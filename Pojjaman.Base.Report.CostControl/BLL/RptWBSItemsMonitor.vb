Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptWBSItemsMonitor
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
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
    Public Shared Function CreateWBSMonitorTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 240
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      'Dim csUnitPrice As New TreeTextColumn
      'csUnitPrice.MappingName = "UnitPrice"
      'csUnitPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitPriceHeaderText}")
      'csUnitPrice.NullText = ""
      'csUnitPrice.DataAlignment = HorizontalAlignment.Right
      'csUnitPrice.Format = "#,###.##"
      'csUnitPrice.TextBox.Name = "UnitPrice"
      'csUnitPrice.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.Format = "#,###.##"
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True

      'Dim csBarrier1 As New DataGridBarrierColumn
      'csBarrier1.MappingName = "Barrier1"
      'csBarrier1.HeaderText = ""
      'csBarrier1.NullText = ""
      'csBarrier1.ReadOnly = True

      Dim csTotalQty As New TreeTextColumn
      csTotalQty.MappingName = "TotalQuantity"
      csTotalQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalQuantityHeaderText}")
      csTotalQty.NullText = ""
      csTotalQty.DataAlignment = HorizontalAlignment.Right
      csTotalQty.Format = "#,###.##"
      csTotalQty.TextBox.Name = "TotalQuantity"
      csTotalQty.ReadOnly = True

      Dim csActualQty As New TreeTextColumn
      csActualQty.MappingName = "ActualQuantity"
      csActualQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualQuantityHeaderText}")
      csActualQty.NullText = ""
      csActualQty.DataAlignment = HorizontalAlignment.Right
      csActualQty.Format = "#,###.##"
      csActualQty.TextBox.Name = "ActualQuantity"
      csActualQty.ReadOnly = True

      Dim csQtyDiff As New TreeTextColumn
      csQtyDiff.MappingName = "QuantityDiff"
      csQtyDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csQtyDiff.NullText = ""
      csQtyDiff.DataAlignment = HorizontalAlignment.Right
      csQtyDiff.Format = "#,###.##"
      csQtyDiff.TextBox.Name = "QuantityDiff"
      csQtyDiff.ReadOnly = True

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.ReadOnly = True

      Dim csTotalMC As New TreeTextColumn
      csTotalMC.MappingName = "TotalMaterialCost"
      csTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalMaterialCostHeaderText}")
      csTotalMC.NullText = ""
      csTotalMC.DataAlignment = HorizontalAlignment.Right
      csTotalMC.Format = "#,###.##"
      csTotalMC.TextBox.Name = "TotalMaterialCost"
      csTotalMC.ReadOnly = True

      Dim csActualTotalMC As New TreeTextColumn
      csActualTotalMC.MappingName = "ActualMaterialCost"
      csActualTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMaterialCostHeaderText}")
      csActualTotalMC.NullText = ""
      csActualTotalMC.DataAlignment = HorizontalAlignment.Right
      csActualTotalMC.Format = "#,###.##"
      csActualTotalMC.TextBox.Name = "ActualMaterialCost"
      csActualTotalMC.ReadOnly = True

      Dim csMatDiff As New TreeTextColumn
      csMatDiff.MappingName = "MatDiff"
      csMatDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csMatDiff.NullText = ""
      csMatDiff.DataAlignment = HorizontalAlignment.Right
      csMatDiff.Format = "#,###.##"
      csMatDiff.TextBox.Name = "MatDiff"
      csMatDiff.ReadOnly = True

      Dim csBarrier3 As New DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
      csBarrier3.ReadOnly = True

      Dim csTotalLC As New TreeTextColumn
      csTotalLC.MappingName = "TotalLaborCost"
      csTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalLaborCostHeaderText}")
      csTotalLC.NullText = ""
      csTotalLC.DataAlignment = HorizontalAlignment.Right
      csTotalLC.Format = "#,###.##"
      csTotalLC.TextBox.Name = "TotalLaborCost"
      csTotalLC.ReadOnly = True

      Dim csActualTotalLC As New TreeTextColumn
      csActualTotalLC.MappingName = "ActualLaborCost"
      csActualTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualLaborCostHeaderText}")
      csActualTotalLC.NullText = ""
      csActualTotalLC.DataAlignment = HorizontalAlignment.Right
      csActualTotalLC.Format = "#,###.##"
      csActualTotalLC.TextBox.Name = "ActualLaborCost"
      csActualTotalLC.ReadOnly = True

      Dim csLabDiff As New TreeTextColumn
      csLabDiff.MappingName = "LabDiff"
      csLabDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csLabDiff.NullText = ""
      csLabDiff.DataAlignment = HorizontalAlignment.Right
      csLabDiff.Format = "#,###.##"
      csLabDiff.TextBox.Name = "LabDiff"
      csLabDiff.ReadOnly = True

      Dim csBarrier4 As New DataGridBarrierColumn
      csBarrier4.MappingName = "Barrier4"
      csBarrier4.HeaderText = ""
      csBarrier4.NullText = ""
      csBarrier4.ReadOnly = True

      Dim csTotalEC As New TreeTextColumn
      csTotalEC.MappingName = "TotalEquipmentCost"
      csTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalEquipmentCostHeaderText}")
      csTotalEC.NullText = ""
      csTotalEC.DataAlignment = HorizontalAlignment.Right
      csTotalEC.Format = "#,###.##"
      csTotalEC.TextBox.Name = "TotalEquipmentCost"
      csTotalEC.ReadOnly = True

      Dim csActualTotalEC As New TreeTextColumn
      csActualTotalEC.MappingName = "ActualEquipmentCost"
      csActualTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualEquipmentCostHeaderText}")
      csActualTotalEC.NullText = ""
      csActualTotalEC.DataAlignment = HorizontalAlignment.Right
      csActualTotalEC.Format = "#,###.##"
      csActualTotalEC.TextBox.Name = "ActualEquipmentCost"
      csActualTotalEC.ReadOnly = True

      Dim csEqDiff As New TreeTextColumn
      csEqDiff.MappingName = "EqDiff"
      csEqDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csEqDiff.NullText = ""
      csEqDiff.DataAlignment = HorizontalAlignment.Right
      csEqDiff.Format = "#,###.##"
      csEqDiff.TextBox.Name = "EqDiff"
      csEqDiff.ReadOnly = True

      Dim csBarrier5 As New DataGridBarrierColumn
      csBarrier5.MappingName = "Barrier5"
      csBarrier5.HeaderText = ""
      csBarrier5.NullText = ""
      csBarrier5.ReadOnly = True

      Dim csTotal As New TreeTextColumn
      csTotal.MappingName = "Total"
      csTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalCostHeaderText}")
      csTotal.NullText = ""
      csTotal.Width = 100
      csTotal.DataAlignment = HorizontalAlignment.Right
      csTotal.Format = "#,###.##"
      csTotal.TextBox.Name = "Total"
      csTotal.ReadOnly = True

      Dim csActualTotal As New TreeTextColumn
      csActualTotal.MappingName = "Actual"
      csActualTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualCostHeaderText}")
      csActualTotal.NullText = ""
      csActualTotal.DataAlignment = HorizontalAlignment.Right
      csActualTotal.Format = "#,###.##"
      csActualTotal.TextBox.Name = "Actual"
      csActualTotal.ReadOnly = True

      Dim csTotalDiff As New TreeTextColumn
      csTotalDiff.MappingName = "TotalDiff"
      csTotalDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csTotalDiff.NullText = ""
      csTotalDiff.Width = 110
      csTotalDiff.DataAlignment = HorizontalAlignment.Right
      csTotalDiff.Format = "#,###.##"
      csTotalDiff.TextBox.Name = "TotalDiff"
      csTotalDiff.ReadOnly = True

      Dim csTotalPercentDiff As New TreeTextColumn
      csTotalPercentDiff.MappingName = "TotalPercentDiff"
      csTotalPercentDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PercentDiffHeaderText}")
      csTotalPercentDiff.NullText = ""
      'csTotalDiff.Width = 110
      csTotalPercentDiff.DataAlignment = HorizontalAlignment.Right
      'csTotalDiff.Format = "#,###.##"
      csTotalPercentDiff.TextBox.Name = "TotalPercentDiff"
      csTotalPercentDiff.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)

      dst.GridColumnStyles.Add(csBarrier0)

      'dst.GridColumnStyles.Add(csUnitPrice)
      dst.GridColumnStyles.Add(csUnit)

      'dst.GridColumnStyles.Add(csBarrier1)

      dst.GridColumnStyles.Add(csTotalQty)
      dst.GridColumnStyles.Add(csActualQty)
      dst.GridColumnStyles.Add(csQtyDiff)

      dst.GridColumnStyles.Add(csBarrier2)

      dst.GridColumnStyles.Add(csTotalMC)
      dst.GridColumnStyles.Add(csActualTotalMC)
      dst.GridColumnStyles.Add(csMatDiff)

      dst.GridColumnStyles.Add(csBarrier3)

      dst.GridColumnStyles.Add(csTotalLC)
      dst.GridColumnStyles.Add(csActualTotalLC)
      dst.GridColumnStyles.Add(csLabDiff)

      dst.GridColumnStyles.Add(csBarrier4)

      dst.GridColumnStyles.Add(csTotalEC)
      dst.GridColumnStyles.Add(csActualTotalEC)
      dst.GridColumnStyles.Add(csEqDiff)

      dst.GridColumnStyles.Add(csBarrier5)

      dst.GridColumnStyles.Add(csTotal)
      dst.GridColumnStyles.Add(csActualTotal)
      dst.GridColumnStyles.Add(csTotalDiff)
      dst.GridColumnStyles.Add(csTotalPercentDiff)

      Return dst
    End Function
    Public Shared Function GetWBSMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("boqi_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_itemName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier0", GetType(String)))

      'myDatatable.Columns.Add(New DataColumn("UnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))

      'myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("TotalQuantity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualQuantity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("QuantityDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("TotalMaterialCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualMaterialCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("MatDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier3", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("TotalLaborCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualLaborCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("LabDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier4", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("TotalEquipmentCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualEquipmentCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EqDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier5", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Total", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Actual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalDiff", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalPercentDiff", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return Me.GetWBSMonitorSchemaTable 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return Me.CreateWBSMonitorTableStyle 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Cols.FrozenCount = 3
      lkg.HilightGroupParentText = True
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      If m_cc Is Nothing OrElse Not m_cc.Originated Then
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        tm.Treetable = dt
        Return
      End If
      'If m_cc.BoqId = 0 Then
      '  Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '  dt.Clear()
      '  tm.Treetable = dt
      '  Return
      'End If
      If TypeOf Me.Filters(1).Value Is Date Then
        Dim nodigit As Boolean = False
        If Me.Filters(5).Name.ToLower = "nodigit" Then
          nodigit = CBool(Me.Filters(5).Value)
        End If
        PopulateWBSMonitorListing(tm.Treetable, nodigit)
      End If
    End Sub
    Public Sub PopulateWBSMonitorListing(ByVal dt As TreeTable, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()

      Dim dt2 As DataTable = Me.DataSet.Tables(0)
      Dim dt3 As DataTable = Me.DataSet.Tables(1)
      Dim dt4 As DataTable = Me.DataSet.Tables(2)
      If dt2.Rows.Count <= 0 Then
        Return
      End If

      ' WBS ##################################################################################################
      '#######################################################################################################
      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing
      Dim myTempId As Integer = 0
      Dim SumNetWbsBudget As Decimal = 0
      Dim SumNetWBsActual As Decimal = 0
      Dim SumNetWBsDiff As Decimal = 0
      Dim tr As TreeRow = Nothing
      Dim lcitr As TreeRow = Nothing

      For Each wbsrow As DataRow In dt2.Rows
        If CInt(wbsrow("wbs_level")) = 0 Then
          parentNode = dt.Childs.Add
          SumNetWbsBudget += CDec(wbsrow("TotalBudget"))
          SumNetWBsActual += CDec(wbsrow("TotalActual"))
          SumNetWBsDiff += CDec(wbsrow("DiffAmount"))
        Else
          myParent = wbsrow("Parent")
          Try
            parentNode = Nodes(myParent).Childs.Add
          Catch ex As Exception

          End Try
        End If

        If Not parentNode Is Nothing Then
          Nodes(CStr(wbsrow("wbs_path"))) = parentNode

          'แสดงแต่ละ wbs
          tr = parentNode
          tr("boqi_itemname") = wbsrow("wbs_code") & "-" & wbsrow("wbs_name")
          '
          'If CInt(wbsrow("wbs_level")) <> 0 Then
          '  tr("TotalQuantity") = Configuration.FormatToString(CDec(wbsrow("QtyBudget")), dgt)
          '  tr("ActualQuantity") = Configuration.FormatToString(CDec(wbsrow("QtyActual")), dgt)
          '  tr("QuantityDiff") = Configuration.FormatToString(CDec(wbsrow("DiffQty")), dgt)
          'End If
          '
          tr("TotalMaterialCost") = Configuration.FormatToString(CDec(wbsrow("MatBudget")), dgt)
          tr("ActualMaterialCost") = Configuration.FormatToString(CDec(wbsrow("MatActual")), dgt)
          tr("MatDiff") = Configuration.FormatToString(CDec(wbsrow("DiffMat")), dgt)
          '
          tr("TotalLaborCost") = Configuration.FormatToString(CDec(wbsrow("LabBudget")), dgt)
          tr("ActualLaborCost") = Configuration.FormatToString(CDec(wbsrow("LabActual")), dgt)
          tr("LabDiff") = Configuration.FormatToString(CDec(wbsrow("DiffLab")), dgt)
          '
          tr("TotalEquipmentCost") = Configuration.FormatToString(CDec(wbsrow("EqBudget")), dgt)
          tr("ActualEquipmentCost") = Configuration.FormatToString(CDec(wbsrow("EqActual")), dgt)
          tr("EqDiff") = Configuration.FormatToString(CDec(wbsrow("DiffEq")), dgt)
          '
          tr("Total") = Configuration.FormatToString(CDec(wbsrow("TotalBudget")), dgt)
          tr("Actual") = Configuration.FormatToString(CDec(wbsrow("TotalActual")), dgt)
          tr("TotalDiff") = Configuration.FormatToString(CDec(wbsrow("DiffAmount")), dgt)
          tr("TotalPercentDiff") = Configuration.FormatToString(CDec(wbsrow("PercentDiff")), dgt) & " %"
          tr.State = RowExpandState.Expanded

          For Each itemrow As DataRow In dt4.Select("cc_id=" & wbsrow("cc_id") & " and wbs_id=" & wbsrow("wbs_id") & " and ismarkup=0")

            'แต่ละ item
            lcitr = tr.Childs.Add
            lcitr("boqi_itemname") = itemrow("itemname")
            '
            'lcitr("UnitPrice") = Configuration.FormatToString(CDec(itemrow("UnitPrice")), dgt)
            lcitr("Unit") = itemrow("UnitName")
            '
            lcitr("TotalQuantity") = Configuration.FormatToString(CDec(itemrow("QtyBudget")), dgt)
            lcitr("ActualQuantity") = Configuration.FormatToString(CDec(itemrow("Qty")), dgt)
            lcitr("QuantityDiff") = Configuration.FormatToString(CDec(itemrow("DiffQty")), dgt)
            '
            lcitr("TotalMaterialCost") = Configuration.FormatToString(CDec(itemrow("MatBudget")), dgt)
            lcitr("ActualMaterialCost") = Configuration.FormatToString(CDec(itemrow("MatActual")), dgt)
            lcitr("MatDiff") = Configuration.FormatToString(CDec(itemrow("DiffMat")), dgt)
            '
            lcitr("TotalLaborCost") = Configuration.FormatToString(CDec(itemrow("LabBudget")), dgt)
            lcitr("ActualLaborCost") = Configuration.FormatToString(CDec(itemrow("LabActual")), dgt)
            lcitr("LabDiff") = Configuration.FormatToString(CDec(itemrow("DiffLab")), dgt)
            '
            lcitr("TotalEquipmentCost") = Configuration.FormatToString(CDec(itemrow("EqBudget")), dgt)
            lcitr("ActualEquipmentCost") = Configuration.FormatToString(CDec(itemrow("EqActual")), dgt)
            lcitr("EqDiff") = Configuration.FormatToString(CDec(itemrow("DiffEq")), dgt)
            '
            lcitr("Total") = Configuration.FormatToString(CDec(itemrow("TotalBudget")), dgt)
            lcitr("Actual") = Configuration.FormatToString(CDec(itemrow("TotalActual")), dgt)
            lcitr("TotalDiff") = Configuration.FormatToString(CDec(itemrow("DiffAmount")), dgt)
            lcitr("TotalPercentDiff") = Configuration.FormatToString(CDec(itemrow("PercentDiff")), dgt) & " %"
          Next
        End If
      Next
      '#######################################################################################################

      ' OVER HEAD ############################################################################################
      '#######################################################################################################
      Dim SumMarkAmount As Decimal = 0
      Dim SumActualAmout As Decimal = 0
      Dim SumTotalDiffAmount As Decimal = 0
      Dim tmpMarkAmt As Decimal = 0
      Dim tmpActAmt As Decimal = 0
      Dim tmpDiffAmt As Decimal = 0
      Dim tmpPercentDiff As Decimal = 0
      Dim overheadTemp As String = ""
      Dim overheadedtr As TreeRow = Nothing
      Dim overheadtr As TreeRow = Nothing
      Dim markuptr As TreeRow = Nothing

      overheadedtr = dt.Childs.Add
      overheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
      If dt3.Rows.Count > 0 Then
        For Each markuprow As DataRow In dt3.Select("code_tag = 0")
          'แต่ละ Over Head
          If Not overheadTemp = CStr(markuprow("code_order")) Then
            If Not overheadtr Is Nothing Then
              overheadtr("Total") = Configuration.FormatToString(tmpMarkAmt, dgt)
              overheadtr("Actual") = Configuration.FormatToString(tmpActAmt, dgt)
              overheadtr("TotalDiff") = Configuration.FormatToString(tmpDiffAmt, dgt)
              If tmpMarkAmt = 0 Then
                overheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
              Else
                overheadtr("TotalPercentDiff") = Configuration.FormatToString((tmpDiffAmt / tmpMarkAmt) * 100, dgt) & " %"
              End If
              tmpMarkAmt = 0
              tmpActAmt = 0
              tmpDiffAmt = 0
            End If

            overheadtr = overheadedtr.Childs.Add
            overheadtr("boqi_itemName") = markuprow("code_description")
            overheadtr.State = RowExpandState.Expanded
            overheadTemp = CStr(markuprow("code_order"))
          End If

          'แต่ละรายการ Markup
          If Not overheadtr Is Nothing Then
            markuptr = overheadtr.Childs.Add

            markuptr("boqi_itemName") = markuprow("markup_name")
            markuptr("Total") = Configuration.FormatToString(CDec(markuprow("markup_totalamt")), dgt)
            markuptr("Actual") = Configuration.FormatToString(CDec(markuprow("amount")), dgt)
            markuptr("TotalDiff") = Configuration.FormatToString(CDec(markuprow("diffamount")), dgt)
            If CDec(markuprow("markup_totalamt")) = 0 Then
              markuptr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            Else
              markuptr("TotalPercentDiff") = Configuration.FormatToString((CDec(markuprow("diffamount")) / CDec(markuprow("markup_totalamt"))) * 100, dgt) & " %"
            End If
            SumMarkAmount += CDec(markuprow("markup_totalamt"))
            SumActualAmout += CDec(markuprow("amount"))
            SumTotalDiffAmount += CDec(markuprow("diffamount"))
            tmpMarkAmt += CDec(markuprow("markup_totalamt"))
            tmpActAmt += CDec(markuprow("amount"))
            tmpDiffAmt += CDec(markuprow("diffamount"))
            markuptr.State = RowExpandState.Expanded
          End If

          Dim DocMatActual As Decimal = 0
          Dim DocLabActual As Decimal = 0
          Dim DocEqActual As Decimal = 0
          Dim DocAmount As Decimal = 0
          'Dim myDocId As String = ""
          Dim myTempDoc As String = ""
          Dim DocMarkuptr As TreeRow = Nothing
          Dim DocMarkupItemTr As TreeRow = Nothing

          For Each markupdocrow As DataRow In dt4.Select("wbs_id = " & markuprow("markup_id") & " and ismarkup = 1")
            If Not markuptr Is Nothing Then
              'แสดงรายการในแต่ละเอกสาร
              DocMarkupItemTr = markuptr.Childs.Add
              DocMarkupItemTr("boqi_itemname") = markupdocrow("itemName")
              'DocMarkupItemTr("Unit") = IIf(markupdocrow.IsNull("UnitName"), "", markupdocrow("UnitName"))
              DocMarkupItemTr("Total") = Configuration.FormatToString(CDec(markupdocrow("TotalBudget")), dgt)
              DocMarkupItemTr("Actual") = Configuration.FormatToString(CDec(markupdocrow("TotalActual")), dgt)
              DocMarkupItemTr("TotalDiff") = Configuration.FormatToString(CDec(markupdocrow("diffamount")), dgt)
              DocMarkupItemTr("TotalPercentDiff") = Configuration.FormatToString(CDec(markupdocrow("percentdiff")), dgt) & " %"
              DocMarkupItemTr.State = RowExpandState.None
            End If

            DocAmount += CDec(markupdocrow("TotalActual"))
          Next
          If Not DocMarkuptr Is Nothing Then
            DocMarkuptr("Actual") = Configuration.FormatToString(DocAmount, dgt)
          End If
        Next

        If Not overheadtr Is Nothing Then
          overheadtr("Total") = Configuration.FormatToString(tmpMarkAmt, dgt)
          overheadtr("Actual") = Configuration.FormatToString(tmpActAmt, dgt)
          overheadtr("TotalDiff") = Configuration.FormatToString(tmpDiffAmt, dgt)
          If tmpMarkAmt = 0 Then
            overheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
          Else
            overheadtr("TotalPercentDiff") = Configuration.FormatToString((tmpDiffAmt / tmpMarkAmt) * 100, dgt) & " %"
          End If
          tmpMarkAmt = 0
          tmpActAmt = 0
          tmpDiffAmt = 0
        End If
      End If

      overheadedtr("Total") = Configuration.FormatToString(SumMarkAmount, dgt)
      overheadedtr("Actual") = Configuration.FormatToString(SumActualAmout, dgt)
      overheadedtr("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount, dgt)
      If SumMarkAmount = 0 Then
        overheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
      Else
        overheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumTotalDiffAmount / SumMarkAmount) * 100, dgt) & " %"
      End If
      overheadedtr.State = RowExpandState.Expanded
      '#######################################################################################################

      'TOTAL #################################################################################################
      '#######################################################################################################
      Dim totalNode As TreeRow = dt.Childs.Add
      totalNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Total}")
      totalNode("Total") = Configuration.FormatToString(SumMarkAmount + SumNetWbsBudget, dgt)
      totalNode("Actual") = Configuration.FormatToString(SumActualAmout + SumNetWBsActual, dgt)
      totalNode("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount + SumNetWBsDiff, dgt)
      If SumMarkAmount + SumNetWbsBudget = 0 Then
        totalNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
      Else
        totalNode("TotalPercentDiff") = Configuration.FormatToString(((SumTotalDiffAmount + SumNetWBsDiff) / (SumMarkAmount + SumNetWbsBudget)) * 100, dgt) & " %"
      End If
      totalNode.State = RowExpandState.Expanded
      '#######################################################################################################

      'PROFIT ################################################################################################
      '#######################################################################################################
      Dim SumProfitAmt As Decimal = 0
      Dim SumProfitActualAmt As Decimal = 0
      Dim SumDiffProfitAmt As Decimal = 0
      Dim profitheadedtr As TreeRow = Nothing
      Dim profitheadtr As TreeRow = Nothing
      Dim itemtr As TreeRow = Nothing

      profitheadedtr = dt.Childs.Add
      profitheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Profit}" & "<ประเมิน>")

      If dt3.Rows.Count > 0 Then
        For Each profitrow As DataRow In dt3.Select("code_tag = 1")

          profitheadtr = profitheadedtr.Childs.Add

          profitheadtr("boqi_itemName") = profitrow("markup_name")
          profitheadtr("Total") = Configuration.FormatToString(CDec(profitrow("markup_totalamt")), dgt)
          'profitheadtr("Actual") = Configuration.FormatToString(CDec(profitrow("amount")), dgt)
          profitheadtr("TotalDiff") = Configuration.FormatToString(CDec(profitrow("diffamount")), dgt)
          'If CDec(profitrow("markup_totalamt")) = 0 Then
          '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
          'Else
          '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString((CDec(profitrow("diffamount")) / CDec(profitrow("markup_totalamt"))) * 100, dgt) & " %"
          'End If
          SumProfitAmt += CDec(profitrow("markup_totalamt"))
          SumProfitActualAmt += CDec(profitrow("amount"))
          SumDiffProfitAmt += CDec(profitrow("diffamount"))
          profitheadtr.State = RowExpandState.Expanded
        Next
      End If

      profitheadedtr("Total") = Configuration.FormatToString(SumProfitAmt, dgt)
      'profitheadedtr("Actual") = Configuration.FormatToString(SumProfitActualAmt, dgt)
      profitheadedtr("TotalDiff") = Configuration.FormatToString(SumDiffProfitAmt, dgt)
      'If SumProfitAmt = 0 Then
      '  profitheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
      'Else
      '  profitheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumDiffProfitAmt / SumProfitAmt) * 100, dgt) & " %"
      'End If
      profitheadedtr.State = RowExpandState.Expanded
      '#######################################################################################################

      'NET PROFIT ############################################################################################
      '#######################################################################################################
      Dim netNode As TreeRow = dt.Childs.Add
      netNode("boqi_itemName") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ")
      'netNode("Total") = Configuration.FormatToString(NetProfitTotal, dgt)
      'netNode("Actual") = Configuration.FormatToString(NetProfitActual, dgt)
      netNode("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount + SumNetWBsDiff + SumDiffProfitAmt, dgt)
      'If (SumTotalDiffAmount + SumNetWBsDiff) = 0 Then
      '  netNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
      'Else
      '  netNode("TotalPercentDiff") = Configuration.FormatToString(((SumTotalDiffAmount + SumNetWBsDiff - SumDiffProfitAmt) / (SumTotalDiffAmount + SumNetWBsDiff)) * 100, dgt) & " %"
      'End If
      netNode.State = RowExpandState.Expanded
      '#######################################################################################################


      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If

    End Sub
    Public Overrides Sub RefreshDataSet()
      m_cc = New CostCenter
      If TypeOf Me.Filters(0).Value Is CostCenter Then
        m_cc = CType(Me.Filters(0).Value, CostCenter)
      End If
      'เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
      If Not Me.Filters(0).Value Is DBNull.Value Then
        Me.Filters(0).Value = m_cc.Id
      End If
      If Not Me.Filters(6).Value Is Nothing AndAlso TypeOf Me.Filters(6).Value Is Employee Then
        Me.Filters(6).Value = Me.Filters(6).Value.Id
      End If
      If Not m_cc Is Nothing AndAlso m_cc.Originated Then
        MyBase.RefreshDataSet()
      End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptWBSItemsMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSItemsMonitor.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSItemsMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSItemsMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSItemsMonitor.ListLabel}"
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

      If Not Me.m_cc Is Nothing Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.m_cc.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.m_cc.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = CDate(Me.Filters(1).Value).ToShortDateString
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

      Dim n As Integer = 0
      Dim c As Integer = 0
      Dim barrierColl As String = ""
      Dim isBarier As Boolean = False
      For rowItem As Integer = 0 To Me.Treemanager.Treetable.Rows.Count - 1
        c = 0
        For colItem As Integer = 1 To Me.Treemanager.Treetable.Columns.Count - 1
          barrierColl = Me.Treemanager.Treetable.Columns(colItem).ColumnName.ToLower
          If barrierColl.IndexOf("barrier") = 0 Then
            isBarier = True
          Else
            isBarier = False
          End If
          If Not isBarier Then
            dpi = New DocPrintingItem
            dpi.Mapping = "col" & c.ToString
            dpi.Value = Me.Treemanager.Treetable.Rows(rowItem)(colItem)
            dpi.DataType = "System.String"
            dpi.Row = n + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
            c += 1
          End If

        Next
        n += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

