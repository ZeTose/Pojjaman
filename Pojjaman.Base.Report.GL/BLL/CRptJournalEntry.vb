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
  Public Class CRptJournalEntry
    Inherits CrystalReport
    Implements IUseCrystalReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter())
      MyBase.New(filters)
    End Sub
#End Region

#Region "Methods"
    'Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    'Public Overrides Sub ListInnewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
    '  m_grid = grid
    '  m_grid.BeginUpdate()
    '  m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
    '  m_grid.Model.Options.NumberedColHeaders = False
    '  m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
    '  CreateHeader()
    '  PopulateData()
    '  m_grid.EndUpdate()
    'End Sub
    'Private Sub CreateHeader()

    '  m_grid.RowCount = 1
    '  m_grid.ColCount = 6

    '  m_grid.ColWidths(1) = 120
    '  m_grid.ColWidths(2) = 400
    '  m_grid.ColWidths(3) = 140
    '  m_grid.ColWidths(4) = 100
    '  m_grid.ColWidths(5) = 100
    '  m_grid.ColWidths(6) = 100

    '  m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    '  m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    '  m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    '  m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    '  m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    '  m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    '  m_grid.Rows.HeaderCount = 1
    '  m_grid.Rows.FrozenCount = 1

    '  Dim indent As String = Space(3)
    '  m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.CostCenterID}") '"รหัส Cost Center"
    '  m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.CostCenterName}") '"ชื่อ Cost Center"

    '  m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.StockID}") '"รหัสวัสดุ"
    '  m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.StockName}")  '"ชื่อวัสดุ"
    '  m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.UnitName}")  '"ชื่อหน่วยนับ"
    '  m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.Num}")  '"จำนวน"
    '  m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.AvgPrice}")  '"ราคาเฉลี่ย"
    '  m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.Capital}")  '"ต้นทุน"


    '  m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    '  m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    '  m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    '  m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    '  m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    '  m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    '  m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    '  m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    'End Sub
    'Private Sub PopulateData()
    '  Dim dt As DataTable = Me.DataSet.Tables(0)
    '  Dim currentCoscenterCode As String = ""
    '  Dim currentItemCode As String = ""
    '  Dim a As Decimal = 0
    '  Dim currCostCenterIndex As Integer = -1
    '  Dim currItemIndex As Integer = -1
    '  Dim indent As String = Space(3)
    '  Dim SumCost As Decimal = 0

    '  For Each row As DataRow In dt.Rows
    '    If row("CostCenterId").ToString <> currentCoscenterCode Then
    '      m_grid.RowCount += 1
    '      currCostCenterIndex = m_grid.RowCount
    '      m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
    '      m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
    '      m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
    '      m_grid(currCostCenterIndex, 1).CellValue = row("CostCenterCode")
    '      m_grid(currCostCenterIndex, 2).CellValue = row("CostCenterName")
    '      currentCoscenterCode = row("CostCenterId").ToString
    '      currentItemCode = ""
    '    End If
    '    If row("LciCode").ToString <> currentItemCode Then
    '      m_grid.RowCount += 1
    '      currItemIndex = m_grid.RowCount
    '      m_grid.RowStyles(currItemIndex).ReadOnly = True
    '      m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(a), DigitConfig.Price)
    '      a = 0
    '    End If
    '    If Not row.IsNull("LciCode") Then
    '      m_grid(currItemIndex, 1).CellValue = indent & row("LciCode").ToString
    '    End If
    '    If Not row.IsNull("LciName") Then
    '      m_grid(currItemIndex, 2).CellValue = indent & row("LciName").ToString
    '    End If
    '    'If IsNumeric(row("Qty")) Then
    '    '  a += CDec(row("Qty")) '* CDec(row("CostUnit"))
    '    'End If
    '    'm_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(a), DigitConfig.Price)
    '    If Not row.IsNull("UnitName") Then
    '      m_grid(currItemIndex, 3).CellValue = indent & row("UnitName").ToString
    '    End If
    '    If IsNumeric(row("Qty")) Then
    '      m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Price)
    '    End If
    '    If IsNumeric(row("Qty")) Then
    '      If CDec(row("Qty")) = 0 Then
    '        m_grid(currItemIndex, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.ZeroStock}")
    '      Else
    '        m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("Costamt")) / CDec(row("QTY")), DigitConfig.Price)
    '      End If
    '    Else
    '      m_grid(currItemIndex, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.NoCost}")
    '    End If
    '    currentItemCode = row("LciCode").ToString
    '    If (CDec(row("Qty")) <> 0 AndAlso CDec(row("costamt")) <> 0) Then
    '      m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("costamt")), DigitConfig.UnitPrice)
    '    Else
    '      m_grid(currItemIndex, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.NoCost}")
    '    End If
    '    'SumCost += CDec(remainAmount)
    '  Next
    '  'm_grid.RowCount += 1
    '  'currItemIndex = m_grid.RowCount
    '  'm_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
    '  'm_grid.RowStyles(currItemIndex).Font.Bold = True
    '  'm_grid.RowStyles(currItemIndex).ReadOnly = True
    '  'm_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.SumAmount}")  '"รวมทั้งหมด"
    '  'm_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(SumCost, DigitConfig.Price)

    'End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides Property ReportName As String
      Get
        Return "CRptJournalEntry"
        'Return "CRptJournalEntry"
      End Get
      Set(ByVal value As String)

      End Set
    End Property    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "CRptJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.CRptJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.CRptJournalEntry"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.CRptJournalEntry.ListLabel}"
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
    'Public Overrides Function GetDefaultFormPath() As String
    '  Return "CRptJournalEntry"
    'End Function
    'Public Overrides Function GetDefaultForm() As String
    '  Return "CRptJournalEntry"
    'End Function
    'Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
    '  Dim dpiColl As New DocPrintingItemCollection
    '  Dim dpi As DocPrintingItem

    '  For Each fixDpi As DocPrintingItem In Me.FixValueCollection
    '    dpiColl.Add(fixDpi)
    '  Next

    '  Dim n As Integer = 0
    '  For rowIndex As Integer = 2 To m_grid.RowCount
    '    dpi = New DocPrintingItem
    '    dpi.Mapping = "col0"
    '    dpi.Value = m_grid(rowIndex, 1).CellValue
    '    dpi.DataType = "System.String"
    '    dpi.Row = n + 1
    '    dpi.Table = "Item"
    '    dpiColl.Add(dpi)

    '    dpi = New DocPrintingItem
    '    dpi.Mapping = "col1"
    '    dpi.Value = m_grid(rowIndex, 2).CellValue
    '    dpi.DataType = "System.String"
    '    dpi.Row = n + 1
    '    dpi.Table = "Item"
    '    dpiColl.Add(dpi)

    '    dpi = New DocPrintingItem
    '    dpi.Mapping = "col2"
    '    dpi.Value = m_grid(rowIndex, 3).CellValue
    '    dpi.DataType = "System.String"
    '    dpi.Row = n + 1
    '    dpi.Table = "Item"
    '    dpiColl.Add(dpi)

    '    dpi = New DocPrintingItem
    '    dpi.Mapping = "col3"
    '    dpi.Value = m_grid(rowIndex, 4).CellValue
    '    dpi.DataType = "System.String"
    '    dpi.Row = n + 1
    '    dpi.Table = "Item"
    '    dpiColl.Add(dpi)

    '    dpi = New DocPrintingItem
    '    dpi.Mapping = "col4"
    '    dpi.Value = m_grid(rowIndex, 5).CellValue
    '    dpi.DataType = "System.String"
    '    dpi.Row = n + 1
    '    dpi.Table = "Item"
    '    dpiColl.Add(dpi)

    '    dpi = New DocPrintingItem
    '    dpi.Mapping = "col5"
    '    dpi.Value = m_grid(rowIndex, 6).CellValue
    '    dpi.DataType = "System.String"
    '    dpi.Row = n + 1
    '    dpi.Table = "Item"
    '    dpiColl.Add(dpi)
    '    n += 1
    '  Next
    '  Return dpiColl
    'End Function
#End Region

  End Class
End Namespace

