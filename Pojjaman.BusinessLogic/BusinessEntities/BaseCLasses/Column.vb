Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Configuration
Imports System.Runtime.InteropServices
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Filter

#Region "Members"
    Private m_name As String
    Private m_value As Object
    Private m_description As String
    Private m_dataType As System.Type
#End Region

#Region "Constructors"
    Public Sub New(ByVal name As String, ByVal value As Object)
      Me.m_name = name
      Me.m_value = value
    End Sub
    Public Sub New(ByVal name As String, ByVal value As Object, ByVal description As String)
      Me.m_name = name
      Me.m_value = value
      Me.m_description = description
    End Sub
    Public Sub New(ByVal name As String, ByVal value As Object, ByVal description As String, dataType As System.Type)
      Me.m_name = name
      Me.m_value = value
      Me.m_description = description
    End Sub
#End Region

#Region "Properties"
    Public Property Name() As String      Get        Return m_name      End Get      Set(ByVal Value As String)        m_name = Value      End Set    End Property    Public Property Value() As Object      Get        Return m_value      End Get      Set(ByVal Value As Object)        m_value = Value      End Set    End Property
    Public Property Description As String
      Get
        Return m_description
      End Get
      Set(value As String)
        m_description = value
      End Set
    End Property
    Public Property DataType As System.Type
      Get
        Return m_dataType
      End Get
      Set(value As System.Type)
        m_value = value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function BlankFilterArray(ByVal filters() As Filter) As Boolean
      For Each myFilter As Filter In filters
        If Not myFilter.Value Is Nothing AndAlso Not IsDBNull(myFilter.Value) AndAlso myFilter.Value.ToString.Length <> 0 Then
          Return False
        End If
      Next
      Return True
    End Function
#End Region

  End Class
  Public Class Column

#Region "Members"
    Private m_name As String
    Private m_alias As String
    Private m_dataType As Type
    Private m_width As Integer
    Private m_alignment As HorizontalAlignment
    Private m_ordinal As Integer
    Private m_format As Integer
    Private m_accessId As Integer
    Private m_issum As Boolean
#End Region

#Region "Constructors"
    Public Sub New(ByVal name As String, ByVal [alias] As String, ByVal width As Integer, ByVal alignment As Integer, ByVal ordinal As Integer)
      Me.New(name, [alias], width, alignment, ordinal, 2, False)
    End Sub
    Public Sub New(ByVal name As String, ByVal [alias] As String, ByVal width As Integer, ByVal alignment As Integer, ByVal ordinal As Integer, ByVal format As Integer, ByVal issum As Boolean)
      With Me
        .m_name = name
        .m_alias = [alias]
        .m_width = width
        .m_alignment = CType(alignment, HorizontalAlignment)
        .m_ordinal = ordinal
        .m_format = format
        .m_issum = issum
      End With
    End Sub
    Public Sub New(ByVal row As DataRow)
      Construct(row)
    End Sub
    Private Sub Construct(ByVal row As DataRow)
      With Me
        .m_name = DBNullToString(row("col_name"))
        .m_alias = DBNullToString(row("col_alias"))
        .m_width = DBNullToInteger(row("col_width"))
        .m_alignment = CType(CStr(row("col_align")), HorizontalAlignment)
        .m_ordinal = DBNullToInteger(row("col_ordinal"))
        .m_format = DBNullToInteger(row("col_format"))
        .m_dataType = Type.GetType(DBNullToString(row("col_dataType")))
        .m_accessId = DBNullToInteger(row("col_access"))
        .m_issum = DBNullToBoolean(row("col_issum"))
      End With
    End Sub
    Private Function DBNullToString(ByVal obj As Object) As String
      If IsDBNull(obj) Then
        Return ""
      End If
      Return obj.ToString
    End Function
    Private Function DBNullToInteger(ByVal obj As Object) As Integer
      If IsDBNull(obj) OrElse Not IsNumeric(obj) Then
        Return 0
      End If
      Return CInt(obj)
    End Function
    Private Function DBNullToBoolean(ByVal obj As Object) As Boolean
      If IsDBNull(obj) Then
        Return False
      End If
      Return CBool(obj)
    End Function
#End Region

#Region "Proprties"
    Public ReadOnly Property Name() As String
      Get
        Return m_name
      End Get
    End Property
    Public Property [Alias]() As String
      Get
        If Not m_alias Is Nothing Then          Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
          Return myStringParserService.Parse(m_alias)
        End If        Return m_alias
      End Get
      Set(ByVal Value As String)
        m_alias = Value
      End Set
    End Property
    Public Property DataType() As Type
      Get
        Return m_dataType
      End Get
      Set(ByVal Value As Type)
        m_dataType = Value
      End Set
    End Property
    Public Property Width() As Integer
      Get
        Return m_width
      End Get
      Set(ByVal Value As Integer)
        m_width = Value
      End Set
    End Property
    Public Property Alignment() As HorizontalAlignment
      Get
        Return m_alignment
      End Get
      Set(ByVal Value As HorizontalAlignment)
        m_alignment = Value
      End Set
    End Property
    Public Property Oridnal() As Integer
      Get
        Return m_ordinal
      End Get
      Set(ByVal Value As Integer)
        m_ordinal = Value
      End Set
    End Property
    Public Property Format() As Integer      Get        Return m_format      End Get      Set(ByVal Value As Integer)        m_format = Value      End Set    End Property
    Public Property AccessId() As Integer
      Get
        Return Me.m_accessId
      End Get
      Set(ByVal Value As Integer)
        Me.m_accessId = Value
      End Set
    End Property
    Public Property IsSum() As Boolean      Get        Return m_issum      End Get      Set(ByVal Value As Boolean)        m_issum = Value      End Set    End Property
#End Region

  End Class
  Public Class ColumnCollection
    Inherits CollectionBase

#Region "Members"
    Private Shared m_columnListDataSet As DataSet
    Private m_className As String
    Private m_userId As Integer
#End Region

#Region "Constructors"
    Public Shared Sub RefreshColumnList()

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetAllColumnList")
      m_columnListDataSet = ds
    End Sub
    Shared Sub New()
      If m_columnListDataSet Is Nothing OrElse m_columnListDataSet.Tables(0).Rows.Count = 0 Then
        RefreshColumnList()
      End If
    End Sub
    'Public Sub New(ByVal className As String, ByVal user As Integer)
    '    
    '    Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
    '    , CommandType.StoredProcedure, "GetColumnList" _
    '    , New SqlClient.SqlParameter("@classname", className) _
    '    , New SqlClient.SqlParameter("@usercol_user", user))
    '    Construct(ds)
    'End Sub
    Public Sub New(ByVal className As String, ByVal user As Integer)
      m_className = className
      m_userId = user
      Construct(m_columnListDataSet)
    End Sub
    'Private Sub Construct(ByVal ds As DataSet)
    '    Dim row As DataRow
    '    If ds.Tables(0).Rows.Count = 0 Then
    '        For Each row In ds.Tables(1).Rows
    '            Me.Add(New Column(row))
    '        Next
    '    Else
    '        For Each row In ds.Tables(0).Rows
    '            Add(New Column(row))
    '        Next
    '    End If
    'End Sub
    Private Sub Construct(ByVal ds As DataSet)
      Dim userFilter As String = "(usercol_user=" & m_userId & ") and (entity_name = '" & m_className & "')"
      Dim rows As DataRow() = ds.Tables(0).Select(userFilter, "[col_ordinal]")
      If rows.Length > 0 Then
        For Each row As DataRow In rows
          Add(New Column(row))
        Next
        Return
      End If

      Dim defaultFilter As String = "(entity_name ='" & m_className & "')"
      Dim defaultRows As DataRow() = ds.Tables(1).Select(defaultFilter, "[col_ordinal]")
      If defaultRows.Length > 0 Then
        For Each row As DataRow In defaultRows
          Add(New Column(row))
        Next
      End If
    End Sub
#End Region


#Region "Properties"
    Public Shared ReadOnly Property CodeDescriptionTable() As DataSet
      Get
        Return m_columnListDataSet
      End Get
    End Property
    Default Public Property Item(ByVal index As Integer) As Column
      Get
        Return CType(MyBase.List.Item(index), Column)
      End Get
      Set(ByVal value As Column)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Function Add(ByVal value As Column) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As ColumnCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As Column())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As Column) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As Column(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ItemEnumerator
      Return New ItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As Column) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As Column)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As Column)
      MyBase.List.Remove(value)
    End Sub
    Public Overridable Function Save() As SaveErrorException
      Debug.WriteLine("Implement Me!!! ColumnCollection.Save")
    End Function
    Public Overridable Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Debug.WriteLine("Implement Me!!! ColumnCollection.Save")
    End Function
#End Region


    Public Class ItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As ColumnCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, Column)
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
