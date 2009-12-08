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
    Public Class RptReceiveByCheck
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
            m_grid.ColCount = 6

            m_grid.ColWidths(1) = 150
            m_grid.ColWidths(2) = 150
            m_grid.ColWidths(3) = 150
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 200

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.DocCode}") '"เลขที่เอกสาร"
            m_grid(0, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.CheckCode}") '"เลขที่เช็ค"
            m_grid(0, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.CheckDate}") '"วันที่บนเช็ค"
            m_grid(0, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.CheckCost}") '"มูลค่าเช็ค"
            m_grid(0, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.Balance}") '"ยอดค้างรับคงเหลือ"
            m_grid(0, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.Status}") '"สถานะเช็ค"

            m_grid(1, 1).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.RVID}")  '"รหัสใบสำคัญรับ"
            m_grid(1, 2).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.ReferenceDoc}")  '"เอกสารอ้างอิง"
            m_grid(1, 3).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.Date}")  '"วันที่"
            m_grid(1, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.ReceiveAmount}")  '"ยอดรับ"
            m_grid(1, 6).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.Customer}")  '"ลูกค้า"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentDocCode As String = ""
            Dim currentRVCode As String = ""

            Dim currDocIndex As Integer = -1
            Dim currRVIndex As Integer = -1
            Dim indent As String = Space(3)

            For Each row As DataRow In dt.Rows
                If row("DocId").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    m_grid(currDocIndex, 1).CellValue = row("DocCode")
                    m_grid(currDocIndex, 2).CellValue = row("CheckCode")
                    m_grid(currDocIndex, 3).CellValue = CDate(row("CheckDate")).ToShortDateString
                    m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(CDec(row("CheckAmt")), DigitConfig.Price)
                    m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(CDec(row("CheckRemain")), DigitConfig.Price)
                    m_grid(currDocIndex, 6).CellValue = row("CheckStatus")
                    currentDocCode = row("DocId").ToString
                    currentRVCode = ""
                End If
                If row("RVId").ToString <> currentRVCode Then
                    m_grid.RowCount += 1
                    currRVIndex = m_grid.RowCount
                    m_grid.RowStyles(currRVIndex).ReadOnly = True
                    If Not row.IsNull("RVCode") Then
                        m_grid(currRVIndex, 1).CellValue = indent & row("RVCode").ToString
                    End If
                    If Not row.IsNull("RefDocCode") Then
                        m_grid(currRVIndex, 2).CellValue = indent & row("RefDocCode").ToString
                    End If
                    If Not row.IsNull("RefDocDate") Then
                        m_grid(currRVIndex, 3).CellValue = indent & CDate(row("RefDocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("ReceiveAmt") Then
                        m_grid(currRVIndex, 4).CellValue = Configuration.FormatToString(CDec(row("ReceiveAmt")), DigitConfig.Price)
                    End If
                    If Not row.IsNull("CustomerName") Then
                        m_grid(currRVIndex, 6).CellValue = indent & row("CustomerName").ToString
                    End If
                    currentRVCode = row("RVId").ToString
                End If
            Next
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptReceiveByCheck"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptReceiveByCheck"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptReceiveByCheck"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptReceiveByCheck.ListLabel}"
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
            Return "RptReceiveByCheck"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptReceiveByCheck"
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
                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

