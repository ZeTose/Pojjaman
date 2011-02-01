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
  Public Class RptMatStockMonitor
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_listhash As Hashtable
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
      Try
        m_grid = grid
        RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
        AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
        m_grid.BeginUpdate()
        m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
        m_grid.Model.Options.NumberedColHeaders = False
        m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
        CreateHeader()
        PopulateData()
      Catch ex As Exception
        Throw ex
      Finally
        m_grid.EndUpdate()
      End Try
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 12

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
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
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.StockId}") '"รหัสวัสดุ"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.StockName}") '"ชื่อสินค้า"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.ReceiveTotal}") '"ยอดรับ"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.PayTotal}") '"ยอดจ่าย"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.DocDate}")  '"วันที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.DocID}")  '"เลขที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Definnition}")  '"คำอธิบาย"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Num}")  '"จำนวน"
      m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Price/Unit}")  '"ราคา/หน่วย"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Cost}")  '"มูลค่า"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Num}")  '"จำนวน"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Price/Unit}")  '"ราคา/หน่วย"
      m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Cost}")  '"มูลค่า"
      m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.StatusTotal}")  '"ยอดคงเหลือ"
      m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Price/Unit}")  '"ราคา/หน่วย"
      m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Cost}")  '"มูลค่า"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim docId As Integer
      Dim docType As Integer

      Dim idValue As KeyValuePair = CType(m_listhash(e.RowIndex), KeyValuePair)

      If idValue Is Nothing Then
        Return
      End If

      docId = CInt(idValue.Key)
      docType = CInt(idValue.Value)

      If docId <= 0 OrElse docType <= 0 Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      myEntityPanelService.OpenDetailPanel(en)
    End Sub
    Private Sub PopulateData()
      Dim lciDt As DataTable = Me.DataSet.Tables(0)
      Dim openDt As DataTable = Me.DataSet.Tables(1)
      Dim dtRaw As DataTable = Me.DataSet.Tables(2)

      m_listhash = New Hashtable

      Dim myStartDate As Date
      Dim myEndDate As Date
      If Not IsDBNull(Me.Filters(0).Value) Then
        myStartDate = CDate(Me.Filters(0).Value)
      End If
      If Not IsDBNull(Me.Filters(1).Value) Then
        myEndDate = CDate(Me.Filters(1).Value)
      End If
      Dim currLciIndex As Integer = -1
      Dim currOpnIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim currItemIndex As Integer = -1
      Dim Sum As Decimal = 0
      Dim DocRows As DataRow()

      For Each lciRow As DataRow In lciDt.Rows
        m_grid.RowCount += 1
        currLciIndex = m_grid.RowCount
        m_grid.RowStyles(currLciIndex).BackColor = Color.FromArgb(128, 255, 128)
        m_grid.RowStyles(currLciIndex).Font.Bold = True
        m_grid.RowStyles(currLciIndex).ReadOnly = True
        m_grid(currLciIndex, 1).CellValue = lciRow("lci_code")
        m_grid(currLciIndex, 2).CellValue = lciRow("lci_name")
        m_grid(currLciIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.NumUnit}") '"หน่วยนับ"
        m_grid(currLciIndex, 9).CellValue = lciRow("unit_name")

        Dim remainQty As Decimal = 0
        Dim remainAmount As Decimal = 0


        Dim opnRows As DataRow() = openDt.Select("stocki_entity=" & CStr(lciRow("lci_id")))
        m_grid.RowCount += 1
        currOpnIndex = m_grid.RowCount
        m_grid.RowStyles(currOpnIndex).ReadOnly = True
        m_grid(currOpnIndex, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.Openingbalance}") '"ยอดยกมา"
        If opnRows.Length > 0 Then
          If IsNumeric(opnRows(0)("qty")) Then
            remainQty = CDec(opnRows(0)("qty"))
          End If
          If IsNumeric(opnRows(0)("amount")) Then
            remainAmount = CDec(opnRows(0)("amount"))
          End If
          m_grid(currOpnIndex, 10).CellValue = Configuration.FormatToString(remainQty, DigitConfig.Qty)
          If (remainQty <> 0 AndAlso remainAmount <> 0) Then
            m_grid(currOpnIndex, 11).CellValue = Configuration.FormatToString(remainAmount / remainQty, DigitConfig.UnitPrice)
          End If
          m_grid(currOpnIndex, 12).CellValue = Configuration.FormatToString(remainAmount, DigitConfig.Price)

        Else
          m_grid(currOpnIndex, 10).CellValue = Configuration.FormatToString(0, DigitConfig.Qty)
          m_grid(currOpnIndex, 11).CellValue = Configuration.FormatToString(0, DigitConfig.UnitPrice)
          m_grid(currOpnIndex, 12).CellValue = Configuration.FormatToString(0, DigitConfig.Price)

        End If

        DocRows = dtRaw.Select("itemid=" & CStr(lciRow("lci_id")))
        For Each ItemRow As DataRow In DocRows
          Dim drh As New DataRowHelper(ItemRow)
          Dim rowMistake As Boolean = drh.GetValue(Of Integer)("Mistake") > 0
          m_grid.RowCount += 1
          currItemIndex = m_grid.RowCount
          '-------------การกำหนดสีต้องเอามาไว้ก่อน
          If IsNumeric(ItemRow("hilight")) Then
            If CInt(ItemRow("hilight")) = 1 Then
              m_grid.RowStyles(currItemIndex).BackColor = Color.OrangeRed
              m_grid.RowStyles(currItemIndex).TextColor = Color.White
            End If
          End If
          '-------------END การกำหนดสีต้องเอามาไว้ก่อน
          '-------------การกำหนดสีต้องเอามาไว้ก่อน
          If IsNumeric(ItemRow("Mistake")) Then
            If rowMistake Then
              m_grid.RowStyles(currItemIndex).BackColor = Color.Purple
              m_grid.RowStyles(currItemIndex).TextColor = Color.White
            End If
          End If
          '-------------END การกำหนดสีต้องเอามาไว้ก่อน
          m_grid.RowStyles(currItemIndex).ReadOnly = True
          If Not ItemRow.IsNull("DocDate") Then
            m_grid(currItemIndex, 1).CellValue = indent & CDate(ItemRow("DocDate")).ToShortDateString
          End If
          If Not ItemRow.IsNull("Code") Then
            m_grid(currItemIndex, 2).CellValue = indent & ItemRow("Code").ToString
          End If
          If Not ItemRow.IsNull("Description") Then
            m_grid(currItemIndex, 3).CellValue = indent & ItemRow("Description").ToString
          End If

          Dim drxh As New DataRowHelper(ItemRow)
          Dim idkey As Integer = drxh.GetValue(Of Integer)("docid")
          Dim typekey As Integer = drxh.GetValue(Of Integer)("doctype")
          If idkey > 0 AndAlso typekey > 0 Then
            Dim idValue As New KeyValuePair(idkey.ToString, typekey.ToString)
            m_listhash(m_grid.RowCount) = idValue
          End If

          Dim currentIn As Decimal = 0
          Dim currentOut As Decimal = 0

          Dim currentInAmount As Decimal = 0
          Dim currentOutAmount As Decimal = 0
          '----> Receipt
          If IsNumeric(ItemRow("receipt")) Then
            m_grid(currItemIndex, 4).CellValue = Configuration.FormatToString(CDec(ItemRow("receipt")), DigitConfig.Qty)
            currentIn = CDec(ItemRow("receipt"))
            If IsNumeric(ItemRow("UnitPrice")) Then
              m_grid(currItemIndex, 5).CellValue = Configuration.FormatToString(CDec(ItemRow("UnitPrice")), DigitConfig.UnitPrice)
            End If
            If IsNumeric(ItemRow("receiptAmount")) Then
              m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(ItemRow("receiptAmount")), DigitConfig.Price)
              currentInAmount = CDec(ItemRow("receiptAmount"))
            End If
            If rowMistake AndAlso drh.GetValue(Of Decimal)("receipt") > 0 Then
              m_grid(currItemIndex, 5).CellValue = "Qty Mistake"
              m_grid(currItemIndex, 6).CellValue = "Qty Mistake"
            End If
          End If
          '----> End Receipt

          '----> Withdraw
          If IsNumeric(ItemRow("Withdraw")) Then
            m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(ItemRow("Withdraw")), DigitConfig.Qty)
            currentOut = CDec(ItemRow("withdraw"))
            If IsNumeric(ItemRow("UnitPrice")) Then
              m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(ItemRow("UnitPrice")), DigitConfig.UnitPrice)
            End If

            If IsNumeric(ItemRow("WithdrawAmount")) Then
              m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(ItemRow("WithdrawAmount")), DigitConfig.Price)
              currentOutAmount = CDec(ItemRow("WithdrawAmount"))
            End If

            If rowMistake AndAlso drh.GetValue(Of Decimal)("Withdraw") > 0 Then
              m_grid(currItemIndex, 8).CellValue = "Qty Mistake"
              m_grid(currItemIndex, 9).CellValue = "Qty Mistake"
            End If

          End If
          '----> End Withdraw

          remainQty += (currentIn - currentOut)

          remainAmount += (currentInAmount - currentOutAmount)

          '----> Balance
          m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(remainQty, DigitConfig.Qty)

          If (remainAmount <> 0 And remainQty <> 0) Then
            m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(remainAmount / remainQty, DigitConfig.UnitPrice)
          Else
            m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(0, DigitConfig.UnitPrice)
          End If
          m_grid(currItemIndex, 12).CellValue = Configuration.FormatToString(remainAmount, DigitConfig.Price)

          '----> End Balance
        Next
        Sum += CDec(remainAmount)
      Next
      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currItemIndex).Font.Bold = True
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.SumAmount}")  '"รวมทั้งหมด"
      m_grid(currItemIndex, 12).CellValue = Configuration.FormatToString(Sum, DigitConfig.Price)

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptMatStockMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatStockMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatStockMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatStockMonitor.ListLabel}"
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
      Return "RptMatStockMonitor"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptMatStockMonitor"
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

