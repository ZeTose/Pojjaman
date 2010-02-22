Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Reflection
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class AdvanceMileStone
    Inherits Milestone

#Region "Members"

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.Type.Value = 86
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      Me.Type.Value = 86
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
      Me.Type.Value = 86
    End Sub
#End Region

#Region "Overrides Properties"
    Public Overrides Property MileStoneAmount() As Decimal
      Get
        'If Me.PaymentApplication Is Nothing Then
        '    Return MyBase.MileStoneAmount
        'End If
        'Return Me.PaymentApplication.Advance
        Return MyBase.MileStoneAmount
      End Get
      Set(ByVal Value As Decimal)
        MyBase.MileStoneAmount = Value
      End Set
    End Property
    Public Overrides Property Retention() As Decimal
      Get
        Return 0
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
    Public Overrides Property Penalty() As Decimal
      Get
        Return 0
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
    Public Overrides ReadOnly Property DiscountAmount() As Decimal
      Get
        Return 0
      End Get
    End Property
    Public Overrides Property Advance() As Decimal
      Get
        Return 0
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property FullClassName() As String
      Get
        Return Me.Namespace & "." & "AdvanceMileStone"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvanceMileStone.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.AdvanceMileStone"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.AdvanceMileStone"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.AdvanceMileStone.ListLabel}"
      End Get
    End Property
#End Region
  End Class
  Public Class Retention
    Inherits Milestone

#Region "Members"

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.Type.Value = 77
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      Me.Type.Value = 77
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
      Me.Type.Value = 77
    End Sub
#End Region

#Region "Overrides Properties"
    Public Overrides Property MileStoneAmount() As Decimal
      Get
        'If Me.PaymentApplication Is Nothing Then
        '    Return MyBase.MileStoneAmount
        'End If
        'Return Me.PaymentApplication.Retention
        Return MyBase.MileStoneAmount
      End Get
      Set(ByVal Value As Decimal)
        MyBase.MileStoneAmount = Value
      End Set
    End Property
    Public Overrides Property Retention() As Decimal
      Get
        Return 0
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
    Public Overrides Property Penalty() As Decimal
      Get
        Return 0
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
    Public Overrides ReadOnly Property DiscountAmount() As Decimal
      Get
        Return 0
      End Get
    End Property
    Public Overrides Property Advance() As Decimal
      Get
        Return 0
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property FullClassName() As String
      Get
        Return Me.Namespace & "." & "Retention"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Retention.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Retention"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Retention"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Retention.ListLabel}"
      End Get
    End Property
#End Region

  End Class
  Public Class VariationOrderDe
    Inherits Milestone

#Region "Members"

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.Type.Value = 79
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      Me.Type.Value = 79
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
      Me.Type.Value = 79
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property FullClassName() As String
      Get
        Return Me.Namespace & "." & "VariationOrderDe"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VariationOrderDe.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.VariationOrderDe"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.VariationOrderDe"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VariationOrderDe.ListLabel}"
      End Get
    End Property
#End Region

  End Class
  Public Class VariationOrderInc
    Inherits Milestone

#Region "Members"

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.Type.Value = 78
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      Me.Type.Value = 78
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
      Me.Type.Value = 78
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property FullClassName() As String
      Get
        Return Me.Namespace & "." & "VariationOrderInc"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VariationOrderInc.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.VariationOrderInc"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.VariationOrderInc"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VariationOrderInc.ListLabel}"
      End Get
    End Property
#End Region

  End Class
  Public Class Milestone
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IBillIssuable, IHasIBillablePerson, IHasToCostCenter

#Region "Members"
    Private m_name As String
    Private m_pmaId As Integer
    Private m_pma As PaymentApplication
    Private m_advance As Decimal
    Private m_retention As Decimal
    Private m_penalty As Decimal
    Private m_note As String
    Private m_discount As Discount
    Private m_taxRate As Decimal
    Private m_miAmount As Decimal
    Private m_status As MilestoneStatus

    Private m_docDate As Date
    Private m_handedDate As Date
    Private m_billIssueDate As Date

    Private m_itemTable As TreeTable
    Private m_type As MilestoneType
    Private m_receive As Receive

    Private m_realTaxBase As Decimal
    Private m_realMileStoneAmount As Decimal
    Private m_realTaxAmount As Decimal

    Private m_cost As Decimal
#End Region

#Region "Constructors"
    Private Sub Wire()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      Wire()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      Wire()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      Wire()
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      Wire()
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
      ReLoadItems()
      Wire()
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_status = New MilestoneStatus(-1)
        .m_type = New MilestoneType(75) 'Milestone
        m_docDate = Date.Now.Date
        m_receive = New Receive
        m_receive.RefDoc = Me
        m_receive.DocDate = Me.m_docDate
        .m_cost = Decimal.MinValue
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
          .m_docDate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_billissuedate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_billissuedate") Then
          .m_billIssueDate = CDate(dr(aliasPrefix & Me.Prefix & "_billissuedate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_handedDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_handedDate") Then
          .m_handedDate = CDate(dr(aliasPrefix & Me.Prefix & "_handedDate"))
        End If

        ' Name
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
          .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
        End If
        ' Note
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If
        'Discount Rate
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_discrate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & Me.Prefix & "_discrate")))
        End If
        ' Milestone Status
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .m_status = New MilestoneStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If
        ' Milestone Tax Rate
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_taxrate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & Me.Prefix & "_taxrate"))
        End If
        ' Milestone Advance
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_advr") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_advr") Then
          .m_advance = CDec(dr(aliasPrefix & Me.Prefix & "_advr"))
        End If
        ' Milestone Retention
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_retention") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_retention") Then
          .m_retention = CDec(dr(aliasPrefix & Me.Prefix & "_retention"))
        End If
        ' Milestone Penalty
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_penalty") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_penalty") Then
          .m_penalty = CDec(dr(aliasPrefix & Me.Prefix & "_penalty"))
        End If

        ' Milestone Amount
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_realamt") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_realamt") Then
          .m_miAmount = CDec(dr(aliasPrefix & Me.Prefix & "_realamt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_type") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_type") Then
          .m_type.Value = CInt(dr(aliasPrefix & Me.Prefix & "_type"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_pma") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_pma") Then
          .m_pmaId = CInt(dr(aliasPrefix & Me.Prefix & "_pma"))
        End If

        ' Milestone Cost
        If dr.Table.Columns.Contains(aliasPrefix & "billii_cost") AndAlso Not dr.IsNull(aliasPrefix & "billii_cost") Then
          .m_cost = CDec(dr(aliasPrefix & "billii_cost"))
        End If

        '--------------------REAL-------------------------
        ' TaxBase
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & Me.Prefix & "_taxbase"))
        End If

        ' MileStoneAmount
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_realrealamt") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_realrealamt") Then
          .m_realMileStoneAmount = CDec(dr(aliasPrefix & Me.Prefix & "_realrealamt"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & Me.Prefix & "_taxamt"))
        End If
        '--------------------END REAL-------------------------
      End With
    End Sub

#End Region

#Region "Properties"
    '--------------------REAL-------------------------
    Public Property RealMileStoneAmount() As Decimal
      Get
        'HACK
        If m_realMileStoneAmount = 0 AndAlso m_miAmount <> 0 Then
          m_realMileStoneAmount = m_miAmount
        End If
        Return m_realMileStoneAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realMileStoneAmount = Value
      End Set
    End Property
    Public Property RealTaxAmount() As Decimal
      Get
        ''HACK
        'If m_realTaxAmount = 0 AndAlso TaxAmount <> 0 Then
        '  m_realTaxAmount = TaxAmount
        'End If
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
      End Set
    End Property
    Public Property RealTaxBase() As Decimal      Get        ''HACK
        'If m_realTaxBase = 0 AndAlso TaxBase <> 0 Then
        '  m_realTaxBase = TaxBase
        'End If        Return m_realTaxBase      End Get      Set(ByVal Value As Decimal)        m_realTaxBase = Value      End Set    End Property
    '--------------------END REAL-------------------------

    Public Property PMAId() As Integer
      Get
        Return m_pmaId
      End Get
      Set(ByVal Value As Integer)
        m_pmaId = Value
      End Set
    End Property
    Public ReadOnly Property Linenumber() As Integer      Get        If m_pma Is Nothing Then          Return 0
        End If        Return m_pma.ItemCollection.IndexOf(Me) + 1      End Get    End Property
    Public Property PaymentApplication() As PaymentApplication      Get        Return m_pma      End Get      Set(ByVal Value As PaymentApplication)        m_pma = Value      End Set    End Property
    Public Property Type() As MilestoneType      Get        Return m_type      End Get      Set(ByVal Value As MilestoneType)        m_type = Value      End Set    End Property
    Public Property Cost() As Decimal
      Get
        Return m_cost
      End Get
      Set(ByVal Value As Decimal)
        'Default Value = Decimal.MinValue --> Beware
        m_cost = Value
      End Set
    End Property
    Public Property DocDate() As Date      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property
    Public Property HandedDate() As Date      Get        Return m_handedDate      End Get      Set(ByVal Value As Date)        m_handedDate = Value      End Set    End Property    Public Property BillIssueDate() As Date      Get        Return m_billIssueDate      End Get      Set(ByVal Value As Date)        m_billIssueDate = Value      End Set    End Property
    Public Property Name() As String Implements IHasName.Name
      Get
        Return m_name
      End Get
      Set(ByVal Value As String)
        m_name = Value
      End Set
    End Property
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property    Public ReadOnly Property Customer() As Customer      Get        If m_pma Is Nothing Then          Return Nothing
        End If        Return Me.CostCenter.Customer      End Get    End Property    Public ReadOnly Property CostCenter() As CostCenter
      Get
        If m_pma Is Nothing Then
          Return Nothing
        End If
        Return m_pma.CostCenter
      End Get
    End Property    Public Overridable Property Retention() As Decimal
      Get
        Return m_retention
      End Get
      Set(ByVal Value As Decimal)
        m_retention = Value
      End Set
    End Property    Public Overridable Property Penalty() As Decimal
      Get
        Return m_penalty
      End Get
      Set(ByVal Value As Decimal)
        m_penalty = Value
      End Set
    End Property    Public Overridable Property Advance() As Decimal
      Get
        Return m_advance
      End Get
      Set(ByVal Value As Decimal)
        m_advance = Value
      End Set
    End Property    Public Overridable ReadOnly Property AdvancePlusRetention() As Decimal
      Get
        Return Advance + Retention
      End Get
    End Property
    Public Property Note() As String Implements IReceivable.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Private m_gross As Decimal    Public ReadOnly Property Gross() As Decimal      Get        Return m_gross      End Get    End Property    Public Overridable Property MileStoneAmount() As Decimal
      Get
        Return m_miAmount
      End Get
      Set(ByVal Value As Decimal)
        m_miAmount = Value
      End Set
    End Property    Public Overridable Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Overridable ReadOnly Property DiscountAmount() As Decimal      Get        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If        Select Case Me.TaxType.Value
          Case 0, 1 '"ไม่มี",'"แยก"
            Me.Discount.AmountBeforeDiscount = Me.RealMileStoneAmount - sign * Me.AdvancePlusRetention          Case 2 '"รวม"
            Me.Discount.AmountBeforeDiscount = (Me.RealMileStoneAmount - sign * Me.Advance) / ((100 + Me.TaxRate) / 100) - sign * Me.Retention
        End Select        Return Me.Discount.Amount      End Get    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property#Region "Calculated"    Public Overridable ReadOnly Property CalculatedDiscountAmount() As Decimal      'ค่าที่ไม่ได้มาจากการป้อน --> มาจาก MilestoneAmount      Get        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If        Dim discount As New discount(Me.Discount.Rate)        Select Case Me.TaxType.Value
          Case 0, 1 '"ไม่มี",'"แยก"
            discount.AmountBeforeDiscount = Me.MileStoneAmount - sign * Me.AdvancePlusRetention          Case 2 '"รวม"
            discount.AmountBeforeDiscount = (Me.MileStoneAmount - sign * Me.Advance) / ((100 + Me.TaxRate) / 100) - sign * Me.Retention
        End Select        Return discount.Amount      End Get    End Property    Public ReadOnly Property CalculatedTaxBase() As Decimal      'ค่าที่ไม่ได้มาจากการป้อน --> มาจาก MilestoneAmount      Get
        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            Return CDec(Me.MileStoneAmount - sign * (Me.CalculatedDiscountAmount + Me.Penalty + Me.Advance))
          Case 2 '"รวม"
            Return CDec((Me.MileStoneAmount - sign * (Me.Penalty + Me.Advance)) / ((100 + Me.TaxRate) / 100) - sign * Me.CalculatedDiscountAmount)
        End Select
      End Get
    End Property
    Public ReadOnly Property CalculatedTaxAmount() As Decimal      Get        Return (Me.TaxRate * Me.CalculatedTaxBase) / 100      End Get    End Property    Public ReadOnly Property CalculatedBeforeTax() As Decimal      Get        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.MileStoneAmount - sign * (Me.CalculatedDiscountAmount + Me.AdvancePlusRetention + Me.Penalty)
          Case 1 '"แยก"
            Return Me.MileStoneAmount - sign * (Me.CalculatedDiscountAmount + Me.AdvancePlusRetention + Me.Penalty)
          Case 2 '"รวม"
            Return Me.CalculatedTaxBase - Me.Retention
        End Select      End Get    End Property    Public ReadOnly Property CalculatedAfterTax() As Decimal      Get        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.CalculatedBeforeTax
          Case 1, 2 '"แยก"
            Return Me.CalculatedBeforeTax + Me.CalculatedTaxAmount
        End Select      End Get    End Property
#End Region    Public ReadOnly Property TaxBase() As Decimal
      Get
        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            Return CDec(Me.RealMileStoneAmount - sign * (Me.DiscountAmount + Me.Penalty + Me.Advance))
          Case 2 '"รวม"
            Return CDec((Me.RealMileStoneAmount - sign * (Me.Penalty + Me.Advance)) / ((100 + Me.TaxRate) / 100) - sign * Me.DiscountAmount)
        End Select
      End Get
    End Property    Public ReadOnly Property OtherTaxBase() As Decimal 'TaxBase ที่ลบออกจาก milestone
      Get
        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If
        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return 0
          Case 1 '"แยก"
            Return CDec(-sign * (Me.DiscountAmount + Me.Penalty + Me.Advance))
          Case 2 '"รวม"
            Return CDec((-sign * (Me.Penalty + Me.Advance)) / ((100 + Me.TaxRate) / 100) - sign * Me.DiscountAmount)
        End Select
      End Get
    End Property    Public ReadOnly Property PseudoOtherTaxBase() As Decimal 'TaxBase ที่ลบออกจาก milestone
      Get
        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If
        Select Case Me.TaxType.Value
          Case 0, 1 '"ไม่มี",'"แยก"
            Return CDec(-sign * (Me.DiscountAmount + Me.Penalty + Me.Advance))
          Case 2 '"รวม"
            Return CDec((-sign * (Me.Penalty + Me.Advance)) / ((100 + Me.TaxRate) / 100) - sign * Me.DiscountAmount)
        End Select
      End Get
    End Property    Public ReadOnly Property TaxType() As TaxType      Get        If Me.m_pma Is Nothing Then          Return New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        End If        If Me.Type.Value = 77 Then          'Retention ไม่มี Vat          Return New TaxType(0)        Else
          Return Me.m_pma.TaxType        End If      End Get    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Return (Me.TaxRate * Me.RealTaxBase) / 100      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.RealMileStoneAmount - sign * (Me.DiscountAmount + Me.AdvancePlusRetention + Me.Penalty)
          Case 1 '"แยก"
            Return Me.RealMileStoneAmount - sign * (Me.DiscountAmount + Me.AdvancePlusRetention + Me.Penalty)
          Case 2 '"รวม"
            Return Me.RealTaxBase '- Me.Retention
            'Me.MileStoneAmount - sign * (Me.DiscountAmount + Me.AdvancePlusRetention + Me.Penalty) - Me.TaxAmount
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        Dim sign As Integer = 1        If Me.Type.Value = 79 Then          sign = -1
        End If        Select Case Me.TaxType.Value
          Case 0 '"ไม่มี"
            Return Me.BeforeTax
          Case 1, 2 '"แยก"
            Return Me.BeforeTax + Me.RealTaxAmount
        End Select      End Get    End Property    Public ReadOnly Property TaxPoint() As TaxPoint      Get        If Me.m_pma Is Nothing Then          Return New TaxPoint(1)
        End If        Return Me.m_pma.TaxPoint      End Get    End Property    Public Property Amount() As Decimal Implements IHasAmount.Amount
      Get
        Return AfterTax
      End Get
      Set(ByVal Value As Decimal)

      End Set
    End Property    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, MilestoneStatus)
      End Set
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Milestone"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "Milestone"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Milestone.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Milestone"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Milestone"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Milestone.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "milestone"
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
      Dim myDatatable As New TreeTable("Milestone")
      myDatatable.Columns.Add(New DataColumn("milestonei_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("milestonei_desc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("milestonei_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("milestonei_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("milestonei_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("milestonei_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("milestonei_note", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetSelectionListDatatableForCustomer(ByVal ParamArray filters() As Filter) As TreeTable
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim dt As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetMilestoneListForCustomer", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("BillIssueItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("cc_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("milestone_id", GetType(Integer)))
      For Each tableRow As DataRow In dt.Rows
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("ccinfo")
        row("cc_id") = tableRow("cc_id")
        row("Date") = tableRow("milestone_docdate")
        row("Entity") = tableRow("milestone_code")
        row("milestone_id") = tableRow("milestone_id")
        If Not tableRow.IsNull("milestone_aftertax") Then
          row("Amount") = Configuration.FormatToString(CDec(tableRow("milestone_aftertax")), DigitConfig.Price) 'tableRow("billa_gross")
        End If
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
    Public Shared Function GetSelectionListDatatable(ByVal ParamArray filters() As Filter) As TreeTable

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      Dim receives_id As Integer
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 2)
        For i As Integer = 0 To filters.Length - 2
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
        receives_id = CInt(filters(filters.Length - 1).Value)
      End If
      Dim dt As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetBillIssueItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("BillIssueItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("salebilli_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DueDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDueDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("CostCenterName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stock_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stock_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stock_type", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stock_beforetax", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("stock_taxbase", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("stock_aftertax", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("salebillii_billedamt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("salebillii_unreceivedamt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("salebillii_linenumber", GetType(Integer)))
      For Each tableRow As DataRow In dt.Rows
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("billi_code")
        row("salebilli_id") = tableRow("billii_billi")
        row("Linenumber") = tableRow("billii_linenumber")
        row("Date") = tableRow("billi_docdate")
        row("DueDate") = tableRow("billi_docdate")
        row("Entity") = tableRow("milestone_code")
        row("stock_id") = tableRow("milestone_id")
        row("stock_code") = tableRow("milestone_code")
        row("stock_type") = tableRow("milestone_type")
        row("CostCenterName") = tableRow("costcentername")
        If Not tableRow.IsNull("milestone_aftertax") Then
          row("Amount") = Configuration.FormatToString(CDec(tableRow("milestone_aftertax")), DigitConfig.Price) 'tableRow("billa_gross")
        End If
        row("stock_id") = tableRow("milestone_id")
        row("stock_code") = tableRow("milestone_code")
        row("stock_type") = tableRow("milestone_type")
        row("stock_beforetax") = tableRow("milestone_beforetax")
        row("stock_aftertax") = tableRow("milestone_aftertax")
        'hack
        Dim receivable As New SaleBillIssueItem
        receivable.Id = CInt(tableRow("milestone_id"))
        receivable.ParentId = CInt(tableRow("billii_billi"))
        row("salebillii_unreceivedamt") = Configuration.FormatToString(receivable.GetRemainingAmountReceiveSelection(receives_id), DigitConfig.Price)
        row("salebillii_billedamt") = row("Amount")
        row("salebillii_linenumber") = tableRow("billii_linenumber")
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function

#End Region

#Region "Methods"
    Public Sub ResetReal()
      'HACK: RealMileStoneAmount ต้องอยู่อันแรกนะจ๊ะ
      Me.RealMileStoneAmount = Me.MileStoneAmount
      Me.RealTaxBase = Me.TaxBase
      Me.RealTaxAmount = Me.TaxAmount
    End Sub
    Public Sub CopyTo(ByVal newMi As Milestone)
      newMi.Advance = Me.Advance
      newMi.Amount = Me.Amount
      newMi.AutoGen = Me.AutoGen
      newMi.Code = Me.Code
      newMi.Discount = Me.Discount
      newMi.DocDate = Me.DocDate
      newMi.Id = Me.Id
      newMi.ItemTable = Me.ItemTable
      newMi.MileStoneAmount = Me.MileStoneAmount
      newMi.Name = Me.Name
      newMi.Note = Me.Note
      newMi.PaymentApplication = Me.PaymentApplication
      newMi.PMAId = Me.PMAId
      newMi.Penalty = Me.Penalty
      newMi.Retention = Me.Retention
      newMi.TaxRate = Me.TaxRate
      newMi.Receive = Me.Receive
      newMi.RealTaxBase = Me.RealTaxBase
      newMi.RealTaxAmount = Me.RealTaxAmount
      newMi.RealMileStoneAmount = Me.RealMileStoneAmount
    End Sub
    Public Function Clone(ByVal type As MilestoneType) As Milestone
      If type Is Nothing Then
        Return Nothing
      End If
      Dim newMi As Milestone
      Select Case type.Value
        Case 75 'Milestone
          newMi = New Milestone
          Me.CopyTo(newMi)
        Case 77 'Retention
          newMi = New Retention
          Me.CopyTo(newMi)
        Case 78 'VariationOrderInc
          newMi = New VariationOrderInc
          Me.CopyTo(newMi)
        Case 79 'VariationOrderDe
          newMi = New VariationOrderDe
          Me.CopyTo(newMi)
        Case 86 'AdvanceMileStone
          newMi = New AdvanceMileStone
          Me.CopyTo(newMi)
      End Select
      Return newMi
    End Function
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer)
      Me.Id = oldid
      Me.m_receive.Id = oldreceive
    End Sub
    Public Function UnHand(ByVal currentUserId As Integer) As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        If Not SqlHelper.CheckObjectExist("UnHandMilestone") Then
          Return New SaveErrorException("${res:Global.Error.NoSprocInDB}", "UnHandMilestone")
        End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UnHandMilestone", New SqlParameter() {New SqlParameter("@milestone_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
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
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
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
          Me.Status = New MilestoneStatus(2)
        End If
        Me.RefreshGross()

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", Me.ValidIdOrDBNull(Me.CostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_pma", Me.ValidIdOrDBNull(Me.PaymentApplication)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_linenumber", Me.Linenumber))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_handeddate", Me.ValidDateOrDBNull(Me.HandedDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.Type.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cust", Me.ValidIdOrDBNull(Me.Customer)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_realamt", Me.MileStoneAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_realrealamt", Me.RealMileStoneAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_advr", Me.Advance))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_penalty", Me.Penalty))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_advrRetention", Me.AdvancePlusRetention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discrate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discamt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforetax", Configuration.Format(Me.BeforeTax, DigitConfig.Price)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Configuration.Format(Me.RealTaxBase, DigitConfig.Price))) 'Me.TaxBase
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Configuration.GetConfig("CompanyTaxRate"))) 'Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxPoint", Me.TaxPoint.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Configuration.Format(Me.RealTaxAmount, DigitConfig.Price))) 'Me.TaxAmount
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Configuration.Format(Me.AfterTax, DigitConfig.Price)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()


        Dim oldid As Integer = Me.Id
        Dim oldreceive As Integer = Me.m_receive.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          SaveDetail(Me.Id, conn, trans)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          m_receive = New Receive(Me)
          Dim savePaymentError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
          If Not IsNumeric(savePaymentError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldreceive)
            Return savePaymentError
          Else
            Select Case CInt(savePaymentError.Message)
              Case -1, -2
                trans.Rollback()
                Me.ResetID(oldid, oldreceive)
                Return savePaymentError
              Case Else
            End Select
          End If
          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldreceive)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldreceive)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

      Dim da As New SqlDataAdapter("Select * from milestoneitem where milestonei_milestone=" & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "milestoneitem")

      Dim dbCount As Integer = ds.Tables("milestoneitem").Rows.Count
      Dim itemCount As Integer = Me.ItemTable.Childs.Count
      Dim i As Integer = 0
      With ds.Tables("milestoneitem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For n As Integer = 0 To Me.MaxRowIndex
          Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(n), TreeRow)
          If ValidateRow(itemRow) Then
            Dim item As New MilestoneItem
            item.CopyFromDataRow(itemRow)
            i += 1
            Dim dr As DataRow = .NewRow
            dr("milestonei_milestone") = Me.Id
            dr("milestonei_linenumber") = i
            dr("milestonei_desc") = item.Description
            dr("milestonei_unit") = item.Unit.Id
            dr("milestonei_qty") = item.Qty
            dr("milestonei_unitprice") = item.UnitPrice
            dr("milestonei_amt") = item.Amount
            dr("milestonei_note") = item.Note

            .Rows.Add(dr)
          End If
        Next
      End With
      Dim dt As DataTable = ds.Tables("milestoneitem")
      ' First process deletes.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
    End Function

#End Region

#Region "Items"
    Public Overloads Sub ReLoadItems()
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems()
      Me.IsInitialized = True
    End Sub
    Public Overloads Sub ReloadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.IsInitialized = False
      m_itemTable = GetSchemaTable()
      LoadItems(ds, aliasPrefix)
      Me.IsInitialized = True
    End Sub
    Private Overloads Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.RealConnectionString _
      , CommandType.StoredProcedure _
      , "GetMilestoneItems" _
      , New SqlParameter("@milestone_id", Me.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New MilestoneItem(row, "")
        item.Milestone = Me
        Me.Add(item)
      Next
    End Sub
    Private Overloads Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New MilestoneItem(dr, aliasPrefix)
        item.Milestone = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim myItem As New MilestoneItem
        Me.ItemTable.AcceptChanges()
        Me.Add(myItem)
      Next
    End Sub
    Public Function Add(ByVal item As MilestoneItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.Milestone = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As MilestoneItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.Milestone = Me
      item.CopyToDataRow(myRow)
      ReIndex(index + 1)
      Return myRow
    End Function
    Public Sub Remove(ByVal index As Integer)
      Me.ItemTable.Childs.Remove(Me.ItemTable.Childs(index))
      ReIndex()
    End Sub
    Private Sub ReIndex()
      ReIndex(0)
    End Sub
    Private Sub ReIndex(ByVal index As Integer)
      If index < 0 OrElse index > Me.ItemTable.Childs.Count - 1 Then
        Return
      End If
      For i As Integer = index To Me.ItemTable.Childs.Count - 1
        Me.ItemTable.Childs(i)("milestonei_linenumber") = i + 1
      Next
    End Sub
    Public Function MaxRowIndex() As Integer
      If Me.m_itemTable Is Nothing Then
        Return -1
      End If
      'ให้ค่า index ของแถวสุดท้ายที่มีข้อมูล
      For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
        Dim row As TreeRow = Me.m_itemTable.Childs(i)
        If ValidateRow(row) Then
          Return i
        End If
      Next
      Return -1 'ไม่มีข้อมูลเลย
    End Function
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        If index = Me.m_itemTable.Childs.Count - 1 Then
          Me.AddBlankRow(1)
        End If
        Select Case e.Column.ColumnName.ToLower
          Case "milestonei_qty", "milestonei_unitprice"
            UpdateAmount(e)
          Case Else
        End Select
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        Me.OnPropertyChanged(Me, pe)
        Me.m_itemTable.AcceptChanges()
      End If
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "unit"
            SetUnitValue(e)
          Case "milestonei_qty", "milestonei_unitprice"
            SetQty(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
      Dim item As New MilestoneItem
      item.CopyFromDataRow(CType(e.Row, TreeRow))
      e.Row("milestonei_amt") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      RefreshGross()
    End Sub
    Public Sub RefreshGross()
      If Me.ItemTable Is Nothing OrElse Me.ItemTable.Rows.Count = 0 Then        m_gross = 0
      Else
        Dim amt As Decimal = 0        For Each row As TreeRow In Me.ItemTable.Rows
          Dim item As New MilestoneItem
          item.CopyFromDataRow(row)
          amt += item.Amount
        Next        m_gross = amt
      End If    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Try
        'Dim proposedUnit As Object = e.Row("unit")
        'Dim proposedDescription As Object = e.Row("milestonei_desc")
        'Dim proposedQty As Object = e.Row("milestonei_qty")
        'Dim proposedUnitPrice As Object = e.Row("milestonei_unitprice")

        Dim proposedDescription As String = ""
        Dim proposedQty As Decimal = 0
        Dim proposedUnitPrice As Decimal = 0

        If Not e.Row.IsNull("milestonei_desc") Then
          proposedDescription = CStr(e.Row("milestonei_desc"))
        End If
        If Not e.Row.IsNull("milestonei_qty") AndAlso IsNumeric(e.Row("milestonei_qty")) Then
          proposedQty = CDec(e.Row("milestonei_qty"))
        End If
        If Not e.Row.IsNull("milestonei_unitprice") AndAlso IsNumeric(e.Row("milestonei_unitprice")) Then
          proposedUnitPrice = CDec(e.Row("milestonei_unitprice"))
        End If

        If Not e.ProposedValue Is Nothing Then
          Select Case e.Column.ColumnName.ToLower
            'Case "unit"
            'proposedUnit = e.ProposedValue
            Case "milestonei_desc"
              proposedDescription = CStr(e.ProposedValue)
            Case "milestonei_qty"
              proposedQty = CDec(e.ProposedValue)
            Case "milestonei_unitprice"
              proposedUnitPrice = CDec(e.ProposedValue)
            Case Else
              Return
          End Select
        End If

        Dim isBlankRow As Boolean = False
        'If (IsDBNull(proposedUnit) OrElse CStr(proposedUnit).Length = 0) _
        'And (IsDBNull(proposedUnitPrice) OrElse Not IsNumeric(proposedUnitPrice) OrElse CDec(proposedUnitPrice) = 0) _
        'And (IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0) _
        'And (IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
        'Then
        'isBlankRow = True
        'End If
        If (proposedUnitPrice = 0) AndAlso (proposedDescription.Length = 0) AndAlso (proposedQty = 0) Then
          isBlankRow = True
        End If

        If Not isBlankRow Then
          'If IsDBNull(proposedUnit) Then
          '    e.Row.SetColumnError("Unit", Me.StringParserService.Parse("${res:Global.Error.UnitMissing}"))
          'Else
          '    e.Row.SetColumnError("Unit", "")
          'End If

          If (proposedDescription Is Nothing) OrElse CStr(proposedDescription).Length = 0 Then
            e.Row.SetColumnError("milestonei_desc", Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
          Else
            e.Row.SetColumnError("milestonei_desc", "")
          End If

          'If IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0 Then
          '    e.Row.SetColumnError("milestonei_qty", Me.StringParserService.Parse("${res:Global.Error.QtyMissing}"))
          'Else
          '    e.Row.SetColumnError("milestonei_qty", "")
          'End If
          'If IsDBNull(proposedQty) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0 Then
          '    e.Row.SetColumnError("milestonei_unitprice", Me.StringParserService.Parse("${res:Global.Error.UnitPriceMissing}"))
          'Else
          '    e.Row.SetColumnError("milestonei_unitprice", "")
          'End If
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      'Dim proposedUnit As Object = row("unit")
      'Dim proposedDescription As Object = row("milestonei_desc")
      'Dim proposedQty As Object = row("milestonei_qty")
      'Dim proposedUnitPrice As Object = row("milestonei_unitprice")

      Dim proposedDescription As String = ""
      Dim proposedQty As Decimal = 0
      Dim proposedUnitPrice As Decimal = 0

      If Not row.IsNull("milestonei_desc") Then
        proposedDescription = CStr(row("milestonei_desc"))
      End If
      If Not row.IsNull("milestonei_qty") AndAlso IsNumeric(row("milestonei_qty")) Then
        proposedQty = CDec(row("milestonei_qty"))
      End If
      If Not row.IsNull("milestonei_unitprice") AndAlso IsNumeric(row("milestonei_unitprice")) Then
        proposedUnitPrice = CDec(row("milestonei_unitprice"))
      End If

      Dim flag As Boolean = True
      Dim isBlankRow As Boolean = False
      'If ((proposedUnit Is Nothing) OrElse CStr(proposedUnit).Length = 0) _
      'And ((proposedUnitPrice Is Nothing) OrElse Not IsNumeric(proposedUnitPrice) OrElse CDec(proposedUnitPrice) = 0) _
      'And ((proposedDescription Is Nothing) OrElse CStr(proposedDescription).Length = 0) _
      'And ((proposedQty Is Nothing) OrElse Not IsNumeric(proposedQty) OrElse CDec(proposedQty) = 0) _
      'Then
      'flag = False
      'End If

      If (proposedUnitPrice = 0) AndAlso (proposedDescription.Length = 0) AndAlso (proposedQty = 0) Then
        flag = False
      End If

      Return flag
    End Function
    Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
      If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      Dim dgconfig As DigitConfig = DigitConfig.Qty
      Select Case e.Column.ColumnName.ToLower
        Case "milestonei_qty"
          dgconfig = DigitConfig.Qty
        Case "milestonei_unitprice"
          dgconfig = DigitConfig.UnitPrice
      End Select
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), dgconfig)
    End Sub
    Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      Dim myUnit As New Unit(e.ProposedValue.ToString)
      If Not myUnit Is Nothing AndAlso myUnit.Valid Then
        e.Row("milestonei_unit") = myUnit.Id
        e.ProposedValue = myUnit.Name
      Else
        e.Row("milestonei_unit") = DBNull.Value
        e.ProposedValue = DBNull.Value
      End If
    End Sub
    Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
      'Dim row As DataRow = e.Row
      'Me.m_itemTable.Childs.Remove(CType(row, TreeRow))
      'Try
      '    If Not Me.m_isInitialized Then
      '        Return
      '    End If

      '    Dim index As TreeRow = CType(e.Row, TreeRow)
      '    Me.m_itemTable.Childs.Remove(index)
      'Catch ex As Exception
      '    MessageBox.Show(ex.ToString)
      'End Try
    End Sub
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "MI"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "MI"
    End Function
    Private Sub GetHeaderPrintingEntries(ByVal dpiColl As DocPrintingItemCollection)
      Dim dpi As DocPrintingItem

      'MilestoneCode
      dpi = New DocPrintingItem
      dpi.Mapping = "MilestoneCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'MilestoneName
      dpi = New DocPrintingItem
      dpi.Mapping = "MilestoneName"
      dpi.Value = Me.Name
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

      'InvoiceCode
      dpi = New DocPrintingItem
      dpi.Mapping = "InvoiceCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'InvoiceDate
      dpi = New DocPrintingItem
      dpi.Mapping = "InvoiceDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'CustomerInfo
      If Me.Customer.Originated Then
        Me.Customer.PopulateDPIColl(dpiColl)
      End If

      'LastEditor
      Dim myEditorName As String = ""
      If Not Me.LastEditor Is Nothing AndAlso Me.LastEditor.Originated Then
        myEditorName = Me.LastEditor.Name
      ElseIf Not Me.Originator Is Nothing AndAlso Me.Originator.Originated Then
        myEditorName = Me.Originator.Name
      End If
      dpi = New DocPrintingItem
      dpi.Mapping = "LastEditor"
      dpi.Value = myEditorName
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''CreditPeriod
      'dpi = New DocPrintingItem
      'dpi.Mapping = "CreditPeriod"
      'dpi.Value = Me.CreditPeriod
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.Datetime"
      dpiColl.Add(dpi)
    End Sub
    Private Sub GetSummaryPrintingEntries(ByVal dpiColl As DocPrintingItemCollection)

    End Sub
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection

      GetHeaderPrintingEntries(dpiColl)
      GetSummaryPrintingEntries(dpiColl)

      Dim dpi As DocPrintingItem
      Me.RefreshGross()

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'BeforeTax - ยอดไม่รวมภาษี
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      If Me.TaxAmount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.TaxAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.AfterTax - Me.BeforeTax, DigitConfig.Price)
      End If
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      '-- Last Page -------------
      '--------------------------
      'LastPageGross
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageGross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageBeforeTax - ยอดไม่รวมภาษี
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageBeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTaxAmount"
      If Me.TaxAmount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.TaxAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.AfterTax - Me.BeforeTax, DigitConfig.Price)
      End If
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageAfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '--------------------------


      'Note 'Undone >>>> เพิ่มใน DB ด้วยจ้า
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'ContractAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractAmount"
      dpi.Value = Configuration.FormatToString(Me.MileStoneAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AdvancePayment
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvancePayment"
      dpi.Value = Configuration.FormatToString(Me.Advance, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "Retention"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DiscountRate 'Undone >>>> เพิ่มใน DB ด้วยจ้า
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountRate"
      dpi.Value = Me.Discount.Rate
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountAmount 'Undone >>>> เพิ่มใน DB ด้วยจ้า
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Amount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      For i As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        If ValidateRow(itemRow) Then
          Dim item As New MilestoneItem
          item.CopyFromDataRow(itemRow)
          'Item.LineNumber
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = n + 1
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Name"
          dpi.Value = item.Description
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

          'Item.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
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
        End If
      Next

      'MessageBox.Show(m_itemCollection.PaymentApplication.TaxBase)
      'TaxBase - มูลค่าสินค้า/บริการ
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxBase"
      'dpi.Value = Configuration.FormatToString(Me.Vat.TaxBase, DigitConfig.Price)
      dpi.Value = Configuration.FormatToString(Me.TaxBase - Me.TaxAmount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'MileStoneAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "MileStoneAmount"
      dpi.Value = Configuration.FormatToString(Me.MileStoneAmount / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)


      'For Each item As Milestone In Me.ItemCollection


      'SummaryMileStoneAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryMileStoneAmount"
      dpi.Value = Configuration.FormatToString(Me.MileStoneAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryDiscountAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AfterDiscountAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.MileStoneAmount - Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceAmount"
      dpi.Value = Configuration.FormatToString(Me.Advance / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryAdvanceAmount"
      dpi.Value = Configuration.FormatToString(Me.Advance, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AfterAdvanceAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterAdvanceAmount"
      dpi.Value = Configuration.FormatToString((Me.MileStoneAmount - Me.DiscountAmount) - Me.Advance, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryRetentionAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryRetentionAmount"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AfterRetentionAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterRetentionAmount"
      dpi.Value = Configuration.FormatToString(((Me.MileStoneAmount - Me.DiscountAmount) - Me.Advance) - Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryGoodsReceiptAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryGoodsReceiptAmount"
      dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryGoodsReceiptAmountIncludedVat
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryGoodsReceiptAmountIncludedVat"
      dpi.Value = Configuration.FormatToString(Me.TaxBase * ((100 + Me.TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'Gross Included Tax
      dpi = New DocPrintingItem
      dpi.Mapping = "GrossIncludeAddedTax"
      If Me.TaxAmount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.Gross + Me.TaxAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.Gross + (Me.AfterTax - Me.BeforeTax), DigitConfig.Price)
      End If
      'dpi.Value = Configuration.FormatToString(sumAdvance / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      '--- Last page -----------
      '-------------------------
      'LastPageTaxBase - มูลค่าสินค้า/บริการ
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTaxBase"
      dpi.Value = Configuration.FormatToString(Me.TaxBase - Me.TaxAmount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageMileStoneAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageMileStoneAmount"
      dpi.Value = Configuration.FormatToString(Me.MileStoneAmount / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryAdvanceAmount"
      dpi.Value = Configuration.FormatToString(Me.Advance, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAdvanceAmount"
      dpi.Value = Configuration.FormatToString(Me.Advance / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryGoodsReceiptAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryGoodsReceiptAmount"
      dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryGoodsReceiptAmountIncludedVat
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryGoodsReceiptAmountIncludedVat"
      dpi.Value = Configuration.FormatToString(Me.TaxBase * ((100 + Me.TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'LastPageGross Included Tax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageGrossIncludeAddedTax"
      If Me.TaxAmount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.Gross + Me.TaxAmount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.Gross + (Me.AfterTax - Me.BeforeTax), DigitConfig.Price)
      End If
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '-------------------------

      'CustomerCode
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerCode"
      dpi.Value = Me.PaymentApplication.Customer.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerName
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerName"
      dpi.Value = Me.PaymentApplication.Customer.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerBillingAddress
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerBillingAddress"
      dpi.Value = Me.PaymentApplication.Customer.BillingAddress
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "IBillIssuable"
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer) As Decimal Implements IBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveMilestoneAmount" _
                , New SqlParameter("@milestone_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer, ByVal billi_id As Integer) As Decimal Implements IBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveMilestoneAmount" _
                , New SqlParameter("@milestone_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                , New SqlParameter("@salebillii_salebilli", billi_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountWithBillIssue(ByVal billi_id As Integer) As Decimal Implements IBillIssuable.GetRemainingAmountWithBillIssue
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveMilestoneAmount" _
                , New SqlParameter("@milestone_id", Me.Id) _
                , New SqlParameter("@salebillii_salebilli", billi_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
      Return Me.Amount
    End Function
    Public Property [Date]() As Date Implements IReceivable.Date
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)
        Me.DocDate = Value
      End Set
    End Property
    Public Property DueDate() As Date Implements IReceivable.DueDate
      Get
        Return Me.HandedDate
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property
    Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
      Get
        Return Me.Customer
      End Get
    End Property
    Public Property Receive() As Receive Implements IReceivable.Receive
      Get
        Return m_receive
      End Get
      Set(ByVal Value As Receive)
        m_receive = Value
      End Set
    End Property
    Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount

    End Function
#End Region

#Region "Overrides"
    Public Overrides Function ToString() As String
      If Me.Originated Then
        Return Me.Code & ":" & Me.Name & ":" & Me.Type.Description
      Else
        Return "None"
      End If
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

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property
  End Class
  Public Class MilestoneStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "milestone_status"
      End Get
    End Property
#End Region

  End Class

  Public Class MilestoneType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "milestone_type"
      End Get
    End Property
#End Region

  End Class
  <Serializable(), DefaultMember("Item")> _
  Public Class MilestoneCollection
    Inherits CollectionBase

#Region "Members"
    Private m_pma As PaymentApplication
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As CostCenter)
      If Not owner.Originated Then
        Return
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMilestonesForCC" _
      , New SqlParameter("@cc_id", owner.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As Milestone
        Select Case CInt(row("milestone_type"))
          Case 75 'Milestone
            item = New Milestone(row, "")
          Case 77 'Retention
            item = New Retention(row, "")
          Case 78 'VariationOrderInc
            item = New VariationOrderInc(row, "")
          Case 79 'VariationOrderDe
            item = New VariationOrderDe(row, "")
          Case 86 'AdvanceMileStone
            item = New AdvanceMileStone(row, "")
        End Select
        item.PaymentApplication = m_pma
        Me.Add(item)
      Next

    End Sub
    Public Sub New(ByVal owner As BillIssue)
      If Not owner.Originated Then
        Return
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMilestonesForBillIssue" _
      , New SqlParameter("@billi_id", owner.Id) _
      )
      'm_pma = owner.PaymentApplication Todo
      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As Milestone
        Select Case CInt(row("milestone_type"))
          Case 75 'Milestone
            item = New Milestone(row, "")
          Case 77 'Retention
            item = New Retention(row, "")
          Case 78 'VariationOrderInc
            item = New VariationOrderInc(row, "")
          Case 79 'VariationOrderDe
            item = New VariationOrderDe(row, "")
          Case 86 'AdvanceMileStone
            item = New AdvanceMileStone(row, "")
        End Select
        Me.Add(item)
      Next

    End Sub
    Public Sub New(ByVal owner As PaymentApplication)
      Me.m_pma = owner
      If Not Me.m_pma.Originated Then
        Return
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMilestones" _
      , New SqlParameter("@pma_id", Me.m_pma.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As Milestone
        Select Case CInt(row("milestone_type"))
          Case 75 'Milestone
            item = New Milestone(row, "")
          Case 77 'Retention
            item = New Retention(row, "")
          Case 78 'VariationOrderInc
            item = New VariationOrderInc(row, "")
          Case 79 'VariationOrderDe
            item = New VariationOrderDe(row, "")
          Case 86 'AdvanceMileStone
            item = New AdvanceMileStone(row, "")
        End Select
        item.PaymentApplication = m_pma
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal owner As Customer)
      If Not owner.Originated Then
        Return
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.SiteConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMilestonesForCustomer" _
      , New SqlParameter("@cust_id", owner.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As Milestone
        Select Case CInt(row("milestone_type"))
          Case 75 'Milestone
            item = New Milestone(row, "")
          Case 77 'Retention
            item = New Retention(row, "")
          Case 78 'VariationOrderInc
            item = New VariationOrderInc(row, "")
          Case 79 'VariationOrderDe
            item = New VariationOrderDe(row, "")
          Case 86 'AdvanceMileStone
            item = New AdvanceMileStone(row, "")
        End Select
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property PaymentApplication() As PaymentApplication      Get        Return m_pma      End Get      Set(ByVal Value As PaymentApplication)        m_pma = Value        For Each mi As Milestone In Me          mi.PaymentApplication = m_pma
        Next      End Set    End Property    Default Public Property Item(ByVal index As Integer) As Milestone
      Get
        Return CType(MyBase.List.Item(index), Milestone)
      End Get
      Set(ByVal value As Milestone)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub ResetReal()
      For Each mi As Milestone In Me
        mi.ResetReal()
      Next
    End Sub
    Private Function IncludeThisItem(ByVal item As Milestone, ByVal pma As PaymentApplication) As Boolean
      If pma Is Nothing OrElse (Not item.PaymentApplication Is Nothing AndAlso item.PaymentApplication.Id = pma.Id) Then
        Return True
      End If
    End Function
    Public Function GetIdList() As String
      Dim ret As String = ""
      For Each mi As Milestone In Me
        ret &= "|" & mi.Id & "|"
      Next
      Return ret
    End Function
    Public Function GetBillableCollection() As MilestoneCollection
      Dim coll As New MilestoneCollection
      For Each mi As Milestone In Me
        If mi.Status.Value = 3 Then  ' ส่งงานแล้ว
          coll.Add(mi)
        End If
      Next
      Return coll
    End Function
    Public Function GetBilledCollection() As MilestoneCollection
      Dim coll As New MilestoneCollection
      For Each mi As Milestone In Me
        If mi.Status.Value = 4 Then 'วางบิลแล้ว
          coll.Add(mi)
        End If
      Next
      Return coll
    End Function
    Public Function GetComboTable() As DataTable
      Dim myDatatable As New DataTable("List")
      myDatatable.Columns.Add(New DataColumn("Id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      For Each mi As Milestone In Me
        Dim dr As DataRow = myDatatable.NewRow
        dr("Id") = mi.Id
        dr("Name") = mi.Code & ":" & mi.Name
        myDatatable.Rows.Add(dr)
      Next
      Return myDatatable
    End Function
    Public Function Add(ByVal index As Integer) As Milestone
      Dim currentMi As Milestone = Me(index)
      Dim newMi As New Milestone
      Select Case currentMi.Type.Value
        Case 75 'Milestone
          Me.Insert(index, newMi)
        Case 77 'Retention
          Me.Insert(index, newMi)
        Case 78 'VariationOrderInc
          Me.Insert(index, newMi)
        Case 79 'VariationOrderDe
          Me.Insert(index, newMi)
        Case 86 'AdvanceMileStone
          Me.Insert(index, newMi)
      End Select
      Return newMi
    End Function
    Public Function GetAdvanceCollection(Optional ByVal pma As PaymentApplication = Nothing) As MilestoneCollection
      Dim myCollection As New MilestoneCollection
      If Me.PaymentApplication Is Nothing Then
        myCollection.PaymentApplication = pma
      Else
        myCollection.PaymentApplication = Me.PaymentApplication
      End If
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If TypeOf item Is AdvanceMileStone Then
            myCollection.Add(item)
          End If
        End If
      Next
      Return myCollection
    End Function
    Public Function GetAdvanceLocked() As Boolean
      Dim advrColl As MilestoneCollection = Me.GetAdvanceCollection
      If advrColl.Count > 1 Then
        Return True
      End If
      If advrColl.Count > 0 Then
        Dim advr As AdvanceMileStone = CType(advrColl(0), AdvanceMileStone)
        If advr.Status.Value = 0 Or advr.Status.Value > 3 Then
          Return True
        End If
      End If
      Return False
    End Function
    Public Function GetOrCreateAdvance() As AdvanceMileStone
      Dim coll As MilestoneCollection = Me.GetAdvanceCollection
      If coll.Count = 1 Then
        Return CType(coll(0), AdvanceMileStone)
      ElseIf coll.Count = 0 Then
        Dim advr As New AdvanceMileStone
        If Me.Count = 0 Then
          Me.Add(advr)
        Else
          Me.Insert(0, advr)
        End If
        Return advr
      End If
      Return Nothing 'เกิน 1
    End Function
    Public Sub DeleteAdvance(Optional ByVal pma As PaymentApplication = Nothing)
      Dim itemToRemove As Milestone
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If TypeOf item Is AdvanceMileStone Then
            itemToRemove = item
          End If
        End If
      Next
      If Not itemToRemove Is Nothing Then
        Me.Remove(itemToRemove)
      End If
    End Sub
    Public Function GetRetentionCollection(Optional ByVal pma As PaymentApplication = Nothing) As MilestoneCollection
      Dim myCollection As New MilestoneCollection
      If Me.PaymentApplication Is Nothing Then
        myCollection.PaymentApplication = pma
      Else
        myCollection.PaymentApplication = Me.PaymentApplication
      End If
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If TypeOf item Is Retention Then
            myCollection.Add(item)
          End If
        End If
      Next
      Return myCollection
    End Function
    Public Function GetRetentionLocked() As Boolean
      Dim rtnColl As MilestoneCollection = Me.GetRetentionCollection
      If rtnColl.Count > 1 Then
        Return True
      End If
      If rtnColl.Count > 0 Then
        Dim rtn As Retention = CType(rtnColl(0), Retention)
        If rtn.Status.Value = 0 Or rtn.Status.Value > 3 Then
          Return True
        End If
      End If
      Return False
    End Function
    Public Function GetOrCreateRetention() As Retention
      Dim coll As MilestoneCollection = Me.GetRetentionCollection
      If coll.Count = 1 Then
        Return CType(coll(0), Retention)
      ElseIf coll.Count = 0 Then
        Dim rtn As New Retention
        Me.Add(rtn)
        Return rtn
      End If
      Return Nothing 'เกิน 1
    End Function
    Public Sub DeleteRetention(Optional ByVal pma As PaymentApplication = Nothing)
      Dim itemToRemove As Milestone
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If TypeOf item Is Retention Then
            itemToRemove = item
          End If
        End If
      Next
      If Not itemToRemove Is Nothing Then
        Me.Remove(itemToRemove)
      End If
    End Sub
    Public Function GetMilestoneLocked() As Boolean
      For Each item As Milestone In Me
        If item.Status.Value >= 3 Then
          Return True
        End If
      Next
      Return False
    End Function
    Public Function GetVOIncCollection(Optional ByVal pma As PaymentApplication = Nothing) As MilestoneCollection
      Dim myCollection As New MilestoneCollection
      If Me.PaymentApplication Is Nothing Then
        myCollection.PaymentApplication = pma
      Else
        myCollection.PaymentApplication = Me.PaymentApplication
      End If
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If TypeOf item Is VariationOrderInc Then
            myCollection.Add(item)
          End If
        End If
      Next
      Return myCollection
    End Function
    Public Function GetVODeCollection(Optional ByVal pma As PaymentApplication = Nothing) As MilestoneCollection
      Dim myCollection As New MilestoneCollection
      If Me.PaymentApplication Is Nothing Then
        myCollection.PaymentApplication = pma
      Else
        myCollection.PaymentApplication = Me.PaymentApplication
      End If
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If TypeOf item Is VariationOrderDe Then
            myCollection.Add(item)
          End If
        End If
      Next
      Return myCollection
    End Function
    Public Function GetMilestoneCollection(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal toAdv As Boolean = False) As MilestoneCollection
      Dim myCollection As New MilestoneCollection
      If Me.PaymentApplication Is Nothing Then
        myCollection.PaymentApplication = pma
      Else
        myCollection.PaymentApplication = Me.PaymentApplication
      End If
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If Not TypeOf item Is VariationOrderDe Then
            If (Not toAdv) OrElse (toAdv AndAlso Not TypeOf item Is VariationOrderInc) Then
              If Not TypeOf item Is Retention Then
                If Not TypeOf item Is AdvanceMileStone Then
                  myCollection.Add(item)
                End If
              End If
            End If
          End If
        End If
      Next
      Return myCollection
    End Function
    Public Function GetMilesoneAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.MileStoneAmount
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          amt += itemAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.Amount
          Dim itemRetention As Decimal = item.Retention
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
            itemRetention = Configuration.Format(itemRetention, DigitConfig.Price)
          End If
          amt += (itemAmount + itemRetention)
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.Amount
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetTaxBase(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.TaxBase
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetTaxAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.TaxAmount
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetBeforeTax(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.BeforeTax
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetAfterTax(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.AfterTax
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetMilestoneAmountAfterTax(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.MileStoneAmount
          If item.TaxType.Value = 1 Then
            itemAmount += Vat.GetVatAmount(itemAmount)
          End If
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetMilestoneAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.MileStoneAmount
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetMilestoneAmountWithTax(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.CalculatedAfterTax
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetAfterTax(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.AfterTax
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetBeforeTax(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.BeforeTax
          'Dim itemRetention As Decimal = item.Retention
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
            'itemRetention = Configuration.Format(itemRetention, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetRetentionAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.Retention
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetHandedRetentionAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If item.Status.Value >= 3 Then
            Dim itemAmount As Decimal = item.Retention
            If roundBeforeSum Then
              itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
            End If
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetAdvrAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.Advance
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          amt += itemAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetHandedAdvrAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          If item.Status.Value >= 3 Then
            Dim itemAmount As Decimal = item.Advance
            If roundBeforeSum Then
              itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
            End If
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetDiscountAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.DiscountAmount
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          amt += itemAmount
        End If
      Next
      Return amt
    End Function
    Public Function GetCanGetDiscountAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.DiscountAmount
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          If TypeOf item Is VariationOrderDe Then
            amt -= itemAmount
          Else
            amt += itemAmount
          End If
        End If
      Next
      Return amt
    End Function
    Public Function GetPenaltyAmount(Optional ByVal pma As PaymentApplication = Nothing, Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim amt As Decimal
      For Each item As Milestone In Me
        If IncludeThisItem(item, pma) Then
          Dim itemAmount As Decimal = item.Penalty
          If roundBeforeSum Then
            itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
          End If
          amt += itemAmount
        End If
      Next
      Return amt
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As Milestone) As Integer
      If Not m_pma Is Nothing Then
        value.PaymentApplication = m_pma
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As MilestoneCollection)
      For i As Integer = 0 To value.Count - 1
        If Not m_pma Is Nothing Then
          value(i).PaymentApplication = m_pma
        End If
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As Milestone())
      For i As Integer = 0 To value.Length - 1
        If Not m_pma Is Nothing Then
          value(i).PaymentApplication = m_pma
        End If
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As Milestone) As Boolean
      For Each mi As Milestone In Me
        If value.Originated And mi.Id = value.Id Then
          Return True
        End If
      Next
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As Milestone(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As MilestoneEnumerator
      Return New MilestoneEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As Milestone) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As Milestone)
      If Not m_pma Is Nothing Then
        value.PaymentApplication = m_pma
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As Milestone)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As MilestoneCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class MilestoneEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As MilestoneCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, Milestone)
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
