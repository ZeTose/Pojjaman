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
  Public Class RptChangingUnitPrice
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
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
      m_grid.RowCount = 1
      m_grid.ColCount = 12

      m_grid.ColWidths(1) = 150
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 120
      m_grid.ColWidths(7) = 120
      m_grid.ColWidths(8) = 120
      m_grid.ColWidths(9) = 150
      m_grid.ColWidths(10) = 120
      m_grid.ColWidths(11) = 120
      m_grid.ColWidths(12) = 120

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

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.DocCode}") '"รหัสใบรับของ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.DocDate}") '"วันที่รับของ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.CC}") '"โครงการ(CostCenter)"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.SupplierName}") '"ผู้ขาย"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.Quantities}") '"ปริมาณ(Quantities)"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.UnitPrice}") '"ราคาต่อหน่วย(UnitPrice)"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.ItemID}") '"รหัสสินค้า"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.ItemName}") '"ชื่อสินค้า"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.Unit}") '"หน่วย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.PONum}") '"จำนวนสั่งซื้อ(PO)"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.ReciveNum}") '"จำนวนรับ(รับของ)"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.Diff}") '"ผลต่าง"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.POUnitPrice}") '"ราคา/หน่วย(PO)"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.ReciveUnitPrice}") '"ราคา/หน่วย(รับของ)"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.PriceDiff}") '"ผลต่างราคาต่อหน่วย"
      m_grid(1, 12).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.POReference}") '"อ้างอิงจาก PO"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentDocCode As String = ""
      Dim currentItemCode As String = ""

      Dim currDocIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)

      m_hashData = New Hashtable
      Dim dc0 As New DataColumn("id")
      dt.Columns.Add(dc0)
      Dim dc1 As New DataColumn("docType")
      dt.Columns.Add(dc1)

      For Each row As DataRow In dt.Rows
        If row("DocCode").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount

          Dim IDandType As New KeyValuePair(45, CInt(row("stock_id")))
          m_hashData(currDocIndex) = IDandType

          m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currDocIndex).Font.Bold = True
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          m_grid(currDocIndex, 1).CellValue = row("DocCode")
          m_grid(currDocIndex, 2).CellValue = CDate(row("ReceivingDate")).ToShortDateString
          m_grid(currDocIndex, 3).CellValue = row("CostCenterName")
          m_grid(currDocIndex, 4).CellValue = row("SupplierName")
          currentDocCode = row("DocCode").ToString
          currentItemCode = ""
        End If
        If row("ItemCode").ToString <> currentItemCode Then
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount

          Dim IDandType As New KeyValuePair(6, CInt(row("DocId")))
          m_hashData(currItemIndex) = IDandType

          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not row.IsNull("ItemCode") Then
            m_grid(currItemIndex, 1).CellValue = indent & row("ItemCode").ToString
          End If
          If Not row.IsNull("ItemName") Then
            m_grid(currItemIndex, 3).CellValue = indent & row("ItemName").ToString
          End If
          If Not row.IsNull("UnitName") Then
            m_grid(currItemIndex, 5).CellValue = indent & row("UnitName").ToString
          End If
          If IsNumeric(row("Qty")) Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
          End If
          If IsNumeric(row("ReceivedQty")) Then
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("ReceivedQty")), DigitConfig.Qty)
          End If
          If IsNumeric(row("QtyDiff")) Then
            m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("QtyDiff")), DigitConfig.Qty)
          End If
          If IsNumeric(row("OrderUnitPrice")) Then
            m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(row("OrderUnitPrice")), DigitConfig.Price)
          End If
          If IsNumeric(row("ReceivingUnitPrice")) Then
            m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(CDec(row("ReceivingUnitPrice")), DigitConfig.Price)
          End If
          If IsNumeric(row("UnitPriceDiff")) Then
            m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(CDec(row("UnitPriceDiff")), DigitConfig.Price)
          End If
          If Not row.IsNull("RefDocCode") Then
            m_grid(currItemIndex, 12).CellValue = indent & row("RefDocCode").ToString
          End If
          currentItemCode = row("ItemCode").ToString
        End If
      Next
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptChangingUnitPrice"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptChangingUnitPrice"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptChangingUnitPrice"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptChangingUnitPrice.ListLabel}"
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
      Return "RptChangingUnitPrice"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptChangingUnitPrice"
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

        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 12).CellValue
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

