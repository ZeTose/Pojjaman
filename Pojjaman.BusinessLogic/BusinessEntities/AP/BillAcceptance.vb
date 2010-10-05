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
  Public Class PayableItemType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
    Public Sub New()
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "PayableItemType"
      End Get
    End Property
#End Region

  End Class

  Public Class BillAcceptanceStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "billa_status"
      End Get
    End Property
#End Region

  End Class

  Public Class BillAcceptance
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, IHasIBillablePerson, ICancelable

#Region "Members"
    Private m_supplier As Supplier
    Private m_docDate As Date

    Private m_costCenter As CostCenter
    Private m_po As PO

    Private m_billIssueCode As String
    Private m_billIssueDocDate As Date

    Private m_note As String
    Private m_creditPeriod As Long

    Private m_status As BillAcceptanceStatus

    Private m_itemCollection As BillAcceptanceItemCollection
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
        .m_costCenter = New CostCenter
        .m_po = New PO
        .m_supplier = New Supplier
        .m_creditPeriod = 0
        .m_note = ""
        .m_docDate = Date.Now.Date
        .m_status = New BillAcceptanceStatus(-1)
        m_itemCollection = New BillAcceptanceItemCollection(Me)
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
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_supplier") Then
            .m_supplier = New Supplier(CInt(dr(aliasPrefix & Me.Prefix & "_supplier")))
          End If
        End If

        If dr.Table.Columns.Contains("cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .m_costCenter = New CostCenter(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_cc") Then
            .m_costCenter = New CostCenter(CInt(dr(aliasPrefix & Me.Prefix & "_cc")))
          End If
        End If

        If dr.Table.Columns.Contains("po_id") Then
          If Not dr.IsNull("po_id") Then
            .m_po = New PO(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & Me.Prefix & "_po") Then
            .m_po = New PO(CInt(dr(aliasPrefix & Me.Prefix & "_po")))
          End If
        End If

        If dr.Table.Columns.Contains(Me.Prefix & "_billissuecode") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_billissuecode") Then
          .m_billIssueCode = CStr(dr(aliasPrefix & Me.Prefix & "_billissuecode"))
        End If
        If dr.Table.Columns.Contains(Me.Prefix & "_billissuedate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_billissuedate") Then
          .m_billIssueDocDate = CDate(dr(aliasPrefix & Me.Prefix & "_billissuedate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & Me.Prefix & "_creditperiod"))
        End If

        If dr.Table.Columns.Contains(Me.Prefix & "_docDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & Me.Prefix & "_docDate"))
        End If

        If dr.Table.Columns.Contains(Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .m_status = New BillAcceptanceStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        m_itemCollection = New BillAcceptanceItemCollection(Me)

      End With
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollection() As BillAcceptanceItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As BillAcceptanceItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property PO() As PO
      Get
        Return m_po
      End Get
      Set(ByVal Value As PO)
        m_po = Value
        ChangePO()
      End Set
    End Property
    Private Sub ChangePO()
      'ź¡
      Dim itemsToRemove As New ArrayList
      For Each item As BillAcceptanceItem In Me.ItemCollection
        If item.Id <> 0 Then
          itemsToRemove.Add(item)
        End If
      Next
      For Each item As BillAcceptanceItem In itemsToRemove
        Me.ItemCollection.Remove(item)
      Next
      If Not Me.m_po Is Nothing AndAlso Me.m_po.Originated Then
        Me.Supplier = Me.m_po.Supplier
        Me.CreditPeriod = Me.m_po.CreditPeriod
        Me.CostCenter = Me.m_po.CostCenter
      Else
        If Not Me.m_supplier Is Nothing Then
          Me.CreditPeriod = Me.Supplier.CreditPeriod
        End If
      End If
    End Sub
    Public Property CostCenter() As CostCenter
      Get
        Return m_costCenter
      End Get
      Set(ByVal Value As CostCenter)
        m_costCenter = Value
      End Set
    End Property
    Public Property Supplier() As Supplier
      Get
        Return m_supplier
      End Get
      Set(ByVal Value As Supplier)
        m_supplier = Value
        If Me.m_po Is Nothing Then
          Me.m_creditPeriod = Me.m_supplier.CreditPeriod
          Return
        End If
        If Value.Id <> Me.m_po.Supplier.Id Then
          Me.m_creditPeriod = Me.m_supplier.CreditPeriod
          Me.PO = New PO
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
    Public Property DueDate() As Date
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
    Public Property BillIssueCode() As String
      Get
        Return m_billIssueCode
      End Get
      Set(ByVal Value As String)
        m_billIssueCode = Value
      End Set
    End Property
    Public Property BillIssueDocDate() As Date
      Get
        Return m_billIssueDocDate
      End Get
      Set(ByVal Value As Date)
        m_billIssueDocDate = Value
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
    Public Property CreditPeriod() As Long
      Get
        Return m_creditPeriod
      End Get
      Set(ByVal Value As Long)
        m_creditPeriod = Value
      End Set
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, BillAcceptanceStatus)
      End Set
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        Return Me.ItemCollection.Amount
      End Get
    End Property
    Public ReadOnly Property RemainingAmount() As Decimal
      Get
        Return Me.ItemCollection.RemainingAmount
      End Get
    End Property
    Public ReadOnly Property ItemCount() As Integer
      Get
        Return Me.ItemCollection.Count
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "BillAcceptance"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "billa"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "BillAcceptance"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BillAcceptance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.BillAcceptance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.BillAcceptance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BillAcceptance.ListLabel}"
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
      Dim myDatatable As New TreeTable("BillAcceptance")

      myDatatable.Columns.Add(New DataColumn("billai_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("billai_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("billai_entitytype", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))

      Dim dateCol As New DataColumn("DocDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      dateCol = New DataColumn("DueDate", GetType(Date))
      dateCol.DefaultValue = Date.MinValue
      myDatatable.Columns.Add(dateCol)

      myDatatable.Columns.Add(New DataColumn("billai_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnpaidAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("billai_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Retention", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PlusRetention", GetType(String)))

      'ʴ error ҷͧ
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.CodeHeaderText}")
      myDatatable.Columns("billai_amt").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillAcceptanceDetail.AmountHeaderText}")
      Return myDatatable
    End Function
    Public Shared Function GetBillAcceptance(ByVal txtCode As TextBox, ByRef oldBA As BillAcceptance) As Boolean
      Dim newBA As New BillAcceptance(txtCode.Text)
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

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String)
      Me.Code = oldCode
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        Dim oldcode As String

        If Originated Then
          If Not Supplier Is Nothing Then
            If Supplier.Canceled Then
              Return New SaveErrorException(StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Supplier.Code})
            End If
          End If
        End If

        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' ҧ ArrayList ҡ Item ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@billa_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        oldcode = Me.Code
        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        paramArrayList.Add(New SqlParameter("@billa_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@billa_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@billa_supplier", Me.ValidIdOrDBNull(Me.Supplier)))
        paramArrayList.Add(New SqlParameter("@billa_po", Me.ValidIdOrDBNull(Me.PO)))
        paramArrayList.Add(New SqlParameter("@billa_cc", Me.ValidIdOrDBNull(Me.CostCenter)))
        paramArrayList.Add(New SqlParameter("@billa_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@billa_billissueCode", Me.BillIssueCode))
        paramArrayList.Add(New SqlParameter("@billa_billissueDate", Me.ValidDateOrDBNull(Me.BillIssueDocDate)))
        paramArrayList.Add(New SqlParameter("@billa_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@billa_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@billa_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' ҧ SqlParameter ҡ ArrayList ...

        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Try
          Me.ExecuteSaveSproc(returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid)
                Me.ResetCode(oldcode)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -69 'ใบวางบิลซ้ำ
                trans.Rollback()
                ResetID(oldid)
                Me.ResetCode(oldcode)
                Return New SaveErrorException("${res:Global.Error.BillIssueCodeDuplicated}", Me.BillIssueCode)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid)
            Me.ResetCode(oldcode)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          SaveDetail(Me.Id, conn, trans)

          Me.DeleteRef(conn, trans)
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGR_BillARef" _
          , New SqlParameter("@billa_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePCN_BillARef" _
          , New SqlParameter("@billa_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateEQMaint_BillARef" _
          , New SqlParameter("@billa_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAPO_BillARef" _
          , New SqlParameter("@billa_id", Me.Id))
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateAPA_BillARef" _
          , New SqlParameter("@billa_id", Me.Id))
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid)
          Me.ResetCode(oldcode)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid)
          Me.ResetCode(oldcode)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each billi As BillAcceptanceItem In Me.ItemCollection
        ret &= billi.Id.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
      Dim da As New SqlDataAdapter("Select * from BillAcceptanceItem where billai_billa=" & Me.Id, conn)
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
      da.FillSchema(ds, SchemaType.Mapped, "BillAcceptanceItem")
      da.Fill(ds, "BillAcceptanceItem")


      Dim dt As DataTable = ds.Tables("BillAcceptanceItem")
      Dim i As Integer = 0
      With ds.Tables("BillAcceptanceItem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each billi As BillAcceptanceItem In Me.ItemCollection
          i += 1
          Dim dr As DataRow = .NewRow
          dr("billai_billa") = Me.Id
          dr("billai_linenumber") = i
          dr("stock_id") = billi.Id
          dr("stock_code") = billi.Code
          dr("stock_type") = billi.EntityId
          dr("stock_docdate") = billi.Date
          dr("stock_creditprd") = billi.CreditPeriod
          dr("stock_beforetax") = billi.BeforeTax
          dr("stock_aftertax") = billi.AfterTax
          dr("stock_taxbase") = billi.TaxBase
          dr("billai_amt") = billi.Amount
          dr("billai_billedamt") = billi.Amount '****** Hack
          dr("billai_unpaidamt") = billi.UnpaidAmount
          dr("stock_note") = billi.Note
          dr("stock_status") = Me.Status.Value
          dr("stock_retention") = billi.Retention
          dr("billai_retentiontype") = billi.RetentionType
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

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\BA.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

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

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'SupBillCode
      dpi = New DocPrintingItem
      dpi.Mapping = "SupBillCode"
      dpi.Value = Me.BillIssueCode
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SupBillDocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "SupBillDocDate"
      dpi.Value = Me.BillIssueDocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      If Not Me.Supplier Is Nothing AndAlso Me.Supplier.Originated Then
        'SupplierInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierInfo"
        dpi.Value = Me.Supplier.Code & ":" & Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierName
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierName"
        dpi.Value = Me.Supplier.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierAddress"
        dpi.Value = Me.Supplier.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SupplierCurrentAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "SupplierCurrentAddress"
        dpi.Value = Me.Supplier.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'If Not Me.Employee Is Nothing AndAlso Me.Employee.Originated Then
      '   ' Employee
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Supplier"
      '    dpi.Value = Me.Supplier.Code & ":" & Me.Supplier.Name
      '    dpi.DataType = "System.String"
      '    dpiColl.Add(dpi)
      'End If

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
      dpi.Value = Configuration.FormatToString(Me.CreditPeriod, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      If ItemCollection IsNot Nothing Then
        'Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Amount"
        dpi.Value = Configuration.FormatToString(Me.ItemCollection.RealAmount, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)


        'TaxAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "TaxAmount"
        dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetAfterTax - Me.ItemCollection.GetBeforeTax, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)

        'AfterTax
        dpi = New DocPrintingItem
        dpi.Mapping = "AfterTax"
        dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetAfterTax, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)

      End If

      Dim n As Integer = 0
      For Each item As BillAcceptanceItem In Me.ItemCollection
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

        'Item.DocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DocDate"
        dpi.Value = item.Date
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.CostCenterCode"
        dpi.Value = item.GetCostCenterFromRefDoc(item.Id, item.EntityId).Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.BillType
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.BillType"
        dpi.Value = New PayableItemType(item.EntityId).Description
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DueDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DueDate"
        dpi.Value = item.DueDate
        dpi.DataType = "System.DateTime"
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

        'Item.PlusRetention
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.PlusRetention"
        dpi.Value = Configuration.FormatToString(item.AfterTax + item.Retention, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DueDate
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DueDate"
        dpi.Value = item.DueDate
        dpi.DataType = "System.DateTime"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)


        'Item.DocAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DocAmount"
        If item.BilledAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.BilledAmount, DigitConfig.Price)
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

        Dim amt As String = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        Dim Bfpoint As String = Trim(Split(Replace(amt, ",", ""), ".")(0))
        Dim Aftpoint As String = "00"
        If UBound(Split(amt, "."), 1) <> 0 Then
          Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
        End If
        amt = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        Bfpoint = Trim(Split(Replace(amt, ",", ""), ".")(0))
        Aftpoint = "00"
        If UBound(Split(amt, "."), 1) <> 0 Then
          Aftpoint = Left(Trim(Split(amt, ".")(1)), 2)
        End If

        'Item.AmountBaht
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AmountBaht"
        dpi.Value = Configuration.FormatToString(CDec(Bfpoint), DigitConfig.Int)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.AmountSatang
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.AmountSatang"
        dpi.Value = Aftpoint
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

        If item.EntityId = 45 Then
          'Hack
          Dim gr As New GoodsReceipt(item.Id)

          'Item.POCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.POCode"
          If Not gr.Po Is Nothing Then
            dpi.Value = gr.Po.Code
          Else
            dpi.Value = ""
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.PODueDate
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.PODueDate"
          If Not gr.Po Is Nothing AndAlso gr.Po.Code.Length > 0 Then
            dpi.Value = gr.Po.DueDate
          Else
            dpi.Value = ""
          End If
          dpi.DataType = "System.DateTime"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.VatCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Vatcode"
          If Not gr.Vat Is Nothing Then
            dpi.Value = gr.Vat.GetVatItemCodes
          Else
            dpi.Value = ""
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.VatDocDate
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.VatDocDate"
          If Not gr.Vat Is Nothing Then
            dpi.Value = gr.Vat.GetVatItemDates
          Else
            dpi.Value = ""
          End If
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If

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

      'วันที่ใบรับวางบิล
      dpi = New DocPrintingItem
      dpi.Mapping = "BillDocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'รหัสใบรับวางบิล
      dpi = New DocPrintingItem
      dpi.Mapping = "BillDocCode"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'รหัสผู้ขาย
      dpi = New DocPrintingItem
      dpi.Mapping = "BillSupplierCode"
      If Me.Supplier IsNot Nothing Then
        dpi.Value = Me.Supplier.Code
      Else
        dpi.Value = ""
      End If
      dpi.DataType = "System.String"
      'dpi.Row = 1
      'dpi.Table = "BillItem"
      dpiColl.Add(dpi)

      'ที่อยู่ผู้ขาย
      dpi = New DocPrintingItem
      dpi.Mapping = "BillSupplierBillingAddress"
      If Me.Supplier IsNot Nothing Then
        dpi.Value = Me.Supplier.BillingAddress
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

      'Dim sumCol9 As Decimal = 0
      'Dim sumCol10 As Decimal = 0
      'Dim sumCol11 As Decimal = 0

      Dim sumDiscount As Decimal = 0
      Dim sumTaxAmount As Decimal = 0
      Dim sumAmount As Decimal = 0

      Dim n As Integer = 1
      Dim LineNumber As Integer = 0
      For Each item As BillAcceptanceItem In Me.ItemCollection
        'ซื้อสินค้า/บริการ
        If item.EntityId = 45 Then

          Dim doc As New GoodsReceipt(item.Id)
          LineNumber += 1

          'ลำดับรายการวางบิล
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = LineNumber
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          'เลขที่ใบส่งสินค้า
          dpi = New DocPrintingItem
          'dpi.Mapping = "BillDocCode"
          dpi.Mapping = "col1"
          dpi.Value = item.Code
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          'วันที่เอกสาร
          dpi = New DocPrintingItem
          'dpi.Mapping = "BillDocDate"
          dpi.Mapping = "col2"
          dpi.Value = item.Date.ToShortDateString
          dpi.DataType = "System.String"
          dpi.Row = n
          dpi.Table = "BillItem"
          dpiColl.Add(dpi)

          'วันที่กำหนดชำระ
          dpi = New DocPrintingItem
          'dpi.Mapping = "BillDocDate"
          dpi.Mapping = "col3"
          dpi.Value = item.DueDate.ToShortDateString
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
          For Each docitem As GoodsReceiptItem In doc.ItemCollection

            ItemlineNumber += 1

            'ลำดับรายการ
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

            ''ส่วนลดรายการ
            'dpi = New DocPrintingItem
            ''dpi.Mapping = "BillDisCount"
            'dpi.Mapping = "col9"
            'dpi.Value = Configuration.FormatToString(docitem.DiscountAmount, DigitConfig.Price)
            'dpi.DataType = "System.String"
            'dpi.Row = n
            'dpi.Table = "BillItem"
            'dpiColl.Add(dpi)

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
            'dpi.Mapping = "BillAmount"
            dpi.Mapping = "col10"
            dpi.Value = Configuration.FormatToString(docitem.TaxAmount, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n
            dpi.Table = "BillItem"
            dpiColl.Add(dpi)

            'รวมเงิน
            dpi = New DocPrintingItem
            'dpi.Mapping = "BillAmount"
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
          If doc.TaxType.Value = 0 OrElse doc.TaxType.Value = 1 Then
            sumDiscount += doc.AdvancePayItemCollection.GetExcludeVATAmount
          Else
            sumDiscount += doc.AdvancePayItemCollection.GetAmount
          End If
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
        Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBillAcceptance}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBillAcceptance", New SqlParameter() {New SqlParameter("@billa_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.BillAcceptanceIsReferencedCannotBeDeleted}")
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
  Public Class BillAcceptanceItem
    Inherits SimpleBusinessEntityBase
    Implements IBillAcceptable

#Region "Members"
    Private m_realAmount As Decimal
    Private m_beforeTax As Decimal
    Private m_afterTax As Decimal
    Private m_taxBase As Decimal

    Private m_deducttaxBase As Nullable(Of Decimal)
    Private m_Remained As Nullable(Of Decimal)

    Private m_taxRate As Decimal
    Private m_taxPoint As New TaxPoint(0)
    Private m_taxType As New TaxType(2)
    Private m_unpaidAmount As Decimal
    Private m_amount As Decimal
    Private m_note As String
    Private m_billAcceptance As BillAcceptance
    Private m_typeId As Integer
    Private m_docDate As Date
    Private m_creditPeriod As Long
    Private m_pays As PaySelection
    Private m_apvi As APVatInput
    Private m_itemprefix As String

    Private m_billedAmount As Decimal 'ʹҧ

    Private m_linenumber As Integer

    Private m_ccId As Integer
    Private m_cc As CostCenter

    Private m_parentId As Integer
    Private m_parentCode As String
    Private m_parentType As Integer

    Private m_retentionType As Integer
    Private m_remainningBalance As Decimal

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal payable As IBillAcceptable, ByVal billA As BillAcceptance)
      MyBase.New()
      m_billAcceptance = billA
      m_itemprefix = "billai"
      Construct(payable)
    End Sub
    Public Sub New(ByVal payable As IBillAcceptable, ByVal pays As PaySelection)
      MyBase.New()
      m_pays = pays
      m_itemprefix = "paysi"
      Construct(payable)
    End Sub
    Public Sub New(ByVal payable As IBillAcceptable, ByVal apvi As APVatInput)
      MyBase.New()
      m_apvi = apvi
      m_itemprefix = "paysi"
      Construct(payable)
    End Sub
    Private Overloads Sub Construct(ByVal payable As IBillAcceptable)
      Me.Id = payable.Id
      Me.Code = payable.Code
      Me.RealAmount = payable.AmountToPay
      Me.Date = payable.Date
      Me.BilledAmount = Me.RealAmount
      'Me.Retention =
      Me.CreditPeriod = CInt(DateDiff(DateInterval.Day, payable.Date, payable.DueDate))
      If Not m_billAcceptance Is Nothing AndAlso m_billAcceptance.Originated Then
        Me.UnpaidAmount = payable.GetRemainingAmountWithBillAcceptance(m_billAcceptance.Id)
      ElseIf Not m_pays Is Nothing Then
        Me.UnpaidAmount = payable.GetRemainingAmountPayselection(m_pays.Id)
      End If
      If TypeOf payable Is ISimpleEntity Then
        m_typeId = CType(payable, ISimpleEntity).EntityId
      End If
    End Sub
    Public Sub New(ByVal advancepay As AdvancePay, ByVal apvi As APVatInput)
      MyBase.New()
      m_apvi = apvi

      Me.Id = advancepay.Id
      Me.Code = advancepay.Code
      Me.RealAmount = advancepay.AmountToPay
      Me.Date = advancepay.DocDate
      Me.BilledAmount = Me.RealAmount
      Me.BeforeTax = advancepay.BeforeTax
      Me.AfterTax = advancepay.AfterTax
      Me.TaxBase = advancepay.RealTaxBase

      'Hack 
      Me.Amount = Me.TaxBase
      Me.UnpaidAmount = Me.TaxBase
      Me.BilledAmount = Me.TaxBase

      If TypeOf advancepay Is ISimpleEntity Then
        m_typeId = CType(advancepay, ISimpleEntity).EntityId
      End If
    End Sub
    'Public Sub New(ByVal pa As PA)
    'MyBase.New()
    'm_typeId = pa.EntityId
    'Me.Id = pa.Id
    'Me.Code = pa.Code
    'Me.Date = pa.DocDate
    'Me.DueDate = pa.DueDate
    'Me.BeforeTax = pa.BeforeTax
    ''Me.Retention = pa.Retention 
    'Me.AfterTax = pa.AfterTax
    ''Me.Retention = pa.Retention
    'Me.UnpaidAmount = pa.GetRemainingAmountWithBillAcceptance(0)
    ''Me.Amount = 0

    'Me.Note = pa.Note

    'End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal billA As BillAcceptance)
      m_billAcceptance = billA
      m_itemprefix = "billai"
      Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal pays As PaySelection)
      m_pays = pays
      m_itemprefix = "paysi"
      Construct(dr, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String, ByVal apvi As APVatInput)
      m_apvi = apvi
      m_itemprefix = "paysi"
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
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_docdate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docdate") Then
        Me.m_docDate = CDate(dr(aliasPrefix & "stock_docdate"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "stock_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & "stock_creditperiod") Then
        Me.m_creditPeriod = CInt(dr(aliasPrefix & "stock_creditperiod"))
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
      If dr.Table.Columns.Contains(aliasPrefix & "stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
        Me.m_ccId = CInt(dr(aliasPrefix & "stock_tocc"))
      End If
      '******************************
      If dr.Table.Columns.Contains(aliasPrefix & "TaxbaseDeducted") AndAlso Not dr.IsNull(aliasPrefix & "TaxbaseDeducted") Then
        Me.m_deducttaxBase = CDec(dr(aliasPrefix & "TaxbaseDeducted"))
      End If

      If dr.Table.Columns.Contains(aliasPrefix & "Remained") AndAlso Not dr.IsNull(aliasPrefix & "Remained") Then
        Me.m_Remained = CDec(dr(aliasPrefix & "Remained"))
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
      If dr.Table.Columns.Contains(aliasPrefix & "stock_retention") AndAlso Not dr.IsNull(aliasPrefix & "stock_retention") Then
        Me.m_retention = CDec(dr(aliasPrefix & "stock_retention"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_retentiontype") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_retentiontype") Then
        Me.m_retentionType = CInt(dr(aliasPrefix & m_itemprefix & "_retentiontype"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & "remain") AndAlso Not dr.IsNull(aliasPrefix & "remain") Then
        Select Case m_itemprefix
          Case "paysi"
            If Not m_pays Is Nothing Then
              Me.m_billedAmount = CDec(dr(aliasPrefix & "remain"))
              Me.m_remainningBalance = CDec(dr(aliasPrefix & "remain"))
            End If
          Case "billai"
            If Not m_billAcceptance Is Nothing Then
              'Me.m_unpaidAmount = Me.GetRemainingAmountWithBillAcceptance(Me.m_billAcceptance.Id)
              'Me.m_billedAmount = Me.m_unpaidAmount
              Me.m_amount = CDec(dr(aliasPrefix & "remain"))
              Me.m_unpaidAmount = CDec(dr(aliasPrefix & "remain"))
              Me.m_billedAmount = Me.m_unpaidAmount
            End If
        End Select
      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_unpaidamt") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_unpaidamt") Then
        Me.m_unpaidAmount = CDec(dr(aliasPrefix & m_itemprefix & "_unpaidamt"))
      End If
      If dr.Table.Columns.Contains(aliasPrefix & m_itemprefix & "_billedamt") AndAlso Not dr.IsNull(aliasPrefix & m_itemprefix & "_billedamt") Then
        Me.m_billedAmount = CDec(dr(aliasPrefix & m_itemprefix & "_billedamt"))
      End If
      '*********************************************************
      m_deducttaxBase = Nothing
    End Sub
#End Region

#Region "Properties"
    Public Property BillAcceptance() As BillAcceptance
      Get
        Return m_billAcceptance
      End Get
      Set(ByVal Value As BillAcceptance)
        m_billAcceptance = Value
      End Set
    End Property
    Public Property PaySelection() As PaySelection
      Get
        Return m_pays
      End Get
      Set(ByVal Value As PaySelection)
        m_pays = Value
      End Set
    End Property
    Public Property Linenumber() As Integer
      Get
        Return m_linenumber
      End Get
      Set(ByVal Value As Integer)
        m_linenumber = Value
      End Set
    End Property
    Public Property CostCenterId() As Integer
      Get
        Return m_ccId
      End Get
      Set(ByVal Value As Integer)
        m_ccId = Value
      End Set
    End Property
    Public Property ParentId() As Integer
      Get
        Return m_parentId
      End Get
      Set(ByVal Value As Integer)
        m_parentId = Value
      End Set
    End Property
    Public Property ParentCode() As String
      Get
        Return m_parentCode
      End Get
      Set(ByVal Value As String)
        m_parentCode = Value
      End Set
    End Property
    Public Property ParentType() As Integer
      Get
        Return m_parentType
      End Get
      Set(ByVal Value As Integer)
        m_parentType = Value
      End Set
    End Property
    Public Property BilledAmount() As Decimal
      Get
        Return Me.m_billedAmount
      End Get
      Set(ByVal Value As Decimal)
        Me.m_billedAmount = Value
        SetGLChange()
      End Set
    End Property
    Public Property RemainningBalance As Decimal
      Get
        Return Me.m_remainningBalance
      End Get
      Set(ByVal value As Decimal)
        m_remainningBalance = value
      End Set
    End Property
    Public Property Remained As Decimal
      Get
        Return Me.m_Remained.Value
      End Get
      Set(ByVal value As Decimal)
        m_Remained = value
      End Set
    End Property
    Public Property CreditPeriod() As Long
      Get
        Return m_creditPeriod
      End Get
      Set(ByVal Value As Long)
        m_creditPeriod = Value
      End Set
    End Property
    Public Property BeforeTax() As Decimal
      Get
        Return m_beforeTax
      End Get
      Set(ByVal Value As Decimal)
        m_beforeTax = Value
      End Set
    End Property
    Public Property AfterTax() As Decimal
      Get
        Return m_afterTax
      End Get
      Set(ByVal Value As Decimal)
        m_afterTax = Value
        If Me.Id = 0 Then
          Me.m_taxBase = Vat.GetExcludedVatAmount(Me.m_afterTax)
        End If
      End Set
    End Property
    Public Property TaxType() As TaxType
      Get
        Return m_taxType
      End Get
      Set(ByVal Value As TaxType)
        m_taxType = Value
      End Set
    End Property
    Public Property TaxPoint() As TaxPoint
      Get
        Return m_taxPoint
      End Get
      Set(ByVal Value As TaxPoint)
        m_taxPoint = Value
      End Set
    End Property
    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        m_taxRate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
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
    Public Property DeductTaxBase() As Decimal
      Get
        If m_deducttaxBase.HasValue Then
          Return m_deducttaxBase.Value
        End If
        'If Me.EntityId = 46 Then
        '  m_deducttaxBase = 0
        '  Return 0
        'End If
        If Not Me.PaySelection Is Nothing Then
          m_deducttaxBase = Vat.GetTaxBaseDeductedWithoutThisRefDoc(Me.Id, Me.EntityId, PaySelection.Id, PaySelection.EntityId)
          Return m_deducttaxBase.Value
        ElseIf Not Me.m_apvi Is Nothing Then
          m_deducttaxBase = Vat.GetTaxBaseDeductedWithoutThisRefDoc(Me.Id, Me.EntityId, m_apvi.Id, m_apvi.EntityId)
          Return m_deducttaxBase.Value
        Else
          m_deducttaxBase = 0
          Return 0
        End If
      End Get
      Set(ByVal Value As Decimal)
        m_deducttaxBase = Value
      End Set
    End Property
    Public ReadOnly Property TaxAmount As Decimal
      Get
        Return (Amount / UnpaidAmount) * (AfterTax - BeforeTax)
      End Get
    End Property
    Public ReadOnly Property TaxAmountDeducted As Decimal
      Get
        If DeductTaxBase <> 0 AndAlso TaxBase <> 0 Then
          If UnpaidAmount = Amount Then
            If Me.EntityId = 59 Then
              Return ((BeforeTax - DeductTaxBase) / BeforeTax) * (AfterTax - BeforeTax)
            End If
            Return ((TaxBase - DeductTaxBase) / TaxBase) * (AfterTax - BeforeTax)
          End If
          'Return ((TaxBase - DeductTaxBase) / TaxBase) * (AfterTax - BeforeTax) * Amount / UnpaidAmount
          'If DeductTaxBase = 0 Then
          'ภ้าชำระไม่เต็ม ยอดต้องเท่ากับยอดที่จ่าย
          Return (AfterTax - BeforeTax) * Amount / AfterTax
          'Else
          '  Dim x As Decimal = ((TaxBase - DeductTaxBase) / TaxBase)
          '  Dim vated As Decimal = DeductTaxBase / TaxBase
          '  Dim b As Decimal = (Amount / UnpaidAmount)
          '  Dim taxamt As Decimal = (AfterTax - BeforeTax)
          '  Dim ret As Decimal = (b - vated) * taxamt
          '  Return ret
          'End If
        End If
        If UnpaidAmount <> Amount Then
          Return (AfterTax - BeforeTax) * Amount / UnpaidAmount
        End If
        Return (AfterTax - BeforeTax)
      End Get
    End Property
    Public ReadOnly Property itemType As String
      Get
        Select Case m_typeId
          Case 45
            Return "รับของ"
          Case 15
            Return "ซื้อยกมา"
          Case 59
            Return "มัดจำจ่าย"
          Case 46
            Return "ลดหนี้"
          Case 292
            Return "รับงาน"
          Case Else
            Return Nothing

        End Select
      End Get
    End Property
      
    'Private m_taxBaseDeducted As Decimal = Decimal.MinValue
    'Public Property TaxBaseDeducted() As Decimal
    '  Get
    '    Return m_taxBaseDeducted
    '  End Get
    '  Set(ByVal Value As Decimal)
    '    m_taxBaseDeducted = Value
    '  End Set
    'End Property
    Public Property RealAmount() As Decimal
      Get
        Return m_realAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realAmount = Value
        SetGLChange()
      End Set
    End Property
    Public Property Amount() As Decimal
      Get
        Return m_amount
      End Get
      Set(ByVal Value As Decimal)
        m_amount = Value
      End Set
    End Property
    Public Property UnpaidAmount() As Decimal
      Get
        Return m_unpaidAmount
      End Get
      Set(ByVal Value As Decimal)
        m_unpaidAmount = Value
        SetGLChange()
      End Set
    End Property
    Private m_retention As Decimal
    Public Property Retention() As Decimal
      Get
        If Me.m_typeId = 199 Then
          Return 0
        End If
        Return m_retention
      End Get
      Set(ByVal value As Decimal)
        m_retention = value
      End Set
    End Property
    Public Property RetentionType() As Integer
      Get
        Return m_retentionType
      End Get
      Set(ByVal value As Integer)
        m_retentionType = value
      End Set
    End Property

    Public ReadOnly Property RetentionForGL() As Decimal
      Get
        If Me.EntityId = 199 Then
          Return Me.Amount
        End If
        Return 0
      End Get
    End Property
    Public ReadOnly Property AmountForGL As Decimal
      Get
        If Me.EntityId = 46 Then
          Return -Me.Amount
        Else
          Return Me.Amount
        End If
      End Get
    End Property

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "BillAcceptanceItem"
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
#End Region

#Region "Methods"
    ''' <summary>
    ''' เปลี่ยนแปลง GL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGLChange()
      If Not m_pays Is Nothing Then
        m_pays.OnGlChanged()
      End If
      If Not m_apvi Is Nothing Then
        m_apvi.OnGlChanged()
      End If
    End Sub
    Public Sub SetType(ByVal type As Integer)
      Me.m_typeId = type
    End Sub
    Public Sub Clear()
      Me.Id = 0
      Me.RealAmount = 0
      Me.Amount = 0
      Me.Code = ""
      Me.Date = Date.MinValue
      Me.UnpaidAmount = 0
      Me.CreditPeriod = 0
      Me.SetType(-1)
    End Sub
#End Region

#Region "IBillAcceptable"
    Public Function AmountToPay() As Decimal Implements IBillAcceptable.AmountToPay
      Return Me.AfterTax
    End Function
    Public Property [Date]() As Date Implements IBillAcceptable.Date
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
      End Set
    End Property
    Public Property DueDate() As Date Implements IBillAcceptable.DueDate
      Get
        Try
          Return Me.[Date].AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.[Date]
        End Try
      End Get
      Set(ByVal Value As Date)
        Try
          m_creditPeriod = DateDiff(DateInterval.Day, [Date], Value)
        Catch ex As Exception

        End Try
      End Set
    End Property
    Public Property Note() As String Implements IBillAcceptable.Note
      Get
        Return Me.m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property Payment() As Payment Implements IBillAcceptable.Payment
      Get

      End Get
      Set(ByVal Value As Payment)

      End Set
    End Property
    Public ReadOnly Property Recipient() As IBillablePerson Implements IBillAcceptable.Recipient
      Get

      End Get
    End Property
    Public Function RemainingAmount() As Decimal Implements IBillAcceptable.RemainingAmount
      Return Me.AfterTax
    End Function
    Public Function GetCostCenterFromRefDoc(ByVal stock_id As Integer, ByVal stock_type As Integer) As CostCenter
      Try
        Dim dsr As DataSet = SqlHelper.ExecuteDataset( _
            Me.ConnectionString _
            , CommandType.StoredProcedure _
            , "GetCCForBillAccaptance" _
            , New SqlParameter("@stock_id", stock_id) _
            , New SqlParameter("@stock_type", stock_type) _
            )
        If dsr.Tables(0).Rows.Count > 0 Then
          If Not dsr.Tables(0).Rows(0).IsNull("cc_id") Then
            Return CostCenter.GetCostCenter(dsr.Tables(0).Rows(0), ViewType.PaySelection)
          End If
        End If
        Return New CostCenter
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        If Me.ParentId <> 0 Then
          Return GetRemainingAmountPayselection(pays_id, Me.ParentId)
        Else
          Dim sproc As String = "GetUnpaidStockRetentionAmount"
          If Me.m_typeId = 199 Then
            sproc = "GetUnpaidStockRetentionAmount"
            Dim dsr As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                , New SqlParameter("@retentiontype", Me.RetentionType) _
                )
            If dsr.Tables(0).Rows.Count > 0 Then
              Return Configuration.Format(CDec(dsr.Tables(0).Rows(0)(0)), DigitConfig.Price)
            End If
          ElseIf Me.m_typeId = 46 Then
            sproc = "GetUnpaidPurchaseCNAmount"
          Else
            sproc = "GetUnpaidStockAmount"
            If m_Remained.HasValue Then
              Return m_Remained.Value
            End If
          End If
          Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                  Me.ConnectionString _
                  , CommandType.StoredProcedure _
                  , sproc _
                  , New SqlParameter("@stock_id", Me.Id) _
                  , New SqlParameter("@paysi_pays", pays_id) _
                  , New SqlParameter("@stock_type", Me.m_typeId) _
                  )
          If ds.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer, ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim sproc As String = "GetUnpaidStockRetentionAmount"
        If Me.m_typeId = 199 Then
          sproc = "GetUnpaidStockRetentionAmount"
          Dim dsr As DataSet = SqlHelper.ExecuteDataset( _
             Me.ConnectionString _
             , CommandType.StoredProcedure _
             , sproc _
             , New SqlParameter("@stock_id", Me.Id) _
             , New SqlParameter("@paysi_pays", pays_id) _
             , New SqlParameter("@billai_billa", billa_id) _
             , New SqlParameter("@retentiontype", Me.RetentionType) _
             )
          If dsr.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(dsr.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        ElseIf Me.m_typeId = 46 Then
          sproc = "GetUnpaidPurchaseCNAmount"
        Else
          sproc = "GetUnpaidStockAmount"
          If m_Remained.HasValue Then
            Return m_Remained.Value
          End If
        End If
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                , New SqlParameter("@billai_billa", billa_id) _
                , New SqlParameter("@stock_type", Me.m_typeId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselectionFromOtherPays(ByVal pays_id As Integer) As Decimal
      Try
        Dim sproc As String = "GetUnpaidStockRetentionAmount"
        If Me.m_typeId = 199 Then
          sproc = "GetUnpaidStockRetentionAmountFromOtherPays"
        ElseIf Me.m_typeId = 46 Then
          sproc = "GetUnpaidPurchaseCNAmountFromOtherPays"
        Else
          sproc = "GetUnpaidStockAmountFromOtherPays"
        End If
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
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
    Public Function GetRemainingAmountWithBillAcceptance(ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountWithBillAcceptance
      Try
        Dim sproc As String = "GetUnpaidStockRetentionAmount"
        If Me.m_typeId = 199 Then
          sproc = "GetUnpaidStockRetentionAmount"
          Dim dsr As DataSet = SqlHelper.ExecuteDataset( _
              Me.ConnectionString _
              , CommandType.StoredProcedure _
              , sproc _
              , New SqlParameter("@stock_id", Me.Id) _
              , New SqlParameter("@billai_billa", billa_id) _
              , New SqlParameter("@retentiontype", Me.RetentionType) _
              )
          If dsr.Tables(0).Rows.Count > 0 Then
            Return Configuration.Format(CDec(dsr.Tables(0).Rows(0)(0)), DigitConfig.Price)
          End If
        ElseIf Me.m_typeId = 46 Then
          sproc = "GetUnpaidPurchaseCNAmount"
          'ElseIf Me.m_typeId = 292 Then
          'sproc = "GetUnpaidPAAmount"
        Else
          sproc = "GetUnpaidStockAmount"
          If m_Remained.HasValue Then
            Return m_Remained.Value
          End If
        End If
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@billai_billa", billa_id) _
                , New SqlParameter("@stock_type", Me.m_typeId) _
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
      Dim pays_id As Integer
      If Not filters Is Nothing AndAlso filters.Length > 0 Then
        ReDim params(filters.Length - 2)
        For i As Integer = 0 To filters.Length - 2
          params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
        Next
        pays_id = CInt(filters(filters.Length - 1).Value)
      End If
      Dim dt As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetBillAcceptanceItemsList", params)
      dt = ds.Tables(0)

      Dim myDatatable As New TreeTable("BillAcceptanceItems")
      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("billa_id", GetType(Integer)))
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
      myDatatable.Columns.Add(New DataColumn("billai_unpaidamt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("billai_billedamt", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("billai_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("billai_retentiontype", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("stock_retention", GetType(Decimal)))

      For Each tableRow As DataRow In dt.Rows
        Dim row As TreeRow = myDatatable.Childs.Add
        row("Selected") = False
        row("Code") = tableRow("billa_code")
        row("billa_id") = tableRow("billai_billa")
        row("Linenumber") = tableRow("billai_linenumber")
        row("Date") = tableRow("billa_docdate")

        Dim billaDueDate As DateTime
        Dim billaCreditPeriod As Integer = 0
        If IsNumeric(tableRow("billa_CreditPeriod")) Then
          billaCreditPeriod = CInt(tableRow("billa_CreditPeriod"))
        End If
        If IsDate(tableRow("billa_docdate")) Then
          billaDueDate = CDate(tableRow("billa_docdate")).AddDays(billaCreditPeriod)
        End If
        row("DueDate") = billaDueDate.ToShortDateString   'tableRow("billa_docdate")
        row("Entity") = tableRow("stock_code")
        'If Not tableRow.IsNull("stock_aftertax") Then
        'row("Amount") = Configuration.FormatToString(CDec(tableRow("stock_aftertax")), DigitConfig.Price) 'tableRow("billa_gross")
        'End If
        If Not tableRow.IsNull("remain") Then
          row("Amount") = Configuration.FormatToString(CDec(tableRow("remain")), DigitConfig.Price) 'tableRow("billa_gross")
        End If
        row("stock_id") = tableRow("stock_id")
        row("stock_code") = tableRow("stock_code")
        row("stock_type") = tableRow("stock_type")
        row("stock_beforetax") = tableRow("stock_beforetax")
        row("stock_aftertax") = tableRow("stock_aftertax")
        row("stock_taxbase") = tableRow("stock_taxbase")
        'hack
        Dim payable As New BillAcceptanceItem
        payable.Id = CInt(row("stock_id"))
        payable.ParentId = CInt(row("billa_id"))
        If Not tableRow.IsNull("billai_retentiontype") Then
          payable.RetentionType = CInt(tableRow("billai_retentiontype"))
        End If
        Dim type As Integer
        If Not tableRow.IsNull("stock_type") Then
          type = CInt(tableRow("stock_type"))
        End If
        If type = 199 Then
          row("billai_retentiontype") = tableRow("billai_retentiontype")
          row("billai_unpaidamt") = Configuration.FormatToString(CDec(tableRow("remain")), DigitConfig.Price)
        ElseIf type = 292 OrElse type = 45 Then
          row("stock_retention") = tableRow("stock_retention")
          row("billai_unpaidamt") = Configuration.FormatToString(CDec(tableRow("remain")), DigitConfig.Price)
        Else
          row("billai_unpaidamt") = Configuration.FormatToString(payable.GetRemainingAmountPayselection(pays_id), DigitConfig.Price)
        End If
        row("billai_billedamt") = tableRow("billai_billedamt")
        row("billai_linenumber") = tableRow("billai_linenumber")

        row.State = RowExpandState.None
      Next
      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BillAcceptance.ListLabel}"
      End Get
    End Property
#End Region

    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "BillAcceptanceItem"
      End Get
    End Property

  End Class

  <Serializable(), DefaultMember("Item")> _
Public Class BillAcceptanceItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_billAcceptance As BillAcceptance
    Private m_pays As PaySelection
    Private m_apvi As APVatInput
    Private m_prefix As String
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal ba As BillAcceptance)
      m_billAcceptance = ba
      m_prefix = "billai"
      If Not ba.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetBillAcceptanceItems" _
      , New SqlParameter("@billa_id", m_billAcceptance.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New BillAcceptanceItem(row, "", ba)
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal pays As PaySelection)
      m_pays = pays
      m_prefix = "paysi"
      If Not pays.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetPaySelectionItems" _
      , New SqlParameter("@pays_id", pays.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New BillAcceptanceItem(row, "", pays)
        Me.Add(item)
      Next
    End Sub
    Public Sub New(ByVal apvi As APVatInput)
      m_apvi = apvi
      m_prefix = "paysi"
      If Not apvi.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetAPVatInputItems" _
      , New SqlParameter("@pays_id", apvi.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New BillAcceptanceItem(row, "", apvi)
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property BillAcceptance() As BillAcceptance
      Get
        Return m_billAcceptance
      End Get
      Set(ByVal Value As BillAcceptance)
        m_billAcceptance = Value
      End Set
    End Property
    Public Property PaySelection() As PaySelection
      Get
        Return m_pays
      End Get
      Set(ByVal Value As PaySelection)
        m_pays = Value
      End Set
    End Property
    Default Public Property Item(ByVal index As Integer) As BillAcceptanceItem
      Get
        Return CType(MyBase.List.Item(index), BillAcceptanceItem)
      End Get
      Set(ByVal value As BillAcceptanceItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
#End Region

#Region "Class Methods"
    ''' <summary>
    ''' เปลี่ยนแปลง GL
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetGLChange()
      If Not m_pays Is Nothing Then
        m_pays.OnGlChanged()
      End If
      If Not m_apvi Is Nothing Then
        m_apvi.OnGlChanged()
      End If
    End Sub
    Public Function GetRemainFromOtherDocs(ByVal doc As BillAcceptanceItem) As Decimal
      Dim ret As Decimal = 0
      For Each myDoc As BillAcceptanceItem In Me
        If Not doc Is myDoc AndAlso doc.Id = myDoc.Id AndAlso doc.EntityId = myDoc.EntityId AndAlso ((myDoc.ParentType = doc.ParentType AndAlso myDoc.ParentId <> doc.ParentId) Or myDoc.ParentId = 0 Or doc.ParentId = 0) Then
          ret += myDoc.Amount
        End If
      Next
      Return Math.Min(doc.AfterTax, doc.GetRemainingAmountPayselectionFromOtherPays(Me.m_pays.Id)) - ret
    End Function
    Public Function RealAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 46 Then
          ret -= doc.RealAmount
        Else
          ret += doc.RealAmount
        End If
      Next
      Return ret
    End Function
    Public Function UnpaidAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 46 Then
          ret -= doc.UnpaidAmount
        Else
          ret += doc.UnpaidAmount
        End If
      Next
      Return ret
    End Function
    Public Function Amount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 46 Then
          ret -= doc.Amount
        Else
          ret += doc.Amount
        End If
      Next
      Return ret
    End Function
    Public Function GetAfterTax(Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim ret As Decimal = 0
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 46 Then
          ret -= doc.AfterTax
        Else
          ret += doc.AfterTax
        End If
      Next
      Return ret
    End Function
    Public Function GetBeforeTax(Optional ByVal roundBeforeSum As Boolean = True) As Decimal
      Dim ret As Decimal = 0
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 46 Then
          ret -= doc.BeforeTax
        Else
          ret += doc.BeforeTax
        End If
      Next
      Return ret
    End Function
    Public Function GetPlusRetention() As Decimal
      Dim ret As Decimal = 0
      Dim retHt As New Hashtable
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 46 Then
          ret -= doc.AfterTax
        ElseIf doc.EntityId = 45 OrElse doc.EntityId = 292 Then
          If Not retHt.Contains(doc.Id) Then
            retHt(doc.Id) = doc.AfterTax + doc.Retention
            ret += CDec(retHt(doc.Id))
          End If
        ElseIf doc.EntityId = 199 And doc.RetentionType = 45 Then
          If Not retHt.Contains(doc.Id) Then
            Dim tmpDoc As New GoodsReceipt(doc.Id)
            tmpDoc.RefreshTaxBase()
            retHt(doc.Id) = tmpDoc.AfterTax + doc.AfterTax
            ret += CDec(retHt(doc.Id))
          End If
        ElseIf doc.EntityId = 199 And doc.RetentionType = 292 Then
          If Not retHt.Contains(doc.Id) Then
            Dim tmpDoc As New PA(doc.Id)
            tmpDoc.RefreshTaxBase()
            retHt(doc.Id) = tmpDoc.AfterTax + doc.AfterTax
            ret += CDec(retHt(doc.Id))
          End If
        Else
          ret += doc.AfterTax + doc.Retention
        End If
      Next
      Return ret
    End Function
    Public Function GetRetentionDeducted() As Decimal
      Dim ret As Decimal = 0
      Dim retHt As New Hashtable
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 45 OrElse doc.EntityId = 292 Then
          If Not retHt.Contains(doc.Id) Then
            retHt(doc.Id) = doc.Retention
            ret += CDec(retHt(doc.Id))
          End If
        ElseIf doc.EntityId = 199 AndAlso doc.RetentionType = 45 Then
          If Not retHt.Contains(doc.Id) Then
            Dim tmpDoc As New GoodsReceipt(doc.Id)
            tmpDoc.RefreshTaxBase()
            retHt(doc.Id) = doc.AfterTax
            ret += CDec(retHt(doc.Id))
          End If
        ElseIf doc.EntityId = 199 AndAlso doc.RetentionType = 292 Then
          If Not retHt.Contains(doc.Id) Then
            Dim tmpDoc As New PA(doc.Id)
            tmpDoc.RefreshTaxBase()
            retHt(doc.Id) = doc.AfterTax
            ret += CDec(retHt(doc.Id))
          End If
        Else
          ret += doc.Retention
        End If
      Next
      Return ret
    End Function
    Public Function GetRetention() As Decimal
      Dim ret As Decimal = 0
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 199 AndAlso doc.RetentionType = 45 Then
          ret += doc.Amount
        ElseIf doc.EntityId = 199 AndAlso doc.RetentionType = 292 Then
        End If
      Next
      Return ret
    End Function
    Public Function RemainingAmount() As Decimal
      Dim ret As Decimal = 0
      For Each doc As BillAcceptanceItem In Me
        If doc.EntityId = 46 Then
          ret -= (doc.UnpaidAmount - doc.Amount)
        Else
          ret += doc.UnpaidAmount - doc.Amount
        End If
      Next
      Return ret
    End Function
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each bai As BillAcceptanceItem In Me
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
        newRow("UnpaidAmount") = Configuration.FormatToString(bai.UnpaidAmount, DigitConfig.Price)
        newRow("Retention") = Configuration.FormatToString(bai.Retention, DigitConfig.Price)
        newRow("PlusRetention") = Configuration.FormatToString(bai.AfterTax + bai.Retention, DigitConfig.Price)
        newRow(Me.m_prefix & "_amt") = Configuration.FormatToString(bai.Amount, DigitConfig.Price)
        newRow(Me.m_prefix & "_note") = bai.Note
        newRow.Tag = bai
      Next
    End Sub
    Public Sub PopulateAPVatInputItem(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      'Dim remain As Decimal = 0
      For Each bai As BillAcceptanceItem In Me
        'bai.UnpaidAmount = APVatInput.GetRemainingVatAmount(bai.Id, bai.EntityId)
        'bai.Amount = bai.UnpaidAmount

        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        newRow(Me.m_prefix & "_linenumber") = i
        If bai.EntityId = 0 Then
          newRow(Me.m_prefix & "_entityType") = DBNull.Value
        Else
          newRow(Me.m_prefix & "_entityType") = bai.EntityId
        End If
        newRow("Code") = bai.Code
        newRow("DocDate") = bai.Date
        newRow("DueDate") = bai.DueDate
        If bai.Amount <> 0 Then
          newRow("Amount") = Configuration.FormatToString(bai.Amount, DigitConfig.Price)
        End If
        If bai.UnpaidAmount <> 0 Then
          newRow("RemainAmount") = Configuration.FormatToString(bai.UnpaidAmount, DigitConfig.Price)
        End If
        newRow(Me.m_prefix & "_note") = bai.Note
        newRow.Tag = bai
      Next
    End Sub
    Public Sub PopulatePaySelectionItem(ByVal dt As TreeTable, Optional ByVal refresh As Boolean = False)
      dt.Clear()
      Dim i As Integer = 0
      Dim n As Integer = 0
      Dim hashItem As New Hashtable
      Dim tmpNewSort As New Hashtable
      Dim tmpHashNoParent As New Hashtable
      Dim key As String = ""
      Dim remainningBalance As Decimal = 0
      Dim remain As Decimal = 0
      Dim index As Integer = 0

      ''ที่ต้องเก็บลงตัวแปร HashTable เพราะต้องการเรียง List ให้เป็นไปตามที่หน้าจอแสดงเพื่อแสดง ยอดค้างชำระคงเหลือ ถูกต้อง
      For Each bai As BillAcceptanceItem In Me
        If bai.ParentId <> 0 Then
          tmpNewSort(n) = bai
          n += 1
        End If
      Next
      For Each bai As BillAcceptanceItem In Me
        If bai.ParentId = 0 Then
          tmpNewSort(n) = bai
          n += 1
        End If
      Next
      'For k As Integer = 0 To tmpNewSort.Count - 1
      'If TypeOf tmpNewSort(k) Is BillAcceptanceItem Then
      'Dim bai As BillAcceptanceItem = CType(tmpNewSort(k), BillAcceptanceItem)
      'index = Me.IndexOf(bai)
      ''If refresh Then
      'key = bai.Id.ToString & "|" & bai.EntityId
      'If Not hashItem.Contains(key) Then
      'hashItem(key) = bai.GetRemainingAmountPayselection(Me.PaySelection.Id)
      'remainningBalance = CDec(hashItem(key))
      'remain = CDec(hashItem(key))
      'Me(index).UnpaidAmount = remainningBalance
      'If Me(index).BilledAmount >= remainningBalance Then
      'Me(index).Amount = remainningBalance
      'Else
      'Me(index).Amount = Me(index).BilledAmount
      'End If
      'remainningBalance -= Me(index).Amount
      'Else
      'If remainningBalance > 0 Then
      'Me(index).UnpaidAmount = remainningBalance
      'If Me(index).BilledAmount >= remainningBalance Then
      'Me(index).Amount = remainningBalance
      'Else
      'Me(index).Amount = Me(index).BilledAmount
      'End If
      'remainningBalance -= Me(index).Amount
      'Else
      'Me(index).UnpaidAmount = 0
      'Me(index).Amount = 0
      'End If
      'End If
      'End If
      ''End If
      'Next

      For k As Integer = 0 To tmpNewSort.Count - 1
        If TypeOf tmpNewSort(k) Is BillAcceptanceItem Then
          Dim bai As BillAcceptanceItem = CType(tmpNewSort(k), BillAcceptanceItem)
          index = Me.IndexOf(bai)
          'If refresh Then
          key = bai.Id.ToString & "|" & bai.EntityId
          If Not hashItem.Contains(key) Then
            hashItem(key) = bai.GetRemainingAmountPayselection(Me.PaySelection.Id)
            remainningBalance = CDec(hashItem(key))
            remain = CDec(hashItem(key))

            Me(index).UnpaidAmount = remainningBalance

            If refresh Then ''ให้ default Amount ให้ ถ้าดึงเอกสารมาวางบิล
              Me(index).UnpaidAmount = Math.Min(Me(index).BilledAmount, remainningBalance)
              If Me(index).Amount = 0 Then
                Me(index).Amount = Math.Min(Me(index).BilledAmount, remainningBalance)
              Else
                Me(index).Amount = Math.Min(Me(index).Amount, Math.Min(Me(index).BilledAmount, remainningBalance))
              End If
            End If

            remainningBalance -= Me(index).Amount
          Else
            If remainningBalance > 0 Then
              Me(index).UnpaidAmount = remainningBalance

              If refresh Then ''ให้ default Amount ให้ ถ้าดึงเอกสารมาวางบิล
                If Me(index).Amount = 0 Then
                  Me(index).Amount = Math.Min(Me(index).BilledAmount, remainningBalance)
                Else
                  Me(index).Amount = Math.Min(Me(index).Amount, Math.Min(Me(index).BilledAmount, remainningBalance))
                End If
              End If

              remainningBalance -= Me(index).Amount
            Else
              Me(index).UnpaidAmount = 0
              Me(index).Amount = 0
            End If
          End If
        End If
        'End If
      Next

      For Each bai As BillAcceptanceItem In Me
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
        newRow("DocDate") = bai.Date
        newRow("DueDate") = bai.DueDate
        newRow("paysi_retentionType") = bai.RetentionType

        bai.RemainningBalance = remain
        'If refresh Then
        'key = bai.Id.ToString & "|" & bai.EntityId
        'If Not hashItem.Contains(key) Then
        'hashItem(key) = bai.GetRemainingAmountPayselection(Me.PaySelection.Id)
        'remainningBalance = CDec(hashItem(key))
        'Else
        'If remainningBalance > 0 Then
        'If remainningBalance >= bai.UnpaidAmount Then
        'bai.UnpaidAmount = remainningBalance - bai.UnpaidAmount
        'remainningBalance -= bai.UnpaidAmount
        'Else
        'bai.UnpaidAmount = remainningBalance
        'remainningBalance -= bai.UnpaidAmount
        'End If
        'Else
        'bai.UnpaidAmount = 0
        'End If
        'End If
        'bai.Amount = bai.UnpaidAmount
        'End If

        newRow("Retention") = Configuration.FormatToString(bai.Retention, DigitConfig.Price)
        newRow("PlusRetention") = Configuration.FormatToString(bai.AfterTax + bai.Retention, DigitConfig.Price)
        newRow("RealAmount") = Configuration.FormatToString(bai.BilledAmount, DigitConfig.Price)
        newRow("UnpaidAmount") = Configuration.FormatToString(bai.UnpaidAmount, DigitConfig.Price) 'Configuration.FormatToString(Math.Min(bai.UnpaidAmount, bai.BilledAmount), DigitConfig.Price)
        newRow(Me.m_prefix & "_amt") = Configuration.FormatToString(bai.Amount, DigitConfig.Price)
        newRow("RemainningBalance") = Configuration.FormatToString(bai.RemainningBalance, DigitConfig.Price)
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
        If Not row.IsNull("paysi_parentEntity") Then
          If CInt(row("paysi_parentEntity")) = id Then
            If Not row.IsNull("paysi_parentEntityType") Then
              If CInt(row("paysi_parentEntityType")) = type Then
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
      newRow("paysi_parentEntity") = id
      newRow("paysi_parentEntityType") = type
      If desc Is Nothing OrElse IsDBNull(desc) Then
        desc = noParentText
      End If
      newRow("Code") = desc
      newRow("Button") = "invisible"
      Return newRow
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As BillAcceptanceItem) As Integer
      Return MyBase.List.Add(value)
      SetGLChange()
    End Function
    Public Sub AddRange(ByVal value As BillAcceptanceItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As BillAcceptanceItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As BillAcceptanceItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As BillAcceptanceItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As BillAcceptanceItemEnumerator
      Return New BillAcceptanceItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As BillAcceptanceItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As BillAcceptanceItem)
      MyBase.List.Insert(index, value)
      SetGLChange()
    End Sub
    Public Sub Remove(ByVal value As BillAcceptanceItem)
      MyBase.List.Remove(value)
      SetGLChange()
    End Sub
    Public Sub Remove(ByVal value As BillAcceptanceItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Remove(value(i))
      Next
      SetGLChange()
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
      SetGLChange()
    End Sub
#End Region


    Public Class BillAcceptanceItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As BillAcceptanceItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, BillAcceptanceItem)
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

  Public Class GoodsReceiptForBillAcceptance
    Inherits GoodsReceipt

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "GoodsReceiptForBillAcceptance"
      End Get
    End Property

    Public Overrides ReadOnly Property Columns() As ColumnCollection
      Get
        'If m_columns Is Nothing OrElse m_columns.Count <= 0 Then
        'm_columns = New ColumnCollection(Me.ClassName, 0)
        'End If
        'Return m_columns
        Return New ColumnCollection(Me.ClassName, 0)
      End Get
    End Property

  End Class
  Public Class APOpeningBalanceForBillAcceptance
    Inherits APOpeningBalance

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "APOpeningBalanceForBillAcceptance"
      End Get
    End Property
  End Class
  Public Class EqMaintenanceForBillAcceptance
    Inherits EqMaintenance

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "EqMaintenanceForBillAcceptance"
      End Get
    End Property
  End Class
  Public Class PurchaseCNForBillAcceptance
    Inherits PurchaseCN

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PurchaseCNForBillAcceptance"
      End Get
    End Property
  End Class
  Public Class PurchaseRetentionForBillAcceptance
    Inherits PurchaseRetention

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PurchaseRetentionForBillAcceptance"
      End Get
    End Property
    Public Overrides ReadOnly Property Columns() As ColumnCollection
      Get
        Return New ColumnCollection(Me.ClassName, 0)
      End Get
    End Property
  End Class
  Public Class PAForBillAcceptance
    Inherits PA

    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "PAForBillAcceptance"
      End Get
    End Property
  End Class
End Namespace
