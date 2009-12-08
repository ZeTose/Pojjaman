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
  Public Class RptAPBillAcceptanceByDueDate
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
      m_grid.HorizontalThumbTrack = True
      m_grid.VerticalThumbTrack = True
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 8

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 120
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 120
      m_grid.ColWidths(6) = 120
      m_grid.ColWidths(7) = 120
      m_grid.ColWidths(8) = 120

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.limitDate}")          '"วันที่ครบกำหนด"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.BillAcceptance}")     '"ใบรับวางบิล"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.Date}")               '"วันที่"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.SupplierName}")       '"ชื่อผู้ขาย"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.AllBillAcceptanceTotal}") '"ยอดรับวางบิลทั้งหมด"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.AllPaymentRemainingTotal}")      '"ยอดค้างชำระทั้งหมด"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.Note}")               '"หมายเหตุ"

      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.DocID}") '"รหัสเอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.DocDate}")  '"วันที่เอกสาร"
      m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.BillAcceptanceTotal}")  '"ยอดรับวางบิล"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.PaymentRemaining}")  '"ยอดค้างชำระ"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.DocType}")  '"ประเภทเอกสาร"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentDocCode As String = ""
      Dim currentBillCode As String = ""

      Dim tmpTotalAmt As Decimal = 0
      Dim tmpTotalUnpaid As Decimal = 0

      Dim indent As String = Space(3)
      Dim currBillIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim sumAmt As Decimal = 0
      Dim sumPaymentAmt As Decimal = 0

      For Each row As DataRow In dt.Rows
        If row("DocCode").ToString <> currentDocCode Then
          If Not currentDocCode = "" Then
            m_grid(currBillIndex, 6).CellValue = Configuration.FormatToString(tmpTotalAmt, DigitConfig.Price)
            m_grid(currBillIndex, 7).CellValue = Configuration.FormatToString(tmpTotalUnpaid, DigitConfig.Price)
          End If
          m_grid.RowCount += 1
          currBillIndex = m_grid.RowCount
          m_grid.RowStyles(currBillIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currBillIndex).Font.Bold = True
          m_grid.RowStyles(currBillIndex).ReadOnly = True
          If Not row.IsNull("DueDate") Then
            If IsDate(row("DueDate")) Then
              m_grid(currBillIndex, 1).CellValue = CDate(row("DueDate")).ToShortDateString
            End If
          End If
          If Not row.IsNull("DocCode") Then
            m_grid(currBillIndex, 2).CellValue = row("DocCode")
          End If
          If Not row.IsNull("DocDate") Then
            If IsDate(row("DocDate")) Then
              m_grid(currBillIndex, 3).CellValue = CDate(row("DocDate")).ToShortDateString
            End If
          End If
          If Not row.IsNull("SupplierName") Then
            m_grid(currBillIndex, 4).CellValue = row("SupplierName")
          End If
          'm_grid(currBillIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
          'm_grid(currBillIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Unpaid")), DigitConfig.Price)
          If Not row.IsNull("Note") Then
            m_grid(currBillIndex, 8).CellValue = row("Note")
          End If
          m_grid(currBillIndex, 1).Tag = "Font.Bold"
          currentDocCode = row("DocCode").ToString
          currentBillCode = ""
          tmpTotalAmt = 0
          tmpTotalUnpaid = 0

        End If
        If row("BillCode").ToString <> currentBillCode Then
          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          m_grid(currDocIndex, 1).CellValue = ""
          If Not row.IsNull("BillCode") Then
            m_grid(currDocIndex, 2).CellValue = indent & row("BillCode").ToString
          End If
          If Not row.IsNull("BillDate") Then
            If IsDate(row("BillDate")) Then
              m_grid(currDocIndex, 3).CellValue = indent & CDate(row("BillDate")).ToShortDateString
            End If
          End If
          If IsNumeric(row("BillAmount")) Then
            m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(CDec(row("BillAmount")), DigitConfig.Price)
            If CInt(row("StockType")) = 46 Then
              tmpTotalAmt -= CDec(row("BillAmount"))
              sumAmt -= CDec(row("BillAmount"))
            Else
              tmpTotalAmt += CDec(row("BillAmount"))
              sumAmt += CDec(row("BillAmount"))
            End If
          End If
          If IsNumeric(row("BillUnpaid")) Then
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("BillUnpaid")), DigitConfig.Price)
            If CInt(row("StockType")) = 46 Then
              tmpTotalUnpaid -= CDec(row("BillUnpaid"))
              sumPaymentAmt -= CDec(row("BillUnpaid"))
            Else
              tmpTotalUnpaid += CDec(row("BillUnpaid"))
              sumPaymentAmt += CDec(row("BillUnpaid"))
            End If

          End If
          m_grid(currDocIndex, 8).CellValue = indent & row("Type").ToString

          currentBillCode = row("BillCode").ToString
        End If
      Next

      m_grid(currBillIndex, 6).CellValue = Configuration.FormatToString(tmpTotalAmt, DigitConfig.Price)
      m_grid(currBillIndex, 7).CellValue = Configuration.FormatToString(tmpTotalUnpaid, DigitConfig.Price)

      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).Font.Bold = True
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.Total}")       '"รวม"
      m_grid(currDocIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumAmt, DigitConfig.Price)
      m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(sumPaymentAmt, DigitConfig.Price)
      m_grid(currDocIndex, 1).Tag = "Font.Bold"
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPBillAcceptanceByDueDate"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPBillAcceptanceByDueDate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPBillAcceptanceByDueDate"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPBillAcceptanceByDueDate.ListLabel}"
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
      Return "RptAPBillAcceptanceByDueDate"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAPBillAcceptanceByDueDate"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      Dim fn As Font
      Dim SumBilledAmt As Decimal = 0
      Dim SumRemain As Decimal = 0
      For rowIndex As Integer = 2 To m_grid.RowCount

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

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace