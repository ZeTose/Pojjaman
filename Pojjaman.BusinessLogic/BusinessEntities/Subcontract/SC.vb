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
  Public Class SCStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "sc_status"
      End Get
    End Property
#End Region

  End Class
  Public Class SC
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, ICancelable, IHasToCostCenter, IDuplicable,  _
      ICheckPeriod, IWBSAllocatable, IApprovAble, IAbleExceptAccountPeriod _
   , ICloseStatusAble, IApproveStatusAble, IShowStatusColorAble

#Region "Members"

    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_startDate As Date
    Private m_endDate As Date
    Private m_subcontractor As Supplier
    Private m_wr As WR
    Private m_cc As CostCenter
    Private m_director As Employee
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
    Private m_closed As Boolean
    Private m_closing As Boolean
    Private m_status As SCStatus
    Private m_creditPeriod As Long
    Private m_contactPerson As String
    Private m_approvePerson As User
    Private m_approveDate As DateTime

    'Public Group As Boolean = False

    Private m_note As String

    Private m_retention As Decimal
    Private m_witholdingTax As Decimal
    Private m_advancepay As Decimal

    Private m_itemCollection As SCItemCollection
    Private m_approveDocColl As ApproveDocCollection
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
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String, Optional ByVal noItem As Boolean = False)
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
        .m_startDate = Now.Date
        .m_endDate = Now.Date
        .m_subcontractor = New Supplier
        .m_contactPerson = ""
        .m_cc = New CostCenter
        .m_director = New Employee
        .m_wr = New WR

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
        .m_closed = False
        .m_status = New SCStatus(-1)
        .m_note = ""
        .m_creditPeriod = 0

        .m_retention = 0
        .m_witholdingTax = 0
        .m_advancepay = 0
        .AutoCodeFormat = New AutoCodeFormat(Me)

      End With
      'MatActualHash = New Hashtable
      'LabActualHash = New Hashtable
      'EQActualHash = New Hashtable
      m_itemCollection = New SCItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains("sc_docdate") Then
          If Not dr.IsNull("sc_docdate") Then
            If IsDate(dr("sc_docdate")) Then
              .m_docDate = CDate(dr("sc_docdate"))
              .m_olddocDate = CDate(dr("sc_docdate"))
            End If
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_docdate") Then
            If IsDate(dr(aliasPrefix & "sc_docdate")) Then
              .m_docDate = CDate(aliasPrefix & "sc_docdate")
              .m_olddocDate = CDate(aliasPrefix & "sc_docdate")
            End If
          End If
        End If
        If Not dr.IsNull("sc_creditperiod") Then
          .m_creditPeriod = CLng(dr("sc_creditperiod"))
        End If
        If Not dr.IsNull("sc_contactPerson") Then
          .m_contactPerson = CStr(dr("sc_contactPerson"))
        End If
        If dr.Table.Columns.Contains("sc_startdate") Then
          If Not dr.IsNull("sc_startdate") Then
            If IsDate(dr("sc_startdate")) Then
              .m_startDate = CDate(dr("sc_startdate"))
            End If
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_startdate") Then
            If IsDate(dr(aliasPrefix & "sc_startdate")) Then
              .m_startDate = CDate(aliasPrefix & "sc_startdate")
            End If
          End If
        End If
        If dr.Table.Columns.Contains("sc_enddate") Then
          If Not dr.IsNull("sc_enddate") Then
            If IsDate(dr("sc_enddate")) Then
              .m_endDate = CDate(dr("sc_enddate"))
            End If
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_enddate") Then
            If IsDate(dr(aliasPrefix & "sc_enddate")) Then
              .m_endDate = CDate(aliasPrefix & "sc_enddate")
            End If
          End If
        End If
        If dr.Table.Columns.Contains("supplier_id") Then
          If Not dr.IsNull("supplier_id") Then
            .m_subcontractor = New Supplier(CInt(dr("supplier_id"))) 'Supplier.GetSupplierbyDataRow(dr)
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_subcontractor") Then
            .m_subcontractor = New Supplier(CInt(dr(aliasPrefix & "sc_subcontractor")))
          End If
        End If
        If dr.Table.Columns.Contains("cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .m_cc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "cc_id")))
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_cc") Then
            .m_cc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "sc_cc")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wr_id") Then
          If Not dr.IsNull("wr_id") Then
            .m_wr = WR.GetWRbyDataRow(dr)
            '.m_wr = New WR(dr, "", False)
          End If
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "sc_wr") Then
          If Not dr.IsNull(aliasPrefix & "sc_wr") Then
            .m_wr = New WR(CInt(dr(aliasPrefix & "sc_wr")))
          End If
        End If
        If dr.Table.Columns.Contains("employee_id") Then
          If Not dr.IsNull("employee_id") Then
            .m_director = New Employee(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_director") Then
            .m_director = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "sc_director")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "sc_gross") Then
          .m_gross = CDec(dr(aliasPrefix & "sc_gross"))
        End If
        If Not dr.IsNull(aliasPrefix & "sc_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "sc_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sc_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "sc_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "sc_taxtype")))
        End If
        If Not dr.IsNull(aliasPrefix & "sc_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "sc_taxrate"))
        End If
        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "sc_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "sc_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "sc_taxbase"))
        End If

        ' Gross
        If dr.Table.Columns.Contains(aliasPrefix & "sc_gross") _
        AndAlso Not dr.IsNull(aliasPrefix & "sc_gross") Then
          .m_realGross = CDec(dr(aliasPrefix & "sc_gross"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "sc_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "sc_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "sc_taxamt"))
        End If
        '--------------------END REAL-------------------------
        If dr.Table.Columns.Contains(aliasPrefix & "sc_closed") AndAlso Not dr.IsNull(aliasPrefix & "sc_closed") Then
          .m_closed = CBool(dr(aliasPrefix & "sc_closed"))
          .m_closing = CBool(dr(aliasPrefix & "sc_closed"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_status") AndAlso Not dr.IsNull(aliasPrefix & "sc_status") Then
          .m_status = New SCStatus(CInt(dr(aliasPrefix & "sc_status")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_note") AndAlso Not dr.IsNull(aliasPrefix & "sc_note") Then
          .m_note = CStr(dr(aliasPrefix & "sc_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_retention") AndAlso Not dr.IsNull(aliasPrefix & "sc_retention") Then
          .m_retention = CDec(dr(aliasPrefix & "sc_retention"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_advancepay") AndAlso Not dr.IsNull(aliasPrefix & "sc_advancepay") Then
          .m_advancepay = CDec(dr(aliasPrefix & "sc_advancepay"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_witholdingtax") AndAlso Not dr.IsNull(aliasPrefix & "sc_witholdingtax") Then
          .m_witholdingTax = CDec(dr(aliasPrefix & "sc_witholdingtax"))
        End If


        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "sc_approvePerson")))
          End If
        End If
        ' Approved Date
        If Not dr.IsNull(aliasPrefix & "sc_approveDate") Then
          .m_approveDate = CDate(dr(aliasPrefix & "sc_approveDate"))
        End If

        m_itemCollection = New SCItemCollection(Me)

      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
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
    '--------------------REAL-------------------------    Public Property RealGross() As Decimal
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
    Public Property RealTaxBase() As Decimal
      Get
        Return m_realTaxBase
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxBase = Value
      End Set
    End Property
    '--------------------end REAL-------------------------
    Public Property Closed() As Boolean Implements ICloseStatusAble.Closed      Get
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
          For Each item As SCItem In Me.ItemCollection
            'If Not item.NewChild Then
            item.SetMat(item.ReceiptMat)
            item.SetLab(item.ReceiptLab)
            item.SetEq(item.ReceiptEq)
            item.SetQty(item.ReceiptQty)
            'End If
          Next
        Else 'ยกเลิกการปิด
          For Each item As SCItem In Me.ItemCollection
            'If Not item.NewChild Then
            item.SetMat(item.OldMat)
            item.SetLab(item.OldLab)
            item.SetEq(item.OldEq)
            item.SetQty(item.OldQty)
            'End If
          Next
        End If
        Me.RefreshTaxBase()
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
    Public Property ItemCollection() As SCItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As SCItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property SubContractor() As Supplier Implements IWBSAllocatable.Supplier
      Get
        Return m_subcontractor
      End Get
      Set(ByVal Value As Supplier)
        If m_subcontractor Is Nothing Then
          m_subcontractor = New Supplier
        End If
        If Value.Id <> m_subcontractor.Id Then
          Me.m_creditPeriod = Value.CreditPeriod
        End If
        m_subcontractor = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property WR As WR
      Get
        Return m_wr
      End Get
      Set(ByVal value As WR)
        m_wr = value
        ChangeWR()
      End Set
    End Property
    Public Property Director() As Employee
      Get
        Return m_director
      End Get
      Set(ByVal Value As Employee)
        m_director = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ContactPerson As String
      Get
        Return m_contactPerson
      End Get
      Set(ByVal value As String)
        m_contactPerson = value
      End Set
    End Property
    Public Property CostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        If m_cc Is Nothing Then
          m_cc = New CostCenter
        End If
        If m_cc.Id <> Value.Id Then
          For Each itm As SCItem In Me.ItemCollection
            itm.WBSDistributeCollection.Clear()
          Next
        End If
        m_cc = Value

        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return m_olddocDate
      End Get
    End Property    Public Property DueDate() As Date
      Get
        Try
          Return Me.DocDate.AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.DocDate
        End Try
      End Get
      Set(ByVal Value As Date)
        Try
          m_creditPeriod = DateDiff(DateInterval.Day, DocDate, Value)
        Catch ex As Exception

        End Try
      End Set
    End Property    Public Property CreditPeriod() As Long      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Long)        m_creditPeriod = Value      End Set    End Property    Public Property StartDate() As Date      Get        Return m_startDate      End Get      Set(ByVal Value As Date)        m_startDate = Value        'OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property EndDate() As Date      Get        Return m_endDate      End Get      Set(ByVal Value As Date)        m_endDate = Value        'OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property Note() As String      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property    Public Property Retention() As Decimal
      Get
        Return m_retention
      End Get
      Set(ByVal Value As Decimal)
        m_retention = Value
      End Set
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
    End Property    Public ReadOnly Property TaxGross() As Decimal
      Get
        Return m_taxGross
      End Get
    End Property    Public Property Discount() As Discount
      Get
        Return m_discount
      End Get
      Set(ByVal Value As Discount)
        m_discount = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = Me.RealGross
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property    Public Property RealDiscountAmount As Decimal      Get
        Return Me.DiscountAmount
      End Get
      Set(ByVal value As Decimal)

      End Set
    End Property    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        m_taxRate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property    Public Property TaxBase() As Decimal
      Get
        Return m_taxBase
      End Get
      Set(ByVal Value As Decimal)
        m_taxBase = Value
      End Set
    End Property    Public Property TaxType() As TaxType
      Get
        Return m_taxType
      End Get
      Set(ByVal Value As TaxType)
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
    End Property    Public ReadOnly Property BeforeTax() As Decimal
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
    End Property    Public Property RealBeforeTax() As Decimal
      Get
        Return Me.BeforeTax
      End Get
      Set(ByVal value As Decimal)

      End Set
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
    End Property    Public Property RealAfterTax As Decimal      Get
        Return Me.AfterTax
      End Get
      Set(ByVal value As Decimal)

      End Set
    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, SCStatus)
      End Set
    End Property    Public Property AdvancePay() As Decimal      Get
        Return m_advancepay
      End Get
      Set(ByVal Value As Decimal)
        m_advancepay = Value
      End Set
    End Property    Public Property WitholdingTax() As Decimal      Get
        Return m_witholdingTax
      End Get
      Set(ByVal Value As Decimal)
        m_witholdingTax = Value
      End Set
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "SC"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "sc"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SC.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.SC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.SC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SC.ListLabel}"
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
    Public Shared Function GetSC(ByVal txtCode As TextBox, ByRef oldSC As SC, Optional ByVal GetMiniSC As Boolean = False, Optional ByVal pa As PA = Nothing) As Boolean
      If txtCode.Text.Length > 0 Then
        Dim scNew As SC
        If pa IsNot Nothing AndAlso CBool(Configuration.GetConfig("ApproveSC")) Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
          , CommandType.StoredProcedure _
          , "SCisApprove" _
             , New SqlParameter("@sc_code", txtCode.Text) _
          )
          If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
            scNew = oldSC
            txtCode.Text = oldSC.Code
            Return False
          End If
          Dim isApprove As Boolean = CBool(ds.Tables(0).Rows(0)(0))
          If Not isApprove Then
            MessageBox.Show(txtCode.Text & " ยังไม่อนุมัติ")
            scNew = oldSC
            txtCode.Text = oldSC.Code
            Return False
          End If
        End If
        If GetMiniSC Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
           , CommandType.StoredProcedure _
           , "GetSC" _
              , New SqlParameter("@sc_code", txtCode.Text) _
           )
          scNew = New SC
          If ds.Tables(0).Rows.Count = 0 OrElse ds.Tables(0).Rows(0).IsNull(0) Then
            MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
            scNew = oldSC
            txtCode.Text = oldSC.Code
            Return False
          End If
          SetNewSCbyRow(scNew, ds.Tables(0).Rows(0))
        Else
          scNew = New SC(txtCode.Text)
        End If
        If txtCode.Text.Length <> 0 AndAlso Not scNew.Valid Then
          MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
          scNew = oldSC
          txtCode.Text = oldSC.Code
          Return False
        End If
        txtCode.Text = scNew.Code
        If oldSC.Id <> scNew.Id Then
          oldSC = scNew
          Return True
        End If
        oldSC = scNew
      End If

      Return True

    End Function

    Public Shared Sub SetNewSCbyRow(ByVal sc As SC, ByVal dr As DataRow)
      Dim aliasPrefix As String = ""
      Dim drh As New DataRowHelper(dr)
      With sc
        .Id = drh.GetValue(Of Integer)("sc_id")
        .Code = drh.GetValue(Of String)("sc_code")
        If dr.Table.Columns.Contains("sc_docdate") Then
          If Not dr.IsNull("sc_docdate") Then
            If IsDate(dr("sc_docdate")) Then
              .m_docDate = CDate(dr("sc_docdate"))
            End If
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_docdate") Then
            If IsDate(dr(aliasPrefix & "sc_docdate")) Then
              .m_docDate = CDate(aliasPrefix & "sc_docdate")
            End If
          End If
        End If
        If Not dr.IsNull("sc_creditperiod") Then
          .m_creditPeriod = CLng(dr("sc_creditperiod"))
        End If
        If Not dr.IsNull("sc_contactPerson") Then
          .m_contactPerson = CStr(dr("sc_contactPerson"))
        End If
        If dr.Table.Columns.Contains("sc_startdate") Then
          If Not dr.IsNull("sc_startdate") Then
            If IsDate(dr("sc_startdate")) Then
              .m_startDate = CDate(dr("sc_startdate"))
            End If
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_startdate") Then
            If IsDate(dr(aliasPrefix & "sc_startdate")) Then
              .m_startDate = CDate(aliasPrefix & "sc_startdate")
            End If
          End If
        End If
        If dr.Table.Columns.Contains("sc_enddate") Then
          If Not dr.IsNull("sc_enddate") Then
            If IsDate(dr("sc_enddate")) Then
              .m_endDate = CDate(dr("sc_enddate"))
            End If
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_enddate") Then
            If IsDate(dr(aliasPrefix & "sc_enddate")) Then
              .m_endDate = CDate(aliasPrefix & "sc_enddate")
            End If
          End If
        End If
        If dr.Table.Columns.Contains("supplier_id") Then
          If Not dr.IsNull("supplier_id") Then
            .m_subcontractor = New Supplier(CInt(dr("supplier_id"))) 'Supplier.GetSupplierbyDataRow(dr)
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_subcontractor") Then
            .m_subcontractor = New Supplier(CInt(dr(aliasPrefix & "sc_subcontractor")))
          End If
        End If
        If dr.Table.Columns.Contains("cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .m_cc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "cc_id")))
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_cc") Then
            .m_cc = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "sc_cc")))
          End If
        End If

        If dr.Table.Columns.Contains("employee_id") Then
          If Not dr.IsNull("employee_id") Then
            .m_director = New Employee(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_director") Then
            .m_director = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "sc_director")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "sc_gross") Then
          .m_gross = CDec(dr(aliasPrefix & "sc_gross"))
        End If
        If Not dr.IsNull(aliasPrefix & "sc_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "sc_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "sc_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "sc_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "sc_taxtype")))
        End If
        If Not dr.IsNull(aliasPrefix & "sc_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "sc_taxrate"))
        End If
        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "sc_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "sc_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "sc_taxbase"))
        End If

        ' Gross
        If dr.Table.Columns.Contains(aliasPrefix & "sc_gross") _
        AndAlso Not dr.IsNull(aliasPrefix & "sc_gross") Then
          .m_realGross = CDec(dr(aliasPrefix & "sc_gross"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "sc_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "sc_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "sc_taxamt"))
        End If
        '--------------------END REAL-------------------------
        If dr.Table.Columns.Contains(aliasPrefix & "sc_closed") AndAlso Not dr.IsNull(aliasPrefix & "sc_closed") Then
          .m_closed = CBool(dr(aliasPrefix & "sc_closed"))
          .m_closing = CBool(dr(aliasPrefix & "sc_closed"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_status") AndAlso Not dr.IsNull(aliasPrefix & "sc_status") Then
          .m_status = New SCStatus(CInt(dr(aliasPrefix & "sc_status")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_note") AndAlso Not dr.IsNull(aliasPrefix & "sc_note") Then
          .m_note = CStr(dr(aliasPrefix & "sc_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_retention") AndAlso Not dr.IsNull(aliasPrefix & "sc_retention") Then
          .m_retention = CDec(dr(aliasPrefix & "sc_retention"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_advancepay") AndAlso Not dr.IsNull(aliasPrefix & "sc_advancepay") Then
          .m_advancepay = CDec(dr(aliasPrefix & "sc_advancepay"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "sc_witholdingtax") AndAlso Not dr.IsNull(aliasPrefix & "sc_witholdingtax") Then
          .m_witholdingTax = CDec(dr(aliasPrefix & "sc_witholdingtax"))
        End If


        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "sc_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "sc_approvePerson")))
          End If
        End If
        ' Approved Date
        If Not dr.IsNull(aliasPrefix & "sc_approveDate") Then
          .m_approveDate = CDate(dr(aliasPrefix & "sc_approveDate"))
        End If
      End With

    End Sub

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("SC")
      myDatatable.Columns.Add(New DataColumn("sci_sequence", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_scDesc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_originqty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_mat", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_lab", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_eq", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PAAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_originamt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_level", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_unvatable", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("WRUnit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_wriUnit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_wriQty", GetType(String)))

      'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.CodeHeaderText}")
      myDatatable.Columns("sci_itemName").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.DescriptionHeaderText}")
      myDatatable.Columns("Unit").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.UnitHeaderText}")
      myDatatable.Columns("sci_qty").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.QtyHeaderText}")

      Return myDatatable
    End Function

#End Region

#Region "Methods"
    Public Sub RefreshReceiveAmount()
      For Each itm As SCItem In Me.ItemCollection
        'itm.ReceiveAmount = itm.ReceiveAmount
        itm.RecalculateReceiveAmount()
      Next
    End Sub
    Public Sub RefreshApproveDocCollection() Implements IApproveStatusAble.RefreshApproveDocCollection
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Private Sub ChangeWR()
      Me.ItemCollection.Clear()
      Me.StartDate = Date.Now
      Me.EndDate = Date.Now
      Me.CostCenter = New CostCenter
      Me.Director = New Employee

      Dim sci As SCItem
      Dim lineNumber As Integer = 0
      If Not Me.WR Is Nothing Then
        Me.StartDate = WR.StartDate
        Me.EndDate = WR.EndDate
        Me.CostCenter = WR.CostCenter
        Me.Director = WR.Director

        If Not Me.WR.ItemCollection Is Nothing Then
          For Each wri As WRItem In Me.WR.AbleItemCollection
            lineNumber += 1
            sci = New SCItem
            If Not wri.ItemType Is Nothing Then
              sci.ItemType = wri.ItemType
            End If
            If Not wri.Entity Is Nothing Then
              sci.Entity = wri.Entity
            End If
            sci.Linenumber = lineNumber
            sci.WRISequence = wri.Sequence
            sci.Level = wri.Level
            sci.WR = Me.WR
            sci.ItemName = wri.ItemName

            If wri.ItemType.Value <> 160 AndAlso wri.ItemType.Value <> 162 Then
              If Not wri.Unit Is Nothing Then
                sci.WRIUnit = wri.Unit
                sci.Unit = wri.Unit
              End If
              'If wri.ItemType.Value = 289 Then
              '  sci.SetWRIQty(wri.Qty - wri.OrderedQty)
              '  sci.SetWRIOrigingQty(sci.WRIQty)
              '  sci.SetQty(sci.WRIQty)
              'Else
              '  sci.SetWRIQty(wri.Qty)
              '  sci.SetWRIOrigingQty(wri.Qty)
              '  sci.SetQty(wri.Qty)
              'End If
              If wri.ItemType.Value = 289 Then
                sci.SetWRIQty(wri.Qty)
                sci.SetWRIOrigingQty(wri.Qty)
                sci.SetQty(wri.Qty)
              Else
                sci.SetWRIQty(wri.Qty - wri.OrderedQty)
                sci.SetWRIOrigingQty(sci.WRIQty)
                sci.SetQty(sci.WRIQty)
              End If
              sci.UnitPrice = wri.UnitPrice

              sci.Note = wri.Note
            End If

            sci.WBSDistributeCollection = New WBSDistributeCollection
            AddHandler sci.WBSDistributeCollection.PropertyChanged, AddressOf sci.WBSChangedHandler
            For Each wbsd As WBSDistribute In wri.WBSDistributeCollection
              sci.WBSDistributeCollection.Add(wbsd)
            Next

            Me.ItemCollection.Add(sci)
            For Each wbsd As WBSDistribute In sci.WBSDistributeCollection
              Me.ItemCollection.SetBudgetRemain(wbsd, sci)
            Next

          Next
        End If
      End If
    End Sub
    Public Function GetUnClosedContract() As String
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetUnClosedContract" _
      , New SqlParameter("@sc_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        Return CStr(ds.Tables(0).Rows(0)(0))
      End If
      Return ""
    End Function
    Public Function GetWROrderedQtyBySC() As Hashtable
      If Me.WR Is Nothing AndAlso Me.WR.Originated Then
        Dim hashwr As New Hashtable
        Dim key As Integer
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
        , CommandType.StoredProcedure _
        , "GetWROrderedQtyBySC" _
        , New SqlParameter("@wr_id", Me.WR.Id) _
        )
        For Each row As DataRow In ds.Tables(0).Rows
          Dim wri As New WRItem(row, "")
          key = wri.Sequence
          hashwr.Add(key, wri)
        Next
        Return hashwr
      End If
      Return Nothing
    End Function
    Public Function GetCurrentAmountForMarkup(ByVal mk As Markup) As Decimal
      Dim ret As Decimal = 0
      For Each item As SCItem In Me.ItemCollection
        'If Not item.NewChild Then
        For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
          If grWBSD.IsMarkup Then
            If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
              ret += (grWBSD.Percent * item.Amount / 100)
            End If
          End If
        Next
        'End If
      Next
      Return ret
    End Function
    Public Function GetCurrentTypeQtyForWBS(ByVal myWbs As WBS, ByVal name As String, ByVal type As Integer) As Decimal
      Dim ret As Decimal = 0
      For Each item As SCItem In Me.ItemCollection
        'If Not item.NewChild Then
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
              Dim view As Integer = 6
              Dim transferAmt As Decimal = item.Amount
              Dim amt As Decimal = WBSDistribute.GetUsedQty(item.Qty, isOut, view, 3)
              If grWBSD.WBS.IsDescendantOf(myWbs) Then
                ret += (grWBSD.Percent * amt / 100)
              End If
            End If
          Next
        End If
        'End If
      Next
      Return ret
    End Function
    Public Function IsReferencedByPA() As Boolean
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetIsReferencedByPA" _
                , New SqlParameter("@entity_id", Me.Id) _
                , New SqlParameter("@entity_type", Me.EntityId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          If ds.Tables(0).Rows(0).IsNull(0) Then
            Return False
          End If
          Return CBool(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
      End Try
      Return False
    End Function
    'Public Function GetCurrentMatQtyForWBS(ByVal myWbs As WBS, ByVal matId As Integer) As Decimal
    '    Dim ret As Decimal = 0
    '    For Each item As SCItem In Me.ItemCollection
    '        If Not item.ItemType Is Nothing _
    '        AndAlso item.ItemType.Value = 42 _
    '        AndAlso item.Entity.Id = matId Then
    '            For Each grWBSD As WBSDistribute In item.WBSDistributeCollection
    '                If Not grWBSD.IsMarkup Then
    '                    Dim isOut As Boolean = False
    '                    Dim view As Integer = 7
    '                    Dim transferAmt As Decimal = item.Amount
    '                    Dim amt As Decimal = WBSDistribute.GetUsedQty(item.Qty, isOut, view, 3)
    '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
    '                        ret += (grWBSD.Percent * amt / 100)
    '                    End If
    '                End If
    '            Next
    '        End If
    '    Next
    '    Return ret
    'End Function
    'Public Function GetCurrentLabQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
    '    Dim ret As Decimal = 0
    '    For Each item As SCItem In Me.ItemCollection
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
    '                    Dim view As Integer = 7
    '                    Dim transferAmt As Decimal = item.Amount
    '                    Dim amt As Decimal = WBSDistribute.GetUsedQty(item.Qty, isOut, view, 3)
    '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
    '                        ret += (grWBSD.Percent * amt / 100)
    '                    End If
    '                End If
    '            Next
    '        End If
    '    Next
    '    Return ret
    'End Function
    'Public Function GetCurrentEqQtyForWBS(ByVal myWbs As WBS, ByVal name As String) As Decimal
    '    Dim ret As Decimal = 0
    '    For Each item As SCItem In Me.ItemCollection
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
    '                    Dim view As Integer = 7
    '                    Dim transferAmt As Decimal = item.Amount
    '                    Dim amt As Decimal = WBSDistribute.GetUsedQty(item.Qty, isOut, view, 3)
    '                    If grWBSD.WBS.IsDescendantOf(myWbs) Then
    '                        ret += (grWBSD.Percent * amt / 100)
    '                    End If
    '                End If
    '            Next
    '        End If
    '    Next
    '    Return ret
    'End Function
    Private Sub RecalculateAmount()
      Dim newUnitPrice As Decimal = 0
      For Each item As SCItem In Me.ItemCollection
        If item.Level = 0 Then
          newUnitPrice = 0
          'If Not item.NewChild AndAlso item.Level = 0 Then
          If item.Qty = 0 Then
            item.SetUnitPrice(0)
          Else
            item.SetUnitPrice((item.Mat + item.Lab + item.Eq) / item.Qty)
          End If
          'End If
        End If
      Next
    End Sub
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As SCItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
      Return ""
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

      'POOverBudgetOnlyWBSAllocate
      config = Configuration.GetConfig("POOverBudgetOnlyWBSAllocate")
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
        For Each item As SCItem In Me.ItemCollection
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
              ''สำหรับ WBS ที่เป็นแม่ตัวที่จัดสรรอยู่ =====<<

            Next
            If item.WBSDistributeCollection.GetSumPercent = 0 Then
              'สำหรับ Auto จัดสรร
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim tActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
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
        For Each item As SCItem In Me.ItemCollection
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            'สำหรับ Auto จัดสรร
            Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
            Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
            Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
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
          Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
          Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          Dim currentActual As Decimal = wbsd.Amount

          Dim tActual As Decimal = (wbsd.WBS.GetActualMat(Me, 6) + wbsd.WBS.GetActualLab(Me, 6) + wbsd.WBS.GetActualEq(Me, 6))
          Dim tcActual As Decimal = wbsd.WBS.GetThisDocActualFromDB(6, Me.Id, wbsd.CostCenter.Id)
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
        'Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
        'Dim totalCurrent As Decimal = Me.ItemCollection.Amount

        'If totalBudget < (totalActual + totalCurrent) Then
        '  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        'End If
      End If

      Return New SaveErrorException("0")
    End Function
    Dim hashAutoChild As Hashtable
    Private Function ValidateItem() As SaveErrorException
      Dim key1 As String = ""
      Dim key As String = ""
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim j As Integer = 0
      hashAutoChild = New Hashtable
      For Each sitem As SCItem In Me.ItemCollection
        If sitem.Level = 0 Then
          If Not sitem.IsHasChild(True) Then
            j += 1
            key1 = j.ToString
            hashAutoChild(key1) = sitem
          End If
        End If
      Next
      If hashAutoChild.Count > 0 Then
        If msgServ.AskQuestion("${res:Global.Question.NotChildItemAndWantToAutoCreateChild}") Then
          Return New SaveErrorException("2")
        Else
          Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
        End If
      End If
      For Each sitem As SCItem In Me.ItemCollection
        'If Not Me.Closing AndAlso Not sitem.NewChild Then

        If sitem.Level = 0 Then
          Dim m_value As Decimal = sitem.Mat + sitem.Lab + sitem.Eq
          If Configuration.Format(sitem.CostAmount, DigitConfig.Price) <> Configuration.Format(m_value, DigitConfig.Price) Then
            If msgServ.AskQuestion("${res:Global.Question.SCAmountNotEqualAllocateAndReCalUnitPrice}") Then
              Me.RecalculateAmount()
              Me.RefreshTaxBase()
              Me.m_realGross = Me.m_gross
              Me.RealTaxBase = Me.TaxBase
              Me.RealTaxAmount = Me.TaxAmount
            Else
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
            End If
            'Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
            'New String() {sitem.ItemDescription, Configuration.FormatToString(sitem.Amount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
          End If
          'If sitem.Amount <> sitem.ChildAmount Then
          '  Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverSCAmount}", _
          '  New String() {Configuration.FormatToString(sitem.Amount, DigitConfig.Price), Configuration.FormatToString(sitem.ChildAmount, DigitConfig.Price)})
          'End If
          If Configuration.Format(sitem.Mat, DigitConfig.Price) <> Configuration.Format(sitem.ChildMat, DigitConfig.Price) Then 'รายการ "{0}" Mat {1} ผลรวม Mat {2} รายการย่อยไม่เท่ากัน 
            Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverMat}", _
            New String() {sitem.ItemDescription, Configuration.FormatToString(sitem.Mat, DigitConfig.Price), Configuration.FormatToString(sitem.ChildMat, DigitConfig.Price)})
          End If
          If Configuration.Format(sitem.Lab, DigitConfig.Price) <> Configuration.Format(sitem.ChildLab, DigitConfig.Price) Then 'รายการ "{0}" Lab {1} ผลรวม Lab {2} รายการย่อยไม่เท่ากัน 
            Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverLab}", _
            New String() {sitem.ItemDescription, Configuration.FormatToString(sitem.Lab, DigitConfig.Price), Configuration.FormatToString(sitem.ChildLab, DigitConfig.Price)})
          End If
          If Configuration.Format(sitem.Eq, DigitConfig.Price) <> Configuration.Format(sitem.ChildEq, DigitConfig.Price) Then 'รายการ "{0}" Eq {1} ผลรวม Eq {2} รายการย่อยไม่เท่ากัน 
            Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverEq}", _
            New String() {sitem.ItemDescription, Configuration.FormatToString(sitem.Eq, DigitConfig.Price), Configuration.FormatToString(sitem.ChildEq, DigitConfig.Price)})
          End If

        Else
          Dim m_value As Decimal = sitem.Mat + sitem.Lab + sitem.Eq
          If Configuration.Format(sitem.CostAmount, DigitConfig.Price) <> Configuration.Format(m_value, DigitConfig.Price) Then
            Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
            New String() {sitem.ItemDescription, Configuration.FormatToString(sitem.Amount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
          End If
        End If

        'End If

        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In sitem.WBSDistributeCollection
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
            If Not Me.SubContractor Is Nothing Then
              If Me.SubContractor.Canceled Then
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.Director.Code})
              End If
            End If
          End If
          If Me.ItemCollection.Count = 0 Then   '.ItemTable.Childs.Count = 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
          End If
          Dim ValidateError As SaveErrorException = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          Else
            If CInt(ValidateError.Message) = 2 Then
              For Each sitem As SCItem In hashAutoChild.Values
                Dim nsitem As New SCItem
                nsitem.ItemType = New SCIItemType(88)
                nsitem.Entity = New BlankItem("")
                nsitem.Level = 1
                nsitem.ItemName = sitem.ItemName
                nsitem.Unit = sitem.Unit
                nsitem.SetQty(sitem.Qty)
                nsitem.SetUnitPrice(sitem.UnitPrice)
                'nsitem.SetMat(sitem.Mat)
                nsitem.SetLab(sitem.Lab)
                'nsitem.SetEq(sitem.Eq)
                nsitem.WBSDistributeCollection = sitem.WBSDistributeCollection
                AddHandler nsitem.WBSDistributeCollection.PropertyChanged, AddressOf nsitem.WBSChangedHandler

                Me.ItemCollection.Insert(Me.ItemCollection.IndexOf(sitem) + 1, nsitem)
              Next
            End If
          End If
          If Me.Closing Then
            Dim codeList As String = Me.GetUnClosedContract
            If codeList.Length > 0 Then
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCItem.VODRUnClosed}"), New String() {codeList, Me.Code})
            End If
          End If
          ''=============== Validate Over Budget ==================>>
          Dim ValidateOverBudgetError As SaveErrorException
          Dim config As Integer = CInt(Configuration.GetConfig("POOverBudget"))
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

        Me.RefreshTaxBase()
        Dim tmpBoq As BOQ = Me.CostCenter.Boq
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

        Dim oldcode As String
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
        Dim willClose As Boolean = False
        If Me.Closing Then
          willClose = True
        ElseIf Not Me.Closing AndAlso Not Me.Closed Then
          willClose = False
        End If

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.CostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startdate", Me.ValidDateOrDBNull(Me.StartDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_enddate", Me.ValidDateOrDBNull(Me.EndDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contactPerson", Me.ContactPerson))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Configuration.GetConfig("CompanyTaxRate"))) 'Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforetax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", willClose))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_subcontractor", ValidIdOrDBNull(Me.SubContractor)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_director", ValidIdOrDBNull(Me.Director)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_witholdingtax", Me.WitholdingTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_advancepay", Me.AdvancePay))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discrate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discamt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wr", ValidIdOrDBNull(Me.WR)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approveperson", ValidIdOrDBNull(Me.ApprovePerson)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvedate", Me.ValidDateOrDBNull(Me.ApproveDate)))
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
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
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

          'Sub Save Block =================================================
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
          'Sub Save Block =================================================

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

      Dim isCanceled As Integer = 0
      If Me.Status.Value = 0 Then
        isCanceled = 1
      End If
      trans.Commit()

      Dim trans2 As SqlTransaction = conn.BeginTransaction
      Try


        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "UpdateSCParent" _
                                , New SqlParameter("@id", Me.Id) _
                                , New SqlParameter("@docType", Me.EntityId))
        Me.DeleteRef(conn, trans2)
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_PRRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_PRRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'If Me.Status.Value = 0 Then
        '    Me.CancelRef(conn, trans)
        'End If
        If Not Me.WR Is Nothing AndAlso Me.WR.Originated Then
          SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "InsertUpdatereference" _
        , New SqlParameter("@entity_id", Me.WR.Id) _
        , New SqlParameter("@entity_type", Me.WR.EntityId) _
        , New SqlParameter("@refto_id", Me.Id) _
        , New SqlParameter("@refto_type", Me.EntityId) _
        , New SqlParameter("@refto_iscanceled", isCanceled) _
        )
        End If

        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "UpdateWBSReferencedFromSC", New SqlParameter("@refto_id", Me.Id))

        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")
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
        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, "", Me.CostCenter.Id, Me.SubContractor.Id)
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
      Dim autoCodeFormat As String = Me.Code  'Entity.GetAutoCodeFormat(Me.EntityId)
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

        Dim da As New SqlDataAdapter("Select * from scitem where sci_sc=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from sciwbs where sciw_sequence in (select sci_sequence from scitem where sci_sc=" & Me.Id & ")", conn)
        Dim daOld As New SqlDataAdapter("Select * from scolditem where scio_sequence in (select sci_sequence from scitem where sci_sc=" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From scitem Where sci_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "scitem")
        da.Fill(ds, "scitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "sciwbs")
        daWbs.Fill(ds, "sciwbs")
        ds.Relations.Add("sequence", ds.Tables!scitem.Columns!sci_sequence, ds.Tables!sciwbs.Columns!sciw_sequence)

        cmdBuilder = New SqlCommandBuilder(daOld)
        daOld.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daOld.FillSchema(ds, SchemaType.Mapped, "scolditem")
        daOld.Fill(ds, "scolditem")
        ds.Relations.Add("sequence2", ds.Tables!scitem.Columns!sci_sequence, ds.Tables!scolditem.Columns!scio_sequence)

        Dim dt As DataTable = ds.Tables("scitem")
        'Dim dc As DataColumn = dt.Columns!sci_sequence
        'dc.AutoIncrement = True
        'dc.AutoIncrementSeed = -1
        'dc.AutoIncrementStep = -1

        Dim dtWbs As DataTable = ds.Tables("sciwbs")
        Dim dtOld As DataTable = ds.Tables("scolditem")

        For Each row As DataRow In ds.Tables("scolditem").Rows
          row.Delete()
        Next

        For Each row As DataRow In ds.Tables("sciwbs").Rows
          row.Delete()
        Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As SCItem In Me.ItemCollection
            'If Not testItem.NewChild Then
            If testItem.Sequence = CInt(dr("sci_sequence")) Then
              found = True
              Exit For
            End If
            'End If
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
        'Dim dt As DataTable = ds.Tables("scitem")
        'For Each row As DataRow In ds.Tables("scitem").Rows
        '  row.Delete()
        'Next

        Dim i As Integer = 0   'Line Running

        With ds.Tables("scitem")
          For Each item As SCItem In Me.ItemCollection
            'If Not item.NewChild Then
            If Not item.ItemType Is Nothing Then
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
            End If

            i += 1

            '------------Checking if we have to add a new row or just update existing--------------------
            Dim dr As DataRow
            Dim drs As DataRow() = ds.Tables("scitem").Select("sci_sequence=" & item.Sequence)
            If drs.Length = 0 Then
              dr = .NewRow
              dr("sci_sequence") = (-1) * i
              .Rows.Add(dr)
            Else
              dr = drs(0)
            End If
            '------------End Checking--------------------

            'Dim dr As DataRow = .NewRow
            dr("sci_sc") = item.SC.Id
            dr("sci_lineNumber") = i
            dr("sci_level") = item.Level
            dr("sci_entity") = item.Entity.Id
            dr("sci_entityType") = item.ItemType.Value
            dr("sci_itemName") = item.EntityName
            dr("sci_unit") = item.Unit.Id
            dr("sci_qty") = item.Qty
            dr("sci_unitprice") = item.UnitPrice
            dr("sci_mat") = item.Mat
            dr("sci_lab") = item.Lab
            dr("sci_eq") = item.Eq
            dr("sci_amt") = item.Amount
            dr("sci_note") = item.Note
            dr("sci_unvatable") = item.Unvatable
            'dr("sci_parent") = item.ParentPath
            dr("sci_status") = Me.Status.Value
            dr("sci_unitCost") = item.UnitCost

            If Not WR Is Nothing Then
              dr("sci_wr") = item.WR.Id
            End If
            dr("sci_wrSequence") = item.WRISequence
            If Not item.WRIUnit Is Nothing Then
              dr("sci_wrUnit") = item.WRIUnit.Id
            End If
            dr("sci_wrQty") = item.WRIQty

            Dim dr2 As DataRow = dtOld.NewRow
            dr2("scio_sequence") = dr("sci_sequence")
            If Me.Closed AndAlso Not Me.Closing Then 'ยกเลิกปิด SC
              dr2("scio_qty") = item.OldQty
              dr2("scio_mat") = item.OldMat
              dr2("scio_lab") = item.OldLab
              dr2("scio_eq") = item.OldEq
              dr2("scio_amt") = item.OldAmount
            ElseIf Not Me.Closed AndAlso Me.Closing Then 'กำลังจะปิด SC
              dr2("scio_qty") = item.OldQty
              dr2("scio_mat") = item.OldMat
              dr2("scio_lab") = item.OldLab
              dr2("scio_eq") = item.OldEq
              dr2("scio_amt") = item.OldAmount
            ElseIf Not Me.Closed AndAlso Not Me.Closing Then 'ยังไม่เคยปิด และยังไม่ปิด หรือเคยเปิดมาแล้ว
              dr2("scio_qty") = item.Qty
              dr2("scio_mat") = item.Mat
              dr2("scio_lab") = item.Lab
              dr2("scio_eq") = item.Eq
              dr2("scio_amt") = item.Amount
            End If
            dtOld.Rows.Add(dr2)

            Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
            If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
              If item.ItemType.Value = 289 AndAlso item.GetChildAmount > 0 Then
                'ถ้าเป็นรายการ sc และ มีลูก ไม่ต้อง บันทึก wbs
              Else
                Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
                Dim currentSum As Decimal = wbsdColl.GetSumPercent

                For Each wbsd As WBSDistribute In wbsdColl
                  If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                    'ยังไม่เต็ม 100 แต่มีหัวอยู่
                    wbsd.Percent += (100 - currentSum)
                  End If
                  Dim bfTax As Decimal = 0
                  bfTax = item.CostAmount
                  wbsd.BaseCost = bfTax 'item.Amount
                  'wbsd.TransferBaseCost = bfTax 'item.Amount
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("sciw_sequence") = dr("sci_sequence")
                  childDr("sciw_wbs") = wbsd.WBS.Id
                  childDr("sciw_percent") = wbsd.Percent
                  childDr("sciw_ismarkup") = wbsd.IsMarkup
                  childDr("sciw_direction") = 0 'in
                  childDr("sciw_baseCost") = wbsd.BaseCost
                  childDr("sciw_amt") = wbsd.Amount
                  'childDr("sciw_toaccttype") = Me.ToAccountType.Value
                  If wbsd.CostCenter Is Nothing Then
                    wbsd.CostCenter = Me.CostCenter
                  End If
                  childDr("sciw_cc") = wbsd.CostCenter.Id
                  childDr("sciw_cbs") = wbsd.CBS.Id
                  'Add เข้า sciwbs
                  dtWbs.Rows.Add(childDr)
                Next

                currentSum = wbsdColl.GetSumPercent
                'ยังไม่เต็ม 100 และยังไม่มี root
                If currentSum < 100 Then
                  Try
                    Dim wbsd As New WBSDistribute
                    wbsd.WBS = rootWBS
                    wbsd.CostCenter = Me.CostCenter
                    wbsd.Percent = 100 - currentSum
                    Dim bfTax As Decimal = 0
                    bfTax = item.CostAmount
                    wbsd.BaseCost = bfTax 'item.Amount
                    'wbsd.TransferBaseCost = bfTax 'item.Amount
                    Dim childDr As DataRow = dtWbs.NewRow
                    childDr("sciw_sequence") = dr("sci_sequence")
                    childDr("sciw_wbs") = wbsd.WBS.Id
                    childDr("sciw_percent") = wbsd.Percent
                    childDr("sciw_ismarkup") = wbsd.IsMarkup
                    childDr("sciw_direction") = 0 'in
                    childDr("sciw_baseCost") = wbsd.BaseCost
                    childDr("sciw_amt") = wbsd.Amount
                    'childDr("sciw_toaccttype") = Me.ToAccountType.Value                               
                    childDr("sciw_cc") = wbsd.CostCenter.Id
                    childDr("sciw_cbs") = wbsd.CBS.Id

                    'Add เข้า sciwbs
                    dtWbs.Rows.Add(childDr)
                  Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                  End Try
                End If

              End If
            End If

            'End If
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
        Dim currentkey As Integer = CInt(e.Row("sciw_sequence")) '.GetParentRow("sequence")("sciw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!sciw_sequence = e.Row.GetParentRow("sequence")("sci_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!sciw_sequence = currentkey
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
        Dim currentkey As Integer = CInt(e.Row("scio_sequence")) '.GetParentRow("sequence")("sciw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!scio_sequence = e.Row.GetParentRow("sequence2")("sci_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!scio_sequence = currentkey
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
    Public Shared Function ApproveStoreData(ByVal Docid As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException

      'Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      'returnVal.ParameterName = "RETURN_VALUE"
      'returnVal.DbType = DbType.Int32
      'returnVal.Direction = ParameterDirection.ReturnValue
      'returnVal.SourceVersion = DataRowVersion.Current
      '' สร้าง ArrayList จาก Item ของ  SqlParameter ...
      'Dim paramArrayList As New ArrayList

      'paramArrayList.Add(returnVal)
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Docid))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvestoreperson", currentUserId))
      'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvestoredate", theTime))

      '' สร้าง SqlParameter จาก ArrayList ...
      'Dim sqlparams() As SqlParameter
      'sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      '' ให้ Transaction ควบคุมที่ส่วนของ Client เพราะอาจมีหลาย loop ได้
      'Try
      '    SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "ApproveStorePR", sqlparams)
      '    Return New SaveErrorException(returnVal.Value.ToString)
      'Catch ex As SqlException
      '    Return New SaveErrorException(ex.ToString)
      'Catch ex As Exception
      '    Return New SaveErrorException(ex.ToString)
      'End Try

    End Function
    'Public Function CloneGroupingItem() As SC
    '  Dim sc1 As New SC
    '  sc1.Id = Me.Id
    '  sc1.Group = True
    '  sc1.ItemCollection = New SCItemCollection(sc1)

    '  Return sc1
    'End Function

#End Region

#Region "RefreshTaxBase"
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxBase = 0

      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
        Return
      End If

      Dim sumAmountWithVat As Decimal = 0
      For Each item As SCItem In Me.ItemCollection
        'If Not item.NewChild Then
        If item.Level = 0 Then
          m_gross += item.Amount
          If Not item.Unvatable Then

            m_taxGross += item.Amount
            sumAmountWithVat += item.Amount
          End If
        End If
        'End If
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
        Return Configuration.Format(Me.Discount.Amount * Me.TaxGross / Me.Gross, DigitConfig.Price)
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

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Configuration.FormatToString(Me.CreditPeriod, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'ContactPerson
      dpi = New DocPrintingItem
      dpi.Mapping = "ContactPerson"
      dpi.Value = Me.ContactPerson
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Not Me.WR Is Nothing AndAlso Me.WR.Originated Then
        'WR Code Reference Doc
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocWrCode "
        dpi.Value = Me.WR.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'WR Date Reference
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocWrDate"
        dpi.Value = Me.WR.DocDate
        dpi.DataType = "System.DateTime"
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

        'SubContractorFax
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorFax"
        dpi.Value = Me.SubContractor.Fax.ToString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorPhone"
        dpi.Value = Me.SubContractor.Phone.ToString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorMobile
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorMobilePhone"
        dpi.Value = Me.SubContractor.Mobile.ToString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorEmail
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorEmail"
        dpi.Value = Me.SubContractor.EmailAddress.ToString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorHomePage
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorHomePage"
        dpi.Value = Me.SubContractor.HomePage.ToString
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

        'CostCenterAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAddress"
        dpi.Value = Me.CostCenter.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If


      If Not Me.Director Is Nothing AndAlso Me.Director.Originated Then
        'RequestorId
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorId"
        dpi.Value = Me.Director.Id
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.Person
        dpiColl.Add(dpi)

        'RequestorInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorInfo"
        dpi.Value = Me.Director.Code & ":" & Me.Director.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RequestorCode
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorCode"
        dpi.Value = Me.Director.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'RequestorName
        dpi = New DocPrintingItem
        dpi.Mapping = "RequestorName"
        dpi.Value = Me.Director.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'StartWorkingDate
      dpi = New DocPrintingItem
      dpi.Mapping = "StartWorkingDate"
      dpi.Value = Me.StartDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'EndWorkingDate
      dpi = New DocPrintingItem
      dpi.Mapping = "EndWorkingDate"
      dpi.Value = Me.EndDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "Retention"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      ''withholdingTax
      'dpi = New DocPrintingItem
      'dpi.Mapping = "withholdingTax"
      'dpi.Value = Me.WitholdingTax
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'AdvancePayAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvancePayAmount"
      dpi.Value = Configuration.FormatToString(Me.AdvancePay, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

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

      'RealGross
      dpi = New DocPrintingItem
      dpi.Mapping = "RealGross"
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

      'RealDiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "RealDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.RealDiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'RealBeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "RealBeforeTax"
      dpi.Value = Configuration.FormatToString(Me.RealBeforeTax, DigitConfig.Price)
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

      'RealTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "RealTaxAmount"
      dpi.Value = Configuration.FormatToString(Me.RealTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'RealAfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "RealAfterTax"
      dpi.Value = Configuration.FormatToString(Me.RealAfterTax, DigitConfig.Price)
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

      '--สำหรับแสดงรายการตามที่เคย print (ยอดเก่าก่อน closed sc)--
      dpiColl.AddRange(GetRealItemsPrintingEntries)
      dpiColl.AddRange(GetRealParentPrintingEntries)
      dpiColl.AddRange(GetRealChilPrintingEntries)

      '--สำหรับแสดงรายการตามหน้าจอ
      dpiColl.AddRange(GetItemsPrintingEntries)
      dpiColl.AddRange(GetParentPrintingEntries)
      dpiColl.AddRange(GetChilPrintingEntries)
      Return dpiColl
    End Function
    Public Function GetRealItemsPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font
      Dim indent As String = ""
      For Each item As SCItem In Me.ItemCollection
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
        dpi.Mapping = "RealItem.LineNumber"
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
          dpi.Value = indent & item.EntityName.Trim
        Else
          dpi.Value = indent & item.Entity.Name.Trim
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

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
        'End If

        'Item.Mat
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Mat"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
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
        dpi.DataType = "System.String"
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
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ReceivedAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ReceivedAmount"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'แบบไม่แสดงปริมาณ ราคา มูลค่า MAT LAB EQ Receipt ที่รายการสั่งจ้าง =========================================================================
        If item.Level = 1 Then

          'Item.ChildUnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildUnitCode"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Code
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildUnitName
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildUnitName"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Name
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildQty
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildQty"
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

          'Item.ChildUnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildUnitPrice"
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

          'Item.ChildAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildAmount"
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
          'End If

          'Item.ChildMat
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildMat"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildLab
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildLab"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldLab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildEq
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildEq"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldEq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildReceivedAmount"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

        End If
        'แบบไม่แสดงปริมาณ ราคา มูลค่า MAT LAB EQ Receipt ที่รายการสั่งจ้าง =========================================================================

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
    Public Function GetRealParentPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As SCItem In Me.ItemCollection
        If item.Level = 0 Then
          line += 1
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.LineNumber"
          dpi.Value = line
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Unit"
          dpi.Value = item.Unit.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Qty"
          If item.OldQty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldQty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Amount"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)
          'End If

          'ParentItem.Mat
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Mat"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Lab
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Lab"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldLab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Eq
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Eq"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldEq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'ParentItem.ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ReceivedAmount"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)
          'End If

          'ParentItem.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function
    Public Function GetRealChilPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As SCItem In Me.ItemCollection
        If item.Level = 1 Then
          line += 1
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.LineNumber"
          dpi.Value = line
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Unit"
          dpi.Value = item.Unit.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Qty"
          If item.OldQty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldQty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Amount"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)
          'End If

          'ChildItem.Mat
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Mat"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Lab
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Lab"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldLab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Eq
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Eq"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldEq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'ChildItem.ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.ReceivedAmount"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)
          'End If

          'ChildItem.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function

    Public Function GetItemsPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font
      Dim indent As String = ""
      For Each item As SCItem In Me.ItemCollection
        'If Not item.NewChild Then
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
        'End If

        'Item.Mat
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Mat"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
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
        dpi.DataType = "System.String"
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
          dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'แบบไม่แสดงปริมาณ ราคา มูลค่า MAT LAB EQ Receipt ที่รายการสั่งจ้าง =========================================================================
        If item.Level = 1 Then

          'Item.ChildUnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildUnitCode"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Code
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildUnitName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildUnitName"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Name
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildQty"
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

          'Item.ChildUnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildUnitPrice"
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

          'Item.ChildAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildAmount"
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
          'End If

          'Item.ChildMat
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildMat"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildLab
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildLab"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildEq
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildEq"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildReceivedAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

        End If
        'แบบไม่แสดงปริมาณ ราคา มูลค่า MAT LAB EQ Receipt ที่รายการสั่งจ้าง =========================================================================

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
    Public Function GetParentPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As SCItem In Me.ItemCollection
        If item.Level = 0 Then
          line += 1
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.LineNumber"
          dpi.Value = line
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Unit"
          dpi.Value = item.Unit.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Qty"
          If item.Qty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)
          'End If

          'ParentItem.Mat
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Mat"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Lab
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Lab"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.Eq
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Eq"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'ParentItem.ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ReceivedAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)
          'End If

          'ParentItem.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function
    Public Function GetChilPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As SCItem In Me.ItemCollection
        If item.Level = 1 Then
          line += 1
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.LineNumber"
          dpi.Value = line
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Unit"
          dpi.Value = item.Unit.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Qty"
          If item.Qty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)
          'End If

          'ChildItem.Mat
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Mat"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Lab
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Lab"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.Eq
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Eq"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'ChildItem.ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.ReceivedAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceiptAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)
          'End If

          'ChildItem.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          i += 1
        End If
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
            "select isnull(sc_closed,0) from sc where sc_id=" & Me.Id)
        If ds.Tables(0).Rows.Count > 0 Then
          If CInt(ds.Tables(0).Rows(0)(0)) = 1 OrElse CBool(ds.Tables(0).Rows(0)(0)) Then
            Return True
          End If
        End If
        Return False
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteSC", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")

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
      Me.Canceled = False
      Me.CancelPerson = New User
      Me.Closing = False
      Me.Closed = False
      Me.ClearReference()

      'Not Reference WR ========================
      Me.m_wr = New WR

      'Reference WR ========================
      'Dim hashWR As Hashtable
      'Dim key As Integer
      'Dim qty As Decimal
      'If Not Me.WR Is Nothing AndAlso Me.WR.Originated Then
      '  hashWR = Me.GetWROrderedQtyBySC
      'End If

      Dim wbsdummy As WBS
      For Each item As SCItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsdummy = wbsd.WBS
            wbsd.WBS = wbsdummy
          Next

          'Not Reference WR ========================
          item.WR = New WR
          item.WRISequence = 0
          item.SetWRIQty(0)
          item.SetWRIOrigingQty(0)
          item.WRIUnit = New Unit

          'Reference WR ========================
          'If Not item.WR Is Nothing AndAlso item.WR.Originated Then
          '  key = CInt(item.WRISequence)
          '  qty = CType(hashWR(key), WRItem).OrderedQty
          '  item.SetQty(qty)
          'End If

          item.ReceiptMat = 0
          item.ReceiptLab = 0
          item.ReceiptEq = 0
          item.ReceiptQty = 0
          item.ReceiptAmount = 0
        End If
      Next
      Return Me
    End Function
#End Region

#Region "IWBSAllocatable"
    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As SCItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As SCItem In Me.ItemCollection
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
    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get

      End Get
      Set(ByVal Value As CostCenter)

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

  Public Class SCForApprove
    Inherits SC
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName As String
      Get
        Return "SCForApprove"
      End Get
    End Property
  End Class

  Public Class SCForVO
    Inherits SC
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName As String
      Get
        Return "SCForVO"
      End Get
    End Property
  End Class

  Public Class SCForDR
    Inherits SC
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName As String
      Get
        Return "SCForDR"
      End Get
    End Property
  End Class

End Namespace
