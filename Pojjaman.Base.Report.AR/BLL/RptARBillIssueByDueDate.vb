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
    Public Class RptARBillIssueByDueDate
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
            CreateHeader()
            PopulateData()
            m_grid.EndUpdate()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
            Dim tr As Object = m_hashData(e.RowIndex)
            If tr Is Nothing Then
                Return
            End If

            If TypeOf tr Is KeyValuePair Then
                Dim IDandType As KeyValuePair = CType(tr, KeyValuePair)
                If IDandType Is Nothing Then
                    Return
                End If

                Dim docId As Integer = 0
                Dim docType As Integer = 0

                docId = IDandType.Value
                docType = IDandType.Key

                If docId > 0 AndAlso docType > 0 Then
                    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                    myEntityPanelService.OpenDetailPanel(en)
                End If
            End If
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 1
            m_grid.ColCount = 7

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 100
            m_grid.ColWidths(3) = 100
            m_grid.ColWidths(4) = 220
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 120
            m_grid.ColWidths(7) = 150

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.LimitDate}")       '"วันที่ครบกำหนด"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.BillAcceptance}")  '"ใบรับวางบิล"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.Date}")            '"วันที่"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.CustName}")         '"ชื่อลูกค้า"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.SumBillAcceptance}")       '"ยอดรับวางบิลทั้งหมด"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.BillAcceptaceRemaining}")  '"ยอดค้างชำระทั้งหมด"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.Note}")            '"หมายเหตุ"

            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.DocID}")       '"รหัสเอกสาร"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.DocDate}")   '"วันที่เอกสาร"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.CostCenter}")    '"CostCenter"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.BillAcceptanceTotal}")  '"ยอดรับวางบิล"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.Remaining}")   '"ยอดค้างชำระ"
            m_grid(1, 7).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.DocType}")     '"ประเภทเอกสาร"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentDocCode As String = ""
            Dim currentBillCode As String = ""
            Dim tmpTotalUnpaid As Decimal = 0
            Dim tmpTotalBilledAmount As Decimal = 0

            Dim currentBillaIndex As Integer = -1
            Dim currentBilliIndex As Integer = -1

            SumBilledAmt = 0
            SumRemain = 0

            Dim SummaryBaseBilledAmt As Decimal = 0
            Dim SummaryBaseRemainAmt As Decimal = 0

            m_hashData = New Hashtable
            Dim dc0 As New DataColumn("id")
            dt.Columns.Add(dc0)
            Dim dc1 As New DataColumn("docType")
            dt.Columns.Add(dc1)

            Dim indent As String = Space(3)
            For Each row As DataRow In dt.Rows
                If row("DocCode").ToString <> currentDocCode Then
                    If Not currentDocCode = "" Then
                        m_grid(currentBillaIndex, 5).CellValue = Configuration.FormatToString(tmpTotalBilledAmount, DigitConfig.Price)
                        m_grid(currentBillaIndex, 6).CellValue = Configuration.FormatToString(tmpTotalUnpaid, DigitConfig.Price)
                        m_grid.RowCount += 1
                        currentBilliIndex = m_grid.RowCount
                        m_grid.RowStyles(currentBilliIndex).ReadOnly = True
                        m_grid(currentBilliIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.Total}") '"รวม"
                        m_grid(currentBilliIndex, 5).CellValue = Configuration.FormatToString(tmpTotalBilledAmount, DigitConfig.Price)
                        m_grid(currentBilliIndex, 6).CellValue = Configuration.FormatToString(tmpTotalUnpaid, DigitConfig.Price)
                        m_grid(currentBilliIndex, 1).Tag = "Font.Bold"

                        SumBilledAmt += tmpTotalBilledAmount
                        SumRemain += tmpTotalUnpaid

                    End If
                    m_grid.RowCount += 1
                    currentBillaIndex = m_grid.RowCount

                    Dim IDandType As New KeyValuePair(CInt(row("DocType")), CInt(row("DocID")))
                    m_hashData(currentBillaIndex) = IDandType

                    m_grid.RowStyles(currentBillaIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currentBillaIndex).Font.Bold = True
                    m_grid.RowStyles(currentBillaIndex).ReadOnly = True
                    m_grid(currentBillaIndex, 1).CellValue = CDate(row("DueDate")).ToShortDateString
                    m_grid(currentBillaIndex, 2).CellValue = row("DocCode")
                    m_grid(currentBillaIndex, 3).CellValue = CDate(row("DocDate")).ToShortDateString
                    m_grid(currentBillaIndex, 4).CellValue = row("CustomerName")
                    m_grid(currentBillaIndex, 5).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                    m_grid(currentBillaIndex, 7).CellValue = row("Note")
                    m_grid(currentBillaIndex, 1).Tag = "Font.Bold"
                    currentDocCode = row("DocCode").ToString
                    currentBillCode = ""
                    tmpTotalBilledAmount = 0
                    tmpTotalUnpaid = 0
                End If
                If row("SaleBillCode").ToString <> currentBillCode Then
                    m_grid.RowCount += 1
                    currentBilliIndex = m_grid.RowCount
                    m_grid.RowStyles(currentBilliIndex).ReadOnly = True
                    m_grid(currentBilliIndex, 1).CellValue = DBNull.Value
                    If Not row.IsNull("SaleBillCode") Then
                        m_grid(currentBilliIndex, 2).CellValue = indent & row("SaleBillCode").ToString
                    End If
                    If IsDate(row("SaleBillDocDate")) Then
                        m_grid(currentBilliIndex, 3).CellValue = indent & CDate(row("SaleBillDocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("CCName") Then
                        m_grid(currentBilliIndex, 4).CellValue = indent & (row("CCName")).ToString
                    End If
                    If IsNumeric(row("SaleBillAmount")) Then
                        If CInt(row("stock_type")) <> 79 Then
                            m_grid(currentBilliIndex, 5).CellValue = Configuration.FormatToString(CDec(row("SaleBillAmount")), DigitConfig.Price)
                            tmpTotalBilledAmount += CDec(row("SaleBillAmount"))
                            SummaryBaseBilledAmt += CDec(row("SaleBillAmount"))
                        Else
                            m_grid(currentBilliIndex, 5).CellValue = Configuration.FormatToString(CDec(row("SaleBillAmount")) * -1, DigitConfig.Price)
                            tmpTotalBilledAmount -= CDec(row("SaleBillAmount"))
                            SummaryBaseBilledAmt -= CDec(row("SaleBillAmount"))
                        End If
                    End If
                    If IsNumeric(row("SaleBillUnpaid")) Then
                        If CInt(row("stock_type")) <> 79 Then
                            m_grid(currentBilliIndex, 6).CellValue = Configuration.FormatToString(CDec(row("SaleBillUnpaid")), DigitConfig.Price)
                            tmpTotalUnpaid += CDec(row("SaleBillUnpaid"))
                            SummaryBaseRemainAmt += CDec(row("SaleBillUnpaid"))
                        Else
                            m_grid(currentBilliIndex, 6).CellValue = Configuration.FormatToString(CDec(row("SaleBillUnpaid")) * -1, DigitConfig.Price)
                            tmpTotalUnpaid -= CDec(row("SaleBillUnpaid"))
                            SummaryBaseRemainAmt -= CDec(row("SaleBillUnpaid"))
                        End If

                    End If
                    m_grid(currentBilliIndex, 7).CellValue = row("Type").ToString

                    currentBillCode = indent & row("SaleBillCode").ToString
                End If
            Next
            m_grid(currentBillaIndex, 5).CellValue = Configuration.FormatToString(tmpTotalBilledAmount, DigitConfig.Price)
            m_grid(currentBillaIndex, 6).CellValue = Configuration.FormatToString(tmpTotalUnpaid, DigitConfig.Price)

            m_grid.RowCount += 1
            currentBilliIndex = m_grid.RowCount
            m_grid.RowStyles(currentBilliIndex).ReadOnly = True
            m_grid(currentBilliIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.Total}") '"รวม"
            m_grid(currentBilliIndex, 5).CellValue = Configuration.FormatToString(tmpTotalBilledAmount, DigitConfig.Price)
            m_grid(currentBilliIndex, 6).CellValue = Configuration.FormatToString(tmpTotalUnpaid, DigitConfig.Price)
            m_grid(currentBilliIndex, 1).Tag = "Font.Bold"

            SumBilledAmt += tmpTotalBilledAmount
            SumRemain += tmpTotalUnpaid

            m_grid.RowCount += 1
            currentBilliIndex = m_grid.RowCount
            m_grid.RowStyles(currentBilliIndex).ReadOnly = True
            m_grid(currentBilliIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.GrandTotal}") '"รวม"
            m_grid(currentBilliIndex, 5).CellValue = Configuration.FormatToString(SummaryBaseBilledAmt, DigitConfig.Price)
            m_grid(currentBilliIndex, 6).CellValue = Configuration.FormatToString(SummaryBaseRemainAmt, DigitConfig.Price)
            m_grid(currentBilliIndex, 1).Tag = "Font.Bold"

        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptARBillIssueByDueDate"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptARBillIssueByDueDate"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptARBillIssueByDueDate"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARBillIssueByDueDate.ListLabel}"
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
            Return "RptARBillIssueByDueDate"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptARBillIssueByDueDate"
        End Function
        Private SumBilledAmt As Decimal = 0
        Private SumRemain As Decimal = 0
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            For rowIndex As Integer = 2 To m_grid.RowCount
                Dim fn As Font

                If m_grid(rowIndex, 1).Tag Is Nothing Then
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                Else
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
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

                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

