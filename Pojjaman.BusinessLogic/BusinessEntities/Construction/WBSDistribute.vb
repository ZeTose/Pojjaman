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
  Public Class WBSDistribute

#Region "Members"
    Private m_wbs As WBS
    Private m_cc As CostCenter
    Private m_percent As Decimal
    Private m_isMarkup As Boolean
    Private m_outward As Boolean
    Private m_baseCost As Decimal
    Private m_toaccttype As Integer
    Private m_transferBaseCost As Decimal
    Private m_amount As Decimal

    Private m_qtyOverBudget As Boolean
    Private m_amountOverBudget As Boolean

    Private m_budgetQty As Decimal
    Private m_bfQty As Decimal
    Private m_thisperiodQty As Decimal
    Private m_budgetAmount As Decimal
    Private m_budgetRemain As Decimal
    Private m_qtyRemain As Decimal
    Private m_bfAmount As Decimal
    Private m_thisperiodAmount As Decimal

    Private m_declareAmount As Decimal
    Private m_declareQty As Decimal
    Private m_remainSummary As Decimal
    Private m_qtyremainSummary As Decimal
    Private m_baseQty As Decimal

    Private m_childIdList As ArrayList
    Private m_childAmount As Decimal
#End Region

#Region "Constructors"
    Public Sub New()
      m_wbs = New WBS
      m_childIdList = New ArrayList
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        m_wbs = New WBS
        m_cc = New CostCenter
        m_childIdList = New ArrayList

        If dr.Table.Columns.Contains(aliasPrefix & "stockiw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "stockiw_isMarkup"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "priw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "priw_isMarkup"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "poiw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "poiw_isMarkup"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "sciw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "sciw_isMarkup"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "driw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "driw_isMarkup"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "voiw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "voiw_isMarkup"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "paiw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "paiw_isMarkup"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_isMarkup") AndAlso Not dr.IsNull(aliasPrefix & "wriw_isMarkup") Then
          m_isMarkup = CBool(dr(aliasPrefix & "wriw_isMarkup"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wbs_id") AndAlso Not dr.IsNull(aliasPrefix & "wbs_id") Then
          'm_wbs = New WBS
          m_wbs.Id = CInt(dr(aliasPrefix & "wbs_id"))
          If dr.Table.Columns.Contains(aliasPrefix & "wbs_code") AndAlso Not dr.IsNull(aliasPrefix & "wbs_code") Then
            m_wbs.Code = CStr(dr(aliasPrefix & "wbs_code"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "wbs_name") AndAlso Not dr.IsNull(aliasPrefix & "wbs_name") Then
            m_wbs.Name = CStr(dr(aliasPrefix & "wbs_name"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "wbs_noqtycontrol") AndAlso Not dr.IsNull(aliasPrefix & "wbs_noqtycontrol") Then
            m_wbs.NoQtyControl = CBool(dr(aliasPrefix & "wbs_noqtycontrol"))
          End If
        End If

        'CC
        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") AndAlso Not dr.IsNull(aliasPrefix & "cc_id") Then
          'm_cc = New CostCenter
          If dr.Table.Columns.Contains(aliasPrefix & "stockiw_cc") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "stockiw_cc"))
          ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_cc") AndAlso Not dr.IsNull(aliasPrefix & "priw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "priw_cc"))
          ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_cc") AndAlso Not dr.IsNull(aliasPrefix & "poiw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "poiw_cc"))
          ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_cc") AndAlso Not dr.IsNull(aliasPrefix & "sciw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "sciw_cc"))
          ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_cc") AndAlso Not dr.IsNull(aliasPrefix & "driw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "driw_cc"))
          ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_cc") AndAlso Not dr.IsNull(aliasPrefix & "voiw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "voiw_cc"))
          ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_cc") AndAlso Not dr.IsNull(aliasPrefix & "paiw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "paiw_cc"))
          ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_cc") AndAlso Not dr.IsNull(aliasPrefix & "wriw_cc") Then
            m_cc.Id = CInt(dr(aliasPrefix & "wriw_cc"))
          End If


          If dr.Table.Columns.Contains(aliasPrefix & "cc_code") AndAlso Not dr.IsNull(aliasPrefix & "cc_code") Then
            m_cc.Code = CStr(dr(aliasPrefix & "cc_code"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "cc_name") AndAlso Not dr.IsNull(aliasPrefix & "cc_name") Then
            m_cc.Name = CStr(dr(aliasPrefix & "cc_name"))
          End If
          If dr.Table.Columns.Contains(aliasPrefix & "cc_boq") AndAlso Not dr.IsNull(aliasPrefix & "cc_boq") Then
            m_cc.BoqId = CInt(dr(aliasPrefix & "cc_boq"))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stockiw_percent") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "stockiw_percent"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_percent") AndAlso Not dr.IsNull(aliasPrefix & "priw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "priw_percent"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_percent") AndAlso Not dr.IsNull(aliasPrefix & "poiw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "poiw_percent"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_percent") AndAlso Not dr.IsNull(aliasPrefix & "sciw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "sciw_percent"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_percent") AndAlso Not dr.IsNull(aliasPrefix & "driw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "driw_percent"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_percent") AndAlso Not dr.IsNull(aliasPrefix & "voiw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "voiw_percent"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_percent") AndAlso Not dr.IsNull(aliasPrefix & "paiw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "paiw_percent"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_percent") AndAlso Not dr.IsNull(aliasPrefix & "wriw_percent") Then
          m_percent = CDec(dr(aliasPrefix & "wriw_percent"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stockiw_amt") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "stockiw_amt"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_amt") AndAlso Not dr.IsNull(aliasPrefix & "priw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "priw_amt"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_amt") AndAlso Not dr.IsNull(aliasPrefix & "poiw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "poiw_amt"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_amt") AndAlso Not dr.IsNull(aliasPrefix & "sciw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "sciw_amt"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_amt") AndAlso Not dr.IsNull(aliasPrefix & "driw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "driw_amt"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_amt") AndAlso Not dr.IsNull(aliasPrefix & "voiw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "voiw_amt"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_amt") AndAlso Not dr.IsNull(aliasPrefix & "paiw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "paiw_amt"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_amt") AndAlso Not dr.IsNull(aliasPrefix & "wriw_amt") Then
          m_amount = CDec(dr(aliasPrefix & "wriw_amt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stockiw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "stockiw_baseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "priw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "priw_baseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "poiw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "poiw_baseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "sciw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "sciw_baseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "driw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "driw_baseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "voiw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "voiw_baseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "paiw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "paiw_baseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_baseCost") AndAlso Not dr.IsNull(aliasPrefix & "wriw_baseCost") Then
          m_baseCost = CDec(dr(aliasPrefix & "wriw_baseCost"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stockiw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "stockiw_transferBaseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "priw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "priw_transferBaseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "poiw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "poiw_transferBaseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "sciw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "sciw_transferBaseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "driw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "driw_transferBaseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "voiw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "voiw_transferBaseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "paiw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "paiw_transferBaseCost"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_transferBaseCost") AndAlso Not dr.IsNull(aliasPrefix & "wriw_transferBaseCost") Then
          m_transferBaseCost = CDec(dr(aliasPrefix & "wriw_transferBaseCost"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stockiw_direction") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "stockiw_direction"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_direction") AndAlso Not dr.IsNull(aliasPrefix & "priw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "priw_direction"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_direction") AndAlso Not dr.IsNull(aliasPrefix & "poiw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "poiw_direction"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_direction") AndAlso Not dr.IsNull(aliasPrefix & "sciw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "sciw_direction"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_direction") AndAlso Not dr.IsNull(aliasPrefix & "driw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "driw_direction"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_direction") AndAlso Not dr.IsNull(aliasPrefix & "voiw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "voiw_direction"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_direction") AndAlso Not dr.IsNull(aliasPrefix & "paiw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "paiw_direction"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_direction") AndAlso Not dr.IsNull(aliasPrefix & "wriw_direction") Then
          m_outward = CBool(dr(aliasPrefix & "wriw_direction"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stockiw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "stockiw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "stockiw_toaccttype"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "priw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "priw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "priw_toaccttype"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "poiw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "poiw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "poiw_toaccttype"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sciw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "sciw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "sciw_toaccttype"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "driw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "driw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "driw_toaccttype"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "paiw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "paiw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "paiw_toaccttype"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "voiw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "voiw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "voiw_toaccttype"))
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "wriw_toaccttype") AndAlso Not dr.IsNull(aliasPrefix & "wriw_toaccttype") Then
          m_toaccttype = CInt(dr(aliasPrefix & "wriw_toaccttype"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "budgetremain") AndAlso Not dr.IsNull(aliasPrefix & "budgetremain") Then
          Me.m_budgetRemain = CDec(dr(aliasPrefix & "budgetremain"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "qtyremain") AndAlso Not dr.IsNull(aliasPrefix & "qtyremain") Then
          Me.m_qtyRemain = CDec(dr(aliasPrefix & "qtyremain"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "qty") AndAlso Not dr.IsNull(aliasPrefix & "qty") Then
          Me.m_baseQty = CDec(dr(aliasPrefix & "qty"))
        End If

        'm_childIdList = .GetChildIdList(m_wbs.Id)

      End With
    End Sub

#End Region

#Region "Properties"
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
    Private Sub OnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'm_htChangedProperties(e.Name) = e.Value
      RaiseEvent PropertyChanged(sender, e)
    End Sub
    Public Property QtyOverBudget() As Boolean
      Get
        Return m_qtyOverBudget
      End Get
      Set(ByVal Value As Boolean)
        m_qtyOverBudget = Value
      End Set
    End Property
    Public Property AmountOverBudget() As Boolean
      Get
        Return m_amountOverBudget
      End Get
      Set(ByVal Value As Boolean)
        m_amountOverBudget = Value
      End Set
    End Property
    Public Property BudgetQty() As Decimal      Get        Return m_budgetQty      End Get      Set(ByVal Value As Decimal)        m_budgetQty = Value      End Set    End Property    Public Property BfQty() As Decimal      Get        Return m_bfQty      End Get      Set(ByVal Value As Decimal)        m_bfQty = Value      End Set    End Property    Public Property ThisperiodQty() As Decimal      Get        Return m_thisperiodQty      End Get      Set(ByVal Value As Decimal)        m_thisperiodQty = Value      End Set    End Property    Public Property DeclareQty() As Decimal      Get        Return m_declareQty      End Get      Set(ByVal Value As Decimal)        m_declareQty = Value      End Set    End Property    Public Property BudgetAmount() As Decimal      Get        Return m_budgetAmount      End Get      Set(ByVal Value As Decimal)        m_budgetAmount = Value      End Set    End Property    Public Property BudgetRemain() As Decimal      Get        Return m_budgetRemain      End Get      Set(ByVal Value As Decimal)        m_budgetRemain = Value      End Set    End Property    Public Property QtyRemain() As Decimal      Get        Return m_qtyRemain      End Get      Set(ByVal Value As Decimal)        m_qtyRemain = Value      End Set    End Property    Public Property RemainSummary() As Decimal      Get        Return m_remainSummary      End Get      Set(ByVal Value As Decimal)        m_remainSummary = Value      End Set    End Property    Public Property QtyRemainSummary() As Decimal      Get        Return m_qtyremainSummary      End Get      Set(ByVal Value As Decimal)        m_qtyremainSummary = Value      End Set    End Property    Public ReadOnly Property Qty() As Decimal      Get        Return m_baseQty * (m_percent / 100)      End Get    End Property    Public Property BaseQty() As Decimal      Get
        Return m_baseQty
      End Get
      Set(ByVal Value As Decimal)
        m_baseQty = Value
      End Set
    End Property    Public Property BfAmount() As Decimal      Get        Return m_bfAmount      End Get      Set(ByVal Value As Decimal)        m_bfAmount = Value      End Set    End Property    Public Property ThisperiodAmount() As Decimal      Get        Return m_thisperiodAmount      End Get      Set(ByVal Value As Decimal)        m_thisperiodAmount = Value      End Set    End Property
    Public Property BaseCost() As Decimal      Get        Return m_baseCost      End Get      Set(ByVal Value As Decimal)        m_baseCost = Value        m_amount = m_baseCost * m_percent / 100      End Set    End Property    Public Property TransferBaseCost() As Decimal      Get        Return m_transferBaseCost      End Get      Set(ByVal Value As Decimal)        m_transferBaseCost = Value      End Set    End Property    'Public ReadOnly Property Amount() As Decimal    '  Get    '    Return m_baseCost * m_percent / 100    '  End Get    'End Property    Public Property Amount() As Decimal      Get        'Return m_baseCost * m_percent / 100        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value
        m_percent = (Value / m_baseCost) * 100
      End Set    End Property    Public ReadOnly Property TransferAmount() As Decimal      Get        Return m_transferBaseCost * m_percent / 100      End Get    End Property    Public Property Toaccttype() As Integer      Get        Return m_toaccttype      End Get      Set(ByVal Value As Integer)        m_toaccttype = Value      End Set    End Property
    Public Property WBS() As WBS      Get        Return m_wbs      End Get      Set(ByVal Value As WBS)        Dim oldVal As WBS = m_wbs        m_wbs = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs("WBS", m_wbs, oldVal))      End Set    End Property    Public Property CostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value      End Set    End Property    Public Property Percent() As Decimal      Get        Return m_percent      End Get      Set(ByVal Value As Decimal)        Dim oldVal As Decimal = TransferAmount        m_percent = Value        m_amount = m_baseCost * m_percent / 100        OnPropertyChanged(Me, New PropertyChangedEventArgs("Percent", TransferAmount, oldVal))      End Set    End Property
    Public Property IsMarkup() As Boolean      Get        Return m_isMarkup      End Get      Set(ByVal Value As Boolean)        m_isMarkup = Value      End Set    End Property
    Public Property IsOutWard() As Boolean
      Get
        Return m_outward
      End Get
      Set(ByVal Value As Boolean)
        m_outward = Value
      End Set
    End Property
    Public ReadOnly Property ChildIdList As ArrayList
      Get
        Return m_childIdList
      End Get
    End Property
    Public Property ChildAmount As Decimal
      Get
        Return m_childAmount
      End Get
      Set(ByVal value As Decimal)
        m_childAmount = value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("WBS")
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("WBS", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Percent", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      ' งบประมาณ & ปริมาณ คงเหลือ
      myDatatable.Columns.Add(New DataColumn("BudgetRemain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("QtyRemain", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetUsedAmount(ByVal transferAmount As Decimal, ByVal fifoAmount As Decimal, ByVal isOut As Boolean, ByVal view As Integer, ByVal toAcctType As Integer) As Decimal
      Dim amt As Decimal = 0
      Select Case view
        Case 45, 7, 6 'รับของ,PR,PO
          Select Case toAcctType
            Case 1, 2 'WIP/EXP
              If isOut Then 'WBS จ่าย
                amt = -transferAmount
              Else 'WBS รับ
                amt = transferAmount
              End If
            Case 3 'Store
              If isOut Then 'WBS จ่าย
                amt = -transferAmount
              Else 'WBS รับ
                amt = transferAmount
              End If
          End Select
        Case 31 'เบิกของ
          Select Case toAcctType
            Case 1, 2 'WIP/EXP
              If isOut Then 'WBS จ่าย
                amt = -transferAmount '0
              Else 'WBS รับ
                amt = transferAmount
              End If
            Case 3 'Store
              If isOut Then 'WBS จ่าย
                amt = 0
              Else 'WBS รับ
                amt = 0
              End If
          End Select
      End Select
      Return amt
    End Function
    Public Shared Function GetUsedQty(ByVal stockQty As Decimal, ByVal isOut As Boolean, ByVal view As Integer, ByVal toAcctType As Integer) As Decimal
      Dim qty As Decimal = 0
      Select Case view
        Case 45, 7, 6 'รับของ,PR,PO
          Select Case toAcctType
            Case 1, 2 'WIP/EXP
              If isOut Then 'WBS จ่าย
                qty = -stockQty
              Else 'WBS รับ
                qty = stockQty
              End If
            Case 3 'Store
              If isOut Then 'WBS จ่าย
                qty = -stockQty
              Else 'WBS รับ
                qty = stockQty
              End If
          End Select
        Case Else 'เบิกของ
          Select Case toAcctType
            Case 1, 2 'WIP/EXP
              If isOut Then 'WBS จ่าย
                qty = -stockQty '0
              Else 'WBS รับ
                qty = stockQty
              End If
            Case 3 'Store
              If isOut Then 'WBS จ่าย
                qty = 0
              Else 'WBS รับ
                qty = 0
              End If
          End Select
      End Select
      Return qty
    End Function
#End Region

#Region "Methods"
    Public Function Clone() As WBSDistribute
      Dim newWbsd As New WBSDistribute
      newWbsd.CostCenter = Me.CostCenter
      newWbsd.WBS = Me.WBS
      newWbsd.Percent = Me.Percent
      newWbsd.IsMarkup = Me.IsMarkup
      newWbsd.IsOutWard = Me.IsOutWard
      newWbsd.BudgetAmount = Me.BudgetAmount
      newWbsd.BudgetQty = Me.BudgetQty
      Return newWbsd
    End Function
    Public Sub GetChildIdList()
      Dim newArray As New ArrayList
      Dim ConnString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnString, CommandType.Text, "select depend_wbs from swang_Depend where depend_parent = " & Me.WBS.Id)
      For Each row As DataRow In ds.Tables(0).Rows
        If Not row.IsNull("depend_wbs") Then
          newArray.Add(CInt(row("depend_wbs")))
        End If
      Next
      m_childIdList = newArray
    End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class WBSDistributeCollection
    Inherits CollectionBase

#Region "Constructors"
    Public Sub New()
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As WBSDistribute
      Get
        Return CType(MyBase.List.Item(index), WBSDistribute)
      End Get
      Set(ByVal value As WBSDistribute)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable, ByVal item As PRItem, ByVal view As Integer)
      dt.Clear()
      Dim i As Integer = 0
      For Each wbsd As WBSDistribute In Me
        i += 1
        Dim transferAmt As Decimal = item.Amount
        wbsd.BaseCost = item.Amount
        wbsd.TransferBaseCost = transferAmt
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not wbsd.CostCenter Is Nothing Then
          newRow("CostCenter") = wbsd.CostCenter.Code & ":" & wbsd.CostCenter.Name
        Else
          newRow("CostCenter") = ""
        End If
        newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
        newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
        Dim isOut As Boolean = False
        Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, 3)
        'newRow("Amount") = Configuration.FormatToString(amt * wbsd.Percent / 100, DigitConfig.Price)
        newRow("Amount") = Configuration.FormatToString(wbsd.Amount, DigitConfig.Price)
        If Not wbsd.IsMarkup Then
          'เป็น WBS
          Dim actual As Decimal = 0
          Dim currentDiff As Decimal = 0
          Dim actualQty As Decimal = 0
          Dim currentQty As Decimal = 0

          Dim theName As String = item.EntityName
          If theName Is Nothing Then
            theName = item.Entity.Name
          End If
          Select Case item.ItemType.Value
            Case 0 'อื่นๆ
              actual = wbsd.WBS.GetActualMat(item.Pr, view)

              actualQty = wbsd.WBS.GetActualType0Qty(item.Pr, view)
              currentQty = item.Pr.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 0)
            Case 19 'Tool
              actual = wbsd.WBS.GetActualMat(item.Pr, view)

              actualQty = wbsd.WBS.GetActualMatQty(item.Pr, view, item.Entity.Id, 19)
              currentQty = item.Pr.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 19)
            Case 42 'Mat
              actual = wbsd.WBS.GetActualMat(item.Pr, view)

              actualQty = wbsd.WBS.GetActualMatQty(item.Pr, view, item.Entity.Id, 42)
              currentQty = item.Pr.GetCurrentMatQtyForWBS(wbsd.WBS, item.Entity.Id)
            Case 88 'Lab
              actual = wbsd.WBS.GetActualLab(item.Pr, view)

              actualQty = wbsd.WBS.GetActualLabQty(item.Pr, view)
              currentQty = item.Pr.GetCurrentLabQtyForWBS(wbsd.WBS, theName)
            Case 89 'Eq
              actual = wbsd.WBS.GetActualEq(item.Pr, view)

              actualQty = wbsd.WBS.GetActualEqQty(item.Pr, view)
              currentQty = item.Pr.GetCurrentEqQtyForWBS(wbsd.WBS, theName)
          End Select
          currentDiff = item.Pr.GetCurrentDiffForWBS(wbsd.WBS, item.ItemType)
          'currentDiff = new actual - old actual
          'budget 100 actual 80 diff = 20
          'budget 100 actual 60 currentDiff = 60 - 80 = -20 --> diff = 100 - (80 +(-20))
          'budget 100 actual 100 currentDiff = 100 - 80 = 20 --> diff = 100 - (80 + 20)


          'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
          Dim budgetRemain As Decimal = wbsd.BudgetAmount - (actual + currentDiff)
          If budgetRemain < 0 Then
            wbsd.AmountOverBudget = True
          Else
            wbsd.AmountOverBudget = False
          End If
          wbsd.BudgetRemain = budgetRemain
          newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)

          'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
          Dim qtyRemain As Decimal = wbsd.BudgetQty - actualQty - currentQty
          If qtyRemain < 0 AndAlso Not wbsd.WBS.NoQtyControl Then
            wbsd.QtyOverBudget = True
          Else
            wbsd.QtyOverBudget = False
          End If
          wbsd.QtyRemain = qtyRemain
          newRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Price)
        Else
          'เป็น markup
          Dim mk As New Markup(wbsd.WBS.Id)
          If Not mk Is Nothing Then
            wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.Pr, view) - item.Pr.GetCurrentAmountForMarkup(mk)
            newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)
            'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
          End If
        End If
        newRow.Tag = wbsd
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal item As POItem, ByVal view As Integer)
      dt.Clear()
      Dim i As Integer = 0
      If Not item.Po Is Nothing Then
        item.Po.RefreshTaxBase()
      End If
      For Each wbsd As WBSDistribute In Me
        i += 1
        Dim bfTax As Decimal = 0
        If Not item.Po Is Nothing Then 'AndAlso item.Po.Originated
          If item.Po.Closed Then
            bfTax = item.ReceivedBeforeTax
          Else
            bfTax = item.BeforeTax
          End If
        End If
        Dim transferAmt As Decimal = bfTax
        wbsd.BaseCost = bfTax
        wbsd.TransferBaseCost = transferAmt
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not wbsd.CostCenter Is Nothing Then
          newRow("CostCenter") = wbsd.CostCenter.Code & ":" & wbsd.CostCenter.Name
        Else
          newRow("CostCenter") = ""
        End If
        newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
        newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
        Dim isOut As Boolean = False
        'Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.TaxBase, isOut, view, 3)
        'newRow("Amount") = Configuration.FormatToString(amt * wbsd.Percent / 100, DigitConfig.Price)
        newRow("Amount") = Configuration.FormatToString(wbsd.Amount, DigitConfig.Price)
        If Not wbsd.IsMarkup Then
          Dim actual As Decimal = 0
          Dim currentDiff As Decimal = 0
          Dim actualQty As Decimal = 0
          Dim currentQty As Decimal = 0

          Dim theName As String = item.EntityName
          If theName Is Nothing Then
            theName = item.Entity.Name
          End If
          Select Case item.ItemType.Value
            Case 0 'อื่นๆ
              actual = wbsd.WBS.GetActualMat(item.Po, view)

              actualQty = wbsd.WBS.GetActualType0Qty(item.Po, view)
              currentQty = item.Po.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 0)
            Case 19 'Tool
              actual = wbsd.WBS.GetActualMat(item.Po, view)

              actualQty = wbsd.WBS.GetActualMatQty(item.Po, view, item.Entity.Id, 19)
              currentQty = item.Po.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 19)
            Case 42 'Mat
              actual = wbsd.WBS.GetActualMat(item.Po, view)

              actualQty = wbsd.WBS.GetActualMatQty(item.Po, view, item.Entity.Id, 42)
              currentQty = item.Po.GetCurrentMatQtyForWBS(wbsd.WBS, item.Entity.Id)
            Case 88 'Lab
              actual = wbsd.WBS.GetActualLab(item.Po, view)

              actualQty = wbsd.WBS.GetActualLabQty(item.Po, view)
              currentQty = item.Po.GetCurrentLabQtyForWBS(wbsd.WBS, theName)
            Case 89 'Eq
              actual = wbsd.WBS.GetActualEq(item.Po, view)

              actualQty = wbsd.WBS.GetActualEqQty(item.Po, view)
              currentQty = item.Po.GetCurrentEqQtyForWBS(wbsd.WBS, theName)
          End Select
          currentDiff = item.Po.GetCurrentDiffForWBS(wbsd.WBS, item.ItemType)
          'currentDiff = new actual - old actual
          'budget 100 actual 80 diff = 20
          'budget 100 actual 60 currentDiff = 60 - 80 = -20 --> diff = 100 - (80 +(-20))
          'budget 100 actual 100 currentDiff = 100 - 80 = 20 --> diff = 100 - (80 + 20)


          'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
          Dim budgetRemain As Decimal = wbsd.BudgetAmount - (actual + currentDiff)
          If budgetRemain < 0 Then
            wbsd.AmountOverBudget = True
          Else
            wbsd.AmountOverBudget = False
          End If
          wbsd.BudgetRemain = budgetRemain
          newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)

          'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
          Dim qtyRemain As Decimal = wbsd.BudgetQty - actualQty - currentQty
          If qtyRemain < 0 AndAlso Not wbsd.WBS.NoQtyControl Then
            wbsd.QtyOverBudget = True
          Else
            wbsd.QtyOverBudget = False
          End If
          wbsd.QtyRemain = qtyRemain
          newRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Price)
        Else
          Dim mk As New Markup(wbsd.WBS.Id)
          If Not mk Is Nothing Then
            wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.Po, view) - item.Po.GetCurrentAmountForMarkup(mk)
            newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)
            'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
          End If
        End If
        newRow.Tag = wbsd
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal item As PurchaseCNItem, ByVal view As Integer)
      dt.Clear()
      'Dim i As Integer = 0
      'For Each wbsd As WBSDistribute In Me
      '    i += 1
      '    wbsd.WBS.Boq = item.PurchaseCN.ToCostCenter.Boq
      '    Dim transferAmt As Decimal = item.Amount
      '    wbsd.BaseCost = item.Amount
      '    wbsd.TransferBaseCost = transferAmt
      '    Dim newRow As TreeRow = dt.Childs.Add()
      '    newRow("Linenumber") = i
      '    newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
      '    newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
      '    Dim isOut As Boolean = False
      '    Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, item.GoodsReceipt.ToAccountType.Value)
      '    newRow("Amount") = Configuration.FormatToString(amt * wbsd.Percent / 100, DigitConfig.Price)
      '    If Not wbsd.IsMarkup Then
      '        Dim actual As Decimal = 0
      '        Dim budget As Decimal = 0
      '        Dim current As Decimal = 0
      '        Dim budgetQty As Decimal = 0
      '        Dim actualQty As Decimal = 0
      '        Dim currentQty As Decimal = 0

      '        Dim theName As String = item.EntityName
      '        If theName Is Nothing Then
      '            theName = item.Entity.Name
      '        End If
      '        Select Case item.ItemType.Value
      '            Case 0 'อื่นๆ
      '                actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, view)
      '                budget = wbsd.WBS.GetTotalMatFromDB

      '                budgetQty = wbsd.WBS.GetBudgetQtyForType0FromDB(theName)
      '                actualQty = wbsd.WBS.GetActualMatQty(item.GoodsReceipt, view)
      '                currentQty = item.GoodsReceipt.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 0)
      '            Case 19 'Tool
      '                actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, view)
      '                budget = wbsd.WBS.GetTotalMatFromDB

      '                budgetQty = 0 'ไม่มี budget ให้เครื่องมือแน่ๆ
      '                actualQty = wbsd.WBS.GetActualMatQty(item.GoodsReceipt, view)
      '                currentQty = item.GoodsReceipt.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 19)
      '            Case 42 'Mat
      '                actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, view)
      '                budget = wbsd.WBS.GetTotalMatFromDB

      '                budgetQty = wbsd.WBS.GetTotalMatQtyFromDB(item.Entity.Id)
      '                actualQty = wbsd.WBS.GetActualMatQty(item.GoodsReceipt, view)
      '                currentQty = item.GoodsReceipt.GetCurrentMatQtyForWBS(wbsd.WBS, item.Entity.Id)
      '            Case 88 'Lab
      '                actual = wbsd.WBS.GetActualLab(item.GoodsReceipt, view)
      '                budget = wbsd.WBS.GetTotalLabFromDB

      '                budgetQty = wbsd.WBS.GetTotalLabQtyFromDB(theName)
      '                actualQty = wbsd.WBS.GetActualLabQty(item.GoodsReceipt, view)
      '                currentQty = item.GoodsReceipt.GetCurrentLabQtyForWBS(wbsd.WBS, theName)
      '            Case 89 'Eq
      '                actual = wbsd.WBS.GetActualEq(item.GoodsReceipt, view)
      '                budget = wbsd.WBS.GetTotalEqFromDB

      '                budgetQty = wbsd.WBS.GetTotalEqQtyFromDB(theName)
      '                actualQty = wbsd.WBS.GetActualEqQty(item.GoodsReceipt, view)
      '                currentQty = item.GoodsReceipt.GetCurrentEqQtyForWBS(wbsd.WBS, theName)
      '        End Select
      '        current = item.GoodsReceipt.GetCurrentAmountForWBS(wbsd.WBS, item.ItemType)

      '        'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
      '        newRow("BudgetRemain") = Configuration.FormatToString(budget - actual - current, DigitConfig.Price)

      '        'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
      '        newRow("QtyRemain") = Configuration.FormatToString(budgetQty - actualQty - currentQty, DigitConfig.Price)
      '    Else
      '        Dim mk As New Markup(wbsd.WBS.Id)
      '        If Not mk Is Nothing Then
      '            newRow("BudgetRemain") = Configuration.FormatToString(mk.StoredTotalAmount - mk.GetActualTotal(item.GoodsReceipt, view) - item.GoodsReceipt.GetCurrentAmountForMarkup(mk), DigitConfig.Price)
      '            'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
      '        End If
      '    End If
      '    newRow.Tag = wbsd
      'Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal item As GoodsReceiptItem, ByVal view As Integer)
      dt.Clear()
      Dim i As Integer = 0
      For Each wbsd As WBSDistribute In Me
        i += 1
        Dim transferAmt As Decimal = item.Cost
        wbsd.BaseCost = transferAmt
        wbsd.TransferBaseCost = transferAmt
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not wbsd.CostCenter Is Nothing Then
          newRow("CostCenter") = wbsd.CostCenter.Code & ":" & wbsd.CostCenter.Name
        Else
          newRow("CostCenter") = ""
        End If
        newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
        newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
        Dim isOut As Boolean = False
        'Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.TaxBase, isOut, view, item.GoodsReceipt.ToAccountType.Value)
        'newRow("Amount") = Configuration.FormatToString(amt * wbsd.Percent / 100, DigitConfig.Price)
        newRow("Amount") = Configuration.FormatToString(wbsd.Amount, DigitConfig.Price)
        If Not wbsd.IsMarkup Then
          Dim actual As Decimal = 0
          Dim currentDiff As Decimal = 0
          Dim actualQty As Decimal = 0
          Dim currentQty As Decimal = 0

          Dim theName As String = item.EntityName
          If theName Is Nothing Then
            theName = item.Entity.Name
          End If
          Select Case item.ItemType.Value
            Case 0 'อื่นๆ
              actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, view)

              actualQty = wbsd.WBS.GetActualType0Qty(item.GoodsReceipt, view)
              currentQty = item.GoodsReceipt.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 0)
            Case 19 'Tool
              actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, view)

              actualQty = wbsd.WBS.GetActualMatQty(item.GoodsReceipt, view, item.Entity.Id, 19)
              currentQty = item.GoodsReceipt.GetCurrentTypeQtyForWBS(wbsd.WBS, theName, 19)
            Case 42 'Mat
              actual = wbsd.WBS.GetActualMat(item.GoodsReceipt, view)

              actualQty = wbsd.WBS.GetActualMatQty(item.GoodsReceipt, view, item.Entity.Id, 42)
              currentQty = item.GoodsReceipt.GetCurrentMatQtyForWBS(wbsd.WBS, item.Entity.Id)
            Case 88 'Lab
              actual = wbsd.WBS.GetActualLab(item.GoodsReceipt, view)

              actualQty = wbsd.WBS.GetActualLabQty(item.GoodsReceipt, view)
              currentQty = item.GoodsReceipt.GetCurrentLabQtyForWBS(wbsd.WBS, theName)
            Case 89 'Eq
              actual = wbsd.WBS.GetActualEq(item.GoodsReceipt, view)

              actualQty = wbsd.WBS.GetActualEqQty(item.GoodsReceipt, view)
              currentQty = item.GoodsReceipt.GetCurrentEqQtyForWBS(wbsd.WBS, theName)
          End Select
          currentDiff = item.GoodsReceipt.GetCurrentDiffForWBS(wbsd.WBS, item.ItemType)
          'currentDiff = new actual - old actual
          'budget 100 actual 80 diff = 20
          'budget 100 actual 60 currentDiff = 60 - 80 = -20 --> diff = 100 - (80 +(-20))
          'budget 100 actual 100 currentDiff = 100 - 80 = 20 --> diff = 100 - (80 + 20)


          'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
          Dim budgetRemain As Decimal = wbsd.BudgetAmount - (actual + currentDiff)
          If budgetRemain < 0 Then
            wbsd.AmountOverBudget = True
          Else
            wbsd.AmountOverBudget = False
          End If
          wbsd.BudgetRemain = budgetRemain
          newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)

          'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
          Dim qtyRemain As Decimal = wbsd.BudgetQty - actualQty - currentQty
          If qtyRemain < 0 AndAlso Not wbsd.WBS.NoQtyControl Then
            wbsd.QtyOverBudget = True
          Else
            wbsd.QtyOverBudget = False
          End If
          wbsd.QtyRemain = qtyRemain
          newRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Price)
        Else
          Dim mk As New Markup(wbsd.WBS.Id)
          If Not mk Is Nothing Then
            wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.GoodsReceipt, view) - item.GoodsReceipt.GetCurrentAmountForMarkup(mk)
            newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)
            'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
          End If
        End If
        newRow.Tag = wbsd
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal item As AssetWithdrawItem, ByVal view As Integer)
      dt.Clear()
      Dim i As Integer = 0
      For Each wbsd As WBSDistribute In Me
        i += 1
        wbsd.WBS.Boq = item.AssetWithdraw.WithdrawCostcenter.Boq
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not wbsd.CostCenter Is Nothing Then
          newRow("CostCenter") = wbsd.CostCenter.Code & ":" & wbsd.CostCenter.Name
        Else
          newRow("CostCenter") = ""
        End If
        newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
        newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
        Dim isOut As Boolean = False
        Dim amt As Decimal = WBSDistribute.GetUsedAmount(wbsd.BaseCost, item.Amount, isOut, view, 3)
        newRow("Amount") = Configuration.FormatToString(amt * wbsd.Percent / 100, DigitConfig.Price)
        If Not wbsd.IsMarkup Then
          Dim actual As Decimal = 0
          Dim budget As Decimal = 0
          Dim current As Decimal = 0
          Dim budgetQty As Decimal = 0
          Dim actualQty As Decimal = 0
          Dim currentQty As Decimal = 0

          Dim theName As String = item.Entity.Name
          actual = wbsd.WBS.GetActualMat(item.AssetWithdraw, view)
          budget = wbsd.WBS.GetTotalMatFromDB
          current = item.AssetWithdraw.GetCurrentAmountForWBS(wbsd.WBS, Nothing)

          'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
          wbsd.BudgetRemain = budget - actual - current
          newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)

          'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
          wbsd.QtyRemain = budgetQty - actualQty - currentQty
          newRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Price)
        Else
          Dim mk As New Markup(wbsd.WBS.Id)
          If Not mk Is Nothing Then
            wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.AssetWithdraw, view) - item.AssetWithdraw.GetCurrentAmountForMarkup(mk)
            newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)
            'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
          End If
        End If
        newRow.Tag = wbsd
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal item As MatWithdrawItem, ByVal view As Integer, ByVal isOut As Boolean)
      dt.Clear()
      Dim i As Integer = 0
      For Each wbsd As WBSDistribute In Me
        i += 1
        If Not isOut Then
          wbsd.WBS.Boq = item.Matwithdraw.ToCostCenter.Boq
        Else
          wbsd.WBS.Boq = item.Matwithdraw.FromCostCenter.Boq
        End If
        wbsd.BaseCost = item.TransferAmount
        wbsd.TransferBaseCost = item.TransferAmount
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not wbsd.CostCenter Is Nothing Then
          newRow("CostCenter") = wbsd.CostCenter.Code & ":" & wbsd.CostCenter.Name
        Else
          newRow("CostCenter") = ""
        End If
        newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
        newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
        Dim amt As Decimal = WBSDistribute.GetUsedAmount(item.TransferAmount, item.Amount, isOut, view, item.Matwithdraw.Type.Value)
        newRow("Amount") = Configuration.FormatToString(amt * wbsd.Percent / 100, DigitConfig.Price)
        If Not wbsd.IsMarkup Then
          Dim budget As Decimal = 0
          Dim actual As Decimal = 0
          Dim currentDiff As Decimal = 0
          actual = wbsd.WBS.GetActualMat(item.Matwithdraw, view)
          budget = wbsd.WBS.GetTotalMatFromDB
          'current = item.Matwithdraw.GetCurrentAmountForWBS(wbsd.WBS, isOut)

          currentDiff = item.Matwithdraw.GetCurrentDiffForWBS(wbsd.WBS, isOut)

          'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
          wbsd.BudgetRemain = budget - (actual + currentDiff)
          newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)
          If wbsd.BudgetRemain < 0 Then
            wbsd.AmountOverBudget = True
          Else
            wbsd.AmountOverBudget = False
          End If

          Dim budgetQty As Decimal = 0
          Dim actualQty As Decimal = 0
          Dim currentQty As Decimal = 0
          budgetQty = wbsd.WBS.GetActualMatQty(item.Matwithdraw, view, item.Entity.Id, 42)
          actualQty = wbsd.WBS.GetActualTotalQty(item.Matwithdraw, view)
          currentQty = item.Matwithdraw.GetCurrentQtyForWBS(wbsd.WBS, wbsd.WBS.GetUnit, isOut)
          'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
          wbsd.QtyRemain = budgetQty - actualQty - currentQty
          newRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Price)
          If wbsd.QtyRemain < 0 Then
            wbsd.QtyOverBudget = True
          Else
            wbsd.QtyOverBudget = False
          End If
        Else
          Dim mk As New Markup(wbsd.WBS.Id)
          If Not mk Is Nothing Then
            wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.Matwithdraw, view) - item.Matwithdraw.GetCurrentAmountForMarkup(mk, isOut)
            newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)
            'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
          End If
        End If
        newRow.Tag = wbsd
      Next
    End Sub
    Public Sub Populate(ByVal dt As TreeTable, ByVal item As MatReturnItem, ByVal view As Integer, ByVal isOut As Boolean)
      dt.Clear()
      Dim i As Integer = 0
      For Each wbsd As WBSDistribute In Me
        i += 1
        If Not isOut Then
          wbsd.WBS.Boq = item.MatReturn.ToCostCenter.Boq
        Else
          wbsd.WBS.Boq = item.MatReturn.FromCostCenter.Boq
        End If
        wbsd.BaseCost = item.TransferAmount
        wbsd.TransferBaseCost = item.TransferAmount
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        If Not wbsd.CostCenter Is Nothing Then
          newRow("CostCenter") = wbsd.CostCenter.Code & ":" & wbsd.CostCenter.Name
        Else
          newRow("CostCenter") = ""
        End If
        newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
        newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
        Dim type As Integer = 3
        If isOut Then
          type = 1
        End If
        Dim amt As Decimal = WBSDistribute.GetUsedAmount(item.TransferAmount, item.Amount, isOut, view, type)
        newRow("Amount") = Configuration.FormatToString(amt * wbsd.Percent / 100, DigitConfig.Price)
        If Not wbsd.IsMarkup Then
          Dim budget As Decimal = 0
          Dim actual As Decimal = 0
          Dim current As Decimal = 0
          actual = wbsd.WBS.GetActualMat(item.MatReturn, view)
          budget = wbsd.WBS.GetTotalMatFromDB
          current = item.MatReturn.GetCurrentAmountForWBS(wbsd.WBS, isOut)
          'MessageBox.Show(String.Format("{0}:{1}:{2}", actual, budget, current))
          wbsd.BudgetRemain = budget - actual - current
          newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)

          Dim budgetQty As Decimal = 0
          Dim actualQty As Decimal = 0
          Dim currentQty As Decimal = 0
          budgetQty = wbsd.WBS.GetActualMatQty(item.MatReturn, view, item.Entity.Id, 42)
          actualQty = wbsd.WBS.GetActualTotalQty(item.MatReturn, view)
          currentQty = item.MatReturn.GetCurrentQtyForWBS(wbsd.WBS, wbsd.WBS.GetUnit, isOut)
          'MessageBox.Show(String.Format("{0}:{1}:{2}", budgetQty, actualQty, currentQty))
          wbsd.QtyRemain = budgetQty - actualQty - currentQty
          newRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Price)
        Else
          Dim mk As New Markup(wbsd.WBS.Id)
          If Not mk Is Nothing Then
            wbsd.BudgetRemain = mk.StoredTotalAmount - mk.GetActualTotal(item.MatReturn, view) - item.MatReturn.GetCurrentAmountForMarkup(mk, isOut)
            newRow("BudgetRemain") = Configuration.FormatToString(wbsd.BudgetRemain, DigitConfig.Price)
            'newRow("QtyRemain") = Configuration.FormatToString(wbsd.WBS.GetTotal, DigitConfig.Price)
          End If
        End If
        newRow.Tag = wbsd
      Next
    End Sub
    'Public Sub Populate(ByVal dt As TreeTable, ByVal amount As Decimal)
    '    dt.Clear()
    '    Dim i As Integer = 0
    '    For Each wbsd As WBSDistribute In Me
    '        i += 1
    '        Dim newRow As TreeRow = dt.Childs.Add()
    '        newRow("Linenumber") = i
    '        newRow("WBS") = wbsd.WBS.Code & ":" & wbsd.WBS.Name
    '        newRow("Percent") = Configuration.FormatToString(wbsd.Percent, 2)
    '        newRow("Amount") = Configuration.FormatToString(wbsd.Percent * amount / 100, DigitConfig.Price)
    '        newRow.Tag = wbsd
    '    Next
    'End Sub
    Public Function GetSumPercent() As Decimal
      Dim ret As Decimal = 0
      For Each wbsd As WBSDistribute In Me
        ret += wbsd.Percent
      Next
      Return ret
    End Function
    Public Function GetSumAmount() As Decimal
      Dim ret As Decimal = 0
      For Each wbsd As WBSDistribute In Me
        ret += wbsd.Amount
      Next
      Return ret
    End Function
    Public Function Clone(ByVal item As PAItem) As WBSDistributeCollection
      Dim newColl As New WBSDistributeCollection
      For Each oldItem As WBSDistribute In Me
        Dim newItem As WBSDistribute = oldItem.Clone
        newItem.BaseCost = item.Amount
        newItem.TransferBaseCost = item.Amount
        newColl.Add(newItem)
      Next
      Return newColl
    End Function
    Public Function Clone(ByVal item As VOItem) As WBSDistributeCollection
      Dim newColl As New WBSDistributeCollection
      For Each oldItem As WBSDistribute In Me
        Dim newItem As WBSDistribute = oldItem.Clone
        newItem.BaseCost = item.Amount
        newItem.TransferBaseCost = item.Amount
        newColl.Add(newItem)
      Next
      Return newColl
    End Function
    Public Function Clone(ByVal item As DRItem) As WBSDistributeCollection
      Dim newColl As New WBSDistributeCollection
      For Each oldItem As WBSDistribute In Me
        Dim newItem As WBSDistribute = oldItem.Clone
        newItem.BaseCost = item.Amount
        newItem.TransferBaseCost = item.Amount
        newColl.Add(newItem)
      Next
      Return newColl
    End Function
    Public Function Clone(ByVal item As POItem) As WBSDistributeCollection
      Dim newColl As New WBSDistributeCollection
      For Each oldItem As WBSDistribute In Me
        Dim newItem As WBSDistribute = oldItem.Clone
        newItem.BaseCost = item.BeforeTax
        newItem.TransferBaseCost = item.BeforeTax
        newColl.Add(newItem)
      Next
      Return newColl
    End Function
    Public Function Clone(ByVal item As MatWithdrawItem) As WBSDistributeCollection
      Dim newColl As New WBSDistributeCollection
      For Each oldItem As WBSDistribute In Me
        Dim newItem As WBSDistribute = oldItem.Clone
        newItem.BaseCost = item.Amount
        newItem.TransferBaseCost = item.Amount
        newColl.Add(newItem)
      Next
      Return newColl
    End Function
    Public Function Clone(ByVal item As GoodsReceiptItem) As WBSDistributeCollection
      Dim newColl As New WBSDistributeCollection
      For Each oldItem As WBSDistribute In Me
        Dim newItem As WBSDistribute = oldItem.Clone
        newItem.BaseCost = item.BeforeTax
        newItem.TransferBaseCost = item.BeforeTax
        newColl.Add(newItem)
      Next
      Return newColl
    End Function
#End Region

#Region "Collection Methods"
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
    Private Sub OnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      'm_htChangedProperties(e.Name) = e.Value
      RaiseEvent PropertyChanged(sender, e)
    End Sub
    Private Sub ItemChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      OnPropertyChanged(sender, e)
    End Sub
    Public Function Add(ByVal value As WBSDistribute) As Integer
      Dim index As Integer = MyBase.List.Add(value)
      AddHandler value.PropertyChanged, AddressOf ItemChangedHandler
      Return index
    End Function
    Public Sub AddRange(ByVal value As WBSDistributeCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As WBSDistribute())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As WBSDistribute) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As WBSDistribute(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As WBSDistributeEnumerator
      Return New WBSDistributeEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As WBSDistribute) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As WBSDistribute)
      MyBase.List.Insert(index, value)
      AddHandler value.PropertyChanged, AddressOf ItemChangedHandler
    End Sub
    Public Sub Remove(ByVal value As WBSDistribute)
      Dim oldVal As WBS = value.WBS      MyBase.List.Remove(value)
      RemoveHandler value.PropertyChanged, AddressOf ItemChangedHandler
      OnPropertyChanged(value, New PropertyChangedEventArgs("WBS", New WBS, oldVal))
    End Sub
    Public Sub Remove(ByVal value As WBSDistributeCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      Dim value As WBSDistribute = Me(index)
      Dim oldVal As WBS = value.WBS      MyBase.List.RemoveAt(index)
      RemoveHandler value.PropertyChanged, AddressOf ItemChangedHandler
      OnPropertyChanged(value, New PropertyChangedEventArgs("WBS", New WBS, oldVal))
    End Sub
#End Region


    Public Class WBSDistributeEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As WBSDistributeCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, WBSDistribute)
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

