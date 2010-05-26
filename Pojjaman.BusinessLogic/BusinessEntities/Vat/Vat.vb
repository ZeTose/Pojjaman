Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports System.Reflection
Namespace Longkong.Pojjaman.BusinessLogic

  Public Class VatDirection
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "vat_direction"
      End Get
    End Property
#End Region

  End Class

  Public Class Vat
    Inherits SimpleBusinessEntityBase
		Implements IPrintableEntity, IHasMainDoc

#Region "Members"
    Private vat_note As String
    Private vat_refDoc As IVatable
    Private vat_direction As VatDirection

    Private vat_entity As IBillablePerson
    Private vat_printName As String
    Private vat_entityAddress As String
    Private vat_entityTaxId As String
    Private vat_entityIdNo As String

    Private m_itemCollection As VatItemCollection

    Private vat_taxbase As Decimal

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
    Public Sub New(ByVal refDoc As IVatable)
      Me.New(refDoc.Id, CType(refDoc, IObjectReflectable).EntityId)
			Me.RefDoc = refDoc
			Me.Entity = refDoc.Person
    End Sub
    Public Sub New(ByVal refId As Integer, ByVal refType As Integer)
      If refId = 0 Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetVat" _
      , New SqlParameter("@vat_refDoc", refId), New SqlParameter("@vat_refDocType", refType))
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
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .vat_refDoc = New GenericVatble
        .vat_refDoc.Id = 0
        .vat_refDoc.Date = Date.MinValue
        .vat_refDoc.Code = ""
        .vat_direction = New VatDirection(0)
      End With
      m_itemCollection = New VatItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "vat_note") AndAlso Not dr.IsNull(aliasPrefix & "vat_note") Then
          .vat_note = CStr(dr(aliasPrefix & "vat_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vat_direction") AndAlso Not dr.IsNull(aliasPrefix & "vat_direction") Then
          .vat_direction = New VatDirection(CInt(dr(aliasPrefix & "vat_direction")))
        End If

        Dim refDocType As Integer
        Dim refDocId As Integer
        Dim refDocCode As String
        Dim refDocDate As Date
        If dr.Table.Columns.Contains(aliasPrefix & "vat_refDocType") AndAlso Not dr.IsNull(aliasPrefix & "vat_refDocType") Then
          refDocType = CInt(dr(aliasPrefix & "vat_refDocType"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vat_refdoc") AndAlso Not dr.IsNull(aliasPrefix & "vat_refdoc") Then
          refDocId = CInt(dr(aliasPrefix & "vat_refdoc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vat_refdoccode") AndAlso Not dr.IsNull(aliasPrefix & "vat_refdoccode") Then
          refDocCode = CStr(dr(aliasPrefix & "vat_refdoccode"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vat_refdocdate") AndAlso Not dr.IsNull(aliasPrefix & "vat_refdocdate") Then
          refDocDate = CDate(dr(aliasPrefix & "vat_refdocdate"))
        End If

        Dim entityType As Integer
        Dim entityId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "vat_entityType") AndAlso Not dr.IsNull(aliasPrefix & "vat_entityType") Then
          entityType = CInt(dr(aliasPrefix & "vat_entityType"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vat_entity") AndAlso Not dr.IsNull(aliasPrefix & "vat_entity") Then
          entityId = CInt(dr(aliasPrefix & "vat_entity"))
        End If
        .vat_entity = CType(SimpleBusinessEntityBase.GetEntity(Longkong.Pojjaman.BusinessLogic.Entity.GetFullClassName(entityType), entityId), IBillablePerson)

        If dr.Table.Columns.Contains(aliasPrefix & "vat_entityAddress") AndAlso Not dr.IsNull(aliasPrefix & "vat_entityAddress") Then
          .vat_entityAddress = CStr(dr(aliasPrefix & "vat_entityAddress"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vat_printName") AndAlso Not dr.IsNull(aliasPrefix & "vat_printName") Then
          .vat_printName = CStr(dr(aliasPrefix & "vat_printName"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vat_entityTaxId") AndAlso Not dr.IsNull(aliasPrefix & "vat_entityTaxId") Then
          .vat_entityTaxId = CStr(dr(aliasPrefix & "vat_entityTaxId"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vat_entityIdNo") AndAlso Not dr.IsNull(aliasPrefix & "vat_entityIdNo") Then
          .vat_entityIdNo = CStr(dr(aliasPrefix & "vat_entityIdNo"))
        End If
        'If dr.Table.Columns.Contains(aliasPrefix & "vat_taxbase") AndAlso Not dr.IsNull(aliasPrefix & "vat_taxbase") Then
        '    .vat_taxbase = CDec(dr(aliasPrefix & "vat_taxbase"))
        'End If

      End With
      m_itemCollection = New VatItemCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
		Public ReadOnly Property Maindoc() As ISimpleEntity Implements IHasMainDoc.MainDoc
			Get
				Return CType(vat_refDoc, ISimpleEntity)
			End Get
		End Property
		Public Property ItemCollection() As VatItemCollection
			Get
				Return m_itemCollection
			End Get
			Set(ByVal Value As VatItemCollection)
				m_itemCollection = Value
			End Set
		End Property
		Public Property Note() As String
			Get
				Return vat_note
			End Get
			Set(ByVal Value As String)
				vat_note = Value
			End Set
		End Property
		Public Property RefDoc() As IVatable
			Get
				Return vat_refDoc
			End Get
			Set(ByVal Value As IVatable)
				vat_refDoc = Value
			End Set
		End Property
		Private Function MinDateToNow(ByVal theDate As Date) As Date
			If theDate.Equals(Date.MinValue) Then
				Return Now
			End If
			Return theDate
		End Function
		Public Property SubmitalDate() As Date
			Get
				If Not Me.Originated AndAlso Not Me.RefDoc Is Nothing Then
					Return MinDateToNow(Me.RefDoc.Date)
				End If
				If Me.ItemCollection.Count > 0 Then
					Dim item As VatItem = Me.ItemCollection(0)
					Return MinDateToNow(item.SubmitalDate)
				End If
				Return Now.Date
			End Get
			Set(ByVal Value As Date)
				For Each item As VatItem In Me.ItemCollection
					item.SubmitalDate = Value
				Next
			End Set
		End Property
		Public Property VatGroup() As VatGroup
			Get
				If Me.ItemCollection.Count > 0 Then
					Dim item As VatItem = Me.ItemCollection(0)
					Return item.VatGroup
				End If
				Return New VatGroup
			End Get
			Set(ByVal Value As VatGroup)
				For Each item As VatItem In Me.ItemCollection
					item.VatGroup = Value
				Next
			End Set
		End Property
		''' -----------------------------------------------------------------------------
		''' <summary>
		''' ระบุว่าเป็นภาษีซื้อหรือขาย
		''' 1=ซื้อ
		''' 2=ขาย
		''' </summary>
		''' <value></value>
		''' <remarks>
		''' </remarks>
		''' <history>
		''' 	[KRISS]	09/01/2549	Created
		''' </history>
		''' -----------------------------------------------------------------------------
		Public Property Direction() As VatDirection
			Get
				Return vat_direction
			End Get
			Set(ByVal Value As VatDirection)
				vat_direction = Value
			End Set
		End Property
		Public Property Entity() As IBillablePerson
			Get
				Return vat_entity
			End Get
			Set(ByVal Value As IBillablePerson)
				vat_entity = Value
			End Set
		End Property
		Public Property PrintName() As String
			Get
				Return vat_printName
			End Get
			Set(ByVal Value As String)
				vat_printName = Value
			End Set
		End Property
		Public Property EntityAddress() As String
			Get
				Return vat_entityAddress
			End Get
			Set(ByVal Value As String)
				vat_entityAddress = Value
			End Set
		End Property
		Public Property EntityTaxId() As String
			Get
				Return vat_entityTaxId
			End Get
			Set(ByVal Value As String)
				vat_entityTaxId = Value
			End Set
		End Property
		Public Property EntityIdNo() As String
			Get
				Return vat_entityIdNo
			End Get
			Set(ByVal Value As String)
				vat_entityIdNo = Value
			End Set
		End Property
		Public ReadOnly Property TaxBase() As Decimal
			Get
				Dim sumTaxBase As Decimal = 0
				For Each item As VatItem In Me.ItemCollection
					sumTaxBase += Configuration.Format(item.TaxBase, DigitConfig.Price)
				Next
				Return sumTaxBase
			End Get
		End Property
		Public ReadOnly Property Amount() As Decimal
			Get
				Dim sumAmount As Decimal = 0
				For Each item As VatItem In Me.ItemCollection
					sumAmount += Configuration.Format(item.Amount, DigitConfig.Price)
				Next
				Return Configuration.Format(sumAmount, DigitConfig.Price)
			End Get
		End Property
		Public Property VatTaxBase() As Decimal
			Get
				Return Me.vat_taxbase
			End Get
			Set(ByVal Value As Decimal)
				Me.vat_taxbase = Value
			End Set
		End Property
		Public Overrides ReadOnly Property GetListSprocName() As String
			Get
				Return "GetVatList"
			End Get
		End Property
		Public Overrides ReadOnly Property GetSprocName() As String
			Get
				Return "GetVat"
			End Get
		End Property
		Public Overrides ReadOnly Property ClassName() As String
			Get
				Return "Vat"
			End Get
		End Property
		Public Overrides ReadOnly Property TableName() As String
			Get
				Return "Vat"
			End Get
		End Property
		Public Overrides ReadOnly Property Prefix() As String
			Get
				Return "vat"
			End Get
		End Property

		Public Overrides ReadOnly Property DetailPanelTitle() As String
			Get
				Return "${res:Longkong.Pojjaman.BusinessLogic.Vat.DetailLabel}"
			End Get
		End Property
		Public Overrides ReadOnly Property DetailPanelIcon() As String
			Get
				Return "Icons.16x16.Vat"
			End Get
		End Property
		Public Overrides ReadOnly Property ListPanelIcon() As String
			Get
				Return "Icons.16x16.Vat"
			End Get
		End Property
		Public Overrides ReadOnly Property ListPanelTitle() As String
			Get
				Return "${res:Longkong.Pojjaman.BusinessLogic.Vat.ListLabel}"
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
    Public Shared Function GetTaxBaseDeductedWithoutThisRefDoc(ByVal vati_refdoc As Integer _
  , ByVal vati_refdoctype As Integer, ByVal vat_refdoc As Integer, ByVal vat_refdoctype As Integer) As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetTaxBaseDeductedWithoutThisRefDoc" _
      , New SqlParameter("@vati_refdoc", vati_refdoc) _
      , New SqlParameter("@vati_refdoctype", vati_refdoctype) _
      , New SqlParameter("@vat_refdoc", vat_refdoc) _
      , New SqlParameter("@vat_refdoctype", vat_refdoctype) _
      )
      If ds.Tables(0).Rows.Count = 1 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
		Public Shared Function GetSchemaTable() As TreeTable
			Dim myDatatable As New TreeTable("Vat")
			myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
			myDatatable.Columns.Add(New DataColumn("vati_linenumber", GetType(Integer)))
			myDatatable.Columns.Add(New DataColumn("vati_code", GetType(String)))

			Dim dateCol As New DataColumn("vati_docdate", GetType(Date))
			dateCol.DefaultValue = Date.MinValue
			myDatatable.Columns.Add(dateCol)
			myDatatable.Columns.Add(New DataColumn("vati_runnumber", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("SupplierButton", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("vati_printName", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("vati_printaddress", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("vati_taxbase", GetType(String)))		'เอาไว้แสดง
			myDatatable.Columns.Add(New DataColumn("vati_realtaxbase", GetType(Decimal)))		 'เก็บค่าเต็มๆ
			myDatatable.Columns.Add(New DataColumn("vati_taxrate", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("useCustomAmt", GetType(Boolean)))
			myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("vati_note", GetType(String)))
			myDatatable.Columns.Add(New DataColumn("vati_cc", GetType(Integer)))

			myDatatable.Columns.Add(New DataColumn("vati_submitaldate", GetType(Date)))
			myDatatable.Columns.Add(New DataColumn("vati_group", GetType(Integer)))

			myDatatable.Columns.Add(New DataColumn("vati_refdoc", GetType(Integer)))
			myDatatable.Columns.Add(New DataColumn("vati_refdoctype", GetType(Integer)))

			Return myDatatable
		End Function

		Public Shared Function GetExcludedVatAmount(ByVal valueIncludedVat As Decimal) As Decimal
			Dim vatRate As Decimal = CDec(Configuration.GetConfig("CompanyTaxRate"))
			Return GetExcludedVatAmount(valueIncludedVat, vatRate)
		End Function
		Public Shared Function GetExcludedVatAmount(ByVal valueIncludedVat As Decimal, ByVal vatRate As Decimal) As Decimal
			Return Configuration.Format((valueIncludedVat / (vatRate + 100)) * 100, DigitConfig.Price)
		End Function
		Public Shared Function GetExcludedVatAmountWithoutRound(ByVal valueIncludedVat As Decimal, ByVal vatRate As Decimal) As Decimal
			Return (valueIncludedVat / (vatRate + 100)) * 100
		End Function

		Public Shared Function GetVatAmount(ByVal valueBeforeVat As Decimal) As Decimal
			Dim vatRate As Decimal = CDec(Configuration.GetConfig("CompanyTaxRate"))
			Return GetVatAmount(valueBeforeVat, vatRate)
		End Function

		Public Shared Function GetVatAmount(ByVal valueBeforeVat As Decimal, ByVal vatRate As Decimal) As Decimal
			Return (valueBeforeVat * vatRate) / 100
		End Function
#End Region

#Region "Methods"
		Public Sub SetCCId(ByVal ccId As Integer)
			For Each item As VatItem In Me.ItemCollection
				item.CcId = ccId
			Next
		End Sub
		Public Sub SetRefDocToItem(ByVal vati_refdoc As Integer, ByVal vati_refdocType As Integer)
			For Each item As VatItem In Me.ItemCollection
				item.Refdoc = vati_refdoc
				item.RefdocType = vati_refdocType
			Next
		End Sub
		Public Function GetVatItemCodes() As String
			Dim ret As String = ""
			For Each item As VatItem In Me.ItemCollection
				ret &= item.Code & ","
			Next
			If ret.Length > 0 Then
				ret = ret.TrimEnd(","c)
			End If
			Return ret
		End Function

		Public Function GetVatItemDates() As String
			Dim ret As String = ""
			For Each item As VatItem In Me.ItemCollection
				ret &= item.DocDate.ToShortDateString & ","
			Next
			If ret.Length > 0 Then
				ret = ret.TrimEnd(","c)
			End If
			Return ret
		End Function

		Public Function GetVatItemNotes() As String
			Dim ret As String = ""
			For Each item As VatItem In Me.ItemCollection
				ret &= item.Note & ","
			Next
			If ret.Length > 0 Then
				ret = ret.TrimEnd(","c)
			End If
			Return ret
		End Function
		Private Sub ResetID(ByVal oldid As Integer)
			Me.Id = oldid
		End Sub
		Private Function DupInside(ByVal target As VatItem) As String
			For Each item As VatItem In Me.ItemCollection
				If Not item Is target Then
					If item.Code.ToLower = target.Code.ToLower Then
						Return item.Code
					End If
				End If
			Next
			Return ""
		End Function
		Private Function DupCode() As String
			For Each item As VatItem In Me.ItemCollection
				If DupInside(item).Length > 0 Then
					Return item.Code
				End If
				Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString()
				Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
										, CommandType.StoredProcedure _
										, "GetDupVatCode" _
										, New SqlParameter("@vati_code", item.Code) _
										, New SqlParameter("@vat_supplier", Me.Entity.Id) _
										, New SqlParameter("@vat_id", Me.Id) _
										)
				If ds.Tables(0).Rows.Count > 0 Then
					Return item.Code
				End If
			Next
			Return ""
    End Function
    Private Function DupSalesVatCode() As String
      Dim codes As String = ""
      For Each item As VatItem In Me.ItemCollection
        If DupInside(item).Length > 0 Then
          Return item.Code
        End If
        codes &= "|" & item.Code & "|"
      Next
      Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
            , CommandType.StoredProcedure _
            , "GetDupSalesVatCode" _
            , New SqlParameter("@vati_code", codes) _
            , New SqlParameter("@vat_id", Me.Id) _
            )
      If ds.Tables(0).Rows.Count > 0 Then
        Return ds.Tables(0).Rows(0)("vati_code").ToString
      End If
      Return ""
    End Function
		Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
			With Me
				Dim o As Object = Configuration.GetConfig("NoDupSupplierDoc")
				If Not o Is Nothing Then
					Dim config As Boolean = CBool(o)
					If config AndAlso Me.Direction.Value = 1 Then
						Dim theDup As String = DupCode()
						If theDup.Length > 0 Then
							Return New SaveErrorException("${res:Global.Error.VatCodeDuplicated}", theDup)
						End If
					End If
        End If

        '================Checking for duplicate Vat Code (Sales Tax) =============
        If Me.Direction.Value = 0 Then
          Dim salesVatDup As String = DupSalesVatCode()
          If salesVatDup.Length > 0 Then
            Return New SaveErrorException("${res:Global.Error.VatCodeDuplicated}", salesVatDup)
          End If
        End If
        '================Checking for duplicate Vat Code (Sales Tax) =============

				'Me.RefreshVatTaxBase()
				Dim tmpTaxBase As Decimal = Configuration.Format(Me.TaxBase, DigitConfig.Price)
				If Me.ItemCollection.Count <= 0 And tmpTaxBase > 0 Then
					Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
				End If

        Dim tmpRefTaxBase As Decimal = 0
        If TypeOf Me.RefDoc Is PaySelection Then
          Dim pays As PaySelection = CType(Me.RefDoc, PaySelection)
          tmpRefTaxBase = Configuration.Format(pays.RealTaxBase, DigitConfig.Price)
          'ถ้าใบจ่ายชำระนี้เป็นการแบ่งจ่ายชำระแล้ว จะไม่อนุญาติให้ออกใบกำกับภาษีมูลค่าเพิ่มที่เมนูจ่ายชำระแล้ว
          If tmpTaxBase > 0 AndAlso pays.Gross <> pays.ItemCollection.GetPlusRetention Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Vat.ValidVatAmount}"))
          End If
        Else
          tmpRefTaxBase = Configuration.Format(Me.RefDoc.GetMaximumTaxBase, DigitConfig.Price)
        End If

				If Me.Direction.Value = 0 AndAlso _
				tmpTaxBase - tmpRefTaxBase = -0.01 Then			'ยอดในใบกำกับน้อยกว่า
					If Me.ItemCollection.Count > 0 Then
						Dim item As VatItem = Me.ItemCollection(Me.ItemCollection.Count - 1)
						item.TaxBase += CDec(0.01 / (item.TaxRate / 100))
					End If
				ElseIf Me.Direction.Value = 0 AndAlso _
				tmpTaxBase - tmpRefTaxBase = 0.01 Then			'ยอดในใบกำกับมากกว่า
					If Me.ItemCollection.Count > 0 Then
						Dim item As VatItem = Me.ItemCollection(Me.ItemCollection.Count - 1)
						item.TaxBase -= CDec(0.01 / (item.TaxRate / 100))
					End If
        ElseIf _
        ( _
        TypeOf Me.RefDoc Is BillAcceptance _
        OrElse TypeOf Me.RefDoc Is GoodsReceipt _
        OrElse TypeOf Me.RefDoc Is PaySelection _
        OrElse TypeOf Me.RefDoc Is APOpeningBalance _
        OrElse TypeOf Me.RefDoc Is EqMaintenance _
        OrElse TypeOf Me.RefDoc Is GoodsSold _
        OrElse TypeOf Me.RefDoc Is PA _
        ) _
        AndAlso (tmpTaxBase > 0) AndAlso tmpTaxBase > tmpRefTaxBase Then
          Dim obj As Object = Configuration.GetConfig("VatAcceptDiffAmount")
          Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          If tmpTaxBase > tmpRefTaxBase AndAlso tmpTaxBase - tmpRefTaxBase < CInt(obj) Then
            If Not myMessage.AskQuestionFormatted(StringParserService.Parse("${res:Global.Error.DiffTaxBaseAndVatTaxBase}"), _
                                          New String() {Configuration.FormatToString(tmpRefTaxBase, DigitConfig.Price), _
                                                        Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)}) Then
              Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
            End If
          ElseIf tmpTaxBase < tmpRefTaxBase AndAlso tmpRefTaxBase - tmpTaxBase < CInt(obj) Then
            If Not myMessage.AskQuestionFormatted(StringParserService.Parse("${res:Global.Error.DiffTaxBaseAndVatTaxBase}"), _
                                       New String() {Configuration.FormatToString(tmpRefTaxBase, DigitConfig.Price), _
                                                     Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)}) Then
              Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
            End If
          Else
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseMoreThanRefDocTaxBase}"), _
                  New String() {Configuration.FormatToString(tmpTaxBase, DigitConfig.Price) _
                  , Configuration.FormatToString(tmpRefTaxBase, DigitConfig.Price)})
          End If
      
        ElseIf tmpTaxBase <> tmpRefTaxBase _
        AndAlso Not TypeOf Me.RefDoc Is BillAcceptance _
        AndAlso Not TypeOf Me.RefDoc Is GoodsReceipt _
        AndAlso Not TypeOf Me.RefDoc Is APOpeningBalance _
        AndAlso Not TypeOf Me.RefDoc Is EqMaintenance _
        AndAlso Not TypeOf Me.RefDoc Is GoodsSold _
        AndAlso Not TypeOf Me.RefDoc Is APVatInput _
        AndAlso Not TypeOf Me.RefDoc Is AdvancePay _
        AndAlso Not TypeOf Me.RefDoc Is ReceiveSelection _
        AndAlso Not TypeOf Me.RefDoc Is AROpeningBalance _
        AndAlso Not TypeOf Me.RefDoc Is PA _
          Then
          If TypeOf Me.RefDoc Is PaySelection AndAlso tmpTaxBase <> 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
                   New String() {Configuration.FormatToString(tmpTaxBase, DigitConfig.Price) _
                   , Configuration.FormatToString(tmpRefTaxBase, DigitConfig.Price)})
          ElseIf Not TypeOf Me.RefDoc Is PaySelection Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
                New String() {Configuration.FormatToString(tmpTaxBase, DigitConfig.Price) _
                , Configuration.FormatToString(tmpRefTaxBase, DigitConfig.Price)})
          End If
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
          paramArrayList.Add(New SqlParameter("@vat_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        Dim refDocType As Integer
        If TypeOf Me.RefDoc Is ISimpleEntity Then
          refDocType = CType(Me.RefDoc, ISimpleEntity).EntityId
        End If
        paramArrayList.Add(New SqlParameter("@vat_refDocType", refDocType))
        paramArrayList.Add(New SqlParameter("@vat_refdoc", IIf(Me.RefDoc.Id <> 0, Me.RefDoc.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@vat_refDocCode", Me.RefDoc.Code))
        paramArrayList.Add(New SqlParameter("@vat_refDocDate", Me.RefDoc.Date))

        If Not Me.RefDoc.Person Is Nothing AndAlso TypeOf Me.RefDoc.Person Is SimpleBusinessEntityBase Then
          Dim payee As SimpleBusinessEntityBase = CType(Me.RefDoc.Person, SimpleBusinessEntityBase)
          paramArrayList.Add(New SqlParameter("@vat_entity", ValidIdOrDBNull(payee)))
          paramArrayList.Add(New SqlParameter("@vat_entityType", payee.EntityId))
        End If

        paramArrayList.Add(New SqlParameter("@vat_taxbase", Me.TaxBase))
        paramArrayList.Add(New SqlParameter("@vat_amt", Me.Amount))
        paramArrayList.Add(New SqlParameter("@vat_note", Me.Note))

        Dim myDirection As Boolean = False
        If Me.Direction.Value = 1 Then
          myDirection = True
        End If
        paramArrayList.Add(New SqlParameter("@vat_direction", myDirection))
        paramArrayList.Add(New SqlParameter("@vat_status", Me.Status.Value))

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
                Return New SaveErrorException("${res:Global.Error.VatCodeDuplicated}", Me.Code)
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

			Dim da As New SqlDataAdapter("Select * from Vatitem where vati_vat=" & Me.Id, conn)
			Dim cmdBuilder As New SqlCommandBuilder(da)

			Dim ds As New DataSet

			da.SelectCommand.Transaction = trans

			'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
			cmdBuilder.GetDeleteCommand.Transaction = trans
			cmdBuilder.GetInsertCommand.Transaction = trans
			cmdBuilder.GetUpdateCommand.Transaction = trans

			da.Fill(ds, "Vatitem")

			Dim dbCount As Integer = ds.Tables("Vatitem").Rows.Count
			Dim i As Integer = 0
			Dim vi As New VatItem
			Dim ptn As String = Longkong.Pojjaman.BusinessLogic.Entity.GetAutoCodeFormat(vi.EntityId)
			Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
			pattern = CodeGenerator.GetPattern(pattern)
			Dim lastCode As String = vi.GetLastCode(pattern)

			With ds.Tables("Vatitem")
				For Each row As DataRow In .Rows
					row.Delete()
				Next
				Dim myDirection As Boolean = False
				If Me.Direction.Value = 1 Then
					myDirection = True
				End If
				For Each item As VatItem In Me.ItemCollection
					i += 1
					Dim dr As DataRow = .NewRow
					If (Me.AutoGen AndAlso item.Code.Length = 0) OrElse (item.AutoGen AndAlso ((item.Code Is Nothing) OrElse (item.Code.Length = 0))) Then
						'item.Code = item.GetNextCode
						Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me.RefDoc)
						item.Code = newCode
						lastCode = newCode
					End If
					If item.Runnumber Is Nothing Or Trim(item.Runnumber) = "" Then
						dr("vati_runnumber") = Me.RefDoc.Code & "-" & i.ToString.PadLeft(2, "0"c)
					Else
						dr("vati_runnumber") = item.Runnumber
					End If
					dr("vati_vat") = Me.Id
					dr("vati_linenumber") = i					'itemRow("vati_linenumber")
					dr("vati_code") = item.Code
					dr("vati_docdate") = IIf(item.DocDate.Equals(Date.MinValue), Date.Now.Date, item.DocDate.Date)
					dr("vati_printName") = item.PrintName
					dr("vati_printAddress") = item.PrintAddress
					dr("vati_taxrate") = item.TaxRate
					dr("vati_taxbase") = Configuration.Format(item.TaxBase, DigitConfig.Price)
					dr("vati_amt") = item.Amount
					dr("vati_note") = item.Note
					dr("vati_direction") = myDirection
					dr("vati_cc") = item.CcId
					dr("vati_submitaldate") = ValidDateOrDBNull(item.SubmitalDate)
					dr("vati_group") = ValidIdOrDBNull(item.VatGroup)
					dr("vati_refdoc") = item.Refdoc
					dr("vati_refdoctype") = item.RefdocType
					dr("vati_customTaxAmount") = item.UseCustomTaxAmount
					.Rows.Add(dr)
				Next
			End With
			Dim dt As DataTable = ds.Tables("Vatitem")
			' First process deletes.
			da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
			' Next process updates.
			da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
			' Finally process inserts.
			da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
		End Function
		Public Sub ResetToDefaultVatitem(ByVal code As String, ByVal [date] As Date)
			Me.ItemCollection.Clear()
			Dim vati As New VatItem
			vati.TaxBase = Me.RefDoc.GetMaximumTaxBase
			vati.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
			vati.Code = code
			vati.DocDate = [date]
			vati.PrintAddress = Me.RefDoc.Person.BillingAddress
			vati.PrintName = Me.RefDoc.Person.Name
			Me.ItemCollection.Add(vati)
		End Sub
		Public Sub RefreshVatTaxBase()
			If Me.RefDoc.GetMaximumTaxBase = Me.RefDoc.TaxBase Then
				Me.VatTaxBase = Me.RefDoc.GetMaximumTaxBase
			Else
				If Me.TaxBase > 0 Then
					Me.VatTaxBase = Me.RefDoc.GetMaximumTaxBase
				Else
					Me.VatTaxBase = Me.RefDoc.GetMaximumTaxBase - Me.RefDoc.TaxBase
				End If
			End If
		End Sub
#End Region

#Region "UI Validation Code"
		Public Sub CodeChanged(ByVal newCode As String)
      Dim vi As VatItem
      If newCode.Trim.Length > 0 Then
        If Me.ItemCollection.Count <= 0 Then
          vi = New VatItem
          Me.ItemCollection.Add(vi)
        End If
        vi = Me.ItemCollection(0)
        vi.Code = newCode

        '--------------------------------------------------
        vi.DocDate = Me.RefDoc.Date
        vi.PrintName = Me.RefDoc.Person.Name
        vi.PrintAddress = Me.RefDoc.Person.BillingAddress

        vi.TaxBase = Me.RefDoc.TaxBase
        '--------------------------------------------------
      Else
        Me.ItemCollection.Clear()
      End If
    End Sub
		Public Function DateTextChanged(ByVal txtInvoiceDate As TextBox, ByVal dtpInvoiceDate As DateTimePicker, ByVal validator As PJMTextboxValidator) As Boolean
			Dim dirtyFlag As Boolean = False
			Dim vi As VatItem
      If Me.ItemCollection.Count > 0 Then
        'vi = New VatItem
        'Me.ItemCollection.Add(vi)
        vi = Me.ItemCollection(0)
        If Not txtInvoiceDate.Text.Length = 0 AndAlso validator.GetErrorMessage(txtInvoiceDate) = "" Then
          Dim theDate As Date = CDate(txtInvoiceDate.Text)
          If Not vi.DocDate.Equals(theDate) Then
            dtpInvoiceDate.Value = theDate
            vi.DocDate = dtpInvoiceDate.Value
            dirtyFlag = True
          End If
        Else
          dtpInvoiceDate.Value = Date.Now
          vi.DocDate = Date.MinValue
          dirtyFlag = True
        End If
        Return dirtyFlag
      End If
		End Function
		Public Function DatePickerChanged(ByVal dtpInvoiceDate As DateTimePicker, ByVal txtInvoiceDate As TextBox, ByVal dateSetting As Boolean) As Boolean
			Dim dirtyFlag As Boolean = False
			Dim vi As VatItem
      If Me.ItemCollection.Count > 0 Then
        'vi = New VatItem
        'Me.ItemCollection.Add(vi)

        vi = Me.ItemCollection(0)
        If Not vi.DocDate.Equals(dtpInvoiceDate.Value) Then
          If Not dateSetting Then
            txtInvoiceDate.Text = MinDateToNull(dtpInvoiceDate.Value, "")
            vi.DocDate = dtpInvoiceDate.Value
          End If
          dirtyFlag = True
        End If
        Return dirtyFlag
      End If
		End Function
		Public Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
			If dt.Equals(Date.MinValue) Then
				Return nullString
			End If
			Return dt.ToShortDateString		'พี่ดำมาแก้คืนว่ะ
			'Return dt.ToString("dd/MM/yyyy")  ' เหน่งมาแก้นะครับ
		End Function
		Public Sub SetVatToOneDoc(ByVal txtInvoiceCode As TextBox, ByVal txtInvoiceDate As TextBox, ByVal dtpInvoiceDate As DateTimePicker)
			If Me.ItemCollection.Count > 0 Then
				Dim vitem As VatItem = Me.ItemCollection(0)
				If Me.ItemCollection.Count = 1 Then
					'มี 1 ใบ
					txtInvoiceCode.Text = vitem.Code
					txtInvoiceDate.Text = MinDateToNull(vitem.DocDate, "")
					dtpInvoiceDate.Value = MinDateToNow(vitem.DocDate)
				Else
					'มีหลายใบ
					txtInvoiceCode.Text = ""
					txtInvoiceDate.Text = MinDateToNull(Now, "")
					dtpInvoiceDate.Value = Now
					vitem.Code = txtInvoiceCode.Text
					vitem.DocDate = dtpInvoiceDate.Value
				End If
				'If Me.MaxRowIndex = -1 Then 'Not Me.m_entity.Originated Then
				'    vitem.TaxBase = Me.m_entity.TaxBase
				'End If
				vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
				Me.ItemCollection.Clear()
				Me.ItemCollection.Add(vitem)
			Else
				Return

				'ไม่มี Vatitem เลย
				Dim vitem As New VatItem
				vitem.DocDate = Me.RefDoc.Date
				vitem.PrintName = Me.RefDoc.Person.Name
				vitem.PrintAddress = Me.RefDoc.Person.BillingAddress


				vitem.TaxBase = Me.RefDoc.TaxBase

				vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
				Me.ItemCollection.Clear()
				Me.ItemCollection.Add(vitem)
				txtInvoiceDate.Text = MinDateToNull(Now, "")
				dtpInvoiceDate.Value = Now
			End If
		End Sub
		Public Delegate Sub OneArg()
		Public Sub SetVatToOneDoc(ByVal txtInvoiceCode As TextBox, ByVal txtInvoiceDate As TextBox, ByVal dtpInvoiceDate As DateTimePicker, ByVal UpdateVatAutogenStatus As OneArg)
			If Me.ItemCollection.Count > 0 Then
				Dim vitem As VatItem
				vitem = Me.ItemCollection(0)
				If Me.ItemCollection.Count = 1 Then
					'มี 1 ใบ
					'Me.txtInvoiceCode.Text = vitem.Code
					UpdateVatAutogenStatus.Invoke()
					txtInvoiceDate.Text = MinDateToNull(vitem.DocDate, "")
					'txtInvoiceDate.Text = MinDateToNull(vitem.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
					dtpInvoiceDate.Value = MinDateToNow(vitem.DocDate)
				End If
				If Not vitem.UseCustomTaxAmount Then
					vitem.TaxBase = Me.RefDoc.TaxBase			'มันจะอัปเดท taxbase ใน tab ภาษีอัตโนมัติ
				End If
				vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
			Else
				'ไม่มี Vatitem เลย
				Dim vitem As New VatItem
				vitem.DocDate = Me.RefDoc.Date
				vitem.PrintName = Me.RefDoc.Person.Name
				vitem.PrintAddress = Me.RefDoc.Person.BillingAddress
				vitem.TaxBase = Me.RefDoc.TaxBase
				vitem.TaxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
				Me.ItemCollection.Add(vitem)
				UpdateVatAutogenStatus.Invoke()
				txtInvoiceDate.Text = MinDateToNull(Now, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
				dtpInvoiceDate.Value = Now
			End If
		End Sub
#End Region

#Region "IPrintableEntity"
		Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
			Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\IV.dfm"
		End Function
		Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
			Return "IV"
		End Function
		Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'Me.RefreshTaxBase()
			'Code
			dpi = New DocPrintingItem
			dpi.Mapping = "Code"
			dpi.Value = Me.Code
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			If TypeOf Me.RefDoc Is GoodsSold Then
				Dim gs As GoodsSold = CType(Me.RefDoc, GoodsSold)
				dpi = New DocPrintingItem
				dpi.Mapping = "PORefCode"
				dpi.Value = gs.PoDocCode
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'AdvanceReceiveAmount
				dpi = New DocPrintingItem
				dpi.Mapping = "AdvanceReceiveAmount"
				dpi.Value = Configuration.FormatToString(gs.AdvanceReceiveItemCollection.GetAmount, DigitConfig.Price)
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'AdvanceReceiveVATAmount
				dpi = New DocPrintingItem
				dpi.Mapping = "AdvanceReceiveVATAmount"
				dpi.Value = Configuration.FormatToString(gs.AdvanceReceiveItemCollection.GetVATAmount, DigitConfig.Price)
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)
			End If

			'DocDate
			dpi = New DocPrintingItem
			dpi.Mapping = "DocDate"
			dpi.Value = Me.RefDoc.Date.ToShortDateString
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'VatItemCodes
			dpi = New DocPrintingItem
			dpi.Mapping = "VatItemCodes"
			dpi.Value = Me.GetVatItemCodes
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'InvoiceCode
			dpi = New DocPrintingItem
			dpi.Mapping = "InvoiceCode"
			dpi.Value = Me.GetVatItemCodes
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'VatItemDocDate
			dpi = New DocPrintingItem
			dpi.Mapping = "VatItemDates"
			dpi.Value = Me.GetVatItemDates
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'Note
			dpi = New DocPrintingItem
			dpi.Mapping = "Note"
			dpi.Value = Me.Note
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'Note2
			dpi = New DocPrintingItem
			dpi.Mapping = "Note2"
			dpi.Value = Me.GetVatItemNotes
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'Type
			dpi = New DocPrintingItem
			dpi.Mapping = "Type"
			dpi.Value = Me.Direction.Description
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			'Amount
			dpi = New DocPrintingItem
			dpi.Mapping = "Amount"
			dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
			dpi.DataType = "System.String"
			dpiColl.Add(dpi)

			If TypeOf Me.Entity Is IBillablePerson Then
				'CustomerCode 'รหัส
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerCode"
				dpi.Value = CType(Me.Entity, IBillablePerson).Code
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerName 'ชื่อ
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerName"
				dpi.Value = CType(Me.Entity, IBillablePerson).Name
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerInfo 'รหัส:ชื่อ
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerInfo"
				dpi.Value = CType(Me.Entity, IBillablePerson).Code & ":" & CType(Me.Entity, IBillablePerson).Name
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerBillingAddress  ที่อยู่ออกบิล *****
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerBillingAddress"
				dpi.Value = CType(Me.Entity, IBillablePerson).BillingAddress
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerAddress 'ที่อยู่ปัจจุบัน
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerAddress"
				dpi.Value = CType(Me.Entity, IBillablePerson).Address
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerMobile 'มือถือ
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerMobile"
				dpi.Value = CType(Me.Entity, IBillablePerson).Mobile
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerPhone 'โทรศัพท์
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerPhone"
				dpi.Value = CType(Me.Entity, IBillablePerson).Phone
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerFax 'Fax
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerFax"
				dpi.Value = CType(Me.Entity, IBillablePerson).Fax
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CustomerContact 'ผู้ติดต่อ
				dpi = New DocPrintingItem
				dpi.Mapping = "CustomerContact"
				dpi.Value = CType(Me.Entity, IBillablePerson).Contact
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)
			End If




			Dim tt As TreeTable
			Dim maxRefIndex As Integer = 0
			Dim mi As MethodInfo
			Dim refAfterTax As Decimal = 0
			Dim refBe4Tax As Decimal = 0
			Dim refGross As Decimal = 0
			Dim refDiscount As Discount
			Dim refDiscountAmount As Decimal = 0
			Dim refNote As String = ""
			Dim refRealGross As Decimal = 0
			If Not Me.RefDoc Is Nothing Then
				'RefDocCode
				dpi = New DocPrintingItem
				dpi.Mapping = "RefDocCode"
				dpi.Value = Me.RefDoc.Code
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)

				'CostCenter
				Dim ty As Type = CType(Me.RefDoc, Object).GetType
				Dim pi As PropertyInfo = ty.GetProperty("FromCostCenter")
				If pi Is Nothing Then
					pi = ty.GetProperty("CostCenter")
				End If
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If TypeOf o Is CostCenter Then
						' CostcenterInfo
						dpi = New DocPrintingItem
						dpi.Mapping = "CostCenterInfo"
						dpi.Value = CType(o, CostCenter).Code & ":" & CType(o, CostCenter).Name
						dpi.DataType = "System.String"
						dpiColl.Add(dpi)

						' Costcenter Code
						dpi = New DocPrintingItem
						dpi.Mapping = "CostCenterCode"
						dpi.Value = CType(o, CostCenter).Code
						dpi.DataType = "System.String"
						dpiColl.Add(dpi)

						' CostCenter Name
						dpi = New DocPrintingItem
						dpi.Mapping = "CostCenterName"
						dpi.Value = CType(o, CostCenter).Name
						dpi.DataType = "System.String"
						dpiColl.Add(dpi)
					End If
				End If
				pi = ty.GetProperty("Gross")
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If IsNumeric(o) Then
						refGross = CDec(o)
					End If
				End If
				pi = ty.GetProperty("AfterTax")
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If IsNumeric(o) Then
						refAfterTax = CDec(o)
					End If
				End If
				pi = ty.GetProperty("BeforeTax")
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If IsNumeric(o) Then
						refBe4Tax = CDec(o)
					End If
				End If
				pi = ty.GetProperty("Discount")
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If TypeOf o Is Discount Then
						refDiscount = CType(o, Discount)
					End If
				End If
				pi = ty.GetProperty("DiscountAmount")
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If IsNumeric(o) Then
						refDiscountAmount = CDec(o)
					End If
				End If
				pi = ty.GetProperty("Note")
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If IsNumeric(o) Then
						refNote = CStr(o)
					End If
				End If
				If Not TypeOf Me.RefDoc Is AdvanceReceive Then
					pi = ty.GetProperty("ItemTable")
					If Not pi Is Nothing Then
						Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
						If TypeOf o Is TreeTable Then
							tt = CType(o, TreeTable)
						End If
					End If
				End If
				If tt Is Nothing Then
					refGross = refAfterTax
				End If
				Dim mi2 As MethodInfo
				mi2 = ty.GetMethod("MaxRowIndex")
				If Not mi2 Is Nothing Then
					Dim o As Object = mi2.Invoke(Me.RefDoc, Nothing)
					If TypeOf o Is Integer Then
						maxRefIndex = CInt(o)
					End If
				End If
				pi = ty.GetProperty("RealGross")
				If Not pi Is Nothing Then
					Dim o As Object = pi.GetValue(Me.RefDoc, Nothing)
					If IsNumeric(o) Then
						refRealGross = CDec(o)
					End If
				End If

				Dim ts(0) As Type
				ts(0) = GetType(TreeRow)
				mi = ty.GetMethod("ValidateRow", ts)

			End If

			'Gross
			dpi = New DocPrintingItem
			dpi.Mapping = "Gross"
			dpi.Value = Configuration.FormatToString(refRealGross, DigitConfig.Price)
			dpi.DataType = "System.Decimal"
			dpiColl.Add(dpi)

			'DiscountRate
			If Not refDiscount Is Nothing Then
				dpi = New DocPrintingItem
				dpi.Mapping = "DiscountRate"
				dpi.Value = refDiscount.Rate
				dpi.DataType = "System.String"
				dpiColl.Add(dpi)
			End If

			'DiscountAmount
			dpi = New DocPrintingItem
			dpi.Mapping = "DiscountAmount"
			dpi.Value = Configuration.FormatToString(refDiscountAmount, DigitConfig.Price)
			dpi.DataType = "System.Decimal"
			dpiColl.Add(dpi)

			'BeforeTax
			dpi = New DocPrintingItem
			dpi.Mapping = "BeforeTax"
			dpi.Value = Configuration.FormatToString(refBe4Tax, DigitConfig.Price)
			dpi.DataType = "System.Decimal"
			dpiColl.Add(dpi)

			'TaxAmount
			dpi = New DocPrintingItem
			dpi.Mapping = "TaxAmount"
			dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
			dpi.DataType = "System.Decimal"
			dpiColl.Add(dpi)

			'AfterTax
			dpi = New DocPrintingItem
			dpi.Mapping = "AfterTax"
			dpi.Value = Configuration.FormatToString(refAfterTax, DigitConfig.Price)
			dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Item.Name (Show MileStone Detail)


      If Me.Direction.Value = 1 Then  'ภาษีซื้อ
        Dim n As Integer = 0
        For Each item As VatItem In Me.ItemCollection
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
          dpi.Value = item.Runnumber
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.RefDoc
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.RefDoc"
          dpi.Value = item.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Date
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Date"
          dpi.Value = item.DocDate.ToShortDateString
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(item.TaxBase, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.TaxRate
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.TaxRate"
          dpi.Value = Configuration.FormatToString(item.TaxRate, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.TaxAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.TaxAmount"
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

          n += 1
        Next
      ElseIf TypeOf Me.RefDoc Is GoodsSold Then
        Dim n As Integer = 0
        For Each item As GoodsSoldItem In CType(Me.RefDoc, GoodsSold).ItemCollection
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
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = item.EntityName
          Else
            dpi.Value = item.Entity.Name
          End If
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

          'Item.DiscountRate
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.DiscountRate"
          dpi.Value = item.Discount.Rate
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.DiscountAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.DiscountAmount"
          If item.Discount.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
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

          'Item.ZeroVat
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ZeroVat"
          dpi.Value = item.UnVatable
          dpi.DataType = "System.Boolean"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          n += 1
        Next   'i
      ElseIf TypeOf Me.RefDoc Is AdvanceReceive Then
        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = 1
        dpi.DataType = "System.Int32"
        dpi.Row = 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        dpi.Value = "รับมัดจำ (" & refNote & ")"
        dpi.DataType = "System.String"
        dpi.Row = 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        dpi.Value = Configuration.FormatToString(refAfterTax, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
      ElseIf TypeOf Me.RefDoc Is BillIssue Then
        Dim bi As BillIssue = CType(Me.RefDoc, BillIssue)
        If Not bi.SingleVat Then
          Dim n As Integer = 0
          For Each vitem As VatItem In Me.ItemCollection
            If Not vitem.Milestone Is Nothing Then
              Dim mis As Milestone = vitem.Milestone
              If mis.MaxRowIndex = -1 Then
                'ไม่มี item ในงวด
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
                dpi.Value = mis.Code
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Name
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Name"
                dpi.Value = mis.Name
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Unit
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Unit"
                dpi.Value = "หน่วย"
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Qty
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Qty"
                dpi.Value = Configuration.FormatToString(1, DigitConfig.Qty)
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.UnitPrice
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.UnitPrice"
                If mis.Amount = 0 Then
                  dpi.Value = ""
                Else
                  dpi.Value = Configuration.FormatToString(mis.Amount, DigitConfig.UnitPrice)
                End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Amount
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Amount"
                If mis.Amount = 0 Then
                  dpi.Value = ""
                Else
                  If TypeOf mis Is VariationOrderDe Then
                    dpi.Value = Configuration.FormatToString(-mis.Amount, DigitConfig.Price)
                  Else
                    dpi.Value = Configuration.FormatToString(mis.Amount, DigitConfig.Price)
                  End If
                End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Note
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Note"
                dpi.Value = mis.Note
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                n += 1
              Else
                'มี item ในงวด
                For x As Integer = 0 To mis.MaxRowIndex
                  Dim misRow As TreeRow = CType(mis.ItemTable.Rows(x), TreeRow)

                  If mis.ValidateRow(misRow) Then
                    Dim item As New MilestoneItem
                    item.CopyFromDataRow(misRow)

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
                      If TypeOf mis Is VariationOrderDe Then
                        dpi.Value = Configuration.FormatToString(-mis.Amount, DigitConfig.Price)
                      Else
                        dpi.Value = Configuration.FormatToString(mis.Amount, DigitConfig.Price)
                      End If
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
              End If
            End If
          Next
          'Show milestone detail           
          For Each item As Milestone In bi.ItemCollection
            If bi.ShowDetail Then
              item.ReLoadItems()
              For Each miDetailRow As TreeRow In item.ItemTable.Childs
                n += 1
                Dim childText As String = miDetailRow("milestonei_desc").ToString
                'Item.NameMilestone
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.NameMilestone"
                dpi.Value = childText
                dpi.DataType = "System.String"
                dpi.Row = n
                dpi.Table = "Item"
                dpiColl.Add(dpi)
              Next
            End If
          Next
          n += 1
				End If
			ElseIf TypeOf (Me.RefDoc) Is ReceiveSelection Then
				Dim rsn As ReceiveSelection = CType(Me.RefDoc, ReceiveSelection)
				Dim n As Integer = 0
				If Not rsn.SingleVat Then
					For Each vitem As VatItem In Me.ItemCollection
						If Not vitem.Milestone Is Nothing Then
							Dim mis As Milestone = vitem.Milestone
							If mis.MaxRowIndex = -1 Then
								'ไม่มี item ในงวด
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
								dpi.Value = mis.Code
								dpi.DataType = "System.String"
								dpi.Row = n + 1
								dpi.Table = "Item"
								dpiColl.Add(dpi)

								'Item.Name
								dpi = New DocPrintingItem
								dpi.Mapping = "Item.Name"
								dpi.Value = mis.Name
								dpi.DataType = "System.String"
								dpi.Row = n + 1
								dpi.Table = "Item"
								dpiColl.Add(dpi)

								'Item.Unit
								dpi = New DocPrintingItem
								dpi.Mapping = "Item.Unit"
								dpi.Value = "หน่วย"
								dpi.DataType = "System.String"
								dpi.Row = n + 1
								dpi.Table = "Item"
								dpiColl.Add(dpi)

								'Item.Qty
								dpi = New DocPrintingItem
								dpi.Mapping = "Item.Qty"
								dpi.Value = Configuration.FormatToString(1, DigitConfig.Qty)
								dpi.DataType = "System.String"
								dpi.Row = n + 1
								dpi.Table = "Item"
								dpiColl.Add(dpi)

								'Item.UnitPrice
								dpi = New DocPrintingItem
								dpi.Mapping = "Item.UnitPrice"
								If mis.Amount = 0 Then
									dpi.Value = ""
								Else
									dpi.Value = Configuration.FormatToString(mis.Amount, DigitConfig.UnitPrice)
								End If
								dpi.DataType = "System.String"
								dpi.Row = n + 1
								dpi.Table = "Item"
								dpiColl.Add(dpi)

								'Item.Amount
								dpi = New DocPrintingItem
								dpi.Mapping = "Item.Amount"
								If mis.Amount = 0 Then
									dpi.Value = ""
								Else
                  If TypeOf mis Is VariationOrderDe Then
                    dpi.Value = Configuration.FormatToString(-mis.Amount, DigitConfig.Price)
                  Else
                    dpi.Value = Configuration.FormatToString(mis.Amount, DigitConfig.Price)
                  End If
								End If
								dpi.DataType = "System.String"
								dpi.Row = n + 1
								dpi.Table = "Item"
								dpiColl.Add(dpi)

								'Item.Note
								dpi = New DocPrintingItem
								dpi.Mapping = "Item.Note"
								dpi.Value = mis.Note
								dpi.DataType = "System.String"
								dpi.Row = n + 1
								dpi.Table = "Item"
								dpiColl.Add(dpi)
								n += 1
							Else
								'มี item ในงวด
								For x As Integer = 0 To mis.MaxRowIndex
									Dim misRow As TreeRow = CType(mis.ItemTable.Rows(x), TreeRow)

									If mis.ValidateRow(misRow) Then
										Dim item As New MilestoneItem
										item.CopyFromDataRow(misRow)

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
							End If
						End If
					Next
          ''Show milestone detail
          'For Each item As SaleBillIssueItem In rsn.ItemCollection
          'If rsn.ItemCollection.ShowDetail Then
          'Dim m_item As New Milestone(item.StockId)
          'For Each miDetailRow As TreeRow In m_item.ItemTable.Childs
          'n += 1
          'Dim childText As String = miDetailRow("milestonei_desc").ToString
          ''Item.NameMileStone
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.NameMileStone"
          'dpi.Value = childText
          'dpi.DataType = "System.String"
          'dpi.Row = n
          'dpi.Table = "Item"
          'dpiColl.Add(dpi)
          'Next
          'End If
          'n += 1
          'Next
				End If
			End If

			Return dpiColl
    End Function

#End Region

	End Class
  Public Class VatForSelection
    Inherits Vat

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "VatForSelection"
      End Get
    End Property

  End Class

  Public Class VatGroup
    Inherits TreeBaseEntity

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal myParent As VatGroup)
      MyBase.New(myParent)
      myParent = New VatGroup(myParent.Id)
    End Sub
    Public Sub New(ByVal gid As Integer)
      MyBase.New(gid)
    End Sub
    Public Sub New(ByVal gcode As String)
      MyBase.New(gcode)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "vatg_note") AndAlso Not dr.IsNull(aliasPrefix & "vatg_note") Then
          .vatg_note = CStr(dr(aliasPrefix & "vatg_note"))
        End If
      End With
    End Sub
#End Region

#Region "Members"
    Private vatg_note As String
#End Region

#Region "Properties"
    Public Property Note() As String
      Get
        Return vatg_note
      End Get
      Set(ByVal Value As String)
        vatg_note = Value
      End Set
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "vatg"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "VatGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "VatGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VatGroup.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.VatGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.VatGroup"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VatGroup.ListLabel}"
      End Get
    End Property
#End Region

#Region "Methods"
    Public Overloads Overrides Sub SetParent(ByVal parId As Integer)
      If parId <> Id Then
        Me.Parent = New VatGroup(parId)
      Else
        Me.Parent = Me
      End If
    End Sub
    Public Overloads Overrides Sub SetParent(ByVal id As Integer, ByVal code As String, ByVal name As String)
      Dim par As New VatGroup
      par.Id = id
      par.Code = code
      par.Name = name
      Me.Parent = par
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim parID As Object = 0
        If Not Me.Parent Is Nothing AndAlso Me.Parent.Originated Then
          parID = Me.Parent.Id
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
          paramArrayList.Add(New SqlParameter("@vatg_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        paramArrayList.Add(New SqlParameter("@vatg_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@vatg_name", Me.Name))
        paramArrayList.Add(New SqlParameter("@vatg_altname", Me.AlternateName))
        paramArrayList.Add(New SqlParameter("@vatg_parid", parID))
        paramArrayList.Add(New SqlParameter("@vatg_level", Me.Level))
        paramArrayList.Add(New SqlParameter("@vatg_path", Me.Path))
        paramArrayList.Add(New SqlParameter("@vatg_control", Me.IsControlGroup))
        paramArrayList.Add(New SqlParameter("@vatg_note", Me.Note))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)

        ' ตรวจจับ Error ของการ Save ...

        Return New SaveErrorException(returnVal.Value.ToString)

      End With
    End Function
#End Region

#Region "Shared"
    Public Shared Function GetVatGroup(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldGroup As VatGroup) As Boolean
      Dim group As New VatGroup(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not group.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        group = oldGroup
        'ElseIf group.IsControlGroup Then
        '    MessageBox.Show(group.Code & "-" & group.Name & " เป็นกลุ่มแม่")
        '    group = oldGroup
        Return False
      End If
      txtCode.Text = group.Code
      txtName.Text = group.Name

      oldGroup = group
      Return True
      'If oldGroup Is Nothing OrElse oldGroup.Id <> group.Id Then
      'oldGroup = group
      'Return True
      'End If
      'Return False
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return True 'Hack
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteVatGroup}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteVatGroup", New SqlParameter() {New SqlParameter("@vatg_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.VatGroupIsReferencedCannotBeDeleted}")
            Case Else
          End Select
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
#End Region

  End Class


  Public Class VatItem
    Implements ICodeGeneratable, IObjectReflectable, IHasToCostCenter _
    , IHasFromCostCenter, IHasGroup, IPrintableEntity, ICanSaveTreeTable

#Region "Members"
    Private m_vatId As Integer
    Private m_vat As Vat
    Private m_lineNumber As Integer
    Private m_code As String
    Private m_docDate As Date
    Private m_printName As String
    Private m_printAddress As String
    Private m_taxBase As Decimal
    Private m_taxRate As Decimal = CDec(Configuration.GetConfig("CompanyTaxRate"))
    Private m_taxAmt As Decimal
    Private m_useCustomTaxAmt As Boolean
    Private m_note As String
    Private m_runNumber As String
    Private m_ccId As Integer
    Private m_group As VatGroup
    Private m_submitalDate As Date

    Private m_refdoc As Integer
    Private m_refdocType As Integer

    Private m_lines As ArrayList

    Private m_milestone As Milestone
    Private m_billAcceptanceItem As BillAcceptanceItem
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.m_group = New VatGroup
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.m_group = New VatGroup
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "vati_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "vati_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "vati_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_taxrate") AndAlso Not dr.IsNull(aliasPrefix & "vati_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "vati_taxrate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vati_taxbase") AndAlso Not dr.IsNull(aliasPrefix & "vati_taxbase") Then
          .m_taxBase = CDec(dr(aliasPrefix & "vati_taxbase"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vati_amt") AndAlso Not dr.IsNull(aliasPrefix & "vati_amt") Then
          .m_taxAmt = CDec(dr(aliasPrefix & "vati_amt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_code") AndAlso Not dr.IsNull(aliasPrefix & "vati_code") Then
          .m_code = CStr(dr(aliasPrefix & "vati_code"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vati_printName") AndAlso Not dr.IsNull(aliasPrefix & "vati_printName") Then
          .m_printName = CStr(dr(aliasPrefix & "vati_printName"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vati_printAddress") AndAlso Not dr.IsNull(aliasPrefix & "vati_printAddress") Then
          .m_printAddress = CStr(dr(aliasPrefix & "vati_printAddress"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_docDate") AndAlso Not dr.IsNull(aliasPrefix & "vati_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "vati_docDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_note") AndAlso Not dr.IsNull(aliasPrefix & "vati_note") Then
          .m_note = CStr(dr(aliasPrefix & "vati_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_runNumber") AndAlso Not dr.IsNull(aliasPrefix & "vati_runNumber") Then
          .m_runNumber = CStr(dr(aliasPrefix & "vati_runNumber"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vati_cc") AndAlso Not dr.IsNull(aliasPrefix & "vati_cc") Then
          .m_ccId = CInt(dr(aliasPrefix & "vati_cc"))
        End If

        If dr.Table.Columns.Contains("vatg_id") Then
          If Not dr.IsNull("vatg_id") Then
            .VatGroup = New VatGroup(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "vati_group") AndAlso Not dr.IsNull(aliasPrefix & "vati_group") Then
            .VatGroup = New VatGroup(CInt(dr(aliasPrefix & "vati_group")))
          End If
        End If

        If dr.Table.Columns.Contains("vat_id") Then
          If Not dr.IsNull("vat_id") Then
            .m_vatId = CInt(dr("vat_id"))
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "vati_vat") AndAlso Not dr.IsNull(aliasPrefix & "vati_vat") Then
            .m_vatId = CInt(dr(aliasPrefix & "vati_vat"))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_submitaldate") AndAlso Not dr.IsNull(aliasPrefix & "vati_submitaldate") Then
          .m_submitalDate = CDate(dr(aliasPrefix & "vati_submitaldate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_refdoc") AndAlso Not dr.IsNull(aliasPrefix & "vati_refdoc") Then
          .m_refdoc = CInt(dr(aliasPrefix & "vati_refdoc"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vati_refdoctype") AndAlso Not dr.IsNull(aliasPrefix & "vati_refdoctype") Then
          .m_refdocType = CInt(dr(aliasPrefix & "vati_refdoctype"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "vati_customTaxAmount") AndAlso Not dr.IsNull(aliasPrefix & "vati_customTaxAmount") Then
          .m_useCustomTaxAmt = CBool(dr(aliasPrefix & "vati_customTaxAmount"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property Milestone() As Milestone
      Get
        Return m_milestone
      End Get
      Set(ByVal Value As Milestone)
        m_milestone = Value
      End Set
    End Property
    Public Property BillAcceptanceItem() As BillAcceptanceItem
      Get
        Return m_billAcceptanceItem
      End Get
      Set(ByVal Value As BillAcceptanceItem)
        m_billAcceptanceItem = Value
      End Set
    End Property
    Public Property Refdoc() As Integer
      Get
        Return m_refdoc
      End Get
      Set(ByVal Value As Integer)
        m_refdoc = Value
      End Set
    End Property
    Public Property RefdocType() As Integer
      Get
        Return m_refdocType
      End Get
      Set(ByVal Value As Integer)
        m_refdocType = Value
      End Set
    End Property
    Private m_headerText As String
    Public Property HeaderText() As String
      Get
        Return m_headerText
      End Get
      Set(ByVal Value As String)
        m_headerText = Value
      End Set
    End Property
    Public Property SubmitalDate() As Date
      Get
        Return Me.m_submitalDate
      End Get
      Set(ByVal Value As Date)
        m_submitalDate = Value
      End Set
    End Property
    Public Property VatGroup() As VatGroup
      Get
        Return m_group
      End Get
      Set(ByVal Value As VatGroup)
        m_group = Value
      End Set
    End Property
    Public Property Runnumber() As String
      Get
        Return m_runNumber
      End Get
      Set(ByVal Value As String)
        m_runNumber = Value
      End Set
    End Property
    Public ReadOnly Property VatId() As Integer
      Get
        If Not Me.Vat Is Nothing AndAlso Me.Vat.Originated Then
          m_vatId = Me.Vat.Id
        End If
        Return m_vatId
      End Get
    End Property
    Public Property Vat() As Vat
      Get
        Return m_vat
      End Get
      Set(ByVal Value As Vat)
        m_vat = Value
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
    Public Property Code() As String Implements IIdentifiable.Code
      Get
        Return m_code
      End Get
      Set(ByVal Value As String)
        m_code = Value
        Try
          'If TypeOf Me.RefDoc Is BillAcceptance Then  ' เอาออกเพราะเปลี่ยน code แล้วชื่อที่อยู่หาย
          Me.Vat.Entity = Me.Vat.RefDoc.Person
          'End If
        Catch ex As Exception

        End Try
        If Not Me.Vat Is Nothing Then
          Me.DocDate = Me.Vat.RefDoc.Date
          Me.PrintName = Me.Vat.Entity.Name
          Me.PrintAddress = Me.Vat.Entity.BillingAddress
          Me.SubmitalDate = Me.Vat.SubmitalDate
          Me.VatGroup = Me.Vat.VatGroup
        End If
      End Set
    End Property
    Public Property DocDate() As Date
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
      End Set
    End Property
    Public Property PrintName() As String
      Get
        Return m_printName
      End Get
      Set(ByVal Value As String)
        m_printName = Value
      End Set
    End Property
    Public Property PrintAddress() As String
      Get
        Return m_printAddress
      End Get
      Set(ByVal Value As String)
        m_printAddress = Value
      End Set
    End Property
    Public Property TaxBase() As Decimal
      Get
        Return m_taxBase
      End Get
      Set(ByVal Value As Decimal)
        m_taxBase = Value
        Me.UseCustomTaxAmount = False
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
      End Set
    End Property
    Public Property Amount() As Decimal
      Get
        ' ถ้ากำหนด TaxAmount เอง
        If UseCustomTaxAmount Then
          Return m_taxAmt
        Else
          Return (Me.m_taxBase * Me.m_taxRate) / 100
        End If
      End Get
      Set(ByVal Value As Decimal)
        Me.UseCustomTaxAmount = True
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
    Public Property CcId() As Integer
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

#End Region

#Region "Methods"
    ''' <summary>
    ''' เปลี่ยนแปลง GL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetRefDocGLChange()
      If Not m_vat Is Nothing Then
        If TypeOf m_vat.RefDoc Is SimpleBusinessEntityBase Then
          CType(m_vat.RefDoc, SimpleBusinessEntityBase).OnGlChanged()
        End If
      End If
    End Sub
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim proposedTaxBase As Object = row("vati_taxbase")
      Dim proposedTaxRate As Object = row("vati_taxrate")
      Dim proposedCode As Object = row("vati_code")
      Dim proposedDocDate As Object = row("vati_docdate")
      Dim proposedPrintName As Object = row("vati_printname")
      Dim proposedPrintAddress As Object = row("vati_printaddress")

      Dim isBlankRow As Boolean = False
      If (IsDBNull(proposedTaxBase) OrElse CStr(proposedTaxBase).Length = 0 OrElse CInt(proposedTaxBase) = 0) _
          And (IsDBNull(proposedTaxRate) OrElse CStr(proposedTaxRate).Length = 0 OrElse CInt(proposedTaxRate) = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode).Length = 0) _
          And (IsDBNull(proposedPrintName) OrElse CStr(proposedPrintName).Length = 0) _
          And (IsDBNull(proposedPrintAddress) OrElse CStr(proposedPrintAddress).Length = 0) _
          And (IsDBNull(proposedDocDate) OrElse CStr(proposedDocDate).Length = 0 OrElse CDate(proposedDocDate).Equals(Date.MinValue)) Then
        isBlankRow = True
      End If

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not isBlankRow Then
        If IsDBNull(proposedTaxBase) Then
          row.SetColumnError("vati_taxbase", myStringParserService.Parse("${res:Global.Error.TaxBaseMissing}"))
        Else
          row.SetColumnError("vati_taxbase", "")
        End If

        If IsDBNull(proposedTaxRate) Then
          row.SetColumnError("vati_taxrate", myStringParserService.Parse("${res:Global.Error.TaxRateMissing}"))
        Else
          row.SetColumnError("vati_taxrate", "")
        End If

        If IsDBNull(proposedCode) OrElse CStr(proposedCode).Length = 0 Then
          row.SetColumnError("vati_code", myStringParserService.Parse("${res:Global.Error.DescriptonMissing}"))
        Else
          row.SetColumnError("vati_code", "")
        End If
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim proposedTaxBase As Object = row("vati_taxbase")
      Dim proposedTaxRate As Object = row("vati_taxrate")
      Dim proposedCode As Object = row("vati_code")
      Dim proposedDocDate As Object = row("vati_docdate")
      Dim proposedPrintName As Object = row("vati_printname")
      Dim proposedPrintAddress As Object = row("vati_printaddress")

      Dim flag As Boolean = True
      If (IsDBNull(proposedTaxBase) OrElse CStr(proposedTaxBase).Length = 0 OrElse CInt(proposedTaxBase) = 0) _
          And (IsDBNull(proposedTaxRate) OrElse CStr(proposedTaxRate).Length = 0 OrElse CInt(proposedTaxRate) = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode).Length = 0) _
          And (IsDBNull(proposedPrintName) OrElse CStr(proposedPrintName).Length = 0) _
          And (IsDBNull(proposedPrintAddress) OrElse CStr(proposedPrintAddress).Length = 0) _
          And (IsDBNull(proposedDocDate) OrElse CStr(proposedDocDate).Length = 0 OrElse CDate(proposedDocDate).Equals(Date.MinValue)) _
          Then
        flag = False
      End If

      Return flag
      Return True
    End Function
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.Vat.IsInitialized = False
      If row.IsNull("Selected") Then
        row("Selected") = False
      End If
      row("vati_linenumber") = Me.LineNumber
      row("vati_code") = Me.Code
      row("vati_printname") = Me.PrintName
      row("vati_printaddress") = Me.PrintAddress
      row("vati_docdate") = Me.DocDate

      row("vati_refdoc") = Me.Refdoc
      row("vati_refdoctype") = Me.RefdocType

      row("useCustomAmt") = Me.UseCustomTaxAmount
      If Me.Amount = 0 Then
        row("Amount") = ""
      Else
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      End If

      If Me.TaxRate = 0 Then
        row("vati_taxrate") = ""
      Else
        row("vati_taxrate") = Configuration.FormatToString(Me.TaxRate, DigitConfig.Price)
      End If
      If Me.TaxBase = 0 Then
        row("vati_taxbase") = ""
      Else
        row("vati_taxbase") = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      End If
      row("vati_realtaxbase") = Me.TaxBase

      row("vati_note") = Me.Note
      row("vati_runnumber") = Me.Runnumber
      row("vati_cc") = Me.CcId

      row("vati_group") = Me.Group.Id
      row("vati_submitaldate") = Me.SubmitalDate

      Me.Vat.IsInitialized = True
    End Sub
#End Region

#Region "ICodeGeneratable"
    Public Function GetLastCode(ByVal prefixPattern As String) As String Implements ICodeGeneratable.GetLastCode

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      'ไม่เวิร์ค ใช้แบบใหม่ข้างล่าง
      'Dim sql As String = "select top 1 vati_code from [vatitem] where vati_direction = 0 and vati_code like '" & prefixPattern & "%' " & " order by vati_vat,vati_linenumber desc"
      Dim sql As String = "select max(vati_code) vati_code from [vatitem] where vati_direction = 0 and vati_code like '" & prefixPattern & "%' "

      conn.Open()

      Dim cmd As SqlCommand = conn.CreateCommand
      cmd.CommandText = sql

      Dim obj As Object = cmd.ExecuteScalar
      If Not IsDBNull(obj) AndAlso Not obj Is Nothing Then
        Return obj.ToString
      End If
      Return ""
    End Function
    Public Function GetNextCode() As String Implements ICodeGeneratable.GetNextCode
      Dim ptn As String = Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
      pattern = CodeGenerator.GetPattern(pattern)
      Dim newCode As String = CodeGenerator.Generate(ptn, Me.GetLastCode(pattern), Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(Entity.GetAutoCodeFormat(Me.EntityId), newCode, Me)
      End While
      Return newCode
    End Function
    Private m_autogen As Boolean
    Public Property AutoGen() As Boolean Implements ICodeGeneratable.AutoGen
      Get
        Return m_autogen
      End Get
      Set(ByVal Value As Boolean)
        m_autogen = Value
      End Set
    End Property
    Public Function DuplicateCode(ByVal newCode As String) As Boolean
      If Me.Vat Is Nothing Then
        Return False
      End If
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim conn As New SqlConnection(sqlConString)
      Dim sql As String = "select count(*) from vatitem where vati_code='" & newCode & "' and (vati_vat <> " & Me.Vat.Id & " or vati_linenumber <> " & Me.LineNumber & ")" & _
      " and vati_direction = 0" '****** ภาษีขายเท่านั้น

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
#End Region

#Region "IObjectReflectable"
    Public ReadOnly Property EntityId() As Integer Implements IObjectReflectable.EntityId
      Get
        Return Entity.GetIdFromClassName(Me.ClassName)
      End Get
    End Property
    Public ReadOnly Property ClassName() As String Implements IObjectReflectable.ClassName
      Get
        Return "VatItem"
      End Get
    End Property
    Public ReadOnly Property FullClassName() As String Implements IObjectReflectable.FullClassName
      Get
        Return Me.Namespace & "." & Me.ClassName
      End Get
    End Property
    Public ReadOnly Property FullClassNameForSecurity() As String Implements IObjectReflectable.FullClassNameForSecurity
      Get
        Return Me.FullClassName
      End Get
    End Property
    Public ReadOnly Property [Namespace]() As String Implements IObjectReflectable.Namespace
      Get
        Return "Longkong.Pojjaman.BusinessLogic"
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("VatItem")
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RefDocCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocDate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("SupplierName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TaxBase", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TaxRate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TaxAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("VatGroupCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("VatGroupButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("VatGroupName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("vati_group", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("vati_vat", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("vati_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("vati_refdoc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("vati_refdoctype", GetType(Integer)))

      Dim dateCol As New DataColumn("SubmitalDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)
      Return myDatatable
    End Function
    Public Shared Function GetItemDataTable(ByVal filters As Filter()) As TreeTable
      Dim myDatatable As TreeTable = VatItem.GetSchemaTable

      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetVatItemDetailList", params)

      For Each dr As DataRow In ds.Tables(0).Rows
        Dim vitem As New VatItem(dr, "")
        Dim row As TreeRow = myDatatable.Childs.Add
        row("vati_vat") = dr("vati_vat")
        row("vati_linenumber") = dr("vati_linenumber")
        row("vati_group") = dr("vati_group")
        row("Code") = vitem.Code
        row("RefDocCode") = dr("vat_refdoccode")
        row("DocDate") = CDate(vitem.DocDate).ToShortDateString
        row("SupplierName") = dr("EntityName")
        row("TaxBase") = Configuration.FormatToString(vitem.TaxBase, DigitConfig.Price)
        row("TaxRate") = Configuration.FormatToString(vitem.TaxRate, DigitConfig.Price)
        row("TaxAmount") = Configuration.FormatToString(vitem.Amount, DigitConfig.Price)
        row("VatGroupCode") = vitem.VatGroup.Code
        row("VatGroupName") = vitem.VatGroup.Name
        row("SubmitalDate") = CDate(vitem.SubmitalDate).ToShortDateString
      Next
      Return myDatatable
    End Function
    Public Function SaveGroupAndSubmitalDate(ByVal tt As TreeTable) As SaveErrorException Implements ICanSaveTreeTable.SaveTreeTable
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim da As New SqlDataAdapter("Select * from Vatitem", conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "Vatitem")
        Dim dt As DataTable = ds.Tables("Vatitem")

        Dim i As Integer = 0
        For Each tr As TreeRow In tt.Rows
          Dim vatId As Integer = CInt(tr("vati_vat"))
          Dim line As Integer = CInt(tr("vati_linenumber"))
          Dim groupId As Object = DBNull.Value
          Dim sDate As Object = DBNull.Value
          If IsDate(tr("SubmitalDate")) Then
            If Not CDate(tr("SubmitalDate")).Equals(Date.MinValue) Then
              sDate = tr("SubmitalDate")
            End If
          End If
          If Not tr.IsNull("vati_group") Then
            groupId = CInt(tr("vati_group"))
          End If
          Dim drs As DataRow() = dt.Select("vati_vat=" & vatId & " and vati_linenumber=" & line)
          If drs.Length = 1 Then
            Dim dr As DataRow = drs(0)
            dr("vati_group") = groupId
            dr("vati_submitaldate") = sDate
          End If
        Next

        ' First process deletes.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        trans.Commit()
        Return New SaveErrorException("1")
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      Finally
        conn.Close()
      End Try
    End Function
    Public Shared Function GetListDatatable(ByVal ParamArray filters() As Filter) As TreeTable

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      Dim params() As SqlParameter
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 1)
        For i As Integer = 0 To filters.Length - 1
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
      End If
      Dim dt As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetVatItemDetailList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("VatItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Vat", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("VatItem", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TaxBase", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("VatAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("SubmitalDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("DummySubmitalDate", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Group", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DummyGroup", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))

      For Each tableRow As DataRow In dt.Rows
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("vat_refdocCode")
        row("Vat") = tableRow("vat_id")
        row("Linenumber") = tableRow("vati_linenumber")
        row("VatItem") = tableRow("vati_code")
        row("Date") = tableRow("vati_docdate")
        row("SubmitalDate") = tableRow("vati_submitaldate")


        row("EntityName") = tableRow("EntityName")

        If IsNumeric(tableRow("vati_taxbase")) Then
          row("TaxBase") = Configuration.FormatToString(CDec(tableRow("vati_taxbase")), DigitConfig.Price)
        End If
        If IsNumeric(tableRow("vati_amt")) Then
          row("VatAmount") = Configuration.FormatToString(CDec(tableRow("vati_amt")), DigitConfig.Price)
        End If
        row("Group") = tableRow("vatg_name")
        row("CostCenter") = tableRow("cc_code")
        row.State = RowExpandState.None
        row.Tag = tableRow
      Next
      Return myDatatable
    End Function
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

    Public ReadOnly Property Group() As ISimpleEntity Implements IHasGroup.Group
      Get
        Return Me.VatGroup
      End Get
    End Property

#Region "IPrintableEntity"
    Public Property Id() As Integer Implements IIdentifiable.Id
      Get

      End Get
      Set(ByVal Value As Integer)

      End Set
    End Property
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "TaxInvoice"
    End Function
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return ""
    End Function
    Dim showSpecificLineOnly As Boolean = False
    Dim myCount As Integer
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      'Me.RefreshTaxBase()
      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'InvoiceCode
      dpi = New DocPrintingItem
      dpi.Mapping = "InvoiceCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note2
      dpi = New DocPrintingItem
      dpi.Mapping = "Note2"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Amount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim entity As IBillablePerson
      If Not Me.Vat Is Nothing Then
        entity = CType(Me.Vat.Entity, IBillablePerson)
      End If
      If entity Is Nothing Then
        entity = New Customer
      End If

      'CustomerCode 'รหัส
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerCode"
      dpi.Value = entity.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerName 'ชื่อ
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerName"
      dpi.Value = Me.PrintName 'entity.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerInfo 'รหัส:ชื่อ
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerInfo"
      dpi.Value = entity.Code & ":" & entity.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerBillingAddress  ที่อยู่ออกบิล *****
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerBillingAddress"
      dpi.Value = Me.PrintAddress 'entity.BillingAddress
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerAddress 'ที่อยู่ปัจจุบัน
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerAddress"
      dpi.Value = entity.Address
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerMobile 'มือถือ
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerMobile"
      dpi.Value = entity.Mobile
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerPhone 'โทรศัพท์
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerPhone"
      dpi.Value = entity.Phone
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerFax 'Fax
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerFax"
      dpi.Value = entity.Fax
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CustomerContact 'ผู้ติดต่อ
      dpi = New DocPrintingItem
      dpi.Mapping = "CustomerContact"
      dpi.Value = entity.Contact
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenter
      ' CostcenterInfo
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterInfo"
      dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ' Costcenter Code
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterCode"
      dpi.Value = Me.CostCenter.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ' CostCenter Name
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = Me.CostCenter.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim refDoc As IVatable
      If Not Me.Vat Is Nothing AndAlso Not Me.Vat.RefDoc Is Nothing Then
        refDoc = Me.Vat.RefDoc
        If Not refDoc Is Nothing Then
          ' RefDocCode
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocCode"
          dpi.Value = refDoc.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If

        ''BeforeTax
        'dpi = New DocPrintingItem
        'dpi.Mapping = "BeforeTax"
        'dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
        'dpi.DataType = "System.Decimal"
        'dpiColl.Add(dpi)

        'TaxAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "TaxAmount"
        dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)

        'BeforeTaxAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "BeforeTaxAmount"
        dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)

        'AfterTax
        dpi = New DocPrintingItem
        dpi.Mapping = "AfterTax"
        dpi.Value = Configuration.FormatToString(Me.TaxBase + Me.Amount, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)
       
      End If
      If TypeOf Me.Vat.RefDoc Is BillIssue Then
        Dim bi As BillIssue = CType(Me.Vat.RefDoc, BillIssue)
        myCount = bi.ItemCollection.Count
        If Not bi.SingleVat Then
          showSpecificLineOnly = True
        End If
        Dim SummaryAdvanceAmount As Decimal = 0
        For Each bitem As Milestone In bi.ItemCollection
          If bitem.TaxType.Value <> 0 Then
            SummaryAdvanceAmount += (bitem.Advance / (100 + bitem.TaxRate) * 100)
          Else
            SummaryAdvanceAmount += bitem.Advance
          End If
        Next
        'SummaryAdvanceAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "SummaryAdvanceAmount"
        dpi.Value = Configuration.FormatToString(Me.TaxBase + Me.Amount, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)
      End If

      '**************************************Line Items*********************************************
      Dim ls As ArrayList = Me.Lines
      Dim sumRetention As Decimal = 0
      If Not ls Is Nothing Then
        Dim y As Integer = 0
        Dim i As Integer = 0 'เริ่มไปก่อนแล้ว
        Dim j As Integer = 0

        Dim sumAdvance As Decimal = 0
        Dim sumDiscount As Decimal = 0
        Dim sumMilestoneAmount As Decimal = 0
        Dim sumAftertax As Decimal = 0

        For Each lineText As String In ls
          j += 1
          If Not showSpecificLineOnly OrElse (j = Me.LineNumber OrElse ls.Count <> myCount) Then
            Dim lineTexts As String() = lineText.Split("|"c)
            If lineTexts.Length > 1 Then
              'Item.LineNumber
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.LineNumber"
              If lineTexts(13) = "Detail" Then
                dpi.Value = ""
              Else
                dpi.Value = y + 1
              End If
              dpi.DataType = "System.Int32"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Name
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Name"
              dpi.Value = lineTexts(0)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Unit
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Unit"
              dpi.Value = lineTexts(8)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Qty
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Qty"
              dpi.Value = lineTexts(9)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.UnitPrice
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.UnitPrice"
              dpi.Value = lineTexts(1)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.UnitPrice
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.RealUnitPrice"
              dpi.Value = lineTexts(1)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Amount"
              dpi.Value = lineTexts(2)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.DiscountRate
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.DiscountRate"
              dpi.Value = lineTexts(10)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.DiscountAmount()
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.DiscountAmount"
              dpi.Value = lineTexts(4)
              dpi.DataType = "System.Decimal"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.Note
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Note"
              dpi.Value = lineTexts(3)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              ''Item.Amount
              'dpi = New DocPrintingItem
              'dpi.Mapping = "Item.Amount"
              'dpi.Value = lineTexts(2)
              'dpi.DataType = "System.String"
              'dpi.Row = i + 1
              'dpi.Table = "Item"
              'dpiColl.Add(dpi)

              'Item.UnitPriceWithoutDeduct
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.UnitPriceWithoutDeduct"
              dpi.Value = lineTexts(6)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.AmountWithoutDeduct
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.AmountWithoutDeduct"
              dpi.Value = lineTexts(6)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.TaxBase
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.TaxBase"
              dpi.Value = lineTexts(12)
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              If IsNumeric(lineTexts(4)) Then
                sumDiscount += CDec(lineTexts(4))
              End If
              If IsNumeric(lineTexts(5)) Then
                sumAdvance += CDec(lineTexts(5))
              End If
              If IsNumeric(lineTexts(6)) Then
                sumMilestoneAmount += CDec(lineTexts(6))
              End If
              If IsNumeric(lineTexts(7)) Then
                sumRetention += CDec(lineTexts(7))
              End If
              If IsNumeric(lineTexts(11)) Then
                sumAftertax += CDec(lineTexts(11))
              End If

              y += 1
            Else
              'Item.Name
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Name"
              dpi.Value = lineText
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)
            End If
            i += 1
          End If
        Next
        '************************************End Line Items***********************************************
        Dim distRate As String = ""
        Dim distAmt As Decimal = 0
        If TypeOf (Me.Vat.RefDoc) Is ReceiveSelection Then
          For Each rcItem As SaleBillIssueItem In CType(Me.Vat.RefDoc, ReceiveSelection).ItemCollection  'bi.ItemCollection
            If rcItem.EntityId.Equals(83) Then  'GoodsSold
              Dim gs As New GoodsSold(rcItem.Id)
              distRate = gs.Discount.Rate
              distAmt = gs.Discount.Amount
            End If
          Next

          sumDiscount = distAmt
        End If
        'DiscountRate
        dpi = New DocPrintingItem
        dpi.Mapping = "DiscountRate"
        dpi.Value = distRate
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'DiscountAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "DiscountAmount"
        dpi.Value = Configuration.FormatToString(distAmt, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)

        'Gross
        dpi = New DocPrintingItem
        dpi.Mapping = "Gross"
        dpi.Value = Configuration.FormatToString(sumMilestoneAmount, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)

        'SummaryMileStoneAmount 
        dpi = New DocPrintingItem
        dpi.Mapping = "SummaryMileStoneAmount"
        dpi.Value = Configuration.FormatToString(sumMilestoneAmount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SummaryDiscountAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "SummaryDiscountAmount"
        dpi.Value = Configuration.FormatToString(sumDiscount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'AfterDiscountAmount 
        dpi = New DocPrintingItem
        dpi.Mapping = "AfterDiscountAmount"
        dpi.Value = Configuration.FormatToString(sumMilestoneAmount - sumDiscount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SummaryAdvanceAmount 
        dpi = New DocPrintingItem
        dpi.Mapping = "SummaryAdvanceAmount"
        dpi.Value = Configuration.FormatToString(sumAdvance, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        ''AfterAdvanceAmount 
        'dpi = New DocPrintingItem
        'dpi.Mapping = "AftertaxAdvance"
        'dpi.Value = Configuration.FormatToString(sumMilestoneAmount - sumDiscount, DigitConfig.Price)
        'dpi.DataType = "System.String"
        'dpiColl.Add(dpi)

        'AfterAdvanceAmount 
        dpi = New DocPrintingItem
        dpi.Mapping = "AfterAdvanceAmount"
        dpi.Value = Configuration.FormatToString((sumMilestoneAmount - sumDiscount) - sumAdvance, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SummaryRetentionAmount 
        dpi = New DocPrintingItem
        dpi.Mapping = "SummaryRetentionAmount"
        dpi.Value = Configuration.FormatToString(sumRetention, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'AfterRetionAmount 
        dpi = New DocPrintingItem
        dpi.Mapping = "AfterRetionAmount"
        dpi.Value = Configuration.FormatToString((sumAftertax - sumDiscount) - sumAdvance, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

      End If

      Return dpiColl
    End Function
    Public ReadOnly Property Lines() As ArrayList
      Get
        Me.m_lines = New ArrayList
        If Not Me.Vat Is Nothing Then
          If TypeOf Me.Vat.RefDoc Is BillIssue Then 'รับวางบิล
            Dim bi As BillIssue = CType(Me.Vat.RefDoc, BillIssue)
            If Not Me.Milestone Is Nothing Then 'มี Milestone แปะอยู่
              Dim item As Milestone = Me.Milestone
              Dim itemText As String = ""
              itemText = item.Name & _
              "|" & Configuration.FormatToString(item.RealMileStoneAmount, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(item.RealMileStoneAmount, DigitConfig.Price) & _
              "|" & item.Note & _
              "|" & Configuration.FormatToString(item.Discount.Amount + item.Penalty, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(item.Advance, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(item.RealMileStoneAmount, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(item.Retention, DigitConfig.Price) & _
              "|รายการ" & _
              "|" & Configuration.FormatToString(1, DigitConfig.Qty) & _
              "|" & item.Discount.Rate & _
              "|" & Configuration.FormatToString(item.AfterTax, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(item.RealTaxBase, DigitConfig.Price) & _
              "|"
              Me.m_lines.Add(itemText)

            Else 'ไม่มี Milestone แปะอยู่
              For Each item As Milestone In bi.ItemCollection
                Dim itemText As String = ""
                itemText = item.Name & _
                "|" & Configuration.FormatToString(item.RealMileStoneAmount, DigitConfig.Price) & _
                "|" & Configuration.FormatToString(item.RealMileStoneAmount, DigitConfig.Price) & _
                "|" & item.Note & _
                "|" & Configuration.FormatToString(item.Discount.Amount + item.Penalty, DigitConfig.Price) & _
                "|" & Configuration.FormatToString(item.Advance, DigitConfig.Price) & _
                "|" & Configuration.FormatToString(item.RealMileStoneAmount, DigitConfig.Price) & _
                "|" & Configuration.FormatToString(item.Retention, DigitConfig.Price) & _
                "|รายการ" & _
                "|" & Configuration.FormatToString(1, DigitConfig.Qty) & _
                "|" & item.Discount.Rate & _
                "|" & Configuration.FormatToString(item.AfterTax, DigitConfig.Price) & _
                "|" & Configuration.FormatToString(item.RealTaxBase, DigitConfig.Price) & _
              "|"
                Me.m_lines.Add(itemText)
                If bi.ShowDetail Then
                  For Each miDetailRow As TreeRow In item.ItemTable.Childs
                    'miDetailRow("milestonei_desc").ToString
                    Dim itext As String = ""
                    itext = miDetailRow("milestonei_desc").ToString & _
                    "|" & _
                    "|" & _
                    "|" & miDetailRow("milestonei_note").ToString & _
                    "|" & _
                    "|" & _
                    "|" & _
                    "|" & _
                    "|" & _
                    "|" & _
                    "|" & _
                    "|" & _
                    "|" & _
                    "|Detail"
                    Me.m_lines.Add(itext)
                  Next
                End If
              Next
            End If
          ElseIf TypeOf (Me.Vat.RefDoc) Is ReceiveSelection Then 'รับชำระหนี้
            Dim rs As ReceiveSelection = CType(Me.Vat.RefDoc, ReceiveSelection)
            If Not Me.Milestone Is Nothing Then 'มี Milestone แปะอยู่
              Dim item As Milestone = Me.Milestone
              Dim rcItem As SaleBillIssueItem
              For Each rcItem In rs.ItemCollection
                If (item.Id = rcItem.Id AndAlso item.Id <> 0) OrElse rcItem Is item Then
                  Exit For
                End If
              Next
              If rcItem Is Nothing Then
                rcItem = New SaleBillIssueItem
              End If
              Dim tb As Decimal = item.RealMileStoneAmount
              Dim dsc As Decimal = item.Discount.Amount + item.Penalty
              Dim adv As Decimal = item.Advance
              If rcItem.Amount <> rcItem.UnreceivedAmount Then
                tb = Me.TaxBase
                dsc = 0
                adv = 0
              End If
              Dim itemText As String = ""
              itemText = item.Name & _
              "|" & Configuration.FormatToString(tb, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(tb, DigitConfig.Price) & _
              "|" & item.Note & _
              "|" & Configuration.FormatToString(dsc, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(adv, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(tb, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(item.Retention, DigitConfig.Price) & _
              "|รายการ" & _
              "|" & Configuration.FormatToString(1, DigitConfig.Qty) & _
              "|" & item.Discount.Rate & _
              "|" & Configuration.FormatToString(item.AfterTax, DigitConfig.Price) & _
              "|" & Configuration.FormatToString(item.RealTaxBase, DigitConfig.Price) & _
              "|"
              Me.m_lines.Add(itemText)
            Else 'ไม่มี Milestone แปะอยู่       
              If rs.SingleVat Then
                For Each rcItem As SaleBillIssueItem In rs.ItemCollection
                  If rcItem.EntityId = 83 Then 'GoodsSold
                    Dim gs As New GoodsSold(rcItem.Id)
                    For Each gsItem As GoodsSoldItem In gs.ItemCollection
                      Dim itemText As String = ""
                      itemText = gsItem.Entity.Name & _
                      "|" & Configuration.FormatToString(gsItem.UnitPrice, DigitConfig.Price) & _
                      "|" & Configuration.FormatToString(gsItem.Amount, DigitConfig.Price) & _
                      "|" & gsItem.Note & _
                      "|" & Configuration.FormatToString(gsItem.Discount.Amount, DigitConfig.Price) & _
                      "|" & Configuration.FormatToString(0, DigitConfig.Price) & _
                      "|" & Configuration.FormatToString(gsItem.Amount, DigitConfig.Price) & _
                      "|" & Configuration.FormatToString(0, DigitConfig.Price) & _
                      "|" & gsItem.Unit.Name & _
                      "|" & Configuration.FormatToString(gsItem.Qty, DigitConfig.Qty) & _
                      "|" & gsItem.Discount.Rate & _
                      "|" & Configuration.FormatToString(gsItem.AfterTax, DigitConfig.Price) & _
                      "|" & Configuration.FormatToString(gsItem.TaxBase, DigitConfig.Price) & _
              "|"
                      Me.m_lines.Add(itemText)
                    Next
                  ElseIf rcItem.EntityId.Equals(75) _
                  OrElse rcItem.EntityId.Equals(77) _
                  OrElse rcItem.EntityId.Equals(78) _
                  OrElse rcItem.EntityId.Equals(79) _
                  OrElse rcItem.EntityId.Equals(86) Then          'MileStone
                    Dim mi As New Milestone(rcItem.Id)
                    Dim itemText As String = ""
                    itemText = mi.Name & _
                    "|" & Configuration.FormatToString(mi.RealMileStoneAmount, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(mi.RealMileStoneAmount, DigitConfig.Price) & _
                    "|" & mi.Note & _
                    "|" & Configuration.FormatToString(mi.Discount.Amount + mi.Penalty, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(mi.Advance, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(mi.RealMileStoneAmount, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(mi.Retention, DigitConfig.Price) & _
                    "|รายการ" & _
                    "|" & Configuration.FormatToString(1, DigitConfig.Qty) & _
                    "|" & mi.Discount.Rate & _
                    "|" & Configuration.FormatToString(mi.AfterTax, DigitConfig.Price) & _
                     "|" & Configuration.FormatToString(mi.RealTaxBase, DigitConfig.Price) & _
              "|"
                    Me.m_lines.Add(itemText)
                    'Dim mitem As New Milestone(rcItem.StockId)
                    If rs.ItemCollection.ShowDetail Then
                      For Each miDetailRow As TreeRow In mi.ItemTable.Childs
                        'miDetailRow("milestonei_desc").ToString
                        Dim itext As String = ""
                        itext = miDetailRow("milestonei_desc").ToString & _
                        "|" & _
                        "|" & _
                        "|" & miDetailRow("milestonei_note").ToString & _
                        "|" & _
                        "|" & _
                        "|" & _
                        "|" & _
                        "|" & _
                        "|" & _
                        "|" & _
                        "|" & _
                        "|" & _
                        "|Detail"
                        Me.m_lines.Add(itext)
                      Next
                    End If
                  End If
                Next
              Else ' หลายใบ
                Dim i As Integer = Me.Vat.ItemCollection.IndexOf(Me)
                Dim rcItem As SaleBillIssueItem = rs.ItemCollection(i)
                If rcItem.EntityId = 83 Then 'GoodsSold
                  Dim gs As New GoodsSold(rcItem.Id)
                  For Each gsItem As GoodsSoldItem In gs.ItemCollection
                    Dim itemText As String = ""
                    itemText = gsItem.Entity.Name & _
                    "|" & Configuration.FormatToString(gsItem.UnitPrice, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(gsItem.Amount, DigitConfig.Price) & _
                    "|" & gsItem.Note & _
                    "|" & Configuration.FormatToString(gsItem.Discount.Amount, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(0, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(gsItem.Amount, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(0, DigitConfig.Price) & _
                    "|" & gsItem.Unit.Name & _
                    "|" & Configuration.FormatToString(gsItem.Qty, DigitConfig.Qty) & _
                    "|" & gsItem.Discount.Rate & _
                    "|" & Configuration.FormatToString(gsItem.AfterTax, DigitConfig.Price) & _
                    "|" & Configuration.FormatToString(gsItem.TaxBase, DigitConfig.Price) & _
              "|"
                    Me.m_lines.Add(itemText)
                  Next
                ElseIf rcItem.EntityId.Equals(75) _
                OrElse rcItem.EntityId.Equals(77) _
                OrElse rcItem.EntityId.Equals(78) _
                OrElse rcItem.EntityId.Equals(79) _
                OrElse rcItem.EntityId.Equals(86) Then 'MileStone
                  Dim mi As New Milestone(rcItem.Id)
                  Dim tb As Decimal = mi.RealMileStoneAmount
                  Dim dsc As Decimal = mi.Discount.Amount + mi.Penalty
                  Dim adv As Decimal = mi.Advance
                  If rcItem.Amount <> rcItem.UnreceivedAmount Then
                    tb = Me.TaxBase
                    dsc = 0
                    adv = 0
                  End If
                  Dim itemText As String = ""
                  itemText = mi.Name & _
                  "|" & Configuration.FormatToString(tb, DigitConfig.Price) & _
                  "|" & Configuration.FormatToString(tb, DigitConfig.Price) & _
                  "|" & mi.Note & _
                  "|" & Configuration.FormatToString(dsc, DigitConfig.Price) & _
                  "|" & Configuration.FormatToString(adv, DigitConfig.Price) & _
                  "|" & Configuration.FormatToString(tb, DigitConfig.Price) & _
                  "|" & Configuration.FormatToString(mi.Retention, DigitConfig.Price) & _
                  "|รายการ" & _
                  "|" & Configuration.FormatToString(1, DigitConfig.Qty) & _
                  "|" & mi.Discount.Rate & _
                  "|" & Configuration.FormatToString(mi.AfterTax, DigitConfig.Price) & _
                  "|" & Configuration.FormatToString(mi.RealTaxBase, DigitConfig.Price) & _
              "|"
                  Me.m_lines.Add(itemText)
                  'Dim mitem As New Milestone(rcItem.StockId)
                  If rs.ItemCollection.ShowDetail Then
                    For Each miDetailRow As TreeRow In mi.ItemTable.Childs
                      'miDetailRow("milestonei_desc").ToString
                      Dim itext As String = ""
                      itext = miDetailRow("milestonei_desc").ToString & _
                      "|" & _
                      "|" & _
                      "|" & miDetailRow("milestonei_note").ToString & _
                      "|" & _
                      "|" & _
                      "|" & _
                      "|" & _
                      "|" & _
                      "|" & _
                      "|" & _
                      "|" & _
                      "|" & _
                      "|Detail"
                      Me.m_lines.Add(itext)
                    Next
                  End If
                End If
              End If
            End If
          End If
        End If
        Return m_lines
      End Get
    End Property
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
Public Class VatItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_vat As Vat
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As Vat)
      Me.m_vat = owner
      If Not Me.m_vat.Originated Then
        Return
      End If


      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetVatItems" _
      , New SqlParameter("@vat_id", Me.m_vat.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New VatItem(row, "")
        item.Vat = m_vat
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As VatItem
      Get
        Return CType(MyBase.List.Item(index), VatItem)
      End Get
      Set(ByVal value As VatItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim amt As Decimal = 0
        For Each item As VatItem In Me
          amt += Configuration.Format(item.Amount, DigitConfig.Price)
        Next
        Return amt
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each vi As VatItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        vi.CopyToDataRow(newRow)
        vi.ItemValidateRow(newRow)
        newRow.Tag = vi
      Next
    End Sub
#End Region

#Region "Collection Methods"
    ''' <summary>
    ''' เปลี่ยนแปลง GL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetRefDocGLChange()
      If Not m_vat Is Nothing Then
        If TypeOf m_vat.RefDoc Is SimpleBusinessEntityBase Then
          CType(m_vat.RefDoc, SimpleBusinessEntityBase).OnGlChanged()
        End If
      End If
    End Sub
    Public Function Add(ByVal value As VatItem) As Integer
      If Not m_vat Is Nothing Then
        value.Vat = m_vat
      End If
      SetRefDocGLChange()
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As VatItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As VatItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As VatItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As VatItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As VatItemEnumerator
      Return New VatItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As VatItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As VatItem)
      If Not m_vat Is Nothing Then
        value.Vat = m_vat
      End If
      SetRefDocGLChange()
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As VatItem)
      SetRefDocGLChange()
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      SetRefDocGLChange()
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class VatItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As VatItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, VatItem)
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

  Public Class VatItemWithCustomNote
    Implements IPrintableEntity
    Private m_vitem As VatItem
    Public Sub New(ByVal vitem As VatItem)
      m_vitem = vitem
    End Sub

    Public Property Code As String Implements IIdentifiable.Code
      Get

      End Get
      Set(ByVal value As String)

      End Set
    End Property

    Public Property Id As Integer Implements IIdentifiable.Id
      Get

      End Get
      Set(ByVal value As Integer)

      End Set
    End Property

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath

    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim ret As DocPrintingItemCollection = m_vitem.GetDocPrintingEntries
      If Not m_vitem.Vat Is Nothing AndAlso TypeOf m_vitem.Vat.RefDoc Is IHasCustomNote Then
        Dim coll As CustomNoteCollection        ' = CType(m_entity, IHasCustomNote).GetCustomNoteCollection
        If TypeOf m_vitem.Vat.RefDoc Is IHasMainDoc Then
          If Not (TypeOf (m_vitem.Vat.RefDoc) Is JournalEntry) Then
            coll = CType(CType(m_vitem.Vat.RefDoc, IHasMainDoc).MainDoc, IHasCustomNote).GetCustomNoteCollection
          Else
            coll = CType(m_vitem.Vat.RefDoc, IHasCustomNote).GetCustomNoteCollection
          End If
        Else
          coll = CType(m_vitem.Vat.RefDoc, IHasCustomNote).GetCustomNoteCollection
        End If
        For Each note As CustomNote In coll
          Dim dpi As New DocPrintingItem
          dpi.Mapping = "Note." & note.NoteName
          If note.IsDropDown Then
            dpi.Value = Boolean.Parse(CStr(note.Note))
            dpi.DataType = "System.Boolean"
          Else
            dpi.Value = CStr(note.Note)
            dpi.DataType = "System.String"
          End If
          ret.Add(dpi)
        Next
      End If
      Return ret
    End Function
  End Class
End Namespace
