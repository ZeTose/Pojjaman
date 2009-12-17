Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class Budget
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IDisposable, IDuplicable

#Region "Members"
    Private m_project As Project
    Private m_estimator As Employee
    Private m_status As BOQStatus


    Private m_itemTable As TreeTable
    Private m_lvfgs As ArrayList

    Private m_taxAmount As Decimal

    Private m_markupState As String

    Private m_totalBudgetFromDB As Decimal
    Private m_finalbidpriceFromDB As Decimal

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
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_project = New Project
        .m_estimator = New Employee
        .m_status = New BOQStatus(-1)
       
        m_lvfgs = New ArrayList
      End With
      WorkBreakdownStructure.GetBoqChilds(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "project_id") Then
          If Not dr.IsNull(aliasPrefix & "project_id") Then
            .m_project = New Project(dr, aliasPrefix & "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "boq_project") Then
            .m_project = New Project(CInt(dr(aliasPrefix & "boq_project")))
          End If
        End If
        If dr.Table.Columns.Contains("employee_id") Then
          If Not dr.IsNull("employee_id") Then
            .m_estimator = New Employee(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "boq_employee") Then
            .m_estimator = New Employee(CInt(dr(aliasPrefix & "boq_employee")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_status") AndAlso Not dr.IsNull(aliasPrefix & "boq_status") Then
          .m_status = New BOQStatus(CInt(dr(aliasPrefix & "boq_status")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_taxamt") AndAlso Not dr.IsNull(aliasPrefix & "boq_taxamt") Then
          .m_taxAmount = CDec(dr(aliasPrefix & "boq_taxamt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_finalbidprice") AndAlso Not dr.IsNull(aliasPrefix & "boq_finalbidprice") Then
          .m_finalbidpriceFromDB = CDec(dr(aliasPrefix & "boq_finalbidprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_totalBudget") AndAlso Not dr.IsNull(aliasPrefix & "boq_totalBudget") Then
          .m_totalBudgetFromDB = CDec(dr(aliasPrefix & "boq_totalBudget"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_markupstate") AndAlso Not dr.IsNull(aliasPrefix & "boq_markupstate") Then
          .m_markupState = CStr(dr(aliasPrefix & "boq_markupstate"))
        End If
      End With
      WorkBreakdownStructure.GetBoqChilds(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Private Lazy As Boolean = False
    Public Sub LazyConstruct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_code") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_code") Then
          .Code = CStr(dr(aliasPrefix & Me.Prefix & "_code"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_id") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_id") Then
          .Id = CInt(dr(aliasPrefix & Me.Prefix & "_id"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "boq_finalbidprice") AndAlso Not dr.IsNull(aliasPrefix & "boq_finalbidprice") Then
          .m_finalbidpriceFromDB = CDec(dr(aliasPrefix & "boq_finalbidprice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "boq_totalBudget") AndAlso Not dr.IsNull(aliasPrefix & "boq_totalBudget") Then
          .m_totalBudgetFromDB = CDec(dr(aliasPrefix & "boq_totalBudget"))
        End If
        Lazy = True
      End With
    End Sub
#End Region

#Region "Properties"    Public Property MarkupState() As String      Get
        Return m_markupState
      End Get
      Set(ByVal Value As String)
        m_markupState = Value
      End Set
    End Property    Public Property TaxAmount() As Decimal
      Get
        Return m_taxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_taxAmount = Value
      End Set
    End Property    Public ReadOnly Property LevelConfigs() As ArrayList
      Get
        'Dim maxLevel As Integer = 0
        'For Each myWbs As WBS In Me.WBSCollection
        'maxLevel = Math.Max(maxLevel, myWbs.Level)
        'Next
        'If m_lvfgs.Count > maxLevel + 1 Then
        'For i As Integer = maxLevel To m_lvfgs.Count - 1
        'm_lvfgs.Remove(m_lvfgs(m_lvfgs.Count - 1))
        'Next
        'ElseIf m_lvfgs.Count < maxLevel + 1 Then
        'For i As Integer = m_lvfgs.Count To maxLevel
        'm_lvfgs.Add(New LevelConfig(i))
        'Next
        'End If
        'Return m_lvfgs
      End Get
    End Property    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property    Public Property Project() As Project      Get        Return m_project      End Get      Set(ByVal Value As Project)        m_project = Value      End Set    End Property    Public Property Estimator() As Employee      Get        Return m_estimator      End Get      Set(ByVal Value As Employee)        m_estimator = Value      End Set    End Property        Public ReadOnly Property TotalBudget() As Decimal
      Get
        'If Lazy Then
        'Return Me.m_totalBudgetFromDB
        'End If
        'Return Me.DirectCost + Me.Overhead
      End Get
    End Property    Public ReadOnly Property HasMaterialCost() As Boolean      Get        If Me.Project Is Nothing Then          Return False
        End If        Return Me.Project.HasMaterialCost      End Get    End Property    Public ReadOnly Property HasLaborCost() As Boolean      Get        If Me.Project Is Nothing Then          Return False
        End If        Return Me.Project.HasLaborCost      End Get    End Property    Public ReadOnly Property HasEquipmentCost() As Boolean      Get        If Me.Project Is Nothing Then          Return False
        End If        Return Me.Project.HasEquipmentCost      End Get    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return Me.m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, BOQStatus)
      End Set
    End Property

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Budget"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName As String
      Get
        Return "GetBudget2"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName As String
      Get
        Return "boq"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Budget.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Budget"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Budget"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Budget.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "boq"
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
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region
#Region "Shared"
    Public Shared Function GetBOQ(ByVal boqId As Integer) As BOQ
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SiteConnectionString _
      , CommandType.StoredProcedure _
      , "GetBOQ" _
      , New SqlParameter("@boq_id", boqId) _
      )
      Dim entity As New BOQ
      If ds.Tables(0).Rows.Count = 1 Then
        entity.LazyConstruct(ds.Tables(0).Rows(0), "")
      End If
      Return entity
    End Function
    Public Shared Function GetBOQ(ByVal txtCode As TextBox, ByRef oldEntity As BOQ) As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SiteConnectionString _
      , CommandType.StoredProcedure _
      , "GetBOQ" _
      , New SqlParameter("@boq_code", txtCode.Text) _
      )
      Dim entity As New BOQ
      If ds.Tables(0).Rows.Count = 1 Then
        entity.LazyConstruct(ds.Tables(0).Rows(0), "")
      End If

      If txtCode.Text.Length <> 0 AndAlso Not entity.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        entity = oldEntity
      End If
      txtCode.Text = entity.Code
      If oldEntity.Id <> entity.Id Then
        oldEntity = entity
        Return True
      End If
      Return False
    End Function    
#End Region

#Region "Saving"
    Public Function FindWBS(ByVal id As Integer) As WorkBreakdownStructure
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
    Private Function InsertUpdate(ByVal currentUserId As Integer) As SaveErrorException
      If Me.DuplicateCode(Me.Code) Then
        Return New SaveErrorException("${res:Global.Error.AlreadyHasThisCode}", New String() {Me.Code})
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim theTime As Date = Now
        Dim theUserId As Integer = currentUserId

        Dim daBoq As SqlDataAdapter
        Dim daWbs As SqlDataAdapter
        If Me.Originated Then
          daBoq = New SqlDataAdapter("Select * from boq where boq_id=" & Me.Id, conn)
          daWbs = New SqlDataAdapter("select * from wbs where wbs_boq=" & Me.Id, conn)
        Else
          daBoq = New SqlDataAdapter("Select * from boq where 1=2", conn)
          daWbs = New SqlDataAdapter("select * from wbs where 1=2", conn)
        End If

        Dim ds As New DataSet

        '***********----BOQ ----****************
        Dim cb As New SqlCommandBuilder(daBoq)
        daBoq.SelectCommand.Transaction = trans

        daBoq.DeleteCommand = cb.GetDeleteCommand
        daBoq.DeleteCommand.Transaction = trans

        daBoq.InsertCommand = cb.GetInsertCommand
        daBoq.InsertCommand.Transaction = trans

        daBoq.UpdateCommand = cb.GetUpdateCommand
        daBoq.UpdateCommand.Transaction = trans

        daBoq.InsertCommand.CommandText &= "; Select * From boq Where boq_id= @@IDENTITY"
        daBoq.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        daBoq.FillSchema(ds, SchemaType.Mapped, "boq")
        daBoq.Fill(ds, "boq")
        '***********----BOQ ----****************

        '***********----WBS ----****************
        cb = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans

        daWbs.DeleteCommand = cb.GetDeleteCommand
        daWbs.DeleteCommand.Transaction = trans

        daWbs.InsertCommand = cb.GetInsertCommand
        daWbs.InsertCommand.Transaction = trans

        daWbs.UpdateCommand = cb.GetUpdateCommand
        daWbs.UpdateCommand.Transaction = trans

        daWbs.InsertCommand.CommandText &= ";" & _
        "update wbs set wbs_parid = wbs_id where wbs_parid is null and wbs_id=@@IDENTITY;" & _
        "update wbs set wbs_path ='|'+convert(nvarchar,wbs_id)+'|' where wbs_id = @@IDENTITY and wbs_parid= @@IDENTITY;" & _
        "update wbs set wbs.wbs_path = (select parent.wbs_path from wbs parent where parent.wbs_id=wbs.wbs_parid) + '|'+convert(nvarchar,wbs.wbs_id)+'|' where wbs.wbs_id = @@IDENTITY and wbs.wbs_parid <> @@IDENTITY ;" & _
        " Select * From wbs Where wbs_id= @@IDENTITY"
        daWbs.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        daWbs.FillSchema(ds, SchemaType.Mapped, "wbs")
        daWbs.Fill(ds, "wbs")
        ds.Relations.Add("boq_wbs", ds.Tables!boq.Columns!boq_id, ds.Tables!wbs.Columns!wbs_boq)
        ds.Relations.Add("wbsTree", ds.Tables!wbs.Columns!wbs_id, ds.Tables!wbs.Columns!wbs_parid)
        '***********----WBS ----****************

        Dim dc As DataColumn

        Dim dtBoq As DataTable = ds.Tables("boq")
        dc = dtBoq.Columns!boq_id
        dc.AutoIncrement = True
        dc.AutoIncrementSeed = -1
        dc.AutoIncrementStep = -1

        Dim dtWbs As DataTable = ds.Tables("wbs")
        dc = dtWbs.Columns!wbs_id
        dc.AutoIncrement = True
        dc.AutoIncrementSeed = Integer.MaxValue
        dc.AutoIncrementStep = -1

        Dim tmpBoqDa As New SqlDataAdapter
        tmpBoqDa.DeleteCommand = daBoq.DeleteCommand
        tmpBoqDa.InsertCommand = daBoq.InsertCommand
        tmpBoqDa.UpdateCommand = daBoq.UpdateCommand

        Dim tmpwbsDa As New SqlDataAdapter
        tmpwbsDa.DeleteCommand = daWbs.DeleteCommand
        tmpwbsDa.InsertCommand = daWbs.InsertCommand
        tmpwbsDa.UpdateCommand = daWbs.UpdateCommand

        AddHandler tmpBoqDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler tmpwbsDa.RowUpdated, AddressOf tmpwbsDa_MyRowUpdated
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        Dim drBoq As DataRow
        If Not Me.Originated Then
          drBoq = dtBoq.NewRow
          dtBoq.Rows.Add(drBoq)
        Else
          drBoq = dtBoq.Rows(0)
        End If
        drBoq(Me.Prefix & "_code") = Me.Code
        drBoq(Me.Prefix & "_project") = Me.ValidIdOrDBNull(Me.Project)
        drBoq(Me.Prefix & "_estimator") = Me.ValidIdOrDBNull(Me.Estimator)
        drBoq(Me.Prefix & "_status") = Me.Status.Value
        drBoq(Me.Prefix & "_taxamt") = Me.TaxAmount
        drBoq(Me.Prefix & "_totalbudget") = Me.TotalBudget

        Me.SetOriginEditCancelStatus(drBoq, theTime, currentUserId)

        Dim rowsToDelete As New ArrayList
        For Each dr As DataRow In dtWbs.Rows
          Dim found As Boolean = (Not FindWBS(CInt(dr("wbs_id"))) Is Nothing)
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        For Each rootWbs As WorkBreakdownStructure In Me.Childs
          rootWbs.CreateOrUpdate(dtWbs, drBoq)
        Next

        tmpwbsDa.Update(GetDeletedRows(dtWbs))
        tmpBoqDa.Update(GetDeletedRows(dtBoq))
        tmpBoqDa.Update(dtBoq.Select("", "", DataViewRowState.ModifiedCurrent))
        tmpwbsDa.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpBoqDa.Update(dtBoq.Select("", "", DataViewRowState.Added))
        tmpwbsDa.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True
        Dim theId As Integer = Me.Id
        If Not Me.Originated Then
          theId = CInt(drBoq("boq_id"))
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "CleanWBs", New SqlParameter() {New SqlParameter("@boq_id", theId)})
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertBOQProcedure", New SqlParameter() {New SqlParameter("@boq", theId)})
        trans.Commit()
        If Not Me.Originated Then
          Me.Id = CInt(drBoq("boq_id"))
        End If
        Return New SaveErrorException("0")
        'Catch ex As Exception
        'trans.Rollback()
        ''Hack
        'Return New SaveErrorException("${res:Global.Error.BOQHasWBSOrMarkupRefedCannotDelete}")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
      Return New SaveErrorException("0")
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub tmpwbsDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("wbs_boq")
        Dim currentInternalKey As Object = e.Row("wbs_parid")
        e.Row!wbs_boq = e.Row.GetParentRow("boq_wbs")("boq_id", DataRowVersion.Original)
        If Not e.Row.GetParentRow("wbsTree") Is Nothing AndAlso e.Row.GetParentRow("wbsTree").HasVersion(DataRowVersion.Original) Then
          e.Row!wbs_parid = e.Row.GetParentRow("wbsTree")("wbs_id", DataRowVersion.Original)
        End If
        'If e.Row.IsNull("wbs_parid") Then
        '    e.Row!wbs_parid = e.Row!wbs_id
        'End If
        e.Row.AcceptChanges()
        e.Row!wbs_boq = currentkey
        e.Row!wbs_parid = currentInternalKey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows
      '
      ' Workaround:
      ' With a remoted DataSet, Select returns the array elements
      ' filled with Nothing/null, instead of DataRow objects.
      '
      Dim r As DataRow, I As Integer = 0
      For Each r In dt.Rows
        If r.RowState = DataRowState.Deleted Then
          Rows(I) = r
          I += 1
        End If
      Next
      Return Rows
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException

      Return InsertUpdate(currentUserId)

    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PO.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Project
      dpi = New DocPrintingItem
      dpi.Mapping = "Project"
      dpi.Value = Me.Project.Code & ":" & Me.Project.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''SumTotalMaterialCost
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumTotalMaterialCost"
      'dpi.Value = Configuration.FormatToString(Me.FinalMaterialCost, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''SumTotalLaborCost
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumTotalLaborCost"
      'dpi.Value = Configuration.FormatToString(Me.FinalLaborCost, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''SumTotalEquipmentCost
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumTotalEquipmentCost"
      'dpi.Value = Configuration.FormatToString(Me.FinalEquipmentCost, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''SumTotal
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumTotal"
      'dpi.Value = Configuration.FormatToString(Me.FinalBidPriceWithVat, DigitConfig.Price)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'Address
      dpi = New DocPrintingItem
      dpi.Mapping = "Address"
      dpi.Value = m_project.Address
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Province
      dpi = New DocPrintingItem
      dpi.Mapping = "Province"
      dpi.Value = m_project.Province
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerCode"
      dpi.Value = m_project.Customer.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerName
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerName"
      dpi.Value = m_project.Customer.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Customer
      dpi = New DocPrintingItem
      dpi.Mapping = "Customer"
      dpi.Value = m_project.Customer.Code & ":" & m_project.Customer.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CompletionDate
      dpi = New DocPrintingItem
      dpi.Mapping = "CompletionDate"
      dpi.Value = m_project.CompletionDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl

    End Function
#End Region

#Region "Overrides"
    Public Overrides Function ToString() As String
      Return Me.Code
    End Function
#End Region

#Region "IDisposable"
    Public Sub Dispose() Implements System.IDisposable.Dispose
      Dispose(True)
    End Sub
    Protected Overrides Sub Finalize()
      Dispose(False)
    End Sub
    Protected m_disposed As Boolean = False
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If m_disposed Then
        Return
      End If
      If disposing Then
        Try
          'Me.ItemCollection.Dispose()
          'Me.WBSCollection.Dispose()
          'Me.MarkupCollection.Dispose()
          'Me.LaborMarkupItems.Dispose()
          'Me.EquipmentMarkupItems.Dispose()
          'Me.MaterialMarkupItems.Dispose()
        Catch ex As Exception

        End Try
        m_disposed = True
        GC.SuppressFinalize(Me)
      End If
      'Undone : clear all resource
    End Sub
#End Region

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      'If Not Me.Originated Then
      'Return Me
      'End If
      'Me.Id = 0
      'Me.Code = "Copy of " & Me.Code
      'For Each myWbs As WBS In Me.WBSCollection
      'Dim parent As WBS = Me.WBSCollection.GetParentOf(myWbs)
      'If parent Is Nothing Then
      'parent = myWbs
      'End If
      'myWbs.Parent = parent
      'Next
      'For Each myWbs As WBS In Me.WBSCollection
      'myWbs.Id = 0
      'myWbs.Status.Value = -1
      'Next
      'For Each mk As Markup In Me.MarkupCollection
      'mk.Id = 0
      'mk.Status.Value = -1
      'Next
      'Return Me
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBoq}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBoq", New SqlParameter() {New SqlParameter("@boq_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.BoqIsReferencedCannotBeDeleted}")
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

#Region "New Way"
    Public Property Childs As List(Of WorkBreakdownStructure)
    Public Property ChildrenCount As Integer
    Public Sub PopulateWorkBreakdownStructures(ByVal dt As TreeTable, Optional ByVal SetWorkDone As CountDelegate = Nothing)
      dt.Clear()
      dt.Initialized = False
      Dim cnt As Integer = 0
      For Each w As WorkBreakdownStructure In Me.Childs
        If Not SetWorkDone Is Nothing Then
          cnt += 1
          SetWorkDone(cnt)
        End If
        Dim tr As TreeRow = dt.Childs.Add
        w.PopulateRow(tr, SetWorkDone, cnt, True)
      Next
      dt.Initialized = True
      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("Linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
#End Region
  End Class

End Namespace

