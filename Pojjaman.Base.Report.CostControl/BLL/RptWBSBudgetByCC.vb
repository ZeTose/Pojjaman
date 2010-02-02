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
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptWBSBudgetByCC
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    'Private m_cc As CostCenter
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

      'Dim csUnit As New TreeTextColumn
      'csUnit.MappingName = "Unit"
      'csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      'csUnit.NullText = ""
      'csUnit.DataAlignment = HorizontalAlignment.Center
      'csUnit.Format = "#,###.##"
      'csUnit.TextBox.Name = "Unit"
      'csUnit.ReadOnly = True

      'Dim csBarrier1 As New DataGridBarrierColumn
      'csBarrier1.MappingName = "Barrier1"
      'csBarrier1.HeaderText = ""
      'csBarrier1.NullText = ""
      'csBarrier1.ReadOnly = True

      'Dim csTotalQty As New TreeTextColumn
      'csTotalQty.MappingName = "TotalQuantity"
      'csTotalQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalQuantityHeaderText}")
      'csTotalQty.NullText = ""
      'csTotalQty.DataAlignment = HorizontalAlignment.Right
      'csTotalQty.Format = "#,###.##"
      'csTotalQty.TextBox.Name = "TotalQuantity"
      'csTotalQty.ReadOnly = True

      'Dim csActualQty As New TreeTextColumn
      'csActualQty.MappingName = "ActualQuantity"
      'csActualQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualQuantityHeaderText}")
      'csActualQty.NullText = ""
      'csActualQty.DataAlignment = HorizontalAlignment.Right
      'csActualQty.Format = "#,###.##"
      'csActualQty.TextBox.Name = "ActualQuantity"
      'csActualQty.ReadOnly = True

      'Dim csQtyDiff As New TreeTextColumn
      'csQtyDiff.MappingName = "QuantityDiff"
      'csQtyDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      'csQtyDiff.NullText = ""
      'csQtyDiff.DataAlignment = HorizontalAlignment.Right
      'csQtyDiff.Format = "#,###.##"
      'csQtyDiff.TextBox.Name = "QuantityDiff"
      'csQtyDiff.ReadOnly = True

      'Dim csBarrier2 As New DataGridBarrierColumn
      'csBarrier2.MappingName = "Barrier2"
      'csBarrier2.HeaderText = ""
      'csBarrier2.NullText = ""
      'csBarrier2.ReadOnly = True

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

      'dst.GridColumnStyles.Add(csUnit)
      'dst.GridColumnStyles.Add(csBarrier1)
      'dst.GridColumnStyles.Add(csActualQty)
      'dst.GridColumnStyles.Add(csBarrier2)

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

      'myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("ActualQuantity", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))

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
      '  Dim nodigit As Boolean = False
      '  If Me.Filters(5).Name.ToLower = "nodigit" Then
      '    nodigit = CBool(Me.Filters(5).Value)
      '  End If
      PopulateWBSMonitorListing(tm.Treetable)
      'End If
    End Sub
    Public Sub PopulateWBSMonitorListing(ByVal dt As TreeTable)
      Dim dgt As DigitConfig = DigitConfig.Price

      dt.Clear()
      Dim dt2 As DataTable = Me.DataSet.Tables(0)

      If dt2.Rows.Count <= 0 Then
        Return
      End If

      Dim costCenterTr As TreeRow = Nothing
      Dim itemTr As TreeRow = Nothing
      Dim currCostCenter As String = ""

      Dim totalBudget As Decimal = 0
      Dim totalActual As Decimal = 0
      Dim totalDiff As Decimal = 0
      Dim profit As Decimal = 0
      Dim profitEstimate As Decimal = 0
      Dim grandTotal As Decimal = 0
      Dim grandProfit As Decimal = 0

      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      For Each ccRow As DataRow In dt2.Rows
        If ccRow("cc_id").ToString <> currCostCenter Then
          If Not itemTr Is Nothing Then
            '----------------------------------------
            itemTr = costCenterTr.Childs.Add
            itemTr("boqi_itemname") = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.NetProfit}") '"กำไร(ขาดทุน)สุทธิ"
            '
            itemTr("TotalDiff") = Configuration.FormatToString(grandTotal + grandProfit, dgt)
            'If profit = 0 Then
            '  itemTr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            'Else
            '  itemTr("TotalPercentDiff") = Configuration.FormatToString((totalDiff / profit) * 100, dgt) & " %"
            'End If
            itemTr.State = RowExpandState.Expanded

            grandTotal = 0
            grandProfit = 0
            '----------------------------------------
          End If

          currCostCenter = ccRow("cc_id").ToString
          '----------------------------------------
          costCenterTr = dt.Childs.Add
          costCenterTr("boqi_itemname") = ccRow("cc_code") & " : " & ccRow("cc_name")
          costCenterTr.State = RowExpandState.Expanded
          '----------------------------------------

          totalBudget = 0
          totalActual = 0
          totalDiff = 0
          profit = 0
          itemTr = Nothing

          If Not ccRow.IsNull("inDirectCost") Then
            If ccRow("inDirectType").ToString.ToLower = "directcost" Then
              '----------------------------------------
              itemTr = costCenterTr.Childs.Add
              itemTr("boqi_itemname") = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.DirectCost}") '"ต้นทุนทางตรง"

              totalBudget = CDec(ccRow("TotalBudget"))
              totalActual = CDec(ccRow("TotalActual"))
              totalDiff = CDec(ccRow("TotalDiff"))
              '
              itemTr("TotalMaterialCost") = Configuration.FormatToString(CDec(ccRow("MatBudget")), dgt)
              itemTr("ActualMaterialCost") = Configuration.FormatToString(CDec(ccRow("MatActual")), dgt)
              itemTr("MatDiff") = Configuration.FormatToString(CDec(ccRow("DiffMat")), dgt)
              '
              itemTr("TotalLaborCost") = Configuration.FormatToString(CDec(ccRow("LabBudget")), dgt)
              itemTr("ActualLaborCost") = Configuration.FormatToString(CDec(ccRow("LabActual")), dgt)
              itemTr("LabDiff") = Configuration.FormatToString(CDec(ccRow("DiffLab")), dgt)
              '
              itemTr("TotalEquipmentCost") = Configuration.FormatToString(CDec(ccRow("EqBudget")), dgt)
              itemTr("ActualEquipmentCost") = Configuration.FormatToString(CDec(ccRow("EqActual")), dgt)
              itemTr("EqDiff") = Configuration.FormatToString(CDec(ccRow("DiffEq")), dgt)
              '
              itemTr("Total") = Configuration.FormatToString(CDec(ccRow("TotalBudget")), dgt)
              itemTr("Actual") = Configuration.FormatToString(CDec(ccRow("TotalActual")), dgt)
              itemTr("TotalDiff") = Configuration.FormatToString(CDec(ccRow("TotalDiff")), dgt)
              itemTr("TotalPercentDiff") = Configuration.FormatToString(CDec(ccRow("PercentDiff")), dgt) & " %"
              itemTr.State = RowExpandState.Expanded
              '----------------------------------------
            End If
          End If

        Else
          If Not ccRow.IsNull("inDirectCost") Then

            Select Case ccRow("inDirectType").ToString.ToLower
              Case "overhead"
                '----------------------------------------
                itemTr = costCenterTr.Childs.Add
                itemTr("boqi_itemname") = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.InDirectCost}") '"ค่าอำนวยการ(Overhead)"
                '
                totalBudget += CDec(ccRow("TotalBudget"))
                totalActual += CDec(ccRow("TotalActual"))
                totalDiff += CDec(ccRow("TotalDiff"))
                '
                itemTr("Total") = Configuration.FormatToString(CDec(ccRow("TotalBudget")), dgt)
                itemTr("Actual") = Configuration.FormatToString(CDec(ccRow("TotalActual")), dgt)
                itemTr("TotalDiff") = Configuration.FormatToString(CDec(ccRow("TotalDiff")), dgt)
                itemTr("TotalPercentDiff") = Configuration.FormatToString(CDec(ccRow("PercentDiff")), dgt) & " %"
                itemTr.State = RowExpandState.Expanded
                '---------------------------------------- 
              Case "profit"
                '----------------------------------------
                itemTr = costCenterTr.Childs.Add
                itemTr("boqi_itemname") = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.EstimateProfit}") '"กำไร<ประเมิน>"
                '
                totalBudget -= CDec(ccRow("TotalBudget"))
                totalActual -= CDec(ccRow("TotalActual"))
                totalDiff -= CDec(ccRow("TotalDiff"))

                grandProfit = CDec(ccRow("TotalDiff"))
                '
                itemTr("Total") = Configuration.FormatToString(CDec(ccRow("TotalBudget")), dgt)
                'itemTr("Actual") = Configuration.FormatToString(CDec(ccRow("TotalActual")), dgt)
                itemTr("TotalDiff") = Configuration.FormatToString(CDec(ccRow("TotalDiff")), dgt)
                'itemTr("TotalPercentDiff") = Configuration.FormatToString(CDec(ccRow("PercentDiff")), dgt) & " %"
                itemTr.State = RowExpandState.Expanded
                '----------------------------------------          
              Case "total"
                '----------------------------------------
                itemTr = costCenterTr.Childs.Add
                itemTr("boqi_itemname") = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.Total}")  '"Total"
                profit = totalDiff

                grandTotal = totalDiff
                '
                itemTr("Total") = Configuration.FormatToString(totalBudget, dgt)
                itemTr("Actual") = Configuration.FormatToString(totalActual, dgt)
                itemTr("TotalDiff") = Configuration.FormatToString(totalDiff, dgt)
                If totalBudget = 0 Then
                  itemTr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
                Else
                  itemTr("TotalPercentDiff") = Configuration.FormatToString((totalDiff / totalBudget) * 100, dgt) & " %"
                End If
                itemTr.State = RowExpandState.Expanded
                '----------------------------------------            
            End Select

          End If
        End If
      Next

      'สำหรับแถวสุดท้าย
      If Not costCenterTr Is Nothing AndAlso Not itemTr Is Nothing Then
        '----------------------------------------
        itemTr = costCenterTr.Childs.Add
        itemTr("boqi_itemname") = myStringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.NetProfit}") '"กำไร(ขาดทุน)สุทธิ"
        '
        itemTr("TotalDiff") = Configuration.FormatToString(grandTotal + grandProfit, dgt)
        'If profit = 0 Then
        '  itemTr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        'Else
        '  itemTr("TotalPercentDiff") = Configuration.FormatToString((totalDiff / profit) * 100, dgt) & " %"
        'End If
        itemTr.State = RowExpandState.Expanded
        '----------------------------------------
      End If

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
      'm_cc = New CostCenter
      'If TypeOf Me.Filters(0).Value Is CostCenter Then
      '  m_cc = CType(Me.Filters(0).Value, CostCenter)
      'End If
      'เปลี่ยนค่าที่จะส่งไป StoredProcedure ที่ส่งเป็น Object เป็น ID
      'If Not Me.Filters(0).Value Is DBNull.Value Then
      '  Me.Filters(0).Value = m_cc.Id
      'End If
      'If Not Me.Filters(6).Value Is Nothing AndAlso TypeOf Me.Filters(6).Value Is Employee Then
      '  Me.Filters(6).Value = Me.Filters(6).Value.Id
      'End If
      '
      'If Not m_cc Is Nothing AndAlso m_cc.Originated Then
      MyBase.RefreshDataSet()
      'End If
    End Sub
#End Region

    '#Region "Overrides"
    '        Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
    '            Return BOQ.GetWBSMonitorSchemaTable
    '        End Function
    '        Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
    '            Return BOQ.CreateWBSMonitorTableStyle
    '        End Function
    '        Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
    '            Me.m_treemanager = tm
    '            If TypeOf Me.Filters(0).Value Is Date Then
    '                Dim type As BOQ.WBSReportType = BOQ.WBSReportType.GoodsReceipt
    '                If TypeOf Me.Filters(3).Value Is BOQ.WBSReportType Then
    '                    type = CType(Me.Filters(3).Value, BOQ.WBSReportType)
    '                End If
    '                BOQ.PopulateWBSMonitorListing(tm, CDate(Me.Filters(0).Value), Me.Filters(1).Value, Me.Filters(2).Value, type)
    '            End If
    '        End Sub
    '        Public Overrides Sub RefreshDataSet()

    '        End Sub
    '#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptWBSBudgetByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSBudgetByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSBudgetByCC"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSBudgetByCC.ListLabel}"
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
      Return "RptWBSBudgetByCC"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptWBSBudgetByCC"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = CDate(Me.Filters(0).Value).ToShortDateString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterStart"
      dpi.Value = Me.Filters(1).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterEnd"
      dpi.Value = Me.Filters(2).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim n As Integer = 0
      Dim i As Integer = 0
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        If itemRow.IsNull("Total") OrElse CStr(itemRow("Total")).Length <= 0 Then
          i += 1
          dpi.Value = i
        End If
        'dpi.Value = itemRow("boqi_linenumber")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = itemRow("boqi_itemName")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        If itemRow.IsNull("Total") OrElse CStr(itemRow("Total")).Length <= 0 Then
          dpi.Font = New Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        End If
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = itemRow("TotalMaterialCost")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = itemRow("ActualMaterialCost")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = itemRow("MatDiff")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = itemRow("TotalLaborCost")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = itemRow("ActualLaborCost")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = itemRow("LabDiff")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = itemRow("TotalEquipmentCost")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = itemRow("ActualEquipmentCost")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col10"
        dpi.Value = itemRow("EqDiff")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = itemRow("Total")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col12"
        dpi.Value = itemRow("Actual")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col13"
        dpi.Value = itemRow("TotalDiff")
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col14"
        dpi.Value = itemRow("TotalPercentDiff")
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

