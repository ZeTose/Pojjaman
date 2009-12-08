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
    Public Class RptDepreciationByAsset
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

            m_grid.ColWidths(1) = 150
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 100
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
          

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.AssetCode}") '"รหัสสินทรัพย์"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.AssetName}") '"สินทรัพย์"

            m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.CostCenter}") '"Cost Center"
            m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.Price}") '"ราคาซื้อ"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.StartDate}") '"เริ่มต้น"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.EndDate}") '"สิ้นสุด"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.Depreciation}") '"ค่าเสื่อม"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.SumDepreciation}") '"ค่าเสื่อมสะสม"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.NetAssetValue}") '"มูลค่าคงเหลือ"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.DocRefer}") '"เอกสารอ้างอิง"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 2).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 4).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 9).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentAssetAcctCode As String = ""
           
            Dim currAssetIndex As Integer = -1
            Dim currIndex As Integer = -1
            Dim indent As String = Space(3)
            Dim no As Integer = 0
            Dim myItem As Asset
            Dim temp As Double

            Dim sumPrice As Decimal = 0
            Dim sumDeprec As Decimal = 0
            Dim sumDeprecNet As Decimal = 0
            Dim sumNetAssetValue As Decimal = 0

            Dim TotalPrice As Decimal = 0
            Dim TotalDeprec As Decimal = 0
            Dim TotalDeprecNet As Decimal = 0
            Dim TotalNetAssetValue As Decimal = 0
            

            For Each row As DataRow In dt.Rows
                If row("AsstCode").ToString <> currentAssetAcctCode Then
                    If currentAssetAcctCode.Length > 0 Then
                        m_grid.RowCount += 1
                        currAssetIndex = m_grid.RowCount
                        m_grid.RowStyles(currAssetIndex).BackColor = Color.FromArgb(167, 214, 231)
                        m_grid(currAssetIndex, 2).CellValue = "รวม"
                        m_grid(currAssetIndex, 3).CellValue = Configuration.FormatToString(sumPrice, DigitConfig.Price)
                        m_grid(currAssetIndex, 6).CellValue = Configuration.FormatToString(sumDeprec, DigitConfig.Price)
                        m_grid(currAssetIndex, 7).CellValue = Configuration.FormatToString(sumDeprecNet, DigitConfig.Price)
                        m_grid(currAssetIndex, 8).CellValue = Configuration.FormatToString(sumNetAssetValue, DigitConfig.Price)
                    End If
                    m_grid.RowCount += 1
                    currAssetIndex = m_grid.RowCount
                    m_grid.RowStyles(currAssetIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currAssetIndex).Font.Bold = True
                    m_grid.RowStyles(currAssetIndex).ReadOnly = True
                    m_grid(currAssetIndex, 1).Tag = "Font.Bold"
                    m_grid(currAssetIndex, 1).CellValue = row("AsstCode")
                    m_grid(currAssetIndex, 2).CellValue = row("AsstName")
                    currentAssetAcctCode = row("AsstCode").ToString

                    sumPrice = 0
                    sumDeprec = 0
                    sumDeprecNet = 0
                    sumNetAssetValue = 0

                End If
                m_grid.RowCount += 1
                currIndex = m_grid.RowCount
                m_grid.RowStyles(currIndex).ReadOnly = True
                If Not row.IsNull("CCName") Then
                    m_grid(currIndex, 2).CellValue = row("CCName").ToString
                End If
                If Not row.IsNull("Price") Then
                    m_grid(currIndex, 3).CellValue = Configuration.FormatToString(CDec(row("Price")), DigitConfig.Price)
                    sumPrice += CDec(m_grid(currIndex, 3).CellValue)
                    TotalPrice += CDec(m_grid(currIndex, 3).CellValue)
                End If
                If Not row.IsNull("StartDate") Then
                    m_grid(currIndex, 4).CellValue = CDate(row("StartDate")).ToShortDateString
                End If
                If Not row.IsNull("EndDate") Then
                    m_grid(currIndex, 5).CellValue = CDate(row("EndDate")).ToShortDateString
                End If
                If Not row.IsNull("Depreciation") Then
                    m_grid(currIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Depreciation")), DigitConfig.Price)
                    sumDeprec += CDec(m_grid(currIndex, 6).CellValue)
                    TotalDeprec += CDec(m_grid(currIndex, 6).CellValue)
                End If
                If Not row.IsNull("DepreciationNt") Then
                    m_grid(currIndex, 7).CellValue = Configuration.FormatToString(CDec(row("DepreciationNt")), DigitConfig.Price)
                    sumDeprecNet += CDec(m_grid(currIndex, 7).CellValue)
                    TotalDeprecNet += CDec(m_grid(currIndex, 7).CellValue)
                End If
                If Not row.IsNull("NetAssetValue") Then
                    m_grid(currIndex, 8).CellValue = Configuration.FormatToString(CDec(row("NetAssetValue")), DigitConfig.Price)
                    sumNetAssetValue += CDec(m_grid(currIndex, 8).CellValue)
                    TotalNetAssetValue += CDec(m_grid(currIndex, 8).CellValue)
                End If
                If Not row.IsNull("RefCode") Then
                    m_grid(currIndex, 9).CellValue = row("RefCode").ToString
                End If
            Next
            'สำหรับประเภทสินทรัพย์ตัวสุดท้าย
            m_grid.RowCount += 1
            currIndex = m_grid.RowCount
            m_grid.RowStyles(currIndex).BackColor = Color.FromArgb(167, 214, 231)
            m_grid.RowStyles(currIndex).BackColor = Color.FromArgb(167, 214, 231)
            m_grid(currIndex, 2).CellValue = "รวม"
            m_grid(currIndex, 3).CellValue = Configuration.FormatToString(sumPrice, DigitConfig.Price)
            m_grid(currIndex, 6).CellValue = Configuration.FormatToString(sumDeprec, DigitConfig.Price)
            m_grid(currIndex, 7).CellValue = Configuration.FormatToString(sumDeprecNet, DigitConfig.Price)
            m_grid(currIndex, 8).CellValue = Configuration.FormatToString(sumNetAssetValue, DigitConfig.Price)

            m_grid.RowCount += 1
            currIndex = m_grid.RowCount
            m_grid.RowStyles(currIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currIndex).Font.Bold = True
            m_grid.RowStyles(currIndex).ReadOnly = True
            m_grid(currIndex, 2).CellValue = "รวมทั้งหมด"
            m_grid(currIndex, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currIndex, 3).CellValue = Configuration.FormatToString(TotalPrice, DigitConfig.Price)
            m_grid(currIndex, 6).CellValue = Configuration.FormatToString(TotalDeprec, DigitConfig.Price)
            m_grid(currIndex, 7).CellValue = Configuration.FormatToString(TotalDeprecNet, DigitConfig.Price)
            m_grid(currIndex, 8).CellValue = Configuration.FormatToString(TotalNetAssetValue, DigitConfig.Price)

        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptDepreciationByAsset"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptDepreciationByAsset"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptDepreciationByAsset"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptDepreciationByAsset.ListLabel}"
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
            Return "RptDepreciationByAsset"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptDepreciationByAsset"
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

