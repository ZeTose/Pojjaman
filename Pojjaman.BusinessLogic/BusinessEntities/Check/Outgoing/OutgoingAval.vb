Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class OutgoingAval
    Inherits SimpleBusinessEntityBase
    Implements IPaymentItem, IPrintableEntity, IHasIBillablePerson, ICheckPeriod


#Region "Members"
    Private m_cqcode As String
    Private m_issueDate As Date
    Private m_dueDate As Date
    Private m_supplier As Supplier
    Private m_recipient As String
    Private m_Loan As Loan

    Private m_amount As Decimal
    Private m_bankcharge As Decimal
    Private m_wht As Decimal

    Private m_note As String
    Private m_receivingEntity As SimpleBusinessEntityBase

    Private m_docStatus As OutgoingCheckDocStatus 'สถานะเช็คจ่าย
    Private m_itemTable As TreeTable

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
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()

      Me.m_Loan = New Loan
      Me.m_supplier = New Supplier
      Me.m_issueDate = Now.Date
      If Not CBool(Configuration.GetConfig("AllowNoCqCodeDate")) Then
        Me.m_dueDate = Now.Date
      End If

      Me.m_docStatus = New OutgoingCheckDocStatus(-1)
      Me.Status = New CheckStatus(-1)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      MyBase.Construct(ds, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "check_cqcode") AndAlso Not dr.IsNull(aliasPrefix & "check_cqcode") Then
          .m_cqcode = CStr(dr(aliasPrefix & "check_cqcode"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_issueDate") AndAlso Not dr.IsNull(aliasPrefix & "check_issueDate") Then
          .m_issueDate = CDate(dr(aliasPrefix & "check_issueDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_dueDate") AndAlso Not dr.IsNull(aliasPrefix & "check_dueDate") Then
          .m_dueDate = CDate(dr(aliasPrefix & "check_dueDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "supplier_id") Then
          If Not dr.IsNull(aliasPrefix & "supplier_id") Then
            .m_supplier = New Supplier(dr, aliasPrefix)
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
            .m_Loan = New Loan(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "check_bankacct") AndAlso Not dr.IsNull(aliasPrefix & "check_bankacct") Then
            .m_Loan = New Loan(CInt(dr(aliasPrefix & "check_bankacct")))
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
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Property CqCode() As String
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
    Public Property IssueDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_issueDate      End Get      Set(ByVal Value As Date)        m_issueDate = Value      End Set    End Property    Public Property DueDate() As Date Implements IPaymentItem.DueDate      Get        Return m_dueDate      End Get      Set(ByVal Value As Date)        m_dueDate = Value      End Set    End Property    Public Property Supplier() As Supplier      Get        Return m_supplier      End Get      Set(ByVal Value As Supplier)        m_supplier = Value        If Me.Recipient Is Nothing OrElse Me.Recipient.Length = 0 Then          Me.Recipient = m_supplier.Name
        End If        If Not ConfigurationSettings.AppSettings.Item("AddInsDirectory") Is Nothing AndAlso ConfigurationSettings.AppSettings.Item("AddInsDirectory").ToLower.EndsWith("_ple\") Then
          RefreshPV()        End If
      End Set    End Property    Public Property Recipient() As String      Get        Return m_recipient      End Get      Set(ByVal Value As String)        m_recipient = Value      End Set    End Property    Public Property Loan() As Loan      Get        Return m_Loan      End Get      Set(ByVal Value As Loan)        m_Loan = Value      End Set    End Property    Public Property BankCharge() As Decimal      Get
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
    Public Function GetRemainingAmount() As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetOutGoingCheckAmount" _
                , New SqlParameter("@check_id", Me.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

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
      , "GetOutgoingCheckPayments" _
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
    Public Sub RefreshPV()      Me.IsInitialized = False
      If m_itemTable Is Nothing Then
        Return
      End If
      m_itemTable.Clear()
      If Me.Supplier Is Nothing OrElse Not Me.Supplier.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetOutgoingCheckPayments" _
      , New SqlParameter("@check_id", Me.Id) _
      , New SqlParameter("@supplier_id", Me.ValidIdOrDBNull(Me.Supplier)) _
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
        dr("PVRemain") = Configuration.FormatToString(CDec(row("payment_remain")), DigitConfig.Price)
        dr("check_note") = row("payment_refdocNote")
        dr("refDoc") = row("payment_refDoc")
        dr("refDocType") = row("payment_refDocType")
        If IsNumeric(row("paymenti_amt")) Then
          Dim rowAmt As Decimal = CDec(row("paymenti_amt"))
          rowAmt = Math.Min(amt, rowAmt)
          dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
          amt -= rowAmt
        End If
        dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
      Next
      For Each row As DataRow In ds.Tables(1).Rows
        i += 1
        Dim dr As TreeRow = m_itemTable.Childs.Add
        dr("check_linenumber") = row("paymenti_linenumber")
        dr("PVId") = row("payment_id")
        dr("Date") = row("payment_refdocDate")
        dr("Code") = row("payment_refdocCode")
        dr("PVCode") = row("payment_code")
        dr("PVRemain") = Configuration.FormatToString(CDec(row("payment_remain")), DigitConfig.Price)
        dr("check_note") = row("payment_refdocNote")
        dr("refDoc") = row("payment_refDoc")
        dr("refDocType") = row("payment_refDocType")
        If IsNumeric(row("payment_remain")) Then
          Dim rowAmt As Decimal = CDec(row("payment_remain"))
          rowAmt = Math.Min(amt, rowAmt)
          dr("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
          amt -= rowAmt
        End If
        dr("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
      Next
      Me.IsInitialized = True
    End Sub
    Public Sub ReIndex()
      Dim i As Integer = 0
      Dim amt As Decimal = Me.Amount
      For Each row As DataRow In m_itemTable.Childs
        i += 1
        row("check_linenumber") = i
        If IsNumeric(row("PVRemain")) Then
          Dim rowAmt As Decimal = CDec(row("PVRemain"))
          rowAmt = Math.Min(amt, rowAmt)
          row("Amount") = Configuration.FormatToString(rowAmt, DigitConfig.Price)
          amt -= rowAmt
        End If
        row("RemainingAmount") = Configuration.FormatToString(amt, DigitConfig.Price)
      Next
    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "OutgoingAval"
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
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", Me.ValidIdOrDBNull(Me.Loan)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.DocStatus.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isaval", True))


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
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", Me.ValidIdOrDBNull(Me.Loan)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.DocStatus.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_isavl", True))

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
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal currentUserId As Integer) As SaveErrorException
      Try
        If Me.m_itemTable Is Nothing Then
          Return New SaveErrorException("0")
        End If
        Dim da As New SqlDataAdapter("Select * from paymentitem where paymenti_entitytype = 336 and paymenti_entity=" & Me.Id, conn)
        Dim cmdBuilder As New SqlCommandBuilder(da)

        Dim ds As New DataSet

        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "paymentitem")

        Dim i As Integer = 0
        With ds.Tables("paymentitem")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For n As Integer = 0 To Me.m_itemTable.Childs.Count - 1
            Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
            i += 1
            Dim dr As DataRow = .NewRow
            dr("paymenti_entity") = Me.Id
            dr("paymenti_entitycode") = Me.CqCode
            dr("paymenti_payment") = itemRow("PVId")
            dr("paymenti_linenumber") = itemRow("check_linenumber")
            dr("paymenti_entityType") = Me.EntityId
            dr("paymenti_refamt") = Me.Amount
            dr("paymenti_amt") = itemRow("Amount")
            dr("paymenti_note") = itemRow("check_note")
            dr("paymenti_status") = Me.Status.Value
            .Rows.Add(dr)
          Next
        End With
        Dim dt As DataTable = ds.Tables("paymentitem")
        ' First process deletes.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
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


End Namespace
