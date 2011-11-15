Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports Telerik.WinControls
Imports Longkong.Core.Properties

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptIncomingWhtPND2FilterSubPanel
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
    Friend WithEvents lblToSupplier As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSupplierCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbSupplierCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbSpg As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents chkIncludeChildSpg As System.Windows.Forms.CheckBox
    Friend WithEvents cmbVatType As System.Windows.Forms.ComboBox
    Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVatType As System.Windows.Forms.Label
    Friend WithEvents lblSpg As System.Windows.Forms.Label
    Friend WithEvents rdbUnNormalSubmit As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNormalSubmit As System.Windows.Forms.RadioButton
    Friend WithEvents cmbAccountBookCodeEnd As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbAccountBookCodeStart As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblSubmit As System.Windows.Forms.Label
    Friend WithEvents lblAcctBook As System.Windows.Forms.Label
    Friend WithEvents lblToAcctBook As System.Windows.Forms.Label
    Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.rdbUnNormalSubmit = New System.Windows.Forms.RadioButton()
      Me.rdbNormalSubmit = New System.Windows.Forms.RadioButton()
      Me.cmbSpg = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.chkIncludeChildSpg = New System.Windows.Forms.CheckBox()
      Me.cmbVatType = New System.Windows.Forms.ComboBox()
      Me.cmbAccountBookCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbSupplierCodeEnd = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbAccountBookCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.cmbSupplierCodeStart = New Telerik.WinControls.UI.RadMultiColumnComboBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.lblVatType = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblSpg = New System.Windows.Forms.Label()
      Me.lblSubmit = New System.Windows.Forms.Label()
      Me.lblAcctBook = New System.Windows.Forms.Label()
      Me.lblToAcctBook = New System.Windows.Forms.Label()
      Me.lblSupplier = New System.Windows.Forms.Label()
      Me.lblToSupplier = New System.Windows.Forms.Label()
      Me.btnRefresh = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbYear = New System.Windows.Forms.ComboBox()
      Me.lblYear = New System.Windows.Forms.Label()
      Me.cmbMonth = New System.Windows.Forms.ComboBox()
      Me.lblMonth = New System.Windows.Forms.Label()
      Me.grbMaster.SuspendLayout()
      CType(Me.cmbSpg, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAccountBookCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbSupplierCodeEnd, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbAccountBookCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.cmbSupplierCodeStart, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.FixedGroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbMaster
      '
      Me.grbMaster.Controls.Add(Me.rdbUnNormalSubmit)
      Me.grbMaster.Controls.Add(Me.rdbNormalSubmit)
      Me.grbMaster.Controls.Add(Me.cmbSpg)
      Me.grbMaster.Controls.Add(Me.chkIncludeChildSpg)
      Me.grbMaster.Controls.Add(Me.cmbVatType)
      Me.grbMaster.Controls.Add(Me.cmbAccountBookCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbSupplierCodeEnd)
      Me.grbMaster.Controls.Add(Me.cmbAccountBookCodeStart)
      Me.grbMaster.Controls.Add(Me.cmbSupplierCodeStart)
      Me.grbMaster.Controls.Add(Me.txtDocDateStart)
      Me.grbMaster.Controls.Add(Me.dtpDocDateStart)
      Me.grbMaster.Controls.Add(Me.txtDocDateEnd)
      Me.grbMaster.Controls.Add(Me.dtpDocDateEnd)
      Me.grbMaster.Controls.Add(Me.lblDocDateEnd)
      Me.grbMaster.Controls.Add(Me.lblVatType)
      Me.grbMaster.Controls.Add(Me.Label1)
      Me.grbMaster.Controls.Add(Me.lblSpg)
      Me.grbMaster.Controls.Add(Me.lblSubmit)
      Me.grbMaster.Controls.Add(Me.lblAcctBook)
      Me.grbMaster.Controls.Add(Me.lblToAcctBook)
      Me.grbMaster.Controls.Add(Me.lblSupplier)
      Me.grbMaster.Controls.Add(Me.lblToSupplier)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(8, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(165, 391)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "เงื่อนไขค้นหา"
      '
      'rdbUnNormalSubmit
      '
      Me.rdbUnNormalSubmit.AccessibleName = "Indicate"
      Me.rdbUnNormalSubmit.AutoSize = True
      Me.rdbUnNormalSubmit.Location = New System.Drawing.Point(11, 365)
      Me.rdbUnNormalSubmit.Name = "rdbUnNormalSubmit"
      Me.rdbUnNormalSubmit.Size = New System.Drawing.Size(95, 17)
      Me.rdbUnNormalSubmit.TabIndex = 8
      Me.rdbUnNormalSubmit.Text = "(2). ยื่นเพิ่มเติม"
      Me.rdbUnNormalSubmit.UseVisualStyleBackColor = True
      '
      'rdbNormalSubmit
      '
      Me.rdbNormalSubmit.AccessibleName = "Indicate"
      Me.rdbNormalSubmit.AutoSize = True
      Me.rdbNormalSubmit.Checked = True
      Me.rdbNormalSubmit.Location = New System.Drawing.Point(11, 348)
      Me.rdbNormalSubmit.Name = "rdbNormalSubmit"
      Me.rdbNormalSubmit.Size = New System.Drawing.Size(80, 17)
      Me.rdbNormalSubmit.TabIndex = 8
      Me.rdbNormalSubmit.TabStop = True
      Me.rdbNormalSubmit.Text = "(1). ยื่นปกติ"
      Me.rdbNormalSubmit.UseVisualStyleBackColor = True
      '
      'cmbSpg
      '
      '
      'cmbSpg.NestedRadGridView
      '
      Me.cmbSpg.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbSpg.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbSpg.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbSpg.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbSpg.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbSpg.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbSpg.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbSpg.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbSpg.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbSpg.EditorControl.Name = "NestedRadGridView"
      Me.cmbSpg.EditorControl.ReadOnly = True
      Me.cmbSpg.EditorControl.ShowGroupPanel = False
      Me.cmbSpg.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbSpg.EditorControl.TabIndex = 0
      Me.cmbSpg.Location = New System.Drawing.Point(12, 153)
      Me.cmbSpg.Name = "cmbSpg"
      '
      '
      '
      Me.cmbSpg.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbSpg.Size = New System.Drawing.Size(140, 21)
      Me.cmbSpg.TabIndex = 2
      Me.cmbSpg.TabStop = False
      '
      'chkIncludeChildSpg
      '
      Me.chkIncludeChildSpg.AutoSize = True
      Me.chkIncludeChildSpg.Location = New System.Drawing.Point(61, 137)
      Me.chkIncludeChildSpg.Name = "chkIncludeChildSpg"
      Me.chkIncludeChildSpg.Size = New System.Drawing.Size(78, 17)
      Me.chkIncludeChildSpg.TabIndex = 7
      Me.chkIncludeChildSpg.Text = "รวมกลุ่มลูก"
      Me.chkIncludeChildSpg.UseVisualStyleBackColor = True
      '
      'cmbVatType
      '
      Me.cmbVatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVatType.FormattingEnabled = True
      Me.cmbVatType.Location = New System.Drawing.Point(11, 36)
      Me.cmbVatType.Name = "cmbVatType"
      Me.cmbVatType.Size = New System.Drawing.Size(141, 21)
      Me.cmbVatType.TabIndex = 4
      '
      'cmbAcctBookEnd
      '
      '
      'cmbAcctBookEnd.NestedRadGridView
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
      Me.cmbAccountBookCodeEnd.Location = New System.Drawing.Point(34, 297)
      Me.cmbAccountBookCodeEnd.Name = "cmbAcctBookEnd"
      '
      '
      '
      Me.cmbAccountBookCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAccountBookCodeEnd.Size = New System.Drawing.Size(120, 21)
      Me.cmbAccountBookCodeEnd.TabIndex = 3
      Me.cmbAccountBookCodeEnd.TabStop = False
      '
      'cmbSupplierCodeEnd
      '
      '
      'cmbSupplierCodeEnd.NestedRadGridView
      '
      Me.cmbSupplierCodeEnd.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbSupplierCodeEnd.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbSupplierCodeEnd.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbSupplierCodeEnd.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbSupplierCodeEnd.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbSupplierCodeEnd.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbSupplierCodeEnd.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbSupplierCodeEnd.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbSupplierCodeEnd.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbSupplierCodeEnd.EditorControl.Name = "NestedRadGridView"
      Me.cmbSupplierCodeEnd.EditorControl.ReadOnly = True
      Me.cmbSupplierCodeEnd.EditorControl.ShowGroupPanel = False
      Me.cmbSupplierCodeEnd.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbSupplierCodeEnd.EditorControl.TabIndex = 0
      Me.cmbSupplierCodeEnd.Location = New System.Drawing.Point(33, 225)
      Me.cmbSupplierCodeEnd.Name = "cmbSupplierCodeEnd"
      '
      '
      '
      Me.cmbSupplierCodeEnd.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbSupplierCodeEnd.Size = New System.Drawing.Size(120, 21)
      Me.cmbSupplierCodeEnd.TabIndex = 3
      Me.cmbSupplierCodeEnd.TabStop = False
      '
      'cmbAcctBookStart
      '
      '
      'cmbAcctBookStart.NestedRadGridView
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
      Me.cmbAccountBookCodeStart.Location = New System.Drawing.Point(13, 274)
      Me.cmbAccountBookCodeStart.Name = "cmbAcctBookStart"
      '
      '
      '
      Me.cmbAccountBookCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbAccountBookCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbAccountBookCodeStart.TabIndex = 2
      Me.cmbAccountBookCodeStart.TabStop = False
      '
      'cmbSuplierCodeStart
      '
      '
      'cmbSuplierCodeStart.NestedRadGridView
      '
      Me.cmbSupplierCodeStart.EditorControl.BackColor = System.Drawing.SystemColors.Window
      Me.cmbSupplierCodeStart.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbSupplierCodeStart.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
      Me.cmbSupplierCodeStart.EditorControl.Location = New System.Drawing.Point(0, 0)
      '
      '
      '
      Me.cmbSupplierCodeStart.EditorControl.MasterGridViewTemplate.AllowAddNewRow = False
      Me.cmbSupplierCodeStart.EditorControl.MasterGridViewTemplate.AllowCellContextMenu = False
      Me.cmbSupplierCodeStart.EditorControl.MasterGridViewTemplate.AllowColumnChooser = False
      Me.cmbSupplierCodeStart.EditorControl.MasterGridViewTemplate.EnableGrouping = False
      Me.cmbSupplierCodeStart.EditorControl.MasterGridViewTemplate.ShowFilteringRow = False
      Me.cmbSupplierCodeStart.EditorControl.Name = "NestedRadGridView"
      Me.cmbSupplierCodeStart.EditorControl.ReadOnly = True
      Me.cmbSupplierCodeStart.EditorControl.ShowGroupPanel = False
      Me.cmbSupplierCodeStart.EditorControl.Size = New System.Drawing.Size(240, 150)
      Me.cmbSupplierCodeStart.EditorControl.TabIndex = 0
      Me.cmbSupplierCodeStart.Location = New System.Drawing.Point(12, 202)
      Me.cmbSupplierCodeStart.Name = "cmbSuplierCodeStart"
      '
      '
      '
      Me.cmbSupplierCodeStart.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
      Me.cmbSupplierCodeStart.Size = New System.Drawing.Size(141, 21)
      Me.cmbSupplierCodeStart.TabIndex = 2
      Me.cmbSupplierCodeStart.TabStop = False
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(11, 83)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateStart.TabIndex = 1
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(11, 83)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(33, 106)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(33, 106)
      Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
      Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDateEnd.TabIndex = 2
      Me.dtpDocDateEnd.TabStop = False
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 108)
      Me.lblDocDateEnd.Name = "lblDocDateEnd"
      Me.lblDocDateEnd.Size = New System.Drawing.Size(18, 18)
      Me.lblDocDateEnd.TabIndex = 0
      Me.lblDocDateEnd.Text = "ถึง"
      Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblVatType
      '
      Me.lblVatType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblVatType.ForeColor = System.Drawing.Color.Black
      Me.lblVatType.Location = New System.Drawing.Point(8, 19)
      Me.lblVatType.Name = "lblVatType"
      Me.lblVatType.Size = New System.Drawing.Size(130, 18)
      Me.lblVatType.TabIndex = 3
      Me.lblVatType.Text = "ประเภทภาษี"
      Me.lblVatType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(8, 66)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(134, 18)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "วันที่เอกสาร"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblSpg
      '
      Me.lblSpg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSpg.ForeColor = System.Drawing.Color.Black
      Me.lblSpg.Location = New System.Drawing.Point(8, 135)
      Me.lblSpg.Name = "lblSpg"
      Me.lblSpg.Size = New System.Drawing.Size(134, 18)
      Me.lblSpg.TabIndex = 3
      Me.lblSpg.Text = "กลุ่มผู้ขาย"
      Me.lblSpg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblSubmit
      '
      Me.lblSubmit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubmit.ForeColor = System.Drawing.Color.Black
      Me.lblSubmit.Location = New System.Drawing.Point(8, 329)
      Me.lblSubmit.Name = "lblSubmit"
      Me.lblSubmit.Size = New System.Drawing.Size(135, 18)
      Me.lblSubmit.TabIndex = 3
      Me.lblSubmit.Text = "ลักษณะการยื่น"
      Me.lblSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAcctBook
      '
      Me.lblAcctBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAcctBook.ForeColor = System.Drawing.Color.Black
      Me.lblAcctBook.Location = New System.Drawing.Point(9, 256)
      Me.lblAcctBook.Name = "lblAcctBook"
      Me.lblAcctBook.Size = New System.Drawing.Size(135, 18)
      Me.lblAcctBook.TabIndex = 3
      Me.lblAcctBook.Text = "ตั้งแต่สมุดรายวัน"
      Me.lblAcctBook.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblToAcctBook
      '
      Me.lblToAcctBook.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToAcctBook.ForeColor = System.Drawing.Color.Black
      Me.lblToAcctBook.Location = New System.Drawing.Point(9, 299)
      Me.lblToAcctBook.Name = "lblToAcctBook"
      Me.lblToAcctBook.Size = New System.Drawing.Size(24, 18)
      Me.lblToAcctBook.TabIndex = 6
      Me.lblToAcctBook.Text = "ถึง"
      Me.lblToAcctBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblSupplier
      '
      Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSupplier.ForeColor = System.Drawing.Color.Black
      Me.lblSupplier.Location = New System.Drawing.Point(8, 184)
      Me.lblSupplier.Name = "lblSupplier"
      Me.lblSupplier.Size = New System.Drawing.Size(135, 18)
      Me.lblSupplier.TabIndex = 3
      Me.lblSupplier.Text = "ผู้ถูกหัก ณ ที่จ่าย"
      Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblToSupplier
      '
      Me.lblToSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToSupplier.ForeColor = System.Drawing.Color.Black
      Me.lblToSupplier.Location = New System.Drawing.Point(8, 227)
      Me.lblToSupplier.Name = "lblToSupplier"
      Me.lblToSupplier.Size = New System.Drawing.Size(24, 18)
      Me.lblToSupplier.TabIndex = 6
      Me.lblToSupplier.Text = "ถึง"
      Me.lblToSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'btnRefresh
      '
      Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnRefresh.Location = New System.Drawing.Point(190, 304)
      Me.btnRefresh.Name = "btnRefresh"
      Me.btnRefresh.Size = New System.Drawing.Size(75, 64)
      Me.btnRefresh.TabIndex = 5
      Me.btnRefresh.Text = "Refresh"
      '
      'btnReset
      '
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(211, 374)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(54, 23)
      Me.btnReset.TabIndex = 6
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "Clear"
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
      'FixedGroupBox1
      '
      Me.FixedGroupBox1.Controls.Add(Me.cmbYear)
      Me.FixedGroupBox1.Controls.Add(Me.lblYear)
      Me.FixedGroupBox1.Controls.Add(Me.cmbMonth)
      Me.FixedGroupBox1.Controls.Add(Me.lblMonth)
      Me.FixedGroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.FixedGroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.FixedGroupBox1.Location = New System.Drawing.Point(179, 8)
      Me.FixedGroupBox1.Name = "FixedGroupBox1"
      Me.FixedGroupBox1.Size = New System.Drawing.Size(165, 104)
      Me.FixedGroupBox1.TabIndex = 0
      Me.FixedGroupBox1.TabStop = False
      Me.FixedGroupBox1.Text = "เดือนปีที่ยื่นภาษี"
      '
      'cmbYear
      '
      Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbYear.FormattingEnabled = True
      Me.cmbYear.Location = New System.Drawing.Point(11, 75)
      Me.cmbYear.Name = "cmbYear"
      Me.cmbYear.Size = New System.Drawing.Size(141, 21)
      Me.cmbYear.TabIndex = 4
      '
      'lblYear
      '
      Me.lblYear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblYear.ForeColor = System.Drawing.Color.Black
      Me.lblYear.Location = New System.Drawing.Point(8, 58)
      Me.lblYear.Name = "lblYear"
      Me.lblYear.Size = New System.Drawing.Size(130, 18)
      Me.lblYear.TabIndex = 3
      Me.lblYear.Text = "ปีภาษี"
      Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cmbMonth
      '
      Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMonth.FormattingEnabled = True
      Me.cmbMonth.Location = New System.Drawing.Point(11, 36)
      Me.cmbMonth.Name = "cmbMonth"
      Me.cmbMonth.Size = New System.Drawing.Size(141, 21)
      Me.cmbMonth.TabIndex = 4
      '
      'lblMonth
      '
      Me.lblMonth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMonth.ForeColor = System.Drawing.Color.Black
      Me.lblMonth.Location = New System.Drawing.Point(8, 19)
      Me.lblMonth.Name = "lblMonth"
      Me.lblMonth.Size = New System.Drawing.Size(130, 18)
      Me.lblMonth.TabIndex = 3
      Me.lblMonth.Text = "เดือนภาษี"
      Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'RptIncomingWhtPND2FilterSubPanel
      '
      Me.Controls.Add(Me.FixedGroupBox1)
      Me.Controls.Add(Me.grbMaster)
      Me.Controls.Add(Me.btnRefresh)
      Me.Controls.Add(Me.btnReset)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptIncomingWhtPND2FilterSubPanel"
      Me.Size = New System.Drawing.Size(354, 411)
      Me.grbMaster.ResumeLayout(False)
      Me.grbMaster.PerformLayout()
      CType(Me.cmbSpg, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAccountBookCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbSupplierCodeEnd, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbAccountBookCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.cmbSupplierCodeStart, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.FixedGroupBox1.ResumeLayout(False)
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
      WitholdingTaxType.ListCodeDescriptionInComboBox(Me.cmbVatType, "wht_type", True)
      cmbVatType.SelectedIndex = 0
      ' เรียงตาม 
      'RptMatReturnFilterOrderBy.ListCodeDescriptionInComboBox(Me.cmbOrderBy, "rpt_matreturn")
      'For i As Integer = 1 To 5
      '  Dim item As New IdValuePair(i, "ตาม Level " & i.ToString)
      '  'cmbShownLevel.Items.Add(item)
      'Next
    End Sub
    Private Sub PopulateStatus()
      Dim baseDate As Date = AccountBaseDate.GetBaseDateFromDB() 'CDate(Configuration.GetConfig("BaseDate"))
      Dim years(9) As Date
      For i As Integer = 0 To 9
        years(i) = DateAdd(DateInterval.Year, i, baseDate)
      Next
      Dim myDateTimeService As DateTimeService = CType(ServiceManager.Services.GetService(GetType(DateTimeService)), DateTimeService)
      DateTimeService.ListYearsInComboBox(Me.cmbYear, years)
      DateTimeService.ListMonthsInComboBoxWithIdValue(Me.cmbMonth, False, , False)
    End Sub
    Private Sub Initialize()
      RegisterDropdown()
      PopulateStatus()
      InitialMultiCombo()
      ClearCriterias()
    End Sub

    Private Sub ClearCriterias()
      For Each grbCtrl As Control In grbMaster.Controls
        'If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
        For Each Ctrl As Control In grbCtrl.Controls
          If TypeOf grbCtrl Is RadMultiColumnComboBox Then
            'SetAllRadMultiComboBoxFilter(grbCtrl)
            CType(grbCtrl, RadMultiColumnComboBox).SelectedIndex = -1
          ElseIf TypeOf grbCtrl Is RadDateTimePicker Then
            CType(grbCtrl, RadDateTimePicker).SetToNullValue()
          ElseIf TypeOf grbCtrl Is TextBox Then
            grbCtrl.Text = ""
          End If
        Next
        'End If
      Next

      'Me.DocDateEnd = Date.Now
      'Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      'Me.dtpDocDateEnd.Value = Me.DocDateEnd
      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.txtDocDateStart.Text = MinDateToNull(dtStart, "")
      Me.dtpDocDateStart.Value = dtStart
      Me.DocDateStart = dtStart

      Me.txtDocDateEnd.Text = MinDateToNull(Date.Now, "")
      Me.dtpDocDateEnd.Value = Date.Now
      Me.DocDateEnd = Date.Now

      Me.cmbYear.SelectedIndex = (Date.Now.Year - AccountBaseDate.GetBaseDateFromDB().Year) 'CDate(Configuration.GetConfig("BaseDate")).Year)
      Me.cmbMonth.SelectedIndex = Date.Now.Month - 1
      'Me.SupplierGroup = New SupplierGroup

      Me.chkIncludeChildSpg.Checked = False
      Me.rdbNormalSubmit.Checked = True

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
      Dim arr(12) As Longkong.Pojjaman.BusinessLogic.Filter

      arr(0) = New Longkong.Pojjaman.BusinessLogic.Filter("@DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Longkong.Pojjaman.BusinessLogic.Filter("@DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(2) = New Longkong.Pojjaman.BusinessLogic.Filter("@SupplierCodeStart", ValidCodeOrDBNullText(Me.cmbSupplierCodeStart))
      arr(3) = New Longkong.Pojjaman.BusinessLogic.Filter("@SupplierCodeEnd", ValidCodeOrDBNullText(Me.cmbSupplierCodeEnd))
      'arr(4) = New Longkong.Pojjaman.BusinessLogic.Filter("@userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(4) = New Longkong.Pojjaman.BusinessLogic.Filter("@WhtType", IIf(cmbVatType.SelectedItem Is Nothing, DBNull.Value, CType(cmbVatType.SelectedItem, IdValuePair).Id))

      If Me.cmbSpg.Text.Trim.Length = 0 OrElse Me.cmbSpg.SelectedIndex = -1 Then
        arr(5) = New Longkong.Pojjaman.BusinessLogic.Filter("@SupplierGroupID", DBNull.Value)
      Else
        Dim drow() As DataRow = SupplierGroup.AllMinData.Select("spg_code='" & Me.cmbSpg.Text & "'")
        Dim m_suppliergroup As New SupplierGroup(drow(0), "")
        arr(5) = New Longkong.Pojjaman.BusinessLogic.Filter("@SupplierGroupID", Me.ValidIdOrDBNull(m_suppliergroup))
      End If

      arr(6) = New Longkong.Pojjaman.BusinessLogic.Filter("@IncludeChildSupplierGroup", Me.chkIncludeChildSpg.Checked)
      arr(7) = New Longkong.Pojjaman.BusinessLogic.Filter("@AcctBookCodeStart", ValidCodeOrDBNullText(Me.cmbAccountBookCodeStart))
      arr(8) = New Longkong.Pojjaman.BusinessLogic.Filter("@AcctBookCodeEnd", ValidCodeOrDBNullText(Me.cmbAccountBookCodeEnd))
      arr(9) = New Longkong.Pojjaman.BusinessLogic.Filter("@IsNormalSubmit", IIf(Me.rdbNormalSubmit.Checked, 1, 2))
      arr(10) = New Longkong.Pojjaman.BusinessLogic.Filter("@WhtTypeName", Me.cmbVatType.Text)
      'Dim myProperties As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
      'Dim culture As String = CType(myProperties.GetProperty("CoreProperties.UILanguage"), String)
      'arr(11) = New Longkong.Pojjaman.BusinessLogic.Filter("Culture", culture)

      Dim newIdMonth As IdValuePair = CType(Me.cmbMonth.SelectedItem, IdValuePair)
      Dim newIdYear As ValueDisplayPair = CType(Me.cmbYear.SelectedItem, ValueDisplayPair)
      Dim taxMonthYear As Date = DateAdd(DateInterval.Month, CInt(newIdMonth.Id) - 1, newIdYear.Value)
      arr(11) = New Longkong.Pojjaman.BusinessLogic.Filter("@TaxMonthYear", taxMonthYear)
      arr(12) = New Longkong.Pojjaman.BusinessLogic.Filter("@IncludeIdList", DBNull.Value)

      'arr(13) = New Longkong.Pojjaman.BusinessLogic.Filter("CurrentUserName", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Name)

      'arr(5) = New Longkong.Pojjaman.BusinessLogic.Filter("@LevelToShow", CType(Me.cmbShownLevel.SelectedItem, IdValuePair).Id)
      'arr(6) = New Longkong.Pojjaman.BusinessLogic.Filter("@NotShowCostCenter", IIf(Me.chkShowCostCenter.Checked, 1, DBNull.Value))
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
      Me.cmbSupplierCodeStart.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbSupplierCodeStart.MultiColumnComboBoxElement.DropDownWidth = 350
      Me.cmbSupplierCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 500
      Me.cmbSupplierCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 350

      Me.cmbSpg.MultiColumnComboBoxElement.DropDownHeight = 370
      Me.cmbSpg.MultiColumnComboBoxElement.DropDownWidth = 350

      Me.cmbAccountBookCodeStart.MultiColumnComboBoxElement.DropDownHeight = 200
      Me.cmbAccountBookCodeStart.MultiColumnComboBoxElement.DropDownWidth = 400
      Me.cmbAccountBookCodeEnd.MultiColumnComboBoxElement.DropDownHeight = 200
      Me.cmbAccountBookCodeEnd.MultiColumnComboBoxElement.DropDownWidth = 400

      'Add Supplier Columns ==========================
      Dim element As Telerik.WinControls.UI.RadMultiColumnComboBoxElement = Me.cmbSupplierCodeStart.MultiColumnComboBoxElement
      element.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False
      Dim col As New Telerik.WinControls.UI.GridViewTextBoxColumn("supplier_code")
      col.HeaderText = "รหัส"
      col.Width = 100
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      col = New Telerik.WinControls.UI.GridViewTextBoxColumn("supplier_name")
      col.HeaderText = "ชื่อ"
      col.Width = 200
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      For Each Column As Telerik.WinControls.UI.GridViewDataColumn In Me.cmbSupplierCodeStart.MultiColumnComboBoxElement.Columns
        cmbSupplierCodeEnd.MultiColumnComboBoxElement.Columns.Add(Column)
      Next
      'Refresh CostCenter List
      Dim supplierDataSourceStart As DataTable = Supplier.AllMinData
      Dim supplierDataSourceEnd As DataTable = Me.CloneData(supplierDataSourceStart)
      Me.cmbSupplierCodeStart.DataSource = supplierDataSourceStart
      Me.cmbSupplierCodeEnd.DataSource = supplierDataSourceEnd
      Me.cmbSupplierCodeStart.SelectedIndex = -1
      Me.cmbSupplierCodeEnd.SelectedIndex = -1

      'Add Supplier Group Columns ==========================
      element = Me.cmbSpg.MultiColumnComboBoxElement
      element.EditorControl.MasterGridViewTemplate.AutoGenerateColumns = False
      col = New Telerik.WinControls.UI.GridViewTextBoxColumn("spg_code")
      col.HeaderText = "รหัส"
      col.Width = 100
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      col = New Telerik.WinControls.UI.GridViewTextBoxColumn("spg_name")
      col.HeaderText = "ชื่อ"
      col.Width = 200
      col.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
      element.Columns.Add(col)
      'Refresh Supplier Group List
      Dim spgDataSourceStart As DataTable = SupplierGroup.AllMinData
      Me.cmbSpg.DataSource = spgDataSourceStart
      Me.cmbSpg.SelectedIndex = -1

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
      Me.cmbAccountBookCodeStart.SelectedIndex = -1
      Me.cmbAccountBookCodeEnd.SelectedIndex = -1

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
      dpi.Value = txtDocDateEnd.Text
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

