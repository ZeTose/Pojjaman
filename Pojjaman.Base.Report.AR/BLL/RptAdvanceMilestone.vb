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
  Public Class RptAdvanceMilestone
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    'Private m_showDetailInGrid As Integer
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
      'If m_showDetailInGrid = 0 Then
      '  lkg.Rows.HeaderCount = 2
      '  lkg.Rows.FrozenCount = 2
      'Else
      lkg.Rows.HeaderCount = 3
      lkg.Rows.FrozenCount = 3
      'End If

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

        Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
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
      'm_showDetailInGrid = CInt(Me.Filters(8).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If



      Dim indent As String = Space(3)

      ' Level 0
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CustID}")  '"รหัสลูกหนี้หนี้"
      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CustName}")  '"ชื่อลูกหนี้"
      ' Level 1
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCCode}")  '"รหัส Cost Center"
      tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCName}")  '"ชื่อ Cost Center"
      'tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLCode}")  '"เลขที่ GL"
      'tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.VatInvoice}")  '"เลขที่ใบกำกับ"
      'tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCCode}")  '"รหัส Cost Center"
      'tr("col5") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.CCName}")  '"ชื่อ Cost Center"
      'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.BeforeTax}")  '"ยอดก่อนภาษี"
      'tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.TaxAmount}") '"เงินภาษี"
      'tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.AfterTax}")  '"รวม"
      'tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.OpenningBalance}")  '"ยอดคงเหลือยกมา"
      'tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.RefDocAmount}")  '"ยอดหักมัดจำ"
      'tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Remaining}")  '"ยอดคงเหลือ"
      'tr("col12") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Status}")  '"สถานะ"
      'tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}")  '"หมายเหตุ"
      ' Level 2
      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.BillICode}")  '"เลขที่เอกสารวางบิล"
      tr("col1") = indent & indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocDate}")  '"วันที่เอกสาร"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLCode}")  '"เลขที่ GL"
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.DocType}")  '"ประเภทเอกสาร"
      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.MilestoneCode}")  '" milestone code"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.Description}")  '"รายการของ milestone"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.AdvanceAmount}")  '"ยอดมัดจำ" 
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.AdvanceAmount}")  '"ยอดหัก" 
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Remain}")  '"คงเหลือ" 
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.ReceiveStatus}")  '"การรับเงิน"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.ReceiveDoc}")  '"เอกสารรับเงิน"

    End Sub
    Private Sub PopulateData()
      Dim dtcc As DataTable = Me.DataSet.Tables(0)
      Dim dtbf As DataTable = Me.DataSet.Tables(1)
      Dim dtDoc As DataTable = Me.DataSet.Tables(2)
      Dim dtRecs As DataTable = Me.DataSet.Tables(3)


      ''ทำ list ของใบรับชำระ
      'Dim dicRecs As New Dictionary(Of Integer, String)
      'Dim recsList As New List(Of String)

      'Dim billId As Integer = -1
      'For Each billRow As DataRow In dtRecs.Rows
      '  Dim brh As New DataRowHelper(billRow)
      '  If billId = brh.GetValue(Of Integer)("receivesi_parentEntity") Then
      '    recsList.Add(brh.GetValue(Of String)("receives_code"))
      '  ElseIf billId = -1 Then
      '    billId = brh.GetValue(Of Integer)("receivesi_parentEntity")
      '    recsList.Add(brh.GetValue(Of String)("receives_code"))
      '  Else
      '    dicRecs.Add(billId, String.Join(",", recsList))
      '    recsList.Clear()
      '    billId = brh.GetValue(Of Integer)("receivesi_parentEntity")
      '    recsList.Add(brh.GetValue(Of String)("receives_code"))
      '  End If
      'Next
      ''ทำ list ของใบรับชำระ
      ''ทำแทนแล้ว
      Dim dicClass As New DictionaryOfJoinStringbyInteger(dtRecs, "receivesi_parentEntity", "receives_code", ",")



      If dtcc.Rows.Count = 0 Then
        Return
      End If

      Dim indent As String = Space(3)

      Dim trCust As TreeRow
      Dim trCC As TreeRow
      Dim trDoc As TreeRow

      Dim totalAdvanceAmount As Decimal = 0

      Dim sumadvrinc As Decimal = 0
      Dim sumadvrrel As Decimal = 0
      Dim advanceRemain As Decimal = 0

      Dim totalBeforeTax As Decimal = 0
      Dim totalTaxAmount As Decimal = 0
      Dim totalAfterTax As Decimal = 0
      Dim totalAdvanceInc As Decimal = 0
      Dim totalAdvanceRel As Decimal = 0
      Dim totalBalance As Decimal = 0

      Dim currentCust As String = ""

      Dim rowIndex As Integer = 0
      m_hashData = New Hashtable

      For Each custRow As DataRow In dtcc.Rows
        Dim curh As New DataRowHelper(custRow)
        If currentCust <> custRow("cust_code").ToString Then
          currentCust = custRow("cust_code").ToString

          trCust = Me.Treemanager.Treetable.Childs.Add
          trCust.Tag = "Font.Bold"
          trCust("col0") = curh.GetValue(Of String)("cust_code")
          trCust("col1") = curh.GetValue(Of String)("cust_name")

          For Each ccRow As DataRow In dtcc.Select("billi_cust=" & curh.GetValue(Of String)("billi_cust").ToString)
            trCC = trCust.Childs.Add
            rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trCC) + 1
            m_hashData(rowIndex) = ccRow

            Dim ccrh As New DataRowHelper(ccRow)

            trCC("col0") = indent & ccrh.GetValue(Of String)("cc_code")
            trCC("col1") = ccrh.GetValue(Of String)("cc_name")

            sumadvrinc = 0
            sumadvrrel = 0
            advanceRemain = 0

            'balance forward
            For Each bfrow As DataRow In dtbf.Select("cc_id=" & ccrh.GetValue(Of Integer)("cc_id").ToString)
              Dim bfrh As New DataRowHelper(bfrow)
              trDoc = trCC.Childs.Add
              trDoc("col3") = "ยกมา"
              advanceRemain = bfrh.GetValue(Of Decimal)("advrBf")
              If advanceRemain > 0 Then
                trDoc("col6") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)
                trDoc("col8") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)
                sumadvrinc = advanceRemain
              ElseIf advanceRemain < 0 Then
                trDoc("col7") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)
                trDoc("col8") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)
                sumadvrrel = -advanceRemain
              End If
            Next


            For Each docRow As DataRow In dtDoc.Select("cc_id=" & ccrh.GetValue(Of Integer)("cc_id").ToString)
              Dim drh As New DataRowHelper(docRow)
              'If Not docRow.IsNull("currentamount") Then
              '  totalAdvanceAmount += CDec(docRow("currentamount"))
              '  totalAdvance += CDec(docRow("currentamount"))
              '  advanceRemain -= CDec(docRow("currentamount"))
              'End If
              Dim curBillId As Integer = drh.GetValue(Of Integer)("billi_id")
              trDoc = trCC.Childs.Add
              rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDoc) + 1
              m_hashData(rowIndex) = docRow
              trDoc("col0") = indent & indent & drh.GetValue(Of String)("billi_code")
              trDoc("col1") = drh.GetValue(Of Date)("billi_docdate").ToShortDateString
              trDoc("col2") = drh.GetValue(Of String)("gl_code")
              trDoc("col3") = drh.GetValue(Of String)("code_description")
              trDoc("col4") = drh.GetValue(Of String)("milestone_code")
              trDoc("col5") = drh.GetValue(Of String)("milestone_name")
              trDoc("col6") = Configuration.FormatToString(drh.GetValue(Of Decimal)("advrInc"), DigitConfig.Price)
              trDoc("col7") = Configuration.FormatToString(drh.GetValue(Of Decimal)("advrRel"), DigitConfig.Price)
                            advanceRemain = advanceRemain + drh.GetValue(Of Decimal)("advrInc")
                            advanceRemain = advanceRemain - drh.GetValue(Of Decimal)("advrRel")
              trDoc("col8") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)
              trDoc("col9") = drh.GetValue(Of String)("recsStatus")
              'If dicRecs.ContainsKey(curBillId) Then
              '  trDoc("col10") = dicRecs.Item(curBillId)
              'Else

              'End If
              If dicClass.ContainsKey(curBillId) Then
                trDoc("col10") = dicClass.GetValue(curBillId)
              Else

              End If

              sumadvrinc += drh.GetValue(Of Decimal)("advrInc")
              sumadvrrel += drh.GetValue(Of Decimal)("advrRel")

            Next

            trCC("col6") = Configuration.FormatToString(sumadvrinc, DigitConfig.Price)
            trCC("col7") = Configuration.FormatToString(sumadvrrel, DigitConfig.Price)
            trCC("col8") = Configuration.FormatToString(advanceRemain, DigitConfig.Price)

            totalAdvanceInc += sumadvrinc
            totalAdvanceRel += sumadvrrel
            totalBalance += advanceRemain

            trCC.State = RowExpandState.Expanded

          Next

          trCust.State = RowExpandState.Expanded

        End If

      Next

      trCust = Me.m_treemanager.Treetable.Childs.Add
      trCust.Tag = "Font.Bold"
      trCust("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARAdvanceReceive.Total}") '"รวม"
      trCust("col6") = Configuration.FormatToString(totalAdvanceInc, DigitConfig.Price)
      trCust("col7") = Configuration.FormatToString(totalAdvanceRel, DigitConfig.Price)
      trCust("col8") = Configuration.FormatToString(totalBalance, DigitConfig.Price)

      'trCust("col10") = Configuration.FormatToString(totalAdvanceInc, DigitConfig.Price)
      'trCust("col11") = Configuration.FormatToString(totalBalance, DigitConfig.Price)

      Return

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
      'myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))

      Return myDatatable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "Report"
      Dim widths As New ArrayList
      Dim iCol As Integer = 10 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

      widths.Add(120)
      widths.Add(100)
      widths.Add(100)
      widths.Add(80)
      widths.Add(100)
      widths.Add(200)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(90)
      widths.Add(300)
      'widths.Add(100)
      'widths.Add(100)
      'widths.Add(300)

      For i As Integer = 0 To iCol
        If i = 1 Then
          'If m_showDetailInGrid <> 0 Then
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
          Dim cs As New TreeTextColumn(i, True, Color.Khaki)
          cs.MappingName = "col" & i
          cs.HeaderText = ""
          cs.Width = CInt(widths(i))
          cs.NullText = ""
          cs.Alignment = HorizontalAlignment.Left
          'If Me.m_showDetailInGrid <> 0 Then
          Select Case i
            Case 0, 1, 2, 3, 4, 5, 9, 10
              cs.Alignment = HorizontalAlignment.Left
              cs.DataAlignment = HorizontalAlignment.Left
              cs.Format = "s"
            Case Else
              cs.Alignment = HorizontalAlignment.Right
              cs.DataAlignment = HorizontalAlignment.Right
              cs.Format = "d"
          End Select

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
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptAdvanceMilestone"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptARAdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptARAdvanceReceive"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptAdvanceMilestone.ListLabel}"
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
      Return "RptAdvanceMilestone"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptAdvanceMilestone"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'docdate start
      dpi = New DocPrintingItem
      dpi.Mapping = "docdatestart"
      If Not IsDBNull(Filters(0).Value) Then
        dpi.Value = CDate((Filters(0).Value)).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'docdate end
      dpi = New DocPrintingItem
      dpi.Mapping = "docdateend"
      If Not IsDBNull(Filters(1).Value) Then
        dpi.Value = CDate((Filters(1).Value)).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'customer start
      dpi = New DocPrintingItem
      dpi.Mapping = "customerstart"
      If Not IsDBNull(Filters(2).Value) Then
        dpi.Value = CStr((Filters(2).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'customer end
      dpi = New DocPrintingItem
      dpi.Mapping = "customerend"
      If Not IsDBNull(Filters(3).Value) Then
        dpi.Value = CStr((Filters(3).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "costcenterstart"
      If Not IsDBNull(Filters(8).Value) Then
        dpi.Value = CStr((Filters(8).Value)).ToString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''CostCenterEnd ยกเลิก
      'dpi = New DocPrintingItem
      'dpi.Mapping = "costcenterend"
      'If Not IsDBNull(Filters(8).Value) Then
      'dpi.Value = CStr((Filters(8).Value)).ToString
      'End If
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'IncludeChildren
      dpi = New DocPrintingItem
      dpi.Mapping = "IncludeChildren"
      If Not IsDBNull(Filters(4).Value) Then
        If CType(Filters(4).Value, Boolean) Then
          dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptARFilterSubPanel.chkIncludeChildren}")
        End If
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      Dim i As Integer = 0
      Dim StartRow As Integer = 4
      Dim fn As Font
      'If Me.m_showDetailInGrid = 0 Then
      '  StartRow = 3
      'Else
      '  StartRow = 4
      'End If

      For rowIndex As Integer = StartRow To m_grid.RowCount
        fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))

        'If Me.m_showDetailInGrid <> 0 Then
        If Not CType(Me.Treemanager.Treetable.Rows(rowIndex - 1), TreeRow).Tag Is Nothing Then
          fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If
        'End If

        For colIndex As Integer = 1 To Me.m_grid.ColCount
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & colIndex.ToString
          dpi.Value = m_grid(rowIndex, colIndex).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpi.Font = fn
          dpiColl.Add(dpi)
        Next

        If rowIndex = m_grid.RowCount Then
          'SumText
          dpi = New DocPrintingItem
          dpi.Mapping = "SumText"
          dpi.Value = m_grid(rowIndex, 4).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumBeforeTax
          dpi = New DocPrintingItem
          dpi.Mapping = "SumBeforeTax"
          dpi.Value = m_grid(rowIndex, 5).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumTaxAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "SumTaxAmount"
          dpi.Value = m_grid(rowIndex, 6).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumAfterTax
          dpi = New DocPrintingItem
          dpi.Mapping = "SumAfterTax"
          dpi.Value = m_grid(rowIndex, 7).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumAdvanceAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "SumAdvanceAmount"
          dpi.Value = m_grid(rowIndex, 9).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)

          'SumBalance
          dpi = New DocPrintingItem
          dpi.Mapping = "SumBalance"
          dpi.Value = m_grid(rowIndex, 10).CellValue
          dpi.DataType = "System.String"
          dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
          dpiColl.Add(dpi)
        End If

        n += 1
      Next


      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

