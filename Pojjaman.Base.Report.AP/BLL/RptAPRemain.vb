Option Explicit On
Option Strict On

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
  Public Class RptAPRemain
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_showDetailInGrid As Integer
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
      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      If m_showDetailInGrid = 0 Then
        lkg.Rows.HeaderCount = 1
        lkg.Rows.FrozenCount = 1
      Else
        lkg.Rows.HeaderCount = 2
        lkg.Rows.FrozenCount = 2
      End If

      lkg.Refresh()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim dr As DataRow = CType(m_hashData(e.RowIndex), DataRow)
      If dr Is Nothing Then
        Return
      End If

      Dim drh As New DataRowHelper(dr)

      Dim docId As Integer = drh.GetValue(Of Integer)("DocID")
      Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

      Trace.WriteLine(docId.ToString & ":" & docType.ToString)

      If docId > 0 AndAlso docType > 0 Then
        Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
        myEntityPanelService.OpenDetailPanel(en)
      End If
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      m_showDetailInGrid = CInt(Me.Filters(7).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)

      If m_showDetailInGrid = 0 Then
        ' Level 1.
        Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierCode}") '"รหัสเจ้าหนี้"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierName}") '"ชื่อเจ้าหนี้"
        tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OpenningBalance}") '"ยอดยกมา"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Cash}") '"ยอดซื้อสด"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Debt}") '"ยอดซื้อเชื่อ"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Dicount}") '"ยอดลดหนี้"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Pay}") '"ยอดจ่ายชำระ"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.EndingBalance}") '"ยอดยกไป"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionOpeningBalance}") '"ยอด Retention ยกมา"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Retention}") '"ยอด Retention"
        tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.PayRetention}") '"ยอดจ่ายชำระ Retention"
        tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionEndingBalance}") '"ยอด Retention ยกไป"
        tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"
        tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DebtDebit}") '"ยอดซื้"
      Else
        ' Level 1.
        Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierCode}") '"รหัสเจ้าหนี้"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.SupplierName}") '"ชื่อเจ้าหนี้"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OpenningBalance}") '"ยอดยกมา"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Cash}") '"ยอดซื้อสด"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Debt}") '"ยอดซื้อเชื่อ"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Dicount}") '"ยอดลดหนี้"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Pay}") '"ยอดจ่ายชำระ"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.EndingBalance}") '"ยอดยกไป"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionOpeningBalance}") '"ยอด Retention ยกมา"
        tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Retention}") '"ยอด Retention"
        tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.PayRetention}") '"ยอดจ่ายชำระ Retention"
        tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RetentionEndingBalance}") '"ยอด Retention ยกไป"
        tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"
        ' Level 2.
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DocType}") '"ประเภทเอกสาร"
        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPAging.DNDocNo}") '"เลขที่เอกสาร"
        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DocDate}") '"วันที่เอกสาร"
        tr("col3") = indent & Me.StringParserService.Parse("เลขที่ใบสำคัญ") '"เลขที่ใบสำคัญ"
        tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.CostCenter}") '"CostCenter"
        tr("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DebtDebit}") '"ยอดล้างเจ้าหนี้"
        tr("col17") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.RefDocCode}") '"เลขที่เอกสารอ้างอิง"
        tr("col18") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.VatitemCode}") '"เลขที่ใบกำกับภาษี"
                tr("col19") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OtherDocCode}") '"เลขที่ใบส่งของ"
                tr("col20") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.OtherDocDate}") '"วันที่ไปส่งของ"
            End If
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(1)
      'Dim dt2 As DataTable = Me.DataSet.Tables(2)

      m_hashData = New Hashtable

      If dt.Rows.Count = 0 Then
        Return
      End If
      Dim indent As String = Space(3)

      Dim trSupplier As TreeRow
      Dim trDetail As TreeRow

      Dim sumOpenningBalance As Decimal = 0
      Dim sumAmountCash As Decimal = 0
      Dim sumAmountAP As Decimal = 0
      Dim sumPCNAmount As Decimal = 0
      Dim sumPayAmount As Decimal = 0
      Dim sumEndingBalance As Decimal = 0
      Dim sumOpeningBalanceRetention As Decimal = 0
      Dim sumRetention As Decimal = 0
      Dim sumPaysRetention As Decimal = 0
      Dim sumEndingBalanceRetention As Decimal = 0

      For Each supplierRow As DataRow In dt.Rows
        trSupplier = Me.Treemanager.Treetable.Childs.Add
        trSupplier.Tag = "Font.Bold"
        Dim srh As New DataRowHelper(supplierRow)
        trSupplier("col0") = srh.GetValue(Of String)("supplier_code")
        trSupplier("col1") = srh.GetValue(Of String)("supplier_name")

        If m_showDetailInGrid = 0 Then
          trSupplier("col4") = Configuration.FormatToString(srh.GetValue(Of Decimal)("OpeningBalance"), DigitConfig.Price)
          trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("AmountCash"), DigitConfig.Price)
          trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("AmountAP"), DigitConfig.Price)
          trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("PCN"), DigitConfig.Price)
          trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Pays"), DigitConfig.Price)
          trSupplier("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("EndingBalance"), DigitConfig.Price)
          trSupplier("col10") = Configuration.FormatToString(srh.GetValue(Of Decimal)("OpeningBalanceRetention"), DigitConfig.Price)
          trSupplier("col11") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Retention"), DigitConfig.Price)
          trSupplier("col12") = Configuration.FormatToString(srh.GetValue(Of Decimal)("PayRetention"), DigitConfig.Price)
          trSupplier("col13") = Configuration.FormatToString(srh.GetValue(Of Decimal)("EndingBalanceRetention"), DigitConfig.Price)
        Else
          trSupplier("col5") = Configuration.FormatToString(srh.GetValue(Of Decimal)("OpeningBalance"), DigitConfig.Price)
          trSupplier("col6") = Configuration.FormatToString(srh.GetValue(Of Decimal)("AmountCash"), DigitConfig.Price)
          trSupplier("col7") = Configuration.FormatToString(srh.GetValue(Of Decimal)("AmountAP"), DigitConfig.Price)
          trSupplier("col8") = Configuration.FormatToString(srh.GetValue(Of Decimal)("PCN"), DigitConfig.Price)
          trSupplier("col9") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Pays"), DigitConfig.Price)
          trSupplier("col10") = Configuration.FormatToString(srh.GetValue(Of Decimal)("EndingBalance"), DigitConfig.Price)
          trSupplier("col11") = Configuration.FormatToString(srh.GetValue(Of Decimal)("OpeningBalanceRetention"), DigitConfig.Price)
          trSupplier("col12") = Configuration.FormatToString(srh.GetValue(Of Decimal)("Retention"), DigitConfig.Price)
          trSupplier("col13") = Configuration.FormatToString(srh.GetValue(Of Decimal)("PayRetention"), DigitConfig.Price)
          trSupplier("col14") = Configuration.FormatToString(srh.GetValue(Of Decimal)("EndingBalanceRetention"), DigitConfig.Price)
        End If
        sumOpenningBalance += srh.GetValue(Of Decimal)("OpeningBalance")
        sumAmountCash += srh.GetValue(Of Decimal)("AmountCash")
        sumAmountAP += srh.GetValue(Of Decimal)("AmountAP")
        sumPCNAmount += srh.GetValue(Of Decimal)("PCN")
        sumPayAmount += srh.GetValue(Of Decimal)("Pays")
        sumEndingBalance += srh.GetValue(Of Decimal)("EndingBalance")
        sumOpeningBalanceRetention += srh.GetValue(Of Decimal)("OpeningBalanceRetention")
        sumRetention += srh.GetValue(Of Decimal)("Retention")
        sumPaysRetention += srh.GetValue(Of Decimal)("PayRetention")
        sumEndingBalanceRetention += srh.GetValue(Of Decimal)("EndingBalanceRetention")

        'If Not supplierRow.IsNull("supplier_code") Then
        '  trSupplier("col0") = supplierRow("supplier_code").ToString
        'End If
        'If Not supplierRow.IsNull("supplier_name") Then
        '  trSupplier("col1") = supplierRow("supplier_name").ToString
        'End If
        'If Not supplierRow.IsNull("OpeningBalance") Then
        '  If m_showDetailInGrid = 0 Then
        '    trSupplier("col4") = Configuration.FormatToString(CDec(supplierRow("OpeningBalance")), DigitConfig.Price)
        '  Else
        '    trSupplier("col5") = Configuration.FormatToString(CDec(supplierRow("OpeningBalance")), DigitConfig.Price)
        '  End If
        '  sumOpenningBalance += CDec(supplierRow("OpeningBalance"))
        'End If
        'If Not supplierRow.IsNull("Amount") Then
        '  If CDec(supplierRow("Amount")) <> 0 Then
        '    If m_showDetailInGrid = 0 Then
        '      trSupplier("col5") = Configuration.FormatToString(CDec(supplierRow("AmountCash")), DigitConfig.Price)
        '      trSupplier("col6") = Configuration.FormatToString(CDec(supplierRow("AmountAP")), DigitConfig.Price)
        '    Else
        '      trSupplier("col6") = Configuration.FormatToString(CDec(supplierRow("AmountCash")), DigitConfig.Price)
        '      trSupplier("col7") = Configuration.FormatToString(CDec(supplierRow("AmountAP")), DigitConfig.Price)
        '    End If
        '    sumAmountCash += CDec(supplierRow("Amount"))
        '  End If
        'End If
        'If Not supplierRow.IsNull("PCN") Then
        '  If CDec(supplierRow("PCN")) <> 0 Then
        '    If m_showDetailInGrid = 0 Then
        '      trSupplier("col7") = Configuration.FormatToString(CDec(supplierRow("PCN")), DigitConfig.Price)
        '    Else
        '      trSupplier("col8") = Configuration.FormatToString(CDec(supplierRow("PCN")), DigitConfig.Price)
        '    End If
        '    sumPCNAmount += CDec(supplierRow("PCN"))
        '  End If
        'End If
        'If Not supplierRow.IsNull("Pays") Then
        '  If CDec(supplierRow("Pays")) <> 0 Then
        '    If m_showDetailInGrid = 0 Then
        '      trSupplier("col8") = Configuration.FormatToString(CDec(supplierRow("Pays")), DigitConfig.Price)
        '    Else
        '      trSupplier("col9") = Configuration.FormatToString(CDec(supplierRow("Pays")), DigitConfig.Price)
        '    End If
        '    sumPayAmount += CDec(supplierRow("Pays"))
        '  End If
        'End If
        'If Not supplierRow.IsNull("EndingBalance") Then
        '  If m_showDetailInGrid = 0 Then
        '    trSupplier("col9") = Configuration.FormatToString(CDec(supplierRow("EndingBalance")), DigitConfig.Price)
        '  Else
        '    trSupplier("col10") = Configuration.FormatToString(CDec(supplierRow("EndingBalance")), DigitConfig.Price)
        '  End If
        '  sumEndingBalance += CDec(supplierRow("EndingBalance"))
        'End If

        'If Not supplierRow.IsNull("OpeningBalanceRetention") Then
        '  If m_showDetailInGrid = 0 Then
        '    trSupplier("col10") = Configuration.FormatToString(CDec(supplierRow("OpeningBalanceRetention")), DigitConfig.Price)
        '  Else
        '    trSupplier("col11") = Configuration.FormatToString(CDec(supplierRow("OpeningBalanceRetention")), DigitConfig.Price)
        '  End If
        '  sumOpeningBalanceRetention += CDec(supplierRow("OpeningBalanceRetention"))
        'End If
        'If Not supplierRow.IsNull("Retention") Then
        '  If CDec(supplierRow("Retention")) <> 0 Then
        '    If m_showDetailInGrid = 0 Then
        '      trSupplier("col11") = Configuration.FormatToString(CDec(supplierRow("Retention")), DigitConfig.Price)
        '    Else
        '      trSupplier("col12") = Configuration.FormatToString(CDec(supplierRow("Retention")), DigitConfig.Price)
        '    End If
        '    sumRetention += CDec(supplierRow("Retention"))
        '  End If
        'End If
        'If Not supplierRow.IsNull("PayRetention") Then
        '  If CDec(supplierRow("PayRetention")) <> 0 Then
        '    If m_showDetailInGrid = 0 Then
        '      trSupplier("col13") = Configuration.FormatToString(CDec(supplierRow("PayRetention")), DigitConfig.Price)
        '    Else
        '      trSupplier("col14") = Configuration.FormatToString(CDec(supplierRow("PayRetention")), DigitConfig.Price)
        '    End If
        '    sumPaysRetention += CDec(supplierRow("PayRetention"))
        '  End If
        'End If
        'If Not supplierRow.IsNull("EndingBalanceRetention") Then
        '  If m_showDetailInGrid = 0 Then
        '    trSupplier("col14") = Configuration.FormatToString(CDec(supplierRow("EndingBalanceRetention")), DigitConfig.Price)
        '  Else
        '    trSupplier("col15") = Configuration.FormatToString(CDec(supplierRow("EndingBalanceRetention")), DigitConfig.Price)
        '  End If
        '  sumEndingBalanceRetention += CDec(supplierRow("EndingBalanceRetention"))
        'End If


        If m_showDetailInGrid <> 0 Then
          Dim dt2 As DataTable = Me.DataSet.Tables(2)
          trSupplier.State = RowExpandState.Expanded
          For Each detailRow As DataRow In dt2.Select("Supplier=" & supplierRow("Supplier_ID").ToString)
            Dim deh As New DataRowHelper(detailRow)
            If Not trSupplier Is Nothing Then
              trDetail = trSupplier.Childs.Add
              trDetail.Tag = detailRow
              trDetail("col0") = indent & deh.GetValue(Of String)("entity_description")
              trDetail("col1") = indent & deh.GetValue(Of String)("doccode")
              trDetail("col2") = indent & deh.GetValue(Of Date)("docdate").ToShortDateString
              trDetail("col3") = indent & deh.GetValue(Of String)("glcode", "-")
              trDetail("col4") = indent & deh.GetValue(Of String)("CC")
              'If Not detailRow.IsNull("entity_description") Then
              '  trDetail("col0") = indent & detailRow("entity_description").ToString
              'End If
              'If Not detailRow.IsNull("doccode") Then
              '  trDetail("col1") = indent & detailRow("doccode").ToString
              'End If
              'If Not detailRow.IsNull("docdate") Then
              '  If IsDate(detailRow("docdate")) Then
              '    trDetail("col2") = indent & CDate(detailRow("docdate")).ToShortDateString
              '  End If
              'End If

              'trDetail("col3") = indent & deh.GetValue(Of String)("glcode", "-")

              'If Not detailRow.IsNull("CC") Then
              '  trDetail("col4") = indent & detailRow("CC").ToString
              'End If

              trDetail("col5") = Configuration.FormatToString(deh.GetValue(Of Decimal)("OpeningBalance"), DigitConfig.Price)
              trDetail("col6") = Configuration.FormatToString(deh.GetValue(Of Decimal)("AmountCash"), DigitConfig.Price)
              trDetail("col7") = Configuration.FormatToString(deh.GetValue(Of Decimal)("AmountAP"), DigitConfig.Price)
              trDetail("col8") = Configuration.FormatToString(deh.GetValue(Of Decimal)("PCN"), DigitConfig.Price)
              trDetail("col9") = Configuration.FormatToString(deh.GetValue(Of Decimal)("Pays"), DigitConfig.Price)
              trDetail("col10") = Configuration.FormatToString(deh.GetValue(Of Decimal)("EndingBalance"), DigitConfig.Price)
              trDetail("col11") = Configuration.FormatToString(deh.GetValue(Of Decimal)("OpeningBalanceRetention"), DigitConfig.Price)
              trDetail("col12") = Configuration.FormatToString(deh.GetValue(Of Decimal)("Retention"), DigitConfig.Price)
              trDetail("col13") = Configuration.FormatToString(deh.GetValue(Of Decimal)("PayRetention"), DigitConfig.Price)
              trDetail("col14") = Configuration.FormatToString(deh.GetValue(Of Decimal)("EndingBalanceRetention"), DigitConfig.Price)
              trDetail("col15") = indent & deh.GetValue(Of String)("glNote", "-")
              trDetail("col16") = Configuration.FormatToString(deh.GetValue(Of Decimal)("PaysGross"), DigitConfig.Price)

              trDetail("col17") = deh.GetValue(Of String)("RefDocCode")
                            trDetail("col18") = deh.GetValue(Of String)("VatitemCode")
                            trDetail("col19") = deh.GetValue(Of String)("OtherCode")
                            trDetail("col20") = deh.GetValue(Of String)("OtherDate")

              'If Not detailRow.IsNull("OpeningBalance") Then
              '  trDetail("col5") = Configuration.FormatToString(CDec(detailRow("OpeningBalance")), DigitConfig.Price)
              'End If
              'If Not detailRow.IsNull("Amount") Then
              '  If CDec(detailRow("Amount")) <> 0 Then
              '    trDetail("col6") = Configuration.FormatToString(CDec(detailRow("Amount")), DigitConfig.Price)
              '  End If
              'End If
              'If Not detailRow.IsNull("PCN") Then
              '  If CDec(detailRow("PCN")) <> 0 Then
              '    trDetail("col7") = Configuration.FormatToString(CDec(detailRow("PCN")), DigitConfig.Price)
              '  End If
              'End If
              'If Not detailRow.IsNull("Pays") Then
              '  If CDec(detailRow("Pays")) <> 0 Then
              '    trDetail("col8") = Configuration.FormatToString(CDec(detailRow("Pays")), DigitConfig.Price)
              '  End If
              'End If
              'If Not detailRow.IsNull("EndingBalance") Then
              '  trDetail("col9") = Configuration.FormatToString(CDec(detailRow("EndingBalance")), DigitConfig.Price)
              'End If
              'If Not detailRow.IsNull("OpeningBalanceRetention") Then
              '  trDetail("col10") = Configuration.FormatToString(CDec(detailRow("OpeningBalanceRetention")), DigitConfig.Price)
              'End If
              'If Not detailRow.IsNull("Retention") Then
              '  If CDec(detailRow("Retention")) <> 0 Then
              '    trDetail("col11") = Configuration.FormatToString(CDec(detailRow("Retention")), DigitConfig.Price)
              '  End If
              'End If
              'If Not detailRow.IsNull("PayRetention") Then
              '  If CDec(detailRow("PayRetention")) <> 0 Then
              '    trDetail("col12") = Configuration.FormatToString(CDec(detailRow("PayRetention")), DigitConfig.Price)
              '  End If
              'End If
              'If Not detailRow.IsNull("RefDocCode") Then
              '  trDetail("col16") = detailRow("RefDocCode")
              'End If
              'If Not detailRow.IsNull("VatitemCode") Then
              '  trDetail("col17") = detailRow("VatitemCode")
              'End If
            End If
          Next
        End If
      Next
      'ตูดรายงาน
      trSupplier = Me.Treemanager.Treetable.Childs.Add
      trSupplier.Tag = "Font.Bold"
      trSupplier("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.Total}")  'รวม
      If m_showDetailInGrid = 0 Then
        trSupplier("col4") = Configuration.FormatToString(sumOpenningBalance, DigitConfig.Price)
        If sumAmountCash > 0 Then
          trSupplier("col5") = Configuration.FormatToString(sumAmountCash, DigitConfig.Price)
        End If
        If sumAmountAP > 0 Then
          trSupplier("col6") = Configuration.FormatToString(sumAmountAP, DigitConfig.Price)
        End If
        If sumPCNAmount > 0 Then
          trSupplier("col7") = Configuration.FormatToString(sumPCNAmount, DigitConfig.Price)
        End If
        If sumPayAmount > 0 Then
          trSupplier("col8") = Configuration.FormatToString(sumPayAmount, DigitConfig.Price)
        End If
        trSupplier("col9") = Configuration.FormatToString(sumEndingBalance, DigitConfig.Price)

        trSupplier("col10") = Configuration.FormatToString(sumOpeningBalanceRetention, DigitConfig.Price)
        If sumRetention > 0 Then
          trSupplier("col11") = Configuration.FormatToString(sumRetention, DigitConfig.Price)
        End If
        If sumPaysRetention > 0 Then
          trSupplier("col12") = Configuration.FormatToString(sumPaysRetention, DigitConfig.Price)
        End If
        trSupplier("col13") = Configuration.FormatToString(sumEndingBalanceRetention, DigitConfig.Price)
      Else
        trSupplier("col5") = Configuration.FormatToString(sumOpenningBalance, DigitConfig.Price)
        If sumAmountCash > 0 Then
          trSupplier("col6") = Configuration.FormatToString(sumAmountCash, DigitConfig.Price)
        End If
        If sumAmountAP > 0 Then
          trSupplier("col7") = Configuration.FormatToString(sumAmountAP, DigitConfig.Price)
        End If
        If sumPCNAmount > 0 Then
          trSupplier("col8") = Configuration.FormatToString(sumPCNAmount, DigitConfig.Price)
        End If
        If sumPayAmount > 0 Then
          trSupplier("col9") = Configuration.FormatToString(sumPayAmount, DigitConfig.Price)
        End If
        trSupplier("col10") = Configuration.FormatToString(sumEndingBalance, DigitConfig.Price)

        trSupplier("col11") = Configuration.FormatToString(sumOpeningBalanceRetention, DigitConfig.Price)
        If sumRetention > 0 Then
          trSupplier("col12") = Configuration.FormatToString(sumRetention, DigitConfig.Price)
        End If
        If sumPaysRetention > 0 Then
          trSupplier("col13") = Configuration.FormatToString(sumPaysRetention, DigitConfig.Price)
        End If
        trSupplier("col14") = Configuration.FormatToString(sumEndingBalanceRetention, DigitConfig.Price)
      End If


      Dim lineNumber As Integer = 1
      For Each tr As TreeRow In Me.m_treemanager.Treetable.Rows
        If Not tr.Tag Is Nothing AndAlso TypeOf tr.Tag Is DataRow Then
          m_hashData(lineNumber) = CType(tr.Tag, DataRow)
        End If

        lineNumber += 1
      Next

    End Sub
    Private Function SearchTag(ByVal id As Integer) As TreeRow
      If Me.m_treemanager Is Nothing Then
        Return Nothing
      End If
      Dim dt As TreeTable = m_treemanager.Treetable
      For Each row As TreeRow In dt.Rows
        If IsNumeric(row.Tag) AndAlso CInt(row.Tag) = id Then
          Return row
        End If
      Next
    End Function
    Public Overrides Function GetSimpleSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("Report")
      myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col14", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col15", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col16", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("col17", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col18", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col19", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col20", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim iCol As Integer = 20 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

      widths.Add(90)
      widths.Add(180)
      widths.Add(80 * m_showDetailInGrid)
      widths.Add(95 * m_showDetailInGrid)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(180 * m_showDetailInGrid)
      widths.Add(95 * m_showDetailInGrid)
      widths.Add(100 * m_showDetailInGrid)
      widths.Add(100 * m_showDetailInGrid)
      widths.Add(80 * m_showDetailInGrid)
      widths.Add(80 * m_showDetailInGrid)

      For i As Integer = 0 To iCol
        If i = 1 Then
          If m_showDetailInGrid <> 0 Then
            Dim cs As New PlusMinusTreeTextColumn
            cs.MappingName = "col" & i
            cs.HeaderText = ""
            cs.Width = CInt(widths(i))
            cs.NullText = ""
            cs.Alignment = HorizontalAlignment.Left
            cs.ReadOnly = True
            cs.Format = "s"
            AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
            dst.GridColumnStyles.Add(cs)
          Else
            Dim cs As New TreeTextColumn(1, True, Color.White)
            cs.MappingName = "col" & i
            cs.HeaderText = ""
            cs.Width = CInt(widths(i))
            cs.NullText = ""
            cs.Alignment = HorizontalAlignment.Left
            cs.ReadOnly = True
            cs.Format = "s"
            AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
            dst.GridColumnStyles.Add(cs)
          End If
        Else
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          If m_showDetailInGrid <> 0 Then
            Select Case i
              Case 0, 1, 2, 3, 4, 15, 17, 18, 19, 20
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = HorizontalAlignment.Left
                cs.Format = "s"
              Case Else
                cs.Alignment = HorizontalAlignment.Right
                cs.DataAlignment = HorizontalAlignment.Right
                cs.Format = "d"
            End Select
          Else
            Select Case i
              Case 0, 1, 10
                cs.Alignment = HorizontalAlignment.Left
                cs.DataAlignment = HorizontalAlignment.Left
                cs.Format = "s"
              Case Else
                cs.Alignment = HorizontalAlignment.Right
                cs.DataAlignment = HorizontalAlignment.Right
                cs.Format = "d"
            End Select
          End If

          cs.ReadOnly = True

          AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
          dst.GridColumnStyles.Add(cs)
        End If
      Next

      Return dst
    End Function
    Public Overrides Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      e.HilightValue = False
      If e.Row <= 1 Then
        e.HilightValue = True
      End If
    End Sub
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAPRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptAPRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.ListLabel}"
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
        Select Case fixDpi.Mapping.ToLower
          Case "month", "year", "today"
            dpiColl.Add(fixDpi)
          Case "docdatestart", "docdateend"
            dpiColl.Add(fixDpi)
          Case "supplierstart", "supplierend"
            dpiColl.Add(fixDpi)
          Case "costcenterstart", "costcenterend"
            dpiColl.Add(fixDpi)
        End Select
      Next

      Dim i As Integer = 0
      Dim iRow As Integer = 0
      If m_showDetailInGrid = 0 Then
        iRow = 2
      Else
        iRow = 3
      End If
      Dim fn As Font

      For rowIndex As Integer = iRow To Me.m_grid.RowCount

        fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

        If Me.m_showDetailInGrid <> 0 Then
          If Not CType(Me.Treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
            fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
        End If

        For colIndex As Integer = 1 To Me.m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & colIndex.ToString
          dpi.Value = m_grid(rowIndex, colIndex).CellValue
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpi.Font = fn
          dpiColl.Add(dpi)
        Next

        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

