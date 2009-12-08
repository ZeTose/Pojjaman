Option Explicit On 
Option Strict On
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptSpecialJournalEntry
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private ShowSummary As Boolean
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
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 1
      lkg.Rows.FrozenCount = 1
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
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
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.DocDate}") ' "วันที่"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.DocCode}") ' "เลขที่เอกสาร"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.RefDocCode}") ' "เลขที่เอกสารอ้างอิง"
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.AccountCode}") ' "รหัสผังบัญชี"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.AccountName}") ' "ชื่อผังบัญชี"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.JurnalCode}") ' "สมุดรายวัน"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.TotalDr}") ' "รวมเดบิต"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.TotalCr}") ' "รวมเครดิต".
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.Remaining}") ' "คงเหลือ"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.CostCenter}") ' "Cost Center"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.AccountType}") 'ประเภทบัญชี
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.PVRV}") 'ใบสำคัญรับ/จ่าย
      tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.Note}") 'หมายเหตุ


    End Sub
    Private Sub PopulateData()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim remaining As Decimal = 0
      Dim trGL As TreeRow
      For Each row As DataRow In dt.Rows
        trGL = Me.m_treemanager.Treetable.Childs.Add
        trGL("col0") = CDate(row("gl_docdate")).ToShortDateString
        trGL("col1") = row("gl_code")
        trGL("col2") = row("gl_refcode")
        trGL("col3") = row("acct_code")
        trGL("col4") = row("acct_name")
        trGL("col5") = row("accountbook_code")
        trGL("col6") = Configuration.FormatToString(CDec(row("debit")), DigitConfig.Price)
        remaining += CDec(row("debit"))
        trGL("col7") = Configuration.FormatToString(CDec(row("credit")), DigitConfig.Price)
        remaining -= CDec(row("credit"))
        trGL("col8") = Configuration.FormatToString(remaining, DigitConfig.Price)
        trGL("col9") = row("cc_code")
        trGL("col10") = row("code_description")
        trGL("col11") = row("gli_pvrv")
        trGL("col12") = row("gli_note")
      Next
    End Sub
    Private Function SumChilds(ByRef result As Decimal, ByVal parent As TreeRow, ByVal columnName As String) As Decimal
      If parent.Childs.Count > 0 Then
        For Each childs As TreeRow In parent.Childs
          If Not childs.IsNull(columnName) Then result += CDec(childs(columnName))
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
      myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      widths.Add(80)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(200)
      widths.Add(80)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(150)

      For i As Integer = 0 To 12
        Dim cs As New TreeTextColumn(i, True, Color.Khaki)
        cs.MappingName = "col" & i
        cs.HeaderText = ""
        cs.Width = CInt(widths(i))
        cs.NullText = ""
        Select Case i
          Case 5
            cs.Alignment = HorizontalAlignment.Center
            cs.DataAlignment = HorizontalAlignment.Center
            cs.Format = "s"
          Case 6, 7, 8
            cs.Alignment = HorizontalAlignment.Right
            cs.DataAlignment = HorizontalAlignment.Right
            cs.Format = "s"
          Case Else
            cs.Alignment = HorizontalAlignment.Left
            cs.DataAlignment = HorizontalAlignment.Left
            cs.Format = "d"
        End Select
        cs.ReadOnly = True
        'AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
        dst.GridColumnStyles.Add(cs)
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
        Return "RptSpecialJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptSpecialJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptSpecialJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSpecialJournalEntry.ListLabel}"
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
#End Region
#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
    End Function
    Public Overrides Function GetDefaultForm() As String

    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim i As Integer = 0
      For rowItem As Integer = 2 To Me.Treemanager.Treetable.Rows.Count
        For colItem As Integer = 1 To Me.Treemanager.Treetable.Columns.Count
          'status
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & colItem.ToString
          dpi.Value = m_grid(rowItem, colItem).CellValue '(rowItem, colItem)
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next
        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

