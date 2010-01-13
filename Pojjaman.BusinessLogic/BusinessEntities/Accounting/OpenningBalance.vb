Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class OpenningBalanceStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "gl_status"
      End Get
    End Property
#End Region

  End Class
  Public Class OpenningBalance
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPrintableEntity, ICheckPeriod


#Region "Members"
    Private m_docDate As Date
    Private m_note As String
    Private m_status As OpenningBalanceStatus

    Private m_je As JournalEntry

    Private m_itemTable As TreeTable

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleted, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
      ReLoadItems(ds, aliasPrefix)
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
      ReLoadItems()
      'WrapperArrayList.AddItemAddedHandler(m_itemTable, AddressOf ItemAdded)
      AddHandler m_itemTable.ColumnChanging, AddressOf Treetable_ColumnChanging
      AddHandler m_itemTable.ColumnChanged, AddressOf Treetable_ColumnChanged
      AddHandler m_itemTable.RowDeleting, AddressOf ItemDelete
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_docDate = Now.Date
        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate
        .m_status = New OpenningBalanceStatus(-1)
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If Not dr.IsNull(aliasPrefix & "opb_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "opb_docDate"))
        End If

        If Not dr.IsNull(aliasPrefix & "opb_note") Then
          .m_note = CStr(dr(aliasPrefix & "opb_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "status.code_value") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "status.code_value") Then
          .m_status = New OpenningBalanceStatus(CInt(dr(aliasPrefix & Me.Prefix & "status.code_value")))
        End If
        m_je = New JournalEntry(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemTable() As TreeTable      Get        Return m_itemTable      End Get      Set(ByVal Value As TreeTable)        m_itemTable = Value      End Set    End Property
    Public Sub RefreshGross()
      Dim sumDebit As Decimal = 0
      For Each row As TreeRow In Me.ItemTable.Childs
        If Not IsDBNull(row("DebitAmount")) AndAlso IsNumeric(row("DebitAmount")) Then
          sumDebit += CDec(row("DebitAmount"))
        End If
      Next
      m_debitAmount = sumDebit

      Dim sumCredit As Decimal = 0
      For Each row As TreeRow In Me.ItemTable.Childs
        If Not IsDBNull(row("CreditAmount")) AndAlso IsNumeric(row("CreditAmount")) Then
          sumCredit += CDec(row("CreditAmount"))
        End If
      Next
      m_creditAmount = sumCredit
    End Sub
    Private m_debitAmount As Decimal = 0
    Public ReadOnly Property DebitAmount() As Decimal
      Get
        Return m_debitAmount
      End Get
    End Property
    Private m_creditAmount As Decimal = 0
    Public ReadOnly Property CreditAmount() As Decimal
      Get
        Return m_creditAmount
      End Get
    End Property
    Public ReadOnly Property Profit() As Decimal
      Get
        Return DebitAmount - CreditAmount
      End Get
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        If Me.m_je IsNot Nothing Then
          Me.m_je.DocDate = Value
        End If      End Set    End Property    Public Property Note() As String Implements IGLAble.Note      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Overrides Property Status() As CodeDescription      Get        Return m_status      End Get      Set(ByVal Value As CodeDescription)        m_status = CType(Value, OpenningBalanceStatus)      End Set    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "OpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "OpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "opb"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.OpenningBalance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.OpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.OpenningBalance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.OpenningBalance.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt = tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("OpenningBalance")
      myDatatable.Columns.Add(New DataColumn("opbi_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("opbi_acct", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("opbi_cc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("CCCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("opbi_amt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("opbi_isdebit", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("DebitAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CreditAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("opbi_note", GetType(String)))
      Return myDatatable
    End Function
    Public Shared Function GetOpeningBalance(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldOpb As OpenningBalance) As Boolean
      Dim opbNew As New OpenningBalance(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not opbNew.Originated Then
        MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
        opbNew = oldOpb
        'ElseIf cc.IsControlGroup Then
        '    MessageBox.Show(prNew.Code & "-" & cc.Name & " เป็นกลุ่มแม่")
        '    prNew = oldPR
      End If
      txtCode.Text = opbNew.Code
      txtName.Text = ""
      If oldOpb.Id <> opbNew.Id Then
        oldOpb = opbNew
        Return True
      End If
      Return False
    End Function
#End Region

#Region "Methods"
    Private Sub ResetID(ByVal oldid As Integer, ByVal oldJeId As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldJeId
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Me.MaxRowIndex < 0 Then '.ItemTable.Childs.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If
        'If Me.DebitAmount <> Me.CreditAmount Then
        '    Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.UnBalanceDebitCredit}"))
        'End If
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' สร้าง ArrayList จาก Item ของ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)

        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@opb_id", Me.Id))
        End If

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
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
        'paymentcode is null
        Me.m_je.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_je.AutoGen = False

        paramArrayList.Add(New SqlParameter("@opb_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@opb_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))

        paramArrayList.Add(New SqlParameter("@opb_debitamt", Me.DebitAmount))
        paramArrayList.Add(New SqlParameter("@opb_creditamt", Me.CreditAmount))
        paramArrayList.Add(New SqlParameter("@opb_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@opb_status", Me.Status.Value))

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
        Dim oldjeid As Integer = Me.m_je.Id
        Try
          Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
          If IsNumeric(returnVal.Value) Then
            Select Case CInt(returnVal.Value)
              Case -1, -2, -5
                trans.Rollback()
                Me.ResetID(oldid, oldjeid)
                Return New SaveErrorException(returnVal.Value.ToString)
              Case Else
            End Select
          ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
            trans.Rollback()
            Me.ResetID(oldid, oldjeid)
            Return New SaveErrorException(returnVal.Value.ToString)
          End If

          SaveDetail(Me.Id, conn, trans)



          If Me.m_je.Status.Value = -1 Then
            m_je.Status.Value = 3
          End If
          Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
          If Not IsNumeric(saveJeError.Message) Then
            trans.Rollback()
            Me.ResetID(oldid, oldjeid)
            Return saveJeError
          Else
            Select Case CInt(saveJeError.Message)
              Case -1, -5
                trans.Rollback()
                Me.ResetID(oldid, oldjeid)
                Return saveJeError
              Case -2
                'Post ไปแล้ว
                Me.ResetID(oldid, oldjeid)
                Return saveJeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================
          Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
          If Not IsNumeric(saveAutoCodeError.Message) Then
            trans.Rollback()
            ResetID(oldid, oldjeid)
            Return saveAutoCodeError
          Else
            Select Case CInt(saveAutoCodeError.Message)
              Case -1, -2, -5
                trans.Rollback()
                ResetID(oldid, oldjeid)
                Return saveAutoCodeError
              Case Else
            End Select
          End If
          '==============================AUTOGEN==========================================

          trans.Commit()
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          trans.Rollback()
          Me.ResetID(oldid, oldjeid)
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          trans.Rollback()
          Me.ResetID(oldid, oldjeid)
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As Integer


      Dim da As New SqlDataAdapter("Select * from openningbalanceitem where opbi_opb=" & Me.Id, conn)
      Dim cmdBuilder As New SqlCommandBuilder(da)

      Dim ds As New DataSet

      da.SelectCommand.Transaction = trans

      'ต้องอยู่ต่อจาก da.SelectCommand.Transaction = trans
      cmdBuilder.GetDeleteCommand.Transaction = trans
      cmdBuilder.GetInsertCommand.Transaction = trans
      cmdBuilder.GetUpdateCommand.Transaction = trans

      da.Fill(ds, "openningbalanceitem")

      Dim dbCount As Integer = ds.Tables("openningbalanceitem").Rows.Count
      Dim itemCount As Integer = Me.ItemTable.Childs.Count
      Dim i As Integer = 0
      With ds.Tables("openningbalanceitem")
        For Each row As DataRow In .Rows
          row.Delete()
        Next
        For n As Integer = 0 To Me.MaxRowIndex
          Dim item As TreeRow = Me.m_itemTable.Childs(n)
          If ValidateRow(item) Then
            i += 1
            Dim dr As DataRow = .NewRow
            dr("opbi_opb") = Me.Id
            dr("opbi_linenumber") = i 'item("opbi_linenumber")
            dr("opbi_acct") = item("opbi_acct")
            dr("opbi_cc") = item("opbi_cc")
            dr("opbi_isdebit") = item("opbi_isdebit")
            dr("opbi_amt") = item("opbi_amt")
            dr("opbi_note") = item("opbi_note")
            .Rows.Add(dr)
          End If
        Next
      End With
      Dim dt As DataTable = ds.Tables("openningbalanceitem")
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
    Private Sub LoadItems()
      If Not Me.Originated Then
        Return
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetOpenningBalanceitems" _
      , New SqlParameter("@opb_id", Me.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New OpenningBalanceItem(row, "")
        item.OpenningBalance = Me
        Me.Add(item)
      Next
    End Sub
    Private Sub LoadItems(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      For Each dr As DataRow In ds.Tables(1).Rows
        Dim item As New OpenningBalanceItem(dr, aliasPrefix)
        item.OpenningBalance = Me
        Me.Add(item)
      Next
    End Sub
    Public Sub AddBlankRow(ByVal count As Integer)
      For i As Integer = 0 To count - 1
        Dim myItem As New OpenningBalanceItem
        myItem.Account = New Account
        myItem.CostCenter = New CostCenter
        Me.ItemTable.AcceptChanges()
        Me.Add(myItem)
      Next
    End Sub
    Public Function Add(ByVal item As OpenningBalanceItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.Add
      item.LineNumber = Me.ItemTable.Childs.Count
      item.OpenningBalance = Me
      item.CopyToDataRow(myRow)
      Return myRow
    End Function
    Public Function Insert(ByVal index As Integer, ByVal item As OpenningBalanceItem) As TreeRow
      Dim myRow As TreeRow = Me.ItemTable.Childs.InsertAt(index)
      item.LineNumber = Me.ItemTable.Childs.IndexOf(myRow) + 1
      item.OpenningBalance = Me
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
        Me.ItemTable.Childs(i)("opbi_linenumber") = i + 1
      Next
    End Sub
    Public Function MaxRowIndex() As Integer
      If Me.m_itemTable Is Nothing Then
        Return -1
      End If
      'ให้ index ของแถวสุดท้ายที่มีข้อมูล
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
          Case "code"
            SetAccountValue(e)
          Case "cccode"
            SetCostCenterValue(e)
          Case "debitamount"
            SetDebit(e)
          Case "creditamount"
            SetCrebit(e)
        End Select
        ValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim proposedAccount As Object = e.Row("Code")
      Dim proposedCC As Object = e.Row("CCCode")
      Dim proposedCredit As Object = e.Row("creditamount")
      Dim proposedDebit As Object = e.Row("debitamount")

      Select Case e.Column.ColumnName.ToLower
        Case "code"
          proposedAccount = e.ProposedValue
        Case "cccode"
          proposedCC = e.ProposedValue
        Case "debitamount"
          proposedDebit = e.ProposedValue
        Case "creditamount"
          proposedCredit = e.ProposedValue
        Case Else
          Return
      End Select

      If IsDBNull(proposedAccount) Then
        e.Row.SetColumnError("Code", Me.StringParserService.Parse("${res:Global.Error.AccountMissing}"))
      Else
        e.Row.SetColumnError("Code", "")
      End If

      If IsDBNull(proposedCC) Then
        e.Row.SetColumnError("CCCode", Me.StringParserService.Parse("${res:Global.Error.CostCenterMissing}"))
      Else
        e.Row.SetColumnError("CCCode", "")
      End If

      If IsDBNull(proposedCredit) And IsDBNull(proposedDebit) Then
        e.Row.SetColumnError("creditamount", Me.StringParserService.Parse("${res:Global.Error.CreditMissing}"))
        e.Row.SetColumnError("debitamount", Me.StringParserService.Parse("${res:Global.Error.DebitMissing}"))
      Else
        e.Row.SetColumnError("creditamount", "")
        e.Row.SetColumnError("debitamount", "")
      End If
    End Sub
    Public Function ValidateRow(ByVal row As TreeRow) As Boolean
      Dim proposedAccount As Object = row("opbi_acct")
      Dim proposedCC As Object = row("opbi_cc")
      Dim proposedCode As Object = row("Code")
      Dim proposedAmount As Object = row("opbi_amt")

      If (IsDBNull(proposedAccount) OrElse CInt(proposedAccount) = 0) _
          And (IsDBNull(proposedCC) OrElse CInt(proposedCC) = 0) _
          And (IsDBNull(proposedCode) OrElse CStr(proposedCode) = "") _
          And (IsDBNull(proposedAmount) OrElse CDec(proposedAmount) = 0) _
          Then
        Return False
      End If
      Return True
    End Function
    Public Sub SetDebit(ByVal e As DataColumnChangeEventArgs)
      If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(TextParser.Evaluate(e.ProposedValue.ToString), DigitConfig.Price)
      e.Row("opbi_amt") = e.ProposedValue
      e.Row("opbi_isdebit") = True
      e.Row("creditamount") = ""
    End Sub
    Public Sub SetCrebit(ByVal e As DataColumnChangeEventArgs)
      If IsDBNull(e.ProposedValue) OrElse CStr(e.ProposedValue).Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(TextParser.Evaluate(e.ProposedValue.ToString), DigitConfig.Price)
      e.Row("opbi_amt") = e.ProposedValue
      e.Row("opbi_isdebit") = False
      e.Row("debitamount") = ""
    End Sub
    Public Sub SetAccountValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      Dim entity As New Account(e.ProposedValue.ToString)
      If entity.Originated Then
        Dim myUnit As Unit
        e.Row("opbi_acct") = entity.Id
        e.ProposedValue = entity.Code
        e.Row("Name") = entity.Name
      Else
        e.Row("opbi_acct") = DBNull.Value
        e.ProposedValue = DBNull.Value
        e.Row("Name") = DBNull.Value
      End If
    End Sub
    Public Sub SetCostCenterValue(ByVal e As System.Data.DataColumnChangeEventArgs)
      Dim entity As New CostCenter(e.ProposedValue.ToString)
      If entity.Originated Then
        Dim myUnit As Unit
        e.Row("opbi_cc") = entity.Id
        e.ProposedValue = entity.Code
        e.Row("CCName") = entity.Name
      Else
        e.Row("opbi_cc") = DBNull.Value
        e.ProposedValue = DBNull.Value
        e.Row("CCName") = DBNull.Value
      End If
    End Sub
    Private Sub ItemAdded(ByVal sender As Object, ByVal e As ITemAddedEventArgs)
      Try
        If Not Me.IsInitialized Then
          Return
        End If
        Dim pe As New PropertyChangedEventArgs("ItemChanged", "", "")
        Me.OnPropertyChanged(Me, pe)
        e.Row.SetColumnError("Code", "")
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
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

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_name", Me.ClassName), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        Me.m_je = Value
      End Set
    End Property
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      'โหดมาก!!! มีแยก Cost Center ด้วย
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem
      Dim dt As DataTable = OpenningBalance.GetSchemaTable
      For i As Integer = 0 To Me.MaxRowIndex
        dt.ImportRow(Me.ItemTable.Childs(i))
      Next
      Dim dsh As New DataSetHelper
      Dim ccDt As DataTable = dsh.SelectDistinct("CC", dt, "opbi_cc")
      For Each row As DataRow In ccDt.Rows
        Dim selectString As String = ""
        If row.IsNull(0) Then
          selectString = "isnull(opbi_cc,'')=''"
        Else
          selectString = "opbi_cc=" & row(0).ToString
        End If
        Dim rows As DataRow() = Me.ItemTable.Select(selectString, "opbi_linenumber")
        Dim sumProfit As Decimal = 0
        Dim thisCC As New CostCenter(CInt(row(0)))
        For i As Integer = 0 To rows.Length - 1
          Dim item As New OpenningBalanceItem
          item.CopyFromDataRow(rows(i))
          Dim profitDebitMatch As Boolean = False ' J7.1
          Dim opbCreditMatch As Boolean = False ' J7.2
          Dim opbDebitMatch As Boolean = False 'J7.3
          Dim profitCreditMatch As Boolean = False ' J7.4
          For Each addedJi As JournalEntryItem In jiColl
            If Not addedJi.CostCenter Is Nothing _
            AndAlso addedJi.CostCenter.Id = item.CostCenter.Id Then
              If item.IsDebit Then
                If Not addedJi.Account Is Nothing _
                    AndAlso addedJi.Account.Id = item.Account.Id Then
                  If addedJi.Mapping = "J7.3" Then
                    opbDebitMatch = True
                    addedJi.Amount += item.Amount
                    sumProfit += item.Amount
                  End If
                End If
              Else
                If Not addedJi.Account Is Nothing _
                    AndAlso addedJi.Account.Id = item.Account.Id Then
                  If addedJi.Mapping = "J7.2" Then
                    opbCreditMatch = True
                    addedJi.Amount += item.Amount
                    sumProfit -= item.Amount
                  End If
                End If
              End If
            End If
          Next
          If item.IsDebit Then
            If Not opbDebitMatch Then
              ji = New JournalEntryItem
              ji.Account = item.Account
              ji.Mapping = "J7.3"
              ji.Amount = item.Amount
              ji.CostCenter = item.CostCenter
              jiColl.Add(ji)
              sumProfit += item.Amount
            End If
          Else
            If Not opbCreditMatch Then
              ji = New JournalEntryItem
              ji.Account = item.Account
              ji.Mapping = "J7.2"
              ji.Amount = item.Amount
              ji.CostCenter = item.CostCenter
              jiColl.Add(ji)
              sumProfit -= item.Amount
            End If
          End If
        Next
        If sumProfit < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "J7.1"
          ji.Amount = -sumProfit
          ji.CostCenter = thisCC
          jiColl.Add(ji)
        ElseIf sumProfit > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "J7.4"
          ji.Amount = sumProfit
          ji.CostCenter = thisCC
          jiColl.Add(ji)
        End If
      Next
      Return jiColl
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\Openningbalance.dfm"
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

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.EveryPage
      dpiColl.Add(dpi)

      'SumDebit
      dpi = New DocPrintingItem
      dpi.Mapping = "SumDebit"
      dpi.Value = Configuration.FormatToString(Me.DebitAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCredit
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCredit"
      dpi.Value = Configuration.FormatToString(Me.CreditAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'Profit
      dpi = New DocPrintingItem
      dpi.Mapping = "Profit"
      dpi.Value = Configuration.FormatToString(Me.Profit, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

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

      Dim n As Integer = 0
      For i As Integer = 0 To Me.MaxRowIndex
        Dim itemRow As TreeRow = CType(Me.m_itemTable.Rows(i), TreeRow)
        If ValidateRow(itemRow) Then
          Dim item As New OpenningBalanceItem
          item.CopyFromDataRow(itemRow)
          'Item.LineNumber
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          dpi.Value = n + 1
          dpi.DataType = "System.Int32"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          Dim space As String = ""
          If Not item.IsDebit Then
            space = "   "
          End If

          'Item.AccountCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.AccountCode"
          dpi.Value = space & item.Account.Code
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Account
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Account"
          dpi.Value = space & item.Account.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          If item.IsDebit Then
            'Item.Debit
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Debit"
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          Else
            ' Item.Credit
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Credit"
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          End If

          'Item.CostCenterInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CostCenterInfo"
          dpi.Value = item.CostCenter.Code & ":" & item.CostCenter.Name
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.CostcenterCode
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

          n += 1
        End If
      Next
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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteOpenningBalance}", format) Then
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteOpenningBalance", New SqlParameter() {New SqlParameter("@opb_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.OpenningBalanceIsReferencedCannotBeDeleted}")
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

  End Class

  Public Class OpenningBalanceItem

#Region "Members"
    Private m_openningBalance As OpenningBalance
    Private m_lineNumber As Integer
    Private m_acct As Account
    Private m_cc As CostCenter
    Private m_amount As Decimal
    Private m_isDebit As Boolean
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
        If dr.Table.Columns.Contains(aliasPrefix & "opbi_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "opbi_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "opbi_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "opbi_amt") AndAlso Not dr.IsNull(aliasPrefix & "opbi_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "opbi_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "opbi_isdebit") AndAlso Not dr.IsNull(aliasPrefix & "opbi_isdebit") Then
          .m_isDebit = CBool(dr(aliasPrefix & "opbi_isdebit"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "opbi_note") AndAlso Not dr.IsNull(aliasPrefix & "opbi_note") Then
          .m_note = CStr(dr(aliasPrefix & "opbi_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
          If Not dr.IsNull("acct_id") Then
            .m_acct = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "opbi_acct") AndAlso Not dr.IsNull(aliasPrefix & "opbi_acct") Then
            .m_acct = New Account(CInt(dr(aliasPrefix & "opbi_acct")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") AndAlso Not dr.IsNull(aliasPrefix & "cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .m_cc = New CostCenter(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "opbi_cc") AndAlso Not dr.IsNull(aliasPrefix & "opbi_cc") Then
            .m_cc = New CostCenter(CInt(dr(aliasPrefix & "opbi_cc")))
          End If
        End If

      End With

    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property OpenningBalance() As OpenningBalance      Get        Return m_openningBalance      End Get      Set(ByVal Value As OpenningBalance)        m_openningBalance = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Account() As Account      Get        Return m_acct      End Get      Set(ByVal Value As Account)        m_acct = Value      End Set    End Property    Public Property CostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value      End Set    End Property    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property IsDebit() As Boolean      Get        Return m_isDebit      End Get      Set(ByVal Value As Boolean)        m_isDebit = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property#End Region

#Region "Methods"
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.OpenningBalance.IsInitialized = False
      row("opbi_linenumber") = Me.LineNumber
      row("opbi_isdebit") = Me.IsDebit
      row("opbi_amt") = Me.Amount
      row("DebitAmount") = ""
      row("CreditAmount") = ""
      If Me.IsDebit Then
        If Me.Amount <> 0 Then
          row("DebitAmount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("DebitAmount") = ""
        End If
      Else
        If Me.Amount <> 0 Then
          row("CreditAmount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("CreditAmount") = ""
        End If

      End If
      If Not Me.Account Is Nothing Then
        row("Code") = Me.Account.Code
        row("Name") = Me.Account.Name
        row("opbi_acct") = Me.Account.Id
      End If
      If Not Me.CostCenter Is Nothing Then
        row("CCCode") = Me.CostCenter.Code
        row("CCName") = Me.CostCenter.Name
        row("opbi_cc") = Me.CostCenter.Id
      End If
      row("opbi_note") = Me.Note

      Me.OpenningBalance.IsInitialized = True
    End Sub
    Public Sub CopyFromDataRow(ByVal row As DataRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("opbi_linenumber")) Then
          Me.LineNumber = CInt(row("opbi_linenumber"))
        End If
        If Not row.IsNull(("opbi_isdebit")) Then
          Me.IsDebit = CBool(row("opbi_isdebit"))
        End If
        If Not row.IsNull(("opbi_amt")) Then
          Me.Amount = CDec(row("opbi_amt"))
        End If
        If Not row.IsNull(("opbi_acct")) Then
          Me.Account = New Account(CInt(row("opbi_acct")))
        Else
          Me.Account = New Account
        End If
        If Not row.IsNull(("opbi_cc")) Then
          Me.CostCenter = New CostCenter(CInt(row("opbi_cc")))
        Else
          Me.CostCenter = New CostCenter
        End If
        If Not row.IsNull(("opbi_note")) Then
          Me.Note = CStr(row("opbi_note"))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try
    End Sub
    Public Sub CopyFromDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Try
        If Not row.IsNull(("opbi_linenumber")) Then
          Me.LineNumber = CInt(row("opbi_linenumber"))
        End If
        If Not row.IsNull(("opbi_isdebit")) Then
          Me.IsDebit = CBool(row("opbi_isdebit"))
        End If
        If Not row.IsNull(("opbi_amt")) Then
          Me.Amount = CDec(row("opbi_amt"))
        End If
        If Not row.IsNull(("opbi_acct")) Then
          Me.Account = New Account(CInt(row("opbi_acct")))
        Else
          Me.Account = New Account
        End If
        If Not row.IsNull(("opbi_cc")) Then
          Me.CostCenter = New CostCenter(CInt(row("opbi_cc")))
        Else
          Me.CostCenter = New CostCenter
        End If
        If Not row.IsNull(("opbi_note")) Then
          Me.Note = CStr(row("opbi_note"))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub
#End Region

  End Class

End Namespace
