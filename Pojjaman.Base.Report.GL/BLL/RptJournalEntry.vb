'Option Strict On
'Option Explicit On 
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptJournalEntry
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_hashData As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
      MyBase.New(filters, fixValueCollection)
    End Sub
#End Region

#Region "Methods"
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 2
      lkg.Rows.FrozenCount = 2
            'm_grid.Model.Rows.Hidden(0) = True

            lkg.HideRows(0) = False
            lkg.RowHeights(0) = 20

      'm_grid.Model.Cols.Hidden(13) = True
      'm_grid.Model.Cols.Hidden(14) = True
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim indent As String = Space(5)
      ' Level 1.
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctCode}") '"รหัสบัญชี"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctName}") '"ชื่อบัญชี"
      ' Level 2.
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DocDate}") '"วันที่เอกสาร"
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DocCode}") '"เลขที่เอกสาร"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.RefDocCode}") '"เลขที่เอกสารอ้างอิง"
      tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.PVRVCode}") '"เลขที่ใบสำคัญรับ/จ่าย"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctBookName}") '"สมุดรายวัน"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Detail}") '"รายละเอียด/คำอธิบาย"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Debit}") '"เดบิต"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Credit}") '"เครดิต"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Balance}") '"ยอดคงเหลือ"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.CostCenter}") '"CC"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.ItemNote}") '"หมายเหตุรายการ"
      'tr("col11") = "id"
      'tr("col12") = "type"
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      'If IsNumeric(m_grid(e.RowIndex, 13).CellValue) AndAlso IsNumeric(m_grid(e.RowIndex, 14).CellValue) Then
      '  Dim docId As Integer
      '  Dim docType As Integer
      '  docId = CInt(m_grid(e.RowIndex, 13).CellValue)
      '  docType = CInt(m_grid(e.RowIndex, 14).CellValue)
      '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '  Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      '  myEntityPanelService.OpenDetailPanel(en)
      'End If

      Dim dr As DataRow = CType(m_hashData(e.RowIndex), DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("gl_refid")
      Dim docType As Integer = drh.GetValue(Of Integer)("gl_refDocType")

      Trace.WriteLine(docId.ToString & ":" & docType.ToString)

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub PopulateData()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      m_hashData = New Hashtable

      Dim dsh As New DataSetHelper
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim ShowSumEachAcct As Boolean = CBool(Me.DataSet.Tables(2).Rows(0).Item("ShowSumEachAcct"))
      Dim currentAccountCode As String = ""
      Dim currentDoc As String = ""
      Dim currentLine As String = ""

      Dim accountTr As TreeRow
      Dim docTr As TreeRow
      Dim totalBalance As Decimal

      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        Dim rowTag As Integer = CInt(row("acct_id"))
        Dim rowCode As String = CStr(row("acct_code"))
        Dim rowName As String = CStr(row("acct_name"))
        Dim rowLevel As Integer = CInt(row("acct_level"))
        Dim parentNodes As ITreeParent

        If IsDBNull(row("acct_parid")) OrElse CInt(row("acct_parid")) = CInt(row("acct_id")) Then
          parentNodes = Me.m_treemanager.Treetable
        Else
          Dim parnode As TreeRow = SearchTag(CInt(row("acct_parid")))
          If parnode Is Nothing Then
            parentNodes = Me.m_treemanager.Treetable
          Else
            parentNodes = parnode
          End If
        End If
        Dim theRow As TreeRow = parentNodes.Childs.Add
        theRow("col0") = rowCode
        theRow("col1") = Space(rowLevel) & rowName 'Space(rowLevel * 3) & rowName

        theRow.Tag = rowTag
        Me.SetTransaction(rowTag, theRow)
        therow.State = RowExpandState.Expanded
      Next
      Me.m_treemanager.Treetable.AcceptChanges()

      ' Summary Zone
      For Each row As DataRow In dt.Rows
        Dim parnode As TreeRow = SearchTag(CInt(row("acct_id")))
        If Not parnode Is Nothing AndAlso parnode.Childs.Count > 0 AndAlso (ShowSumEachAcct OrElse CInt(row("acct_id")) = 0) Then
          Dim debit As Decimal = 0
          Dim credit As Decimal = 0
          Dim theRow As TreeRow = parnode.Childs.Add
          therow("col1") = "รวมยอด:" & Trim(CStr(parnode("col1")))

          debit = SumChilds(debit, parnode, "col6")
          credit = SumChilds(credit, parnode, "col7")
          theRow("col6") = Configuration.FormatToString(debit, DigitConfig.Price)
          theRow("col7") = Configuration.FormatToString(credit, DigitConfig.Price)
          therow.Tag = "summary"
        End If
      Next
      Me.m_treemanager.Treetable.AcceptChanges()

      Dim lineNumber As Integer = 1
      For Each tr As TreeRow In Me.m_treemanager.Treetable.Rows
        If Not tr.Tag Is Nothing AndAlso TypeOf tr.Tag Is DataRow Then
          m_hashData(lineNumber) = CType(tr.Tag, DataRow)
        End If

        lineNumber += 1
      Next
    End Sub
    Private Function SumChilds(ByRef result As Decimal, ByVal parent As TreeRow, ByVal columnName As String) As Decimal
      If parent.Childs.Count > 0 Then
        For Each childs As TreeRow In parent.Childs
          If Not childs.IsNull(columnName) Then result += Configuration.Format(CDec(childs(columnName)), DigitConfig.Price)
          If childs.Childs.Count > 0 Then SumChilds(result, childs, columnName)
        Next
      End If
      Return result
    End Function
    Private Function SearchTag(ByVal id As Integer) As TreeRow
      If Me.m_treemanager Is Nothing Then
        Return Nothing
      End If
      Dim dt As TreeTable = m_treemanager.Treetable
      For Each row As TreeRow In dt.Rows
        If IsNumeric(row.Tag) AndAlso CInt(row.Tag) = id Then
          Return row
        End If
      Next
    End Function
    Private Sub SetTransaction(ByVal id As Integer, ByVal tr As TreeRow)
      If Me.DataSet.Tables.Count > 1 Then
        Dim dt As DataTable = Me.DataSet.Tables(1)
        Dim ComputeDrCr As Boolean = CBool(Me.DataSet.Tables(3).Rows(0).Item("ComputeDrCr"))
        Dim totalbalance As Decimal = 0
        For Each row As DataRow In dt.Select("acct_id = " & id.ToString)
          If Not row.IsNull("gl_id") Then
            Dim theRow As TreeRow = tr.Childs.Add
            Dim isdebit As Boolean = CBool(row("gli_isdebit"))
            Dim gli_balanceamt As Decimal = CDec(IIf(row.IsNull("gli_balanceamt"), 0, row("gli_balanceamt")))
            Dim gli_debitamt As Decimal = CDec(IIf(row.IsNull("gli_debitamt"), 0, row("gli_debitamt")))
            Dim gli_creditamt As Decimal = CDec(IIf(row.IsNull("gli_creditamt"), 0, row("gli_creditamt")))

            If ComputeDrCr Then
              If gli_debitamt < gli_creditamt Then
                gli_creditamt -= gli_debitamt
                gli_debitamt = 0
              Else
                gli_debitamt -= gli_creditamt
                gli_creditamt = 0
              End If
            End If

            If Not row.IsNull("gl_docdate") Then
              theRow("col0") = Space(2) & CDate(row("gl_docdate")).ToString("dd/MM/yyyy")
            End If
            If Not row.IsNull("gl_code") Then
              theRow("col1") = CStr(row("gl_code")) 'Space(6) & CStr(row("gl_code"))
            End If
            If Not row.IsNull("gl_refcode") Then
              theRow("col2") = CStr(row("gl_refcode")) 'Space(6) & CStr(row("gl_refcode"))
            End If


            theRow("col3") = row("stock_pvrv")      ' ใบสำคัญรับ/จ่าย
            theRow("col4") = row("accountbook_name")      ' สมุดรายวัน
            theRow("col5") = row("gl_note")       ' รายการ/คำอธิบาย

            theRow("col6") = Configuration.FormatToString(gli_debitamt, DigitConfig.Price)      ' เดบิต
            theRow("col7") = Configuration.FormatToString(gli_creditamt, DigitConfig.Price)      ' เครบิต

            totalbalance += gli_balanceamt

            theRow("col8") = Configuration.FormatToString(totalbalance, DigitConfig.Price)      ' ยอดคงเหลือ
            theRow("col9") = row("cc_code")       ' Costcenter
            theRow("col10") = row("gli_note")       ' หมายเหตุรายการ
            'theRow("col11") = row("gl_refid")
            'theRow("col12") = row("gl_refDocType")

            theRow.Tag = row '"glitem"
          End If
        Next
        tr.AcceptChanges()
      End If
    End Sub
    Public Overrides Function GetSimpleSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("IsSummary", GetType(Boolean)))
      'myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      widths.Add(100)
      widths.Add(250)
      widths.Add(120)
      widths.Add(140)
      widths.Add(120)
      widths.Add(250)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(50)
      widths.Add(150)

      'widths.Add(50)
      'widths.Add(50)
      For i As Integer = 0 To 10
        If i = 1 Then
          Dim cs As New PlusMinusTreeTextColumn
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          cs.ReadOnly = True
          cs.Format = "d"
          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          Select Case i
            Case 6, 7, 8
              cs.Alignment = HorizontalAlignment.Right
              cs.DataAlignment = HorizontalAlignment.Right
            Case Else
              cs.Alignment = HorizontalAlignment.Left
              cs.DataAlignment = HorizontalAlignment.Left
          End Select
          cs.ReadOnly = True
          cs.Format = "d"
          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        End If
      Next
      Return dst
    End Function
    Public Overrides Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row <= 1 Then
        e.HilightValue = True
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
    End Function
    Public Overrides Function GetDefaultForm() As String

    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        Select Case fixDpi.Mapping.ToLower
          Case "month", "year", "format", "today"
            dpiColl.Add(fixDpi)
          Case "docdatestart", "docdateend"
            dpiColl.Add(fixDpi)
          Case "accountstart", "accountend"
            dpiColl.Add(fixDpi)
          Case "costcenterstart", "costcenterend"
            dpiColl.Add(fixDpi)
          Case "childincluded"
            dpiColl.Add(fixDpi)
        End Select
      Next

      Dim i As Integer = 0
      For Each itemRow As TreeRow In Me.Treemanager.Treetable.Rows
        If itemRow.Index > 1 Then
          'Item.DocDate
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          If itemRow.Level = 0 Then
            dpi.Value = itemRow("col0")
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          Else
            If Not itemRow.IsNull("col0") Then
              dpi.Value = CStr(itemRow("col0"))
            Else
              dpi.Value = itemRow("col0")
            End If
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.AccountBookCode
          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
            dpi.Value = itemRow("col1")
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          Else
            If Not itemRow.IsNull("col1") Then
              dpi.Value = CStr(itemRow("col1"))
            Else
              dpi.Value = itemRow("col1")
            End If
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.RefCode
          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          If itemRow.Level = 0 Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
          dpi.Value = itemRow("col2")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.PVRVCode
          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          If itemRow.Level = 0 Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
          dpi.Value = itemRow("col3")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.AccountBook
          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          If itemRow.Level = 0 Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
          dpi.Value = itemRow("col4")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Description
          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          If itemRow.Level = 0 Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
          dpi.Value = itemRow("col5")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)


          'Item.Debit
          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
            dpi.Value = itemRow("col6")
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          Else
            If Not itemRow.IsNull("col6") Then
              dpi.Value = "      " & CStr(itemRow("col6"))
            Else
              dpi.Value = itemRow("col6")
            End If
          End If
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          'Item.Credit
          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          If itemRow.Level = 0 Or itemRow.Tag.ToString.ToLower = "summary" Then
            dpi.Value = itemRow("col7")
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          Else
            If Not itemRow.IsNull("col7") Then
              dpi.Value = "      " & CStr(itemRow("col7"))
            Else
              dpi.Value = itemRow("col7")
            End If
          End If
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          If itemRow.Tag.ToString.ToLower = "summary" Then dpi.LineStyle = 2
          dpiColl.Add(dpi)

          'Item.Remain
          dpi = New DocPrintingItem
          dpi.Mapping = "col8"
          If itemRow.Level = 0 Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
          If Not itemRow.IsNull("isSummary") AndAlso CBool(itemRow("isSummary")) Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            dpi.LineStyle = 2
          End If
          dpi.Value = itemRow("col8")
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.CostCenter
          dpi = New DocPrintingItem
          dpi.Mapping = "col9"
          If itemRow.Level = 0 Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
          dpi.Value = itemRow("col9")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ItemNote
          dpi = New DocPrintingItem
          dpi.Mapping = "col10"
          If itemRow.Level = 0 Then
            dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
          dpi.Value = itemRow("col10")
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      'For Each itemRow As DataRow In Me.DataSet.Tables(0).Rows
      '    'Item.AccountCode
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.AccountCode"
      '    dpi.Value = itemRow("AccountCode")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.AccountName
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.AccountName"
      '    dpi.Value = itemRow("AccountName")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.DocDate
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.DocDate"
      '    dpi.Value = itemRow("DocDate")
      '    dpi.DataType = "System.DateTime"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.AccountBookCode
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.AccountBookCode"
      '    dpi.Value = itemRow("AccountBookCode")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.AccountBookName
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.AccountBookName"
      '    dpi.Value = itemRow("AccountBookName")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.DocCode
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.DocCode"
      '    dpi.Value = itemRow("DocCode")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.RefDocCode
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.RefDocCode"
      '    dpi.Value = itemRow("RefDocCode")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.RefDocType
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.RefDocType"
      '    dpi.Value = itemRow("RefDocType")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Description
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Description"
      '    dpi.Value = itemRow("Description")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.TotalDebitamt
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.TotalDebitamt"
      '    dpi.Value = itemRow("TotalDebitamt")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.TotalCreditamt
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.TotalCreditamt"
      '    dpi.Value = itemRow("TotalCreditamt")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.debitamt
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.debitamt"
      '    dpi.Value = itemRow("debitamt")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.creditamt
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.creditamt"
      '    dpi.Value = itemRow("creditamt")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.Balanceamt
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.Balanceamt"
      '    dpi.Value = itemRow("Balanceamt")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.CostcenterCode
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.CostcenterCode"
      '    dpi.Value = itemRow("CostcenterCode")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)

      '    'Item.CostcenterName
      '    dpi = New DocPrintingItem
      '    dpi.Mapping = "Item.CostcenterName"
      '    dpi.Value = itemRow("CostcenterName")
      '    dpi.DataType = "System.String"
      '    dpi.Row = i + 1
      '    dpi.Table = "Item"
      '    dpiColl.Add(dpi)
      '    i += 1
      'Next
      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

