Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class PaymentApplicationStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pma_status"
      End Get
    End Property
#End Region

  End Class
  Public Class TaxPoint
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "TaxPoint"
      End Get
    End Property
#End Region

  End Class
  Public Class PaymentApplication
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IHasIBillablePerson, IHasToCostCenter, IDuplicable, INewPrintableEntity

#Region "Members"
    Private m_cc As CostCenter 'CostCenter
    Private m_startDate As Date 'วันเริ่ม
    Private m_duration As Integer 'ระยะเวลา
    Private m_durationUnit As DateIntervalUnit 'หน่วย วัน/เดือน/ปี
    Private m_completionDate As Date 'กำหนดเสร็จ
    Private m_budget As Decimal 'ประมาณการต้นทุน
    Private m_contractAmount As Decimal 'มูลค่าตามสัญญา
    Private m_taxRate As Decimal 'อัตราภาษี
    Private m_taxType As TaxType 'ประเภทภาษี
    Private m_taxPoint As TaxPoint 'จุดรับรู้ภาษี
    Private m_status As PaymentApplicationStatus
    Private m_contractnumber As String
    Private m_dateactive As Date
    Private m_datefinish As Date

    Private m_manualBudget As Boolean

    Private m_itemCollection As MilestoneCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal Project As Project)
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , "GetPaymentApplication" _
      , New SqlParameter("@project_id", Project.Id))
      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
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
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_status = New PaymentApplicationStatus(-1)
        .m_cc = New CostCenter
        .m_durationUnit = New DateIntervalUnit(-1)
        .m_taxPoint = New TaxPoint(1)
        .m_itemCollection = New MilestoneCollection(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "costecenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "costecenter.cc_id") Then
            .m_cc = New CostCenter(dr, aliasPrefix & "costecenter.")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cc") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cc") Then
            .m_cc = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_cc")))
          End If
        End If

        If Not Me.Project Is Nothing Then
          Me.CompletionDate = Me.Project.CompletionDate
          Me.Duration = Me.Project.Duration
          Me.DurationUnit.Value = Me.Project.DurationUnit.Value
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_startDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_startDate") Then
          .m_startDate = CDate(dr(aliasPrefix & Me.Prefix & "_startDate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_completionDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_completionDate") Then
          .m_completionDate = CDate(dr(aliasPrefix & Me.Prefix & "_completionDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_duration") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_duration") Then
          .m_duration = CInt(dr(aliasPrefix & Me.Prefix & "_duration"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_durationUnit") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_durationUnit") Then
          .m_durationUnit = New DateIntervalUnit(CInt(dr(aliasPrefix & Me.Prefix & "_durationUnit")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_taxPoint") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_taxPoint") Then
          .m_taxPoint = New TaxPoint(CInt(dr(aliasPrefix & Me.Prefix & "_taxPoint")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_taxtype") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & Me.Prefix & "_taxtype")))
        End If

        If Not dr.IsNull(aliasPrefix & Me.Prefix & "_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & Me.Prefix & "_taxrate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_contractAmt") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_contractAmt") Then
          .m_contractAmount = CDec(dr(aliasPrefix & Me.Prefix & "_contractAmt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_budget") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_budget") Then
          .m_budget = CDec(dr(aliasPrefix & Me.Prefix & "_budget"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_manualbudget") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_manualbudget") Then
          .m_manualBudget = CBool(dr(aliasPrefix & Me.Prefix & "_manualbudget"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_advr") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_advr") Then
          .m_advance = CDec(dr(aliasPrefix & Me.Prefix & "_advr"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_retention") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_retention") Then
          .m_retention = CDec(dr(aliasPrefix & Me.Prefix & "_retention"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .m_status = New PaymentApplicationStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_contractnumber") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_contractnumber") Then
          .m_contractnumber = CStr(dr(aliasPrefix & Me.Prefix & "_contractnumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_contractdateactive") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_contractdateactive") Then
          .m_dateactive = CDate(dr(aliasPrefix & Me.Prefix & "_contractdateactive"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_contractdatefinish") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_contractdatefinish") Then
          .m_datefinish = CDate(dr(aliasPrefix & Me.Prefix & "_contractdatefinish"))
        End If

        'Private m_contractnumber As String
        'Private m_dateactive As Date
        'Private m_datefinish As Date


        m_itemCollection = New MilestoneCollection(Me)
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property ContractNumber As String
      Get
        Return m_contractnumber
      End Get
      Set(value As String)
        m_contractnumber = value
      End Set
    End Property
    Public Property ContractDateActive As Date
      Get
        Return m_dateactive
      End Get
      Set(value As Date)
        m_dateactive = value
      End Set
    End Property
    Public Property ContractDateFinish As Date
      Get
        Return m_datefinish
      End Get
      Set(value As Date)
        m_datefinish = value
      End Set
    End Property
    Public Property ItemCollection() As MilestoneCollection      Get        Return m_itemCollection      End Get      Set(ByVal Value As MilestoneCollection)        m_itemCollection = Value      End Set    End Property
    Public ReadOnly Property Boq() As BOQ      Get        Return Me.CostCenter.Boq      End Get    End Property    Public ReadOnly Property Project() As Project      Get        Return Me.CostCenter.Project      End Get    End Property    Public Property CostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value      End Set    End Property    Public ReadOnly Property Customer() As Customer      Get
        Return Me.CostCenter.Customer
      End Get
    End Property    Public Property ManualBudget() As Boolean      Get        Return m_manualBudget      End Get      Set(ByVal Value As Boolean)        m_manualBudget = Value      End Set    End Property    Public Property StartDate() As Date 'Implements ICheckPeriod.DocDate      Get        Return m_startDate      End Get      Set(ByVal Value As Date)        m_startDate = Value      End Set    End Property    Public Property Duration() As Integer      Get        Return m_duration      End Get      Set(ByVal Value As Integer)        m_duration = Value      End Set    End Property    Public Property DurationUnit() As DateIntervalUnit      Get        Return m_durationUnit      End Get      Set(ByVal Value As DateIntervalUnit)        m_durationUnit = Value      End Set    End Property    Public Property CompletionDate() As Date      Get        Return m_completionDate      End Get      Set(ByVal Value As Date)        m_completionDate = Value      End Set    End Property    Public Property Budget() As Decimal      Get        Return m_budget      End Get      Set(ByVal Value As Decimal)        m_budget = Value      End Set    End Property    Public Property ContractAmount() As Decimal      Get        Return m_contractAmount      End Get      Set(ByVal Value As Decimal)        m_contractAmount = Value        UpdateAdvance()        UpdateRetention()      End Set    End Property    Public Sub UpdateAdvance()      Dim advr As AdvanceMileStone
      If Me.Advance = 0 Then
        Me.m_itemCollection.DeleteAdvance()
      Else
        advr = Me.m_itemCollection.GetOrCreateAdvance
        If Not advr Is Nothing Then
          advr.MileStoneAmount = Me.Advance
        End If
      End If
    End Sub    Public Sub UpdateRetention()      Dim rtn As Retention
      If Me.Retention = 0 Then
        Me.m_itemCollection.DeleteRetention()
      Else
        rtn = Me.m_itemCollection.GetOrCreateRetention
        If Not rtn Is Nothing Then
          rtn.MileStoneAmount = Me.Retention
        End If
      End If
    End Sub    Public Property TaxPoint() As TaxPoint      Get        Return m_taxPoint      End Get      Set(ByVal Value As TaxPoint)        m_taxPoint = Value      End Set    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value      End Set    End Property    Public ReadOnly Property TaxBase() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0     '"ไม่มี"
            Return 0
          Case 1     '"แยก"
            Return Me.TotalAmountForTax '- DiscountAmount ใน total amount มีส่วนลดอยู่แล้ว
            'Return Me.ContractAmount - DiscountAmount   'ยอดนี้พอมีงานเพิ่มลด แล้วผิด
            'Return Me.TotalAmount
          Case 2     '"รวม"
            Return (Me.TotalAmountForTax) * (100 / (Me.TaxRate + 100))
            'Return (Me.TotalAmount - DiscountAmount) * (100 / (Me.TaxRate + 100)) ใน total amount มีส่วนลดอยู่แล้ว
            'Return (Me.ContractAmount - DiscountAmount) * (100 / (Me.TaxRate + 100)) 'ยอดนี้พอมีงานเพิ่มลด แล้วผิด
            'Return Me.TotalAmount * (100 / (Me.TaxRate + 100))
        End Select
      End Get
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Return (Me.TaxRate * Me.TaxBase) / 100      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0      '"ไม่มี"
            Return Me.TotalAmount
          Case 1     '"แยก"
            Return Me.TotalAmount
          Case 2     '"รวม"
            Return Me.TotalAmount - Me.TaxAmount
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax
          Case 1, 2 'แยก,'รวม
            Return Me.BeforeTax + Me.TaxAmount
        End Select      End Get    End Property    Public ReadOnly Property RealAfterTax() As Decimal      Get        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax
          Case 1, 2 'แยก,'รวม
            Return Me.TaxBase + Me.TaxAmount
        End Select      End Get    End Property    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Return Me.m_itemCollection.GetCanGetDiscountAmount
      End Get
    End Property    Public ReadOnly Property Penalty() As Decimal
      Get
        Return Me.m_itemCollection.GetPenaltyAmount
      End Get
    End Property    Public ReadOnly Property VoInc() As Decimal      Get
        'Dim coll As MilestoneCollection
        'coll = Me.m_itemCollection.GetVOIncCollection
        'If Me.TaxType.Value = 1 Then 'แยก Vat
        'Return coll.GetBeforeTax
        'Else
        'Return coll.GetAmount
        'End If
        Dim miAmt As Decimal = 0
        For Each mi As Milestone In Me.ItemCollection
          If TypeOf mi Is VariationOrderInc Then
            miAmt += mi.MileStoneAmount
          End If
        Next
        Return miAmt
      End Get
    End Property    Public ReadOnly Property VoDe() As Decimal      Get
        'Dim coll As MilestoneCollection
        'coll = Me.m_itemCollection.GetVODeCollection
        'If Me.TaxType.Value = 1 Then 'แยก Vat
        'Return coll.GetBeforeTax
        'Else
        'Return coll.GetAmount
        'End If
        Dim miAmt As Decimal = 0
        For Each mi As Milestone In Me.ItemCollection
          If TypeOf mi Is VariationOrderDe Then
            miAmt += mi.MileStoneAmount
          End If
        Next
        Return miAmt
      End Get
    End Property    Public ReadOnly Property AllMilestoneAmount() As Decimal      Get
        'ทุกอย่าง
        Return Me.m_itemCollection.GetCanGetAmount
      End Get
    End Property    Public ReadOnly Property TotalAmount() As Decimal
      Get
        Return Me.ContractAmount + Me.VoInc - Me.VoDe - Me.DiscountAmount - Me.Penalty
      End Get
    End Property    Public ReadOnly Property TotalAmountForTax() As Decimal
      Get
        Return Me.ContractAmount + Me.VoInc - Me.VoDe - Me.DiscountAmount 'ไม่มีค่าปรับด้วย
      End Get
    End Property    Public ReadOnly Property Amount() As Decimal      Get
        Return AllMilestoneAmount '- Me.DiscountAmount - Me.Penalty
      End Get
    End Property    Private m_advance As Decimal    Public Property Advance() As Decimal
      Get
        Return m_advance
      End Get
      Set(ByVal Value As Decimal)
        m_advance = Value
      End Set
    End Property    Private m_retention As Decimal    Public Property Retention() As Decimal      Get
        Return m_retention
      End Get
      Set(ByVal Value As Decimal)
        m_retention = Value
      End Set
    End Property    Private m_gross As Decimal
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
    End Property    Public Sub UpdateGross()
      'If Me.ItemTable Is Nothing OrElse Me.ItemTable.Rows.Count = 0 Then      '    m_gross = 0
      'Else
      '    Dim amt As Decimal = 0      '    For Each row As TreeRow In Me.ItemTable.Rows
      '        If Not row.IsNull("pmai_entityType") AndAlso IsNumeric(row("pmai_entityType")) Then
      '            If Not row.IsNull("Amount") AndAlso IsNumeric(row("Amount")) Then
      '                Select Case CInt(row("pmai_entityType"))
      '                    Case 78, 75
      '                        amt += CDec(row("Amount"))
      '                    Case 79
      '                        amt -= CDec(row("Amount"))
      '                End Select
      '            End If
      '        End If

      '    Next      '    m_gross = amt
      'End If
    End Sub    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, PaymentApplicationStatus)      End Set    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "paymentapplication"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "pma"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "paymentapplication"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PaymentApplication.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PaymentApplication"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PaymentApplication"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PaymentApplication.ListLabel}"
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
    Public Overrides ReadOnly Property UseSiteConnString() As Boolean
      Get
        Return True
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PaymentApplication")

      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Autogen", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))

      Dim dateCol As New DataColumn("DocDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("HandedDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("BillIssueDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      myDatatable.Columns.Add(New DataColumn("Advance", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Retention", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Discount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Penalty", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Status", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
      Return myDatatable
    End Function
    Public Function IncludeThisItem(ByVal item As Milestone) As Boolean
      If Not item.PaymentApplication Is Nothing AndAlso item.PaymentApplication.Id = Me.Id Then
        Return True
      End If
      Return False
    End Function
#End Region

#Region "Methods"
    Public Shared Function GetProjectContact(cc_id As Integer) As DataTable
      Dim dcc As New DataColumn("contactnumber", GetType(System.String)) 'เลขที่สัญญา
      Dim dca As New DataColumn("contactactivedate", GetType(System.DateTime)) 'วันที่เริ่มสัญญา
      Dim dcf As New DataColumn("contactfinishdate", GetType(System.DateTime)) 'วันที่สิ้นสุดสัญญา

      Dim dt As New DataTable
      dt.Columns.Add(dcc)
      dt.Columns.Add(dca)
      dt.Columns.Add(dcf)

      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetProjectContact", New SqlParameter("@cc_id", cc_id))
        If ds.Tables.Count > 0 Then
          For Each row As DataRow In ds.Tables(0).Rows
            Dim newrow As DataRow = dt.NewRow
            If row.Table.Columns.Contains("contactnumber") Then
              newrow("contactnumber") = row("contactnumber")
            End If
            If row.Table.Columns.Contains("contactactivedate") Then
              newrow("contactactivedate") = row("contactactivedate")
            End If
            If row.Table.Columns.Contains("contactfinishdate") Then
              newrow("contactfinishdate") = row("contactfinishdate")
            End If
            dt.Rows.Add(newrow)
          Next
        End If
      Catch ex As Exception
      End Try

      Return dt
    End Function
    Public Sub DistributeRetention()
      Dim roundBeforeSum As Boolean = True
      Dim coll As MilestoneCollection = Me.ItemCollection.GetMilestoneCollection
      If coll.Count = 0 Then
        Return
      End If
      Dim remain As Decimal = Me.Retention - Me.ItemCollection.GetHandedRetentionAmount
      Dim unhandedValue As Decimal = 0
      For Each item As Milestone In coll
        Dim itemAmount As Decimal = item.MileStoneAmount
        If roundBeforeSum Then
          itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
        End If
        If item.Status.Value < 3 Then
          unhandedValue += itemAmount
        End If
      Next
      For Each item As Milestone In coll
        If unhandedValue <> 0 AndAlso item.Status.Value < 3 Then
          item.Retention = Configuration.Format(remain * (item.MileStoneAmount / unhandedValue), DigitConfig.Price)
          item.ResetReal(True)
        End If
      Next
    End Sub
    Public Sub DistributeAdvance()
      Dim roundBeforeSum As Boolean = True
      Dim coll As MilestoneCollection = Me.ItemCollection.GetMilestoneCollection(Nothing, True)
      If coll.Count = 0 Then
        Return
      End If
      Dim remain As Decimal = Me.Advance - Me.ItemCollection.GetHandedAdvrAmount
      Dim unhandedValue As Decimal = 0
      For Each item As Milestone In coll
        Dim itemAmount As Decimal = item.MileStoneAmount
        If roundBeforeSum Then
          itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
        End If
        If item.Status.Value < 3 Then
          unhandedValue += itemAmount
        End If
      Next
      For Each item As Milestone In coll
        If unhandedValue <> 0 AndAlso item.Status.Value < 3 Then
          item.Advance = Configuration.Format(remain * (item.MileStoneAmount / unhandedValue), DigitConfig.Price)
          item.ResetReal(True)
        End If
      Next
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim tmpAdvr As Decimal = Configuration.Format(Me.ItemCollection.GetAdvrAmount, DigitConfig.Price)
        Dim tmpRealAdvr As Decimal = Configuration.Format(Me.Advance, DigitConfig.Price)
        Dim tmpMiAdvr As Decimal = Configuration.Format(Me.ItemCollection.GetMilestoneAdvrAmount, DigitConfig.Price)
        If tmpAdvr <> tmpRealAdvr Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.AdvanceToHandIsnotEqual}"), _
          New String() {Configuration.FormatToString(tmpAdvr, DigitConfig.Price) _
          , Configuration.FormatToString(tmpRealAdvr, DigitConfig.Price)})
        End If
        If tmpMiAdvr <> tmpAdvr Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.AdvanceToHandIsnotEqual}"), _
         New String() {Configuration.FormatToString(tmpAdvr, DigitConfig.Price) _
         , Configuration.FormatToString(tmpMiAdvr, DigitConfig.Price)})
        End If

        Dim tmpMiRtn As Decimal = Configuration.Format(Me.ItemCollection.GetMilestoneRetention, DigitConfig.Price)
        Dim tmpRtn As Decimal = Configuration.Format(Me.ItemCollection.GetRetentionAmount, DigitConfig.Price)
        Dim tmpRealRtn As Decimal = Configuration.Format(Me.Retention, DigitConfig.Price)
        If tmpRtn <> tmpRealRtn Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.RetentionToHandIsnotEqual}"), _
          New String() {Configuration.FormatToString(tmpRtn, DigitConfig.Price) _
          , Configuration.FormatToString(tmpRealRtn, DigitConfig.Price)})
        End If
        If tmpRtn <> tmpMiRtn Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.RetentionToHandIsnotEqual}"), _
          New String() {Configuration.FormatToString(tmpRtn, DigitConfig.Price) _
          , Configuration.FormatToString(tmpMiRtn, DigitConfig.Price)})
        End If

        'Dim tmpTotalAmount As Decimal = Configuration.Format(Me.TotalAmount, DigitConfig.Price) AfterTax
        'Dim tmpAmount As Decimal = Configuration.Format(Me.ItemCollection.GetCanGetAmount(Nothing, True), DigitConfig.Price)

        Dim tmpTotalAmount As Decimal = Configuration.Format(Me.AfterTax, DigitConfig.Price)
        Dim tmpAmount As Decimal = Configuration.Format(Me.ItemCollection.GetCanGetMilestoneAmountWithTax(Nothing, False), DigitConfig.Price)
        If tmpAmount <> tmpTotalAmount Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.AmountToHandIsnotEqual}"), _
          New String() {Configuration.FormatToString(tmpAmount, DigitConfig.Price) _
          , Configuration.FormatToString(tmpTotalAmount, DigitConfig.Price)})
        End If

        'Validate ราย milestone ไม่ให้ save ยอดติดลบได้
        For Each item As Milestone In Me.ItemCollection
          If item.Amount < 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.MileStoneAmountIsMinus} ") _
           & Configuration.FormatToString(item.Amount, DigitConfig.Price))
          End If
        Next



        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@pma_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_project", ValidIdOrDBNull(Me.Project)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startdate", ValidDateOrDBNull(Me.StartDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_completiondate", ValidDateOrDBNull(Me.CompletionDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duration", Me.Duration))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_durationUnit", Me.DurationUnit.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_budget", Me.Budget))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxPoint", Me.TaxPoint.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Configuration.Format(Me.TaxBase, DigitConfig.Price)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contractAmt", Me.ContractAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_totalamt", Me.TotalAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discamt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_penalty", Me.Penalty))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_VOinc", Me.VoInc))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_VOde", Me.VoDe))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_advr", Me.Advance))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.CostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_boq", ValidIdOrDBNull(Me.Boq)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_manualbudget", Me.ManualBudget))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contractnumber", Me.ContractNumber))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contractdateactive", ValidDateOrDBNull(Me.ContractDateActive)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contractdatefinish", ValidDateOrDBNull(Me.ContractDateFinish)))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          trans.Commit()
          Dim saveDetailError As SaveErrorException = SaveDetail(currentUserId)
          If Not IsNumeric(saveDetailError.Message) Then
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                Return saveDetailError
              Case Else
            End Select
          End If

          '--------------Remove Until We Meet again-----------------------
          'Dim saveWBSError As SaveErrorException = SaveWBS(currentUserId)
          'If Not IsNumeric(saveWBSError.Message) Then
          '  Return saveWBSError
          'Else
          '  Select Case CInt(saveWBSError.Message)
          '    Case -1, -2, -5
          '      Return saveWBSError
          '    Case Else
          '  End Select
          'End If
          '--------------Remove Until We Meet again-----------------------

          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Try
            trans.Rollback()
          Catch ex2 As Exception
          End Try
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Try
            trans.Rollback()
          Catch ex2 As Exception
          End Try
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal currentUserId As Integer) As SaveErrorException
      'ลบ milestone ที่เกินออก
      DeleteMilestones()
      Dim i As Integer
      For Each item As Milestone In Me.ItemCollection
        If item.Status.Value < 3 And item.Status.Value <> 0 Then
          Dim saveDetailError As SaveErrorException = item.Save(currentUserId)
          If Not IsNumeric(saveDetailError.Message) Then
            Return saveDetailError
          Else
            Select Case CInt(saveDetailError.Message)
              Case -1, -2, -5
                Return saveDetailError
              Case Else
            End Select
          End If
          i += 1
        End If
      Next
      Return New SaveErrorException(i.ToString)
    End Function
    Private Function DeleteMilestones() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("Error No id")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim excludeList As String = Me.ItemCollection.GetIdList()
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteMilestoneForPMA", _
                                  New SqlParameter("@pma_id", Me.Id), _
                                  New SqlParameter("@excludeList", excludeList) _
                                  )

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
    Private Function SaveWBS(ByVal currentUserId As Integer) As SaveErrorException
      If Me.Boq Is Nothing OrElse Not Me.Boq.Originated Then
        Return New SaveErrorException("0")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Dim ds As New DataSet
      Dim daWbs As SqlDataAdapter
      daWbs = New SqlDataAdapter("select * from wbs where wbs_boq=" & Me.Boq.Id & " order by wbs_level desc", conn)
      Dim cb As New SqlCommandBuilder(daWbs)
      daWbs.SelectCommand.Transaction = trans

      daWbs.DeleteCommand = cb.GetDeleteCommand
      daWbs.DeleteCommand.Transaction = trans

      daWbs.InsertCommand = cb.GetInsertCommand
      daWbs.InsertCommand.Transaction = trans

      daWbs.UpdateCommand = cb.GetUpdateCommand
      daWbs.UpdateCommand.Transaction = trans

      cb = Nothing

      daWbs.FillSchema(ds, SchemaType.Mapped, "wbs")
      daWbs.Fill(ds, "wbs")
      Dim dtWbs As DataTable = ds.Tables("wbs")
      Dim rowsToDelete As New ArrayList
      For Each dr As DataRow In dtWbs.Rows
        Dim found As Boolean = False
        For Each testWbs As WBS In Me.Boq.WBSCollection
          If testWbs.Id = CInt(dr("wbs_id")) Then
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
      Dim rootWbs As WBS = Me.Boq.WBSCollection.GetRoot
      If Not rootWbs Is Nothing Then
        Dim drWbs As DataRow
        Dim drs As DataRow() = dtWbs.Select("wbs_id=" & rootWbs.Id)
        If drs.Length = 0 Then
          drWbs = dtWbs.NewRow
        Else
          drWbs = drs(0)
        End If
        'drWbs("wbs_id") = ""
        drWbs("wbs_boq") = Me.Boq.Id
        drWbs("wbs_level") = 0
        drWbs("wbs_code") = rootWbs.Code
        drWbs("wbs_name") = rootWbs.Name
        drWbs("wbs_altName") = rootWbs.AlternateName
        drWbs("wbs_note") = rootWbs.Note
        drWbs("wbs_control") = DBNull.Value
        drWbs("wbs_path") = ""
        drWbs("wbs_linenumber") = 1
        If Not rootWbs.Milestone Is Nothing Then
          drWbs("wbs_milestone") = rootWbs.Milestone.Id
        Else
          drWbs("wbs_milestone") = DBNull.Value
        End If
        drWbs("wbs_state") = CInt(rootWbs.State)
        If rootWbs.Status.Value = -1 Then
          rootWbs.Status.Value = 2
        End If
        drWbs("wbs_status") = rootWbs.Status.Value
        If drs.Length = 0 Then
          dtWbs.Rows.Add(drWbs)
          Dim oldParId As Integer = rootWbs.Id
          rootWbs.Id = CInt(drWbs("wbs_id"))
          Me.Boq.WBSCollection.UpdateParentId(oldParId, rootWbs.Id)
          Me.Boq.ItemCollection.UpdateWbsId(oldParId, rootWbs.Id)
        End If
        Dim collForRoot As WBSCollection = rootWbs.Childs
        LoopWbs(collForRoot, 1, dtWbs)
        collForRoot = Nothing
      End If

      Dim daMarkup As SqlDataAdapter
      daMarkup = New SqlDataAdapter("select * from markup where markup_boq=" & Me.Boq.Id, conn)
      cb = New SqlCommandBuilder(daMarkup)
      daMarkup.SelectCommand.Transaction = trans

      daMarkup.DeleteCommand = cb.GetDeleteCommand
      daMarkup.DeleteCommand.Transaction = trans

      daMarkup.InsertCommand = cb.GetInsertCommand
      daMarkup.InsertCommand.Transaction = trans

      daMarkup.UpdateCommand = cb.GetUpdateCommand
      daMarkup.UpdateCommand.Transaction = trans

      cb = Nothing

      daMarkup.FillSchema(ds, SchemaType.Mapped, "markup")
      daMarkup.Fill(ds, "markup")

      Dim dtMarkup As DataTable = ds.Tables("markup")
      rowsToDelete = New ArrayList
      For Each dr As DataRow In dtMarkup.Rows
        Dim found As Boolean = False
        For Each testMarkup As Markup In Me.Boq.MarkupCollection
          If testMarkup.Id = CInt(dr("markup_id")) Then
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
      For Each mrkp As Markup In Me.Boq.MarkupCollection
        Dim drMarkup As DataRow
        Dim drs As DataRow() = dtMarkup.Select("markup_id=" & mrkp.Id)
        If drs.Length = 0 Then
          drMarkup = dtMarkup.NewRow
        Else
          drMarkup = drs(0)
        End If
        'drWbs("markup_id") = ""
        drMarkup("markup_boq") = Me.Boq.Id
        drMarkup("markup_name") = mrkp.Name
        drMarkup("markup_note") = mrkp.Note
        drMarkup("markup_type") = mrkp.Type.Value
        drMarkup("markup_condition") = mrkp.Condition.Value
        drMarkup("markup_amt") = mrkp.Amount
        drMarkup("markup_unit") = mrkp.Unit.Value
        drMarkup("markup_totalamt") = mrkp.TotalAmount
        drMarkup("markup_distributedamt") = mrkp.DistributedAmount
        drMarkup("markup_dmethod") = mrkp.DistributionMethod.Value
        If Not mrkp.Milestone Is Nothing Then
          drMarkup("markup_milestone") = mrkp.Milestone.Id
        Else
          drMarkup("markup_milestone") = DBNull.Value
        End If
        If mrkp.Status.Value = -1 Then
          mrkp.Status.Value = 2
        End If
        drMarkup("markup_status") = mrkp.Status.Value
        If drs.Length = 0 Then
          dtMarkup.Rows.Add(drMarkup)
          mrkp.Id = CInt(drMarkup("markup_id"))
        End If
      Next

      daWbs.Update(dtWbs.Select("", "", DataViewRowState.Deleted))
      daMarkup.Update(dtMarkup.Select("", "", DataViewRowState.Deleted))

      daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))
      daMarkup.Update(dtMarkup.Select("", "", DataViewRowState.ModifiedCurrent))

      daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
      daMarkup.Update(dtMarkup.Select("", "", DataViewRowState.Added))

      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "CleanWBs", New SqlParameter() {New SqlParameter("@boq_id", Me.Boq.Id)})
      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Private Sub LoopWbs(ByVal coll As WBSCollection, ByVal level As Integer, ByVal dtWbs As DataTable)
      Dim line As Integer = 1
      For Each myWbs As WBS In coll
        Dim drWbs As DataRow
        Dim drs As DataRow() = dtWbs.Select("wbs_id=" & myWbs.Id)
        If drs.Length = 0 Then
          drWbs = dtWbs.NewRow
        Else
          drWbs = drs(0)
        End If
        'drWbs("wbs_id") = ""
        drWbs("wbs_boq") = Me.Boq.Id
        drWbs("wbs_parid") = myWbs.Parent.Id
        drWbs("wbs_level") = level
        drWbs("wbs_code") = myWbs.Code
        drWbs("wbs_name") = myWbs.Name
        drWbs("wbs_altName") = myWbs.AlternateName
        drWbs("wbs_note") = myWbs.Note
        drWbs("wbs_control") = DBNull.Value
        drWbs("wbs_path") = ""
        drWbs("wbs_linenumber") = line
        If Not myWbs.Milestone Is Nothing Then
          drWbs("wbs_milestone") = myWbs.Milestone.Id
        Else
          drWbs("wbs_milestone") = DBNull.Value
        End If
        drWbs("wbs_state") = CInt(myWbs.State)
        If myWbs.Status.Value = -1 Then
          myWbs.Status.Value = 2
        End If
        drWbs("wbs_status") = myWbs.Status.Value
        If drs.Length = 0 Then
          dtWbs.Rows.Add(drWbs)
          Dim oldParId As Integer = myWbs.Id
          myWbs.Id = CInt(drWbs("wbs_id"))
          Me.Boq.WBSCollection.UpdateParentId(oldParId, myWbs.Id)
          Me.Boq.ItemCollection.UpdateWbsId(oldParId, myWbs.Id)
        End If
        line += 1
        Dim childs As WBSCollection = myWbs.Childs
        LoopWbs(childs, level + 1, dtWbs)
        childs = Nothing
      Next
    End Sub
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "PaymentApplication"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "PaymentApplication"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "pma_id"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterInfo
      If Me.CostCenter.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'RefBOQ
      dpi = New DocPrintingItem
      dpi.Mapping = "RefBOQ"
      dpi.Value = Me.Boq.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerInfo
      If Me.Customer.Valid AndAlso Not Me.Customer Is Nothing Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerInfo"
        dpi.Value = Me.Customer.Code & ":" & Me.Customer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCode"
        dpi.Value = Me.Customer.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerName"
        dpi.Value = Me.Customer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'AlternateName 
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerAlternateName"
        dpi.Value = Me.Customer.AlternateName
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Address
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerAddress"
        dpi.Value = Me.Customer.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'BillingAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerBillingAddress"
        dpi.Value = Me.Customer.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Phone
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerPhone"
        dpi.Value = Me.Customer.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Mobile
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerMobile"
        dpi.Value = Me.Customer.Mobile
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Mobile
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerAuthorizeAmount"
        dpi.Value = Configuration.FormatToString(Me.Customer.AuthorizeAmount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'StartDate
      dpi = New DocPrintingItem
      dpi.Mapping = "StartDate"
      dpi.Value = Me.StartDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'Period
      dpi = New DocPrintingItem
      dpi.Mapping = "Period"
      If Not Me.DurationUnit Is Nothing Then
        dpi.Value = Me.Duration & " " & Me.DurationUnit.Description
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DueComplete
      dpi = New DocPrintingItem
      dpi.Mapping = "DueComplete"
      dpi.Value = Me.CompletionDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'Budget
      dpi = New DocPrintingItem
      dpi.Mapping = "Budget"
      dpi.Value = Configuration.FormatToString(Me.Budget, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxPoint
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxPoint"
      If Not Me.TaxPoint Is Nothing Then
        dpi.Value = Me.TaxPoint.Description
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TaxType
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxType"
      If Not Me.TaxType Is Nothing Then
        dpi.Value = Me.TaxType.Description
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Advance
      dpi = New DocPrintingItem
      dpi.Mapping = "Advance"
      dpi.Value = Configuration.FormatToString(Me.Advance, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ContractAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractAmount"
      dpi.Value = Configuration.FormatToString(Me.ContractAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim myCount As New Hashtable
      Dim mySum As New Hashtable
      Dim n As Integer = 0
      Dim SumAmount As Decimal = 0
      For Each item As Milestone In Me.ItemCollection
        dpi = New DocPrintingItem
        dpi.Mapping = "pmai_pma"
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

        'Item.Type
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Type"
        dpi.Value = item.Type.Description
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DocDate"
        dpi.Value = item.DocDate.ToShortDateString
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

                'Item.HandedDate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.HandedDate"
                If Not (item.HandedDate = Date.MinValue) Then
                    dpi.Value = item.HandedDate.ToShortDateString
                Else
                    dpi.Value = ""
                End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.BillDate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.BillDate"
                If Not (item.BillIssueDate = Date.MinValue) Then
                    dpi.Value = item.BillIssueDate.ToShortDateString
                Else
                    dpi.Value = ""
                End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.ReceiveDate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.ReceiveDate"
                If Not (item.ReceiveDate = Date.MinValue) Then
                    dpi.Value = item.ReceiveDate.ToShortDateString
                Else
                    dpi.Value = ""
                End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Name
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Name"
                dpi.Value = item.Name
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Amount
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Amount"
                dpi.Value = Configuration.FormatToString(item.MileStoneAmount, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                If item.Type.Value = 79 Then
                    SumAmount -= item.MileStoneAmount
                Else
                    SumAmount += item.MileStoneAmount
                End If

                'Item.Advance
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Advance"
                dpi.Value = Configuration.FormatToString(item.Advance, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Retention
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Retention"
                dpi.Value = Configuration.FormatToString(item.Retention, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Penalty
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Penalty"
                dpi.Value = Configuration.FormatToString(item.Penalty, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Discount
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Discount"
                dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Final
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Final"
                dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
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

                'Item.Status
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Status"
                dpi.Value = Split(item.Status.ToString, ":")(1)
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                Dim myStatus As Integer
                myStatus = CInt(Split(item.Status.ToString, ":")(0))
                If myStatus = 3 OrElse myStatus = 4 OrElse myStatus = 5 Then '3 ส่งงวดงานแล้ว  / 4 วางบิลแล้ว / 5 รับเงินแล้ว
                    myCount(myStatus) = CInt(myCount(myStatus)) + 1
                    mySum(myStatus) = CDbl(mySum(myStatus)) + item.Amount
                End If

                n += 1
            Next

      'HandedCount
      dpi = New DocPrintingItem
      dpi.Mapping = "HandedCount"
      Dim myTemp As Integer = CInt(IIf(myCount(4) Is Nothing, "0", myCount(4))) + CInt(IIf(myCount(5) Is Nothing, "0", myCount(5)))
      dpi.Value = CInt(IIf(myCount(3) Is Nothing, "0", myCount(3))) + myTemp
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'HandedAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "HandedAmount"
      Dim myTemp1 As Decimal = CDec(IIf(mySum(3) Is Nothing, "0", mySum(3))) + CDec(IIf(mySum(4) Is Nothing, "0", mySum(4))) + CDec(IIf(mySum(5) Is Nothing, "0", mySum(5)))
      dpi.Value = Configuration.FormatToString(myTemp1, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'BillingCount
      dpi = New DocPrintingItem
      dpi.Mapping = "BillingCount"
      'myTemp = CInt(IIf(myCount(5) Is Nothing, "0", myCount(5)))
      dpi.Value = CInt(IIf(myCount(4) Is Nothing, "0", myCount(4))) ' + myTemp
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'BillingAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "BillingAmount"
      myTemp1 = CDec(IIf(mySum(4) Is Nothing, "0", mySum(4))) '+ CDec(IIf(mySum(5) Is Nothing, "0", mySum(5)))
      dpi.Value = Configuration.FormatToString(myTemp1, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'BilledCount
      dpi = New DocPrintingItem
      dpi.Mapping = "BilledCount"
      myTemp = CInt(IIf(myCount(5) Is Nothing, "0", myCount(5)))
      dpi.Value = CInt(IIf(myCount(4) Is Nothing, "0", myCount(4))) + myTemp
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'BilledAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "BilledAmount"
      myTemp1 = CDec(IIf(mySum(4) Is Nothing, "0", mySum(4))) + CDec(IIf(mySum(5) Is Nothing, "0", mySum(5)))
      dpi.Value = Configuration.FormatToString(myTemp1, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ReceivedCount
      dpi = New DocPrintingItem
      dpi.Mapping = "ReceivedCount"
      dpi.Value = IIf(myCount(5) Is Nothing, "0", myCount(5))
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ReceivedAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "ReceivedAmount"
      dpi.Value = IIf(mySum(5) Is Nothing, "0", Configuration.FormatToString(CDbl(mySum(5)), DigitConfig.Price))
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalCount
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalCount"
      dpi.Value = Me.ItemCollection.Count
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalDiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalPenaltyAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalPenaltyAmount"
      dpi.Value = Configuration.FormatToString(Me.Penalty, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DecAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "DecAmount"
      dpi.Value = Configuration.FormatToString(Me.VoDe, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'IncAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "IncAmount"
      dpi.Value = Configuration.FormatToString(Me.VoInc, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AllAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AllAmount"
      dpi.Value = Configuration.FormatToString(Me.TotalAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalName
      dpi = New DocPrintingItem
      dpi.Mapping = "Item.TotalName"
      dpi.Value = Me.ItemCollection.Count
      dpi.DataType = "System.String"
      dpi.Row = n + 1
      dpi.Table = "Item"
      dpiColl.Add(dpi)

      'TotalAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalAmount"
      dpi.Value = Configuration.FormatToString(SumAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalAdvance
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalAdvance"
      dpi.Value = Configuration.FormatToString(Me.Advance, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalRetention
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalRetention"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalPenalty
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalPenalty"
      dpi.Value = Configuration.FormatToString(Me.Penalty, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalDiscount
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalDiscount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalFinal
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalFinal"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetCanGetAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalReceievRetention //Sum ประเภทงวดงานที่เป็น Retention ที่รับเงินแล้ว
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalReceievRetention"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetTotalMilestoneReceiveAmount(Me.Id, 77), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalReceievAdvance //Sum ประเภทงวดงานที่เป็น Advance ที่รับเงินแล้ว
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalReceievAdvance"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetTotalMilestoneReceiveAmount(Me.Id, 86), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalDeductRetention //Sum ประเภทงวดงานที่เป็น งวดงาน มีการหัก Retention ที่รับเงินแล้ว
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalDeductRetention"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.TotalDeductRetention, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TotalDeductAdvance //Sum ประเภทงวดงานที่เป็น งวดงาน มีการหัก Advance ที่รับเงินแล้ว
      dpi = New DocPrintingItem
      dpi.Mapping = "TotalDeductAdvance"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.TotalDeductAdvance, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ContractNumber
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractNumber"
      dpi.Value = Me.ContractNumber
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ContractDateActive
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractDateActive"
      dpi.Value = Me.ContractDateActive.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ContractDateFinish
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractDateFinish"
      dpi.Value = Me.ContractDateFinish.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "IHasIBillablePerson"
    Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
      Get
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        'Nothing
      End Set
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
      format(0) = Me.CostCenter.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePaymentApplication}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePaymentApplication", New SqlParameter() {New SqlParameter("@pma_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.PaymentApplicationIsReferencedCannotBeDeleted}")
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

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.CostCenter = Value
      End Set
    End Property

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Status.Value = -1
      Me.CostCenter = New CostCenter
      For Each mi As Milestone In m_itemCollection
        mi.Id = 0
        mi.Status.Value = -1
        mi.BillIssueDate = Date.MinValue
        mi.HandedDate = Date.MinValue
      Next
      Return Me
    End Function
#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.RelationList.Add("general>pma_id>item>pmai_pma")

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pma_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RefBOQ", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerAlternateName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerBillingAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerMobile", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerAuthorizeAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("StartDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Period", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DueComplete", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Budget", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxPoint", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxType", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Advance", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ContractAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("HandedCount", "System.Integer"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("HandedAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillingCount", "System.Integer"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillingAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BilledCount", "System.Integer"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BilledAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivedCount", "System.Integer"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivedAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalCount", "System.Integer"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalDiscountAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalPenaltyAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DecAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("IncAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AllAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalAdvance", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalRetention", "System.Decimal"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalPenalty", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalDiscount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalFinal", "System.Decimal"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalReceievRetention", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalReceievAdvance", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalDeductRetention", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TotalDeductAdvance", "System.Decimal"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pmai_pma", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Type", "System.String", "Item"))
            dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))

            dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DocDate", "System.DateTime", "Item"))
            dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.HandedDate", "System.DateTime", "Item"))
            dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.BillDate", "System.DateTime", "Item"))
            dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ReceiveDate", "System.DateTime", "Item"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Advance", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Retention", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Penalty", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Discount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Final", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Status", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.TotalName", "System.String", "Item"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

  End Class

  Public Class PaymentApplicationEntityType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pmai_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Class PaymentApplicableEntityType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pmai_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Interface IPaymentApplicable
    Inherits IHasAmount, IHasName
  End Interface
End Namespace
