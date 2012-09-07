Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels

    Public Class SupplierAuxDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IReversibleEntityProperty

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
        Friend WithEvents PrimaryGroupBoxControl As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents picMap As System.Windows.Forms.PictureBox
        Friend WithEvents txtHomePage As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblbirthDate As System.Windows.Forms.Label
        Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblHomePage As System.Windows.Forms.Label
        Friend WithEvents picImage As System.Windows.Forms.PictureBox
        Friend WithEvents lblLastContactDate As System.Windows.Forms.Label
        Friend WithEvents dtpLastContactDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblLastPayDate As System.Windows.Forms.Label
        Friend WithEvents dtpLastPayDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblSummaryDiscount As System.Windows.Forms.Label
        Friend WithEvents txtSummaryDiscount As System.Windows.Forms.TextBox
        Friend WithEvents txtDetailDiscount As System.Windows.Forms.TextBox
        Friend WithEvents lblDetailDiscount As System.Windows.Forms.Label
        Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxRate As System.Windows.Forms.Label
        Friend WithEvents txtCheckAmountOnHand As System.Windows.Forms.TextBox
        Friend WithEvents lblCreditType As System.Windows.Forms.Label
        Friend WithEvents lblCreditPeriod As System.Windows.Forms.Label
        Friend WithEvents txtCreditPeriod As System.Windows.Forms.TextBox
        Friend WithEvents lblCreditPeriodUnit As System.Windows.Forms.Label
        Friend WithEvents lblCreditAmount As System.Windows.Forms.Label
        Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
        Friend WithEvents txtCreditPeriodFromTransport As System.Windows.Forms.TextBox
        Friend WithEvents lblCreditPeriodFromTransport As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents cmbCreditType As System.Windows.Forms.ComboBox
        Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
        Friend WithEvents lblReceiveDate As System.Windows.Forms.Label
        Friend WithEvents lblReceiveWeek As System.Windows.Forms.Label
        Friend WithEvents txtReceiveDates As System.Windows.Forms.TextBox
        Friend WithEvents txtReceiveWeeks As System.Windows.Forms.TextBox
        Friend WithEvents lblReceiveDay As System.Windows.Forms.Label
        Friend WithEvents ImbBillRecDay As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBillRecWeeks As System.Windows.Forms.TextBox
        Friend WithEvents txtBillRecDates As System.Windows.Forms.TextBox
        Friend WithEvents lblBillRecWeek As System.Windows.Forms.Label
        Friend WithEvents lblBillRecDate As System.Windows.Forms.Label
        Friend WithEvents lblBillRecDay As System.Windows.Forms.Label
        Friend WithEvents txtBillRecDays As System.Windows.Forms.TextBox
        Friend WithEvents ImbBillRecDate As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbBillRecWeek As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtReceiveDays As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtbirthdate As System.Windows.Forms.TextBox
        Friend WithEvents txtLastContactDate As System.Windows.Forms.TextBox
        Friend WithEvents txtLastPaydate As System.Windows.Forms.TextBox
        Friend WithEvents lblCheckAmountOnHand As System.Windows.Forms.Label
        Friend WithEvents grbReceive As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbBillRec As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbSupplier As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbFinancial As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbCredit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ImbReceiveDay As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbReceiveDate As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbReceiveWeek As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnLoadMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnShowMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblPicSize As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SupplierAuxDetailView))
            Me.PrimaryGroupBoxControl = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnLoadMap = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnClearMap = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnShowMap = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbReceive = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ImbReceiveWeek = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImbReceiveDate = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImbReceiveDay = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblReceiveDate = New System.Windows.Forms.Label
            Me.lblReceiveWeek = New System.Windows.Forms.Label
            Me.txtReceiveDates = New System.Windows.Forms.TextBox
            Me.txtReceiveDays = New System.Windows.Forms.TextBox
            Me.txtReceiveWeeks = New System.Windows.Forms.TextBox
            Me.lblReceiveDay = New System.Windows.Forms.Label
            Me.grbBillRec = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ImbBillRecDay = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtBillRecWeeks = New System.Windows.Forms.TextBox
            Me.txtBillRecDates = New System.Windows.Forms.TextBox
            Me.lblBillRecWeek = New System.Windows.Forms.Label
            Me.lblBillRecDate = New System.Windows.Forms.Label
            Me.lblBillRecDay = New System.Windows.Forms.Label
            Me.txtBillRecDays = New System.Windows.Forms.TextBox
            Me.ImbBillRecDate = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImbBillRecWeek = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnOk = New System.Windows.Forms.Button
            Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.pnlPicHolder = New System.Windows.Forms.Panel
            Me.picMap = New System.Windows.Forms.PictureBox
            Me.grbSupplier = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtLastContactDate = New System.Windows.Forms.TextBox
            Me.txtbirthdate = New System.Windows.Forms.TextBox
            Me.txtHomePage = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblbirthDate = New System.Windows.Forms.Label
            Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker
            Me.lblHomePage = New System.Windows.Forms.Label
            Me.picImage = New System.Windows.Forms.PictureBox
            Me.lblLastContactDate = New System.Windows.Forms.Label
            Me.dtpLastContactDate = New System.Windows.Forms.DateTimePicker
            Me.grbFinancial = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtLastPaydate = New System.Windows.Forms.TextBox
            Me.lblLastPayDate = New System.Windows.Forms.Label
            Me.dtpLastPayDate = New System.Windows.Forms.DateTimePicker
            Me.lblSummaryDiscount = New System.Windows.Forms.Label
            Me.txtSummaryDiscount = New System.Windows.Forms.TextBox
            Me.txtDetailDiscount = New System.Windows.Forms.TextBox
            Me.lblDetailDiscount = New System.Windows.Forms.Label
            Me.txtTaxRate = New System.Windows.Forms.TextBox
            Me.lblTaxRate = New System.Windows.Forms.Label
            Me.lblCheckAmountOnHand = New System.Windows.Forms.Label
            Me.txtCheckAmountOnHand = New System.Windows.Forms.TextBox
            Me.grbCredit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbCreditType = New System.Windows.Forms.ComboBox
            Me.txtCreditPeriod = New System.Windows.Forms.TextBox
            Me.txtCreditAmount = New System.Windows.Forms.TextBox
            Me.txtCreditPeriodFromTransport = New System.Windows.Forms.TextBox
            Me.lblCreditType = New System.Windows.Forms.Label
            Me.lblCreditPeriod = New System.Windows.Forms.Label
            Me.lblCreditPeriodUnit = New System.Windows.Forms.Label
            Me.lblCreditAmount = New System.Windows.Forms.Label
            Me.lblCreditPeriodFromTransport = New System.Windows.Forms.Label
            Me.btnCancel = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.lblPicSize = New System.Windows.Forms.Label
            Me.PrimaryGroupBoxControl.SuspendLayout()
            Me.grbReceive.SuspendLayout()
            Me.grbBillRec.SuspendLayout()
            Me.grbMap.SuspendLayout()
            Me.pnlPicHolder.SuspendLayout()
            Me.grbSupplier.SuspendLayout()
            Me.grbFinancial.SuspendLayout()
            Me.grbCredit.SuspendLayout()
            Me.SuspendLayout()
            '
            'PrimaryGroupBoxControl
            '
            Me.PrimaryGroupBoxControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnLoadMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnClearMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnShowMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbReceive)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbBillRec)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnOk)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbSupplier)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbFinancial)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbCredit)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnCancel)
            Me.PrimaryGroupBoxControl.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.PrimaryGroupBoxControl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.PrimaryGroupBoxControl.ForeColor = System.Drawing.Color.Blue
            Me.PrimaryGroupBoxControl.Location = New System.Drawing.Point(8, 8)
            Me.PrimaryGroupBoxControl.Name = "PrimaryGroupBoxControl"
            Me.PrimaryGroupBoxControl.Size = New System.Drawing.Size(840, 424)
            Me.PrimaryGroupBoxControl.TabIndex = 0
            Me.PrimaryGroupBoxControl.TabStop = False
            Me.PrimaryGroupBoxControl.Text = "ข้อมูลหลัก"
            '
            'btnLoadMap
            '
            Me.btnLoadMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLoadMap.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLoadMap.Image = CType(resources.GetObject("btnLoadMap.Image"), System.Drawing.Image)
            Me.btnLoadMap.Location = New System.Drawing.Point(216, 368)
            Me.btnLoadMap.Name = "btnLoadMap"
            Me.btnLoadMap.Size = New System.Drawing.Size(24, 23)
            Me.btnLoadMap.TabIndex = 55
            Me.btnLoadMap.TabStop = False
            Me.btnLoadMap.ThemedImage = CType(resources.GetObject("btnLoadMap.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnClearMap
            '
            Me.btnClearMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnClearMap.Image = CType(resources.GetObject("btnClearMap.Image"), System.Drawing.Image)
            Me.btnClearMap.Location = New System.Drawing.Point(264, 368)
            Me.btnClearMap.Name = "btnClearMap"
            Me.btnClearMap.Size = New System.Drawing.Size(24, 23)
            Me.btnClearMap.TabIndex = 56
            Me.btnClearMap.TabStop = False
            Me.btnClearMap.ThemedImage = CType(resources.GetObject("btnClearMap.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnShowMap
            '
            Me.btnShowMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnShowMap.ForeColor = System.Drawing.SystemColors.Control
            Me.btnShowMap.Image = CType(resources.GetObject("btnShowMap.Image"), System.Drawing.Image)
            Me.btnShowMap.Location = New System.Drawing.Point(240, 368)
            Me.btnShowMap.Name = "btnShowMap"
            Me.btnShowMap.Size = New System.Drawing.Size(24, 23)
            Me.btnShowMap.TabIndex = 54
            Me.btnShowMap.TabStop = False
            Me.btnShowMap.ThemedImage = CType(resources.GetObject("btnShowMap.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbReceive
            '
            Me.grbReceive.Controls.Add(Me.ImbReceiveWeek)
            Me.grbReceive.Controls.Add(Me.ImbReceiveDate)
            Me.grbReceive.Controls.Add(Me.ImbReceiveDay)
            Me.grbReceive.Controls.Add(Me.lblReceiveDate)
            Me.grbReceive.Controls.Add(Me.lblReceiveWeek)
            Me.grbReceive.Controls.Add(Me.txtReceiveDates)
            Me.grbReceive.Controls.Add(Me.txtReceiveDays)
            Me.grbReceive.Controls.Add(Me.txtReceiveWeeks)
            Me.grbReceive.Controls.Add(Me.lblReceiveDay)
            Me.grbReceive.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbReceive.Location = New System.Drawing.Point(296, 304)
            Me.grbReceive.Name = "grbReceive"
            Me.grbReceive.Size = New System.Drawing.Size(256, 104)
            Me.grbReceive.TabIndex = 26
            Me.grbReceive.TabStop = False
            Me.grbReceive.Text = "เงื่อนไขการรับชำระหนี้"
            '
            'ImbReceiveWeek
            '
            Me.ImbReceiveWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbReceiveWeek.Image = CType(resources.GetObject("ImbReceiveWeek.Image"), System.Drawing.Image)
            Me.ImbReceiveWeek.Location = New System.Drawing.Point(224, 72)
            Me.ImbReceiveWeek.Name = "ImbReceiveWeek"
            Me.ImbReceiveWeek.Size = New System.Drawing.Size(24, 23)
            Me.ImbReceiveWeek.TabIndex = 172
            Me.ImbReceiveWeek.TabStop = False
            Me.ImbReceiveWeek.ThemedImage = CType(resources.GetObject("ImbReceiveWeek.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImbReceiveDate
            '
            Me.ImbReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbReceiveDate.Image = CType(resources.GetObject("ImbReceiveDate.Image"), System.Drawing.Image)
            Me.ImbReceiveDate.Location = New System.Drawing.Point(224, 48)
            Me.ImbReceiveDate.Name = "ImbReceiveDate"
            Me.ImbReceiveDate.Size = New System.Drawing.Size(24, 23)
            Me.ImbReceiveDate.TabIndex = 171
            Me.ImbReceiveDate.TabStop = False
            Me.ImbReceiveDate.ThemedImage = CType(resources.GetObject("ImbReceiveDate.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImbReceiveDay
            '
            Me.ImbReceiveDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbReceiveDay.Image = CType(resources.GetObject("ImbReceiveDay.Image"), System.Drawing.Image)
            Me.ImbReceiveDay.Location = New System.Drawing.Point(224, 24)
            Me.ImbReceiveDay.Name = "ImbReceiveDay"
            Me.ImbReceiveDay.Size = New System.Drawing.Size(24, 23)
            Me.ImbReceiveDay.TabIndex = 170
            Me.ImbReceiveDay.TabStop = False
            Me.ImbReceiveDay.ThemedImage = CType(resources.GetObject("ImbReceiveDay.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblReceiveDate
            '
            Me.lblReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveDate.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveDate.Location = New System.Drawing.Point(16, 48)
            Me.lblReceiveDate.Name = "lblReceiveDate"
            Me.lblReceiveDate.Size = New System.Drawing.Size(96, 18)
            Me.lblReceiveDate.TabIndex = 8
            Me.lblReceiveDate.Text = "ทุกวันที่:"
            Me.lblReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblReceiveWeek
            '
            Me.lblReceiveWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveWeek.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveWeek.Location = New System.Drawing.Point(8, 72)
            Me.lblReceiveWeek.Name = "lblReceiveWeek"
            Me.lblReceiveWeek.Size = New System.Drawing.Size(104, 18)
            Me.lblReceiveWeek.TabIndex = 8
            Me.lblReceiveWeek.Text = "จ่ายเงินตามสัปดาห์ที่:"
            Me.lblReceiveWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtReceiveDates
            '
            Me.Validator.SetDataType(Me.txtReceiveDates, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReceiveDates, "")
            Me.txtReceiveDates.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveDates, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceiveDates, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveDates, System.Drawing.Color.Empty)
            Me.txtReceiveDates.Location = New System.Drawing.Point(112, 48)
            Me.Validator.SetMaxValue(Me.txtReceiveDates, "")
            Me.Validator.SetMinValue(Me.txtReceiveDates, "")
            Me.txtReceiveDates.Name = "txtReceiveDates"
            Me.txtReceiveDates.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReceiveDates, "")
            Me.Validator.SetRequired(Me.txtReceiveDates, False)
            Me.txtReceiveDates.Size = New System.Drawing.Size(112, 21)
            Me.txtReceiveDates.TabIndex = 10
            Me.txtReceiveDates.TabStop = False
            Me.txtReceiveDates.Text = ""
            '
            'txtReceiveDays
            '
            Me.Validator.SetDataType(Me.txtReceiveDays, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReceiveDays, "")
            Me.txtReceiveDays.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveDays, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceiveDays, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveDays, System.Drawing.Color.Empty)
            Me.txtReceiveDays.Location = New System.Drawing.Point(112, 24)
            Me.Validator.SetMaxValue(Me.txtReceiveDays, "")
            Me.Validator.SetMinValue(Me.txtReceiveDays, "")
            Me.txtReceiveDays.Name = "txtReceiveDays"
            Me.txtReceiveDays.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReceiveDays, "")
            Me.Validator.SetRequired(Me.txtReceiveDays, False)
            Me.txtReceiveDays.Size = New System.Drawing.Size(112, 21)
            Me.txtReceiveDays.TabIndex = 9
            Me.txtReceiveDays.TabStop = False
            Me.txtReceiveDays.Text = ""
            '
            'txtReceiveWeeks
            '
            Me.Validator.SetDataType(Me.txtReceiveWeeks, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReceiveWeeks, "")
            Me.txtReceiveWeeks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveWeeks, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceiveWeeks, -15)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveWeeks, System.Drawing.Color.Empty)
            Me.txtReceiveWeeks.Location = New System.Drawing.Point(112, 72)
            Me.Validator.SetMaxValue(Me.txtReceiveWeeks, "")
            Me.Validator.SetMinValue(Me.txtReceiveWeeks, "")
            Me.txtReceiveWeeks.Name = "txtReceiveWeeks"
            Me.txtReceiveWeeks.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReceiveWeeks, "")
            Me.Validator.SetRequired(Me.txtReceiveWeeks, False)
            Me.txtReceiveWeeks.Size = New System.Drawing.Size(112, 21)
            Me.txtReceiveWeeks.TabIndex = 11
            Me.txtReceiveWeeks.TabStop = False
            Me.txtReceiveWeeks.Text = ""
            '
            'lblReceiveDay
            '
            Me.lblReceiveDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveDay.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveDay.Location = New System.Drawing.Point(16, 24)
            Me.lblReceiveDay.Name = "lblReceiveDay"
            Me.lblReceiveDay.Size = New System.Drawing.Size(96, 18)
            Me.lblReceiveDay.TabIndex = 8
            Me.lblReceiveDay.Text = "ทุกวัน:"
            Me.lblReceiveDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbBillRec
            '
            Me.grbBillRec.Controls.Add(Me.ImbBillRecDay)
            Me.grbBillRec.Controls.Add(Me.txtBillRecWeeks)
            Me.grbBillRec.Controls.Add(Me.txtBillRecDates)
            Me.grbBillRec.Controls.Add(Me.lblBillRecWeek)
            Me.grbBillRec.Controls.Add(Me.lblBillRecDate)
            Me.grbBillRec.Controls.Add(Me.lblBillRecDay)
            Me.grbBillRec.Controls.Add(Me.txtBillRecDays)
            Me.grbBillRec.Controls.Add(Me.ImbBillRecDate)
            Me.grbBillRec.Controls.Add(Me.ImbBillRecWeek)
            Me.grbBillRec.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbBillRec.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbBillRec.Location = New System.Drawing.Point(296, 192)
            Me.grbBillRec.Name = "grbBillRec"
            Me.grbBillRec.Size = New System.Drawing.Size(256, 104)
            Me.grbBillRec.TabIndex = 25
            Me.grbBillRec.TabStop = False
            Me.grbBillRec.Text = "เงื่อนไขการวางบิล"
            '
            'ImbBillRecDay
            '
            Me.ImbBillRecDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbBillRecDay.Image = CType(resources.GetObject("ImbBillRecDay.Image"), System.Drawing.Image)
            Me.ImbBillRecDay.Location = New System.Drawing.Point(224, 24)
            Me.ImbBillRecDay.Name = "ImbBillRecDay"
            Me.ImbBillRecDay.Size = New System.Drawing.Size(24, 23)
            Me.ImbBillRecDay.TabIndex = 168
            Me.ImbBillRecDay.TabStop = False
            Me.ImbBillRecDay.ThemedImage = CType(resources.GetObject("ImbBillRecDay.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBillRecWeeks
            '
            Me.Validator.SetDataType(Me.txtBillRecWeeks, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillRecWeeks, "")
            Me.txtBillRecWeeks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillRecWeeks, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBillRecWeeks, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBillRecWeeks, System.Drawing.Color.Empty)
            Me.txtBillRecWeeks.Location = New System.Drawing.Point(112, 72)
            Me.Validator.SetMaxValue(Me.txtBillRecWeeks, "")
            Me.Validator.SetMinValue(Me.txtBillRecWeeks, "")
            Me.txtBillRecWeeks.Name = "txtBillRecWeeks"
            Me.txtBillRecWeeks.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBillRecWeeks, "")
            Me.Validator.SetRequired(Me.txtBillRecWeeks, False)
            Me.txtBillRecWeeks.Size = New System.Drawing.Size(112, 21)
            Me.txtBillRecWeeks.TabIndex = 8
            Me.txtBillRecWeeks.TabStop = False
            Me.txtBillRecWeeks.Text = ""
            '
            'txtBillRecDates
            '
            Me.Validator.SetDataType(Me.txtBillRecDates, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillRecDates, "")
            Me.txtBillRecDates.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillRecDates, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBillRecDates, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBillRecDates, System.Drawing.Color.Empty)
            Me.txtBillRecDates.Location = New System.Drawing.Point(112, 48)
            Me.Validator.SetMaxValue(Me.txtBillRecDates, "")
            Me.Validator.SetMinValue(Me.txtBillRecDates, "")
            Me.txtBillRecDates.Name = "txtBillRecDates"
            Me.txtBillRecDates.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBillRecDates, "")
            Me.Validator.SetRequired(Me.txtBillRecDates, False)
            Me.txtBillRecDates.Size = New System.Drawing.Size(112, 21)
            Me.txtBillRecDates.TabIndex = 7
            Me.txtBillRecDates.TabStop = False
            Me.txtBillRecDates.Text = ""
            '
            'lblBillRecWeek
            '
            Me.lblBillRecWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillRecWeek.ForeColor = System.Drawing.Color.Black
            Me.lblBillRecWeek.Location = New System.Drawing.Point(16, 72)
            Me.lblBillRecWeek.Name = "lblBillRecWeek"
            Me.lblBillRecWeek.Size = New System.Drawing.Size(96, 16)
            Me.lblBillRecWeek.TabIndex = 8
            Me.lblBillRecWeek.Text = "ทุกวันสัปดาห์"
            Me.lblBillRecWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBillRecDate
            '
            Me.lblBillRecDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillRecDate.ForeColor = System.Drawing.Color.Black
            Me.lblBillRecDate.Location = New System.Drawing.Point(16, 48)
            Me.lblBillRecDate.Name = "lblBillRecDate"
            Me.lblBillRecDate.Size = New System.Drawing.Size(96, 18)
            Me.lblBillRecDate.TabIndex = 8
            Me.lblBillRecDate.Text = "ทุกวันที่:"
            Me.lblBillRecDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBillRecDay
            '
            Me.lblBillRecDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillRecDay.ForeColor = System.Drawing.Color.Black
            Me.lblBillRecDay.Location = New System.Drawing.Point(16, 24)
            Me.lblBillRecDay.Name = "lblBillRecDay"
            Me.lblBillRecDay.Size = New System.Drawing.Size(96, 18)
            Me.lblBillRecDay.TabIndex = 8
            Me.lblBillRecDay.Text = "ทุกวัน:"
            Me.lblBillRecDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBillRecDays
            '
            Me.Validator.SetDataType(Me.txtBillRecDays, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillRecDays, "")
            Me.txtBillRecDays.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillRecDays, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBillRecDays, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBillRecDays, System.Drawing.Color.Empty)
            Me.txtBillRecDays.Location = New System.Drawing.Point(112, 24)
            Me.Validator.SetMaxValue(Me.txtBillRecDays, "")
            Me.Validator.SetMinValue(Me.txtBillRecDays, "")
            Me.txtBillRecDays.Name = "txtBillRecDays"
            Me.txtBillRecDays.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBillRecDays, "")
            Me.Validator.SetRequired(Me.txtBillRecDays, False)
            Me.txtBillRecDays.Size = New System.Drawing.Size(112, 21)
            Me.txtBillRecDays.TabIndex = 6
            Me.txtBillRecDays.TabStop = False
            Me.txtBillRecDays.Text = ""
            '
            'ImbBillRecDate
            '
            Me.ImbBillRecDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbBillRecDate.Image = CType(resources.GetObject("ImbBillRecDate.Image"), System.Drawing.Image)
            Me.ImbBillRecDate.Location = New System.Drawing.Point(224, 48)
            Me.ImbBillRecDate.Name = "ImbBillRecDate"
            Me.ImbBillRecDate.Size = New System.Drawing.Size(24, 23)
            Me.ImbBillRecDate.TabIndex = 168
            Me.ImbBillRecDate.TabStop = False
            Me.ImbBillRecDate.ThemedImage = CType(resources.GetObject("ImbBillRecDate.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImbBillRecWeek
            '
            Me.ImbBillRecWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbBillRecWeek.Image = CType(resources.GetObject("ImbBillRecWeek.Image"), System.Drawing.Image)
            Me.ImbBillRecWeek.Location = New System.Drawing.Point(224, 72)
            Me.ImbBillRecWeek.Name = "ImbBillRecWeek"
            Me.ImbBillRecWeek.Size = New System.Drawing.Size(24, 23)
            Me.ImbBillRecWeek.TabIndex = 168
            Me.ImbBillRecWeek.TabStop = False
            Me.ImbBillRecWeek.ThemedImage = CType(resources.GetObject("ImbBillRecWeek.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnOk
            '
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnOk.ForeColor = System.Drawing.Color.Black
            Me.btnOk.Location = New System.Drawing.Point(624, 384)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(96, 24)
            Me.btnOk.TabIndex = 4
            Me.btnOk.Text = "OK"
            '
            'grbMap
            '
            Me.grbMap.Controls.Add(Me.pnlPicHolder)
            Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMap.Location = New System.Drawing.Point(8, 192)
            Me.grbMap.Name = "grbMap"
            Me.grbMap.Size = New System.Drawing.Size(280, 176)
            Me.grbMap.TabIndex = 16
            Me.grbMap.TabStop = False
            Me.grbMap.Text = "แผนที่"
            '
            'pnlPicHolder
            '
            Me.pnlPicHolder.AutoScroll = True
            Me.pnlPicHolder.Controls.Add(Me.picMap)
            Me.pnlPicHolder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlPicHolder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.pnlPicHolder.Location = New System.Drawing.Point(3, 17)
            Me.pnlPicHolder.Name = "pnlPicHolder"
            Me.pnlPicHolder.Size = New System.Drawing.Size(274, 156)
            Me.pnlPicHolder.TabIndex = 22
            '
            'picMap
            '
            Me.picMap.Location = New System.Drawing.Point(8, 8)
            Me.picMap.Name = "picMap"
            Me.picMap.Size = New System.Drawing.Size(264, 144)
            Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.picMap.TabIndex = 6
            Me.picMap.TabStop = False
            '
            'grbSupplier
            '
            Me.grbSupplier.Controls.Add(Me.lblPicSize)
            Me.grbSupplier.Controls.Add(Me.btnLoadImage)
            Me.grbSupplier.Controls.Add(Me.btnClearImage)
            Me.grbSupplier.Controls.Add(Me.txtLastContactDate)
            Me.grbSupplier.Controls.Add(Me.txtbirthdate)
            Me.grbSupplier.Controls.Add(Me.txtHomePage)
            Me.grbSupplier.Controls.Add(Me.lblName)
            Me.grbSupplier.Controls.Add(Me.txtName)
            Me.grbSupplier.Controls.Add(Me.lblCode)
            Me.grbSupplier.Controls.Add(Me.txtCode)
            Me.grbSupplier.Controls.Add(Me.lblbirthDate)
            Me.grbSupplier.Controls.Add(Me.dtpBirthDate)
            Me.grbSupplier.Controls.Add(Me.lblHomePage)
            Me.grbSupplier.Controls.Add(Me.picImage)
            Me.grbSupplier.Controls.Add(Me.lblLastContactDate)
            Me.grbSupplier.Controls.Add(Me.dtpLastContactDate)
            Me.grbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbSupplier.Location = New System.Drawing.Point(8, 24)
            Me.grbSupplier.Name = "grbSupplier"
            Me.grbSupplier.Size = New System.Drawing.Size(544, 160)
            Me.grbSupplier.TabIndex = 0
            Me.grbSupplier.TabStop = False
            Me.grbSupplier.Text = "รายละเอียดSupplier"
            '
            'btnLoadImage
            '
            Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLoadImage.Image = CType(resources.GetObject("btnLoadImage.Image"), System.Drawing.Image)
            Me.btnLoadImage.Location = New System.Drawing.Point(488, 136)
            Me.btnLoadImage.Name = "btnLoadImage"
            Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
            Me.btnLoadImage.TabIndex = 57
            Me.btnLoadImage.TabStop = False
            Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnClearImage
            '
            Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnClearImage.Image = CType(resources.GetObject("btnClearImage.Image"), System.Drawing.Image)
            Me.btnClearImage.Location = New System.Drawing.Point(512, 136)
            Me.btnClearImage.Name = "btnClearImage"
            Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
            Me.btnClearImage.TabIndex = 58
            Me.btnClearImage.TabStop = False
            Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtLastContactDate
            '
            Me.Validator.SetDataType(Me.txtLastContactDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLastContactDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLastContactDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLastContactDate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLastContactDate, System.Drawing.Color.Empty)
            Me.txtLastContactDate.Location = New System.Drawing.Point(120, 120)
            Me.Validator.SetMaxValue(Me.txtLastContactDate, "")
            Me.Validator.SetMinValue(Me.txtLastContactDate, "")
            Me.txtLastContactDate.Name = "txtLastContactDate"
            Me.Validator.SetRegularExpression(Me.txtLastContactDate, "")
            Me.Validator.SetRequired(Me.txtLastContactDate, False)
            Me.txtLastContactDate.Size = New System.Drawing.Size(108, 21)
            Me.txtLastContactDate.TabIndex = 5
            Me.txtLastContactDate.Text = ""
            '
            'txtbirthdate
            '
            Me.Validator.SetDataType(Me.txtbirthdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtbirthdate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtbirthdate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtbirthdate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtbirthdate, System.Drawing.Color.Empty)
            Me.txtbirthdate.Location = New System.Drawing.Point(120, 72)
            Me.Validator.SetMaxValue(Me.txtbirthdate, "")
            Me.Validator.SetMinValue(Me.txtbirthdate, "")
            Me.txtbirthdate.Name = "txtbirthdate"
            Me.Validator.SetRegularExpression(Me.txtbirthdate, "")
            Me.Validator.SetRequired(Me.txtbirthdate, False)
            Me.txtbirthdate.Size = New System.Drawing.Size(108, 21)
            Me.txtbirthdate.TabIndex = 3
            Me.txtbirthdate.Text = ""
            '
            'txtHomePage
            '
            Me.txtHomePage.AcceptsReturn = True
            Me.Validator.SetDataType(Me.txtHomePage, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtHomePage, "")
            Me.txtHomePage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtHomePage, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtHomePage, -15)
            Me.Validator.SetInvalidBackColor(Me.txtHomePage, System.Drawing.Color.Empty)
            Me.txtHomePage.Location = New System.Drawing.Point(120, 96)
            Me.Validator.SetMaxValue(Me.txtHomePage, "")
            Me.Validator.SetMinValue(Me.txtHomePage, "")
            Me.txtHomePage.Name = "txtHomePage"
            Me.Validator.SetRegularExpression(Me.txtHomePage, "")
            Me.Validator.SetRequired(Me.txtHomePage, False)
            Me.txtHomePage.Size = New System.Drawing.Size(288, 21)
            Me.txtHomePage.TabIndex = 4
            Me.txtHomePage.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(16, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(104, 18)
            Me.lblName.TabIndex = 4
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(120, 48)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(288, 21)
            Me.txtName.TabIndex = 2
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 2
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(120, 24)
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.txtCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(128, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'lblbirthDate
            '
            Me.lblbirthDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblbirthDate.ForeColor = System.Drawing.Color.Black
            Me.lblbirthDate.Location = New System.Drawing.Point(16, 72)
            Me.lblbirthDate.Name = "lblbirthDate"
            Me.lblbirthDate.Size = New System.Drawing.Size(104, 18)
            Me.lblbirthDate.TabIndex = 8
            Me.lblbirthDate.Text = "วันเกิด:"
            Me.lblbirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpBirthDate
            '
            Me.dtpBirthDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBirthDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpBirthDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpBirthDate.Location = New System.Drawing.Point(120, 72)
            Me.dtpBirthDate.Name = "dtpBirthDate"
            Me.dtpBirthDate.Size = New System.Drawing.Size(128, 21)
            Me.dtpBirthDate.TabIndex = 0
            '
            'lblHomePage
            '
            Me.lblHomePage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblHomePage.ForeColor = System.Drawing.Color.Black
            Me.lblHomePage.Location = New System.Drawing.Point(16, 96)
            Me.lblHomePage.Name = "lblHomePage"
            Me.lblHomePage.Size = New System.Drawing.Size(104, 18)
            Me.lblHomePage.TabIndex = 8
            Me.lblHomePage.Text = "เว็ปไซด์:"
            Me.lblHomePage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'picImage
            '
            Me.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.picImage.Location = New System.Drawing.Point(416, 16)
            Me.picImage.Name = "picImage"
            Me.picImage.Size = New System.Drawing.Size(120, 120)
            Me.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.picImage.TabIndex = 6
            Me.picImage.TabStop = False
            '
            'lblLastContactDate
            '
            Me.lblLastContactDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLastContactDate.ForeColor = System.Drawing.Color.Black
            Me.lblLastContactDate.Location = New System.Drawing.Point(16, 120)
            Me.lblLastContactDate.Name = "lblLastContactDate"
            Me.lblLastContactDate.Size = New System.Drawing.Size(104, 18)
            Me.lblLastContactDate.TabIndex = 8
            Me.lblLastContactDate.Text = "วัวันที่ติดต่อล่าสุด:"
            Me.lblLastContactDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpLastContactDate
            '
            Me.dtpLastContactDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpLastContactDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpLastContactDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpLastContactDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpLastContactDate.Location = New System.Drawing.Point(120, 120)
            Me.dtpLastContactDate.Name = "dtpLastContactDate"
            Me.dtpLastContactDate.Size = New System.Drawing.Size(128, 21)
            Me.dtpLastContactDate.TabIndex = 2
            '
            'grbFinancial
            '
            Me.grbFinancial.Controls.Add(Me.txtLastPaydate)
            Me.grbFinancial.Controls.Add(Me.lblLastPayDate)
            Me.grbFinancial.Controls.Add(Me.dtpLastPayDate)
            Me.grbFinancial.Controls.Add(Me.lblSummaryDiscount)
            Me.grbFinancial.Controls.Add(Me.txtSummaryDiscount)
            Me.grbFinancial.Controls.Add(Me.txtDetailDiscount)
            Me.grbFinancial.Controls.Add(Me.lblDetailDiscount)
            Me.grbFinancial.Controls.Add(Me.txtTaxRate)
            Me.grbFinancial.Controls.Add(Me.lblTaxRate)
            Me.grbFinancial.Controls.Add(Me.lblCheckAmountOnHand)
            Me.grbFinancial.Controls.Add(Me.txtCheckAmountOnHand)
            Me.grbFinancial.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbFinancial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbFinancial.Location = New System.Drawing.Point(560, 192)
            Me.grbFinancial.Name = "grbFinancial"
            Me.grbFinancial.Size = New System.Drawing.Size(272, 152)
            Me.grbFinancial.TabIndex = 3
            Me.grbFinancial.TabStop = False
            Me.grbFinancial.Text = "ทางด้านการเงิน"
            '
            'txtLastPaydate
            '
            Me.Validator.SetDataType(Me.txtLastPaydate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLastPaydate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLastPaydate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLastPaydate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLastPaydate, System.Drawing.Color.Empty)
            Me.txtLastPaydate.Location = New System.Drawing.Point(136, 24)
            Me.Validator.SetMaxValue(Me.txtLastPaydate, "")
            Me.Validator.SetMinValue(Me.txtLastPaydate, "")
            Me.txtLastPaydate.Name = "txtLastPaydate"
            Me.Validator.SetRegularExpression(Me.txtLastPaydate, "")
            Me.Validator.SetRequired(Me.txtLastPaydate, False)
            Me.txtLastPaydate.Size = New System.Drawing.Size(107, 21)
            Me.txtLastPaydate.TabIndex = 16
            Me.txtLastPaydate.Text = ""
            '
            'lblLastPayDate
            '
            Me.lblLastPayDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLastPayDate.ForeColor = System.Drawing.Color.Black
            Me.lblLastPayDate.Location = New System.Drawing.Point(8, 26)
            Me.lblLastPayDate.Name = "lblLastPayDate"
            Me.lblLastPayDate.Size = New System.Drawing.Size(128, 18)
            Me.lblLastPayDate.TabIndex = 8
            Me.lblLastPayDate.Text = "วันที่ชำระครั้งล่าสุด:"
            Me.lblLastPayDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpLastPayDate
            '
            Me.dtpLastPayDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpLastPayDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpLastPayDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpLastPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpLastPayDate.Location = New System.Drawing.Point(136, 24)
            Me.dtpLastPayDate.Name = "dtpLastPayDate"
            Me.dtpLastPayDate.Size = New System.Drawing.Size(128, 21)
            Me.dtpLastPayDate.TabIndex = 0
            '
            'lblSummaryDiscount
            '
            Me.lblSummaryDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSummaryDiscount.ForeColor = System.Drawing.Color.Black
            Me.lblSummaryDiscount.Location = New System.Drawing.Point(16, 74)
            Me.lblSummaryDiscount.Name = "lblSummaryDiscount"
            Me.lblSummaryDiscount.Size = New System.Drawing.Size(120, 18)
            Me.lblSummaryDiscount.TabIndex = 8
            Me.lblSummaryDiscount.Text = "ส่วนลดรายการสินค้า:"
            Me.lblSummaryDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSummaryDiscount
            '
            Me.Validator.SetDataType(Me.txtSummaryDiscount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSummaryDiscount, "")
            Me.txtSummaryDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSummaryDiscount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSummaryDiscount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSummaryDiscount, System.Drawing.Color.Empty)
            Me.txtSummaryDiscount.Location = New System.Drawing.Point(136, 72)
            Me.Validator.SetMaxValue(Me.txtSummaryDiscount, "")
            Me.Validator.SetMinValue(Me.txtSummaryDiscount, "")
            Me.txtSummaryDiscount.Name = "txtSummaryDiscount"
            Me.Validator.SetRegularExpression(Me.txtSummaryDiscount, "")
            Me.Validator.SetRequired(Me.txtSummaryDiscount, False)
            Me.txtSummaryDiscount.Size = New System.Drawing.Size(128, 21)
            Me.txtSummaryDiscount.TabIndex = 18
            Me.txtSummaryDiscount.Text = ""
            '
            'txtDetailDiscount
            '
            Me.Validator.SetDataType(Me.txtDetailDiscount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDetailDiscount, "")
            Me.txtDetailDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDetailDiscount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDetailDiscount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDetailDiscount, System.Drawing.Color.Empty)
            Me.txtDetailDiscount.Location = New System.Drawing.Point(136, 48)
            Me.Validator.SetMaxValue(Me.txtDetailDiscount, "")
            Me.Validator.SetMinValue(Me.txtDetailDiscount, "")
            Me.txtDetailDiscount.Name = "txtDetailDiscount"
            Me.Validator.SetRegularExpression(Me.txtDetailDiscount, "")
            Me.Validator.SetRequired(Me.txtDetailDiscount, False)
            Me.txtDetailDiscount.Size = New System.Drawing.Size(128, 21)
            Me.txtDetailDiscount.TabIndex = 17
            Me.txtDetailDiscount.Text = ""
            '
            'lblDetailDiscount
            '
            Me.lblDetailDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDetailDiscount.ForeColor = System.Drawing.Color.Black
            Me.lblDetailDiscount.Location = New System.Drawing.Point(8, 50)
            Me.lblDetailDiscount.Name = "lblDetailDiscount"
            Me.lblDetailDiscount.Size = New System.Drawing.Size(128, 18)
            Me.lblDetailDiscount.TabIndex = 8
            Me.lblDetailDiscount.Text = "ส่วนลดท้ายบิล:"
            Me.lblDetailDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxRate
            '
            Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtTaxRate, "")
            Me.txtTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtTaxRate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.txtTaxRate.Location = New System.Drawing.Point(136, 96)
            Me.Validator.SetMaxValue(Me.txtTaxRate, "")
            Me.Validator.SetMinValue(Me.txtTaxRate, "")
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
            Me.Validator.SetRequired(Me.txtTaxRate, False)
            Me.txtTaxRate.Size = New System.Drawing.Size(128, 21)
            Me.txtTaxRate.TabIndex = 19
            Me.txtTaxRate.Text = ""
            '
            'lblTaxRate
            '
            Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxRate.ForeColor = System.Drawing.Color.Black
            Me.lblTaxRate.Location = New System.Drawing.Point(8, 98)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(128, 18)
            Me.lblTaxRate.TabIndex = 8
            Me.lblTaxRate.Text = "อัตราภาษี:"
            Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCheckAmountOnHand
            '
            Me.lblCheckAmountOnHand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCheckAmountOnHand.ForeColor = System.Drawing.Color.Black
            Me.lblCheckAmountOnHand.Location = New System.Drawing.Point(8, 122)
            Me.lblCheckAmountOnHand.Name = "lblCheckAmountOnHand"
            Me.lblCheckAmountOnHand.Size = New System.Drawing.Size(128, 18)
            Me.lblCheckAmountOnHand.TabIndex = 8
            Me.lblCheckAmountOnHand.Text = "มูลค่าเจ้าหนี้คงค้าง:"
            Me.lblCheckAmountOnHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCheckAmountOnHand
            '
            Me.Validator.SetDataType(Me.txtCheckAmountOnHand, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtCheckAmountOnHand, "")
            Me.txtCheckAmountOnHand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCheckAmountOnHand, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCheckAmountOnHand, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCheckAmountOnHand, System.Drawing.Color.Empty)
            Me.txtCheckAmountOnHand.Location = New System.Drawing.Point(136, 120)
            Me.Validator.SetMaxValue(Me.txtCheckAmountOnHand, "")
            Me.Validator.SetMinValue(Me.txtCheckAmountOnHand, "")
            Me.txtCheckAmountOnHand.Name = "txtCheckAmountOnHand"
            Me.Validator.SetRegularExpression(Me.txtCheckAmountOnHand, "")
            Me.Validator.SetRequired(Me.txtCheckAmountOnHand, False)
            Me.txtCheckAmountOnHand.Size = New System.Drawing.Size(128, 21)
            Me.txtCheckAmountOnHand.TabIndex = 20
            Me.txtCheckAmountOnHand.Text = ""
            '
            'grbCredit
            '
            Me.grbCredit.Controls.Add(Me.cmbCreditType)
            Me.grbCredit.Controls.Add(Me.txtCreditPeriod)
            Me.grbCredit.Controls.Add(Me.txtCreditAmount)
            Me.grbCredit.Controls.Add(Me.txtCreditPeriodFromTransport)
            Me.grbCredit.Controls.Add(Me.lblCreditType)
            Me.grbCredit.Controls.Add(Me.lblCreditPeriod)
            Me.grbCredit.Controls.Add(Me.lblCreditPeriodUnit)
            Me.grbCredit.Controls.Add(Me.lblCreditAmount)
            Me.grbCredit.Controls.Add(Me.lblCreditPeriodFromTransport)
            Me.grbCredit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbCredit.Location = New System.Drawing.Point(560, 24)
            Me.grbCredit.Name = "grbCredit"
            Me.grbCredit.Size = New System.Drawing.Size(272, 160)
            Me.grbCredit.TabIndex = 1
            Me.grbCredit.TabStop = False
            Me.grbCredit.Text = "เครดิต"
            '
            'cmbCreditType
            '
            Me.cmbCreditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCreditType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ErrorProvider1.SetIconPadding(Me.cmbCreditType, -15)
            Me.cmbCreditType.Location = New System.Drawing.Point(136, 21)
            Me.cmbCreditType.Name = "cmbCreditType"
            Me.cmbCreditType.Size = New System.Drawing.Size(96, 21)
            Me.cmbCreditType.TabIndex = 12
            '
            'txtCreditPeriod
            '
            Me.Validator.SetDataType(Me.txtCreditPeriod, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
            Me.Validator.SetDisplayName(Me.txtCreditPeriod, "")
            Me.txtCreditPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreditPeriod, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreditPeriod, System.Drawing.Color.Empty)
            Me.txtCreditPeriod.Location = New System.Drawing.Point(136, 48)
            Me.Validator.SetMaxValue(Me.txtCreditPeriod, "")
            Me.Validator.SetMinValue(Me.txtCreditPeriod, "")
            Me.txtCreditPeriod.Name = "txtCreditPeriod"
            Me.Validator.SetRegularExpression(Me.txtCreditPeriod, "")
            Me.Validator.SetRequired(Me.txtCreditPeriod, False)
            Me.txtCreditPeriod.Size = New System.Drawing.Size(96, 21)
            Me.txtCreditPeriod.TabIndex = 13
            Me.txtCreditPeriod.Text = ""
            '
            'txtCreditAmount
            '
            Me.Validator.SetDataType(Me.txtCreditAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtCreditAmount, "")
            Me.txtCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreditAmount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
            Me.txtCreditAmount.Location = New System.Drawing.Point(136, 72)
            Me.Validator.SetMaxValue(Me.txtCreditAmount, "")
            Me.Validator.SetMinValue(Me.txtCreditAmount, "")
            Me.txtCreditAmount.Name = "txtCreditAmount"
            Me.Validator.SetRegularExpression(Me.txtCreditAmount, "")
            Me.Validator.SetRequired(Me.txtCreditAmount, False)
            Me.txtCreditAmount.Size = New System.Drawing.Size(96, 21)
            Me.txtCreditAmount.TabIndex = 14
            Me.txtCreditAmount.Text = ""
            '
            'txtCreditPeriodFromTransport
            '
            Me.Validator.SetDataType(Me.txtCreditPeriodFromTransport, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
            Me.Validator.SetDisplayName(Me.txtCreditPeriodFromTransport, "")
            Me.txtCreditPeriodFromTransport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreditPeriodFromTransport, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreditPeriodFromTransport, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreditPeriodFromTransport, System.Drawing.Color.Empty)
            Me.txtCreditPeriodFromTransport.Location = New System.Drawing.Point(136, 96)
            Me.Validator.SetMaxValue(Me.txtCreditPeriodFromTransport, "")
            Me.Validator.SetMinValue(Me.txtCreditPeriodFromTransport, "")
            Me.txtCreditPeriodFromTransport.Name = "txtCreditPeriodFromTransport"
            Me.Validator.SetRegularExpression(Me.txtCreditPeriodFromTransport, "")
            Me.Validator.SetRequired(Me.txtCreditPeriodFromTransport, False)
            Me.txtCreditPeriodFromTransport.Size = New System.Drawing.Size(96, 21)
            Me.txtCreditPeriodFromTransport.TabIndex = 15
            Me.txtCreditPeriodFromTransport.Text = ""
            '
            'lblCreditType
            '
            Me.lblCreditType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditType.ForeColor = System.Drawing.Color.Black
            Me.lblCreditType.Location = New System.Drawing.Point(16, 24)
            Me.lblCreditType.Name = "lblCreditType"
            Me.lblCreditType.Size = New System.Drawing.Size(112, 18)
            Me.lblCreditType.TabIndex = 8
            Me.lblCreditType.Text = "ประเภทเครดิต:"
            Me.lblCreditType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCreditPeriod
            '
            Me.lblCreditPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPeriod.ForeColor = System.Drawing.Color.Black
            Me.lblCreditPeriod.Location = New System.Drawing.Point(24, 48)
            Me.lblCreditPeriod.Name = "lblCreditPeriod"
            Me.lblCreditPeriod.Size = New System.Drawing.Size(112, 18)
            Me.lblCreditPeriod.TabIndex = 8
            Me.lblCreditPeriod.Text = "ระยะเวลา:"
            Me.lblCreditPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCreditPeriodUnit
            '
            Me.lblCreditPeriodUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPeriodUnit.ForeColor = System.Drawing.Color.Black
            Me.lblCreditPeriodUnit.Location = New System.Drawing.Point(240, 48)
            Me.lblCreditPeriodUnit.Name = "lblCreditPeriodUnit"
            Me.lblCreditPeriodUnit.Size = New System.Drawing.Size(24, 18)
            Me.lblCreditPeriodUnit.TabIndex = 8
            Me.lblCreditPeriodUnit.Text = "วัน"
            '
            'lblCreditAmount
            '
            Me.lblCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditAmount.ForeColor = System.Drawing.Color.Black
            Me.lblCreditAmount.Location = New System.Drawing.Point(24, 72)
            Me.lblCreditAmount.Name = "lblCreditAmount"
            Me.lblCreditAmount.Size = New System.Drawing.Size(112, 18)
            Me.lblCreditAmount.TabIndex = 8
            Me.lblCreditAmount.Text = "วงเงินเครดิต:"
            Me.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCreditPeriodFromTransport
            '
            Me.lblCreditPeriodFromTransport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPeriodFromTransport.ForeColor = System.Drawing.Color.Black
            Me.lblCreditPeriodFromTransport.Location = New System.Drawing.Point(24, 96)
            Me.lblCreditPeriodFromTransport.Name = "lblCreditPeriodFromTransport"
            Me.lblCreditPeriodFromTransport.Size = New System.Drawing.Size(112, 16)
            Me.lblCreditPeriodFromTransport.TabIndex = 8
            Me.lblCreditPeriodFromTransport.Text = "เครดิตจากวันส่งของ:"
            Me.lblCreditPeriodFromTransport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(728, 384)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 24)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "Cancel"
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.Empty
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.Empty
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'lblPicSize
            '
            Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPicSize.Location = New System.Drawing.Point(427, 64)
            Me.lblPicSize.Name = "lblPicSize"
            Me.lblPicSize.TabIndex = 59
            Me.lblPicSize.Text = "120 X 120 pixel"
            Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'SupplierAuxDetailView
            '
            Me.Controls.Add(Me.PrimaryGroupBoxControl)
            Me.Name = "SupplierAuxDetailView"
            Me.Size = New System.Drawing.Size(856, 440)
            Me.PrimaryGroupBoxControl.ResumeLayout(False)
            Me.grbReceive.ResumeLayout(False)
            Me.grbBillRec.ResumeLayout(False)
            Me.grbMap.ResumeLayout(False)
            Me.pnlPicHolder.ResumeLayout(False)
            Me.grbSupplier.ResumeLayout(False)
            Me.grbFinancial.ResumeLayout(False)
            Me.grbCredit.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

            Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCode}")

            Me.lblbirthDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblbirthDate}")
            Me.Validator.SetDisplayName(Me.txtbirthdate, lblbirthDate.Text)

            Me.lblHomePage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblHomePage}")
            Me.Validator.SetDisplayName(Me.txtHomePage, lblHomePage.Text)

            Me.lblLastContactDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblLastContactDate}")
            Me.Validator.SetDisplayName(Me.txtLastContactDate, Me.lblLastContactDate.Text)

            Me.lblLastPayDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblLastPayDate}")
            Me.Validator.SetDisplayName(Me.txtLastPaydate, Me.lblLastPayDate.Text)

            Me.lblSummaryDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblSummaryDiscount}")
            Me.Validator.SetDisplayName(Me.txtSummaryDiscount, Me.lblSummaryDiscount.Text)

            Me.lblDetailDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblDetailDiscount}")
            Me.Validator.SetDisplayName(Me.txtDetailDiscount, Me.lblDetailDiscount.Text)

            Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Global.TaxRateText}")
            Me.Validator.SetDisplayName(Me.txtTaxRate, Me.lblTaxRate.Text)

            Me.lblCreditType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditType}")

            Me.lblCreditPeriod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditPeriod}")
            Me.Validator.SetDisplayName(Me.txtCreditPeriod, Me.lblCreditPeriod.Text)

            Me.lblCreditPeriodUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditPeriodUnit}")

            Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditAmount}")
            Me.Validator.SetDisplayName(Me.txtCreditAmount, Me.lblCreditAmount.Text)

            Me.lblCreditPeriodFromTransport.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCreditPeriodFromTransport}")
            Me.Validator.SetDisplayName(Me.txtCreditPeriodFromTransport, Me.lblCreditPeriodFromTransport.Text)

            Me.btnOk.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
            Me.btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")

            'Me.btnShowMap.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.btnShowMap}")
            'Me.btnLoadMap.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.btnLoadMap}")
            'Me.btnLoadImage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.btnLoadImage}")

            Me.lblReceiveDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblReceiveDate}")
            Me.Validator.SetDisplayName(Me.txtReceiveDates, Me.lblReceiveDate.Text)

            Me.lblReceiveWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblReceiveWeek}")
            Me.Validator.SetDisplayName(Me.txtReceiveWeeks, Me.lblReceiveWeek.Text)

            Me.lblReceiveDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblReceiveDay}")
            Me.Validator.SetDisplayName(Me.txtReceiveDays, Me.lblReceiveDay.Text)

            Me.lblBillRecWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblBillRecWeek}")
            Me.Validator.SetDisplayName(Me.txtBillRecWeeks, Me.txtBillRecWeeks.Text)

            Me.lblBillRecDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblBillRecDate}")
            Me.Validator.SetDisplayName(Me.txtBillRecDates, Me.txtBillRecDates.Text)

            Me.lblBillRecDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblBillRecDay}")
            Me.Validator.SetDisplayName(Me.txtBillRecDays, Me.lblBillRecDay.Text)

            Me.grbReceive.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.grbReceive}")
            Me.lblCheckAmountOnHand.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.lblCheckAmountOnHand}")

            Me.PrimaryGroupBoxControl.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.PrimarygrbControl}")
            Me.grbSupplier.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.grbSupplierDetail}")
            Me.grbMap.Text = Me.StringParserService.Parse("${res:Global.grbMap}")
            Me.grbCredit.Text = Me.StringParserService.Parse("${res:Global.Credit}")
            Me.grbBillRec.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.grbBillRecDetail}")
            Me.grbFinancial.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SupplierAuxDetailView.grbFinancialDetail}")

        End Sub
#End Region

#Region "Member"
        Private m_entity As Supplier
        Private m_isInitialized As Boolean = False
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "Methods"
        Private Function ConvertItemsToValueArray(ByVal list As String) As String
            Dim result As String = ""
            If list Is Nothing OrElse list.Length = 0 Then
                Return Nothing
            Else
                For Each item As String In list.Split(","c)
                    result &= CStr(CInt(item) + 1) & ","
                Next
                If result.Length <> 0 Then
                    result = result.TrimEnd(","c)
                End If
                Return result
            End If
        End Function
#End Region

#Region "IListDetail"

        ' ตรวจสอบสถานะของฟอร์ม
        Public Overrides Sub CheckFormEnable()
            If m_entity.Canceled Then
                For Each ctrl As Control In PrimaryGroupBoxControl.Controls
                    If ctrl.Name.ToLower <> "btncancel" Then
                        ctrl.Enabled = False
                    End If
                Next
                grbSupplier.Enabled = False
                grbReceive.Enabled = False
                grbBillRec.Enabled = False
                grbFinancial.Enabled = False
                grbCredit.Enabled = False
                grbMap.Enabled = False
            Else
                For Each ctrl As Control In PrimaryGroupBoxControl.Controls
                    ctrl.Enabled = True
                Next
                grbSupplier.Enabled = True
                grbReceive.Enabled = True
                grbBillRec.Enabled = True
                grbFinancial.Enabled = True
                grbCredit.Enabled = True
                grbMap.Enabled = True
            End If
        End Sub

        ' เคลียร์ข้อมูลลูกค้าใน control
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In PrimaryGroupBoxControl.Controls
                If TypeOf crlt Is TextBox Then
                    crlt.Text = ""
                End If
            Next

            txtbirthdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            txtLastContactDate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")
            txtLastPaydate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

            dtpBirthDate.Value = Now.Date
            dtpLastContactDate.Value = Now.Date
            dtpLastPayDate.Value = Now.Date

            cmbCreditType.SelectedIndex = -1
            cmbCreditType.SelectedIndex = -1

        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler dtpBirthDate.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpLastContactDate.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpLastPayDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtbirthdate.Validated, AddressOf Me.ChangeProperty
            AddHandler txtLastContactDate.Validated, AddressOf Me.ChangeProperty
            AddHandler txtLastPaydate.Validated, AddressOf Me.ChangeProperty

            AddHandler txtHomePage.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtBillRecDates.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtBillRecWeeks.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtReceiveDates.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtReceiveWeeks.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtSummaryDiscount.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtDetailDiscount.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtTaxRate.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtCheckAmountOnHand.TextChanged, AddressOf Me.ChangeProperty

            AddHandler cmbCreditType.SelectedValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtCreditPeriod.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtCreditAmount.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtCreditPeriodFromTransport.TextChanged, AddressOf Me.ChangeProperty
        End Sub
        ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            txtCode.Text = Me.m_entity.Code
            txtName.Text = Me.m_entity.Name

            picImage.Image = Me.m_entity.Image
            CheckLabelImgSize()
            picMap.Image = Me.m_entity.Map

            dtpBirthDate.Value = MinDateToNow(Me.m_entity.BirthDate)
            txtbirthdate.Text = MinDateToNull(Me.m_entity.BirthDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

            dtpLastContactDate.Value = MinDateToNow(Me.m_entity.LastContactDate)
            txtLastContactDate.Text = MinDateToNull(Me.m_entity.LastContactDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

            dtpLastPayDate.Value = MinDateToNow(Me.m_entity.LastPayDate)
            txtLastPaydate.Text = MinDateToNull(Me.m_entity.LastPayDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))


            txtHomePage.Text = Me.m_entity.HomePage

            txtBillRecDays.Text = DateTimeService.GetDayStrings(Me.m_entity.BillrecDays, False)
            txtBillRecDates.Text = ConvertItemsToValueArray(Me.m_entity.BillRecDates)
            txtBillRecWeeks.Text = ConvertItemsToValueArray(Me.m_entity.BillRecWeeks)
            txtReceiveDays.Text = DateTimeService.GetDayStrings(Me.m_entity.ReceiveDays, False)
            txtReceiveDates.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveDates)
            txtReceiveWeeks.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveWeeks)

            txtSummaryDiscount.Text = Me.m_entity.SummaryDiscount.Rate
            txtDetailDiscount.Text = Me.m_entity.DetailDiscount.Rate

            txtTaxRate.Text = Me.m_entity.TaxRate.ToString
            txtCheckAmountOnHand.Text = Me.m_entity.CheckAmountOnHand.ToString

            cmbCreditType.SelectedValue = Me.m_entity.CreditType.Value

            txtCreditPeriod.Text = Me.m_entity.CreditPeriod.ToString
            txtCreditAmount.Text = Me.m_entity.CreditAmount.ToString
            txtCreditPeriodFromTransport.Text = Me.m_entity.CreditPeriodFromTransport.ToString

            SetLabelText()
            CheckFormEnable()

            m_isInitialized = True
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Try
                Select Case CType(sender, Control).Name.ToLower
                    Case "dtpbirthdate"
                        DateToString(dtpBirthDate, txtbirthdate)
                        Me.m_entity.BirthDate = dtpBirthDate.Value

                    Case "txthomepage"
                        Me.m_entity.HomePage = txtHomePage.Text

                    Case "dtplastcontactdate"
                        DateToString(dtpLastContactDate, txtLastContactDate)
                        Me.m_entity.LastContactDate = dtpLastContactDate.Value

                    Case "dtplastpaydate"
                        DateToString(dtpLastPayDate, txtLastPaydate)
                        Me.m_entity.LastPayDate = dtpLastPayDate.Value

                    Case "txtdetaildiscount"
                        Me.m_entity.DetailDiscount.Rate = txtDetailDiscount.Text

                    Case "txtsummarydiscount"
                        Me.m_entity.SummaryDiscount.Rate = txtSummaryDiscount.Text

                    Case "txttaxrate"
                        If IsNumeric(txtTaxRate.Text) Then
                            Me.m_entity.TaxRate = CDec(txtTaxRate.Text)
                        Else
                            Me.m_entity.TaxRate = Nothing
                        End If

                    Case "txtcheckamountonhand"
                        If IsNumeric(txtCheckAmountOnHand.Text) Then
                            Me.m_entity.CheckAmountOnHand = CDec(txtCheckAmountOnHand.Text)
                        Else
                            Me.m_entity.CheckAmountOnHand = Nothing
                        End If

                    Case "cmbcredittype"
                        Me.m_entity.CreditType.Value = CInt(cmbCreditType.SelectedValue)

                    Case "txtcreditperiod"
                        If IsNumeric(txtCreditPeriod.Text) Then
                            Me.m_entity.CreditPeriod = CInt(txtCreditPeriod.Text)
                        Else
                            Me.m_entity.CreditPeriod = Nothing
                        End If

                    Case "txtcreditamount"
                        If IsNumeric(txtCreditAmount.Text) Then
                            Me.m_entity.CreditAmount = CDec(txtCreditAmount.Text)
                        Else
                            Me.m_entity.CreditAmount = Nothing
                        End If

                    Case "txtcreditperiodfromtransport"
                        If IsNumeric(txtCreditPeriodFromTransport.Text) Then
                            Me.m_entity.CreditPeriodFromTransport = CInt(txtCreditPeriodFromTransport.Text)
                        Else
                            Me.m_entity.CreditPeriodFromTransport = Nothing
                        End If

                    Case "txtbirthdate"
                        Dim dt As DateTime = StringToDate(txtbirthdate, dtpBirthDate)
                        Me.m_entity.BirthDate = dt

                    Case "txtlastcontactdate"
                        Dim dt As DateTime = StringToDate(txtLastContactDate, dtpLastContactDate)
                        Me.m_entity.LastContactDate = dt

                    Case "txtlastpaydate"
                        Dim dt As DateTime = StringToDate(txtLastPaydate, dtpLastPayDate)
                        Me.m_entity.LastPayDate = dt

                End Select
            Catch ex As Exception

            End Try
            'Hack
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = True
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                Me.m_entity = Nothing
                Me.m_entity = CType(Value, Supplier)
                Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
                Me.SaveProperties()
                'Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
            Dim propService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim culture As String = propService.GetProperty("CoreProperties.UILanguage", "th")
            culture = culture & "-" & culture.ToUpper
            'Me.DateTimeService.ListDaysInComboBox(Me.cmbBillrecDay, False, culture)
            'Me.DateTimeService.ListDaysInComboBox(Me.cmbReceiveDay, False, culture)

            Me.cmbCreditType.DataSource = CodeDescription.GetCodeList("credit_type")
            Me.cmbCreditType.DisplayMember = "code_description"
            Me.cmbCreditType.ValueMember = "code_value"
        End Sub

#End Region

#Region "Event Handlers"
        Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
            Dim dlg As New OpenFileDialog
            Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
            dlg.Filter = String.Join("|", fileFilters)
            If dlg.ShowDialog = DialogResult.OK Then
                Dim img As Image = Image.FromFile(dlg.FileName)
                If img.Size.Height > Me.picImage.Height OrElse img.Size.Width >= Me.picImage.Width Then
                    Dim percent As Decimal = 100 * (Math.Min(Me.picImage.Height / img.Size.Height, Me.picImage.Width / img.Size.Width))
                    img = ImageHelper.Resize(img, percent)
                End If
                Me.picImage.Image = img
                m_entity.Image = img
                'Hack
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
                CheckLabelImgSize()
            End If
        End Sub

        Private Sub btnLoadMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadMap.Click
            Dim dlg As New OpenFileDialog
            Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
            dlg.Filter = String.Join("|", fileFilters)
            If dlg.ShowDialog = DialogResult.OK Then
                Dim img As Image = Image.FromFile(dlg.FileName)
                Me.picMap.Image = img
                m_entity.Map = img
                'Hack
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
                Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
                myDialog.ShowDialog()
            End If
        End Sub

        Private Sub btnShowMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowMap.Click
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(New Longkong.Pojjaman.Gui.Panels.MapDialog(m_entity, Me))
            myDialog.ShowDialog()
            Me.picMap.Invalidate()
        End Sub
        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.RevertProperties()
        End Sub
        Private Sub ImbBillRecDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImbBillRecDate.Click
            Dim dates(30) As Object
            For i As Integer = 1 To 31
                dates(i - 1) = i
            Next
            Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(dates, Me.m_entity.BillRecDates)
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
            If myDialog.ShowDialog() = DialogResult.OK Then
                Me.txtBillRecDates.Text = chkdlg.CheckedItemsString
                Me.m_entity.BillRecDates = chkdlg.CheckedValuesString
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub ImbBillRecDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImbBillRecDay.Click
            Dim days As Object() = Me.DateTimeService.GetDays(False).ToArray
            Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(days, Me.m_entity.BillrecDays)
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
            If myDialog.ShowDialog() = DialogResult.OK Then
                Me.txtBillRecDays.Text = chkdlg.CheckedItemsString
                Me.m_entity.BillrecDays = chkdlg.CheckedValuesString
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub ImbBillRecWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImbBillRecWeek.Click
            Dim weeks(3) As Object
            For i As Integer = 1 To 4
                weeks(i - 1) = i
            Next
            Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(weeks, Me.m_entity.BillRecWeeks)
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
            If myDialog.ShowDialog() = DialogResult.OK Then
                Me.txtBillRecWeeks.Text = chkdlg.CheckedItemsString
                Me.m_entity.BillRecWeeks = chkdlg.CheckedValuesString
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub ImbReceiveDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImbReceiveDay.Click
            Dim days As Object() = Me.DateTimeService.GetDays(False).ToArray
            Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(days, Me.m_entity.ReceiveDays)
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
            If myDialog.ShowDialog() = DialogResult.OK Then
                Me.txtReceiveDays.Text = chkdlg.CheckedItemsString
                Me.m_entity.ReceiveDays = chkdlg.CheckedValuesString
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub ImbReceiveDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImbReceiveDate.Click
            Dim dates(30) As Object
            For i As Integer = 1 To 31
                dates(i - 1) = i
            Next
            Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(dates, Me.m_entity.ReceiveDates)
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
            If myDialog.ShowDialog() = DialogResult.OK Then
                Me.txtReceiveDates.Text = chkdlg.CheckedItemsString
                Me.m_entity.ReceiveDates = chkdlg.CheckedValuesString
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub ImbReceiveWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImbReceiveWeek.Click
            Dim weeks(3) As Object
            For i As Integer = 1 To 4
                weeks(i - 1) = i
            Next
            Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(weeks, Me.m_entity.ReceiveWeeks)
            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
            If myDialog.ShowDialog() = DialogResult.OK Then
                Me.txtReceiveWeeks.Text = chkdlg.CheckedItemsString
                Me.m_entity.ReceiveWeeks = chkdlg.CheckedValuesString
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub picMap_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picMap.Paint
            Dim g As Graphics = e.Graphics
            Dim pn As New Pen(Color.Red, 3)
            Dim top As Integer = Me.m_entity.MapPosition.Y - 10
            If top < 0 Then top = 0
            Dim left As Integer = Me.m_entity.MapPosition.X - 10
            If left < 0 Then left = 0
            Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
            If bottom > picMap.Height Then bottom = picMap.Height
            Dim right As Integer = Me.m_entity.MapPosition.X + 10
            If right > picMap.Width Then right = picMap.Width
            g.DrawLine(pn, left, top, right, bottom)
            g.DrawLine(pn, right, top, left, bottom)
            pn.Dispose()
        End Sub
        Private m_Ticks As Long
        Private m_canDrag As Boolean = False
        Const TICKS_OFFSET As Long = 0
        Private Sub picMap_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseMove
            Dim ts As New TimeSpan(Now.Ticks - m_Ticks)
            If m_canDrag And e.Button = MouseButtons.Left And ts.TotalMilliseconds > TICKS_OFFSET Then
                If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
                    Me.m_entity.MapPosition = New Point(e.X, e.Y)
                    picMap.Invalidate()
                    m_Ticks = Now.Ticks
                End If
            End If
        End Sub
        Private Sub picMap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseDown
            'Dim top As Integer = Me.m_entity.MapPosition.Y - 10
            'If top < 0 Then top = 0
            'Dim left As Integer = Me.m_entity.MapPosition.X - 10
            'If left < 0 Then left = 0
            'Dim bottom As Integer = Me.m_entity.MapPosition.Y + 10
            'If bottom > picMap.Height Then bottom = picMap.Height
            'Dim right As Integer = Me.m_entity.MapPosition.X + 10
            'If right > picMap.Width Then right = picMap.Width

            'Dim xBounds As New Rectangle(left, top, 20, 20)
            'If xBounds.Contains(New Point(e.X, e.Y)) Then
            '    m_canDrag = True
            'End If

            m_canDrag = True
            If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
                Me.m_entity.MapPosition = New Point(e.X, e.Y)
                picMap.Invalidate()
                'Hack
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
        End Sub
        Private Sub picMap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picMap.MouseUp
            If picMap.Bounds.Contains(New Point(e.X, e.Y)) Then
                Me.m_entity.MapPosition = New Point(e.X, e.Y)
                'Hack
                Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
                myContent.IsDirty = True
            End If
            m_canDrag = False
        End Sub
#End Region

#Region "IReversibleEntityProperty"

#Region "Members"
        Private m_oldStatusIsDirty As Boolean
        Private m_oldBirthdate As Date
        Private m_oldHomePage As String
        Private m_oldLastContactDate As Date
        Private m_oldBillrecDay As DayOfWeek
        Private m_oldBillRecDate As Integer
        Private m_oldBillRecWeek As Integer
        Private m_oldReceiveDay As DayOfWeek
        Private m_oldReceiveDate As Integer
        Private m_oldReceiveWeek As Integer
        Private m_oldLastPayDate As Date
        Private m_oldSummaryDiscount As Discount
        Private m_oldDetailDiscount As Discount
        Private m_oldTaxRate As Decimal
        Private m_oldCheckAmountOnHand As Decimal
        Private m_oldCreditType As CreditType
        Private m_oldCreditPeriod As Integer
        Private m_oldCreditAmount As Decimal
        Private m_oldCreditPeriodFromTransport As Integer
        Private m_oldMap As Image
        Private m_oldImage As Image
        Private m_oldMapPosition As Point
#End Region

        Public Sub RevertProperties() Implements IReversibleEntityProperty.RevertProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = m_oldStatusIsDirty
            Me.m_entity.BirthDate = m_oldBirthdate
            Me.m_entity.HomePage = m_oldHomePage
            Me.m_entity.LastContactDate = m_oldLastContactDate
            'Me.m_entity.BillrecDay = m_oldBillrecDay
            'Me.m_entity.BillRecDate = m_oldBillRecDate
            'Me.m_entity.BillRecWeek = m_oldBillRecWeek
            'Me.m_entity.ReceiveDays = m_oldReceiveDay
            'Me.m_entity.ReceiveDate = m_oldReceiveDate
            'Me.m_entity.ReceiveWeek = m_oldReceiveWeek
            Me.m_entity.LastPayDate = m_oldLastPayDate
            Me.m_entity.SummaryDiscount = m_oldSummaryDiscount
            Me.m_entity.DetailDiscount = m_oldDetailDiscount
            Me.m_entity.TaxRate = m_oldTaxRate
            Me.m_entity.CheckAmountOnHand = m_oldCheckAmountOnHand
            Me.m_entity.CreditType = m_oldCreditType
            Me.m_entity.CreditPeriod = m_oldCreditPeriod
            Me.m_entity.CreditAmount = m_oldCreditAmount
            Me.m_entity.CreditPeriodFromTransport = m_oldCreditPeriodFromTransport
            Me.m_entity.Map = m_oldMap
            Me.m_entity.Image = m_oldImage
            Me.m_entity.MapPosition = m_oldMapPosition
            Me.m_entity.HtChangedProperties.Clear()
        End Sub
        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            m_oldStatusIsDirty = myContent.IsDirty
            m_oldBirthdate = Me.m_entity.BirthDate
            m_oldHomePage = Me.m_entity.HomePage
            m_oldLastContactDate = Me.m_entity.LastContactDate
            'm_oldBillrecDay = Me.m_entity.BillrecDay
            'm_oldBillRecDate = Me.m_entity.BillRecDate
            'm_oldBillRecWeek = Me.m_entity.BillRecWeek
            'm_oldReceiveDay = Me.m_entity.ReceiveDays
            'm_oldReceiveDate = Me.m_entity.ReceiveDate
            'm_oldReceiveWeek = Me.m_entity.ReceiveWeek
            m_oldLastPayDate = Me.m_entity.LastPayDate
            m_oldSummaryDiscount = Me.m_entity.SummaryDiscount
            m_oldDetailDiscount = Me.m_entity.DetailDiscount
            m_oldTaxRate = Me.m_entity.TaxRate
            m_oldCheckAmountOnHand = Me.m_entity.CheckAmountOnHand
            m_oldCreditType = Me.m_entity.CreditType
            m_oldCreditPeriod = Me.m_entity.CreditPeriod
            m_oldCreditAmount = Me.m_entity.CreditAmount
            m_oldCreditPeriodFromTransport = Me.m_entity.CreditPeriodFromTransport
            m_oldMap = Me.m_entity.Map
            m_oldImage = Me.m_entity.Image
            m_oldMapPosition = Me.m_entity.MapPosition
        End Sub
#End Region

        Private Sub btnClearMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMap.Click
            m_entity.Map = Nothing
            Me.picMap.Image = Nothing
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = True
        End Sub

        Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearImage.Click
            m_entity.Image = Nothing
            Me.picImage.Image = Nothing
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            myContent.IsDirty = True
            CheckLabelImgSize()
        End Sub
        Private Sub CheckLabelImgSize()
            Me.lblPicSize.Text = "120 X 120 pixel"
            If Me.m_entity.Image Is Nothing Then
                Me.lblPicSize.Visible = True
            Else
                Me.lblPicSize.Visible = False
            End If
        End Sub
    End Class

End Namespace
