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
  'Public Class SCIItemType
  'Inherits CodeDescription

  '#Region "Constructors"
  'Public Sub New(ByVal value As Integer)
  'MyBase.New(value)
  'End Sub
  '#End Region

  '#Region "Properties"
  'Public Overrides ReadOnly Property CodeName() As String
  'Get
  'Return "sci_entityType"
  'End Get
  'End Property
  '#End Region

  'End Class
  Public Class WRItem
    Implements IWBSAllocatableItem

#Region "Members"
    Private m_wr As WR
    Private m_sequence As Integer
    Private m_lineNumber As Integer
    Private m_wrdescription As String
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

    Private m_unitCost As Decimal
    Private m_discount As New Discount("")
    Private m_hasChild As Boolean
    'Private m_allocateCostAmount As Decimal
    'Private m_IsNewAllocate As Boolean

    Private m_orderedAmount As Decimal
    Private m_orderedMat As Decimal
    Private m_orderedLab As Decimal
    Private m_orderedEq As Decimal
    Private m_orderedQty As Decimal

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
      m_WBSDistributeCollection = New WBSDistributeCollection
      AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    End Sub
    Public Sub New(ByVal id As Integer, ByVal line As Integer)
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetWRItems" _
      , New SqlParameter("@wr_id", id) _
      , New SqlParameter("@wri_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
      Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
      AddHandler wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
      m_WBSDistributeCollection = wbsdColl
      If ds.Tables.Count > 1 Then
        For Each wbsRow As DataRow In ds.Tables(1).Select("wriw_sequence=" & Me.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          m_WBSDistributeCollection.Add(wbsd)
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

        If dr.Table.Columns.Contains(aliasPrefix & "wri_wr") AndAlso Not dr.IsNull(aliasPrefix & "wri_wr") Then
          If .m_wr Is Nothing Then
            .m_wr = New WR
          End If
          .m_wr.Id = CInt(dr("wri_wr"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wri_sequence") AndAlso Not dr.IsNull(aliasPrefix & "wri_sequence") Then
          .m_sequence = CInt(dr("wri_sequence"))
        End If
        '
        If dr.Table.Columns.Contains(aliasPrefix & "wri_linenumber") AndAlso Not dr.IsNull(aliasPrefix & "wri_linenumber") Then
          .m_lineNumber = CInt(dr("wri_linenumber"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wri_level") AndAlso Not dr.IsNull(aliasPrefix & "wri_level") Then
          .m_level = CInt(dr("wri_level"))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "wri_entity") AndAlso Not dr.IsNull(aliasPrefix & "wri_entity") Then
          itemId = CInt(dr(aliasPrefix & "wri_entity"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "orderedAmount") AndAlso Not dr.IsNull(aliasPrefix & "orderedAmount") Then
          .m_orderedAmount = CDec(dr("orderedAmount"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "orderedQty") AndAlso Not dr.IsNull(aliasPrefix & "orderedQty") Then
          .m_orderedQty = CDec(dr("orderedQty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "orderedMat") AndAlso Not dr.IsNull(aliasPrefix & "orderedMat") Then
          .m_orderedMat = CDec(dr("orderedMat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "orderedLab") AndAlso Not dr.IsNull(aliasPrefix & "orderedLab") Then
          .m_orderedLab = CDec(dr("orderedLab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "orderedEq") AndAlso Not dr.IsNull(aliasPrefix & "orderedEq") Then
          .m_orderedEq = CDec(dr("orderedEq"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_itemName") AndAlso Not dr.IsNull(aliasPrefix & "wri_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "wri_itemName"))
        Else
          .m_entityName = ""
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_entityType") AndAlso Not dr.IsNull(aliasPrefix & "wri_entityType") Then

          .m_itemType = New SCIItemType(CInt(dr(aliasPrefix & "wri_entityType")))

          Select Case .m_itemType.Value
            Case 42    '"lci"
              ' If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
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
                  .m_entity = New LCIItem(dr, "")
                End If
              Else
                .m_entity = New Tool(itemId)
              End If
            Case 88, 89
              If itemId > 0 Then
                .m_entity = LCIItem.GetLciItemById(itemId)
                'If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
                '  '  If Not dr.IsNull("lci_id") Then
                '  '    .m_entity = New LCIItem(dr, "")
                '  '  End If
                '  'Else
                '  '  .m_entity = New LCIItem(itemId)
                'End If
              Else
                .m_entity = New BlankItem(.m_entityName)
              End If
            Case Else     '0, 28, 88, 89, 160, 162
              .m_entity = New BlankItem(.m_entityName)
          End Select

        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_qty") AndAlso Not dr.IsNull(aliasPrefix & "wri_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "wri_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = Unit.GetUnitById(CInt(dr(aliasPrefix & "unit_id")))
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "wri_unit") AndAlso Not dr.IsNull(aliasPrefix & "wri_unit") Then
            .m_unit = Unit.GetUnitById(CInt(dr(aliasPrefix & "wri_unit")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wri_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "wri_unitprice") Then
          .m_unitprice = CDec(dr(aliasPrefix & "wri_unitprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_mat") AndAlso Not dr.IsNull(aliasPrefix & "wri_mat") Then
          .m_mat = CDec(dr(aliasPrefix & "wri_mat"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_lab") AndAlso Not dr.IsNull(aliasPrefix & "wri_lab") Then
          .m_lab = CDec(dr(aliasPrefix & "wri_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wri_eq") AndAlso Not dr.IsNull(aliasPrefix & "wri_eq") Then
          .m_eq = CDec(dr(aliasPrefix & "wri_eq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wri_unitCost") AndAlso Not dr.IsNull(aliasPrefix & "wri_unitCost") Then
          .m_unitCost = CDec(dr(aliasPrefix & "wri_unitCost"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wri_note") AndAlso Not dr.IsNull(aliasPrefix & "wri_note") Then
          .m_note = CStr(dr(aliasPrefix & "wri_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "wri_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "wri_unvatable"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_wbs") AndAlso Not dr.IsNull(aliasPrefix & "wri_wbs") Then
          .m_wbsId = CInt(dr(aliasPrefix & "wri_wbs"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wrio_qty") AndAlso Not dr.IsNull(aliasPrefix & "wrio_qty") Then
          .m_oldQty = CDec(dr(aliasPrefix & "wrio_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wrio_mat") AndAlso Not dr.IsNull(aliasPrefix & "wrio_mat") Then
          .m_oldMat = CDec(dr(aliasPrefix & "wrio_mat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wrio_lab") AndAlso Not dr.IsNull(aliasPrefix & "wrio_lab") Then
          .m_oldLab = CDec(dr(aliasPrefix & "wrio_lab"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wrio_eq") AndAlso Not dr.IsNull(aliasPrefix & "wrio_eq") Then
          .m_oldEq = CDec(dr(aliasPrefix & "wrio_eq"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wrio_amt") AndAlso Not dr.IsNull(aliasPrefix & "wrio_amt") Then
          .m_oldAmount = CDec(dr(aliasPrefix & "wrio_amt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wri_parent") AndAlso Not dr.IsNull(aliasPrefix & "wri_parent") Then
          .m_parent = CDec(dr(aliasPrefix & "wri_parent"))
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              Me.Conversion = lci.GetConversion(Me.Unit)
            Catch ex As NoConversionException
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              If Not msgServ Is Nothing Then
                msgServ.ShowErrorFormatted("${res:Global.Error.GoodsSoldNotUnit}", New String() {ex.Lci.Code, ex.Unit.Name})
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
    Public Property wr() As WR
      Get
        Return m_wr
      End Get
      Set(ByVal Value As WR)
        m_wr = Value
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
    Public Property wrDescription() As String
      Get
        Return m_wrdescription
      End Get
      Set(ByVal Value As String)
        m_wrdescription = Value
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
        If Me.wr.ItemCollection.IndexOf(Me) = 0 AndAlso Value.Value <> 289 Then
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
        End If      End Set    End Property    Public Sub UpdateWBSQty()
      If (Me.ItemType.Value = 160 OrElse
          Me.ItemType.Value = 162 OrElse
          Me.ItemType.Value = 88 OrElse
          Me.ItemType.Value = 89) Then
        For Each wbsd As WBSDistribute In Me.WBSDistributeCollection
          wbsd.BaseQty = 0
          wbsd.QtyRemain = 0
        Next
        Return
      End If
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
        End Select        Dim amt As Decimal = Value * Me.UnitPrice

        Select Case Me.ItemType.Value
          Case 0, 19, 28, 42
            Me.m_mat = amt
            Me.m_lab = 0
            Me.m_eq = 0
          Case 88
            Me.m_mat = 0
            Me.m_lab = amt
            Me.m_eq = 0
          Case 89
            Me.m_mat = 0
            Me.m_lab = 0
            Me.m_eq = amt
          Case 289
            If amt <= Me.Amount Then
              Me.m_mat = 0
              Me.m_lab = amt
              Me.m_eq = 0
            Else
              Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
              m_lab = (amt - amt2) + Me.Lab
            End If
        End Select        If IsNumeric(Value) Then          m_qty = Configuration.Format(Value, DigitConfig.Qty)
        Else
          m_qty = 0
        End If        'UpdateWBSQty()      End Set    End Property
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
        End Select        Dim amt As Decimal = Value * Me.Qty
        Select Case Me.ItemType.Value
          Case 0, 19, 28, 42
            Me.m_mat = amt
            Me.m_lab = 0
            Me.m_eq = 0
          Case 88
            Me.m_mat = 0
            Me.m_lab = amt
            Me.m_eq = 0
          Case 89
            Me.m_mat = 0
            Me.m_lab = 0
            Me.m_eq = amt
          Case 289
            If amt <= Me.Amount Then
              Me.m_mat = 0
              Me.m_lab = amt
              Me.m_eq = 0
            Else
              Dim amt2 As Decimal = Me.Mat + Me.Lab + Me.Eq
              m_lab = (amt - amt2) + Me.Lab
            End If
        End Select        m_unitprice = Value        'UpdateWBS()      End Set    End Property
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
    Public ReadOnly Property Amount() As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        Return Configuration.Format((Me.UnitPrice * Me.Qty), DigitConfig.Price)
      End Get
    End Property
    'Public ReadOnly Property UnitCost() As Decimal 'Implements IWBSAllocatableItem.ItemAmount
    'Get
    'If Me.StockQty <> 0 Then
    'Dim tmpCost As Decimal = 0
    'Dim tmpRealGrossNoVat As Decimal = 0

    'tmpRealGrossNoVat = Me.wr.RealGross

    'If tmpRealGrossNoVat = 0 Then
    'Return 0
    'End If

    'tmpCost = Me.AmountWithDefaultUnit

    'tmpCost = tmpCost - ((tmpCost / tmpRealGrossNoVat) * Me.wr.Discount.Amount)

    'If Me.wr.TaxType.Value = 2 Then
    'If Not Me.Unvatable Then
    'tmpCost = tmpCost * (100 / (100 + Me.wr.TaxRate))
    'End If
    'End If

    'If Me.StockQty = 0 Then
    'Return 0
    'End If

    'tmpCost = tmpCost / Me.StockQty

    'Return tmpCost
    'End If
    'Return 0
    'End Get
    'End Property
    'Public ReadOnly Property CostAmount() As Decimal Implements IWBSAllocatableItem.ItemAmount
    'Get
    ''If IsNewAllocate Then
    ''  Return AllocateCostAmount
    ''End If
    'Return UnitCost * Me.StockQty
    'End Get
    'End Property
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
    Public Property OrderedAmount() As Decimal
      Get
        Return m_orderedAmount
      End Get
      Set(ByVal Value As Decimal)
        m_orderedAmount = Value
      End Set
    End Property
    Public Property OrderedQty() As Decimal
      Get
        Return m_orderedQty
      End Get
      Set(ByVal Value As Decimal)
        m_orderedQty = Value
      End Set
    End Property

    Public Property OrderedMat() As Decimal
      Get
        Return m_orderedMat
      End Get
      Set(ByVal Value As Decimal)
        m_orderedMat = Value
      End Set
    End Property
    Public Property OrderedLab() As Decimal
      Get
        Return m_orderedLab
      End Get
      Set(ByVal Value As Decimal)
        m_orderedLab = Value
      End Set
    End Property
    Public Property OrderedEq() As Decimal
      Get
        Return m_orderedEq
      End Get
      Set(ByVal Value As Decimal)
        m_orderedEq = Value
      End Set
    End Property

    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
    Public Function DupCode(ByVal myCode As String) As Boolean      If Me.wr Is Nothing Then        Return False
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
      For Each item As WRItem In Me.wr.ItemCollection
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
                , New SqlParameter("@wri_entity", myTool.Id) _
                , New SqlParameter("@wri_entitytype", myTool.EntityId) _
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
                , New SqlParameter("@wri_entity", lci.Id) _
                , New SqlParameter("@wri_entitytype", lci.EntityId) _
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
              , New SqlParameter("@wri_entity", myTool.Id) _
              , New SqlParameter("@wri_entitytype", myTool.EntityId) _
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
              , New SqlParameter("@wri_entity", lci.Id) _
              , New SqlParameter("@wri_entitytype", lci.EntityId) _
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
            'รายการ wr (งาน)
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
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim code As Object = row("code")
      Dim wri_itemname As Object = row("wri_itemname")
      Dim wri_entitytype As Object = row("wri_entitytype")
      Dim unit As Object = row("unit")
      Dim wri_qty As Object = row("wri_qty")

      Dim isClosed As Boolean = False
      isClosed = Me.wr.Closed

      Dim isBlankRow As Boolean = False
      If IsDBNull(wri_entitytype) Then
        isBlankRow = True
      End If
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not isBlankRow Then
        Select Case CInt(wri_entitytype)
          Case 289
            If (IsDBNull(wri_qty) OrElse Not IsNumeric(wri_qty) OrElse CDec(wri_qty) <= 0) AndAlso Not Me.wr.Closing Then
              row.SetColumnError("wri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("wri_qty", "")
            End If
            If IsDBNull(wri_itemname) OrElse wri_itemname.ToString.Length = 0 Then
              row.SetColumnError("wri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("wri_itemname", "")
            End If
            row.SetColumnError("code", "")
          Case 160, 162
            row.SetColumnError("wri_qty", "")
            row.SetColumnError("wri_itemname", "")
            row.SetColumnError("code", "")
          Case 0, 88, 89    'blank item /ค่าแรง/เครื่องจักร
            If IsDBNull(wri_itemname) OrElse wri_itemname.ToString.Length = 0 Then
              row.SetColumnError("wri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("wri_itemname", "")
            End If
            If (IsDBNull(wri_qty) OrElse Not IsNumeric(wri_qty) OrElse CDec(wri_qty) <= 0) AndAlso Not Me.wr.Closing Then
              row.SetColumnError("wri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("wri_qty", "")
            End If
          Case 19    'เครื่องมือ
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(wri_itemname) OrElse wri_itemname.ToString.Length = 0 Then
              row.SetColumnError("wri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("wri_itemname", "")
            End If
            If (IsDBNull(wri_qty) OrElse Not IsNumeric(wri_qty) OrElse CDec(wri_qty) <= 0) AndAlso Not Me.wr.Closing Then
              row.SetColumnError("wri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("wri_qty", "")
            End If
          Case 28    'F/A
            If IsDBNull(wri_itemname) OrElse wri_itemname.ToString.Length = 0 Then
              row.SetColumnError("wri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("wri_itemname", "")
            End If
            If (IsDBNull(wri_qty) OrElse Not IsNumeric(wri_qty) OrElse CDec(wri_qty) <= 0) AndAlso Not Me.wr.Closing Then
              row.SetColumnError("wri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("wri_qty", "")
            End If
            row.SetColumnError("code", "")
          Case 42    'LCI
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
              row.SetColumnError("code", myStringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
            Else
              row.SetColumnError("code", "")
            End If
            If IsDBNull(wri_itemname) OrElse wri_itemname.ToString.Length = 0 Then
              row.SetColumnError("wri_itemname", myStringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
            Else
              row.SetColumnError("wri_itemname", "")
            End If
            If (IsDBNull(wri_qty) OrElse Not IsNumeric(wri_qty) OrElse CDec(wri_qty) <= 0) AndAlso Not Me.wr.Closing Then
              row.SetColumnError("wri_qty", myStringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
            Else
              row.SetColumnError("wri_qty", "")
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
      Me.m_unit = New Unit
      Me.m_unitprice = 0
      Me.m_note = ""
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.wr.IsInitialized = False
        If Me.Level = 0 Then
          row.FixLevel = 1
          row.CustomFontStyle = FontStyle.Bold
        Else
          row.FixLevel = -1
        End If

        row("wri_linenumber") = Me.Linenumber
        row("wri_level") = Me.Level
        'row("wri_wrdewr") = Me.SCDescription

        Dim m_Entity_Name As String = Space(5) & Trim(Me.Entity.Name)
        Dim m_EntityName As String = Space(5) & Trim(Me.EntityName)

        If Not Me.ItemType Is Nothing Then
          row("wri_entityType") = Me.ItemType.Value
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("wri_entity") = Me.Entity.Id
                row("wri_itemName") = m_Entity_Name
                row("EntityName") = m_Entity_Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("wri_itemName") = EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                If TypeOf (Me.Entity) Is LCIItem Then
                  row("wri_entity") = Me.Entity.Id
                  row("wri_itemName") = m_Entity_Name
                  row("EntityName") = m_Entity_Name
                  row("Code") = Me.Entity.Code
                  If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                    If Me.Entity.Name <> Me.EntityName Then
                      row("wri_itemName") = m_EntityName & "<" & m_Entity_Name & ">"
                    End If
                  End If
                Else
                  row("Button") = "invisible"
                  row("wri_itemName") = m_EntityName
                End If
                row("Button") = ""
              End If
            Case 0, 28      ', 88, 89
              row("Button") = "invisible"
              row("wri_itemName") = m_EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("wri_itemName") = m_EntityName
            Case 289
              row("Button") = "invisible"
              row("wri_itemName") = Trim(m_EntityName)
          End Select

        End If

        If Not Me.Unit Is Nothing Then
          row("wri_unit") = Me.Unit.Id
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
        '  row("wri_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        'Else
        '  'If Me.Pr.Closed Then
        '  'row("wri_qty") = "0"
        '  'Else
        '  row("wri_qty") = ""
        '  'End If
        'End If

        If Me.Qty <> 0 Then
          row("wri_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("wri_qty") = ""
        End If

        If Me.Mat <> 0 Then
          row("wri_mat") = Configuration.FormatToString(Me.Mat, DigitConfig.Price)
        Else
          row("wri_mat") = ""
        End If
        If Me.Lab <> 0 Then
          row("wri_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
        Else
          row("wri_lab") = ""
        End If
        If Me.Eq <> 0 Then
          row("wri_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
        Else
          row("wri_eq") = ""
        End If

        If Me.UnitPrice <> 0 Then
          row("wri_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        Else
          row("wri_unitprice") = ""
        End If

        If Me.Amount <> 0 Then
          row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("Amount") = ""
        End If

        If Me.OrderedQty <> 0 Then
          row("OrderedQty") = Configuration.FormatToString(Me.OrderedQty, DigitConfig.Price)
        Else
          row("OrderedQty") = ""
        End If

        'If Me.OriginAmount <> 0 Then
        '    row("sci_originamt") = Configuration.FormatToString(Me.OriginAmount, DigitConfig.Price)
        'Else
        '    row("sci_originamt") = ""
        'End If

        row("wri_note") = Me.Note

        'row("wri_unvatable") = Me.Unvatable

        Me.wr.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Sub CopyToDataRowWithNotSpecifyUnitPrice(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        Me.wr.IsInitialized = False
        If Me.Level = 0 Then
          row.FixLevel = 1
          row.CustomFontStyle = FontStyle.Bold
        Else
          row.FixLevel = -1
        End If

        row("wri_linenumber") = Me.Linenumber
        row("wri_level") = Me.Level
        'row("wri_wrdewr") = Me.SCDescription

        Dim m_Entity_Name As String = Space(5) & Trim(Me.Entity.Name)
        Dim m_EntityName As String = Space(5) & Trim(Me.EntityName)

        If Not Me.ItemType Is Nothing Then
          row("wri_entityType") = Me.ItemType.Value
          Select Case Me.ItemType.Value
            Case 19, 42
              If Not Me.Entity Is Nothing Then
                row("wri_entity") = Me.Entity.Id
                row("wri_itemName") = m_Entity_Name
                row("EntityName") = m_Entity_Name
                row("Code") = Me.Entity.Code
                If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                  If Me.Entity.Name <> Me.EntityName Then
                    row("wri_itemName") = EntityName & "<" & Me.Entity.Name & ">"
                  End If
                End If
              End If
              row("Button") = ""
            Case 88, 89
              If Not Me.Entity Is Nothing Then
                If TypeOf (Me.Entity) Is LCIItem Then
                  row("wri_entity") = Me.Entity.Id
                  row("wri_itemName") = m_Entity_Name
                  row("EntityName") = m_Entity_Name
                  row("Code") = Me.Entity.Code
                  If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
                    If Me.Entity.Name <> Me.EntityName Then
                      row("wri_itemName") = m_EntityName & "<" & m_Entity_Name & ">"
                    End If
                  End If
                Else
                  row("Button") = "invisible"
                  row("wri_itemName") = m_EntityName
                End If
                row("Button") = ""
              End If
            Case 0, 28      ', 88, 89
              row("Button") = "invisible"
              row("wri_itemName") = m_EntityName
            Case 160, 162
              row("Button") = "invisible"
              row("UnitButton") = "invisible"
              row("wri_itemName") = m_EntityName
            Case 289
              row("Button") = "invisible"
              row("wri_itemName") = Trim(m_EntityName)
          End Select

        End If

        If Not Me.Unit Is Nothing Then
          row("wri_unit") = Me.Unit.Id
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
        '  row("wri_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        'Else
        '  'If Me.Pr.Closed Then
        '  'row("wri_qty") = "0"
        '  'Else
        '  row("wri_qty") = ""
        '  'End If
        'End If

        If Me.Qty <> 0 Then
          row("wri_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
        Else
          row("wri_qty") = ""
        End If

        'If Me.Mat <> 0 Then
        '  row("wri_mat") = Configuration.FormatToString(Me.Mat, DigitConfig.Price)
        'Else
        '  row("wri_mat") = ""
        'End If
        'If Me.Lab <> 0 Then
        '  row("wri_lab") = Configuration.FormatToString(Me.Lab, DigitConfig.Price)
        'Else
        '  row("wri_lab") = ""
        'End If
        'If Me.Eq <> 0 Then
        '  row("wri_eq") = Configuration.FormatToString(Me.Eq, DigitConfig.Price)
        'Else
        '  row("wri_eq") = ""
        'End If

        'If Me.UnitPrice <> 0 Then
        '  row("wri_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
        'Else
        '  row("wri_unitprice") = ""
        'End If

        'If Me.Amount <> 0 Then
        '  row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        'Else
        '  row("Amount") = ""
        'End If

        If Me.OrderedQty <> 0 Then
          row("OrderedQty") = Configuration.FormatToString(Me.OrderedQty, DigitConfig.Price)
        Else
          row("OrderedQty") = ""
        End If

        'If Me.OriginAmount <> 0 Then
        '    row("sci_originamt") = Configuration.FormatToString(Me.OriginAmount, DigitConfig.Price)
        'Else
        '    row("sci_originamt") = ""
        'End If

        row("wri_note") = Me.Note

        'row("wri_unvatable") = Me.Unvatable

        Me.wr.IsInitialized = True
      Catch ex As NoConversionException
        MessageBox.Show("วัสดุ '" & ex.Lci.Code & "' ไม่มีหน่วยนับ '" & ex.Unit.Name & "'")
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Function IsReferenced() As Boolean
      If Me.ItemType.Value = 289 Then
        If OrderedQty > 0 Then
          Return True
        End If
      Else
        'IsParentRefercend
        Dim doc As WRItem = Me.wr.ItemCollection.CurrentItem
        If doc Is Nothing Then
          Return False
        End If
        Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
        Dim startIndex As Integer = lastIndex

        For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
          If i > startIndex Then
            If Me.wr.ItemCollection(i).ItemType.Value = 289 AndAlso Me.wr.ItemCollection(i).Parent = Me.Parent Then
              Return True
            End If
            lastIndex = i
          End If
        Next

        Return False

      End If
    End Function
    Public Function IsHasChild(Optional ByVal CurrentItemIsMe As Boolean = False) As Boolean
      Dim doc As WRItem = Nothing
      If Not CurrentItemIsMe Then
        doc = Me.wr.ItemCollection.CurrentItem
      Else
        doc = Me
      End If

      If doc Is Nothing Then
        Return False
      End If
      If doc.Level = 1 Then
        Return False
      End If

      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        If i > startIndex Then
          Dim currItem As WRItem = Me.wr.ItemCollection(i)
          If currItem.Level = 0 Then
            Exit For
          End If
          If currItem.ItemType.Value <> 160 AndAlso currItem.ItemType.Value <> 162 Then
            lastIndex = i
          End If
        End If
      Next

      If startIndex < lastIndex Then
        Return True
      End If

      Return False

    End Function
    Public Function ChildAmount() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 OrElse wri.ItemType.Value = 160 OrElse wri.ItemType.Value = 162 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Amount
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Amount
      End If

      Return m_childAmount
    End Function
    Public Function ChildMat() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Mat
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Mat
      End If

      Return m_childAmount
    End Function
    Public Function ChildLab() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Lab
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Lab
      End If

      Return m_childAmount
    End Function
    Public Function ChildEq() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Eq
        End If
        'End If
      Next

      If startIndex = lastIndex Then
        Return Me.Eq
      End If

      Return m_childAmount
    End Function
    Public Function GetChildAmount() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Amount
        End If
        'End If
      Next

      'If startIndex = lastIndex Then
      '  Return Me.Eq
      'End If

      Return m_childAmount
    End Function
    Public Function GetChildMat() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Mat
        End If
        'End If
      Next

      'If startIndex = lastIndex Then
      '  Return Me.Mat
      'End If

      Return m_childAmount
    End Function
    Public Function GetChildLab() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Lab
        End If
        'End If
      Next

      'If startIndex = lastIndex Then
      '  Return Me.Lab
      'End If

      Return m_childAmount
    End Function
    Public Function GetChildEq() As Decimal
      Dim doc As WRItem = Me

      Dim m_childAmount As Decimal = 0
      Dim lastIndex As Integer = Me.wr.ItemCollection.IndexOf(doc)
      Dim startIndex As Integer = lastIndex

      For i As Integer = startIndex To Me.wr.ItemCollection.Count - 1
        'If Not Me.wr.ItemCollection(i).NewChild Then
        If i > startIndex Then
          Dim wri As WRItem = Me.wr.ItemCollection(i)
          If wri.Level = 0 Then
            Exit For
          End If
          lastIndex = i
          m_childAmount += wri.Eq
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
    Public Sub SetAmount(value As Decimal)
      If m_unitprice = 0 Then
        Me.SetUnitPrice(value)
      End If
      If m_unitprice <> 0 Then
        m_qty = value / m_unitprice
      Else
        m_qty = value
      End If
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetwrItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("wrItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("m_wr", GetType(Integer)))
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
        If Not inValidIds.Contains(CInt(tableRow("wri_pr"))) Then
          Dim wri As New WRItem(tableRow, "")
          Dim row As TreeRow = myDatatable.Childs.Add
          row("Selected") = False
          row("Code") = tableRow("wr_code")
          row("m_wr") = tableRow("wri_wr")

          Dim wrId As Integer
          If Not row.IsNull("m_wr") Then
            wrId = CInt(row("m_wr"))
          End If

          row("Linenumber") = tableRow("wri_linenumber")
          row("Date") = tableRow("wr_docdate")
          row("ReceivingDate") = tableRow("wr_receivingdate")

          Dim entityText As String = ""
          If Not wri.ItemType Is Nothing Then
            entityText &= wri.ItemType.Description & ":"
          End If
          If Not wri.Entity.Code Is Nothing AndAlso wri.Entity.Code.Length > 0 Then
            entityText &= wri.Entity.Code & ":"
          End If
          If Not wri.Entity.Name Is Nothing AndAlso wri.Entity.Name.Length > 0 Then
            entityText &= wri.Entity.Name
          End If
          row("Entity") = entityText
          row("Qty") = wri.Qty
          row("Requestor") = tableRow("requestorinfo")
          row("CostCenter") = tableRow("ccinfo")
          row.State = RowExpandState.None

          wri.wr = New WR
          wri.wr.Id = wrId
          row.Tag = wri
        End If
      Next
      Return myDatatable
    End Function
    Private Shared Function GetPRIdWithOnlyNoteItem(ByVal dt As DataTable) As ArrayList
      Dim arr As New ArrayList
      Dim tmpId As Integer = 0
      For Each tableRow As DataRow In dt.Rows
        If tmpId <> CInt(tableRow("wri_pr")) Then
          tmpId = CInt(tableRow("wri_pr"))
          If Not arr.Contains(tmpId) Then
            arr.Add(tmpId)
          End If
        End If
      Next
      Dim realArr As New ArrayList
      For Each id As Integer In arr
        Dim rows As DataRow() = dt.Select("wri_wr = " & id)
        Dim found As Boolean = False
        For Each row As DataRow In rows
          Dim wri As New WRItem(row, "")
          'If wri.OrderedQty <> 0 Or wri.Qty <> 0 Then
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
            If Not Me.m_wr Is Nothing Then

              'Me.m_wr.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
            End If
          Case "amount"
            If Not Me.m_wr Is Nothing Then

              'Me.m_wr.SetActual(wbsd.WBS, CDec(e.OldValue), CDec(e.Value), Me.ItemType.Value)
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
                'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.wr, 6) - Me.wr.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
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
            wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Me.wr.Id, Me.wr.EntityId, Me.ItemType.Value)
            wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Me.wr.Id, Me.wr.EntityId, Me.Entity.Id, _
                                                                        Me.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย

            'UpdateWBSQty()

        End Select
        wbsd.BaseQty = Me.Qty
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
  Public Class wrItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_wr As WR
    Private m_currentItem As WRItem
    Private m_currentRealItem As WRItem
    Private m_gridVisibleRowCount As Integer

    Dim m_hashWBSItems As Hashtable
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As WR)
      Me.m_wr = owner
      m_hashWBSItems = New Hashtable
      If Not Me.m_wr.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetWRItems" _
      , New SqlParameter("@wr_id", Me.m_wr.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New WRItem(row, "")
        item.wr = m_wr
        Me.Add(item)
        m_hashWBSItems(item.WBSId) = item
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf item.WBSChangedHandler
        item.WBSDistributeCollection = wbsdColl
        If ds.Tables.Count > 1 Then
          For Each wbsRow As DataRow In ds.Tables(1).Select("wriw_sequence=" & item.Sequence)
            Dim wbsd As New WBSDistribute(wbsRow, "")
            wbsdColl.Add(wbsd)
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
      For Each itm As WRItem In Me
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
    Default Public Property Item(ByVal index As Integer) As WRItem
      Get
        Return CType(MyBase.List.Item(index), WRItem)
      End Get
      Set(ByVal value As WRItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim amt As Decimal = 0        For Each item As WRItem In Me
          'If Not item.NewChild Then
          amt += Configuration.Format(item.Amount, DigitConfig.Price)
          'End If
        Next
        Return amt
      End Get
    End Property
    Public Property CurrentItem() As WRItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As WRItem)
        m_currentItem = Value
      End Set
    End Property
    Public Property CurrentRealItem() As WRItem
      Get
        Return m_currentRealItem
      End Get
      Set(ByVal Value As WRItem)
        m_currentRealItem = Value
      End Set
    End Property
    Public ReadOnly Property ParentCurrentItem() As WRItem
      Get
        Dim curr As New WRItem
        Dim firstRow As WRItem
        For Each itm As WRItem In Me
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
      dst.MappingName = "wrItems"

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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetwrItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("wrItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("m_wr", GetType(Integer)))
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
        Dim wri As New WRItem(tableRow, "")
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("wr_code")
        row("m_wr") = tableRow("wri_wr")
        row("Linenumber") = tableRow("wri_linenumber")
        row("Date") = tableRow("wr_docdate")
        'row("ReceivingDate") = tableRow("wr_receivingdate")

        Dim entityText As String = ""
        If Not wri.ItemType Is Nothing Then
          entityText &= wri.ItemType.Description & ":"
        End If
        If Not wri.Entity.Code Is Nothing AndAlso wri.Entity.Code.Length > 0 Then
          entityText &= wri.Entity.Code & ":"
        End If
        If Not wri.Entity.Name Is Nothing AndAlso wri.Entity.Name.Length > 0 Then
          entityText &= wri.Entity.Name
        End If
        row("Entity") = entityText
        row("Qty") = wri.Qty
        'row("OrderedQty") = wri.OrderedQty
        row("Requestor") = tableRow("requestorinfo")
        row("CostCenter") = tableRow("ccinfo")
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
#End Region

#Region "Class Methods"
    Public Function GetCurrentWBSItems(ByVal wbsId As Decimal) As WRItem
      For Each item As WRItem In Me
        'If Not item.NewChild Then
        If item.WBSId = wbsId And item.Level = 0 Then
          Return item
        End If
        'End If
      Next
      Return Nothing
    End Function
    Public Function GetCurrentItems(ByVal boqItem As BoqItem) As WRItem
      For Each item As WRItem In Me
        'If Not item.NewChild Then
        If boqItem.ItemType.Value = 42 Then
          If item.WBSId = boqItem.WBS.Id AndAlso item.Entity.Id = boqItem.Entity.Id AndAlso item.UnitPrice = boqItem.UMC AndAlso item.Qty = boqItem.Qty Then
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
    Public Function GetCurrentLastItems(ByVal boqItem As BoqItem) As WRItem
      Dim index As Integer = Me.Count
      Dim xitm As WRItem = Nothing
      Dim xkey As Boolean = False
      For Each item As WRItem In Me
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
    Public Sub SetBudgetRemain(ByVal wbsd As WBSDistribute, ByVal Item As WRItem)
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
          'wbsd.BudgetQty = wbsd.BudgetQty - (newWBS.GetActualType0Qty(Me.wr, 6) - Me.wr.GetCurrentTypeQtyForWBS(newWBS, theName, 0))
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
      wbsd.BudgetRemain = wbsd.BudgetAmount - newWBS.GetWBSActualFromDB(Item.wr.Id, Item.wr.EntityId, Item.ItemType.Value)
      wbsd.QtyRemain = wbsd.BudgetQty - newWBS.GetWBSQtyActualFromDB(Item.wr.Id, Item.wr.EntityId, Item.Entity.Id, _
                                                                  Item.ItemType.Value, theName) 'แปลงเป็นหน่วยตาม boq เรียบร้อย
      'Item.UpdateWBSQty()
      'wbsd.BaseQty = Item.Qty
    End Sub
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      Dim currItem As WRItem = Nothing

      'Verify m_hashWBSItems กับ Collection =================================>>>>
      Dim newList As New Hashtable
      For Each wbsxId As Object In m_hashWBSItems.Keys
        Dim foundId As Boolean = False
        For Each itmx As WRItem In Me
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

          Dim doc As New WRItem
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
            Dim wwri As New WRItem
            If Me.Count = 0 Then
              Me.Add(wwri)
            Else
              If Not Me.CurrentItem Is Nothing Then
                wwri = Me.CurrentItem
              Else
                Me.Add(wwri)
              End If
            End If
            Dim item As New BlankItem("")
            wwri.Entity = item
            wwri.ItemType = New SCIItemType(289)
            wwri.EntityName = wbsitem.Name
            wwri.Unit = wbsitem.Unit
            wwri.Qty = 1
            wwri.UnitPrice = wbsitem.GetTotalParentBudget
          End If
        ElseIf TypeOf items(i).Tag Is BoqItem Then

          '-----------------BOQ Items--------------------
          Dim bitem As BoqItem = CType(items(i).Tag, BoqItem)

          'ถ้าไปลบรายการของ wbs ออก ก็จะหา wbs ให้ใหม่เสมอ
          If Not m_hashWBSItems.Contains(bitem.WBS.Id) Then
            m_hashWBSItems(bitem.WBS.Id) = bitem.WBS
            Dim wwri As New WRItem
            If Me.Count = 0 Then
              Me.Add(wwri)
            Else
              Dim writem As WRItem = Me.GetCurrentWBSItems(bitem.WBS.Id)
              If Not writem Is Nothing Then
                wwri = writem
              Else
                Me.Add(wwri)
              End If
            End If
            Dim item As New BlankItem("")
            wwri.Entity = item
            wwri.ItemType = New SCIItemType(289)
            wwri.EntityName = bitem.WBS.Name
            wwri.Unit = bitem.WBS.Unit
            wwri.Qty = 1
            wwri.WBSId = bitem.WBS.Id
            wwri.UnitPrice = bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 0)
            'wwri.SetLab(wwri.Amount)
            'wwri.setMat(bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 1))
            'wwri.SetLab(bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 2))
            'wwri.setEq(bitem.WBS.GetBudget(bitem.WBS.Id, bitem.WBS.Boq.Id, 3))

            'Dim mwriWbsd As New WBSDistribute
            'If Not bitem.WBS Is Nothing Then
            '  mwriWbsd.IsMarkup = False
            '  mwriWbsd.CostCenter = Me.m_wr.CostCenter
            '  mwriWbsd.WBS = bitem.WBS
            '  mwriWbsd.Percent = 100
            '  'mwriWbsd.BaseCost = bitem.TotalMaterialCost
            '  'mwriWbsd.TransferBaseCost = bitem.TotalMaterialCost
            '  mwriWbsd.IsOutWard = False
            '  mwriWbsd.Toaccttype = 3

            '  If mwriWbsd.Percent = 100 Then
            '    If Not wwri Is Nothing Then
            '      wwri.WBSDistributeCollection.Add(mwriWbsd)
            '      AddHandler wwri.WBSDistributeCollection.PropertyChanged, AddressOf wwri.WBSChangedHandler
            '      SetBudgetRemain(mwriWbsd, wwri)
            '      'matDoc.SC.SetActual(matWbsd.WBS, 0, matDoc.Amount, matDoc.ItemType.Value)
            '    End If
            '  End If
            'End If
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
      Dim item As WRItem = GetCurrentItems(bitem)
      Dim lastboqitem As WRItem = GetCurrentLastItems(bitem)
      Dim doc As New WRItem
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
      doc.EntityName = bitem.EntityName
      doc.Unit = bitem.Unit
      doc.Qty = bitem.Qty + doc.Qty
      doc.UnitPrice = unitPrice

      Dim wbsd As New WBSDistribute
      If Not bitem.WBS Is Nothing Then
        wbsd.IsMarkup = False
        wbsd.CostCenter = Me.m_wr.CostCenter
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
      dt.Clear()
      Dim currItem As WRItem
      Dim hsNew As New Hashtable
      Dim parentRow As TreeRow
      Dim childRow As TreeRow

      For Each wri As WRItem In Me
        If wri.ItemType.Value = 289 Then
          Me(Me.IndexOf(wri)).Level = 0

          If wri.ItemType.Value <> 162 Then
            hsNew(wri) = wri
          End If

        Else
          Me(Me.IndexOf(wri)).Level = 1
        End If
      Next

      'me.AutoGenerateItems(hsNew)

      currItem = Me.CurrentItem
      For Each wri As WRItem In Me
        'If Not wri.NewChild Then
        Me.CurrentItem = wri

        '-- Summary MAT LAB EQ ลูก ๆ ไปให้รายการจัดจ้าง --
        If wri.Level = 0 AndAlso wri.IsHasChild Then
          wri.SetMat(wri.ChildMat)
          wri.SetLab(wri.ChildLab)
          wri.SetEq(wri.ChildEq)
          wri.SetAmount(wri.Mat + wri.Lab + wri.Eq)
        End If
        '-- -- Summary MAT LAB EQ ----------------

        If wri.Level = 0 Then
          parentRow = dt.Childs.Add
          parentRow.State = RowExpandState.Expanded

          wri.CopyToDataRow(parentRow)
          wri.ItemValidateRow(parentRow)
          parentRow.Tag = wri
        Else
          If Not parentRow Is Nothing Then
            childRow = parentRow.Childs.Add

            wri.CopyToDataRow(childRow)
            wri.ItemValidateRow(childRow)
            childRow.Tag = wri
          End If
        End If

        'Dim newRow As TreeRow = dt.Childs.Add

        'newRow.State = RowExpandState.Expanded
        'If wri.Level = 0 Then
        '  newRow = dt.Childs.Add
        '  newRow.State = RowExpandState.Expanded
        '  currRow = newRow
        'Else
        '  newRow = currRow.Childs.Add
        'End If

        'wri.CopyToDataRow(newRow)
        'wri.ItemValidateRow(newRow)
        'newRow.Tag = wri
        'End If
      Next

      'Dim newRow As TreeRow
      'newRow = Me.m_treeManager.Treetable.Childs.Add()
      'newRow("wri_level") = 0
      'newRow("Button") = "invisible"

      dt.AcceptChanges()

      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("wri_entityType")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
          '  'เพิ่มอีก 1 แถว ถ้ามีข้อมูลจนถึงแถวสุดท้าย
          dt.Childs.Add()
        End If
      Catch ex As Exception

      End Try

      dt.AcceptChanges()

      Me.CurrentItem = currItem

    End Sub
    Public Sub PopulateWithNoUnitPrice(ByVal dt As TreeTable, ByVal tg As DataGrid)
      dt.Clear()
      Dim currItem As WRItem
      Dim hsNew As New Hashtable
      Dim parentRow As TreeRow
      Dim childRow As TreeRow

      For Each wri As WRItem In Me
        If wri.ItemType.Value = 289 Then
          Me(Me.IndexOf(wri)).Level = 0

          If wri.ItemType.Value <> 162 Then
            hsNew(wri) = wri
          End If

        Else
          Me(Me.IndexOf(wri)).Level = 1
        End If
      Next

      'me.AutoGenerateItems(hsNew)

      currItem = Me.CurrentItem
      For Each wri As WRItem In Me
        'If Not wri.NewChild Then
        Me.CurrentItem = wri

        '-- Summary MAT LAB EQ ลูก ๆ ไปให้รายการจัดจ้าง --
        'If wri.Level = 0 AndAlso wri.IsHasChild Then
        '  wri.SetMat(wri.ChildMat)
        '  wri.SetLab(wri.ChildLab)
        '  wri.SetEq(wri.ChildEq)
        '  wri.SetAmount(wri.Mat + wri.Lab + wri.Eq)
        'End If
        '-- -- Summary MAT LAB EQ ----------------

        If wri.Level = 0 Then
          parentRow = dt.Childs.Add
          parentRow.State = RowExpandState.Expanded

          wri.CopyToDataRowWithNotSpecifyUnitPrice(parentRow)
          wri.ItemValidateRow(parentRow)
          parentRow.Tag = wri
        Else
          If Not parentRow Is Nothing Then
            childRow = parentRow.Childs.Add

            wri.CopyToDataRowWithNotSpecifyUnitPrice(childRow)
            wri.ItemValidateRow(childRow)
            childRow.Tag = wri
          End If
        End If

        'Dim newRow As TreeRow = dt.Childs.Add

        'newRow.State = RowExpandState.Expanded
        'If wri.Level = 0 Then
        '  newRow = dt.Childs.Add
        '  newRow.State = RowExpandState.Expanded
        '  currRow = newRow
        'Else
        '  newRow = currRow.Childs.Add
        'End If

        'wri.CopyToDataRow(newRow)
        'wri.ItemValidateRow(newRow)
        'newRow.Tag = wri
        'End If
      Next

      'Dim newRow As TreeRow
      'newRow = Me.m_treeManager.Treetable.Childs.Add()
      'newRow("wri_level") = 0
      'newRow("Button") = "invisible"

      dt.AcceptChanges()

      Do Until dt.Rows.Count > tg.VisibleRowCount
        'เพิ่มแถวจนเต็ม
        dt.Childs.Add()
      Loop

      Try
        If (Not dt.Rows(dt.Rows.Count - 1).IsNull("wri_entityType")) OrElse (Not CType(dt.Rows(dt.Rows.Count - 1), TreeRow).Tag Is Nothing) Then
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
      Dim currItem As WRItem = Me.CurrentItem
      For Each wri As WRItem In hsNew.Values

        Me.CurrentItem = wri
        'If Not wri.IsHasChild Then
        If wri.Mat > 0 AndAlso wri.GetChildMat = 0 Then
          Dim newwri As New WRItem
          newwri.ItemType = New SCIItemType(0)
          'newsci.NewChild = True
          newwri.Level = 1
          If wri.Qty = 0 Then
            newwri.Qty = 0
          Else
            newwri.Qty = wri.Mat / wri.Qty
          End If
          If newwri.Qty = 0 Then
            newwri.UnitPrice = 0
          Else
            newwri.UnitPrice = wri.Mat / newwri.Qty
          End If

          newwri.EntityName = wri.EntityName
          index += 1
          Me.Insert(Me.IndexOf(wri) + index, newwri)
        End If
        If wri.Lab > 0 AndAlso wri.GetChildLab = 0 Then
          Dim newwri As New WRItem
          newwri.ItemType = New SCIItemType(88)
          'newsci.NewChild = True
          newwri.Level = 1
          If wri.Qty = 0 Then
            newwri.Qty = 0
          Else
            newwri.Qty = wri.Lab / wri.Qty
          End If
          If newwri.Qty = 0 Then
            newwri.UnitPrice = 0
          Else
            newwri.UnitPrice = wri.Lab / newwri.Qty
          End If

          newwri.EntityName = wri.EntityName
          index += 1
          Me.Insert(Me.IndexOf(wri) + index, newwri)
        End If
        If wri.Eq > 0 AndAlso wri.GetChildEq = 0 Then
          Dim newwri As New WRItem
          newwri.ItemType = New SCIItemType(89)
          'newsci.NewChild = True
          newwri.Level = 1
          If wri.Qty = 0 Then
            newwri.Qty = 0
          Else
            newwri.Qty = wri.Eq / wri.Qty
          End If
          If newwri.Qty = 0 Then
            newwri.UnitPrice = 0
          Else
            newwri.UnitPrice = wri.Eq / newwri.Qty
          End If

          newwri.EntityName = wri.EntityName
          index += 1
          Me.Insert(Me.IndexOf(wri) + index, newwri)
        End If
        'End If
      Next
      Me.CurrentItem = currItem
    End Sub
    Public Function FindChildRow(ByVal parRow As TreeRow, ByVal parKay As Integer, ByVal child As Hashtable) As Boolean
      Dim key As String = ""
      For i As Integer = 1 To child.Count
        key = CStr(parKay) & CStr(i)
        Dim wri As WRItem = CType(child(key), WRItem)
        If Not wri Is Nothing Then
          Dim newrow As TreeRow = parRow.Childs.Add
          newrow.Tag = wri
          wri.CopyToDataRow(newrow)
          wri.ItemValidateRow(newrow)
          'newrow.State = RowExpandState.Expanded
        End If
      Next
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As WRItem) As Integer
      If Not m_wr Is Nothing Then
        value.wr = m_wr
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As wrItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As WRItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As WRItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As WRItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As wrItemEnumerator
      Return New wrItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As WRItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As WRItem)
      If Not m_wr Is Nothing Then
        value.wr = m_wr
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As WRItem)
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


    Public Class wrItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As wrItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, WRItem)
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

  Public Class ChildwrItem
    Inherits WRItem

    Public Sub New()
      MyBase.New()
    End Sub
  End Class

End Namespace

