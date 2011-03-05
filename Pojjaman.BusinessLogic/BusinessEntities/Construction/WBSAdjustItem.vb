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
  Public Class AdjustAllocateType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "AdjustAllocateType"
      End Get
    End Property
#End Region

  End Class

  Public Class WBSAdjustItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_wbsAdjust As WBSAdjust
    Private m_lineNumber As Integer
    Private m_sequence As Integer
    Private m_itemType As AdjustAllocateType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_cost As Decimal
    Private m_cc As CostCenter
    Private m_note As String

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

      Dim drh As New DataRowHelper(dr)

      m_itemType = New AdjustAllocateType(drh.GetValue(Of Integer)("wbsadji_entityType"))

      'Dim itemId As Integer
      'itemId = drh.GetValue(Of Integer)("adji_entity")
      m_entityName = drh.GetValue(Of String)("wbsadji_itemName")

      'If itemId > 0 Then
      '  Select Case m_itemType.Value
      '    Case 42
      '      m_entity = LCIItem.GetLciItemById(itemId)
      '    Case 19
      '      m_entity = New Tool(itemId)
      '    Case 88, 89
      '      m_entity = LCIItem.GetLciItemById(itemId)
      '  End Select
      'Else
      '  m_entity = New BlankItem(m_entityName)
      'End If
      m_itemType = New AdjustAllocateType(drh.GetValue(Of Integer)("wbsadji_entityType"))
      m_sequence = drh.GetValue(Of Integer)("wbsadji_sequence")
      m_lineNumber = drh.GetValue(Of Integer)("wbsadji_lineNumber")
      m_cost = drh.GetValue(Of Decimal)("wbsadji_costAmount")
      m_note = drh.GetValue(Of String)("wbsadji_note")
      'm_cc = New CostCenter(drh.GetValue(Of Integer)("adji_cc"))

      'm_WBSDistributeCollection = New WBSDistributeCollection
      'AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property CostCenter As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal value As CostCenter)
        m_cc = value
      End Set
    End Property
    Public ReadOnly Property Direction As Integer
      Get
        If Me.Cost < 0 Then
          Return 1
        Else
          Return 0
        End If
      End Get
    End Property
    Public Property Cost() As Decimal
      Get
        Return m_cost
      End Get
      Set(ByVal value As Decimal)
        m_cost = value
      End Set
    End Property
    Public Property Note As String
      Get
        Return m_note
      End Get
      Set(ByVal value As String)
        m_note = value
      End Set
    End Property
    Public Property WBSAdjust() As WBSAdjust
      Get
        Return m_wbsAdjust
      End Get
      Set(ByVal Value As WBSAdjust)
        m_wbsAdjust = Value
      End Set
    End Property
    Public Property Sequence() As Integer
      Get
        Return m_sequence
      End Get
      Set(ByVal Value As Integer)
        m_sequence = Value
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
    Public Property ItemType() As AdjustAllocateType
      Get
        Return m_itemType
      End Get
      Set(ByVal Value As AdjustAllocateType)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemType Is Nothing Then
          m_itemType = Value
          'Me.Clear()
          Return
        End If
        If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
          'ผ่านโลด
          Return
        End If
        'If msgServ.AskQuestion("${res:Global.Question.ChangePREntityType}") Then
        '  Dim oldType As Integer = m_itemType.Value
        m_itemType = Value
        '  For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        '    Dim transferAmt As Decimal = Me.cost
        '    wbsd.BaseCost = transferAmt
        '    'wbsd.TransferBaseCost = transferAmt
        '    Select Case Me.ItemType.Value
        '      Case 0, 19, 42
        '        wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
        '      Case 88
        '        wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
        '      Case 89
        '        wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
        '    End Select
        '    Me.m_pr.SetActual(wbsd.WBS, wbsd.Amount, 0, oldType)
        '    Me.m_pr.SetActual(wbsd.WBS, 0, wbsd.Amount, m_itemType.Value)
        '  Next
        Me.Clear()
        'End If
      End Set
    End Property
    Public Property Entity() As IHasName
      Get
        Return m_entity
      End Get
      Set(ByVal Value As IHasName)
        m_entity = Value
      End Set
    End Property
    'Public Function DupCode(ByVal myCode As String) As Boolean
    '  If Me.Pr Is Nothing Then
    '    Return False
    '  End If
    '  If Me.ItemType Is Nothing Then
    '    Return False
    '  End If
    '  If Me.ItemType.Value = 42 Then
    '    'Material ใส่ Code เดียวกันได้
    '    Return False
    '  End If
    '  If myCode Is Nothing OrElse myCode.Length = 0 Then
    '    Return False
    '  End If
    '  For Each item As PRItem In Me.Pr.ItemCollection
    '    If Not item Is Me Then
    '      If item.ItemType.Value = Me.ItemType.Value Then
    '        Dim theCode As String = ""
    '        If Not item.Entity Is Nothing Then
    '          theCode = item.Entity.Code
    '        End If
    '        If Not theCode Is Nothing AndAlso theCode.Length > 0 Then
    '          If myCode.ToLower = theCode.ToString.ToLower Then
    '            Return True
    '          End If
    '        End If
    '      End If
    '    End If
    '  Next
    '  Return False
    'End Function
    'Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
    '  Try
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset( _
    '    RecentCompanies.CurrentCompany.SiteConnectionString _
    '    , CommandType.StoredProcedure _
    '    , sproc _
    '    , filters _
    '    )
    '    If ds.Tables(0).Rows(0).IsNull(0) Then
    '      Return 0
    '    End If
    '    Return CDec(ds.Tables(0).Rows(0)(0))
    '  Catch ex As Exception
    '  End Try
    'End Function
    Public Sub SetItemCode(ByVal theCode As String)
      'Dim unitPrice As Decimal = 0
      'Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPRPricing"))
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If Me.ItemType Is Nothing Then
      '  'ไม่มี Type
      '  msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '  Return
      'End If
      'If DupCode(theCode) Then
      '  msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {Me.ItemType.Description, theCode})
      '  Return
      'End If
      'Select Case Me.ItemType.Value
      '  Case 160, 162
      '    msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveCode}")
      '    Return
      '  Case 0      ', 88, 89				'Blank
      '    msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
      '    Return
      '  Case 28       'F/A
      '    msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
      '    Return
      '  Case 19       'Tool
      '    If theCode Is Nothing OrElse theCode.Length = 0 Then
      '      If Me.Entity.Code.Length <> 0 Then
      '        If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {Me.Entity.Code}) Then
      '          Me.Clear()
      '        End If
      '      End If
      '      Return
      '    End If
      '    Dim myTool As New Tool(theCode)
      '    If Not myTool.Originated Then
      '      msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {theCode})
      '      Return
      '    ElseIf myTool.Canceled Then
      '      msgServ.ShowMessageFormatted("${res:Global.Error.ToolIsCanceled}", New String() {theCode})
      '      Return
      '    Else
      '      Select Case pricing
      '        Case 0
      '          unitPrice = myTool.FairPrice
      '        Case 2
      '          unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
      '          , New SqlParameter("@pri_entity", myTool.Id) _
      '          , New SqlParameter("@pri_entitytype", myTool.EntityId) _
      '          )
      '      End Select
      '      Dim myUnit As Unit = myTool.Unit
      '      Me.m_unit = myUnit
      '      Me.m_entity = myTool
      '      If Me.Conversion <> 0 Then
      '        unitPrice = unitPrice * Conversion
      '      End If
      '      Me.UnitPrice = unitPrice
      '    End If
      '  Case 42, 88, 89      'LCI
      '    If theCode Is Nothing OrElse theCode.Length = 0 Then
      '      If Me.Entity.Code.Length <> 0 Then
      '        If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {Me.Entity.Code}) Then
      '          Me.Clear()
      '        End If
      '      End If
      '      If Me.ItemType.Value = 42 Then
      '        Return
      '      Else
      '        Exit Select
      '      End If
      '    End If
      '    Dim lci As New LCIItem(theCode)
      '    If Not lci.Originated Then
      '      msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {theCode})
      '      Return
      '    ElseIf lci.Canceled Then
      '      msgServ.ShowMessageFormatted("${res:Global.Error.LCIIsCanceled}", New String() {theCode})
      '      Return
      '    ElseIf lci.Level <> 5 Then
      '      msgServ.ShowMessageFormatted("${res:Global.LCI.Level5Only}", New String() {theCode})
      '      Return
      '    Else
      '      Select Case pricing
      '        Case 0
      '          unitPrice = lci.FairPrice
      '        Case 2
      '          unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
      '          , New SqlParameter("@pri_entity", lci.Id) _
      '          , New SqlParameter("@pri_entitytype", lci.EntityId) _
      '          )
      '      End Select
      '      Dim myUnit As Unit = lci.DefaultUnit
      '      Me.m_unit = myUnit
      '      Me.m_entity = lci
      '      If Me.Conversion <> 0 Then
      '        unitPrice = unitPrice * Conversion
      '      End If
      '      Me.UnitPrice = unitPrice
      '    End If
      '  Case Else
      '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '    Return
      'End Select
      'Me.Qty = 1
      'Me.OrderedQty = 0
    End Sub
    Public Sub SetItemPrice(ByVal theCode As String)
      'Dim unitPrice As Decimal = 0
      'Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPRPricing"))
      'Select Case Me.ItemType.Value
      '  Case 19       'Tool
      '    If theCode Is Nothing OrElse theCode.Length = 0 Then
      '      Return
      '    End If
      '    Dim myTool As New Tool(theCode)

      '    Select Case pricing
      '      Case 0
      '        unitPrice = myTool.FairPrice
      '      Case 2
      '        unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
      '        , New SqlParameter("@pri_entity", myTool.Id) _
      '        , New SqlParameter("@pri_entitytype", myTool.EntityId) _
      '        )
      '    End Select
      '    If Me.Conversion <> 0 Then
      '      unitPrice = unitPrice * Conversion
      '    End If
      '    Me.UnitPrice = unitPrice
      '    Me.Qty = 1
      '    Me.OrderedQty = 0
      '  Case 42, 88, 89      'LCI
      '    If theCode Is Nothing OrElse theCode.Length = 0 Then
      '      Return
      '    End If
      '    Dim lci As New LCIItem(theCode)

      '    Select Case pricing
      '      Case 0
      '        unitPrice = lci.FairPrice
      '      Case 2
      '        unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
      '        , New SqlParameter("@pri_entity", lci.Id) _
      '        , New SqlParameter("@pri_entitytype", lci.EntityId) _
      '        )
      '    End Select
      '    If Me.Conversion <> 0 Then
      '      unitPrice = unitPrice * Conversion
      '    End If
      '    Me.UnitPrice = unitPrice
      '    Me.Qty = 1
      '    Me.OrderedQty = 0

      '  Case Else
      'End Select
    End Sub
    Public Property EntityName() As String
      Get
        Return m_entityName
      End Get
      Set(ByVal Value As String)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

        Me.m_entityName = Value

      End Set
    End Property
    'Public Property Unit() As Unit
    '  Get
    '    Return m_unit
    '  End Get
    '  Set(ByVal Value As Unit)
    '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '    If Me.ItemType Is Nothing Then
    '      'ไม่มี Type
    '      msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '      Return
    '    End If
    '    If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
    '      msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnit}")
    '      Return
    '    End If
    '    Dim oldConversion As Decimal = Me.Conversion
    '    Dim newConversion As Decimal = 1
    '    Dim err As String = ""
    '    If Not Value Is Nothing AndAlso Value.Originated Then
    '      If TypeOf Me.Entity Is LCIItem Then
    '        If CType(Me.Entity, LCIItem).Level < 5 Then
    '          newConversion = 1
    '        Else
    '          If Not CType(Me.Entity, LCIItem).ValidUnit(Value) Then
    '            err = "${res:Global.Error.NoUnitConversion}"
    '          Else
    '            newConversion = CType(Me.Entity, LCIItem).GetConversion(Value)
    '          End If
    '        End If
    '      ElseIf TypeOf Me.Entity Is Tool Then
    '        If Not (Not CType(Me.Entity, Tool).Unit Is Nothing AndAlso CType(Me.Entity, Tool).Unit.Id = Value.Id) Then
    '          err = "${res:Global.Error.NoUnitConversion}"
    '        End If
    '      End If
    '    Else
    '      err = "${res:Global.Error.InvalidUnit}"
    '    End If
    '    If err.Length = 0 Then
    '      If Me.m_qty <> 0 Then
    '        'Me.m_qty = (oldConversion / newConversion) * Me.m_qty
    '        Me.Qty = (Me.Qty * oldConversion) / newConversion
    '      End If
    '      If Me.UnitPrice <> 0 Then
    '        'Me.m_unitprice = (newConversion / oldConversion) * Me.m_unitprice
    '        Me.UnitPrice = (Me.UnitPrice / oldConversion) * newConversion
    '      End If
    '      m_unit = Value
    '      Me.Conversion = newConversion
    '    Else
    '      msgServ.ShowMessage(err)
    '    End If
    '  End Set
    'End Property
    'Private Sub UpdateWBS()
    '  For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
    '    Dim bfTax As Decimal = 0
    '    Dim oldVal As Decimal = wbsd.Amount
    '    Dim transferAmt As Decimal = Me.Amount
    '    wbsd.BaseCost = bfTax
    '    wbsd.BaseCost = transferAmt
    '    Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.Amount, oldVal))
    '  Next
    'End Sub
    'Public Property Qty() As Decimal
    '  Get
    '    Return m_qty
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '    If Me.ItemType Is Nothing Then
    '      'ไม่มี Type
    '      msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '      Return
    '    End If
    '    If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
    '      'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
    '      msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
    '      Return
    '    End If
    '    If IsNumeric(Value) Then
    '      m_qty = Configuration.Format(Value, DigitConfig.Qty)
    '    Else
    '      m_qty = 0
    '    End If
    '    UpdateWBS()
    '  End Set
    'End Property
    'Public Property OriginQty() As Decimal
    '  Get
    '    Return m_originQty
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_originQty = Configuration.Format(Value, DigitConfig.Qty)
    '  End Set
    'End Property
    'Public ReadOnly Property StockQty() As Decimal
    '  Get
    '    Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)
    '  End Get
    'End Property
    'Public Property OrderedQty() As Decimal
    '  Get
    '    Return m_orderedQty
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_orderedQty = Value
    '  End Set
    'End Property
    'Public Property WithdrawnQty() As Decimal
    '  Get
    '    Return m_withdrawnQty
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_withdrawnQty = Value
    '  End Set
    'End Property
    'Public ReadOnly Property RemainingQty() As Decimal
    '  Get
    '    Return Me.Qty - Me.OrderedQty
    '  End Get
    'End Property
    'Public Property Note() As String
    '  Get
    '    Return m_note
    '  End Get
    '  Set(ByVal Value As String)
    '    m_note = Value
    '  End Set
    'End Property
#End Region

#Region "Methods"
    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements IWBSAllocatableItem.WBSChangedHandler
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
            If Not Me.m_wbsAdjust Is Nothing Then

              'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "amount"
            If Not Me.m_wbsAdjust Is Nothing Then

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
              Case 0
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
                'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.SC, 6) - Me.SC.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
              Case 1
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
                wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerLabBudgetAmount
              Case 2
                wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
                wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerEqBudgetAmount
            End Select
            If wbsd.IsMarkup Then
              wbsd.BudgetRemain = newWBS.GetTotalMarkUpFromDB - GetWBSActualFromDB(Me.m_wbsAdjust.Id, Me.m_wbsAdjust.AllocationType, wbsd.WBS.Id, Me.ItemType.Value, Me.Direction)
              wbsd.QtyRemain = 0
            Else
              wbsd.BudgetRemain = wbsd.BudgetAmount - GetWBSActualFromDB(Me.m_wbsAdjust.Id, Me.m_wbsAdjust.AllocationType, wbsd.WBS.Id, Me.ItemType.Value, Me.Direction)
              'If Me.ItemType.Value <> 88 And Me.ItemType.Value <> 89 Then
              '  wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.m_wbsAdjust.Id, Me.m_wbsAdjust.EntityId, Me.Entity.Id, _
              '                                                                Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
              'Else
              wbsd.QtyRemain = 0
              'End If
            End If

        End Select
      End If
    End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim type As Object = row("entitytype")
      Dim itemname As Object = row("itemname")
      Dim cost As Object = row("cost")
      'Dim cc As Object = row("costcenter")

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If IsDBNull(type) OrElse type.ToString.Length = 0 Then
        row.SetColumnError("entitytype", myStringParserService.Parse("${res:Global.Error.ItemTypeMissing}"))
      Else
        row.SetColumnError("entitytype", "")
      End If
      If IsDBNull(itemname) OrElse itemname.ToString.Length = 0 Then
        row.SetColumnError("itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
      Else
        row.SetColumnError("itemname", "")
      End If
      If IsDBNull(cost) OrElse cost.ToString.Length = 0 Then
        row.SetColumnError("cost", myStringParserService.Parse("${res:Global.Error.RealAmountMissing}"))
      Else
        row.SetColumnError("cost", "")
      End If
      'If IsDBNull(cc) OrElse cc.ToString.Length = 0 Then
      '  row.SetColumnError("costcenter", myStringParserService.Parse("${res:Global.Error.CostCenterMissing}"))
      'Else
      '  row.SetColumnError("costcenter", "")
      'End If

    End Sub
    Public Sub Clear()
      'Me.m_entity = New BlankItem("")
      'Me.m_entityName = ""
      'Me.m_qty = 0
      'Me.m_originQty = 0
      'Me.m_orderedQty = 0
      'Me.m_unit = New Unit
      'Me.m_unitprice = 0
      'Me.m_note = ""
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.WBSAdjust.IsInitialized = False
        row("linenumber") = Me.LineNumber
        row("entityType") = Me.ItemType.Value
        row("itemName") = Me.EntityName

        If Not Me.CostCenter Is Nothing Then
          row("costcenter") = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        End If


        'If Not Me.ItemType Is Nothing Then
        '  row("entityType") = Me.ItemType.Value
        '  Select Case Me.ItemType.Value
        '    Case 19, 42
        '      If Not Me.Entity Is Nothing Then
        '        row("entity") = Me.Entity.Id
        '        row("itemName") = Me.Entity.Name
        '        row("EntityName") = Me.Entity.Name
        '        row("Code") = Me.Entity.Code
        '        If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
        '          If Me.Entity.Name <> Me.EntityName Then
        '            row("itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
        '          End If
        '        End If
        '      End If
        '      row("Button") = ""
        '    Case 88, 89
        '      If Not Me.Entity Is Nothing Then
        '        If TypeOf (Me.Entity) Is LCIItem Then
        '          row("entity") = Me.Entity.Id
        '          row("itemName") = Me.Entity.Name
        '          row("EntityName") = Me.Entity.Name
        '          row("Code") = Me.Entity.Code
        '          If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
        '            If Me.Entity.Name <> Me.EntityName Then
        '              row("itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
        '            End If
        '          End If
        '        Else
        '          'row("Button") = "invisible"
        '          row("itemName") = Me.EntityName
        '        End If
        '        row("Button") = ""
        '      End If
        '    Case 0, 28           ', 88, 89
        '      row("Button") = "invisible"
        '      row("itemName") = Me.EntityName
        '    Case 160, 162
        '      row("Button") = "invisible"
        '      'row("UnitButton") = "invisible"
        '      row("itemName") = Me.EntityName
        '  End Select
        'End If

        'If Not Me.Unit Is Nothing Then
        '  row("pri_unit") = Me.Unit.Id
        '  row("Unit") = Me.Unit.Name
        'End If
        'Me.Conversion = 1
        'If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
        '  If TypeOf Me.Entity Is LCIItem Then
        '    Dim lci As LCIItem = CType(Me.Entity, LCIItem)
        '    Me.Conversion = lci.GetConversion(Me.Unit)
        '  Else
        '    Me.Conversion = 1
        '  End If
        'End If

        'If Me.Qty <> 0 Then
        '  row("pri_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        'Else
        '  If Me.Pr.Closed Then
        '    row("pri_qty") = "0"
        '  Else
        '    row("pri_qty") = ""
        '  End If
        'End If

        'If Me.OriginQty <> 0 Then
        '  row("pri_originqty") = Configuration.FormatToString(Me.OriginQty, DigitConfig.Qty)
        'Else
        '  row("pri_originqty") = ""
        'End If

        If Me.Cost <> 0 Then
          row("Cost") = Configuration.FormatToString(Me.Cost, DigitConfig.Price)
        Else
          row("Cost") = ""
        End If

        'If Me.OriginAmount <> 0 Then
        '  row("pri_originamt") = Configuration.FormatToString(Me.OriginAmount, DigitConfig.Price)
        'Else
        '  row("pri_originamt") = ""
        'End If

        row("note") = Me.Note

        'If Me.UnitPrice <> 0 Then
        '  row("pri_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        'Else
        '  row("pri_unitprice") = ""
        'End If
        'If Me.OrderedQty <> Decimal.MinValue And Me.OrderedQty <> 0 Then
        '  'row("OrderedQty") = Configuration.FormatToString(Me.OrderedQty / Me.Conversion, DigitConfig.Qty)
        '  row("OrderedQty") = Configuration.FormatToString(Me.OrderedQty, DigitConfig.Qty)
        'Else
        '  row("OrderedQty") = DBNull.Value
        'End If

        Me.WBSAdjust.IsInitialized = True
        'Catch ex As NoConversionException
        '  MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Function GetWBSActualFromDB(ByVal Id As Integer, ByVal entityId As Integer, ByVal wbsId As Integer _                                       , ByVal ItemTypeId As Integer, ByVal direction As Integer) As Decimal      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                SimpleBusinessEntityBase.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetWBSActualRemainForWBSAdjustItem" _
                , New SqlParameter("@id", Id) _
                , New SqlParameter("@entityId", entityId) _
                , New SqlParameter("@wbsid", wbsId) _
                , New SqlParameter("@itemTypeId", ItemTypeId) _
                , New SqlParameter("@direction", direction) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
      Return 0
    End Function
    'Public Function GetOrderedQty() As Decimal
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.Pr.ConnectionString _
    '  , CommandType.StoredProcedure _
    '  , "GetOrderedQty" _
    '  , New SqlParameter("@pr_id", Me.Pr.Id) _
    '  , New SqlParameter("@entity_id", Me.Entity.Id) _
    '  , New SqlParameter("@linenumber", Me.LineNumber) _
    '  )
    '  If ds.Tables(0).Rows.Count = 1 Then
    '    If IsNumeric(ds.Tables(0).Rows(0)("pri_orderedqty")) Then
    '      Return CDec(ds.Tables(0).Rows(0)("pri_orderedqty"))
    '    End If
    '  End If
    'End Function
    'Public Function GetWithdrawnQty() As Decimal
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.Pr.ConnectionString _
    '  , CommandType.StoredProcedure _
    '  , "GetWithdrawnQty" _
    '  , New SqlParameter("@pr_id", Me.Pr.Id) _
    '  , New SqlParameter("@entity_id", Me.Entity.Id) _
    '  , New SqlParameter("@linenumber", Me.LineNumber) _
    '  )
    '  If ds.Tables(0).Rows.Count = 1 Then
    '    If IsNumeric(ds.Tables(0).Rows(0)("pri_withdrawnqty")) Then
    '      Return CDec(ds.Tables(0).Rows(0)("pri_withdrawnqty"))
    '    End If
    '  End If
    'End Function
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetPRItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("PRItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("m_pr", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("ReceivingDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyReceivingDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))

      Dim inValidIds As ArrayList = GetPRIdWithOnlyNoteItem(dt)
      For Each tableRow As DataRow In dt.Rows
        If Not inValidIds.Contains(CInt(tableRow("pri_pr"))) Then

          Dim newId As Integer = CInt(tableRow("pri_pr"))
          Dim newLine As Integer = CInt(tableRow("pri_linenumber"))
          'Dim pri As New PRItem(newId, newLine)
          Dim pri As New PRItem(tableRow, "")

          Dim row As TreeRow = myDatatable.Childs.Add
          row("Selected") = False
          row("Code") = tableRow("pr_code")
          row("m_pr") = tableRow("pri_pr")

          Dim prId As Integer
          If Not row.IsNull("m_pr") Then
            prId = CInt(row("m_pr"))
          End If

          row("Linenumber") = tableRow("pri_linenumber")
          row("Date") = tableRow("pr_docdate")
          row("ReceivingDate") = tableRow("pr_receivingdate")

          Dim entityText As String = ""
          If Not pri.ItemType Is Nothing Then
            entityText &= pri.ItemType.Description & ":"
          End If
          If Not pri.Entity.Code Is Nothing AndAlso pri.Entity.Code.Length > 0 Then
            entityText &= pri.Entity.Code & ":"
          End If
          If Not pri.Entity.Name Is Nothing AndAlso pri.Entity.Name.Length > 0 Then
            entityText &= pri.Entity.Name
          End If
          row("Entity") = entityText
          row("Qty") = pri.Qty
          row("OrderedQty") = pri.OrderedQty
          row("Requestor") = tableRow("requestorinfo")
          row("CostCenter") = tableRow("ccinfo")
          row.State = RowExpandState.None

          pri.Pr = New PR
          pri.Pr.Id = prId
          row.Tag = pri
        End If
      Next
      Return myDatatable
    End Function
    Public Shared Function GetListDatatableForMatWithDraw(ByVal procName As String, ByVal ParamArray filters() As Filter) As DataTable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, procName, params)
      Return ds.Tables(0)
    End Function
    Private Shared Function GetPRIdWithOnlyNoteItem(ByVal dt As DataTable) As ArrayList
      Dim arr As New ArrayList
      Dim tmpId As Integer = 0
      For Each tableRow As DataRow In dt.Rows
        If tmpId <> CInt(tableRow("pri_pr")) Then
          tmpId = CInt(tableRow("pri_pr"))
          If Not arr.Contains(tmpId) Then
            arr.Add(tmpId)
          End If
        End If
      Next
      Dim realArr As New ArrayList
      For Each id As Integer In arr
        Dim rows As DataRow() = dt.Select("pri_pr = " & id)
        Dim found As Boolean = False
        For Each row As DataRow In rows
          Dim pri As New PRItem(row, "")
          If pri.OrderedQty <> 0 Or pri.Qty <> 0 Then
            found = True
            Exit For
          End If
        Next
        If Not found Then
          If Not realArr.Contains(id) Then
            realArr.Add(id)
          End If
        End If
      Next
      Return realArr
    End Function
#End Region

    'Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
    '  'If TypeOf sender Is WBSDistribute Then
    '  '  Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
    '  '  Select Case e.Name.ToLower
    '  '    Case "percent"
    '  '      If Not Me.m_pr Is Nothing Then
    '  '        Me.m_pr.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
    '  '      End If
    '  '    Case "wbs"
    '  '      Dim oldWBS As WBS = CType(e.OldValue, WBS)
    '  '      Dim newWBS As WBS = CType(e.Value, WBS)
    '  '      Select Case Me.ItemType.Value
    '  '        Case 0, 19, 42
    '  '          wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
    '  '        Case 88
    '  '          wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
    '  '        Case 89
    '  '          wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
    '  '      End Select
    '  '      Me.m_pr.SetActual(oldWBS, wbsd.TransferAmount, 0, Me.ItemType.Value)
    '  '      Me.m_pr.SetActual(newWBS, 0, wbsd.TransferAmount, Me.ItemType.Value)
    '  '  End Select
    '  'End If
    '  If TypeOf sender Is WBSDistribute Then
    '    Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
    '    Select Case e.Name.ToLower
    '      Case "percent"
    '        If Not Me.m_pr Is Nothing Then

    '          'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
    '        End If
    '      Case "amount"
    '        If Not Me.m_pr Is Nothing Then

    '          'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
    '        End If
    '      Case "wbs"
    '        'Dim oldWBS As WBS = CType(e.OldValue, WBS)
    '        Dim newWBS As WBS = CType(e.Value, WBS)
    '        Dim theName As String = Me.EntityName
    '        If theName Is Nothing Then
    '          theName = Me.Entity.Name
    '        End If
    '        Select Case Me.ItemType.Value
    '          'Case 289
    '          '  wbsd.BudgetAmount = newWBS.GetTotalLabFromDB 'GetTotalMatFromDB
    '          '  wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
    '          Case 0
    '            wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
    '            wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
    '            'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.SC, 6) - Me.SC.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
    '            wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
    '          Case 19
    '            wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
    '            wbsd.BudgetQty = 0        'ไม่มี budget ให้เครื่องมือแน่ๆ
    '            wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
    '          Case 42
    '            wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
    '            wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Me.Entity.Id)
    '            wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
    '          Case 88
    '            wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
    '            wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
    '            wbsd.OwnerBudgetAmount = newWBS.OwnerLabBudgetAmount
    '          Case 89
    '            wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
    '            wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
    '            wbsd.OwnerBudgetAmount = newWBS.OwnerEqBudgetAmount
    '        End Select
    '        If wbsd.IsMarkup Then
    '          wbsd.BudgetRemain = newWBS.GetTotalMarkUpFromDB - newWBS.GetWBSActualFromDB(Me.Pr.Id, Me.Pr.EntityId, Me.ItemType.Value)
    '          wbsd.QtyRemain = 0
    '        Else
    '          wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.Pr.Id, Me.Pr.EntityId, Me.ItemType.Value)
    '          If Me.ItemType.Value <> 88 And Me.ItemType.Value <> 89 Then
    '            wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.Pr.Id, Me.Pr.EntityId, Me.Entity.Id, _
    '                                                                          Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
    '          Else
    '            wbsd.QtyRemain = 0
    '          End If
    '        End If

    '    End Select
    '  End If
    'End Sub

    'Public Sub UpdateWBSQty()
    '  If Me.ItemType.Value <> 88 AndAlso Me.ItemType.Value <> 89 Then
    '    For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
    '      If wbsd.IsMarkup Then
    '        wbsd.BaseQty = 0
    '      Else
    '        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, ItemType.Value)
    '        If boqConversion = 0 Then
    '          wbsd.BaseQty = Me.Qty
    '        Else
    '          wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
    '        End If
    '      End If
    '    Next
    '  Else
    '    For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
    '      wbsd.BaseQty = 0
    '    Next
    '  End If
    'End Sub

#Region "IWBSAllocatableItem"
    Public ReadOnly Property AllocationErrorMessage As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        If Me.ItemType Is Nothing Then
          Return "No Item Type"
        End If
        Return ""
      End Get
    End Property

    Public ReadOnly Property AllocationType As String Implements IWBSAllocatableItem.AllocationType
      Get
        Select Case Me.ItemType.Value
          Case 0
            Return "mat"
          Case 1
            Return "lab"
          Case 2
            Return "eq"
        End Select
      End Get
    End Property

    Public ReadOnly Property Description As String Implements IWBSAllocatableItem.Description
      Get
        Return Trim(Me.EntityName)
      End Get
    End Property

    Public ReadOnly Property Type As String Implements IWBSAllocatableItem.Type
      Get
        Dim strType As String = CodeDescription.GetDescription("stocki_enitytype", 0)
        Return strType & " (" & AllocationType.ToUpper & ")"
      End Get
    End Property

    Public ReadOnly Property ItemAmount As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Return Me.Cost
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

    Public Property WBSDistributeCollection2 As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2
      Get

      End Get
      Set(ByVal value As WBSDistributeCollection)

      End Set
    End Property
#End Region

  End Class

End Namespace

