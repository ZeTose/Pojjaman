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
  Public Class RptWBSMonitor
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

      Dim csUnitPrice As New TreeTextColumn
      csUnitPrice.MappingName = "UnitPrice"
      csUnitPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitPriceHeaderText}")
      csUnitPrice.NullText = ""
      csUnitPrice.DataAlignment = HorizontalAlignment.Right
      csUnitPrice.Format = "#,###.##"
      csUnitPrice.TextBox.Name = "UnitPrice"
      csUnitPrice.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

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

      dst.GridColumnStyles.Add(csUnitPrice)
      dst.GridColumnStyles.Add(csUnit)

      dst.GridColumnStyles.Add(csBarrier1)

      'dst.GridColumnStyles.Add(csTotalQty)
      dst.GridColumnStyles.Add(csActualQty)
      'dst.GridColumnStyles.Add(csQtyDiff)

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

      myDatatable.Columns.Add(New DataColumn("UnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))

      'myDatatable.Columns.Add(New DataColumn("TotalQuantity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualQuantity", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("QuantityDiff", GetType(String)))

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
      myDatatable.Columns.Add(New DataColumn("DocID", GetType(Integer)))

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
      lkg.Cols.FrozenCount = 3
      m_grid.Model.Cols.Hidden(m_grid.ColCount) = True
      lkg.HilightGroupParentText = True
      lkg.RefreshHeights()
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
      If m_cc.BoqId = 0 Then
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        tm.Treetable = dt
        Return
      End If
      If TypeOf Me.Filters(1).Value Is Date Then
        Dim nodigit As Boolean = False
        If Me.Filters(5).Name.ToLower = "nodigit" Then
          nodigit = CBool(Me.Filters(5).Value)
        End If
        PopulateWBSMonitorListing(tm.Treetable, CDate(Me.Filters(1).Value), nodigit)
      End If
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
    Public Sub PopulateWBSMonitorListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()
      Dim dt2 As DataTable = Me.DataSet.Tables(0)
      Dim dt3 As DataTable = Me.DataSet.Tables(1)
      Dim dt4 As DataTable = Me.DataSet.Tables(2)
      dt2.TableName = "Table0"
      dt3.TableName = "Table1"
      dt4.TableName = "Table2"
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
      Dim tr As TreeRow
      Dim stage As String = ""
      Try
        'แบบไม่เลือก Option WBS 
        For Each wbsrow As DataRow In dt2.Rows
          If CInt(wbsrow("wbs_level")) = 0 Then
            parentNode = dt.Childs.Add
            SumNetWbsBudget += CDec(wbsrow("wbs_budget"))
            SumNetWBsActual += CDec(wbsrow("wbs_actual"))
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
            tr.Tag = wbsrow
            tr("boqi_itemname") = wbsrow("wbs_code") & "-" & wbsrow("wbs_name")
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
            tr("Total") = Configuration.FormatToString(CDec(wbsrow("wbs_budget")), dgt)
            tr("Actual") = Configuration.FormatToString(CDec(wbsrow("wbs_actual")), dgt)
            tr("TotalDiff") = Configuration.FormatToString(CDec(wbsrow("DiffAmount")), dgt)
            stage = "1"
            If CDec(wbsrow("wbs_budget")) = 0 Then
              tr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            Else
              tr("TotalPercentDiff") = Configuration.FormatToString((CDec(wbsrow("DiffAmount")) / CDec(wbsrow("wbs_budget"))) * 100, dgt) & " %"
            End If
            stage = "2"
            tr.State = RowExpandState.Expanded
          End If

          If CInt(Me.Filters(4).Value) > 0 Then
            Dim DocMatActual As Decimal = 0
            Dim DocLabActual As Decimal = 0
            Dim DocEqActual As Decimal = 0
            Dim DocAmount As Decimal = 0
            Dim myDocId As String = ""
            Dim Doctr As TreeRow = Nothing
            Dim DocItemTr As TreeRow = Nothing
            For Each wbsDoc As DataRow In dt4.Select("wbsid = " & wbsrow("wbs_id") & " and ismarkup = 0")

              If Not myDocId = CStr(wbsDoc("DocId")) Then
                If Not Doctr Is Nothing Then
                  Doctr("ActualMaterialCost") = Configuration.FormatToString(DocMatActual, dgt)
                  Doctr("ActualLaborCost") = Configuration.FormatToString(DocLabActual, dgt)
                  Doctr("ActualEquipmentCost") = Configuration.FormatToString(DocEqActual, dgt)
                  Doctr("Actual") = Configuration.FormatToString(DocAmount, dgt)
                  DocMatActual = 0
                  DocLabActual = 0
                  DocEqActual = 0
                  DocAmount = 0
                End If

                'แสดงเอกสารแต่ละตัว
                tr.State = RowExpandState.Expanded
                Doctr = tr.Childs.Add
                Doctr.Tag = wbsDoc
                Doctr("boqi_itemname") = "(เอกสาร) " & CStr(wbsDoc("DocCode"))
                Doctr.State = RowExpandState.None
                myDocId = CStr(wbsDoc("DocId"))
                Doctr("DocId") = myDocId
              End If

              If CInt(Me.Filters(4).Value) > 1 Then
                'แสดงรายการในแต่ละเอกสาร
                If Not Doctr Is Nothing Then
                  Doctr.State = RowExpandState.Expanded
                  DocItemTr = Doctr.Childs.Add
                  DocItemTr("boqi_itemname") = wbsDoc("itemName")
                  DocItemTr("UnitPrice") = Configuration.FormatToString(CDec(wbsDoc("UnitPrice")), dgt)
                  DocItemTr("Unit") = IIf(wbsDoc.IsNull("UnitName"), "", wbsDoc("UnitName"))
                  DocItemTr("ActualQuantity") = Configuration.FormatToString(CDec(wbsDoc("Qty")), dgt)
                  DocItemTr("ActualMaterialCost") = Configuration.FormatToString(CDec(wbsDoc("MatActual")), dgt)
                  DocItemTr("ActualLaborCost") = Configuration.FormatToString(CDec(wbsDoc("LabActual")), dgt)
                  DocItemTr("ActualEquipmentCost") = Configuration.FormatToString(CDec(wbsDoc("EqActual")), dgt)
                  DocItemTr("Actual") = Configuration.FormatToString(CDec(wbsDoc("Amount")), dgt)
                  DocItemTr.State = RowExpandState.None
                End If
              End If

              DocMatActual += CDec(wbsDoc("MatActual"))
              DocLabActual += CDec(wbsDoc("LabActual"))
              DocEqActual += CDec(wbsDoc("EqActual"))
              DocAmount += CDec(wbsDoc("Amount"))
            Next
            If Not Doctr Is Nothing Then
              Doctr("ActualMaterialCost") = Configuration.FormatToString(DocMatActual, dgt)
              Doctr("ActualLaborCost") = Configuration.FormatToString(DocLabActual, dgt)
              Doctr("ActualEquipmentCost") = Configuration.FormatToString(DocEqActual, dgt)
              Doctr("Actual") = Configuration.FormatToString(DocAmount, dgt)
            End If
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
                stage = "3"
                If tmpMarkAmt = 0 Then
                  overheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
                Else
                  overheadtr("TotalPercentDiff") = Configuration.FormatToString((tmpDiffAmt / tmpMarkAmt) * 100, dgt) & " %"
                End If
                stage = "4"
                tmpMarkAmt = 0
                tmpActAmt = 0
                tmpDiffAmt = 0
              End If

              overheadtr = overheadedtr.Childs.Add
              overheadtr.Tag = markuprow
              overheadtr("boqi_itemName") = markuprow("code_description")
              overheadtr.State = RowExpandState.Expanded
              overheadTemp = CStr(markuprow("code_order"))
            End If

            'แต่ละรายการ Markup
            If Not overheadtr Is Nothing Then
              markuptr = overheadtr.Childs.Add
              markuptr.Tag = markuprow
              markuptr("boqi_itemName") = markuprow("markup_name")
              markuptr("Total") = Configuration.FormatToString(CDec(markuprow("markup_totalamt")), dgt)
              markuptr("Actual") = Configuration.FormatToString(CDec(markuprow("amount")), dgt)
              markuptr("TotalDiff") = Configuration.FormatToString(CDec(markuprow("diffamount")), dgt)
              stage = "5"
              If CDec(markuprow("markup_totalamt")) = 0 Then
                markuptr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
              Else
                markuptr("TotalPercentDiff") = Configuration.FormatToString((CDec(markuprow("diffamount")) / CDec(markuprow("markup_totalamt"))) * 100, dgt) & " %"
              End If
              stage = "6"
              SumMarkAmount += CDec(markuprow("markup_totalamt"))
              SumActualAmout += CDec(markuprow("amount"))
              SumTotalDiffAmount += CDec(markuprow("diffamount"))
              tmpMarkAmt += CDec(markuprow("markup_totalamt"))
              tmpActAmt += CDec(markuprow("amount"))
              tmpDiffAmt += CDec(markuprow("diffamount"))
              markuptr.State = RowExpandState.Expanded
            End If

            'รายการแต่ละเอกสารในแต่ละ Markup
            If CInt(Me.Filters(4).Value) > 0 Then
              Dim DocMatActual As Decimal = 0
              Dim DocLabActual As Decimal = 0
              Dim DocEqActual As Decimal = 0
              Dim DocAmount As Decimal = 0
              'Dim myDocId As String = ""
              Dim myTempDoc As String = ""
              Dim DocMarkuptr As TreeRow = Nothing
              Dim DocMarkupItemTr As TreeRow = Nothing

              For Each markupdocrow As DataRow In dt4.Select("wbsid = " & markuprow("markup_id") & " and ismarkup = 1")
                If Not myTempDoc = CStr(markupdocrow("DocId")) Then
                  If Not DocMarkuptr Is Nothing Then
                    DocMarkuptr("Actual") = Configuration.FormatToString(DocAmount, dgt)
                  End If

                  'แสดงเอกสารแต่ละตัว
                  DocMarkuptr = markuptr.Childs.Add
                  DocMarkuptr = markupdocrow
                  DocMarkuptr("boqi_itemname") = markupdocrow("DocCode")
                  'tr("Actual") = Configuration.FormatToString(SumValueInDataTable(dt3.Select(myQuery), "Amt"), dgt)
                  DocMarkuptr.State = RowExpandState.Expanded
                  myTempDoc = CStr(markupdocrow("DocId"))
                End If

                If CInt(Me.Filters(4).Value) > 1 Then
                  If Not DocMarkuptr Is Nothing Then
                    'แสดงรายการในแต่ละเอกสาร
                    DocMarkupItemTr = DocMarkuptr.Childs.Add
                    DocMarkupItemTr("boqi_itemname") = markupdocrow("itemName")
                    DocMarkupItemTr("Unit") = IIf(markupdocrow.IsNull("UnitName"), "", markupdocrow("UnitName"))
                    DocMarkupItemTr("ActualQuantity") = Configuration.FormatToString(CDec(markupdocrow("Qty")), dgt)
                    DocMarkupItemTr("Actual") = Configuration.FormatToString(CDec(markupdocrow("Amount")), dgt)
                    DocMarkupItemTr.State = RowExpandState.None
                  End If
                End If

                DocAmount += CDec(markupdocrow("Amount"))
              Next
              If Not DocMarkuptr Is Nothing Then
                DocMarkuptr("Actual") = Configuration.FormatToString(DocAmount, dgt)
              End If
            End If
          Next

          If Not overheadtr Is Nothing Then
            overheadtr("Total") = Configuration.FormatToString(tmpMarkAmt, dgt)
            overheadtr("Actual") = Configuration.FormatToString(tmpActAmt, dgt)
            overheadtr("TotalDiff") = Configuration.FormatToString(tmpDiffAmt, dgt)
            stage = "7"
            If tmpMarkAmt = 0 Then
              overheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            Else
              overheadtr("TotalPercentDiff") = Configuration.FormatToString((tmpDiffAmt / tmpMarkAmt) * 100, dgt) & " %"
            End If
            stage = "8"
            tmpMarkAmt = 0
            tmpActAmt = 0
            tmpDiffAmt = 0
          End If
        End If

        overheadedtr("Total") = Configuration.FormatToString(SumMarkAmount, dgt)
        overheadedtr("Actual") = Configuration.FormatToString(SumActualAmout, dgt)
        overheadedtr("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount, dgt)
        stage = "9"
        If SumMarkAmount = 0 Then
          overheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        Else
          overheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumTotalDiffAmount / SumMarkAmount) * 100, dgt) & " %"
        End If
        stage = "10"
        overheadedtr.State = RowExpandState.Expanded
        '#######################################################################################################

        'TOTAL #################################################################################################
        '#######################################################################################################
        Dim totalNode As TreeRow = dt.Childs.Add
        totalNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Total}")
        totalNode("Total") = Configuration.FormatToString(SumMarkAmount + SumNetWbsBudget, dgt)
        totalNode("Actual") = Configuration.FormatToString(SumActualAmout + SumNetWBsActual, dgt)
        totalNode("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount + SumNetWBsDiff, dgt)
        stage = "11"
        If SumMarkAmount + SumNetWbsBudget = 0 Then
          totalNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        Else
          totalNode("TotalPercentDiff") = Configuration.FormatToString(((SumTotalDiffAmount + SumNetWBsDiff) / (SumMarkAmount + SumNetWbsBudget)) * 100, dgt) & " %"
        End If
        stage = "12"
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
            stage = "13"
            'If CDec(profitrow("markup_totalamt")) = 0 Then
            '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            'Else
            '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString((CDec(profitrow("diffamount")) / CDec(profitrow("markup_totalamt"))) * 100, dgt) & " %"
            'End If
            stage = "14"
            SumProfitAmt += CDec(profitrow("markup_totalamt"))
            SumProfitActualAmt += CDec(profitrow("amount"))
            SumDiffProfitAmt += CDec(profitrow("diffamount"))
            profitheadtr.State = RowExpandState.Expanded
          Next
        End If

        profitheadedtr("Total") = Configuration.FormatToString(SumProfitAmt, dgt)
        'profitheadedtr("Actual") = Configuration.FormatToString(SumProfitActualAmt, dgt)
        profitheadedtr("TotalDiff") = Configuration.FormatToString(SumDiffProfitAmt, dgt)
        stage = "15"
        'If SumProfitAmt = 0 Then
        '    profitheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        'Else
        '    profitheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumDiffProfitAmt / SumProfitAmt) * 100, dgt) & " %"
        'End If
        stage = "16"
        profitheadedtr.State = RowExpandState.Expanded
        '#######################################################################################################

        'NET PROFIT ############################################################################################
        '#######################################################################################################
        Dim netNode As TreeRow = dt.Childs.Add
        netNode("boqi_itemName") = Me.StringParserService.Parse("กำไร(ขาดทุน)สุทธิ")
        'netNode("Total") = Configuration.FormatToString(NetProfitTotal, dgt)
        'netNode("Actual") = Configuration.FormatToString(NetProfitActual, dgt)
        netNode("TotalDiff") = Configuration.FormatToString(SumTotalDiffAmount + SumNetWBsDiff + SumDiffProfitAmt, dgt)
        stage = "17"
        'If (SumTotalDiffAmount + SumNetWBsDiff) = 0 Then
        '    netNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        'Else
        '    netNode("TotalPercentDiff") = Configuration.FormatToString(((SumTotalDiffAmount + SumNetWBsDiff - SumDiffProfitAmt) / (SumTotalDiffAmount + SumNetWBsDiff)) * 100, dgt) & " %"
        'End If
        stage = "18"
        netNode.State = RowExpandState.Expanded
        '#######################################################################################################


        Dim i As Integer = 0
        'For Each row As DataRow In dt.Rows
        '  i += 1
        '  row("boqi_linenumber") = i
        'Next
        m_hashData = New Hashtable
        For Each row As TreeRow In dt.Rows
          i += 1
          row("boqi_linenumber") = i
          If Not row.Tag Is Nothing Then
            m_hashData(i) = row.Tag
          End If
        Next
        If i > 0 Then
          dt.AcceptChanges()
        End If
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
      If Not m_cc Is Nothing AndAlso m_cc.Originated Then
        MyBase.RefreshDataSet()
      End If
    End Sub
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
        Return "RptWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitor.DetailLabel}"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitor.ListLabel}"
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

