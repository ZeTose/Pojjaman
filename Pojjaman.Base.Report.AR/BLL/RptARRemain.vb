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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptARRemain
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
            If Me.Filters(7).Value = 0 Then
                lkg.Rows.HeaderCount = 1
                lkg.Rows.FrozenCount = 1
            Else
                lkg.Rows.HeaderCount = 2
                lkg.Rows.FrozenCount = 2
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

                Dim docId As Integer = drh.GetValue(Of Integer)("ID")
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
            CreateHeader()
            PopulateData()
        End Sub
        Private Sub CreateHeader()
            If Me.m_treemanager Is Nothing Then
                Return
            End If

            Dim indent As String = Space(3)

            Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
            If CInt(Me.Filters(7).Value) = 0 Then
                ' Level 1.
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerCode}") '"รหัสลูกหนี้"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerName}") '"ชื่อลูกหนี้"
                tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpenningBalance}") '"ยอดยกมา"
                tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Debt}") '"ยอดซื้อเชื่อ"
                tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.SCN}") '"ยอดลดหนี้"
                tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Receive}") '"ยอดรับชำระ"
                tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalance}") '"ยอดยกไป"

                tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpeningBalanceRetention}") '"ยอด Retention ยกมา"
                tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Retention}") '"ยอด Retention"
                tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ReceiveRetention}") '"ยอดรับชำระ Retention"
                tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalanceRetention}") '"ยอด Retention ยกไป"
                tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.BillRetention}") '"วางบิล Retentionลด"   ${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}

                'tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"

            Else
                ' Level 1.
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerCode}") '"รหัสลูกหนี้"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerName}") '"ชื่อลูกหนี้"
                tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpenningBalance}") '"ยอดยกมา"
                tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Debt}") '"ยอดซื้อเชื่อ"
                tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.SCN}") '"ยอดลดหนี้"
                tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Receive}") '"ยอดรับชำระ"
                tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalance}") '"ยอดยกไป"

                tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpeningBalanceRetention}") '"ยอด Retention ยกมา"
                tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Retention}") '"ยอด Retention"
                tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ReceiveRetention}") '"ยอดรับชำระ Retention"
                tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalanceRetention}") '"ยอด Retention ยกไป"
                tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.BillRetention}") '"วางบิล Retentionลด"   ${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}


                ' Level 2.
                tr = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DocType}") '"ประเภทเอกสาร"
                tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DNDocNo}") '"เลขที่เอกสาร"
                tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DocDate}") '"วันที่เอกสาร"
                tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrCode}") '"เลขที่ใบสำคัญ"
                tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.CostCenter}") '"เลขที่ใบสำคัญ"
                tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"
                tr("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.VatCode}") '"ใบกำกับภาษี"

            End If
        End Sub
        Private Sub PopulateData()

            Dim ShowDetail As Boolean = False
            Dim ShowAll As Boolean = False
            Dim ShowAR As Boolean = False
            Dim ShowRetention As Boolean = False

            ShowDetail = CBool(Me.Filters(7).Value)
            ShowAll = CBool(Me.Filters(8).Value)
            ShowAR = CBool(Me.Filters(15).Value)
            ShowRetention = CBool(Me.Filters(16).Value)

            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim dt2 As DataTable

            If ShowDetail Then
                dt2 = Me.DataSet.Tables(1)
                CalRetentionBalance()
            End If

            If dt.Rows.Count = 0 Then
                Return
            End If


            Dim indent As String = Space(3)

            Dim trCustomer As TreeRow
            Dim trDetail As TreeRow

            Dim sumOpenningBalance As Decimal = 0
            Dim sumAmount As Decimal = 0
            Dim sumSCNAmount As Decimal = 0
            Dim sumReceiveAmount As Decimal = 0
            Dim sumEndingBalance As Decimal = 0
            Dim sumOPBRetention As Decimal = 0
            Dim sumRetention As Decimal = 0
            Dim sumDecreaseRetention As Decimal = 0
            Dim sumEndingBalanceRetention As Decimal = 0
            Dim sumReceiveRetention As Decimal = 0
            Dim sumBillRetention As Decimal = 0

            Dim totalOpenningBalance As Decimal = 0
            Dim totalAmount As Decimal = 0
            Dim totalSCNAmount As Decimal = 0
            Dim totalReceiveAmount As Decimal = 0
            Dim totalEndingBalance As Decimal = 0
            Dim totalOPBRetention As Decimal = 0
            Dim totalRetention As Decimal = 0
            Dim totalDecreaseRetention As Decimal = 0
            Dim totalEndingBalanceRetention As Decimal = 0
            Dim totalReceiveRetention As Decimal = 0
            Dim totalBillRetention As Decimal = 0

            Dim DocKey As String = ""
            Dim DocBal As DocumentBalance
            Dim HasARMove As Boolean = False
            Dim HasRetentionMove As Boolean = False
            Dim DocEndBalance As Decimal = 0
            Dim DocOpenRetentionBalance As Decimal = 0
            Dim DocEndRetentionBalance As Decimal = 0

            Dim rowIndex As Integer = 0
            m_hashData = New Hashtable

            For Each supplierRow As DataRow In dt.Rows

                trCustomer = Me.Treemanager.Treetable.Childs.Add
                If ShowDetail Then
                    trCustomer.Tag = "Font.Bold"
                End If

                If Not supplierRow.IsNull("cust_code") Then
                    trCustomer("col0") = supplierRow("cust_code").ToString
                End If
                If Not supplierRow.IsNull("cust_name") Then
                    trCustomer("col1") = supplierRow("cust_name").ToString
                End If

                If Not ShowDetail Then
                    If Not supplierRow.IsNull("OpeningBalance") Then
                        trCustomer("col4") = Configuration.FormatToString(CDec(supplierRow("OpeningBalance")), DigitConfig.Price)
                        totalOpenningBalance += CDec(supplierRow("OpeningBalance"))
                    End If
                    If Not supplierRow.IsNull("Amount") Then
                        If CDec(supplierRow("Amount")) > 0 Then
                            trCustomer("col5") = Configuration.FormatToString(CDec(supplierRow("Amount")), DigitConfig.Price)
                            totalAmount += CDec(supplierRow("Amount"))
                        End If
                    End If
                    If Not supplierRow.IsNull("SCN") Then
                        If CDec(supplierRow("SCN")) > 0 Then
                            trCustomer("col6") = Configuration.FormatToString(CDec(supplierRow("SCN")), DigitConfig.Price)
                            totalSCNAmount += CDec(supplierRow("SCN"))
                        End If
                    End If
                    If Not supplierRow.IsNull("ReceiveSelection") Then
                        If CDec(supplierRow("ReceiveSelection")) > 0 Then
                            trCustomer("col7") = Configuration.FormatToString(CDec(supplierRow("ReceiveSelection")), DigitConfig.Price)
                            totalReceiveAmount += CDec(supplierRow("ReceiveSelection"))
                        End If
                    End If
                    If Not supplierRow.IsNull("EndingBalance") Then
                        trCustomer("col8") = Configuration.FormatToString(CDec(supplierRow("EndingBalance")), DigitConfig.Price)
                        totalEndingBalance += CDec(supplierRow("EndingBalance"))
                    End If

                    '============================================-Retention===================================================

                    If Not supplierRow.IsNull("OPBRetention") Then
                        trCustomer("col9") = Configuration.FormatToString(CDec(supplierRow("OPBRetention")), DigitConfig.Price)
                        totalOPBRetention += CDec(supplierRow("OPBRetention"))
                    End If

                    If Not supplierRow.IsNull("Retention") Then
                        trCustomer("col10") = Configuration.FormatToString(CDec(supplierRow("Retention")), DigitConfig.Price)
                        totalRetention += CDec(supplierRow("Retention"))
                    End If

                    If Not supplierRow.IsNull("DecreaseRetention") Then
                        trCustomer("col11") = Configuration.FormatToString(CDec(supplierRow("DecreaseRetention")), DigitConfig.Price)
                        totalDecreaseRetention += CDec(supplierRow("DecreaseRetention"))
                    End If

                    If Not supplierRow.IsNull("EndingBalanceRetention") Then
                        trCustomer("col12") = Configuration.FormatToString(CDec(supplierRow("EndingBalanceRetention")), DigitConfig.Price)
                        totalEndingBalanceRetention += CDec(supplierRow("EndingBalanceRetention"))
                    End If

                    If Not supplierRow.IsNull("BillRetention") Then
                        trCustomer("col13") = Configuration.FormatToString(CDec(supplierRow("BillRetention")), DigitConfig.Price)
                        totalBillRetention += CDec(supplierRow("BillRetention"))
                    End If

                    '=========================================================================================================


                End If


                If ShowDetail Then

                    trCustomer.State = RowExpandState.Expanded

                    sumOpenningBalance = 0
                    sumAmount = 0
                    sumSCNAmount = 0
                    sumReceiveAmount = 0
                    sumEndingBalance = 0
                    sumOPBRetention = 0
                    sumRetention = 0
                    sumDecreaseRetention = 0
                    sumEndingBalanceRetention = 0
                    sumReceiveRetention = 0
                    sumBillRetention = 0

                    For Each detailRow As DataRow In dt2.Select("Customer =" & supplierRow("Cust_ID").ToString)
                        Dim deh As New DataRowHelper(detailRow)

                        DocKey = deh.GetValue(Of String)("ID", "-") & "|" & deh.GetValue(Of String)("DocType", "-") & "|" & deh.GetValue(Of String)("CCID", "-")
                        DocBal = Nothing
                        If DocumentBalanceList.ContainsKey(DocKey) Then
                            DocBal = DocumentBalanceList(DocKey)
                            DocEndBalance = DocBal.EndingBalance
                            DocOpenRetentionBalance = DocBal.OBalanceRetention
                            DocEndRetentionBalance = DocBal.BalanceRetention
                            HasARMove = DocBal.HasARMove
                            HasRetentionMove = DocBal.HasRetentionMove
                        Else
                            DocEndBalance = 0
                            DocOpenRetentionBalance = 0
                            DocEndRetentionBalance = 0
                            HasARMove = False
                            HasRetentionMove = False
                        End If

                        If _
                            (((ShowAll) And (ShowAR) And (ShowRetention)) And ((HasARMove) Or (HasRetentionMove))) _
                            OrElse
                            (((ShowAll) And (ShowAR) And Not (ShowRetention)) And ((DocEndBalance <> 0) Or (HasRetentionMove))) _
                            OrElse
                            (((ShowAll) And Not (ShowAR) And (ShowRetention)) And ((HasARMove) Or (DocEndRetentionBalance <> 0))) _
                            OrElse
                            ((Not (ShowAll) And (ShowAR) And Not (ShowRetention)) And (DocEndBalance <> 0)) _
                            OrElse
                            ((Not (ShowAll) And Not (ShowAR) And (ShowRetention)) And (DocEndRetentionBalance <> 0)) _
                            OrElse
                            ((Not (ShowAll) And (ShowAR) And (ShowRetention)) And ((DocEndBalance <> 0) Or (DocEndRetentionBalance <> 0))) _
                        Then

                            If Not trCustomer Is Nothing Then
                                trDetail = trCustomer.Childs.Add

                                rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDetail) + 1
                                m_hashData(rowIndex) = detailRow

                                trDetail("col0") = indent & deh.GetValue(Of String)("entity_description", "-")
                                trDetail("col1") = indent & deh.GetValue(Of String)("doccode", "-")
                                trDetail("col2") = indent & deh.GetValue(Of Date)("docdate", Now.Date).ToShortDateString
                                trDetail("col3") = indent & deh.GetValue(Of String)("glcode", "-")
                                trDetail("col4") = indent & deh.GetValue(Of String)("CostCenter")
                                trDetail("col5") = Configuration.FormatToString(deh.GetValue(Of Decimal)("OpeningBalance"), DigitConfig.Price)

                                If DocBal.OpeningBalance <> 0 Then
                                    sumOpenningBalance += DocBal.OpeningBalance
                                    totalOpenningBalance += DocBal.OpeningBalance
                                End If

                                If DocBal.Amount <> 0 Then
                                    trDetail("col6") = Configuration.FormatToString(DocBal.Amount, DigitConfig.Price)
                                    sumAmount += DocBal.Amount
                                    totalAmount += DocBal.Amount
                                End If

                                If DocBal.SCN <> 0 Then
                                    trDetail("col7") = Configuration.FormatToString(DocBal.SCN, DigitConfig.Price)
                                    sumSCNAmount += DocBal.SCN
                                    totalSCNAmount += DocBal.SCN
                                End If

                                If DocBal.ReceiveSelection <> 0 Then
                                    trDetail("col8") = Configuration.FormatToString(DocBal.ReceiveSelection, DigitConfig.Price)
                                    sumReceiveAmount += DocBal.ReceiveSelection
                                    totalReceiveAmount += DocBal.ReceiveSelection
                                End If

                                If DocBal.EndingBalance <> 0 Then
                                    trDetail("col9") = Configuration.FormatToString(DocBal.EndingBalance, DigitConfig.Price)
                                    sumEndingBalance += DocBal.EndingBalance
                                    totalEndingBalance += DocBal.EndingBalance
                                End If

                                '============================================-Retention===================================================


                                trDetail("col10") = Configuration.FormatToString(DocBal.OBalanceRetention, DigitConfig.Price)
                                sumOPBRetention += DocBal.OBalanceRetention
                                totalOPBRetention += DocBal.OBalanceRetention

                                trDetail("col11") = Configuration.FormatToString(DocBal.Retention, DigitConfig.Price)
                                sumRetention += DocBal.Retention
                                totalRetention += DocBal.Retention

                                trDetail("col12") = Configuration.FormatToString(DocBal.DecreaseRetention, DigitConfig.Price)
                                sumDecreaseRetention += DocBal.DecreaseRetention
                                totalDecreaseRetention += DocBal.DecreaseRetention

                                trDetail("col13") = Configuration.FormatToString(DocBal.BalanceRetention, DigitConfig.Price)
                                sumEndingBalanceRetention += DocBal.BalanceRetention
                                totalEndingBalanceRetention += DocBal.BalanceRetention

                                trDetail("col14") = Configuration.FormatToString(DocBal.BillRetention, DigitConfig.Price)
                                sumBillRetention += DocBal.BillRetention
                                totalBillRetention += DocBal.BillRetention

                                '=========================================================================================================

                                trDetail("col15") = detailRow("Glnote").ToString

                                trDetail("col16") = detailRow("vatcode").ToString

                            End If

                        End If


                    Next

                    If sumOpenningBalance <> 0 Then
                        trCustomer("col5") = Configuration.FormatToString(sumOpenningBalance, DigitConfig.Price)
                    End If

                    If sumAmount <> 0 Then
                        trCustomer("col6") = Configuration.FormatToString(sumAmount, DigitConfig.Price)
                    End If

                    If sumSCNAmount <> 0 Then
                        trCustomer("col7") = Configuration.FormatToString(sumSCNAmount, DigitConfig.Price)
                    End If

                    If sumReceiveAmount <> 0 Then
                        trCustomer("col8") = Configuration.FormatToString(sumReceiveAmount, DigitConfig.Price)
                    End If

                    trCustomer("col9") = Configuration.FormatToString(sumEndingBalance, DigitConfig.Price)

                    '=============================================Retention===================================================

                    trCustomer("col10") = Configuration.FormatToString(sumOPBRetention, DigitConfig.Price)

                    trCustomer("col11") = Configuration.FormatToString(sumRetention, DigitConfig.Price)

                    trCustomer("col12") = Configuration.FormatToString(sumDecreaseRetention, DigitConfig.Price)

                    trCustomer("col13") = Configuration.FormatToString(sumEndingBalanceRetention, DigitConfig.Price)

                    trCustomer("col14") = Configuration.FormatToString(sumBillRetention, DigitConfig.Price)

                    '=========================================================================================================


                End If

            Next

            trCustomer = Me.Treemanager.Treetable.Childs.Add

            If Not ShowDetail Then

                trCustomer("col4") = Configuration.FormatToString(totalOpenningBalance, DigitConfig.Price)

                If totalAmount <> 0 Then
                    trCustomer("col5") = Configuration.FormatToString(totalAmount, DigitConfig.Price)
                End If

                If totalSCNAmount <> 0 Then
                    trCustomer("col6") = Configuration.FormatToString(totalSCNAmount, DigitConfig.Price)
                End If

                If totalReceiveAmount <> 0 Then
                    trCustomer("col7") = Configuration.FormatToString(totalReceiveAmount, DigitConfig.Price)
                End If

                trCustomer("col8") = Configuration.FormatToString(totalEndingBalance, DigitConfig.Price)


                '============================================-Retention===================================================

                If totalOPBRetention <> 0 Then
                    trCustomer("col9") = Configuration.FormatToString(totalOPBRetention, DigitConfig.Price)
                End If

                If totalRetention <> 0 Then
                    trCustomer("col10") = Configuration.FormatToString(totalRetention, DigitConfig.Price)
                End If

                If totalDecreaseRetention <> 0 Then
                    trCustomer("col11") = Configuration.FormatToString(totalDecreaseRetention, DigitConfig.Price)
                End If

                trCustomer("col12") = Configuration.FormatToString(totalEndingBalanceRetention, DigitConfig.Price)

                If totalReceiveRetention <> 0 Then
                    trCustomer("col13") = Configuration.FormatToString(totalBillRetention, DigitConfig.Price)
                End If

                '=========================================================================================================


            Else


                trCustomer.Tag = "Font.Bold"

                trCustomer("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Total}")  'รวม

                trCustomer("col5") = Configuration.FormatToString(totalOpenningBalance, DigitConfig.Price)

                If totalAmount <> 0 Then
                    trCustomer("col6") = Configuration.FormatToString(totalAmount, DigitConfig.Price)
                End If

                If totalSCNAmount <> 0 Then
                    trCustomer("col7") = Configuration.FormatToString(totalSCNAmount, DigitConfig.Price)
                End If

                If totalReceiveAmount <> 0 Then
                    trCustomer("col8") = Configuration.FormatToString(totalReceiveAmount, DigitConfig.Price)
                End If

                trCustomer("col9") = Configuration.FormatToString(totalEndingBalance, DigitConfig.Price)


                '============================================-Retention===================================================

                If totalOPBRetention <> 0 Then
                    trCustomer("col10") = Configuration.FormatToString(totalOPBRetention, DigitConfig.Price)
                End If

                If totalRetention <> 0 Then
                    trCustomer("col11") = Configuration.FormatToString(totalRetention, DigitConfig.Price)
                End If

                If totalDecreaseRetention <> 0 Then
                    trCustomer("col12") = Configuration.FormatToString(totalDecreaseRetention, DigitConfig.Price)
                End If

                trCustomer("col13") = Configuration.FormatToString(totalEndingBalanceRetention, DigitConfig.Price)

                If totalReceiveRetention <> 0 Then
                    trCustomer("col14") = Configuration.FormatToString(totalBillRetention, DigitConfig.Price)
                End If

                '=========================================================================================================


            End If

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
            myDatatable.Columns.Add(New DataColumn("col14", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col15", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col16", GetType(String)))

            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            Dim iCol As Integer = 16 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

            widths.Add(90)
            widths.Add(180)
            widths.Add(80 * CInt(Me.Filters(7).Value))
            widths.Add(95 * CInt(Me.Filters(7).Value))
            widths.Add(150)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(105 * CInt(Me.Filters(7).Value))
            widths.Add(180 * CInt(Me.Filters(7).Value))
            widths.Add(180 * CInt(Me.Filters(7).Value))

            For i As Integer = 0 To iCol
                If i = 1 Then
                    If CInt(Me.Filters(7).Value) <> 0 Then
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
                        Dim cs As New TreeTextColumn(1, True, Color.White)
                        cs.MappingName = "col" & i
                        cs.HeaderText = ""
                        cs.Width = CInt(widths(i))
                        cs.NullText = ""
                        cs.Alignment = HorizontalAlignment.Left
                        cs.ReadOnly = True
                        cs.Format = "s"
                        AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                        dst.GridColumnStyles.Add(cs)
                    End If
                Else
                    Dim cs As New TreeTextColumn(i, True, Color.Khaki)
                    cs.MappingName = "col" & i
                    cs.HeaderText = ""
                    cs.Width = CInt(widths(i))
                    cs.NullText = ""
                    cs.Alignment = HorizontalAlignment.Left
                    If CInt(Me.Filters(7).Value) <> 0 Then
                        Select Case i
                            Case 0, 1, 2, 3, 4, 15, 16
                                cs.Alignment = HorizontalAlignment.Left
                                cs.DataAlignment = HorizontalAlignment.Left
                                cs.Format = "s"
                            Case Else
                                cs.Alignment = HorizontalAlignment.Right
                                cs.DataAlignment = HorizontalAlignment.Right
                                cs.Format = "d"
                        End Select
                    Else
                        Select Case i
                            Case 0, 1
                                cs.Alignment = HorizontalAlignment.Left
                                cs.DataAlignment = HorizontalAlignment.Left
                                cs.Format = "s"
                            Case Else
                                cs.Alignment = HorizontalAlignment.Right
                                cs.DataAlignment = HorizontalAlignment.Right
                                cs.Format = "d"
                        End Select
                    End If

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

        Private RetentionPMAList As Dictionary(Of String, RetentionPMA)
        Private RetentionBalanceList As Dictionary(Of String, RetentionBalance)
        Private DocumentBalanceList As Dictionary(Of String, DocumentBalance)

        Private Sub CalRetentionBalance()

            Dim RPMA As RetentionPMA
            Dim RBalance As RetentionBalance
            Dim DocBalance As DocumentBalance
            Dim dt As DataTable

            RetentionPMAList = New Dictionary(Of String, RetentionPMA)
            RetentionBalanceList = New Dictionary(Of String, RetentionBalance)
            DocumentBalanceList = New Dictionary(Of String, DocumentBalance)

            dt = Me.DataSet.Tables(2)

            For Each PMARow As DataRow In dt.Rows
                RPMA = New RetentionPMA(PMARow)
                RetentionPMAList.Add(RPMA.pma.ToString & "|" & RPMA.CCID.ToString, RPMA)
            Next

            dt = Me.DataSet.Tables(3)

            For Each DocRow As DataRow In dt.Rows
                RBalance = New RetentionBalance(DocRow)
                RetentionBalanceList.Add(RBalance.ID.ToString & "|" & RBalance.DocType.ToString & "|" & RBalance.pma.ToString & "|" & RBalance.CCID.ToString, RBalance)
            Next

            Dim Currentpma As String

            Currentpma = "0|0"

            For Each DocRetention As KeyValuePair(Of String, RetentionBalance) In RetentionBalanceList
                If RetentionPMAList.ContainsKey(DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString) Then

                    If Currentpma <> (DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString) Then
                        Currentpma = DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString
                        RPMA = RetentionPMAList(Currentpma)
                    End If

                    If RPMA.OBalanceRetention <= DocRetention.Value.ORetention Then
                        DocRetention.Value.OBalanceRetention = DocRetention.Value.ORetention - RPMA.OBalanceRetention
                        RPMA.OBalanceRetention = 0
                    Else
                        DocRetention.Value.OBalanceRetention = 0
                        RPMA.OBalanceRetention = RPMA.OBalanceRetention - DocRetention.Value.ORetention
                    End If

                End If
            Next

            Currentpma = "0|0"

            For Each DocRetention As KeyValuePair(Of String, RetentionBalance) In RetentionBalanceList
                If RetentionPMAList.ContainsKey(DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString) Then

                    If Currentpma <> (DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString) Then
                        Currentpma = DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString
                        RPMA = RetentionPMAList(Currentpma)
                    End If

                    If (RPMA.OBalanceRetention + RPMA.BalanceRetention) <= (DocRetention.Value.OBalanceRetention + DocRetention.Value.Retention) Then
                        DocRetention.Value.BalanceRetention = (DocRetention.Value.OBalanceRetention + DocRetention.Value.Retention) - RPMA.BalanceRetention
                        RPMA.OBalanceRetention = 0
                        RPMA.BalanceRetention = 0
                    Else
                        DocRetention.Value.BalanceRetention = 0
                        If RPMA.OBalanceRetention >= (DocRetention.Value.OBalanceRetention + DocRetention.Value.Retention) Then
                            RPMA.OBalanceRetention = RPMA.OBalanceRetention - (DocRetention.Value.OBalanceRetention + DocRetention.Value.Retention)
                        Else
                            RPMA.BalanceRetention = (RPMA.OBalanceRetention + RPMA.BalanceRetention) - (DocRetention.Value.OBalanceRetention + DocRetention.Value.Retention)
                            RPMA.OBalanceRetention = 0
                        End If

                    End If

                End If
            Next

            For Each DocRetention As KeyValuePair(Of String, RetentionBalance) In RetentionBalanceList
                If DocumentBalanceList.ContainsKey(DocRetention.Value.ID.ToString & "|" & DocRetention.Value.DocType.ToString & "|" & DocRetention.Value.CCID.ToString) Then

                    DocBalance = DocumentBalanceList(DocRetention.Value.ID.ToString & "|" & DocRetention.Value.DocType.ToString & "|" & DocRetention.Value.CCID.ToString)

                    DocBalance.OpeningBalance += DocRetention.Value.OpeningBalance
                    DocBalance.Amount += DocRetention.Value.Amount
                    DocBalance.SCN += DocRetention.Value.SCN
                    DocBalance.ReceiveSelection += DocRetention.Value.ReceiveSelection
                    DocBalance.EndingBalance += DocRetention.Value.EndingBalance

                    DocBalance.ORetention += DocRetention.Value.ORetention
                    DocBalance.OBalanceRetention += DocRetention.Value.OBalanceRetention

                    DocBalance.Retention += DocRetention.Value.Retention
                    DocBalance.DecreaseRetention += DocRetention.Value.DecreaseRetention
                    DocBalance.BalanceRetention += DocRetention.Value.BalanceRetention
                    DocBalance.BillRetention += DocRetention.Value.BillRetention

                Else

                    DocBalance = New DocumentBalance
                    DocBalance.ID = DocRetention.Value.ID
                    DocBalance.DocType = DocRetention.Value.DocType
                    DocBalance.CCID = DocRetention.Value.CCID

                    DocBalance.OpeningBalance = DocRetention.Value.OpeningBalance
                    DocBalance.Amount = DocRetention.Value.Amount
                    DocBalance.SCN = DocRetention.Value.SCN
                    DocBalance.ReceiveSelection = DocRetention.Value.ReceiveSelection
                    DocBalance.EndingBalance = DocRetention.Value.EndingBalance

                    DocBalance.ORetention = DocRetention.Value.ORetention
                    DocBalance.OBalanceRetention = DocRetention.Value.OBalanceRetention

                    DocBalance.Retention = DocRetention.Value.Retention
                    DocBalance.DecreaseRetention = DocRetention.Value.DecreaseRetention
                    DocBalance.BalanceRetention = DocRetention.Value.BalanceRetention
                    DocBalance.BillRetention = DocRetention.Value.BillRetention

                    DocumentBalanceList.Add(DocRetention.Value.ID.ToString & "|" & DocRetention.Value.DocType.ToString & "|" & DocRetention.Value.CCID.ToString, DocBalance)

                End If
            Next

        End Sub

#End Region

#Region "Shared"
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptARRemain"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptARRemain"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptARRemain"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ListLabel}"
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
                Select Case fixDpi.Mapping.ToLower
                    Case "month", "year", "today"
                        dpiColl.Add(fixDpi)
                    Case "docdatestart", "docdateend"
                        dpiColl.Add(fixDpi)
                    Case "customerstart", "customerend"
                        dpiColl.Add(fixDpi)
                    Case "costcenterstart", "costcenterend"
                        dpiColl.Add(fixDpi)
                End Select
            Next

            Dim startRow As Integer = 2
            Dim i As Integer = 0
            Dim fn As Font

            If CInt(Me.Filters(7).Value) <> 0 Then
                startRow = 3
            End If

            For rowIndex As Integer = startRow To m_grid.RowCount
                If CType(Me.Treemanager.Treetable.Rows(i), TreeRow) Is Nothing Then
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                Else
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If
                For colIndex As Integer = 1 To m_grid.ColCount

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col" & (colIndex - 1).ToString
                    dpi.Value = m_grid(rowIndex, colIndex).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Font = fn
                    dpiColl.Add(dpi)
                Next
                i += 1
            Next

            Return dpiColl
        End Function
#End Region

        Private Class DocumentBalance

            Private _ID As Integer
            Public Property ID As Integer
                Get
                    Return _ID
                End Get
                Set(value As Integer)
                    _ID = value
                End Set
            End Property

            Private _DocType As Integer
            Public Property DocType As Integer
                Get
                    Return _DocType
                End Get
                Set(value As Integer)
                    _DocType = value
                End Set
            End Property

            Private _CCID As Integer
            Public Property CCID As Integer
                Get
                    Return _CCID
                End Get
                Set(value As Integer)
                    _CCID = value
                End Set
            End Property

#Region "AR Property"

            Private _OpeningBalance As Decimal
            Public Property OpeningBalance As Decimal
                Get
                    Return _OpeningBalance
                End Get
                Set(value As Decimal)
                    _OpeningBalance = value
                End Set
            End Property

            Private _Amount As Decimal
            Public Property Amount As Decimal
                Get
                    Return _Amount
                End Get
                Set(value As Decimal)
                    _Amount = value
                End Set
            End Property

            Private _SCN As Decimal
            Public Property SCN As Decimal
                Get
                    Return _SCN
                End Get
                Set(value As Decimal)
                    _SCN = value
                End Set
            End Property

            Private _ReceiveSelection As Decimal
            Public Property ReceiveSelection As Decimal
                Get
                    Return _ReceiveSelection
                End Get
                Set(value As Decimal)
                    _ReceiveSelection = value
                End Set
            End Property

            Private _EndingBalance As Decimal
            Public Property EndingBalance As Decimal
                Get
                    Return _EndingBalance
                End Get
                Set(value As Decimal)
                    _EndingBalance = value
                End Set
            End Property

            Public ReadOnly Property HasARMove As Boolean
                Get

                    If (Math.Abs(_OpeningBalance) + Math.Abs(_Amount) + Math.Abs(_SCN) + Math.Abs(_ReceiveSelection)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property
#End Region

#Region "Retention Property"
            Private _ORetention As Decimal
            Public Property ORetention As Decimal
                Get
                    Return _ORetention
                End Get
                Set(value As Decimal)
                    _ORetention = value
                End Set
            End Property

            Private _ODecreaseRetention As Decimal
            Public Property ODecreaseRetention As Decimal
                Get
                    Return _ODecreaseRetention
                End Get
                Set(value As Decimal)
                    _ODecreaseRetention = value
                End Set
            End Property

            Private _OBalanceRetention As Decimal
            Public Property OBalanceRetention As Decimal
                Get
                    Return _OBalanceRetention
                End Get
                Set(value As Decimal)
                    _OBalanceRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _BalanceRetention As Decimal
            Public Property BalanceRetention As Decimal
                Get
                    Return _BalanceRetention
                End Get
                Set(value As Decimal)
                    _BalanceRetention = value
                End Set
            End Property

            Private _BillRetention As Decimal
            Public Property BillRetention As Decimal
                Get
                    Return _BillRetention
                End Get
                Set(value As Decimal)
                    _BillRetention = value
                End Set
            End Property


            Public ReadOnly Property HasRetentionMove As Boolean
                Get

                    If (Math.Abs(_OBalanceRetention) + Math.Abs(_Retention) + Math.Abs(_DecreaseRetention)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property

#End Region

        End Class

        Private Class RetentionBalance

            Public Sub New(DocRow As DataRow)

                _ID = CInt(DocRow("ID"))
                _DocType = CInt(DocRow("DocType"))
                _pma = CInt(DocRow("pma"))
                _CCID = CInt(DocRow("CCID"))

                If Not DocRow.IsNull("OpeningBalance") Then
                    _OpeningBalance = CDec(DocRow("OpeningBalance"))
                Else
                    _OpeningBalance = 0
                End If

                If Not DocRow.IsNull("Amount") Then
                    _Amount = CDec(DocRow("Amount"))
                Else
                    _Amount = 0
                End If

                If Not DocRow.IsNull("SCN") Then
                    _SCN = CDec(DocRow("SCN"))
                Else
                    _SCN = 0
                End If

                If Not DocRow.IsNull("ReceiveSelection") Then
                    _ReceiveSelection = CDec(DocRow("ReceiveSelection"))
                Else
                    _ReceiveSelection = 0
                End If

                If Not DocRow.IsNull("EndingBalance") Then
                    _EndingBalance = CDec(DocRow("EndingBalance"))
                Else
                    _EndingBalance = 0
                End If


                If Not DocRow.IsNull("OPBRetention") Then
                    _ORetention = CDec(DocRow("OPBRetention"))
                Else
                    _ORetention = 0
                End If

                'If Not DocRow.IsNull("OPBDecreaseRetention") Then
                '    _ODecreaseRetention = CDec(DocRow("OPBDecreaseRetention"))
                'Else
                '    _ODecreaseRetention = 0
                'End If

                _OBalanceRetention = 0

                If Not DocRow.IsNull("Retention") Then
                    _Retention = CDec(DocRow("Retention"))
                Else
                    _Retention = 0
                End If

                If Not DocRow.IsNull("DecreaseRetention") Then
                    _DecreaseRetention = CDec(DocRow("DecreaseRetention"))
                Else
                    _DecreaseRetention = 0
                End If

                _BalanceRetention = 0

                If Not DocRow.IsNull("BillRetention") Then
                    _BillRetention = CDec(DocRow("BillRetention"))
                Else
                    _BillRetention = 0
                End If

            End Sub

            Private _ID As Integer
            Public Property ID As Integer
                Get
                    Return _ID
                End Get
                Set(value As Integer)
                    _ID = value
                End Set
            End Property

            Private _DocType As Integer
            Public Property DocType As Integer
                Get
                    Return _DocType
                End Get
                Set(value As Integer)
                    _DocType = value
                End Set
            End Property

            Private _pma As Integer
            Public Property pma As Integer
                Get
                    Return _pma
                End Get
                Set(value As Integer)
                    _pma = value
                End Set
            End Property

            Private _CCID As Integer
            Public Property CCID As Integer
                Get
                    Return _CCID
                End Get
                Set(value As Integer)
                    _CCID = value
                End Set
            End Property

#Region "AR Property"

            Private _OpeningBalance As Decimal
            Public Property OpeningBalance As Decimal
                Get
                    Return _OpeningBalance
                End Get
                Set(value As Decimal)
                    _OpeningBalance = value
                End Set
            End Property

            Private _Amount As Decimal
            Public Property Amount As Decimal
                Get
                    Return _Amount
                End Get
                Set(value As Decimal)
                    _Amount = value
                End Set
            End Property

            Private _SCN As Decimal
            Public Property SCN As Decimal
                Get
                    Return _SCN
                End Get
                Set(value As Decimal)
                    _SCN = value
                End Set
            End Property

            Private _ReceiveSelection As Decimal
            Public Property ReceiveSelection As Decimal
                Get
                    Return _ReceiveSelection
                End Get
                Set(value As Decimal)
                    _ReceiveSelection = value
                End Set
            End Property

            Private _EndingBalance As Decimal
            Public Property EndingBalance As Decimal
                Get
                    Return _EndingBalance
                End Get
                Set(value As Decimal)
                    _EndingBalance = value
                End Set
            End Property

            Public ReadOnly Property HasARMove As Boolean
                Get

                    If (Math.Abs(_OpeningBalance) + Math.Abs(_Amount) + Math.Abs(_SCN) + Math.Abs(_ReceiveSelection)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property
#End Region

#Region "Retention Property"
            Private _ORetention As Decimal
            Public Property ORetention As Decimal
                Get
                    Return _ORetention
                End Get
                Set(value As Decimal)
                    _ORetention = value
                End Set
            End Property

            'Private _ODecreaseRetention As Decimal
            'Public Property ODecreaseRetention As Decimal
            '    Get
            '        Return _ODecreaseRetention
            '    End Get
            '    Set(value As Decimal)
            '        _ODecreaseRetention = value
            '    End Set
            'End Property

            Private _OBalanceRetention As Decimal
            Public Property OBalanceRetention As Decimal
                Get
                    Return _OBalanceRetention
                End Get
                Set(value As Decimal)
                    _OBalanceRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _BalanceRetention As Decimal
            Public Property BalanceRetention As Decimal
                Get
                    Return _BalanceRetention
                End Get
                Set(value As Decimal)
                    _BalanceRetention = value
                End Set
            End Property

            Private _BillRetention As Decimal
            Public Property BillRetention As Decimal
                Get
                    Return _BillRetention
                End Get
                Set(value As Decimal)
                    _BillRetention = value
                End Set
            End Property

            Public ReadOnly Property HasRetentionMove As Boolean
                Get

                    If (Math.Abs(_OBalanceRetention) + Math.Abs(_Retention) + Math.Abs(_DecreaseRetention)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property

#End Region



        End Class

        Private Class RetentionPMA

            Public Sub New(PMARow As DataRow)

                _pma = CInt(PMARow("pma"))
                _CCID = CInt(PMARow("CCID"))

                _ORetention = CDec(PMARow("OPBRetention"))
                _OBalanceRetention = _ODecreaseRetention

                _Retention = CDec(PMARow("Retention"))
                _DecreaseRetention = CDec(PMARow("DecreaseRetention"))
                _BalanceRetention = _DecreaseRetention

            End Sub

            Private _pma As Integer
            Public Property pma As Integer
                Get
                    Return _pma
                End Get
                Set(value As Integer)
                    _pma = value
                End Set
            End Property

            Private _CCID As Integer
            Public Property CCID As Integer
                Get
                    Return _CCID
                End Get
                Set(value As Integer)
                    _CCID = value
                End Set
            End Property

            Private _ORetention As Decimal
            Public Property ORetention As Decimal
                Get
                    Return _ORetention
                End Get
                Set(value As Decimal)
                    _ORetention = value
                End Set
            End Property

            Private _ODecreaseRetention As Decimal
            Public Property ODecreaseRetention As Decimal
                Get
                    Return _ODecreaseRetention
                End Get
                Set(value As Decimal)
                    _ODecreaseRetention = value
                End Set
            End Property

            Private _OBalanceRetention As Decimal
            Public Property OBalanceRetention As Decimal
                Get
                    Return _OBalanceRetention
                End Get
                Set(value As Decimal)
                    _OBalanceRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _BalanceRetention As Decimal
            Public Property BalanceRetention As Decimal
                Get
                    Return _BalanceRetention
                End Get
                Set(value As Decimal)
                    _BalanceRetention = value
                End Set
            End Property

        End Class


    End Class
End Namespace

