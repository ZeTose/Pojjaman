Option Explicit On
Option Strict On
Imports System.Collections.Generic
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
  Public Class RptSCMovement
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
      'Try
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

      lkg.Rows.HeaderCount = 2
      lkg.Rows.FrozenCount = 2

      lkg.Refresh()
      'Catch ex As Exception
      '  Throw ex
      'Finally
      '  m_grid.EndUpdate()
      'End Try
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

        Dim docId As Integer = drh.GetValue(Of Integer)("refID")
        Dim docType As Integer = drh.GetValue(Of Integer)("entityID")

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
      'm_showDetailInGrid = CInt(Me.Filters(9).Value)
      CreateHeader()
      PopulateData()
    End Sub
    Private Sub CreateHeader()
      If Me.m_treemanager Is Nothing Then
        Return
      End If

      Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DocNumber}")       '"เลขที่เอกสาร"

      tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.scBudget}")       '"SC Budget"
      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.scBudget}")       '"SC Budget"
      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retention}")     '"มัดจำ"      
      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retentionn}")       '"Retention"
      tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DR}")     '"ยอดหัก DR"  '""  

      tr = Me.m_treemanager.Treetable.Childs.Add
      tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.sc_docDate}")        '"วันที่เอกสาร"

      tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.docCode}")       '"เลขที่เอกสาร"
      tr("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.supplierinfo}")      '"ผู้รับเหมา"    
      tr("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.ccinfo}")      '"Cost Center "

      tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmount}") '"เบิก"
      tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountMJ}") '"เบิก"
      tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountRT}") '"หักไว้" 
      tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountDR}") '"เบิก"
      tr("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"  

      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                    {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, 0, 1), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 4, 1, 4), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 6, 1, 8), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 9, 1, 11), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 12, 1, 14), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 15, 1, 17)}) ' _
    End Sub

    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim dt1 As DataTable = Me.DataSet.Tables(1)
      Dim dt2 As DataTable = Me.DataSet.Tables(2)
      Dim dt3 As DataTable = Me.DataSet.Tables(3)
      Dim dt4 As DataTable = Me.DataSet.Tables(4)
      'Dim dt5 As DataTable = Me.DataSet.Tables(5)
      If dt.Rows.Count = 0 Then
        Return
      End If
      Dim IsPreveiewSummary As Boolean
      IsPreveiewSummary = (CInt(Me.Filters(10).Value) = 1)

      Dim currSupplier As String = ""
      Dim currSC As String = ""
      Dim trSubContractor As TreeRow
      Dim trCC As TreeRow

      'Dim trAdvance As TreeRow
      Dim trSC As TreeRow
      Dim trDetail As TreeRow
      Dim trSummary As TreeRow

      Dim DocAmount As Decimal
      Dim scRemain As Decimal
      Dim drRemain As Decimal
      Dim advRemain As Decimal
      Dim retRemain As Decimal

      Dim summarrySCDebt As Decimal
      Dim summarryRetDebt As Decimal
      Dim summarryAdvDebt As Decimal
      Dim index As Integer = 2

      Dim isFirstAdvance As Boolean = False
      Dim isHashChild As Boolean = False

      Dim rowIndex As Integer = 0
      m_hashData = New Hashtable

      Dim subConHash As New Hashtable
      For Each subContRow As DataRow In dt.Rows 'ขึ้น SubContractor ใหม่

        Dim subConDrh As New DataRowHelper(subContRow)
        If Not subConHash.ContainsKey(subConDrh.GetValue(Of Integer)("supplier_id")) Then
          trSubContractor = Me.Treemanager.Treetable.Childs.Add
          index += 1
          trSubContractor.Tag = "Font.Bold"
          trSubContractor("col0") = subConDrh.GetValue(Of String)("SubContractorInfo")
          trSubContractor("col8") = Configuration.FormatToString(subConDrh.GetValue(Of Decimal)("advopeningbalance"), DigitConfig.Price)
          trSubContractor("col10") = Configuration.FormatToString(subConDrh.GetValue(Of Decimal)("advbalance"), DigitConfig.Price)
          trSubContractor.State = RowExpandState.Expanded
          m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(index, 1, index, 2)})

          subConHash(subConDrh.GetValue(Of Integer)("supplier_id")) = trSubContractor
        Else
          trSubContractor = CType(subConHash(subConDrh.GetValue(Of Integer)("supplier_id")), TreeRow)
        End If

        For Each CCrow As DataRow In dt.Select("supplier_id = " & subConDrh.GetValue(Of String)("supplier_id") & " and cc_id = " & subConDrh.GetValue(Of String)("cc_id"))
          Dim ccDrh As New DataRowHelper(CCrow)
          trCC = trSubContractor.Childs.Add
          index += 1
          trCC.Tag = "Font.Bold"
          trCC("col0") = ccDrh.GetValue(Of String)("ccinfo")
          trCC.State = RowExpandState.Expanded
          m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(index, 1, index, 2)})

          For Each scRow As DataRow In dt1.Select("supplier_id = " & ccDrh.GetValue(Of String)("supplier_id") & " and entityId = 289 and cc_id = " & ccDrh.GetValue(Of String)("cc_id")) 'ขึ้น SC ใบใหม่ใน SubContractor เดียวกัน
            Dim scDrh As New DataRowHelper(scRow)

            DocAmount = scDrh.GetValue(Of Decimal)("sc") '- scDrh.GetValue(Of Decimal)("advance") - scDrh.GetValue(Of Decimal)("retention") + scDrh.GetValue(Of Decimal)("dr")

            scRemain = (scDrh.GetValue(Of Decimal)("sc") - scDrh.GetValue(Of Decimal)("sc_debit"))
            drRemain = (scDrh.GetValue(Of Decimal)("dr") - scDrh.GetValue(Of Decimal)("dr_debit"))
            advRemain = (scDrh.GetValue(Of Decimal)("advance") - scDrh.GetValue(Of Decimal)("advance_debit"))
            retRemain = (scDrh.GetValue(Of Decimal)("retention") - scDrh.GetValue(Of Decimal)("retention_debit"))

            summarrySCDebt = scRemain - drRemain - advRemain
            summarryRetDebt = retRemain
            summarryAdvDebt = summarrySCDebt + summarryRetDebt

            trSC = trCC.Childs.Add
            trSC.State = RowExpandState.Expanded
            rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trSC) + 1
            m_hashData(rowIndex) = scRow

            index += 1
            trSC("col0") = scDrh.GetValue(Of Date)("sc_Date").ToShortDateString
            trSC("col1") = scDrh.GetValue(Of String)("Code")
            trSC("col2") = scDrh.GetValue(Of String)("sc_Type")
            trSC("col3") = scDrh.GetValue(Of String)("ccinfo")
            trSC("col4") = Configuration.FormatToString(DocAmount, DigitConfig.Price)
            trSC("col5") = Configuration.FormatToString(scDrh.GetValue(Of Decimal)("sc"), DigitConfig.Price)
            trSC("col8") = Configuration.FormatToString(scDrh.GetValue(Of Decimal)("advance"), DigitConfig.Price)
            trSC("col11") = Configuration.FormatToString(scDrh.GetValue(Of Decimal)("retention"), DigitConfig.Price)
            trSC("col14") = Configuration.FormatToString(scDrh.GetValue(Of Decimal)("dr"), DigitConfig.Price)

            trSC("col7") = Configuration.FormatToString(scRemain, DigitConfig.Price)
            trSC("col10") = Configuration.FormatToString(advRemain, DigitConfig.Price)
            trSC("col13") = Configuration.FormatToString(retRemain, DigitConfig.Price)
            trSC("col16") = Configuration.FormatToString(drRemain, DigitConfig.Price) '***************************

            'm_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
            '                          {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(index, 0, index, 1)})

            For Each childSCRow As DataRow In dt1.Select("supplier_id = " & subContRow("supplier_id").ToString & " and sc_id = " & scRow("sc_id").ToString & " and entityId <> 289" _
                                                         & " and cc_id =" & CCrow("cc_id").ToString)
              Dim newChildSCRow As New DataRowHelper(childSCRow)

              scRemain += (newChildSCRow.GetValue(Of Decimal)("sc") - newChildSCRow.GetValue(Of Decimal)("sc_debit"))
              drRemain += (newChildSCRow.GetValue(Of Decimal)("dr") - newChildSCRow.GetValue(Of Decimal)("dr_debit"))
              advRemain += (newChildSCRow.GetValue(Of Decimal)("advance") - newChildSCRow.GetValue(Of Decimal)("advance_debit"))
              retRemain += (newChildSCRow.GetValue(Of Decimal)("retention") - newChildSCRow.GetValue(Of Decimal)("retention_debit"))

              'DocAmount = newChildSCRow.GetValue(Of Decimal)("sc") - newChildSCRow.GetValue(Of Decimal)("advance") - newChildSCRow.GetValue(Of Decimal)("retention") + newChildSCRow.GetValue(Of Decimal)("dr")

              summarrySCDebt += (drRemain - advRemain)
              summarryRetDebt += retRemain
              summarryAdvDebt += ((drRemain - advRemain) + retRemain)

              trDetail = trSC.Childs.Add
              trDetail.State = RowExpandState.Expanded

              rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDetail) + 1
              m_hashData(rowIndex) = childSCRow

              index += 1
              trDetail("col0") = newChildSCRow.GetValue(Of Date)("sc_Date").ToShortDateString
              trDetail("col1") = newChildSCRow.GetValue(Of String)("Code")
              trDetail("col2") = newChildSCRow.GetValue(Of String)("sc_Type")
              trDetail("col3") = newChildSCRow.GetValue(Of String)("ccinfo")
              'trDetail("col4") = Configuration.FormatToString(DocAmount, DigitConfig.Price)
              trDetail("col5") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("sc"), DigitConfig.Price)
              trDetail("col8") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("advance"), DigitConfig.Price)
              trDetail("col11") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("retention"), DigitConfig.Price)
              trDetail("col14") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("dr"), DigitConfig.Price)
              trDetail("col7") = Configuration.FormatToString(scRemain, DigitConfig.Price)
              trDetail("col10") = Configuration.FormatToString(advRemain, DigitConfig.Price)
              trDetail("col13") = Configuration.FormatToString(retRemain, DigitConfig.Price)
              trDetail("col16") = Configuration.FormatToString(drRemain, DigitConfig.Price) '*************************

              If newChildSCRow.GetValue(Of Integer)("entityID") = 292 Then
                DocAmount = newChildSCRow.GetValue(Of Decimal)("sc_debit") '- newChildSCRow.GetValue(Of Decimal)("advance_debit") - newChildSCRow.GetValue(Of Decimal)("retention_debit") - newChildSCRow.GetValue(Of Decimal)("dr_debit")
                trDetail("col4") = Configuration.FormatToString(DocAmount, DigitConfig.Price)
                trDetail("col6") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("sc_debit"), DigitConfig.Price)
                trDetail("col9") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("advance_debit"), DigitConfig.Price)
                trDetail("col12") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("retention_debit"), DigitConfig.Price)
                trDetail("col15") = Configuration.FormatToString(newChildSCRow.GetValue(Of Decimal)("dr_debit"), DigitConfig.Price)
              End If

              'trDetail("col16") = Configuration.FormatToString(summarrySCDebt, DigitConfig.Price)
              'trDetail("col17") = Configuration.FormatToString(summarryRetDebt, DigitConfig.Price)
              'trDetail("col18") = Configuration.FormatToString(summarryAdvDebt, DigitConfig.Price)
              'trDetail.State = RowExpandState.Expanded
            Next
            '--Summary ตาม เอกสาร-- ====================
            If IsPreveiewSummary Then
              For Each sumSCRow As DataRow In dt2.Select("supplier_id = " & subContRow("supplier_id").ToString & " and sc_id = " & scRow("sc_id").ToString)
                Dim sumSCDrh As New DataRowHelper(sumSCRow)

                trSummary = trSC.Childs.Add

                rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trSummary) + 1
                m_hashData(rowIndex) = sumSCRow

                index += 1
                trSummary("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.SCTotal}") '"รวมตามใบสั่งจ้าง"
                trSummary("col5") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("sc"), DigitConfig.Price)
                trSummary("col6") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("sc_debit"), DigitConfig.Price)
                'trSummary("col6") = Configuration.FormatToString(scRemain, DigitConfig.Price)
                trSummary("col14") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("dr"), DigitConfig.Price)
                trSummary("col15") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("dr_debit"), DigitConfig.Price)
                'trSummary("col10") = Configuration.FormatToString(drRemain, DigitConfig.Price)
                trSummary("col8") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("advance"), DigitConfig.Price)
                trSummary("col9") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("advance_debit"), DigitConfig.Price)
                'trSummary("col12") = Configuration.FormatToString(advRemain, DigitConfig.Price)
                trSummary("col11") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("retention"), DigitConfig.Price)
                trSummary("col12") = Configuration.FormatToString(sumSCDrh.GetValue(Of Decimal)("retention_debit"), DigitConfig.Price)
                'trSummary.State = RowExpandState.Expanded
              Next
            End If
            '--Summary ตาม เอกสาร-- ====================
          Next

          '--Summary ตาม CostCenter-- ====================
          If IsPreveiewSummary Then
            For Each sumCCRow As DataRow In dt3.Select("supplier_id = " & ccDrh.GetValue(Of String)("supplier_id") & " and cc_id = " & ccDrh.GetValue(Of String)("cc_id"))
              Dim sumCCDrh As New DataRowHelper(sumCCRow)

              trSummary = trCC.Childs.Add

              rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trSummary) + 1
              m_hashData(rowIndex) = sumCCRow

              index += 1
              trSummary("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CostCenterTotal}") '"รวมตาม CostCenter"
              trSummary("col5") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("sc"), DigitConfig.Price)
              trSummary("col6") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("sc_debit"), DigitConfig.Price)
              'trSummary("col6") = Configuration.FormatToString(scRemain, DigitConfig.Price)
              trSummary("col14") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("dr"), DigitConfig.Price)
              trSummary("col15") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("dr_debit"), DigitConfig.Price)
              'trSummary("col10") = Configuration.FormatToString(drRemain, DigitConfig.Price)
              trSummary("col8") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("advance"), DigitConfig.Price)
              trSummary("col9") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("advance_debit"), DigitConfig.Price)
              'trSummary("col12") = Configuration.FormatToString(advRemain, DigitConfig.Price)
              trSummary("col11") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("retention"), DigitConfig.Price)
              trSummary("col12") = Configuration.FormatToString(sumCCDrh.GetValue(Of Decimal)("retention_debit"), DigitConfig.Price)
              'trSummary.State = RowExpandState.Expanded
            Next
          End If
          '--Summary ตาม CostCenter-- ====================
        Next

      Next

      '--Summary ตาม Supplier-- ====================
      If IsPreveiewSummary Then
        For Each subconId As Integer In subConHash.Keys
          Dim trSubcontract As TreeRow = CType(subConHash(subconId), TreeRow)

          For Each sumSupplierRow As DataRow In dt4.Select("supplier_id = " & subconId.ToString)
            Dim sumSupplierDrh As New DataRowHelper(sumSupplierRow)

            trSummary = trSubcontract.Childs.Add

            rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trSummary) + 1
            m_hashData(rowIndex) = sumSupplierRow

            index += 1
            trSummary("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.SupplierTotal}") '"รวมตาม SubContractor"
            trSummary("col5") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("sc"), DigitConfig.Price)
            trSummary("col6") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("sc_debit"), DigitConfig.Price)
            'trSummary("col6") = Configuration.FormatToString(scRemain, DigitConfig.Price)
            trSummary("col14") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("dr"), DigitConfig.Price)
            trSummary("col15") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("dr_debit"), DigitConfig.Price)
            'trSummary("col10") = Configuration.FormatToString(drRemain, DigitConfig.Price)
            trSummary("col8") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("advance"), DigitConfig.Price)
            trSummary("col9") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("advance_debit"), DigitConfig.Price)
            'trSummary("col12") = Configuration.FormatToString(advRemain, DigitConfig.Price)
            trSummary("col11") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("retention"), DigitConfig.Price)
            trSummary("col12") = Configuration.FormatToString(sumSupplierDrh.GetValue(Of Decimal)("retention_debit"), DigitConfig.Price)
            'trSummary.State = RowExpandState.Expanded
          Next
        Next
      End If
      '--Summary ตาม Supplier-- ====================

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
      Return Nothing
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

      widths.Add(100)
      widths.Add(120)
      widths.Add(120)
      widths.Add(0)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(100)
      widths.Add(0)

      For i As Integer = 0 To 16
        If i = 0 Then

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
          If i >= 4 AndAlso i <= 16 Then
            cs.DataAlignment = HorizontalAlignment.Right
          Else
            cs.DataAlignment = HorizontalAlignment.Left
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
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptSCMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCMovement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.ListLabel}"
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
      Return "RptSCMovement"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptSCMovement"
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
      For rowIndex As Integer = 3 To m_grid.RowCount
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

        dpi = New DocPrintingItem
        dpi.Mapping = "col12"
        dpi.Value = m_grid(rowIndex, 13).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col13"
        dpi.Value = m_grid(rowIndex, 14).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col14"
        dpi.Value = m_grid(rowIndex, 15).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col15"
        dpi.Value = m_grid(rowIndex, 16).CellValue
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
