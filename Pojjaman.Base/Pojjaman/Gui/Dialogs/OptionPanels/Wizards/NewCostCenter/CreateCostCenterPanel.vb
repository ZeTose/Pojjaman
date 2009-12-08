Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard
    Public Class CreateCostCenterPanel
        Inherits WizardPanel

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
        Friend WithEvents txtMessage As System.Windows.Forms.TextBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtWipAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblStoreAcct As System.Windows.Forms.Label
        Friend WithEvents txtStoreAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblWipAcct As System.Windows.Forms.Label
        Friend WithEvents ibtnShowStoreAcctDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowWipAcctDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtWipAcctName As System.Windows.Forms.TextBox
        Friend WithEvents txtStoreAcctName As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowExpenseAcctDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtExpenseAcctName As System.Windows.Forms.TextBox
        Friend WithEvents lblExpenseAcct As System.Windows.Forms.Label
        Friend WithEvents txtExpenseAcctCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CreateCostCenterPanel))
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtWipAcctCode = New System.Windows.Forms.TextBox
            Me.lblStoreAcct = New System.Windows.Forms.Label
            Me.txtStoreAcctCode = New System.Windows.Forms.TextBox
            Me.lblWipAcct = New System.Windows.Forms.Label
            Me.ibtnShowStoreAcctDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnShowWipAcctDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtWipAcctName = New System.Windows.Forms.TextBox
            Me.txtStoreAcctName = New System.Windows.Forms.TextBox
            Me.ibtnShowExpenseAcctDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtExpenseAcctName = New System.Windows.Forms.TextBox
            Me.lblExpenseAcct = New System.Windows.Forms.Label
            Me.txtExpenseAcctCode = New System.Windows.Forms.TextBox
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.SuspendLayout()
            '
            'txtMessage
            '
            Me.Validator.SetDataType(Me.txtMessage, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtMessage, "")
            Me.Validator.SetGotFocusBackColor(Me.txtMessage, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtMessage, System.Drawing.Color.Empty)
            Me.txtMessage.Location = New System.Drawing.Point(8, 8)
            Me.Validator.SetMaxValue(Me.txtMessage, "")
            Me.Validator.SetMinValue(Me.txtMessage, "")
            Me.txtMessage.Multiline = True
            Me.txtMessage.Name = "txtMessage"
            Me.txtMessage.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtMessage, "")
            Me.Validator.SetRequired(Me.txtMessage, False)
            Me.txtMessage.Size = New System.Drawing.Size(392, 80)
            Me.txtMessage.TabIndex = 0
            Me.txtMessage.Text = ""
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(344, 128)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 17
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, Nothing)
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(96, 149)
            Me.txtName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, True)
            Me.txtName.Size = New System.Drawing.Size(268, 21)
            Me.txtName.TabIndex = 2
            Me.txtName.Text = ""
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.Location = New System.Drawing.Point(-16, 149)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(112, 20)
            Me.lblName.TabIndex = 8
            Me.lblName.Text = "ชื่อ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, Nothing)
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(96, 128)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(248, 21)
            Me.txtCode.TabIndex = 1
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(-16, 128)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 20)
            Me.lblCode.TabIndex = 7
            Me.lblCode.Text = "รหัส:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtWipAcctCode
            '
            Me.Validator.SetDataType(Me.txtWipAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWipAcctCode, Nothing)
            Me.txtWipAcctCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtWipAcctCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtWipAcctCode, System.Drawing.Color.Empty)
            Me.txtWipAcctCode.Location = New System.Drawing.Point(96, 235)
            Me.Validator.SetMaxValue(Me.txtWipAcctCode, "")
            Me.Validator.SetMinValue(Me.txtWipAcctCode, "")
            Me.txtWipAcctCode.Name = "txtWipAcctCode"
            Me.Validator.SetRegularExpression(Me.txtWipAcctCode, "")
            Me.Validator.SetRequired(Me.txtWipAcctCode, True)
            Me.txtWipAcctCode.Size = New System.Drawing.Size(88, 22)
            Me.txtWipAcctCode.TabIndex = 6
            Me.txtWipAcctCode.Text = ""
            '
            'lblStoreAcct
            '
            Me.lblStoreAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStoreAcct.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblStoreAcct.Location = New System.Drawing.Point(-16, 215)
            Me.lblStoreAcct.Name = "lblStoreAcct"
            Me.lblStoreAcct.Size = New System.Drawing.Size(112, 18)
            Me.lblStoreAcct.TabIndex = 11
            Me.lblStoreAcct.Text = "ผังบัญชี Store:"
            Me.lblStoreAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtStoreAcctCode
            '
            Me.Validator.SetDataType(Me.txtStoreAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStoreAcctCode, Nothing)
            Me.txtStoreAcctCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtStoreAcctCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtStoreAcctCode, System.Drawing.Color.Empty)
            Me.txtStoreAcctCode.Location = New System.Drawing.Point(96, 213)
            Me.Validator.SetMaxValue(Me.txtStoreAcctCode, "")
            Me.Validator.SetMinValue(Me.txtStoreAcctCode, "")
            Me.txtStoreAcctCode.Name = "txtStoreAcctCode"
            Me.Validator.SetRegularExpression(Me.txtStoreAcctCode, "")
            Me.Validator.SetRequired(Me.txtStoreAcctCode, True)
            Me.txtStoreAcctCode.Size = New System.Drawing.Size(88, 22)
            Me.txtStoreAcctCode.TabIndex = 5
            Me.txtStoreAcctCode.Text = ""
            '
            'lblWipAcct
            '
            Me.lblWipAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWipAcct.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblWipAcct.Location = New System.Drawing.Point(-16, 237)
            Me.lblWipAcct.Name = "lblWipAcct"
            Me.lblWipAcct.Size = New System.Drawing.Size(112, 18)
            Me.lblWipAcct.TabIndex = 12
            Me.lblWipAcct.Text = "ผังบัญชี WIP:"
            Me.lblWipAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowStoreAcctDialog
            '
            Me.ibtnShowStoreAcctDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowStoreAcctDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowStoreAcctDialog.Image = CType(resources.GetObject("ibtnShowStoreAcctDialog.Image"), System.Drawing.Image)
            Me.ibtnShowStoreAcctDialog.Location = New System.Drawing.Point(341, 213)
            Me.ibtnShowStoreAcctDialog.Name = "ibtnShowStoreAcctDialog"
            Me.ibtnShowStoreAcctDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowStoreAcctDialog.TabIndex = 20
            Me.ibtnShowStoreAcctDialog.TabStop = False
            Me.ibtnShowStoreAcctDialog.ThemedImage = CType(resources.GetObject("ibtnShowStoreAcctDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowWipAcctDialog
            '
            Me.ibtnShowWipAcctDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowWipAcctDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowWipAcctDialog.Image = CType(resources.GetObject("ibtnShowWipAcctDialog.Image"), System.Drawing.Image)
            Me.ibtnShowWipAcctDialog.Location = New System.Drawing.Point(341, 235)
            Me.ibtnShowWipAcctDialog.Name = "ibtnShowWipAcctDialog"
            Me.ibtnShowWipAcctDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowWipAcctDialog.TabIndex = 21
            Me.ibtnShowWipAcctDialog.TabStop = False
            Me.ibtnShowWipAcctDialog.ThemedImage = CType(resources.GetObject("ibtnShowWipAcctDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtWipAcctName
            '
            Me.Validator.SetDataType(Me.txtWipAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtWipAcctName, "")
            Me.txtWipAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtWipAcctName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtWipAcctName, System.Drawing.Color.Empty)
            Me.txtWipAcctName.Location = New System.Drawing.Point(184, 235)
            Me.Validator.SetMaxValue(Me.txtWipAcctName, "")
            Me.Validator.SetMinValue(Me.txtWipAcctName, "")
            Me.txtWipAcctName.Name = "txtWipAcctName"
            Me.txtWipAcctName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtWipAcctName, "")
            Me.Validator.SetRequired(Me.txtWipAcctName, False)
            Me.txtWipAcctName.Size = New System.Drawing.Size(160, 22)
            Me.txtWipAcctName.TabIndex = 16
            Me.txtWipAcctName.TabStop = False
            Me.txtWipAcctName.Text = ""
            '
            'txtStoreAcctName
            '
            Me.Validator.SetDataType(Me.txtStoreAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtStoreAcctName, "")
            Me.txtStoreAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtStoreAcctName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtStoreAcctName, System.Drawing.Color.Empty)
            Me.txtStoreAcctName.Location = New System.Drawing.Point(184, 213)
            Me.Validator.SetMaxValue(Me.txtStoreAcctName, "")
            Me.Validator.SetMinValue(Me.txtStoreAcctName, "")
            Me.txtStoreAcctName.Name = "txtStoreAcctName"
            Me.txtStoreAcctName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtStoreAcctName, "")
            Me.Validator.SetRequired(Me.txtStoreAcctName, False)
            Me.txtStoreAcctName.Size = New System.Drawing.Size(160, 22)
            Me.txtStoreAcctName.TabIndex = 15
            Me.txtStoreAcctName.TabStop = False
            Me.txtStoreAcctName.Text = ""
            '
            'ibtnShowExpenseAcctDialog
            '
            Me.ibtnShowExpenseAcctDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowExpenseAcctDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowExpenseAcctDialog.Image = CType(resources.GetObject("ibtnShowExpenseAcctDialog.Image"), System.Drawing.Image)
            Me.ibtnShowExpenseAcctDialog.Location = New System.Drawing.Point(341, 191)
            Me.ibtnShowExpenseAcctDialog.Name = "ibtnShowExpenseAcctDialog"
            Me.ibtnShowExpenseAcctDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowExpenseAcctDialog.TabIndex = 19
            Me.ibtnShowExpenseAcctDialog.TabStop = False
            Me.ibtnShowExpenseAcctDialog.ThemedImage = CType(resources.GetObject("ibtnShowExpenseAcctDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtExpenseAcctName
            '
            Me.Validator.SetDataType(Me.txtExpenseAcctName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtExpenseAcctName, "")
            Me.txtExpenseAcctName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtExpenseAcctName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtExpenseAcctName, System.Drawing.Color.Empty)
            Me.txtExpenseAcctName.Location = New System.Drawing.Point(184, 191)
            Me.Validator.SetMaxValue(Me.txtExpenseAcctName, "")
            Me.Validator.SetMinValue(Me.txtExpenseAcctName, "")
            Me.txtExpenseAcctName.Name = "txtExpenseAcctName"
            Me.txtExpenseAcctName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtExpenseAcctName, "")
            Me.Validator.SetRequired(Me.txtExpenseAcctName, False)
            Me.txtExpenseAcctName.Size = New System.Drawing.Size(160, 22)
            Me.txtExpenseAcctName.TabIndex = 14
            Me.txtExpenseAcctName.TabStop = False
            Me.txtExpenseAcctName.Text = ""
            '
            'lblExpenseAcct
            '
            Me.lblExpenseAcct.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblExpenseAcct.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblExpenseAcct.Location = New System.Drawing.Point(-16, 193)
            Me.lblExpenseAcct.Name = "lblExpenseAcct"
            Me.lblExpenseAcct.Size = New System.Drawing.Size(112, 18)
            Me.lblExpenseAcct.TabIndex = 10
            Me.lblExpenseAcct.Text = "ผังบัญชีค่าใช้จ่าย:"
            Me.lblExpenseAcct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtExpenseAcctCode
            '
            Me.Validator.SetDataType(Me.txtExpenseAcctCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtExpenseAcctCode, Nothing)
            Me.txtExpenseAcctCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtExpenseAcctCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtExpenseAcctCode, System.Drawing.Color.Empty)
            Me.txtExpenseAcctCode.Location = New System.Drawing.Point(96, 191)
            Me.Validator.SetMaxValue(Me.txtExpenseAcctCode, "")
            Me.Validator.SetMinValue(Me.txtExpenseAcctCode, "")
            Me.txtExpenseAcctCode.Name = "txtExpenseAcctCode"
            Me.Validator.SetRegularExpression(Me.txtExpenseAcctCode, "")
            Me.Validator.SetRequired(Me.txtExpenseAcctCode, True)
            Me.txtExpenseAcctCode.Size = New System.Drawing.Size(88, 22)
            Me.txtExpenseAcctCode.TabIndex = 4
            Me.txtExpenseAcctCode.Text = ""
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(-16, 170)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(112, 20)
            Me.lblCustomer.TabIndex = 9
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomerCode
            '
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, Nothing)
            Me.txtCustomerCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(96, 170)
            Me.txtCustomerCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, True)
            Me.txtCustomerCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCustomerCode.TabIndex = 3
            Me.txtCustomerCode.Text = ""
            '
            'ibtnShowCustomerDialog
            '
            Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowCustomerDialog.Image = CType(resources.GetObject("ibtnShowCustomerDialog.Image"), System.Drawing.Image)
            Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(341, 169)
            Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
            Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowCustomerDialog.TabIndex = 18
            Me.ibtnShowCustomerDialog.TabStop = False
            Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerName
            '
            Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerName, "")
            Me.txtCustomerName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.txtCustomerName.Location = New System.Drawing.Point(184, 170)
            Me.txtCustomerName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(160, 21)
            Me.txtCustomerName.TabIndex = 13
            Me.txtCustomerName.TabStop = False
            Me.txtCustomerName.Text = ""
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'CreateCostCenterPanel
            '
            Me.Controls.Add(Me.txtCustomerCode)
            Me.Controls.Add(Me.ibtnShowCustomerDialog)
            Me.Controls.Add(Me.txtCustomerName)
            Me.Controls.Add(Me.txtWipAcctCode)
            Me.Controls.Add(Me.txtStoreAcctCode)
            Me.Controls.Add(Me.ibtnShowStoreAcctDialog)
            Me.Controls.Add(Me.ibtnShowWipAcctDialog)
            Me.Controls.Add(Me.txtWipAcctName)
            Me.Controls.Add(Me.txtStoreAcctName)
            Me.Controls.Add(Me.ibtnShowExpenseAcctDialog)
            Me.Controls.Add(Me.txtExpenseAcctName)
            Me.Controls.Add(Me.txtExpenseAcctCode)
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtMessage)
            Me.Controls.Add(Me.lblCustomer)
            Me.Controls.Add(Me.lblStoreAcct)
            Me.Controls.Add(Me.lblWipAcct)
            Me.Controls.Add(Me.lblExpenseAcct)
            Me.Name = "CreateCostCenterPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Wire()
            Me.EnableFinish = False
            SetLabelText()
        End Sub
#End Region

#Region "Event Wiring"
        Private Sub Wire()
            AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCustomerCode.TextChanged, AddressOf Me.TextChangeHandler

            AddHandler txtExpenseAcctCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtExpenseAcctCode.TextChanged, AddressOf Me.TextChangeHandler

            AddHandler txtWipAcctCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtWipAcctCode.TextChanged, AddressOf Me.TextChangeHandler

            AddHandler txtStoreAcctCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtStoreAcctCode.TextChanged, AddressOf Me.TextChangeHandler
        End Sub
        Private codeTextChanged As Boolean = False
        Private expenseAcctCodeTextChanged As Boolean = False
        Private wipAcctCodeTextChanged As Boolean = False
        Private storeAcctCodeTextChanged As Boolean = False
        Private Sub TextChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
            If m_updating OrElse Me.CostCenter Is Nothing Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustomercode"
                    codeTextChanged = True
                Case "txtexpenseacctcode"
                    expenseAcctCodeTextChanged = True
                Case "txtwipacctcode"
                    wipAcctCodeTextChanged = True
                Case "txtstoreacctcode"
                    storeAcctCodeTextChanged = True
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If m_updating OrElse Me.CostCenter Is Nothing Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustomercode"
                    If codeTextChanged Then
                        Customer.GetCustomer(txtCustomerCode, txtCustomerName, CostCenter.Customer)
                        codeTextChanged = False
                    End If
                Case "txtexpenseacctcode"
                    If expenseAcctCodeTextChanged Then
                        Account.GetAccount(txtExpenseAcctCode, txtExpenseAcctName, CostCenter.ExpenseAccount)
                        expenseAcctCodeTextChanged = False
                    End If
                Case "txtwipacctcode"
                    If wipAcctCodeTextChanged Then
                        Account.GetAccount(txtWipAcctCode, txtWipAcctName, CostCenter.WipAccount)
                        wipAcctCodeTextChanged = False
                    End If
                Case "txtstoreacctcode"
                    If storeAcctCodeTextChanged Then
                        Account.GetAccount(txtStoreAcctCode, txtStoreAcctName, CostCenter.StoreAccount)
                        storeAcctCodeTextChanged = False
                    End If
            End Select
        End Sub
#End Region

#Region "Methods"
        Public Sub SetLabelText()
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreateCostCenterPanel.lblName}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreateCostCenterPanel.lblCode}")
            Me.lblStoreAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreateCostCenterPanel.lblStoreAcct}")
            Me.lblWipAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreateCostCenterPanel.lblWipAcct}")
            Me.lblExpenseAcct.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreateCostCenterPanel.lblExpenseAcct}")
            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreateCostCenterPanel.lblCustomer}")

            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewCostCenterWizard.CreateCostCenterPanel.DescriptionText}").Split(New Char() {ChrW(10)})
        End Sub
        Private m_updating As Boolean = False
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Select Case message
                Case DialogMessage.Activated
                    If Not Me.CostCenter Is Nothing Then
                        If Me.CostCenter.Name = "" And Me.CostCenter.Project.Originated Then
                            Me.CostCenter.Name = Me.CostCenter.Project.Name
                        End If
                        If Not Me.CostCenter.StoreAccount.Originated Then
                            Me.CostCenter.StoreAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.MatInStore).Account
                        End If
                        If Not Me.CostCenter.WipAccount.Originated Then
                            Me.CostCenter.WipAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.Wip).Account
                        End If
                        If Not Me.CostCenter.ExpenseAccount.Originated Then
                            Me.CostCenter.ExpenseAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.OtherExpense).Account
                        End If
                        If Not Me.CostCenter.Customer.Originated And Me.CostCenter.Project.Originated Then
                            Me.CostCenter.Customer = Me.CostCenter.Project.Customer
                        End If
                        If Me.CostCenter.Project.Originated Then
                            Me.CostCenter.Address = Me.CostCenter.Project.Address
                        End If
                        m_updating = True

                        Me.txtCode.Text = Me.CostCenter.Code
                        Me.txtName.Text = Me.CostCenter.Name

                        chkAutorun.Checked = CostCenter.AutoGen
                        UpdateAutogenStatus()

                        Me.txtCustomerCode.Text = Me.CostCenter.Customer.Code
                        Me.txtCustomerName.Text = Me.CostCenter.Customer.Name

                        Me.txtExpenseAcctCode.Text = Me.CostCenter.ExpenseAccount.Code
                        Me.txtExpenseAcctName.Text = Me.CostCenter.ExpenseAccount.Name

                        Me.txtStoreAcctCode.Text = Me.CostCenter.StoreAccount.Code
                        Me.txtStoreAcctName.Text = Me.CostCenter.StoreAccount.Name

                        Me.txtWipAcctCode.Text = Me.CostCenter.WipAccount.Code
                        Me.txtWipAcctName.Text = Me.CostCenter.WipAccount.Name

                        m_updating = False
                    End If
                    Me.EnableFinish = False
                Case DialogMessage.Next
                    If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
                        msgServ.ShowMessage(Validator.ValidationSummary)
                        Return False
                    End If
                    If Not Me.CostCenter Is Nothing Then
                        Me.CostCenter.Code = Me.txtCode.Text
                        Me.CostCenter.Name = Me.txtName.Text
                    End If
                    Me.EnableFinish = True
            End Select
            Return True
        End Function
#End Region

#Region "Event handlers"
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                Me.Validator.SetRequired(Me.txtCode, False)
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.txtCode.ReadOnly = True
                m_oldCode = Me.CostCenter.Code
                Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.CostCenter.EntityId)
                'Hack: set Code เป็น "" เอง
                Me.CostCenter.Code = ""
                Me.CostCenter.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtCode, True)
                Me.txtCode.Text = m_oldCode
                Me.txtCode.ReadOnly = False
                Me.CostCenter.AutoGen = False
            End If
        End Sub
#End Region

#Region "Dialog"
        Private Sub ibtnShowExpenseAcctDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowExpenseAcctDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim dummy As New Account
            dummy.Type = New AccountType(5)
            entities.Add(dummy)
            myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetExpenseAcct, Nothing, entities)
        End Sub
        Private Sub ibtnShowStoreAcctDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowStoreAcctDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim dummy As New Account
            dummy.Type = New AccountType(1)
            entities.Add(dummy)
            myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetStoreAcct, Nothing, entities)
        End Sub
        Private Sub ibtnShowWipAcctDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowWipAcctDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim entities As New ArrayList
            Dim dummy As New Account
            dummy.Type = New AccountType(1)
            entities.Add(dummy)
            myEntityPanelService.OpenTreeDialog(dummy, AddressOf SetWipAcct, Nothing, entities)
        End Sub
        Private Sub SetStoreAcct(ByVal e As ISimpleEntity)
            Me.txtStoreAcctCode.Text = e.Code
            Account.GetAccount(txtStoreAcctCode, txtStoreAcctName, Me.CostCenter.StoreAccount)
        End Sub
        Private Sub SetWipAcct(ByVal e As ISimpleEntity)
            Me.txtWipAcctCode.Text = e.Code
            Account.GetAccount(txtWipAcctCode, txtWipAcctName, Me.CostCenter.WipAccount)
        End Sub
        Private Sub SetExpenseAcct(ByVal e As ISimpleEntity)
            Me.txtExpenseAcctCode.Text = e.Code
            Account.GetAccount(txtExpenseAcctCode, txtExpenseAcctName, Me.CostCenter.ExpenseAccount)
        End Sub
        Private Sub ibtnShowCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            If CostCenter Is Nothing Then
                Return
            End If
            Me.txtCustomerCode.Text = e.Code
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, CostCenter.Customer)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property CostCenter() As CostCenter
            Get
                If TypeOf Me.CustomizationObject Is CostCenter Then
                    Return CType(Me.CustomizationObject, CostCenter)
                End If
            End Get
        End Property
#End Region

    End Class
End Namespace

