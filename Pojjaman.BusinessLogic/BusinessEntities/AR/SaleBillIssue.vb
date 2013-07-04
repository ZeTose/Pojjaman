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
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class SaleBillIssueStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "salebilli_status"
      End Get
    End Property
#End Region

  End Class
  Public Class SaleBillIssue
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IHasIBillablePerson, ICancelable, ICheckPeriod, IDocStatus, INewPrintableEntity

#Region "Members"
    Private m_customer As Customer
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_employee As Employee
    Private m_note As String
    Private m_creditPeriod As Integer

    Private m_status As SaleBillIssueStatus

    Private m_itemCollection As SaleBillIssueItemCollection
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
        .m_employee = New Employee
        .m_customer = New Customer
        .m_creditPeriod = 0
        .m_note = ""
        .m_docDate = Date.Now.Date
        .m_olddocDate = Date.Now.Date
        .m_status = New SaleBillIssueStatus(-1)
        m_itemCollection = New SaleBillIssueItemCollection(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains("customer.cust_id") Then
          If Not dr.IsNull("customer.cust_id") Then
            .m_customer = New Customer(dr, "customer.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "salebilli_cust") Then
            .m_customer = New Customer(CInt(dr(aliasPrefix & "salebilli_cust")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_employee") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_employee") Then
          .m_employee = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_employee")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "salebilli_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "salebilli_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & "salebilli_creditperiod"))
        End If

        If dr.Table.Columns.Contains("salebilli_docDate") AndAlso Not dr.IsNull(aliasPrefix & "salebilli_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "salebilli_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & "salebilli_docDate"))
        End If

        If dr.Table.Columns.Contains("salebilli_note") AndAlso Not dr.IsNull(aliasPrefix & "salebilli_note") Then
          .m_note = CStr(dr(aliasPrefix & "salebilli_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "salebilli_status") AndAlso Not dr.IsNull(aliasPrefix & "salebilli_status") Then
          .m_status = New SaleBillIssueStatus(CInt(dr(aliasPrefix & "salebilli_status")))
        End If
        m_itemCollection = New SaleBillIssueItemCollection(Me)

      End With
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollection() As SaleBillIssueItemCollection      Get        Return m_itemCollection      End Get      Set(ByVal Value As SaleBillIssueItemCollection)        m_itemCollection = Value      End Set    End Property    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        m_customer = Value      End Set    End Property    Public Property Employee() As Employee      Get        Return m_employee      End Get      Set(ByVal Value As Employee)        m_employee = Value      End Set    End Property    Public Property DocDate() As Date Implements ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value      End Set    End Property    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return m_olddocDate
      End Get
    End Property    Public ReadOnly Property DueDate() As Date
      Get
        Try
          Return Me.DocDate.AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.DocDate
        End Try
      End Get
    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, SaleBillIssueStatus)      End Set    End Property    Public ReadOnly Property Gross() As Decimal      Get        Return Me.ItemCollection.Amount      End Get    End Property    Public ReadOnly Property RemainingAmount() As Decimal      Get        Return Me.ItemCollection.RemainingAmount      End Get    End Property    Public ReadOnly Property ItemCount() As Integer      Get        Return Me.ItemCollection.Count      End Get    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "SaleBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "salebilli"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "SaleBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SaleBillIssue.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.SaleBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.SaleBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SaleBillIssue.ListLabel}"
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
      Dim myDatatable As New TreeTable("SaleBillIssue")

      myDatatable.Columns.Add(New DataColumn("salebillii_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("salebillii_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("salebillii_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))

      Dim dateCol As New DataColumn("DocDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("DueDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      myDatatable.Columns.Add(New DataColumn("salebillii_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnreceivedAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("salebillii_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("refdoc", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("reftype", GetType(String)))

      'เพื่อให้แสดง error ตามคอลัมน์เป็นภาษาที่ต้องการ
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.CodeHeaderText}")
      myDatatable.Columns("salebillii_amt").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleBillIssueDetail.AmountHeaderText}")
      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
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
          paramArrayList.Add(New SqlParameter("@salebilli_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@salebilli_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@salebilli_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@salebilli_cust", Me.ValidIdOrDBNull(Me.Customer)))
        paramArrayList.Add(New SqlParameter("@salebilli_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_employee", Me.ValidIdOrDBNull(Me.Employee)))
        paramArrayList.Add(New SqlParameter("@salebilli_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@salebilli_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@salebilli_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldcode As String
        Dim oldautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen

        Try

          Try
            Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
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

            SaveDetail(Me.Id, conn, trans)

            'Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGS_SBIRef" _
            ', New SqlParameter("@salebilli_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateARO_SBIRef" _
            ', New SqlParameter("@salebilli_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetSold_SBIRef" _
            ', New SqlParameter("@salebilli_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQR_SBIRef" _
            ', New SqlParameter("@salebilli_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWO_SBIRef" _
            ', New SqlParameter("@salebilli_id", Me.Id))
            'If Me.Status.Value = 0 Then
            '  Me.CancelRef(conn, trans)
            'End If
            trans.Commit()
            ' Return New SaveErrorException(returnVal.Value.ToString)
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
            'Finally
            '  conn.Close()
          End Try

          'Sub Save Block
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
          'Sub Save Block

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
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGS_SBIRef" _
        , New SqlParameter("@salebilli_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateARO_SBIRef" _
        , New SqlParameter("@salebilli_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAssetSold_SBIRef" _
        , New SqlParameter("@salebilli_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQR_SBIRef" _
        , New SqlParameter("@salebilli_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWO_SBIRef" _
        , New SqlParameter("@salebilli_id", Me.Id))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      Return New SaveErrorException("0")
    End Function

    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each billi As SaleBillIssueItem In Me.ItemCollection
        ret &= billi.Id.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

      Dim da As New SqlDataAdapter("Select * from salebillissueitem where salebillii_salebilli=" & Me.Id, conn)

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
      da.FillSchema(ds, SchemaType.Mapped, "SaleBillIssueItem")
      da.Fill(ds, "SaleBillIssueItem")

      Dim dt As DataTable = ds.Tables("SaleBillIssueItem")

      Dim i As Integer = 0
      With ds.Tables("SaleBillIssueItem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each billi As SaleBillIssueItem In Me.ItemCollection
          i += 1
          Dim dr As DataRow = .NewRow
          dr("salebillii_salebilli") = Me.Id
          dr("salebillii_linenumber") = i
          dr("stock_id") = billi.Id
          dr("stock_code") = billi.Code
          dr("stock_type") = billi.EntityId
          dr("stock_docdate") = billi.Date
          dr("stock_creditprd") = billi.CreditPeriod
          dr("stock_beforetax") = billi.BeforeTax
          dr("stock_aftertax") = billi.AfterTax
          dr("stock_taxbase") = billi.TaxBase
          dr("salebillii_amt") = billi.Amount
          dr("salebillii_billedamt") = billi.Amount '****** Hack
          dr("salebillii_unreceivedamt") = billi.UnreceivedAmount
          dr("stock_note") = billi.Note
          dr("stock_status") = Me.Status.Value
          .Rows.Add(dr)
        Next
      End With

      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      da.Update(GetDeletedRows(dt))
      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      da.Update(dt.Select("", "", DataViewRowState.Added))
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Function GetVatCodeFromSproc(ByVal sproc As String, ByVal StockId As Integer) As DataTable
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
            Me.ConnectionString _
            , CommandType.StoredProcedure _
            , sproc _
            , New SqlParameter("@stock_id", StockId) _
            )
        Return ds.Tables(0)
      Catch ex As Exception
      End Try
    End Function
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
    Public Shared Function GetBillissue(ByVal txtCode As TextBox, ByRef oldBA As SaleBillIssue) As Boolean
      Dim newBA As New SaleBillIssue(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newBA.Valid Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        newBA = oldBA
      End If
      txtCode.Text = newBA.Code
      If oldBA Is Nothing OrElse oldBA.Id <> newBA.Id Then
        oldBA = newBA
        Return True
      End If
      'oldBA = newBA
      Return False
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "SaleBillIssue"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "SaleBillIssue"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "billi_id"
      dpi.Value = Me.Id
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

      If Not Me.Customer Is Nothing AndAlso Me.Customer.Originated Then
        'CustomerInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerInfo"
        dpi.Value = Me.Customer.Code & ":" & Me.Customer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCode"
        dpi.Value = Me.Customer.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerName
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerName"
        dpi.Value = Me.Customer.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerAddress"
        dpi.Value = Me.Customer.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CustomerCurrentAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CustomerCurrentAddress"
        dpi.Value = Me.Customer.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
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

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Me.CreditPeriod
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.Datetime"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      Dim InvoiceStr As String = ""
      For Each item As SaleBillIssueItem In Me.ItemCollection
        dpi = New DocPrintingItem
        dpi.Mapping = "billii_billi"
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

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Date
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Date"
        dpi.Value = item.Date.ToShortDateString
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        Dim type As New ReceivableItemType(item.EntityId)
        If Not item.Note Is Nothing AndAlso item.Note.Length > 0 Then
          dpi.Value = type.Description & " - " & item.Note
        Else
          dpi.Value = type.Description
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

        Dim tmpVatCode As String = ""
        If item.EntityId = 83 Then
          Dim dt As DataTable = GetVatCodeFromSproc("GetVatCodeFromSaleBillIssueItem", item.Id)
          If Not dt Is Nothing Then
            For Each row As DataRow In dt.Rows
              If Not row.IsNull("VatCode") Then
                tmpVatCode &= row("VatCode").ToString & ","
              End If
            Next
          End If
          If tmpVatCode.Length > 0 Then
            tmpVatCode = tmpVatCode.Substring(0, tmpVatCode.Length - 1)
          End If
        End If

        'Item.Invoice
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Invoice"
        dpi.Value = tmpVatCode
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        n += 1
      Next

      ''Check สำหรับ Customize ของวีสถาปัตต์ วีคอนกรึต ===========================================>>>
      Dim hasVArch As Boolean = False
      For Each a As AddIn In AddInTreeSingleton.AddInTree.AddIns
        If a.FileName.ToLower.Contains("pojjaman.base.form.varch") Then
          hasVArch = True
        End If
      Next
      If hasVArch Then
        dpiColl.AddRange(GetDocVPCustomizePrintingEntries)
      End If
      ''Check สำหรับ Customize ของวีสถาปัตต์ วีคอนกรึต ===========================================<<<

      Return dpiColl
    End Function

    Public Function GetDocVPCustomizePrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'วันที่ใบวางบิล
      dpi = New DocPrintingItem
      dpi.Mapping = "BillDocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'รหัสใบวางบิล
      dpi = New DocPrintingItem
      dpi.Mapping = "BillDocCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'รหัสลูกค้า
      dpi = New DocPrintingItem
      dpi.Mapping = "BillCustomerCode"
      If Me.Customer IsNot Nothing Then
        dpi.Value = Me.Customer.Code
      Else
        dpi.Value = ""
      End If
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'ชื่อลูกค้า
      dpi = New DocPrintingItem
      dpi.Mapping = "BillCustomerName"
      If Me.Customer IsNot Nothing Then
        dpi.Value = Me.Customer.Name
      Else
        dpi.Value = ""
      End If
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'ที่อยู่ลูกค้า
      dpi = New DocPrintingItem
      dpi.Mapping = "BillCustomerBillingAddress"
      If Me.Customer IsNot Nothing Then
        dpi.Value = Me.Customer.BillingAddress
      Else
        dpi.Value = ""
      End If
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'เครดิต(วัน)
      dpi = New DocPrintingItem
      dpi.Mapping = "BillCreditPeriod"
      dpi.Value = Configuration.FormatToString(Me.CreditPeriod, DigitConfig.Int)
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'กำหนดชำระ
      dpi = New DocPrintingItem
      dpi.Mapping = "BillDueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'ยอดวางบิล
      dpi = New DocPrintingItem
      dpi.Mapping = "BillGross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'หมายเหตุ
      dpi = New DocPrintingItem
      dpi.Mapping = "BillNote"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'ผู้วางบิล
      dpi = New DocPrintingItem
      dpi.Mapping = "BillEmployee"
      dpi.Value = Me.Employee.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Dim sumCol9 As Decimal = 0
      'Dim sumCol10 As Decimal = 0
      'Dim sumCol11 As Decimal = 0

      Dim sumDiscount As Decimal = 0
      Dim sumTaxAmount As Decimal = 0
      Dim sumAmount As Decimal = 0

      Dim n As Integer = 1

      Dim LineNumber As Integer = 0
      For Each item As SaleBillIssueItem In Me.ItemCollection
        dpi = New DocPrintingItem
        dpi.Mapping = "billii_billi"
        dpi.Value = Me.Id
        dpi.DataType = "System.String"
        dpi.Row = n
        dpi.Table = "BillItem"
        dpiColl.Add(dpi)

        'ขายสินค้า/บริการ
        If item.EntityId = 83 Then

          Dim doc As New GoodsSold(item.Id)
          LineNumber += 1

          'ลำดับรายการวางบิล
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = LineNumber
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          'วันที่เอกสาร
          dpi = New DocPrintingItem
          'dpi.Mapping = "BillDocDate"
          dpi.Mapping = "col1"
          dpi.Value = item.Date.ToShortDateString
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          'เลขที่ใบส่งสินค้า
          dpi = New DocPrintingItem
          'dpi.Mapping = "BillDocCode"
          dpi.Mapping = "col2"
          dpi.Value = item.Code
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          'เลขที่ใบกำกับ
          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          If doc.Vat.ItemCollection.Count > 0 Then
            dpi.Value = doc.Vat.ItemCollection(0).Code
          End If
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          'หมายเหตุ
          dpi = New DocPrintingItem
          'dpi.Mapping = "BillAmount"
          dpi.Mapping = "col12"
          dpi.Value = item.Note
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          Dim ItemlineNumber As Integer = 0
          For Each docitem As GoodsSoldItem In doc.ItemCollection

            ItemlineNumber += 1
            'LineNumber
            dpi = New DocPrintingItem
            dpi.Mapping = "col4"
            dpi.Value = ItemlineNumber
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'รายการ
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillDescription"
            dpi.Mapping = "col5"
            dpi.Value = docitem.EntityName
            If docitem.Entity IsNot Nothing Then
              'Dim name As String = ""
              'If docitem.EntityName.Length > 0 Then
              '  name = " <" & docitem.EntityName & ">"
              'End If
              If docitem.Entity.Name.Length > 0 Then
                dpi.Value = docitem.Entity.Name '& name
              End If
            End If
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'จำนวน
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillQty"
            dpi.Mapping = "col6"
            dpi.Value = Configuration.FormatToString(docitem.Qty, DigitConfig.Qty)
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'หน่วย
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillUnitName"
            dpi.Mapping = "col7"
            dpi.Value = ""
            If docitem.Unit IsNot Nothing Then
              dpi.Value = docitem.Unit.Name
            End If
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'ราคา/หน่วย
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillUnitPrice"
            dpi.Mapping = "col8"
            dpi.Value = Configuration.FormatToString(docitem.UnitPrice, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'จำนวนเงิน
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillAmount"
            dpi.Mapping = "col9"
            dpi.Value = Configuration.FormatToString(docitem.Amount, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'ภาษีมูลค่าเพิ่ม
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillDisCount"
            dpi.Mapping = "col10"
            dpi.Value = Configuration.FormatToString(docitem.TaxAmount, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'รวมเงิน
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillDisCount"
            dpi.Mapping = "col11"
            If doc.TaxType.Value = 2 Then 'รวม VAT
              dpi.Value = Configuration.FormatToString(docitem.Amount, DigitConfig.Price)
            Else
              dpi.Value = Configuration.FormatToString(docitem.Amount + docitem.TaxAmount, DigitConfig.Price)
            End If
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'sumCol9 += docitem.Amount
            'sumCol10 += docitem.TaxAmount
            'sumCol11 += (docitem.Amount + docitem.TaxAmount)

            n += 1
          Next

          '' เพิ่มแถว ของท้ายรายการ =================== 
          'n += 1
          ''sumCol9
          'dpi = New DocPrintingItem
          'dpi.Mapping = "col9"
          'dpi.Value = Configuration.FormatToString(sumCol9, DigitConfig.Price)
          'dpi.DataType = "System.String"
          'dpi.Row = n
          'dpi.Table = "BillItem"
          'dpiColl.Add(dpi)

          ''sumCol10
          'dpi = New DocPrintingItem
          'dpi.Mapping = "col10"
          'dpi.Value = Configuration.FormatToString(sumCol10, DigitConfig.Price)
          'dpi.DataType = "System.String"
          'dpi.Row = n
          'dpi.Table = "BillItem"
          'dpiColl.Add(dpi)

          ''sumCol11
          'dpi = New DocPrintingItem
          'dpi.Mapping = "col11"
          'dpi.Value = Configuration.FormatToString(sumCol11, DigitConfig.Price)
          'dpi.DataType = "System.String"
          'dpi.Row = n
          'dpi.Table = "BillItem"
          'dpiColl.Add(dpi)

          sumDiscount += doc.DiscountAmount
          'If doc.TaxType.Value = 0 OrElse doc.TaxType.Value = 1 Then
          '  sumDiscount += doc.AdvancePayItemCollection.GetExcludeVATAmount
          'Else
          '  sumDiscount += doc.AdvancePayItemCollection.GetAmount
          'End If
          sumTaxAmount += doc.TaxAmount
          sumAmount += doc.AfterTax

        End If

      Next

      'SumDiscount
      dpi = New DocPrintingItem
      dpi.Mapping = "BillSumDiscount"
      dpi.Value = Configuration.FormatToString(sumDiscount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SumTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "BillSumTaxAmount"
      dpi.Value = Configuration.FormatToString(sumTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SumAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "BillSumAmount"
      dpi.Value = Configuration.FormatToString(sumAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteSaleBillIssue}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteSaleBillIssue", New SqlParameter() {New SqlParameter("@salebillii_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.SaleBillIssueIsReferencedCannotBeDeleted}")
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

#Region "IHasIBillablePerson"
    Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
      Get
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Customer Then
          Me.Customer = CType(Value, Customer)
        End If
      End Set
    End Property
#End Region

#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else

        End If
        Return ""
      End Get
    End Property
#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.RelationList.Add("general>billi_id>item>billii_billi")
      dpiColl.RelationList.Add("general>billi_id>BillItem>billii_billi")

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("billi_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Customer", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CustomerCurrentAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("LastEditor", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreditPeriod", "System.Integer"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DueDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Gross", "System.Decimal"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("billii_billi", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Date", "System.DateTime", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Invoice", "System.String", "Item"))

      ''Check สำหรับ Customize ของวีสถาปัตต์ วีคอนกรึต ===========================================>>>
      dpiColl.AddRange(GetDocVPCustomizePrintingEntriesColumns)
      ''Check สำหรับ Customize ของวีสถาปัตต์ วีคอนกรึต ===========================================<<<

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function

    Public Function GetDocVPCustomizePrintingEntriesColumns() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillDocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillDocCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillCustomerCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillCustomerName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillCustomerBillingAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillCreditPeriod", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillDueDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillGross", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillNote", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillEmployee", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillSumDiscount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillSumTaxAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BillSumAmount", "System.Decimal"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("billii_billi", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col0", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col1", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col2", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col3", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col4", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col5", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col6", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col7", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col8", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col9", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col10", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col11", "System.String", "BillItem"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("col12", "System.String", "BillItem"))

      Return dpiColl
    End Function
#End Region


  End Class

  Public Class SaleBillIssueItem
    Inherits SimpleBusinessEntityBase
    Implements ISaleBillIssuable

#Region "Members"
    Private m_realAmount As Decimal
    Private m_beforeTax As Decimal
    Private m_afterTax As Decimal
    Private m_taxBase As Decimal
    Private m_unReceivedAmount As Decimal
    Private m_amount As Decimal
    Private m_note As String
    Private m_saleBillIssue As SaleBillIssue
    Private m_typeId As Integer
    Private m_docDate As Date
    Private m_creditPeriod As Integer
    Private m_receives As ReceiveSelection
    Private m_itemprefix As String

    Private m_billedAmount As Decimal 'ยอดวางบิล

    Private m_linenumber As Integer

    Private m_parentId As Integer
    Private m_parentCode As String
    Private m_parentType As Integer

    Private m_stockid As Integer
    Private m_ARretention As Decimal  'ยอดหัก Retention

    Private m_taxrate As Decimal
    Private m_taxtype As TaxType

    Private m_deductedTaxbase As Nullable(Of Decimal)
    Private m_deductedVatAmt As Nullable(Of Decimal)

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal receivable As ISaleBillIssuable, ByVal billi As SaleBillIssue)
      MyBase.New()
      m_saleBillIssue = billi
      m_itemprefix = "salebillii"
      Construct(receivable)
    End Sub
    Public Sub New(ByVal receivable As ISaleBillIssuable, ByVal receives As ReceiveSelection)
      MyBase.New()
      m_receives = receives
      m_itemprefix = "receivesi"
      Construct(receivable)
    End Sub
    Public Overloads Sub Construct(ByVal receivable As ISaleBillIssuable)
      Me.Id = receivable.Id
      Me.Code = receivable.Code
      Me.RealAmount = receivable.AmountToReceive
      Me.BilledAmount = Me.RealAmount
      Me.CreditPeriod = CInt(DateDiff(DateInterval.Day, receivable.Date, receivable.DueDate))
      If Not m_saleBillIssue Is Nothing AndAlso m_saleBillIssue.Originated Then
        Me.UnreceivedAmount = receivable.GetRemainingAmountWithBillIssue(m_saleBillIssue.Id)
      Else
        Me.UnreceivedAmount = receivable.GetRemainingAmountReceiveSelection(m_receives.Id)
      End If
      If TypeOf receivable Is ISimpleEntity Then
        m_typeId = CType(receivable, ISimpleEntity).EntityId
      End If
      If TypeOf receivable Is IHasVat Then
        m_taxrate = CType(receivable, IHasVat).Taxrate
        m_taxtype = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        If CType(receivable, IHasVat).Taxtype IsNot Nothing Then
          m_taxtype = CType(receivable, IHasVat).Taxtype
        End If
      End If
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal billi As SaleBillIssue)
      m_saleBillIssue = billi
      m_itemprefix = "salebillii"
      Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal receives As ReceiveSelection)
      m_receives = receives
      m_itemprefix = "receivesi"
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      If dr.Table.Columns.Contains(aliasPrefix & "stock_aftertax") AndAlso Not dr.IsNull(aliasPrefix & "stock_aftertax") Then
        Me.m_afterTax = CDec(dr(aliasPrefix & "stock_aftertax"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_beforeTax") AndAlso Not dr.IsNull(aliasPrefix & "stock_beforeTax") Then
        Me.m_beforeTax = CDec(dr(aliasPrefix & "stock_beforeTax"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_taxBase") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxBase") Then
        Me.m_taxBase = CDec(dr(aliasPrefix & "stock_taxBase"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_type") AndAlso Not dr.IsNull(aliasPrefix & "stock_type") Then
        Me.m_typeId = CInt(dr(aliasPrefix & "stock_type"))
        If m_typeId <> 83 AndAlso m_typeId <> 366 Then
          ARretention = getARretention()
        End If
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_docdate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docdate") Then
        Me.m_docDate = CDate(dr(aliasPrefix & "stock_docdate"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_creditprd") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditprd") Then
        Me.m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditprd"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditperiod") Then
        If Me.m_creditPeriod = 0 Then
          Me.m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditperiod"))
        End If
      End If
      Me.m_realAmount = Me.m_afterTax
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_amt") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_amt") Then
        Me.m_amount = CDec(dr(aliasPrefix & m_itemprefix & "_amt"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
        Me.m_note = CStr(dr(aliasPrefix & "stock_note"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_linenumber") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_linenumber") Then
        Me.m_linenumber = CInt(dr(aliasPrefix & m_itemprefix & "_linenumber"))
      End If
      '********************************************************
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_parentEntityCode") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_parentEntityCode") Then
        Me.m_parentCode = CStr(dr(aliasPrefix & m_itemprefix & "_parentEntityCode"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_parentEntity") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_parentEntity") Then
        Me.m_parentId = CInt(dr(aliasPrefix & m_itemprefix & "_parentEntity"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_parentEntityType") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_parentEntityType") Then
        Me.m_parentType = CInt(dr(aliasPrefix & m_itemprefix & "_parentEntityType"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "remain") AndAlso Not dr.IsNull(aliasPrefix & "remain") Then
        'มาจากหน้า list ของแต่ละ entity (ไม่ได้มาจาก list ของใบวางบิล)
        Select Case m_itemprefix
          Case "receivesi"
            If Not m_receives Is Nothing Then
              Me.m_unReceivedAmount = Me.GetRemainingAmountReceiveSelection(Me.m_receives.Id)
            End If
          Case "salebillii"
            If Not m_saleBillIssue Is Nothing Then
              Me.m_unReceivedAmount = Me.GetRemainingAmountWithBillIssue(Me.m_saleBillIssue.Id)
            End If
        End Select
        Me.m_billedAmount = Me.m_unReceivedAmount
        'Me.m_amount = CDec(dr(aliasPrefix & "remain"))
        'Me.m_unReceivedAmount = CDec(dr(aliasPrefix & "remain"))
      End If

      If dr.Table.Columns.Contains(aliasPrefix & "stock_retention") AndAlso Not dr.IsNull(aliasPrefix & "stock_retention") Then
        Select Case m_itemprefix
          Case "receivesi"
            If Not m_receives Is Nothing Then
              Me.ARretention = CDec(dr(aliasPrefix & "stock_retention"))
            End If
        End Select

      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_unreceivedamt") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_unreceivedamt") Then
        Me.m_unReceivedAmount = CDec(dr(aliasPrefix & m_itemprefix & "_unreceivedamt"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_billedamt") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_billedamt") Then
        Me.m_billedAmount = CDec(dr(aliasPrefix & m_itemprefix & "_billedamt"))
      End If
      '********************************************************

      If dr.Table.Columns.Contains(aliasPrefix & "stock_id") AndAlso Not dr.IsNull(aliasPrefix & "stock_id") Then
        Me.m_stockid = CInt(dr(aliasPrefix & "stock_id"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxtype") Then
        Me.m_taxtype = New TaxType(CInt(dr(aliasPrefix & "stock_taxtype")))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_taxrate") AndAlso Not dr.IsNull(aliasPrefix & "stock_taxrate") Then
        Me.m_taxrate = CDec(dr(aliasPrefix & "stock_taxrate"))
      End If

    End Sub
#End Region

#Region "Properties"
    Public Property SaleBillIssue() As SaleBillIssue      Get        Return m_saleBillIssue      End Get      Set(ByVal Value As SaleBillIssue)        m_saleBillIssue = Value      End Set    End Property    Public Property ReceiveSelection() As ReceiveSelection      Get        Return m_receives      End Get      Set(ByVal Value As ReceiveSelection)        m_receives = Value      End Set    End Property    Public Property DeductedTaxBase As Nullable(Of Decimal)
      Get
        If m_deductedTaxbase.HasValue Then
          Return m_deductedTaxbase.Value
        End If
        Return Nothing
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        m_deductedTaxbase = value
      End Set
    End Property    Public Property DeductedVatAmt As Nullable(Of Decimal)
      Get
        If m_deductedVatAmt.HasValue Then
          Return m_deductedVatAmt.Value
        End If
        Return Nothing
      End Get
      Set(ByVal value As Nullable(Of Decimal))
        m_deductedVatAmt = value
      End Set
    End Property    Public Property VatAmt As Decimal    Public Property Linenumber() As Integer
      Get
        Return m_linenumber
      End Get
      Set(ByVal Value As Integer)
        m_linenumber = Value
      End Set
    End Property    Public Property ParentId() As Integer      Get        Return m_parentId      End Get      Set(ByVal Value As Integer)        m_parentId = Value      End Set    End Property    Public Property ParentCode() As String      Get        Return m_parentCode      End Get      Set(ByVal Value As String)        m_parentCode = Value      End Set    End Property    Public Property ParentType() As Integer      Get        Return m_parentType      End Get      Set(ByVal Value As Integer)        m_parentType = Value      End Set    End Property    Public Property BilledAmount() As Decimal      Get
        Return Me.m_billedAmount
      End Get
      Set(ByVal Value As Decimal)
        Me.m_billedAmount = Value
      End Set
    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Public Property BeforeTax() As Decimal      Get        Return m_beforeTax      End Get      Set(ByVal Value As Decimal)        m_beforeTax = Value      End Set    End Property    Public Property AfterTax() As Decimal      Get        Return m_afterTax      End Get      Set(ByVal Value As Decimal)        m_afterTax = Value      End Set    End Property    Public Property TaxBase() As Decimal      Get        Return m_taxBase      End Get      Set(ByVal Value As Decimal)        m_taxBase = Value      End Set    End Property
    Public Property RealAmount() As Decimal      Get        Return m_realAmount      End Get      Set(ByVal Value As Decimal)        m_realAmount = Value      End Set    End Property    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property
    Public Property UnreceivedAmount() As Decimal      Get        Return m_unReceivedAmount      End Get      Set(ByVal Value As Decimal)        'm_unReceivedAmount = Me.AfterTax - Me.Amount        m_unReceivedAmount = Value      End Set    End Property
    Public Property ARretention() As Decimal
      Get
        Dim tmp As Object = Configuration.GetConfig("ARRetentionPoint")
        Dim apRetentionPoint As Integer = 0
        If IsNumeric(tmp) Then
          apRetentionPoint = CInt(tmp)
        End If
        Dim retentionHere As Boolean = (apRetentionPoint = 1)
        If retentionHere Then
          Return m_ARretention
        Else
          Return 0
        End If
      End Get
      Set(ByVal Value As Decimal)        m_ARretention = Value      End Set
    End Property
    Public Property BillIretention() As Decimal
      Get
        Dim tmp As Object = Configuration.GetConfig("ARRetentionPoint")
        Dim apRetentionPoint As Integer = 0
        If IsNumeric(tmp) Then
          apRetentionPoint = CInt(tmp)
        End If
        Dim atBill As Boolean = (apRetentionPoint = 0)
        If atBill Then
          Return m_ARretention
        Else
          Return m_ARretention
        End If
      End Get
      Set(ByVal Value As Decimal)        m_ARretention = Value      End Set
    End Property

    Public ReadOnly Property Retention() As Decimal
      Get
        Return m_ARretention
      End Get
    End Property
    Public ReadOnly Property AmountForGL As Decimal
      Get
        If Me.EntityId = 79 OrElse Me.EntityId = 48 Then
          Return -Me.Amount
        Else
          Return Me.Amount
        End If
      End Get
    End Property

    Public ReadOnly Property TaxRate As Decimal
      Get
        Return m_taxrate
      End Get
    End Property
    Public ReadOnly Property TaxType As TaxType
      Get
        Return m_taxtype
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "SaleBillIssueItem"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property EntityId() As Integer
      Get
        Return m_typeId
      End Get
    End Property
    Public Property StockId() As Integer
      Get
        Return m_stockid
      End Get
      Set(ByVal Value As Integer)
        m_stockid = Value
      End Set
    End Property
#End Region

#Region "Methods"
    Public Sub SetType(ByVal type As Integer)
      Me.m_typeId = type
    End Sub
    Public Sub SetTaxType(ByVal _taxtype As Integer)
      Me.m_taxtype = New TaxType(_taxtype)
    End Sub
    Public Sub SetTaxRate(ByVal _taxrate As Decimal)
      Me.m_taxrate = _taxrate
    End Sub
    Public Sub Clear()
      Me.Id = 0
      Me.RealAmount = 0
      Me.Amount = 0
      Me.Code = ""
      Me.Date = Date.MinValue
      Me.UnreceivedAmount = 0
      Me.CreditPeriod = 0
      Me.SetType(-1)
    End Sub
#End Region

#Region "ISaleBillIssuable"
    Public Function AmountToReceive() As Decimal Implements ISaleBillIssuable.AmountToReceive
      Return Me.AfterTax
    End Function
    Public Property [Date]() As Date Implements ISaleBillIssuable.Date
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
      End Set
    End Property
    Public Property DueDate() As Date Implements ISaleBillIssuable.DueDate
      Get
        Try
          Return Me.[Date].AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.[Date]
        End Try
      End Get
      Set(ByVal Value As Date)

      End Set
    End Property
    Public Property Note() As String Implements ISaleBillIssuable.Note
      Get
        Return Me.m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property Receive() As Receive Implements ISaleBillIssuable.Receive
      Get

      End Get
      Set(ByVal Value As Receive)

      End Set
    End Property
    Public ReadOnly Property Payer() As IBillablePerson Implements ISaleBillIssuable.Payer
      Get

      End Get
    End Property
    Public Function RemainingAmount() As Decimal Implements ISaleBillIssuable.RemainingAmount
      Return Me.AfterTax
    End Function
    Public Function GetRemainingAmountWithBillIssue(ByVal salebilli_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountWithBillIssue
      Try
        If Me.ParentType = 81 Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          Me.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetUnreceiveMilestoneAmount" _
          , New SqlParameter("@milestone_id", Me.Id) _
          , New SqlParameter("@salebillii_salebilli", salebilli_id) _
          )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        ElseIf Me.m_typeId = 366 Then 'ถ้าเป็นเอกสาร Writeoff asset
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                  Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , "GetUnreceiveWriteOffAmount" _
                  , New SqlParameter("@stock_id", Me.Id) _
                  , New SqlParameter("@salebillii_salebilli", salebilli_id) _
                  )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        Else
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                  Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , "GetUnreceiveStockAmount" _
                  , New SqlParameter("@stock_id", Me.Id) _
                  , New SqlParameter("@salebillii_salebilli", salebilli_id) _
                  )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelectionFromOtherReceives(ByVal receives_id As Integer) As Decimal
      Try
        If Me.ParentType = 81 Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          Me.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetUnreceiveMilestoneAmountFromOtherReceives" _
          , New SqlParameter("@milestone_id", Me.Id) _
          , New SqlParameter("@receivesi_receives", receives_id) _
          )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        Else
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          Me.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetUnreceiveStockAmountFromOtherReceives" _
          , New SqlParameter("@stock_id", Me.Id) _
          , New SqlParameter("@receivesi_receives", receives_id) _
          )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        If Me.ParentType = 81 Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
          Me.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetUnreceiveMilestoneAmount" _
          , New SqlParameter("@milestone_id", Me.Id) _
          , New SqlParameter("@receivesi_receives", receives_id) _
          )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        ElseIf Me.ParentId <> 0 Then
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                  Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , "GetUnreceiveStockAmount" _
                  , New SqlParameter("@stock_id", Me.Id) _
                  , New SqlParameter("@receivesi_receives", receives_id) _
                  , New SqlParameter("@salebillii_salebilli", Me.ParentId) _
                  )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        ElseIf Me.m_typeId = 48 Then 'ถ้าเป็นเอกสารใบลดหนี้ลูกหนี้
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                  Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , "GetUnreceiveSaleCNAmount" _
                  , New SqlParameter("@stock_id", Me.Id) _
                  , New SqlParameter("@receivesi_receives", receives_id) _
                  )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        ElseIf Me.m_typeId = 366 Then 'ถ้าเป็นเอกสาร Writeoff asset
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                  Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , "GetUnreceiveWriteOffAmount" _
                  , New SqlParameter("@stock_id", Me.Id) _
                  , New SqlParameter("@receivesi_receives", receives_id) _
                  )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        Else
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                  Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , "GetUnreceiveStockAmount" _
                  , New SqlParameter("@stock_id", Me.Id) _
                  , New SqlParameter("@receivesi_receives", receives_id) _
                  )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountReceiveSelection(ByVal receives_id As Integer, ByVal billi_id As Integer) As Decimal Implements ISaleBillIssuable.GetRemainingAmountReceiveSelection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnreceiveStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@receivesi_receives", receives_id) _
                , New SqlParameter("@salebillii_salebilli", receives_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
#End Region

#Region "Shared"
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
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetSaleBillIssueItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("SaleBillIssueItems")
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
      myDatatable.Columns.Add(New DataColumn("stock_id", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stock_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stock_type", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stock_beforetax", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("stock_taxbase", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("stock_aftertax", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("salebillii_unreceivedamt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("salebillii_billedamt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("salebillii_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stock_taxtype", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stock_taxrate", GetType(Decimal)))

      For Each tableRow As DataRow In dt.Rows
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("salebilli_code")
        row("salebilli_id") = tableRow("salebillii_salebilli")
        row("Linenumber") = tableRow("salebillii_linenumber")
        row("Date") = tableRow("salebilli_docdate")
        row("DueDate") = tableRow("salebilli_docdate")
        row("Entity") = tableRow("stock_code")
        row("stock_id") = tableRow("stock_id")
        row("stock_code") = tableRow("stock_code")
        row("stock_type") = tableRow("stock_type")
        If Not tableRow.IsNull("stock_aftertax") Then
          row("Amount") = Configuration.FormatToString(CDec(tableRow("stock_aftertax")), DigitConfig.Price) 'tableRow("billa_gross")
        End If
        row("stock_id") = tableRow("stock_id")
        row("stock_code") = tableRow("stock_code")
        row("stock_type") = tableRow("stock_type")
        row("stock_beforetax") = tableRow("stock_beforetax")
        row("stock_aftertax") = tableRow("stock_aftertax")
        'hack
        Dim receivable As New SaleBillIssueItem
        receivable.Id = CInt(tableRow("stock_id"))
        receivable.ParentId = CInt(tableRow("salebillii_salebilli"))
        row("salebillii_unreceivedamt") = Configuration.FormatToString(receivable.GetRemainingAmountReceiveSelection(receives_id), DigitConfig.Price)
        row("salebillii_billedamt") = tableRow("salebillii_billedamt")
        row("salebillii_linenumber") = tableRow("salebillii_linenumber")
        If tableRow.Table.Columns.Contains("stock_taxtype") AndAlso Not tableRow.IsNull("stock_taxtype") Then
          row("stock_taxtype") = tableRow("stock_taxtype")
        End If
        If tableRow.Table.Columns.Contains("stock_taxrate") AndAlso Not tableRow.IsNull("stock_taxrate") Then
          row("stock_taxrate") = tableRow("stock_taxrate")
        End If
        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.SaleBillIssue.ListLabel}"
      End Get
    End Property
#End Region

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "SaleBillIssueItem"
      End Get
    End Property

    Function getARretention() As Decimal
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMilestoneRetention" _
      , New SqlParameter("@milestone_id", Me.Id) _
      , New SqlParameter("@receives_id", ValidIdOrZero(Me.ReceiveSelection)) _
      )
      If ds.Tables(0).Rows.Count > 0 Then
        Return CDec(ds.Tables(0).Rows(0)(0))
      End If
    End Function

    Function GetRemainingRetention(ByVal recsId As Integer) As Decimal
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMilestoneRetention" _
      , New SqlParameter("@milestone_id", Me.Id) _
      , New SqlParameter("@receives_id", recsId) _
      )
      If ds.Tables(0).Rows.Count > 0 Then
        Return CDec(ds.Tables(0).Rows(0)(0))
      End If
    End Function

    Function GetMilestoneRetention() As Decimal
      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetMilestoneRetention" _
      , New SqlParameter("@milestone_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count > 0 Then
        Return CDec(ds.Tables(0).Rows(0)(0))
      End If
    End Function

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class SaleBillIssueItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_saleBillIssue As SaleBillIssue
    Private m_receives As ReceiveSelection
    Private m_prefix As String
    Private m_showDetail As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal bi As SaleBillIssue)
      m_saleBillIssue = bi
      m_prefix = "salebillii"
      If Not bi.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetSaleBillIssueItems" _
      , New SqlParameter("@salebilli_id", m_saleBillIssue.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New SaleBillIssueItem(row, "", bi)
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal receives As ReceiveSelection)
      m_receives = receives
      m_prefix = "receivesi"
      If Not receives.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetReceiveSelectionItems" _
      , New SqlParameter("@receives_id", receives.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New SaleBillIssueItem(row, "", receives)
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property SaleBillIssue() As SaleBillIssue      Get        Return m_saleBillIssue      End Get      Set(ByVal Value As SaleBillIssue)        m_saleBillIssue = Value      End Set    End Property
    Public Property ReceiveSelection() As ReceiveSelection      Get        Return m_receives      End Get      Set(ByVal Value As ReceiveSelection)        m_receives = Value      End Set    End Property
    Default Public Property Item(ByVal index As Integer) As SaleBillIssueItem
      Get
        Return CType(MyBase.List.Item(index), SaleBillIssueItem)
      End Get
      Set(ByVal value As SaleBillIssueItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property ShowDetail() As Boolean
      Get
        Return m_showDetail
      End Get
      Set(ByVal Value As Boolean)
        m_showDetail = Value
      End Set
    End Property
    Public ReadOnly Property ARretention As Decimal
      Get
        Dim SumRetention As Decimal = 0
        For Each Item As SaleBillIssueItem In Me
          SumRetention += Item.ARretention
        Next
        Return SumRetention
      End Get
    End Property
    Public ReadOnly Property Retention As Decimal
      Get
        Dim SumRetention As Decimal = 0
        For Each Item As SaleBillIssueItem In Me
          SumRetention += Item.Retention
        Next
        Return SumRetention
      End Get
    End Property
    Public ReadOnly Property BeforeTax As Decimal
      Get
        Dim SumBeforeTax As Decimal = 0
        For Each Item As SaleBillIssueItem In Me
          SumBeforeTax += Item.BeforeTax
        Next
        Return SumBeforeTax
      End Get
    End Property
    Public ReadOnly Property WHTBase As Decimal
      Get
        Dim SumWHTBase As Decimal = 0
        For Each Item As SaleBillIssueItem In Me
          SumWHTBase += Item.BeforeTax + Item.Retention
        Next
        Return SumWHTBase
      End Get
    End Property
#End Region

#Region "Class Methods"
    Public Function GetRemainFromOtherDocs(ByVal doc As SaleBillIssueItem) As Decimal
      Dim ret As Decimal = 0
      For Each myDoc As SaleBillIssueItem In Me
        If Not doc Is myDoc AndAlso doc.Id = myDoc.Id AndAlso doc.EntityId = myDoc.EntityId AndAlso ((myDoc.ParentType = doc.ParentType AndAlso myDoc.ParentId <> doc.ParentId) Or myDoc.ParentId = 0 Or doc.ParentId = 0) Then
          ret += myDoc.Amount
        End If
      Next

      Return Configuration.Format(Math.Min(doc.AfterTax, doc.GetRemainingAmountReceiveSelectionFromOtherReceives(Me.m_receives.Id)) - ret, DigitConfig.Price)
    End Function
    Public Function RealAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As SaleBillIssueItem In Me
        If doc.EntityId = 79 OrElse doc.EntityId = 48 Then
          ret -= doc.RealAmount
        Else
          ret += doc.RealAmount
        End If
      Next
      Return Configuration.Format(ret, DigitConfig.Price)
    End Function
    Public Function UnreceivedAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As SaleBillIssueItem In Me
        If doc.EntityId = 79 OrElse doc.EntityId = 48 Then
          ret -= doc.UnreceivedAmount
        Else
          ret += doc.UnreceivedAmount
        End If
      Next
      Return Configuration.Format(ret, DigitConfig.Price)
    End Function
    Public Function Amount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As SaleBillIssueItem In Me
        If doc.EntityId = 79 OrElse doc.EntityId = 48 Then
          ret -= doc.Amount
        Else
          ret += doc.Amount
        End If
      Next
      Return Configuration.Format(ret, DigitConfig.Price)
    End Function
    Public Function RemainingAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As SaleBillIssueItem In Me
        If doc.EntityId = 79 Then
          ret -= (doc.UnreceivedAmount - doc.Amount)
          'ElseIf doc.EntityId = 48 Then
          '    ret -= doc.UnreceivedAmount
        Else
          ret += doc.UnreceivedAmount - doc.Amount
        End If
      Next
      Return Configuration.Format(ret, DigitConfig.Price)
    End Function
    Public Function VatAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As SaleBillIssueItem In Me
        '48 ลดหนี้ ออกมาเป็นค่าลบอยู่แล้ว
        If doc.EntityId = 79 Then
          ret -= doc.VatAmt
        Else
          ret += doc.VatAmt
        End If
      Next
      Return Configuration.Format(ret, DigitConfig.Price)
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each bai As SaleBillIssueItem In Me
        i += 1

        'myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))

        Dim newRow As TreeRow = dt.Childs.Add()
        newRow(Me.m_prefix & "_linenumber") = i
        newRow(Me.m_prefix & "_entity") = bai.Id
        If bai.EntityId = 0 Then
          newRow(Me.m_prefix & "_entityType") = DBNull.Value
        Else
          newRow(Me.m_prefix & "_entityType") = bai.EntityId
        End If
        newRow("Code") = bai.Code
        newRow("DocDate") = bai.Date
        newRow("DueDate") = bai.DueDate
        newRow("RealAmount") = Configuration.FormatToString(bai.RemainingAmount, DigitConfig.Price)
        newRow("UnreceivedAmount") = Configuration.FormatToString(bai.UnreceivedAmount, DigitConfig.Price)
        newRow(Me.m_prefix & "_amt") = Configuration.FormatToString(bai.Amount, DigitConfig.Price)
        newRow(Me.m_prefix & "_note") = bai.Note
        newRow("refdoc") = bai.Id
        newRow("reftype") = bai.EntityId
        newRow.Tag = bai
      Next
    End Sub
    Public Sub PopulateReceiveSelectionItem(ByVal dt As TreeTable, Optional ByVal refresh As Boolean = False)
      dt.Clear()
      Dim i As Integer = 0
      For Each bai As SaleBillIssueItem In Me
        i += 1
        Dim parRow As TreeRow = FindRow(dt, bai.ParentId, bai.ParentCode, bai.ParentType)
        Dim newRow As TreeRow = parRow.Childs.Add()
        newRow(Me.m_prefix & "_linenumber") = i
        newRow(Me.m_prefix & "_entity") = bai.Id
        If bai.EntityId = 0 Then
          newRow(Me.m_prefix & "_entityType") = DBNull.Value
        Else
          newRow(Me.m_prefix & "_entityType") = bai.EntityId
        End If
        newRow("Code") = bai.Code
        If ShowDetail Then
          'แสดงรายละเอียด
          If bai.EntityId = 75 OrElse bai.EntityId = 78 OrElse bai.EntityId = 79 Then
            newRow.State = RowExpandState.Expanded
            Dim item As New Milestone(bai.StockId)
            'item.ReLoadItems()
            For Each miDetailRow As TreeRow In item.ItemTable.Childs
              Dim childRow As TreeRow = newRow.Childs.Add
              Dim childText As String = miDetailRow("milestonei_desc").ToString
              If Not miDetailRow.IsNull("milestonei_qty") AndAlso IsNumeric(miDetailRow("milestonei_qty")) AndAlso CDec(miDetailRow("milestonei_qty")) > 0 Then
                Dim unitText As String = ""
                If Not miDetailRow.IsNull("Unit") Then
                  unitText = " " & miDetailRow("Unit").ToString
                End If
                childText &= (Configuration.FormatToString(CDec(miDetailRow("milestonei_qty")), DigitConfig.Qty) & unitText)
              End If
              childRow("Code") = childText
            Next
          End If
        End If

        newRow("DocDate") = bai.Date
        newRow("DueDate") = bai.DueDate

        If refresh Then
          Dim remain As Decimal = bai.GetRemainingAmountReceiveSelection(Me.ReceiveSelection.Id)
          remain = Math.Min(bai.BilledAmount, remain)
          Dim remain2 As Decimal = Me.GetRemainFromOtherDocs(bai)
          remain = Math.Min(remain, remain2)
          If bai.UnreceivedAmount <> remain Then
            bai.UnreceivedAmount = remain
          End If
        End If
        'newRow("RealAmount") = Configuration.FormatToString(bai.BilledAmount, DigitConfig.Price)
        newRow("RealAmount") = Configuration.FormatToString(bai.RemainingAmount + bai.ARretention, DigitConfig.Price)
        newRow("RetentionAmount") = Configuration.FormatToString(bai.ARretention, DigitConfig.Price)
        newRow("UnreceivedAmount") = Configuration.FormatToString(Math.Min(bai.UnreceivedAmount, bai.BilledAmount), DigitConfig.Price)
        newRow(Me.m_prefix & "_amt") = Configuration.FormatToString(bai.Amount, DigitConfig.Price)
        newRow(Me.m_prefix & "_note") = bai.Note
        newRow.Tag = bai
      Next
      If i = 0 Then
        Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        Dim noParentText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.BlankParentText}")
        Dim parRow As TreeRow = FindRow(dt, 0, noParentText, 0)
      End If
    End Sub
    Public Shared Function FindRow(ByVal dt As TreeTable, ByVal id As Integer, ByVal desc As String, ByVal type As Integer) As TreeRow
      For Each row As TreeRow In dt.Childs
        If Not row.IsNull("receivesi_parentEntity") Then
          If CInt(row("receivesi_parentEntity")) = id Then
            If Not row.IsNull("receivesi_parentEntityType") Then
              If CInt(row("receivesi_parentEntityType")) = type Then
                Return row
              End If
            End If
          End If
        End If
      Next
      Dim newRow As TreeRow
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim noParentText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ReceiveSelectionDetail.BlankParentText}")
      If id = 0 Then
        newRow = dt.Childs.Add
      Else
        Dim noParentRow As TreeRow = FindRow(dt, 0, noParentText, 0)
        newRow = dt.Childs.InsertAt(dt.Childs.IndexOf(noParentRow))
      End If
      newRow("receivesi_parentEntity") = id
      newRow("receivesi_parentEntityType") = type
      If desc Is Nothing OrElse IsDBNull(desc) Then
        desc = noParentText
      End If
      newRow("Code") = desc
      newRow("Button") = "invisible"

      If type = 125 Then 'ใบวางบิล
        Dim sbi As New SaleBillIssue
        sbi.Id = id
        newRow.Tag = sbi
      Else '81 ใบวางบิลงวด
        Dim bi As New BillIssue
        bi.Id = id
        newRow.Tag = bi
      End If

      Return newRow
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As SaleBillIssueItem) As Integer
      If Not Me.m_receives Is Nothing Then

      ElseIf Not Me.m_saleBillIssue Is Nothing Then

      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As SaleBillIssueItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As SaleBillIssueItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As SaleBillIssueItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As SaleBillIssueItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As SaleBillIssueItemEnumerator
      Return New SaleBillIssueItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As SaleBillIssueItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As SaleBillIssueItem)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As SaleBillIssueItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal value As SaleBillIssueItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region


    Public Class SaleBillIssueItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As SaleBillIssueItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, SaleBillIssueItem)
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
