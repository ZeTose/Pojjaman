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
    ' Bank
    Public Class Bank
        Inherits SimpleBusinessEntityBase
        Implements IHasName, IForceListDialog

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
            Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            Me.m_name = ""
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                ' Bank name
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_default") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_default") Then
                    .m_isDefault = CBool(dr(aliasPrefix & Me.Prefix & "_default"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property IsDefault() As Boolean
            Get
                Return m_isDefault
            End Get
            Set(ByVal Value As Boolean)
                m_isDefault = Value
            End Set
        End Property
        Public Property Name() As String Implements IHasName.Name
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Bank"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Bank.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Bank"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Bank"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Bank.ListLabel}"
            End Get
        End Property
#End Region

#Region "Method"
        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
        Private Sub ResetID(ByVal oldid As Integer)
            Me.Id = oldid
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
            returnVal.ParameterName = "RETURN_VALUE"
            returnVal.DbType = DbType.Int32
            returnVal.Direction = ParameterDirection.ReturnValue
            returnVal.SourceVersion = DataRowVersion.Current
            Dim paramArrayList As New ArrayList

            Dim theTime As Date = Now
            Dim theUser As New User(currentUserId)

            If Me.AutoGen And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
            End If
            Me.AutoGen = False

            paramArrayList.Add(returnVal)
            If Me.Originated Then
                paramArrayList.Add(New SqlParameter("@bank_id", Me.Id))
            End If
            paramArrayList.Add(New SqlParameter("@bank_code", Me.Code))
            paramArrayList.Add(New SqlParameter("@bank_name", Me.Name))

            'SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

            ' สร้าง SqlParameter จาก ArrayList ...
            Dim sqlparams() As SqlParameter
            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            trans = conn.BeginTransaction

            Dim oldid As Integer = Me.Id

            Try
                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                trans.Commit()
                ' ตรวจจับ Error ของการ Save ...
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As SqlException
                trans.Rollback()
                Me.ResetID(oldid)
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As Exception
                trans.Rollback()
                Me.ResetID(oldid)
                Return New SaveErrorException(returnVal.Value.ToString)
            Finally
                conn.Close()
            End Try


        End Function
#End Region

#Region "Shared"
        Public Shared Function GetBank(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldbank As Bank) As Boolean
            Dim newbank As New Bank(txtCode.Text)
            If txtCode.TextLength <> 0 AndAlso Not newbank.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                newbank = oldbank
            End If
            txtCode.Text = newbank.Code
            txtName.Text = newbank.Name
            If oldbank.Id <> newbank.Id Then
                oldbank = newbank
                Return True
            End If
            Return False
        End Function
#End Region

        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "bank"
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
    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class BankCollection
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
            , "GetBankList" _
            , params _
            )

            For Each row As DataRow In ds.Tables(0).Rows
                Dim item As New Bank(row, "")
                Me.Add(item)
            Next
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As Bank
            Get
                Return CType(MyBase.List.Item(index), Bank)
            End Get
            Set(ByVal value As Bank)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Class Methods"
        Public Function GetItemWithId(ByVal id As Integer) As Bank
            For Each item As Bank In Me
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
                cmd.CommandText = "Execute GetBankList " & GetParamsString(m_filters)
                If Not m_filters Is Nothing AndAlso m_filters.Length > 0 Then
                    For i As Integer = 0 To m_filters.Length - 1
                        cmd.Parameters.Add(New SqlParameter("@" & m_filters(i).Name, m_filters(i).Value))
                    Next
                End If

                Dim m_dataset As New DataSet
                Dim m_da As New SqlDataAdapter
                m_da.SelectCommand = cmd

                m_da.Fill(m_dataset, "Bank")

                Dim cmdBuilder As New SqlCommandBuilder(m_da)

                Dim dt As DataTable = m_dataset.Tables("Bank")
                For Each row As DataRow In dt.Rows
                    If row.IsNull("bank_default") OrElse CInt(row("bank_default")) = 0 Then
                        If GetItemWithId(CInt(row("bank_id"))) Is Nothing Then
                            'หาไม่เจอ
                            row.Delete()
                        End If
                    End If
                Next
                For Each item As Bank In Me
                    If Not item.Originated Then
                        Dim dr As DataRow = dt.NewRow
                        dr("bank_code") = item.Code
                        dr("bank_name") = item.Name
                        dr("bank_default") = 0 'user-defined
                        dt.Rows.Add(dr)
                    Else
                        Dim theRows As DataRow() = dt.Select("bank_id=" & item.Id)
                        If theRows.Length = 1 Then
                            Dim dr As DataRow = theRows(0)
                            dr("bank_code") = item.Code
                            dr("bank_name") = item.Name
                            dr("bank_default") = dr("bank_default")
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
            For Each item As Bank In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add
                newRow("Linenumber") = i
                newRow("code") = item.Code
                newRow("Name") = item.Name
                If item.IsDefault Then
                    newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankFilterSubPanel.cmbUnitType.Default}")
                Else
                    newRow("Default") = stServ.Parse("${res:Longkong.Pojjaman.Gui.Panels.BankFilterSubPanel.cmbUnitType.UserDefined}")
                End If
                newRow.Tag = item
            Next
        End Sub
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As Bank) As Integer
            If Not Me.Contains(value) Then
                Return MyBase.List.Add(value)
            End If
        End Function
        Public Sub AddRange(ByVal value As BankCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Sub AddRange(ByVal value As Bank())
            For i As Integer = 0 To value.Length - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As Bank) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As Bank(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As BankEnumerator
            Return New BankEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As Bank) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Bank)
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As Bank)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal value As BankCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Remove(value(i))
            Next
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class BankEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As BankCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, Bank)
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
