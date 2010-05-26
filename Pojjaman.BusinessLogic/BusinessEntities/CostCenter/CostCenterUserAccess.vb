Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class CCUserRole
    Public Shared Sub CreateFor(ByVal mycc As CostCenter, ByVal includeHQ As Boolean)
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetUserRolesForCostCenter" _
      , New SqlParameter("@cc_id", mycc.Id) _
      , New SqlParameter("@includeHQ", includeHQ))
      mycc.Roles = New List(Of CCUserRole)
      For Each row As DataRow In ds.Tables(0).Rows
        Dim ur As New CCUserRole
        ur.CostCenter = mycc
        ur.Role = CCRole.GetCCRoleById(CDec(row("Id")))
        ur.User = New User(CInt(row("user_id")))
        ur.Id = CDec(row("Id"))
        If Not row.IsNull("Tier") Then
          ur.Tier = CInt(row("Tier"))
        End If
        ur.StartDate = Now
        mycc.Roles.Add(ur)
      Next
    End Sub
    Public Property Id As Decimal
    Public Property User As User
    Public Property CostCenter As CostCenter
    Public Property Role As CCRole
    Public Property StartDate As Date
    Public Property Tier As Nullable(Of Integer)
  End Class
  Public Class CCRole

#Region "Members"
    Private m_Id As Decimal
    Private m_Code As String
    Private m_Name As String

    Private Shared m_RoleDescHashWithId As Hashtable
    Private Shared m_RoleDescHashWithCode As Hashtable
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshRoleList()
    End Sub
    Private Sub New()
    End Sub
    Private Sub New(ByVal dr As DataRow)
      With Me
        If Not dr.IsNull("Id") Then
          Me.m_Id = CDec(dr("Id"))
        End If
        If Not dr.IsNull("Code") Then
          Me.m_Code = CStr(dr("Code"))
        End If
        If Not dr.IsNull("Name") Then
          Me.m_Name = CStr(dr("Name"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property Id As Decimal
      Get
        Return m_Id
      End Get
    End Property
    Public ReadOnly Property Code As String
      Get
        Return m_Code
      End Get
    End Property
    Public ReadOnly Property Name As String
      Get
        Return m_Name
      End Get
    End Property
#End Region

#Region "Methods"
    Public Shared Sub RefreshRoleList()
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select * from Roles order by Code")
      Dim myTable As DataTable = ds.Tables(0)
      m_RoleDescHashWithId = New Hashtable
      m_RoleDescHashWithCode = New Hashtable
      For Each row As DataRow In myTable.Rows
        m_RoleDescHashWithId(CDec(row("ID"))) = row
        m_RoleDescHashWithCode(row("Code").ToString.ToLower) = row
      Next
    End Sub
    Public Shared Function GetCCRoleByCode(ByVal code As String) As CCRole
      If m_RoleDescHashWithCode.Contains(code.ToLower) Then
        Return New CCRole(CType(m_RoleDescHashWithCode(code.ToLower), DataRow))
      End If
      Return New CCRole
    End Function
    Public Shared Function GetCCRoleById(ByVal id As Decimal) As CCRole
      If m_RoleDescHashWithId.Contains(id) Then
        Return New CCRole(CType(m_RoleDescHashWithId(id), DataRow))
      End If
      Return New CCRole
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function ToString() As String
      Return Me.Code & ":" & Me.Name
    End Function
#End Region

  End Class
  Public Class CostCenterUserAccess

#Region "Members"
    Private m_userId As Integer
    Private m_userCode As String
    Private m_userName As String
    Private m_ccId As Integer
    Private m_ccCode As String
    Private m_ccName As String
    Private m_accessValue As Integer
#End Region

#Region "Constuctors"
    Public Sub New()
      m_accessValue = 0
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow)
      If dr.Table.Columns.Contains("usercc_user") AndAlso Not dr.IsNull("usercc_user") Then
        m_userId = CInt(dr("usercc_user"))
      End If
      If dr.Table.Columns.Contains("user_code") AndAlso Not dr.IsNull("user_code") Then
        m_userCode = CStr(dr("user_code"))
      End If
      If dr.Table.Columns.Contains("user_name") AndAlso Not dr.IsNull("user_name") Then
        m_userName = CStr(dr("user_name"))
      End If
      If dr.Table.Columns.Contains("usercc_cc") AndAlso Not dr.IsNull("usercc_cc") Then
        m_ccId = CInt(dr("usercc_cc"))
      End If
      If dr.Table.Columns.Contains("cc_code") AndAlso Not dr.IsNull("cc_code") Then
        m_ccCode = CStr(dr("cc_code"))
      End If
      If dr.Table.Columns.Contains("cc_name") AndAlso Not dr.IsNull("cc_name") Then
        m_ccName = CStr(dr("cc_name"))
      End If
      If dr.Table.Columns.Contains("usercc_value") AndAlso Not dr.IsNull("usercc_value") Then
        m_accessValue = CInt(dr("usercc_value"))
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property UserId() As Integer
      Get
        Return m_userId
      End Get
      Set(ByVal Value As Integer)
        m_userId = Value
      End Set
    End Property
    Public Property UserCode() As String
      Get
        Return m_userCode
      End Get
      Set(ByVal Value As String)
        m_userCode = Value
      End Set
    End Property
    Public Property UserName() As String
      Get
        Return m_userName
      End Get
      Set(ByVal Value As String)
        m_userName = Value
      End Set
    End Property
    Public Property CostCenterId() As Integer
      Get
        Return m_ccId
      End Get
      Set(ByVal Value As Integer)
        m_ccId = Value
      End Set
    End Property
    Public Property CostCenterCode() As String
      Get
        Return m_ccCode
      End Get
      Set(ByVal Value As String)
        m_ccCode = Value
      End Set
    End Property
    Public Property CostCenterName() As String
      Get
        Return m_ccName
      End Get
      Set(ByVal Value As String)
        m_ccName = Value
      End Set
    End Property
    Public Property AccessValue() As Integer
      Get
        Return m_accessValue
      End Get
      Set(ByVal Value As Integer)
        m_accessValue = Value
      End Set
    End Property
#End Region

#Region "Methods"

#End Region

  End Class


  <Serializable(), DefaultMember("Item")> _
  Public Class CostCenterUserAccessCollection
    Inherits CollectionBase

#Region "Members"
    Private m_cc As Integer
    Private m_user As Integer
    Private m_supermod As Boolean = False
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal mycc As CostCenter)
      m_cc = mycc.Id
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetCostCenterUserAccessList" _
      , New SqlParameter("@cc_id", m_cc))

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New CostCenterUserAccess(row)
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal myuser As User)
      m_user = myuser.Id
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetCostCenterUserAccessList" _
      , New SqlParameter("@user_id", m_user))

      For Each row As DataRow In ds.Tables(0).Rows
        If CInt(row.Item("usercc_cc")) > 0 Then
          Dim item As New CostCenterUserAccess(row)
          Me.Add(item)
        Else
          Me.IsSuperMod = True
        End If
      Next
    End Sub

#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As CostCenterUserAccess
      Get
        Return CType(MyBase.List.Item(index), CostCenterUserAccess)
      End Get
      Set(ByVal value As CostCenterUserAccess)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property IsSuperMod() As Boolean
      Get
        Return m_supermod
      End Get
      Set(ByVal Value As Boolean)
        m_supermod = Value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub PopulateUser4CostCenter(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each myccuseraccess As CostCenterUserAccess In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow.Item("ccua_linenumber") = i.ToString
        newRow.Item("Code") = myccuseraccess.UserCode
        newRow.Item("Name") = myccuseraccess.UserName
      Next
      dt.AcceptChanges()
    End Sub
    Public Sub PopulateCostCenter4User(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each myccuseraccess As CostCenterUserAccess In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow.Item("ccua_linenumber") = i.ToString
        newRow.Item("Code") = myccuseraccess.CostCenterCode
        newRow.Item("Name") = myccuseraccess.CostCenterName
      Next
      dt.AcceptChanges()
    End Sub
    Public Function HaveAccess(ByVal ccid As Integer, ByVal userid As Integer, Optional ByVal parentid As Integer = 0) As Boolean
      Dim haveRight As Boolean = False
      For Each myccuseraccess As CostCenterUserAccess In Me
        If (myccuseraccess.CostCenterId = ccid AndAlso myccuseraccess.UserId = userid) Then
          haveRight = True
        End If
      Next

      If Not haveRight Then
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetCostCenterUserAccessList" _
        , New SqlParameter("@cc_id", -1) _
        , New SqlParameter("@user_id", userid))
        If ds.Tables(0).Rows.Count > 0 Then
          haveRight = True
        End If
      End If
      Return haveRight
    End Function
    Public Function Save(ByVal cc As CostCenter) As SaveErrorException
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "select * from usercostcenter where usercc_cc=" & cc.Id


        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "UserCostCenter")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("UserCostCenter")
        For Each row As DataRow In dt.Rows
          row.Delete()
        Next

        'Dim userList As String
        'Dim hashParentUser As Hashtable = Me.getParrentUserHash

        For Each item As CostCenterUserAccess In Me
          Dim dr As DataRow = dt.NewRow
          dr("usercc_user") = item.UserId
          'userList = userList + "," + item.UserId.ToString
          dr("usercc_cc") = cc.Id
          dr("usercc_value") = item.AccessValue
          dt.Rows.Add(dr)
        Next

        'userList = LTrim(userList)

        'Dim dtParentUser As DataTable = getParrentUser(cc.Parent.Path, userList)

        'For Each drChilds As DataRow In dtParentUser.Rows
        '  Dim dr As DataRow = dt.NewRow
        '  dr("usercc_user") = drChilds("usercc_user")
        '  dr("usercc_cc") = cc.Id
        '  dr("usercc_value") = 1
        '  dt.Rows.Add(dr)
        'Next

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
    Public Function Save(ByVal cc As CostCenter, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Dim hashParentUser As Hashtable = Me.getParrentUserHash(cc)

      'Dim userList As String
      For Each item As CostCenterUserAccess In Me
        If Not hashParentUser.Contains(item.UserId) Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, "INSERT INTO usercostcenter VALUES (" & item.UserId & "," & cc.Id & ",1)")
        End If
      Next

      Return New SaveErrorException("1")

      'Try
      '  Dim cmd As SqlCommand = conn.CreateCommand
      '  cmd.Transaction = trans
      '  cmd.CommandText = "select * from usercostcenter where usercc_cc=" & cc.Id

      '  Dim m_dataset As New DataSet
      '  Dim m_da As New SqlDataAdapter
      '  m_da.SelectCommand = cmd

      '  m_da.Fill(m_dataset, "UserCostCenter")

      '  Dim cmdBuilder As New SqlCommandBuilder(m_da)

      '  Dim dt As DataTable = m_dataset.Tables("UserCostCenter")
      '  For Each row As DataRow In dt.Rows
      '    row.Delete()
      '  Next

      '  'Dim hashParentUser As Hashtable = Me.getParrentUserHash(cc)

      '  'Dim userList As String
      '  For Each item As CostCenterUserAccess In Me
      '    'If Not hashParentUser.Contains(item.UserId) Then
      '    Dim dr As DataRow = dt.NewRow
      '    dr("usercc_user") = item.UserId
      '    'userList = userList + "," + item.UserId.ToString
      '    dr("usercc_cc") = cc.Id
      '    dr("usercc_value") = item.AccessValue
      '    dt.Rows.Add(dr)
      '    'End If
      '  Next

      '  ' First process deletes.
      '  m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      '  ' Next process updates.
      '  m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      '  ' Finally process inserts.
      '  m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
      '  Return New SaveErrorException("1")
      'Catch ex As Exception
      '  Return New SaveErrorException("Error Saving:" & ex.ToString)
      'End Try

    End Function
    Public Function Save(ByVal user As User) As SaveErrorException
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "select * from usercostcenter where usercc_user=" & user.Id


        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "UserCostCenter")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("UserCostCenter")
        Dim dtCCchild As DataTable
        For Each row As DataRow In dt.Rows
          row.Delete()
        Next

        Dim cclist As String = ""

        For Each item As CostCenterUserAccess In Me
          Dim dr As DataRow = dt.NewRow
          dr("usercc_user") = user.Id
          dr("usercc_cc") = item.CostCenterId
          cclist = cclist + "," + item.CostCenterId.ToString
          dr("usercc_value") = item.AccessValue
          dt.Rows.Add(dr)
        Next

        cclist = LTrim(cclist)

        dtCCchild = getChildCC(cclist)

        If Not dtCCchild Is Nothing Then
          For Each drChilds As DataRow In dtCCchild.Rows
            Dim dr As DataRow = dt.NewRow
            dr("usercc_user") = user.Id
            dr("usercc_cc") = drChilds("usercc_cc")
            dr("usercc_value") = 1
            dt.Rows.Add(dr)
          Next
        End If

        If IsSuperMod Then
          Dim dr As DataRow = dt.NewRow
          dr("usercc_user") = user.Id
          dr("usercc_cc") = -1
          dr("usercc_value") = 1
          dt.Rows.Add(dr)
        End If

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
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As CostCenterUserAccess) As Integer
      If Not Me.Contains(value) Then
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As CostCenterUserAccessCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As CostCenterUserAccess())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As CostCenterUserAccess) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As CostCenterUserAccess(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As CostCenterUserAccessEnumerator
      Return New CostCenterUserAccessEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As CostCenterUserAccess) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As CostCenterUserAccess)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As CostCenterUserAccess)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As CostCenterUserAccessCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
    Private Function getChildCC(ByVal cclist As String) As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(RecentCompanies.CurrentCompany.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetCCChildsforCC" _
      , New SqlParameter("@ccList", cclist) _
      )
      If ds.Tables(0).Rows.Count > 0 Then
        Return ds.Tables(0)
      End If
      Return Nothing
    End Function
    Private Function getParrentUserHash(ByVal cc As CostCenter) As Hashtable
      Dim myHashUser As New Hashtable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(RecentCompanies.CurrentCompany.ConnectionString _
      , CommandType.StoredProcedure, "getParrentUserforCC", New SqlParameter("@cc_id", cc.Id))
      For Each row As DataRow In ds.Tables(0).Rows
        If Not row.IsNull("user_id") AndAlso IsNumeric(row("user_Id")) Then
          myHashUser(CInt(row("user_Id"))) = CInt(row("user_id"))
        End If
      Next
      Return myHashUser
    End Function
#End Region


    Public Class CostCenterUserAccessEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As CostCenterUserAccessCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, CostCenterUserAccess)
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
