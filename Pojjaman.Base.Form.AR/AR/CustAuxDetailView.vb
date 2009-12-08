Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels

    Public Class CustAuxDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IReversibleEntityProperty


#Region "Member"
        Private m_entity As Customer
        Private m_isInitialized As Boolean = False
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
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblbirthDate As System.Windows.Forms.Label
        Friend WithEvents picImage As System.Windows.Forms.PictureBox
        Friend WithEvents picMap As System.Windows.Forms.PictureBox
        Friend WithEvents lblTaxRate As System.Windows.Forms.Label
        Friend WithEvents lblSummaryDiscount As System.Windows.Forms.Label
        Friend WithEvents lblCreditPeriodFromTransport As System.Windows.Forms.Label
        Friend WithEvents lblCreditPeriod As System.Windows.Forms.Label
        Friend WithEvents txtCreditPeriod As System.Windows.Forms.TextBox
        Friend WithEvents txtCheckAmountOnHand As System.Windows.Forms.TextBox
        Friend WithEvents txtCreditAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblHomePage As System.Windows.Forms.Label
        Friend WithEvents lblCheckAmountOnHand As System.Windows.Forms.Label
        Friend WithEvents txtDetailDiscount As System.Windows.Forms.TextBox
        Friend WithEvents lblCreditAmount As System.Windows.Forms.Label
        Friend WithEvents lblCreditType As System.Windows.Forms.Label
        Friend WithEvents txtHomePage As System.Windows.Forms.TextBox
        Friend WithEvents lblDetailDiscount As System.Windows.Forms.Label
        Friend WithEvents lblLastContactDate As System.Windows.Forms.Label
        Friend WithEvents lblLastPayDate As System.Windows.Forms.Label
        Friend WithEvents lblReceiveDay As System.Windows.Forms.Label
        Friend WithEvents lblReceiveDate As System.Windows.Forms.Label
        Friend WithEvents lblReceiveWeek As System.Windows.Forms.Label
        Friend WithEvents lblBillRecWeek As System.Windows.Forms.Label
        Friend WithEvents lblBillRecDate As System.Windows.Forms.Label
        Friend WithEvents lblBillRecDay As System.Windows.Forms.Label
        Friend WithEvents txtSummaryDiscount As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
        Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblCreditPeriodUnit As System.Windows.Forms.Label
        Friend WithEvents dtpLastContactDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtReceiveDate As System.Windows.Forms.TextBox
        Friend WithEvents txtReceiveWeek As System.Windows.Forms.TextBox
        Friend WithEvents txtCreditPeriodFromTransport As System.Windows.Forms.TextBox
        Friend WithEvents txtBillRecWeek As System.Windows.Forms.TextBox
        Friend WithEvents txtBillRecDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpLastPayDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents PrimaryGroupBoxControl As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents cmbCreditType As System.Windows.Forms.ComboBox
        Friend WithEvents pnlPicHolder As System.Windows.Forms.Panel
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents txtBillRecDay As System.Windows.Forms.TextBox
        Friend WithEvents txtReceiveDay As System.Windows.Forms.TextBox
        Friend WithEvents ImbBillRecDay As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbBillRecDate As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbBillRecWeek As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbReceiveDate As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbReceiveWeek As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ImbReceiveDay As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtBirtdate As System.Windows.Forms.TextBox
        Friend WithEvents txtLastContactdate As System.Windows.Forms.TextBox
        Friend WithEvents txtLastPaydate As System.Windows.Forms.TextBox
        Friend WithEvents grbCredit As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbBillRec As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbFinancial As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbCustomer As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbMap As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents grbRecieve As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnLoadMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnShowMap As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblPicSize As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CustAuxDetailView))
            Me.lblCreditPeriod = New System.Windows.Forms.Label
            Me.txtCreditPeriod = New System.Windows.Forms.TextBox
            Me.picImage = New System.Windows.Forms.PictureBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblbirthDate = New System.Windows.Forms.Label
            Me.txtCheckAmountOnHand = New System.Windows.Forms.TextBox
            Me.txtCreditAmount = New System.Windows.Forms.TextBox
            Me.lblHomePage = New System.Windows.Forms.Label
            Me.lblCheckAmountOnHand = New System.Windows.Forms.Label
            Me.txtDetailDiscount = New System.Windows.Forms.TextBox
            Me.lblCreditAmount = New System.Windows.Forms.Label
            Me.lblCreditType = New System.Windows.Forms.Label
            Me.txtHomePage = New System.Windows.Forms.TextBox
            Me.lblDetailDiscount = New System.Windows.Forms.Label
            Me.lblLastContactDate = New System.Windows.Forms.Label
            Me.lblLastPayDate = New System.Windows.Forms.Label
            Me.picMap = New System.Windows.Forms.PictureBox
            Me.lblTaxRate = New System.Windows.Forms.Label
            Me.lblSummaryDiscount = New System.Windows.Forms.Label
            Me.lblCreditPeriodFromTransport = New System.Windows.Forms.Label
            Me.lblReceiveDay = New System.Windows.Forms.Label
            Me.lblReceiveDate = New System.Windows.Forms.Label
            Me.lblReceiveWeek = New System.Windows.Forms.Label
            Me.lblBillRecWeek = New System.Windows.Forms.Label
            Me.lblBillRecDate = New System.Windows.Forms.Label
            Me.lblBillRecDay = New System.Windows.Forms.Label
            Me.txtSummaryDiscount = New System.Windows.Forms.TextBox
            Me.txtTaxRate = New System.Windows.Forms.TextBox
            Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker
            Me.lblCreditPeriodUnit = New System.Windows.Forms.Label
            Me.dtpLastContactDate = New System.Windows.Forms.DateTimePicker
            Me.txtReceiveDate = New System.Windows.Forms.TextBox
            Me.txtReceiveWeek = New System.Windows.Forms.TextBox
            Me.txtCreditPeriodFromTransport = New System.Windows.Forms.TextBox
            Me.txtBillRecWeek = New System.Windows.Forms.TextBox
            Me.txtBillRecDate = New System.Windows.Forms.TextBox
            Me.grbCredit = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbCreditType = New System.Windows.Forms.ComboBox
            Me.grbBillRec = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ImbBillRecDay = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtBillRecDay = New System.Windows.Forms.TextBox
            Me.ImbBillRecDate = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImbBillRecWeek = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbFinancial = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtLastPaydate = New System.Windows.Forms.TextBox
            Me.dtpLastPayDate = New System.Windows.Forms.DateTimePicker
            Me.grbCustomer = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblPicSize = New System.Windows.Forms.Label
            Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtLastContactdate = New System.Windows.Forms.TextBox
            Me.txtBirtdate = New System.Windows.Forms.TextBox
            Me.grbMap = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.pnlPicHolder = New System.Windows.Forms.Panel
            Me.PrimaryGroupBoxControl = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnLoadMap = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnClearMap = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnShowMap = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbRecieve = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.ImbReceiveDay = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtReceiveDay = New System.Windows.Forms.TextBox
            Me.ImbReceiveDate = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ImbReceiveWeek = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnOk = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbCredit.SuspendLayout()
            Me.grbBillRec.SuspendLayout()
            Me.grbFinancial.SuspendLayout()
            Me.grbCustomer.SuspendLayout()
            Me.grbMap.SuspendLayout()
            Me.pnlPicHolder.SuspendLayout()
            Me.PrimaryGroupBoxControl.SuspendLayout()
            Me.grbRecieve.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCreditPeriod
            '
            Me.lblCreditPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPeriod.ForeColor = System.Drawing.Color.Black
            Me.lblCreditPeriod.Location = New System.Drawing.Point(8, 48)
            Me.lblCreditPeriod.Name = "lblCreditPeriod"
            Me.lblCreditPeriod.Size = New System.Drawing.Size(128, 18)
            Me.lblCreditPeriod.TabIndex = 6
            Me.lblCreditPeriod.Text = "ระยะเวลา:"
            Me.lblCreditPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCreditPeriod
            '
            Me.Validator.SetDataType(Me.txtCreditPeriod, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
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
            Me.txtCreditPeriod.Size = New System.Drawing.Size(104, 21)
            Me.txtCreditPeriod.TabIndex = 7
            Me.txtCreditPeriod.Text = ""
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
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(112, 18)
            Me.lblName.TabIndex = 2
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(120, 48)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.txtName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(288, 21)
            Me.txtName.TabIndex = 3
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 18)
            Me.lblCode.TabIndex = 0
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(120, 24)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.txtCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(288, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'lblbirthDate
            '
            Me.lblbirthDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblbirthDate.ForeColor = System.Drawing.Color.Black
            Me.lblbirthDate.Location = New System.Drawing.Point(8, 72)
            Me.lblbirthDate.Name = "lblbirthDate"
            Me.lblbirthDate.Size = New System.Drawing.Size(112, 18)
            Me.lblbirthDate.TabIndex = 4
            Me.lblbirthDate.Text = "วันเกิด:"
            Me.lblbirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCheckAmountOnHand
            '
            Me.Validator.SetDataType(Me.txtCheckAmountOnHand, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCheckAmountOnHand, "")
            Me.txtCheckAmountOnHand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCheckAmountOnHand, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCheckAmountOnHand, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCheckAmountOnHand, System.Drawing.Color.Empty)
            Me.txtCheckAmountOnHand.Location = New System.Drawing.Point(136, 120)
            Me.txtCheckAmountOnHand.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtCheckAmountOnHand, "")
            Me.Validator.SetMinValue(Me.txtCheckAmountOnHand, "")
            Me.txtCheckAmountOnHand.Name = "txtCheckAmountOnHand"
            Me.Validator.SetRegularExpression(Me.txtCheckAmountOnHand, "")
            Me.Validator.SetRequired(Me.txtCheckAmountOnHand, False)
            Me.txtCheckAmountOnHand.Size = New System.Drawing.Size(104, 21)
            Me.txtCheckAmountOnHand.TabIndex = 9
            Me.txtCheckAmountOnHand.Text = ""
            '
            'txtCreditAmount
            '
            Me.Validator.SetDataType(Me.txtCreditAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCreditAmount, "")
            Me.txtCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreditAmount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreditAmount, System.Drawing.Color.Empty)
            Me.txtCreditAmount.Location = New System.Drawing.Point(136, 72)
            Me.txtCreditAmount.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtCreditAmount, "")
            Me.Validator.SetMinValue(Me.txtCreditAmount, "")
            Me.txtCreditAmount.Name = "txtCreditAmount"
            Me.Validator.SetRegularExpression(Me.txtCreditAmount, "")
            Me.Validator.SetRequired(Me.txtCreditAmount, False)
            Me.txtCreditAmount.Size = New System.Drawing.Size(104, 21)
            Me.txtCreditAmount.TabIndex = 1
            Me.txtCreditAmount.Text = ""
            '
            'lblHomePage
            '
            Me.lblHomePage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblHomePage.ForeColor = System.Drawing.Color.Black
            Me.lblHomePage.Location = New System.Drawing.Point(8, 96)
            Me.lblHomePage.Name = "lblHomePage"
            Me.lblHomePage.Size = New System.Drawing.Size(112, 18)
            Me.lblHomePage.TabIndex = 6
            Me.lblHomePage.Text = "เว็ปไซด์:"
            Me.lblHomePage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCheckAmountOnHand
            '
            Me.lblCheckAmountOnHand.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCheckAmountOnHand.ForeColor = System.Drawing.Color.Black
            Me.lblCheckAmountOnHand.Location = New System.Drawing.Point(8, 120)
            Me.lblCheckAmountOnHand.Name = "lblCheckAmountOnHand"
            Me.lblCheckAmountOnHand.Size = New System.Drawing.Size(128, 18)
            Me.lblCheckAmountOnHand.TabIndex = 8
            Me.lblCheckAmountOnHand.Text = "มุลค่าลูกหนี้คงค้าง:"
            Me.lblCheckAmountOnHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDetailDiscount
            '
            Me.Validator.SetDataType(Me.txtDetailDiscount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDetailDiscount, "")
            Me.txtDetailDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtDetailDiscount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDetailDiscount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDetailDiscount, System.Drawing.Color.Empty)
            Me.txtDetailDiscount.Location = New System.Drawing.Point(136, 72)
            Me.txtDetailDiscount.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtDetailDiscount, "")
            Me.Validator.SetMinValue(Me.txtDetailDiscount, "")
            Me.txtDetailDiscount.Name = "txtDetailDiscount"
            Me.Validator.SetRegularExpression(Me.txtDetailDiscount, "")
            Me.Validator.SetRequired(Me.txtDetailDiscount, False)
            Me.txtDetailDiscount.Size = New System.Drawing.Size(104, 21)
            Me.txtDetailDiscount.TabIndex = 5
            Me.txtDetailDiscount.Text = ""
            '
            'lblCreditAmount
            '
            Me.lblCreditAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditAmount.ForeColor = System.Drawing.Color.Black
            Me.lblCreditAmount.Location = New System.Drawing.Point(8, 72)
            Me.lblCreditAmount.Name = "lblCreditAmount"
            Me.lblCreditAmount.Size = New System.Drawing.Size(128, 18)
            Me.lblCreditAmount.TabIndex = 0
            Me.lblCreditAmount.Text = "วงเงินเครดิต:"
            Me.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCreditType
            '
            Me.lblCreditType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditType.ForeColor = System.Drawing.Color.Black
            Me.lblCreditType.Location = New System.Drawing.Point(8, 24)
            Me.lblCreditType.Name = "lblCreditType"
            Me.lblCreditType.Size = New System.Drawing.Size(128, 18)
            Me.lblCreditType.TabIndex = 4
            Me.lblCreditType.Text = "ประเภทการเครดิต:"
            Me.lblCreditType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtHomePage
            '
            Me.txtHomePage.AcceptsReturn = True
            Me.Validator.SetDataType(Me.txtHomePage, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtHomePage, "")
            Me.txtHomePage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtHomePage, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtHomePage, System.Drawing.Color.Empty)
            Me.txtHomePage.Location = New System.Drawing.Point(120, 96)
            Me.txtHomePage.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtHomePage, "")
            Me.Validator.SetMinValue(Me.txtHomePage, "")
            Me.txtHomePage.Name = "txtHomePage"
            Me.Validator.SetRegularExpression(Me.txtHomePage, "")
            Me.Validator.SetRequired(Me.txtHomePage, False)
            Me.txtHomePage.Size = New System.Drawing.Size(288, 21)
            Me.txtHomePage.TabIndex = 7
            Me.txtHomePage.Text = ""
            '
            'lblDetailDiscount
            '
            Me.lblDetailDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDetailDiscount.ForeColor = System.Drawing.Color.Black
            Me.lblDetailDiscount.Location = New System.Drawing.Point(8, 72)
            Me.lblDetailDiscount.Name = "lblDetailDiscount"
            Me.lblDetailDiscount.Size = New System.Drawing.Size(128, 18)
            Me.lblDetailDiscount.TabIndex = 4
            Me.lblDetailDiscount.Text = "ส่วนลดรายการสินค้า:"
            Me.lblDetailDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLastContactDate
            '
            Me.lblLastContactDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLastContactDate.ForeColor = System.Drawing.Color.Black
            Me.lblLastContactDate.Location = New System.Drawing.Point(8, 120)
            Me.lblLastContactDate.Name = "lblLastContactDate"
            Me.lblLastContactDate.Size = New System.Drawing.Size(112, 18)
            Me.lblLastContactDate.TabIndex = 8
            Me.lblLastContactDate.Text = "วันที่ติดต่อล่าสุด:"
            Me.lblLastContactDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLastPayDate
            '
            Me.lblLastPayDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLastPayDate.ForeColor = System.Drawing.Color.Black
            Me.lblLastPayDate.Location = New System.Drawing.Point(8, 24)
            Me.lblLastPayDate.Name = "lblLastPayDate"
            Me.lblLastPayDate.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.lblLastPayDate.Size = New System.Drawing.Size(128, 18)
            Me.lblLastPayDate.TabIndex = 0
            Me.lblLastPayDate.Text = "วันที่ชำระครั้งล่าสุด:"
            Me.lblLastPayDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'picMap
            '
            Me.picMap.Location = New System.Drawing.Point(0, 0)
            Me.picMap.Name = "picMap"
            Me.picMap.Size = New System.Drawing.Size(320, 160)
            Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.picMap.TabIndex = 6
            Me.picMap.TabStop = False
            '
            'lblTaxRate
            '
            Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxRate.ForeColor = System.Drawing.Color.Black
            Me.lblTaxRate.Location = New System.Drawing.Point(8, 96)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(128, 18)
            Me.lblTaxRate.TabIndex = 6
            Me.lblTaxRate.Text = "อัตราภาษี:"
            Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSummaryDiscount
            '
            Me.lblSummaryDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSummaryDiscount.ForeColor = System.Drawing.Color.Black
            Me.lblSummaryDiscount.Location = New System.Drawing.Point(8, 48)
            Me.lblSummaryDiscount.Name = "lblSummaryDiscount"
            Me.lblSummaryDiscount.Size = New System.Drawing.Size(128, 18)
            Me.lblSummaryDiscount.TabIndex = 2
            Me.lblSummaryDiscount.Text = "ส่วนลดท้ายบิล:"
            Me.lblSummaryDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCreditPeriodFromTransport
            '
            Me.lblCreditPeriodFromTransport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPeriodFromTransport.ForeColor = System.Drawing.Color.Black
            Me.lblCreditPeriodFromTransport.Location = New System.Drawing.Point(8, 96)
            Me.lblCreditPeriodFromTransport.Name = "lblCreditPeriodFromTransport"
            Me.lblCreditPeriodFromTransport.Size = New System.Drawing.Size(128, 18)
            Me.lblCreditPeriodFromTransport.TabIndex = 2
            Me.lblCreditPeriodFromTransport.Text = "เครดิตจากวันส่งของ:"
            Me.lblCreditPeriodFromTransport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblReceiveDay
            '
            Me.lblReceiveDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveDay.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveDay.Location = New System.Drawing.Point(16, 24)
            Me.lblReceiveDay.Name = "lblReceiveDay"
            Me.lblReceiveDay.Size = New System.Drawing.Size(88, 18)
            Me.lblReceiveDay.TabIndex = 0
            Me.lblReceiveDay.Text = "ทุกวัน:"
            Me.lblReceiveDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblReceiveDate
            '
            Me.lblReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveDate.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveDate.Location = New System.Drawing.Point(16, 48)
            Me.lblReceiveDate.Name = "lblReceiveDate"
            Me.lblReceiveDate.Size = New System.Drawing.Size(88, 18)
            Me.lblReceiveDate.TabIndex = 3
            Me.lblReceiveDate.Text = "ทุกวันที่:"
            Me.lblReceiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblReceiveWeek
            '
            Me.lblReceiveWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceiveWeek.ForeColor = System.Drawing.Color.Black
            Me.lblReceiveWeek.Location = New System.Drawing.Point(16, 72)
            Me.lblReceiveWeek.Name = "lblReceiveWeek"
            Me.lblReceiveWeek.Size = New System.Drawing.Size(88, 18)
            Me.lblReceiveWeek.TabIndex = 6
            Me.lblReceiveWeek.Text = "ทุกสัปดาห์:"
            Me.lblReceiveWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBillRecWeek
            '
            Me.lblBillRecWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillRecWeek.ForeColor = System.Drawing.Color.Black
            Me.lblBillRecWeek.Location = New System.Drawing.Point(8, 72)
            Me.lblBillRecWeek.Name = "lblBillRecWeek"
            Me.lblBillRecWeek.Size = New System.Drawing.Size(88, 18)
            Me.lblBillRecWeek.TabIndex = 6
            Me.lblBillRecWeek.Text = "ทุกสัปดาห์:"
            Me.lblBillRecWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBillRecDate
            '
            Me.lblBillRecDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillRecDate.ForeColor = System.Drawing.Color.Black
            Me.lblBillRecDate.Location = New System.Drawing.Point(8, 48)
            Me.lblBillRecDate.Name = "lblBillRecDate"
            Me.lblBillRecDate.Size = New System.Drawing.Size(88, 18)
            Me.lblBillRecDate.TabIndex = 3
            Me.lblBillRecDate.Text = "ทุกวันที่:"
            Me.lblBillRecDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBillRecDay
            '
            Me.lblBillRecDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillRecDay.ForeColor = System.Drawing.Color.Black
            Me.lblBillRecDay.Location = New System.Drawing.Point(8, 24)
            Me.lblBillRecDay.Name = "lblBillRecDay"
            Me.lblBillRecDay.Size = New System.Drawing.Size(88, 18)
            Me.lblBillRecDay.TabIndex = 0
            Me.lblBillRecDay.Text = "ทุกวัน:"
            Me.lblBillRecDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSummaryDiscount
            '
            Me.Validator.SetDataType(Me.txtSummaryDiscount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSummaryDiscount, "")
            Me.txtSummaryDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSummaryDiscount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSummaryDiscount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSummaryDiscount, System.Drawing.Color.Empty)
            Me.txtSummaryDiscount.Location = New System.Drawing.Point(136, 48)
            Me.txtSummaryDiscount.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtSummaryDiscount, "")
            Me.Validator.SetMinValue(Me.txtSummaryDiscount, "")
            Me.txtSummaryDiscount.Name = "txtSummaryDiscount"
            Me.Validator.SetRegularExpression(Me.txtSummaryDiscount, "")
            Me.Validator.SetRequired(Me.txtSummaryDiscount, False)
            Me.txtSummaryDiscount.Size = New System.Drawing.Size(104, 21)
            Me.txtSummaryDiscount.TabIndex = 3
            Me.txtSummaryDiscount.Text = ""
            '
            'txtTaxRate
            '
            Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxRate, "")
            Me.txtTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtTaxRate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.txtTaxRate.Location = New System.Drawing.Point(136, 96)
            Me.txtTaxRate.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtTaxRate, "")
            Me.Validator.SetMinValue(Me.txtTaxRate, "")
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
            Me.Validator.SetRequired(Me.txtTaxRate, False)
            Me.txtTaxRate.Size = New System.Drawing.Size(104, 21)
            Me.txtTaxRate.TabIndex = 7
            Me.txtTaxRate.Text = ""
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
            Me.dtpBirthDate.TabIndex = 2
            '
            'lblCreditPeriodUnit
            '
            Me.lblCreditPeriodUnit.AutoSize = True
            Me.lblCreditPeriodUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPeriodUnit.ForeColor = System.Drawing.Color.Black
            Me.lblCreditPeriodUnit.Location = New System.Drawing.Point(240, 48)
            Me.lblCreditPeriodUnit.Name = "lblCreditPeriodUnit"
            Me.lblCreditPeriodUnit.Size = New System.Drawing.Size(17, 17)
            Me.lblCreditPeriodUnit.TabIndex = 8
            Me.lblCreditPeriodUnit.Text = "วัน"
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
            Me.dtpLastContactDate.TabIndex = 4
            '
            'txtReceiveDate
            '
            Me.Validator.SetDataType(Me.txtReceiveDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReceiveDate, "")
            Me.txtReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveDate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveDate, System.Drawing.Color.Empty)
            Me.txtReceiveDate.Location = New System.Drawing.Point(104, 48)
            Me.Validator.SetMaxValue(Me.txtReceiveDate, "")
            Me.Validator.SetMinValue(Me.txtReceiveDate, "")
            Me.txtReceiveDate.Name = "txtReceiveDate"
            Me.txtReceiveDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReceiveDate, "")
            Me.Validator.SetRequired(Me.txtReceiveDate, False)
            Me.txtReceiveDate.Size = New System.Drawing.Size(112, 21)
            Me.txtReceiveDate.TabIndex = 4
            Me.txtReceiveDate.TabStop = False
            Me.txtReceiveDate.Text = ""
            '
            'txtReceiveWeek
            '
            Me.Validator.SetDataType(Me.txtReceiveWeek, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReceiveWeek, "")
            Me.txtReceiveWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveWeek, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveWeek, System.Drawing.Color.Empty)
            Me.txtReceiveWeek.Location = New System.Drawing.Point(104, 72)
            Me.Validator.SetMaxValue(Me.txtReceiveWeek, "")
            Me.Validator.SetMinValue(Me.txtReceiveWeek, "")
            Me.txtReceiveWeek.Name = "txtReceiveWeek"
            Me.txtReceiveWeek.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReceiveWeek, "")
            Me.Validator.SetRequired(Me.txtReceiveWeek, False)
            Me.txtReceiveWeek.Size = New System.Drawing.Size(112, 21)
            Me.txtReceiveWeek.TabIndex = 7
            Me.txtReceiveWeek.TabStop = False
            Me.txtReceiveWeek.Text = ""
            '
            'txtCreditPeriodFromTransport
            '
            Me.Validator.SetDataType(Me.txtCreditPeriodFromTransport, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCreditPeriodFromTransport, "")
            Me.txtCreditPeriodFromTransport.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCreditPeriodFromTransport, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCreditPeriodFromTransport, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCreditPeriodFromTransport, System.Drawing.Color.Empty)
            Me.txtCreditPeriodFromTransport.Location = New System.Drawing.Point(136, 96)
            Me.txtCreditPeriodFromTransport.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtCreditPeriodFromTransport, "")
            Me.Validator.SetMinValue(Me.txtCreditPeriodFromTransport, "")
            Me.txtCreditPeriodFromTransport.Name = "txtCreditPeriodFromTransport"
            Me.Validator.SetRegularExpression(Me.txtCreditPeriodFromTransport, "")
            Me.Validator.SetRequired(Me.txtCreditPeriodFromTransport, False)
            Me.txtCreditPeriodFromTransport.Size = New System.Drawing.Size(104, 21)
            Me.txtCreditPeriodFromTransport.TabIndex = 3
            Me.txtCreditPeriodFromTransport.Text = ""
            '
            'txtBillRecWeek
            '
            Me.Validator.SetDataType(Me.txtBillRecWeek, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillRecWeek, "")
            Me.txtBillRecWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillRecWeek, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBillRecWeek, System.Drawing.Color.Empty)
            Me.txtBillRecWeek.Location = New System.Drawing.Point(104, 72)
            Me.Validator.SetMaxValue(Me.txtBillRecWeek, "")
            Me.Validator.SetMinValue(Me.txtBillRecWeek, "")
            Me.txtBillRecWeek.Name = "txtBillRecWeek"
            Me.txtBillRecWeek.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBillRecWeek, "")
            Me.Validator.SetRequired(Me.txtBillRecWeek, False)
            Me.txtBillRecWeek.Size = New System.Drawing.Size(112, 21)
            Me.txtBillRecWeek.TabIndex = 7
            Me.txtBillRecWeek.TabStop = False
            Me.txtBillRecWeek.Text = ""
            '
            'txtBillRecDate
            '
            Me.Validator.SetDataType(Me.txtBillRecDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillRecDate, "")
            Me.txtBillRecDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillRecDate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBillRecDate, System.Drawing.Color.Empty)
            Me.txtBillRecDate.Location = New System.Drawing.Point(104, 48)
            Me.Validator.SetMaxValue(Me.txtBillRecDate, "")
            Me.Validator.SetMinValue(Me.txtBillRecDate, "")
            Me.txtBillRecDate.Name = "txtBillRecDate"
            Me.txtBillRecDate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBillRecDate, "")
            Me.Validator.SetRequired(Me.txtBillRecDate, False)
            Me.txtBillRecDate.Size = New System.Drawing.Size(112, 21)
            Me.txtBillRecDate.TabIndex = 4
            Me.txtBillRecDate.TabStop = False
            Me.txtBillRecDate.Text = ""
            '
            'grbCredit
            '
            Me.grbCredit.Controls.Add(Me.cmbCreditType)
            Me.grbCredit.Controls.Add(Me.lblCreditType)
            Me.grbCredit.Controls.Add(Me.lblCreditPeriod)
            Me.grbCredit.Controls.Add(Me.txtCreditPeriod)
            Me.grbCredit.Controls.Add(Me.lblCreditPeriodUnit)
            Me.grbCredit.Controls.Add(Me.lblCreditAmount)
            Me.grbCredit.Controls.Add(Me.txtCreditAmount)
            Me.grbCredit.Controls.Add(Me.txtCreditPeriodFromTransport)
            Me.grbCredit.Controls.Add(Me.lblCreditPeriodFromTransport)
            Me.grbCredit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbCredit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbCredit.Location = New System.Drawing.Point(560, 24)
            Me.grbCredit.Name = "grbCredit"
            Me.grbCredit.Size = New System.Drawing.Size(256, 128)
            Me.grbCredit.TabIndex = 7
            Me.grbCredit.TabStop = False
            Me.grbCredit.Text = "เครดิต"
            '
            'cmbCreditType
            '
            Me.cmbCreditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCreditType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.cmbCreditType.Location = New System.Drawing.Point(136, 21)
            Me.cmbCreditType.Name = "cmbCreditType"
            Me.cmbCreditType.Size = New System.Drawing.Size(104, 21)
            Me.cmbCreditType.TabIndex = 5
            '
            'grbBillRec
            '
            Me.grbBillRec.Controls.Add(Me.ImbBillRecDay)
            Me.grbBillRec.Controls.Add(Me.txtBillRecWeek)
            Me.grbBillRec.Controls.Add(Me.txtBillRecDate)
            Me.grbBillRec.Controls.Add(Me.lblBillRecWeek)
            Me.grbBillRec.Controls.Add(Me.lblBillRecDate)
            Me.grbBillRec.Controls.Add(Me.lblBillRecDay)
            Me.grbBillRec.Controls.Add(Me.txtBillRecDay)
            Me.grbBillRec.Controls.Add(Me.ImbBillRecDate)
            Me.grbBillRec.Controls.Add(Me.ImbBillRecWeek)
            Me.grbBillRec.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbBillRec.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbBillRec.Location = New System.Drawing.Point(304, 192)
            Me.grbBillRec.Name = "grbBillRec"
            Me.grbBillRec.Size = New System.Drawing.Size(248, 104)
            Me.grbBillRec.TabIndex = 4
            Me.grbBillRec.TabStop = False
            Me.grbBillRec.Text = "เงื่อนไขการวางบิล"
            '
            'ImbBillRecDay
            '
            Me.ImbBillRecDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbBillRecDay.Image = CType(resources.GetObject("ImbBillRecDay.Image"), System.Drawing.Image)
            Me.ImbBillRecDay.Location = New System.Drawing.Point(216, 24)
            Me.ImbBillRecDay.Name = "ImbBillRecDay"
            Me.ImbBillRecDay.Size = New System.Drawing.Size(24, 23)
            Me.ImbBillRecDay.TabIndex = 2
            Me.ImbBillRecDay.TabStop = False
            Me.ImbBillRecDay.ThemedImage = CType(resources.GetObject("ImbBillRecDay.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtBillRecDay
            '
            Me.Validator.SetDataType(Me.txtBillRecDay, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillRecDay, "")
            Me.txtBillRecDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillRecDay, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBillRecDay, System.Drawing.Color.Empty)
            Me.txtBillRecDay.Location = New System.Drawing.Point(104, 24)
            Me.Validator.SetMaxValue(Me.txtBillRecDay, "")
            Me.Validator.SetMinValue(Me.txtBillRecDay, "")
            Me.txtBillRecDay.Name = "txtBillRecDay"
            Me.txtBillRecDay.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBillRecDay, "")
            Me.Validator.SetRequired(Me.txtBillRecDay, False)
            Me.txtBillRecDay.Size = New System.Drawing.Size(112, 21)
            Me.txtBillRecDay.TabIndex = 1
            Me.txtBillRecDay.TabStop = False
            Me.txtBillRecDay.Text = ""
            '
            'ImbBillRecDate
            '
            Me.ImbBillRecDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbBillRecDate.Image = CType(resources.GetObject("ImbBillRecDate.Image"), System.Drawing.Image)
            Me.ImbBillRecDate.Location = New System.Drawing.Point(216, 48)
            Me.ImbBillRecDate.Name = "ImbBillRecDate"
            Me.ImbBillRecDate.Size = New System.Drawing.Size(24, 23)
            Me.ImbBillRecDate.TabIndex = 5
            Me.ImbBillRecDate.TabStop = False
            Me.ImbBillRecDate.ThemedImage = CType(resources.GetObject("ImbBillRecDate.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImbBillRecWeek
            '
            Me.ImbBillRecWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbBillRecWeek.Image = CType(resources.GetObject("ImbBillRecWeek.Image"), System.Drawing.Image)
            Me.ImbBillRecWeek.Location = New System.Drawing.Point(216, 72)
            Me.ImbBillRecWeek.Name = "ImbBillRecWeek"
            Me.ImbBillRecWeek.Size = New System.Drawing.Size(24, 23)
            Me.ImbBillRecWeek.TabIndex = 8
            Me.ImbBillRecWeek.TabStop = False
            Me.ImbBillRecWeek.ThemedImage = CType(resources.GetObject("ImbBillRecWeek.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbFinancial
            '
            Me.grbFinancial.Controls.Add(Me.txtLastPaydate)
            Me.grbFinancial.Controls.Add(Me.lblLastPayDate)
            Me.grbFinancial.Controls.Add(Me.lblSummaryDiscount)
            Me.grbFinancial.Controls.Add(Me.txtSummaryDiscount)
            Me.grbFinancial.Controls.Add(Me.txtDetailDiscount)
            Me.grbFinancial.Controls.Add(Me.lblDetailDiscount)
            Me.grbFinancial.Controls.Add(Me.txtTaxRate)
            Me.grbFinancial.Controls.Add(Me.lblTaxRate)
            Me.grbFinancial.Controls.Add(Me.lblCheckAmountOnHand)
            Me.grbFinancial.Controls.Add(Me.txtCheckAmountOnHand)
            Me.grbFinancial.Controls.Add(Me.dtpLastPayDate)
            Me.grbFinancial.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbFinancial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbFinancial.Location = New System.Drawing.Point(560, 192)
            Me.grbFinancial.Name = "grbFinancial"
            Me.grbFinancial.Size = New System.Drawing.Size(248, 184)
            Me.grbFinancial.TabIndex = 8
            Me.grbFinancial.TabStop = False
            Me.grbFinancial.Text = "ทางด้านการเงิน"
            '
            'txtLastPaydate
            '
            Me.Validator.SetDataType(Me.txtLastPaydate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLastPaydate, "")
            Me.txtLastPaydate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtLastPaydate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtLastPaydate, -15)
            Me.Validator.SetInvalidBackColor(Me.txtLastPaydate, System.Drawing.Color.Empty)
            Me.txtLastPaydate.Location = New System.Drawing.Point(136, 24)
            Me.txtLastPaydate.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtLastPaydate, "")
            Me.Validator.SetMinValue(Me.txtLastPaydate, "")
            Me.txtLastPaydate.Name = "txtLastPaydate"
            Me.Validator.SetRegularExpression(Me.txtLastPaydate, "")
            Me.Validator.SetRequired(Me.txtLastPaydate, False)
            Me.txtLastPaydate.Size = New System.Drawing.Size(83, 21)
            Me.txtLastPaydate.TabIndex = 1
            Me.txtLastPaydate.Text = ""
            '
            'dtpLastPayDate
            '
            Me.dtpLastPayDate.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpLastPayDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpLastPayDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpLastPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpLastPayDate.Location = New System.Drawing.Point(136, 24)
            Me.dtpLastPayDate.Name = "dtpLastPayDate"
            Me.dtpLastPayDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpLastPayDate.TabIndex = 0
            '
            'grbCustomer
            '
            Me.grbCustomer.Controls.Add(Me.lblPicSize)
            Me.grbCustomer.Controls.Add(Me.btnLoadImage)
            Me.grbCustomer.Controls.Add(Me.btnClearImage)
            Me.grbCustomer.Controls.Add(Me.txtLastContactdate)
            Me.grbCustomer.Controls.Add(Me.txtBirtdate)
            Me.grbCustomer.Controls.Add(Me.txtHomePage)
            Me.grbCustomer.Controls.Add(Me.lblName)
            Me.grbCustomer.Controls.Add(Me.txtName)
            Me.grbCustomer.Controls.Add(Me.lblCode)
            Me.grbCustomer.Controls.Add(Me.txtCode)
            Me.grbCustomer.Controls.Add(Me.lblbirthDate)
            Me.grbCustomer.Controls.Add(Me.lblHomePage)
            Me.grbCustomer.Controls.Add(Me.picImage)
            Me.grbCustomer.Controls.Add(Me.lblLastContactDate)
            Me.grbCustomer.Controls.Add(Me.dtpBirthDate)
            Me.grbCustomer.Controls.Add(Me.dtpLastContactDate)
            Me.grbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbCustomer.Location = New System.Drawing.Point(8, 24)
            Me.grbCustomer.Name = "grbCustomer"
            Me.grbCustomer.Size = New System.Drawing.Size(544, 160)
            Me.grbCustomer.TabIndex = 0
            Me.grbCustomer.TabStop = False
            Me.grbCustomer.Text = "รายละเอียดลูกค้า"
            '
            'lblPicSize
            '
            Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPicSize.Location = New System.Drawing.Point(426, 64)
            Me.lblPicSize.Name = "lblPicSize"
            Me.lblPicSize.TabIndex = 201
            Me.lblPicSize.Text = "120 X 120 pixel"
            Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnLoadImage
            '
            Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLoadImage.Image = CType(resources.GetObject("btnLoadImage.Image"), System.Drawing.Image)
            Me.btnLoadImage.Location = New System.Drawing.Point(488, 136)
            Me.btnLoadImage.Name = "btnLoadImage"
            Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
            Me.btnLoadImage.TabIndex = 60
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
            Me.btnClearImage.TabIndex = 61
            Me.btnClearImage.TabStop = False
            Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtLastContactdate
            '
            'Me.Validator.SetDataType(Me.txtLastContactdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            'Me.Validator.SetDisplayName(Me.txtLastContactdate, "")
            'Me.Validator.SetGotFocusBackColor(Me.txtLastContactdate, System.Drawing.Color.Empty)
            'Me.Validator.SetInvalidBackColor(Me.txtLastContactdate, System.Drawing.Color.Empty)
            Me.txtLastContactdate.Location = New System.Drawing.Point(120, 120)
            'Me.Validator.SetMaxValue(Me.txtLastContactdate, "")
            'Me.Validator.SetMinValue(Me.txtLastContactdate, "")
            Me.txtLastContactdate.Name = "txtLastContactdate"
            'Me.Validator.SetRegularExpression(Me.txtLastContactdate, "")
            'Me.Validator.SetRequired(Me.txtLastContactdate, False)
            Me.txtLastContactdate.Size = New System.Drawing.Size(106, 21)
            Me.txtLastContactdate.TabIndex = 9
            Me.txtLastContactdate.Text = ""
            '
            'txtBirtdate
            '
            'Me.Validator.SetDataType(Me.txtBirtdate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            'Me.Validator.SetDisplayName(Me.txtBirtdate, "")
            'Me.Validator.SetGotFocusBackColor(Me.txtBirtdate, System.Drawing.Color.Empty)
            'Me.Validator.SetInvalidBackColor(Me.txtBirtdate, System.Drawing.Color.Empty)
            Me.txtBirtdate.Location = New System.Drawing.Point(120, 72)
            'Me.Validator.SetMaxValue(Me.txtBirtdate, "")
            'Me.Validator.SetMinValue(Me.txtBirtdate, "")
            Me.txtBirtdate.Name = "txtBirtdate"
            'Me.Validator.SetRegularExpression(Me.txtBirtdate, "")
            'Me.Validator.SetRequired(Me.txtBirtdate, False)
            Me.txtBirtdate.Size = New System.Drawing.Size(106, 21)
            Me.txtBirtdate.TabIndex = 5
            Me.txtBirtdate.Text = ""
            '
            'grbMap
            '
            Me.grbMap.Controls.Add(Me.pnlPicHolder)
            Me.grbMap.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMap.Location = New System.Drawing.Point(8, 192)
            Me.grbMap.Name = "grbMap"
            Me.grbMap.Size = New System.Drawing.Size(288, 184)
            Me.grbMap.TabIndex = 1
            Me.grbMap.TabStop = False
            Me.grbMap.Text = "แผนที่"
            '
            'pnlPicHolder
            '
            Me.pnlPicHolder.AutoScroll = True
            Me.pnlPicHolder.Controls.Add(Me.picMap)
            Me.pnlPicHolder.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlPicHolder.Location = New System.Drawing.Point(3, 17)
            Me.pnlPicHolder.Name = "pnlPicHolder"
            Me.pnlPicHolder.Size = New System.Drawing.Size(282, 164)
            Me.pnlPicHolder.TabIndex = 0
            '
            'PrimaryGroupBoxControl
            '
            Me.PrimaryGroupBoxControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnLoadMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnClearMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnShowMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbRecieve)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnOk)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.btnCancel)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbMap)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbCustomer)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbBillRec)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbFinancial)
            Me.PrimaryGroupBoxControl.Controls.Add(Me.grbCredit)
            Me.PrimaryGroupBoxControl.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.PrimaryGroupBoxControl.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.PrimaryGroupBoxControl.ForeColor = System.Drawing.Color.Blue
            Me.PrimaryGroupBoxControl.Location = New System.Drawing.Point(8, 8)
            Me.PrimaryGroupBoxControl.Name = "PrimaryGroupBoxControl"
            Me.PrimaryGroupBoxControl.Size = New System.Drawing.Size(824, 440)
            Me.PrimaryGroupBoxControl.TabIndex = 0
            Me.PrimaryGroupBoxControl.TabStop = False
            Me.PrimaryGroupBoxControl.Text = "ข้อมูลหลัก"
            '
            'btnLoadMap
            '
            Me.btnLoadMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnLoadMap.ForeColor = System.Drawing.SystemColors.Control
            Me.btnLoadMap.Image = CType(resources.GetObject("btnLoadMap.Image"), System.Drawing.Image)
            Me.btnLoadMap.Location = New System.Drawing.Point(224, 376)
            Me.btnLoadMap.Name = "btnLoadMap"
            Me.btnLoadMap.Size = New System.Drawing.Size(24, 23)
            Me.btnLoadMap.TabIndex = 58
            Me.btnLoadMap.TabStop = False
            Me.btnLoadMap.ThemedImage = CType(resources.GetObject("btnLoadMap.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnClearMap
            '
            Me.btnClearMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnClearMap.Image = CType(resources.GetObject("btnClearMap.Image"), System.Drawing.Image)
            Me.btnClearMap.Location = New System.Drawing.Point(272, 376)
            Me.btnClearMap.Name = "btnClearMap"
            Me.btnClearMap.Size = New System.Drawing.Size(24, 23)
            Me.btnClearMap.TabIndex = 59
            Me.btnClearMap.TabStop = False
            Me.btnClearMap.ThemedImage = CType(resources.GetObject("btnClearMap.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnShowMap
            '
            Me.btnShowMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnShowMap.ForeColor = System.Drawing.SystemColors.Control
            Me.btnShowMap.Image = CType(resources.GetObject("btnShowMap.Image"), System.Drawing.Image)
            Me.btnShowMap.Location = New System.Drawing.Point(248, 376)
            Me.btnShowMap.Name = "btnShowMap"
            Me.btnShowMap.Size = New System.Drawing.Size(24, 23)
            Me.btnShowMap.TabIndex = 57
            Me.btnShowMap.TabStop = False
            Me.btnShowMap.ThemedImage = CType(resources.GetObject("btnShowMap.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbRecieve
            '
            Me.grbRecieve.Controls.Add(Me.ImbReceiveDay)
            Me.grbRecieve.Controls.Add(Me.lblReceiveDate)
            Me.grbRecieve.Controls.Add(Me.lblReceiveWeek)
            Me.grbRecieve.Controls.Add(Me.txtReceiveDate)
            Me.grbRecieve.Controls.Add(Me.txtReceiveDay)
            Me.grbRecieve.Controls.Add(Me.txtReceiveWeek)
            Me.grbRecieve.Controls.Add(Me.lblReceiveDay)
            Me.grbRecieve.Controls.Add(Me.ImbReceiveDate)
            Me.grbRecieve.Controls.Add(Me.ImbReceiveWeek)
            Me.grbRecieve.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbRecieve.Location = New System.Drawing.Point(304, 304)
            Me.grbRecieve.Name = "grbRecieve"
            Me.grbRecieve.Size = New System.Drawing.Size(248, 104)
            Me.grbRecieve.TabIndex = 5
            Me.grbRecieve.TabStop = False
            Me.grbRecieve.Text = "เงื่อนไขการรับชำระหนี้"
            '
            'ImbReceiveDay
            '
            Me.ImbReceiveDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbReceiveDay.Image = CType(resources.GetObject("ImbReceiveDay.Image"), System.Drawing.Image)
            Me.ImbReceiveDay.Location = New System.Drawing.Point(216, 24)
            Me.ImbReceiveDay.Name = "ImbReceiveDay"
            Me.ImbReceiveDay.Size = New System.Drawing.Size(24, 23)
            Me.ImbReceiveDay.TabIndex = 2
            Me.ImbReceiveDay.TabStop = False
            Me.ImbReceiveDay.ThemedImage = CType(resources.GetObject("ImbReceiveDay.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtReceiveDay
            '
            Me.Validator.SetDataType(Me.txtReceiveDay, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtReceiveDay, "")
            Me.txtReceiveDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtReceiveDay, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtReceiveDay, System.Drawing.Color.Empty)
            Me.txtReceiveDay.Location = New System.Drawing.Point(104, 24)
            Me.Validator.SetMaxValue(Me.txtReceiveDay, "")
            Me.Validator.SetMinValue(Me.txtReceiveDay, "")
            Me.txtReceiveDay.Name = "txtReceiveDay"
            Me.txtReceiveDay.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtReceiveDay, "")
            Me.Validator.SetRequired(Me.txtReceiveDay, False)
            Me.txtReceiveDay.Size = New System.Drawing.Size(112, 21)
            Me.txtReceiveDay.TabIndex = 1
            Me.txtReceiveDay.TabStop = False
            Me.txtReceiveDay.Text = ""
            '
            'ImbReceiveDate
            '
            Me.ImbReceiveDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbReceiveDate.Image = CType(resources.GetObject("ImbReceiveDate.Image"), System.Drawing.Image)
            Me.ImbReceiveDate.Location = New System.Drawing.Point(216, 48)
            Me.ImbReceiveDate.Name = "ImbReceiveDate"
            Me.ImbReceiveDate.Size = New System.Drawing.Size(24, 23)
            Me.ImbReceiveDate.TabIndex = 5
            Me.ImbReceiveDate.TabStop = False
            Me.ImbReceiveDate.ThemedImage = CType(resources.GetObject("ImbReceiveDate.ThemedImage"), System.Drawing.Bitmap)
            '
            'ImbReceiveWeek
            '
            Me.ImbReceiveWeek.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ImbReceiveWeek.Image = CType(resources.GetObject("ImbReceiveWeek.Image"), System.Drawing.Image)
            Me.ImbReceiveWeek.Location = New System.Drawing.Point(216, 72)
            Me.ImbReceiveWeek.Name = "ImbReceiveWeek"
            Me.ImbReceiveWeek.Size = New System.Drawing.Size(24, 23)
            Me.ImbReceiveWeek.TabIndex = 8
            Me.ImbReceiveWeek.TabStop = False
            Me.ImbReceiveWeek.ThemedImage = CType(resources.GetObject("ImbReceiveWeek.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnOk
            '
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnOk.ForeColor = System.Drawing.Color.Black
            Me.btnOk.Location = New System.Drawing.Point(608, 384)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(96, 24)
            Me.btnOk.TabIndex = 9
            Me.btnOk.Text = "OK"
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(712, 384)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(96, 24)
            Me.btnCancel.TabIndex = 0
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
            'CustAuxDetailView
            '
            Me.Controls.Add(Me.PrimaryGroupBoxControl)
            Me.Name = "CustAuxDetailView"
            Me.Size = New System.Drawing.Size(840, 456)
            Me.grbCredit.ResumeLayout(False)
            Me.grbBillRec.ResumeLayout(False)
            Me.grbFinancial.ResumeLayout(False)
            Me.grbCustomer.ResumeLayout(False)
            Me.grbMap.ResumeLayout(False)
            Me.pnlPicHolder.ResumeLayout(False)
            Me.PrimaryGroupBoxControl.ResumeLayout(False)
            Me.grbRecieve.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Overrides Sub SetLabelText()

            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblbirthDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblbirthDate}")
            Me.lblSummaryDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblSummaryDiscount}")
            Me.lblCreditPeriodFromTransport.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblCreditPeriodFromTransport}")
            Me.lblCreditPeriod.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblCreditPeriod}")
            Me.lblHomePage.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblHomePage}")
            Me.lblCheckAmountOnHand.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblCheckAmountOnHand}")
            Me.lblCreditAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblCreditAmount}")
            Me.lblCreditType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblCreditType}")
            Me.lblDetailDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblDetailDiscount}")
            Me.lblLastContactDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblLastContactDate}")
            Me.lblLastPayDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblLastPayDate}")
            Me.lblReceiveDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblReceiveDay}")
            Me.lblReceiveDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblReceiveDate}")
            Me.lblReceiveWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblReceiveWeek}")
            Me.lblBillRecWeek.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblBillRecWeek}")
            Me.lblBillRecDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblBillRecDate}")
            Me.lblBillRecDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblBillRecDay}")
            Me.lblCreditPeriodUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblCreditPeriodUnit}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.lblCode}")
            Me.grbRecieve.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustAuxDetailView.grbRecieve}")
            Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Global.TaxRateText}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
            Me.btnOk.Text = Me.StringParserService.Parse("${res:Global.OKButtonText}")
            Me.btnCancel.Text = Me.StringParserService.Parse("${res:Global.CancelButtonText}")
        End Sub
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
                grbCustomer.Enabled = False
                grbBillRec.Enabled = False
                grbRecieve.Enabled = False
                grbFinancial.Enabled = False
                grbCredit.Enabled = False
                grbMap.Enabled = False
            Else
                For Each ctrl As Control In PrimaryGroupBoxControl.Controls
                    ctrl.Enabled = True
                Next
                grbCustomer.Enabled = True
                grbBillRec.Enabled = True
                grbRecieve.Enabled = True
                grbFinancial.Enabled = True
                grbCredit.Enabled = True
                grbMap.Enabled = True
            End If
        End Sub

        ' เคลียร์ข้อมูลลูกค้าใน control
        Public Overrides Sub ClearDetail()
            For Each ctrl As Control In PrimaryGroupBoxControl.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next
            

            dtpBirthDate.Value = Now.Date
            txtBirtdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

            dtpLastContactDate.Value = Now.Date
            txtLastContactdate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

            dtpLastPayDate.Value = Now.Date
            txtLastPaydate.Text = Me.StringParserService.Parse("${res:Global.BlankDateText}")

            cmbCreditType.SelectedIndex = -1
            cmbCreditType.SelectedIndex = -1

        End Sub

        Protected Overrides Sub EventWiring()
            AddHandler dtpBirthDate.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtBirtdate.Validated, AddressOf Me.ChangeProperty

            AddHandler txtHomePage.TextChanged, AddressOf Me.ChangeProperty

            AddHandler dtpLastContactDate.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtLastContactdate.Validated, AddressOf Me.ChangeProperty

            AddHandler txtBillRecDate.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtBillRecWeek.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtReceiveDate.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtReceiveWeek.TextChanged, AddressOf Me.ChangeProperty

            AddHandler dtpLastPayDate.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtLastPaydate.Validated, AddressOf Me.ChangeProperty

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
            txtHomePage.Text = Me.m_entity.HomePage

            dtpBirthDate.Value = MinDateToNow(Me.m_entity.BirthDate)
            txtBirtdate.Text = MinDateToNull(Me.m_entity.BirthDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

            dtpLastContactDate.Value = MinDateToNow(Me.m_entity.LastContactDate)
            txtLastContactdate.Text = MinDateToNull(Me.m_entity.LastContactDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

            dtpLastPayDate.Value = MinDateToNow(Me.m_entity.LastPayDate)
            txtLastPaydate.Text = MinDateToNull(Me.m_entity.LastPayDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

            
            txtBillRecDay.Text = DateTimeService.GetDayStrings(Me.m_entity.BillrecDays, False)
            txtBillRecDate.Text = ConvertItemsToValueArray(Me.m_entity.BillRecDates)
            txtBillRecWeek.Text = ConvertItemsToValueArray(Me.m_entity.BillRecWeeks)

            txtReceiveDay.Text = DateTimeService.GetDayStrings(Me.m_entity.ReceiveDays, False)
            txtReceiveDate.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveDates)
            txtReceiveWeek.Text = ConvertItemsToValueArray(Me.m_entity.ReceiveWeeks)

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
                        DateToString(dtpBirthDate, txtBirtdate)
                        Me.m_entity.BirthDate = dtpBirthDate.Value

                    Case "txtbirtdate"
                        Dim dt As DateTime = StringToDate(txtBirtdate, dtpBirthDate)
                        Me.m_entity.BirthDate = dt

                    Case "dtplastpaydate"
                        DateToString(dtpLastPayDate, txtLastPaydate)
                        Me.m_entity.LastPayDate = dtpLastPayDate.Value

                    Case "txtlastpaydate"
                        Dim dt As DateTime = StringToDate(txtLastPaydate, dtpLastPayDate)
                        Me.m_entity.LastPayDate = dt

                    Case "dtplastcontactdate"
                        DateToString(dtpLastContactDate, txtLastContactdate)
                        Me.m_entity.LastContactDate = Me.dtpLastContactDate.Value

                    Case "txtlastcontactdate"
                        Dim dt As DateTime = StringToDate(txtLastContactdate, dtpLastContactDate)
                        Me.m_entity.LastContactDate = dt

                    Case "txthomepage"
                        Me.m_entity.HomePage = txtHomePage.Text

                    Case "txtbillrecdate"
                        Me.m_entity.BillRecDates = txtBillRecDate.Text
                    Case "txtbillrecweek"
                        Me.m_entity.BillRecWeeks = txtBillRecWeek.Text

                    Case "txtreceivedate"
                        Me.m_entity.ReceiveDates = txtReceiveDate.Text

                    Case "txtreceiveweek"
                        Me.m_entity.ReceiveWeeks = txtReceiveWeek.Text

                    Case "txtdetaildiscount"
                        Me.m_entity.DetailDiscount.Rate = txtDetailDiscount.Text

                    Case "txtsummarydiscount"
                        Me.m_entity.SummaryDiscount.Rate = txtSummaryDiscount.Text

                    Case "txttaxrate"
                        If txtTaxRate.TextLength > 0 Then
                            Me.m_entity.TaxRate = CDec(txtTaxRate.Text)
                        Else
                            Me.m_entity.TaxRate = Nothing
                        End If

                    Case "txtcheckamountonhand"
                        If txtCheckAmountOnHand.TextLength > 0 Then
                            Me.m_entity.CheckAmountOnHand = CDec(txtCheckAmountOnHand.Text)
                        Else
                            Me.m_entity.CheckAmountOnHand = Nothing
                        End If

                    Case "cmbcredittype"
                        Me.m_entity.CreditType.Value = CInt(cmbCreditType.SelectedValue)

                    Case "txtcreditperiod"
                        If txtCreditPeriod.TextLength > 0 Then
                            Me.m_entity.CreditPeriod = CInt(txtCreditPeriod.Text)
                        Else
                            Me.m_entity.CreditPeriod = Nothing
                        End If

                    Case "txtcreditamount"
                        If txtCreditAmount.TextLength > 0 Then
                            Me.m_entity.CreditAmount = CDec(txtCreditAmount.Text)
                        Else
                            Me.m_entity.CreditAmount = Nothing
                        End If

                    Case "txtcreditperiodfromtransport"
                        If txtCreditPeriodFromTransport.TextLength > 0 Then
                            Me.m_entity.CreditPeriodFromTransport = CInt(txtCreditPeriodFromTransport.Text)
                        Else
                            Me.m_entity.CreditPeriodFromTransport = Nothing
                        End If

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
                Me.m_entity = CType(Value, Customer)
                Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
                Me.SaveProperties()
                Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
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
                Me.txtBillRecDate.Text = chkdlg.CheckedItemsString
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
                Me.txtBillRecDay.Text = chkdlg.CheckedItemsString
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
                Me.txtBillRecWeek.Text = chkdlg.CheckedItemsString
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
                Me.txtReceiveDay.Text = chkdlg.CheckedItemsString
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
                Me.txtReceiveDate.Text = chkdlg.CheckedItemsString
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
                Me.txtReceiveWeek.Text = chkdlg.CheckedItemsString
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
        Private m_oldBillrecDays As String
        Private m_oldBillRecDates As String
        Private m_oldBillRecWeeks As String
        Private m_oldReceiveDays As String
        Private m_oldReceiveDates As String
        Private m_oldReceiveWeeks As String
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
            Me.m_entity.BillrecDays = m_oldBillrecDays
            Me.m_entity.BillRecDates = m_oldBillRecDates
            Me.m_entity.BillRecWeeks = m_oldBillRecWeeks
            Me.m_entity.ReceiveDays = m_oldReceiveDays
            Me.m_entity.ReceiveDates = m_oldReceiveDates
            Me.m_entity.ReceiveWeeks = m_oldReceiveWeeks
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
        End Sub
        Public Sub SaveProperties() Implements IReversibleEntityProperty.SaveProperties
            Dim myContent As IViewContent = WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent
            m_oldStatusIsDirty = myContent.IsDirty
            m_oldBirthdate = Me.m_entity.BirthDate
            m_oldHomePage = Me.m_entity.HomePage
            m_oldLastContactDate = Me.m_entity.LastContactDate
            m_oldBillrecDays = Me.m_entity.BillrecDays
            m_oldBillRecDates = Me.m_entity.BillRecDates
            m_oldBillRecWeeks = Me.m_entity.BillRecWeeks
            m_oldReceiveDays = Me.m_entity.ReceiveDays
            m_oldReceiveDates = Me.m_entity.ReceiveDates
            m_oldReceiveWeeks = Me.m_entity.ReceiveWeeks
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

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

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
'Todo: เพิ่ม CheckListBox