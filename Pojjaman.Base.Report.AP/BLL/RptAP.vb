Option Strict On
Option Explicit On
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptAP
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private m_hashData As Hashtable
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
            m_grid.HorizontalThumbTrack = True
            m_grid.VerticalThumbTrack = True
            CreateHeader()
            PopulateData()
            m_grid.EndUpdate()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

            'Dim tr As Object = m_hashData(e.RowIndex)
            'If tr Is Nothing Then
            '  Return
            'End If
            'If TypeOf tr Is DataRow Then
            Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
            If dr Is Nothing Then
                Return
            End If

            Dim drh As New DataRowHelper(dr)

            Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
            Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

            If docId > 0 AndAlso docType > 0 Then
                Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                myEntityPanelService.OpenDetailPanel(en)
            End If
            'End If
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 1
            m_grid.ColCount = 12

            Dim GridRangeStyle1 As GridRangeStyle = New GridRangeStyle
            m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(0, 10, 0, 12)})

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 140
            m_grid.ColWidths(5) = 140
            m_grid.ColWidths(6) = 120
            m_grid.ColWidths(7) = 120
            m_grid.ColWidths(8) = 120
            m_grid.ColWidths(9) = 100
            m_grid.ColWidths(10) = 120
            m_grid.ColWidths(11) = 120
            m_grid.ColWidths(12) = 120

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
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
            m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.ApID}")              '"รหัสเจ้าหนี้"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.ApName}")            '"ชื่อเจ้าหนี้"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.CreditAmount}")      '"วงเงินเครดิต"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.RemainingCreditAmount}")  '"วงเงินเครดิตคงเหลือ"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.ApStatus}")          '"สถานะเจ้าหนี้"

            m_grid(1, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.DocDate}")  '"วันที่เอกสาร"
            m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.DocCode}")  '"เลขที่เอกสาร"
            m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.InVoid}")  '"เลขที่ใบกำกับ"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.DocType}")  '"ประเภทเอกสาร"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.PpCode}")   '"เลขที่ใบสำคัญจ่าย"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Debit}")    '"เดบิต"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Credit}")   '"เครดิต"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Status}")   '"คงเหลือ"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Term}")     '"เทอม"
            m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Debit}")     '"เดบิต"
            m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Credit}")    '"เครดิต"
            m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Status}")   '"คงเหลือ"

            GridRangeStyle1.Range = GridRangeInfo.Cell(0, 10)
            GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Retention}")  '"Retention"
            GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Center
            m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

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
            m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim dt2 As DataTable = Me.DataSet.Tables(1)
            'Dim dt3 As DataTable = Me.DataSet.Tables(2)
            Dim currentSupplierCode As String = ""
            Dim currentDocCode As String = ""

            Dim indent As String = Space(3)
            Dim tmpRemain As Decimal = 0
            Dim tmpDebit As Decimal = 0
            Dim tmpCredit As Decimal = 0
            Dim tmpDebit2 As Decimal = 0
            Dim tmpCredit2 As Decimal = 0
            Dim sumSupplier As Int32 = 0
            Dim sumOpnBalance As Decimal = 0
            Dim sumDebit As Decimal = 0
            Dim sumCredit As Decimal = 0
            Dim sumRetentionDebit As Decimal = 0
            Dim sumRetentionCredit As Decimal = 0
            Dim sumRetentionEndingBalance As Decimal = 0
            Dim sumRetentionRemaining As Decimal = 0
            Dim lastSupplierCrAmtRecord As Decimal = 0
            Dim currSupplierIndex As Integer = -1
            Dim currDocIndex As Integer = -1

            'Dim dicClass As New DictionaryOfJoinStringbyInteger(dt3, "VatId", "vati_code", ",")

            For Each row As DataRow In dt.Rows
                Dim supRows As DataRow() = Me.DataSet.Tables(1).Select("SupplierCode ='" & row("SupplierCode").ToString & "'")
                If supRows.Length = 0 Then
                    Dim dr As DataRow = Me.DataSet.Tables(1).NewRow()
                    dr(0) = row(0)
                    dr(1) = row(1)
                    dr(2) = row(2)
                    dr(3) = row(3)
                    dr(4) = ""
                    dr(5) = 0
                    dr(6) = Now
                    dr(7) = 0
                    dr(8) = 0
                    dr(9) = ""
                    dr(10) = ""
                    dr(11) = 0
                    dr(12) = 0
                    dr(13) = 0
                    dr(14) = 0
                    dt2.Rows.Add(dr)
                End If
            Next

            For Each row As DataRow In dt2.Rows
                If row("SupplierCode").ToString <> currentSupplierCode Then
                    sumSupplier += 1
                    If sumSupplier > 1 Then
                        'วงเงินเครดิตคงเหลือ
                        If m_grid.RowStyles(currSupplierIndex).ReadOnly = True Then
                            m_grid.RowStyles(currSupplierIndex).ReadOnly = False
                        End If
                        m_grid(currSupplierIndex, 4).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")) - tmpRemain, DigitConfig.Price)
                        m_grid(currSupplierIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                        m_grid.RowStyles(currSupplierIndex).ReadOnly = True

                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        m_grid(currDocIndex, 3).CellValue = "รวมเงิน"
                        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpDebit, DigitConfig.Price)
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(tmpCredit, DigitConfig.Price)
                        tmpDebit = 0
                        tmpCredit = 0
                        tmpRemain = 0
                    End If
                    m_grid.RowCount += 1
                    currSupplierIndex = m_grid.RowCount
                    m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currSupplierIndex).Font.Bold = True
                    m_grid.RowStyles(currSupplierIndex).ReadOnly = True

                    m_grid(currSupplierIndex, 1).CellValue = row("SupplierCode")
                    m_grid(currSupplierIndex, 2).CellValue = row("SupplierName")
                    m_grid(currSupplierIndex, 3).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")), DigitConfig.Price)
                    m_grid(currSupplierIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
                    m_grid(currSupplierIndex, 5).CellValue = row("Status")
                    currentSupplierCode = row("SupplierCode").ToString
                    lastSupplierCrAmtRecord = CDec(row("CreditAmount"))
                    Dim supRows As DataRow() = Me.DataSet.Tables(0).Select("SupplierCode ='" & currentSupplierCode & "'")
                    If supRows.Length = 1 Then
                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount
                        m_grid.RowStyles(currDocIndex).ReadOnly = True

                        m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.OpenningBalance}")   '"ยอดยกมา"
                        m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(supRows(0)("OpenningBalance")), DigitConfig.Price)
                        sumOpnBalance += CDec(supRows(0)("OpenningBalance"))
                        tmpRemain = CDec(supRows(0)("OpenningBalance"))
                        m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(CDec(supRows(0)("RetentionOpenningBalance")), DigitConfig.Price)
                        sumRetentionEndingBalance += CDec(supRows(0)("RetentionOpenningBalance"))
                    End If
                    currentDocCode = ""

                End If
                If row("DocCode").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    m_grid(currDocIndex, 0).Tag = row

                    If IsDate(row("DocDate")) Then
                        m_grid(currDocIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("DocCode") Then
                        m_grid(currDocIndex, 2).CellValue = indent & row("DocCode").ToString
                    End If
                    If Not row.IsNull("RefCode") Then
                        m_grid(currDocIndex, 3).CellValue = indent & row("RefCode").ToString
                    End If
                    If Not row.IsNull("Type") Then
                        m_grid(currDocIndex, 4).CellValue = indent & row("Type").ToString
                    End If
                    If Not row.IsNull("PVCode") Then
                        m_grid(currDocIndex, 5).CellValue = indent & row("PVCode").ToString
                    End If
                    If IsNumeric(row("Debit")) Then
                        m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Debit")), DigitConfig.Price)
                        tmpRemain -= Configuration.Format(CDec(row("Debit")), DigitConfig.Price)
                        tmpDebit += Configuration.Format(CDec(row("Debit")), DigitConfig.Price)
                        sumDebit += Configuration.Format(CDec(row("Debit")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("Credit")) Then
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Credit")), DigitConfig.Price)
                        tmpRemain += Configuration.Format(CDec(row("Credit")), DigitConfig.Price)
                        tmpCredit += Configuration.Format(CDec(row("Credit")), DigitConfig.Price)
                        sumCredit += Configuration.Format(CDec(row("Credit")), DigitConfig.Price)
                    End If
                    m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
                    If Not row.IsNull("Period") Then
                        m_grid(currDocIndex, 9).CellValue = indent & row("Period").ToString
                    End If

                    If Not row.IsNull("stock_paymentRetention") Then
                        m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(CDec(row("stock_paymentRetention")), DigitConfig.Price)
                        sumRetentionDebit += CDec(row("stock_paymentRetention"))
                        sumRetentionRemaining -= CDec(row("stock_paymentRetention"))
                    End If
                    If Not row.IsNull("stock_retention") Then
                        m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(CDec(row("stock_retention")), DigitConfig.Price)
                        sumRetentionCredit += CDec(row("stock_retention"))
                        sumRetentionRemaining += CDec(row("stock_retention"))
                    End If

                    'If Not row.IsNull("stock_retention") Then
                    m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(sumRetentionRemaining, DigitConfig.Price)
                    'End If
                    currentDocCode = row("DocCode").ToString
                End If
            Next

            'วงเงินเครดิตคงเหลือ
            If m_grid.RowStyles(currSupplierIndex).ReadOnly = True Then
                m_grid.RowStyles(currSupplierIndex).ReadOnly = False
            End If
            m_grid(currSupplierIndex, 4).CellValue = Configuration.FormatToString(lastSupplierCrAmtRecord - tmpRemain, DigitConfig.Price)
            m_grid(currSupplierIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.RowStyles(currSupplierIndex).ReadOnly = True

            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).ReadOnly = True

            m_grid(currDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Total}")     '"รวมเงิน"
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpDebit, DigitConfig.Price)
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(tmpCredit, DigitConfig.Price)

            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currDocIndex).Font.Bold = True
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.SumAp}")   '"รวมเจ้าหนี้(ราย)"
            m_grid(currDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.OpeningBalance}")  '"ยอดยกมา"
            m_grid(currDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currDocIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Debit}")  '"เดบิต"
            m_grid(currDocIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Credit}")  '"เครดิต"
            m_grid(currDocIndex, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Status}")  '"คงเหลือ"
            m_grid(currDocIndex, 10).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Debit}")  '"เดบิต"
            m_grid(currDocIndex, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Credit}")  '"เครดิต"
            m_grid(currDocIndex, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Status}")  '"คงเหลือ"
            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currDocIndex).Font.Bold = True
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 3).CellValue = sumSupplier
            m_grid(currDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(sumOpnBalance, DigitConfig.Price)
            m_grid(currDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumDebit, DigitConfig.Price)
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumCredit, DigitConfig.Price)
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(sumOpnBalance + (sumCredit - sumDebit), DigitConfig.Price)

            m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(sumRetentionDebit, DigitConfig.Price)
            m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(sumRetentionCredit, DigitConfig.Price)
            m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(sumRetentionEndingBalance + sumRetentionRemaining, DigitConfig.Price)

        End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptAP"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAP.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptAP"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptAP"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptAP.ListLabel}"
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
            Return "RptAP"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptAP"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            Dim IsSummaryLine As Boolean = False

            For rowIndex As Integer = 2 To m_grid.RowCount
                IsSummaryLine = False

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
                If CStr(dpi.Value) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAP.Total}") Then
                    IsSummaryLine = True
                    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If
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
                If IsSummaryLine Then
                    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col6"
                dpi.Value = m_grid(rowIndex, 7).CellValue
                If IsSummaryLine Then
                    dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If
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

                dpi = New DocPrintingItem
                dpi.Mapping = "col10"
                dpi.Value = m_grid(rowIndex, 11).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col11"
                dpi.Value = m_grid(rowIndex, 12).CellValue
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

