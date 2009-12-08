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
    Public Class RptARReceive
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
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
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      If CInt(Me.Filters(7).Value) <> 0 Then
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
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.ReciveDate}")    '"วันที่ชำระ"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.DocCode}")     '"เลขที่เอกสารชำระ"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.ARName}")   '"ชื่อลูกหนี้"
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.RefDocNO}")  '"เอกสารอ้างอิง"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.RefDocDate}")  '"วันที่เอกสารอ้างอิง"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.StockAmount}")   '"ยอดตามเอกสารอ้างอิง"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.Gross}")   '"ยอดที่ต้องชำระ"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.WitholdingTax}")   '"ภาษีถูกหัก ณ ที่รับ"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.Decrease}")    '"ยอดหักรับ"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.Increase}")   '"ยอดเพิ่มรับ"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.Amount}")   '"ยอดรับชำระ"

      If CInt(Me.Filters(7).Value) <> 0 Then
        ' Level 2.
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr.Tag = ""
        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.ExperenceType}")   '"หมวดการแสดง"

        ' Level 3.
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.DocNO}")   '"ประเภทการรับชำระ/เอกสารอ้างอิง"
        tr("col2") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.DocType}")    '"เลขที่/ประเภทเอกสาร"
        tr("col3") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.BankAccount}")    '"เลขที่สมุดบัญชี"
        tr("col4") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.DocDate}")   '"วันที่ครบกำหนด/วันที่เอกสาร"

        'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.DocGross}")    '"ยอดเงิน"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.ReceiveAmount}")    '"รับชำระ"

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

      Dim trReceive As TreeRow
      Dim trReceiveType As TreeRow
      Dim trDoc As TreeRow
      Dim trReceiveitem As TreeRow
      Dim trRefDocitem As TreeRow

      Dim sumRefDocAmt As Decimal = 0
      Dim sumPaysAmount As Decimal = 0
      Dim sumWHT As Decimal = 0
      Dim sumDecrease As Decimal = 0
      Dim sumIncrease As Decimal = 0
      Dim sumPaysGross As Decimal = 0

      For Each row As DataRow In dt.Rows

        trReceive = Me.m_treemanager.Treetable.Childs.Add
        If CInt(Me.Filters(7).Value) <> 0 Then
          trReceive.Tag = "Font.Bold"
        End If
        If Not row.IsNull("receive_DocDate") Then
          If IsDate(row("receive_DocDate")) Then
            trReceive("col0") = CDate(row("receive_DocDate")).ToShortDateString
          End If
        End If
        If Not row.IsNull("receive_Code") Then
          trReceive("col1") = row("receive_Code")
        End If
        If Not row.IsNull("Cust_Name") Then
          trReceive("col2") = row("Cust_Name")  'row("SupplierCode") & ":" & row("SupplierName")
        End If
        If Not row.IsNull("receive_RefDocCode") Then
          trReceive("col3") = row("receive_RefDocCode")
        End If
        If IsDate(row("receive_RefDocDate")) Then
          trReceive("col4") = CDate(row("receive_RefDocDate")).ToShortDateString
        End If
        If CInt(row("receive_refDocType")) = 82 Then
          Dim sumRefDocStockAmt As Decimal = 0
          Dim sumRefDocBillAmt As Decimal = 0
          For Each refDocItem As DataRow In dt3.Select("receivesi_receives=" & row("receive_refDoc").ToString)
            If Not refDocItem.IsNull("stock_aftertax") Then
              sumRefDocStockAmt += CDec(refdocitem("stock_aftertax"))
            End If
            If Not refDocItem.IsNull("receivesi_billedamt") Then
              sumRefDocBillAmt += CDec(refdocitem("receivesi_billedamt"))
            End If
          Next
          trReceive("col5") = Configuration.FormatToString(sumRefDocStockAmt, DigitConfig.Price)
          trReceive("col6") = Configuration.FormatToString(sumRefDocBillAmt, DigitConfig.Price)
          sumRefDocAmt += sumRefDocStockAmt
          sumPaysAmount += sumRefDocBillAmt
        Else
          trReceive("col5") = Configuration.FormatToString(CDec(row("stock_aftertax")), DigitConfig.Price)
          sumRefDocAmt += CDec(row("stock_aftertax"))
          trReceive("col6") = Configuration.FormatToString(CDec(row("receive_amt")), DigitConfig.Price)
          sumPaysAmount += CDec(row("receive_amt"))
        End If
        If IsNumeric(row("receive_WitholdingTax")) Then
          trReceive("col7") = Configuration.FormatToString(CDec(row("receive_WitholdingTax")), DigitConfig.Price)
          sumWHT += CDec(row("receive_WitholdingTax"))
        End If
        If IsNumeric(row("DeCrease")) Then
          trReceive("col8") = Configuration.FormatToString(CDec(row("DeCrease")), DigitConfig.Price)
          sumDecrease += CDec(row("DeCrease"))
        End If
        If IsNumeric(row("InCrease")) Then
          trReceive("col9") = Configuration.FormatToString(CDec(row("InCrease")), DigitConfig.Price)
          sumIncrease += CDec(row("InCrease"))
        End If
        If IsNumeric(row("receive_gross")) Then
          trReceive("col10") = Configuration.FormatToString(CDec(row("receive_gross")), DigitConfig.Price)
          sumPaysGross += CDec(row("receive_gross"))
        End If

        If CInt(Me.Filters(7).Value) <> 0 Then
          trReceive.State = RowExpandState.Expanded

          trReceiveType = trReceive.Childs.Add
          trReceiveType("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.PaymentType}") '"ปรเภทการรับชำระ"

          trDoc = trReceive.Childs.Add
          trDoc("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.RefDocPayment}") '"เอกสารอ้างอิงการชำระ" 

          For Each paysItem As DataRow In dt2.Select("receivei_receive=" & row("receive_id").ToString)
            trReceiveitem = trReceiveType.Childs.Add
            If Not paysItem.IsNull("code_description") Then
              trReceiveitem("col1") = paysItem("code_description")
            End If
            If Not paysItem.IsNull("EntityCode") Then
              trReceiveitem("col2") = indent & indent & paysItem("EntityCode").ToString
            End If
            If Not paysItem.IsNull("BankAcctCode") Then
              If paysItem("BankAcctCode").ToString.IndexOf(":") >= 1 And paysItem("BankAcctCode").ToString.Length > 1 Then
                trReceiveitem("col3") = indent & indent & paysItem("BankAcctCode").ToString
              End If
            End If

            If IsDate(paysItem("EntityDueDate")) Then
              trReceiveitem("col4") = indent & indent & CDate(paysItem("EntityDueDate")).ToShortDateString
            End If
            If IsNumeric(paysItem("EntityPayAmt")) Then
              trReceiveitem("col5") = Configuration.FormatToString(CDec(paysItem("EntityPayAmt")), DigitConfig.Price)
            End If
            If IsNumeric(paysItem("EntityPayAmt")) Then
              trReceiveitem("col6") = Configuration.FormatToString(CDec(paysItem("EntityPayAmt")), DigitConfig.Price)
            End If
            If IsNumeric(paysItem("EntityPayAmt")) Then
              trReceiveitem("col10") = Configuration.FormatToString(CDec(paysItem("EntityPayAmt")), DigitConfig.Price)
            End If
          Next

          'nRefindex = 0
          If Not row.IsNull("receive_refDocType") Then
            If CInt(row("receive_refDocType")).Equals(82) Then
              For Each refDocItem As DataRow In dt3.Select("receivesi_receives=" & row("receive_refDoc").ToString)
                trRefDocitem = trDoc.Childs.Add
                If Not refDocItem.IsNull("DocCode") Then
                  trRefDocitem("col1") = refDocItem("DocCode").toString
                End If
                If Not refDocItem.IsNull("entity_description") Then
                  trRefDocitem("col2") = indent & indent & refDocItem("entity_description").toString
                End If
                If IsDate(refDocItem("stock_docdate")) Then
                  trRefDocitem("col4") = indent & indent & CDate(refDocItem("stock_docdate")).ToShortDateString
                End If
                If IsNumeric(refDocItem("stock_aftertax")) Then
                  trRefDocitem("col5") = Configuration.FormatToString(CDec(refDocItem("stock_aftertax")), DigitConfig.Price)
                End If
                If IsNumeric(refDocItem("receivesi_billedamt")) Then
                  trRefDocitem("col6") = Configuration.FormatToString(CDec(refDocItem("receivesi_billedamt")), DigitConfig.Price)
                End If
                If IsNumeric(refDocItem("receivesi_amt")) Then
                  trRefDocitem("col10") = Configuration.FormatToString(CDec(refDocItem("receivesi_amt")), DigitConfig.Price)
                End If
              Next
            Else
              trRefDocitem = trDoc.Childs.Add
              If Not row.IsNull("receive_refdocCode") Then
                trRefDocitem("col1") = row("receive_refdocCode").ToString
              End If
              If Not row.IsNull("entity_description") Then
                trRefDocitem("col2") = indent & indent & row("entity_description").ToString
              End If
              If IsDate(row("receive_refdocdate")) Then
                trRefDocitem("col4") = indent & indent & CDate(row("receive_refdocdate")).ToShortDateString
              End If
              If IsNumeric(row("receive_amt")) Then
                trRefDocitem("col5") = Configuration.FormatToString(CDec(row("receive_amt")), DigitConfig.Price)
              End If
              If IsNumeric(row("receive_amt")) Then
                trRefDocitem("col6") = Configuration.FormatToString(CDec(row("receive_amt")), DigitConfig.Price)
              End If
            End If
          End If
        End If
      Next

      trReceive = Me.m_treemanager.Treetable.Childs.Add
      trReceive.Tag = "Font.Bold"
      trReceive("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.Total}") '"รวม"
      trReceive("col5") = Configuration.FormatToString(sumRefDocAmt, DigitConfig.Price)
      trReceive("col6") = Configuration.FormatToString(sumPaysAmount, DigitConfig.Price)
      trReceive("col7") = Configuration.FormatToString(sumWHT, DigitConfig.Price)
      trReceive("col8") = Configuration.FormatToString(sumDecrease, DigitConfig.Price)
      trReceive("col9") = Configuration.FormatToString(sumIncrease, DigitConfig.Price)
      trReceive("col10") = Configuration.FormatToString(sumPaysGross, DigitConfig.Price)

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
      widths.Add(180)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)
      widths.Add(105)

      For i As Integer = 0 To 10
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
            Case 0, 1, 2, 3, 4
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
        Return "RptARReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptARReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptARReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARReceive.ListLabel}"
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
      Return "RptARReceive"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptARReceive"
    End Function
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

      'CheckBox ChildInclude
      dpi = New DocPrintingItem
      dpi.Mapping = "IncludeChildCC"
      If Not IsDBNull(Filters(5).Value) Then
        dpi.Value = "(รวมในสังกัด)"
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim ReceiveGross As Decimal = 0
      Dim Gross As Decimal = 0
      Dim WitholdingTax As Decimal = 0
      Dim Revenue As Decimal = 0
      Dim Discount As Decimal = 0
      Dim ReceiveAmount As Decimal = 0

      Dim n As Integer = 0
      Dim i As Integer = 0
      Dim fn As Font
      Dim startRow As Integer = 2
      If CInt(Me.Filters(7).Value) <> 0 Then
        startRow = 4
      End If
      For rowIndex As Integer = startRow To m_grid.RowCount

        'If IsDate(Me.m_grid(rowIndex, 1).CellValue) Then
        If Not CType(Me.Treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'MessageBox.Show("Bold: " & CType(Me.m_treemanager.Treetable.Rows(n), TreeRow)(1).ToString)
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          'MessageBox.Show("Regular: " & CType(Me.m_treemanager.Treetable.Rows(n), TreeRow)(1).ToString)
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
