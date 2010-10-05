Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class POItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_po As PO
    Private m_lineNumber As Integer

    Private m_pritem As PRItem

    Private m_itemType As ItemType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Private m_originQty As Decimal
    Private m_originAmt As Decimal
    Public m_qty As Decimal
    Private m_unitPrice As Decimal
    Private m_note As String
    Private m_receivedQty As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")
    Private m_conversion As Decimal = 1
    Private m_unitCost As Decimal

    Private m_WBSDistributeCollection As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_WBSDistributeCollection = New WBSDistributeCollection
      AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "pri_entityType") AndAlso Not dr.IsNull("pri_entityType") Then
          Me.m_pritem = New PRItem(dr, aliasPrefix)
          Dim myPR As New PR

          If dr.Table.Columns.Contains(aliasPrefix & "pri_pr") AndAlso Not dr.IsNull(aliasPrefix & "pri_pr") Then
            myPR.Id = CInt(dr(aliasPrefix & "pri_pr"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "pr_code") AndAlso Not dr.IsNull(aliasPrefix & "pr_code") Then
            myPR.Code = CStr(dr(aliasPrefix & "pr_code"))
          End If
          Me.m_pritem.Pr = myPR
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "poi_entityType") AndAlso Not dr.IsNull(aliasPrefix & "poi_entityType") Then
          .m_itemType = New ItemType(CInt(dr(aliasPrefix & "poi_entityType")))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "poi_entity") AndAlso Not dr.IsNull(aliasPrefix & "poi_entity") Then
          itemId = CInt(dr(aliasPrefix & "poi_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "poi_itemName") AndAlso Not dr.IsNull(aliasPrefix & "poi_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "poi_itemName"))
        Else
          .m_entityName = ""
        End If
        Select Case .m_itemType.Value
          Case 42 '"lci"
            'If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
            .m_entity = LCIItem.GetLciItemById(itemId)
            '  If Not dr.IsNull("lci_id") Then
            '    .m_entity = New LCIItem(dr, "")
            '  End If
            'Else
            '  .m_entity = New LCIItem(itemId)
            'End If
          Case 19 '"tool"
            If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("tool_id") Then
                .m_entity = New Tool(dr, "")
              End If
            Else
              .m_entity = New Tool(itemId)
            End If
          Case 88, 89
            If itemId > 0 Then
              If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
                .m_entity = LCIItem.GetLciItemById(itemId)
                '  If Not dr.IsNull("lci_id") Then
                '    .m_entity = New LCIItem(dr, "")
                '  End If
              Else
                .m_entity = New BlankItem(.m_entityName)
              End If
            Else
              .m_entity = New BlankItem(.m_entityName)
            End If
          Case Else       '0, 28, 88, 89, 160, 162
            .m_entity = New BlankItem(.m_entityName)
        End Select

        If dr.Table.Columns.Contains(aliasPrefix & "poi_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "poi_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "poi_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "poi_originqty") AndAlso Not dr.IsNull(aliasPrefix & "poi_originqty") Then
          .m_originQty = CDec(dr(aliasPrefix & "poi_originqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "poi_originamt") AndAlso Not dr.IsNull(aliasPrefix & "poi_originamt") Then
          .m_originAmt = CDec(dr(aliasPrefix & "poi_originamt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "poi_qty") AndAlso Not dr.IsNull(aliasPrefix & "poi_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "poi_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "poi_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "poi_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "poi_unitprice"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "poi_receivedQty") AndAlso Not dr.IsNull(aliasPrefix & "poi_receivedQty") Then
          .m_receivedQty = CDec(dr(aliasPrefix & "poi_receivedQty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "poi_amt") AndAlso Not dr.IsNull(aliasPrefix & "poi_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "poi_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "poi_note") AndAlso Not dr.IsNull(aliasPrefix & "poi_note") Then
          .m_note = CStr(dr(aliasPrefix & "poi_note"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
        '  If Not dr.IsNull("unit_id") Then
        '    .m_unit = New Unit(dr, "")
        '  End If
        'Else

        If dr.Table.Columns.Contains(aliasPrefix & "poi_unit") AndAlso Not dr.IsNull(aliasPrefix & "poi_unit") Then
          m_unit = New Unit
          '.m_unit = New Unit(CInt(dr(aliasPrefix & "poi_unit")))
          Dim unitId As Nullable(Of Integer) = CInt(dr(aliasPrefix & "poi_unit"))
          If unitId.HasValue AndAlso unitId.Value > 0 Then
            .m_unit = Unit.GetUnitById(unitId.Value)
          End If
        End If
        'End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            'Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              Me.Conversion = CType(Me.Entity, LCIItem).GetConversion(Me.Unit)
            Catch ex As NoConversionException
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              If Not msgServ Is Nothing Then
                msgServ.ShowErrorFormatted("วัสดุ {0} ไม่มีหน่วยนับ {1} ระบุไว้", New String() {ex.Lci.Code, ex.Unit.Name})
              End If
            End Try
          Else
            Me.Conversion = 1
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "poi_discrate") AndAlso Not dr.IsNull(aliasPrefix & "poi_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "poi_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "poi_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "poi_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "poi_unvatable"))
        End If

        'If dr.Table.Columns.Contains(aliasPrefix & "poi_unitCost") AndAlso Not dr.IsNull(aliasPrefix & "poi_unitCost") Then
        '  .m_unitCost = CDec(dr(aliasPrefix & "poi_unitCost"))
        'End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property UnitNet As Decimal
      Get
        Dim m_unitNet As Decimal = 0
        If Me.m_qty <> 0 Then
          m_unitNet = Me.Amount / Me.Qty
        End If
        Return m_unitNet
      End Get
    End Property
    Public Property WBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection
      Get
        Return m_WBSDistributeCollection
      End Get
      Set(ByVal Value As WBSDistributeCollection)
        m_WBSDistributeCollection = Value
      End Set
    End Property
    Public Property Po() As PO      Get        Return m_po      End Get      Set(ByVal Value As PO)        m_po = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Pritem() As PRItem      Get        Return m_pritem      End Get      Set(ByVal Value As PRItem)        m_pritem = Value      End Set    End Property    Public Property ItemType() As ItemType      Get        Return m_itemType      End Get      Set(ByVal Value As ItemType)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemType Is Nothing Then
          m_itemType = Value
          Me.Clear()
          Return
        End If
        If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
          'ผ่านโลด
          Return
        End If
        If msgServ.AskQuestion("${res:Global.Question.ChangePOEntityType}") Then
          Dim oldType As Integer = m_itemType.Value
          m_itemType = Value
          For Each wbsd As WBSDistribute In Me.WBSDistributeCollection            Dim bfTax As Decimal = 0
            If Not Me.Po Is Nothing Then 'AndAlso item.Po.Originated
              If Me.Po.Closed Then
                bfTax = Me.ReceivedBeforeTax
              Else
                bfTax = Me.BeforeTax
              End If
            End If
            Dim transferAmt As Decimal = bfTax
            wbsd.BaseCost = bfTax
            'wbsd.TransferBaseCost = transferAmt            Select Case Me.ItemType.Value
              Case 0, 19, 42
                wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
              Case 88
                wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
              Case 89
                wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
            End Select
            Me.m_po.SetActual(wbsd.WBS, wbsd.Amount, 0, oldType)
            Me.m_po.SetActual(wbsd.WBS, 0, wbsd.Amount, m_itemType.Value)          Next
          'Me.Clear()
        End If      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If      End Set    End Property    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
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
    End Function    Public Sub SetItemCode(ByVal theCode As String)      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPOPricing"))      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.ItemType Is Nothing Then
        'ไม่มี Type
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        Return
      End If
      'If DupCode(theCode) Then
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {Me.ItemType.Description, theCode})
      '    Return
      'End If
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
                unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
                , New SqlParameter("@po_supplier", Po.ValidIdOrDBNull(Po.Supplier)) _
                , New SqlParameter("@poi_entity", myTool.Id) _
                , New SqlParameter("@poi_entitytype", myTool.EntityId) _
                )
              Case 2
                unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
                , New SqlParameter("@po_supplier", DBNull.Value) _
                , New SqlParameter("@poi_entity", myTool.Id) _
                , New SqlParameter("@poi_entitytype", myTool.EntityId) _
                )
            End Select
            Dim myUnit As Unit = myTool.Unit
            Me.m_unit = myUnit
            Me.m_entity = myTool
            If Me.Conversion <> 0 Then
              unitPrice = unitPrice * Conversion
            End If
            Me.UnitPrice = unitPrice
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
                unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
                , New SqlParameter("@po_supplier", Po.ValidIdOrDBNull(Po.Supplier)) _
                , New SqlParameter("@poi_entity", lci.Id) _
                , New SqlParameter("@poi_entitytype", lci.EntityId) _
                )
              Case 2
                unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
                , New SqlParameter("@po_supplier", DBNull.Value) _
                , New SqlParameter("@poi_entity", lci.Id) _
                , New SqlParameter("@poi_entitytype", lci.EntityId) _
                )
            End Select
            Dim myUnit As Unit = lci.DefaultUnit
            Me.m_unit = myUnit
            Me.m_entity = lci
            If Me.Conversion <> 0 Then
              unitPrice = unitPrice * Conversion
            End If
            Me.UnitPrice = unitPrice
          End If

        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
      End Select
      Me.Qty = 1
      Me.ReceivedQty = 0 'UNDONE
    End Sub    Public Sub SetItemPrice(ByVal theCode As String)      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPOPricing"))      Select Case Me.ItemType.Value
        Case 19 'Tool
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim myTool As New Tool(theCode)

          Select Case pricing
            Case 0
              unitPrice = myTool.FairPrice
            Case 1
              unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
              , New SqlParameter("@po_supplier", Po.ValidIdOrDBNull(Po.Supplier)) _
              , New SqlParameter("@poi_entity", myTool.Id) _
              , New SqlParameter("@poi_entitytype", myTool.EntityId) _
              )
            Case 2
              unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
              , New SqlParameter("@po_supplier", DBNull.Value) _
              , New SqlParameter("@poi_entity", myTool.Id) _
              , New SqlParameter("@poi_entitytype", myTool.EntityId) _
              )
          End Select


          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice

        Case 42, 88, 89  'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim lci As New LCIItem(theCode)

          Select Case pricing
            Case 0
              unitPrice = lci.FairPrice
            Case 1
              unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
              , New SqlParameter("@po_supplier", Po.ValidIdOrDBNull(Po.Supplier)) _
              , New SqlParameter("@poi_entity", lci.Id) _
              , New SqlParameter("@poi_entitytype", lci.EntityId) _
              )
            Case 2
              unitPrice = GetAmountFromSproc("GetPOPriceForSupplier" _
              , New SqlParameter("@po_supplier", DBNull.Value) _
              , New SqlParameter("@poi_entity", lci.Id) _
              , New SqlParameter("@poi_entitytype", lci.EntityId) _
              )
          End Select
          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice
      End Select
      Me.Qty = 1
      Me.ReceivedQty = 0    'UNDONE
    End Sub    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
          Case Else '0, 28, 88, 89, 160, 162
            Me.m_entityName = Value
        End Select      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnit}")
          Return
        End If
        Dim oldConversion As Decimal = Me.Conversion
        Dim newConversion As Decimal = 1
        Dim err As String = ""
        If Not Value Is Nothing AndAlso Value.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            If CType(Me.Entity, LCIItem).Level < 5 Then
              newConversion = 1
            Else
              If Not CType(Me.Entity, LCIItem).ValidUnit(Value) Then
                err = "${res:Global.Error.NoUnitConversion}"
              Else
                newConversion = CType(Me.Entity, LCIItem).GetConversion(Value)
              End If
            End If
          ElseIf TypeOf Me.Entity Is Tool Then
            If Not (Not CType(Me.Entity, Tool).Unit Is Nothing AndAlso CType(Me.Entity, Tool).Unit.Id = Value.Id) Then
              err = "${res:Global.Error.NoUnitConversion}"
            End If
          End If
        Else
          err = "${res:Global.Error.InvalidUnit}"
        End If
        If err.Length = 0 Then
          If Me.Qty <> 0 Then
            'Me.m_qty = (oldConversion / newConversion) * Me.m_qty
            Me.Qty = (Me.Qty * oldConversion) / newConversion
          End If
          If Me.UnitPrice <> 0 Then
            'Me.m_unitPrice = (newConversion / oldConversion) * Me.m_unitPrice
            Me.UnitPrice = (Me.UnitPrice / oldConversion) * newConversion
          End If
          m_unit = Value
          Me.Conversion = newConversion
        Else
          msgServ.ShowMessage(err)
        End If      End Set    End Property    Private Sub UpdateWBS()      If Not Me.Po Is Nothing Then        Me.Po.SetRealGross()        Me.Po.RefreshTaxBase()
        For Each wbsd As WBSDistribute In Me.WBSDistributeCollection          Dim bfTax As Decimal = 0
          If Not Me.Po Is Nothing Then 'AndAlso item.Po.Originated
            If Me.Po.Closed Then
              bfTax = Me.ReceivedBeforeTax
            Else
              bfTax = Me.BeforeTax
            End If
          End If
          Dim oldVal As Decimal = wbsd.Amount
          Dim transferAmt As Decimal = bfTax
          wbsd.BaseCost = bfTax
          wbsd.BaseCost = transferAmt          Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.Amount, oldVal))        Next
      End If    End Sub    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
          'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
          Return
        End If        m_qty = Configuration.Format(Value, DigitConfig.Qty)        UpdateWBS()      End Set    End Property    Public Property OriginQty() As Decimal      Get
        Return m_originQty
      End Get
      Set(ByVal Value As Decimal)
        m_originQty = Value
      End Set
    End Property    Public Property OriginAmt() As Decimal      Get
        Return m_originAmt
      End Get
      Set(ByVal Value As Decimal)
        m_originAmt = Value
      End Set
    End Property    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
          Case 0, 19, 28, 42, 88, 89
            'ผ่าน
            m_unitPrice = Value
            UpdateWBS()
          Case Else
            msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        End Select      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property ReceivedQty() As Decimal 'หน่วยตาม QTY ไม่ใช่ STOCKQTY      Get        Return m_receivedQty      End Get      Set(ByVal Value As Decimal)        m_receivedQty = Value      End Set    End Property    Public ReadOnly Property ReceivedAmount() As Decimal      Get
        Return Me.ReceivedQty * Me.UnitPrice
      End Get
    End Property    Public ReadOnly Property ReceivedBeforeTax() As Decimal      Get
        Return Me.CalcBeforeTax(Me.ReceivedAmount, Me.CalcTaxAmount(Me.ReceivedAmount))
      End Get
    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)      End Get    End Property    Public ReadOnly Property UnitCost() As Decimal
      Get
        If Me.StockQty <> 0 Then
          Dim tmpCost As Decimal = 0
          Dim tmpRealGrossNoVat As Decimal = 0

          tmpRealGrossNoVat = Me.Po.RealGross

          If tmpRealGrossNoVat = 0 Then
            Return 0
          End If

          tmpCost = Me.AmountWithDefaultUnit

          tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.Po.Discount.Amount)

          If Me.Po.TaxType.Value = 2 Then
            If Not Me.UnVatable Then
              tmpCost = tmpCost * (100 / (100 + Me.Po.TaxRate))
            End If
          End If

          If Me.StockQty = 0 Then
            Return 0
          End If

          tmpCost = tmpCost / Me.StockQty

          Return tmpCost
        End If
        Return 0
      End Get
    End Property    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property    Public Property Discount() As Discount      Get        Dim amtFormatted As Decimal = Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)        m_discount.AmountBeforeDiscount = amtFormatted        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value      End Set    End Property
    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Private Function CalcTaxAmount(ByVal amt As Decimal) As Decimal
      If Me.Po Is Nothing Then
        Return 0
      End If      Return (Me.Po.TaxRate * amt) / 100
    End Function
    Public ReadOnly Property TaxAmount() As Decimal      Get        Return Me.CalcTaxAmount(Me.TaxBase)      End Get    End Property    Private Function CalcBeforeTax(ByVal amt As Decimal, ByVal tax As Decimal) As Decimal      If Me.Po Is Nothing Then
        Return 0
      End If      Dim myGross As Decimal = Me.Po.Gross
      Dim myDiscount As Decimal = Me.Po.DiscountAmount
      If myGross = 0 Then
        Return 0
      End If      Select Case Me.Po.TaxType.Value
        Case 0
          Return (amt - _
          ( _
          (amt / myGross) * myDiscount) _
          )
        Case 1
          Return (amt - _
          ( _
          (amt / myGross) * myDiscount) _
          )
        Case 2
          Return Me.CalcAfterTax(amt, tax) - tax
      End Select
    End Function    Public ReadOnly Property BeforeTax() As Decimal      Get        Return Me.CalcBeforeTax(Me.AmountWithoutFormat, Me.TaxAmount)      End Get    End Property    Private Function CalcAfterTax(ByVal amt As Decimal, ByVal tax As Decimal) As Decimal      If Me.Po Is Nothing Then
        Return 0
      End If      Dim myGross As Decimal = Me.Po.Gross
      Dim myDiscount As Decimal = Me.Po.DiscountAmount
      If myGross = 0 Then
        Return 0
      End If      Select Case Me.Po.TaxType.Value
        Case 0
          Return Me.CalcBeforeTax(amt, tax)
        Case 1
          Return Me.CalcBeforeTax(amt, tax) + tax
        Case 2
          Return (amt - _
          ( _
          (amt / myGross) * myDiscount) _
          )
      End Select
    End Function    Public ReadOnly Property AfterTax() As Decimal      Get        Return CalcAfterTax(Me.AmountWithoutFormat, Me.TaxAmount)      End Get    End Property
    Private Function CalcTaxBase(ByVal amt As Decimal) As Decimal
      If Me.Po Is Nothing Then
        Return 0
      End If
      Dim myGross As Decimal = Me.Po.Gross
      Dim myDiscount As Decimal = Me.Po.DiscountAmount
      If myGross = 0 Then
        Return 0
      End If
      Select Case Me.Po.TaxType.Value
        Case 0 '"ไม่มี"
          Return 0
        Case 1 '"แยก"
          If Not Me.UnVatable Then
            Return (amt - _
            ( _
            (amt / myGross) * myDiscount) _
            )
          End If
        Case 2 '"รวม"
          If Not Me.UnVatable Then
            Return Vat.GetExcludedVatAmount(amt - ((amt / myGross) * myDiscount), Me.Po.TaxRate)
          End If
      End Select
    End Function
    Public ReadOnly Property DiscountFromParent() As Decimal
      Get
        If Me.Po Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.Po.Gross
        Dim myDiscount As Decimal = Me.Po.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Return (Me.AmountWithoutFormat / myGross) * myDiscount
      End Get
    End Property
    Public ReadOnly Property TaxBase() As Decimal
      Get
        Return CalcTaxBase(Me.Amount)
      End Get
    End Property
    Public ReadOnly Property CostTaxBase() As Decimal
      Get
        Return CalcTaxBase(Me.Cost)
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
    Private m_amount As Decimal
    Public ReadOnly Property Amount() As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Dim amtFormatted As Decimal = Configuration.Format((Me.UnitCost * Me.StockQty), DigitConfig.Price)
        Return amtFormatted - Me.DiscountAmount
      End Get
    End Property
    Public ReadOnly Property AmountWithoutFormat() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = (Me.UnitPrice * Me.Qty)
        Return (Me.UnitPrice * Me.Qty) - Me.Discount.Amount
      End Get
    End Property
    Public ReadOnly Property AmountWithDefaultUnit() As Decimal
      Get
        If StockQty > 0 Then
          Return ((Me.UnitPrice / Me.Conversion) * StockQty) - (Me.Discount.Amount / Me.Conversion)
        Else
          Return 0
        End If
      End Get
    End Property
    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim unit As Object = row("unit")
      Dim code As Object = row("Code")
      Dim poi_itemName As Object = row("poi_itemName")
      Dim poi_qty As Object = row("poi_qty")
      Dim poi_unitprice As Object = row("poi_unitprice")
      Dim poi_entitytype As Object = row("poi_entitytype")

      Dim isClosed As Boolean = False
      isClosed = Me.Po.Closed

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim isBlankRow As Boolean = False
      If IsDBNull(poi_entitytype) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        Select Case CInt(poi_entitytype)
          Case 160, 162 'Note
            row.SetColumnError("poi_qty", "")
            row.SetColumnError("poi_unitprice", "")
            row.SetColumnError("poi_itemname", "")
            row.SetColumnError("code", "")
          Case 0, 88, 89 'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(poi_itemName) OrElse poi_itemName.ToString.Length = 0 Then
              row.SetColumnError("poi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("poi_itemName", "")
            End If
            If Not IsNumeric(poi_qty) Then 'OrElse CDec(poi_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("poi_qty", "")
              Else
                row.SetColumnError("poi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
            Else
              row.SetColumnError("poi_qty", "")
            End If
            'If Not IsNumeric(poi_unitprice) Then 'OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If

            row.SetColumnError("poi_unitprice", "")
            row.SetColumnError("code", "")
          Case 19 'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(poi_itemName) OrElse poi_itemName.ToString.Length = 0 Then
              row.SetColumnError("poi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("poi_itemName", "")
            End If
            If Not IsNumeric(poi_qty) Then 'OrElse CDec(poi_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("poi_qty", "")
              Else
                row.SetColumnError("poi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
            Else
              row.SetColumnError("poi_qty", "")
            End If
            'If Not IsNumeric(poi_unitprice) Then 'OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If
            row.SetColumnError("poi_unitprice", "")
          Case 28 'F/A
            If IsDBNull(poi_itemName) OrElse poi_itemName.ToString.Length = 0 Then
              row.SetColumnError("poi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("poi_itemName", "")
            End If
            If Not IsNumeric(poi_qty) Then 'OrElse CDec(poi_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("poi_qty", "")
              Else
                row.SetColumnError("poi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
            Else
              row.SetColumnError("poi_qty", "")
            End If
            'If Not IsNumeric(poi_unitprice) Then 'OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If
            row.SetColumnError("poi_unitprice", "")
            row.SetColumnError("code", "")
          Case 42 'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(poi_itemName) OrElse poi_itemName.ToString.Length = 0 Then
              row.SetColumnError("poi_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("poi_itemName", "")
            End If
            If Not IsNumeric(poi_qty) Then 'OrElse CDec(poi_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("poi_qty", "")
              Else
                row.SetColumnError("poi_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
            Else
              row.SetColumnError("poi_qty", "")
            End If
            'If Not IsNumeric(poi_unitprice) Then ' OrElse CDec(poi_unitprice) <= 0 Then
            '    row.SetColumnError("poi_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("poi_unitprice", "")
            'End If
            row.SetColumnError("poi_unitprice", "")
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Sub CopyFromPRItem(ByVal prItem As PRItem)

      Dim newPritem As New PRItem(prItem.Pr.Id, prItem.LineNumber)
      Me.m_pritem = prItem
      Me.m_itemType = prItem.ItemType
      Me.m_entity = prItem.Entity
      Me.m_entityName = prItem.EntityName
      Me.m_unit = prItem.Unit
      Me.m_qty = Math.Max(prItem.Qty - (prItem.WithdrawnQty + prItem.OrderedQty), 0)
      Me.m_unitPrice = prItem.UnitPrice
      Me.m_note = prItem.Note

      If Not newPritem.WBSDistributeCollection Is Nothing Then
        Me.WBSDistributeCollection = newPritem.WBSDistributeCollection.Clone(Me)

        'เพิ่มตรงนี้มา --> เพราะของเดิมแก้ % , wbs แล้วค่าคงเหลือไม่เปลี่ยน
        AddHandler Me.WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler

      End If
    End Sub
    Public Sub Clear()
      Me.m_pritem = Nothing
      Me.m_entity = New BlankItem("")
      Me.m_entityName = ""
      Me.m_qty = 0
      Me.m_receivedQty = 0
      Me.m_unit = New Unit
      Me.m_unitPrice = 0
      Me.m_note = ""
      Me.m_discount = New Discount("")
      Me.m_unvatable = False
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Try
        Me.Po.IsInitialized = False

        If Not Me.Pritem Is Nothing Then
          row("pri_linenumber") = Me.Pritem.LineNumber
          If Not Me.Pritem.Entity Is Nothing Then
            row("pri_entity") = Me.Pritem.Entity.Id
            row("pri_entityType") = Me.Pritem.ItemType.Value
            row("PRItemCode") = Me.Pritem.Entity.Code
            row("PRItemName") = Me.Pritem.Entity.Name
          End If

          If Not Me.Pritem.Unit Is Nothing Then
            row("PRItemUnit") = Me.Pritem.Unit.Name
          End If
          row("pri_qty") = Me.Pritem.Qty
          row("PRItemRemainingQty") = Me.Pritem.Qty
          If Not Me.Pritem.Pr Is Nothing Then
            row("pr_code") = Me.Pritem.Pr.Code
            row("pri_pr") = Me.Pritem.Pr.Id
          End If
        End If

        row("poi_linenumber") = Me.LineNumber
        If Not Me.ItemType Is Nothing Then
          row("poi_entityType") = Me.ItemType.Value
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("poi_entity") = Me.Entity.Id
                row("poi_itemName") = Me.Entity.Name
                row("EntityName") = Me.Entity.Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("poi_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                row("poi_entity") = Me.Entity.Id
                row("poi_itemName") = Me.Entity.Name
                row("EntityName") = Me.Entity.Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("poi_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 0, 28   ', 88, 89
              row("Button") = "invisible"
              row("poi_itemName") = Me.EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("poi_itemName") = Me.EntityName
          End Select
        End If

        If Not Me.Unit Is Nothing Then
          row("poi_unit") = Me.Unit.Id
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

        Dim parent As PO = Me.Po
        If parent Is Nothing Then parent = New PO

        If Me.Qty <> 0 Then
          row("poi_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("poi_qty") = ""
        End If
        If Me.OriginQty <> 0 Then
          row("poi_originqty") = Configuration.FormatToString(Me.OriginQty, DigitConfig.Qty)
        Else
          row("poi_originqty") = ""
        End If
        If Me.UnitPrice <> 0 Then
          row("poi_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("poi_unitprice") = ""
        End If

        row("poi_discrate") = Me.Discount.Rate
        If Me.Amount <> 0 Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If

        row("poi_note") = Me.Note
        If Me.ReceivedQty <> Decimal.MinValue AndAlso Me.ReceivedQty <> 0 Then
          'row("ReceivedQty") = Configuration.FormatToString(Me.ReceivedQty / Me.Conversion, DigitConfig.Qty)
          row("ReceivedQty") = Configuration.FormatToString(Me.ReceivedQty, DigitConfig.Qty)
        Else
          row("ReceivedQty") = DBNull.Value
        End If
        row("poi_unvatable") = Me.UnVatable

        Me.Po.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Function GetReceivedQty() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.Po.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetStockedQty" _
      , New SqlParameter("@po_id", Me.Po.Id) _
      , New SqlParameter("@entity_id", Me.Entity.Id) _
      , New SqlParameter("@linenumber", Me.LineNumber) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        If IsNumeric(ds.Tables(0).Rows(0)("receivedQty")) Then
          Return CDec(ds.Tables(0).Rows(0)("receivedQty"))
        End If
      End If
    End Function
#End Region


    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'If TypeOf sender Is WBSDistribute Then
      '  Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
      '  Select Case e.Name.ToLower
      '    Case "percent"
      '      If Not Me.m_po Is Nothing Then
      '        Me.m_po.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
      '      End If
      '    Case "wbs"
      '      Dim oldWBS As WBS = CType(e.OldValue, WBS)
      '      Dim newWBS As WBS = CType(e.Value, WBS)
      '      Select Case Me.ItemType.Value
      '        Case 0, 19, 42
      '          wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
      '        Case 88
      '          wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
      '        Case 89
      '          wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
      '      End Select
      '      Me.m_po.SetActual(oldWBS, wbsd.TransferAmount, 0, Me.ItemType.Value)
      '      Me.m_po.SetActual(newWBS, 0, wbsd.TransferAmount, Me.ItemType.Value)
      '  End Select
      'End If
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            If Not Me.m_po Is Nothing Then

              'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "amount"
            If Not Me.m_po Is Nothing Then

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
            If wbsd.IsMarkup Then
              wbsd.BudgetRemain = newWBS.GetTotalMarkUpFromDB - newWBS.GetWBSActualFromDB(Me.Po.Id, Me.Po.EntityId, Me.ItemType.Value)
              wbsd.QtyRemain = 0
            Else
              wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.Po.Id, Me.Po.EntityId, Me.ItemType.Value)
              If Me.ItemType.Value <> 88 And Me.ItemType.Value <> 89 Then
                wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.Po.Id, Me.Po.EntityId, Me.Entity.Id, _
                                                                              Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
              Else
                wbsd.QtyRemain = 0
              End If
            End If

        End Select
      End If
    End Sub

    Public Sub UpdateWBSQty()
      If Me.ItemType.Value <> 88 AndAlso Me.ItemType.Value <> 89 Then
        For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
          If wbsd.IsMarkup Then
            wbsd.BaseQty = 0
          Else
            Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, Me.ItemType.Value)
            If boqConversion = 0 Then
              wbsd.BaseQty = Me.Qty
            Else
              wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
            End If
          End If
        Next
      Else
        For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
          wbsd.BaseQty = 0
        Next
      End If
    End Sub

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
          Case 88
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
        If Me.Entity.Code.Length = 0 Then
          Return Trim(Me.EntityName)
        End If
        Return Me.Entity.Code & " : " & Trim(Me.Entity.Name)
      End Get
    End Property

    Public ReadOnly Property Type As String Implements IWBSAllocatableItem.Type
      Get
        If Me.ItemType Is Nothing Then
          Return ""
        End If
        Dim strType As String = CodeDescription.GetDescription("stocki_enitytype", ItemType.Value)
        Return strType
      End Get
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
Public Class POItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_po As PO
    Private m_prHash As Hashtable
    Private m_currentItem As POItem
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As PO)
      Me.m_po = owner
      m_prHash = New Hashtable
      If Not Me.m_po.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim sproc As String = "GetPOItems"
      If m_po.Group Then
        sproc = "GetPOItemsGroup"
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , sproc _
      , New SqlParameter("@po_id", Me.m_po.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New POItem(row, "")
        item.Po = m_po
        Me.Add(item)
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        For Each wbsRow As DataRow In ds.Tables(1).Select("poiw_poilinenumber=" & item.LineNumber)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdColl.Add(wbsd)

          '--Budget Remain =========================================================
          Dim budgetRow() As DataRow = ds.Tables(2).Select("wbs_id=" & wbsd.WBS.Id)
          If budgetRow.Length > 0 Then
            Dim drh As New DataRowHelper(budgetRow(0))
            If wbsd.IsMarkup Then
              wbsd.BudgetRemain = drh.GetValue(Of Decimal)("totalactual")
            Else
              Select Case item.ItemType.Value
                Case 88, 289, 291
                  wbsd.BudgetRemain = drh.GetValue(Of Decimal)("labactual")
                Case 89
                  wbsd.BudgetRemain = drh.GetValue(Of Decimal)("eqactual")
                Case Else
                  wbsd.BudgetRemain = drh.GetValue(Of Decimal)("matactual")
              End Select
              'Trace.WriteLine(wbsd.WBS.Code & ":" & Configuration.FormatToString(wbsd.BudgetRemain, 2))
            End If
          End If

          '--Qty Budget Remain =====================================================
          Dim qtyRow() As DataRow = ds.Tables(3).Select("boqi_wbs=" & wbsd.WBS.Id)
          If qtyRow.Length > 0 Then
            Dim qtydrh As New DataRowHelper(qtyRow(0))
            If wbsd.IsMarkup Then
              wbsd.QtyRemain = 0
            Else
              If item.ItemType.Value = 88 OrElse item.ItemType.Value = 89 Then
                wbsd.QtyRemain = 0
              Else
                wbsd.QtyRemain = qtydrh.GetValue(Of Decimal)("qtybudgetremain")
              End If
            End If
          End If

        Next
      Next
    End Sub
    Public Sub RefreshBudget()
      If Not Me.m_po Is Nothing Then
        Me.m_po.RefreshTaxBase()
      End If
      For Each item As POItem In Me
        Dim bfTax As Decimal = 0
        If Not item.Po Is Nothing Then 'AndAlso item.Po.Originated
          If item.Po.Closed Then
            bfTax = item.ReceivedBeforeTax
          Else
            bfTax = item.BeforeTax
          End If
        End If
        Dim transferAmt As Decimal = bfTax
        For Each wbsd As WBSDistribute In item.WBSDistributeCollection
          wbsd.BaseCost = bfTax
          'wbsd.TransferBaseCost = transferAmt
          If Not wbsd.IsMarkup Then
            Dim actual As Decimal = 0
            Dim budget As Decimal = 0
            Dim budgetQty As Decimal = 0
            Dim actualQty As Decimal = 0

            Dim theName As String = item.EntityName
            If theName Is Nothing Then
              theName = item.Entity.Name
            End If
            Select Case item.ItemType.Value
              Case 0 'อื่นๆ
                actual = wbsd.WBS.GetActualMat(item.Po, 6)
                budget = wbsd.WBS.GetTotalMatFromDB

                budgetQty = wbsd.WBS.GetBudgetQtyForType0FromDB(theName)
                actualQty = wbsd.WBS.GetActualType0Qty(item.Po, 6)
              Case 19 'Tool
                actual = wbsd.WBS.GetActualMat(item.Po, 6)
                budget = wbsd.WBS.GetTotalMatFromDB

                budgetQty = 0 'ไม่มี budget ให้เครื่องมือแน่ๆ
                actualQty = wbsd.WBS.GetActualMatQty(item.Po, 6, item.Entity.Id, 19)
              Case 42 'Mat
                actual = wbsd.WBS.GetActualMat(item.Po, 6)
                budget = wbsd.WBS.GetTotalMatFromDB

                budgetQty = wbsd.WBS.GetTotalMatQtyFromDB(item.Entity.Id)
                actualQty = wbsd.WBS.GetActualMatQty(item.Po, 6, item.Entity.Id, 42)
              Case 88 'Lab
                actual = wbsd.WBS.GetActualLab(item.Po, 6)
                budget = wbsd.WBS.GetTotalLabFromDB

                budgetQty = wbsd.WBS.GetTotalLabQtyFromDB(theName)
                actualQty = wbsd.WBS.GetActualLabQty(item.Po, 6)
              Case 89 'Eq
                actual = wbsd.WBS.GetActualEq(item.Po, 6)
                budget = wbsd.WBS.GetTotalEQFromDB

                budgetQty = wbsd.WBS.GetTotalEQQtyFromDB(theName)
                actualQty = wbsd.WBS.GetActualEqQty(item.Po, 6)
            End Select

            Dim theHash As Hashtable
            Select Case item.ItemType.Value
              Case 0, 19, 42
                theHash = item.Po.MatActualHash
              Case 88
                theHash = item.Po.LabActualHash
              Case 89
                theHash = item.Po.EQActualHash
            End Select
            If Not theHash Is Nothing Then
              Dim o_n As OldNew
              If Not theHash.Contains(wbsd.WBS.Id) Then
                o_n = New OldNew
                o_n.OldValue = actual
                o_n.NewValue = actual
                theHash(wbsd.WBS.Id) = o_n
              Else
                o_n = CType(theHash(wbsd.WBS.Id), OldNew)
                o_n.OldValue += actual
                o_n.NewValue += actual
              End If
            End If
            'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
            Dim budgetRemain As Decimal = budget - actual
            If budgetRemain < 0 Then
              wbsd.AmountOverBudget = True
            Else
              wbsd.AmountOverBudget = False
            End If
            wbsd.BudgetAmount = budget
            wbsd.BudgetRemain = budgetRemain

            'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
            Dim qtyRemain As Decimal = budgetQty - actualQty
            If qtyRemain < 0 AndAlso Not wbsd.WBS.NoQtyControl Then
              wbsd.QtyOverBudget = True
            Else
              wbsd.QtyOverBudget = False
            End If
            wbsd.BudgetQty = budgetQty
            wbsd.QtyRemain = qtyRemain
          Else
            Dim mk As New Markup(wbsd.WBS.Id)
            If Not mk Is Nothing Then
              wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.Po, 6) - item.Po.GetCurrentAmountForMarkup(mk)
              'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
            End If
          End If
        Next
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As POItem
      Get
        Return CType(MyBase.List.Item(index), POItem)
      End Get
      Set(ByVal value As POItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim amt As Decimal = 0        For Each item As POItem In Me
          amt += Configuration.Format(item.Amount, DigitConfig.Price)
        Next
        Return amt
      End Get
    End Property
    Public ReadOnly Property PRHASH() As Hashtable
      Get
        Return m_prHash
      End Get
    End Property
    Public Property CurrentItem() As POItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As POItem)
        m_currentItem = Value
      End Set
    End Property
#End Region

#Region "Class Methods"
		Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
			Dim arr As New ArrayList
			For i As Integer = 0 To items.Count - 1
				If Not TypeOf items(i) Is StockBasketItem Then
					'-----------------LCI Items--------------------
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
						Dim doc As New POItem
						If Not Me.CurrentItem Is Nothing Then
							doc = Me.CurrentItem
							doc.ItemType.Value = newType
							Me.CurrentItem = Nothing
						Else
							Me.Add(doc)
							doc.ItemType = New ItemType(newType)
						End If
						doc.SetItemPrice(item.Code)
						'doc.Entity = newItem   'Lock LCI
						doc.SetItemCode(newItem.Code)
					End If
				ElseIf TypeOf items(i).Tag Is BoqItem Then
					'-----------------BOQ Items--------------------
					Dim bitem As BoqItem = CType(items(i).Tag, BoqItem)
					If bitem.ItemType.Value = 18 Then			'ค่าแรง
            bitem.ItemType.Value = 88
            bitem.Entity.Id = 0
					End If
					If bitem.ItemType.Value = 20 Then			'ค่าเครื่องจักร
            bitem.ItemType.Value = 89
            bitem.Entity.Id = 0
					End If

					Dim matWbsd As New WBSDistribute
					Dim labWbsd As New WBSDistribute
					Dim eqWbsd As New WBSDistribute

					Dim matDoc As POItem
					Dim labDoc As POItem
					Dim eqDoc As POItem
					Dim itemType As Integer
					itemType = bitem.ItemType.Value
					Select Case bitem.ItemType.Value
						Case 19, 42, 0
							Dim itemEntityLevel As Integer = 5
							If bitem.ItemType.Value = 42 Then
								If TypeOf bitem.Entity Is LCIItem Then
									itemEntityLevel = CType(bitem.Entity, LCIItem).Level
								End If
							End If
							If itemEntityLevel = 5 Then
								If bitem.UMC <> 0 Then
									matDoc = New POItem
									If Me.Count = 0 Then
										Me.Add(matDoc)
									Else
										If Not Me.CurrentItem Is Nothing Then
											matDoc = Me.CurrentItem
										Else
											Me.Add(matDoc)
										End If
									End If
									matDoc.ItemType = New itemType(bitem.ItemType.Value)
									If bitem.ItemType.Value = 0 Then
										matDoc.EntityName = bitem.EntityName
									Else
										matDoc.Entity = bitem.Entity
									End If
									matDoc.Unit = bitem.Unit
									matDoc.Qty = bitem.Qty
									matDoc.UnitPrice = bitem.UMC

									If Not bitem.WBS Is Nothing Then
                    matWbsd.IsMarkup = False
                    matWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
                    'matWbsd.CostCenter = Me.m_po.CostCenter
										matWbsd.WBS = bitem.WBS
										matWbsd.Percent = 100
										matWbsd.BaseCost = bitem.TotalMaterialCost
                    'matWbsd.TransferBaseCost = bitem.TotalMaterialCost
										matWbsd.IsOutWard = False
										matWbsd.Toaccttype = 3
									End If
								End If
								If bitem.ULC <> 0 Then						 '88
									labDoc = New POItem
									If Me.Count = 0 Then
										Me.Add(labDoc)
									Else
										If Not Me.CurrentItem Is Nothing Then
											labDoc = Me.CurrentItem
										Else
											Me.Add(labDoc)
										End If
									End If
									labDoc.ItemType = New itemType(88)
									If itemType = 42 Then
										labDoc.Entity = bitem.Entity
										labDoc.EntityName = bitem.Entity.Name
									Else
										labDoc.EntityName = bitem.Entity.Name
									End If
									labDoc.Unit = bitem.Unit
									labDoc.Qty = bitem.Qty
									labDoc.UnitPrice = bitem.ULC
									If Not bitem.WBS Is Nothing Then
										labWbsd.IsMarkup = False
                    labWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
										labWbsd.WBS = bitem.WBS
										labWbsd.Percent = 100
										labWbsd.BaseCost = bitem.TotalLaborCost
                    'labWbsd.TransferBaseCost = bitem.TotalLaborCost
										labWbsd.IsOutWard = False
										labWbsd.Toaccttype = 3
									End If
								End If
								If bitem.UEC <> 0 Then						 '89
									eqDoc = New POItem
									If Me.Count = 0 Then
										Me.Add(eqDoc)
									Else
										If Not Me.CurrentItem Is Nothing Then
											eqDoc = Me.CurrentItem
										Else
											Me.Add(eqDoc)
										End If
									End If
									eqDoc.ItemType = New itemType(89)
									If itemType = 42 Then
										eqDoc.Entity = bitem.Entity
										eqDoc.EntityName = bitem.Entity.Name
									Else
										eqDoc.EntityName = bitem.Entity.Name
									End If
									eqDoc.Unit = bitem.Unit
									eqDoc.Qty = bitem.Qty
									eqDoc.UnitPrice = bitem.UEC
									If Not bitem.WBS Is Nothing Then
										eqWbsd.IsMarkup = False
                    eqWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
										eqWbsd.WBS = bitem.WBS
										eqWbsd.Percent = 100
										eqWbsd.BaseCost = bitem.TotalEquipmentCost
                    'eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
										eqWbsd.IsOutWard = False
										eqWbsd.Toaccttype = 3
									End If
								End If
							End If
						Case 88, 89
							Dim doc As POItem
							Dim tempUnitPrice As Decimal
							If Me.Count = 0 Then
								If bitem.ItemType.Value = 88 Then
									labDoc = New POItem
									doc = labDoc
									tempUnitPrice = bitem.ULC
								End If
								If bitem.ItemType.Value = 89 Then
									eqDoc = New POItem
									doc = eqDoc
									tempUnitPrice = bitem.UEC
								End If
								Me.Add(doc)
							Else
								If bitem.ItemType.Value = 88 Then
									labDoc = New POItem
									If Not Me.CurrentItem Is Nothing Then
										labDoc = Me.CurrentItem
									Else
										Me.Add(labDoc)
									End If
									doc = labDoc
									tempUnitPrice = bitem.ULC
								End If
								If bitem.ItemType.Value = 89 Then
									eqDoc = New POItem
									If Not Me.CurrentItem Is Nothing Then
										eqDoc = Me.CurrentItem
									Else
										Me.Add(eqDoc)
									End If
									doc = eqDoc
									tempUnitPrice = bitem.UEC
								End If
							End If
							doc.ItemType = New itemType(bitem.ItemType.Value)
							doc.Entity = bitem.Entity
							doc.EntityName = bitem.Entity.Name
							doc.Unit = bitem.Unit
							doc.Qty = bitem.Qty
							doc.UnitPrice = tempUnitPrice
							If bitem.ItemType.Value = 88 Then
								If Not bitem.WBS Is Nothing Then
									labWbsd.IsMarkup = False
                  labWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
									labWbsd.WBS = bitem.WBS
									labWbsd.Percent = 100
									labWbsd.BaseCost = bitem.TotalLaborCost
                  'labWbsd.TransferBaseCost = bitem.TotalLaborCost
									labWbsd.IsOutWard = False
									labWbsd.Toaccttype = 3
								End If
							End If
							If bitem.ItemType.Value = 89 Then
								If Not bitem.WBS Is Nothing Then
									eqWbsd.IsMarkup = False
                  eqWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
									eqWbsd.WBS = bitem.WBS
									eqWbsd.Percent = 100
									eqWbsd.BaseCost = bitem.TotalEquipmentCost
                  'eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
									eqWbsd.IsOutWard = False
									eqWbsd.Toaccttype = 3
								End If
							End If
					End Select
					If matWbsd.Percent = 100 Then
						If Not matDoc Is Nothing Then
							matDoc.WBSDistributeCollection.Add(matWbsd)
							arr.Add(matDoc)
						End If
					End If
					If labWbsd.Percent = 100 Then
						If Not labDoc Is Nothing Then
							labDoc.WBSDistributeCollection.Add(labWbsd)
							arr.Add(labDoc)
						End If
					End If
					If eqWbsd.Percent = 100 Then
						If Not eqDoc Is Nothing Then
							eqDoc.WBSDistributeCollection.Add(eqWbsd)
							arr.Add(eqDoc)
						End If
					End If
				ElseIf TypeOf items(i).Tag Is PRItem Then
					'-----------------PR Items--------------------
					Dim pri As PRItem = CType(items(i).Tag, PRItem)
					Dim poi As New POItem
					poi.CopyFromPRItem(pri)
					Me.Add(poi)
					arr.Add(poi)
					If Not poi.Pritem.Pr.ReceivingDate.Equals(Date.MinValue) AndAlso poi.Pritem.Pr.ReceivingDate < Me.m_po.ReceivingDate Then
						Me.m_po.ReceivingDate = poi.Pritem.Pr.ReceivingDate
					End If
				End If
			Next

			Me.m_po.RefreshTaxBase()
			For Each item As POItem In arr
				Dim bfTax As Decimal = 0
				If Not Me.m_po Is Nothing Then			'AndAlso item.Po.Originated
					If Me.m_po.Closed Then
						bfTax = item.ReceivedBeforeTax
					Else
						bfTax = item.BeforeTax
					End If
				End If
				For Each wbsd As WBSDistribute In item.WBSDistributeCollection
					Me.m_po.SetActual(wbsd.WBS, 0, bfTax * wbsd.Percent / 100, item.ItemType.Value)
					'Me.m_po.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, item.ItemType.Value)
				Next
			Next
			RefreshBudget()
		End Sub
		Public Sub Populate(ByVal dt As TreeTable)
			dt.Clear()
			Dim i As Integer = 0
			For Each poi As POItem In Me
				i += 1
				Dim thePR As PR = Nothing
				If Not poi.Pritem Is Nothing Then
					If Not poi.Pritem.Pr Is Nothing AndAlso poi.Pritem.Pr.Originated Then
						thePR = poi.Pritem.Pr
					End If
				End If
				Dim parRow As TreeRow = FindRow(dt, thePR)
				Dim newRow As TreeRow = parRow.Childs.Add()
				poi.CopyToDataRow(newRow)
				poi.ItemValidateRow(newRow)
				newRow.Tag = poi
			Next
			If i = 0 Then
				Dim parRow As TreeRow = FindRow(dt, Nothing)
			End If
			dt.AcceptChanges()
		End Sub
		Public Shared Function FindRow(ByVal dt As TreeTable, ByVal thePR As PR) As TreeRow
			Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
			Dim noPRText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")
			For Each row As TreeRow In dt.Childs
				If thePR Is Nothing Then
					If row.Tag Is Nothing Then
						If Not row.IsNull("PRItemCode") AndAlso CStr(row("PRItemCode")) = noPRText Then
							Return row
						End If
					End If
				End If
				If TypeOf row.Tag Is PR Then
					If CType(row.Tag, PR) Is thePR Then
						Return row
					End If
				End If
			Next

			'---->ไม่เจอ
			Dim newRow As TreeRow
			Dim desc As String = ""
			If thePR Is Nothing Then
				newRow = dt.Childs.Add
				desc = noPRText
			Else
				Dim noParentRow As TreeRow = FindRow(dt, Nothing)
				newRow = dt.Childs.InsertAt(dt.Childs.IndexOf(noParentRow))
				desc = thePR.Code
				newRow.Tag = thePR
			End If
			newRow("PRItemCode") = desc
			newRow("Button") = "invisible"
			newRow("UnitButton") = "invisible"
			newRow.State = RowExpandState.Expanded
			Return newRow
		End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As POItem) As Integer
      If Not m_po Is Nothing Then
        value.Po = m_po
      End If
      If Not value.Pritem Is Nothing Then
        If Not value.Pritem.Pr Is Nothing AndAlso value.Pritem.Pr.Originated Then
          If Not m_prHash.Contains(value.Pritem.Pr.Id) Then
            m_prHash(value.Pritem.Pr.Id) = New PR(value.Pritem.Pr.Id)
          End If
          value.Pritem.Pr = CType(m_prHash(value.Pritem.Pr.Id), PR)
        End If
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As POItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As POItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As POItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As POItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As POItemEnumerator
      Return New POItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As POItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As POItem)
      If Not m_po Is Nothing Then
        value.Po = m_po
      End If
      If Not value.Pritem Is Nothing Then
        If Not value.Pritem.Pr Is Nothing AndAlso value.Pritem.Pr.Originated Then
          If Not m_prHash.Contains(value.Pritem.Pr.Id) Then
            m_prHash(value.Pritem.Pr.Id) = New PR(value.Pritem.Pr.Id)
          End If
          value.Pritem.Pr = CType(m_prHash(value.Pritem.Pr.Id), PR)
        End If
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As POItem)
      For Each wbsd As WBSDistribute In value.WBSDistributeCollection
        value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      Next
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      For Each wbsd As WBSDistribute In Me(index).WBSDistributeCollection
        Me(index).WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      Next
      MyBase.List.RemoveAt(index)
    End Sub
    Public Sub checkPritemsRemain()
      Dim list As String = ""
      For Each Item As POItem In Me
        If Not Item.Pritem Is Nothing Then
          list &= "," & Item.Pritem.Pr.Id.ToString & ":" & Item.Pritem.LineNumber.ToString
        End If
      Next
      If list.Length > 0 Then
        list = list.Substring(1)
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
       , CommandType.StoredProcedure _
       , "GetPRItemsRemainQty" _
       , New SqlParameter("@priList", list) _
       )
        If ds.Tables(0).Rows.Count > 0 Then
          For Each row As DataRow In ds.Tables(0).Rows
            Dim deh As New DataRowHelper(row)
            Dim prid As Integer = deh.GetValue(Of Integer)("pri_pr")
            Dim prline As Integer = deh.GetValue(Of Integer)("pri_linenumber")
            Dim RemainQty As Decimal = deh.GetValue(Of Decimal)("RemainQty")
            Dim OrderedQty As Decimal = deh.GetValue(Of Decimal)("pri_orderedQty")
            Dim prunitid As Integer = deh.GetValue(Of Integer)("pri_unit")
            For Each Item As POItem In Me
              If Not Item.Pritem Is Nothing Then
                If Item.Pritem.Pr.Id = prid AndAlso Item.Pritem.LineNumber = prline Then
                  If RemainQty > 0 Then
                    If prunitid = Item.Unit.Id Then
                      Item.Qty = RemainQty
                    Else
                      'บังคับเปลี่ยนหน่วย
                      Item.Unit = Unit.GetUnitById(prunitid)
                      Item.Qty = RemainQty
                      'Dim remPoConver As Decimal = Item.Qty / OrderedQty
                      'Item.Qty = remPoConver * RemainQty
                    End If
                    Item.OriginQty = Item.Qty
                  ElseIf Item.ItemType.Value <> 160 AndAlso Item.ItemType.Value <> 162 Then
                    Item.Pritem = Nothing
                  End If
                End If
              End If
            Next

          Next
        End If
      End If
     
    End Sub
#End Region


    Public Class POItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As POItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, POItem)
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
