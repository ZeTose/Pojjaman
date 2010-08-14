Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class StockDocType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "stock_type"
      End Get
    End Property
#End Region

  End Class

  Public Class StockStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "stock_status"
      End Get
    End Property
#End Region

  End Class
  

  ' StockItem
  Public Class StockItem

#Region "Members"
    Private m_stock As SimpleBusinessEntityBase
    Private m_lineNumber As Integer
    Private m_cc As CostCenter
    Private m_fromcc As CostCenter
    Private m_tocc As CostCenter
    Private m_tocust As Customer
    Private m_toacct As Account
    Private m_toacctType As AccountType
    Private m_sequence As Integer
    Private m_refDoc As Integer
    Private m_refDocLinenumber As Integer
    Private m_refSequence As Integer
    Private m_entity As IHasName
    Private m_itemType As ItemType
    Private m_itemname As String
    Private m_unit As Unit
    Private m_defaultunit As Unit
    Private m_unitprice As Decimal
    Private m_discrate As Discount
    Private m_discamt As Decimal
    Private m_unitCost As Decimal
    Private m_amt As Decimal
    Private m_qty As Decimal
    Private m_stockqty As Decimal
    Private m_iscancelled As Boolean
    Private m_note As String
    Private m_type As StockDocType
    Private m_status As StockStatus
    Private m_IsInitialized As Boolean

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal iseqt As Boolean)
      Me.Construct(dr, aliasPrefix, iseqt)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String, Optional ByVal isEqt As Boolean = False)
      With Me
        m_stock = New SimpleBusinessEntityBase(dr, "stock")
        'm_stock.EntityId = CInt(dr(aliasPrefix & "stocki_type"))
        ' Line number ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
        End If
        ' Cost Center ...
        If dr.Table.Columns.Contains(aliasPrefix & "Costcenter.cc_id") AndAlso Not dr.IsNull(aliasPrefix & "Costcenter.cc_id") Then
          .m_cc = New CostCenter(dr, "Costcenter.")
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_cc") AndAlso Not dr.IsNull(aliasPrefix & "stocki_cc") Then
            .m_cc = New CostCenter(CInt(dr(aliasPrefix & "stocki_cc")))
          End If
        End If
        ' from Cost Center ...
        If dr.Table.Columns.Contains(aliasPrefix & "fromcc.cc_id") AndAlso Not dr.IsNull(aliasPrefix & "fromcc.cc_id") Then
          .m_fromcc = New CostCenter(dr, "fromcc.")
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_fromcc") AndAlso Not dr.IsNull(aliasPrefix & "stocki_fromcc") Then
            .m_fromcc = New CostCenter(CInt(dr(aliasPrefix & "stocki_fromcc")))
          End If
        End If
        ' to Cost Center ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_tocc") _
        AndAlso Not dr.IsNull(aliasPrefix & "stocki_tocc") Then
          .m_tocc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "stocki_tocc")))
        End If
        ' to customer Center ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_tocust") _
        AndAlso Not dr.IsNull(aliasPrefix & "stocki_tocust") Then
          .m_tocust = New Customer(CInt(dr(aliasPrefix & "stocki_tocust")))
        End If
        ' to account 
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_toacct") _
        AndAlso Not dr.IsNull(aliasPrefix & "stocki_toacct") Then
          .m_toacct = New Account(CInt(dr(aliasPrefix & "stocki_toacct")))
        End If
        ' to account type 
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_toacctType") _
        AndAlso Not dr.IsNull(aliasPrefix & "stocki_toacctType") Then
          .m_toacctType = New AccountType(CInt(dr(aliasPrefix & "stocki_toacctType")))
        End If
        ' Sequence number ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_sequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_sequence") Then
          .m_sequence = CInt(dr(aliasPrefix & "stocki_sequence"))
        End If
        ' Ref document ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refDoc") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refDoc") Then
          .m_refDoc = CInt(dr(aliasPrefix & "stocki_refDoc"))
        End If
        ' Ref DocLinenumber ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refDocLinenumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refDocLinenumber") Then
          .m_refDocLinenumber = CInt(dr(aliasPrefix & "stocki_refDocLinenumber"))
        End If
        ' Ref Sequence ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refSequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refSequence") Then
          .m_refSequence = CInt(dr(aliasPrefix & "stocki_refSequence"))
        End If

        ' Entity Type ...

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entityType") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entityType") Then
          .m_itemType = New ItemType(CInt(dr(aliasPrefix & "stocki_entityType")))
        End If

        Dim itemId As Integer

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entity") Then
          itemId = CInt(dr(aliasPrefix & "stocki_entity"))
        End If
        Select Case .m_itemType.Description.ToLower
          Case "blank"
            If dr.Table.Columns.Contains(aliasPrefix & "stocki_itemName") AndAlso Not dr.IsNull(aliasPrefix & "stocki_itemName") Then
              .m_entity = New BlankItem(CStr(dr(aliasPrefix & "stocki_itemName")))
            Else
              'Todo: Error
            End If
          Case "lci"
            If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              If Not dr.IsNull("lci_id") Then
                .m_entity = New LCIItem(dr, "")
              End If
            Else
              .m_entity = LCIItem.GetLciItemById(itemId)
            End If
          Case "tool"
            If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("tool_id") Then
                .m_entity = New LCIItem(dr, "")
              End If
            Else
              .m_entity = New Tool(itemId)
            End If
          Case "f/a"
            If dr.Table.Columns.Contains("asset_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("asset_id") Then
                .m_entity = New Asset(dr, "")
              End If
            Else
              .m_entity = New Asset(itemId)
            End If
          Case Else
        End Select

        ' Item name ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_itemname") AndAlso Not dr.IsNull(aliasPrefix & "stocki_itemname") Then
          .m_itemname = CStr(dr(aliasPrefix & "stocki_itemname"))
        End If
        ' Default Unit ... 
        If dr.Table.Columns.Contains(aliasPrefix & "lci_defaultunit") AndAlso Not dr.IsNull(aliasPrefix & "lci_defaultunit") Then
          .m_defaultunit = Unit.GetUnitById(CInt(dr(aliasPrefix & "lci_defaultunit")))
          '.m_defaultunit = New Unit(dr, "Unit.")
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
            .m_defaultunit = New Unit(CInt(dr(aliasPrefix & "stocki_unit")))
          End If
        End If
        ' Unit ... 
        If dr.Table.Columns.Contains(aliasPrefix & "unit.unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit.unit_id") Then
          .m_unit = New Unit(dr, "Unit.")
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
            .m_unit = Unit.GetUnitById(CInt(dr(aliasPrefix & "stocki_unit")))
          End If
        End If
        ' Unit Price ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitprice") Then
          .m_unitprice = CDec(dr(aliasPrefix & "stocki_unitprice"))
        End If

        ' Discount rate ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_discrate") AndAlso Not dr.IsNull(aliasPrefix & "stocki_discrate") Then
          .m_discrate = New Discount(CStr(dr(aliasPrefix & "stocki_discrate")))
        End If
        ' Discount Amount ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_discamt") AndAlso Not dr.IsNull(aliasPrefix & "stocki_discamt") Then
          .m_discamt = CDec(dr(aliasPrefix & "stocki_discamt"))
        End If
        ' Unit cost ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitCost") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitCost") Then
          .m_unitCost = CDec(dr(aliasPrefix & "stocki_unitCost"))
        End If
        ' Amount ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_amt") AndAlso Not dr.IsNull(aliasPrefix & "stocki_amt") Then
          .m_amt = CDec(dr(aliasPrefix & "stocki_amt"))
        End If
        ' Quatity ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "stocki_qty"))
        End If
        ' Stock Qty ...
        If isEqt Then
          If dr.Table.Columns.Contains(aliasPrefix & "es_sequence") AndAlso Not dr.IsNull(aliasPrefix & "es_sequence") Then
            .esSequence = CInt(dr(aliasPrefix & "es_sequence"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "es_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "es_stockqty") Then
            .m_stockqty = CDec(dr(aliasPrefix & "es_stockqty"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stockqty") Then
            .oldstockqty = CDec(dr(aliasPrefix & "stocki_stockqty"))
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stockqty") Then
            .m_stockqty = CDec(dr(aliasPrefix & "stocki_stockqty"))
          End If
        End If
        
        ' Iscancelled ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_iscancelled") AndAlso Not dr.IsNull(aliasPrefix & "stocki_iscancelled") Then
          .m_iscancelled = CBool(dr(aliasPrefix & "stocki_iscancelled"))
        End If
        ' Stock Docu type ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_type") AndAlso Not dr.IsNull(aliasPrefix & "stocki_type") Then
          .m_type = New StockDocType(CInt(dr(aliasPrefix & "stocki_type")))
        End If
        ' Stock Status ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_status") AndAlso Not dr.IsNull(aliasPrefix & "stocki_status") Then
          .m_status = New StockStatus(CInt(dr(aliasPrefix & "stocki_status")))
        End If
        ' Stock Note ...
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_note") AndAlso Not dr.IsNull(aliasPrefix & "stocki_note") Then
          .m_note = CStr(dr(aliasPrefix & "stocki_note"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Overridable"
    Public Overridable ReadOnly Property GetSpocname() As String
      Get
        Return "GetStockItem"
      End Get
    End Property

    Public Overridable ReadOnly Property Prefix() As String
      Get
        Return "Stocki"
      End Get
    End Property

    Public Overridable Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value      End Set    End Property
#End Region

#Region "Properties"

    Public Property IsInitialized() As Boolean      Get        Return m_IsInitialized      End Get      Set(ByVal Value As Boolean)        m_IsInitialized = Value      End Set    End Property

    Public Property Stock() As SimpleBusinessEntityBase
      Get
        Return m_stock
      End Get
      Set(ByVal Value As SimpleBusinessEntityBase)
        m_stock = Value
      End Set
    End Property

    Public Property ItemType() As CodeDescription      Get        Return m_itemType      End Get      Set(ByVal Value As CodeDescription)        m_itemType = CType(Value, ItemType)      End Set    End Property

    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property CostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value      End Set    End Property    Public Property FromCostcenter() As CostCenter
      Get
        Return m_fromcc
      End Get
      Set(ByVal Value As CostCenter)
        m_fromcc = Value
      End Set
    End Property    Public Property ToCostCenter() As CostCenter      Get
        Return m_tocc
      End Get
      Set(ByVal Value As CostCenter)
        m_tocc = Value
      End Set
    End Property    Public Property ToCustomer() As Customer      Get
        Return m_tocust
      End Get
      Set(ByVal Value As Customer)
        m_tocust = Value
      End Set
    End Property    Public Property ToAccount() As Account      Get
        Return m_toacct
      End Get
      Set(ByVal Value As Account)
        m_toacct = Value
      End Set
    End Property    Public Property ToAccountType() As AccountType      Get
        Return m_toacctType
      End Get
      Set(ByVal Value As AccountType)
        m_toacctType = Value
      End Set
    End Property    Public Property esSequence As Integer    Public Property Sequence() As Integer      Get        Return m_sequence      End Get      Set(ByVal Value As Integer)        m_sequence = Value      End Set    End Property    Public Property RefEqtItem As EqtItem    Public Property RefDoc() As Integer      Get        Return m_refDoc      End Get      Set(ByVal Value As Integer)        m_refDoc = Value      End Set    End Property    Public Property RefDocLinenumber() As Integer      Get        Return m_refDocLinenumber      End Get      Set(ByVal Value As Integer)        m_refDocLinenumber = Value      End Set    End Property    Public Property RefSequence() As Integer      Get        Return m_refSequence      End Get      Set(ByVal Value As Integer)        m_refSequence = Value      End Set    End Property    Public Property Itemname() As String      Get        Return m_itemname      End Get      Set(ByVal Value As String)        m_itemname = Value      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property    Public ReadOnly Property DefaultUnit() As Unit      Get        If m_defaultunit IsNot Nothing AndAlso m_defaultunit.Originated Then          Return m_defaultunit        Else
          Return m_unit
        End If      End Get    End Property    Public Property Unitprice() As Decimal      Get        Return m_unitprice      End Get      Set(ByVal Value As Decimal)        m_unitprice = Value      End Set    End Property    Public Property Discrate() As Discount      Get        Return m_discrate      End Get      Set(ByVal Value As Discount)        m_discrate = Value      End Set    End Property    Public Property Discamt() As Decimal      Get        Return m_discamt      End Get      Set(ByVal Value As Decimal)        m_discamt = Value      End Set    End Property    Public Property UnitCost() As Decimal      Get        Return m_unitCost      End Get      Set(ByVal Value As Decimal)        m_unitCost = Value      End Set    End Property    Public Property Amount() As Decimal      Get        If m_amt = 0 AndAlso m_stockqty > 0 AndAlso m_unitCost > 0 Then          Return m_stockqty * m_unitCost
        End If        Return m_amt      End Get      Set(ByVal Value As Decimal)        m_amt = Value      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        m_qty = Value      End Set    End Property    Public Property oldstockqty As Decimal    Public Property Stockqty() As Decimal      Get        Return m_stockqty      End Get      Set(ByVal Value As Decimal)        m_stockqty = Value      End Set    End Property    Public Property Iscancelled() As Boolean      Get        Return m_iscancelled      End Get      Set(ByVal Value As Boolean)        m_iscancelled = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Type() As StockDocType      Get        Return m_type      End Get      Set(ByVal Value As StockDocType)        m_type = Value      End Set    End Property    Public Property Status() As StockStatus      Get        Return m_status      End Get      Set(ByVal Value As StockStatus)        m_status = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Overridable Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Dim obj As SimpleBusinessEntityBase

      Me.Stock.IsInitialized = False

      row("stocki_lineNumber") = Me.LineNumber

      If Not Me.CostCenter Is Nothing Then
        row("stocki_cc") = Me.CostCenter.Id
        row("CCCode") = Me.CostCenter.Code
        row("CCName") = Me.CostCenter.Name
      End If

      If Not Me.ToCostCenter Is Nothing Then
        row("stocki_tocc") = Me.ToCostCenter.Id
      End If

      If Not Me.ToCustomer Is Nothing Then
        row("stocki_tocust") = Me.ToCustomer.Id
      End If

      If Not Me.FromCostcenter Is Nothing Then
        row("stocki_fromcc") = Me.FromCostcenter.Id
      End If

      If Not Me.ToAccount Is Nothing Then
        row("stocki_toacct") = Me.ToAccount.Id
      End If

      If Not Me.ToAccountType Is Nothing Then
        row("stocki_toacctType") = Me.ToAccountType.Value
      End If

      row("stocki_sequence") = Me.Sequence
      row("stocki_refDoc") = Me.RefDoc
      row("stocki_refDocLinenumber") = Me.RefDocLinenumber
      row("stocki_refSequence") = Me.RefSequence

      If Not Me.Entity Is Nothing Then
        row("stocki_entity") = Me.Entity.Id
        row("Code") = Me.Entity.Code
        row("Name") = CType(Entity, IHasName).Name
        Me.Itemname = CType(Entity, IHasName).Name
      End If

      row("stocki_entityType") = Me.ItemType.Value
      row("stocki_itemname") = Me.Itemname

      If Not Me.Unit Is Nothing Then
        row("stocki_unit") = Me.Unit.Id
        row("UnitCode") = Me.Unit.Code
        row("UnitName") = Me.Unit.Name
      End If

      row("stocki_unitprice") = Me.Unitprice
      If Me.Qty <> 0 Then
        row("stocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      Else
        row("stocki_qty") = ""
      End If
      If Me.Unitprice <> 0 Then
        row("stocki_unitprice") = Configuration.FormatToString(Me.Unitprice, DigitConfig.UnitPrice)
      Else
        row("stocki_unitprice") = ""
      End If
      If Me.Amount <> 0 Then
        row("stocki_amt") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("stocki_amt") = ""
      End If
      If Me.UnitCost <> 0 Then
        row("stocki_unitcost") = Configuration.FormatToString(Me.UnitCost, DigitConfig.Cost)
      Else
        row("stocki_unitcost") = ""
      End If
      If Me.Stockqty <> 0 Then
        row("stocki_stockqty") = Configuration.FormatToString(Me.Stockqty, DigitConfig.Qty)
      Else
        row("stocki_stockqty") = ""
      End If
      row("stocki_iscancelled") = Me.Iscancelled
      row("stocki_note") = Me.Note

      If Not Me.Type Is Nothing Then
        row("stocki_type") = Me.Type.Value
      End If

      If Not Me.Status Is Nothing Then
        row("stocki_status") = Me.Status.Value
      End If

      Me.Stock.IsInitialized = True
    End Sub
    Public Overridable Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("stocki_linenumber")) Then
          Me.LineNumber = CInt(row("stocki_linenumber"))
        End If

        If Not row.IsNull(("stocki_cc")) Then
          Me.CostCenter = New CostCenter(CInt(row("stocki_cc")))
        Else
          Me.CostCenter = New CostCenter
        End If

        If Not row.IsNull(("stocki_tocc")) Then
          Me.ToCostCenter = New CostCenter(CInt(row("stocki_tocc")))
        Else
          Me.ToCostCenter = New CostCenter
        End If

        If Not row.IsNull(("stocki_tocust")) Then
          Me.ToCustomer = New Customer(CInt(row("stocki_tocust")))
        Else
          Me.ToCustomer = New Customer
        End If

        If Not row.IsNull(("stocki_sequence")) Then
          Me.Sequence = CInt(row("stocki_sequence"))
        End If

        If Not row.IsNull(("stocki_refDoc")) Then
          Me.RefDoc = CInt(row("stocki_refDoc"))
        End If

        If Not row.IsNull(("stocki_refDocLinenumber")) Then
          Me.RefDocLinenumber = CInt(row("stocki_refDocLinenumber"))
        End If

        If Not row.IsNull(("stocki_refSequence")) Then
          Me.RefSequence = CInt(row("stocki_refSequence"))
        End If

        If Not row.IsNull(("stocki_entityType")) Then
          Me.ItemType = New ItemType(CInt(row("stocki_entityType")))

          Select Case ItemType.Description.ToLower
            Case "blank"
              If Not row.IsNull(("stocki_itemname")) Then
                Me.Entity = New BlankItem(row("stocki_itemname").ToString)
              Else
                Me.Entity = New BlankItem("")
              End If
            Case "lci"
              If Not row.IsNull(("stocki_entity")) Then
                Me.Entity = New LCIItem(CInt(row("stocki_entity")))
              End If
            Case "tool"
              If Not row.IsNull(("stocki_entity")) Then
                Me.Entity = New Tool(CInt(row("stocki_entity")))
              End If
            Case "f/a"
              If Not row.IsNull(("stocki_entity")) Then
                Me.Entity = New Asset(CInt(row("stocki_entity")))
              End If
          End Select
        End If

        If Not row.IsNull(("stocki_itemname")) Then
          Me.Itemname = CStr(row("stocki_itemname"))
        End If

        If Not row.IsNull(("stocki_unit")) Then
          Me.Unit = New Unit(CInt(row("stocki_unit")))
        Else
          Me.Unit = New Unit
        End If

        If IsNumeric(row("stocki_unitprice")) Then
          Me.Unitprice = CDec(row("stocki_unitprice"))
        End If

        If Not row.IsNull(("stocki_discrate")) Then
          Me.Discrate = New Discount(CStr(row("stocki_discrate")))
        End If

        If IsNumeric(row("stocki_discamt")) Then
          Me.Discamt = CDec(row("stocki_discamt"))
        End If

        If IsNumeric(row("stocki_unitCost")) Then
          Me.UnitCost = CDec(row("stocki_unitCost"))
        End If

        If IsNumeric(row("stocki_amt")) Then
          Me.Amount = CDec(row("stocki_amt"))
        End If

        If IsNumeric(row("stocki_qty")) Then
          Me.Qty = CDec(row("stocki_qty"))
        End If

        If IsNumeric(row("stocki_stockqty")) Then
          Me.Stockqty = CDec(row("stocki_stockqty"))
        End If

        If Not row.IsNull(("stocki_iscancelled")) Then
          Me.Iscancelled = CBool(row("stocki_iscancelled"))
        End If

        If Not row.IsNull(("stocki_note")) Then
          Me.Note = CStr(row("stocki_note"))
        End If

        If Not row.IsNull(("stocki_type")) Then
          Me.Type = New StockDocType(CInt(row("stocki_type")))
        Else
          Me.Type = New StockDocType
        End If

        If Not row.IsNull(("stocki_status")) Then
          Me.Status = New StockStatus(CInt(row("stocki_status")))
        Else
          Me.Status = New StockStatus(-1)
        End If

      Catch ex As Exception
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowErrorFormatted("{0} :: {1}", ex.Message, ex.StackTrace)
      End Try

    End Sub
#End Region

#Region " Shared "
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("StockItem")

      myDatatable.Columns.Add(New DataColumn("stocki_lineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_cc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_tocc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_tocust", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_sequence", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_refDoc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_refDocLinenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_refSequence", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemname", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_discrate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_discamt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_stockqty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_iscancelled", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_type", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_status", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("includingCost", GetType(Boolean)))

      Return myDatatable
    End Function
    Public Shared Function GetSequenceArray(ByVal id As Integer, ByVal line As Integer) As ArrayList
      'GetSequenceFromStockitem
      Dim arr As New ArrayList
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                SimpleBusinessEntityBase.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetSequenceFromStockitem" _
                , New SqlParameter("@stocki_stock", id) _
                , New SqlParameter("@stocki_linenumber", line) _
                )
        For Each row As DataRow In ds.Tables(0).Rows
          arr.Add(row)
        Next
      Catch ex As Exception
        'MessageBox.Show(ex.Message)
      End Try
      Return arr
    End Function
#End Region

  End Class

  Public Class StockItemCollection
    Inherits CollectionBase
#Region "Members"
    Private m_stock As SimpleBusinessEntityBase
    Private m_stockHash As Hashtable
    Private m_currentItem As StockItem
    Private m_refeqtitem As EqtItem
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As GoodsReceipt)
      Me.m_stock = owner
      If Not Me.m_stock.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetStockItems" _
      , New SqlParameter("@stock_id", Me.m_stock.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New StockItem(row, "")
        item.Stock = m_stock
        Me.Add(item)

      Next
    End Sub

#End Region

#Region "Properties"
    Public Property Stock() As SimpleBusinessEntityBase
      Get
        Return m_stock
      End Get
      Set(ByVal Value As SimpleBusinessEntityBase)
        m_stock = Value
      End Set
    End Property
    Default Public Property Item(ByVal index As Integer) As StockItem
      Get
        Return CType(MyBase.List.Item(index), StockItem)
      End Get
      Set(ByVal value As StockItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property StockHASH() As Hashtable
      Get
        Return m_stockHash
      End Get
    End Property
    Public Property CurrentItem() As StockItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As StockItem)
        m_currentItem = Value
      End Set
    End Property
    Public Property RefEqtitem As EqtItem
      Get
        Return m_refeqtitem
      End Get
      Set(ByVal value As EqtItem)
        m_refeqtitem = value
        For Each Item As StockItem In Me
          Item.RefEqtItem = m_refeqtitem
        Next
      End Set
    End Property
#End Region

#Region "Class Methods"

    Public ReadOnly Property Amount As Decimal
      Get
        Dim amt As Decimal
        For Each Item As StockItem In Me
          amt += Item.Amount
        Next
        Return amt
      End Get
    End Property

    'Public Sub Populate(ByVal dt As TreeTable)
    '  dt.Clear()
    '  Dim i As Integer = 0
    '  For Each gri As StockItem In Me
    '    i += 1
    '    Dim thePO As PO = Nothing
    '    If Not gri.POitem Is Nothing Then
    '      If Not gri.POitem.Po Is Nothing AndAlso gri.POitem.Po.Originated Then
    '        thePO = gri.POitem.Po
    '      End If
    '    End If
    '    Dim parRow As TreeRow = FindRow(dt, thePO)
    '    Dim newRow As TreeRow = parRow.Childs.Add()
    '    gri.CopyToDataRow(newRow)
    '    gri.ItemValidateRow(newRow)
    '    newRow.Tag = gri
    '  Next
    '  If i = 0 Then
    '    Dim parRow As TreeRow = FindRow(dt, Nothing)
    '  End If
    '  dt.AcceptChanges()
    'End Sub
    Public Shared Function FindRow(ByVal dt As TreeTable, ByVal thePO As PO) As TreeRow
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noPOText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.entityBaseDetail.BlankPOText}")
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
    Public Function GetCollectionForStock(ByVal stock As SimpleBusinessEntityBase) As StockItemCollection
      Dim myCollection As New StockItemCollection
      myCollection.Stock = stock
      For Each item As StockItem In Me
        'If item.EntityBase Is SimpleBusinessEntityBase Then
        '  myCollection.Add(item)
        'Else
        If stock.Id <> 0 And stock.Id = item.Stock.Id Then
          myCollection.Add(item)
        End If
      Next
      Return myCollection
    End Function
    Public Function GetStockCollection() As StockItemCollection
      Dim myCollection As New StockItemCollection
      Dim stockid As Integer
      For Each item As StockItem In Me
        If stockid = 0 OrElse stockid <> item.Stock.Id Then
          myCollection.Add(item)
          stockid = item.Stock.Id
        End If
      Next
      Return myCollection
    End Function
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      For i As Integer = 0 To items.Count - 1
        Dim itemEntityLevel As Integer
        Dim item As StockBasketItem = CType(items(i), StockBasketItem)
        Dim row As DataRow = CType(item.Tag, DataRow)
        Dim drh As New DataRowHelper(row)
        Dim newItem As StockItem
        Dim newType As Integer = -1
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.stockitem"
            newItem = New StockItem(row, "")
            If targetType > -1 Then
              newType = targetType
            Else
              newType = drh.GetValue(Of Integer)("stocki_entitytype")
            End If
          Case "longkong.pojjaman.businesslogic.lciitem", "longkong.pojjaman.businesslogic.lciforlist"
            newItem = New StockItem(row, "")
            If targetType > -1 Then
              newType = targetType
            Else
              newType = 42
            End If
            itemEntityLevel = CType(newItem.Entity, LCIItem).Level
        End Select
        'If itemEntityLevel = 5 Then
        Dim doc As New StockItem
        doc = newItem
        'If Not Me.CurrentItem Is Nothing Then
        '  doc = Me.CurrentItem
        '  doc.ItemType.Value = newType
        '  Me.CurrentItem = Nothing
        'Else
        Me.Add(doc)
        doc.ItemType = New ItemType(newType)
        doc.oldstockqty = newItem.Stockqty
        'End If
        'doc.Entity = newItem   'เดิม Set จากการกดปุ่มเป็นแบบนี้ทำให้รหัสบัญชีไม่ขึ้น จึงไปใช้วิธีเดียวกับการกรอกใน textbox
        'doc.SetItemCode(newItem.Code)
        'End If
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As StockItem) As Integer
      If Not m_stock Is Nothing Then
        value.Stock = m_stock
      End If
      'If Not value.Stock Is Nothing AndAlso value.Stock.Originated Then
      '  If Not m_stockHash.Contains(value.Stock.Id) Then
      '    m_stockHash(value.Stock.Id) = PO.GetPO(value.Stock.Id, ViewType.PaySelection)
      '  End If
      '  value.Stock = CType(m_stockHash(value.Stock.Id), SimpleBusinessEntityBase)
      'End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As StockItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As StockItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As StockItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As StockItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As StockItemEnumerator
      Return New StockItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As StockItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As StockItem)
      If Not m_stock Is Nothing Then
        value.Stock = m_stock
      End If
      If Not value.Stock Is Nothing AndAlso value.Stock.Originated Then
        If Not m_stockHash.Contains(value.Stock.Id) Then
          m_stockHash(value.Stock.Id) = PO.GetPO(value.Stock.Id, ViewType.PaySelection)
        End If
        value.Stock = CType(m_stockHash(value.Stock.Id), SimpleBusinessEntityBase)
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As StockItem)
      'For Each wbsd As WBSDistribute In value.WBSDistributeCollection
      '  value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      'Next
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As StockItemCollection)
      'For Each item As StockItem In value
      '  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
      '    item.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      '  Next
      'Next
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class StockItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As StockItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, StockItem)
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