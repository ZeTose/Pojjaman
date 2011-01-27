Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports Telerik.WinControls
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptEstimateMilestoneFilterSubPanel
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
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
    Friend WithEvents cmbCustCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbCustCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents btnCustEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCustEnd As System.Windows.Forms.Label
    Friend WithEvents btnCustStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCustStart As System.Windows.Forms.Label
    Friend WithEvents btnCCEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents cmbCostCenterCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbCostCenterCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents lblCCEnd As System.Windows.Forms.Label
    Friend WithEvents RadThemeManager1 As Telerik.WinControls.RadThemeManager
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadMultiColumnComboBox1 As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents rbBillDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbHandedDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbMiDocdate As System.Windows.Forms.RadioButton
    Friend WithEvents grbValueType As System.Windows.Forms.GroupBox
    Friend WithEvents rbGross As System.Windows.Forms.RadioButton
    Friend WithEvents rbWOAdvRet As System.Windows.Forms.RadioButton
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptEstimateMilestoneFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.rbBillDate = New System.Windows.Forms.RadioButton()
      Me.rbHandedDate = New System.Windows.Forms.RadioButton()
      Me.rbMiDocdate = New System.Windows.Forms.RadioButton()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbPeriod = New System.Windows.Forms.ComboBox()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.cmbCostCenterCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbCostCenterCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbCustCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.RadMultiColumnComboBox1 = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbCustCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.btnCustEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCCEnd = New System.Windows.Forms.Label()
      Me.lblCustEnd = New System.Windows.Forms.Label()
      Me.btnCustStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCustStart = New System.Windows.Forms.Label()
      Me.btnCCEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.RadThemeManager1 = New Telerik.WinControls.RadThemeManager()
      Me.grbValueType = New System.Windows.Forms.GroupBox()
      Me.rbGross = New System.Windows.Forms.RadioButton()
      Me.rbWOAdvRet = New System.Windows.Forms.RadioButton()
      Me.grbMaster.SuspendLayout()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbCustCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.cmbCustCodeEnd.SuspendLayout()
      CType(Me.RadMultiColumnComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbCustCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbValueType.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Controls.Add(Me.rbBillDate)
      Me.grbMaster.Controls.Add(Me.rbHandedDate)
      Me.grbMaster.Controls.Add(Me.rbMiDocdate)
      Me.grbMaster.Controls.Add(Me.Label1)
      Me.grbMaster.Controls.Add(Me.cmbPeriod)
      Me.grbMaster.Controls.Add(Me.txtDocDateEnd)
      Me.grbMaster.Controls.Add(Me.txtDocDateStart)
      Me.grbMaster.Controls.Add(Me.dtpDocDateStart)
      Me.grbMaster.Controls.Add(Me.dtpDocDateEnd)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeStart)
      Me.grbMaster.Controls.Add(Me.cmbCustCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbCustCodeStart)
      Me.grbMaster.Controls.Add(Me.btnCustEndFind)
      Me.grbMaster.Controls.Add(Me.lblCCEnd)
      Me.grbMaster.Controls.Add(Me.lblCustEnd)
      Me.grbMaster.Controls.Add(Me.btnCustStartFind)
      Me.grbMaster.Controls.Add(Me.lblCustStart)
      Me.grbMaster.Controls.Add(Me.btnCCEndFind)
      Me.grbMaster.Controls.Add(Me.btnCCStartFind)
      Me.grbMaster.Controls.Add(Me.lblCCStart)
      Me.grbMaster.Controls.Add(Me.lblDocDateStart)
      Me.grbMaster.Controls.Add(Me.lblDocDateEnd)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 3)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(412, 149)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "ค้นหา"
      '
      'rbBillDate
      '
      Me.rbBillDate.AutoSize = True
      Me.rbBillDate.Location = New System.Drawing.Point(80, 122)
      Me.rbBillDate.Name = "rbBillDate"
      Me.rbBillDate.Size = New System.Drawing.Size(74, 17)
      Me.rbBillDate.TabIndex = 83
      Me.rbBillDate.TabStop = True
      Me.rbBillDate.Text = "วันที่วางบิล"
      Me.rbBillDate.UseVisualStyleBackColor = True
      '
      'rbHandedDate
      '
      Me.rbHandedDate.AutoSize = True
      Me.rbHandedDate.Location = New System.Drawing.Point(80, 104)
      Me.rbHandedDate.Name = "rbHandedDate"
      Me.rbHandedDate.Size = New System.Drawing.Size(74, 17)
      Me.rbHandedDate.TabIndex = 82
      Me.rbHandedDate.TabStop = True
      Me.rbHandedDate.Text = "วันที่ส่งงาน"
      Me.rbHandedDate.UseVisualStyleBackColor = True
      '
      'rbMiDocdate
      '
      Me.rbMiDocdate.AutoSize = True
      Me.rbMiDocdate.Location = New System.Drawing.Point(80, 86)
      Me.rbMiDocdate.Name = "rbMiDocdate"
      Me.rbMiDocdate.Size = New System.Drawing.Size(79, 17)
      Me.rbMiDocdate.TabIndex = 81
      Me.rbMiDocdate.TabStop = True
      Me.rbMiDocdate.Text = "วันที่งวดงาน"
      Me.rbMiDocdate.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(219, 86)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(44, 18)
      Me.Label1.TabIndex = 80
      Me.Label1.Text = "ช่วง"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbPeriod
      '
      Me.cmbPeriod.FormattingEnabled = True
      Me.cmbPeriod.Items.AddRange(New Object() {"Week", "Month", "Quarter"})
      Me.cmbPeriod.Location = New System.Drawing.Point(266, 85)
      Me.cmbPeriod.Name = "cmbPeriod"
      Me.cmbPeriod.Size = New System.Drawing.Size(127, 21)
      Me.cmbPeriod.TabIndex = 79
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(266, 60)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 73
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(96, 61)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(92, 21)
      Me.txtDocDateStart.TabIndex = 71
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(96, 61)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 72
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(273, 60)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 74
      Me.dtpDocDateEnd.TabStop = False
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
      Me.cmbCostCenterCodeEnd.Location = New System.Drawing.Point(266, 36)
      Me.cmbCostCenterCodeEnd.Name = "cmbCostCenterCodeEnd"
      '
      '
      '
      Me.cmbCostCenterCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeEnd.Size = New System.Drawing.Size(107, 21)
      Me.cmbCostCenterCodeEnd.TabIndex = 7
      Me.cmbCostCenterCodeEnd.TabStop = False
      Me.cmbCostCenterCodeEnd.Text = "RadMultiColumnComboBox6"
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
      Me.cmbCostCenterCodeStart.Location = New System.Drawing.Point(98, 37)
      Me.cmbCostCenterCodeStart.Name = "cmbCostCenterCodeStart"
      '
      '
      '
      Me.cmbCostCenterCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeStart.Size = New System.Drawing.Size(120, 21)
      Me.cmbCostCenterCodeStart.TabIndex = 6
      Me.cmbCostCenterCodeStart.TabStop = False
      Me.cmbCostCenterCodeStart.Text = "RadMultiColumnComboBox5"
      '
      'cmbCustCodeEnd
      '
      Me.cmbCustCodeEnd.Controls.Add(Me.RadMultiColumnComboBox1)
      '
      'cmbCustCodeEnd.NestedRadGridView
      '
      Me.cmbCustCodeEnd.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbCustCodeEnd.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCustCodeEnd.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbCustCodeEnd.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbCustCodeEnd.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbCustCodeEnd.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbCustCodeEnd.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbCustCodeEnd.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbCustCodeEnd.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbCustCodeEnd.EditorControl.Name = "NestedRadGridView"
      Me.cmbCustCodeEnd.EditorControl.ReadOnly = True
      Me.cmbCustCodeEnd.EditorControl.ShowGroupPanel = False
      Me.cmbCustCodeEnd.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbCustCodeEnd.EditorControl.TabIndex = 0
      Me.cmbCustCodeEnd.Location = New System.Drawing.Point(266, 12)
      Me.cmbCustCodeEnd.Name = "cmbCustCodeEnd"
      '
      '
      '
      Me.cmbCustCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCustCodeEnd.Size = New System.Drawing.Size(107, 21)
      Me.cmbCustCodeEnd.TabIndex = 5
      Me.cmbCustCodeEnd.TabStop = False
      Me.cmbCustCodeEnd.Text = "RadMultiColumnComboBox4"
      '
      'RadMultiColumnComboBox1
      '
      '
      'RadMultiColumnComboBox1.NestedRadGridView
      '
      Me.RadMultiColumnComboBox1.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.RadMultiColumnComboBox1.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.RadMultiColumnComboBox1.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.RadMultiColumnComboBox1.EditorControl.Location = New System.Drawing.Point(-133, -65)
      '
      '
      '
      Me.RadMultiColumnComboBox1.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.RadMultiColumnComboBox1.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.RadMultiColumnComboBox1.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.RadMultiColumnComboBox1.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.RadMultiColumnComboBox1.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.RadMultiColumnComboBox1.EditorControl.Name = "NestedRadGridView"
      Me.RadMultiColumnComboBox1.EditorControl.ReadOnly = True
      Me.RadMultiColumnComboBox1.EditorControl.ShowGroupPanel = False
      Me.RadMultiColumnComboBox1.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.RadMultiColumnComboBox1.EditorControl.TabIndex = 6
      Me.RadMultiColumnComboBox1.EditorControl.Visible = False
      Me.RadMultiColumnComboBox1.Location = New System.Drawing.Point(133, -53)
      Me.RadMultiColumnComboBox1.Name = "RadMultiColumnComboBox1"
      '
      '
      '
      Me.RadMultiColumnComboBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.RadMultiColumnComboBox1.Size = New System.Drawing.Size(107, 21)
      Me.RadMultiColumnComboBox1.TabIndex = 7
      Me.RadMultiColumnComboBox1.TabStop = False
      Me.RadMultiColumnComboBox1.Text = "RadMultiColumnComboBox4"
      '
      'cmbCustCodeStart
      '
      '
      'cmbCustCodeStart.NestedRadGridView
      '
      Me.cmbCustCodeStart.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbCustCodeStart.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCustCodeStart.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbCustCodeStart.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbCustCodeStart.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbCustCodeStart.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbCustCodeStart.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbCustCodeStart.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbCustCodeStart.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbCustCodeStart.EditorControl.Name = "NestedRadGridView"
      Me.cmbCustCodeStart.EditorControl.ReadOnly = True
      Me.cmbCustCodeStart.EditorControl.ShowGroupPanel = False
      Me.cmbCustCodeStart.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbCustCodeStart.EditorControl.TabIndex = 0
      Me.cmbCustCodeStart.Location = New System.Drawing.Point(98, 13)
      Me.cmbCustCodeStart.Name = "cmbCustCodeStart"
      '
      '
      '
      Me.cmbCustCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCustCodeStart.Size = New System.Drawing.Size(120, 21)
      Me.cmbCustCodeStart.TabIndex = 4
      Me.cmbCustCodeStart.TabStop = False
      Me.cmbCustCodeStart.Text = "RadMultiColumnComboBox3"
      '
      'btnCustEndFind
      '
      Me.btnCustEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCustEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCustEndFind.Location = New System.Drawing.Point(372, 12)
      Me.btnCustEndFind.Name = "btnCustEndFind"
      Me.btnCustEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCustEndFind.TabIndex = 70
      Me.btnCustEndFind.TabStop = False
      Me.btnCustEndFind.ThemedImage = CType(resources.GetObject("btnCustEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCCEnd
      '
      Me.lblCCEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCCEnd.Location = New System.Drawing.Point(245, 37)
      Me.lblCCEnd.Name = "lblCCEnd"
      Me.lblCCEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCCEnd.TabIndex = 69
      Me.lblCCEnd.Text = "ถึง"
      Me.lblCCEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblCustEnd
      '
      Me.lblCustEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustEnd.ForeColor = System.Drawing.Color.Black
      Me.lblCustEnd.Location = New System.Drawing.Point(245, 12)
      Me.lblCustEnd.Name = "lblCustEnd"
      Me.lblCustEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblCustEnd.TabIndex = 69
      Me.lblCustEnd.Text = "ถึง"
      Me.lblCustEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnCustStartFind
      '
      Me.btnCustStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCustStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCustStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCustStartFind.Location = New System.Drawing.Point(219, 12)
      Me.btnCustStartFind.Name = "btnCustStartFind"
      Me.btnCustStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCustStartFind.TabIndex = 68
      Me.btnCustStartFind.TabStop = False
      Me.btnCustStartFind.ThemedImage = CType(resources.GetObject("btnCustStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCustStart
      '
      Me.lblCustStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustStart.ForeColor = System.Drawing.Color.Black
      Me.lblCustStart.Location = New System.Drawing.Point(6, 17)
      Me.lblCustStart.Name = "lblCustStart"
      Me.lblCustStart.Size = New System.Drawing.Size(88, 18)
      Me.lblCustStart.TabIndex = 67
      Me.lblCustStart.Text = "ตั้งแต่ลูกค้า"
      Me.lblCustStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCCEndFind
      '
      Me.btnCCEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCEndFind.Location = New System.Drawing.Point(372, 36)
      Me.btnCCEndFind.Name = "btnCCEndFind"
      Me.btnCCEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCEndFind.TabIndex = 63
      Me.btnCCEndFind.TabStop = False
      Me.btnCCEndFind.ThemedImage = CType(resources.GetObject("btnCCEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCStartFind
      '
      Me.btnCCStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCStartFind.Location = New System.Drawing.Point(219, 36)
      Me.btnCCStartFind.Name = "btnCCStartFind"
      Me.btnCCStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCStartFind.TabIndex = 53
      Me.btnCCStartFind.TabStop = False
      Me.btnCCStartFind.ThemedImage = CType(resources.GetObject("btnCCStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(9, 40)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(83, 18)
      Me.lblCCStart.TabIndex = 50
      Me.lblCCStart.Text = "CostCenter เจ้าของ"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateStart
      '
      Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateStart.Location = New System.Drawing.Point(4, 61)
      Me.lblDocDateStart.Name = "lblDocDateStart"
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 43
      Me.lblDocDateStart.Text = "ตั้งแต่"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(243, 61)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblDocDateEnd.TabIndex = 44
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(528, 129)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 9
      Me.btnSearch.Text = "ค้นหา"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(447, 129)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 8
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
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
      'grbValueType
      '
      Me.grbValueType.Controls.Add(Me.rbGross)
      Me.grbValueType.Controls.Add(Me.rbWOAdvRet)
      Me.grbValueType.Location = New System.Drawing.Point(427, 4)
      Me.grbValueType.Name = "grbValueType"
      Me.grbValueType.Size = New System.Drawing.Size(186, 105)
      Me.grbValueType.TabIndex = 10
      Me.grbValueType.TabStop = False
      Me.grbValueType.Text = "แสดงมูลค่า"
      '
      'rbGross
      '
      Me.rbGross.AutoSize = True
      Me.rbGross.Location = New System.Drawing.Point(30, 46)
      Me.rbGross.Name = "rbGross"
      Me.rbGross.Size = New System.Drawing.Size(52, 17)
      Me.rbGross.TabIndex = 1
      Me.rbGross.TabStop = True
      Me.rbGross.Text = "Gross"
      Me.rbGross.UseVisualStyleBackColor = True
      '
      'rbWOAdvRet
      '
      Me.rbWOAdvRet.AutoSize = True
      Me.rbWOAdvRet.Location = New System.Drawing.Point(30, 23)
      Me.rbWOAdvRet.Name = "rbWOAdvRet"
      Me.rbWOAdvRet.Size = New System.Drawing.Size(112, 17)
      Me.rbWOAdvRet.TabIndex = 0
      Me.rbWOAdvRet.TabStop = True
      Me.rbWOAdvRet.Text = "W/O Adv and Ret"
      Me.rbWOAdvRet.UseVisualStyleBackColor = True
      '
      'RptEstimateMilestoneFilterSubPanel
      '
      Me.Controls.Add(Me.grbValueType)
      Me.Controls.Add(Me.grbMaster)
      Me.Controls.Add(Me.btnSearch)
      Me.Controls.Add(Me.btnReset)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptEstimateMilestoneFilterSubPanel"
      Me.Size = New System.Drawing.Size(616, 164)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbCustCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      Me.cmbCustCodeEnd.ResumeLayout(False)
      Me.cmbCustCodeEnd.PerformLayout()
      CType(Me.RadMultiColumnComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbCustCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbValueType.ResumeLayout(False)
      Me.grbValueType.PerformLayout()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText
      'Me.lblEQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.EquipmentCode}")
      'Me.Validator.SetDisplayName(txtEQCodeStart, lblEQCode.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryByCCFilterSubPanel.lblDocDateStart}")
      Me.lblCustStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryByCCFilterSubPanel.lblAcctBookStart}")
      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryByCCFilterSubPanel.lblCCStart}")
      'Me.Validator.SetDisplayName(dtpDocDateStart, lblDocDateStart.Text)

      'Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryByCCFilterSubPanel.lblCC}")
      'Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {ถึง}
      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(dtpDocDateEnd, lblDocDateEnd.Text)

      Me.lblCustEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.lblCCEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

      'Me.Validator.SetDisplayName(cmbA, lblAccountEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptJournalEntryByCCFilterSubPanel.grbMaster}")
    End Sub
#End Region

#Region "Member"
    'Private m_equipmentstart As EquipmentItem
    'Private m_equipmentend As EquipmentItem
    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date
    'Private m_cc As CostCenter
    'Private m_acctDataSourceStart As DataTable
    'Private m_acctBookDataSourceStart As DataTable
    'Private m_costCenterDataSourceStart As DataTable

    'Dim m_hashControlState As New Hashtable
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
    'Public Property AcctDataSourceStart As DataTable
    '  Get
    '    Return m_acctDataSourceStart
    '  End Get
    '  Set(ByVal value As DataTable)
    '    m_acctDataSourceStart = value
    '  End Set
    'End Property
    'Public Property AcctBookDataSourceStart As DataTable
    '  Get
    '    Return m_acctBookDataSourceStart
    '  End Get
    '  Set(ByVal value As DataTable)
    '    m_acctBookDataSourceStart = value
    '  End Set
    'End Property
    'Public Property CostCenterDataSourceStart As DataTable
    '  Get
    '    Return m_costCenterDataSourceStart
    '  End Get
    '  Set(ByVal value As DataTable)
    '    m_costCenterDataSourceStart = value
    '  End Set
    'End Property
    'Public Property Equipmentstart() As EquipmentItem
    '  Get
    '    Return m_equipmentstart
    '  End Get
    '  Set(ByVal Value As EquipmentItem)
    '    m_equipmentstart = Value
    '  End Set
    'End Property
    'Public Property EquipmentEnd() As EquipmentItem
    '  Get
    '    Return m_equipmentend
    '  End Get
    '  Set(ByVal Value As EquipmentItem)
    '    m_equipmentend = Value
    '  End Set
    'End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

    'Public Property CostCenter() As CostCenter
    '  Get
    '    Return m_cc
    '  End Get
    '  Set(ByVal Value As CostCenter)
    '    m_cc = Value
    '  End Set
    'End Property
#End Region

#Region "Methods"

    Private Sub Initialize()

      InitialMultiCombo()
      ClearCriterias()

      'Me.cmbAccountCodeStart.MultiColumnComboBoxElement.ShowPopup()
      'Me.cmbAccountCodeStart.AutoFilter = True
    End Sub
    'Private Sub SetAutoCompleteAble(ByVal ctl As Control, ByVal autocomplete As Boolean)
    '  If TypeOf ctl Is RadMultiColumnComboBox Then
    '    Dim rcbl As RadMultiColumnComboBox = CType(ctl, RadMultiColumnComboBox)
    '    rcbl.AutoFilter = autocomplete
    '    rcbl.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.None
    '    If autocomplete Then
    '      rcbl.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.Append
    '      'rcbl.MultiColumnComboBoxElement.ShowPopup()
    '    End If
    '  End If
    'End Sub
    Private Sub InitialMultiCombo()


      Me.cmbCustCodeStart.MultiColumnComboBoxElement.DropDownHeight = 200
      Me.cmbCustCodeStart.MultiColumnComboBoxElement.DropDownWidth = 400
      Me.cmbCustCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 200
      Me.cmbCustCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 400

      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownWidth = 350
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 350

      'Add Account Columns ==========================


      'Add AccountBook Columns ==========================
      Dim element As RadMultiColumnComboBoxElement = Me.cmbCustCodeStart.MultiColumnComboBoxElement
      element.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False
      Dim col As New GridViewTextBoxColumn("cust_code")
      col.HeaderText = "รหัส"
      col.Width = 100
      col.TextAlignment = Left
      element.Columns.Add(col)
      col = New GridViewTextBoxColumn("cust_name")
      col.HeaderText = "ชื่อ"
      col.Width = 200
      col.TextAlignment = Left
      element.Columns.Add(col)

      For Each Column As GridViewDataColumn In Me.cmbCustCodeStart.MultiColumnComboBoxElement.Columns
        cmbCustCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh Account Book List
      Dim CustDataSourceStart As DataTable = Customer.GetDTCustomer
      Dim CustDataSourceEnd As DataTable = Me.CloneData(CustDataSourceStart)
      Me.cmbCustCodeStart.DataSource = CustDataSourceStart
      Me.cmbCustCodeEnd.DataSource = CustDataSourceEnd

      'Add CostCenter Columns ==========================
      element = Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement
      element.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False
      col = New GridViewTextBoxColumn("cc_code")
      col.HeaderText = "รหัส"
      col.Width = 100
      col.TextAlignment = Left
      element.Columns.Add(col)
      col = New GridViewTextBoxColumn("cc_name")
      col.HeaderText = "ชื่อ"
      col.Width = 200
      col.TextAlignment = Left
      element.Columns.Add(col)
      For Each Column As GridViewDataColumn In Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.Columns
        cmbCostCenterCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh CostCenter List
      Dim costCenterDataSourceStart As DataTable = CostCenter.GetCostCenterSet
      Dim costCenterDataSourceEnd As DataTable = Me.CloneData(costCenterDataSourceStart)
      Me.cmbCostCenterCodeStart.DataSource = costCenterDataSourceStart
      Me.cmbCostCenterCodeEnd.DataSource = costCenterDataSourceEnd

      'Filter, Auto Complete ============================================================================================================== 2
      'Me.cmbAccountCodeStart.AutoFilter = True
      'Me.cmbAccountCodeStart.DisplayMember = "acct_code"
      'Dim filter As New FilterExpression(Me.cmbAccountCodeStart.DisplayMember,
      '                                   FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      'filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)
      'Me.cmbAccountCodeStart.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      'Me.cmbAccountCodeStart.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.SuggestAppend
      ''Me.cmbAccountCodeStart.DropDownStyle = RadDropDownStyle.DropDown
      ''Me.SetAutoCompleteAble(cmbAccountCodeStart, False)

      'Me.cmbAccountCodeEnd.AutoFilter = True
      'Me.cmbAccountCodeEnd.DisplayMember = "acct_code"
      'filter = New FilterExpression(Me.cmbAccountCodeEnd.DisplayMember,
      '                                   FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      'filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)
      'Me.cmbAccountCodeEnd.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      'Me.cmbAccountCodeEnd.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.None
      'Me.cmbAccountCodeEnd.DropDownStyle = RadDropDownStyle.DropDown
      ''Me.SetAutoCompleteAble(cmbAccountCodeEnd, False)

      'Me.cmbAccountBookCodeStart.AutoFilter = True
      'Me.cmbAccountBookCodeStart.DisplayMember = "accountbook_code"
      'filter = New FilterExpression(Me.cmbAccountBookCodeStart.DisplayMember,
      '                                   FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      'filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)
      'Me.cmbAccountBookCodeStart.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      'Me.cmbAccountBookCodeStart.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.None
      'Me.cmbAccountBookCodeStart.DropDownStyle = RadDropDownStyle.DropDown
      ''Me.SetAutoCompleteAble(cmbAccountBookCodeStart, False)

      'Me.cmbAccountBookCodeEnd.AutoFilter = True
      'Me.cmbAccountBookCodeEnd.DisplayMember = "accountbook_code"
      'filter = New FilterExpression(Me.cmbAccountBookCodeEnd.DisplayMember,
      '                                   FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      'filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)
      'Me.cmbAccountBookCodeEnd.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      'Me.cmbAccountBookCodeEnd.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.None
      'Me.cmbAccountBookCodeEnd.DropDownStyle = RadDropDownStyle.DropDown
      ''Me.SetAutoCompleteAble(cmbAccountBookCodeEnd, False)

      ''Me.cmbCostCenterCodeStart.AutoFilter = True
      'Me.cmbCostCenterCodeStart.DisplayMember = "cc_code"
      'filter = New FilterExpression(Me.cmbCostCenterCodeStart.DisplayMember,
      '                                   FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      'filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)
      'Me.cmbCostCenterCodeStart.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      'Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.None
      'Me.cmbCostCenterCodeStart.DropDownStyle = RadDropDownStyle.DropDown
      ''Me.SetAutoCompleteAble(cmbCostCenterCodeStart, False)

      ''Me.cmbCostCenterCodeEnd.AutoFilter = True
      'Me.cmbCostCenterCodeEnd.DisplayMember = "cc_code"
      'filter = New FilterExpression(Me.cmbCostCenterCodeEnd.DisplayMember,
      '                                  FilterExpression.BinaryOperation.AND, GridKnownFunction.StartsWith, GridFilterCellElement.ParameterName)
      'filter.Parameters.Add(GridFilterCellElement.ParameterName, String.Empty)
      'Me.cmbCostCenterCodeEnd.EditorControl.MasterGridViewTemplate.FilterExpressions.Add(filter)
      'Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.None
      'Me.cmbCostCenterCodeEnd.DropDownStyle = RadDropDownStyle.DropDown
      'Me.SetAutoCompleteAble(cmbCostCenterCodeEnd, False)
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
    Private Sub ClearCriterias()
      'For Each grbCtrl As Control In grbMaster.Controls
      '  If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then

      '  End If
      '  If TypeOf grbCtrl Is RadMultiColumnComboBox Then
      '    SetAllRadMultiComboBoxFilter(grbCtrl)
      '  ElseIf TypeOf grbCtrl Is RadDateTimePicker Then
      '    CType(grbCtrl, RadDateTimePicker).SetToNullValue()
      '  ElseIf TypeOf grbCtrl Is TextBox Then
      '    grbCtrl.Text = ""
      '  End If
      '  For Each Ctrl As Control In grbCtrl.Controls
      '    If TypeOf Ctrl Is TextBox Then
      '      Ctrl.Text = ""
      '    ElseIf TypeOf Ctrl Is RadMultiColumnComboBox Then
      '      Ctrl.Text = ""
      '      SetAllRadMultiComboBoxFilter(Ctrl)
      '      'm_hashControlState(Ctrl.Name) = RadMultiComboBox.DropDownClosed
      '    ElseIf TypeOf Ctrl Is RadDateTimePicker Then
      '      CType(Ctrl, RadDateTimePicker).SetToNullValue()
      '    End If
      '  Next
      'Next
      Me.cmbCustCodeStart.Text = ""
      Me.cmbCustCodeEnd.Text = ""
      Me.cmbCostCenterCodeStart.Text = ""
      Me.cmbCostCenterCodeEnd.Text = ""
      Me.rbMiDocdate.Checked = True
      Me.rbGross.Checked = True
      Me.cmbPeriod.SelectedIndex = 1
      'Me.CostCenter = New CostCenter

      'Me.Equipmentstart = New EquipmentItem
      'Me.EquipmentEnd = New EquipmentItem

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.dtpDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.dtpDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

    End Sub
    Public Overrides Function GetFilterString() As String

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
    Private Enum DataType
      MileStoneDocdate
      HandedDate
      BillDate
    End Enum

    Private Enum ValueType
      WOAdvRet
      Gross
    End Enum


    Private Function GetValueType() As Integer
      If rbWOAdvRet.Checked Then
        Return ValueType.WOAdvRet
      End If
      If rbGross.Checked Then
        Return ValueType.Gross
      End If
      Return ValueType.Gross
    End Function
    Private Function GetDateType() As Integer

      If rbMiDocdate.Checked Then
        Return DataType.MileStoneDocdate
      End If
      If rbHandedDate.Checked Then
        Return DataType.HandedDate
      End If
      If rbBillDate.Checked Then
        Return DataType.BillDate
      End If
      Return DataType.MileStoneDocdate
    End Function
    Private Function GetPeriod() As Integer
      Select Case Me.cmbPeriod.SelectedItem.ToString.ToLower
        Case "week"
          Return DateInterval.WeekOfYear
        Case "month"
          Return DateInterval.Month
        Case "quarter"
          Return DateInterval.Quarter
        Case Else
          Return DateInterval.Month
      End Select
    End Function
    Public Overrides Function GetFilterArray() As Longkong.Pojjaman.BusinessLogic.Filter()
      Dim arr(8) As Pojjaman.BusinessLogic.Filter

      arr(0) = New Longkong.Pojjaman.BusinessLogic.Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Longkong.Pojjaman.BusinessLogic.Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Longkong.Pojjaman.BusinessLogic.Filter("DateType", GetDateType)
      arr(3) = New Longkong.Pojjaman.BusinessLogic.Filter("Period", GetPeriod)
      arr(4) = New Longkong.Pojjaman.BusinessLogic.Filter("ValueType", GetValueType)
      arr(5) = New Longkong.Pojjaman.BusinessLogic.Filter("CustCodeStart", ValidCodeOrDBNullText(Me.cmbCustCodeStart))
      arr(6) = New Longkong.Pojjaman.BusinessLogic.Filter("CustCodeEnd", ValidCodeOrDBNullText(Me.cmbCustCodeEnd))
      arr(7) = New Longkong.Pojjaman.BusinessLogic.Filter("CCCodeStart", ValidCodeOrDBNullText(Me.cmbCostCenterCodeStart))
      arr(8) = New Longkong.Pojjaman.BusinessLogic.Filter("CCCodeEnd", ValidCodeOrDBNullText(Me.cmbCostCenterCodeEnd))

      Return arr


      'Dim arr(19) As Filter
      'arr(0) = New Filter("OpenningDocDateStart", DBNull.Value)
      'arr(1) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      'arr(2) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      'arr(3) = New Filter("AcctCodeStart", IIf(txtAcctCodeStart.TextLength > 0, txtAcctCodeStart.Text, DBNull.Value))
      'arr(4) = New Filter("AcctCodeEnd", IIf(txtAcctCodeEnd.TextLength > 0, txtAcctCodeEnd.Text, DBNull.Value))
      'arr(5) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
      'arr(6) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
      'arr(7) = New Filter("Format", JournalEntryFilterOrderBy.GetValue("rpt_journalentryfilter", cmbFormat.Text))
      'arr(8) = New Filter("OnlyPosted", Me.chkOnlyPosted.Checked)
      'arr(9) = New Filter("AcctBookCodeStart", IIf(txtAcctBookStart.TextLength > 0, txtAcctBookStart.Text, DBNull.Value))
      'arr(10) = New Filter("AcctBookCodeEnd", IIf(txtAcctBookEnd.TextLength > 0, txtAcctBookEnd.Text, DBNull.Value))
      'arr(11) = New Filter("PVCodeStart", IIf(txtPVCodeStart.TextLength > 0, txtPVCodeStart.Text, DBNull.Value))
      'arr(12) = New Filter("PVCodeEnd", IIf(txtPVCodeEnd.TextLength > 0, txtPVCodeEnd.Text, DBNull.Value))
      'arr(13) = New Filter("RVCodeStart", IIf(txtRVCodeStart.TextLength > 0, txtRVCodeStart.Text, DBNull.Value))
      'arr(14) = New Filter("RVCodeEnd", IIf(txtRVCodeEnd.TextLength > 0, txtRVCodeEnd.Text, DBNull.Value))
      'arr(15) = New Filter("ShowSumEachAcct", Me.chkShowSumEachAcct.Checked)
      'arr(16) = New Filter("ComputeDrCr", Me.chkComputeDrCr.Checked)
      'arr(17) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      'arr(18) = New Filter("AcctBookCodeprefix", IIf(txtAcctBookCodeprefix.TextLength > 0, txtAcctBookCodeprefix.Text, DBNull.Value))
      'arr(19) = New Filter("RefDocCodePrefix", IIf(txtRefDocCodePrefix.TextLength > 0, txtRefDocCodePrefix.Text, DBNull.Value))

      'Return arr
    End Function
    Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
      Get
        Return Me.btnSearch
      End Get
    End Property

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
      ClearCriterias()
      Me.btnSearch.PerformClick()
    End Sub
#End Region

#Region " IReportFilterSubPanel "
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      'Docdate Start
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateStart"
      dpi.Value = Me.dtpDocDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Docdate End
      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      dpi.Value = Me.dtpDocDateEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''AccountStart
      'dpi = New DocPrintingItem
      'dpi.Mapping = "AccountStart"
      'dpi.Value = cmbAccountCodeStart.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''AccountEnd
      'dpi = New DocPrintingItem
      'dpi.Mapping = "AccountEnd"
      'dpi.Value = cmbAccountCodeEnd.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'AccountBookStart
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountBookStart"
      dpi.Value = cmbCustCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'AccountBookEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "AccountBookEnd"
      dpi.Value = cmbCustCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "CostcenterStart"
      dpi.Value = cmbCostCenterCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'CostCenterEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterEnd"
      dpi.Value = cmbCostCenterCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()


      AddHandler btnCustStartFind.Click, AddressOf Me.btnAccountBookFind_Click
      AddHandler btnCustEndFind.Click, AddressOf Me.btnAccountBookFind_Click

      AddHandler btnCCStartFind.Click, AddressOf Me.btnCCFind_Click
      AddHandler btnCCEndFind.Click, AddressOf Me.btnCCFind_Click


      'AddHandler 
      'AddHandler cmbAccountCodeStart.DropDownOpening, AddressOf Me.radMultiComboBox_DropDownOpening
      'AddHandler cmbAccountCodeStart.TextChanged, AddressOf Me.radMultiComboBox_TextChanged

      'AddHandler cmbAccountCodeEnd.DropDownOpening, AddressOf Me.radMultiComboBox_DropDownOpening
      'AddHandler cmbAccountCodeEnd.TextChanged, AddressOf Me.radMultiComboBox_TextChanged

      'AddHandler cmbAccountBookCodeStart.DropDownOpening, AddressOf Me.radMultiComboBox_DropDownOpening
      'AddHandler cmbAccountBookCodeStart.TextChanged, AddressOf Me.radMultiComboBox_TextChanged

      'AddHandler cmbAccountBookCodeEnd.DropDownOpening, AddressOf Me.radMultiComboBox_DropDownOpening
      'AddHandler cmbAccountBookCodeEnd.TextChanged, AddressOf Me.radMultiComboBox_TextChanged

      'AddHandler cmbCostCenterCodeStart.DropDownOpening, AddressOf Me.radMultiComboBox_DropDownOpening
      'AddHandler cmbCostCenterCodeStart.TextChanged, AddressOf Me.radMultiComboBox_TextChanged

      'AddHandler cmbCostCenterCodeEnd.DropDownOpening, AddressOf Me.radMultiComboBox_DropDownOpening
      'AddHandler cmbCostCenterCodeEnd.TextChanged, AddressOf Me.radMultiComboBox_TextChanged

      'AddHandler dtpDocDateStart.KeyDown, AddressOf Me.RadDateTimePicker_KeyDown
      'AddHandler dtpDocDateEnd.KeyDown, AddressOf Me.RadDateTimePicker_KeyDown

      'AddHandler cmbCostCenterCodeStart.Validated, AddressOf Me.ChangeProperty
      'AddHandler cmbCostCenterCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          'CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "dtpdocdatestart"
          If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          End If
        Case "txtdocdatestart"
          m_dateSetting = True
          If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
            If Not Me.DocDateStart.Equals(theDate) Then
              dtpDocDateStart.Value = theDate
              Me.DocDateStart = dtpDocDateStart.Value
            End If
          Else
            Me.dtpDocDateStart.Value = Date.Now
            Me.DocDateStart = Date.MinValue
          End If
          m_dateSetting = False

        Case "dtpdocdateend"
          If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          End If
        Case "txtdocdateend"
          m_dateSetting = True
          If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
            If Not Me.DocDateEnd.Equals(theDate) Then
              dtpDocDateEnd.Value = theDate
              Me.DocDateEnd = dtpDocDateEnd.Value
            End If
          Else
            Me.dtpDocDateEnd.Value = Date.Now
            Me.DocDateEnd = Date.MinValue
          End If
          m_dateSetting = False

        Case Else

      End Select
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtEQcodestart", "txtEQcodeend"
                Return True
            End Select
          End If
        End If
        ' CostCenter
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtEQcodestart"
              'Me.SetEQStartDialog(entity)

            Case "txtEQcodeend"
              'Me.SetEQEndDialog(entity)

          End Select
        End If
      End If
      ' CostCenter
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccstartfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
        Case "btnccendfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeEndDialog)
      End Select
    End Sub

    Private Sub btnAccountBookFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btncuststartfind"
          myEntityPanelService.OpenListDialog(New Customer, AddressOf SetcustomerStartDialog)

        Case "btncustendfind"
          myEntityPanelService.OpenListDialog(New Customer, AddressOf SetcustomerEndDialog)

      End Select
    End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      Me.cmbCostCenterCodeStart.Text = e.Code
      'CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub SetCCCodeEndDialog(ByVal e As ISimpleEntity)
      Me.cmbCostCenterCodeEnd.Text = e.Code
      'CostCenter.GetCostCenter(txtCCCodeStart, txtTemp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub

    Private Sub SetcustomerStartDialog(ByVal e As ISimpleEntity)
      Me.cmbCustCodeStart.Text = e.Code
      'Customer.GetCustomer(cmbCustCodeStart, txtTemp, Me.CustomerStart)
    End Sub
    Private Sub SetcustomerEndDialog(ByVal e As ISimpleEntity)
      Me.cmbCustCodeEnd.Text = e.Code
      'Customer.GetCustomer(cmbCustCodeEnd, txtTemp, Me.CustomerEnd)
    End Sub
    'Private Sub radMultiComboBox_DropDownOpening(ByVal sender As Object, ByVal args As System.ComponentModel.CancelEventArgs)
    '  'm_hashControlState(CType(sender, Control).Name) = RadMultiComboBox.DropDownOpening
    '  Me.SetAutoCompleteAble(sender, False)
    'End Sub
    'Private Sub cmbAccountCodeStart_DropDownClosed(ByVal sender As Object, ByVal args As Telerik.WinControls.UI.RadPopupClosedEventArgs) Handles cmbAccountCodeStart.DropDownClosed
    '  m_hashControlState(CType(sender, Control).Name) = RadMultiComboBox.DropDownClosed
    'End Sub
    'Private Sub radMultiComboBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '  'If m_hashControlState(CType(sender, Control).Name) = RadMultiComboBox.DropDownClosed Then
    '  Me.SetAutoCompleteAble(sender, True)
    '  'End If
    'End Sub
    'Private Sub RadDateTimePicker_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '  If e.KeyCode = Keys.Back Then
    '    CType(sender, RadDateTimePicker).SetToNullValue()
    '  ElseIf e.KeyCode = Keys.Insert Then
    '    CType(sender, RadDateTimePicker).Value = Now
    '  End If
    'End Sub
    'Enum RadMultiComboBox
    '  DropDownOpening
    '  DropDownClosed
    'End Enum
#End Region

    'Private Sub radMultiComboBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '  'Me.SetAutoCompleteAble(sender, True)
    'End Sub


    'Private Sub cmbAccountCodeStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccountCodeStart.Click
    '  Me.SetAutoCompleteAble(sender, False)
    'End Sub


    'Private Sub dtpDocDateStart_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDocDateStart.Opening
    '  Dim rdtpk As RadDateTimePicker = CType(sender, RadDateTimePicker)
    '  If rdtpk.Value.Equals(Date.MinValue) Then

    '  End If
    'End Sub




  End Class
End Namespace

