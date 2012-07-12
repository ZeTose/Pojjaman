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
  Public Class RptPaymentMethodSummary
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
    Public Overrides Sub ListInnewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
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
      m_grid.ColCount = 7

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = "เลขที่ใบสำคัญจ่าย"
      m_grid(0, 2).Text = "วันที่จ่ายชำระ"
      m_grid(0, 3).Text = "เลขที่เอกสาร"
      m_grid(0, 4).Text = "ชื่อเจ้าหนี้"
      m_grid(0, 5).Text = "ยอดเงิน"
      m_grid(0, 6).Text = "ยอดเงินจ่ายชำระ"
      m_grid(0, 7).Text = "ยอดเงินค้างจ่าย"

      m_grid(1, 1).Text = indent & "ประเภทจ่ายชำระ"
      m_grid(1, 2).Text = indent & "เลขที่อ้างอิง"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentDocCode As String = ""
      Dim currentItemCode As String = ""

      Dim indent As String = Space(3)
      Dim SumItem As Integer
      Dim SumAmount As Decimal
      Dim SumPay As Decimal
      Dim SumRemain As Decimal
      Dim currDocTrIndex As Integer = -1
      Dim currItemTrIndex As Integer = -1

      For Each row As DataRow In dt.Rows
        If row("DocCode").ToString <> currentDocCode Then
          SumItem += 1
          m_grid.RowCount += 1
          currDocTrIndex = m_grid.RowCount
          m_grid.RowStyles(currDocTrIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currDocTrIndex).Font.Bold = True
          m_grid.RowStyles(currDocTrIndex).ReadOnly = True
          m_grid(currDocTrIndex, 1).CellValue = row("DocCode")
          m_grid(currDocTrIndex, 2).CellValue = CDate(row("DocDate")).ToShortDateString
          m_grid(currDocTrIndex, 3).CellValue = row("RefDocCode")
          m_grid(currDocTrIndex, 4).CellValue = row("SupplierName")
          m_grid(currDocTrIndex, 5).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
          m_grid(currDocTrIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Pay")), DigitConfig.Price)
          Dim val As Object = row("Remain")
          If IsNumeric(val) Then
            m_grid(currDocTrIndex, 7).CellValue = Configuration.FormatToString(CDec(val), DigitConfig.Price)
          Else
            m_grid(currDocTrIndex, 7).CellValue = val
          End If
          SumAmount += CDec(row("Amount"))
          SumPay += CDec(row("Pay"))
          currentDocCode = row("DocCode").ToString
          currentItemCode = ""
          m_grid(currDocTrIndex, 1).Tag = "Font.Bold"
        End If
        If row("DocCode").ToString & row("Description").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currItemTrIndex = m_grid.RowCount
          m_grid.RowStyles(currItemTrIndex).ReadOnly = True
          If Not row.IsNull("Description") Then
            m_grid(currItemTrIndex, 1).CellValue = indent & row("Description").ToString
          End If
          If Not row.IsNull("PaymentCode") Then
            m_grid(currItemTrIndex, 2).CellValue = indent & row("PaymentCode").ToString
          End If
          If IsNumeric(row("ItemAmount")) Then
            m_grid(currItemTrIndex, 5).CellValue = Configuration.FormatToString(CDec(row("ItemAmount")), DigitConfig.Price)
          End If
          If IsNumeric(row("ItemPay")) Then
            m_grid(currItemTrIndex, 6).CellValue = Configuration.FormatToString(CDec(row("ItemPay")), DigitConfig.Price)
          End If
          currentItemCode = row("DocCode").ToString & row("Description").ToString
        End If
      Next
      SumRemain += SumAmount - SumPay
      m_grid.RowCount += 1
      currDocTrIndex = m_grid.RowCount
      m_grid.RowStyles(currDocTrIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currDocTrIndex).Font.Bold = True
      m_grid.RowStyles(currDocTrIndex).ReadOnly = True
      m_grid(currDocTrIndex, 2).CellValue = "รวม " & SumItem & " รายการ"
      m_grid(currDocTrIndex, 5).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
      m_grid(currDocTrIndex, 6).CellValue = Configuration.FormatToString(SumPay, DigitConfig.Price)
      m_grid(currDocTrIndex, 7).CellValue = Configuration.FormatToString(SumRemain, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptPaymentMethodSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPaymentMethodSummary.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptPaymentMethodSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptPaymentMethodSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPaymentMethodSummary.ListLabel}"
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
      Return "RptPaymentMethodSummary"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptPaymentMethodSummary"
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
        If Not m_grid(rowIndex, 1).Tag Is Nothing Then
          dpi.Font = fn1
        Else
          dpi.Font = fn2
        End If
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 4).CellValue
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
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 5).CellValue
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
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 6).CellValue
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
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 7).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        If Not m_grid(rowIndex, 1).Tag Is Nothing Then
          dpi.Font = fn1
        Else
          dpi.Font = fn2
        End If
        dpiColl.Add(dpi)
        n += 1

      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

