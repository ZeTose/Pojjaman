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
  Public Class Rpt273
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
      m_grid.ColCount = 11

      m_grid.ColWidths(1) = 200
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 80
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left



      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetTypeCode}") '"รหัสกลุ่มประเภท"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetTypeName}") '"ประเภท"
      Dim indent As String = Space(3)

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetCode}")  '"รหัสประเภท"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetName}")  '"ชื่อประเภท"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.datePay}")
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.price}") '"ราคาซื้อ"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.remainValue}") '"ยอดยกมา"
      m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.calcRate}")  '"อัตราค่าเสื่อมราคา"
      m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.age}")  '"อายุค่าเสื่อมราคา"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.codedescription}")  '"วิธีคิดค่าเสื่อม"
      m_grid(1, 9).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.depreamnt}")  '"ค่าเสื่อมราคา"
      m_grid(1, 10).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.depNext}")  '"ยอดยกไป"
      m_grid(1, 11).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.dateSale}") '"วันที่ขาย"



      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left



      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left




    End Sub
    Private Sub PopulateData()

      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt2 As DataTable = Me.DataSet.Tables(1)
      Dim indent As String = Space(3)
      Dim strAssetTypecode As String = "#@null#"
      Dim strAssetcode As String = "#@null#"
      Dim currAssetTypeIndex As Integer = -1
      Dim currDetailIndex As Integer = -1
      Dim currAssetIndex As Integer = -1
      Dim sumAssetPrice As Decimal = 0
      Dim AssetPrice As Decimal = 0
      Dim beforeTax As Decimal = 0
      Dim taxAmt As Decimal = 0
      Dim status As Boolean = True
      Dim sale As Decimal = 0
      Dim balance As Decimal = 0
      For Each row As DataRow In dt.Rows
        If (CStr(row("assettype_code")) <> strAssetTypecode) Then
          If Not (strAssetTypecode = "#@null#") Then
            currAssetTypeIndex = m_grid.RowCount
            m_grid.RowCount += 1
            balance = AssetPrice - sale
            currAssetIndex = m_grid.RowCount
            m_grid(currAssetIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.sum}") '"รวม"
            m_grid(currAssetIndex, 5).CellValue = indent & Configuration.FormatToString(AssetPrice, DigitConfig.Price)
            AssetPrice = 0
            m_grid.RowCount += 1
            currAssetIndex = m_grid.RowCount
            m_grid(currAssetIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetBetweenl}") '"รวมขายระหว่างงวด"
            m_grid(currAssetIndex, 5).CellValue = indent & Configuration.FormatToString(sale, DigitConfig.Price)
            sale = 0
            m_grid.RowCount += 1
            currAssetIndex = m_grid.RowCount
            m_grid(currAssetIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetTotal}")
            m_grid(currAssetIndex, 5).CellValue = indent & Configuration.FormatToString(balance, DigitConfig.Price)
            balance = 0
          End If

          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
          m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
          m_grid(currAssetTypeIndex, 1).CellValue = row("assettype_code").ToString
          m_grid(currAssetTypeIndex, 2).CellValue = row("assettype_name").ToString
          strAssetTypecode = row("assettype_code").ToString

        End If
        If CStr(row("assettype_code")).ToString & CStr(row("asset_code")).ToString <> strAssetTypecode & strAssetcode Then
          If Not (strAssetcode = "#@null#") Then
            currAssetTypeIndex = m_grid.RowCount
            'm_grid(currAssetTypeIndex, 1).CellValue = row("asset_code").ToString
          End If
          m_grid.RowCount += 1
          currAssetIndex = m_grid.RowCount
          m_grid(currAssetIndex, 1).CellValue = indent & row("asset_code").ToString
          m_grid(currAssetIndex, 2).CellValue = indent & row("asset_name").ToString
          status = True
          For Each row2 As DataRow In dt2.Select("asset_code = '" & CStr(row("asset_code")) & "'")
            If (status = True) Then
              m_grid(currAssetIndex, 11).CellValue = indent & CDate(row2("stock_docdate")).ToShortDateString
              'm_grid(currAssetIndex, 11).CellValue = indent & Configuration.FormatToString(CDec(row2("stock_gross")), DigitConfig.Price)
              m_grid.RowStyles(currAssetIndex).BackColor = Color.FromArgb(128, 155, 128)

              status = False
              sale += CDec(row("depTotal"))

            End If
          Next

          m_grid.RowStyles(currAssetIndex).ReadOnly = True
          If Not row.IsNull("asset_buyDate") Then
            m_grid(currAssetIndex, 3).CellValue = indent & CDate(row("asset_buyDate")).ToShortDateString
          End If
          If Not row.IsNull("buyPrice") Then
            m_grid(currAssetIndex, 4).CellValue = indent & Configuration.FormatToString(CDec(row("buyPrice")), DigitConfig.Price)
          End If
          If Not row.IsNull("depTotal") Then
            m_grid(currAssetIndex, 5).CellValue = indent & Configuration.FormatToString(CDec(row("depTotal")), DigitConfig.Price)
          End If
          If Not row.IsNull("asset_calcRate") Then
            m_grid(currAssetIndex, 6).CellValue = indent & Configuration.FormatToString(CDec(row("asset_calcRate")), DigitConfig.Price)
          End If
          If Not row.IsNull("asset_age") Then
            m_grid(currAssetIndex, 7).CellValue = indent & row("asset_age").ToString
          End If
          If Not row.IsNull("depreamnt") Then
            m_grid(currAssetIndex, 9).CellValue = indent & Configuration.FormatToString(CDec(row("depreamnt")), DigitConfig.Price)
          End If
          If Not row.IsNull("code_description") Then
            m_grid(currAssetIndex, 8).CellValue = indent & row("code_description").ToString
          End If
          If Not row.IsNull("depNext") Then
            m_grid(currAssetIndex, 10).CellValue = indent & Configuration.FormatToString(CDec(row("depNext")), DigitConfig.Price)
          End If
          'If Not row.IsNull("depre_docdate") Then
          '  m_grid(currAssetIndex, 10).CellValue = indent & CDate(row("depre_docdate")).ToShortDateString
          'End If
          strAssetcode = row("asset_code").ToString
          AssetPrice += CDec(row("depTotal"))

        End If
        'If Not row.IsNull("SbeforeTax") Then
        '  beforeTax += CDec(row("SbeforeTax"))
        'End If
        'If Not row.IsNull("StaxAmt") Then
        '  taxAmt += CDec(row("StaxAmt"))
        'End If
        'm_grid(currAssetIndex, 10).CellValue = indent & Configuration.FormatToString(beforeTax, DigitConfig.Price)


      Next

      m_grid.RowCount += 1
      balance = AssetPrice - sale
      currAssetIndex = m_grid.RowCount
      m_grid(currAssetIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.sum}") '"รวม"
      m_grid(currAssetIndex, 5).CellValue = indent & Configuration.FormatToString(AssetPrice, DigitConfig.Price)
      AssetPrice = 0
      m_grid.RowCount += 1
      currAssetIndex = m_grid.RowCount
      m_grid(currAssetIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetBetweenl}") '"รวมขายระหว่างงวด"
      m_grid(currAssetIndex, 5).CellValue = indent & Configuration.FormatToString(sale, DigitConfig.Price)
      sale = 0
      m_grid.RowCount += 1
      currAssetIndex = m_grid.RowCount
      m_grid(currAssetIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt273.assetTotal}")
      m_grid(currAssetIndex, 5).CellValue = indent & Configuration.FormatToString(balance, DigitConfig.Price)
      balance = 0
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Rpt273"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt273.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt273"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt273"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt273.ListLabel}"
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
      Return "Rpt273"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "Rpt273"
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


        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

