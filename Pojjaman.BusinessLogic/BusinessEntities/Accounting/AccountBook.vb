Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AccountBook
    Inherits SimpleBusinessEntityBase
    Implements IHasName, IForceListDialog

#Region "Members"
    Private m_name As String
    Private m_titleName As String
    Private m_prefix As String
    Private Shared m_accountBookSet As DataTable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains("accountbook_name") AndAlso Not dr.IsNull(aliasPrefix & "accountbook_name") Then
          .m_name = CStr(dr(aliasPrefix & "accountbook_name"))
        End If
        If dr.Table.Columns.Contains("accountbook_titlename") AndAlso Not dr.IsNull(aliasPrefix & "accountbook_titlename") Then
          .m_titleName = CStr(dr(aliasPrefix & "accountbook_titlename"))
        End If
        If dr.Table.Columns.Contains("accountbook_prefix") AndAlso Not dr.IsNull(aliasPrefix & "accountbook_prefix") Then
          .m_prefix = CStr(dr(aliasPrefix & "accountbook_prefix"))
        End If
      End With
    End Sub
#End Region

#Region "IHasName"
    Public Property Name() As String Implements IHasName.Name
      Get
        Return Me.m_name
      End Get
      Set(ByVal Value As String)
        Me.m_name = Value
      End Set
    End Property
#End Region

#Region "Properties"

    Public Property TitleName() As String
      Get
        Return Me.m_titleName
      End Get
      Set(ByVal Value As String)
        Me.m_titleName = Value
      End Set
    End Property
    Public Property CodePrefix() As String
      Get
        Return Me.m_prefix
      End Get
      Set(ByVal Value As String)
        Me.m_prefix = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "AccountBook"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AccountBook.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AccountBook"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AccountBook"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AccountBook.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "accountbook"
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetAccountBook(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldAcb As AccountBook) As Boolean
      Dim acb As New AccountBook(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not acb.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        acb = oldAcb
      End If
      txtCode.Text = acb.Code
      txtName.Text = acb.Name
      If oldAcb.Id <> acb.Id Then
        oldAcb = acb
        Return True
      End If
      Return False
    End Function
    Public Shared Sub RefreshEntityTable()
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetAccountBookList" _
      )
      m_accountBookSet = New DataTable
      m_accountBookSet = ds.Tables(0)
    End Sub
    Public Shared Function GetAccountSet() As DataTable
      If m_accountBookSet Is Nothing Then
        AccountBook.RefreshEntityTable()
      End If
      Return m_accountBookSet
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class AccountBookCollection
    Inherits CollectionBase

#Region "Members"
    Private m_filters As Filter()
#End Region

#Region "Constructors"
    Public Sub New(ByVal filters As Filter())

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      m_filters = filters
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAccountBookList" _
      , params _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New AccountBook(row, "")
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As AccountBook
      Get
        Return CType(MyBase.List.Item(index), AccountBook)
      End Get
      Set(ByVal value As AccountBook)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetItemWithId(ByVal id As Integer) As AccountBook
      For Each item As AccountBook In Me
        If item.Id = id Then
          Return item
        End If
      Next
    End Function
    Protected Function GetParamsString(ByVal filters() As Filter) As String
      Dim ret As String = ""
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        For i As Integer = 0 To filters.Length - 1
          ret &= "@" & filters(i).Name & ","
        Next
      End If
      ret = ret.TrimEnd(","c)
      Return ret
    End Function
    Public Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Try

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Execute GetAccountBookList " & GetParamsString(m_filters)
        If Not m_filters Is Nothing AndAlso m_filters.Length > 0 Then
          For i As Integer = 0 To m_filters.Length - 1
            cmd.Parameters.Add(New SqlParameter("@" & m_filters(i).Name, m_filters(i).Value))
          Next
        End If

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "AccountBook")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("AccountBook")
        For Each row As DataRow In dt.Rows
          If GetItemWithId(CInt(row("accountbook_id"))) Is Nothing Then
            'หาไม่เจอ
            row.Delete()
          End If
        Next
        For Each item As AccountBook In Me
          If Not item.Originated Then
            Dim dr As DataRow = dt.NewRow
            dr("accountbook_code") = item.Code
            dr("accountbook_name") = item.Name
            dr("accountbook_titlename") = item.TitleName
            dr("accountbook_prefix") = item.CodePrefix
            dt.Rows.Add(dr)
          Else
            Dim theRows As DataRow() = dt.Select("accountbook_id=" & item.Id)
            If theRows.Length = 1 Then
              Dim dr As DataRow = theRows(0)
              dr("accountbook_code") = item.Code
              dr("accountbook_name") = item.Name
              dr("accountbook_titlename") = item.TitleName
              dr("accountbook_prefix") = item.CodePrefix
            End If
          End If
        Next
        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException("Error Saving:" & ex.ToString)
      End Try
    End Function
    Public Sub PopulateTable(ByVal dt As TreeTable)
      Dim i As Integer = 0
      dt.Clear()
      Dim stServ As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      For Each item As AccountBook In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add
        newRow("Linenumber") = i
        newRow("code") = item.Code
        newRow("Name") = item.Name
        newRow("TitleName") = item.TitleName
        newRow("Prefix") = item.CodePrefix
        newRow.Tag = item
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As AccountBook) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As AccountBookCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As AccountBook())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As AccountBook) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As AccountBook(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As AccountBookEnumerator
      Return New AccountBookEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As AccountBook) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As AccountBook)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As AccountBook)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As AccountBookCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class AccountBookEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As AccountBookCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, AccountBook)
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
