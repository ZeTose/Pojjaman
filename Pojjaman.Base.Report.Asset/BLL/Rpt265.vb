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
    Public Class Rpt265
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
            m_grid.ColCount = 7

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 300
            m_grid.ColWidths(3) = 100
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100


            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
 
            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.AssetTypeID}") '"รหัสประเภท"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.AssetTypeName}") '"ชื่อประเภทสินทรัพย์"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.CostCenter}") ' CC สังกัด

            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.SumRent}") ' รวมค่าเช่า

            Dim indent As String = Space(3)
            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Project}") '"No."
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.CategoryWBS}") '"ใช้ในโครงการ"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DateStrat}") '"หมวดงาน(WBS)"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DateEnd}")  '"จากวันที่"
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Rent}") '"วันที่"
            m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.TakeDocEQW}")  '"ค่าเช่า"
            m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.TakeDocEQR}")   '"เบิกเอกสาร"
 
            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub
        Private Sub PopulateData()
      Dim dt0 As DataTable = Me.DataSet.Tables(0)
      Dim currAssetTypeIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim currentAssetTypeCode As String = ""
      Dim strAssetcode As String = ""
      Dim sumOpeningBalance As Decimal
      Dim sumAmount As Decimal

      For Each row As DataRow In dt0.Rows
        If (CStr(row("asset_code")) <> strAssetcode) Then
          If sumOpeningBalance <> 0 Then
            If Me.Filters(8).Value <> 0 Then
              m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
            End If
          Else
            If (strAssetcode <> "") Then
              If Me.Filters(8).Value <> 0 Then
                m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
              End If
            End If
          End If

          sumOpeningBalance = 0
          m_grid.RowCount += 1
          currAssetTypeIndex = m_grid.RowCount
          m_grid.RowStyles(currAssetTypeIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currAssetTypeIndex).Font.Bold = True
          m_grid.RowStyles(currAssetTypeIndex).ReadOnly = True
          If Not row.IsNull("asset_code") Then
            m_grid(currAssetTypeIndex, 1).CellValue = row("asset_code")
          End If
          If Not row.IsNull("asset_name") Then
            m_grid(currAssetTypeIndex, 2).CellValue = row("asset_name")
          End If
          If Not row.IsNull("cc_code") Then
            m_grid(currAssetTypeIndex, 3).CellValue = row("cc_code")
          End If
          strAssetcode = CStr(row("asset_code"))

          If Me.Filters(8).Value <> 0 Then
            m_grid.RowCount += 1
            currAssetTypeIndex = m_grid.RowCount
            m_grid(currAssetTypeIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.RptAcc}")
            m_grid(currAssetTypeIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
          End If
        End If
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True

        If Not row.IsNull("project_code") Then
          m_grid(currItemIndex, 1).CellValue = "  " & row("project_code")
        End If

        If Not row.IsNull("wbs_name") Then
          m_grid(currItemIndex, 2).CellValue = "  " & row("wbs_name")
        End If

        If Not row.IsNull("withdtawDate") Then
          If IsDate(row("withdtawDate")) Then
            m_grid(currItemIndex, 3).CellValue = "  " & CDate(row("withdtawDate")).ToShortDateString
          End If
        End If
        If Not row.IsNull("returnDate") Then

          If IsDate(row("returnDate")) Then
            m_grid(currItemIndex, 4).CellValue = "  " & CDate(row("returnDate")).ToShortDateString
          End If
        End If

        If Not row.IsNull("assetwithdrawCode") Then
          m_grid(currItemIndex, 6).CellValue = "  " & row("assetwithdrawCode")
        End If

        If Not row.IsNull("assetreturnCode") Then
          m_grid(currItemIndex, 7).CellValue = "  " & row("assetreturnCode")
        End If

        sumOpeningBalance += CDec(row("OpeningBalance"))
        sumAmount += CDec(row("stockiAmt"))
        m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("stockiAmt")), DigitConfig.Price)

      Next


      If sumOpeningBalance <> 0 Then
        If Me.Filters(8).Value <> 0 Then
          m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
        End If
      Else
        If (strAssetcode <> "") Then
          If Me.Filters(8).Value <> 0 Then
            m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumOpeningBalance, DigitConfig.Price)
          End If
        End If
      End If


      m_grid.RowCount += 1
      currAssetTypeIndex = m_grid.RowCount
      m_grid(currAssetTypeIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Rpt265.Total}")
      m_grid(currAssetTypeIndex, 5).CellValue = Configuration.FormatToString(sumAmount, DigitConfig.Price)




        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "Rpt265"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt265.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.Rpt265"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.Rpt265"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.Rpt265.ListLabel}"
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
            Return "Rpt265"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "Rpt265"
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

