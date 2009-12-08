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
  Public Class Rpt270
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
      m_grid.ColCount = 9

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 140
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.assetCode}") '"รหัสประเภท"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.assetName}") '"ชื่อประเภทสินทรัพย์"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.CCName}")

      Dim indent As String = Space(3)

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.groupExpenses}")  '"รหัสประเภท"


      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.DocDate}")  '"No."
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.materialCode}")  '"รหัสสินทรัพย์"
      m_grid(2, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.expensesDetail}")  '"ชื่อสินทรัพย์"
      m_grid(2, 4).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.unit}")   '"วันที่ซื้อ"
      m_grid(2, 5).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.amount}")  '"รหัสสินทรัพย์"
      m_grid(2, 6).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.priceOfUnit}")  '"ชื่อสินทรัพย์"
      m_grid(2, 7).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.discrate}")   '"วันที่ซื้อ"
      m_grid(2, 8).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.Total}")  '"ชื่อสินทรัพย์"
      m_grid(2, 9).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.DocNo}")   '"วันที่ซื้อ"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt2 As DataTable = Me.DataSet.Tables(1)
      Dim ccCode As String = ""
      Dim assetCode As String = "#@null#"
      Dim currentAssetTypeCode As String = ""
      Dim currentAssetCode As String = ""
      Dim currentDocCode As String = ""
      Dim currentSum As String = ""
      Dim currAssetTypeIndex As Integer = -1
      Dim currAssetTypeIndex1 As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currCcIndex As Integer = -1
      Dim total As Decimal = 0
      Dim sum As Decimal = 0
      Dim sum2 As Decimal = 0
      Dim sum3 As Decimal = 0
      Dim no As Integer = 0
      Dim chkTotal As Integer = 0
      Dim lciCode As String = "#@null#"
      Dim sumOrd As Decimal = 0
      Dim asscode2 As String = "#@null#"
      Dim asscode As Boolean = True
      For Each row As DataRow In dt.Rows

        If row("asset_code").ToString <> assetCode Then
          If Not (assetCode = "#@null#") Then
            m_grid(currCcIndex, 8).CellValue = Configuration.FormatToString(sum2, DigitConfig.Price)
            If no = 0 Then
              m_grid(currAssetTypeIndex, 8).CellValue = Configuration.FormatToString(sum3, DigitConfig.Price)
            End If

            sum2 = 0
            sum3 = 0
            no = 1
            chkTotal = 0
          End If

          m_grid.RowCount += 1
          currCcIndex = m_grid.RowCount
          m_grid.RowStyles(currCcIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCcIndex).Font.Bold = True
          m_grid.RowStyles(currCcIndex).ReadOnly = True
          m_grid(currCcIndex, 1).CellValue = row("asset_code")
          m_grid(currCcIndex, 2).CellValue = row("asset_name")
          m_grid(currCcIndex, 3).CellValue = row("cc_code")
          assetCode = row("asset_code").ToString
          If CInt(Me.Filters(11).Value) <> 0 Then
            m_grid.RowCount += 1
            currAssetTypeIndex1 = m_grid.RowCount
            m_grid(currAssetTypeIndex1, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.RptAcc}")
            m_grid.RowStyles(currAssetTypeIndex1).BackColor = Color.FromArgb(118, 155, 128)
            m_grid.RowStyles(currAssetTypeIndex1).Font.Bold = True
            m_grid.RowStyles(currAssetTypeIndex1).ReadOnly = True
            For Each row2 As DataRow In dt2.Select("asset_code = '" & CStr(row("asset_code")) & "'")
              asscode = True
              sumOrd = CDec(row2("sum"))
            Next
            If (asscode = True) Then
              m_grid(currAssetTypeIndex1, 8).CellValue = Configuration.FormatToString(CDec(sumOrd), DigitConfig.Price)
              asscode = False
            Else
              m_grid(currAssetTypeIndex1, 8).CellValue = Configuration.FormatToString(0, DigitConfig.Price)
            End If
            'If (asscode2 <> row2("asset_code").ToString) Then
            'asscode2 = row2("asset_code").ToString

            'End If

          End If

        End If
        If CInt(Me.Filters(9).Value) <> 0 Then
          If row("lci_code").ToString <> lciCode Then
            If Not (lciCode = "#@null#") Then
              If no = 0 Then
                m_grid(currAssetTypeIndex, 8).CellValue = Configuration.FormatToString(sum3, DigitConfig.Price)
              End If
              sum3 = 0
              no = 0
            End If
            If (row.IsNull("lci_code")) Then
              If (chkTotal = 0) Then
                m_grid.RowCount += 1
                currAssetTypeIndex = m_grid.RowCount
                m_grid(currAssetTypeIndex, 1).CellValue = "  " & "อื่น ๆ"
                m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(228, 255, 228)
                m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
                m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
                chkTotal = 1
              End If
              lciCode = row("lci_code").ToString
            Else


              m_grid.RowCount += 1
              currAssetTypeIndex = m_grid.RowCount
              m_grid(currAssetTypeIndex, 1).CellValue = "  " & row("lci_name").ToString
              m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(228, 255, 228)
              m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
              m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
              lciCode = row("lci_code").ToString
            End If


          End If

          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          If Not row.IsNull("lci_code") Then
            m_grid(currDocIndex, 2).CellValue = "      " & row("lci_code").ToString
          End If

          If Not row.IsNull("stocki_itemname") Then
            m_grid(currDocIndex, 3).CellValue = "      " & row("stocki_itemname").ToString
          End If
          If Not row.IsNull("unit_name") Then
            m_grid(currDocIndex, 4).CellValue = "      " & row("unit_name").ToString
          End If
          If Not row.IsNull("stocki_qty") Then
            m_grid(currDocIndex, 5).CellValue = "      " & row("stocki_qty").ToString
          End If
          If Not row.IsNull("stocki_unitprice") Then
            m_grid(currDocIndex, 6).CellValue = "      " & Configuration.FormatToString(CDec(row("stocki_unitprice")), DigitConfig.Price)
          End If
          If Not row.IsNull("stocki_discamt") Then
            m_grid(currDocIndex, 7).CellValue = "      " & Configuration.FormatToString(CDec(row("stocki_discamt")), DigitConfig.Price)
          Else
            m_grid(currDocIndex, 7).CellValue = "      " & Configuration.FormatToString(0, DigitConfig.Price)
          End If
          m_grid(currDocIndex, 8).CellValue = "      " & Configuration.FormatToString(CDec(row("sum")), DigitConfig.Price)
          If Not row.IsNull("stock_code") Then
            m_grid(currDocIndex, 9).CellValue = "      " & row("stock_code").ToString
          End If
          If Not row.IsNull("stock_docdate") Then
            m_grid(currDocIndex, 1).CellValue = "      " & CDate(row("stock_docdate"))
          End If


        End If

        sum = CDec(row("sum")) 'CDec(row("stocki_qty")) '* CDec(row("stocki_unitprice"))

        total += sum

        sum2 += sum
        sum3 += sum


      Next

      m_grid(currAssetTypeIndex, 8).CellValue = Configuration.FormatToString(sum3, DigitConfig.Price)
      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount

      m_grid(currCcIndex, 8).CellValue = Configuration.FormatToString(sum2, DigitConfig.Price)

      m_grid(currDocIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt270.Totals}")
      m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(total, DigitConfig.Price)


    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "Rpt270"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt270.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt270"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.Rpt270"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt270.ListLabel}"
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
      Return "Rpt270"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "Rpt270"
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
        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

