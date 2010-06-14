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
  Public Class MatReturn
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPrintableEntity, IHasToCostCenter, IHasFromCostCenter, ICancelable, ICheckPeriod, IWBSAllocatable

#Region "Members"
    Private m_docDate As Date
    Private m_note As String

    Private m_costCenter As CostCenter
    Private m_fromCostCenter As CostCenter
    Private m_toCostCenter As CostCenter
    Private m_fromCostCenterPerson As Employee
    Private m_toCostCenterPerson As Employee

    Private m_isinitialized As Boolean


    Private m_je As JournalEntry

    Private m_grouping As Boolean = True    Private m_itemCollection As MatReturnItemCollection
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
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docDate = Now.Date
        .m_costCenter = New CostCenter
        .m_fromCostCenter = New CostCenter
        .m_fromCostCenterPerson = New Employee
        .m_toCostCenter = New CostCenter
        .m_toCostCenterPerson = New Employee
        .Status = New StockStatus(-1)
        .m_note = ""
        .m_grouping = True

        '----------------------------Tab Entities-----------------------------------------

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      m_itemCollection = New MatReturnItemCollection(Me, m_grouping)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "costcenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "costcenter.cc_id") Then
            .m_costCenter = New CostCenter(dr, "costcenter.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "stock_cc") Then
            .m_costCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "stock_cc")))
            '.m_costCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_cc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenter.cc_id") Then
            .m_toCostCenter = New CostCenter(dr, "tocostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
            .m_toCostCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "stock_tocc")))
            '.m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "fromcostcenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "fromcostcenter.cc_id") Then
            .m_fromCostCenter = New CostCenter(dr, "fromcostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_fromcc") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromcc") Then
            .m_fromCostCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "stock_fromcc")))
            '.m_fromCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_fromcc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "fromcostcenterperson.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "fromcostcenterperson.employee_id") Then
            .m_fromCostCenterPerson = New Employee(dr, "fromcostcenterperson.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_fromccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromccperson") Then
            .m_fromCostCenterPerson = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "stock_fromccperson")))
            '.m_fromCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_fromccperson")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenterperson.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenterperson.employee_id") Then
            .m_toCostCenterPerson = New Employee(dr, "tocostcenterperson.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_toccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_toccperson") Then
            .m_toCostCenterPerson = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "stock_toccperson")))
            '.m_toCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_toccperson")))
          End If
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          Me.Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        m_je = New JournalEntry(Me)

        m_itemCollection = New MatReturnItemCollection(Me, m_grouping)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollection() As MatReturnItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As MatReturnItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate, IWBSAllocatable.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        Me.m_je.DocDate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Note() As String Implements IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter      Get        Return m_fromCostCenter      End Get      Set(ByVal Value As CostCenter)        m_fromCostCenter = Value      End Set    End Property    Public Property ToCostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter      Get        Return m_toCostCenter      End Get      Set(ByVal Value As CostCenter)        m_toCostCenter = Value      End Set    End Property    Public Property FromCostCenterPerson() As Employee      Get        Return m_fromCostCenterPerson      End Get      Set(ByVal Value As Employee)        m_fromCostCenterPerson = Value      End Set    End Property    Public Property ToCostCenterPerson() As Employee      Get        Return m_toCostCenterPerson      End Get      Set(ByVal Value As Employee)        m_toCostCenterPerson = Value      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        'คืนเข้า store เท่านั้น        Return Me.ToCostCenter.StoreAccount      End Get    End Property    Public Overridable Property Grouping() As Boolean      Get
        Return m_grouping
      End Get
      Set(ByVal Value As Boolean)
        m_grouping = Value
      End Set
    End Property    Public Property CostCenter() As CostCenter      Get        Return m_costCenter      End Get      Set(ByVal Value As CostCenter)        m_costCenter = Value      End Set    End Property    Public ReadOnly Property Gross() As Decimal      Get
        If Me.ItemCollection Is Nothing Then
          Return 0
        End If
        Dim ret As Decimal = 0
        For Each item As MatReturnItem In Me.ItemCollection
          ret += item.Amount
        Next
        Return ret
      End Get
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "MatReturn"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatReturn.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.MatReturn"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.MatReturn"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatReturn.ListLabel}"
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
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("MatReturn")
      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitcost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_transferUnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_transferamt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_sequence", GetType(Integer)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal isOut As Boolean) As Decimal
      Dim ret As Decimal = 0
      For Each item As MatReturnItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        Dim view As Integer = 45
        Dim type As Integer = 3
        If Not isOut Then
          coll = item.InWbsdColl
          view = 31
        Else
          type = 1
          coll = item.OutWbsdColl
          view = 45
        End If
        For Each grWBSD As WBSDistribute In coll
          If Not grWBSD.IsMarkup Then
            Dim amt As Decimal = WBSDistribute.GetUsedAmount(item.TransferAmount, item.Amount, isOut, view, type)
            If grWBSD.WBS.IsDescendantOf(myWbs) Then
              ret += (grWBSD.Percent * amt / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Public Function GetCurrentAmountForMarkup(ByVal mk As Markup, ByVal isOut As Boolean) As Decimal
      Dim ret As Decimal = 0
      For Each item As MatReturnItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        If Not isOut Then
          coll = item.InWbsdColl
        Else
          coll = item.OutWbsdColl
        End If
        For Each grWBSD As WBSDistribute In coll
          If grWBSD.IsMarkup Then
            If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
              ret += (grWBSD.Percent * item.Amount / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Public Function GetCurrentQtyForWBS(ByVal myWbs As WBS, ByVal unit As Unit, ByVal isOut As Boolean) As Decimal
      Dim ret As Decimal = 0
      For Each item As MatReturnItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        Dim view As Integer = 45
        Dim type As Integer = 3
        If Not isOut Then
          coll = item.InWbsdColl
          view = 31
        Else
          type = 1
          coll = item.OutWbsdColl
          view = 45
        End If
        For Each grWBSD As WBSDistribute In coll
          If Not grWBSD.IsMarkup Then
            Dim qty As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, type)
            If grWBSD.WBS.IsDescendantOf(myWbs) Then
              ret += (grWBSD.Percent * qty / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Private Function OverBudget() As Boolean
      If Me.ToCostCenter.Type.Value <> 2 Then
        Return False
      End If
      'GROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If
      If Not onlyCC Then
        For Each item As MatReturnItem In Me.ItemCollection
          Dim inwsdColl As WBSDistributeCollection = item.InWbsdColl
          If inwsdColl.Count = 0 Then
            Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrentDiff As Decimal = item.Amount
            totalBudget = rootWBS.GetTotalMatFromDB
            totalActual = rootWBS.GetActualMat(Me, 31)
            If totalBudget < (totalActual + totalCurrentDiff) Then
              Return True
            End If
          End If

          For Each wbsd As WBSDistribute In inwsdColl
            If wbsd.AmountOverBudget Then
              Return True
            End If
            Dim rootWBS As New WBS(wbsd.WBS.Id)
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrentDiff As Decimal = 0
            totalCurrentDiff = GetCurrentAmountForWBS(rootWBS, False)
            For Each row As DataRow In rootWBS.GetParentsBudget(Me.EntityId, wbsd.CostCenter.Id)
              totalBudget = 0
              totalActual = 0
              If Not row.IsNull("matbudget") Then
                totalBudget = CDec(row("matbudget"))
              End If
              If Not row.IsNull("matactual") Then
                totalActual = CDec(row("matactual"))
              End If
              If totalBudget < (totalActual + totalCurrentDiff) Then
                Return True
              End If
            Next
          Next

        Next
      Else
        Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
        Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 31) + rootWBS.GetActualLab(Me, 31) + rootWBS.GetActualEq(Me, 31))
        Dim totalCurrentDiff As Decimal = GetCurrentAmountForWBS(rootWBS, False)
        If totalBudget < (totalActual + totalCurrentDiff) Then
          Return True
        End If

      End If
      Return False
    End Function

    Private Sub ResetId(ByVal oldID As Integer, ByVal oldJeId As Integer)
      Me.Id = oldID
      Me.m_je.Id = oldJeId
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Not Me.Grouping Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdrawForOperation.Grouping}"))
        End If
        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        ''check over budget
        'Dim overbudgetconfig As Integer = CInt(Configuration.GetConfig("GROverBudget"))
        'Select Case overbudgetconfig
        '  Case 0     'Not allow
        '    If OverBudget() Then
        '      Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.GROverBudgetCannotBeSaved}"))
        '    End If
        '  Case 1     'Warn
        '    If OverBudget() Then
        '      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        '      If Not msgServ.AskQuestion("${res:Global.Question.GROverBudgetSaveAnyway}") Then
        '        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
        '      End If
        '    End If
        '  Case 2     'Do Nothing
        'End Select

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@stock_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New StockStatus(2)
        End If

        '---- AutoCode Format --------
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

        Me.m_je.RefreshGLFormat()
        If Not AutoCodeFormat Is Nothing AndAlso Not AutoCodeFormat.Format Is Nothing Then


          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              'ตาม entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              'แยก
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_je.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@stock_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@stock_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@stock_toAcct", IIf(Me.ToAccount.Originated, Me.ToAccount.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_tocc", IIf(Me.ToCostCenter.Originated, Me.ToCostCenter.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_toccperson", IIf(Me.ToCostCenterPerson.Originated, Me.ToCostCenterPerson.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_fromcc", IIf(Me.FromCostCenter.Originated, Me.FromCostCenter.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_fromccperson", IIf(Me.FromCostCenterPerson.Originated, Me.FromCostCenterPerson.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_cc", IIf(Me.CostCenter.Originated, Me.CostCenter.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@stock_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@stock_type", Me.EntityId))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldId As Integer = Me.Id
        Dim oldJeId As Integer = Me.m_je.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            ResetId(oldId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          '==============================DeleteSTOCKCOST=========================================
          'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
          If Me.Originated AndAlso Not Me.IsReferenced Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteStockiCost", New SqlParameter("@stock_id", Me.Id))
          End If
          '==============================DeleteSTOCKCOST=========================================

          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveDetailError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveDetailError
              Case Else
            End Select
          End If

          '==============================STOCKCOSTFIFO=========================================
          'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
          If Me.Originated AndAlso Not Me.IsReferenced Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertStockiCostFIFO", New SqlParameter("@stock_id", Me.Id), _
                                                                                                  New SqlParameter("@stock_cc", Me.FromCostCenter.Id))
          End If
          '==============================STOCKCOSTFIFO=========================================

          Me.DeleteRef(conn, trans)
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
          , New SqlParameter("@refto_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
          , New SqlParameter("@refto_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
          , New SqlParameter("@refto_id", Me.Id))
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If
          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================


          'trans.Commit()
          'Try
          '  trans = conn.BeginTransaction()
          '  Dim saveWBSError As SaveErrorException = Me.SaveWBSDetail(Me.Id, conn, trans)
          '  If Not IsNumeric(saveWBSError.Message) Then
          '    trans.Rollback()
          '    ResetId(oldId, oldJeId)
          '    Return saveWBSError
          '  Else
          '    Select Case CInt(saveWBSError.Message)
          '      Case -1, -5
          '        trans.Rollback()
          '        ResetId(oldId, oldJeId)
          '        Return saveWBSError
          '      Case -2
          '        'Post ไปแล้ว
          '        Return saveWBSError
          '      Case Else
          '    End Select
          '  End If

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertStockProcedure", New SqlParameter("@stock_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertStock2Procedure", New SqlParameter("@stock_id", Me.Id))

          '  trans.Commit()
          'Catch ex As Exception
          '  trans.Rollback()
          '  ResetId(oldId, oldJeId)
          '  Return New SaveErrorException(ex.ToString)
          'End Try
          'Try
          '  trans = conn.BeginTransaction()


          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          '********************************************
          If Not Me.m_je.ManualFormat Then
            m_je.SetGLFormat(Me.GetDefaultGLFormat)
          End If
          '********************************************
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                ResetId(oldId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Return saveJeError
              Case Else
            End Select
          End If

          trans.Commit()
          'Catch ex As Exception
          '  trans.Rollback()
          '  ResetId(oldId, oldJeId)
          '  Return New SaveErrorException(ex.ToString)
          'End Try
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          ResetId(oldId, oldJeId)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          ResetId(oldId, oldJeId)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String
      If Me.AutoCodeFormat.Format.Length > 0 Then
        autoCodeFormat = Me.AutoCodeFormat.Format
      Else
        autoCodeFormat = Me.Code
      End If
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try

        Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)

        da.SelectCommand.Transaction = trans

        Dim cmdInsert As New SqlCommand("EXEC [InsertFIFOMatReturnItem] @stocki_stock, @stocki_lineNumber, @stocki_cc, @stocki_fromcc, @stocki_tocc, @stocki_wbs, @stocki_toacct, @stocki_fromAcctType, @stocki_toAcctType, @stocki_refSequence, @stocki_entity, @stocki_entityType, @stocki_itemname, @stocki_unit, @stocki_unitcost, @stocki_amt, @stocki_qty, @stocki_stockqty, @stocki_iscancelled, @stocki_note, @stocki_type, @stocki_status,@stocki_transferunitprice", conn)

        cmdInsert.Parameters.Add("@stocki_stock", SqlDbType.Decimal, 18, "stocki_stock")
        cmdInsert.Parameters.Add("@stocki_lineNumber", SqlDbType.Decimal, 18, "stocki_lineNumber")
        cmdInsert.Parameters.Add("@stocki_toacct", SqlDbType.Decimal, 18, "stocki_toacct")
        cmdInsert.Parameters.Add("@stocki_cc", SqlDbType.Decimal, 18, "stocki_cc")
        cmdInsert.Parameters.Add("@stocki_tocc", SqlDbType.Decimal, 18, "stocki_tocc")
        cmdInsert.Parameters.Add("@stocki_wbs", SqlDbType.Decimal, 18, "stocki_wbs")
        cmdInsert.Parameters.Add("@stocki_toaccttype", SqlDbType.Decimal, 18, "stocki_toaccttype")
        cmdInsert.Parameters.Add("@stocki_refSequence", SqlDbType.Decimal, 18, "stocki_refSequence")
        cmdInsert.Parameters.Add("@stocki_entity", SqlDbType.Decimal, 18, "stocki_entity")
        cmdInsert.Parameters.Add("@stocki_entityType", SqlDbType.Decimal, 18, "stocki_entityType")
        cmdInsert.Parameters.Add("@stocki_itemname", SqlDbType.NVarChar, 1000, "stocki_itemname")
        cmdInsert.Parameters.Add("@stocki_unit", SqlDbType.Decimal, 18, "stocki_unit")
        cmdInsert.Parameters.Add("@stocki_unitcost", SqlDbType.Decimal, 18, "stocki_unitcost")
        cmdInsert.Parameters.Add("@stocki_amt", SqlDbType.Decimal, 18, "stocki_amt")
        cmdInsert.Parameters.Add("@stocki_qty", SqlDbType.Decimal, 18, "stocki_qty")
        cmdInsert.Parameters.Add("@stocki_stockqty", SqlDbType.Decimal, 18, "stocki_stockqty")
        cmdInsert.Parameters.Add("@stocki_iscancelled", SqlDbType.Bit, 4, "stocki_iscancelled")
        cmdInsert.Parameters.Add("@stocki_note", SqlDbType.NVarChar, 2000, "stocki_note")
        cmdInsert.Parameters.Add("@stocki_type", SqlDbType.Decimal, 18, "stocki_type")
        cmdInsert.Parameters.Add("@stocki_status", SqlDbType.Decimal, 18, "stocki_status")
        cmdInsert.Parameters.Add("@stocki_transferunitprice", SqlDbType.Decimal, 18, "stocki_transferunitprice")
        cmdInsert.Parameters.Add("@stocki_fromcc", Me.ValidIdOrDBNull(Me.FromCostCenter))
        cmdInsert.Parameters.Add("@stocki_fromaccttype", 1)      '1=WIP Account --- คืนของได้จาก WIP เท่านั้น

        cmdInsert.Transaction = trans
        da.InsertCommand = cmdInsert

        'Detete
        SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "DeleteStockItem", _
        New SqlParameter("@stocki_stock", Me.Id))

        Dim ds As New DataSet
        da.Fill(ds, "stockitem")
        Dim i As Integer = 0
        With ds.Tables("stockitem")
          For Each item As MatReturnItem In Me.ItemCollection
            i += 1
            Dim dr As DataRow = .NewRow
            dr("stocki_stock") = Me.Id
            dr("stocki_cc") = DBNull.Value
            If Me.Grouping Then
              dr("stocki_linenumber") = i     'itemRow("stocki_linenumber")
            Else
              dr("stocki_linenumber") = item.LineNumber
            End If
            'Me.ItemCollection.Item(item.LineNumber).LineNumber = i
            dr("stocki_entity") = item.Entity.Id
            If TypeOf item.Entity Is IObjectReflectable Then
              dr("stocki_entityType") = CType(item.Entity, IObjectReflectable).EntityId
            Else
              dr("stocki_entityType") = 0
            End If
            dr("stocki_itemName") = DBNull.Value
            dr("stocki_unit") = item.Unit.Id
            dr("stocki_stockqty") = item.StockQty
            dr("stocki_toacct") = Me.ValidIdOrDBNull(Me.ToAccount)
            dr("stocki_toacctType") = 3     'เข้า Store โลด
            dr("stocki_qty") = item.Qty
            dr("stocki_note") = item.Note
            dr("stocki_type") = Me.EntityId
            dr("stocki_tocc") = Me.ValidIdOrDBNull(Me.ToCostCenter)
            If item.TransferUnitPrice = Decimal.MinValue Then
              dr("stocki_transferunitprice") = DBNull.Value
            Else
              dr("stocki_transferunitprice") = item.TransferUnitPrice
            End If
            dr("stocki_status") = Me.Status.Value
            .Rows.Add(dr)
          Next
        End With
        Dim dt As DataTable = ds.Tables("stockitem")
        ' First process deletes.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try

    End Function
    Private Function SaveWBSDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "stockiwbs")

        Dim i As Integer = 0
        Dim dtWbs As DataTable = ds.Tables("stockiwbs")
        Dim rootWBS As WBS
        Dim currentSum As Decimal
        Dim Cost As Decimal = 0

        With dtWbs
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          Dim line As Integer = 0
          For Each item As MatReturnItem In Me.ItemCollection
            Dim seqArr As New ArrayList
            line += 1

            seqArr = StockItem.GetSequenceArray(Me.Id, line)
            For Each row As DataRow In seqArr

              If Not row.IsNull("stocki_amt") Then
                Cost = CDec(row("stocki_amt"))
              Else
                Cost = 0
              End If

              Dim wcoll As WBSDistributeCollection
              For x As Integer = 0 To 1
                If x = 0 Then
                  wcoll = item.InWbsdColl
                  currentSum = wcoll.GetSumPercent
                  rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
                Else
                  wcoll = item.OutWbsdColl
                  currentSum = wcoll.GetSumPercent
                  rootWBS = New WBS(Me.FromCostCenter.RootWBSId)
                End If

                Dim childDr As DataRow

                If wcoll.Count > 0 Then

                  For Each wbsd As WBSDistribute In wcoll

                    childDr = dtWbs.NewRow
                    childDr("stockiw_wbs") = wbsd.WBS.Id

                    If wbsd.CostCenter Is Nothing Then
                      If x = 0 Then
                        wbsd.CostCenter = Me.ToCostCenter
                      Else
                        wbsd.CostCenter = Me.FromCostCenter
                      End If
                    End If

                    If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                      'ยังไม่เต็ม 100 แต่มีหัวอยู่
                      wbsd.Percent += (100 - currentSum)
                    End If

                    wbsd.BaseCost = Cost
                    wbsd.TransferBaseCost = Cost

                    childDr("stockiw_cc") = wbsd.CostCenter.Id
                    childDr("stockiw_percent") = wbsd.Percent
                    childDr("stockiw_sequence") = row("stocki_sequence")
                    childDr("stockiw_ismarkup") = wbsd.IsMarkup
                    childDr("stockiw_direction") = x
                    childDr("stockiw_baseCost") = wbsd.BaseCost
                    childDr("stockiw_transferbaseCost") = wbsd.TransferBaseCost
                    childDr("stockiw_transferamt") = wbsd.TransferAmount
                    childDr("stockiw_amt") = wbsd.Amount
                    childDr("stockiw_toaccttype") = 3        'wbsd.Toaccttype
                    'Add เข้า stockiwbs
                    dtWbs.Rows.Add(childDr)


                  Next
                ElseIf Not (rootWBS.Id = 0) Then
                  childDr = dtWbs.NewRow

                  Dim newWbsd As New WBSDistribute
                  newWbsd.WBS = rootWBS

                  If x = 0 Then
                    newWbsd.CostCenter = Me.ToCostCenter
                  Else
                    newWbsd.CostCenter = Me.FromCostCenter
                  End If

                  newWbsd.Percent = 100 - currentSum
                  newWbsd.BaseCost = Cost
                  newWbsd.TransferBaseCost = Cost

                  childDr("stockiw_cc") = newWbsd.CostCenter.Id
                  childDr("stockiw_percent") = newWbsd.Percent
                  childDr("stockiw_sequence") = row("stocki_sequence")
                  childDr("stockiw_ismarkup") = newWbsd.IsMarkup
                  childDr("stockiw_wbs") = newWbsd.WBS.Id
                  childDr("stockiw_direction") = x
                  childDr("stockiw_baseCost") = newWbsd.BaseCost
                  childDr("stockiw_transferbaseCost") = newWbsd.TransferBaseCost
                  childDr("stockiw_transferamt") = newWbsd.TransferAmount
                  childDr("stockiw_amt") = newWbsd.Amount
                  childDr("stockiw_toaccttype") = 3        'wbsd.Toaccttype

                  'Add เข้า stockiwbs
                  dtWbs.Rows.Add(childDr)
                  'End If
                End If

              Next
            Next
          Next
        End With
        ' First process deletes.
        da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.Added))
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      jiColl.AddRange(Me.GetItemJournalEntries)
      Return jiColl
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      Dim itemColl As New MatReturnItemCollection(Me, False)
      If itemColl Is Nothing Then
        Return jiColl
      End If
      Dim ji As New JournalEntryItem
      For Each item As MatReturnItem In itemColl
        Dim lciMatched As Boolean = False
        Dim lciNoAcctMatched As Boolean = False
        Dim originMatched As Boolean = False
        For Each addedJi As JournalEntryItem In jiColl
          Dim newRealAccount As Account
          Dim newEntityAcct As Account
          Dim newLci As LCIItem = CType(item.Entity, LCIItem)
          If Not newLci.Account Is Nothing AndAlso newLci.Account.Originated Then
            newEntityAcct = newLci.Account
          End If
          If Not newEntityAcct Is Nothing AndAlso newEntityAcct.Originated Then
            'ใช้ acct ของ newLci
            newRealAccount = newEntityAcct
          End If
          If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
            If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = newRealAccount.Id Then
              If addedJi.Mapping = "F2.1" Then
                addedJi.Amount += item.Amount
                lciMatched = True
              End If

              'ต้นทาง
              If addedJi.Mapping = "F2.2" Then
                addedJi.Amount += item.Amount
                originMatched = True
              End If
            End If
          ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
            If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
              If addedJi.Mapping = "F2.1" Then
                addedJi.Amount += item.Amount
                lciNoAcctMatched = True
              End If

              'ต้นทาง
              If addedJi.Mapping = "F2.2" Then
                addedJi.Amount += item.Amount
                originMatched = True
              End If
            End If
          End If
        Next
        Dim realAccount As Account
        Dim entityAcct As Account
        Dim lci As LCIItem = CType(item.Entity, LCIItem)
        If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
          entityAcct = lci.Account
        End If
        If Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
          'ใช้ acct ของ lci
          realAccount = entityAcct
        End If
        If Not originMatched Then
          'ฝั่งต้นทาง
          ji = New JournalEntryItem
          ji.Mapping = "F2.2"
          ji.Amount += item.Amount
          ji.Account = Me.FromCostCenter.WipAccount
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)
        End If
        If Not realAccount Is Nothing AndAlso realAccount.Originated Then
          If Not lciMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "F2.1"
            ji.Amount += item.Amount
            ji.Account = realAccount
            ji.CostCenter = Me.ToCostCenter
            jiColl.Add(ji)
          End If
        ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
          If Not lciNoAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = "F2.1"
            ji.Amount += item.Amount
            ji.CostCenter = Me.ToCostCenter
            jiColl.Add(ji)
          End If
        End If
      Next
      Return jiColl
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "MR"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "MR"
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

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      If Not Me.ToCostCenterPerson Is Nothing AndAlso Me.ToCostCenterPerson.Originated Then
        'ToCCPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCPersonInfo"
        dpi.Value = Me.ToCostCenterPerson.Code & ":" & Me.ToCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCPersonCode"
        dpi.Value = Me.ToCostCenterPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCPersonName"
        dpi.Value = Me.ToCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then
        'ToCCInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCInfo"
        dpi.Value = Me.ToCostCenter.Code & ":" & Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCCode"
        dpi.Value = Me.ToCostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCName"
        dpi.Value = Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromCostCenterPerson Is Nothing AndAlso Me.FromCostCenterPerson.Originated Then
        'FromCCPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCPersonInfo"
        dpi.Value = Me.FromCostCenterPerson.Code & ":" & Me.FromCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCPersonCode"
        dpi.Value = Me.FromCostCenterPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCPersonName"
        dpi.Value = Me.FromCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then
        'FromCCInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCInfo"
        dpi.Value = Me.FromCostCenter.Code & ":" & Me.FromCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCCode"
        dpi.Value = Me.FromCostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCName"
        dpi.Value = Me.FromCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim n As Integer = 0
      For Each item As MatReturnItem In Me.ItemCollection
        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        dpi.Value = item.Entity.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit"
        dpi.Value = item.Unit.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        n += 1
      Next

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Total
      dpi = New DocPrintingItem
      dpi.Mapping = "Total"
      dpi.Value = n
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      Return dpiColl
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
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteMatReturn}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteMatReturn", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.MatReturnIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
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

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.FromCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.FromCostCenter = Value
      End Set
    End Property

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.ToCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.ToCostCenter = Value
      End Set
    End Property

#Region "IWBSAllocatable"

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As MatReturnItem In Me.ItemCollection
        'If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
        item.UpdateWBSQty()

        If Not Me.Originated Then
          For Each wbsd As WBSDistribute In item.OutWbsdColl
            wbsd.ChildAmount = 0
            wbsd.GetChildIdList()
            For Each allItem As MatReturnItem In Me.ItemCollection
              For Each childWbsd As WBSDistribute In allItem.OutWbsdColl
                If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                  wbsd.ChildAmount += childWbsd.Amount
                End If
              Next
            Next
          Next
          For Each wbsd As WBSDistribute In item.InWbsdColl
            wbsd.ChildAmount = 0
            wbsd.GetChildIdList()
            For Each allItem As MatReturnItem In Me.ItemCollection
              For Each childWbsd As WBSDistribute In allItem.InWbsdColl
                If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                  wbsd.ChildAmount += childWbsd.Amount
                End If
              Next
            Next
          Next
        End If

        coll.Add(item)
        'End If
      Next
      Return coll
    End Function

    Public Property Supplier As Supplier Implements IWBSAllocatable.Supplier
      Get

      End Get
      Set(ByVal value As Supplier)

      End Set
    End Property

#End Region

#Region "AllowWBSAllocateFrom"
    Public ReadOnly Property AllowWBSAllocateFrom As Boolean Implements IWBSAllocatable.AllowWBSAllocateFrom
      Get
        Return False
      End Get
    End Property

    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IWBSAllocatable.AllowWBSAllocateTo
      Get
        Return True
      End Get
    End Property
#End Region


  End Class

  Public Class MatReturnForOperation
    Inherits MatReturn
    Public Overrides Property Grouping() As Boolean
      Get
        Return True
      End Get
      Set(ByVal Value As Boolean)

      End Set
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "MatReturnForOperation"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatReturnForOperation.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.MatReturnForOperation"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.MatReturnForOperation"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatReturnForOperation.ListLabel}"
      End Get
    End Property
  End Class

  Public Class MatReturnItem
    Implements IWBSAllocatableItem, IAllowWBSAllocatableItem

#Region "Members"
    Private m_matReturn As MatReturn
    Private m_lineNumber As Integer
    Private m_entity As IHasName
    Private m_unit As Unit
    Private m_qty As Decimal
    Private m_unitCost As Decimal
    Private m_note As String
    Private m_stockqty As Decimal    Private m_transferUnitPrice As Decimal = Decimal.MinValue    Private m_conversion As Decimal = 1
    Private m_oldStockQty As Decimal
    Private m_oldStockQty2 As Decimal
    Private m_transferamount As Decimal

    Private m_matreturnId As Integer

    Private m_sequence As Integer

    Private m_inWbsdColl As WBSDistributeCollection

    Private m_outWbsdColl As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_inWbsdColl = New WBSDistributeCollection
      m_outWbsdColl = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal stockid As Integer, ByVal line As Integer)

      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetMatReturnItems" _
      , New SqlParameter("@stock_id", stockid) _
      , New SqlParameter("@stocki_linenumber", line) _
      )
      Me.Construct(ds.Tables(0).Rows(0), "")
      m_inWbsdColl = New WBSDistributeCollection
      For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & Me.Sequence & "and stockiw_direction=0")
        Dim wbsd As New WBSDistribute(wbsRow, "")
        m_inWbsdColl.Add(wbsd)
      Next
      m_outWbsdColl = New WBSDistributeCollection
      For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & Me.Sequence & "and stockiw_direction=1")
        Dim wbsd As New WBSDistribute(wbsRow, "")
        m_outWbsdColl.Add(wbsd)
      Next
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
          If Not dr.IsNull("lci_id") Then
            .m_entity = New LCIItem(dr, "")
          End If
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "stocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entity") Then
          .m_entity = New LCIItem(CInt(dr(aliasPrefix & "stocki_entity")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_stock") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stock") Then
          m_matreturnId = CInt(dr(aliasPrefix & "stocki_stock"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "stocki_qty"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitcost") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitcost") Then
          .m_unitCost = CDec(dr(aliasPrefix & "stocki_unitcost"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_transferUnitPrice") AndAlso Not dr.IsNull(aliasPrefix & "stocki_transferUnitPrice") Then
          .TransferUnitPrice = CDec(dr(aliasPrefix & "stocki_transferUnitPrice"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_note") AndAlso Not dr.IsNull(aliasPrefix & "stocki_note") Then
          .m_note = CStr(dr(aliasPrefix & "stocki_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & "stocki_unit")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stockqty") Then
          Me.m_stockqty = CDec(dr(aliasPrefix & "stocki_stockqty"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_transferamt") AndAlso Not dr.IsNull(aliasPrefix & "stocki_transferamt") Then
          Me.m_transferamount = CDec(dr(aliasPrefix & "stocki_transferamt"))
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Try
              Me.Conversion = lci.GetConversion(Me.Unit)
            Catch ex As NoConversionException
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              msgServ.ShowErrorFormatted("วัสดุ {0} ไม่มีหน่วยนับ {1} ระบุไว้", New String() {ex.Lci.Code, ex.Unit.Name})
            End Try
          Else
            Me.Conversion = 1
          End If
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property InWbsdColl() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection      Get        Return m_inWbsdColl      End Get      Set(ByVal Value As WBSDistributeCollection)        m_inWbsdColl = Value      End Set    End Property
    Public Property OutWbsdColl() As WBSDistributeCollection Implements IWBSAllocatableItem.WBSDistributeCollection2      Get        Return m_outWbsdColl      End Get      Set(ByVal Value As WBSDistributeCollection)        m_outWbsdColl = Value      End Set    End Property
    Public ReadOnly Property Sequence() As Integer      Get        Return m_sequence      End Get    End Property
    Public ReadOnly Property MatReturnId() As Integer
      Get
        Return m_matreturnId
      End Get
    End Property
    Public Property MatReturn() As MatReturn      Get        Return m_matReturn      End Get      Set(ByVal Value As MatReturn)        m_matReturn = Value        If Value Is Nothing Then
          m_matreturnId = 0
          Return
        End If
        m_matreturnId = Value.Id      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value        If TypeOf m_entity Is IHasUnit Then
          Me.m_unit = CType(m_entity, IHasUnit).DefaultUnit
        End If      End Set    End Property    Public Function GetAmountFromSproc(ByVal lci_id As Integer, ByVal cc As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                RecentCompanies.CurrentCompany.SiteConnectionString _
                , CommandType.StoredProcedure _
                , "GetMatreturnQtyWip" _
                , New SqlParameter("@lci_id", lci_id) _
                , New SqlParameter("@cc_id", cc) _
                )
        If ds.Tables(0).Rows(0).IsNull(0) Then
          Return 0
        End If
        Return CDec(ds.Tables(0).Rows(0)(0))
      Catch ex As Exception
      End Try
    End Function    Public Sub SetItemCode(ByVal theCode As String, Optional ByVal cc As Integer = 0)
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If theCode Is Nothing OrElse theCode.Length = 0 Then
        If Me.Entity.Code.Length <> 0 Then
          If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {Me.Entity.Code}) Then
            Me.Clear()
          End If
        End If
        Return
      End If
      Dim lci As New LCIItem(theCode)
      If Not lci.Originated Then
        msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {theCode})
        Return
      Else
        If Not cc = 0 Then
          If GetAmountFromSproc(lci.Id, cc) > 0 Then
            Me.m_qty = GetAmountFromSproc(lci.Id, cc)
            Me.OldQty2 = Me.m_qty
            Dim myUnit As Unit = lci.DefaultUnit
            Me.m_unit = myUnit
            Me.m_entity = lci
          Else
            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {theCode})
            Return
          End If
          'msgServ.ShowMessageFormatted("no!!!!!!", New String() {theCode})
        End If
      End If
      'Me.m_qty = 1
    End Sub    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        Dim oldConversion As Decimal = Me.Conversion
        Dim newConversion As Decimal = 1
        Dim err As String = ""
        If Not Value Is Nothing AndAlso Value.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            If CType(Me.Entity, LCIItem).Level < 5 Then
              newConversion = 1
            Else
              If Not CType(Me.Entity, LCIItem).ValidUnit(Value) Then
                err = "${res:Global.Error.NoUnitConversion}"
              Else
                newConversion = CType(Me.Entity, LCIItem).GetConversion(Value)
              End If
            End If
          ElseIf TypeOf Me.Entity Is Tool Then
            If Not (Not CType(Me.Entity, Tool).Unit Is Nothing AndAlso CType(Me.Entity, Tool).Unit.Id = Value.Id) Then
              err = "${res:Global.Error.NoUnitConversion}"
            End If
          End If
        Else
          err = "${res:Global.Error.InvalidUnit}"
        End If
        If err.Length = 0 Then
          If Me.m_qty <> 0 Then
            Me.m_qty = (oldConversion / newConversion) * Me.m_qty
          End If
          If Me.TransferUnitPrice <> 0 AndAlso Me.TransferUnitPrice <> Decimal.MinValue Then
            Me.TransferUnitPrice = (newConversion / oldConversion) * Me.m_transferUnitPrice
          End If
          m_unit = Value          Me.Conversion = newConversion        Else
          msgServ.ShowMessage(err)
        End If      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        m_qty = Configuration.Format(Value, DigitConfig.Qty)        m_qty = Value      End Set    End Property    Public Property OldQty() As Decimal 'เทจากตะกร้า      Get
        Return m_oldStockQty
      End Get
      Set(ByVal Value As Decimal)
        m_oldStockQty = Value
      End Set
    End Property    Public Property OldQty2() As Decimal 'คีย์โค้ดเองแล้ว enter      Get
        Return m_oldStockQty2
      End Get
      Set(ByVal Value As Decimal)
        m_oldStockQty2 = Value
      End Set
    End Property    Public ReadOnly Property StockQty() As Decimal
      Get
        Return Me.Conversion * Me.Qty
      End Get
    End Property    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property    Public Property UnitCost() As Decimal      Get        Return m_unitCost      End Get      Set(ByVal Value As Decimal)        m_unitCost = Value      End Set    End Property    Public ReadOnly Property Amount() As Decimal      Get
        If Me.UnitCost = Decimal.MinValue Then
          Return 0
        End If
        Return Me.StockQty * Me.UnitCost
      End Get
    End Property    Public Property TransferUnitPrice() As Decimal
      Get
        Return m_transferUnitPrice
      End Get
      Set(ByVal Value As Decimal)
        m_transferUnitPrice = Value
      End Set
    End Property    Public ReadOnly Property TransferAmount() As Decimal Implements IWBSAllocatableItem.ItemAmount
      Get
        'If Me.TransferUnitPrice = Decimal.MinValue Then
        '  Return 0
        'End If
        'Return Me.Qty * Me.TransferUnitPrice
        Return m_transferamount
      End Get
    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub Clear()
      Me.m_entity = New BlankItem("")
      Me.m_qty = 0
      Me.m_unit = New Unit
      Me.TransferUnitPrice = 0
      Me.m_unitCost = 0
      Me.m_note = ""
    End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim proposedUnit As Object = row("stocki_unit")
      Dim proposedCode As Object = row("Code")
      Dim proposedDescription As Object = row("stocki_itemName")
      Dim proposedQty As Object = row("stocki_qty")
      Dim stocki_transferUnitPrice As Object = row("stocki_transferUnitPrice")

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim isBlankRow As Boolean = False
      If (IsDBNull(proposedUnit) OrElse CStr(proposedUnit).Length = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode).Length = 0) _
          And (IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0) _
          And (IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
          Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(proposedUnit) Then
          row.SetColumnError("Unit", myStringParserService.Parse("${res:Global.Error.UnitMissing}"))
        Else
          row.SetColumnError("Unit", "")
        End If

        If IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0 Then
          row.SetColumnError("stocki_itemName", myStringParserService.Parse("${res:Global.Error.ItemMissing}"))
        Else
          row.SetColumnError("stocki_itemName", "")
        End If

        If IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0 Then
          row.SetColumnError("stocki_qty", myStringParserService.Parse("${res:Global.Error.QtyMissing}"))
        Else
          row.SetColumnError("stocki_qty", "")
        End If
      End If
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.MatReturn.IsInitialized = False
      row("stocki_linenumber") = Me.LineNumber
      row("stocki_sequence") = Me.Sequence
      If Not Me.Entity Is Nothing Then
        row("stocki_entity") = Me.Entity.Id
        row("Code") = Me.Entity.Code
        row("stocki_itemName") = Me.Entity.Name
      End If
      If Not Me.Unit Is Nothing Then
        row("stocki_unit") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If
      Me.Conversion = 1
      If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
        If TypeOf Me.Entity Is LCIItem Then
          Dim lci As LCIItem = CType(Me.Entity, LCIItem)
          Me.Conversion = lci.GetConversion(Me.Unit)
        Else
          Me.Conversion = 1
        End If
      End If
      If Me.Qty <> 0 Then
        row("stocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      Else
        row("stocki_qty") = ""
      End If
      If Me.UnitCost <> 0 Then
        row("stocki_unitcost") = Configuration.FormatToString(Me.UnitCost, DigitConfig.Cost)
      Else
        row("stocki_unitcost") = ""
      End If
      If Me.StockQty <> 0 Then
        row("StockQty") = Configuration.FormatToString(Me.StockQty, DigitConfig.Qty)
      Else
        row("StockQty") = ""
      End If
      If Me.TransferUnitPrice = Decimal.MinValue Then
        row("stocki_transferUnitPrice") = DBNull.Value
      Else
        row("stocki_transferUnitPrice") = Configuration.FormatToString(Me.TransferUnitPrice, DigitConfig.UnitPrice)
      End If
      If Me.TransferAmount <> 0 Then
        row("stocki_transferamt") = Configuration.FormatToString(Me.TransferAmount, DigitConfig.Price)
      Else
        row("stocki_transferamt") = DBNull.Value
      End If
      row("stocki_note") = Me.Note
      Me.MatReturn.IsInitialized = True
    End Sub
    Public Sub UpdateWBSQty()
      For Each wbsd As WBSDistribute In Me.InWbsdColl
        'Dim bfTax As Decimal = 0
        'Dim oldVal As Decimal = wbsd.TransferAmount
        'Dim transferAmt As Decimal = Me.Amount
        'wbsd.BaseCost = bfTax
        'wbsd.TransferBaseCost = transferAmt
        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, 42)
        If boqConversion = 0 Then
          wbsd.BaseQty = Me.Qty
        Else
          wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
        End If

        'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
      For Each wbsd As WBSDistribute In Me.OutWbsdColl
        'Dim bfTax As Decimal = 0
        'Dim oldVal As Decimal = wbsd.TransferAmount
        'Dim transferAmt As Decimal = Me.Amount
        'wbsd.BaseCost = bfTax
        'wbsd.TransferBaseCost = transferAmt
        Dim boqConversion As Decimal = wbsd.WBS.GetBoqItemConversion(Me.Entity.Id, Me.Unit.Id, 42)
        If boqConversion = 0 Then
          wbsd.BaseQty = Me.Qty
        Else
          wbsd.BaseQty = Me.Qty * (Me.Conversion / boqConversion)
        End If

        'Me.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("Percent", wbsd.TransferAmount, oldVal))
      Next
    End Sub
#End Region

#Region "IWBSAllocatableItem"

    Public ReadOnly Property AllowWBSAllocateFrom As Boolean Implements IAllowWBSAllocatableItem.AllowWBSAllocateFrom
      Get
        Return True
      End Get
    End Property

    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IAllowWBSAllocatableItem.AllowWBSAllocateTo
      Get
        Return True
      End Get
    End Property

    Public ReadOnly Property AllocationErrorMessage As String Implements IWBSAllocatableItem.AllocationErrorMessage
      Get
        Return ""
      End Get
    End Property

    Public ReadOnly Property AllocationType As String Implements IWBSAllocatableItem.AllocationType
      Get
        Return "mat"
      End Get
    End Property

    Public ReadOnly Property Description As String Implements IWBSAllocatableItem.Description
      Get
        Return Me.Entity.Code & " : " & Trim(Me.Entity.Name)
      End Get
    End Property

    Public ReadOnly Property Type As String Implements IWBSAllocatableItem.Type
      Get
        Dim strType As String = CodeDescription.GetDescription("stocki_enitytype", 42)
        Return strType
      End Get
    End Property

#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class MatReturnItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_MatReturn As MatReturn
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As MatReturn, ByVal group As Boolean)
      Me.m_MatReturn = owner
      If Not Me.m_MatReturn.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMatReturnItems" _
      , New SqlParameter("@stock_id", Me.m_MatReturn.Id) _
      , New SqlParameter("@grouping", group) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New MatReturnItem(row, "")
        item.MatReturn = m_MatReturn
        Me.Add(item)
        If Not group Then
          Dim inWbsdColl As WBSDistributeCollection = New WBSDistributeCollection
          item.InWbsdColl = inWbsdColl
          For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & row("stocki_sequence").ToString & "and stockiw_direction=0")
            Dim wbsd As New WBSDistribute(wbsRow, "")
            inWbsdColl.Add(wbsd)
          Next
          Dim outWbsdColl As WBSDistributeCollection = New WBSDistributeCollection
          item.OutWbsdColl = outWbsdColl
          For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & row("stocki_sequence").ToString & "and stockiw_direction=1")
            Dim wbsd As New WBSDistribute(wbsRow, "")
            outWbsdColl.Add(wbsd)
          Next
        Else
          Dim inWbsdColl As WBSDistributeCollection = New WBSDistributeCollection
          item.InWbsdColl = inWbsdColl
          For Each wbsRow As DataRow In ds.Tables(1).Select("stocki_linenumber=" & row("stocki_linenumber").ToString & "and stockiw_direction=0")
            Dim wbsd As New WBSDistribute(wbsRow, "")
            inWbsdColl.Add(wbsd)
          Next
          Dim outWbsdColl As WBSDistributeCollection = New WBSDistributeCollection
          item.OutWbsdColl = outWbsdColl
          For Each wbsRow As DataRow In ds.Tables(1).Select("stocki_linenumber=" & row("stocki_linenumber").ToString & "and stockiw_direction=1")
            Dim wbsd As New WBSDistribute(wbsRow, "")
            outWbsdColl.Add(wbsd)
          Next
        End If
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property MatReturn() As MatReturn      Get        Return m_MatReturn      End Get      Set(ByVal Value As MatReturn)        m_MatReturn = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As MatReturnItem
      Get
        Return CType(MyBase.List.Item(index), MatReturnItem)
      End Get
      Set(ByVal value As MatReturnItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each mwi As MatReturnItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        mwi.CopyToDataRow(newRow)
        newRow.Tag = mwi
        mwi.ItemValidateRow(newRow)
        newRow.Tag = mwi
      Next
      dt.AcceptChanges()
    End Sub
#End Region

#Region "Collection Methods"
    Public Overridable Function Add(ByVal value As MatReturnItem) As Integer
      If Not m_MatReturn Is Nothing Then
        value.MatReturn = m_MatReturn
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As MatReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As MatReturnItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As MatReturnItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As MatReturnItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As MatReturnItemEnumerator
      Return New MatReturnItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As MatReturnItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Overridable Sub Insert(ByVal index As Integer, ByVal value As MatReturnItem)
      If Not m_MatReturn Is Nothing Then
        value.MatReturn = m_MatReturn
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As MatReturnItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As MatReturnItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class MatReturnItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As MatReturnItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, MatReturnItem)
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
