Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.IO
Imports Longkong.Core.Properties
Imports Longkong.AdobeForm
Namespace Longkong.Pojjaman.Gui.Panels

  Public Class scWBSView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

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
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents grbRefDoc As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtRefDocCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRefDoc As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtSubContractorName As System.Windows.Forms.TextBox
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tgToCC As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(scWBSView))
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.tgToCC = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.Label1 = New System.Windows.Forms.Label
      Me.grbRefDoc = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.txtRefDocCode = New System.Windows.Forms.TextBox
      Me.lblRefDoc = New System.Windows.Forms.Label
      Me.txtSubContractorName = New System.Windows.Forms.TextBox
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.lblSupplier = New System.Windows.Forms.Label
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.grbDetail.SuspendLayout()
      CType(Me.tgToCC, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbRefDoc.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnAddWBS)
      Me.grbDetail.Controls.Add(Me.ibtnDelWBS)
      Me.grbDetail.Controls.Add(Me.tgToCC)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.grbRefDoc)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbDetail.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grbDetail.Location = New System.Drawing.Point(8, 8)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(728, 512)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "จัดสรร"
      '
      'ibtnAddWBS
      '
      Me.ibtnAddWBS.Image = CType(resources.GetObject("ibtnAddWBS.Image"), System.Drawing.Image)
      Me.ibtnAddWBS.Location = New System.Drawing.Point(184, 116)
      Me.ibtnAddWBS.Name = "ibtnAddWBS"
      Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnAddWBS.TabIndex = 30
      Me.ibtnAddWBS.TabStop = False
      Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnDelWBS
      '
      Me.ibtnDelWBS.Image = CType(resources.GetObject("ibtnDelWBS.Image"), System.Drawing.Image)
      Me.ibtnDelWBS.Location = New System.Drawing.Point(208, 116)
      Me.ibtnDelWBS.Name = "ibtnDelWBS"
      Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelWBS.TabIndex = 31
      Me.ibtnDelWBS.TabStop = False
      Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
      '
      'tgToCC
      '
      Me.tgToCC.AllowNew = False
      Me.tgToCC.AllowSorting = False
      Me.tgToCC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgToCC.AutoColumnResize = True
      Me.tgToCC.CaptionVisible = False
      Me.tgToCC.Cellchanged = False
      Me.tgToCC.DataMember = ""
      Me.tgToCC.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgToCC.Location = New System.Drawing.Point(16, 144)
      Me.tgToCC.Name = "tgToCC"
      Me.tgToCC.Size = New System.Drawing.Size(696, 360)
      Me.tgToCC.SortingArrowColor = System.Drawing.Color.Red
      Me.tgToCC.TabIndex = 28
      Me.tgToCC.TreeManager = Nothing
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 119)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(168, 18)
      Me.Label1.TabIndex = 29
      Me.Label1.Text = "จัดสรรไปยัง Cost Center:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbRefDoc
      '
      Me.grbRefDoc.Controls.Add(Me.txtRefDocCode)
      Me.grbRefDoc.Controls.Add(Me.lblRefDoc)
      Me.grbRefDoc.Controls.Add(Me.txtSubContractorName)
      Me.grbRefDoc.Controls.Add(Me.txtCostCenterName)
      Me.grbRefDoc.Controls.Add(Me.lblSupplier)
      Me.grbRefDoc.Controls.Add(Me.lblCostCenter)
      Me.grbRefDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbRefDoc.Location = New System.Drawing.Point(16, 16)
      Me.grbRefDoc.Name = "grbRefDoc"
      Me.grbRefDoc.Size = New System.Drawing.Size(696, 96)
      Me.grbRefDoc.TabIndex = 0
      Me.grbRefDoc.TabStop = False
      Me.grbRefDoc.Text = "เอกสารอ้างอิง"
      '
      'txtRefDocCode
      '
      Me.txtRefDocCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtRefDocCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCode, System.Drawing.Color.Empty)
      Me.txtRefDocCode.Location = New System.Drawing.Point(134, 16)
      Me.Validator.SetMaxValue(Me.txtRefDocCode, "")
      Me.Validator.SetMinValue(Me.txtRefDocCode, "")
      Me.txtRefDocCode.Name = "txtRefDocCode"
      Me.txtRefDocCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtRefDocCode, "")
      Me.Validator.SetRequired(Me.txtRefDocCode, False)
      Me.txtRefDocCode.Size = New System.Drawing.Size(184, 21)
      Me.txtRefDocCode.TabIndex = 1
      Me.txtRefDocCode.TabStop = False
      Me.txtRefDocCode.Text = ""
      '
      'lblRefDoc
      '
      Me.lblRefDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRefDoc.Location = New System.Drawing.Point(24, 16)
      Me.lblRefDoc.Name = "lblRefDoc"
      Me.lblRefDoc.Size = New System.Drawing.Size(104, 18)
      Me.lblRefDoc.TabIndex = 0
      Me.lblRefDoc.Text = "เลขที่เอกสารอ้างอิง:"
      Me.lblRefDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSubContractorName
      '
      Me.txtSubContractorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSubContractorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.txtSubContractorName.Location = New System.Drawing.Point(134, 40)
      Me.Validator.SetMaxValue(Me.txtSubContractorName, "")
      Me.Validator.SetMinValue(Me.txtSubContractorName, "")
      Me.txtSubContractorName.Name = "txtSubContractorName"
      Me.txtSubContractorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorName, "")
      Me.Validator.SetRequired(Me.txtSubContractorName, False)
      Me.txtSubContractorName.Size = New System.Drawing.Size(368, 21)
      Me.txtSubContractorName.TabIndex = 30
      Me.txtSubContractorName.TabStop = False
      Me.txtSubContractorName.Text = ""
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(134, 64)
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(368, 21)
      Me.txtCostCenterName.TabIndex = 31
      Me.txtCostCenterName.TabStop = False
      Me.txtCostCenterName.Text = ""
      '
      'lblSupplier
      '
      Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.Location = New System.Drawing.Point(40, 40)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(88, 18)
      Me.lblSupplier.TabIndex = 28
      Me.lblSupplier.Text = "ผู้รับเหมา/ผู้ขาย:"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCostCenter
      '
      Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblCostCenter.Location = New System.Drawing.Point(40, 64)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(88, 18)
      Me.lblCostCenter.TabIndex = 29
      Me.lblCostCenter.Text = "CostCenter:"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
      '
      'scWBSView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Name = "scWBSView"
      Me.Size = New System.Drawing.Size(744, 528)
      Me.grbDetail.ResumeLayout(False)
      CType(Me.tgToCC, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbRefDoc.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As ISimpleEntity
    Private m_isInitialized As Boolean = False
    Private m_wbsTreeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable
    Private m_combocodeindex As Integer
    Private m_refDoc As IWBSAllocatable

    Public MatActualHash As Hashtable
    Public LabActualHash As Hashtable
    Public EQActualHash As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dtWBS As TreeTable = GetSchemaTable()
      Dim dstWBS As DataGridTableStyle = Me.CreateTableStyle()
      m_wbsTreeManager = New TreeManager(dtWBS, tgToCC)
      m_wbsTreeManager.SetTableStyle(dstWBS)
      m_wbsTreeManager.AllowSorting = False
      m_wbsTreeManager.AllowDelete = False

      AddHandler dtWBS.ColumnChanging, AddressOf WBSTreetable_ColumnChanging
      AddHandler dtWBS.ColumnChanged, AddressOf WBSTreetable_ColumnChanged
      AddHandler dtWBS.RowDeleted, AddressOf WBSItemDelete

      EventWiring()

      MatActualHash = New Hashtable
      LabActualHash = New Hashtable
      EQActualHash = New Hashtable
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"       'add แค่ header เท่านั้น
    Private Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("WBS")
      myDatatable.Columns.Add(New DataColumn("ItemType", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ItemAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("CCButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("WBS", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Percent", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("BudgetRemain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("QtyRemain", GetType(String)))

      Return myDatatable
    End Function
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "WBS"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csType As New TreeTextColumn
      csType.MappingName = "ItemType"
      csType.HeaderText = "ประเภท"
      csType.NullText = ""
      csType.Width = 80
      csType.ReadOnly = True
      csType.TextBox.Name = "ItemType"

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "Description"
      csDescription.HeaderText = "รายการ"
      csDescription.NullText = ""
      csDescription.Width = 190
      csDescription.ReadOnly = True
      csDescription.TextBox.Name = "Description"

      Dim csItemAmount As New TreeTextColumn
      csItemAmount.MappingName = "ItemAmount"
      csItemAmount.HeaderText = "จำนวนเงิน"
      csItemAmount.NullText = ""
      csItemAmount.Width = 100
      csItemAmount.DataAlignment = HorizontalAlignment.Right
      csItemAmount.ReadOnly = True

      csItemAmount.TextBox.Name = "Description"

      '------------------------WBS----------------------------------
      Dim csCostCenter As New TreeTextColumn
      csCostCenter.MappingName = "CostCenter"
      csCostCenter.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.CCHeaderText}")
      csCostCenter.NullText = ""
      csCostCenter.Width = 190
      csCostCenter.ReadOnly = True
      csCostCenter.TextBox.Name = "CostCenter"

      Dim csCCButton As New DataGridButtonColumn
      csCCButton.MappingName = "CCButton"
      csCCButton.HeaderText = ""
      csCCButton.NullText = ""

      Dim csWBS As New TreeTextColumn
      csWBS.MappingName = "WBS"
      csWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.WBSHeaderText}")
      csWBS.NullText = ""
      csWBS.Width = 190
      csWBS.ReadOnly = True
      csWBS.TextBox.Name = "WBS"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""
      AddHandler csButton.Click, AddressOf WBStgButtonClicked

      Dim csPercent As New TreeTextColumn
      csPercent.MappingName = "Percent"
      csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.PercentHeaderText}")
      csPercent.NullText = ""
      csPercent.DataAlignment = HorizontalAlignment.Right
      csPercent.Format = "#,###.##"
      csPercent.Width = 70
      csPercent.TextBox.Name = "Percent"

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmoluntHeaderText}")
      csAmount.NullText = ""
      csAmount.Alignment = HorizontalAlignment.Right
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.Format = "#,###.##"
      csAmount.Width = 100
      csAmount.TextBox.Name = "Amount"

      Dim csBudgetRemain As New TreeTextColumn(5, True)
      csBudgetRemain.MappingName = "BudgetRemain"
      csBudgetRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.BudgetRemainHeaderText}")
      csBudgetRemain.NullText = ""
      csBudgetRemain.Alignment = HorizontalAlignment.Right
      csBudgetRemain.DataAlignment = HorizontalAlignment.Right
      csBudgetRemain.Format = "#,###.##"
      csBudgetRemain.Width = 100
      csBudgetRemain.TextBox.Name = "BudgetRemain"
      csBudgetRemain.ReadOnly = True
      'AddHandler csBudgetRemain.CheckCellHilighted, AddressOf SetHilightValues

      Dim csQtyRemain As New TreeTextColumn(6, True)
      csQtyRemain.MappingName = "QtyRemain"
      csQtyRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QtyRemainHeaderText}")
      csQtyRemain.NullText = ""
      csQtyRemain.Alignment = HorizontalAlignment.Right
      csQtyRemain.DataAlignment = HorizontalAlignment.Right
      csQtyRemain.Format = "#,###.##"
      csQtyRemain.Width = 100
      csQtyRemain.TextBox.Name = "QtyRemain"
      csQtyRemain.ReadOnly = True
      'AddHandler csQtyRemain.CheckCellHilighted, AddressOf SetHilightValues
      '------------------------WBS----------------------------------

      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csItemAmount)
      dst.GridColumnStyles.Add(csCostCenter)
      dst.GridColumnStyles.Add(csCCButton)
      dst.GridColumnStyles.Add(csWBS)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csPercent)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBudgetRemain)
      dst.GridColumnStyles.Add(csQtyRemain)

      Return dst
    End Function
#End Region

#Region "Properties"
    Public ReadOnly Property RefDoc() As IWBSAllocatable
      Get
        Return m_refDoc
      End Get
    End Property
    Private ReadOnly Property CurrentWsbsd() As WBSDistribute
      Get
        Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is WBSDistribute Then
          Return Nothing
        End If
        Return CType(row.Tag, WBSDistribute)
      End Get
    End Property
    Private ReadOnly Property CurrentItem() As IWBSAllocatableItem
      Get
        Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is IWBSAllocatableItem Then
          Return Nothing
        End If
        Return CType(row.Tag, IWBSAllocatableItem)
      End Get
    End Property
    Private ReadOnly Property CurrentParItem() As IWBSAllocatableItem  ' WBSDistributeCollection
      Get
        Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf m_entity Is IWBSAllocatable Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is WBSDistribute Then
          Return Nothing
        End If
        Dim wbsd As WBSDistribute = CType(row.Tag, WBSDistribute)
        For Each itm As IWBSAllocatableItem In CType(m_entity, IWBSAllocatable).GetWBSAllocatableItemCollection
          If itm.WBSDistributeCollection.Contains(wbsd) Then
            Return itm 'itm.WBSDistributeCollection
          End If
          'For Each wbsitem As WBSDistribute In itm.WBSDistributeCollection
          '    If wbsd Is wbsitem Then
          '        Exit For
          '    End If
          'Next
        Next
        Return Nothing
      End Get
    End Property
    Public Sub WBStgButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 4 Then
        Me.CCButtonClicked(e)
      Else
        Me.WBSButtonClicked(e)
      End If
    End Sub
    Dim m_wbsColl As WBSCollection = Nothing
    Dim m_mrkColl As MarkupCollection = Nothing
    Public Sub CCButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.RefDoc.ToCostCenter Is Nothing Then
        Return
      End If
      'If Me.RefDoc.ToCostCenter.BoqId = 0 Then
      '  Return
      'End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New CostCenter
      Dim entities As New ArrayList
      myEntityPanelService.OpenListDialog(entity, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal myEntity As ISimpleEntity)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim doc As WBSDistribute = Me.CurrentWsbsd
      If doc Is Nothing Then
        Return
      End If

      'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
      'Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
      If TypeOf myEntity Is CostCenter Then
        Dim newCC As CostCenter = CType(myEntity, CostCenter)

        If newCC Is Nothing Then
          msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
          Return
        End If
        If newCC.BoqId = 0 Then
          msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
          Return
        End If

        CType(row.Tag, WBSDistribute).CostCenter = CType(myEntity, CostCenter)
        CType(row.Tag, WBSDistribute).WBS = New WBS
      End If
      'Dim view As Integer = 7
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      'wsdColl.Populate(dt, doc, view)
      Me.RefreshDocs()
      m_isInitialized = flag
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Public Sub WBSButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As WBSDistribute = Me.CurrentWsbsd
      If doc Is Nothing Then
        Return
      End If
      '-----------------------------------------------------------*****
      If Me.RefDoc.ToCostCenter Is Nothing Then
        Return
      End If
      'If Me.RefDoc.ToCostCenter.BoqId = 0 Then
      '  Return
      'End If
      If doc.CostCenter.BoqId = 0 Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New WBS
      Dim filters() As Filter

      Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
      Dim rowIndex As Integer = row.Index
      Dim myBOQId As Integer

      If Not doc.CostCenter Is Nothing _
        AndAlso doc.CostCenter.BoqId > 0 Then
        myBOQId = doc.CostCenter.BoqId
        'MessageBox.Show("1" & myBOQId.ToString)
      Else
        myBOQId = Me.RefDoc.ToCostCenter.BoqId
        doc.CostCenter = Me.RefDoc.ToCostCenter
        'MessageBox.Show("2 " & myBOQId.ToString)
      End If
      If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> myBOQId Then
        m_wbsColl = New WBSCollection(myBOQId)
      End If
      If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> myBOQId Then
        m_mrkColl = New MarkupCollection(myBOQId)
      End If
      'If m_wbsColl Is Nothing OrElse m_wbsColl.Boq.Id <> Me.RefDoc.ToCostCenter.BoqId Then
      '    m_wbsColl = New WBSCollection(Me.RefDoc.ToCostCenter.BoqId)
      'End If
      'If m_mrkColl Is Nothing OrElse m_mrkColl.Boq.Id <> Me.RefDoc.ToCostCenter.BoqId Then
      '    m_mrkColl = New MarkupCollection(Me.RefDoc.ToCostCenter.BoqId)
      'End If
      filters = New Filter() {New Filter("mrkColl", m_mrkColl) _
                              , New Filter("wbsColl", m_wbsColl)}
      Dim entities As New ArrayList
      entities.Add(entity)
      myEntityPanelService.OpenListDialog(entity, AddressOf SetWBS, filters, entities)
    End Sub
    Private Sub SetWBS(ByVal myEntity As ISimpleEntity)
      Dim doc As WBSDistribute = Me.CurrentWsbsd
      If doc Is Nothing Then
        Return
      End If
      'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
      'Dim wsdColl As WBSDistributeCollection = doc.wbsd
      Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
      If TypeOf myEntity Is WBS Then
        CType(row.Tag, WBSDistribute).WBS = CType(myEntity, WBS)
        CType(row.Tag, WBSDistribute).IsMarkup = False
      ElseIf TypeOf myEntity Is Markup Then
        Dim newWBS As New WBS
        Dim myMarkup As Markup = CType(myEntity, Markup)
        newWBS.Id = myMarkup.Id
        newWBS.Code = myMarkup.Code
        newWBS.Name = myMarkup.Name
        CType(row.Tag, WBSDistribute).WBS = newWBS
        CType(row.Tag, WBSDistribute).IsMarkup = True
      End If

      'Dim view As Integer = 7
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      'wsdColl.Populate(dt, doc, view)
      Me.RefreshDocs()
      m_isInitialized = flag
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    'Private ReadOnly Property CurrentItem() As PurchaseDNItem
    '    Get
    '        Dim row As TreeRow = Me.m_treeManager.SelectedRow
    '        If row Is Nothing Then
    '            Return Nothing
    '        End If
    '        If Not TypeOf row.Tag Is PurchaseDNItem Then
    '            Return Nothing
    '        End If
    '        Return CType(row.Tag, PurchaseDNItem)
    '    End Get
    'End Property
    'Private Property ComboCodeIndex() As Integer
    'Get
    '    If m_combocodeindex = -1 Then
    '        If cmbCode.Items.Count > 0 Then
    '            m_combocodeindex = 0
    '        End If
    '    End If
    '    Return m_combocodeindex
    'End Get
    'Set(ByVal Value As Integer)
    '    m_combocodeindex = Value
    'End Set
    'End Property
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()

    End Sub

    Public Overrides Sub ClearDetail()
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
    End Sub
    Public Overrides Sub SetLabelText()
      'คาดว่าจะเป็นตรงนี้
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.lblBankCharge.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblBankCharge}")
      'Me.lblWHT.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblWHT}")
      'Me.lblOtherExpense.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblOtherExpense}")
      'Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblNote}")
      'Me.txtDiscountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.txtWHTUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.txtBankChargeUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.txtOtherExpenseUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblItem}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbDetail}")
      Me.grbRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbRefDoc}")
      'Me.lblRefDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefDocDate}")
      Me.lblRefDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefDoc}")

      'Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblCode}")
      'Me.Validator.SetDisplayName(Me.cmbCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      'Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDocDate}")
      'Me.lblRefAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblRefAmount}")
      'Me.lblRefAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.grbDebit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbDebit}")
      'Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDiscountAmount}")
      'Me.lblOtherRev.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblOtherRev}")
      'Me.txtOtherRevUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblDebitAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblDebitAmount}")
      'Me.lblAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblAmount}")
      'Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblGross}")
      'Me.grbCredit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.grbCredit}")
      'Me.lblInterest.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblInterest}")
      'Me.txtInterestUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PaymentOutDetail.lblCreditAmount}")
      'Me.txtGrossUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      'Me.lblAmountUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
    End Sub
    Protected Overrides Sub EventWiring()
      'AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      'AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      'AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtDiscountAmount.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtOtherRevenue.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtInterest.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtBankCharge.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler txtOtherExpense.TextChanged, AddressOf Me.ChangeProperty
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If

      If TypeOf Me.m_entity Is IWBSAllocatable Then
        m_refDoc = CType(Me.m_entity, IWBSAllocatable)

        Me.txtRefDocCode.Text = Me.m_entity.Code
        If Not RefDoc.Supplier Is Nothing Then
          Me.txtSubContractorName.Text = RefDoc.Supplier.Code & " : " & RefDoc.Supplier.Name
        End If
        If Not RefDoc.ToCostCenter Is Nothing Then
          Me.txtCostCenterName.Text = RefDoc.ToCostCenter.Code & " : " & RefDoc.ToCostCenter.Name
        End If
      End If

      RefreshDocs()

      UpdateAmount()
      UpdateRefDoc()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Dim flag As Boolean = Me.m_isInitialized
      Dim hashWBS As New Hashtable
      Dim hashWBSItem As New Hashtable
      Dim key As String = ""
      Dim itemKey As String = ""
      Me.m_isInitialized = False
      If TypeOf m_entity Is IWBSAllocatable Then
        Dim al As IWBSAllocatable = CType(m_entity, IWBSAllocatable)
        Dim dt As TreeTable = m_wbsTreeManager.Treetable
        dt.Clear()
        For Each ali As IWBSAllocatableItem In al.GetWBSAllocatableItemCollection
          Dim newRow As TreeRow = dt.Childs.Add()
          If ali.AllocationErrorMessage.Length <> 0 Then
            newRow.FixLevel = 0
          Else
            newRow.FixLevel = 1
          End If
          newRow("ItemType") = ali.Type
          newRow("Description") = ali.Description
          If ali.ItemAmount <> 0 Then
            newRow("ItemAmount") = Configuration.FormatToString(ali.ItemAmount, DigitConfig.Price)
          End If

          newRow("CCButton") = "invisible"
          newRow("Button") = "invisible"

          newRow.Tag = ali
          If ali.AllocationErrorMessage.Length = 0 Then
            For Each wbsd As WBSDistribute In ali.WBSDistributeCollection
              Dim transferAmt As Decimal = ali.ItemAmount

              wbsd.BaseCost = transferAmt
              wbsd.TransferBaseCost = transferAmt

              Dim wbsRow As TreeRow = dt.Childs.Add()
              wbsRow.FixLevel = -1
              wbsRow("CostCenter") = wbsd.CostCenter.Code & " : " & wbsd.CostCenter.Name
              wbsRow("WBS") = wbsd.WBS.Code & " : " & wbsd.WBS.Name
              wbsRow("Percent") = Configuration.FormatToString(wbsd.Percent, DigitConfig.Price)
              wbsRow("Amount") = Configuration.FormatToString(wbsd.Amount, DigitConfig.Price)

              key = wbsd.WBS.Id.ToString & ":" & wbsd.CostCenter.Id.ToString & ":" & ali.AllocationType
              itemKey = wbsd.WBS.Id.ToString & ":" & wbsd.CostCenter.Id.ToString & ":" & ali.Description & ":" & ali.AllocationType
              'Amount -----------------------------------------------------
              If Not hashWBS.Contains(key) Then
                wbsd.RemainSummary = wbsd.BudgetRemain - (wbsd.Amount + wbsd.ChildAmount)
                hashWBS(key) = wbsd

              Else
                Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
                wbsd.RemainSummary = parWBS.RemainSummary - (wbsd.Amount + wbsd.ChildAmount)
                CType(hashWBS(key), WBSDistribute).RemainSummary = wbsd.RemainSummary

              End If
              'Qty --------------------------------------------------------
              If Not hashWBSItem.Contains(itemKey) Then
                wbsd.QtyRemainSummary = wbsd.QtyRemain - wbsd.Qty
                hashWBSItem(itemKey) = wbsd

              Else
                Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
                wbsd.QtyRemainSummary = parWBS.QtyRemainSummary - wbsd.Qty
                CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = wbsd.QtyRemainSummary

              End If

              wbsRow("BudgetRemain") = Configuration.FormatToString(wbsd.RemainSummary, DigitConfig.Price)
              wbsRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemainSummary, DigitConfig.Price)
              'wbsRow("QtyRemain") = Configuration.FormatToString(wbsd.QtyRemain, DigitConfig.Qty)

              wbsRow.Tag = wbsd
            Next
          End If

        Next
      End If
      RefreshBlankGrid()
      Me.UpdateAmount()
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateRefDoc()

    End Sub
    Private Sub UpdateAmount()
      'Dim oldFlag As Boolean = m_isInitialized
      'm_isInitialized = False
      'Me.txtDebitAmount.Text = Configuration.FormatToString(Me.m_payment.DebitAmount, DigitConfig.Price)
      'Me.txtCreditAmount.Text = Configuration.FormatToString(Me.m_payment.CreditAmount, DigitConfig.Price)
      'Me.txtTotalDebitAmount.Text = Configuration.FormatToString(Me.m_payment.SumDebitAmount, DigitConfig.Price)
      'Me.txtTotalCreditAmount.Text = Configuration.FormatToString(Me.m_payment.SumCreditAmount, DigitConfig.Price)
      'Me.txtGross.Text = Configuration.FormatToString(myGross, DigitConfig.Price)
      'Me.txtAmount.Text = Configuration.FormatToString(Me.m_payment.Amount, DigitConfig.Price)
      'm_isInitialized = oldFlag

      'ถ้ามีรายการจ่ายเงิน ให้ตรวจสอบเลขที่ PV ด้วย
      'If myGross > 0 Then
      '    Me.Validator.SetRequired(Me.cmbCode, True)
      'Else
      '    Me.Validator.SetRequired(Me.cmbCode, False)
      'End If
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal type As Integer)
      myWbs = New WBS(myWbs.Id)
      Dim o_n As OldNew
      Dim theHash As Hashtable
      Select Case type
        Case 0, 19, 42
          theHash = MatActualHash
        Case 88
          theHash = LabActualHash
        Case 89
          theHash = EQActualHash
      End Select
      If Not theHash Is Nothing Then
        If theHash.Contains(myWbs.Id) Then
          o_n = CType(theHash(myWbs.Id), OldNew)
        Else
          o_n = New OldNew
          Select Case type
            Case 0, 19, 42
              o_n.OldValue = myWbs.GetActualMat(Me, 7)
            Case 88
              o_n.OldValue = myWbs.GetActualLab(Me, 7)
            Case 89
              o_n.OldValue = myWbs.GetActualEq(Me, 7)
          End Select
          o_n.NewValue = o_n.OldValue
          theHash(myWbs.Id) = o_n
        End If
        o_n.NewValue += (newVal - oldVal)

        'ส่งต่อไปยังแม่
        If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
          SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, type)
        End If
      End If
    End Sub
    'Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
    '    If Me.m_payment Is Nothing Or Not m_isInitialized Then
    '        Return
    '    End If
    '    Dim dirtyFlag As Boolean = False
    '    Select Case CType(sender, Control).Name.ToLower
    '        Case "cmbcode"
    '            Me.m_payment.Code = cmbCode.Text
    '            ComboCodeIndex = cmbCode.SelectedIndex
    '            m_oldCode = Me.cmbCode.Text
    '            dirtyFlag = True
    '        Case "txtnote"
    '            Me.m_payment.Note = txtNote.Text
    '            dirtyFlag = True
    '        Case "dtpdocdate"
    '            If Not Me.m_payment.DocDate.Equals(dtpDocDate.Value) Then
    '                If Not m_dateSetting Then
    '                    Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
    '                    Me.m_payment.DocDate = dtpDocDate.Value
    '                End If
    '                dirtyFlag = True
    '            End If
    '        Case "txtdocdate"
    '            m_dateSetting = True
    '            If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
    '                Dim theDate As Date = CDate(Me.txtDocDate.Text)
    '                If Not Me.m_payment.DocDate.Equals(theDate) Then
    '                    dtpDocDate.Value = theDate
    '                    Me.m_payment.DocDate = dtpDocDate.Value
    '                    dirtyFlag = True
    '                End If
    '            Else
    '                Me.m_payment.DocDate = Date.Now
    '                Me.m_payment.DocDate = Date.MinValue
    '                dirtyFlag = True
    '            End If
    '            m_dateSetting = False
    '        Case "txtdiscountamount"
    '            If IsNumeric(txtDiscountAmount.Text) Then
    '                Me.m_payment.DiscountAmount = CDec(txtDiscountAmount.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtotherrevenue"
    '            If IsNumeric(txtOtherRevenue.Text) Then
    '                Me.m_payment.OtherRevenue = CDec(txtOtherRevenue.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtinterest"
    '            If IsNumeric(txtInterest.Text) Then
    '                Me.m_payment.Interest = CDec(txtInterest.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtbankcharge"
    '            If IsNumeric(txtBankCharge.Text) Then
    '                Me.m_payment.BankCharge = CDec(txtBankCharge.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '        Case "txtotherexpense"
    '            If IsNumeric(txtOtherExpense.Text) Then
    '                Me.m_payment.OtherExpense = CDec(txtOtherExpense.Text)
    '            End If
    '            Me.UpdateAmount()
    '            dirtyFlag = True
    '    End Select
    '    Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
    '    CheckFormEnable()
    'End Sub
    Public Sub SetStatus()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '    " " & m_entity.CancelDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '    " " & m_entity.LastEditDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '    lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '    " " & m_entity.OriginDate.ToShortTimeString & _
      '    "  โดย:" & m_entity.Originator.Name
      'Else
      '    lblStatus.Text = ""
      'End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If Not Object.ReferenceEquals(Me.m_entity, Value) Then
          Me.m_entity = Nothing
          Me.m_entity = Value
        End If
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
    End Sub
#End Region

#Region "Buttons Event"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      'If Me.chkAutorun.Checked Then
      '    'Me.Validator.SetRequired(Me.txtCode, False)
      '    'Me.ErrorProvider1.SetError(Me.txtCode, "")  
      '    'cmbCode.Items.Clear()
      '    Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
      '    'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_payment.EntityId)
      '    cmbCode.SelectedIndex = ComboCodeIndex
      '    m_oldCode = Me.cmbCode.Text
      '    Me.m_payment.Code = m_oldCode
      '    Me.m_payment.AutoGen = True
      'Else
      '    'Me.Validator.SetRequired(Me.txtCode, True)
      '    'cmbCode.SelectedIndex = ComboCodeIndex

      '    Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
      '    'Me.cmbCode.Items.Clear()
      '    Me.cmbCode.Text = m_oldCode
      '    Me.m_payment.AutoGen = False
      'End If
    End Sub
    'Private Sub ibtnOtherDebit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnOtherDebit.Click
    '    Dim dlg As New OtherPayment(Me.m_payment, True)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
    '    If myDialog.ShowDialog() = DialogResult.OK Then
    '        UpdateAmount()
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    'End Sub
    'Private Sub ibtnTotalCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnTotalCredit.Click
    '    Dim dlg As New OtherPayment(Me.m_payment, False)
    '    Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(dlg)
    '    If myDialog.ShowDialog() = DialogResult.OK Then
    '        UpdateAmount()
    '        Me.WorkbenchWindow.ViewContent.IsDirty = True
    '    End If
    'End Sub
#End Region
#Region "Event Handlers"
    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.RefDoc.ToCostCenter Is Nothing Then
        msgServ.ShowMessage("${res:Global.Error.SpecifyCC}")
        Return
      End If
      'If Me.RefDoc.ToCostCenter.BoqId = 0 Then
      '  msgServ.ShowMessage("${res:Global.Error.SpecifyCCWithBOQ}")
      '  Return
      'End If
      Dim doc As IWBSAllocatableItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
      'dt.Clear()
      'Dim view As Integer = 7
      Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      If wsdColl.GetSumPercent >= 100 Then
        'msgServ.ShowMessage(wsdColl.GetSumPercent)
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
        Return
      ElseIf doc.AllocationErrorMessage.Length > 0 Then
        msgServ.ShowMessage(doc.AllocationErrorMessage)
        Return
      Else
        Dim wbsd As New WBSDistribute
        wbsd.CostCenter = Me.RefDoc.ToCostCenter
        wbsd.Percent = 100 - wsdColl.GetSumPercent
        wsdColl.Add(wbsd)
      End If
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      'wsdColl.Populate(dt, doc, view)
      Me.RefreshDocs() '---------------------**
      m_isInitialized = flag
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
      'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
      'dt.Clear()
      Dim doc As WBSDistribute = Me.CurrentWsbsd
      If doc Is Nothing Then
        Return
      End If
      'Dim doc As PRItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '    Return
      'End If

      If TypeOf m_entity Is IWBSAllocatable Then
        Dim al As IWBSAllocatable = CType(m_entity, IWBSAllocatable)
        'Dim dt As TreeTable = m_wbsTreeManager.Treetable
        'dt.Clear()
        For Each ali As IWBSAllocatableItem In al.GetWBSAllocatableItemCollection
          'Dim newRow As TreeRow = dt.Childs.Add()
          'newRow("ItemType") = ali.Type
          'newRow("Description") = ali.Description
          'newRow("ItemAmount") = Configuration.FormatToString(ali.ItemAmount, DigitConfig.Price)
          'newRow("CCButton") = "invisible"
          'newRow("Button") = "invisible"

          'newRow.Tag = ali
          If ali.WBSDistributeCollection.Contains(doc) Then
            ali.WBSDistributeCollection.Remove(doc)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
          End If


          'For Each wbsd As WBSDistribute In ali.WBSDistributeCollection
          'Dim wbsRow As TreeRow = dt.Childs.Add()
          'wbsRow("CostCenter") = wbsd.CostCenter.Code & " : " & wbsd.CostCenter.Name
          'wbsRow("WBS") = wbsd.WBS.Code & " : " & wbsd.WBS.Name

          'wbsRow.Tag = wbsd

          'Next
        Next
      End If

      'Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      'If wsdColl.Count > 0 Then
      '    wsdColl.Remove(wsdColl.Count - 1)
      '    Me.WorkbenchWindow.ViewContent.IsDirty = True
      'End If
      'Dim view As Integer = 7
      Dim flag As Boolean = m_isInitialized
      m_isInitialized = False
      'wsdColl.Populate(dt, doc, View)
      Me.RefreshDocs()
      m_isInitialized = flag
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

    '#Region "Overrides"
    '        Public Overrides ReadOnly Property TabPageIcon() As String
    '            Get
    '                Return (New Payment).DetailPanelIcon
    '            End Get
    '        End Property
    '#End Region

    '#Region "IPrintable"
    '        Public Overrides ReadOnly Property PrintDocument() As System.Drawing.Printing.PrintDocument
    '            Get
    '                Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
    '                Dim FormPath As String = (myPropertyService.DataDirectory & Path.DirectorySeparatorChar & "forms" & Path.DirectorySeparatorChar & "Adobe" & Path.DirectorySeparatorChar & "documents")
    '                'Dim thePath As String = FormPath & Path.DirectorySeparatorChar & m_payment.ClassName & ".xml"
    '                Dim thePath As String = FormPath & Path.DirectorySeparatorChar & "PaymentVoucher.xml"
    '                Dim df As New DesignerForm(thePath, CType(Me.m_payment, IPrintableEntity))
    '                Return df.PrintDocument
    '            End Get
    '        End Property
    '        Public Overrides ReadOnly Property CanPrint() As Boolean
    '            Get
    '                Return False
    '            End Get
    '        End Property
    '#End Region
#Region "WBS TreeTable Handlers"
    Private Sub WBSTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Dim index As Integer = Me.m_wbsTreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
      If WBSValidateRow(CType(e.Row, TreeRow)) Then
        'UpdateAmount(e)
        Me.m_wbsTreeManager.Treetable.AcceptChanges()
      End If
      Me.RefreshDocs()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub WBSUpdateAmount(ByVal e As DataColumnChangeEventArgs)
      'Dim item As WBSDistribute = Me.CurrentWsbsd
      'If item Is Nothing Then
      '    Return
      'End If
      'Dim currItem As PurchaseDNItem = Me.CurrentItem
      'If currItem Is Nothing Then
      '    Return
      'End If
      'e.Row("Amount") = Configuration.FormatToString(item.Percent * currItem.Amount / 100, DigitConfig.Price)
    End Sub
    Private Sub WBSTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "wbs"
            SetWBSCode(e)
          Case "percent"
            SetWBSPercent(e)
          Case "amount"
            SetAmount(e)
        End Select
        WBSValidateRow(e)
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Public Sub WBSValidateRow(ByVal e As DataColumnChangeEventArgs)
      Dim wbs As Object = e.Row("wbs")
      Dim percent As Object = e.Row("percent")
      Dim amount As Object = e.Row("amount")

      Select Case e.Column.ColumnName.ToLower
        Case "wbs"
          wbs = e.ProposedValue
        Case "percent"
          percent = e.ProposedValue
        Case "amount"
          amount = e.ProposedValue
        Case Else
          Return
      End Select

      Dim isBlankRow As Boolean = False
      If IsDBNull(wbs) Then
        isBlankRow = True
      End If

      If Not isBlankRow Then
        If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
          e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
        Else
          e.Row.SetColumnError("percent", "")
        End If
        If IsDBNull(wbs) OrElse wbs.ToString.Replace(":", "").Length = 0 Then
          e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
        Else
          e.Row.SetColumnError("wbs", "")
        End If
        If IsDBNull(amount) OrElse CDec(amount) <= 0 Then
          e.Row.SetColumnError("amount", Me.StringParserService.Parse("${res:Global.Error.RealAmountMissing}"))
        Else
          e.Row.SetColumnError("amount", "")
        End If
      End If

    End Sub
    Public Function WBSValidateRow(ByVal row As TreeRow) As Boolean
      If row.IsNull("WBS") Then
        Return False
      End If
      Return True
    End Function
    Private m_wbsUpdating As Boolean = False
    Public Sub SetWBSPercent(ByVal e As DataColumnChangeEventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_wbsUpdating Then
        Return
      End If
      Dim item As WBSDistribute = Me.CurrentWsbsd
      If item Is Nothing Then
        Return
      End If

      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)

      Dim oldvalue As Decimal = 0
      If Not e.Row.IsNull(e.Column) Then
        oldvalue = CDec(e.Row(e.Column))
      End If

      Dim wsdColl As WBSDistributeCollection = Me.CurrentParItem.WBSDistributeCollection
      If (wsdColl.GetSumPercent) - oldvalue + value > 100 Then
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
        Return
      End If

      m_wbsUpdating = True
      item.Percent = value
      m_wbsUpdating = False
    End Sub
    Public Sub SetAmount(ByVal e As DataColumnChangeEventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If m_wbsUpdating Then
        Return
      End If
      Dim item As WBSDistribute = Me.CurrentWsbsd
      If item Is Nothing Then
        Return
      End If

      If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
        e.ProposedValue = ""
        Return
      End If
      e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
      Dim value As Decimal = CDec(e.ProposedValue)

      Dim oldvalue As Decimal = 0
      If Not e.Row.IsNull(e.Column) Then
        oldvalue = CDec(e.Row(e.Column))
      End If
      Dim doc As IWBSAllocatableItem = Me.CurrentParItem
      If doc Is Nothing Then
        Return
      End If
      Dim wsdColl As WBSDistributeCollection = Me.CurrentParItem.WBSDistributeCollection
      Dim Amount As Decimal = wsdColl.GetSumAmount - oldvalue + value
      If Amount > doc.ItemAmount Then
        e.ProposedValue = e.Row(e.Column)
        msgServ.ShowMessageFormatted("${res:Global.Error.AmountOverCostAmount}", New String() {Configuration.FormatToString(Amount, DigitConfig.Price), Configuration.FormatToString(doc.ItemAmount, DigitConfig.Price)})
        Return
      End If

      m_wbsUpdating = True
      item.Amount = value
      m_wbsUpdating = False
    End Sub

    'Private Function DupWBSCode(ByVal e As DataColumnChangeEventArgs) As Boolean
    '    If e.Row.IsNull("stocki_entityType") Then
    '        Return False
    '    End If
    '    If IsDBNull(e.ProposedValue) Then
    '        Return False
    '    End If
    '    For Each row As TreeRow In Me.ItemTable.Childs
    '        If Not row Is e.Row Then
    '            If Not row.IsNull("stocki_entityType") Then
    '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '                    If Not row.IsNull("code") Then
    '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '                            Return True
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Next
    '    Return False
    'End Function
    Public Sub SetWBSCode(ByVal e As System.Data.DataColumnChangeEventArgs)
      'If m_wbsUpdating Then
      '    Return
      'End If
      'm_wbsUpdating = True
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      'Dim currItem As PurchaseDNItem = Me.CurrentItem
      'If currItem Is Nothing Then
      '    Return
      'End If
      'If currItem.GoodsReceiptLine <> 0 Then
      '    msgServ.ShowMessage("${res:Global.Error.DNItemWithRefCannotEditWBS}")
      '    e.ProposedValue = e.Row(e.Column)
      '    Return
      'End If
      'If e.Row.IsNull("stocki_entityType") Then
      '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '    e.ProposedValue = e.Row(e.Column)
      '    m_wbsUpdating = False
      '    Return
      'End If
      'If DupCode(e) Then
      '    Dim item As New GoodsReceiptItem
      '    item.CopyFromDataRow(CType(e.Row, TreeRow))
      '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
      '    e.ProposedValue = e.Row(e.Column)
      '    m_wbsUpdating = False
      '    Return
      'End If
      'Select Case CInt(e.Row("stocki_entityType"))
      '    Case 0 'Blank
      '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_wbsUpdating = False
      '        Return
      '    Case 28 'F/A
      '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_wbsUpdating = False
      '        Return
      '    Case 19 'Tool
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_wbsUpdating = False
      '            Return
      '        End If
      '        Dim myTool As New Tool(e.ProposedValue.ToString)
      '        If Not myTool.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_wbsUpdating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = myTool.Unit
      '            e.Row("stocki_entity") = myTool.Id
      '            e.ProposedValue = myTool.Code
      '            e.Row("stocki_itemName") = myTool.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
      '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
      '                e.Row("stocki_acct") = ga.Account.Id
      '                e.Row("AccountCode") = ga.Account.Code
      '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case 42 'LCI
      '        If e.ProposedValue.ToString.Length = 0 Then
      '            If e.Row(e.Column).ToString.Length <> 0 Then
      '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
      '                    ClearRow(e)
      '                Else
      '                    e.ProposedValue = e.Row(e.Column)
      '                End If
      '            End If
      '            m_wbsUpdating = False
      '            Return
      '        End If
      '        Dim lci As New LCIItem(e.ProposedValue.ToString)
      '        If Not lci.Originated Then
      '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
      '            e.ProposedValue = e.Row(e.Column)
      '            m_wbsUpdating = False
      '            Return
      '        Else
      '            Dim myUnit As Unit = lci.DefaultUnit
      '            e.Row("stocki_entity") = lci.Id
      '            e.ProposedValue = lci.Code
      '            e.Row("stocki_itemName") = lci.Name
      '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
      '                e.Row("stocki_unit") = myUnit.Id
      '                e.Row("Unit") = myUnit.Name
      '            Else
      '                e.Row("stocki_unit") = DBNull.Value
      '                e.Row("Unit") = DBNull.Value
      '            End If
      '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
      '                e.Row("stocki_acct") = lci.Account.Id
      '                e.Row("AccountCode") = lci.Account.Code
      '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
      '            Else
      '                e.Row("stocki_acct") = DBNull.Value
      '                e.Row("AccountCode") = DBNull.Value
      '                e.Row("Account") = DBNull.Value
      '            End If
      '        End If
      '    Case Else
      '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
      '        e.ProposedValue = e.Row(e.Column)
      '        m_wbsUpdating = False
      '        Return
      'End Select
      'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
      'm_wbsUpdating = False
    End Sub
    Private Sub WBSItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    End Sub
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      RefreshBlankGrid()
    End Sub
    Private Sub RefreshBlankGrid()

    End Sub
#End Region

#Region "After the main entity has been saved"
    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      If Not successful Then
        Return
      End If
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
      'MyBase.NotifyAfterSave(flag)
    End Sub
    Public Overrides Sub NotifyBeforeSave()
      MyBase.NotifyBeforeSave()
      Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
    End Sub
#End Region

  End Class

End Namespace
