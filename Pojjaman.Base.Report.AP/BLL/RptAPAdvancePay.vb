Option Strict On
Option Explicit On 

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
  Public Class RptAPAdvancePay
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
      m_grid.RowCount = 2
      m_grid.ColCount = 12

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 200
      m_grid.ColWidths(6) = 90
      m_grid.ColWidths(7) = 60
      m_grid.ColWidths(8) = 80
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100
      m_grid.ColWidths(12) = 100

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
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.CostcenterCode}")  '"รหัส Cost Center"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.CostcenterName}")  '"ชื่อ Cost Center"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.DocCode}")  '"เลขที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.DocDate}")  '"วันที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.VatInvoice}")  '"เลขที่ใบกำกับ"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.SupplierCode}")  '"รหัสเจ้าหนี้"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.SupplierName}")  '"ชื่อเจ้าหนี้"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.TaxBase}") '"ฐานภาษี"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.TaxRate}") '"อัตรา"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.TaxAmount}") '"เงินภาษี"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.AfterTax}")  '"รวม"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.CreditAmt}")  '"ยอดหักมัดจำ"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RemainingAmt}")  '"ยอดคงเหลือ"
      m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Status}")  '"สถานะ"

      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RefDocCode}")  '"เลขที่เอกสาร"
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RefDocDate}")  '"วันที่เอกสาร"
      m_grid(2, 5).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.RefDocType}")  '"ประเภทเอกสาร"
      m_grid(2, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.AdvanceAmt}")  '"ยอดหัก" --
      m_grid(2, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Remain}")  '"คงเหลือ" --

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
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)

      Dim currentCostCenterCode As String = ""
      Dim currentDocCode As String = ""
      Dim currentRefDocCode As String = ""

      Dim indent As String = Space(3)
      Dim currCostCenterIndex As Integer = -1
      Dim currDocCodeIndex As Integer = -1
      Dim currRefDocIndex As Integer = -1

      'Dim tmpAmount As Decimal = 0
      'Dim tmpCreditAmount As Decimal = 0

      Dim CreditAmt As Decimal = 0

      Dim SumTaxBase As Decimal = 0
      Dim SumTaxAmt As Decimal = 0
      Dim SumTotal As Decimal = 0
      Dim SumCredit As Decimal = 0

      Dim remainningAmount As Decimal = 0

      For Each row As DataRow In dt.Rows
        If row("CostCenterCode").ToString <> currentCostCenterCode Then
          If currDocCodeIndex <> -1 Then
            m_grid(currDocCodeIndex, 10).CellValue = Configuration.FormatToString(CreditAmt, DigitConfig.Price)
            m_grid(currDocCodeIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)
            CreditAmt = 0
            remainningAmount = 0
          End If
          m_grid.RowCount += 1
          currCostCenterIndex = m_grid.RowCount
          m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
          m_grid.RowStyles(currCostCenterIndex).ReadOnly = True
          m_grid(currCostCenterIndex, 1).CellValue = row("CostCenterCode").ToString
          m_grid(currCostCenterIndex, 2).CellValue = row("CostCenterName").ToString
          currentCostCenterCode = row("CostCenterCode").ToString
          m_grid(currCostCenterIndex, 1).Tag = "Font.Bold"
          currDocCodeIndex = -1
        End If

        If row("DocCode").ToString <> currentDocCode Then
          If currDocCodeIndex <> -1 Then
            m_grid(currDocCodeIndex, 10).CellValue = Configuration.FormatToString(CreditAmt, DigitConfig.Price)
            m_grid(currDocCodeIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)
            CreditAmt = 0
            remainningAmount = 0
          End If
          m_grid.RowCount += 1
          currDocCodeIndex = m_grid.RowCount
          m_grid.RowStyles(currDocCodeIndex).BackColor = Color.FromArgb(250, 227, 197)
          m_grid.RowStyles(currDocCodeIndex).Font.Bold = True
          m_grid.RowStyles(currDocCodeIndex).ReadOnly = True
          If Not row.IsNull("DocCode") Then
            m_grid(currDocCodeIndex, 1).CellValue = indent & (row("DocCode")).ToString
          End If
          If Not row.IsNull("DocDate") Then
            m_grid(currDocCodeIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("VatInvoice") Then
            m_grid(currDocCodeIndex, 3).CellValue = indent & (row("VatInvoice")).ToString
          End If
          If Not row.IsNull("SupplierCode") Then
            m_grid(currDocCodeIndex, 4).CellValue = indent & row("SupplierCode").ToString
          End If
          If Not row.IsNull("SupplierName") Then
            m_grid(currDocCodeIndex, 5).CellValue = indent & row("SupplierName").ToString
          End If
          If Not row.IsNull("TaxBase") Then
            m_grid(currDocCodeIndex, 6).CellValue = Configuration.FormatToString(CDec(row("TaxBase")), DigitConfig.Price)
            SumTaxBase += CDec(row("TaxBase"))
          End If
          If Not row.IsNull("TaxRate") Then
            m_grid(currDocCodeIndex, 7).CellValue = Configuration.FormatToString(CDec(row("TaxRate")), DigitConfig.Price)
          End If
          If Not row.IsNull("TaxAmt") Then
            m_grid(currDocCodeIndex, 8).CellValue = Configuration.FormatToString(CDec(row("TaxAmt")), DigitConfig.Price)
            SumTaxAmt += CDec(row("TaxAmt"))
          End If
          If IsNumeric(row("AfterTax")) Then
            m_grid(currDocCodeIndex, 9).CellValue = Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
            remainningAmount = CDec(row("AfterTax"))
            SumTotal += CDec(row("AfterTax"))
          End If
          If Not row.IsNull("status") Then
            If CInt(row("status")) = 0 Then
              m_grid(currDocCodeIndex, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Canceled}")  '"ถูกยกเลิก"
            End If
          End If
          m_grid(currDocCodeIndex, 1).Tag = "Font.Bold"
          currentDocCode = row("DocCode").ToString
          currentRefDocCode = ""
        End If

        If row("CreditAmt").ToString <> currentRefDocCode Then
          If Not row.IsNull("CreditAmt") Then
            remainningAmount -= CDec(row("CreditAmt"))
            SumCredit += CDec(row("CreditAmt"))
            CreditAmt += CDec(row("CreditAmt"))
          End If

          If CInt(Me.Filters(10).Value) = 1 Then
            m_grid.RowCount += 1
            currRefDocIndex = m_grid.RowCount
            m_grid.RowStyles(currRefDocIndex).ReadOnly = True
            If Not row.IsNull("RefDocCode") Then
              m_grid(currRefDocIndex, 1).CellValue = indent & indent & row("RefDocCode").ToString
            End If
            If Not row.IsNull("RefDocDate") Then
              m_grid(currRefDocIndex, 2).CellValue = indent & indent & CDate(row("RefDocDate")).ToShortDateString
            End If
            If Not row.IsNull("RefDocType") Then
              m_grid(currRefDocIndex, 5).CellValue = indent & indent & row("RefDocType").ToString
            End If
            If Not row.IsNull("CreditAmt") Then
              m_grid(currRefDocIndex, 10).CellValue = Configuration.FormatToString(CDec(row("CreditAmt")), DigitConfig.Price)
            End If
            m_grid(currRefDocIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)
          End If
          
          currentRefDocCode = row("RefDocCode").ToString
        End If
      Next

      m_grid(currDocCodeIndex, 10).CellValue = Configuration.FormatToString(CreditAmt, DigitConfig.Price)
      m_grid(currDocCodeIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)

      m_grid.RowCount += 1
      currDocCodeIndex = m_grid.RowCount
      m_grid.RowStyles(currDocCodeIndex).Font.Bold = True
      m_grid.RowStyles(currDocCodeIndex).ReadOnly = True
      m_grid(currDocCodeIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.Total}") '"รวม"
      m_grid(currDocCodeIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(currDocCodeIndex, 6).CellValue = Configuration.FormatToString(SumTaxBase, DigitConfig.Price)
      m_grid(currDocCodeIndex, 8).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price)
      m_grid(currDocCodeIndex, 9).CellValue = Configuration.FormatToString(SumTotal, DigitConfig.Price)
      m_grid(currDocCodeIndex, 10).CellValue = Configuration.FormatToString(SumCredit, DigitConfig.Price)
      m_grid(currDocCodeIndex, 11).CellValue = Configuration.FormatToString(SumTotal - SumCredit, DigitConfig.Price)
      m_grid(currDocCodeIndex, 1).Tag = "Font.Bold"
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPAdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPAdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPAdvancePay"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPAdvancePay.ListLabel}"
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
      Return "RptAPAdvancePay"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAPAdvancePay"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Dim fn1 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim fn2 As Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

      'docdate start
      dpi = New DocPrintingItem
      dpi.Mapping = "docdatestart"
      If Not IsDBNull(Filters(0).Value) Then
        dpi.Value = CDate((Filters(0).Value)).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'docdate end
      dpi = New DocPrintingItem
      dpi.Mapping = "docdateend"
      If Not IsDBNull(Filters(1).Value) Then
        dpi.Value = CDate((Filters(1).Value)).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'supplier start
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierstart"
      If Not IsDBNull(Filters(2).Value) Then
        dpi.Value = CStr((Filters(2).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'supplier end
      dpi = New DocPrintingItem
      dpi.Mapping = "supplierend"
      If Not IsDBNull(Filters(3).Value) Then
        dpi.Value = CStr((Filters(3).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'costcenter start
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterstart"
      If Not IsDBNull(Filters(6).Value) Then
        dpi.Value = CStr((Filters(6).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'costcenter end
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterend"
      If Not IsDBNull(Filters(7).Value) Then
        dpi.Value = CStr((Filters(7).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      Dim SumTaxBase As Decimal = 0
      Dim SumTaxAmt As Decimal = 0
      Dim SumTotal As Decimal = 0
      For rowIndex As Integer = 3 To m_grid.RowCount
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

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 8).CellValue
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
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 9).CellValue
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
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 10).CellValue
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
        dpi.Mapping = "col10"
        dpi.Value = m_grid(rowIndex, 11).CellValue
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
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 12).CellValue
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

        If rowIndex < m_grid.RowCount Then
          If IsNumeric(m_grid(rowIndex, 6).CellValue) Then
            SumTaxBase += CDec(m_grid(rowIndex, 6).CellValue)
          End If
          If IsNumeric(m_grid(rowIndex, 8).CellValue) Then
            SumTaxAmt += CDec(m_grid(rowIndex, 8).CellValue)
          End If
          If IsNumeric(m_grid(rowIndex, 10).CellValue) Then
            SumTotal += CDec(m_grid(rowIndex, 10).CellValue)
          End If
        End If
      Next

      m_grid.RowCount += 1

      m_grid.RowStyles(m_grid.RowCount).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(m_grid.RowCount).Font.Bold = True
      m_grid.RowStyles(m_grid.RowCount).ReadOnly = True

      'SumText
      dpi = New DocPrintingItem
      dpi.Mapping = "SumText"
      dpi.Value = "รวม"
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol5
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol5"
      dpi.Value = Configuration.FormatToString(SumTaxBase, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol7
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol7"
      dpi.Value = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol8
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol8"
      dpi.Value = Configuration.FormatToString(SumTotal, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

