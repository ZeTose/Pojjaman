Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class PettyCashClaimStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pcc_status"
      End Get
    End Property
#End Region

  End Class
  Public Class PettyCashClaim
    Inherits SimpleBusinessEntityBase
    Implements IPayable, IGLAble, IPrintableEntity, ICancelable, ICheckPeriod
        
#Region "Members"
    Private pcc_docDate As Date
    Private pcc_pc As PettyCash
    Private pcc_note As String
    Private pcc_gross As Decimal
    Private pcc_status As PettyCashClaimStatus
    Private m_itemTable As TreeTable

    Private m_payment As Payment

    Private m_je As JournalEntry
#End Region

#Region "Constructors"
    Public Sub Wire()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub UnWire()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      RemoveHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      RemoveHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      RemoveHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      Wire()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      Wire()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      Wire()
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      Wire()
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      Wire()
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .pcc_docDate = Now.Date
        .pcc_pc = New PettyCash
        .pcc_status = New PettyCashClaimStatus(-1)


        .m_payment = New Payment(Me)
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.pcc_docDate
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If Not dr.IsNull(aliasPrefix & "pcc_docDate") Then
          .pcc_docDate = CDate(dr(aliasPrefix & "pcc_docDate"))
        End If

        If Not dr.IsNull(aliasPrefix & "pcc_note") Then
          .pcc_note = CStr(dr(aliasPrefix & "pcc_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pc_id") Then
          If Not dr.IsNull(aliasPrefix & "pc_id") Then
            .pcc_pc = New PettyCash(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pcc_pc") Then
            .pcc_pc = New PettyCash(CInt(dr(aliasPrefix & "pcc_pc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "pcc_status") AndAlso Not dr.IsNull(aliasPrefix & "pcc_status") Then
          .pcc_status = New PettyCashClaimStatus(CInt(dr(aliasPrefix & "pcc_status")))
        End If

        .m_payment = New Payment(Me)

        .m_je = New JournalEntry(Me)
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable
      Get
        Return m_itemTable
      End Get
      Set(ByVal Value As TreeTable)
        m_itemTable = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements IPayable.Date, IGLAble.Date, ICheckPeriod.DocDate
      Get
        Return pcc_docDate
      End Get
      Set(ByVal Value As Date)
        pcc_docDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
        Me.m_je.DocDate = Value
      End Set
    End Property
    Public Property Note() As String Implements IPayable.Note, IGLAble.Note
      Get
        Return pcc_note
      End Get
      Set(ByVal Value As String)
        pcc_note = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property PettyCash() As PettyCash
      Get
        Return pcc_pc
      End Get
      Set(ByVal Value As PettyCash)
        pcc_pc = Value
        ChangePettyCash()
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Private Sub ChangePettyCash()
      LoadNewItems()
    End Sub
    Public ReadOnly Property Gross() As Decimal
      Get
        Return pcc_gross
      End Get
    End Property
    Public Sub UpdateGross()
      If Me.ItemTable Is Nothing OrElse Me.ItemTable.Rows.Count = 0 Then
        pcc_gross = 0
      Else
        Dim amt As Decimal = 0
        For Each row As TreeRow In Me.ItemTable.Rows
          If Not row.IsNull("Amount") AndAlso IsNumeric(row("Amount")) Then
            amt += CDec(row("Amount"))
          End If
        Next
        pcc_gross = amt
      End If
    End Sub
    Public Overrides Property Status() As CodeDescription
      Get
        Return pcc_status
      End Get
      Set(ByVal Value As CodeDescription)
        pcc_status = CType(Value, PettyCashClaimStatus)
      End Set
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PettyCashClaim"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "pcc"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PettyCashClaim.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PettyCashClaim"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PettyCashClaim"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PettyCashClaim.ListLabel}"
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
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PettyCashClaim"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "pcci_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 20
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "pcci_linenumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 40
      csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csDocDate As New TreeTextColumn
      csDocDate.MappingName = "DocDate"
      csDocDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.DocDateHeaderText}")
      csDocDate.NullText = ""
      csDocDate.Format = "d"
      csDocDate.Width = 30
      csDocDate.ReadOnly = True

      Dim csDocType As New TreeTextColumn
      csDocType.MappingName = "DocType"
      csDocType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.DocTypeHeaderText}")
      csDocType.NullText = ""
      csDocType.Width = 40
      csDocType.TextBox.Name = "DocType"
      csDocType.ReadOnly = True

      Dim csRealAmount As New TreeTextColumn
      csRealAmount.MappingName = "RealAmount"
      csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.RealAmountHeaderText}")
      csRealAmount.NullText = ""
      csRealAmount.DataAlignment = HorizontalAlignment.Right
      csRealAmount.Format = "#,###.##"
      csRealAmount.TextBox.Name = "RealAmount"
      csRealAmount.Width = 30
      csRealAmount.ReadOnly = True

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.TextBox.Name = "Amount"
      csAmount.Width = 30
      csAmount.ReadOnly = False

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PettyCashClaimDetail.NoteHeaderText}")
      csNote.NullText = ""
      csNote.DataAlignment = HorizontalAlignment.Left
      csNote.TextBox.Name = "Note"
      csNote.TextBox.Width = 100
      'csNote.TextBox.MaxLength = 2000
      csNote.ReadOnly = False

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csDocDate)
      dst.GridColumnStyles.Add(csDocType)
      dst.GridColumnStyles.Add(csRealAmount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)
      Return dst
    End Function

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PettyCashClaim")

      myDatatable.Columns.Add(New DataColumn("pcci_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pcci_payment", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pcci_paymentilinenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocType", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("DocDate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RealAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldpay As Integer, ByVal oldje As Integer)
      Me.Id = oldid
      Me.m_payment.Id = oldid
      Me.m_je.Id = oldje
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.MaxRowIndex < 0 Then '.ItemTable.Childs.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If
        If Me.Payment.Gross < Me.Gross Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.PaymentAmountMissing}"))
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
          paramArrayList.Add(New SqlParameter("@pcc_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_payment.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If

        'If Me.AutoGen Then 'And Me.Code.Length = 0 
        'Me.Code = Me.GetNextCode
        'End If
        'Me.AutoGen = False
        Me.UpdateGross()


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
        Me.m_payment.Code = m_je.Code
        Me.m_payment.DocDate = m_je.DocDate
        If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
          Me.m_payment.Code = Me.Code
          Me.m_payment.DocDate = Me.DocDate
        End If
        Me.AutoGen = False
        Me.m_payment.AutoGen = False
        Me.m_je.AutoGen = False

        paramArrayList.Add(New SqlParameter("@pcc_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@pcc_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@pcc_pc", Me.ValidIdOrDBNull(Me.PettyCash)))
        paramArrayList.Add(New SqlParameter("@pcc_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@pcc_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@pcc_status", Me.Status.Value))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' สร้าง SqlParameter จาก ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldpay As Integer = m_payment.Id
        Dim oldje As Integer = m_je.Id

        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldje)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If
          Dim pmGross As Decimal = Me.Payment.Gross()
          If pmGross < Me.Gross Then
            Dim diff As Decimal = Me.Gross - pmGross
            Dim newPaymentItem As New PaymentItem
            Me.m_payment.ItemCollection.Insert(0, newPaymentItem)
            newPaymentItem.EntityType = New PaymentEntityType(Me.PettyCash.EntityId)
            newPaymentItem.Entity = Me.PettyCash
            newPaymentItem.Amount = diff
          End If
          If Not Me.PettyCash.Costcenter Is Nothing Then
            Me.m_payment.CCId = Me.PettyCash.Costcenter.Id
          End If

          Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
          If Not IsNumeric(savePaymentError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldje)
            Return savePaymentError
          Else
            Select Case CInt(savePaymentError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje)
                Return savePaymentError
              Case Else
            End Select
          End If
          ChangeOldItemStatus(conn, trans)
          SaveDetail(Me.Id, conn, trans)
          ChangeNewItemStatus(conn, trans)


          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldpay, oldje)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldpay, oldje)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Return saveJeError
              Case Else
            End Select
          End If

          Me.DeleteRef(conn, trans)
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateGR_PCCRef" _
          , New SqlParameter("@pcc_id", Me.Id))
          If Me.Status.Value = 0 Then
            Me.CancelRef(conn, trans)
          End If
          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetID(oldid, oldpay, oldje)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid, oldpay, oldje)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldpay, oldje)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPaymentItemStatus", New SqlParameter("@pcc_id", Me.Id))
    End Sub
    Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      If Not Me.Originated Then
        Return
      End If
      SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPaymentItemStatus", New SqlParameter("@pcc_id", Me.Id))
    End Sub
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code 'Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer

      Dim da As New SqlDataAdapter("Select * from PettyCashClaimItem where pcci_pcc=" & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "PettyCashClaimItem")

      Dim i As Integer = 0
      With ds.Tables("PettyCashClaimItem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For n As Integer = 0 To Me.MaxRowIndex
          Dim itemRow As TreeRow = Me.m_itemTable.Childs(n)
          Dim item As New PettyCashClaimItem
          item.CopyFromDataRow(itemRow)
          If ValidateRow(itemRow) Then
            i += 1
            Dim dr As DataRow = .NewRow
            dr("pcci_pcc") = Me.Id
            dr("pcci_linenumber") = i
            dr("pcci_payment") = item.Paymentid
            dr("pcci_paymentilinenumber") = item.PaymentLine
            dr("pcci_refdocCode") = item.RefDocCode
            dr("pcci_refDocType") = item.EntityType.Value
            dr("pcci_refDocDate") = item.RefDocDate
            dr("pcci_paymentAmt") = item.RefDocAmount
            dr("pcci_amt") = item.PaidAmount
            dr("pcci_note") = item.Note
            .Rows.Add(dr)
          End If
        Next
      End With
      Dim dt As DataTable = ds.Tables("PettyCashClaimItem")
      ' First process deletes.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      ' Next process updates.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      ' Finally process inserts.
      da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
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
      LoadItems(ds, aliasPrefix)
      Me.IsInitialized = True
    End Sub
    Public Sub LoadNewItems()
      Me.ItemTable.Clear()
      If Not Me.PettyCash.Originated Then
        Return
      End If
      Dim myId As Object
      If Me.Originated Then
        myId = Me.Id
      Else
        myId = DBNull.Value
      End If
      Dim grNeedsApproval As Boolean = False
      grNeedsApproval = CBool(Configuration.GetConfig("ApproveDO"))
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetNewPettyCashClaimItems" _
      , New SqlParameter("@pc_id", Me.PettyCash.Id) _
      , New SqlParameter("@pcc_id", myId) _
      , New SqlParameter("@grNeedsApproval", grNeedsApproval) _
      )
      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New PettyCashClaimItem(row, "")
        item.PettyCashClaim = Me
        Me.Add(item)
      Next
    End Sub
    Private Overloads Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetPettyCashClaimItems" _
      , New SqlParameter("@pcc_id", Me.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New PettyCashClaimItem(row, "")
        item.PettyCashClaim = Me
        Me.Add(item)
      Next
    End Sub
    Private Overloads Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New PettyCashClaimItem(dr, aliasPrefix)
        item.PettyCashClaim = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim item As New PettyCashClaimItem
        Me.ItemTable.AcceptChanges()
        Me.Add(item)
      Next
    End Sub
    Public Function Add(ByVal item As PettyCashClaimItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.PettyCashClaim = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As PettyCashClaimItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.PettyCashClaim = Me
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
        Me.ItemTable.Childs(i)("pcci_linenumber") = i + 1
      Next
    End Sub
    Public Function MaxRowIndex() As Integer
      If Me.m_itemTable Is Nothing Then
        Return -1
      End If
      'ให้ค่า index ของแถวสุดท้ายที่มีข้อมูล
      For i As Integer = Me.m_itemTable.Childs.Count - 1 To 0 Step -1
        Dim row As TreeRow = Me.m_itemTable.Childs(i)
        If ValidateRow(row) Then
          Return i
        End If
      Next
      Return -1 'ไม่มีข้อมูลเลย
    End Function
#End Region

#Region "TreeTable Handlers"
    Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_itemTable.Childs.IndexOf(CType(e.Row, TreeRow))
      If ValidateRow(CType(e.Row, TreeRow)) Then
        If index = Me.m_itemTable.Childs.Count - 1 Then
          Me.AddBlankRow(1)
        End If
        Me.UpdateGross()
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        Me.OnPropertyChanged(Me, pe)
        Me.m_itemTable.AcceptChanges()
      End If
    End Sub
    Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not Me.IsInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "amount"

            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            If IsNumeric(e.ProposedValue) Then
              Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              e.ProposedValue = Configuration.FormatToString(value, DigitConfig.Price)
            End If

        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)

    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim RealAmount As Object = row("RealAmount")
      Dim Amount As Object = row("Amount")
      If row.IsNull("entityType") Then
        Return False
      End If
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If IsDBNull(Amount) OrElse CDec(Amount) <= 0 Then
        row.SetColumnError("Amount", myStringParserService.Parse("${res:Global.Error.ZeroValueError}"))
        Return False
      Else
        row.SetColumnError("Amount", "")
      End If
      If CDec(Amount) > CDec(RealAmount) Then
        row.SetColumnError("Amount", myStringParserService.Parse("${res:Global.Error.PaymentAmountMissing}"))
        Return False
      Else
        row.SetColumnError("Amount", "")
      End If
      Return True
    End Function
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

#Region "IPayable"
    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      Return Me.Gross
    End Function
    Public Property DueDate() As Date Implements IPayable.DueDate
      Get
        Return Me.DocDate
      End Get
      Set(ByVal Value As Date)

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
    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Supplier.GetDefaultSupplier(Supplier.DefaultSupplierType.PettyCash)
      End Get
    End Property
    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      Return 0
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "ClaimPettyCash"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "ClaimPettyCash"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'DocCode
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate
      If Me.PettyCash.Originated Then
        dpi = New DocPrintingItem
        dpi.Mapping = "DocDate"
        dpi.Value = Me.DocDate.ToShortDateString
        dpi.DataType = "System.DateTime"
        dpiColl.Add(dpi)
      End If

      'PettyCashInfo
      If Me.PettyCash.Valid Then
        dpi = New DocPrintingItem
        dpi.Mapping = "PettyCashInfo"
        dpi.Value = Me.PettyCash.Code & ":" & Me.PettyCash.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "PettyCashCode"
        dpi.Value = Me.PettyCash.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "PettyCashName"
        dpi.Value = Me.PettyCash.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'Amount
      dpi = New DocPrintingItem
      dpi.Mapping = "Amount"
      dpi.Value = Configuration.FormatToString(Me.PettyCash.Amount, DigitConfig.Price)
      dpi.DataType = "System.string"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
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
      Dim pcCC As CostCenter = Nothing
      'If Not Me.Payment Is Nothing Then
      'Dim pmGross As Decimal = Me.Payment.Gross
      'เงินสดย่อย
      ji = New JournalEntryItem
      ji.Mapping = "G10.1"
      ji.Amount = Me.AmountToPay
      If Not Me.PettyCash Is Nothing AndAlso Not Me.PettyCash.Account Is Nothing AndAlso Me.PettyCash.Account.Originated Then
        ji.Account = Me.PettyCash.Account
      End If
      If Me.PettyCash.ToCC IsNot Nothing Then
        ji.CostCenter = Me.PettyCash.ToCC
      Else
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      pcCC = ji.CostCenter
      jiColl.Add(ji)
      'Payment
      jiColl.AddRange(Me.Payment.GetJournalEntries)

      For i As Integer = 0 To Me.MaxRowIndex
        ji = New JournalEntryItem
        ji.Mapping = "G10.1W"
        If IsNumeric(Me.ItemTable.Childs(i)("RealAmount")) Then
          ji.Amount = CDec(Me.ItemTable.Childs(i)("RealAmount"))
        Else
          ji.Amount = 0
        End If
        If Not Me.PettyCash Is Nothing AndAlso Not Me.PettyCash.Account Is Nothing AndAlso Me.PettyCash.Account.Originated Then
          ji.Account = Me.PettyCash.Account
        End If
        ji.Note = CStr(Me.ItemTable.Childs(i)("Code")) + ":" + CStr(Me.ItemTable.Childs(i)("DocType"))
        ji.CostCenter = pcCC
        jiColl.Add(ji)
        'Payment
      Next
      Return jiColl
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePettyCashClaim}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        ChangeOldItemStatus(conn, trans)
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePettyCashClaim", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.PettyCashClaimIsReferencedCannotBeDeleted}")
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

#Region ""
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Overrides Function IsCancelable() As Boolean
      If Me.Status.Value = 3 Then
        Return False
      Else
        Return True
      End If
    End Function
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Me.Payment.Status.Value = 0
      Me.JournalEntry.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region



  End Class
  Public Class PettyCashClaimEntityType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pcc_entityType"
      End Get
    End Property
#End Region

  End Class
  Public Class PettyCashClaimItem

#Region "Members"
    Private m_pcc As PettyCashClaim
    Private m_lineNumber As Integer

    Private m_paymentid As Integer
    Private m_paymentLine As Integer

    Private m_refDocCode As String
    Private m_refDocDate As Date
    Private m_refDocAmount As Decimal
    Private m_entityType As PettyCashClaimEntityType

    Private m_paidAmount As Decimal
    Private m_note As String
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
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_refDocType") AndAlso Not dr.IsNull(aliasPrefix & "pcci_refDocType") Then
          .m_entityType = New PettyCashClaimEntityType(CInt(dr(aliasPrefix & "pcci_refDocType")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_refdocCode") AndAlso Not dr.IsNull(aliasPrefix & "pcci_refdocCode") Then
          .m_refDocCode = dr(aliasPrefix & "pcci_refdocCode").ToString
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_refdocDate") AndAlso Not dr.IsNull(aliasPrefix & "pcci_refdocDate") Then
          .m_refDocDate = CDate(dr(aliasPrefix & "pcci_refdocDate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_paymentAmt") AndAlso Not dr.IsNull(aliasPrefix & "pcci_paymentAmt") Then
          .m_refDocAmount = CDec(dr(aliasPrefix & "pcci_paymentAmt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_amt") AndAlso Not dr.IsNull(aliasPrefix & "pcci_amt") Then
          .m_paidAmount = CDec(dr(aliasPrefix & "pcci_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_payment") AndAlso Not dr.IsNull(aliasPrefix & "pcci_payment") Then
          .m_paymentid = CInt(dr(aliasPrefix & "pcci_payment"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_paymentilinenumber") AndAlso Not dr.IsNull(aliasPrefix & "pcci_paymentilinenumber") Then
          .m_paymentLine = CInt(dr(aliasPrefix & "pcci_paymentilinenumber"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pcci_note") AndAlso Not dr.IsNull(aliasPrefix & "pcci_note") Then
          .m_note = dr(aliasPrefix & "pcci_note").ToString
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property PettyCashClaim() As PettyCashClaim
      Get
        Return m_pcc
      End Get
      Set(ByVal Value As PettyCashClaim)
        m_pcc = Value
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
    Public Property Paymentid() As Integer
      Get
        Return m_paymentid
      End Get
      Set(ByVal Value As Integer)
        m_paymentid = Value
      End Set
    End Property
    Public Property PaymentLine() As Integer
      Get
        Return m_paymentLine
      End Get
      Set(ByVal Value As Integer)
        m_paymentLine = Value
      End Set
    End Property
    Public Property RefDocCode() As String
      Get
        Return m_refDocCode
      End Get
      Set(ByVal Value As String)
        m_refDocCode = Value
      End Set
    End Property
    Public Property RefDocDate() As Date
      Get
        Return m_refDocDate
      End Get
      Set(ByVal Value As Date)
        m_refDocDate = Value
      End Set
    End Property
    Public ReadOnly Property RefDocType() As String
      Get
        Return m_entityType.Description
      End Get
    End Property
    Public Property EntityType() As PettyCashClaimEntityType
      Get
        Return m_entityType
      End Get
      Set(ByVal Value As PettyCashClaimEntityType)
        m_entityType = Value
      End Set
    End Property
    Public Property RefDocAmount() As Decimal
      Get
        Return m_refDocAmount
      End Get
      Set(ByVal Value As Decimal)
        m_refDocAmount = Value
      End Set
    End Property
    Public Property PaidAmount() As Decimal
      Get
        Return m_paidAmount
      End Get
      Set(ByVal Value As Decimal)
        m_paidAmount = Value
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
#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If

      Me.PettyCashClaim.IsInitialized = False
      row("pcci_linenumber") = Me.LineNumber
      row("pcci_payment") = Me.Paymentid
      row("pcci_paymentilinenumber") = Me.PaymentLine
      If Me.PaidAmount <> 0 Then
        row("Amount") = Configuration.FormatToString(Me.PaidAmount, DigitConfig.Price)
      Else
        row("Amount") = ""
      End If
      row("Code") = Me.RefDocCode
      If Not Me.RefDocDate.Equals(Date.MinValue) Then
        row("DocDate") = Me.RefDocDate.ToShortDateString
      Else
        row("DocDate") = ""
      End If
      If Me.RefDocAmount <> 0 Then
        row("RealAmount") = Configuration.FormatToString(Me.RefDocAmount, DigitConfig.Price)
      Else
        row("RealAmount") = ""
      End If
      If Not Me.EntityType Is Nothing Then
        row("entityType") = Me.EntityType.Value
        row("DocType") = Me.RefDocType
      End If
      row("Note") = Me.Note
      Me.PettyCashClaim.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull("pcci_payment") AndAlso IsNumeric(row("pcci_payment")) Then
          Me.Paymentid = CInt(row("pcci_payment"))
        End If
        If Not row.IsNull("pcci_paymentilinenumber") AndAlso IsNumeric(row("pcci_paymentilinenumber")) Then
          Me.PaymentLine = CInt(row("pcci_paymentilinenumber"))
        End If
        If Not row.IsNull("Amount") AndAlso IsNumeric(row("Amount")) Then
          Me.PaidAmount = CDec(row("Amount"))
        End If
        If Not row.IsNull("code") Then
          Me.RefDocCode = row("code").ToString
        End If
        If Not row.IsNull("entityType") AndAlso IsNumeric(row("entityType")) Then
          Me.EntityType = New PettyCashClaimEntityType(CInt(row("entityType")))
        End If
        If Not row.IsNull("DocDate") AndAlso Not row("DocDate").ToString.Length = 0 AndAlso Not CDate(row("DocDate")).Equals(Date.MinValue) Then
          Me.RefDocDate = CDate(row("DocDate"))
        End If
        If Not row.IsNull("RealAmount") AndAlso IsNumeric(row("RealAmount")) Then
          Me.RefDocAmount = CDec(row("RealAmount"))
        End If
        If Not row.IsNull("Note") Then
          Me.Note = row("Note").ToString
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
#End Region

  End Class
End Namespace
