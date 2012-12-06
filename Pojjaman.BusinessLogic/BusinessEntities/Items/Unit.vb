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
  Public Class Unit
    Inherits SimpleBusinessEntityBase
    Implements IHasName, IPJMUpdatable, IForceListDialog

#Region "Members"
    Private m_name As String
    Private m_pjmid As Integer
    Private m_isDefault As Boolean

    Private Shared m_AllUnits As Hashtable
    Private Shared m_unitNameIds As Dictionary(Of String, String)
    Public Shared ReadOnly Property AllUnits As Hashtable
      Get
        If m_AllUnits Is Nothing Then
          RefreshAllData()
        End If
        Return m_AllUnits
      End Get
    End Property
    Public Shared ReadOnly Property UnitsNameMap As Dictionary(Of String, String)
      Get
        If m_unitNameIds Is Nothing Then
          RefreshAllData()
        End If
        Return m_unitNameIds
      End Get
    End Property
    Private Shared m_unitTable As DataTable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal unitId As Integer)
      MyBase.New(unitId)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
      MyBase.New(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_pjmid") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_pjmid") Then
          .m_pjmid = CInt(dr(aliasPrefix & Me.Prefix & "_pjmid"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_default") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_default") Then
          .m_isDefault = CBool(dr(aliasPrefix & Me.Prefix & "_default"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property IsDefault() As Boolean      Get        Return m_isDefault      End Get      Set(ByVal Value As Boolean)        m_isDefault = Value      End Set    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Unit"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Unit.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Unit"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Unit"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Unit.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "unit"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Methods"
    Public Shared Sub RefreshAllData()
      Unit.m_AllUnits = New Hashtable
      Unit.m_unitNameIds = New Dictionary(Of String, String)

      Dim key As String = ""
      Dim name As String = ""

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetUnitList" _
    , Nothing)
      If ds.Tables(0).Rows.Count >= 1 Then
        For Each row As DataRow In ds.Tables(0).Rows
          Dim drh As New DataRowHelper(row)
          key = CStr(drh.GetValue(Of Integer)("unit_id"))
          name = drh.GetValue(Of String)("unit_name")
          If name <> "<Reserved>" AndAlso Not name Is Nothing Then
            Unit.m_AllUnits(key) = row
            If Unit.m_unitNameIds.ContainsKey(name) Then
              MessageBox.Show("Dupplicate Unit Name :" & name)
            Else
              Unit.m_unitNameIds.Add(name, key)
            End If
          End If
        Next
      End If
    End Sub
    Public Shared Function GetUnitById(ByVal id As Integer) As Unit
      If id = 0 Then
        Return New Unit
      End If
      Dim key As String = id.ToString
      Dim row As DataRow = CType(AllUnits(key), DataRow)
      If row Is Nothing Then
        Dim blankunit As New Unit
        blankunit.Id = 0
        blankunit.Code = ""
        blankunit.Name = ""
        Return blankunit
      End If
      Dim unit As New Unit(row, "") 'Pui
      Return unit
    End Function
    Public Shared Function GetUnitByName(ByVal name As String) As Unit
      If Not UnitsNameMap.ContainsKey(name) Then
        Dim blankunit As New Unit
        blankunit.Id = 0
        blankunit.Code = ""
        blankunit.Name = ""
        Return blankunit
      End If
      Dim key As String = UnitsNameMap.Item(name)
      Dim row As DataRow = CType(AllUnits(key), DataRow)
      If row Is Nothing Then
        Dim blankunit As New Unit
        blankunit.Id = 0
        blankunit.Code = ""
        blankunit.Name = ""
        Return blankunit
      End If
      Dim unit As New Unit(row, "") 'Pui
      Return unit
    End Function
    Public Shared Sub DestroyCachUnit()
      m_AllUnits = Nothing
      m_unitNameIds = Nothing
    End Sub
    Public Shared Function CountUnitRef(ByVal id As Integer) As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "CountUnitRef", _
      New SqlParameter("@unit_id", id))
      If ds.Tables(0).Rows.Count > 0 Then
        Return (CInt(ds.Tables(0).Rows(0)(0)) = 0)
      End If
      Return True
    End Function
    Public Overrides Function ToString() As String
      Return m_name
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
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

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_pjmid", Me.PJMID))

      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)

      If conn.State = ConnectionState.Open Then conn.Close()
      conn.Open()
      trans = conn.BeginTransaction

      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        trans.Commit()

        '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============
        Unit.m_AllUnits = Nothing
        '== ทำลาย Member นี้ทิ้งเสมอ เมื่อมีการแก้ไข ============

        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(returnVal.Value.ToString)
      Finally
        conn.Close()
      End Try
    End Function
#End Region

#Region "IHasName"
    Public Property Name() As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
        OnTabPageTextChanged(Me, New EventArgs)
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetUnit(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldUnit As Unit) As Boolean
      Dim newunit As New Unit(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newunit.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        newunit = oldUnit
      End If
      txtCode.Text = newunit.Code
      txtName.Text = newunit.Name
      If oldUnit.Id <> newunit.Id Then
        oldUnit = newunit
        Return True
      End If
      Return False
    End Function
#End Region

#Region "IPJMUpdatable"
    Public Property PJMID() As Integer Implements IPJMUpdatable.PJMID
      Get
        Return m_pjmid
      End Get
      Set(ByVal Value As Integer)
        m_pjmid = Value
      End Set
    End Property
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class UnitCollection
    Inherits CollectionBase

#Region "Members"
    Private m_filters As Filter()
#End Region

#Region "Constructors"
    Public Sub New(ByVal filters As Filter())
      HashUnitCollection = New Hashtable

      Dim sqlConString As String = SimpleBusinessEntityBase.SiteConnectionString
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
      , "GetUnitList" _
      , params _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New Unit(row, "")
        Me.Add(item)
        HashUnitCollection.Add(CInt(row("unit_id")), row)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property HashUnitCollection As Hashtable
    Default Public Property Item(ByVal index As Integer) As Unit
      Get
        Return CType(MyBase.List.Item(index), Unit)
      End Get
      Set(ByVal value As Unit)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetItemWithId(ByVal id As Integer) As Unit
      For Each item As Unit In Me
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
    Private Function ValidateReference(hs As Hashtable) As SaveErrorException
      Dim stServ As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      For Each item As Unit In Me
        If item.Originated AndAlso item.IsDirty Then
          If hs.ContainsKey(item.Id) Then
            If Not HashUnitCollection.ContainsKey(item.Id) Then
              Return New SaveErrorException(String.Format(stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.UnitReferenceCannotDelete}"), item.Name))
            End If
            Return New SaveErrorException(String.Format(stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.UnitReferencedCannotUpdate}"), item.Name))
          End If
        End If
      Next

      Return New SaveErrorException("0")
    End Function
    Public Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "CountUnitReferenced")
      Dim unitRefHash As New Hashtable
      For Each row As DataRow In ds.Tables(0).Rows
        If Not row.IsNull("unit_id") Then
          unitRefHash.Add(CInt(row("unit_id")), row)
        End If
      Next

      Dim saveErr As SaveErrorException = ValidateReference(unitRefHash)
      If Not IsNumeric(saveErr.Message) Then
        Return New SaveErrorException(saveErr.Message)
      End If

      Try
        Dim stServ As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        Dim conn As New SqlConnection(sqlConString)
        Dim cmd As SqlCommand = conn.CreateCommand
        cmd.CommandText = "Execute GetUnitList " & GetParamsString(m_filters)
        If Not m_filters Is Nothing AndAlso m_filters.Length > 0 Then
          For i As Integer = 0 To m_filters.Length - 1
            cmd.Parameters.Add(New SqlParameter("@" & m_filters(i).Name, m_filters(i).Value))
          Next
        End If

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "Unit")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("Unit")
        For Each row As DataRow In dt.Rows
          If row.IsNull("unit_default") OrElse CInt(row("unit_default")) = 0 Then
            'ไม่ใช่ default
            If GetItemWithId(CInt(row("unit_id"))) Is Nothing Then
              'หาไม่เจอ
              'If Unit.CountUnitRef(CInt(row("unit_id"))) Then
              If Not unitRefHash.ContainsKey(CInt(row("unit_id"))) Then
                'ลบได้
                row.Delete()
              Else
                'MessageBox.Show("หน่วยนับ '" & CStr(row("unit_name")) & "' ถูกอ้างอิงแล้ว ไม่สามารถลบได้")
                'Return New SaveErrorException(stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.UnitReferenceCannotDelete}"), CStr(row("unit_name")))
                Return New SaveErrorException(String.Format(stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.UnitReferenceCannotDelete}"), CStr(row("unit_name"))))
              End If
            End If
          End If
        Next
        For Each item As Unit In Me
          If Not item.Originated Then
            Dim dr As DataRow = dt.NewRow
            dr("unit_code") = item.Code
            dr("unit_name") = item.Name
            dr("unit_default") = 0 'add เพิ่มเอง
            dr("unit_pjmid") = DBNull.Value
            dt.Rows.Add(dr)
          Else
            Dim theRows As DataRow() = dt.Select("unit_id=" & item.Id)
            If theRows.Length = 1 Then
              Dim dr As DataRow = theRows(0)
              dr("unit_code") = item.Code
              dr("unit_name") = item.Name
              dr("unit_default") = dr("unit_default")
              dr("unit_pjmid") = dr("unit_pjmid")
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
      For Each item As Unit In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add
        newRow("Linenumber") = i
        newRow("code") = item.Code
        newRow("Name") = item.Name
        If item.IsDefault Then
          newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.Default}")
        Else
          newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.UserDefined}")
        End If
        newRow.Tag = item
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As Unit) As Integer
      If Not Me.Contains(value) Then
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As UnitCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As Unit())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As Unit) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As Unit(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As UnitEnumerator
      Return New UnitEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As Unit) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As Unit)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As Unit)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As UnitCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class UnitEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As UnitCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, Unit)
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
