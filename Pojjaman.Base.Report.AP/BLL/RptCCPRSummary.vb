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

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptCCPRSummary
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
            m_grid.ColCount = 6

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 200
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 120


            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right


            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            'Table Header แถวที่ 0
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.CCID}")  '"รหัส Cost Center"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.CCName}")  '"ชื่อ Cost Center"

            'Table Header แถวที่ 1
            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.PrID}")   '"เลขที่ PR"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.PrDate}")   '"วันที่ PR"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.ReceivingDate}")   '"กำหนดส่ง"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.PRNote}")  '"หมายเหตุ"

            'Table Header แถวที่ 2
            m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.MatID}")   '"รหัสวัสดุ"
            m_grid(2, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.MatName}")  '"ชื่อวัสดุ"
            m_grid(2, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.Unit}")   '"หน่วย"
            m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.Qty}")   '"จำนวน"
            m_grid(2, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.PRiNote}")  '"หมายเหตุ"
            
            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center

            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
            m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim currentDocId As String = ""
            Dim currentCCId As String = ""
            Dim currentCCName As String = ""
            Dim currentItem As String = ""

            Dim currDocIndex As Integer = -1
            Dim currCCIndex As Integer = -1
            Dim currItemIndex As Integer = -1

            Dim CountCC As Integer
            Dim CountAllCC As Integer

            Dim indent As String = Space(3)
            Dim GridRangeStyle1 As GridRangeStyle

            For Each row As DataRow In dt.Rows
                If row("CCId").ToString <> currentCCId Then
                    If currentCCId.Length > 0 Then
                        m_grid.RowCount += 1
                        currCCIndex = m_grid.RowCount
                        m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(167, 214, 231)
                        m_grid(currCCIndex, 4).CellValue = "รวมทั้งโครงการ"
                        m_grid(currCCIndex, 5).CellValue = CountCC
                        m_grid(currCCIndex, 6).CellValue = "เอกสาร"
                    End If

                    m_grid.RowCount += 1
                    currCCIndex = m_grid.RowCount
                    m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currCCIndex).Font.Bold = True
                    m_grid.RowStyles(currCCIndex).ReadOnly = True
                    m_grid(currCCIndex, 1).CellValue = row("CCCode")
                    m_grid(currCCIndex, 2).CellValue = row("CCName")
                    currentCCId = row("CCId").ToString
                    currentDocId = ""
                    CountCC = 0
                End If
                '---------------------------------------------------------------------------------------
                If row("DocId").ToString <> currentDocId Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.AntiqueWhite
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    If Not row.IsNull("DocCode") Then
                        m_grid(currDocIndex, 1).CellValue = indent & row("DocCode").ToString
                    End If
                    If IsDate(row("DocDate")) Then
                        m_grid(currDocIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("ReceivingDate") Then
                        m_grid(currDocIndex, 3).CellValue = indent & CDate(row("ReceivingDate")).ToShortDateString
                    End If
                    If Not row.IsNull("Note") Then
                        m_grid(currDocIndex, 6).CellValue = indent & row("Note").ToString
                    End If
                    currentDocId = row("DocId").ToString
                    CountCC += 1
                    CountAllCC += 1
                End If
                '----------------------------------------------------------------------------------------
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                If Not row.IsNull("ItemCode") Then
                    m_grid(currItemIndex, 2).CellValue = indent & indent & row("ItemCode").ToString
                End If
                If Not row.IsNull("ItemName") Then
                    m_grid(currItemIndex, 3).CellValue = indent & indent & row("ItemName").ToString
                End If
                If Not row.IsNull("UnitName") Then
                    m_grid(currItemIndex, 4).CellValue = indent & indent & row("UnitName").ToString
                End If
                If IsNumeric(row("Qty")) Then
                    m_grid(currItemIndex, 5).CellValue = indent & indent & Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
                End If
                'If IsNumeric(row("Amount")) Then
                '    m_grid(currItemIndex, 6).CellValue = indent & indent & Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                'End If
                If IsNumeric(row("Note")) Then
                    m_grid(currItemIndex, 6).CellValue = indent & indent & row("Note").ToString
                End If


            Next

            m_grid.RowCount += 1
            currCCIndex = m_grid.RowCount
            m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(167, 214, 231)
            m_grid(currCCIndex, 4).CellValue = "รวมทั้งโครงการ"
            m_grid(currCCIndex, 5).CellValue = CountCC
            m_grid(currCCIndex, 6).CellValue = "เอกสาร"

            m_grid.RowCount += 1
            currCCIndex = m_grid.RowCount
            m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(167, 214, 231)
            m_grid(currCCIndex, 4).CellValue = "รวมทุกโครงการ"
            m_grid(currCCIndex, 5).CellValue = CountAllCC
            m_grid(currCCIndex, 6).CellValue = "เอกสาร"
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptCCPRSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptCCPRSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptCCPRSummary"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCCPRSummary.ListLabel}"
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
            Return "RptCCPRSummary"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptCCPRSummary"
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

