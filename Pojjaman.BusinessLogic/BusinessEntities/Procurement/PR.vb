Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class PRStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pr_status"
      End Get
    End Property
#End Region

  End Class
  Public Class PR
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IApprovAble, ICancelable, IHasToCostCenter,  _
      IDuplicable, ICheckPeriod, IWBSAllocatable, IHasCurrency, IAbleExceptAccountPeriod, ICloseStatusAble,  _
      IApproveStatusAble, IShowStatusColorAble, IDocStatus, INewPrintableEntity, IDocumentPersonAble

#Region "Members"
    Private pr_docDate As Date
    Private pr_olddocDate As Date
    Private pr_receivingDate As Date
    Private pr_note As String
    Private pr_requestor As Employee
    Private pr_cc As CostCenter
    Private pr_approvePerson As User
    Private pr_approveDate As DateTime
    Private pr_approveStorePerson As User
    Private pr_approveStoreDate As DateTime

    Private pr_status As PRStatus

    Private pr_declareId As Integer
    Private pr_declareCode As String
    Private pr_declareNote As String

    Private pr_declareStatusValue As Integer

    Private m_termNote As String
    Private m_deliveryTime As String
    Private m_placeOfDelivery As String
    Private m_attachment As String
    Private m_specialCondition As String

    Private m_itemCollection As PRItemCollection

    Private m_customNoteColl As CustomNoteCollection

    Private m_approveDocColl As ApproveDocCollection

    Private m_budgetCollection As WBSDistributeCollection

    'Public BOQHASH As Hashtable
    Private m_closed As Boolean
    Private m_closedBefor As Boolean
    Public MatActualHash As Hashtable
    Public LabActualHash As Hashtable
    Public EQActualHash As Hashtable
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
        .pr_approvePerson = New User
        .pr_approveStorePerson = New User
        .pr_requestor = New Employee
        .pr_cc = New CostCenter
        .pr_status = New PRStatus(-1)
        .pr_docDate = Now.Date
        .pr_olddocDate = Now.Date

        .m_termNote = ""
        .m_deliveryTime = ""
        .m_placeOfDelivery = ""
        '.m_attachment = "..............................................................." 'PLE Only
        '.m_specialCondition = "..............................................................." 'PLE Only
        .m_closed = False
        .m_closedBefor = False
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
      m_itemCollection = New PRItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If Not dr.IsNull(aliasPrefix & "pr_docDate") Then
          .pr_docDate = CDate(dr(aliasPrefix & "pr_docDate"))
          .pr_olddocDate = CDate(dr(aliasPrefix & "pr_docDate"))
        End If

        If Not dr.IsNull(aliasPrefix & "pr_note") Then
          .pr_note = CStr(dr(aliasPrefix & "pr_note"))
        End If

        If dr.Table.Columns.Contains("cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .pr_cc = New CostCenter(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pr_cc") Then
            .pr_cc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "pr_cc")))
            '.pr_cc = New CostCenter(CInt(dr(aliasPrefix & "pr_cc")))
          End If
        End If

        'TermNote
        If Not dr.IsNull(aliasPrefix & "pr_termnote") Then
          .m_termNote = CStr(dr(aliasPrefix & "pr_termnote"))
        End If

        'Delivery Time
        If Not dr.IsNull(aliasPrefix & "pr_deliverytime") Then
          .m_deliveryTime = CStr(dr(aliasPrefix & "pr_deliverytime"))
        End If

        'Place Of Delivery
        If Not dr.IsNull(aliasPrefix & "pr_placeofdelivery") Then
          .m_placeOfDelivery = CStr(dr(aliasPrefix & "pr_placeofdelivery"))
        End If

        If Not dr.IsNull(aliasPrefix & "pr_receivingDate") Then
          .pr_receivingDate = CDate(dr(aliasPrefix & "pr_receivingDate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "requestor.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "requestor.employee_id") Then
            .pr_requestor = New Employee(dr, aliasPrefix & "requestor.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pr_requestor") Then
            .pr_requestor = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "pr_requestor")))
            '.pr_requestor = New Employee(CInt(dr(aliasPrefix & "pr_requestor")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "pr_approveDate") Then
          .pr_approveDate = CDate(dr(aliasPrefix & "pr_approveDate"))
        End If
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .pr_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pr_approvePerson") Then
            .pr_approvePerson = New User(CInt(dr(aliasPrefix & "pr_approvePerson")))
          End If
        End If

        If dr.Table.Columns.Contains("approveStorePerson.user_id") Then
          If Not dr.IsNull("approveStorePerson.user_id") Then
            .pr_approveStorePerson = New User(dr, "approveStorePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pr_approveStorePerson") Then
            .pr_approveStorePerson = New User(CInt(dr(aliasPrefix & "pr_approveStorePerson")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "pr_approveStoreDate") Then
          .pr_approveStoreDate = CDate(dr(aliasPrefix & "pr_approveStoreDate"))
        End If


        If dr.Table.Columns.Contains(aliasPrefix & "pr_status") AndAlso Not dr.IsNull(aliasPrefix & "pr_status") Then
          .pr_status = New PRStatus(CInt(dr(aliasPrefix & "pr_status")))
        End If

        'Closing Status
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_closed") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_closed") Then
          .m_closed = CBool(dr(aliasPrefix & Me.Prefix & "_closed"))
          .m_closedBefor = .m_closed
        Else
          .m_closed = False
          .m_closedBefor = .m_closed
        End If

        'Special Condition
        If dr.Table.Columns.Contains(aliasPrefix & "pr_specialCondition") AndAlso Not dr.IsNull(aliasPrefix & "pr_specialCondition") Then
          .m_specialCondition = CStr(dr(aliasPrefix & "pr_specialCondition"))
        End If
        'Attachment
        If dr.Table.Columns.Contains(aliasPrefix & "pr_attachment") AndAlso Not dr.IsNull(aliasPrefix & "pr_attachment") Then
          .m_attachment = CStr(dr(aliasPrefix & "pr_attachment"))
        End If


        '---------------------------DECLARE---------------------------------------
        If dr.Table.Columns.Contains(aliasPrefix & "prdeclare_id") AndAlso Not dr.IsNull(aliasPrefix & "prdeclare_id") Then
          .pr_declareId = CInt(dr(aliasPrefix & "prdeclare_id"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "prdeclare_code") AndAlso Not dr.IsNull(aliasPrefix & "prdeclare_code") Then
          .pr_declareCode = CStr(dr(aliasPrefix & "prdeclare_code"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "prdeclare_note") AndAlso Not dr.IsNull(aliasPrefix & "prdeclare_note") Then
          .pr_declareNote = CStr(dr(aliasPrefix & "prdeclare_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pr_declarestatus") AndAlso Not dr.IsNull(aliasPrefix & "pr_declarestatus") Then
          .pr_declareStatusValue = CInt(dr(aliasPrefix & "pr_declarestatus"))
        End If
      End With
      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
      m_itemCollection = New PRItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
      Me.AutoCodeFormat = New AutoCodeFormat(Me)

      '==============CURRENCY=================================
      BusinessLogic.Currency.SetCurrencyFromDB(Me)
      '==============CURRENCY=================================
    End Sub
    Public Sub ConstructForPOitem(ByVal dr As System.Data.DataRow)
      Dim drh As New DataRowHelper(dr)

      With Me
        .Id = drh.GetValue(Of Integer)("pr_id")
        .Code = drh.GetValue(Of String)("pr_code")
        .pr_docDate = drh.GetValue(Of Date)("pr_docDate")
        .pr_olddocDate = drh.GetValue(Of Date)("pr_docDate")

        .pr_note = drh.GetValue(Of String)("pr_note")


        .pr_cc = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)("pr_cc"))


        'TermNote
        .m_termNote = drh.GetValue(Of String)("pr_termnote")

        'Delivery Time
        .m_deliveryTime = drh.GetValue(Of String)("pr_deliverytime")

        'Place Of Delivery
        .m_placeOfDelivery = drh.GetValue(Of String)("pr_placeofdelivery")
        .pr_receivingDate = drh.GetValue(Of Date)("pr_receivingDate")



        .pr_requestor = Employee.GetEmployeeById(drh.GetValue(Of Integer)("pr_requestor"))

        .pr_approveDate = drh.GetValue(Of Date)("pr_approveDate")

        .pr_approvePerson = New User(drh.GetValue(Of Integer)("pr_approvePerson"))


        .pr_approveStorePerson = New User(drh.GetValue(Of Integer)("pr_approveStorePerson"))

        .pr_approveStoreDate = drh.GetValue(Of Date)("pr_approveStoreDate")


        .pr_status = New PRStatus(drh.GetValue(Of Integer)("pr_status"))

        'Closing Status
        If dr.Table.Columns.Contains("pr_closed") AndAlso Not dr.IsNull("pr_closed") Then
          .m_closed = CBool(dr("pr_closed"))
          .m_closedBefor = .m_closed
        Else
          .m_closed = False
          .m_closedBefor = .m_closed
        End If

        'Special Condition
        .m_specialCondition = drh.GetValue(Of String)("pr_specialCondition")
        'Attachment
        .m_attachment = drh.GetValue(Of String)("pr_attachment")


        '---------------------------DECLARE---------------------------------------
        If dr.Table.Columns.Contains("prdeclare_id") AndAlso Not dr.IsNull("prdeclare_id") Then
          .pr_declareId = CInt(dr("prdeclare_id"))
        End If
        If dr.Table.Columns.Contains("prdeclare_code") AndAlso Not dr.IsNull("prdeclare_code") Then
          .pr_declareCode = CStr(dr("prdeclare_code"))
        End If
        If dr.Table.Columns.Contains("prdeclare_note") AndAlso Not dr.IsNull("prdeclare_note") Then
          .pr_declareNote = CStr(dr("prdeclare_note"))
        End If
        If dr.Table.Columns.Contains("pr_declarestatus") AndAlso Not dr.IsNull("pr_declarestatus") Then
          .pr_declareStatusValue = CInt(dr("pr_declarestatus"))
        End If
      End With

    End Sub
#End Region

#Region "Properties"
    Public Property ApproveDocColl As ApproveDocCollection
      Get
        Return m_approveDocColl
      End Get
      Set(ByVal value As ApproveDocCollection)
        '
      End Set
    End Property
    Public ReadOnly Property ExceptAccountPeriod As Boolean Implements IAbleExceptAccountPeriod.ExceptAccountPeriod
      Get
        Return Me.Closed
      End Get
    End Property
    Public Property Attachment() As String
      Get
        Return m_attachment
      End Get
      Set(ByVal Value As String)
        m_attachment = Value
      End Set
    End Property
    Public Property SpecialCondition() As String
      Get
        Return m_specialCondition
      End Get
      Set(ByVal Value As String)
        m_specialCondition = Value
      End Set
    End Property
    Public Property TermNote() As String
      Get
        Return m_termNote
      End Get
      Set(ByVal Value As String)
        m_termNote = Value
      End Set
    End Property
    Public Property DeliveryTime() As String
      Get
        Return m_deliveryTime
      End Get
      Set(ByVal Value As String)
        m_deliveryTime = Value
      End Set
    End Property
    Public Property PlaceOfDelivery() As String
      Get
        Return m_placeOfDelivery
      End Get
      Set(ByVal Value As String)
        m_placeOfDelivery = Value
      End Set
    End Property
    Public Property ItemCollection() As PRItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As PRItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property BudgetCollection() As WBSDistributeCollection
      Get
        Return m_budgetCollection
      End Get
      Set(ByVal Value As WBSDistributeCollection)
        m_budgetCollection = Value
      End Set
    End Property
    Private Function DupWBS(ByVal arr As ArrayList, ByVal theWbs As WBS) As Boolean
      If arr Is Nothing Then
        Return False
      End If
      For Each myWbs As WBS In arr
        If myWbs Is theWbs Then
          Return True
        End If
        If myWbs.Id = theWbs.Id Then
          Return True
        End If
      Next
      Return False
    End Function
    Private Function GetDeclareAmountFromSproc(ByVal sproc As String, ByVal line As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@prdeclare_pr", Me.Id) _
                , New SqlParameter("@prdeclarei_prilinenumber", line) _
                , New SqlParameter("@prdeclare_id", 0) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)(0))
          End If
        End If
      Catch ex As Exception
      End Try
    End Function
    Public Function OverBudget() As Boolean
      For Each item As PRItem In Me.ItemCollection
        Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
        'Hack ไปก่อนนะ
        wbsdColl.Populate(WBSDistribute.GetSchemaTable, item, 7)
        For Each wbsd As WBSDistribute In wbsdColl
          If wbsd.AmountOverBudget Then
            Return True
          End If
          If wbsd.QtyOverBudget Then
            Return True
          End If
        Next
      Next
      Return False
    End Function
    Public ReadOnly Property DeclareId() As Integer
      Get
        Return Me.pr_declareId
      End Get
    End Property
    Public ReadOnly Property DeclareCode() As String
      Get
        Return Me.pr_declareCode
      End Get
    End Property
    Public ReadOnly Property DeclareNote() As String
      Get
        Return Me.pr_declareNote
      End Get
    End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate      Get        Return pr_docDate      End Get      Set(ByVal Value As Date)        pr_docDate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return pr_olddocDate
      End Get
    End Property    Public Property ReceivingDate() As Date      Get        Return pr_receivingDate      End Get      Set(ByVal Value As Date)        pr_receivingDate = Value        'Me.ItemCollection.SetReceivingDate(Value)        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property Gross() As Decimal Implements IApprovAble.AmountToApprove      Get        If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then          Return 0
        End If        Return Me.ItemCollection.Amount      End Get    End Property    Public Property Note() As String      Get        Return pr_note      End Get      Set(ByVal Value As String)        pr_note = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Requestor() As Employee      Get        Return pr_requestor      End Get      Set(ByVal Value As Employee)        pr_requestor = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property CostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter      Get        Return pr_cc      End Get      Set(ByVal Value As CostCenter)        pr_cc = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property ApprovePerson() As User      Get        Return pr_approvePerson      End Get      Set(ByVal Value As User)        pr_approvePerson = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property ApproveDate() As DateTime      Get        Return pr_approveDate      End Get      Set(ByVal Value As DateTime)        pr_approveDate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property ApproveStorePerson() As User      Get        Return pr_approveStorePerson      End Get      Set(ByVal Value As User)        pr_approveStorePerson = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property ApproveStoreDate() As DateTime      Get        Return pr_approveStoreDate      End Get      Set(ByVal Value As DateTime)        pr_approveStoreDate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return pr_status
      End Get
      Set(ByVal Value As CodeDescription)
        pr_status = CType(Value, PRStatus)
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PR"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "pr"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PR.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PR.ListLabel}"
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
    Public Function HasLCIItem() As Boolean
      Dim hasLCI As Boolean = False
      For Each pri As PRItem In Me.ItemCollection
        If pri.ItemType.Value = 42 Then
          hasLCI = True
          Exit For
        End If
      Next
      Return hasLCI
    End Function
    Public Property Closed() As Boolean Implements ICloseStatusAble.Closed
      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        'm_closedBefor = m_closed
        m_closed = Value
      End Set
    End Property
    Public Property ClosedBefor() As Boolean
      Get
        Return m_closedBefor
      End Get
      Set(ByVal Value As Boolean)
        m_closedBefor = Value
      End Set
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PR")

      myDatatable.Columns.Add(New DataColumn("pri_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pri_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pri_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_originqty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_originamt", GetType(String)))

      Dim dateCol As New DataColumn("pri_receivingDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.CodeHeaderText}")
      myDatatable.Columns("pri_itemName").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.DescriptionHeaderText}")
      myDatatable.Columns("Unit").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.UnitHeaderText}")
      myDatatable.Columns("pri_qty").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.QtyHeaderText}")

      Return myDatatable
    End Function
    Public Shared Function GetPR(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldPR As PR) As Boolean
      Dim prNew As New PR(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not prNew.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        prNew = oldPR
        'ElseIf cc.IsControlGroup Then
        '    MessageBox.Show(prNew.Code & "-" & cc.Name & " เป็นกลุ่มแม่")
        '    prNew = oldPR
      End If
      txtCode.Text = prNew.Code
      txtName.Text = ""
      If oldPR.Id <> prNew.Id Then
        oldPR = prNew
        Return True
      End If
      Return False
    End Function
    Public Shared Function GetRemainingQtyForTransfer(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal arrKeyList As ArrayList, Optional ByVal includeMatTransferWithNotReceipt As Boolean = False) As DataTable
      Dim keyList As String = ""
      keyList = String.Join(",", arrKeyList.ToArray)
      If keyList.Length > 4000 Then
        Throw New Exception("PR Line number over flow") 'ถ้าปล่อยไปเดี๋ยว จะไป loop ใน procedure
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetPRRemainingForMatTransferList" _
    , New SqlParameter("@idList", keyList) _
    , New SqlParameter("@fromCC_id", storeCC) _
    , New SqlParameter("@stock_id", stockId)
    )
      If ds.Tables(0).Rows.Count > 0 Then
        Return ds.Tables(0)
      End If

      Return Nothing
    End Function
    Public Shared Function GetRemainingQtyForWithTransfer(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal prId As Integer, ByVal prLinenumber As Integer) As Decimal
      Dim key As String = prId.ToString & ":" & prLinenumber.ToString
      Dim arrPritem As New ArrayList
      arrPritem.Add(key)
      Dim itemQty As Decimal = 0
      Dim prTable As DataTable = PR.GetRemainingQtyForTransfer(stockId, storeCC, arrPritem, True)
      If Not prTable Is Nothing Then
        Dim dr() As DataRow = prTable.Select("keyid='" & key & "'")
        Dim drh As New DataRowHelper(dr(0))
        itemQty = drh.GetValue(Of Decimal)("RemainingQty")
      End If

      Return itemQty
    End Function
    Public Shared Function GetRemainingQtyForOperationWithdraw(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal arrKeyList As ArrayList, Optional ByVal includeMatTransferWithNotReceipt As Boolean = False) As DataTable
      Dim keyList As String = ""
      keyList = String.Join(",", arrKeyList.ToArray)
      If keyList.Length > 4000 Then
        Throw New Exception("PR Line number over flow") 'ถ้าปล่อยไปเดี๋ยว จะไป loop ใน procedure
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetPRRemainingForMatOperationWithdrawList" _
    , New SqlParameter("@idList", keyList) _
    , New SqlParameter("@fromCC_id", storeCC) _
    , New SqlParameter("@stock_id", stockId)
    )
      If ds.Tables(0).Rows.Count > 0 Then
        Return ds.Tables(0)
      End If

      Return Nothing
    End Function
    Public Function CheckIsStoreApproved() As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "CheckIsStoreApproved" _
    , New SqlParameter("@pr_id", Me.Id) _
    )
      If ds.Tables(0).Rows.Count > 0 Then
        Return CBool(ds.Tables(0).Rows(0)(0))
      End If

      Return False
    End Function
    Public Shared Function GetRemainingQtyForOperationWithdraw(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal prId As Integer, ByVal prLinenumber As Integer) As Decimal
      Dim key As String = prId.ToString & ":" & prLinenumber.ToString
      Dim arrPritem As New ArrayList
      arrPritem.Add(key)
      Dim itemQty As Decimal = 0
      Dim prTable As DataTable = PR.GetRemainingQtyForTransfer(stockId, storeCC, arrPritem, True)
      If Not prTable Is Nothing Then
        Dim dr() As DataRow = prTable.Select("keyid='" & key & "'")
        Dim drh As New DataRowHelper(dr(0))
        itemQty = drh.GetValue(Of Decimal)("RemainingQty")
      End If

      Return itemQty
    End Function
#End Region

#Region "Methods"
    Public Sub RefreshApproveDocCollection() Implements IApproveStatusAble.RefreshApproveDocCollection
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal type As Integer)
      myWbs = New WBS(myWbs.Id)
      Dim o_n As OldNew
      Dim theHash As Hashtable
      Select Case type
        Case 0, 19, 42
          theHash = MatActualHash
        Case 88
          theHash = LabActualHash
        Case 89
          theHash = EQActualHash
      End Select
      If Not theHash Is Nothing Then
        If theHash.Contains(myWbs.Id) Then
          o_n = CType(theHash(myWbs.Id), OldNew)
        Else
          o_n = New OldNew
          Select Case type
            Case 0, 19, 42
              o_n.OldValue = myWbs.GetActualMat(Me, 7)
            Case 88
              o_n.OldValue = myWbs.GetActualLab(Me, 7)
            Case 89
              o_n.OldValue = myWbs.GetActualEq(Me, 7)
          End Select
          o_n.NewValue = o_n.OldValue
          theHash(myWbs.Id) = o_n
        End If
        o_n.NewValue += (newVal - oldVal)

        'ส่งต่อไปยังแม่
        If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
          SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, type)
        End If
      End If
    End Sub
    Public Function GetCurrentDiffForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      Dim theHash As Hashtable
      Select Case itemType.Value
        Case 0, 19, 42
          theHash = MatActualHash
        Case 88
          theHash = LabActualHash
        Case 89
          theHash = EQActualHash
      End Select
      If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
        Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
        Return o_n.NewValue - o_n.OldValue
      End If
      Return 0
    End Function
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      Dim ret As Decimal = 0
      For Each item As PRItem In Me.ItemCollection
        Dim flag As Boolean = False
        If Not item.ItemType Is Nothing Then
          Select Case itemType.Value
            Case 0, 19, 42
              Select Case item.ItemType.Value
                Case 0, 19, 42
                  flag = True
                Case Else
                  flag = False
              End Select
            Case 88
              Select Case item.ItemType.Value
                Case 88
                  flag = True
                Case Else
                  flag = False
              End Select
            Case 89
              Select Case item.ItemType.Value
                Case 89
                  flag = True
                Case Else
                  flag = False
              End Select
          End Select
        End If
        If flag Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 7
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, 3)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentAmountForMarkup(ByVal mk As Markup) As Decimal
      Dim ret As Decimal = 0
      For Each item As PRItem In Me.ItemCollection
        For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
          If grWBSD.IsMarkup Then
            If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
              ret += (grWBSD.Percent * item.Amount / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Public Function GetCurrentTypeQtyForWBS(ByVal myWbs As WBS, ByVal name As String, ByVal type As Integer) As Decimal
      Dim ret As Decimal = 0
      For Each item As PRItem In Me.ItemCollection
        Dim theName As String = item.EntityName
        If theName Is Nothing Then
          theName = item.Entity.Name
        End If
        If theName Is Nothing Then
          theName = ""
        End If
        If name Is Nothing Then
          name = ""
        End If
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = type _
        AndAlso theName.ToLower = name.ToLower Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 7
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentMatQtyForWBS(ByVal myWbs As WBS, ByVal matId As Integer) As Decimal
      Dim ret As Decimal = 0
      For Each item As PRItem In Me.ItemCollection
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = 42 _
        AndAlso item.Entity.Id = matId Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 7
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentLabQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
      Dim ret As Decimal = 0
      For Each item As PRItem In Me.ItemCollection
        Dim theName As String = item.EntityName
        If theName Is Nothing Then
          theName = item.Entity.Name
        End If
        If theName Is Nothing Then
          theName = ""
        End If
        If name Is Nothing Then
          name = ""
        End If
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = 88 _
        AndAlso theName.ToLower = name.ToLower Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 7
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Public Function GetCurrentEqQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
      Dim ret As Decimal = 0
      For Each item As PRItem In Me.ItemCollection
        Dim theName As String = item.EntityName
        If theName Is Nothing Then
          theName = item.Entity.Name
        End If
        If theName Is Nothing Then
          theName = ""
        End If
        If name Is Nothing Then
          name = ""
        End If
        If Not item.ItemType Is Nothing _
        AndAlso item.ItemType.Value = 89 _
        AndAlso theName.ToLower = name.ToLower Then
          For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
            If Not grWBSD.IsMarkup Then
              Dim isOut As Boolean = False
              Dim view As Integer = 7
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
      Next
      Return ret
    End Function
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As PRItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

      If Me.CostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If
      'PROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("PROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      'PROverBudgetOnlyWBSAllocate
      config = Configuration.GetConfig("PROverBudgetOnlyWBSAllocate")
      Dim onlyWBSAllocate As Boolean = False
      If Not config Is Nothing Then
        onlyWBSAllocate = CBool(config)
      End If

      '====================
      WBS.ParentBudgetHash = New Hashtable 'ห้ามลืมเด็ดขาด
      '====================
      Dim idList As String = Me.ListWbsId
      Dim dsParentBudget As New DataSet
      dsParentBudget = WBS.GetParentsBudgetList(Me.EntityId, idList)
      Dim currwbsId As Integer

      If Not onlyCC Then
        For Each item As PRItem In Me.ItemCollection
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrent As Decimal = 0
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              totalCurrent = (wbsd.Percent / 100) * item.Amount

              If onlyWBSAllocate Then
                If wbsd.OwnerBudgetAmount - totalCurrent < 0 Then
                  Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
                End If
              End If

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
                Select Case item.ItemType.Value
                  Case 88
                    totalBudget = drh.GetValue(Of Decimal)("labbudget")
                    totalActual = drh.GetValue(Of Decimal)("labactual")
                  Case 89
                    totalBudget = drh.GetValue(Of Decimal)("eqbudget")
                    totalActual = drh.GetValue(Of Decimal)("eqactual")
                  Case Else
                    totalBudget = drh.GetValue(Of Decimal)("matbudget")
                    totalActual = drh.GetValue(Of Decimal)("matactual")
                End Select
                If totalBudget < (totalActual + wbsd.Amount) Then
                  Dim myId As Integer = drh.GetValue(Of Integer)("depend_parent")
                  Dim myWBS As New WBS(myId)
                  Return New SaveErrorException(myWBS.Code & ":" & myWBS.Name)
                End If
              Next

            Next
            If item.WBSDistributeCollection.GetSumPercent = 0 Then
              'สำหรับ Auto จัดสรร
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim tActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
              Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
              Dim cActual As Decimal = item.Amount
              Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
              If onlyWBSAllocate Then
                If oBudget < ((tActual - thisActual) + cActual) Then
                  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
                End If
              End If
              If tBudget < ((tActual - thisActual) + cActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
          End If
        Next
      Else
        Dim hCC As New Hashtable
        For Each item As PRItem In Me.ItemCollection
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            'สำหรับ Auto จัดสรร
            Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
            Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
            Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
            Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
            Dim currentActual As Decimal = item.Amount
            Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
            If onlyWBSAllocate Then
              If oBudget < ((totalActual - thisActual) + currentActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
            If totalBudget < ((totalActual - thisActual) + currentActual) Then
              Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
            End If
          End If
        Next
        For Each wbsd As WBSDistribute In hCC.Values
          Dim rootWBS As New WBS(wbsd.WBS.GetWBSRootId)
          Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
          Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
          Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          Dim currentActual As Decimal = wbsd.Amount

          Dim tActual As Decimal = (wbsd.WBS.GetActualMat(Me, Me.EntityId) + wbsd.WBS.GetActualLab(Me, Me.EntityId) + wbsd.WBS.GetActualEq(Me, Me.EntityId))
          Dim tcActual As Decimal = wbsd.WBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          If onlyWBSAllocate Then
            If wbsd.OwnerBudgetAmount < ((tActual - tcActual) + currentActual) Then
              Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
            End If
          End If
          If totalBudget < ((totalActual - thisActual) + currentActual) Then
            Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
          End If
        Next

        'Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
        'Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        'Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 7) + rootWBS.GetActualLab(Me, 7) + rootWBS.GetActualEq(Me, 7))

        'Dim totalCurrentDiff As Decimal = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0)) + _
        'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88)) + _
        'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
        'If totalBudget < (totalActual + totalCurrentDiff) Then
        '  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        'End If
      End If

      Return New SaveErrorException("0")
    End Function
    Private Function ValidateItem() As SaveErrorException
      Dim key As String = ""

      For Each item As PRItem In Me.ItemCollection

        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In item.WBSDistributeCollection
          key = wbitem.CostCenter.Code & ":" & wbitem.WBS.Id.ToString
          If Not newHash.Contains(key) Then
            newHash(key) = wbitem
          Else
            Return New SaveErrorException("${res:Global.Error.DupplicateWBS}", New String() {wbitem.WBS.Code})
          End If
          If (wbitem.WBS Is Nothing OrElse wbitem.WBS.Id = 0) AndAlso wbitem.CostCenter.BoqId > 0 Then
            Return New SaveErrorException("${res:Global.Error.WBSMissing}")
          End If
        Next
      Next

      Return New SaveErrorException("0")
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException



      Return New SaveErrorException("0")

    End Function
    Private m_DocMethod As SaveDocMultiApprovalMethod
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim oldcode As String
      With Me

        If Not Me.Originated Then
          m_DocMethod = SaveDocMultiApprovalMethod.Save
        ElseIf Me.Status.Value = 0 Then
          m_DocMethod = SaveDocMultiApprovalMethod.Cancel
        ElseIf Me.Closed Then
          m_DocMethod = SaveDocMultiApprovalMethod.Close
        Else
          m_DocMethod = SaveDocMultiApprovalMethod.Update
        End If

        Dim docValidate As Boolean = True
        If (Me.Originated AndAlso Me.Status.Value = 0) OrElse Me.Closed Then
          docValidate = False
        End If

        If docValidate Then
          If Me.ItemCollection.Count = 0 Then   '.ItemTable.Childs.Count = 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
          End If
          Dim ValidateError As SaveErrorException = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          End If

          'Check Over Budget ====================================
          Dim ValidateOverBudgetError As SaveErrorException
          Dim config As Integer = CInt(Configuration.GetConfig("PROverBudget"))
          Select Case config
            Case 0   'Not allow
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.OverBudgetCannotSaved}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                Return New SaveErrorException(msgString & vbCrLf & msgString2)
              End If
            Case 1   'Warn
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.AcceptOverBudget}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                If Not msgServ.AskQuestion(msgString2 & vbCrLf & msgString) Then
                  Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
                End If
              End If
            Case 2   'Do Nothing
          End Select
          'Check Over Budget ====================================
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
          paramArrayList.Add(New SqlParameter("@pr_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        oldcode = Me.Code
        Dim oldautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen

        If Me.AutoGen Then   'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        paramArrayList.Add(New SqlParameter("@pr_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@pr_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@pr_receivingDate", Me.ValidDateOrDBNull(Me.ReceivingDate)))
        paramArrayList.Add(New SqlParameter("@pr_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@pr_requestor", ValidIdOrDBNull(Me.Requestor)))
        paramArrayList.Add(New SqlParameter("@pr_cc", ValidIdOrDBNull(Me.CostCenter)))
        'paramArrayList.Add(New SqlParameter("@pr_approveperson", Me.ValidIdOrDBNull(Me.ApprovePerson)))
        'paramArrayList.Add(New SqlParameter("@pr_approvedate", IIf(Me.ApprovePerson.Valid, theTime, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@pr_approvestoreperson", Me.ValidIdOrDBNull(Me.ApproveStorePerson)))
        paramArrayList.Add(New SqlParameter("@pr_approvestoredate", IIf(Me.ApproveStorePerson.Valid, theTime, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@pr_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@pr_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_termnote", Me.TermNote))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_deliverytime", Me.DeliveryTime))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_placeofdelivery", Me.PlaceOfDelivery))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_attachment", Me.Attachment))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_specialcondition", Me.SpecialCondition))
        paramArrayList.Add(New SqlParameter("@" & "pr_closed", Me.Closed))
        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen)
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

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
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid)
                  Me.ResetCode(oldcode, oldautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetID(oldid)
              Me.ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If
            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetID(oldid)
              Me.ResetCode(oldcode, oldautogen)
              Return saveDetailError
            Else
              Select Case CInt(saveDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid)
                  Me.ResetCode(oldcode, oldautogen)
                  Return saveDetailError
                Case Else
              End Select
            End If

            '==============CURRENCY=================================
            'Save Currency
            If Me.Originated Then
              BusinessLogic.Currency.SaveCurrency(Me, conn, trans)
            End If
            '==============CURRENCY=================================







            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              ResetID(oldid)
              Me.ResetCode(oldcode, oldautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid)
                  Me.ResetCode(oldcode, oldautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================

            trans.Commit()

          Catch ex As SqlException
            trans.Rollback()
            Me.ResetID(oldid)
            Me.ResetCode(oldcode, oldautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid)
            Me.ResetCode(oldcode, oldautogen)
            Return New SaveErrorException(ex.ToString)
          End Try

          'Sub Save Block ============================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          Try
            Dim subsaveerror As SaveErrorException = SubSaveDocApprove(conn, currentUserId)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          'Sub Save Block ============================================

          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
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

      'Save CustomNote จากการ Copy เอกสาร
      If Not Me.m_customNoteColl Is Nothing AndAlso Me.m_customNoteColl.Count > 0 Then
        If Me.Originated Then
          Me.m_customNoteColl.EntityId = Me.Id
          Me.m_customNoteColl.Save()
        End If
      End If

      For Each extender As Object In Me.Extenders
        If TypeOf extender Is IExtender Then
          Dim saveDocError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
          If Not IsNumeric(saveDocError.Message) Then
            trans.Rollback()
            Return saveDocError
          Else
            Select Case CInt(saveDocError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Return saveDocError
              Case Else
            End Select
          End If
        End If
      Next

      Try
        Me.DeleteRef(conn, trans)
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_PRRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_PRRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromPR", New SqlParameter("@refto_id", Me.Id))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSaveDocApprove(ByVal conn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException
      Dim strans As SqlTransaction = conn.BeginTransaction

      Try
        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.Gross, currentUserId, m_DocMethod, Me.ApproveDocColl.GetLastedApproveDoc.Comment, Me.CostCenter.Id, 0, Me)
        Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, strans)
        If Not IsNumeric(savemldocError.Message) Then
          strans.Rollback()
          Return savemldocError
        End If
      Catch ex As Exception
        strans.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      strans.Commit()
      Return New SaveErrorException("0")
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String
      If Me.AutoCodeFormat.Format.Length > 0 Then
        autoCodeFormat = Me.AutoCodeFormat.Format
      Else
        autoCodeFormat = Me.Code
      End If
      'Entity.GetAutoCodeFormat(Me.EntityId)
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
        Dim da As New SqlDataAdapter("Select * from pritem where pri_pr=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from priwbs where priw_pr=" & Me.Id & " and priw_prilinenumber in (select pri_linenumber from pritem where pri_pr=" & Me.Id & ")", conn)


        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "pritem")
        da.Fill(ds, "pritem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "priwbs")
        daWbs.Fill(ds, "priwbs")

        Dim dt As DataTable = ds.Tables("pritem")
        Dim dtWbs As DataTable = ds.Tables("priwbs")

        For Each row As DataRow In ds.Tables("priwbs").Rows
          row.Delete()
        Next
        For Each row As DataRow In ds.Tables("pritem").Rows
          row.Delete()
        Next
        Dim i As Integer = 0       'Line Running
        Dim beforeSaveQty As Decimal
        With ds.Tables("pritem")
          For Each item As PRItem In Me.ItemCollection
            Select Case item.ItemType.Value
              Case 42
                Dim lci As New LCIItem(item.Entity.Id)
                If Not lci.Originated Then
                  Return New SaveErrorException("${res:Global.Error.LCIIsInvalid}", New String() {item.Entity.Name})
                ElseIf Not lci.ValidUnit(item.Unit) Then
                  Return New SaveErrorException("${res:Global.Error.LCIInvalidUnit}", New String() {lci.Code, item.Unit.Name})
                End If
              Case 19
                Dim myTool As New Tool(item.Entity.Id)
                If Not myTool.Originated Then
                  Return New SaveErrorException("${res:Global.Error.ToolIsInvalid}", New String() {item.Entity.Name})
                ElseIf myTool.Unit.Id <> item.Unit.Id Then
                  Return New SaveErrorException("${res:Global.Error.ToolInvalidUnit}", New String() {myTool.Code, item.Unit.Name})
                End If
            End Select
            beforeSaveQty = item.Qty
            i += 1
            Dim dr As DataRow = .NewRow
            If Not m_closedBefor AndAlso Me.Closed Then
              dr("pri_qty") = item.GetOrderedQty + item.GetWithdrawnQty
              dr("pri_originqty") = item.Qty
              dr("pri_originamt") = item.Amount
              item.m_qty = Configuration.Format(item.GetOrderedQty + item.GetWithdrawnQty, DigitConfig.Qty)
            ElseIf Not m_closedBefor AndAlso Not Me.Closed Then
              dr("pri_qty") = item.Qty
              dr("pri_originqty") = item.Qty
              dr("pri_originamt") = item.Amount
            ElseIf m_closedBefor AndAlso Not Me.Closed Then
              dr("pri_qty") = item.OriginQty
              dr("pri_originqty") = item.OriginQty
              dr("pri_originamt") = item.OriginAmount
              item.m_qty = Configuration.Format(item.GetOrderedQty, DigitConfig.Qty)
            ElseIf m_closedBefor AndAlso Me.Closed Then
              dr("pri_qty") = item.GetOrderedQty + item.GetWithdrawnQty
              dr("pri_originqty") = item.OriginQty
              dr("pri_originamt") = item.OriginAmount
              item.m_qty = Configuration.Format(item.GetOrderedQty + item.GetWithdrawnQty, DigitConfig.Qty)
            End If
            dr("pri_pr") = Me.Id
            dr("pri_linenumber") = i
            dr("pri_entity") = item.Entity.Id
            dr("pri_entityType") = item.ItemType.Value
            dr("pri_itemName") = item.EntityName
            dr("pri_unit") = item.Unit.Id
            dr("pri_stockqty") = item.StockQty
            dr("pri_orderedqty") = item.GetOrderedQty
            dr("pri_withdrawnqty") = item.GetWithdrawnQty
            dr("pri_unitprice") = item.UnitPrice
            dr("pri_amt") = item.Amount
            dr("pri_note") = item.Note
            dr("pri_receivingdate") = Me.ValidDateOrDBNull(item.ReceivingDate)
            .Rows.Add(dr)
            If item.ItemType.Value <> 160 _
            AndAlso item.ItemType.Value <> 162 Then
              Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim currentSum As Decimal = wbsdColl.GetSumPercent
              For Each wbsd As WBSDistribute In wbsdColl
                If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                  'ยังไม่เต็ม 100 แต่มีหัวอยู่
                  wbsd.Percent += (100 - currentSum)
                End If

                Dim m_currentQty As Decimal = 0
                If Not m_closedBefor AndAlso Me.Closed Then
                  m_currentQty = item.OrderedQty + item.WithdrawnQty
                ElseIf Not m_closedBefor AndAlso Not Me.Closed Then
                  m_currentQty = item.Qty
                ElseIf m_closedBefor AndAlso Not Me.Closed Then
                  m_currentQty = item.OriginQty
                ElseIf m_closedBefor AndAlso Me.Closed Then
                  m_currentQty = item.OrderedQty + item.WithdrawnQty
                End If

                wbsd.BaseCost = item.UnitPrice * m_currentQty
                'wbsd.TransferBaseCost = wbsd.BaseCost

                Dim childDr As DataRow = dtWbs.NewRow
                childDr("priw_wbs") = wbsd.WBS.Id
                If wbsd.CostCenter Is Nothing Then
                  wbsd.CostCenter = Me.CostCenter
                End If
                childDr("priw_cc") = wbsd.CostCenter.Id
                childDr("priw_percent") = wbsd.Percent
                childDr("priw_pr") = Me.Id
                childDr("priw_prilinenumber") = i
                childDr("priw_ismarkup") = wbsd.IsMarkup
                childDr("priw_direction") = 0               'in
                childDr("priw_baseCost") = wbsd.BaseCost
                'childDr("priw_transferbaseCost") = wbsd.TransferBaseCost
                'childDr("priw_transferamt") = wbsd.TransferAmount
                childDr("priw_amt") = wbsd.Amount
                childDr("priw_toaccttype") = 3
                childDr("priw_cbs") = wbsd.CBS.Id
                'Add เข้า priwbs
                dtWbs.Rows.Add(childDr)
              Next

              currentSum = wbsdColl.GetSumPercent
              'ยังไม่เต็ม 100 และยังไม่มี root
              If currentSum < 100 AndAlso Not rootWBS Is Nothing Then
                Try

                  Dim m_currentQty As Decimal = 0
                  If Not m_closedBefor AndAlso Me.Closed Then
                    m_currentQty = item.OrderedQty + item.WithdrawnQty
                  ElseIf Not m_closedBefor AndAlso Not Me.Closed Then
                    m_currentQty = item.Qty
                  ElseIf m_closedBefor AndAlso Not Me.Closed Then
                    m_currentQty = item.OriginQty
                  ElseIf m_closedBefor AndAlso Me.Closed Then
                    m_currentQty = item.OrderedQty + item.WithdrawnQty
                  End If

                  Dim newWbsd As New WBSDistribute
                  newWbsd.WBS = rootWBS
                  newWbsd.CostCenter = item.Pr.CostCenter
                  newWbsd.Percent = 100 - currentSum
                  newWbsd.BaseCost = item.UnitPrice * m_currentQty
                  'newWbsd.TransferBaseCost = newWbsd.BaseCost
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("priw_wbs") = newWbsd.WBS.Id
                  childDr("priw_cc") = newWbsd.CostCenter.Id
                  childDr("priw_percent") = newWbsd.Percent
                  childDr("priw_pr") = Me.Id
                  childDr("priw_prilinenumber") = i
                  childDr("priw_ismarkup") = False
                  childDr("priw_direction") = 0                 'in
                  childDr("priw_baseCost") = newWbsd.BaseCost
                  'childDr("priw_transferbaseCost") = newWbsd.TransferBaseCost
                  'childDr("priw_transferamt") = newWbsd.TransferAmount
                  childDr("priw_amt") = newWbsd.Amount
                  childDr("priw_toaccttype") = 3
                  childDr("priw_cbs") = newWbsd.CBS.Id
                  'Add เข้า priwbs
                  dtWbs.Rows.Add(childDr)
                Catch ex As Exception
                  MessageBox.Show(ex.ToString)
                End Try
              End If
            End If
            item.m_qty = beforeSaveQty
          Next
        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True
        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
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
    Public Shared Function ApproveStoreData(ByVal Docid As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException

      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current
      ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
      Dim paramArrayList As New ArrayList

      paramArrayList.Add(returnVal)
      paramArrayList.Add(New SqlParameter("@pr_id", Docid))
      paramArrayList.Add(New SqlParameter("@pr_approvestoreperson", currentUserId))
      paramArrayList.Add(New SqlParameter("@pr_approvestoredate", theTime))

      ' สร้าง SqlParameter จาก ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      ' ให้ Transaction ควบคุมที่ส่วนของ Client เพราะอาจมีหลาย loop ได้
      Try
        SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ApproveStorePR", sqlparams)
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try

    End Function

#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.RelationList.Add("general>pr_id>item>pri_pr")
      dpiColl.RelationList.Add("general>pr_id>Approve>ApprovePersonLevelNo")

      dpiColl.RelationList.Add("item>pri_pr>allocate>priw_pri")
      dpiColl.RelationList.Add("item>pri_linenumber>allocate>priw_linenumber")

      dpiColl.RelationList.Add("item>pri_linenumber>UnitPrice>UnitPriceNo")
      dpiColl.RelationList.Add("item>pri_linenumber>Unit>UnitNo")
      dpiColl.RelationList.Add("item>pri_linenumber>Qty>QtyNo")
      dpiColl.RelationList.Add("item>pri_linenumber>Name>NameNo")
      dpiColl.RelationList.Add("item>pri_linenumber>Note>NoteNo")

      dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateUnitPrice>UnitPriceNo")
      dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateUnit>UnitNo")
      dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateQty>QtyNo")
      dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateName>NameNo")

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pr_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivingDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TermNote", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DeliveryTime", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("PlaceOfDelivery", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Attachment", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Special", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenter", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Customer", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorId", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Requestor", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalSequence", "System.Int32"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SumItemQty", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastPageGross", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonIdLevel", "System.String")) '--Last Approved--
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AuthorizeId", "System.String")) '--Last Approved--

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonLevelNo", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonCodeLevel", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonNameLevel", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonInfoLevel", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonDateLevel", "System.DateTime", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonCommentLevel", "System.String", "Approve"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pri_pr", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pri_linenumber", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Sequence", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCostCenter", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodePercent", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodeAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainQty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LciNote", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Description", "System.String", "Item")) '--For Sitem โดยเฉพาะ--
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ReceivingDate", "System.String", "Item"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UnitPriceNo", "System.String", "UnitPrice"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "UnitPrice"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UnitNo", "System.String", "Unit"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Unit"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("QtyNo", "System.String", "Qty"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Qty"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("NameNo", "System.String", "Name"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Name"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("NoteNo", "System.String", "Note"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Note"))

      dpiColl.AddRange(GetAllocateDocPrintingColumns)

      Return dpiColl
    End Function
    Public Function GetAllocateDocPrintingColumns() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("priw_pri", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("priw_prilinenumber", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCostCenter", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCode", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSName", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSInfo", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.CBSCode", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.CBSName", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.CBSInfo", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodePercent", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Percent", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodeAmount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.BudgetAmount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainAmount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSBudgetQty", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainQty", "System.String", "Allocate"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPriceNo", "System.String", "AllocateUnitPrice"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "AllocateUnitPrice"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitNo", "System.String", "AllocateUnit"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "AllocateUnit"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.QtyNo", "System.String", "AllocateQty"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "AllocateQty"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.NameNo", "System.String", "AllocateName"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "AllocateName"))

      Return dpiColl
    End Function
    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PR.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      '--สำหรับไว้สร้าง relation ใน schema--=============
      'pr_id
      dpi = New DocPrintingItem
      dpi.Mapping = "pr_id"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)
      '--สำหรับไว้สร้าง relation ใน schema--=============

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

      'ReceivingDate
      dpi = New DocPrintingItem
      dpi.Mapping = "ReceivingDate"
      dpi.Value = Me.ReceivingDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'TermNote
      dpi = New DocPrintingItem
      dpi.Mapping = "TermNote"
      dpi.Value = Me.TermNote
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DeliveryTime
      dpi = New DocPrintingItem
      dpi.Mapping = "DeliveryTime"
      dpi.Value = Me.DeliveryTime
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'PlaceOfDelivery
      dpi = New DocPrintingItem
      dpi.Mapping = "PlaceOfDelivery"
      dpi.Value = Me.PlaceOfDelivery
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Attachment
      dpi = New DocPrintingItem
      dpi.Mapping = "Attachment"
      dpi.Value = Me.Attachment
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Special
      dpi = New DocPrintingItem
      dpi.Mapping = "Special"
      dpi.Value = Me.SpecialCondition
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
        'CostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenter"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        If Not Me.CostCenter.Customer Is Nothing AndAlso Me.CostCenter.Customer.Originated Then
          'Customer
          dpi = New DocPrintingItem
          dpi.Mapping = "Customer"
          dpi.Value = Me.CostCenter.Customer.Code & ":" & Me.CostCenter.Customer.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'CustomerName
          dpi = New DocPrintingItem
          dpi.Mapping = "CustomerName"
          dpi.Value = Me.CostCenter.Customer.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'CustomerCode
          dpi = New DocPrintingItem
          dpi.Mapping = "CustomerCode"
          dpi.Value = Me.CostCenter.Customer.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If
      End If

      If Not Me.Requestor Is Nothing AndAlso Me.Requestor.Originated Then
        'RequestorId
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorId"
        dpi.Value = Me.Requestor.Id
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.Person
        dpiColl.Add(dpi)

        'Requestor
        dpi = New DocPrintingItem
        dpi.Mapping = "Requestor"
        dpi.Value = Me.Requestor.Code & ":" & Me.Requestor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RequestorInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorInfo"
        dpi.Value = Me.Requestor.Code & ":" & Me.Requestor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RequestorCode
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorCode"
        dpi.Value = Me.Requestor.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RequestorName
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorName"
        dpi.Value = Me.Requestor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Mapping การอนุมัติ #917
      Dim appTable As DataTable = BusinessEntity.GetApprovePersonListfromDoc(Me.Id, Me.EntityId)
      If appTable.Rows.Count > 0 Then
        For Each row As DataRow In appTable.Rows
          Dim deh As New DataRowHelper(row)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonNameLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonCodeLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonInfoLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name") & ":" & deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonDateLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of Date)("apvdate").ToShortDateString
          dpi.DataType = "System.DateTime"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonInfoLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("apvdoc_comment").ToString
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        Next

      End If

      Dim LastLevelApprove As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        'If ap.Level > 0 AndAlso Not ap.Reject Then
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            dpi = New DocPrintingItem
            dpi.Mapping = "ApprovePersonIdLevel " & ap.Level.ToString
            dpi.Value = ap.Originator
            dpi.DataType = "System.String"
            dpi.SignatureType = SignatureType.ApprovePerson
            dpiColl.Add(dpi)
          End If
        Next

        'Authorizeid
        dpi = New DocPrintingItem
        dpi.Mapping = "AuthorizeId"
        If Me.IsApproved Then
          dpi.Value = Me.ApprovePerson.Id
        Else
          dpi.Value = 0
        End If
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.AuthorizedPerson
        dpiColl.Add(dpi)
      End If

      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim sequence As Integer = 0
      For Each item As PRItem In Me.ItemCollection
        '--สำหรับไว้สร้าง relation ใน schema--=============
        'pri_pr
        dpi = New DocPrintingItem
        dpi.Mapping = "pri_pr"
        dpi.Value = Me.Id
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'pri_linenumber
        dpi = New DocPrintingItem
        dpi.Mapping = "pri_linenumber"
        dpi.Value = item.LineNumber
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        '--สำหรับไว้สร้าง relation ใน schema--=============

        'Item.Sequence
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Sequence"
        If item.ItemType.Value = 160 OrElse item.ItemType.Value = 162 Then
          dpi.Value = ""
        Else
          sequence = sequence + 1
          dpi.Value = sequence
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        Dim qtyText As String = ""
        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
          line += 1
          'Item.LineNumber
          '************** เอามาไว้เป็นอันที่ 2
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = line
          dpi.DataType = "System.Int32"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit"
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.UnitPriceN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice" & (i + 1).ToString
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.UnitN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit" & (i + 1).ToString
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'Item.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty"
          If item.Qty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.QtyN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty" & (i + 1).ToString
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          qtyText = Configuration.FormatToString(item.Qty, DigitConfig.Qty) & " " & item.Unit.Name
        End If

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.NameN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name" & (i + 1).ToString
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        Dim WBSCostCenter As String = ""
        Dim WBSCode As String = ""
        Dim WBSName As String = ""
        Dim WBSCodePercent As String = ""
        Dim WBSCodeAmount As String = ""
        Dim WBSRemainAmount As String = ""
        Dim WBSRemainQty As String = ""

        Dim hashWBS As New Hashtable
        Dim hashWBSItem As New Hashtable
        Dim key As String = ""
        Dim itemKey As String = ""

        If item.WBSDistributeCollection.Count > 0 Then
          'Populate ให้คำนวณคงเหลือแบบหลอกๆ
          'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)


          If item.WBSDistributeCollection.Count = 1 Then

            key = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.AllocationType
            itemKey = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

            'Amount -----------------------------------------------------
            If Not hashWBS.Contains(key) Then
              item.WBSDistributeCollection.Item(0).RemainSummary = item.WBSDistributeCollection.Item(0).BudgetRemain - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
              hashWBS(key) = item.WBSDistributeCollection.Item(0)
            Else
              Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
              item.WBSDistributeCollection.Item(0).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
              CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(0).RemainSummary
            End If
            'Qty --------------------------------------------------------
            If Not hashWBSItem.Contains(itemKey) Then
              item.WBSDistributeCollection.Item(0).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemain - item.WBSDistributeCollection.Item(0).Qty
              hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(0)
            Else
              Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
              item.WBSDistributeCollection.Item(0).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(0).Qty
              CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemainSummary
            End If

            WBSCostCenter = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & _
            item.WBSDistributeCollection.Item(0).CostCenter.Name 'Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
            WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
            WBSName = item.WBSDistributeCollection.Item(0).WBS.Name
            WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%"
            WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price)
            WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
            WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
          Else
            Dim j As Integer
            For j = 0 To item.WBSDistributeCollection.Count - 1

              key = item.WBSDistributeCollection.Item(j).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(j).CostCenter.Id.ToString & ":" & item.AllocationType
              itemKey = item.WBSDistributeCollection.Item(j).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(j).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

              'Amount -----------------------------------------------------
              If Not hashWBS.Contains(key) Then
                item.WBSDistributeCollection.Item(j).RemainSummary = item.WBSDistributeCollection.Item(j).BudgetRemain - (item.WBSDistributeCollection.Item(j).Amount + item.WBSDistributeCollection.Item(j).ChildAmount)
                hashWBS(key) = item.WBSDistributeCollection.Item(j)
              Else
                Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
                item.WBSDistributeCollection.Item(j).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(j).Amount + item.WBSDistributeCollection.Item(j).ChildAmount)
                CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(j).RemainSummary
              End If
              'Qty --------------------------------------------------------
              If Not hashWBSItem.Contains(itemKey) Then
                item.WBSDistributeCollection.Item(j).QtyRemainSummary = item.WBSDistributeCollection.Item(j).QtyRemain - item.WBSDistributeCollection.Item(j).Qty
                hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(j)
              Else
                Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
                item.WBSDistributeCollection.Item(j).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(j).Qty
                CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(j).QtyRemainSummary
              End If

              WBSCostCenter &= item.WBSDistributeCollection.Item(j).CostCenter.Code & ":" & _
              item.WBSDistributeCollection.Item(j).CostCenter.Name ' & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
              WBSCode &= item.WBSDistributeCollection.Item(j).WBS.Code
              WBSName &= item.WBSDistributeCollection.Item(j).WBS.Name
              WBSCodePercent &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Percent, DigitConfig.Price)
              WBSCodeAmount &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Amount, DigitConfig.Price)
              WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).RemainSummary, DigitConfig.Price)
              WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).QtyRemainSummary, DigitConfig.Price)
              If j < item.WBSDistributeCollection.Count - 1 Then
                WBSCostCenter &= ", "
                'WBSCostCentern &= ", "
                WBSCode &= ", "
                WBSName &= ", "
                WBSCodePercent &= ", "
                WBSCodeAmount &= ", "
                WBSRemainAmount &= ", "
                WBSRemainQty &= ", "
              End If
            Next
          End If
        End If

        'Item.WBSCostCenter
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCostCenter"
        dpi.Value = WBSCostCenter
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCode"
        dpi.Value = WBSCode
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSName
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSName"
        dpi.Value = WBSName
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCodePercent
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCodePercent"
        dpi.Value = WBSCodePercent
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSCodeAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSCodeAmount"
        dpi.Value = WBSCodeAmount
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSRemainAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSRemainAmount"
        dpi.Value = WBSRemainAmount
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.WBSRemainQty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.WBSRemainQty"
        dpi.Value = WBSRemainQty
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        '--------------------- WBS Section ------------------

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.LciNote
        If TypeOf item.Entity Is IHasNote Then
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LciNote"
          dpi.Value = CType(item.Entity, IHasNote).Note
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If

        'Item.NoteN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note" & (i + 1).ToString
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)


        'Item.Description '''For Sitem โดยเฉพาะ
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Description"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName & vbCrLf & qtyText
        Else
          dpi.Value = item.Entity.Name & vbCrLf & qtyText
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ReceivingDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ReceivingDate"
        If Not Date.MinValue.Equals(item.ReceivingDate) Then
          dpi.Value = item.ReceivingDate.ToShortDateString
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        i += 1
      Next

      'TotalSequence
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalSequence"
      dpi.Value = sequence
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'SumItemQty
      dpi = New DocPrintingItem
      dpi.Mapping = "SumItemQty"
      dpi.Value = Configuration.FormatToString(line, DigitConfig.Qty)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      '*************************************LastPage********************************
      If Me.Gross <> 0 Then
        'LastPageGross
        dpi = New DocPrintingItem
        dpi.Mapping = "LastPageGross"
        dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
        dpiColl.Add(dpi)
      End If


      dpiColl.AddRange(GetAllocateDocPrinting)

      Return dpiColl

    End Function

    Public Function GetAllocateDocPrinting() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      For Each item As PRItem In Me.ItemCollection
        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        Dim qtyText As String = ""
        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
          line += 1
          'Item.LineNumber
          '************** เอามาไว้เป็นอันที่ 2
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = line
          dpi.DataType = "System.Int32"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit"
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.UnitPriceN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice" & (i + 1).ToString
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.UnitN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Unit" & (i + 1).ToString
          dpi.Value = item.Unit.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'Item.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty"
          If item.Qty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.QtyN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Qty" & (i + 1).ToString
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          qtyText = Configuration.FormatToString(item.Qty, DigitConfig.Qty) & " " & item.Unit.Name
        End If



        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.NameN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name" & (i + 1).ToString
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        'Dim WBSCostCenter As String = ""
        'Dim WBSCode As String = ""
        'Dim WBSName As String = ""
        'Dim WBSCodePercent As String = ""
        'Dim WBSCodeAmount As String = ""
        'Dim WBSRemainAmount As String = ""
        'Dim WBSRemainQty As String = ""
        'If item.WBSDistributeCollection.Count > 0 Then
        '  'Populate ให้คำนวณคงเหลือแบบหลอกๆ
        '  'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
        '  If item.WBSDistributeCollection.Count = 1 Then
        '    WBSCostCenter = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & _
        '    item.WBSDistributeCollection.Item(0).CostCenter.Name 'Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
        '    WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
        '    WBSName = item.WBSDistributeCollection.Item(0).WBS.Name
        '    WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%"
        '    WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price)
        '    WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
        '    WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
        '  Else
        '    Dim j As Integer
        '    For j = 0 To item.WBSDistributeCollection.Count - 1
        '      WBSCostCenter &= item.WBSDistributeCollection.Item(j).CostCenter.Code & ":" & _
        '      item.WBSDistributeCollection.Item(j).CostCenter.Name ' & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
        '      WBSCode &= item.WBSDistributeCollection.Item(j).WBS.Code
        '      WBSName &= item.WBSDistributeCollection.Item(j).WBS.Name
        '      WBSCodePercent &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Percent, DigitConfig.Price)
        '      WBSCodeAmount &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Amount, DigitConfig.Price)
        '      WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).BudgetRemain, DigitConfig.Price)
        '      WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).QtyRemain, DigitConfig.Price)
        '      If j < item.WBSDistributeCollection.Count - 1 Then
        '        WBSCostCenter &= ", "
        '        'WBSCostCentern &= ", "
        '        WBSCode &= ", "
        '        WBSName &= ", "
        '        WBSCodePercent &= ", "
        '        WBSCodeAmount &= ", "
        '        WBSRemainAmount &= ", "
        '        WBSRemainQty &= ", "
        '      End If
        '    Next
        '  End If
        'End If

        For Each dis As WBSDistribute In item.WBSDistributeCollection
          line += 1

          '--สำหรับไว้สร้าง relation ใน schema--=============
          'priw_pri
          dpi = New DocPrintingItem
          dpi.Mapping = "priw_pri"
          dpi.Value = Me.Id
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'priw_prilinenumber
          dpi = New DocPrintingItem
          dpi.Mapping = "priw_prilinenumber"
          dpi.Value = item.LineNumber
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)
          '--สำหรับไว้สร้าง relation ใน schema--=============

          'Item.WBSCostCenter
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCostCenter"
          dpi.Value = dis.CostCenter.Code & ":" & dis.CostCenter.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCode"
          dpi.Value = dis.WBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSName"
          dpi.Value = dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSInfo"
          dpi.Value = dis.WBS.Code & ":" & dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSCode"
          dpi.Value = dis.CBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSName"
          dpi.Value = dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSInfo"
          dpi.Value = dis.CBS.Code & ":" & dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodePercent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodePercent"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Percent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Percent"
          dpi.Value = Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodeAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodeAmount"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.BudgetAmount"
          dpi.Value = dis.BudgetAmount
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainAmount"
          dpi.Value = dis.BudgetRemain
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          ''Item.WBSRemainAmount
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.AmountOverBudget"
          'dpi.Value = dis.AmountOverBudget
          'dpi.DataType = "System.String"
          'dpi.Row = i + 1
          'dpi.Table = "Allocate"
          'dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSBudgetQty"
          dpi.Value = dis.BudgetQty
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainQty"
          dpi.Value = dis.QtyRemain
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          ''Item.WBSRemainAmount
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.QtyOverBudget"
          'dpi.Value = dis.QtyRemain
          'dpi.DataType = "System.String"
          'dpi.Row = i + 1
          'dpi.Table = "Allocate"
          'dpiColl.Add(dpi)
          '--------------------- WBS Section ------------------
        Next


        ''Item.Note
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Note"
        'dpi.Value = item.Note
        'dpi.DataType = "System.String"
        'dpi.Row = i + 1
        'dpi.Table = "Allocate"
        'dpiColl.Add(dpi)

        ''Item.LciNote
        'If TypeOf item.Entity Is IHasNote Then
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.LciNote"
        '  dpi.Value = CType(item.Entity, IHasNote).Note
        '  dpi.DataType = "System.String"
        '  dpi.Row = i + 1
        '  dpi.Table = "Allocate"
        '  dpiColl.Add(dpi)
        'End If

        ''Item.NoteN
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Note" & (i + 1).ToString
        'dpi.Value = item.Note
        'dpi.DataType = "System.String"
        'dpiColl.Add(dpi)


        ''Item.Description '''For Sitem โดยเฉพาะ
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Description"
        'If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
        '  dpi.Value = item.EntityName & vbCrLf & qtyText
        'Else
        '  dpi.Value = item.Entity.Name & vbCrLf & qtyText
        'End If
        'dpi.DataType = "System.String"
        'dpi.Row = i + 1
        'dpi.Table = "Allocate"
        'dpiColl.Add(dpi)

        i += 1

      Next

      Return dpiColl
    End Function
#End Region

#Region " IApprovAble "
    Public Function ApproveData(ByVal Docid As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
      'เปลี่ยนไปใช้ Trigger แทน
      Return New SaveErrorException("0")

      With Me
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Docid))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approveperson", currentUserId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvedate", theTime))

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        ' ให้ Transaction ควบคุมที่ส่วนของ Client เพราะอาจมีหลาย loop ได้
        Try
          SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Approve" & Me.TableName, sqlparams)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Public ReadOnly Property IsApproved() As Boolean Implements IApprovAble.IsApproved
      Get
        If Not (Me.ApprovePerson Is Nothing) AndAlso Me.ApprovePerson.Originated Then
          Return True
        End If
        Return False
      End Get
    End Property
    Public ReadOnly Property ApproveIcon() As String Implements IApprovAble.ApproveIcon
      Get

      End Get
    End Property
    Public ReadOnly Property IsAuthorized As Boolean Implements IApproveStatusAble.IsAuthorized
      Get
        Return Me.IsApproved
      End Get
    End Property
    Public ReadOnly Property IsLevelApproved As Boolean Implements IApproveStatusAble.IsLevelApproved
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            If Not approveDoc.Reject AndAlso approveDoc.Level > 0 Then
              Return True
            End If
          End If
        End If

        Return False
      End Get
    End Property

    Public ReadOnly Property IsReject As Boolean Implements IApproveStatusAble.IsReject
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            Return approveDoc.Reject
          End If
        End If

        Return False
      End Get
    End Property
    Public ReadOnly Property ShowUnApproveButton() As Boolean Implements IApprovAble.ShowUnApproveButton
      Get
        Return Not (Me.Status.Value = 0 OrElse Me.IsClosed)
      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get

      End Get
    End Property
    Public ReadOnly Property IsClosed As Boolean
      Get
        Dim ds As DataSet _
          = SqlHelper.ExecuteDataset(Me.ConnectionString, _
            CommandType.Text, _
            "select isnull(pr_closed,0) from pr where pr_id=" & Me.Id)
        If ds.Tables(0).Rows.Count > 0 Then
          If CInt(ds.Tables(0).Rows(0)(0)) = 1 OrElse CBool(ds.Tables(0).Rows(0)(0)) Then
            Return True
          End If
        End If
        Return False
      End Get
    End Property


#End Region

#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else
          Dim obj As Object = Configuration.GetConfig("ApprovePR")
          If CBool(obj) Then
            If Me.IsAuthorized Then
              Return "Authorized"
            ElseIf Me.IsLevelApproved Then
              Return "Approved"
            ElseIf Me.IsReject Then
              Return "Reject"
            End If
          End If
        End If
        Return ""
      End Get
    End Property
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePR}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim delDocError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
            If Not IsNumeric(delDocError.Message) Then
              trans.Rollback()
              Return delDocError
            Else
              Select Case CInt(delDocError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Return delDocError
                Case Else
              End Select
            End If
          End If
        Next

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePR", New SqlParameter() {New SqlParameter("@pr_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.PRIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)

        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId)
        mldoc.DocMethod = SaveDocMultiApprovalMethod.Delete
        Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, trans)
        If Not IsNumeric(savemldocError.Message) Then
          trans.Rollback()
          Return savemldocError
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

#Region "IHasToCostCenter"
    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
      End Set
    End Property

#End Region

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      'เวลา Copy ให้เอา CustomNote จากอันปัจจุบันมาเก็บไว้ก่อน
      Me.m_customNoteColl = New CustomNoteCollection(Me)

      Me.Status.Value = -1
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      Me.ApproveDate = Date.MinValue
      Me.ApprovePerson = New User
      Me.ApproveStoreDate = Date.MinValue
      Me.ApproveStorePerson = New User
      Me.Canceled = False
      Me.CancelPerson = New User
      'Me.Closing = False
      Me.Closed = False
      Me.ClearReference()
      Dim wbsdummy As WBS
      For Each item As PRItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsdummy = wbsd.WBS
            wbsd.WBS = wbsdummy
          Next
          item.OrderedQty = 0
          item.WithdrawnQty = 0
        End If
      Next
      Return Me
    End Function
#End Region

#Region "IWBSAllocatable"
    Public Property FromCostCenter As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get

      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As PRItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As PRItem In Me.ItemCollection
                For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                  If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                    wbsd.ChildAmount += childWbsd.Amount
                  End If
                Next
              Next
            Next
          End If

          coll.Add(item)
        End If
      Next

      Return coll
    End Function

    Public Property Supplier As Supplier Implements IWBSAllocatable.Supplier
      Get

      End Get
      Set(ByVal value As Supplier)

      End Set
    End Property

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

    '==============CURRENCY=================================
#Region "IHasCurrency"
    Private m_currency As Currency
    Public Property Currency As Currency Implements IHasCurrency.Currency
      Get
        If m_currency Is Nothing Then
          m_currency = Currency.DefaultCurrency.Clone
        End If
        Return m_currency
      End Get
      Set(ByVal value As Currency)
        m_currency = value
      End Set
    End Property
#End Region
    '==============CURRENCY=================================

#Region "IDocumentPersonAble"

    ReadOnly Property DocumentEditedUser As DocumentEditedUser Implements IDocumentPersonAble.DocumentEditedUser
      Get
        Dim m_documentEditedUser As New DocumentEditedUser

        m_documentEditedUser.ApprovedUserList = Me.GetApprovedUserList
        m_documentEditedUser.ApprovedUser = Me.GetApprovedUser
        m_documentEditedUser.AutherizedUser = Me.GetAutherizedUser
        m_documentEditedUser.CanceledUser = Me.GetCanceledUser
        m_documentEditedUser.CreatedUser = Me.GetCreatedUser
        m_documentEditedUser.EditedUser = Me.GetEditedUser
        m_documentEditedUser.EditedUser = Me.GetRejectUser
        m_documentEditedUser.Employee = Me.Requestor

        Return m_documentEditedUser
      End Get
    End Property

    Private Function GetApprovedUserList() As List(Of ApproveDoc)
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            aProvePerson.Add(ap)
          End If
        Next
      End If

      Return aProvePerson
    End Function

    Public Function GetApprovedUser() As EditedUser
      Dim aplist As List(Of ApproveDoc) = Me.GetApprovedUserList
      Dim editeduser As New EditedUser
      If aplist.Count > 1 Then
        Dim userHs As New Hashtable
        Dim maxLevel As Integer = 0
        For Each doc As ApproveDoc In aplist
          userHs(doc.Level) = doc
          maxLevel = Math.Max(maxLevel, doc.Level)
        Next
        'Return New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator)
        editeduser.UserId = CType(userHs(maxLevel - 1), ApproveDoc).Originator
        editeduser.UserName = New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator).Name
        editeduser.EditedDate = CType(userHs(maxLevel - 1), ApproveDoc).OriginDate
      ElseIf aplist.Count > 0 Then
        'Return New User(aplist.Item(aplist.Count - 1).Originator)
        editeduser.UserId = aplist.Item(aplist.Count - 1).Originator
        editeduser.UserName = New User(aplist.Item(aplist.Count - 1).Originator).Name
        editeduser.EditedDate = aplist.Item(aplist.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetAutherizedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.ApprovePerson Is Nothing Then
        editeduser.UserId = Me.ApprovePerson.Id
        editeduser.UserName = Me.ApprovePerson.Name
        editeduser.EditedDate = Me.ApproveDate
      End If
      Return editeduser
    End Function

    Public Function GetCanceledUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.CancelPerson Is Nothing Then
        editeduser.UserId = Me.CancelPerson.Id
        editeduser.UserName = Me.CancelPerson.Name
        editeduser.EditedDate = Me.CancelDate
      End If
      Return editeduser
    End Function

    Public Function GetCreatedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Originator Is Nothing Then
        editeduser.UserId = Me.Originator.Id
        editeduser.UserName = Me.Originator.Name
        editeduser.EditedDate = Me.OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetEditedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not LastEditor Is Nothing Then
        editeduser.UserId = Me.LastEditor.Id
        editeduser.UserName = Me.LastEditor.Name
        editeduser.EditedDate = Me.LastEditDate
      End If
      Return editeduser
    End Function

    Public Function GetRejectUser() As EditedUser
      Dim editeduser As New EditedUser
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        editeduser.UserId = LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator
        editeduser.UserName = New User(LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator).Name
        editeduser.EditedDate = LastLevelApprove.Item(LastLevelApprove.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

#End Region

  End Class

  Public Class PRForApprove
    Inherits PR
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "PRForApprove"
      End Get
    End Property
  End Class
  Public Class PRForMatTransfer
    Inherits PR
    Implements IWithdrawAble, IVisibleButtonShowColorListAble, IHaveItemEntity
    Public Property ItemEntity As Hashtable Implements IHaveItemEntity.ItemEntity
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "PRForMatTransfer"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PRForMatTransfer"
      End Get
    End Property
  End Class
  Public Class PRForMatOperationWithdraw
    Inherits PR
    Implements IWithdrawAble, IVisibleButtonShowColorListAble, IHaveItemEntity
    Public Property ItemEntity As Hashtable Implements IHaveItemEntity.ItemEntity
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "PRForMatOperationWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PRForMatOperationWithdraw"
      End Get
    End Property
  End Class

  Public Class PRForEqToolTransfer
    Inherits PR
    Implements IWithdrawAble, IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "PRForEqToolTransfer"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PRForEqToolTransfer"
      End Get
    End Property
  End Class
End Namespace
