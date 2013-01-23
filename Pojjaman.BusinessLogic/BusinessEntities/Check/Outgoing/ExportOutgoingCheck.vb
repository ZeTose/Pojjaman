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
Imports System.Globalization
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Namespace Longkong.Pojjaman.BusinessLogic
  Public Interface IAbleSelectDocPickup
    Property DocumentPickingList As String
  End Interface
  Public Class ExportOutgoingCheck
    Inherits SimpleBusinessEntityBase
    Implements IHasAmount, IHasBankAccount, ICheckPeriod, ICOCExportable, IAbleSelectDocPickup, IPrintableEntity, IPaymentTrackExportable

#Region "Members"
    Private m_issueDate As Date
    Private m_oldissueDate As Date
    Private m_effectiveDate As Date
    Private m_pickupDate As Date
    Private m_bankacct As BankAccount
    Private m_feeChargee As String

    Private m_checkCount As Decimal
    Private m_totalamount As Decimal

    Private m_itemCollection As ExportOutgoingCheckItemCollection

    Private m_receiveList As List(Of ChequeReceiver)
    Private m_paymentTrackDataSet As DataSet
    Private m_PaymenTrackCheckDetailList As List(Of PaymentTrackCheckDetail)
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
      Me.m_oldissueDate = Now.Date
      Me.m_effectiveDate = Now.Date
      Me.m_pickupDate = Now.Date
      Me.m_bankacct = New BankAccount
      Me.Chargee = "N"
      Me.m_itemCollection = New ExportOutgoingCheckItemCollection(Me)
      Me.m_receiveList = New List(Of ChequeReceiver)
      Me.m_paymentTrackDataSet = New DataSet
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
          .m_oldissueDate = CDate(dr(aliasPrefix & "eocheck_issueDate"))
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

        'If dr.Table.Columns.Contains(aliasPrefix & "eopt_status") AndAlso Not dr.IsNull(aliasPrefix & "eopt_status") Then
        '  .m_paymentTrackStatus = CStr(dr(aliasPrefix & "eopt_status"))
        'End If

        m_paymentTrackDataSet = Me.GetExportPaymentTrackList
        ExportOutgoingCheck.OutGoingCheckPaymentDataSet = Nothing
        ExportOutgoingCheck.OutGoingCheckPaymentDataSet = OutgoingCheck.PVListDataSet
        m_itemCollection = New ExportOutgoingCheckItemCollection(Me)

        ExportOutgoingCheck.OutGoingCheckPaymentDataSet = Nothing

        GetIsResponseFromBuilkFromDB()
      End With
    End Sub
#End Region

#Region "Properties"
    Public IsResponseFromBuilk As Boolean

    Public Property TreeManager As TreeManager
    Public Shared Property OutGoingCheckPaymentDataSet As DataSet
    Public ReadOnly Property PaymentTrackDataSet As DataSet
      Get
        If m_paymentTrackDataSet Is Nothing Then
          m_paymentTrackDataSet = New DataSet
        End If
        Return m_paymentTrackDataSet
      End Get
    End Property
    Public Property ItemCollection() As ExportOutgoingCheckItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As ExportOutgoingCheckItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public ReadOnly Property CreateDate As Nullable(Of Date) Implements ICOCExportable.CreateDate
      Get
        Return Me.IssueDate
      End Get
    End Property
    Public Property IssueDate() As Date Implements ICheckPeriod.DocDate
      Get
        Return m_issueDate
      End Get
      Set(ByVal Value As Date)
        m_issueDate = Value
      End Set
    End Property
    Public ReadOnly Property OldIssueDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_oldissueDate
      End Get
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
    Public Function GetResponseFromBuilkData() As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.Text, "select * from ExportOutgoingCheckLog where eocheckl_eocheck = " & Me.Id.ToString)
      Return ds
    End Function
    Public Sub GetIsResponseFromBuilkFromDB()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.Text, "select count(*) from ExportOutgoingCheckLog where eocheckl_eocheck = " & Me.Id.ToString & " and eocheckl_exportType = '1'")
      If ds.Tables(0).Rows.Count > 0 AndAlso IsNumeric(ds.Tables(0).Rows(0)(0)) AndAlso CInt(ds.Tables(0).Rows(0)(0)) > 0 Then
        IsResponseFromBuilk = True
      Else
        IsResponseFromBuilk = False
      End If
    End Sub
    Public Function ExportPaymentTrack() As SaveErrorException
      Dim saveerr1 As SaveErrorException = ExportPaymentTrackFile()
      Dim saveerr2 As SaveErrorException = ExportPaymentTrackOnLine()
      If Not IsNumeric(saveerr1.Message) OrElse Not IsNumeric(saveerr2.Message) Then
        Dim strError As String = ""
        If Not IsNumeric(saveerr1.Message) Then
          strError = saveerr1.Message
        Else
          If CInt(saveerr1.Message) = -2 Then
            Return New SaveErrorException("-2")
          End If
        End If
        If Not IsNumeric(saveerr2.Message) Then
          strError &= saveerr2.Message
        End If
        Return New SaveErrorException(strError)
      End If
      Return New SaveErrorException("0")
    End Function
    Public Function ExportPaymentTrackFile() As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
      '  msgServ.ShowMessage(Validator.ValidationSummary)
      '  Return
      'End If

      'Dim culture As New CultureInfo("en-US", True)
      Dim myOpb As New SaveFileDialog
      myOpb.Filter = "All Files|*.*|Text File (*.txt)|*.txt"
      myOpb.FilterIndex = 2
      myOpb.FileName = "PaymentTrack_" & Me.PayerBuilkID & "_" & Me.Id.ToString & ".txt"
      If myOpb.ShowDialog() = DialogResult.OK Then
        Dim fileName As String = Path.GetDirectoryName(myOpb.FileName) & Path.DirectorySeparatorChar & Path.GetFileName(myOpb.FileName)
        Dim writer As New IO.StreamWriter(fileName, False, System.Text.Encoding.Default)

        Try
          Exporter.ExportPaymentTrack(Me, writer)
          'MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.ExportCompleted}"))
        Catch ex As Exception
          'MessageBox.Show("Error:" & ex.ToString)
          Return New SaveErrorException(ex.Message)
        Finally
          writer.Close()
        End Try
      Else
        Return New SaveErrorException("-2")
      End If
      Return New SaveErrorException("0")
    End Function
    Public Function ExportPaymentTrackOnLine() As SaveErrorException

      Dim BuilkID As String = Configuration.GetConfig("BuilkID").ToString
      Dim HostURL As String = Configuration.GetConfig("WebServiceHostURL").ToString

      If BuilkID = "" Then
        Return New SaveErrorException("0")
      End If

      Dim WebService As String = HostURL & "/paymenttrack/Transaction/?bid=" & BuilkID

      'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/approvebuilksupplier/?bid=12")
      'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/Transaction/?bid=" & BuilkID)
      Dim request As WebRequest = WebRequest.Create(WebService)
      request.Method = "POST"

      Dim postData As String = ""

      'Dim writer As New IO.StreamWriter(dataStream, System.Text.Encoding.UTF8)

      Try
        Exporter.ExportPaymentTrack(Me, postData)
        'MessageBox.Show(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ExportPaymentTrackDetail.ExportCompleted}"))
      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try

      Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
      Dim dataStream As Stream

      Try
        request.ContentType = "text/plain"
        request.ContentLength = byteArray.Length
        dataStream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)

      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      Finally
        If Not dataStream Is Nothing Then
          dataStream.Close()
        End If
      End Try

      Dim response As WebResponse
      Dim reader As StreamReader
      Dim responseFromServer As String
      Try
        response = request.GetResponse()
        dataStream = response.GetResponseStream()
        reader = New StreamReader(dataStream)
        responseFromServer = reader.ReadToEnd()

        response.Close()
        dataStream.Close()

        If response Is Nothing Then
          Throw New SaveErrorException("Not response from server")
        Else
          'response.ToString
        End If
      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try

      Return New SaveErrorException("0")

    End Function

    Public Sub GetBuilkExportResponseRequest()

      Dim blist As New List(Of BuilkExportConfirmInfo)
      Dim BuilkID As String = Configuration.GetConfig("BuilkID").ToString
      Dim HostURL As String = Configuration.GetConfig("WebServiceHostURL").ToString

      If BuilkID = "" Then
        Return
      End If

      Dim WebService As String = HostURL & "/paymenttrack/requestbuilkexportconfirm/?bid=" & BuilkID & "&pid=" & Me.Id.ToString

      ' Create a request for the URL. 
      'Dim request As WebRequest = WebRequest.Create("http://www.builk.com/paymenttrack/requestbuilkexportconfirm/?bid=" & BuilkID & "&pid=" & Me.Id.ToString)
      Dim request As WebRequest = WebRequest.Create(WebService)
      ' If required by the server, set the credentials.
      request.Credentials = CredentialCache.DefaultCredentials
      ' Get the response.
      Dim response As WebResponse = request.GetResponse()
      ' Display the status.
      'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
      ' Get the stream containing content returned by the server.
      Dim dataStream As Stream = response.GetResponseStream()
      ' Open the stream using a StreamReader for easy access.
      Dim reader As New StreamReader(dataStream)
      ' Read the content.
      Dim responseFromServer As String = reader.ReadToEnd()
      ' Display the content.
      'Console.WriteLine(responseFromServer)
      ' Clean up the streams and the response.
      reader.Close()
      response.Close()



      blist = JsonConvert.DeserializeObject(Of List(Of BuilkExportConfirmInfo))(responseFromServer)

      Dim cmdLog As String = ""
      Dim cmdDate As String = Now.ToString("yyyy-MM-dd")
      Dim cmdList As New ArrayList

      For Each bi As BuilkExportConfirmInfo In blist

        cmdLog = "("
        cmdLog &= Me.Id.ToString & ","
        cmdLog &= "'1'" & ","
        cmdLog &= cmdDate & ","
        cmdLog &= "'" & bi.CheckCode.Trim & "'," 'Txn. Reference No.poj
        cmdLog &= "'" & bi.SupplierName.Trim & "'," 'Payee
        cmdLog &= bi.CheckAmount 'Amount
        cmdLog &= ")"
        cmdList.Add(cmdLog)

      Next

      InsertExportLog(cmdList)

    End Sub

    Private Sub InsertExportLog(li As ArrayList)
      Try
        If li.Count > 0 Then
          Dim cmdLog As String = ""
          cmdLog &= "delete from ExportOutgoingCheckLog where eocheckl_eocheck =" & Me.Id.ToString & " and eocheckl_exportType ='1';"
          cmdLog &= "insert into ExportOutgoingCheckLog ( eocheckl_eocheck ,eocheckl_exportType ,eocheckl_exportDate ,eocheckl_checkCode ,eocheckl_checkSupplier ,eocheckl_checkAmount ) values "
          cmdLog &= String.Join(",", li.ToArray)
          cmdLog &= ";"

          SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, CommandType.Text, cmdLog, Nothing)
        End If


      Catch ex As Exception

      End Try
    End Sub

    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub

    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)

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

          'If Me.Status.Value = 0 Then
          '  Me.SavePaymentTrackStatus("C", currentUserId)
          'End If

          trans.Commit()

          Try
            If Me.Status.Value = 0 Then
              'If myMessage.AskQuestion("ต้องการให้ Export PaymentTrack ด้วยหรือไม่") Then
              Me.SaveExportPaymentTrackStatus("C", currentUserId)
              Me.ExportPaymentTrack()
              'Me.ExportPaymentTrackOnLine()
              'End If
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.Message & vbCrLf & ex.InnerException.ToString)
          End Try


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

    Public Function GetExportPaymentTrackList() As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString _
    , CommandType.StoredProcedure _
    , "GetExportPaymentTrackList" _
    , New SqlParameter("@eocheck_id", Me.Id)
    )
      If ds.Tables(0).Rows.Count > 0 Then
        Return ds
      End If

      Return New DataSet
    End Function

    Public Function GetPVCodeListByCheckId(ByVal checkId As Integer) As String
      If Not m_paymentTrackDataSet Is Nothing AndAlso m_paymentTrackDataSet.Tables.Count > 0 Then
        Dim dr As DataRow() = m_paymentTrackDataSet.Tables(0).Select("eochecki_entity=" & checkId.ToString)
        Dim cList As New ArrayList
        For Each row As DataRow In dr
          Dim drh As New DataRowHelper(row)
          cList.Add(drh.GetValue(Of String)("payment_code"))
        Next
        Return String.Join(", ", cList.ToArray)
      End If
      Return ""
    End Function

    Public Function GetVATAmountByCheckId(ByVal checkId As Integer) As Decimal
      If Not m_paymentTrackDataSet Is Nothing AndAlso m_paymentTrackDataSet.Tables.Count > 0 Then
        Dim dr As DataRow() = m_paymentTrackDataSet.Tables(0).Select("eochecki_entity=" & checkId.ToString)
        Dim vatAmt As Decimal = 0
        For Each row As DataRow In dr
          Dim drh As New DataRowHelper(row)
          vatAmt += drh.GetValue(Of Decimal)("vatamt")
        Next
        Return vatAmt
      End If
      Return 0
    End Function

    Public Function GetVATTaxBaseByCheckId(ByVal checkId As Integer) As Decimal
      If Not m_paymentTrackDataSet Is Nothing AndAlso m_paymentTrackDataSet.Tables.Count > 0 Then
        Dim dr As DataRow() = m_paymentTrackDataSet.Tables(0).Select("eochecki_entity=" & checkId.ToString)
        Dim vattaxbase As Decimal = 0
        For Each row As DataRow In dr
          Dim drh As New DataRowHelper(row)
          vattaxbase += (drh.GetValue(Of Decimal)("vatamt") + drh.GetValue(Of Decimal)("vattaxbase"))
        Next
        Return vattaxbase
      End If
      Return 0
    End Function

    Public Function GetWHTCollectionByCheckId(ByVal checkId As Integer) As WitholdingTaxCollection
      If Not m_paymentTrackDataSet Is Nothing AndAlso m_paymentTrackDataSet.Tables.Count > 1 Then
        Dim whtcol As New WitholdingTaxCollection
        'Dim ds As New DataSet
        Dim dr As DataRow() = m_paymentTrackDataSet.Tables(1).Select("eochecki_entity=" & checkId.ToString & " and wht_id is not null")
        'Dim dr1 As DataRow() = m_paymentTrackDataSet.Tables(2).Select("eochecki_entity=" & checkId.ToString)
        'Dim dt As New DataTable
        'Dim dt1 As New DataTable
        '--Add Columns-- ========
        'For Each dc As DataColumn In m_paymentTrackDataSet.Tables(1).Columns
        '  dt.Columns.Add(New DataColumn(dc.ColumnName))
        'Next
        'For Each dc As DataColumn In m_paymentTrackDataSet.Tables(2).Columns
        '  dt1.Columns.Add(New DataColumn(dc.ColumnName))
        'Next

        'For Each row As DataRow In dr1
        '  Dim newrow As DataRow = dt1.NewRow
        '  For Each dc As DataColumn In m_paymentTrackDataSet.Tables(2).Columns
        '    newrow(dc.ColumnName) = row(dc.ColumnName)
        '  Next
        '  dt1.Rows.Add(newrow)
        'Next

        'ds.Tables.Add(New DataTable)
        'ds.Tables.Add(dt1)

        For Each row As DataRow In dr

          'Dim newrow As DataRow = dt.NewRow
          'For Each dc As DataColumn In m_paymentTrackDataSet.Tables(1).Columns
          '  newrow(dc.ColumnName) = row(dc.ColumnName)
          'Next
          'dt.Rows.Add(newrow)
          'ds.Tables.Add(dt)

          Dim item As New WitholdingTax(row, "")
          whtcol.Add(item)

        Next
        Return whtcol
      End If
      Return New WitholdingTaxCollection
    End Function

    Public Function GetAddedList(ByVal chk As OutgoingCheck) As String
      If Not Me.m_paymentTrackDataSet Is Nothing Then
        Dim dr As DataRow() = Me.m_paymentTrackDataSet.Tables(1).Select("eochecki_entity=" & chk.Id.ToString)
        Dim addedList As New ArrayList
        Dim percent As Decimal = 0
        Dim addedText As String = ""
        For Each row As DataRow In dr
          Dim drh As New DataRowHelper(row)
          'percent = drh.GetValue(Of Decimal)("percent")
          If drh.GetValue(Of Decimal)("payment_interest") > 0 Then
            addedText = "ดอกเบี้ยจ่าย".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_interest"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
          If drh.GetValue(Of Decimal)("payment_bankcharge") > 0 Then
            addedText = "ค่าธรรมเนียมธนาคาร".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_bankcharge"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
          If drh.GetValue(Of Decimal)("payment_otherExpense") > 0 Then
            addedText = "ค่าใช้จ่ายอื่นๆ".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_otherExpense"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
          If drh.GetValue(Of Decimal)("payment_creditamt") > 0 Then
            addedText = "ยอดเพิ่มจำนวนจ่ายอื่น".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_creditamt"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
        Next
        If addedList.Count > 0 Then
          Return String.Join(";", addedList.ToArray())
        End If
      End If

      Return ""
    End Function

    Public Function GetSubtractList(ByVal chk As OutgoingCheck) As String
      If Not Me.m_paymentTrackDataSet Is Nothing Then
        Dim dr As DataRow() = Me.m_paymentTrackDataSet.Tables(1).Select("eochecki_entity=" & chk.Id.ToString)
        Dim subtractList As New ArrayList
        Dim percent As Decimal = 0
        Dim subtractText As String = ""
        For Each row As DataRow In dr
          Dim drh As New DataRowHelper(row)
          'percent = drh.GetValue(Of Decimal)("percent")
          If drh.GetValue(Of Decimal)("payment_discount") > 0 Then
            subtractText = "ส่วนลดรับ".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_discount"), DigitConfig.Price).ToString
            subtractList.Add(subtractText)
          End If
          If drh.GetValue(Of Decimal)("payment_otherRevenue") > 0 Then
            subtractText = "รายได้อื่นๆ".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_otherRevenue"), DigitConfig.Price).ToString
            subtractList.Add(subtractText)
          End If
          'If drh.GetValue(Of Decimal)("payment_witholdingTax") > 0 Then
          '  subtractText = "ภาษีหัก ณ ที่จ่าย".Colon & (drh.GetValue(Of Decimal)("payment_witholdingTax") * percent).ToString
          '  subtractList.Add(subtractText)
          'End If
          If drh.GetValue(Of Decimal)("payment_debitamt") > 0 Then
            subtractText = "ยอดหักจำนวนจ่ายอื่น".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_debitamt"), DigitConfig.Price).ToString
            subtractList.Add(subtractText)
          End If
        Next
        If subtractList.Count > 0 Then
          Return String.Join(";", subtractList.ToArray())
        End If
      End If

      Return ""
    End Function

    Public Function GetRefDocAddedList(ByVal chk As OutgoingCheck, ByVal stockid As Integer) As String
      If Not Me.m_paymentTrackDataSet Is Nothing Then
        Dim dr As DataRow() = Me.m_paymentTrackDataSet.Tables(0).Select("eochecki_entity=" & chk.Id.ToString & " and stockid=" & stockid.ToString)
        Dim addedList As New ArrayList
        Dim percent As Decimal = 0
        Dim addedText As String = ""
        For Each row As DataRow In dr
          Dim drh As New DataRowHelper(row)
          'percent = drh.GetValue(Of Decimal)("percent")
          If drh.GetValue(Of Decimal)("payment_interest") > 0 Then
            addedText = "ดอกเบี้ยจ่าย".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_interest"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
          If drh.GetValue(Of Decimal)("payment_bankcharge") > 0 Then
            addedText = "ค่าธรรมเนียมธนาคาร".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_bankcharge"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
          If drh.GetValue(Of Decimal)("payment_otherExpense") > 0 Then
            addedText = "ค่าใช้จ่ายอื่นๆ".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_otherExpense"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
          If drh.GetValue(Of Decimal)("payment_creditamt") > 0 Then
            addedText = "ยอดเพิ่มจำนวนจ่ายอื่น".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_creditamt"), DigitConfig.Price).ToString
            addedList.Add(addedText)
          End If
        Next
        If addedList.Count > 0 Then
          Return String.Join(";", addedList.ToArray())
        End If
      End If

      Return ""
    End Function

    Public Function GetRefDocSubtractList(ByVal chk As OutgoingCheck, ByVal stockid As Integer) As String
      If Not Me.m_paymentTrackDataSet Is Nothing Then
        Dim dr As DataRow() = Me.m_paymentTrackDataSet.Tables(0).Select("eochecki_entity=" & chk.Id.ToString & " and stockid=" & stockid.ToString)
        Dim subtractList As New ArrayList
        Dim percent As Decimal = 0
        Dim subtractText As String = ""
        For Each row As DataRow In dr
          Dim drh As New DataRowHelper(row)
          'percent = drh.GetValue(Of Decimal)("percent")
          If drh.GetValue(Of Decimal)("payment_discount") > 0 Then
            subtractText = "ส่วนลดรับ".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_discount"), DigitConfig.Price).ToString
            subtractList.Add(subtractText)
          End If
          If drh.GetValue(Of Decimal)("payment_otherRevenue") > 0 Then
            subtractText = "รายได้อื่นๆ".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_otherRevenue"), DigitConfig.Price).ToString
            subtractList.Add(subtractText)
          End If
          'If drh.GetValue(Of Decimal)("payment_witholdingTax") > 0 Then
          '  subtractText = "ภาษีหัก ณ ที่จ่าย".Colon & (drh.GetValue(Of Decimal)("payment_witholdingTax") * percent).ToString
          '  subtractList.Add(subtractText)
          'End If
          If drh.GetValue(Of Decimal)("payment_debitamt") > 0 Then
            subtractText = "ยอดหักจำนวนจ่ายอื่น".Colon & Configuration.Format(drh.GetValue(Of Decimal)("payment_debitamt"), DigitConfig.Price).ToString
            subtractList.Add(subtractText)
          End If
          If drh.GetValue(Of Decimal)("stockretention") > 0 Then
            subtractText = "Retention:" & Configuration.Format(drh.GetValue(Of Decimal)("stockretention"), DigitConfig.Price).ToString
            subtractList.Add(subtractText)
          End If
        Next
        If subtractList.Count > 0 Then
          Return String.Join(";", subtractList.ToArray())
        End If
      End If

      Return ""
    End Function

    'Public Function GetBillAcceptanceList(ByVal chk As OutgoingCheck) As DataTable
    '  If Not Me.m_paymentTrackDataSet Is Nothing Then
    '    Dim dt As New DataTable
    '    Dim newrow As DataRow
    '    Dim dr As DataRow() = Me.m_paymentTrackDataSet.Tables(0).Select("check_id=" & chk.Id.ToString)
    '    For Each dc As DataColumn In dr.
    '    For Each row As DataRow In dr

    '    Next
    '  End If
    'End Function

#Region "IPaymentTrackExportable"
    Public Function CheckExportPaymentTrackStatus() As String
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
                                                  CommandType.StoredProcedure,
                                                  "CheckExportPaymentTrack",
                                                  New SqlParameter("@eopt_eocheck", Me.Id)
                                                  )
      If ds.Tables(0).Rows.Count = 0 OrElse ds.Tables(0).Rows(0).IsNull("eopt_status") Then
        Return ""
      Else
        Return ds.Tables(0).Rows(0)("eopt_status").ToString
      End If
    End Function
    Public Function SaveExportPaymentTrackStatus(ByVal status As String, ByVal UserId As Object) As String
      'Me.m_paymentTrackStatus = status
      SqlHelper.ExecuteNonQuery(SimpleBusinessEntityBase.ConnectionString, _
                                                   CommandType.StoredProcedure,
                                                   "InsertExportPaymentTrack", _
                                                   New SqlParameter("@eopt_eocheck", Me.Id), _
                                                   New SqlParameter("@eopt_status", status), _
                                                   New SqlParameter("@eopt_editor", UserId))
    End Function
    Public Property PayerBuilkID As String Implements IPaymentTrackExportable.PayerBuilkID
      Get
        Dim obj As Object = Configuration.GetConfig("BuilkID")
        Return CStr(obj)
      End Get
      Set(ByVal value As String)

      End Set
    End Property
    Private m_paymentTrackStatus As String
    Public Property PaymentTrackStatus As String Implements IPaymentTrackExportable.PaymentTrackStatus
      Get
        Return m_paymentTrackStatus
      End Get
      Set(ByVal value As String)
        m_paymentTrackStatus = value
      End Set
    End Property
    Public ReadOnly Property CheckQty As Integer Implements IPaymentTrackExportable.CheckQty
      Get
        Dim qty As Integer = 0
        For Each c As ExportOutgoingCheckItem In Me.ItemCollection
          If Not c.Entity Is Nothing AndAlso _
          Not c.Entity.Supplier.BuilkID Is Nothing AndAlso _
          c.Entity.Supplier.BuilkID.Trim.Length > 0 Then
            qty += 1
          End If
        Next
        Return qty
      End Get
    End Property
    Public ReadOnly Property CheckAmount As Decimal Implements IPaymentTrackExportable.CheckAmount
      Get
        Dim amt As Decimal = 0
        For Each c As ExportOutgoingCheckItem In Me.ItemCollection
          If Not c.Entity Is Nothing AndAlso _
          Not c.Entity.Supplier.BuilkID Is Nothing AndAlso _
          c.Entity.Supplier.BuilkID.Trim.Length > 0 Then
            amt += c.Entity.Amount
          End If
        Next
        Return amt
      End Get
    End Property

    Public Function PaymenTrackCheckDetailList() As System.Collections.Generic.List(Of PaymentTrackCheckDetail) Implements IPaymentTrackExportable.PaymenTrackCheckDetailList

      Dim culture As New CultureInfo("en-US", True)
      m_PaymenTrackCheckDetailList = New List(Of PaymentTrackCheckDetail)

      For Each exCheck As ExportOutgoingCheckItem In Me.ItemCollection
        If Not exCheck.Entity Is Nothing AndAlso _
          exCheck.Entity.Originated AndAlso _
          Not exCheck.Entity.Supplier.BuilkID Is Nothing AndAlso _
          exCheck.Entity.Supplier.BuilkID.Trim.Length > 0 Then

          Dim ck As New PaymentTrackCheckDetail
          ck.CheckID = exCheck.Entity.Id.ToString
          ck.CheckCode = exCheck.Entity.Code
          ck.PayeeBuilkId = exCheck.Entity.Supplier.BuilkID
          ck.CheckDescription = exCheck.Detail
          ck.CheckIssueDate = exCheck.Entity.IssueDate.ToString("yyyy-MM-dd", culture)
          ck.CheckAmount = Configuration.Format(exCheck.Entity.Amount, DigitConfig.Price).ToString
          ck.BeforeTax = Configuration.Format(exCheck.AmountBeforeVat, DigitConfig.Price).ToString
          ck.WitholdingTax = Configuration.Format(exCheck.WHTCollection.Amount, DigitConfig.Price).ToString
          ck.AfterTax = Configuration.Format(exCheck.AmountAfterVat, DigitConfig.Price).ToString
          ck.DocForReceive = ExportOutgoingCheck.GetDescriptionFromCodeTag(exCheck.DocumentForPickup, "DocumentForPickup", True)
          ck.ReceiveAddress = ExportOutgoingCheck.GetDescriptionFromCodeTag(exCheck.PickupCode, "PickupLocationCode", True)
          ck.ReceiveMethod = ExportOutgoingCheck.GetDescriptionFromCodeTag(exCheck.DeliveryMethod, "DeliveryMethod", True)
          ck.CheckRemark = exCheck.Entity.Note
          ck.Added = Me.GetAddedList(exCheck.Entity)
          ck.Subtract = Me.GetSubtractList(exCheck.Entity)

          Dim dr As DataRow() = Me.m_paymentTrackDataSet.Tables(0).Select("billa_id is not null and eochecki_entity=" & exCheck.Entity.Id.ToString)
          If dr.Length > 0 Then '--มีเอกสารวางบิล-- ====================== X1
            Dim billHs As New Hashtable
            For Each row As DataRow In dr
              Dim pbhr As New DataRowHelper(row)
              Dim pb As New PaymentTrackBillNoteDetail

              If Not billHs.ContainsKey(pbhr.GetValue(Of String)("billa_id")) Then
                pb.CheckID = exCheck.Entity.Id.ToString
                pb.BillID = pbhr.GetValue(Of String)("billa_id")
                pb.BillNoteCode = pbhr.GetValue(Of String)("billa_billissueCode")
                If IsDate(pbhr.GetValue(Of Date)("billa_billissueDate")) Then
                  pb.BillNoteDate = pbhr.GetValue(Of Date)("billa_billissueDate").ToString("yyyy-MM-dd", culture)
                End If
                pb.Amount = Configuration.Format(pbhr.GetValue(Of Decimal)("billa_gross"), DigitConfig.Price).ToString

                Dim dr2 As DataRow() = Me.m_paymentTrackDataSet.Tables(0).Select("eochecki_entity=" & exCheck.Entity.Id.ToString & " and billa_id=" & pbhr.GetValue(Of String)("billa_id"))
                For Each row2 As DataRow In dr2
                  Dim dochr As New DataRowHelper(row2)
                  Dim dc As New PaymentTrackDocDetail
                  dc.CheckID = exCheck.Entity.Id.ToString
                  dc.BillID = pbhr.GetValue(Of String)("billa_id")
                  dc.DocumentType = dochr.GetValue(Of String)("entity_description")
                  dc.DocumentCode = dochr.GetValue(Of String)("stockotherDocCode")
                  If IsDate(dochr.GetValue(Of Date)("stockotherdocdate")) Then
                    dc.DocumentDate = dochr.GetValue(Of Date)("stockotherdocdate").ToString("yyyy-MM-dd", culture)
                  End If
                  dc.Amount = Configuration.Format((dochr.GetValue(Of Decimal)("stock_aftertax") + dochr.GetValue(Of Decimal)("stockretention")), DigitConfig.Price).ToString
                  dc.TotalAmount = Configuration.Format(dochr.GetValue(Of Decimal)("stock_aftertax"), DigitConfig.Price).ToString
                  'If dochr.GetValue(Of Decimal)("stockretention") > 0 Then
                  '  dc.Subtract = "Retention:" & Configuration.Format(dochr.GetValue(Of Decimal)("stockretention"), DigitConfig.Price).ToString
                  'End If
                  dc.Added = Me.GetRefDocAddedList(exCheck.Entity, dochr.GetValue(Of Integer)("stockid"))
                  dc.Subtract = Me.GetRefDocSubtractList(exCheck.Entity, dochr.GetValue(Of Integer)("stockid"))
                  dc.ReferenceDocument = dochr.GetValue(Of String)("posc")
                  pb.PaymentTrackDocDetailList.Add(dc)
                Next

                billHs(pbhr.GetValue(Of String)("billa_id")) = row
                ck.PaymentTrackBillNoteDetailList.Add(pb)
              End If
            Next

          Else '--ไม่มีมีเอกสารวางบิล-- =================================== X1
            Dim dr2 As DataRow() = Me.m_paymentTrackDataSet.Tables(0).Select("eochecki_entity=" & exCheck.Entity.Id.ToString)
            For Each row As DataRow In dr2
              Dim dochr As New DataRowHelper(row)
              If dochr.GetValue(Of Integer)("stockid") > 0 Then
                Dim dc As New PaymentTrackDocDetail
                dc.CheckID = exCheck.Entity.Id.ToString
                dc.BillID = ""
                dc.DocumentType = dochr.GetValue(Of String)("entity_description")
                dc.DocumentCode = dochr.GetValue(Of String)("stockotherDocCode")
                If IsDate(dochr.GetValue(Of Date)("stockotherdocdate")) Then
                  dc.DocumentDate = dochr.GetValue(Of Date)("stockotherdocdate").ToString("yyyy-MM-dd", culture)
                End If
                dc.Amount = Configuration.Format((dochr.GetValue(Of Decimal)("stock_aftertax") + dochr.GetValue(Of Decimal)("stockretention")), DigitConfig.Price).ToString
                dc.TotalAmount = Configuration.Format(dochr.GetValue(Of Decimal)("stock_aftertax"), DigitConfig.Price).ToString
                'If dochr.GetValue(Of Decimal)("stockretention") > 0 Then
                '  dc.Subtract = "Retention:" & Configuration.Format(dochr.GetValue(Of Decimal)("stockretention"), DigitConfig.Price).ToString
                'End If
                dc.Added = Me.GetRefDocAddedList(exCheck.Entity, dochr.GetValue(Of Integer)("stockid"))
                dc.Subtract = Me.GetRefDocSubtractList(exCheck.Entity, dochr.GetValue(Of Integer)("stockid"))
                dc.ReferenceDocument = dochr.GetValue(Of String)("posc")
                ck.PaymentTrackDocDetailList.Add(dc)
              End If
            Next
          End If

          m_PaymenTrackCheckDetailList.Add(ck)
        End If
      Next

      Return m_PaymenTrackCheckDetailList
    End Function

    Public Property PaymentTrackID As String Implements IPaymentTrackExportable.PaymentTrackID
      Get
        Return Me.Id.ToString
      End Get
      Set(ByVal value As String)

      End Set
    End Property
#End Region

    'Public Sub PopulatePaymentTrack(ByVal dt As TreeTable)
    '  'dt.Clear()

    '  Dim checkHs As New Hashtable
    '  Dim checkTr As TreeRow = Nothing
    '  Dim docTr As TreeRow = Nothing

    '  For Each row As DataRow In Me.m_paymentTrackDataSet.Tables(0).Rows
    '    Dim drh As New DataRowHelper(row)

    '    If Not checkHs.ContainsKey(drh.GetValue(Of String)("check_id")) Then
    '      checkTr = dt.Childs.Add
    '      checkTr("col0") = drh.GetValue(Of String)("entity_description")
    '      checkTr("col1") = drh.GetValue(Of String)("check_code")
    '      checkTr("col2") = drh.GetValue(Of String)("supplier_code") & " : " & drh.GetValue(Of String)("supplier_name")
    '      checkTr("col3") = drh.GetValue(Of String)("eochecki_detail")
    '      If IsDate(drh.GetValue(Of String)("check_issuedate")) Then
    '        checkTr("col4") = CDate(drh.GetValue(Of String)("check_issuedate")).ToShortDateString
    '      End If
    '      checkTr("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("check_amt"), DigitConfig.Price)
    '      '
    '      checkTr("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("whtamt"), DigitConfig.Price)
    '      checkTr("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("deductpayment"), DigitConfig.Price)
    '      checkTr("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("addedpayment"), DigitConfig.Price)
    '      checkTr("col9") = ExportOutgoingCheck.GetDescriptionFromCodeTag(drh.GetValue(Of String)("eochecki_documentForPickup"), "DocumentForPickup")
    '      checkTr("col10") = ExportOutgoingCheck.GetDescriptionFromCodeTag(drh.GetValue(Of String)("eochecki_pickupCode"), "PickupLocationCode")
    '      checkTr("col11") = ExportOutgoingCheck.GetDescriptionFromCodeTag(drh.GetValue(Of String)("eochecki_deliveryMethod"), "DeliveryMethod")

    '      checkTr("col7") = drh.GetValue(Of String)("check_note")

    '      checkHs(drh.GetValue(Of String)("check_id")) = checkTr
    '    Else
    '      checkTr = CType(checkHs(drh.GetValue(Of String)("check_id")), TreeRow)

    '    End If

    '    'Dim newRow As TreeRow = dt.Childs.Add()
    '    'eoci.CopyToDataRow(newRow)
    '    ''eoci.ItemValidateRow(newRow)
    '    'newRow.Tag = eoci
    '  Next
    '  dt.AcceptChanges()
    'End Sub

    Public Shared Function GetDescriptionFromCodeTag(ByVal picupCodeList As String, ByVal codeName As String, Optional ByVal JoinWithSemicolon As Boolean = False) As String
      If picupCodeList Is Nothing OrElse picupCodeList.Length = 0 Then
        Return ""
      End If
      Dim splitCode() As String = picupCodeList.Split(" "c)
      Dim splitDescriptionList As New ArrayList
      Dim dt As DataTable = CodeDescription.GetCodeList(codeName)
      Dim puDescriptionHs As New Hashtable
      For Each row As DataRow In dt.Rows
        Dim drh As New DataRowHelper(row)
        Dim splitIdCode() As String = drh.GetValue(Of String)("code_description").Split("-"c)
        puDescriptionHs.Add(drh.GetValue(Of String)("code_tag"), splitIdCode(1).Trim)
      Next
      For Each pucode As String In splitCode
        splitDescriptionList.Add(CStr(puDescriptionHs(pucode)))
      Next
      Dim joinString As String = ", "
      If JoinWithSemicolon Then
        joinString = ";"
      End If
      Return String.Join(joinString, splitDescriptionList.ToArray)
    End Function
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

      '--Export Payment Track-- =================
      Me.SaveExportPaymentTrackStatus("D", DBNull.Value)
      Me.ExportPaymentTrack()
      '--Export Payment Track-- =================

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
    Private Function GetSplitAddress(ByVal splitString As String) As ArrayList
      Dim repVar As String = Replace(splitString, "  ", " ")
      Dim splitVar() As String = repVar.Split(" "c)
      Dim listVar As New ArrayList
      Dim currStringVar As String = ""
      Dim nextStringVar As String = ""
      For Each var As String In splitVar
        nextStringVar &= " " & var
        If nextStringVar.Length >= 30 Then
          listVar.Add(currStringVar)
          nextStringVar = ""
          currStringVar = var
        Else
          currStringVar &= " " & var
        End If
      Next

      Return listVar

      'Dim list(3) As String
      'list(0) = Mid(splitVar, 1, 30)
      'list(1) = Mid(splitVar, 31, 30)
      'list(2) = Mid(splitVar, 62, 30)
      'list(3) = Mid(splitVar, 93, 30)

      'If Len(list(1)) > 0 AndAlso Mid(list(1), 1, 1) <> " " Then

      'End If
    End Function
    Public Function ChequeReceiverList() As System.Collections.Generic.List(Of ChequeReceiver) Implements ICOCExportable.ChequeReceiverList
      'If m_receiveList Is Nothing Then
      m_receiveList = New List(Of ChequeReceiver)
      'End If
      For Each item As ExportOutgoingCheckItem In Me.ItemCollection
        Dim m_receive As New ChequeReceiver
        m_receive.PartIdentifier = "D"
        If Not item.Entity Is Nothing Then
          m_receive.TnxReferenceNo = item.Entity.Code
          m_receive.Amount = item.Entity.Amount
          m_receive.Payee = item.Entity.Recipient

          If Not item.Entity Is Nothing AndAlso Not item.Entity.Supplier Is Nothing Then
            Dim strAddress As String = item.Entity.Supplier.BillingAddress.Trim '& " " & item.Entity.Supplier.Province.Trim
            strAddress = Replace(strAddress, vbCrLf, " ")
            strAddress = Replace(strAddress, vbLf, " ")
            strAddress = Replace(strAddress, "  ", " ")

            'Dim ar As New ArrayList
            'For Each Str As Char In strAddress.ToCharArray
            '  Dim asci As Integer = Asc(Str)
            '  Trace.WriteLine(Str.ToString & ":" & asci.ToString)
            'Next

            m_receive.PayeeAddress1 = Mid(strAddress, 1, 30)
            m_receive.PayeeAddress2 = Mid(strAddress, 31, 30)
            m_receive.PayeeAddress3 = Mid(strAddress, 61, 30)
            m_receive.PayeeAddress4 = Mid(strAddress, 91, 30)
            'Dim arr As ArrayList = Me.GetSplitAddress(item.Entity.Supplier.BillingAddress & " " & item.Entity.Supplier.Province)
            'Select Case arr.Count
            '  Case 1
            '    m_receive.PayeeAddress1 = arr(0).ToString
            '  Case 2
            '    m_receive.PayeeAddress1 = arr(0).ToString
            '    m_receive.PayeeAddress2 = arr(1).ToString
            '  Case 3
            '    m_receive.PayeeAddress1 = arr(0).ToString
            '    m_receive.PayeeAddress2 = arr(1).ToString
            '    m_receive.PayeeAddress3 = arr(2).ToString
            '  Case 4
            '    m_receive.PayeeAddress1 = arr(0).ToString
            '    m_receive.PayeeAddress2 = arr(1).ToString
            '    m_receive.PayeeAddress3 = arr(2).ToString
            '    m_receive.PayeeAddress4 = arr(3).ToString
            'End Select
            m_receive.BeneRef = item.Entity.Supplier.Code
            m_receive.TaxID = ""
            If Not item.WHTCollection Is Nothing AndAlso item.WHTCollection.Count > 0 Then
              If item.Entity.Supplier.PersonType.Value = 1 Then
                m_receive.TaxID = item.WHTCollection(0).EntityTaxId
                m_receive.PersonalID = item.WHTCollection(0).EntityTaxId
              Else
                m_receive.TaxID = item.WHTCollection(0).EntityIdNo
                m_receive.PersonalID = ""
              End If
            End If
            If m_receive.TaxID.Trim.Length = 0 Then
              If item.Entity.Supplier.PersonType.Value = 1 Then
                m_receive.TaxID = item.Entity.Supplier.IdNo
                m_receive.PersonalID = item.Entity.Supplier.IdNo
              Else
                m_receive.TaxID = item.Entity.Supplier.TaxId
                m_receive.PersonalID = ""
              End If
            End If
            If m_receive.TaxID Is Nothing Then
              m_receive.TaxID = ""
            End If
            If m_receive.PersonalID Is Nothing Then
              m_receive.PersonalID = ""
            End If
          End If
          If item.WHTCollection.Count > 0 Then
            m_receive.BeneRef = item.WHTCollection(0).Code  'item.GetWHTCodeList
          End If
          m_receive.Detail = item.Detail
          m_receive.DeliveryMethod = item.DeliveryMethod
          m_receive.PickupLocationCode = item.PickupCode
          m_receive.DocumentForPickup = item.DocumentForPickup
          m_receive.AttachmentSubfile = ""
          m_receive.AdviceMode = "F"
          If Not item.Entity Is Nothing AndAlso Not item.Entity.Supplier Is Nothing Then
            If item.Entity.Supplier.FaxforExport Is Nothing OrElse item.Entity.Supplier.FaxforExport.Length = 0 Then
              Dim fax As String = CStr(Configuration.GetConfig("FixedFaxNumberToExportCheck"))

              m_receive.FaxNo = fax
            Else
              m_receive.FaxNo = item.Entity.Supplier.FaxforExport
            End If
          End If
          m_receive.EmailID = ""
          m_receive.TotalInvAmtBefVAT = item.WHTCollection.WitholdingTaxbase
          m_receive.TotalTaxDeductedAmt = item.WHTCollection.Amount
          m_receive.TotalInvAmtAfterVAT = item.WHTCollection.WitholdingTaxbase + item.WHTCollection.Amount
          m_receive.TaxInfoCount = item.WHTCollection.Count

          'Dim whtIndex As Integer = 1
          Dim m_receiveVatList As New List(Of ChequePaymentVat)
          For Each wht As WitholdingTax In item.WHTCollection
            For Each row As TreeRow In wht.ItemTable.Rows
              Dim m_vatreceive As New ChequePaymentVat
              Dim whti As New WitholdingTaxItem
              whti.CopyFromDataRow(row)

              m_vatreceive.PartIdentifier = "T"
              m_vatreceive.TaxForm = Me.TaxFormCode(wht.Type.Value)
              m_vatreceive.TaxSeq = wht.SequenceNo.Code

              m_vatreceive.TaxRate = whti.TaxRate
              m_vatreceive.TypeofTaxDeducted = whti.Description
              m_vatreceive.InvAmtBefVAT = whti.TaxBase
              m_vatreceive.TaxDeductedAmt = whti.Amount
              m_vatreceive.InvAmtAfterVAT = Math.Round(whti.TaxBase + whti.Amount, DigitConfig.Price)

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


#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return ""
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "ExportOutgoingCheck"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Payer builk ID
      dpi = New DocPrintingItem
      dpi.Mapping = "PayerBuilkID"
      dpi.Value = CStr(Configuration.GetConfig("CompanyId"))
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Payment track ID
      dpi = New DocPrintingItem
      dpi.Mapping = "PaymentTrackID"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'เลขที่เอกสาร
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'วันที่เอกสาร
      dpi = New DocPrintingItem
      dpi.Mapping = "IssueDate"
      dpi.Value = Me.IssueDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'วันที่เอกสาร
      dpi = New DocPrintingItem
      dpi.Mapping = "IssueDate"
      dpi.Value = Me.IssueDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'วันที่ต้องการให้มีผล
      dpi = New DocPrintingItem
      dpi.Mapping = "EffectiveDate"
      dpi.Value = Me.EffectiveDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'วันที่ให้ผู้มารับเช็ค
      dpi = New DocPrintingItem
      dpi.Mapping = "PickUpDate"
      dpi.Value = Me.PickUpDate.ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Not BankAccount Is Nothing Then
        'รหัสสมุดเงินฝาก
        dpi = New DocPrintingItem
        dpi.Mapping = "BankAccountCode"
        dpi.Value = Me.BankAccount.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ชื่อสมุดเงินฝาก
        dpi = New DocPrintingItem
        dpi.Mapping = "BankAccountName"
        dpi.Value = Me.BankAccount.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        If Not BankAccount.BankBranch Is Nothing Then
          'รหัสสาขาธนาคาร
          dpi = New DocPrintingItem
          dpi.Mapping = "BankBranchCode"
          dpi.Value = Me.BankAccount.BankBranch.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'ชื่อสาขาธนาคาร
          dpi = New DocPrintingItem
          dpi.Mapping = "BankBranchName"
          dpi.Value = Me.BankAccount.BankBranch.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          If Not Me.BankAccount.BankBranch.Bank Is Nothing Then
            'รหัสธนาคาร
            dpi = New DocPrintingItem
            dpi.Mapping = "BankCode"
            dpi.Value = Me.BankAccount.BankBranch.Bank.Code
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'ชื่อธนาคาร
            dpi = New DocPrintingItem
            dpi.Mapping = "BankName"
            dpi.Value = Me.BankAccount.BankBranch.Bank.Name
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)
          End If
        End If
      End If

      'จัดเก็บค่าธรรมเนียม
      dpi = New DocPrintingItem
      dpi.Mapping = "Chargee"
      dpi.Value = Me.Chargee
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      If Not Me.TreeManager Is Nothing Then
        Dim i As Integer = 0
        Dim rowIndex As Integer = 0
        For Each row As TreeRow In Me.TreeManager.Treetable.Rows
          i += 1
          If i > 3 Then
            rowIndex += 1
            For Each col As DataColumn In Me.TreeManager.Treetable.Columns
              dpi = New DocPrintingItem
              dpi.Mapping = col.ColumnName
              dpi.Value = row(col.ColumnName)
              dpi.DataType = "System.String"
              dpi.Row = rowIndex
              dpi.Table = "Item"
              dpiColl.Add(dpi)
            Next
          End If
        Next
      End If

      Return dpiColl
    End Function
#End Region

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
        'If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
        'AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
        '  .m_entity = New OutgoingCheck(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
        'End If
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

    Public Sub FillData(ByVal newRefresh As Boolean)
      If Not Me.Entity Is Nothing Then

        Dim i As Integer = 0
        Me.WHTCollection = New WitholdingTaxCollection
        Me.AmountBeforeVat = 0
        Me.AmountWHT = 0
        Me.AmountAfterVat = 0
        Me.TaxCount = 0

        If Not newRefresh Then 'Me.ExportOutgoingCheck.Originated Then
          Me.PVCode = ExportOutgoingCheck.GetPVCodeListByCheckId(Me.Entity.Id)
          Me.AmountBeforeVat = ExportOutgoingCheck.GetVATAmountByCheckId(Me.Entity.Id)
          Me.AmountAfterVat = ExportOutgoingCheck.GetVATTaxBaseByCheckId(Me.Entity.Id)
          Dim whtcol As WitholdingTaxCollection = Me.ExportOutgoingCheck.GetWHTCollectionByCheckId(Me.Entity.Id)
          For Each wht As WitholdingTax In whtcol
            Me.WHTCollection.Add(wht)
          Next
          Me.TaxCount = whtcol.Count

        Else
          Me.Entity.ReLoadItems()
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
        Dim drh As New DataRowHelper(row)
        Dim item As New ExportOutgoingCheckItem(row, "")
        Dim chkrow As DataRow() = ds.Tables(1).Select("check_id=" & drh.GetValue(Of String)("eochecki_entity"))
        If chkrow.Length > 0 Then
          item.Entity = New OutgoingCheck(chkrow(0), "")
        End If
        item.ExportOutgoingCheck = m_exportOutgoingCheck
        item.FillData(False)
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
        'eoci.FillData()
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

  Public Class BuilkExportConfirmInfo
    Public CheckCode As String
    Public SupplierName As String
    Public CheckAmount As String
  End Class

End Namespace
