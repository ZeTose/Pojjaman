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
  Public Class RptEQTMaintenance
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
      m_grid.RowCount = 2
      m_grid.ColCount = 7

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      'm_grid(0, 1).Text = Me.StringParserService.Parse(" ")
      'm_grid(0, 1).Text = Me.StringParserService.Parse(" ")

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.ToolCode}") '"รหัสเครื่องมือ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptToolStatus.ToolName}") '"ชื่อเครื่องมือ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.OwnerCC}") '"CC เจ้าของ"

      Dim indent As String = Space(3)

      m_grid(1, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.eqtiCode}")  '"รหัสเอกสารแปลงสถานะ"
      m_grid(1, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.EqtDetail.lblDocDate}")  '"วันที่"

      m_grid(2, 2).Text = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.eqtStockCode}")  '"รหัสเอกสารซ่อม"
      m_grid(2, 3).Text = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.eqtStockList}")   '"รายการซ่อม"
      m_grid(2, 4).Text = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.eqtStockTotal}")  '"จำนวน"
      m_grid(2, 5).Text = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRDeclareDetail.UnitHeaderText}")  '"Unit"
      m_grid(2, 6).Text = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.PerUnit}")  '"ต่อหน่วย"
      m_grid(2, 7).Text = indent & indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.RepairCost}")  '"มูลค่าซ่อม"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim ccCode As String = ""
      Dim currenteqtCode As String = ""
      Dim currenteqtiCode As String = ""
      Dim currentstockCode As String = ""
      Dim currentstockName As String = ""
      Dim bReturn As Decimal = 0
      Dim currentSum As String = ""
      Dim curreqtIndex As Integer = -1
      Dim curreqtiIndex As Integer = -1
      Dim curreqtsIndex As Integer = -1
      Dim currCcIndex As Integer = -1
      Dim currstockIndex As Integer = -1
      Dim sumeqtiReturn As Decimal = 0
      Dim sumeqtsReturn As Decimal = 0
      Dim sumstockReturn As Decimal = 0
      Dim sumReturn As Decimal = 0
      Dim sum As Decimal = 0
      Dim no As Integer = 0
      Dim no1 As Integer = 0
      Dim currenteqtsCode As String = ""

      For Each row As DataRow In dt.Rows
        If row("eqtCode").ToString <> currenteqtCode Then

          m_grid.RowCount += 1
          curreqtIndex = m_grid.RowCount
          m_grid.RowStyles(curreqtIndex).BackColor = Color.FromArgb(130, 255, 130)
          m_grid.RowStyles(curreqtIndex).Font.Bold = True
          m_grid.RowStyles(curreqtIndex).ReadOnly = True
          m_grid(curreqtIndex, 1).CellValue = row("eqtCode")
          m_grid(curreqtIndex, 2).CellValue = row("eqtName")
          currenteqtCode = row("eqtCode").ToString

        End If

        If row("eqtiCode").ToString <> currenteqtiCode Then
          If Not (currenteqtiCode = "") Then
            m_grid(curreqtiIndex, 7).CellValue = Configuration.FormatToString(sumeqtiReturn, DigitConfig.Price)

            sumeqtiReturn = 0

            no = 1
          End If

          m_grid.RowCount += 1
          curreqtiIndex = m_grid.RowCount
          m_grid.RowStyles(curreqtiIndex).BackColor = Color.FromArgb(255, 204, 153)
          m_grid.RowStyles(curreqtiIndex).Font.Bold = True
          m_grid.RowStyles(curreqtiIndex).ReadOnly = True
          m_grid(curreqtiIndex, 1).CellValue = "  " & row("eqtiCode").ToString
          m_grid(curreqtiIndex, 2).CellValue = "  " & row("eqtiName").ToString
          m_grid(curreqtiIndex, 3).CellValue = "  " & row("EqtiCC").ToString
          'currenteqtiCode = row("eqtiCode").ToString
        End If

        If row("eqtstock_code").ToString <> currenteqtsCode OrElse row("eqtiCode").ToString <> currenteqtiCode Then
          If Not (currenteqtsCode = "") Then
            If no = 0 Then
              m_grid(curreqtiIndex, 7).CellValue = Configuration.FormatToString(sumeqtiReturn, DigitConfig.Price)
              'sumstockReturn = 0
            End If
            no = 0
            m_grid(curreqtsIndex, 7).CellValue = Configuration.FormatToString(sumeqtsReturn, DigitConfig.Price)
            sumeqtsReturn = 0

            no = 1
          End If

          m_grid.RowCount += 1
          curreqtsIndex = m_grid.RowCount
          m_grid.RowStyles(curreqtsIndex).BackColor = Color.FromArgb(153, 204, 255)
          m_grid.RowStyles(curreqtsIndex).Font.Bold = True
          m_grid.RowStyles(curreqtsIndex).ReadOnly = True
          m_grid(curreqtsIndex, 1).CellValue = "  " & row("eqtstock_code").ToString
          m_grid(curreqtsIndex, 2).CellValue = "  " & CDate(row("eqtstock_docdate")).ToShortDateString
          currenteqtsCode = row("eqtstock_code").ToString
          currenteqtiCode = row("eqtiCode").ToString
        End If

        'If row("stock_code").ToString <> currentstockCode AndAlso row("LciName").ToString <> currentstockName Then
        If Not (currentstockCode = "") Then
          If no = 0 Then
            m_grid(curreqtiIndex, 7).CellValue = Configuration.FormatToString(sumeqtiReturn, DigitConfig.Price)
            'sumstockReturn = 0
          End If
          If no = 0 Then
            m_grid(curreqtsIndex, 7).CellValue = Configuration.FormatToString(sumeqtsReturn, DigitConfig.Price)
            'sumstockReturn = 0
          End If
          no = 0
          m_grid(currCcIndex, 7).CellValue = Configuration.FormatToString(sumstockReturn, DigitConfig.Price)
          sumstockReturn = 0
        End If

        m_grid.RowCount += 1
        currstockIndex = m_grid.RowCount
        m_grid.RowStyles(currstockIndex).Font.Bold = True
        m_grid.RowStyles(currstockIndex).ReadOnly = True
        m_grid(currstockIndex, 2).CellValue = "  " & row("stock_code").ToString
        m_grid(currstockIndex, 3).CellValue = "  " & row("LciName").ToString
        currentstockCode = row("stock_code").ToString
        'currentstockName = row("LciName").ToString
        'End If

        If Not row.IsNull("RepairCost") Then
          bReturn = CDec(row("RepairCost"))
        End If

        sumeqtiReturn += bReturn
        sumeqtsReturn += bReturn
        sumstockReturn += bReturn
        currCcIndex = m_grid.RowCount
        'sum += bReturn

        m_grid(currCcIndex, 4).CellValue = Configuration.FormatToString(CDec(row("es_stockqty")), DigitConfig.Price)
        m_grid(currCcIndex, 5).CellValue = "  " & row("unit_name").ToString
        m_grid(currCcIndex, 6).CellValue = Configuration.FormatToString(CDec(row("es_unitcost")), DigitConfig.Price)
        'm_grid(currCcIndex, 7).CellValue = Configuration.FormatToString(CDec(row("RepairCost")), DigitConfig.Price)
        m_grid(currCcIndex, 7).CellValue = Configuration.FormatToString(sumstockReturn, DigitConfig.Price)

      Next

      'm_grid(curreqtsIndex, 7).CellValue = Configuration.FormatToString(sumeqtsReturn, DigitConfig.Price)
      m_grid(curreqtiIndex, 7).CellValue = Configuration.FormatToString(sumeqtiReturn, DigitConfig.Price)
      m_grid(curreqtsIndex, 7).CellValue = Configuration.FormatToString(sumeqtsReturn, DigitConfig.Price)
      m_grid(currstockIndex, 7).CellValue = Configuration.FormatToString(sumstockReturn, DigitConfig.Price)

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptEQTMaintenance"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptEQTMaintenance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptEQTMaintenance"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptEQTMaintenance.ListLabel}"
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
      Return "RptEQTMaintenance"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptEQTMaintenance"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
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



        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

