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
  Public Class RptPurchaseDocLinking
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

#Region "Style"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PurchaseDocLinking"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'Dim csLineNumber As New TreeTextColumn
      'csLineNumber.MappingName = "LineNumber"
      'csLineNumber.HeaderText = "#" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      'csLineNumber.NullText = ""
      'csLineNumber.Width = 30
      'csLineNumber.DataAlignment = HorizontalAlignment.Center
      'csLineNumber.ReadOnly = True
      'csLineNumber.TextBox.Name = "LineNumber"

      Dim csCode As New PlusMinusTreeTextColumn
      csCode.MappingName = "code"
      csCode.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csCode.NullText = ""
      csCode.Width = 200
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.Alignment = HorizontalAlignment.Left
      csCode.TextBox.Name = "code"
      csCode.ReadOnly = True

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "description"
      csDescription.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csDescription.NullText = ""
      csDescription.Width = 120
      csDescription.DataAlignment = HorizontalAlignment.Left
      csDescription.TextBox.Name = "description"
      csDescription.ReadOnly = True

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "date"
      csDate.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      csDate.NullText = ""
      csDate.Width = 100
      csDate.DataAlignment = HorizontalAlignment.Left
      csDate.Alignment = HorizontalAlignment.Left
      csDate.TextBox.Name = "date"
      csDate.ReadOnly = True

      Dim cspayDescription As New TreeTextColumn
      cspayDescription.MappingName = "paydescription"
      cspayDescription.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      cspayDescription.NullText = ""
      cspayDescription.Width = 120
      cspayDescription.DataAlignment = HorizontalAlignment.Left
      cspayDescription.TextBox.Name = "paydescription"
      cspayDescription.ReadOnly = True

      Dim cspayCode As New TreeTextColumn
      cspayCode.MappingName = "paycode"
      cspayCode.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      cspayCode.NullText = ""
      cspayCode.Width = 120
      cspayCode.DataAlignment = HorizontalAlignment.Left
      cspayCode.TextBox.Name = "paycode"
      cspayCode.ReadOnly = True

      Dim csPayDate As New TreeTextColumn
      csPayDate.MappingName = "paydate"
      csPayDate.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      csPayDate.NullText = ""
      csPayDate.Width = 100
      csPayDate.DataAlignment = HorizontalAlignment.Left
      csPayDate.Alignment = HorizontalAlignment.Left
      csPayDate.TextBox.Name = "paydate"
      csPayDate.ReadOnly = True

      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(cspayDescription)
      dst.GridColumnStyles.Add(cspayCode)
      dst.GridColumnStyles.Add(csPayDate)

      Return dst
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PurchaseDocLinking")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      'myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("id", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("date", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("paydescription", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("paycode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("paydate", GetType(String)))

      Return myDatatable
    End Function
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      'Dim indent As String = Space(5)
      ' Level 1.
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("description") = "Description" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctName}") '"ชื่อบัญชี"
      tr("code") = "Code" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctCode}") '"รหัสบัญชี"
      tr("date") = "Date" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.Amount}") '"จำนวนเงิน"
      tr("paydescription") = "PayDescription" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.Description}") '"ประเภทเอกสาร"
      tr("paycode") = "PayCode" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.Description}") '"ประเภทเอกสาร"
      tr("paydate") = "PayDate" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.Description}") '"ประเภทเอกสาร"
      ' Level 2.
      'tr = Me.m_treemanager.Treetable.Childs.Add
      'tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DocDate}") '"วันที่เอกสาร"
      'tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DocCode}") '"เลขที่เอกสาร"
      'tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.RefDocCode}") '"เลขที่เอกสารอ้างอิง"
      'tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.PVRVCode}") '"เลขที่ใบสำคัญรับ/จ่าย"
      'tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctBookName}") '"สมุดรายวัน"
      'tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Detail}") '"รายละเอียด/คำอธิบาย"
      'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Debit}") '"เดบิต"
      'tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Credit}") '"เครดิต"
      'tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Balance}") '"ยอดคงเหลือ"
      'tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.CostCenter}") '"CC"
      'tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.ItemNote}") '"หมายเหตุรายการ"
      'tr("col11") = "id"
      'tr("col12") = "type"
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return RptPurchaseDocLinking.GetSchemaTable 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return RptPurchaseDocLinking.CreateTableStyle 'BOQ.CreateWBSMonitorTableStyle
    End Function
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
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      'lkg.HideHead = True
      'lkg.Cols.FrozenCount = 2
      'm_grid.Model.Cols.Hidden(m_grid.ColCount) = True
      lkg.Rows.HeaderCount = 1
      lkg.Rows.FrozenCount = 1
      lkg.HilightGroupParentText = True
      lkg.RefreshHeights()
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      'If m_cc Is Nothing OrElse Not m_cc.Originated Then
      '  Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '  dt.Clear()
      '  tm.Treetable = dt
      '  Return
      'End If
      'If m_cc.BoqId = 0 Then
      '  Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '  dt.Clear()
      '  tm.Treetable = dt
      '  Return
      'End If
      'If TypeOf Me.Filters(1).Value Is Date Then
      'Dim nodigit As Boolean = False
      'If Me.Filters(5).Name.ToLower = "nodigit" Then
      '  nodigit = CBool(Me.Filters(5).Value)
      'End If
      CreateHeader()
      PopulateData()
      'End If
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim tr As Object = m_hashData(e.RowIndex)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is IdType Then
        Dim c As IdType = CType(tr, IdType)

        Dim docId As Integer = c.Id
        Dim docType As Integer = c.Type

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As Services.IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
        End If
      End If
    End Sub
    Private Class IdType
      Public Sub New(ByVal mid As Integer, ByVal mtype As Integer)
        Id = mid
        Type = mtype
      End Sub

      Public Property Id As Integer
      Public Property Type As Integer
    End Class
    Dim rowHash As Hashtable
    Dim desHash As Hashtable
    Private Function FindRow(ByVal dt As TreeTable, ByVal drh As DataRowHelper, ByVal prefix As String, ByVal hash As Hashtable, ByVal parent As TreeRow) As TreeRow
      Dim row As TreeRow = Nothing
      Dim key As String = ""
      Dim parId As String = ""
      If Not parent.IsNull("id") Then
        parId = parent("id")
      End If

      Dim prid As Integer = drh.GetValue(Of Integer)("pr_id")
      Dim poid As Integer = drh.GetValue(Of Integer)("po_id")
      Dim grid As Integer = drh.GetValue(Of Integer)("stock_id")
      Dim pyid As Integer = drh.GetValue(Of Integer)("pays_id")
      Dim biid As Integer = drh.GetValue(Of Integer)("billa_id")

      Select Case prefix.ToLower
        Case "pr"
          key = prefix & ":" & prid.ToString
        Case "po"
          key = prefix & ":" & parId.ToString & ":" & poid.ToString
        Case "stock"
          key = prefix & ":" & parId.ToString & ":" & grid.ToString
        Case "pays"
          key = prefix & ":" & parId.ToString & ":" & pyid.ToString
        Case "billa"
          key = prefix & ":" & parId.ToString & ":" & biid.ToString
        Case "paymenti45"
          key = prefix & ":" & prid.ToString
        Case "paymenti73"
          key = prefix & prid.ToString
      End Select

      Trace.WriteLine(key.ToString)

      If Not hash.ContainsKey(key) Then
        If parent Is Nothing Then
          row = dt.Childs.Add
        Else
          row = parent.Childs.Add
        End If

        row("id") = key
        row("code") = drh.GetValue(Of String)(prefix & "_code")
        row("description") = desHash(prefix)
        If Date.MinValue = drh.GetValue(Of Date)(prefix & "_docdate").ToShortDateString Then
          row("date") = ""
        Else
          row("date") = drh.GetValue(Of Date)(prefix & "_docdate").ToShortDateString
        End If
        row("paydescription") = drh.GetValue(Of String)(prefix & "description")
        row("paycode") = drh.GetValue(Of String)(prefix & "entitycode")
        If Date.MinValue = drh.GetValue(Of Date)(prefix & "duedate") Then
          row("paydate") = ""
        Else
          row("paydate") = drh.GetValue(Of Date)(prefix & "duedate").ToShortDateString
        End If

        If prefix = "paymenti45_" OrElse prefix = "paymenti73_" Then
        Else
          row.State = RowExpandState.Expanded
        End If

        Dim rowIndex As Integer = Me.m_treemanager.Treetable.Rows.IndexOf(row) + 1
        Select Case prefix.ToLower
          Case "pr"
            m_hashData(rowIndex) = New IdType(prid, 7)
          Case "po"
            m_hashData(rowIndex) = New IdType(poid, 6)
          Case "stock"
            m_hashData(rowIndex) = New IdType(grid, 45)
          Case "pays"
            m_hashData(rowIndex) = New IdType(pyid, 73)
          Case "billa"
            m_hashData(rowIndex) = New IdType(biid, 60)
          Case "paymenti45"
            m_hashData(rowIndex) = New IdType(prid, 6)
          Case "paymenti73"
            m_hashData(rowIndex) = New IdType(prid, 6)
        End Select

        hash(key) = row
        Return row
      Else
        Return CType(hash(key), TreeRow)
      End If
    End Function
    Private Function FindParRow(ByVal dt As TreeTable, ByVal hash As Hashtable, ByVal drh As DataRowHelper) As TreeRow
      Dim key As String = ""
      Dim prid As Integer = 0
      Dim poid As Integer = 0
      Dim grid As Integer = 0
      Dim caseid As Integer = 0
      Dim type As Integer

      prid = drh.GetValue(Of Integer)("pr_id")
      poid = drh.GetValue(Of Integer)("po_id")
      grid = drh.GetValue(Of Integer)("stock_id")
      caseid = drh.GetValue(Of Integer)("case")

      If prid > 0 Then
        type = 1
        key = "haspr"
      ElseIf prid = 0 AndAlso poid > 0 Then
        type = 2
        key = "nopr"
      ElseIf prid = 0 AndAlso poid = 0 Then
        type = 3
        key = "noprnopo"
      End If

      If Not hash.ContainsKey(key) Then
        Dim row As TreeRow = dt.Childs.Add
        row.State = RowExpandState.Expanded
        Select Case type
          Case 1
            row("code") = "มีใบขอซื้อ"
            row("id") = "pr:0"
          Case 2
            row("code") = "ไม่มีใบสั่งซื้อ"
            row("id") = "po:0"
          Case 3
            row("code") = "ไม่มีใบขอซื้อ และไม่มีใบสั่งซื้อ"
            row("id") = "stock:0"
        End Select
        hash(key) = row
        Return row
      Else
        Return CType(hash(key), TreeRow)
      End If
    End Function
    Public Sub PopulateData()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treemanager.Treetable

      Dim dt0 As DataTable = Me.DataSet.Tables(0)
      Dim dt1 As DataTable = Me.DataSet.Tables(1)

      Dim prRow As TreeRow = Nothing
      Dim poRow As TreeRow = Nothing
      Dim grRow As TreeRow = Nothing
      Dim pyRow As TreeRow = Nothing

      Dim prid As Integer = 0
      Dim poid As Integer = 0
      Dim grid As Integer = 0
      Dim caseid As Integer = 0

      Dim indent As String = Space(3)

      rowHash = New Hashtable
      desHash = New Hashtable
      desHash("pr") = "ใบขอซื้อ"
      desHash("po") = indent & "ใบสั่งซื้อ"
      desHash("stock") = indent & indent & "ใบรับของ"
      desHash("pays") = indent & indent & indent & "ใบจ่ายชำระ"
      desHash("billa") = indent & indent & indent & "ใบวางบิล"

      Dim parRow As TreeRow = Nothing

      m_hashData = New Hashtable

      Try

        For Each row As DataRow In dt0.Rows
          Dim drh As New DataRowHelper(row)
          prid = drh.GetValue(Of Integer)("pr_id")
          poid = drh.GetValue(Of Integer)("po_id")
          grid = drh.GetValue(Of Integer)("stock_id")
          caseid = drh.GetValue(Of Integer)("case")

          parRow = FindParRow(dt, rowHash, drh)

          prRow = FindRow(dt, drh, "pr", rowHash, parRow)

          If (caseid = 1 AndAlso poid > 0) OrElse (caseid = 2) OrElse (caseid = 3) Then
            poRow = FindRow(dt, drh, "po", rowHash, prRow)
          End If

          If grid > 0 Then
            grRow = FindRow(dt, drh, "stock", rowHash, poRow)

            'For Each pydRow As DataRow In dt3.Select("stock_Id=" & grid.ToString)
            '  Dim pydrh As New DataRowHelper(pydRow)
            '  If pydrh.GetValue(Of Integer)("paymenti45_entity", -1) >= 0 Then
            '    FindRow(dt, pydrh, "paymenti45_", rowHash, grRow)
            '  End If
            'Next

            For Each pydRow As DataRow In dt1.Select("stock_Id=" & grid.ToString)

              Dim pydrh As New DataRowHelper(pydRow)
              If pydrh.GetValue(Of Integer)("billa_id") > 0 Then
                FindRow(dt, pydrh, "billa", rowHash, grRow)
              End If
              If pydrh.GetValue(Of Integer)("pays_id") > 0 Then
                pyRow = FindRow(dt, pydrh, "pays", rowHash, grRow)

                For Each pay73 As DataRow In dt1.Select("pays_id=" & pydrh.GetValue(Of Integer)("pays_id").ToString)
                  Dim pay73dhp As New DataRowHelper(pay73)
                  If pay73dhp.GetValue(Of Integer)("paymenti73_entity", -1) > -1 Then
                    FindRow(dt, pay73dhp, "paymenti73_", rowHash, pyRow)
                  End If
                Next

              End If
            Next
          End If
        Next

        Dim i As Integer = 0
        For Each row As TreeRow In dt.Rows
          i += 1
        Next

        'If i > 0 Then
        dt.AcceptChanges()
        'End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

    End Sub
    Private Function SetDataSourceFiltered(ByVal dt As DataTable, ByVal columnSource As String, ByVal codestart As String, ByVal codeend As String) As DataTable
      Dim newdt As New DataTable
      Dim filterString As String = ""

      If codestart.Length = 0 AndAlso codeend.Length = 0 Then
        Return dt
      ElseIf codestart.Length > 0 AndAlso codeend.Length = 0 Then
        filterString = columnSource & " >= '" & codestart & "'"
      ElseIf codestart.Length = 0 AndAlso codeend.Length < 0 Then
        filterString = columnSource & " <= '" & codeend & "'"
      Else
        filterString = columnSource & " >= '" & codestart & "' and " & columnSource & " <='" & codeend & "'"
      End If

      For Each dcol As DataColumn In dt.Columns
        newdt.Columns.Add(New DataColumn(dcol.ColumnName))
      Next

      For Each drow As DataRow In dt.Select(filterString)
        Dim newDrow As DataRow = newdt.NewRow

        For Each dcol As DataColumn In dt.Columns
          newDrow(dcol.ColumnName) = drow(dcol.ColumnName)
        Next
        newdt.Rows.Add(newDrow)
      Next

      Return newdt
    End Function

#End Region

#Region "Select Distinct From DataTable"
    'Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
    '    Dim lastValues() As Object
    '    Dim newTable As DataTable

    '    If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
    '        Throw New ArgumentNullException("FieldNames")
    '    End If

    '    lastValues = New Object(FieldNames.Length - 1) {}
    '    newTable = New DataTable

    '    For Each field As String In FieldNames
    '        newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
    '    Next

    '    For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
    '        If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
    '            newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

    '            setLastValues(lastValues, Row, FieldNames)
    '        End If
    '    Next

    '    Return newTable
    'End Function
    Private Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
      Dim areEqual As Boolean = True

      For i As Integer = 0 To fieldNames.Length - 1
        If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
          areEqual = False
          Exit For
        End If
      Next

      Return areEqual
    End Function
    Private Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
      For Each field As String In fieldNames
        newRow(field) = sourceRow(field)
      Next

      Return newRow
    End Function
    Private Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
      For i As Integer = 0 To fieldNames.Length - 1
        lastValues(i) = sourceRow(fieldNames(i))
      Next
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptPurchaseDocLinking"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseDocLinking.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptPurchaseDocLinking"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptPurchaseDocLinking"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseDocLinking.ListLabel}"
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
      Return "RptPurchaseDocLinking"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptPurchaseDocLinking"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 1 To m_grid.RowCount
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid(rowIndex, 2).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid(rowIndex, 3).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 4).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 5).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 6).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

