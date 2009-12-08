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
    Public Class RptUnreceivedPOItem
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
            m_grid.ColCount = 10

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 150
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 80
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100
            m_grid.ColWidths(10) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.SupplierCode}") '"รหัสผู้ขาย"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.ISupplierName}") '"ชื่อผู้ขาย"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.DocDate}")  '"วันที่เอกสาร"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.DocID}")  '"เลขที่เอกสาร"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.ReceivingDate}")  '"วันที่กำหนดส่ง"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.CostCenter}")  '"Cost Center"

            m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.ItemCode}")  '"รหัสสินค้า"
            m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.ItemName}")  '"ชื่อสินค้า"
            m_grid(2, 5).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.Unit}")  '"หน่วยนับ"
            m_grid(2, 6).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.Qty}")  '"จำนวนที่สั่งซื้อ"
            m_grid(2, 7).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.ReceivedQty}")  '"จำนวนรับ"
            m_grid(2, 8).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.UnReceivedQty}")  '"จำนวนค้างรับ"
            m_grid(2, 9).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.UnitPrice}")  '"ราคาต่อหน่วย"
            m_grid(2, 10).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.UnReceivedAmt}")  '"มูลค่าค้างรับ"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(2, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentSupplierCode As String = ""
            Dim currentDocCode As String = ""

            Dim currentLine As String = ""

            Dim currSupplierIndex As Integer = -1
            Dim currDocIndex As Integer = -1
            Dim currLciIndex As Integer = -1
            Dim indent As String = Space(3)
            For Each row As DataRow In dt.Rows
                If row("SupplierCode").ToString <> currentSupplierCode Then
                    m_grid.RowCount += 1
                    currSupplierIndex = m_grid.RowCount
                    m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currSupplierIndex).Font.Bold = True
                    m_grid.RowStyles(currSupplierIndex).ReadOnly = True
                    m_grid(currSupplierIndex, 1).CellValue = row("SupplierCode")
                    m_grid(currSupplierIndex, 2).CellValue = row("SupplierName")
                    currentSupplierCode = row("SupplierCode").ToString
                    currentDocCode = ""
                End If
                If row("DocCode").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).BackColor = Color.AntiqueWhite
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    If IsDate(row("DocDate")) Then
                        m_grid(currDocIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("DocCode") Then
                        m_grid(currDocIndex, 2).CellValue = indent & row("DocCode").ToString
                    End If
                    If IsDate(row("ReceivingDate")) Then
                        m_grid(currDocIndex, 3).CellValue = indent & CDate(row("ReceivingDate")).ToShortDateString
                    End If
                    If Not row.IsNull("CostCenterName") Then
                        m_grid(currDocIndex, 4).CellValue = indent & row("CostCenterName").ToString
                    End If
                    currentDocCode = row("DocCode").ToString
                    currentLine = ""
                End If
                If row("LineNumber").ToString <> currentLine Then
                    m_grid.RowCount += 1
                    currLciIndex = m_grid.RowCount
                    m_grid.RowStyles(currLciIndex).ReadOnly = True
                    If Not row.IsNull("ItemCode") Then
                        m_grid(currLciIndex, 1).CellValue = indent & indent & row("ItemCode").ToString
                    End If
                    If Not row.IsNull("ItemName") Then
                        m_grid(currLciIndex, 2).CellValue = indent & indent & row("ItemName").ToString
                    End If
                    m_grid(currLciIndex, 3).CellValue = DBNull.Value
                    m_grid(currLciIndex, 4).CellValue = DBNull.Value
                    If Not row.IsNull("UnitName") Then
                        m_grid(currLciIndex, 5).CellValue = indent & indent & row("UnitName").ToString
                    End If
                    If IsNumeric(row("Qty")) Then
                        m_grid(currLciIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
                    End If
                    If IsNumeric(row("ReceivedQty")) Then
                        m_grid(currLciIndex, 7).CellValue = Configuration.FormatToString(CDec(row("ReceivedQty")), DigitConfig.Qty)
                    End If
                    If IsNumeric(row("UnReceivedQty")) Then
                        m_grid(currLciIndex, 8).CellValue = Configuration.FormatToString(CDec(row("UnReceivedQty")), DigitConfig.Qty)
                    End If
                    If IsNumeric(row("UnitPrice")) Then
                        m_grid(currLciIndex, 9).CellValue = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("UnReceivedAmt")) Then
                        m_grid(currLciIndex, 10).CellValue = Configuration.FormatToString(CDec(row("UnReceivedAmt")), DigitConfig.Price)
                    End If
                    currentLine = row("LineNumber").ToString
                End If
            Next
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptUnreceivedPOItem"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptUnreceivedPOItem"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptUnreceivedPOItem"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptUnreceivedPOItem.ListLabel}"
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
            Return "RptUnreceivedPOItem"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptUnreceivedPOItem"
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

                dpi = New DocPrintingItem
                dpi.Mapping = "col9"
                dpi.Value = m_grid(rowIndex, 10).CellValue
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

