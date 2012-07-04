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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  '  Public Class MatWithdrawType
  '    Inherits CodeDescription

  '#Region "Constructors"
  '    Public Sub New()
  '      MyBase.New()
  '    End Sub
  '    Public Sub New(ByVal value As Integer)
  '      MyBase.New(value)
  '    End Sub
  '#End Region

  '#Region "Properties"
  '    Public Overrides ReadOnly Property CodeName() As String
  '      Get
  '        Return "matwithdraw_type"
  '      End Get
  '    End Property
  '#End Region

  '  End Class
  Public Class MatReceipt
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPrintableEntity, IHasToCostCenter, IHasFromCostCenter, ICancelable, ICheckPeriod, IWBSAllocatable, IExtender, IHasAppStoreColl _
      , INewGLAble, INewPrintableEntity, IDocStatus

#Region "Members"
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_MTDate As Date 'เอกสารโอนเดิม
    Private m_note As String
    Private m_otherDocCode As String

    Private m_costCenter As CostCenter
    Private m_fromCostCenter As CostCenter
    Private m_toCostCenter As CostCenter
    Private m_fromCostCenterPerson As Employee
    Private m_toCostCenterPerson As Employee
    Private m_asset As Asset
    Private m_type As MatTransferType
    Private m_diffAmountFIFO As Decimal
    Private m_isinitialized As Boolean


    Private m_je As JournalEntry

    Private m_grouping As Boolean

    Private m_itemCollection As MatReceiptItemCollection

    Public MatActualHashIn As Hashtable
    Public MatActualHashOut As Hashtable

    Private m_approvalCollection As ApprovalStoreCommentCollection
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
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docDate = Now.Date
        .m_olddocDate = Now.Date
        .m_costCenter = New CostCenter
        .m_fromCostCenter = New CostCenter
        .m_fromCostCenterPerson = New Employee
        .m_toCostCenter = New CostCenter
        .m_toCostCenterPerson = New Employee
        .m_asset = New Asset
        .m_type = New MatTransferType(-1)
        .Status = New StockStatus(-1)
        .m_note = ""
        .m_grouping = True

        '----------------------------Tab Entities-----------------------------------------

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      m_itemCollection = New MatReceiptItemCollection(Me, m_grouping)
      MatActualHashIn = New Hashtable
      MatActualHashOut = New Hashtable
      m_approvalCollection = New ApprovalStoreCommentCollection(Me)
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


        If dr.Table.Columns.Contains(aliasPrefix & "stock_tag") AndAlso Not dr.IsNull(aliasPrefix & "stock_tag") Then
          Me.m_type.Value = CInt(dr(aliasPrefix & "stock_tag"))
        End If

        'วันที่โอนย้ายไปไว้ที่ stock_otherdocdate แล้วเอาวันรับมาทับ

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If


        If dr.Table.Columns.Contains("stock_otherdocDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_otherdocDate") Then
          .m_MTDate = CDate(dr(aliasPrefix & "stock_otherdocDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If


        If dr.Table.Columns.Contains(aliasPrefix & "_asset") Then
          If Not dr.IsNull(aliasPrefix & "_asset") Then
            .m_asset = New Asset(CInt(dr(aliasPrefix & "_asset")))
          End If
        Else
          If dr.Table.Columns.Contains("stock_asset") AndAlso Not dr.IsNull("stock_asset") Then
            .m_asset = New Asset(CInt(dr("stock_asset")))
          End If
        End If
        If dr.Table.Columns.Contains("stock_diffAmt") AndAlso Not dr.IsNull(aliasPrefix & "stock_diffAmt") Then
          .m_diffAmountFIFO = CDec(dr(aliasPrefix & "stock_diffAmt"))
        End If
        If dr.Table.Columns.Contains("stock_entity") AndAlso Not dr.IsNull(aliasPrefix & "stock_entity") Then
          .StockEntity = CInt(dr(aliasPrefix & "stock_entity"))
        End If
        'm_otherDocCode

        m_je = New JournalEntry(Me)
        If m_je.DocDate = Date.MinValue Then
          m_je.DocDate = Me.DocDate
        End If
        m_itemCollection = New MatReceiptItemCollection(Me, m_grouping)
        MatActualHashIn = New Hashtable
        MatActualHashOut = New Hashtable
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
      Me.m_approvalCollection = New ApprovalStoreCommentCollection(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property ApprovalCollection As ApprovalStoreCommentCollection Implements IHasAppStoreColl.ApprovalCollection
      Get
        Return m_approvalCollection
      End Get
      Set(ByVal value As ApprovalStoreCommentCollection)
        m_approvalCollection = value
      End Set
    End Property
    Public Property ItemCollection() As MatReceiptItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As MatReceiptItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        Me.m_je.DocDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property
    Public Property MatTransferDocDate() As Date
      Get
        Return m_MTDate
      End Get
      Set(ByVal Value As Date)
        m_MTDate = Value
      End Set
    End Property
    Public Property StockEntity As Integer
    'Public Overrides AutoCodeFormat As AutoCodeFormat

    Public Property Type() As MatTransferType
      Get
        Return m_type
      End Get
      Set(ByVal Value As MatTransferType)
        m_type = Value
        ValidateCCandType()
      End Set
    End Property
    Public Property Note() As String Implements IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Sub ValidateCCandType()
      If m_fromCostCenter.Id = m_toCostCenter.Id Then
        Me.Type.Value = 1 'WIP
        Me.Type.Locked = True
      Else
        Me.Type.Locked = False
      End If
    End Sub
    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get
        Return m_fromCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        If Not Me.ToCostCenter Is Nothing Then
          If Value.Id = Me.ToCostCenter.Id Then
            Dim str As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim msg As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
            msg.ShowMessage(str.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatTransfer.FromCCAndToCC}"))
            Return
          End If
        End If
        m_fromCostCenter = Value
        ValidateCCandType()
      End Set
    End Property
    Public Property ToCostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter
      Get
        Return m_toCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        If Not Me.FromCostCenter Is Nothing Then
          If Me.FromCostCenter.Id = Value.Id Then
            Dim str As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Dim msg As MessageService = CType(ServiceManager.Services.GetService(GetType(MessageService)), MessageService)
            msg.ShowMessage(str.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatTransfer.FromCCAndToCC}"))
            Return
          End If
        End If
        m_toCostCenter = Value
        ValidateCCandType()
      End Set
    End Property
    Public Property FromCostCenterPerson() As Employee
      Get
        Return m_fromCostCenterPerson
      End Get
      Set(ByVal Value As Employee)
        m_fromCostCenterPerson = Value
      End Set
    End Property
    Public Property ToCostCenterPerson() As Employee
      Get
        Return m_toCostCenterPerson
      End Get
      Set(ByVal Value As Employee)
        m_toCostCenterPerson = Value
      End Set
    End Property

    Public Property Asset() As Asset
      Get
        Return m_asset
      End Get
      Set(ByVal Value As Asset)
        m_asset = Value
      End Set
    End Property

    Public ReadOnly Property ToAccount() As Account
      Get
        Select Case Me.Type.Value
          Case 1 'WIP
            Return Me.ToCostCenter.WipAccount
          Case 2 'EXP
            Return Me.ToCostCenter.ExpenseAccount
          Case 3 'Store
            Return Me.ToCostCenter.StoreAccount
        End Select
      End Get
    End Property
    Public Overridable Property Grouping() As Boolean
      Get
        Return m_grouping
      End Get
      Set(ByVal Value As Boolean)
        m_grouping = Value
      End Set
    End Property
    Public Property CostCenter() As CostCenter
      Get
        Return m_costCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_costCenter = Value
      End Set
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        If Me.ItemCollection Is Nothing Then
          Return 0
        End If
        Dim ret As Decimal = 0
        For Each item As MatReceiptItem In Me.ItemCollection
          ret += item.ItemCollectionPrePareCost.CostAmount
        Next
        'If Not Me.Grouping Then
        '  For Each item As MatWithdrawItem In Me.ItemCollection
        '    ret += (item.UnitCost * item.StockQty)
        '  Next
        'Else
        '  For Each item As MatWithdrawItem In Me.ItemCollection
        '    ret += item.TransferAmount
        '  Next
        'End If
        Return ret
      End Get
    End Property
    Public ReadOnly Property DiffAmountFIFO As Decimal
      Get
        Return m_diffAmountFIFO
      End Get
    End Property

    Public ReadOnly Property TransferGross() As Decimal
      Get
        If Me.ItemCollection Is Nothing Then
          Return 0
        End If
        Dim ret As Decimal = 0
        For Each item As MatReceiptItem In Me.ItemCollection
          ret += item.TransferAmount
        Next
        Return ret
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "matreceipt"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatReceipt.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.MatReceipt"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.MatReceipt"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatReceipt.ListLabel}"
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
      Dim myDatatable As New TreeTable("MatReceipt")
      myDatatable.Columns.Add(New DataColumn("pri_pr", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pr_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("pri_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pri_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("PRItemCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PRItemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PRItemUnit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_qty", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("PRItemRemainingQty", GetType(Decimal)))

      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("defaultunit", GetType(String)))
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
    'Public Sub RefreshApproveCommentList()
    '  Me.ApprovalCollection = New ApprovalStoreCommentCollection(Me)
    'End Sub
    Public Sub SetAutoCodeFormat(ByVal CurrentUserId As Integer)
      If Me.StockEntity > 0 Then
        Dim arr As List(Of AutoCodeFormat) = BusinessLogic.Entity.GetNewAutoCodeFormats(343, CurrentUserId)
        For Each autoCode As AutoCodeFormat In arr
          If autoCode.Id = Me.StockEntity Then
            Me.AutoCodeFormat = autoCode
          End If
        Next
      End If
    End Sub
    Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal isOut As Boolean)
      If Not isOut Then
        myWbs = New WBS(myWbs.Id)
        Dim o_n As OldNew
        Dim theHash As Hashtable
        theHash = MatActualHashIn
        If Not theHash Is Nothing Then
          If theHash.Contains(myWbs.Id) Then
            o_n = CType(theHash(myWbs.Id), OldNew)
          Else
            o_n = New OldNew
            o_n.OldValue = myWbs.GetActualMat(Me, 45)
            o_n.NewValue = o_n.OldValue
            theHash(myWbs.Id) = o_n
          End If
          o_n.NewValue += (newVal - oldVal)

          'ส่งต่อไปยังแม่
          If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
            SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, isOut)
          End If
        End If
      Else
        myWbs = New WBS(myWbs.Id)
        Dim o_n As OldNew
        Dim theHash As Hashtable
        theHash = MatActualHashOut
        If Not theHash Is Nothing Then
          If theHash.Contains(myWbs.Id) Then
            o_n = CType(theHash(myWbs.Id), OldNew)
          Else
            o_n = New OldNew
            o_n.OldValue = myWbs.GetActualMat(Me, 45)
            o_n.NewValue = o_n.OldValue
            theHash(myWbs.Id) = o_n
          End If
          o_n.NewValue += (newVal - oldVal)

          'ส่งต่อไปยังแม่
          If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
            SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, isOut)
          End If
        End If
      End If
    End Sub
    Public Function GetCurrentDiffForWBS(ByVal myWbs As WBS, ByVal isOut As Boolean) As Decimal
      If Not isOut Then
        Dim theHash As Hashtable

        theHash = MatActualHashIn

        If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
          Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
          Return o_n.NewValue - o_n.OldValue
        End If
        Return 0
      Else
        Dim theHash As Hashtable

        theHash = MatActualHashOut

        If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
          Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
          Return o_n.NewValue - o_n.OldValue
        End If
        Return 0
      End If
    End Function
    Public Function GetRemainLCIItem(ByVal lci_id As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetRemainLCIItemForCC" _
                , New SqlParameter("@lci_id", lci_id) _
                , New SqlParameter("@cc_id", Me.ValidIdOrDBNull(Me.FromCC)) _
                , New SqlParameter("@doc_id", Me.Id) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)("remain"))
          End If
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
      Return 0
    End Function
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal isOut As Boolean) As Decimal
      Dim ret As Decimal = 0
      For Each item As MatReceiptItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        Dim view As Integer = 45
        'If Not isOut Then
        coll = item.WBSDistributeCollection
        view = 31
        'Else
        '  coll = item.OutWbsdColl
        '  view = 45
        'End If
        For Each grWBSD As WBSDistribute In coll
          If Not grWBSD.IsMarkup Then
            'Dim amt As Decimal = WBSDistribute.GetUsedAmount(item.TransferAmount, item.Amount, isOut, view, Me.Type.Value)
            Dim amt As Decimal = WBSDistribute.GetUsedAmount(item.ItemCollectionPrePareCost.CostAmount, item.Amount, isOut, view, Me.Type.Value)
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
      For Each item As MatReceiptItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        'If Not isOut Then
        coll = item.WBSDistributeCollection
        'Else
        'coll = item.OutWbsdColl
        'End If
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
      For Each item As MatReceiptItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        Dim view As Integer = 45
        'If Not isOut Then
        coll = item.WBSDistributeCollection
        view = 31
        'Else
        'coll = item.OutWbsdColl
        'view = 45
        'End If
        For Each grWBSD As WBSDistribute In coll
          If Not grWBSD.IsMarkup Then
            Dim qty As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, Me.Type.Value)
            If grWBSD.WBS.IsDescendantOf(myWbs) Then
              ret += (grWBSD.Percent * qty / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As POItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      If Me.CostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If
      'GROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      Dim idList As String = Me.ListWbsId
      Dim dsParentBudget As New DataSet
      dsParentBudget = WBS.GetParentsBudgetList(Me.EntityId, idList)
      Dim currwbsId As Integer
      Dim dt As New DataTable

      If Not onlyCC Then
        'For Each item As MatReceiptItem In Me.ItemCollection
        '  Dim inwsdColl As WBSDistributeCollection = item.WBSDistributeCollection
        '  If inwsdColl.Count = 0 Then
        '    Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
        '    Dim totalBudget As Decimal = 0
        '    Dim totalActual As Decimal = 0
        '    Dim totalCurrentDiff As Decimal = item.ItemCollectionPrePareCost.CostAmount
        '    totalBudget = rootWBS.GetTotalMatFromDB
        '    totalActual = rootWBS.GetActualMat(Me, 31)
        '    If totalBudget < (totalActual + totalCurrentDiff) Then
        '      Return True
        '    End If
        '  End If

        '  For Each wbsd As WBSDistribute In inwsdColl
        '    If wbsd.AmountOverBudget Then
        '      Return True
        '    End If
        '    Dim rootWBS As New WBS(wbsd.WBS.Id)
        '    Dim totalBudget As Decimal = 0
        '    Dim totalActual As Decimal = 0
        '    Dim totalCurrentDiff As Decimal = 0
        '    totalCurrentDiff = GetCurrentAmountForWBS(rootWBS, False)
        '    For Each row As DataRow In rootWBS.GetParentsBudget(Me.EntityId, wbsd.CostCenter.Id)
        '      totalBudget = 0
        '      totalActual = 0
        '      If Not row.IsNull("matbudget") Then
        '        totalBudget = CDec(row("matbudget"))
        '      End If
        '      If Not row.IsNull("matactual") Then
        '        totalActual = CDec(row("matactual"))
        '      End If
        '      If totalBudget < (totalActual + totalCurrentDiff) Then
        '        Return True
        '      End If
        '    Next
        '  Next

        'Next
        For Each item As MatReceiptItem In Me.ItemCollection
          Dim totalBudget As Decimal = 0
          Dim totalActual As Decimal = 0
          Dim totalCurrent As Decimal = 0
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            totalCurrent = (wbsd.Percent / 100) * item.Amount

            'สำหรับ WBS ตัวมันเอง =====>>
            If wbsd.BudgetRemain - totalCurrent < 0 Then
              Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
            End If
            'สำหรับ WBS ตัวมันเอง =====<<

            currwbsId = wbsd.WBS.Id
            For Each drow As DataRow In dsParentBudget.Tables(0).Select("depend_wbs=" & currwbsId)
              Dim drh As New DataRowHelper(drow)

              totalBudget = 0
              totalActual = 0
              totalBudget = drh.GetValue(Of Decimal)("matbudget")
              totalActual = drh.GetValue(Of Decimal)("matactual")
              If totalBudget < (totalActual + wbsd.Amount) Then
                Dim myId As Integer = drh.GetValue(Of Integer)("depend_parent")
                Dim myWBS As New WBS(myId)
                Return New SaveErrorException(myWBS.Code & ":" & myWBS.Name)
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
          Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        End If
      End If
      Return New SaveErrorException("0")

    End Function
    Private Function VerrifyCost() As String
      For Each item As MatReceiptItem In Me.ItemCollection
        Dim currCostCollection As New StockCostItemCollection(item.Entity, Me.FromCostCenter, item.StockQty, Me.Id)
        If item.ItemCollectionPrePareCost.Count <> currCostCollection.Count Then
          Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange}") & vbCrLf & _
               Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange2}") & vbCrLf & _
               Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange3}")
        End If
        For i As Integer = 0 To item.ItemCollectionPrePareCost.Count - 1
          If item.ItemCollectionPrePareCost(i).UnitCost = currCostCollection(i).UnitCost AndAlso _
             item.ItemCollectionPrePareCost(i).StockQty = currCostCollection(i).StockQty Then
            Return ""
          Else
            Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange}") & vbCrLf & _
                   Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange2}") & vbCrLf & _
                   Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange3}")
          End If
        Next
      Next
      Return ""
    End Function
    Private Sub ResetId(ByVal oldid As Integer, ByVal oldjeid As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldjeid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      If Not Me.m_je.ManualFormat Then
        m_je.SetGLFormat(Me.GetDefaultGLFormat)
      End If

      Return New SaveErrorException("0")

    End Function
    Public Function ValidateItems() As SaveErrorException

      Dim config As Boolean = CBool(Configuration.GetConfig("AllowOverWithdrawStock"))

      Dim remaining As Decimal = 0
      For Each item As MatReceiptItem In Me.ItemCollection
        If Not config Then
          If Not item.Pritem Is Nothing AndAlso Not item.Pritem.Pr Is Nothing AndAlso item.Pritem.Pr.Originated Then
            remaining = item.AllowWithdrawFromPR()
          Else
            remaining = item.MatReceipt.GetRemainLCIItem(item.Entity.Id) 'item.GetAmountFromSproc(item.Entity.Id, Me.FromCC.Id)
          End If
          remaining = remaining / item.Conversion 'หน่วยปัจจุบัน

          Dim xCompare As String = Configuration.FormatToString(item.Qty, DigitConfig.Price)
          Dim yCompare As String = Configuration.FormatToString(remaining, DigitConfig.Price)

          If item.Qty > remaining Then
            Dim str As String = My.Resources.MatReceipt_OverStock
            str = String.Format(str, xCompare, yCompare)
            Return New SaveErrorException(str)
          End If
        Else
          'If Not msgServ.AskQuestionFormatted("", "${res:Longkong.Pojjaman.Gui.Panels.MatTransferDetailView.InvalidQty}", New String() {xCompare, yCompare}) Then
          '  e.ProposedValue = (remaining / doc.Conversion)
          '  doc.Qty = e.ProposedValue
          '  Return
          'End If
        End If
      Next

      Return New SaveErrorException("0")
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
      conn.Open()
      'trans = conn.BeginTransaction()
      Try

        Dim mainsave As SaveErrorException = Save(currentUserId, conn, trans)
        If Not IsNumeric(mainsave.Message) Then
          Return New SaveErrorException(mainsave.Message)
        End If

        '--Sub Save Block-- ============================================================
        Try
          Dim subsaveerror3 As SaveErrorException = SubSaveJeAtom(conn)
          If Not IsNumeric(subsaveerror3.Message) Then
            Return New SaveErrorException(" Save Incomplete Please Save Again")
          End If
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try

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
    End Function
    'Public Property AutoCodeFormat As String
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      With Me

        Dim isDocApproved As Boolean = ApprovalStoreComment.IsReceiveDocReceivpt(Me.Id, Me.EntityId)

        If Not isDocApproved Then
          'check over budget
          Dim ValidateOverBudgetError As SaveErrorException
          Dim overbudgetconfig As Integer = CInt(Configuration.GetConfig("GROverBudget"))
          Select Case overbudgetconfig
            Case 0 'Not allow
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.OverBudgetCannotSaved}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                Return New SaveErrorException(msgString & vbCrLf & msgString2)
              End If
            Case 1 'Warn
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.AcceptOverBudget}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                If Not msgServ.AskQuestion(msgString2 & vbCrLf & msgString) Then
                  Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
                End If
              End If
            Case 2 'Do Nothing
          End Select

          'Dim ValidItemsError As SaveErrorException = Me.ValidateItems
          'If Not IsNumeric(ValidItemsError.Message) Then
          '  Return ValidItemsError
          'End If
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

        If m_approvalCollection.IsApproved Then
          Me.m_je.DontSave = False
        Else
          Me.m_je.DontSave = True
        End If
        Me.m_je.RefreshGLFormat()
        If Not AutoCodeFormat Is Nothing AndAlso Not AutoCodeFormat.Format Is Nothing Then

          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              'If Me.AutoGen Then 'And Me.Code.Length = 0 Then
              '  Me.Code = Me.GetNextCode
              'End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              'ตาม entity
              'If Me.AutoGen Then 'And Me.Code.Length = 0 Then
              '  Me.Code = Me.GetNextCode
              'End If
              Me.m_je.Code = Me.Code 'AutoCodeFormat.Format
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              'Me.Code = Me.m_je.Code
            Case Else
              'แยก
              'If Me.AutoGen Then 'And Me.Code.Length = 0 Then
              '  Me.Code = Me.GetNextCode
              'End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          'If Me.AutoGen Then 'And Me.Code.Length = 0 Then
          '  Me.Code = Me.GetNextCode
          'End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_je.DocDate = Me.DocDate

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

        ' สร้าง SqlParameter จาก ArrayList ...
        'Dim sqlparams() As SqlParameter
        'sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        'Dim trans As SqlTransaction
        'Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
        'conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldjeid As Integer = Me.m_je.Id

        Try
          Try
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMTDocdate", New SqlParameter("@stock_id", Me.Id), _
                                                                                                       New SqlParameter("@stock_docdate", Me.DocDate))
          Catch ex As SqlException
            trans.Rollback()
            ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          End Try

          'Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          'If IsNumeric(returnVal.Value) Then
          '  Select Case CInt(returnVal.Value)
          '    Case -1, -2, -5
          '      trans.Rollback()
          '      ResetId(oldid, oldjeid)
          '      Return New SaveErrorException(returnVal.Value.ToString)
          '    Case Else
          '  End Select
          'ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          '  trans.Rollback()
          '  ResetId(oldid, oldjeid)
          '  Return New SaveErrorException(returnVal.Value.ToString)
          'End If

          Dim saveApproveError As SaveErrorException = m_approvalCollection.SaveApproveComment(conn, trans)
          If Not IsNumeric(saveApproveError.Message) Then
            trans.Rollback()
            ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return saveApproveError
          Else
            Select Case CInt(saveApproveError.Message)
              Case -1, -2, -5
                'trans.Rollback()
                ResetId(oldid, oldjeid)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveApproveError
              Case Else
            End Select
          End If

          If Not m_approvalCollection.IsApproved Then
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DisApproveMatReceipt", New SqlParameter("@stock_id", Me.Id))
          Else
            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveDetailError
            Else
              Select Case CInt(saveDetailError.Message)
                Case -1, -2, -5
                  'trans.Rollback()
                  ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveDetailError
                Case Else
              End Select
            End If

            '==============================STOCKCOSTFIFO=========================================
            'ถ้าเอกสารนี้ถูกอ้างอิงแล้ว ก็จะไม่อนุญาติให้เปลี่ยนแปลง Cost แล้วนะ (julawut)
            If Not Me.IsReferenced Then
              SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertStockiCostFIFO", New SqlParameter("@stock_id", Me.Id), _
                                                                                                          New SqlParameter("@stock_cc", Me.FromCostCenter.Id))
            End If
            '==============================STOCKCOSTFIFO=========================================

            ''==============================Journal Entries=======================================
            'Me.ItemCollection = New MatReceiptItemCollection(Me, True, conn, trans)
            'If Me.m_je.Status.Value = -1 Then
            '  m_je.Status.Value = 3
            'End If
            ' ''********************************************
            ''If Not Me.m_je.ManualFormat Then
            ''  m_je.SetGLFormat(Me.GetDefaultGLFormat)
            ''End If
            ' ''********************************************
            'Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            'If Not IsNumeric(saveJeError.Message) Then
            '  trans.Rollback()
            '  ResetId(oldid, oldjeid)
            '  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            '  Return saveJeError
            'Else
            '  Select Case CInt(saveJeError.Message)
            '    Case -1, -5
            '      trans.Rollback()
            '      ResetId(oldid, oldjeid)
            '      ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            '      Return saveJeError
            '    Case -2
            '      'Post ไปแล้ว
            '      Return saveJeError
            '    Case Else
            '  End Select
            'End If
            ''==============================Journal Entries=======================================

            '==============================UPDATE PRITEM=========================================
            'If Me.m_approvalCollection.IsApproved Then
            '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePriWithdrawQtyWithDefaultUnit", New SqlParameter("@stock_id", Me.Id))
            'End If
            '==============================UPDATE PRITEM=========================================

            ''Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertMatReceiptReference" _
            ', New SqlParameter("@refto_id", Me.Id), New SqlParameter("@refto_type", Me.EntityId))
            ''SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePR_MAtwRef" _
            '', New SqlParameter("@refto_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            ''If Me.Status.Value = 0 Then
            ''  Me.CancelRef(conn, trans)
            ''End If
            ''trans.Commit()

            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMATWBSActual")
            ''SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateStock2WBSActual")

          End If


          trans.Commit()

        Catch ex As SqlException

          'trans.Rollback()
          ResetId(oldid, oldjeid)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          'trans.Rollback()
          ResetId(oldid, oldjeid)
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.ToString)
        Finally
          'conn.Close()
        End Try

        '--JE Save Block-- ============================================================
        If Not Me.m_je.DontSave Then
          'ถึง error อันแรกก็ผ่านไปแล้ว  reset เฉพาะ GL ได้
          oldid = Me.Id
          oldcode = Me.Code
          oldautogen = Me.AutoGen
          Try

            'ถ้า Manual Format ก็ไม่ต้องทำเลย
            If Not Me.JournalEntry.ManualFormat Then
              'หา Cost ใหม่ ยอมสร้างใหม่ แต่ไม่อยู่ใน trans
              'แล้วค่อยใส trans ตอนเอาเข้า
              Me.ItemCollection = New MatReceiptItemCollection(Me, True)
              '********************************************
              'ต้องบอกให้มัน refresh gl เอา Cost ขึ้นมาให้ด้วย
              Me.OnGlChanged()

              Dim glf As GLFormat = Me.GetDefaultGLFormat
              If Not glf Is Nothing Then
                m_je.SetGLFormat(Me.GetDefaultGLFormat)
              End If
            End If
            '********************************************
          Catch ex As Exception
            Return New SaveErrorException(" Save Incomplete Please Save Again (JE)")
          End Try

          Dim transJe As SqlTransaction = conn.BeginTransaction()
          Try


            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If

            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, transJe)
            If Not IsNumeric(saveJeError.Message) Then
              transJe.Rollback()
              Me.ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  transJe.Rollback()
                  Me.ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveJeError
                Case -2
                  'Post ไปแล้ว
                  Return saveJeError
                Case Else
              End Select
            End If

            transJe.Commit()

          Catch ex As Exception
            transJe.Rollback()
            Me.ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          End Try
        Else
          DeleteGL()
        End If
        '--JE Save Block-- ============================================================


        Return New SaveErrorException("1")

      End With
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======เริ่ม trans 2 ลองผิดให้ save ใหม่ ========
      Dim trans As SqlTransaction = conn.BeginTransaction

      Try
        '==============================UPDATE Old PRITEM=========================================
        'If Me.Originated AndAlso Not Me.IsReferenced Then
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteOldPriWithdrawQty", New SqlParameter("@stock_id", Me.Id))
        'End If
        '==============================UPDATE Old PRITEM=========================================
        '==============================UPDATE PRITEM=========================================
        If Me.m_approvalCollection.IsApproved Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePriWithdrawQtyWithDefaultUnit", New SqlParameter("@stock_id", Me.Id))
        End If
        '==============================UPDATE PRITEM=========================================

        'Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertMatReceiptReference" _
                                                                          , New SqlParameter("@refto_id", Me.Id) _
                                                                          , New SqlParameter("@refto_type", Me.EntityId) _
                                                                          , New SqlParameter("@IsApprove", m_approvalCollection.IsApproved))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePR_MAtwRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'If Me.Status.Value = 0 Then
        '  Me.CancelRef(conn, trans)
        'End If
        'trans.Commit()

        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromStock", New SqlParameter("@refto_id", Me.Id), New SqlParameter("@refto_type", Me.EntityId))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMATWBSActual")
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateStock2WBSActual")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
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
        Dim unitCost As Decimal = 0
        Dim Cost As Decimal = 0

        'Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in " & _
                                        "(select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ") " & _
                                        "and stockiw_direction=0", conn)

        Dim ds As New DataSet

        'Dim cmdBuilder As New SqlCommandBuilder(da)
        'da.SelectCommand.Transaction = trans
        'da.DeleteCommand = cmdBuilder.GetDeleteCommand
        'da.DeleteCommand.Transaction = trans
        'da.InsertCommand = cmdBuilder.GetInsertCommand
        'da.InsertCommand.Transaction = trans
        'da.UpdateCommand = cmdBuilder.GetUpdateCommand
        'da.UpdateCommand.Transaction = trans
        'da.InsertCommand.CommandText &= "; Select * From stockitem Where stocki_sequence = @@IDENTITY"
        'da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        'cmdBuilder = Nothing
        'da.FillSchema(ds, SchemaType.Mapped, "stockitem")
        'da.Fill(ds, "stockitem")

        'cmdBuilder = New SqlCommandBuilder(daWbs)
        Dim cmdBuilder As New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "stockiwbs")
        daWbs.Fill(ds, "stockiwbs")
        'ds.Relations.Add("sequence", ds.Tables!stockitem.Columns!stocki_sequence, ds.Tables!stockiwbs.Columns!stockiw_sequence)

        'Dim dt As DataTable = ds.Tables("stockitem")

        Dim dtWbs As DataTable = ds.Tables("stockiwbs")

        For Each row As DataRow In ds.Tables("stockiwbs").Rows
          row.Delete()
        Next

        'Dim rowsToDelete As ArrayList
        ''------------Checking if we have to delete some rows--------------------
        'rowsToDelete = New ArrayList
        'For Each dr As DataRow In dt.Rows
        '  Dim found As Boolean = False
        '  For Each testItem As MatReceiptItem In Me.ItemCollection
        '    If testItem.Sequence = CInt(dr("stocki_sequence")) Then
        '      found = True
        '      Exit For
        '    End If
        '  Next
        '  If Not found Then
        '    If Not rowsToDelete.Contains(dr) Then
        '      rowsToDelete.Add(dr)
        '    End If
        '  End If
        'Next
        'For Each dr As DataRow In rowsToDelete
        '  dr.Delete()
        'Next
        ''------------End Checking--------------------

        Dim i As Integer = 0 'Line Running
        Dim seq As Integer = -1
        For Each item As MatReceiptItem In Me.ItemCollection
          i += 1

          ''------------Checking if we have to add a new row or just update existing--------------------
          'Dim dr As DataRow
          'Dim drs As DataRow() = dt.Select("stocki_sequence=" & item.Sequence)
          'If drs.Length = 0 Then
          '  dr = dt.NewRow
          '  'dt.Rows.Add(dr)
          '  seq = seq + (-1)
          '  dr("stocki_sequence") = seq
          'Else
          '  dr = drs(0)
          'End If
          ''------------End Checking--------------------

          'If item.Pritem Is Nothing Then
          '  dr("stocki_refdoc") = DBNull.Value
          '  dr("stocki_refdoclinenumber") = DBNull.Value
          'Else
          '  dr("stocki_refdoc") = item.Pritem.Pr.Id
          '  dr("stocki_refdoclinenumber") = item.Pritem.LineNumber
          'End If
          'dr("stocki_stock") = Me.Id
          'dr("stocki_cc") = DBNull.Value
          'If Me.Grouping Then
          '  dr("stocki_linenumber") = i
          'Else
          '  dr("stocki_linenumber") = item.LineNumber
          'End If
          'dr("stocki_entity") = item.Entity.Id
          'If TypeOf item.Entity Is IObjectReflectable Then
          '  dr("stocki_entityType") = CType(item.Entity, IObjectReflectable).EntityId
          'Else
          '  dr("stocki_entityType") = 0
          'End If
          'dr("stocki_itemName") = item.Entity.Name
          'dr("stocki_unit") = item.Unit.Id
          'dr("stocki_stockqty") = item.StockQty
          'dr("stocki_toacct") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.ToAccount)
          'dr("stocki_toacctType") = Me.Type.Value
          'dr("stocki_qty") = item.Qty
          'dr("stocki_note") = item.Note
          'dr("stocki_type") = Me.EntityId
          'dr("stocki_fromcc") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.FromCostCenter)
          'dr("stocki_tocc") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.ToCostCenter)
          'dr("stocki_status") = Me.Status.Value
          'dr("stocki_refsequence") = 0  '0 ไปก่อนเดี๋ยวมี Query Update RefSequence ให้ตามหลัง
          'If item.TransferUnitPrice = Decimal.MinValue Then
          '  dr("stocki_transferunitprice") = DBNull.Value
          'Else
          '  dr("stocki_transferunitprice") = item.TransferUnitPrice
          'End If
          ''dt.Rows.Add(dr)

          ''------------Checking if we have to add a new row or just update existing--------------------
          'If drs.Length = 0 Then
          '  dt.Rows.Add(dr)
          'End If
          ''------------End Checking--------------------

          'For x As Integer = 0 To 1
          Dim rootWBS As WBS
          Dim wbsdColl As WBSDistributeCollection
          Dim currentSum As Decimal
          Dim currentCostCenter As CostCenter

          'If x = 0 Then
          rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
          wbsdColl = item.WBSDistributeCollection
          currentSum = wbsdColl.GetSumPercent
          currentCostCenter = Me.ToCostCenter
          'Else
          'rootWBS = New WBS(Me.FromCostCenter.RootWBSId)
          'wbsdColl = item.WBSDistributeCollection
          'currentSum = wbsdColl.GetSumPercent
          'currentCostCenter = Me.FromCostCenter
          'End If

          'If (x = 0 AndAlso item.AllowWBSAllocateTo) OrElse (x = 1 AndAlso item.AllowWBSAllocateFrom) Then

          Try
            For Each wbsd As WBSDistribute In wbsdColl
              If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                'ยังไม่เต็ม 100 แต่มีหัวอยู่
                wbsd.Percent += (100 - currentSum)
              End If
              Dim bfTax As Decimal = 0
              bfTax = item.UnitCost
              wbsd.BaseCost = bfTax 'item.Amount
              'wbsd.TransferBaseCost = bfTax 'item.Amount
              Dim childDr As DataRow = dtWbs.NewRow
              childDr("stockiw_sequence") = item.Sequence ' dr("stocki_sequence")
              childDr("stockiw_wbs") = wbsd.WBS.Id
              childDr("stockiw_percent") = wbsd.Percent
              childDr("stockiw_ismarkup") = wbsd.IsMarkup
              childDr("stockiw_direction") = 0 'x
              childDr("stockiw_baseCost") = wbsd.BaseCost
              childDr("stockiw_amt") = wbsd.Amount
              childDr("stockiw_toaccttype") = Me.Type.Value
              If wbsd.CostCenter Is Nothing Then
                wbsd.CostCenter = currentCostCenter
              End If
              childDr("stockiw_cc") = wbsd.CostCenter.Id
              childDr("stockiw_cbs") = wbsd.CBS.Id
              'Add เข้า sciwbs
              dtWbs.Rows.Add(childDr)
            Next
          Catch ex As Exception
            Throw New Exception(ex.Message)
          End Try

          currentSum = wbsdColl.GetSumPercent
          'ยังไม่เต็ม 100 และยังไม่มี root
          If currentSum < 100 Then
            Try
              Dim wbsd As New WBSDistribute
              wbsd.WBS = rootWBS
              wbsd.CostCenter = currentCostCenter
              wbsd.Percent = 100 - currentSum
              Dim bfTax As Decimal = 0
              bfTax = item.UnitCost
              wbsd.BaseCost = bfTax 'item.Amount
              'wbsd.TransferBaseCost = bfTax 'item.Amount
              Dim childDr As DataRow = dtWbs.NewRow

              childDr("stockiw_sequence") = item.Sequence  ' dr("stocki_sequence")
              childDr("stockiw_wbs") = wbsd.WBS.Id
              childDr("stockiw_percent") = wbsd.Percent
              childDr("stockiw_ismarkup") = wbsd.IsMarkup
              childDr("stockiw_direction") = 0 'x
              childDr("stockiw_baseCost") = wbsd.BaseCost
              childDr("stockiw_amt") = wbsd.Amount
              childDr("stockiw_toaccttype") = Me.Type.Value
              childDr("stockiw_cc") = wbsd.CostCenter.Id
              childDr("stockiw_cbs") = wbsd.CBS.Id

              'Add เข้า sciwbs
              dtWbs.Rows.Add(childDr)
            Catch ex As Exception
              Throw New Exception(ex.Message)
            End Try
          End If

          'End If '

          'Next
        Next

        'Dim tmpDa As New SqlDataAdapter
        'tmpDa.DeleteCommand = da.DeleteCommand
        'tmpDa.InsertCommand = da.InsertCommand
        'tmpDa.UpdateCommand = da.UpdateCommand

        'AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        'da_aux.Update(GetDeletedRows(dtAux))
        'tmpDa.Update(GetDeletedRows(dt))

        'tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        'da_aux.Update(dtAux.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        'tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        'da_aux.Update(dtAux.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try

    End Function
    'Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
    '  If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
    '  If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    'End Sub
    Private Sub daWbs_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        'Dim currentkey As Integer = CInt(e.Row("stockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        '' This is where you get a correct original value key stored to the child row. You yank
        '' the original pseudo key value from the parent, plug it in as the child row's primary key
        '' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        'e.Row!stockiw_sequence = e.Row.GetParentRow("sequence")("stocki_sequence", DataRowVersion.Original)
        'e.Row.AcceptChanges()
        '' Now store the actual primary key value back into the foreign key column of the child row.
        'e.Row!stockiw_sequence = currentkey
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
    Private Sub DeleteGL()
      SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "DeleteGL", _
           New SqlParameter() {New SqlParameter("@gl_id", Me.m_je.Id), New SqlParameter("@gl_docdate", Now)})
    End Sub
    'Private Function SaveWBSDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
    '  Try
    '    Dim da As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
    '    Dim cmdBuilder As New SqlCommandBuilder(da)

    '    Dim ds As New DataSet

    '    da.SelectCommand.Transaction = trans

    '    'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
    '    cmdBuilder.GetDeleteCommand.Transaction = trans
    '    cmdBuilder.GetInsertCommand.Transaction = trans
    '    cmdBuilder.GetUpdateCommand.Transaction = trans

    '    da.Fill(ds, "stockiwbs")

    '    Dim i As Integer = 0
    '    Dim dtWbs As DataTable = ds.Tables("stockiwbs")
    '    Dim rootWBS As WBS
    '    Dim currentSum As Decimal
    '    Dim Cost As Decimal = 0

    '    With dtWbs
    '      For Each row As DataRow In .Rows
    '        row.Delete()
    '      Next
    '      Dim line As Integer = 0
    '      For Each item As MatWithdrawItem In Me.ItemCollection
    '        Dim seqArr As New ArrayList
    '        line = line + 1

    '        seqArr = StockItem.GetSequenceArray(Me.Id, line)
    '        For Each row As DataRow In seqArr

    '          If Not row.IsNull("stocki_amt") Then
    '            Cost = CDec(row("stocki_amt"))
    '          Else
    '            Cost = 0
    '          End If

    '          Dim wcoll As WBSDistributeCollection

    '          For x As Integer = 0 To 1 'loop Cost Center
    '            If x = 0 Then
    '              wcoll = item.InWbsdColl
    '              currentSum = wcoll.GetSumPercent
    '              rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
    '            Else
    '              wcoll = item.OutWbsdColl
    '              currentSum = wcoll.GetSumPercent
    '              rootWBS = New WBS(Me.FromCostCenter.RootWBSId)
    '            End If

    '            Dim childDr As DataRow

    '            If wcoll.Count > 0 Then

    '              For Each wbsd As WBSDistribute In wcoll

    '                childDr = dtWbs.NewRow
    '                childDr("stockiw_wbs") = wbsd.WBS.Id

    '                If wbsd.CostCenter Is Nothing Then
    '                  If x = 0 Then
    '                    wbsd.CostCenter = Me.ToCostCenter
    '                  Else
    '                    wbsd.CostCenter = Me.FromCostCenter
    '                  End If
    '                End If

    '                If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
    '                  'ยังไม่เต็ม 100 แต่มีหัวอยู่
    '                  wbsd.Percent += (100 - currentSum)
    '                End If
    '                'wbsd.BaseCost = CDec(row("stocki_amt"))
    '                'If Not row.IsNull("stocki_amt") Then
    '                '	wbsd.BaseCost = CDec(row("stocki_amt"))								 'item.Amount
    '                'Else
    '                '	wbsd.BaseCost = 0
    '                'End If

    '                wbsd.BaseCost = Cost
    '                wbsd.TransferBaseCost = Cost

    '                childDr("stockiw_cc") = wbsd.CostCenter.Id
    '                childDr("stockiw_percent") = wbsd.Percent
    '                childDr("stockiw_sequence") = row("stocki_sequence")
    '                childDr("stockiw_ismarkup") = wbsd.IsMarkup
    '                childDr("stockiw_direction") = x
    '                childDr("stockiw_baseCost") = wbsd.BaseCost
    '                childDr("stockiw_amt") = wbsd.Amount
    '                childDr("stockiw_transferbaseCost") = wbsd.BaseCost
    '                childDr("stockiw_transferamt") = wbsd.Amount
    '                childDr("stockiw_toaccttype") = Me.Type.Value      'wbsd.Toaccttype
    '                'Add เข้า stockiwbs
    '                dtWbs.Rows.Add(childDr)

    '              Next
    '            ElseIf Not (rootWBS.Id = 0) Then
    '              childDr = dtWbs.NewRow

    '              Dim newWbsd As New WBSDistribute
    '              newWbsd.WBS = rootWBS

    '              If x = 0 Then
    '                newWbsd.CostCenter = Me.ToCostCenter
    '              Else
    '                newWbsd.CostCenter = Me.FromCostCenter
    '              End If

    '              newWbsd.Percent = 100 - currentSum
    '              'If Not row.IsNull("stocki_amt") Then
    '              '  newWbsd.BaseCost = CDec(row("stocki_amt")) 'item.Amount
    '              'Else
    '              '  newWbsd.BaseCost = 0
    '              'End If

    '              newWbsd.BaseCost = Cost
    '              newWbsd.TransferBaseCost = Cost

    '              childDr("stockiw_cc") = newWbsd.CostCenter.Id
    '              childDr("stockiw_percent") = newWbsd.Percent
    '              childDr("stockiw_sequence") = row("stocki_sequence")
    '              childDr("stockiw_ismarkup") = newWbsd.IsMarkup
    '              childDr("stockiw_wbs") = newWbsd.WBS.Id
    '              childDr("stockiw_direction") = x
    '              childDr("stockiw_baseCost") = newWbsd.BaseCost
    '              childDr("stockiw_amt") = newWbsd.Amount
    '              childDr("stockiw_transferbaseCost") = newWbsd.BaseCost
    '              childDr("stockiw_transferamt") = newWbsd.Amount
    '              childDr("stockiw_toaccttype") = Me.Type.Value  'wbsd.Toaccttype

    '              'Add เข้า stockiwbs
    '              dtWbs.Rows.Add(childDr)
    '              'End If
    '            End If
    '          Next
    '        Next
    '      Next
    '    End With
    '    ' First process deletes.
    '    da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.Deleted))
    '    ' Next process updates.
    '    da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
    '    ' Finally process inserts.
    '    da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.Added))
    '    Return New SaveErrorException("1")
    '  Catch ex As Exception
    '    Return New SaveErrorException(ex.ToString)
    '  End Try
    'End Function

    Private Function GetPritemString() As String
      Dim ret As String = "("
      For Each item As MatReceiptItem In Me.ItemCollection
        If Not item.Pritem Is Nothing Then
          ret &= "'" & item.Pritem.Pr.Id.ToString & "|" & item.Pritem.LineNumber & "',"
        End If
      Next
      ret &= "'')"
      Return ret
    End Function
    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                RecentCompanies.CurrentCompany.SiteConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , filters _
                )
        If ds.Tables(0).Rows(0).IsNull(0) Then
          Return 0
        End If
        Return CDec(ds.Tables(0).Rows(0)(0))
      Catch ex As Exception
      End Try
      Return 0
    End Function
    Private Function SavePRItemsDetail(ByVal arr As ArrayList, ByVal trans As SqlTransaction, ByVal conn As SqlConnection) As SaveErrorException
      Try
        For Each o As ValueDisplayPair In arr
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePRWithdrawnQty" _
          , New SqlParameter("@pri_pr", CInt(o.Value)) _
          , New SqlParameter("@pri_linenumber", CInt(o.Display)))
        Next
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
      Return New SaveErrorException("1")
    End Function

#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
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
      'Dim itemColl As New MatReceiptItemCollection(Me, True)
      'If itemColl Is Nothing Then
      '  Return jiColl
      'End If
      Dim map As String = ""
      Dim newRealAccount As Account
      Select Case Me.Type.Value
        Case 3 'Store
          map = "F1.1"
        Case 1 'WIP
          map = "F1.3"
          newRealAccount = Me.ToCostCenter.WipAccount
        Case 2 'Exp
          map = "F1.2"
          newRealAccount = Me.ToCostCenter.ExpenseAccount
      End Select
      Dim ji As New JournalEntryItem
      For Each item As MatReceiptItem In Me.ItemCollection 'itemColl
        Dim lciMatched As Boolean = False
        Dim lciNoAcctMatched As Boolean = False
        Dim originMatched As Boolean = False
        Dim newLci As LCIItem = CType(item.Entity, LCIItem)
        Dim newEntityAcct As Account
        If Not newLci.Account Is Nothing AndAlso newLci.Account.Originated Then
          newEntityAcct = newLci.Account
        End If
        If Me.Type.Value = 3 Then
          newRealAccount = newEntityAcct
        End If
        'For Each addedJi As JournalEntryItem In jiColl
        '  If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
        '    If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = newRealAccount.Id Then
        '      If addedJi.Mapping = map Then
        '        addedJi.Amount += item.Amount
        '        lciMatched = True
        '      End If

        '      'ต้นทาง
        '      If addedJi.Mapping = "F1.4" Then
        '        addedJi.Amount += item.Amount
        '        originMatched = True
        '      End If
        '    End If
        '  ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
        '    If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
        '      If addedJi.Mapping = map Then
        '        addedJi.Amount += item.Amount
        '        lciNoAcctMatched = True
        '      End If

        '      'ต้นทาง
        '      If addedJi.Mapping = "F1.4" Then
        '        addedJi.Amount += item.Amount
        '        originMatched = True
        '      End If
        '    End If
        '  End If
        'Next
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
          ji.Mapping = "F1.4"
          ji.Amount += item.Amount
          ji.Account = realAccount
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)

          'ฝั่งต้นทาง
          ji = New JournalEntryItem
          ji.Mapping = "F1.4D"
          ji.Amount += item.Amount
          ji.Account = realAccount
          ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.Unit.Name & ")"
          ji.EntityItem = item.Entity.Id
          ji.EntityItemType = 42
          ji.CostCenter = Me.FromCostCenter
          jiColl.Add(ji)

          If item.WBSDistributeCollection Is Nothing OrElse item.WBSDistributeCollection.Count = 0 Then
            'ฝั่งต้นทาง
            ji = New JournalEntryItem
            ji.Mapping = "F1.4W"
            ji.Amount += item.Amount
            ji.Account = realAccount
            ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.Unit.Name & ")"
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = 42
            ji.CostCenter = Me.FromCostCenter
            jiColl.Add(ji)
          Else
            For Each iwbs As WBSDistribute In item.WBSDistributeCollection
              ji = New JournalEntryItem
              ji.Mapping = "F1.4W"
              ji.Amount += iwbs.Amount
              ji.Account = realAccount
              ji.Note = item.Entity.Code & ":" & item.Entity.Name & "/" & iwbs.WBS.Code & ":" & Configuration.FormatToString(iwbs.Percent, 2) & "%"
              'ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.unit.Name & ")"
              ji.EntityItem = item.Entity.Id
              ji.EntityItemType = 42
              ji.CostCenter = Me.CostCenter
              jiColl.Add(ji)
            Next
          End If

        End If
        If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
          If Not lciMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount += item.Amount
            ji.Account = newRealAccount
            ji.CostCenter = Me.ToCostCenter
            jiColl.Add(ji)

            ji = New JournalEntryItem
            ji.Mapping = map & "D"
            ji.Amount += item.Amount
            ji.Account = newRealAccount
            ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.Unit.Name & ")"
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = 42
            ji.CostCenter = Me.ToCostCenter
            jiColl.Add(ji)

            If item.WBSDistributeCollection2 Is Nothing Then
              ji = New JournalEntryItem
              ji.Mapping = map & "W"
              ji.Amount += item.Amount
              ji.Account = newRealAccount
              ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.Unit.Name & ")"
              ji.EntityItem = item.Entity.Id
              ji.EntityItemType = 42
              ji.CostCenter = Me.ToCostCenter
              jiColl.Add(ji)
            Else
              For Each iwbs As WBSDistribute In item.WBSDistributeCollection2
                ji = New JournalEntryItem
                ji.Mapping = map & "W"
                ji.Amount += iwbs.Amount
                ji.Account = newRealAccount
                ji.Note = item.Entity.Code & ":" & item.Entity.Name & "/" & iwbs.WBS.Code & ":" & iwbs.Percent & "%"
                'ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.unit.Name & ")"
                ji.EntityItem = item.Entity.Id
                ji.EntityItemType = 42
                ji.CostCenter = Me.CostCenter
                jiColl.Add(ji)
              Next
            End If
          End If
        ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
          If Not lciNoAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount += item.Amount
            ji.CostCenter = Me.ToCostCenter
            jiColl.Add(ji)

            ji = New JournalEntryItem
            ji.Mapping = map & "D"
            ji.Amount += item.Amount
            ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.Unit.Name & ")"
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = 42
            ji.CostCenter = Me.ToCostCenter
            jiColl.Add(ji)

            If item.WBSDistributeCollection2 Is Nothing Then
              ji = New JournalEntryItem
              ji.Mapping = map & "W"
              ji.Amount += item.Amount
              ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.Unit.Name & ")"
              ji.EntityItem = item.Entity.Id
              ji.EntityItemType = 42
              ji.CostCenter = Me.ToCostCenter
              jiColl.Add(ji)
            Else

              For Each iwbs As WBSDistribute In item.WBSDistributeCollection2
                ji = New JournalEntryItem
                ji.Mapping = map & "W"
                ji.Amount += iwbs.Amount
                ji.Note = item.Entity.Code & ":" & item.Entity.Name & "/" & iwbs.WBS.Code & ":" & iwbs.Percent & "%"
                'ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.unit.Name & ")"
                ji.EntityItem = item.Entity.Id
                ji.EntityItemType = 42
                ji.CostCenter = Me.CostCenter
                jiColl.Add(ji)
              Next
            End If

          End If
        End If
      Next

      'Dim diffConversion As Decimal = 0
      'diffConversion = Me.Gross - Me.TransferGross
      'If diffConversion <> 0 Then
      '  ji = New JournalEntryItem
      '  ji.Mapping = "F1.5"
      '  ji.Amount = diffConversion
      '  ji.Account = newRealAccount
      '  ji.CostCenter = Me.ToCostCenter
      '  jiColl.Add(ji)
      'End If

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

#Region "INewGLAble"
    Public Function OnlyGenGlAtom() As SaveErrorException Implements INewGLAble.OnlyGenGLAtom
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      SubSaveJeAtom(conn)
      conn.Close()
    End Function
    Private Function SubSaveJeAtom(ByVal conn As SqlConnection) As SaveErrorException Implements INewGLAble.SubSaveJeAtom
      Me.JournalEntry.RefreshOnlyGLAtom()
      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Me.JournalEntry.SaveAutoMateDetail(Me.JournalEntry.Id, conn, trans)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try
      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Public Function NewGetJournalEntries() As JournalEntryItemCollection Implements INewGLAble.NewGetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      jiColl.AddRange(Me.NewGetItemJournalEntries)
      Return jiColl
    End Function
    Private Function NewGetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      'Dim itemColl As New MatWithdrawItemCollection(Me, False)
      'If itemColl Is Nothing Then
      '  Return jiColl
      'End If
      Dim map As String = ""
      Dim newRealAccount As Account
      Select Case Me.Type.Value
        Case 3 'Store
          map = "F1.1"
        Case 1 'WIP
          map = "F1.3"
          newRealAccount = Me.ToCostCenter.WipAccount
        Case 2 'Exp
          map = "F1.2"
          newRealAccount = Me.ToCostCenter.ExpenseAccount
      End Select
      Dim ji As New JournalEntryItem
      For Each item As MatReceiptItem In Me.ItemCollection 'itemColl
        Dim lciMatched As Boolean = False
        Dim lciNoAcctMatched As Boolean = False
        Dim originMatched As Boolean = False
        Dim newLci As LCIItem = CType(item.Entity, LCIItem)
        Dim newEntityAcct As Account
        If Not newLci.Account Is Nothing AndAlso newLci.Account.Originated Then
          newEntityAcct = newLci.Account
        End If
        If Me.Type.Value = 3 Then
          newRealAccount = newEntityAcct
        End If

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
          ji.Mapping = "F1.4"
          ji.Amount = item.Amount
          ji.Account = realAccount
          ji.CostCenter = Me.FromCostCenter
          ji.EntityItem = lci.Id
          ji.EntityItemType = 42
          ji.table = Me.TableName & "item"
          ji.AtomNote = "ต้นทางเบิกออก CostCenter " & Me.Type.Description
          jiColl.Add(ji)
        End If
        If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
          If Not lciMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount = item.Amount
            ji.Account = newRealAccount
            ji.CostCenter = Me.ToCostCenter
            ji.EntityItem = lci.Id
            ji.EntityItemType = 42
            ji.table = Me.TableName & "item"
            ji.AtomNote = "รับเบิก CostCenter " & Me.Type.Description
            jiColl.Add(ji)
          End If
        ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
          If Not lciNoAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount = item.Amount
            ji.CostCenter = Me.ToCostCenter
            ji.EntityItem = lci.Id
            ji.EntityItemType = 42
            ji.table = Me.TableName & "item"
            ji.AtomNote = "รับเบิก CostCenter " & Me.Type.Description
            jiColl.Add(ji)
          End If
        End If
      Next



      Return jiColl
    End Function
#End Region
#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "MW"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "MW"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "stock_id"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      'Type
      dpi = New DocPrintingItem
      dpi.Mapping = "Type"
      dpi.Value = Me.Type.Description
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim prList As String = ""
      Dim n As Integer = 0
      For Each item As MatReceiptItem In Me.ItemCollection
        dpi = New DocPrintingItem
        dpi.Mapping = "stocki_stock"
        dpi.Value = Me.Id
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

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

        'Item.TransferUnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.TransferUnitPrice"
        dpi.Value = Configuration.FormatToString(item.TransferUnitPrice, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.UnitCost
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UnitCost"
        dpi.Value = Configuration.FormatToString(item.UnitCost, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.TransferAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.TransferAmount"
        dpi.Value = Configuration.FormatToString(item.TransferAmount, DigitConfig.Qty)
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

        'Item.PRCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.PRCode"
        If Not item.Pritem Is Nothing AndAlso Not item.Pritem.Pr Is Nothing Then
          dpi.Value = item.Pritem.Pr.Code
          If item.Pritem.Pr.Code.Length > 0 Then
            prList &= item.Pritem.Pr.Code & ","
          End If
        Else
          dpi.Value = ""
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        n += 1
      Next

      If prList.Length > 0 Then
        prList = prList.Substring(0, prList.Length - 1)
      End If

      'PRCode
      dpi = New DocPrintingItem
      dpi.Mapping = "DescribePRCode"
      dpi.Value = prList
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TransferGross
      dpi = New DocPrintingItem
      dpi.Mapping = "TransferGross"
      dpi.Value = Configuration.FormatToString(Me.TransferGross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiffConversion
      dpi = New DocPrintingItem
      dpi.Mapping = "DiffConversion"
      dpi.Value = Configuration.FormatToString(Me.Gross - Me.TransferGross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return False
        'If Me.Originated Then
        '  Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced AndAlso Not Me.ApprovalCollection.IsApproved
        'Else
        '  Return False
        'End If
      End Get
    End Property
    Public Function DeleteExtender(ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException Implements IExtender.Delete
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Try
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteMatReceipt", _
                                  New SqlParameter("@stock_id", Me.Id), _
                                  New SqlParameter("@stock_type", Me.EntityId))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, "delete from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock =" & Me.Id & ") and stockiw_direction=0")

        '==============================UPDATE PRITEM=========================================
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePriWithdrawQty", New SqlParameter("@stock_id", Me.Id))
        '==============================UPDATE PRITEM=========================================

        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMatWBSActual")

        Return New SaveErrorException("2")
      Catch ex As SqlException

        Return New SaveErrorException(ex.Message)
      Catch ex As Exception

        Return New SaveErrorException(ex.Message)
      Finally

      End Try
    End Function
    Public Overrides Function Delete() As SaveErrorException
      'If Not Me.Originated Then
      '  Return New SaveErrorException("${res:Global.Error.NoIdError}")
      'End If
      'Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'Dim format(0) As String
      'format(0) = Me.Code
      'If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteMatReceipt}", format) Then
      '  Return New SaveErrorException("${res:Global.CencelDelete}")
      'End If
      ''  '-------------------------------------------------------
      ''  Dim pris As String = GetPritemString()
      ''  Dim sql As String = "select * from pritem where convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) " & _
      ''  "in (select convert(nvarchar,stocki_refdoc) + '|' +  convert(nvarchar,stocki_refdoclinenumber) from stockitem " & _
      ''  "where stocki_stock=" & Me.Id & ") or convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) in " & pris

      ''  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      ''RecentCompanies.CurrentCompany.SiteConnectionString _
      '', CommandType.Text _
      '', sql _
      '')
      ''  Dim arr As New ArrayList
      ''  For Each row As DataRow In ds.Tables(0).Rows
      ''    Dim o As New ValueDisplayPair(row("pri_pr"), row("pri_linenumber"))
      ''    arr.Add(o)
      ''  Next
      ''-------------------------------------------------------
      'Dim trans As SqlTransaction
      'Dim conn As New SqlConnection(Me.ConnectionString)
      'conn.Open()
      'trans = conn.BeginTransaction()
      'Try
      '  Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      '  returnVal.ParameterName = "RETURN_VALUE"
      '  returnVal.DbType = DbType.Int32
      '  returnVal.Direction = ParameterDirection.ReturnValue
      '  returnVal.SourceVersion = DataRowVersion.Current
      '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteMatReceipt", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
      '  If IsNumeric(returnVal.Value) Then
      '    Select Case CInt(returnVal.Value)
      '      Case -1
      '        trans.Rollback()
      '        Return New SaveErrorException("${res:Global.MatWithdrawIsReferencedCannotBeDeleted}")
      '      Case Else
      '    End Select
      '  ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
      '    trans.Rollback()
      '    Return New SaveErrorException(returnVal.Value.ToString)
      '  End If
      '  Me.DeleteRef(conn, trans)

      '  '==============================UPDATE PRITEM=========================================
      '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePriWithdrawQty", New SqlParameter("@stock_id", Me.Id))
      '  '==============================UPDATE PRITEM=========================================

      '  SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMatWBSActual")
      '  ''--------------------------------------------------------------
      '  'Dim oldid As Integer = Me.Id
      '  'Dim oldjeid As Integer = Me.m_je.Id
      '  'Dim savePRItemsError As SaveErrorException = Me.SavePRItemsDetail(arr, trans, conn)
      '  'If Not IsNumeric(savePRItemsError.Message) Then
      '  '  trans.Rollback()
      '  '  ResetId(oldid, oldjeid)
      '  '  Return savePRItemsError
      '  'Else
      '  '  Select Case CInt(savePRItemsError.Message)
      '  '    Case -1, -5
      '  '      trans.Rollback()
      '  '      ResetId(oldid, oldjeid)
      '  '      Return savePRItemsError
      '  '    Case -2
      '  '      'Post ไปแล้ว
      '  '      Return savePRItemsError
      '  '    Case Else
      '  '  End Select
      '  'End If
      '  ''--------------------------------------------------------------

      '  trans.Commit()
      '  Return New SaveErrorException("1")
      'Catch ex As SqlException
      '  trans.Rollback()
      '  Return New SaveErrorException(ex.Message)
      'Catch ex As Exception
      '  trans.Rollback()
      '  Return New SaveErrorException(ex.Message)
      'Finally
      '  conn.Close()
      'End Try
    End Function
#End Region

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return False 'Me.Status.Value > 1 AndAlso Me.IsCancelable AndAlso Not Me.ApprovalCollection.IsApproved
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
      For Each item As MatReceiptItem In Me.ItemCollection
        'If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
        item.UpdateWBSQty()

        If Not Me.Originated Then
          'For Each wbsd As WBSDistribute In item.OutWbsdColl
          '  wbsd.ChildAmount = 0
          '  wbsd.GetChildIdList()
          '  For Each allItem As MatReceiptItem In Me.ItemCollection
          '    For Each childWbsd As WBSDistribute In allItem.OutWbsdColl
          '      If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
          '        wbsd.ChildAmount += childWbsd.Amount
          '      End If
          '    Next
          '  Next
          'Next
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsd.ChildAmount = 0
            wbsd.GetChildIdList()
            For Each allItem As MatReceiptItem In Me.ItemCollection
              For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
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

#Region "IExtender"
    Public Function Save1(ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException Implements IExtender.Save

    End Function
#End Region

#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else
          'Dim obj As Object = Configuration.GetConfig("ApprovePR")
          'If CBool(obj) Then
          '  If Me.IsAuthorized Then
          '    Return "Authorized"
          '  ElseIf Me.IsLevelApproved Then
          '    Return "Approved"
          '  End If
          'End If
        End If
        Return ""
      End Get
    End Property
#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection

      dpiColl.RelationList.Add("general>stock_id>item>stocki_stock")

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stock_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCPersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCPersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCPersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCPersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCPersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCPersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Type", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stocki_stock", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.TransferUnitPrice", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitCost", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.TransferAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.PRCode", "System.String", "Item"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DescribePRCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Total", "System.Int32"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Gross", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransferGross", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DiffConversion", "System.String"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class

End Namespace
