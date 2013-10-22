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
  Public Class RptAPAging
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
                If m_showByBillDate = 0 Or m_showByBillDate = 4 Then
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
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
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

                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"

                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range0_7}")         '"ช่วง 0-7 วัน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range8_14}")        '"ช่วง 8-14 วัน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range15_21}")       '"ช่วง 15-21 วัน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range22_28}")       '"ช่วง 22-28 วัน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange_28}")     '"เกิน 28 วัน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"

                Else

                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"
                    tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range0_7}")         '"ช่วง 0-7 วัน"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range8_14}")        '"ช่วง 8-14 วัน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range15_21}")       '"ช่วง 15-21 วัน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range22_28}")       '"ช่วง 22-28 วัน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange_28}")     '"เกิน 28 วัน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"

                End If


                ' Level 2,3.
                If m_showDetailInGrid <> 0 Then

                    If m_showByBillDate = 0 Or m_showByBillDate = 4 Then

                        tr = Me.m_treemanager.Treetable.Childs.Add
                        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillDueDate}")     '"วันที่ครบกำหนดชำระ" 
                        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillCode}")        '"เลขที่ใบวางบิล"
                        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillDocDate}")     '"วันที่เอกสาร"  

                    End If

                    tr = Me.m_treemanager.Treetable.Childs.Add
                    tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockDueDate}")        '"วันที่กำหนดชำระ"   
                    tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockCode}")           '"เลขที่เอกสาร"
                    tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockDocDate}")        '"วันที่เอกสาร" 

                End If

            ElseIf m_showPeriod = 1 Then

                ' Level 1.
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                If m_showDetailInGrid <> 0 Then

                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"

                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range1M}")         '"ช่วง 1 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range2M}")        '"ช่วง 2 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range3M}")       '"ช่วง 3 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range4M}")       '"ช่วง 4 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range5M}")       '"ช่วง 5 เดือน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range6M}")      '"ช่วง 6 เดือน"
                    tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange6M}")     '"เกิน 6 เดือน"
                    tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"

                Else

                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"
                    tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")       '"ไม่อยู่ในช่วง"
                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range1M}")         '"ช่วง 1 เดือน"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range2M}")        '"ช่วง 2 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range3M}")       '"ช่วง 3 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range4M}")       '"ช่วง 4 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range5M}")       '"ช่วง 5 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range6M}")      '"ช่วง 6 เดือน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange6M}")     '"เกิน 6 เดือน"
                    tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"

                End If



                ' Level 2,3.
                If m_showDetailInGrid <> 0 Then

                    If m_showByBillDate = 0 Or m_showByBillDate = 4 Then

                        tr = Me.m_treemanager.Treetable.Childs.Add
                        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillDueDate}")     '"วันที่ครบกำหนดชำระ" 
                        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillCode}")        '"เลขที่ใบวางบิล"
                        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillDocDate}")     '"วันที่เอกสาร"  

                    End If

                    tr = Me.m_treemanager.Treetable.Childs.Add
                    tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockDueDate}")        '"วันที่กำหนดชำระ"   
                    tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockCode}")           '"รหัสใบวางบิล"
                    tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockDocDate}")        '"วันที่เอกสาร" 

                End If

            ElseIf m_showPeriod = 2 Then

                ' Level 1.
                Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
                If m_showDetailInGrid <> 0 Then

                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"

                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")      '"ไม่อยู่ในช่วง"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range1Q}")         '"ช่วง 3 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range2Q}")        '"ช่วง 6 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range3Q}")       '"ช่วง 9 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range4Q}")       '"ช่วง 12 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange4Q}")     '"เกิน 12 เดือน"
                    tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"

                Else

                    tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
                    tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"
                    tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")      '"ไม่อยู่ในช่วง"
                    tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range1Q}")         '"ช่วง 3 เดือน"
                    tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range2Q}")        '"ช่วง 6 เดือน"
                    tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range3Q}")       '"ช่วง 9 เดือน"
                    tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range4Q}")       '"ช่วง 12 เดือน"
                    tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange4Q}")     '"เกิน 12 เดือน"
                    tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"

                End If



                ' Level 2,3.
                If m_showDetailInGrid <> 0 Then

                    If m_showByBillDate = 0 Or m_showByBillDate = 4 Then

                        tr = Me.m_treemanager.Treetable.Childs.Add
                        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillDueDate}")     '"วันที่ครบกำหนดชำระ" 
                        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillCode}")        '"เลขที่ใบวางบิล"
                        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillDocDate}")     '"วันที่เอกสาร"  

                    End If

                    tr = Me.m_treemanager.Treetable.Childs.Add
                    tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockDueDate}")        '"วันที่กำหนดชำระ"   
                    tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockCode}")           '"รหัสใบวางบิล"
                    tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockDocDate}")        '"วันที่เอกสาร" 

                End If

            End If
    End Sub
    Private Sub PopulateData()

            Dim dtSupplier As DataTable = Me.DataSet.Tables(1)
            Dim dtBill As DataTable = Me.DataSet.Tables(2)
            Dim dtDocStock As DataTable = Me.DataSet.Tables(3)
            Dim dtDocBill As DataTable = Me.DataSet.Tables(4)

            m_hashData = New Hashtable

            If dtSupplier.Rows.Count = 0 Then
                Return
            End If

            Dim indent As String = Space(3)

            Dim trSupplier As TreeRow
            Dim trDocStock As TreeRow
            Dim trBill As TreeRow
            Dim trDocBill As TreeRow

            Dim sumCol(10) As Decimal
            Dim sumTotalAmount As Decimal = 0
            For i As Integer = 0 To 10
                sumCol(i) = 0
            Next

            Dim srh As DataRowHelper
            Dim drh As DataRowHelper

            Dim currSupplierID As Integer
            Dim currBillId As Integer

            For Each rowSupplier As DataRow In dtSupplier.Rows
                srh = New DataRowHelper(rowSupplier)
                trSupplier = Me.m_treemanager.Treetable.Childs.Add
                trSupplier.Tag = rowSupplier
                trSupplier("col0") = srh.GetValue(Of String)("SupplierCode")
                trSupplier("col1") = srh.GetValue(Of String)("SupplierName")
                currSupplierID = srh.GetValue(Of Integer)("SupplierID")

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
                            trSupplier("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                            trSupplier("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                            trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                            trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                            trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                            trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                            trSupplier("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        Else
                            trSupplier("col2") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                            trSupplier("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                            trSupplier("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                            trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                            trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                            trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                            trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
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
                            trSupplier("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                            trSupplier("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                            trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                            trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                            trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                            trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                            trSupplier("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                            trSupplier("col10") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                            trSupplier("col11") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        Else
                            trSupplier("col2") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                            trSupplier("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                            trSupplier("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                            trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                            trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                            trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                            trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                            trSupplier("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                            trSupplier("col10") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
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
                            trSupplier("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                            trSupplier("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                            trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                            trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                            trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                            trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                            trSupplier("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        Else
                            trSupplier("col2") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                            trSupplier("col3") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                            trSupplier("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                            trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                            trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                            trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                            trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End If

                End Select

                If m_showDetailInGrid <> 0 Then

                    trSupplier.State = RowExpandState.Expanded

                    For Each rowDocStock As DataRow In dtDocStock.Select("SupplierID = " & currSupplierID.ToString)

                        drh = New DataRowHelper(rowDocStock)
                        trDocStock = trSupplier.Childs.Add
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

                    For Each rowBill As DataRow In dtBill.Select("SupplierID = " & currSupplierID.ToString)

                        drh = New DataRowHelper(rowBill)
                        trBill = trSupplier.Childs.Add
                        trBill.Tag = rowBill
                        trBill("col0") = drh.GetValue(Of Date)("BillDueDate").ToShortDateString
                        trBill("col1") = drh.GetValue(Of String)("BillCode")
                        trBill("col2") = drh.GetValue(Of Date)("BillDocDate").ToShortDateString

                        Select Case m_showPeriod
                            Case 0 'Day
                                trBill("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                                trBill("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                                trBill("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                                trBill("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                                trBill("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                                trBill("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                                trBill("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 1 'Month
                                trBill("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                                trBill("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                                trBill("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                                trBill("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                                trBill("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                                trBill("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                                trBill("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                                trBill("col10") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                                trBill("col11") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            Case 2 'Year
                                trBill("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                                trBill("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                                trBill("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                                trBill("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                                trBill("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                                trBill("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                                trBill("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                        End Select

                        trBill.State = RowExpandState.Expanded
                        currBillId = drh.GetValue(Of Integer)("BillId")
                        For Each rowDocBill As DataRow In dtDocBill.Select("BillId = " & currBillId.ToString)

                            drh = New DataRowHelper(rowDocBill)
                            trDocBill = trBill.Childs.Add
                            trDocBill.Tag = rowDocBill
                            trDocBill("col0") = drh.GetValue(Of Date)("StockDueDate").ToShortDateString
                            trDocBill("col1") = drh.GetValue(Of String)("StockCode")
                            trDocBill("col2") = drh.GetValue(Of Date)("StockDocDate").ToShortDateString

                            Select Case m_showPeriod
                                Case 0 'Day
                                    trDocBill("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOutBound"), DigitConfig.Price)
                                    trDocBill("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day1to7"), DigitConfig.Price)
                                    trDocBill("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day8to14"), DigitConfig.Price)
                                    trDocBill("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day15to21"), DigitConfig.Price)
                                    trDocBill("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Day22to28"), DigitConfig.Price)
                                    trDocBill("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("DayOver28"), DigitConfig.Price)
                                    trDocBill("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                                Case 1 'Month
                                    trDocBill("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOutBound"), DigitConfig.Price)
                                    trDocBill("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month1"), DigitConfig.Price)
                                    trDocBill("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month2"), DigitConfig.Price)
                                    trDocBill("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month3"), DigitConfig.Price)
                                    trDocBill("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month4"), DigitConfig.Price)
                                    trDocBill("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month5"), DigitConfig.Price)
                                    trDocBill("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("Month6"), DigitConfig.Price)
                                    trDocBill("col10") = Configuration.FormatToString(drh.GetValue(Of Decimal)("MonthOver6"), DigitConfig.Price)
                                    trDocBill("col11") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                                Case 2 'Year
                                    trDocBill("col3") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOutBound"), DigitConfig.Price)
                                    trDocBill("col4") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear1"), DigitConfig.Price)
                                    trDocBill("col5") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear2"), DigitConfig.Price)
                                    trDocBill("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear3"), DigitConfig.Price)
                                    trDocBill("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYear4"), DigitConfig.Price)
                                    trDocBill("col8") = Configuration.FormatToString(drh.GetValue(Of Decimal)("QuarterYearOver4"), DigitConfig.Price)
                                    trDocBill("col9") = Configuration.FormatToString(drh.GetValue(Of Decimal)("RemainAmount"), DigitConfig.Price)
                            End Select

                        Next

                    Next

                End If

            Next

            'Sum Row
            trSupplier = Me.m_treemanager.Treetable.Childs.Add
            If m_showDetailInGrid <> 0 Then
                trSupplier("col2") = "รวม"
            Else
                trSupplier("col1") = "รวม"
            End If


            Select Case m_showPeriod
                Case 0 'Day
                    If m_showDetailInGrid <> 0 Then
                        trSupplier("col3") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trSupplier("col4") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trSupplier("col5") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trSupplier("col6") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trSupplier("col7") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trSupplier("col8") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trSupplier("col9") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                    Else
                        trSupplier("col2") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trSupplier("col3") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trSupplier("col4") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trSupplier("col5") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trSupplier("col6") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trSupplier("col7") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trSupplier("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                    End If

                Case 1 'Month
                    If m_showDetailInGrid <> 0 Then
                        trSupplier("col3") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trSupplier("col4") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trSupplier("col5") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trSupplier("col6") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trSupplier("col7") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trSupplier("col8") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trSupplier("col9") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                        trSupplier("col10") = Configuration.FormatToString(sumCol(7), DigitConfig.Price)
                        trSupplier("col11") = Configuration.FormatToString(sumCol(8), DigitConfig.Price)
                    Else
                        trSupplier("col2") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trSupplier("col3") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trSupplier("col4") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trSupplier("col5") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trSupplier("col6") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trSupplier("col7") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trSupplier("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                        trSupplier("col9") = Configuration.FormatToString(sumCol(7), DigitConfig.Price)
                        trSupplier("col10") = Configuration.FormatToString(sumCol(8), DigitConfig.Price)
                    End If

                Case 2 'Year
                    If m_showDetailInGrid <> 0 Then
                        trSupplier("col3") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trSupplier("col4") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trSupplier("col5") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trSupplier("col6") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trSupplier("col7") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trSupplier("col8") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trSupplier("col9") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
                    Else
                        trSupplier("col2") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
                        trSupplier("col3") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
                        trSupplier("col4") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
                        trSupplier("col5") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
                        trSupplier("col6") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
                        trSupplier("col7") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
                        trSupplier("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
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
      myDatatable.Columns.Add(New DataColumn("SelectionType", GetType(String)))

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
                colCount = 12
      End If
      If m_showDetailInGrid = 0 Then
        colCount = colCount - 1
      End If

            widths.Add(140)
      widths.Add(200)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
            widths.Add(120)
      widths.Add(0)

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
          'Dim realColCount As Integer = colCount
          'If m_showDetailInGrid = 0 Then
          '  realColCount = realColCount + 1
          'End If
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          Select Case i
            Case 0, 1
              cs.Alignment = HorizontalAlignment.Left
              cs.DataAlignment = HorizontalAlignment.Left
              'Case realColCount
              '  cs.Alignment = HorizontalAlignment.Center
              '  cs.DataAlignment = HorizontalAlignment.Center
              '  cs.Format = "s"
            Case Else
              cs.Alignment = HorizontalAlignment.Right
              cs.DataAlignment = HorizontalAlignment.Right
          End Select
                    cs.ReadOnly = True
                    cs.Format = "s"
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
        Return "RptAPAging"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPAging"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPAging"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.ListLabel}"
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
      Return "RptAPAging"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAPAging"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim iRow As Integer = CInt(IIf(m_showDetailInGrid = 0, 1, 3)) + 1
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

