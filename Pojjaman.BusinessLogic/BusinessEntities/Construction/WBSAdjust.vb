Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic
Imports Telerik.WinControls.UI

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class WBSAdjustStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "wbsadj_status"
      End Get
    End Property
#End Region

  End Class
  Public Class WBSAdjust
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, ICancelable, IDuplicable, ICheckPeriod, IWBSAllocatable

#Region "Members"
    Private m_docDate As Date
    Private m_adjustDate As Date
    Private m_allocationType As Integer
    Private m_reason As String
    Private m_note As String
    Private m_adjustPerson As Employee

    Private m_status As WBSAdjustStatus

    Private m_ItemList As List(Of WBSAdjustItem)
    Private m_currentItem As WBSAdjustItem
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
        .m_adjustPerson = New Employee
        .m_status = New WBSAdjustStatus(-1)
        .m_docDate = Now.Date
        .m_adjustDate = Now.Date
        .m_allocationType = 7
        .AutoCodeFormat = New AutoCodeFormat(Me)
        .m_ItemList = New List(Of WBSAdjustItem)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)

      Dim drh As New DataRowHelper(dr)

      m_docDate = drh.GetValue(Of Date)("wbsadj_docdate")
      m_adjustDate = drh.GetValue(Of Date)("wbsadj_adjustdate")
      m_allocationType = drh.GetValue(Of Integer)("wbsadj_allocationType")
      m_reason = drh.GetValue(Of String)("wbsadj_reason")
      m_note = drh.GetValue(Of String)("wbsadj_note")
      m_status = New WBSAdjustStatus(drh.GetValue(Of Integer)("wbsadj_status"))
      m_adjustPerson = New Employee(dr, "") ' drh.GetValue(Of Integer)("wbsadj_adjustPerson"))

      Me.AutoCodeFormat = New AutoCodeFormat(Me)
      Me.GetItemList()
    End Sub
#End Region

#Region "Properties"
    Public Property AllocationType As Integer
      Get
        Return m_allocationType
      End Get
      Set(ByVal value As Integer)
        m_allocationType = value
      End Set
    End Property
    Public Property CurrentItem As WBSAdjustItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal value As WBSAdjustItem)
        m_currentItem = value
      End Set
    End Property
    Public Property ItemList As List(Of WBSAdjustItem)
      Get
        If m_ItemList Is Nothing Then
          m_ItemList = New List(Of WBSAdjustItem)
        End If
        Return m_ItemList
      End Get
      Set(ByVal value As List(Of WBSAdjustItem))
        m_ItemList = value
      End Set
    End Property
    'Private Function GetDeclareAmountFromSproc(ByVal sproc As String, ByVal line As Integer) As Decimal
    'Try
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
    '          Me.ConnectionString _
    '          , CommandType.StoredProcedure _
    '          , sproc _
    '          , New SqlParameter("@prdeclare_pr", Me.Id) _
    '          , New SqlParameter("@prdeclarei_prilinenumber", line) _
    '          , New SqlParameter("@prdeclare_id", 0) _
    '          )
    '  Dim tableIndex As Integer = 0
    '  If ds.Tables.Count > tableIndex Then
    '    If ds.Tables(tableIndex).Rows.Count > 0 Then
    '      If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
    '        Return 0
    '      End If
    '      Return CDec(ds.Tables(tableIndex).Rows(0)(0))
    '    End If
    '  End If
    'Catch ex As Exception
    'End Try
    'End Function
    'Public Function OverBudget() As Boolean
    '  For Each item As PRItem In Me.ItemCollection
    '    Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
    '    'Hack ไปก่อนนะ
    '    wbsdColl.Populate(WBSDistribute.GetSchemaTable, item, 7)
    '    For Each wbsd As WBSDistribute In wbsdColl
    '      If wbsd.AmountOverBudget Then
    '        Return True
    '      End If
    '      If wbsd.QtyOverBudget Then
    '        Return True
    '      End If
    '    Next
    '  Next
    '  Return False
    'End Function
    'Public ReadOnly Property DeclareNote() As String
    '  Get
    '    Return Me.pr_declareNote
    '  End Get
    'End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        'OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property AdjustDate() As Date      Get        Return m_adjustDate      End Get      Set(ByVal Value As Date)        m_adjustDate = Value        'OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property Gross() As Decimal      Get        If Me.ItemList Is Nothing OrElse Me.ItemList.Count = 0 Then          Return 0
        End If        Dim m_gross As Decimal = 0        For Each wbsadji As WBSAdjustItem In Me.ItemList          m_gross += wbsadji.Cost
        Next        Return m_gross      End Get    End Property    Public Property Reason() As String      Get        Return m_reason      End Get      Set(ByVal Value As String)        m_reason = Value        'OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value        'OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property AdjustPerson() As Employee      Get        Return m_adjustPerson      End Get      Set(ByVal Value As Employee)        m_adjustPerson = Value        'OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, WBSAdjustStatus)
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "WBSAdjust"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "WBSAdj"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WBSAdjust.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.WBSAdjust"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.WBSAdjust"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WBSAdjust.ListLabel}"
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
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("WBSAdjust")

      myDatatable.Columns.Add(New DataColumn("linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("itemName", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("pri_unit", GetType(Integer)))
      'myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("pri_qty", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("pri_originqty", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("cost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("costcenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("note", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("pri_unitprice", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("pri_originamt", GetType(String)))

      'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.CodeHeaderText}")
      myDatatable.Columns("itemName").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WBSAdjustPanelView.DescriptionHeaderText}")
      'myDatatable.Columns("Unit").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.UnitHeaderText}")
      'myDatatable.Columns("pri_qty").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.QtyHeaderText}")

      Return myDatatable
    End Function
    'Public Shared Function GetPR(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldPR As PR) As Boolean
    '  Dim prNew As New PR(txtCode.Text)
    '  If txtCode.Text.Length <> 0 AndAlso Not prNew.Valid Then
    '    MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
    '    prNew = oldPR
    '    'ElseIf cc.IsControlGroup Then
    '    '    MessageBox.Show(prNew.Code & "-" & cc.Name & " เป็นกลุ่มแม่")
    '    '    prNew = oldPR
    '  End If
    '  txtCode.Text = prNew.Code
    '  txtName.Text = ""
    '  If oldPR.Id <> prNew.Id Then
    '    oldPR = prNew
    '    Return True
    '  End If
    '  Return False
    'End Function
    'Public Shared Function GetRemainingQtyForTransfer(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal arrKeyList As ArrayList, Optional ByVal includeMatTransferWithNotReceipt As Boolean = False) As DataTable
    '  Dim keyList As String = ""
    '  keyList = String.Join(",", arrKeyList.ToArray)
    '  If keyList.Length > 4000 Then
    '    Throw New Exception("PR Line number over flow") 'ถ้าปล่อยไปเดี๋ยว จะไป loop ใน procedure
    '  End If
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    ', CommandType.StoredProcedure _
    ', "GetPRRemainingForMatTransferList" _
    ', New SqlParameter("@idList", keyList) _
    ', New SqlParameter("@fromCC_id", storeCC) _
    ', New SqlParameter("@stock_id", stockId)
    ')
    '  If ds.Tables(0).Rows.Count > 0 Then
    '    Return ds.Tables(0)
    '  End If

    '  Return Nothing
    'End Function
    'Public Shared Function GetRemainingQtyForWithTransfer(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal prId As Integer, ByVal prLinenumber As Integer) As Decimal
    '  Dim key As String = prId.ToString & ":" & prLinenumber.ToString
    '  Dim arrPritem As New ArrayList
    '  arrPritem.Add(key)
    '  Dim itemQty As Decimal = 0
    '  Dim prTable As DataTable = PR.GetRemainingQtyForTransfer(stockId, storeCC, arrPritem, True)
    '  If Not prTable Is Nothing Then
    '    Dim dr() As DataRow = prTable.Select("keyid='" & key & "'")
    '    Dim drh As New DataRowHelper(dr(0))
    '    itemQty = drh.GetValue(Of Decimal)("RemainingQty")
    '  End If

    '  Return itemQty
    'End Function
    'Public Shared Function GetRemainingQtyForOperationWithdraw(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal arrKeyList As ArrayList, Optional ByVal includeMatTransferWithNotReceipt As Boolean = False) As DataTable
    '  Dim keyList As String = ""
    '  keyList = String.Join(",", arrKeyList.ToArray)
    '  If keyList.Length > 4000 Then
    '    Throw New Exception("PR Line number over flow") 'ถ้าปล่อยไปเดี๋ยว จะไป loop ใน procedure
    '  End If
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    ', CommandType.StoredProcedure _
    ', "GetPRRemainingForMatOperationWithdrawList" _
    ', New SqlParameter("@idList", keyList) _
    ', New SqlParameter("@fromCC_id", storeCC) _
    ', New SqlParameter("@stock_id", stockId)
    ')
    '  If ds.Tables(0).Rows.Count > 0 Then
    '    Return ds.Tables(0)
    '  End If

    '  Return Nothing
    'End Function
    'Public Function CheckIsStoreApproved() As Boolean
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    ', CommandType.StoredProcedure _
    ', "CheckIsStoreApproved" _
    ', New SqlParameter("@pr_id", Me.Id) _
    ')
    '  If ds.Tables(0).Rows.Count > 0 Then
    '    Return CBool(ds.Tables(0).Rows(0)(0))
    '  End If

    '  Return False
    'End Function
    'Public Shared Function GetRemainingQtyForOperationWithdraw(ByVal stockId As Integer, ByVal storeCC As Integer, ByVal prId As Integer, ByVal prLinenumber As Integer) As Decimal
    '  Dim key As String = prId.ToString & ":" & prLinenumber.ToString
    '  Dim arrPritem As New ArrayList
    '  arrPritem.Add(key)
    '  Dim itemQty As Decimal = 0
    '  Dim prTable As DataTable = PR.GetRemainingQtyForTransfer(stockId, storeCC, arrPritem, True)
    '  If Not prTable Is Nothing Then
    '    Dim dr() As DataRow = prTable.Select("keyid='" & key & "'")
    '    Dim drh As New DataRowHelper(dr(0))
    '    itemQty = drh.GetValue(Of Decimal)("RemainingQty")
    '  End If

    '  Return itemQty
    'End Function
#End Region

#Region "Methods"
    Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
      For i As Integer = 0 To items.Count - 1
        If Not TypeOf items(i) Is StockBasketItem Then
          '-----------------LCI Items--------------------

          Dim item As BasketItem = CType(items(i), BasketItem)
          Dim newItem As IHasName
          Dim newType As Integer = -1
          Select Case item.FullClassName.ToLower
            Case "longkong.pojjaman.businesslogic.lciitem", "longkong.pojjaman.businesslogic.lciforlist"
              newItem = New LCIItem(item.Id)
              If targetType > -1 Then
                newType = targetType
              Else
                newType = 42
              End If

            Case "longkong.pojjaman.businesslogic.tool"
              newItem = New Tool(item.Id)
              newType = 19

          End Select

          Dim doc As New WBSAdjustItem
          If Not Me.CurrentItem Is Nothing Then
            doc = Me.CurrentItem
            doc.ItemType.Value = newType
            Me.CurrentItem = Nothing
          Else
            Me.ItemList.Add(doc)
            doc.ItemType = New AdjustAllocateType(newType)
          End If
          doc.SetItemPrice(newItem.Code)
          doc.SetItemCode(newItem.Code)
        ElseIf TypeOf items(i).Tag Is BoqItem Then
          '-----------------BOQ Items--------------------
          Dim bitem As BoqItem = CType(items(i).Tag, BoqItem)
          If bitem.ItemType.Value = 18 Then         'ค่าแรง
            bitem.ItemType.Value = 88
            bitem.Entity.Id = 0
          End If
          If bitem.ItemType.Value = 20 Then         'ค่าเครื่องจักร
            bitem.ItemType.Value = 89
            bitem.Entity.Id = 0
          End If

          Dim matWbsd As New WBSDistribute
          Dim labWbsd As New WBSDistribute
          Dim eqWbsd As New WBSDistribute

          Dim matDoc As WBSAdjustItem
          Dim labDoc As WBSAdjustItem
          Dim eqDoc As WBSAdjustItem
          Dim itemType As Integer
          itemType = bitem.ItemType.Value
          Select Case bitem.ItemType.Value
            Case 42, 0
              If bitem.UMC <> 0 Then              'mat
                matDoc = New WBSAdjustItem
                If Me.ItemList.Count = 0 Then
                  Me.ItemList.Add(matDoc)
                Else
                  If Not Me.CurrentItem Is Nothing Then
                    matDoc = Me.CurrentItem
                  Else
                    Me.ItemList.Add(matDoc)
                  End If
                End If
                matDoc.ItemType = New AdjustAllocateType(bitem.ItemType.Value)
                If bitem.ItemType.Value = 0 Then
                  matDoc.EntityName = bitem.EntityName
                Else
                  matDoc.Entity = bitem.Entity
                End If
                'matDoc.Unit = bitem.Unit
                'matDoc.Qty = bitem.Qty
                matDoc.Cost = bitem.UMC

                If Not bitem.WBS Is Nothing Then
                  matWbsd.IsMarkup = False

                  matWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
                  'matWbsd.CostCenter = Me.m_pr.CostCenter
                  matWbsd.WBS = bitem.WBS
                  matWbsd.Percent = 100
                  matWbsd.BaseCost = bitem.TotalMaterialCost
                  'matWbsd.TransferBaseCost = bitem.TotalMaterialCost
                  matWbsd.IsOutWard = False
                  matWbsd.Toaccttype = 3
                End If
              End If
              If bitem.ULC <> 0 Then              '88 -> Lab
                labDoc = New WBSAdjustItem
                If Me.ItemList.Count = 0 Then
                  Me.ItemList.Add(labDoc)
                Else
                  If Not Me.CurrentItem Is Nothing Then
                    labDoc = Me.CurrentItem
                  Else
                    Me.ItemList.Add(labDoc)
                  End If
                End If
                labDoc.ItemType = New AdjustAllocateType(88)
                If itemType = 42 Then
                  labDoc.Entity = bitem.Entity
                  labDoc.EntityName = bitem.Entity.Name
                Else
                  labDoc.EntityName = bitem.Entity.Name
                End If
                'labDoc.Unit = bitem.Unit
                'labDoc.Qty = bitem.Qty
                labDoc.Cost = bitem.ULC
                If Not bitem.WBS Is Nothing Then
                  labWbsd.IsMarkup = False
                  labWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
                  labWbsd.WBS = bitem.WBS
                  labWbsd.Percent = 100
                  labWbsd.BaseCost = bitem.TotalLaborCost
                  'labWbsd.TransferBaseCost = bitem.TotalLaborCost
                  labWbsd.IsOutWard = False
                  labWbsd.Toaccttype = 3
                End If
              End If
              If bitem.UEC <> 0 Then              '89 -> EQ
                eqDoc = New WBSAdjustItem
                If Me.ItemList.Count = 0 Then
                  Me.ItemList.Add(eqDoc)
                Else
                  If Not Me.CurrentItem Is Nothing Then
                    eqDoc = Me.CurrentItem
                  Else
                    Me.ItemList.Add(eqDoc)
                  End If
                End If
                eqDoc.ItemType = New AdjustAllocateType(89)
                If itemType = 42 Then
                  eqDoc.Entity = bitem.Entity
                  eqDoc.EntityName = bitem.Entity.Name
                Else
                  eqDoc.EntityName = bitem.Entity.Name
                End If
                'eqDoc.Unit = bitem.Unit
                'eqDoc.Qty = bitem.Qty
                eqDoc.Cost = bitem.UEC
                If Not bitem.WBS Is Nothing Then
                  eqWbsd.IsMarkup = False
                  eqWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
                  eqWbsd.WBS = bitem.WBS
                  eqWbsd.Percent = 100
                  eqWbsd.BaseCost = bitem.TotalEquipmentCost
                  'eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
                  eqWbsd.IsOutWard = False
                  eqWbsd.Toaccttype = 3
                End If
              End If
            Case 88, 89
              Dim doc As WBSAdjustItem
              Dim tempUnitPrice As Decimal
              If Me.ItemList.Count = 0 Then
                If bitem.ItemType.Value = 88 Then
                  labDoc = New WBSAdjustItem
                  doc = labDoc
                  tempUnitPrice = bitem.ULC
                End If
                If bitem.ItemType.Value = 89 Then
                  eqDoc = New WBSAdjustItem
                  doc = eqDoc
                  tempUnitPrice = bitem.UEC
                End If
                Me.ItemList.Add(doc)
              Else
                If bitem.ItemType.Value = 88 Then
                  labDoc = New WBSAdjustItem
                  If Not Me.CurrentItem Is Nothing Then
                    labDoc = Me.CurrentItem
                  Else
                    Me.ItemList.Add(labDoc)
                  End If
                  doc = labDoc
                  tempUnitPrice = bitem.ULC
                End If
                If bitem.ItemType.Value = 89 Then
                  eqDoc = New WBSAdjustItem
                  If Not Me.CurrentItem Is Nothing Then
                    eqDoc = Me.CurrentItem
                  Else
                    Me.ItemList.Add(eqDoc)
                  End If
                  doc = eqDoc
                  tempUnitPrice = bitem.UEC
                End If
              End If

              doc.ItemType = New AdjustAllocateType(bitem.ItemType.Value)
              doc.Entity = bitem.Entity
              doc.EntityName = bitem.Entity.Name
              'doc.Unit = bitem.Unit
              'doc.Qty = bitem.Qty
              doc.Cost = tempUnitPrice
              If bitem.ItemType.Value = 88 Then
                If Not bitem.WBS Is Nothing Then
                  labWbsd.IsMarkup = False
                  labWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
                  labWbsd.WBS = bitem.WBS
                  labWbsd.Percent = 100
                  labWbsd.BaseCost = bitem.TotalLaborCost
                  'labWbsd.TransferBaseCost = bitem.TotalLaborCost
                  labWbsd.IsOutWard = False
                  labWbsd.Toaccttype = 3
                End If
              End If
              If bitem.ItemType.Value = 89 Then
                If Not bitem.WBS Is Nothing Then
                  eqWbsd.IsMarkup = False
                  eqWbsd.CostCenter = bitem.BOQ.GetCCFromBOQ
                  eqWbsd.WBS = bitem.WBS
                  eqWbsd.Percent = 100
                  eqWbsd.BaseCost = bitem.TotalEquipmentCost
                  'eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
                  eqWbsd.IsOutWard = False
                  eqWbsd.Toaccttype = 3
                End If
              End If
          End Select

          If matWbsd.Percent = 100 Then
            If Not matDoc Is Nothing Then
              matDoc.WBSDistributeCollection.Add(matWbsd)
              'matDoc.Pr.SetActual(matWbsd.WBS, 0, matDoc.Amount, matDoc.ItemType.Value)
            End If
          End If
          If labWbsd.Percent = 100 Then
            If Not labDoc Is Nothing Then
              labDoc.WBSDistributeCollection.Add(labWbsd)
              'labDoc.Pr.SetActual(labWbsd.WBS, 0, labDoc.Amount, labDoc.ItemType.Value)
            End If
          End If
          If eqWbsd.Percent = 100 Then
            If Not eqDoc Is Nothing Then
              eqDoc.WBSDistributeCollection.Add(eqWbsd)
              'eqDoc.Pr.SetActual(eqWbsd.WBS, 0, eqDoc.Amount, eqDoc.ItemType.Value)
            End If
          End If

        End If
      Next
      'RefreshBudget()
    End Sub
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each wbsi As WBSAdjustItem In Me.ItemList
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        wbsi.CopyToDataRow(newRow)
        wbsi.ItemValidateRow(newRow)
        newRow.Tag = wbsi
      Next
    End Sub
    Public Sub GetItemList()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, _
                                                   CommandType.StoredProcedure, _
                                                   "GetWBSAdjustItems", _
                                                    New SqlParameter() {New SqlParameter("@wbsadj_id", Me.Id), _
                                                                        New SqlParameter("@wbsadj_allocationType", Me.AllocationType)} _
                                                    )
      m_ItemList = New List(Of WBSAdjustItem)
      For Each row As DataRow In ds.Tables(0).Rows
        Dim wbsadji As New WBSAdjustItem(row, "")
        wbsadji.WBSAdjust = Me
        m_ItemList.Add(wbsadji)

        'SET WBS =================>>>
        Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
        AddHandler wbsdColl.PropertyChanged, AddressOf wbsadji.WBSChangedHandler
        wbsadji.WBSDistributeCollection = wbsdColl
        For Each wbsRow As DataRow In ds.Tables(1).Select("wbsadjiw_sequence=" & wbsadji.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdColl.Add(wbsd)

          '--Budget Remain =========================================================
          Dim budgetRow() As DataRow = ds.Tables(2).Select("wbs_id=" & wbsd.WBS.Id)
          If budgetRow.Length > 0 Then
            Dim drh As New DataRowHelper(budgetRow(0))
            If wbsd.IsMarkup Then
              wbsd.BudgetRemain = drh.GetValue(Of Decimal)("totalactual")
            Else
              Select Case wbsadji.ItemType.Value
                Case 0
                  wbsd.BudgetRemain = drh.GetValue(Of Decimal)("matactual")
                  wbsd.WBS.GetTotalMatFromDB()
                  wbsd.OwnerBudgetAmount = wbsd.WBS.OwnerMatBudgetAmount
                Case 1
                  wbsd.BudgetRemain = drh.GetValue(Of Decimal)("labactual")
                  wbsd.WBS.GetTotalLabFromDB()
                  wbsd.OwnerBudgetAmount = wbsd.WBS.OwnerLabBudgetAmount
                Case 2
                  wbsd.BudgetRemain = drh.GetValue(Of Decimal)("eqactual")
                  wbsd.WBS.GetTotalEQFromDB()
                  wbsd.OwnerBudgetAmount = wbsd.WBS.OwnerEqBudgetAmount
              End Select
              'Trace.WriteLine(wbsd.WBS.Code & ":" & Configuration.FormatToString(wbsd.BudgetRemain, 2))
            End If
          End If

          '--Qty Budget Remain =====================================================
          'Dim qtyRow() As DataRow = ds.Tables(3).Select("boqi_wbs=" & wbsd.WBS.Id)
          'If qtyRow.Length > 0 Then
          '  Dim qtydrh As New DataRowHelper(qtyRow(0))
          '  If wbsd.IsMarkup Then
          '    wbsd.QtyRemain = 0
          '  Else
          '    If wbsadji.ItemType.Value = 88 OrElse wbsadji.ItemType.Value = 89 Then
          '      wbsd.QtyRemain = 0
          '    Else
          '      wbsd.QtyRemain = qtydrh.GetValue(Of Decimal)("qtybudgetremain")
          '    End If
          '  End If
          'End If

        Next
        'SET WBS =================<<<

      Next
    End Sub
    'Public Sub AddNewItem(ByVal rg As RadGridView)
    '  Dim tr As GridViewDataRowInfo = rg.Rows.AddNew()
    '  tr.Tag = New WBSAdjustItem
    'End Sub
    'Public Sub Populate(ByVal rg As RadGridView)

    '  rg.Rows.Clear()

    '  Dim lineNumber As Integer = 0
    '  For Each wbsi As WBSAdjustItem In Me.ItemList
    '    'If tr Is Nothing Then
    '    '  Return
    '    'End If
    '    Dim tr As GridViewDataRowInfo = rg.Rows.AddNew()

    '    lineNumber += 1

    '    'If tr.ViewTemplate.Columns.Contains("SelectedForDeleted") Then
    '    '  tr.Cells("SelectedForDeleted").Value = p.SelectedForDeleted
    '    'End If
    '    'If tr.ViewTemplate.Columns.Contains("Selected") Then
    '    '  tr.Cells("Selected").Value = p.Selected
    '    'End If
    '    tr.Cells("lineNumber").Value = lineNumber
    '    tr.Cells("itemType").Value = wbsi.ItemType.Description
    '    tr.Cells("code").Value = wbsi.Entity.Code
    '    'tr.Cells("entity").Value = ""
    '    tr.Cells("description").Value = wbsi.EntityName
    '    tr.Cells("cost").Value = Configuration.FormatToString(wbsi.Cost, DigitConfig.Price)
    '    'tr.Cells("costcenter").Value = wbsi.CostCenterId
    '    'tr.Cells("findcc").Value = ""
    '    tr.Cells("note").Value = wbsi.Note

    '    tr.Tag = wbsi
    '  Next

    '  Me.AddNewItem(rg)

    'End Sub
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As WBSAdjustItem In Me.ItemList
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

      'If Me.CostCenter.Type.Value <> 2 Then
      '  Return New SaveErrorException("-1")
      'End If
      'If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
      '  Return New SaveErrorException("-1")
      'End If

      'PROverBudgetOnlyCC
      Dim config As Object
      Select Case Me.AllocationType
        Case 6
          config = Configuration.GetConfig("POOverBudgetOnlyCC")
        Case 7
          config = Configuration.GetConfig("PROverBudgetOnlyCC")
        Case 45
          config = Configuration.GetConfig("GROverBudgetOnlyCC")
        Case 31
          config = False
      End Select
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      'PROverBudgetOnlyWBSAllocat
      Select Case Me.AllocationType
        Case 6
          config = Configuration.GetConfig("POOverBudgetOnlyWBSAllocate")
        Case 7
          config = Configuration.GetConfig("PROverBudgetOnlyWBSAllocate")
        Case 45
          config = Configuration.GetConfig("GROverBudgetOnlyWBSAllocate")
        Case 31
          config = False
      End Select
      Dim onlyWBSAllocate As Boolean = False
      If Not config Is Nothing Then
        onlyWBSAllocate = CBool(config)
      End If

      '====================
      WBS.ParentBudgetHash = New Hashtable 'ห้ามลืมเด็ดขาด
      '====================
      Dim idList As String = Me.ListWbsId
      Dim dsParentBudget As New DataSet
      dsParentBudget = WBS.GetParentsBudgetList(Me.AllocationType, idList)
      Dim currwbsId As Integer

      If Not onlyCC Then
        For Each item As WBSAdjustItem In Me.ItemList
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrent As Decimal = 0
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              Dim validateBudget As Boolean = True

              If wbsd.CostCenter.Type.Value <> 2 Then
                validateBudget = False
              End If
              If wbsd.CostCenter.Boq Is Nothing OrElse wbsd.CostCenter.Boq.Id = 0 Then
                validateBudget = False
              End If

              If validateBudget Then
                totalCurrent = (wbsd.Percent / 100) * item.Cost

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
              End If

            Next
            If item.WBSDistributeCollection.GetSumPercent = 0 Then
              'สำหรับ Auto จัดสรร
              For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                Dim rootWBS As New WBS(wbsd.CostCenter.RootWBSId)
                Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
                Dim tActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
                Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
                Dim cActual As Decimal = item.Cost
                Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
                If onlyWBSAllocate Then
                  If oBudget < ((tActual - thisActual) + cActual) Then
                    Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
                  End If
                End If
                If tBudget < ((tActual - thisActual) + cActual) Then
                  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
                End If
              Next

            End If
          End If
        Next
      Else
        Dim hCC As New Hashtable
        For Each item As WBSAdjustItem In Me.ItemList
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            'สำหรับ Auto จัดสรร
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              Dim rootWBS As New WBS(wbsd.CostCenter.RootWBSId)
              Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, Me.EntityId) + rootWBS.GetActualLab(Me, Me.EntityId) + rootWBS.GetActualEq(Me, Me.EntityId))
              Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
              Dim currentActual As Decimal = item.Cost
              Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
              If onlyWBSAllocate Then
                If oBudget < ((totalActual - thisActual) + currentActual) Then
                  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
                End If
              End If
              If totalBudget < ((totalActual - thisActual) + currentActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            Next

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

      End If

      Return New SaveErrorException("0")
    End Function
    Private Function ValidateItem() As SaveErrorException
      Dim key As String = ""

      For Each item As WBSAdjustItem In Me.ItemList

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
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim oldcode As String
      With Me
        Dim docValidate As Boolean = True
        If Me.Originated AndAlso Me.Status.Value = 0 Then
          docValidate = False
        End If

        If docValidate Then
          If Me.ItemList.Count = 0 Then   '.ItemTable.Childs.Count = 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
          End If
          Dim ValidateError As SaveErrorException = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          End If

          'Check Over Budget ====================================
          Dim ValidateOverBudgetError As SaveErrorException
          Dim config As Integer
          Select Case Me.AllocationType
            Case 6
              config = CInt(Configuration.GetConfig("POOverBudget"))
            Case 7
              config = CInt(Configuration.GetConfig("PROverBudget"))
            Case 45
              config = CInt(Configuration.GetConfig("GROverBudget"))
            Case 31
              config = 2
          End Select

          'config=CInt(Configuration.GetConfig("PROverBudget"))
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
          paramArrayList.Add(New SqlParameter("@wbsadj_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        oldcode = Me.Code
        If Me.AutoGen Then   'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        paramArrayList.Add(New SqlParameter("@wbsadj_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@wbsadj_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@wbsadj_adjustDate", Me.ValidDateOrDBNull(Me.AdjustDate)))
        paramArrayList.Add(New SqlParameter("@wbsadj_adjustPerson", Me.ValidIdOrDBNull(Me.AdjustPerson)))
        paramArrayList.Add(New SqlParameter("@wbsadj_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@wbsadj_allocationType", Me.AllocationType))
        paramArrayList.Add(New SqlParameter("@wbsadj_reason", Me.Reason))
        paramArrayList.Add(New SqlParameter("@wbsadj_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@wbsadj_status", Me.Status.Value))
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
        Dim oldautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
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

            'Select Case Me.AllocationType
            '  Case 6
            '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")
            '  Case 7
            '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")
            '  Case 45
            '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateGRWBSActual")
            '  Case 31
            '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMATWBSActual")
            'End Select

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
            'Return New SaveErrorException(returnVal.Value.ToString)
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
            'Finally
            '  conn.Close()
          End Try

          '--Sub Save Block-- ============================================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
            Return New SaveErrorException(returnVal.Value.ToString)
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
        Select Case Me.AllocationType
          Case 6
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")
          Case 7
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")
          Case 45
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateGRWBSActual")
          Case 31
            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMATWBSActual")
        End Select
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from wbsadjustitem where wbsadji_wbsadj=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from wbsadjustiwbs where wbsadjiw_sequence in (select wbsadji_sequence from wbsadjustitem where wbsadji_wbsadj=" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From wbsadjustitem Where wbsadji_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "wbsadjustitem")
        da.Fill(ds, "wbsadjustitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "wbsadjustiwbs")
        daWbs.Fill(ds, "wbsadjustiwbs")
        ds.Relations.Add("sequence", ds.Tables!wbsadjustitem.Columns!wbsadji_sequence, ds.Tables!wbsadjustiwbs.Columns!wbsadjiw_sequence)

        Dim dt As DataTable = ds.Tables("wbsadjustitem")
        Dim dtWbs As DataTable = ds.Tables("wbsadjustiwbs")

        For Each row As DataRow In ds.Tables("wbsadjustiwbs").Rows
          row.Delete()
        Next
        'For Each row As DataRow In ds.Tables("wbsadjustitem").Rows
        '  row.Delete()
        'Next
        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As WBSAdjustItem In Me.ItemList
            If testItem.Sequence = CInt(dr("wbsadji_sequence")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        '------------End Checking--------------------
        Dim i As Integer = 0       'Line Running
        'Dim beforeSaveQty As Decimal
        Dim seq As Integer = -1
        With ds.Tables("wbsadjustitem")
          For Each item As WBSAdjustItem In Me.ItemList
            i += 1
            '------------Checking if we have to add a new row or just update existing--------------------
            Dim dr As DataRow
            Dim drs As DataRow() = dt.Select("wbsadji_sequence=" & item.Sequence)
            If drs.Length = 0 Then
              dr = dt.NewRow
              'dt.Rows.Add(dr)
              seq = seq + (-1)
              dr("wbsadji_sequence") = seq
            Else
              dr = drs(0)
            End If
            '------------End Checking--------------------

            dr("wbsadji_wbsadj") = Me.Id
            dr("wbsadji_linenumber") = i
            'dr("wbsadji_entity") = item.Entity.Id
            dr("wbsadji_entityType") = item.ItemType.Value
            dr("wbsadji_itemName") = item.EntityName
            dr("wbsadji_costAmount") = item.Cost
            dr("wbsadji_note") = item.Note
            dr("wbsadji_status") = Me.Status.Value

            '------------Checking if we have to add a new row or just update existing--------------------
            If drs.Length = 0 Then
              dt.Rows.Add(dr)
            End If
            '------------End Checking--------------------

            Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
            Dim currentSum As Decimal = wbsdColl.GetSumPercent
            For Each wbsd As WBSDistribute In wbsdColl
              Dim rootWBS As New WBS(wbsd.CostCenter.RootWBSId)
              If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                'ยังไม่เต็ม 100 แต่มีหัวอยู่
                wbsd.Percent += (100 - currentSum)
              End If

              wbsd.BaseCost = Math.Abs(item.Cost)

              Dim childDr As DataRow = dtWbs.NewRow
              childDr("wbsadjiw_wbs") = wbsd.WBS.Id
              If wbsd.CostCenter Is Nothing Then
                wbsd.CostCenter = Me.ToCostCenter
              End If
              childDr("wbsadjiw_cc") = wbsd.CostCenter.Id
              childDr("wbsadjiw_percent") = wbsd.Percent
              childDr("wbsadjiw_sequence") = dr("wbsadji_sequence")
              childDr("wbsadjiw_ismarkup") = wbsd.IsMarkup
              childDr("wbsadjiw_direction") = item.Direction
              childDr("wbsadjiw_baseCost") = wbsd.BaseCost
              childDr("wbsadjiw_amt") = wbsd.Amount
              childDr("wbsadjiw_toaccttype") = 3
              childDr("wbsadjiw_cbs") = wbsd.CBS.Id
              'Add เข้า priwbs
              dtWbs.Rows.Add(childDr)
            Next

          Next
        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

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
        Dim currentkey As Integer = CInt(e.Row("wbsadjiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!wbsadjiw_sequence = e.Row.GetParentRow("sequence")("wbsadji_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!wbsadjiw_sequence = currentkey
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

      ''Code
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Code"
      'dpi.Value = Me.Code
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''DocDate
      'dpi = New DocPrintingItem
      'dpi.Mapping = "DocDate"
      'dpi.Value = Me.DocDate.ToShortDateString
      'dpi.DataType = "System.DateTime"
      'dpiColl.Add(dpi)

      ''ReceivingDate
      'dpi = New DocPrintingItem
      'dpi.Mapping = "ReceivingDate"
      'dpi.Value = Me.ReceivingDate.ToShortDateString
      'dpi.DataType = "System.DateTime"
      'dpiColl.Add(dpi)

      ''TermNote
      'dpi = New DocPrintingItem
      'dpi.Mapping = "TermNote"
      'dpi.Value = Me.TermNote
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''DeliveryTime
      'dpi = New DocPrintingItem
      'dpi.Mapping = "DeliveryTime"
      'dpi.Value = Me.DeliveryTime
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''PlaceOfDelivery
      'dpi = New DocPrintingItem
      'dpi.Mapping = "PlaceOfDelivery"
      'dpi.Value = Me.PlaceOfDelivery
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''Attachment
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Attachment"
      'dpi.Value = Me.Attachment
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''Special
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Special"
      'dpi.Value = Me.SpecialCondition
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
      '  'CostCenter
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "CostCenter"
      '  dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  'CostCenterInfo
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "CostCenterInfo"
      '  dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  'CostCenterName
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "CostCenterName"
      '  dpi.Value = Me.CostCenter.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  'CostCenterCode
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "CostCenterCode"
      '  dpi.Value = Me.CostCenter.Code
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  If Not Me.CostCenter.Customer Is Nothing AndAlso Me.CostCenter.Customer.Originated Then
      '    'Customer
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Customer"
      '    dpi.Value = Me.CostCenter.Customer.Code & ":" & Me.CostCenter.Customer.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    'CustomerName
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "CustomerName"
      '    dpi.Value = Me.CostCenter.Customer.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    'CustomerCode
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "CustomerCode"
      '    dpi.Value = Me.CostCenter.Customer.Code
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      '  End If
      'End If

      'If Not Me.Requestor Is Nothing AndAlso Me.Requestor.Originated Then
      '  'Requestor
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Requestor"
      '  dpi.Value = Me.Requestor.Code & ":" & Me.Requestor.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  'RequestorInfo
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "RequestorInfo"
      '  dpi.Value = Me.Requestor.Code & ":" & Me.Requestor.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  'RequestorCode
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "RequestorCode"
      '  dpi.Value = Me.Requestor.Code
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  'RequestorName
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "RequestorName"
      '  dpi.Value = Me.Requestor.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)
      'End If

      ''Note
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Note"
      'dpi.Value = Me.Note
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''Mapping การอนุมัติ #917
      'Dim appTable As DataTable = BusinessEntity.GetApprovePersonListfromDoc(Me.Id, Me.EntityId)
      'If appTable.Rows.Count > 0 Then
      '  For Each row As DataRow In appTable.Rows
      '    Dim deh As New DataRowHelper(row)
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "ApprovePersonNameLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
      '    dpi.Value = deh.GetValue(Of String)("user_name")
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "ApprovePersonCodeLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
      '    dpi.Value = deh.GetValue(Of String)("user_code")
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "ApprovePersonInfoLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
      '    dpi.Value = deh.GetValue(Of String)("user_name") & ":" & deh.GetValue(Of String)("user_code")
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "ApprovePersonDateLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
      '    dpi.Value = deh.GetValue(Of Date)("apvdate").ToShortDateString
      '    dpi.DataType = "System.DateTime"
      '    dpiColl.Add(dpi)
      '  Next

      'End If


      'Dim line As Integer = 0
      'Dim counter As Integer = 0
      'Dim i As Integer = 0
      'For Each item As PRItem In Me.ItemCollection
      '  'Item.Code
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Code"
      '  dpi.Value = item.Entity.Code
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  Dim qtyText As String = ""
      '  If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
      '    line += 1
      '    'Item.LineNumber
      '    '************** เอามาไว้เป็นอันที่ 2
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.LineNumber"
      '    dpi.Value = line
      '    dpi.DataType = "System.Int32"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Unit
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Unit"
      '    dpi.Value = item.Unit.Name
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.UnitPrice
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.UnitPrice"
      '    If item.UnitPrice = 0 Then
      '      dpi.Value = ""
      '    Else
      '      dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
      '    End If
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.UnitPriceN
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.UnitPrice" & (i + 1).ToString
      '    If item.UnitPrice = 0 Then
      '      dpi.Value = ""
      '    Else
      '      dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
      '    End If
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    'Item.Amount
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Amount"
      '    If item.Amount = 0 Then
      '      dpi.Value = ""
      '    Else
      '      dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      '    End If
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.UnitN
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Unit" & (i + 1).ToString
      '    dpi.Value = item.Unit.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    'Item.Qty
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Qty"
      '    If item.Qty = 0 Then
      '      dpi.Value = ""
      '    Else
      '      dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
      '    End If
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.QtyN
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Qty" & (i + 1).ToString
      '    dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    qtyText = Configuration.FormatToString(item.Qty, DigitConfig.Qty) & " " & item.Unit.Name
      '  End If

      '  'Item.Name
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Name"
      '  If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
      '    dpi.Value = item.EntityName
      '  Else
      '    dpi.Value = item.Entity.Name
      '  End If
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.NameN
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Name" & (i + 1).ToString
      '  If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
      '    dpi.Value = item.EntityName
      '  Else
      '    dpi.Value = item.Entity.Name
      '  End If
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  '--------------------- WBS Section ------------------
      '  Dim WBSCostCenter As String = ""
      '  Dim WBSCode As String = ""
      '  Dim WBSName As String = ""
      '  Dim WBSCodePercent As String = ""
      '  Dim WBSCodeAmount As String = ""
      '  Dim WBSRemainAmount As String = ""
      '  Dim WBSRemainQty As String = ""
      '  If item.WBSDistributeCollection.Count > 0 Then
      '    'Populate ให้คำนวณคงเหลือแบบหลอกๆ
      '    'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
      '    If item.WBSDistributeCollection.Count = 1 Then
      '      WBSCostCenter = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & _
      '      item.WBSDistributeCollection.Item(0).CostCenter.Name 'Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
      '      WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
      '      WBSName = item.WBSDistributeCollection.Item(0).WBS.Name
      '      WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%"
      '      WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price)
      '      WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
      '      WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
      '    Else
      '      Dim j As Integer
      '      For j = 0 To item.WBSDistributeCollection.Count - 1
      '        WBSCostCenter &= item.WBSDistributeCollection.Item(j).CostCenter.Code & ":" & _
      '        item.WBSDistributeCollection.Item(j).CostCenter.Name ' & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
      '        WBSCode &= item.WBSDistributeCollection.Item(j).WBS.Code
      '        WBSName &= item.WBSDistributeCollection.Item(j).WBS.Name
      '        WBSCodePercent &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Percent, DigitConfig.Price)
      '        WBSCodeAmount &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Amount, DigitConfig.Price)
      '        WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).BudgetRemain, DigitConfig.Price)
      '        WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).QtyRemain, DigitConfig.Price)
      '        If j < item.WBSDistributeCollection.Count - 1 Then
      '          WBSCostCenter &= ", "
      '          'WBSCostCentern &= ", "
      '          WBSCode &= ", "
      '          WBSName &= ", "
      '          WBSCodePercent &= ", "
      '          WBSCodeAmount &= ", "
      '          WBSRemainAmount &= ", "
      '          WBSRemainQty &= ", "
      '        End If
      '      Next
      '    End If
      '  End If

      '  'Item.WBSCostCenter
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.WBSCostCenter"
      '  dpi.Value = WBSCostCenter
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.WBSCode
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.WBSCode"
      '  dpi.Value = WBSCode
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.WBSName
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.WBSName"
      '  dpi.Value = WBSName
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.WBSCodePercent
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.WBSCodePercent"
      '  dpi.Value = WBSCodePercent
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.WBSCodeAmount
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.WBSCodeAmount"
      '  dpi.Value = WBSCodeAmount
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.WBSRemainAmount
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.WBSRemainAmount"
      '  dpi.Value = WBSRemainAmount
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.WBSRemainQty
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.WBSRemainQty"
      '  dpi.Value = WBSRemainQty
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)
      '  '--------------------- WBS Section ------------------

      '  'Item.Note
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Note"
      '  dpi.Value = item.Note
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  'Item.LciNote
      '  If TypeOf item.Entity Is IHasNote Then
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.LciNote"
      '    dpi.Value = CType(item.Entity, IHasNote).Note
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)
      '  End If

      '  'Item.NoteN
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Note" & (i + 1).ToString
      '  dpi.Value = item.Note
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)


      '  'Item.Description '''For Sitem โดยเฉพาะ
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "Item.Description"
      '  If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
      '    dpi.Value = item.EntityName & vbCrLf & qtyText
      '  Else
      '    dpi.Value = item.Entity.Name & vbCrLf & qtyText
      '  End If
      '  dpi.DataType = "System.String"
      '  dpi.Row = i + 1
      '  dpi.Table = "Item"
      '  dpiColl.Add(dpi)

      '  i += 1
      'Next

      ''SumItemQty
      'dpi = New DocPrintingItem
      'dpi.Mapping = "SumItemQty"
      'dpi.Value = Configuration.FormatToString(line, DigitConfig.Qty)
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''*************************************LastPage********************************
      'If Me.Gross <> 0 Then
      '  'LastPageGross
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "LastPageGross"
      '  dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      '  dpi.DataType = "System.Decimal"
      '  dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      '  dpiColl.Add(dpi)
      'End If


      'dpiColl.AddRange(GetAllocateDocPrinting)

      Return dpiColl

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
        'For Each extender As Object In Me.Extenders
        '  If TypeOf extender Is IExtender Then
        '    Dim delDocError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
        '    If Not IsNumeric(delDocError.Message) Then
        '      trans.Rollback()
        '      Return delDocError
        '    Else
        '      Select Case CInt(delDocError.Message)
        '        Case -1, -2, -5
        '          trans.Rollback()
        '          Return delDocError
        '        Case Else
        '      End Select
        '    End If
        '  End If
        'Next

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
                                  "DeleteWBSAdjust", _
                                  New SqlParameter() { _
                                    New SqlParameter("@wbsadj_id", Me.Id), _
                                    New SqlParameter("@wbsadj_allocationType", Me.AllocationType), _
                                    returnVal} _
                                  )
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              'Return New SaveErrorException("${res:Global.PRIsReferencedCannotBeDeleted}")
              Return New SaveErrorException("This document is referenced, Can not be delete.")
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

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      ''เวลา Copy ให้เอา CustomNote จากอันปัจจุบันมาเก็บไว้ก่อน
      'Me.m_customNoteColl = New CustomNoteCollection(Me)

      Me.Status.Value = 2
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code

      Me.Canceled = False
      Me.CancelPerson = New User
      Me.ClearReference()
      Dim wbsdummy As WBS
      For Each item As WBSAdjustItem In Me.ItemList
        For Each wbsd As WBSDistribute In item.WBSDistributeCollection
          wbsdummy = wbsd.WBS
          wbsd.WBS = wbsdummy
        Next
      Next
      Return Me
    End Function
#End Region

#Region "IWBSAllocatable"
    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As WBSAdjustItem In Me.ItemList
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          'item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As WBSAdjustItem In Me.ItemList
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
        Return True
      End Get
    End Property

    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IWBSAllocatable.AllowWBSAllocateTo
      Get
        Return True
      End Get
    End Property

    Public Property FromCostCenter As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get
        Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property

    Public Property ToCostCenter As CostCenter Implements IWBSAllocatable.ToCostCenter
      Get
        Return CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End Get
      Set(ByVal value As CostCenter)

      End Set
    End Property
#End Region

  End Class
End Namespace
