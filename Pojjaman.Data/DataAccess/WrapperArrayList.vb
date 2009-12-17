Imports System.Reflection
Namespace Longkong.Pojjaman.DataAccessLayer
    Public Delegate Sub ItemAddedHandler(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
  Public Class WrapperArrayListx
    Inherits ArrayList

    Public Sub New(ByVal list As ArrayList)
      Me.AddRange(list)
    End Sub

    Public Shared Sub AddItemAddedHandler(ByVal dt As DataTable, ByVal handler As ItemAddedHandler)
      Dim collection As DataRowCollection = dt.Rows
      Dim collectionType As Type = collection.GetType
      Dim fi As FieldInfo = collectionType.GetField( _
      "list", _
      BindingFlags.Instance Or BindingFlags.NonPublic)
      Dim list As ArrayList = CType(fi.GetValue(collection), ArrayList)
      Dim wrapperList As New WrapperArrayListx(list)
      AddHandler wrapperList.ItemAdded, handler
      fi.SetValue(collection, wrapperList)
    End Sub

    Public Overrides Function Add(ByVal value As Object) As Integer
      Dim index As Integer = MyBase.Add(value)
      Me.OnItemAdded(New ITemAddedEventArgs(CType(value, DataRow)))
      Return index
    End Function
    Public Event ItemAdded As ItemAddedHandler
    Protected Sub OnItemAdded(ByVal e As ITemAddedEventArgs)
      RaiseEvent ItemAdded(Me, e)
    End Sub
  End Class
    Public Class ITemAddedEventArgs
        Inherits EventArgs

#Region "Members"
        Private m_row As DataRow
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal row As DataRow)
            MyBase.New()
            m_row = row
        End Sub
#End Region

#Region "Properties"
        Public Property Row() As DataRow            Get                Return m_row            End Get            Set(ByVal Value As DataRow)                m_row = Value            End Set        End Property
#End Region

    End Class
End Namespace

