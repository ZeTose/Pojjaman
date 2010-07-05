Imports System.ComponentModel
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class BusinessEntity
        Implements IComparable, IPropertyChangeable

#Region "Members"
        Private m_orderBy As String
        Private m_id As Integer
        Private m_code As String
        Private m_name As String
        Private m_alternateName As String
        Private m_StringParserService As StringParserService
#End Region

#Region "Events"
        Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements IPropertyChangeable.PropertyChanged
        Public Event TabPageTextChanged As EventHandler
#End Region

#Region "constructors"
        Public Sub New()
            Construct()
        End Sub
        Public Sub New(ByVal id As Integer)
            Construct()
            If id <= 0 Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "Get" & Me.SProcName _
            , New SqlParameter("@" & Me.Prefix & "_id", id) _
            )
            If ds.Tables(0).Rows.Count > 0 Then
                Construct(ds, "")
            End If
        End Sub
        Public Sub New(ByVal code As String)
            If code.Length = 0 Then
                Return
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "Get" & Me.SProcName _
            , New SqlParameter("@" & Me.Prefix & "_code", code) _
            )
            If ds.Tables(0).Rows.Count > 0 Then
                Construct(ds, "")
            End If
        End Sub
        Public Sub New(ByVal reader As IDataReader)
            Construct(reader)
        End Sub
        Public Sub New(ByVal ds As DataSet, ByVal aliasPrefix As String)
            Construct(ds, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overridable Property Id() As Integer            Get                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Id")            End Get            Set(ByVal Value As Integer)                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Id")            End Set        End Property        Public Overridable Property Code() As String            Get                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Code")            End Get            Set(ByVal Value As String)                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Code")            End Set        End Property        Public Overridable Property Name() As String            Get                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Name")            End Get            Set(ByVal Value As String)                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Name")            End Set        End Property        Public Overridable Property AlternateName() As String            Get                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".AlternateName")            End Get            Set(ByVal Value As String)                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".AlternateName")            End Set        End Property
        Public Overridable ReadOnly Property MasterCriteria() As String            Get                Return ""            End Get        End Property
        Public Shared ReadOnly Property ConnectionString() As String
            Get

                Return RecentCompanies.CurrentCompany.ConnectionString
            End Get
        End Property
        Public Property OrderBy() As String            Get                Return m_orderBy            End Get            Set(ByVal Value As String)                m_orderBy = Value            End Set        End Property        Public Overridable ReadOnly Property Prefix() As String            Get
                Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Prefix")
            End Get
        End Property        Public Overridable ReadOnly Property DatabaseName() As String
            Get
                Return Me.ClassName
            End Get
        End Property        Public Overridable ReadOnly Property SProcName() As String
            Get
                Return Me.DatabaseName
            End Get
        End Property        Public Overridable ReadOnly Property ClassName() As String
            Get
                Debug.WriteLine("Implement Me!!! ClassName")
            End Get
        End Property
        Public Overridable ReadOnly Property [NameSpace]() As String
            Get
                Return "Longkong.Pojjaman.BusinessLogic"
            End Get
        End Property
        Public ReadOnly Property FullClassName() As String
            Get
                If Me.NameSpace = "" Then
                    Return Me.ClassName
                End If
                Return Me.NameSpace & "." & Me.ClassName
            End Get
        End Property
        Public ReadOnly Property ListCols() As ListColumnList
            Get
                Return New ListColumnList(Me.ClassName)
            End Get
        End Property
        Public Overridable ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.HelpTopic"
            End Get
        End Property
        Public Overridable ReadOnly Property ListPanelTitle() As String
            Get
                Return Me.ClassName
            End Get
        End Property
        Public Overridable ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.HelpTopic"
            End Get
        End Property
        Public Overridable ReadOnly Property DetailPanelTitle() As String
            Get
                Return Me.ClassName
            End Get
        End Property
        Public Overridable ReadOnly Property TabPageText() As String
            Get
                Return Me.ClassName & ":" & Me.Code
            End Get
        End Property
        Public ReadOnly Property Valid() As Boolean
            Get
                Return Me.Id <> 0
            End Get
        End Property
        Public ReadOnly Property StringParserService() As StringParserService
            Get
                If m_StringParserService Is Nothing Then
                    m_StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                End If
                Return m_StringParserService
            End Get
        End Property
#End Region

#Region "Shared Methods"
        Public Shared Function CreateEntity(ByVal fullClassName As String, ByVal args() As Object) As BusinessEntity
            Dim newInstance As Object
            newInstance = [Assembly].GetExecutingAssembly.CreateInstance(fullClassName, True, BindingFlags.CreateInstance, Nothing, args, Nothing, Nothing)
            If (newInstance Is Nothing) Then
                Debug.WriteLine("Type not found: " & fullClassName)
                Return Nothing
            End If
            Return CType(newInstance, BusinessEntity)
        End Function
        Public Shared Function GetEntity(ByVal fullClassName As String, ByVal id As Integer) As BusinessEntity
            Return BusinessEntity.CreateEntity(fullClassName, New Object() {id})
        End Function
        Public Shared Function GetEntity(ByVal fullClassName As String, ByVal code As String) As BusinessEntity
            Return BusinessEntity.CreateEntity(fullClassName, New Object() {code})
        End Function
        Public Shared Function GetEntity(ByVal fullClassName As String) As BusinessEntity
            Return BusinessEntity.CreateEntity(fullClassName, Nothing)
    End Function
    Public Shared Function GetApprovePersonListfromDoc(ByVal DocId As Integer, ByVal TypeId As Integer) As DataTable
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
          , CommandType.StoredProcedure _
          , "GetApprovePersonListfromDoc" _
          , New SqlParameter("@DocId", DocId) _
          , New SqlParameter("@TypeId", TypeId)
          )
      Return ds.Tables(0)
    End Function
#End Region

#Region "Method"
        Public Function GetDataTable() As TreeTable
            Dim myDatatable As New TreeTable(Me.ClassName)
            For Each col As ListColumn In Me.ListCols
                myDatatable.Columns.Add(New DataColumn(col.Name, GetType(String)))
            Next
            Return myDatatable
        End Function
        Public Function ListTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = Me.ClassName
            For Each col As ListColumn In Me.ListCols
                Dim cs As New DataGridTextColumn
                cs.MappingName = col.Name
                cs.HeaderText = StringParserService.Parse(col.Alias)
                cs.Width = col.Width
                cs.NullText = ""
                dst.GridColumnStyles.Add(cs)
            Next
            Return dst
        End Function
        Public Function GetCodePattern() As String

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select entity_autocodeFormat from entity where entity_name='" & Me.ClassName & "'"

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql
            Dim result As Object = cmd.ExecuteScalar()
            If Not IsDBNull(result) Then
                Return result.ToString
            End If

        End Function
        Public Function GetNextCode() As String
            Dim newCode As String = CodeGenerator.Generate(GetCodePattern, Me.GetLastCode, Now)
            If DuplicateCode(newCode) Then
                Return CodeGenerator.Generate(GetCodePattern, newCode, Now)
            Else
                Return newCode
            End If
        End Function
        Public Function DuplicateCode(ByVal newCode As String) As Boolean

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select count(*) from [" & Me.DatabaseName & "] where " & Me.Prefix & "_code='" & newCode & "'"

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql
            Dim recordCount As Object = cmd.ExecuteScalar
            conn.Close()
            If Not IsDBNull(recordCount) AndAlso CInt(recordCount) > 0 Then
                Return True
            End If
            Return False
        End Function
        Public Function GetLastCode() As String

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select top 1 " & Me.Prefix & "_code from [" & Me.DatabaseName & "] order by " & Me.Prefix & "_id desc"

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql

            Dim obj As Object = cmd.ExecuteScalar
            If Not IsDBNull(obj) Then
                Return obj.ToString
            End If
        End Function
        Public Sub OnPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            RaiseEvent PropertyChanged(sender, e)
        End Sub
        Public Sub OnTabPageTextChanged(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent TabPageTextChanged(sender, e)
        End Sub
        Protected Sub LoadEntity(ByVal sql As String)
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Construct(ds, "")
            End If
        End Sub
        Protected Overridable Sub Construct()
            Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Construct")
        End Sub
        Protected Overridable Sub Construct(ByVal reader As IDataReader)
            Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Construct")
        End Sub
        Protected Overridable Sub Construct(ByVal ds As DataSet, ByVal aliasPrefix As String)
            Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Construct")
        End Sub
        Protected Overridable Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Construct")
        End Sub
        Public Overridable Function GetListDataTable(ByVal query As String, ByVal order As String) As DataTable
            Dim dt As DataTable = GetDataset(query, order).Tables(0)
            dt.TableName = Me.ClassName
            Return dt
        End Function
        Public Overridable Function GetDataset(ByVal query As String, ByVal order As String) As System.Data.DataSet
            Dim sql As String = BuildSql()
            If query.Length = 0 Then
                Return GetDataset(order)
            End If
            sql &= " where " & query
            If order.Length = 0 Then
                Return CreateDataset(sql)
            End If
            sql &= " order by " & order
            Return CreateDataset(sql)
        End Function
        Public Overridable Function GetDataset(ByVal order As String) As System.Data.DataSet
            Dim sql As String = BuildSql()
            If order.Length = 0 Then
                Return CreateDataset(sql)
            End If
            sql &= " order by " & order
            Return CreateDataset(sql)
        End Function
        Public Overridable Function GetDataset() As System.Data.DataSet
            Dim sql As String = BuildSql()
            Return CreateDataset(sql)
        End Function
        Public Function CreateDataset(ByVal sql As String) As Data.DataSet
            Return SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)
        End Function
        Private Function BuildSql() As String
            Dim sql As String = ""
            For Each col As ListColumn In Me.ListCols
                sql &= col.Name & ","
            Next
            If sql = "" Then
                Return "Select * FROM [" & Me.DatabaseName & "]"
            Else
                sql = Left(sql, sql.LastIndexOf(","))
                Return "Select " & sql & " FROM [" & Me.DatabaseName & "]"
            End If
        End Function
        Public Overridable Function Save() As String
            Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Save")
        End Function
        Public Overridable Function Save(ByVal currentUserId As Integer) As String
            Debug.WriteLine("Implement Me!!! " & Me.ClassName & ".Save")
        End Function
#End Region

#Region "IComparable"
        Public Overridable Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            ' Any non-Nothing object is greater than Nothing.
            If obj Is Nothing Then Return 1
            ' Cast to a specific BusinessEntity object to avoid late binding.
            Dim other As BusinessEntity = CType(obj, BusinessEntity)
            Dim result As Integer
            If Me.Id = other.Id Then
                result = 0
            ElseIf Me.Id > other.Id Then
                result = 1
            ElseIf Me.Id < other.Id Then
                result = -1
            Else
                Return Nothing
            End If
            Return result
        End Function
#End Region

        Public ReadOnly Property Initialized() As Boolean Implements IPropertyChangeable.Initialized
            Get

            End Get
        End Property
    End Class


End Namespace

