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
	Public Class ItemType
		Inherits CodeDescription

#Region "Constructors"
		Public Sub New(ByVal value As Integer)
			MyBase.New(value)
		End Sub
#End Region

#Region "Properties"
		Public Overrides ReadOnly Property CodeName() As String
			Get
				Return "ItemType"
			End Get
		End Property
#End Region

	End Class

	Public Class BlankItem
		Implements IHasName

#Region "Members"
		Private m_name As String
#End Region

#Region "Constructors"
		Public Sub New(ByVal name As String)
			Me.m_name = name
		End Sub
#End Region

#Region "IHasName"
		Public Property Name() As String Implements IHasName.Name
			Get
				Return m_name
			End Get
			Set(ByVal Value As String)
				m_name = Value
			End Set
		End Property
		Public Property Code() As String Implements IIdentifiable.Code
			Get
				Return ""
			End Get
			Set(ByVal Value As String)

			End Set
		End Property
		Public Property Id() As Integer Implements IIdentifiable.Id
			Get
				Return 0
			End Get
			Set(ByVal Value As Integer)

			End Set
		End Property
#End Region


	End Class

  Public Class PRItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_pr As PR
    Private m_lineNumber As Integer
    Private m_itemType As ItemType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Public m_qty As Decimal
    Private m_originQty As Decimal
    Private m_orderedQty As Decimal
    Private m_withdrawnQty As Decimal
    Private m_note As String
    Private m_conversion As Decimal = 1

    Private m_unitprice As Decimal

    Private m_WBSDistributeCollection As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_WBSDistributeCollection = New WBSDistributeCollection
      AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal id As Integer, ByVal line As Integer)
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetPRItems" _
      , New SqlParameter("@pr_id", id) _
      , New SqlParameter("@pri_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
      Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
      AddHandler wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
      m_WBSDistributeCollection = wbsdColl
      If ds.Tables.Count > 1 Then
        For Each wbsRow As DataRow In ds.Tables(1).Select("priw_prilinenumber=" & Me.LineNumber)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdColl.Add(wbsd)
        Next
      End If
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "pri_entityType") AndAlso Not dr.IsNull(aliasPrefix & "pri_entityType") Then
          .m_itemType = New ItemType(CInt(dr(aliasPrefix & "pri_entityType")))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "pri_entity") AndAlso Not dr.IsNull(aliasPrefix & "pri_entity") Then
          itemId = CInt(dr(aliasPrefix & "pri_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pri_itemName") AndAlso Not dr.IsNull(aliasPrefix & "pri_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "pri_itemName"))
        Else
          .m_entityName = ""
        End If
        Select Case .m_itemType.Value
          Case 42        '"lci"
            If dr.Table.Columns.Contains("pri_entity") AndAlso Not dr.IsNull("pri_entity") Then
              .m_entity = LCIItem.GetLciItemById(itemId)
              '  If Not dr.IsNull("lci_id") Then
              '    .m_entity = New LCIItem(dr, "")
              '  End If
              'Else
              '  .m_entity = New LCIItem(itemId)
            End If
          Case 19        '"tool"
            If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("tool_id") Then
                .m_entity = New Tool(dr, "")
              End If
            Else
              .m_entity = New Tool(itemId)
            End If
          Case 88, 89
            If itemId > 0 Then
              If dr.Table.Columns.Contains("pri_entity") AndAlso Not dr.IsNull("pri_entity") Then
                .m_entity = LCIItem.GetLciItemById(itemId)
                '  If Not dr.IsNull("lci_id") Then
                '    .m_entity = New LCIItem(dr, "")
                '  End If
                'Else
                '  .m_entity = New LCIItem(itemId)
              End If
            Else
              .m_entity = New BlankItem(.m_entityName)
            End If
          Case Else         '0, 28, 88, 89, 160, 162
            .m_entity = New BlankItem(.m_entityName)
        End Select

        If dr.Table.Columns.Contains(aliasPrefix & "pri_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "pri_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "pri_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pri_qty") AndAlso Not dr.IsNull(aliasPrefix & "pri_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "pri_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pri_originqty") AndAlso Not dr.IsNull(aliasPrefix & "pri_originqty") Then
          .m_originQty = CDec(dr(aliasPrefix & "pri_originqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pri_orderedqty") AndAlso Not dr.IsNull(aliasPrefix & "pri_orderedqty") Then
          .m_orderedQty = CDec(dr(aliasPrefix & "pri_orderedqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pri_withdrawnqty") AndAlso Not dr.IsNull(aliasPrefix & "pri_withdrawnqty") Then
          .m_withdrawnQty = CDec(dr(aliasPrefix & "pri_withdrawnqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pri_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "pri_unitprice") Then
          .m_unitprice = CDec(dr(aliasPrefix & "pri_unitprice"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pri_note") AndAlso Not dr.IsNull(aliasPrefix & "pri_note") Then
          .m_note = CStr(dr(aliasPrefix & "pri_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "pri_unit") AndAlso Not dr.IsNull(aliasPrefix & "pri_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & "pri_unit")))
          End If
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            'Dim lci As LCIItem
            Try
              'Me.Conversion = lci.GetConversion(Me.Unit)
              Me.Conversion = CType(Me.Entity, LCIItem).GetConversion(Me.Unit)
              Trace.WriteLine(CType(Me.Entity, LCIItem).Id.ToString & " : " & Configuration.FormatToString(Me.Conversion, DigitConfig.Price))
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
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
    Public Property UnitPrice() As Decimal      Get        Return m_unitprice      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
            m_unitprice = Value
            UpdateWBS()
          Case Else
            msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        End Select      End Set    End Property
    Public ReadOnly Property Amount() As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Return Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
      End Get
    End Property
    Public ReadOnly Property OriginAmount() As Decimal
      Get
        Return Configuration.Format((Me.UnitPrice * Me.OriginQty), DigitConfig.Price)
      End Get
    End Property
    Public Property Pr() As PR      Get        Return m_pr      End Get      Set(ByVal Value As PR)        m_pr = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property ItemType() As ItemType      Get        Return m_itemType      End Get      Set(ByVal Value As ItemType)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemType Is Nothing Then
          m_itemType = Value
          Me.Clear()
          Return
        End If
        If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
          'ผ่านโลด
          Return
        End If
        If msgServ.AskQuestion("${res:Global.Question.ChangePREntityType}") Then
          Dim oldType As Integer = m_itemType.Value
          m_itemType = Value
          For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
            Dim transferAmt As Decimal = Me.Amount
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
            Me.m_pr.SetActual(wbsd.WBS, wbsd.TransferAmount, 0, oldType)
            Me.m_pr.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, m_itemType.Value)
          Next
          Me.Clear()
        End If      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If      End Set    End Property    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.Pr Is Nothing Then        Return False
      End If      If Me.ItemType Is Nothing Then
        Return False
      End If
      If Me.ItemType.Value = 42 Then
        'Material ใส่ Code เดียวกันได้
        Return False
      End If
      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As PRItem In Me.Pr.ItemCollection
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
    End Function    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
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
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPRPricing"))      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        Case 160, 162
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveCode}")
          Return
        Case 0      ', 88, 89				'Blank
          msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
          Return
        Case 28       'F/A
          msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
          Return
        Case 19       'Tool
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
              Case 2
                unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
                , New SqlParameter("@pri_entity", myTool.Id) _
                , New SqlParameter("@pri_entitytype", myTool.EntityId) _
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
        Case 42, 88, 89      'LCI
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
              Case 2
                unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
                , New SqlParameter("@pri_entity", lci.Id) _
                , New SqlParameter("@pri_entitytype", lci.EntityId) _
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
      Me.OrderedQty = 0
    End Sub    Public Sub SetItemPrice(ByVal theCode As String)      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPRPricing"))      Select Case Me.ItemType.Value
        Case 19       'Tool
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim myTool As New Tool(theCode)

          Select Case pricing
            Case 0
              unitPrice = myTool.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
              , New SqlParameter("@pri_entity", myTool.Id) _
              , New SqlParameter("@pri_entitytype", myTool.EntityId) _
              )
          End Select
          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice
          Me.Qty = 1
          Me.OrderedQty = 0
        Case 42, 88, 89      'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim lci As New LCIItem(theCode)

          Select Case pricing
            Case 0
              unitPrice = lci.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
              , New SqlParameter("@pri_entity", lci.Id) _
              , New SqlParameter("@pri_entitytype", lci.EntityId) _
              )
          End Select
          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice
          Me.Qty = 1
          Me.OrderedQty = 0

        Case Else
      End Select
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
          Case Else         '0, 28, 88, 89, 160, 162
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
          If Me.m_qty <> 0 Then
            'Me.m_qty = (oldConversion / newConversion) * Me.m_qty
            Me.Qty = (Me.Qty * oldConversion) / newConversion
          End If
          If Me.UnitPrice <> 0 Then
            'Me.m_unitprice = (newConversion / oldConversion) * Me.m_unitprice
            Me.UnitPrice = (Me.UnitPrice / oldConversion) * newConversion
          End If
          m_unit = Value
          Me.Conversion = newConversion
        Else
          msgServ.ShowMessage(err)
        End If      End Set    End Property    Private Sub UpdateWBS()
      For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        Dim bfTax As Decimal = 0
        Dim oldVal As Decimal = wbsd.TransferAmount
        Dim transferAmt As Decimal = Me.Amount
        wbsd.BaseCost = bfTax
        wbsd.TransferBaseCost = transferAmt
        Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
    End Sub    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
          'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
          Return
        End If        If IsNumeric(Value) Then          m_qty = Configuration.Format(Value, DigitConfig.Qty)
        Else
          m_qty = 0
        End If        UpdateWBS()      End Set    End Property    Public Property OriginQty() As Decimal      Get        Return m_originQty      End Get      Set(ByVal Value As Decimal)        m_originQty = Configuration.Format(Value, DigitConfig.Qty)      End Set    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)      End Get    End Property    Public Property OrderedQty() As Decimal      Get        Return m_orderedQty      End Get      Set(ByVal Value As Decimal)        m_orderedQty = Value      End Set    End Property    Public Property WithdrawnQty() As Decimal      Get        Return m_withdrawnQty      End Get      Set(ByVal Value As Decimal)        m_withdrawnQty = Value      End Set    End Property    Public ReadOnly Property RemainingQty() As Decimal      Get        Return Me.Qty - Me.OrderedQty      End Get    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim code As Object = row("code")
      Dim pri_itemname As Object = row("pri_itemname")
      Dim pri_entitytype As Object = row("pri_entitytype")
      Dim unit As Object = row("unit")
      Dim pri_qty As Object = row("pri_qty")

      Dim isClosed As Boolean = False
      isClosed = Me.Pr.Closed

      Dim isBlankRow As Boolean = False
      If IsDBNull(pri_entitytype) Then
        isBlankRow = True
      End If
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not isBlankRow Then
        Select Case CInt(pri_entitytype)
          Case 160, 162
            row.SetColumnError("pri_qty", "")
            row.SetColumnError("pri_itemname", "")
            row.SetColumnError("code", "")
          Case 0, 88, 89         'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("pri_qty", "")
              Else
                row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
            Else
              row.SetColumnError("pri_qty", "")
            End If
            row.SetColumnError("code", "")
          Case 19        'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("pri_qty", "")
              Else
                row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
            Else
              row.SetColumnError("pri_qty", "")
            End If
          Case 28        'F/A
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("pri_qty", "")
              Else
                row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
            Else
              row.SetColumnError("pri_qty", "")
            End If
            row.SetColumnError("code", "")
          Case 42        'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(pri_itemname) OrElse pri_itemname.ToString.Length = 0 Then
              row.SetColumnError("pri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pri_itemname", "")
            End If
            If IsDBNull(pri_qty) OrElse Not IsNumeric(pri_qty) OrElse CDec(pri_qty) <= 0 Then
              If isClosed Then
                row.SetColumnError("pri_qty", "")
              Else
                row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              End If
              'If CDec(pri_qty) <= 0 Then
              '  If Not (Me.Pr.ClosedBefor And Not Me.Pr.Closed) Then
              '    row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              '  End If
              'Else
              '  row.SetColumnError("pri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
              'End If
            Else
              row.SetColumnError("pri_qty", "")
            End If
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Sub Clear()
      Me.m_entity = New BlankItem("")
      Me.m_entityName = ""
      Me.m_qty = 0
      Me.m_originQty = 0
      Me.m_orderedQty = 0
      Me.m_unit = New Unit
      Me.m_unitprice = 0
      Me.m_note = ""
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.Pr.IsInitialized = False
        row("pri_linenumber") = Me.LineNumber

        If Not Me.ItemType Is Nothing Then
          row("pri_entityType") = Me.ItemType.Value
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("pri_entity") = Me.Entity.Id
                row("pri_itemName") = Me.Entity.Name
                row("EntityName") = Me.Entity.Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("pri_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                If TypeOf (Me.Entity) Is LCIItem Then
                  row("pri_entity") = Me.Entity.Id
                  row("pri_itemName") = Me.Entity.Name
                  row("EntityName") = Me.Entity.Name
                  row("Code") = Me.Entity.Code
                  If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                    If Me.Entity.Name <> Me.EntityName Then
                      row("pri_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
                    End If
                  End If
                Else
                  'row("Button") = "invisible"
                  row("pri_itemName") = Me.EntityName
                End If
                row("Button") = ""
              End If
            Case 0, 28           ', 88, 89
              row("Button") = "invisible"
              row("pri_itemName") = Me.EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("pri_itemName") = Me.EntityName
          End Select
        End If

        If Not Me.Unit Is Nothing Then
          row("pri_unit") = Me.Unit.Id
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

        If Me.Qty <> 0 Then
          row("pri_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          If Me.Pr.Closed Then
            row("pri_qty") = "0"
          Else
            row("pri_qty") = ""
          End If
        End If

        If Me.OriginQty <> 0 Then
          row("pri_originqty") = Configuration.FormatToString(Me.OriginQty, DigitConfig.Qty)
        Else
          row("pri_originqty") = ""
        End If

        If Me.Amount <> 0 Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If

        If Me.OriginAmount <> 0 Then
          row("pri_originamt") = Configuration.FormatToString(Me.OriginAmount, DigitConfig.Price)
        Else
          row("pri_originamt") = ""
        End If

        row("pri_note") = Me.Note
        If Me.UnitPrice <> 0 Then
          row("pri_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("pri_unitprice") = ""
        End If
        If Me.OrderedQty <> Decimal.MinValue And Me.OrderedQty <> 0 Then
          'row("OrderedQty") = Configuration.FormatToString(Me.OrderedQty / Me.Conversion, DigitConfig.Qty)
          row("OrderedQty") = Configuration.FormatToString(Me.OrderedQty, DigitConfig.Qty)
        Else
          row("OrderedQty") = DBNull.Value
        End If
        Me.Pr.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Function GetOrderedQty() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.Pr.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetOrderedQty" _
      , New SqlParameter("@pr_id", Me.Pr.Id) _
      , New SqlParameter("@entity_id", Me.Entity.Id) _
      , New SqlParameter("@linenumber", Me.LineNumber) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        If IsNumeric(ds.Tables(0).Rows(0)("pri_orderedqty")) Then
          Return CDec(ds.Tables(0).Rows(0)("pri_orderedqty"))
        End If
      End If
    End Function
    Public Function GetWithdrawnQty() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.Pr.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetWithdrawnQty" _
      , New SqlParameter("@pr_id", Me.Pr.Id) _
      , New SqlParameter("@entity_id", Me.Entity.Id) _
      , New SqlParameter("@linenumber", Me.LineNumber) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        If IsNumeric(ds.Tables(0).Rows(0)("pri_withdrawnqty")) Then
          Return CDec(ds.Tables(0).Rows(0)("pri_withdrawnqty"))
        End If
      End If
    End Function
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

    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'If TypeOf sender Is WBSDistribute Then
      '  Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
      '  Select Case e.Name.ToLower
      '    Case "percent"
      '      If Not Me.m_pr Is Nothing Then
      '        Me.m_pr.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
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
      '      Me.m_pr.SetActual(oldWBS, wbsd.TransferAmount, 0, Me.ItemType.Value)
      '      Me.m_pr.SetActual(newWBS, 0, wbsd.TransferAmount, Me.ItemType.Value)
      '  End Select
      'End If
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            If Not Me.m_pr Is Nothing Then

              'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "amount"
            If Not Me.m_pr Is Nothing Then

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
              'Case 289
              '  wbsd.BudgetAmount = newWBS.GetTotalLabFromDB 'GetTotalMatFromDB
              '  wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
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
            wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.Pr.Id, Me.Pr.EntityId, Me.ItemType.Value)
            wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.Pr.Id, Me.Pr.EntityId, Me.Entity.Id, _
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
        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, ItemType.Value)
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
	Public Class PRItemCollection
		Inherits CollectionBase

#Region "Members"
		Private m_pr As PR
		Private m_currentItem As PRItem
#End Region

#Region "Constructors"
		Public Sub New(ByVal owner As PR)
			Me.m_pr = owner
			If Not Me.m_pr.Originated Then
				Return
			End If


			Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


			Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
			, CommandType.StoredProcedure _
			, "GetPRItems" _
			, New SqlParameter("@pr_id", Me.m_pr.Id) _
			)

			For Each row As DataRow In ds.Tables(0).Rows
				Dim item As New PRItem(row, "")
				item.Pr = m_pr
				Me.Add(item)
				Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
				AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
				item.WBSDistributeCollection = wbsdColl
				If ds.Tables.Count > 1 Then
					For Each wbsRow As DataRow In ds.Tables(1).Select("priw_prilinenumber=" & item.LineNumber)
						Dim wbsd As New WBSDistribute(wbsRow, "")
						wbsdColl.Add(wbsd)
					Next
				End If
			Next
      'RefreshBudget()
		End Sub
		Private Sub RefreshBudget()
			For Each item As PRItem In Me
				Dim transferAmt As Decimal = item.Amount
				For Each wbsd As WBSDistribute In item.WBSDistributeCollection
					'--------------------------------------------------
					wbsd.BaseCost = transferAmt
					wbsd.TransferBaseCost = transferAmt
					If Not wbsd.IsMarkup Then
						'เป็น WBS
						Dim actual As Decimal = 0
						Dim budget As Decimal = 0
						Dim current As Decimal = 0
						Dim budgetQty As Decimal = 0
						Dim actualQty As Decimal = 0
						Dim currentQty As Decimal = 0

						Dim theName As String = item.EntityName
						If theName Is Nothing Then
							theName = item.Entity.Name
						End If
						Select Case item.ItemType.Value
							Case 0						 'อื่นๆ
								actual = wbsd.WBS.GetActualMat(item.Pr, 7)
								budget = wbsd.WBS.GetTotalMatFromDB

								budgetQty = wbsd.WBS.GetBudgetQtyForType0FromDB(theName)
								actualQty = wbsd.WBS.GetActualType0Qty(item.Pr, 7)
							Case 19						 'Tool
								actual = wbsd.WBS.GetActualMat(item.Pr, 7)
								budget = wbsd.WBS.GetTotalMatFromDB

								budgetQty = 0							 'ไม่มี budget ให้เครื่องมือแน่ๆ
								actualQty = wbsd.WBS.GetActualMatQty(item.Pr, 7, item.Entity.Id, 19)
							Case 42						 'Mat
								actual = wbsd.WBS.GetActualMat(item.Pr, 7)
								budget = wbsd.WBS.GetTotalMatFromDB

								budgetQty = wbsd.WBS.GetTotalMatQtyFromDB(item.Entity.Id)
								actualQty = wbsd.WBS.GetActualMatQty(item.Pr, 7, item.Entity.Id, 42)
							Case 88						 'Lab
								actual = wbsd.WBS.GetActualLab(item.Pr, 7)
								budget = wbsd.WBS.GetTotalLabFromDB

								budgetQty = wbsd.WBS.GetTotalLabQtyFromDB(theName)
								actualQty = wbsd.WBS.GetActualLabQty(item.Pr, 7)
							Case 89						 'Eq
								actual = wbsd.WBS.GetActualEq(item.Pr, 7)
								budget = wbsd.WBS.GetTotalEQFromDB

								budgetQty = wbsd.WBS.GetTotalEQQtyFromDB(theName)
								actualQty = wbsd.WBS.GetActualEqQty(item.Pr, 7)
						End Select

						Dim theHash As Hashtable
						Select Case item.ItemType.Value
							Case 0, 19, 42
								theHash = item.Pr.MatActualHash
							Case 88
								theHash = item.Pr.LabActualHash
							Case 89
								theHash = item.Pr.EQActualHash
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
						'เป็น markup
						Dim mk As New Markup(wbsd.WBS.Id)
						If Not mk Is Nothing Then
							wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.Pr, 7) - item.Pr.GetCurrentAmountForMarkup(mk)
						End If
					End If
					'--------------------------------------------------
				Next
			Next
		End Sub
#End Region

#Region "Properties"
		Default Public Property Item(ByVal index As Integer) As PRItem
			Get
				Return CType(MyBase.List.Item(index), PRItem)
			End Get
			Set(ByVal value As PRItem)
				MyBase.List.Item(index) = value
			End Set
		End Property
		Public ReadOnly Property Amount() As Decimal
			Get
				Dim amt As Decimal = 0				For Each item As PRItem In Me
					amt += Configuration.Format(item.Amount, DigitConfig.Price)
				Next
				Return amt
			End Get
		End Property
		Public Property CurrentItem() As PRItem
			Get
				Return m_currentItem
			End Get
			Set(ByVal Value As PRItem)
				m_currentItem = Value
			End Set
		End Property
#End Region

#Region "Shared"
		Public Shared Function CreateListTableStyle() As DataGridTableStyle
			Dim dst As New DataGridTableStyle
			dst.MappingName = "PRItems"

			Dim csSelected As New DataGridCheckBoxColumn
			csSelected.MappingName = "Selected"
			csSelected.HeaderText = ""

			Dim csDescription As New PlusMinusTreeTextColumn
			csDescription.MappingName = "Entity"
			csDescription.HeaderText = "Entity"
			csDescription.NullText = ""
			csDescription.Width = 180
			csDescription.ReadOnly = True

			Dim csQty As New TreeTextColumn
			csQty.MappingName = "Qty"
			csQty.HeaderText = "Qty"
			csQty.NullText = ""
			csQty.ReadOnly = True

			Dim csOrderedQty As New TreeTextColumn
			csOrderedQty.MappingName = "OrderedQty"
			csOrderedQty.HeaderText = "OrderedQty"
			csOrderedQty.NullText = ""
			csOrderedQty.ReadOnly = True

			Dim csDate As New TreeTextColumn
			csDate.MappingName = "DummyDate"
			csDate.HeaderText = "Date"
			csDate.NullText = ""
			csDate.DataAlignment = HorizontalAlignment.Center
			csDate.Width = 100
			csDate.Format = "d"
			csDate.ReadOnly = True

			Dim csReceivingDate As New TreeTextColumn
			csReceivingDate.MappingName = "DummyReceivingDate"
			csReceivingDate.HeaderText = "ReceivingDate"
			csReceivingDate.NullText = ""
			csReceivingDate.DataAlignment = HorizontalAlignment.Center
			csReceivingDate.Width = 100
			csReceivingDate.Format = "d"
			csReceivingDate.ReadOnly = True

			Dim csRequestor As New TreeTextColumn
			csRequestor.MappingName = "Requestor"
			csRequestor.HeaderText = "Requestor"
			csRequestor.NullText = ""
			csRequestor.DataAlignment = HorizontalAlignment.Center
			csRequestor.Width = 100
			csRequestor.ReadOnly = True

			Dim csCostCenter As New TreeTextColumn
			csCostCenter.MappingName = "CostCenter"
			csCostCenter.HeaderText = "CostCenter"
			csCostCenter.NullText = ""
			csCostCenter.DataAlignment = HorizontalAlignment.Center
			csCostCenter.Width = 100
			csCostCenter.ReadOnly = True

			dst.GridColumnStyles.Add(csSelected)
			dst.GridColumnStyles.Add(csDescription)
			dst.GridColumnStyles.Add(csQty)
			dst.GridColumnStyles.Add(csOrderedQty)
			dst.GridColumnStyles.Add(csDate)
			dst.GridColumnStyles.Add(csReceivingDate)
			'dst.GridColumnStyles.Add(csRequestor)
			'dst.GridColumnStyles.Add(csCostCenter)
			Return dst
		End Function
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

			For Each tableRow As DataRow In dt.Rows
				Dim pri As New PRItem(tableRow, "")
				Dim row As TreeRow = myDatatable.Childs.Add
				row("Selected") = False
				row("Code") = tableRow("pr_code")
				row("m_pr") = tableRow("pri_pr")
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
			Next
			Return myDatatable
		End Function
#End Region

#Region "Class Methods"
		Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
			For i As Integer = 0 To items.Count - 1
				If Not TypeOf items(i) Is StockBasketItem Then
					'-----------------LCI Items--------------------

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

						Case "longkong.pojjaman.businesslogic.tool"
							newItem = New Tool(item.Id)
							newType = 19

					End Select

					Dim doc As New PRItem
					If Not Me.CurrentItem Is Nothing Then
						doc = Me.CurrentItem
						doc.ItemType.Value = newType
						Me.CurrentItem = Nothing
					Else
						Me.Add(doc)
						doc.ItemType = New itemType(newType)
					End If
					doc.SetItemPrice(newItem.Code)
					doc.SetItemCode(newItem.Code)
				ElseIf TypeOf items(i).Tag Is BoqItem Then
					'-----------------BOQ Items--------------------
					Dim bitem As BoqItem = CType(items(i).Tag, BoqItem)
					If bitem.ItemType.Value = 18 Then					'ค่าแรง
						bitem.ItemType.Value = 88
						bitem.Entity.Id = 0
					End If
					If bitem.ItemType.Value = 20 Then					'ค่าเครื่องจักร
						bitem.ItemType.Value = 89
						bitem.Entity.Id = 0
					End If

					Dim matWbsd As New WBSDistribute
					Dim labWbsd As New WBSDistribute
					Dim eqWbsd As New WBSDistribute

					Dim matDoc As PRItem
					Dim labDoc As PRItem
					Dim eqDoc As PRItem
					Dim itemType As Integer
					itemType = bitem.ItemType.Value
					Select Case bitem.ItemType.Value
						Case 42, 0
							If bitem.UMC <> 0 Then							'mat
								matDoc = New PRItem
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
									matWbsd.CostCenter = Me.m_pr.CostCenter
									matWbsd.WBS = bitem.WBS
									matWbsd.Percent = 100
									matWbsd.BaseCost = bitem.TotalMaterialCost
									matWbsd.TransferBaseCost = bitem.TotalMaterialCost
									matWbsd.IsOutWard = False
									matWbsd.Toaccttype = 3
								End If
							End If
							If bitem.ULC <> 0 Then							'88 -> Lab
								labDoc = New PRItem
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
									labWbsd.CostCenter = Me.m_pr.CostCenter
									labWbsd.WBS = bitem.WBS
									labWbsd.Percent = 100
									labWbsd.BaseCost = bitem.TotalLaborCost
									labWbsd.TransferBaseCost = bitem.TotalLaborCost
									labWbsd.IsOutWard = False
									labWbsd.Toaccttype = 3
								End If
							End If
							If bitem.UEC <> 0 Then							'89 -> EQ
								eqDoc = New PRItem
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
									eqWbsd.CostCenter = Me.m_pr.CostCenter
									eqWbsd.WBS = bitem.WBS
									eqWbsd.Percent = 100
									eqWbsd.BaseCost = bitem.TotalEquipmentCost
									eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
									eqWbsd.IsOutWard = False
									eqWbsd.Toaccttype = 3
								End If
							End If
						Case 88, 89
							Dim doc As PRItem
							Dim tempUnitPrice As Decimal
							If Me.Count = 0 Then
								If bitem.ItemType.Value = 88 Then
									labDoc = New PRItem
									doc = labDoc
									tempUnitPrice = bitem.ULC
								End If
								If bitem.ItemType.Value = 89 Then
									eqDoc = New PRItem
									doc = eqDoc
									tempUnitPrice = bitem.UEC
								End If
								Me.Add(doc)
							Else
								If bitem.ItemType.Value = 88 Then
									labDoc = New PRItem
									If Not Me.CurrentItem Is Nothing Then
										labDoc = Me.CurrentItem
									Else
										Me.Add(labDoc)
									End If
									doc = labDoc
									tempUnitPrice = bitem.ULC
								End If
								If bitem.ItemType.Value = 89 Then
									eqDoc = New PRItem
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
									labWbsd.CostCenter = Me.m_pr.CostCenter
									labWbsd.WBS = bitem.WBS
									labWbsd.Percent = 100
									labWbsd.BaseCost = bitem.TotalLaborCost
									labWbsd.TransferBaseCost = bitem.TotalLaborCost
									labWbsd.IsOutWard = False
									labWbsd.Toaccttype = 3
								End If
							End If
							If bitem.ItemType.Value = 89 Then
								If Not bitem.WBS Is Nothing Then
									eqWbsd.IsMarkup = False
									eqWbsd.CostCenter = Me.m_pr.CostCenter
									eqWbsd.WBS = bitem.WBS
									eqWbsd.Percent = 100
									eqWbsd.BaseCost = bitem.TotalEquipmentCost
									eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
									eqWbsd.IsOutWard = False
									eqWbsd.Toaccttype = 3
								End If
							End If
					End Select

					If matWbsd.Percent = 100 Then
						If Not matDoc Is Nothing Then
							matDoc.WBSDistributeCollection.Add(matWbsd)
							matDoc.Pr.SetActual(matWbsd.WBS, 0, matDoc.Amount, matDoc.ItemType.Value)
						End If
					End If
					If labWbsd.Percent = 100 Then
						If Not labDoc Is Nothing Then
							labDoc.WBSDistributeCollection.Add(labWbsd)
							labDoc.Pr.SetActual(labWbsd.WBS, 0, labDoc.Amount, labDoc.ItemType.Value)
						End If
					End If
					If eqWbsd.Percent = 100 Then
						If Not eqDoc Is Nothing Then
							eqDoc.WBSDistributeCollection.Add(eqWbsd)
							eqDoc.Pr.SetActual(eqWbsd.WBS, 0, eqDoc.Amount, eqDoc.ItemType.Value)
						End If
					End If

				End If
			Next
			RefreshBudget()
		End Sub
		Public Sub Populate(ByVal dt As TreeTable)
			dt.Clear()
			Dim i As Integer = 0
			For Each pri As PRItem In Me
				i += 1
				Dim newRow As TreeRow = dt.Childs.Add()
				pri.CopyToDataRow(newRow)
				pri.ItemValidateRow(newRow)
				newRow.Tag = pri
			Next
		End Sub
		Public Function CreateTableStyle() As DataGridTableStyle
			Dim dst As New DataGridTableStyle
			dst.MappingName = "PRItems"

			Dim csSelected As New DataGridCheckBoxColumn
			csSelected.MappingName = "Selected"
			csSelected.HeaderText = ""

			Dim csDescription As New PlusMinusColumn
			csDescription.MappingName = "Entity"
			csDescription.HeaderText = "Entity"
			csDescription.NullText = ""
			csDescription.Width = 180

			Dim csQty As New HeaderAndDataAlignColumn
			csQty.MappingName = "Qty"
			csQty.HeaderText = "Qty"
			csQty.NullText = ""

			Dim csDate As New HeaderAndDataAlignColumn
			csDate.MappingName = "Date"
			csDate.HeaderText = "Date"
			csDate.NullText = ""
			csDate.DataAlignment = HorizontalAlignment.Center
			csDate.Width = 100
			csDate.Format = "d"


			Dim csRequestor As New HeaderAndDataAlignColumn
			csRequestor.MappingName = "Requestor"
			csRequestor.HeaderText = "Requestor"
			csRequestor.NullText = ""
			csRequestor.DataAlignment = HorizontalAlignment.Center
			csRequestor.Width = 100

			Dim csCostCenter As New HeaderAndDataAlignColumn
			csCostCenter.MappingName = "CostCenter"
			csCostCenter.HeaderText = "CostCenter"
			csCostCenter.NullText = ""
			csCostCenter.DataAlignment = HorizontalAlignment.Center
			csCostCenter.Width = 100


			dst.GridColumnStyles.Add(csSelected)
			dst.GridColumnStyles.Add(csDescription)
			dst.GridColumnStyles.Add(csQty)
			dst.GridColumnStyles.Add(csDate)
			dst.GridColumnStyles.Add(csRequestor)
			dst.GridColumnStyles.Add(csCostCenter)
			Return dst
		End Function
		Public Function GetDataTable() As ExpandableRowDataTable
			Dim myDatatable As New ExpandableRowDataTable("PRItems")
			myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
			myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("m_pr", GetType(Integer)))
			myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("Qty", GetType(Decimal)))
			myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
			myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("SortIndex", GetType(Decimal)))

			For Each item As PRItem In Me.List
				Dim row As ExpandableDataRow = myDatatable.Add(item.Pr.Code & item.LineNumber)
				row("Selected") = False
				row("Code") = item.Pr.Code
				row("m_pr") = item.Pr.Id
				row("Linenumber") = item.LineNumber
				row("Date") = item.Pr.DocDate
				Dim entityText As String = ""
				If Not item.ItemType Is Nothing Then
					entityText &= item.ItemType.Description & ":"
				End If
				If Not item.Entity.Code Is Nothing AndAlso item.Entity.Code.Length > 0 Then
					entityText &= item.Entity.Code & ":"
				End If
				If Not item.Entity.Name Is Nothing AndAlso item.Entity.Name.Length > 0 Then
					entityText &= item.Entity.Name
				End If
				row("Entity") = entityText
				row("Qty") = item.Qty
				row("Requestor") = item.Pr.Requestor.Code & ":" & item.Pr.Requestor.Name
				row("CostCenter") = item.Pr.CostCenter.Code & ":" & item.Pr.CostCenter.Name
				row.State = PlusMinusState.UnderParent
			Next
			Return myDatatable
		End Function
#End Region

#Region "Collection Methods"
		Public Function Add(ByVal value As PRItem) As Integer
			If Not m_pr Is Nothing Then
				value.Pr = m_pr
			End If
			Return MyBase.List.Add(value)
		End Function
		Public Sub AddRange(ByVal value As PRItemCollection)
			For i As Integer = 0 To value.Count - 1
				Me.Add(value(i))
			Next
		End Sub
		Public Sub AddRange(ByVal value As PRItem())
			For i As Integer = 0 To value.Length - 1
				Me.Add(value(i))
			Next
		End Sub
		Public Function Contains(ByVal value As PRItem) As Boolean
			Return MyBase.List.Contains(value)
		End Function
		Public Sub CopyTo(ByVal array As PRItem(), ByVal index As Integer)
			MyBase.List.CopyTo(array, index)
		End Sub
		Public Shadows Function GetEnumerator() As PRItemEnumerator
			Return New PRItemEnumerator(Me)
		End Function
		Public Function IndexOf(ByVal value As PRItem) As Integer
			Return MyBase.List.IndexOf(value)
		End Function
		Public Sub Insert(ByVal index As Integer, ByVal value As PRItem)
			If Not m_pr Is Nothing Then
				value.Pr = m_pr
			End If
			MyBase.List.Insert(index, value)
		End Sub
		Public Sub Remove(ByVal value As PRItem)
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
#End Region


		Public Class PRItemEnumerator
			Implements IEnumerator

#Region "Members"
			Private m_baseEnumerator As IEnumerator
			Private m_temp As IEnumerable
#End Region

#Region "Construtor"
			Public Sub New(ByVal mappings As PRItemCollection)
				Me.m_temp = mappings
				Me.m_baseEnumerator = Me.m_temp.GetEnumerator
			End Sub
#End Region

			Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
				Get
					Return CType(Me.m_baseEnumerator.Current, PRItem)
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

