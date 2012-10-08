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
Imports Syncfusion.Windows.Forms.Grid

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptIncomingWhtPND
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

      Dim docId As Integer = drh.GetValue(Of Integer)("docId")
      Dim docType As Integer = drh.GetValue(Of Integer)("docType")

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 0
      m_grid.ColCount = 12

      m_grid.ColWidths(1) = 50
      m_grid.ColWidths(2) = 150
      m_grid.ColWidths(3) = 250
      m_grid.ColWidths(4) = 120
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 120
      m_grid.ColWidths(7) = 80
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 50
      m_grid.ColWidths(11) = 90
      m_grid.ColWidths(12) = 90

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 0
      m_grid.Rows.FrozenCount = 0

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.No}") '"ลำดับที่"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.SupplierName}") '"ชื่อผู้มีเงินได้"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.SupplierAddress}") '"ที่อยู่"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.SupplierTaxId}") '"เลขประจำตัวผู้เสียภาษี"
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.PayDate}") '"วันที่จ่าย"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.Description}") '"รายการ"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.TaxRate}") '"อัตราภาษี"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.BeforeTax}") '"จำนวนเงิน"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.WHTAmt}") '"หัก ณ ที่จ่าย"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.WHTPaymentType}") '"เงื่อนไข"
      m_grid(0, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.SubmitNo}") '"ยื่นเพิ่มเติมครั้งที่"
      m_grid(0, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.ExportNo}") '"Export ครั้งที่"

      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim SumAmount As Decimal = 0
      Dim SumWHT As Decimal = 0
      Dim i As Integer = 0

      Dim currDocIndex As Integer
      For Each row As DataRow In dt.Rows
        i += 1
        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        m_grid(currDocIndex, 0).Tag = row
        m_grid.RowStyles(currDocIndex).ReadOnly = True
        m_grid(currDocIndex, 1).CellValue = i.ToString
        If Not row.IsNull("printname") Then
          m_grid(currDocIndex, 2).CellValue = row("printname").ToString
        End If
        If Not row.IsNull("printaddress") Then
          m_grid(currDocIndex, 3).CellValue = row("printaddress").ToString
        End If
        If Not row.IsNull("printtaxid") Then
          m_grid(currDocIndex, 4).CellValue = row("printtaxid").ToString
        End If
        If IsDate(row("DocDate")) Then
          m_grid(currDocIndex, 5).CellValue = CDate(row("DocDate")).ToShortDateString
        End If
        If Not row.IsNull("Description") Then
          m_grid(currDocIndex, 6).CellValue = row("Description").ToString
        End If
        If IsNumeric(row("TaxRate")) Then
          m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("TaxRate")), DigitConfig.Price)
        End If
        If IsNumeric(row("BeforeTax")) Then
          m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("BeforeTax")), DigitConfig.Price)
          SumAmount += CDec(row("BeforeTax"))
        End If
        If IsNumeric(row("WHTAmt")) Then
          m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(CDec(row("WHTAmt")), DigitConfig.Price)
          SumWHT += CDec(row("WHTAmt"))
        End If
        If Not row.IsNull("whtpaymenttype") Then
          m_grid(currDocIndex, 10).CellValue = row("whtpaymenttype").ToString
        End If
        If IsNumeric(row("wht_submitno")) Then
          m_grid(currDocIndex, 11).CellValue = Configuration.FormatToString(CDec(row("wht_submitno")), DigitConfig.Int)
        End If
        If IsNumeric(row("wht_exportno")) Then
          m_grid(currDocIndex, 12).CellValue = Configuration.FormatToString(CDec(row("wht_exportno")), DigitConfig.Int)
        End If
      Next

      m_grid.RowCount += 1
      currDocIndex = m_grid.RowCount
      m_grid.RowStyles(currDocIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currDocIndex).Font.Bold = True
      m_grid.RowStyles(currDocIndex).ReadOnly = True
      m_grid(currDocIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.SumAll}") '"รวมทั้งหมด"
      m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(SumAmount, DigitConfig.Price)
      m_grid(currDocIndex, 9).CellValue = Configuration.FormatToString(SumWHT, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptIncomingWhtPND"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptIncomingWhtPND"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptIncomingWhtPND"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptIncomingWhtPND.ListLabel}"
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
#End Region
#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
    End Function
    Public Overrides Function GetDefaultForm() As String

    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0

      Dim SplitAddress As Boolean = True
      Dim SumAmt As Decimal = 0
      Dim SumWHT As Decimal = 0
      For rowIndex As Integer = 1 To m_grid.RowCount
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 1).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        If SplitAddress AndAlso Not IsDBNull(m_grid(rowIndex, 3).CellValue) AndAlso m_grid(rowIndex, 3).Text.Trim.Length > 30 Then
          Dim myAddress As String = CStr(m_grid(rowIndex, 3).Text.Replace(vbCrLf, " "))
          Dim myHalfPosition = myAddress.Length \ 2
          Dim DecisioningRange As String = myAddress.Substring(myHalfPosition - 6, 12)
          Dim SplitPositionIndecisioningRange As Integer = DecisioningRange.IndexOf(" ")
          If SplitPositionIndecisioningRange < 0 Then
            SplitPositionIndecisioningRange = DecisioningRange.IndexOf(Chr(160))  'space คนละ code กับข้างบน
          End If
          SplitPositionIndecisioningRange += 1
          Dim SplitPosition As Integer = myHalfPosition - 6 + SplitPositionIndecisioningRange
          dpi.Value = m_grid(rowIndex, 2).Text & vbCrLf
          dpi.Value &= myAddress.Substring(0, SplitPosition) & vbCrLf & myAddress.Substring(SplitPosition, myAddress.Length - SplitPosition)
        Else
          dpi.Value = m_grid(rowIndex, 2).CellValue & vbCrLf & m_grid(rowIndex, 3).CellValue & vbCrLf & "-"
        End If
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
        n += 1
        If IsNumeric(m_grid(rowIndex, 8).CellValue) Then
          SumAmt += CDec(m_grid(rowIndex, 8).CellValue)
        End If
        If IsNumeric(m_grid(rowIndex, 9).CellValue) Then
          SumWHT += CDec(m_grid(rowIndex, 9).CellValue)
        End If
      Next

      'SumText
      dpi = New DocPrintingItem
      dpi.Mapping = "SumText"
      dpi.Value = "รวม"
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol7
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol7"
      dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol9
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol8"
      dpi.Value = Configuration.FormatToString(SumWHT, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)
      Return dpiColl
    End Function

    'Public Overrides Function GetPrintDocumentFromGrid() As Syncfusion.Windows.Forms.Grid.GridPrintDocument
    '  Dim pd As New GridPrintDocument(m_grid, True)
    '  Return pd
    'End Function

#End Region

  End Class
End Namespace

