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
  Public Class Rpt275
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
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 0
      m_grid.ColCount = 16

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 120
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 0
      m_grid.Rows.FrozenCount = 0

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.DocNumber}")       '"เลขที่เอกสาร"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.po_docDate}")      '"วันที่สั่งซื้อ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.supplierinfo}")    '"ผู้ขาย"    
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.ccinfo}")          '"Cost Center "
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.DateReceive}")     '"วันที่รับของ"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.beforetax}")          '"ยอดก่อนภาษี"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.tax}")             '"ภาษี"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.aftertax}")          '"ยอดรวมภาษี"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.postatusinfo}")    '"ผู้อนุมัติ"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.referable}")      '"หมายเหตุ"
      m_grid(0, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.note}")           '"วันที่อนุมัติ"
      m_grid(0, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.PRcode}")         '"สถานะการสั่งซื้อ"
      m_grid(0, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.po_note}")        '"รหัสใบสั่งซื้อ"
      m_grid(0, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.closestatus}")    '"สถานะการเปิด PO"
      m_grid(0, 15).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.refstatus}")      '"อ้างอิง"
      m_grid(0, 16).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.DueDate}")      '"วันที่ครบกำหนด"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)

      Dim currTrIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)

      Dim SumAmount As Decimal = 0
      Dim SumTaxAmt As Decimal = 0
      Dim SumAfterTax As Decimal = 0


      Dim n As Int32 = 0

      For Each row As DataRow In dt.Rows
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        m_grid(currItemIndex, 1).CellValue = row("po_code")
        If Not row.IsNull("po_docDate") Then
          m_grid(currItemIndex, 2).CellValue = CDate(row("po_docDate")).ToShortDateString
        End If
        If Not row.IsNull("supplierinfo") Then
          m_grid(currItemIndex, 3).CellValue = row("supplierinfo").ToString
        End If
        If Not row.IsNull("ccinfo") Then
          m_grid(currItemIndex, 4).CellValue = row("ccinfo").ToString
        End If
        If Not row.IsNull("Po_ReceivingDate") Then
          m_grid(currItemIndex, 5).CellValue = CDate(row("Po_ReceivingDate")).ToShortDateString
        End If
        'If IsNumeric(rowitem("Amount")) Then
        '    m_grid(currItemIndex, 7).CellValue = indent & Configuration.FormatToString(CDec(rowitem("Amount")), DigitConfig.Price)
        '    tmpEachAmount += CDec(rowitem("Amount"))
        '    tmpAmount += CDec(rowitem("Amount"))
        '    SumAmount += CDec(rowitem("Amount"))
        'End If
        If Not row.IsNull("Po_gross") Then
          m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Po_beforetax")), DigitConfig.Price)
          SumAmount += CDec(row("Po_beforetax"))
        End If
        If Not row.IsNull("Po_taxamt") Then
          m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Po_taxamt")), DigitConfig.Price)
          SumTaxAmt += CDec(row("Po_taxamt"))
        End If
        If Not row.IsNull("Po_aftertax") Then
          m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("Po_aftertax")), DigitConfig.Price)
          SumAfterTax += CDec(row("Po_aftertax"))
        End If
        m_grid(currItemIndex, 9).CellValue = row("approvepersoninfo").ToString
        If Not row.IsNull("po_approvedate") Then
          m_grid(currItemIndex, 10).CellValue = CDate(row("po_approvedate")).ToShortDateString
        End If
        m_grid(currItemIndex, 11).CellValue = row("postatusinfo").ToString
        m_grid(currItemIndex, 12).CellValue = row("PRcode").ToString
        m_grid(currItemIndex, 13).CellValue = row("po_note").ToString
        m_grid(currItemIndex, 14).CellValue = row("closestatus").ToString
        m_grid(currItemIndex, 15).CellValue = row("refstatus").ToString
        If row("po_status").ToString = "0" Then
          m_grid(currItemIndex, 11).CellValue = row("postatusinfo").ToString
        End If
        m_grid(currItemIndex, 16).CellValue = CDate(row("duedate")).ToShortDateString

      Next
      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currTrIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt275.SumAll}") 'รวม
      m_grid(currTrIndex, 6).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price) 'ยอดเงิน
      m_grid(currTrIndex, 7).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price) 'ยอดภาษี
      m_grid(currTrIndex, 8).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price) 'ยอดรวมภาษี 
      m_grid(currTrIndex, 1).Tag = "Group Level"

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Rpt275"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt275.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt275"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt275"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt275.ListLabel}"
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
      Return "Rpt275"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "Rpt275"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim LineNumber As Integer = 0

      Dim n As Integer = 0
      Dim i As Integer = 0
      For rowIndex As Integer = 1 To m_grid.RowCount
        i += 1
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = i
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid(rowIndex, 2).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid(rowIndex, 3).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 4).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 5).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 6).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 7).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 8).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'เอาไว้ดูว่า Row ไหนมาจากการ Sum
        dpi = New DocPrintingItem
        dpi.Mapping = "Group Level"
        If rowIndex = m_grid.RowCount Then
          dpi.Value = m_grid(rowIndex, 8).CellValue
        Else
          dpi.Value = 0
        End If
        dpi.DataType = "System.Integer"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 9).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 10).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col10"
        dpi.Value = m_grid(rowIndex, 11).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 12).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col12"
        dpi.Value = m_grid(rowIndex, 13).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col13"
        dpi.Value = m_grid(rowIndex, 14).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col14"
        dpi.Value = m_grid(rowIndex, 15).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col15"
        dpi.Value = m_grid(rowIndex, 16).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)


        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace
