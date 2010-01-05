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
  Public Class RptAPPayment
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    'Private ShowDetailInGrid As Integer
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
      If CInt(Me.Filters(10).Value) <> 0 Then
        lkg.Rows.HeaderCount = 3
        lkg.Rows.FrozenCount = 3
      Else
        lkg.Rows.HeaderCount = 1
        lkg.Rows.FrozenCount = 1
      End If

      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Treemanager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      'ShowDetailInGrid = CInt(Me.DataSet.Tables(0).Rows(0)("ShowDetail"))
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String
      indent = Space(3)

      ' Level 1.
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.ReciveDate}")      '"วันที่ชำระ"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.DocCode}")        '"เลขที่เอกสารใบสำคัญชำระ"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.APName}")      '"ชื่อเจ้าหนี้"
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.RefDocCode}")  '"เอกสารทำรายการ"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.RefDocDate}")  '"วันที่เอกสาร"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.UnpaidAmount}")       '"ยอดตามเอกสาร"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.Gross}")      '"ยอดที่ต้องชำระ"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.WitholdingTax}")      '"ภาษีหัก ณ ที่จ่าย"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.CutPayAmt}")      '"ยอดหักจ่าย"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.Increase}")      '"ยอดเพิ่มจ่าย"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.Amount}")      '"ยอดจ่ายชำระ"
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.GlNote}")  '"หมายเหตุ"

      If CInt(Me.Filters(10).Value) <> 0 Then
        ' Level 2.
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.ReciveType}")    '"หมวดการแสดง"

        ' Level 3.
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.GlCode}")  '"ประเภทการจ่ายชำระ/เลขที่ใบสำคัญ"
        tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.DocType}")       '"ประเภทเอกสาร"
        tr("col3") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.RefDocCode}")  '"เอกสารอ้างอิง"
        tr("col4") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.DocDate}")   '"วันที่ครบกำหนด/วันที่เอกสาร"

        'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.DocGross}")       '"ยอดเงิน"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.PayAmount}")      '"จ่ายชำระ"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.GlNote}")  '"หมายเหตุ"

      End If

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt2 As DataTable = Me.DataSet.Tables(1)
      Dim dt3 As DataTable = Me.DataSet.Tables(2)

      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim indent As String = Space(3)
      Dim currDocIndex As Integer = -1
      Dim currDocId As String = ""

      Dim currRefDocIndex As Integer = -1
      Dim currRefDocId As String = ""

      Dim trPay As TreeRow
      Dim trPayType As TreeRow
      Dim trDoc As TreeRow
      Dim trPayitem As TreeRow
      Dim trRefDocitem As TreeRow

      Dim sumStockAmt As Decimal = 0
      Dim sumBilledAmt As Decimal = 0
      Dim sumWHTAmt As Decimal = 0
      Dim sumDeCreaseAmt As Decimal = 0
      Dim sumInCreaseAmt As Decimal = 0
      Dim sumPaymentAmt As Decimal = 0

      For Each row As DataRow In dt.Rows

        trPay = Me.m_treemanager.Treetable.Childs.Add
        If CInt(Me.Filters(10).Value) <> 0 Then
          trPay.Tag = "Font.Bold"
        End If
        If Not row.IsNull("payment_docdate") Then
          If IsDate(row("payment_docdate")) Then
            trPay("col0") = CDate(row("payment_docdate")).ToShortDateString
          End If
        End If
        If Not row.IsNull("payment_code") Then
          trPay("col1") = row("payment_code")
        End If
        If Not row.IsNull("supplier_name") Then
          trPay("col2") = row("supplier_name")  'row("SupplierCode") & ":" & row("SupplierName")
        End If
        If Not row.IsNull("payment_refDocCode") Then
          trPay("col3") = row("payment_refDocCode")
        End If
        If Not row.IsNull("payment_refDocDate") Then
          If IsDate(row("payment_refDocDate")) Then
            trPay("col4") = CDate(row("payment_refDocDate")).ToShortDateString
          End If
        End If
        'If Not row.IsNull("RefType") Then
        '  If CInt(row("RefType")).Equals(73) Then
        '    If IsNumeric(row("TotalUnpaidAmt")) Then
        '      trPay("col5") = Configuration.FormatToString(CDec(row("TotalUnpaidAmt")), DigitConfig.Price)
        '    End If
        '  Else
        '    If IsNumeric(row("Gross")) Then
        '      trPay("col5") = Configuration.FormatToString(CDec(row("Gross")), DigitConfig.Price)
        '    End If
        '  End If
        'End If
        If CInt(row("payment_refDocType")) = 73 Then
          Dim sumRefDocStockAmt As Decimal = 0
          Dim sumRefDocBillAmt As Decimal = 0
          For Each refDocItem As DataRow In dt3.Select("paysi_pays=" & row("payment_refDoc").ToString)
            If Not refDocItem.IsNull("stock_aftertax") Then
              sumRefDocStockAmt += CDec(refDocItem("stock_aftertax"))
            End If
            If Not refDocItem.IsNull("paysi_billedamt") Then
              sumRefDocBillAmt += CDec(refDocItem("paysi_billedamt"))
            End If
          Next
          trPay("col5") = Configuration.FormatToString(sumRefDocStockAmt, DigitConfig.Price)
          trPay("col6") = Configuration.FormatToString(sumRefDocBillAmt, DigitConfig.Price)
          sumStockAmt += sumRefDocStockAmt
          sumBilledAmt += sumRefDocBillAmt
        Else
          If IsNumeric(row("stock_aftertax")) Then
            trPay("col5") = Configuration.FormatToString(CDec(row("stock_aftertax")), DigitConfig.Price)
            sumStockAmt += CDec(row("stock_aftertax"))
          End If
          If IsNumeric(row("payment_gross")) Then
            trPay("col6") = Configuration.FormatToString(CDec(row("payment_gross")), DigitConfig.Price)
            sumBilledAmt += CDec(row("payment_gross"))
          End If
          'sumRefDocAmt += CDec(row("stock_aftertax"))
          'trReceive("col6") = Configuration.FormatToString(CDec(row("receive_amt")), DigitConfig.Price)
          'sumPaysAmount += CDec(row("receive_amt"))
        End If
        If IsNumeric(row("payment_WitholdingTax")) Then
          trPay("col7") = Configuration.FormatToString(CDec(row("payment_WitholdingTax")), DigitConfig.Price)
          sumWHTAmt += CDec(row("payment_WitholdingTax"))
        End If
        If IsNumeric(row("deCrease")) Then
          trPay("col8") = Configuration.FormatToString(CDec(row("deCrease")), DigitConfig.Price)
          sumDeCreaseAmt += CDec(row("deCrease"))
        End If
        If IsNumeric(row("inCrease")) Then
          trPay("col9") = Configuration.FormatToString(CDec(row("inCrease")), DigitConfig.Price)
          sumInCreaseAmt += CDec(row("inCrease"))
        End If
        If IsNumeric(row("payment_gross")) Then
          trPay("col10") = Configuration.FormatToString(CDec(row("payment_gross")), DigitConfig.Price)
          sumPaymentAmt += CDec(row("payment_gross"))
        End If
        If Not row.IsNull("Note") Then
          trPay("col11") = row("Note")
        End If

        If CInt(Me.Filters(10).Value) <> 0 Then
          trPay.State = RowExpandState.Expanded

          trPayType = trPay.Childs.Add
          trPayType("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.PaymentType}")     '"ปรเภทการจ่ายชำระ"

          trDoc = trPay.Childs.Add
          trDoc("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.RefDocPayment}") '"เอกสารอ้างอิงการชำระ" 

          For Each prow As DataRow In dt2.Select("paymenti_payment =" & row("payment_id").ToString)
            trPayitem = trPayType.Childs.Add
            If Not prow.IsNull("code_description") Then
              trPayitem("col1") = prow("code_description")
            End If
            If Not prow.IsNull("EntityCode") Then
              trPayitem("col2") = indent & indent & prow("EntityCode").ToString
            End If
            If Not prow.IsNull("BankAcctCode") Then
              trPayitem("col3") = indent & indent & prow("BankAcctCode").ToString
            End If

            If Not prow.IsNull("EntityDueDate") Then
              If IsDate(prow("EntityDueDate")) Then
                trPayitem("col4") = indent & indent & CDate(prow("EntityDueDate")).ToShortDateString
              End If
            End If
            If Not prow.IsNull("EntityRefPayAmt") Then
              trPayitem("col5") = Configuration.FormatToString(CDec(prow("EntityRefPayAmt")), DigitConfig.Price)
            End If
            If IsNumeric(prow("EntityPayAmt")) Then
              trPayitem("col6") = Configuration.FormatToString(CDec(prow("EntityPayAmt")), DigitConfig.Price)
            End If
            If IsNumeric(prow("EntityPayAmt")) Then
              trPayitem("col10") = Configuration.FormatToString(CDec(prow("EntityPayAmt")), DigitConfig.Price)
            End If
          Next

          'nRefindex = 0
          If Not row.IsNull("payment_refDocType") Then
            If CInt(row("payment_refDocType")).Equals(73) Then
              For Each drow As DataRow In dt3.Select("paysi_pays = " & row("payment_refDoc").ToString)
                trRefDocitem = trDoc.Childs.Add
                If Not drow.IsNull("IglCode") Then
                  trRefDocitem("col1") = drow("IglCode")
                End If
                If Not drow.IsNull("entity_description") Then
                  trRefDocitem("col2") = indent & indent & drow("entity_description").ToString
                End If
                If Not drow.IsNull("DocCode") Then
                  trRefDocitem("col3") = drow("DocCode")
                End If
                If IsDate(drow("stock_docdate")) Then
                  trRefDocitem("col4") = indent & indent & CDate(drow("stock_docdate")).ToShortDateString
                End If
                If IsNumeric(drow("stock_aftertax")) Then
                  trRefDocitem("col5") = Configuration.FormatToString(CDec(drow("stock_aftertax")), DigitConfig.Price)
                End If
                If IsNumeric(drow("paysi_billedamt")) Then
                  trRefDocitem("col5") = Configuration.FormatToString(CDec(drow("paysi_billedamt")), DigitConfig.Price)
                End If
                If IsNumeric(drow("paysi_amt")) Then
                  trRefDocitem("col6") = Configuration.FormatToString(CDec(drow("paysi_amt")), DigitConfig.Price)
                End If
                If Not drow.IsNull("Note") Then
                  trRefDocitem("col11") = drow("Note").ToString
                End If
              Next
            Else
              trRefDocitem = trDoc.Childs.Add
              If Not row.IsNull("payment_code") Then
                trRefDocitem("col1") = row("payment_code")
              End If
              If Not row.IsNull("entity_description") Then
                trRefDocitem("col2") = indent & indent & row("entity_description").ToString
              End If
              If Not row.IsNull("payment_refDocCode") Then
                trRefDocitem("col3") = row("payment_refDocCode")
              End If
              If Not row.IsNull("payment_refdocdate") Then
                If IsDate(row("payment_refdocdate")) Then
                  trRefDocitem("col4") = indent & indent & CDate(row("payment_refdocdate")).ToShortDateString
                End If
              End If
              If IsNumeric(row("payment_gross")) Then
                trRefDocitem("col5") = Configuration.FormatToString(CDec(row("payment_gross")), DigitConfig.Price)
              End If
              If IsNumeric(row("payment_amt")) Then
                trRefDocitem("col6") = Configuration.FormatToString(CDec(row("payment_amt")), DigitConfig.Price)
              End If
            End If
          End If
        End If
      Next

      trPay = Me.m_treemanager.Treetable.Childs.Add
      trPay.Tag = "Font.Bold"
      trPay("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.Total}") '"รวม"
            'trPay("col5") = Configuration.FormatToString(sumStockAmt, DigitConfig.Price)
            'trPay("col6") = Configuration.FormatToString(sumBilledAmt, DigitConfig.Price)
            'trPay("col7") = Configuration.FormatToString(sumWHTAmt, DigitConfig.Price)
            'trPay("col8") = Configuration.FormatToString(sumDeCreaseAmt, DigitConfig.Price)
            'trPay("col9") = Configuration.FormatToString(sumInCreaseAmt, DigitConfig.Price)
      trPay("col10") = Configuration.FormatToString(sumPaymentAmt, DigitConfig.Price)

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

      widths.Add(80)
      widths.Add(205)
      widths.Add(170)
      widths.Add(150)
      widths.Add(120)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)
      widths.Add(180)

      For i As Integer = 0 To 11
        If i = 1 Then
          If CInt(Me.Filters(10).Value) <> 0 Then
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
            'Dim cs As New PlusMinusTreeTextColumn
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
          Select Case i
            Case 0, 1, 2, 3, 4, 11
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
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPPayment"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPPayment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPPayment"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.ListLabel}"
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
      Return "RptAPPayment"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAPPayment"
    End Function
    Dim SumPayAmt As Decimal = 0
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

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

      'supplier start
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierstart"
      If Not IsDBNull(Filters(2).Value) Then
        dpi.Value = CStr((Filters(2).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'supplier end
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierend"
      If Not IsDBNull(Filters(3).Value) Then
        dpi.Value = CStr((Filters(3).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ChildInclude
      dpi = New DocPrintingItem
      dpi.Mapping = "IncludeChildCC"
      If Not IsDBNull(Filters(5).Value) Then
        dpi.Value = "(รวมในสังกัด)"
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CheckBox ShowDetail
      dpi = New DocPrintingItem
      dpi.Mapping = "ShowDetail"
      If Not IsDBNull(Filters(10).Value) Then
        dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPPayment.ShowDetail}") 'ShowDetail
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim SumAmt As Decimal = 0
      Dim SumDecsAmt As Decimal = 0

      Dim fn As Font
      Dim n As Integer = 0
      Dim nStart As Integer = 0
      If CInt(Me.Filters(10).Value) = 0 Then
        nStart = 2
      Else
        nStart = 4
      End If
      For rowIndex As Integer = nStart To m_grid.RowCount
        If Not CType(Me.Treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
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

