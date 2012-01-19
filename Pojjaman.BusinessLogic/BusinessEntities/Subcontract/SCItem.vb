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
  Public Class SCIItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "sci_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Class SCItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_sc As SC
    Private m_sequence As Integer
    Private m_lineNumber As Integer
    Private m_scdescription As String
    Private m_level As Integer
    Private m_itemType As SCIItemType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Private m_qty As Decimal
    Private m_unitprice As Decimal
    Private m_mat As Decimal
    Private m_lab As Decimal
    Private m_eq As Decimal
    'Private m_amount As Decimal
    Private m_note As String
    Private m_conversion As Decimal = 1
    Private m_unvatable As Boolean = False
    Private m_tag As Object
    Private m_parent As Decimal
    Private m_state As RowExpandState
    Private m_wbsId As Integer

    Private m_wr As WR
    Private m_wriSequence As Long
    Private m_wriUnit As Unit
    Private m_wriQty As Decimal
    Private m_wriorginQty As Decimal
    Private m_unitCost As Decimal
    Private m_discount As New Discount("")
    Private m_hasChild As Boolean
    'Private m_allocateCostAmount As Decimal
    'Private m_IsNewAllocate As Boolean

    Private m_receiptAmount As Decimal
    Private m_receiptMat As Decimal
    Private m_receiptLab As Decimal
    Private m_receiptEq As Decimal
    Private m_receiptQty As Decimal

    Private m_oldQty As Decimal
    Private m_oldMat As Decimal
    Private m_oldLab As Decimal
    Private m_oldEq As Decimal
    Private m_oldAmount As Decimal

    'Private m_newChild As Boolean

    Private m_WBSDistributeCollection As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      If m_sc Is Nothing Then
        m_sc = New SC
      End If
      m_WBSDistributeCollection = New WBSDistributeCollection
      AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal id As Integer, ByVal line As Integer)
      If m_sc Is Nothing Then
        m_sc = New SC
      End If
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetSCItems" _
      , New SqlParameter("@sc_id", id) _
      , New SqlParameter("@sci_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
      Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
      AddHandler wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
      m_WBSDistributeCollection = wbsdColl
      If ds.Tables.Count > 1 Then
        For Each wbsRow As DataRow In ds.Tables(1).Select("sciw_sequence=" & Me.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          m_WBSDistributeCollection.Add(wbsd)
        Next
      End If
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      If m_sc Is Nothing Then
        m_sc = New SC
      End If
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      If m_sc Is Nothing Then
        m_sc = New SC
      End If
      Me.Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal sc As SC)
      If m_sc Is Nothing Then
        m_sc = New SC
      End If
      Me.Construct(dr, "")
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "sci_sc") AndAlso Not dr.IsNull(aliasPrefix & "sci_sc") Then
          If .m_sc Is Nothing Then
            .m_sc = New SC
          End If
          .m_sc.Id = CInt(dr("sci_sc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_sequence") AndAlso Not dr.IsNull(aliasPrefix & "sci_sequence") Then
          .m_sequence = CInt(dr("sci_sequence"))
        End If
        '
        If dr.Table.Columns.Contains(aliasPrefix & "sci_linenumber") AndAlso Not dr.IsNull(aliasPrefix & "sci_linenumber") Then
          .m_lineNumber = CInt(dr("sci_linenumber"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_level") AndAlso Not dr.IsNull(aliasPrefix & "sci_level") Then
          .m_level = CInt(dr("sci_level"))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "sci_entity") AndAlso Not dr.IsNull(aliasPrefix & "sci_entity") Then
          itemId = CInt(dr(aliasPrefix & "sci_entity"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "ReceiptAmount") AndAlso Not dr.IsNull(aliasPrefix & "ReceiptAmount") Then
          .m_receiptAmount = CDec(dr("ReceiptAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "ReceiptQty") AndAlso Not dr.IsNull(aliasPrefix & "ReceiptQty") Then
          .m_receiptQty = CDec(dr("ReceiptQty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "ReceiptMat") AndAlso Not dr.IsNull(aliasPrefix & "ReceiptMat") Then
          .m_receiptMat = CDec(dr("ReceiptMat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "ReceiptLab") AndAlso Not dr.IsNull(aliasPrefix & "ReceiptLab") Then
          .m_receiptLab = CDec(dr("ReceiptLab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "ReceiptEq") AndAlso Not dr.IsNull(aliasPrefix & "ReceiptEq") Then
          .m_receiptEq = CDec(dr("ReceiptEq"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sci_itemName") AndAlso Not dr.IsNull(aliasPrefix & "sci_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "sci_itemName"))
        Else
          .m_entityName = ""
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sci_entityType") AndAlso Not dr.IsNull(aliasPrefix & "sci_entityType") Then

          .m_itemType = New SCIItemType(CInt(dr(aliasPrefix & "sci_entityType")))

          Select Case .m_itemType.Value
            Case 42    '"lci"
              'If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              .m_entity = LCIItem.GetLciItemById(itemId)
              '  If Not dr.IsNull("lci_id") Then
              '    .m_entity = New LCIItem(dr, "")
              '  End If
              'Else
              '  .m_entity = New LCIItem(itemId)
              'End If
            Case 19    '"tool"
              If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
                If Not dr.IsNull("tool_id") Then
                  .m_entity = New Tool(dr, "")
                End If
              Else
                .m_entity = New Tool(itemId)
              End If
            Case 88, 89
              If itemId > 0 Then
                'If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
                .m_entity = LCIItem.GetLciItemById(itemId)
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

        End If


        If dr.Table.Columns.Contains(aliasPrefix & "sci_qty") AndAlso Not dr.IsNull(aliasPrefix & "sci_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "sci_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "sci_unit") AndAlso Not dr.IsNull(aliasPrefix & "sci_unit") Then
            .m_unit = Unit.GetUnitById(CInt(dr(aliasPrefix & "sci_unit")))
            '.m_unit = New Unit(CInt(dr(aliasPrefix & "sci_unit")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "sci_unitprice") Then
          .m_unitprice = CDec(dr(aliasPrefix & "sci_unitprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sci_mat") AndAlso Not dr.IsNull(aliasPrefix & "sci_mat") Then
          .m_mat = CDec(dr(aliasPrefix & "sci_mat"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sci_lab") AndAlso Not dr.IsNull(aliasPrefix & "sci_lab") Then
          .m_lab = CDec(dr(aliasPrefix & "sci_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_eq") AndAlso Not dr.IsNull(aliasPrefix & "sci_eq") Then
          .m_eq = CDec(dr(aliasPrefix & "sci_eq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_unitCost") AndAlso Not dr.IsNull(aliasPrefix & "sci_unitCost") Then
          .m_unitCost = CDec(dr(aliasPrefix & "sci_unitCost"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_note") AndAlso Not dr.IsNull(aliasPrefix & "sci_note") Then
          .m_note = CStr(dr(aliasPrefix & "sci_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sci_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "sci_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "sci_unvatable"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sci_wbs") AndAlso Not dr.IsNull(aliasPrefix & "sci_wbs") Then
          .m_wbsId = CInt(dr(aliasPrefix & "sci_wbs"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "scio_qty") AndAlso Not dr.IsNull(aliasPrefix & "scio_qty") Then
          .m_oldQty = CDec(dr(aliasPrefix & "scio_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "scio_mat") AndAlso Not dr.IsNull(aliasPrefix & "scio_mat") Then
          .m_oldMat = CDec(dr(aliasPrefix & "scio_mat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "scio_lab") AndAlso Not dr.IsNull(aliasPrefix & "scio_lab") Then
          .m_oldLab = CDec(dr(aliasPrefix & "scio_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "scio_eq") AndAlso Not dr.IsNull(aliasPrefix & "scio_eq") Then
          .m_oldEq = CDec(dr(aliasPrefix & "scio_eq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "scio_amt") AndAlso Not dr.IsNull(aliasPrefix & "scio_amt") Then
          .m_oldAmount = CDec(dr(aliasPrefix & "scio_amt"))
        End If

        If Not Me.SC.WR Is Nothing Then
          .m_wr = Me.SC.WR
          'If dr.Table.Columns.Contains(aliasPrefix & "sci_wr") AndAlso Not dr.IsNull(aliasPrefix & "sci_wr") Then
          '  If CInt(dr.IsNull(aliasPrefix & "sci_wr")) > 0 Then
          '    .m_wr = Me.SC.WR
          '  Else
          '    .m_wr = New WR
          '  End If
          'End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "sci_wr") AndAlso Not dr.IsNull(aliasPrefix & "sci_wr") Then
            .m_wr = New WR(CInt(dr(aliasPrefix & "sci_wr")))

          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sci_wrsequence") AndAlso Not dr.IsNull(aliasPrefix & "sci_wrsequence") Then
          .m_wriSequence = CLng(dr(aliasPrefix & "sci_wrsequence"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_wrunit") AndAlso Not dr.IsNull(aliasPrefix & "sci_wrunit") Then
          .m_wriUnit = Unit.GetUnitById(CInt(dr(aliasPrefix & "sci_wrunit")))
          '.m_wriUnit = New Unit
          '.m_wriUnit.Id = CInt(dr("wrunit_id"))
          '.m_wriUnit.Code = CStr(dr("wrunit_code"))
          '.m_wriUnit.Name = CStr(dr("wrunit_name"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "wrunit_id") AndAlso Not dr.IsNull(aliasPrefix & "wrunit_id") Then
        'If Not dr.IsNull("wrunit_id") Then
        '.m_wriUnit = New Unit(dr, "")
        'End If
        'Else
        'If dr.Table.Columns.Contains(aliasPrefix & "sci_wrunit") AndAlso Not dr.IsNull(aliasPrefix & "sci_wrunit") Then
        '.m_wriUnit = New Unit(CInt(dr(aliasPrefix & "sci_wrunit")))
        'End If
        'End If
        If dr.Table.Columns.Contains(aliasPrefix & "sci_wrqty") AndAlso Not dr.IsNull(aliasPrefix & "sci_wrqty") Then
          .m_wriQty = CDec(dr(aliasPrefix & "sci_wrqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wrQtyRemain") AndAlso Not dr.IsNull(aliasPrefix & "wrQtyRemain") Then
          .m_wriorginQty = CDec(dr(aliasPrefix & "wrQtyRemain"))
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            'Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              Me.Conversion = CType(Me.Entity, LCIItem).GetConversion(Me.Unit)
              'Me.Conversion = lci.GetConversion(Me.Unit)
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

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      If m_sc Is Nothing Then
        m_sc = New SC
      End If

      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    'Public Property NewChild() As Boolean
    '  Get
    '    Return m_newChild
    '  End Get
    '  Set(ByVal Value As Boolean)
    '    m_newChild = Value
    '  End Set
    'End Property
    Public Property Discount() As Discount      Get        Dim amtFormatted As Decimal = Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)        m_discount.AmountBeforeDiscount = amtFormatted        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value      End Set    End Property
    Public Property WBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection
      Get
        Return m_WBSDistributeCollection
      End Get
      Set(ByVal Value As WBSDistributeCollection)
        m_WBSDistributeCollection = Value
      End Set
    End Property
    Public Property FromCCWBSDistributeCollection() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2
      Get

      End Get
      Set(ByVal Value As WBSDistributeCollection)

      End Set
    End Property
    Public ReadOnly Property Sequence() As Integer
      Get
        Return m_sequence
      End Get
    End Property
    Public Property SC() As SC
      Get
        Return m_sc
      End Get
      Set(ByVal Value As SC)
        m_sc = Value
      End Set
    End Property
    Public Property Linenumber() As Integer
      Get
        Return m_lineNumber
      End Get
      Set(ByVal Value As Integer)
        m_lineNumber = Value
      End Set
    End Property
    Public Property SCDescription() As String
      Get
        Return m_scdescription
      End Get
      Set(ByVal Value As String)
        m_scdescription = Value
      End Set
    End Property
    Public Property Level() As Integer
      Get
        Return m_level
      End Get
      Set(ByVal Value As Integer)
        m_level = Value
      End Set
    End Property
    Public Property ItemType() As SCIItemType      Get        Return m_itemType      End Get      Set(ByVal Value As SCIItemType)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If m_itemType Is Nothing Then
          m_itemType = Value
          Me.Clear()
          Return
        End If
        If Me.SC.ItemCollection.IndexOf(Me) = 0 AndAlso Value.Value <> 289 Then
          msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SCItem.SCItemOnly}")
          Return
        End If
        If HasChild() Then
          msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SCItem.SCItemOnly}")
          Return
        End If
        If Not Value Is Nothing AndAlso Value.Value = m_itemType.Value Then
          'ผ่านโลด
          Return
        End If
        'If msgServ.AskQuestion("${res:Global.Question.ChangePREntityType}") Then
        '  Dim oldType As Integer = m_itemType.Value
        m_itemType = Value
        'For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
        '  Dim transferAmt As Decimal = Me.Amount
        '  wbsd.BaseCost = transferAmt
        '  wbsd.TransferBaseCost = transferAmt
        '  Select Case Me.ItemType.Value
        '    Case 0, 19, 42
        '      wbsd.BudgetAmount = wbsd.WBS.GetTotalMatFromDB
        '    Case 88
        '      wbsd.BudgetAmount = wbsd.WBS.GetTotalLabFromDB
        '    Case 89
        '      wbsd.BudgetAmount = wbsd.WBS.GetTotalEQFromDB
        '  End Select
        '  'Me.m_sc.SetActual(wbsd.WBS, wbsd.TransferAmount, 0, oldType)
        '  'Me.m_sc.SetActual(wbsd.WBS, 0, wbsd.TransferAmount, m_itemType.Value)
        'Next
        Me.Clear()
        '  If Value.Value = 289 Then
        '    Me.Level = 0
        '  Else
        '    Me.Level = 1
        '  End If
        'End If      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If      End Set    End Property
    Public Property ItemName() As String
      Get
        Return m_entityName
      End Get
      Set(ByVal Value As String)
        m_entityName = Value
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
    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
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
        If Me.ItemType.Value <> 289 Then
          If Not Me.WRIUnit Is Nothing AndAlso Me.WRIUnit.Id > 0 Then
            If Me.WRIUnit.Id <> Value.Id Then
              msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.SCUnitMustSameWRUnit}", New String() {Value.Name, Me.WRIUnit.Name})
              Return
            End If
          End If
        End If
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
          'Else
          '  err = "${res:Global.Error.InvalidUnit}"
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
        Else
          msgServ.ShowMessage(err)
        End If      End Set    End Property    Public Property WR As WR      Get        If m_wr Is Nothing Then          m_wr = New WR
        End If        Return m_wr
      End Get
      Set(ByVal value As WR)
        m_wr = value
      End Set
    End Property    Public Property WRISequence As Long
      Get        Return m_wriSequence
      End Get
      Set(ByVal value As Long)
        m_wriSequence = value
      End Set
    End Property    Public Property WRIUnit As Unit      Get        Return m_wriUnit
      End Get
      Set(ByVal value As Unit)
        m_wriUnit = value
      End Set
    End Property    Public Property WRIQty As Decimal      Get        Return m_wriQty
      End Get
      Set(ByVal value As Decimal)
        If Me.WR.Originated Then
        If (m_wriorginQty < value) Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.QtyOverWR}", _
                                           New String() {Configuration.FormatToString(m_wriorginQty, DigitConfig.Price), _
                                                         Configuration.FormatToString(value, DigitConfig.Price)})
          Return
        End If
        m_wriQty = value
        End If
      End Set
    End Property    Public ReadOnly Property WRIOriginQty As Decimal
      Get
        Return m_wriorginQty
      End Get
    End Property
    Public Sub SetWRIQty(ByVal qty As Decimal)
      m_wriQty = qty
    End Sub
    Public Sub SetWRIOrigingQty(ByVal qty As Decimal)
      m_wriorginQty = qty
    End Sub
  
    Public Sub UpdateWBSQty()
      Select Case Me.ItemType.Value
        Case 88, 89, 160, 162
          For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
            wbsd.BaseQty = 0
          Next
        Case Else
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
      End Select
    End Sub    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
            Return
          Case 289
            'Do nothing
          Case Else
            If Me.WRIQty > 0 Then
              ''If Me.Unit.Equals(Me.WRIUnit) Then ' AndAlso Me.WRIOriginQty < Value Then  '????? WRIOriginQty คือจำนวนคงเหลือตอนทำเอกสารรึเป่า
              ''  msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.SCiQtyMustLessThanOrEqualWRiQty}", _
              ''                                New String() {Configuration.FormatToString(Value, DigitConfig.Qty), _
              ''                                              Configuration.FormatToString(WRIOriginQty, DigitConfig.Qty)})
              ''  Return
              ''ElseIf Me.Unit.Equals(Me.WRIUnit) Then
              If Value < WRIQty Then
                SetWRIQty(Value)
              End If
              ''End If
            End If
        End Select        'Dim amt As Decimal = Value * Me.UnitPrice
        'Select Case Me.ItemType.Value
        '  Case 0, 19, 28, 42
        '    Me.m_mat = amt
        '    Me.m_lab = 0
        '    Me.m_eq = 0
        '  Case 88
        '    Me.m_mat = 0
        '    Me.m_lab = amt
        '    Me.m_eq = 0
        '  Case 89
        '    Me.m_mat = 0
        '    Me.m_lab = 0
        '    Me.m_eq = amt
        '  Case 289
        '    If amt <= Me.Amount Then
        '      Me.m_mat = 0
        '      Me.m_lab = amt
        '      Me.m_eq = 0
        '    Else
        '      Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
        '      m_lab = (amt - amt2) + Me.Lab
        '    End If
        'End Select        If IsNumeric(Value) Then          m_qty = Configuration.Format(Value, DigitConfig.Qty)
        Else
          m_qty = 0
        End If        Me.RecalculateReceiveAmount()        'UpdateWBSQty()      End Set    End Property
    Public Property UnitPrice() As Decimal      Get        Return m_unitprice      End Get      Set(ByVal Value As Decimal)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          'ไม่มี Type
          msgServ.ShowMessage("${res:Global.Error.NoItemType}")
          Return
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
            Return
        End Select        'Dim amt As Decimal = Value * Me.Qty        'Select Case Me.ItemType.Value
        '  Case 0, 19, 28, 42
        '    Me.m_mat = amt
        '    Me.m_lab = 0
        '    Me.m_eq = 0
        '  Case 88
        '    Me.m_mat = 0
        '    Me.m_lab = amt
        '    Me.m_eq = 0
        '  Case 89
        '    Me.m_mat = 0
        '    Me.m_lab = 0
        '    Me.m_eq = amt
        '  Case 289
        '    If amt <= Me.Amount Then
        '      Me.m_mat = 0
        '      Me.m_lab = amt
        '      Me.m_eq = 0
        '    Else
        '      Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
        '      m_lab = (amt - amt2) + Me.Lab
        '    End If
        'End Select        m_unitprice = Value        Me.SC.RefreshRealGross()        Me.RecalculateReceiveAmount()        'UpdateWBS()      End Set    End Property
    Public Property Mat() As Decimal
      Get
        Return m_mat
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 88 OrElse _
            Me.ItemType.Value = 89 OrElse _
            Me.ItemType.Value = 160 Then
          Return
        End If
        If Value >= Me.Amount Then
          m_mat = Me.Amount
          m_lab = 0
          m_eq = 0
        End If
        If Me.ItemType.Value = 289 Then
          m_lab = Me.Amount - Value - Me.Eq
        End If
        Dim m_value As Decimal = Value + Me.Lab + Me.Eq
        If m_value > Me.Amount Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          New String() {Me.ItemDescription, Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                       Configuration.FormatToString(m_value, DigitConfig.Price)})
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
        If Me.ItemType.Value = 88 OrElse _
           Me.ItemType.Value = 289 Then
          If Value >= Me.Amount Then
            m_mat = 0
            m_lab = Me.Amount
            m_eq = 0
          End If
          Dim m_value As Decimal = Me.Mat + Value + Me.Eq
          If m_value > Me.Amount Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
            New String() {Me.ItemDescription, Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                         Configuration.FormatToString(m_value, DigitConfig.Price)})
            Return
          Else
            m_lab = Value
          End If
        End If
      End Set
    End Property
    Public Property Eq() As Decimal
      Get
        Return m_eq
      End Get
      Set(ByVal Value As Decimal)
        If Me.ItemType.Value = 89 OrElse _
           Me.ItemType.Value = 289 Then
          If Value >= Me.Amount Then
            m_mat = 0
            m_lab = 0
            m_eq = Me.Amount
          End If
          If Me.ItemType.Value = 289 Then
            m_lab = Me.Amount - Me.Mat - Value
          End If
          Dim m_value As Decimal = Me.Mat + Me.Lab + Value
          If m_value > Me.Amount Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
            New String() {Me.ItemDescription, Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                         Configuration.FormatToString(m_value, DigitConfig.Price)})
            Return
          Else
            m_eq = Value
          End If
        End If
      End Set
    End Property
    Public ReadOnly Property StockQty() As Decimal      Get        Return Configuration.Format(Me.Conversion * Me.Qty, DigitConfig.Qty)      End Get    End Property
    Public ReadOnly Property Amount() As Decimal 'Implements IWBSAllocatableItem.ItemAmount
      Get
        If Not Me.SC Is Nothing AndAlso Me.SC.Closing Then
          Return Me.ReceiptAmount
        End If
        Return Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
      End Get
    End Property
    Public ReadOnly Property UnitCost() As Decimal 'Implements IWBSAllocatableItem.ItemAmount
      Get
        If Me.StockQty <> 0 Then
          Dim tmpCost As Decimal = 0
          Dim tmpRealGrossNoVat As Decimal = 0

          tmpRealGrossNoVat = Me.SC.RealGross

          If tmpRealGrossNoVat = 0 Then
            Return 0
          End If

          tmpCost = Me.AmountWithDefaultUnit

          tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.SC.Discount.Amount)

          If Me.SC.TaxType.Value = 2 Then
            If Not Me.Unvatable Then
              tmpCost = tmpCost * (100 / (100 + Me.SC.TaxRate))
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
    End Property
    Public Sub RecalculateReceiveAmount()
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Select Case Me.ItemType.Value
        Case 160, 162
          'เป็นหมายเหตุ/หมายเหตุอ้างอิง มีปริมาณไม่ได้
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveUnitPrice}")
          Return
      End Select
      Dim m_cost As Decimal = Me.CostAmount
      Trace.WriteLine(m_cost.ToString)      Select Case Me.ItemType.Value
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
    Public ReadOnly Property CostAmount() As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        'If IsNewAllocate Then
        '  Return AllocateCostAmount
        'End If
        'Return UnitCost * Me.StockQty
        Dim tmpCost As Decimal = Me.UnitCost * Me.StockQty
          tmpCost = Me.Amount
          Dim tmpRealGrossNoVat As Decimal = 0
          tmpRealGrossNoVat = Me.SC.RealGrossWithNoDeductItem

          If tmpRealGrossNoVat = 0 Then
            Return 0
          End If
          tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.SC.Discount.Amount)

          If Me.SC.TaxType.Value = 2 Then
            If Not Me.Unvatable Then
              tmpCost = tmpCost * (100 / (100 + Me.SC.TaxRate))
            End If
          End If
        Return tmpCost
      End Get
    End Property
    Public Property OldQty() As Decimal
      Get
        Return m_oldQty
      End Get
      Set(ByVal Value As Decimal)
        m_oldQty = Value
      End Set
    End Property
    Public Property OldMat() As Decimal
      Get
        Return m_oldMat
      End Get
      Set(ByVal Value As Decimal)
        m_oldMat = Value
      End Set
    End Property
    Public Property OldLab() As Decimal
      Get
        Return m_oldLab
      End Get
      Set(ByVal Value As Decimal)
        m_oldLab = Value
      End Set
    End Property
    Public Property OldEq() As Decimal
      Get
        Return m_oldEq
      End Get
      Set(ByVal Value As Decimal)
        m_oldEq = Value
      End Set
    End Property
    Public Property OldAmount() As Decimal
      Get
        Return m_oldAmount
      End Get
      Set(ByVal Value As Decimal)
        m_oldAmount = Value
      End Set
    End Property
    'Dim m_isSetNewAllocate As Boolean = False
    'Public Property IsSetNewAllocate() As Boolean
    '  Get
    '    Return m_isSetNewAllocate
    '  End Get
    '  Set(ByVal Value As Boolean)
    '    m_isSetNewAllocate = Value
    '  End Set
    'End Property
    'Public Property AllocateCostAmount() As Decimal
    '  Get
    '    Return m_allocateCostAmount
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_allocateCostAmount = Value
    '  End Set
    'End Property
    'Public Property IsNewAllocate() As Boolean
    '  Get
    '    Return m_IsNewAllocate
    '  End Get
    '  Set(ByVal Value As Boolean)
    '    m_IsNewAllocate = Value
    '  End Set
    'End Property
    Public ReadOnly Property AmountWithDefaultUnit() As Decimal
      Get
        If StockQty > 0 Then
          Return ((Me.UnitPrice / Me.Conversion) * StockQty) '- (Me.Discount.Amount / Me.Conversion)
        Else
          Return 0
        End If
      End Get
    End Property
    Public Property ReceiptAmount() As Decimal
      Get
        Return m_receiptAmount
      End Get
      Set(ByVal Value As Decimal)
        m_receiptAmount = Value
      End Set
    End Property
    Public Property ReceiptQty() As Decimal
      Get
        Return m_receiptQty
      End Get
      Set(ByVal Value As Decimal)
        m_receiptQty = Value
      End Set
    End Property

    Public Property ReceiptMat() As Decimal
      Get
        Return m_receiptMat
      End Get
      Set(ByVal Value As Decimal)
        m_receiptMat = Value
      End Set
    End Property
    Public Property ReceiptLab() As Decimal
      Get
        Return m_receiptLab
      End Get
      Set(ByVal Value As Decimal)
        m_receiptLab = Value
      End Set
    End Property
    Public Property ReceiptEq() As Decimal
      Get
        Return m_receiptEq
      End Get
      Set(ByVal Value As Decimal)
        m_receiptEq = Value
      End Set
    End Property

    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.SC Is Nothing Then        Return False
      End If      If Me.ItemType Is Nothing Then
        Return False
      End If
      If Me.ItemType.Value = 42 OrElse Me.ItemType.Value = 88 OrElse Me.ItemType.Value = 89 Then
        'Material ใส่ Code เดียวกันได้
        Return False
      End If
      If myCode Is Nothing OrElse myCode.Length = 0 Then
        Return False
      End If
      For Each item As SCItem In Me.SC.ItemCollection
        If Not item Is Me Then ' AndAlso Not item.NewChild Then
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
        Case 289
          msgServ.ShowMessage("${res:Global.Error.SCItemCannotHaveCode}")
          Return
        Case 160, 162
          msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveCode}")
          Return
        Case 0  ', 88, 89				'Blank
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
                , New SqlParameter("@sci_entity", myTool.Id) _
                , New SqlParameter("@sci_entitytype", myTool.EntityId) _
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
        Case 42, 88, 89   'LCI
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
                unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
                , New SqlParameter("@sci_entity", lci.Id) _
                , New SqlParameter("@sci_entitytype", lci.EntityId) _
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
    End Sub    Public Property Unvatable() As Boolean      Get
        Return m_unvatable
      End Get
      Set(ByVal Value As Boolean)
        m_unvatable = Value
      End Set
    End Property    Public Property WBSId() As Integer      Get
        Return m_wbsId
      End Get
      Set(ByVal Value As Integer)
        m_wbsId = Value
      End Set
    End Property    Public Property Parent() As Decimal      Get
        Return m_parent
      End Get
      Set(ByVal Value As Decimal)
        m_parent = Value
      End Set
    End Property    Public Sub SetItemPrice(ByVal theCode As String)      Dim unitPrice As Decimal = 0
      Dim pricing As Integer = CInt(Configuration.GetConfig("CompanyPRPricing"))      Select Case Me.ItemType.Value
        Case 19    'Tool
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim myTool As New Tool(theCode)

          Select Case pricing
            Case 0
              unitPrice = myTool.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
              , New SqlParameter("@sci_entity", myTool.Id) _
              , New SqlParameter("@sci_entitytype", myTool.EntityId) _
              )
          End Select
          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice
          Me.Qty = 1
        Case 42, 88, 89   'LCI
          If theCode Is Nothing OrElse theCode.Length = 0 Then
            Return
          End If
          Dim lci As New LCIItem(theCode)

          Select Case pricing
            Case 0
              unitPrice = lci.FairPrice
            Case 2
              unitPrice = GetAmountFromSproc("GetPRPriceForSupplier" _
              , New SqlParameter("@sci_entity", lci.Id) _
              , New SqlParameter("@sci_entitytype", lci.EntityId) _
              )
          End Select
          If Me.Conversion <> 0 Then
            unitPrice = unitPrice * Conversion
          End If
          Me.UnitPrice = unitPrice
          Me.Qty = 1

        Case Else
      End Select
    End Sub    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Me.ItemType Is Nothing Then
          If Me.Level > 0 Then
            'ไม่มี Type
            msgServ.ShowMessage("${res:Global.Error.NoItemType}")
            Return
          Else
            'รายการ sc (งาน)
            Me.m_entityName = Value
            Return
          End If
        End If
        Select Case Me.ItemType.Value
          Case 19, 42
            If Not Me.Entity.Code Is Nothing AndAlso Me.Entity.Code.Length > 0 Then
              'มี Code อยู่ ---> 
              Me.m_entityName = Value
            Else
              msgServ.ShowMessage("${res:Global.Error.ItemCodeMissing}")
            End If
          Case Else     '0, 28, 88, 89, 160, 162
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
    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property
    Public Property State() As RowExpandState
      Get
        Return m_state
      End Get
      Set(ByVal Value As RowExpandState)
        m_state = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Private Sub ItemWRValidateRow(ByVal row As DataRow)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim sci_wriqty As Object = row("sci_wriqty")
      'Dim sci_wr As Integer = CInt(row("sci_wr"))
      If Me.WR.Originated Then
        If IsDBNull(sci_wriqty) OrElse Not IsNumeric(sci_wriqty) OrElse CDec(sci_wriqty) <= 0 Then
          If Not Me.WR Is Nothing AndAlso Me.WR.Id <> 0 AndAlso Me.WRISequence > 0 Then
            row.SetColumnError("sci_wriqty", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
          Else
            row.SetColumnError("sci_wriqty", "")
          End If
        Else
          row.SetColumnError("sci_wriqty", "")
        End If
      Else
        row.SetColumnError("sci_wriqty", "")
      End If
    End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim code As Object = row("code")
      Dim sci_itemname As Object = row("sci_itemname")
      Dim sci_entitytype As Object = row("sci_entitytype")
      Dim unit As Object = row("unit")
      Dim sci_qty As Object = row("sci_qty")

      Dim isClosed As Boolean = False
      isClosed = Me.SC.Closed

      Dim isBlankRow As Boolean = False
      If IsDBNull(sci_entitytype) Then
        isBlankRow = True
      End If
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not isBlankRow Then
        Select Case CInt(sci_entitytype)
          Case 289
            If (IsDBNull(sci_qty) OrElse Not IsNumeric(sci_qty) OrElse CDec(sci_qty) <= 0) AndAlso Not Me.SC.Closing Then
              row.SetColumnError("sci_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("sci_qty", "")
            End If
            If IsDBNull(sci_itemname) OrElse sci_itemname.ToString.Length = 0 Then
              row.SetColumnError("sci_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("sci_itemname", "")
            End If
            row.SetColumnError("code", "")
            ItemWRValidateRow(row)
          Case 160, 162
            row.SetColumnError("sci_qty", "")
            row.SetColumnError("sci_itemname", "")
            row.SetColumnError("code", "")
          Case 0, 88, 89    'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(sci_itemname) OrElse sci_itemname.ToString.Length = 0 Then
              row.SetColumnError("sci_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("sci_itemname", "")
            End If
            If (IsDBNull(sci_qty) OrElse Not IsNumeric(sci_qty) OrElse CDec(sci_qty) <= 0) AndAlso Not Me.SC.Closing Then
              row.SetColumnError("sci_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("sci_qty", "")
            End If
            ItemWRValidateRow(row)
          Case 19    'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(sci_itemname) OrElse sci_itemname.ToString.Length = 0 Then
              row.SetColumnError("sci_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("sci_itemname", "")
            End If
            If (IsDBNull(sci_qty) OrElse Not IsNumeric(sci_qty) OrElse CDec(sci_qty) <= 0) AndAlso Not Me.SC.Closing Then
              row.SetColumnError("sci_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("sci_qty", "")
            End If
            ItemWRValidateRow(row)
          Case 28    'F/A
            If IsDBNull(sci_itemname) OrElse sci_itemname.ToString.Length = 0 Then
              row.SetColumnError("sci_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("sci_itemname", "")
            End If
            If (IsDBNull(sci_qty) OrElse Not IsNumeric(sci_qty) OrElse CDec(sci_qty) <= 0) AndAlso Not Me.SC.Closing Then
              row.SetColumnError("sci_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("sci_qty", "")
            End If
            row.SetColumnError("code", "")
          Case 42    'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(sci_itemname) OrElse sci_itemname.ToString.Length = 0 Then
              row.SetColumnError("sci_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("sci_itemname", "")
            End If
            If (IsDBNull(sci_qty) OrElse Not IsNumeric(sci_qty) OrElse CDec(sci_qty) <= 0) AndAlso Not Me.SC.Closing Then
              row.SetColumnError("sci_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("sci_qty", "")
            End If
            ItemWRValidateRow(row)
          Case Else
            Return
        End Select
      End If
    End Sub
    Public Sub Clear()
      Me.m_entity = New BlankItem("")
      Me.m_entityName = ""
      Me.m_qty = 0
      Me.m_unit = New Unit
      Me.m_unitprice = 0
      Me.m_note = ""
      Me.m_wriSequence = 0
      Me.m_wriQty = 0
      Me.m_wriorginQty = 0
      Me.m_wr = New WR
      Me.m_wriUnit = New Unit
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.SC.IsInitialized = False
        If Me.Level = 0 Then
          row.FixLevel = 1
          row.CustomFontStyle = FontStyle.Bold
        Else
          row.FixLevel = -1
        End If

        row("sci_linenumber") = Me.Linenumber
        row("sci_level") = Me.Level
        'row("sci_scdesc") = Me.SCDescription

        Dim m_Entity_Name As String = Space(5) & Trim(Me.Entity.Name)
        Dim m_EntityName As String = Space(5) & Trim(Me.EntityName)

        If Not Me.ItemType Is Nothing Then
          row("sci_entityType") = Me.ItemType.Value
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("sci_entity") = Me.Entity.Id
                row("sci_itemName") = m_Entity_Name
                row("EntityName") = m_Entity_Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("sci_itemName") = EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                If TypeOf (Me.Entity) Is LCIItem Then
                  row("sci_entity") = Me.Entity.Id
                  row("sci_itemName") = m_Entity_Name
                  row("EntityName") = m_Entity_Name
                  row("Code") = Me.Entity.Code
                  If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                    If Me.Entity.Name <> Me.EntityName Then
                      row("sci_itemName") = m_EntityName & "<" & m_Entity_Name & ">"
                    End If
                  End If
                Else
                  row("Button") = "invisible"
                  row("sci_itemName") = m_EntityName
                End If
                row("Button") = ""
              End If
            Case 0, 28      ', 88, 89
              row("Button") = "invisible"
              row("sci_itemName") = m_EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("sci_itemName") = m_EntityName
            Case 289
              row("Button") = "invisible"
              row("sci_itemName") = Trim(m_EntityName)
          End Select

        End If

        If Not Me.Unit Is Nothing Then
          row("sci_unit") = Me.Unit.Id
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

        'If Me.Qty <> 0 Then
        '  row("sci_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        'Else
        '  'If Me.Pr.Closed Then
        '  'row("sci_qty") = "0"
        '  'Else
        '  row("sci_qty") = ""
        '  'End If
        'End If

        If Me.Qty <> 0 Then
          row("sci_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("sci_qty") = ""
        End If

        If Me.Mat <> 0 Then
          row("sci_mat") = Configuration.FormatToString(Me.Mat, DigitConfig.Price)
        Else
          row("sci_mat") = ""
        End If
        If Me.Lab <> 0 Then
          row("sci_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
        Else
          row("sci_lab") = ""
        End If
        If Me.Eq <> 0 Then
          row("sci_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
        Else
          row("sci_eq") = ""
        End If


        If Me.UnitPrice <> 0 Then
          row("sci_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("sci_unitprice") = ""
        End If

        If Me.Amount <> 0 Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If

        If Me.ReceiptAmount <> 0 Then
          row("PAAmount") = Configuration.FormatToString(Me.ReceiptAmount, DigitConfig.Price)
        Else
          row("PAAmount") = ""
        End If

        'If Me.OriginAmount <> 0 Then
        '    row("sci_originamt") = Configuration.FormatToString(Me.OriginAmount, DigitConfig.Price)
        'Else
        '    row("sci_originamt") = ""
        'End If

        row("sci_note") = Me.Note


        row("sci_unvatable") = Me.Unvatable

        If Not Me.WRIUnit Is Nothing Then
          row("sci_wriUnit") = Me.WRIUnit.Id
          row("WRUnit") = Me.WRIUnit.Name
        End If

        If Me.WRIQty > 0 Then
          row("sci_wriQty") = Configuration.FormatToString(Me.WRIQty, DigitConfig.Qty)
        End If

        Me.SC.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Function IsHasChild(Optional ByVal CurrentItemIsMe As Boolean = False) As Boolean
      Dim doc As SCItem = Nothing
      If Not CurrentItemIsMe Then
        doc = Me.SC.ItemCollection.CurrentItem
      Else
        doc = Me
      End If
      If doc Is Nothing Then
        Return False
      End If
      If doc.Level = 1 Then
        Return False
      End If

      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim currItem As SCItem = Me.SC.ItemCollection(i)
          If currItem.Level = 0 Then
            Exit For
          End If
          If currItem.ItemType.Value <> 160 AndAlso currItem.ItemType.Value <> 162 Then
            lastIndex = i
          End If
        End If
        'End If
      Next

      If startIndex < lastIndex Then
        Return True
      End If

      Return False

    End Function
    Public Function ChildAmount() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0



      'Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      'Dim startIndex As Integer = lastIndex

      'For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
      '  'If Not Me.SC.ItemCollection(i).NewChild Then
      '  If i > startIndex Then
      '    Dim sci As SCItem = Me.SC.ItemCollection(i)
      '    If sci.Level = 0 Then
      '      Exit For
      '    End If
      '    lastIndex = i
      '    m_childAmount += sci.Amount
      '  End If
      '  'End If
      'Next

      'If startIndex = lastIndex Then
      '  Return Me.Amount
      'End If

      Return m_childAmount
    End Function
    Public Function ChildMat() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim sci As SCItem = Me.SC.ItemCollection(i)
          If sci.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += Configuration.Format(sci.Mat, DigitConfig.Price)
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Mat
      End If

      Return m_childAmount
    End Function
    Public Function ChildLab() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim sci As SCItem = Me.SC.ItemCollection(i)
          If sci.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += Configuration.Format(sci.Lab, DigitConfig.Price)
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Lab
      End If

      Return m_childAmount
    End Function
    Public Function ChildEq() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim sci As SCItem = Me.SC.ItemCollection(i)
          If sci.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += Configuration.Format(sci.Eq, DigitConfig.Price)
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Eq
      End If

      Return m_childAmount
    End Function
    Public Function GetChildAmount() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim sci As SCItem = Me.SC.ItemCollection(i)
          If sci.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += sci.Amount
        End If
        'End If
      Next

      'If startIndex = lastIndex Then
      '  Return Me.Eq
      'End If

      Return m_childAmount
    End Function
    Public Function GetChildMat() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim sci As SCItem = Me.SC.ItemCollection(i)
          If sci.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += sci.Mat
        End If
        'End If
      Next

      'If startIndex = lastIndex Then
      '  Return Me.Mat
      'End If

      Return m_childAmount
    End Function
    Public Function GetChildLab() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim sci As SCItem = Me.SC.ItemCollection(i)
          If sci.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += sci.Lab
        End If
        'End If
      Next

      'If startIndex = lastIndex Then
      '  Return Me.Lab
      'End If

      Return m_childAmount
    End Function
    Public Function GetChildEq() As Decimal
      Dim doc As SCItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.SC.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.SC.ItemCollection.Count - 1
        'If Not Me.SC.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim sci As SCItem = Me.SC.ItemCollection(i)
          If sci.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += sci.Eq
        End If
        'End If
      Next

      'If startIndex = lastIndex Then
      '  Return Me.Eq
      'End If

      Return m_childAmount
    End Function
    Public Sub SetUnitPrice(ByVal value As Decimal)
      m_unitprice = value
    End Sub
    Public Sub SetMat(ByVal value As Decimal)
      m_mat = value
    End Sub
    Public Sub SetLab(ByVal value As Decimal)
      m_lab = value
    End Sub
    Public Sub SetEq(ByVal value As Decimal)
      m_eq = value
    End Sub
    Public Sub SetQty(ByVal value As Decimal)
      m_qty = value
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetSCItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("SCItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("m_sc", GetType(Integer)))
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
        If Not inValidIds.Contains(CInt(tableRow("sci_pr"))) Then
          Dim sci As New SCItem(tableRow, "")
          Dim row As TreeRow = myDatatable.Childs.Add
          row("Selected") = False
          row("Code") = tableRow("sc_code")
          row("m_sc") = tableRow("sci_sc")

          Dim scId As Integer
          If Not row.IsNull("m_sc") Then
            scId = CInt(row("m_sc"))
          End If

          row("Linenumber") = tableRow("sci_linenumber")
          row("Date") = tableRow("sc_docdate")
          row("ReceivingDate") = tableRow("sc_receivingdate")

          Dim entityText As String = ""
          If Not sci.ItemType Is Nothing Then
            entityText &= sci.ItemType.Description & ":"
          End If
          If Not sci.Entity.Code Is Nothing AndAlso sci.Entity.Code.Length > 0 Then
            entityText &= sci.Entity.Code & ":"
          End If
          If Not sci.Entity.Name Is Nothing AndAlso sci.Entity.Name.Length > 0 Then
            entityText &= sci.Entity.Name
          End If
          row("Entity") = entityText
          row("Qty") = sci.Qty
          row("Requestor") = tableRow("requestorinfo")
          row("CostCenter") = tableRow("ccinfo")
          row.State = RowExpandState.None

          sci.SC = New SC
          sci.SC.Id = scId
          row.Tag = sci
        End If
      Next
      Return myDatatable
    End Function
    Private Shared Function GetPRIdWithOnlyNoteItem(ByVal dt As DataTable) As ArrayList
      Dim arr As New ArrayList
      Dim tmpId As Integer = 0
      For Each tableRow As DataRow In dt.Rows
        If tmpId <> CInt(tableRow("sci_pr")) Then
          tmpId = CInt(tableRow("sci_pr"))
          If Not arr.Contains(tmpId) Then
            arr.Add(tmpId)
          End If
        End If
      Next
      Dim realArr As New ArrayList
      For Each id As Integer In arr
        Dim rows As DataRow() = dt.Select("sci_sc = " & id)
        Dim found As Boolean = False
        For Each row As DataRow In rows
          Dim sci As New SCItem(row, "")
          'If sci.OrderedQty <> 0 Or sci.Qty <> 0 Then
          '    found = True
          '    Exit For
          'End If
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

    Public Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements IWBSAllocatableItem.WBSChangedHandler
      If TypeOf sender Is WBSDistribute Then
        Dim wbsd As WBSDistribute = CType(sender, WBSDistribute)
        Select Case e.Name.ToLower
          Case "percent"
            If Not Me.m_sc Is Nothing Then

              'Me.m_sc.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "amount"
            If Not Me.m_sc Is Nothing Then

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
            wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.SC.Id, Me.SC.EntityId, Me.ItemType.Value)
            wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.SC.Id, Me.SC.EntityId, Me.Entity.Id, _
                                                                        Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
        End Select
      End If
    End Sub
    Public ReadOnly Property AllocationErrorMessage() As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        'If IsNewAllocate Then
        '  Return ""
        'End If
        If Me.ItemType Is Nothing Then
          Return "No Item Type"
        End If
        Select Case Me.ItemType.Value
          Case 160, 162
            Return "${res:Global.Error.NoteCannotHaveWBS}"
          Case 289
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
          Case 88, 289
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
        Dim indent As String = ""
        If Me.ItemType.Value <> 289 Then
          indent = Space(5)
        End If
        If Me.ItemType Is Nothing Then
          Return ""
        End If

        Return indent & ItemType.Description

      End Get
    End Property

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class SCItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_sc As SC
    Private m_currentItem As SCItem
    Private m_currentRealItem As SCItem
    Private m_gridVisibleRowCount As Integer

    Dim m_hashWBSItems As Hashtable
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As SC)
      Me.m_sc = owner
      m_hashWBSItems = New Hashtable
      If Not Me.m_sc.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetSCItems" _
      , New SqlParameter("@sc_id", Me.m_sc.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New SCItem(row, m_sc)
        item.SC = m_sc
        Me.Add(item)
        m_hashWBSItems(item.WBSId) = item
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        If ds.Tables.Count > 1 Then
          For Each wbsRow As DataRow In ds.Tables(1).Select("sciw_sequence=" & item.Sequence)
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

      'RefreshBudget()
      'RefreshAccumulateRemain()
    End Sub
    Public Sub RefreshAccumulateRemain()
      Dim hashWBS As New Hashtable
      Dim key As String = ""
      Dim summary As Decimal = 0
      For Each itm As SCItem In Me
        'If Not itm.NewChild Then
        For Each wbsitm As WBSDistribute In itm.WBSDistributeCollection
          If key <> wbsitm.WBS.Id.ToString & ":" & wbsitm.CostCenter.Id.ToString Then
            key = wbsitm.WBS.Id.ToString & ":" & wbsitm.CostCenter.Id.ToString

            wbsitm.RemainSummary = wbsitm.BudgetRemain - wbsitm.Amount
          End If
        Next
        'End If
      Next
    End Sub
    Public Sub RefreshBudget()
      'For Each item As SCItem In Me
      '  Dim transferAmt As Decimal = item.Amount
      '  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
      '    '--------------------------------------------------
      '    wbsd.BaseCost = transferAmt
      '    wbsd.TransferBaseCost = transferAmt
      '    If Not wbsd.IsMarkup Then
      '      'เป็น WBS
      '      Dim actual As Decimal = 0
      '      Dim budget As Decimal = 0
      '      Dim current As Decimal = 0
      '      Dim budgetQty As Decimal = 0
      '      Dim actualQty As Decimal = 0
      '      Dim currentQty As Decimal = 0

      '      Dim theName As String = item.EntityName
      '      If theName Is Nothing Then
      '        theName = item.Entity.Name
      '      End If
      '      Select Case item.ItemType.Value
      '        Case 0      'อื่นๆ
      '          actual = wbsd.WBS.GetActualMat(item.SC, 6)
      '          budget = wbsd.WBS.GetTotalMatFromDB

      '          budgetQty = wbsd.WBS.GetBudgetQtyForType0FromDB(theName)
      '          actualQty = wbsd.WBS.GetActualType0Qty(item.SC, 6)
      '        Case 19      'Tool
      '          actual = wbsd.WBS.GetActualMat(item.SC, 6)
      '          budget = wbsd.WBS.GetTotalMatFromDB

      '          budgetQty = 0       'ไม่มี budget ให้เครื่องมือแน่ๆ
      '          actualQty = wbsd.WBS.GetActualMatQty(item.SC, 6, item.Entity.Id, 19)
      '        Case 42      'Mat
      '          actual = wbsd.WBS.GetActualMat(item.SC, 6)
      '          budget = wbsd.WBS.GetTotalMatFromDB

      '          budgetQty = wbsd.WBS.GetTotalMatQtyFromDB(item.Entity.Id)
      '          actualQty = wbsd.WBS.GetActualMatQty(item.SC, 6, item.Entity.Id, 42)
      '        Case 88      'Lab
      '          actual = wbsd.WBS.GetActualLab(item.SC, 6)
      '          budget = wbsd.WBS.GetTotalLabFromDB

      '          budgetQty = wbsd.WBS.GetTotalLabQtyFromDB(theName)
      '          actualQty = wbsd.WBS.GetActualLabQty(item.SC, 6)
      '        Case 89      'Eq
      '          actual = wbsd.WBS.GetActualEq(item.SC, 6)
      '          budget = wbsd.WBS.GetTotalEQFromDB

      '          budgetQty = wbsd.WBS.GetTotalEQQtyFromDB(theName)
      '          actualQty = wbsd.WBS.GetActualEqQty(item.SC, 6)
      '      End Select

      '      'Dim theHash As Hashtable
      '      'Select Case item.ItemType.Value
      '      '    Case 0, 19, 42
      '      '        theHash = item.SC.MatActualHash
      '      '    Case 88
      '      '        theHash = item.SC.LabActualHash
      '      '    Case 89
      '      '        theHash = item.SC.EQActualHash
      '      'End Select
      '      'If Not theHash Is Nothing Then
      '      '    Dim o_n As OldNew
      '      '    If Not theHash.Contains(wbsd.WBS.Id) Then
      '      '        o_n = New OldNew
      '      '        o_n.OldValue = actual
      '      '        o_n.NewValue = actual
      '      '        theHash(wbsd.WBS.Id) = o_n
      '      '    Else
      '      '        o_n = CType(theHash(wbsd.WBS.Id), OldNew)
      '      '        o_n.OldValue += actual
      '      '        o_n.NewValue += actual
      '      '    End If
      '      'End If

      '      'Dim budgetRemain As Decimal = budget - actual
      '      'Dim budgetRemain As Decimal = wbsd.BudgetAmount - actual
      '      'If budgetRemain < 0 Then
      '      '    wbsd.AmountOverBudget = True
      '      'Else
      '      '    wbsd.AmountOverBudget = False
      '      'End If
      '      ''wbsd.BudgetAmount = budget
      '      'wbsd.BudgetRemain = budgetRemain

      '      Dim qtyRemain As Decimal = budgetQty - actualQty
      '      If qtyRemain < 0 AndAlso Not wbsd.WBS.NoQtyControl Then
      '        wbsd.QtyOverBudget = True
      '      Else
      '        wbsd.QtyOverBudget = False
      '      End If
      '      wbsd.BudgetQty = budgetQty
      '      wbsd.QtyRemain = qtyRemain
      '    Else
      '      'เป็น markup
      '      Dim mk As New Markup(wbsd.WBS.Id)
      '      If Not mk Is Nothing Then
      '        wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.SC, 6) - item.SC.GetCurrentAmountForMarkup(mk)
      '      End If
      '    End If
      '    '--------------------------------------------------
      '  Next
      'Next
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
    Default Public Property Item(ByVal index As Integer) As SCItem
      Get
        Return CType(MyBase.List.Item(index), SCItem)
      End Get
      Set(ByVal value As SCItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim amt As Decimal = 0        For Each item As SCItem In Me
          'If Not item.NewChild Then
          amt += Configuration.Format(item.Amount, DigitConfig.Price)
          'End If
        Next
        Return amt
      End Get
    End Property
    Public Property CurrentItem() As SCItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As SCItem)
        m_currentItem = Value
      End Set
    End Property
    Public Property CurrentRealItem() As SCItem
      Get
        Return m_currentRealItem
      End Get
      Set(ByVal Value As SCItem)
        m_currentRealItem = Value
      End Set
    End Property
    Public ReadOnly Property ParentCurrentItem() As SCItem
      Get
        Dim curr As New SCItem
        Dim firstRow As SCItem
        For Each itm As SCItem In Me
          'If Not itm.NewChild Then
          If itm.Level = 0 Then
            firstRow = itm
          End If

          If CurrentItem.Linenumber = itm.Linenumber Then
            Exit For
          End If
          'End If
        Next
        Return curr
      End Get
    End Property
    Public Property GridVisibleRowCount() As Integer
      Get
        If Me.m_gridVisibleRowCount = 0 Then
          Me.m_gridVisibleRowCount = 19 'Fix
        End If
        Return Me.m_gridVisibleRowCount
      End Get
      Set(ByVal Value As Integer)
        Me.m_gridVisibleRowCount = Value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function CreateListTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "SCItems"

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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetSCItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("SCItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("m_sc", GetType(Integer)))
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
        Dim sci As New SCItem(tableRow, "")
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("sc_code")
        row("m_sc") = tableRow("sci_sc")
        row("Linenumber") = tableRow("sci_linenumber")
        row("Date") = tableRow("sc_docdate")
        'row("ReceivingDate") = tableRow("sc_receivingdate")

        Dim entityText As String = ""
        If Not sci.ItemType Is Nothing Then
          entityText &= sci.ItemType.Description & ":"
        End If
        If Not sci.Entity.Code Is Nothing AndAlso sci.Entity.Code.Length > 0 Then
          entityText &= sci.Entity.Code & ":"
        End If
        If Not sci.Entity.Name Is Nothing AndAlso sci.Entity.Name.Length > 0 Then
          entityText &= sci.Entity.Name
        End If
        row("Entity") = entityText
        row("Qty") = sci.Qty
        'row("OrderedQty") = sci.OrderedQty
        row("Requestor") = tableRow("requestorinfo")
        row("CostCenter") = tableRow("ccinfo")
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
#End Region

#Region "Class Methods"
    Public Function GetCurrentWBSItems(ByVal wbsId As Decimal) As SCItem
      For Each item As SCItem In Me
        'If Not item.NewChild Then
        If item.WBSId = wbsId And item.Level = 0 Then
          Return item
        End If
        'End If
      Next
      Return Nothing
    End Function
    Public Function GetCurrentItems(ByVal boqItem As BoqItem) As SCItem
      For Each item As SCItem In Me
        'If Not item.NewChild Then
        If boqItem.ItemType.Value = 42 Then
          If item.WBSId = boqItem.WBS.Id AndAlso item.Entity.Id = boqItem.Entity.Id Then
            Return item
          End If
        Else
          If item.WBSId = boqItem.WBS.Id AndAlso item.EntityName = boqItem.EntityName AndAlso item.ItemType.Value = boqItem.ItemType.Value Then
            Return item
          End If
        End If
        'End If
      Next
      Return Nothing
    End Function
    Public Function GetCurrentLastItems(ByVal boqItem As BoqItem) As SCItem
      Dim index As Integer = Me.Count
      Dim xitm As SCItem = Nothing
      Dim xkey As Boolean = False
      For Each item As SCItem In Me
        'If Not item.NewChild Then
        If item.WBSId = boqItem.WBS.Id Then
          xitm = item
          xkey = True
        Else
          If xkey Then
            Return xitm
          End If
        End If
        'End If
      Next
      If Me.Count > 0 Then
        Return Me(Me.Count - 1)
      End If
    End Function
    Public Sub SetBudgetRemain(ByVal wbsd As WBSDistribute, ByVal Item As SCItem)
      Dim newWBS As WBS = wbsd.WBS ' CType(e.Value, WBS)
      Dim theName As String = Item.EntityName
      If theName Is Nothing Then
        theName = Item.Entity.Name
      End If
      Select Case Item.ItemType.Value
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
          wbsd.BudgetQty = newWBS.GetTotalMatQtyFromDB(Item.Entity.Id)
        Case 88
          wbsd.BudgetAmount = newWBS.GetTotalLabFromDB
          wbsd.BudgetQty = newWBS.GetTotalLabQtyFromDB(theName)
        Case 89
          wbsd.BudgetAmount = newWBS.GetTotalEQFromDB
          wbsd.BudgetQty = newWBS.GetTotalEQQtyFromDB(theName)
      End Select
      wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Item.SC.Id, Item.SC.EntityId, Item.ItemType.Value)
      wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Item.SC.Id, Item.SC.EntityId, Item.Entity.Id, _
                                                                  Item.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
      'Item.UpdateWBSQty()
    End Sub
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      Dim currItem As SCItem = Nothing

      'Verify m_hashWBSItems กับ Collection =================================>>>>
      Dim newList As New Hashtable
      For Each wbsxId As Object In m_hashWBSItems.Keys
        Dim foundId As Boolean = False
        For Each itmx As SCItem In Me
          If CType(wbsxId, Integer) = itmx.WBSId Then
            foundId = True
            Exit For
          End If
        Next
        If Not foundId Then
          newList(wbsxId) = wbsxId
        End If
      Next
      For Each wid As Integer In newList.Values
        If m_hashWBSItems.Contains(wid) Then
          m_hashWBSItems.Remove(wid)
        End If
      Next
      'Verify m_hashWBSItems กับ Collection ==================================<<<<

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

          Dim doc As New scitem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = newType
            Me.CurrentItem = Nothing
            currItem = doc
          Else
            'Me.Add(doc)
            Me.Insert(Me.IndexOf(currItem), doc)
            doc.ItemType = New SCIItemType(newType)
            currItem = doc
          End If
          doc.SetItemPrice(newItem.Code)
          doc.SetItemCode(newItem.Code)
        ElseIf TypeOf items(i).Tag Is WBS Then
          '---------------- WBS Items --------------------
          Dim wbsitem As WBS = CType(items(i).Tag, WBS)
          If Not m_hashWBSItems.Contains(wbsitem.Id) Then
            m_hashWBSItems(wbsitem.Id) = wbsitem
            Dim wsci As New scitem
            If Me.Count = 0 Then
              Me.Add(wsci)
            Else
              If Not Me.CurrentItem Is Nothing Then
                wsci = Me.CurrentItem
              Else
                Me.Add(wsci)
              End If
            End If
            Dim item As New BlankItem("")
            wsci.Entity = item
            wsci.ItemType = New SCIItemType(289)
            wsci.EntityName = wbsitem.Name
            wsci.Unit = wbsitem.Unit
            wsci.Qty = 1
            wsci.UnitPrice = wbsitem.GetTotalParentBudget
          End If
        ElseIf TypeOf items(i).Tag Is BoqItem Then

          '-----------------BOQ Items--------------------
          Dim bitem As BoqItem = CType(items(i).Tag, BoqItem)

          'ถ้าไปลบรายการของ wbs ออก ก็จะหา wbs ให้ใหม่เสมอ
          If Not m_hashWBSItems.Contains(bitem.WBS.Id) Then
            m_hashWBSItems(bitem.WBS.Id) = bitem.WBS
            Dim wsci As New scitem
            If Me.Count = 0 Then
              Me.Add(wsci)
            Else
              Dim scitem As scitem = Me.GetCurrentWBSItems(bitem.WBS.Id)
              If Not scitem Is Nothing Then
                wsci = scitem
              Else
                Me.Add(wsci)
              End If
            End If
            Dim item As New BlankItem("")
            wsci.Entity = item
            wsci.ItemType = New SCIItemType(289)
            wsci.EntityName = bitem.WBS.Name
            wsci.Unit = bitem.WBS.Unit
            wsci.Qty = 1
            wsci.WBSId = bitem.WBS.Id
            wsci.UnitPrice = bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 0)
            'wsci.SetLab(wsci.Amount)
            'wsci.setMat(bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 1))
            'wsci.SetLab(bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 2))
            'wsci.setEq(bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 3))

            Dim msciWbsd As New WBSDistribute
            If Not bitem.WBS Is Nothing Then
              msciWbsd.IsMarkup = False
              msciWbsd.CostCenter = Me.m_sc.CostCenter
              msciWbsd.WBS = bitem.WBS
              msciWbsd.Percent = 100
              'msciWbsd.BaseCost = bitem.TotalMaterialCost
              'msciWbsd.TransferBaseCost = bitem.TotalMaterialCost
              msciWbsd.IsOutWard = False
              msciWbsd.Toaccttype = 3

              If msciWbsd.Percent = 100 Then
                If Not wsci Is Nothing Then
                  wsci.WBSDistributeCollection.Add(msciWbsd)
                  AddHandler wsci.WBSDistributeCollection.PropertyChanged, AddressOf wsci.WBSChangedHandler
                  SetBudgetRemain(msciWbsd, wsci)
                  'matDoc.SC.SetActual(matWbsd.WBS, 0, matDoc.Amount, matDoc.ItemType.Value)
                End If
              End If
            End If
          End If

          'If bitem.TotalCost = 0 Then
          '  Return
          'End If

          If bitem.ItemType.Value = 18 Then     'ค่าแรง
            bitem.ItemType.Value = 88
            bitem.Entity.Id = 0
          ElseIf bitem.ItemType.Value = 20 Then     'ค่าเครื่องจักร
            bitem.ItemType.Value = 89
            bitem.Entity.Id = 0
          End If

          '>>>>==== SetNewItems ================>>>
          Dim tempUnitPrice As Decimal
          If bitem.ItemType.Value = 88 Then
            tempUnitPrice = bitem.ULC
            Me.SetNewItems(bitem, tempUnitPrice)
                End If
          If bitem.ItemType.Value = 89 Then
            tempUnitPrice = bitem.UEC
            Me.SetNewItems(bitem, tempUnitPrice)
                End If
          If bitem.ItemType.Value <> 88 AndAlso bitem.ItemType.Value <> 89 Then
            If bitem.UMC > 0 Then
              tempUnitPrice = bitem.UMC
              Me.SetNewItems(bitem, tempUnitPrice)
                End If
            If bitem.ULC > 0 Then
              tempUnitPrice = bitem.ULC
              bitem.ItemType.Value = 88
              Me.SetNewItems(bitem, tempUnitPrice)
              End If
            If bitem.UEC > 0 Then
              tempUnitPrice = bitem.UEC
              bitem.ItemType.Value = 89
              Me.SetNewItems(bitem, tempUnitPrice)
                End If
            If bitem.TotalCost = 0 Then
              tempUnitPrice = 0
              Me.SetNewItems(bitem, tempUnitPrice)
                End If
                End If
          '>>>>==== SetNewItems ================>>>

              End If
      Next
      'RefreshBudget()
    End Sub
    Private Sub SetNewItems(ByVal bitem As BoqItem, ByVal unitPrice As Decimal)
                Dim item As SCItem = GetCurrentItems(bitem)
                Dim lastboqitem As SCItem = GetCurrentLastItems(bitem)
      Dim doc As New SCItem
      'Dim tempUnitPrice As Decimal

                If Not item Is Nothing Then
        doc = item
                  doc.WBSId = bitem.WBS.Id
                Else
                  doc.WBSId = bitem.WBS.Id
                  Me.Insert(Me.IndexOf(lastboqitem) + 1, doc)
                End If

      'If bitem.ItemType.Value = 88 Then
      '  tempUnitPrice = bitem.ULC
      'End If
      'If bitem.ItemType.Value = 89 Then
      '  tempUnitPrice = bitem.UEC
      'End If
      'If bitem.ItemType.Value <> 88 AndAlso bitem.ItemType.Value <> 89 Then
      '  tempUnitPrice = bitem.UMC
      'End If

              doc.ItemType = New SCIItemType(bitem.ItemType.Value)
              doc.Entity = bitem.Entity
              doc.EntityName = bitem.Entity.Name
              doc.Unit = bitem.Unit
              doc.Qty = bitem.Qty
      doc.UnitPrice = unitPrice

      Dim wbsd As New WBSDistribute
                If Not bitem.WBS Is Nothing Then
        wbsd.IsMarkup = False
        wbsd.CostCenter = Me.m_sc.CostCenter
        wbsd.WBS = bitem.WBS
        wbsd.Percent = 100
                  'labWbsd.BaseCost = bitem.TotalLaborCost
                  'labWbsd.TransferBaseCost = bitem.TotalLaborCost
        wbsd.IsOutWard = False
        wbsd.Toaccttype = 3

        If Not doc Is Nothing Then
          SetBudgetRemain(wbsd, doc)
              'm_WBSDistributeCollection = New WBSDistributeCollection
          AddHandler doc.WBSDistributeCollection.PropertyChanged, AddressOf doc.WBSChangedHandler
              'matDoc.SC.SetActual(matWbsd.WBS, 0, matDoc.Amount, matDoc.ItemType.Value)
          doc.WBSDistributeCollection.Add(wbsd)
            End If
          End If
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal tg As DataGrid)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      dt.Clear()

      'Me.m_sc.TreeManager.Treetable = dt

      Dim currItem As SCItem
      Dim hsNew As New Hashtable
      Dim parentRow As TreeRow
      Dim childRow As TreeRow
      Dim chkNoRefItem As Boolean = False

      For Each sci As SCItem In Me
        If sci.ItemType.Value = 289 Then
          Me(Me.IndexOf(sci)).Level = 0

          If sci.ItemType.Value <> 162 Then
            hsNew(sci) = sci
          End If

        Else
          Me(Me.IndexOf(sci)).Level = 1
        End If
      Next

      'me.AutoGenerateItems(hsNew)

      currItem = Me.CurrentItem
      For Each sci As SCItem In Me
        'If Not sci.NewChild Then
        Me.CurrentItem = sci

        ''-- Summary MAT LAB EQ ลูก ๆ ไปให้รายการจัดจ้าง --
        'If sci.Level = 0 AndAlso sci.IsHasChild Then
        '  sci.SetMat(sci.ChildMat)
        '  sci.SetLab(sci.ChildLab)
        '  sci.SetEq(sci.ChildEq)
        'End If
        ''-- -- Summary MAT LAB EQ ----------------

        If sci.Level = 0 Then
          'If (sci.WR Is Nothing OrElse sci.WR.Id = 0) AndAlso Not chkNoRefItem Then
          '  chkNoRefItem = True
          '  parentRow = dt.Childs.Add()
          '  parentRow.State = RowExpandState.Expanded
          '  'parentRow.FixLevel = 0
          '  parentRow.CustomFontStyle = FontStyle.Bold
          '  parentRow("Button") = "invisible"
          '  parentRow("UnitButton") = "invisible"
          '  parentRow("sci_itemName") = myStringParserService.Parse("${res:Global.Error.NotRefWR}")
          '  parentRow.Tag = "hasnotrefwr" 'ห้ามเปลี่ยนคำนี้ ปุ้ย
          'End If

          parentRow = dt.Childs.Add
          parentRow.State = RowExpandState.Expanded

          sci.CopyToDataRow(parentRow)
          sci.ItemValidateRow(parentRow)
          parentRow.Tag = sci
        Else
          If Not parentRow Is Nothing Then
            childRow = parentRow.Childs.Add

            sci.CopyToDataRow(childRow)
            sci.ItemValidateRow(childRow)
            childRow.Tag = sci
          End If
        End If

        'Dim newRow As TreeRow = dt.Childs.Add
        ''If sci.Level = 0 Then
        ''  newRow = dt.Childs.Add
        ''  newRow.State = RowExpandState.Expanded
        ''  currRow = newRow
        ''Else
        ''  newRow = currRow.Childs.Add
        ''End If
        'sci.CopyToDataRow(newRow)
        'sci.ItemValidateRow(newRow)
        'newRow.Tag = sci
        'End If
      Next

      For Each prow As TreeRow In dt.Childs
        If TypeOf prow.Tag Is SCItem AndAlso CType(prow.Tag, SCItem).Level = 0 Then
          Dim pmat As Decimal = 0
          Dim plab As Decimal = 0
          Dim peq As Decimal = 0

          For Each crow As TreeRow In prow.Childs
            pmat += CType(crow.Tag, SCItem).Mat
            plab += CType(crow.Tag, SCItem).Lab
            peq += CType(crow.Tag, SCItem).Eq
          Next

          CType(prow.Tag, SCItem).SetMat(pmat)
          CType(prow.Tag, SCItem).SetLab(plab)
          CType(prow.Tag, SCItem).SetEq(peq)
          CType(prow.Tag, SCItem).CopyToDataRow(prow)
        End If
      Next


      dt.AcceptChanges()

      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("sci_entityType")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception

      End Try

      dt.AcceptChanges()

      Me.CurrentItem = currItem

    End Sub
    Public Sub AutoGenerateItems(ByVal hsNew As Hashtable)
      Dim index As Integer = 0
      Dim currItem As SCItem = Me.CurrentItem
      For Each sci As SCItem In hsNew.Values

        Me.CurrentItem = sci
        'If Not sci.IsHasChild Then
        If sci.Mat > 0 AndAlso sci.GetChildMat = 0 Then
          Dim newsci As New SCItem
          newsci.ItemType = New SCIItemType(0)
          'newsci.NewChild = True
          newsci.Level = 1
          If sci.Qty = 0 Then
            newsci.Qty = 0
          Else
            newsci.Qty = sci.Mat / sci.Qty
          End If
          If newsci.Qty = 0 Then
            newsci.UnitPrice = 0
          Else
            newsci.UnitPrice = sci.Mat / newsci.Qty
          End If

          newsci.EntityName = sci.EntityName
          index += 1
          Me.Insert(Me.IndexOf(sci) + index, newsci)
        End If
        If sci.Lab > 0 AndAlso sci.GetChildLab = 0 Then
          Dim newsci As New SCItem
          newsci.ItemType = New SCIItemType(88)
          'newsci.NewChild = True
          newsci.Level = 1
          If sci.Qty = 0 Then
            newsci.Qty = 0
          Else
            newsci.Qty = sci.Lab / sci.Qty
          End If
          If newsci.Qty = 0 Then
            newsci.UnitPrice = 0
          Else
            newsci.UnitPrice = sci.Lab / newsci.Qty
          End If

          newsci.EntityName = sci.EntityName
          index += 1
          Me.Insert(Me.IndexOf(sci) + index, newsci)
        End If
        If sci.Eq > 0 AndAlso sci.GetChildEq = 0 Then
          Dim newsci As New SCItem
          newsci.ItemType = New SCIItemType(89)
          'newsci.NewChild = True
          newsci.Level = 1
          If sci.Qty = 0 Then
            newsci.Qty = 0
          Else
            newsci.Qty = sci.Eq / sci.Qty
          End If
          If newsci.Qty = 0 Then
            newsci.UnitPrice = 0
          Else
            newsci.UnitPrice = sci.Eq / newsci.Qty
          End If

          newsci.EntityName = sci.EntityName
          index += 1
          Me.Insert(Me.IndexOf(sci) + index, newsci)
        End If
        'End If
      Next
      Me.CurrentItem = currItem
    End Sub
    Public Function FindChildRow(ByVal parRow As TreeRow, ByVal parKay As Integer, ByVal child As Hashtable) As Boolean
      Dim key As String = ""
      For i As Integer = 1 To child.Count
        key = CStr(parKay) & CStr(i)
        Dim sci As SCItem = CType(child(key), SCItem)
        If Not sci Is Nothing Then
          Dim newrow As TreeRow = parRow.Childs.Add
          newrow.Tag = sci
          sci.CopyToDataRow(newrow)
          sci.ItemValidateRow(newrow)
          'newrow.State = RowExpandState.Expanded
        End If
      Next
    End Function
    'Public Function IsFirstRowNotRefWR(ByVal dt As TreeTable) As Boolean
    '  For Each row As TreeRow In dt.Rows
    '    If TypeOf row.Tag Is String Then
    '      If CType(row.Tag, String) = "hasnotrefwr" Then
    '        Return True
    '      End If
    '    End If
    '  Next
    '  Return False
    'End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As SCItem) As Integer
      If Not m_sc Is Nothing Then
        value.SC = m_sc
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As SCItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As SCItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As SCItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As SCItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As SCItemEnumerator
      Return New SCItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As SCItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As SCItem)
      If Not m_sc Is Nothing Then
        value.SC = m_sc
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As SCItem)
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


    Public Class SCItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As SCItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, SCItem)
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

  Public Class ChildSCItem
    Inherits SCItem

    Public Sub New()
      MyBase.New()
    End Sub
  End Class

End Namespace

