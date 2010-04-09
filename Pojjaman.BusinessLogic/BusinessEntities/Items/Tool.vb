Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.ComponentModel
Imports System.Configuration
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class Tool
        Inherits SimpleBusinessEntityBase
    Implements IHasRentalRate, IHasImage, IHasUnit, IHasPrice, IHasGroup, IEqtItem

#Region "Members"
        Private tool_name As String
        Private tool_group As ToolGroup
        Private tool_unit As Unit
    Private m_qty As Integer
    Private tool_fairprice As Decimal
    Private tool_rentalrate As Decimal
    Private m_cc As CostCenter

        Private m_image As Image
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.tool_group = New ToolGroup
            Me.tool_unit = New Unit
        End Sub
        Public Sub New(ByVal toolCode As String)
            MyBase.New(toolCode)
        End Sub
        Public Sub New(ByVal toolId As Integer)
            MyBase.New(toolId)
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

        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)

            With Me

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .tool_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "toolg_id") _
                AndAlso Not dr.IsNull(aliasPrefix & "toolg_id") Then
                    .tool_group = New ToolGroup(dr, "")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_group") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_group") Then
                        .tool_group = New ToolGroup(CInt(dr(aliasPrefix & Me.Prefix & "_group")))
                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & "unit_id") _
                AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
                    .tool_unit = New Unit(dr, "")
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_unit") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_unit") Then
                        .tool_unit = New Unit(CInt(dr(aliasPrefix & Me.Prefix & "_unit")))
                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_fairprice") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_fairprice") Then
                    .tool_fairprice = CDec(dr(aliasPrefix & Me.Prefix & "_fairprice"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_rentalrate") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_rentalrate") Then
                    .tool_rentalrate = CDec(dr(aliasPrefix & Me.Prefix & "_rentalrate"))
                End If
            End With
            LoadImage()
        End Sub
        Public Sub LoadImage()
            If Id <= 0 Then
                Return
            End If

            Dim sqlConString As String = Me.RealConnectionString
            Dim conn As New SqlConnection(sqlConString)
            Dim sql As String = "select tool_image from toolimage where tool_id = " & Me.Id

            conn.Open()

            Dim cmd As SqlCommand = conn.CreateCommand
            cmd.CommandText = sql

            Dim custReader As SqlDataReader = cmd.ExecuteReader((CommandBehavior.KeyInfo Or CommandBehavior.CloseConnection))
            If custReader.Read Then
                LoadImage(custReader)
            End If
        End Sub
        Public Sub LoadImage(ByVal reader As IDataReader)
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            m_image = Field.GetImage(reader, "tool_image")
            Try
                If Image Is Nothing Then
                    m_image = Image.FromFile(myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Entity.BlankImage}"))
                End If
            Catch ex As Exception

            End Try
        End Sub
#End Region

#Region "Properties"
        Public Property Unit() As Unit
            Get
                If Me.Originated Then
                    Return (New Tool(Id)).MemoryUnit
                End If
                Return tool_unit
            End Get
            Set(ByVal Value As Unit)
                'tool_unit = Value
            End Set
    End Property
    Public Property Qty() As Integer
      Get
        Return m_qty
      End Get
      Set(ByVal Value As Integer)
        m_qty = Value
      End Set
    End Property
    Public Property Costcenter As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal value As CostCenter)
        m_cc = value
      End Set
    End Property
        Public Property Name() As String Implements IHasName.Name            Get
                Return tool_name
            End Get
            Set(ByVal Value As String)
                tool_name = Value
                OnPropertyChanged(Me, New PropertyChangedEventArgs)
            End Set
        End Property
        Public Property RentalRate() As Decimal Implements IHasRentalRate.RentalRate
            Get
                Return tool_rentalrate
            End Get
            Set(ByVal Value As Decimal)
                tool_rentalrate = Value
            End Set
        End Property
        Public Property Group() As ToolGroup
            Get
                Return tool_group
            End Get
            Set(ByVal Value As ToolGroup)
                tool_group = Value
                OnPropertyChanged(Me, New PropertyChangedEventArgs)
            End Set
        End Property

        Public Property FairPrice() As Decimal
            Get
                Return tool_fairprice
            End Get
            Set(ByVal Value As Decimal)
                tool_fairprice = Value
            End Set
        End Property

        Public Property Image() As System.Drawing.Image Implements IHasImage.Image
            Get
                Return m_image
            End Get
            Set(ByVal Value As System.Drawing.Image)
                m_image = Value
            End Set
        End Property

        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Tool"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Tool.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Tool"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Tool"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "tool"
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
                Return "${res:Longkong.Pojjaman.BusinessLogic.Tool.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property UseSiteConnString() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

#Region "Shared"
        Public Shared Function GetTool(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldTool As Tool) As Boolean
            Dim myTool As New Tool(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not myTool.Originated Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                myTool = oldTool
            End If
            txtCode.Text = myTool.Code
            txtName.Text = myTool.Name
            If oldTool.Id <> myTool.Id Then
                oldTool = myTool
                Return True
            End If
            Return False
        End Function
        Public Shared Function GetAvailabilityInCC(ByVal filters As Filter()) As DataTable
            'GetRemainToolListForCC
            Dim params() As SqlParameter
            If Not filters Is Nothing AndAlso filters.Length > 0 Then
                ReDim params(filters.Length - 1)
                For i As Integer = 0 To filters.Length - 1
                    params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
                Next
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetRemainToolListForCC", params)
            Return ds.Tables(0)
        End Function
#End Region

#Region "Method"
        Public Function GetLastWithdrawSequence() As Integer
            Try
                Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
                Dim ds As DataSet

                ds = SqlHelper.ExecuteDataset(sqlConString _
                , CommandType.StoredProcedure _
                , "GetLastToolWithdrawSequenceWithNoReturn" _
                , New SqlParameter("@tool_id", Me.Id))

                If ds.Tables(0).Rows.Count > 0 AndAlso IsNumeric(ds.Tables(0).Rows(0)(0)) Then
                    Return CInt(ds.Tables(0).Rows(0)(0))
                End If
            Catch ex As Exception
            End Try
            Return 0
        End Function
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
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString, CommandType.StoredProcedure, "GetRefUnitForTool", _
            New SqlParameter("@tool_id", Me.Id))
            Return ds.Tables(0)
        End Function
        Public Overrides Function ToString() As String
            Return tool_name
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
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_group", Me.Group.Id))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_unit", Me.MemoryUnit.Id))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fairprice", Me.FairPrice))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_rentalrate", Me.RentalRate))

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
                ' Save Image process 
                'If Not Me.Image Is Nothing Then
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertToolimage" _
                , New SqlParameter("@tool_id", Me.Id) _
                , New SqlParameter("@tool_image", Pojjaman.Graphix.Imaging.ConvertImageToByteArray(Me.Image)))
                'End If

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
                Return Me.tool_unit
            End Get
            Set(ByVal Value As Unit)
                Me.tool_unit = Value
            End Set
        End Property
#End Region

#Region "IHasPrice"
        Public Property Price() As Decimal Implements IHasPrice.Price
            Get
                Return Me.FairPrice
            End Get
            Set(ByVal Value As Decimal)
                Me.FairPrice = Value
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteTool}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteTool", New SqlParameter() {New SqlParameter("@tool_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.ToolIsReferencedCannotBeDeleted}")
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

        Public ReadOnly Property GroupForCode() As ISimpleEntity Implements IHasGroup.Group
            Get
                Return Me.tool_group
            End Get
        End Property
    End Class
    'TODO : เหน่งกลับมาทำ ToolGroup ด้วยนะครับ
    Public Class ToolGroup
        Inherits TreeBaseEntity

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal myParent As ToolGroup)
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
                Return "toolg"
            End Get
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "ToolGroup"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.ToolGroup.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.ToolGroup"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.ToolGroup"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.ToolGroup.ListLabel}"
            End Get
        End Property
#End Region

#Region "Methods"
        Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
            If parId <> Id Then
                Me.Parent = New ToolGroup(parId)
            Else
                Me.Parent = Nothing
            End If
        End Sub
        Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
            Dim par As New ToolGroup
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
                    paramArrayList.Add(New SqlParameter("@toolg_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                If Me.AutoGen And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                Me.AutoGen = False

                paramArrayList.Add(New SqlParameter("@toolg_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@toolg_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@toolg_altname", Me.AlternateName))
                paramArrayList.Add(New SqlParameter("@toolg_parid", parID))
                paramArrayList.Add(New SqlParameter("@toolg_level", Me.Level))
                paramArrayList.Add(New SqlParameter("@toolg_path", Me.Path))
                paramArrayList.Add(New SqlParameter("@toolg_control", Me.IsControlGroup))

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
        Public Shared Function GetToolGroup(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldGroup As ToolGroup) As Boolean
            Dim group As New ToolGroup(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not group.Valid Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                group = oldGroup
            ElseIf group.IsControlGroup Then
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
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteToolGroup}", format) Then
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
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteToolGroup", New SqlParameter() {New SqlParameter("@toolg_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.ToolGroupIsReferencedCannotBeDeleted}")
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
    Public Class ToolForSelection
        Inherits Tool
        Public CC As New CostCenter
        Public FromWip As Boolean = False

        Public Overrides ReadOnly Property CodonName() As String
            Get
                Return "ToolForSelection"
            End Get
        End Property
  End Class

End Namespace

