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
  Public Class DRStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "dr_status"
      End Get
    End Property
#End Region

  End Class
  Public Class DR
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, ICancelable, IHasToCostCenter, IDuplicable,  _
      ICheckPeriod, IWBSAllocatable, IApprovAble, IAbleExceptAccountPeriod _
   , ICloseStatusAble, IApproveStatusAble, IShowStatusColorAble

#Region "Members"

    Private m_docDate As Date
    Private m_olddocDate As Date
    'Private m_subcontractor As Supplier
    Private m_sc As SC
    'Private m_director As Employee
    Private m_status As DRStatus
    Private m_note As String

    Private m_fromcc As CostCenter
    Private m_fromEmployee As Employee

    'Private m_costCenter As CostCenter
    'Private m_toCostCenter As CostCenter
    'Private m_toEmployee As Employee '******คิดว่าน่าจะเป็น subcontract ที่รับไปนะ

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

    Private m_approvePerson As User
    Private m_approveDate As DateTime

    Private m_retention As Decimal
    Private m_witholdingTax As Decimal

    Private m_itemCollection As DRItemCollection
    Private m_closed As Boolean
    Private m_closing As Boolean

    Private m_approveDocColl As ApproveDocCollection

    Private m_customNoteColl As CustomNoteCollection
    Public Group As Boolean = False

    'Public MatActualHash As Hashtable
    'Public LabActualHash As Hashtable
    'Public EQActualHash As Hashtable


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
      Dim drr As DataRow = ds.Tables(0).Rows(0)
      Construct(drr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me

        .m_docDate = Now.Date
        .m_olddocDate = Now.Date
        .m_sc = New SC
        .m_sc.SubContractor = New Supplier
        .m_fromEmployee = New Employee
        .m_sc.CostCenter = New CostCenter
        .m_fromcc = New CostCenter
        '.m_costCenter = New CostCenter
        .m_status = New DRStatus(-1)
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
        .m_discount = New Discount("")
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))

        .m_retention = 0
        .m_witholdingTax = 0
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      'MatActualHash = New Hashtable
      'LabActualHash = New Hashtable
      'EQActualHash = New Hashtable
      m_itemCollection = New DRItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        'SC Info
        If dr.Table.Columns.Contains("dr_sc") Then
          If Not dr.IsNull("dr_sc") Then
            .m_sc = New SC(CInt(dr("dr_sc")))
          Else
            .m_sc = New SC
            Dim drh As New DataRowHelper(dr)
            .m_sc.SubContractor = New Supplier(drh.GetValue(Of Integer)("dr_subcontractor"))
            .m_sc.CostCenter = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)("dr_tocc"))
          End If
        End If
        If dr.Table.Columns.Contains("dr_docdate") AndAlso Not dr.IsNull("dr_docdate") Then
          If IsDate(dr("dr_docdate")) Then
            .m_docDate = CDate(dr("dr_docdate"))
            .m_olddocDate = CDate(dr("dr_docdate"))
          End If
          '.m_subcontractor = New Supplier(dr, "supplier.")
        End If
        If dr.Table.Columns.Contains("dr_note") AndAlso Not dr.IsNull("dr_note") Then
          .m_note = CStr(dr("dr_note"))
        End If
        If dr.Table.Columns.Contains("dr_fromcc") Then
          If Not dr.IsNull("dr_fromcc") Then
            .m_fromcc = New CostCenter(CInt(dr("dr_fromcc")))
          End If
        End If
        If dr.Table.Columns.Contains("employee_id") Then
          If Not dr.IsNull("employee_id") Then
            .m_fromEmployee = New Employee(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "dr_fromemployee") Then
            .m_fromEmployee = New Employee(CInt(dr(aliasPrefix & "dr_fromemployee")))
          End If
        End If
        If dr.Table.Columns.Contains("dr_status") AndAlso Not dr.IsNull("dr_status") Then
          .m_status = New DRStatus(CInt(dr("dr_status")))
        End If
        If Not dr.IsNull(aliasPrefix & "dr_gross") Then
          .m_gross = CDec(dr(aliasPrefix & "dr_gross"))
        End If
        If Not dr.IsNull(aliasPrefix & "dr_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "dr_discrate")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dr_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "dr_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "dr_taxtype")))
        End If
        If Not dr.IsNull(aliasPrefix & "dr_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "dr_taxrate"))
        End If

        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "dr_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "dr_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "dr_taxbase"))
        End If

        ' Gross
        If dr.Table.Columns.Contains(aliasPrefix & "dr_gross") _
        AndAlso Not dr.IsNull(aliasPrefix & "dr_gross") Then
          .m_realGross = CDec(dr(aliasPrefix & "dr_gross"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "dr_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "dr_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "dr_taxamt"))
        End If
        '--------------------END REAL-------------------------

        If dr.Table.Columns.Contains(aliasPrefix & "dr_closed") AndAlso Not dr.IsNull(aliasPrefix & "dr_closed") Then
          .m_closed = CBool(dr(aliasPrefix & "dr_closed"))
          .m_closing = CBool(dr(aliasPrefix & "dr_closed"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dr_note") AndAlso Not dr.IsNull(aliasPrefix & "dr_note") Then
          .m_note = CStr(dr(aliasPrefix & "dr_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "dr_witholdingtax") AndAlso Not dr.IsNull(aliasPrefix & "dr_witholdingtax") Then
          .m_witholdingTax = CDec(dr(aliasPrefix & "dr_witholdingtax"))
        End If

        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "dr_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "dr_approvePerson")))
          End If
        End If
        ' Approved Date
        If Not dr.IsNull(aliasPrefix & "dr_approveDate") Then
          .m_approveDate = CDate(dr(aliasPrefix & "dr_approveDate"))
        End If
        'MatActualHash = New Hashtable
        'LabActualHash = New Hashtable
        'EQActualHash = New Hashtable
        m_itemCollection = New DRItemCollection(Me)
        Me.AutoCodeFormat = New AutoCodeFormat(Me)
        m_approveDocColl = New ApproveDocCollection(Me)
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
    Public Property Sc() As SC
      Get
        Return m_sc
      End Get
      Set(ByVal Value As SC)
        If Value.Status.Value = 0 OrElse Value.Closed Then
          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowWarningFormatted("${res:Global.Error.CanceledSC}", New String() {Value.Code})
          Return
        End If
        m_sc = Value
        Me.TaxRate = m_sc.TaxRate
        Me.TaxType = New TaxType(m_sc.TaxType.Value)
        'ChangePO()
      End Set
    End Property

    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property
    Public Property SubContractor() As Supplier Implements IWBSAllocatable.Supplier
      Get
        Return Me.Sc.SubContractor
      End Get
      Set(ByVal Value As Supplier)
        Me.Sc.SubContractor = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property FromEmployee() As Employee
      Get
        Return m_fromEmployee
      End Get
      Set(ByVal Value As Employee)
        m_fromEmployee = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
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
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, DRStatus)
      End Set
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
    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get
        Return m_fromcc
      End Get
      Set(ByVal Value As CostCenter)
        If m_fromcc.Id <> Value.Id Then
          For Each itm As DRItem In Me.ItemCollection
            itm.WBSDistributeCollection.Clear()
          Next
        End If

        m_fromcc = Value

        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ToCostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter, IHasToCostCenter.ToCC
      Get
        Return Me.Sc.CostCenter
      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property

    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        m_taxRate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property RealTaxBase() As Decimal
      Get
        Return m_realTaxBase
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxBase = Value
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
    Public ReadOnly Property TaxGross() As Decimal
      Get
        Return m_taxGross
      End Get
    End Property
    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = Me.RealGross
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Public Property TaxBase() As Decimal
      Get
        Return m_taxBase
      End Get
      Set(ByVal Value As Decimal)
        m_taxBase = Value
      End Set
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
    End Property
    Public Property TaxType() As TaxType
      Get
        Return m_taxType
      End Get
      Set(ByVal Value As TaxType)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Not Me.Sc Is Nothing Then
          If Value.Value <> Me.Sc.TaxType.Value Then
            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SC.CanNotChangeVATType}")
            Return
          End If
        End If
        m_taxType = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
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
    Public Property WitholdingTax() As Decimal
      Get
        Return m_witholdingTax
      End Get
      Set(ByVal Value As Decimal)
        m_witholdingTax = Value
      End Set
    End Property
    Public Property Closed() As Boolean Implements ICloseStatusAble.Closed
      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
      End Set
    End Property
    Public Property Closing() As Boolean
      Get
        Return m_closing
      End Get
      Set(ByVal Value As Boolean)
        m_closing = Value
        If m_closing Then 'กำลังจะปิด
          For Each item As DRItem In Me.ItemCollection
            item.SetMat(item.ReceivedMat)
            item.SetLab(item.ReceivedLab)
            item.SetEq(item.ReceivedEq)
            item.SetQty(item.ReceivedQty)
          Next
        Else 'ยกเลิกการปิด
          For Each item As DRItem In Me.ItemCollection
            item.SetMat(item.OldMat)
            item.SetLab(item.OldLab)
            item.SetEq(item.OldEq)
            item.SetQty(item.OldQty)
          Next
        End If
        Me.RefreshTaxBase()
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "DR"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.DR.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.DR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.DR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.DR.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "dr"
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
    Public Property ItemCollection() As DRItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As DRItemCollection)
        m_itemCollection = Value
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

#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("DR")

      myDatatable.Columns.Add(New DataColumn("dri_lineNumber", GetType(Integer)))
      'myDatatable.Columns.Add(New DataColumn("dri_drDesc", GetType(String))) 'รายละเอียด
      myDatatable.Columns.Add(New DataColumn("dri_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("dri_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_qty", GetType(String))) '"ปริมาณ"
      myDatatable.Columns.Add(New DataColumn("dri_unitprice", GetType(String))) '"มูลค่าตามสัญญา"
      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_mat", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_lab", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_eq", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DRAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dri_unvatable", GetType(Boolean)))

      'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
      'Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      'myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.CodeHeaderText}")
      'myDatatable.Columns("dri_itemName").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.DescriptionHeaderText}")
      'myDatatable.Columns("Unit").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.UnitHeaderText}")
      'myDatatable.Columns("dr_qty").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.QtyHeaderText}")
      Return myDatatable
    End Function

    Public Shared Function GetDR(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldDR As DR) As Boolean
      Dim newDr As New DR(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newDr.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        newDr = oldDR
      End If
      txtCode.Text = newDr.Code
      txtName.Text = ""
      If oldDR Is Nothing OrElse oldDR.Id <> newDr.Id Then
        oldDR = newDr
        Return True
      End If
      oldDR = newDr
      Return True
      Return False
    End Function
#End Region

#Region "Methods"
    Public Sub RefreshApproveDocCollection() Implements IApproveStatusAble.RefreshApproveDocCollection
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    'Public Function GetRetentionDeductedWithoutThisStock(ByVal stockId As Integer) As Decimal
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
    '    , CommandType.StoredProcedure _
    '    , "GetPORetentionDeductedWithoutThisStock" _
    '    , New SqlParameter("@po_id", Me.Id) _
    '    , New SqlParameter("@stock_id", stockId) _
    '    )
    '    If ds.Tables(0).Rows.Count = 1 Then
    '        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
    '            Return CDec(ds.Tables(0).Rows(0)(0))
    '        End If
    '    End If
    'End Function
    'Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal type As Integer)
    '    myWbs = New WBS(myWbs.Id)
    '    Dim o_n As OldNew
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
    '        If theHash.Contains(myWbs.Id) Then
    '            o_n = CType(theHash(myWbs.Id), OldNew)
    '        Else
    '            o_n = New OldNew
    '            Select Case type
    '                Case 0, 19, 42
    '                    o_n.OldValue = myWbs.GetActualMat(Me, 6)
    '                Case 88
    '                    o_n.OldValue = myWbs.GetActualLab(Me, 6)
    '                Case 89
    '                    o_n.OldValue = myWbs.GetActualEq(Me, 6)
    '            End Select
    '            o_n.NewValue = o_n.OldValue
    '            theHash(myWbs.Id) = o_n
    '        End If
    '        o_n.NewValue += (newVal - oldVal)

    '        'ส่งต่อไปยังแม่()
    '        If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
    '            SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, type)
    '        End If
    '    End If
    'End Sub
    'Public Function GetCurrentDiffForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
    '    Dim theHash As Hashtable
    '    Select Case itemType.Value
    '        Case 0, 19, 42
    '            theHash = MatActualHash
    '        Case 88
    '            theHash = LabActualHash
    '        Case 89
    '            theHash = EQActualHash
    '    End Select
    '    If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
    '        Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
    '        Return o_n.NewValue - o_n.OldValue
    '    End If
    '    Return 0
    'End Function
    'Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal itemType As ItemType) As Decimal
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
    'End Function
    'Public Function GetCurrentToCCAmountForMarkup(ByVal mk As Markup) As Decimal
    '  Dim ret As Decimal = 0
    '  For Each item As DRItem In Me.ItemCollection
    '    For Each grWBSD As WBSDistribute In item.ToCCWBSDistributeCollection
    '      If grWBSD.IsMarkup Then
    '        If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
    '          ret += (grWBSD.Percent * item.Amount / 100)
    '        End If
    '      End If
    '    Next
    '  Next
    '  Return ret
    'End Function
    Public Function GetCurrentFromCCAmountForMarkup(ByVal mk As Markup) As Decimal
      Dim ret As Decimal = 0
      For Each item As DRItem In Me.ItemCollection
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
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As DRItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      Dim stringPar As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Me.ToCostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.ToCostCenter.Boq Is Nothing OrElse Me.ToCostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If
      'PROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      'PROverBudgetOnlyWBSAllocate
      config = Configuration.GetConfig("GROverBudgetOnlyWBSAllocate")
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
      Dim dt As New DataTable
      If Not onlyCC Then
        For Each item As DRItem In Me.ItemCollection
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 AndAlso item.ItemType.Value <> 289 Then
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

              'สำหรับ WBS ที่เป็นแม่ตัวที่จัดสรรอยู่ =====>>
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
              Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
              Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim tActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
              Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.ToCostCenter.Id)
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
        For Each item As DRItem In Me.ItemCollection
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            'สำหรับ Auto จัดสรร
            Dim rootWBS As New WBS(Me.FromCostCenter.RootWBSId)
            Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
            Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
            Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.FromCostCenter.Id)
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
          Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
          Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          Dim currentActual As Decimal = wbsd.Amount

          Dim tActual As Decimal = (wbsd.WBS.GetActualMat(Me, 45) + wbsd.WBS.GetActualLab(Me, 45) + wbsd.WBS.GetActualEq(Me, 45))
          Dim tcActual As Decimal = wbsd.WBS.GetThisDocActualFromDB(45, Me.Id, wbsd.CostCenter.Id)
          If onlyWBSAllocate Then
            If wbsd.OwnerBudgetAmount < ((tActual - tcActual) + currentActual) Then
              Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
            End If
          End If
          If totalBudget < ((totalActual - thisActual) + currentActual) Then
            Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
          End If
        Next

        'Dim rootWBS As New WBS(Me.ToCostCenter.RootWBSId)
        'Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        'Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 7) + rootWBS.GetActualLab(Me, 7) + rootWBS.GetActualEq(Me, 7))
        'Dim totalCurrent As Decimal = Me.ItemCollection.Amount

        'If totalBudget < (totalActual + totalCurrent) Then
        '  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        'End If
      End If

      Return New SaveErrorException("0")
    End Function
    Private Function ValidateItem() As SaveErrorException
      Dim key As String = ""
      For Each ditem As DRItem In Me.ItemCollection
        Dim m_value As Decimal = ditem.Mat + ditem.Lab + ditem.Eq
        If ditem.Amount <> m_value Then
          Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          New String() {ditem.ItemDescription, Configuration.FormatToString(ditem.Amount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
        End If
        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In ditem.WBSDistributeCollection
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
        'Dim newHash2 As New Hashtable
        'For Each wbitem As WBSDistribute In ditem.FromCCWBSDistributeCollection
        '  key = wbitem.WBS.Id.ToString
        '  If Not newHash2.Contains(key) Then
        '    newHash2(key) = wbitem
        '  Else
        '    Return New SaveErrorException("${res:Global.Error.DupplicateWBS}", New String() {wbitem.WBS.Code})
        '  End If
        '  If (wbitem.WBS Is Nothing OrElse wbitem.WBS.Id = 0) AndAlso wbitem.CostCenter.BoqId > 0 Then
        '    Return New SaveErrorException("${res:Global.Error.WBSMissing}")
        '  End If
        'Next
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
    Private m_DocMethod As SaveDocMultiApprovalMethod
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
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
          If Me.Originated Then
            If Not Me.Sc.SubContractor Is Nothing Then
              If Me.Sc.SubContractor.Canceled Then
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.Sc.SubContractor.Code})
              End If
            End If
          End If

          If Me.ItemCollection.Count = 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
          End If

          Dim ValidateError As SaveErrorException = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          End If

          ''=============== Validate Over Budget ==================>>
          Dim ValidateOverBudgetError As SaveErrorException
          Dim config As Integer = CInt(Configuration.GetConfig("GROverBudget"))
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
        End If


        '    Dim tmpBoq As BOQ = Me.CostCenter.Boq
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        '     สร้าง ArrayList จาก Item ของ  SqlParameter ...
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
        '    Me.RefreshTaxBase()

        Dim oldcode As String
        Dim oldautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen

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
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_sc", ValidIdOrDBNull(Me.Sc)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.DocDate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_subcontractor", ValidIdOrDBNull(Me.Sc.SubContractor)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromemployee", ValidIdOrDBNull(Me.FromEmployee))) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_tocc", ValidIdOrDBNull(Me.Sc.CostCenter))) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_fromcc", ValidIdOrDBNull(Me.FromCostCenter))) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.TaxBase)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Me.AfterTax)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforetax", Me.BeforeTax)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", willClose)) '
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_witholdingtax", Me.WitholdingTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discamt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        'สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Dim oldid As Integer = Me.Id
        Try


          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                ResetID(oldid)
                ResetCode(oldcode, oldautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
            End Select
            '        -------------------------------------------------------
            '        Dim pris As String = GetPritemString()
            '        Dim sql As String = "select * from pritem where convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) " & _
            '        "in (select convert(nvarchar,poi_pr) + '|' +  convert(nvarchar,poi_prilinenumber) from poitem " & _
            '        "where poi_po =" & Me.Id & ") or convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) in " & pris

            '        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
            '        RecentCompanies.CurrentCompany.SiteConnectionString _
            '        , CommandType.Text _
            '        , sql _
            '        )
            '        Dim arr As New ArrayList
            '        For Each row As DataRow In ds.Tables(0).Rows
            '            Dim o As New ValueDisplayPair(row("pri_pr"), row("pri_linenumber"))
            '            arr.Add(o)
            '        Next
            '        -------------------------------------------------------

            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return saveDetailError
            Else
              Select Case CInt(saveDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid)
                  ResetCode(oldcode, oldautogen)
                  Return saveDetailError
                Case Else
              End Select
            End If

            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid)
                  ResetCode(oldcode, oldautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            trans.Commit()

          Catch ex As SqlException
            trans.Rollback()
            Me.ResetID(oldid)
            ResetCode(oldcode, oldautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid)
            ResetCode(oldcode, oldautogen)
            Return New SaveErrorException(ex.ToString)
          End Try

          'Sub Save Block =======================================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              trans.Rollback()
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
          'Sub Save Block =======================================================

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


      trans.Commit()
      Dim isCanceled As Integer = 0
      If Me.Status.Value = 0 Then
        isCanceled = 1
      End If
      Dim trans2 As SqlTransaction = conn.BeginTransaction
      Try


        Me.DeleteRef(conn, trans2)

        If Me.Sc.Id <> 0 Then
          SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "InsertUpdatereference" _
               , New SqlParameter("@entity_id", Me.Sc.Id) _
               , New SqlParameter("@entity_type", Me.Sc.EntityId) _
               , New SqlParameter("@refto_id", Me.Id) _
               , New SqlParameter("@refto_type", Me.EntityId) _
               , New SqlParameter("@refto_iscanceled", isCanceled) _
               )
        End If

        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "UpdateWBSReferencedFromDR", New SqlParameter("@refto_id", Me.Id))

        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")
        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "swang_UpdateGRWBSActual")
        trans2.Commit()
      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try


      Return New SaveErrorException("0")
    End Function
    Private Function SubSaveDocApprove(ByVal conn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException
      Dim strans As SqlTransaction = conn.BeginTransaction

      Try
        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.Gross, currentUserId, m_DocMethod, Me.ApproveDocColl.GetLastedApproveDoc.Comment, 0, Me.SubContractor.Id, Me)
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
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      'Dim currWBS As String
      Try
        Dim da As New SqlDataAdapter("Select * from dritem where dri_dr=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from driwbs where driw_sequence in (select dri_sequence from dritem where dri_dr=" & Me.Id & ")", conn)
        Dim daOld As New SqlDataAdapter("Select * from drolditem where drio_sequence in (select dri_sequence from dritem where dri_dr=" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From dritem Where dri_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "dritem")
        da.Fill(ds, "dritem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "driwbs")
        daWbs.Fill(ds, "driwbs")
        ds.Relations.Add("sequence", ds.Tables!dritem.Columns!dri_sequence, ds.Tables!driwbs.Columns!driw_sequence)

        cmdBuilder = New SqlCommandBuilder(daOld)
        daOld.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daOld.FillSchema(ds, SchemaType.Mapped, "drolditem")
        daOld.Fill(ds, "drolditem")
        ds.Relations.Add("sequence2", ds.Tables!dritem.Columns!dri_sequence, ds.Tables!drolditem.Columns!drio_sequence)

        Dim dt As DataTable = ds.Tables("dritem")
        Dim dtWbs As DataTable = ds.Tables("driwbs")
        Dim dtOld As DataTable = ds.Tables("drolditem")

        For Each row As DataRow In ds.Tables("drolditem").Rows
          row.Delete()
        Next
        For Each row As DataRow In ds.Tables("driwbs").Rows
          row.Delete()
        Next
        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As DRItem In Me.ItemCollection
            If testItem.Sequence = CInt(dr("dri_sequence")) Then
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
        'For Each row As DataRow In ds.Tables("dritem").Rows
        '  row.Delete()
        'Next

        Dim i As Integer = 0
        With ds.Tables("dritem")
          For Each item As DRItem In Me.ItemCollection
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
            Dim drs As DataRow() = ds.Tables("dritem").Select("dri_sequence=" & item.Sequence)
            If drs.Length = 0 Then
              dr = .NewRow
              dr("dri_sequence") = (-1) * i
              .Rows.Add(dr)
            Else
              dr = drs(0)
            End If
            '------------End Checking--------------------

            dr("dri_dr") = Me.Id
            dr("dri_lineNumber") = i
            dr("dri_sc") = Me.Sc.Id
            dr("dri_entity") = item.Entity.Id
            dr("dri_entityType") = item.ItemType.Value
            dr("dri_itemName") = item.EntityName
            dr("dri_unit") = item.Unit.Id
            dr("dri_qty") = item.Qty
            dr("dri_unitprice") = item.UnitPrice
            dr("dri_mat") = item.Mat
            dr("dri_lab") = item.Lab
            dr("dri_eq") = item.Eq
            dr("dri_amt") = item.Amount
            dr("dri_note") = item.Note
            dr("dri_status") = Me.Status.Value
            dr("dri_unitCost") = item.UnitCost
            '.Rows.Add(dr)
            'dr("dri_drDesc") = ""
            dr("dri_unvatable") = item.UnVatable

            Dim dr2 As DataRow = dtOld.NewRow
            dr2("drio_sequence") = dr("dri_sequence")
            If Me.Closed AndAlso Not Me.Closing Then 'ยกเลิกปิด DR
              dr2("drio_qty") = item.OldQty
              dr2("drio_mat") = item.OldMat
              dr2("drio_lab") = item.OldLab
              dr2("drio_eq") = item.OldEq
              dr2("drio_amt") = item.OldAmount
            ElseIf Not Me.Closed AndAlso Me.Closing Then 'กำลังจะปิด DR
              dr2("drio_qty") = item.OldQty
              dr2("drio_mat") = item.OldMat
              dr2("drio_lab") = item.OldLab
              dr2("drio_eq") = item.OldEq
              dr2("drio_amt") = item.OldAmount
            ElseIf Not Me.Closed AndAlso Not Me.Closing Then 'ยังไม่เคยปิด และยังไม่ปิด หรือเคยเปิดมาแล้ว
              dr2("drio_qty") = item.Qty
              dr2("drio_mat") = item.Mat
              dr2("drio_lab") = item.Lab
              dr2("drio_eq") = item.Eq
              dr2("drio_amt") = item.Amount
            End If
            dtOld.Rows.Add(dr2)

            If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then

              'For x As Integer = 0 To 1
              Dim rootWBS As WBS
              Dim wbsdColl As WBSDistributeCollection
              Dim currentSum As Decimal
              Dim currentCostCenter As CostCenter

              'If x = 0 Then
              '  rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
              '  wbsdColl = item.ToCCWBSDistributeCollection
              '  currentSum = wbsdColl.GetSumPercent
              '  currentCostCenter = Me.ToCostCenter
              'Else
              rootWBS = New WBS(Me.FromCostCenter.RootWBSId)
              wbsdColl = item.WBSDistributeCollection
              currentSum = wbsdColl.GetSumPercent
              currentCostCenter = Me.FromCostCenter
              'End If

              'If (x = 0 AndAlso item.AllowWBSAllocateTo) OrElse (x = 1 AndAlso item.AllowWBSAllocateFrom) Then

              Try
                For Each wbsd As WBSDistribute In wbsdColl
                  If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                    'ยังไม่เต็ม 100 แต่มีหัวอยู่
                    wbsd.Percent += (100 - currentSum)
                  End If
                  Dim bfTax As Decimal = 0
                  bfTax = Math.Abs(item.CostAmount)
                  wbsd.BaseCost = bfTax 'item.Amount
                  'wbsd.TransferBaseCost = bfTax 'item.Amount
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("driw_sequence") = dr("dri_sequence")
                  childDr("driw_wbs") = wbsd.WBS.Id
                  childDr("driw_percent") = wbsd.Percent
                  childDr("driw_ismarkup") = wbsd.IsMarkup
                  childDr("driw_direction") = 1 'x
                  childDr("driw_baseCost") = wbsd.BaseCost
                  childDr("driw_amt") = wbsd.Amount
                  'childDr("sciw_toaccttype") = Me.ToAccountType.Value
                  If wbsd.CostCenter Is Nothing Then
                    wbsd.CostCenter = currentCostCenter
                  End If
                  childDr("driw_cc") = wbsd.CostCenter.Id
                  childDr("driw_cbs") = wbsd.CBS.Id
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
                  bfTax = item.CostAmount
                  wbsd.BaseCost = bfTax 'item.Amount
                  'wbsd.TransferBaseCost = bfTax 'item.Amount
                  Dim childDr As DataRow = dtWbs.NewRow

                  childDr("driw_sequence") = dr("dri_sequence")
                  childDr("driw_wbs") = wbsd.WBS.Id
                  childDr("driw_percent") = wbsd.Percent
                  childDr("driw_ismarkup") = wbsd.IsMarkup
                  childDr("driw_direction") = 1 'x
                  childDr("driw_baseCost") = wbsd.BaseCost
                  childDr("driw_amt") = wbsd.Amount
                  'childDr("sciw_toaccttype") = Me.ToAccountType.Value                               
                  childDr("driw_cc") = wbsd.CostCenter.Id
                  childDr("driw_cbs") = wbsd.CBS.Id

                  'Add เข้า sciwbs
                  dtWbs.Rows.Add(childDr)
                Catch ex As Exception
                  Throw New Exception(ex.Message)
                End Try
              End If

              'End If

              'Next

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
        Dim currentkey As Integer = CInt(e.Row("driw_sequence")) '.GetParentRow("sequence")("sciw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!driw_sequence = e.Row.GetParentRow("sequence")("dri_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!driw_sequence = currentkey
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
        Dim currentkey As Integer = CInt(e.Row("drio_sequence")) '.GetParentRow("sequence")("driw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!drio_sequence = e.Row.GetParentRow("sequence2")("dri_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!drio_sequence = currentkey
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
    'Private Function GetPritemString() As String
    '    Dim ret As String = "("
    '    'For Each item As POItem In Me.ItemCollection
    '    '    If Not item.Pritem Is Nothing Then
    '    '        ret &= "'" & item.Pritem.Pr.Id.ToString & "|" & item.Pritem.LineNumber & "',"
    '    '    End If
    '    'Next
    '    ret &= "'')"
    '    Return ret
    'End Function
    'Private Function SavePRItemsDetail(ByVal arr As ArrayList, ByVal trans As SqlTransaction, ByVal conn As SqlConnection) As SaveErrorException
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
    '    'po1.ItemCollection = New DRItemCollection(po1)

    '    Return po1
    'End Function
    Public Function CloneGroupingItem() As DR
      Dim dr1 As New DR
      dr1.Id = Me.Id
      dr1.Group = True
      dr1.ItemCollection = New DRItemCollection(dr1)

      Return dr1
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
      For Each item As DRItem In Me.ItemCollection
        m_gross += item.Amount
        If Not item.UnVatable Then
          m_taxGross += item.Amount
          sumAmountWithVat += item.Amount
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
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PR.dfm"
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

      If Not Me.Sc Is Nothing Then
        'SCCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SCCode"
        dpi.Value = Me.Sc.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        If Not Me.Sc.Director Is Nothing AndAlso Me.Sc.Director.Originated Then
          'RequestorId
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorId"
          dpi.Value = Me.Sc.Director.Id
          dpi.DataType = "System.String"
          dpi.SignatureType = SignatureType.Person
          dpiColl.Add(dpi)

          'RequestorInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorInfo"
          dpi.Value = Me.Sc.Director.Code & ":" & Me.Sc.Director.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RequestorCode
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorCode"
          dpi.Value = Me.Sc.Director.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RequestorName
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorName"
          dpi.Value = Me.Sc.Director.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If
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

      If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then
        'ToCostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterInfo"
        dpi.Value = Me.ToCostCenter.Code & ":" & Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterCode"
        dpi.Value = Me.ToCostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCostCenterName"
        dpi.Value = Me.ToCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ToCostCenterAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAddress"
        dpi.Value = Me.ToCostCenter.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromEmployee Is Nothing AndAlso Me.FromEmployee.Originated Then
        'FromEmployeeInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "SubcontractorInfo"
        dpi.Value = Me.FromEmployee.Code & ":" & Me.FromEmployee.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromEmployeeCode
        dpi = New DocPrintingItem
        dpi.Mapping = "FromEmployeeCode"
        dpi.Value = Me.FromEmployee.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromEmployeeName
        dpi = New DocPrintingItem
        dpi.Mapping = "FromEmployeeName"
        dpi.Value = Me.FromEmployee.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAddress"
        dpi.Value = Me.FromCostCenter.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.FromCostCenter Is Nothing AndAlso Me.FromCostCenter.Originated Then
        'FromCostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterInfo"
        dpi.Value = Me.FromCostCenter.Code & ":" & Me.FromCostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterCode"
        dpi.Value = Me.FromCostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'FromCostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCostCenterName"
        dpi.Value = Me.FromCostCenter.Name
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

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'อัตราภาษี
      'TaxRate
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxRate"
      dpi.Value = Configuration.FormatToString(Me.TaxRate, DigitConfig.Int)
      dpi.DataType = "System.String"
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
        Next

      End If

      Dim LastLevelApprove As New Hashtable
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 AndAlso Not ap.Reject Then
          LastLevelApprove(ap.Level) = ap
        End If
      Next
      For Each ap As ApproveDoc In LastLevelApprove.Values
        dpi = New DocPrintingItem
        dpi.Mapping = "ApprovePersonIdLevel " & ap.Level.ToString
        dpi.Value = ap.Originator
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.ApprovePerson
        dpiColl.Add(dpi)
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

      dpiColl.AddRange(GetRealItemCollDocPrintingEntries)
      dpiColl.AddRange(GetItemCollDocPrintingEntries)

      Return dpiColl
    End Function

    Public Function GetRealItemCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      '------------------ท้ายเอกสาร------------------------------

      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As DRItem In Me.ItemCollection
        line += 1

        'Item.LineNumber
        '************** เอามาไว้เป็นอันที่ 2
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.LineNumber"
        dpi.Value = line
        dpi.Font = fn
        dpi.DataType = "System.Int32"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Code"
        dpi.Value = item.Entity.Code
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
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

        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Unit"
        dpi.Value = item.Unit.Name
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Qty"
        If item.OldQty = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldQty, DigitConfig.Qty)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.UnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.UnitPrice"
        If item.UnitPrice = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Amount"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ReceivedAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ReceivedAmount"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Mat
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Mat"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Lab
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Lab"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldLab, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Eq
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Eq"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldEq, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Note"
        dpi.Value = item.Note
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        i += 1
      Next
      Return dpiColl
    End Function
    Public Function GetItemCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      '------------------ท้ายเอกสาร------------------------------

      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As DRItem In Me.ItemCollection
        line += 1

        'Item.LineNumber
        '************** เอามาไว้เป็นอันที่ 2
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = line
        dpi.Font = fn
        dpi.DataType = "System.Int32"
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
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
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
    'Dim m As CostCenter
    'Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
    '  Get
    '    Return m 'Me.CostCenter
    '  End Get
    '  Set(ByVal Value As CostCenter)
    '    Me.m = Value
    '  End Set
    'End Property
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
            "select isnull(dr_closed,0) from dr where dr_id=" & Me.Id)
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteDR", New SqlParameter() {New SqlParameter("@dr_id", Me.Id), returnVal})
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")

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
      Me.Canceled = False
      Me.CancelPerson = New User
      Me.Closing = False
      Me.Closed = False
      Me.ClearReference()
      Dim wbsdummy As WBS
      For Each item As DRItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsdummy = wbsd.WBS
            wbsd.WBS = wbsdummy
          Next
        End If
      Next
      Return Me
    End Function
#End Region

#Region "IWBSAllocatable"
    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As DRItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As DRItem In Me.ItemCollection
                For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                  If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                    wbsd.ChildAmount += childWbsd.Amount
                  End If
                Next
              Next
            Next
            'For Each wbsd As WBSDistribute In item.ToCCWBSDistributeCollection
            '  wbsd.ChildAmount = 0
            '  wbsd.GetChildIdList()
            '  For Each allItem As DRItem In Me.ItemCollection
            '    For Each childWbsd As WBSDistribute In allItem.ToCCWBSDistributeCollection
            '      If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
            '        wbsd.ChildAmount += childWbsd.Amount
            '      End If
            '    Next
            '  Next
            'Next
          End If

          coll.Add(item)
        End If
      Next
      Return coll
    End Function
    Public ReadOnly Property AllowWBSAllocateFrom As Boolean Implements IWBSAllocatable.AllowWBSAllocateFrom
      Get
        Return True
      End Get
    End Property
    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IWBSAllocatable.AllowWBSAllocateTo
      Get
        Return False
      End Get
    End Property
#End Region

#Region "IApproveStatusAble"
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
#End Region

  End Class
  '    Public Class DRStatus
  '        Inherits CodeDescription

  '#Region "Constructors"
  '        Public Sub New(ByVal value As Integer)
  '            MyBase.New(value)
  '        End Sub
  '#End Region

  '#Region "Properties"
  '        Public Overrides ReadOnly Property CodeName() As String
  '            Get
  '                Return "po_status"
  '            End Get
  '        End Property
  '#End Region

  '    End Class

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

  Public Class DRForApprove
    Inherits DR
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "DRForApprove"
      End Get
    End Property
  End Class
End Namespace
