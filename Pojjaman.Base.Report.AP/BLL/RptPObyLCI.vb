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
    Public Class RptPObyLCI
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
            m_grid.ColCount = 8

            m_grid.ColWidths(1) = 150
            m_grid.ColWidths(2) = 250
            m_grid.ColWidths(3) = 120
            m_grid.ColWidths(4) = 150
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.ItemCode}") '"รหัสวัสดุ"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.ItemName}") '"ชื่อวัสดุ"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.SupplierCode}")   '"รหัสผู้ขาย"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.SupplierName}")   '"ชื่อผู้ขาย"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.POCode}")   '"รหัสใบสั่งซื้อ"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.CCInfo}")   '"Cost Center"
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.UnitName}")   '"หน่วยนับ"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.Qty}")  '"จำนวนสั่งซื้อ"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.UnitPrice}")  '"ราคาต่อหน่วย"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.Amount}")  '"จำนวนเงิน"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim currentItemCode As String = ""
            Dim currentSupplierCode As String = ""
            Dim currentSubUnit As String = ""
            Dim currentUnit As String = ""
            Dim SubUnitFlag As Boolean = True
            Dim UnitFlag As Boolean = True

            Dim currItemIndex As Integer = -1
            Dim currSupplierIndex As Integer = -1
            Dim indent As String = Space(3)
            Dim tmpSupplier As Int32 = 0
            Dim SumSupplier As Int32 = 0
            Dim SumItem As Int32 = 0
            Dim SumTotalQty As Decimal = 0
            Dim tmpTotalQty As Decimal = 0
            Dim SumTotalAmount As Decimal = 0
            Dim tmpTotalAmount As Decimal = 0

            For Each row As DataRow In dt.Rows
                If row("ItemId").ToString & row("ItemCode").ToString & row("ItemName").ToString <> currentItemCode Then
                    SumItem += 1
                    If SumItem > 1 Then
                        m_grid.RowCount += 1
                        currSupplierIndex = m_grid.RowCount
                        m_grid.RowStyles(currSupplierIndex).ReadOnly = True
                        m_grid(currSupplierIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLci.Sum}") & tmpSupplier & _
                        Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLci.Description}") '"รวม " " ราย"
                        m_grid(currSupplierIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLci.Sum}") '"รวม "
                        If SubUnitFlag = True Then
                            m_grid(currSupplierIndex, 6).CellValue = Configuration.FormatToString(tmpTotalQty, DigitConfig.Qty)
                        End If
                        m_grid(currSupplierIndex, 8).CellValue = Configuration.FormatToString(tmpTotalAmount, DigitConfig.Price)
                        tmpSupplier = 0
                        tmpTotalQty = 0
                        tmpTotalAmount = 0
                        SubUnitFlag = True
                        currentSubUnit = ""
                    End If
                    m_grid.RowCount += 1
                    currItemIndex = m_grid.RowCount
                    m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currItemIndex).Font.Bold = True
                    m_grid.RowStyles(currItemIndex).ReadOnly = True
                    m_grid(currItemIndex, 1).CellValue = row("ItemCode")
                    m_grid(currItemIndex, 2).CellValue = row("ItemName")
                    currentItemCode = row("ItemId").ToString & row("ItemCode").ToString & row("ItemName").ToString
                    currentItemCode = ""
                End If
                If row("SupplierCode").ToString <> currentSupplierCode Then
                    If row("UnitID").ToString <> currentSubUnit And currentSubUnit <> "" Then
                        SubUnitFlag = False
                    End If
                    If row("UnitID").ToString <> currentUnit And currentUnit <> "" Then
                        UnitFlag = False
                    End If
                    m_grid.RowCount += 1
                    currSupplierIndex = m_grid.RowCount
                    m_grid.RowStyles(currSupplierIndex).ReadOnly = True
                    If Not row.IsNull("SupplierCode") Then
                        m_grid(currSupplierIndex, 1).CellValue = indent & row("SupplierCode").ToString
                    End If
                    If Not row.IsNull("SupplierName") Then
                        m_grid(currSupplierIndex, 2).CellValue = indent & row("SupplierName").ToString
                    End If
                    If Not row.IsNull("POCode") Then
                        m_grid(currSupplierIndex, 3).CellValue = indent & row("POCode").ToString
                    End If
                    If Not row.IsNull("CCInfo") Then
                        m_grid(currSupplierIndex, 4).CellValue = indent & row("CCInfo").ToString
                    End If
                    If Not row.IsNull("UnitName") Then
                        m_grid(currSupplierIndex, 5).CellValue = indent & row("UnitName").ToString
                    End If
                    If IsNumeric(row("Qty")) Then
                        m_grid(currSupplierIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
                        tmpTotalQty += CDec(row("Qty"))
                        SumTotalQty += CDec(row("Qty"))
                    Else
                        m_grid(currSupplierIndex, 6).CellValue = ""
                    End If
                    If IsNumeric(row("UnitPrice")) Then
                        m_grid(currSupplierIndex, 7).CellValue = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
                    Else
                        m_grid(currSupplierIndex, 7).CellValue = ""
                    End If
                    If IsNumeric(row("Amount")) Then
                        m_grid(currSupplierIndex, 8).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
                        tmpTotalAmount += CDec(row("Amount"))
                        SumTotalAmount += CDec(row("Amount"))
                    Else
                        m_grid(currSupplierIndex, 8).CellValue = ""
                    End If
                    tmpSupplier += 1
                    SumSupplier += 1
                    currentSubUnit = row("UnitID").ToString
                    currentUnit = row("UnitID").ToString
                    currentItemCode = row("ItemId").ToString & row("ItemCode").ToString & row("ItemName").ToString
                End If
            Next

            m_grid.RowCount += 1
            currSupplierIndex = m_grid.RowCount
            m_grid.RowStyles(currSupplierIndex).ReadOnly = True
            m_grid(currSupplierIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLci.Sum}") _
             & tmpSupplier & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLci.Description}") '"รวม " " รายการ"
            m_grid(currSupplierIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLci.Sum}") '"รวม "
            If SubUnitFlag = True Then
                m_grid(currSupplierIndex, 6).CellValue = Configuration.FormatToString(tmpTotalQty, DigitConfig.Qty)
            End If
            m_grid(currSupplierIndex, 8).CellValue = Configuration.FormatToString(tmpTotalAmount, DigitConfig.Price)

            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
            m_grid.RowStyles(currItemIndex).Font.Bold = True
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLCI.SumItem}") & indent & SumItem '"รวมรายการวัสดุทั้งหมด" 
            m_grid(currItemIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPOByLCI.SumSupplier}") & indent & SumSupplier '"รวมจำนวนผู้ขายทั้งหมด" 
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptPObyLCI"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptPObyLCI"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptPObyLCI"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPObyLCI.ListLabel}"
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
            Return "RptPObyLCI"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptPObyLCI"
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

                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

