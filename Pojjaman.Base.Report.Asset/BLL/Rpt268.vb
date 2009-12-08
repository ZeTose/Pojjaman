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
  Public Class Rpt268
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
      m_grid.ColCount = 4

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100


      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 1
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.AssetTypeID}") '"รหัสประเภท"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.AssetTypeName}") '"ชื่อประเภทสินทรัพย์"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.Total}") '"จำนวนทั้งหมด"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.TotalOfTake}") '"จำนวนเบิกได้"
      Dim indent As String = Space(3)

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.CCID}") '"รหัสประเภท"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.CCName}") '"ชื่อประเภทสินทรัพย์"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.CCTotal}") '"จำนวนทั้งหมด"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.CCTotalOfTake}") '"จำนวนเบิกได้"


      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.AssetCode}") '"No."
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.AssetName}") '"รหัสสินทรัพย์"
      m_grid(2, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.AssetStatus}") '"ชื่อสินทรัพย์"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentAssetTypeCode As String = "@null----"
      Dim currentDocCode As String = ""
      Dim currentAssetCode As String = ""
      Dim currAssetIndex As Integer = -1
      Dim currAssetTypeIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      'Dim indent As String = Space(3)
      Dim no As Integer = 0
      Dim assetQty As Decimal
      Dim sumQty As Decimal
      Dim assetCcQty As Decimal = 0
      Dim sumCcQty As Decimal = 0
      Dim sum As Decimal = 0
      Dim assest As Decimal = 0
      Dim tsum As Decimal = 0
      Dim tassest As Decimal = 0
      For Each row As DataRow In dt.Rows
        If row("assettype_code").ToString <> currentAssetTypeCode Then
          If Not (currentAssetTypeCode = "@null----") Then
            m_grid(currDocIndex, 3).CellValue = Configuration.FormatToString(sum, DigitConfig.Price)
            m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(assest, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 3).CellValue = Configuration.FormatToString(sumCcQty, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 4).CellValue = Configuration.FormatToString(assetCcQty, DigitConfig.Price)
            no = 1
            assetCcQty = 0
            sumCcQty = 0
            assest = 0
            sum = 0
          End If
          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currDocIndex).Font.Bold = True
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          m_grid(currDocIndex, 1).CellValue = row("assettype_code")
          m_grid(currDocIndex, 2).CellValue = row("assettype_name")
          currentAssetTypeCode = row("assettype_code").ToString
        End If
        If row("cc_code").ToString <> currentDocCode Then
          If Not (currentDocCode = "") Then
            If no = 0 Then
              m_grid(currAssetTypeIndex, 3).CellValue = Configuration.FormatToString(sumCcQty, DigitConfig.Price)
              m_grid(currAssetTypeIndex, 4).CellValue = Configuration.FormatToString(assetCcQty, DigitConfig.Price)
              assetCcQty = 0
              sumCcQty = 0
            Else
              assetCcQty = 0
              sumCcQty = 0
            End If
            no = 0
          End If
          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(228, 250, 250)
          m_grid(currAssetTypeIndex, 1).CellValue = "   " & row("cc_code").ToString
          m_grid(currAssetTypeIndex, 2).CellValue = "   " & row("cc_name").ToString
          currentDocCode = row("cc_code").ToString
        End If

        If row("asset_code").ToString <> currentAssetCode Then

          If Not row.IsNull("sumQty") Then
            sumQty = CDec(row("sumQty"))
          End If

          If Not row.IsNull("assetQty") Then
            assetQty = CDec(row("assetQty"))
          End If

          m_grid.RowCount += 1
          currAssetIndex = m_grid.RowCount
          m_grid(currAssetIndex, 1).CellValue = "      " & row("asset_code").ToString
          m_grid(currAssetIndex, 2).CellValue = "      " & row("asset_name").ToString
          m_grid(currAssetIndex, 3).CellValue = Configuration.FormatToString(CDec(row("sumQty")), DigitConfig.Price)
          m_grid(currAssetIndex, 4).CellValue = Configuration.FormatToString(CDec(row("assetQty")), DigitConfig.Price)
          currentAssetCode = row("asset_code").ToString
          sumCcQty += sumQty
          assetCcQty += assetQty
          sum += sumQty
          assest += assetQty
          tsum += sumQty
          tassest += assetQty
        End If

        m_grid(currAssetTypeIndex, 3).CellValue = Configuration.FormatToString(sumCcQty, DigitConfig.Price)
        m_grid(currAssetTypeIndex, 4).CellValue = Configuration.FormatToString(assetCcQty, DigitConfig.Price)
        m_grid(currDocIndex, 3).CellValue = Configuration.FormatToString(sum, DigitConfig.Price)
        m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(assest, DigitConfig.Price)

      Next
      m_grid.RowCount += 1
      currAssetIndex = m_grid.RowCount
      m_grid.RowStyles(currAssetIndex).Font.Bold = True
      m_grid(currAssetIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt268.Totals}")
      m_grid(currAssetIndex, 3).CellValue = Configuration.FormatToString(tsum, DigitConfig.Price)
      m_grid(currAssetIndex, 4).CellValue = Configuration.FormatToString(tassest, DigitConfig.Price)

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Rpt268"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt268.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt268"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt268"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt268.ListLabel}"
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
      Return "Rpt268"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "Rpt268"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 3 To m_grid.RowCount
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


        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

