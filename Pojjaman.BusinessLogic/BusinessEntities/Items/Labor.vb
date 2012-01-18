Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Labor
    Inherits SimpleBusinessEntityBase
    Implements IMultiName, IPJMUpdatable, IHasUnit, IHasPrice

#Region "Members"
    Private labor_name As String
    Private labor_group As LaborGroup
    Private labor_alternateName As String
    Private labor_unit As Unit
    Private labor_cost As Decimal
    Private labor_costdate As DateTime
    Private labor_type As String
    Private labor_pjmid As Integer
#End Region

#Region "Constructor"
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
      Me.labor_group = New LaborGroup
      Me.labor_unit = New Unit
      Me.Type = "1"
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)

      MyBase.Construct(dr, aliasPrefix)

      Dim drh As New DataRowHelper(dr)

      With Me


        .labor_name = drh.GetValue(Of String)(aliasPrefix & "labor_name")


        If dr.Table.Columns.Contains(aliasPrefix & "laborg_id") AndAlso Not dr.IsNull(aliasPrefix & "laborg_id") Then
          .labor_group = New LaborGroup(dr, "")
        Else
          .labor_group = New LaborGroup(drh.GetValue(Of Integer)(aliasPrefix & Me.Prefix & "_group"))
        End If


        .labor_pjmid = drh.GetValue(Of Integer)(aliasPrefix & "labor_pjmid")
        .labor_alternateName = drh.GetValue(Of String)(aliasPrefix & "labor_altName")
        .labor_cost = drh.GetValue(Of Decimal)(aliasPrefix & "labor_cost")
        .labor_costdate = drh.GetValue(Of Date)(aliasPrefix & "labor_costdate")
        .labor_type = drh.GetValue(Of String)(aliasPrefix & "labor_type")

        If dr.Table.Columns.Contains("unit_id") Then
          If Not dr.IsNull("unit_id") Then
            Dim unitId As Integer = drh.GetValue(Of Integer)("unit_id")
            .labor_unit = Unit.GetUnitById(unitId)
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "labor_unit") Then
            Dim unitId As Integer = drh.GetValue(Of Integer)(aliasPrefix & "labor_unit")
            .labor_unit = Unit.GetUnitById(unitId)
          End If
        End If

        'If Not dr.IsNull(aliasPrefix & "labor_name") Then
        '  .labor_name = CStr(dr(aliasPrefix & "labor_name"))
        'End If

        'If dr.Table.Columns.Contains(aliasPrefix & "laborg_id") AndAlso Not dr.IsNull(aliasPrefix & "laborg_id") Then
        '  .labor_group = New LaborGroup(dr, "")
        'Else
        '  If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_group") _
        '  AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_group") Then
        '    .labor_group = New LaborGroup(CInt(dr(aliasPrefix & Me.Prefix & "_group")))
        '  End If
        'End If

        'If Not dr.IsNull(aliasPrefix & "labor_pjmid") Then
        '  .labor_pjmid = CInt(dr(aliasPrefix & "labor_pjmid"))
        'End If

        'If Not dr.IsNull(aliasPrefix & "labor_altName") Then
        '  .labor_alternateName = CStr(dr(aliasPrefix & "labor_altName"))
        'End If

        'If Not dr.IsNull(aliasPrefix & "labor_cost") Then
        '  .labor_cost = CDec(dr(aliasPrefix & "labor_cost"))
        'End If

        'If Not dr.IsNull(aliasPrefix & "labor_costdate") Then
        '  .labor_costdate = CDate(dr(aliasPrefix & "labor_costdate"))
        'End If

        'If Not dr.IsNull(aliasPrefix & "labor_type") Then
        '  .labor_type = CStr(dr(aliasPrefix & "labor_type"))
        'End If

        'If dr.Table.Columns.Contains("unit_id") Then
        '  If Not dr.IsNull("unit_id") Then
        '    '.labor_unit = New Unit(dr, "")
        '    Dim unitId As Integer = CInt(dr("unit_id"))
        '    .labor_unit = Unit.GetUnitById(unitId)
        '  End If
        'Else
        '  If Not dr.IsNull(aliasPrefix & "labor_unit") Then
        '    '.labor_unit = New Unit(CInt(dr(aliasPrefix & "labor_unit")))
        '    Dim unitId As Integer = CInt(dr(aliasPrefix & "labor_unit"))
        '    .labor_unit = Unit.GetUnitById(unitId)
        '  End If
        'End If
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property Name() As String Implements IHasName.Name      Get        Return labor_name      End Get      Set(ByVal Value As String)        labor_name = Value      End Set    End Property    Public Property AlternateName() As String Implements IMultiName.AlternateName      Get        Return labor_alternateName      End Get      Set(ByVal Value As String)        labor_alternateName = Value      End Set    End Property    Public Overridable Property Group() As TreeBaseEntity
      Get
        Return labor_group
      End Get
      Set(ByVal Value As TreeBaseEntity)
        labor_group = CType(Value, LaborGroup)
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Cost() As Decimal      Get
        Return labor_cost
      End Get
      Set(ByVal Value As Decimal)
        labor_cost = Value
      End Set
    End Property    Public Property CostDate() As DateTime      Get
        Return labor_costdate
      End Get
      Set(ByVal Value As DateTime)
        labor_costdate = Value
      End Set
    End Property    Public Property Unit() As Unit
      Get
        If Me.Originated Then
          Return (New Labor(Me.Id).MemoryUnit)
        End If
        Return labor_unit
      End Get
      Set(ByVal Value As Unit)
        'labor_unit = Value
      End Set
    End Property
    Public Property Type() As String
      Get
        Return labor_type
      End Get
      Set(ByVal Value As String)
        labor_type = Value
      End Set
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Labor"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        If Me.Type = "1" Then 'Labor
          Return "${res:Longkong.Pojjaman.BusinessLogic.Labor.DetailLabel}"
        ElseIf Me.Type = "2" Then 'EQ
          Return "${res:Longkong.Pojjaman.BusinessLogic.EqCost.DetailLabel}"
        End If
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        If Me.Type = "1" Then 'Labor
          Return "Icons.16x16.Labor"
        ElseIf Me.Type = "2" Then 'EQ
          Return "Icons.16x16.EqCost"
        End If
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Labor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        If Me.Type = "1" Then 'Labor
          Return "${res:Longkong.Pojjaman.BusinessLogic.Labor.ListLabel}"
        ElseIf Me.Type = "2" Then 'EQ
          Return "${res:Longkong.Pojjaman.BusinessLogic.EqCost.ListLabel}"
        End If
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "labor"
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
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("EquipmentCost")
      myDatatable.Columns.Add(New DataColumn("lcil_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("lcil_labor", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Group", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Cost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("lcil_note", GetType(String)))
      Dim dateCol As New DataColumn("CostDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)
      Return myDatatable
    End Function
    Public Shared Function GetLCISchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("LciList")
      myDatatable.Columns.Add(New DataColumn("lcil_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      Return myDatatable
    End Function
    Public Function GetLCIListTable() As TreeTable
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString, CommandType.StoredProcedure, "GetLaborLCIList", _
      New SqlParameter("@labor_id", Me.Id) _
      , New SqlParameter("@labor_type", Me.Type))
      Dim tt As TreeTable = GetLCISchemaTable()
      Dim i As Integer = 0
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim tr As TreeRow = tt.Childs.Add
        tr("lcil_linenumber") = i
        tr("Code") = row("Code")
        tr("Name") = row("Name")
      Next
      Return tt
    End Function
#End Region

#Region "Methods"
    Public Function CheckUnitBeforeSaving() As String
      Dim dt As DataTable = GetRefUnitTable()
      If dt Is Nothing Then
        Return ""
      End If
      For Each row As DataRow In dt.Rows
        Dim refUnit As New Unit(CInt(row("unit_id")))
        If Me.MemoryUnit.Id <> refUnit.Id Then
          Return "ต้องมีหน่วยนับ " & refUnit.Name & " เท่านั้น เนื่องจากมีการอ้างอิงไปยังเอกสารอื่นแล้ว"
        End If
      Next
      Return ""
    End Function
    Public Function GetRefUnitTable() As DataTable
      If Not Me.Originated Then
        Return Nothing
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "GetRefUnitForLabor", _
      New SqlParameter("@labor_id", Me.Id))
      Return ds.Tables(0)
    End Function
    Public Function GetLCITable() As DataTable
      Dim dt As New DataTable

    End Function
    Public Overrides Function ToString() As String
      Return labor_name
    End Function

    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim unitError As String = CheckUnitBeforeSaving()
      If Not unitError Is Nothing AndAlso unitError.Length > 0 Then
        Return New SaveErrorException(unitError)
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
        paramArrayList.Add(New SqlParameter("@Labor_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      paramArrayList.Add(New SqlParameter("@Labor_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@Labor_name", Me.Name))
      paramArrayList.Add(New SqlParameter("@Labor_altname", Me.AlternateName))
      paramArrayList.Add(New SqlParameter("@Labor_cost", Me.Cost))
      paramArrayList.Add(New SqlParameter("@Labor_costdate", IIf(Me.CostDate.Equals(Date.MinValue), DBNull.Value, Me.CostDate)))
      paramArrayList.Add(New SqlParameter("@Labor_unit", Me.MemoryUnit.Id))
      paramArrayList.Add(New SqlParameter("@Labor_group", Me.Group.Id))
      paramArrayList.Add(New SqlParameter("@Labor_type", Me.Type))
      paramArrayList.Add(New SqlParameter("@Labor_pjmid", Me.PJMID))

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
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try


    End Function

#End Region

#Region "IPJMUpdatable"

    Public Property PJMID() As Integer Implements IPJMUpdatable.PJMID
      Get
        Return labor_pjmid
      End Get
      Set(ByVal Value As Integer)
        labor_pjmid = Value
      End Set
    End Property
#End Region

#Region "IHasUnit"
    Public Property DefaultUnit() As Unit Implements IHasUnit.DefaultUnit
      Get
        Return Me.Unit
      End Get
      Set(ByVal Value As Unit)
        Me.Unit = Value
      End Set
    End Property
    Public Property MemoryUnit() As Unit Implements IHasUnit.MemoryUnit
      Get
        Return Me.labor_unit
      End Get
      Set(ByVal Value As Unit)
        Me.labor_unit = Value
      End Set
    End Property
#End Region

#Region "IHasPrice"
    Public Property Price() As Decimal Implements IHasPrice.Price
      Get
        Return Me.Cost
      End Get
      Set(ByVal Value As Decimal)
        Me.Cost = Value
      End Set
    End Property
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteLabor}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteLabor", New SqlParameter() {New SqlParameter("@labor_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.LaborIsReferencedCannotBeDeleted}")
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

  Public Class LaborGroup
    Inherits TreeBaseEntity

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As LaborGroup)
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
        Return "laborg"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "LaborGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.LaborGroup.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.LaborGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.LaborGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.LaborGroup.ListLabel}"
      End Get
    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New LaborGroup(parId)
      Else
        Me.Parent = Me
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New LaborGroup
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
          paramArrayList.Add(New SqlParameter("@laborg_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@laborg_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@laborg_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@laborg_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@laborg_parid", parID))
        paramArrayList.Add(New SqlParameter("@laborg_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@laborg_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@laborg_control", Me.IsControlGroup))

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
    Public Shared Function GetLaborGroup(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldGroup As LaborGroup, Optional ByVal allowParent As Boolean = False) As Boolean
      Dim group As New LaborGroup(txtCode.Text)
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteLaborGroup}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteLaborGroup", New SqlParameter() {New SqlParameter("@laborg_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.LaborGroupIsReferencedCannotBeDeleted}")
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
