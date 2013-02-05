Imports System.Data.SqlClient
Imports System.Configuration
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class TreeBaseEntity
    Inherits SimpleBusinessEntityBase
    Implements IMultiName

#Region "Members"
    Private m_name As String
    Private m_alternateName As String
    Private m_level As Integer
    Private m_path As String
    Private m_control As Boolean
    Private m_parent As TreeBaseEntity
    Private m_acct As Account
#End Region

#Region "Contructors"
    Public Sub New()
      Construct()
    End Sub
    Public Sub New(ByVal parent As TreeBaseEntity)
      Construct()
      Me.Parent = parent
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        .m_acct = New Account()

        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_altName") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_altName") Then
          .m_alternateName = CStr(dr(aliasPrefix & Prefix & "_altName"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_level") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_level") Then
          .m_level = CInt(dr(aliasPrefix & Prefix & "_level"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Prefix & "_name"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_path") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_path") Then
          .m_path = CStr(dr(aliasPrefix & Prefix & "_path"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_control") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_control") Then
          .m_control = CBool(dr(aliasPrefix & Prefix & "_control"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Prefix & "_acct") AndAlso Not dr.IsNull(aliasPrefix & Prefix & "_acct") Then
          .m_acct = New Account(CInt(dr(aliasPrefix & Prefix & "_acct")))
        End If

        Dim parid As Integer
        Dim parCode As String
        Dim parName As String
        If dr.Table.Columns.Contains(aliasPrefix & "parent." & Prefix & "_id") Then
          If Not dr.IsNull(aliasPrefix & "parent." & Prefix & "_id") Then
            parid = CInt(dr(aliasPrefix & "parent." & Prefix & "_id"))
          End If
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "parent_id") Then
          If Not dr.IsNull(aliasPrefix & "parent_id") Then
            parid = CInt(dr(aliasPrefix & "parent_id"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "parent." & Prefix & "_code") Then
          If Not dr.IsNull(aliasPrefix & "parent." & Prefix & "_code") Then
            parCode = CStr(dr(aliasPrefix & "parent." & Prefix & "_code"))
          End If
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "parent_code") Then
          If Not dr.IsNull(aliasPrefix & "parent_code") Then
            parCode = CStr(dr(aliasPrefix & "parent_code"))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "parent." & Prefix & "_name") Then
          If Not dr.IsNull(aliasPrefix & "parent." & Prefix & "_name") Then
            parName = CStr(dr(aliasPrefix & "parent." & Prefix & "_name"))
          End If
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "parent_name") Then
          If Not dr.IsNull(aliasPrefix & "parent_name") Then
            parName = CStr(dr(aliasPrefix & "parent_name"))
          End If
        End If
        SetParent(parid, parCode, parName)


      End With
    End Sub
    Public Overridable Sub SetParent(ByVal parId As Integer)
      Debug.WriteLine("Implement Me!!! TreeBaseEntity.SetParent")
    End Sub
    Public Overridable Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New TreeBaseEntity
      par.Id = id
      par.Code = code
      par.Name = name
      Me.Parent = par
    End Sub
#End Region

#Region "IMultiName"
    Public Property Name() As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
        Me.OnTabPageTextChanged(Me, New EventArgs)
      End Set
    End Property
    Public Property AlternateName() As String Implements IMultiName.AlternateName
      Get
        Return m_alternateName
      End Get
      Set(ByVal Value As String)
        m_alternateName = Value
      End Set
    End Property
#End Region

#Region "ITreeEntity"
    Public Property IsControlGroup() As Boolean
      Get
        Return m_control
      End Get
      Set(ByVal Value As Boolean)
        m_control = Value
      End Set
    End Property
    Public Property Level() As Integer
      Get
        Return m_level
      End Get
      Set(ByVal Value As Integer)
        m_level = Value
      End Set
    End Property
    Public Overridable Property Parent() As TreeBaseEntity
      Get
        Return m_parent
      End Get
      Set(ByVal Value As TreeBaseEntity)
        m_parent = Value
      End Set
    End Property
    Public Property Path() As String
      Get
        Return m_path
      End Get
      Set(ByVal Value As String)
        m_path = Value
      End Set
    End Property
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
    Public Overridable ReadOnly Property GetCollectionSproc() As String
      Get

      End Get
    End Property
    Public Overridable Property Account As Account
      Get
        Return m_acct
      End Get
      Set(value As Account)
        m_acct = value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Overridable Sub PopulateTree(ByVal tvGroup As TreeView, ByVal ParamArray filters() As Filter)
      'Dim dt As DataTable = Me.GetTreeDataSet(filters).Tables(0)
      Dim ds As DataSet = Me.GetListDataSet("", filters)
      Dim dt As DataTable = ds.Tables(0)
      tvGroup.BeginUpdate()
      tvGroup.Nodes.Clear()

      Dim hashCheckedNode As New Hashtable
      If ds.Tables.Count = 3 Then
        For Each row As DataRow In ds.Tables(2).Rows
          Dim NodeTag As Integer = CInt(row(Prefix & "_id"))
          hashCheckedNode.Add(NodeTag, row)
        Next
      End If

      'tvGroup.ForeColor = Color.Gray
      For Each row As DataRow In dt.Rows
        Dim NodeTag As Integer = CInt(row(Prefix & "_id"))
        Dim NodeNme As String = CStr(row(Prefix & "_code")) & " - " & CStr(row(Prefix & "_name"))
        Dim parentNodes As TreeNodeCollection
        If IsDBNull(row(Prefix & "_parid")) OrElse CInt(row(Prefix & "_parid")) = CInt(row(Prefix & "_id")) Then
          parentNodes = tvGroup.Nodes
        Else
          Dim parnode As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_parid")))
          If hashCheckedNode.ContainsKey(NodeTag) Then
            parnode.Checked = True
          End If

          If parnode Is Nothing Then
            parentNodes = tvGroup.Nodes
          Else
            parentNodes = parnode.Nodes
          End If
        End If
        Dim theNode As TreeNode = parentNodes.Add(NodeNme)
        If hashCheckedNode.ContainsKey(NodeTag) Then
          theNode.Checked = True
        End If

        theNode.Tag = NodeTag
      Next
      If ds.Tables.Count >= 2 Then
        Dim dt2 As DataTable = ds.Tables(1)
        For Each row As DataRow In dt2.Rows
          Dim node As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(row(Prefix & "_id")))
          TreeViewHelper.HilightNode(node, Color.Blue)
        Next
      End If

      tvGroup.EndUpdate()
    End Sub
    Public Function GetCollection(ByVal requiredLevel As Integer, ByVal parentId As Integer) As TreeBaseEntityCollection
      Dim myCollection As New TreeBaseEntityCollection
      Dim sql As String
      If Not parentId = -1 Then
        sql = "select * from [" & Me.TableName & "] where " & Prefix & "_level=" & requiredLevel & " and " & Prefix & "_parid=" & parentId & " order by " & Prefix & "_code"
      Else
        sql = "select * from [" & Me.TableName & "] where " & Prefix & "_level=" & requiredLevel & " order by " & Prefix & "_code"
      End If
      Dim ds As DataSet = CreateDataset(sql)
      For Each dr As DataRow In ds.Tables(0).Rows
        Dim entity As TreeBaseEntity = CType(Me.CreateEntity(Me.FullClassName, New Object() {dr, ""}), TreeBaseEntity)
        myCollection.Add(entity)
      Next
      Return myCollection
    End Function
    Public Function GetCollection(ByVal requiredLevel As Integer, ByVal parentId As Integer, ByVal ParamArray filters() As Filter) As TreeBaseEntityCollection
      Dim params(filters.Length - 1 + 2) As SqlParameter
      For i As Integer = 0 To filters.Length - 1
        params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
      Next
      params(filters.Length) = New SqlParameter("@level", requiredLevel)
      params(filters.Length + 1) = New SqlParameter("@parid", parentId)
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, Me.GetCollectionSproc, params)
      Dim myCollection As New TreeBaseEntityCollection
      For Each dr As DataRow In ds.Tables(0).Rows
        Dim entity As TreeBaseEntity = CType(Me.CreateEntity(Me.FullClassName, New Object() {dr, ""}), TreeBaseEntity)
        myCollection.Add(entity)
      Next
      Return myCollection
    End Function
    Public Overridable Function GetTreeDataSet(ByVal ParamArray filters() As Filter) As DataSet
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        Dim params(filters.Length - 1) As SqlParameter
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim sql As String = "select * from [" & Me.TableName & "] order by " & Prefix & "_level," & Prefix & "_code"

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Return SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, sql)
    End Function
    Public Function GetTreeDataSet(ByVal criteria As String) As DataSet
      If criteria = "" Then
        Dim sql As String = "select * from [" & Me.TableName & "] order by " & Prefix & "_level," & Prefix & "_code"

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Return SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, sql)
      End If
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
          'ElseIf Me.Originated Then
          '    parID = Me.Id
          'Else
          '    parID = DBNull.Value
        End If

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        Dim paramArrayList As New ArrayList
        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_parid", parID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_control", Me.IsControlGroup))


        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

        Return New SaveErrorException(returnVal.Value.ToString)
      End With
    End Function
    Public Overrides Function ToString() As String
      Return m_name
    End Function
    Public Overridable Function ChangeParent(ByVal groupId As Integer, ByVal parentId As Integer) As Integer
      If IsParentChild(parentId, groupId) Then
        Return -1
      End If
      Dim sql As String
      sql = "update [" & Me.TableName & "] set " & Me.Prefix & "_parid= " & parentId & _
      "," & Me.Prefix & "_level =(select " & Me.Prefix & "_level+1 from [" & Me.TableName & "] where " & Me.Prefix & "_id=" & _
      parentId & ")," & Me.Prefix & "_path =(select " & Me.Prefix & "_path+'|" & groupId & _
      "|' from [" & Me.TableName & "] where " & Me.Prefix & "_id=" & parentId & ") where " & Me.Prefix & "_id =" & groupId
      Dim cn As New SqlConnection(Me.ConnectionString)
      Dim cmd As New SqlCommand(sql, cn)
      cn.Open()
      Return cmd.ExecuteNonQuery()
      cn = Nothing
      cmd = Nothing
    End Function
    Public Function IsParentChild(ByVal childId As Integer, ByVal parentId As Integer) As Boolean
      Dim sql As String
      sql = "select count(*) from " & Me.TableName & " child," & Me.TableName & " parent" & _
            " where charindex(parent." & Me.Prefix & "_path, child." & Me.Prefix & "_path) = 1" & _
            " and parent." & Me.Prefix & "_id = " & parentId.ToString & " and child." & Me.Prefix & "_id =" & childId.ToString
      Dim cn As New SqlConnection(Me.ConnectionString)
      Dim cmd As New SqlCommand(sql, cn)
      cn.Open()
      Dim result As Object = cmd.ExecuteScalar
      cn.Close()
      cn = Nothing
      cmd = Nothing
      If IsDBNull(result) OrElse Not IsNumeric(result) OrElse CInt(result) <= 0 Then
        Return False
      End If
      Return True
    End Function
    Public Function IsChildOf(ByVal parent As TreeBaseEntity) As Boolean
      Dim sql As String
      sql = "select count(*) from " & Me.TableName & " child," & Me.TableName & " parent" & _
            " where charindex(parent." & Me.Prefix & "_path, child." & Me.Prefix & "_path) = 1" & _
            " and parent." & Me.Prefix & "_id = " & parent.Id.ToString & " and child." & Me.Prefix & "_id =" & Me.Id
      Dim cn As New SqlConnection(Me.ConnectionString)
      Dim cmd As New SqlCommand(sql, cn)
      cn.Open()
      Dim result As Object = cmd.ExecuteScalar
      cn.Close()
      cn = Nothing
      cmd = Nothing
      If IsDBNull(result) OrElse Not IsNumeric(result) OrElse CInt(result) <= 0 Then
        Return False
      End If
      Return True
    End Function
    Public Function IsDescendantOf(ByVal parent As TreeBaseEntity) As Boolean
      Dim sql As String
      sql = "select count(*) from " & Me.TableName & " child," & Me.TableName & " parent" & _
            " where charindex(parent." & Me.Prefix & "_path, child." & Me.Prefix & "_path) > 0" & _
            " and parent." & Me.Prefix & "_id = " & parent.Id.ToString & " and child." & Me.Prefix & "_id =" & Me.Id
      Dim cn As New SqlConnection(Me.ConnectionString)
      Dim cmd As New SqlCommand(sql, cn)
      cn.Open()
      Dim result As Object = cmd.ExecuteScalar
      cn.Close()
      cn = Nothing
      cmd = Nothing
      If IsDBNull(result) OrElse Not IsNumeric(result) OrElse CInt(result) <= 0 Then
        Return False
      End If
      Return True
    End Function
#End Region

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "TreeBaseEntity"
      End Get
    End Property

  End Class

  Public Class TreeBaseEntityCollection
    Inherits CollectionBase

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As TreeBaseEntity
      Get
        Return CType(MyBase.List.Item(index), TreeBaseEntity)
      End Get
      Set(ByVal value As TreeBaseEntity)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Methods"
    Protected Sub OnItemPropertyChanged(ByVal sender As Object, ByVal e As ItemPropertyChangeEventArgs)
      e.Index = Me.IndexOf(CType(sender, TreeBaseEntity))
    End Sub
    Public Function Add(ByVal value As TreeBaseEntity) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As TreeBaseEntity())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As TreeBaseEntity) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As TreeBaseEntity(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As TreeBaseEntityEnumerator
      Return New TreeBaseEntityEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As TreeBaseEntity) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As TreeBaseEntity)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As TreeBaseEntity)
      MyBase.List.Remove(value)
    End Sub
    Public Overridable Function Save() As Integer
      Debug.WriteLine("Implement Me!!! ItemCollection.Save")
    End Function
    Public Overridable Function Save(ByVal tx As SqlTransaction) As Integer
      Debug.WriteLine("Implement Me!!! ItemCollection.Save")
    End Function
#End Region


    Public Class TreeBaseEntityEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As TreeBaseEntityCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, TreeBaseEntity)
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

  Public Class IHasNameCollection
    Inherits CollectionBase

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As IHasName
      Get
        Return CType(MyBase.List.Item(index), IHasName)
      End Get
      Set(ByVal value As IHasName)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Methods"
    Protected Sub OnItemPropertyChanged(ByVal sender As Object, ByVal e As ItemPropertyChangeEventArgs)
      e.Index = Me.IndexOf(CType(sender, IHasName))
    End Sub
    Public Function Add(ByVal value As IHasName) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As IHasName())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As IHasName) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As IHasName(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As IHasNameEnumerator
      Return New IHasNameEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As IHasName) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As IHasName)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As IHasName)
      MyBase.List.Remove(value)
    End Sub
    Public Overridable Function Save() As Integer
      Debug.WriteLine("Implement Me!!! ItemCollection.Save")
    End Function
    Public Overridable Function Save(ByVal tx As SqlTransaction) As Integer
      Debug.WriteLine("Implement Me!!! ItemCollection.Save")
    End Function
#End Region


    Public Class IHasNameEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As IHasNameCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, IHasName)
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

