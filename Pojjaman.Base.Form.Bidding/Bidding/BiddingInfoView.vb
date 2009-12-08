Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BiddingInfoView
        Inherits AbstractEntityDetailPanelView

#Region "Members"
        Private m_entity As LCIItem
        Private m_owner As IListPanel
        Private m_isInitialized As Boolean = False

        Private m_treeManager As TreeManager
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
            'Me.m_helpers = New HelperCollection(Me)
            'Me.LoadHelpers()
        End Sub
#End Region

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
        Friend WithEvents txtEngineer As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
        Friend WithEvents txtProjectedValue As System.Windows.Forms.TextBox
        Friend WithEvents lblProjectedValue As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents lblProvince As System.Windows.Forms.Label
        Friend WithEvents lblLiquidatedType As System.Windows.Forms.Label
        Friend WithEvents txtLiquidatedUnit As System.Windows.Forms.TextBox
        Friend WithEvents lblPer As System.Windows.Forms.Label
        Friend WithEvents grbGeneralInfo As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblBidType As System.Windows.Forms.Label
        Friend WithEvents lblBidAs As System.Windows.Forms.Label
        Friend WithEvents grbBOQType As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbBoqDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents chkSubmited As System.Windows.Forms.CheckBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
        Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton3 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImageButton4 As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblBidEnd As System.Windows.Forms.Label
        Friend WithEvents lblAddendum As System.Windows.Forms.Label
        Friend WithEvents txtAddendum As System.Windows.Forms.TextBox
        Friend WithEvents lblLiquidatedType1 As System.Windows.Forms.Label
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents txtLocation As System.Windows.Forms.TextBox
        Friend WithEvents dtpBidOpenDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblBidOpen As System.Windows.Forms.Label
        Friend WithEvents dtpBidOpenTime As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblBidOpenTime As System.Windows.Forms.Label
        Friend WithEvents grbProjectInformation As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblContact As System.Windows.Forms.Label
        Friend WithEvents lblBaht As System.Windows.Forms.Label
        Friend WithEvents lblPhase As System.Windows.Forms.Label
        Friend WithEvents txtPhase As System.Windows.Forms.TextBox
        Friend WithEvents cmbPhase As System.Windows.Forms.ComboBox
        Friend WithEvents cmbBidType As System.Windows.Forms.ComboBox
        Friend WithEvents cmbBidAs As System.Windows.Forms.ComboBox
        Friend WithEvents chkMat As System.Windows.Forms.CheckBox
        Friend WithEvents chkLabor As System.Windows.Forms.CheckBox
        Friend WithEvents lblEstimator As System.Windows.Forms.Label
        Friend WithEvents txtEstimator As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtEstimator1 As System.Windows.Forms.TextBox
        Friend WithEvents txtPenalty As System.Windows.Forms.TextBox
        Friend WithEvents lblPenalty As System.Windows.Forms.Label
        Friend WithEvents chkEquip As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BiddingInfoView))
            Me.grbBidInfo = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblBidEndTime = New System.Windows.Forms.Label
            Me.dtpBidEndTime = New System.Windows.Forms.DateTimePicker
            Me.lblBidEnd = New System.Windows.Forms.Label
            Me.dtpBidEndDate = New System.Windows.Forms.DateTimePicker
            Me.lblBidStartTime = New System.Windows.Forms.Label
            Me.dtpBidStartTime = New System.Windows.Forms.DateTimePicker
            Me.lblBidStartDate = New System.Windows.Forms.Label
            Me.dtpBidStartDate = New System.Windows.Forms.DateTimePicker
            Me.txtBidBond = New System.Windows.Forms.TextBox
            Me.lblBidBond = New System.Windows.Forms.Label
            Me.lblStatus = New System.Windows.Forms.Label
            Me.lblAddendum = New System.Windows.Forms.Label
            Me.txtAddendum = New System.Windows.Forms.TextBox
            Me.lblLiquidatedType1 = New System.Windows.Forms.Label
            Me.lblLocation = New System.Windows.Forms.Label
            Me.txtLocation = New System.Windows.Forms.TextBox
            Me.dtpBidOpenDate = New System.Windows.Forms.DateTimePicker
            Me.lblBidOpen = New System.Windows.Forms.Label
            Me.dtpBidOpenTime = New System.Windows.Forms.DateTimePicker
            Me.lblBidOpenTime = New System.Windows.Forms.Label
            Me.lblBidCode = New System.Windows.Forms.Label
            Me.txtBidCode = New System.Windows.Forms.TextBox
            Me.grbProjectInformation = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbProvince = New System.Windows.Forms.ComboBox
            Me.txtLiquidatedUnit = New System.Windows.Forms.TextBox
            Me.lblPer = New System.Windows.Forms.Label
            Me.lblLiquidatedType = New System.Windows.Forms.Label
            Me.txtPenalty = New System.Windows.Forms.TextBox
            Me.lblPenalty = New System.Windows.Forms.Label
            Me.lblProvince = New System.Windows.Forms.Label
            Me.lblAddress = New System.Windows.Forms.Label
            Me.txtAddress = New System.Windows.Forms.TextBox
            Me.txtProjectedValue = New System.Windows.Forms.TextBox
            Me.lblProjectedValue = New System.Windows.Forms.Label
            Me.lblCompletionDate = New System.Windows.Forms.Label
            Me.dtpCompletionDate = New System.Windows.Forms.DateTimePicker
            Me.txtContact = New System.Windows.Forms.TextBox
            Me.lblEngineer = New System.Windows.Forms.Label
            Me.txtEngineer = New System.Windows.Forms.TextBox
            Me.lblContact = New System.Windows.Forms.Label
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.txtCustomer = New System.Windows.Forms.TextBox
            Me.lblBaht = New System.Windows.Forms.Label
            Me.ImageButton3 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton4 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblPhase = New System.Windows.Forms.Label
            Me.txtPhase = New System.Windows.Forms.TextBox
            Me.cmbPhase = New System.Windows.Forms.ComboBox
            Me.grbGeneralInfo = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbBidType = New System.Windows.Forms.ComboBox
            Me.cmbBidAs = New System.Windows.Forms.ComboBox
            Me.lblBidAs = New System.Windows.Forms.Label
            Me.lblBidType = New System.Windows.Forms.Label
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.lblNote = New System.Windows.Forms.Label
            Me.grbBOQType = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.chkMat = New System.Windows.Forms.CheckBox
            Me.chkLabor = New System.Windows.Forms.CheckBox
            Me.chkEquip = New System.Windows.Forms.CheckBox
            Me.grbBoqDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtEstimator1 = New System.Windows.Forms.TextBox
            Me.ImageButton1 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImageButton2 = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.chkSubmited = New System.Windows.Forms.CheckBox
            Me.lblEstimator = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtEstimator = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.grbBidInfo.SuspendLayout()
            Me.grbProjectInformation.SuspendLayout()
            Me.grbGeneralInfo.SuspendLayout()
            Me.grbBOQType.SuspendLayout()
            Me.grbBoqDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbBidInfo
            '
            Me.grbBidInfo.Controls.Add(Me.cmbStatus)
            Me.grbBidInfo.Controls.Add(Me.lblBidEndTime)
            Me.grbBidInfo.Controls.Add(Me.dtpBidEndTime)
            Me.grbBidInfo.Controls.Add(Me.lblBidEnd)
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
            Me.grbBidInfo.Controls.Add(Me.lblLiquidatedType1)
            Me.grbBidInfo.Controls.Add(Me.lblLocation)
            Me.grbBidInfo.Controls.Add(Me.txtLocation)
            Me.grbBidInfo.Controls.Add(Me.dtpBidOpenDate)
            Me.grbBidInfo.Controls.Add(Me.lblBidOpen)
            Me.grbBidInfo.Controls.Add(Me.dtpBidOpenTime)
            Me.grbBidInfo.Controls.Add(Me.lblBidOpenTime)
            Me.grbBidInfo.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbBidInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbBidInfo.Location = New System.Drawing.Point(8, 88)
            Me.grbBidInfo.Name = "grbBidInfo"
            Me.grbBidInfo.Size = New System.Drawing.Size(424, 168)
            Me.grbBidInfo.TabIndex = 1
            Me.grbBidInfo.TabStop = False
            Me.grbBidInfo.Text = "รายละเอียดการประมูล"
            '
            'cmbStatus
            '
            Me.cmbStatus.Location = New System.Drawing.Point(96, 16)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(144, 21)
            Me.cmbStatus.TabIndex = 146
            '
            'lblBidEndTime
            '
            Me.lblBidEndTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidEndTime.ForeColor = System.Drawing.Color.Black
            Me.lblBidEndTime.Location = New System.Drawing.Point(200, 112)
            Me.lblBidEndTime.Name = "lblBidEndTime"
            Me.lblBidEndTime.Size = New System.Drawing.Size(32, 18)
            Me.lblBidEndTime.TabIndex = 136
            Me.lblBidEndTime.Text = "เวลา"
            Me.lblBidEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBidEndTime
            '
            Me.dtpBidEndTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidEndTime.CustomFormat = "dd/MM/yyyy"
            Me.dtpBidEndTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.dtpBidEndTime.Location = New System.Drawing.Point(232, 112)
            Me.dtpBidEndTime.Name = "dtpBidEndTime"
            Me.dtpBidEndTime.Size = New System.Drawing.Size(104, 21)
            Me.dtpBidEndTime.TabIndex = 135
            '
            'lblBidEnd
            '
            Me.lblBidEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidEnd.ForeColor = System.Drawing.Color.Black
            Me.lblBidEnd.Location = New System.Drawing.Point(8, 112)
            Me.lblBidEnd.Name = "lblBidEnd"
            Me.lblBidEnd.Size = New System.Drawing.Size(88, 18)
            Me.lblBidEnd.TabIndex = 134
            Me.lblBidEnd.Text = "วันที่สิ้นสุดการยื่น:"
            Me.lblBidEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBidEndDate
            '
            Me.dtpBidEndDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidEndDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpBidEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpBidEndDate.Location = New System.Drawing.Point(96, 112)
            Me.dtpBidEndDate.Name = "dtpBidEndDate"
            Me.dtpBidEndDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpBidEndDate.TabIndex = 133
            '
            'lblBidStartTime
            '
            Me.lblBidStartTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidStartTime.ForeColor = System.Drawing.Color.Black
            Me.lblBidStartTime.Location = New System.Drawing.Point(200, 88)
            Me.lblBidStartTime.Name = "lblBidStartTime"
            Me.lblBidStartTime.Size = New System.Drawing.Size(32, 18)
            Me.lblBidStartTime.TabIndex = 132
            Me.lblBidStartTime.Text = "เวลา"
            Me.lblBidStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBidStartTime
            '
            Me.dtpBidStartTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidStartTime.CustomFormat = "dd/MM/yyyy"
            Me.dtpBidStartTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.dtpBidStartTime.Location = New System.Drawing.Point(232, 88)
            Me.dtpBidStartTime.Name = "dtpBidStartTime"
            Me.dtpBidStartTime.Size = New System.Drawing.Size(104, 21)
            Me.dtpBidStartTime.TabIndex = 131
            '
            'lblBidStartDate
            '
            Me.lblBidStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidStartDate.ForeColor = System.Drawing.Color.Black
            Me.lblBidStartDate.Location = New System.Drawing.Point(8, 88)
            Me.lblBidStartDate.Name = "lblBidStartDate"
            Me.lblBidStartDate.Size = New System.Drawing.Size(88, 18)
            Me.lblBidStartDate.TabIndex = 130
            Me.lblBidStartDate.Text = "วันที่ยื่นซอง:"
            Me.lblBidStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBidStartDate
            '
            Me.dtpBidStartDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidStartDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpBidStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpBidStartDate.Location = New System.Drawing.Point(96, 88)
            Me.dtpBidStartDate.Name = "dtpBidStartDate"
            Me.dtpBidStartDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpBidStartDate.TabIndex = 129
            '
            'txtBidBond
            '
            Me.txtBidBond.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtBidBond, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBidBond, "")
            Me.txtBidBond.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBidBond, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBidBond, System.Drawing.Color.Empty)
            Me.txtBidBond.Location = New System.Drawing.Point(96, 40)
            Me.txtBidBond.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtBidBond, "")
            Me.Validator.SetMinValue(Me.txtBidBond, "")
            Me.txtBidBond.Name = "txtBidBond"
            Me.Validator.SetRegularExpression(Me.txtBidBond, "")
            Me.Validator.SetRequired(Me.txtBidBond, False)
            Me.txtBidBond.Size = New System.Drawing.Size(104, 21)
            Me.txtBidBond.TabIndex = 127
            Me.txtBidBond.Text = ""
            '
            'lblBidBond
            '
            Me.lblBidBond.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidBond.Location = New System.Drawing.Point(16, 40)
            Me.lblBidBond.Name = "lblBidBond"
            Me.lblBidBond.Size = New System.Drawing.Size(80, 21)
            Me.lblBidBond.TabIndex = 128
            Me.lblBidBond.Text = "หลักประกันซอง:"
            Me.lblBidBond.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.Location = New System.Drawing.Point(8, 16)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(88, 21)
            Me.lblStatus.TabIndex = 126
            Me.lblStatus.Text = "สถานะการประมูล:"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddendum
            '
            Me.lblAddendum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAddendum.Location = New System.Drawing.Point(224, 16)
            Me.lblAddendum.Name = "lblAddendum"
            Me.lblAddendum.Size = New System.Drawing.Size(88, 21)
            Me.lblAddendum.TabIndex = 126
            Me.lblAddendum.Text = "Addendum#:"
            Me.lblAddendum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAddendum
            '
            Me.txtAddendum.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtAddendum, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAddendum, "")
            Me.txtAddendum.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAddendum, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAddendum, System.Drawing.Color.Empty)
            Me.txtAddendum.Location = New System.Drawing.Point(312, 16)
            Me.txtAddendum.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtAddendum, "")
            Me.Validator.SetMinValue(Me.txtAddendum, "")
            Me.txtAddendum.Name = "txtAddendum"
            Me.Validator.SetRegularExpression(Me.txtAddendum, "")
            Me.Validator.SetRequired(Me.txtAddendum, False)
            Me.txtAddendum.Size = New System.Drawing.Size(104, 21)
            Me.txtAddendum.TabIndex = 125
            Me.txtAddendum.Text = ""
            '
            'lblLiquidatedType1
            '
            Me.lblLiquidatedType1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLiquidatedType1.Location = New System.Drawing.Point(200, 40)
            Me.lblLiquidatedType1.Name = "lblLiquidatedType1"
            Me.lblLiquidatedType1.Size = New System.Drawing.Size(40, 20)
            Me.lblLiquidatedType1.TabIndex = 145
            Me.lblLiquidatedType1.Text = "%,บาท"
            Me.lblLiquidatedType1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLocation
            '
            Me.lblLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLocation.Location = New System.Drawing.Point(16, 64)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(80, 21)
            Me.lblLocation.TabIndex = 128
            Me.lblLocation.Text = "สถานที่ยื่นซอง:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLocation
            '
            Me.txtLocation.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtLocation, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLocation, "")
            Me.txtLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLocation, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLocation, System.Drawing.Color.Empty)
            Me.txtLocation.Location = New System.Drawing.Point(96, 64)
            Me.txtLocation.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtLocation, "")
            Me.Validator.SetMinValue(Me.txtLocation, "")
            Me.txtLocation.Name = "txtLocation"
            Me.Validator.SetRegularExpression(Me.txtLocation, "")
            Me.Validator.SetRequired(Me.txtLocation, False)
            Me.txtLocation.Size = New System.Drawing.Size(320, 21)
            Me.txtLocation.TabIndex = 127
            Me.txtLocation.Text = ""
            '
            'dtpBidOpenDate
            '
            Me.dtpBidOpenDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidOpenDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpBidOpenDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidOpenDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpBidOpenDate.Location = New System.Drawing.Point(96, 136)
            Me.dtpBidOpenDate.Name = "dtpBidOpenDate"
            Me.dtpBidOpenDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpBidOpenDate.TabIndex = 133
            '
            'lblBidOpen
            '
            Me.lblBidOpen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidOpen.ForeColor = System.Drawing.Color.Black
            Me.lblBidOpen.Location = New System.Drawing.Point(8, 136)
            Me.lblBidOpen.Name = "lblBidOpen"
            Me.lblBidOpen.Size = New System.Drawing.Size(88, 18)
            Me.lblBidOpen.TabIndex = 134
            Me.lblBidOpen.Text = "วันที่ประกาศผล:"
            Me.lblBidOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBidOpenTime
            '
            Me.dtpBidOpenTime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidOpenTime.CustomFormat = "dd/MM/yyyy"
            Me.dtpBidOpenTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBidOpenTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
            Me.dtpBidOpenTime.Location = New System.Drawing.Point(232, 136)
            Me.dtpBidOpenTime.Name = "dtpBidOpenTime"
            Me.dtpBidOpenTime.Size = New System.Drawing.Size(104, 21)
            Me.dtpBidOpenTime.TabIndex = 135
            '
            'lblBidOpenTime
            '
            Me.lblBidOpenTime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidOpenTime.ForeColor = System.Drawing.Color.Black
            Me.lblBidOpenTime.Location = New System.Drawing.Point(200, 136)
            Me.lblBidOpenTime.Name = "lblBidOpenTime"
            Me.lblBidOpenTime.Size = New System.Drawing.Size(32, 18)
            Me.lblBidOpenTime.TabIndex = 136
            Me.lblBidOpenTime.Text = "เวลา"
            Me.lblBidOpenTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBidCode
            '
            Me.lblBidCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidCode.Location = New System.Drawing.Point(8, 40)
            Me.lblBidCode.Name = "lblBidCode"
            Me.lblBidCode.Size = New System.Drawing.Size(88, 20)
            Me.lblBidCode.TabIndex = 124
            Me.lblBidCode.Text = "รหัสการประมูล:"
            Me.lblBidCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBidCode
            '
            Me.txtBidCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtBidCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBidCode, "")
            Me.txtBidCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBidCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBidCode, System.Drawing.Color.Empty)
            Me.txtBidCode.Location = New System.Drawing.Point(96, 40)
            Me.txtBidCode.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtBidCode, "")
            Me.Validator.SetMinValue(Me.txtBidCode, "")
            Me.txtBidCode.Name = "txtBidCode"
            Me.Validator.SetRegularExpression(Me.txtBidCode, "")
            Me.Validator.SetRequired(Me.txtBidCode, False)
            Me.txtBidCode.Size = New System.Drawing.Size(160, 21)
            Me.txtBidCode.TabIndex = 7
            Me.txtBidCode.Text = ""
            '
            'grbProjectInformation
            '
            Me.grbProjectInformation.Controls.Add(Me.cmbProvince)
            Me.grbProjectInformation.Controls.Add(Me.txtLiquidatedUnit)
            Me.grbProjectInformation.Controls.Add(Me.lblPer)
            Me.grbProjectInformation.Controls.Add(Me.lblLiquidatedType)
            Me.grbProjectInformation.Controls.Add(Me.txtPenalty)
            Me.grbProjectInformation.Controls.Add(Me.lblPenalty)
            Me.grbProjectInformation.Controls.Add(Me.lblProvince)
            Me.grbProjectInformation.Controls.Add(Me.lblAddress)
            Me.grbProjectInformation.Controls.Add(Me.txtAddress)
            Me.grbProjectInformation.Controls.Add(Me.txtProjectedValue)
            Me.grbProjectInformation.Controls.Add(Me.lblProjectedValue)
            Me.grbProjectInformation.Controls.Add(Me.lblCompletionDate)
            Me.grbProjectInformation.Controls.Add(Me.dtpCompletionDate)
            Me.grbProjectInformation.Controls.Add(Me.txtContact)
            Me.grbProjectInformation.Controls.Add(Me.lblEngineer)
            Me.grbProjectInformation.Controls.Add(Me.txtEngineer)
            Me.grbProjectInformation.Controls.Add(Me.lblContact)
            Me.grbProjectInformation.Controls.Add(Me.lblCustomer)
            Me.grbProjectInformation.Controls.Add(Me.txtCustomer)
            Me.grbProjectInformation.Controls.Add(Me.lblBaht)
            Me.grbProjectInformation.Controls.Add(Me.ImageButton3)
            Me.grbProjectInformation.Controls.Add(Me.ImageButton4)
            Me.grbProjectInformation.Controls.Add(Me.lblPhase)
            Me.grbProjectInformation.Controls.Add(Me.txtPhase)
            Me.grbProjectInformation.Controls.Add(Me.cmbPhase)
            Me.grbProjectInformation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbProjectInformation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbProjectInformation.Location = New System.Drawing.Point(8, 264)
            Me.grbProjectInformation.Name = "grbProjectInformation"
            Me.grbProjectInformation.Size = New System.Drawing.Size(704, 192)
            Me.grbProjectInformation.TabIndex = 2
            Me.grbProjectInformation.TabStop = False
            Me.grbProjectInformation.Text = "Project Information"
            '
            'cmbProvince
            '
            Me.cmbProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbProvince.Location = New System.Drawing.Point(96, 136)
            Me.cmbProvince.Name = "cmbProvince"
            Me.cmbProvince.Size = New System.Drawing.Size(112, 21)
            Me.cmbProvince.TabIndex = 148
            '
            'txtLiquidatedUnit
            '
            Me.txtLiquidatedUnit.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtLiquidatedUnit, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLiquidatedUnit, "")
            Me.txtLiquidatedUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLiquidatedUnit, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLiquidatedUnit, System.Drawing.Color.Empty)
            Me.txtLiquidatedUnit.Location = New System.Drawing.Point(456, 88)
            Me.txtLiquidatedUnit.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtLiquidatedUnit, "")
            Me.Validator.SetMinValue(Me.txtLiquidatedUnit, "")
            Me.txtLiquidatedUnit.Name = "txtLiquidatedUnit"
            Me.Validator.SetRegularExpression(Me.txtLiquidatedUnit, "")
            Me.Validator.SetRequired(Me.txtLiquidatedUnit, False)
            Me.txtLiquidatedUnit.Size = New System.Drawing.Size(104, 21)
            Me.txtLiquidatedUnit.TabIndex = 146
            Me.txtLiquidatedUnit.Text = ""
            '
            'lblPer
            '
            Me.lblPer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPer.Location = New System.Drawing.Point(432, 88)
            Me.lblPer.Name = "lblPer"
            Me.lblPer.Size = New System.Drawing.Size(24, 20)
            Me.lblPer.TabIndex = 147
            Me.lblPer.Text = "ต่อ"
            Me.lblPer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLiquidatedType
            '
            Me.lblLiquidatedType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLiquidatedType.Location = New System.Drawing.Point(392, 88)
            Me.lblLiquidatedType.Name = "lblLiquidatedType"
            Me.lblLiquidatedType.Size = New System.Drawing.Size(40, 20)
            Me.lblLiquidatedType.TabIndex = 145
            Me.lblLiquidatedType.Text = "%,บาท"
            Me.lblLiquidatedType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPenalty
            '
            Me.txtPenalty.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtPenalty, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPenalty, "")
            Me.txtPenalty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPenalty, System.Drawing.Color.Empty)
            Me.txtPenalty.Location = New System.Drawing.Point(288, 88)
            Me.txtPenalty.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtPenalty, "")
            Me.Validator.SetMinValue(Me.txtPenalty, "")
            Me.txtPenalty.Name = "txtPenalty"
            Me.Validator.SetRegularExpression(Me.txtPenalty, "")
            Me.Validator.SetRequired(Me.txtPenalty, False)
            Me.txtPenalty.Size = New System.Drawing.Size(104, 21)
            Me.txtPenalty.TabIndex = 143
            Me.txtPenalty.Text = ""
            '
            'lblPenalty
            '
            Me.lblPenalty.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPenalty.Location = New System.Drawing.Point(232, 88)
            Me.lblPenalty.Name = "lblPenalty"
            Me.lblPenalty.Size = New System.Drawing.Size(56, 20)
            Me.lblPenalty.TabIndex = 144
            Me.lblPenalty.Text = "ค่าปรับ:"
            Me.lblPenalty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProvince
            '
            Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProvince.Location = New System.Drawing.Point(8, 136)
            Me.lblProvince.Name = "lblProvince"
            Me.lblProvince.Size = New System.Drawing.Size(88, 20)
            Me.lblProvince.TabIndex = 142
            Me.lblProvince.Text = "จังหวัด:"
            Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress
            '
            Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAddress.Location = New System.Drawing.Point(8, 112)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(88, 20)
            Me.lblAddress.TabIndex = 140
            Me.lblAddress.Text = "ที่อยู่:"
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAddress
            '
            Me.txtAddress.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAddress, "")
            Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.txtAddress.Location = New System.Drawing.Point(96, 112)
            Me.txtAddress.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtAddress, "")
            Me.Validator.SetMinValue(Me.txtAddress, "")
            Me.txtAddress.Name = "txtAddress"
            Me.Validator.SetRegularExpression(Me.txtAddress, "")
            Me.Validator.SetRequired(Me.txtAddress, False)
            Me.txtAddress.Size = New System.Drawing.Size(552, 21)
            Me.txtAddress.TabIndex = 139
            Me.txtAddress.Text = ""
            '
            'txtProjectedValue
            '
            Me.txtProjectedValue.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtProjectedValue, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectedValue, "")
            Me.txtProjectedValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectedValue, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectedValue, System.Drawing.Color.Empty)
            Me.txtProjectedValue.Location = New System.Drawing.Point(96, 88)
            Me.txtProjectedValue.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtProjectedValue, "")
            Me.Validator.SetMinValue(Me.txtProjectedValue, "")
            Me.txtProjectedValue.Name = "txtProjectedValue"
            Me.Validator.SetRegularExpression(Me.txtProjectedValue, "")
            Me.Validator.SetRequired(Me.txtProjectedValue, False)
            Me.txtProjectedValue.Size = New System.Drawing.Size(112, 21)
            Me.txtProjectedValue.TabIndex = 137
            Me.txtProjectedValue.Text = ""
            '
            'lblProjectedValue
            '
            Me.lblProjectedValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProjectedValue.Location = New System.Drawing.Point(8, 88)
            Me.lblProjectedValue.Name = "lblProjectedValue"
            Me.lblProjectedValue.Size = New System.Drawing.Size(88, 20)
            Me.lblProjectedValue.TabIndex = 138
            Me.lblProjectedValue.Text = "ราคากลาง:"
            Me.lblProjectedValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCompletionDate
            '
            Me.lblCompletionDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCompletionDate.ForeColor = System.Drawing.Color.Black
            Me.lblCompletionDate.Location = New System.Drawing.Point(8, 160)
            Me.lblCompletionDate.Name = "lblCompletionDate"
            Me.lblCompletionDate.Size = New System.Drawing.Size(88, 18)
            Me.lblCompletionDate.TabIndex = 130
            Me.lblCompletionDate.Text = "กำหนดเสร็จ:"
            Me.lblCompletionDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpCompletionDate
            '
            Me.dtpCompletionDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpCompletionDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpCompletionDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpCompletionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpCompletionDate.Location = New System.Drawing.Point(96, 160)
            Me.dtpCompletionDate.Name = "dtpCompletionDate"
            Me.dtpCompletionDate.Size = New System.Drawing.Size(112, 21)
            Me.dtpCompletionDate.TabIndex = 129
            '
            'txtContact
            '
            Me.txtContact.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtContact, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtContact, "")
            Me.txtContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.txtContact.Location = New System.Drawing.Point(96, 40)
            Me.txtContact.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtContact, "")
            Me.Validator.SetMinValue(Me.txtContact, "")
            Me.txtContact.Name = "txtContact"
            Me.Validator.SetRegularExpression(Me.txtContact, "")
            Me.Validator.SetRequired(Me.txtContact, False)
            Me.txtContact.Size = New System.Drawing.Size(552, 21)
            Me.txtContact.TabIndex = 4
            Me.txtContact.Text = ""
            '
            'lblEngineer
            '
            Me.lblEngineer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEngineer.Location = New System.Drawing.Point(8, 64)
            Me.lblEngineer.Name = "lblEngineer"
            Me.lblEngineer.Size = New System.Drawing.Size(88, 20)
            Me.lblEngineer.TabIndex = 124
            Me.lblEngineer.Text = "วิศวกร/สถาปนิก:"
            Me.lblEngineer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEngineer
            '
            Me.txtEngineer.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtEngineer, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEngineer, "")
            Me.txtEngineer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEngineer, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEngineer, System.Drawing.Color.Empty)
            Me.txtEngineer.Location = New System.Drawing.Point(96, 64)
            Me.txtEngineer.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtEngineer, "")
            Me.Validator.SetMinValue(Me.txtEngineer, "")
            Me.txtEngineer.Name = "txtEngineer"
            Me.Validator.SetRegularExpression(Me.txtEngineer, "")
            Me.Validator.SetRequired(Me.txtEngineer, False)
            Me.txtEngineer.Size = New System.Drawing.Size(552, 21)
            Me.txtEngineer.TabIndex = 7
            Me.txtEngineer.Text = ""
            '
            'lblContact
            '
            Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblContact.Location = New System.Drawing.Point(8, 40)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(88, 20)
            Me.lblContact.TabIndex = 123
            Me.lblContact.Text = "ผู้ติดต่อ:"
            Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(8, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(88, 20)
            Me.lblCustomer.TabIndex = 122
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomer
            '
            Me.txtCustomer.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCustomer, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomer, "")
            Me.txtCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomer, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomer, System.Drawing.Color.Empty)
            Me.txtCustomer.Location = New System.Drawing.Point(96, 16)
            Me.txtCustomer.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtCustomer, "")
            Me.Validator.SetMinValue(Me.txtCustomer, "")
            Me.txtCustomer.Name = "txtCustomer"
            Me.Validator.SetRegularExpression(Me.txtCustomer, "")
            Me.Validator.SetRequired(Me.txtCustomer, False)
            Me.txtCustomer.Size = New System.Drawing.Size(552, 21)
            Me.txtCustomer.TabIndex = 6
            Me.txtCustomer.Text = ""
            '
            'lblBaht
            '
            Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBaht.Location = New System.Drawing.Point(208, 88)
            Me.lblBaht.Name = "lblBaht"
            Me.lblBaht.Size = New System.Drawing.Size(32, 20)
            Me.lblBaht.TabIndex = 145
            Me.lblBaht.Text = "บาท"
            Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'ImageButton3
            '
            Me.ImageButton3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton3.Image = CType(resources.GetObject("ImageButton3.Image"), System.Drawing.Image)
            Me.ImageButton3.Location = New System.Drawing.Point(672, 16)
            Me.ImageButton3.Name = "ImageButton3"
            Me.ImageButton3.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton3.TabIndex = 209
            Me.ImageButton3.TabStop = False
            Me.ImageButton3.ThemedImage = CType(resources.GetObject("ImageButton3.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton4
            '
            Me.ImageButton4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton4.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton4.Image = CType(resources.GetObject("ImageButton4.Image"), System.Drawing.Image)
            Me.ImageButton4.Location = New System.Drawing.Point(648, 16)
            Me.ImageButton4.Name = "ImageButton4"
            Me.ImageButton4.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton4.TabIndex = 210
            Me.ImageButton4.TabStop = False
            Me.ImageButton4.ThemedImage = CType(resources.GetObject("ImageButton4.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblPhase
            '
            Me.lblPhase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPhase.Location = New System.Drawing.Point(216, 160)
            Me.lblPhase.Name = "lblPhase"
            Me.lblPhase.Size = New System.Drawing.Size(88, 20)
            Me.lblPhase.TabIndex = 138
            Me.lblPhase.Text = "ระยะเวลาก่อสร้าง:"
            Me.lblPhase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhase
            '
            Me.txtPhase.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtPhase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPhase, "")
            Me.txtPhase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPhase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPhase, System.Drawing.Color.Empty)
            Me.txtPhase.Location = New System.Drawing.Point(304, 160)
            Me.txtPhase.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtPhase, "")
            Me.Validator.SetMinValue(Me.txtPhase, "")
            Me.txtPhase.Name = "txtPhase"
            Me.Validator.SetRegularExpression(Me.txtPhase, "")
            Me.Validator.SetRequired(Me.txtPhase, False)
            Me.txtPhase.Size = New System.Drawing.Size(112, 21)
            Me.txtPhase.TabIndex = 137
            Me.txtPhase.Text = ""
            '
            'cmbPhase
            '
            Me.cmbPhase.Location = New System.Drawing.Point(416, 160)
            Me.cmbPhase.Name = "cmbPhase"
            Me.cmbPhase.Size = New System.Drawing.Size(88, 21)
            Me.cmbPhase.TabIndex = 146
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
            Me.grbGeneralInfo.Location = New System.Drawing.Point(432, 120)
            Me.grbGeneralInfo.Name = "grbGeneralInfo"
            Me.grbGeneralInfo.Size = New System.Drawing.Size(264, 136)
            Me.grbGeneralInfo.TabIndex = 3
            Me.grbGeneralInfo.TabStop = False
            Me.grbGeneralInfo.Text = "ทั่วไป"
            '
            'cmbBidType
            '
            Me.cmbBidType.Location = New System.Drawing.Point(104, 16)
            Me.cmbBidType.Name = "cmbBidType"
            Me.cmbBidType.Size = New System.Drawing.Size(144, 21)
            Me.cmbBidType.TabIndex = 148
            '
            'cmbBidAs
            '
            Me.cmbBidAs.Location = New System.Drawing.Point(104, 40)
            Me.cmbBidAs.Name = "cmbBidAs"
            Me.cmbBidAs.Size = New System.Drawing.Size(144, 21)
            Me.cmbBidAs.TabIndex = 147
            '
            'lblBidAs
            '
            Me.lblBidAs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidAs.Location = New System.Drawing.Point(16, 40)
            Me.lblBidAs.Name = "lblBidAs"
            Me.lblBidAs.Size = New System.Drawing.Size(88, 20)
            Me.lblBidAs.TabIndex = 124
            Me.lblBidAs.Text = "ประมูลในฐานะ:"
            Me.lblBidAs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBidType
            '
            Me.lblBidType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBidType.Location = New System.Drawing.Point(8, 16)
            Me.lblBidType.Name = "lblBidType"
            Me.lblBidType.Size = New System.Drawing.Size(96, 20)
            Me.lblBidType.TabIndex = 122
            Me.lblBidType.Text = "ประเภทการประมูล:"
            Me.lblBidType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(8, 72)
            Me.txtNote.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(248, 56)
            Me.txtNote.TabIndex = 132
            Me.txtNote.Text = ""
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(8, 56)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(88, 20)
            Me.lblNote.TabIndex = 133
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
            Me.grbBOQType.Location = New System.Drawing.Point(536, 40)
            Me.grbBOQType.Name = "grbBOQType"
            Me.grbBOQType.Size = New System.Drawing.Size(160, 80)
            Me.grbBOQType.TabIndex = 125
            Me.grbBOQType.TabStop = False
            Me.grbBOQType.Text = "ข้อมูลรายการ BOQ"
            '
            'chkMat
            '
            Me.chkMat.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkMat.Location = New System.Drawing.Point(8, 16)
            Me.chkMat.Name = "chkMat"
            Me.chkMat.Size = New System.Drawing.Size(104, 16)
            Me.chkMat.TabIndex = 0
            Me.chkMat.Text = "ค่าวัสดุ"
            '
            'chkLabor
            '
            Me.chkLabor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkLabor.Location = New System.Drawing.Point(8, 36)
            Me.chkLabor.Name = "chkLabor"
            Me.chkLabor.Size = New System.Drawing.Size(104, 16)
            Me.chkLabor.TabIndex = 0
            Me.chkLabor.Text = "ค่าแรง"
            '
            'chkEquip
            '
            Me.chkEquip.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkEquip.Location = New System.Drawing.Point(8, 56)
            Me.chkEquip.Name = "chkEquip"
            Me.chkEquip.TabIndex = 1
            Me.chkEquip.Text = "ค่าเครื่องจักร"
            '
            'grbBoqDetail
            '
            Me.grbBoqDetail.Controls.Add(Me.txtEstimator1)
            Me.grbBoqDetail.Controls.Add(Me.ImageButton1)
            Me.grbBoqDetail.Controls.Add(Me.ImageButton2)
            Me.grbBoqDetail.Controls.Add(Me.chkSubmited)
            Me.grbBoqDetail.Controls.Add(Me.lblEstimator)
            Me.grbBoqDetail.Controls.Add(Me.txtName)
            Me.grbBoqDetail.Controls.Add(Me.lblName)
            Me.grbBoqDetail.Controls.Add(Me.lblCode)
            Me.grbBoqDetail.Controls.Add(Me.txtCode)
            Me.grbBoqDetail.Controls.Add(Me.grbBOQType)
            Me.grbBoqDetail.Controls.Add(Me.txtEstimator)
            Me.grbBoqDetail.Controls.Add(Me.grbBidInfo)
            Me.grbBoqDetail.Controls.Add(Me.grbGeneralInfo)
            Me.grbBoqDetail.Controls.Add(Me.txtBidCode)
            Me.grbBoqDetail.Controls.Add(Me.lblBidCode)
            Me.grbBoqDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbBoqDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbBoqDetail.Location = New System.Drawing.Point(8, 0)
            Me.grbBoqDetail.Name = "grbBoqDetail"
            Me.grbBoqDetail.Size = New System.Drawing.Size(704, 264)
            Me.grbBoqDetail.TabIndex = 126
            Me.grbBoqDetail.TabStop = False
            Me.grbBoqDetail.Text = "รายละเอียด BOQ"
            '
            'txtEstimator1
            '
            Me.txtEstimator1.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtEstimator1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEstimator1, "")
            Me.txtEstimator1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEstimator1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEstimator1, System.Drawing.Color.Empty)
            Me.txtEstimator1.Location = New System.Drawing.Point(200, 64)
            Me.txtEstimator1.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtEstimator1, "")
            Me.Validator.SetMinValue(Me.txtEstimator1, "")
            Me.txtEstimator1.Name = "txtEstimator1"
            Me.Validator.SetRegularExpression(Me.txtEstimator1, "")
            Me.Validator.SetRequired(Me.txtEstimator1, False)
            Me.txtEstimator1.Size = New System.Drawing.Size(280, 21)
            Me.txtEstimator1.TabIndex = 211
            Me.txtEstimator1.Text = ""
            '
            'ImageButton1
            '
            Me.ImageButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton1.Image = CType(resources.GetObject("ImageButton1.Image"), System.Drawing.Image)
            Me.ImageButton1.Location = New System.Drawing.Point(504, 64)
            Me.ImageButton1.Name = "ImageButton1"
            Me.ImageButton1.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton1.TabIndex = 209
            Me.ImageButton1.TabStop = False
            Me.ImageButton1.ThemedImage = CType(resources.GetObject("ImageButton1.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImageButton2
            '
            Me.ImageButton2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImageButton2.ForeColor = System.Drawing.SystemColors.Control
            Me.ImageButton2.Image = CType(resources.GetObject("ImageButton2.Image"), System.Drawing.Image)
            Me.ImageButton2.Location = New System.Drawing.Point(480, 64)
            Me.ImageButton2.Name = "ImageButton2"
            Me.ImageButton2.Size = New System.Drawing.Size(24, 23)
            Me.ImageButton2.TabIndex = 210
            Me.ImageButton2.TabStop = False
            Me.ImageButton2.ThemedImage = CType(resources.GetObject("ImageButton2.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkSubmited
            '
            Me.chkSubmited.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkSubmited.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.chkSubmited.ForeColor = System.Drawing.Color.Black
            Me.chkSubmited.Location = New System.Drawing.Point(536, 16)
            Me.chkSubmited.Name = "chkSubmited"
            Me.chkSubmited.Size = New System.Drawing.Size(88, 20)
            Me.chkSubmited.TabIndex = 131
            Me.chkSubmited.TabStop = False
            Me.chkSubmited.Text = "ยื่นประมูลแล้ว"
            '
            'lblEstimator
            '
            Me.lblEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEstimator.Location = New System.Drawing.Point(8, 62)
            Me.lblEstimator.Name = "lblEstimator"
            Me.lblEstimator.Size = New System.Drawing.Size(88, 20)
            Me.lblEstimator.TabIndex = 129
            Me.lblEstimator.Text = "ผู้ประมาณราคา:"
            Me.lblEstimator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(96, 16)
            Me.txtName.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(432, 21)
            Me.txtName.TabIndex = 124
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.Location = New System.Drawing.Point(24, 16)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(72, 20)
            Me.lblName.TabIndex = 127
            Me.lblName.Text = "โครงการ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(256, 40)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(72, 20)
            Me.lblCode.TabIndex = 126
            Me.lblCode.Text = "Job Number:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.txtCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(328, 40)
            Me.txtCode.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(152, 21)
            Me.txtCode.TabIndex = 125
            Me.txtCode.Text = ""
            '
            'txtEstimator
            '
            Me.txtEstimator.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtEstimator, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEstimator, "")
            Me.txtEstimator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEstimator, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEstimator, System.Drawing.Color.Empty)
            Me.txtEstimator.Location = New System.Drawing.Point(96, 64)
            Me.txtEstimator.MaxLength = 4
            Me.Validator.SetMaxValue(Me.txtEstimator, "")
            Me.Validator.SetMinValue(Me.txtEstimator, "")
            Me.txtEstimator.Name = "txtEstimator"
            Me.Validator.SetRegularExpression(Me.txtEstimator, "")
            Me.Validator.SetRequired(Me.txtEstimator, False)
            Me.txtEstimator.Size = New System.Drawing.Size(104, 21)
            Me.txtEstimator.TabIndex = 137
            Me.txtEstimator.Text = ""
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
            'BiddingInfoView
            '
            Me.Controls.Add(Me.grbBoqDetail)
            Me.Controls.Add(Me.grbProjectInformation)
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "BiddingInfoView"
            Me.Size = New System.Drawing.Size(720, 464)
            Me.grbBidInfo.ResumeLayout(False)
            Me.grbProjectInformation.ResumeLayout(False)
            Me.grbGeneralInfo.ResumeLayout(False)
            Me.grbBOQType.ResumeLayout(False)
            Me.grbBoqDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Methods"

#End Region

#Region "Overrides"
        Public Overrides Sub CheckFormEnable()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, LCIItem)
                'Hack:
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property


        Public Overrides Sub ClearDetail()
            'txtlv1.Text = ""
            'txtlv2.Text = ""
            'txtlv3.Text = ""
            'txtlv4.Text = ""
            'txtlv5.Text = ""
            'txtName.Text = ""
            'txtAltName.Text = ""
            'chkControl.Checked = False
        End Sub
        Public Overrides Sub Initialize()
            Dim dt As DataTable = Province.GetProvinceList
            Me.cmbProvince.DataSource = dt
            Me.cmbProvince.ValueMember = "province_id"
            Me.cmbProvince.DisplayMember = "province_name"
        End Sub

        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbBidInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.grbBidInfo}")
            Me.lblBidCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidCode}")
            Me.lblStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblStatus}")
            Me.lblBidBond.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidBond}")
            Me.lblBidStartDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidStartDate}")
            Me.lblBidStartTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidStartTime}")
            Me.lblBidEndTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidEndTime}")
            Me.lblCompletionDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblCompletionDate}")
            Me.lblEngineer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblEngineer}")
            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblCustomer}")
            Me.lblProjectedValue.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblProjectedValue}")
            Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblAddress}")
            Me.lblProvince.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblProvince}")
            Me.lblLiquidatedType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblLiquidatedType}")
            Me.lblPer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblPer}")
            Me.grbGeneralInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.grbGeneralInfo}")
            Me.lblBidType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidType}")
            Me.lblBidAs.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidAs}")
            Me.grbBOQType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.grbBOQType}")
            Me.grbBoqDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.grbBoqDetail}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblCode}")
            Me.chkSubmited.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.chkSubmited}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblNote}")
            Me.lblBidEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidEnd}")
            Me.lblAddendum.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblAddendum}")
            Me.lblLiquidatedType1.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblLiquidatedType1}")
            Me.lblLocation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblLocation}")
            Me.lblBidOpen.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidOpen}")
            Me.lblBidOpenTime.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblBidOpenTime}")
            Me.grbProjectInformation.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.grbProjectInformation}")
            Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblContact}")
            Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
            Me.lblPhase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblPhase}")
            Me.chkMat.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.chkMat}")
            Me.chkLabor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.chkLabor}")
            Me.chkEquip.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.chkEquip}")
            Me.lblEstimator.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblEstimator}")
            Me.lblPenalty.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.BiddingInfoView.lblPenalty}")


        End Sub

        Protected Overrides Sub EventWiring()
            'AddHandler txtlv1.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtlv2.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtlv3.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtlv4.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtlv5.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty
            'AddHandler chkControl.CheckedChanged, AddressOf Me.ChangeProperty
        End Sub

        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            'txtlv1.Text = m_entity.Lv1
            'txtlv2.Text = m_entity.Lv2
            'txtlv3.Text = m_entity.Lv3
            'txtlv4.Text = m_entity.Lv4
            'txtlv5.Text = m_entity.Lv5
            'txtName.Text = m_entity.Name
            'txtAltName.Text = m_entity.AlternateName
            'If Not m_entity.Parent Is Nothing AndAlso m_entity.Parent.Valid Then
            '    Me.txtParent.Text = m_entity.Parent.Name
            'Else
            '    Me.txtParent.Text = "Root" 'Todo
            'End If
            'If Me.m_entity.IsControlGroup Then
            '    chkControl.Checked = True
            'Else
            '    chkControl.Checked = False
            'End If
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                'Case "txtlv1"
                '    Me.m_entity.Lv1 = txtlv1.Text
                'Case "txtlv2"
                '    Me.m_entity.Lv2 = txtlv2.Text
                'Case "txtlv3"
                '    Me.m_entity.Lv3 = txtlv3.Text
                'Case "txtlv4"
                '    Me.m_entity.Lv4 = txtlv4.Text
                'Case "txtlv5"
                '    Me.m_entity.Lv5 = txtlv5.Text
                'Case "txtname"
                '    Me.m_entity.Name = txtName.Text
                'Case "txtaltname"
                '    Me.m_entity.AlternateName = txtAltName.Text
                'Case "chkcontrol"
                '    Me.m_entity.IsControlGroup = chkControl.Checked
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            CheckFormEnable()
        End Sub
#End Region

#Region "Event"
        Private Sub ibtnGenCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
#End Region

        Private Sub BiddingInfoView_WorkbenchWindowChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.WorkbenchWindowChanged
            'Dim myListPanelView As GroupPanelView = CType(Me.WorkbenchWindow.SubViewContents(0), GroupPanelView)
            'AddHandler myListPanelView.Saved, AddressOf EntitySaved
        End Sub
        Private Sub EntitySaved(ByVal sender As Object, ByVal e As SaveEventArgs)

        End Sub

        Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged

        End Sub

        Private Sub txtLocation_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocation.TextChanged

        End Sub

        Private Sub txtEstimater_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEstimator.TextChanged

        End Sub

        Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged

        End Sub
    End Class
End Namespace
