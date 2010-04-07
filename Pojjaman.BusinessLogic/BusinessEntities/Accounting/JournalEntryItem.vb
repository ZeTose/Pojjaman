Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Collections
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class JournalEntryItem

#Region "Members"
    Private m_journalEntry As JournalEntry
    Private m_lineNumber As Integer
    Private m_acct As Account
    Private m_cc As CostCenter
    Private m_amount As Decimal
    Private m_isDebit As Boolean
    Private m_note As String
    Private m_entityitem As Integer
    Private m_entityitemType As Integer

    Private m_mapping As String
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
        If dr.Table.Columns.Contains(aliasPrefix & "gli_lineNumber") AndAlso Not dr.IsNull(aliasPrefix & "gli_lineNumber") Then
          .m_lineNumber = CInt(dr(aliasPrefix & "gli_lineNumber"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "gli_amt") AndAlso Not dr.IsNull(aliasPrefix & "gli_amt") Then
          .m_amount = CDec(dr(aliasPrefix & "gli_amt"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "gli_isdebit") AndAlso Not dr.IsNull(aliasPrefix & "gli_isdebit") Then
          .m_isDebit = CBool(dr(aliasPrefix & "gli_isdebit"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "gli_note") AndAlso Not dr.IsNull(aliasPrefix & "gli_note") Then
          .m_note = CStr(dr(aliasPrefix & "gli_note"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "acct_id") AndAlso Not dr.IsNull(aliasPrefix & "acct_id") Then
          If Not dr.IsNull("acct_id") Then
            .m_acct = New Account(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "gli_acct") AndAlso Not dr.IsNull(aliasPrefix & "gli_acct") Then
            .m_acct = New Account(CInt(dr(aliasPrefix & "gli_acct")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "cc_id") AndAlso Not dr.IsNull(aliasPrefix & "cc_id") Then
          If Not dr.IsNull("cc_id") Then
            .m_cc = New CostCenter(dr, "")
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "gli_cc") AndAlso Not dr.IsNull(aliasPrefix & "gli_cc") Then
            .m_cc = New CostCenter(CInt(dr(aliasPrefix & "gli_cc")))
          End If
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "gli_entity") AndAlso Not dr.IsNull(aliasPrefix & "gli_entity") Then
          .m_entityitem = CInt(dr(aliasPrefix & "gli_entity"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "gli_entitytype") AndAlso Not dr.IsNull(aliasPrefix & "gli_entitytype") Then
          .m_entityitemType = CInt(dr(aliasPrefix & "gli_entitytype"))
        End If
      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property JournalEntry() As JournalEntry      Get        Return m_journalEntry      End Get      Set(ByVal Value As JournalEntry)        m_journalEntry = Value      End Set    End Property    Public Property LineNumber() As Integer      Get        Return m_lineNumber      End Get      Set(ByVal Value As Integer)        m_lineNumber = Value      End Set    End Property    Public Property Account() As Account      Get        Return m_acct      End Get      Set(ByVal Value As Account)        m_acct = Value      End Set    End Property    Public Sub SetItemCode(ByVal theCode As String)
      Dim entity As New Account(theCode)
      If entity.Originated Then
        Me.Account = entity
      Else
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowMessageFormatted("${res:Global.Error.NoAccount}", New String() {theCode})
      End If
    End Sub    Public Property CostCenter() As CostCenter      Get        Return m_cc      End Get      Set(ByVal Value As CostCenter)        m_cc = Value      End Set    End Property    Public Sub SetItemCCCode(ByVal theCode As String)
      Dim entity As New CostCenter(theCode)
      If entity.Originated Then
        Me.CostCenter = entity
      Else
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        msgServ.ShowMessageFormatted("${res:Global.Error.NoCostCenter}", New String() {theCode})
      End If
    End Sub    Public Property Amount() As Decimal      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property IsDebit() As Boolean      Get        Return m_isDebit      End Get      Set(ByVal Value As Boolean)        m_isDebit = Value      End Set    End Property    Public Property Note() As String      Get        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property    Public Property Mapping() As String      Get        Return m_mapping      End Get      Set(ByVal Value As String)        m_mapping = Value      End Set    End Property    Public Property EntityItem() As Integer      Get        Return m_entityitem      End Get      Set(ByVal Value As Integer)        m_entityitem = Value      End Set    End Property    Public Property EntityItemType() As Integer      Get        Return m_entityitemType      End Get      Set(ByVal Value As Integer)        m_entityitemType = Value      End Set    End Property#End Region

#Region "Methods"
    Public Sub ItemValidateRow(ByVal row As DataRow)
      Dim proposedAccount As Object = row("Code")
      Dim proposedCC As Object = row("CCCode")
      Dim proposedAmount As Object = row("gli_amt")

      Dim isBlankRow As Boolean = False
      If (IsDBNull(proposedAccount) OrElse proposedAccount.ToString.Length = 0) _
          And (IsDBNull(proposedCC) OrElse proposedCC.ToString.Length = 0) _
          And (IsDBNull(proposedAccount) OrElse proposedAccount.ToString.Length = 0) _
          And (IsDBNull(proposedAmount) OrElse Not IsNumeric(proposedAmount) OrElse CDec(proposedAmount) = 0) _
          Then
        isBlankRow = True
      End If

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not isBlankRow Then
        If IsDBNull(proposedAccount) OrElse proposedAccount.ToString.Length = 0 Then
          row.SetColumnError("Code", myStringParserService.Parse("${res:Global.Error.AccountMissing}"))
        Else
          row.SetColumnError("Code", "")
        End If

        If IsDBNull(proposedCC) OrElse proposedCC.ToString.Length = 0 Then
          row.SetColumnError("CCCode", myStringParserService.Parse("${res:Global.Error.CostCenterMissing}"))
        Else
          row.SetColumnError("CCCode", "")
        End If

        If IsDBNull(proposedAmount) OrElse Not IsNumeric(proposedAmount) OrElse CDec(proposedAmount) = 0 Then
          row.SetColumnError("creditamount", myStringParserService.Parse("${res:Global.Error.CreditMissing}"))
          row.SetColumnError("debitamount", myStringParserService.Parse("${res:Global.Error.DebitMissing}"))
        Else
          row.SetColumnError("creditamount", "")
          row.SetColumnError("debitamount", "")
        End If
      Else
        row.SetColumnError("Code", "")
        row.SetColumnError("CCCode", "")
        row.SetColumnError("creditamount", "")
        row.SetColumnError("debitamount", "")
      End If
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If
      Me.JournalEntry.IsInitialized = False
      row("gli_linenumber") = Me.LineNumber
      row("gli_isdebit") = Me.IsDebit
      row("gli_amt") = Me.Amount
      row("DebitAmount") = ""
      row("CreditAmount") = ""
      If Me.Amount <> 0 Then
        If Me.IsDebit Then
          row("DebitAmount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        Else
          row("CreditAmount") = Configuration.FormatToString(Me.Amount, DigitConfig.Price)
        End If
      End If
      Dim displayName As String = ""
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Not Me.Account Is Nothing Then
        row("Code") = Me.Account.Code
        If Me.IsDebit Then
          '"DR. "
          displayName = myStringParserService.Parse("${res:Global.DebitPrefix}") & Me.Account.Name
        ElseIf Me.Amount <> 0 Then
          '"      CR. "
          displayName = myStringParserService.Parse("${res:Global.CreditPrefix}") & Me.Account.Name
        Else
          displayName = Me.Account.Name
        End If
        row("Name") = displayName
        row("gli_acct") = Me.Account.Id
      End If
      If Not Me.CostCenter Is Nothing Then
        row("CCCode") = Me.CostCenter.Code
        row("CCName") = Me.CostCenter.Name
        row("gli_cc") = Me.CostCenter.Id
      End If
      row("gli_note") = Me.Note

      Dim btnText As String = ""
      If Not Me.JournalEntry.Editable AndAlso Not Me.JournalEntry.ManualFormat Then
        btnText = "invisible"
      End If
      row("CCButton") = btnText
      row("Button") = btnText
      Me.JournalEntry.IsInitialized = True
    End Sub
#End Region

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class JournalEntryItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_owner As JournalEntry
    Private m_manager As TreeManager
#End Region

#Region "Constructors"
    Public Sub New()
    End Sub
    Public Sub New(ByVal owner As JournalEntry)
      Me.m_owner = owner
      If Not Me.m_owner.Originated Then
        Return
      End If


      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString


      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetGLItems" _
      , New SqlParameter("@gl_id", Me.m_owner.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New JournalEntryItem(row, "")
        item.JournalEntry = m_owner
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Public Property Manager() As TreeManager      Get        Return m_manager      End Get      Set(ByVal Value As TreeManager)        m_manager = Value      End Set    End Property    Default Public Property Item(ByVal index As Integer) As JournalEntryItem
      Get
        Return CType(MyBase.List.Item(index), JournalEntryItem)
      End Get
      Set(ByVal value As JournalEntryItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public ReadOnly Property debitCount As Integer
      Get
        Dim i As Integer = 0
        For Each ji As JournalEntryItem In Me
          If ji.IsDebit Then
            i += 1
          End If
        Next
        Return i
      End Get
    End Property
#End Region

#Region "Shared"

#End Region

#Region "Class Methods"
    Public Sub MoveItemUp(ByVal item As JournalEntryItem)
      Dim currIndex As Integer = Me.IndexOf(item)
      If currIndex <= 0 Then
        Return
      End If
      Me.Remove(item)
      Me.Insert(currIndex - 1, item)
    End Sub
    Public Sub MoveItemDown(ByVal item As JournalEntryItem)
      Dim currIndex As Integer = Me.IndexOf(item)
      If currIndex >= Me.Count - 1 Then
        Return
      End If
      Me.Remove(item)
      If currIndex = Me.Count - 1 Then
        Me.Add(item)
      Else
        Me.Insert(currIndex + 1, item)
      End If
    End Sub
    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each vi As JournalEntryItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        vi.CopyToDataRow(newRow)
        vi.ItemValidateRow(newRow)
        newRow.Tag = vi
      Next
    End Sub
    Public Function GetExactMappingItems(ByVal mapping As String) As JournalEntryItemCollection
      Dim ret As New JournalEntryItemCollection
      For Each item As JournalEntryItem In Me
        If item.Mapping.ToLower = mapping.ToLower Then
          ret.Add(item)
        End If
      Next
      Return ret
    End Function
    ''' <summary>
    ''' หาผังบัญชีจาก GlFormat
    ''' </summary>
    ''' <param name="glfi"></param>
    ''' <param name="ji"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetAccount(ByVal glfi As GLFormatItem, ByVal ji As JournalEntryItem) As Account
      Dim acct As Account
      Select Case glfi.FieldType.Value
        Case 1                'GeneralAccount
          If glfi.Account Is Nothing OrElse Not glfi.Account.Originated Then
            acct = CType(glfi.Field, GeneralAccount).Account
            acct = New Account(acct.Code)
          Else
            acct = glfi.Account
          End If
        Case 2, 3               'mix
          If TypeOf glfi.Field Is GeneralAccount AndAlso (ji.Account Is Nothing OrElse Not ji.Account.Originated) Then
            acct = CType(glfi.Field, GeneralAccount).Account
            acct = New Account(acct.Code)
          Else
            acct = ji.Account
          End If
        Case Else
          MessageBox.Show("GL Error")
      End Select
      Return acct
    End Function
    Public Function GetMappingItems(ByVal glfi As GLFormatItem) As JournalEntryItemCollection
      Dim ret As New JournalEntryItemCollection
      If glfi.Mapping.ToLower.EndsWith("d") OrElse glfi.Mapping.ToLower.EndsWith("w") Then
        For Each item As JournalEntryItem In Me
          If item.Mapping.ToLower = glfi.Mapping.ToLower Then
            item.Account = GetAccount(glfi, item)
            Dim cc As CostCenter = glfi.CostCenter
            If Not cc Is Nothing AndAlso cc.Originated Then
              item.CostCenter = cc
            ElseIf item.CostCenter Is Nothing OrElse Not item.CostCenter.Originated Then
              item.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            item.IsDebit = glfi.IsDebit
            If item.Amount <> 0 Then
              If item.Amount > 0 Then
                item.IsDebit = glfi.IsDebit
              Else
                item.Amount = -item.Amount
                item.IsDebit = Not glfi.IsDebit
              End If
              If item.Note Is Nothing OrElse item.Note = "" Then
                item.Note = glfi.Field.Name
              End If
              ret.Add(item)
            End If
          End If
        Next
        Return ret
      End If
      Dim reg As New Regex("[A-Za-z]+[0-9]*(\.?[0-9]+)+")
      Dim dt As New TreeTable
      dt.Columns.Add(New DataColumn("Mapping", GetType(String)))
      dt.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      dt.Columns.Add(New DataColumn("Account", GetType(String)))
      dt.Columns.Add(New DataColumn("Value", GetType(Decimal)))
      dt.Columns.Add(New DataColumn("Note", GetType(String)))

      Dim mapHash As New Hashtable
      Dim mapTable As New TreeTable
      mapTable.Columns.Add(New DataColumn("Key", GetType(String)))

      Dim ccHash As New Hashtable
      Dim ccTable As New TreeTable
      ccTable.Columns.Add(New DataColumn("Key", GetType(Integer)))

      Dim acctHash As New Hashtable
      Dim acctTable As New TreeTable
      acctTable.Columns.Add(New DataColumn("Key", GetType(Integer)))

      For Each m As Match In reg.Matches(glfi.Mapping)
        If Not mapHash.Contains(m.Value.ToLower) Then
          mapHash(m.Value.ToLower) = m
          Dim mapRow As TreeRow = mapTable.Childs.Add
          mapRow("Key") = m.Value.ToLower
          mapRow.Tag = m
          Dim tmpColl As JournalEntryItemCollection = GetExactMappingItems(m.Value)
          Dim cc As CostCenter = glfi.CostCenter
          For Each ji As JournalEntryItem In tmpColl

            '========================= Set Cost Center ================================
            If Not cc Is Nothing AndAlso cc.Originated Then
              ji.CostCenter = cc
            ElseIf ji.CostCenter Is Nothing OrElse Not ji.CostCenter.Originated Then
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            '========================= Set Cost Center ================================

            If Not ccHash.Contains(ji.CostCenter.Id) Then
              ccHash(ji.CostCenter.Id) = ji.CostCenter
              Dim ccRow As TreeRow = ccTable.Childs.Add
              ccRow("Key") = ji.CostCenter.Id
              ccRow.Tag = ji.CostCenter
            End If

            '==========Add ลง dt ==========================
            Dim theRow As TreeRow = dt.Childs.Add
            theRow("Mapping") = m.Value
            theRow("CostCenter") = ji.CostCenter.Id
            Dim acct As Account = GetAccount(glfi, ji)
            If Not acctHash.Contains(acct.Id) Then
              acctHash(acct.Id) = acct
              Dim accRow As TreeRow = acctTable.Childs.Add
              accRow("Key") = acct.Id
              accRow.Tag = acct
            End If
            ji.Account = acct
            theRow("Account") = acct.Id
            theRow("Value") = ji.Amount
            theRow("Note") = ji.Note
            theRow.Tag = ji
            '==========Add ลง dt ==========================

          Next
        End If
      Next
      For Each ccItem As TreeRow In ccTable.Childs 'As DictionaryEntry In ccHash
        Dim ccId As Integer = CInt(ccItem("Key")) '(ccItem.Key)
        For Each acctItem As TreeRow In acctTable.Childs 'DictionaryEntry In acctHash
          Dim acctId As Integer = CInt(acctItem("Key")) '(acctItem.Key)
          Dim rows() As DataRow = dt.Select("CostCenter = '" & ccId.ToString & "' and Account='" & acctId.ToString & "'")
          Dim mapValHash As New Hashtable
          Dim itemnote As String = ""
          For Each row As DataRow In rows
            Dim map As String = row("Mapping").ToString
            Dim value As Decimal = CDec(row("Value"))
            itemnote = row("Note").ToString
            If mapValHash.Contains(map.ToLower) Then
              mapValHash(map.ToLower) = CDec(mapValHash(map.ToLower)) + value
            Else
              mapValHash(map.ToLower) = value
            End If
          Next
          Dim mapping As String = glfi.Mapping.ToLower
          For Each m As Match In reg.Matches(glfi.Mapping.ToLower)
            If mapValHash.Contains(m.Value.ToLower) Then
              mapping = mapping.Replace(m.Value.ToLower, mapValHash(m.Value.ToLower).ToString)
            Else
              mapping = mapping.Replace(m.Value.ToLower, "0")
            End If
          Next
          Dim amt As Decimal = CDec(TextHelper.TextParser.Evaluate(mapping))
          Dim ji As New JournalEntryItem
          ji.Account = CType(acctItem.Tag, Account) '(acctItem.Value, Account)
          ji.Amount = Configuration.Format(amt, DigitConfig.Price)
          ji.Note = itemnote
          Dim cc As CostCenter = CType(ccItem.Tag, CostCenter) '(ccItem.Value, CostCenter)
          If Not cc Is Nothing AndAlso cc.Originated Then
            ji.CostCenter = cc
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          If ji.Amount <> 0 Then
            If ji.Amount > 0 Then
              ji.IsDebit = glfi.IsDebit
            Else
              ji.Amount = -ji.Amount
              ji.IsDebit = Not glfi.IsDebit
            End If

            If ji.Note Is Nothing OrElse ji.Note = "" Then
              ji.Note = glfi.Field.Name
            ElseIf ji.Note.Contains("{glfi.Field.Name}") Then
              ji.Note = ji.Note.Replace("{glfi.Field.Name}", glfi.Field.Name)
            End If

            ret.Add(ji)
          End If
        Next
      Next
      Return ret
    End Function
    'Public Function CreateTableStyle() As DataGridTableStyle
    '    Dim dst As New DataGridTableStyle
    '    dst.MappingName = "JournalEntryItems"

    '    Dim csSelected As New DataGridCheckBoxColumn
    '    csSelected.MappingName = "Selected"
    '    csSelected.HeaderText = ""

    '    Dim csDescription As New PlusMinusColumn
    '    csDescription.MappingName = "Entity"
    '    csDescription.HeaderText = "Entity"
    '    csDescription.NullText = ""
    '    csDescription.Width = 180

    '    Dim csQty As New HeaderAndDataAlignColumn
    '    csQty.MappingName = "Qty"
    '    csQty.HeaderText = "Qty"
    '    csQty.NullText = ""

    '    Dim csDate As New HeaderAndDataAlignColumn
    '    csDate.MappingName = "Date"
    '    csDate.HeaderText = "Date"
    '    csDate.NullText = ""
    '    csDate.DataAlignment = HorizontalAlignment.Center
    '    csDate.Width = 100
    '    csDate.Format = "d"


    '    Dim csRequestor As New HeaderAndDataAlignColumn
    '    csRequestor.MappingName = "Requestor"
    '    csRequestor.HeaderText = "Requestor"
    '    csRequestor.NullText = ""
    '    csRequestor.DataAlignment = HorizontalAlignment.Center
    '    csRequestor.Width = 100

    '    Dim csCostCenter As New HeaderAndDataAlignColumn
    '    csCostCenter.MappingName = "CostCenter"
    '    csCostCenter.HeaderText = "CostCenter"
    '    csCostCenter.NullText = ""
    '    csCostCenter.DataAlignment = HorizontalAlignment.Center
    '    csCostCenter.Width = 100


    '    dst.GridColumnStyles.Add(csSelected)
    '    dst.GridColumnStyles.Add(csDescription)
    '    dst.GridColumnStyles.Add(csQty)
    '    dst.GridColumnStyles.Add(csDate)
    '    dst.GridColumnStyles.Add(csRequestor)
    '    dst.GridColumnStyles.Add(csCostCenter)
    '    Return dst
    'End Function
    'Public Function GetDataTable() As ExpandableRowDataTable
    '    Dim myDatatable As New ExpandableRowDataTable("JournalEntryItems")
    '    myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
    '    myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
    '    myDatatable.Columns.Add(New DataColumn("m_pr", GetType(Integer)))
    '    myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
    '    myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
    '    myDatatable.Columns.Add(New DataColumn("Qty", GetType(Decimal)))
    '    myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
    '    myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
    '    myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
    '    myDatatable.Columns.Add(New DataColumn("SortIndex", GetType(Decimal)))

    '    For Each item As JournalEntryItem In Me.List
    '        Dim row As ExpandableDataRow = myDatatable.Add(item.JournalEntry.Code & item.LineNumber)
    '        row("Selected") = False
    '        row("Code") = item.JournalEntry.Code
    '        row("m_pr") = item.JournalEntry.Id
    '        row("Linenumber") = item.LineNumber
    '        row("Date") = item.JournalEntry.DocDate
    '        row("Entity") = item.Entity.Code & ":" & item.Entity.Name
    '        row("Qty") = item.Qty
    '        row("Requestor") = item.Pr.Requestor.Code & ":" & item.Pr.Requestor.Name
    '        row("CostCenter") = item.Pr.CostCenter.Code & ":" & item.Pr.CostCenter.Name
    '        row.State = PlusMinusState.UnderParent
    '    Next
    '    Return myDatatable
    'End Function
    Public Overridable Function Save() As SaveErrorException
      Debug.WriteLine("Implement Me!!! ColumnCollection.Save")
    End Function
    Public Overridable Function Save(ByVal currentUserId As Integer) As SaveErrorException

      '
      'Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
      'Dim conn As New SqlConnection(sqlConString)
      'conn.Open()
      'Dim ds As New DataSet
      'Dim da As New SqlDataAdapter("Select * from JournalEntryItem where gli_pr=" & Me.m_owner.Id, conn)
      ''da.FillSchema(ds, SchemaType.Source, "PoItems")
      'da.Fill(ds, "JournalEntryItems")
      'Dim cmdBuilder As New SqlCommandBuilder(da)
      'With ds.Tables("JournalEntryItems")
      '    For Each row As DataRow In .Rows
      '        row.Delete()
      '    Next
      '    Dim i As Integer = 0
      '    For Each item As JournalEntryItem In Me
      '        i += 1
      '        Dim dr As DataRow = .NewRow
      '        dr("gli_pr") = Me.m_owner.Id
      '        dr("gli_linenumber") = i
      '        dr("gli_entity") = item.Entity.Id
      '        If item.Entity.Id = 0 Then
      '            dr("gli_itemName") = item.Entity.Name
      '        End If
      '        dr("gli_entityType") = item.ItemType.Value
      '        If Not item.Unit Is Nothing AndAlso item.Unit.Valid Then
      '            dr("gli_unit") = item.Unit.Id
      '        End If
      '        dr("gli_qty") = item.Qty
      '        dr("gli_note") = item.Note
      '        .Rows.Add(dr)
      '    Next
      'End With
      'Dim dt As DataTable = ds.Tables("JournalEntryItems")
      '' First process deletes.
      'da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Deleted))
      '' Next process updates.
      'da.Update(dt.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
      '' Finally process inserts.
      'da.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As JournalEntryItem) As Integer
      value.JournalEntry = Me.m_owner
      'Dim index As Integer = MyBase.List.Add(value)
      'If Not m_owner Is Nothing Then
      '    ReIndex()
      'End If
      Return MyBase.List.Add(value)
    End Function
    'Public Function Add(ByVal row As TreeRow) As Integer
    '    Dim newItem As New JournalEntryItem
    '    newItem.CopyFromDataRow(row)
    '    Dim index As Integer = MyBase.List.Add(newItem)
    '    If Not m_owner Is Nothing Then
    '        ReIndex()
    '    End If
    '    Return index
    'End Function
    Public Sub AddRange(ByVal value As JournalEntryItemCollection)
      For i As Integer = 0 To value.Count - 1
        'If Not Me.m_owner Is Nothing Then
        '    Dim myRow As TreeRow = Me.m_owner.ItemTable.Childs.Add
        '    value(i).CopyToDataRow(myRow)
        'End If
        Me.Add(value(i))
      Next
    End Sub
    'Public Sub AddRange(ByVal value As JournalEntryItem())
    '    For i As Integer = 0 To value.Length - 1
    '        If Not Me.m_owner Is Nothing Then
    '            Dim myRow As TreeRow = Me.m_owner.ItemTable.Childs.Add
    '            value(i).CopyToDataRow(myRow)
    '        End If
    '        Me.Add(value(i))
    '    Next
    'End Sub
    Public Function Contains(ByVal value As JournalEntryItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As JournalEntryItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As JournalEntryItemEnumerator
      Return New JournalEntryItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As JournalEntryItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    'Public Sub Insert(ByVal index As Integer, ByVal value As JournalEntryItem)
    '    If Not Me.m_owner Is Nothing Then
    '        Me.m_owner.IsInitialized = False
    '    End If
    '    If Not Me.m_owner Is Nothing Then
    '        Dim myRow As TreeRow = Me.m_owner.ItemTable.Childs.InsertAt(index)
    '        value.CopyToDataRow(myRow)
    '        If Not Me.m_manager Is Nothing Then
    '            Me.m_manager.SelectedRow = myRow
    '        End If
    '        'Hack อีกแล้ว (ถ้าไม่ AcceptChanges มันจะแสดงผลเพี้ยนๆบน Grid)
    '        Me.m_owner.ItemTable.AcceptChanges()
    '    End If

    '    MyBase.List.Insert(index, value)
    '    If Not Me.m_owner Is Nothing Then
    '        Me.m_owner.IsInitialized = True
    '    End If
    '    If Not m_owner Is Nothing Then
    '        ReIndex()
    '    End If
    'End Sub
    Public Sub Insert(ByVal index As Integer, ByVal value As JournalEntryItem)
      value.JournalEntry = Me.m_owner
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As JournalEntryItem)
      MyBase.List.Remove(value)
      'If Not m_owner Is Nothing Then
      '    ReIndex()
      'End If
    End Sub
    'Public Sub Remove(ByVal row As TreeRow)
    '    Dim index As Integer = Me.m_owner.ItemTable.Childs.IndexOf(row)
    '    MyBase.List.RemoveAt(index)
    '    If Not m_owner Is Nothing Then
    '        ReIndex()
    '    End If
    'End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
      'If Not Me.m_owner Is Nothing Then
      '    If Me.m_owner.ItemTable.Childs.Count > Me.Count Then
      '        Me.m_owner.ItemTable.Childs.Remove(Me.m_owner.ItemTable.Childs(index))
      '    End If
      'End If
      'If Not m_owner Is Nothing Then
      '    ReIndex()
      'End If
    End Sub
    'Public Sub ReIndex()
    '    For i As Integer = 0 To Me.Count - 1
    '        Me(i).LineNumber = i + 1
    '        Me.m_owner.ItemTable.Childs(i)("gli_linenumber") = i + 1
    '    Next
    'End Sub
#End Region


    Public Class JournalEntryItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As JournalEntryItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, JournalEntryItem)
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

