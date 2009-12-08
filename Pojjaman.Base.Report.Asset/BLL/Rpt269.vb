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
  Public Class Rpt269
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

      m_grid.ColWidths(1) = 80
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.CCCode}") '"รหัสประเภท"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.CCName}") '"ชื่อประเภทสินทรัพย์"

      Dim indent As String = Space(3)

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.assetCode}")  '"รหัสประเภท"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.assetName}")  '"ชื่อประเภทสินทรัพย์"
      m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.TotalTake}")   '"ชื่อสินทรัพย์"
      m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.TotalReturn}")    '"วันที่ซื้อ"


      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.DocDate}")  '"No."
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.DocID}")  '"รหัสสินทรัพย์"
      m_grid(2, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.DocType}")  '"ชื่อสินทรัพย์"
      m_grid(2, 4).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.AssetCodes}")   '"วันที่ซื้อ"
      m_grid(2, 5).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt269.AssetNames}")  '"รหัสสินทรัพย์"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
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
      Dim currentAssetTypeCode As String = ""
      Dim sumAssetTypeWithdtaw As Decimal = 0
      Dim sumAssetTypeReturn As Decimal = 0
      Dim currentAssetCode As String = ""
      Dim sumAssetWithdtaw As Decimal = 0
      Dim sumAssetReturn As Decimal = 0
      Dim sentAsset As Decimal = 0
      Dim currentDocCode As String = ""
      Dim sumCcWithdtaw As Decimal = 0
      Dim sumCcReturn As Decimal = 0
      Dim currentSum As String = ""
      Dim currAssetTypeIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currCcIndex As Integer = -1
      Dim sumWithdtaw As Decimal = 0
      Dim sumReturn As Decimal = 0

      'Dim indent As String = Space(3)
      Dim no As Integer = 0


      For Each row As DataRow In dt.Rows

        If row("cc_code").ToString <> ccCode Then

          If Not (ccCode = "") Then
            m_grid(currCcIndex, 6).CellValue = Configuration.FormatToString(sumCcWithdtaw, DigitConfig.Price)
            m_grid(currCcIndex, 7).CellValue = Configuration.FormatToString(sumCcReturn, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 6).CellValue = Configuration.FormatToString(sumAssetTypeWithdtaw, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 7).CellValue = Configuration.FormatToString(sumAssetTypeReturn, DigitConfig.Price)
            sumCcWithdtaw = 0
            sumCcReturn = 0
            sumAssetTypeWithdtaw = 0
            sumAssetTypeReturn = 0
            no = 1
          End If
          m_grid.RowCount += 1
          currCcIndex = m_grid.RowCount
          m_grid.RowStyles(currCcIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCcIndex).Font.Bold = True
          m_grid.RowStyles(currCcIndex).ReadOnly = True
          m_grid(currCcIndex, 1).CellValue = row("cc_code")
          m_grid(currCcIndex, 2).CellValue = row("cc_name")
          ccCode = row("cc_code").ToString
          m_grid(currCcIndex, 3).CellValue = row("assettype_code").ToString & row("cc_code").ToString

        End If

        If row("assettype_code").ToString & row("cc_code").ToString <> currentAssetTypeCode & ccCode Then
          If Not (currentAssetTypeCode = "") Then
            If no = 0 Then
              m_grid(currAssetTypeIndex, 6).CellValue = Configuration.FormatToString(sumAssetTypeWithdtaw, DigitConfig.Price)
              m_grid(currAssetTypeIndex, 7).CellValue = Configuration.FormatToString(sumAssetTypeReturn, DigitConfig.Price)
              sumAssetTypeWithdtaw = 0
              sumAssetTypeReturn = 0
            Else
              sumAssetTypeWithdtaw = 0
              sumAssetTypeReturn = 0
            End If
            no = 0
          End If

          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(228, 250, 250)
          m_grid(currAssetTypeIndex, 1).CellValue = "  " & row("assettype_code").ToString
          m_grid(currAssetTypeIndex, 2).CellValue = "  " & row("assettype_name").ToString
          currentAssetTypeCode = row("assettype_code").ToString
        End If

        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        m_grid(currDocIndex, 3).CellValue = "      " & row("DocCode").ToString
        currentDocCode = row("DocCode").ToString
        If Not row.IsNull("WithdtawQty") Then
          sumAssetWithdtaw = CDec(row("WithdtawQty"))
        End If
        If Not row.IsNull("ReturnQty") Then
          sumAssetReturn = CDec(row("ReturnQty"))
        End If
        m_grid(currDocIndex, 1).CellValue = "      " & row("stock_docDate").ToString
        m_grid(currDocIndex, 2).CellValue = "      " & row("DocCode").ToString
        m_grid(currDocIndex, 3).CellValue = row("entity_description")
        m_grid(currDocIndex, 4).CellValue = row("asset_code")
        m_grid(currDocIndex, 5).CellValue = row("asset_name")
        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumAssetWithdtaw, DigitConfig.Price)
        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumAssetReturn, DigitConfig.Price)


        sumAssetTypeWithdtaw += sumAssetWithdtaw
        sumAssetTypeReturn += sumAssetReturn
        sumCcWithdtaw += sumAssetWithdtaw
        sumCcReturn += sumAssetReturn
        sumWithdtaw += sumAssetWithdtaw
        sumReturn += sumAssetReturn
        'sentAsset += row("WithdtawQty")
      Next

      m_grid(currAssetTypeIndex, 6).CellValue = Configuration.FormatToString(sumAssetTypeWithdtaw, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 7).CellValue = Configuration.FormatToString(sumAssetTypeReturn, DigitConfig.Price)

      m_grid(currCcIndex, 6).CellValue = Configuration.FormatToString(sumCcWithdtaw, DigitConfig.Price)
      m_grid(currCcIndex, 7).CellValue = Configuration.FormatToString(sumCcReturn, DigitConfig.Price)
      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.Totals}")
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumWithdtaw, DigitConfig.Price)
      m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumReturn, DigitConfig.Price)

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Rpt269"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt269.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt269"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt269"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt269.ListLabel}"
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
      Return "Rpt269"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "Rpt269"
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

