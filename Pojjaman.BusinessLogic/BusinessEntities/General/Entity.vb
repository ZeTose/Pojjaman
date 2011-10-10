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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AutoCodeConfig
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "entityAuto_Config"
      End Get
    End Property
#End Region
  End Class
  Public Class AutoCodeFormat
    Public Sub New()
    End Sub
    Public Sub New(ByVal entity As SimpleBusinessEntityBase)
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      If entity.Originated Then
        Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, _
      "select entityautogen.* from entityautogen inner join entityautocode on entity_autocode = entityauto_id  where entityautocode.entity_id='" & entity.Id & "' and entity_type = '" & entity.EntityId & "'" _
      )
        If ds.Tables(0).Rows.Count > 0 Then
          Dim row As DataRow = ds.Tables(0).Rows(0)
          If row.Table.Columns.Contains("entity_autocodeformat") AndAlso Not row.IsNull("entity_autocodeformat") Then
            Me.Format = (CStr(row("entity_autocodeformat")))
          End If
          If row.Table.Columns.Contains("entity_id") AndAlso Not row.IsNull("entity_id") Then
            Me.EntityId = (CInt(row("entity_id")))
          End If
          If row.Table.Columns.Contains("entityauto_config") AndAlso Not row.IsNull("entityauto_config") Then
            Me.CodeConfig = New AutoCodeConfig(CInt(row("entityauto_config")))
          End If
          If row.Table.Columns.Contains("entityauto_glf") AndAlso Not row.IsNull("entityauto_glf") Then
            Me.GLFormat = New GLFormat(CInt(row("entityauto_glf")))
          End If
          If row.Table.Columns.Contains("entityauto_id") AndAlso Not row.IsNull("entityauto_id") Then
            Me.Id = CInt(row("entityauto_id"))
          End If
        Else
          ds = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, _
        "select * from gl  where gl_refid='" & entity.Id & "' and gl_refdoctype = '" & entity.EntityId & "'" _
        )
          If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            If row.Table.Columns.Contains("gl_glformat") AndAlso Not row.IsNull("gl_glformat") Then
              Me.GLFormat = New GLFormat(CInt(row("gl_glformat")))
            End If
          End If
        End If
      End If
    End Sub
    Private m_id As Integer
    Public Property Id() As Integer
      Get
        Return m_id
      End Get
      Set(ByVal Value As Integer)
        m_id = Value
      End Set
    End Property
    Private m_entityid As Integer
    Public Property EntityId() As Integer
      Get
        Return m_entityid
      End Get
      Set(ByVal Value As Integer)
        m_entityid = Value
      End Set
    End Property
    Private m_format As String
    Public Property Format() As String
      Get
        Return m_format
      End Get
      Set(ByVal Value As String)
        m_format = Value
      End Set
    End Property
    Private m_glformat As GLFormat
    Public Property GLFormat() As GLFormat
      Get
        Return m_glformat
      End Get
      Set(ByVal Value As GLFormat)
        m_glformat = Value
      End Set
    End Property
    Private m_description As String
    Public Property Description() As String
      Get
        Return m_description
      End Get
      Set(ByVal Value As String)
        m_description = Value
      End Set
    End Property
    Private m_config As AutoCodeConfig
    Public Property CodeConfig() As AutoCodeConfig
      Get
        If m_config Is Nothing Then
          m_config = New AutoCodeConfig(-1)
        End If
        Return m_config
      End Get
      Set(ByVal Value As AutoCodeConfig)
        m_config = Value
      End Set
    End Property

    Public Overrides Function ToString() As String
      Return Me.Format
    End Function
  End Class
  Public Class AutoCodeFormatCollection
    Private m_curruserid As Integer
    Private Shared _allAutoCodeFormat As Object

    Public Sub New()
    End Sub
    Private Shared m_AutoCodeFormatTable As DataTable
    Public Shared ReadOnly Property AllAutoCodeFormat(ByVal userid As Integer) As DataTable
      Get
        If m_AutoCodeFormatTable Is Nothing Then
          RefreshData(userid)
        End If
        Return m_AutoCodeFormatTable
      End Get
    End Property



    'Shared Function GetAutoCodeFormat(ByVal userid As Integer, ByVal entityId As Integer) As ArrayList
    '  Dim dt As DataTable = AllAutoCodeFormat(userid)
    '  Dim row() As DataRow = dt.Select("entity_id =" & entityId.ToString)
    '  Dim arr As New List
    '  For Each ar As
    '    Return row()
    'End Function

    Private Shared Sub RefreshData(ByVal userid As Integer, ByVal ParamArray commandParameters() As SqlParameter)
      Dim key As String = ""
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetAutoCodeFormatCollection" _
    , commandParameters)
      'If ds.Tables(0).Rows.Count >= 1 Then
      AutoCodeFormatCollection.m_AutoCodeFormatTable = ds.Tables(0)

      For Each row As DataRow In ds.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        key = CStr(drh.GetValue(Of Integer)("lci_id"))
      Next
      'End If
    End Sub

  End Class
  Public Class Entity

#Region "Members"

    Private Shared m_entityTable As DataTable

#End Region

#Region "Constructors"
    Shared Sub New()
      If m_entityTable Is Nothing OrElse m_entityTable.Rows.Count = 0 Then
        RefreshEntityList()
      End If
    End Sub
#End Region

#Region "Methods"
    Public Shared Function ChangeAccess(ByVal entity_id As Integer, ByVal accessId As Integer) As Integer
      Dim sql As String
      sql = "update entity set entity_access =" & accessId & " where entity_id=" & entity_id
      Dim cn As New SqlConnection(RecentCompanies.CurrentCompany.ConnectionString)
      Dim cmd As New SqlCommand(sql, cn)
      cn.Open()
      Return cmd.ExecuteNonQuery()
      cn = Nothing
      cmd = Nothing
    End Function
    Public Shared Function GetEntityTableForAccess(ByVal accessId As Integer) As DataTable
      Dim dt As DataTable = m_entityTable.Clone
      If accessId = 0 Then
        Return dt
      End If
      Dim rows As DataRow() = m_entityTable.Select("entity_access=" & accessId)
      For Each row As DataRow In rows
        dt.ImportRow(row)
      Next
      Return dt
    End Function
    Public Shared Function GetEntityTableForGLDoc() As DataTable
      Dim dt As New DataTable
      Dim rows() As DataRow = m_entityTable.Select("entity_hasGL = 1")
      For Each col As DataColumn In m_entityTable.Columns
        Dim c As New DataColumn(col.ColumnName)
        dt.Columns.Add(c)
      Next
      For i As Integer = 0 To rows.Length - 1
        Dim r As DataRow = dt.Rows.Add
        For Each col As DataColumn In m_entityTable.Columns
          r(col.ColumnName) = rows(i)(col.ColumnName)
        Next

      Next

      Return dt
    End Function
    Private Shared Function GetData(ByVal className As String, ByVal fieldName As String, Optional ByVal full As Boolean = False) As Object
      If Not className Is Nothing AndAlso className.Length <> 0 Then
        If m_entityTable Is Nothing OrElse m_entityTable.Rows.Count = 0 Then
          RefreshEntityList()
        End If
        Dim str As String
        If full Then
          str = "entity_fullclassname"
        Else
          str = "entity_name"
        End If
        Dim rows() As DataRow = m_entityTable.Select(str & "='" & className & "'")
        If rows.Length = 1 Then
          Return rows(0)(fieldName)
        End If
      End If
    End Function
    Private Shared Function GetData(ByVal id As Integer, ByVal fieldName As String) As Object
      If m_entityTable Is Nothing OrElse m_entityTable.Rows.Count = 0 Then
        RefreshEntityList()
      End If
      Dim rows() As DataRow = m_entityTable.Select("entity_id=" & id)
      If rows.Length = 1 Then
        Return rows(0)(fieldName)
      End If
    End Function

    Public Shared Function GetIdFromClassName(ByVal classname As String) As Integer
      Return CInt(GetData(classname, "entity_id"))
    End Function
    Public Shared Function GetIdFromFullClassName(ByVal classname As String) As Integer
      Return CInt(GetData(classname, "entity_id", True))
    End Function
    Public Shared Function GetAccessIdFromFullClassName(ByVal classname As String) As Integer
      Dim o As Object = GetData(classname, "entity_access", True)
      If Not IsDBNull(o) Then
        Return CInt(GetData(classname, "entity_access", True))
      Else
        Return 0
      End If
    End Function
    Public Shared Function GetAutoCodeFormat(ByVal id As Integer) As String
      Return CStr(GetData(id, "entity_autocodeFormat"))
    End Function
    Public Shared Function GetAutoCodeFormat(ByVal className As String) As String
      Return CStr(GetData(className, "entity_autocodeFormat"))
    End Function

    Public Shared Function GetFullClassName(ByVal id As Integer) As String
      Return CStr(GetData(id, "entity_fullClassName"))
    End Function
    Public Shared Function GetFullClassName(ByVal className As String) As String
      Return CStr(GetData(className, "entity_fullClassName"))
    End Function
    Public Shared Function GetAutoGenStatus(ByVal classname As String) As Boolean
      Dim obj As Object = GetData(classname, "entity_autogen")
      If TypeOf obj Is Boolean Then
        Return CBool(obj)
      End If
      Return False
    End Function
    Public Shared Function GetAutoGenStatus(ByVal id As Integer) As Boolean
      Return CBool(GetData(id, "entity_autogen"))
    End Function
    Public Shared Sub RefreshEntityList()
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select * from [entity] order by entity_id")
      m_entityTable = ds.Tables(0)
    End Sub
    Public Shared m_codelist As ArrayList
    Public Shared Function GetAutoCodeFormats(ByVal entityId As Integer) As ArrayList
      Dim arr As New ArrayList
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select * from [entityautogen] where entity_id=" & entityId & " order by entity_id")
      arr.Add(Entity.GetAutoCodeFormat(entityId))
      If ds.Tables(0).Rows.Count > 0 Then
        For Each row As DataRow In ds.Tables(0).Rows
          If Not row.IsNull("entity_autocodeFormat") Then
            arr.Add(CStr(row("entity_autocodeFormat")))
          End If
        Next
      End If
      Return arr
    End Function

    Public Shared m_AutoCodeFormatList As List(Of AutoCodeFormat)
    Public Shared Sub NewAutoCodeFormats(ByVal entityId As Integer, ByVal userId As Integer)
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, _
      "select * from entityautogen " & _
      "left join userautogen on entityauto_id = userauto_entityauto " & _
      "left join glformat on [entityauto_glf] = glf_id " & _
      "left join [LinkGL] on [GLFormat].[glf_linkgl] = [LinkGL].[linkgl_id] " & _
      "left join [accountbook] on [glf_accountbook] = [accountbook_id] " & _
      "where entity_id ='" & entityId & "' " & _
      "and " & _
      "userauto_user ='" & userId & "' " & _
      "order by userauto_order" _
      )
      If ds.Tables(0).Rows.Count > 0 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim acf As New AutoCodeFormat
          If row.Table.Columns.Contains("entity_autocodeformat") AndAlso Not row.IsNull("entity_autocodeformat") Then
            acf.Format = (CStr(row("entity_autocodeformat")))
          End If
          If row.Table.Columns.Contains("entityauto_config") AndAlso Not row.IsNull("entityauto_config") Then
            acf.CodeConfig = New AutoCodeConfig(CInt(row("entityauto_config")))
          End If
          If row.Table.Columns.Contains("glf_id") AndAlso Not row.IsNull("glf_id") Then
            'acf.GLFormat = New GLFormat(CInt(row("entityauto_glf")))
            acf.GLFormat = New GLFormat(row, "")
          End If
          If row.Table.Columns.Contains("entityauto_id") AndAlso Not row.IsNull("entityauto_id") Then
            acf.Id = CInt(row("entityauto_id"))
          End If
          If row.Table.Columns.Contains("entity_id") AndAlso Not row.IsNull("entity_id") Then
            acf.EntityId = CInt(row("entity_id"))
          End If
          m_AutoCodeFormatList.Add(acf)
        Next
      End If
    End Sub
    Public Shared Function GetNewAutoCodeFormats(ByVal entityId As Integer, ByVal userId As Integer) As List(Of AutoCodeFormat)
      Dim autocodelist As New List(Of AutoCodeFormat)
      If m_AutoCodeFormatList IsNot Nothing Then
        Dim HasEntity As Boolean = False
        For Each acf1 As AutoCodeFormat In m_AutoCodeFormatList
          If acf1.EntityId = entityId Then
            HasEntity = True
          End If
        Next
        If Not HasEntity Then
          NewAutoCodeFormats(entityId, userId)
        End If
            For Each acf2 As AutoCodeFormat In m_AutoCodeFormatList
              If acf2.EntityId = entityId Then
                autocodelist.Add(acf2)
              End If
            Next
            Return autocodelist
      End If
      m_AutoCodeFormatList = New List(Of AutoCodeFormat)
      NewAutoCodeFormats(entityId, userId)
      Return m_AutoCodeFormatList
    End Function
    Public Shared Sub NewPopulateCodeCombo(ByVal cmb As ComboBox, ByVal entityId As Integer, ByVal userId As Integer)
      Dim arr As List(Of AutoCodeFormat) = GetNewAutoCodeFormats(entityId, userId)
      cmb.Items.Clear()
      For Each item As AutoCodeFormat In arr
        cmb.Items.Add(item)
      Next
      If cmb.Items.Count > 0 Then
        cmb.SelectedIndex = 0
      End If
    End Sub
    Public Shared Sub PopulateCodeCombo(ByVal cmb As ComboBox, ByVal entityId As Integer)
      Dim arr As ArrayList = GetAutoCodeFormats(entityId)
      Dim old As String
      old = cmb.Text
      cmb.Items.Clear()
      For Each item As String In arr
        cmb.Items.Add(item)
      Next
      If cmb.Items.Contains(old) Then
        cmb.Text = old
      ElseIf cmb.Items.Count > 0 Then
        cmb.SelectedIndex = 0
      End If
    End Sub
#End Region

  End Class

  Public Class FormEntity

#Region "Members"
    Private m_id As Integer
    Private m_description As String
    Private m_autoCodeFormat As String
    Private m_isAutoGen As Boolean
    Private m_notVisible As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      m_id = 0
      m_description = ""
      m_autoCodeFormat = ""
      m_isAutoGen = True
      m_notVisible = False
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Construct(dr, aliasPrefix)
    End Sub
    Private Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "entity_id") AndAlso Not dr.IsNull(aliasPrefix & "entity_id") Then
          .m_id = CInt(dr(aliasPrefix & "entity_id"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "entity_description") AndAlso Not dr.IsNull(aliasPrefix & "entity_description") Then
          .m_description = CStr(dr(aliasPrefix & "entity_description"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "entity_autocodeformat") AndAlso Not dr.IsNull(aliasPrefix & "entity_autocodeformat") Then
          .m_autoCodeFormat = CStr(dr(aliasPrefix & "entity_autocodeformat"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "entity_autogen") AndAlso Not dr.IsNull(aliasPrefix & "entity_autogen") Then
          .m_isAutoGen = CBool(dr(aliasPrefix & "entity_autogen"))
        End If

        .m_notVisible = False
        If dr.Table.Columns.Contains(aliasPrefix & "entity_visible") AndAlso Not dr.IsNull(aliasPrefix & "entity_visible") Then
          .m_notVisible = CBool(dr(aliasPrefix & "entity_visible"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property NotVisible As Boolean
      Get
        Return m_notVisible
      End Get
      Set(ByVal value As Boolean)
        m_notVisible = value
      End Set
    End Property
    Public Property Id() As Integer
      Get
        Return m_id
      End Get
      Set(ByVal Value As Integer)
        m_id = Value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return m_description
      End Get
      Set(ByVal Value As String)
        m_description = Value
      End Set
    End Property
    Public Property AutoCodeFormat() As String
      Get
        Return m_autoCodeFormat
      End Get
      Set(ByVal Value As String)
        m_autoCodeFormat = Value
      End Set
    End Property
    Public Property IsAutoGen() As Boolean
      Get
        Return m_isAutoGen
      End Get
      Set(ByVal Value As Boolean)
        m_isAutoGen = Value
      End Set
    End Property
#End Region

  End Class
  <Serializable(), DefaultMember("Item")> _
  Public Class FormEntityCollection
    Inherits CollectionBase

#Region "Constructors"
    Public Sub New()

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEntityList")

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New FormEntity(row, "")
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal accessId As Integer)
      Dim dt As DataTable = Entity.GetEntityTableForAccess(accessId)
      For Each row As DataRow In dt.Rows
        Dim item As New FormEntity(row, "")
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As FormEntity
      Get
        Return CType(MyBase.List.Item(index), FormEntity)
      End Get
      Set(ByVal value As FormEntity)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetItemWithId(ByVal id As Integer) As FormEntity
      For Each item As FormEntity In Me
        If item.Id = id Then
          Return item
        End If
      Next
    End Function
    Public Function Save() As SaveErrorException
      Try

        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Execute GetEntityList"

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "FormEntity")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("FormEntity")
        For Each item As FormEntity In Me
          Dim theRows As DataRow() = dt.Select("entity_id=" & item.Id)
          If theRows.Length = 1 Then
            Dim dr As DataRow = theRows(0)
            dr("entity_autogen") = item.IsAutoGen
            dr("entity_autocodeformat") = item.AutoCodeFormat
          End If
        Next
        ' First process deletes.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Entity.RefreshEntityList()
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException("Error Saving:" & ex.ToString)
      End Try
    End Function
    Public Sub PopulateTable(ByVal dt As TreeTable)
      Dim i As Integer = 0
      dt.Clear()
      For Each item As FormEntity In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add
        newRow("Linenumber") = i
        newRow("Description") = item.Description
        newRow("AutoCodeFormat") = item.AutoCodeFormat
        newRow("AutoGen") = item.IsAutoGen
        newRow.Tag = item
      Next
    End Sub
    Public Sub PopulateTable2(ByVal dt As TreeTable)
      Dim i As Integer = 0
      dt.Clear()
      For Each item As FormEntity In Me
        If Not item.NotVisible Then
          i += 1
          Dim newRow As TreeRow = dt.Childs.Add
          newRow("Linenumber") = i
          newRow("Description") = item.Description
          newRow("AutoCodeFormat") = item.AutoCodeFormat
          newRow("AutoGen") = item.IsAutoGen
          newRow.Tag = item
        End If
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As FormEntity) As Integer
      If Not Me.Contains(value) Then
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As FormEntityCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As FormEntity())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As FormEntity) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As FormEntity(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As FormEntityEnumerator
      Return New FormEntityEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As FormEntity) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As FormEntity)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As FormEntity)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As FormEntityCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class FormEntityEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As FormEntityCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, FormEntity)
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
