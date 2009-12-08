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
    Public Class GLFormat
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private m_name As String
        Private m_note As String

        Private m_LinkGL As LinkGL
        Private m_isDefault As Boolean
        Private m_accountBook As AccountBook

        Private m_itemCollection As GLFormatItemCollection
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal lgl As LinkGL)
            MyBase.New()
            Me.LinkGL = lgl
            m_itemCollection = New GLFormatItemCollection(Me)
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
		Protected Overloads Overrides Sub Construct()
			MyBase.Construct()
			m_LinkGL = New LinkGL
			Me.m_accountBook = New AccountBook
			m_itemCollection = New GLFormatItemCollection(Me)
		End Sub
		Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
			MyBase.Construct(dr, aliasPrefix)
			With Me
				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
					.m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
				End If
				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
					.m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
				End If
				If dr.Table.Columns.Contains(aliasPrefix & "linkgl_id") Then
					If Not dr.IsNull(aliasPrefix & "linkgl_id") Then
						.m_LinkGL = New LinkGL(dr, "")
					End If
				Else
					If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linkgl") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linkgl") Then
						.m_LinkGL = New LinkGL(CInt(dr(aliasPrefix & Me.Prefix & "_linkgl")))
					End If
				End If
				If dr.Table.Columns.Contains(aliasPrefix & "accountBook_id") Then
					If Not dr.IsNull(aliasPrefix & "accountBook_id") Then
						.m_accountBook = New AccountBook(dr, "")
					End If
				Else
					If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_accountBook") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_accountBook") Then
						.m_accountBook = New AccountBook(CInt(dr(aliasPrefix & Me.Prefix & "_accountBook")))
					End If
				End If
				If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_isdefault") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_isdefault") Then
					.m_isDefault = CBool(dr(aliasPrefix & Me.Prefix & "_isdefault"))
				End If
			End With
			m_itemCollection = New GLFormatItemCollection(Me)
		End Sub
#End Region

#Region "Properties"
        Public Property ItemCollection() As GLFormatItemCollection
            Get
                Return m_itemCollection
            End Get
            Set(ByVal Value As GLFormatItemCollection)
                m_itemCollection = Value
            End Set
        End Property
        Public Property LinkGL() As LinkGL            Get                Return m_LinkGL            End Get            Set(ByVal Value As LinkGL)                m_LinkGL = Value            End Set        End Property
        Public Property IsDefault() As Boolean            Get                Return m_isDefault            End Get            Set(ByVal Value As Boolean)                m_isDefault = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property        Public Property AccountBook() As AccountBook            Get                Return m_accountBook            End Get            Set(ByVal Value As AccountBook)                m_accountBook = Value            End Set        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "GLFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.GLFormat.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.GLFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.GLFormat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.GLFormat.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "glf"
            End Get
        End Property
        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Name & ")"
                If tpt.EndsWith("()") Then
                    tpt = tpt.TrimEnd("()".ToCharArray)
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

#Region "Shared"
        Public Shared Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("GLFormat")
            myDatatable.Columns.Add(New DataColumn("glfi_linenumber", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("glfi_mapping", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("AcctCode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("AcctButton", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("AcctName", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("CCCode", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("CCName", GetType(String)))
            Return myDatatable
        End Function

        Public Shared Function GetGLFormat(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldglf As GLFormat) As Boolean
            Dim glf As New GLFormat(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not glf.Originated Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                glf = oldglf
            End If
            txtCode.Text = glf.Code
            txtName.Text = glf.Name
            If oldglf.Id <> glf.Id Then
                oldglf = glf
                Return True
            End If
            Return False
        End Function
#End Region

#Region "Methods"
        Public Overrides Function ToString() As String
            Return m_name
        End Function
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current

                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If Me.Originated Then
                    paramArrayList.Add(New SqlParameter("@glf_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                paramArrayList.Add(New SqlParameter("@glf_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@glf_linkgl", Me.ValidIdOrDBNull(Me.LinkGL)))
                paramArrayList.Add(New SqlParameter("@glf_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@glf_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@glf_accountbook", Me.ValidIdOrDBNull(Me.AccountBook)))
                paramArrayList.Add(New SqlParameter("@glf_isdefault", Me.IsDefault))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(Me.ConnectionString)
                conn.Open()
                trans = conn.BeginTransaction()
                Try
                    Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
                    SaveDetail(Me.Id, conn, trans)
                    trans.Commit()
                    Return New SaveErrorException(returnVal.Value.ToString)
                Catch ex As SqlException
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Catch ex As Exception
                    trans.Rollback()
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try
            End With
        End Function
        Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

            Dim da As New SqlDataAdapter("Select * from glformatitem where glfi_glf=" & Me.Id, conn)
            Dim cmdBuilder As New SqlCommandBuilder(da)

            Dim ds As New DataSet

            da.SelectCommand.Transaction = trans

            'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
            cmdBuilder.GetDeleteCommand.Transaction = trans
            cmdBuilder.GetInsertCommand.Transaction = trans
            cmdBuilder.GetUpdateCommand.Transaction = trans

            da.Fill(ds, "glformatitem")
            With ds.Tables("glformatitem")
                For Each row As DataRow In .Rows
                    row.Delete()
                Next
                Dim i As Integer = 0
                For Each item As GLFormatItem In Me.ItemCollection
                    Dim dr As DataRow = .NewRow
                    dr("glfi_glf") = Me.Id
                    dr("glfi_linenumber") = i + 1 'item("gli_linenumber")
                    dr("glfi_field") = item.Field.Id
                    dr("glfi_fieldtype") = item.FieldType.Value
                    dr("glfi_fieldName") = item.Field.Name
                    dr("glfi_isdebit") = item.IsDebit
                    dr("glfi_description") = item.FieldDescription
                    dr("glfi_mapping") = item.Mapping
                    dr("glfi_note") = item.Note
                    dr("glfi_acct") = Me.ValidIdOrDBNull(item.Account)
                    dr("glfi_cc") = Me.ValidIdOrDBNull(item.CostCenter)
                    .Rows.Add(dr)
                    i += 1
                Next
            End With
            Dim dt As DataTable = ds.Tables("glformatitem")
            ' First process deletes.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
            ' Next process updates.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
            ' Finally process inserts.
            da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
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

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                If Me.Originated Then
                    Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced
                Else
                    Return False
                End If
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("Error No id")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                Dim cmd As New SqlCommand("delete glformatitem where glfi_glf=" & Me.Id)
                cmd.Connection = conn
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()
                cmd.CommandText = "delete glformat where glf_id=" & Me.Id
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
#End Region

    End Class

    Public Class GLFormatItemType
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "glfi_fieldtype"
            End Get
        End Property
#End Region

    End Class

    Public Class GLFormatItem

#Region "Members"
        Private m_glFormat As GLFormat

        Private m_lineNumber As Integer
        Private m_field As IHasName
        Private m_fieldType As GLFormatItemType
        Private m_account As Account
        Private m_isDebit As Boolean
        Private m_fieldDescription As String

        Private m_mapping As String
        Private m_note As String

        Private m_cc As CostCenter
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & "glfi_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "glfi_lineNumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & "glfi_lineNumber"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
                    If Not dr.IsNull("acct_id") Then
                        .m_account = New Account(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & "glfi_acct") AndAlso Not dr.IsNull(aliasPrefix & "glfi_acct") Then
                        .m_account = New Account(CInt(dr(aliasPrefix & "glfi_acct")))
                    End If
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "glfi_isdebit") AndAlso Not dr.IsNull(aliasPrefix & "glfi_isdebit") Then
                    .m_isDebit = CBool(dr(aliasPrefix & "glfi_isdebit"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "glfi_fieldtype") AndAlso Not dr.IsNull(aliasPrefix & "glfi_fieldtype") Then
                    .m_fieldType = New GLFormatItemType(CInt(dr(aliasPrefix & "glfi_fieldtype")))
                End If
                Dim fieldId As Integer
                If dr.Table.Columns.Contains(aliasPrefix & "glfi_field") AndAlso Not dr.IsNull(aliasPrefix & "glfi_field") Then
                    fieldId = CInt(dr(aliasPrefix & "glfi_field"))
                End If
                Select Case .m_fieldType.Description.ToLower
                    Case "dynamic"
                        If dr.Table.Columns.Contains(aliasPrefix & "glfi_fieldName") AndAlso Not dr.IsNull(aliasPrefix & "glfi_fieldName") Then
                            .m_field = New BlankItem(CStr(dr(aliasPrefix & "glfi_fieldName")))
                        Else
                            'Todo: Error
                        End If
                        If dr.Table.Columns.Contains(aliasPrefix & "glfi_description") AndAlso Not dr.IsNull(aliasPrefix & "glfi_description") Then
                            .m_fieldDescription = CStr(dr(aliasPrefix & "glfi_description"))
                        Else
                            'Todo: Error
                        End If
                    Case "mix"
                        .m_field = New GeneralAccount(fieldId)
                        If fieldId = 0 Then
                            .m_field.Name = CStr(dr(aliasPrefix & "glfi_fieldName"))
                        End If
                        If dr.Table.Columns.Contains(aliasPrefix & "glfi_description") AndAlso Not dr.IsNull(aliasPrefix & "glfi_description") Then
                            .m_fieldDescription = CStr(dr(aliasPrefix & "glfi_description"))
                        Else
                            'Todo: Error
                        End If
                    Case "generalaccount"
                        .m_field = New GeneralAccount(fieldId)
                        If fieldId = 0 Then
                            .m_field.Name = CStr(dr(aliasPrefix & "glfi_fieldName"))
                        End If
                        If m_account Is Nothing OrElse Not m_account.Originated Then
                            m_account = CType(.m_field, GeneralAccount).Account
                            m_account = New Account(m_account.Code)
                            If Not m_account Is Nothing AndAlso m_account.Originated Then
                                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                                m_account.Name &= " <" & myStringParserService.Parse("${res:Global.Default}") & ">"
                            End If
                            m_account.Id = 0
                        End If
                    Case Else
                End Select

                If dr.Table.Columns.Contains(aliasPrefix & "glfi_mapping") AndAlso Not dr.IsNull(aliasPrefix & "glfi_mapping") Then
                    .m_mapping = CStr(dr(aliasPrefix & "glfi_mapping"))
                End If
                If dr.Table.Columns.Contains(aliasPrefix & "glfi_note") AndAlso Not dr.IsNull(aliasPrefix & "glfi_note") Then
                    .m_note = CStr(dr(aliasPrefix & "glfi_note"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "glfi_cc") AndAlso Not dr.IsNull(aliasPrefix & "glfi_cc") Then
                    .m_cc = New CostCenter(CInt(dr(aliasPrefix & "glfi_cc")))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property CostCenter() As CostCenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As CostCenter)
                m_cc = Value
            End Set
        End Property
        Public Sub SetItemCCCode(ByVal theCode As String)
            Dim entity As New CostCenter(theCode)
            If entity.Originated Then
                Me.CostCenter = entity
            Else
                Me.CostCenter = Nothing
                'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                'msgServ.ShowMessageFormatted("${res:Global.Error.NoCostCenter}", New String() {theCode})
            End If
        End Sub
        Public Property GLFormat() As GLFormat            Get                Return m_glFormat            End Get            Set(ByVal Value As GLFormat)                m_glFormat = Value            End Set        End Property
        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property Account() As Account            Get                Return m_account            End Get            Set(ByVal Value As Account)                m_account = Value            End Set        End Property
        Public Property Field() As IHasName            Get                Return m_field            End Get            Set(ByVal Value As IHasName)                m_field = Value            End Set        End Property        Public Property FieldType() As GLFormatItemType            Get                Return m_fieldType            End Get            Set(ByVal Value As GLFormatItemType)                m_fieldType = Value            End Set        End Property
        Public Property IsDebit() As Boolean            Get                Return m_isDebit            End Get            Set(ByVal Value As Boolean)                m_isDebit = Value            End Set        End Property
        Public Property FieldDescription() As String            Get                Return m_fieldDescription            End Get            Set(ByVal Value As String)                m_fieldDescription = Value            End Set        End Property
        Public Property Mapping() As String            Get                Return m_mapping            End Get            Set(ByVal Value As String)                m_mapping = Value            End Set        End Property
        Public Property Note() As String
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Sub CloneTo(ByVal target As GLFormatItem)
            target.Account = Me.Account
            target.Field = Me.Field
            target.FieldDescription = Me.FieldDescription
            target.FieldType = Me.FieldType
            target.IsDebit = Me.IsDebit
            target.Mapping = Me.Mapping
            target.Note = Me.Note
        End Sub
        Public Sub SetItemCode(ByVal theCode As String)
            If theCode Is Nothing OrElse theCode.Length = 0 Then
                If Not Me.Field Is Nothing AndAlso TypeOf Me.Field Is GeneralAccount Then
                    Dim acct As Account = CType(Me.Field, GeneralAccount).Account
                    acct = New Account(acct.Code)
                    If Not acct Is Nothing AndAlso acct.Originated Then
                        Me.Account = acct
                        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                        Me.Account.Name = acct.Name & " <" & myStringParserService.Parse("${res:Global.Default}") & ">"
                    Else
                        Me.Account = New Account
                    End If
                Else
                    Me.Account = New Account
                End If
                Return
            End If

            Dim entity As New Account(theCode)
            If entity.Originated Then
                Me.Account = entity
            Else
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                msgServ.ShowMessageFormatted("${res:Global.Error.NoAccount}", New String() {theCode})
            End If
        End Sub
        Public Sub ItemValidateRow(ByVal row As DataRow)
            Dim proposedAccount As Object = row("AcctCode")

            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            If IsDBNull(proposedAccount) Then
                row.SetColumnError("AcctCode", myStringParserService.Parse("${res:Global.Error.AccountMissing}"))
            Else
                row.SetColumnError("AcctCode", "")
            End If
        End Sub
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Me.GLFormat.IsInitialized = False
            row("glfi_linenumber") = Me.LineNumber

            Dim displayName As String = ""
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            If Me.IsDebit Then
                '"DR. "
                displayName = myStringParserService.Parse("${res:Global.DebitPrefix}") & Me.Field.Name
            Else
                '"      CR. "
                displayName = myStringParserService.Parse("${res:Global.CreditPrefix}") & Me.Field.Name
            End If
            row("Name") = displayName
            If Not Me.Account Is Nothing Then
                row("AcctCode") = Me.Account.Code
                row("AcctName") = Me.Account.Name
            End If
            If Not Me.CostCenter Is Nothing Then
                row("CCCode") = Me.CostCenter.Code
                row("CCName") = Me.CostCenter.Name
            End If
            If Me.FieldType.Description.ToLower = "dynamic" Or Me.FieldType.Description.ToLower = "mix" Then
                row("AcctCode") = "-------------"
                row("AcctName") = Me.FieldDescription
            End If
            row("glfi_mapping") = Me.Mapping
            row("Note") = Me.Note
            Me.GLFormat.IsInitialized = True

        End Sub
        'Public Sub CopyFromDataRow(ByVal row As TreeRow)
        '    If row Is Nothing Then
        '        Return
        '    End If
        '    Try
        '        If Not row.IsNull(("glfi_linenumber")) Then
        '            Me.LineNumber = CInt(row("glfi_linenumber"))
        '        End If
        '        If Not row.IsNull(("glfi_acct")) Then
        '            Me.Account = New Account(CInt(row("glfi_acct")))
        '        End If
        '        If Not row.IsNull(("glfi_isdebit")) Then
        '            Me.IsDebit = CBool(row("glfi_isdebit"))
        '        End If
        '        If Not IsDBNull(row("glfi_fieldtype")) Then
        '            Me.FieldType = New GLFormatItemType(CInt(row("glfi_fieldtype")))
        '        End If
        '        Select Case Me.FieldType.Description.ToLower
        '            Case "generalaccount", "mix"
        '                Me.Field = New GeneralAccount(CInt(row("glfi_field")))
        '            Case "dynamic"
        '                Me.Field = New BlankItem(CStr(row("Name")))
        '        End Select
        '        If Not row.IsNull(("glfi_mapping")) Then
        '            Me.Mapping = CStr(row("glfi_mapping"))
        '        End If
        '        If Not row.IsNull(("Note")) Then
        '            Me.Note = CStr(row("Note"))
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
        '    End Try

        'End Sub
#End Region

    End Class

    <Serializable(), DefaultMember("Item")> _
Public Class GLFormatItemCollection
        Inherits CollectionBase

#Region "Members"
        Private m_owner As GLFormat
#End Region

#Region "Constructors"
        Public Sub New()
        End Sub
        Public Sub New(ByVal owner As GLFormat)
            Me.m_owner = owner

            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

            If Not m_owner.Originated Then
                If Not m_owner.LinkGL.Originated Then
                    Return
                End If
                Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
                , CommandType.StoredProcedure _
                , "GetDefaultGLFormatItems" _
                , New SqlParameter("@linkgl_id", m_owner.LinkGL.Id) _
                )

                For Each row As DataRow In ds.Tables(0).Rows
                    Dim item As New GLFormatItem(row, "")
                    item.GLFormat = m_owner
                    Me.Add(item)
                Next
            Else
                Dim ds2 As DataSet = SqlHelper.ExecuteDataset(sqlConString _
                , CommandType.StoredProcedure _
                , "GetGLFormatItems" _
                , New SqlParameter("@glf_id", m_owner.Id) _
                )

                For Each row As DataRow In ds2.Tables(0).Rows
                    Dim item As New GLFormatItem(row, "")
                    item.GLFormat = m_owner
                    Me.Add(item)
                Next
            End If
        End Sub
#End Region

#Region "Properties"
        Default Public Property Item(ByVal index As Integer) As GLFormatItem
            Get
                Return CType(MyBase.List.Item(index), GLFormatItem)
            End Get
            Set(ByVal value As GLFormatItem)
                MyBase.List.Item(index) = value
            End Set
        End Property
#End Region

#Region "Shared"

#End Region

#Region "Class Methods"
        Public Sub Populate(ByVal dt As TreeTable)
            dt.Clear()
            Dim i As Integer = 0
            For Each vi As GLFormatItem In Me
                i += 1
                Dim newRow As TreeRow = dt.Childs.Add()
                vi.CopyToDataRow(newRow)
                vi.ItemValidateRow(newRow)
                newRow.Tag = vi
            Next
        End Sub
#End Region

#Region "Collection Methods"
        Public Function Add(ByVal value As GLFormatItem) As Integer
            value.GLFormat = Me.m_owner
            Return MyBase.List.Add(value)
        End Function
        Public Sub AddRange(ByVal value As GLFormatItemCollection)
            For i As Integer = 0 To value.Count - 1
                Me.Add(value(i))
            Next
        End Sub
        Public Function Contains(ByVal value As GLFormatItem) As Boolean
            Return MyBase.List.Contains(value)
        End Function
        Public Sub CopyTo(ByVal array As GLFormatItem(), ByVal index As Integer)
            MyBase.List.CopyTo(array, index)
        End Sub
        Public Shadows Function GetEnumerator() As GLFormatItemEnumerator
            Return New GLFormatItemEnumerator(Me)
        End Function
        Public Function IndexOf(ByVal value As GLFormatItem) As Integer
            Return MyBase.List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As GLFormatItem)
            value.GLFormat = Me.m_owner
            MyBase.List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As GLFormatItem)
            MyBase.List.Remove(value)
        End Sub
        Public Sub Remove(ByVal index As Integer)
            MyBase.List.RemoveAt(index)
        End Sub
#End Region


        Public Class GLFormatItemEnumerator
            Implements IEnumerator

#Region "Members"
            Private m_baseEnumerator As IEnumerator
            Private m_temp As IEnumerable
#End Region

#Region "Construtor"
            Public Sub New(ByVal mappings As GLFormatItemCollection)
                Me.m_temp = mappings
                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
            End Sub
#End Region

            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
                Get
                    Return CType(Me.m_baseEnumerator.Current, GLFormatItem)
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
