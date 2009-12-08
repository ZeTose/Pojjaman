Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard
    Public Class ChooseCustomerPanel
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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
        Friend WithEvents lblProjectName As System.Windows.Forms.Label
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents lblProjectCode As System.Windows.Forms.Label
        Friend WithEvents lblJobNumber As System.Windows.Forms.Label
        Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChooseCustomerPanel))
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.lblCustomer = New System.Windows.Forms.Label
            Me.txtCustomerCode = New System.Windows.Forms.TextBox
            Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCustomerName = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtProjectName = New System.Windows.Forms.TextBox
            Me.txtProjectCode = New System.Windows.Forms.TextBox
            Me.txtJobNumber = New System.Windows.Forms.TextBox
            Me.lblProjectName = New System.Windows.Forms.Label
            Me.lblProjectCode = New System.Windows.Forms.Label
            Me.lblJobNumber = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
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
            Me.txtMessage.TabStop = False
            Me.txtMessage.Text = ""
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(16, 136)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(64, 20)
            Me.lblCustomer.TabIndex = 5
            Me.lblCustomer.Text = "ลูกค้า:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomerCode
            '
            Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(80, 136)
            Me.txtCustomerCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, True)
            Me.txtCustomerCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCustomerCode.TabIndex = 1
            Me.txtCustomerCode.Text = ""
            '
            'ibtnShowCustomerDialog
            '
            Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowCustomerDialog.Image = CType(resources.GetObject("ibtnShowCustomerDialog.Image"), System.Drawing.Image)
            Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(352, 135)
            Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
            Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowCustomerDialog.TabIndex = 7
            Me.ibtnShowCustomerDialog.TabStop = False
            Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerName
            '
            Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerName, "")
            Me.txtCustomerName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.txtCustomerName.Location = New System.Drawing.Point(168, 136)
            Me.txtCustomerName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(184, 21)
            Me.txtCustomerName.TabIndex = 6
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
            'txtProjectName
            '
            Me.txtProjectName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectName, "")
            Me.txtProjectName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.txtProjectName.Location = New System.Drawing.Point(104, 216)
            Me.txtProjectName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtProjectName, "")
            Me.Validator.SetMinValue(Me.txtProjectName, "")
            Me.txtProjectName.Name = "txtProjectName"
            Me.Validator.SetRegularExpression(Me.txtProjectName, "")
            Me.Validator.SetRequired(Me.txtProjectName, True)
            Me.txtProjectName.Size = New System.Drawing.Size(268, 21)
            Me.txtProjectName.TabIndex = 3
            Me.txtProjectName.Text = ""
            '
            'txtProjectCode
            '
            Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCode, "")
            Me.txtProjectCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtProjectCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.txtProjectCode.Location = New System.Drawing.Point(104, 192)
            Me.txtProjectCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtProjectCode, "")
            Me.Validator.SetMinValue(Me.txtProjectCode, "")
            Me.txtProjectCode.Name = "txtProjectCode"
            Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
            Me.Validator.SetRequired(Me.txtProjectCode, True)
            Me.txtProjectCode.Size = New System.Drawing.Size(248, 21)
            Me.txtProjectCode.TabIndex = 2
            Me.txtProjectCode.Text = ""
            '
            'txtJobNumber
            '
            Me.txtJobNumber.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtJobNumber, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtJobNumber, "")
            Me.txtJobNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtJobNumber, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtJobNumber, System.Drawing.Color.Empty)
            Me.txtJobNumber.Location = New System.Drawing.Point(104, 240)
            Me.txtJobNumber.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtJobNumber, "")
            Me.Validator.SetMinValue(Me.txtJobNumber, "")
            Me.txtJobNumber.Name = "txtJobNumber"
            Me.Validator.SetRegularExpression(Me.txtJobNumber, "")
            Me.Validator.SetRequired(Me.txtJobNumber, True)
            Me.txtJobNumber.Size = New System.Drawing.Size(268, 21)
            Me.txtJobNumber.TabIndex = 4
            Me.txtJobNumber.Text = ""
            '
            'lblProjectName
            '
            Me.lblProjectName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProjectName.Location = New System.Drawing.Point(0, 216)
            Me.lblProjectName.Name = "lblProjectName"
            Me.lblProjectName.Size = New System.Drawing.Size(104, 20)
            Me.lblProjectName.TabIndex = 9
            Me.lblProjectName.Text = "ชื่อโครงการประมูล:"
            Me.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProjectCode
            '
            Me.lblProjectCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProjectCode.Location = New System.Drawing.Point(0, 192)
            Me.lblProjectCode.Name = "lblProjectCode"
            Me.lblProjectCode.Size = New System.Drawing.Size(104, 20)
            Me.lblProjectCode.TabIndex = 8
            Me.lblProjectCode.Text = "รหัสโครงการประมูล:"
            Me.lblProjectCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblJobNumber
            '
            Me.lblJobNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblJobNumber.Location = New System.Drawing.Point(0, 240)
            Me.lblJobNumber.Name = "lblJobNumber"
            Me.lblJobNumber.Size = New System.Drawing.Size(104, 20)
            Me.lblJobNumber.TabIndex = 10
            Me.lblJobNumber.Text = "Job Number:"
            Me.lblJobNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(352, 192)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 11
            '
            'ChooseCustomerPanel
            '
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.txtProjectName)
            Me.Controls.Add(Me.lblProjectName)
            Me.Controls.Add(Me.txtProjectCode)
            Me.Controls.Add(Me.lblProjectCode)
            Me.Controls.Add(Me.lblCustomer)
            Me.Controls.Add(Me.txtCustomerCode)
            Me.Controls.Add(Me.ibtnShowCustomerDialog)
            Me.Controls.Add(Me.txtCustomerName)
            Me.Controls.Add(Me.txtMessage)
            Me.Controls.Add(Me.lblJobNumber)
            Me.Controls.Add(Me.txtJobNumber)
            Me.Name = "ChooseCustomerPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCustomerCode.TextChanged, AddressOf Me.TextChangeHandler
            Me.NextWizardPanelID = "CreationSuccessful"
        End Sub
#End Region

#Region "Methods"
        Private codeTextChanged As Boolean = False
        Private Sub TextChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.Project Is Nothing Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustomercode"
                    codeTextChanged = True
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.Project Is Nothing Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustomercode"
                    If codeTextChanged Then
                        Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.Project.Customer)
                        codeTextChanged = False
                    End If
            End Select
        End Sub
        Public Sub SetLabelText()
            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.ChooseCustomerPanel.lblCustomer}")
            Me.Validator.SetDisplayName(Me.txtCustomerCode, Me.lblCustomer.Text)

            Me.lblProjectCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.ChooseCustomerPanel.lblProjectCode}")
            Me.Validator.SetDisplayName(Me.txtProjectCode, Me.lblProjectCode.Text)

            Me.lblProjectName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.ChooseCustomerPanel.lblProjectName}")
            Me.Validator.SetDisplayName(Me.txtProjectName, Me.lblProjectName.Text)

            Me.lblJobNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.ChooseCustomerPanel.lblJobNumber}")
            Me.Validator.SetDisplayName(Me.txtJobNumber, Me.lblJobNumber.Text)

            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewProjectWizard.ChooseCustomerPanel.DescriptionText}").Split(New Char() {ChrW(10)})
        End Sub
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Select Case message
                Case DialogMessage.Activated
                    If Not Me.Project Is Nothing Then
                        chkAutorun.Checked = Me.Project.AutoGen
                        UpdateAutogenStatus()
                    End If
                    Me.EnableFinish = False
                Case DialogMessage.Next
                    If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
                        msgServ.ShowMessage(Validator.ValidationSummary)
                        Return False
                    End If
                    If Not Me.Project Is Nothing Then
                        If Not Me.Project.AutoGen Then
                            Me.Project.Code = Me.txtProjectCode.Text
                        End If
                        Me.Project.Name = Me.txtProjectName.Text
                        Me.Project.Jobnumber = Me.txtJobNumber.Text
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
                Me.Validator.SetRequired(Me.txtProjectCode, False)
                Me.ErrorProvider1.SetError(Me.txtProjectCode, "")
                Me.txtProjectCode.ReadOnly = True
                m_oldCode = Me.Project.Code
                Me.txtProjectCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.Project.EntityId)
                'Hack: set Code เป็น "" เอง
                Me.Project.Code = ""
                Me.Project.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtProjectCode, True)
                Me.txtProjectCode.Text = m_oldCode
                Me.txtProjectCode.ReadOnly = False
                Me.Project.AutoGen = False
            End If
        End Sub
        Private Sub ibtnShowCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New Customer, AddressOf SetCustomer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            If Project Is Nothing Then
                Return
            End If
            Me.txtCustomerCode.Text = e.Code
            Customer.GetCustomer(txtCustomerCode, txtCustomerName, Project.Customer)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property Project() As Project
            Get
                If TypeOf Me.CustomizationObject Is Project Then
                    Return CType(Me.CustomizationObject, Project)
                End If
            End Get
        End Property
#End Region

    End Class
End Namespace

