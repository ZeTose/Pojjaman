Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard
    Public Class CreateCustomerPanel
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
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
        Friend WithEvents lblProjectName As System.Windows.Forms.Label
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents lblProjectCode As System.Windows.Forms.Label
        Friend WithEvents lblJobNumber As System.Windows.Forms.Label
        Friend WithEvents txtJobNumber As System.Windows.Forms.TextBox
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents chkCustAutoRun As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CreateCustomerPanel))
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.txtProjectCode = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtProjectName = New System.Windows.Forms.TextBox
            Me.txtJobNumber = New System.Windows.Forms.TextBox
            Me.lblProjectName = New System.Windows.Forms.Label
            Me.lblProjectCode = New System.Windows.Forms.Label
            Me.lblJobNumber = New System.Windows.Forms.Label
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.chkCustAutoRun = New System.Windows.Forms.CheckBox
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
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(-8, 128)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(112, 20)
            Me.lblCode.TabIndex = 6
            Me.lblCode.Text = "รหัสลูกค้า:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(104, 128)
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
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(104, 152)
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
            Me.lblName.Location = New System.Drawing.Point(-8, 152)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(112, 20)
            Me.lblName.TabIndex = 7
            Me.lblName.Text = "ชื่อลูกค้า:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
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
            Me.txtProjectCode.TabIndex = 3
            Me.txtProjectCode.Text = ""
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
            Me.txtProjectName.TabIndex = 4
            Me.txtProjectName.Text = ""
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
            Me.txtJobNumber.TabIndex = 5
            Me.txtJobNumber.Text = ""
            '
            'lblProjectName
            '
            Me.lblProjectName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProjectName.Location = New System.Drawing.Point(-8, 216)
            Me.lblProjectName.Name = "lblProjectName"
            Me.lblProjectName.Size = New System.Drawing.Size(112, 20)
            Me.lblProjectName.TabIndex = 9
            Me.lblProjectName.Text = "ชื่อโครงการประมูล:"
            Me.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProjectCode
            '
            Me.lblProjectCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProjectCode.Location = New System.Drawing.Point(-8, 192)
            Me.lblProjectCode.Name = "lblProjectCode"
            Me.lblProjectCode.Size = New System.Drawing.Size(112, 20)
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
            Me.chkAutorun.TabIndex = 12
            '
            'chkCustAutoRun
            '
            Me.chkCustAutoRun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkCustAutoRun.Image = CType(resources.GetObject("chkCustAutoRun.Image"), System.Drawing.Image)
            Me.chkCustAutoRun.Location = New System.Drawing.Point(352, 128)
            Me.chkCustAutoRun.Name = "chkCustAutoRun"
            Me.chkCustAutoRun.Size = New System.Drawing.Size(21, 21)
            Me.chkCustAutoRun.TabIndex = 12
            '
            'CreateCustomerPanel
            '
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.lblJobNumber)
            Me.Controls.Add(Me.txtJobNumber)
            Me.Controls.Add(Me.txtProjectName)
            Me.Controls.Add(Me.lblProjectName)
            Me.Controls.Add(Me.txtProjectCode)
            Me.Controls.Add(Me.lblProjectCode)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.txtMessage)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.chkCustAutoRun)
            Me.Name = "CreateCustomerPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            SetLabelText()
        End Sub
#End Region

#Region "Methods"
        Public Sub SetLabelText()
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.CreateCustomerPanel.lblCode}")
            Me.Validator.SetDisplayName(Me.txtCode, Me.lblCode.Text)

            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.CreateCustomerPanel.lblName}")
            Me.Validator.SetDisplayName(Me.txtName, Me.lblName.Text)

            Me.lblProjectCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.CreateCustomerPanel.lblProjectCode}")
            Me.Validator.SetDisplayName(Me.txtProjectCode, Me.lblProjectCode.Text)

            Me.lblProjectName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.CreateCustomerPanel.lblProjectName}")
            Me.Validator.SetDisplayName(Me.txtProjectName, Me.lblProjectName.Text)

            Me.lblJobNumber.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.CreateCustomerPanel.lblJobNumber}")
            Me.Validator.SetDisplayName(Me.txtJobNumber, Me.lblJobNumber.Text)

            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewProjectWizard.CreateCustomerPanel.DescriptionText}").Split(New Char() {ChrW(10)})
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

#Region "Event Handlers"
        Private Sub chkCustAutoRun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustAutoRun.CheckedChanged
            UpdateCustAutogenStatus()
        End Sub
        Private m_oldCustCode As String = ""
        Private Sub UpdateCustAutogenStatus()
            If Me.chkCustAutoRun.Checked Then
                Me.Validator.SetRequired(Me.txtCode, False)
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.txtCode.ReadOnly = True
                m_oldCustCode = Me.Project.Customer.Code
                Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.Project.Customer.EntityId)
                'Hack: set Code เป็น "" เอง
                Me.Project.Customer.Code = ""
                Me.Project.Customer.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtCode, True)
                Me.txtCode.Text = m_oldCustCode
                Me.txtCode.ReadOnly = False
                Me.Project.Customer.AutoGen = False
            End If
        End Sub

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
#End Region

#Region "Overrides"
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Select Case message
                Case DialogMessage.Activated
                    If Not Me.Project Is Nothing Then
                        Me.txtCode.Text = Me.Project.Customer.Code
                        Me.txtName.Text = Me.Project.Customer.Name
                        Me.txtProjectCode.Text = Me.Project.Code
                        Me.txtProjectName.Text = Me.Project.Name
                        Me.txtJobNumber.Text = Me.Project.Jobnumber
                        chkAutorun.Checked = Me.Project.AutoGen
                        UpdateAutogenStatus()

                        chkCustAutoRun.Checked = Me.Project.Customer.AutoGen
                        UpdateCustAutogenStatus()
                    End If
                    Me.EnableFinish = False
                Case DialogMessage.Next
                    If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
                        msgServ.ShowMessage(Validator.ValidationSummary)
                        Return False
                    End If
                    If Not Me.Project Is Nothing Then
                        If Not Me.Project.Customer.AutoGen Then
                            Me.Project.Customer.Code = Me.txtCode.Text
                        End If
                        Me.Project.Customer.Name = Me.txtName.Text
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

    End Class
End Namespace

