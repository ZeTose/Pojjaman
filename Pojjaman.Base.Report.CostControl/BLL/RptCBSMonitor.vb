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
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptCBSMonitor
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
    Public Shared Function CreateCBSMonitorTableStyle(ByVal dtcc As DataTable, ByVal Views As String) As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "CBS"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csCBSCode As New TreeTextColumn
      csCBSCode.MappingName = "cbs_code"
      csCBSCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CBSCODEHeaderText}")
      csCBSCode.NullText = ""
      csCBSCode.Width = 30
      csCBSCode.DataAlignment = HorizontalAlignment.Center
      csCBSCode.ReadOnly = True
      csCBSCode.TextBox.Name = "cbs_code"

      Dim csCBSName As New PlusMinusTreeTextColumn
      csCBSName.MappingName = "cbs_Name"
      csCBSName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CNBHeaderText}")
      csCBSName.NullText = ""
      csCBSName.Width = 240
      csCBSName.TextBox.Name = "CBS_name"
      csCBSName.ReadOnly = True

      dst.GridColumnStyles.Add(csCBSCode)
      dst.GridColumnStyles.Add(csCBSName)

      Dim LcsBarrier As New List(Of DataGridBarrierColumn)
      Dim LcsBudget As New List(Of TreeTextColumn)
      Dim LcsActualTotalPR As New List(Of TreeTextColumn)
      Dim LcsPRDiff As New List(Of TreeTextColumn)

      Dim LcsActualTotalPO As New List(Of TreeTextColumn)
      Dim LcsPODiff As New List(Of TreeTextColumn)

      Dim LcsActualTotalGR As New List(Of TreeTextColumn)
      Dim LcsGRDiff As New List(Of TreeTextColumn)

      Dim LcsActualTotalMW As New List(Of TreeTextColumn)
      Dim LcsMWDiff As New List(Of TreeTextColumn)

      For Each ccrow As DataRow In dtcc.Rows
        Dim crh As New DataRowHelper(ccrow)

        Dim cc As String = crh.GetValue(Of Integer)("ccid").ToString


        Dim csBarrier0 As New DataGridBarrierColumn
        csBarrier0.MappingName = "Barrier" & cc
        csBarrier0.HeaderText = ""
        csBarrier0.NullText = ""
        csBarrier0.ReadOnly = True

        Dim csBudget As New TreeTextColumn
        csBudget.MappingName = "BudgetCost" & cc
        csBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BudgetCostHeaderText}")
        csBudget.NullText = ""
        csBudget.DataAlignment = HorizontalAlignment.Right
        csBudget.Format = "#,###.##"
        csBudget.TextBox.Name = "BudgetCost" & cc
        csBudget.ReadOnly = True

        Dim csActualTotalPR As New TreeTextColumn
        csActualTotalPR.MappingName = "ActualPRCost" & cc
        csActualTotalPR.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPRCostHeaderText}")
        csActualTotalPR.NullText = ""
        csActualTotalPR.DataAlignment = HorizontalAlignment.Right
        csActualTotalPR.Format = "#,###.##"
        csActualTotalPR.TextBox.Name = "ActualPRCost" & cc
        csActualTotalPR.ReadOnly = True

        Dim csPRDiff As New TreeTextColumn
        csPRDiff.MappingName = "PRDiff" & cc
        csPRDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        csPRDiff.NullText = ""
        csPRDiff.DataAlignment = HorizontalAlignment.Right
        csPRDiff.Format = "#,###.##"
        csPRDiff.TextBox.Name = "PRDiff" & cc
        csPRDiff.ReadOnly = True

        Dim csActualTotalPO As New TreeTextColumn
        csActualTotalPO.MappingName = "ActualPOCost" & cc
        csActualTotalPO.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPOCostHeaderText}")
        csActualTotalPO.NullText = ""
        csActualTotalPO.DataAlignment = HorizontalAlignment.Right
        csActualTotalPO.Format = "#,###.##"
        csActualTotalPO.TextBox.Name = "ActualPOCost" & cc
        csActualTotalPO.ReadOnly = True

        Dim csPODiff As New TreeTextColumn
        csPODiff.MappingName = "PODiff" & cc
        csPODiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        csPODiff.NullText = ""
        csPODiff.DataAlignment = HorizontalAlignment.Right
        csPODiff.Format = "#,###.##"
        csPODiff.TextBox.Name = "PODiff" & cc
        csPODiff.ReadOnly = True

        Dim csActualTotalGR As New TreeTextColumn
        csActualTotalGR.MappingName = "ActualGRCost" & cc
        csActualTotalGR.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualGRCostHeaderText}")
        csActualTotalGR.NullText = ""
        csActualTotalGR.DataAlignment = HorizontalAlignment.Right
        csActualTotalGR.Format = "#,###.##"
        csActualTotalGR.TextBox.Name = "ActualGRCost" & cc
        csActualTotalGR.ReadOnly = True

        Dim csGRDiff As New TreeTextColumn
        csGRDiff.MappingName = "GRDiff" & cc
        csGRDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        csGRDiff.NullText = ""
        csGRDiff.DataAlignment = HorizontalAlignment.Right
        csGRDiff.Format = "#,###.##"
        csGRDiff.TextBox.Name = "GRDiff" & cc
        csGRDiff.ReadOnly = True

        Dim csActualTotalMW As New TreeTextColumn
        csActualTotalMW.MappingName = "ActualMWCost" & cc
        csActualTotalMW.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
        csActualTotalMW.NullText = ""
        csActualTotalMW.DataAlignment = HorizontalAlignment.Right
        csActualTotalMW.Format = "#,###.##"
        csActualTotalMW.TextBox.Name = "ActualMWCost" & cc
        csActualTotalMW.ReadOnly = True

        Dim csMWDiff As New TreeTextColumn
        csMWDiff.MappingName = "MWDiff" & cc
        csMWDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        csMWDiff.NullText = ""
        csMWDiff.Width = 110
        csMWDiff.DataAlignment = HorizontalAlignment.Right
        csMWDiff.Format = "#,###.##"
        csMWDiff.TextBox.Name = "MWDiff" & cc
        csMWDiff.ReadOnly = True

        LcsBarrier.Add(csBarrier0)
        LcsBudget.Add(csBudget)
        LcsActualTotalPR.Add(csActualTotalPR)
        LcsPRDiff.Add(csPRDiff)
        LcsActualTotalPR.Add(csActualTotalPO)
        LcsPRDiff.Add(csPODiff)
        LcsActualTotalPR.Add(csActualTotalGR)
        LcsPRDiff.Add(csGRDiff)
        LcsActualTotalPR.Add(csActualTotalMW)
        LcsPRDiff.Add(csMWDiff)

        dst.GridColumnStyles.Add(csBarrier0)

        dst.GridColumnStyles.Add(csBudget)

        If Views.Contains("|7|") Then
          dst.GridColumnStyles.Add(csActualTotalPR)
          dst.GridColumnStyles.Add(csPRDiff)
        End If


        If Views.Contains("|6|") Then
          dst.GridColumnStyles.Add(csActualTotalPO)
          dst.GridColumnStyles.Add(csPODiff)
        End If

        If Views.Contains("|45|") Then
          dst.GridColumnStyles.Add(csActualTotalGR)
          dst.GridColumnStyles.Add(csGRDiff)
        End If

        If Views.Contains("|31|") Then
          dst.GridColumnStyles.Add(csActualTotalMW)
          dst.GridColumnStyles.Add(csMWDiff)
        End If

      Next


      'Dim csBarrier0 As New DataGridBarrierColumn
      'csBarrier0.MappingName = "Barrier0"
      'csBarrier0.HeaderText = ""
      'csBarrier0.NullText = ""
      'csBarrier0.ReadOnly = True

      'Dim csBudget As New TreeTextColumn
      'csBudget.MappingName = "Budget"
      'csBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BudgetCostHeaderText}")
      'csBudget.NullText = ""
      'csBudget.DataAlignment = HorizontalAlignment.Right
      'csBudget.Format = "#,###.##"
      'csBudget.TextBox.Name = "Budget"
      'csBudget.ReadOnly = True



      'Dim csActualTotalPR As New TreeTextColumn
      'csActualTotalPR.MappingName = "ActualPRCost"
      'csActualTotalPR.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPRCostHeaderText}")
      'csActualTotalPR.NullText = ""
      'csActualTotalPR.DataAlignment = HorizontalAlignment.Right
      'csActualTotalPR.Format = "#,###.##"
      'csActualTotalPR.TextBox.Name = "ActualPRCost"
      'csActualTotalPR.ReadOnly = True

      'Dim csPRDiff As New TreeTextColumn
      'csPRDiff.MappingName = "PRDiff"
      'csPRDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      'csPRDiff.NullText = ""
      'csPRDiff.DataAlignment = HorizontalAlignment.Right
      'csPRDiff.Format = "#,###.##"
      'csPRDiff.TextBox.Name = "PRDiff"
      'csPRDiff.ReadOnly = True

      'Dim csActualTotalPO As New TreeTextColumn
      'csActualTotalPO.MappingName = "ActualPOCost"
      'csActualTotalPO.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPOCostHeaderText}")
      'csActualTotalPO.NullText = ""
      'csActualTotalPO.DataAlignment = HorizontalAlignment.Right
      'csActualTotalPO.Format = "#,###.##"
      'csActualTotalPO.TextBox.Name = "ActualPOCost"
      'csActualTotalPO.ReadOnly = True

      'Dim csPODiff As New TreeTextColumn
      'csPODiff.MappingName = "PODiff"
      'csPODiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      'csPODiff.NullText = ""
      'csPODiff.DataAlignment = HorizontalAlignment.Right
      'csPODiff.Format = "#,###.##"
      'csPODiff.TextBox.Name = "PODiff"
      'csPODiff.ReadOnly = True

      'Dim csActualTotalGR As New TreeTextColumn
      'csActualTotalGR.MappingName = "ActualGRCost"
      'csActualTotalGR.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualGRCostHeaderText}")
      'csActualTotalGR.NullText = ""
      'csActualTotalGR.DataAlignment = HorizontalAlignment.Right
      'csActualTotalGR.Format = "#,###.##"
      'csActualTotalGR.TextBox.Name = "ActualGRCost"
      'csActualTotalGR.ReadOnly = True

      'Dim csGRDiff As New TreeTextColumn
      'csGRDiff.MappingName = "GRDiff"
      'csGRDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      'csGRDiff.NullText = ""
      'csGRDiff.DataAlignment = HorizontalAlignment.Right
      'csGRDiff.Format = "#,###.##"
      'csGRDiff.TextBox.Name = "GRDiff"
      'csGRDiff.ReadOnly = True

      'Dim csActualTotalMW As New TreeTextColumn
      'csActualTotalMW.MappingName = "ActualMWCost"
      'csActualTotalMW.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      'csActualTotalMW.NullText = ""
      'csActualTotalMW.DataAlignment = HorizontalAlignment.Right
      'csActualTotalMW.Format = "#,###.##"
      'csActualTotalMW.TextBox.Name = "ActualMWCost"
      'csActualTotalMW.ReadOnly = True

      'Dim csMWDiff As New TreeTextColumn
      'csMWDiff.MappingName = "MWDiff"
      'csMWDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      'csMWDiff.NullText = ""
      'csMWDiff.Width = 110
      'csMWDiff.DataAlignment = HorizontalAlignment.Right
      'csMWDiff.Format = "#,###.##"
      'csMWDiff.TextBox.Name = "MWDiff"
      'csMWDiff.ReadOnly = True




      'dst.GridColumnStyles.Add(csCBSCode)
      'dst.GridColumnStyles.Add(csCBSName)



      Return dst
    End Function
    Public Shared Function GetCBSMonitorSchemaTable(ByVal dtcc As DataTable) As TreeTable
      Dim myDatatable As New TreeTable("CBS")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("cbs_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("cbs_name", GetType(String)))

      For Each ccrow As DataRow In dtcc.Rows
        Dim crh As New DataRowHelper(ccrow)

        Dim cc As String = crh.GetValue(Of Integer)("ccid").ToString
        myDatatable.Columns.Add(New DataColumn("Barrier" & cc, GetType(String)))

        myDatatable.Columns.Add(New DataColumn("BudgetCost" & cc, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("ActualPRCost" & cc, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("PRDiff" & cc, GetType(String)))


        myDatatable.Columns.Add(New DataColumn("ActualPOCost" & cc, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("PODiff" & cc, GetType(String)))


        myDatatable.Columns.Add(New DataColumn("ActualGRCost" & cc, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("GRDiff" & cc, GetType(String)))


        myDatatable.Columns.Add(New DataColumn("ActualMWCost" & cc, GetType(String)))
        myDatatable.Columns.Add(New DataColumn("MWDiff" & cc, GetType(String)))
      Next


      Return myDatatable
    End Function

    Private Sub CreateHeader(ByVal dt As TreeTable)
      If dt Is Nothing Then
        Return
      End If

      dt.Clear()


      Dim trcc As TreeRow = dt.Childs.Add
      trcc("cbs_code") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CBSCODEHeaderText}")       '"CBS Code"
      trcc("cbs_name") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CNBHeaderText}")       '"CBS NAME"

      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                    {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 2, 2), _
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 3, 2, 3)}) ' _


      Dim trDetail As TreeRow = dt.Childs.Add
      Dim i As Integer = 5
      ' 10 Col per cc

      For Each ccrow As DataRow In dtcc.Rows
        Dim crh As New DataRowHelper(ccrow)


        Dim cc As String = crh.GetValue(Of Integer)("ccid").ToString
        trcc("BudgetCost" & cc) = crh.GetValue(Of String)("cc_code") & ":" & crh.GetValue(Of String)("cc_name")

        trDetail("BudgetCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BudgetCostHeaderText}")
        trDetail("ActualPRCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPRCostHeaderText}")
        trDetail("PRDiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        trDetail("ActualPOCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPOCostHeaderText}")
        trDetail("PODiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        trDetail("ActualGRCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualGRCostHeaderText}")
        trDetail("GRDiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        trDetail("ActualMWCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
        trDetail("MWDiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
        'Dim csBarrier0 As New DataGridBarrierColumn
        'csBarrier0.MappingName = "Barrier" & cc
        'csBarrier0.HeaderText = ""
        'csBarrier0.NullText = ""
        'csBarrier0.ReadOnly = True

        m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                    {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, i, 1, i + 8)}) ' _

        i += 10
      Next


      'trcc("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.scBudget}")       '"SC Budget"
      'trcc("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retention}")     '"มัดจำ"      
      'trcc("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Retentionn}")       '"Retention"
      'trcc("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DR}")     '"ยอดหัก DR"  '""  

      'trcc = Me.m_treemanager.Treetable.Childs.Add
      'trcc("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.sc_docDate}")        '"วันที่เอกสาร"

      'trcc("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.docCode}")       '"เลขที่เอกสาร"
      'trcc("col2") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.supplierinfo}")      '"ผู้รับเหมา"    
      'trcc("col3") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.ccinfo}")      '"Cost Center "

      'trcc("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmount}") '"เบิก"
      'trcc("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      'trcc("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountMJ}") '"เบิก"
      'trcc("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      'trcc("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountRT}") '"หักไว้" 
      'trcc("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"

      'trcc("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.DebitAmount}") '"ตั้ง"
      'trcc("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.CreditAmountDR}") '"เบิก"
      'trcc("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptSCMovement.Balance}") '"คงเหลือ"  

      'm_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
      '                              {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 1, 0, 1), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 1, 1, 1), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(0, 4, 1, 4), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 6, 1, 8), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 9, 1, 11), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 12, 1, 14), _
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 15, 1, 17)}) ' _
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return RptCBSMonitor.GetCBSMonitorSchemaTable(Nothing) 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return RptCBSMonitor.CreateCBSMonitorTableStyle(Nothing, "") 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Private dtcc As DataTable
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick

      dtcc = Me.DataSet.Tables(0)

      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetCBSMonitorSchemaTable(dtcc), New TreeGrid)
      ListInGrid(tm)


      lkg.TreeTableStyle = CreateCBSMonitorTableStyle(dtcc, CStr(Me.Filters(4).Value))
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 2
      lkg.Rows.FrozenCount = 2
      lkg.Cols.FrozenCount = 3
      'm_grid.Model.Cols.Hidden(m_grid.ColCount) = True
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

      'End If
      Dim nodigit As Boolean = False
      If Me.Filters(3).Name.ToLower = "nodigit" Then
        nodigit = CBool(Me.Filters(3).Value)
      End If
      CreateHeader(tm.Treetable)
      PopulateCBSMonitorListing(tm.Treetable, nodigit)
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      Dim tr As Object = m_hashData(e.RowIndex)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is DataRow Then
        Dim dr As DataRow = CType(tr, DataRow)
        Dim drh As New DataRowHelper(dr)

        Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
        Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
        End If
      End If


      'If IsNumeric(m_grid(e.RowIndex, m_grid.ColCount).CellValue) Then
      '  Dim docId As Integer
      '  Dim docType As Integer
      '  docType = 6
      '  docId = CInt(m_grid(e.RowIndex, m_grid.ColCount).CellValue)
      '  If docId <> 0 Then
      '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      '    myEntityPanelService.OpenDetailPanel(en)
      '  End If
      'End If
    End Sub
    Private dicdata As Dictionary(Of String, CBSAmount)
    Private Class CBSAmount
      Sub New(ByVal drh As DataRowHelper)
        CCID = drh.GetValue(Of Integer)("ccid")
        CBS = drh.GetValue(Of Integer)("cbs")
        Budget = drh.GetValue(Of Decimal)("Budget")
        PRActual = drh.GetValue(Of Decimal)("practual")
        POActual = drh.GetValue(Of Decimal)("poactual")
        GRActual = drh.GetValue(Of Decimal)("gractual")
        MWActual = drh.GetValue(Of Decimal)("mwactual")
      End Sub
      Public Property CCID As Integer
      Public Property CBS As Integer
      Public Property Budget As Decimal
      Public Property PRActual As Decimal
      Public Property POActual As Decimal
      Public Property GRActual As Decimal
      Public Property MWActual As Decimal
    End Class
    Public Sub PopulateCBSMonitorListing(ByVal dt As TreeTable, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      'Dim dtcc As DataTable = Me.DataSet.Tables(0)
      Dim dtcbs As DataTable = Me.DataSet.Tables(1)
      'Dim dtMarkUp As DataTable = Me.DataSet.Tables(2)
      Dim dtdata As DataTable = Me.DataSet.Tables(2)
      dtcbs.TableName = "Table0"
      'dtMarkUp.TableName = "Table1"
      dtdata.TableName = "Table1"
      If dtcbs.Rows.Count <= 0 Then
        Return
      End If

      dicdata = New Dictionary(Of String, CBSAmount)

      For Each row As DataRow In dtdata.Rows
        Dim drh As New DataRowHelper(row)
        Dim key As String = drh.GetValue(Of Integer)("ccid").ToString & "|" & drh.GetValue(Of Integer)("cbs").ToString
        Dim ca As New CBSAmount(drh)
        dicdata.Add(key, ca)
      Next



      ' Cbs ##################################################################################################
      '#######################################################################################################
      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing
      Dim myTempId As Integer = 0

      Dim tr As TreeRow
      Dim stage As String = ""
      Try
        'แบบไม่เลือก Option WBS 
        For Each cbsrow As DataRow In dtcbs.Rows
          Dim cbrh As New DataRowHelper(cbsrow)
          If CInt(cbsrow("cbs_level")) = 0 Then
            parentNode = dt.Childs.Add

          Else
            myParent = cbsrow("Parent")
            Try
              parentNode = Nodes(myParent).Childs.Add
            Catch ex As Exception

            End Try
          End If

          If Not parentNode Is Nothing Then
            Nodes(CStr(cbsrow("cbs_path"))) = parentNode

            'แสดงแต่ละ wbs
            tr = parentNode
            tr.Tag = cbsrow
            tr("cbs_code") = cbsrow("cbs_code")
            tr("cbs_name") = cbsrow("cbs_name")
            '
            Dim cbs As String = cbrh.GetValue(Of Integer)("cbs_id").ToString

            For Each ccrow As DataRow In dtcc.Rows
              Dim ccrh As New DataRowHelper(ccrow)

              Dim cc As String = ccrh.GetValue(Of Integer)("ccid")

              If dicdata.ContainsKey(cc & "|" & cbs) Then
                tr("BudgetCost" & cc) = Configuration.FormatToString(dicdata(cc & "|" & cbs).Budget, dgt)
                tr("ActualPRCost" & cc) = Configuration.FormatToString(dicdata(cc & "|" & cbs).PRActual, dgt)
                tr("PRDiff" & cc) = 0

                tr("ActualPOCost" & cc) = Configuration.FormatToString(dicdata(cc & "|" & cbs).POActual, dgt)
                tr("PODiff" & cc) = 0

                tr("ActualGRCost" & cc) = Configuration.FormatToString(dicdata(cc & "|" & cbs).GRActual, dgt)
                tr("GRDiff" & cc) = 0

                tr("ActualMWCost" & cc) = Configuration.FormatToString(dicdata(cc & "|" & cbs).MWActual, dgt)
                tr("MWDiff" & cc) = 0
              End If

            Next


            stage = "1"

            stage = "2"
            tr.State = RowExpandState.Expanded
          End If

          'If detail > 0 Then
          '  Dim DocMatActual As Decimal = 0
          '  Dim DocLabActual As Decimal = 0
          '  Dim DocEqActual As Decimal = 0
          '  Dim DocAmount As Decimal = 0
          '  Dim myDocId As String = ""
          '  Dim Doctr As TreeRow = Nothing
          '  Dim DocItemTr As TreeRow = Nothing
          '  For Each wbsDoc As DataRow In dtdata.Select("wbsid = " & cbsrow("wbs_id") & " and ismarkup = 0")

          '    If Not myDocId = CStr(wbsDoc("DocId")) Then
          '      If Not Doctr Is Nothing Then
          '        Doctr("ActualMaterialCost") = Configuration.FormatToString(DocMatActual, dgt)
          '        Doctr("ActualLaborCost") = Configuration.FormatToString(DocLabActual, dgt)
          '        Doctr("ActualEquipmentCost") = Configuration.FormatToString(DocEqActual, dgt)
          '        Doctr("Actual") = Configuration.FormatToString(DocAmount, dgt)
          '        DocMatActual = 0
          '        DocLabActual = 0
          '        DocEqActual = 0
          '        DocAmount = 0
          '      End If

          '      'แสดงเอกสารแต่ละตัว
          '      tr.State = RowExpandState.Expanded
          '      Doctr = tr.Childs.Add
          '      Doctr.Tag = wbsDoc
          '      Doctr("boqi_itemname") = "(เอกสาร) " & CStr(wbsDoc("DocCode"))
          '      Doctr.State = RowExpandState.None
          '      myDocId = CStr(wbsDoc("DocId"))
          '      Doctr("DocId") = myDocId
          '      Doctr("note") = CStr(wbsDoc("Docnote"))
          '    End If

          '    If detail > 1 Then
          '      'แสดงรายการในแต่ละเอกสาร
          '      If Not Doctr Is Nothing Then
          '        Doctr.State = RowExpandState.Expanded
          '        DocItemTr = Doctr.Childs.Add
          '        DocItemTr("boqi_itemname") = wbsDoc("itemName")
          '        DocItemTr("UnitPrice") = Configuration.FormatToString(CDec(wbsDoc("UnitPrice")), dgt)
          '        DocItemTr("Unit") = IIf(wbsDoc.IsNull("UnitName"), "", wbsDoc("UnitName"))
          '        DocItemTr("ActualQuantity") = Configuration.FormatToString(CDec(wbsDoc("Qty")), dgt)
          '        DocItemTr("ActualMaterialCost") = Configuration.FormatToString(CDec(wbsDoc("MatActual")), dgt)
          '        DocItemTr("ActualLaborCost") = Configuration.FormatToString(CDec(wbsDoc("LabActual")), dgt)
          '        DocItemTr("ActualEquipmentCost") = Configuration.FormatToString(CDec(wbsDoc("EqActual")), dgt)
          '        DocItemTr("Actual") = Configuration.FormatToString(CDec(wbsDoc("Amount")), dgt)
          '        DocItemTr.State = RowExpandState.None
          '        DocItemTr("note") = CStr(wbsDoc("itemnote"))
          '      End If
          '    End If

          '    DocMatActual += CDec(wbsDoc("MatActual"))
          '    DocLabActual += CDec(wbsDoc("LabActual"))
          '    DocEqActual += CDec(wbsDoc("EqActual"))
          '    DocAmount += CDec(wbsDoc("Amount"))
          '  Next
          '  If Not Doctr Is Nothing Then
          '    Doctr("ActualMaterialCost") = Configuration.FormatToString(DocMatActual, dgt)
          '    Doctr("ActualLaborCost") = Configuration.FormatToString(DocLabActual, dgt)
          '    Doctr("ActualEquipmentCost") = Configuration.FormatToString(DocEqActual, dgt)
          '    Doctr("Actual") = Configuration.FormatToString(DocAmount, dgt)
          '  End If
          'End If
        Next

        ''#######################################################################################################

        '' OVER HEAD ############################################################################################
        ''#######################################################################################################
        'Dim SumMarkAmount As Decimal = 0
        'Dim SumActualAmout As Decimal = 0
        'Dim SumTotalDiffAmount As Decimal = 0
        'Dim tmpMarkAmt As Decimal = 0
        'Dim tmpActAmt As Decimal = 0
        'Dim tmpDiffAmt As Decimal = 0
        'Dim overheadTemp As String = ""
        'Dim overheadedtr As TreeRow = Nothing
        'Dim overheadtr As TreeRow = Nothing
        'Dim markuptr As TreeRow = Nothing
        'overheadedtr = dt.Childs.Add
        'overheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
        'If dtMarkUp.Rows.Count > 0 Then
        '  For Each markuprow As DataRow In dtMarkUp.Select("code_tag = 0")
        '    'แต่ละ Over Head
        '    If Not overheadTemp = CStr(markuprow("code_order")) Then
        '      If Not overheadtr Is Nothing Then
        '        overheadtr("Total") = Configuration.FormatToString(tmpMarkAmt, dgt)
        '        overheadtr("Actual") = Configuration.FormatToString(tmpActAmt, dgt)
        '        overheadtr("TotalDiff") = Configuration.FormatToString(tmpDiffAmt, dgt)
        '        stage = "3"
        '        If tmpMarkAmt = 0 Then
        '          overheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        '        Else
        '          overheadtr("TotalPercentDiff") = Configuration.FormatToString((tmpDiffAmt / tmpMarkAmt) * 100, dgt) & " %"
        '        End If
        '        stage = "4"
        '        tmpMarkAmt = 0
        '        tmpActAmt = 0
        '        tmpDiffAmt = 0
        '      End If

        '      overheadtr = overheadedtr.Childs.Add
        '      overheadtr.Tag = markuprow
        '      overheadtr("boqi_itemName") = markuprow("code_description")
        '      overheadtr.State = RowExpandState.Expanded
        '      overheadTemp = CStr(markuprow("code_order"))
        '    End If

        '    'แต่ละรายการ Markup
        '    If Not overheadtr Is Nothing Then
        '      markuptr = overheadtr.Childs.Add
        '      markuptr.Tag = markuprow
        '      markuptr("boqi_itemName") = markuprow("markup_name")
        '      markuptr("Total") = Configuration.FormatToString(CDec(markuprow("markup_totalamt")), dgt)
        '      markuptr("Actual") = Configuration.FormatToString(CDec(markuprow("amount")), dgt)
        '      markuptr("TotalDiff") = Configuration.FormatToString(CDec(markuprow("diffamount")), dgt)
        '      stage = "5"
        '      If CDec(markuprow("markup_totalamt")) = 0 Then
        '        markuptr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        '      Else
        '        markuptr("TotalPercentDiff") = Configuration.FormatToString((CDec(markuprow("diffamount")) / CDec(markuprow("markup_totalamt"))) * 100, dgt) & " %"
        '      End If
        '      stage = "6"
        '      SumMarkAmount += CDec(markuprow("markup_totalamt"))
        '      SumActualAmout += CDec(markuprow("amount"))
        '      SumTotalDiffAmount += CDec(markuprow("diffamount"))
        '      tmpMarkAmt += CDec(markuprow("markup_totalamt"))
        '      tmpActAmt += CDec(markuprow("amount"))
        '      tmpDiffAmt += CDec(markuprow("diffamount"))
        '      markuptr.State = RowExpandState.Expanded
        '    End If

        '    'รายการแต่ละเอกสารในแต่ละ Markup
        '    If detail > 0 Then
        '      Dim DocMatActual As Decimal = 0
        '      Dim DocLabActual As Decimal = 0
        '      Dim DocEqActual As Decimal = 0
        '      Dim DocAmount As Decimal = 0
        '      'Dim myDocId As String = ""
        '      Dim myTempDoc As String = ""
        '      Dim DocMarkuptr As TreeRow = Nothing
        '      Dim DocMarkupItemTr As TreeRow = Nothing

        '      For Each markupdocrow As DataRow In dtDoc.Select("wbsid = " & markuprow("markup_id") & " and ismarkup = 1")
        '        If Not myTempDoc = CStr(markupdocrow("DocId")) Then
        '          If Not DocMarkuptr Is Nothing Then
        '            DocMarkuptr("Actual") = Configuration.FormatToString(DocAmount, dgt)
        '            DocAmount = 0
        '          End If

        '          'แสดงเอกสารแต่ละตัว
        '          DocMarkuptr = markuptr.Childs.Add
        '          DocMarkuptr.Tag = markupdocrow
        '          DocMarkuptr("boqi_itemname") = markupdocrow("DocCode")
        '          'tr("Actual") = Configuration.FormatToString(SumValueInDataTable(dt3.Select(myQuery), "Amt"), dgt)
        '          DocMarkuptr.State = RowExpandState.Expanded
        '          myTempDoc = CStr(markupdocrow("DocId"))
        '        End If

        '        If detail > 1 Then
        '          If Not DocMarkuptr Is Nothing Then
        '            'แสดงรายการในแต่ละเอกสาร
        '            DocMarkupItemTr = DocMarkuptr.Childs.Add
        '            DocMarkupItemTr("boqi_itemname") = markupdocrow("itemName")
        '            DocMarkupItemTr("Unit") = IIf(markupdocrow.IsNull("UnitName"), "", markupdocrow("UnitName"))
        '            DocMarkupItemTr("ActualQuantity") = Configuration.FormatToString(CDec(markupdocrow("Qty")), dgt)
        '            DocMarkupItemTr("Actual") = Configuration.FormatToString(CDec(markupdocrow("Amount")), dgt)
        '            DocMarkupItemTr.State = RowExpandState.None
        '          End If
        '        End If

        '        DocAmount += CDec(markupdocrow("Amount"))
        '      Next
        '      If Not DocMarkuptr Is Nothing Then
        '        DocMarkuptr("Actual") = Configuration.FormatToString(DocAmount, dgt)
        '        DocAmount = 0
        '      End If
        '    End If
        '  Next

        '  If Not overheadtr Is Nothing Then
        '    overheadtr("Total") = Configuration.FormatToString(tmpMarkAmt, dgt)
        '    overheadtr("Actual") = Configuration.FormatToString(tmpActAmt, dgt)
        '    overheadtr("TotalDiff") = Configuration.FormatToString(tmpDiffAmt, dgt)
        '    stage = "7"
        '    If tmpMarkAmt = 0 Then
        '      overheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        '    Else
        '      overheadtr("TotalPercentDiff") = Configuration.FormatToString((tmpDiffAmt / tmpMarkAmt) * 100, dgt) & " %"
        '    End If
        '    stage = "8"
        '    tmpMarkAmt = 0
        '    tmpActAmt = 0
        '    tmpDiffAmt = 0
        '  End If
        'End If

        'overheadedtr("Total") = Configuration.FormatToString(SumMarkAmount, dgt)
        'overheadedtr("Actual") = Configuration.FormatToString(SumActualAmout, dgt)
        'overheadedtr("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount, dgt)
        'stage = "9"
        'If SumMarkAmount = 0 Then
        '  overheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        'Else
        '  overheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumTotalDiffAmount / SumMarkAmount) * 100, dgt) & " %"
        'End If
        'stage = "10"
        'overheadedtr.State = RowExpandState.Expanded
        ''#######################################################################################################

        'TOTAL #################################################################################################
        '#######################################################################################################
        'Dim totalNode As TreeRow = dt.Childs.Add
        'totalNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Total}")
        'totalNode("Total") = Configuration.FormatToString(SumMarkAmount + SumNetWbsBudget, dgt)
        'totalNode("Actual") = Configuration.FormatToString(SumActualAmout + SumNetWBsActual, dgt)
        'totalNode("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount + SumNetWBsDiff, dgt)
        'stage = "11"
        'If SumMarkAmount + SumNetWbsBudget = 0 Then
        '  totalNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        'Else
        '  totalNode("TotalPercentDiff") = Configuration.FormatToString(((SumTotalDiffAmount + SumNetWBsDiff) / (SumMarkAmount + SumNetWbsBudget)) * 100, dgt) & " %"
        'End If
        'stage = "12"
        'totalNode.State = RowExpandState.Expanded
        ''#######################################################################################################

        ''PROFIT ################################################################################################
        ''#######################################################################################################
        'Dim SumProfitAmt As Decimal = 0
        'Dim SumProfitActualAmt As Decimal = 0
        'Dim SumDiffProfitAmt As Decimal = 0
        'Dim profitheadedtr As TreeRow = Nothing
        'Dim profitheadtr As TreeRow = Nothing
        'Dim itemtr As TreeRow = Nothing

        'profitheadedtr = dt.Childs.Add
        'profitheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Profit}" & "<ประเมิน>")

        'If dtMarkUp.Rows.Count > 0 Then
        '  For Each profitrow As DataRow In dtMarkUp.Select("code_tag = 1")

        '    profitheadtr = profitheadedtr.Childs.Add

        '    profitheadtr("boqi_itemName") = profitrow("markup_name")
        '    profitheadtr("Total") = Configuration.FormatToString(CDec(profitrow("markup_totalamt")), dgt)
        '    'profitheadtr("Actual") = Configuration.FormatToString(CDec(profitrow("amount")), dgt)
        '    profitheadtr("TotalDiff") = Configuration.FormatToString(CDec(profitrow("diffamount")), dgt)
        '    stage = "13"
        '    'If CDec(profitrow("markup_totalamt")) = 0 Then
        '    '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        '    'Else
        '    '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString((CDec(profitrow("diffamount")) / CDec(profitrow("markup_totalamt"))) * 100, dgt) & " %"
        '    'End If
        '    stage = "14"
        '    SumProfitAmt += CDec(profitrow("markup_totalamt"))
        '    SumProfitActualAmt += CDec(profitrow("amount"))
        '    SumDiffProfitAmt += CDec(profitrow("diffamount"))
        '    profitheadtr.State = RowExpandState.Expanded
        '  Next
        'End If

        'profitheadedtr("Total") = Configuration.FormatToString(SumProfitAmt, dgt)
        ''profitheadedtr("Actual") = Configuration.FormatToString(SumProfitActualAmt, dgt)
        'profitheadedtr("TotalDiff") = Configuration.FormatToString(SumDiffProfitAmt, dgt)
        'stage = "15"
        ''If SumProfitAmt = 0 Then
        ''    profitheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        ''Else
        ''    profitheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumDiffProfitAmt / SumProfitAmt) * 100, dgt) & " %"
        ''End If
        'stage = "16"
        'profitheadedtr.State = RowExpandState.Expanded
        ''#######################################################################################################

        ''NET PROFIT ############################################################################################
        ''#######################################################################################################
        'Dim netNode As TreeRow = dt.Childs.Add
        'netNode("boqi_itemName") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ")
        ''netNode("Total") = Configuration.FormatToString(NetProfitTotal, dgt)
        ''netNode("Actual") = Configuration.FormatToString(NetProfitActual, dgt)
        'netNode("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount + SumNetWBsDiff + SumDiffProfitAmt, dgt)
        'stage = "17"
        ''If (SumTotalDiffAmount + SumNetWBsDiff) = 0 Then
        ''    netNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        ''Else
        ''    netNode("TotalPercentDiff") = Configuration.FormatToString(((SumTotalDiffAmount + SumNetWBsDiff - SumDiffProfitAmt) / (SumTotalDiffAmount + SumNetWBsDiff)) * 100, dgt) & " %"
        ''End If
        'stage = "18"
        'netNode.State = RowExpandState.Expanded
        ''#######################################################################################################


        'Dim i As Integer = 0
        ''For Each row As DataRow In dt.Rows
        ''  i += 1
        ''  row("boqi_linenumber") = i
        ''Next
        'm_hashData = New Hashtable
        'For Each row As TreeRow In dt.Rows
        '  i += 1
        '  row("boqi_linenumber") = i
        '  If Not row.Tag Is Nothing Then
        '    m_hashData(i) = row.Tag
        '  End If
        'Next
        'If i > 0 Then
        dt.AcceptChanges()
        'End If
      Catch ex As Exception
        MessageBox.Show(stage & vbCrLf & ex.Message)
      End Try

    End Sub
    'Private Function SumValueInDataTable(ByVal dr() As DataRow, ByVal field As String) As Decimal
    '    Dim ret As Decimal = 0
    '    For Each drtmp As DataRow In dr
    '        If Not drtmp.IsNull(field) Then
    '            ret += CDec(drtmp(field))
    '        End If
    '    Next
    '    Return ret
    'End Function
    'Public Overrides Sub RefreshDataSet()
    '  m_cc = New CostCenter
    '  'If TypeOf Me.Filters(0).Value Is CostCenter Then
    '  '  m_cc = CType(Me.Filters(0).Value, CostCenter)
    '  'End If
    '  ''เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
    '  'If Not Me.Filters(0).Value Is DBNull.Value Then
    '  '  Me.Filters(0).Value = m_cc.Id
    '  'End If
    '  'If Not Me.Filters(6).Value Is Nothing AndAlso TypeOf Me.Filters(6).Value Is Employee Then
    '  '  Me.Filters(6).Value = Me.Filters(6).Value.Id
    '  'End If
    '  '
    '  If Not m_cc Is Nothing AndAlso m_cc.Originated Then
    '    MyBase.RefreshDataSet()
    '  End If
    'End Sub
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
        Return "RptCBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCBSMonitor.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptCBSMonitor.ListLabel}"
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
    Public Property AdvanceFindCollection() As AdvanceFindCollection

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
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCode"
      dpi.Value = m_cc.Code  'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = m_cc.Name 'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      If Not IsDBNull(Me.Filters(1).Value) Then
        dpi.Value = CDate(Me.Filters(1).Value).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim typeString As String = ""
      Dim type As BOQ.WBSReportType
      If TypeOf Me.Filters(3).Value Is BOQ.WBSReportType Then
        type = CType(Me.Filters(3).Value, BOQ.WBSReportType)
      End If
      Select Case type
        Case BOQ.WBSReportType.PR
          typeString = "ขอซื้อ"
        Case BOQ.WBSReportType.PO
          typeString = "สั่งซื้อ"
        Case BOQ.WBSReportType.GoodsReceipt
          typeString = "รับของ"
        Case BOQ.WBSReportType.MatWithdraw
          typeString = "เบิกของ"
      End Select
      dpi = New DocPrintingItem
      dpi.Mapping = "Type"
      dpi.Value = typeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "Requester"
      If Not IsDBNull(Me.Filters(6).Value) Then
        dpi.Value = New Employee(CInt(Me.Filters(6).Value)).Name
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

        r = i + 1
        Dim dr As Object = m_hashData(r)
        If Not dr Is Nothing Then
          If TypeOf dr Is DataRow Then
            Dim row As DataRow = CType(dr, DataRow)
            If row.Table.TableName = "Table0" Then
              Dim drh As New DataRowHelper(row)

              dpi = New DocPrintingItem
              dpi.Mapping = "col1.1"
              dpi.Value = drh.GetValue(Of String)("wbs_code")
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              dpi = New DocPrintingItem
              dpi.Mapping = "col1.2"
              dpi.Value = drh.GetValue(Of String)("wbs_name")
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)
            End If
          End If
        End If

        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

