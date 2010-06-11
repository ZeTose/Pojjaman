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
  Public Class VO
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, ICancelable, IHasToCostCenter, IDuplicable, ICheckPeriod, IWBSAllocatable, IApprovAble

#Region "Members"
    Private m_docDate As Date
    Private m_VO As VO
    Private m_note As String
    Private m_gross As Decimal
    Private m_discount As Discount
    Private m_beforeTax As Decimal
    Private m_taxGross As Decimal
    Private m_taxBase As Decimal
    Private m_taxRate As Decimal
    Private m_taxType As TaxType
    Private m_taxAmount As Decimal
    Private m_realTaxBase As Decimal
    Private m_afterTax As Decimal
    Private m_realGross As Decimal
    Private m_realTaxAmount As Decimal
    Private m_customNoteColl As CustomNoteCollection
    Private m_status As VOStatus
    Private m_sc As SC
    Private m_itemCollection As VOItemCollection
    Private m_subcontractor As Supplier
    Private m_cc As CostCenter
    Private m_approvePerson As User
    Private m_approveDate As DateTime

    Private m_closed As Boolean
    Private m_closing As Boolean

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
        .m_cc = New CostCenter
        .DocDate = Now.Date
        .m_subcontractor = New Supplier

        .m_sc = New SC
        .m_note = ""
        .m_gross = 0
        .m_discount = New Discount("")
        .m_beforeTax = 0
        .m_taxBase = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_taxGross = 0
        .m_taxAmount = 0
        .m_afterTax = 0
        .m_realTaxBase = 0
        .m_realGross = 0
        .m_realTaxAmount = 0
        .m_status = New VOStatus(-1)
        .AutoCodeFormat = New AutoCodeFormat(Me)

      End With

      m_itemCollection = New VOItemCollection(Me)

    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        '' sc
        If dr.Table.Columns.Contains("vo_sc") Then
          If Not dr.IsNull("vo_sc") Then
            .m_sc = New SC(CInt(dr("vo_sc")))
            '.m_subcontractor = New Supplier(dr, "supplier.")
          End If
        End If
        If dr.Table.Columns.Contains("vo_docdate") AndAlso Not dr.IsNull("vo_docdate") Then
          If IsDate(dr("vo_docdate")) Then
            .m_docDate = CDate(dr("vo_docdate"))
          End If
          '.m_subcontractor = New Supplier(dr, "supplier.")
        End If
        If dr.Table.Columns.Contains("vo_note") AndAlso Not dr.IsNull("vo_note") Then
          .m_note = CStr(dr("vo_note"))
        End If
        If dr.Table.Columns.Contains("vo_status") AndAlso Not dr.IsNull("vo_status") Then
          .m_status = New VOStatus(CInt(dr("vo_status")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vo_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "vo_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "vo_taxtype")))
        End If
        If Not dr.IsNull(aliasPrefix & "vo_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "vo_taxrate"))
        End If
        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "vo_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "vo_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "vo_taxbase"))
        End If

        ' Gross
        If dr.Table.Columns.Contains(aliasPrefix & "vo_gross") _
        AndAlso Not dr.IsNull(aliasPrefix & "vo_gross") Then
          .m_realGross = CDec(dr(aliasPrefix & "vo_gross"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "vo_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "vo_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "vo_taxamt"))
        End If
        '--------------------END REAL-------------------------

        If dr.Table.Columns.Contains(aliasPrefix & "vo_closed") AndAlso Not dr.IsNull(aliasPrefix & "vo_closed") Then
          .m_closed = CBool(dr(aliasPrefix & "vo_closed"))
          .m_closing = CBool(dr(aliasPrefix & "vo_closed"))
        End If
        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "vo_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "vo_approvePerson")))
          End If
        End If
        ' Approved Date
        If Not dr.IsNull(aliasPrefix & "vo_approveDate") Then
          .m_approveDate = CDate(dr(aliasPrefix & "vo_approveDate"))
        End If

        m_itemCollection = New VOItemCollection(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property VO() As VO
      Get
        Return m_VO
      End Get
      Set(ByVal Value As VO)
        m_VO = Value
        If m_VO.Code <> Value.Code Then
          m_VO = New VO(Value.Code)
        End If
      End Set
    End Property

    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property ItemCollection() As VOItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As VOItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property SubContractor() As Supplier Implements IWBSAllocatable.Supplier
      Get
        Return Me.SC.SubContractor
      End Get
      Set(ByVal Value As Supplier)
        If Me.SC.SubContractor Is Nothing Then
          Me.SC.SubContractor = New Supplier
        End If
        Me.SC.SubContractor = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property CostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter
      Get
        Return Me.SC.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        If Me.SC.CostCenter Is Nothing Then
          Me.SC.CostCenter = New CostCenter
        End If
        Me.SC.CostCenter = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0     '"ไม่มี"
            Return Me.RealGross - Me.Discount.Amount
          Case 1     '"แยก"
            Return Me.RealGross - Me.Discount.Amount
          Case 2     '"รวม"
            Return Me.AfterTax - Me.RealTaxAmount
        End Select
      End Get
    End Property    Public ReadOnly Property TaxGross() As Decimal
      Get
        Return m_taxGross
      End Get
    End Property    Public Property TaxBase() As Decimal
      Get
        Return m_taxBase
      End Get
      Set(ByVal Value As Decimal)
        m_taxBase = Value
      End Set
    End Property    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        m_taxRate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property TaxType() As TaxType
      Get
        Return m_taxType
      End Get
      Set(ByVal Value As TaxType)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Not Me.SC Is Nothing Then
          If Value.Value <> Me.SC.TaxType.Value Then
            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SC.CanNotChangeVATType}")
            Return
          End If
        End If
        m_taxType = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0     '"ไม่มี"
            Return 0
          Case 2     'รวม VAT
            Return Me.TaxGross - Me.DiscountWithVat - Me.RealTaxBase
          Case Else     '1 แยก
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)
        End Select
      End Get
    End Property
    Public ReadOnly Property AfterTax() As Decimal Implements IApprovAble.AmountToApprove
      Get
        Select Case Me.TaxType.Value
          Case 0     '"ไม่มี"
            Return Me.BeforeTax
          Case 1     '"แยก"
            Return Me.BeforeTax + Me.RealTaxAmount
          Case 2     '"รวม"
            Return Me.RealGross - Me.Discount.Amount
        End Select
      End Get
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, VOStatus)
      End Set
    End Property
    'Public ReadOnly Property DiscountWithVat() As Decimal
    '    Get
    '        If Me.Gross = 0 Then
    '            Return 0
    '        End If
    '        Return Configuration.Format(Me.Discount.Amount * Me.TaxGross / Me.Gross, DigitConfig.Price)
    '    End Get
    'End Property
    '--------------------REAL-------------------------    Public Property RealTaxBase() As Decimal
      Get
        Return m_realTaxBase
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxBase = Value
      End Set
    End Property
    Public Property Closed() As Boolean      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
      End Set
    End Property
    Public Property Closing() As Boolean      Get
        Return m_closing
      End Get
      Set(ByVal Value As Boolean)
        m_closing = Value
        If m_closing Then 'กำลังจะปิด
          For Each item As VOItem In Me.ItemCollection
            If item.Level = 1 Then
              item.SetMat(item.ReceivedMat)
              item.SetLab(item.ReceivedLab)
              item.SetEq(item.ReceivedEq)
              item.SetQty(item.ReceivedQty)
            End If
          Next
        Else 'ยกเลิกการปิด
          For Each item As VOItem In Me.ItemCollection
            If item.Level = 1 Then
              item.SetMat(item.oldMat)
              item.SetLab(item.oldLab)
              item.SetEq(item.oldEq)
              item.SetQty(item.oldQty)
            End If
          Next
        End If
        Me.RefreshTaxBase()
      End Set
    End Property
    Public Property RealGross() As Decimal
      Get
        'HACK
        If m_realGross = 0 AndAlso m_gross <> 0 Then
          m_realGross = m_gross
        End If
        Return m_realGross
      End Get
      Set(ByVal Value As Decimal)
        m_realGross = Value
      End Set
    End Property
    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
      End Set
    End Property
    Public Property Discount() As Discount
      Get
        Return m_discount
      End Get
      Set(ByVal Value As Discount)
        m_discount = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = Me.RealGross
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Public Property ApprovePerson() As User
      Get
        Return m_approvePerson
      End Get
      Set(ByVal Value As User)
        m_approvePerson = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ApproveDate() As DateTime
      Get
        Return m_approveDate
      End Get
      Set(ByVal Value As DateTime)
        m_approveDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property SC() As SC      Get        Return m_sc      End Get      Set(ByVal Value As SC)        If Value.Status.Value = 0 OrElse Value.Closed Then          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowWarningFormatted("${res:Global.Error.CanceledSC}", New String() {Value.Code})
          Return
        End If        m_sc = Value        Me.TaxRate = m_sc.TaxRate
        Me.TaxType = New TaxType(m_sc.TaxType.Value)        ChangeSC()      End Set    End Property    Private Sub ChangeSC()      '--------------------------------------ลบรายการ----------------------------------
      'Dim itemsToRemove As New ArrayList
      'For Each item As VOItem In Me.ItemCollection
      '    If Not item.scitem Is Nothing Then
      '        If Not item.scitem.sc Is Nothing Then
      '            If item.scitem.sc.Originated Then
      '                itemsToRemove.Add(item)
      '            End If
      '        End If
      '    End If
      'Next      'For Each item As VOItem In Me.ItemCollection      '    Me.ItemCollection.Remove(item)
      'Next      Me.ItemCollection.Clear()      '-------------------------------------------------------------------------------      If Not Me.m_sc Is Nothing AndAlso Me.m_sc.Originated Then
        Me.SubContractor = Me.m_sc.SubContractor
        Me.TaxType = Me.m_sc.TaxType
        Me.TaxRate = Me.SC.TaxRate
        Me.CostCenter = Me.m_sc.CostCenter
        For Each newScitem As SCItem In Me.m_sc.ItemCollection
          If newScitem.ItemType.Value = 289 Then
            Dim item As New VOItem
            item.CopyFromscitem(newScitem)
            item.IsNotVoItem = True
            Me.ItemCollection.Add(item)
            Me.ItemCollection.CurrentItem = item
            Me.ItemCollection.CurrentRealItem = item
          End If
        Next
        'Me.RefreshTaxBase()
      End If
    End Sub
    Private Function GetOldItemTable(ByVal sc As SC) As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetVOItemFromSC" _
      , New SqlParameter("@vo_id", Me.Id) _
      , New SqlParameter("@sci_sc", sc.Id) _
      )
      Return ds.Tables(0)
    End Function
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "VO"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VO.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.VO"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.VO"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VO.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "vo"
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
    Public Shared Function GetVO(ByVal txtCode As TextBox, ByRef oldVO As VO) As Boolean
      Dim newVo As New VO(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newVo.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        newVo = oldVO
        Return False
      End If
      txtCode.Text = newVo.Code
      oldVO = newVo
      Return True
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("VO")
      myDatatable.Columns.Add(New DataColumn("sci_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_sc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_itemName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("voi_code", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_level", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_unitName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_mat", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_lab", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_eq", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_unvatable", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("voi_billingAmount", GetType(Decimal)))

      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub RecalculateAmount()
      Dim newUnitPrice As Decimal = 0
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 0 AndAlso item.IsNotRefSC Then
          newUnitPrice = 0
          If item.Qty = 0 Then
            item.SetQty(1)
            item.SetUnitPrice((item.Mat + item.Lab + item.Eq))
          Else
            item.SetUnitPrice((item.Mat + item.Lab + item.Eq) / item.Qty)
          End If
        End If
      Next
    End Sub
    Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal type As Integer)
      '    myWbs = New WBS(myWbs.Id)
      '    ' Dim o_n As OldNew
      '    Dim theHash As Hashtable
      '    Select Case type
      '        Case 0, 19, 42
      '            theHash = MatActualHash
      '        Case 88
      '            theHash = LabActualHash
      '        Case 89
      '            theHash = EQActualHash
      '    End Select
      '    If Not theHash Is Nothing Then
      '        'If theHash.Contains(myWbs.Id) Then
      '        '    '    o_n = CType(theHash(myWbs.Id), OldNew)
      '        'Else
      '        '    '    o_n = New OldNew
      '        '    Select Case type
      '        '        Case 0, 19, 42
      '        '            o_n.OldValue = myWbs.GetActualMat(Me, 6)
      '        '        Case 88
      '        '            o_n.OldValue = myWbs.GetActualLab(Me, 6)
      '        '        Case 89
      '        '            o_n.OldValue = myWbs.GetActualEq(Me, 6)
      '        '    End Select
      '        '    o_n.NewValue = o_n.OldValue
      '        '    theHash(myWbs.Id) = o_n
      '        'End If
      '        '  o_n.NewValue += (newVal - oldVal)

      '        'ส่งต่อไปยังแม่
      '        If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
      '            SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, type)
      '        End If
      '    End If
    End Sub
    Public Function GetCurrentDiffForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      '    Dim theHash As Hashtable
      '    Select Case itemType.Value
      '        Case 0, 19, 42
      '            theHash = MatActualHash
      '        Case 88
      '            theHash = LabActualHash
      '        Case 89
      '            theHash = EQActualHash
      '    End Select
      '    'If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
      '    '    Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
      '    '    Return o_n.NewValue - o_n.OldValue
      '    'End If
      '    Return 0
    End Function
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
      '    Dim ret As Decimal = 0
      '    For Each item As POItem In Me.ItemCollection
      '        Dim flag As Boolean = False
      '        If Not item.ItemType Is Nothing Then
      '            Select Case itemType.Value
      '                Case 0, 19, 42
      '                    Select Case item.ItemType.Value
      '                        Case 0, 19, 42
      '                            flag = True
      '                        Case Else
      '                            flag = False
      '                    End Select
      '                Case 88
      '                    Select Case item.ItemType.Value
      '                        Case 88
      '                            flag = True
      '                        Case Else
      '                            flag = False
      '                    End Select
      '                Case 89
      '                    Select Case item.ItemType.Value
      '                        Case 89
      '                            flag = True
      '                        Case Else
      '                            flag = False
      '                    End Select
      '            End Select
      '        End If
      '        If flag Then
      '            For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
      '                If Not grWBSD.IsMarkup Then
      '                    Dim isOut As Boolean = False
      '                    Dim view As Integer = 6
      '                    Dim transferAmt As Decimal = item.BeforeTax 'item.Amount
      '                    Dim amt As Decimal = WBSDistribute.GetUsedAmount(transferAmt, item.Amount, isOut, view, 3)
      '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
      '                        ret += (grWBSD.Percent * amt / 100)
      '                    End If
      '                End If
      '            Next
      '        End If
      '    Next
      '    Return ret
    End Function
    Public Function GetCurrentAmountForMarkup(ByVal mk As Markup) As Decimal
      '    Dim ret As Decimal = 0
      '    For Each item As POItem In Me.ItemCollection
      '        For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
      '            If grWBSD.IsMarkup Then
      '                If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
      '                    ret += (grWBSD.Percent * item.Amount / 100)
      '                End If
      '            End If
      '        Next
      '    Next
      '    Return ret
      'End Function
      'Public Function GetCurrentTypeQtyForWBS(ByVal myWbs As WBS, ByVal name As String, ByVal type As Integer) As Decimal
      '    Dim ret As Decimal = 0
      '    For Each item As POItem In Me.ItemCollection
      '        Dim theName As String = item.EntityName
      '        If theName Is Nothing Then
      '            theName = item.Entity.Name
      '        End If
      '        If theName Is Nothing Then
      '            theName = ""
      '        End If
      '        If name Is Nothing Then
      '            name = ""
      '        End If
      '        If Not item.ItemType Is Nothing _
      '        AndAlso item.ItemType.Value = type _
      '        AndAlso theName.ToLower = name.ToLower Then
      '            For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
      '                If Not grWBSD.IsMarkup Then
      '                    Dim isOut As Boolean = False
      '                    Dim view As Integer = 6
      '                    Dim transferAmt As Decimal = item.Amount
      '                    Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
      '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
      '                        ret += (grWBSD.Percent * amt / 100)
      '                    End If
      '                End If
      '            Next
      '        End If
      '    Next
      '    Return ret
    End Function
    Public Function GetCurrentMatQtyForWBS(ByVal myWbs As WBS, ByVal matId As Integer) As Decimal
      '    Dim ret As Decimal = 0
      '    For Each item As POItem In Me.ItemCollection
      '        If Not item.ItemType Is Nothing _
      '        AndAlso item.ItemType.Value = 42 _
      '        AndAlso item.Entity.Id = matId Then
      '            For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
      '                If Not grWBSD.IsMarkup Then
      '                    Dim isOut As Boolean = False
      '                    Dim view As Integer = 6
      '                    Dim transferAmt As Decimal = item.Amount
      '                    Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
      '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
      '                        ret += (grWBSD.Percent * amt / 100)
      '                    End If
      '                End If
      '            Next
      '        End If
      '    Next
      '    Return ret
    End Function
    Public Function GetCurrentLabQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
      '    Dim ret As Decimal = 0
      '    For Each item As POItem In Me.ItemCollection
      '        Dim theName As String = item.EntityName
      '        If theName Is Nothing Then
      '            theName = item.Entity.Name
      '        End If
      '        If theName Is Nothing Then
      '            theName = ""
      '        End If
      '        If name Is Nothing Then
      '            name = ""
      '        End If
      '        If Not item.ItemType Is Nothing _
      '        AndAlso item.ItemType.Value = 88 _
      '        AndAlso theName.ToLower = name.ToLower Then
      '            For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
      '                If Not grWBSD.IsMarkup Then
      '                    Dim isOut As Boolean = False
      '                    Dim view As Integer = 6
      '                    Dim transferAmt As Decimal = item.Amount
      '                    Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
      '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
      '                        ret += (grWBSD.Percent * amt / 100)
      '                    End If
      '                End If
      '            Next
      '        End If
      '    Next
      '    Return ret
    End Function
    Public Function GetCurrentEqQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
      '    Dim ret As Decimal = 0
      '    For Each item As POItem In Me.ItemCollection
      '        Dim theName As String = item.EntityName
      '        If theName Is Nothing Then
      '            theName = item.Entity.Name
      '        End If
      '        If theName Is Nothing Then
      '            theName = ""
      '        End If
      '        If name Is Nothing Then
      '            name = ""
      '        End If
      '        If Not item.ItemType Is Nothing _
      '        AndAlso item.ItemType.Value = 89 _
      '        AndAlso theName.ToLower = name.ToLower Then
      '            For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
      '                If Not grWBSD.IsMarkup Then
      '                    Dim isOut As Boolean = False
      '                    Dim view As Integer = 6
      '                    Dim transferAmt As Decimal = item.Amount
      '                    Dim amt As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, 3)
      '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
      '                        ret += (grWBSD.Percent * amt / 100)
      '                    End If
      '                End If
      '            Next
      '        End If
      '    Next
      '    Return ret
    End Function
    Private Function OverBudget() As Boolean
      '    If Me.CostCenter.Type.Value <> 2 Then
      '        Return False
      '    End If
      '    If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
      '        Return False
      '    End If
      '    'POROverBudgetOnlyCC
      '    Dim config As Object = Configuration.GetConfig("POOverBudgetOnlyCC")
      '    Dim onlyCC As Boolean = False
      '    If Not config Is Nothing Then
      '        onlyCC = CBool(config)
      '    End If
      '    If Not onlyCC Then
      '        For Each item As POItem In Me.ItemCollection
      '            If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
      '                Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
      '                If wsdColl.Count = 0 Then
      '                    Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
      '                    Dim totalBudget As Decimal = 0
      '                    Dim totalActual As Decimal = 0
      '                    Dim totalCurrentDiff As Decimal = item.Amount
      '                    Select Case item.ItemType.Value
      '                        Case 88
      '                            totalbudget = rootWBS.GetTotalLabFromDB
      '                            totalactual = rootWBS.GetActualLab(Me, 6)
      '                        Case 89
      '                            totalbudget = rootWBS.GetTotalEQFromDB
      '                            totalactual = rootWBS.GetActualEq(Me, 6)
      '                        Case Else
      '                            totalbudget = rootWBS.GetTotalMatFromDB
      '                            totalactual = rootWBS.GetActualMat(Me, 6)
      '                    End Select
      '                    If totalBudget < (totalActual + totalCurrentDiff) Then
      '                        Return True
      '                    End If
      '                End If
      '                For Each wbsd As WBSDistribute In wsdColl
      '                    If wbsd.AmountOverBudget Then
      '                        Return True
      '                    End If
      '                    Dim rootWBS As New WBS(wbsd.WBS.Id)
      '                    Dim totalBudget As Decimal = 0
      '                    Dim totalActual As Decimal = 0
      '                    Dim totalCurrentDiff As Decimal = 0
      '                    'Select Case item.ItemType.Value
      '                    '    Case 88
      '                    '        totalcurrentdiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88))
      '                    '    Case 89
      '                    '        totalcurrentdiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
      '                    '    Case Else
      '                    '        totalcurrentdiff = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0))
      '                    'End Select
      '                    For Each row As DataRow In rootwbs.GetParentsBudget(Me.EntityId)
      '                        totalBudget = 0
      '                        totalActual = 0
      '                        Select Case item.ItemType.Value
      '                            Case 88
      '                                If Not row.IsNull("labbudget") Then
      '                                    totalbudget = CDec(row("labbudget"))
      '                                End If
      '                                If Not row.IsNull("labactual") Then
      '                                    totalactual = CDec(row("labactual"))
      '                                End If
      '                            Case 89
      '                                If Not row.IsNull("eqbudget") Then
      '                                    totalbudget = CDec(row("eqbudget"))
      '                                End If
      '                                If Not row.IsNull("eqactual") Then
      '                                    totalactual = CDec(row("eqactual"))
      '                                End If
      '                            Case Else
      '                                If Not row.IsNull("matbudget") Then
      '                                    totalbudget = CDec(row("matbudget"))
      '                                End If
      '                                If Not row.IsNull("matactual") Then
      '                                    totalactual = CDec(row("matactual"))
      '                                End If
      '                        End Select
      '                        If totalbudget < (totalActual + totalCurrentDiff) Then
      '                            Return True
      '                        End If
      '                    Next
      '                Next
      '            End If
      '        Next
      '    Else
      '        Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
      '        Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
      '        Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
      'Dim totalCurrentDiff As Decimal = Me.GetCurrentDiffForWBS(rootWBS, New ItemType(0)) + _
      'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(88)) + _
      'Me.GetCurrentDiffForWBS(rootWBS, New ItemType(89))
      'If totalBudget < (totalActual + totalCurrentDiff) Then
      '    Return True
      'End If
      '    End If
      '    Return False
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      Dim stringPar As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Me.CostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If
      'PROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("POOverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If
      '====================
      WBS.ParentBudgetHash = New Hashtable 'ห้ามลืมเด็ดขาด
      '====================
      If Not onlyCC Then
        For Each item As VOItem In Me.ItemCollection
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 AndAlso item.ItemType.Value <> 289 Then

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

              'สำหรับ WBS ที่เป็นแม่ตัวที่จัดสรรอยู่ =====>>
              For Each row As DataRow In wbsd.WBS.GetParentsBudget(Me.EntityId)
                totalBudget = 0
                totalActual = 0
                Select Case item.ItemType.Value
                  Case 88
                    If Not row.IsNull("labbudget") Then
                      totalBudget = CDec(row("labbudget"))
                    End If
                    If Not row.IsNull("labactual") Then
                      totalActual = CDec(row("labactual"))
                    End If
                  Case 89
                    If Not row.IsNull("eqbudget") Then
                      totalBudget = CDec(row("eqbudget"))
                    End If
                    If Not row.IsNull("eqactual") Then
                      totalActual = CDec(row("eqactual"))
                    End If
                  Case Else
                    If Not row.IsNull("matbudget") Then
                      totalBudget = CDec(row("matbudget"))
                    End If
                    If Not row.IsNull("matactual") Then
                      totalActual = CDec(row("matactual"))
                    End If
                End Select
                If Me.Originated Then
                  If item.ItemType.Value = 88 Then
                    totalActual -= item.OldLab
                  ElseIf item.ItemType.Value = 89 Then
                    totalActual -= item.OldEq
                  Else
                    totalActual -= item.OldMat
                  End If
                End If
                Trace.WriteLine("")
                Trace.WriteLine(totalBudget.ToString)
                Trace.WriteLine(totalActual.ToString)
                Trace.WriteLine(totalCurrent.ToString)
                If totalBudget < (totalActual + totalCurrent) Then
                  Dim myId As Integer = CInt(row("depend_parent"))
                  Dim myWBS As New WBS(myId)
                  Return New SaveErrorException(myWBS.Code & ":" & myWBS.Name)
                End If
              Next
              'สำหรับ WBS ที่เป็นแม่ตัวที่จัดสรรอยู่ =====<<
            Next
          End If
        Next
      Else
        Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
        Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
        Dim totalCurrent As Decimal = Me.ItemCollection.Amount

        If totalBudget < (totalActual + totalCurrent) Then
          Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        End If
      End If

      Return New SaveErrorException("0")
    End Function
    Private Function ValidateItem() As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim key As String = ""
      Dim c As Integer = 0
      Dim i As Integer = 0
      For Each sitem As VOItem In Me.ItemCollection
        i += 1
        If sitem.Level = 0 Then
          If i > 1 Then
            If c = 0 Then
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.vo.NoItem}"))
            End If
          End If
          c = 0
        Else
          c += 1
        End If
      Next
      If i > 0 And c = 0 Then
        Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.vo.NoItem}"))
      End If
      For Each vitem As VOItem In Me.ItemCollection
        If vitem.Level = 0 Then
          If vitem.Amount <> vitem.ChildAmount Then
            If vitem.RefSequence = 0 Then
              If msgServ.AskQuestion("${res:Global.Question.SCAmountNotEqualAllocateAndReCalUnitPrice}") Then
                Me.RecalculateAmount()
                Me.RefreshTaxBase()
                Me.RealTaxBase = Me.TaxBase
                Me.RealTaxAmount = Me.TaxAmount
              Else
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
              End If
              'Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverSCAmount}", _
              '      New String() {Configuration.FormatToString(vitem.Amount, DigitConfig.Price), Configuration.FormatToString(vitem.ChildAmount, DigitConfig.Price)})
            End If
          End If
        Else
          Dim m_value As Decimal = vitem.Mat + vitem.Lab + vitem.Eq
          If vitem.Amount <> m_value Then
            Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
New String() {vitem.ItemDescription, Configuration.FormatToString(vitem.Amount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
          End If
        End If
        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In vitem.WBSDistributeCollection
          key = wbitem.WBS.Id.ToString
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
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.Originated Then
          If Not Me.SubContractor Is Nothing Then
            If Me.SubContractor.Canceled Then
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.SubContractor.Code})
            End If
          End If
        End If

        If Me.ItemCollection.Count = 0 Then   '.ItemTable.Childs.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.vo.NoItem}"))
        End If
        Dim ValidateError As SaveErrorException = ValidateItem()
        If Not IsNumeric(ValidateError.Message) Then
          Return ValidateError
        End If

        ''=============== Validate Over Budget ==================>>
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
        ''=============== Validate Over Budget ==================<<

        Me.RefreshTaxBase()
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)


        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        Me.RefreshTaxBase()

        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        Dim willClose As Boolean = False
        If Me.Closing Then
          willClose = True
        ElseIf Not Me.Closing AndAlso Not Me.Closed Then
          willClose = False
        End If

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_sc", Me.ValidIdOrDBNull(Me.SC)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_subcontractor", ValidIdOrDBNull(Me.SC.SubContractor)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.SC.CostCenter)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startdate", Me.ValidDateOrDBNull(Me.StartDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_enddate", Me.ValidDateOrDBNull(Me.EndDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Configuration.GetConfig("CompanyTaxRate"))) 'Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.TaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforetax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", Me.Closed))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", willClose))

        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_director", ValidIdOrDBNull(Me.Director)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_witholdingtax", Me.WitholdingTax))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discrate", Me.Discount.Rate))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discamt", Me.DiscountAmount))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Dim oldid As Integer = Me.Id
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          Select Case CInt(returnVal.Value)
            Case -1, -5
              trans.Rollback()
              ResetID(oldid)
              Return New SaveErrorException(returnVal.Value.ToString)
          End Select
        
          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
          If Not IsNumeric(saveDetailError.Message) Then
            trans.Rollback()
            ResetID(oldid)
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid)
                Return saveDetailError
              Case Else
            End Select
          End If

          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

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

          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateSCParent" _
                                    , New SqlParameter("@id", Me.Id) _
                                    , New SqlParameter("@docType", Me.EntityId))
          Me.DeleteRef(conn, trans)
          'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_PORef" _
          ', New SqlParameter("@refto_id", Me.Id))

          Dim isCanceled As Integer = 0
          If Me.Status.Value = 0 Then
            isCanceled = 1
          End If
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertUpdatereference" _
          , New SqlParameter("@entity_id", Me.SC.Id) _
          , New SqlParameter("@entity_type", Me.SC.EntityId) _
          , New SqlParameter("@refto_id", Me.Id) _
          , New SqlParameter("@refto_type", Me.EntityId) _
          , New SqlParameter("@refto_iscanceled", isCanceled) _
          )
          'If Me.Status.Value = 0 Then
          '    Me.CancelRef(conn, trans)
          'End If

          '    '--------------------------------------------------------------
          '    Dim savePRItemsError As SaveErrorException = Me.SavePRItemsDetail(arr, trans, conn)
          '    If Not IsNumeric(savePRItemsError.Message) Then
          '        trans.Rollback()
          '        ResetID(oldid)
          '        Return savePRItemsError
          '    Else
          '        Select Case CInt(savePRItemsError.Message)
          '            Case -1, -5
          '                trans.Rollback()
          '                ResetID(oldid)
          '                Return savePRItemsError
          '            Case -2
          '                'Post ไปแล้ว
          '                Return savePRItemsError
          '            Case Else
          '        End Select
          '    End If
          '    '--------------------------------------------------------------

          '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertPOProcedure" _
          '     , New SqlParameter("@po", Me.Id))

          '    trans.Commit()


          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")

          trans.Commit()

          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code 'Entity.GetAutoCodeFormat(Me.EntityId)
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
    'Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '    If Not Me.Originated Then
    '        Return
    '    End If
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPRItemStatus", New SqlParameter("@po_id", Me.Id))

    'End Sub
    'Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
    '    If Not Me.Originated Then
    '        Return
    '    End If
    '    SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPRItemStatus", New SqlParameter("@po_id", Me.Id))
    'End Sub
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Dim currWBS As String
      Try
        Dim da As New SqlDataAdapter("Select * from voitem where voi_vo=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from voiwbs where voiw_sequence in (select voi_sequence from voitem where voi_vo=" & Me.Id & ")", conn)
        Dim daOld As New SqlDataAdapter("Select * from voolditem where voio_sequence in (select voi_sequence from voitem where voi_vo=" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From voitem Where voi_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "voitem")
        da.Fill(ds, "voitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "voiwbs")
        daWbs.Fill(ds, "voiwbs")
        ds.Relations.Add("sequence", ds.Tables!voitem.Columns!voi_sequence, ds.Tables!voiwbs.Columns!voiw_sequence)

        cmdBuilder = New SqlCommandBuilder(daOld)
        daOld.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daOld.FillSchema(ds, SchemaType.Mapped, "voolditem")
        daOld.Fill(ds, "voolditem")
        ds.Relations.Add("sequence2", ds.Tables!voitem.Columns!voi_sequence, ds.Tables!voolditem.Columns!voio_sequence)

        Dim dt As DataTable = ds.Tables("voitem")
        Dim dtWbs As DataTable = ds.Tables("voiwbs")
        Dim dtOld As DataTable = ds.Tables("voolditem")

        For Each row As DataRow In ds.Tables("voolditem").Rows
          row.Delete()
        Next
        For Each row As DataRow In ds.Tables("voiwbs").Rows
          row.Delete()
        Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As VOItem In Me.ItemCollection
            If testItem.Sequence = CInt(dr("voi_sequence")) Then
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
        'For Each row As DataRow In ds.Tables("voitem").Rows
        '  row.Delete()
        'Next

        Dim i As Integer = 0
        Dim refSequence As Decimal = 0
        With ds.Tables("voitem")
          For Each item As VOItem In Me.ItemCollection
            If item.Level = 0 Then
              refSequence = item.RefSequence
            End If
            If (Not item.IsNotVoItem) Then

              i += 1
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

              '------------Checking if we have to add a new row or just update existing--------------------
              Dim dr As DataRow
              Dim drs As DataRow() = ds.Tables("voitem").Select("voi_sequence=" & item.Sequence)
              If drs.Length = 0 Then
                dr = .NewRow
                dr("voi_sequence") = (-1) * i
                .Rows.Add(dr)
              Else
                dr = drs(0)
              End If
              '------------End Checking--------------------

              'Dim dr As DataRow = .NewRow
              dr("voi_vo") = Me.Id
              dr("voi_lineNumber") = i
              dr("voi_entity") = item.Entity.Id
              dr("voi_entityType") = item.ItemType.Value
              dr("voi_itemName") = item.EntityName
              dr("voi_unit") = item.Unit.Id
              dr("voi_qty") = item.Qty
              dr("voi_unitprice") = item.UnitPrice
              dr("voi_mat") = item.Mat
              dr("voi_lab") = item.Lab
              dr("voi_eq") = item.Eq
              dr("voi_amt") = item.Amount
              dr("voi_note") = item.Note
              dr("voi_refsequence") = refSequence
              dr("voi_sc") = Me.SC.Id
              dr("voi_unvatable") = item.UnVatable
              'dr("voi_parent") = item.ParentPath
              dr("voi_level") = item.Level
              dr("voi_status") = Me.Status.Value
              dr("voi_unitCost") = item.UnitCost
              '.Rows.Add(dr)

              Dim dr2 As DataRow = dtOld.NewRow
              dr2("voio_sequence") = dr("voi_sequence")
              If Me.Closed AndAlso Not Me.Closing Then 'ยกเลิกปิด SC
                dr2("voio_qty") = item.OldQty
                dr2("voio_mat") = item.OldMat
                dr2("voio_lab") = item.OldLab
                dr2("voio_eq") = item.OldEq
                dr2("voio_amt") = item.OldAmount
              ElseIf Not Me.Closed AndAlso Me.Closing Then 'กำลังจะปิด SC
                dr2("voio_qty") = item.OldQty
                dr2("voio_mat") = item.OldMat
                dr2("voio_lab") = item.OldLab
                dr2("voio_eq") = item.OldEq
                dr2("voio_amt") = item.OldAmount
              ElseIf Not Me.Closed AndAlso Not Me.Closing Then 'ยังไม่เคยปิด และยังไม่ปิด หรือเคยเปิดมาแล้ว
                dr2("voio_qty") = item.Qty
                dr2("voio_mat") = item.Mat
                dr2("voio_lab") = item.Lab
                dr2("voio_eq") = item.Eq
                dr2("voio_amt") = item.Amount
              End If
              dtOld.Rows.Add(dr2)

              If item.ItemType.Value <> 160 _
              AndAlso item.ItemType.Value <> 162 Then
                Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
                Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
                Dim currentSum As Decimal = wbsdColl.GetSumPercent
                For Each wbsd As WBSDistribute In wbsdColl
                  If currentSum < 100 AndAlso wbsd.WBS.Id = rootWBS.Id Then
                    'ยังไม่เต็ม 100 แต่มีหัวอยู่
                    wbsd.Percent += (100 - currentSum)
                  End If
                  Dim bfTax As Decimal = 0
                  'If item.VO.Closed Then
                  '    bfTax = item.ReceivedBeforeTax
                  'Else
                  bfTax = item.CostAmount
                  'End If
                  currWBS = wbsd.WBS.Code & ":" & wbsd.WBS.Name
                  wbsd.BaseCost = bfTax
                  wbsd.TransferBaseCost = bfTax
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("voiw_wbs") = wbsd.WBS.Id
                  childDr("voiw_sequence") = dr("voi_sequence")
                  If wbsd.CostCenter Is Nothing Then
                    wbsd.CostCenter = Me.CostCenter
                  End If
                  childDr("voiw_cc") = wbsd.CostCenter.Id
                  childDr("voiw_percent") = wbsd.Percent
                  childDr("voiw_ismarkup") = wbsd.IsMarkup
                  childDr("voiw_direction") = 0        'in
                  childDr("voiw_baseCost") = wbsd.BaseCost
                  childDr("voiw_amt") = wbsd.Amount
                  childDr("voiw_cbs") = wbsd.CBS.Id
                  'childDr("voiw_toaccttype") = 3
                  'Add เข้า voiwbs
                  dtWbs.Rows.Add(childDr)
                Next

                currentSum = wbsdColl.GetSumPercent
                'ยังไม่เต็ม 100 และยังไม่มี root
                If currentSum < 100 AndAlso Not rootWBS Is Nothing Then
                  Try
                    Dim newWbsd As New WBSDistribute
                    newWbsd.WBS = rootWBS
                    newWbsd.CostCenter = item.VO.CostCenter
                    newWbsd.Percent = 100 - currentSum
                    Dim bfTax As Decimal = 0
                    'If item.VO.Closed Then
                    '    bfTax = item.ReceivedBeforeTax
                    'Else
                    bfTax = item.CostAmount
                    'End If
                    newWbsd.BaseCost = bfTax
                    newWbsd.TransferBaseCost = bfTax
                    Dim childDr As DataRow = dtWbs.NewRow
                    childDr("voiw_wbs") = newWbsd.WBS.Id
                    childDr("voiw_sequence") = dr("voi_sequence")
                    childDr("voiw_cc") = newWbsd.CostCenter.Id
                    childDr("voiw_percent") = newWbsd.Percent
                    childDr("voiw_ismarkup") = False
                    childDr("voiw_direction") = 0         'in
                    childDr("voiw_baseCost") = newWbsd.BaseCost
                    childDr("voiw_amt") = newWbsd.Amount
                    childDr("voiw_cbs") = newWbsd.CBS.Id
                    'childDr("voiw_toaccttype") = 3
                    'Add เข้า voiwbs
                    dtWbs.Rows.Add(childDr)
                  Catch ex As Exception
                    Throw New Exception(ex.Message.ToString)
                  End Try
                End If
              End If
            End If
          Next
        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated
        AddHandler daOld.RowUpdated, AddressOf daOld_MyRowUpdated

        daOld.Update(GetDeletedRows(dtOld))
        daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))
        daOld.Update(dtOld.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daOld.Update(dtOld.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True

        Return New SaveErrorException("1")

      Catch ex2 As ConstraintException
        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicateWBS}"), New String() {currWBS})

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
        Dim currentkey As Integer = CInt(e.Row("voiw_sequence")) '.GetParentRow("sequence")("sciw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!voiw_sequence = e.Row.GetParentRow("sequence")("voi_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!voiw_sequence = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daOld_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("voio_sequence")) '.GetParentRow("sequence")("voiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!voio_sequence = e.Row.GetParentRow("sequence2")("voi_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!voio_sequence = currentkey
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
    Private Function GetPritemString() As String
      '    Dim ret As String = "("
      '    For Each item As POItem In Me.ItemCollection
      '        If Not item.Pritem Is Nothing Then
      '            ret &= "'" & item.Pritem.Pr.Id.ToString & "|" & item.Pritem.LineNumber & "',"
      '        End If
      '    Next
      '    ret &= "'')"
      '    Return ret
    End Function
    Private Function SavePRItemsDetail(ByVal arr As ArrayList, ByVal trans As SqlTransaction, ByVal conn As SqlConnection) As SaveErrorException
      '    Try
      '        For Each o As ValueDisplayPair In arr
      '            SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePROrderedQty" _
      '            , New SqlParameter("@pri_pr", CInt(o.Value)) _
      '            , New SqlParameter("@pri_linenumber", CInt(o.Display)))
      '        Next
      '    Catch ex As Exception
      '        Return New SaveErrorException(ex.ToString)
      '    End Try
      '    Return New SaveErrorException("1")
      'End Function
      'Public Function CloneGroupingItem() As PO
      '    Dim po1 As New PO
      '    po1.Id = Me.Id
      '    po1.Group = True
      '    'po1.ItemCollection = New VOItemCollection(po1)

      '    Return po1
    End Function
#End Region

#Region "RefreshTaxBase"
    'Private m_taxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxBase = 0

      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
        Return
      End If

      Dim sumAmountWithVat As Decimal = 0
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 1 Then
          m_gross += item.Amount
          If Not item.UnVatable Then
            m_taxGross += item.Amount
            sumAmountWithVat += item.Amount
          End If
        End If
      Next
      Select Case Me.TaxType.Value
        Case 0 '"ไม่มี"
          m_taxBase = 0
        Case 1 '"แยก"
          m_taxBase = sumAmountWithVat - Me.DiscountWithVat
        Case 2 '"รวม"
          Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
          Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
          m_taxBase = a - b
      End Select
    End Sub
    Public ReadOnly Property DiscountWithVat() As Decimal
      Get
        If Me.Gross = 0 Then
          Return 0
        End If
        Return Configuration.Format(Me.DiscountAmount * Me.TaxGross / Me.Gross, DigitConfig.Price)
      End Get
    End Property
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
      Me.RefreshTaxBase()
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

      If Not Me.SC Is Nothing Then
        'SCCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SCCode"
        dpi.Value = Me.SC.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.SubContractor Is Nothing AndAlso Me.SubContractor.Originated Then
        'SubcontractorInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "SubcontractorInfo"
        dpi.Value = Me.SubContractor.Code & ":" & Me.SubContractor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorCode"
        dpi.Value = Me.SubContractor.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorName
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorName"
        dpi.Value = Me.SubContractor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorAddredss
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorAddress"
        dpi.Value = Me.SubContractor.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorBillingAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorBillingAddress"
        dpi.Value = Me.SubContractor.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      '------------------ท้ายเอกสาร------------------------------
      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.RealGross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DiscountRate
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountRate"
      dpi.Value = Me.Discount.Rate
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      dpi.Value = Configuration.FormatToString(Me.RealTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'อัตราภาษี
      'TaxRate
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxRate"
      dpi.Value = Configuration.FormatToString(Me.TaxRate, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)
      '------------------ท้ายเอกสาร------------------------------
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font
      Dim indent As String = ""
      For Each item As VOItem In Me.ItemCollection
        line += 1
        If item.Level = 0 Then
          parentLine += 1
          childLine = 0
          fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          indent = Space(0)
        Else
          If item.ItemType.Value <> 162 Then
            childLine += 1
          End If
          fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          indent = Space(3)
        End If
        'Item.LineNumber
        '************** เอามาไว้เป็นอันที่ 2
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        If item.Level = 0 Then
          dpi.Value = parentLine
        Else
          If item.ItemType.Value <> 162 Then
            dpi.Value = parentLine.ToString & "." & childLine.ToString
          End If
        End If
        dpi.Font = fn
        dpi.DataType = "System.string"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = indent & item.EntityName.Trim
        Else
          dpi.Value = indent & item.Entity.Name.Trim
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit"
        dpi.Value = item.Unit.Name
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        If item.Qty = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        End If
        dpi.Font = fn
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
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ReceivedAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ReceivedAmount"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Mat
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Mat"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Lab
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Lab"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Eq
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Eq"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        i += 1
      Next
      Return dpiColl
    End Function
#End Region

#Region " IApprovAble "
    Public Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
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
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", DocID))
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
    Dim m As CostCenter
    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return m 'Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.m = Value
      End Set
    End Property
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
        Return "Icons.16x16.Approve"
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
            "select isnull(vo_closed,0) from vo where vo_id=" & Me.Id)
        If ds.Tables(0).Rows.Count > 0 Then
          If CInt(ds.Tables(0).Rows(0)(0)) = 1 OrElse CBool(ds.Tables(0).Rows(0)(0)) Then
            Return True
          End If
        End If
        Return False
      End Get
    End Property
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
      'If Me.SC.Status.Value = 0 OrElse Me.SC.Closed Then
      '  Return New SaveErrorException("${res:Global.Error.CanceledSC}", New String() {Me.SC.Code})
      'End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePO}", format) Then
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

        'Update PROrderedQty
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePROrderedQtyDeletePO" _
        ', New SqlParameter("@po_id", Me.Id))

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteVO", New SqlParameter() {New SqlParameter("@vo_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.POIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")
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
        'Return True
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
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
      'Me.ApproveDate = Date.MinValue
      'Me.ApprovePerson = New User
      For Each item As POItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          item.ReceivedQty = 0
        End If
      Next
      Return Me
    End Function
#End Region

#Region "IWBSAllocatable"
    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get

      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As VOItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As VOItem In Me.ItemCollection
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


  Public Class VOStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "vo_status"
      End Get
    End Property
#End Region

  End Class

  '    Public Class TaxType
  '        Inherits CodeDescription

  '#Region "Constructors"
  '        Public Sub New(ByVal value As Integer)
  '            MyBase.New(value)
  '        End Sub
  '#End Region

  '#Region "Properties"
  '        Public Overrides ReadOnly Property CodeName() As String
  '            Get
  '                Return "taxtype"
  '            End Get
  '        End Property
  '#End Region

  '    End Class

  Public Class VOForApprove
    Inherits VO
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "VOForApprove"
      End Get
    End Property
  End Class
End Namespace
