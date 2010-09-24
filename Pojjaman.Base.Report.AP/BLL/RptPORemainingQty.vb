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
  Public Class RptPORemainingQty
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

      Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
      Dim docType As Integer = 6

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 10

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 100
      m_grid.ColWidths(3) = 250
      m_grid.ColWidths(4) = 50
      m_grid.ColWidths(5) = 90
      m_grid.ColWidths(6) = 70
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 80
      m_grid.ColWidths(9) = 80
      m_grid.ColWidths(10) = 120

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.Date}") '"วันที่ใบสั่งซื้อ"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.Code}") '"รหัสใบสั่งซื้อ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.SupplierName}") '"ชื่อผู้ขาย"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.DueDate}") '"วันกำหนดรับของ"
      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.ItemCode}")  '"รหัสสินค้า"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.ItemName}")  '"ชื่อสินค้า"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.Unit}")  '"หน่วยนับ"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.NumOrder}")  '"จำนวนสั่งซื้อ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.Received}")   '"จำนวนรับ"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.Remain}")   '"จำนวนค้างรับ"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.UnitPrice}")   '"ราคาต่อหน่วย"
      m_grid(1, 9).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.PriceRemain}")  '"มูลค่าค้างรับ"
      m_grid(1, 10).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.ReceivingDate}")  '"วันรับของจริง"

      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentPOCode As String = ""
      Dim currentItemCode As String = ""

      Dim currPOIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim sumQty As Decimal = 0
      Dim sumReceive As Decimal = 0
      Dim sumRemain As Decimal = 0
      Dim SumPriceRemain As Decimal = 0

      Dim poQty As Decimal = 0
      Dim poReceive As Decimal = 0
      Dim poRemain As Decimal = 0
      Dim poPriceRemain As Decimal = 0

      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(65)
      Dim CheckString As String = BinaryHelper.DecToBin(level, 5)
      Dim accessPO As Boolean
      CheckString = BinaryHelper.RevertString(CheckString)

      If Not CBool(CheckString.Substring(0, 1)) Then 'กำหนดค่าของรายงาน ว่าถ้า User ที่ดูรายงานไม่มีสิทธิในการดู PO ให้ราคา /หน่วย และมูลค่าค้างรับ =N/A
        accessPO = False
      Else
        accessPO = True
      End If
      For Each row As DataRow In dt.Rows
        If row("Code").ToString <> currentPOCode Then
          If m_grid.RowCount > 0 Then
            m_grid(currPOIndex, 5).CellValue = Configuration.FormatToString(poQty, DigitConfig.Qty)
            m_grid(currPOIndex, 6).CellValue = Configuration.FormatToString(poReceive, DigitConfig.Qty)
            m_grid(currPOIndex, 7).CellValue = Configuration.FormatToString(poRemain, DigitConfig.Qty)
            If accessPO Then
              m_grid(currPOIndex, 9).CellValue = Configuration.FormatToString(poPriceRemain, DigitConfig.Qty)
            Else
              m_grid(currItemIndex, 9).CellValue = "N/A"
            End If
            'If accessPO Then
            '    m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(SumPriceRemain, DigitConfig.Price)
            'Else
            '    m_grid(currItemIndex, 9).CellValue = "N/A"
            'End If
          End If
          poQty = 0
          poReceive = 0
          poRemain = 0
          poPriceRemain = 0

          m_grid.RowCount += 1
          currPOIndex = m_grid.RowCount
          m_grid(currPOIndex, 0).Tag = row
          m_grid.RowStyles(currPOIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currPOIndex).Font.Bold = True
          m_grid.RowStyles(currPOIndex).ReadOnly = True
          If Not row.IsNull("DocDate") Then
            If IsDate(row("DocDate")) Then
              m_grid(currPOIndex, 1).CellValue = CDate(row("DocDate")).ToShortDateString
            End If
          End If
          m_grid(currPOIndex, 2).CellValue = row("Code")
          m_grid(currPOIndex, 3).CellValue = row("SupplierName")
          If Not row.IsNull("DueDate") Then
            If IsDate(row("DueDate")) Then
              m_grid(currPOIndex, 10).CellValue = CDate(row("DueDate")).ToShortDateString

            End If
          End If
          currentPOCode = row("Code").ToString
          currentItemCode = ""
          m_grid(currPOIndex, 1).Tag = "Font.Bold"
        End If
        If row("poi_linenumber").ToString & row("ItemCode").ToString & row("ItemName").ToString <> currentItemCode Then
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not row.IsNull("ItemCode") Then
            m_grid(currItemIndex, 2).CellValue = indent & row("ItemCode").ToString
          End If
          If Not row.IsNull("ItemName") Then
            m_grid(currItemIndex, 3).CellValue = indent & row("ItemName").ToString
          End If
          If Not row.IsNull("UnitName") Then
            m_grid(currItemIndex, 4).CellValue = indent & row("UnitName").ToString
          End If

          If IsNumeric(row("Order")) Then
            m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(row("Order")), DigitConfig.Qty)
            sumQty += CDec(row("Order"))
            poQty += CDec(row("Order"))
          End If

          If IsNumeric(row("Received")) Then
            m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Received")), DigitConfig.Qty)
            sumReceive += CDec(row("Received"))
            poReceive += CDec(row("Received"))
          End If

          If IsNumeric(row("Remain")) Then
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Remain")), DigitConfig.Qty)
            sumRemain += CDec(row("Remain"))
            poRemain += CDec(row("Remain"))
          End If

          If IsNumeric(row("UnitPrice")) Then
            If accessPO Then
              m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("UnitPrice")), DigitConfig.Price)
            Else
              m_grid(currItemIndex, 8).CellValue = "N/A"
            End If
          End If
          If IsNumeric(row("PriceRemain")) Then
            If accessPO Then
              m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(row("PriceRemain")), DigitConfig.Price)
            Else
              m_grid(currItemIndex, 9).CellValue = "N/A"
            End If
            poPriceRemain += CDec(row("PriceRemain"))
            SumPriceRemain += CDec(row("PriceRemain"))
          End If

          If Not row.IsNull("ReceivingDate") Then
            m_grid(currItemIndex, 10).CellValue = indent & (row("ReceivingDate")).ToString
          End If

          currentItemCode = row("poi_linenumber").ToString & row("ItemCode").ToString & row("ItemName").ToString
        End If
      Next
      'PO แถวสุดท้าย
      m_grid(currPOIndex, 5).CellValue = Configuration.FormatToString(poQty, DigitConfig.Qty)
      m_grid(currPOIndex, 6).CellValue = Configuration.FormatToString(poReceive, DigitConfig.Qty)
      m_grid(currPOIndex, 7).CellValue = Configuration.FormatToString(poRemain, DigitConfig.Qty)
      If accessPO Then
        m_grid(currPOIndex, 9).CellValue = Configuration.FormatToString(poPriceRemain, DigitConfig.Price)
      Else
        m_grid(currItemIndex, 9).CellValue = "N/A"
      End If
      'If accessPO Then
      '    m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(poPriceRemain, DigitConfig.Price)
      'Else
      '    m_grid(currItemIndex, 9).CellValue = "N/A"
      'End If

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.Total}") 'รวม
      m_grid(currItemIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(sumQty, DigitConfig.Qty)
      m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(sumReceive, DigitConfig.Qty)
      m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(sumRemain, DigitConfig.Qty)
      If accessPO Then
        m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(SumPriceRemain, DigitConfig.Price)
      Else
        m_grid(currItemIndex, 9).CellValue = "N/A"
      End If

      m_grid(currItemIndex, 1).Tag = "Font.Bold"
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptPORemainingQty"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptPORemainingQty"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptPORemainingQty"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptPORemainingQty.ListLabel}"
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
      Return "RptPORemainingQty"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptPORemainingQty"
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

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

