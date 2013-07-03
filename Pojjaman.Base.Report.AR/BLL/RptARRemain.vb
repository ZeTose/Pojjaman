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
  Public Class RptARRemain
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
      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      If Me.Filters(7).Value = 0 Then
        lkg.Rows.HeaderCount = 1
        lkg.Rows.FrozenCount = 1
      Else
        lkg.Rows.HeaderCount = 2
        lkg.Rows.FrozenCount = 2
      End If

      lkg.Refresh()
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim tr As Object = m_hashData(e.RowIndex)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is DataRow Then
        Dim dr As DataRow = CType(tr, DataRow)
        If dr Is Nothing Then
          Return
        End If

        Dim drh As New DataRowHelper(dr)

        Dim docId As Integer = drh.GetValue(Of Integer)("ID")
        Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

        Debug.Print(docId.ToString)
        Debug.Print(docType.ToString)

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
        End If
      End If
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
      Me.m_treemanager = tm
      Me.m_treemanager.Treetable.Clear()
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim indent As String = Space(3)

      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      If CInt(Me.Filters(7).Value) = 0 Then
        ' Level 1.
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerCode}") '"รหัสลูกหนี้"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerName}") '"ชื่อลูกหนี้"
        tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpenningBalance}") '"ยอดยกมา"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Debt}") '"ยอดซื้อเชื่อ"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.SCN}") '"ยอดลดหนี้"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Receive}") '"ยอดรับชำระ"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalance}") '"ยอดยกไป"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpeningBalanceRetention}") '"ยอด Retention ยกมา"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Retention}") '"ยอด Retention"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}") '"วางบิล Retentionลด"   ${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}
        tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalanceRetention}") '"ยอด Retention ยกไป"
        tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ReceiveRetention}") '"ยอดรับชำระ Retention"
        'tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"

      Else
        ' Level 1.
        tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerCode}") '"รหัสลูกหนี้"
        tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerName}") '"ชื่อลูกหนี้"
        tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpenningBalance}") '"ยอดยกมา"
        tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Debt}") '"ยอดซื้อเชื่อ"
        tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.SCN}") '"ยอดลดหนี้"
        tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Receive}") '"ยอดรับชำระ"
        tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalance}") '"ยอดยกไป"
        tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpeningBalanceRetention}") '"ยอด Retention ยกมา"
        tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Retention}") '"ยอด Retention"
        tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}") '"วางบิล Retentionลด"   ${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}
        tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalanceRetention}") '"ยอด Retention ยกไป"
        tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ReceiveRetention}") '"ยอดรับชำระ Retention"

        ' Level 2.
        tr = Me.m_treemanager.Treetable.Childs.Add
        tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DocType}") '"ประเภทเอกสาร"
        tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DNDocNo}") '"เลขที่เอกสาร"
        tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DocDate}") '"วันที่เอกสาร"
        tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrCode}") '"เลขที่ใบสำคัญ"
        tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.CostCenter}") '"เลขที่ใบสำคัญ"
        tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"หมายเหตุ"
        tr("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.VatCode}") '"ใบกำกับภาษี"

      End If
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt2 As DataTable
      If CInt(Me.Filters(7).Value) <> 0 Then
        dt2 = Me.DataSet.Tables(1)
      End If

      If dt.Rows.Count = 0 Then
        Return
      End If

      Dim indent As String = Space(3)

      Dim trCustomer As TreeRow
      Dim trDetail As TreeRow

      Dim sumOpenningBalance As Decimal = 0
      Dim sumAmount As Decimal = 0
      Dim sumSCNAmount As Decimal = 0
      Dim sumReceiveAmount As Decimal = 0
      Dim sumEndingBalance As Decimal = 0
      Dim sumOPBRetention As Decimal = 0
      Dim sumRetention As Decimal = 0
      Dim sumDecreaseRetention As Decimal = 0
      Dim sumEndingBalanceRetention As Decimal = 0
      Dim sumReceiveRetention As Decimal = 0

      Dim rowIndex As Integer = 0
      m_hashData = New Hashtable

      For Each supplierRow As DataRow In dt.Rows

        trCustomer = Me.Treemanager.Treetable.Childs.Add
        If CInt(Me.Filters(7).Value) <> 0 Then
          trCustomer.Tag = "Font.Bold"
        End If

        If Not supplierRow.IsNull("cust_code") Then
          trCustomer("col0") = supplierRow("cust_code").ToString
        End If
        If Not supplierRow.IsNull("cust_name") Then
          trCustomer("col1") = supplierRow("cust_name").ToString
        End If

        If CInt(Me.Filters(7).Value) = 0 Then
          If Not supplierRow.IsNull("OpeningBalance") Then
            trCustomer("col4") = Configuration.FormatToString(CDec(supplierRow("OpeningBalance")), DigitConfig.Price)
            sumOpenningBalance += CDec(supplierRow("OpeningBalance"))
          End If
          If Not supplierRow.IsNull("Amount") Then
            If CDec(supplierRow("Amount")) > 0 Then
              trCustomer("col5") = Configuration.FormatToString(CDec(supplierRow("Amount")), DigitConfig.Price)
              sumAmount += CDec(supplierRow("Amount"))
            End If
          End If
          If Not supplierRow.IsNull("SCN") Then
            If CDec(supplierRow("SCN")) > 0 Then
              trCustomer("col6") = Configuration.FormatToString(CDec(supplierRow("SCN")), DigitConfig.Price)
              sumSCNAmount += CDec(supplierRow("SCN"))
            End If
          End If
          If Not supplierRow.IsNull("ReceiveSelection") Then
            If CDec(supplierRow("ReceiveSelection")) > 0 Then
              trCustomer("col7") = Configuration.FormatToString(CDec(supplierRow("ReceiveSelection")), DigitConfig.Price)
              sumReceiveAmount += CDec(supplierRow("ReceiveSelection"))
            End If
          End If
          If Not supplierRow.IsNull("EndingBalance") Then
            trCustomer("col8") = Configuration.FormatToString(CDec(supplierRow("EndingBalance")), DigitConfig.Price)
            sumEndingBalance += CDec(supplierRow("EndingBalance"))
          End If

          If Not supplierRow.IsNull("OPBRetention") Then
            trCustomer("col9") = Configuration.FormatToString(CDec(supplierRow("OPBRetention")), DigitConfig.Price)
            sumOPBRetention += CDec(supplierRow("OPBRetention"))
          End If
          If Not supplierRow.IsNull("Retention") Then
            trCustomer("col10") = Configuration.FormatToString(CDec(supplierRow("Retention")), DigitConfig.Price)
            sumRetention += CDec(supplierRow("Retention"))
          End If
          If Not supplierRow.IsNull("DecreaseRetention") Then
            trCustomer("col11") = Configuration.FormatToString(CDec(supplierRow("DecreaseRetention")), DigitConfig.Price)
            sumDecreaseRetention += CDec(supplierRow("DecreaseRetention"))
          End If
          If Not supplierRow.IsNull("EndingBalanceRetention") Then
            trCustomer("col12") = Configuration.FormatToString(CDec(supplierRow("EndingBalanceRetention")), DigitConfig.Price)
            sumEndingBalanceRetention += CDec(supplierRow("EndingBalanceRetention"))
          End If
          If Not supplierRow.IsNull("ReceiveRetention") Then
            trCustomer("col13") = Configuration.FormatToString(CDec(supplierRow("ReceiveRetention")), DigitConfig.Price)
            sumReceiveRetention += CDec(supplierRow("ReceiveRetention"))
          End If
        Else
          If Not supplierRow.IsNull("OpeningBalance") Then
            trCustomer("col5") = Configuration.FormatToString(CDec(supplierRow("OpeningBalance")), DigitConfig.Price)
            sumOpenningBalance += CDec(supplierRow("OpeningBalance"))
          End If
          If Not supplierRow.IsNull("Amount") Then
            If CDec(supplierRow("Amount")) > 0 Then
              trCustomer("col6") = Configuration.FormatToString(CDec(supplierRow("Amount")), DigitConfig.Price)
              sumAmount += CDec(supplierRow("Amount"))
            End If
          End If
          If Not supplierRow.IsNull("SCN") Then
            If CDec(supplierRow("SCN")) > 0 Then
              trCustomer("col7") = Configuration.FormatToString(CDec(supplierRow("SCN")), DigitConfig.Price)
              sumSCNAmount += CDec(supplierRow("SCN"))
            End If
          End If
          If Not supplierRow.IsNull("ReceiveSelection") Then
            If CDec(supplierRow("ReceiveSelection")) > 0 Then
              trCustomer("col8") = Configuration.FormatToString(CDec(supplierRow("ReceiveSelection")), DigitConfig.Price)
              sumReceiveAmount += CDec(supplierRow("ReceiveSelection"))
            End If
          End If
          If Not supplierRow.IsNull("EndingBalance") Then
            trCustomer("col9") = Configuration.FormatToString(CDec(supplierRow("EndingBalance")), DigitConfig.Price)
            sumEndingBalance += CDec(supplierRow("EndingBalance"))
          End If

          If Not supplierRow.IsNull("OPBRetention") Then
            trCustomer("col10") = Configuration.FormatToString(CDec(supplierRow("OPBRetention")), DigitConfig.Price)
            sumOPBRetention += CDec(supplierRow("OPBRetention"))
          End If
          If Not supplierRow.IsNull("Retention") Then
            trCustomer("col11") = Configuration.FormatToString(CDec(supplierRow("Retention")), DigitConfig.Price)
            sumRetention += CDec(supplierRow("Retention"))
          End If
          If Not supplierRow.IsNull("DecreaseRetention") Then
            trCustomer("col12") = Configuration.FormatToString(CDec(supplierRow("DecreaseRetention")), DigitConfig.Price)
            sumDecreaseRetention += CDec(supplierRow("DecreaseRetention"))
          End If
          If Not supplierRow.IsNull("EndingBalanceRetention") Then
            trCustomer("col13") = Configuration.FormatToString(CDec(supplierRow("EndingBalanceRetention")), DigitConfig.Price)
            sumEndingBalanceRetention += CDec(supplierRow("EndingBalanceRetention"))
          End If
          If Not supplierRow.IsNull("ReceiveRetention") Then
            trCustomer("col14") = Configuration.FormatToString(CDec(supplierRow("ReceiveRetention")), DigitConfig.Price)
            sumReceiveRetention += CDec(supplierRow("ReceiveRetention"))
          End If
        End If


        If CInt(Me.Filters(7).Value) <> 0 Then
          trCustomer.State = RowExpandState.Expanded

          For Each detailRow As DataRow In dt2.Select("Customer =" & supplierRow("Cust_ID").ToString)
            Dim deh As New DataRowHelper(detailRow)

            If Not trCustomer Is Nothing Then
              trDetail = trCustomer.Childs.Add

              rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDetail) + 1
              m_hashData(rowIndex) = detailRow

              trDetail("col0") = indent & deh.GetValue(Of String)("entity_description", "-")
              trDetail("col1") = indent & deh.GetValue(Of String)("doccode", "-")
              trDetail("col2") = indent & deh.GetValue(Of Date)("docdate", Now.Date).ToShortDateString
              trDetail("col3") = indent & deh.GetValue(Of String)("glcode", "-")
              trDetail("col4") = indent & deh.GetValue(Of String)("CostCenter")
              trDetail("col5") = Configuration.FormatToString(deh.GetValue(Of Decimal)("OpeningBalance"), DigitConfig.Price)

              If Not detailRow.IsNull("Amount") Then
                If CDec(detailRow("Amount")) > 0 Then
                  trDetail("col6") = Configuration.FormatToString(CDec(detailRow("Amount")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("SCN") Then
                If CDec(detailRow("SCN")) > 0 Then
                  trDetail("col7") = Configuration.FormatToString(CDec(detailRow("SCN")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("ReceiveSelection") Then
                If CDec(detailRow("ReceiveSelection")) <> 0 Then
                  trDetail("col8") = Configuration.FormatToString(CDec(detailRow("ReceiveSelection")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("EndingBalance") Then
                trDetail("col9") = Configuration.FormatToString(CDec(detailRow("EndingBalance")), DigitConfig.Price)
              End If

              If Not detailRow.IsNull("OPBRetention") Then
                trDetail("col10") = Configuration.FormatToString(CDec(detailRow("OPBRetention")), DigitConfig.Price)
              End If
              If Not detailRow.IsNull("Retention") Then
                If CDec(detailRow("Retention")) <> 0 Then
                  trDetail("col11") = Configuration.FormatToString(CDec(detailRow("Retention")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("DecreaseRetention") Then
                If CDec(detailRow("DecreaseRetention")) <> 0 Then
                  trDetail("col12") = Configuration.FormatToString(CDec(detailRow("DecreaseRetention")), DigitConfig.Price)
                End If
              End If
              If Not detailRow.IsNull("EndingBalanceRetention") Then
                trDetail("col13") = Configuration.FormatToString(CDec(detailRow("EndingBalanceRetention")), DigitConfig.Price)
              End If
              If Not detailRow.IsNull("ReceiveRetention") Then
                If CDec(detailRow("ReceiveRetention")) <> 0 Then
                  trDetail("col14") = Configuration.FormatToString(CDec(detailRow("ReceiveRetention")), DigitConfig.Price)
                End If
              End If

              trDetail("col15") = detailRow("Glnote").ToString

              trDetail("col16") = detailRow("vatcode").ToString

            End If
          Next
        End If
      Next

      trCustomer = Me.Treemanager.Treetable.Childs.Add
      If CInt(Me.Filters(7).Value) <> 0 Then
        trCustomer.Tag = "Font.Bold"
      End If
      trCustomer("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Total}")  'รวม
      If CInt(Me.Filters(7).Value) = 0 Then
        trCustomer("col4") = Configuration.FormatToString(sumOpenningBalance, DigitConfig.Price)
        If sumAmount > 0 Then
          trCustomer("col5") = Configuration.FormatToString(sumAmount, DigitConfig.Price)
        End If
        If sumSCNAmount > 0 Then
          trCustomer("col6") = Configuration.FormatToString(sumSCNAmount, DigitConfig.Price)
        End If
        If sumReceiveAmount > 0 Then
          trCustomer("col7") = Configuration.FormatToString(sumReceiveAmount, DigitConfig.Price)
        End If
        trCustomer("col8") = Configuration.FormatToString(sumEndingBalance, DigitConfig.Price)

        If sumOPBRetention > 0 Then
          trCustomer("col9") = Configuration.FormatToString(sumOPBRetention, DigitConfig.Price)
        End If
        If sumRetention > 0 Then
          trCustomer("col10") = Configuration.FormatToString(sumRetention, DigitConfig.Price)
        End If
        If sumDecreaseRetention > 0 Then
          trCustomer("col11") = Configuration.FormatToString(sumDecreaseRetention, DigitConfig.Price)
        End If
        trCustomer("col12") = Configuration.FormatToString(sumEndingBalanceRetention, DigitConfig.Price)
        If sumReceiveRetention > 0 Then
          trCustomer("col13") = Configuration.FormatToString(sumReceiveRetention, DigitConfig.Price)
        End If
      Else
        trCustomer("col5") = Configuration.FormatToString(sumOpenningBalance, DigitConfig.Price)
        If sumAmount > 0 Then
          trCustomer("col6") = Configuration.FormatToString(sumAmount, DigitConfig.Price)
        End If
        If sumSCNAmount > 0 Then
          trCustomer("col7") = Configuration.FormatToString(sumSCNAmount, DigitConfig.Price)
        End If
        If sumReceiveAmount > 0 Then
          trCustomer("col8") = Configuration.FormatToString(sumReceiveAmount, DigitConfig.Price)
        End If
        trCustomer("col9") = Configuration.FormatToString(sumEndingBalance, DigitConfig.Price)

        If sumOPBRetention > 0 Then
          trCustomer("col10") = Configuration.FormatToString(sumOPBRetention, DigitConfig.Price)
        End If
        If sumRetention > 0 Then
          trCustomer("col11") = Configuration.FormatToString(sumRetention, DigitConfig.Price)
        End If
        If sumDecreaseRetention > 0 Then
          trCustomer("col12") = Configuration.FormatToString(sumDecreaseRetention, DigitConfig.Price)
        End If
        trCustomer("col13") = Configuration.FormatToString(sumEndingBalanceRetention, DigitConfig.Price)
        If sumReceiveRetention > 0 Then
          trCustomer("col14") = Configuration.FormatToString(sumReceiveRetention, DigitConfig.Price)
        End If
      End If

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

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim iCol As Integer = 16 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

      widths.Add(90)
      widths.Add(180)
      widths.Add(80 * CInt(Me.Filters(7).Value))
      widths.Add(95 * CInt(Me.Filters(7).Value))
      widths.Add(150)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(95)
      widths.Add(105 * CInt(Me.Filters(7).Value))
      widths.Add(180 * CInt(Me.Filters(7).Value))
      widths.Add(180 * CInt(Me.Filters(7).Value))

      For i As Integer = 0 To iCol
        If i = 1 Then
          If CInt(Me.Filters(7).Value) <> 0 Then
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
          If CInt(Me.Filters(7).Value) <> 0 Then
            Select Case i
              Case 0, 1, 2, 3, 4, 15, 16
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
              Case 0, 1
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
        Return "RptARRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptARRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptARRemain"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ListLabel}"
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
          Case "customerstart", "customerend"
            dpiColl.Add(fixDpi)
          Case "costcenterstart", "costcenterend"
            dpiColl.Add(fixDpi)
        End Select
      Next

      Dim startRow As Integer = 2
      Dim i As Integer = 0
      Dim fn As Font

      If CInt(Me.Filters(7).Value) <> 0 Then
        startRow = 3
      End If

      For rowIndex As Integer = startRow To m_grid.RowCount
        If CType(Me.Treemanager.Treetable.Rows(i), TreeRow) Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Else
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If
        For colIndex As Integer = 1 To m_grid.ColCount

          dpi = New DocPrintingItem
          dpi.Mapping = "col" & (colIndex - 1).ToString
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

