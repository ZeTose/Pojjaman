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
    Public Class RptPORemainingCost
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
            m_grid.ColCount = 10

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 120
            m_grid.ColWidths(3) = 200
            m_grid.ColWidths(4) = 100
            m_grid.ColWidths(5) = 100
            m_grid.ColWidths(6) = 100
            m_grid.ColWidths(7) = 100
            m_grid.ColWidths(8) = 100
            m_grid.ColWidths(9) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            Dim indent As String = Space(3)
            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.PODocDate}") '"วันที่ใบสั่งซื้อ"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.POCode}") '"รหัสใบสั่งซื้อ"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.SupplierName}") '"ชื่อผู้ขาย"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.POCost}") '"มูลค่าสั่งซื้อรวม"
            m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.POReceivedCost}") '"มูลค่ารับของรวม"
            m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.PORemainingCost}") '"มูลค่าค้างรับรวม"
            m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.DueDate}") '"วันที่กำหนดรับของ"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.DocCode}")  '"รหัสสินค้า"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.ItemName}")  '"ชื่อสินค้า"
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.UnitName}")   '"หน่วยนับ"
            m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.Qty}")  '"จำนวนสั่งซื้อ"
            m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.UnitPrice}")  '"ราคาต่อหน่วย"

            m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.OrderCost}")  '"มูลค่าสั่งซื้อ"
            m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.ReceivedCost}")  '"มูลค่ารับของ"
            m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.RemainingCost}")  '"มูลค่าค้างรับ"    
            m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.ReceiveDate}")  '"วันที่รับของจริง"    

            m_grid(1, 2).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 4).HorizontalAlignment = indent & Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left


        End Sub
        Private Sub PopulateData()
            Dim poDt As DataTable = Me.DataSet.Tables(0)
            Dim notShowDetail As Boolean = Me.DataSet.Tables(1).Rows(0).Item("IsNotShowDetail")
            Dim ShowAll As Boolean = Me.DataSet.Tables(2).Rows(0).Item("IsShowAll")
            Dim UnitFlag As Boolean = True

            Dim currentPOId As String = ""
            Dim lastReceiveDate As Date = Date.MinValue

            Dim POAmt As Decimal = 0
            Dim POReceiveAmt As Decimal = 0
            Dim PORemainingAmt As Decimal = 0

            Dim DiscAmt As Decimal = 0
            Dim ReceiveDiscAmt As Decimal = 0
            Dim RemainingDiscAmt As Decimal = 0

            Dim VATAmt As Decimal = 0
            Dim ReceiveVATAmt As Decimal = 0
            Dim RemainingVATAmt As Decimal = 0

            Dim currPOIndex As Integer = -1
            Dim currItemIndex As Integer = -1
            Dim currDiscIndex As Integer = -1
            Dim currVatIndex As Integer = -1
            Dim indent As String = Space(3)

            Dim sumPOAmt As Decimal = 0
            Dim sumPOReceive As Decimal = 0
            'Dim sumPORemain As Decimal = 0

            Dim ReceivedRow As DataRow()

            For Each poRow As DataRow In poDt.Rows
                If ShowAll OrElse (poRow("POaftertax") - poRow("Stockaftertax")) > 0 Then
                    If currentPOId <> "" And currentPOId <> poRow("DocId").ToString Then
                        If Not notShowDetail Then
                            m_grid.RowCount += 1
                            currDiscIndex = m_grid.RowCount
                            m_grid.RowStyles(currDiscIndex).ReadOnly = True
                            m_grid(currDiscIndex, 4).CellValue = "ส่วนลด"
                            m_grid(currDiscIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                            m_grid(currDiscIndex, 7).CellValue = Configuration.FormatToString(DiscAmt * -1, DigitConfig.Price)
                            m_grid(currDiscIndex, 8).CellValue = Configuration.FormatToString(ReceiveDiscAmt * -1, DigitConfig.Price)
                            m_grid(currDiscIndex, 9).CellValue = Configuration.FormatToString(RemainingDiscAmt * -1, DigitConfig.Price)
                            m_grid(currDiscIndex, 1).Tag = "Font.Bold"

                            m_grid.RowCount += 1
                            currVatIndex = m_grid.RowCount
                            m_grid.RowStyles(currVatIndex).ReadOnly = True
                            m_grid(currVatIndex, 4).CellValue = "VAT"
                            m_grid(currVatIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
                            m_grid(currVatIndex, 7).CellValue = Configuration.FormatToString(VATAmt, DigitConfig.Price)
                            m_grid(currVatIndex, 8).CellValue = Configuration.FormatToString(ReceiveVATAmt, DigitConfig.Price)
                            m_grid(currVatIndex, 9).CellValue = Configuration.FormatToString(RemainingVATAmt, DigitConfig.Price)
                            m_grid(currVatIndex, 1).Tag = "Font.Bold"
                        End If
                    End If

                    If poRow("DocId").ToString <> currentPOId Then
                        m_grid.RowCount += 1
                        currPOIndex = m_grid.RowCount
                        m_grid.RowStyles(currPOIndex).BackColor = Color.FromArgb(128, 255, 128)
                        m_grid.RowStyles(currPOIndex).Font.Bold = True
                        m_grid.RowStyles(currPOIndex).ReadOnly = True
                        If Not poRow.IsNull("DocDate") Then
                            If IsDate(poRow("DocDate")) Then
                                m_grid(currPOIndex, 1).CellValue = CDate(poRow("DocDate")).ToShortDateString
                            End If
                        End If
                        m_grid(currPOIndex, 2).CellValue = poRow("DocCode")
                        m_grid(currPOIndex, 3).CellValue = poRow("SupplierName")
                        m_grid(currPOIndex, 7).CellValue = Configuration.FormatToString(poRow("POaftertax"), DigitConfig.Price)
            m_grid(currPOIndex, 8).CellValue = Configuration.FormatToString(poRow("Stockaftertax"), DigitConfig.Price)
                        m_grid(currPOIndex, 9).CellValue = Configuration.FormatToString(poRow("POaftertax") - poRow("Stockaftertax"), DigitConfig.Price)
                        If Not poRow.IsNull("DueDate") Then
                            If IsDate(poRow("DueDate")) Then
                                m_grid(currPOIndex, 10).CellValue = CDate(poRow("DueDate")).ToShortDateString
                            End If
                        End If
                        m_grid(currPOIndex, 1).Tag = "Font.Bold"

                        sumPOAmt += poRow("POaftertax")
                        sumPOReceive += poRow("Stockaftertax")
                        'sumPORemain += poRow("POaftertax")

                        DiscAmt = Configuration.FormatToString(poRow("PODiscAmt"), DigitConfig.Price)
                        ReceiveDiscAmt = Configuration.FormatToString(poRow("StockDiscAmt"), DigitConfig.Price)
                        RemainingDiscAmt = Configuration.FormatToString(DiscAmt - ReceiveDiscAmt, DigitConfig.Price)

                        VATAmt = Configuration.FormatToString(poRow("POtaxAmt"), DigitConfig.Price)
                        ReceiveVATAmt = Configuration.FormatToString(poRow("StocktaxAmt"), DigitConfig.Price)
                        RemainingVATAmt = Configuration.FormatToString(VATAmt - ReceiveVATAmt, DigitConfig.Price)

                        currentPOId = poRow("DocId")
                    End If

                    If Not notShowDetail Then
                        m_grid.RowCount += 1
                        currItemIndex = m_grid.RowCount
                        m_grid.RowStyles(currItemIndex).ReadOnly = True
                        'If poRow("UnitID").ToString <> currItemIndex And currItemIndex <> "" Then
                        '    UnitFlag = False
                        'End If
                        If Not poRow.IsNull("ItemCode") Then
                            m_grid(currItemIndex, 2).CellValue = indent & poRow("ItemCode").ToString
                        End If
                        If Not poRow.IsNull("ItemName") Then
                            m_grid(currItemIndex, 3).CellValue = indent & poRow("ItemName").ToString
                        End If
                        If Not poRow.IsNull("UnitName") Then
                            m_grid(currItemIndex, 4).CellValue = indent & poRow("UnitName").ToString
                        End If
                        If IsNumeric(poRow("ItemQty")) Then
                            m_grid(currItemIndex, 5).CellValue = indent & Configuration.FormatToString(CDec(poRow("ItemQty")), DigitConfig.Qty)
                        End If
                        If IsNumeric(poRow("ItemUnitPrice")) Then
                            m_grid(currItemIndex, 6).CellValue = indent & Configuration.FormatToString(CDec(poRow("ItemUnitPrice")), DigitConfig.Qty)
                        End If
                        If IsNumeric(poRow("ItemAmt")) Then
                            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(poRow("ItemAmt")), DigitConfig.Price)
                        End If
                        If IsNumeric(poRow("ItemRecAmt")) Then
                            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(poRow("ItemRecAmt")), DigitConfig.Price)
                        End If
                        If IsNumeric(poRow("RemainingAmt")) Then
                            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(poRow("RemainingAmt")), DigitConfig.Price)
                        End If
                        If Not poRow.IsNull("ReceivingDate") Then
                            m_grid(currItemIndex, 10).CellValue = indent & (poRow("ReceivingDate")).ToString
                        End If
          End If
        End If
      Next

      If poDt.Rows.Count > 0 And currPOIndex <> -1 Then
        If Not notShowDetail Then
          m_grid.RowCount += 1
          currDiscIndex = m_grid.RowCount
          m_grid.RowStyles(currDiscIndex).ReadOnly = True
          m_grid(currDiscIndex, 4).CellValue = "ส่วนลด"
          m_grid(currDiscIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
          m_grid(currDiscIndex, 7).CellValue = Configuration.FormatToString(DiscAmt * -1, DigitConfig.Price)
          m_grid(currDiscIndex, 8).CellValue = Configuration.FormatToString(ReceiveDiscAmt * -1, DigitConfig.Price)
          m_grid(currDiscIndex, 9).CellValue = Configuration.FormatToString(RemainingDiscAmt * -1, DigitConfig.Price)
          m_grid(currDiscIndex, 1).Tag = "Font.Bold"

          m_grid.RowCount += 1
          currVatIndex = m_grid.RowCount
          m_grid.RowStyles(currVatIndex).ReadOnly = True
          m_grid(currVatIndex, 4).CellValue = "VAT"
          m_grid(currVatIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
          m_grid(currVatIndex, 7).CellValue = Configuration.FormatToString(VATAmt, DigitConfig.Price)
          m_grid(currVatIndex, 8).CellValue = Configuration.FormatToString(ReceiveVATAmt, DigitConfig.Price)
          m_grid(currVatIndex, 9).CellValue = Configuration.FormatToString(RemainingVATAmt, DigitConfig.Price)
          m_grid(currVatIndex, 1).Tag = "Font.Bold"
        End If
      End If

      m_grid.RowCount += 1
      currPOIndex = m_grid.RowCount
      m_grid.RowStyles(currPOIndex).Font.Bold = True
      m_grid.RowStyles(currPOIndex).BackColor = Color.FromArgb(167, 214, 231)
      m_grid.RowStyles(currPOIndex).ReadOnly = True
      m_grid(currPOIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.Total}")
      m_grid(currPOIndex, 7).CellValue = Configuration.FormatToString(sumPOAmt, DigitConfig.Price)
      m_grid(currPOIndex, 8).CellValue = Configuration.FormatToString(sumPOReceive, DigitConfig.Price)
      m_grid(currPOIndex, 9).CellValue = Configuration.FormatToString(sumPOAmt - sumPOReceive, DigitConfig.Price)
      m_grid(currPOIndex, 1).Tag = "Font.Bold"
        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptPORemainingCost"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptPORemainingCost"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptPORemainingCost"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingCost.ListLabel}"
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
            Return "RptPORemainingCost"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptPORemainingCost"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim n As Integer = 0
            For rowIndex As Integer = 2 To m_grid.RowCount
                Dim fn As Font

                If m_grid(rowIndex, 1).Tag Is Nothing Then
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                Else
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
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

                dpi = New DocPrintingItem
                dpi.Mapping = "col8"
                dpi.Value = m_grid(rowIndex, 9).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col9"
                dpi.Value = m_grid(rowIndex, 10).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpi.Font = fn
                dpiColl.Add(dpi)

                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace

