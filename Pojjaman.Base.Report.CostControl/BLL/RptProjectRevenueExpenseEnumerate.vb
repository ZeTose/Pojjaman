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
  Public Class RptProjectRevenueExpenseEnumerate
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
      dst.MappingName = "RevExp"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csCostCenterCode As New TreeTextColumn
      csCostCenterCode.MappingName = "cc_code"
      csCostCenterCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CostCenterCODEHeaderText}")
      csCostCenterCode.NullText = ""
      csCostCenterCode.Width = 120
      csCostCenterCode.DataAlignment = HorizontalAlignment.Left
      csCostCenterCode.ReadOnly = True
      csCostCenterCode.TextBox.Name = "cc_code"

      Dim csCostCenterName As New PlusMinusTreeTextColumn
      csCostCenterName.MappingName = "cc_Name"
      csCostCenterName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CostCenterNameHeaderText}")
      csCostCenterName.NullText = ""
      csCostCenterName.Width = 248
      csCostCenterName.TextBox.Name = "cc_name"
      csCostCenterName.ReadOnly = True

      Dim csBarrier0 As New TreeTextColumn 'DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.Width = 25
      csBarrier0.ReadOnly = True

      Dim csPrice As New TreeTextColumn
      csPrice.MappingName = "price"
      csPrice.HeaderText = "Price" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csPrice.NullText = ""
      csPrice.DataAlignment = HorizontalAlignment.Center
      csPrice.Format = "#,###.##"
      csPrice.Width = 0
      csPrice.TextBox.Name = "price"
      csPrice.ReadOnly = True

      Dim csMain As New TreeTextColumn
      csMain.MappingName = "main"
      csMain.HeaderText = "Main" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csMain.NullText = ""
      csMain.DataAlignment = HorizontalAlignment.Right
      csMain.Format = "#,###.##"
      csMain.Width = 100
      csMain.TextBox.Name = "main"
      csMain.ReadOnly = True

      Dim csVO As New TreeTextColumn
      csVO.MappingName = "vo"
      csVO.HeaderText = "VO" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csVO.NullText = ""
      csVO.DataAlignment = HorizontalAlignment.Right
      csVO.Format = "#,###.##"
      csVO.Width = 100
      csVO.TextBox.Name = "vo"
      csVO.ReadOnly = True

      Dim csPenalty As New TreeTextColumn
      csPenalty.MappingName = "penalty"
      csPenalty.HeaderText = "Penalty" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csPenalty.NullText = ""
      csPenalty.DataAlignment = HorizontalAlignment.Right
      csPenalty.Format = "#,###.##"
      csPenalty.Width = 100
      csPenalty.TextBox.Name = "penalty"
      csPenalty.ReadOnly = True

      Dim csOther As New TreeTextColumn
      csOther.MappingName = "other"
      csOther.HeaderText = "Other" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csOther.NullText = ""
      csOther.DataAlignment = HorizontalAlignment.Right
      csOther.Format = "#,###.##"
      csOther.Width = 100
      csOther.TextBox.Name = "other"
      csOther.ReadOnly = True

      Dim csBf As New TreeTextColumn
      csBf.MappingName = "bf"
      csBf.HeaderText = "BF" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csBf.NullText = ""
      csBf.DataAlignment = HorizontalAlignment.Right
      csBf.Format = "#,###.##"
      csBf.Width = 100
      csBf.TextBox.Name = "Bf"
      csBf.ReadOnly = True

      Dim csTotal As New TreeTextColumn
      csTotal.MappingName = "total"
      csTotal.HeaderText = "Total" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csTotal.NullText = ""
      csTotal.DataAlignment = HorizontalAlignment.Right
      csTotal.Format = "#,###.##"
      csTotal.Width = 100
      csTotal.TextBox.Name = "total"
      csTotal.ReadOnly = True

      Dim csBarrier1 As New TreeTextColumn 'DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.Width = 25
      csBarrier1.ReadOnly = True

      Dim csReceivedHeader As New TreeTextColumn
      csReceivedHeader.MappingName = "receivedheader"
      csReceivedHeader.HeaderText = "Receivedheader" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedHeader.NullText = ""
      csReceivedHeader.DataAlignment = HorizontalAlignment.Center
      csReceivedHeader.Format = "#,###.##"
      csReceivedHeader.Width = 0
      csReceivedHeader.TextBox.Name = "receivedheader"
      csReceivedHeader.ReadOnly = True

      Dim csDeliver As New TreeTextColumn
      csDeliver.MappingName = "deliver"
      csDeliver.HeaderText = "Deliver" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csDeliver.NullText = ""
      csDeliver.DataAlignment = HorizontalAlignment.Right
      csDeliver.Format = "#,###.##"
      csDeliver.Width = 100
      csDeliver.TextBox.Name = "deliver"
      csDeliver.ReadOnly = True

      Dim csBill As New TreeTextColumn
      csBill.MappingName = "bill"
      csBill.HeaderText = "Bill" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csBill.NullText = ""
      csBill.DataAlignment = HorizontalAlignment.Right
      csBill.Format = "#,###.##"
      csBill.Width = 100
      csBill.TextBox.Name = "bill"
      csBill.ReadOnly = True

      Dim csReceived As New TreeTextColumn
      csReceived.MappingName = "received"
      csReceived.HeaderText = "Received" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceived.NullText = ""
      csReceived.DataAlignment = HorizontalAlignment.Right
      csReceived.Format = "#,###.##"
      csReceived.Width = 100
      csReceived.TextBox.Name = "received"
      csReceived.ReadOnly = True

      Dim csRetention As New TreeTextColumn
      csRetention.MappingName = "retention"
      csRetention.HeaderText = "Retention" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRetention.NullText = ""
      csRetention.DataAlignment = HorizontalAlignment.Right
      csRetention.Format = "#,###.##"
      csRetention.Width = 100
      csRetention.TextBox.Name = "retention"
      csRetention.ReadOnly = True

      Dim csAdvance As New TreeTextColumn
      csAdvance.MappingName = "advance"
      csAdvance.HeaderText = "Advance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csAdvance.NullText = ""
      csAdvance.DataAlignment = HorizontalAlignment.Right
      csAdvance.Format = "#,###.##"
      csAdvance.Width = 100
      csAdvance.TextBox.Name = "advance"
      csAdvance.ReadOnly = True

      Dim csRemain As New TreeTextColumn
      csRemain.MappingName = "remain"
      csRemain.HeaderText = "Remain" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemain.NullText = ""
      csRemain.DataAlignment = HorizontalAlignment.Right
      csRemain.Format = "#,###.##"
      csRemain.Width = 100
      csRemain.TextBox.Name = "remain"
      csRemain.ReadOnly = True

      Dim csBarrier2 As New TreeTextColumn 'DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.Width = 25
      csBarrier2.ReadOnly = True

      Dim csCost As New TreeTextColumn
      csCost.MappingName = "cost"
      csCost.HeaderText = "Cost" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csCost.NullText = ""
      csCost.DataAlignment = HorizontalAlignment.Center
      csCost.Format = "#,###.##"
      csCost.Width = 0
      csCost.TextBox.Name = "cost"
      csCost.ReadOnly = True

      Dim csBudget As New TreeTextColumn
      csBudget.MappingName = "budget"
      csBudget.HeaderText = "Budget" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csBudget.NullText = ""
      csBudget.DataAlignment = HorizontalAlignment.Right
      csBudget.Format = "#,###.##"
      csBudget.Width = 100
      csBudget.TextBox.Name = "budget"
      csBudget.ReadOnly = True

      Dim csPOActual As New TreeTextColumn
      csPOActual.MappingName = "poactual"
      csPOActual.HeaderText = "PO Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csPOActual.NullText = ""
      csPOActual.DataAlignment = HorizontalAlignment.Right
      csPOActual.Format = "#,###.##"
      csPOActual.Width = 100
      csPOActual.TextBox.Name = "poactual"
      csPOActual.ReadOnly = True

      Dim csPOActualBalance As New TreeTextColumn
      csPOActualBalance.MappingName = "poactualbalance"
      csPOActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csPOActualBalance.NullText = ""
      csPOActualBalance.DataAlignment = HorizontalAlignment.Right
      csPOActualBalance.Format = "#,###.##"
      csPOActualBalance.Width = 100
      csPOActualBalance.TextBox.Name = "poactualbalance"
      csPOActualBalance.ReadOnly = True

      Dim csGRActual As New TreeTextColumn
      csGRActual.MappingName = "gractual"
      csGRActual.HeaderText = "GR Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csGRActual.NullText = ""
      csGRActual.DataAlignment = HorizontalAlignment.Right
      csGRActual.Format = "#,###.##"
      csGRActual.Width = 100
      csGRActual.TextBox.Name = "gractual"
      csGRActual.ReadOnly = True

      Dim csGRActualBalance As New TreeTextColumn
      csGRActualBalance.MappingName = "gractualbalance"
      csGRActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csGRActualBalance.NullText = ""
      csGRActualBalance.DataAlignment = HorizontalAlignment.Right
      csGRActualBalance.Format = "#,###.##"
      csGRActualBalance.Width = 100
      csGRActualBalance.TextBox.Name = "gractualbalance"
      csGRActualBalance.ReadOnly = True

      Dim csBarrier3 As New TreeTextColumn 'DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
      csBarrier3.Width = 25
      csBarrier3.ReadOnly = True

      Dim csProfit As New TreeTextColumn
      csProfit.MappingName = "profit"
      csProfit.HeaderText = "Profit" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csProfit.NullText = ""
      csProfit.DataAlignment = HorizontalAlignment.Center
      csProfit.Format = "#,###.##"
      csProfit.Width = 0
      csProfit.TextBox.Name = "profit"
      csProfit.ReadOnly = True

      Dim csContractBudget As New TreeTextColumn
      csContractBudget.MappingName = "contractbudget"
      csContractBudget.HeaderText = "Costract - Budget" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractBudget.NullText = ""
      csContractBudget.DataAlignment = HorizontalAlignment.Center
      csContractBudget.Format = "#,###.##"
      csContractBudget.Width = 0
      csContractBudget.TextBox.Name = "contractbudget"
      csContractBudget.ReadOnly = True

      Dim csContractBudgetPrice As New TreeTextColumn
      csContractBudgetPrice.MappingName = "contractbudgetprice"
      csContractBudgetPrice.HeaderText = "Price" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractBudgetPrice.NullText = ""
      csContractBudgetPrice.DataAlignment = HorizontalAlignment.Right
      csContractBudgetPrice.Format = "#,###.##"
      csContractBudgetPrice.Width = 100
      csContractBudgetPrice.TextBox.Name = "contractbudgetprice"
      csContractBudgetPrice.ReadOnly = True

      Dim csContractBudgetEstimate As New TreeTextColumn
      csContractBudgetEstimate.MappingName = "estimatebudget"
      csContractBudgetEstimate.HeaderText = "Estimate Budget" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractBudgetEstimate.NullText = ""
      csContractBudgetEstimate.DataAlignment = HorizontalAlignment.Right
      csContractBudgetEstimate.Format = "#,###.##"
      csContractBudgetEstimate.Width = 100
      csContractBudgetEstimate.TextBox.Name = "estimatebudget"
      csContractBudgetEstimate.ReadOnly = True

      Dim csContractBudgetProfitLost As New TreeTextColumn
      csContractBudgetProfitLost.MappingName = "profitloss"
      csContractBudgetProfitLost.HeaderText = "กำไร/ขาดทุน" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractBudgetProfitLost.NullText = ""
      csContractBudgetProfitLost.DataAlignment = HorizontalAlignment.Right
      csContractBudgetProfitLost.Format = "#,###.##"
      csContractBudgetProfitLost.Width = 100
      csContractBudgetProfitLost.TextBox.Name = "profitloss"
      csContractBudgetProfitLost.ReadOnly = True

      Dim csBarrier7 As New DataGridBarrierColumn 'DataGridBarrierColumn
      csBarrier7.MappingName = "Barrier7"
      csBarrier7.HeaderText = ""
      csBarrier7.NullText = ""
      'csBarrier7.Width = 25
      csBarrier7.ReadOnly = True

      Dim csContractPOActual As New TreeTextColumn
      csContractPOActual.MappingName = "ContractPOActual"
      csContractPOActual.HeaderText = "Contract - PO Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractPOActual.NullText = ""
      csContractPOActual.DataAlignment = HorizontalAlignment.Center
      csContractPOActual.Format = "#,###.##"
      csContractPOActual.Width = 0
      csContractPOActual.TextBox.Name = "ContractPOActual"
      csContractPOActual.ReadOnly = True

      Dim csContractPOActualPrice As New TreeTextColumn
      csContractPOActualPrice.MappingName = "ContractPOActualPrice"
      csContractPOActualPrice.HeaderText = "Budget" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractPOActualPrice.NullText = ""
      csContractPOActualPrice.DataAlignment = HorizontalAlignment.Right
      csContractPOActualPrice.Format = "#,###.##"
      csContractPOActualPrice.Width = 100
      csContractPOActualPrice.TextBox.Name = "ContractPOActualPrice"
      csContractPOActualPrice.ReadOnly = True

      Dim csContractPOActual_GRActual As New TreeTextColumn
      csContractPOActual_GRActual.MappingName = "ContractPOActual_GRActual"
      csContractPOActual_GRActual.HeaderText = "PO Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractPOActual_GRActual.NullText = ""
      csContractPOActual_GRActual.DataAlignment = HorizontalAlignment.Right
      csContractPOActual_GRActual.Format = "#,###.##"
      csContractPOActual_GRActual.Width = 100
      csContractPOActual_GRActual.TextBox.Name = "ContractPOActual_GRActual"
      csContractPOActual_GRActual.ReadOnly = True

      Dim csContractPOActualBalance As New TreeTextColumn
      csContractPOActualBalance.MappingName = "ContractPOActualBalance"
      csContractPOActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractPOActualBalance.NullText = ""
      csContractPOActualBalance.DataAlignment = HorizontalAlignment.Right
      csContractPOActualBalance.Format = "#,###.##"
      csContractPOActualBalance.Width = 100
      csContractPOActualBalance.TextBox.Name = "ContractPOActualBalance"
      csContractPOActualBalance.ReadOnly = True

      Dim csBarrier8 As New DataGridBarrierColumn 'DataGridBarrierColumn
      csBarrier8.MappingName = "Barrier8"
      csBarrier8.HeaderText = ""
      csBarrier8.NullText = ""
      'csBarrier8.Width = 25
      csBarrier8.ReadOnly = True

      Dim csReceivedPOActual As New TreeTextColumn
      csReceivedPOActual.MappingName = "ReceivedPOActual"
      csReceivedPOActual.HeaderText = "Received - PO Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedPOActual.NullText = ""
      csReceivedPOActual.DataAlignment = HorizontalAlignment.Center
      csReceivedPOActual.Format = "#,###.##"
      csReceivedPOActual.Width = 0
      csReceivedPOActual.TextBox.Name = "ReceivedPOActual"
      csReceivedPOActual.ReadOnly = True

      Dim csReceivedPOActualPrice As New TreeTextColumn
      csReceivedPOActualPrice.MappingName = "ReceivedPOActualPrice"
      csReceivedPOActualPrice.HeaderText = "Received" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedPOActualPrice.NullText = ""
      csReceivedPOActualPrice.DataAlignment = HorizontalAlignment.Right
      csReceivedPOActualPrice.Format = "#,###.##"
      csReceivedPOActualPrice.Width = 100
      csReceivedPOActualPrice.TextBox.Name = "ReceivedPOActualPrice"
      csReceivedPOActualPrice.ReadOnly = True

      Dim csReceivedPOActual_GRActual As New TreeTextColumn
      csReceivedPOActual_GRActual.MappingName = "ReceivedPOActual_GRActual"
      csReceivedPOActual_GRActual.HeaderText = "PO Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedPOActual_GRActual.NullText = ""
      csReceivedPOActual_GRActual.DataAlignment = HorizontalAlignment.Right
      csReceivedPOActual_GRActual.Format = "#,###.##"
      csReceivedPOActual_GRActual.Width = 100
      csReceivedPOActual_GRActual.TextBox.Name = "ReceivedPOActual_GRActual"
      csReceivedPOActual_GRActual.ReadOnly = True

      Dim csReceivedPOActualBalance As New TreeTextColumn
      csReceivedPOActualBalance.MappingName = "ReceivedPOActualBalance"
      csReceivedPOActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedPOActualBalance.NullText = ""
      csReceivedPOActualBalance.DataAlignment = HorizontalAlignment.Right
      csReceivedPOActualBalance.Format = "#,###.##"
      csReceivedPOActualBalance.Width = 100
      csReceivedPOActualBalance.TextBox.Name = "ReceivedPOActualBalance"
      csReceivedPOActualBalance.ReadOnly = True




      'Dim csContractBudgetPercent As New TreeTextColumn
      'csContractBudgetPercent.MappingName = "contractbudgetpercent"
      'csContractBudgetPercent.HeaderText = "(%)" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      'csContractBudgetPercent.NullText = ""
      'csContractBudgetPercent.DataAlignment = HorizontalAlignment.Right
      'csContractBudgetPercent.Format = "#,###.##"
      'csContractBudgetPercent.Width = 0
      'csContractBudgetPercent.TextBox.Name = "contractbudgetpercent"
      'csContractBudgetPercent.ReadOnly = True

      Dim csBarrier4 As New DataGridBarrierColumn
      csBarrier4.MappingName = "Barrier4"
      csBarrier4.HeaderText = ""
      csBarrier4.NullText = ""
      'csBarrier4.Width = 25
      csBarrier4.ReadOnly = True

      Dim csReceivedActual As New TreeTextColumn
      csReceivedActual.MappingName = "receivedactual"
      csReceivedActual.HeaderText = "Received - Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedActual.NullText = ""
      csReceivedActual.DataAlignment = HorizontalAlignment.Center
      csReceivedActual.Format = "#,###.##"
      csReceivedActual.Width = 0
      csReceivedActual.TextBox.Name = "receivedactual"
      csReceivedActual.ReadOnly = True

      Dim csReceivedActualPrice As New TreeTextColumn
      csReceivedActualPrice.MappingName = "ReceivedActualPrice"
      csReceivedActualPrice.HeaderText = "Price" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedActualPrice.NullText = ""
      csReceivedActualPrice.DataAlignment = HorizontalAlignment.Right
      csReceivedActualPrice.Format = "#,###.##"
      csReceivedActualPrice.Width = 100
      csReceivedActualPrice.TextBox.Name = "ReceivedActualprice"
      csReceivedActualPrice.ReadOnly = True

      Dim csReceivedActual_GRActual As New TreeTextColumn
      csReceivedActual_GRActual.MappingName = "ReceivedActual_GRActual"
      csReceivedActual_GRActual.HeaderText = "GR Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedActual_GRActual.NullText = ""
      csReceivedActual_GRActual.DataAlignment = HorizontalAlignment.Right
      csReceivedActual_GRActual.Format = "#,###.##"
      csReceivedActual_GRActual.Width = 100
      csReceivedActual_GRActual.TextBox.Name = "ReceivedActual_GRActual"
      csReceivedActual_GRActual.ReadOnly = True

      Dim csReceivedActualBalance As New TreeTextColumn
      csReceivedActualBalance.MappingName = "ReceivedActualBalance"
      csReceivedActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedActualBalance.NullText = ""
      csReceivedActualBalance.DataAlignment = HorizontalAlignment.Right
      csReceivedActualBalance.Format = "#,###.##"
      csReceivedActualBalance.Width = 100
      csReceivedActualBalance.TextBox.Name = "ReceivedActualBalance"
      csReceivedActualBalance.ReadOnly = True

      'Dim csReceivedActualPercent As New TreeTextColumn
      'csReceivedActualPercent.MappingName = "ReceivedActualPercent"
      'csReceivedActualPercent.HeaderText = "(%)" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      'csReceivedActualPercent.NullText = ""
      'csReceivedActualPercent.DataAlignment = HorizontalAlignment.Right
      'csReceivedActualPercent.Format = "#,###.##"
      'csReceivedActualPercent.Width = 0
      'csReceivedActualPercent.TextBox.Name = "ReceivedActualPercent"
      'csReceivedActualPercent.ReadOnly = True

      Dim csBarrier5 As New DataGridBarrierColumn
      csBarrier5.MappingName = "Barrier5"
      csBarrier5.HeaderText = ""
      csBarrier5.NullText = ""
      'csBarrier5.Width = 25
      csBarrier5.ReadOnly = True

      Dim csRemainComplete As New TreeTextColumn
      csRemainComplete.MappingName = "RemainComplete"
      csRemainComplete.HeaderText = "Remain - Complete" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemainComplete.NullText = ""
      csRemainComplete.DataAlignment = HorizontalAlignment.Center
      csRemainComplete.Format = "#,###.##"
      csRemainComplete.Width = 0
      csRemainComplete.TextBox.Name = "RemainComplete"
      csRemainComplete.ReadOnly = True

      Dim csRemainCompleteReceived As New TreeTextColumn
      csRemainCompleteReceived.MappingName = "RemainCompleteReceived"
      csRemainCompleteReceived.HeaderText = "Price" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemainCompleteReceived.NullText = ""
      csRemainCompleteReceived.DataAlignment = HorizontalAlignment.Right
      csRemainCompleteReceived.Format = "#,###.##"
      csRemainCompleteReceived.Width = 100
      csRemainCompleteReceived.TextBox.Name = "RemainCompleteReceived"
      csRemainCompleteReceived.ReadOnly = True

      Dim csRemainComplete_GRActual As New TreeTextColumn
      csRemainComplete_GRActual.MappingName = "RemainComplete_GRActual"
      csRemainComplete_GRActual.HeaderText = "GR Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemainComplete_GRActual.NullText = ""
      csRemainComplete_GRActual.DataAlignment = HorizontalAlignment.Right
      csRemainComplete_GRActual.Format = "#,###.##"
      csRemainComplete_GRActual.Width = 100
      csRemainComplete_GRActual.TextBox.Name = "RemainComplete_GRActual"
      csRemainComplete_GRActual.ReadOnly = True

      Dim csRemainCompleteBalance As New TreeTextColumn
      csRemainCompleteBalance.MappingName = "RemainCompleteBalance"
      csRemainCompleteBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemainCompleteBalance.NullText = ""
      csRemainCompleteBalance.DataAlignment = HorizontalAlignment.Right
      csRemainCompleteBalance.Format = "#,###.##"
      csRemainCompleteBalance.Width = 100
      csRemainCompleteBalance.TextBox.Name = "RemainCompleteBalance"
      csRemainCompleteBalance.ReadOnly = True

      'Dim csRemainCompletePercent As New TreeTextColumn
      'csRemainCompletePercent.MappingName = "RemainCompletePercent"
      'csRemainCompletePercent.HeaderText = "(%)" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      'csRemainCompletePercent.NullText = ""
      'csRemainCompletePercent.DataAlignment = HorizontalAlignment.Right
      'csRemainCompletePercent.Format = "#,###.##"
      'csRemainCompletePercent.Width = 0
      'csRemainCompletePercent.TextBox.Name = "RemainCompletePercent"
      'csRemainCompletePercent.ReadOnly = True

      Dim csBarrier6 As New TreeTextColumn 'DataGridBarrierColumn
      csBarrier6.MappingName = "Barrier6"
      csBarrier6.HeaderText = ""
      csBarrier6.NullText = ""
      csBarrier6.Width = 25
      csBarrier6.ReadOnly = True

      Dim csDateComplete As New TreeTextColumn
      csDateComplete.MappingName = "DateComplete"
      csDateComplete.HeaderText = "Date Complete" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csDateComplete.NullText = ""
      csDateComplete.DataAlignment = HorizontalAlignment.Center
      csDateComplete.Width = 90
      csDateComplete.TextBox.Name = "DateComplete"
      csDateComplete.ReadOnly = True

      dst.GridColumnStyles.Add(csCostCenterCode)
      dst.GridColumnStyles.Add(csCostCenterName)

      dst.GridColumnStyles.Add(csBarrier0)
      dst.GridColumnStyles.Add(csPrice)
      dst.GridColumnStyles.Add(csMain)
      dst.GridColumnStyles.Add(csVO)
      dst.GridColumnStyles.Add(csPenalty)
      dst.GridColumnStyles.Add(csOther)
      dst.GridColumnStyles.Add(csBf)
      dst.GridColumnStyles.Add(csTotal)

      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csReceivedHeader)
      dst.GridColumnStyles.Add(csDeliver)
      dst.GridColumnStyles.Add(csBill)
      dst.GridColumnStyles.Add(csReceived)
      dst.GridColumnStyles.Add(csRetention)
      dst.GridColumnStyles.Add(csAdvance)
      dst.GridColumnStyles.Add(csRemain)

      dst.GridColumnStyles.Add(csBarrier2)
      dst.GridColumnStyles.Add(csBudget)
      dst.GridColumnStyles.Add(csPOActual)
      dst.GridColumnStyles.Add(csPOActualBalance)
      dst.GridColumnStyles.Add(csGRActual)
      dst.GridColumnStyles.Add(csGRActualBalance)

      dst.GridColumnStyles.Add(csBarrier3)
      dst.GridColumnStyles.Add(csProfit)
      dst.GridColumnStyles.Add(csContractBudget)
      dst.GridColumnStyles.Add(csContractBudgetPrice)
      dst.GridColumnStyles.Add(csContractBudgetEstimate)
      dst.GridColumnStyles.Add(csContractBudgetProfitLost)
      'dst.GridColumnStyles.Add(csContractBudgetPercent)

      dst.GridColumnStyles.Add(csBarrier7)
      dst.GridColumnStyles.Add(csContractPOActual)
      dst.GridColumnStyles.Add(csContractPOActualPrice)
      dst.GridColumnStyles.Add(csContractPOActual_GRActual)
      dst.GridColumnStyles.Add(csContractPOActualBalance)

      dst.GridColumnStyles.Add(csBarrier8)
      dst.GridColumnStyles.Add(csReceivedPOActual)
      dst.GridColumnStyles.Add(csReceivedPOActualPrice)
      dst.GridColumnStyles.Add(csReceivedPOActual_GRActual)
      dst.GridColumnStyles.Add(csReceivedPOActualBalance)

      dst.GridColumnStyles.Add(csBarrier4)
      dst.GridColumnStyles.Add(csReceivedActual)
      dst.GridColumnStyles.Add(csReceivedActualPrice)
      dst.GridColumnStyles.Add(csReceivedActual_GRActual)
      dst.GridColumnStyles.Add(csReceivedActualBalance)
      'dst.GridColumnStyles.Add(csReceivedActualPercent)

      dst.GridColumnStyles.Add(csBarrier5)
      dst.GridColumnStyles.Add(csRemainComplete)
      dst.GridColumnStyles.Add(csRemainCompleteReceived)
      dst.GridColumnStyles.Add(csRemainComplete_GRActual)
      dst.GridColumnStyles.Add(csRemainCompleteBalance)
      'dst.GridColumnStyles.Add(csRemainCompletePercent)

      dst.GridColumnStyles.Add(csBarrier6)
      dst.GridColumnStyles.Add(csDateComplete)

      Return dst
    End Function
    Public Shared Function GetCBSMonitorSchemaTable(ByVal dtcc As DataTable) As TreeTable
      Dim myDatatable As New TreeTable("RevExp")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("cc_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("cc_name", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("barrier0", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Price", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Main", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("VO", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Penalty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Other", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Bf", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Total", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedHeader", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Deliver", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Bill", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Received", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Retention", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Advance", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Remain", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("barrier2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Cost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Budget", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("POActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("POActualBalance", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("GRActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("GRActualBalance", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("profit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("contractbudget", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("contractbudgetprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("estimatebudget", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("profitloss", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("contractbudgetpercent", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier7", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ContractPOActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ContractPOActualPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ContractPOActual_GRActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ContractPOActualBalance", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("ReceivedActualPercent", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier8", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedPOActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedPOActualPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedPOActual_GRActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedPOActualBalance", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("receivedactual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedActualPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedActual_GRActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedActualBalance", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("ReceivedActualPercent", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainComplete", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainCompleteReceived", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainComplete_GRActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainCompleteBalance", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("RemainCompletePercent", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DateComplete", GetType(String)))




      'myDatatable.Columns.Add(New DataColumn("csContractPOActual", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("csContractPOActualPrice", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("csContractPOActual_GRActual", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("csContractPOActualBalance", GetType(String)))
      ''myDatatable.Columns.Add(New DataColumn("ReceivedActualPercent", GetType(String)))

      'myDatatable.Columns.Add(New DataColumn("csReceivedPOActual", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("csReceivedPOActualPrice", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("csReceivedPOActual_GRActual", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("csReceivedPOActualBalance", GetType(String)))

      Return myDatatable
    End Function

    Private Sub CreateHeader(ByVal dt As TreeTable)
      If dt Is Nothing Then
        Return
      End If

      dt.Clear()

      Dim tr As TreeRow = dt.Childs.Add
      tr("cc_code") = "Cost Center Code" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CostCenterCodeHeaderText}")
      tr("cc_name") = "Cost Center Name" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CostCenterNameHeaderText}")
      tr("price") = "Price" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("receivedheader") = "Received" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ReceievdHeaderHeaderText}")
      tr("cost") = "Cost" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CostHeaderText}")
      tr("DateComplete") = "Date Complete" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CostHeaderText}")
      tr("profit") = "Profit"

      tr = dt.Childs.Add
      tr("main") = "Main" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("vo") = "VO" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("penalty") = "Penalty" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("other") = "Other" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("bf") = "BF" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("total") = "Total" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("deliver") = "Deliver" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("bill") = "Bill" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("received") = "Received" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("retention") = "Retention" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("advance") = "Advance" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("remain") = "Remain" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("budget") = "Budget" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("poactual") = "PO Actual" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("poactualbalance") = "Balance" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("gractual") = "GR Actual" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("gractualbalance") = "Balance" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("contractbudget") = "Contract - Budget"
      tr("ContractPOActual") = "Contract - PO Actual"
      tr("ReceivedPOActual") = "Received - PO Actual"
      tr("receivedactual") = "Contract - GR Actual"
      tr("RemainComplete") = "Received - GR Actual"

      tr = dt.Childs.Add
      tr("contractbudgetprice") = "Contract" '"Price"
      tr("estimatebudget") = "Budget" '"Estimate Budget"
      tr("profitloss") = "Profit/Loss"
      'tr("contractbudgetpercent") = "(%)"

      tr("ContractPOActualPrice") = "Contract" '"Price"
      tr("ContractPOActual_GRActual") = "PO Actual"
      tr("ContractPOActualBalance") = "Balance"
      'tr("ReceivedActualPercent") = "(%)"

      tr("ReceivedPOActualPrice") = "Received"
      tr("ReceivedPOActual_GRActual") = "PO Actual"
      tr("ReceivedPOActualBalance") = "Balance"
      'tr("RemainCompletePercent") = "(%)"

      tr("ReceivedActualPrice") = "Contract" '"Price"
      tr("ReceivedActual_GRActual") = "GR Actual"
      tr("ReceivedActualBalance") = "Balance"
      'tr("ReceivedActualPercent") = "(%)"

      tr("RemainCompleteReceived") = "Received"
      tr("RemainComplete_GRActual") = "GR Actual"
      tr("RemainCompleteBalance") = "Balance"
      'tr("RemainCompletePercent") = "(%)"

      'Cost Center Code, Cost Center Name, Price, Received(Header), Cost, Profit, Date Complete
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                    {
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 0, 3, 0),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 3, 2),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 3, 3, 3),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 5, 1, 11),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 13, 1, 19),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 21, 1, 26),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 28, 1, 52),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 54, 3, 54)
                                    })
      'Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 54, 3, 54)
      'Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 45, 3, 45)
      'Main, VO, Panalty, Total, Deliver, Bill, Received, Remain, Budget, PO Actual, Balance, GR Actual, Balance
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                    {
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 6, 3, 6),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 7, 3, 7),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 8, 3, 8),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 9, 3, 9),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 10, 3, 10),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 11, 3, 11),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 13, 3, 13),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 14, 3, 14),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 15, 3, 15),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 16, 3, 16),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 17, 3, 17),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 18, 3, 18),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 19, 3, 19),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 21, 3, 21),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 22, 3, 22),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 23, 3, 23),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 24, 3, 24),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 25, 3, 25),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 26, 3, 26)
                                    })
      'Contract-Budget, Contract-PO Actual, Budget-PO Actual, Received-Actual, Received-Complete
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                   {
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 29, 2, 32),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 34, 2, 37),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 39, 2, 42),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 44, 2, 47),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 49, 2, 52)
                                  })


      'm_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
      '                             {
      '                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 54, 3, 54)
      '                             })

      'm_grid.Cols.Model.ColStyles(54).BackColor = Color.Red

      '  Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 34, 2, 36),
      'Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 38, 2, 41)
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return RptProjectRevenueExpenseEnumerate.GetCBSMonitorSchemaTable(Nothing) 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return RptProjectRevenueExpenseEnumerate.CreateCBSMonitorTableStyle(Nothing, "") 'BOQ.CreateWBSMonitorTableStyle
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
      Dim tm As New TreeManager(GetCBSMonitorSchemaTable(Nothing), New TreeGrid)
      ListInGrid(tm)


      lkg.TreeTableStyle = CreateCBSMonitorTableStyle(Nothing, Nothing)
      lkg.Model.Rows.Hidden(0) = True
      'lkg.Model.ColWidths(5) = 0
      lkg.TreeTable = tm.Treetable
      lkg.Rows.HeaderCount = 3
      lkg.Rows.FrozenCount = 3
      lkg.Cols.FrozenCount = 3

      lkg.Cols.Model.ColStyles(1).BackColor = Color.Red
      lkg.Cols.Model.ColStyles(2).BackColor = Color.Blue

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
      If Me.Filters(1).Name.ToLower = "nodigit" Then
        nodigit = CBool(Me.Filters(1).Value)
      End If
      CreateHeader(tm.Treetable)
      PopulateCBSMonitorListing(tm.Treetable, nodigit)
      MergeSeparate(tm.Treetable)
    End Sub
    Private Sub MergeSeparate(ByVal dt As TreeTable)
      Dim rowCount As Integer = dt.Rows.Count + 4 ' Me.DataSet.Tables(0).Rows.Count + 4
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                             {
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 4, rowCount, 4),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 12, rowCount, 12),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 20, rowCount, 20),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 27, rowCount, 27),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 33, rowCount, 33),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 38, rowCount, 38),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 43, rowCount, 43),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 48, rowCount, 48),
                               Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 53, rowCount, 53)
                             })
      '
      'Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 53, rowCount, 53)

    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      'Dim tr As Object = m_hashData(e.RowIndex)
      'If tr Is Nothing Then
      '  Return
      'End If

      'If TypeOf tr Is DataRow Then
      '  Dim dr As DataRow = CType(tr, DataRow)
      '  Dim drh As New DataRowHelper(dr)

      '  Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
      '  Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

      '  If docId > 0 AndAlso docType > 0 Then
      '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      '    myEntityPanelService.OpenDetailPanel(en)
      '  End If
      'End If


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

      Dim m_CCRvExp As New CostCenterRevenueExpense

      For Each drow As DataRow In Me.DataSet.Tables(0).Rows
        Dim drh As New DataRowHelper(drow)

        Dim trc As TreeRow = dt.Childs.Add
        trc("cc_code") = drh.GetValue(Of String)("cc_code")
        trc("cc_name") = drh.GetValue(Of String)("cc_name")

        trc("main") = Configuration.FormatToString(drh.GetValue(Of Decimal)("main"), dgt)
        trc("vo") = Configuration.FormatToString(drh.GetValue(Of Decimal)("vo"), dgt)
        trc("other") = Configuration.FormatToString(drh.GetValue(Of Decimal)("other"), dgt)
        trc("bf") = Configuration.FormatToString(drh.GetValue(Of Decimal)("bf"), dgt)
        trc("penalty") = Configuration.FormatToString(drh.GetValue(Of Decimal)("penalty"), dgt)
        trc("total") = Configuration.FormatToString((drh.GetValue(Of Decimal)("main") + drh.GetValue(Of Decimal)("vo") + drh.GetValue(Of Decimal)("other") + drh.GetValue(Of Decimal)("bf")) - drh.GetValue(Of Decimal)("penalty"), dgt)

        trc("deliver") = Configuration.FormatToString(drh.GetValue(Of Decimal)("deliver"), dgt)
        trc("bill") = Configuration.FormatToString(drh.GetValue(Of Decimal)("bill"), dgt)
        trc("received") = Configuration.FormatToString(drh.GetValue(Of Decimal)("received"), dgt)
        trc("retention") = Configuration.FormatToString(drh.GetValue(Of Decimal)("recretention"), dgt)
        trc("advance") = Configuration.FormatToString(drh.GetValue(Of Decimal)("recadvance"), dgt)
        trc("remain") = Configuration.FormatToString(drh.GetValue(Of Decimal)("remain"), dgt)

        trc("budget") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget"), dgt)
        trc("POActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("POActual"), dgt)
        trc("POActualBalance") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget") - drh.GetValue(Of Decimal)("POActual"), dgt)
        trc("GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("GRActual"), dgt)
                trc("GRActualBalance") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget") - drh.GetValue(Of Decimal)("GRActual"), dgt)

        trc("contractbudgetprice") = Configuration.FormatToString(CDec(trc("main")), dgt)
        trc("estimatebudget") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget"), dgt)
        trc("profitloss") = Configuration.FormatToString(CDec(trc("main")) - drh.GetValue(Of Decimal)("budget"), dgt)

        trc("ContractPOActualPrice") = Configuration.FormatToString(CDec(trc("main")), dgt)
        trc("ContractPOActual_GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("POActual"), dgt)
        trc("ContractPOActualBalance") = Configuration.FormatToString(CDec(trc("main")) - drh.GetValue(Of Decimal)("POActual"), dgt)

        trc("ReceivedPOActualPrice") = Configuration.FormatToString(CDec(trc("received")), dgt)
        trc("ReceivedPOActual_GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("POActual"), dgt)
        trc("ReceivedPOActualBalance") = Configuration.FormatToString(CDec(trc("received")) - drh.GetValue(Of Decimal)("POActual"), dgt)

        trc("ReceivedActualPrice") = Configuration.FormatToString(CDec(trc("main")), dgt)
        trc("ReceivedActual_GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("gractual"), dgt)
        trc("ReceivedActualBalance") = Configuration.FormatToString(CDec(trc("main")) - drh.GetValue(Of Decimal)("gractual"), dgt)

        trc("RemainCompleteReceived") = Configuration.FormatToString(CDec(trc("received")), dgt)
        trc("RemainComplete_GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("gractual"), dgt)
        trc("RemainCompleteBalance") = Configuration.FormatToString(CDec(trc("received")) - drh.GetValue(Of Decimal)("gractual"), dgt)

        trc("DateComplete") = drh.GetValue(Of Date)("project_completiondate").ToShortDateString

        ''Summary''--
        m_CCRvExp.Main += CDec(trc("main"))
        m_CCRvExp.Vo += CDec(trc("vo"))
        m_CCRvExp.Other += CDec(trc("other"))
        m_CCRvExp.Bf += CDec(trc("bf"))
        m_CCRvExp.Penalty += CDec(trc("penalty"))
        m_CCRvExp.Total += CDec(trc("total"))

        m_CCRvExp.Deliver += CDec(trc("deliver"))
        m_CCRvExp.Bill += CDec(trc("bill"))
        m_CCRvExp.Received += CDec(trc("received"))
        m_CCRvExp.Retention += CDec(trc("retention"))
        m_CCRvExp.Advance += CDec(trc("advance"))
        m_CCRvExp.Remain += CDec(trc("remain"))

        m_CCRvExp.Budget += CDec(trc("budget"))
        m_CCRvExp.POActual += CDec(trc("POActual"))
        m_CCRvExp.POActualBalance += CDec(trc("POActualBalance"))
        m_CCRvExp.GRActual += CDec(trc("GRActual"))
        m_CCRvExp.GRActualBalance += CDec(trc("GRActualBalance"))

        m_CCRvExp.Contractbudgetprice += CDec(trc("contractbudgetprice"))
        m_CCRvExp.Estimatebudget += CDec(trc("estimatebudget"))
        m_CCRvExp.Profitloss += CDec(trc("profitloss"))

        m_CCRvExp.ReceivedActualPrice += CDec(trc("ReceivedActualPrice"))
        m_CCRvExp.ReceivedActual_GRActual += CDec(trc("ReceivedActual_GRActual"))
        m_CCRvExp.ReceivedActualBalance += CDec(trc("ReceivedActualBalance"))

        m_CCRvExp.RemainCompleteReceived += CDec(trc("RemainCompleteReceived"))
        m_CCRvExp.RemainComplete_GRActual += CDec(trc("RemainComplete_GRActual"))
        m_CCRvExp.RemainCompleteBalance += CDec(trc("RemainCompleteBalance"))
      Next

      ''Summary''--
      Dim trsc As TreeRow = dt.Childs.Add
      trsc("cc_name") = "Total Cost"

      trsc("main") = Configuration.FormatToString(m_CCRvExp.Main, dgt)
      trsc("vo") = Configuration.FormatToString(m_CCRvExp.Vo, dgt)
      trsc("other") = Configuration.FormatToString(m_CCRvExp.Other, dgt)
      trsc("bf") = Configuration.FormatToString(m_CCRvExp.Bf, dgt)
      trsc("penalty") = Configuration.FormatToString(m_CCRvExp.Penalty, dgt)
      trsc("total") = Configuration.FormatToString(m_CCRvExp.Total, dgt)

      trsc("deliver") = Configuration.FormatToString(m_CCRvExp.Deliver, dgt)
      trsc("bill") = Configuration.FormatToString(m_CCRvExp.Bill, dgt)
      trsc("received") = Configuration.FormatToString(m_CCRvExp.Received, dgt)
      trsc("retention") = Configuration.FormatToString(m_CCRvExp.Retention, dgt)
      trsc("advance") = Configuration.FormatToString(m_CCRvExp.Advance, dgt)
      trsc("remain") = Configuration.FormatToString(m_CCRvExp.Remain, dgt)

      trsc("budget") = Configuration.FormatToString(m_CCRvExp.Budget, dgt)
      trsc("POActual") = Configuration.FormatToString(m_CCRvExp.POActual, dgt)
      trsc("POActualBalance") = Configuration.FormatToString(m_CCRvExp.POActualBalance, dgt)
      trsc("GRActual") = Configuration.FormatToString(m_CCRvExp.GRActual, dgt)
      trsc("GRActualBalance") = Configuration.FormatToString(m_CCRvExp.GRActualBalance, dgt)

      trsc("contractbudgetprice") = Configuration.FormatToString(m_CCRvExp.Contractbudgetprice, dgt)
      trsc("estimatebudget") = Configuration.FormatToString(m_CCRvExp.Estimatebudget, dgt)
      trsc("profitloss") = Configuration.FormatToString(m_CCRvExp.Profitloss, dgt)

      trsc("ContractPOActualPrice") = Configuration.FormatToString(m_CCRvExp.Contractbudgetprice, dgt)
      trsc("ContractPOActual_GRActual") = Configuration.FormatToString(m_CCRvExp.POActual, dgt)
      trsc("ContractPOActualBalance") = Configuration.FormatToString(m_CCRvExp.Contractbudgetprice - m_CCRvExp.POActual, dgt)

      trsc("ReceivedPOActualPrice") = Configuration.FormatToString(m_CCRvExp.RemainCompleteReceived, dgt)
      trsc("ReceivedPOActual_GRActual") = Configuration.FormatToString(m_CCRvExp.POActual, dgt)
      trsc("ReceivedPOActualBalance") = Configuration.FormatToString(m_CCRvExp.RemainCompleteReceived - m_CCRvExp.POActual, dgt)

      trsc("ReceivedActualPrice") = Configuration.FormatToString(m_CCRvExp.Contractbudgetprice, dgt)
      trsc("ReceivedActual_GRActual") = Configuration.FormatToString(m_CCRvExp.RemainComplete_GRActual, dgt)
      trsc("ReceivedActualBalance") = Configuration.FormatToString(m_CCRvExp.Contractbudgetprice - m_CCRvExp.RemainComplete_GRActual, dgt)

      trsc("RemainCompleteReceived") = Configuration.FormatToString(m_CCRvExp.RemainCompleteReceived, dgt)
      trsc("RemainComplete_GRActual") = Configuration.FormatToString(m_CCRvExp.RemainComplete_GRActual, dgt)
      trsc("RemainCompleteBalance") = Configuration.FormatToString(m_CCRvExp.RemainCompleteBalance, dgt)

      dt.AcceptChanges()
      Return


      Dim dtcbs As DataTable = Me.DataSet.Tables(1)
      Dim dtdata As DataTable = Me.DataSet.Tables(2)
      dtcbs.TableName = "Table0"
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


          End If

        Next

        dt.AcceptChanges()
      Catch ex As Exception
        MessageBox.Show(stage & vbCrLf & ex.Message)
      End Try

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
        Return "RptProjectRevenueExpenseEnumerate"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptProjectRevenueExpenseEnumerate.DetailLabel}"
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
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptProjectRevenueExpenseEnumerate.ListLabel}"
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

      If CStr(Me.Filters(0).Value).Length > 0 Then
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCodeList"
        dpi.Value = CStr(Me.Filters(0).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

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

    Private Class CostCenterRevenueExpense
      Public Property cc_code As String
      Public Property cc_name As String

      Public Property Main As Decimal
      Public Property Vo As Decimal
      Public Property Other As Decimal
      Public Property Bf As Decimal
      Public Property Penalty As Decimal
      Public Property Total As Decimal

      Public Property Deliver As Decimal
      Public Property Bill As Decimal
      Public Property Received As Decimal
      Public Property Retention As Decimal
      Public Property Advance As Decimal
      Public Property Remain As Decimal

      Public Property Budget As Decimal
      Public Property POActual As Decimal
      Public Property POActualBalance As Decimal
      Public Property GRActual As Decimal
      Public Property GRActualBalance As Decimal

      Public Property Contractbudgetprice As Decimal
      Public Property Estimatebudget As Decimal
      Public Property Profitloss As Decimal

      Public Property Contractbudgetpercent As Decimal

      Public Property ReceivedActualPrice As Decimal
      Public Property ReceivedActual_GRActual As Decimal
      Public Property ReceivedActualBalance As Decimal

      Public Property ReceivedActualPercent As Decimal

      Public Property RemainCompleteReceived As Decimal
      Public Property RemainComplete_GRActual As Decimal
      Public Property RemainCompleteBalance As Decimal

      Public Property RemainCompletePercent As Decimal

      Public Property DateComplete As Date
    End Class

  End Class
End Namespace

