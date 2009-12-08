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
    Public Class RptPOReceivingCalendar
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
        Private MasterTotal As Decimal = 0
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
            m_grid.ColCount = 4

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 250
            m_grid.ColWidths(3) = 150
            m_grid.ColWidths(4) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.DateRecive}")  '"วันที่รับของ"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.SupplierCode}")   '"รหัสผู้ขาย"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.SupplierName}")   '"ชื่อผู้ขาย"

            m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.PoID}")   '"เลขที่ใบสั่งซื้อ"
            m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.Project}")   '"โครงการ"
            m_grid(2, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.POEmployee}")   '"ผู้สั่งซื้อ"
            m_grid(2, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.Cost}")   '"จำนวนเงิน"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim currentReceivingDate As String = ""
            Dim currentSupplierCode As String = ""
            Dim currentDocCode As String = ""

            Dim currReceivingIndex As Integer = -1
            Dim currSupplierIndex As Integer = -1
            Dim currPoIndex As Integer = -1
            Dim indent As String = Space(3)
            Dim SumAmount As Decimal = 0
            Dim tmpAmount As Decimal = 0

            For Each row As DataRow In dt.Rows
                Dim theDate As String = ""
                If IsDate(row("ReceivingDate")) Then
                    theDate = CDate(row("ReceivingDate")).ToShortDateString
                End If
                If theDate <> currentReceivingDate Then
                    If currentReceivingDate <> "" Then
                        m_grid.RowCount += 1
                        currPoIndex = m_grid.RowCount
                        m_grid.RowStyles(currPoIndex).ReadOnly = True
                        m_grid(currPoIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.Amount}") '"รวมเป็นเงิน"
                        m_grid(currPoIndex, 4).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
                        tmpAmount = 0
                    End If
                    m_grid.RowCount += 1
                    currReceivingIndex = m_grid.RowCount
                    m_grid.RowStyles(currReceivingIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currReceivingIndex).Font.Bold = True
                    m_grid.RowStyles(currReceivingIndex).ReadOnly = True
                    m_grid(currReceivingIndex, 1).CellValue = theDate
                    currentReceivingDate = theDate
                    currentSupplierCode = ""
                End If
                If row("SupplierCode").ToString <> currentSupplierCode Then
                    m_grid.RowCount += 1
                    currSupplierIndex = m_grid.RowCount
                    m_grid.RowStyles(currSupplierIndex).ReadOnly = True
                    If Not row.IsNull("SupplierCode") Then
                        m_grid(currSupplierIndex, 1).CellValue = indent & row("SupplierCode").ToString
                    End If
                    If Not row.IsNull("SupplierName") Then
                        m_grid(currSupplierIndex, 2).CellValue = indent & row("SupplierName").ToString
                    End If
                    currentSupplierCode = row("SupplierCode").ToString
                    currentDocCode = ""
                End If
                If row("DocId").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currPoIndex = m_grid.RowCount
                    m_grid.RowStyles(currPoIndex).ReadOnly = True
                    If Not row.IsNull("DocCode") Then
                        m_grid(currPoIndex, 1).CellValue = indent & indent & row("DocCode").ToString
                    End If
                    If Not row.IsNull("CCName") Then
                        m_grid(currPoIndex, 2).CellValue = indent & indent & row("CCName").ToString
                    End If
                    If Not row.IsNull("EmployeeName") Then
                        m_grid(currPoIndex, 3).CellValue = indent & indent & row("EmployeeName").ToString
                    End If
                    If IsNumeric(row("Amount")) Then
                        m_grid(currPoIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                        tmpAmount += CDec(row("Amount"))
                        SumAmount += CDec(row("Amount"))
                    End If
                    currentDocCode = row("DocId").ToString
                End If
            Next
            m_grid.RowCount += 1
            currPoIndex = m_grid.RowCount
            m_grid.RowStyles(currPoIndex).ReadOnly = True
            m_grid(currPoIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.Amount}") '"รวมเป็นเงิน"
            m_grid(currPoIndex, 4).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)

            m_grid.RowCount += 1
            currPoIndex = m_grid.RowCount
            m_grid.RowStyles(currPoIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currPoIndex).Font.Bold = True
            m_grid.RowStyles(currPoIndex).ReadOnly = True
            m_grid(currPoIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.Total}") '"รวมทั้งหมด"
            m_grid(currPoIndex, 4).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptPOReceivingCalendar"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptPOReceivingCalendar"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptPOReceivingCalendar"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPOReceivingCalendar.ListLabel}"
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
            Return "RptPOReceivingCalendar"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptPOReceivingCalendar"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            Dim SumAmt As Decimal = 0
            For rowIndex As Integer = 3 To m_grid.RowCount
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
                n += 1
              
                If IsNumeric(m_grid(rowIndex, 4).CellValue) Then
                    SumAmt += CDec(m_grid(rowIndex, 4).CellValue)
                End If
            Next


            dpi = New DocPrintingItem
            dpi.Mapping = "SumText"
            dpi.Value = "รวมทั้งหมด"
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            'SumCol3
            dpi = New DocPrintingItem
            dpi.Mapping = "sumCol3"
            dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
            dpi.DataType = "System.String"
            dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

