Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptPOSummary
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

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 120
            m_grid.ColWidths(3) = 200
            m_grid.ColWidths(4) = 150
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 120
            m_grid.ColWidths(7) = 120

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.PoDocDate}")  '"วันที่ออกใบสั่งซื้อ"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.PoCode}")     '"เลขที่ใบสั่งซื้อ"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.CCCode}")     '"รหัสโครงการ"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.CCName}")     '"ชื่อโครงการ"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.SupplierName}") '"ชื่อผู้ขาย"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Tel}")        '"โทรศัพท์"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Fax}")        '"โทรสาร"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.PrDocDate}")  '"วันที่ออกใบขอซื้อ"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.PrCode}")     '"เลขที่ใบขอซื้อ"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Detail}")     '"รายละเอียด"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Amount}")     '"จำนวน"
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Unit}") '"หน่วย"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.UnitPrice}")        '"ราคาต่อหน่วย"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Price}")      '"ราคา"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentItem As String = ""
            Dim currentDocId As String = ""

            Dim currDocIndex As Integer = -1
            Dim currItemIndex As Integer = -1
            Dim indent As String = Space(3)
            Dim tmpDiscAmount As Decimal = 0
            Dim tmpTaxType As Integer = 0
            Dim tmpTaxAmount As Decimal = 0
            Dim tmpAfterTax As Decimal = 0
            Dim SumAmount As Decimal = 0

            For Each row As DataRow In dt.Rows
                If row("DocId").ToString <> currentDocId Then
                    If currentDocId <> "" Then
                        If tmpDiscAmount > 0 Then
                            m_grid.RowCount += 1
                            currItemIndex = m_grid.RowCount
                            m_grid.RowStyles(currItemIndex).ReadOnly = True
                            m_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.DiscAmt}") '"ค่าส่วนลด"
                            m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpDiscAmount, DigitConfig.Price)
                        End If
                        If tmpTaxType = 1 And IsNumeric(tmpTaxAmount) Then
                            m_grid.RowCount += 1
                            currItemIndex = m_grid.RowCount
                            m_grid.RowStyles(currItemIndex).ReadOnly = True
                            m_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.TaxAmount}") '"ค่าภาษีมูลค่าเพิ่ม"
                            m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(tmpTaxAmount), DigitConfig.Price)
                        End If
                        m_grid.RowCount += 1
                        currItemIndex = m_grid.RowCount
                        m_grid.RowStyles(currItemIndex).ReadOnly = True
                        m_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Sum}") '"รวม "
                        m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                        m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpAfterTax, DigitConfig.Price)
                    End If
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    m_grid(currDocIndex, 1).CellValue = CDate(row("DocDate")).ToShortDateString
                    m_grid(currDocIndex, 2).CellValue = row("DocCode")
                    m_grid(currDocIndex, 3).CellValue = row("CCCode")
                    m_grid(currDocIndex, 4).CellValue = row("CCName")
                    m_grid(currDocIndex, 5).CellValue = row("SupplierName")
                    m_grid(currDocIndex, 6).CellValue = row("SupplierPhone")
                    m_grid(currDocIndex, 7).CellValue = row("SupplierFax")

                    m_grid(currDocIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                    m_grid(currDocIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                    m_grid(currDocIndex, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

                    m_grid(currDocIndex, 1).Tag = "Font.Bold"

                    If IsNumeric(row("AfterTax")) Then
                        tmpAfterTax = row("AfterTax")
                        SumAmount += row("AfterTax")
                    End If
                    If IsNumeric(row("DiscAmt")) Then
                        tmpDiscAmount = row("DiscAmt")
                    Else
                        tmpDiscAmount = 0
                    End If

                    If row("TaxType") = 1 And IsNumeric(row("TaxAmount")) Then
                        tmpTaxType = 1
                        tmpTaxAmount = CDec(row("TaxAmount"))
                    Else
                        tmpTaxType = 0
                        tmpTaxAmount = 0
                    End If
                    currentDocId = row("DocId").ToString
                    currentItem = ""
                End If
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                If IsDate(row("RefDocDate")) Then
                    m_grid(currItemIndex, 1).CellValue = indent & CDate(row("RefDocDate")).ToShortDateString
                End If
                If Not row.IsNull("RefCode") Then
                    m_grid(currItemIndex, 2).CellValue = indent & row("RefCode").ToString
                End If
                If Not row.IsNull("ItemName") Then
                    m_grid(currItemIndex, 3).CellValue = indent & row("ItemName").ToString
                End If
                If Not row.IsNull("Qty") Then
                    m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Price)
                End If
                If Not row.IsNull("Unit") Then
                    m_grid(currItemIndex, 5).CellValue = indent & row("Unit").ToString
                End If
                If Not row.IsNull("UnitPrice") Then
                    m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
                End If
                If Not row.IsNull("Amount") Then
                    m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                End If

                currentItem = row("ItemId").ToString & row("ItemName").ToString
            Next

            If tmpTaxType = 1 Then
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                m_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.TaxAmount}") '"ค่าภาษีมูลค่าเพิ่ม"
                m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpTaxAmount, DigitConfig.Price)
            End If

            If tmpDiscAmount > 0 And currentDocId <> "" Then
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                m_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.DiscAmt}") '"ค่าส่วนลด"
                m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpDiscAmount, DigitConfig.Price)
            End If

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.Sum}") '"รวม "
            m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpAfterTax, DigitConfig.Price)

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currItemIndex).Font.Bold = True
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.SumAll}") '"รวมทั้งหมด"
            m_grid(currItemIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptPOSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptPOSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptPOSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPOSummary.ListLabel}"
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
            Return "RptPOSummary"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptPOSummary"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem
            Dim fn1 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Dim fn2 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))


            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            Dim SumAmt As Decimal = 0
            For rowIndex As Integer = 2 To m_grid.RowCount
                dpi = New DocPrintingItem
                dpi.Mapping = "col0"
                dpi.Value = m_grid(rowIndex, 1).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col1"
                dpi.Value = m_grid(rowIndex, 2).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col2"
                dpi.Value = m_grid(rowIndex, 3).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col3"
                dpi.Value = m_grid(rowIndex, 4).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col4"
                dpi.Value = m_grid(rowIndex, 5).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col5"
                dpi.Value = m_grid(rowIndex, 6).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col6"
                dpi.Value = m_grid(rowIndex, 7).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col7"
                'dpi.Value = m_grid(rowIndex, 8).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                n += 1
                If IsNumeric(m_grid(rowIndex, 7).CellValue) Then
                    SumAmt += CDbl(m_grid(rowIndex, 7).CellValue)
                End If
            Next

            'SumText
            dpi = New DocPrintingItem
            dpi.Mapping = "SumText"
            dpi.Value = "รวม"
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol7
            dpi = New DocPrintingItem
            dpi.Mapping = "sumCol7"
            dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

