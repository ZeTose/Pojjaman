Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.DataAccessLayer

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptVatNotDue
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private m_showDetailInGrid As Integer
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
            If m_showDetailInGrid = 0 Then
                lkg.Rows.HeaderCount = 1
                lkg.Rows.FrozenCount = 1
            Else
                lkg.Rows.HeaderCount = 2
                lkg.Rows.FrozenCount = 2
            End If

            lkg.Refresh()
        End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
            Dim dr As DataRow = CType(m_hashData(e.RowIndex), DataRow)
            If dr Is Nothing Then
                Return
            End If

            Dim drh As New DataRowHelper(dr)

            Dim docId As Integer = drh.GetValue(Of Integer)("DocID")
            Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

            Trace.WriteLine(docId.ToString & ":" & docType.ToString)

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If
        End Sub
        Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
            Me.m_treemanager = tm
            Me.m_treemanager.Treetable.Clear()
            m_showDetailInGrid = CInt(Me.Filters(8).Value)
            CreateHeader()
            PopulateData()
        End Sub
        Private Sub CreateHeader()
            If Me.m_treemanager Is Nothing Then
                Return
            End If

            Dim indent As String = Space(3)

            If m_showDetailInGrid = 0 Then
                ' Level 1
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocCode}") '"เลขที่เอกสาร"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocDate}") '"วันที่เอกสาร"
                tr("col2") = "Supplier"
                tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.VatAmt}") '"จำนวนเงินภาษี"
                tr("col4") = "stock_taxbase"
                tr("col5") = "stock_taxAmt"
            Else
                ' Level 1
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocCode}") '"เลขที่เอกสาร"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DocDate}") '"วันที่เอกสาร"
                tr("col2") = "entity_description"
                tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.VatAmt}") '"จำนวนเงินภาษี"
                tr("col4") = "stock_taxbase"
                tr("col5") = "stock_taxAmt"

                ' Level 2
                tr = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.RefDocCode}") '"เลขที่เอกสารอ้างอิงดึงไปทำกรอกใบกำกับ"
                tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.RefDocDate}") ' "วันที่เอกสารอ้างอิงดึงไปทำกรอกฯ"
                tr("col2") = indent & "entity_description"
                tr("col3") = indent & "Supplier"
                tr("col4") = indent & "vat_taxbase"
                tr("col5") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.RefVatAmt}") '"จำนวนเงินภาษี"
                tr("col6") = indent & "dueVat_base"
                tr("col7") = indent & "dueVat_amt"
            End If
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            If dt.Rows.Count = 0 Then
                Return
            End If

            Dim indent As String = Space(3)

            Dim trStockCode As TreeRow
            Dim trPaysDoc As TreeRow

            Dim currentStockCode As String = ""

            Dim rowIndex As Integer = 0
            m_hashData = New Hashtable

            For Each stockRow As DataRow In dt.Rows
                'If currentStockCode <> stockRow("stock_code").ToString Then
                '    currentStockCode = stockRow("stock_code").ToString
                trStockCode = Me.Treemanager.Treetable.Childs.Add
                trStockCode.Tag = "Font.Bold"

                trStockCode.Tag = stockRow

                If Not stockRow.IsNull("stock_code") Then
                    trStockCode("col0") = stockRow("stock_code").ToString
                End If
                If Not stockRow.IsNull("stock_docdate") Then
                    trStockCode("col1") = CDate(stockRow("stock_docdate")).ToShortDateString
                End If
                If Not stockRow.IsNull("entity_description") Then
                    trStockCode("col2") = stockRow("entity_description").ToString
                End If
                If Not stockRow.IsNull("Supplier") Then
                    trStockCode("col3") = stockRow("Supplier").ToString
                End If
                If Not stockRow.IsNull("stock_taxbase") Then
                    trStockCode("col4") = Configuration.FormatToString(CDec(stockRow("stock_taxbase")), DigitConfig.Price)
                End If
                If Not stockRow.IsNull("stock_taxAmt") Then
                    trStockCode("col5") = Configuration.FormatToString(CDec(stockRow("stock_taxAmt")), DigitConfig.Price)
                End If

                If m_showDetailInGrid <> 0 Then
                    Dim dt1 As DataTable = Me.DataSet.Tables(1)
                    trStockCode.State = RowExpandState.Expanded
                    For Each paysRow As DataRow In dt1.Select("stock_id=" & stockRow("stock_id").ToString)
                        Dim deh As New DataRowHelper(paysRow)
                        If Not trStockCode Is Nothing Then
                            trPaysDoc = trStockCode.Childs.Add
                            trPaysDoc.Tag = paysRow
                            If Not paysRow.IsNull("pays_code") Then
                                trPaysDoc("col0") = indent & paysRow("pays_code").ToString
                            End If
                            If Not paysRow.IsNull("pays_docdate") Then
                                If IsDate(paysRow("pays_docdate")) Then
                                    trPaysDoc("col1") = indent & CDate(paysRow("pays_docdate")).ToShortDateString
                                End If
                            End If
                            If Not paysRow.IsNull("entity_description") Then
                                trPaysDoc("col2") = indent & paysRow("entity_description").ToString
                            End If
                            If Not paysRow.IsNull("Supplier") Then
                                trPaysDoc("col3") = indent & paysRow("Supplier").ToString
                            End If
                            If Not paysRow.IsNull("vat_taxbase") Then
                                trPaysDoc("col4") = indent & Configuration.FormatToString(CDec(paysRow("vat_taxbase")), DigitConfig.Price)
                                'totalBeforeTax += CDec(paysRow("beforetax"))
                            End If
                            If Not paysRow.IsNull("vat_amt") Then
                                trPaysDoc("col5") = indent & Configuration.FormatToString(CDec(paysRow("vat_amt")), DigitConfig.Price)
                                'totalTaxAmount += CDec(paysRow("taxamt"))
                            End If
                            If Not paysRow.IsNull("dueVat_base") Then
                                trPaysDoc("col6") = indent & Configuration.FormatToString(CDec(paysRow("dueVat_base")), DigitConfig.Price)
                                'totalAfterTax += CDec(paysRow("aftertax"))
                            End If
                            If Not paysRow.IsNull("dueVat_amt") Then
                                trPaysDoc("col7") = indent & Configuration.FormatToString(CDec(paysRow("dueVat_amt")), DigitConfig.Price)
                                'advanceRemain = CDec(paysRow("openningbalanceremain"))
                            End If
                        End If
                    Next
                End If
            Next
            Dim lineNumber As Integer = 1
            For Each tr As TreeRow In Me.m_treemanager.Treetable.Rows
                If Not tr.Tag Is Nothing AndAlso TypeOf tr.Tag Is DataRow Then
                    m_hashData(lineNumber) = CType(tr.Tag, DataRow)
                End If

                lineNumber += 1
            Next
        End Sub
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
            'myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
            'myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
            'myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
            'myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
            'myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
            'myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))

            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            Dim iCol As Integer = 7 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

            widths.Add(120)
            widths.Add(200)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(150)
            widths.Add(120)
            widths.Add(100)
            'widths.Add(100)
            'widths.Add(120)
            'widths.Add(100)
            'widths.Add(100)
            'widths.Add(100)
            'widths.Add(300)

            For i As Integer = 0 To iCol
                If i = 1 Then
                    'If m_showDetailInGrid <> 0 Then
                    Dim cs As New PlusMinusTreeTextColumn
                    cs.MappingName = "col" & i
                    cs.HeaderText = ""
                    cs.Width = CInt(widths(i))
                    cs.NullText = ""
                    cs.Alignment = HorizontalAlignment.Left
                    cs.ReadOnly = True
                    cs.Format = "s"
                    AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                    dst.GridColumnStyles.Add(cs)
                Else
                    Dim cs As New TreeTextColumn(i, True, Color.Khaki)
                    cs.MappingName = "col" & i
                    cs.HeaderText = ""
                    cs.Width = CInt(widths(i))
                    cs.NullText = ""
                    cs.Alignment = HorizontalAlignment.Left
                    'If Me.m_showDetailInGrid <> 0 Then
                    Select Case i
                        Case 0, 1, 2, 3,
                            cs.Alignment = HorizontalAlignment.Left
                            cs.DataAlignment = HorizontalAlignment.Left
                            cs.Format = "s"
                        Case Else
                            cs.Alignment = HorizontalAlignment.Right
                            cs.DataAlignment = HorizontalAlignment.Right
                            cs.Format = "d"
                    End Select

                    cs.ReadOnly = True

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
                Return "RptVatNotDue"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptVatNotDue"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptVatNotDue"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptVatNotDue.ListLabel}"
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
                dpiColl.Add(fixDpi)
            Next

            Dim i As Integer = 0
            Dim SumTaxAmount As Decimal = 0
            Dim SumBeforeTax As Decimal = 0
            Dim SumAfterTax As Decimal = 0
            For Each itemRow As DataRow In Me.DataSet.Tables(0).Rows
                'Item.LineNumber
                dpi = New DocPrintingItem
                dpi.Mapping = "linenumber"
                dpi.Value = i + 1
                dpi.DataType = "System.Sting"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.DocDate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.DocDate"
                dpi.Value = itemRow("docdate")
                dpi.DataType = "System.DateTime"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Invoice
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Invoice"
                dpi.Value = itemRow("invoice")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.DocCode
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.DocCode"
                dpi.Value = itemRow("docCode")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.VatRunNumber
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.vatrunnumber"
                dpi.Value = itemRow("vatrunnumber")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.RelatedDoc
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.RelatedDoc"
                dpi.Value = itemRow("RelatedDoc")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.SubmitalDate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.SubmitalDate"
                dpi.Value = itemRow("SubmitalDate")
                dpi.DataType = "System.DateTime"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Supplier
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Supplier"
                dpi.Value = itemRow("supplier")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.BeforeTax
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.BeforeTax"
                dpi.Value = itemRow("beforetax")
                dpi.DataType = "System.Decimal"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                If IsNumeric(itemRow("beforetax")) Then
                    SumBeforeTax += Configuration.Format(CDec(itemRow("beforetax")), DigitConfig.Price)
                End If

                'Item.TaxAmount
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.TaxAmount"
                dpi.Value = itemRow("taxamt")
                dpi.DataType = "System.Decimal"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                If IsNumeric(itemRow("taxamt")) Then
                    SumTaxAmount += Configuration.Format(CDec(itemRow("taxamt")), DigitConfig.Price)
                End If

                'Item.AfterTax
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.AfterTax"
                dpi.Value = itemRow("aftertax")
                dpi.DataType = "System.Decimal"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                If IsNumeric(itemRow("aftertax")) Then
                    SumAfterTax += CDec(itemRow("aftertax"))
                End If

                'Item.Invoice
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Invoice"
                dpi.Value = itemRow("Invoice")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.GroupName
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.GroupName"
                dpi.Value = itemRow("GroupName")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.CostcenterName
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.CostcenterName"
                dpi.Value = itemRow("CostcenterName")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                i += 1
            Next

            'SumText
            dpi = New DocPrintingItem
            dpi.Mapping = "SumText"
            dpi.Value = "รวม"
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol5
            dpi = New DocPrintingItem
            dpi.Mapping = "SumCol5"
            dpi.Value = Configuration.FormatToString(SumBeforeTax, DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol6
            dpi = New DocPrintingItem
            dpi.Mapping = "SumCol6"
            dpi.Value = Configuration.FormatToString(SumTaxAmount, DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumBeforeTax
            dpi = New DocPrintingItem
            dpi.Mapping = "SumAfterTax"
            dpi.Value = Configuration.FormatToString(SumAfterTax, DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

