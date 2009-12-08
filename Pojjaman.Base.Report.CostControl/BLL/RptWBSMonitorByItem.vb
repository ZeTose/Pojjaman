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
  Public Class RptWBSMonitorByItem
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
      csTotal.Width = 90
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
      csTotalDiff.DataAlignment = HorizontalAlignment.Right
      csTotalDiff.Format = "#,###.##"
      csTotalDiff.TextBox.Name = "TotalDiff"
      csTotalDiff.ReadOnly = True

      Dim csTotalPercentDiff As New TreeTextColumn
      csTotalPercentDiff.MappingName = "TotalPerCentDiff"
      csTotalPercentDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PercentDiffHeaderText}")
      csTotalPercentDiff.NullText = ""
      csTotalPercentDiff.DataAlignment = HorizontalAlignment.Right
      'csTotalPercentDiff.Format = "#,###.##"
      csTotalPercentDiff.TextBox.Name = "TotalPerCentDiff"
      csTotalPercentDiff.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)

      dst.GridColumnStyles.Add(csBarrier0)

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
      myDatatable.Columns.Add(New DataColumn("TotalPerCentDiff", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Overrides"

    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return Me.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return Me.CreateWBSMonitorTableStyle
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
      '    Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '    dt.Clear()
      '    tm.Treetable = dt
      '    Return
      'End If
      'If m_cc.BoqId = 0 Then
      '    Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
      '    dt.Clear()
      '    tm.Treetable = dt
      '    Return
      'End If
      If TypeOf Me.Filters(1).Value Is Date Then
        Dim nodigit As Boolean = False
        If Me.Filters(5).Name.ToLower = "nodigit" Then
          nodigit = CBool(Me.Filters(5).Value)
        End If
        PopulateExpenseIncomeListing(tm.Treetable, CDate(Me.Filters(1).Value), nodigit)
      End If
    End Sub
    Public Sub PopulateExpenseIncomeListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()

      Dim dt0 As DataTable = Me.DataSet.Tables(0)
      Dim dt1 As DataTable = Me.DataSet.Tables(1)
      Dim dt2 As DataTable = Me.DataSet.Tables(2)

      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim ccNode As TreeRow = Nothing
      Dim itemParentNode As TreeRow = Nothing
      Dim wbsNode As TreeRow = Nothing

      Dim myTemp As String = ""
      Dim myTempPath As String = ""

      For Each rowCC As DataRow In dt0.Rows
        'Dim totalQuantity As Decimal = 0
        'Dim actualQuantity As Decimal = 0
        'Dim quantityDiff As Decimal = 0

        Dim totalMaterialCost As Decimal = 0
        Dim actualMaterialCost As Decimal = 0
        Dim matDiff As Decimal = 0

        Dim totalLaborCost As Decimal = 0
        Dim actualLaborCost As Decimal = 0
        Dim labDiff As Decimal = 0

        Dim totalEquipmentCost As Decimal = 0
        Dim actualEquipmentCost As Decimal = 0
        Dim eqDiff As Decimal = 0

        Dim total As Decimal = 0
        Dim actual As Decimal = 0
        Dim totalDiff As Decimal = 0

        ccNode = dt.Childs.Add
        ccNode("boqi_itemname") = rowCC("cc_name")

        For Each rowItem As DataRow In dt1.Select("cc_id=" & rowCC("cc_id"))
          itemParentNode = ccNode.Childs.Add
          itemParentNode("boqi_itemname") = rowItem("itemname")
          itemParentNode("Unit") = rowItem("UnitName")
          itemParentNode("TotalQuantity") = Configuration.FormatToString(CDec(rowItem("qtybudget")), dgt)
          itemParentNode("ActualQuantity") = Configuration.FormatToString(CDec(rowItem("qtyactual")), dgt)
          itemParentNode("QuantityDiff") = Configuration.FormatToString(CDec(rowItem("qtybudget")) - CDec(rowItem("qtyactual")), dgt)
          '
          itemParentNode("TotalMaterialCost") = Configuration.FormatToString(CDec(rowItem("matbudget")), dgt)
          itemParentNode("ActualMaterialCost") = Configuration.FormatToString(CDec(rowItem("matactual")), dgt)
          itemParentNode("MatDiff") = Configuration.FormatToString(CDec(rowItem("matbudget")) - CDec(rowItem("matactual")), dgt)
          '
          itemParentNode("TotalLaborCost") = Configuration.FormatToString(CDec(rowItem("labbudget")), dgt)
          itemParentNode("ActualLaborCost") = Configuration.FormatToString(CDec(rowItem("labactual")), dgt)
          itemParentNode("LabDiff") = Configuration.FormatToString(CDec(rowItem("labbudget")) - CDec(rowItem("labactual")), dgt)
          ' 
          itemParentNode("TotalEquipmentCost") = Configuration.FormatToString(CDec(rowItem("eqbudget")), dgt)
          itemParentNode("ActualEquipmentCost") = Configuration.FormatToString(CDec(rowItem("eqactual")), dgt)
          itemParentNode("EqDiff") = Configuration.FormatToString(CDec(rowItem("eqbudget")) - CDec(rowItem("eqactual")), dgt)
          '
          itemParentNode("Total") = Configuration.FormatToString(CDec(rowItem("totalbudget")), dgt)
          itemParentNode("Actual") = Configuration.FormatToString(CDec(rowItem("totalactual")), dgt)
          itemParentNode("TotalDiff") = Configuration.FormatToString(CDec(rowItem("totalbudget")) - CDec(rowItem("totalactual")), dgt)
          If CDec(rowItem("totalbudget")) = 0 Then
            itemParentNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
          Else
            itemParentNode("TotalPercentDiff") = Configuration.FormatToString(((CDec(rowItem("totalbudget")) - CDec(rowItem("totalactual"))) / CDec(rowItem("totalbudget"))) * 100, dgt) & " %"
          End If

          'totalQuantity += CDec(rowItem("qtybudget"))
          totalMaterialCost += CDec(rowItem("matbudget"))
          totalLaborCost += CDec(rowItem("labbudget"))
          totalEquipmentCost += CDec(rowItem("eqbudget"))

          'actualQuantity += CDec(rowItem("qtyactual"))
          actualMaterialCost += CDec(rowItem("matactual"))
          actualLaborCost += CDec(rowItem("labactual"))
          actualEquipmentCost += CDec(rowItem("eqactual"))

          total += CDec(rowItem("totalbudget")) 'totalMaterialCost + totalLaborCost + totalEquipmentCost
          actual += CDec(rowItem("totalactual"))

          If CInt(Me.Filters(9).Value) = 0 Then

            Dim ParentNode As TreeRow = Nothing
            Try
              For Each rowWbs As DataRow In dt2.Select("itemname='" & rowItem("itemname") & "'")
                If CInt(rowWbs("wbs_level")) = 0 Then
                  ParentNode = itemParentNode.Childs.Add
                Else
                  myParent = rowWbs("wbs_parent")
                  Try
                    ParentNode = Nodes(myParent).Childs.Add
                  Catch ex As Exception

                  End Try
                End If

                If Not ParentNode Is Nothing Then
                  Nodes(CStr(rowWbs("wbs_path"))) = ParentNode

                  'แสดงแต่ละ wbs
                  wbsNode = ParentNode

                  wbsNode("boqi_itemname") = rowWbs("wbs_code") & "-" & rowWbs("wbs_name")
                  'wbsNode("Unit") = "" 'rowItem("UnitName")
                  wbsNode("TotalQuantity") = Configuration.FormatToString(CDec(rowWbs("qtybudget")), dgt)
                  wbsNode("ActualQuantity") = Configuration.FormatToString(CDec(rowWbs("qtyactual")), dgt)
                  wbsNode("QuantityDiff") = Configuration.FormatToString(CDec(rowWbs("qtybudget")) - CDec(rowWbs("qtyactual")), dgt)
                  '
                  wbsNode("TotalMaterialCost") = Configuration.FormatToString(CDec(rowWbs("matbudget")), dgt)
                  wbsNode("ActualMaterialCost") = Configuration.FormatToString(CDec(rowWbs("matactual")), dgt)
                  wbsNode("MatDiff") = Configuration.FormatToString(CDec(rowWbs("matbudget")) - CDec(rowWbs("matactual")), dgt)
                  '
                  wbsNode("TotalLaborCost") = Configuration.FormatToString(CDec(rowWbs("labbudget")), dgt)
                  wbsNode("ActualLaborCost") = Configuration.FormatToString(CDec(rowWbs("labactual")), dgt)
                  wbsNode("LabDiff") = Configuration.FormatToString(CDec(rowWbs("labbudget")) - CDec(rowWbs("labactual")), dgt)
                  ' 
                  wbsNode("TotalEquipmentCost") = Configuration.FormatToString(CDec(rowWbs("eqbudget")), dgt)
                  wbsNode("ActualEquipmentCost") = Configuration.FormatToString(CDec(rowWbs("eqactual")), dgt)
                  wbsNode("EqDiff") = Configuration.FormatToString(CDec(rowWbs("eqbudget")) - CDec(rowWbs("eqactual")), dgt)
                  '
                  wbsNode("Total") = Configuration.FormatToString(CDec(rowWbs("totalbudget")), dgt)
                  wbsNode("Actual") = Configuration.FormatToString(CDec(rowWbs("totalactual")), dgt)
                  wbsNode("TotalDiff") = Configuration.FormatToString(CDec(rowWbs("totalbudget")) - CDec(rowWbs("totalactual")), dgt)
                  If CDec(rowWbs("totalbudget")) = 0 Then
                    wbsNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
                  Else
                    wbsNode("TotalPercentDiff") = Configuration.FormatToString(((CDec(rowWbs("totalbudget")) - CDec(rowWbs("totalactual"))) / CDec(rowWbs("totalbudget"))) * 100, dgt) & " %"
                  End If

                  wbsNode.State = RowExpandState.Expanded
                End If

              Next
            Catch ex As Exception
              MessageBox.Show(ex.Message)
            End Try

            itemParentNode.State = RowExpandState.Expanded

          End If
        Next

        'ccNode("TotalQuantity") = Configuration.FormatToString(totalQuantity, dgt)
        'ccNode("ActualQuantity") = Configuration.FormatToString(actualQuantity, dgt)
        'ccNode("QuantityDiff") = Configuration.FormatToString(totalQuantity - actualQuantity, dgt)
        '
        ccNode("TotalMaterialCost") = Configuration.FormatToString(totalMaterialCost, dgt)
        ccNode("ActualMaterialCost") = Configuration.FormatToString(actualMaterialCost, dgt)
        ccNode("MatDiff") = Configuration.FormatToString(totalMaterialCost - actualMaterialCost, dgt)
        '
        ccNode("TotalLaborCost") = Configuration.FormatToString(totalLaborCost, dgt)
        ccNode("ActualLaborCost") = Configuration.FormatToString(actualLaborCost, dgt)
        ccNode("LabDiff") = Configuration.FormatToString(totalLaborCost - actualLaborCost, dgt)
        ' 
        ccNode("TotalEquipmentCost") = Configuration.FormatToString(totalEquipmentCost, dgt)
        ccNode("ActualEquipmentCost") = Configuration.FormatToString(actualEquipmentCost, dgt)
        ccNode("EqDiff") = Configuration.FormatToString(totalEquipmentCost - actualEquipmentCost, dgt)
        '
        ccNode("Total") = Configuration.FormatToString(total, dgt)
        ccNode("Actual") = Configuration.FormatToString(actual, dgt)
        ccNode("TotalDiff") = Configuration.FormatToString(total - actual, dgt)

        ccNode.State = RowExpandState.Expanded
      Next

      Dim i As Integer = 0
      For Each row As DataRow In dt.Rows
        i += 1
        row("boqi_linenumber") = i
      Next
      If i > 0 Then
        dt.AcceptChanges()
      End If
    End Sub
    Private Function SumValueInDataTable(ByVal dr() As DataRow, ByVal field As String) As Decimal
      Dim ret As Decimal = 0
      For Each drtmp As DataRow In dr
        If Not drtmp.IsNull(field) Then
          ret += CDec(drtmp(field))
        End If
      Next
      Return ret
    End Function

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
      '
      'If Not m_cc Is Nothing AndAlso m_cc.Originated Then
      MyBase.RefreshDataSet()
      'End If
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptWBSMonitorByItem"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitorByItem.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitorByItem"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitorByItem"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitorByItem.ListLabel}"
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
      Return "RptWBSMonitorByItem"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = m_cc.Name
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      If Not IsDBNull(Me.Filters(1).Value) Then
        dpi.Value = CDate(Me.Filters(1).Value).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "WBSReportType"
      If Not IsDBNull(Me.Filters(3).Value) Then
        dpi.Value = Me.Filters(3).Value
      End If
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
      Dim barrierColl As String = ""
      Dim isBarier As Boolean = False
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        For itemcol As Integer = 1 To Me.Treemanager.Treetable.Columns.Count - 1
          barrierColl = Me.Treemanager.Treetable.Columns(itemcol).ColumnName.ToLower
          If barrierColl.IndexOf("barrier") = 0 Then
            isBarier = True
          Else
            isBarier = False
          End If
          If Not isBarier Then
            dpi = New DocPrintingItem
            dpi.Mapping = "col" & itemcol
            dpi.Value = itemRow(Me.Treemanager.Treetable.Columns(itemcol))
            dpi.DataType = "System.String"
            dpi.Row = i + 1
            dpi.Table = "Item"
            dpiColl.Add(dpi)
          End If
        Next
        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

