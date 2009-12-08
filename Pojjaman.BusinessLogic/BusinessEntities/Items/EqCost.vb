Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class EqCost
        Inherits Labor

#Region "Members"
        Private eqcost_group As EqCostGroup
#End Region

#Region "Construct"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Construct(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            Me.eqcost_group = New EqCostGroup
            Me.Type = "2"
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & "eqcostg_id") AndAlso Not dr.IsNull(aliasPrefix & "eqcostg_id") Then
                    .eqcost_group = New EqCostGroup(dr, "")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_group") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_group") Then
                        .eqcost_group = New EqCostGroup(CInt(dr(aliasPrefix & Me.Prefix & "_group")))
                    End If
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Overrides Property Group() As TreeBaseEntity
            Get
                Return eqcost_group
            End Get
            Set(ByVal Value As TreeBaseEntity)
                eqcost_group = CType(Value, EqCostGroup)
                OnPropertyChanged(Me, New PropertyChangedEventArgs)
            End Set
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "EqCost"
            End Get
        End Property

        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "EqCost"
            End Get
        End Property
#End Region

#Region "ICodeGeneratable"
        Public Overrides Function GetLastCode(ByVal prefixPattern As String) As String
            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select top 1 labor_code from [labor] where labor_type = '2' and labor_code like '" & prefixPattern & "' " & " order by " & Me.Prefix & "_id desc"

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql

            Dim obj As Object = cmd.ExecuteScalar
            If Not IsDBNull(obj) AndAlso Not obj Is Nothing Then
                Return obj.ToString
            End If
            Return ""
        End Function
        Public Overrides Function DuplicateCode(ByVal newCode As String) As Boolean
            Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select count(*) from [labor] where labor_code='" & newCode & "' and labor_id <> " & Me.Id

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
#End Region

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                ' Hack :
                Return True
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("${res:Global.Error.NoIdError}")
            End If
            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteEQCost}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEQCost", New SqlParameter() {New SqlParameter("@labor_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.EQCostIsReferencedCannotBeDeleted}")
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If
                trans.Commit()
                Return New SaveErrorException("1")
            Catch ex As SqlException
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Finally
                conn.Close()
            End Try
        End Function
#End Region

        Public Overrides ReadOnly Property GetSprocName() As String
            Get
                Return "Get" & Me.ClassName
            End Get
        End Property
    End Class


    Public Class EqCostGroup
        Inherits TreeBaseEntity

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal myParent As EqCostGroup)
            MyBase.New(myParent)
        End Sub
        Public Sub New(ByVal gid As Integer)
            MyBase.New(gid)
        End Sub
        Public Sub New(ByVal gcode As String)
            MyBase.New(gcode)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "eqcostg"
            End Get
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "EqCostGroup"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.EqCostGroup.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.EqCostGroup"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.EqCostGroup"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.EqCostGroup.ListLabel}"
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
            If parId <> Id Then
                Me.Parent = New EqCostGroup(parId)
            Else
                Me.Parent = Me
            End If
        End Sub
        Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
            Dim par As New EqCostGroup
            par.Id = id
            par.Code = code
            par.Name = name
            Me.Parent = par
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                Dim parID As Object = 0
                If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
                    parID = Me.Parent.Id
                End If

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
                Dim paramArrayList As New ArrayList

                paramArrayList.Add(returnVal)
                If Me.Originated Then
                    paramArrayList.Add(New SqlParameter("@eqcostg_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False

                paramArrayList.Add(New SqlParameter("@eqcostg_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@eqcostg_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@eqcostg_altname", Me.AlternateName))
                paramArrayList.Add(New SqlParameter("@eqcostg_parid", parID))
                paramArrayList.Add(New SqlParameter("@eqcostg_level", Me.Level))
                paramArrayList.Add(New SqlParameter("@eqcostg_path", Me.Path))
                paramArrayList.Add(New SqlParameter("@eqcostg_control", Me.IsControlGroup))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

                ' ตรวจจับ Error ของการ Save ...

                Return New SaveErrorException(returnVal.Value.ToString)

            End With
        End Function
#End Region

#Region "Shared"
        Public Shared Function GetEqCostGroup(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldGroup As EqCostGroup, Optional ByVal allowParent As Boolean = False) As Boolean
            Dim group As New EqCostGroup(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not group.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                group = oldGroup
            ElseIf Not allowParent And group.IsControlGroup Then
                MessageBox.Show(group.Code & "-" & group.Name & " เป็นกลุ่มแม่")
                group = oldGroup
            End If
            txtCode.Text = group.Code
            txtName.Text = group.Name
            If oldGroup.Id <> group.Id Then
                oldGroup = group
                Return True
            End If
            Return False
        End Function
#End Region

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                Return True 'Hack
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("${res:Global.Error.NoIdError}")
            End If
            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteEqCostGroup}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteEqCostGroup", New SqlParameter() {New SqlParameter("@eqcostg_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.EqCostGroupIsReferencedCannotBeDeleted}")
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If
                trans.Commit()
                Return New SaveErrorException("1")
            Catch ex As SqlException
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Finally
                conn.Close()
            End Try
        End Function
#End Region

    End Class

End Namespace
