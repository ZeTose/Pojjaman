Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class SupplierContact
    Inherits SimpleBusinessEntityBase
    Implements IHasName


#Region "Members"
    Private suppliercontact_isPrimary As Boolean
    Private suppliercontact_name As String
    Private suppliercontact_title As String
    Private suppliercontact_phone As String
    Private suppliercontact_email As String
    Private suppliercontact_supplier As Supplier
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal suppliercontactCode As String)
      MyBase.New(suppliercontactCode)
    End Sub
    Public Sub New(ByVal suppliercontactId As Integer)
      MyBase.New(suppliercontactId)
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
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      Me.suppliercontact_supplier = New Supplier
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)

      With Me

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .suppliercontact_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_title") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_title") Then
          .suppliercontact_title = CStr(dr(aliasPrefix & Me.Prefix & "_title"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_email") _
      AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_email") Then
          .suppliercontact_email = CStr(dr(aliasPrefix & Me.Prefix & "_email"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_phone") _
      AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_phone") Then
          .suppliercontact_phone = CStr(dr(aliasPrefix & Me.Prefix & "_phone"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isPrimary") _
      AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isPrimary") Then
          .suppliercontact_isPrimary = CBool(dr(aliasPrefix & Me.Prefix & "_isPrimary"))
        End If

        'If dr.Table.Columns.Contains("supplier_id") Then
        '    If Not dr.IsNull("supplier_id") Then
        '        .suppliercontact_supplier = New Supplier(dr, "")
        '    End If
        'Else
        '    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_supplier") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_supplier") Then
        '        .suppliercontact_supplier = New Supplier(CInt(dr(aliasPrefix & Me.Prefix & "_supplier")))
        '    End If
        'End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property Supplier() As Supplier      Get        Return suppliercontact_supplier      End Get      Set(ByVal Value As Supplier)        suppliercontact_supplier = Value      End Set    End Property
    Public Property IsPrimary() As Boolean      Get        Return suppliercontact_isPrimary      End Get      Set(ByVal Value As Boolean)        suppliercontact_isPrimary = Value      End Set    End Property    Public Property Name() As String Implements IHasName.Name      Get        Return suppliercontact_name      End Get      Set(ByVal Value As String)        suppliercontact_name = Value      End Set    End Property    Public Property Title() As String      Get        Return suppliercontact_title      End Get      Set(ByVal Value As String)        suppliercontact_title = Value      End Set    End Property    Public Property Phone() As String      Get        Return suppliercontact_phone      End Get      Set(ByVal Value As String)        suppliercontact_phone = Value      End Set    End Property    Public Property Email() As String      Get        Return suppliercontact_email      End Get      Set(ByVal Value As String)        suppliercontact_email = Value      End Set    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "SupplierContact"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SupplierContact.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.SupplierContact"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.SupplierContact"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "suppliercontact"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.SupplierContact.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Contact")
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Title", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Email", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Phone", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("IsPrimary", GetType(Boolean)))
      Return myDatatable
    End Function
    Public Shared Function GetSupplierContact(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldSupplierContact As SupplierContact) As Boolean
      Dim mySupplierContact As New SupplierContact(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not mySupplierContact.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        mySupplierContact = oldSupplierContact
      End If
      txtCode.Text = mySupplierContact.Code
      txtName.Text = mySupplierContact.Name
      If oldSupplierContact.Id <> mySupplierContact.Id Then
        oldSupplierContact = mySupplierContact
        Return True
      End If
      Return False
    End Function
#End Region

#Region "Method"
    Public Overrides Function ToString() As String
      Return suppliercontact_name
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
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_title", Me.Title))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_email", Me.Email))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_phone", Me.Phone))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isPrimary", Me.IsPrimary))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_supplier", ValidIdOrDBNull(Me.Supplier)))

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
Public Class SupplierContactCollection
    Inherits CollectionBase

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As Supplier)
      If Not owner.Originated Then
        Return
      End If
      If owner.NotGetItems Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetSupplierContactList" _
      , New SqlParameter("@supplier_id", owner.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New SupplierContact(row, "")
        item.Supplier = owner
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As SupplierContact
      Get
        Return CType(MyBase.List.Item(index), SupplierContact)
      End Get
      Set(ByVal value As SupplierContact)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each sc As SupplierContact In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        newRow("Code") = sc.Code
        newRow("Name") = sc.Name
        newRow("Title") = sc.Title
        newRow("Email") = sc.Email
        newRow("Phone") = sc.Phone
        newRow("IsPrimary") = sc.IsPrimary
        newRow.Tag = sc
      Next
    End Sub
    Public Sub Populate(ByVal cmb As ComboBox)
      cmb.Items.Clear()
      Dim i As Integer = 0
      For Each sc As SupplierContact In Me
        cmb.Items.Add(sc.Name)
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As SupplierContact) As Integer
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As SupplierContactCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As SupplierContact())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As SupplierContact) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As SupplierContact(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As SupplierContactEnumerator
      Return New SupplierContactEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As SupplierContact) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As SupplierContact)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As SupplierContact)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As SupplierContactCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class SupplierContactEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As SupplierContactCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, SupplierContact)
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

