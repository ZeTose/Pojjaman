
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
  Public Class RptPA
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

      Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("pa_id")
      Dim docType As Integer = 292

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 16

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 100

      m_grid.ColWidths(6) = 120
      m_grid.ColWidths(7) = 120

      m_grid.ColWidths(8) = 120
      m_grid.ColWidths(9) = 120
      m_grid.ColWidths(10) = 120
      m_grid.ColWidths(11) = 135
      m_grid.ColWidths(12) = 120
      m_grid.ColWidths(13) = 120
      m_grid.ColWidths(14) = 120
      m_grid.ColWidths(15) = 150
      m_grid.ColWidths(16) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      Dim indent As String = Space(3)
      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.DocNumber}")      '"เลขที่เอกสาร"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.DocDate}")       '"วันที่เอกสาร"

      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.subcontractor}")    '"ผู้รับเหมา"    
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.CC}")          '"Cost Center"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.scDocCode}")    '"เลขที่ใบสั่งจ้าง"    

      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.gross}")       '"ยอดเงินรวม"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.discamt}")       '"ส่วนลด"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.advance}")      '"มัดจำ
      m_grid(0, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.afterdiscamtadvance}")     '"หลังหักส่วนลดและมัดจำ

      m_grid(0, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.beforetax}")       '"ยอดเงินไม่รวมภาษี"
      m_grid(0, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.taxamt}")      '"มูลค่าภาษี"
      m_grid(0, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.aftertax}")     '"ยอดเงินสุทธิ"
      m_grid(0, 15).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.note}")    '"หมายเหตุ"
      m_grid(0, 16).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.refstatus}")    '"สถานะของเอกสาร"

      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.DocTYpe}")      '"ประเภทเอกสาร"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.PAitemName}")       '"ชื่อรายการ"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.UnitName}")    '"หน่วย"  
      m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.Qty}")    '"จำนวน"    
      m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.UnitPrice}")     '"ราคาต่อหน่วย"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.amt}")     '"ยอดเงินรวม"

      'm_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.gross}")       '"ยอดเงินรวม"
      'm_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.beforetax}")       '"ยอดเงินไม่รวมภาษี"

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
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt1 As DataTable = Me.DataSet.Tables(1)

      Dim currTrIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim currPAItem As Integer = -1
      Dim currPA As Integer = 0
      Dim indent As String = Space(3)

      Dim SumGross As Decimal = 0

      Dim SumDiscAmt As Decimal = 0
      Dim SumAdvance As Decimal = 0
      Dim SumAfterDisc As Decimal = 0

      Dim SumBeforTax As Decimal = 0
      Dim SumTaxAmt As Decimal = 0
      Dim SumAfterTax As Decimal = 0

      Dim n As Int32 = 0

      For Each row As DataRow In dt.Rows
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid(currItemIndex, 0).Tag = row
        m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(255, 255, 192, 128) ' Color.FromArgb(128, 255, 128)
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        If Not row.IsNull("Code") Then
          m_grid(currItemIndex, 1).CellValue = row("Code")
        End If
        If Not row.IsNull("DocDate") Then
          m_grid(currItemIndex, 2).CellValue = CDate(row("DocDate")).ToShortDateString
        End If

        If Not row.IsNull("subcontractor") Then
          m_grid(currItemIndex, 3).CellValue = row("subcontractor").ToString
        End If

        If Not row.IsNull("CC") Then
          m_grid(currItemIndex, 4).CellValue = row("CC").ToString
        End If
        If Not row.IsNull("SC") Then
          m_grid(currItemIndex, 5).CellValue = row("SC").ToString
        End If

        If Not row.IsNull("gross") Then
          m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("gross")), DigitConfig.Price)
          SumGross += CDec(row("gross"))
        End If
        If Not row.IsNull("discamt") Then
          m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(row("discamt")), DigitConfig.Price)
          SumDiscAmt += CDec(row("discamt"))
        End If
        If Not row.IsNull("advance") Then
          m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(CDec(row("advance")), DigitConfig.Price)
          SumAdvance += CDec(row("advance"))
        End If
        If Not row.IsNull("gross") Then
          m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(CDec(row("gross")) - CDec(row("discamt")) - CDec(row("advance")), DigitConfig.Price)
          SumAfterDisc += (CDec(row("gross")) - CDec(row("discamt")) - CDec(row("advance")))
        End If

        If Not row.IsNull("beforetax") Then
          m_grid(currItemIndex, 12).CellValue = Configuration.FormatToString(CDec(row("beforetax")), DigitConfig.Price)
          SumBeforTax += CDec(row("beforetax"))
        End If
        If Not row.IsNull("taxamt") Then
          m_grid(currItemIndex, 13).CellValue = Configuration.FormatToString(CDec(row("taxamt")), DigitConfig.Price)
          SumTaxAmt += CDec(row("taxamt"))
        End If
        If Not row.IsNull("aftertax") Then
          m_grid(currItemIndex, 14).CellValue = Configuration.FormatToString(CDec(row("aftertax")), DigitConfig.Price)
          SumAfterTax += CDec(row("aftertax"))
        End If
        If Not row.IsNull("note") Then
          m_grid(currItemIndex, 15).CellValue = row("note").ToString
        End If

        If Not row.IsNull("refstatus") Then
          m_grid(currItemIndex, 16).CellValue = row("refstatus").ToString
        End If
        currPA = row("pa_id").ToString

        For Each pairow As DataRow In dt1.Rows
          If currPA = pairow("pai_pa").ToString Then
            If Not pairow.IsNull("pai_pa") Then
              m_grid.RowCount += 1
              currPAItem = m_grid.RowCount
              m_grid(currPAItem, 0).Tag = row
              If CInt(pairow("pai_level")) = 0 Then
                m_grid.RowStyles(currPAItem).BackColor = Color.FromArgb(255, 240, 230, 140) 'Color.FromArgb(255, 255, 128)
              End If
              m_grid.RowStyles(currPAItem).ReadOnly = True
              If Not pairow.IsNull("code_description") Then
                m_grid(currPAItem, 3).CellValue = indent & pairow("code_description").ToString
              End If
              If Not pairow.IsNull("pai_itemName") Then
                m_grid(currPAItem, 4).CellValue = indent & pairow("pai_itemName").ToString
              End If
              If Not pairow.IsNull("unit_name") Then
                m_grid(currPAItem, 5).CellValue = indent & pairow("unit_name").ToString
              End If
              If Not pairow.IsNull("pai_qty") Then
                m_grid(currPAItem, 6).CellValue = indent & Configuration.FormatToString(CDec(pairow("pai_qty")), DigitConfig.Price)
              End If
              If Not pairow.IsNull("pai_unitprice") Then
                m_grid(currPAItem, 7).CellValue = indent & Configuration.FormatToString(CDec(pairow("pai_unitprice")), DigitConfig.Price)
              End If
              If Not pairow.IsNull("pai_amt") Then
                m_grid(currPAItem, 8).CellValue = indent & Configuration.FormatToString(CDec(pairow("pai_amt")), DigitConfig.Price)
              End If
            End If
          End If
        Next

      Next
      m_grid.RowCount += 1
      currTrIndex = m_grid.RowCount
      m_grid.RowStyles(currTrIndex).BackColor = Color.FromArgb(255, 255, 224, 192) ' Color.FromArgb(255, 255, 128)
      m_grid.RowStyles(currTrIndex).Font.Bold = True
      m_grid.RowStyles(currTrIndex).ReadOnly = True
      m_grid(currTrIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.SumAll}") 'รวม
      m_grid(currTrIndex, 8).CellValue = Configuration.FormatToString(SumGross, DigitConfig.Price) 'ยอดเงินรวม
      m_grid(currTrIndex, 9).CellValue = Configuration.FormatToString(SumDiscAmt, DigitConfig.Price) 'ยอดก่อนภาษี
      m_grid(currTrIndex, 10).CellValue = Configuration.FormatToString(SumAdvance, DigitConfig.Price) 'ยอดภาษี
      m_grid(currTrIndex, 11).CellValue = Configuration.FormatToString(SumAfterDisc, DigitConfig.Price) 'ยอดรวมภาษี 
      m_grid(currTrIndex, 12).CellValue = Configuration.FormatToString(SumBeforTax, DigitConfig.Price) 'ยอดก่อนภาษี
      m_grid(currTrIndex, 13).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price) 'ยอดภาษี
      m_grid(currTrIndex, 14).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price) 'ยอดรวมภาษี 

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptPA"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPA.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptPA"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptPA"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPA.ListLabel}"
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
      Return "RptPA"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptPA"
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
      For rowIndex As Integer = 2 To m_grid.RowCount
        i += 1
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = i
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        For colIndex As Integer = 1 To m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & (colIndex - 1).ToString
          dpi.Value = m_grid(rowIndex, colIndex).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col0"
        'dpi.Value = m_grid(rowIndex, 1).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col1"
        'dpi.Value = m_grid(rowIndex, 2).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col2"
        'dpi.Value = m_grid(rowIndex, 3).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col3"
        'dpi.Value = m_grid(rowIndex, 4).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col4"
        'dpi.Value = m_grid(rowIndex, 5).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col5"
        'dpi.Value = m_grid(rowIndex, 6).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col6"
        'dpi.Value = m_grid(rowIndex, 7).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col7"
        'dpi.Value = m_grid(rowIndex, 8).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col8"
        'dpi.Value = m_grid(rowIndex, 9).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col9"
        'dpi.Value = m_grid(rowIndex, 10).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col10"
        'dpi.Value = m_grid(rowIndex, 11).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col11"
        'dpi.Value = m_grid(rowIndex, 12).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col12"
        'dpi.Value = m_grid(rowIndex, 13).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col13"
        'dpi.Value = m_grid(rowIndex, 14).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col14"
        'dpi.Value = m_grid(rowIndex, 15).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col15"
        'dpi.Value = m_grid(rowIndex, 16).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace
