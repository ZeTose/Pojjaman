Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class CBSValue
        Public Property Week As Week
        Public Property Budget As Decimal
        Public Property Amount As Decimal
    End Class
    Public Class CBS
        Inherits TreeBaseEntity
        Implements IControlItem

#Region "Member"
        Private m_note As String
        Private m_acct As Account
        Private Shared m_idCBSHash As Hashtable
        Private Shared m_codeCBSHash As Hashtable
        Private Shared m_cbsSet As DataTable
        Private m_Referenced As Boolean
#End Region

#Region "Shared"

        Public Shared ReadOnly Property Count As Integer
            Get
                Return 0
            End Get
        End Property
        Private Shared CBSIdList As Dictionary(Of Integer, CBS)
        Private Shared CBSCodeList As Dictionary(Of String, CBS)

        Private Shared m_tree As List(Of CBS)
        Public Shared ReadOnly Property CBSTree As List(Of CBS)
            Get
                If m_tree Is Nothing Then
                    RefreshTree()
                End If
                Return m_tree
            End Get
        End Property
        Public Shared Sub RefreshTree()
            m_tree = New List(Of CBS)
            CBSIdList = New Dictionary(Of Integer, CBS)
            CBSCodeList = New Dictionary(Of String, CBS)
            Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetCBSTree" _
            )
            m_idCBSHash = New Hashtable
            m_codeCBSHash = New Hashtable
            Dim parentList As New Dictionary(Of Integer, CBS)
            Dim orphans As New List(Of CBS) 'ลูกกำพร้า
            For Each row As DataRow In ds.Tables(0).Rows
                Dim c As New CBS(row, "")
                parentList.Add(c.Id, c)
                If Not c.ParentId.HasValue OrElse c.ParentId.Value = c.Id Then
                    m_tree.Add(c)
                Else
                    Dim tryParent As CBS = Nothing
                    If parentList.TryGetValue(c.ParentId.Value, tryParent) _
                    AndAlso tryParent IsNot Nothing Then
                        'TODO: จริงๆไม่น่าจะต้องเช็ค nothing อีกนะ ว่างๆลองดูหน่อย
                        tryParent.Childs.Add(c)
                        c.Parent = tryParent
                    Else
                        orphans.Add(c)
                    End If
                End If
                CBSIdList.Add(c.Id, c)
                CBSCodeList.Add(c.Code, c)

                m_idCBSHash(c.Id) = c
                m_codeCBSHash(c.Code.ToLower) = c
            Next
            m_tree.AddRange(orphans)
        End Sub
        Public Shared Function GetById(ByVal idToFind As Integer) As CBS
            Dim c As CBS = Nothing
            If CBSIdList Is Nothing Then
                RefreshTree()
            End If
            If CBSIdList.TryGetValue(idToFind, c) Then
                Return c
            End If
            Return New CBS
        End Function
        Public Shared Function GetByCode(ByVal codeToFind As String) As CBS
            Dim c As CBS = Nothing
            If CBSCodeList Is Nothing Then
                RefreshTree()
            End If
            For Each kv As KeyValuePair(Of String, CBS) In CBSCodeList
                If kv.Key.ToLower = codeToFind.ToLower Then
                    Return kv.Value
                End If
            Next
            Return New CBS
        End Function
#End Region

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                If Me.Originated Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("${res:Global.Error.NoIdError}")
            End If
            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteCBS}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                ''--------------------------Delete EXTENDERS---------------------
                'For Each extender As Object In Me.Extenders
                '  If TypeOf extender Is IExtender Then
                '    Dim deleteDetailError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
                '    If Not IsNumeric(deleteDetailError.Message) Then
                '      trans.Rollback()
                '      Return deleteDetailError
                '    Else
                '      Select Case CInt(deleteDetailError.Message)
                '        Case -1, -2, -5
                '          trans.Rollback()
                '          Return deleteDetailError
                '        Case Else
                '      End Select
                '    End If
                '  End If
                'Next
                '--------------------------Delete SAVING EXTENDERS---------------------

                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteCBS", New SqlParameter() {New SqlParameter("@cbs_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.CBSIsReferencedCannotBeDeleted}")
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If

                ''------------------------- อย่าลืม ทำลายทิ้งด้วยนะ -----------------------------
                'CostCenter.DestroyCachCC()
                ''------------------------- อย่าลืม ทำลายทิ้งด้วยนะ -----------------------------

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

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Shared Sub New()
            RefreshEntityTable()
        End Sub
        Public Shared Sub RefreshEntityTable()
            Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
            , CommandType.StoredProcedure _
            , "GetCBS" _
            )
            m_idCBSHash = New Hashtable
            m_codeCBSHash = New Hashtable
            m_cbsSet = New DataTable
            Dim myTable As DataTable = ds.Tables(0)
            m_cbsSet = SetCBSSet(ds.Tables(0))
            For Each row As DataRow In myTable.Rows
                Dim cb As New CBS
                cb.Construct(row, "")
                m_idCBSHash(cb.Id) = cb
                m_codeCBSHash(cb.Code.ToLower) = cb
            Next
        End Sub
        Public Sub New(ByVal myParent As CBS)
            MyBase.New(myParent)
        End Sub
        Public Sub New(ByVal id As Integer)
            'MyBase.New(id)
            If id = 0 Then
                Return
            End If
            If m_idCBSHash Is Nothing Then
                RefreshEntityTable()
            End If
            Dim cb As CBS = CType(m_idCBSHash(id), CBS)
            If Not cb Is Nothing Then
                Me.Clone(cb)
            End If
        End Sub
        Public Sub New(ByVal code As String)
            'MyBase.New(code)
            If code = "" Then
                Return
            End If
            If m_codeCBSHash Is Nothing Then
                RefreshEntityTable()
            End If
            Dim cb As CBS = CType(m_codeCBSHash(code.ToLower), CBS)
            If Not cb Is Nothing Then
                Me.Clone(cb)
            End If
        End Sub
        Private Sub Clone(ByVal cb As CBS)
            Me.AlternateName = cb.AlternateName
            Me.AutoGen = cb.AutoGen
            Me.CancelDate = cb.CancelDate
            Me.Canceled = cb.Canceled
            Me.CancelPerson = cb.CancelPerson
            Me.Code = cb.Code
            Me.Edited = cb.Edited
            Me.Id = cb.Id
            Me.IsControlGroup = cb.IsControlGroup
            Me.IsDirty = cb.IsDirty
            Me.IsInitialized = cb.IsInitialized
            Me.LastEditDate = cb.LastEditDate
            Me.LastEditor = cb.LastEditor
            Me.Level = cb.Level
            Me.Name = cb.Name
            Me.NoSaveMessage = cb.NoSaveMessage
            Me.Originator = cb.Originator
            Me.OriginDate = cb.OriginDate
            Me.Parent = cb.Parent
            Me.Path = cb.Path
            Me.Note = cb.Note
            Me.Acct = cb.Acct
            Me.Status = cb.Status
            Me.Referenced = cb.Referenced
            ' Me.Type = cb.Type
        End Sub

        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)

            Dim drh As New DataRowHelper(dr)
            Note = drh.GetValue(Of String)("cbs_note")
            m_acct = New Account(drh.GetValue(Of String)("cbs_acct"))
            m_Referenced = drh.GetValue(Of Boolean)("referenced")
        End Sub
#End Region

#Region "Properties"
        'Public Overrides Property Parent As TreeBaseEntity
        '    Get
        '        Return MyBase.Parent
        '    End Get
        '    Set(ByVal value As TreeBaseEntity)
        '        MyBase.Parent = value
        '    End Set
        'End Property
        Public Property Referenced As Boolean
            Get
                Return m_Referenced
            End Get
            Set(ByVal value As Boolean)
                m_Referenced = value
            End Set
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "cbs"
            End Get
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "CBS"
            End Get
        End Property
        Public Overrides ReadOnly Property CodonName() As String
            Get
                Return "CBS"
            End Get
        End Property
        Public Overrides ReadOnly Property [NameSpace]() As String
            Get
                Return "Longkong.Pojjaman.BusinessLogic"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CBS.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.CBS"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.CBS"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.CBS.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property UseSiteConnString() As Boolean
            Get
                Return True
            End Get
        End Property
#Region "Methods"
        Private Shared Function SetCBSSet(ByVal dsSource As DataTable) As DataTable
            Dim dt As New DataTable
            dt.Columns.Add("cbs_id")
            dt.Columns.Add("cbs_code")
            dt.Columns.Add("cbs_name")

            For Each row As DataRow In dsSource.Rows
                Dim drh As New DataRowHelper(row)
                If drh.GetValue(Of Integer)("cbs_id") > 0 Then
                    Dim dr As DataRow = dt.NewRow()
                    dr("cbs_id") = drh.GetValue(Of String)("cbs_id")
                    dr("cbs_code") = drh.GetValue(Of String)("cbs_code")
                    dr("cbs_name") = drh.GetValue(Of String)("cbs_name")
                    dt.Rows.Add(dr)
                End If
            Next
            Return dt
        End Function
        Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
            If parId <> Id Then
                Me.Parent = New CBS(parId)
            Else
                Me.Parent = Nothing
            End If
        End Sub
        Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
            Dim parCBS As New CBS
            parCBS.Id = id
            parCBS.Code = code
            parCBS.Name = name
            Me.Parent = parCBS
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            With Me
                'If Me.Type Is Nothing OrElse Me.Type.Value < 0 Then
                '    Account.RefreshEntityTable()
                '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoAccountType}"))
                'End If
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
                    paramArrayList.Add(New SqlParameter("@cbs_id", Me.Id))
                End If

                Dim theTime As Date = Now
                Dim theUser As New User(currentUserId)

                paramArrayList.Add(New SqlParameter("@cbs_code", Me.Code))
                paramArrayList.Add(New SqlParameter("@cbs_name", Me.Name))
                paramArrayList.Add(New SqlParameter("@cbs_altname", Me.AlternateName))
                paramArrayList.Add(New SqlParameter("@cbs_parid", parID))
                paramArrayList.Add(New SqlParameter("@cbs_level", Me.Level))
                paramArrayList.Add(New SqlParameter("@cbs_path", Me.Path))
                paramArrayList.Add(New SqlParameter("@cbs_control", Me.IsControlGroup))
                paramArrayList.Add(New SqlParameter("@cbs_note", Me.Note))
                paramArrayList.Add(New SqlParameter("@cbs_acct", Me.Acct))

                SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

                ' สร้าง SqlParameter จาก ArrayList ...
                Dim sqlparams() As SqlParameter
                sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

                Dim trans As SqlTransaction
                Dim conn As New SqlConnection(Me.ConnectionString)

                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Open()
                trans = conn.BeginTransaction()
                Dim oldid As Integer = Me.Id
                Try
                    Try
                        'Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
                        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)

                        '--------------------------SAVING EXTENDERS---------------------
                        For Each extender As Object In Me.Extenders
                            If TypeOf extender Is IExtender Then
                                Dim saveDetailError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
                                If Not IsNumeric(saveDetailError.Message) Then
                                    trans.Rollback()
                                    ResetID(oldid)
                                    'CBS.RefreshEntityTable()
                                    Return saveDetailError
                                Else
                                    Select Case CInt(saveDetailError.Message)
                                        Case -1, -2, -5
                                            trans.Rollback()
                                            ResetID(oldid)
                                            'CBS.RefreshEntityTable()
                                            Return saveDetailError
                                        Case Else
                                    End Select
                                End If
                            End If
                        Next
                        '--------------------------END SAVING EXTENDERS---------------------
                        trans.Commit()

                        ' ตรวจจับ Error ของการ Save ...
                        'CBS.RefreshEntityTable()
                        'Return New SaveErrorException(returnVal.Value.ToString)
                    Catch ex As Exception
                        trans.Rollback()
                        Me.ResetID(oldid)
                        'CBS.RefreshEntityTable()
                        Return New SaveErrorException(ex.ToString)
                    End Try

                    '--Sub Save Block-- ============================================================
                    Try
                        Dim subsaveerror As SaveErrorException = SubSave(conn)
                        If Not IsNumeric(subsaveerror.Message) Then
                            Return New SaveErrorException(" Save Incomplete Please Save Again")
                        End If
                        Return New SaveErrorException("0")
                        'Complete Save
                    Catch ex As Exception
                        Return New SaveErrorException(ex.ToString)
                    End Try
                    '--Sub Save Block-- ============================================================

                Catch ex As Exception
                    Return New SaveErrorException(ex.ToString)
                Finally
                    conn.Close()
                End Try

            End With
        End Function
        Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

            '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
            Dim trans As SqlTransaction = conn.BeginTransaction

            Try
                CBS.RefreshEntityTable()
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.ToString)
            End Try

            trans.Commit()
            Return New SaveErrorException("0")
        End Function
        Private Sub ResetID(ByVal oldid As Integer)
            Me.Id = oldid
        End Sub
#End Region
        Public ReadOnly Property IdOrNull As Nullable(Of Integer)
            Get
                Dim ret As Nullable(Of Integer) = Nothing
                If Id <> 0 Then
                    ret = Id
                End If
                Return ret
            End Get
        End Property
        Public Property Note As String
        Public Property ParentId As Nullable(Of Integer)
        Public Property Acct As Account

        Private m_childs As List(Of CBS)

        Public ReadOnly Property Childs As List(Of CBS)
            Get
                If m_childs Is Nothing Then
                    m_childs = New List(Of CBS)
                End If
                Return m_childs
            End Get
        End Property
#End Region

#Region "Method"

      Private m_plan As List(Of CBSValue)
      Public Function GetPlannedValue(ByVal boqId As Integer) As Decimal
         Dim ret As Decimal = 0
         For Each p As CBSValue In Plan(boqId)
            ret += p.Amount
         Next
         Return ret
      End Function
      Public Function Plan(ByVal boqId As Integer) As List(Of CBSValue)
         RefreshPlan(boqId)
         Return m_plan
      End Function
      Private m_CachedPlanDataTables As Dictionary(Of Integer, DataTable)
      Private ReadOnly Property CachedPlanDataTables As Dictionary(Of Integer, DataTable)
         Get
            If m_CachedPlanDataTables Is Nothing Then
               m_CachedPlanDataTables = New Dictionary(Of Integer, DataTable)
            End If
            Return m_CachedPlanDataTables
         End Get
      End Property
      Private Sub RefreshPlan(ByVal boqId As Integer)
         m_plan = New List(Of CBSValue)
         If boqId <> 0 Then

            If Not CachedPlanDataTables.ContainsKey(boqId) Then
               Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
               Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
               , CommandType.Text _
               , "SELECT cbs_id,year,month,number,sum(wbs_amount) [Budget],SUM(amount) [amount] " & _
     " FROM wbs " & _
     " INNER JOIN cbs ON cbs_id = wbs_cbs" & _
     " INNER JOIN plans ON plan_wbs = wbs_id" & _
     " WHERE wbs_boq = 11" & _
     " GROUP BY cbs_id,year,month,number" _
               )
               Dim dt As DataTable = ds.Tables(0)
               CachedPlanDataTables(boqId) = dt
            End If
            For Each dr As DataRow In CachedPlanDataTables(boqId).Select("cbs_id = " & Me.Id.ToString)
               Dim deh As New DataRowHelper(dr)
               Dim y As Integer = deh.GetValue(Of Integer)("year")
               Dim m As Integer = deh.GetValue(Of Integer)("month")
               Dim n As Integer = deh.GetValue(Of Integer)("number")
               Dim amount As Decimal = deh.GetValue(Of Decimal)("amount")
               Dim budget As Decimal = deh.GetValue(Of Decimal)("budget")
               Dim cbv As New CBSValue
               cbv.Amount = amount
               cbv.Budget = budget
               cbv.Week = New Week(n, m, y)
               m_plan.Add(cbv)
            Next
         End If
      End Sub

      Public ReadOnly Property ControlMessage As String Implements IControlItem.ControlMessage
         Get
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim myString As String = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CBS.ControlMessage}")   '"ไม่สามารถเลือก CBS " + Me.Code + " - " + Me.Name + " เนื่องจากเป็น CBS คุม"
            myString = String.Format(myString, Me.Code + " - " + Me.Name)
            Return myString
         End Get
      End Property
#End Region
       
    End Class

    Public Class WorkBreakdownStructure

#Region "Constructors"
        Public Sub New()
            Unit = New Unit
            CBS = New CBS
            Me.PlannedStartDate = Now
            Me.PlannedFinishDate = Now
            Me.StartDate = Now
            Me.FinishDate = Now
        End Sub
        Public Sub New(ByVal dr As DataRow)
            Dim dh As New DataRowHelper(dr)
            Id = dh.GetValue(Of Integer)("wbs_id")
            Code = dh.GetValue(Of String)("wbs_code")
            Name = dh.GetValue(Of String)("wbs_name")
            AlternateName = dh.GetValue(Of String)("wbs_altname")
            Note = dh.GetValue(Of String)("wbs_note")
            StatusId = dh.GetValue(Of Integer)("wbs_status")
            m_qty = dh.GetValue(Of Decimal)("wbs_qty")
            m_unitPrice = dh.GetValue(Of Decimal)("wbs_unitprice")
            m_amount = dh.GetValue(Of Decimal)("wbs_amount")
            PlannedStartDate = dh.GetValue(Of Date)("wbs_startdate")
            PlannedFinishDate = dh.GetValue(Of Date)("wbs_finishdate")
            StartDate = dh.GetValue(Of Date)("wbs_realstartdate")
            FinishDate = dh.GetValue(Of Date)("wbs_realfinishdate")

            ParentId = dh.GetValue(Of Integer)("wbs_parid")
            BOQId = dh.GetValue(Of Integer)("wbs_boq")
            Dim unitId As Integer = dh.GetValue(Of Integer)("wbs_unit", 0)
            Unit = New Unit(unitId)

            Dim cbsId As Integer = dh.GetValue(Of Integer)("wbs_cbs", 0)
            CBS = CBS.GetById(cbsId)

            Me.State = CType([Enum].Parse(GetType(RowExpandState), dh.GetValue(Of String)("wbs_state", "1")), RowExpandState)
        End Sub
#End Region

#Region "Properties"
        Public Property Id As Integer
        Public Property Code As String
        Public Property Name As String
        Public Property AlternateName As String
        Public Property Note As String
        Public Property StatusId As Nullable(Of Integer)
        Public Property ParentId As Nullable(Of Integer)
        Public Property Unit As Unit
        Public Property State As RowExpandState = RowExpandState.Expanded
        Public Property BOQId As Integer
        Private m_plan As Dictionary(Of Week, Decimal)
        Public Function GetPlannedValue() As Decimal
            Dim ret As Decimal = 0
            For Each p As KeyValuePair(Of Week, Decimal) In Plan
                ret += p.Value
            Next
            Return ret
        End Function
        Public ReadOnly Property Plan As Dictionary(Of Week, Decimal)
            Get
                If m_plan Is Nothing Then
                    RefreshPlan()
                End If
                Return m_plan
            End Get
        End Property
        Private m_CachedPlanDataTables As Dictionary(Of Integer, DataTable)
        Private ReadOnly Property CachedPlanDataTables As Dictionary(Of Integer, DataTable)
            Get
                If m_CachedPlanDataTables Is Nothing Then
                    m_CachedPlanDataTables = New Dictionary(Of Integer, DataTable)
                End If
                Return m_CachedPlanDataTables
            End Get
        End Property
        Private Sub RefreshPlan()
            m_plan = New Dictionary(Of Week, Decimal)
            If BOQId <> 0 Then

                If Not CachedPlanDataTables.ContainsKey(BOQId) Then
                    Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
                    Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
                    , CommandType.Text _
                    , "select wbs_id,plans.* from plans inner join wbs on wbs_id = plan_wbs where wbs_boq =" & BOQId.ToString & " order by wbs_id,[year],[month],[number]" _
                    )
                    Dim dt As DataTable = ds.Tables(0)
                    CachedPlanDataTables(BOQId) = dt
                End If
                For Each dr As DataRow In CachedPlanDataTables(BOQId).Select("wbs_id = " & Me.Id.ToString)
                    Dim deh As New DataRowHelper(dr)
                    Dim y As Integer = deh.GetValue(Of Integer)("year")
                    Dim m As Integer = deh.GetValue(Of Integer)("month")
                    Dim n As Integer = deh.GetValue(Of Integer)("number")
                    Dim amount As Decimal = deh.GetValue(Of Decimal)("amount")
                    m_plan(New Week(n, m, y)) = amount
                Next
            End If
        End Sub
        Public Property CBS As CBS
        Private m_qty As Nullable(Of Decimal) = Nothing
        Public Property Qty As Nullable(Of Decimal)
            Get
                Return m_qty
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                m_qty = value
                If m_unitPrice.HasValue AndAlso m_qty.HasValue Then
                    m_amount = m_unitPrice.Value * m_qty.Value
                End If
            End Set
        End Property
        Private m_unitPrice As Nullable(Of Decimal) = Nothing
        Public Property UnitPrice As Nullable(Of Decimal)
            Get
                Return m_unitPrice
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                m_unitPrice = value
                If m_unitPrice.HasValue AndAlso m_qty.HasValue Then
                    m_amount = m_unitPrice.Value * m_qty.Value
                End If
            End Set
        End Property
        Private m_amount As Decimal = 0
        Public Property Amount As Decimal
            Get
                Return m_amount
            End Get
            Set(ByVal value As Decimal)
                m_amount = value
                If Qty.HasValue AndAlso Qty.Value <> 0 Then
                    m_unitPrice = m_amount / Qty.Value
                Else
                    m_unitPrice = Nothing
                End If
            End Set
        End Property
        Public ReadOnly Property Budget As Decimal
            Get
                Dim ret As Decimal = Me.Amount
                For Each child As WorkBreakdownStructure In Me.Childs
                    ret += child.Budget
                Next
                Return ret
            End Get
        End Property
        Public Property PlannedStartDate As Nullable(Of Date)
        Public Property PlannedFinishDate As Nullable(Of Date)

        Public Property StartDate As Nullable(Of Date)
        Public Property FinishDate As Nullable(Of Date)

        Public Property Boq As BOQ
        Public Property Parent As WorkBreakdownStructure
        Public ReadOnly Property Level As Integer
            Get
                If Parent Is Nothing Then
                    Return 0
                End If
                Return Me.Parent.Level + 1
            End Get
        End Property
        Private m_childs As List(Of WorkBreakdownStructure)
        Public ReadOnly Property Childs As List(Of WorkBreakdownStructure)
            Get
                If m_childs Is Nothing Then
                    m_childs = New List(Of WorkBreakdownStructure)
                End If
                Return m_childs
            End Get
        End Property
#End Region

#Region "Shared"
        Public Shared Sub GetBoqChilds(ByVal budget As Budget)
            If budget Is Nothing Then
                Return
            End If
            budget.Childs = New List(Of WorkBreakdownStructure)

            Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
            , CommandType.StoredProcedure _
            , "GetWorkBreakdownStructures" _
            , New SqlParameter("@boq_id", budget.Id) _
            )
            budget.ChildrenCount = ds.Tables(0).Rows.Count
            Dim parentList As New Dictionary(Of Integer, WorkBreakdownStructure)
            Dim orphans As New List(Of WorkBreakdownStructure) 'ลูกกำพร้า
            For Each row As DataRow In ds.Tables(0).Rows
                Dim w As New WorkBreakdownStructure(row)
                parentList.Add(w.Id, w)
                If Not w.ParentId.HasValue OrElse w.ParentId.Value = w.Id Then
                    budget.Childs.Add(w)
                Else
                    Dim tryParent As WorkBreakdownStructure = Nothing
                    If parentList.TryGetValue(w.ParentId.Value, tryParent) _
                    AndAlso tryParent IsNot Nothing Then
                        'TODO: จริงๆไม่น่าจะต้องเช็ค nothing อีกนะ ว่างๆลองดูหน่อย
                        tryParent.Childs.Add(w)
                        w.Parent = tryParent
                    Else
                        orphans.Add(w)
                    End If
                End If
            Next
            budget.Childs.AddRange(orphans)
        End Sub
#End Region
        Public Sub UpdatePlan()
            Try
                Dim planstodelete As New List(Of KeyValuePair(Of Week, Decimal))
                For Each p As KeyValuePair(Of Week, Decimal) In Me.Plan
                    If p.Key.Year < StartDate.Value.Year Then
                        planstodelete.Add(p)
                    ElseIf p.Key.Year = StartDate.Value.Year AndAlso p.Key.Month < StartDate.Value.Month Then
                        planstodelete.Add(p)
                    End If
                    If p.Key.Year > FinishDate.Value.Year Then
                        planstodelete.Add(p)
                    ElseIf p.Key.Year = FinishDate.Value.Year AndAlso p.Key.Month > FinishDate.Value.Month Then
                        planstodelete.Add(p)
                    End If
                Next
                For Each p As KeyValuePair(Of Week, Decimal) In planstodelete
                    Me.Plan.Remove(p.Key)
                Next
            Catch ex As Exception

            End Try
            For Each child As WorkBreakdownStructure In Me.Childs
                child.UpdatePlan()
            Next
        End Sub
        Public Sub FillPlan(ByVal dtPlans As DataTable)

            For Each p As KeyValuePair(Of Week, Decimal) In Me.Plan
                Dim drPlan As DataRow = dtPlans.NewRow
                drPlan("plan_wbs") = Me.Id
                drPlan("year") = p.Key.Year
                drPlan("month") = p.Key.Month
                drPlan("number") = p.Key.Number
                drPlan("amount") = p.Value
                dtPlans.Rows.Add(drPlan)
            Next

            For Each child As WorkBreakdownStructure In Me.Childs
                child.FillPlan(dtPlans)
            Next
        End Sub
        Public Sub CreateOrUpdate(ByVal dtWbs As DataTable, ByVal drBoq As DataRow)
            Dim drWbs As DataRow
            Dim drs As DataRow() = dtWbs.Select("wbs_id=" & Me.Id)
            If drs.Length = 0 Then
                drWbs = dtWbs.NewRow
            Else
                drWbs = drs(0)
            End If
            drWbs("wbs_boq") = drBoq("boq_id")

            If Not Me.Parent Is Nothing AndAlso Me.Parent.Id <> 0 Then
                drWbs("wbs_parid") = Me.Parent.Id
            Else
                drWbs("wbs_parid") = DBNull.Value
            End If

            drWbs("wbs_level") = Me.Level
            drWbs("wbs_code") = Me.Code
            If Not Me.CBS Is Nothing AndAlso Me.CBS.Id <> 0 Then
                drWbs("wbs_cbs") = Me.CBS.Id
            Else
                drWbs("wbs_cbs") = DBNull.Value
            End If
            drWbs("wbs_name") = Me.Name
            drWbs("wbs_altName") = Me.AlternateName
            drWbs("wbs_note") = Me.Note
            drWbs("wbs_control") = (Me.Childs.Count > 0)
            drWbs("wbs_path") = ""
            drWbs("wbs_linenumber") = 1
            drWbs("wbs_state") = CInt(Me.State)

            If Not Me.StatusId.HasValue Then
                Me.StatusId = 2
            End If
            drWbs("wbs_status") = Me.StatusId.Value
            If Me.PlannedStartDate.HasValue Then
                drWbs("wbs_startdate") = Me.PlannedStartDate.Value
            End If
            If Me.PlannedFinishDate.HasValue Then
                drWbs("wbs_finishdate") = Me.PlannedFinishDate.Value
            End If
            If Me.Qty.HasValue Then
                drWbs("wbs_qty") = Me.Qty
            Else
                drWbs("wbs_qty") = DBNull.Value
            End If
            If Me.UnitPrice.HasValue Then
                drWbs("wbs_unitprice") = Me.UnitPrice
            Else
                drWbs("wbs_unitprice") = DBNull.Value
            End If
            drWbs("wbs_budget") = Me.Budget
            drWbs("wbs_amount") = Me.Amount

            drWbs("wbs_unit") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.Unit)
            If drs.Length = 0 Then
                dtWbs.Rows.Add(drWbs)
                Me.Id = CInt(drWbs("wbs_id"))
                If Me.Level = 0 OrElse drWbs.IsNull("wbs_parid") Then
                    drWbs("wbs_parid") = DBNull.Value
                End If
            End If
            For Each child As WorkBreakdownStructure In Me.Childs
                child.CreateOrUpdate(dtWbs, drBoq)
            Next
        End Sub
        Public Sub PopulateRow(ByVal tr As TreeRow, ByVal SetWorkDone As CountDelegate, ByVal current As Integer, ByVal includeChildren As Boolean)
            If tr Is Nothing Then
                Return
            End If
            If Not SetWorkDone Is Nothing Then
                current += 1
                SetWorkDone(current)
            End If
            tr("Code") = Me.Code
            If Not Me.CBS Is Nothing AndAlso Me.CBS.IdOrNull.HasValue Then
                tr("CBS") = Me.CBS.Code
            Else
                tr("CBS") = ""
            End If
            tr("Name") = Me.Name
            tr("Unit") = Me.Unit.Name
            tr("UnitButton") = ""
            tr("Note") = Me.Note

            Dim tmat As Decimal = 0 'Me.GetTotalMat
            Dim tlab As Decimal = 0 'Me.GetTotalLab
            Dim teq As Decimal = 0 'Me.GetTotalEq
            Dim t As Decimal = 0 'Me.GetTotal
            Dim tpw As Decimal = 0 'Me.GetTotalPerWBS

            If Me.UnitPrice.HasValue Then
                tr("Unitprice") = Configuration.FormatToString(Me.UnitPrice.Value, DigitConfig.UnitPrice)
            Else
                tr("Unitprice") = ""
            End If

            If Me.Qty.HasValue Then
                tr("QTY") = Configuration.FormatToString(Me.Qty.Value, DigitConfig.UnitPrice)
            Else
                tr("QTY") = ""
            End If

            tr("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
            tr("Budget") = Configuration.FormatToString(Me.Budget, DigitConfig.Price)

            If Me.PlannedStartDate.HasValue Then
                tr("StartDate") = Me.PlannedStartDate.Value
            Else
                tr("StartDate") = DBNull.Value
            End If
            If Me.PlannedFinishDate.HasValue Then
                tr("FinishDate") = Me.PlannedFinishDate.Value
            Else
                tr("FinishDate") = DBNull.Value
            End If

            tr.State = Me.State

            tr.Tag = Me

            If includeChildren Then
                For Each child As WorkBreakdownStructure In Me.Childs
                    Dim childTR As TreeRow = tr.Childs.Add
                    child.PopulateRow(childTR, SetWorkDone, current, includeChildren)
                Next
            End If
        End Sub

        Public Function FindWbs(ByVal id As Integer) As WorkBreakdownStructure
            For Each child As WorkBreakdownStructure In Me.Childs
                If child.Id = id Then
                    Return child
                End If
                Dim founded As WorkBreakdownStructure = child.FindWbs(id)
                If Not founded Is Nothing Then
                    Return founded
                End If
            Next
        End Function
    End Class
End Namespace

