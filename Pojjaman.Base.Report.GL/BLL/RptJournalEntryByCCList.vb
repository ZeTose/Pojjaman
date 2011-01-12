Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptJournalEntryByCCList
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
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

#Region "Style"
    Public Shared Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "JournalEntryByCCList"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      'Dim csLineNumber As New TreeTextColumn
      'csLineNumber.MappingName = "LineNumber"
      'csLineNumber.HeaderText = "#" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      'csLineNumber.NullText = ""
      'csLineNumber.Width = 30
      'csLineNumber.DataAlignment = HorizontalAlignment.Center
      'csLineNumber.ReadOnly = True
      'csLineNumber.TextBox.Name = "LineNumber"

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "acct_code"
      csCode.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      csCode.DataAlignment = HorizontalAlignment.Left
      csCode.Alignment = HorizontalAlignment.Left
      csCode.TextBox.Name = "acct_code"
      csCode.ReadOnly = True

      Dim csbook As New TreeTextColumn
      csbook.MappingName = "acct_book"
      csbook.HeaderText = "รว" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csbook.NullText = ""
      csbook.Width = 60
      csbook.DataAlignment = HorizontalAlignment.Left
      csbook.Alignment = HorizontalAlignment.Left
      csbook.TextBox.Name = "acct_book"
      csbook.ReadOnly = True


      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "acct_name"
      csName.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      csName.NullText = ""
      csName.Width = 350
      csName.DataAlignment = HorizontalAlignment.Left
      csName.Alignment = HorizontalAlignment.Left
      csName.TextBox.Name = "acct_name"
      csName.ReadOnly = True

      Dim csDr As New TreeTextColumn
      csDr.MappingName = "dr"
      csDr.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitPriceHeaderText}")
      csDr.NullText = ""
      csDr.Width = 100
      csDr.DataAlignment = HorizontalAlignment.Right
      csDr.Format = "#,###.##"
      csDr.TextBox.Name = "Dr"
      csDr.ReadOnly = True

      Dim csCr As New TreeTextColumn
      csCr.MappingName = "cr"
      csCr.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitPriceHeaderText}")
      csCr.NullText = ""
      csCr.Width = 100
      csCr.DataAlignment = HorizontalAlignment.Right
      csCr.Format = "#,###.##"
      csCr.TextBox.Name = "Cr"
      csCr.ReadOnly = True

      Dim csBal As New TreeTextColumn
      csBal.MappingName = "bal"
      csBal.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitPriceHeaderText}")
      csBal.NullText = ""
      csBal.Width = 100
      csBal.DataAlignment = HorizontalAlignment.Right
      csBal.Format = "#,###.##"
      csBal.TextBox.Name = "bal"
      csBal.ReadOnly = True

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "description"
      csDescription.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csDescription.NullText = ""
      csDescription.Width = 200
      csDescription.DataAlignment = HorizontalAlignment.Left
      csDescription.TextBox.Name = "description"
      csDescription.ReadOnly = True

      Dim csRowType As New TreeTextColumn
      csRowType.MappingName = "rowType"
      csRowType.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitPriceHeaderText}")
      csRowType.NullText = ""
      csRowType.Width = 0
      csRowType.TextBox.Name = "rowType"
      csRowType.ReadOnly = True

      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csbook)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csDr)
      dst.GridColumnStyles.Add(csCr)
      dst.GridColumnStyles.Add(csBal)
      dst.GridColumnStyles.Add(csRowType)

      Return dst
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("JournalEntryByCCList")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      'myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("acct_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("acct_book", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("acct_name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("dr", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("cr", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("bal", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("rowType", GetType(String)))

      Return myDatatable
    End Function
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      'Dim indent As String = Space(5)
      ' Level 1.
      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("acct_code") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctCode}") '"รหัสบัญชี"
      tr("acct_book") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.BookCode}") '"รหัสบัญชี"
      tr("acct_name") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctName}") '"ชื่อบัญชี"
      tr("description") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.Description}") '"ประเภทเอกสาร"
      tr("Dr") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Debit}") '"จำนวนเงิน"
      tr("Cr") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Credit}") '"จำนวนเงิน"
      tr("bal") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPGL.Remain}") '"จำนวนเงิน"
      ' Level 2.
      'tr = Me.m_treemanager.Treetable.Childs.Add
      'tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DocDate}") '"วันที่เอกสาร"
      'tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.DocCode}") '"เลขที่เอกสาร"
      'tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.RefDocCode}") '"เลขที่เอกสารอ้างอิง"
      'tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.PVRVCode}") '"เลขที่ใบสำคัญรับ/จ่าย"
      'tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.AcctBookName}") '"สมุดรายวัน"
      'tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Detail}") '"รายละเอียด/คำอธิบาย"
      'tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Debit}") '"เดบิต"
      'tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Credit}") '"เครดิต"
      'tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.Balance}") '"ยอดคงเหลือ"
      'tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.CostCenter}") '"CC"
      'tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntry.ItemNote}") '"หมายเหตุรายการ"
      'tr("col11") = "id"
      'tr("col12") = "type"
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return RptJournalEntryByCCList.GetSchemaTable 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return RptJournalEntryByCCList.CreateTableStyle 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      'lkg.HideHead = True
      'lkg.Cols.FrozenCount = 2
      'm_grid.Model.Cols.Hidden(m_grid.ColCount) = True
      lkg.Rows.HeaderCount = 1
      lkg.Rows.FrozenCount = 1
      lkg.HilightGroupParentText = True
      lkg.RefreshHeights()
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      'If m_cc Is Nothing OrElse Not m_cc.Originated Then
      '  Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '  dt.Clear()
      '  tm.Treetable = dt
      '  Return
      'End If
      'If m_cc.BoqId = 0 Then
      '  Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '  dt.Clear()
      '  tm.Treetable = dt
      '  Return
      'End If
      'If TypeOf Me.Filters(1).Value Is Date Then
      'Dim nodigit As Boolean = False
      'If Me.Filters(5).Name.ToLower = "nodigit" Then
      '  nodigit = CBool(Me.Filters(5).Value)
      'End If
      CreateHeader()
      PopulateData()
      'End If
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
      Dim tr As Object = m_hashData(e.RowIndex)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is DataRowHelper Then
        Dim drh As DataRowHelper = CType(tr, DataRowHelper)

        Dim docId As Integer = drh.GetValue(Of Integer)("gl_refid")
        Dim docType As Integer = drh.GetValue(Of Integer)("gl_refdoctype")

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
        End If
      End If
    End Sub

    Public Sub PopulateData()
      If Me.m_treemanager Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treemanager.Treetable

      Dim dgt As DigitConfig = DigitConfig.Price
      'If noDigit Then
      '  dgt = DigitConfig.Int
      'End If
      'dt.Clear()
      Dim showTreeParent As Boolean = False
      Dim showAllAccount As Boolean = False
      Dim showDocument As Boolean = False
      Dim ccCodeStartFilter As String = ""
      Dim ccCodeEndFilter As String = ""

      If Not Me.Filters(8).Value.Equals(DBNull.Value) Then
        showTreeParent = CType(Me.Filters(8).Value, Boolean)
      End If
      If Not Me.Filters(10).Value.Equals(DBNull.Value) Then
        showDocument = CType(Me.Filters(10).Value, Boolean)
      End If
      If Not Me.Filters(6).Value.Equals(DBNull.Value) Then
        ccCodeStartFilter = CType(Me.Filters(6).Value, String)
      End If

      If Not Me.Filters(7).Value.Equals(DBNull.Value) Then
        ccCodeEndFilter = CType(Me.Filters(7).Value, String)
      End If

      Dim dt2 As DataTable = Me.DataSet.Tables(0)
      Dim dtacctcc As DataTable = Me.DataSet.Tables(2)
      Dim dtdoc As DataTable = Me.DataSet.Tables(3)
      
      Dim dt5 As DataTable = CostCenter.GetCostCenterSet
      Dim ccDataSource As DataTable = SetDataSourceFiltered(dt5, "cc_code", ccCodeStartFilter, ccCodeEndFilter)
      Dim newCChash As New Hashtable

      For Each ccRow As DataRow In ccDataSource.Rows
        Dim drh As New DataRowHelper(ccRow)
        newCChash(drh.GetValue(Of Integer)("cc_id")) = drh
      Next

      If dt2.Rows.Count <= 0 Then
        Return
      End If

      '#######################################################################################################
      '#######################################################################################################
      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing
      Dim childNode As TreeRow = Nothing
      Dim docNode As TreeRow = Nothing
      Dim acctId As Integer = 0
      Dim ccId As Integer = 0
      Dim indent As String = Space(2)
      Dim tr As TreeRow

      Dim ccHash As New Hashtable
      Dim key As String = ""

      Dim Bal As Decimal = 0
      Dim coeff As Decimal = 1

      m_hashData = New Hashtable
      Dim trIndex As Integer = 0

      Try

        If Not showTreeParent Then

          For Each acctRow As DataRow In dt2.Rows
            tr = dt.Childs.Add
            tr("acct_code") = acctRow("acct_code")            '
            tr("acct_name") = acctRow("acct_name")
            tr("rowType") = "account"
            If Not acctRow.IsNull("acct_id") Then
              acctId = CInt(acctRow("acct_id"))
            End If
            tr.State = RowExpandState.Expanded

            If showDocument Then
              For Each acctccrow As DataRow In dtacctcc.Select("gli_acct=" & acctId.ToString)
                Dim drh As New DataRowHelper(acctccrow)
                ccId = drh.GetValue(Of Integer)("gli_cc")
                key = drh.GetValue(Of String)("key")

                childNode = tr.Childs.Add
                childNode("acct_code") = indent & CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_code")
                childNode("acct_name") = CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_name")
               
                childNode("rowType") = "costcenter"
                ccHash(key) = childNode
                childNode.State = RowExpandState.Expanded
                'แสดงตามเครื่องหมายตามหมวดบัญชี
                coeff = drh.GetValue(Of Decimal)("coeff", 1)
                Bal = drh.GetValue(Of Decimal)("BfDR") - drh.GetValue(Of Decimal)("BfCr")

                'บรรทัดยกมา
                If Bal <> 0 Then
                  docNode = childNode.Childs.Add
                  trIndex = Me.m_treemanager.Treetable.Rows.IndexOf(docNode) + 1
                  m_hashData(trIndex) = drh
                  docNode("acct_name") = "ยกมา"
                  If Bal > 0 Then
                    docNode("Dr") = Configuration.FormatToString(coeff * Bal, DigitConfig.Price)
                  Else
                    docNode("Cr") = Configuration.FormatToString(coeff * Bal, DigitConfig.Price)
                  End If
                  docNode("rowType") = "document"
                End If

                Bal = coeff * Bal
                docNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price)

                For Each docrow As DataRow In dtdoc.Select("key= '" & key & "'")
                  Dim docrh As New DataRowHelper(docrow)
                  docNode = childNode.Childs.Add
                  trIndex = Me.m_treemanager.Treetable.Rows.IndexOf(docNode) + 1
                  m_hashData(trIndex) = docrh
                  docNode("acct_code") = indent & indent & docrh.GetValue(Of Date)("gl_refdate").ToShortDateString
                  docNode("acct_book") = docrh.GetValue(Of String)("accountbook_prefix")
                  docNode("acct_name") = docrh.GetValue(Of String)("gl_refcode")
                  docNode("description") = docrh.GetValue(Of String)("gli_note")
                  docNode("Dr") = Configuration.FormatToString(docrh.GetValue(Of Decimal)("DocDR"), DigitConfig.Price) 'indent & indent & docdrh.GetValue(Of String)("entity_description")
                  docNode("Cr") = Configuration.FormatToString(docrh.GetValue(Of Decimal)("DocCr"), DigitConfig.Price) 'indent & indent & docdrh.GetValue(Of String)("entity_description")
                  Bal = docrh.GetValue(Of Decimal)("Period") + Bal
                  docNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price) 'indent & indent & docdrh.GetValue(Of String)("entity_description")
                  docNode("rowType") = "document"
                Next

                childNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price)

              Next
            Else
              For Each glirow As DataRow In dtacctcc.Select("gli_acct = " & acctId.ToString)
                Dim drh As New DataRowHelper(glirow)
                ccId = drh.GetValue(Of Integer)("gli_cc")
                If ccId > 0 Then
                  childNode = tr.Childs.Add
                  childNode("acct_code") = indent & CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_code")
                  childNode("acct_name") = CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_name")
                  coeff = drh.GetValue(Of Decimal)("coeff", 1)
                  Bal = drh.GetValue(Of Decimal)("BfDR") - drh.GetValue(Of Decimal)("BfCr")
                  Bal = coeff * Bal
                  childNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price)
                  childNode("rowType") = "costcenter"
                End If
              Next
            End If
          Next
        Else

          For Each acctRow As DataRow In dt2.Rows

            If CInt(acctRow("acct_level")) = 0 Then
              parentNode = dt.Childs.Add
            Else
              myParent = acctRow("Parent")
              Try
                parentNode = Nodes(myParent).Childs.Add
              Catch ex As Exception

              End Try
            End If

            If Not parentNode Is Nothing Then
              Nodes(CStr(acctRow("acct_path"))) = parentNode
              tr = parentNode
              tr("acct_code") = acctRow("acct_code")            '
              tr("acct_name") = acctRow("acct_name")
              tr("rowType") = "account"
              If Not acctRow.IsNull("acct_id") Then
                acctId = CInt(acctRow("acct_id"))
              End If
              tr.State = RowExpandState.Expanded

              If Not tr Is Nothing Then
                If showDocument Then
                  For Each acctccrow As DataRow In dtacctcc.Select("gli_acct=" & acctId.ToString)
                    Dim drh As New DataRowHelper(acctccrow)
                    ccId = drh.GetValue(Of Integer)("gli_cc")
                    key = drh.GetValue(Of String)("key")

                    childNode = tr.Childs.Add
                    childNode("acct_code") = indent & CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_code")
                    childNode("acct_name") = CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_name")

                    childNode("rowType") = "costcenter"
                    ccHash(key) = childNode
                    childNode.State = RowExpandState.Expanded
                    'แสดงตามเครื่องหมายตามหมวดบัญชี
                    coeff = drh.GetValue(Of Decimal)("coeff", 1)
                    Bal = drh.GetValue(Of Decimal)("BfDR") - drh.GetValue(Of Decimal)("BfCr")

                    'บรรทัดยกมา
                    If Bal <> 0 Then
                      docNode = childNode.Childs.Add
                      trIndex = Me.m_treemanager.Treetable.Rows.IndexOf(docNode) + 1
                      m_hashData(trIndex) = drh
                      docNode("acct_name") = "ยกมา"
                      If Bal > 0 Then
                        docNode("Dr") = Configuration.FormatToString(coeff * Bal, DigitConfig.Price)
                      Else
                        docNode("Cr") = Configuration.FormatToString(coeff * Bal, DigitConfig.Price)
                      End If
                      docNode("rowType") = "document"
                    End If

                    Bal = coeff * Bal
                    docNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price)

                    For Each docrow As DataRow In dtdoc.Select("key= '" & key & "'")
                      Dim docrh As New DataRowHelper(docrow)
                      docNode = childNode.Childs.Add
                      trIndex = Me.m_treemanager.Treetable.Rows.IndexOf(docNode) + 1
                      m_hashData(trIndex) = docrh
                      docNode("acct_code") = indent & indent & docrh.GetValue(Of Date)("gl_refdate").ToShortDateString
                      docNode("acct_book") = docrh.GetValue(Of String)("accountbook_prefix")
                      docNode("acct_name") = docrh.GetValue(Of String)("gl_refcode")
                      docNode("description") = docrh.GetValue(Of String)("gli_note")
                      docNode("Dr") = Configuration.FormatToString(docrh.GetValue(Of Decimal)("DocDR"), DigitConfig.Price) 'indent & indent & docdrh.GetValue(Of String)("entity_description")
                      docNode("Cr") = Configuration.FormatToString(docrh.GetValue(Of Decimal)("DocCr"), DigitConfig.Price) 'indent & indent & docdrh.GetValue(Of String)("entity_description")
                      Bal = docrh.GetValue(Of Decimal)("Period") + Bal
                      docNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price) 'indent & indent & docdrh.GetValue(Of String)("entity_description")
                      docNode("rowType") = "document"
                    Next

                    childNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price)

                  Next

                Else
                  For Each glirow As DataRow In dtacctcc.Select("gli_acct = " & acctId.ToString)
                    Dim drh As New DataRowHelper(glirow)
                    ccId = drh.GetValue(Of Integer)("gli_cc")
                    If ccId > 0 Then
                      childNode = tr.Childs.Add
                      childNode("acct_code") = indent & CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_code")
                      childNode("acct_name") = CType(newCChash(ccId), DataRowHelper).GetValue(Of String)("cc_name")
                      coeff = drh.GetValue(Of Decimal)("coeff", 1)
                      Bal = drh.GetValue(Of Decimal)("BfDR") - drh.GetValue(Of Decimal)("BfCr")
                      Bal = coeff * Bal
                      childNode("Bal") = Configuration.FormatToString(Bal, DigitConfig.Price)
                      childNode("rowType") = "costcenter"
                    End If
                  Next

                End If

              End If
            End If
          Next
        End If

        Dim i As Integer = 0
        'For Each row As DataRow In dt.Rows
        '  i += 1
        '  row("boqi_linenumber") = i
        'Next
        'm_hashData = New Hashtable
        For Each row As TreeRow In dt.Rows
          i += 1
          'row("linenumber") = i
          'If Not row.Tag Is Nothing Then
          '  m_hashData(i) = row.Tag
          'End If
        Next

        If i > 0 Then
          dt.AcceptChanges()
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

    End Sub
    Private Function SetDataSourceFiltered(ByVal dt As DataTable, ByVal columnSource As String, ByVal codestart As String, ByVal codeend As String) As DataTable
      Dim newdt As New DataTable
      Dim filterString As String = ""

      If codestart.Length = 0 AndAlso codeend.Length = 0 Then
        Return dt
      ElseIf codestart.Length > 0 AndAlso codeend.Length = 0 Then
        filterString = columnSource & " >= '" & codestart & "'"
      ElseIf codestart.Length = 0 AndAlso codeend.Length < 0 Then
        filterString = columnSource & " <= '" & codeend & "'"
      Else
        filterString = columnSource & " >= '" & codestart & "' and " & columnSource & " <='" & codeend & "'"
      End If

      For Each dcol As DataColumn In dt.Columns
        newdt.Columns.Add(New DataColumn(dcol.ColumnName))
      Next

      For Each drow As DataRow In dt.Select(filterString)
        Dim newDrow As DataRow = newdt.NewRow

        For Each dcol As DataColumn In dt.Columns
          newDrow(dcol.ColumnName) = drow(dcol.ColumnName)
        Next
        newdt.Rows.Add(newDrow)
      Next

      Return newdt
    End Function

#End Region

#Region "Select Distinct From DataTable"
    'Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
    '    Dim lastValues() As Object
    '    Dim newTable As DataTable

    '    If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
    '        Throw New ArgumentNullException("FieldNames")
    '    End If

    '    lastValues = New Object(FieldNames.Length - 1) {}
    '    newTable = New DataTable

    '    For Each field As String In FieldNames
    '        newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
    '    Next

    '    For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
    '        If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
    '            newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

    '            setLastValues(lastValues, Row, FieldNames)
    '        End If
    '    Next

    '    Return newTable
    'End Function
    Private Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
      Dim areEqual As Boolean = True

      For i As Integer = 0 To fieldNames.Length - 1
        If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
          areEqual = False
          Exit For
        End If
      Next

      Return areEqual
    End Function
    Private Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
      For Each field As String In fieldNames
        newRow(field) = sourceRow(field)
      Next

      Return newRow
    End Function
    Private Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
      For i As Integer = 0 To fieldNames.Length - 1
        lastValues(i) = sourceRow(fieldNames(i))
      Next
    End Sub
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptJournalEntryByCCList"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptJournalEntryByCCList"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptJournalEntryByCCList"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptJournalEntryByCCList.ListLabel}"
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
      Return "RptWBSBudgetUsage"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptWBSBudgetUsage"
    End Function

    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim i As Integer = 0
      Dim r As Integer = 0
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        For j As Integer = 1 To Me.Treemanager.Treetable.Columns.Count - 1
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & j
          dpi.Value = itemRow(Me.Treemanager.Treetable.Columns(j))
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next

        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

