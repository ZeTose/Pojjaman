
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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptDR
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
      m_grid.Refresh()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      Dim dr As DataRow = CType(m_grid(e.RowIndex, 0).Tag, DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
      Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Private Sub CreateHeader()
      m_grid.RowCount = 1
      m_grid.ColCount = 15

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 120
      m_grid.ColWidths(3) = 100
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 200
      m_grid.ColWidths(6) = 200
      m_grid.ColWidths(7) = 100
      m_grid.ColWidths(8) = 100
      m_grid.ColWidths(9) = 100
      m_grid.ColWidths(10) = 100
      m_grid.ColWidths(11) = 100
      m_grid.ColWidths(12) = 200
      m_grid.ColWidths(13) = 120
      m_grid.ColWidths(14) = 200
      m_grid.ColWidths(15) = 200

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      Dim indent As String = Space(3)
      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.DocNumber}")       '"เลขที่เอกสาร"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.sc_docDate}")      '"วันที่เอกสาร"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.SCCode}") '"เลขที่ใบสั่งจ้าง"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.subcontractorinfo}")    '"ผู้รับเหมา"    
      m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.toccinfo}")          '"Cost Center เบิก "
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.fromccinfo}")             '"Cost Center ให้เบิก"
      m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.Sum}")             '"ยอดรวมไม่รวม"************
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.taxamt}")       '"มูลค่าภาษี"
      m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.beforetax}")       '"ยอดรวมภาษี"
      m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.ReceivedAmount}")       '"รับงานแล้ว"
      m_grid(0, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.RemainingAmount}")       '"ค้างรับงาน"

      m_grid(0, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.note}")      '"หมายเหตุ"
      m_grid(0, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.refstatus}")      '"อ้างอิง"
      m_grid(0, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.scstatusinfo}")    '"สถานะ"
      m_grid(0, 15).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.Director}")    '"ผู้สั่งจ้าง"

      m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.PADocNumber}")      '"เลขที่เอกสาร"
      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.sc_docDate}")    '"วันที่เอกสาร"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.paitem}") '"เลขที่ใบสั่งจ้าง"
      m_grid(1, 10).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.amt}")

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(0, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

      m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt1 As DataTable = Me.DataSet.Tables(1)

      Dim currTrIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim currPAIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim currDRId As Integer

      Dim SumAmount As Decimal = 0
      Dim SumTaxAmt As Decimal = 0
      Dim SumAfterTax As Decimal = 0
      Dim SumBeforeTax As Decimal = 0
      Dim SumReceivedAmount As Decimal = 0
      Dim SumRemainingAmount As Decimal = 0

      Dim n As Int32 = 0

      Dim hashPA As New Hashtable
      Dim listPARows As New List(Of DataRow)
      Dim refId As Integer = 0
      For Each row As DataRow In dt1.Rows
        refId = CInt(row("pai_refdoc"))
        If Not hashPA.ContainsKey(refId) Then
          listPARows = New List(Of DataRow)
          listPARows.Add(row)
          hashPA.Add(refId, listPARows)
        Else
          listPARows = CType(hashPA(refId), List(Of DataRow))
          listPARows.Add(row)
          hashPA(refId) = listPARows
        End If
      Next

      For Each row As DataRow In dt.Rows
        refId = CInt(row("dr_id"))
        'Dim dr As DataRow() = dt1.Select("pai_refDoc=" & row("dr_id"))

        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid(currItemIndex, 0).Tag = row
        If hashPA.ContainsKey(refId) Then 'DR.Length > 0 Then
          m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(255, 180, 100)
        End If

        m_grid.RowStyles(currItemIndex).ReadOnly = True
        m_grid(currItemIndex, 1).CellValue = row("DRcode")
        If Not row.IsNull("dr_docDate") Then
          m_grid(currItemIndex, 2).CellValue = CDate(row("dr_docDate")).ToShortDateString
        End If
        If Not row.IsNull("SCCode") Then
          m_grid(currItemIndex, 3).CellValue = row("SCCode").ToString
        End If
        If Not row.IsNull("subcontractor") Then
          m_grid(currItemIndex, 4).CellValue = row("subcontractor").ToString
        End If
        If Not row.IsNull("tocc") Then
          m_grid(currItemIndex, 5).CellValue = row("tocc").ToString
        End If
        If Not row.IsNull("fromcc") Then
          m_grid(currItemIndex, 6).CellValue = row("fromcc").ToString
        End If
        If Not row.IsNull("dr_beforetax") Then
          m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("dr_beforetax")), DigitConfig.Price)
          SumBeforeTax += CDec(row("dr_beforetax"))
        End If
        If Not row.IsNull("taxAmt") Then
          m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("taxAmt")), DigitConfig.Price)
          SumTaxAmt += CDec(row("taxAmt"))
        End If
        If Not row.IsNull("dr_aftertax") Then
          m_grid(currItemIndex, 9).CellValue = Configuration.FormatToString(CDec(row("dr_aftertax")), DigitConfig.Price)
          SumAfterTax += CDec(row("dr_aftertax"))
        End If
        If Not row.IsNull("ReceivedAmount") Then
          m_grid(currItemIndex, 10).CellValue = Configuration.FormatToString(CDec(row("ReceivedAmount")), DigitConfig.Price)
          SumReceivedAmount += CDec(row("ReceivedAmount"))
        End If
        If Not row.IsNull("RemainingAmount") Then
          m_grid(currItemIndex, 11).CellValue = Configuration.FormatToString(CDec(row("RemainingAmount")), DigitConfig.Price)
          SumRemainingAmount += CDec(row("RemainingAmount"))
        End If
        m_grid(currItemIndex, 12).CellValue = row("SCnote").ToString
        m_grid(currItemIndex, 13).CellValue = row("refstatus").ToString 'อ้างอิง
        m_grid(currItemIndex, 14).CellValue = row("DRStatus").ToString 'สถานะ
        m_grid(currItemIndex, 15).CellValue = row("employee_name").ToString
        currDRId = row("dr_id")

        If hashPA.ContainsKey(refId) Then
          For Each parow As DataRow In CType(hashPA(refId), List(Of DataRow)) 'dt1.Rows
            If currDRId = parow("pai_refDoc") Then
              ' Dim newPArow As New DataRowHelper(parow)
              m_grid.RowCount += 1
              currPAIndex = m_grid.RowCount
              m_grid(currPAIndex, 0).Tag = parow
              m_grid.RowStyles(currPAIndex).ReadOnly = True
              m_grid(currPAIndex, 1).CellValue = indent & parow("pa_code")

              If Not parow.IsNull("pa_docDate") Then
                m_grid(currPAIndex, 2).CellValue = indent & CDate(parow("pa_docDate")).ToShortDateString
              End If
              If Not parow.IsNull("pai_itemName") Then
                m_grid(currPAIndex, 3).CellValue = indent & parow("pai_itemName").ToString
              End If
              If Not parow.IsNull("pai_amt") Then
                m_grid(currPAIndex, 10).CellValue = indent & Configuration.FormatToString(CDec(parow("pai_amt")), DigitConfig.Price)
              End If
              If Not parow.IsNull("pai_not") Then
                m_grid(currPAIndex, 12).CellValue = indent & parow("pai_not").ToString
              End If
            End If

          Next
        End If


      Next
      m_grid.RowCount += 1
      currTrIndex = m_grid.RowCount
      m_grid.RowStyles(currTrIndex).BackColor = Color.FromArgb(128, 255, 128)
      m_grid.RowStyles(currTrIndex).Font.Bold = True
      m_grid.RowStyles(currTrIndex).ReadOnly = True
      m_grid(currTrIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptDR.SumAll}") 'รวม
      m_grid(currTrIndex, 7).CellValue = Configuration.FormatToString(SumBeforeTax, DigitConfig.Price) 'ยอดรวมไม่รวม
      m_grid(currTrIndex, 8).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price) 'มูลค่าภาษี 
      m_grid(currTrIndex, 9).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price) 'ยอดรวมภาษี 
      m_grid(currTrIndex, 10).CellValue = Configuration.FormatToString(SumReceivedAmount, DigitConfig.Price) 'รับงานแล้ว 
      m_grid(currTrIndex, 11).CellValue = Configuration.FormatToString(SumRemainingAmount, DigitConfig.Price) 'ค้างรับงาน 

    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptDR"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptDR.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptDR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptDR"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptDR.ListLabel}"
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
      Return "RptDR"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptDR"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim LineNumber As Integer = 0

      Dim n As Integer = 0
      Dim i As Integer = 0
      For rowIndex As Integer = 1 To m_grid.RowCount
        i += 1
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = i
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

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

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col5"
        'dpi.Value = m_grid(rowIndex, 6).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col6"
        'dpi.Value = m_grid(rowIndex, 7).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col7"
        'dpi.Value = m_grid(rowIndex, 8).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col8"
        'dpi.Value = m_grid(rowIndex, 9).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col9"
        'dpi.Value = m_grid(rowIndex, 10).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col10"
        'dpi.Value = m_grid(rowIndex, 11).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col11"
        'dpi.Value = m_grid(rowIndex, 12).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col12"
        'dpi.Value = m_grid(rowIndex, 13).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col13"
        'dpi.Value = m_grid(rowIndex, 14).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col14"
        'dpi.Value = m_grid(rowIndex, 15).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)

        'dpi = New DocPrintingItem
        'dpi.Mapping = "col15"
        'dpi.Value = m_grid(rowIndex, 16).CellValue
        'dpi.DataType = "System.String"
        'dpi.Row = n + 1
        'dpi.Table = "Item"
        'dpiColl.Add(dpi)


        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace
