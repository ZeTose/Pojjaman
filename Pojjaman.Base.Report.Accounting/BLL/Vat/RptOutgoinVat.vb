Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptOutgoinVat
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
            RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            m_grid.BeginUpdate()
            m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            m_grid.Model.Options.NumberedColHeaders = False
            m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
            CreateHeader()
            PopulateData()
            m_grid.EndUpdate()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

            Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
            If dr Is Nothing Then
                Return
            End If

            Dim drh As New DataRowHelper(dr)

            Dim docId As Integer = drh.GetValue(Of Integer)("docId")
            Dim docType As Integer = drh.GetValue(Of Integer)("docType")

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 0
            m_grid.ColCount = 10

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 100
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 200
            m_grid.ColWidths(7) = 120
            m_grid.ColWidths(8) = 120
            m_grid.ColWidths(9) = 100
            m_grid.ColWidths(10) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 0
            m_grid.Rows.FrozenCount = 0

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.DocDate}") '"วันที่"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.SubmitalDate}") '"วันที่ยื่นภาษี"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.VatRunNumber}") '"เลขที่"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.Invoice}") '"ใบกำกับภาษี"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.DocCode}") '"เลขที่เอกสาร"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.CustomerName}") '"ชื่อลูกค้า"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.GroupName}") '"กลุ่มภาษี"
            m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.BeforeTax}") '"มูลค่าสินค้า/บริการ"
            m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.TaxAmount}") '"จำนวนเงินภาษี"
            m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.AfterTax}") '"รวม"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentDocCode As String = ""
            Dim currentLine As String = ""
            Dim SumBeforeTax As Decimal = 0
            Dim SumTaxAmount As Decimal = 0
            Dim SumAfterTax As Decimal = 0

            Dim currDocIndex As Integer = -1
            For Each row As DataRow In dt.Rows
                m_grid.RowCount += 1
                currDocIndex = m_grid.RowCount
                m_grid(currDocIndex, 0).Tag = row
                m_grid.RowStyles(currDocIndex).ReadOnly = True
                If IsDate(row("DocDate")) Then
                    m_grid(currDocIndex, 1).CellValue = CDate(row("DocDate")).ToShortDateString
                End If
                If IsDate(row("SubmitalDate")) Then
                    m_grid(currDocIndex, 2).CellValue = CDate(row("SubmitalDate")).ToShortDateString
                End If
                If Not row.IsNull("VatRunNumber") Then
                    m_grid(currDocIndex, 3).CellValue = row("VatRunNumber").ToString
                End If
                If Not row.IsNull("Invoice") Then
                    m_grid(currDocIndex, 4).CellValue = row("Invoice").ToString
                End If
                If Not row.IsNull("DocCode") Then
                    m_grid(currDocIndex, 5).CellValue = row("DocCode").ToString
                End If
                If Not row.IsNull("Supplier") Then
                    m_grid(currDocIndex, 6).CellValue = row("Supplier").ToString
                End If
                If Not row.IsNull("GroupName") Then
                    m_grid(currDocIndex, 7).CellValue = row("GroupName").ToString
                End If
                If IsNumeric(row("BeforeTax")) Then
                    m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("BeforeTax")), DigitConfig.Price)
                    SumBeforeTax += Configuration.Format(CDec(row("BeforeTax")), DigitConfig.Price)
                End If
                If IsNumeric(row("TaxAmt")) Then
                    m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(CDec(row("TaxAmt")), DigitConfig.Price)
                    SumTaxAmount += Configuration.Format(CDec(row("TaxAmt")), DigitConfig.Price)
                End If
                If IsNumeric(row("AfterTax")) Then
                    m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
                    SumAfterTax += Configuration.Format(CDec(row("AfterTax")), DigitConfig.Price)
                End If
            Next
            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currDocIndex).Font.Bold = True
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.SumAll}")
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(SumBeforeTax, DigitConfig.Price)
            m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(SumTaxAmount, DigitConfig.Price)
            m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price)
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptOutgoinVat"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptOutgoinVat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptOutgoinVat"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoinVat.ListLabel}"
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
#End Region
#Region "IPrintableEntity"
        Public Overrides Function GetDefaultFormPath() As String
            Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
        End Function
        Public Overrides Function GetDefaultForm() As String

        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim i As Integer = 0
            Dim SumBeforeTax As Decimal = 0
            Dim SumTaxAmount As Decimal = 0
            Dim SumAfterTax As Decimal = 0
            For Each itemRow As DataRow In Me.DataSet.Tables(0).Rows
                'Item.LineNumber
                dpi = New DocPrintingItem
                dpi.Mapping = "linenumber"
                dpi.Value = i + 1
                dpi.DataType = "System.Sting"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.DocDate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.DocDate"
                dpi.Value = itemRow("docdate")
                dpi.DataType = "System.DateTime"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.SubmitDate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.SubmitalDate"
                dpi.Value = itemRow("submitaldate")
                dpi.DataType = "System.DateTime"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Invoice
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Invoice"
                dpi.Value = itemRow("invoice")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                ''Item.AccountBook
                'dpi = New DocPrintingItem
                'dpi.Mapping = "Item.AccountBook"
                'dpi.Value = itemRow("accountBook")
                'dpi.DataType = "System.String"
                'dpi.Row = i + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'Item.DocCode
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.DocCode"
                dpi.Value = itemRow("docCode")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Supplier
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Supplier"
                dpi.Value = itemRow("supplier")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.BeforeTax
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.BeforeTax"
                dpi.Value = Configuration.Format(itemRow("beforetax"), DigitConfig.Price)
                dpi.DataType = "System.Decimal"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                If IsNumeric(itemRow("beforetax")) Then
                    SumBeforeTax += Configuration.Format(CDec(itemRow("beforetax")), DigitConfig.Price)
                End If

                'Item.TaxAmount
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.TaxAmount"
                dpi.Value = Configuration.Format(itemRow("taxamt"), DigitConfig.Price)
                dpi.DataType = "System.Decimal"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                If IsNumeric(itemRow("taxamt")) Then
                    SumTaxAmount += Configuration.Format(CDec(itemRow("taxamt")), DigitConfig.Price)
                End If

                'Item.AfterTax
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.AfterTax"
                dpi.Value = Configuration.Format(itemRow("aftertax"), DigitConfig.Price)
                dpi.DataType = "System.Decimal"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)
                If IsNumeric(itemRow("aftertax")) Then
                    SumAfterTax += Configuration.Format(CDec(itemRow("aftertax")), DigitConfig.Price)
                End If

                'Item.runNumber
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.runNumber"
                dpi.Value = itemRow("vatrunnumber")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.TaxRate
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.taxrate"
                dpi.Value = Configuration.FormatToString(CDec(itemRow("vati_taxrate")), DigitConfig.Price)
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.Invoice
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.Invoice"
                dpi.Value = itemRow("Invoice")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'Item.GroupName
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.GroupName"
                dpi.Value = itemRow("GroupName")
                dpi.DataType = "System.String"
                dpi.Row = i + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                i += 1
            Next

            'SumText
            dpi = New DocPrintingItem
            dpi.Mapping = "SumText"
            dpi.Value = "รวม"
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol4
            dpi = New DocPrintingItem
            dpi.Mapping = "SumCol4"
            dpi.Value = Configuration.FormatToString(SumBeforeTax, DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol5
            dpi = New DocPrintingItem
            dpi.Mapping = "SumCol5"
            dpi.Value = Configuration.FormatToString(SumTaxAmount, DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol6
            dpi = New DocPrintingItem
            dpi.Mapping = "SumCol6"
            dpi.Value = Configuration.FormatToString(SumAfterTax, DigitConfig.Price)
            dpi.DataType = "System.Decimal"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

    End Class
End Namespace

