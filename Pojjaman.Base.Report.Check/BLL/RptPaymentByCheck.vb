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
    Public Class RptPaymentByCheck
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
            m_grid.VerticalThumbTrack = True

            CreateHeader()
            PopulateData()
            m_grid.EndUpdate()
        End Sub
        Private Sub CreateHeader()
            m_grid.RowCount = 1
            m_grid.ColCount = 8

            m_grid.ColWidths(1) = 150
            m_grid.ColWidths(2) = 150
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 120
            m_grid.ColWidths(7) = 200
            m_grid.ColWidths(8) = 200

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.DocNumber}") '"เลขที่เอกสาร"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.CheckNumber}") '"เลขที่เช็ค"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.CheckDate}") '"วันที่บนเช็ค"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.CheckDueDate}") '"วันที่ครบกำหนด"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.CheckCost}") '"มูลค่าเช็ค"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.Balance}") '"ยอดคงเหลือ"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.Statusy}") '"สถานะเช็ค"
            m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.Supplier}")  '"ผู้ขาย"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.PpID}")  '"รหัสใบสำคัญจ่าย"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.ReferenceDoc}") '"เอกสารอ้างอิง"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.Date}") '"วันที่"
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.PaidAmount}") '"ยอดตัดจ่าย"


            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentDocCode As String = ""
            Dim currentPVCode As String = ""

            Dim currDocIndex As Integer = -1
            Dim currPVIndex As Integer = -1
            Dim indent As String = Space(3)

            Dim sumCheckAmount As Decimal = 0
            Dim sumCheckRemain As Decimal = 0

            For Each row As DataRow In dt.Rows
                If row("DocId").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    m_grid(currDocIndex, 1).CellValue = row("DocCode")
                    m_grid(currDocIndex, 2).CellValue = row("CheckCode")
                    If IsDate(row("CheckDate")) Then
                        m_grid(currDocIndex, 3).CellValue = CDate(row("CheckDate")).ToShortDateString
                    End If
                    If IsDate(row("CheckDueDate")) Then
                        m_grid(currDocIndex, 4).CellValue = CDate(row("CheckDueDate")).ToShortDateString
                    End If
                    m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(CDec(row("CheckAmt")), DigitConfig.Price)
                    m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("CheckRemain")), DigitConfig.Price)
                    m_grid(currDocIndex, 7).CellValue = row("CheckStatus")
                    If Not row.IsNull("SupplierName") Then
                        m_grid(currDocIndex, 8).CellValue = row("SupplierName").ToString
                    End If
                    currentDocCode = row("DocId").ToString
                    currentPVCode = ""
                    m_grid(currDocIndex, 1).Tag = "Font.Bold"

                    sumCheckAmount += CDec(row("CheckAmt"))
                    sumCheckRemain += CDec(row("CheckRemain"))
                End If
                If row("PVId").ToString <> currentPVCode Then
                    m_grid.RowCount += 1
                    currPVIndex = m_grid.RowCount
                    m_grid.RowStyles(currPVIndex).ReadOnly = True
                    If Not row.IsNull("PVCode") Then
                        m_grid(currPVIndex, 1).CellValue = indent & row("PVCode").ToString
                    End If
                    If Not row.IsNull("RefDocCode") Then
                        m_grid(currPVIndex, 2).CellValue = indent & row("RefDocCode").ToString
                    End If
                    If Not row.IsNull("RefDocDate") Then
                        m_grid(currPVIndex, 3).CellValue = indent & CDate(row("RefDocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("PayAmt") Then
                        m_grid(currPVIndex, 5).CellValue = Configuration.FormatToString(CDec(row("PayAmt")), DigitConfig.Price)
                    End If
                    currentPVCode = row("PVId").ToString
                End If
            Next

            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            'm_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currDocIndex).Font.Bold = True
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.Total}") '"รวม"
            m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(sumCheckAmount, DigitConfig.Price)
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumCheckRemain, DigitConfig.Price)
            m_grid(currDocIndex, 1).Tag = "Font.Bold"

        End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptPaymentByCheck"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptPaymentByCheck"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptPaymentByCheck"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPaymentByCheck.ListLabel}"
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
            Return "RptPaymentByCheck"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptPaymentByCheck"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            'Dim i As Integer = 0
            'For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
            Dim fn As Font
            For rowIndex As Integer = 2 To m_grid.RowCount
                'If i > 1 Then
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

                n += 1
                'End If
                'i += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

