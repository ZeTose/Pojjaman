Imports Longkong.Pojjaman.DataAccessLayer
'Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic

    Public Class Department
        Inherits SimpleBusinessEntityBase

#Region "Members"
        Private m_name As String
        Private m_startdate As Date
        Private m_enddate As Date
        Private m_budget As Decimal
        Private m_entityid As Integer
        Private m_documentid As Integer
#End Region

#Region "Constuctors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal did As Integer)
            MyBase.New(did)
        End Sub
        Public Sub New(ByVal dcode As String)
            MyBase.New(dcode)
        End Sub
        Public Sub New(ByVal Entity As Object)
            If TypeOf (Entity) Is GoodsReceipt Then
                m_documentid = CType(Entity, GoodsReceipt).Id
                m_entityid = CType(Entity, GoodsReceipt).EntityId
            ElseIf TypeOf (Entity) Is PR Then
                m_documentid = CType(Entity, PR).Id
                m_entityid = CType(Entity, PR).EntityId
            ElseIf TypeOf (Entity) Is PO Then
                m_documentid = CType(Entity, PO).Id
                m_entityid = CType(Entity, PO).EntityId
            End If

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetDepartment" _
            , New SqlParameter("@doc_id", m_documentid) _
            , New SqlParameter("@entity_id", m_entityid))

            If ds.Tables(0).Rows.Count > 0 Then
                Construct(ds.Tables(0).Rows(0))
            End If
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow)
            Construct(dr)
        End Sub
        Private Overloads Sub Construct(ByVal dr As System.Data.DataRow)
            If dr.Table.Columns.Contains("Id") AndAlso Not dr.IsNull("Id") Then
                Id = CInt(dr("Id"))
            End If

            If dr.Table.Columns.Contains("EntityId") AndAlso Not dr.IsNull("EntityId") Then
                m_entityid = CInt(dr("EntityId"))
            End If
            If dr.Table.Columns.Contains("DocumentId") AndAlso Not dr.IsNull("DocumentId") Then
                m_documentid = CInt(dr("DocumentId"))
            End If
            If dr.Table.Columns.Contains("Code") AndAlso Not dr.IsNull("Code") Then
                Code = CStr(dr("Code"))
            End If

            If dr.Table.Columns.Contains("Name") AndAlso Not dr.IsNull("Name") Then
                m_name = CStr(dr("Name"))
            End If
            If dr.Table.Columns.Contains("StartDate") AndAlso Not dr.IsNull("StartDate") Then
                m_startdate = CDate(dr("StartDate"))
            End If
            If dr.Table.Columns.Contains("EndDate") AndAlso Not dr.IsNull("EndDate") Then
                m_enddate = CDate(dr("EndDate"))
            End If
            If dr.Table.Columns.Contains("Budget") AndAlso Not dr.IsNull("Budget") Then
                m_budget = CDec(dr("Budget"))
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Property StartDate() As Date
            Get
                Return m_startdate
            End Get
            Set(ByVal Value As Date)
                m_startdate = Value
            End Set
        End Property
        Public Property EndDate() As Date
            Get
                Return m_enddate
            End Get
            Set(ByVal Value As Date)
                m_enddate = Value
            End Set
        End Property
        Public Property Budget() As Decimal
            Get
                Return m_budget
            End Get
            Set(ByVal Value As Decimal)
                m_budget = Value
            End Set
        End Property
        Public Property dEntityId() As Integer
            Get
                Return m_entityid
            End Get
            Set(ByVal Value As Integer)
                m_entityid = Value
            End Set
        End Property
        Public Property DocumentId() As Integer
            Get
                Return m_documentid
            End Get
            Set(ByVal Value As Integer)
                m_documentid = Value
            End Set
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Department"
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
            With Me
                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList
                paramArrayList.Add(returnVal)

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                paramArrayList.Add(New SqlParameter("@cc_id", Id))
                paramArrayList.Add(New SqlParameter("@doc_id", m_documentid))
                paramArrayList.Add(New SqlParameter("@entity_id", m_entityid))

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

                ' ตรวจจับ Error ของการ Save ...
                Return New SaveErrorException(returnVal.Value.ToString)

            End With
        End Function
        Public Overloads Function Delete(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
            Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
            returnVal.ParameterName = "RETURN_VALUE"
            returnVal.DbType = DbType.Int32
            returnVal.Direction = ParameterDirection.ReturnValue
            returnVal.SourceVersion = DataRowVersion.Current
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
                                    "DeleteDepartment", _
                                    New SqlParameter() { _
                                    New SqlParameter("@cc_id", Id), _
                                    New SqlParameter("@doc_id", m_documentid), _
                                    New SqlParameter("@entity_id", m_entityid), returnVal})

            Return New SaveErrorException(returnVal.Value.ToString)

        End Function
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
    Public Class DepartmentCollection
        Inherits CollectionBase

#Region "Members"
        Private m_cc As Integer
        'Private m_name As String
        'Private m_startdate As Date
        'Private m_enddate As Date
        Private m_childbudget As Decimal
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal mycc As CostCenter)
            If mycc Is Nothing Then
                Return
            End If
            m_cc = mycc.Id
            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetDepartmentList" _
            , New SqlParameter("@cc_id", m_cc))

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New Department(row)
                Me.Add(item)
            Next
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0)(0)) Then
                    m_childbudget = CDec(ds.Tables(1).Rows(0)(0))
                End If
            End If
        End Sub
#End Region

#Region "Properties"
        Public Property Id() As Integer
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Integer)
                m_cc = Value
            End Set
        End Property
        Public Property ChildBudget() As Decimal
            Get
                Return m_childbudget
            End Get
            Set(ByVal Value As Decimal)
                m_childbudget = Value
            End Set
        End Property
        Default Public Property Item(ByVal index As Integer) As DepartmentCollection
            Get
                Return CType(MyBase.List.Item(index), DepartmentCollection)
            End Get
            Set(ByVal value As DepartmentCollection)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Sub PopulateDepartmentBudget(ByVal dt As TreeTable)

            dt.Clear()
            Dim i As Integer = 0
            For Each mybudget As Department In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()

                newRow.Item("dpm_linenumber") = i.ToString
                newRow.Item("Name") = mybudget.Name
                newRow.Item("StartDate") = mybudget.StartDate
                newRow.Item("EndDate") = mybudget.EndDate
                newRow.Item("Budget") = Configuration.FormatToString(mybudget.Budget, DigitConfig.Price)
                newRow.Tag = mybudget
            Next
            dt.AcceptChanges()
        End Sub
        Public Function Save(ByVal cc As CostCenter) As SaveErrorException
            Try
                Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
                Dim conn As New SqlConnection(sqlConString)
                Dim cmd As SqlCommand = conn.CreateCommand
                cmd.CommandText = "select * from department where dpm_costcenter=" & cc.Id

                Dim m_dataset As New DataSet
                Dim m_da As New SqlDataAdapter
                m_da.SelectCommand = cmd

                m_da.Fill(m_dataset, "DepartmentBudget")

                Dim cmdBuilder As New SqlCommandBuilder(m_da)

                Dim dt As DataTable = m_dataset.Tables("DepartmentBudget")
                For Each row As DataRow In dt.Rows
                    row.Delete()
                Next

                For Each item As Department In Me
                    Dim dr As DataRow = dt.NewRow

                    dr("dpm_costcenter") = cc.Id
                    dr("dpm_name") = item.Name
                    dr("dpm_startdate") = item.StartDate
                    dr("dpm_enddate") = item.EndDate
                    dr("dpm_budget") = item.Budget

                    dt.Rows.Add(dr)
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
        Public Function Delete(ByVal cc As CostCenter, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
            'Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            'Dim conn As New SqlConnection(sqlConString)
            Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
            returnVal.ParameterName = "RETURN_VALUE"
            returnVal.DbType = DbType.Int32
            returnVal.Direction = ParameterDirection.ReturnValue
            returnVal.SourceVersion = DataRowVersion.Current
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
                                    "DeleteDepartmentList", _
                                    New SqlParameter() { _
                                    New SqlParameter("@cc_id", cc.Id) _
                                    , returnVal})

            Return New SaveErrorException(returnVal.Value.ToString)
        End Function
        'Public Function Save(ByVal user As User) As SaveErrorException
        '    Try
        '        Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
        '        Dim conn As New SqlConnection(sqlConString)
        '        Dim cmd As SqlCommand = conn.CreateCommand
        '        cmd.CommandText = "select * from usercostcenter where usercc_user=" & user.Id


        '        Dim m_dataset As New DataSet
        '        Dim m_da As New SqlDataAdapter
        '        m_da.SelectCommand = cmd

        '        m_da.Fill(m_dataset, "UserCostCenter")

        '        Dim cmdBuilder As New SqlCommandBuilder(m_da)

        '        Dim dt As DataTable = m_dataset.Tables("UserCostCenter")
        '        For Each row As DataRow In dt.Rows
        '            row.Delete()
        '        Next

        '        For Each item As CostCenterUserAccess In Me
        '            Dim dr As DataRow = dt.NewRow
        '            dr("usercc_user") = user.Id
        '            dr("usercc_cc") = item.CostCenterId
        '            dr("usercc_value") = item.AccessValue
        '            dt.Rows.Add(dr)
        '        Next
        '        If IsSuperMod Then
        '            Dim dr As DataRow = dt.NewRow
        '            dr("usercc_user") = user.Id
        '            dr("usercc_cc") = -1
        '            dr("usercc_value") = 1
        '            dt.Rows.Add(dr)
        '        End If

        '        ' First process deletes.
        '        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        '        ' Next process updates.
        '        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        '        ' Finally process inserts.
        '        m_da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        '        Return New SaveErrorException("1")
        '    Catch ex As Exception
        '        Return New SaveErrorException("Error Saving:" & ex.ToString)
        '    End Try
        'End Function
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As Department) As Integer
            If Not MyBase.List.Contains(value) Then
                Return MyBase.List.Add(value)
            End If
        End Function
        'Public Sub AddRange(ByVal value As DepartmentBudgetCollection)
        '    For i As Integer = 0 To value.Count - 1
        '        Me.Add(value(i))
        '    Next
        'End Sub
        Public Sub AddRange(ByVal value As Department())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        'Public Function Contains(ByVal value As Departmentbudget) As Boolean
        '    Return MyBase.List.Contains(value)
        'End Function
        'Public Sub CopyTo(ByVal array As Departmentbudget(), ByVal index As Integer)
        '    MyBase.List.CopyTo(array, index)
        'End Sub
        'Public Shadows Function GetEnumerator() As DepartmentBudgetEnumerator
        '    Return New DepartmentBudgetEnumerator(Me)
        'End Function
        'Public Function IndexOf(ByVal value As Departmentbudget) As Integer
        '    Return MyBase.List.IndexOf(value)
        'End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Department)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As Department)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As DepartmentCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        '        Public Class DepartmentBudgetEnumerator
        '            Implements IEnumerator

        '#Region "Members"
        '            Private m_baseEnumerator As IEnumerator
        '            Private m_temp As IEnumerable
        '#End Region

        '#Region "Construtor"
        '            Public Sub New(ByVal mappings As DepartmentBudgetCollection)
        '                Me.m_temp = mappings
        '                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
        '            End Sub
        '#End Region

        '            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        '                Get
        '                    Return CType(Me.m_baseEnumerator.Current, Departmentbudget)
        '                End Get
        '            End Property

        '            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        '                Return Me.m_baseEnumerator.MoveNext
        '            End Function

        '            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        '                Me.m_baseEnumerator.Reset()
        '            End Sub
        '        End Class
    End Class

    '    Public Class Department
    '        Inherits SimpleBusinessEntityBase
    '        Implements IHasName

    '#Region "Members"
    '        Private dpt_name As String
    '#End Region

    '#Region "Constructors"
    '        Public Sub New()
    '            MyBase.New()
    '        End Sub
    '        Public Sub New(ByVal id As Integer)
    '            MyBase.New(id)
    '        End Sub
    '        Public Sub New(ByVal code As String)
    '            MyBase.New(code)
    '        End Sub
    '        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
    '            MyBase.New(dr, aliasPrefix)
    '            Construct(dr, aliasPrefix)
    '        End Sub

    '        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
    '            MyBase.Construct(dr, aliasPrefix)
    '            With Me
    '                If Not dr.IsNull(aliasPrefix & "dpt_name") Then
    '                    .dpt_name = CStr(dr(aliasPrefix & "dpt_name"))
    '                End If

    '            End With
    '        End Sub
    '#End Region

    '#Region "Properties"
    '        Public Property Name() As String Implements IHasName.Name    '            Get    '                Return dpt_name    '            End Get    '            Set(ByVal Value As String)    '                dpt_name = Value    '            End Set    '        End Property
    '        Public Overrides ReadOnly Property ClassName() As String
    '            Get
    '                Return "Department"
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property DetailPanelIcon() As String
    '            Get
    '                Return "Icons.16x16.Department"
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property DetailPanelTitle() As String
    '            Get
    '                Return "${res:Longkong.Pojjaman.BusinessLogic.Department.DetailLabel}"
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property ListPanelIcon() As String
    '            Get
    '                Return "Icons.16x16.Department"
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property ListPanelTitle() As String
    '            Get
    '                Return "${res:Longkong.Pojjaman.BusinessLogic.Department.ListLabel}"
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property Prefix() As String
    '            Get
    '                Return "dpt"
    '            End Get
    '        End Property
    '#End Region

    '#Region "Methods"

    '        Public Overrides Function ToString() As String
    '            Return dpt_name
    '        End Function
    '        Private Sub ResetID(ByVal oldid As Integer)
    '            Me.Id = oldid
    '        End Sub
    '        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

    '            Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
    '            returnVal.ParameterName = "RETURN_VALUE"
    '            returnVal.DbType = DbType.Int32
    '            returnVal.Direction = ParameterDirection.ReturnValue
    '            returnVal.SourceVersion = DataRowVersion.Current
    '            Dim paramArrayList As New ArrayList

    '            paramArrayList.Add(returnVal)
    '            If Me.Originated Then
    '                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
    '            End If

    '            Dim theTime As Date = Now
    '            Dim theUser As New User(currentUserId)

    '            If Me.AutoGen And Me.Code.Length = 0 Then
    '                Me.Code = Me.GetNextCode
    '            End If
    '            Me.AutoGen = False

    '            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
    '            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))

    '            ' Save Originator , LastEditor , CancelPerson ...
    '            ' SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)
    '            ' สร้าง SqlParameter จาก ArrayList ...
    '            Dim sqlparams() As SqlParameter
    '            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

    '            Dim trans As SqlTransaction
    '            Dim conn As New SqlConnection(Me.ConnectionString)

    '            If conn.State = ConnectionState.Open Then conn.Close()
    '            conn.Open()
    '            trans = conn.BeginTransaction
    '            Dim oldid As Integer = Me.Id
    '            Try
    '                ' Save Processing ...
    '                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
    '                trans.Commit()
    '                ' ตรวจจับ Error ของการ Save ...
    '                Return New SaveErrorException(returnVal.Value.ToString)
    '            Catch ex As SqlException
    '                trans.Rollback()
    '                Me.ResetID(oldid)
    '                Return New SaveErrorException(returnVal.Value.ToString)
    '            Catch ex As Exception
    '                trans.Rollback()
    '                Me.ResetID(oldid)
    '                Return New SaveErrorException(returnVal.Value.ToString)
    '            Finally
    '                conn.Close()
    '            End Try

    '        End Function

    '#End Region

    '#Region "Shared"
    '        Public Shared Function GetDepartment(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef olddept As Department) As Boolean
    '            Dim newdept As New Department(txtCode.Text)
    '            If txtCode.Text.Length <> 0 AndAlso Not newdept.Valid Then
    '                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
    '                newdept = olddept
    '            End If
    '            txtCode.Text = newdept.Code
    '            txtName.Text = newdept.Name
    '            If olddept.Id <> newdept.Id Then
    '                olddept = newdept
    '                Return True
    '            End If
    '            Return False
    '        End Function
    '#End Region
    'End Class
End Namespace