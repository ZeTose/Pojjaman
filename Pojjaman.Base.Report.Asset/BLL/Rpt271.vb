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
  Public Class Rpt271
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
      m_grid.RowCount = 1
      m_grid.ColCount = 6

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetTypeCode}") '"รหัสประเภท"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetTypeName}") '"ชื่อประเภทสินทรัพย์"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetTotals}")
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetFrees}")

      Dim indent As String = Space(3)

      m_grid(1, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetID}")  '"No."
      m_grid(1, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetName}")  '"รหัสสินทรัพย์"
      m_grid(1, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.CCname}")  '"ชื่อสินทรัพย์"
      m_grid(1, 4).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.status}")   '"วันที่ซื้อ"
      'm_grid(1, 5).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetTotal}")  '"รหัสสินทรัพย์"
      'm_grid(1, 6).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.assetFree}")  '"ชื่อสินทรัพย์"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim ccCode As String = ""
      Dim assetCode As String = ""
      Dim currentAssetTypeCode As String = ""
      Dim sumAssetTypeWithdtaw As Decimal = 0
      Dim sumAssetTypeReturn As Decimal = 0
      Dim currentAssetCode As String = ""
      Dim sumAssetWithdtaw As Decimal = 0
      Dim sumAssetReturn As Decimal = 0
      Dim sentAsset As Decimal = 0
      Dim currentDocCode As String = ""
      Dim Withdtaw As Decimal = 0
      Dim bReturn As Decimal = 0
      Dim currentSum As String = ""
      Dim currAssetTypeIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currCcIndex As Integer = -1
      Dim sumWithdtaw As Decimal = 0
      Dim sumReturn As Decimal = 0
      Dim sum1 As Decimal = 0
      Dim sum2 As Decimal = 0
      'Dim indent As String = Space(3)
      Dim no As Integer = 0
      Dim no1 As Integer = 0

      For Each row As DataRow In dt.Rows
        If row("assettype_code").ToString <> currentAssetTypeCode Then
          If Not (currentAssetTypeCode = "") Then
            m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumAssetTypeWithdtaw, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 6).CellValue = Configuration.FormatToString(sumAssetTypeReturn, DigitConfig.Price)

            sumAssetTypeWithdtaw = 0
            sumAssetTypeReturn = 0

            no = 1
          End If
          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
          m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
          m_grid(currAssetTypeIndex, 1).CellValue = row("assettype_code")
          m_grid(currAssetTypeIndex, 2).CellValue = row("assettype_name")
          currentAssetTypeCode = row("assettype_code").ToString

        End If
        If row("asset_code").ToString <> currentAssetCode Then
          If Not (currentAssetCode = "") Then
            If no = 0 Then
              m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumAssetTypeWithdtaw, DigitConfig.Price)
              m_grid(currAssetTypeIndex, 6).CellValue = Configuration.FormatToString(sumAssetTypeReturn, DigitConfig.Price)
              'sumAssetWithdtaw = 0
              'sumAssetReturn = 0
            End If
            no = 0
            m_grid(currCcIndex, 5).CellValue = Configuration.FormatToString(sumAssetWithdtaw, DigitConfig.Price)
            m_grid(currCcIndex, 6).CellValue = Configuration.FormatToString(sumAssetReturn, DigitConfig.Price)
            sumAssetWithdtaw = 0
            sumAssetReturn = 0
          End If

          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          m_grid(currDocIndex, 1).CellValue = "  " & row("asset_code").ToString
          m_grid(currDocIndex, 2).CellValue = "  " & row("asset_name").ToString
          currentAssetCode = row("asset_code").ToString
        End If
        If Not row.IsNull("WithdtawQty") Then
          Withdtaw = CDec(row("WithdtawQty"))
        End If
        If Not row.IsNull("ReturnQty") Then
          bReturn = CDec(row("ReturnQty"))
        End If

        sumAssetWithdtaw += Withdtaw
        sumAssetReturn += bReturn
        sumAssetTypeWithdtaw += Withdtaw
        sumAssetTypeReturn += bReturn
        currCcIndex = m_grid.RowCount
        sum1 += Withdtaw
        sum2 += bReturn

        m_grid.RowStyles(currCcIndex).ReadOnly = True
        m_grid(currCcIndex, 4).CellValue = "  " & row("code_description").ToString

        m_grid(currCcIndex, 3).CellValue = "  " & row("cc_name").ToString

        m_grid(currCcIndex, 5).CellValue = Configuration.FormatToString(sumAssetWithdtaw, DigitConfig.Price)
        m_grid(currCcIndex, 6).CellValue = Configuration.FormatToString(sumAssetReturn, DigitConfig.Price)

      Next

      m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumAssetTypeWithdtaw, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 6).CellValue = Configuration.FormatToString(sumAssetTypeReturn, DigitConfig.Price)


      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt271.Totals}")
      m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(sum1, DigitConfig.Price)
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sum2, DigitConfig.Price)

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Rpt271"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt271.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt271"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt271"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt271.ListLabel}"
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
      Return "Rpt271"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "Rpt271"
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
#End Region  End Class
End Namespace

