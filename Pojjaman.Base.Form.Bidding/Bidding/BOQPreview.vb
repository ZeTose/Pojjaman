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
Imports Longkong.AdobeForm
Imports Longkong.Core.Properties
Imports System.IO
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BOQPreview
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
    Friend WithEvents lblBOQCode As System.Windows.Forms.Label
    Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents lblProject As System.Windows.Forms.Label
    Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnZoomOut As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents numPages As System.Windows.Forms.NumericUpDown
    Friend WithEvents ibtnZoomIn As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnLevelConfig As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtPercent As System.Windows.Forms.TextBox
    Friend WithEvents chkWysiwyg As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowWbsAmount As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowItemCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowSumRow As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowListNumber As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BOQPreview))
      Me.lblBOQCode = New System.Windows.Forms.Label
      Me.txtBOQCode = New System.Windows.Forms.TextBox
      Me.txtProjectName = New System.Windows.Forms.TextBox
      Me.lblProject = New System.Windows.Forms.Label
      Me.txtProjectCode = New System.Windows.Forms.TextBox
      Me.ibtnZoomOut = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.pnlPicHolder = New System.Windows.Forms.Panel
      Me.picMap = New System.Windows.Forms.PictureBox
      Me.numPages = New System.Windows.Forms.NumericUpDown
      Me.ibtnZoomIn = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.ibtnLevelConfig = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtPercent = New System.Windows.Forms.TextBox
      Me.chkWysiwyg = New System.Windows.Forms.CheckBox
      Me.chkShowWbsAmount = New System.Windows.Forms.CheckBox
      Me.chkShowItemCode = New System.Windows.Forms.CheckBox
      Me.chkShowSumRow = New System.Windows.Forms.CheckBox
      Me.chkShowListNumber = New System.Windows.Forms.CheckBox
      Me.grbMap.SuspendLayout()
      Me.pnlPicHolder.SuspendLayout()
      CType(Me.numPages, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
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
      Me.txtProjectName.Size = New System.Drawing.Size(248, 22)
      Me.txtProjectName.TabIndex = 4
      Me.txtProjectName.TabStop = False
      Me.txtProjectName.Text = ""
      '
      'lblProject
      '
      Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProject.ForeColor = System.Drawing.Color.Black
      Me.lblProject.Location = New System.Drawing.Point(168, 8)
      Me.lblProject.Name = "lblProject"
      Me.lblProject.Size = New System.Drawing.Size(80, 18)
      Me.lblProject.TabIndex = 2
      Me.lblProject.Text = "โครงการประมูล:"
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
      'ibtnZoomOut
      '
      Me.ibtnZoomOut.Image = CType(resources.GetObject("ibtnZoomOut.Image"), System.Drawing.Image)
      Me.ibtnZoomOut.Location = New System.Drawing.Point(632, 5)
      Me.ibtnZoomOut.Name = "ibtnZoomOut"
      Me.ibtnZoomOut.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomOut.TabIndex = 14
      Me.ibtnZoomOut.TabStop = False
      Me.ibtnZoomOut.ThemedImage = CType(resources.GetObject("ibtnZoomOut.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbMap
      '
      Me.grbMap.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMap.Controls.Add(Me.pnlPicHolder)
      Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMap.Location = New System.Drawing.Point(8, 56)
      Me.grbMap.Name = "grbMap"
      Me.grbMap.Size = New System.Drawing.Size(768, 432)
      Me.grbMap.TabIndex = 12
      Me.grbMap.TabStop = False
      Me.grbMap.Text = "Preview"
      '
      'pnlPicHolder
      '
      Me.pnlPicHolder.AutoScroll = True
      Me.pnlPicHolder.Controls.Add(Me.picMap)
      Me.pnlPicHolder.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlPicHolder.Location = New System.Drawing.Point(3, 17)
      Me.pnlPicHolder.Name = "pnlPicHolder"
      Me.pnlPicHolder.Size = New System.Drawing.Size(762, 412)
      Me.pnlPicHolder.TabIndex = 0
      '
      'picMap
      '
      Me.picMap.BackColor = System.Drawing.SystemColors.Window
      Me.picMap.Location = New System.Drawing.Point(0, 0)
      Me.picMap.Name = "picMap"
      Me.picMap.Size = New System.Drawing.Size(458, 444)
      Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picMap.TabIndex = 6
      Me.picMap.TabStop = False
      '
      'numPages
      '
      Me.numPages.Location = New System.Drawing.Point(736, 7)
      Me.numPages.Name = "numPages"
      Me.numPages.Size = New System.Drawing.Size(40, 20)
      Me.numPages.TabIndex = 11
      '
      'ibtnZoomIn
      '
      Me.ibtnZoomIn.Image = CType(resources.GetObject("ibtnZoomIn.Image"), System.Drawing.Image)
      Me.ibtnZoomIn.Location = New System.Drawing.Point(656, 5)
      Me.ibtnZoomIn.Name = "ibtnZoomIn"
      Me.ibtnZoomIn.Size = New System.Drawing.Size(24, 24)
      Me.ibtnZoomIn.TabIndex = 13
      Me.ibtnZoomIn.TabStop = False
      Me.ibtnZoomIn.ThemedImage = CType(resources.GetObject("ibtnZoomIn.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(464, 0)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(8, 8)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 8
      Me.tgItem.TreeManager = Nothing
      Me.tgItem.Visible = False
      '
      'ibtnLevelConfig
      '
      Me.ibtnLevelConfig.Image = CType(resources.GetObject("ibtnLevelConfig.Image"), System.Drawing.Image)
      Me.ibtnLevelConfig.Location = New System.Drawing.Point(600, 5)
      Me.ibtnLevelConfig.Name = "ibtnLevelConfig"
      Me.ibtnLevelConfig.Size = New System.Drawing.Size(24, 24)
      Me.ibtnLevelConfig.TabIndex = 14
      Me.ibtnLevelConfig.TabStop = False
      Me.ibtnLevelConfig.ThemedImage = CType(resources.GetObject("ibtnLevelConfig.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtPercent
      '
      Me.txtPercent.Location = New System.Drawing.Point(680, 7)
      Me.txtPercent.Name = "txtPercent"
      Me.txtPercent.ReadOnly = True
      Me.txtPercent.Size = New System.Drawing.Size(48, 20)
      Me.txtPercent.TabIndex = 15
      Me.txtPercent.Text = ""
      '
      'chkWysiwyg
      '
      Me.chkWysiwyg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkWysiwyg.Location = New System.Drawing.Point(640, 32)
      Me.chkWysiwyg.Name = "chkWysiwyg"
      Me.chkWysiwyg.Size = New System.Drawing.Size(136, 24)
      Me.chkWysiwyg.TabIndex = 16
      Me.chkWysiwyg.Text = "Print As Vistual"
      '
      'chkShowWbsAmount
      '
      Me.chkShowWbsAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowWbsAmount.Location = New System.Drawing.Point(496, 32)
      Me.chkShowWbsAmount.Name = "chkShowWbsAmount"
      Me.chkShowWbsAmount.Size = New System.Drawing.Size(128, 24)
      Me.chkShowWbsAmount.TabIndex = 16
      Me.chkShowWbsAmount.Text = "Show WBS Amount"
      '
      'chkShowItemCode
      '
      Me.chkShowItemCode.Checked = True
      Me.chkShowItemCode.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkShowItemCode.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowItemCode.Location = New System.Drawing.Point(368, 32)
      Me.chkShowItemCode.Name = "chkShowItemCode"
      Me.chkShowItemCode.Size = New System.Drawing.Size(128, 24)
      Me.chkShowItemCode.TabIndex = 16
      Me.chkShowItemCode.Text = "Show Item Code"
      '
      'chkShowSumRow
      '
      Me.chkShowSumRow.Checked = True
      Me.chkShowSumRow.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkShowSumRow.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowSumRow.Location = New System.Drawing.Point(200, 32)
      Me.chkShowSumRow.Name = "chkShowSumRow"
      Me.chkShowSumRow.Size = New System.Drawing.Size(152, 24)
      Me.chkShowSumRow.TabIndex = 16
      Me.chkShowSumRow.Text = "Use Total Amount in Table"
      '
      'chkShowListNumber
      '
      Me.chkShowListNumber.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowListNumber.Location = New System.Drawing.Point(64, 32)
      Me.chkShowListNumber.Name = "chkShowListNumber"
      Me.chkShowListNumber.Size = New System.Drawing.Size(120, 24)
      Me.chkShowListNumber.TabIndex = 16
      Me.chkShowListNumber.Text = "Show List Number"
      '
      'BOQPreview
      '
      Me.Controls.Add(Me.chkWysiwyg)
      Me.Controls.Add(Me.txtPercent)
      Me.Controls.Add(Me.ibtnZoomOut)
      Me.Controls.Add(Me.grbMap)
      Me.Controls.Add(Me.numPages)
      Me.Controls.Add(Me.ibtnZoomIn)
      Me.Controls.Add(Me.lblBOQCode)
      Me.Controls.Add(Me.txtBOQCode)
      Me.Controls.Add(Me.txtProjectName)
      Me.Controls.Add(Me.lblProject)
      Me.Controls.Add(Me.txtProjectCode)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.ibtnLevelConfig)
      Me.Controls.Add(Me.chkShowWbsAmount)
      Me.Controls.Add(Me.chkShowItemCode)
      Me.Controls.Add(Me.chkShowSumRow)
      Me.Controls.Add(Me.chkShowListNumber)
      Me.Name = "BOQPreview"
      Me.Size = New System.Drawing.Size(784, 496)
      Me.grbMap.ResumeLayout(False)
      Me.pnlPicHolder.ResumeLayout(False)
      CType(Me.numPages, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As BOQ
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableInitialized As Boolean
    Private m_ppis As ArrayList
    Private m_coll As DocPrintingItemCollection
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
      Dim dt As TreeTable = m_treeManager.Treetable
      RemoveHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler
    End Sub
    Private Sub Wire()
      Dim dt As TreeTable = m_treeManager.Treetable
      AddHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler
    End Sub
    Private Sub RowExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)
      If TypeOf e.Row.Tag Is WBS Then
        CType(e.Row.Tag, WBS).State = e.Row.State
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
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
      csCode.Alignment = HorizontalAlignment.Left
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

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csUMC)
      dst.GridColumnStyles.Add(csTotalMC)
      dst.GridColumnStyles.Add(csULC)
      dst.GridColumnStyles.Add(csTotalLC)
      dst.GridColumnStyles.Add(csUEC)
      dst.GridColumnStyles.Add(csTotalEC)
      dst.GridColumnStyles.Add(csTotal)

      Return dst
    End Function
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()

    End Sub
    Public Overrides Sub ClearDetail()

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblBOQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPreview.lblBOQCode}")
      Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQPreview.lblProject}")
    End Sub
    Protected Overrides Sub EventWiring()

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

      InitProgress()
      Me.m_tableInitialized = False
      Unwire()
      Me.m_entity.PopulateFinalItemListing(m_treeManager, AddressOf WorkDone, Me.chkWysiwyg.Checked, , Me.chkShowItemCode.Checked)
      Wire()
      Me.tgItem.RefreshHeights()
      Me.m_tableInitialized = True

      Dim pd As PrintDocument = Me.PrintDocument
      If Not pd Is Nothing Then
        pd.PrintController = New PJMPreviewControl(AddressOf SetPreviewPageInfos)
				If m_entity.ClassName = "RptJVAutomatic" Then
					pd.DefaultPageSettings.Landscape = True
				End If
				pd.Print()
			End If
      numPages_ValueChanged(Nothing, Nothing)

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub SetPreviewPageInfos(ByVal ppis As PreviewPageInfo())
      m_ppis = New ArrayList
      For Each ppi As PreviewPageInfo In ppis
        m_ppis.Add(ppi)
      Next
      Me.numPages.Maximum = m_ppis.Count
      Me.numPages.Minimum = 1
      numPages.Value = 1
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower

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
        startEndRowRemoved = False
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

#Region "IValidatable"

#End Region

#Region "Event Handlers"
    Private m_originalSize As New Size(0, 0)
    Private Sub numPages_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numPages.ValueChanged
      If m_ppis Is Nothing OrElse m_ppis.Count = 0 Then
        Return
      End If
      Dim ppi As PreviewPageInfo = CType(m_ppis(CInt(Me.numPages.Value - 1)), PreviewPageInfo)
      ZoomFactor = 1
      Me.txtPercent.Text = (ZoomFactor * 100).ToString & " %"
      m_originalSize = ppi.Image.Size
      Me.picMap.Image = ppi.Image
      Me.picMap.Size = ppi.Image.Size
      picMap.Size = New Size(CInt(m_originalSize.Width * ZoomFactor * ZoomConst), CInt(m_originalSize.Height * ZoomFactor * ZoomConst))
    End Sub
    Private ZoomFactor As Double = 1
    Private ZoomConst As Double = 0.16
    Private ZoomDelta As Double = 0.1
    Private Sub ibtnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomOut.Click
      ZoomFactor -= ZoomDelta
      ZoomFactor = Math.Max(0, ZoomFactor)
      Try
        picMap.Size = New Size(CInt(m_originalSize.Width * ZoomFactor * ZoomConst), CInt(m_originalSize.Height * ZoomFactor * ZoomConst))
      Catch ex As Exception

      End Try
      Me.txtPercent.Text = (ZoomFactor * 100).ToString & " %"
    End Sub
    Private Sub ibtnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnZoomIn.Click
      ZoomFactor += ZoomDelta
      ZoomFactor = Math.Min(5, ZoomFactor)
      Try
        picMap.Size = New Size(CInt(m_originalSize.Width * ZoomFactor * ZoomConst), CInt(m_originalSize.Height * ZoomFactor * ZoomConst))
      Catch ex As Exception

      End Try
      Me.txtPercent.Text = (ZoomFactor * 100).ToString & " %"
    End Sub
    Private Sub ibtnLevelConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnLevelConfig.Click
      'Return
      Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.BOQOptionsView
      myAuxPanel.Entity = Me.m_entity
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
      If myDialog.ShowDialog() = DialogResult.Cancel Then
        'Me.WorkbenchWindow.ViewContent.IsDirty = True    'neng :ไม่งั้นจะ IsDirty เสมอเมื่อคลิก Cancel
      End If
    End Sub
#End Region

#Region "IClipboardHandler Overrides"

#End Region

#Region "IPrintable"
    Dim m_currentPage As Integer
    Dim m_pageCount As Integer
    Dim m_printingForm As DesignerForm
    Dim startEndRowRemoved As Boolean = False
    Private ReadOnly Property IsHorizontalForm() As Boolean
      Get
        If m_printingForm Is Nothing Then
          Return False
        End If
        For Each ctrl As AdobeForm.IDrawable In m_printingForm.Controls
          If TypeOf ctrl Is TableControl Then
            Dim tb As TableControl = CType(ctrl, TableControl)
            If tb.Height > tb.Width Then
              Return False
            Else
              Return True
            End If
          End If
        Next
      End Get
    End Property
    Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
      Get
        Dim thePath As String = ""
        Dim myPropertyService As Core.Properties.PropertyService = CType(ServiceManager.Services.GetService(GetType(Core.Properties.PropertyService)), Core.Properties.PropertyService)
        Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")

        Dim fileName As String = CType(Me.Entity, IPrintableEntity).GetDefaultForm
        If fileName Is Nothing OrElse fileName.Length = 0 Then
          fileName = Entity.ClassName
        End If
        thePath = FormPath & Path.DirectorySeparatorChar & fileName & ".xml"

        Dim paths As FormPaths
        Dim nameForPath As String
        nameForPath = Entity.FullClassName & ".Documents"
        Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
        paths = CType(myProperties.GetProperty(nameForPath, New FormPaths(nameForPath, Entity.ClassName, thePath)), FormPaths)
        Dim dlg As New Longkong.Pojjaman.Gui.Dialogs.SelectFormsDialog(paths)
        If dlg.ShowDialog() = DialogResult.OK Then
          thePath = dlg.KeyValuePair.Value
        Else
          Return Nothing
        End If

        If File.Exists(thePath) Then
          Dim offset As Integer = 0
          If Not Me.chkShowSumRow.Checked Then
            offset = 1
          End If
          m_printingForm = New DesignerForm(thePath)
          m_currentPage = 0

          For Each ctrl As AdobeForm.IDrawable In m_printingForm.Controls
            If TypeOf ctrl Is TableControl Then
              Dim tb As TableControl = CType(ctrl, TableControl)
              '      If IsHorizontalForm Then
              'tb.RowsPerPage = 20					 'Fix by pui
              '      Else
              '        tb.RowsPerPage = 35
              '      End If
              m_pageCount = CInt(Math.Ceiling((Me.m_treeManager.Treetable.Rows.Count - 1 - offset + Me.GetAddedRowCount(Me.m_entity.LevelConfigs)) / tb.RowsPerPage))  '----->Hack
              Exit For
            End If
          Next

          If Not startEndRowRemoved Then
            '(เอา แถวแรกออก)======================>
            If Me.m_treeManager.Treetable.Rows.Count > 0 Then
              Me.m_treeManager.Treetable.Rows.RemoveAt(0)
            End If
            '<===================================(เอา แถวแรกออก)

            '(เอา แถวสุดท้ายออก)======================>
            If Not Me.chkShowSumRow.Checked AndAlso Me.m_treeManager.Treetable.Rows.Count > 0 Then
              Me.m_treeManager.Treetable.Rows.RemoveAt(Me.m_treeManager.Treetable.Rows.Count - 1)
            End If
            '<===================================(เอา แถวสุดท้ายออก)
            startEndRowRemoved = True
          End If

          m_coll = Me.m_entity.GetDocPrintingEntries

          Dim pd As New PrintDocument
          AddHandler pd.BeginPrint, AddressOf BeginPrint_Handler
          AddHandler pd.PrintPage, AddressOf PrintPage_Handler
          m_printingForm.UpdatePrinterSettings(pd)
          Return pd
        End If

      End Get
    End Property
    Private Function Repeat(ByVal ch As String, ByVal times As Integer) As String
      Dim ret As String = ""
      For i As Integer = 0 To times - 1
        ret &= ch
      Next
      Return ret
    End Function
    Private m_lastpage As Integer = 0
    Protected Overridable Sub BeginPrint_Handler(ByVal sender As Object, ByVal pe As PrintEventArgs)
      Dim pd As PrintDocument = CType(sender, PrintDocument)
      Dim firstPage As Integer = 1
      m_lastpage = Me.m_pageCount
      If pd.PrinterSettings.PrintRange = PrintRange.SomePages Then
        firstPage = pd.PrinterSettings.FromPage
        m_lastpage = pd.PrinterSettings.ToPage
      End If
      Me.m_currentPage = firstPage - 1
    End Sub
    Protected Overridable Sub PrintPage_Handler(ByVal sender As Object, ByVal pe As PrintPageEventArgs)
      Dim g As Graphics = pe.Graphics
      Dim currWBSListNumber As String = ""
			Dim currItemNumber As Integer = 0
			Dim f As DocPrintingItem.Frequency
			Dim candraw As Boolean = True
      'Undone: Refactor please!!!!
      Me.m_currentPage += 1
      Try
        For Each ctrl As AdobeForm.IDrawable In m_printingForm.Controls
					If Not TypeOf ctrl Is TableControl Then
						'Select Page to Draw
						f = DocPrintingItem.Frequency.EveryPage
						If Me.m_currentPage = 1 Then
							f = DocPrintingItem.Frequency.FirstPage
						ElseIf Me.m_currentPage = Me.m_pageCount Then
							f = DocPrintingItem.Frequency.LastPage
						End If
						If TypeOf ctrl Is AdobeControl Then
							Dim actrl As AdobeControl = CType(ctrl, AdobeControl)
							If Me.m_pageCount = 1 Then
								candraw = True
							Else
								Dim isFirstPage As Boolean = (actrl.Name.ToLower.StartsWith("firstpage"))
								Dim isLastPage As Boolean = (actrl.Name.ToLower.StartsWith("lastpage"))
								Select Case f
									Case DocPrintingItem.Frequency.EveryPage
										candraw = True
										If isFirstPage OrElse isLastPage Then
											candraw = False
										End If
									Case DocPrintingItem.Frequency.FirstPage
										candraw = True
										If isLastPage Then
											candraw = False
										End If
									Case DocPrintingItem.Frequency.LastPage
										candraw = True
										If isFirstPage Then
											candraw = False
										End If
								End Select
							End If
						End If
						'----------------------------------
						If TypeOf ctrl Is BorderyControl Then
							CType(ctrl, BorderyControl).Caption = Me.Parse(CType(ctrl, BorderyControl).MapCaption)
							If TypeOf ctrl Is TextFieldControl Then
								CType(ctrl, TextFieldControl).Text = Me.Parse(CType(ctrl, TextFieldControl).MapText)
							End If
						End If
						If TypeOf ctrl Is ImageControl Then
							Dim imgc As ImageControl = CType(ctrl, ImageControl)
							If imgc.Path.StartsWith("=") Then
								imgc.Image = CType(GetObject(imgc.Path), Image)
							End If
						End If
						If TypeOf ctrl Is AdobeControl Then
							If candraw Then
								ctrl.Draw(pe.Graphics)
							End If
						Else
							ctrl.Draw(pe.Graphics)
						End If

					Else
						Dim tb As TableControl = CType(ctrl, TableControl)

						''tb.RowsPerPage = 13
						'If IsHorizontalForm Then
						'	tb.RowsPerPage = 20							'Fix by pui
						'	tb.RowHeight = 24
						'Else
						'	tb.RowsPerPage = 35
						'	tb.RowHeight = 23.46
						'End If
						''tb.RowHeight = tb.Height / tb.RowsPerPage
						tb.Draw(pe.Graphics)
						Dim startRow As Integer = ((m_currentPage - 1) * tb.RowsPerPage) + 1
						Dim rowSum As New Stack
						Dim y1 As Integer = tb.Location.Y
						Dim printedRows As Integer = 0
						For i As Integer = startRow To (tb.RowsPerPage + startRow - 1)
							If i > Me.m_treeManager.Treetable.Rows.Count Then
								'เกินจำนวนแล้ว
								Exit For
							End If
							Dim sumWbs As WBS
							Dim theRow As TreeRow
							If i <= Me.m_treeManager.Treetable.Rows.Count Then
								theRow = CType(Me.m_treeManager.Treetable.Rows(i - 1), TreeRow)
							End If
							Dim dataFont As Font
							dataFont = New Font(tb.Font.FontFamily.Name, tb.Font.Size, tb.Font.Style, System.Drawing.GraphicsUnit.Point, tb.Font.GdiCharSet)
							Dim penWidth As Single
							Dim penColor As Color = Color.Black
							Dim myWbs As WBS
							Dim lvfg As LevelConfig
							If TypeOf theRow.Tag Is WBS Then
								myWbs = CType(theRow.Tag, WBS)
								lvfg = CType(Me.m_entity.LevelConfigs(myWbs.Level), LevelConfig)
								If rowSum.Count > 0 AndAlso CType(rowSum.Peek, WBS).Level = CType(theRow.Tag, WBS).Level Then
									sumWbs = CType(rowSum.Pop, WBS)
								End If
								If lvfg.LevelSumPositon = LevelConfig.SumPosition.Bottom Then
									rowSum.Push(myWbs)
								End If
							End If

							Dim colOffset As Integer = 0
							Dim verticalInterval As Integer = 5
							Dim horizontalInterval As Integer = 5
							For Each col As AdobeForm.Column In tb.Columns
								colOffset = col.Width + colOffset

								Dim stf As New StringFormat
								stf.Trimming = StringTrimming.EllipsisWord
								Select Case col.Alignment
									Case HorizontalAlignment.Center
										stf.LineAlignment = StringAlignment.Center
										stf.Alignment = StringAlignment.Center
									Case HorizontalAlignment.Left
										stf.LineAlignment = StringAlignment.Center
										stf.Alignment = StringAlignment.Near
									Case HorizontalAlignment.Right
										stf.LineAlignment = StringAlignment.Center
										stf.Alignment = StringAlignment.Far
								End Select
								Dim x1 As Integer = tb.Location.X + colOffset - col.Width

								'*******************************************************************
								Dim sumData As String
								If Not sumWbs Is Nothing Then
									Select Case col.ReportField.ToLower
										Case "boqi_itemname"
											sumData = Space(sumWbs.Level * 3) & "รวม:" & sumWbs.Name
										Case "total"
											sumData = Configuration.FormatToString(sumWbs.GetTotal, DigitConfig.Price)
										Case "totalmaterialcost"
											sumData = Configuration.FormatToString(sumWbs.GetFinalMat, DigitConfig.Price)
										Case "totallaborcost"
											sumData = Configuration.FormatToString(sumWbs.GetFinalLab, DigitConfig.Price)
										Case "totalequipmentcost"
											sumData = Configuration.FormatToString(sumWbs.GetFinalEq, DigitConfig.Price)
										Case Else
											sumData = ""
									End Select
									Dim sumDrawRect As New RectangleF(x1, y1, col.Width, tb.RowHeight)
									pe.Graphics.DrawString(sumData, dataFont, New SolidBrush(tb.ForeColor), sumDrawRect, stf)
									If printedRows <> tb.RowsPerPage Then
										If TypeOf theRow.Tag Is WBS Then
											penWidth = lvfg.PenWidth
											penColor = lvfg.BorderColor
										End If
										Dim p As New Pen(Color.Black, penWidth)
										pe.Graphics.DrawLine(p, tb.Location.X, y1 + tb.RowHeight, tb.Location.X + tb.Width, y1 + tb.RowHeight)
									End If
									If tb.Columns.IndexOf(col) = tb.Columns.Count - 1 Then
										printedRows += 1
										y1 += tb.RowHeight
										sumWbs = Nothing
									End If
								End If
								'*******************************************************************
								Dim data As String
								Select Case col.ReportField.ToLower
									Case "runnumber"
										data = i.ToString
									Case "nomap"
										data = ""
									Case "code"
										If TypeOf theRow.Tag Is WBS Then
											If Me.chkShowListNumber.Checked Then
												data = myWbs.ListNumber
												currWBSListNumber = myWbs.ListNumber
												currItemNumber = 0
											Else
												data = myWbs.Code
											End If
										ElseIf TypeOf theRow.Tag Is BoqItem Then
											currItemNumber += 1
											If Me.chkShowItemCode.Checked Then
												data = CType(theRow.Tag, BoqItem).Entity.Code
											Else
												If Me.chkShowListNumber.Checked Then
													data = currWBSListNumber & "-" & currItemNumber.ToString
												Else
													data = ""
												End If
											End If
										Else
											data = theRow(col.ReportField).ToString
										End If
									Case "boqi_itemname"
										If TypeOf theRow.Tag Is WBS Then
											data = Space(theRow.Level * 3) & myWbs.Name
										ElseIf TypeOf theRow.Tag Is BoqItem Then
											If CType(theRow.Tag, BoqItem).EntityName Is Nothing OrElse CType(theRow.Tag, BoqItem).EntityName.Length = 0 Then
												data = Space(theRow.Level * 3) & CType(theRow.Tag, BoqItem).Entity.Name
											Else
												data = Space(theRow.Level * 3) & CType(theRow.Tag, BoqItem).EntityName
											End If
										ElseIf TypeOf theRow.Tag Is Markup Then
											data = Space(theRow.Level * 3) & theRow(col.ReportField).ToString
										Else
											data = Space(theRow.Level * 3) & theRow(col.ReportField).ToString
										End If
									Case "total", "totalmaterialcost", "totallaborcost", "totalequipmentcost"
										If TypeOf theRow.Tag Is WBS Then
											Select Case lvfg.LevelSumPositon
												Case LevelConfig.SumPosition.None
													If Me.chkShowWbsAmount.Checked Then
														data = theRow(col.ReportField).ToString
													Else
														data = ""
													End If
												Case LevelConfig.SumPosition.Bottom
													If Me.chkShowWbsAmount.Checked Then
														data = theRow(col.ReportField).ToString
													Else
														data = ""
													End If
												Case LevelConfig.SumPosition.Top
													data = theRow(col.ReportField).ToString
											End Select
										Else
											data = theRow(col.ReportField).ToString
										End If
									Case Else
										If Me.m_treeManager.Treetable.Columns.Contains(col.ReportField) Then
											data = theRow(col.ReportField).ToString
										End If
								End Select
								Dim drawRect As New RectangleF(x1, y1, col.Width, tb.RowHeight)
								pe.Graphics.DrawString(data, dataFont, New SolidBrush(tb.ForeColor), drawRect, stf)
								If printedRows < tb.RowsPerPage - 1 Then
									If TypeOf theRow.Tag Is WBS Then
										penWidth = lvfg.PenWidth
										penColor = lvfg.BorderColor
									End If
									Dim p As New Pen(Color.Black, penWidth)
									pe.Graphics.DrawLine(p, tb.Location.X, y1 + tb.RowHeight, tb.Location.X + tb.Width, y1 + tb.RowHeight)
								End If
							Next
							printedRows += 1
							y1 += tb.RowHeight
						Next
					End If
				Next
        If m_currentPage < m_lastpage Then 'Me.m_pageCount Then
          pe.HasMorePages = True
        Else
          pe.HasMorePages = False
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Function GetAddedRowCount(ByVal configs As ArrayList) As Integer
      Dim ret As Integer = 0
      For Each myWbs As WBS In Me.m_entity.WBSCollection
        If CType(configs(myWbs.Level), LevelConfig).LevelSumPositon = LevelConfig.SumPosition.Bottom Then
          ret += 1
        End If
      Next
      Return ret
    End Function
    Private Function GetObject(ByVal data As String) As Object
      If Not data Is Nothing Then
        If data.StartsWith("=Pic") Then
          Dim map As String = data.Substring(1, Len(data) - 1)
          Dim item As DocPrintingItem = m_coll.GetMappingItem(map)
          If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
            Return item.Value
          End If
        ElseIf data.StartsWith("=") Then
          Dim map As String = data.Substring(1, Len(data) - 1)
          Dim config As Object = Configuration.GetConfig(map)
          If Not config Is Nothing Then
            Return config
          End If
        End If
      End If
    End Function
    Private Function Parse(ByVal data As String) As String
      If Not data Is Nothing Then
        If data.ToLower = "=page" Then
          data = Me.m_currentPage.ToString
        ElseIf data.ToLower = "=pages" Then
          data = Me.m_pageCount.ToString
        ElseIf data.ToLower = "=date" Then
          data = Now.ToShortDateString
        ElseIf data.ToLower = "=time" Then
          data = Now.ToShortTimeString
        ElseIf data.StartsWith("=CText(") Then
          Dim num As String = data.Substring(7, data.Length - 8)
          Dim item As DocPrintingItem = m_coll.GetMappingItem(num)
          If Not item Is Nothing AndAlso IsNumeric(item.Value) Then
            Dim number As Decimal = CDec(item.Value)
            data = Configuration.FormatToString(number, DigitConfig.CurrencyText)
          End If

          'Fixed Value ทุกอันต้องอยู่ก่อนบรรทัดนี้:
        ElseIf data.StartsWith("=") Then
          Dim map As String = data.Substring(1, Len(data) - 1)
          Dim item As DocPrintingItem = m_coll.GetMappingItem(map)
          If Not item Is Nothing AndAlso Not item.Value Is Nothing Then
            data = item.Value.ToString
          End If
          If data.StartsWith("=") Then
            data = ""
          End If
        ElseIf data.StartsWith("Company") Then
          Dim config As Object = Configuration.GetConfig(data)
          If Not config Is Nothing Then
            data = config.ToString
          End If
        End If
      End If
      Return data
    End Function
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return "Icons.16x16.BOQPreview"
      End Get
    End Property
#End Region

    Private Sub chkWysiwyg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWysiwyg.CheckedChanged, _
      chkShowWbsAmount.CheckedChanged, _
      chkShowItemCode.CheckedChanged, _
      chkShowSumRow.CheckedChanged, _
      chkShowListNumber.CheckedChanged
      Me.UpdateEntityProperties()
    End Sub

  End Class
End Namespace