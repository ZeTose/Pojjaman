
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
    Public Class RptSCRemainingADV
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
            m_grid.ColCount = 12

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 150
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 200
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 80
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100
            m_grid.ColWidths(10) = 100
            m_grid.ColWidths(11) = 100
            m_grid.ColWidths(12) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2
            Dim indent As String = Space(3)

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.CCCode}")       '"รหัส Cost Center"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.CCName}")      '"ชื่อ Cost Center"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.AVPDocCode}")    '"เลขที่เอกสาร"    
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.AVPDocDate}")    '"วันที่เอกสาร"
            m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.InvoiceNo}")     '"เลขที่ใบกำกับภาษี"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.APCode}")        '"รหัสเจ้าหนี้"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.APName}")        '"ชื่อเจ้าหนี้"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.taxbase}")      '"ฐานภาษี"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.taxrate}")    '"อัตราภาษี"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.tax}")      '"เงินภาษี"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.total}")    '"รวม"
            m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.retention}")     '"ยอดหักมัดจำ"
            m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.remain}")      '"ยอดคงค้าง"
            m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.status}")      '"สถานะ"


            m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.DocCode}")    '"เลขที่เอกสาร"    
            m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.DocDate}")    '"วันที่เอกสาร"
            m_grid(2, 5).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.DocType}")        '"ประเภทเอกสาร"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim currentCostCenterCode As String = ""
            Dim currentDocCode As String = ""
            Dim currentRefDocCode As String = ""

            Dim indent As String = Space(3)
            Dim currCostCenterIndex As Integer = -1
            Dim currDocCodeIndex As Integer = -1
            Dim currRefDocIndex As Integer = -1

            Dim tmpAmount As Decimal = 0
            Dim tmpCreditAmount As Decimal = 0

            Dim SumTaxBase As Decimal = 0
            Dim SumTaxAmt As Decimal = 0
            Dim SumTotal As Decimal = 0
            For Each row As DataRow In dt.Rows
                If row("CostcenterCode").ToString <> currentCostCenterCode Then
                    m_grid.RowCount += 1
                    currCostCenterIndex = m_grid.RowCount
                    m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
                    m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
                    m_grid(currCostCenterIndex, 1).CellValue = row("CostCenterCode").ToString
                    m_grid(currCostCenterIndex, 2).CellValue = row("CostCenterName").ToString
                    currentCostCenterCode = row("CostCenterCode").ToString
                    m_grid(currCostCenterIndex, 1).Tag = "Font.Bold"
                End If

                If row("DocCode").ToString <> currentDocCode Then
                    If currentDocCode <> "" Then
                        m_grid(currDocCodeIndex, 11).CellValue = indent & Configuration.FormatToString(tmpAmount - tmpCreditAmount, DigitConfig.Price)
                    End If
                    m_grid.RowCount += 1
                    currDocCodeIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocCodeIndex).BackColor = Color.FromArgb(250, 227, 197)
                    m_grid.RowStyles(currDocCodeIndex).Font.Bold = True
                    m_grid.RowStyles(currDocCodeIndex).ReadOnly = True
                    If Not row.IsNull("DocCode") Then
                        m_grid(currDocCodeIndex, 1).CellValue = indent & (row("DocCode")).ToString
                    End If
                    If Not row.IsNull("DocDate") Then
                        m_grid(currDocCodeIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("VatInvoice") Then
                        m_grid(currDocCodeIndex, 3).CellValue = indent & (row("VatInvoice")).ToString
                    End If
                    If Not row.IsNull("SupplierCode") Then
                        m_grid(currDocCodeIndex, 4).CellValue = indent & row("SupplierCode").ToString
                    End If
                    If Not row.IsNull("SupplierName") Then
                        m_grid(currDocCodeIndex, 5).CellValue = indent & row("SupplierName").ToString
                    End If
                    If Not row.IsNull("TaxBase") Then
                        m_grid(currDocCodeIndex, 6).CellValue = Configuration.FormatToString(CDec(row("TaxBase")), DigitConfig.Price)
                        SumTaxBase += CDec(row("TaxBase"))
                    End If
                    If Not row.IsNull("TaxRate") Then
                        m_grid(currDocCodeIndex, 7).CellValue = Configuration.FormatToString(CDec(row("TaxRate")), DigitConfig.Price)
                    End If
                    If Not row.IsNull("TaxAmt") Then
                        m_grid(currDocCodeIndex, 8).CellValue = Configuration.FormatToString(CDec(row("TaxAmt")), DigitConfig.Price)
                        SumTaxAmt += CDec(row("TaxAmt"))
                    End If
                    If IsNumeric(row("AfterTax")) Then
                        m_grid(currDocCodeIndex, 10).CellValue = Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
                        tmpAmount = CDec(row("AfterTax"))
                        SumTotal += CDec(row("AfterTax"))
                    End If
                    If Not row.IsNull("status") Then
                        If CInt(row("status")) = 0 Then
                            m_grid(currDocCodeIndex, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Canceled}")  '"ถูกยกเลิก"
                        End If
                    End If
                    m_grid(currDocCodeIndex, 1).Tag = "Font.Bold"

                    currentDocCode = row("DocCode").ToString
                    currentRefDocCode = ""
                    tmpCreditAmount = 0
                End If

                If row("RefDocCode").ToString <> currentRefDocCode Then
                    m_grid.RowCount += 1
                    currRefDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currRefDocIndex).ReadOnly = True
                    If Not row.IsNull("RefDocCode") Then
                        m_grid(currRefDocIndex, 1).CellValue = indent & indent & row("RefDocCode").ToString
                    End If
                    If Not row.IsNull("RefDocDate") Then
                        m_grid(currRefDocIndex, 2).CellValue = indent & indent & CDate(row("RefDocDate")).ToShortDateString
                    End If
                    m_grid(currRefDocIndex, 3).CellValue = DBNull.Value
                    m_grid(currRefDocIndex, 4).CellValue = DBNull.Value
                    If Not row.IsNull("RefDocType") Then
                        m_grid(currRefDocIndex, 5).CellValue = indent & indent & row("RefDocType").ToString
                    End If
                    m_grid(currRefDocIndex, 6).CellValue = DBNull.Value
                    m_grid(currRefDocIndex, 7).CellValue = DBNull.Value
                    m_grid(currRefDocIndex, 8).CellValue = DBNull.Value
                    If Not row.IsNull("CreditAmt") Then
                        m_grid(currRefDocIndex, 9).CellValue = indent & Configuration.FormatToString(CDec(row("CreditAmt")), DigitConfig.Price)
                    End If

                    tmpCreditAmount += CDec(row("CreditAmt"))
                    currentRefDocCode = row("RefDocCode").ToString
                End If
            Next

            If currDocCodeIndex <> -1 Then
                m_grid(currDocCodeIndex, 11).CellValue = Configuration.FormatToString(tmpAmount - tmpCreditAmount, DigitConfig.Price)
            End If

            m_grid.RowCount += 1
            currRefDocIndex = m_grid.RowCount
            m_grid.RowStyles(currRefDocIndex).BackColor = Color.FromArgb(167, 214, 231)
            m_grid.RowStyles(currRefDocIndex).Font.Bold = True
            m_grid.RowStyles(currRefDocIndex).ReadOnly = True
            m_grid(currRefDocIndex, 5).CellValue = "รวม"
            m_grid(currRefDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currRefDocIndex, 6).CellValue = Configuration.FormatToString(SumTaxBase, DigitConfig.Price)
            m_grid(currRefDocIndex, 8).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price)
            m_grid(currRefDocIndex, 10).CellValue = Configuration.FormatToString(SumTotal, DigitConfig.Price)
            m_grid(currRefDocIndex, 1).Tag = "Font.Bold"

        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptSCRemainingADV"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptSCRemainingADV"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptSCRemainingADV"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCRemainingADV.ListLabel}"
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
            Return "RptSCRemainingADV"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptSCRemainingADV"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            'Dim dpiColl As New DocPrintingItemCollection
            'Dim dpi As DocPrintingItem

            'For Each fixDpi As DocPrintingItem In Me.FixValueCollection
            '    dpiColl.Add(fixDpi)
            'Next

            'Dim LineNumber As Integer = 0

            'Dim n As Integer = 0
            'Dim i As Integer = 0
            'For rowIndex As Integer = 1 To m_grid.RowCount
            '    i += 1
            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "Item.LineNumber"
            '    dpi.Value = i
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col0"
            '    dpi.Value = m_grid(rowIndex, 1).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col1"
            '    dpi.Value = m_grid(rowIndex, 2).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col2"
            '    dpi.Value = m_grid(rowIndex, 3).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col3"
            '    dpi.Value = m_grid(rowIndex, 4).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col4"
            '    dpi.Value = m_grid(rowIndex, 5).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col5"
            '    dpi.Value = m_grid(rowIndex, 6).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col6"
            '    dpi.Value = m_grid(rowIndex, 7).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col7"
            '    dpi.Value = m_grid(rowIndex, 8).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col8"
            '    dpi.Value = m_grid(rowIndex, 9).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col9"
            '    dpi.Value = m_grid(rowIndex, 10).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col10"
            '    dpi.Value = m_grid(rowIndex, 11).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col11"
            '    dpi.Value = m_grid(rowIndex, 12).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col12"
            '    dpi.Value = m_grid(rowIndex, 13).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col13"
            '    dpi.Value = m_grid(rowIndex, 14).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col14"
            '    dpi.Value = m_grid(rowIndex, 15).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)

            '    dpi = New DocPrintingItem
            '    dpi.Mapping = "col15"
            '    dpi.Value = m_grid(rowIndex, 16).CellValue
            '    dpi.DataType = "System.String"
            '    dpi.Row = n + 1
            '    dpi.Table = "Item"
            '    dpiColl.Add(dpi)


            '    n += 1
            'Next

            'Return dpiColl
        End Function
#End Region
    End Class
End Namespace
