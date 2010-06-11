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
  Public Class RptARGoodsSoldByBillIssue
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
      m_grid.BeginUpdate()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      m_grid.Model.Options.NumberedColHeaders = False
      m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      m_grid.HorizontalThumbTrack = True
      m_grid.VerticalThumbTrack = True
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 14

      m_grid.ColWidths(1) = 90
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 20
      m_grid.ColWidths(5) = 320
      m_grid.ColWidths(6) = 80
      m_grid.ColWidths(7) = 80
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100
      m_grid.ColWidths(12) = 100
      m_grid.ColWidths(13) = 100
      m_grid.ColWidths(14) = 200

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.BillAcceptanceDate}")   '"วันที่ใบรับวางบิล"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.BillAcceptanceID}")   '"รหัสใบรับวางบิล"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.SupplierID}")  '"รหัสผู้ขาย"
      m_grid(0, 4).Text = ""
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.SupplierName}")   '"ชื่อผู้ขาย"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.CreditDay}")   '"เครดิต(วัน)"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.BillAcceptanceDueDate}")   '"กำหนดชำระ"
      m_grid(0, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.BillAcceptanceCost}")   '"ยอดวางบิล"
      m_grid(0, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.Note}")   '"หมายเหตุ"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.DocDate}")   '"วันที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.DocCode}")   '"เลขที่ใบส่งสินค้า"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.VatCode}")   '"เลขที่ใบกำกับ"
      m_grid(1, 4).Text = ""
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.Description}")   '"รายการ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.Qty}")   '"จำนวน"
      m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.UnitName}")   '"หน่วย"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.UnitPrice}")   '"ราคา/หน่วย"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.Penalty}")   '"ส่วนลด"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.Amount}")   '"จำนวนเงิน"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.TaxAmount}")   '"ภาษีมูลค่าเพิ่ม"
      m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.TotalAmount}")   '"รวมเงิน"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt1 As DataTable = Me.DataSet.Tables(1)

      Dim currentBilla As String = ""
      Dim billaIndex As Integer = 0
      Dim currentGR As String = ""
      Dim GRIndex As Integer = 0
      Dim drh As DataRowHelper
      Dim drh1 As DataRowHelper
      Dim index As Integer = 0
      Dim indent As String = Space(3)

      For Each row As DataRow In dt.Rows
        drh = New DataRowHelper(row)

        If drh.GetValue(Of String)("salebilli_code") <> currentBilla Then

          m_grid.RowCount += 1
          billaIndex = m_grid.RowCount
          m_grid.RowStyles(billaIndex).Font.Bold = True
          m_grid.RowStyles(billaIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid(billaIndex, 1).CellValue = drh.GetValue(Of DateTime)("salebilli_docdate").ToShortDateString
          m_grid(billaIndex, 2).CellValue = drh.GetValue(Of String)("salebilli_code")
          m_grid(billaIndex, 3).CellValue = drh.GetValue(Of String)("customer_code")
          m_grid(billaIndex, 5).CellValue = drh.GetValue(Of String)("customer_name")
          m_grid(billaIndex, 6).CellValue = Configuration.FormatToString(drh.GetValue(Of Integer)("salebilli_creditPeriod"), DigitConfig.Int)
          m_grid(billaIndex, 7).CellValue = drh.GetValue(Of DateTime)("duedate").ToShortDateString
          m_grid(billaIndex, 13).CellValue = Configuration.FormatToString(drh.GetValue(Of Decimal)("salebilli_gross"), DigitConfig.Price)
          m_grid(billaIndex, 1).Tag = "Font.Bold"
          'm_grid.ColStyles(12).ReadOnly = False

          currentBilla = drh.GetValue(Of String)("salebilli_code")
        End If

        For Each row1 As DataRow In dt1.Select("stock_id=" & drh.GetValue(Of String)("salebillii_stockid") & _
                                               " and stock_type=" & drh.GetValue(Of String)("salebillii_stocktype"))
          drh1 = New DataRowHelper(row1)
          m_grid.RowCount += 1
          GRIndex = m_grid.RowCount
          m_grid(GRIndex, 1).CellValue = indent & drh1.GetValue(Of DateTime)("stock_docdate").ToShortDateString
          m_grid(GRIndex, 2).CellValue = indent & drh1.GetValue(Of String)("stock_code")
          m_grid(GRIndex, 3).CellValue = indent & drh1.GetValue(Of String)("vatCode")
          m_grid(GRIndex, 4).CellValue = Configuration.FormatToString(drh1.GetValue(Of Integer)("stocki_linenumber"), DigitConfig.Int)
          m_grid(GRIndex, 5).CellValue = indent & drh1.GetValue(Of String)("itemCode") & _
                                                  IIf(drh1.GetValue(Of String)("itemCode").Length > 0, " : ", "") & _
                                                  drh1.GetValue(Of String)("itemName")
          m_grid(GRIndex, 6).CellValue = Configuration.FormatToString(drh1.GetValue(Of Integer)("stocki_qty"), DigitConfig.Qty)
          m_grid(GRIndex, 7).CellValue = indent & drh1.GetValue(Of String)("unit_name")
          m_grid(GRIndex, 8).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("stocki_unitPrice"), DigitConfig.Price)
          m_grid(GRIndex, 9).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("stocki_discamt"), DigitConfig.Price)
          m_grid(GRIndex, 10).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("stocki_amt"), DigitConfig.Price)
          m_grid(GRIndex, 11).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("taxamt"), DigitConfig.Price)
          m_grid(GRIndex, 12).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("stocki_amt") + drh1.GetValue(Of Decimal)("taxamt"), DigitConfig.Price)
        Next

        m_grid.RowCount += 1
        GRIndex = m_grid.RowCount
        m_grid.RowStyles(GRIndex).Font.Bold = True
        m_grid(GRIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.Total}") ' "รวม"
        m_grid(GRIndex, 10).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("stock_gross"), DigitConfig.Price)
        m_grid(GRIndex, 11).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("grosstaxamt"), DigitConfig.Price)
        m_grid(GRIndex, 12).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("stock_gross") + drh1.GetValue(Of Decimal)("grosstaxamt"), DigitConfig.Price)
        m_grid(GRIndex, 1).Tag = "Font.Bold"

        m_grid.RowCount += 1
        GRIndex = m_grid.RowCount
        m_grid.RowStyles(GRIndex).Font.Bold = True
        m_grid(GRIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.TotalWithDeduct}") & " " & _
        Configuration.FormatToString(drh1.GetValue(Of Decimal)("descreaseAmt"), DigitConfig.Price) '"รวมหัก (ส่วนลด, มัดจำ)
        m_grid(GRIndex, 10).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("GrossWithDeduct"), DigitConfig.Price)
        m_grid(GRIndex, 11).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("GrossWithDeductTaxAmt"), DigitConfig.Price)
        m_grid(GRIndex, 12).CellValue = Configuration.FormatToString(drh1.GetValue(Of Decimal)("GrossWithDeduct") + drh1.GetValue(Of Decimal)("GrossWithDeductTaxAmt"), DigitConfig.Price)
        m_grid(GRIndex, 13).CellValue = Configuration.FormatToString(drh.GetValue(Of Decimal)("salebillii_amt"), DigitConfig.Price)
        m_grid(GRIndex, 1).Tag = "Font.Bold"

      Next

      'm_grid.RowCount += 1
      'GRIndex = m_grid.RowCount
      'm_grid.RowStyles(GRIndex).ReadOnly = True
      'm_grid(GRIndex, 4).CellValue = "รวม"
      'm_grid(GRIndex, 4).CellValue = "ยอดตามเอกสารซื้อสินค้า/บริการ หัก (ส่วนลด, มัดจำ, Retention) "
      'm_grid(GRIndex, 10).CellValue = Configuration.FormatToString(drh.GetValue(Of Decimal)("stock_gross"), DigitConfig.Price)
      'm_grid(GRIndex, 11).CellValue = Configuration.FormatToString(drh.GetValue(Of Decimal)("billai_amt"), DigitConfig.Price)

      For i As Integer = 1 To m_grid.ColCount - 1
        m_grid.ColStyles(i).ReadOnly = True
      Next

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptARGoodsSoldByBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptARGoodsSoldByBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptARGoodsSoldByBillIssue"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARGoodsSoldByBillIssue.ListLabel}"
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
      Return "RptARGoodsSoldByBillIssue"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptARGoodsSoldByBillIssue"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim fn As Font ' New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      For rowIndex As Integer = 2 To m_grid.RowCount
        If Not Me.m_grid(rowIndex, 1).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If
        For colIndex As Integer = 1 To m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & (colIndex - 1).ToString
          dpi.Value = m_grid(rowIndex, colIndex).CellValue
          dpi.DataType = "System.String"
          dpi.Font = fn
          dpi.Row = rowIndex - 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

