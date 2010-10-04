Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Reflection
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Interface IAbleSelectDocPickup
    Property DocumentPickingList As String
  End Interface
  Public Class ExportOutgoingCheck
    Inherits SimpleBusinessEntityBase
    Implements IHasAmount, IHasBankAccount, ICheckPeriod, ICOCExportable, IAbleSelectDocPickup

#Region "Members"
    Private m_issueDate As Date
    Private m_effectiveDate As Date
    Private m_pickupDate As Date
    Private m_bankacct As BankAccount
    Private m_feeChargee As String

    Private m_checkCount As Decimal
    Private m_totalamount As Decimal

    Private m_itemCollection As ExportOutgoingCheckItemCollection

    Private m_receiveList As List(Of ChequeReceiver)
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

      Me.m_issueDate = Now.Date
      Me.m_effectiveDate = Now.Date
      Me.m_pickupDate = Now.Date
      Me.m_bankacct = New BankAccount
      Me.Chargee = "N"
      Me.m_itemCollection = New ExportOutgoingCheckItemCollection(Me)
      Me.m_receiveList = New List(Of ChequeReceiver)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        If dr.Table.Columns.Contains(aliasPrefix & "eocheck_issueDate") AndAlso Not dr.IsNull(aliasPrefix & "eocheck_issueDate") Then
          .m_issueDate = CDate(dr(aliasPrefix & "eocheck_issueDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eocheck_pickupDate") AndAlso Not dr.IsNull(aliasPrefix & "eocheck_pickupDate") Then
          .m_pickupDate = CDate(dr(aliasPrefix & "eocheck_pickupDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eocheck_effectiveDate") AndAlso Not dr.IsNull(aliasPrefix & "eocheck_effectiveDate") Then
          .m_effectiveDate = CDate(dr(aliasPrefix & "eocheck_effectiveDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eocheck_bankacct") AndAlso Not dr.IsNull(aliasPrefix & "eocheck_bankacct") Then
          .m_bankacct = New BankAccount(CInt(dr(aliasPrefix & "eocheck_bankacct")))
        Else
          .m_bankacct = New BankAccount
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eocheck_feeChargee") AndAlso Not dr.IsNull(aliasPrefix & "eocheck_feeChargee") Then
          .m_feeChargee = CStr(dr(aliasPrefix & "eocheck_feeChargee"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eocheck_checkCount") AndAlso Not dr.IsNull(aliasPrefix & "eocheck_checkCount") Then
          .m_checkCount = CDec(dr(aliasPrefix & "eocheck_checkCount"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "eocheck_totalAmount") AndAlso Not dr.IsNull(aliasPrefix & "eocheck_totalAmount") Then
          .m_totalamount = CDec(dr(aliasPrefix & "eocheck_totalAmount"))
        End If

        m_itemCollection = New ExportOutgoingCheckItemCollection(Me)
      End With
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollection() As ExportOutgoingCheckItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As ExportOutgoingCheckItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property IssueDate() As Date Implements ICheckPeriod.DocDate
      Get
        Return m_issueDate
      End Get
      Set(ByVal Value As Date)
        m_issueDate = Value
      End Set
    End Property
    Public Property PickUpDate() As Date Implements ICOCExportable.PickUpDate
      Get
        Return m_pickupDate
      End Get
      Set(ByVal Value As Date)
        m_pickupDate = Value
      End Set
    End Property
    Public Property EffectiveDate() As Date Implements ICOCExportable.EffectiveDate
      Get
        Return m_effectiveDate
      End Get
      Set(ByVal Value As Date)
        m_effectiveDate = Value
      End Set
    End Property
    Public Property BankAccount() As BankAccount Implements IHasBankAccount.BankAccount
      Get
        Return m_bankacct
      End Get
      Set(ByVal Value As BankAccount)
        m_bankacct = Value
      End Set
    End Property
    Public Property Chargee() As String Implements ICOCExportable.Chargee
      Get
        Return m_feeChargee
      End Get
      Set(ByVal Value As String)
        m_feeChargee = Value
      End Set
    End Property
    Public Property TotalAmount() As Decimal Implements IHasAmount.Amount
      Get
        Return m_totalamount
      End Get
      Set(ByVal Value As Decimal)
        m_totalamount = Value
      End Set
    End Property
    Public Property CheckCount() As Decimal
      Get
        Return m_checkCount
      End Get
      Set(ByVal Value As Decimal)
        m_checkCount = Value
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "ExportOutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "ExportOutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "eocheck"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ExportOutgoingCheck.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.ExportOutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.ExportOutgoingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.ExportOutgoingCheck.ListLabel}"
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
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("ExportOutGoingCheck")
      myDatatable.Columns.Add(New DataColumn("eocheck_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("SupplierCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("SupplierName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Receiver", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Detail", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DeliveryMethod", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PickupLocationCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocumentForPickup", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PVCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AmountOnCheck", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AmountBeforeVat", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AmountWHT", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AmountAfterVat", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TaxCount", GetType(String)))
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub

    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException("${res:Global.Error.NoItem}")
        End If

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If .Originated Then
          paramArrayList.Add(New SqlParameter("@" & .Prefix & "_id", .Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False

        'If Me.Status.Value = -1 Then
        '    Me.Status.Value = 2
        'End If

        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_code", .Code))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_issuedate", IIf(Me.IssueDate.Equals(Date.MinValue), DBNull.Value, Me.IssueDate)))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_pickupdate", IIf(Me.PickUpDate.Equals(Date.MinValue), DBNull.Value, Me.PickUpDate)))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_effectivedate", IIf(Me.EffectiveDate.Equals(Date.MinValue), DBNull.Value, Me.EffectiveDate)))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_bankacct", IIf(Me.BankAccount.Originated, Me.BankAccount.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_feeChargee", Me.Chargee))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_checkCount", Me.CheckCount))
        paramArrayList.Add(New SqlParameter("@" & .Prefix & "_totalamount", Me.TotalAmount))
        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(.ConnectionString)

        If conn.State = ConnectionState.Open Then conn.Close()
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id

        Try
          .ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
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

          'SaveDetail(Me.Id, conn, trans, currentUserId)

          Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans, currentUserId)
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

          Me.UpdateDueDateToOutGoingCheck(conn, trans)

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

    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal currentUserId As Integer) As SaveErrorException
      Dim i As Integer = 0

      Dim da As New SqlDataAdapter("Select * from ExportOutgoingCheckItem where eochecki_eocheck = " & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      Try
        da.SelectCommand.Transaction = trans

        'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans

        da.Fill(ds, "ExportOutgoingCheckItem")

        Dim dbCount As Integer = ds.Tables("ExportOutgoingCheckItem").Rows.Count
        Dim itemCount As Integer = Me.ItemCollection.Count


        Dim theUser As New User(currentUserId)
        With ds.Tables("ExportOutgoingCheckItem")
          For Each row As DataRow In .Rows
            row.Delete()
          Next
          For Each item As ExportOutgoingCheckItem In Me.ItemCollection
            i += 1
            Dim dr As DataRow = .NewRow
            dr("eochecki_eocheck") = Me.Id
            dr("eochecki_lineNumber") = i
            dr("eochecki_entity") = item.Entity.Id
            dr("eochecki_detail") = item.Detail
            dr("eochecki_deliverymethod") = item.DeliveryMethod
            dr("eochecki_pickupcode") = item.PickupCode
            dr("eochecki_documentforpickup") = item.DocumentForPickup
            .Rows.Add(dr)
          Next
        End With
        Dim saveRtn As Integer
        Dim dt As DataTable = ds.Tables("ExportOutgoingCheckItem")
        ' First process deletes.
        saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
        ' Next process updates.
        saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
        ' Finally process inserts.
        saveRtn = da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))

        Return New SaveErrorException("1")
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try

      'Return saveRtn

    End Function

    Private Sub UpdateDueDateToOutGoingCheck(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.EffectiveDate.Equals(Date.MinValue) Then
        Dim idList As New ArrayList
        Dim idListText As String = ""
        For Each item As ExportOutgoingCheckItem In Me.ItemCollection
          If Not item.Entity Is Nothing Then
            idList.Add(item.Entity.Id)
          End If
        Next

        idListText = String.Join(",", idList.ToArray)

        If idListText.Length > 0 Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateDueDateToOutGoingCheck", _
                                    New SqlParameter("@idList", idListText),
                                    New SqlParameter("@effectiveDate", Me.EffectiveDate))
        End If
      End If
    End Sub
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return True
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteExportOutgoingCheck}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteExportOutgoingCheck", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})

        If IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
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

#Region "ICOCExportable"
    Public Property ExportType As String Implements IExportable.ExportType
      Get
        Return "coc"
      End Get
      Set(ByVal value As String)

      End Set
    End Property

    Public ReadOnly Property PaymentList As System.Collections.Generic.List(Of PaymentForList) Implements IExportable.PaymentList
      Get

      End Get
    End Property

    Public Property DueDate As Date Implements IPaymentItem.DueDate
      Get

      End Get
      Set(ByVal value As Date)

      End Set
    End Property

    Public Function ChequeReceiverList() As System.Collections.Generic.List(Of ChequeReceiver) Implements ICOCExportable.ChequeReceiverList
      If m_receiveList Is Nothing Then
        m_receiveList = New List(Of ChequeReceiver)
      End If
      Dim m_receiveVatList As New List(Of ChequePaymentVat)
      For Each item As ExportOutgoingCheckItem In Me.ItemCollection
        Dim m_receive As New ChequeReceiver
        m_receive.PartIdentifier = "D"
        If Not item.Entity Is Nothing Then
          m_receive.TnxReferenceNo = item.Entity.Code
          m_receive.Amount = item.Entity.Amount
          m_receive.Payee = item.Entity.Recipient
          m_receive.PayeeAddress1 = ""
          m_receive.PayeeAddress2 = ""
          m_receive.PayeeAddress3 = ""
          m_receive.PayeeAddress4 = ""
          m_receive.TaxID = ""
          m_receive.PersonalID = ""
          If item.WHTCollection.Count > 0 Then
            m_receive.BeneRef = item.WHTCollection(0).Code  'item.GetWHTCodeList
          End If
          m_receive.Detail = item.Detail
          m_receive.DeliveryMethod = item.DeliveryMethod
          m_receive.PickupLocationCode = item.PickupCode
          m_receive.DocumentForPickup = item.DocumentForPickup
          m_receive.AttachmentSubfile = ""
          m_receive.AdviceMode = ""
          m_receive.FaxNo = ""
          m_receive.EmailID = ""
          m_receive.TotalInvAmtBefVAT = item.AmountBeforeVat
          m_receive.TotalTaxDeductedAmt = item.WHTCollection.Amount
          m_receive.TotalInvAmtAfterVAT = item.AmountAfterVat
          m_receive.TaxInfoCount = item.WHTCollection.Count

          'Dim whtIndex As Integer = 1
          For Each wht As WitholdingTax In item.WHTCollection
            For Each row As TreeRow In wht.ItemTable.Rows
              Dim m_vatreceive As New ChequePaymentVat
              Dim whti As New WitholdingTaxItem
              whti.CopyFromDataRow(row)

              m_vatreceive.PartIdentifier = "T"
              m_vatreceive.TaxForm = Me.TaxFormCode(wht.Type.Value)
              m_vatreceive.TaxSeq = wht.SequenceNo

              m_vatreceive.TaxRate = whti.TaxRate
              m_vatreceive.TypeofTaxDeducted = whti.Type.Description
              m_vatreceive.InvAmtBefVAT = wht.TaxBase
              m_vatreceive.TaxDeductedAmt = wht.Amount
              m_vatreceive.InvAmtAfterVAT = wht.TaxBase + wht.Amount

              m_vatreceive.TaxCondition = wht.PaymentType.Value.ToString

              'whtIndex += 1

              m_receiveVatList.Add(m_vatreceive)
            Next
          Next

          m_receive.ChequePaymentVatList = m_receiveVatList

          m_receiveList.Add(m_receive)
        End If
      Next

      Return m_receiveList
    End Function

    Private Function TaxFormCode(ByVal id As Integer) As String
      Dim newTaxFormCode As String = ""
      Select Case id
        Case 1 'ภ.ง.ด.1ก
          newTaxFormCode = "01"
        Case 2 'ภ.ง.ด.1ก พิเศษ
          newTaxFormCode = "02"
        Case 3 'ภ.ง.ด.2
          newTaxFormCode = "03"
        Case 4 'ภ.ง.ด.3
          newTaxFormCode = "05"
        Case 5 'ภ.ง.ด.2ก
          newTaxFormCode = "04"
        Case 6 'ภ.ง.ด.3ก
          newTaxFormCode = "06"
        Case 7 'ภ.ง.ด.53
          newTaxFormCode = "07"
        Case Else
          newTaxFormCode = ""
      End Select
      Return newTaxFormCode
    End Function
#End Region

    Dim m_docPickingList As String
    Public Property DocumentPickingList As String Implements IAbleSelectDocPickup.DocumentPickingList
      Get
        Return m_docPickingList
      End Get
      Set(ByVal value As String)
        m_docPickingList = value
      End Set
    End Property
  End Class


  ' Update check items
  Public Class ExportOutgoingCheckItem

#Region "Members"
    Private m_exportoutgoingcheck As ExportOutgoingCheck
    Private m_lineNumber As Integer
    Private m_entity As OutgoingCheck
    Private m_detail As String
    Private m_deliveryMethod As String
    Private m_pickupCode As String
    Private m_documentForPickup As String

    Private m_WHT As WitholdingTaxCollection

    Private m_pvcode As String
    Private m_amountBeforeVat As Decimal
    Private m_amountWHT As Decimal
    Private m_amountAfterVat As Decimal
    Private m_taxCount As Decimal

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      m_deliveryMethod = "CR"
      m_pickupCode = "01"
    End Sub

    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        ' Line number ...
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_linenumber") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_linenumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & Me.Prefix & "_linenumber"))
        End If
        ' Entity ...
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
          .m_entity = New OutgoingCheck(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
        End If
        ' Detail ...
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_detail") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_detail") Then
          .m_detail = CStr(dr(aliasPrefix & Me.Prefix & "_detail"))
        End If
        ' Delivery Method ...
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_deliverymethod") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_deliverymethod") Then
          .m_deliveryMethod = CStr(dr(aliasPrefix & Me.Prefix & "_deliverymethod"))
        End If
        ' PickUp Code ...
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_pickupcode") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_pickupcode") Then
          .m_pickupCode = CStr(dr(aliasPrefix & Me.Prefix & "_pickupcode"))
        End If
        ' Document For Pickup ...
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_documentforpickup") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_documentforpickup") Then
          .m_documentForPickup = CStr(dr(aliasPrefix & Me.Prefix & "_documentforpickup"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property Prefix() As String
      Get
        Return "eochecki"
      End Get
    End Property

    Public Property ExportOutgoingCheck() As ExportOutgoingCheck
      Get
        Return m_exportoutgoingcheck
      End Get
      Set(ByVal Value As ExportOutgoingCheck)
        m_exportoutgoingcheck = Value
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
    Public Property Entity() As OutgoingCheck
      Get
        Return m_entity
      End Get
      Set(ByVal Value As OutgoingCheck)
        m_entity = Value
      End Set
    End Property
    Public Property Detail() As String
      Get
        Return m_detail
      End Get
      Set(ByVal Value As String)
        m_detail = Value
      End Set
    End Property
    Public Property DeliveryMethod() As String
      Get
        Return m_deliveryMethod
      End Get
      Set(ByVal Value As String)
        m_deliveryMethod = Value
      End Set
    End Property
    Public Property PickupCode() As String
      Get
        Return m_pickupCode
      End Get
      Set(ByVal Value As String)
        m_pickupCode = Value
      End Set
    End Property
    Public Property DocumentForPickup() As String
      Get
        Return m_documentForPickup
      End Get
      Set(ByVal Value As String)
        m_documentForPickup = Value
      End Set
    End Property
    Public Property WHTCollection() As WitholdingTaxCollection
      Get
        Return m_WHT
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_WHT = Value
      End Set
    End Property
    Public Property PVCode() As String
      Get
        Return m_pvcode
      End Get
      Set(ByVal Value As String)
        m_pvcode = Value
      End Set
    End Property
    Public Property AmountBeforeVat() As Decimal
      Get
        Return m_amountBeforeVat
      End Get
      Set(ByVal Value As Decimal)
        m_amountBeforeVat = Value
      End Set
    End Property
    Public Property AmountWHT() As Decimal
      Get
        Return m_amountWHT
      End Get
      Set(ByVal Value As Decimal)
        m_amountWHT = Value
      End Set
    End Property
    Public Property AmountAfterVat() As Decimal
      Get
        Return m_amountAfterVat
      End Get
      Set(ByVal Value As Decimal)
        m_amountAfterVat = Value
      End Set
    End Property
    Public Property TaxCount() As Decimal
      Get
        Return m_taxCount
      End Get
      Set(ByVal Value As Decimal)
        m_taxCount = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.ExportOutgoingCheck.IsInitialized = False
      row("eocheck_linenumber") = Me.LineNumber
      If Not Me.Entity Is Nothing Then
        row("code") = Me.Entity.Code
        row("suppliercode") = Me.Entity.Supplier.Code
        row("suppliername") = Me.Entity.Supplier.Name
        row("receiver") = Me.Entity.Recipient
        row("detail") = Me.Detail
        row("DeliveryMethod") = Me.DeliveryMethod
        row("PickupLocationCode") = Me.PickupCode
        row("DocumentForPickup") = Me.DocumentForPickup
        row("pvcode") = Me.PVCode
        row("AmountBeforeVat") = Me.AmountBeforeVat
        row("AmountWHT") = Me.AmountWHT
        row("AmountAfterVat") = Me.AmountAfterVat
        row("TaxCount") = Me.TaxCount
        row("amountoncheck") = Me.Entity.Amount
      Else
        row("code") = DBNull.Value
        row("suppliercode") = DBNull.Value
        row("suppliername") = DBNull.Value
        row("receiver") = DBNull.Value
        row("detail") = DBNull.Value
        row("DeliveryMethod") = DBNull.Value
        row("PickupLocationCode") = DBNull.Value
        row("DocumentForPickup") = DBNull.Value
        row("pvcode") = DBNull.Value
        row("AmountBeforeVat") = DBNull.Value
        row("AmountWHT") = DBNull.Value
        row("AmountAfterVat") = DBNull.Value
        row("TaxCount") = DBNull.Value
        row("amountoncheck") = DBNull.Value
      End If

      Me.ExportOutgoingCheck.IsInitialized = True
    End Sub

    Public Sub FillData()
      If Not Me.Entity Is Nothing Then
        Me.Entity.ReLoadItems()
        Dim i As Integer = 0
        Me.WHTCollection = New WitholdingTaxCollection
        Me.AmountBeforeVat = 0
        Me.AmountWHT = 0
        Me.AmountAfterVat = 0
        Me.TaxCount = 0
        If Me.Entity.ItemTable.Childs.Count > 0 Then
          For i = 0 To Me.Entity.ItemTable.Childs.Count - 1
            If i > 0 Then
              Me.PVCode = Me.PVCode & " ," & CStr(Me.Entity.ItemTable.Childs(i).Item("PVCode"))
            Else
              Me.PVCode = CStr(Me.Entity.ItemTable.Childs(i).Item("PVCode"))
            End If

            Dim myVat As Vat = New Vat(CInt(Me.Entity.ItemTable.Childs(i).Item("refDoc")), CInt(Me.Entity.ItemTable.Childs(i).Item("refDocType")))
            Me.AmountBeforeVat += myVat.TaxBase
            Me.AmountAfterVat += myVat.TaxBase + myVat.Amount

            Dim myWHT As WitholdingTaxCollection = New WitholdingTaxCollection(CInt(Me.Entity.ItemTable.Childs(i).Item("refDoc")), CInt(Me.Entity.ItemTable.Childs(i).Item("refDocType")))
            Me.AmountWHT += myWHT.Amount
            Dim j As Integer = 0
            For j = 0 To myWHT.Count - 1
              Me.WHTCollection.Add(myWHT(j))
              Me.TaxCount += myWHT(j).ItemTable.Childs.Count
            Next
          Next
        End If
      End If
    End Sub
    Public Function GetWHTCodeList() As String
      Dim whtList As New ArrayList
      For Each item As WitholdingTax In Me.WHTCollection
        whtList.Add(item.Code)
      Next

      Return String.Join(" ", whtList.ToArray)
    End Function
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class ExportOutgoingCheckItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_exportOutgoingCheck As ExportOutgoingCheck
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As ExportOutgoingCheck)
      Me.m_exportOutgoingCheck = owner
      If Not Me.m_exportOutgoingCheck.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetExportOutgoingCheckItems" _
      , New SqlParameter("@eochecki_id", Me.m_exportOutgoingCheck.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New ExportOutgoingCheckItem(row, "")
        item.ExportOutgoingCheck = m_exportOutgoingCheck
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As ExportOutgoingCheckItem
      Get
        Return CType(MyBase.List.Item(index), ExportOutgoingCheckItem)
      End Get
      Set(ByVal value As ExportOutgoingCheckItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      For Each eoci As ExportOutgoingCheckItem In Me
        Dim newRow As TreeRow = dt.Childs.Add()
        eoci.FillData()
        eoci.CopyToDataRow(newRow)
        'eoci.ItemValidateRow(newRow)
        newRow.Tag = eoci
      Next
      dt.AcceptChanges()
    End Sub
    Public Function Amount() As Decimal
      Dim ret As Decimal = 0
      For Each eoc As ExportOutgoingCheckItem In Me
        ret += eoc.Entity.Amount
      Next
      Return ret
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As ExportOutgoingCheckItem) As Integer
      If Not m_exportOutgoingCheck Is Nothing Then
        value.ExportOutgoingCheck = m_exportOutgoingCheck
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As ExportOutgoingCheckItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As ExportOutgoingCheckItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As ExportOutgoingCheckItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As ExportOutgoingCheckItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As ExportOutgoingCheckItemEnumerator
      Return New ExportOutgoingCheckItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As ExportOutgoingCheckItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As ExportOutgoingCheckItem)
      If Not m_exportOutgoingCheck Is Nothing Then
        value.ExportOutgoingCheck = m_exportOutgoingCheck
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As ExportOutgoingCheckItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class ExportOutgoingCheckItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As ExportOutgoingCheckItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, ExportOutgoingCheckItem)
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
