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
  Public Class RptAPRemainDetail
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
      Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("stock_id")
      Dim docType As Integer = drh.GetValue(Of Integer)("stock_type")

      Trace.WriteLine(docId.ToString & ":" & docType.ToString)

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
      m_grid.ColWidths(2) = 200
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 120
      m_grid.ColWidths(5) = 120
      m_grid.ColWidths(6) = 120
      m_grid.ColWidths(7) = 120
      m_grid.ColWidths(8) = 120
      m_grid.ColWidths(9) = 60
      m_grid.ColWidths(10) = 180

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      Dim indent As String = Space(3)
      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.ApID}")          '"รหัสเจ้าหนี้"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.ApName}")        '"ชื่อเจ้าหนี้"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.LimitPaymentDate}")    '"วันที่ครบกำหนดชำระ"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.DocID}")        '"เลขที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.DocDate}")      '"วันที่เอกสาร"
      m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.DocType}")      '"ประเภทเอกสาร"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.DocNumber}")    '"เลขที่ใบกำกับ"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.DocAmount}")    '"ยอดตามเอกสาร"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.Paid}")         '"ยอดชำระแล้ว"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.Cost}")         '"มูลค่า"
      m_grid(1, 9).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.PO}")      '"เลขที่ใบสั่งซื้อ"
      m_grid(1, 10).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.GLnote}")    '"หมายเหตุ"

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
      m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentSupplierCode As String = ""
      Dim currentDocCode As String = ""

      Dim indent As String = Space(3)
      Dim tmpSum As Decimal = 0
      Dim currSupplierIndex As Integer = -1
      Dim currDocIndex As Integer = -1
      Dim netTmpSum As Decimal = 0

      For Each row As DataRow In dt.Rows
        If row("SupplierId").ToString <> currentSupplierCode Then
          If currentSupplierCode <> "" Then
            If currSupplierIndex <> -1 Then
              m_grid.RowCount += 1
              currDocIndex = m_grid.RowCount
              m_grid.RowStyles(currDocIndex).ReadOnly = True
              m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.Total}") '"รวม"
              m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(tmpSum, DigitConfig.Price)
              m_grid(currDocIndex, 1).Tag = "Total"
              tmpSum = 0
            End If
          End If
          m_grid.RowCount += 1
          currSupplierIndex = m_grid.RowCount
          m_grid.RowStyles(currSupplierIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currSupplierIndex).Font.Bold = True
          m_grid.RowStyles(currSupplierIndex).ReadOnly = True

          m_grid(currSupplierIndex, 1).CellValue = row("SupplierCode")
          m_grid(currSupplierIndex, 2).CellValue = row("SupplierName")
          currentSupplierCode = row("SupplierId").ToString
          m_grid(currSupplierIndex, 1).Tag = "Font.Bold"
          currentDocCode = ""
        End If
        If row("DocCode").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currDocIndex = m_grid.RowCount
          m_grid.RowStyles(currDocIndex).ReadOnly = True
          m_grid(currDocIndex, 0).Tag = row
          If IsDate(row("DueDate")) Then
            m_grid(currDocIndex, 1).CellValue = indent & CDate(row("DueDate")).ToShortDateString
          End If
          If Not row.IsNull("DocCode") Then
            m_grid(currDocIndex, 2).CellValue = indent & row("DocCode").ToString
          End If
          If Not row.IsNull("DocDate") Then
            m_grid(currDocIndex, 3).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("DocType") Then
            m_grid(currDocIndex, 4).CellValue = indent & row("DocType").ToString
          End If
                    If Not row.IsNull("VatCode") Or Not row.IsNull("APVatCode") Then
                        m_grid(currDocIndex, 5).CellValue = indent & row("VatCode").ToString & indent & row("APVatCode").ToString
                    End If
          If IsNumeric(row("Amt")) Then
            m_grid(currDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("DocAmount")), DigitConfig.Price)
          End If
          If IsNumeric(row("Amt")) Then
            m_grid(currDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("Paid")), DigitConfig.Price)
          End If
          If IsNumeric(row("Amt")) Then
            m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("Amt")), DigitConfig.Price)
            tmpSum += CDec(row("Amt"))
            netTmpSum += CDec(row("Amt"))
          End If
          If Not row.IsNull("PoCode") Then
            m_grid(currDocIndex, 9).CellValue = indent & row("PoCode").ToString
          End If
          If Not row.IsNull("Note") Then
            m_grid(currDocIndex, 10).CellValue = indent & row("Note").ToString
          End If

          m_grid(currDocIndex, 1).Tag = ""
          currentDocCode = row("DocCode").ToString
        End If
      Next

      If currSupplierIndex <> -1 Then
        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        'm_grid.RowStyles(currDocIndex).Font.Bold = True
        m_grid.RowStyles(currDocIndex).ReadOnly = True
        m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.Total}") '"รวม"
        m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(tmpSum, DigitConfig.Price)
        m_grid(currDocIndex, 1).Tag = "Total"
        tmpSum = 0

        m_grid.RowCount += 1
        currDocIndex = m_grid.RowCount
        m_grid.RowStyles(currDocIndex).Font.Bold = True
        m_grid.RowStyles(currDocIndex).ReadOnly = True
        m_grid(currDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.NetTotal}") '"รวมทั้งหมด"
        m_grid(currDocIndex, 8).CellValue = Configuration.FormatToString(netTmpSum, DigitConfig.Price)
        m_grid(currDocIndex, 1).Tag = "NetTotal"
        netTmpSum = 0
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPRemainDetail"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPRemainDetail"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPRemainDetail"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.ListLabel}"
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
      Return "RptAPRemainDetail"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAPRemainDetail"
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
      Dim SumAmt As Decimal = 0
      For rowIndex As Integer = 2 To m_grid.RowCount
        If rowIndex <> m_grid.RowCount Then

          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = m_grid(rowIndex, 1).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
            dpi.Font = fn1
          Else
            dpi.Font = fn2
          End If
          dpiColl.Add(dpi)

          If CType(m_grid(rowIndex, 1).Tag, String) = "Total" Then
            If IsNumeric(m_grid(rowIndex, 8).CellValue) Then
              SumAmt += CDec(m_grid(rowIndex, 8).CellValue)
            End If
          End If

          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
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
          If CType(m_grid(rowIndex, 1).Tag, String) <> "" Then
            dpi.Font = fn1
          Else
            dpi.Font = fn2
          End If
          dpiColl.Add(dpi)
        Else
          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          dpi.Value = m_grid(rowIndex, 5).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpi.Font = fn1
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpi.Font = fn1
          dpiColl.Add(dpi)
        End If

        n += 1
      Next

      'SumText
      dpi = New DocPrintingItem
      dpi.Mapping = "SumText"
      dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemainDetail.NetTotal}")
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpi.Font = fn1
      dpiColl.Add(dpi)

      'SumCol7
      dpi = New DocPrintingItem
      dpi.Mapping = "sumCol7"
      dpi.Value = Configuration.FormatToString(SumAmt, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpi.Font = fn1
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

