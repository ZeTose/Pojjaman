Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports Telerik.WinControls

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CRptJournalEntryFilterSubPanel
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
    Friend WithEvents lblToCCend As System.Windows.Forms.Label
    Friend WithEvents lblToCCstart As System.Windows.Forms.Label
    Friend WithEvents txtOpenningDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpOpenningDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOpenningStart As System.Windows.Forms.Label
    Friend WithEvents cmbCostCenterCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbCostCenterCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAccountBookCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbAccountBookCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbCostCenterCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbCostCenterCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.txtOpenningDateStart = New System.Windows.Forms.TextBox()
      Me.dtpOpenningDateStart = New System.Windows.Forms.DateTimePicker()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.lblOpenningStart = New System.Windows.Forms.Label()
      Me.lblToCCstart = New System.Windows.Forms.Label()
      Me.lblToCCend = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmbAccountBookCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbAccountBookCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.grbMaster.SuspendLayout()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAccountBookCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAccountBookCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Controls.Add(Me.txtDocDateEnd)
      Me.grbMaster.Controls.Add(Me.dtpDocDateEnd)
      Me.grbMaster.Controls.Add(Me.txtDocDateStart)
      Me.grbMaster.Controls.Add(Me.Label3)
      Me.grbMaster.Controls.Add(Me.dtpDocDateStart)
      Me.grbMaster.Controls.Add(Me.Label2)
      Me.grbMaster.Controls.Add(Me.cmbAccountBookCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbAccountBookCodeStart)
      Me.grbMaster.Controls.Add(Me.cmbCostCenterCodeStart)
      Me.grbMaster.Controls.Add(Me.txtOpenningDateStart)
      Me.grbMaster.Controls.Add(Me.dtpOpenningDateStart)
      Me.grbMaster.Controls.Add(Me.btnRefresh)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.Controls.Add(Me.Label4)
      Me.grbMaster.Controls.Add(Me.lblOpenningStart)
      Me.grbMaster.Controls.Add(Me.Label1)
      Me.grbMaster.Controls.Add(Me.lblToCCstart)
      Me.grbMaster.Controls.Add(Me.lblToCCend)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(167, 394)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
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
      Me.cmbCostCenterCodeEnd.Location = New System.Drawing.Point(33, 180)
      Me.cmbCostCenterCodeEnd.Name = "cmbCostCenterCodeEnd"
      '
      '
      '
      Me.cmbCostCenterCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeEnd.Size = New System.Drawing.Size(120, 21)
      Me.cmbCostCenterCodeEnd.TabIndex = 8
      Me.cmbCostCenterCodeEnd.TabStop = False
      Me.cmbCostCenterCodeEnd.Text = "RadMultiColumnComboBox2"
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
      Me.cmbCostCenterCodeStart.Location = New System.Drawing.Point(12, 156)
      Me.cmbCostCenterCodeStart.Name = "cmbCostCenterCodeStart"
      '
      '
      '
      Me.cmbCostCenterCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbCostCenterCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbCostCenterCodeStart.TabIndex = 7
      Me.cmbCostCenterCodeStart.TabStop = False
      Me.cmbCostCenterCodeStart.Text = "RadMultiColumnComboBox1"
      '
      'txtOpenningDateStart
      '
      Me.Validator.SetDataType(Me.txtOpenningDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtOpenningDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtOpenningDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtOpenningDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtOpenningDateStart, System.Drawing.Color.Empty)
      Me.txtOpenningDateStart.Location = New System.Drawing.Point(12, 33)
      Me.txtOpenningDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtOpenningDateStart, "")
      Me.txtOpenningDateStart.Name = "txtOpenningDateStart"
      Me.Validator.SetRegularExpression(Me.txtOpenningDateStart, "")
      Me.Validator.SetRequired(Me.txtOpenningDateStart, False)
      Me.txtOpenningDateStart.Size = New System.Drawing.Size(120, 21)
      Me.txtOpenningDateStart.TabIndex = 1
      '
      'dtpOpenningDateStart
      '
      Me.dtpOpenningDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpOpenningDateStart.Location = New System.Drawing.Point(12, 33)
      Me.dtpOpenningDateStart.Name = "dtpOpenningDateStart"
      Me.dtpOpenningDateStart.Size = New System.Drawing.Size(141, 21)
      Me.dtpOpenningDateStart.TabIndex = 2
      Me.dtpOpenningDateStart.TabStop = False
      '
      'btnRefresh
      '
      Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRefresh.Location = New System.Drawing.Point(12, 288)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 64)
      Me.btnRefresh.TabIndex = 2
      Me.btnRefresh.Text = "Refresh"
      '
      'btnReset
      '
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(33, 358)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(54, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "เคลียร์"
      '
      'lblOpenningStart
      '
      Me.lblOpenningStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOpenningStart.ForeColor = System.Drawing.Color.Black
      Me.lblOpenningStart.Location = New System.Drawing.Point(9, 14)
      Me.lblOpenningStart.Name = "lblOpenningStart"
      Me.lblOpenningStart.Size = New System.Drawing.Size(136, 18)
      Me.lblOpenningStart.TabIndex = 3
      Me.lblOpenningStart.Text = "ตั้งแต่วันที่เริ่มนับยอดยกมา"
      Me.lblOpenningStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblToCCstart
      '
      Me.lblToCCstart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCstart.ForeColor = System.Drawing.Color.Black
      Me.lblToCCstart.Location = New System.Drawing.Point(11, 138)
      Me.lblToCCstart.Name = "lblToCCstart"
      Me.lblToCCstart.Size = New System.Drawing.Size(136, 18)
      Me.lblToCCstart.TabIndex = 3
      Me.lblToCCstart.Text = "ตั้งแต่ Cost Center "
      Me.lblToCCstart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblToCCend
      '
      Me.lblToCCend.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCend.ForeColor = System.Drawing.Color.Black
      Me.lblToCCend.Location = New System.Drawing.Point(9, 182)
      Me.lblToCCend.Name = "lblToCCend"
      Me.lblToCCend.Size = New System.Drawing.Size(24, 18)
      Me.lblToCCend.TabIndex = 6
      Me.lblToCCend.Text = "ถึง"
      Me.lblToCCend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(12, 82)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.txtDocDateStart.TabIndex = 10
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(12, 82)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(141, 21)
      Me.dtpDocDateStart.TabIndex = 11
      Me.dtpDocDateStart.TabStop = False
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(8, 63)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(136, 18)
      Me.Label2.TabIndex = 12
      Me.Label2.Text = "ตั้งแต่วันที่"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(11, 108)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(24, 18)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "ถึง"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(38, 106)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(115, 21)
      Me.dtpDocDateEnd.TabIndex = 11
      Me.dtpDocDateEnd.TabStop = False
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(38, 106)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(94, 21)
      Me.txtDocDateEnd.TabIndex = 10
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(7, 255)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(24, 18)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "ถึง"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label4
      '
      Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(2, 211)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(136, 18)
      Me.Label4.TabIndex = 3
      Me.Label4.Text = "ตั้งแต่สมุดรายวัน"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbAccountBookCodeStart
      '
      '
      'cmbAccountBookCodeStart.NestedRadGridView
      '
      Me.cmbAccountBookCodeStart.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbAccountBookCodeStart.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbAccountBookCodeStart.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbAccountBookCodeStart.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbAccountBookCodeStart.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbAccountBookCodeStart.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbAccountBookCodeStart.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbAccountBookCodeStart.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbAccountBookCodeStart.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbAccountBookCodeStart.EditorControl.Name = "NestedRadGridView"
      Me.cmbAccountBookCodeStart.EditorControl.ReadOnly = True
      Me.cmbAccountBookCodeStart.EditorControl.ShowGroupPanel = False
      Me.cmbAccountBookCodeStart.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbAccountBookCodeStart.EditorControl.TabIndex = 0
      Me.cmbAccountBookCodeStart.Location = New System.Drawing.Point(11, 229)
      Me.cmbAccountBookCodeStart.Name = "cmbAccountBookCodeStart"
      '
      '
      '
      Me.cmbAccountBookCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAccountBookCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbAccountBookCodeStart.TabIndex = 7
      Me.cmbAccountBookCodeStart.TabStop = False
      Me.cmbAccountBookCodeStart.Text = "RadMultiColumnComboBox1"
      '
      'cmbAccountBookCodeEnd
      '
      '
      'cmbAccountBookCodeEnd.NestedRadGridView
      '
      Me.cmbAccountBookCodeEnd.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbAccountBookCodeEnd.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbAccountBookCodeEnd.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbAccountBookCodeEnd.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbAccountBookCodeEnd.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbAccountBookCodeEnd.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbAccountBookCodeEnd.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbAccountBookCodeEnd.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbAccountBookCodeEnd.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbAccountBookCodeEnd.EditorControl.Name = "NestedRadGridView"
      Me.cmbAccountBookCodeEnd.EditorControl.ReadOnly = True
      Me.cmbAccountBookCodeEnd.EditorControl.ShowGroupPanel = False
      Me.cmbAccountBookCodeEnd.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbAccountBookCodeEnd.EditorControl.TabIndex = 0
      Me.cmbAccountBookCodeEnd.Location = New System.Drawing.Point(33, 253)
      Me.cmbAccountBookCodeEnd.Name = "cmbAccountBookCodeEnd"
      '
      '
      '
      Me.cmbAccountBookCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAccountBookCodeEnd.Size = New System.Drawing.Size(120, 21)
      Me.cmbAccountBookCodeEnd.TabIndex = 8
      Me.cmbAccountBookCodeEnd.TabStop = False
      Me.cmbAccountBookCodeEnd.Text = "RadMultiColumnComboBox2"
      '
      'CRptJournalEntryFilterSubPanel
      '
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "CRptJournalEntryFilterSubPanel"
      Me.Size = New System.Drawing.Size(183, 410)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      CType(Me.cmbCostCenterCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbCostCenterCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAccountBookCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAccountBookCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()

      'Me.lblToCCstart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.lblToCCstart}")
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
      'Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.grbMaster}")
      'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.grbDetail}")

      'Me.chkNegativeOnly.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.chkNegativeOnly}")
      'Me.chkNoZero.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptMatCountFilterSubPanel.chkNoZero}")
    End Sub
#End Region

#Region "Member"
    Private m_OpenningDateStart As Date
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

    Public Property OpenningDateStart() As Date      Get        Return m_OpenningDateStart      End Get      Set(ByVal Value As Date)        m_OpenningDateStart = Value      End Set    End Property

    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property
#End Region

#Region "Methods"
    Private Sub RegisterDropdown()
      ' เรียงตาม 
      'RptMatReturnFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbOrderBy, "rpt_matreturn")
    End Sub
    Private Sub Initialize()
      RegisterDropdown()
      InitialMultiCombo()
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
          For Each Ctrl As Control In grbCtrl.Controls
            If TypeOf grbCtrl Is RadMultiColumnComboBox Then
              SetAllRadMultiComboBoxFilter(grbCtrl)
            ElseIf TypeOf grbCtrl Is RadDateTimePicker Then
              CType(grbCtrl, RadDateTimePicker).SetToNullValue()
            ElseIf TypeOf grbCtrl Is TextBox Then
              grbCtrl.Text = ""
            End If
          Next
        End If
      Next

      Me.OpenningDateStart = Date.Now
      Me.txtOpenningDateStart.Text = MinDateToNull(Me.OpenningDateStart, "")
      Me.dtpOpenningDateStart.Value = Me.OpenningDateStart

      Me.DocDateStart = Date.Now
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

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

    End Function
    Public Overrides Function GetFilterArray() As Longkong.Pojjaman.BusinessLogic.Filter()
      Dim arr(8) As Longkong.Pojjaman.BusinessLogic.Filter
      arr(0) = New Longkong.Pojjaman.BusinessLogic.Filter("@OpenningDateStart", IIf(Me.OpenningDateStart.Equals(Date.MinValue), DBNull.Value, Me.OpenningDateStart))
      arr(1) = New Longkong.Pojjaman.BusinessLogic.Filter("@DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(2) = New Longkong.Pojjaman.BusinessLogic.Filter("@DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(3) = New Longkong.Pojjaman.BusinessLogic.Filter("@CCCodeStart", ValidCodeOrDBNullText(Me.cmbCostCenterCodeStart))
      arr(4) = New Longkong.Pojjaman.BusinessLogic.Filter("@CCCodeEnd", ValidCodeOrDBNullText(Me.cmbCostCenterCodeEnd))
      arr(5) = New Longkong.Pojjaman.BusinessLogic.Filter("@AcctBookCodeStart", ValidCodeOrDBNullText(Me.cmbAccountBookCodeStart))
      arr(6) = New Longkong.Pojjaman.BusinessLogic.Filter("@AcctBookCodeEnd", ValidCodeOrDBNullText(Me.cmbAccountBookCodeEnd))
      arr(7) = New Longkong.Pojjaman.BusinessLogic.Filter("@userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(8) = New Longkong.Pojjaman.BusinessLogic.Filter("@OnlyPosted", DBNull.Value)
      ''arr(8) = New Filter("negativeonly", Me.chkNegativeOnly.Checked)
      Return arr
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

    Private Sub InitialMultiCombo()
      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeStart.MultiColumnComboBoxElement.DropDownWidth = 350
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbCostCenterCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 350

      Me.cmbAccountBookCodeStart.MultiColumnComboBoxElement.DropDownHeight = 200
      Me.cmbAccountBookCodeStart.MultiColumnComboBoxElement.DropDownWidth = 400
      Me.cmbAccountBookCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 200
      Me.cmbAccountBookCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 400

      'Add CostCenter Columns ==========================
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
      'Refresh CostCenter List
      Dim costCenterDataSourceStart As DataTable = CostCenter.GetCostCenterSet
      Dim costCenterDataSourceEnd As DataTable = Me.CloneData(costCenterDataSourceStart)
      Me.cmbCostCenterCodeStart.DataSource = costCenterDataSourceStart
      Me.cmbCostCenterCodeEnd.DataSource = costCenterDataSourceEnd

      'Add AccountBook Columns ==========================
      element = Me.cmbAccountBookCodeStart.MultiColumnComboBoxElement
      element.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False
      col = New GridViewTextBoxColumn("accountbook_code")
      col.HeaderText = "รหัส"
      col.Width = 100
      col.TextAlignment = Left
      element.Columns.Add(col)
      col = New GridViewTextBoxColumn("accountbook_name")
      col.HeaderText = "ชื่อ"
      col.Width = 200
      col.TextAlignment = Left
      element.Columns.Add(col)
      col = New GridViewTextBoxColumn("accountbook_prefix")
      col.HeaderText = "คำย่อ"
      col.Width = 50
      col.TextAlignment = Left
      element.Columns.Add(col)
      For Each Column As GridViewDataColumn In Me.cmbAccountBookCodeStart.MultiColumnComboBoxElement.Columns
        cmbAccountBookCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh Account Book List
      Dim acctBookDataSourceStart As DataTable = AccountBook.GetAccountSet
      Dim acctBookDataSourceEnd As DataTable = Me.CloneData(acctBookDataSourceStart)
      Me.cmbAccountBookCodeStart.DataSource = acctBookDataSourceStart
      Me.cmbAccountBookCodeEnd.DataSource = acctBookDataSourceEnd

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

      'DocDateEnd
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDateEnd"
      dpi.Value = txtOpenningDateStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      AddHandler txtOpenningDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpOpenningDateStart.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        'Case "txttoccstart"
        '  CostCenter.GetCostCenter(txtToCCstart, tempTxt, tempCC1, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        'Case "txttoccend"
        '  CostCenter.GetCostCenter(txtToCCend, tempTxt, tempCC2, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

        Case "dtpopenningdatestart"
          If Not Me.OpenningDateStart.Equals(dtpOpenningDateStart.Value) Then
            If Not m_dateSetting Then
              Me.txtOpenningDateStart.Text = MinDateToNull(dtpOpenningDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.OpenningDateStart = dtpOpenningDateStart.Value
            End If
          End If
        Case "txtopenningdatestart"
          m_dateSetting = True
          If Not Me.txtOpenningDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtOpenningDateStart) = "" Then
            Dim theDate As Date = CDate(Me.txtOpenningDateStart.Text)
            If Not Me.OpenningDateStart.Equals(theDate) Then
              dtpOpenningDateStart.Value = theDate
              Me.OpenningDateStart = dtpOpenningDateStart.Value
            End If
          Else
            Me.dtpOpenningDateStart.Value = Date.Now
            Me.OpenningDateStart = Date.MinValue
          End If
          m_dateSetting = False

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

