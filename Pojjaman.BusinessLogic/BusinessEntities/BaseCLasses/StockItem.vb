Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper

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
        Private m_entitybase As SimpleBusinessEntityBase
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
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
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
                    .m_tocc = New CostCenter(CInt(dr(aliasPrefix & "stocki_tocc")))
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
                            .m_entity = New LCIItem(itemId)
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
                ' Unit ... 
                If dr.Table.Columns.Contains(aliasPrefix & "unit.unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit.unit_id") Then
                    .m_unit = New Unit(dr, "Unit.")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
                        .m_unit = New Unit(CInt(dr(aliasPrefix & "stocki_unit")))
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
                If dr.Table.Columns.Contains(aliasPrefix & "stocki_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stockqty") Then
                    .m_stockqty = CDec(dr(aliasPrefix & "stocki_stockqty"))
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

        Public Overridable Property Entity() As IHasName            Get                Return m_entity            End Get            Set(ByVal Value As IHasName)                m_entity = Value            End Set        End Property
#End Region

#Region "Properties"
       
        Public Property IsInitialized() As Boolean            Get                Return m_IsInitialized            End Get            Set(ByVal Value As Boolean)                m_IsInitialized = Value            End Set        End Property

        Public Property EntityBase() As SimpleBusinessEntityBase
            Get
                Return m_entitybase
            End Get
            Set(ByVal Value As SimpleBusinessEntityBase)
                m_entitybase = Value
            End Set
        End Property

        Public Property ItemType() As CodeDescription            Get                Return m_itemType            End Get            Set(ByVal Value As CodeDescription)                m_itemType = CType(Value, ItemType)            End Set        End Property

        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property CostCenter() As CostCenter            Get                Return m_cc            End Get            Set(ByVal Value As CostCenter)                m_cc = Value            End Set        End Property        Public Property FromCostcenter() As CostCenter
            Get
                Return m_fromcc
            End Get
            Set(ByVal Value As CostCenter)
                m_fromcc = Value
            End Set
        End Property        Public Property ToCostCenter() As CostCenter            Get
                Return m_tocc
            End Get
            Set(ByVal Value As CostCenter)
                m_tocc = Value
            End Set
        End Property        Public Property ToCustomer() As Customer            Get
                Return m_tocust
            End Get
            Set(ByVal Value As Customer)
                m_tocust = Value
            End Set
        End Property        Public Property ToAccount() As Account            Get
                Return m_toacct
            End Get
            Set(ByVal Value As Account)
                m_toacct = Value
            End Set
        End Property        Public Property ToAccountType() As AccountType            Get
                Return m_toacctType
            End Get
            Set(ByVal Value As AccountType)
                m_toacctType = Value
            End Set
        End Property        Public Property Sequence() As Integer            Get                Return m_sequence            End Get            Set(ByVal Value As Integer)                m_sequence = Value            End Set        End Property        Public Property RefDoc() As Integer            Get                Return m_refDoc            End Get            Set(ByVal Value As Integer)                m_refDoc = Value            End Set        End Property        Public Property RefDocLinenumber() As Integer            Get                Return m_refDocLinenumber            End Get            Set(ByVal Value As Integer)                m_refDocLinenumber = Value            End Set        End Property        Public Property RefSequence() As Integer            Get                Return m_refSequence            End Get            Set(ByVal Value As Integer)                m_refSequence = Value            End Set        End Property        Public Property Itemname() As String            Get                Return m_itemname            End Get            Set(ByVal Value As String)                m_itemname = Value            End Set        End Property        Public Property Unit() As Unit            Get                Return m_unit            End Get            Set(ByVal Value As Unit)                m_unit = Value            End Set        End Property        Public Property Unitprice() As Decimal            Get                Return m_unitprice            End Get            Set(ByVal Value As Decimal)                m_unitprice = Value            End Set        End Property        Public Property Discrate() As Discount            Get                Return m_discrate            End Get            Set(ByVal Value As Discount)                m_discrate = Value            End Set        End Property        Public Property Discamt() As Decimal            Get                Return m_discamt            End Get            Set(ByVal Value As Decimal)                m_discamt = Value            End Set        End Property        Public Property UnitCost() As Decimal            Get                Return m_unitCost            End Get            Set(ByVal Value As Decimal)                m_unitCost = Value            End Set        End Property        Public Property Amount() As Decimal            Get                Return m_amt            End Get            Set(ByVal Value As Decimal)                m_amt = Value            End Set        End Property        Public Property Qty() As Decimal            Get                Return m_qty            End Get            Set(ByVal Value As Decimal)                m_qty = Value            End Set        End Property        Public Property Stockqty() As Decimal            Get                Return m_stockqty            End Get            Set(ByVal Value As Decimal)                m_stockqty = Value            End Set        End Property        Public Property Iscancelled() As Boolean            Get                Return m_iscancelled            End Get            Set(ByVal Value As Boolean)                m_iscancelled = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Property Type() As StockDocType            Get                Return m_type            End Get            Set(ByVal Value As StockDocType)                m_type = Value            End Set        End Property        Public Property Status() As StockStatus            Get                Return m_status            End Get            Set(ByVal Value As StockStatus)                m_status = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Overridable Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Dim obj As SimpleBusinessEntityBase

            Me.EntityBase.IsInitialized = False

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

            Me.EntityBase.IsInitialized = True
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

End Namespace