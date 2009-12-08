Option Strict Off

Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Longkong.Core.Properties
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class Summary
    Inherits AbstractEntityDetailPanelView

#Region " Windows Form Designer generated code "
    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblMat As System.Windows.Forms.Label
    Friend WithEvents lblLabor As System.Windows.Forms.Label
    Friend WithEvents lblDirectCost As System.Windows.Forms.Label
    Friend WithEvents lblTotalOverhead As System.Windows.Forms.Label
    Friend WithEvents grbSum As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtMatBasePercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidMat As System.Windows.Forms.TextBox
    Friend WithEvents txtLaborBasePercent As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectCostBasePercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidDirectCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalOVerheadBasePercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidOverhead As System.Windows.Forms.TextBox
    Friend WithEvents txtProfitBasePercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidProfit As System.Windows.Forms.TextBox
    Friend WithEvents txtBid As System.Windows.Forms.TextBox
    Friend WithEvents txtBidPriceBasePercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidOverheadPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidMatPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidDirectCostPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidProfitPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtMatBase As System.Windows.Forms.TextBox
    Friend WithEvents lblBasePricePercent As System.Windows.Forms.Label
    Friend WithEvents lblBidPrice As System.Windows.Forms.Label
    Friend WithEvents txtLaborBase As System.Windows.Forms.TextBox
    Friend WithEvents txtBidLabor As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectCostBase As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalOverheadBase As System.Windows.Forms.TextBox
    Friend WithEvents txtProfitBase As System.Windows.Forms.TextBox
    Friend WithEvents txtBidBase As System.Windows.Forms.TextBox
    Friend WithEvents lblBid As System.Windows.Forms.Label
    Friend WithEvents lblBasePrice As System.Windows.Forms.Label
    Friend WithEvents lblBidPricePercent As System.Windows.Forms.Label
    Friend WithEvents txtBidLaborPercent As System.Windows.Forms.TextBox
    Friend WithEvents lblProfit As System.Windows.Forms.Label
    Friend WithEvents grbSumBid As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblEquip As System.Windows.Forms.Label
    Friend WithEvents txtEquipBasePercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBidEquip As System.Windows.Forms.TextBox
    Friend WithEvents txtEquipBase As System.Windows.Forms.TextBox
    Friend WithEvents txtBidEquipPercent As System.Windows.Forms.TextBox
    Friend WithEvents lblBOQCode As System.Windows.Forms.Label
    Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents PieChart1 As System.Drawing.PieChart.PieChartControl
    Friend WithEvents ibtnZoomChart As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnZoomGrid As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnSaveAsExcel As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbSummarize As System.Windows.Forms.GroupBox
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkHasVat As System.Windows.Forms.CheckBox
    Friend WithEvents lblVat As System.Windows.Forms.Label
    Friend WithEvents txtVat As System.Windows.Forms.TextBox
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Summary))
      Me.grbSum = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.PieChart1 = New System.Drawing.PieChart.PieChartControl
      Me.ibtnZoomChart = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblItem = New System.Windows.Forms.Label
      Me.grbSumBid = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.lblTotalOverhead = New System.Windows.Forms.Label
      Me.lblMat = New System.Windows.Forms.Label
      Me.txtMatBase = New System.Windows.Forms.TextBox
      Me.txtMatBasePercent = New System.Windows.Forms.TextBox
      Me.txtBidMat = New System.Windows.Forms.TextBox
      Me.lblBasePricePercent = New System.Windows.Forms.Label
      Me.lblBidPrice = New System.Windows.Forms.Label
      Me.txtLaborBasePercent = New System.Windows.Forms.TextBox
      Me.lblLabor = New System.Windows.Forms.Label
      Me.txtLaborBase = New System.Windows.Forms.TextBox
      Me.txtBidLabor = New System.Windows.Forms.TextBox
      Me.txtDirectCostBasePercent = New System.Windows.Forms.TextBox
      Me.lblDirectCost = New System.Windows.Forms.Label
      Me.txtDirectCostBase = New System.Windows.Forms.TextBox
      Me.txtBidDirectCost = New System.Windows.Forms.TextBox
      Me.txtTotalOVerheadBasePercent = New System.Windows.Forms.TextBox
      Me.txtTotalOverheadBase = New System.Windows.Forms.TextBox
      Me.txtBidOverhead = New System.Windows.Forms.TextBox
      Me.txtProfitBasePercent = New System.Windows.Forms.TextBox
      Me.lblProfit = New System.Windows.Forms.Label
      Me.txtProfitBase = New System.Windows.Forms.TextBox
      Me.txtBidProfit = New System.Windows.Forms.TextBox
      Me.txtBid = New System.Windows.Forms.TextBox
      Me.txtBidBase = New System.Windows.Forms.TextBox
      Me.lblBid = New System.Windows.Forms.Label
      Me.txtBidPriceBasePercent = New System.Windows.Forms.TextBox
      Me.lblEquip = New System.Windows.Forms.Label
      Me.txtEquipBasePercent = New System.Windows.Forms.TextBox
      Me.txtBidEquip = New System.Windows.Forms.TextBox
      Me.txtEquipBase = New System.Windows.Forms.TextBox
      Me.lblBasePrice = New System.Windows.Forms.Label
      Me.txtBidOverheadPercent = New System.Windows.Forms.TextBox
      Me.txtBidMatPercent = New System.Windows.Forms.TextBox
      Me.txtBidPercent = New System.Windows.Forms.TextBox
      Me.lblBidPricePercent = New System.Windows.Forms.Label
      Me.txtBidLaborPercent = New System.Windows.Forms.TextBox
      Me.txtBidEquipPercent = New System.Windows.Forms.TextBox
      Me.txtBidDirectCostPercent = New System.Windows.Forms.TextBox
      Me.txtBidProfitPercent = New System.Windows.Forms.TextBox
      Me.lblBOQCode = New System.Windows.Forms.Label
      Me.txtBOQCode = New System.Windows.Forms.TextBox
      Me.txtProjectName = New System.Windows.Forms.TextBox
      Me.lblProject = New System.Windows.Forms.Label
      Me.txtProjectCode = New System.Windows.Forms.TextBox
      Me.ibtnZoomGrid = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnSaveAsExcel = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbSummarize = New System.Windows.Forms.GroupBox
      Me.lblLevel = New System.Windows.Forms.Label
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.chkHasVat = New System.Windows.Forms.CheckBox
      Me.lblVat = New System.Windows.Forms.Label
      Me.txtVat = New System.Windows.Forms.TextBox
      Me.lblBaht = New System.Windows.Forms.Label
      Me.grbSum.SuspendLayout()
      Me.PieChart1.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbSumBid.SuspendLayout()
      Me.grbSummarize.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbSum
      '
      Me.grbSum.Controls.Add(Me.PieChart1)
      Me.grbSum.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSum.Location = New System.Drawing.Point(448, 32)
      Me.grbSum.Name = "grbSum"
      Me.grbSum.Size = New System.Drawing.Size(256, 192)
      Me.grbSum.TabIndex = 6
      Me.grbSum.TabStop = False
      Me.grbSum.Text = "Summary Chart"
      '
      'PieChart1
      '
      Me.PieChart1.Controls.Add(Me.ibtnZoomChart)
      Me.PieChart1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PieChart1.Location = New System.Drawing.Point(3, 16)
      Me.PieChart1.Name = "PieChart1"
      Me.PieChart1.Size = New System.Drawing.Size(250, 173)
      Me.PieChart1.TabIndex = 1
      Me.PieChart1.ToolTips = Nothing
      '
      'ibtnZoomChart
      '
      Me.ibtnZoomChart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnZoomChart.Image = CType(resources.GetObject("ibtnZoomChart.Image"), System.Drawing.Image)
      Me.ibtnZoomChart.Location = New System.Drawing.Point(224, 144)
      Me.ibtnZoomChart.Name = "ibtnZoomChart"
      Me.ibtnZoomChart.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomChart.TabIndex = 9
      Me.ibtnZoomChart.TabStop = False
      Me.ibtnZoomChart.ThemedImage = CType(resources.GetObject("ibtnZoomChart.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 264)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(696, 224)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 248)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(128, 16)
      Me.lblItem.TabIndex = 7
      Me.lblItem.Text = "Final BOQ"
      '
      'grbSumBid
      '
      Me.grbSumBid.Controls.Add(Me.lblTotalOverhead)
      Me.grbSumBid.Controls.Add(Me.lblMat)
      Me.grbSumBid.Controls.Add(Me.txtMatBase)
      Me.grbSumBid.Controls.Add(Me.txtMatBasePercent)
      Me.grbSumBid.Controls.Add(Me.txtBidMat)
      Me.grbSumBid.Controls.Add(Me.lblBasePricePercent)
      Me.grbSumBid.Controls.Add(Me.lblBidPrice)
      Me.grbSumBid.Controls.Add(Me.txtLaborBasePercent)
      Me.grbSumBid.Controls.Add(Me.lblLabor)
      Me.grbSumBid.Controls.Add(Me.txtLaborBase)
      Me.grbSumBid.Controls.Add(Me.txtBidLabor)
      Me.grbSumBid.Controls.Add(Me.txtDirectCostBasePercent)
      Me.grbSumBid.Controls.Add(Me.lblDirectCost)
      Me.grbSumBid.Controls.Add(Me.txtDirectCostBase)
      Me.grbSumBid.Controls.Add(Me.txtBidDirectCost)
      Me.grbSumBid.Controls.Add(Me.txtTotalOVerheadBasePercent)
      Me.grbSumBid.Controls.Add(Me.txtTotalOverheadBase)
      Me.grbSumBid.Controls.Add(Me.txtBidOverhead)
      Me.grbSumBid.Controls.Add(Me.txtProfitBasePercent)
      Me.grbSumBid.Controls.Add(Me.lblProfit)
      Me.grbSumBid.Controls.Add(Me.txtProfitBase)
      Me.grbSumBid.Controls.Add(Me.txtBidProfit)
      Me.grbSumBid.Controls.Add(Me.txtBid)
      Me.grbSumBid.Controls.Add(Me.txtBidBase)
      Me.grbSumBid.Controls.Add(Me.lblBid)
      Me.grbSumBid.Controls.Add(Me.txtBidPriceBasePercent)
      Me.grbSumBid.Controls.Add(Me.lblEquip)
      Me.grbSumBid.Controls.Add(Me.txtEquipBasePercent)
      Me.grbSumBid.Controls.Add(Me.txtBidEquip)
      Me.grbSumBid.Controls.Add(Me.txtEquipBase)
      Me.grbSumBid.Controls.Add(Me.lblBasePrice)
      Me.grbSumBid.Controls.Add(Me.txtBidOverheadPercent)
      Me.grbSumBid.Controls.Add(Me.txtBidMatPercent)
      Me.grbSumBid.Controls.Add(Me.txtBidPercent)
      Me.grbSumBid.Controls.Add(Me.lblBidPricePercent)
      Me.grbSumBid.Controls.Add(Me.txtBidLaborPercent)
      Me.grbSumBid.Controls.Add(Me.txtBidEquipPercent)
      Me.grbSumBid.Controls.Add(Me.txtBidDirectCostPercent)
      Me.grbSumBid.Controls.Add(Me.txtBidProfitPercent)
      Me.grbSumBid.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSumBid.Location = New System.Drawing.Point(8, 32)
      Me.grbSumBid.Name = "grbSumBid"
      Me.grbSumBid.Size = New System.Drawing.Size(440, 192)
      Me.grbSumBid.TabIndex = 5
      Me.grbSumBid.TabStop = False
      Me.grbSumBid.Text = "สรุปราคาประมูล(หน่วย:บาท)"
      '
      'lblTotalOverhead
      '
      Me.lblTotalOverhead.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalOverhead.ForeColor = System.Drawing.Color.Black
      Me.lblTotalOverhead.Location = New System.Drawing.Point(8, 120)
      Me.lblTotalOverhead.Name = "lblTotalOverhead"
      Me.lblTotalOverhead.Size = New System.Drawing.Size(96, 24)
      Me.lblTotalOverhead.TabIndex = 20
      Me.lblTotalOverhead.Text = "Include Overhead Amout:"
      Me.lblTotalOverhead.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblMat
      '
      Me.lblMat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMat.ForeColor = System.Drawing.Color.Black
      Me.lblMat.Location = New System.Drawing.Point(8, 24)
      Me.lblMat.Name = "lblMat"
      Me.lblMat.Size = New System.Drawing.Size(96, 18)
      Me.lblMat.TabIndex = 0
      Me.lblMat.Text = "Materials Cost:"
      Me.lblMat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtMatBase
      '
      Me.txtMatBase.BackColor = System.Drawing.SystemColors.Info
      Me.txtMatBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtMatBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtMatBase.Location = New System.Drawing.Point(104, 24)
      Me.txtMatBase.Name = "txtMatBase"
      Me.txtMatBase.ReadOnly = True
      Me.txtMatBase.Size = New System.Drawing.Size(112, 22)
      Me.txtMatBase.TabIndex = 1
      Me.txtMatBase.TabStop = False
      Me.txtMatBase.Text = ""
      Me.txtMatBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtMatBasePercent
      '
      Me.txtMatBasePercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtMatBasePercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtMatBasePercent.Location = New System.Drawing.Point(216, 24)
      Me.txtMatBasePercent.Name = "txtMatBasePercent"
      Me.txtMatBasePercent.ReadOnly = True
      Me.txtMatBasePercent.Size = New System.Drawing.Size(48, 22)
      Me.txtMatBasePercent.TabIndex = 2
      Me.txtMatBasePercent.TabStop = False
      Me.txtMatBasePercent.Text = ""
      Me.txtMatBasePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidMat
      '
      Me.txtBidMat.BackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.txtBidMat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidMat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidMat.Location = New System.Drawing.Point(264, 24)
      Me.txtBidMat.Name = "txtBidMat"
      Me.txtBidMat.ReadOnly = True
      Me.txtBidMat.Size = New System.Drawing.Size(112, 22)
      Me.txtBidMat.TabIndex = 3
      Me.txtBidMat.TabStop = False
      Me.txtBidMat.Text = ""
      Me.txtBidMat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBasePricePercent
      '
      Me.lblBasePricePercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBasePricePercent.ForeColor = System.Drawing.Color.Black
      Me.lblBasePricePercent.Location = New System.Drawing.Point(232, 8)
      Me.lblBasePricePercent.Name = "lblBasePricePercent"
      Me.lblBasePricePercent.Size = New System.Drawing.Size(32, 18)
      Me.lblBasePricePercent.TabIndex = 36
      Me.lblBasePricePercent.Text = "%"
      Me.lblBasePricePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblBidPrice
      '
      Me.lblBidPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidPrice.ForeColor = System.Drawing.Color.Black
      Me.lblBidPrice.Location = New System.Drawing.Point(296, 8)
      Me.lblBidPrice.Name = "lblBidPrice"
      Me.lblBidPrice.Size = New System.Drawing.Size(72, 18)
      Me.lblBidPrice.TabIndex = 37
      Me.lblBidPrice.Text = "Bid Price"
      Me.lblBidPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtLaborBasePercent
      '
      Me.txtLaborBasePercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtLaborBasePercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtLaborBasePercent.Location = New System.Drawing.Point(216, 48)
      Me.txtLaborBasePercent.Name = "txtLaborBasePercent"
      Me.txtLaborBasePercent.ReadOnly = True
      Me.txtLaborBasePercent.Size = New System.Drawing.Size(48, 22)
      Me.txtLaborBasePercent.TabIndex = 7
      Me.txtLaborBasePercent.TabStop = False
      Me.txtLaborBasePercent.Text = ""
      Me.txtLaborBasePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblLabor
      '
      Me.lblLabor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLabor.ForeColor = System.Drawing.Color.Black
      Me.lblLabor.Location = New System.Drawing.Point(8, 48)
      Me.lblLabor.Name = "lblLabor"
      Me.lblLabor.Size = New System.Drawing.Size(96, 18)
      Me.lblLabor.TabIndex = 5
      Me.lblLabor.Text = "Labor:"
      Me.lblLabor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLaborBase
      '
      Me.txtLaborBase.BackColor = System.Drawing.SystemColors.Info
      Me.txtLaborBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtLaborBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtLaborBase.Location = New System.Drawing.Point(104, 48)
      Me.txtLaborBase.Name = "txtLaborBase"
      Me.txtLaborBase.ReadOnly = True
      Me.txtLaborBase.Size = New System.Drawing.Size(112, 22)
      Me.txtLaborBase.TabIndex = 6
      Me.txtLaborBase.TabStop = False
      Me.txtLaborBase.Text = ""
      Me.txtLaborBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidLabor
      '
      Me.txtBidLabor.BackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.txtBidLabor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidLabor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidLabor.Location = New System.Drawing.Point(264, 48)
      Me.txtBidLabor.Name = "txtBidLabor"
      Me.txtBidLabor.ReadOnly = True
      Me.txtBidLabor.Size = New System.Drawing.Size(112, 22)
      Me.txtBidLabor.TabIndex = 8
      Me.txtBidLabor.TabStop = False
      Me.txtBidLabor.Text = ""
      Me.txtBidLabor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDirectCostBasePercent
      '
      Me.txtDirectCostBasePercent.BackColor = System.Drawing.Color.DimGray
      Me.txtDirectCostBasePercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtDirectCostBasePercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtDirectCostBasePercent.ForeColor = System.Drawing.Color.White
      Me.txtDirectCostBasePercent.Location = New System.Drawing.Point(216, 96)
      Me.txtDirectCostBasePercent.Name = "txtDirectCostBasePercent"
      Me.txtDirectCostBasePercent.ReadOnly = True
      Me.txtDirectCostBasePercent.Size = New System.Drawing.Size(48, 22)
      Me.txtDirectCostBasePercent.TabIndex = 17
      Me.txtDirectCostBasePercent.TabStop = False
      Me.txtDirectCostBasePercent.Text = ""
      Me.txtDirectCostBasePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDirectCost
      '
      Me.lblDirectCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDirectCost.ForeColor = System.Drawing.Color.Black
      Me.lblDirectCost.Location = New System.Drawing.Point(3, 96)
      Me.lblDirectCost.Name = "lblDirectCost"
      Me.lblDirectCost.Size = New System.Drawing.Size(101, 18)
      Me.lblDirectCost.TabIndex = 15
      Me.lblDirectCost.Text = "Total Direct Cost:"
      Me.lblDirectCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDirectCostBase
      '
      Me.txtDirectCostBase.BackColor = System.Drawing.Color.DimGray
      Me.txtDirectCostBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtDirectCostBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtDirectCostBase.ForeColor = System.Drawing.Color.White
      Me.txtDirectCostBase.Location = New System.Drawing.Point(104, 96)
      Me.txtDirectCostBase.Name = "txtDirectCostBase"
      Me.txtDirectCostBase.ReadOnly = True
      Me.txtDirectCostBase.Size = New System.Drawing.Size(112, 22)
      Me.txtDirectCostBase.TabIndex = 16
      Me.txtDirectCostBase.TabStop = False
      Me.txtDirectCostBase.Text = ""
      Me.txtDirectCostBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidDirectCost
      '
      Me.txtBidDirectCost.BackColor = System.Drawing.Color.DimGray
      Me.txtBidDirectCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidDirectCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidDirectCost.ForeColor = System.Drawing.Color.White
      Me.txtBidDirectCost.Location = New System.Drawing.Point(264, 96)
      Me.txtBidDirectCost.Name = "txtBidDirectCost"
      Me.txtBidDirectCost.ReadOnly = True
      Me.txtBidDirectCost.Size = New System.Drawing.Size(112, 22)
      Me.txtBidDirectCost.TabIndex = 18
      Me.txtBidDirectCost.TabStop = False
      Me.txtBidDirectCost.Text = ""
      Me.txtBidDirectCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalOVerheadBasePercent
      '
      Me.txtTotalOVerheadBasePercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtTotalOVerheadBasePercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtTotalOVerheadBasePercent.Location = New System.Drawing.Point(216, 120)
      Me.txtTotalOVerheadBasePercent.Name = "txtTotalOVerheadBasePercent"
      Me.txtTotalOVerheadBasePercent.ReadOnly = True
      Me.txtTotalOVerheadBasePercent.Size = New System.Drawing.Size(48, 22)
      Me.txtTotalOVerheadBasePercent.TabIndex = 22
      Me.txtTotalOVerheadBasePercent.TabStop = False
      Me.txtTotalOVerheadBasePercent.Text = ""
      Me.txtTotalOVerheadBasePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalOverheadBase
      '
      Me.txtTotalOverheadBase.BackColor = System.Drawing.SystemColors.Info
      Me.txtTotalOverheadBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtTotalOverheadBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtTotalOverheadBase.Location = New System.Drawing.Point(104, 120)
      Me.txtTotalOverheadBase.Name = "txtTotalOverheadBase"
      Me.txtTotalOverheadBase.ReadOnly = True
      Me.txtTotalOverheadBase.Size = New System.Drawing.Size(112, 22)
      Me.txtTotalOverheadBase.TabIndex = 21
      Me.txtTotalOverheadBase.TabStop = False
      Me.txtTotalOverheadBase.Text = ""
      Me.txtTotalOverheadBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidOverhead
      '
      Me.txtBidOverhead.BackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.txtBidOverhead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidOverhead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidOverhead.Location = New System.Drawing.Point(264, 120)
      Me.txtBidOverhead.Name = "txtBidOverhead"
      Me.txtBidOverhead.ReadOnly = True
      Me.txtBidOverhead.Size = New System.Drawing.Size(112, 22)
      Me.txtBidOverhead.TabIndex = 23
      Me.txtBidOverhead.TabStop = False
      Me.txtBidOverhead.Text = ""
      Me.txtBidOverhead.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtProfitBasePercent
      '
      Me.txtProfitBasePercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtProfitBasePercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtProfitBasePercent.Location = New System.Drawing.Point(216, 144)
      Me.txtProfitBasePercent.Name = "txtProfitBasePercent"
      Me.txtProfitBasePercent.ReadOnly = True
      Me.txtProfitBasePercent.Size = New System.Drawing.Size(48, 22)
      Me.txtProfitBasePercent.TabIndex = 27
      Me.txtProfitBasePercent.TabStop = False
      Me.txtProfitBasePercent.Text = ""
      Me.txtProfitBasePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblProfit
      '
      Me.lblProfit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProfit.ForeColor = System.Drawing.Color.Black
      Me.lblProfit.Location = New System.Drawing.Point(8, 144)
      Me.lblProfit.Name = "lblProfit"
      Me.lblProfit.Size = New System.Drawing.Size(96, 18)
      Me.lblProfit.TabIndex = 25
      Me.lblProfit.Text = "Profit:"
      Me.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtProfitBase
      '
      Me.txtProfitBase.BackColor = System.Drawing.SystemColors.Info
      Me.txtProfitBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtProfitBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtProfitBase.Location = New System.Drawing.Point(104, 144)
      Me.txtProfitBase.Name = "txtProfitBase"
      Me.txtProfitBase.ReadOnly = True
      Me.txtProfitBase.Size = New System.Drawing.Size(112, 22)
      Me.txtProfitBase.TabIndex = 26
      Me.txtProfitBase.TabStop = False
      Me.txtProfitBase.Text = ""
      Me.txtProfitBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidProfit
      '
      Me.txtBidProfit.BackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.txtBidProfit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidProfit.Location = New System.Drawing.Point(264, 144)
      Me.txtBidProfit.Name = "txtBidProfit"
      Me.txtBidProfit.ReadOnly = True
      Me.txtBidProfit.Size = New System.Drawing.Size(112, 22)
      Me.txtBidProfit.TabIndex = 28
      Me.txtBidProfit.TabStop = False
      Me.txtBidProfit.Text = ""
      Me.txtBidProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBid
      '
      Me.txtBid.BackColor = System.Drawing.Color.DimGray
      Me.txtBid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBid.ForeColor = System.Drawing.Color.White
      Me.txtBid.Location = New System.Drawing.Point(264, 168)
      Me.txtBid.Name = "txtBid"
      Me.txtBid.ReadOnly = True
      Me.txtBid.Size = New System.Drawing.Size(112, 22)
      Me.txtBid.TabIndex = 33
      Me.txtBid.TabStop = False
      Me.txtBid.Text = ""
      Me.txtBid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidBase
      '
      Me.txtBidBase.BackColor = System.Drawing.Color.DimGray
      Me.txtBidBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidBase.ForeColor = System.Drawing.Color.White
      Me.txtBidBase.Location = New System.Drawing.Point(104, 168)
      Me.txtBidBase.Name = "txtBidBase"
      Me.txtBidBase.ReadOnly = True
      Me.txtBidBase.Size = New System.Drawing.Size(112, 22)
      Me.txtBidBase.TabIndex = 31
      Me.txtBidBase.TabStop = False
      Me.txtBidBase.Text = ""
      Me.txtBidBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBid
      '
      Me.lblBid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBid.ForeColor = System.Drawing.Color.Black
      Me.lblBid.Location = New System.Drawing.Point(8, 168)
      Me.lblBid.Name = "lblBid"
      Me.lblBid.Size = New System.Drawing.Size(96, 18)
      Me.lblBid.TabIndex = 30
      Me.lblBid.Text = "Bid Price:"
      Me.lblBid.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBidPriceBasePercent
      '
      Me.txtBidPriceBasePercent.BackColor = System.Drawing.Color.DimGray
      Me.txtBidPriceBasePercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidPriceBasePercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidPriceBasePercent.ForeColor = System.Drawing.Color.White
      Me.txtBidPriceBasePercent.Location = New System.Drawing.Point(216, 168)
      Me.txtBidPriceBasePercent.Name = "txtBidPriceBasePercent"
      Me.txtBidPriceBasePercent.ReadOnly = True
      Me.txtBidPriceBasePercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidPriceBasePercent.TabIndex = 32
      Me.txtBidPriceBasePercent.TabStop = False
      Me.txtBidPriceBasePercent.Text = ""
      Me.txtBidPriceBasePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblEquip
      '
      Me.lblEquip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEquip.ForeColor = System.Drawing.Color.Black
      Me.lblEquip.Location = New System.Drawing.Point(8, 72)
      Me.lblEquip.Name = "lblEquip"
      Me.lblEquip.Size = New System.Drawing.Size(96, 18)
      Me.lblEquip.TabIndex = 10
      Me.lblEquip.Text = "Equipment Cost:"
      Me.lblEquip.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtEquipBasePercent
      '
      Me.txtEquipBasePercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtEquipBasePercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtEquipBasePercent.Location = New System.Drawing.Point(216, 72)
      Me.txtEquipBasePercent.Name = "txtEquipBasePercent"
      Me.txtEquipBasePercent.ReadOnly = True
      Me.txtEquipBasePercent.Size = New System.Drawing.Size(48, 22)
      Me.txtEquipBasePercent.TabIndex = 12
      Me.txtEquipBasePercent.TabStop = False
      Me.txtEquipBasePercent.Text = ""
      Me.txtEquipBasePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidEquip
      '
      Me.txtBidEquip.BackColor = System.Drawing.SystemColors.InactiveCaptionText
      Me.txtBidEquip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidEquip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidEquip.Location = New System.Drawing.Point(264, 72)
      Me.txtBidEquip.Name = "txtBidEquip"
      Me.txtBidEquip.ReadOnly = True
      Me.txtBidEquip.Size = New System.Drawing.Size(112, 22)
      Me.txtBidEquip.TabIndex = 13
      Me.txtBidEquip.TabStop = False
      Me.txtBidEquip.Text = ""
      Me.txtBidEquip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtEquipBase
      '
      Me.txtEquipBase.BackColor = System.Drawing.SystemColors.Info
      Me.txtEquipBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtEquipBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtEquipBase.Location = New System.Drawing.Point(104, 72)
      Me.txtEquipBase.Name = "txtEquipBase"
      Me.txtEquipBase.ReadOnly = True
      Me.txtEquipBase.Size = New System.Drawing.Size(112, 22)
      Me.txtEquipBase.TabIndex = 11
      Me.txtEquipBase.TabStop = False
      Me.txtEquipBase.Text = ""
      Me.txtEquipBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBasePrice
      '
      Me.lblBasePrice.BackColor = System.Drawing.Color.Transparent
      Me.lblBasePrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBasePrice.ForeColor = System.Drawing.Color.Black
      Me.lblBasePrice.Location = New System.Drawing.Point(144, 8)
      Me.lblBasePrice.Name = "lblBasePrice"
      Me.lblBasePrice.Size = New System.Drawing.Size(64, 18)
      Me.lblBasePrice.TabIndex = 35
      Me.lblBasePrice.Text = "Base Price"
      Me.lblBasePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtBidOverheadPercent
      '
      Me.txtBidOverheadPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidOverheadPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidOverheadPercent.Location = New System.Drawing.Point(376, 120)
      Me.txtBidOverheadPercent.Name = "txtBidOverheadPercent"
      Me.txtBidOverheadPercent.ReadOnly = True
      Me.txtBidOverheadPercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidOverheadPercent.TabIndex = 24
      Me.txtBidOverheadPercent.TabStop = False
      Me.txtBidOverheadPercent.Text = ""
      Me.txtBidOverheadPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidMatPercent
      '
      Me.txtBidMatPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidMatPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidMatPercent.Location = New System.Drawing.Point(376, 24)
      Me.txtBidMatPercent.Name = "txtBidMatPercent"
      Me.txtBidMatPercent.ReadOnly = True
      Me.txtBidMatPercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidMatPercent.TabIndex = 4
      Me.txtBidMatPercent.TabStop = False
      Me.txtBidMatPercent.Text = ""
      Me.txtBidMatPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidPercent
      '
      Me.txtBidPercent.BackColor = System.Drawing.Color.DimGray
      Me.txtBidPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidPercent.ForeColor = System.Drawing.Color.White
      Me.txtBidPercent.Location = New System.Drawing.Point(376, 168)
      Me.txtBidPercent.Name = "txtBidPercent"
      Me.txtBidPercent.ReadOnly = True
      Me.txtBidPercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidPercent.TabIndex = 34
      Me.txtBidPercent.TabStop = False
      Me.txtBidPercent.Text = ""
      Me.txtBidPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBidPricePercent
      '
      Me.lblBidPricePercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidPricePercent.ForeColor = System.Drawing.Color.Black
      Me.lblBidPricePercent.Location = New System.Drawing.Point(392, 8)
      Me.lblBidPricePercent.Name = "lblBidPricePercent"
      Me.lblBidPricePercent.Size = New System.Drawing.Size(32, 18)
      Me.lblBidPricePercent.TabIndex = 38
      Me.lblBidPricePercent.Text = "%"
      Me.lblBidPricePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtBidLaborPercent
      '
      Me.txtBidLaborPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidLaborPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidLaborPercent.Location = New System.Drawing.Point(376, 48)
      Me.txtBidLaborPercent.Name = "txtBidLaborPercent"
      Me.txtBidLaborPercent.ReadOnly = True
      Me.txtBidLaborPercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidLaborPercent.TabIndex = 9
      Me.txtBidLaborPercent.TabStop = False
      Me.txtBidLaborPercent.Text = ""
      Me.txtBidLaborPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidEquipPercent
      '
      Me.txtBidEquipPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidEquipPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidEquipPercent.Location = New System.Drawing.Point(376, 72)
      Me.txtBidEquipPercent.Name = "txtBidEquipPercent"
      Me.txtBidEquipPercent.ReadOnly = True
      Me.txtBidEquipPercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidEquipPercent.TabIndex = 14
      Me.txtBidEquipPercent.TabStop = False
      Me.txtBidEquipPercent.Text = ""
      Me.txtBidEquipPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidDirectCostPercent
      '
      Me.txtBidDirectCostPercent.BackColor = System.Drawing.Color.DimGray
      Me.txtBidDirectCostPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidDirectCostPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidDirectCostPercent.ForeColor = System.Drawing.Color.White
      Me.txtBidDirectCostPercent.Location = New System.Drawing.Point(376, 96)
      Me.txtBidDirectCostPercent.Name = "txtBidDirectCostPercent"
      Me.txtBidDirectCostPercent.ReadOnly = True
      Me.txtBidDirectCostPercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidDirectCostPercent.TabIndex = 19
      Me.txtBidDirectCostPercent.TabStop = False
      Me.txtBidDirectCostPercent.Text = ""
      Me.txtBidDirectCostPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBidProfitPercent
      '
      Me.txtBidProfitPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtBidProfitPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBidProfitPercent.Location = New System.Drawing.Point(376, 144)
      Me.txtBidProfitPercent.Name = "txtBidProfitPercent"
      Me.txtBidProfitPercent.ReadOnly = True
      Me.txtBidProfitPercent.Size = New System.Drawing.Size(48, 22)
      Me.txtBidProfitPercent.TabIndex = 29
      Me.txtBidProfitPercent.TabStop = False
      Me.txtBidProfitPercent.Text = ""
      Me.txtBidProfitPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBOQCode
      '
      Me.lblBOQCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBOQCode.ForeColor = System.Drawing.Color.Black
      Me.lblBOQCode.Location = New System.Drawing.Point(8, 8)
      Me.lblBOQCode.Name = "lblBOQCode"
      Me.lblBOQCode.Size = New System.Drawing.Size(56, 18)
      Me.lblBOQCode.TabIndex = 0
      Me.lblBOQCode.Text = "รหัสBOQ:"
      Me.lblBOQCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBOQCode
      '
      Me.txtBOQCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtBOQCode.Location = New System.Drawing.Point(64, 6)
      Me.txtBOQCode.Name = "txtBOQCode"
      Me.txtBOQCode.ReadOnly = True
      Me.txtBOQCode.Size = New System.Drawing.Size(96, 22)
      Me.txtBOQCode.TabIndex = 1
      Me.txtBOQCode.TabStop = False
      Me.txtBOQCode.Text = ""
      '
      'txtProjectName
      '
      Me.txtProjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtProjectName.Location = New System.Drawing.Point(344, 6)
      Me.txtProjectName.Name = "txtProjectName"
      Me.txtProjectName.ReadOnly = True
      Me.txtProjectName.Size = New System.Drawing.Size(352, 22)
      Me.txtProjectName.TabIndex = 4
      Me.txtProjectName.TabStop = False
      Me.txtProjectName.Text = ""
      '
      'lblProject
      '
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.ForeColor = System.Drawing.Color.Black
      Me.lblProject.Location = New System.Drawing.Point(160, 8)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(88, 18)
      Me.lblProject.TabIndex = 2
      Me.lblProject.Text = "โครงการ:"
      Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtProjectCode
      '
      Me.txtProjectCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtProjectCode.Location = New System.Drawing.Point(248, 6)
      Me.txtProjectCode.Name = "txtProjectCode"
      Me.txtProjectCode.ReadOnly = True
      Me.txtProjectCode.Size = New System.Drawing.Size(96, 22)
      Me.txtProjectCode.TabIndex = 3
      Me.txtProjectCode.TabStop = False
      Me.txtProjectCode.Text = ""
      '
      'ibtnZoomGrid
      '
      Me.ibtnZoomGrid.Image = CType(resources.GetObject("ibtnZoomGrid.Image"), System.Drawing.Image)
      Me.ibtnZoomGrid.Location = New System.Drawing.Point(144, 240)
      Me.ibtnZoomGrid.Name = "ibtnZoomGrid"
      Me.ibtnZoomGrid.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomGrid.TabIndex = 10
      Me.ibtnZoomGrid.TabStop = False
      Me.ibtnZoomGrid.ThemedImage = CType(resources.GetObject("ibtnZoomGrid.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnSaveAsExcel
      '
      Me.ibtnSaveAsExcel.Image = CType(resources.GetObject("ibtnSaveAsExcel.Image"), System.Drawing.Image)
      Me.ibtnSaveAsExcel.Location = New System.Drawing.Point(176, 240)
      Me.ibtnSaveAsExcel.Name = "ibtnSaveAsExcel"
      Me.ibtnSaveAsExcel.Size = New System.Drawing.Size(24, 24)
      Me.ibtnSaveAsExcel.TabIndex = 10
      Me.ibtnSaveAsExcel.TabStop = False
      Me.ibtnSaveAsExcel.ThemedImage = CType(resources.GetObject("ibtnSaveAsExcel.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbSummarize
      '
      Me.grbSummarize.Controls.Add(Me.lblLevel)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomOut)
      Me.grbSummarize.Controls.Add(Me.ibtnZoomIn)
      Me.grbSummarize.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummarize.Location = New System.Drawing.Point(240, 225)
      Me.grbSummarize.Name = "grbSummarize"
      Me.grbSummarize.Size = New System.Drawing.Size(112, 40)
      Me.grbSummarize.TabIndex = 16
      Me.grbSummarize.TabStop = False
      Me.grbSummarize.Text = "Summarize"
      '
      'lblLevel
      '
      Me.lblLevel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLevel.Location = New System.Drawing.Point(64, 16)
      Me.lblLevel.Name = "lblLevel"
      Me.lblLevel.Size = New System.Drawing.Size(40, 23)
      Me.lblLevel.TabIndex = 13
      Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.Image = CType(resources.GetObject("ibtnZoomOut.Image"), System.Drawing.Image)
      Me.ibtnZoomOut.Location = New System.Drawing.Point(16, 16)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 12
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.Image = CType(resources.GetObject("ibtnZoomIn.Image"), System.Drawing.Image)
      Me.ibtnZoomIn.Location = New System.Drawing.Point(40, 16)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 11
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkHasVat
      '
      Me.chkHasVat.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkHasVat.Location = New System.Drawing.Point(360, 237)
      Me.chkHasVat.Name = "chkHasVat"
      Me.chkHasVat.Size = New System.Drawing.Size(96, 24)
      Me.chkHasVat.TabIndex = 17
      Me.chkHasVat.Text = "VATable"
      '
      'lblVat
      '
      Me.lblVat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblVat.ForeColor = System.Drawing.Color.Black
      Me.lblVat.Location = New System.Drawing.Point(456, 240)
      Me.lblVat.Name = "lblVat"
      Me.lblVat.Size = New System.Drawing.Size(80, 18)
      Me.lblVat.TabIndex = 25
      Me.lblVat.Text = "ภาษีมูลค่าเพิ่ม:"
      Me.lblVat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtVat
      '
      Me.txtVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtVat.Location = New System.Drawing.Point(536, 238)
      Me.txtVat.Name = "txtVat"
      Me.txtVat.Size = New System.Drawing.Size(120, 22)
      Me.txtVat.TabIndex = 26
      Me.txtVat.TabStop = False
      Me.txtVat.Text = ""
      Me.txtVat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.ForeColor = System.Drawing.Color.Black
      Me.lblBaht.Location = New System.Drawing.Point(656, 240)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(40, 18)
      Me.lblBaht.TabIndex = 25
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Summary
      '
      Me.Controls.Add(Me.chkHasVat)
      Me.Controls.Add(Me.grbSummarize)
      Me.Controls.Add(Me.ibtnZoomGrid)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.lblBOQCode)
      Me.Controls.Add(Me.txtBOQCode)
      Me.Controls.Add(Me.txtProjectName)
      Me.Controls.Add(Me.lblProject)
      Me.Controls.Add(Me.txtProjectCode)
      Me.Controls.Add(Me.grbSumBid)
      Me.Controls.Add(Me.grbSum)
      Me.Controls.Add(Me.ibtnSaveAsExcel)
      Me.Controls.Add(Me.lblVat)
      Me.Controls.Add(Me.txtVat)
      Me.Controls.Add(Me.lblBaht)
      Me.Name = "Summary"
      Me.Size = New System.Drawing.Size(712, 496)
      Me.grbSum.ResumeLayout(False)
      Me.PieChart1.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbSumBid.ResumeLayout(False)
      Me.grbSummarize.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As BOQ
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableInitialized As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = BOQ.GetSchemaTable()
      m_treeManager = New TreeManager(dt, tgItem)
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Wire()

      EventWiring()
    End Sub
    Private Sub Unwire()
      Dim dt As TreeTable = m_treeManager.TreeTable
      RemoveHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler
    End Sub
    Private Sub Wire()
      Dim dt As TreeTable = m_treeManager.TreeTable
      AddHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler
    End Sub
    Private Sub RowExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)
      If TypeOf e.Row.Tag Is WBS Then
        CType(e.Row.Tag, WBS).State = e.Row.State
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      ElseIf TypeOf e.Row.Tag Is Integer Then
        Me.m_entity.SetState(CInt(e.Row.Tag), e.Row.State)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim includeQtyPerWBS As Boolean = False
      Dim icq As Object = Configuration.GetConfig("includeQtyPerWBS")
      If Not IsDBNull(icq) AndAlso Not icq Is Nothing Then
        includeQtyPerWBS = CBool(icq)
      End If
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"

      Dim csType As New TreeTextColumn
      csType.MappingName = "boqi_entityTypeDesc"
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TypeHeaderText}")
      csType.NullText = ""
      csType.TextBox.Name = "boqi_entityTypeDesc"
      csType.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CodeHeaderText}")
      csCode.NullText = ""
      csCode.TextBox.Name = "Code"
      csCode.ReadOnly = True

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "boqi_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      csQty.ReadOnly = True

      Dim csUMC As New TreeTextColumn
      csUMC.MappingName = "boqi_umc"
      csUMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UMCHeaderText}")
      csUMC.NullText = ""
      csUMC.DataAlignment = HorizontalAlignment.Right
      csUMC.Format = "#,###.##"
      csUMC.TextBox.Name = "boqi_umc"
      csUMC.ReadOnly = True

      Dim csTotalMC As New TreeTextColumn
      csTotalMC.MappingName = "TotalMaterialCost"
      csTotalMC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalMaterialCostHeaderText}")
      csTotalMC.NullText = ""
      csTotalMC.DataAlignment = HorizontalAlignment.Right
      csTotalMC.Format = "#,###.##"
      csTotalMC.TextBox.Name = "TotalMaterialCost"
      csTotalMC.ReadOnly = True

      Dim csULC As New TreeTextColumn
      csULC.MappingName = "boqi_ulc"
      csULC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.ULCHeaderText}")
      csULC.NullText = ""
      csULC.DataAlignment = HorizontalAlignment.Right
      csULC.Format = "#,###.##"
      csULC.TextBox.Name = "boqi_ulc"
      csULC.ReadOnly = True

      Dim csTotalLC As New TreeTextColumn
      csTotalLC.MappingName = "TotalLaborCost"
      csTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalLaborCostHeaderText}")
      csTotalLC.NullText = ""
      csTotalLC.DataAlignment = HorizontalAlignment.Right
      csTotalLC.Format = "#,###.##"
      csTotalLC.TextBox.Name = "TotalLaborCost"
      csTotalLC.ReadOnly = True

      Dim csUEC As New TreeTextColumn
      csUEC.MappingName = "boqi_uec"
      csUEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.UECHeaderText}")
      csUEC.NullText = ""
      csUEC.DataAlignment = HorizontalAlignment.Right
      csUEC.Format = "#,###.##"
      csUEC.TextBox.Name = "boqi_uec"
      csUEC.ReadOnly = True

      Dim csTotalEC As New TreeTextColumn
      csTotalEC.MappingName = "TotalEquipmentCost"
      csTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalEquipmentCostHeaderText}")
      csTotalEC.NullText = ""
      csTotalEC.DataAlignment = HorizontalAlignment.Right
      csTotalEC.Format = "#,###.##"
      csTotalEC.TextBox.Name = "TotalEquipmentCost"
      csTotalEC.ReadOnly = True

      Dim csTotal As New TreeTextColumn
      csTotal.MappingName = "Total"
      csTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalCostHeaderText}")
      csTotal.NullText = ""
      csTotal.DataAlignment = HorizontalAlignment.Right
      csTotal.Format = "#,###.##"
      csTotal.TextBox.Name = "Total"
      csTotal.ReadOnly = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "boqi_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "boqi_note"
      csNote.ReadOnly = True

      '-------------------------------ธวัชชัย-----------------------------
      Dim csQtyPerWBS As New TreeTextColumn
      csQtyPerWBS.MappingName = "QtyPerWBS"
      csQtyPerWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.QtyPerWBSHeaderText}")
      csQtyPerWBS.NullText = ""
      csQtyPerWBS.DataAlignment = HorizontalAlignment.Right
      csQtyPerWBS.Format = "#,###.##"
      csQtyPerWBS.TextBox.Name = "QtyPerWBS"
      csQtyPerWBS.Width = 100

      Dim csWBSQty As New TreeTextColumn
      csWBSQty.MappingName = "WBSQty"
      csWBSQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.WBSQtyHeaderText}")
      csWBSQty.NullText = ""
      csWBSQty.DataAlignment = HorizontalAlignment.Right
      csWBSQty.Format = "#,###.##"
      csWBSQty.TextBox.Name = "WBSQty"
      csWBSQty.Width = 100

      Dim csTotalPerWBS As New TreeTextColumn
      csTotalPerWBS.MappingName = "TotalPerWBS"
      csTotalPerWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.TotalPerWBSHeaderText}")
      csTotalPerWBS.NullText = ""
      csTotalPerWBS.DataAlignment = HorizontalAlignment.Right
      csTotalPerWBS.Format = "#,###.##"
      csTotalPerWBS.TextBox.Name = "TotalPerWBS"
      csTotalPerWBS.ReadOnly = True
      csTotalPerWBS.Width = 100
      '-------------------------------End ธวัชชัย-----------------------------

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)

      If includeQtyPerWBS Then
        dst.GridColumnStyles.Add(csQtyPerWBS)
        'dst.GridColumnStyles.Add(csWBSQty)
      End If

      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUMC)
      dst.GridColumnStyles.Add(csTotalMC)
      dst.GridColumnStyles.Add(csULC)
      dst.GridColumnStyles.Add(csTotalLC)
      dst.GridColumnStyles.Add(csUEC)
      dst.GridColumnStyles.Add(csTotalEC)

      If includeQtyPerWBS Then
        dst.GridColumnStyles.Add(csTotalPerWBS)
      End If

      dst.GridColumnStyles.Add(csTotal)

      Return dst
    End Function
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()

    End Sub
    Public Overrides Sub ClearDetail()
      ClearGraph()
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      If Not m_entity Is Nothing AndAlso Me.m_entity.TaxAmount <> 0 Then
        Me.txtVat.ReadOnly = False
        Me.chkHasVat.Checked = True
      Else
        Me.txtVat.ReadOnly = True
        Me.chkHasVat.Checked = False
      End If
      m_isInitialized = flag
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblItem}")
      Me.lblMat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblMat}")
      Me.lblLabor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblLabor}")
      Me.lblDirectCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblDirectCost}")
      Me.lblTotalOverhead.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblTotalOverhead}")
      Me.grbSum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.grbSum}")
      Me.lblBasePricePercent.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
      Me.lblBidPrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblBidPrice}")
      Me.lblBid.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblBid}")
      Me.lblBasePrice.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblBasePrice}")
      Me.lblBidPricePercent.Text = Me.StringParserService.Parse("${res:Global.PercentText}")
      Me.lblProfit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblProfit}")
      Me.grbSumBid.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.grbSumBid}")
      Me.lblEquip.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblEquip}")
      Me.lblBOQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblBOQCode}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblProject}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyText}")
      Me.lblVat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.lblVat}")
      Me.grbSummarize.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Summary.grbSummarize}")
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler txtVat.Validated, AddressOf Me.NumberTextBoxChange
      AddHandler txtVat.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      txtBOQCode.Text = m_entity.Code
      txtProjectCode.Text = m_entity.Project.Code
      txtProjectName.Text = m_entity.Project.Name

      UpdateAmount()
      'InitProgress()
      'Me.m_tableInitialized = False
      'Unwire()
      'Me.m_entity.PopulateFinalItemListing(m_treeManager, AddressOf WorkDone)
      'Wire()
      'Me.tgItem.RefreshHeights()
      'Me.m_tableInitialized = True

      RefreshItems()

      If Me.m_entity.FinalBidPrice > 0 Then
        DrawGraph()
      Else
        ClearGraph()
      End If

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub ClearGraph()
      Me.PieChart1.Visible = False
    End Sub
    Public Sub UpdateAmount()
      Me.txtMatBase.Text = Configuration.FormatToString(Me.m_entity.MaterialCost, DigitConfig.Price)

      Me.txtLaborBase.Text = Configuration.FormatToString(Me.m_entity.LaborCost, DigitConfig.Price)

      Me.txtEquipBase.Text = Configuration.FormatToString(Me.m_entity.EquipmentCost, DigitConfig.Price)

      Me.txtDirectCostBase.Text = Configuration.FormatToString(Me.m_entity.DirectCost, DigitConfig.Price)

      Me.txtProfitBase.Text = Configuration.FormatToString(Me.m_entity.Profit, DigitConfig.Price)

      Me.txtTotalOverheadBase.Text = Configuration.FormatToString(Me.m_entity.Overhead, DigitConfig.Price)

      Me.txtBidBase.Text = Configuration.FormatToString(Me.m_entity.TotalAmount, DigitConfig.Price)

      Me.txtVat.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)

      If Me.m_entity.TotalAmount <> 0 Then
        Me.txtMatBasePercent.Text = Configuration.FormatToString((Me.m_entity.MaterialCost / Me.m_entity.TotalAmount) * 100, DigitConfig.Price)
        Me.txtLaborBasePercent.Text = Configuration.FormatToString((Me.m_entity.LaborCost / Me.m_entity.TotalAmount) * 100, DigitConfig.Price)
        Me.txtEquipBasePercent.Text = Configuration.FormatToString((Me.m_entity.EquipmentCost / Me.m_entity.TotalAmount) * 100, DigitConfig.Price)
        Me.txtDirectCostBasePercent.Text = Configuration.FormatToString((Me.m_entity.DirectCost / Me.m_entity.TotalAmount) * 100, DigitConfig.Price)
        Me.txtProfitBasePercent.Text = Configuration.FormatToString((Me.m_entity.Profit / Me.m_entity.TotalAmount) * 100, DigitConfig.Price)
        Me.txtTotalOVerheadBasePercent.Text = Configuration.FormatToString((Me.m_entity.Overhead / Me.m_entity.TotalAmount) * 100, DigitConfig.Price)
        Me.txtBidPriceBasePercent.Text = Configuration.FormatToString((Me.m_entity.TotalAmount / Me.m_entity.TotalAmount) * 100, DigitConfig.Price)
      Else
        Me.txtMatBasePercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtLaborBasePercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtEquipBasePercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtDirectCostBasePercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtProfitBasePercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtTotalOVerheadBasePercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtBidPriceBasePercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
      End If
      '***********************************************************************************************
      Me.txtBidMat.Text = Configuration.FormatToString(Me.m_entity.FinalMaterialCost, DigitConfig.Price)

      Me.txtBidLabor.Text = Configuration.FormatToString(Me.m_entity.FinalLaborCost, DigitConfig.Price)

      Me.txtBidEquip.Text = Configuration.FormatToString(Me.m_entity.FinalEquipmentCost, DigitConfig.Price)

      Me.txtBidDirectCost.Text = Configuration.FormatToString(Me.m_entity.FinalDirectCost, DigitConfig.Price)

      Me.txtBidProfit.Text = Configuration.FormatToString(Me.m_entity.FinalProfit, DigitConfig.Price)

      Me.txtBidOverhead.Text = Configuration.FormatToString(Me.m_entity.FinalOverhead, DigitConfig.Price)

      'Me.txtBid.Text = Configuration.FormatToString(Me.m_entity.FinalBidPrice, DigitConfig.Price)
      Me.txtBid.Text = Configuration.FormatToString(Me.m_entity.FinalBidPriceWithVat, DigitConfig.Price)

      If Me.m_entity.FinalBidPrice <> 0 Then
        Me.txtBidMatPercent.Text = Configuration.FormatToString((Me.m_entity.FinalMaterialCost / Me.m_entity.FinalBidPrice) * 100, DigitConfig.Price)
        Me.txtBidLaborPercent.Text = Configuration.FormatToString((Me.m_entity.FinalLaborCost / Me.m_entity.FinalBidPrice) * 100, DigitConfig.Price)
        Me.txtBidEquipPercent.Text = Configuration.FormatToString((Me.m_entity.FinalEquipmentCost / Me.m_entity.FinalBidPrice) * 100, DigitConfig.Price)
        Me.txtBidDirectCostPercent.Text = Configuration.FormatToString((Me.m_entity.FinalDirectCost / Me.m_entity.FinalBidPrice) * 100, DigitConfig.Price)
        Me.txtBidProfitPercent.Text = Configuration.FormatToString((Me.m_entity.FinalProfit / Me.m_entity.FinalBidPrice) * 100, DigitConfig.Price)
        Me.txtBidOverheadPercent.Text = Configuration.FormatToString((Me.m_entity.FinalOverhead / Me.m_entity.FinalBidPrice) * 100, DigitConfig.Price)
        Me.txtBidPercent.Text = Configuration.FormatToString((Me.m_entity.FinalBidPrice / Me.m_entity.FinalBidPrice) * 100, DigitConfig.Price)
      Else
        Me.txtBidMatPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtBidLaborPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtBidEquipPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtBidDirectCostPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtBidProfitPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtBidOverheadPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
        Me.txtBidPercent.Text = Configuration.FormatToString(0, DigitConfig.Price)
      End If
    End Sub
    Private m_values As ArrayList
    Private m_valueTexts As ArrayList
    Private Sub DrawGraph()
      Me.PieChart1.Visible = True
      m_values = New ArrayList
      m_valueTexts = New ArrayList
      If Me.m_entity.FinalMaterialCost > 0 Then
        m_values.Add(Me.m_entity.FinalMaterialCost)
        m_valueTexts.Add(TextHelper.StringHelper.GetRidOfAtEnd(Me.lblMat.Text, ":"))
      End If
      If Me.m_entity.FinalLaborCost > 0 Then
        m_values.Add(Me.m_entity.FinalLaborCost)
        m_valueTexts.Add(TextHelper.StringHelper.GetRidOfAtEnd(Me.lblLabor.Text, ":"))
      End If
      If Me.m_entity.FinalEquipmentCost > 0 Then
        m_values.Add(Me.m_entity.FinalEquipmentCost)
        m_valueTexts.Add(TextHelper.StringHelper.GetRidOfAtEnd(Me.lblEquip.Text, ":"))
      End If
      If Me.m_entity.FinalOverhead > 0 Then
        m_values.Add(Me.m_entity.FinalOverhead)
        m_valueTexts.Add(TextHelper.StringHelper.GetRidOfAtEnd(Me.lblTotalOverhead.Text, ":"))
      End If
      If Me.m_entity.FinalProfit > 0 Then
        m_values.Add(Me.m_entity.FinalProfit)
        m_valueTexts.Add(TextHelper.StringHelper.GetRidOfAtEnd(Me.lblProfit.Text, ":"))
      End If
      If m_values.Count = 0 Then
        ClearGraph()
        Return
      End If
      SetValues()
      SetPieDisplacements()
      SetColors()
      SetTexts()
      SetToolTips()
      PieChart1.LeftMargin = 10
      PieChart1.RightMargin = 10
      PieChart1.TopMargin = 10
      PieChart1.BottomMargin = 10
      PieChart1.FitChart = False
      PieChart1.SliceRelativeHeight = 0.25
      PieChart1.InitialAngle = -30
      PieChart1.EdgeLineWidth = 1
      PieChart1.EdgeColorType = System.Drawing.PieChart.EdgeColorType.DarkerThanSurface
    End Sub
    Private Sub SetValues()
      Dim values(m_values.Count - 1) As Decimal
      m_values.CopyTo(values)
      Me.PieChart1.Values = values
    End Sub
    Private Sub SetPieDisplacements()
      Dim displaces(m_values.Count - 1) As Single
      For i As Integer = 0 To m_values.Count - 1
        displaces(i) = 0.05
      Next
      Me.PieChart1.SliceRelativeDisplacements = displaces
    End Sub
    Private Sub SetColors()
      Dim colors As New ArrayList
      If m_values.Count >= 1 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.DeepSkyBlue))
      End If
      If m_values.Count >= 2 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.Firebrick))
      End If
      If m_values.Count >= 3 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.Yellow))
      End If
      If m_values.Count >= 4 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.Blue))
      End If
      If m_values.Count >= 5 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.LimeGreen))
      End If
      Me.PieChart1.Colors = CType(colors.ToArray(GetType(Color)), Color())
    End Sub
    Private Sub SetTexts()
      Dim texts(m_values.Count - 1) As String
      For i As Integer = 0 To m_valueTexts.Count - 1
        texts(i) = m_valueTexts(i).ToString
      Next
      Me.PieChart1.Texts = texts
    End Sub
    Private Sub SetToolTips()
      Dim texts(m_values.Count - 1) As String
      For i As Integer = 0 To m_values.Count - 1
        texts(i) = m_valueTexts(i).ToString & ":" & Configuration.FormatToString(CDec(m_values(i)), DigitConfig.Price)
      Next
      Me.PieChart1.ToolTips = texts
    End Sub
    Private txtvatTextChanged As Boolean = False
    Public Sub NumberTextBoxChange(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtvat"
          If txtvatTextChanged Then
            Dim txt As String = txtVat.Text
            txt = txt.Replace(",", "")
            If txt.Length = 0 Then
              Me.m_entity.TaxAmount = 0
            Else
              Try
                Me.m_entity.TaxAmount = CDec(TextHelper.TextParser.Evaluate(txt))
              Catch ex As Exception
                Me.m_entity.TaxAmount = 0
              End Try
            End If
            txtVat.Text = Configuration.FormatToString(Me.m_entity.TaxAmount, DigitConfig.UnitPrice)
            txtvatTextChanged = False
          End If
      End Select
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtvat"
          txtvatTextChanged = True
          dirtyFlag = True
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Public Sub SetStatus()

    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          If Not Me.m_entity Is Nothing Then
            Me.m_entity.Dispose()
            Me.m_entity = Nothing
          End If
          Me.m_entity = CType(Value, BOQ)
        End If
        'Hack:
        If Not m_entity Is Nothing Then
          Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        End If
        If Me.WorkbenchWindow.ActiveViewContent Is Me Then
          UpdateEntityProperties()
        End If
      End Set
    End Property

    Public Overrides Sub Initialize()
      'PopulateRequestor()
      'PopulateCostCenter()
    End Sub
    Public Overrides Sub InitProgress()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim totalWork As Integer = Me.m_entity.WBSCollection.Count + Me.m_entity.ItemCollection.Count
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.BeginTask("${res:MainWindow.StatusBar.LoadingEntity}", totalWork)
    End Sub
    Public Sub WorkDone(ByVal i As Integer)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Worked(i)
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub chkHasVat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHasVat.CheckedChanged
      If Not chkHasVat.Checked Then
        Me.m_entity.TaxAmount = 0
        Me.txtVat.ReadOnly = True
      Else
        Me.m_entity.TaxAmount = CDec(Configuration.GetConfig("CompanyTaxRate")) * Me.m_entity.FinalBidPrice / 100
        Me.txtVat.ReadOnly = False
      End If
      Me.UpdateEntityProperties()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnZoomChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomChart.Click
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim graphDialog As New Longkong.Pojjaman.Gui.Dialogs.GraphDialog(Me.grbSum.Text)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(graphDialog)

      Dim values(m_values.Count - 1) As Decimal
      m_values.CopyTo(values)
      graphDialog.SetValues(values)

      graphDialog.SetPieDisplacements(New Single() {0.05, 0.05, 0.05, 0.05, 0.05, 0.05, 0.05})

      Dim colors As New ArrayList
      If m_values.Count >= 1 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.DeepSkyBlue))
      End If
      If m_values.Count >= 2 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.Firebrick))
      End If
      If m_values.Count >= 3 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.Yellow))
      End If
      If m_values.Count >= 4 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.Blue))
      End If
      If m_values.Count >= 5 Then
        colors.Add(Color.FromArgb(122, System.Drawing.Color.LimeGreen))
      End If
      graphDialog.SetColors(colors)

      Dim texts(m_values.Count - 1) As String
      For i As Integer = 0 To m_valueTexts.Count - 1
        texts(i) = m_valueTexts(i).ToString
      Next
      graphDialog.SetTexts(texts)

      Dim tips(m_values.Count - 1) As String
      For i As Integer = 0 To m_values.Count - 1
        tips(i) = m_valueTexts(i).ToString & ":" & Configuration.FormatToString(CDec(m_values(i)), DigitConfig.Price)
      Next
      graphDialog.SetToolTips(tips)
      graphDialog.DrawGraph()

      myDialog.ShowDialog()
    End Sub
#End Region

#Region "IValidatable"

#End Region

#Region "Event of Button controls"

#End Region

#Region "IClipboardHandler Overrides"

#End Region

#Region "IPrintable"

#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

#Region "Items"
    Private Sub RefreshItems()
      InitProgress()
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      Me.m_tableInitialized = False
      Unwire()
      Me.m_entity.PopulateFinalItemListing(m_treeManager, AddressOf WorkDone, False) ',chkHasVat.Checked)
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Done()
      Wire()
      Me.m_tableInitialized = True
      Me.tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.tgItem.RefreshHeights()
    End Sub
#End Region

    Private Sub ibtnZoomGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomGrid.Click
      If Me.lblItem.Location.Y <> 8 Then
        Me.lblItem.Location = New Point(Me.lblItem.Location.X, 8)
        Me.ibtnZoomGrid.Location = New Point(Me.ibtnZoomGrid.Location.X, Me.ibtnZoomGrid.Location.Y - 240)
        Me.tgItem.Location = New Point(Me.tgItem.Location.X, Me.tgItem.Location.Y - 240)
        Me.tgItem.Size = New Size(Me.tgItem.Size.Width, Me.tgItem.Size.Height + 240)
        Me.grbSummarize.Location = New Point(Me.grbSummarize.Location.X, Me.grbSummarize.Location.Y - 240)
        Me.chkHasVat.Location = New Point(Me.chkHasVat.Location.X, Me.chkHasVat.Location.Y - 240)
        Me.lblBOQCode.Visible = False
        Me.txtBOQCode.Visible = False
        Me.lblProject.Visible = False
        Me.txtProjectCode.Visible = False
        Me.txtProjectName.Visible = False
      Else
        Me.lblItem.Location = New Point(Me.lblItem.Location.X, 248)
        Me.ibtnZoomGrid.Location = New Point(Me.ibtnZoomGrid.Location.X, Me.ibtnZoomGrid.Location.Y + 240)
        Me.tgItem.Location = New Point(Me.tgItem.Location.X, Me.tgItem.Location.Y + 240)
        Me.tgItem.Size = New Size(Me.tgItem.Size.Width, Me.tgItem.Size.Height - 240)
        Me.grbSummarize.Location = New Point(Me.grbSummarize.Location.X, Me.grbSummarize.Location.Y + 240)
        Me.chkHasVat.Location = New Point(Me.chkHasVat.Location.X, Me.chkHasVat.Location.Y + 240)
        Me.lblBOQCode.Visible = True
        Me.txtBOQCode.Visible = True
        Me.lblProject.Visible = True
        Me.txtProjectCode.Visible = True
        Me.txtProjectName.Visible = True
      End If
    End Sub

    Private Sub ibtnSaveAsExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnSaveAsExcel.Click
      Try
        Dim Excel As Object = CreateObject("Excel.Application")
        If Excel Is Nothing Then
          MessageBox.Show("It appears that Excel is not installed on this machine. This operation requires MS Excel to be installed on this machine.")
          Return
        End If
        Dim locale As String = "en-US"
        Dim obj As Object = Configuration.GetConfig("ExcelLocale")
        If IsDBNull(obj) AndAlso obj <> Nothing Then
          locale = obj.ToString()
        End If
        Dim oldCI As System.Globalization.CultureInfo = _
        System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = _
            New System.Globalization.CultureInfo(locale)

        Dim ext As String = ".xlsx"
        If CInt(Excel.Version) < 12 Then
          ext = ".xls"
        End If

        Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        Dim thePath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & "BOQ" & ext
        thePath = Microsoft.VisualBasic.InputBox("เลือก path", "เลือก path", thePath)
        If thePath.Length = 0 Then
          thePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & Path.DirectorySeparatorChar & "BOQ" & ext
        End If

        With Excel
          .SheetsInNewWorkbook = 1
          Dim oDoc As Object = .Workbooks.Add()
          .Worksheets(1).Select()

          Dim i As Integer = 1
          For Each col As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
            .cells(1, i).value = col.HeaderText.Replace("@", "UnitPrice")
            .cells(1, i).EntireRow.Font.Bold = True
            i += 1
          Next
          i = 2
          For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
            Dim j As Integer = 1
            For Each col As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              If Not row.IsNull(col.MappingName) Then
                If TypeOf col Is DataGridComboColumn Then
                  .Cells(i, j).Value = New BOQItemType(row(col.MappingName)).Description
                Else
                  .Cells(i, j).Value = row(col.MappingName).ToString()
                End If
              End If
              j += 1
            Next
            i += 1
          Next
          .ActiveCell.Worksheet.SaveAs(thePath)

          oDoc.Close()
          .Quit()
          oDoc = Nothing
          Excel = Nothing
        End With


        MessageBox.Show("Data's are exported to Excel Succesfully in '" & thePath & "'")
        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

      '' The excel is created and opened for insert value. We most close this excel using this system
      'Dim pro() As Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
      'For Each i As Process In pro
      '  i.Kill()
      'Next

    End Sub

#Region "Sumarize"
    Private m_level As Integer
    Private Sub ibtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomOut.Click
      If m_level > 0 Then
        m_level -= 1
        Me.m_entity.WBSCollection.Sumarize(m_level)
        RefreshItems()
        'Me.m_treeManager.Treetable.Summarize(m_level)
        Me.lblLevel.Text = m_level.ToString()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub ibtnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomIn.Click
      If m_level < Me.m_entity.WBSCollection.GetMaxLevel + 1 Then
        m_level += 1
        Me.m_entity.WBSCollection.Sumarize(m_level)
        RefreshItems()
        'Me.m_treeManager.Treetable.Summarize(m_level)
        Me.lblLevel.Text = m_level.ToString()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
#End Region

    Private Sub grbSumBid_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbSumBid.Enter

    End Sub
  End Class
End Namespace