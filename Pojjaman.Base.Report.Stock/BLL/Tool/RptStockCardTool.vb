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
  Public Class RptStockCardTool
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
    Public Overrides Sub ListInnewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
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
      m_grid.RowCount = 1
      m_grid.ColCount = 8

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 150
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 150

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.tool_code}") '"รหัสเครื่องมือ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.tool_name}") '"ชื่อเครื่องมือ"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.docdate}")  '"วันที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.stock_code}")  '"เลขที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.entity_description}")  '"ประเภทเอกสาร"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.receipt}")   '"รับ"
      m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.withdraw}")  '"จ่าย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.return}")  '"คืน"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.balance}")  '"คงเหลือ"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.note}")  '"หมายเหตุ"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currenttool_code As String = ""
      Dim currentstock_code As String = ""
      Dim currCostCenterIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim currOpenIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim openingBalance As Decimal = 0

      For Each row As DataRow In dt.Rows
        If row("tool_code").ToString <> currenttool_code Then
          m_grid.RowCount += 1
          currCostCenterIndex = m_grid.RowCount
          m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
          m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
          m_grid(currCostCenterIndex, 1).CellValue = row("tool_code")
          m_grid(currCostCenterIndex, 2).CellValue = row("tool_name")
          currenttool_code = row("tool_code").ToString
          currentstock_code = ""

          m_grid.RowCount += 1
          currOpenIndex = m_grid.RowCount
          m_grid.RowStyles(currOpenIndex).ReadOnly = True
          m_grid(currOpenIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.Openingbalance}") '"ยอดยกมา"
          If CInt(row("operateSort")) = -1 Then
            m_grid(currOpenIndex, 7).CellValue = Configuration.FormatToString(CDec(row("receipt")), DigitConfig.Qty)
            openingBalance = CDec(row("receipt"))
          Else
            m_grid(currOpenIndex, 7).CellValue = Configuration.FormatToString(0, DigitConfig.Qty)
            openingBalance = 0
          End If
        End If

        Dim receiptamt As Decimal = 0
        Dim withdrawamt As Decimal = 0
        Dim returnamt As Decimal = 0
        If row("stock_code").ToString <> currentstock_code Then
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not row.IsNull("stock_docdate") Then
            m_grid(currItemIndex, 1).CellValue = indent & CDate(row("stock_docdate")).ToShortDateString
          End If
          If Not row.IsNull("stock_code") Then
            m_grid(currItemIndex, 2).CellValue = indent & row("stock_code").ToString
          End If
          If Not row.IsNull("entity_description") Then
            m_grid(currItemIndex, 3).CellValue = indent & row("entity_description").ToString
          End If
          If IsNumeric(row("receipt")) Then
            m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(row("receipt")), DigitConfig.Qty)
            receiptamt = CDec(row("receipt"))
          End If
          If IsNumeric(row("withdraw")) Then
            m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("withdraw")), DigitConfig.Qty)
            withdrawamt = CDec(row("withdraw"))
          End If
          If IsNumeric(row("return")) Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("return")), DigitConfig.Qty)
            returnamt = CDec(row("return"))
          End If

          openingBalance += receiptamt - withdrawamt + returnamt
          m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(openingBalance, DigitConfig.Qty)

        If Not row.IsNull("note") Then
          m_grid(currItemIndex, 8).CellValue = indent & row("note").ToString
        End If
        currentstock_code = row("stock_code").ToString
        End If
      Next

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptStockCardTool"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptStockCardTool"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptStockCardTool"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptStockCardTool.ListLabel}"
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
          Case "month", "year", "type"
            dpiColl.Add(fixDpi)
          Case "docdatestart", "docdateend"
            dpiColl.Add(fixDpi)
          Case "costcenterstart", "costcenterend"
            dpiColl.Add(fixDpi)
        End Select
      Next

      Dim i As Integer = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        If IsDBNull(m_grid(rowIndex, 3).CellValue) Then
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = m_grid(rowIndex, 1).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Invoice
          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = m_grid(rowIndex, 2).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Else
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = m_grid(rowIndex, 1).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.Invoice
          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = m_grid(rowIndex, 2).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.doccode
          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          dpi.Value = m_grid(rowIndex, 3).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          dpi.Value = m_grid(rowIndex, 4).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          dpi.Value = m_grid(rowIndex, 5).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          dpi.Value = m_grid(rowIndex, 6).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          dpi.Value = m_grid(rowIndex, 7).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        End If

        i += 1
      Next
      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

