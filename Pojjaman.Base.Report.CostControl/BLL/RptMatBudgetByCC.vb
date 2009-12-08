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
  Public Class RptMatBudgetByCC
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
      m_grid.ColCount = 6

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 150
      m_grid.ColWidths(5) = 150
      m_grid.ColWidths(6) = 150

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 0
      m_grid.Rows.FrozenCount = 0

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.Code}") '"Code"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.Description}") '"รายการ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.Unit}") '"หน่วย"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.Budget}") '"Qty Budget"
      m_grid(0, 5).Text = "Unit Price" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.UnitPrice}") '"UnitPrice"
      m_grid(0, 6).Text = "Amount" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.Amount}") '"Amount"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currDocIndex As Integer = -1

      Dim total As Decimal = 0
      For Each row As DataRow In dt.Rows
        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        m_grid.RowStyles(currDocIndex).ReadOnly = True
        If Not row.IsNull("Code") Then
          m_grid(currDocIndex, 1).CellValue = row("Code")
        End If
        If Not row.IsNull("Description") Then
          m_grid(currDocIndex, 2).CellValue = row("Description")
        End If
        If Not row.IsNull("Unit") Then
          m_grid(currDocIndex, 3).CellValue = row("Unit")
        End If
        If IsNumeric(row("Budget")) Then
          m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Budget")), DigitConfig.Qty)
        End If
        If IsNumeric(row("UnitPrice")) Then
          m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.UnitPrice)
        End If
        If IsNumeric(row("Amount")) Then
          total += Configuration.Format(CDec(row("Amount")), DigitConfig.Price)
          m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
        End If
      Next
      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).Font.Bold = True
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 5).CellValue = "Total"
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(total, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptMatBudgetByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatBudgetByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatBudgetByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatBudgetByCC.ListLabel}"
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
      Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
    End Function
    Public Overrides Function GetDefaultForm() As String

    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim i As Integer = 0
      Dim total As Decimal = 0
      For Each itemRow As DataRow In Me.DataSet.Tables(0).Rows
        'col0
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = i + 1
        dpi.DataType = "System.Sting"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'col1
        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = itemRow("code")
        dpi.DataType = "System.DateTime"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'col2
        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = itemRow("description")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'col3
        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = itemRow("unit")
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'col4
        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        If IsNumeric(itemRow("budget")) Then
          dpi.Value = Configuration.FormatToString(CDec(itemRow("budget")), DigitConfig.Qty)
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'col5
        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        If IsNumeric(itemRow("unitprice")) Then
          dpi.Value = Configuration.FormatToString(CDec(itemRow("unitprice")), DigitConfig.UnitPrice)
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'col6
        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        If IsNumeric(itemRow("amount")) Then
          total += Configuration.Format(CDec(itemRow("amount")), DigitConfig.Price)
          dpi.Value = Configuration.FormatToString(CDec(itemRow("amount")), DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        i += 1
      Next

      'col5
      dpi = New DocPrintingItem
      dpi.Font = New Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      dpi.Mapping = "col5"
      dpi.Value = "Total"
      dpi.DataType = "System.String"
      dpi.Row = i + 1
      dpi.Table = "Item"
      dpiColl.Add(dpi)

      'col6
      dpi = New DocPrintingItem
      dpi.Font = New Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      dpi.Mapping = "col6"
      dpi.Value = Configuration.FormatToString(total, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.Row = i + 1
      dpi.Table = "Item"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

