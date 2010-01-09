Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class BillIssueStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "billi_status"
      End Get
    End Property
#End Region

  End Class
  Public Class BillIssue
    Inherits SimpleBusinessEntityBase
		Implements IPrintableEntity, IGLAble, IVatable, IHasIBillablePerson, ICancelable, ICheckPeriod


#Region "Members"
    Private m_docdate As Date
    Private m_employee As Employee
    Private m_creditPeriod As Integer
    Private m_note As String
    Private m_gross As Decimal
    Private m_customer As Customer
    Private m_status As BillIssueStatus

    Private m_itemCollection As MilestoneCollection

    Private m_vat As Vat
    Private m_je As JournalEntry
    Private m_singleVat As Boolean

    Private m_pmas As Hashtable
		Private m_showDetail As Boolean
		Public m_currentConnection As SqlConnection = Nothing
		Public m_currentTransaction As SqlTransaction = Nothing
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
      m_pmas = New Hashtable
      With Me
        .m_creditPeriod = 0
        .m_note = ""
        .m_docdate = Date.Now.Date
        .m_employee = New Employee
        .m_status = New BillIssueStatus(-1)
        .m_itemCollection = New MilestoneCollection(Me)
        .m_customer = New Customer
        m_singleVat = False
        m_showDetail = False

        '----------------------------Tab Entities-----------------------------------------
        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 0

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docdate
        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      RefreshPMA()
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cust") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cust") Then
          .m_customer = New Customer(CInt(dr(aliasPrefix & Me.Prefix & "_cust")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_employee") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_employee") Then
          .m_employee = New Employee(CInt(dr(aliasPrefix & Me.Prefix & "_employee")))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_creditperiod") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_creditperiod") Then
          .m_creditPeriod = CInt(dr(aliasPrefix & Me.Prefix & "_creditperiod"))
        End If

        If dr.Table.Columns.Contains("billi_docDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docDate") Then
          .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docDate"))
        End If

        If dr.Table.Columns.Contains("billi_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .m_status = New BillIssueStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If

        'm_singleVat
        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_singleVat") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_singleVat") Then
          .m_singleVat = CBool(dr(aliasPrefix & Me.Prefix & "_singleVat"))
        End If

        'กำหนดตรงๆ ไปก่อน ยังไม่ได้เก็บในตอน save
        .m_showDetail = False

        .m_vat = New Vat(Me)
        m_vat.Direction.Value = 0

        .m_je = New JournalEntry(Me)
        .m_itemCollection = New MilestoneCollection(Me)
      End With
      RefreshPMA()
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property SingleVat() As Boolean      Get        Return m_singleVat      End Get      Set(ByVal Value As Boolean)        m_singleVat = Value      End Set    End Property    Public Property ShowDetail() As Boolean
      Get
        Return m_showDetail
      End Get
      Set(ByVal Value As Boolean)
        m_showDetail = Value
      End Set
    End Property    Public Property ItemCollection() As MilestoneCollection      Get        Return m_itemCollection      End Get      Set(ByVal Value As MilestoneCollection)        m_itemCollection = Value      End Set    End Property
    Private Sub GetRidOfUnusedPMA()
      Dim pmaToRemoved As New ArrayList
      Dim found As Boolean = False
      For Each pma As PaymentApplication In Me.m_pmas.Values
        For Each mi As Milestone In Me.ItemCollection
          If mi.PaymentApplication Is pma Then
            found = True
            Exit For
          End If
        Next
        If Not found Then
          pmaToRemoved.Add(pma)
        End If
      Next
      For Each pma As PaymentApplication In pmaToRemoved
        Me.m_pmas.Remove(pma.Id)
      Next
    End Sub
    Public Function BilledPercent(ByVal pma As PaymentApplication) As Decimal
      Dim total As Decimal = 0
      Dim amt As Decimal = 0
      total += pma.ContractAmount + pma.VoInc - pma.VoDe
      If total = 0 Then
        Return 0
      End If
      Dim billedItems As MilestoneCollection = pma.ItemCollection.GetBilledCollection
      For Each mi As Milestone In Me.ItemCollection
        If Not billedItems.Contains(mi) Then
          billedItems.Add(mi)
        End If
      Next
      amt = billedItems.GetCanGetAmount
      Return (amt / total) * 100
    End Function
    Public ReadOnly Property Gross() As Decimal
      Get
        If m_itemCollection Is Nothing Then
          Return 0
        End If
        Return m_itemCollection.GetCanGetAmount
      End Get
    End Property

    Public ReadOnly Property Subtracted() As Decimal
      Get
        If m_itemCollection Is Nothing Then
          Return 0
        End If
        Return m_itemCollection.GetAdvrAmount + m_itemCollection.GetRetentionAmount + m_itemCollection.GetDiscountAmount + m_itemCollection.GetPenaltyAmount
      End Get
    End Property
    Public Property Customer() As Customer      Get
        Return m_customer
      End Get
      Set(ByVal Value As Customer)
        m_customer = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements IVatable.Date, IGLAble.Date, ICheckPeriod.DocDate      Get        Return m_docdate      End Get      Set(ByVal Value As Date)        m_docdate = Value      End Set    End Property    Public ReadOnly Property DueDate() As Date
      Get
        Return Me.DocDate.AddDays(Me.CreditPeriod)
      End Get
    End Property    Public Property Employee() As Employee      Get        Return m_employee      End Get      Set(ByVal Value As Employee)        m_employee = Value      End Set    End Property    Public Property Note() As String Implements IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property CreditPeriod() As Integer      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Integer)        m_creditPeriod = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, BillIssueStatus)      End Set    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "billissue"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "billi"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "billissue"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BillIssue.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.BillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.BillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.BillIssue.ListLabel}"
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
    End Property#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BillIssue")

      myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("billii_milestone", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Type", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String))) 'ยอดจริง
      myDatatable.Columns.Add(New DataColumn("AdvancePayment", GetType(String))) 'ยอดเงินมัดจำ
      myDatatable.Columns.Add(New DataColumn("Retention", GetType(String))) 'Retention
      myDatatable.Columns.Add(New DataColumn("DiscAndPenal", GetType(String))) 'Discount And Penalty
      myDatatable.Columns.Add(New DataColumn("ExcVATAmount", GetType(String))) 'Excluding VAT Amount
      myDatatable.Columns.Add(New DataColumn("TaxBase", GetType(String))) 'มูลค่าสินค้า/บริการ
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String))) 'ยอดวางบิล

      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private m_saving As Boolean = False
    Private Sub ResetId(ByVal oldId As Integer _
    , ByVal oldVatId As Integer, ByVal oldJeId As Integer)
      Me.Id = oldId
      Me.m_vat.Id = oldVatId
      Me.m_je.Id = oldJeId
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      m_saving = True
      With Me

        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.ItemMissing}"))
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
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        '---- AutoCode Format --------
        Me.m_je.RefreshGLFormat()
        If Not AutoCodeFormat Is Nothing Then


          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              'ตาม entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              'ตาม gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              'แยก
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_je.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_je.AutoGen = False

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cust", Me.ValidIdOrDBNull(Me.Customer)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_employee", Me.ValidIdOrDBNull(Me.Employee)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_singleVat", Me.SingleVat))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        m_currentConnection = conn
        conn.Open()
        trans = conn.BeginTransaction()
        m_currentTransaction = trans
        Dim oldId As Integer = Me.Id
        Dim oldVatId As Integer = Me.m_vat.Id
        Dim oldJeId As Integer = Me.m_je.Id
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                ResetId(oldId, oldVatId, oldJeId)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case -2
                trans.Rollback()
                ResetId(oldId, oldVatId, oldJeId)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            ResetId(oldId, oldVatId, oldJeId)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          SaveDetail(Me.Id, conn, trans)

          If Not Me.NoVat Then
            Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveVatError.Message) Then
              trans.Rollback()
              ResetId(oldId, oldVatId, oldJeId)
              Return saveVatError
            Else
              Select Case CInt(saveVatError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldId, oldVatId, oldJeId)
                  Return saveVatError
                Case Else
              End Select
            End If
          End If


          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldVatId, oldJeId)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                ResetId(oldId, oldVatId, oldJeId)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Return saveJeError
              Case Else
            End Select
          End If

          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetId(oldId, oldVatId, oldJeId)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetId(oldId, oldVatId, oldJeId)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================


          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          ResetId(oldId, oldVatId, oldJeId)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          ResetId(oldId, oldVatId, oldJeId)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
          m_saving = False
        End Try
      End With
			Me.m_currentConnection = Nothing
			Me.m_currentTransaction = Nothing
    End Function
    Private Function GetRefIdString() As String
      Dim ret As String = ""
      For Each billi As Milestone In Me.ItemCollection
        ret &= billi.Id.ToString & ","
      Next
      If ret.EndsWith(",") Then
        ret = ret.Substring(0, Len(ret) - 1)
      End If
      Return ret
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
      Dim da As New SqlDataAdapter("Select * from billissueitem where billii_billi=" & Me.Id, conn)
      Dim daOldRef As New SqlDataAdapter("select * from milestone where milestone_id in (select billii_milestone from billissueitem where billii_billi=" & Me.Id & ")" & _
      " and milestone_id not in (select billii_milestone from billissueitem where billii_billi <> " & Me.Id & ")", conn)

      Dim daNewRef As SqlDataAdapter
      Dim refIds As String = Me.GetRefIdString
      If refIds.Length > 0 Then
        daNewRef = New SqlDataAdapter("Select * from milestone where milestone_id in (" & refIds & ")", conn)
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
      da.FillSchema(ds, SchemaType.Mapped, "BillIssueItem")
      da.Fill(ds, "BillIssueItem")

      cmdBuilder = New SqlCommandBuilder(daOldRef)
      daOldRef.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daOldRef.FillSchema(ds, SchemaType.Mapped, "oldMilestone")
      daOldRef.Fill(ds, "oldMilestone")

      Dim dtNewRef As DataTable
      If Not daNewRef Is Nothing Then
        cmdBuilder = New SqlCommandBuilder(daNewRef)
        daNewRef.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daNewRef.FillSchema(ds, SchemaType.Mapped, "newMilestone")
        daNewRef.Fill(ds, "newMilestone")
        dtNewRef = ds.Tables("newMilestone")
        For Each row As DataRow In dtNewRef.Rows
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 3 Then
              row("milestone_status") = 4
							row("milestone_billIssueDate") = Now.Date
						ElseIf CInt(row("milestone_status")) = 4 AndAlso Me.Status.Value = 0 Then
							row("milestone_status") = 3
							row("milestone_billIssueDate") = DBNull.Value
						End If
					End If
        Next
      End If

      Dim dt As DataTable = ds.Tables("BillIssueItem")

      Dim dtOldRef As DataTable = ds.Tables("oldMilestone")

      For Each row As DataRow In dtOldRef.Rows
        Dim found As Boolean = False
        For Each billi As Milestone In Me.ItemCollection
          If billi.Id = CInt(row("milestone_id")) Then
            'เจอแล้ว --> 
            found = True
            Exit For
          End If
        Next
        If Not found Then
          'ไม่เจอ
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 4 Then
              row("milestone_status") = 3
							row("milestone_billIssueDate") = DBNull.Value
            End If
          End If
        End If
      Next

      Dim i As Integer = 0
      With ds.Tables("billissueitem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For Each mi As Milestone In Me.ItemCollection
          i += 1
          Dim dr As DataRow = .NewRow
          dr("billii_billi") = Me.Id
          dr("billii_linenumber") = i
          dr("billii_milestone") = mi.Id
          dr("billii_amt") = mi.Amount
          If Not mi.Cost = Decimal.MinValue Then
            dr("billii_cost") = mi.Cost
          Else
            dr("billii_cost") = DBNull.Value
          End If
          .Rows.Add(dr)
        Next
      End With

      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      If Not daNewRef Is Nothing Then
        AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If

      daOldRef.Update(GetDeletedRows(dtOldRef))
      da.Update(GetDeletedRows(dt))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(GetDeletedRows(dtNewRef))
      End If

      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.ModifiedCurrent))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.ModifiedCurrent))
      End If

      da.Update(dt.Select("", "", DataViewRowState.Added))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.Added))
      If Not daNewRef Is Nothing Then
        da.Update(dtNewRef.Select("", "", DataViewRowState.Added))
      End If
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
      Return "BillIssue"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "BillIssue"
    End Function
    Private Sub GetHeaderPrintingEntries(ByVal dpiColl As DocPrintingItemCollection)
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
    End Sub
    Private Sub GetSummaryPrintingEntries(ByVal dpiColl As DocPrintingItemCollection)

    End Sub
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection

      GetHeaderPrintingEntries(dpiColl)
      GetSummaryPrintingEntries(dpiColl)

      Dim dpi As DocPrintingItem

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'BeforeTax - ยอดไม่รวมภาษี
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetCanGetBeforeTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      If Me.Vat.Amount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.Vat.Amount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetAfterTax - Me.ItemCollection.GetBeforeTax, DigitConfig.Price)
      End If
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetAfterTax, DigitConfig.Price)
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
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetCanGetBeforeTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageTaxAmount"
      If Me.Vat.Amount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.Vat.Amount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetAfterTax - Me.ItemCollection.GetBeforeTax, DigitConfig.Price)
      End If
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageAfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAfterTax"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetAfterTax, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '--------------------------

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      Dim isMapCCname As Boolean = False
      For Each item As Milestone In Me.ItemCollection
        If Not isMapCCname Then
          'CostCenterInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "CostCenterInfo"
          dpi.Value = item.CostCenter.Code & ":" & item.CostCenter.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
          isMapCCname = True
        End If
      Next

      Dim n As Integer = 0
      Dim i As Integer = 0
      Dim y As Integer = 0
      Dim z As Integer = 0
      Dim tempCC As Integer = 0
      Dim sumAdvance As Decimal = 0
      Dim sumMilestoneAmount As Decimal = 0

      Dim sumTaxBase As Decimal = 0
      Dim sumVat As Decimal = 0
      For Each item As Milestone In Me.ItemCollection
        If Not tempCC = item.CostCenter.Id Then
          Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
          Dim ccName As String = CStr(IIf(item.CostCenter.Id = 0 OrElse item.CostCenter Is Nothing, myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.BlankParentText}"), item.CostCenter.Code & ":" & item.CostCenter.Name))

          'Item.Name = Cost Center Name
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Name"
          dpi.Value = ccName
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Code = Cost Center Name
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Code"
          dpi.Value = ccName
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.CodeAndName = Cost Center Name
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CodeAndName"
          dpi.Value = ccName
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          tempCC = item.CostCenter.Id
          n += 1
          z += 1
        End If

        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1 - y - z
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Type
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Type"
        dpi.Value = item.Type.Description
        dpi.DataType = "System.String"
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

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        dpi.Value = item.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.CodeAndName
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.CodeAndName"
        dpi.Value = item.Code & ":" & item.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.CostCenterInfo"
        dpi.Value = item.CostCenter.Code & ":" & item.CostCenter.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.CostCenterCode"
        dpi.Value = item.CostCenter.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.CostCenterName"
        dpi.Value = item.CostCenter.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.MilestoneAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.MilestoneAmount"
        If item.MileStoneAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.MileStoneAmount, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ReceiveAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ReceiveAmount"
        Select Case item.Type.Value
          Case 75
            'ผ่าน
            dpi.Value = Configuration.FormatToString(item.Advance + item.Retention + item.DiscountAmount + item.Penalty, DigitConfig.Price)
          Case 78, 79 'เพิ่ม /ลด
            dpi.Value = Configuration.FormatToString(item.DiscountAmount + item.Penalty, DigitConfig.Price)
          Case Else
            dpi.Value = ""
        End Select
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

        'Item.Advance
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Advance"
        If item.Advance = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Advance, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Retention
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Retention"
        If item.Retention = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Retention, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Discount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Discount"
        If item.DiscountAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.DiscountAmount, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Penalty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Penalty"
        If item.Penalty = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Penalty, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.DiscountAndPenalty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.DiscountAndPenalty"
        If item.Penalty + item.DiscountAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Penalty + item.DiscountAmount, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.BeforeTax
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.BeforeTax"
        If item.BeforeTax = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.BeforeTax, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.TaxBase
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.TaxBase"
        If item.TaxBase = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.TaxBase, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        If IsNumeric(item.TaxBase) Then
          sumTaxBase += CDec(item.TaxBase)
        End If
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        dpi.Value = "1"
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit"
        dpi.Value = Me.StringParserService.Parse("${res:Global.ItemCountUnitText}")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Vat
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Vat"
        dpi.Value = Configuration.FormatToString(item.Amount - item.BeforeTax, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        If item.TaxType.Value = 1 Then
          sumVat += (item.Amount - item.BeforeTax)
        End If
        dpiColl.Add(dpi)

        sumMilestoneAmount += item.MileStoneAmount
        sumAdvance += item.Advance

        If Me.ShowDetail Then
          item.ReLoadItems()
          For Each miDetailRow As TreeRow In item.ItemTable.Childs
            n += 1
            y += 1
            Dim childText As String = miDetailRow("milestonei_desc").ToString
            'Item.Name
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Name"
            dpi.Value = childText
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          Next
        End If
        n += 1
      Next

      'MessageBox.Show(m_itemCollection.PaymentApplication.TaxBase)
      'TaxBase - มูลค่าสินค้า/บริการ
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxBase"
      'dpi.Value = Configuration.FormatToString(Me.Vat.TaxBase, DigitConfig.Price)
      dpi.Value = Configuration.FormatToString(sumTaxBase - sumVat, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'MileStoneAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "MileStoneAmount"
      dpi.Value = Configuration.FormatToString(sumMilestoneAmount / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)


      'For Each item As Milestone In Me.ItemCollection


      'SummaryMileStoneAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryMileStoneAmount"
      dpi.Value = Configuration.FormatToString(sumMilestoneAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryDiscountAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryDiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetDiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AfterDiscountAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterDiscountAmount"
      dpi.Value = Configuration.FormatToString(sumMilestoneAmount - Me.ItemCollection.GetDiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvanceAmount"
      dpi.Value = Configuration.FormatToString(sumAdvance / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryAdvanceAmount"
      dpi.Value = Configuration.FormatToString(sumAdvance, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AfterAdvanceAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterAdvanceAmount"
      dpi.Value = Configuration.FormatToString((sumMilestoneAmount - Me.ItemCollection.GetDiscountAmount) - sumAdvance, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryRetentionAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryRetentionAmount"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.GetRetentionAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'AfterRetentionAmount (am เพิ่ม)
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterRetentionAmount"
      dpi.Value = Configuration.FormatToString(((sumMilestoneAmount - Me.ItemCollection.GetDiscountAmount) - sumAdvance) - Me.ItemCollection.GetRetentionAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryGoodsReceiptAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryGoodsReceiptAmount"
      dpi.Value = Configuration.FormatToString(sumTaxBase, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'SummaryGoodsReceiptAmountIncludedVat
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryGoodsReceiptAmountIncludedVat"
      dpi.Value = Configuration.FormatToString(sumTaxBase * ((100 + Me.TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'Gross Included Tax
      dpi = New DocPrintingItem
      dpi.Mapping = "GrossIncludeAddedTax"
      If Me.Vat.Amount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.Gross + Me.Vat.Amount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.Gross + (Me.ItemCollection.GetAfterTax - Me.ItemCollection.GetBeforeTax), DigitConfig.Price)
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
      dpi.Value = Configuration.FormatToString(sumTaxBase - sumVat, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageMileStoneAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageMileStoneAmount"
      dpi.Value = Configuration.FormatToString(sumMilestoneAmount / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryAdvanceAmount"
      dpi.Value = Configuration.FormatToString(sumAdvance, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageAdvanceAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageAdvanceAmount"
      dpi.Value = Configuration.FormatToString(sumAdvance / ((100 + TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryGoodsReceiptAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryGoodsReceiptAmount"
      dpi.Value = Configuration.FormatToString(sumTaxBase, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'LastPageSummaryGoodsReceiptAmountIncludedVat
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageSummaryGoodsReceiptAmountIncludedVat"
      dpi.Value = Configuration.FormatToString(sumTaxBase * ((100 + Me.TaxRate) / 100), DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      'dpi.Row = n + 1
      'dpi.Table = "Item"
      dpiColl.Add(dpi)

      'LastPageGross Included Tax
      dpi = New DocPrintingItem
      dpi.Mapping = "LastPageGrossIncludeAddedTax"
      If Me.Vat.Amount > 0 Then
        dpi.Value = Configuration.FormatToString(Me.Gross + Me.Vat.Amount, DigitConfig.Price)
      Else
        dpi.Value = Configuration.FormatToString(Me.Gross + (Me.ItemCollection.GetAfterTax - Me.ItemCollection.GetBeforeTax), DigitConfig.Price)
      End If
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      '-------------------------

      Dim n1 As Integer = 0
      For Each item As JournalEntryItem In m_je.ItemCollection
        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocItem.LineNumber"
        dpi.Value = n1 + 1
        dpi.DataType = "System.Int32"
        dpi.Row = n1 + 1
        dpi.Table = "RefDocItem"
        dpiColl.Add(dpi)

        Dim space As String = ""
        If Not item.IsDebit Then
          space = "   "
        End If
        
        'Item.AccountCode
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocItem.AccountCode"
        dpi.Value = space & item.Account.Code
        dpi.DataType = "System.String"
        dpi.Row = n1 + 1
        dpi.Table = "RefDocItem"
        dpiColl.Add(dpi)

        'Item.Account
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocItem.Account"
        dpi.Value = space & item.Account.Name
        dpi.DataType = "System.String"
        dpi.Row = n1 + 1
        dpi.Table = "RefDocItem"
        dpiColl.Add(dpi)

        'Item.CCCode
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocItem.CCCode"
        dpi.Value = item.CostCenter.Code
        dpi.DataType = "System.String"
        dpi.Row = n1 + 1
        dpi.Table = "RefDocItem"
        dpiColl.Add(dpi)

        'Item.CCName
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocItem.CCName"
        dpi.Value = item.CostCenter.Name
        dpi.DataType = "System.String"
        dpi.Row = n1 + 1
        dpi.Table = "RefDocItem"
        dpiColl.Add(dpi)

        'Item.CCInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocItem.CCInfo"
        dpi.Value = item.CostCenter.Code & ":" & item.CostCenter.Code
        dpi.DataType = "System.String"
        dpi.Row = n1 + 1
        dpi.Table = "RefDocItem"
        dpiColl.Add(dpi)

        If item.IsDebit Then
          'Item.Debit
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocItem.Debit"
          dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n1 + 1
          dpi.Table = "RefDocItem"
          dpiColl.Add(dpi)
        Else
          ' Item.Credit
          dpi = New DocPrintingItem
          dpi.Mapping = "RefDocItem.Credit"
          dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = n1 + 1
          dpi.Table = "RefDocItem"
          dpiColl.Add(dpi)
        End If


        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "RefDocItem.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n1 + 1
        dpi.Table = "RefDocItem"
        dpiColl.Add(dpi)

        n1 += 1
      Next

      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "RefCodeGL"
      dpi.Value = m_je.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDocDateGL"
      dpi.Value = m_je.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'SumDebitGL
      dpi = New DocPrintingItem
      dpi.Mapping = "SumDebitGL"
      dpi.Value = Configuration.FormatToString(m_je.DebitAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCreditGL
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCreditGL"
      dpi.Value = Configuration.FormatToString(m_je.CreditAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      'dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      Return dpiColl
    End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        Return Me.Status.Value <= 2
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteBillIssue}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        ' จัดการเอกสารอ้างอิงก่อน
        SaveDetailForDeleted(Me.Id, conn, trans)

        ' จัดการลบเอกสาร
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteBillIssue", New SqlParameter() {New SqlParameter("@billi_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.BillIssueIsReferencedCannotBeDeleted}")
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
    Private Function SaveDetailForDeleted(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer
      Dim da As New SqlDataAdapter("Select * from BillIssueItem where billii_billi=" & Me.Id, conn)

      Dim daOldRef As New SqlDataAdapter("select * from milestone where milestone_id in (select billii_milestone from billissueitem where billii_billi = " & Me.Id & ")" & _
      " and milestone_id not in (select billii_milestone from billissueitem where billii_billi <> " & Me.Id & ")", conn)

      Dim daNewRef As SqlDataAdapter
      Dim refIds As String = Me.GetRefIdString
      If refIds.Length > 0 Then
        daNewRef = New SqlDataAdapter("Select * from milestone where milestone_id in (" & refIds & ")" & _
        " and milestone_id not in (select billii_milestone from billissueitem where billii_billi <> " & Me.Id & ")", conn)
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
      da.FillSchema(ds, SchemaType.Mapped, "BillIssueItem")
      da.Fill(ds, "BillIssueItem")

      cmdBuilder = New SqlCommandBuilder(daOldRef)
      daOldRef.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans
      cmdBuilder = Nothing
      daOldRef.FillSchema(ds, SchemaType.Mapped, "oldMilestone")
      daOldRef.Fill(ds, "oldMilestone")

      Dim dtNewRef As DataTable
      If Not daNewRef Is Nothing Then
        cmdBuilder = New SqlCommandBuilder(daNewRef)
        daNewRef.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daNewRef.FillSchema(ds, SchemaType.Mapped, "newMilestone")
        daNewRef.Fill(ds, "newMilestone")
        dtNewRef = ds.Tables("newMilestone")
        For Each row As DataRow In dtNewRef.Rows
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 4 Then
              row("milestone_status") = 3
              row("milestone_billIssueDate") = DBNull.Value
            End If
          End If
        Next
      End If

      Dim dt As DataTable = ds.Tables("BillIssueItem")

      Dim dtOldRef As DataTable = ds.Tables("oldMilestone")
      For Each row As DataRow In dtOldRef.Rows
        Dim found As Boolean = False
        For Each billi As Milestone In Me.ItemCollection
          If billi.Id = CInt(row("milestone_id")) Then
            'เจอแล้ว --> 
            found = True
            Exit For
          End If
        Next
        If Not found Then
          'ไม่เจอ
          If Not row.IsNull("milestone_status") AndAlso IsNumeric(row("milestone_status")) Then
            If CInt(row("milestone_status")) = 4 Then
              row("milestone_status") = 3
              row("milestone_billIssueDate") = DBNull.Value
            End If
          End If
        End If
      Next

      Dim i As Integer = 0
      With ds.Tables("BillIssueItem")   ' ลบทั้งหมดเลย
        For Each row As DataRow In .Rows
          row.Delete()
        Next
      End With

      AddHandler da.RowUpdated, AddressOf tmpDa_MyRowUpdated
      AddHandler daOldRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      If Not daNewRef Is Nothing Then
        AddHandler daNewRef.RowUpdated, AddressOf tmpDa_MyRowUpdated
      End If

      daOldRef.Update(GetDeletedRows(dtOldRef))
      da.Update(GetDeletedRows(dt))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(GetDeletedRows(dtNewRef))
      End If
      da.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.ModifiedCurrent))
      If Not daNewRef Is Nothing Then
        daNewRef.Update(dtNewRef.Select("", "", DataViewRowState.ModifiedCurrent))
      End If
      da.Update(dt.Select("", "", DataViewRowState.Added))
      daOldRef.Update(dtOldRef.Select("", "", DataViewRowState.Added))
      If Not daNewRef Is Nothing Then
        da.Update(dtNewRef.Select("", "", DataViewRowState.Added))
      End If
      Return 1
    End Function
#End Region

#Region "ICancelable"
		Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
			Get
				Return (Me.Status.Value = 1 OrElse Me.Status.Value = 2) AndAlso Me.IsCancelable
			End Get
		End Property
		Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
			Me.Status.Value = 0
			Return Me.Save(currentUserId)
		End Function
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      'MessageBox.Show(Me.AutoCodeFormat.GLFormat.ToString)
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      MessageBox.Show("Nothing")
      Dim ds As DataSet
      If Me.m_currentConnection Is Nothing OrElse Me.m_currentTransaction Is Nothing Then
        ds = SqlHelper.ExecuteDataset(Me.ConnectionString _
        , CommandType.StoredProcedure _
        , "GetGLFormatForEntity" _
        , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Else
        ds = SqlHelper.ExecuteDataset(Me.m_currentConnection _
       , Me.m_currentTransaction _
        , CommandType.StoredProcedure _
        , "GetGLFormatForEntity" _
        , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      End If

      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Private Function GetMilestoneCostWithoutThisBillIssue(ByVal pmaId As Integer) As Decimal
      Try
        Dim ds As DataSet
        If Me.m_currentConnection Is Nothing OrElse Me.m_currentTransaction Is Nothing Then
          ds = SqlHelper.ExecuteDataset( _
          Me.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetMilestoneCostWithoutThisBillIssue" _
          , New SqlParameter("@billi_id", Me.Id) _
          , New SqlParameter("@pma_id", pmaId) _
          )
        Else
          ds = SqlHelper.ExecuteDataset( _
          Me.m_currentConnection _
           , Me.m_currentTransaction _
          , CommandType.StoredProcedure _
          , "GetMilestoneCostWithoutThisBillIssue" _
          , New SqlParameter("@billi_id", Me.Id) _
          , New SqlParameter("@pma_id", pmaId) _
          )
        End If

        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception

      End Try
      Return 0
    End Function
    Private Function GetMilestoneAmountWithoutThisBillIssue(ByVal pmaId As Integer) As Decimal
      Try
        Dim ds As DataSet
        If Me.m_currentConnection Is Nothing OrElse Me.m_currentTransaction Is Nothing Then
          ds = SqlHelper.ExecuteDataset( _
          Me.ConnectionString _
          , CommandType.StoredProcedure _
          , "GetMilestoneAmountWithoutThisBillIssue" _
          , New SqlParameter("@billi_id", Me.Id) _
          , New SqlParameter("@pma_id", pmaId) _
          )
        Else
          ds = SqlHelper.ExecuteDataset( _
          Me.m_currentConnection _
           , Me.m_currentTransaction _
          , CommandType.StoredProcedure _
          , "GetMilestoneAmountWithoutThisBillIssue" _
          , New SqlParameter("@billi_id", Me.Id) _
          , New SqlParameter("@pma_id", pmaId) _
          )
        End If
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception

      End Try
      Return 0
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      GetRidOfUnusedPMA()

      For Each pma As PaymentApplication In Me.m_pmas.Values
        Dim cc As CostCenter = pma.CostCenter
        Dim cust As Customer = Me.Customer
        If cc.Originated AndAlso cust.Originated Then
          Dim theCost As Decimal = 0
          For Each mi As Milestone In Me.ItemCollection
            If Not TypeOf mi Is AdvanceMileStone AndAlso Not TypeOf mi Is Retention Then
              If mi.Cost = Decimal.MinValue Then
                mi.Cost = 0
                Dim amt As Decimal = 0
                If pma.IncludeThisItem(mi) Then
                  Dim itemAmount As Decimal = mi.Amount
                  itemAmount = Configuration.Format(itemAmount, DigitConfig.Price)
                  If TypeOf mi Is VariationOrderDe Then
                    amt = -itemAmount
                  Else
                    amt = itemAmount
                  End If
                End If
                Dim Pn As Decimal = amt / pma.ContractAmount
                Dim E As Decimal = pma.Budget
                Dim Bn As Decimal = Pn * E + (E * (GetMilestoneAmountWithoutThisBillIssue(pma.Id) / pma.ContractAmount) - GetMilestoneCostWithoutThisBillIssue(pma.Id))
                'Dim str As String
                'str = String.Format("{0} * {1} + ({2} * ({3} / {4}) - {5})", Pn, E, E, GetMilestoneAmountWithoutThisBillIssue(pma.Id), pma.ContractAmount, GetMilestoneCostWithoutThisBillIssue(pma.Id))
                'MessageBox.Show(str)
                mi.Cost = Bn
              End If
              theCost += mi.Cost
            End If
          Next

          If theCost <> 0 Then
            'ต้นทุน C7.1
            ji = New JournalEntryItem
            ji.Amount = theCost
            ji.Mapping = "C7.1"
            ji.CostCenter = cc
            jiColl.Add(ji)

            'WIP C7.2
            ji = New JournalEntryItem
            ji.Amount = theCost
            ji.Mapping = "C7.2"
            ji.CostCenter = cc
            If Not cc.WipAccount Is Nothing AndAlso cc.WipAccount.Originated Then
              ji.Account = cc.WipAccount
            End If
            jiColl.Add(ji)
          End If


          Dim discountVatAmount As Decimal = 0
          'ส่วนลดจ่าย C7.8
          Dim discount As Decimal = Me.ItemCollection.GetCanGetDiscountAmount(pma)
          If discount <> 0 Then
            Dim amt As Decimal
            Select Case pma.TaxType.Value
              Case 0       'ไม่มี
                amt = discount
                discountVatAmount = 0
              Case 1       'แยก
                amt = discount
                discountVatAmount = BusinessLogic.Vat.GetVatAmount(amt)
              Case 2       'รวม
                amt = BusinessLogic.Vat.GetExcludedVatAmount(discount)
                discountVatAmount = (discount) - amt
            End Select
            ji = New JournalEntryItem
            ji.Amount = amt
            ji.Mapping = "C7.8"
            ji.CostCenter = cc
            jiColl.Add(ji)

            'Vat ของส่วนลดจ่าย C7.9/C7.10
            ji = New JournalEntryItem
            ji.Amount = discountVatAmount
            If pma.TaxPoint.Value = 1 Then
              ji.Mapping = "C7.9"
            Else
              ji.Mapping = "C7.10"
            End If
            ji.CostCenter = cc
            jiColl.Add(ji)

            'ลูกหนี้การค้าของส่วนลด C7.11
            ji = New JournalEntryItem
            ji.Amount = amt + discountVatAmount
            ji.Mapping = "C7.11"
            ji.CostCenter = cc
            jiColl.Add(ji)
          End If

          Dim advrCol As MilestoneCollection = Me.ItemCollection.GetAdvanceCollection(pma)
          Dim rtnCol As MilestoneCollection = Me.ItemCollection.GetRetentionCollection(pma)
          If pma.ContractAmount <> 0 Then
            Dim amt As Decimal      'TaxBase
            Dim vatAmt As Decimal      'ภาษี

            Dim aAmt As Decimal = 0      'ยอดมัดจำ
            If Not advrCol Is Nothing Then
              aAmt = advrCol.GetBeforeTax       'aAmt = advrCol.GetAmount
            End If
            Dim sumAmt As Decimal      'ลูกหนี้

            'sumAmt = Me.GetMilestoneAmountAftertax
            sumAmt = Me.ItemCollection.GetCanGetMilestoneAmountAfterTax(pma)

            'amt = Me.GetPseudoTaxBase(pma.Id) - pma.Retention

            amt = Me.GetPseudoTaxBase(pma.Id) + Me.GetPseudoOtherTaxBase(pma.Id)


            'vatAmt = Me.GetPseudoTaxAmount(pma.Id) + Me.GetPseudoOtherTaxAmount(pma.Id)
            'amt = sumAmt - vatAmt - aAmt
            If pma.TaxType.Value <> 0 Then
              vatAmt = sumAmt - amt       'sumAmt - amt - aAmt
            End If

            'กรณีเบิกมัดจำ
            If Not advrCol Is Nothing AndAlso aAmt <> 0 Then
              ji = New JournalEntryItem
              ji.Amount = aAmt
              ji.Mapping = "C7.7"

              ji.CostCenter = cc
              jiColl.Add(ji)
            End If

            Dim miType As Integer
            For Each mi As Milestone In Me.ItemCollection
              miType = mi.Type.Value
            Next
            If miType = 75 OrElse miType = 78 OrElse miType = 79 Then
              'รายได้จากงานก่อสร้าง C7.4
              If pma.TaxType.Value = 0 Then
                ji = New JournalEntryItem
                ji.Amount = sumAmt
                ji.Mapping = "C7.4"
                ji.CostCenter = cc
                jiColl.Add(ji)
              Else
                ji = New JournalEntryItem
                ji.Amount = amt
                ji.Mapping = "C7.4"
                ji.CostCenter = cc
                jiColl.Add(ji)
              End If
            End If
            If vatAmt <> 0 Then
              'Vat C7.5/C7.6
              ji = New JournalEntryItem
              ji.Amount = vatAmt
              If pma.TaxPoint.Value = 1 Then
                'Tax ที่นี่
                ji.Mapping = "C7.5"
              Else
                'Tax ที่รับชำระหนี้
                ji.Mapping = "C7.6"
              End If
              ji.CostCenter = cc
              jiColl.Add(ji)
            End If

            'ลูกหนี้การค้า C7.3
            ji = New JournalEntryItem
            ji.Amount = sumAmt
            ji.Mapping = "C7.3"
            ji.CostCenter = cc
            If Not cust.Account Is Nothing AndAlso cust.Originated Then
              ji.Account = cust.Account
            End If
            jiColl.Add(ji)
          End If     'pma.ContractAmount <> 0

          'ค่าปรับ C7.12
          Dim penalty As Decimal = Me.ItemCollection.GetPenaltyAmount(pma)
          If penalty <> 0 Then
            ji = New JournalEntryItem
            ji.Amount = penalty
            ji.Mapping = "C7.12"
            ji.CostCenter = cc
            jiColl.Add(ji)

            'ลูกหนี้การค้าของค่าปรับ C7.13
            ji = New JournalEntryItem
            ji.Amount = penalty
            ji.Mapping = "C7.13"
            ji.CostCenter = cc
            If Not cust.Account Is Nothing AndAlso cust.Originated Then
              ji.Account = cust.Account
            End If
            jiColl.Add(ji)
          End If


          'หักเงินมัดจำรับล่วงหน้า C7.14
          Dim advrAmt As Decimal = Me.ItemCollection.GetAdvrAmount(pma)
          If advrAmt <> 0 Then
            Dim amt As Decimal
            Dim vatAmt As Decimal
            Select Case pma.TaxType.Value
              Case 0       'ไม่มี
                amt = advrAmt
                vatAmt = 0
              Case 1       'แยก
                amt = advrAmt
                vatAmt = BusinessLogic.Vat.GetVatAmount(amt)
              Case 2       'รวม
                amt = BusinessLogic.Vat.GetExcludedVatAmount(advrAmt)
                vatAmt = (advrAmt) - amt

                'Case 1 'แยก
                '  amt = advrAmt
                '  vatAmt = BusinessLogic.Vat.GetVatAmount(amt)
                'Case 2 'รวม
                '  amt = BusinessLogic.Vat.GetExcludedVatAmount(advrAmt)
                '  vatAmt = (advrAmt) - amt
            End Select
            ji = New JournalEntryItem
            ji.Amount = amt
            ji.Mapping = "C7.14"
            ji.CostCenter = cc
            jiColl.Add(ji)

            If pma.TaxType.Value > 0 Then
              'ภาษีของหักเงินมัดจำรับล่วงหน้า C7.15/16
              ji = New JournalEntryItem
              ji.Amount = vatAmt
              If pma.TaxPoint.Value = 1 Then
                ji.Mapping = "C7.15"
              Else
                ji.Mapping = "C7.16"
              End If
              ji.CostCenter = cc
              jiColl.Add(ji)
            End If

            'ลูกหนี้การค้าของการหักเงินมัดจำรับล่วงหน้า C7.17
            ji = New JournalEntryItem
            ji.Amount = amt + vatAmt
            ji.Mapping = "C7.17"
            ji.CostCenter = cc
            If Not cust.Account Is Nothing AndAlso cust.Originated Then
              ji.Account = cust.Account
            End If
            jiColl.Add(ji)
          End If

          Dim tmp As Object = Configuration.GetConfig("ARRetentionPoint")
          Dim apRetentionPoint As Integer = 0
          If IsNumeric(tmp) Then
            apRetentionPoint = CInt(tmp)
          End If
          Dim retentionHere As Boolean = (apRetentionPoint = 0)

          'หักเงิน Retention C7.18
          Dim rtnAmt As Decimal = Me.ItemCollection.GetRetentionAmount(pma)
          If retentionHere AndAlso rtnAmt <> 0 Then
            ji = New JournalEntryItem
            ji.Amount = rtnAmt
            ji.Mapping = "C7.18"
            ji.CostCenter = cc
            jiColl.Add(ji)

            'ลูกหนี้การค้าของการหักเงิน Retention C7.19
            ji = New JournalEntryItem
            ji.Amount = rtnAmt
            ji.Mapping = "C7.19"
            ji.CostCenter = cc
            If Not cust.Account Is Nothing AndAlso cust.Originated Then
              ji.Account = cust.Account
            End If
            jiColl.Add(ji)
          End If


          'มีเบิก Retention
          'Dim rtnCol As MilestoneCollection = Me.ItemCollection.GetRetentionCollection(pma)
          If Not rtnCol Is Nothing AndAlso rtnCol.GetAmount <> 0 Then
            Dim rtn As Decimal = rtnCol.GetAmount
            ''ลูกหนี้การค้าของการเบิกเงิน Retention C7.20
            'ji = New JournalEntryItem
            'ji.Amount = rtn
            'ji.Mapping = "C7.20"
            'ji.CostCenter = cc
            'If Not cust.Account Is Nothing AndAlso cust.Originated Then
            '    ji.Account = cust.Account
            'End If
            'jiColl.Add(ji)

            'การเบิกเงิน Retention C7.21
            ji = New JournalEntryItem
            ji.Amount = rtn
            ji.Mapping = "C7.21"
            ji.CostCenter = cc
            jiColl.Add(ji)
          End If

        End If
      Next
      Return jiColl
    End Function
    Public Function GetJournalEntriesx() As JournalEntryItemCollection  'Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem

      GetRidOfUnusedPMA()

      For Each pma As PaymentApplication In Me.m_pmas.Values
        Dim cc As CostCenter = pma.CostCenter
        Dim cust As Customer = Me.Customer
        If cc.Originated AndAlso cust.Originated Then
          Dim bp As Decimal = Me.BilledPercent(pma) / 100




        End If
      Next
      Return jiColl
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
#End Region

#Region "IVatable"
		Public Sub GenVatItems()
			Me.Vat.ItemCollection.Clear()
			If Me.TaxTypeIs0 Then
				Return
			End If
			Dim i As Integer = 0
			Dim vi As New VatItem
			'Dim ptn As String = Entity.GetAutoCodeFormat(vi.EntityId)
			'Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
			'pattern = CodeGenerator.GetPattern(pattern)
			'Dim lastCode As String = vi.GetLastCode(pattern)
			For Each item As Milestone In Me.ItemCollection
				If item.TaxType.Value <> 0 AndAlso item.TaxPoint.Value <> 2 Then
					i += 1
					Dim vitem As New VatItem
					'vitem.LineNumber = i
					'Dim newCode As String = CodeGenerator.Generate(ptn, lastCode, Me)
					vitem.Code = ""		 'newCode
					'lastCode = newCode
					vitem.AutoGen = True
					vitem.DocDate = Me.DocDate
					vitem.PrintName = Me.Customer.Name
					vitem.PrintAddress = Me.Customer.BillingAddress
					If TypeOf item Is VariationOrderDe Then
						vitem.TaxBase = -item.TaxBase
					Else
						vitem.TaxBase = item.TaxBase
					End If
					vitem.TaxRate = TaxRate
					vitem.CcId = item.CostCenter.Id
					vitem.Milestone = item
					Me.Vat.ItemCollection.Add(vitem)
				End If
			Next
		End Sub
		Public Sub GenSingleVatItem()
			Me.Vat.ItemCollection.Clear()
			Dim vitem As New VatItem
			vitem.LineNumber = 1
			'Dim ptn As String = Entity.GetAutoCodeFormat(vitem.EntityId)
			'Dim pattern As String = CodeGenerator.GetPattern(ptn, Me)
			'pattern = CodeGenerator.GetPattern(pattern)
			vitem.Code = ""	 'CodeGenerator.Generate(ptn, vitem.GetLastCode(pattern), Me)
			vitem.AutoGen = True
			vitem.DocDate = Me.DocDate
			vitem.PrintName = Me.Customer.Name
			vitem.PrintAddress = Me.Customer.BillingAddress
			vitem.TaxBase = Me.GetMaximumTaxBase
			vitem.TaxRate = TaxRate
			Me.Vat.ItemCollection.Add(vitem)
		End Sub
		Public ReadOnly Property TaxTypeIs0() As Boolean			Get				RefreshPMA()				For Each mi As Milestone In Me.ItemCollection
					If mi.TaxType.Value <> 0 Then
						Return False
					End If
				Next				Return True			End Get		End Property
		Public ReadOnly Property TaxAmount() As Decimal			Get				Return Me.ItemCollection.GetCanGetTaxAmount			End Get		End Property
		Public ReadOnly Property TaxRate() As Decimal
			Get
				Return CDec(Configuration.GetConfig("CompanyTaxRate"))
			End Get
		End Property
		Public Function GetMilestoneAmountAftertax() As Decimal
			Return Me.ItemCollection.GetCanGetMilestoneAmountAfterTax
		End Function
		Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
			Return Me.ItemCollection.GetCanGetAfterTax
		End Function
		Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
			Return Me.ItemCollection.GetCanGetBeforeTax
		End Function
		Public Property TaxBase() As Decimal Implements IVatable.TaxBase
			Get
				Return Me.GetMaximumTaxBase
			End Get
			Set(ByVal Value As Decimal)

			End Set
		End Property
		Public Function GetMaximumTaxBase() As Decimal Implements IVatable.GetMaximumTaxBase
			Dim amt As Decimal
			For Each item As Milestone In Me.ItemCollection
				If item.TaxType.Value <> 0 AndAlso item.TaxPoint.Value <> 2 Then
					If TypeOf item Is VariationOrderDe Then
						amt -= Configuration.Format(item.TaxBase, DigitConfig.Price)
					Else
						amt += Configuration.Format(item.TaxBase, DigitConfig.Price)
					End If
				End If
			Next
			Return Configuration.Format(amt, DigitConfig.Price)
		End Function
		Public Function GetPseudoTaxBase(ByVal pmaId As Integer) As Decimal
			Dim amt As Decimal
			For Each item As Milestone In Me.ItemCollection
				If item.PMAId = pmaId Then
					If item.TaxType.Value <> 0 Then
						If TypeOf item Is VariationOrderDe Then
							amt -= Configuration.Format(item.TaxBase, DigitConfig.Price)
						Else
							amt += Configuration.Format(item.TaxBase, DigitConfig.Price)
						End If
					Else
						If TypeOf item Is VariationOrderDe Then
							amt -= Configuration.Format(item.BeforeTax, DigitConfig.Price)
						Else
							amt += Configuration.Format(item.BeforeTax, DigitConfig.Price)
						End If
					End If
				End If
			Next
			Return Configuration.Format(amt, DigitConfig.Price)
		End Function
		Public Function GetPseudoTaxAmount(ByVal pmaId As Integer) As Decimal
			Dim amt As Decimal
			For Each item As Milestone In Me.ItemCollection
				If item.PMAId = pmaId Then
					If item.TaxType.Value <> 0 Then
						If TypeOf item Is VariationOrderDe Then
							amt -= Configuration.Format(item.TaxBase, DigitConfig.Price)
						Else
							amt += Configuration.Format(item.TaxBase, DigitConfig.Price)
						End If
					End If
				End If
			Next
			Return Configuration.Format(Vat.GetVatAmount(amt), DigitConfig.Price)
		End Function
		Public Function GetPseudoOtherTaxBase(ByVal pmaId As Integer) As Decimal
			Dim amt As Decimal = 0
			For Each item As Milestone In Me.ItemCollection
				If item.PMAId = pmaId Then
					amt -= item.PseudoOtherTaxBase
				End If
			Next
			Return Configuration.Format(amt, DigitConfig.Price)
		End Function
		Public Function GetPseudoOtherTaxAmount(ByVal pmaId As Integer) As Decimal
			Dim amt As Decimal
			For Each item As Milestone In Me.ItemCollection
				If item.PMAId = pmaId Then
					If item.TaxType.Value <> 0 Then
						If TypeOf item Is VariationOrderDe Then
							amt += item.OtherTaxBase
						Else
							amt -= item.OtherTaxBase
						End If
					End If
				End If
			Next
			Return Configuration.Format(Vat.GetVatAmount(amt), DigitConfig.Price)
		End Function
		Public Function GetOtherTaxBase() As Decimal
			Dim amt As Decimal
			For Each item As Milestone In Me.ItemCollection
				If item.TaxType.Value <> 0 AndAlso item.TaxPoint.Value <> 2 Then
					If TypeOf item Is VariationOrderDe Then
						amt -= item.OtherTaxBase
					Else
						amt += item.OtherTaxBase
					End If
				End If
			Next
			Return Configuration.Format(amt, DigitConfig.Price)
		End Function
		Public Property Person() As IBillablePerson Implements IVatable.Person
			Get
				Return Me.Customer
			End Get
			Set(ByVal Value As IBillablePerson)
			End Set
		End Property
		Public Property Vat() As Vat Implements IVatable.Vat
			Get
				Return Me.m_vat
			End Get
			Set(ByVal Value As Vat)
				Me.m_vat = Value
			End Set
		End Property
		Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
			Get
				If Not m_saving Then
					RefreshPMA()
				End If
				For Each mi As Milestone In Me.ItemCollection
					If mi.TaxPoint.Value = 1 Then
						Return False
					End If
				Next
				Return True
			End Get
		End Property
		Public Sub RefreshPMA()
			For Each item As Milestone In Me.ItemCollection
				If Not Me.m_pmas.Contains(item.PMAId) Then
					Me.m_pmas(item.PMAId) = New PaymentApplication(item.PMAId)
				End If
				item.PaymentApplication = CType(Me.m_pmas(item.PMAId), PaymentApplication)
			Next
		End Sub
		Public Sub PopulateItemListing(ByVal dt As TreeTable, ByVal showDetail As Boolean)
			dt.Clear()
			Me.RefreshPMA()
			Dim i As Integer
			For Each item As Milestone In Me.ItemCollection
				i += 1
				Dim parRow As TreeRow = FindRow(item.CostCenter.Id, item.CostCenter.Code & ":" & item.CostCenter.Name, dt)
				Dim row As TreeRow = parRow.Childs.Add()
				row("Linenumber") = i
				row("Type") = item.Type.Description
				row("billii_milestone") = item.Code & ":" & item.Name
				row("RealAmount") = Configuration.FormatToString(item.MileStoneAmount, DigitConfig.Price)
				row("AdvancePayment") = Configuration.FormatToString(item.Advance, DigitConfig.Price)
				row("Retention") = Configuration.FormatToString(item.Retention, DigitConfig.Price)
				row("DiscAndPenal") = Configuration.FormatToString(item.DiscountAmount + item.Penalty, DigitConfig.Price)
				row("ExcVATAmount") = Configuration.FormatToString(item.BeforeTax, DigitConfig.Price)
				row("TaxBase") = Configuration.FormatToString(item.TaxBase, DigitConfig.Price)
				row("Amount") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
				row.Tag = item
				If showDetail Then
					'แสดงรายละเอียด
					row.State = RowExpandState.Expanded
					item.ReLoadItems()
					For Each miDetailRow As TreeRow In item.ItemTable.Childs
						Dim childRow As TreeRow = row.Childs.Add
						Dim childText As String = miDetailRow("milestonei_desc").ToString
						If Not miDetailRow.IsNull("milestonei_qty") AndAlso IsNumeric(miDetailRow("milestonei_qty")) AndAlso CDec(miDetailRow("milestonei_qty")) > 0 Then
							Dim unitText As String = ""
							If Not miDetailRow.IsNull("Unit") Then
								unitText = " " & miDetailRow("Unit").ToString
							End If
							childText &= (Configuration.FormatToString(CDec(miDetailRow("milestonei_qty")), DigitConfig.Qty) & unitText)
						End If
						childRow("billii_milestone") = childText
					Next
				End If
			Next
			dt.AcceptChanges()
		End Sub
		Public Function FindRow(ByVal id As Integer, ByVal desc As String, ByVal dt As TreeTable) As TreeRow
			For Each row As TreeRow In dt.Childs
				If CInt(row.Tag) = id Then
					Return row
				End If
			Next
			Dim newRow As TreeRow
			Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
			Dim noParentText As String = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BillIssueDetail.BlankParentText}")
			If id = 0 Then
				newRow = dt.Childs.Add
			Else
				Dim noParentRow As TreeRow = FindRow(0, noParentText, dt)
				newRow = dt.Childs.InsertAt(dt.Childs.IndexOf(noParentRow))
			End If
			newRow.Tag = id
			If desc Is Nothing OrElse IsDBNull(desc) Then
				desc = noParentText
			End If
			newRow("billii_milestone") = desc
			newRow.State = RowExpandState.Expanded
			Return newRow
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


	End Class
End Namespace
