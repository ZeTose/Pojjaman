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
  Public Class StockCostItem

#Region "Members"
  
#End Region

#Region "Constructors"
   Public Sub New()
      Sequence = 0
      UnitCost = 0
      StockQty = 0
      IsNoCost = False
    End Sub
    Public Sub New(ByVal _sequence As Long, ByVal _unitCost As Decimal, ByVal _stockQty As Decimal)
      Sequence = _sequence
      UnitCost = _unitCost
      StockQty = _stockQty
      IsNoCost = False
    End Sub
    Public Sub New(ByVal row As DataRow, ByVal AliasPrefix As String)
      Dim drh As New DataRowHelper(row)
      With Me
        .StockSequence = drh.GetValue(Of Long)("stockic_stockisequence")
        .Sequence = drh.GetValue(Of Long)("stockic_sequence")
        .UnitCost = drh.GetValue(Of Decimal)("stockic_unitcost")
        .StockQty = drh.GetValue(Of Decimal)("stockic_stockqty")
        .UnitDefaultId = drh.GetValue(Of Integer)("stockic_unitdefault")
        .Conversion = drh.GetValue(Of Decimal)("stockic_conversion")
        .Refsequence = drh.GetValue(Of Long)("stockic_refsequence")
        .Refdoc = drh.GetValue(Of Long)("stockic_refdoc")
        .RefdocType = drh.GetValue(Of Integer)("stockic_refdocType")
        .StockChecked = drh.GetValue(Of Boolean)("stockic_stockchecked")

        If row.IsNull("stockic_unitcost") Then
          .IsNoCost = True
        End If

        .UnitDefault = New Unit(row, "")
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property Sequence As Long
    Public Property UnitCost As Decimal
    Public Property StockQty As Decimal

    Public Property StockSequence As Long
    Public Property UnitDefaultId As Integer
    Public Property Conversion As Decimal
    Public Property Refsequence As Long
    Public Property Refdoc As Long
    Public Property RefdocType As Integer
    Public Property StockChecked As Boolean
    Public Property UnitDefault As Unit
    Public Property IsNoCost As Boolean
#End Region

#Region "Methods"
   
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class StockCostItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_itemEntity As IHasName
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As IHasName, ByVal fromCostCenter As CostCenter, ByVal qty As Decimal, Optional ByVal stock_id As Integer = 0, Optional ByVal isReturn As Boolean = False)
      Me.m_itemEntity = owner
      If Me.m_itemEntity Is Nothing Then
        Return
      End If

      Me.Clear()

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet
      If Not isReturn Then
        If stock_id = 0 Then
          ds = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetStockCostFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty))
        Else
          ds = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetStockCostFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty), _
                                                       New SqlParameter("@stock_id", stock_id))
        End If
      Else
        If stock_id = 0 Then
          ds = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetStockCostReturnFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty))
        Else
          ds = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetStockCostReturnFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty), _
                                                       New SqlParameter("@stock_id", stock_id))
        End If
      End If



      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        Dim itmx As New StockCostItem
        itmx.Sequence = drh.GetValue(Of Long)("stockic_sequence")
        itmx.UnitCost = drh.GetValue(Of Decimal)("stockic_unitcost")
        itmx.StockQty = drh.GetValue(Of Decimal)("stockic_stockqty")
        Me.Add(itmx)
      Next

    End Sub

    Public Sub New(ByVal owner As IHasName, ByVal fromCostCenter As CostCenter, ByVal qty As Decimal, ByVal stock_id As Integer, ByVal isReturn As Boolean, ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      Me.m_itemEntity = owner
      If Me.m_itemEntity Is Nothing Then
        Return
      End If

      Me.Clear()



      Dim ds As DataSet
      If Not isReturn Then
        If stock_id = 0 Then
          ds = SqlHelper.ExecuteDataset(conn, trans, CommandType.StoredProcedure, "GetStockCostFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty))
        Else
          ds = SqlHelper.ExecuteDataset(conn, trans, CommandType.StoredProcedure, "GetStockCostFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty), _
                                                       New SqlParameter("@stock_id", stock_id))
        End If
      Else
        If stock_id = 0 Then
          ds = SqlHelper.ExecuteDataset(conn, trans, CommandType.StoredProcedure, "GetStockCostReturnFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty))
        Else
          ds = SqlHelper.ExecuteDataset(conn, trans, CommandType.StoredProcedure, "GetStockCostReturnFIFO", _
                                                       New SqlParameter("@stock_cc", fromCostCenter.Id), _
                                                       New SqlParameter("@stocki_entity", m_itemEntity.Id), _
                                                       New SqlParameter("@stocki_stockqty", qty), _
                                                       New SqlParameter("@stock_id", stock_id))
        End If
      End If



      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        Dim itmx As New StockCostItem
        itmx.Sequence = drh.GetValue(Of Long)("stockic_sequence")
        itmx.UnitCost = drh.GetValue(Of Decimal)("stockic_unitcost")
        itmx.StockQty = drh.GetValue(Of Decimal)("stockic_stockqty")
        Me.Add(itmx)
      Next

    End Sub

#End Region

#Region "Properties"
    Public Property ItemEntity As IHasName      Get        Return m_itemEntity      End Get      Set(ByVal Value As IHasName)        m_itemEntity = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As StockCostItem
      Get
        Return CType(MyBase.List.Item(index), StockCostItem)
      End Get
      Set(ByVal value As StockCostItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function CostAmount() As Decimal
      Dim amt As Decimal = 0
      For Each itm As StockCostItem In Me
        amt += (itm.UnitCost * itm.StockQty)
      Next
      Return amt
    End Function
    Public Function UnitCostAmount() As Decimal
      Dim amt As Decimal = 0
      Dim stockQty As Decimal = 0
      For Each itm As StockCostItem In Me
        amt += (itm.UnitCost * itm.StockQty)
        stockQty += itm.StockQty
      Next
      If stockQty = 0 Then
        Return 0
      End If
      Return amt / stockQty
    End Function
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As StockCostItem) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As StockCostItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As StockCostItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As StockCostItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As StockCostItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As StockCostItemEnumerator
      Return New StockCostItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As StockCostItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As StockCostItem)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As StockCostItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As StockCostItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class StockCostItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As StockCostItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, StockCostItem)
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

