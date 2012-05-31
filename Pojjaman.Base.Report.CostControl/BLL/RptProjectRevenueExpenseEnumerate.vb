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
      csCostCenterCode.Width = 129
      csCostCenterCode.DataAlignment = HorizontalAlignment.Left
      csCostCenterCode.ReadOnly = True
      csCostCenterCode.TextBox.Name = "cc_code"

      Dim csCostCenterName As New PlusMinusTreeTextColumn
      csCostCenterName.MappingName = "cc_Name"
      csCostCenterName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.CostCenterNameHeaderText}")
      csCostCenterName.NullText = ""
      csCostCenterName.Width = 239
      csCostCenterName.TextBox.Name = "cc_name"
      csCostCenterName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
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
      csMain.Width = 109
      csMain.TextBox.Name = "main"
      csMain.ReadOnly = True

      Dim csVO As New TreeTextColumn
      csVO.MappingName = "vo"
      csVO.HeaderText = "VO" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csVO.NullText = ""
      csVO.DataAlignment = HorizontalAlignment.Right
      csVO.Format = "#,###.##"
      csVO.Width = 109
      csVO.TextBox.Name = "vo"
      csVO.ReadOnly = True

      Dim csOther As New TreeTextColumn
      csOther.MappingName = "other"
      csOther.HeaderText = "Other" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csOther.NullText = ""
      csOther.DataAlignment = HorizontalAlignment.Right
      csOther.Format = "#,###.##"
      csOther.Width = 109
      csOther.TextBox.Name = "other"
      csOther.ReadOnly = True

      Dim csBf As New TreeTextColumn
      csBf.MappingName = "bf"
      csBf.HeaderText = "BF" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csBf.NullText = ""
      csBf.DataAlignment = HorizontalAlignment.Right
      csBf.Format = "#,###.##"
      csBf.Width = 109
      csBf.TextBox.Name = "Bf"
      csBf.ReadOnly = True

      Dim csPenalty As New TreeTextColumn
      csPenalty.MappingName = "penalty"
      csPenalty.HeaderText = "Penalty" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csPenalty.NullText = ""
      csPenalty.DataAlignment = HorizontalAlignment.Right
      csPenalty.Format = "#,###.##"
      csPenalty.Width = 109
      csPenalty.TextBox.Name = "penalty"
      csPenalty.ReadOnly = True

      Dim csTotal As New TreeTextColumn
      csTotal.MappingName = "total"
      csTotal.HeaderText = "Total" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csTotal.NullText = ""
      csTotal.DataAlignment = HorizontalAlignment.Right
      csTotal.Format = "#,###.##"
      csTotal.Width = 109
      csTotal.TextBox.Name = "total"
      csTotal.ReadOnly = True

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
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
      csDeliver.Width = 109
      csDeliver.TextBox.Name = "deliver"
      csDeliver.ReadOnly = True

      Dim csBill As New TreeTextColumn
      csBill.MappingName = "bill"
      csBill.HeaderText = "Bill" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csBill.NullText = ""
      csBill.DataAlignment = HorizontalAlignment.Right
      csBill.Format = "#,###.##"
      csBill.Width = 109
      csBill.TextBox.Name = "bill"
      csBill.ReadOnly = True

      Dim csReceived As New TreeTextColumn
      csReceived.MappingName = "received"
      csReceived.HeaderText = "Received" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceived.NullText = ""
      csReceived.DataAlignment = HorizontalAlignment.Right
      csReceived.Format = "#,###.##"
      csReceived.Width = 109
      csReceived.TextBox.Name = "received"
      csReceived.ReadOnly = True

      Dim csRemain As New TreeTextColumn
      csRemain.MappingName = "remain"
      csRemain.HeaderText = "Remain" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemain.NullText = ""
      csRemain.DataAlignment = HorizontalAlignment.Right
      csRemain.Format = "#,###.##"
      csRemain.Width = 109
      csRemain.TextBox.Name = "remain"
      csRemain.ReadOnly = True

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
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
      csBudget.Width = 109
      csBudget.TextBox.Name = "budget"
      csBudget.ReadOnly = True

      Dim csPOActual As New TreeTextColumn
      csPOActual.MappingName = "poactual"
      csPOActual.HeaderText = "PO Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csPOActual.NullText = ""
      csPOActual.DataAlignment = HorizontalAlignment.Right
      csPOActual.Format = "#,###.##"
      csPOActual.Width = 109
      csPOActual.TextBox.Name = "poactual"
      csPOActual.ReadOnly = True

      Dim csPOActualBalance As New TreeTextColumn
      csPOActualBalance.MappingName = "poactualbalance"
      csPOActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csPOActualBalance.NullText = ""
      csPOActualBalance.DataAlignment = HorizontalAlignment.Right
      csPOActualBalance.Format = "#,###.##"
      csPOActualBalance.Width = 109
      csPOActualBalance.TextBox.Name = "poactualbalance"
      csPOActualBalance.ReadOnly = True

      Dim csGRActual As New TreeTextColumn
      csGRActual.MappingName = "gractual"
      csGRActual.HeaderText = "GR Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csGRActual.NullText = ""
      csGRActual.DataAlignment = HorizontalAlignment.Right
      csGRActual.Format = "#,###.##"
      csGRActual.Width = 109
      csGRActual.TextBox.Name = "gractual"
      csGRActual.ReadOnly = True

      Dim csGRActualBalance As New TreeTextColumn
      csGRActualBalance.MappingName = "gractualbalance"
      csGRActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csGRActualBalance.NullText = ""
      csGRActualBalance.DataAlignment = HorizontalAlignment.Right
      csGRActualBalance.Format = "#,###.##"
      csGRActualBalance.Width = 109
      csGRActualBalance.TextBox.Name = "gractualbalance"
      csGRActualBalance.ReadOnly = True

      Dim csBarrier3 As New DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
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
      csContractBudgetPrice.Width = 109
      csContractBudgetPrice.TextBox.Name = "contractbudgetprice"
      csContractBudgetPrice.ReadOnly = True

      Dim csContractBudgetEstimate As New TreeTextColumn
      csContractBudgetEstimate.MappingName = "estimatebudget"
      csContractBudgetEstimate.HeaderText = "Estimate Budget" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractBudgetEstimate.NullText = ""
      csContractBudgetEstimate.DataAlignment = HorizontalAlignment.Right
      csContractBudgetEstimate.Format = "#,###.##"
      csContractBudgetEstimate.Width = 109
      csContractBudgetEstimate.TextBox.Name = "estimatebudget"
      csContractBudgetEstimate.ReadOnly = True

      Dim csContractBudgetProfitLost As New TreeTextColumn
      csContractBudgetProfitLost.MappingName = "profitloss"
      csContractBudgetProfitLost.HeaderText = "กำไร/ขาดทุน" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractBudgetProfitLost.NullText = ""
      csContractBudgetProfitLost.DataAlignment = HorizontalAlignment.Right
      csContractBudgetProfitLost.Format = "#,###.##"
      csContractBudgetProfitLost.Width = 109
      csContractBudgetProfitLost.TextBox.Name = "profitloss"
      csContractBudgetProfitLost.ReadOnly = True

      Dim csContractBudgetPercent As New TreeTextColumn
      csContractBudgetPercent.MappingName = "contractbudgetpercent"
      csContractBudgetPercent.HeaderText = "(%)" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csContractBudgetPercent.NullText = ""
      csContractBudgetPercent.DataAlignment = HorizontalAlignment.Right
      csContractBudgetPercent.Format = "#,###.##"
      csContractBudgetPercent.Width = 0
      csContractBudgetPercent.TextBox.Name = "contractbudgetpercent"
      csContractBudgetPercent.ReadOnly = True

      Dim csBarrier4 As New DataGridBarrierColumn
      csBarrier4.MappingName = "Barrier4"
      csBarrier4.HeaderText = ""
      csBarrier4.NullText = ""
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
      csReceivedActualPrice.Width = 109
      csReceivedActualPrice.TextBox.Name = "ReceivedActualprice"
      csReceivedActualPrice.ReadOnly = True

      Dim csReceivedActual_GRActual As New TreeTextColumn
      csReceivedActual_GRActual.MappingName = "ReceivedActual_GRActual"
      csReceivedActual_GRActual.HeaderText = "GR Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedActual_GRActual.NullText = ""
      csReceivedActual_GRActual.DataAlignment = HorizontalAlignment.Right
      csReceivedActual_GRActual.Format = "#,###.##"
      csReceivedActual_GRActual.Width = 109
      csReceivedActual_GRActual.TextBox.Name = "ReceivedActual_GRActual"
      csReceivedActual_GRActual.ReadOnly = True

      Dim csReceivedActualBalance As New TreeTextColumn
      csReceivedActualBalance.MappingName = "ReceivedActualBalance"
      csReceivedActualBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedActualBalance.NullText = ""
      csReceivedActualBalance.DataAlignment = HorizontalAlignment.Right
      csReceivedActualBalance.Format = "#,###.##"
      csReceivedActualBalance.Width = 109
      csReceivedActualBalance.TextBox.Name = "ReceivedActualBalance"
      csReceivedActualBalance.ReadOnly = True

      Dim csReceivedActualPercent As New TreeTextColumn
      csReceivedActualPercent.MappingName = "ReceivedActualPercent"
      csReceivedActualPercent.HeaderText = "(%)" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csReceivedActualPercent.NullText = ""
      csReceivedActualPercent.DataAlignment = HorizontalAlignment.Right
      csReceivedActualPercent.Format = "#,###.##"
      csReceivedActualPercent.Width = 0
      csReceivedActualPercent.TextBox.Name = "ReceivedActualPercent"
      csReceivedActualPercent.ReadOnly = True

      Dim csBarrier5 As New DataGridBarrierColumn
      csBarrier5.MappingName = "Barrier5"
      csBarrier5.HeaderText = ""
      csBarrier5.NullText = ""
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
      csRemainCompleteReceived.Width = 109
      csRemainCompleteReceived.TextBox.Name = "RemainCompleteReceived"
      csRemainCompleteReceived.ReadOnly = True

      Dim csRemainComplete_GRActual As New TreeTextColumn
      csRemainComplete_GRActual.MappingName = "RemainComplete_GRActual"
      csRemainComplete_GRActual.HeaderText = "GR Actual" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemainComplete_GRActual.NullText = ""
      csRemainComplete_GRActual.DataAlignment = HorizontalAlignment.Right
      csRemainComplete_GRActual.Format = "#,###.##"
      csRemainComplete_GRActual.Width = 109
      csRemainComplete_GRActual.TextBox.Name = "RemainComplete_GRActual"
      csRemainComplete_GRActual.ReadOnly = True

      Dim csRemainCompleteBalance As New TreeTextColumn
      csRemainCompleteBalance.MappingName = "RemainCompleteBalance"
      csRemainCompleteBalance.HeaderText = "Balance" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemainCompleteBalance.NullText = ""
      csRemainCompleteBalance.DataAlignment = HorizontalAlignment.Right
      csRemainCompleteBalance.Format = "#,###.##"
      csRemainCompleteBalance.Width = 109
      csRemainCompleteBalance.TextBox.Name = "RemainCompleteBalance"
      csRemainCompleteBalance.ReadOnly = True

      Dim csRemainCompletePercent As New TreeTextColumn
      csRemainCompletePercent.MappingName = "RemainCompletePercent"
      csRemainCompletePercent.HeaderText = "(%)" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csRemainCompletePercent.NullText = ""
      csRemainCompletePercent.DataAlignment = HorizontalAlignment.Right
      csRemainCompletePercent.Format = "#,###.##"
      csRemainCompletePercent.Width = 0
      csRemainCompletePercent.TextBox.Name = "RemainCompletePercent"
      csRemainCompletePercent.ReadOnly = True

      Dim csBarrier6 As New DataGridBarrierColumn
      csBarrier6.MappingName = "Barrier6"
      csBarrier6.HeaderText = ""
      csBarrier6.NullText = ""
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
      dst.GridColumnStyles.Add(csOther)
      dst.GridColumnStyles.Add(csBf)
      dst.GridColumnStyles.Add(csPenalty)
      dst.GridColumnStyles.Add(csTotal)

      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csReceivedHeader)
      dst.GridColumnStyles.Add(csDeliver)
      dst.GridColumnStyles.Add(csBill)
      dst.GridColumnStyles.Add(csReceived)
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
      dst.GridColumnStyles.Add(csContractBudgetPercent)

      dst.GridColumnStyles.Add(csBarrier4)
      dst.GridColumnStyles.Add(csReceivedActual)
      dst.GridColumnStyles.Add(csReceivedActualPrice)
      dst.GridColumnStyles.Add(csReceivedActual_GRActual)
      dst.GridColumnStyles.Add(csReceivedActualBalance)
      dst.GridColumnStyles.Add(csReceivedActualPercent)

      dst.GridColumnStyles.Add(csBarrier5)
      dst.GridColumnStyles.Add(csRemainComplete)
      dst.GridColumnStyles.Add(csRemainCompleteReceived)
      dst.GridColumnStyles.Add(csRemainComplete_GRActual)
      dst.GridColumnStyles.Add(csRemainCompleteBalance)
      dst.GridColumnStyles.Add(csRemainCompletePercent)

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
      myDatatable.Columns.Add(New DataColumn("Other", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Bf", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Penalty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Total", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedHeader", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Deliver", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Bill", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Received", GetType(String)))
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
      myDatatable.Columns.Add(New DataColumn("contractbudgetpercent", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier4", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("receivedactual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedActualPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedActual_GRActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedActualBalance", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedActualPercent", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier5", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainComplete", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainCompleteReceived", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainComplete_GRActual", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainCompleteBalance", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("RemainCompletePercent", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier6", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DateComplete", GetType(String)))

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
      tr("other") = "Other" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("bf") = "bf" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("penalty") = "Penalty" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("total") = "Total" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("deliver") = "Deliver" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("bill") = "Bill" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("received") = "Received" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("remain") = "Remain" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("budget") = "Budget" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("poactual") = "PO Actual" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("poactualbalance") = "Balance" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("gractual") = "GR Actual" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("gractualbalance") = "Balance" 'Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PriceHeaderText}")
      tr("contractbudget") = "Contract - Budget"
      tr("receivedactual") = "Received - Actual"
      tr("RemainComplete") = "Remain - Complete"

      tr = dt.Childs.Add
      tr("contractbudgetprice") = "Price"
      tr("estimatebudget") = "Estimate Budget"
      tr("profitloss") = "Profit/Loss"
      tr("contractbudgetpercent") = "(%)"

      tr("ReceivedActualPrice") = "Price"
      tr("ReceivedActual_GRActual") = "GR Actual"
      tr("ReceivedActualBalance") = "Balance"
      tr("ReceivedActualPercent") = "(%)"

      tr("RemainCompleteReceived") = "Received"
      tr("RemainComplete_GRActual") = "GR Actual"
      tr("RemainCompleteBalance") = "Balance"
      tr("RemainCompletePercent") = "(%)"

      'Cost Center Code, Cost Center Name, Price, Received(Header), Cost, Profit, Date Complete
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                    {
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 2, 3, 2),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 3, 3, 3),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 5, 1, 11),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 13, 1, 17),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 19, 1, 24),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 26, 1, 43),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 45, 3, 45)
                                    })
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
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 19, 3, 19),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 20, 3, 20),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 21, 3, 21),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 22, 3, 22),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 23, 3, 23),
                                      Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 24, 3, 24)
                                    })
      'Contract-Budget, Received-Actual, Received-Complete
      m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
                                   {
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 27, 2, 31),
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 33, 2, 37),
                                     Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(2, 39, 2, 43)
                                   })

      ',
      'Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, 25, 1, 31)

      'Dim trDetail As TreeRow = dt.Childs.Add
      'Dim i As Integer = 5
      '' 10 Col per cc
      'Dim GridRangeStyle1 As GridRangeStyle = New GridRangeStyle

      'For Each ccrow As DataRow In dtcc.Rows
      '  Dim crh As New DataRowHelper(ccrow)


      '  Dim cc As String = crh.GetValue(Of Integer)("ccid").ToString
      '  'trcc("BudgetCost" & cc) = crh.GetValue(Of String)("cc_code") & ":" & crh.GetValue(Of String)("cc_name")
      '  tr("CostCenter" & cc) = crh.GetValue(Of String)("cc_code") & ":" & crh.GetValue(Of String)("cc_name")

      '  trDetail("BudgetCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BudgetCostHeaderText}")
      '  trDetail("ActualPRCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPRCostHeaderText}")
      '  trDetail("PRDiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      '  trDetail("ActualPOCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPOCostHeaderText}")
      '  trDetail("PODiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      '  trDetail("ActualGRCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualGRCostHeaderText}")
      '  trDetail("GRDiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      '  trDetail("ActualMWCost" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      '  trDetail("MWDiff" & cc) = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      '  'Dim csBarrier0 As New DataGridBarrierColumn
      '  'csBarrier0.MappingName = "Barrier" & cc
      '  'csBarrier0.HeaderText = ""
      '  'csBarrier0.NullText = ""
      '  'csBarrier0.ReadOnly = True

      '  'For r As Integer = 0 To m_grid.ColCount - 1
      '  '  m_grid(1, r).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      '  'Next

      '  m_grid.CoveredRanges.AddRange(New Syncfusion.Windows.Forms.Grid.GridRangeInfo() _
      '                              {Syncfusion.Windows.Forms.Grid.GridRangeInfo.Cells(1, i, 1, i + 9)}) ' 
      '  'm_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      '  i += 11
      'Next

      'For r As Integer = 0 To m_grid.ColCount - 1
      '  m_grid(2, r).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      'Next


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
      'If Me.Filters(3).Name.ToLower = "nodigit" Then
      '  nodigit = CBool(Me.Filters(3).Value)
      'End If
      CreateHeader(tm.Treetable)
      PopulateCBSMonitorListing(tm.Treetable, nodigit)
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
        trc.State = RowExpandState.Expanded
        trc("cc_code") = drh.GetValue(Of String)("cc_code")
        trc("cc_name") = drh.GetValue(Of String)("cc_name")

        trc("main") = Configuration.FormatToString(drh.GetValue(Of Decimal)("main"), DigitConfig.Price)
        trc("vo") = Configuration.FormatToString(drh.GetValue(Of Decimal)("vo"), DigitConfig.Price)
        trc("other") = Configuration.FormatToString(drh.GetValue(Of Decimal)("other"), DigitConfig.Price)
        trc("bf") = Configuration.FormatToString(drh.GetValue(Of Decimal)("bf"), DigitConfig.Price)
        trc("penalty") = Configuration.FormatToString(drh.GetValue(Of Decimal)("penalty"), DigitConfig.Price)
        trc("total") = Configuration.FormatToString((drh.GetValue(Of Decimal)("main") + drh.GetValue(Of Decimal)("vo") + drh.GetValue(Of Decimal)("other") + drh.GetValue(Of Decimal)("bf")) - drh.GetValue(Of Decimal)("penalty"), DigitConfig.Price)
        'trc("total") = Configuration.FormatToString((drh.GetValue(Of Decimal)("main") + drh.GetValue(Of Decimal)("vo") + drh.GetValue(Of Decimal)("other") + drh.GetValue(Of Decimal)("bf")) _
        '- (drh.GetValue(Of Decimal)("penalty") + drh.GetValue(Of Decimal)("retention") + drh.GetValue(Of Decimal)("advance")), DigitConfig.Price)

        trc("deliver") = Configuration.FormatToString(drh.GetValue(Of Decimal)("deliver"), DigitConfig.Price)
        trc("bill") = Configuration.FormatToString(drh.GetValue(Of Decimal)("bill"), DigitConfig.Price)
        'trc("received") = Configuration.FormatToString(drh.GetValue(Of Decimal)("receivedtaxbase"), DigitConfig.Price)
        trc("received") = Configuration.FormatToString(drh.GetValue(Of Decimal)("received"), DigitConfig.Price)
        'trc("remain") = Configuration.FormatToString(drh.GetValue(Of Decimal)("deliver") - drh.GetValue(Of Decimal)("bill"), DigitConfig.Price)
        trc("remain") = Configuration.FormatToString(drh.GetValue(Of Decimal)("remain"), DigitConfig.Price)

        trc("budget") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget"), DigitConfig.Price)
        trc("POActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("POActual"), DigitConfig.Price)
        trc("POActualBalance") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget") - drh.GetValue(Of Decimal)("POActual"), DigitConfig.Price)
        trc("GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("GRActual"), DigitConfig.Price)
        trc("GRActualBalance") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget") - drh.GetValue(Of Decimal)("POActual"), DigitConfig.Price)

        'trc("contractbudgetprice") = Configuration.FormatToString(CDec(trc("total")), DigitConfig.Price)
        trc("contractbudgetprice") = Configuration.FormatToString(CDec(trc("main")), DigitConfig.Price)
        trc("estimatebudget") = Configuration.FormatToString(drh.GetValue(Of Decimal)("budget"), DigitConfig.Price)
        trc("profitloss") = Configuration.FormatToString(CDec(trc("main")) - drh.GetValue(Of Decimal)("budget"), DigitConfig.Price)
        'trc("profitloss") = Configuration.FormatToString(CDec(trc("total")) - drh.GetValue(Of Decimal)("budget"), DigitConfig.Price)
        If drh.GetValue(Of Decimal)("budget") > 0 Then
          trc("contractbudgetpercent") = Configuration.FormatToString(((CDec(trc("main")) / drh.GetValue(Of Decimal)("budget")) - 1) * 100, DigitConfig.Price) & "%"
          'trc("contractbudgetpercent") = Configuration.FormatToString(((CDec(trc("total")) / drh.GetValue(Of Decimal)("budget")) - 1) * 100, DigitConfig.Price) & "%"
        Else
          trc("contractbudgetpercent") = Configuration.FormatToString(0, DigitConfig.Price) & "%"
        End If

        trc("ReceivedActualPrice") = Configuration.FormatToString(CDec(trc("total")), DigitConfig.Price)
        trc("ReceivedActual_GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("gractual"), DigitConfig.Price)
        trc("ReceivedActualBalance") = Configuration.FormatToString(CDec(trc("total")) - drh.GetValue(Of Decimal)("gractual"), DigitConfig.Price)
        If CDec(trc("total")) > 0 Then
          trc("ReceivedActualPercent") = Configuration.FormatToString((drh.GetValue(Of Decimal)("gractual") / CDec(trc("total"))) * 100, DigitConfig.Price) & "%"
        Else
          trc("ReceivedActualPercent") = Configuration.FormatToString(0, DigitConfig.Price) & "%"
        End If

        trc("RemainCompleteReceived") = Configuration.FormatToString(CDec(trc("received")), DigitConfig.Price)
        trc("RemainComplete_GRActual") = Configuration.FormatToString(drh.GetValue(Of Decimal)("gractual"), DigitConfig.Price)
        trc("RemainCompleteBalance") = Configuration.FormatToString(CDec(trc("received")) - drh.GetValue(Of Decimal)("gractual"), DigitConfig.Price)
        If drh.GetValue(Of Decimal)("gractual") > 0 Then
          trc("RemainCompletePercent") = Configuration.FormatToString((CDec(trc("received")) / drh.GetValue(Of Decimal)("gractual")) * 100, DigitConfig.Price) & "%"
        Else
          trc("RemainCompletePercent") = Configuration.FormatToString(0, DigitConfig.Price) & "%"
        End If

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
      trsc.State = RowExpandState.Expanded
      trsc("cc_name") = "Total Cost"

      trsc("main") = Configuration.FormatToString(m_CCRvExp.Main, DigitConfig.Price)
      trsc("vo") = Configuration.FormatToString(m_CCRvExp.Vo, DigitConfig.Price)
      trsc("other") = Configuration.FormatToString(m_CCRvExp.Other, DigitConfig.Price)
      trsc("bf") = Configuration.FormatToString(m_CCRvExp.Bf, DigitConfig.Price)
      trsc("penalty") = Configuration.FormatToString(m_CCRvExp.Penalty, DigitConfig.Price)
      trsc("total") = Configuration.FormatToString(m_CCRvExp.Total, DigitConfig.Price)

      trsc("deliver") = Configuration.FormatToString(m_CCRvExp.Deliver, DigitConfig.Price)
      trsc("bill") = Configuration.FormatToString(m_CCRvExp.Bill, DigitConfig.Price)
      trsc("received") = Configuration.FormatToString(m_CCRvExp.Received, DigitConfig.Price)
      trsc("remain") = Configuration.FormatToString(m_CCRvExp.Remain, DigitConfig.Price)

      trsc("budget") = Configuration.FormatToString(m_CCRvExp.Budget, DigitConfig.Price)
      trsc("POActual") = Configuration.FormatToString(m_CCRvExp.POActual, DigitConfig.Price)
      trsc("POActualBalance") = Configuration.FormatToString(m_CCRvExp.POActualBalance, DigitConfig.Price)
      trsc("GRActual") = Configuration.FormatToString(m_CCRvExp.GRActual, DigitConfig.Price)
      trsc("GRActualBalance") = Configuration.FormatToString(m_CCRvExp.GRActualBalance, DigitConfig.Price)

      trsc("contractbudgetprice") = Configuration.FormatToString(m_CCRvExp.Contractbudgetprice, DigitConfig.Price)
      trsc("estimatebudget") = Configuration.FormatToString(m_CCRvExp.Estimatebudget, DigitConfig.Price)
      trsc("profitloss") = Configuration.FormatToString(m_CCRvExp.Profitloss, DigitConfig.Price)
      If m_CCRvExp.Budget > 0 Then
        trsc("contractbudgetpercent") = Configuration.FormatToString(((m_CCRvExp.Total / m_CCRvExp.Budget) - 1) * 100, DigitConfig.Price) & "%"
      Else
        trsc("contractbudgetpercent") = Configuration.FormatToString(0, DigitConfig.Price) & "%"
      End If

      trsc("ReceivedActualPrice") = Configuration.FormatToString(m_CCRvExp.ReceivedActualPrice, DigitConfig.Price)
      trsc("ReceivedActual_GRActual") = Configuration.FormatToString(m_CCRvExp.ReceivedActual_GRActual, DigitConfig.Price)
      trsc("ReceivedActualBalance") = Configuration.FormatToString(m_CCRvExp.ReceivedActualBalance, DigitConfig.Price)
      If m_CCRvExp.Total > 0 Then
        trsc("ReceivedActualPercent") = Configuration.FormatToString((m_CCRvExp.GRActual / m_CCRvExp.Total) * 100, DigitConfig.Price) & "%"
      Else
        trsc("ReceivedActualPercent") = Configuration.FormatToString(0, DigitConfig.Price) & "%"
      End If

      trsc("RemainCompleteReceived") = Configuration.FormatToString(m_CCRvExp.RemainCompleteReceived, DigitConfig.Price)
      trsc("RemainComplete_GRActual") = Configuration.FormatToString(m_CCRvExp.RemainComplete_GRActual, DigitConfig.Price)
      trsc("RemainCompleteBalance") = Configuration.FormatToString(m_CCRvExp.RemainCompleteBalance, DigitConfig.Price)
      If m_CCRvExp.GRActual > 0 Then
        trsc("RemainCompletePercent") = Configuration.FormatToString((m_CCRvExp.Received / m_CCRvExp.GRActual) * 100, DigitConfig.Price) & "%"
      Else
        trsc("RemainCompletePercent") = Configuration.FormatToString(0, DigitConfig.Price) & "%"
      End If

      dt.AcceptChanges()
      Return


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

