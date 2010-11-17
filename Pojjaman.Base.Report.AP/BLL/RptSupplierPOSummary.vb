Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptSupplierPOSummary
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private MasterTotal As Decimal = 0
    Private m_hashData As Hashtable
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
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      m_grid.BeginUpdate()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      m_grid.Model.Options.NumberedColHeaders = False
      m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim tr As Object = m_hashData(e.RowIndex)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is KeyValuePair Then
        Dim IDandType As KeyValuePair = CType(tr, KeyValuePair)
        If IDandType Is Nothing Then
          Return
        End If

        Dim docId As Integer = 0
        Dim docType As Integer = 0

        docId = IDandType.Value
        docType = IDandType.Key

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
        End If
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 2
      m_grid.ColCount = 11

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 250
      m_grid.ColWidths(3) = 150
      m_grid.ColWidths(4) = 150
      m_grid.ColWidths(5) = 120
      m_grid.ColWidths(6) = 120
      m_grid.ColWidths(7) = 120
      m_grid.ColWidths(8) = 120
      m_grid.ColWidths(9) = 120
      m_grid.ColWidths(10) = 120
      'm_grid.ColWidths(11) = 0

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 2
      m_grid.Rows.FrozenCount = 2

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.SupplierCode}") '"รหัสผู้ขาย"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.SupplierName}") '"ชื่อผู้ขาย"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.PoID}")  '"เลขที่ PO"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.DocDate}")  '"วันที่สั่งซื้อ"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.EmployeeName}")  '"ผู้สั่งซื้อ"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.CostCenter}")  '"Cost Center"
      m_grid(1, 8).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.DiscountAmount}")  '"ส่วนลด"
      m_grid(1, 9).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.BeforeTax}")  '"ก่อนคิดภาษี"
      m_grid(1, 10).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.TaxAmt}")  '"มูลค่าภาษี"
      m_grid(1, 11).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.AfterTax}")  '"หลังคิดภาษี"

      'm_grid(1, 11).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.Total}")  '"รวมมูลค่าใบสั่งซื้อ"

      m_grid(2, 1).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.PrID}") '"เลขที่ PR"
      m_grid(2, 2).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.Description}") '"รายละเอียด"
      m_grid(2, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.Qty}") '"จำนวน"
      m_grid(2, 4).Text = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.UnitName}") '"หน่วย"
      m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.UnitPrice}") '"ราคาต่อหน่วย"
      m_grid(2, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.DisCItem}") '"ส่วนลดรายการ"
      m_grid(2, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.Cost}") '"จำนวนเงิน"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      'm_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(2, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(2, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right


    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)

      Dim currentSupplierId As String = ""
      Dim currentDocId As String = ""
      Dim currentItem As String = ""

      Dim currSupplierIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim tmpTaxAmount As Decimal = 0
      Dim tmpDiscAmount As Decimal = 0
      Dim tmpAfterTax As Decimal = 0
      Dim tmpSummaryPOGross As Decimal = 0

      m_hashData = New Hashtable
      Dim dc0 As New DataColumn("id")
      dt.Columns.Add(dc0)
      Dim dc1 As New DataColumn("docType")
      dt.Columns.Add(dc1)

      For Each row As DataRow In dt.Rows
        If row("SupplierId").ToString <> currentSupplierId Then
          If currentSupplierId <> "" Then
            If tmpDiscAmount > 0 Then
              m_grid.RowCount += 1
              currItemIndex = m_grid.RowCount
              m_grid.RowStyles(currItemIndex).ReadOnly = True
              m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.DiscAmt}") '"ค่าส่วนลด"
              m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpDiscAmount, DigitConfig.Price)
            End If
            If tmpTaxAmount > 0 Then
              m_grid.RowCount += 1
              currItemIndex = m_grid.RowCount
              m_grid.RowStyles(currItemIndex).ReadOnly = True
              m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.TaxAmount}") '"ค่าภาษีมูลค่าเพิ่ม"
              m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(tmpTaxAmount), DigitConfig.Price)
            End If
            m_grid.RowCount += 1
            currItemIndex = m_grid.RowCount
            m_grid.RowStyles(currItemIndex).ReadOnly = True
            m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.Amount}") '"รวมเป็นเงิน"
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpAfterTax, DigitConfig.Price)
          End If
          m_grid.RowCount += 1
          currSupplierIndex = m_grid.RowCount
          m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currSupplierIndex).Font.Bold = True
          m_grid.RowStyles(currSupplierIndex).ReadOnly = True
          m_grid(currSupplierIndex, 1).Tag = "Font.Bold"
          m_grid(currSupplierIndex, 1).CellValue = row("SupplierCode")
          m_grid(currSupplierIndex, 2).CellValue = row("SupplierName")
          currentSupplierId = row("SupplierId").ToString
          currentDocId = ""

          'Clear for new Supplier
          tmpDiscAmount = 0
          tmpTaxAmount = 0
          tmpAfterTax = 0
        End If
        If row("DocId").ToString <> currentDocId Then
          tmpSummaryPOGross = 0
          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          Dim IDandType As New KeyValuePair(6, CInt(row("DocId")))
          m_hashData(currDocIndex) = IDandType


          m_grid.RowStyles(currDocIndex).BackColor = Color.AntiqueWhite
          m_grid.RowStyles(currDocIndex).Font.Bold = True
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          m_grid(currDocIndex, 1).Tag = "Font.Bold"

          If Not row.IsNull("DocCode") Then
            m_grid(currDocIndex, 1).CellValue = indent & row("DocCode").ToString
          End If
          If IsDate(row("DocDate")) Then
            m_grid(currDocIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("EmployeeName") Then
            m_grid(currDocIndex, 3).CellValue = indent & row("EmployeeName").ToString
            m_grid(currDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
          End If
          If Not row.IsNull("CCName") Then
            m_grid(currDocIndex, 4).CellValue = indent & row("CCName").ToString
          End If
          If Not row.IsNull("DiscountAmount") Then
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("DiscountAmount")), DigitConfig.Price)
            tmpSummaryPOGross = tmpSummaryPOGross - CDec(row("DiscountAmount"))
            'tmpDiscAmount += CDec(row("DiscountAmount"))
          End If
          If Not row.IsNull("BeforeTax") Then
            m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(CDec(row("BeforeTax")), DigitConfig.Price)
          End If
          If Not row.IsNull("TaxAmount") Then
            m_grid(currDocIndex, 10).CellValue = Configuration.FormatToString(CDec(row("TaxAmount")), DigitConfig.Price)
          End If
          If Not row.IsNull("AfterTax") Then
            m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(CDec(row("AfterTax")), DigitConfig.Price)
            tmpSummaryPOGross = CDec(row("AfterTax"))
          End If
          'If Not row.IsNull("CCName") Then
          'm_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(tmpSummaryPOGross, DigitConfig.Price)
          'End If

          If IsNumeric(row("AfterTax")) Then
            tmpAfterTax += CDec(row("AfterTax"))
          End If


          If row("TaxType") = 1 And IsNumeric(row("TaxAmount")) Then
            tmpTaxAmount += CDec(row("TaxAmount"))
          End If

          If IsNumeric(row("DiscountAmount")) Then
            'm_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("DiscAmt")), DigitConfig.Price)
            tmpDiscAmount += CDec(row("DiscountAmount"))
          End If

          currentDocId = row("DocId").ToString
          currentItem = ""
        End If
        If row("ItemId").ToString & row("ItemName").ToString <> currentItem Then
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          Dim refId As Integer = 0
          If Not row.IsNull("RefId") Then
            refId = CInt(row("RefId"))
          End If
          Dim IDandType As New KeyValuePair(7, refId)
          m_hashData(currItemIndex) = IDandType
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not row.IsNull("RefCode") Then
            m_grid(currItemIndex, 1).CellValue = indent & indent & row("RefCode").ToString
          End If
          If Not row.IsNull("ItemName") Then
            m_grid(currItemIndex, 2).CellValue = indent & indent & row("ItemName").ToString
          End If
          If IsNumeric(row("Qty")) Then
            m_grid(currItemIndex, 3).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
          End If
          If Not row.IsNull("UnitName") Then
            m_grid(currItemIndex, 4).CellValue = indent & indent & row("UnitName").ToString
          End If
          If IsNumeric(row("UnitPrice")) Then
            m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
          End If
          If IsNumeric(row("DiscAmt")) Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("DiscAmt")), DigitConfig.Price)
            m_grid(currItemIndex, 6).Tag = Configuration.FormatToString(CDec(row("PercentDiscount")), DigitConfig.Price) & " %"
            'tmpDiscAmount += CDec(row("DiscountAmount"))
          End If
          If IsNumeric(row("Amount")) Then
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
          End If
          currentItem = row("ItemId").ToString & row("ItemName").ToString
        End If
      Next

      If tmpDiscAmount > 0 Then
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.DiscAmt}") '"ค่าส่วนลด"
        m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpDiscAmount, DigitConfig.Price)
      End If
      If tmpTaxAmount > 0 Then
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True
        m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.TaxAmount}") '"ค่าภาษีมูลค่าเพิ่ม"
        m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpTaxAmount, DigitConfig.Price)
      End If

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.Amount}") '"รวมเป็นเงิน"
      m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(tmpAfterTax, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptSupplierPOSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptSupplierPOSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptSupplierPOSummary"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSupplierPOSummary.ListLabel}"
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
      Return "RptSupplierPOSummary"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptSupplierPOSummary"
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
      Dim i As Integer = 0
      For rowIndex As Integer = 3 To m_grid.RowCount
        i += 1
        dpi = New DocPrintingItem
        dpi.Mapping = "LineNumber"
        dpi.Value = i
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
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        If Not m_grid(rowIndex, 1).Tag Is Nothing Then
          dpi.Font = fn1
        Else
          dpi.Font = fn2
        End If
        dpi.Table = "Item"

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
        dpi.Value = CStr(m_grid(rowIndex, 6).Tag)
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

