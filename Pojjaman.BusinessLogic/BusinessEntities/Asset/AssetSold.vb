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

  Public Class AssetSold
    Inherits SimpleBusinessEntityBase
    Implements IVatable, IWitholdingTaxable, IBillIssuable, IPrintableEntity, IGLAble, IHasIBillablePerson, IHasFromCostCenter, ICancelable, ICheckPeriod


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

    Private m_itemTable As TreeTable

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
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
      End With
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

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 0

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_receive = New Receive(Me)

        .m_je = New JournalEntry(Me)
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        Dim oldPerson As IBillablePerson = m_customer
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If        m_customer = Value      End Set    End Property    Public Property DocDate() As Date Implements IVatable.Date, IWitholdingTaxable.Date, IReceivable.Date, IGLAble.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public Property FromCostCenter() As CostCenter      Get        Return m_fromCostCenter      End Get      Set(ByVal Value As CostCenter)        m_fromCostCenter = Value      End Set    End Property    Public Property FromCostCenterPerson() As Employee      Get        Return m_fromCostCenterPerson      End Get      Set(ByVal Value As Employee)        m_fromCostCenterPerson = Value      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then          Return Me.FromCostCenter.StoreAccount
        End If      End Get    End Property    Public Property PoDocCode() As String      Get        Return m_poDocCode      End Get      Set(ByVal Value As String)        m_poDocCode = Value      End Set    End Property    Public Property PoDocDate() As Date      Get        Return m_poDocDate      End Get      Set(ByVal Value As Date)        m_poDocDate = Value      End Set    End Property    Public Property Vat() As Vat Implements IVatable.Vat      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set    End Property    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property    Public Property Note() As String Implements IReceivable.Note, IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Private m_gross As Decimal    Public ReadOnly Property Gross() As Decimal      Get        Return m_gross      End Get    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property DiscountAmount() As Decimal      Get        Me.Discount.AmountBeforeDiscount = Me.Gross        Return Me.Discount.Amount      End Get    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Private m_taxbase As Decimal    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            Return m_taxbase          Case 2 '"รวม"
            If Me.DiscountAmount = 0 Then 'แบบ basic ไม่มีส่วนลดท้ายบิล
              Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
            End If
            Return m_taxbase        End Select
        Return m_taxbase
      End Get
      Set(ByVal Value As Decimal)
        m_taxbase = Value
      End Set
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case Else '1,2
            Return (Me.TaxRate * Me.TaxBase) / 100        End Select      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.Gross - Me.DiscountAmount
          Case 1 '"แยก"
            Return Me.Gross - Me.DiscountAmount
          Case 2 '"รวม"
            Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax, Me.TaxRate), DigitConfig.Price)
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax
          Case 1 '"แยก"
            Return Me.BeforeTax + Me.TaxAmount
          Case 2 '"รวม"
            Return Me.Gross - Me.DiscountAmount
        End Select      End Get    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AssetSold"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetSold.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AssetSold"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AssetSold"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AssetSold.ListLabel}"
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
      Dim myDatatable As New TreeTable("AssetSold")
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
      myDatatable.Columns.Add(New DataColumn("deprecalcamt", GetType(Double)))

      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldvat As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
      Me.m_vat.Id = oldvat
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
      Me.m_je.Id = oldje
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Me.RefreshTaxBase()
        Dim tmpTaxBase As Decimal = Configuration.Format(Me.TaxBase, DigitConfig.Price)
        Dim tmpVatTaxBase As Decimal = Configuration.Format(Me.Vat.TaxBase, DigitConfig.Price)
        If tmpTaxBase <> tmpVatTaxBase Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
          New String() {Configuration.FormatToString(tmpVatTaxBase, DigitConfig.Price) _
          , Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)})
        End If
        If Me.MaxRowIndex < 0 Then
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
        If Me.Status.Value = -1 Then
          Me.Status = New CheckStatus(2)
        End If

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
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
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discRate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discAmt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.TaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.TaxAmount))
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
        Dim oldreceive As Integer = m_receive.Id
        Dim oldvat As Integer = m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldje As Integer = m_je.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          'ChangeOldItemStatus(conn, trans)
          Dim saveItemError As SaveErrorException = Me.SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveItemError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return saveItemError
          Else
            Select Case CInt(saveItemError.Message)
              Case -1, -2
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return saveItemError
              Case Else
            End Select
          End If
          'ChangeNewItemStatus(conn, trans)
          If Not Me.FromCostCenter Is Nothing Then
            Me.m_receive.CcId = Me.FromCostCenter.Id
            Me.m_whtcol.SetCCId(Me.FromCostCenter.Id)
            Me.m_vat.SetCCId(Me.FromCostCenter.Id)
          End If
          Dim savePaymentError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
          If Not IsNumeric(savePaymentError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return savePaymentError
          Else
            Select Case CInt(savePaymentError.Message)
              Case -1, -2
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return savePaymentError
              Case Else
            End Select
          End If
          Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveVatError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return saveVatError
          Else
            Select Case CInt(saveVatError.Message)
              Case -1, -2
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                Return saveVatError
              Case Else
            End Select
          End If

          If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
            Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveWhtError.Message) Then
              trans.Rollback()
              ResetID(oldid, oldreceive, oldvat, oldje)
              Return saveWhtError
            Else
              Select Case CInt(saveWhtError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid, oldreceive, oldvat, oldje)
                  Return saveWhtError
                Case Else
              End Select
            End If
          End If

          Me.DeleteRef(conn, trans)
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If
          trans.Commit()
          Try
            trans = conn.BeginTransaction()


            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If
            Me.m_grouping = False
            Me.ReLoadItems()
            '********************************************
            If Not Me.JournalEntry.ManualFormat Then
              If Not (Me.m_je.GLFormat.Originated) Then
                Dim glf As GLFormat = Me.GetDefaultGLFormat
                If Not glf Is Nothing Then
                  m_je.SetGLFormat(glf)
                End If
              End If
            End If
            '********************************************
            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveJeError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldreceive, oldvat, oldje)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldreceive, oldvat, oldje)
                  Return saveJeError
                Case -2
                  'Post ไปแล้ว
                  Return saveJeError
                Case Else
              End Select
            End If
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetSoldStatus" _
            , New SqlParameter("@stock_id", Me.Id))

            trans.Commit()
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid, oldreceive, oldvat, oldje)
            Return New SaveErrorException(ex.ToString)
          End Try
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldvat, oldje)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldreceive, oldvat, oldje)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
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
      For Each tr As TreeRow In Me.m_itemTable.Childs
        If ValidateRow(tr) Then

        End If
      Next
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewStockItemStatus", New SqlParameter("@stock_id", Me.Id))
    End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        '----------------HACK------------------------------------
        Try
          Dim cmd As New SqlCommand("delete StockItem where stocki_stock = " & Me.Id, conn)
          cmd.Transaction = trans
          cmd.ExecuteNonQuery()
        Catch ex As Exception
          Throw New Exception(ex.ToString)
        End Try
        '----------------HACK------------------------------------

        Dim ds As New DataSet

        '***********----WBS ----****************
        Dim da As New SqlDataAdapter("Select * from StockItem where 1=2", conn)
        Dim cb As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans

        da.DeleteCommand = cb.GetDeleteCommand
        da.DeleteCommand.Transaction = trans

        da.InsertCommand = cb.GetInsertCommand
        da.InsertCommand.Transaction = trans

        da.UpdateCommand = cb.GetUpdateCommand
        da.UpdateCommand.Transaction = trans

        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        da.FillSchema(ds, SchemaType.Mapped, "StockItem")
        da.Fill(ds, "StockItem")

        Dim dtMatCounti As DataTable
        Dim dc As DataColumn
        dtMatCounti = ds.Tables("StockItem")


        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        'AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

        For Each dr As DataRow In dtMatCounti.Rows
          dr.Delete()
        Next
        Dim i As Integer = 0
        For Each tr As TreeRow In Me.m_itemTable.Childs
          If ValidateRow(tr) Then
            i += 1
            Dim drFi As DataRow = dtMatCounti.NewRow
            drFi("stocki_stock") = Me.Id
            drFi("stocki_linenumber") = i

            drFi("stocki_cc") = Me.ValidIdOrDBNull(Me.FromCostCenter)
            drFi("stocki_fromcc") = Me.ValidIdOrDBNull(Me.FromCostCenter)
            drFi("stocki_tocc") = DBNull.Value
            drFi("stocki_acct") = tr("stocki_acct")
            drFi("stocki_toacct") = DBNull.Value

            drFi("stocki_entity") = tr("stocki_entity")
            drFi("stocki_entityType") = tr("stocki_entityType")
            drFi("stocki_itemName") = tr("stocki_itemName")

            drFi("stocki_unit") = tr("stocki_unit")
            drFi("stocki_toacctType") = DBNull.Value

            drFi("stocki_qty") = 1
            drFi("stocki_stockqty") = 1

            drFi("stocki_unitprice") = tr("stocki_unitprice")
            drFi("stocki_unvatable") = tr("stocki_unvatable")
            drFi("stocki_note") = tr("stocki_note")

            drFi("stocki_type") = Me.EntityId
            drFi("stocki_status") = Me.Status.Value

            drFi("stocki_refSequence") = 0
            drFi("stocki_tag") = tr("deprecalcamt")

            dtMatCounti.Rows.Add(drFi)
          End If
        Next

        tmpDa.Update(GetDeletedRows(dtMatCounti))
        tmpDa.Update(dtMatCounti.Select("", "", DataViewRowState.ModifiedCurrent))

        ds.EnforceConstraints = False

        tmpDa.Update(dtMatCounti.Select("", "", DataViewRowState.Added))

        ds.EnforceConstraints = True

        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function

    Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows

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

#Region "Items"
    Private m_grouping As Boolean = False
    Public Overloads Sub ReLoadItems()
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems()
      Me.IsInitialized = True
    End Sub
    Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      Me.IsInitialized = True
    End Sub
    Private Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetAssetSoldItems" _
      , New SqlParameter("@stock_id", Me.Id) _
      , New SqlParameter("@grouping", Me.m_grouping) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New AssetSoldItem(row, "")
        item.AssetSold = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim myItem As New AssetSoldItem
        Me.ItemTable.AcceptChanges()
        myItem.AssetSold = Me
        Me.Add(myItem)
      Next
    End Sub
    Public Function Add(ByVal item As AssetSoldItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.AssetSold = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As AssetSoldItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.AssetSold = Me
      item.CopyToDataRow(myRow)
      ReIndex(index + 1)
      Return myRow
    End Function
    Public Sub Remove(ByVal index As Integer)
      Me.ItemTable.Childs.Remove(Me.ItemTable.Childs(index))
      ReIndex()
    End Sub
    Private Sub ReIndex()
      ReIndex(0)
    End Sub
    Private Sub ReIndex(ByVal index As Integer)
      If index < 0 OrElse index > Me.ItemTable.Childs.Count - 1 Then
        Return
      End If
      For i As Integer = index To Me.ItemTable.Childs.Count - 1
        Me.ItemTable.Childs(i)("stocki_linenumber") = i + 1
      Next
    End Sub
    Public Function MaxRowIndex() As Integer
      If Me.m_itemTable Is Nothing Then
        Return -1
      End If
      'ให้ค่า index ของแถวสุดท้ายที่มีข้อมูล
      For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
        Dim row As TreeRow = Me.m_itemTable.Childs(i)
        If ValidateRow(row) Then
          Return i
        End If
      Next
      Return -1 'ไม่มีข้อมูลเลย
    End Function
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      'If CType(e.Row, TreeRow).Level = 0 Then
      '    Return
      'End If
      Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        If index = Me.m_itemTable.Childs.Count - 1 Then
          Me.AddBlankRow(1)
        End If
        Dim pe As New PropertyChangedEventArgs
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            UpdateDepreciation(e)
            pe.Name = "ItemChanged"
          Case "stocki_unitprice", "stocki_unvatable", "stocki_discrate", "stocki_qty", "unit"
            UpdateAmount(e)
            pe.Name = "QtyChanged"
          Case Else
            pe.Name = "ItemChanged"
        End Select
        Me.OnPropertyChanged(Me, pe)
        Me.m_itemTable.AcceptChanges()
      End If
    End Sub
    Public Sub ReUpdateDepreciation()
      For Each row As TreeRow In Me.ItemTable.Rows
        If ValidateRow(row) Then
          Dim assetitem As New Asset(CInt(row("stocki_entity")))
          Dim depreopeningamnt As Decimal = 0
          Dim depreamntinprocess As Decimal = 0
          Dim lastestCalcDate As Date = assetitem.GetLastCalcDate(Nothing)
          If lastestCalcDate.Equals(Date.MinValue) Then
            depreopeningamnt = assetitem.DepreOpening

            'depreamntinprocess = CDec(assetitem.DepreCalcAtDate(Me.DocDate))
            'row("deprecalcamt") = Configuration.FormatToString(depreamntinprocess, DigitConfig.Price)
            row("deprecalcamt") = Configuration.FormatToString(depreopeningamnt, DigitConfig.Price)
          Else
            If lastestCalcDate.Date <= Me.DocDate Then
              depreopeningamnt = CDec(assetitem.DepreCalcAtDate(lastestCalcDate.Date))
            End If

            depreamntinprocess = CDec(assetitem.DepreCalcAtDate(Me.DocDate))
            Dim depre As Double = depreamntinprocess - depreopeningamnt
            row("deprecalcamt") = Configuration.FormatToString(depre, DigitConfig.Price)
          End If

          'row("deprecalcamt") = Configuration.FormatToString(depre, DigitConfig.Price)

          'Dim item As New AssetSoldItem
          'item.AssetSold = Me
          'item.CopyFromDataRow(CType(row, TreeRow))
        End If
      Next
    End Sub
    Private Sub UpdateDepreciation(ByVal e As DataColumnChangeEventArgs)
      If Not e.Row.IsNull("stocki_entity") Then
        Dim assetItem As New Asset(CInt(e.Row("stocki_entity")))

        Dim depreopeningamnt As Double
        Dim lastestCalcDate As Date = assetItem.GetLastCalcDate(Nothing)
        If lastestCalcDate.Equals(Date.MinValue) Then
          depreopeningamnt = assetItem.DepreOpening

          If assetItem.Originated Then
            Dim item As New AssetSoldItem
            item.AssetSold = Me

            'Dim depre As Double = assetItem.DepreCalcAtDate(Me.DocDate)
            item.CopyFromDataRow(CType(e.Row, TreeRow))
            'item.DepreCalculation = depre
            item.DepreCalculation = depreopeningamnt
            e.Row("deprecalcamt") = Configuration.FormatToString(item.DepreCalculation, DigitConfig.Price)
          End If
        Else
          If lastestCalcDate.Date <= Me.DocDate Then
            depreopeningamnt = CDec(assetItem.DepreCalcAtDate(lastestCalcDate.Date))
          End If

          If assetItem.Originated Then
            Dim item As New AssetSoldItem
            item.AssetSold = Me

            Dim depre As Double = assetItem.DepreCalcAtDate(Me.DocDate)
            item.CopyFromDataRow(CType(e.Row, TreeRow))
            item.DepreCalculation = depre - depreopeningamnt
            e.Row("deprecalcamt") = Configuration.FormatToString(item.DepreCalculation, DigitConfig.Price)
          End If
        End If


      End If
    End Sub
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      Dim item As New AssetSoldItem
      item.AssetSold = Me
      item.CopyFromDataRow(CType(e.Row, TreeRow))
      e.Row("Amount") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      e.Row("StockQty") = Configuration.FormatToString(item.StockQty, DigitConfig.Qty)
      RefreshTaxBase()
    End Sub
    Public Sub RefreshTaxBase()
      If Me.ItemTable Is Nothing OrElse Me.ItemTable.Rows.Count = 0 Then        m_gross = 0
      Else
        Dim amt As Decimal = 0        For Each row As TreeRow In Me.ItemTable.Rows
          Dim item As New AssetSoldItem
          item.GetAmountFromRow(row)
          amt += item.Amount
        Next        m_gross = amt
      End If
      If Me.Gross = 0 Then
        Me.TaxBase = 0
        Return
      End If
      Select Case Me.TaxType.Value
        Case 0 '"ไม่มี"
          Me.TaxBase = 0
        Case 1 '"แยก"
          Dim myGross As Decimal = Me.Gross
          Dim myDiscount As Decimal = Me.DiscountAmount
          Dim sumInItems As Decimal = 0
          For Each row As TreeRow In Me.ItemTable.Rows
            Dim item As New AssetSoldItem
            item.GetAmountFromRow(row)
            If Not item.UnVatable Then
              sumInItems += (item.Amount - _
              ( _
              (item.Amount / myGross) * myDiscount) _
              )
            End If
          Next
          Me.TaxBase = sumInItems
        Case 2 '"รวม"
          Dim myGross As Decimal = Me.Gross
          Dim myDiscount As Decimal = Me.DiscountAmount
          Dim sumInItems As Decimal = 0
          For Each row As TreeRow In Me.ItemTable.Rows
            Dim item As New AssetSoldItem
            item.GetAmountFromRow(row)
            If Not item.UnVatable Then
              sumInItems += (item.Amount - ((item.Amount / myGross) * myDiscount)) * (100 / (Me.TaxRate + 100))
            End If
          Next
          Me.TaxBase = sumInItems
      End Select
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      'If CType(e.Row, TreeRow).Level = 0 Then
      '    Return
      'End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            SetCode(e)
          Case "stocki_itemname"
            SetName(e)
          Case "unit"
            SetUnitValue(e)
          Case "stocki_qty"
            SetQty(e)
          Case "stocki_unitprice"
            SetUnitPrice(e)
          Case "accountcode"
            SetAccount(e)

        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim code As Object = e.Row("code")
      Dim stocki_itemname As Object = e.Row("stocki_itemname")
      Dim stocki_entitytype As Object = e.Row("stocki_entitytype")
      Dim accountcode As Object = e.Row("accountcode")
      Dim unit As Object = e.Row("unit")
      Dim stocki_unitprice As Object = e.Row("stocki_unitprice")
      Dim stocki_qty As Object = e.Row("stocki_qty")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          code = e.ProposedValue
        Case "stocki_itemname"
          stocki_itemname = e.ProposedValue
        Case "stocki_entitytype"
          stocki_entitytype = e.ProposedValue
        Case "accountcode"
          accountcode = e.ProposedValue
        Case "unit"
          unit = e.ProposedValue
        Case "stocki_unitprice"
          stocki_unitprice = e.ProposedValue
        Case "stocki_qty"
          stocki_qty = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(stocki_entitytype) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
          e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
        Else
          e.Row.SetColumnError("code", "")
        End If
        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
          e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
        Else
          e.Row.SetColumnError("stocki_itemname", "")
        End If

        If IsDBNull(stocki_qty) OrElse (IsNumeric(stocki_qty) AndAlso CDec(stocki_qty) <= 0) Then
          e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
        Else
          e.Row.SetColumnError("stocki_qty", "")
        End If
        If IsDBNull(stocki_unitprice) OrElse CStr(stocki_unitprice).ToString.Length <= 0 OrElse (IsNumeric(stocki_unitprice) AndAlso CDec(stocki_unitprice) <= 0) Then
          e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
        Else
          e.Row.SetColumnError("stocki_unitprice", "")
        End If
        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
          e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
        Else
          e.Row.SetColumnError("accountcode", "")
        End If
      End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("stocki_entity") Then
        Return False
      End If
      Return True
    End Function
    Private m_updating As Boolean = False
    Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("stocki_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("stocki_entityType"))
        Case 0, 19, 28, 42
          'ผ่าน
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub
    Public Sub SetUnitPrice(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.UnitPrice)
      Dim value As Decimal = CDec(e.ProposedValue)
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("stocki_entityType") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Select Case CInt(e.Row("stocki_entityType"))
        Case 0, 19, 28, 42
          'ผ่าน
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          e.ProposedValue = e.Row(e.Column)
          m_updating = False
          Return
      End Select
      m_updating = False
    End Sub

    Private Sub ClearRow(ByVal e As DataColumnChangeEventArgs)
      e.Row("stocki_entity") = DBNull.Value
      e.Row("stocki_itemname") = DBNull.Value
      e.Row("Amount") = DBNull.Value
      e.Row("stocki_qty") = DBNull.Value
      e.Row("StockQty") = DBNull.Value
      e.Row("stocki_unit") = DBNull.Value
      e.Row("stocki_unitprice") = DBNull.Value
      e.Row("stocki_discrate") = DBNull.Value
      e.Row("Unit") = DBNull.Value
      e.Row("UnitButton") = DBNull.Value
      e.Row("stocki_unvatable") = False
      e.Row("stocki_note") = DBNull.Value
      e.Row("Amount") = DBNull.Value
      e.Row("code") = DBNull.Value
      e.Row("stocki_acct") = DBNull.Value
      e.Row("AccountCode") = DBNull.Value
      e.Row("AccountButton") = ""
      e.Row("Account") = DBNull.Value
      e.Row("Button") = ""
      e.Row("deprecalcamt") = DBNull.Value
    End Sub
    Public Sub SetAccount(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.Row.IsNull("stocki_entity") Then
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      Dim entity As New Account(e.ProposedValue.ToString)
      If entity.Originated Then
        If entity.IsControlGroup Then
          Dim myMsgService As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          myMsgService.ShowError(entity.Code & "-" & entity.Name & " เป็นบัญชีคุม")
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherIncome)
          If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            e.Row("stocki_acct") = ga.Account.Id
            e.ProposedValue = ga.Account.Code
            e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            m_updating = False
            Return
          End If
        Else
          e.Row("stocki_acct") = entity.Id
          e.ProposedValue = entity.Code
          e.Row("Account") = entity.Name
          m_updating = False
          Return
        End If

      Else
        Dim item As New AssetSoldItem
        item.CopyFromDataRow(CType(e.Row, TreeRow))
        If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
          Dim myAsset As Asset = item.Entity
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherIncome)
          If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            e.Row("stocki_acct") = ga.Account.Id
            e.ProposedValue = ga.Account.Code
            e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            m_updating = False
            Return
          End If
        End If
        e.Row("stocki_acct") = DBNull.Value
        e.ProposedValue = DBNull.Value
        e.Row("Account") = DBNull.Value
        m_updating = False
        Return

      End If
      m_updating = False
    End Sub
    Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True

      m_updating = False
    End Sub
    Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
      If e.Row.IsNull("stocki_entityType") Then
        Return False
      End If
      If IsDBNull(e.ProposedValue) Then
        Return False
      End If
      For Each row As TreeRow In Me.ItemTable.Childs
        If Not row Is e.Row Then
          If Not row.IsNull("stocki_entityType") Then
            If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
              If Not row.IsNull("code") Then
                If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
                  Return True
                End If
              End If
            End If
          End If
        End If
      Next
      Return False
    End Function
    Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If
      m_updating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If e.ProposedValue.ToString.Length = 0 Then
        If e.Row(e.Column).ToString.Length <> 0 Then
          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
            ClearRow(e)
          Else
            e.ProposedValue = e.Row(e.Column)
          End If
        End If
        m_updating = False
        Return
      End If
      Dim myItem As New Asset(e.ProposedValue.ToString)
      If myItem.Status.Value = 5 Then 'ถูกขายไปแล้ว
        msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.BusinessLogic.AssetSold.Sold}", New String() {e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      End If
      If Not myItem.Originated Then
        msgServ.ShowMessageFormatted("${res:Global.Error.NoAsset}", New String() {e.ProposedValue.ToString})
        e.ProposedValue = e.Row(e.Column)
        m_updating = False
        Return
      Else
        Dim myUnit As Unit = myItem.Unit
        e.Row("stocki_entity") = myItem.Id
        e.ProposedValue = myItem.Code
        e.Row("stocki_itemName") = myItem.Name
        If Not myUnit Is Nothing AndAlso myUnit.Originated Then
          e.Row("stocki_unit") = myUnit.Id
          e.Row("Unit") = myUnit.Name
        Else
          e.Row("stocki_unit") = DBNull.Value
          e.Row("Unit") = DBNull.Value
        End If
        Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherIncome)
        If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
          e.Row("stocki_acct") = ga.Account.Id
          e.Row("AccountCode") = ga.Account.Code
          e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
        Else
          e.Row("stocki_acct") = DBNull.Value
          e.Row("AccountCode") = DBNull.Value
          e.Row("Account") = DBNull.Value
        End If
      End If

      e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      'e.Row("stocki_stockqty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      m_updating = False
    End Sub
    Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      If m_updating Then
        Return
      End If

    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
      'Dim row As DataRow = e.Row
      'Me.m_itemTable.Childs.Remove(CType(row, TreeRow))
      'Try
      '    If Not Me.m_isInitialized Then
      '        Return
      '    End If

      '    Dim index As TreeRow = CType(e.Row, TreeRow)
      '    Me.m_itemTable.Childs.Remove(index)
      'Catch ex As Exception
      '    MessageBox.Show(ex.ToString)
      'End Try
    End Sub
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    'Dim jiCollSummary As New JournalEntryItemCollection
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      If Me.Amount > 0 Then
        ' DR. ค่าเสื่อมราคา          costcenter เดิม           ji.Mapping = "I6.1"
        SetGLI7_1(jiColl)
        ' CR. ค่าเสื่อมราคาสะสม  costcenter เดิม           ji.Mapping = "I6.2"
        SetGLI7_2(jiColl)
        ' dr. ค่าเสื่อราคาสะสมทั้งหมด
        SetGLI7_3(jiColl)
        ' cr. สินทรัพย์ทั้งหมด
        SetGLI7_4(jiColl)
        ' dr.ลูกหนี้การค้า
        SetGLI7_5(jiColl)
        ' cr.กำไรจากการขายสินทรัพย์
        SetGLI7_6(jiColl)
        ' cr.ภาษีขาย
        SetGLI7_7(jiColl)
        ' dr.ภาษีหัก ณ ที่จ่าย
        SetGLI7_8(jiColl)

      End If

      ' ผังบัญชีการขายสินค้า มี มาตรฐานให้ใช้อยู่แล้ว ไม่ต้องหาอีกครั้งนะจ๊ะ
      If Not Me.Receive Is Nothing Then
        jiColl.AddRange(Me.Receive.GetJournalEntries(Me.FromCostCenter))
      End If

      'For Each ji2 As JournalEntryItem In jiColl
      '  If Not ji2.Mapping = "I7.9" Then
      '    jiCollSummary.Add(ji2)
      'Next
      If Me.Amount > 0 Then
        ' Cr.กำไร(ขาดทุน)จากการขายสินทรัพย์
        SetGLI7_9(jiColl)
      End If

      Return jiColl
    End Function
    ' dr. ค่าเสื่อมราคาเพิ่มเติมจนถึงวันที่ขาย
    Private Sub SetGLI7_1(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      For Each trow As TreeRow In Me.ItemTable.Childs
        If ValidateRow(trow) Then
          Dim asset As New asset(CInt(trow("stocki_entity")))
          If Not asset.DepreAccount Is Nothing Then
            ht(asset.DepreAccount.Id) = asset.DepreAccount
          End If
        End If
      Next
      For Each acct As Account In ht.Values
        Dim Intotalamnt As Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Childs
          If ValidateRow(row) Then
            Dim myAsset As New asset(CInt(row("stocki_entity")))
            'myAsset.DepreciationCalc()
            If myAsset.DepreAccount.Originated AndAlso myAsset.DepreAccount.Id = acct.Id Then
              If Not row.IsNull("deprecalcamt") Then
                Intotalamnt += CDec(row("deprecalcamt"))
              End If
            End If
            'Intotalamnt = CDec(myAsset.DepreLTD)
          End If
        Next
        If Intotalamnt > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I7.1"
          ji.Amount = Intotalamnt
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' cr. ค่าเสื่อมราคาสะสม
    Private Sub SetGLI7_2(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      For Each trow As TreeRow In Me.ItemTable.Childs
        If ValidateRow(trow) Then
          Dim asset As New asset(CInt(trow("stocki_entity")))
          If Not asset.DepreOpeningAccount Is Nothing Then
            ht(asset.DepreOpeningAccount.Id) = asset.DepreOpeningAccount
          End If
        End If
      Next
      For Each acct As Account In ht.Values
        Dim Intotalamnt As Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Childs
          If ValidateRow(row) Then
            Dim myAsset As New asset(CInt(row("stocki_entity")))
            'myAsset.DepreciationCalc()
            If myAsset.DepreOpeningAccount.Originated AndAlso myAsset.DepreOpeningAccount.Id = acct.Id Then
              If Not row.IsNull("deprecalcamt") Then
                Intotalamnt += CDec(row("deprecalcamt"))
              End If
            End If
            'Intotalamnt = CDec(myAsset.DepreLTD)
          End If
        Next
        If Intotalamnt > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I7.2"
          ji.Amount = Intotalamnt
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' dr. ค่าเสื่อราคาสะสมทั้งหมด
    Private Sub SetGLI7_3(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      For Each trow As TreeRow In Me.ItemTable.Childs
        If ValidateRow(trow) Then
          Dim asset As New asset(CInt(trow("stocki_entity")))
          If Not asset.DepreOpeningAccount Is Nothing Then
            ht(asset.DepreOpeningAccount.Id) = asset.DepreOpeningAccount
          End If
        End If
      Next
      For Each acct As Account In ht.Values
        Dim Intotalamnt As Double = 0 'Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Childs
          If ValidateRow(row) Then
            Dim myAsset As New asset(CInt(row("stocki_entity")))
            If myAsset.DepreOpeningAccount.Id = acct.Id Then
              Dim depreamntinprocess As Decimal = 0
              Dim lastestCalcDate As Date = myAsset.GetLastCalcDate(Nothing)
              If lastestCalcDate.Equals(Date.MinValue) Then
                depreamntinprocess = myAsset.DepreOpening
              Else
                depreamntinprocess = CDec(myAsset.DepreCalcAtDate(Me.DocDate))
              End If
              Intotalamnt += myAsset.BuyPrice - depreamntinprocess
            End If
          End If
        Next
        If Intotalamnt > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I7.3"
          ji.Amount = CDec(Intotalamnt)
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' cr. สินทรัพย์ทั้งหมด
    Private Sub SetGLI7_4(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      For Each trow As TreeRow In Me.ItemTable.Childs
        If ValidateRow(trow) Then
          Dim asset As New asset(CInt(trow("stocki_entity")))
          If Not asset.Account Is Nothing Then
            ht(asset.Account.Id) = asset.Account
          End If
        End If
      Next
      For Each acct As Account In ht.Values
        Dim Intotalamnt As Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Childs
          If ValidateRow(row) Then
            Dim myAsset As New asset(CInt(row("stocki_entity")))
            If myAsset.Account.Originated AndAlso myAsset.Account.Id = acct.Id Then
              Dim depreamntinprocess As Decimal = 0
              Dim lastestCalcDate As Date = myAsset.GetLastCalcDate(Nothing)
              If lastestCalcDate.Equals(Date.MinValue) Then
                depreamntinprocess = myAsset.DepreOpening
              Else
                depreamntinprocess = CDec(myAsset.DepreCalcAtDate(Me.DocDate))
              End If
              Intotalamnt += myAsset.BuyPrice - depreamntinprocess
            End If
          End If
        Next
        If Intotalamnt > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I7.4"
          ji.Amount = Intotalamnt
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' dr. ลูกหนี้การค้า
    Private Sub SetGLI7_5(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      If Not Me.Receive Is Nothing Then
        'ส่วนต่างระหว่างยอดรับกับยอดจริง ---> ลูกหนี้
        Me.Receive.UpdateGross()
        If Configuration.Compare(Me.Receive.Gross, Me.Receive.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I7.5"
          ji.Amount = Me.Receive.Amount - Me.Receive.Gross
          If Not Me.Customer.Account Is Nothing AndAlso Me.Customer.Account.Originated Then
            ji.Account = Me.Customer.Account
          End If
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
      End If
    End Sub
    'cr.กำไรจากการขายสินทรัพย์
    Private Sub SetGLI7_6(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable
      For Each trow As TreeRow In Me.ItemTable.Childs
        If ValidateRow(trow) Then
          Dim acctItem As New Account(CInt(trow("stocki_acct")))
          If Not acctItem Is Nothing Then
            ht(acctItem.Id) = acctItem
          End If
        End If
      Next
      For Each acct As Account In ht.Values
        Dim Intotalamnt As Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Childs
          If ValidateRow(row) Then
            Dim myAcct As New Account(CInt(row("stocki_acct")))
            If myAcct.Originated AndAlso myAcct.Id = acct.Id Then
              Dim amt As Decimal
              Dim taxBase As Decimal
              If Not row.IsNull("Amount") Then
                amt = CDec(row("amount"))
              Else
                amt = 0
              End If              Select Case Me.TaxType.Value
                Case 2 '"รวม"
                  taxBase = amt * (100 / (Me.TaxRate + 100))
                Case Else
                  taxBase = amt
              End Select              Intotalamnt += taxBase
            End If
          End If
        Next
        If Intotalamnt > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "I7.6"
          ji.Amount = Intotalamnt
          If acct.Originated Then
            ji.Account = acct
          End If
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
      Next
    End Sub
    ' cr.ภาษีขาย
    Private Sub SetGLI7_7(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      If Me.TaxAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "I7.7"
        ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
        ji.CostCenter = Me.FromCostCenter
        jiColl.Add(ji)
      End If
    End Sub
    'ภาษีหัก ณ ที่จ่าย
    Private Sub SetGLI7_8(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "I7.8"
        ji.Amount = Me.WitholdingTaxCollection.Amount
        ji.CostCenter = Me.FromCostCenter
        jiColl.Add(ji)

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
        ji.CostCenter = Me.FromCostCenter
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
        ji.CostCenter = Me.FromCostCenter
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
        ji.CostCenter = Me.FromCostCenter
            jiColl.Add(ji)
          End If
        Next
      End If
    End Sub
    'กำไร(ขาดทุน)จากการขายสินทรัพย์
    Private Sub SetGLI7_9(ByVal jiColl As JournalEntryItemCollection)
      Dim ji As New JournalEntryItem
      Dim ht As New Hashtable

      Dim debitAmt As Decimal = 0
      Dim creditAmt As Decimal = 0

      'Dim je As New JournalEntry(Me)
      'For Each jiItem As JournalEntryItem In jiColl
      '  je.ItemCollection.Add(jiItem)
      ''Next
      'For Each jiItem As JournalEntryItem In je.ItemCollection
      '  If jiItem.IsDebit Then
      '    debitAmt += jiItem.Amount
      '  Else
      '    creditAmt += jiItem.Amount
      '  End If
      'Next

      Dim jli As New JournalEntryItemCollection

      For Each glfi As GLFormatItem In Me.JournalEntry.GLFormat.ItemCollection
        If glfi.Mapping.ToLower.IndexOf("sumdebit") < 0 AndAlso glfi.Mapping.ToLower.IndexOf("sumcredit") < 0 Then
          Dim matchItems As JournalEntryItemCollection = jiColl.GetMappingItems(glfi)
          For Each matchItem As JournalEntryItem In matchItems
            If Not matchItem.Mapping = "I7.9" Then
              matchItem.IsDebit = glfi.IsDebit
              jli.Add(matchItem)
            End If
          Next
        End If
      Next

      For Each jiItem As JournalEntryItem In jli
        If jiItem.IsDebit Then
          debitAmt += jiItem.Amount
        Else
          creditAmt += jiItem.Amount
        End If
      Next

      If debitAmt <> creditAmt Then
        ji = New JournalEntryItem
        ji.Mapping = "I7.9"
        ji.Amount = debitAmt - creditAmt
        ji.CostCenter = Me.FromCostCenter
        jiColl.Add(ji)
      End If

    End Sub
    Public Property JournalEntry() As JournalEntry Implements IGLAble.journalEntry
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
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return Me.TaxType.Value = 0
      End Get
    End Property
#End Region

#Region "IWitholdingTaxable"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.AfterTax
    End Function
#End Region

#Region "IBillAcceptable"
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


      If Not Me.Customer Is Nothing AndAlso Me.Customer.Originated Then
        'Customer
        dpi = New DocPrintingItem
        dpi.Mapping = "Customer"
        dpi.Value = Me.Customer.Code & ":" & Me.Customer.Name
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
      End If

      If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then
        'CostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenter"
        dpi.Value = Me.FromCostCenter.Code & ":" & Me.FromCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromCostCenterPerson Is Nothing AndAlso Me.FromCostCenterPerson.Originated Then
        'Requestor
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceivePerson"
        dpi.Value = Me.FromCostCenterPerson.Code & ":" & Me.FromCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Me.CreditPeriod
      dpi.DataType = "System.Int32"
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

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
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
      For i As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        If ValidateRow(itemRow) Then 'And itemRow.Level <> 0 Then
          Dim item As New AssetSoldItem
          item.CopyFromDataRow(itemRow)
          'Item.LineNumber
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = n + 1
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
          dpi.Value = item.Entity.Name
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

          'Item.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Note"
          dpi.Value = item.Note
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

          n += 1
        End If
      Next
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAssetSold}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAssetSold", New SqlParameter() {New SqlParameter("@stock_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.AssetSoldIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetSoldStatus" _
        , New SqlParameter("@stock_id", Me.Id))
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
        Return False
        'UNDONE
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

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.FromCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.FromCostCenter = Value
      End Set
    End Property


  End Class
End Namespace
