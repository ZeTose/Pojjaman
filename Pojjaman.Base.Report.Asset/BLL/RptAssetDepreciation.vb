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
  Public Class RptAssetDepreciation
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
      m_grid.ColCount = 12

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 120
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 110
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 80
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 120
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100
      m_grid.ColWidths(12) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AssetAcctCode}")              '"รหัสบัญชี"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AssetAcctName}")            '"ชื่อบัญชีสินทรัพย์"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.No}")  '"No."
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AssetCode}")  '"รหัสสินทรัพย์"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.AssetName}")  '"ชื่อสินทรัพย์"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.BuyDate}")   '"วันที่ซื้อ"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.cc_code}")   '"รหัส costcenter"
      m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.cc_name}")   '"ชื่อ costcenter"
      m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.BuyPrice}")  '"ราคา"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.Openning}")   '"ยอดยกมา"
      m_grid(1, 9).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.CalcRate}")   '"อัตรา (%)"
      m_grid(1, 10).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.Depreciation}")    '"ค่าสึกหรอ"
      m_grid(1, 11).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.DepreciationOpenning}")   '"ค่าเสื่อมราคาสะสม"
      m_grid(1, 12).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.OnGoing}")   '"ยอดยกไป"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentAssetAcctCode As String = ""
      Dim currentDocCode As String = ""

      Dim currAssetTypeIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim no As Integer = 0
      Dim myItem As Asset
      Dim temp As Double

      Dim sumOpbAmt As Decimal = 0
      Dim sumOpbNetAmt As Decimal = 0
      Dim sumAssetDAmt As Decimal = 0
      Dim sumAssetDNetAmt As Decimal = 0
      Dim sumAssetDTotalAmt As Decimal = 0
      Dim sumAssetDTotalNetAmt As Decimal = 0
      Dim sumEdbAmt As Decimal = 0
      Dim sumEdbNetAmt As Decimal = 0

      For Each row As DataRow In dt.Rows
        no += 1
        If row("AcctCode").ToString <> currentAssetAcctCode Then
          If no <> 1 Then
            m_grid(currAssetTypeIndex, 8).CellValue = Configuration.FormatToString(sumOpbAmt, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 10).CellValue = Configuration.FormatToString(sumAssetDAmt, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 11).CellValue = Configuration.FormatToString(sumAssetDTotalAmt, DigitConfig.Price)
            m_grid(currAssetTypeIndex, 12).CellValue = Configuration.FormatToString(sumEdbAmt, DigitConfig.Price)

            sumOpbAmt = 0
            sumAssetDAmt = 0
            sumAssetDTotalAmt = 0
            sumEdbAmt = 0
          End If

          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
          m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
          m_grid(currAssetTypeIndex, 1).CellValue = row("AcctCode")
          m_grid(currAssetTypeIndex, 2).CellValue = row("AcctName")
          m_grid(currAssetTypeIndex, 1).Tag = "Font.Bold"
          currentAssetAcctCode = row("AcctCode").ToString
        End If

        myItem = New Asset(row, "")

        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        m_grid.RowStyles(currDocIndex).ReadOnly = True
        m_grid(currDocIndex, 1).CellValue = indent & no.ToString

        '-----------------------------ASSET--------------------------------------------------
        m_grid(currDocIndex, 2).CellValue = indent & myItem.Code
        m_grid(currDocIndex, 3).CellValue = indent & myItem.Name
        m_grid(currDocIndex, 4).CellValue = indent & myItem.BuyDate.ToShortDateString
        m_grid(currDocIndex, 7).CellValue = indent & Configuration.FormatToString(myItem.BuyPrice, DigitConfig.Price)
        temp = myItem.BuyPrice - myItem.DepreCalcAtDateIgnoreStartCalcAmt(CDate(row("DateStart")).AddDays(-1))
        temp -= myItem.Salvage
        If temp <= 0 Then
          temp = myItem.Salvage
        End If
        m_grid(currDocIndex, 8).CellValue = indent & Configuration.FormatToString(temp, DigitConfig.Price)
        m_grid(currDocIndex, 9).CellValue = indent & Configuration.FormatToString(myItem.CalcRate, DigitConfig.Price)
        m_grid(currDocIndex, 10).CellValue = indent & Configuration.FormatToString(myItem.DepreCalcBetweenDateIgnoreStartCalcAmt(CDate(row("DateStart")), CDate(row("DateEnd"))), DigitConfig.Price)
        m_grid(currDocIndex, 11).CellValue = indent & Configuration.FormatToString(myItem.DepreCalcAtDateIgnoreStartCalcAmt(CDate(row("DateEnd"))), DigitConfig.Price)
        temp = myItem.BuyPrice - myItem.DepreCalcAtDateIgnoreStartCalcAmt(CDate(row("DateEnd")))
        temp -= myItem.Salvage
        If temp <= myItem.Salvage Then
          temp = myItem.Salvage
        End If
        m_grid(currDocIndex, 12).CellValue = indent & Configuration.FormatToString(temp, DigitConfig.Price)
        '-----------------------------ASSET--------------------------------------------------

        If Not row.IsNull("cc_code") Then
          m_grid(currDocIndex, 5).CellValue = indent & row("cc_code").ToString
        End If
        If Not row.IsNull("cc_name") Then
          m_grid(currDocIndex, 6).CellValue = indent & row("cc_name").ToString
        End If


        sumOpbAmt += CDec(m_grid(currDocIndex, 8).CellValue)
        sumOpbNetAmt += CDec(m_grid(currDocIndex, 8).CellValue)

        sumAssetDAmt += CDec(m_grid(currDocIndex, 10).CellValue)
        sumAssetDNetAmt += CDec(m_grid(currDocIndex, 10).CellValue)

        sumAssetDTotalAmt += CDec(m_grid(currDocIndex, 11).CellValue)
        sumAssetDTotalNetAmt += CDec(m_grid(currDocIndex, 11).CellValue)

        sumEdbAmt += CDec(m_grid(currDocIndex, 12).CellValue)
        sumEdbNetAmt += CDec(m_grid(currDocIndex, 12).CellValue)
      Next
      'สำหรับประเภทสินทรัพย์ตัวสุดท้าย
      m_grid(currAssetTypeIndex, 8).CellValue = Configuration.FormatToString(sumOpbAmt, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 10).CellValue = Configuration.FormatToString(sumAssetDAmt, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 11).CellValue = Configuration.FormatToString(sumAssetDTotalAmt, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 12).CellValue = Configuration.FormatToString(sumEdbAmt, DigitConfig.Price)

      m_grid.RowCount += 1
      currAssetTypeIndex = m_grid.RowCount
      m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
      m_grid(currAssetTypeIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.Total}")   '"รวม"
      m_grid(currAssetTypeIndex, 8).CellValue = Configuration.FormatToString(sumOpbNetAmt, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 10).CellValue = Configuration.FormatToString(sumAssetDNetAmt, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 11).CellValue = Configuration.FormatToString(sumAssetDTotalNetAmt, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 12).CellValue = Configuration.FormatToString(sumEdbNetAmt, DigitConfig.Price)
      m_grid(currAssetTypeIndex, 1).Tag = "Font.Bold"
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAssetDepreciation"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAssetDepreciation"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAssetDepreciation"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAssetDepreciation.ListLabel}"
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
      Return "RptAssetDepreciation"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAssetDepreciation"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim fn As Font
      For rowIndex As Integer = 2 To m_grid.RowCount
        If Not m_grid(rowIndex, 1).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If

        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = m_grid(rowIndex, 2).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid(rowIndex, 3).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 4).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 5).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 6).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 7).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 8).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 9).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 10).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col10"
        dpi.Value = m_grid(rowIndex, 11).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)


        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 12).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

