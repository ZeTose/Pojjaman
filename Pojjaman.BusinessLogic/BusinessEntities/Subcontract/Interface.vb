Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Interface IAbleConvertibleUnit
    Property Qty As Decimal
    Property Entity As IHasName
    Property Unit As Unit
    ReadOnly Property ItemType As Integer
  End Interface
  Public Interface IShowStatusColorAble

  End Interface
  Public Interface IVisibleButtonShowColorListAble

  End Interface
  Public Interface IDocumentPersonAble
    ReadOnly Property Employee As Employee
    ReadOnly Property User As User
    ReadOnly Property CanceledUser As User
    ReadOnly Property CreatedUser As User
    ReadOnly Property EditedUser As User
    ReadOnly Property ApprovedUser As User
    ReadOnly Property AutherizedUser As User
    ReadOnly Property RejectUser As User
  End Interface
  Public Interface IApproveStatusAble
    ReadOnly Property IsAuthorized As Boolean
    ReadOnly Property IsLevelApproved As Boolean
    ReadOnly Property IsReject As Boolean
    Sub RefreshApproveDocCollection()
  End Interface
  Public Interface ICloseStatusAble
    Property Closed As Boolean
  End Interface
  Public Interface IDocStatusAble
    Function IsReferenced() As Boolean
    Function IsReferedFrom() As Boolean
    Function IsCancelable() As Boolean
  End Interface
  Public Interface IControlItem
    ReadOnly Property ControlMessage As String
  End Interface
  'Public Interface IWBSRefDocAble
  '    Property DocDate() As DateTime
  '    Property Suplier() As Supplier
  '    Property ToCostCenter() As CostCenter
  '    Property FromCostCenter() As CostCenter
  'End Interface
  Public Interface IWithdrawAble

  End Interface
  Public Interface IWBSAllocatable
    Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection
    Property DocDate() As DateTime
    Property Supplier() As Supplier
    Property ToCostCenter() As CostCenter
    Property FromCostCenter() As CostCenter
    ReadOnly Property AllowWBSAllocateFrom() As Boolean
    ReadOnly Property AllowWBSAllocateTo() As Boolean
  End Interface
  Public Interface IAllowWBSAllocatableItem
    ReadOnly Property AllowWBSAllocateFrom() As Boolean
    ReadOnly Property AllowWBSAllocateTo() As Boolean
  End Interface
  Public Interface IWBSAllocatableItem
    ReadOnly Property Type() As String
    ReadOnly Property Description() As String
    ReadOnly Property ItemAmount() As Decimal
    ReadOnly Property AllocationErrorMessage() As String
    Property WBSDistributeCollection() As WBSDistributeCollection
    Property WBSDistributeCollection2() As WBSDistributeCollection
    ReadOnly Property AllocationType As String
    Sub WBSChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
  End Interface
  Public Enum AllocationType
    Non
    AllocationFromOnly
    AllocationToOnly
    AllocationFromAndTo
  End Enum

  <Serializable(), DefaultMember("Item")> _
  Public Class WBSAllocatableItemCollection
    Inherits CollectionBase

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As IWBSAllocatableItem
      Get
        Return CType(MyBase.List.Item(index), IWBSAllocatableItem)
      End Get
      Set(ByVal value As IWBSAllocatableItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    'Public Sub Populate(ByVal dt As TreeTable)
    '  dt.Clear()
    '  dt.AcceptChanges()
    'End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As IWBSAllocatableItem) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As WBSAllocatableItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As IWBSAllocatableItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As IWBSAllocatableItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As IWBSAllocatableItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As IWBSAllocatableItemEnumerator
      Return New IWBSAllocatableItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As IWBSAllocatableItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As IWBSAllocatableItem)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As IWBSAllocatableItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class IWBSAllocatableItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As WBSAllocatableItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, IWBSAllocatableItem)
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
