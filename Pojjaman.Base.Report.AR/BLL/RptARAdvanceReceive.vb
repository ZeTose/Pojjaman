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
  Public Class RptARAdvanceReceive
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
      m_grid.ColCount = 12

      m_grid.ColWidths(1) = 150
      m_grid.ColWidths(2) = 150
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 150
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
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
      m_grid(0, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCCode}") '"รหัส Cost Center"
      m_grid(0, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCName}") '"ชื่อ Cost Center"

      m_grid(1, 1).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocCode}")  '"เลขที่เอกสาร"
      m_grid(1, 2).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocDate}")  '"วันที่เอกสาร"
      'm_grid(1, 3).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DueDate}")  '"วันที่ครบกำหนด"
      m_grid(1, 3).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.VatInvoice}")  '"เลขที่ใบกำกับ"
      m_grid(1, 4).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CustID}")  '"รหัสลูกหนี้"
      m_grid(1, 5).CellValue = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CustName}")   '"ชื่อลูกหนี้"
      m_grid(1, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.TaxBase}") '"ฐานภาษี"
      m_grid(1, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.TaxRate}") '"อัตรา"
      m_grid(1, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.TaxAmount}") '"เงินภาษี"
      m_grid(1, 9).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.AfterTax}") '"รวม"
      m_grid(1, 10).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.RefDocAmount}") '"ยอดหักมัดจำ"
      m_grid(1, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Remaining}") '"ยอดคงเหลือ"
      m_grid(1, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Status}") '"สถานะ"

      m_grid(2, 1).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocCode}")  '"เลขที่เอกสาร"
      m_grid(2, 2).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocDate}")  '"วันที่เอกสาร"
      m_grid(2, 5).CellValue = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocType}")  '"ประเภทเอกสาร"
      m_grid(2, 10).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.AdvanceAmount}") '"หักมัดจำ"
      m_grid(2, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Remain}") '"คงเหลือ"

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
      m_grid(2, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    End Sub
    Private Sub PopulateData()

      Dim dt As DataTable = Me.DataSet.Tables(0)

      Dim currentCostCenterCode As String = ""
      Dim currentDocCode As String = ""

      'Dim currentVatInvoice As String = ""

      'Dim costcenterTr As TreeRow
      'Dim doccodeTr As TreeRow
      'Dim vatdocTr As TreeRow
      Dim indent As String = Space(3)

      'Dim tmpAmount As Decimal = 0
      Dim currCostCenterIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currDetailIndex As Integer = -1

      Dim sumTaxBase As Decimal = 0
      Dim sumTaxAmt As Decimal = 0
      Dim sumAfterTax As Decimal = 0
      Dim sumAdvance As Decimal = 0
      Dim sumRemain As Decimal = 0

      Dim sumAdvancedAmount As Decimal = 0
      Dim remainningAmount As Decimal = 0


      For Each row As DataRow In dt.Rows
        If row("CostCenterCode").ToString <> currentCostCenterCode Then
          If currDocIndex <> -1 Then
            m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(sumAdvancedAmount, DigitConfig.Price)
            m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)
            sumAdvancedAmount = 0
            remainningAmount = 0
            currDocIndex = -1
          End If

          m_grid.RowCount += 1
          currCostCenterIndex = m_grid.RowCount
          m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
          m_grid.RowStyles(currCostCenterIndex).ReadOnly = True

          m_grid(currCostCenterIndex, 1).CellValue = row("CostCenterCode").ToString
          m_grid(currCostCenterIndex, 2).CellValue = row("CostCenterName").ToString
          currentCostCenterCode = row("CostCenterCode").ToString
          currentDocCode = ""
          m_grid(currCostCenterIndex, 1).Tag = "Font.Bold"

        End If

        If row("CostCenterCode").ToString & row("DocCode").ToString <> currentDocCode Then
          If currDocIndex <> -1 Then
            m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(sumAdvancedAmount, DigitConfig.Price)
            m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)
            sumAdvancedAmount = 0
            remainningAmount = 0
          End If

          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).BackColor = Color.AntiqueWhite
          m_grid.RowStyles(currDocIndex).Font.Bold = True
          m_grid.RowStyles(currDocIndex).ReadOnly = True

          If Not row.IsNull("DocCode") Then
            m_grid(currDocIndex, 1).CellValue = indent & (row("DocCode")).ToString
          End If
          If Not row.IsNull("DocDate") Then
            m_grid(currDocIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("VatInvoice") Then
            m_grid(currDocIndex, 3).CellValue = indent & row("VatInvoice").ToString
          End If
          If Not row.IsNull("CustomerCode") Then
            m_grid(currDocIndex, 4).CellValue = indent & row("CustomerCode").ToString
          End If
          If Not row.IsNull("CustomerName") Then
            m_grid(currDocIndex, 5).CellValue = indent & row("CustomerName").ToString
          End If
          If Not row.IsNull("TaxBase") Then
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("TaxBase")), DigitConfig.Price)
            sumTaxBase += CDec(row("TaxBase"))
          End If
          If Not row.IsNull("TaxRate") Then
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("TaxRate")), DigitConfig.Price)
          End If
          If Not row.IsNull("TaxAmt") Then
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("TaxAmt")), DigitConfig.Price)
            sumTaxAmt += CDec(row("TaxAmt"))
          End If
          If IsNumeric(row("AfterTax")) Then
            m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
            remainningAmount = CDec(row("AfterTax"))
            sumAfterTax += CDec(row("AfterTax"))
          End If
          If Not row.IsNull("status") Then
            If CInt(row("status")) = 0 Then
              m_grid(currDocIndex, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Canceled}")  '"ถูกยกเลิก"
            End If
          End If

          currentDocCode = row("CostCenterCode").ToString & row("DocCode").ToString
          'currentVatInvoice = ""
          m_grid(currDocIndex, 1).Tag = "Font.Bold"
          'tmpAmount = 0
        End If

        If Not row.IsNull("advri_amt") Then
          remainningAmount -= CDec(row("advri_amt"))
          sumAdvancedAmount += CDec(row("advri_amt"))
          sumAdvance += CDec(row("advri_amt"))
        End If

        If CInt(Me.Filters(8).Value) = 1 Then
          m_grid.RowCount += 1
          currDetailIndex = m_grid.RowCount
          m_grid.RowStyles(currDetailIndex).ReadOnly = True
          If Not row.IsNull("advri_refdoccode") Then
            m_grid(currDetailIndex, 1).CellValue = indent & indent & row("advri_refdoccode").ToString
          End If
          If Not row.IsNull("advri_refdocdate") Then
            If IsDate(row("advri_refdocdate")) Then
              m_grid(currDetailIndex, 2).CellValue = indent & indent & CDate(row("advri_refdocdate")).ToShortDateString
            End If
          End If
          If Not row.IsNull("doctype") Then
            m_grid(currDetailIndex, 5).CellValue = indent & indent & row("doctype").ToString
          End If
          If Not row.IsNull("advri_amt") Then
            m_grid(currDetailIndex, 10).CellValue = Configuration.FormatToString(CDec(row("advri_amt")), DigitConfig.Price)
          End If

          m_grid(currDetailIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)
        End If

      Next

      m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(sumAdvancedAmount, DigitConfig.Price)
      m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(remainningAmount, DigitConfig.Price)

      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).Font.Bold = True
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.AfterTax}")
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(sumTaxBase, DigitConfig.Price)
      m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(sumTaxAmt, DigitConfig.Price)
      m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(sumAfterTax, DigitConfig.Price)
      m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(sumAdvance, DigitConfig.Price)
      m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(sumAfterTax - sumAdvance, DigitConfig.Price)
      m_grid(currDocIndex, 1).Tag = "Font.Bold"

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptARAdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptARAdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptARAdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.ListLabel}"
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
      Return "RptARAdvanceReceive"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptARAdvanceReceive"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

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

      'customer start
      dpi = New DocPrintingItem
      dpi.Mapping = "customerstart"
      If Not IsDBNull(Filters(2).Value) Then
        dpi.Value = CStr((Filters(2).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'customer end
      dpi = New DocPrintingItem
      dpi.Mapping = "customerend"
      If Not IsDBNull(Filters(3).Value) Then
        dpi.Value = CStr((Filters(3).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterstart"
      If Not IsDBNull(Filters(7).Value) Then
        dpi.Value = CStr((Filters(7).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterend"
      If Not IsDBNull(Filters(8).Value) Then
        dpi.Value = CStr((Filters(8).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'IncludeChildren
      dpi = New DocPrintingItem
      dpi.Mapping = "IncludeChildren"
      If Not IsDBNull(Filters(5).Value) Then
        If CType(Filters(5).Value, Boolean) Then
          dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARFilterSubPanel.chkIncludeChildren}")
        End If
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      Dim i As Integer = 0
      Dim fn As Font
      For rowIndex As Integer = 3 To m_grid.RowCount
        If m_grid(rowIndex, 1).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If

        For colIndex As Integer = 0 To m_grid.ColCount - 1
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & colIndex.ToString
          dpi.Value = m_grid(rowIndex, colIndex + 1).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpi.Font = fn
          dpiColl.Add(dpi)
        Next

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col0"
        'dpi.Value = m_grid(rowIndex, 1).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col1"
        'dpi.Value = m_grid(rowIndex, 2).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col2"
        'dpi.Value = m_grid(rowIndex, 3).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col3"
        'dpi.Value = m_grid(rowIndex, 4).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col4"
        'dpi.Value = m_grid(rowIndex, 5).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col5"
        'dpi.Value = m_grid(rowIndex, 6).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col6"
        'dpi.Value = m_grid(rowIndex, 7).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col7"
        'dpi.Value = m_grid(rowIndex, 8).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col8"
        'dpi.Value = m_grid(rowIndex, 9).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpi.Font = fn
        'dpiColl.Add(dpi)

        n += 1
      Next     

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

