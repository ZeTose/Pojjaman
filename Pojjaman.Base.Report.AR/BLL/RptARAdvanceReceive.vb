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
    Public Class RptARAdvanceReceive
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
                lkg.Rows.HeaderCount = 2
                lkg.Rows.FrozenCount = 2
            Else
                lkg.Rows.HeaderCount = 3
                lkg.Rows.FrozenCount = 3
            End If

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

                Dim docId As Integer = drh.GetValue(Of Integer)("advr_id")
                Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

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
            m_showDetailInGrid = CInt(Me.Filters(8).Value)
            CreateHeader()
            PopulateData()
        End Sub
        Private Sub CreateHeader()
            If Me.m_treemanager Is Nothing Then
                Return
            End If

            Dim indent As String = Space(3)

            ' Level 0
            Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
            tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CustID}")  '"รหัสลูกหนี้หนี้"
            tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CustName}")  '"ชื่อลูกหนี้"
            ' Level 1
            tr = Me.m_treemanager.Treetable.Childs.Add
            tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocCode}")  '"เลขที่เอกสาร"
            tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocDate}")  '"วันที่เอกสาร"
            tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLCode}")  '"เลขที่ GL"
            tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.VatInvoice}")  '"เลขที่ใบกำกับ"
            tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCCode}")  '"รหัส Cost Center"
            tr("col5") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCName}")  '"ชื่อ Cost Center"
            tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.BeforeTax}")  '"ยอดก่อนภาษี"
            tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.TaxAmount}") '"เงินภาษี"
            tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.AfterTax}")  '"รวม"
            tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.OpenningBalance}")  '"ยอดคงเหลือยกมา"
            tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.RefDocAmount}")  '"ยอดหักมัดจำ"
            tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Remaining}")  '"ยอดคงเหลือ"
            tr("col12") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Status}")  '"สถานะ"
            tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}")  '"หมายเหตุ"
            If m_showDetailInGrid = 1 Then
                ' Level 2
                tr = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocCode}")  '"เลขที่เอกสาร"
                tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocDate}")  '"วันที่เอกสาร"
                tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLCode}")  '"เลขที่ GL"
                tr("col5") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocType}")  '"ประเภทเอกสาร"
                tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.AdvanceAmount}")  '"ยอดหัก" 
                tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Remain}")  '"คงเหลือ" 
                tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}")  '"หมายเหตุ"

            End If
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim dt1 As DataTable = Me.DataSet.Tables(1)

            If dt.Rows.Count = 0 Then
                Return
            End If

            Dim indent As String = Space(3)

            Dim trSupplier As TreeRow
            Dim trDoc As TreeRow
            Dim trDetail As TreeRow

            Dim advanceRemain As Decimal = 0
            Dim totalAdvanceAmount As Decimal = 0

            Dim totalBeforeTax As Decimal = 0
            Dim totalTaxAmount As Decimal = 0
            Dim totalAfterTax As Decimal = 0
            Dim totalAdvance As Decimal = 0
            Dim totalBalance As Decimal = 0

            Dim currentSupplier As String = ""

            Dim rowIndex As Integer = 0
            m_hashData = New Hashtable

            For Each supplierRow As DataRow In dt.Rows
                If currentSupplier <> supplierRow("customercode").ToString Then
                    currentSupplier = supplierRow("customercode").ToString

                    trSupplier = Me.Treemanager.Treetable.Childs.Add
                    trSupplier.Tag = "Font.Bold"
                    If Not supplierRow.IsNull("customercode") Then
                        trSupplier("col0") = supplierRow("customercode").ToString
                    End If
                    If Not supplierRow.IsNull("customername") Then
                        trSupplier("col1") = supplierRow("customername").ToString
                    End If

                    For Each advanceRow As DataRow In dt.Select("cust_Id=" & supplierRow("cust_Id").ToString)
                        trDoc = trSupplier.Childs.Add
                        rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDoc) + 1
                        m_hashData(rowIndex) = advanceRow
                        If Not advanceRow.IsNull("doccode") Then
                            trDoc("col0") = indent & advanceRow("doccode").ToString
                        End If
                        If Not advanceRow.IsNull("docdate") Then
                            If IsDate(advanceRow("docdate")) Then
                                trDoc("col1") = CDate(advanceRow("docdate")).ToShortDateString
                            End If
                        End If
                        If Not advanceRow.IsNull("AdvRglCode") Then
                            trDoc("col2") = indent & advanceRow("AdvRglCode").ToString
                        End If
                        If Not advanceRow.IsNull("VatInvoice") Then
                            trDoc("col3") = indent & advanceRow("VatInvoice").ToString
                        End If
                        If Not advanceRow.IsNull("CostCenterCode") Then
                            trDoc("col4") = indent & advanceRow("CostCenterCode").ToString
                        End If
                        If Not advanceRow.IsNull("CostCenterName") Then
                            trDoc("col5") = indent & advanceRow("CostCenterName").ToString
                        End If
                        If Not advanceRow.IsNull("beforetax") Then
                            trDoc("col6") = Configuration.FormatToString(CDec(advanceRow("beforetax")), DigitConfig.Price)
                            totalBeforeTax += CDec(advanceRow("beforetax"))
                        End If
                        If Not advanceRow.IsNull("taxamt") Then
                            trDoc("col7") = Configuration.FormatToString(CDec(advanceRow("taxamt")), DigitConfig.Price)
                            totalTaxAmount += CDec(advanceRow("taxamt"))
                        End If
                        If Not advanceRow.IsNull("aftertax") Then
                            trDoc("col8") = Configuration.FormatToString(CDec(advanceRow("aftertax")), DigitConfig.Price)
                            totalAfterTax += CDec(advanceRow("aftertax"))
                        End If
                        If Not advanceRow.IsNull("openningbalanceremain") Then
                            trDoc("col9") = Configuration.FormatToString(CDec(advanceRow("openningbalanceremain")), DigitConfig.Price)
                            advanceRemain = CDec(advanceRow("openningbalanceremain"))
                        End If
                        If Not advanceRow.IsNull("status") Then
                            If CInt(advanceRow("status")) = 0 Then
                                advanceRow("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Canceled}")  '"ถูกยกเลิก"
                            End If
                        End If
                        If Not advanceRow.IsNull("AdvRglNote") Then
                            trDoc("col13") = indent & advanceRow("AdvRglNote").ToString
                        End If

                        totalAdvanceAmount = 0

                        For Each detailRow As DataRow In dt1.Select("id=" & advanceRow("advr_id").ToString)
                            If Not detailRow.IsNull("currentamount") Then
                                totalAdvanceAmount += CDec(detailRow("currentamount"))
                                totalAdvance += CDec(detailRow("currentamount"))
                                advanceRemain -= CDec(detailRow("currentamount"))
                            End If

                            If m_showDetailInGrid <> 0 Then
                                trDetail = trDoc.Childs.Add
                                rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDetail) + 1
                                m_hashData(rowIndex) = detailRow
                                If Not detailRow.IsNull("refcode") Then
                                    trDetail("col0") = indent & indent & detailRow("refcode").ToString
                                End If
                                If Not detailRow.IsNull("refdate") Then
                                    If IsDate(detailRow("refdate")) Then
                                        trDetail("col1") = CDate(detailRow("refdate")).ToShortDateString
                                    End If
                                    If Not detailRow.IsNull("refGlCode") Then
                                        trDetail("col2") = indent & indent & detailRow("refGlCode").ToString
                                    End If
                                End If
                                If Not detailRow.IsNull("entity_description") Then
                                    trDetail("col5") = indent & indent & detailRow("entity_description").ToString
                                End If
                                If Not detailRow.IsNull("currentamount") Then
                                    trDetail("col10") = Configuration.FormatToString(CDec(detailRow("currentamount")), DigitConfig.Price)
                                End If
                                trDetail("col11") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)
                                If Not detailRow.IsNull("refGlNote") Then
                                    trDetail("col13") = detailRow("refGlNote").ToString
                                End If
                            End If
                        Next

                        trDoc("col10") = Configuration.FormatToString(totalAdvanceAmount, DigitConfig.Price)
                        trDoc("col11") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)

                        totalBalance += advanceRemain

                        trDoc.State = RowExpandState.Expanded

                    Next

                    trSupplier.State = RowExpandState.Expanded

                End If

            Next

            trSupplier = Me.m_treemanager.Treetable.Childs.Add
            trSupplier.Tag = "Font.Bold"
            trSupplier("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Total}") '"รวม"
            trSupplier("col6") = Configuration.FormatToString(totalBeforeTax, DigitConfig.Price)
            trSupplier("col7") = Configuration.FormatToString(totalTaxAmount, DigitConfig.Price)
            trSupplier("col8") = Configuration.FormatToString(totalAfterTax, DigitConfig.Price)

            trSupplier("col10") = Configuration.FormatToString(totalAdvance, DigitConfig.Price)
            trSupplier("col11") = Configuration.FormatToString(totalBalance, DigitConfig.Price)

            Return

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
            myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))

            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            Dim iCol As Integer = 13 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

            widths.Add(120)
            widths.Add(200)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(150)
            widths.Add(120)
            widths.Add(100)
            widths.Add(100)
            widths.Add(120)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(300)

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
                        Case 0, 1, 2, 3, 4, 5, 12, 13
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
                Return "RptARAdvanceReceive"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptARAdvanceReceive"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptARAdvanceReceive"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.ListLabel}"
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
            Return "RptARAdvanceReceive"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptARAdvanceReceive"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'docdate start
            dpi = New DocPrintingItem
            dpi.Mapping = "docdatestart"
            If Not IsDBNull(Filters(0).Value) Then
                dpi.Value = CDate((Filters(0).Value)).ToShortDateString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'docdate end
            dpi = New DocPrintingItem
            dpi.Mapping = "docdateend"
            If Not IsDBNull(Filters(1).Value) Then
                dpi.Value = CDate((Filters(1).Value)).ToShortDateString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'customer start
            dpi = New DocPrintingItem
            dpi.Mapping = "customerstart"
            If Not IsDBNull(Filters(2).Value) Then
                dpi.Value = CStr((Filters(2).Value)).ToString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'customer end
            dpi = New DocPrintingItem
            dpi.Mapping = "customerend"
            If Not IsDBNull(Filters(3).Value) Then
                dpi.Value = CStr((Filters(3).Value)).ToString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenterStart
            dpi = New DocPrintingItem
            dpi.Mapping = "costcenterstart"
            If Not IsDBNull(Filters(8).Value) Then
                dpi.Value = CStr((Filters(8).Value)).ToString
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            ''CostCenterEnd ยกเลิก
            'dpi = New DocPrintingItem
            'dpi.Mapping = "costcenterend"
            'If Not IsDBNull(Filters(8).Value) Then
            'dpi.Value = CStr((Filters(8).Value)).ToString
            'End If
            'dpi.DataType = "System.String"
            'dpiColl.Add(dpi)

            'IncludeChildren
            dpi = New DocPrintingItem
            dpi.Mapping = "IncludeChildren"
            If Not IsDBNull(Filters(4).Value) Then
                If CType(Filters(4).Value, Boolean) Then
                    dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARFilterSubPanel.chkIncludeChildren}")
                End If
            End If
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Dim n As Integer = 0
            Dim i As Integer = 0
            Dim StartRow As Integer = 0
            Dim fn As Font
            If Me.m_showDetailInGrid = 0 Then
                StartRow = 3
            Else
                StartRow = 4
            End If

            For rowIndex As Integer = StartRow To m_grid.RowCount
                fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

                If Me.m_showDetailInGrid <> 0 Then
                    If Not CType(Me.Treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
                        fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                    End If
                End If

                For colIndex As Integer = 1 To Me.m_grid.ColCount
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col" & colIndex.ToString
                    dpi.Value = m_grid(rowIndex, colIndex).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpi.Font = fn
                    dpiColl.Add(dpi)
                Next

                If rowIndex = m_grid.RowCount Then
                    'SumText
                    dpi = New DocPrintingItem
                    dpi.Mapping = "SumText"
                    dpi.Value = m_grid(rowIndex, 4).CellValue
                    dpi.DataType = "System.String"
                    dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
                    dpiColl.Add(dpi)

                    'SumBeforeTax
                    dpi = New DocPrintingItem
                    dpi.Mapping = "SumBeforeTax"
                    dpi.Value = m_grid(rowIndex, 5).CellValue
                    dpi.DataType = "System.String"
                    dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
                    dpiColl.Add(dpi)

                    'SumTaxAmount
                    dpi = New DocPrintingItem
                    dpi.Mapping = "SumTaxAmount"
                    dpi.Value = m_grid(rowIndex, 6).CellValue
                    dpi.DataType = "System.String"
                    dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
                    dpiColl.Add(dpi)

                    'SumAfterTax
                    dpi = New DocPrintingItem
                    dpi.Mapping = "SumAfterTax"
                    dpi.Value = m_grid(rowIndex, 7).CellValue
                    dpi.DataType = "System.String"
                    dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
                    dpiColl.Add(dpi)

                    'SumAdvanceAmount
                    dpi = New DocPrintingItem
                    dpi.Mapping = "SumAdvanceAmount"
                    dpi.Value = m_grid(rowIndex, 9).CellValue
                    dpi.DataType = "System.String"
                    dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
                    dpiColl.Add(dpi)

                    'SumBalance
                    dpi = New DocPrintingItem
                    dpi.Mapping = "SumBalance"
                    dpi.Value = m_grid(rowIndex, 10).CellValue
                    dpi.DataType = "System.String"
                    dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
                    dpiColl.Add(dpi)
                End If

                n += 1
            Next


            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

