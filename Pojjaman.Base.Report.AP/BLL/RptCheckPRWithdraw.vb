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
    Public Class RptCheckPRWithdraw
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
            m_grid.ColCount = 6

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 350
            m_grid.ColWidths(3) = 150
            m_grid.ColWidths(4) = 180
            m_grid.ColWidths(5) = 150
            m_grid.ColWidths(6) = 180

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.PRCode}") '"เลขที่ใบขอซื้อ"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.DocDate}") '"วันที่ใบขอซื้อ"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.EmpCode}") '"รหัสพนักงานที่ขอซื้อ"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.EmpName}") '"ชื่อพนักงานที่ขอซื้อ"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.CCCode}") '"รหัสโครงการ"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.CCName}") '"ชื่อโครงการ"


            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.LciCode}")  '"รหัสวัสดุ"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.LciName}")  '"ชื่อวัสดุ"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.Unit}")  '"หน่วยนับ"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.PRAmount}")  '"จำนวนออก PR"
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.WithdQty}")  '"จำนวนเบิก"
            m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.PRUnwithdraw}")  '"จำนวนค้างเบิก"

            m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.WithdCode}")  '"เลขที่ใบเบิก"
            m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.DocDateWithd}")   '"วันที่ใบเบิก"
            m_grid(2, 3).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.EmpCodeWithd}")   '"รหัสพนักงานที่เบิก"
            m_grid(2, 4).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.EmpNameWithd}")  '"ชื่อพนักงานที่เบิก"
            m_grid(2, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.Qty}")  '"จำนวน"



            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            'Dim dt1 As DataTable = Me.DataSet.Tables(1)
            Dim currentDocCode As String = ""
            Dim currentLciCode As String = ""
            Dim currentItemCode As String = ""

            Dim currDocIndex As Integer = -1
            Dim currLciIndex As Integer = -1
            Dim currItemIndex As Integer = -1

            Dim sumMatQty As Decimal = 0
            Dim priQty As Decimal = 0

            Dim indent As String = Space(3)

            Dim showAll As Int16
            showAll = CInt(Me.Filters(7).Value)

            For Each row As DataRow In dt.Rows
                If row("DocCode").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    m_grid(currDocIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                    m_grid(currDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                    m_grid(currDocIndex, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

                    m_grid(currDocIndex, 1).CellValue = row("DocCode")
                    m_grid(currDocIndex, 2).CellValue = row("DocDate")
                    m_grid(currDocIndex, 3).CellValue = row("EmpCode")
                    m_grid(currDocIndex, 4).CellValue = row("EmpName")
                    m_grid(currDocIndex, 5).CellValue = row("CCCode")
                    m_grid(currDocIndex, 6).CellValue = row("CCName")
                    currentDocCode = row("DocCode").ToString
                End If
                If sumMatQty > 0 Then
                    m_grid(currLciIndex, 5).CellValue = Configuration.FormatToString(sumMatQty, DigitConfig.Qty)
                    m_grid(currLciIndex, 6).CellValue = Configuration.FormatToString(priQty - sumMatQty, DigitConfig.Qty)
                    sumMatQty = 0
                End If
                m_grid.RowCount += 1
                currLciIndex = m_grid.RowCount
                m_grid.RowStyles(currLciIndex).BackColor = Color.FromArgb(167, 214, 231)
                m_grid.RowStyles(currLciIndex).ReadOnly = True
                If Not row.IsNull("LciCode") Then
                    m_grid(currLciIndex, 1).CellValue = indent & row("LciCode").ToString
                End If
                If Not row.IsNull("LciName") Then
                    m_grid(currLciIndex, 2).CellValue = indent & row("LciName").ToString
                End If
                If Not row.IsNull("Unit") Then
                    m_grid(currLciIndex, 3).CellValue = indent & row("Unit").ToString
                End If
                If IsNumeric(row("Qty")) Then
                    m_grid(currLciIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
                    priQty = CDec(row("Qty"))
                End If
                m_grid(currLciIndex, 5).CellValue = Configuration.FormatToString(0, DigitConfig.Qty)
                m_grid(currLciIndex, 6).CellValue = Configuration.FormatToString(priQty - sumMatQty, DigitConfig.Qty)

                For Each row1 As DataRow In dt.Select("prientity = " & row("prientity").ToString & _
                                                      " and pripr = " & row("pripr").ToString & _
                                                      " and StockCode is not null")
                    m_grid.RowCount += 1
                    currItemIndex = m_grid.RowCount
                    m_grid.RowStyles(currItemIndex).ReadOnly = True
                    m_grid(currItemIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

                    m_grid(currItemIndex, 1).CellValue = indent & indent & row1("StockCode")
                    If IsDate(row1("StockDocDate")) Then
                        m_grid(currItemIndex, 2).CellValue = CDate(row1("StockDocDate")).ToShortDateString
                    End If
                    m_grid(currItemIndex, 3).CellValue = indent & indent & row1("SEmpCode").ToString
                    m_grid(currItemIndex, 4).CellValue = indent & indent & row1("SEmpName").ToString
                    m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row1("matQty")), DigitConfig.Qty)

                    sumMatQty += CDec(row1("matQty"))
                Next
            Next
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptCheckPRWithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptCheckPRWithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptCheckPRWithdraw"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCheckPRWithdraw.ListLabel}"
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
            Return "RptCheckPRWithdraw"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptCheckPRWithdraw"
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

                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

