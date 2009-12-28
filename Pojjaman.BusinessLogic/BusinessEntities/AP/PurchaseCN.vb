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
    , IApprovAble, IHasIBillablePerson, IReceivable, IWitholdingTaxable, ICancelable


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

    Private m_status As PurchaseCNStatus

    Private m_refDocCollection As PurchaseCNRefDocCollection

    Private m_itemTable As TreeTable

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
      ReLoadItems()
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
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

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 1

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(0)

        .m_receive = New Receive(Me)

        .m_je = New JournalEntry(Me)
        .m_refDocCollection = New PurchaseCNRefDocCollection(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Property RefDocCollection() As PurchaseCNRefDocCollection      Get        Return m_refDocCollection      End Get      Set(ByVal Value As PurchaseCNRefDocCollection)        m_refDocCollection = Value      End Set    End Property
    Public Property Supplier() As Supplier      Get        Return m_supplier      End Get      Set(ByVal Value As Supplier)        m_supplier = Value      End Set    End Property    Public Property DocDate() As Date Implements IVatable.Date, IPayable.Date, IGLAble.Date, IReceivable.Date, IWitholdingTaxable.Date      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        Me.m_je.DocDate = Value      End Set    End Property    Public Property FromCostCenter() As CostCenter      'Get      '  Dim ccId As Integer = 0      '  For Each ref As PurchaseCNRefDoc In Me.RefDocCollection
      '    If ccId <> ref.Vatitem.CcId Then
      '      If ccId <> 0 Then
      '        ccId = 0
      '        Exit For
      '      End If
      '      ccId = ref.Vatitem.CcId
      '    End If
      '  Next      '  If m_fromCostCenter Is Nothing OrElse Not m_fromCostCenter.Originated Then      '    If ccId <> 0 Then      '      Return New CostCenter(ccId)
      '    Else
      '      Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '    End If      '  End If      '  If m_fromCostCenter.Id = ccId Then      '    If ccId <> 0 Then      '      Return m_fromCostCenter
      '    Else
      '      Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '    End If      '  End If      '  Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)      'End Get      Get
        Return m_fromCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_fromCostCenter = Value
        'ValidateCCandType()
      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then          Return Me.FromCostCenter.StoreAccount
        End If      End Get    End Property    Public Property Vat() As Vat Implements IVatable.Vat      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set    End Property    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property    Public Property Note() As String Implements IPayable.Note, IGLAble.Note, IReceivable.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Long      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Long)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, PurchaseCNStatus)      End Set    End Property    Private m_gross As Decimal    Public ReadOnly Property Gross() As Decimal      Get        Return m_gross + Me.RefDocCollection.Amount      End Get    End Property    Public ReadOnly Property TaxGross() As Decimal      Get        Return m_taxGross      End Get    End Property    Public ReadOnly Property GrossWithDoc() As Decimal
      Get
        Return m_gross + Me.RefDocCollection.Amount
      End Get
    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property DiscountAmount() As Decimal      Get        Me.Discount.AmountBeforeDiscount = Me.Gross        Return Me.Discount.Amount      End Get    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Private m_taxbase As Decimal    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Return m_taxbase
      End Get
      Set(ByVal Value As Decimal)
        m_taxbase = Value
      End Set
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Return (Me.TaxRate * Me.TaxBase) / 100      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Description.ToLower
          Case "ไม่มี"
            Return Me.Gross - Me.DiscountAmount
          Case "แยก"
            Return Me.Gross - Me.DiscountAmount
          Case "รวม"
						Return Configuration.Format(Vat.GetExcludedVatAmount(Me.AfterTax - Me.m_unTaxGross, Me.TaxRate) + Me.m_unTaxGross, DigitConfig.Price)
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        Select Case Me.TaxType.Description.ToLower
          Case "ไม่มี"
            Return Me.BeforeTax
          Case "แยก"
            Return Me.BeforeTax + Me.TaxAmount
          Case "รวม"
            Return Me.Gross - Me.DiscountAmount
        End Select      End Get    End Property    Public Overrides ReadOnly Property ClassName() As String
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
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me

				If Me.CountItem = 0 AndAlso Me.RefDocCollection.Count <= 0 Then
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

        '---- AutoCode Format --------
        If Not AutoCodeFormat Is Nothing Then


          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.m_je.RefreshGLFormat()
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
                Me.m_je.RefreshGLFormat()
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              'แยก
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.RefreshGLFormat()
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.RefreshGLFormat()
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_je.DocDate = Me.DocDate
        Me.m_receive.Code = m_je.Code
        Me.m_receive.DocDate = m_je.DocDate
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
								Return New SaveErrorException(returnVal.Value.ToString)
							Case -2							'เอกสารถูกอ้างอิงแล้ว
								If Me.IsDirty Then								'ถ้าเอกสารถูกแก้ไข --> ไม่ให้ save
									trans.Rollback()
									Me.ResetID(oldid, oldreceive, oldvat, oldje)
									Return New SaveErrorException(returnVal.Value.ToString)
								End If
							Case Else
						End Select
					ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
						trans.Rollback()
						Me.ResetID(oldid, oldreceive, oldvat, oldje)
						Return New SaveErrorException(returnVal.Value.ToString)
					End If

					SaveDoc(Me.Id, conn, trans)
					SaveDetail(Me.Id, conn, trans)

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
								Return saveReceiveError
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
							Case -1, -2, -5
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
							Me.ResetID(oldid, oldreceive, oldvat, oldje)
							Return saveWhtError
						Else
							Select Case CInt(saveWhtError.Message)
								Case -1, -2
									trans.Rollback()
									Me.ResetID(oldid, oldreceive, oldvat, oldje)
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
							m_je.SetGLFormat(Me.GetDefaultGLFormat)
						End If
            '********************************************
            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              ResetID(oldid, oldreceive, oldvat, oldje)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid, oldreceive, oldvat, oldje)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================


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
						trans.Commit()
					Catch ex As Exception
						trans.Rollback()
						Me.ResetID(oldid, oldreceive, oldvat, oldje)
						Return New SaveErrorException(ex.ToString)
					End Try
					If Not Me.IsDirty AndAlso returnVal.Value.ToString = "-2" Then					'ถ้าเอกสารไม่ถูกแก้ไข --> ให้ save
						Return New SaveErrorException(Me.Id.ToString)
					End If
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
    Private Function SaveDoc(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

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

    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer


      Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)


      da.SelectCommand.Transaction = trans

      Dim cmdInsert As New SqlCommand("Exec [InsertFIFOPurchaseCNItem] " & _
      " @stocki_stock " & _
      ", @stocki_lineNumber " & _
      ", @stocki_cc " & _
      ", @stocki_toacct " & _
      ", @stocki_toacctType " & _
      ", @stocki_acct " & _
      ", @stocki_fromcc" & _
      ", @stocki_tocc" & _
      ", @stocki_tocust" & _
      ", @stocki_refDoc" & _
      ", @stocki_refDocLinenumber" & _
      ", @stocki_refSequence" & _
      ", @stocki_entity" & _
      ", @stocki_entityType" & _
      ", @stocki_itemname" & _
      ", @stocki_unit" & _
      ", @stocki_unitprice" & _
      ", @stocki_discrate" & _
      ", @stocki_discamt" & _
      ", @stocki_unitCost" & _
      ", @stocki_amt" & _
      ", @stocki_qty" & _
      ", @stocki_stockqty" & _
      ", @stocki_unvatable" & _
      ", @stocki_iscancelled" & _
      ", @stocki_note" & _
      ", @stocki_type" & _
      ", @stocki_status" & _
      ", @stocki_fromAcctType", conn)

      cmdInsert.Parameters.Add("@stocki_stock", SqlDbType.Decimal, 18, "stocki_stock")
      cmdInsert.Parameters.Add("@stocki_lineNumber", SqlDbType.Decimal, 18, "stocki_lineNumber")
      cmdInsert.Parameters.Add("@stocki_cc", SqlDbType.Decimal, 18, "stocki_cc")
      cmdInsert.Parameters.Add("@stocki_toacct", SqlDbType.Decimal, 18, "stocki_toacct")
      cmdInsert.Parameters.Add("@stocki_toaccttype", SqlDbType.Decimal, 18, "stocki_toaccttype")
      cmdInsert.Parameters.Add("@stocki_acct", SqlDbType.Decimal, 18, "stocki_acct")
      cmdInsert.Parameters.Add("@stocki_tocc", SqlDbType.Decimal, 18, "stocki_tocc")
      cmdInsert.Parameters.Add("@stocki_tocust", SqlDbType.Decimal, 18, "stocki_tocust")
      cmdInsert.Parameters.Add("@stocki_refdoc", SqlDbType.Decimal, 18, "stocki_refdoc")
      cmdInsert.Parameters.Add("@stocki_refdoclinenumber", SqlDbType.Decimal, 18, "stocki_refdoclinenumber")
      cmdInsert.Parameters.Add("@stocki_refSequence", SqlDbType.Decimal, 18, "stocki_refSequence")
      cmdInsert.Parameters.Add("@stocki_entity", SqlDbType.Decimal, 18, "stocki_entity")
      cmdInsert.Parameters.Add("@stocki_entityType", SqlDbType.Decimal, 18, "stocki_entityType")
      cmdInsert.Parameters.Add("@stocki_itemname", SqlDbType.NVarChar, 1000, "stocki_itemname")
      cmdInsert.Parameters.Add("@stocki_unit", SqlDbType.Decimal, 18, "stocki_unit")
      cmdInsert.Parameters.Add("@stocki_unitprice", SqlDbType.Decimal, 18, "stocki_unitprice")
      cmdInsert.Parameters.Add("@stocki_discrate", SqlDbType.NVarChar, 200, "stocki_discrate")
      cmdInsert.Parameters.Add("@stocki_discamt", SqlDbType.Decimal, 18, "stocki_discamt")
      cmdInsert.Parameters.Add("@stocki_unitcost", SqlDbType.Decimal, 18, "stocki_unitcost")
      cmdInsert.Parameters.Add("@stocki_amt", SqlDbType.Decimal, 18, "stocki_amt")
      cmdInsert.Parameters.Add("@stocki_qty", SqlDbType.Decimal, 18, "stocki_qty")
      cmdInsert.Parameters.Add("@stocki_stockqty", SqlDbType.Decimal, 18, "stocki_stockqty")
      cmdInsert.Parameters.Add("@stocki_unvatable", SqlDbType.Bit, 4, "stocki_unvatable")
      cmdInsert.Parameters.Add("@stocki_iscancelled", SqlDbType.Bit, 4, "stocki_iscancelled")
      cmdInsert.Parameters.Add("@stocki_note", SqlDbType.NVarChar, 2000, "stocki_note")
      cmdInsert.Parameters.Add("@stocki_type", SqlDbType.Decimal, 18, "stocki_type")
      cmdInsert.Parameters.Add("@stocki_status", SqlDbType.Decimal, 18, "stocki_status")

      cmdInsert.Parameters.Add("@stocki_fromcc", Me.ValidIdOrDBNull(Me.FromCostCenter))
      cmdInsert.Parameters.Add("@stocki_fromaccttype", 3) '3=Store Account --- เบิกของได้จาก store เท่านั้น

      cmdInsert.Transaction = trans
      da.InsertCommand = cmdInsert

      'Detete
      SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "DeleteStockItem", _
      New SqlParameter("@stocki_stock", Me.Id))

      Dim ds As New DataSet
      da.Fill(ds, "stockitem")
      Dim i As Integer = 0
      With ds.Tables("stockitem")
        For Each itemRow As TreeRow In Me.ItemTable.Childs
          If ValidateRow(itemRow) Then
            i += 1
            Dim item As New PurchaseCNItem
            item.CopyFromDataRow(itemRow)
            Dim dr As DataRow = .NewRow
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
						.Rows.Add(dr)
					End If
				Next
      End With
      Dim dt As DataTable = ds.Tables("stockitem")
      ' First process deletes.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
    End Function
#End Region

#Region "Items"
    Private m_grouping As Boolean = True
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
      , "GetPurchaseCNItems" _
      , New SqlParameter("@stock_id", Me.Id) _
      , New SqlParameter("@grouping", Me.m_grouping) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New PurchaseCNItem(row, "")
        item.PurchaseCN = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim myItem As New PurchaseCNItem
        Me.ItemTable.AcceptChanges()
        Me.Add(myItem)
      Next
    End Sub
    Public Function Add(ByVal item As PurchaseCNItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.PurchaseCN = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As PurchaseCNItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.PurchaseCN = Me
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
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      Dim item As New PurchaseCNItem
      item.CopyFromDataRow(CType(e.Row, TreeRow))
      e.Row("Amount") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      e.Row("StockQty") = Configuration.FormatToString(item.StockQty, DigitConfig.Qty)
      RefreshTaxBase()
    End Sub
		Private m_taxGross As Decimal
		Private m_unTaxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxbase = 0
			m_unTaxGross = 0

      Dim sumAmountWithVat As Decimal = 0
      If Not Me.ItemTable Is Nothing AndAlso Me.ItemTable.Rows.Count > 0 Then
        For Each row As TreeRow In Me.ItemTable.Rows
          Dim item As New PurchaseCNItem
          item.PurchaseCN = Me
          item.GetAmountFromRow(row)
          m_gross += item.Amount
          If Not item.UnVatable Then
            m_taxGross += item.Amount
						sumAmountWithVat += item.Amount
					Else
						m_unTaxGross += item.Amount
					End If
				Next
      End If

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
            If Not IsNumeric(e.ProposedValue.ToString) Then
              e.ProposedValue = ""
            Else
              If IsNumeric(e.ProposedValue.ToString) Then
                SetQty(e)
              End If
            End If
          Case "stocki_unitprice"
            If Not IsNumeric(e.ProposedValue.ToString) Then
              e.ProposedValue = ""
            Else
              If IsNumeric(e.ProposedValue.ToString) Then
                SetUnitPrice(e)
              End If
            End If
          Case "accountcode"
            SetAccount(e)
          Case "stocki_entitytype"
            SetEntityType(e)
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
      If IsNumeric(e.Row("stocki_unitprice")) Then
        Dim stocki_unitprice As Object = e.Row("stocki_unitprice")
        If IsNumeric(e.Row("stocki_qty")) Then
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
            Select Case CInt(stocki_entitytype)
              Case 160, 162 'Note
                e.Row.SetColumnError("stocki_qty", "")
                e.Row.SetColumnError("stocki_unitprice", "")
                e.Row.SetColumnError("accountcode", "")
                e.Row.SetColumnError("stocki_itemname", "")
                e.Row.SetColumnError("code", "")
              Case 0 'blank item
                If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                  e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                Else
                  e.Row.SetColumnError("stocki_itemname", "")
                End If
                If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                  e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                Else
                  e.Row.SetColumnError("stocki_qty", "")
                End If
                If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                  e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                Else
                  e.Row.SetColumnError("stocki_unitprice", "")
                End If
                If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                  e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                Else
                  e.Row.SetColumnError("accountcode", "")
                End If
                e.Row.SetColumnError("code", "")
              Case 19 'เครื่องมือ
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
                If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                  e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                Else
                  e.Row.SetColumnError("stocki_qty", "")
                End If
                If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                  e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                Else
                  e.Row.SetColumnError("stocki_unitprice", "")
                End If
                If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                  e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                Else
                  e.Row.SetColumnError("accountcode", "")
                End If
              Case 88, 89 'F/A
                If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                  e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                Else
                  e.Row.SetColumnError("stocki_itemname", "")
                End If
                If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                  e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                Else
                  e.Row.SetColumnError("stocki_qty", "")
                End If
                If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                  e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                Else
                  e.Row.SetColumnError("stocki_unitprice", "")
                End If
                If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                  e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                Else
                  e.Row.SetColumnError("accountcode", "")
                End If
                e.Row.SetColumnError("code", "")
              Case 42 'LCI
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
                If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 OrElse IsNumeric(stocki_qty) Then
                  e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                Else
                  e.Row.SetColumnError("stocki_qty", "")
                End If
                If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                  e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                Else
                  e.Row.SetColumnError("stocki_unitprice", "")
                End If
                If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                  e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                Else
                  e.Row.SetColumnError("accountcode", "")
                End If
              Case Else
                Return
            End Select
          End If
        End If
      End If

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("stocki_entitytype") Then
        Return False
      End If
      Return True
		End Function
		Public Function CountItem() As Integer
			Dim i As Integer
			Dim stocki_entitytype As Object
			i = 0
			For Each row As TreeRow In Me.ItemTable.Rows
				If ValidateRow(row) Then
					stocki_entitytype = row("stocki_entitytype")
					If CInt(stocki_entitytype) <> 162 AndAlso CInt(stocki_entitytype) <> 160 AndAlso CInt(stocki_entitytype) <> 160 Then
						i += 1
					End If
				End If
			Next
			Return i
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
				Case 160, 162			 'Note
					msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
				Case 0, 19, 28, 42, 88, 89
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
				Case 160, 162
					msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
				Case 0, 19, 28, 42, 88, 89
					'ผ่าน
				Case Else
					msgServ.ShowMessage("${res:Global.Error.NoItemType}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
			End Select
			m_updating = False
		End Sub
		Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
			If m_updating Then
				Return
			End If
			m_updating = True
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If e.Row.IsNull(e.Column) Then
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
				If IsNumeric(e.ProposedValue) Then
					Select Case CInt(e.ProposedValue)
						Case 0, 28, 88, 89
							e.Row("Button") = "invisible"
							e.Row("UnitButton") = ""
							e.Row("AccountButton") = ""
						Case 160, 162
							e.Row("Button") = "invisible"
							e.Row("UnitButton") = "invisible"
							e.Row("AccountButton") = "invisible"
						Case Else
							e.Row("Button") = ""
							e.Row("UnitButton") = ""
							e.Row("AccountButton") = ""
					End Select
				End If
				m_updating = False
				Return
			End If

			If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
				'ผ่านโลด
				m_updating = False
				Return
			End If
			If msgServ.AskQuestion("${res:Global.Question.ChangePurchaseCNEntityType}") Then
				ClearRow(e)
				If Not IsDBNull(e.ProposedValue) Then
					Select Case CInt(e.ProposedValue)
						Case 0
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
						Case 88, 89
							e.Row("Button") = "invisible"
							e.Row("UnitButton") = ""
							e.Row("AccountButton") = ""
						Case 19, 42
							Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOtherIncome)
							If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
								e.Row("stocki_acct") = ga.Account.Id
								e.Row("AccountCode") = ga.Account.Code
								e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
							Else
								e.Row("stocki_acct") = DBNull.Value
								e.Row("AccountCode") = DBNull.Value
								e.Row("Account") = DBNull.Value
							End If
							e.Row("Button") = ""
							e.Row("UnitButton") = ""
							e.Row("AccountButton") = ""
						Case 160, 162
							e.Row("Button") = "invisible"
							e.Row("UnitButton") = "invisible"
							e.Row("AccountButton") = "invisible"
					End Select
				End If
			Else
				e.ProposedValue = e.Row(e.Column)
				m_updating = False
				Return
			End If
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
			If IsNumeric(e.ProposedValue) Then
				Select Case CInt(e.ProposedValue)
					Case 0, 28, 88, 89
						e.Row("Button") = "invisible"
						e.Row("UnitButton") = ""
						e.Row("AccountButton") = ""
					Case 160, 162
						e.Row("Button") = "invisible"
						e.Row("UnitButton") = "invisible"
						e.Row("AccountButton") = "invisible"
					Case Else
						e.Row("Button") = ""
						e.Row("UnitButton") = ""
						e.Row("AccountButton") = ""
				End Select
			End If
		End Sub
		Public Sub SetAccount(ByVal e As DataColumnChangeEventArgs)
			If m_updating Then
				Return
			End If
			m_updating = True
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If e.Row.IsNull("stocki_entityType") Then
				msgServ.ShowMessage("${res:Global.Error.NoItemType}")
				e.ProposedValue = e.Row(e.Column)
				m_updating = False
				Return
			End If
			Dim entity As New Account(e.ProposedValue.ToString)
			If entity.Originated Then
				Select Case CInt(e.Row("stocki_entityType"))
					Case 160, 162
						msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveAccount}")
						e.ProposedValue = e.Row(e.Column)
						m_updating = False
						Return
					Case Else
						e.Row("stocki_acct") = entity.Id
						e.ProposedValue = entity.Code
						e.Row("Account") = entity.Name
						m_updating = False
						Return
				End Select
			Else
				Select Case CInt(e.Row("stocki_entityType"))
					Case 160, 162				'Note
						e.Row("stocki_acct") = DBNull.Value
						e.ProposedValue = DBNull.Value
						e.Row("Account") = DBNull.Value
						m_updating = False
						Return
					Case 0
						e.Row("stocki_acct") = DBNull.Value
						e.ProposedValue = DBNull.Value
						e.Row("Account") = DBNull.Value
						m_updating = False
						Return
					Case 28				'สินทรัพย์
						Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.GeneralAsset)
						If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
							e.Row("stocki_acct") = ga.Account.Id
							e.ProposedValue = ga.Account.Code
							e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
							m_updating = False
							Return
						End If
						e.Row("stocki_acct") = DBNull.Value
						e.ProposedValue = DBNull.Value
						e.Row("Account") = DBNull.Value
						m_updating = False
						Return
					Case 88				'ค่าแรง
						Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.SalaryWage)
						If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
							e.Row("stocki_acct") = ga.Account.Id
							e.ProposedValue = ga.Account.Code
							e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
							m_updating = False
							Return
						End If
						e.Row("stocki_acct") = DBNull.Value
						e.ProposedValue = DBNull.Value
						e.Row("Account") = DBNull.Value
						m_updating = False
						Return
					Case 89				'ค่าเช่าเครื่องจักร
						Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherExpense)
						If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
							e.Row("stocki_acct") = ga.Account.Id
							e.ProposedValue = ga.Account.Code
							e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
							m_updating = False
							Return
						End If
						e.Row("stocki_acct") = DBNull.Value
						e.ProposedValue = DBNull.Value
						e.Row("Account") = DBNull.Value
						m_updating = False
						Return
					Case 19				'Tool
						Dim item As New PurchaseCNItem
						item.CopyFromDataRow(CType(e.Row, TreeRow))
						If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
							Dim myTool As Tool = CType(item.Entity, Tool)
							Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOther)
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
					Case 42				' Lci
						Dim item As New PurchaseCNItem
						item.CopyFromDataRow(CType(e.Row, TreeRow))
						If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
							Dim lci As LCIItem = CType(item.Entity, LCIItem)
							If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
								e.Row("stocki_acct") = lci.Account.Id
								e.ProposedValue = lci.Account.Code
								e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
								m_updating = False
								Return
							End If
						End If
						e.Row("stocki_acct") = DBNull.Value
						e.ProposedValue = DBNull.Value
						e.Row("Account") = DBNull.Value
						m_updating = False
						Return
					Case Else
						msgServ.ShowMessage("${res:Global.Error.NoItemType}")
						e.ProposedValue = e.Row(e.Column)
						m_updating = False
						Return
				End Select
			End If
			m_updating = False
		End Sub
		Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
			If m_updating Then
				Return
			End If
			m_updating = True
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If e.Row.IsNull("stocki_entityType") Then
				msgServ.ShowMessage("${res:Global.Error.NoItemType}")
				e.ProposedValue = e.Row(e.Column)
				m_updating = False
				Return
			End If
			Select Case CInt(e.Row("stocki_entityType"))
				Case 160, 162			 'Note
					'ผ่าน
				Case 0, 28, 88, 89
					'ผ่าน
				Case 19, 42
					If Not e.Row.IsNull("Code") AndAlso e.Row("Code").ToString.Length > 0 Then
						'มี Code อยู่ ---> 
						If Not IsDBNull(e.ProposedValue) AndAlso Not e.ProposedValue.ToString.Length = 0 Then
							Dim item As New PurchaseCNItem
							item.CopyFromDataRow(CType(e.Row, TreeRow))
							Dim suffix As String = "<" & item.Entity.Name & ">"
							If e.ProposedValue.ToString <> suffix Then
								If e.ProposedValue.ToString.EndsWith(suffix) Then
									Dim s As String = e.ProposedValue.ToString
									e.ProposedValue = s.Remove(s.Length - suffix.Length, suffix.Length)
								End If
							End If
							If e.ProposedValue.ToString <> item.Entity.Name Then
								e.ProposedValue = e.ProposedValue.ToString & suffix
							End If
						End If
					Else
						msgServ.ShowMessage("${res:Global.Error.ItemCodeMissing}")
						e.ProposedValue = e.Row(e.Column)
						m_updating = False
						Return
					End If
				Case Else
					msgServ.ShowMessage("${res:Global.Error.NoItemType}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
			End Select
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
			If e.Row.IsNull("stocki_entityType") Then
				msgServ.ShowMessage("${res:Global.Error.NoItemType}")
				e.ProposedValue = e.Row(e.Column)
				m_updating = False
				Return
			End If
			If DupCode(e) Then
				Dim item As New PurchaseCNItem
				item.CopyFromDataRow(CType(e.Row, TreeRow))
				msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
				e.ProposedValue = e.Row(e.Column)
				m_updating = False
				Return
			End If
			Select Case CInt(e.Row("stocki_entityType"))
				Case 160, 162			 'Note
					msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveCode}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
				Case 0, 88, 89			 'Blank
					msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
				Case 28			 'F/A
					msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
				Case 19			 'Tool
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
					Dim myTool As New Tool(e.ProposedValue.ToString)
					If Not myTool.Originated Then
						msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
						e.ProposedValue = e.Row(e.Column)
						m_updating = False
						Return
					Else
						Dim myUnit As Unit = myTool.Unit
						e.Row("stocki_entity") = myTool.Id
						e.ProposedValue = myTool.Code
						e.Row("stocki_itemName") = myTool.Name
						e.Row("EntityName") = myTool.Name
						If Not myUnit Is Nothing AndAlso myUnit.Originated Then
							e.Row("stocki_unit") = myUnit.Id
							e.Row("Unit") = myUnit.Name
						Else
							e.Row("stocki_unit") = DBNull.Value
							e.Row("Unit") = DBNull.Value
						End If
						Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOther)
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
				Case 42			 'LCI
					If e.ProposedValue.ToString.Length = 0 Then
						If e.Row(e.Column).ToString.Length <> 0 Then
							If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
								ClearRow(e)
							Else
								e.ProposedValue = e.Row(e.Column)
							End If
						End If
						m_updating = False
						Return
					End If
					Dim lci As New LCIItem(e.ProposedValue.ToString)
					If Not lci.Originated Then
						msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
						e.ProposedValue = e.Row(e.Column)
						m_updating = False
						Return
					Else
						Dim myUnit As Unit = lci.DefaultUnit
						e.Row("stocki_entity") = lci.Id
						e.ProposedValue = lci.Code
						e.Row("stocki_itemName") = lci.Name
						e.Row("EntityName") = lci.Name
						If Not myUnit Is Nothing AndAlso myUnit.Originated Then
							e.Row("stocki_unit") = myUnit.Id
							e.Row("Unit") = myUnit.Name
						Else
							e.Row("stocki_unit") = DBNull.Value
							e.Row("Unit") = DBNull.Value
						End If
						If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
							e.Row("stocki_acct") = lci.Account.Id
							e.Row("AccountCode") = lci.Account.Code
							e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
						Else
							e.Row("stocki_acct") = DBNull.Value
							e.Row("AccountCode") = DBNull.Value
							e.Row("Account") = DBNull.Value
						End If
					End If
				Case Else
					msgServ.ShowMessage("${res:Global.Error.NoItemType}")
					e.ProposedValue = e.Row(e.Column)
					m_updating = False
					Return
			End Select
			e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
			m_updating = False
		End Sub
		Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
			If m_updating Then
				Return
			End If
			Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
			If CInt(e.Row("stocki_entityType")) = 160 Or CInt(e.Row("stocki_entityType")) = 162 Then
				msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnit}")
				e.ProposedValue = e.Row(e.Column)
				m_updating = False
				Return
			End If
			Dim item As New PurchaseCNItem
			item.CopyFromDataRow(CType(e.Row, TreeRow))
			Dim oldConversion As Decimal = item.Conversion
			Dim newConversion As Decimal = 1
			Dim myUnit As New Unit(e.ProposedValue.ToString)
			Dim err As String = ""
			If Not myUnit Is Nothing AndAlso myUnit.Originated Then
				If TypeOf item.Entity Is LCIItem Then
					If Not CType(item.Entity, LCIItem).ValidUnit(myUnit) Then
						err = "${res:Global.Error.NoUnitConversion}"
					Else
						newConversion = CType(item.Entity, LCIItem).GetConversion(myUnit)
					End If
				ElseIf TypeOf item.Entity Is Tool Then
					If Not (Not CType(item.Entity, Tool).Unit Is Nothing AndAlso CType(item.Entity, Tool).Unit.Id = myUnit.Id) Then
						err = "${res:Global.Error.NoUnitConversion}"
					End If
				End If
			Else
				err = "${res:Global.Error.InvalidUnit}"
			End If
			If err.Length = 0 Then
				e.Row("stocki_unit") = myUnit.Id
				e.ProposedValue = myUnit.Name
				If Not e.Row.IsNull("stocki_qty") AndAlso e.Row("stocki_qty").ToString.Length > 0 Then
					e.Row("stocki_qty") = (oldConversion / newConversion) * CDec(e.Row("stocki_qty"))
				End If
				If Not e.Row.IsNull("stocki_unitprice") AndAlso e.Row("stocki_unitprice").ToString.Length > 0 Then
					e.Row("stocki_unitprice") = (newConversion / oldConversion) * CDec(e.Row("stocki_unitprice"))
				End If
			Else
				e.ProposedValue = e.Row(e.Column)
				msgServ.ShowMessage(err)
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
      If Me.TaxAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B6.9"
        ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
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
      'ส่วนลดการค้า
      If Me.DiscountAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "Through"
        ji.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.TradeDiscount4).Account
        ji.Note = Me.StringParserService.Parse("${res:Global.TradeDiscount}")
        ji.Amount = Me.DiscountAmount
        If Me.FromCostCenter.Originated Then
          ji.CostCenter = Me.FromCostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)
      End If
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
      For i As Integer = 0 To Me.MaxRowIndex
        Dim item As New PurchaseCNItem
        item.PurchaseCN = Me
        item.CopyFromDataRow(CType(Me.ItemTable.Rows(i), TreeRow))
        If item.UnVatable Then
          Return True
        End If
      Next
      Return False
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As New JournalEntryItem
      For i As Integer = 0 To Me.MaxRowIndex
        Dim item As New PurchaseCNItem
        item.PurchaseCN = Me
        item.CopyFromDataRow(CType(Me.ItemTable.Rows(i), TreeRow))
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

      For n As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
        If ValidateRow(itemRow) Then

          'If Not itemRow.IsNull("stocki_entity") Then
          'itemRow("whti_type") = 0


          'Item.LineNumber (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = n + 1
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.code (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.code"
          dpi.Value = itemRow("Code")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Name (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Name"
          dpi.Value = itemRow("stocki_itemName")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Unit (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit"
          dpi.Value = itemRow("unit")
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.UnitPrice (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice"
          dpi.Value = Configuration.FormatToString(CDec(itemRow("stocki_unitprice")), DigitConfig.Price)
          dpi.DataType = "System.Decimal"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Qty (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty"
          'dpi.Value = Configuration.FormatToString(CDec(itemRow("StockQty")), DigitConfig.Price)
          dpi.Value = Configuration.FormatToString(CDec(itemRow("stocki_qty")), DigitConfig.Price)
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.DiscountRate (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.DiscountRate"
          If IsNumeric(itemRow("stocki_discrate")) Then
            dpi.Value = Configuration.FormatToString(CDec(itemRow("stocki_discrate")), DigitConfig.Price)
          Else
            dpi.Value = itemRow("stocki_discrate")
          End If
          dpi.DataType = "System.Decimal"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Amount (am เพิ่ม)
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(CDec(itemRow("Amount")), DigitConfig.Price)
          dpi.DataType = "System.Decimal"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

        End If
      Next

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
      For i As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        If ValidateRow(itemRow) And itemRow.Level <> 0 Then
          Dim item As New PurchaseCNItem
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

          n += 1
        End If
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
      Return Me.AfterTax
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

  End Class

  Public Class PurchaseCNItem

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
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_wbsdColl = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      m_wbsdColl = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      m_wbsdColl = New WBSDistributeCollection
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
    Public Property WbsdColl() As WBSDistributeCollection      Get        Return m_wbsdColl      End Get      Set(ByVal Value As WBSDistributeCollection)        m_wbsdColl = Value      End Set    End Property
    Public Property Sequence() As Integer      Get        Return m_sequence      End Get      Set(ByVal Value As Integer)        m_sequence = Value      End Set    End Property
    Public Property PurchaseCN() As PurchaseCN      Get        Return m_purchaseCN      End Get      Set(ByVal Value As PurchaseCN)        m_purchaseCN = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property RefDocLine() As Integer      Get        Return m_refDocLine      End Get      Set(ByVal Value As Integer)        m_refDocLine = Value      End Set    End Property    Public Property RefDocId() As Integer      Get        Return m_refDocId      End Get      Set(ByVal Value As Integer)        m_refDocId = Value      End Set    End Property    Public Property RefDocCode() As String      Get        Return m_refDocCode      End Get      Set(ByVal Value As String)        m_refDocCode = Value      End Set    End Property    Public Property ItemType() As ItemType      Get        Return m_itemType      End Get      Set(ByVal Value As ItemType)        m_itemType = Value      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value      End Set    End Property    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        m_entityName = Value      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        m_qty = Value      End Set    End Property    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        m_unitPrice = Value      End Set    End Property    Public Property UnitCost() As Decimal      Get        Return m_unitCost      End Get      Set(ByVal Value As Decimal)        m_unitCost = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Account() As Account      Get
        Return Me.m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
      End Set
    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Me.Conversion * Me.Qty      End Get    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value      End Set    End Property
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
    Public ReadOnly Property TaxAmount() As Decimal      Get        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If        Return (Me.PurchaseCN.TaxRate * Me.TaxBase) / 100      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If        Dim myGross As Decimal = Me.PurchaseCN.Gross
        Dim myDiscount As Decimal = Me.PurchaseCN.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If        Select Case Me.PurchaseCN.TaxType.Value
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
        End Select      End Get    End Property
    Public ReadOnly Property AfterTax() As Decimal      Get        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If        Dim myGross As Decimal = Me.PurchaseCN.Gross
        Dim myDiscount As Decimal = Me.PurchaseCN.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If        Select Case Me.PurchaseCN.TaxType.Value
          Case 0
            Return Me.BeforeTax
          Case 1
            Return Me.BeforeTax + Me.TaxAmount
          Case 2
            Return (Me.AmountWithoutFormat - _
            ( _
            (Me.AmountWithoutFormat / myGross) * myDiscount) _
            )
        End Select      End Get    End Property
    Public ReadOnly Property DiscountFromParent() As Decimal
      Get
        If Me.PurchaseCN Is Nothing Then
          Return 0
        End If        Dim myGross As Decimal = Me.PurchaseCN.Gross
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
    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
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
          Dim lci As LCIItem = CType(Me.Entity, LCIItem)
          Me.Conversion = lci.GetConversion(Me.Unit)
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
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("stocki_linenumber")) Then
          Me.LineNumber = CInt(row("stocki_linenumber"))
        End If

        Me.Unit = New Unit
        If Not row.IsNull(("stocki_unit")) Then
          Me.Unit.Id = CInt(row("stocki_unit"))
          Me.Unit.Name = row("Unit").ToString
        End If

        If Not row.IsNull(("stocki_acct")) Then
          Me.Account = New Account(CInt(row("stocki_acct")))
        Else
          Me.Account = New Account
        End If

        If Me.UnitCost <> 0 Then
          row("stocki_unitcost") = Configuration.FormatToString(Me.UnitCost, DigitConfig.Cost)
        Else
          row("stocki_unitcost") = ""
        End If

        If Not row.IsNull(("stocki_entityType")) Then
          Me.ItemType = New ItemType(CInt(row("stocki_entityType")))
          Select Case CInt(row("stocki_entityType"))
            Case 0, 28, 88, 89, 160, 162 'Blank/Asset
              If Not row.IsNull(("stocki_itemName")) Then
                Me.Entity = New BlankItem(row("stocki_itemName").ToString)
                Me.EntityName = row("stocki_itemName").ToString
              Else
                Me.Entity = New BlankItem("")
                Me.EntityName = ""
              End If
            Case Else
              If Not row.IsNull(("stocki_entity")) Then
                Dim o As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(BusinessLogic.Entity.GetFullClassName(CInt(row("stocki_entityType"))))
                If TypeOf o Is IHasName Then
                  Me.Entity = CType(o, IHasName)
                  Me.Entity.Id = CInt(row("stocki_entity"))
                  Me.Entity.Code = row("Code").ToString
                  Me.Entity.Name = row("EntityName").ToString
                End If
              End If
              If Not row.IsNull(("stocki_itemName")) AndAlso Not Me.Entity Is Nothing Then
                Dim suffix As String = "<" & Me.Entity.Name & ">"
                Dim s As String = row("stocki_itemName").ToString
                If s.EndsWith(suffix) Then
                  Me.EntityName = s.Remove(s.Length - suffix.Length, suffix.Length)
                End If
              Else
                Me.EntityName = ""
              End If
          End Select
        End If

        If Not row.IsNull(("stocki_note")) Then
          Me.Note = CStr(row("stocki_note"))
        End If

        GetAmountFromRow(row)

        If Not row.IsNull(("stocki_refdoclinenumber")) Then
          Me.RefDocLine = CInt(row("stocki_refdoclinenumber"))
          If Not row.IsNull("stocki_refdoc") Then
            Me.RefDocId = CInt(row("stocki_refdoc"))
          End If
          If Not row.IsNull("RefDoc_code") Then
            Me.RefDocCode = CStr(row("RefDoc_code"))
          End If
        End If

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
          If IsNumeric(row("stocki_qty")) Then
            Me.Qty = CDec(row("stocki_qty"))
          End If
          End If
      End If
      If Not row.IsNull(("stocki_discrate")) Then
        Me.Discount.Rate = CStr(row("stocki_discrate"))
      End If
      If Not row.IsNull(("stocki_unitprice")) Then
        If CStr(row("stocki_unitprice")).Length = 0 Then
          Me.UnitPrice = 0
        Else
          If IsNumeric(row("stocki_unitprice")) Then
            Me.UnitPrice = CDec(row("stocki_unitprice"))
          End If
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
    Public Property RefDocId() As Integer      Get        Return m_refDocId      End Get      Set(ByVal Value As Integer)        m_refDocId = Value      End Set    End Property    Public Property RefDocCode() As String      Get        Return m_refDocCode      End Get      Set(ByVal Value As String)        m_refDocCode = Value      End Set    End Property    Public Property RefDocType() As Integer      Get        Return m_refDocType      End Get      Set(ByVal Value As Integer)        m_refDocType = Value      End Set    End Property    Public Property RefDocDate() As Date      Get        Return m_refDocDate      End Get      Set(ByVal Value As Date)        m_refDocDate = Value      End Set    End Property    Public Property Vatitem() As Vatitem      Get        Return m_vatitem      End Get      Set(ByVal Value As Vatitem)        m_vatitem = Value      End Set    End Property    Public ReadOnly Property RealAmount() As Decimal
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
    End Property    Public Property Amount() As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property    Public Property Note() As String      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property    Public Property Linenumber() As Integer      Get        Return m_linenumber      End Get      Set(ByVal Value As Integer)        m_linenumber = Value      End Set    End Property
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
    Public Property PurchaseCN() As PurchaseCN      Get        Return m_cn      End Get      Set(ByVal Value As PurchaseCN)        m_cn = Value      End Set    End Property
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
