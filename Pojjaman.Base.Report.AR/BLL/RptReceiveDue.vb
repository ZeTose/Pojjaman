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
    Public Class RptReceiveDue
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private m_showPeriod As Integer
        Private m_showByBillDate As Integer
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
                If m_showByBillDate = 0 Or m_showByBillDate = 3 Or m_showByBillDate = 6 Then
                    lkg.Rows.HeaderCount = 3
                    lkg.Rows.FrozenCount = 3
                Else
                    lkg.Rows.HeaderCount = 2
                    lkg.Rows.FrozenCount = 2
                End If

            End If
            lkg.Refresh()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
            Dim dr As DataRow = CType(m_hashData(e.RowIndex), DataRow)
            If dr Is Nothing Then
                Return
            End If

            Dim drh As New DataRowHelper(dr)

            Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
            Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

            Trace.WriteLine(docId.ToString & ":" & docType.ToString)

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If
        End Sub

        Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
            Me.m_treemanager = tm
            Me.m_treemanager.Treetable.Clear()
            m_showPeriod = CInt(Me.DataSet.Tables(0).Rows(0).Item("ShowPeriod"))
            m_showByBillDate = CInt(Me.DataSet.Tables(0).Rows(0)("DueDateBy"))
            m_showDetailInGrid = CInt(Me.DataSet.Tables(0).Rows(0)("ShowDetail"))
            CreateHeader()
            PopulateData()
        End Sub
        Private Sub CreateHeader()
            If Me.m_treemanager Is Nothing Then
                Return
            End If

            Dim indent As String = Space(3)

            If m_showPeriod = 0 Then
                ' Level 1.
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                If m_showDetailInGrid <> 0 Then
                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArID}")         '"รหัสลูกหนี้"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArName}")       '"ชื่อลูกหนี้"

                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.NotInRange}")   '"ไม่อยู่ในช่วง"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range0_7}")     '"ช่วง 0-7 วัน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range8_14}")    '"ช่วง 8-14 วัน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range15_21}")   '"ช่วง 15-21 วัน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range22_28}")   '"ช่วง 22-28 วัน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Exceed_28}")    '"เกิน 28 วัน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Total}")        '"รวม"
                Else
                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArID}")         '"รหัสลูกหนี้"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArName}")       '"ชื่อลูกหนี้"

                    tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.NotInRange}")   '"ไม่อยู่ในช่วง"
                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range0_7}")     '"ช่วง 0-7 วัน"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range8_14}")    '"ช่วง 8-14 วัน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range15_21}")   '"ช่วง 15-21 วัน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range22_28}")   '"ช่วง 22-28 วัน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Exceed_28}")    '"เกิน 28 วัน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Total}")        '"รวม"
                End If


                ' Level 2,3.
                If m_showDetailInGrid <> 0 Then

                    If m_showByBillDate = 0 Or m_showByBillDate = 3 Or m_showByBillDate = 6 Then
                        tr = Me.m_treemanager.Treetable.Childs.Add
                        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillDueDate}")             '"วันที่ครบกำหนดชำระ"  
                        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillCode}")                '"เลขที่ใบวางบิล"
                        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillDocDate}")             '"วันที่เอกสาร"  
                    End If

                    tr = Me.m_treemanager.Treetable.Childs.Add
                    tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockDueDate}")            '"วันที่ครบกำหนดชำระ"  
                    tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockCode}")               '"เลขที่เอกสาร"               
                    tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockDocDate}")             '"วันที่เอกสาร"  

                End If

            ElseIf m_showPeriod = 1 Then
                ' Level 1.
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                If m_showDetailInGrid <> 0 Then
                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArID}")             '"รหัสลูกหนี้"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArName}")           '"ชื่อลูกหนี้"

                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range1M}")          '"ช่วง 1 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range2M}")          '"ช่วง 2 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range3M}")          '"ช่วง 3 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range4M}")          '"ช่วง 4 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range5M}")          '"ช่วง 5 เดือน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range6M}")          '"ช่วง 6 เดือน"
                    tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.OverRange6M}")      '"เกิน 6 เดือน"
                    tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Total}")           '"รวม"
                Else
                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArID}")             '"รหัสลูกหนี้"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArName}")           '"ชื่อลูกหนี้"

                    tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range1M}")          '"ช่วง 1 เดือน"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range2M}")          '"ช่วง 2 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range3M}")          '"ช่วง 3 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range4M}")          '"ช่วง 4 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range5M}")          '"ช่วง 5 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range6M}")          '"ช่วง 6 เดือน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.OverRange6M}")      '"เกิน 6 เดือน"
                    tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Total}")           '"รวม"
                End If


                ' Level 2,3.
                If m_showDetailInGrid <> 0 Then

                    If m_showByBillDate = 0 Or m_showByBillDate = 3 Or m_showByBillDate = 6 Then
                        tr = Me.m_treemanager.Treetable.Childs.Add
                        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillDueDate}")             '"วันที่ครบกำหนดชำระ"  
                        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillCode}")                '"เลขที่ใบวางบิล"
                        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillDocDate}")             '"วันที่เอกสาร"  
                    End If

                    tr = Me.m_treemanager.Treetable.Childs.Add
                    tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockDueDate}")            '"วันที่ครบกำหนดชำระ"  
                    tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockCode}")               '"เลขที่เอกสาร"               
                    tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockDocDate}")             '"วันที่เอกสาร"  

                End If

            ElseIf m_showPeriod = 2 Then
                ' Level 1.
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                If m_showDetailInGrid <> 0 Then
                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArID}")             '"รหัสลูกหนี้"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArName}")           '"ชื่อลูกหนี้"

                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range1Q}")          '"ช่วง 3 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range2Q}")          '"ช่วง 6 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range3Q}")          '"ช่วง 9 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range4Q}")          '"ช่วง 12 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.OverRange4Q}")      '"เกิน 12 เดือน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Total}")            '"รวม"
                Else
                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArID}")             '"รหัสลูกหนี้"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.ArName}")           '"ชื่อลูกหนี้"

                    tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range1Q}")          '"ช่วง 3 เดือน"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range2Q}")          '"ช่วง 6 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range3Q}")          '"ช่วง 9 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Range4Q}")          '"ช่วง 12 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.OverRange4Q}")      '"เกิน 12 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.Total}")            '"รวม"
                End If


                ' Level 2,3.
                If m_showDetailInGrid <> 0 Then

                    If m_showByBillDate = 0 Or m_showByBillDate = 3 Or m_showByBillDate = 6 Then
                        tr = Me.m_treemanager.Treetable.Childs.Add
                        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillDueDate}")             '"วันที่ครบกำหนดชำระ"  
                        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillCode}")                '"เลขที่ใบวางบิล"
                        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.BillDocDate}")             '"วันที่เอกสาร"  
                    End If

                    tr = Me.m_treemanager.Treetable.Childs.Add
                    tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockDueDate}")            '"วันที่ครบกำหนดชำระ"  
                    tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockCode}")               '"เลขที่เอกสาร"               
                    tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAging.StockDocDate}")             '"วันที่เอกสาร"  

                End If

            End If
        End Sub
        Private Sub PopulateData()

            Dim dtCustomer As DataTable = Me.DataSet.Tables(1)
            Dim dtBillSale As DataTable = Me.DataSet.Tables(2)
            Dim dtBillMileStone As DataTable = Me.DataSet.Tables(3)
            Dim dtDocStock As DataTable = Me.DataSet.Tables(4)
            Dim dtDocSale As DataTable = Me.DataSet.Tables(5)
            Dim dtDocMileStone As DataTable = Me.DataSet.Tables(6)

            m_hashData = New Hashtable

            If dtCustomer.Rows.Count = 0 Then
                Return
            End If

            Dim indent As String = Space(3)

            Dim trCustomer As TreeRow
            Dim trDocStock As TreeRow
            Dim trBillSale As TreeRow
            Dim trDocSale As TreeRow
            Dim trBillMileStone As TreeRow
            Dim trDocMileStone As TreeRow

            Dim sumCol(10) As Decimal
            Dim sumTotalAmount As Decimal = 0
            For i As Integer = 0 To 10
                sumCol(i) = 0
            Next

            Dim srh As DataRowHelper
            Dim drh As DataRowHelper

            Dim currCustomerId As Integer
            Dim currBillId As Integer

            For Each rowCustomer As DataRow In dtCustomer.Rows
                srh = New DataRowHelper(rowCustomer)
                trCustomer = Me.m_treemanager.Treetable.Childs.Add
                trCustomer.Tag = rowCustomer
                trCustomer("col0") = srh.GetValue(Of String)("CustomerCode")
                trCustomer("col1") = srh.GetValue(Of String)("CustomerName")
                currCustomerId = srh.GetValue(Of Integer)("CustomerId")

                Select Case m_showPeriod
                    Case 0 'Day
                        sumCol(0) += srh.GetValue(Of Decimal)("DayOutBound")
                        sumCol(1) += srh.GetValue(Of Decimal)("Day1to7")
                        sumCol(2) += srh.GetValue(Of Decimal)("Day8to14")
                        sumCol(3) += srh.GetValue(Of Decimal)("Day15to21")
                        sumCol(4) += srh.GetValue(Of Decimal)("Day22to28")
                        sumCol(5) += srh.GetValue(Of Decimal)("DayOver28")
                        sumCol(6) += srh.GetValue(Of Decimal)("RemainAmount")

                        If m_showDetailInGrid <> 0 Then
                            trCustomer("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                            trCustomer("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                            trCustomer("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                            trCustomer("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                            trCustomer("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                            trCustomer("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                            trCustomer("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        Else
                            trCustomer("col2") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                            trCustomer("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                            trCustomer("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                            trCustomer("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                            trCustomer("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                            trCustomer("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                            trCustomer("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End If



                    Case 1 'Month

                        sumCol(0) += srh.GetValue(Of Decimal)("MonthOutBound")
                        sumCol(1) += srh.GetValue(Of Decimal)("Month1")
                        sumCol(2) += srh.GetValue(Of Decimal)("Month2")
                        sumCol(3) += srh.GetValue(Of Decimal)("Month3")
                        sumCol(4) += srh.GetValue(Of Decimal)("Month4")
                        sumCol(5) += srh.GetValue(Of Decimal)("Month5")
                        sumCol(6) += srh.GetValue(Of Decimal)("Month6")
                        sumCol(7) += srh.GetValue(Of Decimal)("MonthOver6")
                        sumCol(8) += srh.GetValue(Of Decimal)("RemainAmount")

                        If m_showDetailInGrid <> 0 Then
                            trCustomer("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                            trCustomer("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                            trCustomer("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                            trCustomer("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                            trCustomer("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                            trCustomer("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                            trCustomer("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                            trCustomer("col10") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                            trCustomer("col11") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        Else
                            trCustomer("col2") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                            trCustomer("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                            trCustomer("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                            trCustomer("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                            trCustomer("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                            trCustomer("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                            trCustomer("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                            trCustomer("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                            trCustomer("col10") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End If


                    Case 2 'Year

                        sumCol(0) += srh.GetValue(Of Decimal)("QuarterYearOutBound")
                        sumCol(1) += srh.GetValue(Of Decimal)("QuarterYear1")
                        sumCol(2) += srh.GetValue(Of Decimal)("QuarterYear2")
                        sumCol(3) += srh.GetValue(Of Decimal)("QuarterYear3")
                        sumCol(4) += srh.GetValue(Of Decimal)("QuarterYear4")
                        sumCol(5) += srh.GetValue(Of Decimal)("QuarterYearOver4")
                        sumCol(6) += srh.GetValue(Of Decimal)("RemainAmount")

                        If m_showDetailInGrid <> 0 Then
                            trCustomer("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                            trCustomer("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                            trCustomer("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                            trCustomer("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                            trCustomer("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                            trCustomer("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                            trCustomer("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        Else
                            trCustomer("col2") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                            trCustomer("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                            trCustomer("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                            trCustomer("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                            trCustomer("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                            trCustomer("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                            trCustomer("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End If

                End Select

                If m_showDetailInGrid <> 0 Then

                    trCustomer.State = RowExpandState.Expanded

                    For Each rowDocStock As DataRow In dtDocStock.Select("CustomerId = " & currCustomerId.ToString)

                        drh = New DataRowHelper(rowDocStock)
                        trDocStock = trCustomer.Childs.Add
                        trDocStock.Tag = rowDocStock

                        trDocStock("col0") = drh.GetValue(Of Date)("StockDueDate").ToShortDateString
                        trDocStock("col1") = drh.GetValue(Of String)("StockCode")
                        trDocStock("col2") = drh.GetValue(Of Date)("StockDocDate").ToShortDateString

                        Select Case m_showPeriod
                            Case 0 'Day
                                trDocStock("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                                trDocStock("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                                trDocStock("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                                trDocStock("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                                trDocStock("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                                trDocStock("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                                trDocStock("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 1 'Month
                                trDocStock("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                                trDocStock("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                                trDocStock("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                                trDocStock("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                                trDocStock("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                                trDocStock("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                                trDocStock("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                                trDocStock("col10") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                                trDocStock("col11") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 2 'Year
                                trDocStock("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                                trDocStock("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                                trDocStock("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                                trDocStock("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                                trDocStock("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                                trDocStock("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                                trDocStock("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End Select

                    Next

                    For Each rowBill As DataRow In dtBillSale.Select("CustomerId = " & currCustomerId.ToString)

                        drh = New DataRowHelper(rowBill)
                        trBillSale = trCustomer.Childs.Add
                        trBillSale.Tag = rowBill

                        trBillSale("col0") = drh.GetValue(Of Date)("BillDueDate").ToShortDateString
                        trBillSale("col1") = drh.GetValue(Of String)("BillCode")
                        trBillSale("col2") = drh.GetValue(Of Date)("BillDocDate").ToShortDateString

                        Select Case m_showPeriod
                            Case 0 'Day
                                trBillSale("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                                trBillSale("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                                trBillSale("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                                trBillSale("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                                trBillSale("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                                trBillSale("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                                trBillSale("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 1 'Month
                                trBillSale("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                                trBillSale("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                                trBillSale("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                                trBillSale("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                                trBillSale("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                                trBillSale("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                                trBillSale("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                                trBillSale("col10") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                                trBillSale("col11") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 2 'Year
                                trBillSale("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                                trBillSale("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                                trBillSale("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                                trBillSale("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                                trBillSale("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                                trBillSale("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                                trBillSale("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End Select

                        trBillSale.State = RowExpandState.Expanded
                        currBillId = drh.GetValue(Of Integer)("BillId")
                        For Each rowDocSale As DataRow In dtDocSale.Select("BillId = " & currBillId.ToString)

                            drh = New DataRowHelper(rowDocSale)
                            trDocSale = trBillSale.Childs.Add
                            trDocSale.Tag = rowDocSale

                            trDocSale("col0") = drh.GetValue(Of Date)("StockDueDate").ToShortDateString
                            trDocSale("col1") = drh.GetValue(Of String)("StockCode")
                            trDocSale("col2") = drh.GetValue(Of Date)("StockDocDate").ToShortDateString

                            Select Case m_showPeriod
                                Case 0 'Day
                                    trDocSale("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                                    trDocSale("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                                    trDocSale("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                                    trDocSale("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                                    trDocSale("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                                    trDocSale("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                                    trDocSale("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                                Case 1 'Month
                                    trDocSale("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                                    trDocSale("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                                    trDocSale("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                                    trDocSale("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                                    trDocSale("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                                    trDocSale("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                                    trDocSale("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                                    trDocSale("col10") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                                    trDocSale("col11") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                                Case 2 'Year
                                    trDocSale("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                                    trDocSale("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                                    trDocSale("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                                    trDocSale("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                                    trDocSale("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                                    trDocSale("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                                    trDocSale("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            End Select

                        Next

                    Next

                    For Each rowBill As DataRow In dtBillMileStone.Select("CustomerId = " & currCustomerId.ToString)

                        drh = New DataRowHelper(rowBill)

                        trBillMileStone = trCustomer.Childs.Add
                        trBillMileStone.Tag = rowBill

                        trBillMileStone("col0") = drh.GetValue(Of Date)("BillDueDate").ToShortDateString
                        trBillMileStone("col1") = drh.GetValue(Of String)("BillCode")
                        trBillMileStone("col2") = drh.GetValue(Of Date)("BillDocDate").ToShortDateString

                        Select Case m_showPeriod
                            Case 0 'Day
                                trBillMileStone("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                                trBillMileStone("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                                trBillMileStone("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                                trBillMileStone("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                                trBillMileStone("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                                trBillMileStone("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                                trBillMileStone("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 1 'Month
                                trBillMileStone("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                                trBillMileStone("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                                trBillMileStone("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                                trBillMileStone("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                                trBillMileStone("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                                trBillMileStone("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                                trBillMileStone("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                                trBillMileStone("col10") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                                trBillMileStone("col11") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 2 'Year
                                trBillMileStone("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                                trBillMileStone("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                                trBillMileStone("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                                trBillMileStone("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                                trBillMileStone("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                                trBillMileStone("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                                trBillMileStone("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End Select

                        'trBillMileStone.State = RowExpandState.Expanded
                        'currBillId = drh.GetValue(Of Integer)("BillId")
                        'For Each rowDocMileStone As DataRow In dtDocMileStone.Select("BillId = " & currBillId.ToString)

                        '    drh = New DataRowHelper(rowDocMileStone)
                        '    trDocMileStone = trBillMileStone.Childs.Add

                        '    trDocMileStone("col0") = "" 'drh.GetValue(Of Date)("StockDueDate").ToShortDateString
                        '    trDocMileStone("col1") = drh.GetValue(Of String)("StockCode")
                        '    trDocMileStone("col2") = "" 'drh.GetValue(Of Date)("StockDocDate").ToShortDateString

                        '    Select Case m_showPeriod
                        '        Case 0 'Day
                        '            trDocMileStone("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                        '            trDocMileStone("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                        '            trDocMileStone("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                        '            trDocMileStone("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                        '            trDocMileStone("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                        '            trDocMileStone("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                        '            trDocMileStone("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        '        Case 1 'Month
                        '            trDocMileStone("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                        '            trDocMileStone("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                        '            trDocMileStone("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                        '            trDocMileStone("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                        '            trDocMileStone("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                        '            trDocMileStone("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                        '            trDocMileStone("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                        '            trDocMileStone("col10") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                        '            trDocMileStone("col11") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        '        Case 2 'Year
                        '            trDocMileStone("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                        '            trDocMileStone("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                        '            trDocMileStone("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                        '            trDocMileStone("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                        '            trDocMileStone("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                        '            trDocMileStone("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                        '            trDocMileStone("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        '    End Select

                        'Next

                    Next


                End If


            Next

            'Sum Row
            trCustomer = Me.m_treemanager.Treetable.Childs.Add
            If m_showDetailInGrid <> 0 Then
                trCustomer("col2") = "รวม"
            Else
                trCustomer("col1") = "รวม"
            End If


            Select Case m_showPeriod
                Case 0 'Day
                    If m_showDetailInGrid <> 0 Then
                        trCustomer("col3") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trCustomer("col4") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trCustomer("col5") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trCustomer("col6") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trCustomer("col7") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trCustomer("col8") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trCustomer("col9") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                    Else
                        trCustomer("col2") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trCustomer("col3") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trCustomer("col4") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trCustomer("col5") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trCustomer("col6") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trCustomer("col7") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trCustomer("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                    End If

                Case 1 'Month
                    If m_showDetailInGrid <> 0 Then
                        trCustomer("col3") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trCustomer("col4") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trCustomer("col5") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trCustomer("col6") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trCustomer("col7") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trCustomer("col8") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trCustomer("col9") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                        trCustomer("col10") = Configuration.FormatToString(sumCol(7), DigitConfig.Price)
                        trCustomer("col11") = Configuration.FormatToString(sumCol(8), DigitConfig.Price)
                    Else
                        trCustomer("col2") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trCustomer("col3") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trCustomer("col4") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trCustomer("col5") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trCustomer("col6") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trCustomer("col7") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trCustomer("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                        trCustomer("col9") = Configuration.FormatToString(sumCol(7), DigitConfig.Price)
                        trCustomer("col10") = Configuration.FormatToString(sumCol(8), DigitConfig.Price)
                    End If

                Case 2 'Year
                    If m_showDetailInGrid <> 0 Then
                        trCustomer("col3") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trCustomer("col4") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trCustomer("col5") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trCustomer("col6") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trCustomer("col7") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trCustomer("col8") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trCustomer("col9") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                    Else
                        trCustomer("col2") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trCustomer("col3") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trCustomer("col4") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trCustomer("col5") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trCustomer("col6") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trCustomer("col7") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trCustomer("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                    End If

            End Select

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
            myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))

            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            Dim colCount As Integer = 0
            If m_showPeriod = 0 Or m_showPeriod = 2 Then
                colCount = 9
            ElseIf m_showPeriod = 1 Then
                colCount = 11
            End If
            If m_showDetailInGrid = 0 Then
                colCount = colCount - 1
            End If

            widths.Add(140)
            widths.Add(200)
            If m_showDetailInGrid = 0 Then
                widths.Add(100)
            Else
                widths.Add(80)
            End If
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)
            widths.Add(100)

            For i As Integer = 0 To colCount
                If i = 1 Then
                    If m_showDetailInGrid <> 0 Then
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
                    Dim realColCount As Integer = colCount
                    If m_showDetailInGrid = 0 Then
                        realColCount = realColCount + 1
                    End If
                    Dim cs As New TreeTextColumn(i, True, Color.Khaki)
                    cs.MappingName = "col" & i
                    cs.HeaderText = ""
                    cs.Width = CInt(widths(i))
                    cs.NullText = ""
                    'cs.Alignment = HorizontalAlignment.Left
                    cs.ReadOnly = True
                    Select Case i
                        Case 0, 1
                            cs.Alignment = HorizontalAlignment.Left
                            cs.DataAlignment = HorizontalAlignment.Left
                            cs.Format = "s"
                        Case realColCount
                            cs.Alignment = HorizontalAlignment.Center
                            cs.DataAlignment = HorizontalAlignment.Center
                            cs.Format = "s"
                        Case Else
                            cs.Alignment = HorizontalAlignment.Right
                            cs.DataAlignment = HorizontalAlignment.Right
                            cs.Format = "s"
                    End Select
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
                Return "RptReceiveDue"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptReceiveDue"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptARAging"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptReceiveDue.ListLabel}"
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
            Return "RptReceiveDue"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptReceiveDue"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            Dim iRow As Integer = CInt(IIf(m_showDetailInGrid = 0, 1, 2)) + 1
            For rowIndex As Integer = iRow To m_grid.RowCount
                Dim fn As Font

                If rowIndex < m_grid.RowCount Then
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                Else
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If

                For colIndex As Integer = 0 To m_grid.ColCount - 1
                    dpi = New DocPrintingItem
                    dpi.Mapping = "col" & colIndex.ToString
                    dpi.Value = m_grid(rowIndex, colIndex + 1).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = n + 1
                    dpi.Table = "Item"
                    dpi.Font = fn
                    dpiColl.Add(dpi)
                Next

                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

