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
  Public Class RptAPAging
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_showPeriod As Integer
    Private m_showByBillDate As Integer
    Private m_showDetailInGrid As Integer
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
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      If m_showDetailInGrid = 0 Then
        lkg.Rows.HeaderCount = 1
        lkg.Rows.FrozenCount = 1
      Else
        lkg.Rows.HeaderCount = 3
        lkg.Rows.FrozenCount = 3
      End If

      lkg.Refresh()
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
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"
        tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")       '"ไม่อยู่ในช่วง"
        tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range0_7}")         '"ช่วง 0-7 วัน"
        tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range8_14}")        '"ช่วง 8-14 วัน"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range15_21}")       '"ช่วง 15-21 วัน"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range22_28}")       '"ช่วง 22-28 วัน"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange_28}")     '"เกิน 28 วัน"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"
        ' Level 2.
        If m_showDetailInGrid <> 0 Then
          tr = Me.m_treemanager.Treetable.Childs.Add
          tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DueDate}")     '"วันที่กำหนดชำระ"  
          tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockCode}")     '"รหัสใบสั่งซื้อ/รับของ" 

          'Level 3
          tr = Me.m_treemanager.Treetable.Childs.Add
          tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DueDate}")     '"วันที่กำหนดชำระ"   
          tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillaDocCode}") '"รหัสใบวางบิล"
        End If

      ElseIf m_showPeriod = 1 Then
        ' Level 1.
        Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
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
        ' Level 2.
        If m_showDetailInGrid <> 0 Then
          tr = Me.m_treemanager.Treetable.Childs.Add
          tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DueDate}")     '"วันที่กำหนดชำระ"     
          tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockCode}")     '"รหัสใบสั่งซื้อ/รับของ"  

          'Level 3
          tr = Me.m_treemanager.Treetable.Childs.Add
          tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DueDate}")     '"วันที่กำหนดชำระ"   
          tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillaDocCode}") '"รหัสใบวางบิล"
        End If

      ElseIf m_showPeriod = 2 Then
        ' Level 1.
        Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierId}")       '"รหัสผู้ขาย"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.SupplierName}")     '"ชื่อผู้ขาย"
        tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.NotInRange}")      '"ไม่อยู่ในช่วง"
        tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range1Q}")         '"ช่วง 3 เดือน"
        tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range2Q}")        '"ช่วง 6 เดือน"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range3Q}")       '"ช่วง 9 เดือน"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Range4Q}")       '"ช่วง 12 เดือน"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.OverRange4Q}")     '"เกิน 12 เดือน"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}")            '"รวม"
        ' Level 2.
        If m_showDetailInGrid <> 0 Then
          tr = Me.m_treemanager.Treetable.Childs.Add
          tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DueDate}")     '"วันที่กำหนดชำระ" 
          tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.StockCode}")     '"รหัสใบสั่งซื้อ/รับของ"  

          'Level 3
          tr = Me.m_treemanager.Treetable.Childs.Add
          tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DueDate}")     '"วันที่กำหนดชำระ"   
          tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.BillaDocCode}")  '"รหัสใบวางบิล"
        End If
      End If
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(1) 'Me.DataSet.Tables(m_ShowPeriod + 1)

      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim indent As String = Space(3)
      Dim currTrIndex As Integer = -1
      Dim currSupplierCode As String = ""
      Dim currBillCode As String = ""
      Dim currStockCode As String = ""
      Dim currStockCodeForSupplier As String = ""

      Dim trSupplier As TreeRow
      Dim trSupplieritem As TreeRow
      Dim trBill As TreeRow

      Dim sumSupplierAmount(10) As Decimal
      Dim sumStockAmount(10) As Decimal
      Dim sumCol(10) As Decimal
      Dim sumTotalAmount As Decimal = 0
      For i As Integer = 0 To 10
        sumSupplierAmount(i) = 0
        sumStockAmount(i) = 0
        sumCol(i) = 0
      Next
      Dim lastStockDate As String

      For Each row As DataRow In dt.Rows
        If m_showPeriod = 0 Then
          If CDec(row("SumDay")) <> 0 Then
            If Not currSupplierCode.Equals(row("SupplierCode").ToString) Then
              If Not trSupplier Is Nothing Then
                trSupplier("col2") = Configuration.FormatToString(sumSupplierAmount(0), DigitConfig.Price)
                trSupplier("col3") = Configuration.FormatToString(sumSupplierAmount(1), DigitConfig.Price)
                trSupplier("col4") = Configuration.FormatToString(sumSupplierAmount(2), DigitConfig.Price)
                trSupplier("col5") = Configuration.FormatToString(sumSupplierAmount(3), DigitConfig.Price)
                trSupplier("col6") = Configuration.FormatToString(sumSupplierAmount(4), DigitConfig.Price)
                trSupplier("col7") = Configuration.FormatToString(sumSupplierAmount(5), DigitConfig.Price)
                trSupplier("col8") = Configuration.FormatToString(sumSupplierAmount(6), DigitConfig.Price)
                For i As Integer = 0 To 10
                  sumSupplierAmount(i) = 0
                  'sumStockAmount(i) = 0
                Next
              End If

              trSupplier = Me.m_treemanager.Treetable.Childs.Add
              trSupplier("col0") = row("SupplierCode").ToString
              trSupplier("col1") = row("SupplierName").ToString
              trSupplier.State = RowExpandState.Expanded
              currSupplierCode = row("SupplierCode").ToString
            End If
          End If


          If currStockCodeForSupplier <> row("StockCode").ToString Then
            If IsNumeric(row("DayOutBound")) Then
              sumSupplierAmount(0) += CDec(row("DayOutBound"))
              sumCol(0) += CDec(row("DayOutBound"))
            End If
            If IsNumeric(row("Day1to7")) Then
              sumSupplierAmount(1) += CDec(row("Day1to7"))
              sumCol(1) += CDec(row("Day1to7"))
            End If
            If IsNumeric(row("Day8to14")) Then
              sumSupplierAmount(2) += CDec(row("Day8to14"))
              sumCol(2) += CDec(row("Day8to14"))
            End If
            If IsNumeric(row("Day15to21")) Then
              sumSupplierAmount(3) += CDec(row("Day15to21"))
              sumCol(3) += CDec(row("Day15to21"))
            End If
            If IsNumeric(row("Day22to28")) Then
              sumSupplierAmount(4) += CDec(row("Day22to28"))
              sumCol(4) += CDec(row("Day22to28"))
            End If
            If IsNumeric(row("DayOver28")) Then
              sumSupplierAmount(5) += CDec(row("DayOver28"))
              sumCol(5) += CDec(row("DayOver28"))
            End If
            If IsNumeric(row("SumDay")) Then
              sumSupplierAmount(6) += CDec(row("SumDay"))
              sumCol(6) += CDec(row("SumDay"))
            End If
            currStockCodeForSupplier = row("StockCode").ToString
          End If

          If m_showDetailInGrid <> 0 Then
            If CDec(row("SumDay")) <> 0 Then
              If currStockCode <> row("StockCode").ToString Then
                If Not trSupplieritem Is Nothing Then
                  trSupplieritem("col2") = Configuration.FormatToString(sumStockAmount(0), DigitConfig.Price)
                  trSupplieritem("col3") = Configuration.FormatToString(sumStockAmount(1), DigitConfig.Price)
                  trSupplieritem("col4") = Configuration.FormatToString(sumStockAmount(2), DigitConfig.Price)
                  trSupplieritem("col5") = Configuration.FormatToString(sumStockAmount(3), DigitConfig.Price)
                  trSupplieritem("col6") = Configuration.FormatToString(sumStockAmount(4), DigitConfig.Price)
                  trSupplieritem("col7") = Configuration.FormatToString(sumStockAmount(5), DigitConfig.Price)
                  trSupplieritem("col8") = Configuration.FormatToString(sumStockAmount(6), DigitConfig.Price)
                  If Not row.IsNull("StockDueDate") Then
                    If IsDate(row("StockDueDate")) Then
                      'trSupplieritem("col0") = indent & CDate(row("StockDueDate")).ToShortDateString
                      lastStockDate = indent & CDate(row("StockDueDate")).ToShortDateString
                    End If
                  End If

                  For i As Integer = 0 To 10
                    sumStockAmount(i) = 0
                  Next
                End If

                trSupplieritem = trSupplier.Childs.Add
                trSupplieritem("col0") = indent & CDate(row("StockDueDate")).ToShortDateString
                trSupplieritem("col1") = indent & row("StockCode").ToString
                currStockCode = row("StockCode").ToString
                trSupplieritem.State = RowExpandState.Expanded
              End If


              If IsNumeric(row("DayOutBound")) Then
                sumStockAmount(0) += CDec(row("DayOutBound"))
              End If
              If IsNumeric(row("Day1to7")) Then
                sumStockAmount(1) += CDec(row("Day1to7"))
              End If
              If IsNumeric(row("Day8to14")) Then
                sumStockAmount(2) += CDec(row("Day8to14"))
              End If
              If IsNumeric(row("Day15to21")) Then
                sumStockAmount(3) += CDec(row("Day15to21"))
              End If
              If IsNumeric(row("Day22to28")) Then
                sumStockAmount(4) += CDec(row("Day22to28"))
              End If
              If IsNumeric(row("DayOver28")) Then
                sumStockAmount(5) += CDec(row("DayOver28"))
              End If
              If IsNumeric(row("SumDay")) Then
                sumStockAmount(6) += CDec(row("SumDay"))
              End If
            End If

            If Not trSupplieritem Is Nothing Then
              If CDec(row("SumDay")) <> 0 Then
                If row("BillaCode").ToString <> "" Then
                  trBill = trSupplieritem.Childs.Add
                  trBill("col1") = indent & indent & row("BillaCode").ToString
                  trBill("col2") = Configuration.FormatToString(CDec(row("DayOutBound")), DigitConfig.Price)
                  trBill("col3") = Configuration.FormatToString(CDec(row("Day1to7")), DigitConfig.Price)
                  trBill("col4") = Configuration.FormatToString(CDec(row("Day8to14")), DigitConfig.Price)
                  trBill("col5") = Configuration.FormatToString(CDec(row("Day15to21")), DigitConfig.Price)
                  trBill("col6") = Configuration.FormatToString(CDec(row("Day22to28")), DigitConfig.Price)
                  trBill("col7") = Configuration.FormatToString(CDec(row("DayOver28")), DigitConfig.Price)
                  trBill("col8") = Configuration.FormatToString(CDec(row("SumDay")), DigitConfig.Price)
                  If Not row.IsNull("BillaDueDate") Then
                    If IsDate(row("BillaDueDate")) Then
                      trBill("col0") = indent & indent & CDate(row("BillaDueDate")).ToShortDateString
                    End If
                  End If
                End If
              End If
            End If
          End If

        ElseIf m_showPeriod = 1 Then
          If CDec(row("SumMonth")) <> 0 Then
            If Not currSupplierCode.Equals(row("SupplierCode")) Then
              If Not trSupplier Is Nothing Then
                trSupplier("col2") = Configuration.FormatToString(sumSupplierAmount(0), DigitConfig.Price)
                trSupplier("col3") = Configuration.FormatToString(sumSupplierAmount(1), DigitConfig.Price)
                trSupplier("col4") = Configuration.FormatToString(sumSupplierAmount(2), DigitConfig.Price)
                trSupplier("col5") = Configuration.FormatToString(sumSupplierAmount(3), DigitConfig.Price)
                trSupplier("col6") = Configuration.FormatToString(sumSupplierAmount(4), DigitConfig.Price)
                trSupplier("col7") = Configuration.FormatToString(sumSupplierAmount(5), DigitConfig.Price)
                trSupplier("col8") = Configuration.FormatToString(sumSupplierAmount(6), DigitConfig.Price)
                trSupplier("col9") = Configuration.FormatToString(sumSupplierAmount(7), DigitConfig.Price)
                trSupplier("col10") = Configuration.FormatToString(sumSupplierAmount(8), DigitConfig.Price)
                For i As Integer = 0 To 10
                  sumSupplierAmount(i) = 0
                  'sumStockAmount(i) = 0
                Next
              End If

              trSupplier = Me.m_treemanager.Treetable.Childs.Add
              trSupplier("col0") = row("SupplierCode")
              trSupplier("col1") = row("SupplierName")
              trSupplier.State = RowExpandState.Expanded
              currSupplierCode = row("SupplierCode").ToString
            End If
          End If


          If currStockCodeForSupplier <> row("StockCode").ToString Then
            If IsNumeric(row("MonthOutBound")) Then
              sumSupplierAmount(0) += CDec(row("MonthOutBound"))
              sumCol(0) += CDec(row("MonthOutBound"))
            End If
            If IsNumeric(row("Month1")) Then
              sumSupplierAmount(1) += CDec(row("Month1"))
              sumCol(1) += CDec(row("Month1"))
            End If
            If IsNumeric(row("Month2")) Then
              sumSupplierAmount(2) += CDec(row("Month2"))
              sumCol(2) += CDec(row("Month2"))
            End If
            If IsNumeric(row("Month3")) Then
              sumSupplierAmount(3) += CDec(row("Month3"))
              sumCol(3) += CDec(row("Month3"))
            End If
            If IsNumeric(row("Month4")) Then
              sumSupplierAmount(4) += CDec(row("Month4"))
              sumCol(4) += CDec(row("Month4"))
            End If
            If IsNumeric(row("Month5")) Then
              sumSupplierAmount(5) += CDec(row("Month5"))
              sumCol(5) += CDec(row("Month5"))
            End If
            If IsNumeric(row("Month6")) Then
              sumSupplierAmount(6) += CDec(row("Month6"))
              sumCol(6) += CDec(row("Month6"))
            End If
            If IsNumeric(row("MonthOver6")) Then
              sumSupplierAmount(7) += CDec(row("MonthOver6"))
              sumCol(7) += CDec(row("MonthOver6"))
            End If
            If IsNumeric(row("SumMonth")) Then
              sumSupplierAmount(8) += CDec(row("SumMonth"))
              sumCol(8) += CDec(row("SumMonth"))
            End If
            currStockCodeForSupplier = row("StockCode").ToString
          End If

          If m_showDetailInGrid <> 0 Then
            If CDec(row("SumMonth")) <> 0 Then
              If Not currStockCode = row("StockCode").ToString Then
                If Not trSupplieritem Is Nothing Then
                  trSupplieritem("col2") = Configuration.FormatToString(sumStockAmount(0), DigitConfig.Price)
                  trSupplieritem("col3") = Configuration.FormatToString(sumStockAmount(1), DigitConfig.Price)
                  trSupplieritem("col4") = Configuration.FormatToString(sumStockAmount(2), DigitConfig.Price)
                  trSupplieritem("col5") = Configuration.FormatToString(sumStockAmount(3), DigitConfig.Price)
                  trSupplieritem("col6") = Configuration.FormatToString(sumStockAmount(4), DigitConfig.Price)
                  trSupplieritem("col7") = Configuration.FormatToString(sumStockAmount(5), DigitConfig.Price)
                  trSupplieritem("col8") = Configuration.FormatToString(sumStockAmount(6), DigitConfig.Price)
                  trSupplieritem("col9") = Configuration.FormatToString(sumStockAmount(7), DigitConfig.Price)
                  trSupplieritem("col10") = Configuration.FormatToString(sumStockAmount(8), DigitConfig.Price)
                  If Not row.IsNull("StockDueDate") Then
                    If IsDate(row("StockDueDate")) Then
                      'trSupplieritem("col0") = indent & CDate(row("StockDueDate")).ToShortDateString
                      lastStockDate = indent & CDate(row("StockDueDate")).ToShortDateString
                    End If
                  End If

                  For i As Integer = 0 To 10
                    sumStockAmount(i) = 0
                  Next
                End If

                trSupplieritem = trSupplier.Childs.Add
                trSupplieritem("col0") = indent & CDate(row("StockDueDate")).ToShortDateString
                trSupplieritem("col1") = indent & row("StockCode").ToString
                currStockCode = row("StockCode").ToString
                trSupplieritem.State = RowExpandState.Expanded
              End If


              If IsNumeric(row("MonthOutBound")) Then
                sumStockAmount(0) += CDec(row("MonthOutBound"))
              End If
              If IsNumeric(row("Month1")) Then
                sumStockAmount(1) += CDec(row("Month1"))
              End If
              If IsNumeric(row("Month2")) Then
                sumStockAmount(2) += CDec(row("Month2"))
              End If
              If IsNumeric(row("Month3")) Then
                sumStockAmount(3) += CDec(row("Month3"))
              End If
              If IsNumeric(row("Month4")) Then
                sumStockAmount(4) += CDec(row("Month4"))
              End If
              If IsNumeric(row("Month5")) Then
                sumStockAmount(5) += CDec(row("Month5"))
              End If
              If IsNumeric(row("Month6")) Then
                sumStockAmount(6) += CDec(row("Month6"))
              End If
              If IsNumeric(row("MonthOver6")) Then
                sumStockAmount(7) += CDec(row("MonthOver6"))
              End If
              If IsNumeric(row("SumMonth")) Then
                sumStockAmount(8) += CDec(row("SumMonth"))
              End If
            End If

            If Not trSupplieritem Is Nothing Then
              If CDec(row("SumMonth")) <> 0 Then
                If row("BillaCode").ToString <> "" Then
                  trBill = trSupplieritem.Childs.Add
                  trBill("col1") = indent & indent & row("BillaCode").ToString
                  trBill("col2") = Configuration.FormatToString(CDec(row("MonthOutBound")), DigitConfig.Price)
                  trBill("col3") = Configuration.FormatToString(CDec(row("Month1")), DigitConfig.Price)
                  trBill("col4") = Configuration.FormatToString(CDec(row("Month2")), DigitConfig.Price)
                  trBill("col5") = Configuration.FormatToString(CDec(row("Month3")), DigitConfig.Price)
                  trBill("col6") = Configuration.FormatToString(CDec(row("Month4")), DigitConfig.Price)
                  trBill("col7") = Configuration.FormatToString(CDec(row("Month5")), DigitConfig.Price)
                  trBill("col8") = Configuration.FormatToString(CDec(row("Month6")), DigitConfig.Price)
                  trBill("col9") = Configuration.FormatToString(CDec(row("MonthOver6")), DigitConfig.Price)
                  trBill("col10") = Configuration.FormatToString(CDec(row("SumMonth")), DigitConfig.Price)
                  If Not row.IsNull("BillaDueDate") Then
                    If IsDate(row("BillaDueDate")) Then
                      trBill("col0") = indent & indent & CDate(row("BillaDueDate")).ToShortDateString
                    End If
                  End If
                End If
              End If
            End If
          End If


        ElseIf m_showPeriod = 2 Then
          If CDec(row("SumYear")) <> 0 Then
            If Not currSupplierCode.Equals(row("SupplierCode")) Then
              If Not trSupplier Is Nothing Then
                trSupplier("col2") = Configuration.FormatToString(sumSupplierAmount(0), DigitConfig.Price)
                trSupplier("col3") = Configuration.FormatToString(sumSupplierAmount(1), DigitConfig.Price)
                trSupplier("col4") = Configuration.FormatToString(sumSupplierAmount(2), DigitConfig.Price)
                trSupplier("col5") = Configuration.FormatToString(sumSupplierAmount(3), DigitConfig.Price)
                trSupplier("col6") = Configuration.FormatToString(sumSupplierAmount(4), DigitConfig.Price)
                trSupplier("col7") = Configuration.FormatToString(sumSupplierAmount(5), DigitConfig.Price)
                trSupplier("col8") = Configuration.FormatToString(sumSupplierAmount(6), DigitConfig.Price)
                For i As Integer = 0 To 10
                  sumSupplierAmount(i) = 0
                Next

              End If

              trSupplier = Me.m_treemanager.Treetable.Childs.Add
              trSupplier("col0") = row("SupplierCode")
              trSupplier("col1") = row("SupplierName")
              trSupplier.State = RowExpandState.Expanded
              currSupplierCode = row("SupplierCode").ToString
            End If
          End If


          If currStockCodeForSupplier <> row("StockCode").ToString Then
            If IsNumeric(row("QuarterYearOutBound")) Then
              sumSupplierAmount(0) += CDec(row("QuarterYearOutBound"))
              sumCol(0) += CDec(row("QuarterYearOutBound"))
            End If
            If IsNumeric(row("QuarterYear1")) Then
              sumSupplierAmount(1) += CDec(row("QuarterYear1"))
              sumCol(1) += CDec(row("QuarterYear1"))
            End If
            If IsNumeric(row("QuarterYear2")) Then
              sumSupplierAmount(2) += CDec(row("QuarterYear2"))
              sumCol(2) += CDec(row("QuarterYear2"))
            End If
            If IsNumeric(row("QuarterYear3")) Then
              sumSupplierAmount(3) += CDec(row("QuarterYear3"))
              sumCol(3) += CDec(row("QuarterYear3"))
            End If
            If IsNumeric(row("QuarterYear4")) Then
              sumSupplierAmount(4) += CDec(row("QuarterYear4"))
              sumCol(4) += CDec(row("QuarterYear4"))
            End If
            If IsNumeric(row("QuarterYearOver4")) Then
              sumSupplierAmount(5) += CDec(row("QuarterYearOver4"))
              sumCol(5) += CDec(row("QuarterYearOver4"))
            End If
            If IsNumeric(row("QuarterYearOver4")) Then
              sumSupplierAmount(6) += CDec(row("SumYear"))
              sumCol(6) += CDec(row("SumYear"))
            End If
            currStockCodeForSupplier = row("StockCode").ToString
          End If

          If m_showDetailInGrid <> 0 Then
            If CDec(row("SumYear")) <> 0 Then
              If Not currStockCode = row("StockCode").ToString Then
                If Not trSupplieritem Is Nothing Then
                  trSupplieritem("col2") = Configuration.FormatToString(sumStockAmount(0), DigitConfig.Price)
                  trSupplieritem("col3") = Configuration.FormatToString(sumStockAmount(1), DigitConfig.Price)
                  trSupplieritem("col4") = Configuration.FormatToString(sumStockAmount(2), DigitConfig.Price)
                  trSupplieritem("col5") = Configuration.FormatToString(sumStockAmount(3), DigitConfig.Price)
                  trSupplieritem("col6") = Configuration.FormatToString(sumStockAmount(4), DigitConfig.Price)
                  trSupplieritem("col7") = Configuration.FormatToString(sumStockAmount(5), DigitConfig.Price)
                  trSupplieritem("col8") = Configuration.FormatToString(sumStockAmount(6), DigitConfig.Price)
                  If Not row.IsNull("StockDueDate") Then
                    If IsDate(row("StockDueDate")) Then
                      'trSupplieritem("col0") = indent & CDate(row("StockDueDate")).ToShortDateString
                      lastStockDate = indent & CDate(row("StockDueDate")).ToShortDateString
                    End If
                  End If

                  For i As Integer = 0 To 10
                    sumStockAmount(i) = 0
                  Next
                End If

                trSupplieritem = trSupplier.Childs.Add
                trSupplieritem("col0") = indent & CDate(row("StockDueDate")).ToShortDateString
                trSupplieritem("col1") = indent & row("StockCode").ToString
                currStockCode = row("StockCode").ToString
                trSupplieritem.State = RowExpandState.Expanded
              End If


              If IsNumeric(row("QuarterYearOutBound")) Then
                sumStockAmount(0) += CDec(row("QuarterYearOutBound"))
              End If
              If IsNumeric(row("QuarterYear1")) Then
                sumStockAmount(1) += CDec(row("QuarterYear1"))
              End If
              If IsNumeric(row("QuarterYear2")) Then
                sumStockAmount(2) += CDec(row("QuarterYear2"))
              End If
              If IsNumeric(row("QuarterYear3")) Then
                sumStockAmount(3) += CDec(row("QuarterYear3"))
              End If
              If IsNumeric(row("QuarterYear4")) Then
                sumStockAmount(4) += CDec(row("QuarterYear4"))
              End If
              If IsNumeric(row("QuarterYearOver4")) Then
                sumStockAmount(5) += CDec(row("QuarterYearOver4"))
              End If
              If IsNumeric(row("QuarterYearOver4")) Then
                sumStockAmount(6) += CDec(row("SumYear"))
              End If
            End If


            If Not trSupplieritem Is Nothing Then
              If CDec(row("SumYear")) <> 0 Then
                If row("BillaCode").ToString <> "" Then
                  trBill = trSupplieritem.Childs.Add
                  trBill("col1") = indent & indent & row("BillaCode").ToString
                  trBill("col2") = Configuration.FormatToString(CDec(row("QuarterYearOutBound")), DigitConfig.Price)
                  trBill("col3") = Configuration.FormatToString(CDec(row("QuarterYear1")), DigitConfig.Price)
                  trBill("col4") = Configuration.FormatToString(CDec(row("QuarterYear2")), DigitConfig.Price)
                  trBill("col5") = Configuration.FormatToString(CDec(row("QuarterYear3")), DigitConfig.Price)
                  trBill("col6") = Configuration.FormatToString(CDec(row("QuarterYear4")), DigitConfig.Price)
                  trBill("col7") = Configuration.FormatToString(CDec(row("QuarterYearOver4")), DigitConfig.Price)
                  trBill("col8") = Configuration.FormatToString(CDec(row("SumYear")), DigitConfig.Price)
                  If Not row.IsNull("BillaDueDate") Then
                    If IsDate(row("BillaDueDate")) Then
                      trBill("col0") = indent & indent & CDate(row("BillaDueDate")).ToShortDateString
                    End If

                  End If
                End If
              End If
            End If
          End If
        End If
      Next

      If m_showDetailInGrid <> 0 Then
        'สำหรับ Stock สุดท้าย
        If Not trSupplieritem Is Nothing Then
          If m_showPeriod = 0 Then
            trSupplieritem("col0") = lastStockDate
            trSupplieritem("col2") = Configuration.FormatToString(sumStockAmount(0), DigitConfig.Price)
            trSupplieritem("col3") = Configuration.FormatToString(sumStockAmount(1), DigitConfig.Price)
            trSupplieritem("col4") = Configuration.FormatToString(sumStockAmount(2), DigitConfig.Price)
            trSupplieritem("col5") = Configuration.FormatToString(sumStockAmount(3), DigitConfig.Price)
            trSupplieritem("col6") = Configuration.FormatToString(sumStockAmount(4), DigitConfig.Price)
            trSupplieritem("col7") = Configuration.FormatToString(sumStockAmount(5), DigitConfig.Price)
            trSupplieritem("col8") = Configuration.FormatToString(sumStockAmount(6), DigitConfig.Price)
          ElseIf m_showPeriod = 1 Then
            trSupplieritem("col0") = lastStockDate
            trSupplieritem("col2") = Configuration.FormatToString(sumStockAmount(0), DigitConfig.Price)
            trSupplieritem("col3") = Configuration.FormatToString(sumStockAmount(1), DigitConfig.Price)
            trSupplieritem("col4") = Configuration.FormatToString(sumStockAmount(2), DigitConfig.Price)
            trSupplieritem("col5") = Configuration.FormatToString(sumStockAmount(3), DigitConfig.Price)
            trSupplieritem("col6") = Configuration.FormatToString(sumStockAmount(4), DigitConfig.Price)
            trSupplieritem("col7") = Configuration.FormatToString(sumStockAmount(5), DigitConfig.Price)
            trSupplieritem("col8") = Configuration.FormatToString(sumStockAmount(6), DigitConfig.Price)
            trSupplieritem("col9") = Configuration.FormatToString(sumStockAmount(7), DigitConfig.Price)
            trSupplieritem("col10") = Configuration.FormatToString(sumStockAmount(8), DigitConfig.Price)
          ElseIf m_showPeriod = 2 Then
            trSupplieritem("col0") = lastStockDate
            trSupplieritem("col2") = Configuration.FormatToString(sumStockAmount(0), DigitConfig.Price)
            trSupplieritem("col3") = Configuration.FormatToString(sumStockAmount(1), DigitConfig.Price)
            trSupplieritem("col4") = Configuration.FormatToString(sumStockAmount(2), DigitConfig.Price)
            trSupplieritem("col5") = Configuration.FormatToString(sumStockAmount(3), DigitConfig.Price)
            trSupplieritem("col6") = Configuration.FormatToString(sumStockAmount(4), DigitConfig.Price)
            trSupplieritem("col7") = Configuration.FormatToString(sumStockAmount(5), DigitConfig.Price)
            trSupplieritem("col8") = Configuration.FormatToString(sumStockAmount(6), DigitConfig.Price)
          End If
        End If
      End If

      'สำหรับ Supplier คนสุดท้าย
      If Not trSupplier Is Nothing Then
        If m_showPeriod = 0 Then
            trSupplier("col2") = Configuration.FormatToString(sumSupplierAmount(0), DigitConfig.Price)
            trSupplier("col3") = Configuration.FormatToString(sumSupplierAmount(1), DigitConfig.Price)
            trSupplier("col4") = Configuration.FormatToString(sumSupplierAmount(2), DigitConfig.Price)
            trSupplier("col5") = Configuration.FormatToString(sumSupplierAmount(3), DigitConfig.Price)
            trSupplier("col6") = Configuration.FormatToString(sumSupplierAmount(4), DigitConfig.Price)
            trSupplier("col7") = Configuration.FormatToString(sumSupplierAmount(5), DigitConfig.Price)
            trSupplier("col8") = Configuration.FormatToString(sumSupplierAmount(6), DigitConfig.Price)
        ElseIf m_showPeriod = 1 Then
          trSupplier("col2") = Configuration.FormatToString(sumSupplierAmount(0), DigitConfig.Price)
          trSupplier("col3") = Configuration.FormatToString(sumSupplierAmount(1), DigitConfig.Price)
          trSupplier("col4") = Configuration.FormatToString(sumSupplierAmount(2), DigitConfig.Price)
          trSupplier("col5") = Configuration.FormatToString(sumSupplierAmount(3), DigitConfig.Price)
          trSupplier("col6") = Configuration.FormatToString(sumSupplierAmount(4), DigitConfig.Price)
          trSupplier("col7") = Configuration.FormatToString(sumSupplierAmount(5), DigitConfig.Price)
          trSupplier("col8") = Configuration.FormatToString(sumSupplierAmount(6), DigitConfig.Price)
          trSupplier("col9") = Configuration.FormatToString(sumSupplierAmount(7), DigitConfig.Price)
          trSupplier("col10") = Configuration.FormatToString(sumSupplierAmount(8), DigitConfig.Price)
        ElseIf m_showPeriod = 2 Then
          trSupplier("col2") = Configuration.FormatToString(sumSupplierAmount(0), DigitConfig.Price)
          trSupplier("col3") = Configuration.FormatToString(sumSupplierAmount(1), DigitConfig.Price)
          trSupplier("col4") = Configuration.FormatToString(sumSupplierAmount(2), DigitConfig.Price)
          trSupplier("col5") = Configuration.FormatToString(sumSupplierAmount(3), DigitConfig.Price)
          trSupplier("col6") = Configuration.FormatToString(sumSupplierAmount(4), DigitConfig.Price)
          trSupplier("col7") = Configuration.FormatToString(sumSupplierAmount(5), DigitConfig.Price)
          trSupplier("col8") = Configuration.FormatToString(sumSupplierAmount(6), DigitConfig.Price)
        End If
      End If

      If Not trSupplier Is Nothing Then
        trSupplier = trSupplier.Childs.Add
        trSupplier("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.Total}") '"รวม"

        trSupplier("col2") = Configuration.FormatToString(sumCol(0), DigitConfig.Price)
        trSupplier("col3") = Configuration.FormatToString(sumCol(1), DigitConfig.Price)
        trSupplier("col4") = Configuration.FormatToString(sumCol(2), DigitConfig.Price)
        trSupplier("col5") = Configuration.FormatToString(sumCol(3), DigitConfig.Price)
        trSupplier("col6") = Configuration.FormatToString(sumCol(4), DigitConfig.Price)
        trSupplier("col7") = Configuration.FormatToString(sumCol(5), DigitConfig.Price)
        If m_showPeriod = 1 Then
          trSupplier("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
          trSupplier("col9") = Configuration.FormatToString(sumCol(7), DigitConfig.Price)
          sumCol(8) = 0
          For i As Integer = 0 To 7
            sumCol(8) += sumCol(i)
          Next
          trSupplier("col10") = Configuration.FormatToString(sumCol(8), DigitConfig.Price)
        Else
          sumCol(6) = 0
          For i As Integer = 0 To 5
            sumCol(6) += sumCol(i)
          Next
          trSupplier("col8") = Configuration.FormatToString(sumCol(6), DigitConfig.Price)
        End If
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

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim colCount As Integer = 0
      If m_showPeriod = 0 Or m_showPeriod = 2 Then
        colCount = 8
      ElseIf m_showPeriod = 1 Then
        colCount = 10
      End If
      If m_showDetailInGrid = 0 Then
        colCount = colCount - 1
      End If

      widths.Add(120)
      widths.Add(200)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      'widths.Add(100)

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

