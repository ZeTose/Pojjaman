Imports System.Linq
Imports System.Globalization
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic
Imports Longkong.Core.AddIns
Imports System.Runtime.CompilerServices

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class OutgoingCheck
    Inherits SimpleBusinessEntityBase
    Implements IPaymentItem, IPrintableEntity, IHasBankAccount, IHasIBillablePerson, ICheckPeriod, IExportable


#Region "Members"
    Private m_cqcode As String
    Private m_issueDate As Date
    Private m_oldissueDate As Date
    Private m_dueDate As Date
    Private m_supplier As Supplier
    Private m_recipient As String
    Private m_bankacct As BankAccount

    Private m_amount As Decimal
    Private m_bankcharge As Decimal
    Private m_wht As Decimal

    Private m_note As String
    Private m_receivingEntity As SimpleBusinessEntityBase

    Private m_docStatus As OutgoingCheckDocStatus 'สถานะเช็คจ่าย
    Private m_itemTable As TreeTable

    Private m_ACPayeeOnly As Boolean
    Private m_unbearer As Boolean
    Private m_receiptAtBank As Boolean

    Private m_oldcqcode As String
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      MyBase.New(dr, aliasPrefix)
    End Sub

    Public Property ExportType As String = "mcl" Implements IExportable.ExportType

    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()

      Me.m_bankacct = New BankAccount
      Me.m_supplier = New Supplier
      Me.m_issueDate = Now.Date
      Me.m_oldissueDate = Now.Date
      If Not CBool(Configuration.GetConfig("AllowNoCqCodeDate")) Then
        Me.m_dueDate = Now.Date
      End If

      Me.m_docStatus = New OutgoingCheckDocStatus(-1)
      Me.Status = New CheckStatus(-1)

      '==Checking for addin วิศวพัฒน์
      Dim hasExport As Boolean = False
      For Each a As AddIn In AddInTreeSingleton.AddInTree.AddIns
        If a.FileName.ToLower.Contains("textexport") Then
          hasExport = True
        End If
      Next
      If hasExport Then
        Me.m_receiptAtBank = True
      End If

    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      MyBase.Construct(ds, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        .m_cqcode = ""
        .m_note = ""

        If dr.Table.Columns.Contains(aliasPrefix & "check_cqcode") AndAlso Not dr.IsNull(aliasPrefix & "check_cqcode") Then
          .m_cqcode = CStr(dr(aliasPrefix & "check_cqcode"))
          .m_oldcqcode = CStr(dr(aliasPrefix & "check_cqcode"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_issueDate") AndAlso Not dr.IsNull(aliasPrefix & "check_issueDate") Then
          .m_issueDate = CDate(dr(aliasPrefix & "check_issueDate"))
          .m_oldissueDate = CDate(dr(aliasPrefix & "check_issueDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_dueDate") AndAlso Not dr.IsNull(aliasPrefix & "check_dueDate") Then
          .m_dueDate = CDate(dr(aliasPrefix & "check_dueDate"))
        End If

        If dr.Table.Columns.Contains("eocheck_supplier") Then '--เพื่อความเร็ว:pui--
          If Not dr.IsNull("eocheck_supplier") Then
            .m_supplier = New Supplier(dr, "") ' Supplier.GetSupplierbyDataRow(dr)
          End If
        ElseIf dr.Table.Columns.Contains(aliasPrefix & "supplier_id") Then
          If Not dr.IsNull(aliasPrefix & "supplier_id") Then
            .m_supplier = New Supplier(CInt(dr("supplier_id")), True) ' Supplier.GetSupplierbyDataRow(dr)
            '.m_supplier = New Supplier(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "check_supplier") AndAlso Not dr.IsNull(aliasPrefix & "check_supplier") Then
            Dim filters(0) As Filter
            filters(0) = New Filter("includeInvisible", True) 'เพื่อให้มองเห็น supplier ที่ซ่อนอยู่เช่น เงินสดย่อย ได้
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & "check_supplier")), filters)
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_recipient") AndAlso Not dr.IsNull(aliasPrefix & "check_recipient") Then
          .m_recipient = CStr(dr(aliasPrefix & "check_recipient"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "bankacct_id") Then
          If Not dr.IsNull(aliasPrefix & "bankacct_id") Then
            .m_bankacct = New BankAccount(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "check_bankacct") AndAlso Not dr.IsNull(aliasPrefix & "check_bankacct") Then
            .m_bankacct = New BankAccount(CInt(dr(aliasPrefix & "check_bankacct")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_amt") AndAlso Not dr.IsNull(aliasPrefix & "check_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "check_amt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_bankcharge") AndAlso Not dr.IsNull(aliasPrefix & "check_bankcharge") Then
          .m_bankcharge = CDec(dr(aliasPrefix & "check_bankcharge"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_wht") AndAlso Not dr.IsNull(aliasPrefix & "check_wht") Then
          .m_wht = CDec(dr(aliasPrefix & "check_wht"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_note") AndAlso Not dr.IsNull(aliasPrefix & "check_note") Then
          .m_note = CStr(dr(aliasPrefix & "check_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_docstatus") AndAlso Not dr.IsNull(aliasPrefix & "check_docstatus") Then
          .m_docStatus.Value = CInt(dr(aliasPrefix & "check_docstatus"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .Status.Value = CInt(dr(aliasPrefix & Me.Prefix & "_status"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_ACPayeeOnly") AndAlso Not dr.IsNull(aliasPrefix & "check_ACPayeeOnly") Then
          .m_ACPayeeOnly = CBool(dr(aliasPrefix & "check_ACPayeeOnly"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_unbearer") AndAlso Not dr.IsNull(aliasPrefix & "check_unbearer") Then
          .m_unbearer = CBool(dr(aliasPrefix & "check_unbearer"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_ExportType") AndAlso Not dr.IsNull(aliasPrefix & "check_ExportType") Then
          .ExportType = CStr(dr(aliasPrefix & "check_ExportType"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_receiptAtBank") AndAlso Not dr.IsNull(aliasPrefix & "check_receiptAtBank") Then
          .m_receiptAtBank = CBool(dr(aliasPrefix & "check_receiptAtBank"))
        End If
      End With
      RefreshPVList()
    End Sub
#End Region

#Region "Properties"
    Public Property ReceiptAtBank As Boolean
      Get
        Return m_receiptAtBank
      End Get
      Set(ByVal value As Boolean)
        m_receiptAtBank = value
        If m_receiptAtBank Then
          m_cqcode = ""
        Else
          m_cqcode = m_oldcqcode
        End If
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
    Public Property CqCode() As String Implements IPaymentItem.Code
      Get
        Return m_cqcode
      End Get
      Set(ByVal Value As String)
        m_cqcode = Value
      End Set
    End Property
    Public ReadOnly Property DocDate As Date
      Get
        Return Me.IssueDate
      End Get
    End Property
    Public Property IssueDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_issueDate      End Get      Set(ByVal Value As Date)        m_issueDate = Value      End Set    End Property    Public ReadOnly Property OldIssueDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return m_oldissueDate
      End Get
    End Property    Public Property DueDate() As Date Implements IPaymentItem.DueDate      Get        Return m_dueDate      End Get      Set(ByVal Value As Date)        m_dueDate = Value      End Set    End Property    Public ReadOnly Property CreateDate As Nullable(Of Date) Implements IPaymentItem.CreateDate
      Get
        Return DocDate
      End Get
    End Property    Public Property Supplier() As Supplier      Get        Return m_supplier      End Get      Set(ByVal Value As Supplier)        m_supplier = Value        If Me.Recipient Is Nothing OrElse Me.Recipient.Length = 0 Then          Me.Recipient = m_supplier.Name
        End If
      End Set    End Property    Public Property Recipient() As String      Get        Return m_recipient      End Get      Set(ByVal Value As String)        m_recipient = Value      End Set    End Property    Public Property Bankacct() As BankAccount Implements IHasBankAccount.BankAccount      Get        If m_bankacct Is Nothing Then
          m_bankacct = New BankAccount
        End If        Return m_bankacct      End Get      Set(ByVal Value As BankAccount)        m_bankacct = Value      End Set    End Property    Public Property ACPayeeOnly() As Boolean      Get        Return m_ACPayeeOnly      End Get      Set(ByVal Value As Boolean)        m_ACPayeeOnly = Value      End Set    End Property    Public Property Unbearer() As Boolean      Get        Return m_unbearer      End Get      Set(ByVal Value As Boolean)        m_unbearer = Value      End Set    End Property    Public Property BankCharge() As Decimal      Get
        Return m_bankcharge
      End Get
      Set(ByVal Value As Decimal)
        m_bankcharge = Value
      End Set
    End Property    Public Property WHT() As Decimal      Get
        Return m_wht
      End Get
      Set(ByVal Value As Decimal)
        m_wht = Value
      End Set
    End Property    Public Property Amount() As Decimal Implements IHasAmount.Amount      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property DocStatus() As OutgoingCheckDocStatus      Get        Return m_docStatus      End Get      Set(ByVal Value As OutgoingCheckDocStatus)        m_docStatus = Value      End Set    End Property
#End Region

#Region "Shared"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "OutGoingCheck"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      ' Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "check_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "check_linenumber"

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.DateHeaderText}")
      csDate.NullText = ""
      'csCode.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True

      Dim csPVCode As New TreeTextColumn
      csPVCode.MappingName = "PVCode"
      csPVCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.PVCodeHeaderText}")
      csPVCode.NullText = ""
      'csCode.ReadOnly = True

      Dim csPVRemain As New TreeTextColumn
      csPVRemain.MappingName = "PVRemain"
      csPVRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.PVRemainHeaderText}")
      csPVRemain.NullText = ""
      csPVRemain.TextBox.Name = "PVRemain"
      csPVRemain.ReadOnly = True
      csPVRemain.Format = "#,###.##"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.Format = "#,###.##"

      Dim csRemainingAmount As New TreeTextColumn
      csRemainingAmount.MappingName = "RemainingAmount"
      csRemainingAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.RemainingAmountHeaderText}")
      csRemainingAmount.NullText = ""
      csRemainingAmount.TextBox.Name = "RemainingAmount"
      csRemainingAmount.ReadOnly = True
      csRemainingAmount.Format = "#,###.##"

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "check_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.OutGoingCheckDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csPVCode)
      dst.GridColumnStyles.Add(csPVRemain)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csRemainingAmount)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("OutGoingCheck")

      myDatatable.Columns.Add(New DataColumn("check_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PVId", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("PVCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PVRemain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainingAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("check_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("refDoc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("refDocType", GetType(Integer)))
      Return myDatatable
    End Function
    Public createCheck As Boolean
    Public Shared Sub CreateChecks(ByVal bAcct As BankAccount, ByVal startText As String, ByVal endText As String, ByVal currentUserID As Integer)
      If Not IsNumeric(startText) OrElse Not IsNumeric(endText) Then
        MessageBox.Show("Please specify numeric start and end codes!")
        Return
      End If
      If startText.Length <> endText.Length Then
        MessageBox.Show("Please specify start and end codes with same length!")
        Return
      End If

      Dim startNumber As Integer = CInt(startText)
      Dim endNumber As Integer = CInt(endText)
      Dim runNumbers As New ArrayList
      For runNumber As Integer = startNumber To endNumber
        runNumbers.Add(runNumber.ToString.PadLeft(startText.Length, "0"c))
      Next
      For Each runNumber As String In runNumbers
        Dim chk As New OutgoingCheck
        chk.Bankacct = bAcct
        chk.CqCode = runNumber.ToString
        chk.Status.Value = 2
        chk.DocStatus.Value = 5
        chk.createCheck = True
        Dim err As SaveErrorException = chk.Save(currentUserID)
        If Not IsNumeric(err.Message) Then
          Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          Try
            myMessage.ShowMessageFormatted(err.Message, err.Params)
          Catch ex As Exception
            myMessage.ShowMessage(err.Message)
          End Try
        End If
      Next
    End Sub
#End Region

#Region "Methods"
    Private Function GetList(ByVal list As List(Of PaymentForList)) As IQueryable(Of PaymentForList)
      Dim ret As IQueryable(Of PaymentForList) = (From p In list
                  Select p).AsQueryable
      Return ret
    End Function
    Public Function GetSum() As Decimal
      Return GetList(PaymentList).Sum(Function(p) p.Amount)
    End Function
    Public Function GetRemain() As Decimal
      Return Me.Amount - GetSum()
    End Function
    Public Function GetRemainingAmount(ByVal paymentId As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetOutGoingCheckAmount" _
                , New SqlParameter("@check_id", Me.Id) _
                , New SqlParameter("@paymenti_payment", paymentId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
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
      Me.IsInitialized = True
    End Sub
    Protected Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetOldOutgoingCheckPayments" _
      , New SqlParameter("@check_id", Me.Id) _
      )

      Dim i As Integer = 0
      Dim amt As Decimal = Me.Amount
      For Each row As DataRow In ds.Tables(0).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("check_linenumber") = row("paymenti_linenumber")
        dr("PVId") = row("payment_id")
        dr("Date") = row("payment_refdocDate")
        dr("Code") = row("payment_refdocCode")
        dr("PVCode") = row("payment_code")

        If IsNumeric(row("payment_remain")) Then
          dr("PVRemain") = Configuration.FormatToString(CDec(row("payment_remain")), DigitConfig.Price)
        End If
        dr("check_note") = row("payment_refdocNote")
        dr("refDoc") = row("payment_refDoc")
        dr("refDocType") = row("payment_refDocType")
        If IsNumeric(row("paymenti_amt")) Then
          Dim rowAmt As Decimal = CDec(row("paymenti_amt"))
          dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
          amt -= rowAmt
        End If
        dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
      Next
    End Sub
    Private m_paymentList As List(Of PaymentForList)
    Public ReadOnly Property PaymentList As List(Of PaymentForList) Implements IExportable.PaymentList
      Get
        If m_paymentList Is Nothing Then
          m_paymentList = New List(Of PaymentForList)
        End If
        Return m_paymentList
      End Get
    End Property
    Public Shared Function PVListDataSet() As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetOutgoingCheckPayments" _
    , New SqlParameter("@check_id", DBNull.Value) _
    , New SqlParameter("@supplier_id", DBNull.Value) _
    )
      Return ds
    End Function
    Public Sub RefreshPVList2()
      Dim ds As DataSet = ExportOutgoingCheck.OutGoingCheckPaymentDataSet

      m_paymentList = New List(Of PaymentForList)
      For Each row As DataRow In ds.Tables(0).Select("check_id=" & Me.Id.ToString)
        Dim deh As New DataRowHelper(row)
        Dim p As New PaymentForList
        p.Id = deh.GetValue(Of Integer)("Id")
        p.Code = deh.GetValue(Of String)("Code")
        p.RefId = deh.GetValue(Of Integer)("RefId")
        p.RefCode = deh.GetValue(Of String)("RefCode")
        p.RefType = deh.GetValue(Of String)("RefType")
        p.RefTypeId = deh.GetValue(Of Integer)("RefTypeId")
        p.RefDocDate = deh.GetValue(Of Date)("RefDocDate")
        p.RefDueDate = deh.GetValue(Of Date)("RefDueDate")
        p.RefAmount = deh.GetValue(Of Decimal)("RefAmount")
        p.Amount = deh.GetValue(Of Decimal)("Amount")
        p.RefPaid = deh.GetValue(Of Decimal)("RefPaid")
        p.Note = deh.GetValue(Of String)("Note")
        p.JustAdded = False

        '===========================================================
        p.PayeeFax = deh.GetValue(Of String)("PayeeFax")
        p.PayeeID = deh.GetValue(Of String)("PayeeID")
        p.PayeeName = deh.GetValue(Of String)("PayeeName")
        p.PayeeTaxID = deh.GetValue(Of String)("PayeeTaxID")
        p.PersonalID = deh.GetValue(Of String)("PersonalID")

        p.KbankDCAccount = deh.GetValue(Of String)("KbankDCAccount")
        p.KbankDCBank = deh.GetValue(Of String)("KbankDCBank")
        p.KbankMCAccount = deh.GetValue(Of String)("KbankMCAccount")
        p.KbankMCBank = deh.GetValue(Of String)("KbankMCBank")
        '===========================================================

        '===========================================================
        Dim drs As DataRow() = ds.Tables(1).Select("ID=" & p.Id.ToString)
        If Not drs Is Nothing AndAlso drs.Length > 0 Then
          Dim currentTaxInfo As New TaxInfo
          For Each r As DataRow In drs
            Dim deh2 As New DataRowHelper(r)
            Dim wid As Integer = deh2.GetValue(Of Integer)("whtid")
            If currentTaxInfo.ID <> wid Then
              currentTaxInfo = New TaxInfo
              currentTaxInfo.ID = wid
              currentTaxInfo.TaxCondition = deh2.GetValue(Of String)("TaxCondition")
              currentTaxInfo.TaxForm = deh2.GetValue(Of String)("TaxForm")
              p.TaxInfos.Add(currentTaxInfo)
            End If
            Dim ti As New TaxInfoItem
            ti.Description = deh2.GetValue(Of String)("Description")
            ti.BeforeVAT = deh2.GetValue(Of Decimal)("BeforeVAT")
            ti.TaxRate = deh2.GetValue(Of Decimal)("TaxRate")
            ti.AfterVat = ti.BeforeVAT + Vat.GetVatAmount(ti.BeforeVAT)
            ti.WHT = deh2.GetValue(Of Decimal)("TaxAmount")
            currentTaxInfo.TaxInfoItems.Add(ti)
          Next
        End If
        '===========================================================
        m_paymentList.Add(p)
      Next
    End Sub
    Public Sub RefreshPVList()
      If Not ExportOutgoingCheck.OutGoingCheckPaymentDataSet Is Nothing Then
        RefreshPVList2()
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
        , CommandType.StoredProcedure _
        , "GetOutgoingCheckPayments" _
        , New SqlParameter("@check_id", Me.Id) _
        , New SqlParameter("@supplier_id", Me.ValidIdOrDBNull(Me.Supplier)) _
        )

      m_paymentList = New List(Of PaymentForList)
      For Each row As DataRow In ds.Tables(0).Rows
        Dim deh As New DataRowHelper(row)
        Dim p As New PaymentForList
        p.Id = deh.GetValue(Of Integer)("Id")
        p.Code = deh.GetValue(Of String)("Code")
        p.RefId = deh.GetValue(Of Integer)("RefId")
        p.RefCode = deh.GetValue(Of String)("RefCode")
        p.RefType = deh.GetValue(Of String)("RefType")
        p.RefTypeId = deh.GetValue(Of Integer)("RefTypeId")
        p.RefDocDate = deh.GetValue(Of Date)("RefDocDate")
        p.RefDueDate = deh.GetValue(Of Date)("RefDueDate")
        p.RefAmount = deh.GetValue(Of Decimal)("RefAmount")
        p.Amount = deh.GetValue(Of Decimal)("Amount")
        p.RefPaid = deh.GetValue(Of Decimal)("RefPaid")
        p.Note = deh.GetValue(Of String)("Note")
        p.JustAdded = False

        '===========================================================
        p.PayeeFax = deh.GetValue(Of String)("PayeeFax")
        p.PayeeID = deh.GetValue(Of String)("PayeeID")
        p.PayeeName = deh.GetValue(Of String)("PayeeName")
        p.PayeeTaxID = deh.GetValue(Of String)("PayeeTaxID")
        p.PersonalID = deh.GetValue(Of String)("PersonalID")

        p.KbankDCAccount = deh.GetValue(Of String)("KbankDCAccount")
        p.KbankDCBank = deh.GetValue(Of String)("KbankDCBank")
        p.KbankMCAccount = deh.GetValue(Of String)("KbankMCAccount")
        p.KbankMCBank = deh.GetValue(Of String)("KbankMCBank")
        '===========================================================

        '===========================================================
        Dim drs As DataRow() = ds.Tables(1).Select("ID=" & p.Id.ToString)
        If Not drs Is Nothing AndAlso drs.Length > 0 Then
          Dim currentTaxInfo As New TaxInfo
          For Each r As DataRow In drs
            Dim deh2 As New DataRowHelper(r)
            Dim wid As Integer = deh2.GetValue(Of Integer)("whtid")
            If currentTaxInfo.ID <> wid Then
              currentTaxInfo = New TaxInfo
              currentTaxInfo.ID = wid
              currentTaxInfo.TaxCondition = deh2.GetValue(Of String)("TaxCondition")
              currentTaxInfo.TaxForm = deh2.GetValue(Of String)("TaxForm")
              p.TaxInfos.Add(currentTaxInfo)
            End If
            Dim ti As New TaxInfoItem
            ti.Description = deh2.GetValue(Of String)("Description")
            ti.BeforeVAT = deh2.GetValue(Of Decimal)("BeforeVAT")
            ti.TaxRate = deh2.GetValue(Of Decimal)("TaxRate")
            ti.AfterVat = ti.BeforeVAT + Vat.GetVatAmount(ti.BeforeVAT)
            ti.WHT = deh2.GetValue(Of Decimal)("TaxAmount")
            currentTaxInfo.TaxInfoItems.Add(ti)
          Next
        End If
        '===========================================================
        m_paymentList.Add(p)
      Next
    End Sub
    'Public Sub RefreshPV()    '  Me.IsInitialized = False
    '  If m_itemTable Is Nothing Then
    '    Return
    '  End If
    '  m_itemTable.Clear()
    '  If Me.Supplier Is Nothing OrElse Not Me.Supplier.Originated Then
    '    Return
    '  End If
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
    '  , CommandType.StoredProcedure _
    '  , "GetOutgoingCheckPayments" _
    '  , New SqlParameter("@check_id", Me.Id) _
    '  , New SqlParameter("@supplier_id", Me.ValidIdOrDBNull(Me.Supplier)) _
    '  )
    '  Dim i As Integer = 0
    '  Dim amt As Decimal = Me.Amount
    '  For Each row As DataRow In ds.Tables(0).Rows
    '    i += 1
    '    Dim dr As TreeRow = m_itemTable.Childs.Add
    '    dr("check_linenumber") = row("paymenti_linenumber")
    '    dr("PVId") = row("payment_id")
    '    dr("Date") = row("payment_refdocDate")
    '    dr("Code") = row("payment_refdocCode")
    '    dr("PVCode") = row("payment_code")
    '    dr("PVRemain") = Configuration.FormatToString(CDec(row("payment_remain")), DigitConfig.Price)
    '    dr("check_note") = row("payment_refdocNote")
    '    dr("refDoc") = row("payment_refDoc")
    '    dr("refDocType") = row("payment_refDocType")
    '    If IsNumeric(row("paymenti_amt")) Then
    '      Dim rowAmt As Decimal = CDec(row("paymenti_amt"))
    '      rowAmt = Math.Min(amt, rowAmt)
    '      dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
    '      amt -= rowAmt
    '    End If
    '    dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
    '  Next
    '  For Each row As DataRow In ds.Tables(1).Rows
    '    i += 1
    '    Dim dr As TreeRow = m_itemTable.Childs.Add
    '    dr("check_linenumber") = row("paymenti_linenumber")
    '    dr("PVId") = row("payment_id")
    '    dr("Date") = row("payment_refdocDate")
    '    dr("Code") = row("payment_refdocCode")
    '    dr("PVCode") = row("payment_code")
    '    dr("PVRemain") = Configuration.FormatToString(CDec(row("payment_remain")), DigitConfig.Price)
    '    dr("check_note") = row("payment_refdocNote")
    '    dr("refDoc") = row("payment_refDoc")
    '    dr("refDocType") = row("payment_refDocType")
    '    If IsNumeric(row("payment_remain")) Then
    '      Dim rowAmt As Decimal = CDec(row("payment_remain"))
    '      rowAmt = Math.Min(amt, rowAmt)
    '      dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
    '      amt -= rowAmt
    '    End If
    '    dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
    '  Next
    '  Me.IsInitialized = True
    'End Sub
    'Public Sub ReIndex()
    '  Dim i As Integer = 0
    '  Dim amt As Decimal = Me.Amount
    '  For Each row As DataRow In m_itemTable.Childs
    '    i += 1
    '    row("check_linenumber") = i
    '    If IsNumeric(row("PVRemain")) Then
    '      Dim rowAmt As Decimal = CDec(row("PVRemain"))
    '      rowAmt = Math.Min(amt, rowAmt)
    '      row("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
    '      amt -= rowAmt
    '    End If
    '    row("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
    '  Next
    'End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "OutgoingCheck"
      End Get
    End Property

    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "OutgoingCheck"
      End Get
    End Property

    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "Get" & Me.TableName
      End Get
    End Property

    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "check"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.OutgoingCheck.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.OutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.OutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.OutgoingCheck.ListLabel}"
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

    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      If Me.Amount <= 0 AndAlso (Me.DocStatus.Value <> 5 OrElse Me.Originated) Then
        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", "${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckDetailView.lblAmount}")
      End If
      If Me.Originated Then
        If Not Me.Supplier Is Nothing Then
          If Me.Supplier.Canceled Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.Supplier.Code})
          End If
        End If
      End If
      ' กำหนด SqlParameter เพื่อ return ค่าการ Execute procedure ...
      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current

      ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
      Dim paramArrayList As New ArrayList

      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False


      If Me.Status.Value = -1 Then
        Me.Status.Value = 2
      End If

      If Me.DocStatus.Value = -1 Then
        Me.DocStatus.Value = 1 'default = เช็คในมือ
      End If

      If Me.DocStatus.Value = 5 AndAlso Me.Originated Then
        'Save หลังจากการ Autorun
        Me.DocStatus.Value = 1 'default = เช็คในมือ
      End If

      paramArrayList.Add(returnVal)
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cqcode", Me.CqCode))
      Dim config As Boolean = CBool(Configuration.GetConfig("UseCheckRegistration"))
      If config And createCheck Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_issuedate", DBNull.Value)) 'ValidDateOrDBNull(Me.IssueDate)))
      Else
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_issuedate", ValidDateOrDBNull(Me.IssueDate)))
      End If
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duedate", ValidDateOrDBNull(Me.DueDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_supplier", Me.ValidIdOrDBNull(Me.Supplier)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_recipient", Me.Recipient))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", Me.ValidIdOrDBNull(Me.Bankacct)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.DocStatus.Value))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_ACPayeeOnly", Me.ACPayeeOnly))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_Unbearer", Me.Unbearer))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_exporttype", Me.ExportType))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receiptAtbank", Me.ReceiptAtBank))

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
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Me.ResetID(oldid)
              Return New SaveErrorException("${res:Global.Error.DupCheckCode}", New String() {Me.Code, Me.CqCode})
            Case -2
              trans.Rollback()
              Me.ResetID(oldid)
              Return New SaveErrorException("${res:Global.Error.OutgoingCheckCodeIsRefed}", Me.Code)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Dim detailError As SaveErrorException = SaveDetail(Me.Id, conn, trans, currentUserId)
        If Not IsNumeric(detailError.Message) Then
          Me.ResetID(oldid)
          trans.Rollback()
          Return detailError
        Else
          Select Case CInt(detailError.Message)
            Case -1, -5
              Me.ResetID(oldid)
              trans.Rollback()
              Return New SaveErrorException(returnVal.Value.ToString)
            Case -2
              Me.ResetID(oldid)
              trans.Rollback()
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        End If
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
        Try
          For Each item As PaymentForList In Me.PaymentList
            If item.JustAdded Then
              Dim refType As Integer = item.RefTypeId
              Dim refId As Integer = item.RefId
              Dim theEntity As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(refType), refId)
              Dim m_whtcol As WitholdingTaxCollection
              Dim m_FirstWht As WitholdingTax
              If TypeOf (theEntity) Is IPayable Then
                Dim payable As IPayable = CType(theEntity, IPayable)
                If payable.Payment IsNot Nothing Then
                  payable.Payment.OnHold = False
                End If
              End If
              '====================WHT=========================
              If TypeOf theEntity Is IWitholdingTaxable Then
                Dim whtRefDoc As IWitholdingTaxable = CType(theEntity, IWitholdingTaxable)
                m_whtcol = whtRefDoc.WitholdingTaxCollection
                If m_whtcol Is Nothing Then
                  m_whtcol = New WitholdingTaxCollection
                  m_whtcol.RefDoc.WitholdingTaxCollection = m_whtcol
                End If
                If m_whtcol.Count > 0 Then
                  For Each witem As WitholdingTax In m_whtcol
                    witem.RefDoc.WitholdingTaxCollection = m_whtcol
                    witem.RefDoc = whtRefDoc
                    witem.Entity = whtRefDoc.Person
                  Next
                  m_FirstWht = m_whtcol(0)
                Else
                  m_FirstWht = New WitholdingTax
                  m_FirstWht.Code = BusinessLogic.Entity.GetAutoCodeFormat(m_FirstWht.EntityId)
                  m_FirstWht.LastestCode = m_FirstWht.Code
                  m_FirstWht.RefDoc.WitholdingTaxCollection = m_whtcol
                  m_FirstWht.RefDoc = whtRefDoc
                  m_FirstWht.Entity = whtRefDoc.Person
                  m_whtcol.Add(m_FirstWht)
                End If

                If whtRefDoc.WitholdingTaxCollection.Count > 0 AndAlso _
                   whtRefDoc.WitholdingTaxCollection.CanBeDelay Then
                  m_whtcol = whtRefDoc.WitholdingTaxCollection
                End If
                m_whtcol.RefDoc = whtRefDoc
              End If
              If m_whtcol.Count > 0 Then
                If Not m_whtcol Is Nothing AndAlso m_whtcol.Contains(m_whtcol(0)) Then
                  m_FirstWht = m_whtcol(0)
                End If
              Else
                Dim whtRefDoc As IWitholdingTaxable = CType(theEntity, IWitholdingTaxable)
                m_whtcol = whtRefDoc.WitholdingTaxCollection

                m_FirstWht = New WitholdingTax
                m_FirstWht.Code = BusinessLogic.Entity.GetAutoCodeFormat(m_FirstWht.EntityId)
                m_FirstWht.LastestCode = m_FirstWht.Code
                m_FirstWht.RefDoc.WitholdingTaxCollection = m_whtcol
                m_FirstWht.RefDoc = whtRefDoc
                m_FirstWht.Entity = whtRefDoc.Person
                m_whtcol.Add(m_FirstWht)
              End If
              '====================WHT=========================

              '======================GL=======================
              'theEntity.GLIsChanged = True
              '======================GL=======================
              theEntity.Save(currentUserId)
            End If
          Next
        Catch ex As Exception
        End Try
      End Try
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
      If Me.Amount <= 0 AndAlso (Me.DocStatus.Value <> 5 OrElse Me.Originated) Then
        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", "${res:Longkong.Pojjaman.Gui.Panels.OutgoingCheckDetailView.lblAmount}")
      End If
      ' กำหนด SqlParameter เพื่อ return ค่าการ Execute procedure ...
      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current

      ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
      Dim paramArrayList As New ArrayList

      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False


      If Me.Status.Value = -1 Then
        Me.Status.Value = 2
      End If

      If Me.DocStatus.Value = -1 Then
        Me.DocStatus.Value = 1 'default = เช็คในมือ
      End If

      If Me.DocStatus.Value = 5 AndAlso Me.Originated Then
        'Save หลังจากการ Autorun
        Me.DocStatus.Value = 1 'default = เช็คในมือ
      End If

      paramArrayList.Add(returnVal)
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cqcode", Me.CqCode))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_issuedate", ValidDateOrDBNull(Me.IssueDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duedate", ValidDateOrDBNull(Me.DueDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_supplier", Me.ValidIdOrDBNull(Me.Supplier)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_recipient", Me.Recipient))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", Me.ValidIdOrDBNull(Me.Bankacct)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.DocStatus.Value))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_ACPayeeOnly", Me.ACPayeeOnly))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_Unbearer", Me.Unbearer))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_exporttype", Me.ExportType))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receiptAtbank", Me.ReceiptAtBank))

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
              Return New SaveErrorException("${res:Global.Error.DupCheckCode}", New String() {Me.Code, Me.CqCode})
            Case -2
              Me.ResetID(oldid)
              Return New SaveErrorException("${res:Global.Error.OutgoingCheckCodeIsRefed}", Me.Code)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          Me.ResetID(oldid)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        Me.ResetID(oldid)
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        Me.ResetID(oldid)
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Function GetPaymentIdToSave() As String
      Dim list As New List(Of String)
      list.Add("'0'")
      For Each item As PaymentForList In Me.PaymentList
        If item.JustAdded Then
          list.Add(item.Id.ToString)
        End If
      Next
      Return String.Join(",", list.ToArray)
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal currentUserId As Integer) As SaveErrorException
      Try
        Dim da As New SqlDataAdapter("Select * from paymentitem where (paymenti_entitytype = 22 and paymenti_entity=" & Me.Id & ") or paymenti_payment in (" & GetPaymentIdToSave() & ")", conn)
        Dim da2 As New SqlDataAdapter("select * from payment where payment_id in (" & GetPaymentIdToSave() & ")", conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "paymentitem")

        '=================================================
        cmdBuilder = New SqlCommandBuilder(da2)

        da2.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da2.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da2.Fill(ds, "payment")
        '=================================================

        With ds.Tables("paymentitem")
          Dim rowsToDelete As New List(Of DataRow)
          For Each row As DataRow In .Rows
            Dim found As Boolean = False
            For Each item As PaymentForList In Me.PaymentList
              If item.Id = CInt(row("paymenti_payment")) Then
                found = True
                Exit For
              End If
            Next
            If Not found Then
              rowsToDelete.Add(row)
            End If
          Next
          For Each row As DataRow In rowsToDelete
            row.Delete()
          Next
          Dim i As Integer = 0
          For Each item As PaymentForList In Me.PaymentList
            If item.JustAdded Then
              Dim drs1 As DataRow() = ds.Tables("paymentitem").Select("paymenti_payment = " & item.Id.ToString)
              If Not drs1 Is Nothing AndAlso drs1.Length > 0 Then
                Dim dr As DataRow = drs1(0)
                dr("paymenti_entity") = Me.Id
                dr("paymenti_entitycode") = Me.CqCode
                dr("paymenti_payment") = item.Id
                dr("paymenti_linenumber") = i + 1
                dr("paymenti_entityType") = Me.EntityId
                dr("paymenti_refamt") = Me.Amount
                dr("paymenti_amt") = item.Amount
                dr("paymenti_note") = item.Note
                dr("paymenti_status") = Me.Status.Value
              End If
              i += 1
              Dim drs As DataRow() = ds.Tables("payment").Select("payment_id = " & item.Id.ToString)
              If Not drs Is Nothing AndAlso drs.Length > 0 Then
                Dim paymentDR As DataRow = drs(0)
                Dim deh As New DataRowHelper(paymentDR)
                Dim oldAmount As Decimal = deh.GetValue(Of Decimal)("payment_amt")
                Dim oldGross As Decimal = deh.GetValue(Of Decimal)("payment_gross")
                paymentDR("payment_gross") = oldGross + item.Amount
              End If
            End If
          Next
        End With
        Dim dt As DataTable = ds.Tables("paymentitem")
        ' First process deletes.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        Dim dt2 As DataTable = ds.Tables("payment")
        da2.Update(dt2.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
      Return New SaveErrorException("0")
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.DocStatus.Value = 1
        End If
        Return False
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteOutgoingCheck}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteOutgoingCheck", New SqlParameter() {New SqlParameter("@check_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.OutgoingCheckIsReferencedCannotBeDeleted}")
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

#Region "IPrintableEntity"
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "OutgoingCheck"
    End Function
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "OutgoingCheck"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Amount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      If Not Me.DueDate.Equals(Date.MinValue) Then
        dpi.Value = Me.DueDate.ToShortDateString
      Else
        dpi.Value = ""
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Recipient
      dpi = New DocPrintingItem
      dpi.Mapping = "Recipient"
      dpi.Value = Me.Recipient
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Me.ACPayeeOnly Then
        'ACPayeeOnly
        dpi = New DocPrintingItem
        dpi.Mapping = "ACPayeeOnly"
        dpi.Value = "OK"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Me.Unbearer Then
        'Unbearer
        dpi = New DocPrintingItem
        dpi.Mapping = "Unbearer"
        dpi.Value = "OK"
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Return dpiColl
    End Function
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

  Public Class OutgoingCheckForSelection
    Inherits OutgoingCheck
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "OutgoingCheckForSelection"
      End Get
    End Property
  End Class

  Public Class OutgoingCheckDocStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal description As String)
      MyBase.New(description)
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "outgoingcheck_docstatus"
      End Get
    End Property
#End Region

  End Class

  Public Interface IExportable
    Inherits IHasBankAccount, IPaymentItem

    ReadOnly Property PaymentList As List(Of PaymentForList)

    Property ExportType As String

  End Interface
  Public Interface ICOCExportable
    Inherits IExportable

    Property EffectiveDate As Date
    Property PickUpDate As Date
    Property Chargee As String
    Function ChequeReceiverList() As List(Of ChequeReceiver)

    'ReadOnly Property ChequePaymentList As List(Of ChequePayment)
    'ReadOnly Property ChequePaymentVatList As List(Of ChequePaymentVat)

  End Interface
  Public Interface IPaymentTrackExportable
    Property PayerBuilkID As String
    Property PaymentTrackID As String
    Property PaymentTrackStatus As String
    ReadOnly Property CheckQty As Integer
    ReadOnly Property CheckAmount As Decimal
    Function PaymenTrackCheckDetailList() As List(Of PaymentTrackCheckDetail)
  End Interface
  Public Class Exporter
    Private Shared Function GetCompanyName() As String
      Return CStr(Configuration.GetConfig("CompanyName"))
    End Function
    Public Shared Function GetBankInfo(ByVal bankName As String, ByVal bankAccountCode As String) As BankInfo
      If bankName Is Nothing Then
        bankName = ""
      End If
      If bankAccountCode Is Nothing Then
        bankAccountCode = "0000"
      End If
      Dim bi As New BankInfo
      bi.BankName = bankName.Trim
      bi.BankAccountCode = bankAccountCode
      bi.BankBranchCode = bankAccountCode.Substring(0, 3)
      Select Case bankName
        Case "กรุงเทพ"
          bi.BankCode = "002"
        Case "กสิกรไทย"
          bi.BankCode = "004"
        Case "เอบีเอ็น แอมโร"
          bi.BankCode = "005"
          bi.BankBranchCode = "001"
        Case "กรุงไทย"
          bi.BankCode = "006"
        Case "เจพีมอร์แกน(เชส)"
          bi.BankCode = "008"
          bi.BankBranchCode = "001"
        Case "โตเกียว-มิตซูบิชิ"
          bi.BankCode = "010"
          bi.BankBranchCode = "001"
        Case "ทหารไทย"
          bi.BankCode = "011"
        Case "ไทยพาณิชย์"
          bi.BankCode = "014"
        Case "นครหลวงไทย"
          bi.BankCode = "015"
        Case "ซิตี้แบงก์"
          bi.BankCode = "017"
          bi.BankBranchCode = "001"
        Case "ซูมิโตโม มิตซุย แบงกิ้ง"
          bi.BankCode = "018"
          bi.BankBranchCode = "001"
        Case "สแตนดาร์ดชาร์เตอร์ด(ไทย)"
          bi.BankCode = "020"
        Case "ไทยธนาคาร"
          bi.BankCode = "022"
        Case "ยูโอบี"
          bi.BankCode = "024"
        Case "กรุงศรีอยุธยา"
          bi.BankCode = "025"
        Case "เมกะ สากลพาณิชย์"
          bi.BankCode = "026"
          bi.BankBranchCode = "001"
        Case "อเมริกา"
          bi.BankCode = "027"
          bi.BankBranchCode = "001"
        Case "คาลิยง"
          bi.BankCode = "028"
          bi.BankAccountCode = bankAccountCode.Substring(0, 11)
          bi.BankBranchCode = "0001" '===== 4 digit
        Case "ออมสิน"
          bi.BankCode = "030"
          Select Case bankAccountCode.Length
            Case 15
              bi.BankAccountCode = bankAccountCode.Substring(4, 11)
              bi.BankBranchCode = bankAccountCode.Substring(0, 4) '===== 4 digit
            Case 12
              bi.BankAccountCode = "999" & bankAccountCode
              bi.BankBranchCode = "999" & bankAccountCode.Substring(0, 1) '===== 4 digit
          End Select
        Case "ฮ่องกงและเซี่ยงไฮ้"
          bi.BankCode = "031"
          bi.BankBranchCode = "0001" '===== 4 digit
        Case "ดอยช์แบงก์"
          bi.BankCode = "032"
          bi.BankBranchCode = "001"
        Case "อาคารสงเคราะห์"
          bi.BankCode = "033"
          Select Case bankAccountCode.Length
            Case 10
              Dim d12 As String = "0" & bankAccountCode.Substring(0, 4) & "0" & bankAccountCode.Substring(4, 6)
              bi.BankBranchCode = d12.Substring(0, 3)
              bi.BankAccountCode = d12
            Case 12
              Dim d15 As String = "0" & bankAccountCode.Substring(0, 3) & "00" & bankAccountCode.Substring(3, 9)
              bi.BankBranchCode = d15.Substring(0, 4)
              bi.BankAccountCode = d15.Substring(4, 11)
          End Select
        Case "เพื่อการเกษตรและสหกรณ์ฯ"
          bi.BankCode = "034"
        Case "มิซูโฮ(คอร์ปอเรต)"
          bi.BankCode = "039"
          bi.BankAccountCode = bankAccountCode.Substring(1, 11)
          bi.BankBranchCode = "0001" '===== 4 digit
        Case "ธนชาต"
          bi.BankCode = "065"
        Case "อิสลามแห่งประเทศไทย"
          bi.BankCode = "066"
          Select Case bankAccountCode.Length
            Case 10
              'Default
            Case 12
              Dim d10 As String = bankAccountCode.Substring(1, 10)
              bi.BankBranchCode = d10.Substring(0, 3)
              bi.BankAccountCode = d10
          End Select
        Case "ทิสโก้"
          bi.BankCode = "067"
          bi.BankAccountCode = bankAccountCode.Substring(4, 10)
          bi.BankBranchCode = bankAccountCode.Substring(0, 4)
        Case "เอไอจี เพื่อรายย่อย"
          bi.BankCode = "068"
        Case "เกียรตินาคิน"
          bi.BankCode = "069"
          bi.BankAccountCode = bankAccountCode.Substring(4, 10)
          bi.BankBranchCode = bankAccountCode.Substring(0, 4)
        Case "สินเอเซีย"
          bi.BankCode = "070"
        Case "ไทยเครดิต เพื่อรายย่อย"
          bi.BankCode = "071"
        Case "แลนด์แอนด์เฮ้าส์ เพื่อรายย่อย"
          bi.BankCode = "073"
      End Select
      Return bi
    End Function
    Public Class BankInfo
      Public BankCode As String
      Public BankName As String
      Public BankAccountCode As String
      Public BankBranchCode As String
    End Class
    Public Shared Sub Export(ByVal c As IExportable, ByVal writer As TextWriter)
      Dim t As String = c.ExportType.ToLower
      Select Case t.ToLower
        Case "mcl"
          ExportMCP(c, t, writer)
        Case "dct", "pct"
          ExportDCP(c, t, writer)
        Case "coc"
          If TypeOf c Is ICOCExportable Then
            ExportCOC(CType(c, ICOCExportable), t, writer)
          Else
            ExportCOC(c, t, writer)
          End If
      End Select
    End Sub
    Private Shared Sub ExportMCP(ByVal c As IExportable, ByVal t As String, ByVal writer As TextWriter)
      Dim theItemList As List(Of PaymentForList) = c.PaymentList 'GetGroupedList(c.PaymentList, t)
      Dim amtString As String = Configuration.FormatToString(c.Amount, 2)

      Dim culture As New CultureInfo("en-US", True)

      Dim effectiveDate As Date = c.DueDate
      If theItemList IsNot Nothing AndAlso theItemList.Count > 0 Then
        effectiveDate = theItemList(0).RefDueDate
      End If
      Dim exportTime As Date = Date.Now
      Dim header As String = ""
      header &= "H" 'Part Identifier
      header &= "MCL" 'Payment Type
      header &= String.Format("{0,-10}", c.BankAccount.BankCode.Replace("-", "")) 'Debit A/C No.
      header &= Space(16) 'Batch Ref.#
      header &= effectiveDate.ToString("dd-MM-yyyy", culture) 'Effective Date
      header &= Space(5) 'Customer Branch #
      header &= String.Format("{0:000000000000000000}", theItemList.Count)  'Total Credit Items
      header &= String.Format("{0:000000000000000.00}", CDbl(Replace(amtString, ",", ""))) 'Total Debit Amount
      header &= "N" 'Charges for A/C Of.

      writer.WriteLine(header)

      Dim i As Integer = 1
      For Each item As PaymentForList In theItemList
        Dim bi As BankInfo = GetBankInfo(item.KbankMCBank, item.KbankMCAccount)
        Dim itemBankCode As String = bi.BankCode
        Dim itemBankName As String = bi.BankName
        Dim itemBankBranchCode As String = bi.BankBranchCode
        Dim itemBankBranchName As String = ""
        Dim itemAccount As String = bi.BankAccountCode

        Dim itemAmountString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemBfVatString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemWHtString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemAfVatString As String = Configuration.FormatToString(item.Amount, 2)

        Dim creditText As String = ""
        creditText &= "D" 'Part Identifier
        creditText &= String.Format("{0,-10}", i) 'Txn. Reference No.
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemAmountString, ",", ""))) 'Amount
        creditText &= String.Format("{0,-80}", item.PayeeName).Substring(0, 80) 'Payee
        creditText &= Space(30) 'Payee Address 1
        creditText &= Space(30) 'Payee Address 2
        creditText &= Space(30) 'Payee Address 3
        creditText &= Space(30) 'Payee Address 4
        creditText &= String.Format("{0:00000000000000000000}", CDbl(itemAccount)) 'A/C #
        creditText &= String.Format("{0,-16}", item.RefCode).Substring(0, 16) 'Bene. Ref #
        creditText &= String.Format("{0,-13}", item.PersonalID).Substring(0, 13) 'Personal Id
        creditText &= String.Format("{0:0000}", CInt(itemBankBranchCode)) 'Branch Code
        creditText &= String.Format("{0:000}", CInt(itemBankCode)) 'Bank No
        creditText &= Space(255) 'Details
        creditText &= String.Format("{0,-10}", item.PayeeTaxID) 'Tax Id
        creditText &= Space(50) 'Attachment Sub-file
        creditText &= "F" 'Advice Mode (F = fax)
        creditText &= String.Format("{0,-50}", SetDigitOnly(item.PayeeFax)) 'Fax No.
        creditText &= Space(50) 'Email ID
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemBfVatString, ",", ""))) 'Total Inv Amt bef VAT (10.2)
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemWHtString, ",", ""))) 'Total Tax deducted Amt (10.2)
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemAfVatString, ",", ""))) 'Total Inv Amt after VAT (10.2)
        creditText &= String.Format("{0:000}", item.TaxInfos.Count) 'Tax Info Count
        writer.WriteLine(creditText)

        Dim j As Integer = 1
        For Each taxi As TaxInfo In item.TaxInfos
          For Each ti As TaxInfoItem In taxi.TaxInfoItems
            Dim tiAmountString As String = Configuration.FormatToString(ti.TaxRate, 2)
            Dim tiBfVatString As String = Configuration.FormatToString(ti.BeforeVAT, 2)
            Dim tiWHtString As String = Configuration.FormatToString(ti.WHT, 2)
            Dim tiAfVatString As String = Configuration.FormatToString(ti.AfterVat, 2)

            Dim taxDetail As String = ""
            taxDetail &= "T" 'Part Identifier
            taxDetail &= taxi.TaxForm 'Tax Form
            taxDetail &= String.Format("{0,-10}", j) 'Tax Seq.#
            taxDetail &= String.Format("{0:000.00}", CDbl(Replace(tiAmountString, ",", ""))) 'Tax rate (3.2)
            taxDetail &= String.Format("{0,-40}", ti.Description).Substring(0, 40)   'Type of tax deducted
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiBfVatString, ",", ""))) 'Inv Amt bef VAT (10.2)
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiWHtString, ",", ""))) 'Tax deducted Amt (10.2)
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiAfVatString, ",", ""))) 'Inv Amt after VAT (10.2)
            taxDetail &= taxi.TaxCondition 'Tax Condition
            writer.WriteLine(taxDetail)
          Next

          j += 1
        Next

        i += 1
      Next
    End Sub
    'Public Const COMPANY_NAME As String = "บริษัท วิศวภัทร์ จำกัด"
    Private Shared Sub ExportDCP(ByVal c As IExportable, ByVal t As String, ByVal writer As TextWriter)
      Dim theItemList As List(Of PaymentForList) = c.PaymentList 'GetGroupedList(c.PaymentList, t)
      Dim amtString As String = Configuration.FormatToString(c.Amount, 2)

      Dim culture As New CultureInfo("en-US", True)

      Dim effectiveDate As Date = c.DueDate
      If theItemList IsNot Nothing AndAlso theItemList.Count > 0 Then
        effectiveDate = theItemList(0).RefDueDate
      End If
      Dim exportTime As Date = Date.Now
      Dim header As String = ""
      header &= "H" 'Part Identifier
      header &= t.ToUpper '"DCT","PCT" 'PRODUCT TYPE
      header &= Space(16) 'Batch Ref.#
      header &= "000000" 'TRANS-NO
      header &= Space(1) 'FILLER
      header &= Space(4) 'TRANS-TYPE
      header &= Space(1) 'FILLER
      header &= Space(7) 'COMPANY-CODE
      header &= Space(1) 'FILLER
      header &= String.Format("{0,-10}", c.BankAccount.BankCode.Replace("-", "")) 'ACCT-NO
      header &= Space(1) 'FILLER
      header &= String.Format("{0:000000000000000}", CDbl(Replace(Replace(amtString, ",", ""), ".", ""))) 'AMOUNT
      header &= Space(1) 'FILLER
      header &= exportTime.ToString("yyMMdd", culture) 'TRANS-DATE
      header &= Space(1) 'FILLER
      header &= Space(23) 'TITLE
      header &= Space(1) 'FILLER
      header &= String.Format("{0,-50}", GetCompanyName) 'NAME
      header &= effectiveDate.ToString("yyMMdd", culture) 'EFFECTIVE-DATE
      header &= String.Format("{0:000000000000000000}", theItemList.Count)  'Total Credit Items
      header &= "N" 'CHARGES FOR A/C OF
      header &= Space(5) 'Customer Branch #

      writer.WriteLine(header)

      Dim i As Integer = 1
      For Each item As PaymentForList In theItemList
        Dim bi As BankInfo = GetBankInfo(item.KbankDCBank, item.KbankDCAccount)
        Dim itemBankCode As String = bi.BankCode
        Dim itemBankName As String = bi.BankName
        Dim itemBankBranchCode As String = bi.BankBranchCode
        Dim itemBankBranchName As String = ""
        Dim itemAccount As String = bi.BankAccountCode

        Dim itemAmountString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemBfVatString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemWHtString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemAfVatString As String = Configuration.FormatToString(item.Amount, 2)

        Dim creditText As String = ""
        creditText &= "D" 'Part Identifier 1
        creditText &= String.Format("{0:000000}", i) 'TRANS-NO 6
        creditText &= Space(1) 'FILLER 1
        creditText &= Space(4) 'TRANS-TYPE 4
        creditText &= Space(1) 'FILLER 1
        creditText &= Space(7) 'COMPANY-CODE 7
        creditText &= Space(1) 'FILLER 1
        If IsNumeric(itemAccount.Replace("-", "")) Then
          creditText &= String.Format("{0:0000000000}", CDbl(itemAccount.Replace("-", ""))) 'ACCT-NO
        Else
          creditText &= String.Format("{0,-10}", itemAccount.Replace("-", "")) 'ACCT-NO
        End If
        creditText &= Space(1) 'FILLER
        creditText &= String.Format("{0:000000000000000}", CDbl(Replace(Replace(itemAmountString, ",", ""), ".", ""))) 'AMOUNT
        creditText &= Space(1) 'FILLER
        creditText &= exportTime.ToString("yyMMdd", culture) 'TRANS-DATE
        creditText &= Space(1) 'FILLER
        creditText &= Space(23) 'TITLE
        creditText &= Space(1) 'FILLER        
        creditText &= String.Format("{0,-50}", item.PayeeName).Substring(0, 50) 'NAME
        creditText &= item.RefDueDate.ToString("yyMMdd", culture) 'EFFECTIVE-DATE
        creditText &= String.Format("{0:000}", item.TaxInfos.Count) 'Tax Info Count
        creditText &= String.Format("{0,-16}", item.RefCode).Substring(0, 16) 'Bene. Ref #
        creditText &= Space(50) 'Attachment Sub-file
        creditText &= "F" 'Advice Mode (F = fax)
        creditText &= String.Format("{0,-50}", SetDigitOnly(item.PayeeFax)) 'Fax No.
        creditText &= Space(50) 'Email ID
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemBfVatString, ",", ""))) 'Total Inv Amt bef VAT (10.2)
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemWHtString, ",", ""))) 'Total Tax deducted Amt (10.2)
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemAfVatString, ",", ""))) 'Total Inv Amt after VAT (10.2)
        creditText &= String.Format("{0,-10}", item.PayeeTaxID) 'Payee Tax Id
        creditText &= String.Format("{0,-13}", item.PersonalID).Substring(0, 13) 'Personal Id
        creditText &= Space(30) 'Payee Address 1
        creditText &= Space(30) 'Payee Address 2
        creditText &= Space(30) 'Payee Address 3
        creditText &= Space(30) 'Payee Address 4

        writer.WriteLine(creditText)

        Dim j As Integer = 1
        For Each taxi As TaxInfo In item.TaxInfos
          For Each ti As TaxInfoItem In taxi.TaxInfoItems
            Dim tiAmountString As String = Configuration.FormatToString(ti.TaxRate, 2)
            Dim tiBfVatString As String = Configuration.FormatToString(ti.BeforeVAT, 2)
            Dim tiWHtString As String = Configuration.FormatToString(ti.WHT, 2)
            Dim tiAfVatString As String = Configuration.FormatToString(ti.AfterVat, 2)

            Dim taxDetail As String = ""
            taxDetail &= "T" 'Part Identifier
            taxDetail &= taxi.TaxForm 'Tax Form
            taxDetail &= String.Format("{0,-10}", j) 'Tax Seq.#
            taxDetail &= String.Format("{0:000.00}", CDbl(Replace(tiAmountString, ",", ""))) 'Tax rate (3.2)
            taxDetail &= String.Format("{0,-40}", ti.Description).Substring(0, 40)   'Type of tax deducted
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiBfVatString, ",", ""))) 'Inv Amt bef VAT (10.2)
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiWHtString, ",", ""))) 'Tax deducted Amt (10.2)
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiAfVatString, ",", ""))) 'Inv Amt after VAT (10.2)
            taxDetail &= taxi.TaxCondition 'Tax Condition
            writer.WriteLine(taxDetail)
          Next

          j += 1
        Next

        i += 1
      Next
    End Sub
    Private Shared Sub ExportCOC(ByVal c As IExportable, ByVal t As String, ByVal writer As TextWriter)
      Dim theItemList As List(Of PaymentForList) = c.PaymentList 'GetGroupedList(c.PaymentList, t)
      Dim amtString As String = Configuration.FormatToString(c.Amount, 2)

      Dim culture As New CultureInfo("en-US", True)

      Dim effectiveDate As Date = c.DueDate
      If theItemList IsNot Nothing AndAlso theItemList.Count > 0 Then
        effectiveDate = theItemList(0).RefDueDate
      End If
      Dim pickupDate As Date = c.DueDate

      Dim exportTime As Date = Date.Now
      Dim header As String = ""
      header &= "H" 'Part Identifier
      header &= "COC" 'Payment Type
      header &= String.Format("{0,-10}", c.BankAccount.BankCode.Replace("-", "")) 'Debit A/C No.
      header &= Space(16) 'Batch Ref.#
      header &= exportTime.ToString("dd-MM-yyyy", culture) 'Effective Date
      header &= pickupDate.ToString("dd-MM-yyyy", culture) 'Pickup Date
      header &= Space(5) 'Customer Branch #
      header &= String.Format("{0:000000000000000000}", theItemList.Count)  'Total Credit Items
      header &= String.Format("{0:000000000000000.00}", CDbl(Replace(amtString, ",", ""))) 'Total Debit Amount
      header &= "N" 'Charges for A/C Of.

      writer.WriteLine(header)

      Dim i As Integer = 1
      For Each item As PaymentForList In theItemList
        Dim bi As BankInfo = GetBankInfo(item.KbankMCBank, item.KbankMCAccount)
        Dim itemBankCode As String = bi.BankCode
        Dim itemBankName As String = bi.BankName
        Dim itemBankBranchCode As String = bi.BankBranchCode
        Dim itemBankBranchName As String = ""
        Dim itemAccount As String = bi.BankAccountCode

        Dim itemAmountString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemBfVatString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemWHtString As String = Configuration.FormatToString(item.Amount, 2)
        Dim itemAfVatString As String = Configuration.FormatToString(item.Amount, 2)

        Dim creditText As String = ""
        creditText &= "D" 'Part Identifier
        creditText &= String.Format("{0,-10}", i) 'Txn. Reference No.
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemAmountString, ",", ""))) 'Amount
        creditText &= String.Format("{0,-120}", item.PayeeName).Substring(0, 120) 'Payee
        creditText &= Space(30) 'Payee Address 1
        creditText &= Space(30) 'Payee Address 2
        creditText &= Space(30) 'Payee Address 3
        creditText &= Space(30) 'Payee Address 4
        creditText &= String.Format("{0,-10}", item.PayeeTaxID) 'Tax Id
        creditText &= String.Format("{0,-13}", item.PersonalID).Substring(0, 13) 'Personal Id
        creditText &= String.Format("{0,-16}", item.RefCode).Substring(0, 16) 'Bene. Ref #
        creditText &= Space(255) 'Details
        creditText &= item.DeliveryMethod 'Delivery Method
        creditText &= String.Format("{0,-4}", item.PickupLocation).Substring(0, 4) 'Pickup Location Code
        creditText &= String.Format("{0,-24}", item.PickupDocument).Substring(0, 24) 'Document for Pickup
        creditText &= Space(50) 'Attachment Sub-file
        creditText &= "F" 'Advice Mode (F = fax)
        creditText &= String.Format("{0,-50}", SetDigitOnly(item.PayeeFax)) 'Fax No.
        creditText &= Space(50) 'Email ID
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemBfVatString, ",", ""))) 'Total Inv Amt bef VAT (10.2)
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemWHtString, ",", ""))) 'Total Tax deducted Amt (10.2)
        creditText &= String.Format("{0:0000000000.00}", CDbl(Replace(itemAfVatString, ",", ""))) 'Total Inv Amt after VAT (10.2)
        creditText &= String.Format("{0:000}", item.TaxInfos.Count) 'Tax Info Count
        writer.WriteLine(creditText)

        Dim j As Integer = 1
        For Each taxi As TaxInfo In item.TaxInfos
          For Each ti As TaxInfoItem In taxi.TaxInfoItems
            Dim tiAmountString As String = Configuration.FormatToString(ti.TaxRate, 2)
            Dim tiBfVatString As String = Configuration.FormatToString(ti.BeforeVAT, 2)
            Dim tiWHtString As String = Configuration.FormatToString(ti.WHT, 2)
            Dim tiAfVatString As String = Configuration.FormatToString(ti.AfterVat, 2)

            Dim taxDetail As String = ""
            taxDetail &= "T" 'Part Identifier
            taxDetail &= taxi.TaxForm 'Tax Form
            taxDetail &= String.Format("{0,-10}", j) 'Tax Seq.#
            taxDetail &= String.Format("{0:000.00}", CDbl(Replace(tiAmountString, ",", ""))) 'Tax rate (3.2)
            taxDetail &= String.Format("{0,-40}", ti.Description).Substring(0, 40)   'Type of tax deducted
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiBfVatString, ",", ""))) 'Inv Amt bef VAT (10.2)
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiWHtString, ",", ""))) 'Tax deducted Amt (10.2)
            taxDetail &= String.Format("{0:0000000000.00}", CDbl(Replace(tiAfVatString, ",", ""))) 'Inv Amt after VAT (10.2)
            taxDetail &= taxi.TaxCondition 'Tax Condition
            writer.WriteLine(taxDetail)
          Next

          j += 1
        Next

        i += 1
      Next
    End Sub
    Private Shared Sub ExportCOC(ByVal c As ICOCExportable, ByVal t As String, ByVal writer As TextWriter)

      Dim CqReceiveList As List(Of ChequeReceiver) = c.ChequeReceiverList

      Dim DebitAmount As Decimal = 0
      For Each cqritem As ChequeReceiver In CqReceiveList
        DebitAmount += cqritem.Amount
      Next

      Dim culture As New CultureInfo("en-US", True)


      Dim header As String = ""
      header &= "H" 'Part Identifier
      header &= "COC" 'Payment Type
      header &= String.Format("{0,-10}", c.BankAccount.BankCode.Replace("-", "")) 'Debit A/C No.
      header &= Space(16) 'Batch Ref.#
      header &= c.EffectiveDate.ToString("dd-MM-yyyy", culture) 'Effective Date
      header &= c.PickUpDate.ToString("dd-MM-yyyy", culture) 'Pickup Date
      header &= Space(5) 'Customer Branch #
      header &= String.Format("{0:000000000000000000}", CqReceiveList.Count)  'Total Credit Items
      header &= String.Format("{0:000000000000000.00}", DebitAmount) 'Total Debit Amount
      header &= c.Chargee 'Charges for A/C Of.

      writer.WriteLine(header)

      For Each cqritem As ChequeReceiver In CqReceiveList
        Dim creditText As String = ""
        creditText &= "D" 'Part Identifier
        creditText &= String.Format("{0,-10}", cqritem.TnxReferenceNo).Substring(cqritem.TnxReferenceNo.Length - 10, 10) 'Txn. Reference No.poj
        creditText &= String.Format("{0:0000000000.00}", cqritem.Amount) 'Amount
        creditText &= String.Format("{0,-120}", cqritem.Payee).Substring(0, 120) 'Payee
        creditText &= String.Format("{0,-30}", cqritem.PayeeAddress1).Substring(0, 30) 'Payee Address 1
        creditText &= String.Format("{0,-30}", cqritem.PayeeAddress2).Substring(0, 30) 'Payee Address 2
        creditText &= String.Format("{0,-30}", cqritem.PayeeAddress3).Substring(0, 30) 'Payee Address 3
        creditText &= String.Format("{0,-30}", cqritem.PayeeAddress4).Substring(0, 30) 'Payee Address 4
        creditText &= String.Format("{0,-10}", cqritem.TaxID) 'Tax Id
        creditText &= String.Format("{0,-13}", cqritem.PersonalID).Substring(0, 13) 'Personal Id
        creditText &= String.Format("{0,-16}", cqritem.BeneRef).Substring(0, 16) 'Bene. Ref #
        creditText &= String.Format("{0,-255}", cqritem.Detail).Substring(0, 255) 'Details
        creditText &= cqritem.DeliveryMethod 'Delivery Method
        creditText &= String.Format("{0,-4}", cqritem.PickupLocationCode).Substring(0, 4) 'Pickup Location Code
        creditText &= String.Format("{0,-24}", cqritem.DocumentForPickup).Substring(0, 24) 'Document for Pickup
        creditText &= String.Format("{0,-50}", cqritem.AttachmentSubfile).Substring(0, 50) 'Attachment Sub-file
        creditText &= cqritem.AdviceMode 'Advice Mode (F = fax)
        creditText &= String.Format("{0,-50}", SetDigitOnly(cqritem.FaxNo)) 'Fax No.
        creditText &= String.Format("{0,-50}", cqritem.EmailID).Substring(0, 50) 'Email ID
        creditText &= String.Format("{0:0000000000.00}", cqritem.TotalInvAmtBefVAT) 'Total Inv Amt bef VAT (10.2)
        creditText &= String.Format("{0:0000000000.00}", cqritem.TotalTaxDeductedAmt) 'Total Tax deducted Amt (10.2)
        creditText &= String.Format("{0:0000000000.00}", cqritem.TotalInvAmtAfterVAT) 'Total Inv Amt after VAT (10.2)
        creditText &= String.Format("{0:000}", cqritem.ChequePaymentVatList.Count) 'Tax Info Count

        writer.WriteLine(creditText)

        Dim taxIndex As Integer = 1
        For Each cqrVatitem As ChequePaymentVat In cqritem.ChequePaymentVatList
          Dim taxDetail As String = ""
          taxDetail &= "T" 'Part Identifier
          taxDetail &= cqrVatitem.TaxForm 'Tax Form
          taxDetail &= String.Format("{0,-10}", taxIndex) 'Tax Seq.#
          taxDetail &= String.Format("{0:000.00}", cqrVatitem.TaxRate) 'Tax rate (3.2)
          taxDetail &= String.Format("{0,-40}", cqrVatitem.TypeofTaxDeducted).Substring(0, 40) 'Type of tax deducted
          taxDetail &= String.Format("{0:0000000000.00}", cqrVatitem.InvAmtBefVAT) 'Inv Amt bef VAT (10.2)
          taxDetail &= String.Format("{0:0000000000.00}", cqrVatitem.TaxDeductedAmt) 'Tax deducted Amt (10.2)
          taxDetail &= String.Format("{0:0000000000.00}", cqrVatitem.InvAmtAfterVAT) 'Inv Amt after VAT (10.2)
          taxDetail &= cqrVatitem.TaxCondition 'Tax Condition

          writer.WriteLine(taxDetail)

          taxIndex += 1
        Next

        For Each cqpayitem As ChequePayment In cqritem.ChequePaymentList
          Dim invoiceText As String = ""
          invoiceText &= "I" 'Part Identifier
          invoiceText &= String.Format("{0,-30}", cqpayitem.PaymentNo).Substring(0, 30) 'Payment No.
          invoiceText &= String.Format("{0,-15}", cqpayitem.BankReference).Substring(0, 15) 'Bank Reference
          invoiceText &= String.Format("{0,-15}", cqpayitem.CustomerReference).Substring(0, 15) 'Customer Reference
          invoiceText &= String.Format("{0,-20}", cqpayitem.InvoiceNumber).Substring(0, 20) 'Invoice Number
          invoiceText &= String.Format("{0:0000000000000.00}", cqpayitem.InvoiceAmount).Replace(".", "") 'Invoice Amount
          invoiceText &= cqpayitem.InvoiceDate.ToString("ddMMyyyy", culture) 'Invoice Date
          invoiceText &= String.Format("{0,-15}", cqpayitem.CreditNoteNo).Substring(0, 15) 'Credit Note No.
          invoiceText &= String.Format("{0:0000000000000.00}", cqpayitem.CreditNoteAmount).Replace(".", "") 'Credit Note Amount
          invoiceText &= String.Format("{0,-15}", cqpayitem.DebitNoteNo).Substring(0, 15) 'Debit Note No.
          invoiceText &= String.Format("{0:0000000000000.00}", cqpayitem.DebitNoteAmount).Replace(".", "") 'Debit Note Amount
          invoiceText &= String.Format("{0:0000000000000.00}", cqpayitem.GrossAmount).Replace(".", "") 'Gross Amount
          invoiceText &= String.Format("{0:0000000000000.00}", cqpayitem.VATAmount).Replace(".", "") 'VAT Amount
          invoiceText &= String.Format("{0:0000000000000.00}", cqpayitem.WHTAmount).Replace(".", "") 'WHT Amount
          invoiceText &= String.Format("{0:0000000000000.00}", cqpayitem.NetAmount).Replace(".", "") 'Net Amount
          invoiceText &= String.Format("{0,-15}", cqpayitem.StatementNo).Substring(0, 15) 'Statement No.
          invoiceText &= String.Format("{0,-2}", cqpayitem.StatusInv) 'Status(Inv).
          invoiceText &= String.Format("{0,-2}", cqpayitem.StatusInv) 'Status(Inv).
          invoiceText &= String.Format("{0,-2}", cqpayitem.TransactionType) 'Transaction Type
          invoiceText &= String.Format("{0,-40}", cqpayitem.ReferenceNo1).Substring(0, 40) 'Reference No. 1
          invoiceText &= String.Format("{0,-40}", cqpayitem.ReferenceNo2).Substring(0, 40) 'Reference No. 2
          invoiceText &= String.Format("{0,-40}", cqpayitem.ReferenceNo3).Substring(0, 40) 'Reference No. 3
          invoiceText &= String.Format("{0,-40}", cqpayitem.ReferenceNo4).Substring(0, 40) 'Reference No. 4
          invoiceText &= String.Format("{0,-100}", cqpayitem.Filler).Substring(0, 100) 'Filler

          writer.WriteLine(invoiceText)

        Next

      Next

    End Sub
    Public Shared Function SetDigitOnly(ByVal val As String) As String
      Dim dg As String = val
      dg = dg.Replace(" ", "")
      dg = dg.Replace("(", "")
      dg = dg.Replace(")", "")
      dg = dg.Replace("-", "")
      Return dg
    End Function
    Private Shared Function ItemEqualKbankMCL(ByVal i1 As PaymentForList, ByVal i2 As PaymentForList) As Boolean
      If i1.KbankMCBank <> i2.KbankMCBank Then
        Return False
      End If
      If i1.KbankMCAccount <> i2.KbankMCAccount Then
        Return False
      End If
      If i1.PayeeName <> i2.PayeeName Then
        Return False
      End If
      Return True
    End Function
    Private Shared Function ItemEqualKbankDCT(ByVal i1 As PaymentForList, ByVal i2 As PaymentForList) As Boolean
      If i1.KbankDCBank <> i2.KbankDCBank Then
        Return False
      End If
      If i1.KbankDCAccount <> i2.KbankDCAccount Then
        Return False
      End If
      If i1.PayeeName <> i2.PayeeName Then
        Return False
      End If
      Return True
    End Function
    Private Shared Function GetGroupedList(ByVal list As List(Of PaymentForList), ByVal t As String) As List(Of PaymentForList)
      Dim exportList As New List(Of PaymentForList)
      Select Case t.ToLower
        Case "mcl"
          'Sort
          Dim sorted As New List(Of PaymentForList)
          Dim itemList As New List(Of PaymentForList)
          For Each item As PaymentForList In list
            If Not sorted.Contains(item) Then
              For Each innerItem As PaymentForList In list
                If Not sorted.Contains(innerItem) AndAlso ItemEqualKbankMCL(item, innerItem) Then
                  Dim theItem As New PaymentForList
                  theItem.KbankMCBank = innerItem.KbankMCBank
                  theItem.KbankMCAccount = innerItem.KbankMCAccount
                  theItem.RefCode = ""
                  theItem.PayeeName = innerItem.PayeeName
                  theItem.Amount += innerItem.Amount
                  itemList.Add(theItem)
                  sorted.Add(innerItem)
                End If
              Next
            End If
          Next

          Dim currentItem As New PaymentForList
          For Each item As PaymentForList In itemList
            If Not ItemEqualKbankMCL(currentItem, item) OrElse item.Amount > 3000000 OrElse currentItem.Amount + item.Amount > 3000000 Then
              Dim currentAmount As Decimal = item.Amount
              While currentAmount > 3000000
                currentItem = New PaymentForList
                currentItem.KbankMCBank = item.KbankMCBank
                currentItem.KbankMCAccount = item.KbankMCAccount
                currentItem.RefCode = ""
                currentItem.PayeeName = item.PayeeName
                currentItem.Amount += 3000000
                currentItem.BankName = item.KbankMCBank
                exportList.Add(currentItem)
                currentAmount -= 3000000
              End While
              currentItem = New PaymentForList
              currentItem.KbankMCBank = item.KbankMCBank
              currentItem.KbankMCAccount = item.KbankMCAccount
              currentItem.RefCode = ""
              currentItem.PayeeName = item.PayeeName
              currentItem.Amount += currentAmount
              currentItem.BankName = item.KbankMCBank
              exportList.Add(currentItem)
            Else
              currentItem.Amount += item.Amount
            End If
          Next
        Case "dct", "pct"
          'Sort
          Dim sorted As New List(Of PaymentForList)
          Dim itemList As New List(Of PaymentForList)
          For Each item As PaymentForList In list
            If Not sorted.Contains(item) Then
              For Each innerItem As PaymentForList In list
                If Not sorted.Contains(innerItem) AndAlso ItemEqualKbankDCT(item, innerItem) Then
                  Dim theItem As New PaymentForList
                  theItem.KbankDCBank = innerItem.KbankDCBank
                  theItem.KbankDCAccount = innerItem.KbankDCAccount
                  theItem.RefCode = ""
                  theItem.PayeeName = innerItem.PayeeName
                  theItem.Amount += innerItem.Amount
                  itemList.Add(theItem)
                  sorted.Add(innerItem)
                End If
              Next
            End If
          Next

          Dim currentItem As New PaymentForList
          For Each item As PaymentForList In itemList
            If Not ItemEqualKbankDCT(currentItem, item) OrElse item.Amount > 3000000 OrElse currentItem.Amount + item.Amount > 3000000 Then
              Dim currentAmount As Decimal = item.Amount
              While currentAmount > 3000000
                currentItem = New PaymentForList
                currentItem.KbankDCBank = item.KbankDCBank
                currentItem.KbankDCAccount = item.KbankDCAccount
                currentItem.RefCode = ""
                currentItem.PayeeName = item.PayeeName
                currentItem.Amount += 3000000
                currentItem.BankName = item.KbankDCBank
                exportList.Add(currentItem)
                currentAmount -= 3000000
              End While
              currentItem = New PaymentForList
              currentItem.KbankDCBank = item.KbankDCBank
              currentItem.KbankDCAccount = item.KbankDCAccount
              currentItem.RefCode = ""
              currentItem.PayeeName = item.PayeeName
              currentItem.Amount += currentAmount
              currentItem.BankName = item.KbankDCBank
              exportList.Add(currentItem)
            Else
              currentItem.Amount += item.Amount
            End If
          Next
      End Select
      Return exportList
    End Function
    Public Shared Sub ExportPaymentTrack(ByVal p As IPaymentTrackExportable, ByVal writer As TextWriter)
      Dim culture As New CultureInfo("en-US", True)

      Dim effectiveDate As Date = Date.MinValue
      If TypeOf p Is ExportOutgoingCheck Then
        effectiveDate = CType(p, ExportOutgoingCheck).EffectiveDate
      End If

      Dim header As String = ""
      header &= "H".Pipe
      header &= p.PayerBuilkID.Pipe
      header &= p.PaymentTrackID.Pipe
      header &= p.PaymentTrackStatus.Pipe
      header &= p.CheckQty.ToString.Pipe
      header &= p.CheckAmount.ToString("####.00").Pipe
      writer.WriteLine(header)

      For Each check As PaymentTrackCheckDetail In p.PaymenTrackCheckDetailList
        Dim checkText As String = ""
        checkText &= "C".Pipe
        checkText &= check.CheckID.Pipe
        checkText &= check.CheckCode.Pipe
        checkText &= check.PayeeBuilkId.Pipe
        checkText &= check.CheckDescription.Pipe
        If effectiveDate = Date.MinValue Then
          checkText &= check.CheckIssueDate.Pipe
        Else
          checkText &= effectiveDate.ToShortDateString.Pipe
        End If
        checkText &= check.CheckAmount.Pipe
        checkText &= check.BeforeTax.Pipe
        checkText &= check.WitholdingTax.Pipe
        checkText &= check.AfterTax.Pipe
        checkText &= check.DocForReceive.Pipe
        checkText &= check.ReceiveAddress.Pipe
        checkText &= check.ReceiveMethod.Pipe
        checkText &= check.CheckRemark.Pipe
        checkText &= check.Added.Pipe
        checkText &= check.Subtract.Pipe
        checkText &= check.BillNoteQty.ToString.Pipe
        checkText &= check.BillNoteAmout.ToString.Pipe
        checkText &= check.DocQty.ToString.Pipe
        checkText &= check.DocAmount.ToString.Pipe
        writer.WriteLine(checkText)

        For Each bill As PaymentTrackBillNoteDetail In check.PaymentTrackBillNoteDetailList
          Dim billText As String = ""
          billText &= "B".Pipe
          billText &= bill.CheckID.Pipe
          billText &= bill.BillID.Pipe
          billText &= bill.BillNoteCode.Pipe
          billText &= bill.BillNoteDate.Pipe
          billText &= bill.Amount.Pipe
          billText &= bill.TotalAmount.Pipe
          billText &= bill.Added.Pipe
          billText &= bill.Subtract.Pipe
          billText &= bill.Remarks.Pipe
          billText &= bill.DocQty.ToString.Pipe
          billText &= bill.DocAmount.ToString.Pipe
          writer.WriteLine(billText)

          For Each doc As PaymentTrackDocDetail In bill.PaymentTrackDocDetailList
            Dim billDocText As String = ""
            billDocText &= "D".Pipe
            billDocText &= doc.CheckID.Pipe
            billDocText &= doc.BillID.Pipe
            billDocText &= doc.DocumentType.Pipe
            billDocText &= doc.DocumentCode.Pipe
            billDocText &= doc.DocumentDate.Pipe
            billDocText &= doc.Amount.Pipe
            billDocText &= doc.TotalAmount.Pipe
            billDocText &= doc.Added.Pipe
            billDocText &= doc.Subtract.Pipe
            billDocText &= doc.ReferenceDocument.Pipe
            writer.WriteLine(billDocText)
          Next
        Next

        For Each doc As PaymentTrackDocDetail In check.PaymentTrackDocDetailList
          Dim docText As String = ""
          docText &= "D".Pipe
          docText &= doc.CheckID.Pipe
          docText &= doc.BillID.Pipe
          docText &= doc.DocumentType.Pipe
          docText &= doc.DocumentCode.Pipe
          docText &= doc.DocumentDate.Pipe
          docText &= doc.Amount.Pipe
          docText &= doc.TotalAmount.Pipe
          docText &= doc.Added.Pipe
          docText &= doc.Subtract.Pipe
          docText &= doc.ReferenceDocument.Pipe
          writer.WriteLine(docText)
        Next
      Next

    End Sub
    Public Shared Sub ExportPaymentTrack(ByVal p As IPaymentTrackExportable, ByRef writer As String)
      Dim culture As New CultureInfo("en-US", True)

      Dim effectiveDate As Date = Date.MinValue
      If TypeOf p Is ExportOutgoingCheck Then
        effectiveDate = CType(p, ExportOutgoingCheck).EffectiveDate
      End If

      Dim header As String = ""
      header &= "H".Pipe
      header &= p.PayerBuilkID.Pipe
      header &= p.PaymentTrackID.Pipe
      header &= p.PaymentTrackStatus.Pipe
      header &= p.CheckQty.ToString.Pipe
      header &= p.CheckAmount.ToString("####.00").Pipe
      writer += header & "{newline}"

      For Each check As PaymentTrackCheckDetail In p.PaymenTrackCheckDetailList
        Dim checkText As String = ""
        checkText &= "C".Pipe
        checkText &= check.CheckID.Pipe
        checkText &= check.CheckCode.Pipe
        checkText &= check.PayeeBuilkId.Pipe
        checkText &= check.CheckDescription.Pipe
        If effectiveDate = Date.MinValue Then
          checkText &= check.CheckIssueDate.Pipe
        Else
          checkText &= effectiveDate.ToShortDateString.Pipe
        End If
        checkText &= check.CheckAmount.Pipe
        checkText &= check.BeforeTax.Pipe
        checkText &= check.WitholdingTax.Pipe
        checkText &= check.AfterTax.Pipe
        checkText &= check.DocForReceive.Pipe
        checkText &= check.ReceiveAddress.Pipe
        checkText &= check.ReceiveMethod.Pipe
        checkText &= check.CheckRemark.Pipe
        checkText &= check.Added.Pipe
        checkText &= check.Subtract.Pipe
        checkText &= check.BillNoteQty.ToString.Pipe
        checkText &= check.BillNoteAmout.ToString.Pipe
        checkText &= check.DocQty.ToString.Pipe
        checkText &= check.DocAmount.ToString.Pipe
        writer += checkText & "{newline}"

        For Each bill As PaymentTrackBillNoteDetail In check.PaymentTrackBillNoteDetailList
          Dim billText As String = ""
          billText &= "B".Pipe
          billText &= bill.CheckID.Pipe
          billText &= bill.BillID.Pipe
          billText &= bill.BillNoteCode.Pipe
          billText &= bill.BillNoteDate.Pipe
          billText &= bill.Amount.Pipe
          billText &= bill.TotalAmount.Pipe
          billText &= bill.Added.Pipe
          billText &= bill.Subtract.Pipe
          billText &= bill.Remarks.Pipe
          billText &= bill.DocQty.ToString.Pipe
          billText &= bill.DocAmount.ToString.Pipe
          writer += billText & "{newline}"

          For Each doc As PaymentTrackDocDetail In bill.PaymentTrackDocDetailList
            Dim billDocText As String = ""
            billDocText &= "D".Pipe
            billDocText &= doc.CheckID.Pipe
            billDocText &= doc.BillID.Pipe
            billDocText &= doc.DocumentType.Pipe
            billDocText &= doc.DocumentCode.Pipe
            billDocText &= doc.DocumentDate.Pipe
            billDocText &= doc.Amount.Pipe
            billDocText &= doc.TotalAmount.Pipe
            billDocText &= doc.Added.Pipe
            billDocText &= doc.Subtract.Pipe
            billDocText &= doc.ReferenceDocument.Pipe
            writer += billDocText & "{newline}"
          Next
        Next

        For Each doc As PaymentTrackDocDetail In check.PaymentTrackDocDetailList
          Dim docText As String = ""
          docText &= "D".Pipe
          docText &= doc.CheckID.Pipe
          docText &= doc.BillID.Pipe
          docText &= doc.DocumentType.Pipe
          docText &= doc.DocumentCode.Pipe
          docText &= doc.DocumentDate.Pipe
          docText &= doc.Amount.Pipe
          docText &= doc.TotalAmount.Pipe
          docText &= doc.Added.Pipe
          docText &= doc.Subtract.Pipe
          docText &= doc.ReferenceDocument.Pipe
          writer += docText & "{newline}"
        Next
      Next

    End Sub

  End Class
  Public Class ChequeReceiver
#Region "Construct"
    Public Sub New()
      ChequePaymentVatList = New List(Of ChequePaymentVat)
      ChequePaymentList = New List(Of ChequePayment)
    End Sub
#End Region

#Region "Properties"
    Public Property PartIdentifier As String
    Public Property TnxReferenceNo As String
    Public Property Amount As Decimal
    Public Property Payee As String
    Public Property PayeeAddress1 As String
    Public Property PayeeAddress2 As String
    Public Property PayeeAddress3 As String
    Public Property PayeeAddress4 As String
    Public Property TaxID As String
    Public Property PersonalID As String
    Public Property BeneRef As String
    Public Property Detail As String
    Public Property DeliveryMethod As String
    Public Property PickupLocationCode As String
    Public Property DocumentForPickup As String
    Public Property AttachmentSubfile As String
    Public Property AdviceMode As String
    Public Property FaxNo As String
    Public Property EmailID As String
    Public Property TotalInvAmtBefVAT As Decimal
    Public Property TotalTaxDeductedAmt As Decimal
    Public Property TotalInvAmtAfterVAT As Decimal
    Public Property TaxInfoCount As Integer
    Public Property ChequePaymentVatList As List(Of ChequePaymentVat)
    Public Property ChequePaymentList As List(Of ChequePayment)
#End Region
  End Class
  Public Class ChequePayment
#Region "Properties"
    Public Property PartIdentifier As String
    Public Property PaymentNo As String
    Public Property BankReference As String
    Public Property CustomerReference As String
    Public Property InvoiceNumber As String
    Public Property InvoiceAmount As Decimal
    Public Property InvoiceDate As Date
    Public Property CreditNoteNo As String
    Public Property CreditNoteAmount As Decimal
    Public Property DebitNoteNo As String
    Public Property DebitNoteAmount As Decimal
    Public Property GrossAmount As Decimal
    Public Property VATAmount As Decimal
    Public Property WHTAmount As Decimal
    Public Property NetAmount As Decimal
    Public Property StatementNo As String
    Public Property StatusInv As String
    Public Property TransactionType As String
    Public Property ReferenceNo1 As String
    Public Property ReferenceNo2 As String
    Public Property ReferenceNo3 As String
    Public Property ReferenceNo4 As String
    Public Property Filler As String
#End Region
  End Class
  Public Class ChequePaymentVat
#Region "Properties"
    Public Property PartIdentifier As String
    Public Property TaxForm As String
    Public Property TaxSeq As String
    Public Property TaxRate As Decimal
    Public Property TypeofTaxDeducted As String
    Public Property InvAmtBefVAT As Decimal
    Public Property TaxDeductedAmt As Decimal
    Public Property InvAmtAfterVAT As Decimal
    Public Property TaxCondition As String
#End Region
  End Class

  Public Class PaymentTrackCheckDetail
    Public Property CheckID As String
    Public Property CheckCode As String
    Public Property PayeeBuilkId As String
    Public Property CheckDescription As String
    Public Property CheckIssueDate As String
    Public Property CheckAmount As String
    Public Property BeforeTax As String
    Public Property WitholdingTax As String
    Public Property AfterTax As String
    Public Property DocForReceive As String
    Public Property ReceiveAddress As String
    Public Property ReceiveMethod As String
    Public Property CheckRemark As String
    Public Property Added As String
    Public Property Subtract As String
    Private m_PaymentTrackBillNoteDetailList As List(Of PaymentTrackBillNoteDetail)
    Public Property PaymentTrackBillNoteDetailList As List(Of PaymentTrackBillNoteDetail)
      Get
        If m_PaymentTrackBillNoteDetailList Is Nothing Then
          m_PaymentTrackBillNoteDetailList = New List(Of PaymentTrackBillNoteDetail)
        End If
        Return m_PaymentTrackBillNoteDetailList
      End Get
      Set(ByVal value As List(Of PaymentTrackBillNoteDetail))
        m_PaymentTrackBillNoteDetailList = value
      End Set
    End Property
    Dim m_PaymentTrackDocDetailList As List(Of PaymentTrackDocDetail)
    Public Property PaymentTrackDocDetailList As List(Of PaymentTrackDocDetail)
      Get
        If m_PaymentTrackDocDetailList Is Nothing Then
          m_PaymentTrackDocDetailList = New List(Of PaymentTrackDocDetail)
        End If
        Return m_PaymentTrackDocDetailList
      End Get
      Set(ByVal value As List(Of PaymentTrackDocDetail))
        m_PaymentTrackDocDetailList = value
      End Set
    End Property
    Public ReadOnly Property BillNoteQty As Integer
      Get
        If m_PaymentTrackBillNoteDetailList Is Nothing Then
          m_PaymentTrackBillNoteDetailList = New List(Of PaymentTrackBillNoteDetail)
        End If
        Return m_PaymentTrackBillNoteDetailList.Count
      End Get
    End Property
    Public ReadOnly Property BillNoteAmout As Decimal
      Get
        Dim amt As Decimal = 0
        If m_PaymentTrackBillNoteDetailList Is Nothing Then
          m_PaymentTrackBillNoteDetailList = New List(Of PaymentTrackBillNoteDetail)
        End If
        For Each b As PaymentTrackBillNoteDetail In m_PaymentTrackBillNoteDetailList
          If b.Amount.Length > 0 Then
            amt += CDec(b.Amount)
          End If
        Next
        Return amt
      End Get
    End Property
    Public ReadOnly Property DocQty As Integer
      Get
        If m_PaymentTrackDocDetailList Is Nothing Then
          m_PaymentTrackDocDetailList = New List(Of PaymentTrackDocDetail)
        End If
        Return m_PaymentTrackDocDetailList.Count
      End Get
    End Property
    Public ReadOnly Property DocAmount As Decimal
      Get
        Dim amt As Decimal = 0
        If m_PaymentTrackDocDetailList Is Nothing Then
          m_PaymentTrackDocDetailList = New List(Of PaymentTrackDocDetail)
        End If
        For Each p As PaymentTrackDocDetail In m_PaymentTrackDocDetailList
          If p.Amount.Length > 0 Then
            amt += CDec(p.Amount)
          End If
        Next
        Return amt
      End Get
    End Property
  End Class

  Public Class PaymentTrackBillNoteDetail
    Public Property CheckID As String
    Public Property BillID As String
    Public Property BillNoteCode As String
    Public Property BillNoteDate As String
    Public Property Amount As String
    Public Property TotalAmount As String
    Public Property Added As String
    Public Property Subtract As String
    Public Property Remarks As String
    Dim m_PaymentTrackDocDetailList As List(Of PaymentTrackDocDetail)
    Public Property PaymentTrackDocDetailList As List(Of PaymentTrackDocDetail)
      Get
        If m_PaymentTrackDocDetailList Is Nothing Then
          m_PaymentTrackDocDetailList = New List(Of PaymentTrackDocDetail)
        End If
        Return m_PaymentTrackDocDetailList
      End Get
      Set(ByVal value As List(Of PaymentTrackDocDetail))
        m_PaymentTrackDocDetailList = value
      End Set
    End Property
    Public ReadOnly Property DocQty As Integer
      Get
        If m_PaymentTrackDocDetailList Is Nothing Then
          m_PaymentTrackDocDetailList = New List(Of PaymentTrackDocDetail)
        End If
        Return m_PaymentTrackDocDetailList.Count
      End Get
    End Property
    Public ReadOnly Property DocAmount As Decimal
      Get
        Dim amt As Decimal = 0
        If m_PaymentTrackDocDetailList Is Nothing Then
          m_PaymentTrackDocDetailList = New List(Of PaymentTrackDocDetail)
        End If
        For Each p As PaymentTrackDocDetail In m_PaymentTrackDocDetailList
          If p.Amount.Length > 0 Then
            amt += CDec(p.Amount)
          End If
        Next
        Return amt
      End Get
    End Property
  End Class

  Public Class PaymentTrackDocDetail
    Public Property CheckID As String
    Public Property BillID As String
    Public Property DocumentType As String
    Public Property DocumentCode As String
    Public Property DocumentDate As String
    Public Property Amount As String
    Public Property TotalAmount As String
    Public Property Added As String
    Public Property Subtract As String
    Public Property ReferenceDocument As String
  End Class
  Module StringExtensions

    '<Extension()>
    'Public Function SPACE(ByVal stringVar As String, ByVal length As Integer) As String
    '  Dim var As String = Trim(stringVar)
    '  Dim stringLen As String = "{0,-" & length.ToString & "}"
    '  var = Exporter.SetDigitOnly(stringVar)
    '  Return String.Format(stringLen, var)
    'End Function
    <Extension()>
    Public Function Pipe(ByVal stringVar As String) As String
      Dim var As String = Trim(stringVar)
      Return var & "|"
    End Function
    <Extension()>
    Public Function Colon(ByVal stringVar As String) As String
      Dim var As String = Trim(stringVar)
      Return var & ":"
    End Function
    <Extension()>
    Public Function Semicolon(ByVal stringVar As String) As String
      Dim var As String = Trim(stringVar)
      Return var & ";"
    End Function
  End Module
End Namespace
