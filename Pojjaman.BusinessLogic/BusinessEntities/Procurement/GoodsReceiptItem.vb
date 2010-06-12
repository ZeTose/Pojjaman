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
  Public Class GoodsReceiptItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_goodsReceiptId As Integer
    Private m_goodsReceipt As GoodsReceipt
    Private m_lineNumber As Integer

    Private m_poitem As POItem

    Private m_itemType As ItemType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Private m_qty As Decimal
    Private m_unitPrice As Decimal
    Private m_note As String
    Private m_stockQty As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")
    Private m_account As Account
    Private m_conversion As Decimal = 1

    Private m_sequence As Integer

    Private m_WBSDistributeCollection As WBSDistributeCollection

    Private m_assetString As String

    Private m_quality As String

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
    Public Sub New(ByVal stockid As Integer, ByVal line As Integer)

      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetGoodsReceiptItems" _
      , New SqlParameter("@stock_id", stockid) _
      , New SqlParameter("@stocki_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
      m_WBSDistributeCollection = New WBSDistributeCollection
      For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & Me.Sequence)
        Dim wbsd As New WBSDistribute(wbsRow, "")
        m_WBSDistributeCollection.Add(wbsd)
      Next
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "poi_entityType") AndAlso Not dr.IsNull("poi_entityType") Then
          Me.m_poitem = New POItem(dr, aliasPrefix)
          Dim myPO As New PO

          If dr.Table.Columns.Contains(aliasPrefix & "poi_po") AndAlso Not dr.IsNull(aliasPrefix & "poi_po") Then
            myPO.Id = CInt(dr(aliasPrefix & "poi_po"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "po_code") AndAlso Not dr.IsNull(aliasPrefix & "po_code") Then
            myPO.Code = CStr(dr(aliasPrefix & "po_code"))
          End If

          Me.m_poitem.Po = myPO
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
          Case 42
            If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              .m_entity = LCIItem.GetLciItemById(itemId)
              '  If Not dr.IsNull("lci_id") Then
              '    .m_entity = New LCIItem(dr, "")
              '  End If
              'Else
              '  .m_entity = New LCIItem(itemId)
            End If
          Case 19
            If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("tool_id") Then
                .m_entity = New Tool(dr, "")
              End If
            Else
              .m_entity = New Tool(itemId)
            End If
          Case 88, 89
            If itemId > 0 Then
              .m_entity = LCIItem.GetLciItemById(itemId)
              'If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              '  If Not dr.IsNull("lci_id") Then
              '    .m_entity = New LCIItem(dr, "")
              '  End If
              'Else
              '  .m_entity = New LCIItem(itemId)
              'End If
            Else
              .m_entity = New BlankItem(.m_entityName)
            End If
          Case Else     '0, 28, 88, 89, 160, 162
            .m_entity = New BlankItem(.m_entityName)
        End Select

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_stock") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stock") Then
          m_goodsReceiptId = CInt(dr(aliasPrefix & "stocki_stock"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "stocki_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "stocki_unitprice"))
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
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "stock.unit_id") AndAlso Not dr.IsNull(aliasPrefix & "stock.unit_id") Then
          .m_unit = New Unit(dr, "stock.")
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & "stocki_unit")))
          End If
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            'Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              Me.Conversion = CType(Me.Entity, LCIItem).GetConversion(Me.Unit)
              'Me.Conversion = lci.GetConversion(Me.Unit)
            Catch ex As NoConversionException
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              msgServ.ShowErrorFormatted("วัสดุ {0} ไม่มีหน่วยนับ {1} ระบุไว้", New String() {ex.Lci.Code, ex.Unit.Name})
            End Try
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

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_asset") AndAlso Not dr.IsNull(aliasPrefix & "stocki_asset") Then
          m_assetString = CStr(dr(aliasPrefix & "stocki_asset"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_quality") AndAlso Not dr.IsNull(aliasPrefix & "stocki_quality") Then
          m_quality = CStr(dr(aliasPrefix & "stocki_quality"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property WBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection
      Get
        Return m_WBSDistributeCollection
      End Get
      Set(ByVal Value As WBSDistributeCollection)
        m_WBSDistributeCollection = Value
      End Set
    End Property
    Public ReadOnly Property Sequence() As Integer
      Get
        Return m_sequence
      End Get
    End Property
    Public Property AssetString() As String
      Get
        Return m_assetString
      End Get
      Set(ByVal Value As String)
        m_assetString = Value
      End Set
    End Property
    Public Property Quality() As String
      Get
        Return m_quality
      End Get
      Set(ByVal Value As String)
        m_quality = Value
      End Set
    End Property
    Public ReadOnly Property GoodsReceiptId() As Integer
      Get
        Return m_goodsReceiptId
      End Get
    End Property
    Public Property GoodsReceipt() As GoodsReceipt
      Get
        Return m_goodsReceipt
      End Get
      Set(ByVal Value As GoodsReceipt)
        m_goodsReceipt = Value
        If Value Is Nothing Then
          m_goodsReceiptId = 0
          Return
        End If
        m_goodsReceiptId = Value.Id
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

    Public Property POitem() As POItem
      Get
        Return m_poitem
      End Get
      Set(ByVal Value As POItem)
        m_poitem = Value
      End Set
    End Property
    Public Property ItemType() As ItemType
      Get
        Return m_itemType
      End Get
      Set(ByVal Value As ItemType)
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
        If msgServ.AskQuestion("${res:Global.Question.ChangeGoodsReceiptEntityType}") Then
          Dim oldType As Integer = m_itemType.Value
          m_itemType = Value
          For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
            Dim transferAmt As Decimal = Me.BeforeTax
            wbsd.BaseCost = transferAmt
            wbsd.TransferBaseCost = transferAmt
            Select Case Me.ItemType.Value
              Case 0, 19, 42
                wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
              Case 88
                wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
              Case 89
                wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
            End Select
            Me.m_goodsReceipt.SetActual(wbsd.WBS, wbsd.TransferAmount, 0, oldType)
            Me.m_goodsReceipt.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, m_itemType.Value)
          Next
          'Me.Clear()
        End If
      End Set
    End Property
    Public Property Entity() As IHasName
      Get
        Return m_entity
      End Get
      Set(ByVal Value As IHasName)
        m_entity = Value
        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If
      End Set
    End Property
    Public Function DupCode(ByVal myCode As String) As Boolean
      If Me.GoodsReceipt Is Nothing Then
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
      For Each item As GoodsReceiptItem In Me.GoodsReceipt.ItemCollection
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
                , New SqlParameter("@stock_entity", GoodsReceipt.ValidIdOrDBNull(GoodsReceipt.Supplier)) _
                , New SqlParameter("@stocki_entity", myTool.Id) _
                , New SqlParameter("@stocki_entitytype", myTool.EntityId) _
                , New SqlParameter("@stock_type", GoodsReceipt.EntityId) _
                )
              Case 2
                unitPrice = GetAmountFromSproc("GetGRPriceForSupplier" _
                , New SqlParameter("@stock_entity", DBNull.Value) _
                , New SqlParameter("@stocki_entity", myTool.Id) _
                , New SqlParameter("@stocki_entitytype", myTool.EntityId) _
                , New SqlParameter("@stock_type", GoodsReceipt.EntityId) _
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
                , New SqlParameter("@stock_entity", GoodsReceipt.ValidIdOrDBNull(GoodsReceipt.Supplier)) _
                , New SqlParameter("@stocki_entity", lci.Id) _
                , New SqlParameter("@stocki_entitytype", lci.EntityId) _
                , New SqlParameter("@stock_type", GoodsReceipt.EntityId) _
                )
              Case 2
                unitPrice = GetAmountFromSproc("GetGRPriceForSupplier" _
                , New SqlParameter("@stock_entity", DBNull.Value) _
                , New SqlParameter("@stocki_entity", lci.Id) _
                , New SqlParameter("@stocki_entitytype", lci.EntityId) _
                , New SqlParameter("@stock_type", GoodsReceipt.EntityId) _
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
    End Sub
    Public Property EntityName() As String
      Get
        Return m_entityName
      End Get
      Set(ByVal Value As String)
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
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        End If
      End Set
    End Property
    Private Sub UpdateWBS()
      If Not Me.GoodsReceipt Is Nothing Then
        Me.GoodsReceipt.RefreshTaxBase()
        For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
          Dim oldVal As Decimal = wbsd.TransferAmount
          Dim transferAmt As Decimal = Me.BeforeTax
          wbsd.BaseCost = transferAmt
          wbsd.TransferBaseCost = transferAmt
          Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
        Next
      End If
    End Sub
    Public Property Qty() As Decimal
      Get
        Return m_qty
      End Get
      Set(ByVal Value As Decimal)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
          'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
          Return
        End If
        m_qty = Configuration.Format(Value, DigitConfig.Qty)

        UpdateWBS()
      End Set
    End Property
    Public Property UnitPrice() As Decimal
      Get
        Return m_unitPrice
      End Get
      Set(ByVal Value As Decimal)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        End Select
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
    Public Sub SetAccountCode(ByVal theCode As String)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Me.GoodsReceipt.OnGlChanged()
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
          Case 160, 162, 0 'Note,อื่นๆ
            Me.m_account = New Account
            Return
          Case 28 'สินทรัพย์
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.GeneralAsset)
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
              Return
            End If
            Me.m_account = New Account
            Return
          Case 88 'ค่าแรง
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.SalaryWage)
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
              Return
            End If
            Me.m_account = New Account
            Return
          Case 89 'ค่าเช่าเครื่องจักร
            Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherExpense)
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
              Return
            End If
            Me.m_account = New Account
            Return
          Case 19 'Tool
            If Not Me.Entity Is Nothing AndAlso Me.Entity.Id <> 0 Then
              Dim myTool As Tool = CType(Me.Entity, Tool)
              Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOther)
              If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
                Me.m_account = ga.Account
                Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
                Return
              End If
              Me.m_account = New Account
            End If
          Case 42 'LCI
            If Not Me.Entity Is Nothing AndAlso Me.Entity.Id <> 0 Then
              Dim lci As LCIItem = CType(Me.Entity, LCIItem)
              If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                Me.m_account = lci.Account
                Me.m_account.Name = lci.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
                Return
              End If
              Me.m_account = New Account
            End If
          Case Else
            Me.m_account = acct
            Return
        End Select
      End If
    End Sub
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
        Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)
      End Get
    End Property
    Public Property Discount() As Discount
      Get
        Dim amtFormatted As Decimal = Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
        m_discount.AmountBeforeDiscount = amtFormatted
        Return m_discount
      End Get
      Set(ByVal Value As Discount)
        m_discount = Value
      End Set
    End Property
    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Public ReadOnly Property Amount() As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Dim amtFormatted As Decimal = Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
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
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        If Me.GoodsReceipt Is Nothing Then
          Return 0
        End If
        Return (Me.GoodsReceipt.TaxRate * Me.TaxBase) / 100
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        If Me.GoodsReceipt Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsReceipt.Gross
        Dim myDiscount As Decimal = Me.GoodsReceipt.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.GoodsReceipt.TaxType.Value
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
        If Me.GoodsReceipt Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsReceipt.Gross
        Dim myDiscount As Decimal = Me.GoodsReceipt.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.GoodsReceipt.TaxType.Value
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
        If Me.GoodsReceipt Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsReceipt.Gross
        Dim myDiscount As Decimal = Me.GoodsReceipt.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Return (Me.AmountWithoutFormat / myGross) * myDiscount
      End Get
    End Property
    Public ReadOnly Property TaxBase() As Decimal
      Get
        If Me.GoodsReceipt Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsReceipt.Gross
        Dim myDiscount As Decimal = Me.GoodsReceipt.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.GoodsReceipt.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            If Not Me.UnVatable Then
              Return (Me.AmountWithoutFormat - ((Me.AmountWithoutFormat / myGross) * myDiscount))
            End If
          Case 2 '"รวม"
            If Not Me.UnVatable Then
              'Return Vat.GetExcludedVatAmountWithoutRound(Me.Amount, Me.GoodsReceipt.TaxRate)
              Return Vat.GetExcludedVatAmountWithoutRound(Me.AmountWithoutFormat - ((Me.AmountWithoutFormat / myGross) * myDiscount), Me.GoodsReceipt.TaxRate)
            End If
        End Select
      End Get
    End Property
    Public ReadOnly Property CostTaxBase() As Decimal
      Get
        If Me.GoodsReceipt Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsReceipt.Gross
        Dim myDiscount As Decimal = Me.GoodsReceipt.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.GoodsReceipt.TaxType.Value
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
              Return (Me.Cost - ((Me.Cost / myGross) * myDiscount)) * (100 / (Me.GoodsReceipt.TaxRate + 100))
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
    Public ReadOnly Property UnitCost() As Decimal
      Get
        Dim tmpCost As Decimal = 0
        Dim tmpRealGrossNoVat As Decimal = 0
        tmpRealGrossNoVat = Me.GoodsReceipt.RealGross

        If Me.StockQty = 0 OrElse tmpRealGrossNoVat = 0 Then
          Return 0
        Else
          tmpCost = Me.Amount 'Me.AmountWithDefaultUnit

          tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.GoodsReceipt.Discount.Amount)

          If Me.GoodsReceipt.TaxType.Value = 2 Then
            If Not Me.UnVatable Then
              tmpCost = tmpCost * (100 / (100 + Me.GoodsReceipt.TaxRate))
            End If
          End If

          tmpCost = tmpCost / Me.StockQty

          Return tmpCost
        End If
        Return 0
      End Get
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
    Public Sub Clear()
      Me.m_poitem = Nothing
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
    Public Sub CreateFromGross(ByVal parGross As Decimal)
      Me.ItemType = New ItemType(0)
      Me.Entity = New BlankItem("NOITEM")
      Me.UnitPrice = parGross
      Me.Qty = 1
    End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim unit As Object = row("unit")
      Dim code As Object = row("Code")
      Dim stocki_itemName As Object = row("stocki_itemName")
      Dim stocki_qty As Object = row("stocki_qty")
      Dim stocki_unitprice As Object = row("stocki_unitprice")
      Dim stocki_entitytype As Object = row("stocki_entitytype")

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
          Case 0, 88, 89         'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(stocki_itemName) OrElse stocki_itemName.ToString.Length = 0 Then
              row.SetColumnError("stocki_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("stocki_itemName", "")
            End If
            If Not IsNumeric(stocki_qty) Then         'OrElse CDec(stocki_qty) <= 0 Then
              row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("stocki_qty", "")
            End If
            'If Not IsNumeric(stocki_unitprice) Then 'OrElse CDec(stocki_unitprice) <= 0 Then
            '    row.SetColumnError("stocki_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("stocki_unitprice", "")
            'End If
            row.SetColumnError("stocki_unitprice", "")
            row.SetColumnError("code", "")
          Case 19       'เครื่องมือ
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
            If Not IsNumeric(stocki_qty) Then         'OrElse CDec(stocki_qty) <= 0 Then
              row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("stocki_qty", "")
            End If
            'If Not IsNumeric(stocki_unitprice) Then 'OrElse CDec(stocki_unitprice) <= 0 Then
            '    row.SetColumnError("stocki_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("stocki_unitprice", "")
            'End If
            row.SetColumnError("stocki_unitprice", "")
          Case 28       'F/A
            If IsDBNull(stocki_itemName) OrElse stocki_itemName.ToString.Length = 0 Then
              row.SetColumnError("stocki_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("stocki_itemName", "")
            End If
            If Not IsNumeric(stocki_qty) Then         'OrElse CDec(stocki_qty) <= 0 Then
              row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("stocki_qty", "")
            End If
            'If Not IsNumeric(stocki_unitprice) Then 'OrElse CDec(stocki_unitprice) <= 0 Then
            '    row.SetColumnError("stocki_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("stocki_unitprice", "")
            'End If
            row.SetColumnError("stocki_unitprice", "")
            row.SetColumnError("code", "")
          Case 42        'LCI
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
            If Not IsNumeric(stocki_qty) Then          'OrElse CDec(stocki_qty) <= 0 Then
              row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("stocki_qty", "")
            End If
            'If Not IsNumeric(stocki_unitprice) Then ' OrElse CDec(stocki_unitprice) <= 0 Then
            '    row.SetColumnError("stocki_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("stocki_unitprice", "")
            'End If
            row.SetColumnError("stocki_unitprice", "")
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Sub CopyFromPOItem(ByVal poitem As POItem)
      Me.m_poitem = poitem
      Me.m_itemType = poitem.ItemType
      Dim m_isCommentType As Boolean = False
      Select Case Me.ItemType.Value
        Case 42
          If TypeOf poitem.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(poitem.Entity, LCIItem)
            Me.m_account = lci.Account
          End If
        Case 19 'เครื่องมือ
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOther)
          Me.m_account = ga.Account
        Case 28 'Asset
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.GeneralAsset)
          Me.m_account = ga.Account
        Case 88 'ค่าแรง
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.SalaryWage)
          Me.m_account = ga.Account
        Case 0, 89
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherExpense)
          Me.m_account = ga.Account
        Case 160, 162
          m_isCommentType = True
      End Select
      Me.m_entity = poitem.Entity
      Me.m_entityName = poitem.EntityName
      If m_isCommentType Then
        Me.m_unit = New Unit
        Me.m_discount = New Discount("")
      Else
        Me.m_unit = poitem.Unit
        Me.m_discount = poitem.Discount
        Me.m_unitPrice = poitem.UnitPrice
        Me.m_unvatable = poitem.UnVatable
        If poitem.ReceivedQty <> Decimal.MinValue Then
          If Me.Conversion <> 0 Then
            Me.Qty = ((poitem.Qty - poitem.ReceivedQty))
          End If
        Else
          Me.Qty = poitem.Qty  '(poitem.Qty * poitem.Conversion) / Me.Conversion
        End If
        If Not poitem.WBSDistributeCollection Is Nothing Then
          Me.WBSDistributeCollection = poitem.WBSDistributeCollection.Clone(Me)

          'เพิ่มตรงนี้มา --> เพราะของเดิมแก้ % , wbs แล้วค่าคงเหลือไม่เปลี่ยน
          AddHandler Me.WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler

        End If
      End If
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Try
        Me.GoodsReceipt.IsInitialized = False


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
            Case 0, 28
              row("Button") = "invisible"
              row("stocki_itemName") = Me.EntityName
            Case 88, 89
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

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          'Me.Conversion = 1
          If TypeOf Me.Entity Is LCIItem Then
            If Not Me.POitem Is Nothing Then
              Dim lci As LCIItem = CType(Me.Entity, LCIItem)
              If Me.POitem.Unit.Id <> Me.Unit.Id Then
                Me.Conversion = lci.GetConversion(Me.Unit)
              End If
              If lci.DefaultUnit.Id <> Me.Unit.Id Then
                Me.Conversion = lci.GetConversion(Me.Unit)
              End If
            Else
              Dim lci As LCIItem = CType(Me.Entity, LCIItem)
              If lci.DefaultUnit.Id <> Me.Unit.Id Then
                Me.Conversion = lci.GetConversion(Me.Unit)
              End If
            End If
          Else
            Me.Conversion = 1
          End If
        End If

        '##########################################################################################
        If Not Me.POitem Is Nothing Then
          row("poi_linenumber") = Me.POitem.LineNumber
          If Not Me.POitem.Entity Is Nothing Then
            row("poi_entity") = Me.POitem.Entity.Id
            If Not Me.POitem.ItemType Is Nothing Then
              row("poi_entityType") = Me.POitem.ItemType.Value
            End If
            row("POItemCode") = Me.POitem.Entity.Code
            row("POItemName") = Me.POitem.Entity.Name
          End If

          If Not Me.POitem.Unit Is Nothing Then
            row("POItemUnit") = Me.POitem.Unit.Name
          End If
          row("poi_qty") = Me.POitem.Qty
          Dim receiveQty As Decimal = 0
          'If Me.POitem.ReceivedQty <> Decimal.MinValue Then
          'receiveQty = Me.POitem.ReceivedQty ' หน่วยตาม PO
          receiveQty = (Me.Qty * Me.Conversion) / POitem.Conversion
          'End If
          If POitem.Conversion <> 0 Then
            If Me.Conversion <> 0 Then
              row("poi_receivedqty") = POitem.ReceivedQty '+ receiveQty
              Select Case Me.POitem.ItemType.Value
                Case 160, 162
                Case Else
                  row("POItemRemainingQty") = Configuration.FormatToString((((Me.POitem.Qty - POitem.ReceivedQty) - receiveQty) * POitem.Conversion) / Me.Conversion, DigitConfig.Qty)
              End Select
            End If
          End If
          'MessageBox.Show(String.Format("{0}-{1},{2}", Me.POitem.Qty, receiveQty / POitem.Conversion, POitem.Conversion))
          If Not Me.POitem.Po Is Nothing Then
            row("po_code") = Me.POitem.Po.Code
            row("poi_po") = Me.POitem.Po.Id
          End If
        End If
        '##########################################################################################

        If Not Me.Account Is Nothing Then
          row("stocki_acct") = Me.Account.Id
          row("AccountCode") = Me.Account.Code
          row("Account") = Me.Account.Name
        End If

        Dim parent As GoodsReceipt = Me.GoodsReceipt
        If parent Is Nothing Then parent = New GoodsReceipt
        If Me.Qty <> 0 Then 'AndAlso parent.ValidateRow(row) Then
          row("stocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("stocki_qty") = ""
        End If

        If row.Table.Columns.Contains("stock_code") Then
          row("stock_code") = Me.GoodsReceipt.Code
        End If

        row("stocki_discrate") = Me.Discount.Rate
        If Me.Amount <> 0 Then ' AndAlso parent.ValidateRow(row) Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If

        row("stocki_note") = Me.Note
        row("stocki_quality") = Me.Quality
        If Me.UnitPrice <> 0 Then 'AndAlso parent.ValidateRow(row) Then
          row("stocki_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("stocki_unitprice") = ""
        End If
        If Me.StockQty <> 0 Then 'AndAlso parent.ValidateRow(row) Then
          row("StockQty") = Configuration.FormatToString(Me.StockQty, DigitConfig.Qty) 'Me.StockQty
        Else
          row("StockQty") = ""
        End If
        row("stocki_unvatable") = Me.UnVatable
        row("AssetString") = Me.AssetString
        Me.GoodsReceipt.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
#End Region

#Region "Shared"
    Public Shared Function GetListDatatable(ByVal ParamArray filters() As Filter) As TreeTable

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim dt As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetGoodsReceiptItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("GoodsReceiptItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stock_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DueDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDueDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("ToCostcenter", GetType(String)))

      For Each tableRow As DataRow In dt.Rows
        Dim gri As New GoodsReceiptItem(tableRow, "")
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("stock_code")
        row("stock_id") = tableRow("stocki_stock")
        row("Linenumber") = tableRow("stocki_linenumber")
        row("Date") = tableRow("stock_docdate")
        row("DueDate") = tableRow("stock_docdate")

        Dim entityInfo As String = ""
        If gri.ItemType.Value = 0 Then
          entityInfo = gri.Entity.Name
        Else
          entityInfo = gri.Entity.Code & ":" & gri.Entity.Name
        End If
        row("Entity") = entityInfo
        row("Qty") = gri.Qty
        row("ToCostcenter") = tableRow("toccinfo")
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
#End Region

    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'If TypeOf sender Is WBSDistribute Then
      '  Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
      '  Select Case e.Name.ToLower
      '    Case "percent"
      '      If Not Me.m_goodsReceipt Is Nothing Then
      '        Me.m_goodsReceipt.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
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
      '      Me.m_goodsReceipt.SetActual(oldWBS, wbsd.TransferAmount, 0, Me.ItemType.Value)
      '      Me.m_goodsReceipt.SetActual(newWBS, 0, wbsd.TransferAmount, Me.ItemType.Value)
      '  End Select
      'End If
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            If Not Me.m_goodsReceipt Is Nothing Then

              'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "amount"
            If Not Me.m_goodsReceipt Is Nothing Then

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
            wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.GoodsReceipt.Id, Me.GoodsReceipt.EntityId, Me.ItemType.Value)
            wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.GoodsReceipt.Id, Me.GoodsReceipt.EntityId, Me.Entity.Id, _
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
        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, Me.ItemType.Value)
        If boqConversion = 0 Then
          wbsd.BaseQty = Me.Qty
        Else
          wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
        End If

        'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
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
  Public Class GoodsReceiptItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_goodsReceipt As GoodsReceipt
    Private m_poHash As Hashtable
    Private m_currentItem As GoodsReceiptItem
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As GoodsReceipt)
      Me.m_goodsReceipt = owner
      m_poHash = New Hashtable
      If Not Me.m_goodsReceipt.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetGoodsReceiptItems" _
      , New SqlParameter("@stock_id", Me.m_goodsReceipt.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New GoodsReceiptItem(row, "")
        item.GoodsReceipt = m_goodsReceipt
        Me.Add(item)
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & item.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdColl.Add(wbsd)
        Next
      Next
    End Sub
    Public Sub RefreshBudget()
      For Each item As GoodsReceiptItem In Me
        For Each wbsd As WBSDistribute In item.WBSDistributeCollection
          Dim transferAmt As Decimal = item.Cost
          wbsd.BaseCost = transferAmt
          wbsd.TransferBaseCost = transferAmt
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
                actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, 45)
                budget = wbsd.WBS.GetTotalMatFromDB

                budgetQty = wbsd.WBS.GetBudgetQtyForType0FromDB(theName)
                actualQty = wbsd.WBS.GetActualType0Qty(item.GoodsReceipt, 45)
              Case 19 'Tool
                actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, 45)
                budget = wbsd.WBS.GetTotalMatFromDB

                budgetQty = 0 'ไม่มี budget ให้เครื่องมือแน่ๆ
                actualQty = wbsd.WBS.GetActualMatQty(item.GoodsReceipt, 45, item.Entity.Id, 19)
              Case 42 'Mat
                actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, 45)
                budget = wbsd.WBS.GetTotalMatFromDB

                budgetQty = wbsd.WBS.GetTotalMatQtyFromDB(item.Entity.Id)
                actualQty = wbsd.WBS.GetActualMatQty(item.GoodsReceipt, 45, item.Entity.Id, 42)
              Case 88 'Lab
                actual = wbsd.WBS.GetActualLab(item.GoodsReceipt, 45)
                budget = wbsd.WBS.GetTotalLabFromDB

                budgetQty = wbsd.WBS.GetTotalLabQtyFromDB(theName)
                actualQty = wbsd.WBS.GetActualLabQty(item.GoodsReceipt, 45)
              Case 89 'Eq
                actual = wbsd.WBS.GetActualEq(item.GoodsReceipt, 45)
                budget = wbsd.WBS.GetTotalEQFromDB

                budgetQty = wbsd.WBS.GetTotalEQQtyFromDB(theName)
                actualQty = wbsd.WBS.GetActualEqQty(item.GoodsReceipt, 45)
            End Select

            Dim theHash As Hashtable
            Select Case item.ItemType.Value
              Case 0, 19, 42
                theHash = item.GoodsReceipt.MatActualHash
              Case 88
                theHash = item.GoodsReceipt.LabActualHash
              Case 89
                theHash = item.GoodsReceipt.EQActualHash
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
              wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.GoodsReceipt, 45) - item.GoodsReceipt.GetCurrentAmountForMarkup(mk)
              'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
            End If
          End If
        Next
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property GoodsReceipt() As GoodsReceipt
      Get
        Return m_goodsReceipt
      End Get
      Set(ByVal Value As GoodsReceipt)
        m_goodsReceipt = Value
      End Set
    End Property
    Default Public Property Item(ByVal index As Integer) As GoodsReceiptItem
      Get
        Return CType(MyBase.List.Item(index), GoodsReceiptItem)
      End Get
      Set(ByVal value As GoodsReceiptItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property POHASH() As Hashtable
      Get
        Return m_poHash
      End Get
    End Property
    Public Property CurrentItem() As GoodsReceiptItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As GoodsReceiptItem)
        m_currentItem = Value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each gri As GoodsReceiptItem In Me
        i += 1
        Dim thePO As PO = Nothing
        If Not gri.POitem Is Nothing Then
          If Not gri.POitem.Po Is Nothing AndAlso gri.POitem.Po.Originated Then
            thePO = gri.POitem.Po
          End If
        End If
        Dim parRow As TreeRow = FindRow(dt, thePO)
        Dim newRow As TreeRow = parRow.Childs.Add()
        gri.CopyToDataRow(newRow)
        gri.ItemValidateRow(newRow)
        newRow.Tag = gri
      Next
      If i = 0 Then
        Dim parRow As TreeRow = FindRow(dt, Nothing)
      End If
      dt.AcceptChanges()
    End Sub
    Public Shared Function FindRow(ByVal dt As TreeTable, ByVal thePO As PO) As TreeRow
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noPOText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.BlankPOText}")
      For Each row As TreeRow In dt.Childs
        If thePO Is Nothing Then
          If row.Tag Is Nothing Then
            If Not row.IsNull("Code") AndAlso CStr(row("Code")) = noPOText Then
              Return row
            End If
          End If
        End If
        If TypeOf row.Tag Is PO Then
          If CType(row.Tag, PO) Is thePO Then
            Return row
          End If
        End If
      Next

      '---->ไม่เจอ
      Dim newRow As TreeRow
      Dim desc As String = ""
      If thePO Is Nothing Then
        newRow = dt.Childs.Add
        desc = noPOText
      Else
        Dim noParentRow As TreeRow = FindRow(dt, Nothing)
        newRow = dt.Childs.InsertAt(dt.Childs.IndexOf(noParentRow))
        desc = thePO.Code
        newRow.Tag = thePO
      End If
      newRow("Code") = desc
      newRow("Button") = "invisible"
      newRow("UnitButton") = "invisible"
      newRow("AccountButton") = "invisible"
      newRow.State = RowExpandState.Expanded
      Return newRow
    End Function
    Public Function GetCollectionForPO(ByVal po As PO) As GoodsReceiptItemCollection
      Dim myCollection As New GoodsReceiptItemCollection
      myCollection.GoodsReceipt = Me.GoodsReceipt
      For Each item As GoodsReceiptItem In Me
        If item.POitem.Po Is po Then
          myCollection.Add(item)
        ElseIf po.Id <> 0 And po.Id = item.POitem.Po.Id Then
          myCollection.Add(item)
        End If
      Next
      Return myCollection
    End Function
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
          Dim doc As New GoodsReceiptItem
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
    Public Overridable Function Add(ByVal value As GoodsReceiptItem) As Integer
      If Not m_goodsReceipt Is Nothing Then
        value.GoodsReceipt = m_goodsReceipt
      End If
      If Not value.POitem Is Nothing Then
        If Not value.POitem.Po Is Nothing AndAlso value.POitem.Po.Originated Then
          If Not m_poHash.Contains(value.POitem.Po.Id) Then
            m_poHash(value.POitem.Po.Id) = PO.GetPO(value.POitem.Po.Id, ViewType.GoodsReceiptItem)
            'm_poHash(value.POitem.Po.Id) = New PO(value.POitem.Po.Id)
          End If
          value.POitem.Po = CType(m_poHash(value.POitem.Po.Id), PO)
        End If
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As GoodsReceiptItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As GoodsReceiptItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As GoodsReceiptItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As GoodsReceiptItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As GoodsReceiptItemEnumerator
      Return New GoodsReceiptItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As GoodsReceiptItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As GoodsReceiptItem)
      If Not m_goodsReceipt Is Nothing Then
        value.GoodsReceipt = m_goodsReceipt
      End If
      If Not value.POitem Is Nothing Then
        If Not value.POitem.Po Is Nothing AndAlso value.POitem.Po.Originated Then
          If Not m_poHash.Contains(value.POitem.Po.Id) Then
            m_poHash(value.POitem.Po.Id) = New PO(value.POitem.Po.Id)
          End If
          value.POitem.Po = CType(m_poHash(value.POitem.Po.Id), PO)
        End If
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As GoodsReceiptItem)
      For Each wbsd As WBSDistribute In value.WBSDistributeCollection
        value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      Next
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As GoodsReceiptItemCollection)
      For Each item As GoodsReceiptItem In value
        For Each wbsd As WBSDistribute In item.WBSDistributeCollection
          item.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
        Next
      Next
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class GoodsReceiptItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As GoodsReceiptItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, GoodsReceiptItem)
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

