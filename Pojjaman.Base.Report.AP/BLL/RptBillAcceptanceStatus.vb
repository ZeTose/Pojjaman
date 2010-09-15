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
  Public Class RptBillAcceptanceStatus
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
      m_grid.HorizontalThumbTrack = True
      m_grid.VerticalThumbTrack = True
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim dr As DataRow = Me.m_grid(e.RowIndex, 0).Tag
      If dr Is Nothing Then
        Return
      End If
      Dim drh As New DataRowHelper(dr)
      Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
      Dim docType As Integer = 60

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 6

      m_grid.ColWidths(1) = 120
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 120
      m_grid.ColWidths(4) = 100
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.SupplierID}")  '"รหัสผู้ขาย"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.SupplierName}")   '"ชื่อผู้ขาย"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.BillAcceptanceID}")   '"รหัสใบรับวางบิล"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.BillAcceptanceDate}")   '"วันที่ใบรับวางบิล"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.BillAcceptanceDueDate}")   '"วันที่กำหนดจ่าย"
      m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.BillAcceptanceCost}")   '"มูลค่าใบวางบิล"
      m_grid(1, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.Cost}")   '"มูลค่าชำระ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.RemainingCost}")   '"มูลค่าค้างชำระ"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentSupplierCode As String = ""
      Dim currentDocCode As String = ""

      Dim indent As String = Space(3)
      Dim tmpItem As Int32 = 0
      Dim SumItem As Int32 = 0
      Dim SumSupplier As Int32 = 0
      Dim SumAmount As Decimal = 0
      Dim tmpAmount As Decimal = 0
      Dim SumPaid As Decimal = 0
      Dim tmpPaid As Decimal = 0
      Dim SumRemain As Decimal = 0
      Dim tmpRemain As Decimal = 0
      Dim currDocIndex As Integer = -1
      Dim currSupplierIndex As Integer = -1

      For Each row As DataRow In dt.Rows
        If row("SupplierCode").ToString & row("SupplierName").ToString <> currentSupplierCode Then
          SumSupplier += 1

          If currentSupplierCode <> "" Then
            m_grid.RowCount += 1
            currDocIndex = m_grid.RowCount
            m_grid.RowStyles(currDocIndex).ReadOnly = True
            m_grid(currDocIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.Total}") & tmpItem & _
                            Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.List}")             '"รวม","รายการ"
            m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
            m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(tmpPaid, DigitConfig.Price)
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
            tmpItem = 0
            tmpAmount = 0
            tmpPaid = 0
            tmpRemain = 0
          End If

          m_grid.RowCount += 1
          currSupplierIndex = m_grid.RowCount
          m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currSupplierIndex).Font.Bold = True
          m_grid.RowStyles(currSupplierIndex).ReadOnly = True
          m_grid(currSupplierIndex, 1).CellValue = row("SupplierCode")
          m_grid(currSupplierIndex, 2).CellValue = row("SupplierName")
          currentSupplierCode = row("SupplierCode").ToString & row("SupplierName").ToString
        End If

        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        m_grid.RowStyles(currDocIndex).ReadOnly = True
        m_grid(currDocIndex, 0).Tag = row
        If Not row.IsNull("DocCode") Then
          m_grid(currDocIndex, 1).CellValue = indent & row("DocCode").ToString
        End If
        If IsDate(row("DocDate")) Then
          m_grid(currDocIndex, 2).CellValue = indent & CDate(row("DocDate")).ToShortDateString
        End If
        If IsDate(row("DueDate")) Then
          m_grid(currDocIndex, 3).CellValue = indent & CDate(row("DueDate")).ToShortDateString
        End If
        If IsNumeric(row("Amount")) Then
          m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
          tmpAmount += CDec(row("Amount"))
          SumAmount += CDec(row("Amount"))
        End If
        If IsNumeric(row("Paid")) Then
          m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(CDec(row("Paid")), DigitConfig.Price)
          tmpPaid += CDec(row("Paid"))
          SumPaid += CDec(row("Paid"))
        End If
        If IsNumeric(row("Remain")) Then
          m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Remain")), DigitConfig.Price)
          tmpRemain += CDec(row("Remain"))
          SumRemain += CDec(row("Remain"))
        End If
        tmpItem += 1
        SumItem += 1
        currentDocCode = row("DocCode").ToString

      Next

      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.Total}") & tmpItem & _
                      Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.List}")             '"รวม","รายการ"
      m_grid(currDocIndex, 4).CellValue = Configuration.FormatToString(tmpAmount, DigitConfig.Price)
      m_grid(currDocIndex, 5).CellValue = Configuration.FormatToString(tmpPaid, DigitConfig.Price)
      m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)

      m_grid.RowCount += 1
      currSupplierIndex = m_grid.RowCount
      m_grid.RowStyles(currSupplierIndex).ReadOnly = True
      m_grid(currSupplierIndex, 1).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.TotalSupplier}") & indent & SumSupplier  '"รวมจำนวนผู้ขายทั้งหมด"
      m_grid(currSupplierIndex, 2).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.TotalList}") & indent & SumItem   '"รวมรายการทั้งหมด"
      m_grid(currSupplierIndex, 4).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
      m_grid(currSupplierIndex, 5).CellValue = Configuration.FormatToString(SumPaid, DigitConfig.Price)
      m_grid(currSupplierIndex, 6).CellValue = Configuration.FormatToString(SumRemain, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptBillAcceptanceStatus"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptBillAcceptanceStatus"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptBillAcceptanceStatus"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptBillAcceptanceStatus.ListLabel}"
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
      Return "RptBillAcceptanceStatus"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptBillAcceptanceStatus"
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
        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

