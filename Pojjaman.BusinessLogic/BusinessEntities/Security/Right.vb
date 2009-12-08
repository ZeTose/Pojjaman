Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Security.Cryptography
Imports Longkong.Pojjaman.Gui.Components
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Right
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private right_name As String

        Private m_users As RightUserCollection
        Private m_userTable As TreeTable
        Private m_userManager As TreeManager
        Private m_userInitialized As Boolean
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
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If Not dr.IsNull(aliasPrefix & "right_name") Then
                    .right_name = CStr(dr(aliasPrefix & "right_name"))
                End If
            End With

        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String Implements IHasName.Name            Get
                Return right_name
            End Get
            Set(ByVal Value As String)
                right_name = Value
                OnPropertyChanged(Me, New PropertyChangedEventArgs)
            End Set
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Right"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Right.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Right"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Right"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "right"
            End Get
        End Property

        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
                If tpt.EndsWith("()") Then
                    tpt.TrimEnd("()".ToCharArray)
                End If
                Return tpt
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Right.ListLabel}"
            End Get
        End Property
#End Region

#Region "Members"
        Public ManualAdding As Boolean = False
#End Region

#Region "Methods"
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If Me.Valid Then
                    paramArrayList.Add(New SqlParameter("@right_id", Me.Id))
                End If

                paramArrayList.Add(New SqlParameter("@right_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@right_name", Me.Name))

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                ' Execute Store Procedure ...
                If Not Me.Valid Then
                    SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "InsertRight", sqlparams)
                    If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) <> -1 Then
                        Me.Id = CInt(returnVal.Value)
                        Me.Users.Save(currentUserId)
                    End If
                Else
                    SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "UpdateRight", sqlparams)
                    If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) <> -1 Then
                        'Me.Id = CInt(returnval.Value)
                        Me.Users.Save(currentUserId)
                    End If
                    If IsNumeric(returnVal.Value) AndAlso CInt(returnVal.Value) > 0 Then
                        Me.Edited = True
                    End If
                End If

                Return New SaveErrorException(returnVal.Value.ToString)
            End With
        End Function
#End Region

#Region "Right-User"
        Public Sub ReloadUser()
            If Not m_userTable Is Nothing Then
                UserEventUnwiring()
            End If
            ReLoadUsers()
            UserEventWiring()
        End Sub
        Public Sub UserEventWiring()
            WrapperArrayList.AddItemAddedHandler(m_userTable, AddressOf UserTableItemAdded)
            AddHandler m_userTable.RowDeleted, AddressOf UserTable_RowDeleted
            AddHandler m_userTable.ColumnChanging, AddressOf UserTable_ColumnChanging
            AddHandler m_userTable.ColumnChanged, AddressOf UserTable_ColumnChanged
        End Sub
        Public Sub UserEventUnwiring()
            RemoveHandler m_userTable.RowDeleted, AddressOf UserTable_RowDeleted
            RemoveHandler m_userTable.ColumnChanging, AddressOf UserTable_ColumnChanging
            RemoveHandler m_userTable.ColumnChanged, AddressOf UserTable_ColumnChanged
        End Sub
        Public Property Users() As RightUserCollection            Get                Return m_users            End Get            Set(ByVal Value As RightUserCollection)                m_users = Value            End Set        End Property        Public Property UserTable() As TreeTable            Get                Return m_userTable            End Get            Set(ByVal Value As TreeTable)                m_userTable = Value            End Set        End Property        Public Property UserManager() As TreeManager            Get                Return m_userManager            End Get            Set(ByVal Value As TreeManager)                m_userManager = Value            End Set        End Property        Public Property UserInitialized() As Boolean            Get                Return m_userInitialized            End Get            Set(ByVal Value As Boolean)                m_userInitialized = Value            End Set        End Property
        Private Overloads Sub ReLoadUsers()
            m_userInitialized = False
            m_userTable = GetUserTable()
            Me.m_users = New RightUserCollection(Me)
            m_userInitialized = True
        End Sub
        Private Overloads Sub ReLoadUsers(ByVal rows As DataRowCollection)
            m_userInitialized = False
            m_userTable = GetUserTable()
            Me.m_users = New RightUserCollection(Me, rows)
            m_userInitialized = True
        End Sub
        Private Overloads Sub ReLoadUsers(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            m_userInitialized = False
            m_userTable = GetUserTable()
            Me.m_users = New RightUserCollection(Me, ds, aliasPrefix)
            m_userInitialized = True
        End Sub
        Public Shared Function GetUserTable() As TreeTable
            Dim myDatatable As New TreeTable("RightUser")
            myDatatable.Columns.Add(New DataColumn("userright_user", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("level0", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("level1", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("level2", GetType(Boolean)))
            myDatatable.Columns.Add(New DataColumn("level3", GetType(Boolean)))
            Return myDatatable
        End Function
        Public Shared Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "RightUser"

            Dim csUserCode As New TreeTextColumn
            csUserCode.MappingName = "Code"
            csUserCode.HeaderText = "Code"
            csUserCode.NullText = ""
            csUserCode.DataAlignment = HorizontalAlignment.Center
            csUserCode.Width = 100
            csUserCode.ReadOnly = True

            Dim csUserName As New TreeTextColumn
            csUserName.MappingName = "Name"
            csUserName.HeaderText = "Name"
            csUserName.NullText = ""
            csUserName.DataAlignment = HorizontalAlignment.Center
            csUserName.Width = 200
            csUserName.ReadOnly = True

            Dim csLevel0 As New DataGridCheckBoxColumn
            csLevel0.MappingName = "level0"
            csLevel0.HeaderText = "View"
            csLevel0.Width = 100

            Dim csLevel1 As New DataGridCheckBoxColumn
            csLevel1.MappingName = "level1"
            csLevel1.HeaderText = "Edit"
            csLevel1.Width = 100

            Dim csLevel2 As New DataGridCheckBoxColumn
            csLevel2.MappingName = "level2"
            csLevel2.HeaderText = "Print"
            csLevel2.Width = 100

            Dim csLevel3 As New DataGridCheckBoxColumn
            csLevel3.MappingName = "level3"
            csLevel3.HeaderText = "Approve"
            csLevel3.Width = 100

            dst.GridColumnStyles.Add(csUserCode)
            dst.GridColumnStyles.Add(csUserName)
            dst.GridColumnStyles.Add(csLevel0)
            dst.GridColumnStyles.Add(csLevel1)
            dst.GridColumnStyles.Add(csLevel2)
            dst.GridColumnStyles.Add(csLevel3)
            Return dst
        End Function
#End Region

#Region "UserTable Handlers"
        Private Sub UserTable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.m_userInitialized Then
                Return
            End If

            If Not e.Row.RowState = DataRowState.Detached Then
                e.Row.SetColumnError("Code", "")
                Dim index As Integer = Me.m_userTable.Childs.IndexOf(CType(e.Row, TreeRow))
                If index < Me.m_users.Count AndAlso index >= 0 Then
                    Me.m_users(index).CopyFromDataRow(CType(e.Row, TreeRow))
                End If
            Else
                e.Row.SetColumnError("Code", Me.StringParserService.Parse("${res:Global.Error.GridHasNewLine}"))
                'If Not Me.m_validator Is Nothing Then
                '    Me.m_validator.HasNewRow = True
                'End If
            End If
            Me.m_userTable.AcceptChanges()

            Dim pe As New PropertyChangedEventArgs("UserTableItemChanged", "", "")
            Me.OnPropertyChanged(Me, pe)
        End Sub
        Private Sub UserTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.m_userInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetUserValue(e)
                    Case "level0", "level1", "level2", "level3"
                        'SetRightValue(e)
                End Select
                ValidateUserRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateUserRow(ByVal e As DataColumnChangeEventArgs)
            Dim proposedCode As Object = e.Row("Code")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    proposedCode = e.ProposedValue
                Case Else
                    Return
            End Select

            If IsDBNull(proposedCode) Then
                e.Row.SetColumnError("Code", Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
            Else
                e.Row.SetColumnError("Code", "")
            End If
        End Sub
        Private rightSetting As Boolean = False
        Public Sub SetRightValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If rightSetting Then
                Return
            End If
            If Not CBool(e.ProposedValue) Then
                e.ProposedValue = True
                Return
            End If
            rightSetting = True
            Select Case e.Column.ColumnName.ToLower
                Case "level0"
                    e.Row("level1") = False
                    e.Row("level2") = False
                    e.Row("level3") = False
                Case "level1"
                    e.Row("level0") = False
                    e.Row("level2") = False
                    e.Row("level3") = False
                Case "level2"
                    e.Row("level0") = False
                    e.Row("level1") = False
                    e.Row("level3") = False
                Case "level3"
                    e.Row("level0") = False
                    e.Row("level1") = False
                    e.Row("level2") = False
            End Select
            rightSetting = False
        End Sub
        Public Sub SetUserValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            Dim myUser As New User(e.ProposedValue.ToString)
            If myUser.Valid Then
                e.Row("userright_user") = myUser.Id
                e.ProposedValue = myUser.Code
                e.Row("Name") = myUser.Name
            Else
                e.Row("userright_user") = DBNull.Value
                e.ProposedValue = DBNull.Value
                e.Row("Name") = DBNull.Value
            End If

        End Sub
        Private Sub UserRowChangedTick(ByVal sender As Object, ByVal e As EventArgs)
            CType(sender, Timer).Stop()
            If Not Me.m_userInitialized Then
                Return
            End If
            Me.m_userTable.AcceptChanges()
            Dim pe As New PropertyChangedEventArgs("UserTableItemChanged", "", "")
            Me.OnPropertyChanged(Me, pe)
        End Sub
        Private Sub UserTable_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
            Dim t As New Timer
            t.Interval = 1
            AddHandler t.Tick, AddressOf UserRowChangedTick
            t.Start()
        End Sub
        Private Sub UserTableItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
            If Not Me.m_userInitialized Then
                Return
            End If
            Dim pe As New PropertyChangedEventArgs("UserTableItemChanged", "", "")
            Me.OnPropertyChanged(Me, pe)
            e.Row.SetColumnError("Code", "")
            ManualAdding = True
            Dim item As New RightUser
            item.CopyFromDataRow(CType(e.Row, TreeRow))
            Me.m_userTable.Childs.AddChild(CType(e.Row, TreeRow))
            Me.m_users.Add(item)
            ManualAdding = False
            'If Not Me.m_validator Is Nothing Then
            '    Me.m_validator.HasNewRow = False
            'End If
        End Sub
#End Region

    End Class

End Namespace