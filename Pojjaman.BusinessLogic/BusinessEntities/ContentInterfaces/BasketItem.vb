Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class StockBasketItem
    Implements IBasketItem

#Region "Members"
    Private m_textInBasket As String
    Private m_id As Integer
    Private m_stockCode As String
    Private m_enityName As String
    Private m_linenumber As Integer
    Private m_fullClassName As String
    Private m_qty As Decimal
    Private m_tag As Object
    Private m_level As Integer
#End Region

#Region "Constructors"
    Public Sub New(ByVal id As Integer, ByVal stockCode As String, ByVal fullClassName As String, ByVal textInBasket As String, ByVal linenumber As Integer, ByVal qty As Decimal, ByVal enityName As String)
      m_id = id
      m_stockCode = stockCode
      m_linenumber = linenumber
      m_fullClassName = fullClassName
      m_textInBasket = textInBasket
      m_qty = qty
      m_enityName = enityName
    End Sub
    Public Sub New(ByVal id As Integer, ByVal stockCode As String, ByVal fullClassName As String, ByVal textInBasket As String, ByVal linenumber As Integer, ByVal qty As Decimal, ByVal enityName As String, ByVal level As Integer)
      m_id = id
      m_stockCode = stockCode
      m_linenumber = linenumber
      m_fullClassName = fullClassName
      m_textInBasket = textInBasket
      m_qty = qty
      m_enityName = enityName
      m_level = level
    End Sub
#End Region

#Region "Methods"
    Public Overrides Function ToString() As String
      Return Me.m_textInBasket
    End Function
#End Region

#Region "Properties"
    Public Property Tag() As Object Implements IHasTag.Tag      Get        Return m_tag      End Get      Set(ByVal Value As Object)        m_tag = Value      End Set    End Property
    Public ReadOnly Property Id() As Integer
      Get
        Return Me.m_id
      End Get
    End Property
    Public ReadOnly Property Linenumber() As Integer
      Get
        Return Me.m_linenumber
      End Get
    End Property
    Public ReadOnly Property StockCode() As String
      Get
        Return Me.m_stockCode
      End Get
    End Property
    Public ReadOnly Property EntityName() As String
      Get
        Return Me.m_enityName
      End Get
    End Property
    Public ReadOnly Property Qty() As Decimal
      Get
        Return m_qty
      End Get
    End Property
    Public ReadOnly Property FullClassName() As String
      Get
        Return m_fullClassName
      End Get
    End Property
    Public ReadOnly Property ParentText() As String Implements IBasketItem.ParentText
      Get
        Return Me.StockCode
      End Get
    End Property
    Public ReadOnly Property Level() As Integer
      Get
        Return m_level
      End Get
    End Property

#End Region

#Region "IBasketItem"
    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean Implements IBasketItem.Equals
      Dim item As StockBasketItem = CType(obj, StockBasketItem)
      Return item.FullClassName = Me.FullClassName And item.Id = Me.Id And item.Linenumber = Me.Linenumber
    End Function
    Public ReadOnly Property TextInBasket() As String Implements IBasketItem.TextInBasket
      Get
        Return m_textInBasket
      End Get
    End Property
#End Region
  End Class
  Public Class BasketItem
    Implements IBasketItem, IIdentifiable, IObjectReflectable

#Region "Members"
    Private m_textInBasket As String
    Private m_id As Integer
    Private m_code As String
    Private m_fullClassName As String
    Private m_tag As Object
#End Region

    Public Sub New(ByVal id As Integer, ByVal code As String, ByVal fullClassName As String, ByVal textInBasket As String)
      m_id = id
      m_code = code
      m_fullClassName = fullClassName
      m_textInBasket = textInBasket
    End Sub

    Public ReadOnly Property TextInBasket() As String Implements IBasketItem.TextInBasket
      Get
        Return m_textInBasket
      End Get
    End Property

    Public Overrides Function ToString() As String
      Return Me.m_textInBasket
    End Function
    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean Implements IBasketItem.Equals
      Dim item As BasketItem = CType(obj, BasketItem)
      Return item.FullClassName = Me.FullClassName And item.Id = Me.Id
    End Function

#Region "Properties"
    Public Property Tag() As Object Implements IHasTag.Tag      Get        Return m_tag      End Get      Set(ByVal Value As Object)        m_tag = Value      End Set    End Property
#End Region

#Region "IObjectReflectable"
    Public ReadOnly Property ClassName() As String Implements IObjectReflectable.ClassName
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property FullClassName() As String Implements IObjectReflectable.FullClassName
      Get
        Return m_fullClassName
      End Get
    End Property
    Public ReadOnly Property [Namespace]() As String Implements IObjectReflectable.Namespace
      Get
        Return ""
      End Get
    End Property
#End Region


#Region "IIdentifiable"
    Public Property Id() As Integer Implements IIdentifiable.Id
      Get
        Return m_id
      End Get
      Set(ByVal Value As Integer)
        m_id = Value
      End Set
    End Property
    Public Property Code() As String Implements IIdentifiable.Code
      Get
        Return m_code
      End Get
      Set(ByVal Value As String)
        m_code = Value
      End Set
    End Property
#End Region

    Public ReadOnly Property EntityId() As Integer Implements IObjectReflectable.EntityId
      Get

      End Get
    End Property

    Public ReadOnly Property ParentText() As String Implements IBasketItem.ParentText
      Get
        Return ""
      End Get
    End Property
  End Class
  Public Interface IHasTag
    Property Tag() As Object
  End Interface
  Public Interface IBasketItem
    Inherits IHasTag
    ReadOnly Property ParentText() As String
    ReadOnly Property TextInBasket() As String
    Function Equals(ByVal obj As Object) As Boolean
  End Interface
  Public Class BasketItemCollection
    Inherits CollectionBase

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As IBasketItem
      Get
        Return CType(MyBase.List.Item(index), IBasketItem)
      End Get
      Set(ByVal value As IBasketItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Function Add(ByVal value As IBasketItem) As Integer
      If Not Contains(value) Then
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As BasketItemCollection)
      For i As Integer = 0 To value.Count - 1
        If Not Contains(value(i)) Then
          Me.Add(value(i))
        End If
      Next
    End Sub
    Public Sub AddRange(ByVal value As IBasketItem())
      For i As Integer = 0 To value.Length - 1
        If Not Contains(value(i)) Then
          Me.Add(value(i))
        End If
      Next
    End Sub
    Public Function Contains(ByVal value As IBasketItem) As Boolean
      For Each item As IBasketItem In Me
        If item.Equals(value) Then
          Return True
        End If
      Next
      If Me.List.Contains(value) Then
        Return True
      End If
      Return False
    End Function
    Public Sub CopyTo(ByVal array As IBasketItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ItemEnumerator
      Return New ItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As IBasketItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As IBasketItem)
      If Not Contains(value) Then
        MyBase.List.Insert(index, value)
      End If
    End Sub
    Public Sub Remove(ByVal value As IBasketItem)
      If Contains(value) Then
        MyBase.List.Remove(value)
      End If
    End Sub
#End Region


    Public Class ItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As BasketItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, IBasketItem)
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
