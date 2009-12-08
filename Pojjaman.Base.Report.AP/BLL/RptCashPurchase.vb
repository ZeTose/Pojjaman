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
    Public Class RptCashPurchase
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
            m_grid.ColCount = 11

            m_grid.ColWidths(1) = 120
            m_grid.ColWidths(2) = 120
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 120
            m_grid.ColWidths(5) = 120
            m_grid.ColWidths(6) = 150
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100
            m_grid.ColWidths(10) = 120
            m_grid.ColWidths(11) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.ItemCode}") '"รหัสสินค้า"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.ItemName}") '"ชื่อสินค้า"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.DocDate}")  '"วันที่เอกสาร"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.DocID}")  '"เลขที่เอกสาร"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.RefCode}")  '"เลขที่ใบกำกับ"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.POCode}")  '"เลขที่ใบรับของ"
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.PO}")  '"เลขที่ใบสั่งซื้อ"
            m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.SupplierName}")  '"ชื่อผู้ขาย"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Num}")  '"จำนวน"
            m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Unit}")  '"หน่วยนับ"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.UnitPrice}")  '"ราคา/หน่วย"
            m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.DiscAmount}")  '"ส่วนลดสินค้า(เป็นเงิน)"
            m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Amount}")  '"จำนวนเงิน"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentItemCode As String = ""
            Dim currentDocCode As String = ""

            Dim currItemIndex As Integer = -1
            Dim currDocIndex As Integer = -1
            Dim indent As String = Space(3)
            Dim SumItem As Decimal = 0
            Dim tmpSupplier As Int32 = 0
            Dim SumQty As Decimal = 0
            Dim tmpQty As Decimal = 0
            Dim SumAmount As Decimal = 0
            Dim tmpAmount As Decimal = 0

            For Each row As DataRow In dt.Rows
                If row("ItemCode").ToString & row("ItemName").ToString <> currentItemCode Then
                    SumItem += 1
                    If SumItem > 1 Then
                        m_grid.RowCount += 1
                        currDocIndex = m_grid.RowCount
                        m_grid.RowStyles(currDocIndex).ReadOnly = True
                        m_grid(currDocIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Sum}") '"รวม"
                        m_grid(currDocIndex, 3).CellValue = tmpSupplier
                        m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Description}") '"รายการ"
                        tmpSupplier = 0
                        'm_grid(currDocIndex, 1).Tag = "Font.Bold"
                    End If
                    m_grid.RowCount += 1
                    currItemIndex = m_grid.RowCount
                    m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currItemIndex).Font.Bold = True
                    m_grid.RowStyles(currItemIndex).ReadOnly = True
                    m_grid(currItemIndex, 1).CellValue = row("ItemCode")
                    m_grid(currItemIndex, 2).CellValue = row("ItemName")
                    currentItemCode = row("ItemCode").ToString & row("ItemName").ToString
                    currentDocCode = ""
                    m_grid(currItemIndex, 1).Tag = "Font.Bold"
                End If
                If row("POCode").ToString <> currentDocCode Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    If IsDate(row("DocDate")) Then
                        m_grid(currDocIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
                    End If
                    If Not row.IsNull("DocCode") Then
                        m_grid(currDocIndex, 2).CellValue = indent & row("DocCode").ToString
                    End If
                    If Not row.IsNull("RefCode") Then
                        m_grid(currDocIndex, 3).CellValue = indent & row("RefCode").ToString
                    End If
                    If Not row.IsNull("POCode") Then
                        m_grid(currDocIndex, 4).CellValue = indent & row("POCode").ToString
                    End If
                    If Not row.IsNull("PO") Then
                        m_grid(currDocIndex, 5).CellValue = indent & row("PO").ToString
                    End If
                    If Not row.IsNull("SupplierName") Then
                        m_grid(currDocIndex, 6).CellValue = indent & row("SupplierName").ToString
                    End If
                    If IsNumeric(row("Qty")) Then
                        m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
                        tmpQty += CDec(row("Qty"))
                        SumQty += CDec(row("Qty"))
                    End If
                    If Not row.IsNull("Unit") Then
                        m_grid(currDocIndex, 8).CellValue = indent & row("Unit").ToString
                    End If
                    If IsNumeric(row("UnitPrice")) Then
                        m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("DiscAmount")) Then
                        m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(CDec(row("DiscAmount")), DigitConfig.Price)
                    End If
                    If IsNumeric(row("Amount")) Then
                        m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                        tmpAmount += CDec(row("Amount"))
                        SumAmount += CDec(row("Amount"))
                    End If
                    tmpSupplier += 1
                    currentDocCode = row("POCode").ToString
                End If
            Next

            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Sum}") '"รวม"
            m_grid(currDocIndex, 3).CellValue = tmpSupplier
            m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Description}") '"รายการ"

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currItemIndex).Font.Bold = True
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Total}") '"รวมทั้งสิ้น"
            m_grid(currItemIndex, 3).CellValue = SumItem
            m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.Description}") '"รายการ"
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(SumQty, DigitConfig.Qty)
            m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
            'm_grid(currItemIndex, 1).Tag = "Font.Bold"
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptCashPurchase"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptCashPurchase"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptCashPurchase"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptCashPurchase.ListLabel}"
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
            Return "RptCashPurchase"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptCashPurchase"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem
            Dim fn1 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Dim fn2 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

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
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col1"
                dpi.Value = m_grid(rowIndex, 2).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                If Not m_grid(rowIndex, 1).Tag Is Nothing Then
                    dpi.Font = fn1
                Else
                    dpi.Font = fn2
                End If
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

                dpi = New DocPrintingItem
                dpi.Mapping = "col10"
                dpi.Value = m_grid(rowIndex, 11).CellValue
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

