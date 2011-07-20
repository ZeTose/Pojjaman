Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports System.Reflection
Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.Services
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.AddIns
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ConfigurationView
        'Inherits UserControl
        Inherits AbstractOptionPanel
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
        Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
        Friend WithEvents lblTaxType As System.Windows.Forms.Label
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents lblFax As System.Windows.Forms.Label
        Friend WithEvents txtFax As System.Windows.Forms.TextBox
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxID As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxID As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtBillingAddress As System.Windows.Forms.TextBox
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents txtOwner As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
        Friend WithEvents lblBillingAddress As System.Windows.Forms.Label
        Friend WithEvents cmbInvMethod As System.Windows.Forms.ComboBox
        Friend WithEvents lblInvMethod As System.Windows.Forms.Label
        Friend WithEvents cmbCostMethod As System.Windows.Forms.ComboBox
        Friend WithEvents lblostMethod As System.Windows.Forms.Label
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents lblOwner As System.Windows.Forms.Label
        Friend WithEvents lblTaxRate As System.Windows.Forms.Label
        Friend WithEvents grbTax As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents picLogo As System.Windows.Forms.PictureBox
        Friend WithEvents btnLoadImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnClearImage As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtBuilkID As System.Windows.Forms.TextBox
    Friend WithEvents lblBuilkID As System.Windows.Forms.Label
    Friend WithEvents txtBuilkPaymentTrackID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPicSize As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigurationView))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtPhone = New System.Windows.Forms.TextBox()
      Me.txtAddress = New System.Windows.Forms.TextBox()
      Me.txtFax = New System.Windows.Forms.TextBox()
      Me.txtName = New System.Windows.Forms.TextBox()
      Me.txtTaxID = New System.Windows.Forms.TextBox()
      Me.txtBillingAddress = New System.Windows.Forms.TextBox()
      Me.txtAltName = New System.Windows.Forms.TextBox()
      Me.txtOwner = New System.Windows.Forms.TextBox()
      Me.txtTaxRate = New System.Windows.Forms.TextBox()
      Me.txtBuilkID = New System.Windows.Forms.TextBox()
      Me.txtBuilkPaymentTrackID = New System.Windows.Forms.TextBox()
      Me.lblTaxID = New System.Windows.Forms.Label()
      Me.cmbTaxType = New System.Windows.Forms.ComboBox()
      Me.lblTaxType = New System.Windows.Forms.Label()
      Me.lblPhone = New System.Windows.Forms.Label()
      Me.lblFax = New System.Windows.Forms.Label()
      Me.lblAddress = New System.Windows.Forms.Label()
      Me.lblName = New System.Windows.Forms.Label()
      Me.lblBillingAddress = New System.Windows.Forms.Label()
      Me.cmbInvMethod = New System.Windows.Forms.ComboBox()
      Me.lblInvMethod = New System.Windows.Forms.Label()
      Me.cmbCostMethod = New System.Windows.Forms.ComboBox()
      Me.lblostMethod = New System.Windows.Forms.Label()
      Me.lblAltName = New System.Windows.Forms.Label()
      Me.lblOwner = New System.Windows.Forms.Label()
      Me.lblTaxRate = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.grbTax = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.picLogo = New System.Windows.Forms.PictureBox()
      Me.btnLoadImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnClearImage = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblPicSize = New System.Windows.Forms.Label()
      Me.lblBuilkID = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbTax.SuspendLayout()
      CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Validator
      '
      Me.Validator.BackcolorChanging = False
      Me.Validator.DataTable = Nothing
      Me.Validator.ErrorProvider = Nothing
      Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.Validator.HasNewRow = False
      Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      '
      'txtPhone
      '
      Me.Validator.SetDataType(Me.txtPhone, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtPhone, "")
      Me.txtPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtPhone, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtPhone, System.Drawing.Color.Empty)
      Me.txtPhone.Location = New System.Drawing.Point(96, 128)
      Me.txtPhone.MaxLength = 25
      Me.Validator.SetMinValue(Me.txtPhone, "")
      Me.txtPhone.Name = "txtPhone"
      Me.Validator.SetRegularExpression(Me.txtPhone, "")
      Me.Validator.SetRequired(Me.txtPhone, False)
      Me.txtPhone.Size = New System.Drawing.Size(168, 21)
      Me.txtPhone.TabIndex = 5
      '
      'txtAddress
      '
      Me.Validator.SetDataType(Me.txtAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAddress, "")
      Me.txtAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAddress, System.Drawing.Color.Empty)
      Me.txtAddress.Location = New System.Drawing.Point(96, 80)
      Me.txtAddress.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtAddress, "")
      Me.txtAddress.Name = "txtAddress"
      Me.Validator.SetRegularExpression(Me.txtAddress, "")
      Me.Validator.SetRequired(Me.txtAddress, False)
      Me.txtAddress.Size = New System.Drawing.Size(392, 21)
      Me.txtAddress.TabIndex = 3
      '
      'txtFax
      '
      Me.Validator.SetDataType(Me.txtFax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFax, "")
      Me.txtFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtFax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFax, System.Drawing.Color.Empty)
      Me.txtFax.Location = New System.Drawing.Point(96, 152)
      Me.txtFax.MaxLength = 25
      Me.Validator.SetMinValue(Me.txtFax, "")
      Me.txtFax.Name = "txtFax"
      Me.Validator.SetRegularExpression(Me.txtFax, "")
      Me.Validator.SetRequired(Me.txtFax, False)
      Me.txtFax.Size = New System.Drawing.Size(168, 21)
      Me.txtFax.TabIndex = 6
      '
      'txtName
      '
      Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtName, "")
      Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
      Me.txtName.Location = New System.Drawing.Point(96, 8)
      Me.txtName.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtName, "")
      Me.txtName.Name = "txtName"
      Me.Validator.SetRegularExpression(Me.txtName, "")
      Me.Validator.SetRequired(Me.txtName, True)
      Me.txtName.Size = New System.Drawing.Size(392, 21)
      Me.txtName.TabIndex = 0
      '
      'txtTaxID
      '
      Me.Validator.SetDataType(Me.txtTaxID, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxID, "")
      Me.txtTaxID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTaxID, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxID, System.Drawing.Color.Empty)
      Me.txtTaxID.Location = New System.Drawing.Point(136, 56)
      Me.txtTaxID.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtTaxID, "")
      Me.txtTaxID.Name = "txtTaxID"
      Me.Validator.SetRegularExpression(Me.txtTaxID, "")
      Me.Validator.SetRequired(Me.txtTaxID, False)
      Me.txtTaxID.Size = New System.Drawing.Size(96, 21)
      Me.txtTaxID.TabIndex = 2
      '
      'txtBillingAddress
      '
      Me.Validator.SetDataType(Me.txtBillingAddress, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBillingAddress, "")
      Me.txtBillingAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBillingAddress, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBillingAddress, System.Drawing.Color.Empty)
      Me.txtBillingAddress.Location = New System.Drawing.Point(96, 104)
      Me.txtBillingAddress.MaxLength = 255
      Me.Validator.SetMinValue(Me.txtBillingAddress, "")
      Me.txtBillingAddress.Name = "txtBillingAddress"
      Me.Validator.SetRegularExpression(Me.txtBillingAddress, "")
      Me.Validator.SetRequired(Me.txtBillingAddress, False)
      Me.txtBillingAddress.Size = New System.Drawing.Size(392, 21)
      Me.txtBillingAddress.TabIndex = 4
      '
      'txtAltName
      '
      Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAltName, "")
      Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
      Me.txtAltName.Location = New System.Drawing.Point(96, 32)
      Me.txtAltName.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtAltName, "")
      Me.txtAltName.Name = "txtAltName"
      Me.Validator.SetRegularExpression(Me.txtAltName, "")
      Me.Validator.SetRequired(Me.txtAltName, True)
      Me.txtAltName.Size = New System.Drawing.Size(392, 21)
      Me.txtAltName.TabIndex = 1
      '
      'txtOwner
      '
      Me.Validator.SetDataType(Me.txtOwner, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtOwner, "")
      Me.txtOwner.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtOwner, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtOwner, System.Drawing.Color.Empty)
      Me.txtOwner.Location = New System.Drawing.Point(96, 56)
      Me.txtOwner.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtOwner, "")
      Me.txtOwner.Name = "txtOwner"
      Me.Validator.SetRegularExpression(Me.txtOwner, "")
      Me.Validator.SetRequired(Me.txtOwner, True)
      Me.txtOwner.Size = New System.Drawing.Size(392, 21)
      Me.txtOwner.TabIndex = 2
      '
      'txtTaxRate
      '
      Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxRate, "")
      Me.txtTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
      Me.txtTaxRate.Location = New System.Drawing.Point(184, 24)
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, False)
      Me.txtTaxRate.Size = New System.Drawing.Size(48, 21)
      Me.txtTaxRate.TabIndex = 1
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBuilkID
      '
      Me.Validator.SetDataType(Me.txtBuilkID, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuilkID, "")
      Me.txtBuilkID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuilkID, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuilkID, System.Drawing.Color.Empty)
      Me.txtBuilkID.Location = New System.Drawing.Point(99, 326)
      Me.txtBuilkID.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtBuilkID, "")
      Me.txtBuilkID.Name = "txtBuilkID"
      Me.Validator.SetRegularExpression(Me.txtBuilkID, "")
      Me.Validator.SetRequired(Me.txtBuilkID, True)
      Me.txtBuilkID.Size = New System.Drawing.Size(389, 21)
      Me.txtBuilkID.TabIndex = 205
      '
      'txtBuilkPaymentTrackID
      '
      Me.Validator.SetDataType(Me.txtBuilkPaymentTrackID, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtBuilkPaymentTrackID, "")
      Me.txtBuilkPaymentTrackID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtBuilkPaymentTrackID, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtBuilkPaymentTrackID, System.Drawing.Color.Empty)
      Me.txtBuilkPaymentTrackID.Location = New System.Drawing.Point(185, 353)
      Me.txtBuilkPaymentTrackID.MaxLength = 200
      Me.Validator.SetMinValue(Me.txtBuilkPaymentTrackID, "")
      Me.txtBuilkPaymentTrackID.Name = "txtBuilkPaymentTrackID"
      Me.Validator.SetRegularExpression(Me.txtBuilkPaymentTrackID, "")
      Me.Validator.SetRequired(Me.txtBuilkPaymentTrackID, True)
      Me.txtBuilkPaymentTrackID.Size = New System.Drawing.Size(303, 21)
      Me.txtBuilkPaymentTrackID.TabIndex = 207
      '
      'lblTaxID
      '
      Me.lblTaxID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxID.ForeColor = System.Drawing.Color.Black
      Me.lblTaxID.Location = New System.Drawing.Point(8, 56)
      Me.lblTaxID.Name = "lblTaxID"
      Me.lblTaxID.Size = New System.Drawing.Size(120, 18)
      Me.lblTaxID.TabIndex = 4
      Me.lblTaxID.Text = "เลขประจำตัวผู้เสียภาษี:"
      Me.lblTaxID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbTaxType
      '
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbTaxType.Location = New System.Drawing.Point(88, 24)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
      Me.cmbTaxType.TabIndex = 0
      '
      'lblTaxType
      '
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblTaxType.Location = New System.Drawing.Point(8, 24)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(72, 18)
      Me.lblTaxType.TabIndex = 3
      Me.lblTaxType.Text = "ประเภทภาษี:"
      Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblPhone
      '
      Me.lblPhone.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPhone.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblPhone.Location = New System.Drawing.Point(8, 128)
      Me.lblPhone.Name = "lblPhone"
      Me.lblPhone.Size = New System.Drawing.Size(88, 18)
      Me.lblPhone.TabIndex = 16
      Me.lblPhone.Text = "โทรศัพท์:"
      Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFax
      '
      Me.lblFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFax.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblFax.Location = New System.Drawing.Point(8, 152)
      Me.lblFax.Name = "lblFax"
      Me.lblFax.Size = New System.Drawing.Size(88, 18)
      Me.lblFax.TabIndex = 17
      Me.lblFax.Text = "โทรสาร:"
      Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAddress
      '
      Me.lblAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAddress.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblAddress.Location = New System.Drawing.Point(8, 80)
      Me.lblAddress.Name = "lblAddress"
      Me.lblAddress.Size = New System.Drawing.Size(88, 18)
      Me.lblAddress.TabIndex = 14
      Me.lblAddress.Text = "ที่อยู่:"
      Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblName
      '
      Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblName.Location = New System.Drawing.Point(8, 8)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(88, 18)
      Me.lblName.TabIndex = 11
      Me.lblName.Text = "ชื่อ:"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblBillingAddress
      '
      Me.lblBillingAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBillingAddress.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBillingAddress.Location = New System.Drawing.Point(8, 104)
      Me.lblBillingAddress.Name = "lblBillingAddress"
      Me.lblBillingAddress.Size = New System.Drawing.Size(88, 18)
      Me.lblBillingAddress.TabIndex = 15
      Me.lblBillingAddress.Text = "Billing Address:"
      Me.lblBillingAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbInvMethod
      '
      Me.cmbInvMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbInvMethod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbInvMethod.Location = New System.Drawing.Point(96, 176)
      Me.cmbInvMethod.Name = "cmbInvMethod"
      Me.cmbInvMethod.Size = New System.Drawing.Size(168, 21)
      Me.cmbInvMethod.TabIndex = 7
      '
      'lblInvMethod
      '
      Me.lblInvMethod.BackColor = System.Drawing.Color.Transparent
      Me.lblInvMethod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblInvMethod.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblInvMethod.Location = New System.Drawing.Point(8, 176)
      Me.lblInvMethod.Name = "lblInvMethod"
      Me.lblInvMethod.Size = New System.Drawing.Size(88, 18)
      Me.lblInvMethod.TabIndex = 18
      Me.lblInvMethod.Text = "Account System:"
      Me.lblInvMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbCostMethod
      '
      Me.cmbCostMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCostMethod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.cmbCostMethod.Location = New System.Drawing.Point(96, 200)
      Me.cmbCostMethod.Name = "cmbCostMethod"
      Me.cmbCostMethod.Size = New System.Drawing.Size(168, 21)
      Me.cmbCostMethod.TabIndex = 8
      '
      'lblostMethod
      '
      Me.lblostMethod.BackColor = System.Drawing.Color.Transparent
      Me.lblostMethod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblostMethod.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblostMethod.Location = New System.Drawing.Point(8, 200)
      Me.lblostMethod.Name = "lblostMethod"
      Me.lblostMethod.Size = New System.Drawing.Size(88, 18)
      Me.lblostMethod.TabIndex = 19
      Me.lblostMethod.Text = "คิดต้นทุน:"
      Me.lblostMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAltName
      '
      Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAltName.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblAltName.Location = New System.Drawing.Point(8, 32)
      Me.lblAltName.Name = "lblAltName"
      Me.lblAltName.Size = New System.Drawing.Size(88, 18)
      Me.lblAltName.TabIndex = 12
      Me.lblAltName.Text = "ชื่ออื่น:"
      Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblOwner
      '
      Me.lblOwner.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblOwner.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblOwner.Location = New System.Drawing.Point(8, 56)
      Me.lblOwner.Name = "lblOwner"
      Me.lblOwner.Size = New System.Drawing.Size(88, 18)
      Me.lblOwner.TabIndex = 13
      Me.lblOwner.Text = "ผู้ประกอบการ:"
      Me.lblOwner.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblTaxRate.Location = New System.Drawing.Point(144, 24)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(40, 18)
      Me.lblTaxRate.TabIndex = 5
      Me.lblTaxRate.Text = "อัตรา:"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label8
      '
      Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label8.Location = New System.Drawing.Point(224, 24)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(24, 18)
      Me.Label8.TabIndex = 6
      Me.Label8.Text = "%"
      Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'grbTax
      '
      Me.grbTax.Controls.Add(Me.cmbTaxType)
      Me.grbTax.Controls.Add(Me.lblTaxType)
      Me.grbTax.Controls.Add(Me.txtTaxRate)
      Me.grbTax.Controls.Add(Me.lblTaxRate)
      Me.grbTax.Controls.Add(Me.Label8)
      Me.grbTax.Controls.Add(Me.txtTaxID)
      Me.grbTax.Controls.Add(Me.lblTaxID)
      Me.grbTax.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbTax.Location = New System.Drawing.Point(8, 224)
      Me.grbTax.Name = "grbTax"
      Me.grbTax.Size = New System.Drawing.Size(256, 88)
      Me.grbTax.TabIndex = 9
      Me.grbTax.TabStop = False
      Me.grbTax.Text = "ภาษี"
      '
      'picLogo
      '
      Me.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.picLogo.Location = New System.Drawing.Point(280, 128)
      Me.picLogo.Name = "picLogo"
      Me.picLogo.Size = New System.Drawing.Size(160, 192)
      Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picLogo.TabIndex = 21
      Me.picLogo.TabStop = False
      '
      'btnLoadImage
      '
      Me.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnLoadImage.ForeColor = System.Drawing.SystemColors.Control
      Me.btnLoadImage.Location = New System.Drawing.Point(440, 213)
      Me.btnLoadImage.Name = "btnLoadImage"
      Me.btnLoadImage.Size = New System.Drawing.Size(24, 23)
      Me.btnLoadImage.TabIndex = 23
      Me.btnLoadImage.TabStop = False
      Me.btnLoadImage.ThemedImage = CType(resources.GetObject("btnLoadImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnClearImage
      '
      Me.btnClearImage.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnClearImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnClearImage.Location = New System.Drawing.Point(464, 213)
      Me.btnClearImage.Name = "btnClearImage"
      Me.btnClearImage.Size = New System.Drawing.Size(24, 23)
      Me.btnClearImage.TabIndex = 24
      Me.btnClearImage.TabStop = False
      Me.btnClearImage.ThemedImage = CType(resources.GetObject("btnClearImage.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblPicSize
      '
      Me.lblPicSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPicSize.ForeColor = System.Drawing.Color.Blue
      Me.lblPicSize.Location = New System.Drawing.Point(312, 216)
      Me.lblPicSize.Name = "lblPicSize"
      Me.lblPicSize.Size = New System.Drawing.Size(100, 23)
      Me.lblPicSize.TabIndex = 204
      Me.lblPicSize.Text = "120 X 120 pixel"
      Me.lblPicSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblBuilkID
      '
      Me.lblBuilkID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBuilkID.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblBuilkID.Location = New System.Drawing.Point(22, 326)
      Me.lblBuilkID.Name = "lblBuilkID"
      Me.lblBuilkID.Size = New System.Drawing.Size(71, 18)
      Me.lblBuilkID.TabIndex = 206
      Me.lblBuilkID.Text = "Builk ID:"
      Me.lblBuilkID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.Label1.Location = New System.Drawing.Point(19, 353)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(145, 18)
      Me.Label1.TabIndex = 208
      Me.Label1.Text = "Builk PaymentTrack ID:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ConfigurationView
      '
      Me.Controls.Add(Me.txtBuilkPaymentTrackID)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtBuilkID)
      Me.Controls.Add(Me.lblBuilkID)
      Me.Controls.Add(Me.lblPicSize)
      Me.Controls.Add(Me.btnLoadImage)
      Me.Controls.Add(Me.btnClearImage)
      Me.Controls.Add(Me.picLogo)
      Me.Controls.Add(Me.grbTax)
      Me.Controls.Add(Me.lblFax)
      Me.Controls.Add(Me.cmbInvMethod)
      Me.Controls.Add(Me.txtPhone)
      Me.Controls.Add(Me.cmbCostMethod)
      Me.Controls.Add(Me.txtAddress)
      Me.Controls.Add(Me.txtFax)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.txtBillingAddress)
      Me.Controls.Add(Me.txtAltName)
      Me.Controls.Add(Me.txtOwner)
      Me.Controls.Add(Me.lblAltName)
      Me.Controls.Add(Me.lblPhone)
      Me.Controls.Add(Me.lblAddress)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.lblBillingAddress)
      Me.Controls.Add(Me.lblInvMethod)
      Me.Controls.Add(Me.lblostMethod)
      Me.Controls.Add(Me.lblOwner)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "ConfigurationView"
      Me.Size = New System.Drawing.Size(672, 391)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbTax.ResumeLayout(False)
      Me.grbTax.PerformLayout()
      CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region "Members"
        Private m_isInitialized As Boolean
    Public ConfigFilters(14) As Filter
        Private Dirty As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Me.SetLabelText()
            Initialize()
            EventWiring()
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
        Public Sub CheckFormEnable()
        End Sub
        Public Sub ClearDetail()
        End Sub
        Public Sub SetLabelText()
      Me.lblTaxType.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblTaxType}")
      Me.lblPhone.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblPhone}")
      Me.lblFax.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblFax}")
      Me.lblAddress.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblAddress}")
      Me.lblName.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblName}")
      Me.lblTaxID.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblTaxID}")
      Me.Label8.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Global.PercentText}")
      Me.lblBillingAddress.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblBillingAddress}")
      Me.lblInvMethod.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblInvMethod}")
      Me.lblostMethod.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblostMethod}")
      Me.lblAltName.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblAltName}")
      Me.lblOwner.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblOwner}")
      Me.lblTaxRate.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.lblTaxRate}")
      Me.grbTax.Text = XmlForms.BasePojjamanUserControl.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ConfigurationView.grbTax}")
        End Sub
        Protected Sub EventWiring()
            AddHandler txtName.TextChanged, AddressOf ChangeProperty
            AddHandler txtAltName.TextChanged, AddressOf ChangeProperty
            AddHandler txtAddress.TextChanged, AddressOf ChangeProperty
            AddHandler txtBillingAddress.TextChanged, AddressOf ChangeProperty
            AddHandler txtPhone.TextChanged, AddressOf ChangeProperty
            AddHandler txtFax.TextChanged, AddressOf ChangeProperty
            AddHandler txtOwner.TextChanged, AddressOf ChangeProperty
            AddHandler txtTaxID.TextChanged, AddressOf ChangeProperty

            AddHandler txtTaxRate.TextChanged, AddressOf ChangeProperty

            AddHandler txtTaxRate.Validated, AddressOf TextHandler

      AddHandler txtBuilkID.TextChanged, AddressOf ChangeProperty
      AddHandler txtBuilkPaymentTrackID.TextChanged, AddressOf ChangeProperty

            AddHandler cmbCostMethod.SelectedIndexChanged, AddressOf ChangeProperty
            AddHandler cmbInvMethod.SelectedIndexChanged, AddressOf ChangeProperty
            AddHandler cmbTaxType.SelectedIndexChanged, AddressOf ChangeProperty
        End Sub

        Public Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txttaxrate"
                    Dim txt As String = Me.txtTaxRate.Text
                    Dim val As Decimal
                    If txt.Length > 0 AndAlso IsNumeric(txt) Then
                        val = CDec(txt)
                    Else
                        val = 0
                    End If
                    Me.SetFilterValue("CompanyTaxRate", val)
                    txtTaxRate.Text = Configuration.FormatToString(val, 2)
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtname"
                    Me.SetFilterValue("CompanyName", txtName.Text)
                    dirtyFlag = True
                Case "txtaltname"
                    Me.SetFilterValue("CompanyAltName", txtAltName.Text)
                    dirtyFlag = True
                Case "txtaddress"
                    Me.SetFilterValue("CompanyAddress", txtAddress.Text)
                    dirtyFlag = True
                Case "txtbillingaddress"
                    Me.SetFilterValue("CompanyBillingAddress", txtBillingAddress.Text)
                    dirtyFlag = True
                Case "txtphone"
                    Me.SetFilterValue("CompanyPhone", txtPhone.Text)
                    dirtyFlag = True
                Case "txtfax"
                    Me.SetFilterValue("CompanyFax", txtFax.Text)
                    dirtyFlag = True
                Case "txtowner"
                    Me.SetFilterValue("CompanyOwner", txtOwner.Text)
                    dirtyFlag = True
                Case "txttaxid"
                    Me.SetFilterValue("CompanyTaxId", txtTaxID.Text)
                    dirtyFlag = True
                Case "txttaxrate"
                    dirtyFlag = True
                Case "cmbcostmethod"
                    Dim item As IdValuePair = CType(Me.cmbCostMethod.SelectedItem, IdValuePair)
                    If Not item Is Nothing Then
                        Me.SetFilterValue("CompanyCostMethod", item.Id)
                    End If
                    dirtyFlag = True
                Case "cmbinvmethod"
                    Dim item As IdValuePair = CType(Me.cmbInvMethod.SelectedItem, IdValuePair)
                    If Not item Is Nothing Then
                        Me.SetFilterValue("CompanyInventoryMethod", item.Id)
                    End If
                    dirtyFlag = True
                Case "cmbtaxtype"
                    Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
                    If Not item Is Nothing Then
                        Me.SetFilterValue("CompanyTaxType", item.Id)
                    End If
          dirtyFlag = True
        Case "txtbuilkid"
          Me.SetFilterValue("BuilkID", txtBuilkID.Text)
          dirtyFlag = True
        Case "txtbuilkpaymenttrackid"
          Me.SetFilterValue("BuilkPaymentTrackID", txtBuilkPaymentTrackID.Text)
          dirtyFlag = True
      End Select
            Dirty = Dirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Sub Initialize()
            ConfigFilters(0) = New Filter("CompanyName", Configuration.GetConfig("CompanyName"))
            ConfigFilters(1) = New Filter("CompanyAddress", Configuration.GetConfig("CompanyAddress"))
            ConfigFilters(2) = New Filter("CompanyBillingAddress", Configuration.GetConfig("CompanyBillingAddress"))
            ConfigFilters(3) = New Filter("CompanyPhone", Configuration.GetConfig("CompanyPhone"))
            ConfigFilters(4) = New Filter("CompanyFax", Configuration.GetConfig("CompanyFax"))
            ConfigFilters(5) = New Filter("CompanyTaxId", Configuration.GetConfig("CompanyTaxId"))
            ConfigFilters(6) = New Filter("CompanyInventoryMethod", Configuration.GetConfig("CompanyInventoryMethod"))
            ConfigFilters(7) = New Filter("CompanyTaxRate", Configuration.GetConfig("CompanyTaxRate"))
            ConfigFilters(8) = New Filter("CompanyTaxType", Configuration.GetConfig("CompanyTaxType"))
            ConfigFilters(9) = New Filter("CompanyOwner", Configuration.GetConfig("CompanyOwner"))
            ConfigFilters(10) = New Filter("CompanyAltName", Configuration.GetConfig("CompanyAltName"))
            ConfigFilters(11) = New Filter("CompanyCostMethod", Configuration.GetConfig("CompanyCostMethod"))
            ' Hack : Logo
      ConfigFilters(12) = New Filter("Logo", Configuration.GetConfig("Logo"))
      ConfigFilters(13) = New Filter("BuilkID", Configuration.GetConfig("BuilkID"))
      ConfigFilters(14) = New Filter("BuilkPaymentTrackID", Configuration.GetConfig("BuilkPaymentTrackID"))
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbInvMethod, "config_invmethod")
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbCostMethod, "config_costmethod")
        End Sub
        Private Sub SetFilterValue(ByVal name As String, ByVal value As Object)
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    filter.Value = value
                    Exit For
                End If
            Next
        End Sub
        Private Function GetFilterValue(ByVal name As String) As Object
            For Each filter As filter In ConfigFilters
                If filter.Name.ToLower = name.ToLower Then
                    Return filter.Value
                End If
            Next
        End Function
#End Region

#Region "Methods"
#End Region

#Region "Event Handers"
        Private Sub ibtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
#End Region

#Region "Overrides"
        Public Overloads Overrides Sub LoadPanelContents()
            m_isInitialized = False
            ClearDetail()
            Me.txtName.Text = GetFilterValue("CompanyName").ToString
            Me.txtAltName.Text = GetFilterValue("CompanyAltName").ToString
            Me.txtAddress.Text = GetFilterValue("CompanyAddress").ToString
            Me.txtBillingAddress.Text = GetFilterValue("CompanyBillingAddress").ToString
            Me.txtPhone.Text = GetFilterValue("CompanyPhone").ToString
            Me.txtFax.Text = GetFilterValue("CompanyFax").ToString
            Me.txtOwner.Text = GetFilterValue("CompanyOwner").ToString
            Me.txtTaxID.Text = GetFilterValue("CompanyTaxId").ToString

            Me.txtTaxRate.Text = Configuration.FormatToString(CDec(GetFilterValue("CompanyTaxRate")), 2)

      Me.txtBuilkID.Text = GetFilterValue("BuilkID").ToString
      Me.txtBuilkPaymentTrackID.Text = GetFilterValue("BuilkPaymentTrackID").ToString

            Dim tmpCostMethod As New CodeDescription(CInt(GetFilterValue("CompanyCostMethod")))
            CodeDescription.ComboSelect(Me.cmbCostMethod, tmpCostMethod)

            Dim tmpInvMethod As New CodeDescription(CInt(GetFilterValue("CompanyInventoryMethod")))
            CodeDescription.ComboSelect(Me.cmbInvMethod, tmpInvMethod)

            Dim tmpTaxType As New CodeDescription(CInt(GetFilterValue("CompanyTaxType")))
            CodeDescription.ComboSelect(Me.cmbTaxType, tmpTaxType)

            Me.picLogo.Image = Configuration.LoadImage()
            CheckLabelImgSize()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Public Overloads Overrides Function StorePanelContents() As Boolean
            If Not m_isInitialized Then
                Return True
            End If
            If Not Dirty Then
                Return True
            End If
            Configuration.Save(Me.ConfigFilters)
            WorkbenchSingleton.Workbench.RedrawAllComponents()
            Return True
        End Function
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

        Private Sub btnLoadLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim dlg As New OpenFileDialog
            dlg.Filter = "Jpeg files (*.jpg)|*.jpg|Bitmap files (*.bmp)|*.bmp|Gif file (*.gif)|*.gif"
            With dlg
                .CheckFileExists = True
                .Filter = "Bitmap Files |*;*.GIF;*.JPG;*.BMP"
            End With
            If dlg.ShowDialog = DialogResult.OK Then
                Dim img As Image = Image.FromFile(dlg.FileName)
                Me.picLogo.Image = img
                Me.SetFilterValue("logo", img)
                'Hack
                Dirty = True
            End If
        End Sub
#Region "Image button"
        Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
            Dim dlg As New OpenFileDialog
            dlg.AddExtension = True
            Dim fileFilters As String() = CType(AddInTreeSingleton.AddInTree.GetTreeNode("/Pojjaman/Workbench/Image/FileFilter").BuildChildItems(Me).ToArray(GetType(String)), String())
            dlg.Filter = String.Join("|", fileFilters)
            If dlg.ShowDialog = DialogResult.OK Then
                Dim img As Image = Image.FromFile(dlg.FileName)
                If img.Size.Height > Me.picLogo.Height OrElse img.Size.Width >= Me.picLogo.Width Then
                    Dim percent As Decimal = 100 * (Math.Min(Me.picLogo.Height / img.Size.Height, Me.picLogo.Width / img.Size.Width))
                    img = ImageHelper.Resize(img, percent)
                End If
                Me.picLogo.Image = img
                Me.SetFilterValue("logo", img)
                'Hack
                Dirty = True
                CheckLabelImgSize()
            End If
        End Sub
        Private Sub btnClearImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearImage.Click
            Me.picLogo.Image = Nothing
            Me.SetFilterValue("logo", Nothing)
            Dirty = True
            CheckLabelImgSize()
        End Sub
        Private Sub CheckLabelImgSize()
            Me.lblPicSize.Text = "160 X 192 pixel"
            If Me.picLogo.Image Is Nothing Then
                Me.lblPicSize.Visible = True
            Else
                Me.lblPicSize.Visible = False
            End If
        End Sub
#End Region

    Private Sub lblostMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblostMethod.Click

    End Sub
  End Class
End Namespace