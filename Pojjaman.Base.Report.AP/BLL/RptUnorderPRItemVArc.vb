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
    Public Class RptUnorderPRItemVArc
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
            m_grid.ColWidths(2) = 250
            m_grid.ColWidths(3) = 280
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 160
            m_grid.ColWidths(9) = 120

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

            m_grid.Rows.HeaderCount = 2
            m_grid.Rows.FrozenCount = 2

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.CCCode}") '"รหัสโครงการ"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.CCName}") '"ชื่อโครงการ"

            m_grid(2, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.PRCode}")  '"เลขที่ใบขอซื้อ"
            m_grid(2, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.DocDate}")  '"วันที่ใบขอซื้อ"

            m_grid(1, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.LciCode}")    '"รหัสวัสดุ"
            m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.LciName}")    '"ชื่อวัสดุ"
            m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.Unit}")  '"หน่วยนับ"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.PRQty}")  '"จำนวนขอซื้อ"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.QtyUnoderAll}")   '"จำนวนค้างทั้งหมด"
            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.QtyUnapprove}")    '"จำนวนค้างอนุมัติ"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.QtyUnStockCheck}")   '"จำนวนค้างตรวจสอบโดยคลัง"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.QtyUnPO}")  '"จำนวนค้างสั่ง (PO)"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right


        End Sub
        Private Sub PopulateData()

            Dim dt As DataTable = Me.DataSet.Tables(0)

            Dim indent As String = Space(3)

            Dim currCC As String = ""
            Dim currCCIndex As Integer = -1
            Dim currDoc As String = ""
            Dim currDocIndex As Integer = -1
            Dim currLCI As String = ""

            Dim sumPrQty As Decimal = 0
            Dim sumRemainAllQty As Decimal = 0
            Dim sumUnApproveQty As Decimal = 0
            Dim sumUnStoreApproeveQty As Decimal = 0
            Dim sumPOReamainQty As Decimal = 0

            Dim sumLCIQty As Decimal = 0
            Dim sumRemainAllLCIQty As Decimal = 0
            Dim currsumLCIIndex As Integer = -1

            Dim Qty As New Hashtable

            For Each ccrow As DataRow In dt.Rows
                If currCC <> ccrow("cccode").ToString Then
                    m_grid.RowCount += 1
                    currCCIndex = m_grid.RowCount
                    m_grid.RowStyles(currCCIndex).BackColor = Color.FromArgb(128, 255, 128)
                    m_grid.RowStyles(currCCIndex).Font.Bold = True
                    m_grid.RowStyles(currCCIndex).ReadOnly = True

                    m_grid(currCCIndex, 1).CellValue = ccrow("cccode").ToString
                    m_grid(currCCIndex, 2).CellValue = ccrow("ccname").ToString

                    currCC = ccrow("cccode").ToString

                End If
           
                If currLCI <> ccrow("cccode").ToString & ccrow("lci_code").ToString Then

                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount

                    m_grid.RowStyles(currDocIndex).BackColor = Color.AntiqueWhite
                    m_grid.RowStyles(currDocIndex).Font.Bold = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    m_grid.RowStyles(currDocIndex).ReadOnly = True
                    m_grid(currDocIndex, 2).CellValue = indent & ccrow("lci_code").ToString
                    m_grid(currDocIndex, 3).CellValue = indent & ccrow("lci_name").ToString
                    m_grid(currDocIndex, 4).CellValue = ccrow("unit_name").ToString

                    currLCI = ccrow("cccode").ToString & ccrow("lci_code").ToString

                    Qty.Add(currDocIndex, 0)

                    currsumLCIIndex = m_grid.RowCount
                    sumLCIQty = 0
                    sumRemainAllLCIQty = 0
                End If


                If currDoc <> ccrow("cccode").ToString & ccrow("DocCode").ToString & ccrow("lci_code").ToString Then
                    m_grid.RowCount += 1
                    currDocIndex = m_grid.RowCount
                    m_grid(currDocIndex, 1).CellValue = indent & ccrow("DocCode").ToString
                    If IsDate(ccrow("pr_docdate")) Then
                        m_grid(currDocIndex, 2).CellValue = indent & indent & CDate(ccrow("pr_docdate")).ToShortDateString
                    End If
                    currDoc = ccrow("cccode").ToString & ccrow("DocCode").ToString & ccrow("lci_code").ToString
                End If

                If CDec(ccrow("pri_qty")) <> 0 Then
                    m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(CDec(ccrow("pri_qty")), DigitConfig.Qty)
                    sumPrQty += CDec(ccrow("pri_qty"))

                    sumLCIQty += CDec(ccrow("pri_qty"))
                    m_grid(currsumLCIIndex, 5).CellValue = Configuration.FormatToString(sumLCIQty, DigitConfig.Qty)


                End If
                If CDec(ccrow("remain")) > 0 Then
                    m_grid(currsumLCIIndex, 6).CellValue = Configuration.FormatToString(CDec(ccrow("remain")), DigitConfig.Qty)
                    sumRemainAllQty += CDec(ccrow("remain"))

                    sumRemainAllLCIQty += CDec(ccrow("remain"))
                    m_grid(currsumLCIIndex, 6).CellValue = Configuration.FormatToString(sumLCIQty, DigitConfig.Qty)

                End If

                If CInt(ccrow("ApprovePerson")) = 0 Then
                    If CDec(ccrow("remain")) <> 0 Then
                        m_grid(currsumLCIIndex, 7).CellValue = Configuration.FormatToString(CDec(ccrow("remain")), DigitConfig.Qty)
                        sumUnApproveQty += CDec(ccrow("remain"))
                    End If
                Else
                    m_grid(currsumLCIIndex, 7).CellValue = Configuration.FormatToString(0, DigitConfig.Qty)
                End If

                If CInt(ccrow("ApproveStorePerson")) = 0 And CInt(ccrow("ApprovePerson")) > 0 Then
                    If CDec(ccrow("remain")) <> 0 Then
                        m_grid(currsumLCIIndex, 8).CellValue = Configuration.FormatToString(CDec(ccrow("remain")), DigitConfig.Qty)
                        sumUnStoreApproeveQty += CDec(ccrow("remain"))
                    End If
                Else
                    m_grid(currsumLCIIndex, 8).CellValue = Configuration.FormatToString(0, DigitConfig.Qty)
                End If
                If CInt(ccrow("ApprovePerson")) > 0 And CInt(ccrow("ApproveStorePerson")) > 0 Then
                    If CDec(ccrow("remain")) <> 0 Then
                        m_grid(currsumLCIIndex, 9).CellValue = Configuration.FormatToString(CDec(ccrow("remain")), DigitConfig.Qty)
                        sumPOReamainQty += CDec(ccrow("remain"))
                    End If
                Else
                    m_grid(currsumLCIIndex, 9).CellValue = Configuration.FormatToString(0, DigitConfig.Qty)
                End If

            Next

            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).Font.Bold = True
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRAnalysis.Total}")  'รวม
            m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(sumPrQty, DigitConfig.Qty)
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumRemainAllQty, DigitConfig.Qty)
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumUnApproveQty, DigitConfig.Qty)
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(sumUnStoreApproeveQty, DigitConfig.Qty)
            m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(sumPOReamainQty, DigitConfig.Qty)

        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptUnorderPRItemVArc"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItemVArc.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptUnorderPRItemVArc"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptUnorderPRItemVArc"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptUnorderPRItemVArc.DetailLabel}"
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
            Return "RptUnorderPRItemVArc"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptUnorderPRItemVArc"
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

