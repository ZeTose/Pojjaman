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
  Public Class Access
    Inherits TreeBaseEntity

#Region "Member"
    Private m_codename As String
    Private m_type As Integer
    Private m_note As String
    Private m_defaultValue As Decimal
    Private m_default As Integer

    Private m_defaultApplied As Boolean = True

    Private m_current As Integer
    Private m_currentValue As Decimal
    Private m_valueOrder As Integer '0=Asc,1=Desc

    Private Shared m_formAccessTable As DataTable
    Private m_entityItemCollecion As List(Of EntityItem)
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshFormAccessTable()
    End Sub
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As Access)
      MyBase.New(myParent)
      Me.Level = myParent.Level + 1
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me

      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
        Me.m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_type") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_type") Then
        Me.m_type = CInt(dr(aliasPrefix & Me.Prefix & "_type"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_codename") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_codename") Then
        Me.m_codename = CStr(dr(aliasPrefix & Me.Prefix & "_codename"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_defaultvalue") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_defaultvalue") Then
        Me.m_defaultValue = CDec(dr(aliasPrefix & Me.Prefix & "_defaultvalue"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_default") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_default") Then
        Me.m_default = CInt(dr(aliasPrefix & Me.Prefix & "_default"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_valueOrder") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_valueOrder") Then
        Me.m_valueOrder = CInt(dr(aliasPrefix & Me.Prefix & "_valueOrder"))
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property EntityItemCollecion As List(Of EntityItem)
    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Type() As Integer      Get
        Return m_type
      End Get
      Set(ByVal Value As Integer)
        m_type = Value
      End Set
    End Property    Public Property CodeName() As String
      Get
        Return m_codename
      End Get
      Set(ByVal Value As String)
        m_codename = Value
      End Set
    End Property    Public Property DefaultValue() As Decimal      Get        Return m_defaultValue      End Get      Set(ByVal Value As Decimal)        m_defaultValue = Value      End Set    End Property    Public Property [Default]() As Integer      Get        Return m_default      End Get      Set(ByVal Value As Integer)        m_default = Value      End Set    End Property    Public Property DefaultApplied() As Boolean      Get        Return m_defaultApplied      End Get      Set(ByVal Value As Boolean)        m_defaultApplied = Value      End Set    End Property    Public Property Current() As Integer      Get        Return m_current      End Get      Set(ByVal Value As Integer)        m_current = Value      End Set    End Property    Public Property CurrentValue() As Decimal      Get        Return m_currentValue      End Get      Set(ByVal Value As Decimal)        m_currentValue = Value      End Set    End Property    Public Property ValueOrder() As Integer      Get        Return m_valueOrder      End Get      Set(ByVal Value As Integer)        m_valueOrder = Value      End Set    End Property    Public Function GetEffectiveAccess(ByVal hasAccess As IHasAccess) As Integer
      Dim myUser As User
      Dim myRole As Role
      If TypeOf hasAccess Is User Then
        myUser = CType(hasAccess, User)
        myRole = myUser.Role
      Else
        myRole = CType(hasAccess, Role)
      End If
      Dim acc As Integer = Nothing
      Dim roleAcc As Integer = Nothing
      If Not myUser Is Nothing AndAlso myUser.Originated Then
        acc = myUser.GetAccess(Me)
      End If
      If Not myRole Is Nothing AndAlso myRole.Originated Then
        roleAcc = myRole.GetAccess(Me)
      End If
      If acc <> Nothing And roleAcc = Nothing Then
        Return acc
      ElseIf acc = Nothing And roleAcc <> Nothing Then
        Return roleAcc
      ElseIf acc <> Nothing And roleAcc <> Nothing Then
        Return acc And roleAcc
      Else
        Return Me.Default
      End If
    End Function
    Public Function GetEffectiveValue(ByVal hasAccess As IHasAccess) As Decimal
      Dim myUser As User
      Dim myRole As Role
      If TypeOf hasAccess Is User Then
        myUser = CType(hasAccess, User)
        myRole = myUser.Role
      Else
        myRole = CType(hasAccess, Role)
      End If
      Dim userVal As Decimal = Nothing
      Dim roleVal As Decimal = Nothing
      If Not myUser Is Nothing AndAlso myUser.Originated Then
        userVal = myUser.GetAccessValue(Me)
      End If
      If Not myRole Is Nothing AndAlso myRole.Originated Then
        roleVal = myRole.GetAccessValue(Me)
      End If
      If userVal <> Nothing And roleVal = Nothing Then
        Return userVal
      ElseIf userVal = Nothing And roleVal <> Nothing Then
        Return roleVal
      ElseIf userVal <> Nothing And roleVal <> Nothing Then
        If Me.ValueOrder = 0 Then
          Return Math.Min(userVal, roleVal)
        End If
        Return Math.Max(userVal, roleVal)
      Else
        Return Me.DefaultValue
      End If
    End Function
    Public ReadOnly Property Description() As String      Get
        Return Me.Name
      End Get
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Access"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Access.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Access"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Access"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Access.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "access"
      End Get
    End Property
#End Region

#Region "Methods"
    Public Function GetFormEntityCollection() As FormEntityCollection
      Return New FormEntityCollection(Me.Id)
    End Function
    Public Shared Sub RefreshFormAccessTable()
      Try
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
        , CommandType.StoredProcedure _
        , "GetFormAccessTable" _
        )
        m_formAccessTable = ds.Tables(0)
      Catch ex As Exception
        Return
      End Try
    End Sub
    Public Shared Function GetFormAccessTable(ByVal formName As String) As DataTable
      Try
        'Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        'Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
        ', CommandType.StoredProcedure _
        ', "GetFormAccessTable" _
        ', New SqlParameter("@form_name", formName) _
        ')
        'Return ds.Tables(0)
        Dim dt As DataTable = m_formAccessTable.Clone
        Dim rows As DataRow() = m_formAccessTable.Select("form_name=" & formName)
        For Each row As DataRow In rows
          dt.ImportRow(row)
        Next
        Return dt
      Catch ex As Exception
        Return Nothing
      End Try
    End Function
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New Access(parId)
      Else
        Me.Parent = Nothing
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New Access
      par.Id = id
      par.Code = code
      par.Name = name
      Me.Parent = par
    End Sub
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("0")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim cmd As New SqlCommand("delete access where access_id=" & Me.Id)
        cmd.Connection = conn
        cmd.Transaction = trans
        cmd.ExecuteNonQuery()
        trans.Commit()
        Return New SaveErrorException("1")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
        End If

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_parid", parID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_path", Me.Path))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

        ' ตรวจจับ Error ของการ Save ...

        Return New SaveErrorException(returnVal.Value.ToString)

      End With
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function ChangeParent(ByVal groupId As Integer, ByVal parentId As Integer) As Integer
      If IsParentChild(parentId, groupId) Then
        Return -1
      End If
      Dim sql As String
      sql = "update [" & Me.TableName & "] set " & Me.Prefix & "_parid= " & parentId & _
      "," & Me.Prefix & "_level =(select " & Me.Prefix & "_level+1 from [" & Me.TableName & "] where " & Me.Prefix & "_id=" & _
      parentId & ")," & Me.Prefix & "_path =(select " & Me.Prefix & "_path+'|" & groupId & _
      "|' from [" & Me.TableName & "] where " & Me.Prefix & "_id=" & parentId & ")," & Me.Prefix & "_order=(select isnull(max(" & Me.Prefix & "_order),1)+1 from [" & Me.TableName & "] where " & Me.Prefix & "_parid=" & parentId & ")" & " where " & Me.Prefix & "_id =" & groupId
      Dim cn As New SqlConnection(Me.ConnectionString)
      Dim cmd As New SqlCommand(sql, cn)
      cn.Open()
      Return cmd.ExecuteNonQuery()
      cn = Nothing
      cmd = Nothing
    End Function
    Public Overrides Sub PopulateTree(ByVal tvGroup As TreeView, ByVal ParamArray filters() As Filter)
      Dim ds As DataSet = Me.GetListDataSet("", filters)
      Dim dt As DataTable = ds.Tables(0)
      tvGroup.BeginUpdate()
      tvGroup.Nodes.Clear()
      'tvGroup.ForeColor = Color.Gray
      For Each row As DataRow In dt.Rows
        Dim NodeTag As Access = New Access(row, "")
        Dim nodeNote As String = ""
        If Not row.IsNull(Prefix & "_note") AndAlso row(Prefix & "_note").ToString.Length > 0 Then
          nodeNote = " (" & CStr(row(Prefix & "_note")) & ")"
        End If
        Dim NodeNme As String = CStr(row(Prefix & "_code")) & " - " & CStr(row(Prefix & "_name")) & nodeNote
        Dim parentNodes As TreeNodeCollection
        If IsDBNull(row(Prefix & "_parid")) OrElse CInt(row(Prefix & "_parid")) = CInt(row(Prefix & "_id")) Then
          parentNodes = tvGroup.Nodes
        Else
          Dim parnode As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_parid")))
          If parnode Is Nothing Then
            parentNodes = tvGroup.Nodes
          Else
            parentNodes = parnode.Nodes
          End If
        End If
        Dim theNode As TreeNode = parentNodes.Add(NodeNme)
        theNode.Tag = NodeTag
      Next
      If ds.Tables.Count = 2 Then
        Dim dt2 As DataTable = ds.Tables(1)
        For Each row As DataRow In dt2.Rows
          Dim node As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_id")))
          TreeViewHelper.HilightNode(node, Color.Blue)
        Next
      End If
      tvGroup.EndUpdate()
    End Sub
    Public Overrides Function ToString() As String
      Return Me.Code
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class AccessCollection
    Inherits CollectionBase

#Region "Members"
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal load As Boolean)
      If Not load Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAccesss" _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New Access(row, "")
        Me.Add(item)

        Dim iList As New List(Of EntityItem)
        For Each erow As DataRow In ds.Tables(3).Rows
          Dim eitem As New EntityItem(erow, item)
          iList.Add(eitem)
        Next
        item.EntityItemCollecion = iList
      Next

    End Sub
    Public Sub New(ByVal hasAccess As IHasAccess)
      If hasAccess Is Nothing Then
        Return
      End If
      Dim params(0) As SqlParameter
      If TypeOf hasAccess Is User Then
        params(0) = New SqlParameter("@user_id", CType(hasAccess, User).Id)
      ElseIf TypeOf hasAccess Is Role Then
        params(0) = New SqlParameter("@role_id", CType(hasAccess, Role).Id)
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAccesss" _
      , params _
      )

      'Tables(0) : Access
      'Tables(1) : User
      'Tables(2) : Role
      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New Access(row, "")
        Dim dt As DataTable
        Dim tablePrefix As String = ""
        If TypeOf hasAccess Is User Then
          dt = ds.Tables(1)
          tablePrefix = "useraccess"
        ElseIf TypeOf hasAccess Is Role Then
          dt = ds.Tables(2)
          tablePrefix = "roleaccess"
        End If
        If Not dt Is Nothing Then
          Dim currRows As DataRow() = dt.Select(tablePrefix & "_access=" & item.Id)
          If currRows.Length = 1 Then
            Dim myRow As DataRow = currRows(0)
            If Not myRow.IsNull(tablePrefix & "_accessvalue") Then
              item.Current = CInt(myRow(tablePrefix & "_accessvalue"))
            End If
            If Not myRow.IsNull(tablePrefix & "_value") Then
              item.CurrentValue = CDec(myRow(tablePrefix & "_value"))
            End If
          End If
        End If
        Me.Add(item)

        Dim iList As New List(Of EntityItem)
        Dim accessid As Integer = item.Id
        Dim dr() As DataRow = ds.Tables(3).Select("entity_access=" & accessid)
        For i As Integer = 0 To dr.Length - 1
          Dim eitem As New EntityItem(dr(i), item)
          iList.Add(eitem)
        Next
        item.EntityItemCollecion = iList

      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As Access
      Get
        Return CType(MyBase.List.Item(index), Access)
      End Get
      Set(ByVal value As Access)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub SetChildValue(ByVal parent As Access)
      For Each child As Access In Me.GetChildsOf(parent)
        child.CurrentValue = parent.CurrentValue
        SetChildValue(child)
      Next
    End Sub
    Public Sub SetChildAccess(ByVal parent As Access)
      For Each child As Access In Me.GetChildsOf(parent)
        child.Current = parent.Current
        SetChildAccess(child)
      Next
    End Sub
    Public Function GetChildsOf(ByVal parent As Access) As AccessCollection
      Dim newColl As New AccessCollection
      For Each myAccess As Access In Me
        If Not myAccess Is myAccess.Parent AndAlso myAccess.Parent Is parent Then
          newColl.Add(myAccess)
        ElseIf myAccess.Id <> 0 AndAlso myAccess.Id <> parent.Id AndAlso myAccess.Parent.Id = parent.Id Then
          'MessageBox.Show("added:" & myWbs.Id.ToString & ":" & parent.Id.ToString)
          newColl.Add(myAccess)
        Else
          'MessageBox.Show("Not added:" & myWbs.Id.ToString & ":" & parent.Id.ToString)
        End If
      Next
      Return newColl
    End Function
    Public Function GetSubOrdinatesOf(ByVal parent As Access) As AccessCollection
      Dim newAccessColl As New AccessCollection
      For Each collAccess As Access In Me
        Dim tmpAccess As Access = collAccess
        Dim tmpColl As New AccessCollection
        tmpColl.Add(tmpAccess)
        While Not tmpAccess Is Nothing
          '>>>> สุดทางเจอแม่แล้ว
          If tmpAccess.Id <> 0 And tmpAccess.Id = parent.Id Then
            newAccessColl.AddRange(tmpColl)
            Exit While
          ElseIf tmpAccess Is parent Then
            newAccessColl.AddRange(tmpColl)
            Exit While
          End If
          tmpAccess = CType(tmpAccess.Parent, Access)
          If Not tmpAccess Is Nothing Then
            tmpColl.Add(tmpAccess)
          End If
        End While
        tmpColl.Clear()
      Next
      Return newAccessColl
    End Function
    Public Sub Populate(ByVal tvAccess As TreeView)
      tvAccess.Nodes.Clear()


      For Each myAccess As Access In Me
        Dim parentNodes As TreeNodeCollection = Nothing
        If myAccess.Parent Is myAccess Then
          parentNodes = tvAccess.Nodes
        ElseIf myAccess.Parent.Id <> 0 And myAccess.Parent.Id = myAccess.Id Then
          parentNodes = tvAccess.Nodes
        Else
          Dim parentNode As TreeNode = FindNode(tvAccess, CType(myAccess.Parent, Access))
          If Not parentNode Is Nothing Then
            parentNodes = parentNode.Nodes
          End If
        End If
        'theNode.ImageIndex = 4
        'theNode.SelectedImageIndex = 4
        Dim theNode As TreeNode
        If Not parentNodes Is Nothing Then
          If myAccess.EntityItemCollecion Is Nothing OrElse myAccess.EntityItemCollecion.Count = 0 Then
            theNode = parentNodes.Add(myAccess.ToString)
            theNode.Tag = myAccess
            theNode.ImageIndex = 0
            theNode.SelectedImageIndex = 0
            'parentNodes.Add(myAccess.ToString).Tag = myAccess
          ElseIf myAccess.EntityItemCollecion.Count = 1 Then

            Dim myAccessString As String = myAccess.EntityItemCollecion(0).Description
            If myAccess.EntityItemCollecion(0).IsReport Then
              myAccessString &= " [" & myAccess.EntityItemCollecion(0).Id & "]"
            End If

            theNode = parentNodes.Add(myAccessString)
            theNode.Tag = myAccess
            theNode.ImageIndex = 0
            theNode.SelectedImageIndex = 0
            'parentNodes.Add(myAccess.EntityItemCollecion(0).Description).Tag = myAccess
          Else
            theNode = parentNodes.Add(myAccess.ToString)
            theNode.Tag = myAccess
            theNode.ImageIndex = 0
            theNode.SelectedImageIndex = 0

            Dim LeafNode As TreeNode = FindNode(tvAccess, myAccess)
            Dim r As Integer = 0
            For Each eitm As EntityItem In myAccess.EntityItemCollecion
              parentNodes = LeafNode.Nodes
              theNode = parentNodes.Add(myAccess.EntityItemCollecion(r).Description)
              theNode.Tag = eitm
              theNode.ImageIndex = 1
              theNode.SelectedImageIndex = 1
              r += 1
            Next
          End If
        End If
      Next
    End Sub
    Public Function FindNode(ByVal tv As TreeView, ByVal myAccess As Access) As TreeNode
      Dim n As TreeNode
      For Each n In tv.Nodes
        Dim tn As TreeNode = FindNode(n, myAccess)
        If Not tn Is Nothing Then
          Return tn
        End If
      Next
    End Function
    Private Function FindNode(ByVal n As TreeNode, ByVal myAccess As Access) As TreeNode
      If TypeOf n.Tag Is Access Then
        Dim nodeAccess As Access = CType(n.Tag, Access)
        If nodeAccess Is myAccess Then
          Return n
        End If
        If nodeAccess.Id <> 0 And nodeAccess.Id = myAccess.Id Then
          Return n
        End If
      End If
      Dim aNode As TreeNode
      For Each aNode In n.Nodes
        Dim tn As TreeNode = FindNode(aNode, myAccess)
        If Not tn Is Nothing Then
          Return tn
        End If
      Next
    End Function
    Public Function GetItemWithId(ByVal id As Integer) As Access
      For Each item As Access In Me
        If item.Id = id Then
          Return item
        End If
      Next
    End Function
    Public Function Save(ByVal user As User) As SaveErrorException
      Try

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "select * from useraccess where useraccess_user=" & user.Id


        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "UserAccess")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("UserAccess")
        For Each row As DataRow In dt.Rows
          If GetItemWithId(CInt(row("useraccess_access"))) Is Nothing Then
            row.Delete()
          End If
        Next
        For Each item As Access In Me
          Dim theRows As DataRow() = dt.Select("useraccess_access=" & item.Id)
          If theRows.Length = 1 Then
            Dim dr As DataRow = theRows(0)
            dr("useraccess_user") = user.Id
            dr("useraccess_value") = item.CurrentValue
            dr("useraccess_accessvalue") = item.Current
          ElseIf theRows.Length = 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("useraccess_access") = item.Id
            dr("useraccess_user") = user.Id
            dr("useraccess_value") = item.CurrentValue
            dr("useraccess_accessvalue") = item.Current
            dt.Rows.Add(dr)
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
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As Access) As Integer
      If Not Me.Contains(value) Then
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As AccessCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As Access())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As Access) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As Access(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As AccessEnumerator
      Return New AccessEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As Access) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As Access)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As Access)
      For Each toDelete As Access In GetSubOrdinatesOf(value)
        MyBase.List.Remove(value)
      Next
    End Sub
    Public Sub Remove(ByVal value As AccessCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class AccessEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As AccessCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, Access)
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

  Public Class EntityItem

#Region "Member"

#End Region

#Region "Constructor"
    Public Sub New(ByVal row As DataRow, ByVal myAccess As Access)
      Me.Construct(row)
      Access = myAccess
    End Sub
    Private Sub Construct(ByVal row As DataRow)
      Dim drh As New DataRowHelper(row)
      Id = drh.GetValue(Of Integer)("entity_id")
      Name = drh.GetValue(Of String)("entity_name")
      Description = drh.GetValue(Of String)("entity_description")
    End Sub
#End Region

#Region "Properties"
    Public Property Id As Integer
    Public Property Name As String
    Public Property Description As String
    Public ReadOnly Property IsReport As Boolean
      Get
        If Me.Name.ToLower.StartsWith("rpt") Then
          Return True
        End If
        Return False
      End Get
    End Property
    Public Property Access As Access
#End Region
  End Class

End Namespace