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
    Public Class RptOutgoingCheckPettyCash
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
            m_grid.ColWidths(2) = 150
            m_grid.ColWidths(3) = 150
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 200
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            m_grid(0, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.CheckDueDate}") '"วันที่บนเช็ค"
            m_grid(0, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.DocDate}") '"วันที่เอกสาร"
            m_grid(0, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.DocNumber}") '"เลขที่เอกสาร"
            m_grid(0, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.CheckNumber}") '"เลขที่เช็ค"
            m_grid(0, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.BookNumber}") '"เลขที่สมุดบัญชี"
            m_grid(0, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.BankBranch}") '"ผู้ขาย"
            m_grid(0, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.Cost}") '"จำนวนเงิน"
            m_grid(0, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.Status}") '"สถานะ"
            m_grid(0, 9).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.CheckPassDate}") '"วันที่เช็คผ่าน"

            m_grid(1, 1).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.PVDate}")  '"วันที่เอกสารจ่ายชำระ"
            m_grid(1, 2).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.PVCode}")  '"เลขที่เอกสารจ่ายชำระ"
            m_grid(1, 3).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.DocCode}")  '"เลขที่เอกสาร"
            m_grid(1, 6).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.PettyCashName}")  '"เงินสดย่อย"

            m_grid(2, 1).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.RefDocDate}")  '"วันที่เอกสารอ้างอิง"
            m_grid(2, 2).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.RefDocPVCode}")  '"วันที่เอกสารจ่ายชำระ"
            m_grid(2, 3).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.RefDocCode}")  '"เลขที่เอกสารอ้างอิง"
            m_grid(2, 5).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.CCCode}")  '"รหัส CostCenter"
            m_grid(2, 6).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.CCName}")  '"ชื่อ CostCenter"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentDocCode As String = ""
            Dim currentPVCode As String = ""

            Dim SumAmount As Decimal = 0

            Dim indent As String = Space(3)

            Dim currDocIndex As Integer = -1
            Dim currDetailIndex As Integer = -1
            Dim currRefDocIndex As Integer = -1

            Dim showThisDetail As Boolean = False

            For Each row As DataRow In dt.Rows
                If row("DocCode").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    If IsDate(row("CheckDueDate")) Then
                        m_grid(currDocIndex, 1).CellValue = CDate(row("CheckDueDate")).ToShortDateString
                    End If
                    If IsDate(row("DocDate")) Then
                        m_grid(currDocIndex, 2).CellValue = CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("DocCode") Then
                        m_grid(currDocIndex, 3).CellValue = row("DocCode").ToString
                    End If
                    If Not row.IsNull("CqCode") Then
                        m_grid(currDocIndex, 4).CellValue = row("CqCode").ToString
                    End If
                    If Not row.IsNull("BankACBankCode") Then
                        m_grid(currDocIndex, 5).CellValue = row("BankACBankCode").ToString
                    End If
                    If Not row.IsNull("BankBranchName") Then
                        m_grid(currDocIndex, 6).CellValue = row("BankBranchName").ToString
                    End If
                    If IsNumeric(row("Amount")) Then
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                    End If
                    If Not row.IsNull("CheckStatus") Then
                        m_grid(currDocIndex, 8).CellValue = row("CheckStatus")
                    End If
                    If Not row.IsNull("CheckPassDate") Then
                        m_grid(currDocIndex, 9).CellValue = CDate(row("CheckPassDate")).ToShortDateString
                    End If
                    If IsNumeric(row("Amount")) Then
                        SumAmount += CDec(row("Amount"))
                    End If
                    currentDocCode = row("DocCode").ToString
                    showThisDetail = Not row.IsNull("payment_docdate")
                End If

                If showThisDetail Then
                    If row("payment_code").ToString <> currentPVCode Then
                        m_grid.RowCount += 1
                        currDetailIndex = m_grid.RowCount
                        m_grid.RowStyles(currDetailIndex).BackColor = Color.FromArgb(250, 227, 197)
                        m_grid.RowStyles(currDetailIndex).Font.Bold = True
                        m_grid.RowStyles(currDetailIndex).ReadOnly = True
                        If Not row.IsNull("payment_docdate") Then
                            m_grid(currDetailIndex, 1).CellValue = indent & CDate(row("payment_docdate")).ToShortDateString
                        End If
                        m_grid(currDetailIndex, 2).CellValue = indent & row("payment_code").ToString
                        m_grid(currDetailIndex, 3).CellValue = indent & row("payment_refdoccode").ToString
                        m_grid(currDetailIndex, 6).CellValue = indent & row("PettyCashName").ToString
                        If Not row.IsNull("paymenti_amt") Then
                            m_grid(currDetailIndex, 7).CellValue = indent & Configuration.FormatToString(CDec(row("paymenti_amt")), DigitConfig.Price)
                        End If
                        currentPVCode = row("payment_code").ToString
                    End If

                    m_grid.RowCount += 1
                    currRefDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currRefDocIndex).ReadOnly = True
                    If Not row.IsNull("pcci_refdocdate") Then
                        m_grid(currRefDocIndex, 1).CellValue = indent & indent & CDate(row("pcci_refdocdate")).ToShortDateString
                    End If
                    m_grid(currRefDocIndex, 2).CellValue = indent & indent & row("refdocpv").ToString
                    m_grid(currRefDocIndex, 3).CellValue = indent & indent & row("pcci_refdoccode").ToString
                    m_grid(currRefDocIndex, 5).CellValue = indent & indent & row("CCCode").ToString
                    m_grid(currRefDocIndex, 6).CellValue = indent & indent & row("CCName").ToString
                    If Not row.IsNull("pcci_amt") Then
                        m_grid(currRefDocIndex, 7).CellValue = indent & indent & Configuration.FormatToString(CDec(row("pcci_amt")), DigitConfig.Price)
                    End If
                End If
            Next

            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currDocIndex).Font.Bold = True
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.TotalAll}") '"รวม"
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptOutgoingCheckPettyCash"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptOutgoingCheckPettyCash"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptOutgoingCheckPettyCash"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptOutgoingCheckPettyCash.ListLabel}"
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
            Return "RptOutgoingCheckPettyCash"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptOutgoingCheckPettyCash"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
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

