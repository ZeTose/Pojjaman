Imports System.Data.SqlClient
Imports System.Configuration
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.TextHelper

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class BOQItemWBSSelectionView
    Inherits AbstractEntityPanelViewContent
    Implements ISimpleListPanel, IValidatable

#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents imlTree As System.Windows.Forms.ImageList
    Friend WithEvents grbUseItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbWBS As System.Windows.Forms.ComboBox
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblWBS As System.Windows.Forms.Label
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents ibtnShowBOQDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBoqCode As System.Windows.Forms.TextBox
    Friend WithEvents lblBoq As System.Windows.Forms.Label
    Friend WithEvents tvGroup As Longkong.Pojjaman.Gui.Components.GroupTreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BOQItemWBSSelectionView))
      Me.imlTree = New System.Windows.Forms.ImageList(Me.components)
      Me.grbUseItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnShowBOQDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.txtBoqCode = New System.Windows.Forms.TextBox
      Me.lblBoq = New System.Windows.Forms.Label
      Me.cmbWBS = New System.Windows.Forms.ComboBox
      Me.txtFrom = New System.Windows.Forms.TextBox
      Me.btnSearch = New System.Windows.Forms.Button
      Me.lblFrom = New System.Windows.Forms.Label
      Me.txtTo = New System.Windows.Forms.TextBox
      Me.lblTo = New System.Windows.Forms.Label
      Me.lblBaht = New System.Windows.Forms.Label
      Me.lblName = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.lblWBS = New System.Windows.Forms.Label
      Me.tvGroup = New Longkong.Pojjaman.Gui.Components.GroupTreeView
      Me.Label1 = New System.Windows.Forms.Label
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblItem = New System.Windows.Forms.Label
      Me.btnSelectAll = New System.Windows.Forms.Button
      Me.grbUseItem.SuspendLayout()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imlTree
      '
      Me.imlTree.ImageSize = New System.Drawing.Size(16, 16)
      Me.imlTree.TransparentColor = System.Drawing.Color.Transparent
      '
      'grbUseItem
      '
      Me.grbUseItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbUseItem.Controls.Add(Me.ibtnShowBOQDialog)
      Me.grbUseItem.Controls.Add(Me.txtBoqCode)
      Me.grbUseItem.Controls.Add(Me.lblBoq)
      Me.grbUseItem.Controls.Add(Me.cmbWBS)
      Me.grbUseItem.Controls.Add(Me.txtFrom)
      Me.grbUseItem.Controls.Add(Me.btnSearch)
      Me.grbUseItem.Controls.Add(Me.lblFrom)
      Me.grbUseItem.Controls.Add(Me.txtTo)
      Me.grbUseItem.Controls.Add(Me.lblTo)
      Me.grbUseItem.Controls.Add(Me.lblBaht)
      Me.grbUseItem.Controls.Add(Me.lblName)
      Me.grbUseItem.Controls.Add(Me.txtName)
      Me.grbUseItem.Controls.Add(Me.lblWBS)
      Me.grbUseItem.Controls.Add(Me.tvGroup)
      Me.grbUseItem.Controls.Add(Me.Label1)
      Me.grbUseItem.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbUseItem.Location = New System.Drawing.Point(16, 8)
      Me.grbUseItem.Name = "grbUseItem"
      Me.grbUseItem.Size = New System.Drawing.Size(760, 144)
      Me.grbUseItem.TabIndex = 21
      Me.grbUseItem.TabStop = False
      Me.grbUseItem.Text = "รายละเอียด"
      '
      'ibtnShowBOQDialog
      '
      Me.ibtnShowBOQDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowBOQDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowBOQDialog.Image = CType(resources.GetObject("ibtnShowBOQDialog.Image"), System.Drawing.Image)
      Me.ibtnShowBOQDialog.Location = New System.Drawing.Point(232, 16)
      Me.ibtnShowBOQDialog.Name = "ibtnShowBOQDialog"
      Me.ibtnShowBOQDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowBOQDialog.TabIndex = 14
      Me.ibtnShowBOQDialog.TabStop = False
      Me.ibtnShowBOQDialog.ThemedImage = CType(resources.GetObject("ibtnShowBOQDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtBoqCode
      '
      Me.txtBoqCode.Location = New System.Drawing.Point(80, 16)
      Me.txtBoqCode.Name = "txtBoqCode"
      Me.txtBoqCode.ReadOnly = True
      Me.txtBoqCode.Size = New System.Drawing.Size(152, 20)
      Me.txtBoqCode.TabIndex = 11
      Me.txtBoqCode.Text = ""
      '
      'lblBoq
      '
      Me.lblBoq.BackColor = System.Drawing.Color.Transparent
      Me.lblBoq.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBoq.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblBoq.Location = New System.Drawing.Point(8, 16)
      Me.lblBoq.Name = "lblBoq"
      Me.lblBoq.Size = New System.Drawing.Size(72, 18)
      Me.lblBoq.TabIndex = 12
      Me.lblBoq.Text = "ผู้ประเมิน:"
      Me.lblBoq.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbWBS
      '
      Me.cmbWBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbWBS.Enabled = False
      Me.cmbWBS.Location = New System.Drawing.Point(80, 88)
      Me.cmbWBS.Name = "cmbWBS"
      Me.cmbWBS.Size = New System.Drawing.Size(208, 21)
      Me.cmbWBS.TabIndex = 3
      '
      'txtFrom
      '
      Me.txtFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtFrom.Location = New System.Drawing.Point(80, 40)
      Me.txtFrom.Name = "txtFrom"
      Me.txtFrom.Size = New System.Drawing.Size(80, 22)
      Me.txtFrom.TabIndex = 0
      Me.txtFrom.Text = ""
      '
      'btnSearch
      '
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(232, 112)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(56, 23)
      Me.btnSearch.TabIndex = 9
      Me.btnSearch.Text = "ค้นหา"
      '
      'lblFrom
      '
      Me.lblFrom.BackColor = System.Drawing.Color.Transparent
      Me.lblFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFrom.Location = New System.Drawing.Point(8, 40)
      Me.lblFrom.Name = "lblFrom"
      Me.lblFrom.Size = New System.Drawing.Size(64, 20)
      Me.lblFrom.TabIndex = 4
      Me.lblFrom.Text = "ราคาตั้งแต่:"
      Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtTo
      '
      Me.txtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtTo.Location = New System.Drawing.Point(184, 40)
      Me.txtTo.Name = "txtTo"
      Me.txtTo.Size = New System.Drawing.Size(80, 22)
      Me.txtTo.TabIndex = 1
      Me.txtTo.Text = ""
      '
      'lblTo
      '
      Me.lblTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTo.Location = New System.Drawing.Point(163, 40)
      Me.lblTo.Name = "lblTo"
      Me.lblTo.Size = New System.Drawing.Size(16, 20)
      Me.lblTo.TabIndex = 7
      Me.lblTo.Text = "ถึง"
      Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(267, 40)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(32, 20)
      Me.lblBaht.TabIndex = 8
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.Location = New System.Drawing.Point(16, 64)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(56, 20)
      Me.lblName.TabIndex = 5
      Me.lblName.Text = "มีคำว่า:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.txtName.Location = New System.Drawing.Point(80, 64)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(208, 22)
      Me.txtName.TabIndex = 2
      Me.txtName.Text = ""
      '
      'lblWBS
      '
      Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWBS.Location = New System.Drawing.Point(16, 88)
      Me.lblWBS.Name = "lblWBS"
      Me.lblWBS.Size = New System.Drawing.Size(56, 20)
      Me.lblWBS.TabIndex = 6
      Me.lblWBS.Text = "WBS:"
      Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tvGroup
      '
      Me.tvGroup.AllowDrop = True
      Me.tvGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tvGroup.FullRowSelect = True
      Me.tvGroup.HideSelection = False
      Me.tvGroup.ImageList = Me.imlTree
      Me.tvGroup.Location = New System.Drawing.Point(312, 15)
      Me.tvGroup.Name = "tvGroup"
      Me.tvGroup.Size = New System.Drawing.Size(440, 121)
      Me.tvGroup.TabIndex = 15
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.Location = New System.Drawing.Point(272, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(32, 20)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "WBS:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.tgItem.Location = New System.Drawing.Point(16, 184)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 336)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 23
      Me.tgItem.TreeManager = Nothing
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(32, 160)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(84, 19)
      Me.lblItem.TabIndex = 24
      Me.lblItem.Text = "รายการBOQ"
      '
      'btnSelectAll
      '
      Me.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSelectAll.Location = New System.Drawing.Point(120, 156)
      Me.btnSelectAll.Name = "btnSelectAll"
      Me.btnSelectAll.Size = New System.Drawing.Size(128, 23)
      Me.btnSelectAll.TabIndex = 20
      Me.btnSelectAll.Text = "เลือก/ไม่เลือกทั้งหมด"
      '
      'BOQItemWBSSelectionView
      '
      Me.Controls.Add(Me.grbUseItem)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.lblItem)
      Me.Controls.Add(Me.btnSelectAll)
      Me.Name = "BOQItemWBSSelectionView"
      Me.Size = New System.Drawing.Size(792, 528)
      Me.grbUseItem.ResumeLayout(False)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As BOQ


    Private m_basketItems As BasketItemCollection
    Private m_proposedBasketItems As BasketItemCollection

    Private m_otherFilters As Filter()

    Public CanDrag As Boolean = True
    Public CanDragToParent As Boolean = False
    Private m_treeManager As TreeManager
    Private m_tableInitialized As Boolean
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal handler As Object, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()
      Dim mode As Selection = Selection.MultiSelect
      If TypeOf handler Is NamedEntityOperationDelegate Then
        mode = Selection.SingleSelect
      End If
      If TypeOf entity Is BOQ Then
        Construct(CType(entity, BOQ), mode, basket, filters, entities)
      End If
    End Sub
    Private Sub Construct(ByVal entity As BOQ, ByVal mode As Selection, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      InitializeComponent()
      m_entity = entity
      Me.SetLabelText()
      Me.TitleName = Me.Text
      Me.PanelName = Me.Name


      Dim dt As TreeTable = BOQ.GetSchemaTable()
      m_treeManager = New TreeManager(dt, tgItem)
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      m_otherFilters = filters


      Search(Nothing, Nothing)

      m_basketItems = New BasketItemCollection
      m_proposedBasketItems = New BasketItemCollection

      Me.dlg = basket
      EntityRefresh(entities)
    End Sub
    Private Sub EntityRefresh(ByVal entities As ArrayList)
      If entities Is Nothing Then
        Return
      End If
      For Each entity As ISimpleEntity In entities
        If TypeOf entity Is CostCenter Then
          Dim cc As CostCenter = CType(entity, CostCenter)
          'If cc.Boq Is Nothing OrElse cc.Boq.Id <> cc.BoqId Then          '  cc.Boq = New BOQ(cc.BoqId)
          'End If
          cc.Boq = New BOQ(cc.BoqId)
          If cc.Originated Then
            If cc.Boq.Originated Then
              Me.SetBoq(cc.Boq)
              Me.txtBoqCode.Enabled = False
              Me.ibtnShowBOQDialog.Enabled = False
            End If
          End If
        End If
      Next
    End Sub
#End Region

#Region "Style"
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""
      AddHandler csSelected.Click, AddressOf RowIcon_Click

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

      dst.GridColumnStyles.Add(csSelected)
      'dst.GridColumnStyles.Add(csLineNumber)
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
    Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
      Dim myTable As TreeTable = Me.m_treeManager.Treetable
      '******************************************************************************
      Dim clickedRow As TreeRow = CType(myTable.Rows(e.Row), TreeRow)
      If CBool(clickedRow("Selected")) Then
        TreeRow.TraverseRow(clickedRow, AddressOf CheckRow)
      Else
        TreeRow.TraverseRow(clickedRow, AddressOf UnCheckRow)
      End If
      '***************ถ้าไม่ AccepChanges จะเพี้ยน*************
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.tgItem.RefreshHeights()
      '******************************************************************************
    End Sub
    Private Sub CheckRow(ByVal tr As TreeRow)
      tr("Selected") = True
    End Sub
    Private Sub UnCheckRow(ByVal tr As TreeRow)
      tr("Selected") = False
    End Sub
#End Region

#Region "Properties"
    Public Enum Selection
      None
      MultiSelect
      SingleSelect
    End Enum
#End Region

#Region "Methods"
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.Text
      ElseIf Not Me.m_entity Is Nothing Then
        Me.TitleName = Me.m_entity.TabPageText
      End If
    End Sub
    Private AllSelected As Boolean = False
    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
      If Me.m_treeManager.Treetable.Childs.Count = 0 Then
        Return
      End If
      Dim row As TreeRow = Me.m_treeManager.Treetable.Childs(0)
      If AllSelected Then
        row("Selected") = False
        TreeRow.TraverseRow(row, AddressOf UnCheckRow)
      Else
        row("Selected") = True
        TreeRow.TraverseRow(row, AddressOf CheckRow)
      End If
      AllSelected = Not AllSelected
      '***************ถ้าไม่ AccepChanges จะเพี้ยน*************
      Me.m_treeManager.Treetable.AcceptChanges()
      '******************************************************************************
    End Sub
    Private Sub Search(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
      If Me.m_entity Is Nothing OrElse Not Me.m_entity.Originated Then
        'Todo: Show some error messasges
        Return
      End If
      UpdateTable()
    End Sub
    Private Sub UpdateTable()
      Me.m_tableInitialized = False
      InitProgress()
      Me.m_entity.PopulateItemListing(m_treeManager, GetFilterArray, AddressOf WorkDone)
      Me.tgItem.RefreshHeights()
      EndProgress()
      Me.m_tableInitialized = True
    End Sub
    Public Function GetFilterArray() As Filter()
      Dim ValueFrom As Object = DBNull.Value
      Dim ValueTo As Object = DBNull.Value
      Dim ContainName As Object = DBNull.Value
      Dim UnderWBS As Object = DBNull.Value

      If Me.txtFrom.TextLength = 0 Then
        ValueFrom = DBNull.Value
      Else
        Try
          ValueFrom = CDec(TextParser.Evaluate(Me.txtFrom.Text))
        Catch ex As Exception
          ValueFrom = DBNull.Value
        End Try
      End If

      If Me.txtTo.TextLength = 0 Then
        ValueTo = DBNull.Value
      Else
        Try
          ValueTo = CDec(TextParser.Evaluate(Me.txtTo.Text))
        Catch ex As Exception
          ValueTo = DBNull.Value
        End Try
      End If

      If Me.txtName.TextLength = 0 Then
        ContainName = DBNull.Value
      Else
        ContainName = Me.txtName.Text
      End If

      If Me.cmbWBS.SelectedItem Is Nothing Then
        UnderWBS = DBNull.Value
      Else
        If TypeOf Me.cmbWBS.SelectedItem Is WBS Then
          UnderWBS = Me.cmbWBS.SelectedItem
        End If
      End If

      If Me.tvGroup.SelectedNode Is Nothing Then
        UnderWBS = DBNull.Value
      Else
        If TypeOf Me.tvGroup.SelectedNode.Tag Is WBS Then
          UnderWBS = Me.tvGroup.SelectedNode.Tag
        End If
      End If

      Dim arr(3) As Filter
      arr(0) = New Filter("ValueFrom", ValueFrom)
      arr(1) = New Filter("ValueTo", ValueTo)
      arr(2) = New Filter("ContainName", ContainName)
      arr(3) = New Filter("UnderWBS", UnderWBS)
      Return arr
    End Function
    Public Sub InitProgress()
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
    Public Sub EndProgress()
      Dim myStatusBarService As IStatusBarService = CType(ServiceManager.Services.GetService(GetType(IStatusBarService)), IStatusBarService)
      myStatusBarService.ProgressMonitor.Done()
    End Sub
#End Region

#Region "Events"
    Private Sub RefreshEditableStatus()
      WorkbenchSingleton.Workbench.RedrawAllComponents()
    End Sub
    Public Sub OnEntityPropertyChanged(ByVal sender As Object, ByVal e As EventArgs)
      RaiseEvent EntityPropertyChanged(sender, e)
    End Sub
#End Region

#Region "ISimpleListPanel"
    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleListPanel.EntityPropertyChanged
    Public Sub CheckFormEnable() Implements ISimpleListPanel.CheckFormEnable

    End Sub

    Public Sub ClearDetail() Implements ISimpleListPanel.ClearDetail

    End Sub

    Public Sub UpdateEntityProperties() Implements ISimpleListPanel.UpdateEntityProperties

    End Sub
    Public Property Entity() As ISimpleEntity Implements ISimpleListPanel.Entity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = CType(Value, BOQ)
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimpleListPanel.Icon
      Get
        Return Me.m_entity.ListPanelIcon
      End Get
    End Property
    Public ReadOnly Property Title() As String Implements ISimpleListPanel.Title
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
    Private Sub SetLabelText() Implements ISimpleListPanel.SetLabelText
      If Not m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
      Me.grbUseItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.grbUseItem}")
      Me.lblFrom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblFrom}")
      Me.lblTo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblTo}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblName}")
      Me.lblWBS.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblWBS}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.lblItem}")
      Me.btnSelectAll.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MarkupDistribution.btnSelectAll}")
      Me.lblBoq.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BOQItemSelectionView.lblBoq}")
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
    End Sub
    Public Sub ShowInPad() Implements ISimpleListPanel.ShowInPad
      'Dim myListPad As IPadContent = WorkbenchSingleton.Workbench.GetPad(Me.m_entity.ClassName)
      'If Not myListPad Is Nothing Then
      '    WorkbenchSingleton.Workbench.WorkbenchLayout.ActivatePad(myListPad)
      'Else
      '    Dim pad As New PanelPad(Me, True)
      '    pad.DockAreas = New String() {"Float"}
      '    WorkbenchSingleton.Workbench.ShowPad(pad)
      'End If
    End Sub
    'Public Sub HidePad()
    'Dim myListPad As IPadContent = WorkbenchSingleton.Workbench.GetPad(Me.m_entity.ClassName)
    'If Not myListPad Is Nothing Then
    'WorkbenchSingleton.Workbench.WorkbenchLayout.HidePad(myListPad)
    'End If
    'End Sub

    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Sub OnEntitySelected(ByVal e As ISimpleEntity)
      RaiseEvent EntitySelected(e)
    End Sub
    Private m_entitySeting As Boolean
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        Return m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If CType(m_entity, Object).Equals(Value) Then
          Return
        End If
        Me.m_entity = Value
        If Not m_entity Is Nothing Then
          m_entitySeting = True
          Me.RefreshData(m_entity)
          m_entitySeting = False
          RefreshEditableStatus()
        End If
      End Set
    End Property
    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData

    End Sub
    Public Sub RefreshData(ByVal entity As ISimpleEntity)
      'If entity Is Nothing OrElse Not entity.Originated Then
      '    Return
      'End If
      'If TreeViewHelper.SearchTag(tvGroup, entity.Id) Is Nothing Then
      '    'เพิ่ง add เข้ามา
      '    Dim newNode As New TreeNode(entity.Code & " - " & entity.Name)
      '    newNode.Tag = entity.Id
      '    If entity.Parent Is Nothing OrElse entity.Parent.Id = entity.Id OrElse Not entity.Parent.Originated Then
      '        'ใต้ root
      '        Dim newPosition As Integer = TreeViewHelper.GetChildIndex(tvGroup.Nodes, newNode)
      '        If newPosition = tvGroup.Nodes.Count Then
      '            tvGroup.Nodes.Add(newNode)
      '        Else
      '            tvGroup.Nodes.Insert(newPosition, newNode)
      '        End If
      '    Else
      '        'มี parent
      '        Dim parnode As TreeNode = TreeViewHelper.SearchTag(tvGroup, entity.Parent.Id)
      '        If Not parnode Is Nothing Then
      '            Dim newPosition As Integer = TreeViewHelper.GetChildIndex(tvGroup.Nodes, newNode)
      '            If newPosition = parnode.Nodes.Count Then
      '                parnode.Nodes.Add(newNode)
      '            Else
      '                parnode.Nodes.Insert(newPosition, newNode)
      '            End If
      '        End If
      '    End If
      '    tvGroup.SelectedNode = newNode
      '    newNode.EnsureVisible()
      '    Return
      'End If
      'Dim node As TreeNode = TreeViewHelper.SearchTag(tvGroup, CInt(entity.Id))
      'If Not node Is Nothing Then
      '    node.Text = entity.Code & " - " & entity.Name
      '    Dim nodes As TreeNodeCollection
      '    If node.Parent Is Nothing Then
      '        nodes = tvGroup.Nodes
      '    Else
      '        nodes = node.Parent.Nodes
      '    End If
      '    nodes.Remove(node)
      '    Dim newPosition As Integer = TreeViewHelper.GetChildIndex(nodes, node)
      '    If newPosition = nodes.Count Then
      '        nodes.Add(node)
      '    Else
      '        nodes.Insert(newPosition, node)
      '    End If
      '    tvGroup.SelectedNode = node
      '    node.EnsureVisible()
      'End If
    End Sub
    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub
    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return "รายการ"
      End Get
    End Property
    Public Overrides Sub Deselected()
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        If Not m_entity Is Nothing Then
          AddHandler m_entity.TabPageTextChanged, AddressOf Me.ChangeTitle
        End If
      End If
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        If Not Me.WorkbenchWindow Is Nothing AndAlso Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
          If TypeOf Me.WorkbenchWindow.SubViewContents(1) Is IValidatable Then
            Return CType(Me.WorkbenchWindow.SubViewContents(1), IValidatable).FormValidator
          End If
        End If
      End Get
    End Property
#End Region

#Region "IBasketCollectable"
    Private dlg As BasketDialog
    Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
      Get
        m_basketItems.Clear()
        If Me.m_entity Is Nothing OrElse Not Me.m_entity.Originated Then
          Return m_basketItems
        End If
        Dim myTable As TreeTable = CType(tgItem.DataSource, TreeTable)
        For Each row As TreeRow In myTable.Rows
          If TypeOf row.Tag Is BoqItem Then
            If Not IsDBNull(row("Selected")) Then
              If CBool(row("Selected")) Then
                Dim item As BoqItem = CType(row.Tag, BoqItem)
                If item.ItemType.Value <> 42 OrElse Not CType(item.Entity, LCIItem).Canceled Then
                  Dim id As Integer = Me.m_entity.Id
                  Dim stockCode As String = Me.m_entity.Code
                  Dim fullClassName As String = "Longkong.Pojjaman.BusinessLogic.BOQItem"
                  Dim entityName As String = item.EntityName
                  If item.ItemType.Value = 0 OrElse item.EntityName Is Nothing OrElse item.EntityName.Length = 0 Then
                    entityName = item.Entity.Name
                  Else
                    entityName = item.EntityName & "<" & item.Entity.Name & ">"
                  End If
                  Dim lineNumber As Integer = item.LineNumber
                  Dim qty As Decimal = item.Qty
                  Dim textInBasket As String = entityName & ":" & qty.ToString
                  Dim bi As New StockBasketItem(id, stockCode, fullClassName, textInBasket, lineNumber, qty, entityName)
                  bi.Tag = item
                  m_basketItems.Add(bi)
                Else
                  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                  msgServ.ShowMessageFormatted("${res:Global.Error.LCIIsCanceled}", New String() {CType(item.Entity, LCIItem).Code})
                End If
              End If
            End If
          End If
        Next
        Return m_basketItems
      End Get
    End Property
    Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
      Get
        Return m_proposedBasketItems
      End Get
    End Property
#End Region

    Private Sub ibtnShowBOQDialog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ibtnShowBOQDialog.Click
      Dim myEntityPanelService As IEntityPanelService = _
                               CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQ, AddressOf SetBoq)
    End Sub
    Private Sub SetBoq(ByVal e As ISimpleEntity)
      If e Is Nothing Then
        Return
      End If
      Me.m_entity = CType(e, BOQ)
      Me.txtBoqCode.Text = m_entity.Code
      ListWBS()
      Dim config As Boolean = Configuration.GetConfig("BOQPopupShowWBSToo")
      If config Then
        UpdateTable()
      End If
    End Sub
    Private Sub ListWBS()
      Me.cmbWBS.Items.Clear()
      Me.cmbWBS.Items.Add(Me.StringParserService.Parse("${res:Global.Unspecified}"))
      Dim g As Graphics = Me.CreateGraphics
      Dim w As Single = 10.0!
      Dim ef1 As New SizeF(0.0!, 0.0!)
      For Each myWbs As WBS In Me.m_entity.WBSCollection
        Me.cmbWBS.Items.Add(myWbs)
        ef1 = g.MeasureString(myWbs.ToString, Me.Font)
        If (ef1.Width > w) Then
          w = ef1.Width
        End If
      Next
      Me.cmbWBS.DropDownWidth = CType(Math.Ceiling(CType(w, Double)), Integer)
      If cmbWBS.Items.Count > 0 Then
        Me.cmbWBS.SelectedIndex = 0
      End If

      Dim myWbsColl As WBSCollection = Me.m_entity.WBSCollection
      Dim myMrkColl As MarkupCollection = Me.m_entity.MarkupCollection
      If Me.txtName.TextLength = 0 Then
        myWbsColl.Populate(tvGroup)
        'myMrkColl.PopulateAll(tvGroup.Nodes(0), True)
      Else
        Dim Colls As WBSCollection() = myWbsColl.SearchCodeOrName(Me.txtName.Text)
        Colls(0).Populate(tvGroup, Colls(1))
        'myMrkColl.PopulateAll(tvGroup.Nodes(0), True)
      End If
    End Sub

    Private Sub tvGroup_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvGroup.AfterSelect
      If Not Me.tvGroup.SelectedNode Is Nothing Then
        Me.cmbWBS.SelectedItem = Me.tvGroup.SelectedNode.Tag
      End If
    End Sub

    Private Sub cmbWBS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWBS.SelectedIndexChanged
      Try
        TreeViewHelper.TraverseNode(Me.tvGroup.Nodes(0), AddressOf SearchWBS)
      Catch ex As Exception

      End Try
    End Sub
    Dim TheWBS As WBS
    Public Sub SearchWBS(ByVal n As TreeNode)
      If Not Me.cmbWBS.SelectedItem Is Nothing Then
        If Not n.Tag Is Nothing Then
          If n.Tag Is Me.cmbWBS.SelectedItem Then
            n.TreeView.SelectedNode = n
          End If
        End If
      End If
    End Sub
  End Class
End Namespace
