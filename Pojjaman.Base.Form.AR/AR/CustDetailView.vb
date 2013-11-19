Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class CustDetailView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          'Clear the memory
          Me.m_entity = Nothing
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
    Friend WithEvents btnAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAuxDetail As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtBillingAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtAltName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtAuthorizeAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxID As System.Windows.Forms.TextBox
    Friend WithEvents rdJuris As System.Windows.Forms.RadioButton
    Friend WithEvents rdIndividual As System.Windows.Forms.RadioButton
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents primaryDetailGroupBox As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents otherDetailGroupBox As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblAltName As System.Windows.Forms.Label
    Friend WithEvents lblBillingAddress As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents lblPersonType As System.Windows.Forms.Label
    Friend WithEvents lblCustGroup As System.Windows.Forms.Label
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents lblAuthorizeAmount As System.Windows.Forms.Label
    Friend WithEvents lblTaxID As System.Windows.Forms.Label
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents chkcancel As System.Windows.Forms.CheckBox
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents ImageButton1 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ImageButton2 As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtIdNo As System.Windows.Forms.TextBox
    Friend WithEvents lblIdNo As System.Windows.Forms.Label
    Friend WithEvents btnGroupEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAccountEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGroup As System.Windows.Forms.TextBox
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents cmbProvince As System.Windows.Forms.ComboBox
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents lblMobile As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents txtBranch As System.Windows.Forms.TextBox
        Friend WithEvents lblBranch As System.Windows.Forms.Label
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustDetailView))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.lblItem = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.btnAuxDetail = New System.Windows.Forms.Button()
            Me.primaryDetailGroupBox = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.cmbProvince = New System.Windows.Forms.ComboBox()
            Me.chkcancel = New System.Windows.Forms.CheckBox()
            Me.txtEmail = New System.Windows.Forms.TextBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.lblName = New System.Windows.Forms.Label()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.lblAltName = New System.Windows.Forms.Label()
            Me.txtBillingAddress = New System.Windows.Forms.TextBox()
            Me.lblBillingAddress = New System.Windows.Forms.Label()
            Me.txtAltName = New System.Windows.Forms.TextBox()
            Me.txtAddress = New System.Windows.Forms.TextBox()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.txtPhone = New System.Windows.Forms.TextBox()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.txtFax = New System.Windows.Forms.TextBox()
            Me.lblFax = New System.Windows.Forms.Label()
            Me.lblProvince = New System.Windows.Forms.Label()
            Me.lblMobile = New System.Windows.Forms.Label()
            Me.txtMobile = New System.Windows.Forms.TextBox()
            Me.otherDetailGroupBox = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txtAccount = New System.Windows.Forms.TextBox()
            Me.txtGroup = New System.Windows.Forms.TextBox()
            Me.btnAccountEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnGroupEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.rdJuris = New System.Windows.Forms.RadioButton()
            Me.txtAuthorizeAmount = New System.Windows.Forms.TextBox()
            Me.lblAuthorizeAmount = New System.Windows.Forms.Label()
            Me.txtTaxID = New System.Windows.Forms.TextBox()
            Me.lblTaxID = New System.Windows.Forms.Label()
            Me.lblPersonType = New System.Windows.Forms.Label()
            Me.rdIndividual = New System.Windows.Forms.RadioButton()
            Me.lblCustGroup = New System.Windows.Forms.Label()
            Me.lblAccount = New System.Windows.Forms.Label()
            Me.lblContact = New System.Windows.Forms.Label()
            Me.txtContact = New System.Windows.Forms.TextBox()
            Me.txtAccountName = New System.Windows.Forms.TextBox()
            Me.txtGroupName = New System.Windows.Forms.TextBox()
            Me.txtIdNo = New System.Windows.Forms.TextBox()
            Me.lblIdNo = New System.Windows.Forms.Label()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
            Me.txtBranch = New System.Windows.Forms.TextBox()
            Me.lblBranch = New System.Windows.Forms.Label()
            Me.grbDetail.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.primaryDetailGroupBox.SuspendLayout()
            Me.otherDetailGroupBox.SuspendLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.tgItem)
            Me.grbDetail.Controls.Add(Me.lblItem)
            Me.grbDetail.Controls.Add(Me.lblStatus)
            Me.grbDetail.Controls.Add(Me.btnAuxDetail)
            Me.grbDetail.Controls.Add(Me.primaryDetailGroupBox)
            Me.grbDetail.Controls.Add(Me.otherDetailGroupBox)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbDetail.ForeColor = System.Drawing.Color.Blue
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(768, 510)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "รายละเอียดลูกค้า:"
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
            Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))})
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(360, 303)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(400, 191)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 194
            Me.tgItem.TreeManager = Nothing
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.Black
            Me.lblItem.Location = New System.Drawing.Point(360, 274)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(96, 18)
            Me.lblItem.TabIndex = 193
            Me.lblItem.Text = "Cost Center"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblStatus
            '
            Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.GrayText
            Me.lblStatus.Location = New System.Drawing.Point(8, 486)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(52, 13)
            Me.lblStatus.TabIndex = 3
            Me.lblStatus.Text = "Status จ้า"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnAuxDetail
            '
            Me.btnAuxDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAuxDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAuxDetail.Location = New System.Drawing.Point(656, 274)
            Me.btnAuxDetail.Name = "btnAuxDetail"
            Me.btnAuxDetail.Size = New System.Drawing.Size(96, 23)
            Me.btnAuxDetail.TabIndex = 21
            Me.btnAuxDetail.Text = "เพิ่มเติม"
            '
            'primaryDetailGroupBox
            '
            Me.primaryDetailGroupBox.Controls.Add(Me.cmbCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkAutorun)
            Me.primaryDetailGroupBox.Controls.Add(Me.cmbProvince)
            Me.primaryDetailGroupBox.Controls.Add(Me.chkcancel)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblEmail)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtName)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblName)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblCode)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblAltName)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtBillingAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblBillingAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtAltName)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblAddress)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblPhone)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtFax)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblFax)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblProvince)
            Me.primaryDetailGroupBox.Controls.Add(Me.lblMobile)
            Me.primaryDetailGroupBox.Controls.Add(Me.txtMobile)
            Me.primaryDetailGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.primaryDetailGroupBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.primaryDetailGroupBox.Location = New System.Drawing.Point(8, 24)
            Me.primaryDetailGroupBox.Name = "primaryDetailGroupBox"
            Me.primaryDetailGroupBox.Size = New System.Drawing.Size(336, 320)
            Me.primaryDetailGroupBox.TabIndex = 0
            Me.primaryDetailGroupBox.TabStop = False
            Me.primaryDetailGroupBox.Text = "ข้อมูลเบื้องต้น:"
            '
            'cmbCode
            '
            Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
            Me.cmbCode.Location = New System.Drawing.Point(104, 24)
            Me.cmbCode.Name = "cmbCode"
            Me.cmbCode.Size = New System.Drawing.Size(120, 21)
            Me.cmbCode.TabIndex = 22
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(224, 24)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 20
            '
            'cmbProvince
            '
            Me.cmbProvince.Location = New System.Drawing.Point(104, 192)
            Me.cmbProvince.MaxLength = 100
            Me.cmbProvince.Name = "cmbProvince"
            Me.cmbProvince.Size = New System.Drawing.Size(216, 21)
            Me.cmbProvince.TabIndex = 5
            '
            'chkcancel
            '
            Me.chkcancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkcancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.chkcancel.ForeColor = System.Drawing.Color.Black
            Me.chkcancel.Location = New System.Drawing.Point(256, 25)
            Me.chkcancel.Name = "chkcancel"
            Me.chkcancel.Size = New System.Drawing.Size(64, 20)
            Me.chkcancel.TabIndex = 21
            Me.chkcancel.TabStop = False
            Me.chkcancel.Text = "ยกเลิก"
            '
            'txtEmail
            '
            Me.Validator.SetDataType(Me.txtEmail, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmail, "")
            Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtEmail, System.Drawing.Color.Empty)
            Me.txtEmail.Location = New System.Drawing.Point(104, 288)
            Me.txtEmail.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtEmail, "")
            Me.Validator.SetMinValue(Me.txtEmail, "")
            Me.txtEmail.Name = "txtEmail"
            Me.Validator.SetRegularExpression(Me.txtEmail, "")
            Me.Validator.SetRequired(Me.txtEmail, False)
            Me.txtEmail.Size = New System.Drawing.Size(216, 21)
            Me.txtEmail.TabIndex = 9
            '
            'lblEmail
            '
            Me.lblEmail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmail.ForeColor = System.Drawing.Color.Black
            Me.lblEmail.Location = New System.Drawing.Point(8, 288)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(88, 18)
            Me.lblEmail.TabIndex = 19
            Me.lblEmail.Text = "อีเมล์:"
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(104, 48)
            Me.txtName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(216, 21)
            Me.txtName.TabIndex = 1
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 48)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(88, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(8, 24)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(88, 18)
            Me.lblCode.TabIndex = 10
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAltName
            '
            Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAltName.ForeColor = System.Drawing.Color.Black
            Me.lblAltName.Location = New System.Drawing.Point(8, 72)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(88, 18)
            Me.lblAltName.TabIndex = 12
            Me.lblAltName.Text = "ชื่ออื่น:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBillingAddress
            '
            Me.Validator.SetDataType(Me.txtBillingAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBillingAddress, "")
            Me.txtBillingAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBillingAddress, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtBillingAddress, -15)
            Me.Validator.SetInvalidBackColor(Me.txtBillingAddress, System.Drawing.Color.Empty)
            Me.txtBillingAddress.Location = New System.Drawing.Point(104, 96)
            Me.txtBillingAddress.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtBillingAddress, "")
            Me.Validator.SetMinValue(Me.txtBillingAddress, "")
            Me.txtBillingAddress.Multiline = True
            Me.txtBillingAddress.Name = "txtBillingAddress"
            Me.Validator.SetRegularExpression(Me.txtBillingAddress, "")
            Me.Validator.SetRequired(Me.txtBillingAddress, True)
            Me.txtBillingAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtBillingAddress.Size = New System.Drawing.Size(216, 42)
            Me.txtBillingAddress.TabIndex = 3
            Me.txtBillingAddress.WordWrap = False
            '
            'lblBillingAddress
            '
            Me.lblBillingAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBillingAddress.ForeColor = System.Drawing.Color.Black
            Me.lblBillingAddress.Location = New System.Drawing.Point(8, 96)
            Me.lblBillingAddress.Name = "lblBillingAddress"
            Me.lblBillingAddress.Size = New System.Drawing.Size(88, 18)
            Me.lblBillingAddress.TabIndex = 13
            Me.lblBillingAddress.Text = "ที่อยู่ตามเอกสาร:"
            Me.lblBillingAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAltName
            '
            Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAltName, "")
            Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.txtAltName.Location = New System.Drawing.Point(104, 72)
            Me.txtAltName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtAltName, "")
            Me.Validator.SetMinValue(Me.txtAltName, "")
            Me.txtAltName.Name = "txtAltName"
            Me.Validator.SetRegularExpression(Me.txtAltName, "")
            Me.Validator.SetRequired(Me.txtAltName, False)
            Me.txtAltName.Size = New System.Drawing.Size(216, 21)
            Me.txtAltName.TabIndex = 2
            '
            'txtAddress
            '
            Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAddress, "")
            Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
            Me.txtAddress.Location = New System.Drawing.Point(104, 144)
            Me.txtAddress.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtAddress, "")
            Me.Validator.SetMinValue(Me.txtAddress, "")
            Me.txtAddress.Multiline = True
            Me.txtAddress.Name = "txtAddress"
            Me.Validator.SetRegularExpression(Me.txtAddress, "")
            Me.Validator.SetRequired(Me.txtAddress, False)
            Me.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtAddress.Size = New System.Drawing.Size(216, 42)
            Me.txtAddress.TabIndex = 4
            Me.txtAddress.WordWrap = False
            '
            'lblAddress
            '
            Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.Black
            Me.lblAddress.Location = New System.Drawing.Point(8, 144)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(88, 18)
            Me.lblAddress.TabIndex = 14
            Me.lblAddress.Text = "ที่อยู่ปัจจุบัน:"
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhone
            '
            Me.Validator.SetDataType(Me.txtPhone, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPhone, "")
            Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
            Me.txtPhone.Location = New System.Drawing.Point(104, 216)
            Me.txtPhone.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtPhone, "")
            Me.Validator.SetMinValue(Me.txtPhone, "")
            Me.txtPhone.Name = "txtPhone"
            Me.Validator.SetRegularExpression(Me.txtPhone, "")
            Me.Validator.SetRequired(Me.txtPhone, False)
            Me.txtPhone.Size = New System.Drawing.Size(216, 21)
            Me.txtPhone.TabIndex = 6
            '
            'lblPhone
            '
            Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPhone.ForeColor = System.Drawing.Color.Black
            Me.lblPhone.Location = New System.Drawing.Point(8, 216)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(88, 18)
            Me.lblPhone.TabIndex = 16
            Me.lblPhone.Text = "โทรศัพท์:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFax
            '
            Me.Validator.SetDataType(Me.txtFax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFax, "")
            Me.txtFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtFax, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFax, System.Drawing.Color.Empty)
            Me.txtFax.Location = New System.Drawing.Point(104, 264)
            Me.txtFax.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtFax, "")
            Me.Validator.SetMinValue(Me.txtFax, "")
            Me.txtFax.Name = "txtFax"
            Me.Validator.SetRegularExpression(Me.txtFax, "")
            Me.Validator.SetRequired(Me.txtFax, False)
            Me.txtFax.Size = New System.Drawing.Size(216, 21)
            Me.txtFax.TabIndex = 8
            '
            'lblFax
            '
            Me.lblFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFax.ForeColor = System.Drawing.Color.Black
            Me.lblFax.Location = New System.Drawing.Point(8, 264)
            Me.lblFax.Name = "lblFax"
            Me.lblFax.Size = New System.Drawing.Size(88, 18)
            Me.lblFax.TabIndex = 18
            Me.lblFax.Text = "โทรสาร:"
            Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProvince
            '
            Me.lblProvince.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProvince.ForeColor = System.Drawing.Color.Black
            Me.lblProvince.Location = New System.Drawing.Point(8, 192)
            Me.lblProvince.Name = "lblProvince"
            Me.lblProvince.Size = New System.Drawing.Size(88, 18)
            Me.lblProvince.TabIndex = 15
            Me.lblProvince.Text = "จังหวัด:"
            Me.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMobile
            '
            Me.lblMobile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblMobile.ForeColor = System.Drawing.Color.Black
            Me.lblMobile.Location = New System.Drawing.Point(8, 240)
            Me.lblMobile.Name = "lblMobile"
            Me.lblMobile.Size = New System.Drawing.Size(88, 18)
            Me.lblMobile.TabIndex = 17
            Me.lblMobile.Text = "โทรศัพท์มือถือ:"
            Me.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMobile
            '
            Me.Validator.SetDataType(Me.txtMobile, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMobile, "")
            Me.txtMobile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtMobile, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMobile, System.Drawing.Color.Empty)
            Me.txtMobile.Location = New System.Drawing.Point(104, 240)
            Me.txtMobile.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtMobile, "")
            Me.Validator.SetMinValue(Me.txtMobile, "")
            Me.txtMobile.Name = "txtMobile"
            Me.Validator.SetRegularExpression(Me.txtMobile, "")
            Me.Validator.SetRequired(Me.txtMobile, False)
            Me.txtMobile.Size = New System.Drawing.Size(216, 21)
            Me.txtMobile.TabIndex = 7
            '
            'otherDetailGroupBox
            '
            Me.otherDetailGroupBox.Controls.Add(Me.txtBranch)
            Me.otherDetailGroupBox.Controls.Add(Me.lblBranch)
            Me.otherDetailGroupBox.Controls.Add(Me.txtAccount)
            Me.otherDetailGroupBox.Controls.Add(Me.txtGroup)
            Me.otherDetailGroupBox.Controls.Add(Me.btnAccountEdit)
            Me.otherDetailGroupBox.Controls.Add(Me.btnGroupEdit)
            Me.otherDetailGroupBox.Controls.Add(Me.btnGroupFind)
            Me.otherDetailGroupBox.Controls.Add(Me.btnAccountFind)
            Me.otherDetailGroupBox.Controls.Add(Me.rdJuris)
            Me.otherDetailGroupBox.Controls.Add(Me.txtAuthorizeAmount)
            Me.otherDetailGroupBox.Controls.Add(Me.lblAuthorizeAmount)
            Me.otherDetailGroupBox.Controls.Add(Me.txtTaxID)
            Me.otherDetailGroupBox.Controls.Add(Me.lblTaxID)
            Me.otherDetailGroupBox.Controls.Add(Me.lblPersonType)
            Me.otherDetailGroupBox.Controls.Add(Me.rdIndividual)
            Me.otherDetailGroupBox.Controls.Add(Me.lblCustGroup)
            Me.otherDetailGroupBox.Controls.Add(Me.lblAccount)
            Me.otherDetailGroupBox.Controls.Add(Me.lblContact)
            Me.otherDetailGroupBox.Controls.Add(Me.txtContact)
            Me.otherDetailGroupBox.Controls.Add(Me.txtAccountName)
            Me.otherDetailGroupBox.Controls.Add(Me.txtGroupName)
            Me.otherDetailGroupBox.Controls.Add(Me.txtIdNo)
            Me.otherDetailGroupBox.Controls.Add(Me.lblIdNo)
            Me.otherDetailGroupBox.Controls.Add(Me.lblNote)
            Me.otherDetailGroupBox.Controls.Add(Me.txtNote)
            Me.otherDetailGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.otherDetailGroupBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.otherDetailGroupBox.Location = New System.Drawing.Point(352, 24)
            Me.otherDetailGroupBox.Name = "otherDetailGroupBox"
            Me.otherDetailGroupBox.Size = New System.Drawing.Size(408, 247)
            Me.otherDetailGroupBox.TabIndex = 1
            Me.otherDetailGroupBox.TabStop = False
            Me.otherDetailGroupBox.Text = "ข้อมูลอื่น ๆ:"
            '
            'txtAccount
            '
            Me.Validator.SetDataType(Me.txtAccount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccount, "")
            Me.txtAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccount, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccount, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccount, System.Drawing.Color.Empty)
            Me.txtAccount.Location = New System.Drawing.Point(136, 72)
            Me.txtAccount.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtAccount, "")
            Me.Validator.SetMinValue(Me.txtAccount, "")
            Me.txtAccount.Name = "txtAccount"
            Me.txtAccount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccount, "")
            Me.Validator.SetRequired(Me.txtAccount, False)
            Me.txtAccount.Size = New System.Drawing.Size(88, 21)
            Me.txtAccount.TabIndex = 14
            Me.txtAccount.Tag = "NotGigaSite"
            '
            'txtGroup
            '
            Me.Validator.SetDataType(Me.txtGroup, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroup, "")
            Me.txtGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroup, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtGroup, -15)
            Me.Validator.SetInvalidBackColor(Me.txtGroup, System.Drawing.Color.Empty)
            Me.txtGroup.Location = New System.Drawing.Point(136, 48)
            Me.txtGroup.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtGroup, "")
            Me.Validator.SetMinValue(Me.txtGroup, "")
            Me.txtGroup.Name = "txtGroup"
            Me.Validator.SetRegularExpression(Me.txtGroup, "")
            Me.Validator.SetRequired(Me.txtGroup, True)
            Me.txtGroup.Size = New System.Drawing.Size(88, 21)
            Me.txtGroup.TabIndex = 2
            '
            'btnAccountEdit
            '
            Me.btnAccountEdit.Enabled = False
            Me.btnAccountEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEdit.Location = New System.Drawing.Point(376, 71)
            Me.btnAccountEdit.Name = "btnAccountEdit"
            Me.btnAccountEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountEdit.TabIndex = 21
            Me.btnAccountEdit.TabStop = False
            Me.btnAccountEdit.Tag = "NotGigaSite"
            Me.btnAccountEdit.ThemedImage = CType(resources.GetObject("btnAccountEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnGroupEdit
            '
            Me.btnGroupEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnGroupEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupEdit.Location = New System.Drawing.Point(376, 47)
            Me.btnGroupEdit.Name = "btnGroupEdit"
            Me.btnGroupEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupEdit.TabIndex = 22
            Me.btnGroupEdit.TabStop = False
            Me.btnGroupEdit.ThemedImage = CType(resources.GetObject("btnGroupEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnGroupFind
            '
            Me.btnGroupFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnGroupFind.Location = New System.Drawing.Point(352, 47)
            Me.btnGroupFind.Name = "btnGroupFind"
            Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
            Me.btnGroupFind.TabIndex = 13
            Me.btnGroupFind.TabStop = False
            Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnAccountFind
            '
            Me.btnAccountFind.Enabled = False
            Me.btnAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountFind.Location = New System.Drawing.Point(352, 71)
            Me.btnAccountFind.Name = "btnAccountFind"
            Me.btnAccountFind.Size = New System.Drawing.Size(24, 23)
            Me.btnAccountFind.TabIndex = 15
            Me.btnAccountFind.TabStop = False
            Me.btnAccountFind.Tag = "NotGigaSite"
            Me.btnAccountFind.ThemedImage = CType(resources.GetObject("btnAccountFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'rdJuris
            '
            Me.rdJuris.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdJuris.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.rdJuris.ForeColor = System.Drawing.Color.Black
            Me.rdJuris.Location = New System.Drawing.Point(136, 24)
            Me.rdJuris.Name = "rdJuris"
            Me.rdJuris.Size = New System.Drawing.Size(88, 24)
            Me.rdJuris.TabIndex = 0
            Me.rdJuris.Text = "นิติบุคคล"
            '
            'txtAuthorizeAmount
            '
            Me.Validator.SetDataType(Me.txtAuthorizeAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtAuthorizeAmount, "")
            Me.txtAuthorizeAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAuthorizeAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAuthorizeAmount, System.Drawing.Color.Empty)
            Me.txtAuthorizeAmount.Location = New System.Drawing.Point(136, 96)
            Me.Validator.SetMaxValue(Me.txtAuthorizeAmount, "")
            Me.Validator.SetMinValue(Me.txtAuthorizeAmount, "")
            Me.txtAuthorizeAmount.Name = "txtAuthorizeAmount"
            Me.Validator.SetRegularExpression(Me.txtAuthorizeAmount, "")
            Me.Validator.SetRequired(Me.txtAuthorizeAmount, False)
            Me.txtAuthorizeAmount.Size = New System.Drawing.Size(264, 21)
            Me.txtAuthorizeAmount.TabIndex = 16
            '
            'lblAuthorizeAmount
            '
            Me.lblAuthorizeAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAuthorizeAmount.ForeColor = System.Drawing.Color.Black
            Me.lblAuthorizeAmount.Location = New System.Drawing.Point(8, 96)
            Me.lblAuthorizeAmount.Name = "lblAuthorizeAmount"
            Me.lblAuthorizeAmount.Size = New System.Drawing.Size(120, 18)
            Me.lblAuthorizeAmount.TabIndex = 12
            Me.lblAuthorizeAmount.Text = "ทุนจดทะเบียน:"
            Me.lblAuthorizeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxID
            '
            Me.Validator.SetDataType(Me.txtTaxID, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxID, "")
            Me.txtTaxID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtTaxID, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxID, System.Drawing.Color.Empty)
            Me.txtTaxID.Location = New System.Drawing.Point(136, 120)
            Me.txtTaxID.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtTaxID, "")
            Me.Validator.SetMinValue(Me.txtTaxID, "")
            Me.txtTaxID.Name = "txtTaxID"
            Me.Validator.SetRegularExpression(Me.txtTaxID, "")
            Me.Validator.SetRequired(Me.txtTaxID, False)
            Me.txtTaxID.Size = New System.Drawing.Size(264, 21)
            Me.txtTaxID.TabIndex = 17
            '
            'lblTaxID
            '
            Me.lblTaxID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxID.ForeColor = System.Drawing.Color.Black
            Me.lblTaxID.Location = New System.Drawing.Point(8, 120)
            Me.lblTaxID.Name = "lblTaxID"
            Me.lblTaxID.Size = New System.Drawing.Size(120, 18)
            Me.lblTaxID.TabIndex = 13
            Me.lblTaxID.Text = "เลขประจำตัวผู้เสียภาษี:"
            Me.lblTaxID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPersonType
            '
            Me.lblPersonType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPersonType.ForeColor = System.Drawing.Color.Black
            Me.lblPersonType.Location = New System.Drawing.Point(8, 24)
            Me.lblPersonType.Name = "lblPersonType"
            Me.lblPersonType.Size = New System.Drawing.Size(120, 18)
            Me.lblPersonType.TabIndex = 9
            Me.lblPersonType.Text = "ประเภทบุคคล:"
            Me.lblPersonType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'rdIndividual
            '
            Me.rdIndividual.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdIndividual.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.rdIndividual.ForeColor = System.Drawing.Color.Black
            Me.rdIndividual.Location = New System.Drawing.Point(224, 24)
            Me.rdIndividual.Name = "rdIndividual"
            Me.rdIndividual.Size = New System.Drawing.Size(112, 24)
            Me.rdIndividual.TabIndex = 1
            Me.rdIndividual.Text = "บุคคลธรรมดา"
            '
            'lblCustGroup
            '
            Me.lblCustGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustGroup.ForeColor = System.Drawing.Color.Black
            Me.lblCustGroup.Location = New System.Drawing.Point(8, 48)
            Me.lblCustGroup.Name = "lblCustGroup"
            Me.lblCustGroup.Size = New System.Drawing.Size(120, 18)
            Me.lblCustGroup.TabIndex = 10
            Me.lblCustGroup.Text = "กลุ่มลูกค้า:"
            Me.lblCustGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAccount
            '
            Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccount.ForeColor = System.Drawing.Color.Black
            Me.lblAccount.Location = New System.Drawing.Point(8, 72)
            Me.lblAccount.Name = "lblAccount"
            Me.lblAccount.Size = New System.Drawing.Size(120, 18)
            Me.lblAccount.TabIndex = 11
            Me.lblAccount.Tag = "NotGigaSite"
            Me.lblAccount.Text = "บัญชี:"
            Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblContact
            '
            Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblContact.ForeColor = System.Drawing.Color.Black
            Me.lblContact.Location = New System.Drawing.Point(8, 193)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(120, 18)
            Me.lblContact.TabIndex = 15
            Me.lblContact.Text = "ผู้ประสานงาน:"
            Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtContact
            '
            Me.Validator.SetDataType(Me.txtContact, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtContact, "")
            Me.txtContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtContact, System.Drawing.Color.Empty)
            Me.txtContact.Location = New System.Drawing.Point(136, 193)
            Me.txtContact.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtContact, "")
            Me.Validator.SetMinValue(Me.txtContact, "")
            Me.txtContact.Name = "txtContact"
            Me.Validator.SetRegularExpression(Me.txtContact, "")
            Me.Validator.SetRequired(Me.txtContact, False)
            Me.txtContact.Size = New System.Drawing.Size(264, 21)
            Me.txtContact.TabIndex = 19
            '
            'txtAccountName
            '
            Me.Validator.SetDataType(Me.txtAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountName, "")
            Me.txtAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAccountName, System.Drawing.Color.Empty)
            Me.txtAccountName.Location = New System.Drawing.Point(224, 72)
            Me.Validator.SetMaxValue(Me.txtAccountName, "")
            Me.Validator.SetMinValue(Me.txtAccountName, "")
            Me.txtAccountName.Name = "txtAccountName"
            Me.txtAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAccountName, "")
            Me.Validator.SetRequired(Me.txtAccountName, False)
            Me.txtAccountName.Size = New System.Drawing.Size(128, 21)
            Me.txtAccountName.TabIndex = 18
            Me.txtAccountName.Tag = "NotGigaSite"
            '
            'txtGroupName
            '
            Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGroupName, "")
            Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
            Me.txtGroupName.Location = New System.Drawing.Point(224, 48)
            Me.Validator.SetMaxValue(Me.txtGroupName, "")
            Me.Validator.SetMinValue(Me.txtGroupName, "")
            Me.txtGroupName.Name = "txtGroupName"
            Me.txtGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGroupName, "")
            Me.Validator.SetRequired(Me.txtGroupName, False)
            Me.txtGroupName.Size = New System.Drawing.Size(128, 21)
            Me.txtGroupName.TabIndex = 17
            '
            'txtIdNo
            '
            Me.Validator.SetDataType(Me.txtIdNo, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtIdNo, "")
            Me.txtIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtIdNo, System.Drawing.Color.Empty)
            Me.txtIdNo.Location = New System.Drawing.Point(136, 169)
            Me.txtIdNo.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtIdNo, "")
            Me.Validator.SetMinValue(Me.txtIdNo, "")
            Me.txtIdNo.Name = "txtIdNo"
            Me.Validator.SetRegularExpression(Me.txtIdNo, "")
            Me.Validator.SetRequired(Me.txtIdNo, False)
            Me.txtIdNo.Size = New System.Drawing.Size(264, 21)
            Me.txtIdNo.TabIndex = 18
            '
            'lblIdNo
            '
            Me.lblIdNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblIdNo.ForeColor = System.Drawing.Color.Black
            Me.lblIdNo.Location = New System.Drawing.Point(8, 169)
            Me.lblIdNo.Name = "lblIdNo"
            Me.lblIdNo.Size = New System.Drawing.Size(120, 18)
            Me.lblIdNo.TabIndex = 14
            Me.lblIdNo.Text = "เลขประจำตัวประชาชน:"
            Me.lblIdNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNote
            '
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.ForeColor = System.Drawing.Color.Black
            Me.lblNote.Location = New System.Drawing.Point(8, 217)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(120, 18)
            Me.lblNote.TabIndex = 16
            Me.lblNote.Text = "หมายเหตุ:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(136, 217)
            Me.txtNote.MaxLength = 250
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.Size = New System.Drawing.Size(264, 21)
            Me.txtNote.TabIndex = 20
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
            'txtBranch
            '
            Me.Validator.SetDataType(Me.txtBranch, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int32Type)
            Me.Validator.SetDisplayName(Me.txtBranch, "")
            Me.txtBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBranch, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBranch, System.Drawing.Color.Empty)
            Me.txtBranch.Location = New System.Drawing.Point(137, 144)
            Me.txtBranch.MaxLength = 5
            Me.Validator.SetMaxValue(Me.txtBranch, "")
            Me.Validator.SetMinValue(Me.txtBranch, "")
            Me.txtBranch.Name = "txtBranch"
            Me.Validator.SetRegularExpression(Me.txtBranch, "")
            Me.Validator.SetRequired(Me.txtBranch, False)
            Me.txtBranch.Size = New System.Drawing.Size(111, 21)
            Me.txtBranch.TabIndex = 24
            '
            'lblBranch
            '
            Me.lblBranch.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBranch.ForeColor = System.Drawing.Color.Black
            Me.lblBranch.Location = New System.Drawing.Point(40, 144)
            Me.lblBranch.Name = "lblBranch"
            Me.lblBranch.Size = New System.Drawing.Size(88, 18)
            Me.lblBranch.TabIndex = 23
            Me.lblBranch.Text = "สาขาที่:"
            Me.lblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CustDetailView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "CustDetailView"
            Me.Size = New System.Drawing.Size(784, 526)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.primaryDetailGroupBox.ResumeLayout(False)
            Me.primaryDetailGroupBox.PerformLayout()
            Me.otherDetailGroupBox.ResumeLayout(False)
            Me.otherDetailGroupBox.PerformLayout()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
    Public Overrides Sub SetLabelText()
      If Not Me.m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblIdNo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblIdNo}")
      Me.Validator.SetDisplayName(Me.txtIdNo, Me.lblIdNo.Text)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblCode}")
      Me.Validator.SetDisplayName(cmbCode, lblCode.Text)

      Me.lblName.Text = Me.StringParserService.Parse("${res:Global.NameText}")
      Me.Validator.SetDisplayName(txtName, lblName.Text)

      Me.lblAltName.Text = Me.StringParserService.Parse("${res:Global.AltNameText}")
      Me.Validator.SetDisplayName(txtAltName, lblAltName.Text)

      Me.lblBillingAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblBillingAddress}")
      Me.Validator.SetDisplayName(Me.txtBillingAddress, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.txtBillingAddressAlert}"))

      Me.chkcancel.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.chkCancel}")

      Me.lblAddress.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblAddress}")
      Me.Validator.SetDisplayName(txtAddress, lblAddress.Text)

      Me.lblPhone.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblPhone}")
      Me.Validator.SetDisplayName(txtPhone, lblPhone.Text)

      Me.lblFax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblFax}")
      Me.Validator.SetDisplayName(txtFax, lblFax.Text)

      Me.lblEmail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblEmail}")
      Me.Validator.SetDisplayName(txtEmail, lblEmail.Text)

      Me.lblPersonType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblPersonType}")

      Me.rdJuris.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.rdJuris}")
      Me.rdIndividual.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.rdIndividual}")

      Me.lblCustGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblCustGroup}")
      Me.Validator.SetDisplayName(txtGroup, lblCustGroup.Text)

      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblAccount}")
      Me.Validator.SetDisplayName(txtAccount, lblAccount.Text)

      Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblContact}")
      Me.Validator.SetDisplayName(txtContact, lblContact.Text)

      Me.lblAuthorizeAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblAuthorizeAmount}")
      Me.Validator.SetDisplayName(txtAuthorizeAmount, lblAuthorizeAmount.Text)

      Me.lblTaxID.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblTaxID}")
      Me.Validator.SetDisplayName(txtTaxID, lblTaxID.Text)

      Me.btnAuxDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.btnAuxDetail}")

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.grbDetail}")
      Me.primaryDetailGroupBox.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.primaryDetailGroupBox}")
      Me.otherDetailGroupBox.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.otherDetailGroupBox}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblNote}")
      Me.lblMobile.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CustDetailView.lblMobile}")

            Me.lblProvince.Text = Me.StringParserService.Parse("${res:Global.Province}")

            Me.lblBranch.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblBranch}")

    End Sub
#End Region

#Region "Member"
    Private m_entity As Customer
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager
    Private m_combocodeindex As Integer
#End Region

#Region "Property"
    Private Property ComboCodeIndex() As Integer
      Get
        If m_combocodeindex = -1 Then
          If cmbCode.Items.Count > 0 Then
            m_combocodeindex = 0
          End If
        End If
        Return m_combocodeindex
      End Get
      Set(ByVal Value As Integer)
        m_combocodeindex = Value
      End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim dt As TreeTable = Customer.GetSchemaTable()
      Dim dst As DataGridTableStyle = Customer.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False

      EventWiring()
      DisableGigaSiteControl()
    End Sub
    Private Sub DisableGigaSiteControl()
      If Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
        Me.txtAccount.Enabled = False
        Me.btnAccountEdit.Enabled = False
        Me.btnAccountFind.Enabled = False
        Me.lblAccount.Enabled = False
        Me.txtAccountName.Enabled = False
      End If
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub Initialize()
      Province.ListProvinceInComboBox(Me.cmbProvince)
    End Sub
    ' ตรวจสอบสถานะของฟอร์ม
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity.Canceled Then
        For Each ctrl As Control In primaryDetailGroupBox.Controls
          ctrl.Enabled = False
        Next
        Me.chkcancel.Enabled = True
        otherDetailGroupBox.Enabled = False
      Else
        For Each ctrl As Control In primaryDetailGroupBox.Controls
          ctrl.Enabled = True
                Next

                If Me.m_entity.TaxId.Length = 0 Then
                    Me.txtBranch.Enabled = False
                Else
                    Me.txtBranch.Enabled = True
                End If

        otherDetailGroupBox.Enabled = True
      End If
      Dim CanEditAccountEntity As Boolean = Convert.ToBoolean(Configuration.GetConfig("CanEditAccountEntity"))
      If CanEditAccountEntity Then
        Me.txtAccount.ReadOnly = False
        Me.btnAccountEdit.Enabled = True
        Me.btnAccountFind.Enabled = True
        Me.Validator.SetRequired(Me.txtAccount, True)
      End If
    End Sub

    ' เคลียร์ข้อมูลลูกค้าใน control
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crtl As Control In grbDetail.Controls
        If TypeOf crtl Is TextBox Then
          crtl.Text = ""
        End If
      Next

      rdJuris.PerformClick()
      chkcancel.Checked = False

      cmbProvince.SelectedIndex = -1
      cmbProvince.SelectedIndex = -1
    End Sub

    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAltName.TextChanged, AddressOf Me.ChangeProperty

      AddHandler chkcancel.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler txtBillingAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAddress.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtPhone.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtContact.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtFax.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtEmail.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtAuthorizeAmount.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtIdNo.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtMobile.TextChanged, AddressOf Me.ChangeProperty

      AddHandler rdJuris.CheckedChanged, AddressOf Me.ChangeProperty
      AddHandler rdIndividual.CheckedChanged, AddressOf Me.ChangeProperty

      AddHandler txtAccount.Validated, AddressOf Me.ChangeProperty
      AddHandler txtGroup.Validated, AddressOf Me.ChangeProperty

            AddHandler cmbProvince.Validated, AddressOf Me.ChangeProperty

            AddHandler txtTaxID.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtBranch.TextChanged, AddressOf TextHandler
            AddHandler txtBranch.Validated, AddressOf ChangeProperty

    End Sub
    ' แสดงค่าข้อมูลของลูกค้าลงใน control ที่อยู่บนฟอร์ม
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code
      BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
      m_genoldCode = m_entity.Code

      m_entity.LoadImage()

      Me.m_genoldCode = Me.m_entity.Code
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      txtName.Text = m_entity.Name
      txtAltName.Text = m_entity.AlternateName
      txtBillingAddress.Text = m_entity.BillingAddress
      txtAddress.Text = m_entity.Address
      txtPhone.Text = m_entity.Phone
      txtFax.Text = m_entity.Fax
      txtEmail.Text = m_entity.EmailAddress
      txtGroup.Text = m_entity.Group.Code
      txtGroupName.Text = m_entity.Group.Name
      txtAccount.Text = m_entity.Account.Code
      txtAccountName.Text = m_entity.Account.Name
      txtAuthorizeAmount.Text = Configuration.FormatToString(m_entity.AuthorizeAmount, DigitConfig.Price)
            txtTaxID.Text = m_entity.TaxId
            txtBranch.Text = Configuration.BranchString(m_entity.BranchId)
      txtContact.Text = m_entity.Contact
      txtIdNo.Text = Me.m_entity.IdNo
      txtNote.Text = Me.m_entity.Note
      txtMobile.Text = Me.m_entity.Mobile

      If Me.m_entity.PersonType.Value = 0 Then
        rdIndividual.PerformClick()
      Else
        rdJuris.PerformClick()
      End If
      If Me.m_entity.Canceled Then
        chkcancel.Checked = True
      Else
        chkcancel.Checked = False
      End If

      Dim flaginlist As Boolean = False
      For Each item As IdValuePair In cmbProvince.Items
        If item.Value = Me.m_entity.Province Then
          Me.cmbProvince.SelectedItem = item
          flaginlist = True
          Exit For
        End If
      Next
      If Not flaginlist Then
        Me.cmbProvince.Text = Me.m_entity.Province
      End If

      m_treeManager.Treetable = Me.m_entity.GetCCTable

      SetStatus()
      SetLabelText()
      CheckFormEnable()

      m_isInitialized = True
        End Sub

        Private txtbranchchanged As Boolean = False
        Private txtsetting As Boolean = False
        Public Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            If txtsetting Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtbranch"
                    txtbranchchanged = True
            End Select
        End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If

      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
          ComboCodeIndex = cmbCode.SelectedIndex
          m_genoldCode = Me.cmbCode.Text
          dirtyFlag = True

        Case "chkcancel"
          Me.m_entity.Canceled = chkcancel.Checked
          dirtyFlag = True

        Case "txtname"
          Me.m_entity.Name = txtName.Text
          dirtyFlag = True

        Case "txtaltname"
          Me.m_entity.AlternateName = txtAltName.Text
          dirtyFlag = True

        Case "txtidno"
          Me.m_entity.IdNo = txtIdNo.Text
          dirtyFlag = True

        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True

        Case "txtmobile"
          Me.m_entity.Mobile = txtMobile.Text
          dirtyFlag = True

        Case "txtbillingaddress"
          Me.m_entity.BillingAddress = txtBillingAddress.Text
          dirtyFlag = True

        Case "txtaddress"
          Me.m_entity.Address = txtAddress.Text
          dirtyFlag = True

        Case "txtphone"
          Me.m_entity.Phone = txtPhone.Text
          dirtyFlag = True

        Case "txtcontact"
          Me.m_entity.Contact = txtContact.Text
          dirtyFlag = True

        Case "txtfax"
          Me.m_entity.Fax = txtFax.Text
          dirtyFlag = True

        Case "txtemail"
          Me.m_entity.EmailAddress = txtEmail.Text
          dirtyFlag = True

        Case "txtauthorizeamount"
          If IsNumeric(txtAuthorizeAmount.Text) Then
            Try
              Me.m_entity.AuthorizeAmount = CDec(txtAuthorizeAmount.Text)
            Catch ex As Exception

            End Try
          Else
            Me.m_entity.AuthorizeAmount = 0
          End If
          dirtyFlag = True

                Case "txttaxid"

                    If Not IsNumeric(txtTaxID.Text) And txtTaxID.Text <> "" Then
                        txtTaxID.Text = ""
                    Else
                        Me.m_entity.TaxId = txtTaxID.Text.Trim

                        If Me.m_entity.TaxId.Length = 0 Then
                            txtsetting = True
                            Me.m_entity.BranchId = -1
                            txtBranch.Text = Configuration.BranchString(Me.m_entity.BranchId)
                            txtsetting = False
                        Else
                            txtsetting = True
                            Me.m_entity.BranchId = 0
                            txtBranch.Text = Configuration.BranchString(Me.m_entity.BranchId)
                            txtsetting = False
                        End If

                        dirtyFlag = True
                    End If


        Case "rdjuris", "rdindividual"
          If rdJuris.Checked Then
            Me.m_entity.PersonType.Value = 1
          Else
            Me.m_entity.PersonType.Value = 0
          End If
          dirtyFlag = True

        Case "txtgroup"
          dirtyFlag = CustomerGroup.GetCustomerGroup(txtGroup, txtGroupName, Me.m_entity.Group)
          If dirtyFlag Then
            Me.SetAccountFromCustomerGroup()
          End If
        Case "txtaccount"
          dirtyFlag = Account.GetAccount(txtAccount, txtAccountName, Me.m_entity.Account)

        Case "cmbprovince"
          Me.m_entity.Province = Me.cmbProvince.Text
                    dirtyFlag = True

                Case "txtbranch"
                    If txtbranchchanged Then
                        txtbranchchanged = False
                        If IsNumeric(txtBranch.Text) Then

                            Me.m_entity.BranchId = CInt(txtBranch.Text)
                            dirtyFlag = True
                        End If

                        txtsetting = True
                        txtBranch.Text = Configuration.BranchString(Me.m_entity.BranchId)
                        txtsetting = False

                    End If

            End Select

      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag

      CheckFormEnable()

    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
    End Sub
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Nothing
        Me.m_entity = CType(Value, Customer)
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property

#End Region

#Region " AutoGenCode "
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_genoldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        'Me.txtCode.ReadOnly = True
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
        cmbCode.SelectedIndex = ComboCodeIndex
        m_genoldCode = Me.cmbCode.Text
        'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
        'Hack: set Code เป็น "" เอง
        'Me.m_entity.Code = ""
        Me.m_entity.Code = m_genoldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Text = m_genoldCode
        'Me.txtCode.ReadOnly = False
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Private Sub btnAuxDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuxDetail.Click
      Dim myAuxPanel As New Longkong.Pojjaman.Gui.Panels.CustAuxDetailView
      myAuxPanel.Entity = Me.m_entity
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(myAuxPanel)
      If myDialog.ShowDialog() = DialogResult.Cancel Then
        'Me.WorkbenchWindow.ViewContent.IsDirty = True    'neng :ไม่งั้นจะ IsDirty เสมอเมื่อคลิก Cancel
      End If
    End Sub
    Private Sub btnGroupEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CustomerGroup)
    End Sub

    Private Sub btnAccountEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccountEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Account)
    End Sub

    Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
       CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CustomerGroup, AddressOf SetCustomerGroupDialog)
    End Sub

    Private Sub SetCustomerGroupDialog(ByVal e As ISimpleEntity)
      Me.txtGroup.Text = e.Code
      Dim dirty As Boolean = CustomerGroup.GetCustomerGroup(txtGroup, txtGroupName, Me.m_entity.Group)
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or dirty
      If dirty Then
        Me.SetAccountFromCustomerGroup()
      End If
    End Sub

    Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAccountDialog)
    End Sub

    Private Sub SetAccountDialog(ByVal e As ISimpleEntity)
      Me.txtAccount.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Account.GetAccount(txtAccount, txtAccountName, Me.m_entity.Account)
    End Sub

    Private Sub SetAccountFromCustomerGroup()
      Me.txtAccount.Text = ""
      Me.txtAccountName.Text = ""
      Me.m_entity.SetAccountFromCustomerGroup()
      If Not Me.m_entity.Account Is Nothing AndAlso Me.m_entity.Account.Code.Length > 0 Then
        Me.txtAccount.Text = m_entity.Account.Code
        Me.txtAccountName.Text = m_entity.Account.Name
      End If
    End Sub

#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New CustomerGroup).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtgroup", "txtgroupname"
                Return True
            End Select
          End If
        End If
        If data.GetDataPresent((New Account).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtaccount", "txtaccountname"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New CustomerGroup).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CustomerGroup).FullClassName))
        Dim entity As New CustomerGroup(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtgroup", "txtgroupname"
              Me.SetCustomerGroupDialog(entity)
          End Select
        End If
      End If
      If data.GetDataPresent((New Account).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Account).FullClassName))
        Dim entity As New Account(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtaccount", "txtaccountname"
              Me.SetAccountDialog(entity)
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
        Return (New Customer).DetailPanelIcon
      End Get
    End Property
#End Region

    Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
      MyBase.NotifyAfterSave(successful)
      For Each myView As IViewContent In WorkbenchSingleton.Workbench.ViewContentCollection
        For Each o As Object In myView.WorkbenchWindow.SubViewContents
          If TypeOf o Is ICanRefreshAutoComplete Then
            CType(o, ICanRefreshAutoComplete).RefreshAutoComplete(2)
          End If
        Next
      Next
    End Sub
  End Class

End Namespace
