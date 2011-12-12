Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class PAIItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pai_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Class PAItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_pa As PA
    Private m_sc As SC
    Private m_lineNumber As Integer
    Private m_itemType As PAIItemType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Private m_originQty As Decimal
    Private m_originAmt As Decimal
    Private m_qty As Decimal
    Private m_unitPrice As Decimal
    Private m_mat As Decimal
    Private m_lab As Decimal
    Private m_eq As Decimal
    Private m_receiveAmount As Decimal
    Private m_unitcost As Decimal
    Private m_account As Account
    Private m_labaccount As Account
    Private m_eqaccount As Account
    Private m_note As String
    Private m_qtyCostAmount As Decimal
    Private m_costAmount As Decimal
    Private m_receivedQty As Decimal
    Private m_receivedAmount As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")
    Private m_conversion As Decimal = 1
    Private m_level As Integer
    Private m_sequence As Decimal
    Private m_refSequence As Decimal
    Private m_refDoc As Decimal
    Private m_refDocType As Decimal
    Private m_refEntity As IHasName
    Private m_parent As Decimal
    Private m_budgetConversion As Decimal
    Private m_hasChild As Boolean
    Private m_hasSCChild As Boolean
    Private m_isReferenceSC As Boolean

    Private m_totalBudget As Decimal
    Private m_totalReceived As Decimal
    Private m_totalProgressReceive As Decimal
    Private m_totalchildAmount As Decimal
    Private m_totalmat As Decimal
    Private m_totallab As Decimal
    Private m_totaleq As Decimal

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
        If dr.Table.Columns.Contains(aliasPrefix & "pai_refdocType") AndAlso Not dr.IsNull("pai_refdocType") Then
          m_refEntity = New RefEntity
          m_refEntity.Id = CInt(dr(aliasPrefix & "pai_refdocType"))
          m_refEntity.Name = CStr(dr(aliasPrefix & "pai_refDocTypeName"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_pa") AndAlso Not dr.IsNull("pai_pa") Then
          Me.m_pa = New PA(CInt(dr("pai_pa")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_sc") AndAlso Not dr.IsNull("pai_sc") Then
          Me.m_sc = New SC(CInt(dr("pai_sc")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_sequence") AndAlso Not dr.IsNull(aliasPrefix & "pai_sequence") Then
          .m_sequence = CDec(dr("pai_sequence"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_refsequence") AndAlso Not dr.IsNull(aliasPrefix & "pai_refsequence") Then
          .m_refSequence = CDec(dr("pai_refsequence"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "ReferenceSC") AndAlso Not dr.IsNull(aliasPrefix & "ReferenceSC") Then
          .m_isReferenceSC = CBool(dr("ReferenceSC"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_level") AndAlso Not dr.IsNull(aliasPrefix & "pai_level") Then
          .m_level = CInt(dr("pai_level"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_refdoc") AndAlso Not dr.IsNull(aliasPrefix & "pai_refdoc") Then
          .m_refDoc = CDec(dr("pai_refdoc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_refdocType") AndAlso Not dr.IsNull(aliasPrefix & "pai_refdocType") Then
          .m_refDocType = CDec(dr("pai_refdocType"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_parent") AndAlso Not dr.IsNull(aliasPrefix & "pai_parent") Then
          .m_parent = CDec(dr("pai_parent"))
        End If

        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "pai_entity") AndAlso Not dr.IsNull(aliasPrefix & "pai_entity") Then
          itemId = CInt(dr(aliasPrefix & "pai_entity"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_itemName") AndAlso Not dr.IsNull(aliasPrefix & "pai_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "pai_itemName"))
        Else
          .m_entityName = ""
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_entityType") AndAlso Not dr.IsNull(aliasPrefix & "pai_entityType") Then
          .m_itemType = New PAIItemType(CInt(dr(aliasPrefix & "pai_entityType")))

          Select Case .m_itemType.Value
            Case 42     '"lci"
              .m_entity = LCIItem.GetLciItemById(itemId)
              If CType(.m_entity, LCIItem).Account IsNot Nothing Then
                .m_account = CType(.m_entity, LCIItem).Account
              End If
              'If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              '  If Not dr.IsNull("lci_id") Then
              '    .m_entity = New LCIItem(dr, "")
              '  End If
              'Else
              '  .m_entity = New LCIItem(itemId)
              'End If
            Case 19     '"tool"
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
            Case Else     '0, 28, 88, 89, 160, 162, 291
              .m_entity = New BlankItem(.m_entityName)
          End Select
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "pai_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "pai_lineNumber"))
        End If


        If dr.Table.Columns.Contains(aliasPrefix & "pai_progressAmt") AndAlso Not dr.IsNull(aliasPrefix & "pai_progressAmt") Then
          .m_totalProgressReceive = CInt(dr(aliasPrefix & "pai_progressAmt"))
        End If


        'If dr.Table.Columns.Contains(aliasPrefix & "pai_originqty") AndAlso Not dr.IsNull(aliasPrefix & "pai_originqty") Then
        '    .m_originQty = CDec(dr(aliasPrefix & "pai_originqty"))
        'End If
        'If dr.Table.Columns.Contains(aliasPrefix & "pai_originamt") AndAlso Not dr.IsNull(aliasPrefix & "pai_originamt") Then
        '    .m_originAmt = CDec(dr(aliasPrefix & "pai_originamt"))
        'End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "pai_unit") AndAlso Not dr.IsNull(aliasPrefix & "pai_unit") Then
            '.m_unit = New Unit(CInt(dr(aliasPrefix & "pai_unit")))
            .m_unit = Unit.GetUnitById(CInt(dr(aliasPrefix & "pai_unit")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_qty") AndAlso Not dr.IsNull(aliasPrefix & "pai_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "pai_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "pai_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "pai_unitprice"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "pai_amt") AndAlso Not dr.IsNull(aliasPrefix & "pai_amt") Then
        '  .m_amount = CDec(dr(aliasPrefix & "pai_amt"))
        'End If

        If dr.Table.Columns.Contains(aliasPrefix & "QtyCostAmount") AndAlso Not dr.IsNull(aliasPrefix & "QtyCostAmount") Then
          .m_qtyCostAmount = CDec(dr(aliasPrefix & "QtyCostAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "CostAmount") AndAlso Not dr.IsNull(aliasPrefix & "CostAmount") Then
          .m_costAmount = CDec(dr(aliasPrefix & "CostAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "receivedQty") AndAlso Not dr.IsNull(aliasPrefix & "receivedQty") Then
          .m_receivedQty = CDec(dr(aliasPrefix & "receivedQty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "receivedAmount") AndAlso Not dr.IsNull(aliasPrefix & "receivedAmount") Then
          .m_receivedAmount = CDec(dr(aliasPrefix & "receivedAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "budgetconversion") AndAlso Not dr.IsNull(aliasPrefix & "budgetconversion") Then
          .m_budgetConversion = CDec(dr(aliasPrefix & "budgetconversion"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_mat") AndAlso Not dr.IsNull(aliasPrefix & "pai_mat") Then
          .m_mat = CDec(dr(aliasPrefix & "pai_mat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_lab") AndAlso Not dr.IsNull(aliasPrefix & "pai_lab") Then
          .m_lab = CDec(dr(aliasPrefix & "pai_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_eq") AndAlso Not dr.IsNull(aliasPrefix & "pai_eq") Then
          .m_eq = CDec(dr(aliasPrefix & "pai_eq"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_amt") AndAlso Not dr.IsNull(aliasPrefix & "pai_amt") Then
          .m_receiveAmount = CDec(dr(aliasPrefix & "pai_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pai_unitCost") AndAlso Not dr.IsNull(aliasPrefix & "pai_unitCost") Then
          .m_unitcost = CDec(dr(aliasPrefix & "pai_unitCost"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_acct") AndAlso Not dr.IsNull(aliasPrefix & "pai_acct") Then
          .m_account = New Account(CInt(dr(aliasPrefix & "pai_acct")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_labacct") AndAlso Not dr.IsNull(aliasPrefix & "pai_labacct") Then
          .m_labaccount = New Account(CInt(dr(aliasPrefix & "pai_labacct")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_eqacct") AndAlso Not dr.IsNull(aliasPrefix & "pai_eqacct") Then
          .m_eqaccount = New Account(CInt(dr(aliasPrefix & "pai_eqacct")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_note") AndAlso Not dr.IsNull(aliasPrefix & "pai_note") Then
          .m_note = CStr(dr(aliasPrefix & "pai_note"))
        End If


        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            'Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              'Me.Conversion = lci.GetConversion(Me.Unit)
              Me.Conversion = CType(Me.Entity, LCIItem).GetConversion(Me.Unit)
            Catch ex As NoConversionException
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              If Not msgServ Is Nothing Then
                msgServ.ShowErrorFormatted("วัสดุ {0} ไม่มีหน่วยนับ {1} ระบุไว้", New String() {ex.Lci.Code, ex.Unit.Name})
              End If
            End Try
          Else
            Me.Conversion = 1
            If itemId > 0 Then
              If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
                If Not dr.IsNull("lci_id") Then
                  .m_conversion = CType(.m_entity, LCIItem).GetConversion(Me.Unit)
                End If
              End If
            End If
          End If
        End If

        'If dr.Table.Columns.Contains(aliasPrefix & "pai_discrate") AndAlso Not dr.IsNull(aliasPrefix & "pai_discrate") Then
        '    .m_discount = New Discount(CStr(dr(aliasPrefix & "pai_discrate")))
        'End If

        If dr.Table.Columns.Contains(aliasPrefix & "pai_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "pai_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "pai_unvatable"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "haschild") AndAlso Not dr.IsNull(aliasPrefix & "haschild") Then
          .m_hasChild = CBool(dr(aliasPrefix & "haschild"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property MatAccount() As Account      Get
        If Me.Sequence = 0 Then
        If TypeOf Me.Entity Is LCIItem Then
          Dim lci As LCIItem = CType(Me.Entity, LCIItem)
          Me.m_account = lci.Account
        ElseIf TypeOf Me.Entity Is Tool Then
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOther)
          Me.m_account = ga.Account
            'ElseIf TypeOf Me.Entity Is BlankItem AndAlso Me.ItemType.Value = 0 Then
            '  Return Me.m_account
        Else
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherExpense)
          Me.m_account = ga.Account
        End If
        End If

        Return Me.m_account
      End Get
      Set(ByVal Value As Account)
        Me.Pa.OnGlChanged()
        m_account = Value
      End Set
    End Property
    Public Property LabAccount() As Account
      Get
        If m_labaccount Is Nothing OrElse Not m_labaccount.Originated Then
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.SalaryWage)
          m_labaccount = ga.Account
        End If
        If Me.ItemType.Value = 291 Then
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.SCPenalty)
          m_labaccount = ga.Account
        End If
        Return m_labaccount
      End Get
      Set(ByVal Value As Account)
        Me.Pa.OnGlChanged()
        m_labaccount = Value
      End Set
    End Property
    Public Property EqAccount() As Account
      Get
        If m_eqaccount Is Nothing OrElse Not m_eqaccount.Originated Then
          Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherExpense)
          m_eqaccount = ga.Account
        End If
        Return m_eqaccount
      End Get
      Set(ByVal Value As Account)
        Me.Pa.OnGlChanged()
        m_eqaccount = Value
      End Set
    End Property
    Public Property RefEntity() As IHasName
      Get
        Return m_refEntity
      End Get
      Set(ByVal Value As IHasName)
        m_refEntity = Value
      End Set
    End Property
    Public ReadOnly Property Sequence() As Decimal
      Get
        Return m_sequence
      End Get
    End Property
    Public Property RefSequence() As Decimal
      Get
        'Select Case Me.RefEntity.Id
        '  Case 289 'sc
        '    m_refSequence = Me.SCitem.Sequence
        '  Case 290 'vo
        '    m_refSequence = Me.VOitem.Sequence
        '  Case 291 'dr
        '    m_refSequence = Me.DRitem.Sequence
        '  Case Else
        '    m_refSequence = 0
        'End Select
        Return m_refSequence
      End Get
      Set(ByVal Value As Decimal)        m_refSequence = Value      End Set
    End Property
    Public Property RefDoc() As Decimal
      Get
        'Select Case Me.RefEntity.Id
        '  Case 289 'sc
        '    m_refDoc = Me.SCitem.SC.Id
        '  Case 290 'vo
        '    m_refDoc = Me.VOitem.VO.Id
        '  Case 291 'dr
        '    m_refDoc = Me.DRitem.Dr.Id
        '  Case Else
        '    m_refDoc = 0
        'End Select
        Return m_refDoc
      End Get
      Set(ByVal Value As Decimal)        m_refDoc = Value      End Set
    End Property
    Public Property RefDocType() As Decimal
      Get
        'Select Case Me.RefEntity.Id
        '  Case 289 'sc
        '    m_refDocType = Me.SCitem.SC.EntityId
        '  Case 290 'vo
        '    m_refDocType = Me.VOitem.VO.EntityId
        '  Case 291 'dr
        '    m_refDocType = Me.DRitem.Dr.EntityId
        '  Case Else
        '    m_refDocType = 0
        'End Select
        Return m_refDocType
      End Get
      Set(ByVal Value As Decimal)        m_refDocType = Value      End Set
    End Property 'm_refDocType
    Public Property Pa() As PA
      Get        Return m_pa      End Get      Set(ByVal Value As PA)
        m_pa = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Level() As Integer      Get        Return m_level      End Get      Set(ByVal Value As Integer)        m_level = Value      End Set    End Property    'Public Property Description() As String    '  Get    '    Return m_description    '  End Get    '  Set(ByVal Value As String)    '    m_description = Value    '  End Set    'End Property    'Public Property SCitem() As SCitem    '  Get    '    Return m_scItem    '  End Get    '  Set(ByVal Value As SCitem)    '    m_scItem = Value    '  End Set    'End Property    'Public Property VOitem() As VOitem    '  Get    '    Return m_voItem    '  End Get    '  Set(ByVal Value As VOitem)    '    m_voItem = Value    '  End Set    'End Property    'Public Property DRitem() As DRitem    '  Get    '    Return m_dritem    '  End Get    '  Set(ByVal Value As DRitem)    '    m_dritem = Value    '  End Set    'End Property    Public Property ItemType() As PAIItemType
      Get        Return m_itemType      End Get      Set(ByVal Value As PAIItemType)
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
        'If Not Value.Value = 160 AndAlso Not Value.Value = 162 Then
        If IsHasChild() Then
          msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SCItem.SCItemOnly}")
          Return
        End If
        'End If

        'If msgServ.AskQuestion("${res:Global.Question.ChangePREntityType}") Then
        'Dim oldType As Integer = m_itemType.Value

        Me.Pa.OnGlChanged()
        m_itemType = Value
        'For Each wbsd As WBSDistribute In Me.WBSDistributeCollection        '	Dim bfTax As Decimal = 0
        '	'If Not Me.Pa Is Nothing Then 'AndAlso item.Po.Originated
        '	'    If Me.Pa.Closed Then
        '	'        bfTax = Me.ReceivedBeforeTax
        '	'    Else
        '	'        bfTax = Me.BeforeTax
        '	'    End If
        '	'End If
        '	Dim transferAmt As Decimal = bfTax
        '	wbsd.BaseCost = bfTax
        '	wbsd.TransferBaseCost = transferAmt        '	Select Case Me.ItemType.Value
        '		Case 0, 19, 42
        '			wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
        '		Case 88
        '			wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
        '		Case 89
        '			wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
        '	End Select
        '	Me.m_pa.SetActual(wbsd.WBS, wbsd.TransferAmount, 0, oldType)
        '	Me.m_pa.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, m_itemType.Value)        'Next
        Me.Clear()
        'End If      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        If Me.Pa Is Nothing Then
          Me.Pa = New PA
        End If
        Me.Pa.OnGlChanged()
        m_entity = Value        If TypeOf m_entity Is IHasUnit Then
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
        Case 160, 162, 289   'Note
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
              Case 2
                unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
                , New SqlParameter("@pai_entity", myTool.Id) _
                , New SqlParameter("@pai_entitytype", myTool.EntityId) _
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
          ElseIf lci.Level <> 5 Then
            msgServ.ShowMessageFormatted("${res:Global.LCI.Level5Only}", New String() {theCode})
            Return
          Else
            Select Case pricing
              Case 0
                unitPrice = lci.FairPrice
              Case 2
                '************************แก้ไข GetPRPriceForSupplier ด้วย
                unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
                , New SqlParameter("@pai_entity", lci.Id) _
                , New SqlParameter("@pai_entitytype", lci.EntityId) _
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
      'Me.ReceivedQty = 0   'UNDONE
    End Sub    Public Sub SetItemPrice(ByVal theCode As String)      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPAPricing"))      Select Case Me.ItemType.Value
        Case 19    'Tool
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim myTool As New Tool(theCode)

          Select Case pricing
            Case 0
              unitPrice = myTool.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetPAPriceForSupplier" _
              , New SqlParameter("@pai_entity", myTool.Id) _
              , New SqlParameter("@pai_entitytype", myTool.EntityId) _
              )
          End Select


          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice

        Case 42, 88, 89    'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim lci As New LCIItem(theCode)

          Select Case pricing
            Case 0
              unitPrice = lci.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetPAPriceForSupplier" _
              , New SqlParameter("@pai_entity", lci.Id) _
              , New SqlParameter("@pai_entitytype", lci.EntityId) _
              )
          End Select
          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice
      End Select
      Me.Qty = 1
      'Me.ReceivedQty = 0   'UNDONE
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
          Case Else     '0, 28, 88, 89, 160, 162, 289
            Me.m_entityName = Value
        End Select      End Set    End Property    Public ReadOnly Property ItemDescription() As String      Get
        If Me.ItemType.Value = 19 OrElse Me.ItemType.Value = 42 OrElse _
           Me.ItemType.Value = 88 OrElse Me.ItemType.Value = 89 Then
          If Me.EntityName.Length > 0 Then
            Return Me.EntityName & "<" & Me.Entity.Name & ">"
          End If
          Return Me.Entity.Name
        Else
          Return Me.EntityName
        End If
      End Get
    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
            'Me.m_unitPrice = (newConversion / oldConversion) * Me.m_unitPrice
            Me.UnitPrice = (Me.UnitPrice / oldConversion) * newConversion
          End If
          m_unit = Value
        Else
          msgServ.ShowMessage(err)
        End If      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        'Dim oldValue As Decimal = Me.m_qty        'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        'If Not IsNumeric(Value) Then
        '  Return
        'End If
        'If Me.ItemType Is Nothing Then
        '  'ไม่มี Type
        '  msgServ.ShowMessage("${res:Global.Error.NoItemType}")
        '  Return
        'End If
        'If Me.ItemType.Value = 160 Or Me.ItemType.Value = 162 Then
        '  'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
        '  msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveQty}")
        '  Return
        'End If        ''รายการเกิดที่หน้า pa เอง ไม่ได้ดึงมาจาก scitem        'If Me.RefEntity.Id > 0 Then        '  If Me.RemainingCost < (Value * Me.UnitPrice) Then        '    'มูลค่ารับงานเกินมูลค่าตามสัญญา        '    msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
        '                New String() {Configuration.FormatToString((Value * Me.UnitPrice), DigitConfig.Price), _
        '                              Configuration.FormatToString(Me.BudgetCostAmount, DigitConfig.Price)})
        '    Return
        '  End If
        'End If        'Select Case Me.ItemType.Value
        '  Case 160, 162
        '    'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
        '    msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
        '    Return
        '  Case 0, 19, 28, 42
        '    Me.m_mat = Value * Me.UnitPrice
        '    Me.m_lab = 0
        '    Me.m_eq = 0
        '  Case 88
        '    Me.m_mat = 0
        '    Me.m_lab = Value * Me.UnitPrice
        '    Me.m_eq = 0
        '  Case 89
        '    Me.m_mat = 0
        '    Me.m_lab = 0
        '    Me.m_eq = Value * Me.UnitPrice
        'End Select        If IsNumeric(Value) Then          m_qty = Configuration.Format(Value, DigitConfig.Qty)
          'm_receiveAmount = m_qty * m_unitPrice
        Else
          m_qty = 0
          'm_receiveAmount = m_qty * m_unitPrice
        End If      End Set    End Property    Public Property OriginQty() As Decimal      Get
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
    End Property    Public ReadOnly Property RemainingQtyCost() As Decimal      Get
        Return Me.ContractQtyCostAmount - Me.ReceivedQty
      End Get
    End Property    Public ReadOnly Property RemainingCost() As Decimal      Get
        Return Me.ContractCostAmount - Me.ReceivedAmount
      End Get
    End Property    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Not IsNumeric(Value) Then
          Return
        End If
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        'รายการเกิดที่หน้า pa เอง ไม่ได้ดึงมาจาก scitem        If Me.RefEntity.Id > 0 Then
          Return
          'If Me.RemainingCost < (Value * Me.Qty) Then          '  'มูลค่ารับงานเกินมูลค่าตามสัญญา          '  msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
          '              New String() {Configuration.FormatToString((Value * Me.Qty), DigitConfig.Price), _
          '                            Configuration.FormatToString(Me.BudgetCostAmount, DigitConfig.Price)})
          '  Return
          'End If
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
            Return
        End Select        Dim amt As Decimal = Value * Me.Qty
        Me.m_mat = 0
        Me.m_lab = 0
        Me.m_eq = 0        'Select Case Me.ItemType.Value
        '  Case 0, 19, 28, 42
        '    Me.m_mat = amt
        '  Case 88, 289
        '    Me.m_lab = amt
        '  Case 89
        '    Me.m_eq = amt
        'End Select        m_unitPrice = Value        m_receiveAmount = amt
        Select Case Me.ItemType.Value
          Case 0, 19, 28, 42
            Me.m_mat = Me.CostAmount
          Case 88, 289
            Me.m_lab = Me.CostAmount
          Case 89
            Me.m_eq = Me.CostAmount
        End Select
      End Set    End Property    Public Property Mat() As Decimal
      Get
        Return m_mat
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 88 OrElse _
            Me.ItemType.Value = 89 Then
          Return
        End If
        Dim m_value As Decimal = Value + Me.Lab + Me.Eq
        If m_value > Me.CostAmount Then ' Me.Amount Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          New String() {Configuration.FormatToString(m_value, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price)})
          Return
        Else
          m_mat = Value
        End If
      End Set
    End Property
    Public Property Lab() As Decimal
      Get
        Return m_lab
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 89 Then
          Return
        End If

        Dim m_value As Decimal = Me.Mat + Value + Me.Eq
        If m_value > Me.CostAmount Then ' Me.Amount Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          New String() {Configuration.FormatToString(m_value, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price)})
          Return
        Else
          m_lab = Value
        End If
      End Set
    End Property
    Public Property Eq() As Decimal
      Get
        Return m_eq
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 88 Then
          Return
        End If
        Dim m_value As Decimal = Me.Mat + Me.Lab + Value
        If m_value > Me.CostAmount Then ' Me.Amount Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          New String() {Configuration.FormatToString(m_value, DigitConfig.Price), Configuration.FormatToString(Me.Amount, DigitConfig.Price)})
          Return
        Else
          m_eq = Value
        End If
      End Set
    End Property    Public ReadOnly Property AmountWithDefaultUnit() As Decimal
      Get
        If StockQty > 0 Then
          If Me.Conversion = 1 Then
            Return m_receiveAmount - Me.Discount.Amount
          End If
          Return ((Me.UnitPrice / Me.Conversion) * StockQty) - (Me.Discount.Amount)
        Else
          Return 0
        End If
      End Get
    End Property    'Public Property Amount() As Decimal    '  Get
    '    Return m_amount
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_originAmt = Value
    '  End Set
    'End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property SC() As SC      Get        Return m_sc      End Get      Set(ByVal Value As SC)        m_sc = Value      End Set    End Property    Public ReadOnly Property ReceivedQty() As Decimal      Get        Return Me.m_receivedQty      End Get    End Property    Public ReadOnly Property ReceivedAmount() As Decimal      Get
        Return Me.m_receivedAmount
      End Get
    End Property    Public ReadOnly Property ContractCostAmount() As Decimal      Get        Return Me.m_costAmount      End Get    End Property    Public ReadOnly Property ContractQtyCostAmount() As Decimal      Get
        Return Me.m_qtyCostAmount * (BudgetConversion / Me.Conversion)
      End Get
    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)      End Get    End Property    Public ReadOnly Property UnitCost() As Decimal
      Get
        If Me.RefEntity.Id = 291 Then
          If Me.StockQty <> 0 Then
            Return Me.Amount / Me.StockQty
          Else
            Return 0
          End If
        End If
        If Me.StockQty <> 0 Then
          Dim tmpCost As Decimal = 0
          Dim tmpRealGrossNoVat As Decimal = 0

          tmpRealGrossNoVat = Me.Pa.RealGrossWithNoDeductItem ' Me.Pa.RealGross

          If tmpRealGrossNoVat = 0 Then
            Return 0
          End If

          tmpCost = Me.AmountWithDefaultUnit

          tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.Pa.Discount.Amount)

          If Me.Pa.TaxType.Value = 2 Then
            If Not Me.UnVatable Then
              tmpCost = tmpCost * (100 / (100 + Me.Pa.TaxRate))
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
    End Property    Public ReadOnly Property CostAmount() As Decimal Implements IWBSAllocatableItem.ItemAmount      Get
        If Me.RefEntity.Id = 291 Then
          Return Me.Amount
        End If
        'Return Me.UnitCost * Me.StockQty
        Dim tmpCost As Decimal = Me.UnitCost * Me.StockQty
        If tmpCost = 0 OrElse (Me.RefDocType = 290 AndAlso Me.Amount < 0) OrElse (Me.RefDocType = 291) OrElse (Me.RefDocType = 289) Then
          tmpCost = Me.ReceiveAmount
          Dim tmpRealGrossNoVat As Decimal = 0
          tmpRealGrossNoVat = Me.Pa.RealGrossWithNoDeductItem

          If tmpRealGrossNoVat = 0 Then
            Return 0
          End If
          tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.Pa.Discount.Amount)

          If Me.Pa.TaxType.Value = 2 Then
            If Not Me.UnVatable Then
              tmpCost = tmpCost * (100 / (100 + Me.Pa.TaxRate))
            End If
          End If
        End If
        Return tmpCost
      End Get
    End Property    Public ReadOnly Property BudgetConversion() As Decimal      Get
        Return m_budgetConversion
      End Get
    End Property    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property    Public Property Discount() As Discount      Get        Dim amtFormatted As Decimal = Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)        m_discount.AmountBeforeDiscount = amtFormatted        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value      End Set    End Property
    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Public ReadOnly Property Amount() As Decimal 'Implements IWBSAllocatableItem.ItemAmount
      Get
        'Dim amtFormatted As Decimal = Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
        'Return amtFormatted - Me.DiscountAmount
        Return Me.ReceiveAmount
      End Get
    End Property
    Private Function ValidateReceiveAmount(ByVal Value As Decimal) As Boolean
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Not Me.RefEntity Is Nothing AndAlso Me.RefEntity.Id > 0 Then
          If Me.HashSCChild Then            'ไม่อนุญาติให้แก้มูลค่ารับงาน ถ้าสัญญานั้นมีรายละเอียด ให้แก้ที่รายละเอียดแทน            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.CanNotChangeContract}")
          Return False
          End If          If Me.RefEntity.Id = 290 OrElse Me.RefEntity.Id = 291 Then          If Me.ContractCostAmount > 0 AndAlso (Value <= 0 OrElse Me.RemainingCost < Value) Then
            'สำหรับ VO+ มูลค่ารับงานต้องมากกว่าศูนย์เสมอ และห้ามมากกว่ามูลค่าค้างรับคงเหลือ
            If Value <= 0 Then
              msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.AdditionValidAmount}")
              Return False
            End If
            msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
                      New String() {Configuration.FormatToString(Value, DigitConfig.Price), _
                                    Configuration.FormatToString(Me.RemainingCost, DigitConfig.Price)})
            Return False
          End If
          If Me.ContractCostAmount < 0 AndAlso (Value > 0 OrElse Me.RemainingCost > Value) Then
            'สำหรับ DR- VO- มูลค่ารับงานต้องน้อยกว่าศูนย์เสมอ และห้ามน้อยเกินมูลค่าค้างรับคงเหลือ
            If Value >= 0 Then
              msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidAmount}")
              Return False
            End If              msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
                        New String() {Configuration.FormatToString(Value, DigitConfig.Price), _
                                      Configuration.FormatToString(Me.RemainingCost, DigitConfig.Price)})
            Return False
            End If
          Else
          If Value <= 0 Then
            msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.AdditionValidAmount}")
            Return False
          End If
            If Me.RemainingCost < Value Then              'มูลค่ารับงานเกินมูลค่าตามสัญญา              msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
                        New String() {Configuration.FormatToString(Value, DigitConfig.Price), _
                                      Configuration.FormatToString(Me.RemainingCost, DigitConfig.Price)})
            Return False
          End If
        End If
      Else 'ถ้าเป็นรายการรับงานเองที่ไม่ได้ดึงมาจาก SC

        End If

      Return True
    End Function
    Public Sub RecalculateReceiveAmount()
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Select Case Me.ItemType.Value
        Case 160, 162
          'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
          Return
      End Select
      Dim m_cost As Decimal = Me.CostAmount
      Select Case Me.ItemType.Value
        Case 0, 19, 28, 42
          Me.m_mat = m_cost 'm_receiveAmount
          Me.m_lab = 0
          Me.m_eq = 0
        Case 88, 291
          Me.m_mat = 0
          Me.m_lab = m_cost 'm_receiveAmount
          Me.m_eq = 0
        Case 89
          Me.m_mat = 0
          Me.m_lab = 0
          Me.m_eq = m_cost 'm_receiveAmount
        Case 289
          Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
          'Me.m_lab = (m_receiveAmount - amt2) + Me.Lab
          Me.m_lab = (m_cost - amt2) + Me.Lab
      End Select
    End Sub
    Public Property ReceiveAmount() As Decimal
      Get
        Return m_receiveAmount
      End Get
      Set(ByVal Value As Decimal)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Value = m_receiveAmount Then
          Return
        End If
        If Value <> 0 Then
          If Not Me.ValidateReceiveAmount(Value) Then
            Return
          End If
        End If

        'If Me.RefEntity.Id > 0 Then
        '  If Me.HashSCChild Then
        '    'ไม่อนุญาติให้แก้มูลค่ารับงาน ถ้าสัญญานั้นมีรายละเอียด ให้แก้ที่รายละเอียดแทน
        '    msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.CanNotChangeContract}")
        '    Return
        '  End If
        '  If Me.RefEntity.Id = 290 OrElse Me.RefEntity.Id = 291 Then
        '    If Me.ContractCostAmount > 0 AndAlso (Value <= 0 OrElse Me.RemainingCost < Value) Then
        '      'สำหรับ VO+ มูลค่ารับงานต้องมากกว่าศูนย์เสมอ และห้ามมากกว่ามูลค่าค้างรับคงเหลือ
        '      If Value <= 0 Then
        '        msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.AdditionValidAmount}")
        '        Return
        '      End If
        '      msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
        '                New String() {Configuration.FormatToString(Value, DigitConfig.Price), _
        '                              Configuration.FormatToString(Me.RemainingCost, DigitConfig.Price)})
        '      Return
        '    End If
        '    If Me.ContractCostAmount < 0 AndAlso (Value > 0 OrElse Me.RemainingCost > Value) Then
        '      'สำหรับ DR- VO- มูลค่ารับงานต้องน้อยกว่าศูนย์เสมอ และห้ามน้อยเกินมูลค่าค้างรับคงเหลือ
        '      If Value >= 0 Then
        '        msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidAmount}")
        '        Return
        '      End If
        '      msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
        '                  New String() {Configuration.FormatToString(Value, DigitConfig.Price), _
        '                                Configuration.FormatToString(Me.RemainingCost, DigitConfig.Price)})
        '      Return
        '    End If
        '  Else
        '    If Value <= 0 Then
        '      msgServ.ShowWarning("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.AdditionValidAmount}")
        '      Return
        '    End If
        '    If Me.RemainingCost < Value Then
        '      'มูลค่ารับงานเกินมูลค่าตามสัญญา
        '      msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ValidBudgetAmount}", _
        '                  New String() {Configuration.FormatToString(Value, DigitConfig.Price), _
        '                                Configuration.FormatToString(Me.RemainingCost, DigitConfig.Price)})
        '      Return
        '    End If
        '  End If
        'Else


        'End If

        m_receiveAmount = Value

        If m_unitPrice <> 0 Then
          m_qty = m_receiveAmount / m_unitPrice
        Else
          m_qty = 0
        End If

        Me.RecalculateReceiveAmount()

        'Select Case Me.ItemType.Value
        '  Case 160, 162
        '    'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
        '    msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
        '    Return
        'End Select

        'Select Case Me.ItemType.Value
        '  Case 0, 19, 28, 42
        '    Me.m_mat = m_receiveAmount
        '    Me.m_lab = 0
        '    Me.m_eq = 0
        '  Case 88
        '    Me.m_mat = 0
        '    Me.m_lab = m_receiveAmount
        '    Me.m_eq = 0
        '  Case 89
        '    Me.m_mat = 0
        '    Me.m_lab = 0
        '    Me.m_eq = m_receiveAmount
        '  Case 289
        '    Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
        '    Me.m_lab = (m_receiveAmount - amt2) + Me.Lab
        'End Select
      End Set
    End Property
    Public ReadOnly Property AmountWithoutFormat() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = (Me.UnitPrice * Me.Qty)
        Return (Me.UnitPrice * Me.Qty) - Me.Discount.Amount
      End Get
    End Property
    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public Property Parent() As Decimal      Get
        Return m_parent
      End Get
      Set(ByVal Value As Decimal)
        m_parent = Value
      End Set
    End Property
    Public Property HasChild() As Boolean
      Get
        Return m_hasChild
      End Get
      Set(ByVal Value As Boolean)
        m_hasChild = Value
      End Set
    End Property
    Public Property HashSCChild() As Boolean
      Get
        Return m_hasSCChild
      End Get
      Set(ByVal Value As Boolean)
        m_hasSCChild = Value
      End Set
    End Property
    Public Property IsReferenceSC() As Boolean
      Get
        Return m_isReferenceSC
      End Get
      Set(ByVal Value As Boolean)
        m_isReferenceSC = Value
      End Set
    End Property
    Public Property TotalBudget() As Decimal
      Get
        Return m_totalBudget
      End Get
      Set(ByVal Value As Decimal)
        m_totalBudget = Value
      End Set
    End Property
    Public Property TotalReceived() As Decimal
      Get
        Return m_totalReceived
      End Get
      Set(ByVal Value As Decimal)
        m_totalReceived = Value
      End Set
    End Property
    Public Property TotalProgressReceive() As Decimal
      Get
        Return m_totalProgressReceive
      End Get
      Set(ByVal Value As Decimal)
        m_totalProgressReceive = Value
      End Set
    End Property
    Public Property TotalChildAmount() As Decimal
      Get
        Return m_totalchildAmount
      End Get
      Set(ByVal Value As Decimal)
        m_totalchildAmount = Value
      End Set
    End Property
    Public Property TotalMat() As Decimal
      Get
        Return m_totalmat
      End Get
      Set(ByVal Value As Decimal)
        m_totalmat = Value
      End Set
    End Property
    Public Property TotalLab() As Decimal
      Get
        Return m_totallab
      End Get
      Set(ByVal Value As Decimal)
        m_totallab = Value
      End Set
    End Property
    Public Property TotalEq() As Decimal
      Get
        Return m_totaleq
      End Get
      Set(ByVal Value As Decimal)
        m_totaleq = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub UpdateWBSQty()

      If Me.ItemType.Value <> 88 AndAlso Me.ItemType.Value <> 89 Then
        For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
          If wbsd.IsMarkup Then
            wbsd.BaseQty = 0
            wbsd.QtyRemain = 0
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
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim unit As Object = row("unit")
      Dim code As Object = row("Code")
      Dim pai_itemName As Object = row("pai_itemName")
      Dim amount As Object = row("amount")
      Dim pai_unitprice As Object = row("pai_unitprice")
      Dim pai_entitytype As Object = row("pai_entitytype")

      Dim isClosed As Boolean = False
      'isClosed = Me.Pa.Closed

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim isBlankRow As Boolean = False
      If IsDBNull(pai_entitytype) Then
        isBlankRow = True
      End If

      row("isSummaryRow") = False

      If Not isBlankRow Then
        Select Case CInt(pai_entitytype)
          Case 160, 162   'Note
            row.SetColumnError("pai_qty", "")
            row.SetColumnError("pai_unitprice", "")
            row.SetColumnError("pai_itemname", "")
            row.SetColumnError("code", "")
          Case 0, 88, 89, 291   'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(pai_itemName) OrElse pai_itemName.ToString.Length = 0 Then
              row.SetColumnError("pai_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pai_itemName", "")
            End If
            If Not IsNumeric(amount) Then    'OrElse CDec(poi_qty) <= 0 Then
              If CStr(amount).Length = 0 Then
                row.SetColumnError("amount", "")
              Else
                row.SetColumnError("amount", myStringParserService.Parse("${res:Global.Error.ItemPAAmountMissing}"))
              End If
            Else
              If CDec(amount) = 0 Then
                row.SetColumnError("amount", "")
              End If
              row.SetColumnError("pai_qty", "")
            End If
            If Not IsNumeric(pai_unitprice) Then    'OrElse CDec(pai_unitprice) <= 0 Then
              row.SetColumnError("pai_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            Else
              row.SetColumnError("pai_unitprice", "")
            End If

            row.SetColumnError("pai_unitprice", "")
            row.SetColumnError("code", "")
          Case 19   'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(pai_itemName) OrElse pai_itemName.ToString.Length = 0 Then
              row.SetColumnError("pai_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pai_itemName", "")
            End If
            If Not IsNumeric(amount) Then    'OrElse CDec(poi_qty) <= 0 Then
              If CStr(amount).Length = 0 Then
                row.SetColumnError("amount", "")
              Else
                row.SetColumnError("amount", myStringParserService.Parse("${res:Global.Error.ItemPAAmountMissing}"))
              End If
            Else
              If CDec(amount) = 0 Then
                row.SetColumnError("amount", "")
              End If
              row.SetColumnError("pai_qty", "")
            End If
            'If Not IsNumeric(pai_unitprice) Then 'OrElse CDec(pai_unitprice) <= 0 Then
            '    row.SetColumnError("pai_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("pai_unitprice", "")
            'End If
            row.SetColumnError("pai_unitprice", "")
          Case 28   'F/A
            If IsDBNull(pai_itemName) OrElse pai_itemName.ToString.Length = 0 Then
              row.SetColumnError("pai_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pai_itemName", "")
            End If
            If Not IsNumeric(amount) Then    'OrElse CDec(poi_qty) <= 0 Then
              If CStr(amount).Length = 0 Then
                row.SetColumnError("amount", "")
              Else
                row.SetColumnError("amount", myStringParserService.Parse("${res:Global.Error.ItemPAAmountMissing}"))
              End If
            Else
              If CDec(amount) = 0 Then
                row.SetColumnError("amount", "")
              End If
              row.SetColumnError("pai_qty", "")
            End If
            'If Not IsNumeric(pai_unitprice) Then 'OrElse CDec(pai_unitprice) <= 0 Then
            '    row.SetColumnError("pai_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("pai_unitprice", "")
            'End If
            row.SetColumnError("pai_unitprice", "")
            row.SetColumnError("code", "")
          Case 42   'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(pai_itemName) OrElse pai_itemName.ToString.Length = 0 Then
              row.SetColumnError("pai_itemName", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("pai_itemName", "")
            End If
            If Not IsNumeric(amount) Then    'OrElse CDec(poi_qty) <= 0 Then
              If CStr(amount).Length = 0 Then
                row.SetColumnError("amount", "")
              Else
                row.SetColumnError("amount", myStringParserService.Parse("${res:Global.Error.ItemPAAmountMissing}"))
              End If
            Else
              If CDec(amount) = 0 Then
                row.SetColumnError("amount", "")
              End If
              row.SetColumnError("pai_qty", "")
            End If
            'If Not IsNumeric(pai_unitprice) Then ' OrElse CDec(pai_unitprice) <= 0 Then
            '    row.SetColumnError("pai_unitprice", myStringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
            'Else
            '    row.SetColumnError("pai_unitprice", "")
            'End If
            row.SetColumnError("pai_unitprice", "")
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Sub SetQty(ByVal qty As Decimal)
      If (Me.ItemType.Value <> 290) AndAlso (Me.ItemType.Value <> 291) AndAlso (Me.ItemType.Value <> 289) Then
        Dim Value As Decimal = 0
        Value = qty * Me.UnitPrice

        If Not Me.ValidateReceiveAmount(Value) Then
          Return
        End If

        m_qty = qty
        m_receiveAmount = Value

        Me.RecalculateReceiveAmount()
      Else
        If ContractQtyCostAmount - m_receivedQty >= qty Then
          m_qty = qty
        End If
      End If
    End Sub
    Public Sub SetReceiveAmount(ByVal receiveAmt As Decimal)
      m_receiveAmount = receiveAmt

      If m_unitPrice <> 0 Then
        m_qty = m_receiveAmount / m_unitPrice
      Else
        m_qty = 0
      End If

      'Trace.WriteLine(m_receiveAmount)
      'Trace.WriteLine(m_unitPrice)
      'Trace.WriteLine(m_qty)
      If Not Me.ItemType Is Nothing Then
        Me.RecalculateReceiveAmount()
      End If
    End Sub
    Public Sub SetReceiveMat(ByVal receiveAmt As Decimal)
      m_mat = receiveAmt
    End Sub
    Public Sub SetReceiveLab(ByVal receiveAmt As Decimal)
      m_lab = receiveAmt
    End Sub
    Public Sub SetReceiveEq(ByVal receiveAmt As Decimal)
      m_eq = receiveAmt
    End Sub
    Public Sub SetUnitPrice(ByVal unitPrice As Decimal)
      m_unitPrice = unitPrice
    End Sub
    Public Sub SetUnit(ByVal newUnit As Unit)
      m_unit = newUnit
    End Sub
    Public Sub Clear()
      'Me.m_scItem = Nothing
      Me.m_entity = New BlankItem("")
      Me.m_entityName = ""
      Me.m_qty = 0
      Me.m_receivedQty = 0
      Me.m_unit = New Unit
      Me.m_unitPrice = 0
      Me.m_note = ""
      Me.m_discount = New Discount("")
      Me.m_account = New Account
      Me.m_unvatable = False
    End Sub
    Public Sub CopyToParentDataRowForNonRef(ByVal row As TreeRow)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      row("Button") = "invisible"
      row("UnitButton") = "invisible"
      row("AccountButton") = "invisible"
      row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.NotRefItem}") '"รายการรับงานไม่ได้อ้างอิงจากสัญญา" 
      row.FixLevel = 1
    End Sub
    Public Sub CopyToParentDataRowForDR(ByVal row As TreeRow)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      row("Button") = "invisible"
      row("UnitButton") = "invisible"
      row("AccountButton") = "invisible"
      row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.DRItemAmount}") '"รวมรายการหักค่าใช้จ่าย"  
      row.FixLevel = 1
    End Sub
    'Public Sub CopyToSummaryDataRow(ByVal row As TreeRow)
    '  Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    '  row("Button") = "invisible"
    '  row("UnitButton") = "invisible"
    '  row("AccountButton") = "invisible"
    '  row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCItemAmount}") & "ทั้งสิ้น" '"รวม" 
    '  row.FixLevel = 7
    '  'row.CustomFontStyle = FontStyle.Bold
    'End Sub
    Public Sub CopyToParentDataRow(ByVal row As TreeRow, Optional ByVal rowType As String = "")
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'row("isSummaryRow") = True

      'If noRefItem Then
      '  row.FixLevel = 0
      '  row.CustomFontStyle = FontStyle.Bold
      '  row("Button") = "invisible"
      '  row("UnitButton") = "invisible"
      '  row("AccountButton") = "invisible"
      '  row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.NotRefItem}") '"รายการรับงานไม่ได้อ้างอิงจากสัญญา" 
      '  Return
      'End If

      'row.FixLevel = -1
      'row.CustomFontStyle = FontStyle.Bold
      'row.CustomBackColor = Color.Gray
      'row.CustomForeColor = Color.Red
      row("Button") = "invisible"
      row("UnitButton") = "invisible"
      row("AccountButton") = "invisible"

      'If isBlankRow Then
      '  row("pai_itemName") = ""
      '  Return
      'End If
      If rowType.Length > 0 AndAlso rowType.ToLower.Equals("summary") Then
        row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCItemAmount}") & "ทั้งสิ้น" '"รวม" 
      End If
      'If Me.RefEntity.Id = 291 Then
      '  row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.DRItemAmount}") '"รวมรายการหักค่าใช้จ่าย" 
      'Else
      '  row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCItemAmount}") '"รวม" 
      '  'ElseIf Me.RefEntity.Id = 0 Then
      '  '  row("pai_itemName") = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.NotRefItem}") '"รายการรับงานไม่ได้อ้างอิงจากสัญญา" 
      'End If
      If Me.Qty = 0 Then
        row("pai_qty") = ""
      Else
        row("pai_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      End If
      If Me.TotalBudget = 0 Then 'มูลค่าตามสัญญา
        row("CostAmount") = ""
      Else
        row("CostAmount") = Configuration.FormatToString(Me.TotalBudget, DigitConfig.Price)
      End If
      If Me.TotalReceived = 0 Then 'มูลค่ารับแล้ว
        row("ReceivedAmount") = ""
      Else
        row("ReceivedAmount") = Configuration.FormatToString(Me.TotalReceived, DigitConfig.Price)
      End If
      If Me.TotalProgressReceive = 0 Then 'รวมรับงาน
        row("Amount") = ""
      Else
        row("Amount") = Configuration.FormatToString(Me.TotalProgressReceive, DigitConfig.Price)
      End If

      If Me.TotalMat <> 0 Then
        row("pai_mat") = Configuration.FormatToString(Me.TotalMat, DigitConfig.Price)
      Else
        row("pai_mat") = ""
      End If
      If Me.TotalLab <> 0 Then
        row("pai_lab") = Configuration.FormatToString(Me.TotalLab, DigitConfig.Price)
      Else
        row("pai_lab") = ""
      End If
      If Me.TotalEq <> 0 Then
        row("pai_eq") = Configuration.FormatToString(Me.TotalEq, DigitConfig.Price)
      Else
        row("pai_eq") = ""
      End If
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If

      Try
        Me.Pa.IsInitialized = False

        If Me.Level = 0 OrElse Me.RefEntity.Id <> 289 Then
          row("pai_refdoc") = Me.RefEntity.Name
          'row.CustomFontStyle = FontStyle.Bold
        End If

        row("pai_linenumber") = Me.LineNumber
        row("pai_level") = Me.Level
        If Me.Level = 1 Then
          row.FixLevel = -1
        Else
          row.FixLevel = 1
        End If

        Dim m_Entity_Name As String = Space(5) & Trim(Me.Entity.Name)
        Dim m_EntityName As String = Space(5) & Trim(Me.EntityName)

        'Dim m_Entity_Name As String = Trim(Me.Entity.Name)
        'Dim m_EntityName As String = Trim(Me.EntityName)

        If Not Me.ItemType Is Nothing Then
          row("pai_entityType") = Me.ItemType.Value
          row("pai_entityTypeDescription") = Me.ItemType.Description
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("pai_entity") = Me.Entity.Id
                row("pai_itemName") = m_Entity_Name
                row("EntityName") = m_Entity_Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("pai_itemName") = EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              If Me.RefEntity.Id <> 0 Then
                row("Button") = "invisible"
              Else
                row("Button") = ""
              End If
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                If TypeOf (Me.Entity) Is LCIItem Then
                  row("pai_entity") = Me.Entity.Id
                  row("pai_itemName") = m_Entity_Name
                  row("EntityName") = m_Entity_Name
                  row("Code") = Me.Entity.Code
                  If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                    If Me.Entity.Name <> Me.EntityName Then
                      row("pai_itemName") = m_EntityName & "<" & m_Entity_Name & ">"
                    End If
                  End If
                Else
                  If Me.RefEntity.Id <> 0 Then
                    row("Button") = "invisible"
                  Else
                    row("Button") = ""
                  End If
                  row("pai_itemName") = m_EntityName
                End If
              End If
            Case 0, 291
              row("Button") = "invisible"
              row("pai_itemName") = m_EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("pai_itemName") = m_EntityName
            Case 289
              row("Button") = "invisible"
              row("pai_itemName") = Trim(m_EntityName)
              row.CustomFontStyle = FontStyle.Bold
          End Select
        End If

        If Not Me.Unit Is Nothing Then
          row("pai_unit") = Me.Unit.Id
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
          row("pai_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("pai_qty") = ""
        End If

        If Me.Mat <> 0 Then
          row("pai_mat") = Configuration.FormatToString(Me.Mat, DigitConfig.Price)
        Else
          row("pai_mat") = ""
        End If
        If Me.Lab <> 0 Then
          row("pai_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
        Else
          row("pai_lab") = ""
        End If
        If Me.Eq <> 0 Then
          row("pai_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
        Else
          row("pai_eq") = ""
        End If
        'End Select

        If Me.UnitPrice <> 0 Then
          row("pai_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("pai_unitprice") = ""
        End If

        'row("pai_discrate") = Me.Discount.Rate
        'If Me.Level = 0 AndAlso Me.HashSCChild Then
        '  If Me.Amount <> 0 Then
        '    row("Amount") = Configuration.FormatToString(Me.TotalChildAmount, DigitConfig.Price)
        '  Else
        '    row("Amount") = ""
        '  End If
        'Else
        If Me.Amount <> 0 Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If
        'End If


        If Me.ContractCostAmount <> Decimal.MinValue AndAlso Me.ContractCostAmount <> 0 Then
          row("CostAmount") = Configuration.FormatToString(Me.ContractCostAmount, DigitConfig.Price)
        Else
          row("CostAmount") = DBNull.Value
        End If
        If Me.ContractQtyCostAmount <> Decimal.MinValue AndAlso Me.ContractQtyCostAmount <> 0 Then
          row("QtyCostAmount") = Configuration.FormatToString(Me.ContractQtyCostAmount, DigitConfig.Qty)
        Else
          row("QtyCostAmount") = DBNull.Value
        End If

        If Me.ReceivedAmount <> Decimal.MinValue AndAlso Me.ReceivedAmount <> 0 Then
          row("ReceivedAmount") = Configuration.FormatToString(Me.ReceivedAmount, DigitConfig.Price)
        Else
          row("ReceivedAmount") = DBNull.Value
        End If
        If Me.ReceivedQty <> Decimal.MinValue AndAlso Me.ReceivedQty <> 0 Then
          row("ReceivedQty") = Configuration.FormatToString(Me.ReceivedQty, DigitConfig.Qty)
        Else
          row("ReceivedQty") = DBNull.Value
        End If



        row("pai_note") = Me.Note
        row("pai_unvatable") = Me.UnVatable

        Me.Pa.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Sub CopyToDataRowForAccountItem(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If

      Try
        'Me.Pa.IsInitialized = False
        If Me.Level = 0 Then
          row("AccountButton") = "invisible"
        End If
        If Me.Level = 0 OrElse Me.RefEntity.Id <> 289 Then
          row("pai_refdoc") = Me.RefEntity.Name
          'row.CustomFontStyle = FontStyle.Bold
        End If

        'row("pai_linenumber") = Me.LineNumber
        'row("pai_level") = Me.Level
        If Me.Level = 1 Then
          row.FixLevel = -1
        Else
          row.FixLevel = 1
        End If

        Dim m_Entity_Name As String = Space(5) & Trim(Me.Entity.Name)
        Dim m_EntityName As String = Space(5) & Trim(Me.EntityName)

        'Dim m_Entity_Name As String = Trim(Me.Entity.Name)
        'Dim m_EntityName As String = Trim(Me.EntityName)

        If Not Me.ItemType Is Nothing Then
          row("pai_entityType") = Me.ItemType.Value
          row("pai_entityTypeDescription") = Me.ItemType.Description
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("pai_entity") = Me.Entity.Id
                row("pai_itemName") = m_Entity_Name
                row("EntityName") = m_Entity_Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("pai_itemName") = EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              'If Me.RefEntity.Id <> 0 Then
              '  row("Button") = "invisible"
              'Else
              '  row("Button") = ""
              'End If
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                If TypeOf (Me.Entity) Is LCIItem Then
                  row("pai_entity") = Me.Entity.Id
                  row("pai_itemName") = m_Entity_Name
                  row("EntityName") = m_Entity_Name
                  row("Code") = Me.Entity.Code
                  If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                    If Me.Entity.Name <> Me.EntityName Then
                      row("pai_itemName") = m_EntityName & "<" & m_Entity_Name & ">"
                    End If
                  End If
                Else
                  'If Me.RefEntity.Id <> 0 Then
                  '  row("Button") = "invisible"
                  'Else
                  '  row("Button") = ""
                  'End If
                  row("pai_itemName") = m_EntityName
                End If
              End If
            Case 0, 291
              'row("Button") = "invisible"
              row("pai_itemName") = m_EntityName
            Case 160, 162
              'row("Button") = "invisible"
              'row("UnitButton") = "invisible"
              row("pai_itemName") = m_EntityName
            Case 289
              'row("Button") = "invisible"
              row("pai_itemName") = Trim(m_EntityName)
              row.CustomFontStyle = FontStyle.Bold
          End Select
        End If

        'If Not Me.Unit Is Nothing Then
        '  row("pai_unit") = Me.Unit.Id
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
        '  row("pai_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        'Else
        '  row("pai_qty") = ""
        'End If

        'If Me.Mat <> 0 Then
        '  row("pai_mat") = Configuration.FormatToString(Me.Mat, DigitConfig.Price)
        'Else
        '  row("pai_mat") = ""
        'End If
        'If Me.Lab <> 0 Then
        '  row("pai_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
        'Else
        '  row("pai_lab") = ""
        'End If
        'If Me.Eq <> 0 Then
        '  row("pai_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
        'Else
        '  row("pai_eq") = ""
        'End If
        'End Select

        'If Me.UnitPrice <> 0 Then
        '  row("pai_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        'Else
        '  row("pai_unitprice") = ""
        'End If

        'row("pai_discrate") = Me.Discount.Rate
        'If Me.Level = 0 AndAlso Me.HashSCChild Then
        '  If Me.Amount <> 0 Then
        '    row("Amount") = Configuration.FormatToString(Me.TotalChildAmount, DigitConfig.Price)
        '  Else
        '    row("Amount") = ""
        '  End If
        'Else
        'If Me.Amount <> 0 Then
        row("Amount") = Configuration.FormatToString(Me.CostAmount, DigitConfig.Price)
        If Not Me.MatAccount Is Nothing Then
          row("AccountCode") = Me.MatAccount.Code
          row("Account") = Me.MatAccount.Name
        End If
        If Not Me.LabAccount Is Nothing Then
          row("AccountCode") = Me.LabAccount.Code
          row("Account") = Me.LabAccount.Name
        End If
        If Not Me.EqAccount Is Nothing Then
          row("AccountCode") = Me.EqAccount.Code
          row("Account") = Me.EqAccount.Name
        End If


        'Else
        'row("Amount") = ""
        'End If
        'End If


        'If Me.ContractCostAmount <> Decimal.MinValue AndAlso Me.ContractCostAmount <> 0 Then
        '  row("CostAmount") = Configuration.FormatToString(Me.ContractCostAmount, DigitConfig.Price)
        'Else
        '  row("CostAmount") = DBNull.Value
        'End If
        'If Me.ContractQtyCostAmount <> Decimal.MinValue AndAlso Me.ContractQtyCostAmount <> 0 Then
        '  row("QtyCostAmount") = Configuration.FormatToString(Me.ContractQtyCostAmount, DigitConfig.Qty)
        'Else
        '  row("QtyCostAmount") = DBNull.Value
        'End If

        'If Me.ReceivedAmount <> Decimal.MinValue AndAlso Me.ReceivedAmount <> 0 Then
        '  row("ReceivedAmount") = Configuration.FormatToString(Me.ReceivedAmount, DigitConfig.Price)
        'Else
        '  row("ReceivedAmount") = DBNull.Value
        'End If
        'If Me.ReceivedQty <> Decimal.MinValue AndAlso Me.ReceivedQty <> 0 Then
        '  row("ReceivedQty") = Configuration.FormatToString(Me.ReceivedQty, DigitConfig.Qty)
        'Else
        '  row("ReceivedQty") = DBNull.Value
        'End If



        'row("pai_note") = Me.Note
        'row("pai_unvatable") = Me.UnVatable

        'Me.Pa.IsInitialized = True
      Catch ex As NoConversionException
        'MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Function IsHasChild() As Boolean
      Dim doc As PAItem = Me '.Pa.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return False
      End If
      If doc.Level = 1 Then
        Return False
      End If

      Dim parent As Decimal = doc.Parent
      Dim hasChild As Boolean
      For Each itm As PAItem In Me.Pa.ItemCollection
        If itm.Level = 1 AndAlso itm.Parent = parent Then
          hasChild = True
        End If
      Next

      Return hasChild

    End Function
    Public Function ChildAmount() As Decimal
      Dim doc As PAItem = Me
      Dim m_childAmount As Decimal = 0
      Dim parent As Decimal = doc.Parent

      For Each itm As PAItem In Me.Pa.ItemCollection
        If itm.Level = 1 AndAlso itm.Parent = parent AndAlso itm.RefEntity.Id = 289 Then
          m_childAmount += itm.Amount
        End If
      Next

      If m_childAmount = 0 Then 'กรณีที่ รายการ sc ไม่มีลูก
        m_childAmount = doc.Amount
      End If

      Return m_childAmount
    End Function
    Public Function IsHasChild(ByVal CurrentItem As PAItem) As Boolean
      Dim doc As PAItem = Nothing
      If Not CurrentItem Is Nothing Then
        doc = CurrentItem
      Else
        doc = Me
      End If
      If doc Is Nothing Then
        Return False
      End If
      If doc.Level = 1 Then
        Return False
      End If

      Dim lastIndex As Integer = Me.Pa.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.Pa.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          If Me.Pa.ItemCollection(i).Level = 0 Then
            Exit For
          End If
          lastIndex = i
        End If
        'End If
      Next

      If startIndex < lastIndex Then
        Return True
      End If

      Return False

    End Function
    Public Function GetChildCostAmount() As Decimal
      Dim doc As PAItem = Me
      Dim m_childCostAmount As Decimal = 0
      Dim parent As Decimal = doc.Parent

      For Each itm As PAItem In Me.Pa.ItemCollection
        If itm.Level = 1 AndAlso itm.Parent = parent Then
          m_childCostAmount += itm.CostAmount
        End If
      Next

      Return m_childCostAmount
    End Function
    Public Function GetChildAmount() As Decimal
      Dim doc As PAItem = Me
      Dim m_childAmount As Decimal = 0
      Dim parent As Decimal = doc.Parent

      For Each itm As PAItem In Me.Pa.ItemCollection
        If itm.Level = 1 AndAlso itm.Parent = parent Then
          m_childAmount += itm.Amount
        End If
      Next

      Return m_childAmount
    End Function
    Public Function GetReceivedQty() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.Pa.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetStockedQty" _
      , New SqlParameter("@pa_id", Me.Pa.Id) _
      , New SqlParameter("@entity_id", Me.Entity.Id) _
      , New SqlParameter("@linenumber", Me.LineNumber) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        If IsNumeric(ds.Tables(0).Rows(0)("receivedQty")) Then
          Return CDec(ds.Tables(0).Rows(0)("receivedQty"))
        End If
      End If
    End Function
    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements IWBSAllocatableItem.WBSChangedHandler
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            'If Not Me.m_pa Is Nothing Then
            '	Me.m_pa.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            'End If
          Case "wbs"
            Dim newWBS As WBS = CType(e.Value, WBS)
            Dim theName As String = Me.EntityName
            If theName Is Nothing Then
              theName = Me.Entity.Name
            End If
            Select Case Me.ItemType.Value
              Case 289, 291
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB 'GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
              Case 0
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetBudgetQtyForType0FromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
                'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.SC, 6) - Me.SC.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
              Case 19
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = 0        'ไม่มี budget ให้เครื่องมือแน่ๆ
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
              Case 42
                wbsd.BudgetAmount = newWBS.GetTotalMatFromDB
                wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Me.Entity.Id)
                wbsd.OwnerBudgetAmount = newWBS.OwnerMatBudgetAmount
              Case 88
                wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
                wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerLabBudgetAmount
              Case 89
                wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
                wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
                wbsd.OwnerBudgetAmount = newWBS.OwnerEqBudgetAmount
            End Select
            If wbsd.IsMarkup Then
              wbsd.BudgetRemain = newWBS.GetTotalMarkUpFromDB - newWBS.GetWBSActualFromDB(Me.Pa.Id, Me.Pa.EntityId, Me.ItemType.Value)
              wbsd.QtyRemain = 0
            Else
              wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.Pa.Id, Me.Pa.EntityId, Me.ItemType.Value)
              If Me.ItemType.Value <> 88 And Me.ItemType.Value <> 89 Then
                wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.Pa.Id, Me.Pa.EntityId, Me.Entity.Id, _
                                                                              Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
              Else
                wbsd.QtyRemain = 0
              End If
            End If

            'wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.Pa.Id, Me.Pa.EntityId, Me.ItemType.Value)
            'wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.Pa.Id, Me.Pa.EntityId, Me.Entity.Id, _
            '                                                               Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย

            ''Me.m_pa.SetActual(oldWBS, wbsd.TransferAmount, 0, Me.ItemType.Value)
            ''Me.m_pa.SetActual(newWBS, 0, wbsd.TransferAmount, Me.ItemType.Value)
        End Select
      End If
    End Sub
    Public Sub SetAccountCode(ByVal theCode As String)      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Me.Pa.OnGlChanged()
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
          Case 160, 162, 0 'Note,อื่นๆ
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
#End Region

#Region "IWBSAllocatableItem"
    Public ReadOnly Property AllocationErrorMessage() As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        If Me.ItemType Is Nothing Then
          Return "No Item Type"
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            Return "${res:Global.Error.NoteCannotHaveWBS}"
          Case 289, 291
            If Me.ChildAmount <> Me.Amount Then
              Return "${res:Global.Error.CannotAllocate}"
            End If
            If Me.GetChildAmount > 0 Then
              Return "${res:Global.Error.CannotAllocate}"
            End If

        End Select
        Return ""
      End Get
    End Property

    Public ReadOnly Property Description() As String Implements IWBSAllocatableItem.Description
      Get
        Dim indent As String = ""
        If Me.ItemType.Value <> 289 Then
          indent = Space(5)
        End If
        If Me.Entity.Code.Length = 0 Then
          Return indent & Trim(Me.EntityName)
        End If
        Return indent & Me.Entity.Code & " : " & Trim(Me.Entity.Name)  '  Me.EntityName
      End Get
    End Property
    Public ReadOnly Property AllocationType As String Implements IWBSAllocatableItem.AllocationType
      Get
        Select Case Me.ItemType.Value
          Case 88, 289, 291
            Return "lab"
          Case 89
            Return "eq"
          Case Else
            Return "mat"
        End Select
      End Get
    End Property
    Public ReadOnly Property Type() As String Implements IWBSAllocatableItem.Type
      Get
        If Me.ItemType Is Nothing Then
          Return ""
        End If
        Return ItemType.Description
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

    Public Property WBSDistributeCollection2() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2
      Get

      End Get
      Set(ByVal Value As WBSDistributeCollection)

      End Set
    End Property
#End Region

#Region "TAX"
    Public ReadOnly Property DiscountFromParent() As Decimal
      Get
        If Me.Pa Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.Pa.Gross
        Dim myDiscount As Decimal = Me.Pa.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Return (Me.AmountWithoutFormat / myGross) * myDiscount
      End Get
    End Property
    Public ReadOnly Property TaxBase() As Decimal
      Get
        If Me.Pa Is Nothing Then
          Return 0
        End If
        Dim myGross As Decimal = Me.Pa.Gross
        Dim myDiscount As Decimal = Me.Pa.DiscountAmount
        If myGross = 0 Then
          Return 0
        End If
        Select Case Me.Pa.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            If Not Me.UnVatable Then
              'Return (Me.AmountWithoutFormat - _
              '( _
              '(Me.AmountWithoutFormat / myGross) * myDiscount) _
              ')
              Return ((myGross - myDiscount) / myGross) * Me.AmountWithoutFormat
            End If
          Case 2 '"รวม"
            If Not Me.UnVatable Then
              Return Vat.GetExcludedVatAmountWithoutRound(Me.Amount, Me.Pa.TaxRate)
              'Return Vat.GetExcludedVatAmountWithoutRound(Me.AmountWithoutFormat - ((Me.AmountWithoutFormat / myGross) * myDiscount), Me.Pa.TaxRate)
            End If
        End Select
      End Get
    End Property
#End Region
  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class PAItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_pa As PA
    Private m_paId As Integer
    'Private m_paHash As Hashtable
    Private m_currentItem As PAItem
    Private m_currentRealItem As PAItem
    Private m_currentLastItem As PAItem

    'Private m_sumqtyCostAmount As Decimal
    Private m_sumCostAmount As Decimal
    'Private m_sumqtyReceivedAmount As Decimal
    Private m_sumReceiveAmount As Decimal
    'Private m_parent As Hashtable
    'Private m_child As Hashtable
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As PA)
      Me.m_pa = owner
      If Not Me.m_pa.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetPAItems" _
      , New SqlParameter("@pa_id", Me.m_pa.Id) _
      )
      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New PAItem(row, "")
        item.Pa = m_pa
        item.SC = m_pa.Sc

        Dim oldAmt As Decimal = item.ReceiveAmount
        item.ReceiveAmount = oldAmt

        Me.Add(item)

        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        If ds.Tables.Count > 1 Then
          For Each wbsRow As DataRow In ds.Tables(1).Select("paiw_sequence=" & item.Sequence)
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
        End If
      Next
    End Sub
    Public Sub RefreshBudget()
    End Sub
#End Region

#Region "Properties"
    'Public Property Parent() As Hashtable
    '  Get
    '    Return m_parent
    '  End Get
    '  Set(ByVal Value As Hashtable)
    '    m_parent = Value
    '  End Set
    'End Property
    'Public Property Child() As Hashtable
    '  Get
    '    Return m_child
    '  End Get
    '  Set(ByVal Value As Hashtable)
    '    m_child = Value
    '  End Set
    'End Property
    Public Property PA() As PA      Get        Return m_pa      End Get      Set(ByVal Value As PA)        m_pa = Value        If Value Is Nothing Then          m_paId = 0
          Return
        End If        m_paId = Value.Id      End Set    End Property
    Default Public Property Item(ByVal index As Integer) As PAItem
      Get
        Return CType(MyBase.List.Item(index), PAItem)
      End Get
      Set(ByVal value As PAItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim amt As Decimal = 0        For Each item As PAItem In Me
          amt += Configuration.Format(item.Amount, DigitConfig.Price)
        Next
        Return amt
      End Get
    End Property
    'Public ReadOnly Property SumQtyContractAmount() As Decimal
    'Get
    'Dim amt As Decimal = 0    'For Each item As PAItem In Me
    'amt += Configuration.Format(item.ContractQtyCostAmount, DigitConfig.Price)
    'Next
    'Return amt
    'End Get
    'End Property
    Public ReadOnly Property SumContractAmount() As Decimal
      Get
        Dim amt As Decimal = 0        For Each item As PAItem In Me
          amt += Configuration.Format(item.TotalBudget, DigitConfig.Price)
        Next
        Return amt
      End Get
    End Property
    'Public ReadOnly Property SumQtyReceived() As Decimal
    'Get
    'Dim amt As Decimal = 0    'For Each item As PAItem In Me
    'If item.Level = 0 Then
    'amt += Configuration.Format(item.ReceivedQty, DigitConfig.Price)
    'End If
    'Next
    'Return amt
    'End Get
    'End Property
    Public ReadOnly Property SumReceivedAmount() As Decimal
      Get
        Dim amt As Decimal = 0        For Each item As PAItem In Me
          amt += Configuration.Format(item.TotalReceived, DigitConfig.Price)
        Next
        Return amt
      End Get
    End Property
    Public Property CurrentItem() As PAItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As PAItem)
        m_currentItem = Value
      End Set
    End Property
    Public Property CurrentRealItem() As PAItem
      Get
        Return m_currentRealItem
      End Get
      Set(ByVal Value As PAItem)
        m_currentRealItem = Value
      End Set
    End Property
    Public Property CurrentLastItem() As PAItem
      Get
        Return m_currentLastItem
      End Get
      Set(ByVal Value As PAItem)
        m_currentLastItem = Value
      End Set
    End Property

#End Region

#Region "Class Methods"
    Public Sub SetBudgetRemain(ByVal wbsd As WBSDistribute, ByVal Item As PAItem)
      Dim newWBS As WBS = wbsd.WBS ' CType(e.Value, WBS)
      Dim theName As String = Item.EntityName
      If theName Is Nothing Then
        theName = Item.Entity.Name
      End If
      Select Case Item.ItemType.Value
        Case 289, 291
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
          wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Item.Entity.Id)
        Case 88
          wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
          wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
        Case 89
          wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
          wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
      End Select
      wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Item.Pa.Id, Item.Pa.EntityId, Item.ItemType.Value)
      wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Item.Pa.Id, Item.Pa.EntityId, Item.Entity.Id, _
                                                                  Item.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
      'Item.UpdateWBSQty()
    End Sub
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
          Dim doc As New PAItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = newType
            Me.CurrentItem = Nothing
          Else
            Me.Add(doc)
            doc.ItemType = New PAIItemType(newType)
          End If
          'doc.Entity = newItem   'เดิม Set จากการกดปุ่มเป็นแบบนี้ทำให้รหัสบัญชีไม่ขึ้น จึงไปใช้วิธีเดียวกับการกรอกใน textbox
          doc.SetItemCode(newItem.Code)
        End If
      Next
      'RefreshBudget()
    End Sub

    Public Sub newPopulate2(ByVal dt As TreeTable, ByVal tg As DataGrid)
      dt.Clear()

      Dim paiChildList As New List(Of PAItem)
      Dim paiDriList As New List(Of PAItem)
      Dim paiNonRefiList As New List(Of PAItem)

      Dim blankPaitemForDR As New PAItem
      blankPaitemForDR.RefEntity = New RefEntity
      blankPaitemForDR.RefEntity.Id = 291

      Dim blankPaitemForNonRef As PAItem

      '--สร้าง Parent SC และเก็บ ChildSC, Dr, และ NonReference ไว้ก่อน--
      Dim paParentRow As TreeRow = Nothing
      For Each pai As PAItem In Me
        If pai.ItemType.Value = 160 OrElse pai.ItemType.Value = 162 Then

        Else
          If Not pai.RefEntity Is Nothing AndAlso pai.RefEntity.Id > 0 Then
            If pai.RefEntity.Id = 291 Then
              paiDriList.Add(pai)
            Else
              If pai.Level = 0 Then
                paParentRow = dt.Childs.Add
                paParentRow.State = RowExpandState.Expanded
                pai.CopyToDataRowForAccountItem(paParentRow)
                'pai.ItemValidateRow(paParentRow)
                paParentRow.Tag = pai
              Else
                paiChildList.Add(pai)
              End If
            End If
          Else
            paiNonRefiList.Add(pai)
          End If
        End If
      Next
      '--สร้าง Parent SC และเก็บ ChildSC, Dr, และ NonReference ไว้ก่อน--
      '--สร้าง Parent NonReference --
      Dim paNonRefParentRow As TreeRow = Nothing
      If paiNonRefiList.Count > 0 Then
        paNonRefParentRow = dt.Childs.Add
        paNonRefParentRow.State = RowExpandState.Expanded
        blankPaitemForDR.CopyToParentDataRowForNonRef(paNonRefParentRow)
        'blankPaitemForDR.ItemValidateRow(paNonRefParentRow)
        paNonRefParentRow.Tag = "NonrefParent"
      End If
      '--สร้าง Parent NonReference --
      '--สร้าง Parent DR --
      Dim paDrParentRow As TreeRow = Nothing
      If paiDriList.Count > 0 Then
        paDrParentRow = dt.Childs.Add
        paDrParentRow.State = RowExpandState.Expanded
        blankPaitemForDR.CopyToParentDataRowForDR(paDrParentRow)
        'blankPaitemForDR.ItemValidateRow(paDrParentRow)
        paDrParentRow.Tag = blankPaitemForDR
      End If
      '--สร้าง Parent DR --

      '--สร้าง Child Paitem--
      Dim paChildRow As TreeRow = Nothing
      For Each prow As TreeRow In dt.Childs
        If TypeOf prow.Tag Is PAItem Then
          For Each pai As PAItem In paiChildList
            If (Me.PA.Originated AndAlso CType(prow.Tag, PAItem).Sequence.Equals(pai.Parent)) OrElse
              (Not Me.PA.Originated AndAlso CType(prow.Tag, PAItem).RefSequence.Equals(pai.Parent)) Then
              paChildRow = prow.Childs.Add
              pai.CopyToDataRowForAccountItem(paChildRow)
              'pai.ItemValidateRow(paChildRow)
              paChildRow.Tag = pai
            End If
          Next
        End If
      Next
      '--สร้าง Child Paitem--
      '--สร้าง Child NonReference--

      '--สร้าง Child NonReference--
      '--สร้าง Child DR--
      Dim drChildRow As TreeRow = Nothing
      For Each prow As TreeRow In dt.Childs
        If TypeOf prow.Tag Is PAItem AndAlso Not CType(prow.Tag, PAItem).RefEntity Is Nothing AndAlso CType(prow.Tag, PAItem).RefEntity.Id = 291 Then
          For Each pai As PAItem In paiDriList
            drChildRow = prow.Childs.Add
            pai.CopyToDataRowForAccountItem(drChildRow)
            'pai.ItemValidateRow(drChildRow)
            drChildRow.Tag = pai
          Next
        End If
      Next
      '--สร้าง Child DR--

      dt.AcceptChanges()
      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("pai_entityType")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception
      End Try
      dt.AcceptChanges()

    End Sub

    Public Sub newPopulate(ByVal dt As TreeTable, ByVal tg As DataGrid)

      Dim paiChildList As New List(Of PAItem)
      Dim paiDriList As New List(Of PAItem)
      Dim paiNonRefiList As New List(Of PAItem)

      Dim blankPaitemForDR As New PAItem
      blankPaitemForDR.RefEntity = New RefEntity
      blankPaitemForDR.RefEntity.Id = 291

      Dim blankPaitemForNonRef As PAItem

      '--สร้าง Parent SC และเก็บ ChildSC, Dr, และ NonReference ไว้ก่อน--
      Dim paParentRow As TreeRow = Nothing
      For Each pai As PAItem In Me
        If Not pai.RefEntity Is Nothing AndAlso pai.RefEntity.Id > 0 Then
          If pai.RefEntity.Id = 291 Then
            paiDriList.Add(pai)
          Else
            If pai.Level = 0 Then
              paParentRow = dt.Childs.Add
              paParentRow.State = RowExpandState.Expanded
              pai.CopyToDataRow(paParentRow)
              pai.ItemValidateRow(paParentRow)
              paParentRow.Tag = pai
            Else
              paiChildList.Add(pai)
            End If
          End If
        Else
          paiNonRefiList.Add(pai)
        End If
      Next
      '--สร้าง Parent SC และเก็บ ChildSC, Dr, และ NonReference ไว้ก่อน--
      '--สร้าง Parent NonReference --
      Dim paNonRefParentRow As TreeRow = Nothing
      If paiNonRefiList.Count > 0 Then
        paNonRefParentRow = dt.Childs.Add
        paNonRefParentRow.State = RowExpandState.Expanded
        blankPaitemForDR.CopyToParentDataRowForNonRef(paNonRefParentRow)
        blankPaitemForDR.ItemValidateRow(paNonRefParentRow)
        paNonRefParentRow.Tag = "NonrefParent"
      End If
      '--สร้าง Parent NonReference --
      '--สร้าง Parent DR --
      Dim paDrParentRow As TreeRow = Nothing
      If paiDriList.Count > 0 Then
        paDrParentRow = dt.Childs.Add
        paDrParentRow.State = RowExpandState.Expanded
        blankPaitemForDR.CopyToParentDataRowForDR(paDrParentRow)
        blankPaitemForDR.ItemValidateRow(paDrParentRow)
        paDrParentRow.Tag = blankPaitemForDR
      End If
      '--สร้าง Parent DR --

      '--สร้าง Child Paitem--
      Dim paChildRow As TreeRow = Nothing
      For Each prow As TreeRow In dt.Childs
        If TypeOf prow.Tag Is PAItem Then
          For Each pai As PAItem In paiChildList
            If (Me.PA.Originated AndAlso CType(prow.Tag, PAItem).Sequence.Equals(pai.Parent)) OrElse
              (Not Me.PA.Originated AndAlso CType(prow.Tag, PAItem).RefSequence.Equals(pai.Parent)) Then
              paChildRow = prow.Childs.Add
              pai.CopyToDataRow(paChildRow)
              pai.ItemValidateRow(paChildRow)
              paChildRow.Tag = pai
            End If
          Next
        End If
      Next
      '--สร้าง Child Paitem--
      '--สร้าง Child NonReference--

      '--สร้าง Child NonReference--
      '--สร้าง Child DR--
      Dim drChildRow As TreeRow = Nothing
      For Each prow As TreeRow In dt.Childs
        If TypeOf prow.Tag Is PAItem AndAlso Not CType(prow.Tag, PAItem).RefEntity Is Nothing AndAlso CType(prow.Tag, PAItem).RefEntity.Id = 291 Then
          For Each pai As PAItem In paiDriList
            drChildRow = prow.Childs.Add
            pai.CopyToDataRow(drChildRow)
            pai.ItemValidateRow(drChildRow)
            drChildRow.Tag = pai
          Next
        End If
      Next
      '--สร้าง Child DR--

      '--New Summary--=============
      Dim totalBudget As Decimal = 0
      Dim totalReceived As Decimal = 0
      Dim totalProgressReceive As Decimal = 0
      Dim totalMat As Decimal = 0
      Dim totalLab As Decimal = 0
      Dim totalEq As Decimal = 0
      'Dim receiveAmount As Decimal = 0
      For Each srow As TreeRow In dt.Childs
        If TypeOf srow.Tag Is PAItem AndAlso CType(srow.Tag, PAItem).Level = 0 Then
          'CType(srow.Tag, PAItem).ReceiveAmount = 0
          CType(srow.Tag, PAItem).TotalBudget = 0
          CType(srow.Tag, PAItem).TotalReceived = 0
          CType(srow.Tag, PAItem).TotalProgressReceive = 0
          CType(srow.Tag, PAItem).TotalMat = 0
          CType(srow.Tag, PAItem).TotalLab = 0
          CType(srow.Tag, PAItem).TotalEq = 0
          'CType(srow.Tag, PAItem).ReceiveAmount = 0
          'CType(srow.Tag, PAItem).SetReceiveAmount(0)
          For Each crow As TreeRow In srow.Childs
            If TypeOf crow.Tag Is PAItem Then
              CType(srow.Tag, PAItem).TotalBudget += CType(crow.Tag, PAItem).ContractCostAmount
              CType(srow.Tag, PAItem).TotalReceived += CType(crow.Tag, PAItem).ReceivedAmount
              CType(srow.Tag, PAItem).TotalProgressReceive += Configuration.Format(CType(crow.Tag, PAItem).Amount, DigitConfig.Price)
              CType(srow.Tag, PAItem).TotalMat += CType(crow.Tag, PAItem).Mat
              CType(srow.Tag, PAItem).TotalLab += CType(crow.Tag, PAItem).Lab
              CType(srow.Tag, PAItem).TotalEq += CType(crow.Tag, PAItem).Eq
              'CType(srow.Tag, PAItem).ReceiveAmount += CType(crow.Tag, PAItem).ReceiveAmount
              'receiveAmount += CType(crow.Tag, PAItem).ReceivedAmount
            End If
          Next
          CType(srow.Tag, PAItem).SetReceiveAmount(CType(srow.Tag, PAItem).TotalProgressReceive)
          totalBudget += CType(srow.Tag, PAItem).TotalBudget
          totalReceived += CType(srow.Tag, PAItem).TotalReceived
          totalProgressReceive += CType(srow.Tag, PAItem).TotalProgressReceive
          totalMat += CType(srow.Tag, PAItem).TotalMat
          totalLab += CType(srow.Tag, PAItem).TotalLab
          totalEq += CType(srow.Tag, PAItem).TotalEq

          CType(srow.Tag, PAItem).CopyToParentDataRow(srow)
        End If
      Next
      '--New Summary--=============

      '--Total Summary--===========
      Dim blankPaItem As New PAItem
      blankPaItem.TotalBudget = totalBudget
      blankPaItem.TotalReceived = totalReceived
      blankPaItem.TotalProgressReceive = totalProgressReceive
      blankPaItem.TotalMat = totalMat
      blankPaItem.TotalLab = totalLab
      blankPaItem.TotalEq = totalEq

      Dim summaryRow As TreeRow = dt.Childs.Add
      summaryRow.State = RowExpandState.Expanded
      blankPaItem.CopyToParentDataRow(summaryRow, "summary")
      blankPaItem.ItemValidateRow(summaryRow)
      '--Total Summary--===========

      dt.AcceptChanges()
      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("pai_entityType")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception
      End Try
      dt.AcceptChanges()


    End Sub

    Public Sub Populate(ByVal dt As TreeTable, ByVal tg As DataGrid)
      dt.Clear()

      newPopulate(dt, tg)

      Return

      ''Dim i As Integer = 0
      ' ''Dim j As Integer = 0

      ''Dim key As String = ""
      ' ''Dim parKey As String = ""

      ''Dim HashSCItem As New Hashtable
      ''Dim CurrentParent As String = ""
      ''Dim isDrItem As Boolean = False
      ''Dim isSCItem As Boolean = False
      ''Dim hasDrItem As Boolean = False
      ''Dim hasNoRefItem As Boolean = False
      ''Dim chkHasChild As New Hashtable

      ' ''Dim sumRow As TreeRow
      ' ''Dim newRow As TreeRow
      ' ''Dim newitem As New PAItem

      ''Dim newItemRef As New ArrayList
      ''Dim newItemDRRef As New ArrayList
      ''Dim newItemNotRef As New ArrayList



      ''Dim parentRow As TreeRow
      ''Dim childRow As TreeRow

      ''For Each pai As PAItem In Me
      ''  key = pai.Parent.ToString
      ''  If pai.ItemType.Value = 289 Then
      ''    Me(Me.IndexOf(pai)).Level = 0
      ''    chkHasChild(key) = pai
      ''  Else
      ''    Me(Me.IndexOf(pai)).Level = 1
      ''    If chkHasChild.Contains(key) Then
      ''      If pai.RefEntity.Id = 289 Then
      ''        CType(chkHasChild(key), PAItem).HashSCChild = True
      ''      End If
      ''    End If
      ''  End If
      ''  If pai.RefEntity.Id = 0 Then
      ''    newItemNotRef.Add(pai)
      ''  ElseIf pai.RefEntity.Id = 291 Then
      ''    newItemDRRef.Add(pai)
      ''  Else
      ''    newItemRef.Add(pai)
      ''  End If
      ''Next

      '' ''== Summary Ref SC Item ==================================================
      ''For Each pai As PAItem In newItemRef

      ''  CurrentParent = pai.Parent.ToString

      ''  If pai.Level = 0 Then
      ''    HashSCItem(CurrentParent) = pai
      ''    newitem = CType(HashSCItem(CurrentParent), PAItem)
      ''    If pai.HasChild Then

      ''      newitem.TotalBudget = 0
      ''      newitem.TotalReceived = 0
      ''      newitem.TotalProgressReceive = 0

      ''      newitem.TotalChildAmount = 0
      ''      newitem.TotalMat = 0
      ''      newitem.TotalLab = 0
      ''      newitem.TotalEq = 0

      ''    End If
      ''  ElseIf pai.Level = 1 Then
      ''    If HashSCItem.Contains(CurrentParent) Then
      ''      newitem = CType(HashSCItem(CurrentParent), PAItem)

      ''      newitem.TotalBudget += pai.ContractCostAmount
      ''      newitem.TotalReceived += pai.ReceivedAmount
      ''      newitem.TotalProgressReceive += Configuration.Format(pai.Amount, DigitConfig.Price)

      ''      If pai.RefEntity.Id <> 290 Then
      ''        newitem.TotalChildAmount += Configuration.Format(pai.Amount, DigitConfig.Price)
      ''        newitem.TotalMat += Configuration.Format(pai.Mat, DigitConfig.Price)
      ''        newitem.TotalLab += Configuration.Format(pai.Lab, DigitConfig.Price)
      ''        newitem.TotalEq += Configuration.Format(pai.Eq, DigitConfig.Price)
      ''      End If

      ''    End If
      ''    'If pai.RefDocType = 290 AndAlso Not pai.IsReferenceSC Then
      ''    '  newitem.TotalBudget += pai.ContractCostAmount
      ''    '  newitem.TotalReceived += pai.ReceivedAmount
      ''    '  newitem.TotalProgressReceive += pai.Amount
      ''    'End If
      ''  End If
      ''Next

      ''For Each pai As PAItem In HashSCItem.Values
      ''  If pai.HasChild Then
      ''    Me(Me.IndexOf(pai)).SetReceiveAmount(pai.TotalChildAmount)
      ''    Me(Me.IndexOf(pai)).SetReceiveMat(pai.TotalMat)
      ''    Me(Me.IndexOf(pai)).SetReceiveLab(pai.TotalLab)
      ''    Me(Me.IndexOf(pai)).SetReceiveEq(pai.TotalEq)
      ''  Else
      ''    Me(Me.IndexOf(pai)).TotalBudget = pai.ContractCostAmount
      ''    Me(Me.IndexOf(pai)).TotalReceived = pai.ReceivedAmount
      ''    Me(Me.IndexOf(pai)).TotalProgressReceive = pai.Amount
      ''  End If
      ''Next

      '' ''== Summary Ref DR Item ==================================================
      ''For Each pai As PAItem In newItemDRRef
      ''  newDrItem.TotalBudget += pai.ContractCostAmount
      ''  newDrItem.TotalReceived += pai.ReceivedAmount
      ''  newDrItem.TotalProgressReceive += pai.Amount
      ''  Me(Me.IndexOf(pai)).TotalProgressReceive = pai.Amount
      ''Next

      '' ''== Summay Not Ref SC Item ==============================================
      ''For Each pai As PAItem In newItemNotRef
      ''  If pai.Level = 0 Then
      ''    CurrentParent = pai.EntityName & "-" & pai.Unit.Code & "-" & pai.UnitPrice.ToString
      ''    HashSCItem(CurrentParent) = pai
      ''    newitem = CType(HashSCItem(CurrentParent), PAItem)
      ''    If pai.IsHasChild(Nothing) Then

      ''      newitem.TotalBudget = 0
      ''      newitem.TotalReceived = 0
      ''      newitem.TotalProgressReceive = 0

      ''      newitem.TotalChildAmount = 0
      ''      newitem.TotalMat = 0
      ''      newitem.TotalLab = 0
      ''      newitem.TotalEq = 0

      ''    End If
      ''  ElseIf pai.Level = 1 Then
      ''    Me(Me.IndexOf(pai)).TotalProgressReceive = pai.Amount
      ''    If HashSCItem.Contains(CurrentParent) Then
      ''      newitem = CType(HashSCItem(CurrentParent), PAItem)

      ''      newitem.TotalBudget += pai.ContractCostAmount
      ''      newitem.TotalReceived += pai.ReceivedAmount
      ''      newitem.TotalProgressReceive += Configuration.Format(pai.Amount, DigitConfig.Price)

      ''      newitem.TotalChildAmount += Configuration.Format(pai.Amount, DigitConfig.Price)
      ''      newitem.TotalMat += Configuration.Format(pai.Mat, DigitConfig.Price)
      ''      newitem.TotalLab += Configuration.Format(pai.Lab, DigitConfig.Price)
      ''      newitem.TotalEq += Configuration.Format(pai.Eq, DigitConfig.Price)

      ''    End If
      ''  End If
      ''Next

      ''=== Ref SC Item =====================================================
      'newitem = Nothing

      ''For Each pai As PAItem In newItemRef
      ''  'If pai.Level = 0 Then
      ''  '  If Not newitem Is Nothing Then
      ''  '    sumRow = dt.Childs.Add()
      ''  '    'sumRow.State = RowExpandState.Expanded
      ''  '    'currRow = sumRow
      ''  '    newitem.CopyToParentDataRow(sumRow)
      ''  '  End If
      ''  '  newitem = pai
      ''  'End If

      ''  '===================================
      ''  'If pai.Level = 0 Then
      ''  '  newRow = dt.Childs.Add
      ''  '  newRow.State = RowExpandState.Expanded
      ''  '  currRow = newRow
      ''  'Else
      ''  '  newRow = currRow.Childs.Add
      ''  'End If
      ''  If pai.Level = 0 Then
      ''    parentRow = dt.Childs.Add
      ''    parentRow.State = RowExpandState.Expanded
      ''    pai.CopyToDataRow(parentRow)
      ''    pai.ItemValidateRow(parentRow)
      ''    parentRow.Tag = pai
      ''  Else
      ''    If Not parentRow Is Nothing Then
      ''      childRow = parentRow.Childs.Add
      ''      pai.CopyToDataRow(childRow)
      ''      pai.ItemValidateRow(childRow)
      ''      childRow.Tag = pai
      ''    End If
      ''  End If
      ''  'newRow = dt.Childs.Add()
      ''  'pai.CopyToDataRow(newRow)
      ''  'pai.ItemValidateRow(newRow)
      ''  'newRow.Tag = pai
      ''  '===================================

      ''  Me.CurrentLastItem = pai
      ''Next
      'If Not newitem Is Nothing Then
      '  sumRow = dt.Childs.Add()
      '  'newRow.State = RowExpandState.Expanded
      '  'currRow = newRow
      '  newitem.CopyToParentDataRow(sumRow)
      'End If

      ' ''=== Ref DR Item =====================================================
      'newitem = Nothing

      'Dim DRParentItem As PAItem = Nothing
      'Dim DRParentRow As TreeRow = Nothing
      'For Each pai As PAItem In newItemDRRef
      '  '===================================

      '  If DRParentRow Is Nothing Then
      '    DRParentRow = dt.Childs.Add
      '    DRParentRow.State = RowExpandState.Expanded
      '    pai.CopyToDataRow(DRParentRow)
      '    pai.ItemValidateRow(DRParentRow)
      '    DRParentRow.Tag = pai
      '  End If


      '  'For Each prow As TreeRow In dt.Childs
      '  '  If TypeOf prow.Tag Is PAItem Then
      '  '    If Not CType(prow.Tag, PAItem).RefEntity Is Nothing AndAlso CType(prow.Tag, PAItem).RefEntity.Id = 291 AndAlso CType(prow.Tag, PAItem).Level = 0 Then
      '  '      DRParentItem = CType(prow.Tag, PAItem)
      '  '      Exit For
      '  '    End If
      '  '  End If
      '  'Next
      '  'If Not checkIsItemHashParent Then
      '  '  DRParentRow = dt.Childs.Add
      '  '  DRParentRow.State = RowExpandState.Expanded
      '  '  pai.CopyToDataRow(parentRow)
      '  '  pai.ItemValidateRow(parentRow)
      '  '  parentRow.Tag = pai
      '  'Else
      '  '  If Not DRParentRow Is Nothing Then
      '  '    childRow = DRParentRow.Childs.Add
      '  '    pai.CopyToDataRow(childRow)
      '  '    pai.ItemValidateRow(childRow)
      '  '    childRow.Tag = pai
      '  '  End If
      '  'End If


      '  '===================================

      '  '===================================
      '  'If pai.Level = 0 Then
      '  '  newRow = dt.Childs.Add
      '  '  newRow.State = RowExpandState.Expanded
      '  '  currRow = newRow
      '  'Else
      '  '  newRow = currRow.Childs.Add
      '  'End If
      '  ''If pai.Level = 0 Then
      '  ''  parentRow = dt.Childs.Add
      '  ''  parentRow.State = RowExpandState.Expanded
      '  ''  pai.CopyToDataRow(parentRow)
      '  ''  pai.ItemValidateRow(parentRow)
      '  ''  parentRow.Tag = pai
      '  ''Else
      '  ''  If Not parentRow Is Nothing Then
      '  ''    childRow = parentRow.Childs.Add
      '  ''    pai.CopyToDataRow(childRow)
      '  ''    pai.ItemValidateRow(childRow)
      '  ''    childRow.Tag = pai
      '  ''  End If
      '  ''End If
      '  'newRow = dt.Childs.Add()
      '  'pai.CopyToDataRow(newRow)
      '  'pai.ItemValidateRow(newRow)
      '  'newRow.Tag = pai
      '  '===================================

      '  Me.CurrentLastItem = pai
      'Next
      'If Not newDrItem Is Nothing AndAlso newDrItem.TotalProgressReceive <> 0 Then
      '  sumRow = dt.Childs.Add()
      '  newDrItem.CopyToParentDataRow(sumRow)
      'End If

      ''=== Not Ref SC Item =====================================================
      'If newItemNotRef.Count > 0 Then
      '  newitem = New PAItem
      '  newitem.RefEntity = New RefEntity
      '  newitem.RefEntity.Id = 0
      '  sumRow = dt.Childs.Add
      '  sumRow.State = RowExpandState.Expanded
      '  newitem.CopyToParentDataRow(sumRow, , True)
      'End If

      'newitem = Nothing
      ''For Each pai As PAItem In newItemNotRef
      ''  'If pai.Level = 0 Then
      ''  '  If Not newitem Is Nothing Then
      ''  '    sumRow = dt.Childs.Add()
      ''  '    'sumRow.State = RowExpandState.Expanded
      ''  '    'currRow = sumRow
      ''  '    newitem.CopyToParentDataRow(sumRow)
      ''  '  End If
      ''  '  newitem = pai
      ''  'End If

      ''  '===================================
      ''  'If pai.Level = 0 Then
      ''  '  newRow = dt.Childs.Add
      ''  '  newRow.State = RowExpandState.Expanded
      ''  '  currRow = newRow
      ''  'Else
      ''  '  newRow = currRow.Childs.Add
      ''  'End If
      ''  If pai.Level = 0 Then
      ''    parentRow = dt.Childs.Add
      ''    parentRow.State = RowExpandState.Expanded
      ''    pai.CopyToDataRow(parentRow)
      ''    pai.ItemValidateRow(parentRow)
      ''    parentRow.Tag = pai
      ''  Else
      ''    If Not parentRow Is Nothing Then
      ''      childRow = parentRow.Childs.Add
      ''      pai.CopyToDataRow(childRow)
      ''      pai.ItemValidateRow(childRow)
      ''      childRow.Tag = pai
      ''    End If
      ''  End If
      ''  'newRow = dt.Childs.Add()
      ''  'pai.CopyToDataRow(newRow)
      ''  'pai.ItemValidateRow(newRow)
      ''  'newRow.Tag = pai
      ''  '===================================

      ''  Me.CurrentLastItem = pai
      ''Next
      'If Not newitem Is Nothing Then
      '  sumRow = dt.Childs.Add()
      '  newitem.CopyToParentDataRow(sumRow)
      'End If


      ''=== Ref DR Item =====================================================
      'newitem = Nothing

      ''Dim DRParentItem As New PAItem
      ''DRParentItem.RefEntity = New RefEntity
      ''DRParentItem.RefEntity.Id = 291

      ''Dim DRParentRow As TreeRow = Nothing
      ''Dim DRChildRow As TreeRow = Nothing
      ''For Each pai As PAItem In newItemDRRef
      ''  '===================================

      ''  If DRParentRow Is Nothing Then
      ''    DRParentRow = dt.Childs.Add
      ''    DRParentRow.State = RowExpandState.Expanded
      ''    DRParentItem.CopyToParentDataRow(DRParentRow)
      ''    DRParentItem.ItemValidateRow(DRParentRow)
      ''    DRParentRow.Tag = pai

      ''    DRChildRow = DRParentRow.Childs.Add
      ''    pai.CopyToDataRow(DRChildRow)
      ''    pai.ItemValidateRow(DRChildRow)
      ''    DRChildRow.Tag = pai
      ''  Else
      ''    DRChildRow = DRParentRow.Childs.Add
      ''    pai.CopyToDataRow(DRChildRow)
      ''    pai.ItemValidateRow(DRChildRow)
      ''    DRChildRow.Tag = pai
      ''  End If

      ''  Me.CurrentLastItem = pai
      ''Next


      ' ''--New Summary--=============
      ''For Each srow As TreeRow In dt.Childs
      ''  If TypeOf srow.Tag Is PAItem AndAlso CType(srow.Tag, PAItem).Level = 0 Then
      ''    CType(srow.Tag, PAItem).TotalBudget = 0
      ''    CType(srow.Tag, PAItem).TotalReceived = 0
      ''    CType(srow.Tag, PAItem).TotalProgressReceive = 0
      ''    CType(srow.Tag, PAItem).TotalMat = 0
      ''    CType(srow.Tag, PAItem).TotalLab = 0
      ''    CType(srow.Tag, PAItem).TotalEq = 0

      ''    For Each crow As TreeRow In srow.Childs
      ''      If TypeOf crow.Tag Is PAItem Then
      ''        CType(srow.Tag, PAItem).TotalBudget += CType(crow.Tag, PAItem).ContractCostAmount
      ''        CType(srow.Tag, PAItem).TotalReceived += CType(crow.Tag, PAItem).ReceivedAmount
      ''        CType(srow.Tag, PAItem).TotalProgressReceive += Configuration.Format(CType(crow.Tag, PAItem).Amount, DigitConfig.Price)
      ''        CType(srow.Tag, PAItem).TotalMat += CType(crow.Tag, PAItem).Mat
      ''        CType(srow.Tag, PAItem).TotalLab += CType(crow.Tag, PAItem).Lab
      ''        CType(srow.Tag, PAItem).TotalEq += CType(crow.Tag, PAItem).Eq
      ''      End If
      ''    Next

      ''    CType(srow.Tag, PAItem).CopyToParentDataRow(srow)
      ''  End If
      ''Next
      ' ''--New Summary--=============

      ''dt.AcceptChanges()

      ''Do Until dt.Rows.Count > tg.VisibleRowCount
      ''  'เพิ่มแถวจนเต็ม
      ''  dt.Childs.Add()
      ''Loop

      ''Try
      ''  If (Not dt.Rows(dt.Rows.Count - 1).IsNull("pai_entityType")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
      ''    '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
      ''    dt.Childs.Add()
      ''  End If
      ''Catch ex As Exception

      ''End Try

      ''dt.AcceptChanges()
    End Sub
    Public Shared Function FindRow(ByVal dt As TreeTable, ByVal thePA As PA) As TreeRow
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noPAText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.BlankPRText}")   '***********แก้ไขด้วย
      For Each row As TreeRow In dt.Childs
        If thePA Is Nothing Then
          If row.Tag Is Nothing Then
            If Not row.IsNull("PAItemCode") AndAlso CStr(row("PAItemCode")) = noPAText Then
              Return row
            End If
          End If
        End If
        If TypeOf row.Tag Is PA Then
          If CType(row.Tag, PA) Is thePA Then
            Return row
          End If
        End If
      Next

      '---->ไม่เจอ
      Dim newRow As TreeRow
      Dim desc As String = ""
      If thePA Is Nothing Then
        newRow = dt.Childs.Add
        desc = noPAText
      Else
        Dim noParentRow As TreeRow = FindRow(dt, Nothing)
        newRow = dt.Childs.InsertAt(dt.Childs.IndexOf(noParentRow))
        desc = thePA.Code
        newRow.Tag = thePA
      End If
      newRow("PAItemCode") = desc
      newRow("Button") = "invisible"
      newRow("UnitButton") = "invisible"
      newRow.State = RowExpandState.Expanded
      Return newRow
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As PAItem) As Integer
      If Not m_pa Is Nothing Then
        value.Pa = m_pa
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As PAItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As PAItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As PAItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As PAItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As PAItemEnumerator
      Return New PAItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As PAItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As PAItem)
      If Not m_pa Is Nothing Then
        value.Pa = m_pa
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As PAItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


  End Class

  Public Class PAItemEnumerator
    Implements IEnumerator

#Region "Members"
    Private m_baseEnumerator As IEnumerator
    Private m_temp As IEnumerable
#End Region

#Region "Construtor"
    Public Sub New(ByVal mappings As PAItemCollection)
      Me.m_temp = mappings
      Me.m_baseEnumerator = Me.m_temp.GetEnumerator
    End Sub
#End Region

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
      Get
        Return CType(Me.m_baseEnumerator.Current, PAItem)
      End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
      Return Me.m_baseEnumerator.MoveNext
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
      Me.m_baseEnumerator.Reset()
    End Sub

  End Class

  Public Class RefEntity
    Inherits SimpleBusinessEntityBase
    Implements IHasName

    Private m_name As String

    Public Property Name() As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
      End Set
    End Property
  End Class

End Namespace
