Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class POPlaceOfDelivery
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
    Private m_name As String
    Private m_isDefault As Boolean
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
            MyBase.New(dr, aliasPrefix)
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub

        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
    Public Property IsDefault() As Boolean      Get        Return m_isDefault      End Get      Set(ByVal Value As Boolean)        m_isDefault = Value      End Set    End Property
    Public Property Name() As String Implements IHasName.Name      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "POPlaceOfDelivery"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.POPlaceOfDelivery.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.POPlaceOfDelivery"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.POPlaceOfDelivery"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "poplaceofdelivery"
      End Get
    End Property

    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.POPlaceOfDelivery.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Shared"
        Public Shared Function GetPOPlaceOfDelivery(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldPOPlaceOfDelivery As POPlaceOfDelivery) As Boolean
            Dim myPOPlaceOfDelivery As New POPlaceOfDelivery(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not myPOPlaceOfDelivery.Originated Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                myPOPlaceOfDelivery = oldPOPlaceOfDelivery
            End If
            txtCode.Text = myPOPlaceOfDelivery.Code
            txtName.Text = myPOPlaceOfDelivery.Name
            If oldPOPlaceOfDelivery.Id <> myPOPlaceOfDelivery.Id Then
                oldPOPlaceOfDelivery = myPOPlaceOfDelivery
                Return True
            End If
            Return False
        End Function
        Public Shared Sub ListInComboBox(ByVal cmb As ComboBox, Optional ByVal includeNothing As Boolean = False)
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString _
            , CommandType.StoredProcedure _
            , "GetPOPlaceOfDeliveryList" _
            )
            Dim dt As DataTable = ds.Tables(0)
            If dt Is Nothing Then
                Return
            End If
            cmb.Items.Clear()
            For Each row As DataRow In dt.Rows
                Dim item As New IdValuePair(CInt(row("poplaceofdelivery_id")), CStr(row("poplaceofdelivery_name")))
                cmb.Items.Add(item)
            Next
            If includeNothing Then
                Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                cmb.Items.Insert(0, New IdValuePair(-1, myService.Parse("${res:Global.Unspecified}")))
            End If
        End Sub

        Public Sub ComboSelect(ByVal cmb As ComboBox)
            For Each item As IdValuePair In cmb.Items
                If Me.Id = item.Id Then
                    cmb.SelectedItem = item
                    Return
                End If
            Next
            cmb.SelectedIndex = -1
        End Sub
#End Region

#Region "Method"
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

            If Me.Originated Then
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
            End If

            Dim theTime As Date = Now
            Dim theUser As New User(currentUserId)

            If Me.AutoGen And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
            End If
            Me.AutoGen = False

            paramArrayList.Add(returnVal)
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))

            SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

            ' สร้าง SqlParameter จาก ArrayList ...
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

  End Class
  <Serializable(), DefaultMember("Item")> _
  Public Class POPlaceOfDeliveryCollection
    Inherits CollectionBase

#Region "Members"
    Private m_filters As Filter()
#End Region

#Region "Constructors"
    Public Sub New(ByVal filters As Filter())

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
      , "GetPOPlaceOfDeliveryList" _
      , params _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New POPlaceOfDelivery(row, "")
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As POPlaceOfDelivery
      Get
        Return CType(MyBase.List.Item(index), POPlaceOfDelivery)
      End Get
      Set(ByVal value As POPlaceOfDelivery)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function GetItemWithId(ByVal id As Integer) As POPlaceOfDelivery
      For Each item As POPlaceOfDelivery In Me
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
        cmd.CommandText = "Execute GetPOPlaceOfDeliveryList " & GetParamsString(m_filters)
        If Not m_filters Is Nothing AndAlso m_filters.Length > 0 Then
          For i As Integer = 0 To m_filters.Length - 1
            cmd.Parameters.Add(New SqlParameter("@" & m_filters(i).Name, m_filters(i).Value))
          Next
        End If

        Dim m_dataset As New DataSet
        Dim m_da As New SqlDataAdapter
        m_da.SelectCommand = cmd

        m_da.Fill(m_dataset, "POPlaceOfDelivery")

        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        Dim dt As DataTable = m_dataset.Tables("POPlaceOfDelivery")
        For Each row As DataRow In dt.Rows
          ' If row.IsNull("unit_default") OrElse CInt(row("unit_default")) = 0 Then
          'ไม่ใช่ default
          If GetItemWithId(CInt(row("poplaceofdelivery_id"))) Is Nothing Then
            'หาไม่เจอ
            'If POPlaceOfDelivery.CanDeleteThisId(CInt(row("poplaceofdelivery_id"))) Then
            'ลบได้
            row.Delete()
            ' Else
            'MessageBox.Show("สถานที่ส่งของ '" & CStr(row("poplaceofdelivery_name")) & "' ถูกอ้างอิงแล้ว ไม่สามารถลบได้")
            'End If
          End If
            ' End If
        Next
        For Each item As POPlaceOfDelivery In Me
          If Not item.Originated Then
            Dim dr As DataRow = dt.NewRow
            dr("poplaceofdelivery_code") = item.Code
            dr("poplaceofdelivery_name") = item.Name
            'dr("unit_default") = 0 'add เพิ่มเอง
            'dr("unit_pjmid") = DBNull.Value
            dt.Rows.Add(dr)
          Else
            Dim theRows As DataRow() = dt.Select("poplaceofdelivery_id=" & item.Id)
            If theRows.Length = 1 Then
              Dim dr As DataRow = theRows(0)
              dr("poplaceofdelivery_code") = item.Code
              dr("poplaceofdelivery_name") = item.Name
              'dr("unit_default") = dr("unit_default")
              'dr("unit_pjmid") = dr("unit_pjmid")
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
      For Each item As POPlaceOfDelivery In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add
        newRow("Linenumber") = i
        newRow("code") = item.Code
        newRow("Name") = item.Name
        'If item.IsDefault Then
        '  newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.Default}")
        'Else
        '  newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.UnitFilterSubPanel.cmbUnitType.UserDefined}")
        'End If
        newRow.Tag = item
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As POPlaceOfDelivery) As Integer
      If Not Me.Contains(value) Then
        Return MyBase.List.Add(value)
      End If
    End Function
    Public Sub AddRange(ByVal value As POPlaceOfDeliveryCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As POPlaceOfDelivery())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As POPlaceOfDelivery) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As POPlaceOfDelivery(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    'Public Shadows Function GetEnumerator() As UnitEnumerator
    '  Return New UnitEnumerator(Me)
    'End Function
    Public Function IndexOf(ByVal value As POPlaceOfDelivery) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As POPlaceOfDelivery)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As POPlaceOfDelivery)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As PoplaceOfDeliveryCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region
  End Class
End Namespace

