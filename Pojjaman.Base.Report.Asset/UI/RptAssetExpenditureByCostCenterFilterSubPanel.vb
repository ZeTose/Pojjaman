Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports Telerik.WinControls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAssetExpenditureByCostCenterFilterSubPanel
    'Inherits UserControl
    Inherits AbstractFilterSubPanel
    Implements IReportFilterSubPanel

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
    Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDocDateStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmbCostCenterCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents chkShowAssetNoMaintain As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowDetail As System.Windows.Forms.CheckBox
    Friend WithEvents cmbAssetCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbAssetCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbAssetTypeCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbAssetTypeCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbCostCenterCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents lblAssetCodeStart As System.Windows.Forms.Label
    Friend WithEvents lblAssetTypeCodeStart As System.Windows.Forms.Label
    Friend WithEvents lblAssetCodeEnd As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAssetTypeCodeEnd As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAsset As System.Windows.Forms.Label
    Friend WithEvents lblAssetType As System.Windows.Forms.Label
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbCostCenterCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.txtDocDateEnd = New DevExpress.XtraEditors.DateEdit()
      Me.txtDocDateStart = New DevExpress.XtraEditors.DateEdit()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.cmbCostCenterCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.lblCostCenter = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.lblAssetType = New System.Windows.Forms.Label()
      Me.lblAssetTypeCodeEnd = New System.Windows.Forms.Label()
      Me.lblAssetTypeCodeStart = New System.Windows.Forms.Label()
      Me.cmbAssetTypeCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbAssetTypeCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.lblAsset = New System.Windows.Forms.Label()
      Me.lblAssetCodeEnd = New System.Windows.Forms.Label()
      Me.lblAssetCodeStart = New System.Windows.Forms.Label()
      Me.cmbAssetCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbAssetCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.chkShowDetail = New System.Windows.Forms.CheckBox()
      Me.chkShowAssetNoMaintain = New System.Windows.Forms.CheckBox()
      Me.grbMaster.SuspendLayout()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.txtDocDateEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.txtDocDateEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.txtDocDateStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.txtDocDateStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAssetTypeCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAssetTypeCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAssetCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAssetCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
              Or System.Windows.Forms.AnchorStyles.Left) _
              Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbMaster.Controls.Add(Me.chkShowAssetNoMaintain)
      Me.grbMaster.Controls.Add(Me.chkShowDetail)
      Me.grbMaster.Controls.Add(Me.cmbAssetCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbAssetCodeStart)
      Me.grbMaster.Controls.Add(Me.cmbAssetTypeCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbAssetTypeCodeStart)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeStart)
      Me.grbMaster.Controls.Add(Me.txtDocDateEnd)
      Me.grbMaster.Controls.Add(Me.lblAssetCodeStart)
      Me.grbMaster.Controls.Add(Me.txtDocDateStart)
      Me.grbMaster.Controls.Add(Me.lblAssetTypeCodeStart)
      Me.grbMaster.Controls.Add(Me.btnRefresh)
      Me.grbMaster.Controls.Add(Me.lblAssetCodeEnd)
      Me.grbMaster.Controls.Add(Me.Label3)
      Me.grbMaster.Controls.Add(Me.lblAssetTypeCodeEnd)
      Me.grbMaster.Controls.Add(Me.lblDocDateStart)
      Me.grbMaster.Controls.Add(Me.Label2)
      Me.grbMaster.Controls.Add(Me.lblAsset)
      Me.grbMaster.Controls.Add(Me.lblDocDateEnd)
      Me.grbMaster.Controls.Add(Me.lblAssetType)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.lblCostCenter)
      Me.grbMaster.Controls.Add(Me.Label1)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(208, 517)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      '
      'cmbCostCenterCodeStart
      '
      '
      'cmbCostCenterCodeStart.NestedRadGridView
      '
      Me.cmbCostCenterCodeStart.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbCostCenterCodeStart.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCostCenterCodeStart.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbCostCenterCodeStart.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbCostCenterCodeStart.EditorControl.Name = "NestedRadGridView"
      Me.cmbCostCenterCodeStart.EditorControl.ReadOnly = True
      Me.cmbCostCenterCodeStart.EditorControl.ShowGroupPanel = False
      Me.cmbCostCenterCodeStart.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbCostCenterCodeStart.EditorControl.TabIndex = 0
      Me.cmbCostCenterCodeStart.Location = New System.Drawing.Point(53, 113)
      Me.cmbCostCenterCodeStart.Name = "cmbCostCenterCodeStart"
      '
      '
      '
      Me.cmbCostCenterCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbCostCenterCodeStart.TabIndex = 3
      Me.cmbCostCenterCodeStart.TabStop = False
      Me.cmbCostCenterCodeStart.Text = "RadMultiColumnComboBox1"
      '
      'txtDocDateEnd
      '
      Me.txtDocDateEnd.EditValue = Nothing
      Me.txtDocDateEnd.Location = New System.Drawing.Point(53, 58)
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.txtDocDateEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
      Me.txtDocDateEnd.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
      Me.txtDocDateEnd.Size = New System.Drawing.Size(100, 20)
      Me.txtDocDateEnd.TabIndex = 2
      '
      'txtDocDateStart
      '
      Me.txtDocDateStart.EditValue = Nothing
      Me.txtDocDateStart.Location = New System.Drawing.Point(53, 34)
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.txtDocDateStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
      Me.txtDocDateStart.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
      Me.txtDocDateStart.Size = New System.Drawing.Size(100, 20)
      Me.txtDocDateStart.TabIndex = 1
      '
      'btnRefresh
      '
      Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRefresh.Location = New System.Drawing.Point(11, 412)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 64)
      Me.btnRefresh.TabIndex = 11
      Me.btnRefresh.Text = "Refresh"
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(11, 37)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(39, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(23, 58)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(27, 18)
      Me.lblDocDateEnd.TabIndex = 0
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(29, 482)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(54, 23)
      Me.btnReset.TabIndex = 12
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "Clear"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(8, 14)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(136, 18)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "วันที่เอกสาร"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Me.ErrorProvider1
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'cmbCostCenterCodeEnd
      '
      '
      'cmbCostCenterCodeEnd.NestedRadGridView
      '
      Me.cmbCostCenterCodeEnd.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbCostCenterCodeEnd.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCostCenterCodeEnd.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbCostCenterCodeEnd.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbCostCenterCodeEnd.EditorControl.Name = "NestedRadGridView"
      Me.cmbCostCenterCodeEnd.EditorControl.ReadOnly = True
      Me.cmbCostCenterCodeEnd.EditorControl.ShowGroupPanel = False
      Me.cmbCostCenterCodeEnd.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbCostCenterCodeEnd.EditorControl.TabIndex = 0
      Me.cmbCostCenterCodeEnd.Location = New System.Drawing.Point(53, 137)
      Me.cmbCostCenterCodeEnd.Name = "cmbCostCenterCodeEnd"
      '
      '
      '
      Me.cmbCostCenterCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeEnd.Size = New System.Drawing.Size(141, 21)
      Me.cmbCostCenterCodeEnd.TabIndex = 4
      Me.cmbCostCenterCodeEnd.TabStop = False
      Me.cmbCostCenterCodeEnd.Text = "RadMultiColumnComboBox1"
      '
      'lblCostCenter
      '
      Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 92)
      Me.lblCostCenter.Name = "lblCostCenter"
      Me.lblCostCenter.Size = New System.Drawing.Size(136, 18)
      Me.lblCostCenter.TabIndex = 3
      Me.lblCostCenter.Text = "Cost Center"
      Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(23, 137)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(27, 18)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "ถึง"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(11, 116)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(39, 18)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "ตั้งแต่"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAssetType
      '
      Me.lblAssetType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetType.ForeColor = System.Drawing.Color.Black
      Me.lblAssetType.Location = New System.Drawing.Point(8, 173)
      Me.lblAssetType.Name = "lblAssetType"
      Me.lblAssetType.Size = New System.Drawing.Size(136, 18)
      Me.lblAssetType.TabIndex = 3
      Me.lblAssetType.Text = "ประเภทสินทรัพย์"
      Me.lblAssetType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAssetTypeCodeEnd
      '
      Me.lblAssetTypeCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetTypeCodeEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAssetTypeCodeEnd.Location = New System.Drawing.Point(23, 218)
      Me.lblAssetTypeCodeEnd.Name = "lblAssetTypeCodeEnd"
      Me.lblAssetTypeCodeEnd.Size = New System.Drawing.Size(27, 18)
      Me.lblAssetTypeCodeEnd.TabIndex = 0
      Me.lblAssetTypeCodeEnd.Text = "ถึง"
      Me.lblAssetTypeCodeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAssetTypeCodeStart
      '
      Me.lblAssetTypeCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetTypeCodeStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetTypeCodeStart.Location = New System.Drawing.Point(11, 197)
      Me.lblAssetTypeCodeStart.Name = "lblAssetTypeCodeStart"
      Me.lblAssetTypeCodeStart.Size = New System.Drawing.Size(39, 18)
      Me.lblAssetTypeCodeStart.TabIndex = 0
      Me.lblAssetTypeCodeStart.Text = "ตั้งแต่"
      Me.lblAssetTypeCodeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbAssetTypeCodeStart
      '
      '
      'cmbAssetTypeCodeStart.NestedRadGridView
      '
      Me.cmbAssetTypeCodeStart.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbAssetTypeCodeStart.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbAssetTypeCodeStart.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbAssetTypeCodeStart.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbAssetTypeCodeStart.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbAssetTypeCodeStart.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbAssetTypeCodeStart.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbAssetTypeCodeStart.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbAssetTypeCodeStart.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbAssetTypeCodeStart.EditorControl.Name = "NestedRadGridView"
      Me.cmbAssetTypeCodeStart.EditorControl.ReadOnly = True
      Me.cmbAssetTypeCodeStart.EditorControl.ShowGroupPanel = False
      Me.cmbAssetTypeCodeStart.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbAssetTypeCodeStart.EditorControl.TabIndex = 0
      Me.cmbAssetTypeCodeStart.Location = New System.Drawing.Point(53, 194)
      Me.cmbAssetTypeCodeStart.Name = "cmbAssetTypeCodeStart"
      '
      '
      '
      Me.cmbAssetTypeCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAssetTypeCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbAssetTypeCodeStart.TabIndex = 5
      Me.cmbAssetTypeCodeStart.TabStop = False
      Me.cmbAssetTypeCodeStart.Text = "RadMultiColumnComboBox1"
      '
      'cmbAssetTypeCodeEnd
      '
      '
      'cmbAssetTypeCodeEnd.NestedRadGridView
      '
      Me.cmbAssetTypeCodeEnd.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbAssetTypeCodeEnd.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbAssetTypeCodeEnd.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbAssetTypeCodeEnd.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbAssetTypeCodeEnd.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbAssetTypeCodeEnd.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbAssetTypeCodeEnd.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbAssetTypeCodeEnd.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbAssetTypeCodeEnd.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbAssetTypeCodeEnd.EditorControl.Name = "NestedRadGridView"
      Me.cmbAssetTypeCodeEnd.EditorControl.ReadOnly = True
      Me.cmbAssetTypeCodeEnd.EditorControl.ShowGroupPanel = False
      Me.cmbAssetTypeCodeEnd.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbAssetTypeCodeEnd.EditorControl.TabIndex = 0
      Me.cmbAssetTypeCodeEnd.Location = New System.Drawing.Point(53, 218)
      Me.cmbAssetTypeCodeEnd.Name = "cmbAssetTypeCodeEnd"
      '
      '
      '
      Me.cmbAssetTypeCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAssetTypeCodeEnd.Size = New System.Drawing.Size(141, 21)
      Me.cmbAssetTypeCodeEnd.TabIndex = 6
      Me.cmbAssetTypeCodeEnd.TabStop = False
      Me.cmbAssetTypeCodeEnd.Text = "RadMultiColumnComboBox1"
      '
      'lblAsset
      '
      Me.lblAsset.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAsset.ForeColor = System.Drawing.Color.Black
      Me.lblAsset.Location = New System.Drawing.Point(8, 255)
      Me.lblAsset.Name = "lblAsset"
      Me.lblAsset.Size = New System.Drawing.Size(136, 18)
      Me.lblAsset.TabIndex = 3
      Me.lblAsset.Text = "ประเภทสินทรัพย์"
      Me.lblAsset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAssetCodeEnd
      '
      Me.lblAssetCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetCodeEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAssetCodeEnd.Location = New System.Drawing.Point(23, 300)
      Me.lblAssetCodeEnd.Name = "lblAssetCodeEnd"
      Me.lblAssetCodeEnd.Size = New System.Drawing.Size(27, 18)
      Me.lblAssetCodeEnd.TabIndex = 0
      Me.lblAssetCodeEnd.Text = "ถึง"
      Me.lblAssetCodeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAssetCodeStart
      '
      Me.lblAssetCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetCodeStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetCodeStart.Location = New System.Drawing.Point(11, 279)
      Me.lblAssetCodeStart.Name = "lblAssetCodeStart"
      Me.lblAssetCodeStart.Size = New System.Drawing.Size(39, 18)
      Me.lblAssetCodeStart.TabIndex = 0
      Me.lblAssetCodeStart.Text = "ตั้งแต่"
      Me.lblAssetCodeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbAssetCodeStart
      '
      '
      'cmbAssetCodeStart.NestedRadGridView
      '
      Me.cmbAssetCodeStart.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbAssetCodeStart.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbAssetCodeStart.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbAssetCodeStart.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbAssetCodeStart.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbAssetCodeStart.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbAssetCodeStart.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbAssetCodeStart.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbAssetCodeStart.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbAssetCodeStart.EditorControl.Name = "NestedRadGridView"
      Me.cmbAssetCodeStart.EditorControl.ReadOnly = True
      Me.cmbAssetCodeStart.EditorControl.ShowGroupPanel = False
      Me.cmbAssetCodeStart.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbAssetCodeStart.EditorControl.TabIndex = 0
      Me.cmbAssetCodeStart.Location = New System.Drawing.Point(53, 276)
      Me.cmbAssetCodeStart.Name = "cmbAssetCodeStart"
      '
      '
      '
      Me.cmbAssetCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAssetCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbAssetCodeStart.TabIndex = 7
      Me.cmbAssetCodeStart.TabStop = False
      Me.cmbAssetCodeStart.Text = "RadMultiColumnComboBox1"
      '
      'cmbAssetCodeEnd
      '
      '
      'cmbAssetCodeEnd.NestedRadGridView
      '
      Me.cmbAssetCodeEnd.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbAssetCodeEnd.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbAssetCodeEnd.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbAssetCodeEnd.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbAssetCodeEnd.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbAssetCodeEnd.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbAssetCodeEnd.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbAssetCodeEnd.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbAssetCodeEnd.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbAssetCodeEnd.EditorControl.Name = "NestedRadGridView"
      Me.cmbAssetCodeEnd.EditorControl.ReadOnly = True
      Me.cmbAssetCodeEnd.EditorControl.ShowGroupPanel = False
      Me.cmbAssetCodeEnd.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbAssetCodeEnd.EditorControl.TabIndex = 0
      Me.cmbAssetCodeEnd.Location = New System.Drawing.Point(53, 300)
      Me.cmbAssetCodeEnd.Name = "cmbAssetCodeEnd"
      '
      '
      '
      Me.cmbAssetCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAssetCodeEnd.Size = New System.Drawing.Size(141, 21)
      Me.cmbAssetCodeEnd.TabIndex = 8
      Me.cmbAssetCodeEnd.TabStop = False
      Me.cmbAssetCodeEnd.Text = "RadMultiColumnComboBox1"
      '
      'chkShowDetail
      '
      Me.chkShowDetail.AutoSize = True
      Me.chkShowDetail.Location = New System.Drawing.Point(11, 343)
      Me.chkShowDetail.Name = "chkShowDetail"
      Me.chkShowDetail.Size = New System.Drawing.Size(139, 17)
      Me.chkShowDetail.TabIndex = 9
      Me.chkShowDetail.Text = "แสดงรายละเอียดเอกสาร"
      Me.chkShowDetail.UseVisualStyleBackColor = True
      '
      'chkShowAssetNoMaintain
      '
      Me.chkShowAssetNoMaintain.AutoSize = True
      Me.chkShowAssetNoMaintain.Location = New System.Drawing.Point(11, 366)
      Me.chkShowAssetNoMaintain.Name = "chkShowAssetNoMaintain"
      Me.chkShowAssetNoMaintain.Size = New System.Drawing.Size(181, 17)
      Me.chkShowAssetNoMaintain.TabIndex = 10
      Me.chkShowAssetNoMaintain.Text = "แสดงสินทรัพย์ที่ไม่มีการซ่อมบำรุง"
      Me.chkShowAssetNoMaintain.UseVisualStyleBackColor = True
      '
      'RptAssetExpenditureByCostCenterFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptAssetExpenditureByCostCenterFilterSubPanel"
      Me.Size = New System.Drawing.Size(224, 537)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.txtDocDateEnd.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.txtDocDateEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.txtDocDateStart.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.txtDocDateStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAssetTypeCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAssetTypeCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAssetCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAssetCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      'Me.lblToCCstart.Text = Me.StringParserService.Parse("${res:Gui.Panels.RptMatCountFilterSubPanel.lblToCCstart}")
      'Me.Validator.SetDisplayName(txtToCCstart, lblToCCstart.Text)

      '' Global {ถึง}
      'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      'Me.lblToCCend.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(txtToCCend, lblToCCend.Text)

      '' Button
      'Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      'Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      '' GroupBox
      'Me.grbMaster.Text = Me.StringParserService.Parse("${res:Gui.Panels.RptMatCountFilterSubPanel.grbMaster}")
      'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Gui.Panels.RptMatCountFilterSubPanel.grbDetail}")

      'Me.chkNegativeOnly.Text = Me.StringParserService.Parse("${res:Gui.Panels.RptMatCountFilterSubPanel.chkNegativeOnly}")
      'Me.chkNoZero.Text = Me.StringParserService.Parse("${res:Gui.Panels.RptMatCountFilterSubPanel.chkNoZero}")
    End Sub
#End Region

#Region "Member"
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      InitializeComponent()
      EventWiring()
      Initialize()

      SetLabelText()
      LoopControl(Me)
    End Sub
#End Region

#Region "Properties"

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' เรียงตาม 
      'RptMatReturnFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbOrderBy, "rpt_matreturn")
      'For i As Integer = 1 To 5
      '  Dim item As New IdValuePair(i, "ตาม Level " & i.ToString)
      '  cmbShownLevel.Items.Add(item)
      'Next
    End Sub
    Private Sub Initialize()
      RegisterDropdown()
      InitialMultiCombo()
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        'If TypeOf grbCtrl Is Gui.Components.FixedGroupBox Then
        '  For Each Ctrl As Control In grbCtrl.Controls
        '    If TypeOf grbCtrl Is RadMultiColumnComboBox Then
        '      SetAllRadMultiComboBoxFilter(grbCtrl)
        '    ElseIf TypeOf grbCtrl Is RadDateTimePicker Then
        '      CType(grbCtrl, RadDateTimePicker).SetToNullValue()
        '    ElseIf TypeOf grbCtrl Is TextBox Then
        '      grbCtrl.Text = ""
        '    End If
        '  Next
        'End If
        If TypeOf grbCtrl Is DevExpress.XtraEditors.DateEdit Then
          grbCtrl.Text = ""
        ElseIf TypeOf grbCtrl Is RadMultiColumnComboBox Then
          SetAllRadMultiComboBoxFilter(grbCtrl)
        End If
      Next

      Me.txtDocDateEnd.DateTime = Now.Date

      'Me.DocDateEnd = Date.Now
      'Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      'Me.dtpDocDateEnd.Value = Me.DocDateEnd

      'If Me.cmbShownLevel.Items.Count >= 1 Then
      '  Me.cmbShownLevel.SelectedIndex = 0
      'End If

    End Sub
    Private Sub SetAllRadMultiComboBoxFilter(ByVal ctrl As Object)
      Dim rmcb As RadMultiColumnComboBox = CType(ctrl, RadMultiColumnComboBox)
      rmcb.AutoFilter = True
      rmcb.DisplayMember = rmcb.MultiColumnComboBoxElement.Columns(0).FieldName  '"acct_code"
      Dim filter As New FilterExpression(rmcb.DisplayMember,
                                         FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)

      Dim fiContain As Boolean = False
      For Each fi As FilterExpression In rmcb.EditorControl.MasterGridViewTemplate.FilterExpressions
        If fi.FieldName.Equals(filter.FieldName) Then
          fiContain = True
        End If
      Next
      If Not fiContain Then
        rmcb.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      End If

      rmcb.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      'Me.cmbAccountCodeStart.DropDownStyle = RadDropDownStyle.DropDown
      'Me.SetAutoCompleteAble(cmbAccountCodeStart, False)
    End Sub
    Public Overrides Function GetFilterString() As String
      '@ nvarchar(50) = null ,  
      '@ nvarchar(50) = null ,  
      '@ nvarchar(50) = null ,  
      '@ nvarchar(50) = null ,  
      '@cc_id nvarchar(50) = null ,  
      '@ nvarchar(50) = null ,  
      '@ nvarchar(50) = null ,  
      '@ bit = null ,  
      '@ bit = null ,  
      '@ChkOpb bit = null ,  
      '@ int = null ,   
    End Function
    Public Overrides Function GetFilterArray() As BusinessLogic.Filter()
      Dim arr(10) As BusinessLogic.Filter
      arr(0) = New BusinessLogic.Filter("DocDateStart", IIf(Me.txtDocDateStart.Text.Length = 0, DBNull.Value, Me.txtDocDateStart.DateTime))
      arr(1) = New BusinessLogic.Filter("DocDateEnd", IIf(Me.txtDocDateEnd.Text.Length = 0, DBNull.Value, Me.txtDocDateEnd.DateTime))
      arr(2) = New BusinessLogic.Filter("CostCenterCodeStart", IIf(Me.cmbCostCenterCodeStart.Text.Length = 0, DBNull.Value, Me.cmbCostCenterCodeStart.Text))
      arr(3) = New BusinessLogic.Filter("CostCenterCodeEnd", IIf(Me.cmbCostCenterCodeEnd.Text.Length = 0, DBNull.Value, Me.cmbCostCenterCodeEnd.Text))

      arr(4) = New BusinessLogic.Filter("AssetTypeCodeStart", IIf(Me.cmbAssetTypeCodeStart.Text.Length = 0, DBNull.Value, Me.cmbAssetTypeCodeStart.Text))
      arr(5) = New BusinessLogic.Filter("AssetTypeCodeEnd", IIf(Me.cmbAssetTypeCodeEnd.Text.Length = 0, DBNull.Value, Me.cmbAssetTypeCodeEnd.Text))
      arr(6) = New BusinessLogic.Filter("AssetCodeStart", IIf(Me.cmbAssetCodeStart.Text.Length = 0, DBNull.Value, Me.cmbAssetCodeStart.Text))
      arr(7) = New BusinessLogic.Filter("AssetCodeEnd", IIf(Me.cmbAssetCodeEnd.Text.Length = 0, DBNull.Value, Me.cmbAssetCodeEnd.Text))

      arr(8) = New BusinessLogic.Filter("ChkDetailDoc", IIf(Me.chkShowDetail.Checked, 1, 0))
      arr(9) = New BusinessLogic.Filter("ChkNonRepair", IIf(Me.chkShowAssetNoMaintain.Checked, 1, 0))
      arr(10) = New BusinessLogic.Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      'arr(11) = New BusinessLogic.Filter("FilterInfo", Me.GetFilterInfo(arr))

      'arr(2) = New BusinessLogic.Filter("@ToCCCodeStart", ValidCodeOrDBNullText(Me.cmbCostCenterCodeStart))
      'arr(3) = New BusinessLogic.Filter("@ToCCCodeEnd", ValidCodeOrDBNullText(Me.cmbCostCenterCodeEnd))
      'arr(4) = New BusinessLogic.Filter("@userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      'arr(5) = New BusinessLogic.Filter("@LevelToShow", CType(Me.cmbShownLevel.SelectedItem, IdValuePair).Id)
      'arr(6) = New BusinessLogic.Filter("@NotShowCostCenter", IIf(Me.chkShowCostCenter.Checked, 1, DBNull.Value))
      ' ''arr(8) = New Filter("negativeonly", Me.chkNegativeOnly.Checked)
      Return arr
    End Function
    Private Function GetFilterInfo(filters() As Longkong.Pojjaman.BusinessLogic.Filter) As String
      Dim filterInfoString As String = ""
      For Each _filter As BusinessLogic.Filter In filters
        If _filter.Description.Length > 0 Then
          filterInfoString &= _filter.Description & _filter.Value
        End If
      Next
      Return filterInfoString
    End Function
    Private Function ValidCodeOrDBNullText(ByVal newCtl As Control) As Object
      If TypeOf newCtl Is RadDateTimePicker Then
        Dim rdtp As RadDateTimePicker = CType(newCtl, RadDateTimePicker)
        If rdtp.Value.Equals(Date.MinValue) Then
          Return DBNull.Value
        End If
        Return rdtp.Value
      Else
        If newCtl.Text.Length > 0 Then
          Return newCtl.Text
        End If
      End If
      Return DBNull.Value
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnRefresh
      End Get
    End Property

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnRefresh.PerformClick()
    End Sub

    Private Sub popupContainerEdit1_QueryResultValue(ByVal sender As Object, ByVal e As QueryResultValueEventArgs)
      'Get the list box displayed in the editor's dropdown 
      Dim editor As PopupContainerEdit = CType(sender, PopupContainerEdit)
      'Dim listBox As ListBox = findChildListBox(editor.Properties.PopupControl)
      ''Add selected items to the array specified by the editor's edit value 
      'Dim ar As ArrayList = CType(e.Value, ArrayList)
      'ar.Clear()
      'ar.AddRange(listBox.SelectedItems)
    End Sub

    Private Sub InitialMultiCombo()
      'Cost Center =======================================
      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownWidth = 350
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 350

      'Add Cost Center Columns ==========================
      Dim element As Telerik.WinControls.UI.RadMultiColumnComboBoxElement = Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement
      element.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False

      Dim col As New Telerik.WinControls.UI.GridViewTextBoxColumn("cc_code")
      col.HeaderText = "รหัส"
      col.Width = 100
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      col = New Telerik.WinControls.UI.GridViewTextBoxColumn("cc_name")
      col.HeaderText = "ชื่อ"
      col.Width = 200
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      For Each Column As Telerik.WinControls.UI.GridViewDataColumn In Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.Columns
        cmbCostCenterCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh Cost Center List
      Dim costCenterDataSourceStart As DataTable = CostCenter.GetCostCenterSet
      Dim costCenterDataSourceEnd As DataTable = Me.CloneData(costCenterDataSourceStart)
      Me.cmbCostCenterCodeStart.DataSource = costCenterDataSourceStart
      Me.cmbCostCenterCodeEnd.DataSource = costCenterDataSourceEnd


      'Asset Type =======================================
      Me.cmbAssetTypeCodeStart.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbAssetTypeCodeStart.MultiColumnComboBoxElement.DropDownWidth = 300
      Me.cmbAssetTypeCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbAssetTypeCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 300

      'Add Asset Type Columns ==========================
      Dim element_t As Telerik.WinControls.UI.RadMultiColumnComboBoxElement = Me.cmbAssetTypeCodeStart.MultiColumnComboBoxElement
      element_t.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False

      Dim col_t As New Telerik.WinControls.UI.GridViewTextBoxColumn("assettype_code")
      col_t.HeaderText = "รหัส"
      col_t.Width = 100
      col_t.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element_t.Columns.Add(col_t)
      col_t = New Telerik.WinControls.UI.GridViewTextBoxColumn("assettype_name")
      col_t.HeaderText = "ชื่อ"
      col_t.Width = 200
      col_t.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element_t.Columns.Add(col_t)
      For Each Column As Telerik.WinControls.UI.GridViewDataColumn In Me.cmbAssetTypeCodeStart.MultiColumnComboBoxElement.Columns
        cmbAssetTypeCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh Asset Type List
      Dim assetTypeCodeStartDataSource As DataTable = AssetType.GetAssetTypeSet
      Dim assetTypeCodeEndDataSource As DataTable = Me.CloneData(assetTypeCodeStartDataSource)
      Me.cmbAssetTypeCodeStart.DataSource = assetTypeCodeStartDataSource
      Me.cmbAssetTypeCodeEnd.DataSource = assetTypeCodeEndDataSource


      'Asset Type =======================================
      Me.cmbAssetCodeStart.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbAssetCodeStart.MultiColumnComboBoxElement.DropDownWidth = 350
      Me.cmbAssetCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbAssetCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 350

      'Add Asset Type Columns ==========================
      Dim element_a As Telerik.WinControls.UI.RadMultiColumnComboBoxElement = Me.cmbAssetCodeStart.MultiColumnComboBoxElement
      element_a.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False

      Dim col_a As New Telerik.WinControls.UI.GridViewTextBoxColumn("Asset_code")
      col_a.HeaderText = "รหัส"
      col_a.Width = 100
      col_a.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element_a.Columns.Add(col_a)
      col_a = New Telerik.WinControls.UI.GridViewTextBoxColumn("Asset_name")
      col_a.HeaderText = "ชื่อ"
      col_a.Width = 200
      col_a.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element_a.Columns.Add(col_a)
      For Each Column As Telerik.WinControls.UI.GridViewDataColumn In Me.cmbAssetCodeStart.MultiColumnComboBoxElement.Columns
        cmbAssetCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh Asset Type List
      Dim AssetCodeStartDataSource As DataTable = Asset.GetAssetSet
      Dim AssetCodeEndDataSource As DataTable = Me.CloneData(AssetCodeStartDataSource)
      Me.cmbAssetCodeStart.DataSource = AssetCodeStartDataSource
      Me.cmbAssetCodeEnd.DataSource = AssetCodeEndDataSource


    End Sub
    Private Function CloneData(ByVal dataSource As DataTable) As DataTable
      Dim newDt As New DataTable

      For Each col As DataColumn In dataSource.Columns
        newDt.Columns.Add(col.ColumnName)
      Next
      For Each row As DataRow In dataSource.Rows
        Dim dr As DataRow = newDt.NewRow
        For Each col As DataColumn In dataSource.Columns
          dr(col.ColumnName) = row(col.ColumnName)
        Next
        newDt.Rows.Add(dr)
      Next

      Return newDt
    End Function
#End Region

#Region "IReportFilterSubPanel"
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      ''DocDateEnd
      'dpi = New DocPrintingItem
      'dpi.Mapping = "DocDateEnd"
      'dpi.Value = txtDocDateEnd.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()

      'AddHandler btnToCCstart.Click, AddressOf Me.btnCostcenterFind_Click
      'AddHandler btnToCCend.Click, AddressOf Me.btnCostcenterFind_Click

      'AddHandler btnLcistart.Click, AddressOf Me.btnLCIFind_Click
      'AddHandler btnLciend.Click, AddressOf Me.btnLCIFind_Click

      'AddHandler txtToCCstart.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtToCCend.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      'AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      'Select Case CType(sender, Control).Name.ToLower
      '  'Case "txttoccstart"
      '  '  CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      '  'Case "txttoccend"
      '  '  CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

      '  Case "dtpdocdateend"
      '    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
      '      If Not m_dateSetting Then
      '        Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      '        Me.DocDateEnd = dtpDocDateEnd.Value
      '      End If
      '    End If
      '  Case "txtdocdateend"
      '    m_dateSetting = True
      '    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
      '      Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
      '      If Not Me.DocDateEnd.Equals(theDate) Then
      '        dtpDocDateEnd.Value = theDate
      '        Me.DocDateEnd = dtpDocDateEnd.Value
      '      End If
      '    Else
      '      Me.dtpDocDateEnd.Value = Date.Now
      '      Me.DocDateEnd = Date.MinValue
      '    End If
      '    m_dateSetting = False

      '  Case Else

      'End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower

              Case "txttoccstart", "txttoccend"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    'Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
    '  Dim data As IDataObject = Clipboard.GetDataObject
    '  If data.GetDataPresent((New CostCenter).FullClassName) Then
    '    Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
    '    Dim entity As New CostCenter(id)
    '    If Not Me.ActiveControl Is Nothing Then
    '      Select Case Me.ActiveControl.Name.ToLower

    '        Case "txttoccstart"
    '          Me.SetToCCStartDialog(entity)

    '        Case "txttoccend"
    '          Me.SetToCCEndDialog(entity)

    '      End Select
    '    End If
    '  End If
    'End Sub
#End Region

#Region " Event Handlers "
    'Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower

    '    Case "btntoccstart"
    '      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCStartDialog)

    '    Case "btntoccend"
    '      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCEndDialog)

    '  End Select
    'End Sub
    'Private tempTxt As New TextBox
    'Private tempCC1 As New CostCenter
    'Private tempCC2 As New CostCenter
    'Private Sub SetToCCStartDialog(ByVal e As ISimpleEntity)
    '  Me.txtToCCstart.Text = e.Code
    '  CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    'End Sub
    'Private Sub SetToCCEndDialog(ByVal e As ISimpleEntity)
    '  Me.txtToCCend.Text = e.Code
    '  CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    'End Sub

    ' LCI item ..
    'Private Sub btnLCIFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btnlcistart"
    '      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIStartDialog)
    '    Case "btnlciend"
    '      myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCIEndDialog)
    '  End Select

    'End Sub

    'Private Sub SetLCIStartDialog(ByVal e As ISimpleEntity)
    '  Me.txtLcistart.Text = e.Code
    'End Sub
    'Private Sub SetLCIEndDialog(ByVal e As ISimpleEntity)
    '  Me.txtLciend.Text = e.Code
    'End Sub
#End Region

  End Class

  '    ' เรียงตาม 
  '    Public Class RptMatReturnFilterOrderBy
  '        Inherits CodeDescription

  '#Region "Construtors"
  '        Public Sub New(ByVal value As Integer)
  '            MyBase.New(value)
  '        End Sub
  '#End Region

  '#Region "Properties"
  '        Public Overrides ReadOnly Property CodeName() As String
  '            Get
  '                Return "rpt_matreturn"
  '            End Get
  '        End Property
  '#End Region

  '    End Class
End Namespace

