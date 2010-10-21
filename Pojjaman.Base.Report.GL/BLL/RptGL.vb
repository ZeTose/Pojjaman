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
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptGL
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private ShowSummary As Boolean
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
            RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
            lkg.DefaultBehavior = False
            lkg.HilightWhenMinus = True
            lkg.Init()
            lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
            ListInGrid(tm)
            lkg.TreeTableStyle = CreateSimpleTableStyle()
            lkg.TreeTable = tm.Treetable
            lkg.Rows.HeaderCount = 2
            lkg.Rows.FrozenCount = 2
            lkg.Refresh()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
            Dim tr As Object = m_hashData(e.RowIndex)
            If tr Is Nothing Then
                Return
            End If

            If TypeOf tr Is DataRow Then
                Dim dr As DataRow = CType(tr, DataRow)
                If dr Is Nothing Then
                    Return
                End If

                Dim drh As New DataRowHelper(dr)

                Dim docId As Integer = drh.GetValue(Of Integer)("docId")
                Dim docType As Integer = drh.GetValue(Of Integer)("docType")

                Debug.Print(docId.ToString)
                Debug.Print(docType.ToString)

                If docId > 0 AndAlso docType > 0 Then
                    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                    myEntityPanelService.OpenDetailPanel(en)
                End If
            End If
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
            tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.DocDate}") ' "วันที่"
            tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.DocCode}") ' "เลขที่เอกสาร"
            tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.RefDocCode}") ' "เลขที่เอกสารอ้างอิง"
            tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.JurnalCode}") ' "สมุดรายวัน"
            tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.DocType}") ' "ประเภทเอกสาร"
            tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.Description}") ' "รายละเอียด"
            tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.TotalDr}") ' "รวมเดบิต"
            tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.TotalCr}") ' "รวมเครดิต"
            tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.CostCenter}") ' "Cost Center"
            tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.Supplier}") ' "ผู้ขาย"
            tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.Status}") 'สถานะการยกเลิก

            ' Level 2.
            tr = Me.m_treemanager.Treetable.Childs.Add
            tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.AccountCode}")  ' "รหัสผังบัญชี"
            tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.AccountName}")   '"ชื่อผังบัญชี"
            tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.Dr}") ' "เดบิต"
            tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.Cr}")  '"เครดิต"

        End Sub
        Private Sub PopulateData()
            If Me.m_treemanager Is Nothing Then
                Return
            End If
            Dim dsh As New DataSetHelper
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim trGL As TreeRow
            Dim trGLitem As TreeRow

            Dim currentGLCode As String = ""
            Dim currentLinenumber As Integer
            Dim indent As String = Space(5)
            Dim SumDebitGrandTotal As Decimal = 0
            Dim SumCreditGrandTotal As Decimal = 0

            Dim rowIndex As Integer = 0
            m_hashData = New Hashtable

            For Each row As DataRow In dt.Rows
                If row("gl_code").ToString <> currentGLCode Then
                    trGL = Me.m_treemanager.Treetable.Childs.Add

                    rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trGL) + 1
                    m_hashData(rowIndex) = row

                    trGL("col0") = CDate(row("gl_docdate")).ToShortDateString
                    trGL("col1") = row("gl_code")
                    trGL("col2") = row("gl_refcode")
                    trGL("col3") = row("accountbook_name")
                    trGL("col4") = Me.StringParserService.Parse(row("gl_refdoctype").ToString)
                    trGL("col5") = row("gl_refdocnote")
                    trGL("col9") = row("suppliername")
                    If CInt(row("gl_status")) = 0 Then
                        trGL("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.Cenceled}")  '"ถูกยกเลิก"
                    End If

                    trGL.Tag = CInt(row("gl_id"))

                    currentGLCode = row("gl_code").ToString
                    currentLinenumber = 0
                    trGL.State = RowExpandState.Expanded
                End If
                If Not row.IsNull("gli_linenumber") AndAlso CInt(row("gli_linenumber")) <> currentLinenumber Then
                    trGLitem = trGL.Childs.Add
                    trGLitem("col1") = indent & row("acct_code").ToString
                    Dim isdebit As Boolean = CBool(row("gli_isdebit"))
                    Dim gli_amt As Decimal = CDec(row("gli_amt"))
                    If isdebit Then
                        trGLitem("col3") = indent & "Dr." & row("acct_name").ToString
                        trGLitem("col5") = indent & row("gli_note").ToString
                        trGLitem("col6") = Configuration.FormatToString(gli_amt, DigitConfig.Price)
                    Else
                        trGLitem("col3") = indent & indent & "Cr." & row("acct_name").ToString
                        trGLitem("col5") = indent & row("gli_note").ToString
                        trGLitem("col7") = Configuration.FormatToString(gli_amt, DigitConfig.Price)
                    End If
                    trGLitem("col8") = row("cc_code")
                    trGLitem.Tag = "glitem"
                    currentLinenumber = CInt(row("gli_linenumber"))
                End If
            Next

            ShowSummary = CBool(Me.DataSet.Tables(2).Rows(0).Item("ShowSummary"))
            currentGLCode = ""
            ' Summary Zone
            For Each row As DataRow In dt.Rows
                If row("gl_code").ToString <> currentGLCode Then
                    Dim parnode As TreeRow = SearchTag(CInt(row("gl_id")))
                    If Not parnode Is Nothing AndAlso parnode.Childs.Count > 0 Then
                        Dim debit As Decimal = 0
                        Dim credit As Decimal = 0
                        debit = SumChilds(debit, parnode, "col6")
                        credit = SumChilds(credit, parnode, "col7")
                        If ShowSummary Then
                            Dim theRow As TreeRow = parnode.Childs.Add
                            theRow("col1") = "รวม " & (parnode.Childs.Count - 1).ToString & " รายการ"
                            theRow("col5") = "รวมทั้งสิ้น"
                            theRow("col6") = Configuration.FormatToString(debit, DigitConfig.Price)
                            theRow("col7") = Configuration.FormatToString(credit, DigitConfig.Price)
                            theRow.Tag = "summary"
                        End If
                        SumDebitGrandTotal += debit
                        SumCreditGrandTotal += credit
                    End If
                End If
                currentGLCode = row("gl_code").ToString
            Next
            Me.m_treemanager.Treetable.AcceptChanges()

            If Not dt.Rows Is Nothing Then
                trGL = Me.m_treemanager.Treetable.Childs.Add
                trGL("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptGL.GrandTotal}")  '"ยอดรวมทั้งหมด"
                trGL("col6") = Configuration.FormatToString(SumDebitGrandTotal, DigitConfig.Price)
                trGL("col7") = Configuration.FormatToString(SumCreditGrandTotal, DigitConfig.Price)
                trGL.State = RowExpandState.None
            End If
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

            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            widths.Add(80)
            widths.Add(100)
            widths.Add(150)
            widths.Add(200)
            widths.Add(100)
            widths.Add(200)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)

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
                        Case 6, 7
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
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptGL"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptGL.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptGL"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptGL"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptGL.ListLabel}"
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
            For Each itemRow As TreeRow In Me.Treemanager.Treetable.Rows
                If itemRow.Index > 1 Then
                    'Item.DocDate
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col0")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    ' doccode
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col1")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    If CStr(itemRow.Tag) = "summary" Then dpi.LineStyle = 2
                    dpiColl.Add(dpi)

                    'refcode
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col2")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'accountcode
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col3"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col3")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'account name
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col4"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col4")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'refdocnote
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col5"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col5")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    If CStr(itemRow.Tag) = "summary" Then dpi.LineStyle = 2
                    dpiColl.Add(dpi)

                    'debit
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col6"
                    If itemRow.Level = 0 Or CStr(itemRow.Tag) = "summary" Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col6")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    If CStr(itemRow.Tag) = "summary" Then dpi.LineStyle = 2
                    dpiColl.Add(dpi)

                    'credit
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col7"
                    If itemRow.Level = 0 Or CStr(itemRow.Tag) = "summary" Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col7")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    If CStr(itemRow.Tag) = "summary" Then dpi.LineStyle = 2
                    dpiColl.Add(dpi)

                    'cc
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col8"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col8")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'supplier
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col9"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col9")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    'status
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col10"
                    If itemRow.Level = 0 Then
                        dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                    dpi.Value = itemRow("col10")
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Level = itemRow.Level
                    dpiColl.Add(dpi)

                    i += 1
                End If
            Next

            Return dpiColl
        End Function
#End Region

    End Class
End Namespace

