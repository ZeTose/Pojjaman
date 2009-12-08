'Imports Longkong.Pojjaman.DataAccessLayer
'Imports Longkong.Pojjaman.BusinessLogic
'Imports System.Data.SqlClient
'Imports System.IO
'Imports System.ComponentModel
'Imports System.Configuration
'Imports System.Reflection
'Imports Longkong.Core.Services
'Imports Longkong.Pojjaman.Services
'Imports Longkong.Pojjaman.Gui.Components

'Namespace Longkong.Pojjaman.BusinessLogic

'    Public Class FinancialStatementFormatItem

'#Region "Members"
'        Private m_financialstatementformat As FinancialStatementFormat
'        Private m_lineNumber As Integer
'        Private m_field As IHasName
'        Private m_fieldType As FinancialStatementType
'        Private m_account As Account
'        Private m_isDebit As Boolean
'        Private m_fieldDescription As String

'        Private m_mapping As String
'        Private m_note As String
'#End Region

'#Region "Constructors"
'        Public Sub New()
'        End Sub
'        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
'            Construct(dr, aliasPrefix)
'        End Sub
'        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
'            With Me
'                If dr.Table.Columns.Contains(aliasPrefix & "glfi_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "glfi_lineNumber") Then
'                    .m_lineNumber = CInt(dr(aliasPrefix & "glfi_lineNumber"))
'                End If
'                If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
'                    If Not dr.IsNull("acct_id") Then
'                        .m_account = New Account(dr, "")
'                    End If
'                Else
'                    If dr.Table.Columns.Contains(aliasPrefix & "glfi_acct") AndAlso Not dr.IsNull(aliasPrefix & "glfi_acct") Then
'                        .m_account = New Account(CInt(dr(aliasPrefix & "glfi_acct")))
'                    End If
'                End If
'                If dr.Table.Columns.Contains(aliasPrefix & "glfi_isdebit") AndAlso Not dr.IsNull(aliasPrefix & "glfi_isdebit") Then
'                    .m_isDebit = CBool(dr(aliasPrefix & "glfi_isdebit"))
'                End If
'                If dr.Table.Columns.Contains(aliasPrefix & "glfi_fieldtype") AndAlso Not dr.IsNull(aliasPrefix & "glfi_fieldtype") Then
'                    .m_fieldType = New FinancialStatementType(CInt(dr(aliasPrefix & "glfi_fieldtype")))
'                End If
'                Dim fieldId As Integer
'                If dr.Table.Columns.Contains(aliasPrefix & "glfi_field") AndAlso Not dr.IsNull(aliasPrefix & "glfi_field") Then
'                    fieldId = CInt(dr(aliasPrefix & "glfi_field"))
'                End If
'                Select Case .m_fieldType.Description.ToLower
'                    Case "dynamic"
'                        If dr.Table.Columns.Contains(aliasPrefix & "glfi_fieldName") AndAlso Not dr.IsNull(aliasPrefix & "glfi_fieldName") Then
'                            .m_field = New BlankItem(CStr(dr(aliasPrefix & "glfi_fieldName")))
'                        Else
'                            'Todo: Error
'                        End If
'                        If dr.Table.Columns.Contains(aliasPrefix & "glfi_description") AndAlso Not dr.IsNull(aliasPrefix & "glfi_description") Then
'                            .m_fieldDescription = CStr(dr(aliasPrefix & "glfi_description"))
'                        Else
'                            'Todo: Error
'                        End If
'                    Case "mix"
'                        .m_field = New GeneralAccount(fieldId)
'                        If dr.Table.Columns.Contains(aliasPrefix & "glfi_description") AndAlso Not dr.IsNull(aliasPrefix & "glfi_description") Then
'                            .m_fieldDescription = CStr(dr(aliasPrefix & "glfi_description"))
'                        Else
'                            'Todo: Error
'                        End If
'                    Case "generalaccount"
'                        .m_field = New GeneralAccount(fieldId)
'                        If m_account Is Nothing OrElse Not m_account.Originated Then
'                            m_account = CType(.m_field, GeneralAccount).Account
'                            If Not m_account Is Nothing AndAlso m_account.Originated Then
'                                Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
'                                m_account.Name &= " <" & myStringParserService.Parse("${res:Global.Default}") & ">"
'                            End If
'                            m_account.Id = 0
'                        End If
'                    Case Else
'                End Select

'                If dr.Table.Columns.Contains(aliasPrefix & "glfi_mapping") AndAlso Not dr.IsNull(aliasPrefix & "glfi_mapping") Then
'                    .m_mapping = CStr(dr(aliasPrefix & "glfi_mapping"))
'                End If
'                If dr.Table.Columns.Contains(aliasPrefix & "glfi_note") AndAlso Not dr.IsNull(aliasPrefix & "glfi_note") Then
'                    .m_note = CStr(dr(aliasPrefix & "glfi_note"))
'                End If
'            End With
'        End Sub
'#End Region

'#Region "Properties"
'        Public Property FinancialStatementFormat() As FinancialStatementFormat'            Get'                Return m_financialstatementformat'            End Get'            Set(ByVal Value As FinancialStatementFormat)'                m_financialstatementformat = Value'            End Set'        End Property

'        Public Property FinancialStatementItem() As FinancialStatementItem'            Get'                Return m_FinancialStatementItem'            End Get'            Set(ByVal Value As FinancialStatementItem)'                m_FinancialStatementItem = Value'            End Set'        End Property


'        Public Property LineNumber() As Integer'            Get'                Return m_lineNumber'            End Get'            Set(ByVal Value As Integer)'                m_lineNumber = Value'            End Set'        End Property'        Public Property Account() As Account'            Get'                Return m_account'            End Get'            Set(ByVal Value As Account)'                m_account = Value'            End Set'        End Property
'        Public Property Field() As IHasName'            Get'                Return m_field'            End Get'            Set(ByVal Value As IHasName)'                m_field = Value'            End Set'        End Property'        Public Property FieldType() As FinancialStatementType'            Get'                Return m_fieldType'            End Get'            Set(ByVal Value As FinancialStatementType)'                m_fieldType = Value'            End Set'        End Property
'        Public Property IsDebit() As Boolean'            Get'                Return m_isDebit'            End Get'            Set(ByVal Value As Boolean)'                m_isDebit = Value'            End Set'        End Property
'        Public Property FieldDescription() As String'            Get'                Return m_fieldDescription'            End Get'            Set(ByVal Value As String)'                m_fieldDescription = Value'            End Set'        End Property
'        Public Property Mapping() As String'            Get'                Return m_mapping'            End Get'            Set(ByVal Value As String)'                m_mapping = Value'            End Set'        End Property
'        Public Property Note() As String
'            Get
'                Return m_note
'            End Get
'            Set(ByVal Value As String)
'                m_note = Value
'            End Set
'        End Property
'#End Region

'#Region "Methods"
'        Public Sub CopyToDataRow(ByVal row As TreeRow)
'            If row Is Nothing Then
'                Return
'            End If
'            Me.FinancialStatementFormat.IsInitialized = False
'            row("glfi_linenumber") = Me.LineNumber
'            row("glfi_isdebit") = Me.IsDebit

'            Dim displayName As String = ""
'            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
'            If Me.IsDebit Then
'                '"DR. "
'                displayName = myStringParserService.Parse("${res:Global.DebitPrefix}") & Me.Field.Name
'            Else
'                '"      CR. "
'                displayName = myStringParserService.Parse("${res:Global.CreditPrefix}") & Me.Field.Name
'            End If
'            row("Name") = displayName
'            If Not Me.Account Is Nothing Then
'                row("AcctCode") = Me.Account.Code
'                row("AcctName") = Me.Account.Name
'                row("glfi_acct") = Me.Account.Id
'            End If
'            row("glfi_field") = Me.Field.Id
'            row("glfi_fieldtype") = Me.FieldType.Value
'            If Me.FieldType.Description.ToLower = "dynamic" Or Me.FieldType.Description.ToLower = "mix" Then
'                row("AcctCode") = "-------------"
'                row("AcctName") = Me.FieldDescription
'            End If
'            row("glfi_mapping") = Me.Mapping
'            row("Note") = Me.Note
'            Me.FinancialStatementFormat.IsInitialized = True

'        End Sub
'        Public Sub CopyFromDataRow(ByVal row As TreeRow)
'            If row Is Nothing Then
'                Return
'            End If
'            Try
'                If Not row.IsNull(("glfi_linenumber")) Then
'                    Me.LineNumber = CInt(row("glfi_linenumber"))
'                End If
'                If Not row.IsNull(("glfi_acct")) Then
'                    Me.Account = New Account(CInt(row("glfi_acct")))
'                End If
'                If Not row.IsNull(("glfi_isdebit")) Then
'                    Me.IsDebit = CBool(row("glfi_isdebit"))
'                End If
'                If Not IsDBNull(row("glfi_fieldtype")) Then
'                    Me.FieldType = New FinancialStatementType(CInt(row("glfi_fieldtype")))
'                End If
'                Select Case Me.FieldType.Description.ToLower
'                    Case "generalaccount", "mix"
'                        Me.Field = New GeneralAccount(CInt(row("glfi_field")))
'                    Case "dynamic"
'                        Me.Field = New BlankItem(CStr(row("Name")))
'                End Select
'                If Not row.IsNull(("glfi_mapping")) Then
'                    Me.Mapping = CStr(row("glfi_mapping"))
'                End If
'                If Not row.IsNull(("Note")) Then
'                    Me.Note = CStr(row("Note"))
'                End If
'            Catch ex As Exception
'                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
'            End Try

'        End Sub
'#End Region

'    End Class

'    <Serializable(), DefaultMember("Item")> _
'Public Class FinancialStatementFormatItemCollection
'        Inherits CollectionBase

'#Region "Members"
'        Private m_fsowner As FinancialStatementFormat
'#End Region

'#Region "Constructors"
'        Public Sub New()
'        End Sub
'        Public Sub New(ByVal owner As FinancialStatementFormat)
'            Me.m_fsowner = owner
'            If Not Me.m_fsowner.Originated Then
'                Return
'            End If

'            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

'            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
'            , CommandType.StoredProcedure _
'            , "GetFinancialStatementFormatItems" _
'            , New SqlParameter("@boq_id", Me.m_fsowner.Id) _
'            )

'            For Each row As DataRow In ds.Tables(0).Rows
'                Dim item As New FinancialStatementFormatItem(row, "")
'                item.FinancialStatementFormat = m_fsowner
'                Me.Add(item)
'            Next
'        End Sub
'#End Region

'#Region "Properties"
'        Public Property FsOwner() As FinancialStatementFormat'            Get'                Return m_fsowner'            End Get'            Set(ByVal Value As FinancialStatementFormat)'                m_fsowner = Value'            End Set'        End Property'        Default Public Property Item(ByVal index As Integer) As FinancialStatementFormatItem
'            Get
'                Return CType(MyBase.List.Item(index), FinancialStatementFormatItem)
'            End Get
'            Set(ByVal value As FinancialStatementFormatItem)
'                MyBase.List.Item(index) = value
'            End Set
'        End Property
'#End Region

'#Region "Class Methods"
'        Public Function GetCollectionForWBS(ByVal wbs As FinancialStatementItem) As FinancialStatementFormatItemCollection
'            Dim myCollection As New FinancialStatementFormatItemCollection
'            myCollection.FsOwner = Me.FsOwner
'            For Each item As FinancialStatementFormatItem In Me
'                If item.FinancialStatementItem Is wbs Then
'                    myCollection.Add(item)
'                ElseIf wbs.Id <> 0 And wbs.Id = item.FinancialStatementItem.Id Then
'                    myCollection.Add(item)
'                End If
'            Next
'            Return myCollection
'        End Function
'        Public Function GetNextItem(ByVal bitem As FinancialStatementFormatItem) As FinancialStatementFormatItem
'            Dim index As Integer = Me.IndexOf(bitem)
'            If index > Me.Count - 2 Or index < 0 Then
'                Return Nothing
'            End If
'            Dim thisWbs As FinancialStatementItem = bitem.FinancialStatementItem
'            For i As Integer = index To Me.Count - 1
'                Dim nextWbs As FinancialStatementItem = Me(i).FinancialStatementItem
'                If thisWbs Is nextWbs Then
'                    Return Me(i)
'                ElseIf thisWbs.Id <> 0 And thisWbs.Id = nextWbs.Id Then
'                    Return Me(i)
'                End If
'            Next
'            Return Nothing
'        End Function
'#End Region

'#Region "Collection Methods"
'        Public Function Add(ByVal value As FinancialStatementFormatItem) As Integer
'            value.FinancialStatementFormat = m_fsowner
'            Return MyBase.List.Add(value)
'        End Function
'        Public Sub AddRange(ByVal value As FinancialStatementFormatItemCollection)
'            For i As Integer = 0 To value.Count - 1
'                value(i).FinancialStatementFormat = m_fsowner
'                Me.Add(value(i))
'            Next
'        End Sub
'        Public Sub AddRange(ByVal value As FinancialStatementFormatItem())
'            For i As Integer = 0 To value.Length - 1
'                value(i).FinancialStatementFormat = m_fsowner
'                Me.Add(value(i))
'            Next
'        End Sub
'        Public Function Contains(ByVal value As FinancialStatementFormatItem) As Boolean
'            Return MyBase.List.Contains(value)
'        End Function
'        Public Sub CopyTo(ByVal array As FinancialStatementFormatItem(), ByVal index As Integer)
'            MyBase.List.CopyTo(array, index)
'        End Sub
'        Public Shadows Function GetEnumerator() As FinancialStatementFormatItemEnumerator
'            Return New FinancialStatementFormatItemEnumerator(Me)
'        End Function
'        Public Function IndexOf(ByVal value As FinancialStatementFormatItem) As Integer
'            Return MyBase.List.IndexOf(value)
'        End Function
'        Public Sub Insert(ByVal index As Integer, ByVal value As FinancialStatementFormatItem)
'            value.FinancialStatementFormat = m_fsowner
'            MyBase.List.Insert(index, value)
'        End Sub
'        Public Sub Remove(ByVal value As FinancialStatementFormatItem)
'            MyBase.List.Remove(value)
'        End Sub
'        Public Sub Remove(ByVal value As FinancialStatementFormatItemCollection)
'            For i As Integer = 0 To value.Count - 1
'                Me.Remove(value(i))
'            Next
'        End Sub
'        Public Sub Remove(ByVal index As Integer)
'            MyBase.List.RemoveAt(index)
'        End Sub
'#End Region


'        Public Class FinancialStatementFormatItemEnumerator
'            Implements IEnumerator

'#Region "Members"
'            Private m_baseEnumerator As IEnumerator
'            Private m_temp As IEnumerable
'#End Region

'#Region "Construtor"
'            Public Sub New(ByVal mappings As FinancialStatementFormatItemCollection)
'                Me.m_temp = mappings
'                Me.m_baseEnumerator = Me.m_temp.GetEnumerator
'            End Sub
'#End Region

'            Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
'                Get
'                    Return CType(Me.m_baseEnumerator.Current, FinancialStatementFormatItem)
'                End Get
'            End Property

'            Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
'                Return Me.m_baseEnumerator.MoveNext
'            End Function

'            Public Sub Reset() Implements System.Collections.IEnumerator.Reset
'                Me.m_baseEnumerator.Reset()
'            End Sub
'        End Class
'    End Class
'End Namespace
