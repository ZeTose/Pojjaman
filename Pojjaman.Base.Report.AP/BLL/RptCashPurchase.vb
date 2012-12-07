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
  Public Class RptCashPurchase
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
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      m_grid.BeginUpdate()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      m_grid.Model.Options.NumberedColHeaders = False
      m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim dr As DataRow = CType(Me.m_grid(e.RowIndex, 0).Tag, DataRow)
      If dr Is Nothing Then
        Return
      End If
      Dim drh As New DataRowHelper(dr)
      Dim docId As Integer = drh.GetValue(Of Integer)("stock_id")
      Dim docType As Integer = drh.GetValue(Of Integer)("stock_type")

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 0
      m_grid.ColCount = 18

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 220
      m_grid.ColWidths(6) = 100 '"ยอดรวม"
      m_grid.ColWidths(7) = 100 '"ภาษี"
      m_grid.ColWidths(8) = 100 '"ยอดปรับปรุงจำนวนจ่าย"
      m_grid.ColWidths(9) = 100 '"ยอดรวมภาษี"
      m_grid.ColWidths(10) = 100 '"รหัส Cost Center"
      m_grid.ColWidths(11) = 200 '"Cost Center รับ"
      m_grid.ColWidths(12) = 100 '"เครดิต"
      m_grid.ColWidths(13) = 100 '"ใบสำคัญจ่าย"
      m_grid.ColWidths(14) = 100 '"ใบสั่งซื้อ"
      m_grid.ColWidths(15) = 200 '"ใบขอซื้อ"
      m_grid.ColWidths(16) = 100 '"ผู้อนุมัติ"
      m_grid.ColWidths(17) = 100 '"วันที่อนุมัติ"
      m_grid.ColWidths(18) = 100 'Note


      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
   
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
  
      m_grid.ColStyles(18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 0
      m_grid.Rows.FrozenCount = 0
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.stockOtherDocCode}") '"เลขที่เอกสาร"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.tock_originDate}") '"วันที่เอกสาร"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.DueDate}") '"วันที่ครบกำหนด"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.supplierCode}") '"รหัสผู้ขาย"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.supplierName}") '"ชื่อผู้ขาย"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.Total}") '"ยอดรวม"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.Tax}") '"ภาษี"
      m_grid(0, 8).Text = Me.StringParserService.Parse("ยอดปรับปรุงจำนวนจ่าย") '"ยอดปรับปรุงจำนวนจ่าย"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.TotalTax}") '"ยอดรวมภาษี"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.toccCode}") '"รหัส Cost Center"
      m_grid(0, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.toccName}") '"Cost Center รับ"
      m_grid(0, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.stock_creditPeriod}") '"เครดิต"
      m_grid(0, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.pvcode}") '"ใบสำคัญจ่าย"
      m_grid(0, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.pocode}") '"ใบสั่งซื้อ"
      m_grid(0, 15).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.prcode}") '"ใบขอซื้อ"
      m_grid(0, 16).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.lasteditorinfo}") '"ผู้อนุมัติ"
      m_grid(0, 17).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.stockApprovedate}") '"วันที่อนุมัติ"
      m_grid(0, 18).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt276.stock_note}")

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)

      Dim currTrIndex As Integer = -1
      Dim indent As String = Space(3)

      Dim Total As Decimal = 0 'รวมยอดเงิน
      Dim sumTax As Decimal = 0 'รวมภาษี
      Dim sumAdjust As Decimal = 0 'รวมยอดปรับปรุง
      Dim sumAftertax As Decimal = 0 'รวมยอดรวมภาษี 
      Dim sumRemain As Decimal = 0 'รวมยอดคงเหลือ

      Dim n As Int32 = 0
      For Each row As DataRow In dt.Rows
        m_grid.RowCount += 1
        currTrIndex = m_grid.RowCount
        m_grid(currTrIndex, 0).Tag = row
        If ((currTrIndex Mod 2) = 0) Then
          m_grid.RowStyles(currTrIndex).BackColor = Color.FromArgb(202, 220, 200)
        Else
          m_grid.RowStyles(currTrIndex).BackColor = Color.FromArgb(255, 255, 255)

        End If
        m_grid(currTrIndex, 1).CellValue = row("stock_code").ToString
        If Not row.IsNull("DocDate") Then
          m_grid(currTrIndex, 2).CellValue = CDate(row("DocDate")).ToShortDateString
        End If
        'm_grid(currTrIndex, 3).CellValue = row("stock_otherDocCode").ToString
        'If Not row.IsNull("otherdocdate") Then
        '  m_grid(currTrIndex, 4).CellValue = CDate(row("otherdocdate")).ToShortDateString
        'End If
        If Not row.IsNull("duedate") Then
          m_grid(currTrIndex, 3).CellValue = CDate(row("duedate")).ToShortDateString
        End If
        m_grid(currTrIndex, 4).CellValue = row("supplierCode").ToString
        m_grid(currTrIndex, 5).CellValue = row("supplierName").ToString
        If Not row.IsNull("BeforTax") Then
          m_grid(currTrIndex, 6).CellValue = Configuration.FormatToString(CDec(row("BeforTax")), DigitConfig.Price)
          Total += CDec(row("BeforTax"))
        End If
        If Not row.IsNull("TextAmount") Then
          m_grid(currTrIndex, 7).CellValue = Configuration.FormatToString(CDec(row("TextAmount")), DigitConfig.Price)
          sumTax += CDec(row("TextAmount"))
        End If
        If Not row.IsNull("AdjAmount") Then
          m_grid(currTrIndex, 8).CellValue = Configuration.FormatToString(CDec(row("AdjAmount")), DigitConfig.Price)
          sumAdjust += CDec(row("AdjAmount"))
        End If
        If Not row.IsNull("AfterTex") Then
          m_grid(currTrIndex, 9).CellValue = Configuration.FormatToString(CDec(row("AfterTex")), DigitConfig.Price)
          sumAftertax += CDec(row("AfterTex"))
        End If
        'If Not row.IsNull("remain") Then
        '  m_grid(currTrIndex, 12).CellValue = Configuration.FormatToString(CDec(row("remain")), DigitConfig.Price)
        '  sumRemain += CDec(row("remain"))
        'End If
        m_grid(currTrIndex, 10).CellValue = row("toccCode").ToString
        m_grid(currTrIndex, 11).CellValue = row("toccName").ToString
        m_grid(currTrIndex, 12).CellValue = row("stock_creditPeriod").ToString
        m_grid(currTrIndex, 13).CellValue = row("pvcode").ToString
        m_grid(currTrIndex, 14).CellValue = row("pocode").ToString

        Dim prCode As New ArrayList
        For Each prrow As DataRow In Me.DataSet.Tables(1).Select("stock_id=" & row("stock_id").ToString)
          prCode.Add(prrow("pr_code"))
        Next
        m_grid(currTrIndex, 15).CellValue = String.Join(",", prCode.ToArray)

        m_grid(currTrIndex, 16).CellValue = row("approveperson").ToString
        If Not row.IsNull("stock_approvedate") Then
          m_grid(currTrIndex, 17).CellValue = CDate(row("stock_approvedate")).ToShortDateString
        End If
        'm_grid(currTrIndex, 21).CellValue = row("refstatus").ToString
        'm_grid(currTrIndex, 22).CellValue = row("toccpersoninfo").ToString
        'm_grid(currTrIndex, 23).CellValue = row("GoodsReceiptStatusinfo").ToString
        If row("stock_status").ToString = "0" Then
          m_grid.RowStyles(currTrIndex).BackColor = Color.FromArgb(142, 142, 142)
        End If
        'm_grid(currTrIndex, 24).CellValue = row("supplieraddress").ToString
        'm_grid(currTrIndex, 25).CellValue = row("supplierphone").ToString
        'm_grid(currTrIndex, 26).CellValue = row("supplierfax").ToString
        m_grid(currTrIndex, 18).CellValue = row("stock_note").ToString
        m_grid.RowStyles(currTrIndex).ReadOnly = True

      Next

      m_grid.RowCount += 1
      currTrIndex = m_grid.RowCount
      m_grid.RowStyles(currTrIndex).BackColor = Color.FromArgb(167, 214, 231)
      m_grid.RowStyles(currTrIndex).Font.Bold = True
      m_grid.RowStyles(currTrIndex).ReadOnly = True
      m_grid(currTrIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(currTrIndex, 5).CellValue = "รวม"
      m_grid(currTrIndex, 6).CellValue = Configuration.FormatToString(Total, DigitConfig.Price)
      m_grid(currTrIndex, 7).CellValue = Configuration.FormatToString(sumTax, DigitConfig.Price)
      m_grid(currTrIndex, 8).CellValue = Configuration.FormatToString(sumAdjust, DigitConfig.Price)
      m_grid(currTrIndex, 9).CellValue = Configuration.FormatToString(sumAftertax, DigitConfig.Price)
      'm_grid(currTrIndex, 12).CellValue = Configuration.FormatToString(sumRemain, DigitConfig.Price)
    End Sub
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptCashPurchase"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptCashPurchase"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptCashPurchase"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.ListLabel}"
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
      Return "RptCashPurchase"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptCashPurchase"
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


        dpi = New DocPrintingItem
        dpi.Mapping = "col16"
        dpi.Value = m_grid(rowIndex, 17).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col17"
        dpi.Value = m_grid(rowIndex, 18).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col18"
        dpi.Value = m_grid(rowIndex, 19).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)


        dpi = New DocPrintingItem
        dpi.Mapping = "col19"
        dpi.Value = m_grid(rowIndex, 20).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)


        dpi = New DocPrintingItem
        dpi.Mapping = "col20"
        dpi.Value = m_grid(rowIndex, 21).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col21"
        dpi.Value = m_grid(rowIndex, 22).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col22"
        dpi.Value = m_grid(rowIndex, 23).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col23"
        dpi.Value = m_grid(rowIndex, 24).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col24"
        dpi.Value = m_grid(rowIndex, 25).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col25"
        dpi.Value = m_grid(rowIndex, 26).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col26"
        dpi.Value = m_grid(rowIndex, 27).CellValue
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
