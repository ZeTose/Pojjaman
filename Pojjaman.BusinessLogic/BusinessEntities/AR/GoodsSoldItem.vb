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
  Public Class GoodsSoldItem

#Region "Members"
    Private m_goodsSoldId As Integer
    Private m_goodsSold As GoodsSold
    Private m_lineNumber As Integer

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

    Private m_WBSDistributeCollection As WBSDistributeCollection
    Private m_itemCollectionPrePareCost As StockCostItemCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_WBSDistributeCollection = New WBSDistributeCollection
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
      , "GetGoodsSoldItems" _
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

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_stock") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stock") Then
          m_goodsSoldId = CInt(dr(aliasPrefix & "stocki_stock"))
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
            Try
              Me.Conversion = lci.GetConversion(Me.Unit)
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

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollectionPrePareCost(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As StockCostItemCollection
      Get
        If m_itemCollectionPrePareCost Is Nothing Then
          If conn Is Nothing AndAlso trans Is Nothing Then
            If Not Me.GoodsSold Is Nothing AndAlso Not Me.GoodsSold.FromCostCenter Is Nothing Then              m_itemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.GoodsSold.FromCostCenter, Me.StockQty)
            End If
          Else
            If Not Me.GoodsSold Is Nothing AndAlso Not Me.GoodsSold.FromCostCenter Is Nothing Then              m_itemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.GoodsSold.FromCostCenter, Me.StockQty)
            End If
          End If
          
        End If
        Return m_itemCollectionPrePareCost
      End Get
      Set(ByVal value As StockCostItemCollection)
        m_itemCollectionPrePareCost = value
        'm_transferAmount = m_itemCollectionPrePareCost.CostAmount
      End Set
    End Property
    Public Property WBSDistributeCollection() As WBSDistributeCollection      Get        Return m_WBSDistributeCollection
      End Get      Set(ByVal Value As WBSDistributeCollection)        m_WBSDistributeCollection = Value
      End Set    End Property
    Public Property Sequence() As Integer      Get        Return m_sequence      End Get      Set(ByVal Value As Integer)        m_sequence = Value      End Set    End Property
    Public ReadOnly Property GoodsSoldId() As Integer
      Get
        Return m_goodsSoldId
      End Get
    End Property
    Public Property GoodsSold() As GoodsSold      Get        Return m_goodsSold      End Get      Set(ByVal Value As GoodsSold)        m_goodsSold = Value
        If Value Is Nothing Then
          m_goodsSoldId = 0
          Return
        End If
        m_goodsSoldId = Value.Id      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property ItemType() As ItemType      Get        Return m_itemType      End Get      Set(ByVal Value As ItemType)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
          m_itemType = Value          Me.Clear()
        End If
        Dim gaType As GeneralAccount.DefaultGAType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
        Select Case Me.ItemType.Value
          Case 0
            gaType = GeneralAccount.DefaultGAType.OtherIncome
          Case 88, 89, 19, 42
            gaType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
        End Select
        Dim ga As GeneralAccount
        If gaType <> GeneralAccount.DefaultGAType.None Then
          ga = GeneralAccount.GetDefaultGA(gaType)
        End If
        If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
          Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
          Me.m_account = ga.Account
          Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
        Else
          Me.m_account = New Account
        End If
      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If
        If Not Me.ItemType Is Nothing Then
          Dim gaType As GeneralAccount.DefaultGAType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
          Select Case Me.ItemType.Value
            Case 0
              gaType = GeneralAccount.DefaultGAType.OtherIncome
            Case 88, 89, 19, 42
              gaType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
          End Select
          Dim ga As GeneralAccount
          If gaType <> GeneralAccount.DefaultGAType.None Then
            ga = GeneralAccount.GetDefaultGA(gaType)
          End If
          If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Me.m_account = ga.Account
            Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
          Else
            Me.m_account = New Account
          End If
        End If

        If Not Me.GoodsSold Is Nothing AndAlso Not Me.GoodsSold.FromCostCenter Is Nothing Then          Me.ItemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.GoodsSold.FromCostCenter, Me.StockQty)
        End If

      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean
      If Me.GoodsSold Is Nothing Then
        Return False
      End If
      If Me.ItemType Is Nothing Then
        Return False
      End If
      'If Me.ItemType.Value = 42 Then
      '    'Material ใส่ Code เดียวกันได้
      '    Return False
      'End If
      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As GoodsSoldItem In Me.GoodsSold.ItemCollection
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
    Public Sub SetItemCode(ByVal theCode As String)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
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

      Dim gaType As GeneralAccount.DefaultGAType = GeneralAccount.DefaultGAType.OtherIncome
      Select Case Me.ItemType.Value
        Case 160, 162 'Note
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveCode}")
          Return
        Case 0 'Blank
          msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
          Return
        Case 88 'Lab
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLaborDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            Return
          End If
          Dim myLab As New Labor(theCode)
          If Not myLab.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoLabor}", New String() {theCode})
            Return
          Else
            Dim myUnit As Unit = myLab.Unit
            Me.m_unit = myUnit
            Me.m_entityName = myLab.Name
            gaType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
          End If
        Case 89 'Eq
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteEqcostDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            Return
          End If
          Dim myEq As New EqCost(theCode)
          If Not myEq.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoEqCost}", New String() {theCode})
            Return
          Else
            Dim myUnit As Unit = myEq.Unit
            Me.m_unit = myUnit
            Me.m_entityName = myEq.Name
            gaType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
          End If
        Case 19 'Tool
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
          Else
            Dim myUnit As Unit = myTool.Unit
            Me.m_unit = myUnit
            Me.m_entity = myTool
            gaType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
          End If
        Case 42 'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            If Me.Entity.Code.Length <> 0 Then
              If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {Me.Entity.Code}) Then
                Me.Clear()
              End If
            End If
            Return
          End If
          Dim lci As New LCIItem(theCode)
          If Not lci.Originated Then
            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {theCode})
            Return
          Else
            Dim myUnit As Unit = lci.DefaultUnit
            Me.m_unit = myUnit
            Me.m_entity = lci
            If Not Me.GoodsSold Is Nothing AndAlso Not Me.GoodsSold.FromCostCenter Is Nothing Then              Dim stockQty As Decimal = Me.m_qty * Me.Conversion              Me.ItemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.GoodsSold.FromCostCenter, stockQty)
            End If
            gaType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
          End If
        Case Else
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
      End Select
      Dim ga As GeneralAccount
      If gaType <> GeneralAccount.DefaultGAType.None Then
        ga = GeneralAccount.GetDefaultGA(gaType)
      End If
      If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
        Me.m_account = ga.Account
        Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
      Else
        Me.m_account = New Account
      End If
      Me.m_qty = 1
    End Sub
    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
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
            Dim gaType As GeneralAccount.DefaultGAType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
            Dim ga As GeneralAccount
            If gaType <> GeneralAccount.DefaultGAType.None Then
              ga = GeneralAccount.GetDefaultGA(gaType)
            End If
            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
            Else
              Me.m_account = New Account
            End If
          Case 0, 88, 89
            Me.m_entityName = Value
            Dim gaType As GeneralAccount.DefaultGAType = GeneralAccount.DefaultGAType.ToolAndOtherIncome
            Dim ga As GeneralAccount
            If gaType <> GeneralAccount.DefaultGAType.None Then
              ga = GeneralAccount.GetDefaultGA(gaType)
            End If
            If (Me.Account Is Nothing OrElse Not Me.Account.Originated) AndAlso Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
              Me.m_account = ga.Account
              Me.m_account.Name = ga.Account.Name & "<" & myStringParserService.Parse("${res:Global.Default}") & ">"
            ElseIf Me.Account Is Nothing OrElse Not Me.Account.Originated Then
              Me.m_account = New Account
            End If
          Case Else '160, 162
            Me.m_entityName = Value
        End Select
      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
          If Me.m_qty <> 0 Then
            Me.m_qty = (oldConversion / newConversion) * Me.m_qty
          End If
          If Me.m_unitPrice <> 0 Then
            Me.m_unitPrice = (newConversion / oldConversion) * Me.m_unitPrice
          End If
          m_unit = Value        Else
          msgServ.ShowMessage(err)
        End If
      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        If Value > 0 AndAlso m_qty <> Value Then          If Not Me.GoodsSold Is Nothing AndAlso Not Me.GoodsSold.FromCostCenter Is Nothing Then            Me.ItemCollectionPrePareCost.Clear()            Dim stockQty As Decimal = Value * Me.Conversion            Me.ItemCollectionPrePareCost = New StockCostItemCollection(m_entity, Me.GoodsSold.FromCostCenter, stockQty)
          End If
        End If

        m_qty = Configuration.Format(Value, DigitConfig.Qty)
      End Set    End Property    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
            m_unitPrice = Configuration.Format(Value, DigitConfig.UnitPrice)
          Case Else
            msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        End Select
      End Set    End Property    Public Property Note() As String
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
      If Me.ItemType Is Nothing Then
        'ไม่มี Type
        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        Return
      End If
      Dim acct As New Account(theCode)
      If acct.IsControlGroup Then
        msgServ.ShowMessage(acct.ControlMessage)
        Return
      End If
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
        Dim amtFormatted As Decimal = Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)        m_discount.AmountBeforeDiscount = amtFormatted
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
    Public ReadOnly Property Amount() As Decimal
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
    Public ReadOnly Property TaxAmount() As Decimal      Get        If Me.GoodsSold Is Nothing Then
          Return 0
        End If        Return (Me.GoodsSold.TaxRate * Me.TaxBase) / 100      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        If Me.GoodsSold Is Nothing Then
          Return 0
        End If        Dim myGross As Decimal = Me.GoodsSold.Gross
        Dim myDiscount As Decimal = Me.GoodsSold.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If        Select Case Me.GoodsSold.TaxType.Value
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
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        If Me.GoodsSold Is Nothing Then
          Return 0
        End If        Dim myGross As Decimal = Me.GoodsSold.Gross
        Dim myDiscount As Decimal = Me.GoodsSold.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If        Select Case Me.GoodsSold.TaxType.Value
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
        If Me.GoodsSold Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsSold.Gross
        Dim myDiscount As Decimal = Me.GoodsSold.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Return (Me.AmountWithoutFormat / myGross) * myDiscount
      End Get
    End Property
    Public ReadOnly Property TaxBase() As Decimal
      Get
        If Me.GoodsSold Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsSold.RealGross
        Dim myDiscount As Decimal = Me.GoodsSold.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.GoodsSold.TaxType.Value
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
              Return Vat.GetExcludedVatAmountWithoutRound(Me.Amount, Me.GoodsSold.TaxRate)
              'Return Vat.GetExcludedVatAmountWithoutRound(Me.AmountWithoutFormat - ((Me.AmountWithoutFormat / myGross) * myDiscount), Me.GoodsSold.TaxRate)
            End If
        End Select
      End Get
    End Property
    Public ReadOnly Property CostTaxBase() As Decimal
      Get
        If Me.GoodsSold Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.GoodsSold.Gross
        Dim myDiscount As Decimal = Me.GoodsSold.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.GoodsSold.TaxType.Value
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
              Return (Me.Cost - ((Me.Cost / myGross) * myDiscount)) * (100 / (Me.GoodsSold.TaxRate + 100))
            End If
        End Select
      End Get
    End Property
    Public ReadOnly Property Cost() As Decimal
      Get
        'Dim tmpCost As Decimal = Me.UnitCost * Me.StockQty
        'If tmpCost = 0 Then
        '  tmpCost = Me.Amount
        'End If
        'Return tmpCost
        Return ItemCollectionPrePareCost.CostAmount
      End Get
    End Property    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public Property UnitCost() As Decimal
      Get
        'Return m_unitCost
        If Me.StockQty > 0 Then
          Return Me.Cost / Me.StockQty
        End If
        Return 0
      End Get
      Set(ByVal Value As Decimal)
        'm_unitCost = Value
      End Set
    End Property
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub Clear()
      Me.m_entity = New BlankItem("")
      Me.m_entityName = ""
      Me.m_qty = 0
      Me.m_unit = New Unit
      Me.m_unitPrice = 0
      Me.m_unitCost = 0
      Me.m_note = ""
      Me.m_discount = New Discount("")
      Me.m_unvatable = False
      Me.m_account = New Account
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
    Public Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Me.GoodsSold.IsInitialized = False

      row("stocki_linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing Then
        row("stocki_entityType") = Me.ItemType.Value
        Select Case Me.ItemType.Value
          Case 19, 42
            If Not Me.Entity Is Nothing Then
              row("stocki_entity") = Me.Entity.Id
              row("stocki_itemName") = Me.Entity.Name
              row("Code") = Me.Entity.Code
              If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                If Me.Entity.Name <> Me.EntityName Then
                  row("stocki_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                End If
              End If
            End If
            row("Button") = ""
          Case 0
            row("Button") = "invisible"
            row("stocki_itemName") = Me.EntityName
          Case 88, 89
            row("Button") = "invisible"
            If Me.EntityName Is Nothing OrElse Me.EntityName.Length = 0 Then
              row("stocki_itemName") = Me.Entity.Name
            Else
              row("stocki_itemName") = Me.EntityName
            End If
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

      Dim parent As GoodsSold = Me.GoodsSold
      If parent Is Nothing Then parent = New GoodsSold

      If Me.UnitCost <> 0 Then 'AndAlso parent.ValidateRow(row) Then
        row("stocki_unitcost") = Configuration.FormatToString(Me.UnitCost, DigitConfig.Cost)
      Else
        row("stocki_unitcost") = ""
      End If

      row("stocki_discrate") = Me.Discount.Rate
      If Me.Qty <> 0 Then 'AndAlso parent.ValidateRow(row) Then
        row("stocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      Else
        row("stocki_qty") = ""
      End If

      row("stocki_discrate") = Me.Discount.Rate
      If Me.Amount <> 0 Then 'AndAlso parent.ValidateRow(row) Then
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("Amount") = ""
      End If

      row("stocki_note") = Me.Note
      If Me.UnitPrice <> 0 Then 'AndAlso parent.ValidateRow(row) Then
        row("stocki_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
      Else
        row("stocki_unitprice") = ""
      End If
      If Me.StockQty <> 0 Then 'AndAlso parent.ValidateRow(row) Then
        row("StockQty") = Configuration.FormatToString(Me.StockQty, DigitConfig.Qty)
      Else
        row("StockQty") = ""
      End If
      row("stocki_unvatable") = Me.UnVatable

      Me.GoodsSold.IsInitialized = True
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetGoodsSoldItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("GoodsSoldItems")
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
      myDatatable.Columns.Add(New DataColumn("FromCostcenter", GetType(String)))

      For Each tableRow As DataRow In dt.Rows
        Dim gri As New GoodsSoldItem(tableRow, "")
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
        row("FromCostcenter") = tableRow("fromccinfo")
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class GoodsSoldItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_GoodsSold As GoodsSold
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As GoodsSold, ByVal group As Boolean)
      Me.m_GoodsSold = owner
      If Not Me.m_GoodsSold.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetGoodsSoldItems" _
      , New SqlParameter("@stock_id", Me.m_GoodsSold.Id) _
      , New SqlParameter("@grouping", group) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New GoodsSoldItem(row, "")
        item.GoodsSold = m_GoodsSold
        Me.Add(item)
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
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
    Public Property GoodsSold() As GoodsSold      Get        Return m_GoodsSold      End Get      Set(ByVal Value As GoodsSold)        m_GoodsSold = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As GoodsSoldItem
      Get
        Return CType(MyBase.List.Item(index), GoodsSoldItem)
      End Get
      Set(ByVal value As GoodsSoldItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each gi As GoodsSoldItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        gi.CopyToDataRow(newRow)
        newRow.Tag = gi
        gi.ItemValidateRow(newRow)
        newRow.Tag = gi
      Next
      dt.AcceptChanges()
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As GoodsSoldItem) As Integer
      If Not m_GoodsSold Is Nothing Then
        value.GoodsSold = m_GoodsSold
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As GoodsSoldItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As GoodsSoldItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As GoodsSoldItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As GoodsSoldItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As GoodsSoldItemEnumerator
      Return New GoodsSoldItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As GoodsSoldItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As GoodsSoldItem)
      If Not m_GoodsSold Is Nothing Then
        value.GoodsSold = m_GoodsSold
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As GoodsSoldItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As GoodsSoldItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class GoodsSoldItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As GoodsSoldItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, GoodsSoldItem)
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

