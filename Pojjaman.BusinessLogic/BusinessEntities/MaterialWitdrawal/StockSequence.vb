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
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class StockSequence
    Inherits SimpleBusinessEntityBase
    'Implements IGLAble, IPrintableEntity, IHasToCostCenter, IHasFromCostCenter, ICancelable, ICheckPeriod

    Implements ICancelable


#Region "Members"
    Private m_DateStart As Date
    Private m_DateEnd As Date
    Private m_IsReSequence As Boolean
    Private Shared m_dataset As DataSet
    Private m_IsRecalUnitCost As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      Me.Id = 1 'Hack
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains("datestart") Then
          If Not dr.IsNull("datestart") AndAlso IsDate(dr("datestart")) Then
            .DateStart = CDate(dr("datestart"))
          End If
        End If
        If dr.Table.Columns.Contains("dateend") Then
          If Not dr.IsNull("datestart") AndAlso IsDate(dr("dateend")) Then
            .DateEnd = CDate(dr("dateend"))
          End If
        End If
        If dr.Table.Columns.Contains("IsResequence") Then
          If Not dr.IsNull("IsResequence") Then
            .IsReSequenced = CBool(dr("IsResequence"))
          End If
        End If
      End With
    End Sub
    'Public Sub New(ByVal code As String)
    '  MyBase.New(code)
    'End Sub
    'Public Sub New(ByVal id As Integer)
    '  MyBase.New(id)
    'End Sub
    'Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
    '  Me.Construct(dr, aliasPrefix)
    'End Sub
    'Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
    '  Dim dr As DataRow = ds.Tables(0).Rows(0)
    '  Construct(dr, aliasPrefix)
    'End Sub
    'Protected Overloads Overrides Sub Construct()
    '  MyBase.Construct()
    '  With Me
    '    .m_docDate = Now.Date
    '    .m_costCenter = New CostCenter
    '    .m_fromCostCenter = New CostCenter
    '    .m_fromCostCenterPerson = New Employee
    '    .m_toCostCenter = New CostCenter
    '    .m_toCostCenterPerson = New Employee
    '    .m_asset = New Asset
    '    .m_type = New MatWithdrawType(1)
    '    .Status = New StockStatus(-1)
    '    .m_note = ""
    '    .m_grouping = True

    '    '----------------------------Tab Entities-----------------------------------------

    '    '.m_je = New JournalEntry(Me)
    '    .m_je.DocDate = Me.m_docDate

    '    '----------------------------End Tab Entities-----------------------------------------
    '  End With
    '  'm_itemCollection = New MatWithdrawItemCollection(Me, m_grouping)
    'End Sub
    'Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
    '  MyBase.Construct(dr, aliasPrefix)
    '  With Me

    '    If dr.Table.Columns.Contains(aliasPrefix & "costcenter.cc_id") Then
    '      If Not dr.IsNull(aliasPrefix & "costcenter.cc_id") Then
    '        .m_costCenter = New CostCenter(dr, "costcenter.")
    '      End If
    '    Else
    '      If Not dr.IsNull(aliasPrefix & "stock_cc") Then
    '        .m_costCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_cc")))
    '      End If
    '    End If

    '    If dr.Table.Columns.Contains(aliasPrefix & "tocostcenter.cc_id") Then
    '      If Not dr.IsNull(aliasPrefix & "tocostcenter.cc_id") Then
    '        .m_toCostCenter = New CostCenter(dr, "tocostcenter.")
    '      End If
    '    Else
    '      If dr.Table.Columns.Contains("stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
    '        .m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
    '      End If
    '    End If

    '    If dr.Table.Columns.Contains(aliasPrefix & "fromcostcenter.cc_id") Then
    '      If Not dr.IsNull(aliasPrefix & "fromcostcenter.cc_id") Then
    '        .m_fromCostCenter = New CostCenter(dr, "fromcostcenter.")
    '      End If
    '    Else
    '      If dr.Table.Columns.Contains("stock_fromcc") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromcc") Then
    '        .m_fromCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_fromcc")))
    '      End If
    '    End If

    '    If dr.Table.Columns.Contains(aliasPrefix & "fromcostcenterperson.employee_id") Then
    '      If Not dr.IsNull(aliasPrefix & "fromcostcenterperson.employee_id") Then
    '        .m_fromCostCenterPerson = New Employee(dr, "fromcostcenterperson.")
    '      End If
    '    Else
    '      If dr.Table.Columns.Contains("stock_fromccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromccperson") Then
    '        .m_fromCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_fromccperson")))
    '      End If
    '    End If

    '    If dr.Table.Columns.Contains(aliasPrefix & "tocostcenterperson.employee_id") Then
    '      If Not dr.IsNull(aliasPrefix & "tocostcenterperson.employee_id") Then
    '        .m_toCostCenterPerson = New Employee(dr, "tocostcenterperson.")
    '      End If
    '    Else
    '      If dr.Table.Columns.Contains("stock_toccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_toccperson") Then
    '        .m_toCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_toccperson")))
    '      End If
    '    End If


    '    If dr.Table.Columns.Contains(aliasPrefix & "stock_tag") AndAlso Not dr.IsNull(aliasPrefix & "stock_tag") Then
    '      Me.m_type.Value = CInt(dr(aliasPrefix & "stock_tag"))
    '    End If

    '    If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
    '      .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
    '    End If

    '    If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
    '      .m_note = CStr(dr(aliasPrefix & "stock_note"))
    '    End If

    '    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
    '    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
    '      .Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
    '    End If


    '    If dr.Table.Columns.Contains(aliasPrefix & "_asset") Then
    '      If Not dr.IsNull(aliasPrefix & "_asset") Then
    '        .m_asset = New Asset(CInt(dr(aliasPrefix & "_asset")))
    '      End If
    '    Else
    '      If dr.Table.Columns.Contains("stock_asset") AndAlso Not dr.IsNull("stock_asset") Then
    '        .m_asset = New Asset(CInt(dr("stock_asset")))
    '      End If
    '    End If


    '    'm_je = New JournalEntry(Me)

    '    'm_itemCollection = New MatWithdrawItemCollection(Me, m_grouping)
    '  End With
    'End Sub
#End Region

#Region "Properties"
    Public Property DateStart() As Date
      Get
        Return m_datestart
      End Get
      Set(ByVal Value As Date)
        m_DateStart = Value
      End Set
    End Property
    Public Property DateEnd() As Date
      Get
        Return m_DateEnd
      End Get
      Set(ByVal Value As Date)
        m_DateEnd = Value
      End Set
    End Property
    Public Property IsReSequenced() As Boolean
      Get
        Return m_IsReSequence
      End Get
      Set(ByVal Value As Boolean)
        m_IsReSequence = Value
      End Set
    End Property
    Public Shared ReadOnly Property DataSet() As DataSet
      Get
        Return m_dataset
      End Get
    End Property
    Public Property IsRecalUnitCost() As Boolean
      Get
        Return Me.m_IsRecalUnitCost
      End Get
      Set(ByVal Value As Boolean)
        Me.m_IsRecalUnitCost = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "StockSequence"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return ""
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "StockSequence"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.StockSequence.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.StockSequence"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.StockSequence"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.StockSequence.ListLabel}"
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
#End Region

#Region "Shared"
   
#End Region

#Region "Methods"
    Public Sub GetPreReSequence()
      Try
        m_dataset = New DataSet
        m_dataset = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetStockSequence" _
                , New SqlParameter("@DateStart", Me.DateStart) _
                , New SqlParameter("@DateEnd", Me.DateEnd) _
                , New SqlParameter("@ViewItems", 1) _
                )
        'If ds.Tables.Count > 0 Then
        '  m_table.Rows.Clear()
        '  m_table = ds.Tables(0)
        'End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    'Public Sub GetLastReSequenceDate()
    '  Dim config As Object = Configuration.GetConfig("LastReSequenceDate")
    '  If config Is Nothing Then
    '    m_IsReSequence = False
    '  Else
    '    m_IsReSequence = True
    '  End If
    'End Sub
    'Public Function GetDiffConversion() As Decimal
    '  Try
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset( _
    '            Me.ConnectionString _
    '            , CommandType.StoredProcedure _
    '            , "GetMatwithdrawDiffConversion" _
    '            , New SqlParameter("@stock_id", Me.Id) _
    '            )
    '    If ds.Tables(0).Rows.Count > 0 Then
    '      If ds.Tables(0).Rows(0).IsNull(0) Then
    '        Return 0
    '      End If
    '      Return CDec(ds.Tables(0).Rows(0)(0))
    '    End If
    '  Catch ex As Exception
    '    MessageBox.Show(ex.ToString)
    '  End Try
    '  Return 0
    'End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
   
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      Dim cmd As New SqlCommand
      Try
        conn.Open()
        trans = conn.BeginTransaction()
        cmd.CommandTimeout = 0
        cmd.Connection = conn
        cmd.Transaction = trans
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "UpdateStockSequence"
        cmd.Parameters.Add("@DateStart", Me.DateStart)
        cmd.Parameters.Add("@DateEnd", Me.DateEnd)
        cmd.Parameters.Add("@recalUnitCost", Me.IsRecalUnitCost)

        cmd.ExecuteReader()
        trans.Commit()

        Return New SaveErrorException("")
      Catch ex As Exception
        trans.Rollback()
        'ResetId(oldid, oldjeid)
        Return New SaveErrorException(ex.ToString)
      End Try

    End Function
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
    'Public Overrides Function Delete() As SaveErrorException
    '  If Not Me.Originated Then
    '    Return New SaveErrorException("${res:Global.Error.NoIdError}")
    '  End If
    '  Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '  Dim format(0) As String
    '  format(0) = Me.Code
    '  If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteMatWithdraw}", format) Then
    '    Return New SaveErrorException("${res:Global.CencelDelete}")
    '  End If
    '  '-------------------------------------------------------
    '  Dim pris As String = GetPritemString()
    '  Dim sql As String = "select * from pritem where convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) " & _
    '  "in (select convert(nvarchar,stocki_refdoc) + '|' +  convert(nvarchar,stocki_refdoclinenumber) from stockitem " & _
    '  "where stocki_stock=" & Me.Id & ") or convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) in " & pris

    '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
    'RecentCompanies.CurrentCompany.SiteConnectionString _
    ', CommandType.Text _
    ', sql _
    ')
    '  Dim arr As New ArrayList
    '  For Each row As DataRow In ds.Tables(0).Rows
    '    Dim o As New ValueDisplayPair(row("pri_pr"), row("pri_linenumber"))
    '    arr.Add(o)
    '  Next
    '  '-------------------------------------------------------
    '  Dim trans As SqlTransaction
    '  Dim conn As New SqlConnection(Me.ConnectionString)
    '  conn.Open()
    '  trans = conn.BeginTransaction()
    '  Try
    '    Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
    '    returnVal.ParameterName = "RETURN_VALUE"
    '    returnVal.DbType = DbType.Int32
    '    returnVal.Direction = ParameterDirection.ReturnValue
    '    returnVal.SourceVersion = DataRowVersion.Current
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteMatWithdraw", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
    '    If IsNumeric(returnVal.Value) Then
    '      Select Case CInt(returnVal.Value)
    '        Case -1
    '          trans.Rollback()
    '          Return New SaveErrorException("${res:Global.MatWithdrawIsReferencedCannotBeDeleted}")
    '        Case Else
    '      End Select
    '    ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
    '      trans.Rollback()
    '      Return New SaveErrorException(returnVal.Value.ToString)
    '    End If
    '    Me.DeleteRef(conn, trans)


    '    '--------------------------------------------------------------
    '    Dim oldid As Integer = Me.Id
    '    Dim oldjeid As Integer = Me.m_je.Id
    '    Dim savePRItemsError As SaveErrorException = Me.SavePRItemsDetail(arr, trans, conn)
    '    If Not IsNumeric(savePRItemsError.Message) Then
    '      trans.Rollback()
    '      ResetId(oldid, oldjeid)
    '      Return savePRItemsError
    '    Else
    '      Select Case CInt(savePRItemsError.Message)
    '        Case -1, -5
    '          trans.Rollback()
    '          ResetId(oldid, oldjeid)
    '          Return savePRItemsError
    '        Case -2
    '          'Post ไปแล้ว
    '          Return savePRItemsError
    '        Case Else
    '      End Select
    '    End If
    '    '--------------------------------------------------------------

    '    trans.Commit()
    '    Return New SaveErrorException("1")
    '  Catch ex As SqlException
    '    trans.Rollback()
    '    Return New SaveErrorException(ex.Message)
    '  Catch ex As Exception
    '    trans.Rollback()
    '    Return New SaveErrorException(ex.Message)
    '  Finally
    '    conn.Close()
    '  End Try
    'End Function
#End Region

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return False
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

  End Class
 
End Namespace
