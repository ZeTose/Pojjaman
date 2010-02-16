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
    Public Class RptPurchaseAnalysis
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
            m_grid.ColCount = 9

            m_grid.ColWidths(1) = 150
            m_grid.ColWidths(2) = 200
            m_grid.ColWidths(3) = 100
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.SupplierCode}") '"รหัสผู้ขาย"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.SupplierName}") '"ชื่อผู้ขาย"
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.CrdPurchQty}") '"ซื้อเชื่อ"
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.CrdPurchQty}") '"ซื้อเชื่อ"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.CrdCashQty}") '"ซื้อสด"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.CrdCashQty}") '"ซื้อสด"
            m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Sum}") '"รวม"
            m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Sum}") '"รวม"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.ItemCode}")  '"รหัสสินค้า"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.ItemName}")  '"ชื่อสินค้า"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Unit}")  '"หน่วยนับ"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Num}")  '"จำนวน"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Cost}")  '"จำนวนเงิน"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Num}")  '"จำนวน"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Cost}")  '"จำนวนเงิน"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Num}")  '"จำนวน"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Cost}")  '"จำนวนเงิน"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentSupplierCode As String = ""
            Dim currentItemCode As String = ""
            Dim currentSubUnit As String = ""
            Dim currentUnit As String = ""
            Dim SubUnitFlag As Boolean = True
            Dim UnitFlag As Boolean = True

            Dim currSupplierIndex As Integer = -1
            Dim currItemIndex As Integer = -1
            Dim indent As String = Space(3)
            Dim tmpItem As Int32 = 0
            Dim SumItem As Int32 = 0
            Dim SumSupplier As Int32 = 0
            Dim SumCrdPurchQty As Decimal = 0
            Dim tmpCrdPurchQty As Decimal = 0
            Dim SumCrdPurchAmount As Decimal = 0
            Dim tmpCrdPurchAmount As Decimal = 0
            Dim SumCashQty As Decimal = 0
            Dim tmpCashQty As Decimal = 0
            Dim SumCashAmount As Decimal = 0
            Dim tmpCashAmount As Decimal = 0
            Dim SumTotalQty As Decimal = 0
            Dim tmpTotalQty As Decimal = 0
            Dim SumTotalAmount As Decimal = 0
            Dim tmpTotalAmount As Decimal = 0

            For Each row As DataRow In dt.Rows
                If row("SupplierCode").ToString & row("SupplierName").ToString <> currentSupplierCode Then
                    SumSupplier += 1
                    If SumSupplier > 1 Then
                        m_grid.RowCount += 1
                        currItemIndex = m_grid.RowCount
                        m_grid.RowStyles(currItemIndex).ReadOnly = True
                        m_grid(currItemIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Sum}") & tmpItem & _
                        Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Description}") '"รวม "" รายการ"
                        m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Sum}") '"รวม "
                        If SubUnitFlag = True Then
                            m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(tmpCrdPurchQty, DigitConfig.Qty)
                            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpCashQty, DigitConfig.Qty)
                            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpTotalQty, DigitConfig.Qty)
                        End If
                        m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(tmpCrdPurchAmount, DigitConfig.Price)
                        m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpCashAmount, DigitConfig.Price)
                        m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpTotalAmount, DigitConfig.Price)
                        tmpItem = 0
                        tmpCrdPurchQty = 0
                        tmpCrdPurchAmount = 0
                        tmpCashQty = 0
                        tmpCashAmount = 0
                        tmpTotalQty = 0
                        tmpTotalAmount = 0
                        SubUnitFlag = True
                        currentSubUnit = ""
                    End If
                    m_grid.RowCount += 1
                    currSupplierIndex = m_grid.RowCount
                    m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currSupplierIndex).Font.Bold = True
                    m_grid.RowStyles(currSupplierIndex).ReadOnly = True
                    m_grid(currSupplierIndex, 1).CellValue = row("SupplierCode")
                    m_grid(currSupplierIndex, 2).CellValue = row("SupplierName")
                    currentSupplierCode = row("SupplierCode").ToString & row("SupplierName").ToString
                    currentItemCode = ""
                End If
                If row("ItemCode").ToString & row("ItemName").ToString <> currentItemCode Then
                    If row("UnitID").ToString <> currentSubUnit And currentSubUnit <> "" Then
                        SubUnitFlag = False
                    End If
                    If row("UnitID").ToString <> currentUnit And currentUnit <> "" Then
                        UnitFlag = False
                    End If
                    m_grid.RowCount += 1
                    currItemIndex = m_grid.RowCount
                    m_grid.RowStyles(currItemIndex).ReadOnly = True
                    If Not row.IsNull("ItemCode") Then
                        m_grid(currItemIndex, 1).CellValue = indent & row("ItemCode").ToString
                    End If
                    If Not row.IsNull("ItemName") Then
                        m_grid(currItemIndex, 2).CellValue = indent & row("ItemName").ToString
                    End If
                    If Not row.IsNull("UnitName") Then
                        m_grid(currItemIndex, 3).CellValue = indent & row("UnitName").ToString
                    End If
                    If IsNumeric(row("CreditPurchaseQty")) Then
                        m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(row("CreditPurchaseQty")), DigitConfig.Qty)
                        tmpCrdPurchQty += CDec(row("CreditPurchaseQty"))
                        SumCrdPurchQty += CDec(row("CreditPurchaseQty"))
                    Else
                        m_grid(currItemIndex, 4).CellValue = ""
                    End If
                    If IsNumeric(row("CreditPurchaseAmount")) Then
                        m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("CreditPurchaseAmount")), DigitConfig.Price)
                        tmpCrdPurchAmount += CDec(row("CreditPurchaseAmount"))
                        SumCrdPurchAmount += CDec(row("CreditPurchaseAmount"))
                    Else
                        m_grid(currItemIndex, 5).CellValue = ""
                    End If
                    If IsNumeric(row("CashQty")) Then
                        m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("CashQty")), DigitConfig.Qty)
                        tmpCashQty += CDec(row("CashQty"))
                        SumCashQty += CDec(row("CashQty"))
                    Else
                        m_grid(currItemIndex, 6).CellValue = ""
                    End If
                    If IsNumeric(row("CashAmount")) Then
                        m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("CashAmount")), DigitConfig.Price)
                        tmpCashAmount += CDec(row("CashAmount"))
                        SumCashAmount += CDec(row("CashAmount"))
                    Else
                        m_grid(currItemIndex, 7).CellValue = ""
                    End If
                    If IsNumeric(row("TotalQty")) Then
                        m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("TotalQty")), DigitConfig.Qty)
                        tmpTotalQty += CDec(row("TotalQty"))
                        SumTotalQty += CDec(row("TotalQty"))
                    End If
                    If IsNumeric(row("TotalAmount")) Then
                        m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(row("TotalAmount")), DigitConfig.Price)
                        tmpTotalAmount += CDec(row("TotalAmount"))
                        SumTotalAmount += CDec(row("TotalAmount"))
                    End If
                    tmpItem += 1
                    SumItem += 1
                    currentSubUnit = row("UnitID").ToString
                    currentUnit = row("UnitID").ToString
                    currentItemCode = row("ItemCode").ToString & row("ItemName").ToString
                End If
            Next

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Sum}") & tmpItem & _
            Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Description}") '"รวม " " รายการ"
            m_grid(currItemIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.Sum}") '"รวม "
            If SubUnitFlag = True Then
                m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(tmpCrdPurchQty, DigitConfig.Qty)
                m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpCashQty, DigitConfig.Qty)
                m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(tmpTotalQty, DigitConfig.Qty)
            End If
            m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(tmpCrdPurchAmount, DigitConfig.Price)
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(tmpCashAmount, DigitConfig.Price)
            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(tmpTotalAmount, DigitConfig.Price)

            m_grid.RowCount += 1
            currSupplierIndex = m_grid.RowCount
            m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currSupplierIndex).Font.Bold = True
            m_grid.RowStyles(currSupplierIndex).ReadOnly = True
            m_grid(currSupplierIndex, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.SumSupplier}") & indent & SumSupplier '"รวมจำนวนผู้ขายทั้งหมด"
            m_grid(currSupplierIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.SumItem}") & indent & SumItem '"รวมรายการทั้งหมด" 
            If UnitFlag = True Then
                m_grid(currSupplierIndex, 4).CellValue = Configuration.FormatToString(SumCrdPurchQty, DigitConfig.Qty)
                m_grid(currSupplierIndex, 6).CellValue = Configuration.FormatToString(SumCashQty, DigitConfig.Qty)
                m_grid(currSupplierIndex, 8).CellValue = Configuration.FormatToString(SumTotalQty, DigitConfig.Qty)
            End If
            m_grid(currSupplierIndex, 5).CellValue = Configuration.FormatToString(SumCrdPurchAmount, DigitConfig.Price)
            m_grid(currSupplierIndex, 7).CellValue = Configuration.FormatToString(SumCashAmount, DigitConfig.Price)
            m_grid(currSupplierIndex, 9).CellValue = Configuration.FormatToString(SumTotalAmount, DigitConfig.Price)
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptPurchaseAnalysis"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptPurchaseAnalysis"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptPurchaseAnalysis"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPurchaseAnalysis.ListLabel}"
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
            Return "RptPurchaseAnalysis"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptPurchaseAnalysis"
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

