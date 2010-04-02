Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Action


#Region "Members"
    Private m_Id As Decimal
    Private m_Name As String
    Private m_Note As String

    Private Shared m_ActionDescHashWithId As Hashtable
    Private Shared m_ActionDescHashWithName As Hashtable
#End Region

#Region "Constructors"
    Shared Sub New()
      RefreshActionList()
    End Sub
    Private Sub New()
    End Sub
    Private Sub New(ByVal dr As DataRow)
      With Me
        If Not dr.IsNull("Id") Then
          Me.m_Id = CDec(dr("Id"))
        End If
        If Not dr.IsNull("Name") Then
          Me.m_Name = CStr(dr("Name"))
        End If
        If Not dr.IsNull("Note") Then
          Me.m_Note = CStr(dr("Note"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property Id As Decimal
      Get
        Return m_Id
      End Get
    End Property
    Public ReadOnly Property Name As String
      Get
        Return m_Name
      End Get
    End Property
    Public ReadOnly Property Note As String
      Get
        Return m_Note
      End Get
    End Property
#End Region

#Region "Methods"
    Public Shared Sub RefreshActionList()
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.Text, "select * from Actions order by Id")
      Dim myTable As DataTable = ds.Tables(0)
      m_ActionDescHashWithId = New Hashtable
      m_ActionDescHashWithName = New Hashtable
      For Each row As DataRow In myTable.Rows
        m_ActionDescHashWithId(CDec(row("ID"))) = New Action(row)
        m_ActionDescHashWithName(row("Name").ToString.ToLower) = New Action(row)
      Next
    End Sub
    Public Shared Function GetActionByName(ByVal name As String) As Action
      If m_ActionDescHashWithName.Contains(name.ToLower) Then
        Return CType(m_ActionDescHashWithName(name.ToLower), Action)
      End If
      Return New Action
    End Function
    Public Shared Function GetActionById(ByVal id As Decimal) As Action
      If m_ActionDescHashWithId.Contains(id) Then
        Return CType(m_ActionDescHashWithId(id), Action)
      End If
      Return New Action
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function ToString() As String
      Return Me.Name & ":" & Me.Note
    End Function
#End Region
  End Class
  Public Class FlowNode
    Public Property State As FlowState
    Private m_incomingPaths As List(Of ActionPath)
    Public Property IncomingPaths As List(Of ActionPath)
      Get
        If m_incomingPaths Is Nothing Then
          m_incomingPaths = New List(Of ActionPath)
        End If
        Return m_incomingPaths
      End Get
      Set(ByVal value As List(Of ActionPath))
        m_incomingPaths = value
      End Set
    End Property
    Private m_outgoingPaths As List(Of ActionPath)
    Public Property OutgoingPaths As List(Of ActionPath)
      Get
        If m_outgoingPaths Is Nothing Then
          m_outgoingPaths = New List(Of ActionPath)
        End If
        Return m_outgoingPaths
      End Get
      Set(ByVal value As List(Of ActionPath))
        m_outgoingPaths = value
      End Set
    End Property
  End Class
  Public Class ActionPath
    Public Property Action As Action
    Public Property StartState As Nullable(Of FlowState)
    Public Property EndState As Nullable(Of FlowState)
    Public Property PossibleRoles As List(Of CCRole)
    Public Property PossibleUsers As List(Of User)
    Public Property MinAmount As Nullable(Of Decimal)
    Public Property MaxAmount As Nullable(Of Decimal)
    Public Property CanBeVisualized As Boolean
    Public Property Tier As Nullable(Of Integer)
    Public Property WarningLimit As Nullable(Of Decimal)
    Public Property Approve As Boolean = False

    Public Sub New()

    End Sub
    Public Sub New(ByVal dr As DataRow)
      If Not dr.IsNull("ActionId") Then
        Me.Action = Action.GetActionById(CInt(dr("ActionId")))
      End If
      If Not dr.IsNull("StartState") Then
        Me.StartState = New FlowState(CStr(dr("StartState")))
      End If
      If Not dr.IsNull("EndState") Then
        Me.EndState = New FlowState(CStr(dr("EndState")))
      End If
      Me.PossibleRoles = New List(Of CCRole)
      If Not dr.IsNull("PossibleRoles") Then
        Dim rolesText As String = CStr(dr("PossibleRoles"))
        If Not String.IsNullOrEmpty(rolesText) Then
          For Each r As String In rolesText.Split(New String() {"||", "|"}, StringSplitOptions.RemoveEmptyEntries)
            Me.PossibleRoles.Add(CCRole.GetCCRoleByCode(r))
          Next
        End If
      End If
      Me.PossibleUsers = New List(Of User)

      If Not dr.IsNull("MinAmount") Then
        Me.MinAmount = CDec(dr("MinAmount"))
      End If
      If Not dr.IsNull("MaxAmount") Then
        Me.MaxAmount = CDec(dr("MaxAmount"))
      End If
      If Not dr.IsNull("CanBeVisualized") Then
        Me.CanBeVisualized = CBool(dr("CanBeVisualized"))
      End If
      If Not dr.IsNull("Tier") Then
        Me.Tier = CInt(dr("Tier"))
      End If
      If Not dr.IsNull("Approve") Then
        Me.Approve = CBool(dr("Approve"))
      End If
    End Sub

    Public Function GetRoleForAction(ByVal actionName As String, ByVal rolesFromCC As List(Of CCUserRole), ByVal currentUserId As Integer) As CCRole
      Dim role As CCRole = Nothing
      If Me.Action.Name = actionName Then
        For Each r As CCRole In Me.PossibleRoles
          For Each ur As CCUserRole In rolesFromCC
            If ur.Role.Id = r.Id AndAlso _
              (Not Me.Tier.HasValue OrElse _
                (ur.Tier.HasValue AndAlso Me.Tier.Value = ur.Tier.Value) _
                ) _
              Then
              If ur.User.Id = currentUserId Then
                Dim amount As Decimal = 0
                If Not Me.MinAmount.HasValue AndAlso Not Me.MaxAmount.HasValue Then
                  role = ur.Role
                Else
                  If TypeOf Me Is IApprovAble Then
                    amount = CType(Me, IApprovAble).AmountToApprove
                    Dim pass As Boolean = True
                    If Me.MinAmount.HasValue Then
                      If Me.MinAmount.Value > amount Then
                        role = Nothing
                      End If
                    End If
                    If Me.MaxAmount.HasValue Then
                      If Me.MaxAmount.Value < amount Then
                        role = Nothing
                      End If
                    End If
                  End If
                End If
              End If
            End If
          Next
        Next
      End If
      Return role
    End Function
    Public Function IsValid(ByVal st As FlowState, ByVal currentUserId As Integer, ByVal entity As Object) As Boolean
      If Not TypeOf entity Is IHasToCostCenter Then
        Return False
      End If
      Dim cc As CostCenter = CType(entity, IHasToCostCenter).ToCC
      If cc Is Nothing Then
        Return False
      End If
      CCUserRole.CreateFor(cc, True)
      Dim rolesFromCC As List(Of CCUserRole) = cc.Roles
      Dim found As Boolean = False
      If Me.StartState.HasValue AndAlso Me.StartState.Value.Name = st.Name Then
        For Each r As CCRole In Me.PossibleRoles
          For Each ur As CCUserRole In rolesFromCC
            If ur.Role.Id = r.Id AndAlso _
              (Not Me.Tier.HasValue OrElse _
                (ur.Tier.HasValue AndAlso Me.Tier.Value = ur.Tier.Value) _
                ) _
              Then
              If ur.User.Id = currentUserId Then
                Dim amount As Decimal = 0
                If Not Me.MinAmount.HasValue AndAlso Not Me.MaxAmount.HasValue Then
                  found = True
                Else
                  If TypeOf entity Is IApprovAble Then
                    amount = CType(entity, IApprovAble).AmountToApprove
                    Dim pass As Boolean = True
                    If Me.MinAmount.HasValue Then
                      If Me.MinAmount.Value > amount Then
                        pass = False
                      End If
                    End If
                    If Me.MaxAmount.HasValue Then
                      If Me.MaxAmount.Value < amount Then
                        pass = False
                      End If
                    End If
                    found = pass
                  End If
                End If
              End If
            End If
          Next
        Next
      End If
      Return found
    End Function
    Public Overrides Function ToString() As String
      If Action Is Nothing OrElse Action.Name Is Nothing Then
        Return ""
      End If
      Dim roleText As String = ""
      For Each r As CCRole In PossibleRoles
        roleText &= r.Name & " or "
      Next
      Return Action.Name & " by " & roleText
    End Function
  End Class
  Public Structure FlowState
    Public Property Name As String
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
      If obj Is Nothing Then
        Return False
      End If
      Return Name.Equals(CType(obj, FlowState).Name)
    End Function
    Public Sub New(ByVal theName As String)
      Name = theName
    End Sub
  End Structure
  Public Class ActionLog

#Region "Members"
    Private m_Id As Decimal
    Private m_EntityTypeId As Integer
    Private m_EntityId As Integer
    Private m_Action As Action
    Private m_Time As Date
    Private m_user As User
    Private m_Role As CCRole
    Private m_Note As String
    Private m_Tier As Nullable(Of Integer)
    Private m_state As String
    Private m_CostCenterId As Integer
    Private m_Amount As Decimal
#End Region

#Region ""
    Public Sub New()

    End Sub
    Public Sub New(ByVal dr As DataRow)
      With Me
        If Not dr.IsNull("Id") Then
          Me.m_Id = CDec(dr("Id"))
        End If
        If Not dr.IsNull("EntityTypeId") Then
          Me.m_EntityTypeId = CInt(dr("EntityTypeId"))
        End If
        If Not dr.IsNull("EntityId") Then
          Me.m_EntityId = CInt(dr("EntityId"))
        End If
        If Not dr.IsNull("ActionId") Then
          Me.m_Action = BusinessLogic.Action.GetActionById(CInt(dr("ActionId")))
        End If
        If Not dr.IsNull("Time") Then
          Me.m_Time = CDate(dr("Time"))
        End If
        If Not dr.IsNull("UserId") Then
          Me.m_user = New User(CInt(dr("UserId")))
        End If
        If Not dr.IsNull("UserRoleId") Then
          Me.m_Role = CCRole.GetCCRoleById(CInt(dr("UserRoleId")))
        End If
        If Not dr.IsNull("Note") Then
          Me.m_Note = CStr(dr("Note"))
        End If
        If Not dr.IsNull("Tier") Then
          Me.m_Tier = CInt(dr("Tier"))
        End If
        If Not dr.IsNull("State") Then
          Me.m_state = CStr(dr("State"))
        End If
        If Not dr.IsNull("CostCenterId") Then
          Me.m_CostCenterId = CInt(dr("CostCenterId"))
        End If
        If Not dr.IsNull("Amount") Then
          Me.m_Amount = CDec(dr("Amount"))
        End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property Id As Decimal      Get        Return m_Id      End Get      Set(ByVal Value As Decimal)        m_Id = Value      End Set    End Property    Public Property EntityTypeId As Integer      Get        Return m_EntityTypeId      End Get      Set(ByVal Value As Integer)        m_EntityTypeId = Value      End Set    End Property    Public Property EntityId As Integer      Get        Return m_EntityId      End Get      Set(ByVal Value As Integer)        m_EntityId = Value      End Set    End Property    Public Property Action As Action      Get        Return m_Action      End Get      Set(ByVal Value As Action)        m_Action = Value      End Set    End Property    Public Property Time As Date      Get        Return m_Time      End Get      Set(ByVal Value As Date)        m_Time = Value      End Set    End Property    Public Property User As User      Get        Return m_user      End Get      Set(ByVal Value As User)        m_user = Value      End Set    End Property    Public Property Role As CCRole      Get        Return m_Role      End Get      Set(ByVal Value As CCRole)        m_Role = Value      End Set    End Property    Public Property Note As String      Get        Return m_Note      End Get      Set(ByVal Value As String)        m_Note = Value      End Set    End Property
    Public Property Tier As Nullable(Of Integer)
      Get
        Return m_Tier
      End Get
      Set(ByVal value As Nullable(Of Integer))
        m_Tier = value
      End Set
    End Property
    Public Property State As String
      Get
        Return m_state
      End Get
      Set(ByVal value As String)
        m_state = value
      End Set
    End Property
    Public Property CostCenterId As Integer      Get        Return m_CostCenterId      End Get      Set(ByVal Value As Integer)        m_CostCenterId = Value      End Set    End Property
    Public Property Amount As Decimal      Get        Return m_Amount      End Get      Set(ByVal Value As Decimal)        m_Amount = Value      End Set    End Property
#End Region

    Public Function Insert() As SaveErrorException
      Try
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Dim da As New SqlDataAdapter("select * from ActionLog where EntityTypeId='" & Me.EntityTypeId & "' and EntityId='" & Me.EntityId & "'", conn)
        Dim ds As New DataSet

        Dim cb As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans

        da.DeleteCommand = cb.GetDeleteCommand
        da.DeleteCommand.Transaction = trans

        da.InsertCommand = cb.GetInsertCommand
        da.InsertCommand.Transaction = trans

        da.UpdateCommand = cb.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        cb = Nothing

        da.FillSchema(ds, SchemaType.Mapped, "ActionLog")
        da.Fill(ds, "ActionLog")

        Dim dt As DataTable = ds.Tables("ActionLog")
        Dim dr As DataRow = dt.NewRow
        dr("EntityId") = Me.EntityId
        dr("EntityTypeId") = Me.EntityTypeId
        If Not Me.Action Is Nothing Then
          dr("ActionId") = Me.Action.Id
        End If
        If Not Me.User Is Nothing Then
          dr("UserId") = Me.User.Id
        End If
        If Not Me.Role Is Nothing Then
          dr("UserRoleId") = Me.Role.Id
        End If
        dr("Note") = Me.Note
        dr("Time") = Me.Time
        If Me.Tier.HasValue Then
          dr("Tier") = Me.Tier.Value
        End If
        dr("State") = Me.State
        dr("CostCenterId") = Me.CostCenterId
        dr("Amount") = Me.Amount
        dt.Rows.Add(dr)
        da.Update(dt.Select("", "", DataViewRowState.Added))
        trans.Commit()
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
      Return New SaveErrorException(Me.Id.ToString)
    End Function
  End Class
End Namespace

