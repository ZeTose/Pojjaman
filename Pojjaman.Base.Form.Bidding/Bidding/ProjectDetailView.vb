Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class ProjectDetailView
    'Inherits UserControl
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
    Friend WithEvents grbBidInfo As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblBidCode As System.Windows.Forms.Label
    Friend WithEvents txtBidCode As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents txtBidBond As System.Windows.Forms.TextBox
    Friend WithEvents lblBidBond As System.Windows.Forms.Label
    Friend WithEvents lblBidStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpBidStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBidStartTime As System.Windows.Forms.Label
    Friend WithEvents dtpBidStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBidEndTime As System.Windows.Forms.Label
    Friend WithEvents dtpBidEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBidEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCompletionDate As System.Windows.Forms.Label
    Friend WithEvents dtpCompletionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents lblEngineer As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents txtProjectedValue As System.Windows.Forms.TextBox
    Friend WithEvents lblProjectedValue As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents lblPer As System.Windows.Forms.Label
    Friend WithEvents grbGeneralInfo As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblBidType As System.Windows.Forms.Label
    Friend WithEvents lblBidAs As System.Windows.Forms.Label
    Friend WithEvents grbBOQType As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents chkSubmited As System.Windows.Forms.CheckBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblBidEnd As System.Windows.Forms.Label
    Friend WithEvents lblAddendum As System.Windows.Forms.Label
    Friend WithEvents txtAddendum As System.Windows.Forms.TextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents dtpBidOpenningDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBidOpen As System.Windows.Forms.Label
    Friend WithEvents grbProjectInformation As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents cmbBidType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBidAs As System.Windows.Forms.ComboBox
    Friend WithEvents chkMat As System.Windows.Forms.CheckBox
    Friend WithEvents chkLabor As System.Windows.Forms.CheckBox
    Friend WithEvents lblEstimator As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents lblPenalty As System.Windows.Forms.Label
    Friend WithEvents chkEquip As System.Windows.Forms.CheckBox
    Friend WithEvents txtEngineerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents grbProjectDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtEstimatorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents txtBidOpenningDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBidEndDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBidStartDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpBidOpenningTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBidOpenningTime As System.Windows.Forms.Label
    Friend WithEvents txtCompletionDate As System.Windows.Forms.TextBox
    Friend WithEvents txtPenaltyRate As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowCustomer As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents txtDuration As System.Windows.Forms.TextBox
    Friend WithEvents cmbDurationUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtEngineerName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowEngineer As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbPenaltyType As System.Windows.Forms.ComboBox
    Friend WithEvents txtEstimatorName As System.Windows.Forms.TextBox
    Friend WithEvents ibtnShowEstimator As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnShowEstimatorDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbBidBondType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPenaltyUnit As System.Windows.Forms.ComboBox
    Friend WithEvents ibtnShowEngineerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblJobNumber As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtContract As System.Windows.Forms.TextBox
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNACCEnumerate As System.Windows.Forms.Button
    Friend WithEvents lblContract As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectDetailView))
      Me.grbBidInfo = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.lblBidEnd = New System.Windows.Forms.Label()
      Me.txtBidOpenningDate = New System.Windows.Forms.TextBox()
      Me.txtBidEndDate = New System.Windows.Forms.TextBox()
      Me.txtBidStartDate = New System.Windows.Forms.TextBox()
      Me.cmbStatus = New System.Windows.Forms.ComboBox()
      Me.lblBidEndTime = New System.Windows.Forms.Label()
      Me.dtpBidEndTime = New System.Windows.Forms.DateTimePicker()
      Me.dtpBidEndDate = New System.Windows.Forms.DateTimePicker()
      Me.lblBidStartTime = New System.Windows.Forms.Label()
      Me.dtpBidStartTime = New System.Windows.Forms.DateTimePicker()
      Me.lblBidStartDate = New System.Windows.Forms.Label()
      Me.dtpBidStartDate = New System.Windows.Forms.DateTimePicker()
      Me.txtBidBond = New System.Windows.Forms.TextBox()
      Me.lblBidBond = New System.Windows.Forms.Label()
      Me.lblStatus = New System.Windows.Forms.Label()
      Me.lblAddendum = New System.Windows.Forms.Label()
      Me.txtAddendum = New System.Windows.Forms.TextBox()
      Me.lblLocation = New System.Windows.Forms.Label()
      Me.txtLocation = New System.Windows.Forms.TextBox()
      Me.dtpBidOpenningDate = New System.Windows.Forms.DateTimePicker()
      Me.lblBidOpen = New System.Windows.Forms.Label()
      Me.dtpBidOpenningTime = New System.Windows.Forms.DateTimePicker()
      Me.lblBidOpenningTime = New System.Windows.Forms.Label()
      Me.cmbBidBondType = New System.Windows.Forms.ComboBox()
      Me.txtContract = New System.Windows.Forms.TextBox()
      Me.lblContract = New System.Windows.Forms.Label()
      Me.lblBidCode = New System.Windows.Forms.Label()
      Me.txtBidCode = New System.Windows.Forms.TextBox()
      Me.grbProjectInformation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtCompletionDate = New System.Windows.Forms.TextBox()
      Me.lblCompletionDate = New System.Windows.Forms.Label()
      Me.cmbProvince = New System.Windows.Forms.ComboBox()
      Me.lblPer = New System.Windows.Forms.Label()
      Me.txtPenaltyRate = New System.Windows.Forms.TextBox()
      Me.lblPenalty = New System.Windows.Forms.Label()
      Me.lblProvince = New System.Windows.Forms.Label()
      Me.lblAddress = New System.Windows.Forms.Label()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.txtProjectedValue = New System.Windows.Forms.TextBox()
      Me.lblProjectedValue = New System.Windows.Forms.Label()
      Me.dtpCompletionDate = New System.Windows.Forms.DateTimePicker()
      Me.txtContact = New System.Windows.Forms.TextBox()
      Me.lblEngineer = New System.Windows.Forms.Label()
      Me.txtEngineerCode = New System.Windows.Forms.TextBox()
      Me.lblContact = New System.Windows.Forms.Label()
      Me.lblCustomer = New System.Windows.Forms.Label()
      Me.txtCustomerCode = New System.Windows.Forms.TextBox()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.ibtnShowCustomer = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblDuration = New System.Windows.Forms.Label()
      Me.txtDuration = New System.Windows.Forms.TextBox()
      Me.cmbDurationUnit = New System.Windows.Forms.ComboBox()
      Me.txtCustomerName = New System.Windows.Forms.TextBox()
      Me.txtEngineerName = New System.Windows.Forms.TextBox()
      Me.ibtnShowEngineer = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.cmbPenaltyType = New System.Windows.Forms.ComboBox()
      Me.cmbPenaltyUnit = New System.Windows.Forms.ComboBox()
      Me.ibtnShowEngineerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.grbGeneralInfo = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.cmbBidType = New System.Windows.Forms.ComboBox()
      Me.cmbBidAs = New System.Windows.Forms.ComboBox()
      Me.lblBidAs = New System.Windows.Forms.Label()
      Me.lblBidType = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.grbBOQType = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.chkMat = New System.Windows.Forms.CheckBox()
      Me.chkLabor = New System.Windows.Forms.CheckBox()
      Me.chkEquip = New System.Windows.Forms.CheckBox()
      Me.grbProjectDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ibtnShowEstimatorDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkAutorun = New System.Windows.Forms.CheckBox()
      Me.txtEstimatorName = New System.Windows.Forms.TextBox()
      Me.ibtnShowEstimator = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.chkSubmited = New System.Windows.Forms.CheckBox()
      Me.lblEstimator = New System.Windows.Forms.Label()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.lblName = New System.Windows.Forms.Label()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtEstimatorCode = New System.Windows.Forms.TextBox()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.txtJobNumber = New System.Windows.Forms.TextBox()
      Me.lblJobNumber = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.btnNACCEnumerate = New System.Windows.Forms.Button()
      Me.grbBidInfo.SuspendLayout()
      Me.grbProjectInformation.SuspendLayout()
      Me.grbGeneralInfo.SuspendLayout()
      Me.grbBOQType.SuspendLayout()
      Me.grbProjectDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbBidInfo
      '
      Me.grbBidInfo.Controls.Add(Me.lblBidEnd)
      Me.grbBidInfo.Controls.Add(Me.txtBidOpenningDate)
      Me.grbBidInfo.Controls.Add(Me.txtBidEndDate)
      Me.grbBidInfo.Controls.Add(Me.txtBidStartDate)
      Me.grbBidInfo.Controls.Add(Me.cmbStatus)
      Me.grbBidInfo.Controls.Add(Me.lblBidEndTime)
      Me.grbBidInfo.Controls.Add(Me.dtpBidEndTime)
      Me.grbBidInfo.Controls.Add(Me.dtpBidEndDate)
      Me.grbBidInfo.Controls.Add(Me.lblBidStartTime)
      Me.grbBidInfo.Controls.Add(Me.dtpBidStartTime)
      Me.grbBidInfo.Controls.Add(Me.lblBidStartDate)
      Me.grbBidInfo.Controls.Add(Me.dtpBidStartDate)
      Me.grbBidInfo.Controls.Add(Me.txtBidBond)
      Me.grbBidInfo.Controls.Add(Me.lblBidBond)
      Me.grbBidInfo.Controls.Add(Me.lblStatus)
      Me.grbBidInfo.Controls.Add(Me.lblAddendum)
      Me.grbBidInfo.Controls.Add(Me.txtAddendum)
      Me.grbBidInfo.Controls.Add(Me.lblLocation)
      Me.grbBidInfo.Controls.Add(Me.txtLocation)
      Me.grbBidInfo.Controls.Add(Me.dtpBidOpenningDate)
      Me.grbBidInfo.Controls.Add(Me.lblBidOpen)
      Me.grbBidInfo.Controls.Add(Me.dtpBidOpenningTime)
      Me.grbBidInfo.Controls.Add(Me.lblBidOpenningTime)
      Me.grbBidInfo.Controls.Add(Me.cmbBidBondType)
      Me.grbBidInfo.Controls.Add(Me.txtContract)
      Me.grbBidInfo.Controls.Add(Me.lblContract)
      Me.grbBidInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBidInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbBidInfo.Location = New System.Drawing.Point(8, 100)
      Me.grbBidInfo.Name = "grbBidInfo"
      Me.grbBidInfo.Size = New System.Drawing.Size(441, 171)
      Me.grbBidInfo.TabIndex = 5
      Me.grbBidInfo.TabStop = False
      Me.grbBidInfo.Text = "รายละเอียดการประมูล"
      '
      'lblBidEnd
      '
      Me.lblBidEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidEnd.ForeColor = System.Drawing.Color.Black
      Me.lblBidEnd.Location = New System.Drawing.Point(8, 117)
      Me.lblBidEnd.Name = "lblBidEnd"
      Me.lblBidEnd.Size = New System.Drawing.Size(88, 19)
      Me.lblBidEnd.TabIndex = 16
      Me.lblBidEnd.Text = "End Date of Bidding:"
      Me.lblBidEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBidOpenningDate
      '
      Me.Validator.SetDataType(Me.txtBidOpenningDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtBidOpenningDate, "")
      Me.txtBidOpenningDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBidOpenningDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBidOpenningDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBidOpenningDate, System.Drawing.Color.Empty)
      Me.txtBidOpenningDate.Location = New System.Drawing.Point(96, 136)
      Me.Validator.SetMaxValue(Me.txtBidOpenningDate, "")
      Me.Validator.SetMinValue(Me.txtBidOpenningDate, "")
      Me.txtBidOpenningDate.Name = "txtBidOpenningDate"
      Me.Validator.SetRegularExpression(Me.txtBidOpenningDate, "")
      Me.Validator.SetRequired(Me.txtBidOpenningDate, False)
      Me.txtBidOpenningDate.Size = New System.Drawing.Size(86, 21)
      Me.txtBidOpenningDate.TabIndex = 9
      '
      'txtBidEndDate
      '
      Me.Validator.SetDataType(Me.txtBidEndDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtBidEndDate, "")
      Me.txtBidEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBidEndDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBidEndDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBidEndDate, System.Drawing.Color.Empty)
      Me.txtBidEndDate.Location = New System.Drawing.Point(96, 114)
      Me.Validator.SetMaxValue(Me.txtBidEndDate, "")
      Me.Validator.SetMinValue(Me.txtBidEndDate, "")
      Me.txtBidEndDate.Name = "txtBidEndDate"
      Me.Validator.SetRegularExpression(Me.txtBidEndDate, "")
      Me.Validator.SetRequired(Me.txtBidEndDate, False)
      Me.txtBidEndDate.Size = New System.Drawing.Size(86, 21)
      Me.txtBidEndDate.TabIndex = 7
      '
      'txtBidStartDate
      '
      Me.Validator.SetDataType(Me.txtBidStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtBidStartDate, "")
      Me.txtBidStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBidStartDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtBidStartDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtBidStartDate, System.Drawing.Color.Empty)
      Me.txtBidStartDate.Location = New System.Drawing.Point(96, 91)
      Me.Validator.SetMaxValue(Me.txtBidStartDate, "")
      Me.Validator.SetMinValue(Me.txtBidStartDate, "")
      Me.txtBidStartDate.Name = "txtBidStartDate"
      Me.Validator.SetRegularExpression(Me.txtBidStartDate, "")
      Me.Validator.SetRequired(Me.txtBidStartDate, False)
      Me.txtBidStartDate.Size = New System.Drawing.Size(86, 21)
      Me.txtBidStartDate.TabIndex = 5
      '
      'cmbStatus
      '
      Me.cmbStatus.Location = New System.Drawing.Point(96, 19)
      Me.cmbStatus.Name = "cmbStatus"
      Me.cmbStatus.Size = New System.Drawing.Size(144, 21)
      Me.cmbStatus.TabIndex = 0
      Me.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
      '
      'lblBidEndTime
      '
      Me.lblBidEndTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidEndTime.ForeColor = System.Drawing.Color.Black
      Me.lblBidEndTime.Location = New System.Drawing.Point(200, 115)
      Me.lblBidEndTime.Name = "lblBidEndTime"
      Me.lblBidEndTime.Size = New System.Drawing.Size(32, 18)
      Me.lblBidEndTime.TabIndex = 22
      Me.lblBidEndTime.Text = "Time"
      Me.lblBidEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpBidEndTime
      '
      Me.dtpBidEndTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidEndTime.CustomFormat = ""
      Me.dtpBidEndTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpBidEndTime.Location = New System.Drawing.Point(232, 115)
      Me.dtpBidEndTime.Name = "dtpBidEndTime"
      Me.dtpBidEndTime.ShowUpDown = True
      Me.dtpBidEndTime.Size = New System.Drawing.Size(80, 21)
      Me.dtpBidEndTime.TabIndex = 8
      '
      'dtpBidEndDate
      '
      Me.dtpBidEndDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidEndDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpBidEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBidEndDate.Location = New System.Drawing.Point(96, 115)
      Me.dtpBidEndDate.Name = "dtpBidEndDate"
      Me.dtpBidEndDate.Size = New System.Drawing.Size(104, 21)
      Me.dtpBidEndDate.TabIndex = 19
      Me.dtpBidEndDate.TabStop = False
      '
      'lblBidStartTime
      '
      Me.lblBidStartTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidStartTime.ForeColor = System.Drawing.Color.Black
      Me.lblBidStartTime.Location = New System.Drawing.Point(200, 91)
      Me.lblBidStartTime.Name = "lblBidStartTime"
      Me.lblBidStartTime.Size = New System.Drawing.Size(32, 18)
      Me.lblBidStartTime.TabIndex = 21
      Me.lblBidStartTime.Text = "Time"
      Me.lblBidStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpBidStartTime
      '
      Me.dtpBidStartTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidStartTime.CustomFormat = ""
      Me.dtpBidStartTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpBidStartTime.Location = New System.Drawing.Point(232, 91)
      Me.dtpBidStartTime.Name = "dtpBidStartTime"
      Me.dtpBidStartTime.ShowUpDown = True
      Me.dtpBidStartTime.Size = New System.Drawing.Size(80, 21)
      Me.dtpBidStartTime.TabIndex = 6
      '
      'lblBidStartDate
      '
      Me.lblBidStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidStartDate.ForeColor = System.Drawing.Color.Black
      Me.lblBidStartDate.Location = New System.Drawing.Point(8, 91)
      Me.lblBidStartDate.Name = "lblBidStartDate"
      Me.lblBidStartDate.Size = New System.Drawing.Size(88, 18)
      Me.lblBidStartDate.TabIndex = 15
      Me.lblBidStartDate.Text = "Bid Date:"
      Me.lblBidStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpBidStartDate
      '
      Me.dtpBidStartDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidStartDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpBidStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBidStartDate.Location = New System.Drawing.Point(96, 91)
      Me.dtpBidStartDate.Name = "dtpBidStartDate"
      Me.dtpBidStartDate.Size = New System.Drawing.Size(104, 21)
      Me.dtpBidStartDate.TabIndex = 18
      Me.dtpBidStartDate.TabStop = False
      '
      'txtBidBond
      '
      Me.Validator.SetDataType(Me.txtBidBond, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtBidBond, "")
      Me.txtBidBond.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBidBond, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBidBond, System.Drawing.Color.Empty)
      Me.txtBidBond.Location = New System.Drawing.Point(96, 43)
      Me.Validator.SetMaxValue(Me.txtBidBond, "")
      Me.Validator.SetMinValue(Me.txtBidBond, "")
      Me.txtBidBond.Name = "txtBidBond"
      Me.Validator.SetRegularExpression(Me.txtBidBond, "")
      Me.Validator.SetRequired(Me.txtBidBond, False)
      Me.txtBidBond.Size = New System.Drawing.Size(88, 21)
      Me.txtBidBond.TabIndex = 2
      Me.txtBidBond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBidBond
      '
      Me.lblBidBond.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidBond.Location = New System.Drawing.Point(16, 43)
      Me.lblBidBond.Name = "lblBidBond"
      Me.lblBidBond.Size = New System.Drawing.Size(80, 21)
      Me.lblBidBond.TabIndex = 13
      Me.lblBidBond.Text = "Bid Bond:"
      Me.lblBidBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblStatus
      '
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.Location = New System.Drawing.Point(8, 19)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(88, 21)
      Me.lblStatus.TabIndex = 11
      Me.lblStatus.Text = "Status:"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAddendum
      '
      Me.lblAddendum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAddendum.Location = New System.Drawing.Point(224, 19)
      Me.lblAddendum.Name = "lblAddendum"
      Me.lblAddendum.Size = New System.Drawing.Size(88, 21)
      Me.lblAddendum.TabIndex = 12
      Me.lblAddendum.Text = "Addendum#:"
      Me.lblAddendum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAddendum
      '
      Me.Validator.SetDataType(Me.txtAddendum, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAddendum, "")
      Me.txtAddendum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAddendum, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAddendum, System.Drawing.Color.Empty)
      Me.txtAddendum.Location = New System.Drawing.Point(312, 19)
      Me.txtAddendum.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtAddendum, "")
      Me.Validator.SetMinValue(Me.txtAddendum, "")
      Me.txtAddendum.Name = "txtAddendum"
      Me.Validator.SetRegularExpression(Me.txtAddendum, "")
      Me.Validator.SetRequired(Me.txtAddendum, False)
      Me.txtAddendum.Size = New System.Drawing.Size(104, 21)
      Me.txtAddendum.TabIndex = 1
      '
      'lblLocation
      '
      Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblLocation.Location = New System.Drawing.Point(16, 67)
      Me.lblLocation.Name = "lblLocation"
      Me.lblLocation.Size = New System.Drawing.Size(80, 21)
      Me.lblLocation.TabIndex = 14
      Me.lblLocation.Text = "Place of Bid:"
      Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtLocation
      '
      Me.Validator.SetDataType(Me.txtLocation, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtLocation, "")
      Me.txtLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtLocation, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtLocation, System.Drawing.Color.Empty)
      Me.txtLocation.Location = New System.Drawing.Point(96, 67)
      Me.txtLocation.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtLocation, "")
      Me.Validator.SetMinValue(Me.txtLocation, "")
      Me.txtLocation.Name = "txtLocation"
      Me.Validator.SetRegularExpression(Me.txtLocation, "")
      Me.Validator.SetRequired(Me.txtLocation, False)
      Me.txtLocation.Size = New System.Drawing.Size(320, 21)
      Me.txtLocation.TabIndex = 4
      '
      'dtpBidOpenningDate
      '
      Me.dtpBidOpenningDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidOpenningDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpBidOpenningDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidOpenningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpBidOpenningDate.Location = New System.Drawing.Point(96, 136)
      Me.dtpBidOpenningDate.Name = "dtpBidOpenningDate"
      Me.dtpBidOpenningDate.Size = New System.Drawing.Size(104, 21)
      Me.dtpBidOpenningDate.TabIndex = 20
      Me.dtpBidOpenningDate.TabStop = False
      '
      'lblBidOpen
      '
      Me.lblBidOpen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidOpen.ForeColor = System.Drawing.Color.Black
      Me.lblBidOpen.Location = New System.Drawing.Point(8, 140)
      Me.lblBidOpen.Name = "lblBidOpen"
      Me.lblBidOpen.Size = New System.Drawing.Size(88, 18)
      Me.lblBidOpen.TabIndex = 17
      Me.lblBidOpen.Text = "Bid Result Date:"
      Me.lblBidOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpBidOpenningTime
      '
      Me.dtpBidOpenningTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidOpenningTime.CustomFormat = ""
      Me.dtpBidOpenningTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpBidOpenningTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpBidOpenningTime.Location = New System.Drawing.Point(232, 139)
      Me.dtpBidOpenningTime.Name = "dtpBidOpenningTime"
      Me.dtpBidOpenningTime.ShowUpDown = True
      Me.dtpBidOpenningTime.Size = New System.Drawing.Size(80, 21)
      Me.dtpBidOpenningTime.TabIndex = 10
      '
      'lblBidOpenningTime
      '
      Me.lblBidOpenningTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidOpenningTime.ForeColor = System.Drawing.Color.Black
      Me.lblBidOpenningTime.Location = New System.Drawing.Point(200, 139)
      Me.lblBidOpenningTime.Name = "lblBidOpenningTime"
      Me.lblBidOpenningTime.Size = New System.Drawing.Size(32, 18)
      Me.lblBidOpenningTime.TabIndex = 23
      Me.lblBidOpenningTime.Text = "Tiime"
      Me.lblBidOpenningTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbBidBondType
      '
      Me.cmbBidBondType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbBidBondType.Location = New System.Drawing.Point(184, 43)
      Me.cmbBidBondType.Name = "cmbBidBondType"
      Me.cmbBidBondType.Size = New System.Drawing.Size(56, 21)
      Me.cmbBidBondType.TabIndex = 3
      Me.cmbBidBondType.DropDownStyle = ComboBoxStyle.DropDownList
      '
      'txtContract
      '
      Me.Validator.SetDataType(Me.txtContract, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtContract, "")
      Me.txtContract.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtContract, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtContract, System.Drawing.Color.Empty)
      Me.txtContract.Location = New System.Drawing.Point(312, 43)
      Me.Validator.SetMaxValue(Me.txtContract, "")
      Me.Validator.SetMinValue(Me.txtContract, "")
      Me.txtContract.Name = "txtContract"
      Me.Validator.SetRegularExpression(Me.txtContract, "")
      Me.Validator.SetRequired(Me.txtContract, False)
      Me.txtContract.Size = New System.Drawing.Size(104, 21)
      Me.txtContract.TabIndex = 4
      Me.txtContract.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblContract
      '
      Me.lblContract.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblContract.Location = New System.Drawing.Point(248, 43)
      Me.lblContract.Name = "lblContract"
      Me.lblContract.Size = New System.Drawing.Size(64, 21)
      Me.lblContract.TabIndex = 19
      Me.lblContract.Text = "Contract:"
      Me.lblContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBidCode
      '
      Me.lblBidCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidCode.Location = New System.Drawing.Point(209, 44)
      Me.lblBidCode.Name = "lblBidCode"
      Me.lblBidCode.Size = New System.Drawing.Size(88, 20)
      Me.lblBidCode.TabIndex = 12
      Me.lblBidCode.Text = "Bidding Code:"
      Me.lblBidCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtBidCode
      '
      Me.Validator.SetDataType(Me.txtBidCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBidCode, "")
      Me.txtBidCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBidCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBidCode, System.Drawing.Color.Empty)
      Me.txtBidCode.Location = New System.Drawing.Point(296, 44)
      Me.txtBidCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtBidCode, "")
      Me.Validator.SetMinValue(Me.txtBidCode, "")
      Me.txtBidCode.Name = "txtBidCode"
      Me.Validator.SetRegularExpression(Me.txtBidCode, "")
      Me.Validator.SetRequired(Me.txtBidCode, False)
      Me.txtBidCode.Size = New System.Drawing.Size(151, 21)
      Me.txtBidCode.TabIndex = 3
      '
      'grbProjectInformation
      '
      Me.grbProjectInformation.Controls.Add(Me.txtCompletionDate)
      Me.grbProjectInformation.Controls.Add(Me.lblCompletionDate)
      Me.grbProjectInformation.Controls.Add(Me.cmbProvince)
      Me.grbProjectInformation.Controls.Add(Me.lblPer)
      Me.grbProjectInformation.Controls.Add(Me.txtPenaltyRate)
      Me.grbProjectInformation.Controls.Add(Me.lblPenalty)
      Me.grbProjectInformation.Controls.Add(Me.lblProvince)
      Me.grbProjectInformation.Controls.Add(Me.lblAddress)
      Me.grbProjectInformation.Controls.Add(Me.txtAddress)
      Me.grbProjectInformation.Controls.Add(Me.txtProjectedValue)
      Me.grbProjectInformation.Controls.Add(Me.lblProjectedValue)
      Me.grbProjectInformation.Controls.Add(Me.dtpCompletionDate)
      Me.grbProjectInformation.Controls.Add(Me.txtContact)
      Me.grbProjectInformation.Controls.Add(Me.lblEngineer)
      Me.grbProjectInformation.Controls.Add(Me.txtEngineerCode)
      Me.grbProjectInformation.Controls.Add(Me.lblContact)
      Me.grbProjectInformation.Controls.Add(Me.lblCustomer)
      Me.grbProjectInformation.Controls.Add(Me.txtCustomerCode)
      Me.grbProjectInformation.Controls.Add(Me.lblBaht)
      Me.grbProjectInformation.Controls.Add(Me.ibtnShowCustomer)
      Me.grbProjectInformation.Controls.Add(Me.ibtnShowCustomerDialog)
      Me.grbProjectInformation.Controls.Add(Me.lblDuration)
      Me.grbProjectInformation.Controls.Add(Me.txtDuration)
      Me.grbProjectInformation.Controls.Add(Me.cmbDurationUnit)
      Me.grbProjectInformation.Controls.Add(Me.txtCustomerName)
      Me.grbProjectInformation.Controls.Add(Me.txtEngineerName)
      Me.grbProjectInformation.Controls.Add(Me.ibtnShowEngineer)
      Me.grbProjectInformation.Controls.Add(Me.cmbPenaltyType)
      Me.grbProjectInformation.Controls.Add(Me.cmbPenaltyUnit)
      Me.grbProjectInformation.Controls.Add(Me.ibtnShowEngineerDialog)
      Me.grbProjectInformation.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbProjectInformation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbProjectInformation.Location = New System.Drawing.Point(8, 289)
      Me.grbProjectInformation.Name = "grbProjectInformation"
      Me.grbProjectInformation.Size = New System.Drawing.Size(745, 199)
      Me.grbProjectInformation.TabIndex = 1
      Me.grbProjectInformation.TabStop = False
      Me.grbProjectInformation.Text = "รายละเอียดอื่นๆ"
      '
      'txtCompletionDate
      '
      Me.Validator.SetDataType(Me.txtCompletionDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtCompletionDate, "")
      Me.txtCompletionDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCompletionDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCompletionDate, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCompletionDate, System.Drawing.Color.Empty)
      Me.txtCompletionDate.Location = New System.Drawing.Point(104, 164)
      Me.Validator.SetMaxValue(Me.txtCompletionDate, "")
      Me.Validator.SetMinValue(Me.txtCompletionDate, "")
      Me.txtCompletionDate.Name = "txtCompletionDate"
      Me.Validator.SetRegularExpression(Me.txtCompletionDate, "")
      Me.Validator.SetRequired(Me.txtCompletionDate, False)
      Me.txtCompletionDate.Size = New System.Drawing.Size(94, 21)
      Me.txtCompletionDate.TabIndex = 9
      '
      'lblCompletionDate
      '
      Me.lblCompletionDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCompletionDate.ForeColor = System.Drawing.Color.Black
      Me.lblCompletionDate.Location = New System.Drawing.Point(14, 166)
      Me.lblCompletionDate.Name = "lblCompletionDate"
      Me.lblCompletionDate.Size = New System.Drawing.Size(88, 24)
      Me.lblCompletionDate.TabIndex = 18
      Me.lblCompletionDate.Text = "Completion Date:"
      Me.lblCompletionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbProvince
      '
      Me.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbProvince.Location = New System.Drawing.Point(104, 140)
      Me.cmbProvince.Name = "cmbProvince"
      Me.cmbProvince.Size = New System.Drawing.Size(144, 21)
      Me.cmbProvince.TabIndex = 8
      '
      'lblPer
      '
      Me.lblPer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPer.Location = New System.Drawing.Point(457, 92)
      Me.lblPer.Name = "lblPer"
      Me.lblPer.Size = New System.Drawing.Size(24, 20)
      Me.lblPer.TabIndex = 25
      Me.lblPer.Text = "Per"
      Me.lblPer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtPenaltyRate
      '
      Me.Validator.SetDataType(Me.txtPenaltyRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtPenaltyRate, "")
      Me.txtPenaltyRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPenaltyRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPenaltyRate, System.Drawing.Color.Empty)
      Me.txtPenaltyRate.Location = New System.Drawing.Point(289, 92)
      Me.Validator.SetMaxValue(Me.txtPenaltyRate, "")
      Me.Validator.SetMinValue(Me.txtPenaltyRate, "")
      Me.txtPenaltyRate.Name = "txtPenaltyRate"
      Me.Validator.SetRegularExpression(Me.txtPenaltyRate, "")
      Me.Validator.SetRequired(Me.txtPenaltyRate, False)
      Me.txtPenaltyRate.Size = New System.Drawing.Size(104, 21)
      Me.txtPenaltyRate.TabIndex = 4
      Me.txtPenaltyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPenalty
      '
      Me.lblPenalty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPenalty.Location = New System.Drawing.Point(233, 92)
      Me.lblPenalty.Name = "lblPenalty"
      Me.lblPenalty.Size = New System.Drawing.Size(56, 20)
      Me.lblPenalty.TabIndex = 24
      Me.lblPenalty.Text = "Penalty:"
      Me.lblPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblProvince
      '
      Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProvince.Location = New System.Drawing.Point(14, 140)
      Me.lblProvince.Name = "lblProvince"
      Me.lblProvince.Size = New System.Drawing.Size(88, 20)
      Me.lblProvince.TabIndex = 17
      Me.lblProvince.Text = "Province:"
      Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAddress
      '
      Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAddress.Location = New System.Drawing.Point(14, 116)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(88, 20)
      Me.lblAddress.TabIndex = 16
      Me.lblAddress.Text = "Address:"
      Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAddress
      '
      Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAddress, "")
      Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.txtAddress.Location = New System.Drawing.Point(104, 116)
      Me.txtAddress.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtAddress, "")
      Me.Validator.SetMinValue(Me.txtAddress, "")
      Me.txtAddress.Name = "txtAddress"
      Me.Validator.SetRegularExpression(Me.txtAddress, "")
      Me.Validator.SetRequired(Me.txtAddress, False)
      Me.txtAddress.Size = New System.Drawing.Size(450, 21)
      Me.txtAddress.TabIndex = 7
      '
      'txtProjectedValue
      '
      Me.Validator.SetDataType(Me.txtProjectedValue, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
      Me.Validator.SetDisplayName(Me.txtProjectedValue, "")
      Me.txtProjectedValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtProjectedValue, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtProjectedValue, System.Drawing.Color.Empty)
      Me.txtProjectedValue.Location = New System.Drawing.Point(104, 92)
      Me.Validator.SetMaxValue(Me.txtProjectedValue, "")
      Me.Validator.SetMinValue(Me.txtProjectedValue, "")
      Me.txtProjectedValue.Name = "txtProjectedValue"
      Me.Validator.SetRegularExpression(Me.txtProjectedValue, "")
      Me.Validator.SetRequired(Me.txtProjectedValue, False)
      Me.txtProjectedValue.Size = New System.Drawing.Size(104, 21)
      Me.txtProjectedValue.TabIndex = 3
      Me.txtProjectedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblProjectedValue
      '
      Me.lblProjectedValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblProjectedValue.Location = New System.Drawing.Point(14, 92)
      Me.lblProjectedValue.Name = "lblProjectedValue"
      Me.lblProjectedValue.Size = New System.Drawing.Size(88, 20)
      Me.lblProjectedValue.TabIndex = 15
      Me.lblProjectedValue.Text = "Fair Price:"
      Me.lblProjectedValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpCompletionDate
      '
      Me.dtpCompletionDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpCompletionDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpCompletionDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpCompletionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpCompletionDate.Location = New System.Drawing.Point(104, 164)
      Me.dtpCompletionDate.Name = "dtpCompletionDate"
      Me.dtpCompletionDate.Size = New System.Drawing.Size(112, 21)
      Me.dtpCompletionDate.TabIndex = 19
      '
      'txtContact
      '
      Me.Validator.SetDataType(Me.txtContact, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtContact, "")
      Me.txtContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtContact, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtContact, System.Drawing.Color.Empty)
      Me.txtContact.Location = New System.Drawing.Point(104, 44)
      Me.txtContact.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtContact, "")
      Me.Validator.SetMinValue(Me.txtContact, "")
      Me.txtContact.Name = "txtContact"
      Me.Validator.SetRegularExpression(Me.txtContact, "")
      Me.Validator.SetRequired(Me.txtContact, False)
      Me.txtContact.Size = New System.Drawing.Size(450, 21)
      Me.txtContact.TabIndex = 1
      '
      'lblEngineer
      '
      Me.lblEngineer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEngineer.Location = New System.Drawing.Point(14, 68)
      Me.lblEngineer.Name = "lblEngineer"
      Me.lblEngineer.Size = New System.Drawing.Size(88, 20)
      Me.lblEngineer.TabIndex = 14
      Me.lblEngineer.Text = "Engineer:"
      Me.lblEngineer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtEngineerCode
      '
      Me.Validator.SetDataType(Me.txtEngineerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEngineerCode, "")
      Me.txtEngineerCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEngineerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEngineerCode, System.Drawing.Color.Empty)
      Me.txtEngineerCode.Location = New System.Drawing.Point(104, 68)
      Me.txtEngineerCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtEngineerCode, "")
      Me.Validator.SetMinValue(Me.txtEngineerCode, "")
      Me.txtEngineerCode.Name = "txtEngineerCode"
      Me.Validator.SetRegularExpression(Me.txtEngineerCode, "")
      Me.Validator.SetRequired(Me.txtEngineerCode, False)
      Me.txtEngineerCode.Size = New System.Drawing.Size(104, 21)
      Me.txtEngineerCode.TabIndex = 2
      '
      'lblContact
      '
      Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblContact.Location = New System.Drawing.Point(14, 44)
      Me.lblContact.Name = "lblContact"
      Me.lblContact.Size = New System.Drawing.Size(88, 20)
      Me.lblContact.TabIndex = 13
      Me.lblContact.Text = "Contact:"
      Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCustomer
      '
      Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCustomer.Location = New System.Drawing.Point(14, 20)
      Me.lblCustomer.Name = "lblCustomer"
      Me.lblCustomer.Size = New System.Drawing.Size(88, 20)
      Me.lblCustomer.TabIndex = 12
      Me.lblCustomer.Text = "Customer:"
      Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCustomerCode
      '
      Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
      Me.txtCustomerCode.Location = New System.Drawing.Point(104, 20)
      Me.txtCustomerCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
      Me.Validator.SetMinValue(Me.txtCustomerCode, "")
      Me.txtCustomerCode.Name = "txtCustomerCode"
      Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
      Me.Validator.SetRequired(Me.txtCustomerCode, False)
      Me.txtCustomerCode.Size = New System.Drawing.Size(104, 21)
      Me.txtCustomerCode.TabIndex = 0
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(208, 92)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(32, 20)
      Me.lblBaht.TabIndex = 23
      Me.lblBaht.Text = "บาท"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'ibtnShowCustomer
      '
      Me.ibtnShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomer.Location = New System.Drawing.Point(579, 20)
      Me.ibtnShowCustomer.Name = "ibtnShowCustomer"
      Me.ibtnShowCustomer.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomer.TabIndex = 29
      Me.ibtnShowCustomer.TabStop = False
      Me.ibtnShowCustomer.ThemedImage = CType(resources.GetObject("ibtnShowCustomer.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnShowCustomerDialog
      '
      Me.ibtnShowCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(555, 20)
      Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
      Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowCustomerDialog.TabIndex = 28
      Me.ibtnShowCustomerDialog.TabStop = False
      Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDuration
      '
      Me.lblDuration.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDuration.Location = New System.Drawing.Point(217, 164)
      Me.lblDuration.Name = "lblDuration"
      Me.lblDuration.Size = New System.Drawing.Size(73, 20)
      Me.lblDuration.TabIndex = 20
      Me.lblDuration.Text = "Duration:"
      Me.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDuration
      '
      Me.Validator.SetDataType(Me.txtDuration, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int32Type)
      Me.Validator.SetDisplayName(Me.txtDuration, "")
      Me.txtDuration.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDuration, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDuration, System.Drawing.Color.Empty)
      Me.txtDuration.Location = New System.Drawing.Point(291, 164)
      Me.Validator.SetMaxValue(Me.txtDuration, "")
      Me.Validator.SetMinValue(Me.txtDuration, "")
      Me.txtDuration.Name = "txtDuration"
      Me.Validator.SetRegularExpression(Me.txtDuration, "")
      Me.Validator.SetRequired(Me.txtDuration, False)
      Me.txtDuration.Size = New System.Drawing.Size(50, 21)
      Me.txtDuration.TabIndex = 10
      Me.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbDurationUnit
      '
      Me.cmbDurationUnit.Location = New System.Drawing.Point(341, 164)
      Me.cmbDurationUnit.Name = "cmbDurationUnit"
      Me.cmbDurationUnit.Size = New System.Drawing.Size(56, 21)
      Me.cmbDurationUnit.TabIndex = 11
      '
      'txtCustomerName
      '
      Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCustomerName, "")
      Me.txtCustomerName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
      Me.txtCustomerName.Location = New System.Drawing.Point(208, 20)
      Me.txtCustomerName.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtCustomerName, "")
      Me.Validator.SetMinValue(Me.txtCustomerName, "")
      Me.txtCustomerName.Name = "txtCustomerName"
      Me.txtCustomerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
      Me.Validator.SetRequired(Me.txtCustomerName, False)
      Me.txtCustomerName.Size = New System.Drawing.Size(346, 21)
      Me.txtCustomerName.TabIndex = 21
      Me.txtCustomerName.TabStop = False
      '
      'txtEngineerName
      '
      Me.txtEngineerName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtEngineerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEngineerName, "")
      Me.txtEngineerName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEngineerName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEngineerName, System.Drawing.Color.Empty)
      Me.txtEngineerName.Location = New System.Drawing.Point(208, 68)
      Me.txtEngineerName.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtEngineerName, "")
      Me.Validator.SetMinValue(Me.txtEngineerName, "")
      Me.txtEngineerName.Name = "txtEngineerName"
      Me.txtEngineerName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEngineerName, "")
      Me.Validator.SetRequired(Me.txtEngineerName, False)
      Me.txtEngineerName.Size = New System.Drawing.Size(346, 21)
      Me.txtEngineerName.TabIndex = 22
      Me.txtEngineerName.TabStop = False
      '
      'ibtnShowEngineer
      '
      Me.ibtnShowEngineer.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEngineer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEngineer.Location = New System.Drawing.Point(579, 67)
      Me.ibtnShowEngineer.Name = "ibtnShowEngineer"
      Me.ibtnShowEngineer.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEngineer.TabIndex = 27
      Me.ibtnShowEngineer.TabStop = False
      Me.ibtnShowEngineer.ThemedImage = CType(resources.GetObject("ibtnShowEngineer.ThemedImage"), System.Drawing.Bitmap)
      '
      'cmbPenaltyType
      '
      Me.cmbPenaltyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPenaltyType.Location = New System.Drawing.Point(393, 92)
      Me.cmbPenaltyType.Name = "cmbPenaltyType"
      Me.cmbPenaltyType.Size = New System.Drawing.Size(56, 21)
      Me.cmbPenaltyType.TabIndex = 5
      '
      'cmbPenaltyUnit
      '
      Me.cmbPenaltyUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPenaltyUnit.Location = New System.Drawing.Point(481, 92)
      Me.cmbPenaltyUnit.Name = "cmbPenaltyUnit"
      Me.cmbPenaltyUnit.Size = New System.Drawing.Size(56, 21)
      Me.cmbPenaltyUnit.TabIndex = 6
      '
      'ibtnShowEngineerDialog
      '
      Me.ibtnShowEngineerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEngineerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEngineerDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEngineerDialog.Location = New System.Drawing.Point(555, 67)
      Me.ibtnShowEngineerDialog.Name = "ibtnShowEngineerDialog"
      Me.ibtnShowEngineerDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEngineerDialog.TabIndex = 26
      Me.ibtnShowEngineerDialog.TabStop = False
      Me.ibtnShowEngineerDialog.ThemedImage = CType(resources.GetObject("ibtnShowEngineerDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbGeneralInfo
      '
      Me.grbGeneralInfo.Controls.Add(Me.cmbBidType)
      Me.grbGeneralInfo.Controls.Add(Me.cmbBidAs)
      Me.grbGeneralInfo.Controls.Add(Me.lblBidAs)
      Me.grbGeneralInfo.Controls.Add(Me.lblBidType)
      Me.grbGeneralInfo.Controls.Add(Me.txtNote)
      Me.grbGeneralInfo.Controls.Add(Me.lblNote)
      Me.grbGeneralInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbGeneralInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbGeneralInfo.Location = New System.Drawing.Point(458, 120)
      Me.grbGeneralInfo.Name = "grbGeneralInfo"
      Me.grbGeneralInfo.Size = New System.Drawing.Size(277, 140)
      Me.grbGeneralInfo.TabIndex = 6
      Me.grbGeneralInfo.TabStop = False
      Me.grbGeneralInfo.Text = "ทั่วไป"
      '
      'cmbBidType
      '
      Me.cmbBidType.Location = New System.Drawing.Point(136, 16)
      Me.cmbBidType.Name = "cmbBidType"
      Me.cmbBidType.Size = New System.Drawing.Size(122, 21)
      Me.cmbBidType.TabIndex = 0
      Me.cmbBidType.Text = "Government"
      Me.cmbBidType.DropDownStyle = ComboBoxStyle.DropDownList
      '
      'cmbBidAs
      '
      Me.cmbBidAs.Location = New System.Drawing.Point(136, 40)
      Me.cmbBidAs.Name = "cmbBidAs"
      Me.cmbBidAs.Size = New System.Drawing.Size(122, 21)
      Me.cmbBidAs.TabIndex = 1
      Me.cmbBidAs.Text = "Sub-Contractor"
      Me.cmbBidAs.DropDownStyle = ComboBoxStyle.DropDownList
      '
      'lblBidAs
      '
      Me.lblBidAs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidAs.Location = New System.Drawing.Point(15, 40)
      Me.lblBidAs.Name = "lblBidAs"
      Me.lblBidAs.Size = New System.Drawing.Size(120, 20)
      Me.lblBidAs.TabIndex = 4
      Me.lblBidAs.Text = "Bidding Information:"
      Me.lblBidAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBidType
      '
      Me.lblBidType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBidType.Location = New System.Drawing.Point(15, 16)
      Me.lblBidType.Name = "lblBidType"
      Me.lblBidType.Size = New System.Drawing.Size(120, 20)
      Me.lblBidType.TabIndex = 5
      Me.lblBidType.Text = "Type of Bidding:"
      Me.lblBidType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(8, 76)
      Me.txtNote.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(250, 56)
      Me.txtNote.TabIndex = 2
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(8, 60)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(88, 20)
      Me.lblNote.TabIndex = 3
      Me.lblNote.Text = "ข้อมูลเพิ่มเติม:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grbBOQType
      '
      Me.grbBOQType.Controls.Add(Me.chkMat)
      Me.grbBOQType.Controls.Add(Me.chkLabor)
      Me.grbBOQType.Controls.Add(Me.chkEquip)
      Me.grbBOQType.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbBOQType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbBOQType.Location = New System.Drawing.Point(574, 40)
      Me.grbBOQType.Name = "grbBOQType"
      Me.grbBOQType.Size = New System.Drawing.Size(160, 76)
      Me.grbBOQType.TabIndex = 17
      Me.grbBOQType.TabStop = False
      Me.grbBOQType.Text = "ข้อมูลรายการ BOQ"
      '
      'chkMat
      '
      Me.chkMat.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkMat.Location = New System.Drawing.Point(18, 19)
      Me.chkMat.Name = "chkMat"
      Me.chkMat.Size = New System.Drawing.Size(104, 16)
      Me.chkMat.TabIndex = 0
      Me.chkMat.TabStop = False
      Me.chkMat.Text = "ค่าวัสดุ"
      '
      'chkLabor
      '
      Me.chkLabor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkLabor.Location = New System.Drawing.Point(18, 36)
      Me.chkLabor.Name = "chkLabor"
      Me.chkLabor.Size = New System.Drawing.Size(104, 16)
      Me.chkLabor.TabIndex = 1
      Me.chkLabor.TabStop = False
      Me.chkLabor.Text = "ค่าแรง"
      '
      'chkEquip
      '
      Me.chkEquip.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkEquip.Location = New System.Drawing.Point(18, 49)
      Me.chkEquip.Name = "chkEquip"
      Me.chkEquip.Size = New System.Drawing.Size(104, 24)
      Me.chkEquip.TabIndex = 2
      Me.chkEquip.TabStop = False
      Me.chkEquip.Text = "ค่าเครื่องจักร"
      '
      'grbProjectDetail
      '
      Me.grbProjectDetail.Controls.Add(Me.ibtnShowEstimatorDialog)
      Me.grbProjectDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbProjectDetail.Controls.Add(Me.chkAutorun)
      Me.grbProjectDetail.Controls.Add(Me.txtEstimatorName)
      Me.grbProjectDetail.Controls.Add(Me.ibtnShowEstimator)
      Me.grbProjectDetail.Controls.Add(Me.chkSubmited)
      Me.grbProjectDetail.Controls.Add(Me.lblEstimator)
      Me.grbProjectDetail.Controls.Add(Me.txtName)
      Me.grbProjectDetail.Controls.Add(Me.lblName)
      Me.grbProjectDetail.Controls.Add(Me.txtCode)
      Me.grbProjectDetail.Controls.Add(Me.grbBOQType)
      Me.grbProjectDetail.Controls.Add(Me.txtEstimatorCode)
      Me.grbProjectDetail.Controls.Add(Me.grbBidInfo)
      Me.grbProjectDetail.Controls.Add(Me.grbGeneralInfo)
      Me.grbProjectDetail.Controls.Add(Me.lblCode)
      Me.grbProjectDetail.Controls.Add(Me.txtBidCode)
      Me.grbProjectDetail.Controls.Add(Me.lblBidCode)
      Me.grbProjectDetail.Controls.Add(Me.txtJobNumber)
      Me.grbProjectDetail.Controls.Add(Me.lblJobNumber)
      Me.grbProjectDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbProjectDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbProjectDetail.Location = New System.Drawing.Point(8, 0)
      Me.grbProjectDetail.Name = "grbProjectDetail"
      Me.grbProjectDetail.Size = New System.Drawing.Size(745, 279)
      Me.grbProjectDetail.TabIndex = 0
      Me.grbProjectDetail.TabStop = False
      Me.grbProjectDetail.Text = "รายละเอียดโครงการ"
      '
      'ibtnShowEstimatorDialog
      '
      Me.ibtnShowEstimatorDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEstimatorDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEstimatorDialog.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnShowEstimatorDialog.Location = New System.Drawing.Point(477, 68)
      Me.ibtnShowEstimatorDialog.Name = "ibtnShowEstimatorDialog"
      Me.ibtnShowEstimatorDialog.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEstimatorDialog.TabIndex = 14
      Me.ibtnShowEstimatorDialog.TabStop = False
      Me.ibtnShowEstimatorDialog.ThemedImage = CType(resources.GetObject("ibtnShowEstimatorDialog.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnCopyMe
      '
      Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Location = New System.Drawing.Point(228, 18)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 18
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkAutorun
      '
      Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
      Me.chkAutorun.Location = New System.Drawing.Point(208, 20)
      Me.chkAutorun.Name = "chkAutorun"
      Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
      Me.chkAutorun.TabIndex = 10
      '
      'txtEstimatorName
      '
      Me.txtEstimatorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtEstimatorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEstimatorName, "")
      Me.txtEstimatorName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEstimatorName, System.Drawing.Color.Empty)
      Me.txtEstimatorName.Location = New System.Drawing.Point(208, 68)
      Me.txtEstimatorName.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtEstimatorName, "")
      Me.Validator.SetMinValue(Me.txtEstimatorName, "")
      Me.txtEstimatorName.Name = "txtEstimatorName"
      Me.txtEstimatorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtEstimatorName, "")
      Me.Validator.SetRequired(Me.txtEstimatorName, False)
      Me.txtEstimatorName.Size = New System.Drawing.Size(273, 21)
      Me.txtEstimatorName.TabIndex = 13
      Me.txtEstimatorName.TabStop = False
      '
      'ibtnShowEstimator
      '
      Me.ibtnShowEstimator.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnShowEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnShowEstimator.Location = New System.Drawing.Point(501, 68)
      Me.ibtnShowEstimator.Name = "ibtnShowEstimator"
      Me.ibtnShowEstimator.Size = New System.Drawing.Size(24, 23)
      Me.ibtnShowEstimator.TabIndex = 15
      Me.ibtnShowEstimator.TabStop = False
      Me.ibtnShowEstimator.ThemedImage = CType(resources.GetObject("ibtnShowEstimator.ThemedImage"), System.Drawing.Bitmap)
      '
      'chkSubmited
      '
      Me.chkSubmited.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSubmited.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.chkSubmited.ForeColor = System.Drawing.Color.Black
      Me.chkSubmited.Location = New System.Drawing.Point(575, 16)
      Me.chkSubmited.Name = "chkSubmited"
      Me.chkSubmited.Size = New System.Drawing.Size(104, 20)
      Me.chkSubmited.TabIndex = 16
      Me.chkSubmited.TabStop = False
      Me.chkSubmited.Text = "Already Submited"
      '
      'lblEstimator
      '
      Me.lblEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEstimator.Location = New System.Drawing.Point(16, 66)
      Me.lblEstimator.Name = "lblEstimator"
      Me.lblEstimator.Size = New System.Drawing.Size(88, 20)
      Me.lblEstimator.TabIndex = 9
      Me.lblEstimator.Text = "Estimator:"
      Me.lblEstimator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(296, 20)
      Me.txtName.MaxLength = 200
      Me.Validator.SetMaxValue(Me.txtName, "")
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(258, 21)
      Me.txtName.TabIndex = 1
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.Location = New System.Drawing.Point(256, 20)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(40, 20)
      Me.lblName.TabIndex = 11
      Me.lblName.Text = "Name:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(104, 20)
      Me.txtCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtCode, "")
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, True)
      Me.txtCode.Size = New System.Drawing.Size(104, 21)
      Me.txtCode.TabIndex = 0
      '
      'txtEstimatorCode
      '
      Me.Validator.SetDataType(Me.txtEstimatorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtEstimatorCode, "")
      Me.txtEstimatorCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtEstimatorCode, System.Drawing.Color.Empty)
      Me.txtEstimatorCode.Location = New System.Drawing.Point(104, 68)
      Me.txtEstimatorCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtEstimatorCode, "")
      Me.Validator.SetMinValue(Me.txtEstimatorCode, "")
      Me.txtEstimatorCode.Name = "txtEstimatorCode"
      Me.Validator.SetRegularExpression(Me.txtEstimatorCode, "")
      Me.Validator.SetRequired(Me.txtEstimatorCode, False)
      Me.txtEstimatorCode.Size = New System.Drawing.Size(104, 21)
      Me.txtEstimatorCode.TabIndex = 4
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(16, 20)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(88, 20)
      Me.lblCode.TabIndex = 7
      Me.lblCode.Text = "Project Code:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtJobNumber
      '
      Me.Validator.SetDataType(Me.txtJobNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtJobNumber, "")
      Me.txtJobNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtJobNumber, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtJobNumber, System.Drawing.Color.Empty)
      Me.txtJobNumber.Location = New System.Drawing.Point(104, 44)
      Me.txtJobNumber.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtJobNumber, "")
      Me.Validator.SetMinValue(Me.txtJobNumber, "")
      Me.txtJobNumber.Name = "txtJobNumber"
      Me.Validator.SetRegularExpression(Me.txtJobNumber, "")
      Me.Validator.SetRequired(Me.txtJobNumber, False)
      Me.txtJobNumber.Size = New System.Drawing.Size(104, 21)
      Me.txtJobNumber.TabIndex = 2
      '
      'lblJobNumber
      '
      Me.lblJobNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblJobNumber.Location = New System.Drawing.Point(16, 44)
      Me.lblJobNumber.Name = "lblJobNumber"
      Me.lblJobNumber.Size = New System.Drawing.Size(88, 20)
      Me.lblJobNumber.TabIndex = 8
      Me.lblJobNumber.Text = "Job Number:"
      Me.lblJobNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.btnNACCEnumerate)
      Me.GroupBox1.Location = New System.Drawing.Point(760, -1)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(222, 489)
      Me.GroupBox1.TabIndex = 2
      Me.GroupBox1.TabStop = False
      '
      'btnNACCEnumerate
      '
      Me.btnNACCEnumerate.Enabled = False
      Me.btnNACCEnumerate.Location = New System.Drawing.Point(20, 21)
      Me.btnNACCEnumerate.Name = "btnNACCEnumerate"
      Me.btnNACCEnumerate.Size = New System.Drawing.Size(173, 43)
      Me.btnNACCEnumerate.TabIndex = 0
      Me.btnNACCEnumerate.Text = "รายละเอียด แบบ บช. ๑"
      Me.btnNACCEnumerate.UseVisualStyleBackColor = True
      '
      'ProjectDetailView
      '
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.grbProjectDetail)
      Me.Controls.Add(Me.grbProjectInformation)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "ProjectDetailView"
      Me.Size = New System.Drawing.Size(992, 498)
      Me.grbBidInfo.ResumeLayout(False)
      Me.grbBidInfo.PerformLayout()
      Me.grbProjectInformation.ResumeLayout(False)
      Me.grbProjectInformation.PerformLayout()
      Me.grbGeneralInfo.ResumeLayout(False)
      Me.grbGeneralInfo.PerformLayout()
      Me.grbBOQType.ResumeLayout(False)
      Me.grbProjectDetail.ResumeLayout(False)
      Me.grbProjectDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_entity As Project
    Private m_isInitialized As Boolean = False
#End Region

#Region "Properties"

#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()
      EventWiring()
      LoopControl(Me)
    End Sub
#End Region

#Region "IListDetail"
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      SetEnableNACCButton()
    End Sub

    ' เคลียร์ข้อมูลลูกค้าใน control
    Public Overrides Sub ClearDetail()
      With Me
        .txtJobNumber.Text = ""
        .txtAddendum.Text = ""
        .txtAddress.Text = ""
        .txtBidBond.Text = ""
        .txtBidCode.Text = ""
        .txtBidEndDate.Text = ""
        .txtBidOpenningDate.Text = ""
        .txtBidStartDate.Text = ""
        .txtCode.Text = ""
        .txtCompletionDate.Text = ""
        .txtContact.Text = ""
        .txtCustomerCode.Text = ""
        .txtCustomerName.Text = ""
        .txtDuration.Text = ""
        .txtEngineerCode.Text = ""
        .txtEngineerName.Text = ""
        .txtEstimatorCode.Text = ""
        .txtEstimatorName.Text = ""
        .txtLocation.Text = ""
        .txtName.Text = ""
        .txtNote.Text = ""
        .txtPenaltyRate.Text = ""
        .txtProjectedValue.Text = ""
        .txtContract.Text = ""

        .dtpBidEndDate.Value = Now.Date
        .dtpBidEndTime.Value = Now.Date
        .dtpBidOpenningDate.Value = Now.Date
        .dtpBidOpenningTime.Value = Now.Date
        .dtpBidStartDate.Value = Now.Date
        .dtpBidStartTime.Value = Now.Date
        .dtpCompletionDate.Value = Now.Date

        .chkEquip.Checked = True
        .chkLabor.Checked = True
        .chkMat.Checked = True
      End With
    End Sub

    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbBidInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.grbBidInfo}")
      Me.lblBidCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidCode}")
      Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblStatus}")
      Me.lblBidBond.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidBond}")
      Me.lblBidStartDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidStartDate}")
      Me.lblBidStartTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidStartTime}")
      Me.lblBidEndTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidEndTime}")
      Me.lblCompletionDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblCompletionDate}")
      Me.lblEngineer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblEngineer}")
      Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblCustomer}")
      Me.lblProjectedValue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblProjectedValue}")
      Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblAddress}")
      Me.lblProvince.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblProvince}")
      Me.lblPer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblPer}")
      Me.grbGeneralInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.grbGeneralInfo}")
      Me.lblBidType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidType}")
      Me.lblBidAs.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidAs}")
      Me.grbBOQType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.grbBOQType}")
      Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblName}")
      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblCode}")
      Me.chkSubmited.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.chkSubmited}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblNote}")
      Me.lblBidEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidEnd}")
      Me.lblAddendum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblAddendum}")
      Me.lblLocation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblLocation}")
      Me.lblBidOpen.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidOpen}")
      Me.grbProjectInformation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.grbProjectInformation}")
      Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblContact}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
      Me.chkMat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.chkMat}")
      Me.chkLabor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.chkLabor}")
      Me.lblEstimator.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblEstimator}")
      Me.lblPenalty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblPenalty}")
      Me.chkEquip.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.chkEquip}")
      Me.grbProjectDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.grbProjectDetail}")
      Me.lblBidOpenningTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblBidOpenningTime}")
      Me.lblDuration.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblDuration}")
      Me.lblJobNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ProjectDetailView.lblJobNumber}")
    End Sub

    Protected Overrides Sub EventWiring()

      AddHandler txtAddendum.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBidBond.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtBidCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtContact.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtJobNumber.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtDuration.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtEngineerCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtEstimatorCode.Validated, AddressOf Me.ChangeProperty

      AddHandler txtLocation.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPenaltyRate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtProjectedValue.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtBidEndDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpBidEndDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpBidEndTime.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtBidStartDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpBidStartDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpBidStartTime.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtBidOpenningDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpBidOpenningDate.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpBidOpenningTime.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCompletionDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpCompletionDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler cmbProvince.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbProvince.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler cmbBidAs.SelectedIndexChanged, AddressOf ChangeProperty
      AddHandler cmbBidBondType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbBidType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbDurationUnit.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbPenaltyUnit.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbPenaltyType.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbStatus.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler chkEquip.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkLabor.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkMat.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler chkSubmited.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler txtContract.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtContract.Validated, AddressOf Me.TextHandler
    End Sub
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtcontract"
          Dim txt As String = Me.txtContract.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Contract = 0
          Else
            Try
              Me.m_entity.Contract = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.Contract = 0
            End Try
          End If
          Me.txtContract.Text = Configuration.FormatToString(Me.m_entity.Contract, DigitConfig.Price)
      End Select
    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      With Me
        .txtCode.Text = m_entity.Code
        Me.m_oldCode = Me.m_entity.Code
        Me.chkAutorun.Checked = Me.m_entity.AutoGen
        Me.UpdateAutogenStatus()

        .txtJobNumber.Text = m_entity.Jobnumber
        .txtName.Text = m_entity.Name
        .txtAddendum.Text = .m_entity.AddendumCode
        .txtAddress.Text = .m_entity.Address
        .txtBidBond.Text = Configuration.FormatToString(.m_entity.BidBond, DigitConfig.Price)
        .txtContract.Text = Configuration.FormatToString(.m_entity.Contract, DigitConfig.Price)
        .txtBidCode.Text = .m_entity.BidCode
        .txtContact.Text = .m_entity.Contact
        If Not .m_entity.Customer Is Nothing Then
          .txtCustomerCode.Text = .m_entity.Customer.Code
          .txtCustomerName.Text = .m_entity.Customer.Name
        End If
        .txtDuration.Text = .m_entity.Duration.ToString
        If Not .m_entity.Engineer Is Nothing Then
          .txtEngineerCode.Text = .m_entity.Engineer.Code
          .txtEngineerName.Text = .m_entity.Engineer.Name
        End If
        If Not .m_entity.Estimator Is Nothing Then
          .txtEstimatorCode.Text = .m_entity.Estimator.Code
          .txtEstimatorName.Text = .m_entity.Estimator.Name
        End If

        .txtLocation.Text = .m_entity.BidLocation
        .txtNote.Text = .m_entity.Note
        .txtPenaltyRate.Text = Configuration.FormatToString(.m_entity.PenaltyRate, DigitConfig.Price)
        .txtProjectedValue.Text = Configuration.FormatToString(.m_entity.ProjectedValue, DigitConfig.Price)

        .txtBidEndDate.Text = MinDateToNull(Me.m_entity.BidEndDate.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        .dtpBidEndDate.Value = MinDateToNow(Me.m_entity.BidEndDate.Date)
        .dtpBidEndTime.Value = MinDateToNow(Me.m_entity.BidEndDate)

        .txtBidOpenningDate.Text = MinDateToNull(Me.m_entity.BidOpenningDate.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        .dtpBidOpenningDate.Value = MinDateToNow(Me.m_entity.BidOpenningDate.Date)
        .dtpBidOpenningTime.Value = MinDateToNow(Me.m_entity.BidOpenningDate)

        .txtBidStartDate.Text = MinDateToNull(Me.m_entity.BidStartDate.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        .dtpBidStartDate.Value = MinDateToNow(Me.m_entity.BidStartDate.Date)
        .dtpBidStartTime.Value = MinDateToNow(Me.m_entity.BidStartDate)

        .txtCompletionDate.Text = MinDateToNull(Me.m_entity.CompletionDate.Date, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
        .dtpCompletionDate.Value = MinDateToNow(Me.m_entity.CompletionDate.Date)

        For Each item As IdValuePair In .cmbBidAs.Items
          If .m_entity.BidAs.Value = item.Id Then
            Me.cmbBidAs.SelectedItem = item
          End If
        Next
        For Each item As IdValuePair In .cmbBidBondType.Items
          If .m_entity.BidBondType.Value = item.Id Then
            Me.cmbBidBondType.SelectedItem = item
          End If
        Next
        For Each item As IdValuePair In .cmbBidType.Items
          If .m_entity.BidType.Value = item.Id Then
            Me.cmbBidType.SelectedItem = item
          End If
        Next
        For Each item As IdValuePair In .cmbDurationUnit.Items
          If .m_entity.DurationUnit.Value = item.Id Then
            Me.cmbDurationUnit.SelectedItem = item
          End If
        Next
        For Each item As IdValuePair In .cmbPenaltyType.Items
          If .m_entity.PenaltyType.Value = item.Id Then
            Me.cmbPenaltyType.SelectedItem = item
          End If
        Next
        For Each item As IdValuePair In .cmbPenaltyUnit.Items
          If .m_entity.PenaltyUnit.Value = item.Id Then
            Me.cmbPenaltyUnit.SelectedItem = item
          End If
        Next
        For Each item As IdValuePair In .cmbStatus.Items
          If .m_entity.Status.Value = item.Id Then
            Me.cmbStatus.SelectedItem = item
          End If
        Next
        Dim cmbIndex As Integer = Me.cmbProvince.FindStringExact(Me.m_entity.Province)
        If cmbIndex = -1 Then
          Me.cmbProvince.Text = Me.m_entity.Province
        Else
          Me.cmbProvince.SelectedIndex = cmbIndex
        End If

        .chkEquip.Checked = .m_entity.HasEquipmentCost
        .chkLabor.Checked = .m_entity.HasLaborCost
        .chkMat.Checked = .m_entity.HasMaterialCost

      End With

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Dim m_dateSetting As Boolean
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      With Me.m_entity
        Select Case CType(sender, Control).Name.ToLower
          Case "txtaddendum"
            .AddendumCode = txtAddendum.Text
            dirtyFlag = True
          Case "txtcontract"
            dirtyFlag = True
          Case "txtjobnumber"
            .Jobnumber = txtJobNumber.Text
            dirtyFlag = True
          Case "txtaddress"
            .Address = txtAddress.Text
            dirtyFlag = True
          Case "txtbidbond"
            If IsNumeric(txtBidBond.Text) Then
              .BidBond = CDec(txtBidBond.Text)
            Else
              .BidBond = 0
            End If
            dirtyFlag = True
          Case "txtbidcode"
            .BidCode = txtBidCode.Text
            dirtyFlag = True
          Case "txtcode"
            .Code = txtCode.Text
            dirtyFlag = True
          Case "txtcontact"
            .Contact = txtContact.Text
            dirtyFlag = True
          Case "txtcustomercode"
            dirtyFlag = ContactCustomer.GetCustomer(txtCustomerCode, txtCustomerName, .Customer)
          Case "txtduration"
            If IsNumeric(txtDuration.Text) Then
              .Duration = CInt(txtDuration.Text)
            Else
              .Duration = 0
            End If
            dirtyFlag = True
          Case "txtengineercode"
            dirtyFlag = RunningEmployee.GetEmployee(txtEngineerCode, txtEngineerName, .Engineer)
          Case "txtestimatorcode"
            dirtyFlag = RunningEmployee.GetEmployee(txtEstimatorCode, txtEstimatorName, .Estimator)
          Case "txtlocation"
            .BidLocation = txtLocation.Text
            dirtyFlag = True
          Case "txtname"
            .Name = txtName.Text
            dirtyFlag = True
          Case "txtnote"
            .Note = txtNote.Text
            dirtyFlag = True
          Case "txtpenaltyrate"
            If IsNumeric(txtPenaltyRate.Text) Then
              .PenaltyRate = CDec(txtPenaltyRate.Text)
            Else
              .PenaltyRate = 0
            End If
            dirtyFlag = True
          Case "txtprojectedvalue"
            If IsNumeric(txtProjectedValue.Text) Then
              .ProjectedValue = CDec(txtProjectedValue.Text)
            Else
              .ProjectedValue = 0
            End If
            dirtyFlag = True

          Case "dtpbidendtime"
            If Not .BidEndDate.Date.Equals(Date.MinValue) Then
              SetTime(dtpBidEndDate.Value, dtpBidEndTime.Value, .BidEndDate)
              dirtyFlag = True
            End If
          Case "txtbidenddate"
            m_dateSetting = True
            If Not Me.txtBidEndDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtBidEndDate) = "" Then
              Dim theDate As Date = CDate(Me.txtBidEndDate.Text)
              If Not .BidEndDate.Date.Equals(theDate) Then
                dtpBidEndDate.Value = theDate
                SetTime(dtpBidEndDate.Value, dtpBidEndTime.Value, .BidEndDate)
                dirtyFlag = True
              End If
            Else
              Me.dtpBidEndDate.Value = Date.Now
              .BidEndDate = Date.MinValue
              dirtyFlag = True
            End If
            m_dateSetting = False
          Case "dtpbidenddate"
            If Not .BidEndDate.Date.Equals(dtpBidEndDate.Value) Then
              If Not m_dateSetting Then
                Me.txtBidEndDate.Text = MinDateToNull(dtpBidEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                SetTime(dtpBidEndDate.Value, dtpBidEndTime.Value, .BidEndDate)
              End If
              dirtyFlag = True
            End If

          Case "dtpbidstarttime"
            If Not .BidStartDate.Date.Equals(Date.MinValue) Then
              SetTime(dtpBidStartDate.Value, dtpBidStartTime.Value, .BidStartDate)
              dirtyFlag = True
            End If
          Case "txtbidstartdate"
            m_dateSetting = True
            If Not Me.txtBidStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtBidStartDate) = "" Then
              Dim theDate As Date = CDate(Me.txtBidStartDate.Text)
              If Not .BidStartDate.Date.Equals(theDate) Then
                dtpBidStartDate.Value = theDate
                SetTime(dtpBidStartDate.Value, dtpBidStartTime.Value, .BidStartDate)
                dirtyFlag = True
              End If
            Else
              Me.dtpBidStartDate.Value = Date.Now
              .BidStartDate = Date.MinValue
              dirtyFlag = True
            End If
            m_dateSetting = False
          Case "dtpbidstartdate"
            If Not .BidStartDate.Date.Equals(dtpBidStartDate.Value) Then
              If Not m_dateSetting Then
                Me.txtBidStartDate.Text = MinDateToNull(dtpBidStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                SetTime(dtpBidStartDate.Value, dtpBidStartTime.Value, .BidStartDate)
              End If
              dirtyFlag = True
            End If

          Case "dtpbidopenningtime"
            If Not .BidOpenningDate.Date.Equals(Date.MinValue) Then
              SetTime(dtpBidOpenningDate.Value, dtpBidOpenningTime.Value, .BidOpenningDate)
              dirtyFlag = True
            End If
          Case "txtbidopenningdate"
            m_dateSetting = True
            If Not Me.txtBidOpenningDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtBidStartDate) = "" Then
              Dim theDate As Date = CDate(Me.txtBidOpenningDate.Text)
              If Not .BidOpenningDate.Date.Equals(theDate) Then
                dtpBidOpenningDate.Value = theDate
                SetTime(dtpBidOpenningDate.Value, dtpBidOpenningTime.Value, .BidOpenningDate)
                dirtyFlag = True
              End If
            Else
              Me.dtpBidOpenningDate.Value = Date.Now
              .BidOpenningDate = Date.MinValue
              dirtyFlag = True
            End If
            m_dateSetting = False
          Case "dtpbidopenningdate"
            If Not .BidOpenningDate.Date.Equals(dtpBidOpenningDate.Value) Then
              If Not m_dateSetting Then
                Me.txtBidOpenningDate.Text = MinDateToNull(dtpBidOpenningDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                SetTime(dtpBidOpenningDate.Value, dtpBidOpenningTime.Value, .BidOpenningDate)
              End If
              dirtyFlag = True
            End If

          Case "txtcompletiondate"
            m_dateSetting = True
            If Not Me.txtCompletionDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtBidStartDate) = "" Then
              Dim theDate As Date = CDate(Me.txtCompletionDate.Text)
              If Not .CompletionDate.Equals(theDate) Then
                dtpCompletionDate.Value = theDate
                .CompletionDate = dtpCompletionDate.Value
                dirtyFlag = True
              End If
            Else
              Me.dtpCompletionDate.Value = Date.Now
              .CompletionDate = Date.MinValue
              dirtyFlag = True
            End If
            m_dateSetting = False
          Case "dtpcompletiondate"
            If Not .CompletionDate.Equals(dtpCompletionDate.Value) Then
              If Not m_dateSetting Then
                Me.txtCompletionDate.Text = MinDateToNull(dtpCompletionDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                .CompletionDate = dtpCompletionDate.Value
              End If
              dirtyFlag = True
            End If

          Case "cmbprovince"
            .Province = cmbProvince.Text
            dirtyFlag = True

          Case "cmbbidas"
            Dim item As IdValuePair = CType(Me.cmbBidAs.SelectedItem, IdValuePair)
            .BidAs.Value = item.Id
            dirtyFlag = True
          Case "cmbbidbondtype"
            Dim item As IdValuePair = CType(Me.cmbBidBondType.SelectedItem, IdValuePair)
            .BidBondType.Value = item.Id
            dirtyFlag = True
          Case "cmbbidtype"
            Dim item As IdValuePair = CType(Me.cmbBidType.SelectedItem, IdValuePair)
            .BidType.Value = item.Id
            Me.SetEnableNACCButton()
            dirtyFlag = True
          Case "cmbdurationunit"
            Dim item As IdValuePair = CType(Me.cmbDurationUnit.SelectedItem, IdValuePair)
            .DurationUnit.Value = item.Id
            dirtyFlag = True
          Case "cmbpenaltyunit"
            Dim item As IdValuePair = CType(Me.cmbPenaltyUnit.SelectedItem, IdValuePair)
            .PenaltyUnit.Value = item.Id
            dirtyFlag = True
          Case "cmbpenaltytype"
            Dim item As IdValuePair = CType(Me.cmbPenaltyType.SelectedItem, IdValuePair)
            .PenaltyType.Value = item.Id
            dirtyFlag = True
          Case "cmbstatus"
            Dim item As IdValuePair = CType(Me.cmbStatus.SelectedItem, IdValuePair)
            .Status.Value = item.Id
            dirtyFlag = True

          Case "chkequip"
            .HasEquipmentCost = chkEquip.Checked
            dirtyFlag = True
          Case "chklabor"
            .HasLaborCost = Me.chkLabor.Checked
            dirtyFlag = True
          Case "chkmat"
            .HasMaterialCost = Me.chkMat.Checked
            dirtyFlag = True

          Case "chksubmited"
            'dirtyFlag = True
        End Select
      End With

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
    End Sub
    Private Sub SetTime(ByVal theDate As Date, ByVal theTime As Date, ByRef timeToSet As Date)
      timeToSet = theDate.Add(theTime.TimeOfDay)
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
      'If Not IsNothing(m_entity.CancelDate) And Not m_entity.CancelDate.Equals(Date.MinValue) Then
      '  lblStatus.Text = "ยกเลิก: " & m_entity.CancelDate.ToShortDateString & _
      '  " " & m_entity.CancelDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.CancelPerson.Name
      'ElseIf Not IsNothing(m_entity.LastEditDate) And Not m_entity.LastEditDate.Equals(Date.MinValue) Then
      '  lblStatus.Text = "แก้ไขล่าสุด: " & m_entity.LastEditDate.ToShortDateString & _
      '  " " & m_entity.LastEditDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.LastEditor.Name
      'ElseIf Not IsNothing(m_entity.OriginDate) And Not m_entity.OriginDate.Equals(Date.MinValue) Then
      '  lblStatus.Text = "เพิ่มเข้าสู่ระบบ: " & m_entity.OriginDate.ToShortDateString & _
      '  " " & m_entity.OriginDate.ToShortTimeString & _
      '  "  โดย:" & m_entity.Originator.Name
      'Else
      '  lblStatus.Text = ""
      'End If
    End Sub
    Private Sub SetEnableNACCButton()
      'If ConfigurationUserControl.GetConfig(0, ConfigType.AddIns, "NotReleased") Then
      '  Me.btnNACCEnumerate.Visible = True
      'Else
      '  Me.btnNACCEnumerate.Visible = False
      'End If
      If m_entity.BidType.Value = 1 Then 'AndAlso Me.m_entity.Originated Then
        Me.btnNACCEnumerate.Enabled = True
      Else
        Me.btnNACCEnumerate.Enabled = False
      End If
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, Project)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

    Public Overrides Sub Initialize()
      Province.ListProvinceInComboBox(Me.cmbProvince)
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbBidAs, "BidAs")
      Me.cmbBidAs.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbBidType, "Biddingtype")
      Me.cmbBidType.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbStatus, "project_status")
      Me.cmbStatus.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbBidBondType, "BidBondType")
      Me.cmbBidBondType.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbPenaltyType, "PenatyType")
      Me.cmbPenaltyType.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbPenaltyUnit, "DateIntervalUnit")
      Me.cmbPenaltyUnit.SelectedIndex = 0
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDurationUnit, "DateIntervalUnit")
      Me.cmbDurationUnit.SelectedIndex = 0
    End Sub

#End Region

#Region "Event of Control"
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        Me.Validator.SetRequired(Me.txtCode, False)
        Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.txtCode.ReadOnly = True
        m_oldCode = Me.txtCode.Text
        Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        Me.m_entity.Code = ""
        Me.m_entity.AutoGen = True
      Else
        Me.Validator.SetRequired(Me.txtCode, True)
        Me.txtCode.Text = m_oldCode
        Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Private Sub ShowEmployee(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEngineer.Click, ibtnShowEstimator.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    Private Sub ibtnShowEngineerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEngineerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New RunningEmployee, AddressOf SetEngineer)
    End Sub
    Private Sub ibtnShowEstimatorDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowEstimatorDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New RunningEmployee, AddressOf SetEstimator)
    End Sub
    Private Sub SetEngineer(ByVal e As ISimpleEntity)
      Me.txtEngineerCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or Employee.GetEmployee(txtEngineerCode, txtEngineerName, Me.m_entity.Engineer)
    End Sub
    Private Sub SetEstimator(ByVal e As ISimpleEntity)
      Me.txtEstimatorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or Employee.GetEmployee(txtEstimatorCode, txtEstimatorName, Me.m_entity.Estimator)
    End Sub

    Private Sub ShowCustomer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomer.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Customer)
    End Sub
    Private Sub ibtnShowCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New ContactCustomer, AddressOf SetCustomer)
    End Sub
    Private Sub SetCustomer(ByVal e As ISimpleEntity)
      Me.txtCustomerCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Customer).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcustomercode", "txtcustomername"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Employee).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtengineercode", "txtengineername", "txtestimatorcode", "txtestimatorname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Customer).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
        Dim entity As New Customer(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcustomercode", "txtcustomername"
              'Me.SetCustomer(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New Employee).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Employee).FullClassName))
        Dim entity As New Employee(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtengineercode", "txtengineername"
              'Me.SetEngineer(entity)
            Case "txtestimatorcode", "txtestimatorname"
              'Me.SetEstimator(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New Project).DetailPanelIcon
      End Get
    End Property
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub btnNACCEnumerate_Click(sender As System.Object, e As System.EventArgs) Handles btnNACCEnumerate.Click
      Dim dlg As Form = New ProjectNACCEnumerateView(Me.m_entity)
      dlg.StartPosition = FormStartPosition.CenterScreen
      dlg.ShowDialog()
    End Sub
  End Class
End Namespace
