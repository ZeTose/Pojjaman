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
    Public Class RptCCExpenseSummary
        Inherits Report

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private MasterTotal As Decimal = 0
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
            Dim indent As String = Space(3)
            Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
            tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.CostCenterId}") '"รหัส Cost Center"
            tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.CostCenterName}") '"ชื่อ Cost Center"

            tr = Me.m_treemanager.Treetable.Childs.Add
            tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.DocId}") '"รหัสเอกสาร"
            tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.Date}") '"วันที่"
            tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.SupplierId}") '"รหัสผู้ขาย"
            tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.SupplierName}") '"ชื่อผู้ขาย"
            tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.DocType}") '"ประเภทเอกสาร"
            tr("col5") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.Definition}") '"คำอธิบาย"
            tr("col6") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.Cost}") '"มูลค่า"
            tr("col7") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.CostRemaining}") '"ยอดค้างชำระ"

        End Sub
        Private m_maxDataLevel As Integer = 1
        Private m_maxLevel As Integer = 1
        Private Sub PopulateData()
            If Me.m_treemanager Is Nothing Then
                Return
            End If
            Dim dsh As New DataSetHelper
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentCC As String = ""
            Dim currentDocCode As String = ""

            Dim DocTr As TreeRow
            Dim CCTr As TreeRow
            Dim indent As String = Space(3)
            Dim SumCC As Int32 = 0
            Dim SumAmount As Decimal = 0
            Dim tmpAmount As Decimal = 0
            Dim SumPaid As Decimal = 0
            Dim tmpPaid As Decimal = 0
            Dim SumRemain As Decimal = 0
            Dim tmpRemain As Decimal = 0
            MasterTotal = 0

            For Each row As DataRow In dt.Rows
                If row("CCId").ToString <> currentCC Then
                    SumCC += 1
                    If currentCC <> "" Then
                        DocTr = Me.m_treemanager.Treetable.Childs.Add
                        DocTr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.Total}") '"รวม "
                        DocTr("col6") = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
                        DocTr("col7") = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
                        MasterTotal += tmpRemain
                        tmpAmount = 0
                        tmpRemain = 0
                    End If
                    CCTr = Me.m_treemanager.Treetable.Childs.Add
                    CCTr("col0") = row("CCCode")
                    CCTr("col1") = row("CCName")
                    currentCC = row("CCId").ToString
                    currentDocCode = ""
                    'DocTr.Tag = CInt(row("supplierid"))

                    CCTr.State = RowExpandState.Expanded

                End If
                If row("DocCode").ToString <> currentDocCode Then
                    DocTr = CCTr.Childs.Add
                    If Not row.IsNull("DocCode") Then
                        DocTr("col0") = indent & row("DocCode").ToString
                    End If
                    If IsDate(row("DocDate")) Then
                        DocTr("col1") = indent & CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("SupplierCode") Then
                        DocTr("col2") = indent & row("SupplierCode").ToString
                    End If
                    If Not row.IsNull("SupplierName") Then
                        DocTr("col3") = indent & row("SupplierName").ToString
                    End If
                    If Not row.IsNull("Type") Then
                        DocTr("col4") = indent & row("Type").ToString
                    End If
                    If Not row.IsNull("Note") Then
                        DocTr("col5") = indent & row("Note").ToString
                    End If
                    If IsNumeric(row("Amount")) Then
                        DocTr("col6") = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                        tmpAmount += CDec(row("Amount"))
                        SumAmount += CDec(row("Amount"))
                    End If
                    If IsNumeric(row("Remain")) Then
                        DocTr("col7") = Configuration.FormatToString(CDec(row("Remain")), DigitConfig.Price)
                        tmpRemain += CDec(row("Remain"))
                        SumRemain += CDec(row("Remain"))
                    End If
                    currentDocCode = row("DocCode").ToString
                End If
            Next

            DocTr = Me.m_treemanager.Treetable.Childs.Add
            DocTr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.Total}") '"รวม "
            DocTr("col6") = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
            DocTr("col7") = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
            MasterTotal += tmpRemain

            DocTr = Me.m_treemanager.Treetable.Childs.Add
            DocTr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.Sum}") '"รวมทั้งหมด "
            DocTr("col6") = Configuration.FormatToString(SumAmount, DigitConfig.Price)
            DocTr("col7") = Configuration.FormatToString(SumRemain, DigitConfig.Price)
            DocTr.State = RowExpandState.Expanded
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
            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            widths.Add(200)
            widths.Add(200)
            widths.Add(150)
            widths.Add(150)
            widths.Add(150)
            widths.Add(150)
            widths.Add(150)
            widths.Add(150)

            Dim alignments As New ArrayList
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Center)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Center)
            alignments.Add(HorizontalAlignment.Left)
            alignments.Add(HorizontalAlignment.Right)
            alignments.Add(HorizontalAlignment.Right)

            For i As Integer = 0 To 7
                Dim cs As New TreeTextColumn(i, True, Color.Khaki)
                cs.MappingName = "col" & i
                cs.HeaderText = ""
                cs.Width = CInt(widths(i))
                cs.NullText = ""
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = CType(alignments(i), HorizontalAlignment)
                cs.ReadOnly = True
                cs.Format = "d"
                AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
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
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptCCExpenseSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptCCExpenseSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptCCExpenseSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCCExpenseSummary.ListLabel}"
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
            Return "RptCCExpenseSummary"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptCCExpenseSummary"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            Dim i As Integer = 0
            For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
                If i > 1 Then
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col0"
                    dpi.Value = itemRow("col0")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col1"
                    dpi.Value = itemRow("col1")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col2"
                    dpi.Value = itemRow("col2")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col3"
                    dpi.Value = itemRow("col3")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col4"
                    dpi.Value = itemRow("col4")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col5"
                    dpi.Value = itemRow("col5")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col6"
                    dpi.Value = itemRow("col6")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col7"
                    dpi.Value = itemRow("col7")
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpiColl.Add(dpi)
                    n += 1
                End If
                i += 1
            Next

            Dim SumAmt As Decimal = 0
            Dim SumRemain As Decimal = 0
            'For Each childRow As TreeRow In Me.Treemanager.Treetable.Childs
            '    If childRow.Childs.Count > 0 Then
            '        Dim grandChildRow As TreeRow = childRow.LastChild
            '        SumAmt += CDec(grandChildRow("col6"))
            '        SumRemain += CDec(grandChildRow("col7"))
            '    End If
            'Next

            'SumText
            dpi = New DocPrintingItem
            dpi.Mapping = "SumText"
            dpi.Value = "รวม"
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol6
            dpi = New DocPrintingItem
            dpi.Mapping = "sumCol6"
            dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol7
            dpi = New DocPrintingItem
            dpi.Mapping = "sumCol7"
            dpi.Value = Configuration.FormatToString(MasterTotal, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

