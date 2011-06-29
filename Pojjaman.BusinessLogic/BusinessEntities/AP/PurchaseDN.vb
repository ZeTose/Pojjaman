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
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class PurchaseDNStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "purchasedn_status"
      End Get
    End Property
#End Region

  End Class
  Public Class PurchaseDN
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IVatable, IBillAcceptable, IPrintableEntity, IApprovAble, IHasIBillablePerson

    'UNDONE'UNDONE'UNDONE'UNDONE'UNDONE'UNDONE'UNDONE'UNDONE'UNDONE
#Region "Members"
    Private m_supplier As Supplier

    Private m_docDate As Date

    Private m_vat As Vat
    Private m_payment As Payment
    Private m_je As JournalEntry

    Private m_note As String
    Private m_creditPeriod As Long

    Private m_discount As Discount
    Private m_taxRate As Decimal
    Private m_taxType As TaxType

    Private m_status As PurchaseDNStatus

    Private m_refDocCollection As DNRefDocCollection
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
        .m_supplier = New Supplier
        .m_creditPeriod = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_note = ""
        .m_discount = New Discount("")
        .m_taxType = New TaxType(1)
        .m_docDate = Now.Date
        .m_status = New PurchaseDNStatus(-1)
        .m_refDocCollection = New DNRefDocCollection(Me)

        '----------------------------Tab Entities-----------------------------------------
        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_payment = New Payment(Me)
        .m_payment.DocDate = Me.m_docDate
        '----------------------------End Tab Entities-----------------------------------------
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("supplier.supplier_id") Then
          If Not dr.IsNull("supplier.supplier_id") Then
            .m_supplier = New Supplier(dr, "supplier.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "stock_entity") Then
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & "stock_entity")))
          End If
        End If
        If Not dr.IsNull(aliasPrefix & "stock_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "stock_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditperiod"))
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "stock_taxtype")))
        End If
        ' PO Tax Rate
        If Not dr.IsNull(aliasPrefix & "stock_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "stock_taxrate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stock_status") AndAlso Not dr.IsNull(aliasPrefix & "stock_status") Then
          .m_status = New PurchaseDNStatus(CInt(dr(aliasPrefix & "stock_status")))
        End If

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 1

        .m_payment = New Payment(Me)

        .m_je = New JournalEntry(Me)
        .m_refDocCollection = New DNRefDocCollection(Me)
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property RefDocCollection() As DNRefDocCollection      Get        Return m_refDocCollection      End Get      Set(ByVal Value As DNRefDocCollection)        m_refDocCollection = Value      End Set    End Property
    Public Property Supplier() As Supplier      Get        Return m_supplier      End Get      Set(ByVal Value As Supplier)        m_supplier = Value        'Todo:      End Set    End Property    Public Property DocDate() As Date Implements IVatable.Date, IPayable.Date, IGLAble.Date      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public Property Vat() As Vat Implements IVatable.Vat      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set    End Property    Public Property Note() As String Implements IPayable.Note, IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Long      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Long)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, PurchaseDNStatus)      End Set    End Property    Public ReadOnly Property Gross() As Decimal      Get        Return Me.RefDocCollection.Amount + Me.RefDocCollection.ItemAmount      End Get    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property DiscountAmount() As Decimal      Get        Me.Discount.AmountBeforeDiscount = Me.Gross        Return Me.Discount.Amount      End Get    End Property    Public Property TaxRate() As Decimal      Get        Return m_taxRate      End Get      Set(ByVal Value As Decimal)        m_taxRate = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Dim sumInItems As Decimal = 0
        Dim sumInDocs As Decimal = 0
        Select Case Me.TaxType.Value
          Case 0
            sumInDocs = 0
          Case 1
            sumInDocs = Me.RefDocCollection.Amount
          Case 2
            sumInDocs = Me.RefDocCollection.Amount * (100 / (Me.TaxRate + 100))
        End Select
        If Me.RefDocCollection.ItemAmount = 0 Then
          sumInItems = 0
        Else
          Select Case Me.TaxType.Value
            Case 0
              sumInItems = 0
            Case 1
              Dim myItemAmt As Decimal = Me.RefDocCollection.ItemAmount
              Dim myDiscount As Decimal = Me.DiscountAmount
              For Each doc As DNRefDoc In Me.RefDocCollection
                For Each item As PurchaseDNItem In doc.ItemCollection
                  If Not item.UnVatable Then
                    sumInItems += (item.Amount - _
                    ( _
                    (item.Amount / myItemAmt) * myDiscount) _
                    )
                  End If
                Next
              Next
            Case 2
              Dim myItemAmt As Decimal = Me.RefDocCollection.ItemAmount
              Dim myDiscount As Decimal = Me.DiscountAmount
              For Each doc As DNRefDoc In Me.RefDocCollection
                For Each item As PurchaseDNItem In doc.ItemCollection
                  If Not item.UnVatable Then
                    sumInItems += (item.Amount - ((item.Amount / myItemAmt) * myDiscount)) * (100 / (Me.TaxRate + 100))
                  End If
                Next
              Next
          End Select
        End If
        Return sumInDocs + sumInItems
      End Get
      Set(ByVal Value As Decimal)
      End Set
    End Property    Public Property TaxType() As TaxType      Get        Return m_taxType      End Get      Set(ByVal Value As TaxType)        m_taxType = Value        OnPropertyChanged(Me, New PropertyChangedEventArgs)      End Set    End Property    Public ReadOnly Property TaxAmount() As Decimal      Get        Return (Me.TaxRate * Me.TaxBase) / 100      End Get    End Property    Public ReadOnly Property BeforeTax() As Decimal      Get        Select Case Me.TaxType.Description.ToLower
          Case "ไม่มี"
            Return Me.Gross - Me.DiscountAmount
          Case "แยก"
            Return Me.Gross - Me.DiscountAmount
          Case "รวม"
            Return Me.AfterTax - Me.TaxAmount
        End Select      End Get    End Property    Public ReadOnly Property AfterTax() As Decimal      Get        Select Case Me.TaxType.Description.ToLower
          Case "ไม่มี"
            Return Me.BeforeTax
          Case "แยก"
            Return Me.BeforeTax + Me.TaxAmount
          Case "รวม"
            Return Me.Gross - Me.DiscountAmount
        End Select      End Get    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PurchaseDN"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.PurchaseDN.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PurchaseDN"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PurchaseDN"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PurchaseDN.ListLabel}"
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
    Public Shared Function GetDocSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PurchaseDNDoc")
      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stockstock_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stockstock_note", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PurchaseDN")
      myDatatable.Columns.Add(New DataColumn("Ref", GetType(Boolean)))

      myDatatable.Columns.Add(New DataColumn("GoodsReceipt_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("GoodsReceipt_Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("GoodsReceiptItem_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_discrate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_acct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("AccountCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Account", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AccountButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unvatable", GetType(Boolean)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldpay As Integer, ByVal oldvat As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_payment.Id = oldpay
      Me.m_vat.Id = oldvat
      Me.m_je.Id = oldje
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_payment.Code = oldJecode
      Me.m_payment.AutoGen = oldjeautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      ValidateError = Me.Payment.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.Vat.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      Return New SaveErrorException("0")

    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim tmpTaxBase As Decimal = Configuration.Format(Me.TaxBase, DigitConfig.Price)
        Dim tmpVatTaxBase As Decimal = Configuration.Format(Me.Vat.TaxBase, DigitConfig.Price)
        If tmpTaxBase <> tmpVatTaxBase Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.TaxBaseNotEqualRefDocTaxBase}"), _
          New String() {Configuration.FormatToString(tmpVatTaxBase, DigitConfig.Price) _
          , Configuration.FormatToString(tmpTaxBase, DigitConfig.Price)})
        End If
        If Me.RefDocCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

        Dim oldid As Integer = Me.Id
        Dim oldpay As Integer = Me.m_payment.Id
        Dim oldvat As Integer = Me.m_vat.Id
        Dim oldje As Integer = Me.m_je.Id

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@stock_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_payment.Status.Value = 4
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New PurchaseDNStatus(2)
        End If

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", Me.Supplier.Id))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entityType", Me.Supplier.EntityId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", ValidDateOrDBNull(Me.DocDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ""))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discRate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discAmt", Me.DiscountAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.TaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforeTax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.TaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_afterTax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return ValidateError2
        End If
        '---==Validated การทำ before save ของหน้าย่อยอื่นๆ ====

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Try

          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldpay, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            'ChangeOldItemStatus(conn, trans)
            SaveDetail(Me.Id, conn, trans)
            SaveDocs(Me.Id, conn, trans)
            'ChangeNewItemStatus(conn, trans)

            Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
            If Not IsNumeric(savePaymentError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return savePaymentError
            Else
              Select Case CInt(savePaymentError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldpay, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return savePaymentError
                Case Else
              End Select
            End If

            Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveVatError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveVatError
            Else
              Select Case CInt(saveVatError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldpay, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveVatError
                Case Else
              End Select
            End If

            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If
            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveJeError.Message) Then
              trans.Rollback()
              Me.ResetID(oldid, oldpay, oldvat, oldje)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.ResetID(oldid, oldpay, oldvat, oldje)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveJeError
                Case -2
                  'Post ไปแล้ว
                  Return saveJeError
                Case Else
              End Select
            End If

            trans.Commit()
            'Return New SaveErrorException(returnVal.Value.ToString)
          Catch ex As SqlException
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldvat, oldje)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
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
     
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPOItemStatus", New SqlParameter("@stock_id", Me.Id))
    End Sub
    Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPOItemStatus", New SqlParameter("@stock_id", Me.Id))
    End Sub
    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each doc As DNRefDoc In Me.RefDocCollection
        ret &= doc.Id.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDocs(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

      Dim da As New SqlDataAdapter("Select * from stockstock where stockstock_stock=" & Me.Id, conn)
      Dim daOldRef As New SqlDataAdapter("Select * from stock where stock_id in (select stockstock_refstock from stockstock where stockstock_stock=" & Me.Id & ")" & _
      " and stock_id not in (select stockstock_refstock from stockstock where stockstock_stock <> " & Me.Id & ")" & _
      " and stock_id not in (select distinct stock_id from stock inner join stockitem item on stocki_stock = stock_id" & _
      " inner join stockitem item2 on item2.stocki_refsequence = item.stocki_sequence" & _
      " and item2.stocki_status <> 0)" & _
      " and stock_id not in (select stock_id from payselectionitem where stock_status <> 0)" & _
      " and stock_id not in (select stock_id from BillAcceptanceItem where stock_status <> 0)" _
      , conn)

      Dim daNewRef As SqlDataAdapter
      Dim refIds As String = Me.GetRefIdString
      If refIds.Length > 0 Then
        daNewRef = New SqlDataAdapter("Select * from stock where stock_id in (" & refIds & ")", conn)
      End If

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
      da.FillSchema(ds, SchemaType.Mapped, "stockstock")
      da.Fill(ds, "stockstock")

      cmdBuilder = New SqlCommandBuilder(daOldRef)
      daOldRef.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daOldRef.FillSchema(ds, SchemaType.Mapped, "oldstockstock")
      daOldRef.Fill(ds, "oldstockstock")

      Dim dtNewRef As DataTable
      If Not daNewRef Is Nothing Then
        cmdBuilder = New SqlCommandBuilder(daNewRef)
        daNewRef.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daNewRef.FillSchema(ds, SchemaType.Mapped, "newstockstock")
        daNewRef.Fill(ds, "newstockstock")
        dtNewRef = ds.Tables("newstockstock")
        For Each row As DataRow In dtNewRef.Rows
          If Not row.IsNull("stock_status") AndAlso IsNumeric(row("stock_status")) Then
            If CInt(row("stock_status")) = 2 Then
              row("stock_status") = 3
            End If
          End If
        Next
      End If

      Dim dt As DataTable = ds.Tables("stockstock")

      Dim dtOldRef As DataTable = ds.Tables("oldstockstock")

      For Each row As DataRow In dtOldRef.Rows
        Dim found As Boolean = False
        For Each doc As DNRefDoc In Me.RefDocCollection
          If doc.Id = CInt(row("stock_id")) Then
            'เจอแล้ว --> 
            found = True
            Exit For
          End If
        Next
        If Not found Then
          'ไม่เจอ
          If Not row.IsNull("stock_status") AndAlso IsNumeric(row("stock_status")) Then
            If CInt(row("stock_status")) = 3 Then
              row("stock_status") = 2
            End If
          End If
        End If
      Next

      Dim i As Integer = 0
      With ds.Tables("stockstock")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each doc As DNRefDoc In Me.RefDocCollection
          Dim dr As DataRow = .NewRow
          dr("stockstock_stock") = Me.Id
          dr("stockstock_refstock") = doc.Id
          dr("stockstock_refstockType") = doc.EntityId
          dr("stockstock_linenumber") = i
          dr("stockstock_amt") = doc.Amount
          dr("stockstock_note") = doc.Note
          .Rows.Add(dr)
        Next
      End With

      If Not daNewRef Is Nothing Then
        AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If
      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldRef.RowUpdated, AddressOf tmpDa_MyRowUpdated

      If Not daNewRef Is Nothing Then
        AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If

      If Not daNewRef Is Nothing Then
        daNewRef.Update(GetDeletedRows(dtNewRef))
      End If
      daOldRef.Update(GetDeletedRows(dtOldRef))
      da.Update(GetDeletedRows(dt))

      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.ModifiedCurrent))
      End If
      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.ModifiedCurrent))

      If Not daNewRef Is Nothing Then
        da.Update(dtNewRef.Select("", "", DataViewRowState.Added))
      End If
      da.Update(dt.Select("", "", DataViewRowState.Added))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.Added))

    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

      Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
      Dim daWbs As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)


      Dim ds As New DataSet

      Dim cmdBuilder As New SqlCommandBuilder(da)
      da.SelectCommand.Transaction = trans
      da.DeleteCommand = cmdBuilder.GetDeleteCommand
      da.DeleteCommand.Transaction = trans
      da.InsertCommand = cmdBuilder.GetInsertCommand
      da.InsertCommand.Transaction = trans
      da.UpdateCommand = cmdBuilder.GetUpdateCommand
      da.UpdateCommand.Transaction = trans
      da.InsertCommand.CommandText &= "; Select * From stockitem Where stocki_sequence = @@IDENTITY"
      da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
      cmdBuilder = Nothing
      da.FillSchema(ds, SchemaType.Mapped, "stockitem")
      da.Fill(ds, "stockitem")

      cmdBuilder = New SqlCommandBuilder(daWbs)
      daWbs.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daWbs.FillSchema(ds, SchemaType.Mapped, "stockiwbs")
      daWbs.Fill(ds, "stockiwbs")
      ds.Relations.Add("sequence", ds.Tables!stockitem.Columns!stocki_sequence, ds.Tables!stockiwbs.Columns!stockiw_sequence)

      Dim dt As DataTable = ds.Tables("stockitem")
      Dim dc As DataColumn = dt.Columns!stocki_sequence
      dc.AutoIncrement = True
      dc.AutoIncrementSeed = -1
      dc.AutoIncrementStep = -1

      Dim dtWbs As DataTable = ds.Tables("stockiwbs")

      For Each row As DataRow In ds.Tables("stockiwbs").Rows
        row.Delete()
      Next
      For Each row As DataRow In ds.Tables("stockitem").Rows
        row.Delete()
      Next
      Dim i As Integer = 0 'Line Running
      For Each refdoc As DNRefDoc In Me.RefDocCollection
        For Each item As PurchaseDNItem In refdoc.ItemCollection
          i += 1
          Dim dr As DataRow = dt.NewRow
          If item.GoodsReceiptId = 0 Then
            dr("stocki_refdoc") = DBNull.Value
            dr("stocki_refdoclinenumber") = DBNull.Value
          Else
            dr("stocki_refdoc") = item.GoodsReceiptId
            dr("stocki_refdoclinenumber") = item.GoodsReceiptLine
          End If
          dr("stocki_toacct") = Me.ValidIdOrDBNull(refdoc.ToAccount)
          dr("stocki_toacctType") = 3
          dr("stocki_stock") = Me.Id
          dr("stocki_tocc") = Me.ValidIdOrDBNull(refdoc.ToCostCenter)
          dr("stocki_acct") = Me.ValidIdOrDBNull(item.Account)
          dr("stocki_linenumber") = i
          dr("stocki_entity") = item.Entity.Id
          dr("stocki_entityType") = item.ItemType.Value
          dr("stocki_itemName") = item.EntityName
          dr("stocki_unit") = item.Unit.Id
          dr("stocki_qty") = item.Qty
          dr("stocki_stockqty") = item.StockQty
          dr("stocki_unitprice") = item.UnitPrice
          dr("stocki_unitcost") = item.UnitCost
          dr("stocki_amt") = item.Amount
          dr("stocki_discrate") = item.Discount.Rate
          dr("stocki_discamt") = item.Discount.Amount
          dr("stocki_unvatable") = item.UnVatable
          dr("stocki_note") = item.Note
          dr("stocki_type") = Me.EntityId
          dr("stocki_iscancelled") = IIf(Me.Canceled, Me.Canceled, DBNull.Value)
          dr("stocki_status") = Me.Status.Value
          dr("stocki_refsequence") = 0
          'Add เข้า stockitem
          dt.Rows.Add(dr)
          For Each wbsd As WBSDistribute In item.WbsdColl
            Dim childDr As DataRow = dtWbs.NewRow
            childDr("stockiw_wbs") = wbsd.WBS.Id
            childDr("stockiw_percent") = wbsd.Percent
            childDr("stockiw_sequence") = dr("stocki_sequence")
            'Add เข้า stockiwbs
            dtWbs.Rows.Add(childDr)
          Next
        Next
      Next

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
        Dim currentkey As Integer = CInt(e.Row("stockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!stockiw_sequence = e.Row.GetParentRow("sequence")("stocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!stockiw_sequence = currentkey
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

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem

      'ภาษีซื้อ
      If Me.TaxAmount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B5.5"
        ji.Amount = Configuration.Format(Me.TaxAmount, DigitConfig.Price)
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jiColl.Add(ji)
      End If

      'ค่าใช้จ่ายอื่นๆ
      If Me.RefDocCollection.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "B5.4"
        ji.Amount = Me.RefDocCollection.Amount
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        jiColl.Add(ji)
      End If

      '      'ส่วนลดรับ
      '      If Me.DiscountAmount > 0 Then
      '          ji = New JournalEntryItem
      '          ji.Mapping = "B5.7"
      '          Dim disc As Decimal = 0
      '          If Me.TaxType.Value = 2 Then
      '              disc = Vat.GetExcludedVatAmount(Me.DiscountAmount, Me.TaxRate)
      '          Else
      '              disc = Me.DiscountAmount
      '          End If
      '          ji.Amount = disc
      '          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      '          jiColl.Add(ji)
      'End If


      '-------------------------------------HACK------------------------------------
      ''ส่วนลดการค้า
      'If Me.DiscountAmount > 0 Then
      'ji = New JournalEntryItem
      'ji.Mapping = "Through"
      'ji.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.TradeDiscount).Account
      'ji.Note = Me.StringParserService.Parse("${res:Global.TradeDiscount}")
      'Dim disc As Decimal = 0
      'If Me.TaxType.Value = 2 Then
      'disc = Vat.GetExcludedVatAmount(Me.DiscountAmount, Me.TaxRate)
      'Else
      'disc = Me.DiscountAmount
      'End If
      'ji.Amount = disc
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'jiColl.Add(ji)
      'End If
      '-------------------------------------HACK------------------------------------

      If Not Me.Payment Is Nothing Then
        'ส่วนต่างระหว่างยอดจ่ายกับยอดจริง ---> เจ้าหนี้
        Dim pmGross As Decimal = Me.Payment.Gross
        If Configuration.Compare(pmGross, Me.Payment.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "B5.6"
          ji.Amount = Me.Payment.Amount - pmGross
          If Not Me.Supplier.Account Is Nothing AndAlso Me.Supplier.Account.Originated Then
            ji.Account = Me.Supplier.Account
          End If
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          jiColl.Add(ji)
        End If
        jiColl.AddRange(Me.Payment.GetJournalEntries)
      End If
      jiColl.AddRange(Me.GetItemJournalEntries)
      Return jiColl
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem
      For Each doc As DNRefDoc In Me.RefDocCollection
        For Each item As PurchaseDNItem In doc.ItemCollection
          Dim itemType As Integer
          Dim blankMatched As Boolean = False
          Dim blankNoAcctMatched As Boolean = False
          Dim lciToolMatched As Boolean = False
          Dim lciToolNoAcctMatched As Boolean = False
          Dim assetMatched As Boolean = False
          Dim assetNoacctMatched As Boolean = False
          Dim itemAmountPerGross As Decimal
          If Me.Gross = 0 Then
            itemAmountPerGross = 0
          Else
            itemAmountPerGross = item.Amount / Me.Gross
          End If
          Dim itemRemainAmount As Decimal = (Me.Gross - Me.TaxAmount) * itemAmountPerGross
          For Each addedJi As JournalEntryItem In jiColl
            If Not item.ItemType Is Nothing Then
              Select Case item.ItemType.Value
                Case 0, 88, 89 'Blank  
                  Dim realAccount As Account
                  If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                    'ใช้ acct ในรายการ
                    realAccount = item.Account
                  End If
                  If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                    If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "B5.4" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += item.Amount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      blankMatched = True
                    End If
                  ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                    If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "B5.4" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += item.Amount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      blankNoAcctMatched = True
                    End If
                  End If
                Case 28  'Asset
                  Dim realAccount As Account
                  If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                    'ใช้ acct ในรายการ
                    realAccount = item.Account
                  End If
                  If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                    If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "B5.3" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += item.Amount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      assetMatched = True
                    End If
                  ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                    If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "B5.3" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += item.Amount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      assetNoacctMatched = True
                    End If
                  End If
                Case 42 ' LCI
                  Dim realAccount As Account
                  Dim entityAcct As Account
                  Dim lci As LCIItem = CType(item.Entity, LCIItem)
                  If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                    entityAcct = lci.Account
                  End If
                  If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                    'ใช้ acct ในรายการ
                    realAccount = item.Account
                  ElseIf Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
                    'ใช้ acct ของ lci
                    realAccount = entityAcct
                  End If
                  If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                    If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id Then
                      If addedJi.Mapping = "B5.1" Then
                        If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                          addedJi.Amount += item.Amount
                        Else
                          addedJi.Amount += itemRemainAmount
                        End If
                        lciToolMatched = True
                      End If
                    End If
                  ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                    If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
                      If addedJi.Mapping = "B5.1" Then
                        If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                          addedJi.Amount += item.Amount
                        Else
                          addedJi.Amount += itemRemainAmount
                        End If
                        lciToolNoAcctMatched = True
                      End If
                    End If
                  End If

                Case 19 'Tool
                  Dim realAccount As Account
                  If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                    'ใช้ acct ในรายการ
                    realAccount = item.Account
                  End If
                  If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                    If (Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = realAccount.Id) And addedJi.Mapping = "B5.2" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += item.Amount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      lciToolMatched = True
                    End If
                  ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                    If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) And addedJi.Mapping = "B5.2" Then
                      If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                        addedJi.Amount += item.Amount
                      Else
                        addedJi.Amount += itemRemainAmount
                      End If
                      lciToolNoAcctMatched = True
                    End If
                  End If
              End Select
            End If
          Next
          If Not item.ItemType Is Nothing Then
            Select Case item.ItemType.Value
              Case 0, 88, 89 'Blank  
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If Not blankMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.4"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.Account = realAccount
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If Not blankNoAcctMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.4"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                End If
              Case 28 'Asset
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If Not assetMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.3"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.Account = realAccount
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If Not assetNoacctMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.3"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                End If
              Case 42 'LCI
                Dim realAccount As Account
                Dim entityAcct As Account
                Dim lci As LCIItem = CType(item.Entity, LCIItem)
                If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                  entityAcct = lci.Account
                End If
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                ElseIf Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
                  'ใช้ acct ของ lci
                  realAccount = entityAcct
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If Not lciToolMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.1"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.Account = realAccount
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If Not lciToolNoAcctMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.1"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                End If

              Case 19 'Tool
                Dim realAccount As Account
                If Not item.Account Is Nothing AndAlso item.Account.Originated Then
                  'ใช้ acct ในรายการ
                  realAccount = item.Account
                End If
                If Not realAccount Is Nothing AndAlso realAccount.Originated Then
                  If Not lciToolMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.2"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.Account = realAccount
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                ElseIf realAccount Is Nothing OrElse Not realAccount.Originated Then
                  If Not lciToolNoAcctMatched Then
                    ji = New JournalEntryItem
                    ji.Mapping = "B5.2"
                    If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                      ji.Amount += item.Amount
                    Else
                      ji.Amount += itemRemainAmount
                    End If
                    ji.CostCenter = doc.ToCostCenter
                    jiColl.Add(ji)
                  End If
                End If
            End Select
          End If
        Next
      Next
      Return jiColl
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.journalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "IVatable"
    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      'Todo: ต้อง refresh หรือเปล่า?
      Return Me.TaxBase
    End Function
    Public Property Person() As IBillablePerson Implements IVatable.Person
      Get
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        Me.Supplier = CType(Value, Supplier)
      End Set
    End Property
    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
      Return Me.AfterTax
    End Function
    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
      Return Me.BeforeTax
    End Function
    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return False
      End Get
    End Property
#End Region

#Region "IBillAcceptable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      Return Me.AfterTax
    End Function
    Public Property DueDate() As Date Implements IPayable.DueDate
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
    End Property
    Public Property Payment() As Payment Implements IPayable.Payment
      Get
        Return m_payment
      End Get
      Set(ByVal Value As Payment)
        m_payment = Value
      End Set
    End Property
    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      'Undone
      Return AmountToPay()
    End Function
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Me.Supplier
      End Get
    End Property
    Public Function GetRemainingAmountWithBillAcceptance(ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountWithBillAcceptance
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@billai_billa", billa_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer, ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                , New SqlParameter("@billai_billa", billa_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\DO.dfm"
    End Function

    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function

    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      'Dim dpi As DocPrintingItem
      'Me.RefreshTaxBase()
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

      'If Not Me.Supplier Is Nothing AndAlso Me.Supplier.Originated Then
      '    'Supplier
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Supplier"
      '    dpi.Value = Me.Supplier.Code & ":" & Me.Supplier.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    'SupplierAddress
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "SupplierAddress"
      '    dpi.Value = Me.Supplier.BillingAddress
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)

      '    'SupplierCurrentAddress
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "SupplierCurrentAddress"
      '    dpi.Value = Me.Supplier.Address
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

      ''Note
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Note"
      'dpi.Value = Me.Note
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      '''CreditPeriod
      ''dpi = New DocPrintingItem
      ''dpi.Mapping = "CreditPeriod"
      ''dpi.Value = Me.CreditPeriod
      ''dpi.DataType = "System.Int32"
      ''dpiColl.Add(dpi)

      ''Gross
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Gross"
      'dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpiColl.Add(dpi)

      ''DiscountRate
      'dpi = New DocPrintingItem
      'dpi.Mapping = "DiscountRate"
      'dpi.Value = Me.Discount.Rate
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''BeforeTax
      'dpi = New DocPrintingItem
      'dpi.Mapping = "BeforeTax"
      'dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpiColl.Add(dpi)

      ''DiscountAmount
      'dpi = New DocPrintingItem
      'dpi.Mapping = "DiscountAmount"
      'dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpiColl.Add(dpi)

      ''TaxAmount
      'dpi = New DocPrintingItem
      'dpi.Mapping = "TaxAmount"
      'dpi.Value = Configuration.FormatToString(Me.TaxAmount, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpiColl.Add(dpi)

      ''AfterTax
      'dpi = New DocPrintingItem
      'dpi.Mapping = "AfterTax"
      'dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpiColl.Add(dpi)

      'Dim n As Integer = 0
      'For i As Integer = 0 To Me.MaxRowIndex
      '    Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
      '    If ValidateRow(itemRow) And itemRow.Level <> 0 Then
      '        Dim item As New PurchaseDNItem
      '        item.CopyFromDataRow(itemRow)
      '        'Item.LineNumber
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.LineNumber"
      '        dpi.Value = n + 1
      '        dpi.DataType = "System.Int32"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Code
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Code"
      '        dpi.Value = item.Entity.Code
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Name
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Name"
      '        dpi.Value = item.Entity.Name
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Unit
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Unit"
      '        dpi.Value = item.Unit.Name
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Qty
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Qty"
      '        dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.UnitPrice
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.UnitPrice"
      '        If item.UnitPrice = 0 Then
      '            dpi.Value = ""
      '        Else
      '            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
      '        End If
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.DiscountRate
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.DiscountRate"
      '        dpi.Value = item.Discount.Rate
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.DiscountAmount
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.DiscountAmount"
      '        If item.Discount.Amount = 0 Then
      '            dpi.Value = ""
      '        Else
      '            dpi.Value = Configuration.FormatToString(item.Discount.Amount, DigitConfig.Price)
      '        End If
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Amount
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Amount"
      '        If item.Amount = 0 Then
      '            dpi.Value = ""
      '        Else
      '            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
      '        End If
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.ZeroVat
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.ZeroVat"
      '        dpi.Value = item.UnVatable
      '        dpi.DataType = "System.Boolean"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        'Item.Note
      '        dpi = New DocPrintingItem
      '        dpi.Mapping = "Item.Note"
      '        dpi.Value = item.Note
      '        dpi.DataType = "System.String"
      '        dpi.Row = n + 1
      '        dpi.Table = "Item"
      '        dpiColl.Add(dpi)

      '        n += 1
      '    End If
      'Next
      Return dpiColl
    End Function
#End Region

#Region " IApprovAble "
    Public Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
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
          SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Approve" & Me.ClassName, sqlparams)
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

      End Get
    End Property
    Public ReadOnly Property AmountToApprove() As Decimal Implements IApprovAble.AmountToApprove
      Get

      End Get
    End Property
    Public ReadOnly Property ApproveIcon() As String Implements IApprovAble.ApproveIcon
      Get

      End Get
    End Property

    Public ReadOnly Property ShowUnApproveButton() As Boolean Implements IApprovAble.ShowUnApproveButton
      Get

      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get

      End Get
    End Property
#End Region

#Region "IHasIBillablePerson"
    Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
      Get
        Return Me.Supplier
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Supplier Then
          Me.Supplier = CType(Value, Supplier)
        End If
      End Set
    End Property
#End Region


  End Class

  Public Class PurchaseDNItem

#Region "Members"
    Private m_purchaseDN As PurchaseDN
    Private m_lineNumber As Integer

    Private m_goodsReceiptLine As Integer
    Private m_goodsReceiptId As Integer
    Private m_goodsReceiptCode As String

    Private m_itemType As ItemType
    Private m_entity As IHasName
    Private m_entityName As String
    Private m_unit As Unit
    Private m_qty As Decimal
    Private m_unitPrice As Decimal
    Private m_note As String
    Private m_stockQty As Decimal
    Private m_unvatable As Boolean = False
    Private m_discount As New Discount("")
    Private m_account As Account
    Private m_conversion As Decimal = 1

    Private m_sequence As Integer

    Private m_wbsdColl As WBSDistributeCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.m_itemType = New ItemType(-1)
      m_wbsdColl = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      m_wbsdColl = New WBSDistributeCollection
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      m_wbsdColl = New WBSDistributeCollection
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refdoc") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refdoc") Then
          .m_goodsReceiptId = CInt(dr(aliasPrefix & "stocki_refdoc"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_refdocLineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_refdocLineNumber") Then
          .m_goodsReceiptLine = CInt(dr(aliasPrefix & "stocki_refdocLineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entityType") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entityType") Then
          .m_itemType = New ItemType(CInt(dr(aliasPrefix & "stocki_entityType")))
        End If
        Dim itemId As Integer
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_entity") AndAlso Not dr.IsNull(aliasPrefix & "stocki_entity") Then
          itemId = CInt(dr(aliasPrefix & "stocki_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_itemName") AndAlso Not dr.IsNull(aliasPrefix & "stocki_itemName") Then
          .m_entityName = CStr(dr(aliasPrefix & "stocki_itemName"))
        Else
          .m_entityName = ""
        End If
        Select Case .m_itemType.Value
          Case 0, 28, 88, 89
            .m_entity = New BlankItem(.m_entityName)
          Case 42
            If dr.Table.Columns.Contains("lci_id") AndAlso Not dr.IsNull("lci_id") Then
              If Not dr.IsNull("lci_id") Then
                .m_entity = New LCIItem(dr, "")
              End If
            Else
              .m_entity = New LCIItem(itemId)
            End If
          Case 19
            If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
              If Not dr.IsNull("tool_id") Then
                .m_entity = New LCIItem(dr, "")
              End If
            Else
              .m_entity = New Tool(itemId)
            End If
          Case Else
        End Select

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "stocki_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "stocki_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_qty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_qty") Then
          .m_qty = CDec(dr(aliasPrefix & "stocki_qty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unitprice") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unitprice") Then
          .m_unitPrice = CDec(dr(aliasPrefix & "stocki_unitprice"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_stockqty") AndAlso Not dr.IsNull(aliasPrefix & "stocki_stockqty") Then
          .m_stockQty = CDec(dr(aliasPrefix & "stocki_stockqty"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "stocki_note") AndAlso Not dr.IsNull(aliasPrefix & "stocki_note") Then
          .m_note = CStr(dr(aliasPrefix & "stocki_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "unit_id") AndAlso Not dr.IsNull(aliasPrefix & "unit_id") Then
          If Not dr.IsNull("unit_id") Then
            .m_unit = New Unit(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_unit") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unit") Then
            .m_unit = New Unit(CInt(dr(aliasPrefix & "stocki_unit")))
          End If
        End If

        If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
          If TypeOf Me.Entity Is LCIItem Then
            Dim lci As LCIItem = CType(Me.Entity, LCIItem)
            Me.Conversion = lci.GetConversion(Me.Unit)
          Else
            Me.Conversion = 1
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_discrate") AndAlso Not dr.IsNull(aliasPrefix & "stocki_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "stocki_discrate")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
          If Not dr.IsNull("acct_id") Then
            .m_account = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "stocki_acct") AndAlso Not dr.IsNull(aliasPrefix & "stocki_acct") Then
            .m_account = New Account(CInt(dr(aliasPrefix & "stocki_acct")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_unvatable") AndAlso Not dr.IsNull(aliasPrefix & "stocki_unvatable") Then
          .m_unvatable = CBool(dr(aliasPrefix & "stocki_unvatable"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "stocki_sequence") AndAlso Not dr.IsNull(aliasPrefix & "stocki_sequence") Then
          m_sequence = CInt(dr(aliasPrefix & "stocki_sequence"))
        End If

      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property WbsdColl() As WBSDistributeCollection      Get        Return m_wbsdColl      End Get      Set(ByVal Value As WBSDistributeCollection)        m_wbsdColl = Value      End Set    End Property
    Public Property Sequence() As Integer      Get        Return m_sequence      End Get      Set(ByVal Value As Integer)        m_sequence = Value      End Set    End Property
    Public Property PurchaseDN() As PurchaseDN      Get        Return m_purchaseDN      End Get      Set(ByVal Value As PurchaseDN)        m_purchaseDN = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property GoodsReceiptLine() As Integer      Get        Return m_goodsReceiptLine      End Get      Set(ByVal Value As Integer)        m_goodsReceiptLine = Value      End Set    End Property    Public Property GoodsReceiptId() As Integer      Get        Return m_goodsReceiptId      End Get      Set(ByVal Value As Integer)        m_goodsReceiptId = Value      End Set    End Property    Public Property GoodsReceiptCode() As String      Get        Return m_goodsReceiptCode      End Get      Set(ByVal Value As String)        m_goodsReceiptCode = Value      End Set    End Property    Public Property ItemType() As ItemType      Get        Return m_itemType      End Get      Set(ByVal Value As ItemType)        m_itemType = Value      End Set    End Property    Public Property Entity() As IHasName      Get        Return m_entity      End Get      Set(ByVal Value As IHasName)        m_entity = Value      End Set    End Property    Public Property EntityName() As String      Get        Return m_entityName      End Get      Set(ByVal Value As String)        m_entityName = Value      End Set    End Property    Public Property Unit() As Unit      Get        Return m_unit      End Get      Set(ByVal Value As Unit)        m_unit = Value      End Set    End Property    Public Property Qty() As Decimal      Get        Return m_qty      End Get      Set(ByVal Value As Decimal)        m_qty = Value      End Set    End Property    Public Property UnitPrice() As Decimal      Get        Return m_unitPrice      End Get      Set(ByVal Value As Decimal)        m_unitPrice = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Account() As Account      Get
        Return Me.m_account
      End Get
      Set(ByVal Value As Account)
        m_account = Value
      End Set
    End Property    Public ReadOnly Property StockQty() As Decimal      Get        Return Me.Conversion * Me.Qty      End Get    End Property    Public Property Discount() As Discount      Get        Return m_discount      End Get      Set(ByVal Value As Discount)        m_discount = Value      End Set    End Property
    Public ReadOnly Property Amount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = (Me.UnitPrice * Me.Qty)
        Return (Me.UnitPrice * Me.Qty) - Me.Discount.Amount
      End Get
    End Property
    Public Property UnVatable() As Boolean      Get        Return m_unvatable      End Get      Set(ByVal Value As Boolean)        m_unvatable = Value      End Set    End Property
    Public ReadOnly Property UnitCost() As Decimal
      Get
        If Me.StockQty <> 0 Then
          Return Me.Amount / Me.StockQty
        End If
        Return 0
      End Get
    End Property
    Public Property Conversion() As Decimal      Get        Return m_conversion      End Get      Set(ByVal Value As Decimal)        m_conversion = Value      End Set    End Property
#End Region

#Region "Methods"
    Public Sub CopyFromEntity(ByVal entity As ISimpleEntity)
      Me.GoodsReceiptLine = 0
      Me.ItemType = New ItemType(entity.EntityId)
      Me.Entity = CType(entity, IHasName)
      If TypeOf entity Is IHasUnit Then
        Me.Unit = CType(entity, IHasUnit).DefaultUnit
      End If
      If TypeOf entity Is IHasPrice Then
        Me.UnitPrice = CType(entity, IHasPrice).Price
      End If
      If TypeOf entity Is LCIItem Then
        Me.UnVatable = CType(entity, LCIItem).Unvatable
      End If
      If TypeOf entity Is IHasAccount Then
        Me.Account = CType(entity, IHasAccount).Account
      End If
      Me.Qty = 1
    End Sub
    Public Sub CopyFromGRItem(ByVal grItem As GoodsReceiptItem)
      Me.GoodsReceiptLine = grItem.LineNumber
      Me.ItemType = grItem.ItemType
      Me.Entity = grItem.Entity
      Me.EntityName = grItem.EntityName
      Me.Unit = grItem.Unit
      Me.UnitPrice = grItem.UnitPrice
      Me.UnVatable = grItem.UnVatable
      Me.Account = grItem.Account
      Me.Qty = grItem.Qty
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)

      If row Is Nothing Then
        Return
      End If
      Me.PurchaseDN.IsInitialized = False

      row("GoodsReceipt_id") = Me.GoodsReceiptId
      row("GoodsReceipt_Code") = Me.GoodsReceiptCode
      row("GoodsReceiptItem_linenumber") = Me.GoodsReceiptLine

      row("stocki_linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing Then
        row("stocki_entity") = Me.Entity.Id
        If Not Me.ItemType Is Nothing Then
          row("stocki_entityType") = Me.ItemType.Value
          If Not Me.ItemType.Value = 0 Then
            If Not Me.EntityName Is Nothing AndAlso Me.EntityName.Length > 0 Then
              row("stocki_itemName") = Me.EntityName & "<" & Me.Entity.Name & ">"
            End If
          End If
        End If
        row("Code") = Me.Entity.Code
        row("stocki_itemName") = Me.Entity.Name
      End If

      If Not Me.Unit Is Nothing Then
        row("stocki_unit") = Me.Unit.Id
        row("Unit") = Me.Unit.Name
      End If

      Me.Conversion = 1
      If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
        If TypeOf Me.Entity Is LCIItem Then
          Dim lci As LCIItem = CType(Me.Entity, LCIItem)
          Me.Conversion = lci.GetConversion(Me.Unit)
        Else
          Me.Conversion = 1
        End If
      End If

      If Not Me.Account Is Nothing Then
        row("stocki_acct") = Me.Account.Id
        row("AccountCode") = Me.Account.Code
        row("Account") = Me.Account.Name
      End If

      If Me.Qty <> 0 Then
        row("stocki_qty") = Configuration.FormatToString(Me.Qty, DigitConfig.Qty)
      Else
        row("stocki_qty") = ""
      End If

      row("stocki_discrate") = Me.Discount.Rate
      If Me.Amount <> 0 Then
        row("Amount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      Else
        row("Amount") = ""
      End If

      row("stocki_note") = Me.Note
      If Me.UnitPrice <> 0 Then
        row("stocki_unitprice") = Configuration.FormatToString(Me.UnitPrice, DigitConfig.UnitPrice)
      Else
        row("stocki_unitprice") = ""
      End If
      If Me.StockQty <> 0 Then
        row("StockQty") = Configuration.FormatToString(Me.StockQty, DigitConfig.Qty)
      Else
        row("StockQty") = ""
      End If
      row("stocki_unvatable") = Me.UnVatable
      row("Ref") = Me.GoodsReceiptLine <> 0
      Me.PurchaseDN.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("stocki_linenumber")) Then
          Me.LineNumber = CInt(row("stocki_linenumber"))
        End If

        If Not row.IsNull(("stocki_unit")) Then
          Me.Unit = New Unit(CInt(row("stocki_unit")))
        Else
          Me.Unit = New Unit
        End If

        If Not row.IsNull(("stocki_acct")) Then
          Me.Account = New Account(CInt(row("stocki_acct")))
        Else
          Me.Account = New Account
        End If

        If Not row.IsNull(("stocki_entityType")) Then
          Me.ItemType = New ItemType(CInt(row("stocki_entityType")))
          Select Case CInt(row("stocki_entityType"))
            Case 0, 28, 88, 89 'Blank/Asset
              If Not row.IsNull(("stocki_itemName")) Then
                Me.Entity = New BlankItem(row("stocki_itemName").ToString)
                Me.EntityName = row("stocki_itemName").ToString
              Else
                Me.Entity = New BlankItem("")
                Me.EntityName = ""
              End If
            Case Else
              If Not row.IsNull(("stocki_entity")) Then
                Me.Entity = CType(SimpleBusinessEntityBase.GetEntity(BusinessLogic.Entity.GetFullClassName(CInt(row("stocki_entityType"))), CInt(row("stocki_entity"))), IHasName)
              End If
              If Not row.IsNull(("stocki_itemName")) Then
                Dim suffix As String = "<" & Me.Entity.Name & ">"
                Dim s As String = row("stocki_itemName").ToString
                If s.EndsWith(suffix) Then
                  Me.EntityName = s.Remove(s.Length - suffix.Length, suffix.Length)
                End If
              Else
                Me.EntityName = ""
              End If
              Me.Conversion = 1
              If Not Me.Unit Is Nothing AndAlso Me.Unit.Originated Then
                If TypeOf Me.Entity Is LCIItem Then
                  Dim lci As LCIItem = CType(Me.Entity, LCIItem)
                  Me.Conversion = lci.GetConversion(Me.Unit)
                Else
                  Me.Conversion = 1
                End If
              End If
          End Select
        End If

        If Not row.IsNull(("stocki_note")) Then
          Me.Note = CStr(row("stocki_note"))
        End If

        GetAmountFromRow(row)

        If Not row.IsNull(("GoodsReceiptItem_linenumber")) Then
          Me.GoodsReceiptLine = CInt(row("GoodsReceiptItem_linenumber"))
          If Not row.IsNull("GoodsReceipt_id") Then
            Me.GoodsReceiptId = CInt(row("GoodsReceipt_id"))
          End If
          If Not row.IsNull("GoodsReceipt_Code") Then
            Me.GoodsReceiptCode = CStr(row("GoodsReceipt_Code"))
          End If
        End If

      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
    Public Sub GetAmountFromRow(ByVal row As TreeRow)
      'เพื่อประหยัด ไม่ต้องสร้าง Entity
      If Not row.IsNull(("stocki_qty")) Then
        If CStr(row("stocki_qty")).Length = 0 Then
          Me.Qty = 0
        Else
          Me.Qty = CDec(row("stocki_qty"))
        End If
      End If
      If Not row.IsNull(("stocki_discrate")) Then
        Me.Discount.Rate = CStr(row("stocki_discrate"))
      End If
      If Not row.IsNull(("stocki_unitprice")) Then
        If CStr(row("stocki_unitprice")).Length = 0 Then
          Me.UnitPrice = 0
        Else
          Me.UnitPrice = CDec(row("stocki_unitprice"))
        End If
      End If
      If Not row.IsNull("stocki_unvatable") Then
        Me.UnVatable = CBool(row("stocki_unvatable"))
      End If
    End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class PurchaseDNItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_refdoc As DNRefDoc
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal refdoc As DNRefDoc)
      m_refdoc = refdoc
      If Not refdoc.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetItemsForRefDoc" _
      , New SqlParameter("@refstock_id", refdoc.Id) _
      , New SqlParameter("@stock_id", refdoc.DN.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New PurchaseDNItem(row, "")
        Me.Add(item)
        Dim wbsdColl As WBSDistributeCollection = item.WbsdColl
        For Each wbsRow As DataRow In ds.Tables(1).Select("stockiw_sequence=" & item.Sequence)
          Dim wbsd As New WBSDistribute(wbsRow, "")
          wbsdColl.Add(wbsd)
        Next
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As PurchaseDNItem
      Get
        Return CType(MyBase.List.Item(index), PurchaseDNItem)
      End Get
      Set(ByVal value As PurchaseDNItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public ReadOnly Property Amount() As Decimal
      Get
        Dim ret As Decimal = 0
        For Each myItem As PurchaseDNItem In Me
          ret += myItem.Amount
        Next
        Return ret
      End Get
    End Property
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As PurchaseDNItem) As Integer
      If Not m_refdoc Is Nothing Then
        value.PurchaseDN = m_refdoc.DN
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As PurchaseDNItemCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).PurchaseDN = m_refdoc.DN
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As PurchaseDNItem())
      For i As Integer = 0 To value.Length - 1
        value(i).PurchaseDN = m_refdoc.DN
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As PurchaseDNItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As PurchaseDNItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As PurchaseDNItemEnumerator
      Return New PurchaseDNItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As PurchaseDNItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As PurchaseDNItem)
      value.PurchaseDN = m_refdoc.DN
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As PurchaseDNItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As PurchaseDNItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class PurchaseDNItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As PurchaseDNItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, PurchaseDNItem)
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

  Public Class DNRefDoc
    Inherits SimpleBusinessEntityBase

#Region "Members"
    Private m_realAmount As Decimal
    Private m_beforeTax As Decimal
    Private m_afterTax As Decimal
    Private m_taxBase As Decimal
    Private m_amount As Decimal
    Private m_note As String
    Private m_DN As PurchaseDN
    Private m_tocc As CostCenter
    Private m_itemCollection As PurchaseDNItemCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_tocc = New CostCenter
      m_itemCollection = New PurchaseDNItemCollection
    End Sub
    Public Sub New(ByVal gr As GoodsReceipt, ByVal dn As PurchaseDN)
      MyBase.New()
      Construct(gr)
      m_DN = dn
      m_itemCollection = New PurchaseDNItemCollection(Me)
    End Sub
    Public Overloads Sub Construct(ByVal gr As GoodsReceipt)
      Me.Id = gr.Id
      Me.Code = gr.Code
      gr.RefreshTaxBase()
      Me.RealAmount = gr.AfterTax
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal dn As PurchaseDN)
      m_DN = dn
      Construct(dr, aliasPrefix)
      m_itemCollection = New PurchaseDNItemCollection(Me)
    End Sub
    Protected Overloads Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      If dr.Table.Columns.Contains(aliasPrefix & "stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
        Me.m_tocc = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_aftertax") AndAlso Not dr.IsNull(aliasPrefix & "stock_aftertax") Then
        Me.m_afterTax = CDec(dr(aliasPrefix & "stock_aftertax"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_beforeTax") AndAlso Not dr.IsNull(aliasPrefix & "stock_beforeTax") Then
        Me.m_beforeTax = CDec(dr(aliasPrefix & "stock_beforeTax"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_taxBase") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxBase") Then
        Me.m_taxBase = CDec(dr(aliasPrefix & "stock_taxBase"))
      End If
      Select Case Me.m_DN.TaxType.Value
        Case 0 'ไม่มี
          Me.m_realAmount = Me.m_beforeTax
        Case 1 'แยก
          Me.m_realAmount = Me.m_taxBase
        Case 2 'รวม
          Me.m_realAmount = Me.m_afterTax
      End Select
      If dr.Table.Columns.Contains(aliasPrefix & "stockstock_amt") AndAlso Not dr.IsNull(aliasPrefix & "stockstock_amt") Then
        Me.m_amount = CDec(dr(aliasPrefix & "stockstock_amt"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stockstock_note") AndAlso Not dr.IsNull(aliasPrefix & "stockstock_note") Then
        Me.m_note = CStr(dr(aliasPrefix & "stockstock_note"))
      End If
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollection() As PurchaseDNItemCollection      Get        Return m_itemCollection      End Get      Set(ByVal Value As PurchaseDNItemCollection)        m_itemCollection = Value      End Set    End Property
    Public Property DN() As PurchaseDN      Get        Return m_DN      End Get      Set(ByVal Value As PurchaseDN)        m_DN = Value      End Set    End Property
    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property
    Public Property ToCostCenter() As CostCenter      Get        Return m_tocc      End Get      Set(ByVal Value As CostCenter)        m_tocc = Value      End Set    End Property    Public ReadOnly Property ToAccount() As Account      Get        If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then          Return Me.ToCostCenter.StoreAccount
        End If      End Get    End Property    Public Property BeforeTax() As Decimal      Get        Return m_beforeTax      End Get      Set(ByVal Value As Decimal)        m_beforeTax = Value      End Set    End Property    Public Property AfterTax() As Decimal      Get        Return m_afterTax      End Get      Set(ByVal Value As Decimal)        m_afterTax = Value      End Set    End Property    Public Property TaxBase() As Decimal      Get        Return m_taxBase      End Get      Set(ByVal Value As Decimal)        m_taxBase = Value      End Set    End Property
    Public Property RealAmount() As Decimal      Get        Return m_realAmount      End Get      Set(ByVal Value As Decimal)        m_realAmount = Value      End Set    End Property    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property
    Public ReadOnly Property ItemAmount() As Decimal
      Get
        Return Me.ItemCollection.Count
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "GoodsReceipt"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "stock"
      End Get
    End Property
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class DNRefDocCollection
    Inherits CollectionBase

#Region "Members"
    Private m_DN As PurchaseDN
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal dn As PurchaseDN)
      m_DN = dn
      If Not dn.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetRefStock" _
      , New SqlParameter("@stock_id", dn.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New DNRefDoc(row, "", dn)
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property DN() As PurchaseDN      Get        Return m_DN      End Get      Set(ByVal Value As PurchaseDN)        m_DN = Value      End Set    End Property
    Default Public Property Item(ByVal index As Integer) As DNRefDoc
      Get
        Return CType(MyBase.List.Item(index), DNRefDoc)
      End Get
      Set(ByVal value As DNRefDoc)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Function RealAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As DNRefDoc In Me
        ret += doc.RealAmount
      Next
      Return ret
    End Function
    Public Function Amount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As DNRefDoc In Me
        ret += doc.Amount
      Next
      Return ret
    End Function
    Public ReadOnly Property ItemAmount() As Decimal
      Get
        Dim ret As Decimal = 0
        For Each doc As DNRefDoc In Me
          ret += doc.ItemCollection.Amount
        Next
        Return ret
      End Get
    End Property

    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each cndnref As DNRefDoc In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("Linenumber") = i
        newRow("Code") = cndnref.Code
        newRow("RealAmount") = Configuration.FormatToString(cndnref.RealAmount, DigitConfig.Price)
        newRow("stockstock_amt") = Configuration.FormatToString(cndnref.Amount, DigitConfig.Price)
        newRow("stockstock_note") = cndnref.Note
        newRow("Code") = cndnref.Code
        newRow.Tag = cndnref
      Next
    End Sub
    Public Sub PopulateItem(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each dnref As DNRefDoc In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow("stocki_linenumber") = i
        newRow("Code") = dnref.Code
        newRow("Button") = "invisible"
        newRow("UnitButton") = "invisible"
        newRow("AccountButton") = "invisible"
        newRow.Tag = dnref
        newRow.State = RowExpandState.Expanded
        For Each item As PurchaseDNItem In dnref.ItemCollection
          Dim newChildRow As TreeRow = newRow.Childs.Add
          item.CopyToDataRow(newChildRow)
          newChildRow.Tag = item
        Next
      Next
    End Sub
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As DNRefDoc) As Integer
      value.DN = Me.DN
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As DNRefDocCollection)
      For i As Integer = 0 To value.Count - 1
        value(i).DN = Me.DN
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As DNRefDoc())
      For i As Integer = 0 To value.Length - 1
        value(i).DN = Me.DN
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As DNRefDoc) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As DNRefDoc(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As DNRefDocEnumerator
      Return New DNRefDocEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As DNRefDoc) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As DNRefDoc)
      value.DN = Me.DN
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As DNRefDoc)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As DNRefDocCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class DNRefDocEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As DNRefDocCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, DNRefDoc)
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
