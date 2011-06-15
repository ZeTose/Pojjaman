Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class WitholdingTaxType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "wht_type"
      End Get
    End Property
#End Region

  End Class
  Public Class WitholdingTaxPaymentType
    Inherits CodeDescription

#Region "Members"
    Private m_otherPaymentType As String
#End Region

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
      m_otherPaymentType = ""
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "wht_paymenttype"
      End Get
    End Property
    Public Property OtherPaymentType() As String
      Get
        If Me.Value <> 4 Then
          Return ""
        End If
        Return m_otherPaymentType
      End Get
      Set(ByVal Value As String)
        m_otherPaymentType = Value
      End Set
    End Property
#End Region

  End Class
  Public Class WitholdingTaxDirection
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "wht_direction"
      End Get
    End Property
#End Region

  End Class
  Public Class WitholdingTax
    Inherits SimpleBusinessEntityBase
		Implements IPrintableEntity, IHasMainDoc

#Region "Members"
    Private wht_bookNo As String
    Private wht_type As WitholdingTaxType
    Private wht_docDate As Date
    Private wht_note As String
    Private wht_refDoc As IWitholdingTaxable
    Private wht_direction As WitholdingTaxDirection

    Private wht_entity As IBillablePerson
    Private wht_printName As String
    Private wht_entityAddress As String
    Private wht_entityTaxId As String
    Private wht_entityIdNo As String

    Private wht_paymentType As WitholdingTaxPaymentType

    Private m_itemTable As TreeTable
    Private m_itemTable2 As TreeTable


    Private wht_representName As String
    Private wht_representAddress As String
    Private wht_representTaxId As String
    Private wht_representIdNo As String
    Private wht_employerAcct As String
    Private wht_employeeSSN As String
    Private wht_CompanySupport As String
    Private wht_license As String
    Private wht_cumulative As String

    Private m_latestCode As String

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal refDoc As IWitholdingTaxable)
      Me.New(refDoc.Id, CType(refDoc, IObjectReflectable).EntityId)
      Me.RefDoc = refDoc
    End Sub
    Private Sub New(ByVal refId As Integer, ByVal refType As Integer)
      If refId = 0 Then
        m_itemTable = GetSchemaTable()
        'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
        AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
        AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
        AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetWitholdingTax" _
      , New SqlParameter("@wht_refDoc", refId), New SqlParameter("@wht_refDocType", refType))
      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count = 1 Then
        Construct(ds.Tables(0).Rows(0), "")
      End If
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal ds As DataSet)
      Me.Construct(dr, "")
      ReLoadItems(ds, "")
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .wht_refDoc = New GenericWitholdingTaxble
        .wht_refDoc.Id = 0
        .wht_refDoc.Date = Date.MinValue
        .wht_refDoc.Code = ""
        .wht_type = New WitholdingTaxType(-1)
        .wht_paymentType = New WitholdingTaxPaymentType(1)
        .wht_direction = New WitholdingTaxDirection(0)
        .wht_docDate = Now.Date
        .SequenceNo = New WitholdingTaxSequence
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If Not dr.IsNull(aliasPrefix & "wht_docDate") Then
          .wht_docDate = CDate(dr(aliasPrefix & "wht_docDate"))
        End If

        If Not dr.IsNull(aliasPrefix & "wht_sequenceNo") Then
          .SequenceNo = New WitholdingTaxSequence
          .SequenceNo.Code = CStr(dr(aliasPrefix & "wht_sequenceNo"))
          If .SequenceNo.Code.Length > 0 Then
            .SequenceNo.Id = .Id
            .SequenceNo.AutoGen = False
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_bookNo") AndAlso Not dr.IsNull(aliasPrefix & "wht_bookNo") Then
          .wht_bookNo = CStr(dr(aliasPrefix & "wht_bookNo"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_note") AndAlso Not dr.IsNull(aliasPrefix & "wht_note") Then
          .wht_note = CStr(dr(aliasPrefix & "wht_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_type") AndAlso Not dr.IsNull(aliasPrefix & "wht_type") Then
          .wht_type = New WitholdingTaxType(CInt(dr(aliasPrefix & "wht_type")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_direction") AndAlso Not dr.IsNull(aliasPrefix & "wht_direction") Then
          .wht_direction = New WitholdingTaxDirection(CInt(dr(aliasPrefix & "wht_direction")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_representName") AndAlso Not dr.IsNull(aliasPrefix & "wht_representName") Then
          .wht_representName = CStr(dr(aliasPrefix & "wht_representName"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_representAddress") AndAlso Not dr.IsNull(aliasPrefix & "wht_representAddress") Then
          .wht_representAddress = CStr(dr(aliasPrefix & "wht_representAddress"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_representTaxId") AndAlso Not dr.IsNull(aliasPrefix & "wht_representTaxId") Then
          .wht_representTaxId = CStr(dr(aliasPrefix & "wht_representTaxId"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_representIdNo") AndAlso Not dr.IsNull(aliasPrefix & "wht_representIdNo") Then
          .wht_representIdNo = CStr(dr(aliasPrefix & "wht_representIdNo"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_employerAcct") AndAlso Not dr.IsNull(aliasPrefix & "wht_employerAcct") Then
          .wht_employerAcct = CStr(dr(aliasPrefix & "wht_employerAcct"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_employeeSSN") AndAlso Not dr.IsNull(aliasPrefix & "wht_employeeSSN") Then
          .wht_employeeSSN = CStr(dr(aliasPrefix & "wht_employeeSSN"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_CompanySupport") AndAlso Not dr.IsNull(aliasPrefix & "wht_CompanySupport") Then
          .wht_CompanySupport = CStr(dr(aliasPrefix & "wht_CompanySupport"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_license") AndAlso Not dr.IsNull(aliasPrefix & "wht_license") Then
          .wht_license = CStr(dr(aliasPrefix & "wht_license"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_cumulative") AndAlso Not dr.IsNull(aliasPrefix & "wht_cumulative") Then
          .wht_cumulative = CStr(dr(aliasPrefix & "wht_cumulative"))
        End If

        Dim refDocType As Integer
        Dim refDocId As Integer
        Dim refDocCode As String
        Dim refDocDate As Date
        If dr.Table.Columns.Contains(aliasPrefix & "wht_refDocType") AndAlso Not dr.IsNull(aliasPrefix & "wht_refDocType") Then
          refDocType = CInt(dr(aliasPrefix & "wht_refDocType"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_refdoc") AndAlso Not dr.IsNull(aliasPrefix & "wht_refdoc") Then
          refDocId = CInt(dr(aliasPrefix & "wht_refdoc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_refdoccode") AndAlso Not dr.IsNull(aliasPrefix & "wht_refdoccode") Then
          refDocCode = CStr(dr(aliasPrefix & "wht_refdoccode"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_refdocdate") AndAlso Not dr.IsNull(aliasPrefix & "wht_refdocdate") Then
          refDocDate = CDate(dr(aliasPrefix & "wht_refdocdate"))
        End If

        'Hack: harcoded
        'If refDocType = 0 Then
        '    .wht_refDoc = New GenericWitholdingTaxble
        '    .wht_refDoc.Id = refDocId
        '    .wht_refDoc.Code = refDocCode
        '    .wht_refDoc.Date = refDocDate
        'Else
        '    .wht_refDoc = CType(SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(refDocType), refDocId), IWitholdingTaxable)
        'End If

        Dim entityType As Integer
        Dim entityId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "wht_entityType") AndAlso Not dr.IsNull(aliasPrefix & "wht_entityType") Then
          entityType = CInt(dr(aliasPrefix & "wht_entityType"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_entity") AndAlso Not dr.IsNull(aliasPrefix & "wht_entity") Then
          entityId = CInt(dr(aliasPrefix & "wht_entity"))
        End If
        If dr.Table.Columns.Contains("eocheck_supplier") Then '--เพื่อความเร็ว:pui--
          If Not dr.IsNull("eocheck_supplier") Then
            .wht_entity = New Supplier(dr, "") ' Supplier.GetSupplierbyDataRow(dr)
          End If
        ElseIf entityType = 10 AndAlso dr.Table.Columns.Contains(aliasPrefix & "supplier_id") AndAlso Not dr.IsNull(aliasPrefix & "supplier_id") Then
          .wht_entity = CType(New Supplier(CInt(dr("supplier_id"))), IBillablePerson)
          '.wht_entity = CType(Supplier.GetSupplierbyDataRow(dr), IBillablePerson)
        Else
          .wht_entity = CType(SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(entityType), entityId), IBillablePerson)
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_entityAddress") AndAlso Not dr.IsNull(aliasPrefix & "wht_entityAddress") Then
          .wht_entityAddress = CStr(dr(aliasPrefix & "wht_entityAddress"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_printName") AndAlso Not dr.IsNull(aliasPrefix & "wht_printName") Then
          .wht_printName = CStr(dr(aliasPrefix & "wht_printName"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_entityTaxId") AndAlso Not dr.IsNull(aliasPrefix & "wht_entityTaxId") Then
          .wht_entityTaxId = CStr(dr(aliasPrefix & "wht_entityTaxId"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_entityIdNo") AndAlso Not dr.IsNull(aliasPrefix & "wht_entityIdNo") Then
          .wht_entityIdNo = CStr(dr(aliasPrefix & "wht_entityIdNo"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "wht_paymentType") AndAlso Not dr.IsNull(aliasPrefix & "wht_paymentType") Then
          .wht_paymentType = New WitholdingTaxPaymentType(CInt(dr(aliasPrefix & "wht_paymentType")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "wht_otherpaymenttype") AndAlso Not dr.IsNull(aliasPrefix & "wht_otherpaymenttype") Then
          .wht_paymentType.OtherPaymentType = CStr(dr(aliasPrefix & "wht_otherpaymenttype"))
        End If

        Me.m_latestCode = Me.Code
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Private m_sequenceNo As WitholdingTaxSequence
    Public Property SequenceNo As WitholdingTaxSequence
      Get
        Return m_sequenceNo
      End Get
      Set(ByVal value As WitholdingTaxSequence)
        m_sequenceNo = value
      End Set
    End Property

    Public ReadOnly Property Maindoc() As ISimpleEntity Implements IHasMainDoc.MainDoc
      Get
        Return CType(wht_refDoc, ISimpleEntity)
      End Get
    End Property

    Public Property BookNo() As String
      Get
        Return wht_bookNo
      End Get
      Set(ByVal Value As String)
        wht_bookNo = Value
      End Set
    End Property
    Public Property LastestCode() As String
      Get
        Return m_latestCode
      End Get
      Set(ByVal Value As String)
        m_latestCode = Value
      End Set
    End Property
    Public Property ItemTable() As TreeTable
      Get
        Return m_itemTable
      End Get
      Set(ByVal Value As TreeTable)
        m_itemTable = Value
      End Set
    End Property
    Public Property ItemTable2() As TreeTable
      Get
        Return m_itemTable2
      End Get
      Set(ByVal Value As TreeTable)
        m_itemTable2 = Value
      End Set
    End Property
    Public Property Type() As WitholdingTaxType
      Get
        If wht_type.Value = -1 Then
          If Not Me.Entity Is Nothing Then
            If Not Me.Entity.PersonType Is Nothing Then
              Select Case Me.Entity.PersonType.Value
                Case 0 'บุคคลธรรมดา = 3
                  wht_type = New WitholdingTaxType(4)
                Case 1 'นิติบุคคล = 53
                  wht_type = New WitholdingTaxType(7)
              End Select
            End If
          End If
        End If
        Return wht_type
      End Get
      Set(ByVal Value As WitholdingTaxType)
        wht_type = Value
      End Set
    End Property
    Public Property DocDate() As Date
      Get
        Return wht_docDate
      End Get
      Set(ByVal Value As Date)
        wht_docDate = Value
      End Set
    End Property
    Public Property Note() As String
      Get
        Return wht_note
      End Get
      Set(ByVal Value As String)
        wht_note = Value
      End Set
    End Property
    Public Property RefDoc() As IWitholdingTaxable
      Get
        Return wht_refDoc
      End Get
      Set(ByVal Value As IWitholdingTaxable)
        wht_refDoc = Value
        If Not Me.Originated Then
          DocDate = Value.Date
        End If
      End Set
    End Property
    Public Property Direction() As WitholdingTaxDirection
      Get
        Return wht_direction
      End Get
      Set(ByVal Value As WitholdingTaxDirection)
        wht_direction = Value
      End Set
    End Property
    Public Property Entity() As IBillablePerson
      Get
        Return wht_entity
      End Get
      Set(ByVal Value As IBillablePerson)
        wht_entity = Value
      End Set
    End Property
    Public Property PrintName() As String
      Get
        Return wht_printName
      End Get
      Set(ByVal Value As String)
        wht_printName = Value
      End Set
    End Property
    Public Property EntityAddress() As String
      Get
        If wht_entityAddress Is Nothing OrElse wht_entityAddress.Length = 0 Then
          Return Me.Entity.BillingAddress
        End If
        Return wht_entityAddress
      End Get
      Set(ByVal Value As String)
        wht_entityAddress = Value
      End Set
    End Property
    Public Property EntityTaxId() As String
      Get
        If wht_entityTaxId Is Nothing OrElse wht_entityTaxId.Length = 0 Then
          If Not Me.Entity.TaxId Is Nothing Then
            Return Me.Entity.TaxId
          Else
            Return ""
          End If
        End If
        Return wht_entityTaxId
      End Get
      Set(ByVal Value As String)
        wht_entityTaxId = Value
      End Set
    End Property
    Public Property EntityIdNo() As String
      Get
        If wht_entityIdNo Is Nothing OrElse wht_entityIdNo.Length = 0 Then
          If Not Me.Entity.IdNo Is Nothing Then
            Return Me.Entity.IdNo
          Else
            Return ""
          End If
        End If
        Return wht_entityIdNo
      End Get
      Set(ByVal Value As String)
        wht_entityIdNo = Value
      End Set
    End Property
    Public Property RepresentName() As String
      Get
        Return wht_representName
      End Get
      Set(ByVal Value As String)
        wht_representName = Value
      End Set
    End Property
    Public Property RepresentTaxId() As String
      Get
        Return wht_representTaxId
      End Get
      Set(ByVal Value As String)
        wht_representTaxId = Value
      End Set
    End Property
    Public Property RepresentAddress() As String
      Get
        Return wht_representAddress
      End Get
      Set(ByVal Value As String)
        wht_representAddress = Value
      End Set
    End Property
    Public Property RepresentIdNo() As String
      Get
        Return wht_representIdNo
      End Get
      Set(ByVal Value As String)
        wht_representIdNo = Value
      End Set
    End Property
    Public Property EmployerAcct() As String
      Get
        Return wht_employerAcct
      End Get
      Set(ByVal Value As String)
        wht_employerAcct = Value
      End Set
    End Property
    Public Property EmployeeSSN() As String
      Get
        Return wht_employeeSSN
      End Get
      Set(ByVal Value As String)
        wht_employeeSSN = Value
      End Set
    End Property
    Public Property CompanySupport() As String
      Get
        Return wht_CompanySupport
      End Get
      Set(ByVal Value As String)
        wht_CompanySupport = Value
      End Set
    End Property
    Public Property License() As String
      Get
        Return wht_license
      End Get
      Set(ByVal Value As String)
        wht_license = Value
      End Set
    End Property
    Public Property Cumulative() As String
      Get
        Return wht_cumulative
      End Get
      Set(ByVal Value As String)
        wht_cumulative = Value
      End Set
    End Property
    Public Property PaymentType() As WitholdingTaxPaymentType
      Get
        Return wht_paymentType
      End Get
      Set(ByVal Value As WitholdingTaxPaymentType)
        wht_paymentType = Value
      End Set
    End Property
    Public ReadOnly Property TaxBase() As Decimal
      Get
        Dim sumTaxBase As Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Childs
          If Not IsDBNull(row("whti_taxbase")) AndAlso IsNumeric(row("whti_taxbase")) Then
            sumTaxBase += CDec(row("whti_taxbase"))
          End If
        Next
        Return sumTaxBase
      End Get
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim sumAmount As Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Childs
          If Not IsDBNull(row("Amount")) AndAlso IsNumeric(row("Amount")) Then
            sumAmount += CDec(row("Amount"))
          End If
        Next
        Return sumAmount
      End Get
    End Property
    Public Property CCId As Integer
    Public Overrides ReadOnly Property GetListSprocName() As String
      Get
        Return "GetWitholdingTaxList"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetWitholdingTax"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "WitholdingTax"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "WitholdingTax"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "wht"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.WitholdingTax"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.WitholdingTax"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt = tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region "Shared"
		Public Shared Function CreateTableStyle() As DataGridTableStyle
			Dim dst As New DataGridTableStyle
			dst.MappingName = "WitholdingTax"
			Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

			Dim csLineNumber As New TreeTextColumn
			csLineNumber.MappingName = "whti_linenumber"
			csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.LineNumberHeaderText}")
			csLineNumber.NullText = ""
			csLineNumber.Width = 30
			csLineNumber.DataAlignment = HorizontalAlignment.Center
			csLineNumber.ReadOnly = True
			csLineNumber.TextBox.Name = "whti_linenumber"

			Dim csDesc As New TreeTextColumn
			csDesc.MappingName = "whti_description"
			csDesc.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.DescriptionHeaderText}")
			csDesc.NullText = ""
			csDesc.Width = 180
			csDesc.TextBox.Name = "whti_description"


			Dim csType As DataGridComboColumn
			csType = New DataGridComboColumn("whti_type" _
			, CodeDescription.GetCodeList("whti_type") _
			, "code_description", "code_value")
			csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.TypeHeaderText}")
			csType.NullText = String.Empty

			Dim csTaxBase As New TreeTextColumn
			csTaxBase.MappingName = "whti_taxbase"
			csTaxBase.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.TaxBaseHeaderText}")
			csTaxBase.NullText = ""
			csTaxBase.DataAlignment = HorizontalAlignment.Right
			csTaxBase.Format = "#,###.##"
			csTaxBase.TextBox.Name = "whti_taxbase"
			csTaxBase.Width = 60

			Dim csTaxRate As New TreeTextColumn
			csTaxRate.MappingName = "whti_taxrate"
			csTaxRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.TaxRateHeaderText}")
			csTaxRate.NullText = ""
			csTaxRate.DataAlignment = HorizontalAlignment.Right
			csTaxRate.Format = "#,###.##"
			csTaxRate.TextBox.Name = "whti_taxrate"
			csTaxRate.Width = 60


			Dim csAmount As New TreeTextColumn
			csAmount.MappingName = "Amount"
			csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.AmountHeaderText}")
			csAmount.NullText = ""
			csAmount.DataAlignment = HorizontalAlignment.Right
			csAmount.Format = "#,###.##"
			csAmount.TextBox.Name = "Amount"
			csAmount.Width = 60

			Dim csNote As New TreeTextColumn
			csNote.MappingName = "whti_note"
			csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.NoteHeaderText}")
			csNote.NullText = ""
			csNote.Width = 100
			csNote.TextBox.Name = "whti_note"

			dst.GridColumnStyles.Add(csLineNumber)
			dst.GridColumnStyles.Add(csType)
			dst.GridColumnStyles.Add(csDesc)
			dst.GridColumnStyles.Add(csTaxBase)
			dst.GridColumnStyles.Add(csTaxRate)
			dst.GridColumnStyles.Add(csAmount)
			dst.GridColumnStyles.Add(csNote)

			Return dst
		End Function

		Public Shared Function CreateTableStyle2() As DataGridTableStyle
			Dim dst As New DataGridTableStyle
			dst.MappingName = "WitholdingTax"
			Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

			Dim csLineNumber As New TreeTextColumn
			csLineNumber.MappingName = "whti_linenumber"
			csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.LineNumberHeaderText}")
			csLineNumber.NullText = ""
			csLineNumber.Width = 30
			csLineNumber.DataAlignment = HorizontalAlignment.Center
			csLineNumber.ReadOnly = True
			csLineNumber.TextBox.Name = "whti_linenumber"

			Dim csWHTCode As New TreeTextColumn
			csWHTCode.MappingName = "wht_code"
			csWHTCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.WHTCodeHeaderText}")
			csWHTCode.NullText = ""
			csWHTCode.Width = 100
			csWHTCode.DataAlignment = HorizontalAlignment.Left
			csWHTCode.ReadOnly = True
			csWHTCode.TextBox.Name = "wht_code"

			Dim csWHTType As New TreeTextColumn
			csWHTType.MappingName = "wht_type"
			csWHTType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.WHTTypeHeaderText}")
			csWHTType.NullText = ""
			csWHTType.Width = 150
			csWHTType.DataAlignment = HorizontalAlignment.Left
			csWHTType.ReadOnly = True
			csWHTType.TextBox.Name = "wht_type"

			Dim csWHTPaymentType As New TreeTextColumn
			csWHTPaymentType.MappingName = "wht_paymenttype"
			csWHTPaymentType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.WHTPaymentTypeHeaderText}")
			csWHTPaymentType.NullText = ""
			csWHTPaymentType.Width = 150
			csWHTPaymentType.DataAlignment = HorizontalAlignment.Left
			csWHTPaymentType.ReadOnly = True
			csWHTPaymentType.TextBox.Name = "wht_paymenttype"

			Dim csDesc As New TreeTextColumn
			csDesc.MappingName = "whti_description"
			csDesc.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.DescriptionHeaderText}")
			csDesc.NullText = ""
			csDesc.Width = 180
			csDesc.ReadOnly = True
			csDesc.TextBox.Name = "whti_description"

			Dim csTaxBase As New TreeTextColumn
			csTaxBase.MappingName = "whti_taxbase"
			csTaxBase.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.TaxBaseHeaderText}")
			csTaxBase.NullText = ""
			csTaxBase.DataAlignment = HorizontalAlignment.Right
			csTaxBase.Format = "#,###.##"
			csTaxBase.TextBox.Name = "whti_taxbase"
			csTaxBase.Width = 70
			csTaxBase.ReadOnly = True

			Dim csTaxRate As New TreeTextColumn
			csTaxRate.MappingName = "whti_taxrate"
			csTaxRate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.TaxRateHeaderText}")
			csTaxRate.NullText = ""
			csTaxRate.DataAlignment = HorizontalAlignment.Right
			csTaxRate.Format = "#,###.##"
			csTaxRate.TextBox.Name = "whti_taxrate"
			csTaxRate.Width = 60
			csTaxRate.ReadOnly = True

			Dim csAmount As New TreeTextColumn
			csAmount.MappingName = "Amount"
			csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.AmountHeaderText}")
			csAmount.NullText = ""
			csAmount.DataAlignment = HorizontalAlignment.Right
			csAmount.Format = "#,###.##"
			csAmount.TextBox.Name = "Amount"
			csAmount.Width = 60
			csAmount.ReadOnly = True

			Dim csAfterVAT As New TreeTextColumn
			csAfterVAT.MappingName = "AfterVAT"
			csAfterVAT.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.WHTDetail.AmountAfterVat}")
			csAfterVAT.NullText = ""
			csAfterVAT.DataAlignment = HorizontalAlignment.Right
			csAfterVAT.Format = "#,###.##"
			csAfterVAT.TextBox.Name = "AfterVAT"
			csAfterVAT.Width = 70
			csAfterVAT.ReadOnly = True

			dst.GridColumnStyles.Add(csLineNumber)
			dst.GridColumnStyles.Add(csWHTCode)
			dst.GridColumnStyles.Add(csWHTType)
			dst.GridColumnStyles.Add(csWHTPaymentType)
			dst.GridColumnStyles.Add(csDesc)
			dst.GridColumnStyles.Add(csTaxBase)
			dst.GridColumnStyles.Add(csTaxRate)
			dst.GridColumnStyles.Add(csAmount)
			'dst.GridColumnStyles.Add(csAfterVAT)

			Return dst
		End Function

		Public Shared Function GetSchemaTable() As TreeTable
			Dim myDatatable As New TreeTable("WitholdingTax")
			myDatatable.Columns.Add(New DataColumn("whti_linenumber", GetType(Integer)))
			myDatatable.Columns.Add(New DataColumn("whti_description", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_taxbase", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_realtaxbase", GetType(Decimal)))		 'เก็บค่าเต็มๆ
			myDatatable.Columns.Add(New DataColumn("whti_taxrate", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("useCustomAmt", GetType(Boolean)))
			myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_note", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_cc", GetType(Integer)))
			myDatatable.Columns.Add(New DataColumn("whti_type", GetType(Integer)))
			Return myDatatable
		End Function

		Public Shared Function GetSchemaTable2() As TreeTable
			Dim myDatatable As New TreeTable("WitholdingTax")
			myDatatable.Columns.Add(New DataColumn("whti_linenumber", GetType(Integer)))
			myDatatable.Columns.Add(New DataColumn("wht_code", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("wht_type", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("wht_type_id", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("wht_paymenttype", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("wht_paymenttype_id", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_description", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_taxrate", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_taxbase", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("whti_realtaxbase", GetType(Decimal)))		 'เก็บค่าเต็มๆ
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("whti_cc", GetType(Integer)))
			'myDatatable.Columns.Add(New DataColumn("AfterVat", GetType(String)))
			Return myDatatable
		End Function
#End Region

#Region "Methods"
    Public Sub SetCCId(ByVal ccId As Integer)
      Me.CCId = ccId
      'For n As Integer = 0 To Me.MaxRowIndex
      'Dim item As TreeRow = Me.m_itemTable.Childs(n)
      'If ValidateRow(item) Then
      'item("whti_cc") = ccId
      'End If
      'Next
    End Sub
		Public Shared Sub DeleteFromRefDoc(ByVal refDocId As Integer, ByVal refDocType As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction)
			Dim paramArrayList As New ArrayList
			paramArrayList.Add(New SqlParameter("@wht_refDocType", refDocType))
			paramArrayList.Add(New SqlParameter("@wht_refdoc", refDocId))
			Dim sqlparams() As SqlParameter
			sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
			SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteWitholdingtax", sqlparams)
		End Sub
		Public Shared Sub DeleteDoc(ByVal DocId As Integer, ByVal refDocId As Integer, ByVal refDocType As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction)
			Dim paramArrayList As New ArrayList
			paramArrayList.Add(New SqlParameter("@wht_id", DocId))
			paramArrayList.Add(New SqlParameter("@wht_refDocType", refDocType))
			paramArrayList.Add(New SqlParameter("@wht_refdoc", refDocId))
			Dim sqlparams() As SqlParameter
			sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
			SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteWitholdingtax", sqlparams)
		End Sub
		Private Sub ResetID(ByVal oldid As Integer)
			Me.Id = oldid
		End Sub
		Public Overrides Function GetLastCode(ByVal prefixPattern As String) As String
			Dim codePattern As String = ""
			Dim generatePattern As String = ""
			codePattern = CodeGenerator.GetPattern(prefixPattern)
			generatePattern = Replace(prefixPattern, codePattern, "")

			Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
			Dim conn As New SqlConnection(sqlConString)
			'Dim sql As String = "select top 1 " & Me.Prefix & "_code from [" & Me.TableName & "] where " & Me.Prefix & "_code like '" & prefixPattern & "%' " & " and wht_direction = " & Me.Direction.Value & " order by " & Me.Prefix & "_id desc"
			Dim sql As String = "select max(wht_code) from [WitholdingTax] " & _
													"where wht_code like '" & codePattern & "%' " & _
													"and wht_direction = " & Me.Direction.Value & " " & _
													"and len(replace(wht_code,'" & codePattern & "','')) = " & generatePattern.Length

			conn.Open()

			Dim cmd As SqlCommand = conn.CreateCommand
			cmd.CommandText = sql

			Dim obj As Object = cmd.ExecuteScalar
			If Not IsDBNull(obj) AndAlso Not obj Is Nothing Then
				Return obj.ToString
			End If
			Return ""
		End Function
		Public Overrides Function DuplicateCode(ByVal newCode As String) As Boolean
			If Me.Direction.Value = 0 Then
				Return False
			End If
			Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
			Dim conn As New SqlConnection(sqlConString)
			Dim sql As String = "select count(*) from [" & Me.TableName & "] where " & Me.Prefix & "_code='" & newCode & "' and isnull(" & Me.Prefix & "_bookNo,'')='" & Me.BookNo & "' and " & Me.Prefix & "_id <> " & Me.Id & " and " & Me.Prefix & "_direction = 1"

			conn.Open()

			Dim cmd As SqlCommand = conn.CreateCommand
			cmd.CommandText = sql
			Dim recordCount As Object = cmd.ExecuteScalar
			conn.Close()
			If Not IsDBNull(recordCount) AndAlso CInt(recordCount) > 0 Then
				Return True
			End If
			Return False
    End Function
    Private Function GetCurrencyConversion() As Decimal
      If TypeOf Me.RefDoc Is IHasCurrency Then
        Return CType(Me.RefDoc, IHasCurrency).Currency.Conversion
      End If
      Return 1
    End Function
    Private Function GetConvertedRefdocMaximumTaxBase() As Decimal
      Return Me.RefDoc.GetMaximumWitholdingTaxBase * GetCurrencyConversion()
    End Function
		Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
			With Me
				If Me.MaxRowIndex < 0 Then		 '.ItemTable.Childs.Count = 0 Then
					Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
				End If

        Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

        Dim refTaxBase As Decimal = 0
        If TypeOf RefDoc Is ReceiveSelection Then
          If Me.Amount > GetConvertedRefdocMaximumTaxBase() Then
            If Not myMessage.AskQuestionFormatted("${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.ExceededTaxBase}", _
                                                  New String() { _
                                                    Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                                                    Configuration.FormatToString(GetConvertedRefdocMaximumTaxBase, DigitConfig.Price) _
                                                  }) Then
              Return New SaveErrorException("")
            End If
          End If
        ElseIf TypeOf RefDoc Is PaySelection Then
          If Me.Amount > GetConvertedRefdocMaximumTaxBase() Then
            If Not myMessage.AskQuestionFormatted("${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.ExceededTaxBase}", _
                                                  New String() { _
                                                    Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                                                    Configuration.FormatToString(GetConvertedRefdocMaximumTaxBase, DigitConfig.Price) _
                                                  }) Then
              Return New SaveErrorException("")
            End If
          End If
        Else
          If Me.Amount > GetConvertedRefdocMaximumTaxBase() Then
            If Not myMessage.AskQuestionFormatted("${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.ExceededTaxBase}", _
                                                  New String() { _
                                                    Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                                                    Configuration.FormatToString(GetConvertedRefdocMaximumTaxBase, DigitConfig.Price) _
                                                  }) Then
              Return New SaveErrorException("")
            End If
          End If
        End If

        Me.UpdateRefDoc()
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)

        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@wht_id", Me.Id))
        End If
        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        If Me.SequenceNo.AutoGen And Me.SequenceNo.Code.Length = 0 Then
          Me.SequenceNo.Code = Me.SequenceNo.GetNextCode
        End If

        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@wht_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@wht_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@wht_bookNo", Me.BookNo))
        paramArrayList.Add(New SqlParameter("@wht_SequenceNo", Me.SequenceNo.Code))

        Dim refDocType As Integer
        If TypeOf Me.RefDoc Is ISimpleEntity Then
          refDocType = CType(Me.RefDoc, ISimpleEntity).EntityId
        End If
        paramArrayList.Add(New SqlParameter("@wht_refDocType", refDocType))
        paramArrayList.Add(New SqlParameter("@wht_refdoc", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@wht_refDocCode", Me.RefDoc.Code))
        paramArrayList.Add(New SqlParameter("@wht_refDocDate", Me.RefDoc.Date))

        If Not Me.RefDoc.Person Is Nothing AndAlso TypeOf Me.RefDoc.Person Is SimpleBusinessEntityBase Then
          Dim payee As SimpleBusinessEntityBase = CType(Me.RefDoc.Person, SimpleBusinessEntityBase)
          paramArrayList.Add(New SqlParameter("@wht_entity", ValidIdOrDBNull(payee)))
          paramArrayList.Add(New SqlParameter("@wht_entityType", payee.EntityId))
        End If

        paramArrayList.Add(New SqlParameter("@wht_printname", Me.PrintName))
        paramArrayList.Add(New SqlParameter("@wht_entityAddress", Me.EntityAddress))
        paramArrayList.Add(New SqlParameter("@wht_entitytaxid", Me.EntityTaxId))
        paramArrayList.Add(New SqlParameter("@wht_entityidno", Me.EntityIdNo))

        paramArrayList.Add(New SqlParameter("@wht_taxbase", Me.TaxBase))
        paramArrayList.Add(New SqlParameter("@wht_amt", Me.Amount))
        paramArrayList.Add(New SqlParameter("@wht_note", Me.Note))


        paramArrayList.Add(New SqlParameter("@wht_direction", Me.Direction.Value))
        paramArrayList.Add(New SqlParameter("@wht_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@wht_type", Me.Type.Value))
        paramArrayList.Add(New SqlParameter("@wht_paymenttype", Me.PaymentType.Value))
        paramArrayList.Add(New SqlParameter("@wht_otherpaymenttype", Me.PaymentType.OtherPaymentType))

        paramArrayList.Add(New SqlParameter("@wht_representName", Me.RepresentName))
        paramArrayList.Add(New SqlParameter("@wht_representAddress", Me.RepresentAddress))
        paramArrayList.Add(New SqlParameter("@wht_representTaxId", Me.RepresentTaxId))
        paramArrayList.Add(New SqlParameter("@wht_representIdNo", Me.RepresentIdNo))
        paramArrayList.Add(New SqlParameter("@wht_employerAcct", Me.EmployerAcct))
        paramArrayList.Add(New SqlParameter("@wht_employeeSSN", Me.EmployeeSSN))
        paramArrayList.Add(New SqlParameter("@wht_CompanySupport", Me.CompanySupport))
        paramArrayList.Add(New SqlParameter("@wht_license", Me.License))
        paramArrayList.Add(New SqlParameter("@wht_cumulative", Me.Cumulative))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Dim oldid As Integer = Me.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1
                Me.ResetID(oldid)
                Return New SaveErrorException("${res:Global.Error.WHTCodeDuplicated}", Me.Code)
              Case -2, -5
                Me.ResetID(oldid)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            Me.ResetID(oldid)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          SaveDetail(Me.Id, conn, trans)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Me.ResetID(oldid)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Me.ResetID(oldid)
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
		End Function

		Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer


			Dim da As New SqlDataAdapter("Select * from witholdingtaxitem where whti_wht=" & Me.Id, conn)
			Dim cmdBuilder As New SqlCommandBuilder(da)

			Dim ds As New DataSet

			da.SelectCommand.Transaction = trans

			'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
			cmdBuilder.GetDeleteCommand.Transaction = trans
			cmdBuilder.GetInsertCommand.Transaction = trans
			cmdBuilder.GetUpdateCommand.Transaction = trans

			da.Fill(ds, "witholdingtaxitem")

			Dim dbCount As Integer = ds.Tables("witholdingtaxitem").Rows.Count
			Dim itemCount As Integer = Me.ItemTable.Childs.Count
			Dim i As Integer = 0
			With ds.Tables("witholdingtaxitem")
				For Each row As DataRow In .Rows
					row.Delete()
				Next
				For n As Integer = 0 To Me.MaxRowIndex
					Dim item As TreeRow = Me.m_itemTable.Childs(n)
					If ValidateRow(item) Then
						i += 1
						Dim dr As DataRow = .NewRow
						dr("whti_wht") = Me.Id
						dr("whti_linenumber") = i			 'item("whti_linenumber")
						dr("whti_description") = item("whti_description")
						dr("whti_taxrate") = item("whti_taxrate")
						dr("whti_taxbase") = item("whti_taxbase")
						dr("whti_amt") = item("Amount")
						dr("whti_note") = item("whti_note")
            dr("whti_cc") = Me.CCId 'item("whti_cc")
						dr("whti_type") = item("whti_type")
						If dr.IsNull("whti_type") Then
							dr("whti_type") = 0
						End If
						.Rows.Add(dr)
					End If
				Next
			End With
			Dim dt As DataTable = ds.Tables("witholdingtaxitem")
			' First process deletes.
			da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
			' Next process updates.
			da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
			' Finally process inserts.
			da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
		End Function
    Public Sub UpdateRefDoc()
      UpdateRefDoc(Me.RefDoc.Person, False)
    End Sub
    Public Sub UpdateRefdoc(ByVal person As IBillablePerson, Optional ByVal force As Boolean = False)
      If force OrElse Me.EntityIdNo Is Nothing OrElse Me.EntityIdNo.Length = 0 Then
        Me.EntityIdNo = person.IdNo
      End If
      If force OrElse Me.EntityTaxId Is Nothing OrElse Me.EntityTaxId.Length = 0 Then
        Me.EntityTaxId = person.TaxId
      End If
      If force OrElse Me.EntityAddress Is Nothing OrElse Me.EntityAddress.Length = 0 Then
        Me.EntityAddress = person.BillingAddress
      End If
      If force OrElse Me.PrintName Is Nothing OrElse Me.PrintName.Length = 0 Then
        Me.PrintName = person.Name
      End If
      If force Then
        Select Case person.PersonType.Value
          Case 0
            Me.Type = New WitholdingTaxType(4)
          Case 1
            Me.Type = New WitholdingTaxType(7)
        End Select
      End If
    End Sub
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
		Private Sub LoadItems()
			If Not Me.Originated Then
				Return
			End If
			Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
			, CommandType.StoredProcedure _
			, "GetWitholdingTaxItems" _
			, New SqlParameter("@wht_id", Me.Id) _
			)
			For Each row As DataRow In ds.Tables(0).Rows
				Dim item As New WitholdingTaxItem(row, "")
				item.WitholdingTax = Me
				Me.Add(item)
			Next
		End Sub
		Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
			For Each dr As DataRow In ds.Tables(1).Rows
				Dim item As New WitholdingTaxItem(dr, aliasPrefix)
				item.WitholdingTax = Me
				Me.Add(item)
			Next
		End Sub
		Public Sub AddBlankRow(ByVal count As Integer)
			For i As Integer = 0 To count - 1
				Dim myItem As New WitholdingTaxItem
				Me.ItemTable.AcceptChanges()
				Me.Add(myItem)
			Next
		End Sub
		Public Function Add(ByVal item As WitholdingTaxItem) As TreeRow
			Dim myRow As TreeRow = Me.ItemTable.Childs.Add
			item.LineNumber = Me.ItemTable.Childs.Count
			item.WitholdingTax = Me
			item.CopyToDataRow(myRow)
			Return myRow
		End Function
		Public Function Insert(ByVal index As Integer, ByVal item As WitholdingTaxItem) As TreeRow
			Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
			item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
			item.WitholdingTax = Me
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
				Me.ItemTable.Childs(i)("whti_linenumber") = i + 1
			Next
		End Sub
		Public Function MaxRowIndex() As Integer
			If Me.m_itemTable Is Nothing Then
				Return -1
			End If
			'ให้ index ของแถวสุดท้ายที่มีข้อมูล
			For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
				Dim row As TreeRow = Me.m_itemTable.Childs(i)
				If ValidateRow(row) Then
					Return i
				End If
			Next
			Return -1		'ไม่มีข้อมูลเลย
		End Function

		Public Overloads Sub ReLoadItems2(Optional ByVal dt As TreeTable = Nothing)
			Me.IsInitialized = False
			m_itemTable2 = GetSchemaTable2()
			LoadItems2(dt)
			Me.IsInitialized = True
		End Sub
		Private Sub LoadItems2(Optional ByVal dt As TreeTable = Nothing)
			If Not Me.Originated Then
				Return
			End If
			Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
			, CommandType.StoredProcedure _
			, "GetWitholdingTaxItems" _
			, New SqlParameter("@wht_id", Me.Id) _
			)

			For Each row As DataRow In ds.Tables(0).Rows
				Dim item As New WitholdingTaxItem(row, "")
				item.WitholdingTax = Me
				Me.Add2(item, dt)
			Next
		End Sub
		Public Function Add2(ByVal item As WitholdingTaxItem, Optional ByVal dt As TreeTable = Nothing) As TreeRow
			Dim myRow As TreeRow = Me.ItemTable2.Childs.Add
			Dim myRow2 As TreeRow
			item.LineNumber = Me.ItemTable2.Childs.Count
			item.WitholdingTax = Me
			item.CopyToDataRow2(myRow)
			If Not dt Is Nothing Then
				myRow2 = dt.Childs.Add
				item.CopyToDataRow2(myRow2)
			End If
			Return myRow
		End Function
#End Region

#Region "TreeTable Handlers"
		Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
			If Not Me.IsInitialized Then
				Return
			End If
			Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
			If ValidateRow(CType(e.Row, TreeRow)) Then
				If e.Column.ColumnName <> "Amount" And e.Column.ColumnName <> "useCustomAmt" Then
					UpdateAmount(e)
				End If
				If index = Me.m_itemTable.Childs.Count - 1 Then
					Me.AddBlankRow(1)
				End If
				Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
				Me.OnPropertyChanged(Me, pe)
				Me.m_itemTable.AcceptChanges()
			End If
		End Sub
		Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
			Dim item As New WitholdingTaxItem
			item.CopyFromDataRow(CType(e.Row, TreeRow))
			e.Row("Amount") = item.Amount
		End Sub
		Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
			If Not Me.IsInitialized Then
				Return
			End If
			Try
				Select Case e.Column.ColumnName.ToLower
					Case "whti_taxbase"
						SetTaxBase(e)
					Case "whti_taxrate"
						SetTaxRate(e)
					Case "amount"
						SetTaxAmount(e)
				End Select
				ValidateRow(e)
			Catch ex As Exception
				MessageBox.Show(ex.ToString)
			End Try
		End Sub
		Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
			Dim proposedTaxBase As Object = e.Row("whti_taxbase")
			Dim proposedTaxRate As Object = e.Row("whti_taxrate")
			Dim proposedDescription As Object = e.Row("whti_description")

			Select Case e.Column.ColumnName.ToLower
				Case "whti_taxbase"
					proposedTaxBase = e.ProposedValue
				Case "whti_taxrate"
					proposedTaxRate = e.ProposedValue
				Case "whti_description"
					proposedDescription = e.ProposedValue
				Case Else
					Return
			End Select

			Dim isBlankRow As Boolean = False
			If (IsDBNull(proposedTaxBase) OrElse CStr(proposedTaxBase).Length = 0 OrElse CInt(proposedTaxBase) = 0) _
					And (IsDBNull(proposedTaxRate) OrElse CStr(proposedTaxRate).Length = 0 OrElse CInt(proposedTaxRate) = 0) _
					And (IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0) Then
				isBlankRow = True
			End If

			If Not isBlankRow Then
				If IsDBNull(proposedTaxBase) Then
					e.Row.SetColumnError("whti_taxbase", Me.StringParserService.Parse("${res:Global.Error.TaxBaseMissing}"))
				Else
					e.Row.SetColumnError("whti_taxbase", "")
				End If

				If IsDBNull(proposedTaxRate) Then
					e.Row.SetColumnError("whti_taxrate", Me.StringParserService.Parse("${res:Global.Error.TaxRateMissing}"))
				Else
					e.Row.SetColumnError("whti_taxrate", "")
				End If

				If IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0 Then
					e.Row.SetColumnError("whti_description", Me.StringParserService.Parse("${res:Global.Error.DescriptonMissing}"))
				Else
					e.Row.SetColumnError("whti_description", "")
				End If
			End If

		End Sub
		Public Function ValidateRow(ByVal row As TreeRow) As Boolean
			Dim proposedTaxBase As Object = row("whti_taxbase")
			Dim proposedTaxRate As Object = row("whti_taxrate")
			Dim proposedDescription As Object = row("whti_description")

			Dim flag As Boolean = True
			If (IsDBNull(proposedTaxBase) OrElse CStr(proposedTaxBase).Length = 0 OrElse CInt(proposedTaxBase) = 0) _
					And (IsDBNull(proposedTaxRate) OrElse CStr(proposedTaxRate).Length = 0 OrElse CInt(proposedTaxRate) = 0) _
					And (IsDBNull(proposedDescription) OrElse CStr(proposedDescription).Length = 0) _
					Then
				flag = False
			End If
			Return flag
		End Function
		Public Sub SetTaxRate(ByVal e As System.Data.DataColumnChangeEventArgs)
			If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
				e.ProposedValue = ""
				e.Row("Amount") = ""
				Return
			End If
			e.Row("useCustomAmt") = False
			e.ProposedValue = Configuration.FormatToString(TextParser.Evaluate(e.ProposedValue.ToString), DigitConfig.Price)
		End Sub
		Public Sub SetTaxBase(ByVal e As System.Data.DataColumnChangeEventArgs)
			If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
				e.ProposedValue = ""
			End If
			Dim value As Decimal = 0
			Try
				value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
				e.ProposedValue = Configuration.FormatToString(value, DigitConfig.Price)
			Catch ex As SyntaxErrorException
				e.ProposedValue = e.Row(e.Column)
			End Try
			e.Row("whti_realtaxbase") = value
			e.Row("useCustomAmt") = False
			Dim item As New WitholdingTaxItem
			item.CopyFromDataRow(CType(e.Row, TreeRow))
			'e.Row("Amount") = item.Amount  'หลังจาก changed แล้วมีการอัปเดทอยู่แล้ว
		End Sub
		Public Sub SetTaxAmount(ByVal e As System.Data.DataColumnChangeEventArgs)
			If Not e.Column.ColumnName = "Amount" Then
				Return
			End If
			If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
				e.ProposedValue = ""
			End If
			Dim value As Decimal = 0
			Try
				value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
				e.ProposedValue = Configuration.FormatToString(value, DigitConfig.Price)
			Catch ex As SyntaxErrorException
				e.ProposedValue = e.Row(e.Column)
			End Try
			e.Row("useCustomAmt") = True
			Dim item As New WitholdingTaxItem
			item.CopyFromDataRow(CType(e.Row, TreeRow))
		End Sub
		Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
			Try
				If Not Me.IsInitialized Then
					Return
				End If
				Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
				Me.OnPropertyChanged(Me, pe)
				e.Row.SetColumnError("whti_description", "")
			Catch ex As Exception
				MessageBox.Show(ex.ToString)
			End Try
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
			Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PV.dfm"
		End Function
		Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

		End Function
		Private Function InsertSpace(ByVal txt As String) As String
			Dim ret As String = ""
			For Each c As Char In txt.ToCharArray
				ret &= c & "  "
			Next
			Return ret.TrimEnd(" "c)
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

			'BookNo
			dpi = New DocPrintingItem
			dpi.Mapping = "BookNo"
			dpi.Value = Me.BookNo
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'DocDate
			dpi = New DocPrintingItem
			dpi.Mapping = "DocDate"
			dpi.Value = Me.DocDate.ToShortDateString
			dpi.DataType = "System.DateTime"
			dpiColl.Add(dpi)

			'CodeRef
			dpi = New DocPrintingItem
			dpi.Mapping = "CodeRef"
			dpi.Value = Me.RefDoc.Code
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'DocDateRef
			dpi = New DocPrintingItem
			dpi.Mapping = "DocDateRef"
			dpi.Value = Me.RefDoc.Date.ToShortDateString
			dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'SequenceNO
      dpi = New DocPrintingItem
      dpi.Mapping = "SequenceNO"
      dpi.Value = Me.SequenceNo
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

			'Note
			dpi = New DocPrintingItem
			dpi.Mapping = "Note"
			dpi.Value = Me.Note
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'PrintName
			dpi = New DocPrintingItem
			dpi.Mapping = "PrintName"
			dpi.Value = Me.PrintName
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'RepresentIdNo
			dpi = New DocPrintingItem
			dpi.Mapping = "RepresentIdNo"
			dpi.Value = Me.RepresentIdNo
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'RepresentTaxId
			dpi = New DocPrintingItem
			dpi.Mapping = "RepresentTaxId"
			dpi.Value = Me.RepresentTaxId
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)


			If Not Me.RefDoc Is Nothing _
			AndAlso Not Me.RefDoc.Person Is Nothing Then
				'PrintAddress
				dpi = New DocPrintingItem
				dpi.Mapping = "PrintAddress"
				If Not Me.EntityAddress Is Nothing Then
					dpi.Value = Me.EntityAddress.Replace(vbCrLf, " ")
				End If
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				If Me.EntityIdNo.Replace("-", "").Length = 13 Then
					'EntityIdNo
					dpi = New DocPrintingItem
					dpi.Mapping = "EntityIdNo"
					dpi.Value = Me.EntityIdNo
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityIdNo1"
					dpi.Value = Me.EntityIdNo.Replace("-", "").Substring(0, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityIdNo2"
					dpi.Value = InsertSpace(Me.EntityIdNo.Replace("-", "").Substring(1, 4))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityIdNo3"
					dpi.Value = InsertSpace(Me.EntityIdNo.Replace("-", "").Substring(5, 5))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityIdNo4"
					dpi.Value = InsertSpace(Me.EntityIdNo.Replace("-", "").Substring(10, 2))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityIdNo5"
					dpi.Value = Me.EntityIdNo.Replace("-", "").Substring(12, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				ElseIf EntityTaxId.Replace("-", "").Length = 10 Then
					'EntityTaxId
					dpi = New DocPrintingItem
					dpi.Mapping = "EntityTaxId"
					dpi.Value = Me.EntityTaxId
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityTaxId1"
					dpi.Value = Me.EntityTaxId.Replace("-", "").Substring(0, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityTaxId2"
					dpi.Value = InsertSpace(Me.EntityTaxId.Replace("-", "").Substring(1, 4))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityTaxId3"
					dpi.Value = InsertSpace(Me.EntityTaxId.Replace("-", "").Substring(5, 4))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "EntityTaxId4"
					dpi.Value = Me.EntityTaxId.Replace("-", "").Substring(9, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				End If
			End If

			Dim taxId As String = CStr(Configuration.GetConfig("CompanyTaxId"))
			If taxId.Replace("-", "").Length = 10 Then
				'TaxId
				dpi = New DocPrintingItem
				dpi.Mapping = "TaxId"
				dpi.Value = taxId
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				dpi = New DocPrintingItem
				dpi.Mapping = "TaxId1"
				dpi.Value = taxId.Replace("-", "").Substring(0, 1)
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				dpi = New DocPrintingItem
				dpi.Mapping = "TaxId2"
				dpi.Value = InsertSpace(taxId.Replace("-", "").Substring(1, 4))
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				dpi = New DocPrintingItem
				dpi.Mapping = "TaxId3"
				dpi.Value = InsertSpace(taxId.Replace("-", "").Substring(5, 4))
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				dpi = New DocPrintingItem
				dpi.Mapping = "TaxId4"
				dpi.Value = taxId.Replace("-", "").Substring(9, 1)
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)
			End If

			If Not Me.RepresentIdNo Is Nothing AndAlso Me.RepresentIdNo.Length > 0 Then
				If Me.RepresentIdNo.Replace("-", "").Length = 13 Then
					'RepresentIdNo
					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentIdNo"
					dpi.Value = Me.RepresentIdNo
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentIdNo1"
					dpi.Value = Me.RepresentIdNo.Replace("-", "").Substring(0, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentIdNo2"
					dpi.Value = InsertSpace(Me.RepresentIdNo.Replace("-", "").Substring(1, 4))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentIdNo3"
					dpi.Value = InsertSpace(Me.RepresentIdNo.Replace("-", "").Substring(5, 5))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentIdNo4"
					dpi.Value = InsertSpace(Me.RepresentIdNo.Replace("-", "").Substring(10, 2))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentIdNo5"
					dpi.Value = Me.RepresentIdNo.Replace("-", "").Substring(12, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				End If
			End If

			If Not Me.RepresentTaxId Is Nothing AndAlso Me.RepresentTaxId.Length > 0 Then
				If RepresentTaxId.Replace("-", "").Length = 10 Then
					'RepresentTaxId
					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentTaxId"
					dpi.Value = Me.RepresentTaxId
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentTaxId1"
					dpi.Value = Me.RepresentTaxId.Replace("-", "").Substring(0, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentTaxId2"
					dpi.Value = InsertSpace(Me.RepresentTaxId.Replace("-", "").Substring(1, 4))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentTaxId3"
					dpi.Value = InsertSpace(Me.RepresentTaxId.Replace("-", "").Substring(5, 4))
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "RepresentTaxId4"
					dpi.Value = Me.RepresentTaxId.Replace("-", "").Substring(9, 1)
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				End If
			End If

			'RepresentName
			dpi = New DocPrintingItem
			dpi.Mapping = "RepresentName"
			dpi.Value = Me.RepresentName
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'RepresentAddress
			dpi = New DocPrintingItem
			dpi.Mapping = "RepresentAddress"
			If Not Me.RepresentAddress Is Nothing Then
				dpi.Value = Me.RepresentAddress.Replace(vbCrLf, " ")
			End If
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			Dim amt As String = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
			Dim Bfpoint As String = Trim(Split(Replace(amt, ",", ""), ".")(0))
			Dim Aftpoint As String = "00"
			If UBound(Split(amt, "."), 1) <> 0 Then
				Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
			End If
			'Amount
			dpi = New DocPrintingItem
			dpi.Mapping = "Amount"
			dpi.Value = Configuration.FormatToString(CDec(Bfpoint), DigitConfig.Int)
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'Satang
			dpi = New DocPrintingItem
			dpi.Mapping = "Satang"
			dpi.Value = Aftpoint
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			amt = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
			Bfpoint = Trim(Split(Replace(amt, ",", ""), ".")(0))
			Aftpoint = "00"
			If UBound(Split(amt, "."), 1) <> 0 Then
				Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
			End If
			'WHTAmount
			dpi = New DocPrintingItem
			dpi.Mapping = "WHTAmount"
			dpi.Value = Configuration.FormatToString(CDec(Bfpoint), DigitConfig.Int)
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'WHTSatang
			dpi = New DocPrintingItem
			dpi.Mapping = "WHTSatang"
			dpi.Value = Aftpoint
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'WHT
			dpi = New DocPrintingItem
			dpi.Mapping = "WHT"
			dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'EmployerAcct
			dpi = New DocPrintingItem
			dpi.Mapping = "EmployerAcct"
			dpi.Value = Me.EmployerAcct
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'EmployeeSSN
			dpi = New DocPrintingItem
			dpi.Mapping = "EmployeeSSN"
			dpi.Value = Me.EmployeeSSN
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'CompanySupport
			dpi = New DocPrintingItem
			dpi.Mapping = "CompanySupport"
			dpi.Value = Me.CompanySupport
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'License
			dpi = New DocPrintingItem
			dpi.Mapping = "License"
			dpi.Value = Me.License
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'Cumulative
			dpi = New DocPrintingItem
			dpi.Mapping = "Cumulative"
			dpi.Value = Me.Cumulative
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			Select Case Me.PaymentType.Value
				Case 1		 'หัก ณ ที่จ่าย
					dpi = New DocPrintingItem
					dpi.Mapping = "PaymentType1"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 2		 'ออกให้ตลอดไป
					dpi = New DocPrintingItem
					dpi.Mapping = "PaymentType2"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 3		 'ออกให้ครั้งเดียว
					dpi = New DocPrintingItem
					dpi.Mapping = "PaymentType3"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 4		 'อื่นๆ ระบุ
					dpi = New DocPrintingItem
					dpi.Mapping = "PaymentType4"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					dpi = New DocPrintingItem
					dpi.Mapping = "OtherPaymentType"
					dpi.Value = Me.PaymentType.OtherPaymentType
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
			End Select

			Select Case Me.Type.Value
				Case 1		 'ภ.ง.ด.1ก
					dpi = New DocPrintingItem
					dpi.Mapping = "Type1"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 2		 '
					dpi = New DocPrintingItem
					dpi.Mapping = "Type2"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 3		 '
					dpi = New DocPrintingItem
					dpi.Mapping = "Type3"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 4		 '
					dpi = New DocPrintingItem
					dpi.Mapping = "Type4"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 5		 '
					dpi = New DocPrintingItem
					dpi.Mapping = "Type5"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 6		 '
					dpi = New DocPrintingItem
					dpi.Mapping = "Type6"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				Case 7		 '
					dpi = New DocPrintingItem
					dpi.Mapping = "Type7"
					dpi.Value = "P"
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
			End Select

			'##############################ITEM###################################
			Dim myItem As New Hashtable
			Dim myWHT As New Hashtable
			Dim myItemName As New Hashtable

			For n As Integer = 0 To Me.MaxRowIndex
				Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
				If ValidateRow(itemRow) Then
					If itemRow.IsNull("whti_type") Then
						itemRow("whti_type") = 0
					End If
					Dim item As New WitholdingTaxItem
					item.CopyFromDataRow(itemRow)

					Dim eachitem As Double
					Dim eachwht As Double
					Dim eachitemname As String
					eachitem = CDbl(myItem(itemRow("whti_type"))) + item.TaxBase
					eachwht = CDbl(myWHT(itemRow("whti_type"))) + item.Amount
					eachitemname = CStr(myItemName(itemRow("whti_type"))) & CStr(IIf(Not myItemName(itemRow("whti_type")) Is Nothing, ", ", "")) & item.Description
					myItem(itemRow("whti_type")) = eachitem
					myWHT(itemRow("whti_type")) = eachwht
					myItemName(itemRow("whti_type")) = eachitemname
				End If
			Next

			For Each obj As Object In myItem.Keys
				amt = Configuration.FormatToString(CDec(myItem(obj)), DigitConfig.Price)
				Bfpoint = Trim(Split(Replace(amt, ",", ""), ".")(0))
				Aftpoint = "00"
				If UBound(Split(amt, "."), 1) <> 0 Then
					Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
				End If

				'Amount
				dpi = New DocPrintingItem
				dpi.Mapping = "Amount" & CType(obj, Int32).ToString
				dpi.Value = Configuration.FormatToString(CDec(Bfpoint), DigitConfig.Int)
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'Satang
				dpi = New DocPrintingItem
				dpi.Mapping = "Satang" & CType(obj, Int32).ToString
				dpi.Value = Aftpoint
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)


				amt = Configuration.FormatToString(CDec(myWHT(obj)), DigitConfig.Price)
				Bfpoint = Trim(Split(Replace(amt, ",", ""), ".")(0))
				Aftpoint = "00"
				If UBound(Split(amt, "."), 1) <> 0 Then
					Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
				End If

				'WHTAmount
				dpi = New DocPrintingItem
				dpi.Mapping = "WHTAmount" & CType(obj, Int32).ToString
				dpi.Value = Configuration.FormatToString(CDec(Bfpoint), DigitConfig.Int)
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'WHTSatang
				dpi = New DocPrintingItem
				dpi.Mapping = "WHTSatang" & CType(obj, Int32).ToString
				dpi.Value = Aftpoint
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'ItemName
				dpi = New DocPrintingItem
				dpi.Mapping = "ItemName" & CType(obj, Int32).ToString
				dpi.Value = myItemName(obj)
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'ItemDocDate
				dpi = New DocPrintingItem
				dpi.Mapping = "ItemDocDate" & CType(obj, Int32).ToString
				dpi.Value = Me.DocDate.ToShortDateString
				dpi.DataType = "System.DateTime"
				dpiColl.Add(dpi)
			Next
			'##############################END ITEM###################################

      '===============================ตาราง WHT ทั้งหมด==============================
      If Not Me.RefDoc Is Nothing Then
        Dim n As Integer = 0
        For Each w As WitholdingTax In Me.RefDoc.WitholdingTaxCollection
          'ItemWHT.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "ItemWHT.Code"
          dpi.Value = w.Code
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "ItemWHT"
          dpiColl.Add(dpi)


          'ItemWHT.DocDate
          dpi = New DocPrintingItem
          dpi.Mapping = "ItemWHT.DocDate"
          dpi.Value = w.DocDate.ToShortDateString
          dpi.DataType = "System.DateTime"
          dpi.Row = n + 1
          dpi.Table = "ItemWHT"
          dpiColl.Add(dpi)

          'ItemWHT.WHT
          dpi = New DocPrintingItem
          dpi.Mapping = "ItemWHT.WHT"
          dpi.Value = Configuration.FormatToString(w.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "ItemWHT"
          dpiColl.Add(dpi)

          n += 1
        Next
        '===============================ตาราง WHT ทั้งหมด==============================

      End If
      dpiColl.AddRange(GetGLDocPrintingEntries)
      dpiColl.AddRange(GetPVRVDocPrintingEntries)
      Return dpiColl
    End Function
		Private Function GetGLDocPrintingEntries() As DocPrintingItemCollection
			Dim dpiColl As New DocPrintingItemCollection
			Dim dpi As DocPrintingItem
			If TypeOf Me.RefDoc Is IGLAble Then
				Dim je As JournalEntry = CType(Me.RefDoc, IGLAble).JournalEntry
				If Not je Is Nothing Then

					'AccountBook
					dpi = New DocPrintingItem
					dpi.Mapping = "AccountBook"
					If Not je.AccountBook Is Nothing Then
						dpi.Value = je.AccountBook.Name
					End If
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)

					Dim n As Integer = 0
					For Each item As JournalEntryItem In je.ItemCollection
						'Item.LineNumber
						dpi = New DocPrintingItem
						dpi.Mapping = "Item.LineNumber"
						dpi.Value = n + 1
						dpi.DataType = "System.Int32"
						dpi.Row = n + 1
						dpi.Table = "Item"
						dpiColl.Add(dpi)

						'Item.AccountCode
						dpi = New DocPrintingItem
						dpi.Mapping = "Item.AccountCode"
						If Not item.Account Is Nothing Then
							dpi.Value = item.Account.Code
						Else
							dpi.Value = ""
						End If
						dpi.DataType = "System.String"
						dpi.Row = n + 1
						dpi.Table = "Item"
						dpiColl.Add(dpi)

						'Item.AccountName
						dpi = New DocPrintingItem
						dpi.Mapping = "Item.AccountName"
						If Not item.Account Is Nothing Then
							dpi.Value = item.Account.Name
						Else
							dpi.Value = ""
						End If
						dpi.DataType = "System.String"
						dpi.Row = n + 1
						dpi.Table = "Item"
						dpiColl.Add(dpi)

						If item.IsDebit Then
							'Item.Debit
							dpi = New DocPrintingItem
							dpi.Mapping = "Item.Debit"
							dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
							dpi.DataType = "System.Decimal"
							dpi.Row = n + 1
							dpi.Table = "Item"
							dpiColl.Add(dpi)
						Else
							'Item.Credit
							dpi = New DocPrintingItem
							dpi.Mapping = "Item.Credit"
							dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
							dpi.DataType = "System.Decimal"
							dpi.Row = n + 1
							dpi.Table = "Item"
							dpiColl.Add(dpi)
						End If

						'Item.CostCenter
						dpi = New DocPrintingItem
						dpi.Mapping = "Item.CostCenter"
						If Not item.CostCenter Is Nothing Then
							dpi.Value = item.CostCenter.Code
						Else
							dpi.Value = ""
						End If
						dpi.DataType = "System.String"
						dpi.Row = n + 1
						dpi.Table = "Item"
						dpiColl.Add(dpi)

						n += 1
					Next
				End If
			End If
			Return dpiColl
		End Function
		Private Function GetPVRVDocPrintingEntries() As DocPrintingItemCollection
			Dim dpiColl As New DocPrintingItemCollection
			Dim dpi As DocPrintingItem
			If TypeOf Me.RefDoc Is IReceivable Then
				Dim RV As Receive = CType(Me.RefDoc, IReceivable).Receive
				If Not RV Is Nothing Then
					'PVRVCode
					dpi = New DocPrintingItem
					dpi.Mapping = "PVRVCode"
					dpi.Value = RV.Code
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				End If
			ElseIf TypeOf Me.RefDoc Is IPayable Then
				Dim PV As Payment = CType(Me.RefDoc, IPayable).Payment
				If Not PV Is Nothing Then
					'PVRVCode
					dpi = New DocPrintingItem
					dpi.Mapping = "PVRVCode"
					dpi.Value = PV.Code
					dpi.DataType = "System.String"
					dpiColl.Add(dpi)
				End If
			End If
			Return dpiColl
		End Function
#End Region

		Public Overrides Function ToString() As String
			Return Me.Code
		End Function

	End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class WitholdingTaxCollection
    Inherits CollectionBase

#Region "Members"
    Private wht_refDoc As IWitholdingTaxable
    Private m_wht As WitholdingTax
    Private m_direction As WitholdingTaxDirection
    Private m_isBeforepay As Boolean
    Public Const fixCodeWHT As String = "--#####--"
    Private m_refEntity As SimpleBusinessEntityBase
#End Region

#Region "Constructors"
    Public Sub New()
      Me.m_wht = New WitholdingTax
    End Sub
    Public Sub New(ByVal refDoc As IWitholdingTaxable)
      Me.New(refDoc.Id, CType(refDoc, IObjectReflectable).EntityId)
      Me.RefDoc = refDoc
    End Sub
    Public Sub New(ByVal refId As Integer, ByVal refType As Integer)
      If refId = 0 Then
        Return
      End If
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
      , CommandType.StoredProcedure _
      , "GetWitholdingTaxCollectionList" _
      , New SqlParameter("@refid", refId), New SqlParameter("@type", refType))
      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count >= 1 Then
        Dim flag As Boolean = False
        For Each row As DataRow In ds.Tables(0).Rows
          Dim item As New WitholdingTax(row, "")
          Me.Add(item)
          If Not flag Then
            If Not row.IsNull("wht_delayed") Then
              Me.m_isBeforepay = CBool(row("wht_delayed"))
            Else
              Me.m_isBeforepay = False
            End If
            flag = True
          End If
        Next
        Me.m_wht = New WitholdingTax(Me.Item(0).Code)
      End If
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As WitholdingTax
      Get
        Return CType(MyBase.List.Item(index), WitholdingTax)
      End Get
      Set(ByVal value As WitholdingTax)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property RefDocDate As Date
      Get

      End Get
      Set(ByVal value As Date)
        For Each wht As WitholdingTax In Me
          wht.DocDate = value
        Next
      End Set
    End Property
    Public Property RefDoc() As IWitholdingTaxable
      Get
        Return wht_refDoc
      End Get
      Set(ByVal Value As IWitholdingTaxable)
        wht_refDoc = Value
      End Set
    End Property
    Public Property Direction() As WitholdingTaxDirection
      Get
        Return m_direction
      End Get
      Set(ByVal Value As WitholdingTaxDirection)
        m_direction = Value
        For Each wht As WitholdingTax In Me
          wht.Direction = m_direction
        Next
      End Set
    End Property
    Dim oldrefdoccode As String
    Public Property IsBeforePay() As Boolean
      Get
        Return m_isBeforepay
      End Get
      Set(ByVal Value As Boolean)
        m_isBeforepay = Value
      End Set
    End Property
    Public ReadOnly Property CanBeDelay() As Boolean
      Get
        Return TypeOf Me.RefDoc Is ICanDelayWHT
      End Get
    End Property
    Public Property CCId As Integer

#End Region

#Region "Shared"
#End Region

#Region "Class Methods"
    Public Sub SetCCId(ByVal ccId As Integer)
      Me.CCId = ccId
      For Each wht As WitholdingTax In Me
        wht.SetCCId(ccId)
      Next
    End Sub
    Public Sub SetStatus(ByVal statusValue As Integer)
      For Each wht As WitholdingTax In Me
        wht.Status.Value = statusValue
      Next
    End Sub
    Public Function Amount() As Decimal
      Dim ret As Decimal = 0
      For Each wht As WitholdingTax In Me
        ret += wht.Amount
      Next
      Return ret
    End Function
    Public Function WitholdingTaxbase() As Decimal
      Dim ret As Decimal = 0
      For Each wht As WitholdingTax In Me
        ret += wht.TaxBase
      Next
      Return ret
    End Function
    Dim m_Ids As Hashtable
    Public Sub SaveOldID()
      m_Ids = New Hashtable
      For Each wht As WitholdingTax In Me
        m_Ids(wht) = wht.Id
      Next
    End Sub
    Public Sub ResetId()
      If m_Ids Is Nothing Then
        Return
      End If
      For Each wht As WitholdingTax In Me
        If m_Ids.Contains(wht) Then
          wht.Id = CInt(m_Ids(wht))
        End If
      Next
    End Sub
    Public Sub CreateListBox(ByVal lbox As ListBox)
      lbox.Items.Clear()
      For Each item As WitholdingTax In Me.List
        lbox.Items.Add(item)
      Next
    End Sub
    Public Sub GenCode()
      If wht_refDoc Is Nothing OrElse Me.Count <= 0 Then
        Return
      End If
      Dim tmpWHT As WitholdingTax = GetFirstAutogenWHT()
      If tmpWHT Is Nothing Then
        Return
      End If
      Dim ptn As String = Entity.GetAutoCodeFormat(tmpWHT.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(ptn, tmpWHT)
      Dim lastCode As String = tmpWHT.GetLastCode(pattern)
      'tmpWHT.GetNextCode()

      For Each wht As WitholdingTax In Me
        If wht.AutoGen Then
          Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, wht)
          While wht.DuplicateCode(newCode)
            newCode = CodeGenerator.Generate(ptn, newCode, wht)
          End While
          wht.Code = newCode
          lastCode = newCode
        End If
      Next
    End Sub
    Private Function GetFirstAutogenWHT() As WitholdingTax
      For Each wht As WitholdingTax In Me
        If wht.AutoGen Then
          Return wht
        End If
      Next
    End Function
    Private Function GetCurrencyConversion() As Decimal
      If TypeOf Me.RefDoc Is IHasCurrency Then
        Return CType(Me.RefDoc, IHasCurrency).Currency.Conversion
      End If
      Return 1
    End Function
    Public Function GetConvertedRefdocMaximumTaxBase() As Decimal
      Return Me.RefDoc.GetMaximumWitholdingTaxBase * GetCurrencyConversion()
    End Function
    Public Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
      If wht_refDoc Is Nothing Then
        'UNDONE
        Return New SaveErrorException("WHTRefdoc IS NOTHING.")
      End If

      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

      Dim refSequenceNo As Boolean = False
      Dim refTaxBase As Decimal = 0
      If TypeOf wht_refDoc Is ReceiveSelection Then
        If Me.WitholdingTaxbase > GetConvertedRefdocMaximumTaxBase Then
          If Not myMessage.AskQuestionFormatted("${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.ExceededTaxBase}", _
                                                New String() { _
                                                  Configuration.FormatToString(Me.WitholdingTaxbase, DigitConfig.Price), _
                                                  Configuration.FormatToString(GetConvertedRefdocMaximumTaxBase, DigitConfig.Price) _
                                                }) Then
            Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
          End If
        End If
      ElseIf TypeOf wht_refDoc Is PaySelection Then
        If Me.WitholdingTaxbase > GetConvertedRefdocMaximumTaxBase Then
          If Not myMessage.AskQuestionFormatted("${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.ExceededTaxBase}", _
                                                New String() { _
                                                  Configuration.FormatToString(Me.WitholdingTaxbase, DigitConfig.Price), _
                                                  Configuration.FormatToString(GetConvertedRefdocMaximumTaxBase, DigitConfig.Price) _
                                                }) Then
            Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
          End If
        End If
      Else
        If Me.Amount > GetConvertedRefdocMaximumTaxBase Then
          If Not myMessage.AskQuestionFormatted("${res:Longkong.Pojjaman.BusinessLogic.WitholdingTax.ExceededTaxBase}", _
                                                  New String() { _
                                                    Configuration.FormatToString(Me.Amount, DigitConfig.Price), _
                                                    Configuration.FormatToString(GetConvertedRefdocMaximumTaxBase, DigitConfig.Price) _
                                                  }) Then
            Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
          End If
        End If
      End If
      Dim whtsToRemove As New ArrayList
      For Each wht As WitholdingTax In Me
        If wht.MaxRowIndex < 0 Then
          whtsToRemove.Add(wht)
        End If
      Next
      For Each wht As WitholdingTax In whtsToRemove
        Me.Remove(wht)
      Next
      GenCode()

      If Not TypeOf Me.RefDoc Is ICanDelayWHT AndAlso Not Me.IsBeforePay Then
        For Each wht As WitholdingTax In Me
          If wht.DuplicateCode(wht.Code) Then
            Return New SaveErrorException("${res:Global.Error.AlreadyHasThisCode}", New String() {wht.Code})
          End If
        Next
      End If


      Try
        Dim refDocType As Integer
        If TypeOf wht_refDoc Is ISimpleEntity Then
          refDocType = CType(wht_refDoc, ISimpleEntity).EntityId
        End If

        Dim payee As SimpleBusinessEntityBase
        If Not wht_refDoc.Person Is Nothing AndAlso TypeOf wht_refDoc.Person Is SimpleBusinessEntityBase Then
          payee = CType(wht_refDoc.Person, SimpleBusinessEntityBase)
        End If

        Dim theTime As Date = Now
        Dim theUserId As Integer = currentUserId

        Dim daWHT As New SqlDataAdapter("Select * from witholdingtax where wht_refdoc=" & wht_refDoc.Id & " and wht_refdoctype =" & refDocType, conn)
        Dim daWHTItem As New SqlDataAdapter("select * from witholdingtaxitem where whti_wht in (Select wht_id from witholdingtax where wht_refdoc=" & wht_refDoc.Id & " and wht_refdoctype =" & refDocType & ")", conn)

        Dim ds As New DataSet

        '***********----WHT ----****************
        Dim cb As New SqlCommandBuilder(daWHT)
        daWHT.SelectCommand.Transaction = trans

        daWHT.DeleteCommand = cb.GetDeleteCommand
        daWHT.DeleteCommand.Transaction = trans

        daWHT.InsertCommand = cb.GetInsertCommand
        daWHT.InsertCommand.Transaction = trans

        daWHT.UpdateCommand = cb.GetUpdateCommand
        daWHT.UpdateCommand.Transaction = trans

        daWHT.InsertCommand.CommandText &= "; Select * From witholdingtax Where wht_id= @@IDENTITY"
        daWHT.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cb = Nothing

        daWHT.FillSchema(ds, SchemaType.Mapped, "wht")
        daWHT.Fill(ds, "wht")
        '***********----END WHT ----****************

        '***********----Item ----****************
        cb = New SqlCommandBuilder(daWHTItem)
        daWHTItem.SelectCommand.Transaction = trans

        daWHTItem.DeleteCommand = cb.GetDeleteCommand
        daWHTItem.DeleteCommand.Transaction = trans

        daWHTItem.InsertCommand = cb.GetInsertCommand
        daWHTItem.InsertCommand.Transaction = trans

        daWHTItem.UpdateCommand = cb.GetUpdateCommand
        daWHTItem.UpdateCommand.Transaction = trans
        cb = Nothing

        daWHTItem.FillSchema(ds, SchemaType.Mapped, "whtitem")
        daWHTItem.Fill(ds, "whtitem")
        ds.Relations.Add("wht_whtitem", ds.Tables!wht.Columns!wht_id, ds.Tables!whtitem.Columns!whti_wht)
        '***********---- END Item ----****************


        Dim dtWHT As DataTable = ds.Tables("wht")
        Dim dtWHTItem As DataTable = ds.Tables("whtitem")

        Dim dc As DataColumn
        dc = dtWHT.Columns!wht_id
        dc.AutoIncrement = True
        dc.AutoIncrementSeed = Integer.MaxValue
        dc.AutoIncrementStep = -1

        Dim tmpWHTDa As New SqlDataAdapter
        tmpWHTDa.DeleteCommand = daWHT.DeleteCommand
        tmpWHTDa.InsertCommand = daWHT.InsertCommand
        tmpWHTDa.UpdateCommand = daWHT.UpdateCommand

        AddHandler tmpWHTDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWHTItem.RowUpdated, AddressOf daWHTitem_MyRowUpdated

        'ลบ Item ทั้งหมด
        For Each dr As DataRow In dtWHTItem.Rows
          dr.Delete()
        Next

        '---------------ลบ WHT ---------------------------
        Dim rowsToDelete As New ArrayList
        For Each dr As DataRow In dtWHT.Rows
          Dim found As Boolean = False
          For Each testWHT As WitholdingTax In Me
            If testWHT.Id = CInt(dr("wht_id")) Then
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
        '---------------END ลบ WHT ---------------------------

        For Each wht As WitholdingTax In Me
          If wht.SequenceNo.AutoGen Then
            Dim obj As Object = Entity.GetAutoCodeFormat(wht.EntityId)
            If obj Is Nothing OrElse CStr(obj).Length = 0 Then
              wht.SequenceNo.Code = ""
            Else
              wht.SequenceNo.Code = wht.SequenceNo.GetNextCode
            End If
          End If

          Dim drWHT As DataRow
          If Not wht.Originated OrElse Not wht.RefDoc Is Me.RefDoc Then
            drWHT = dtWHT.NewRow
          Else
            Dim rows() As DataRow = dtWHT.Select("wht_id=" & wht.Id)
            If rows.Length = 1 Then
              drWHT = dtWHT.Select("wht_id=" & wht.Id)(0)
            End If
          End If
          drWHT("wht_code") = wht.Code
          drWHT("wht_bookNo") = wht.BookNo
          drWHT("wht_docDate") = wht.ValidDateOrDBNull(wht.DocDate)
          drWHT("wht_SequenceNo") = wht.SequenceNo

          drWHT("wht_refDocType") = refDocType
          drWHT("wht_refdoc") = IIf(wht_refDoc.Id <> 0, wht_refDoc.Id, DBNull.Value)
          drWHT("wht_refDocCode") = wht_refDoc.Code
          drWHT("wht_refDocDate") = wht_refDoc.Date

          If Not payee Is Nothing Then
            drWHT("wht_entity") = wht.ValidIdOrDBNull(payee)
            drWHT("wht_entityType") = payee.EntityId
          End If

          drWHT("wht_printname") = wht.PrintName
          drWHT("wht_entityAddress") = wht.EntityAddress
          drWHT("wht_entitytaxid") = wht.EntityTaxId
          drWHT("wht_entityidno") = wht.EntityIdNo

          drWHT("wht_taxbase") = wht.TaxBase
          drWHT("wht_amt") = wht.Amount
          drWHT("wht_note") = wht.Note


          drWHT("wht_direction") = wht.Direction.Value
          drWHT("wht_status") = wht.Status.Value
          drWHT("wht_type") = wht.Type.Value
          drWHT("wht_paymenttype") = wht.PaymentType.Value
          drWHT("wht_otherpaymenttype") = wht.PaymentType.OtherPaymentType

          drWHT("wht_representName") = wht.RepresentName
          drWHT("wht_representAddress") = wht.RepresentAddress
          drWHT("wht_representTaxId") = wht.RepresentTaxId
          drWHT("wht_representIdNo") = wht.RepresentIdNo
          drWHT("wht_employerAcct") = wht.EmployerAcct
          drWHT("wht_employeeSSN") = wht.EmployeeSSN
          drWHT("wht_CompanySupport") = wht.CompanySupport
          drWHT("wht_license") = wht.License
          drWHT("wht_cumulative") = wht.Cumulative

          drWHT("wht_delayed") = Me.IsBeforePay

          wht.SetOriginEditCancelStatus(drWHT, theTime, currentUserId)

          If Not wht.Originated OrElse Not wht.RefDoc Is Me.RefDoc Then
            dtWHT.Rows.Add(drWHT)
          End If

          Dim i As Integer = 0
          For n As Integer = 0 To wht.MaxRowIndex
            Dim item As TreeRow = wht.ItemTable.Childs(n)
            If wht.ValidateRow(item) Then
              i += 1
              Dim drItem As DataRow = dtWHTItem.NewRow
              drItem("whti_wht") = drWHT("wht_id")
              drItem("whti_linenumber") = i
              drItem("whti_description") = item("whti_description")
              If IsNumeric(item("whti_taxrate")) Then
                drItem("whti_taxrate") = item("whti_taxrate")
              End If
              drItem("whti_taxbase") = item("whti_taxbase")
              drItem("whti_amt") = item("Amount")
              drItem("whti_note") = item("whti_note")
              drItem("whti_cc") = Me.CCId 'item("whti_cc")
              drItem("whti_type") = item("whti_type")
              If drItem.IsNull("whti_type") Then
                drItem("whti_type") = 0
              End If
              dtWHTItem.Rows.Add(drItem)
            End If
          Next
        Next

        daWHTItem.Update(GetDeletedRows(dtWHTItem))
        tmpWHTDa.Update(GetDeletedRows(dtWHT))

        tmpWHTDa.Update(dtWHT.Select("", "", DataViewRowState.ModifiedCurrent))
        daWHTItem.Update(dtWHTItem.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpWHTDa.Update(dtWHT.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWHTItem.Update(dtWHTItem.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True

        'Dim theId As Integer = Me.Id
        'If Not Me.Originated Then
        '    theId = CInt(drWHT("WHT_id"))
        'End If
        'If Not Me.Originated Then
        '    Me.Id = CInt(drWHT("WHT_id"))
        'End If
        Return New SaveErrorException("0")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daWHTitem_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then
        e.Status = UpdateStatus.SkipCurrentRow
        Dim currentkey As Object = e.Row("whti_wht")
        e.Row!whti_wht = e.Row.GetParentRow("wht_whtitem")("wht_id", DataRowVersion.Original)
        e.Row.AcceptChanges()
        e.Row!whti_wht = currentkey
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

#Region "Collection Methods"
    ''' <summary>
    ''' เปลี่ยนแปลง GL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetRefDocGLChange()
      If Not m_wht Is Nothing Then
        If TypeOf m_wht.RefDoc Is SimpleBusinessEntityBase Then
          CType(m_wht.RefDoc, SimpleBusinessEntityBase).OnGlChanged()
        End If
      End If
    End Sub
    Public Function Add(ByVal value As WitholdingTax) As Integer
      value.Direction = Me.Direction
      Return MyBase.List.Add(value)
      SetRefDocGLChange()
    End Function
    Public Function Contains(ByVal value As WitholdingTax) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As WitholdingTax(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Function IndexOf(ByVal value As WitholdingTax) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As WitholdingTax)
      value.Direction = Me.Direction
      MyBase.List.Insert(index, value)
      SetRefDocGLChange()
    End Sub
    Public Sub Remove(ByVal value As WitholdingTax)
      MyBase.List.Remove(value)
      SetRefDocGLChange()
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
      SetRefDocGLChange()
    End Sub
#End Region

  End Class

  Public Class WitholdingTaxItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "whti_type"
      End Get
    End Property
#End Region

  End Class
  Public Class WitholdingTaxItem
    Implements IHasToCostCenter, IHasFromCostCenter

#Region "Members"
    Private m_witholdingTax As WitholdingTax
    Private m_lineNumber As Integer
    Private m_description As String
    Private m_taxBase As Decimal
    Private m_taxRate As Decimal
    Private m_taxAmt As Decimal
    Private m_useCustomTaxAmt As Boolean
    Private m_note As String
    Private m_ccId As Integer
    Private m_type As WitholdingTaxItemType
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "whti_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "whti_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "whti_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "whti_taxrate") AndAlso Not dr.IsNull(aliasPrefix & "whti_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "whti_taxrate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "whti_taxbase") AndAlso Not dr.IsNull(aliasPrefix & "whti_taxbase") Then
          .m_taxBase = CDec(dr(aliasPrefix & "whti_taxbase"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "whti_amt") AndAlso Not dr.IsNull(aliasPrefix & "whti_amt") Then
          .m_taxAmt = CDec(dr(aliasPrefix & "whti_amt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "whti_note") AndAlso Not dr.IsNull(aliasPrefix & "whti_note") Then
          .m_note = CStr(dr(aliasPrefix & "whti_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "whti_description") AndAlso Not dr.IsNull(aliasPrefix & "whti_description") Then
          .m_description = CStr(dr(aliasPrefix & "whti_description"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "whti_cc") AndAlso Not dr.IsNull(aliasPrefix & "whti_cc") Then
          .m_ccId = CInt(dr(aliasPrefix & "whti_cc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "whti_type") AndAlso Not dr.IsNull(aliasPrefix & "whti_type") Then
          .m_type = New WitholdingTaxItemType(CInt(dr(aliasPrefix & "whti_type")))
        End If

        Me.UseCustomTaxAmount = True
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property WitholdingTax() As WitholdingTax
      Get
        Return m_witholdingTax
      End Get
      Set(ByVal Value As WitholdingTax)
        m_witholdingTax = Value
      End Set
    End Property
    Public Property Type() As WitholdingTaxItemType
      Get
        Return m_type
      End Get
      Set(ByVal Value As WitholdingTaxItemType)
        m_type = Value
        SetRefDocGLChange()
      End Set
    End Property
    Public Property LineNumber() As Integer
      Get
        Return m_lineNumber
      End Get
      Set(ByVal Value As Integer)
        m_lineNumber = Value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return m_description
      End Get
      Set(ByVal Value As String)
        m_description = Value
      End Set
    End Property
    Public Property TaxBase() As Decimal
      Get
        Return m_taxBase
      End Get
      Set(ByVal Value As Decimal)
        m_taxBase = Value
      End Set
    End Property
    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        m_taxRate = Value
      End Set
    End Property
    Public Property UseCustomTaxAmount() As Boolean
      Get
        Return m_useCustomTaxAmt
      End Get
      Set(ByVal Value As Boolean)
        m_useCustomTaxAmt = Value
        SetRefDocGLChange()
      End Set
    End Property
    Public Property Amount() As Decimal
      Get
        ' ถ้ากำหนด TaxAmount เอง
        If UseCustomTaxAmount Then
          Return m_taxAmt
        Else
          Return Configuration.Format((Me.m_taxBase * Me.m_taxRate) / 100, DigitConfig.Price)
        End If
      End Get
      Set(ByVal Value As Decimal)
        m_taxAmt = Value
        SetRefDocGLChange()
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
    Public Property CCId() As Integer
      Get
        Return m_ccId
      End Get
      Set(ByVal Value As Integer)
        m_ccId = Value
      End Set
    End Property
    Public ReadOnly Property CostCenter() As CostCenter
      Get
        Return New CostCenter(m_ccId)
      End Get
    End Property
    ''' <summary>
    ''' เปลี่ยนแปลง GL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetRefDocGLChange()
      If Not m_witholdingTax Is Nothing Then
        If TypeOf m_witholdingTax.RefDoc Is SimpleBusinessEntityBase Then
          CType(m_witholdingTax.RefDoc, SimpleBusinessEntityBase).OnGlChanged()
        End If
      End If
    End Sub
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.WitholdingTax.IsInitialized = False
      row("whti_linenumber") = Me.LineNumber
      row("whti_description") = Me.Description
      row("useCustomAmt") = Me.UseCustomTaxAmount
      If Me.Amount = 0 Then
        row("Amount") = ""
      Else
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      End If
      If Me.TaxRate = 0 Then
        row("whti_taxrate") = ""
      Else
        row("whti_taxrate") = Configuration.FormatToString(Me.TaxRate, DigitConfig.Price)
      End If
      If Me.TaxBase = 0 Then
        row("whti_taxbase") = ""
      Else
        row("whti_taxbase") = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      End If
      row("whti_realtaxbase") = Me.TaxBase
      row("whti_note") = Me.Note
      row("whti_cc") = Me.CCId
      If Not Me.Type Is Nothing Then
        row("whti_type") = Me.Type.Value
      End If
      Me.WitholdingTax.IsInitialized = True
    End Sub
    Public Sub CopyToDataRow2(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.WitholdingTax.IsInitialized = False
      row("whti_linenumber") = Me.LineNumber
      row("wht_code") = Me.WitholdingTax.Code
      row("wht_type") = Me.WitholdingTax.Type.GetDescription(Me.WitholdingTax.Type.CodeName, Me.WitholdingTax.Type.Value)
      row("wht_type_id") = Me.WitholdingTax.Type.Value
      row("wht_paymenttype") = Me.WitholdingTax.PaymentType.GetDescription(Me.WitholdingTax.PaymentType.CodeName, Me.WitholdingTax.PaymentType.Value)
      If Me.WitholdingTax.PaymentType.Value = 4 Then
        row("wht_paymenttype_id") = 5
      ElseIf Me.WitholdingTax.PaymentType.Value = 5 Then
        row("wht_paymenttype_id") = 4
      Else
        row("wht_paymenttype_id") = Me.WitholdingTax.PaymentType.Value
      End If
      row("whti_description") = Me.Description
      row("whti_taxrate") = Me.TaxRate
      row("whti_taxbase") = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      row("whti_realtaxbase") = Me.TaxBase
      row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      'row("AfterVat") = Configuration.FormatToString(Me.TaxBase * 107 / 100, DigitConfig.Price) 'แก้ 107 ด้วย
      Me.WitholdingTax.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("whti_linenumber")) Then
          Me.LineNumber = CInt(row("whti_linenumber"))
        End If
        If Not row.IsNull(("whti_taxrate")) Then
          If CStr(row("whti_taxrate")).Length = 0 Then
            Me.TaxRate = 0
          Else
            Me.TaxRate = CDec(row("whti_taxrate"))
          End If
        End If
        If IsNumeric(row(("whti_realtaxbase"))) Then
          Me.TaxBase = CDec(row("whti_realtaxbase"))
        End If
        If Not row.IsNull("useCustomAmt") Then
          Me.UseCustomTaxAmount = CBool(row("useCustomAmt"))
        End If
        If IsNumeric(row(("Amount"))) Then
          Me.Amount = CDec(row("Amount"))
        End If
        If Not row.IsNull(("whti_description")) Then
          Me.Description = CStr(row("whti_description"))
        End If
        If Not row.IsNull(("whti_note")) Then
          Me.Note = CStr(row("whti_note"))
        End If
        If Not row.IsNull(("whti_cc")) Then
          Me.CCId = CInt(row("whti_cc"))
        End If
        If Not row.IsNull(("whti_type")) Then
          Me.Type = New WitholdingTaxItemType(CInt(row("whti_type")))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
#End Region

    Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property

    Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
      Get
        Return Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property
  End Class

  Public Class WitholdingTaxSequence
    Inherits SimpleBusinessEntityBase

    Public Sub New()
      MyBase.New()
    End Sub

    Public Property LastestCode() As String

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "WitholdingTaxSequence"
      End Get
    End Property

    Public Overrides Function GetLastCode(ByVal prefixPattern As String) As String
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select top 1 wht_SequenceNo from WitholdingTax where wht_SequenceNo like '" & prefixPattern & "%' " & " order by wht_id desc"

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql

      Dim obj As Object = cmd.ExecuteScalar
      If Not IsDBNull(obj) AndAlso Not obj Is Nothing Then
        Return obj.ToString
      End If
      Return ""
    End Function

    Public Overrides Function DuplicateCode(ByVal newCode As String) As Boolean
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select count(*) from WitholdingTax where wht_SequenceNo='" & newCode & "' and wht_id <> " & Me.Id

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql
      Dim recordCount As Object = cmd.ExecuteScalar
      conn.Close()
      If Not IsDBNull(recordCount) AndAlso CInt(recordCount) > 0 Then
        Return True
      End If
      Return False
    End Function

  End Class
End Namespace
