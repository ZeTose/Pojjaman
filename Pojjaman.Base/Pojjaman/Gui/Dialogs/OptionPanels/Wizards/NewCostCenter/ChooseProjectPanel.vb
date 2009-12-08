Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard
    Public Class ChooseProjectPanel
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
        Friend WithEvents lblProject As System.Windows.Forms.Label
        Friend WithEvents txtProjectCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowProjectDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChooseProjectPanel))
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.lblProject = New System.Windows.Forms.Label
            Me.txtProjectCode = New System.Windows.Forms.TextBox
            Me.ibtnShowProjectDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtProjectName = New System.Windows.Forms.TextBox
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
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
            'lblProject
            '
            Me.lblProject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblProject.Location = New System.Drawing.Point(-8, 136)
            Me.lblProject.Name = "lblProject"
            Me.lblProject.Size = New System.Drawing.Size(88, 20)
            Me.lblProject.TabIndex = 2
            Me.lblProject.Text = "โครงการ:"
            Me.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProjectCode
            '
            Me.txtProjectCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtProjectCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectCode, "")
            Me.txtProjectCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectCode, System.Drawing.Color.Empty)
            Me.txtProjectCode.Location = New System.Drawing.Point(80, 136)
            Me.txtProjectCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtProjectCode, "")
            Me.Validator.SetMinValue(Me.txtProjectCode, "")
            Me.txtProjectCode.Name = "txtProjectCode"
            Me.Validator.SetRegularExpression(Me.txtProjectCode, "")
            Me.Validator.SetRequired(Me.txtProjectCode, True)
            Me.txtProjectCode.Size = New System.Drawing.Size(88, 21)
            Me.txtProjectCode.TabIndex = 1
            Me.txtProjectCode.Text = ""
            '
            'ibtnShowProjectDialog
            '
            Me.ibtnShowProjectDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowProjectDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowProjectDialog.Image = CType(resources.GetObject("ibtnShowProjectDialog.Image"), System.Drawing.Image)
            Me.ibtnShowProjectDialog.Location = New System.Drawing.Point(352, 135)
            Me.ibtnShowProjectDialog.Name = "ibtnShowProjectDialog"
            Me.ibtnShowProjectDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowProjectDialog.TabIndex = 4
            Me.ibtnShowProjectDialog.TabStop = False
            Me.ibtnShowProjectDialog.ThemedImage = CType(resources.GetObject("ibtnShowProjectDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtProjectName
            '
            Me.txtProjectName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtProjectName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtProjectName, "")
            Me.txtProjectName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtProjectName, System.Drawing.Color.Empty)
            Me.txtProjectName.Location = New System.Drawing.Point(168, 136)
            Me.txtProjectName.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtProjectName, "")
            Me.Validator.SetMinValue(Me.txtProjectName, "")
            Me.txtProjectName.Name = "txtProjectName"
            Me.txtProjectName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtProjectName, "")
            Me.Validator.SetRequired(Me.txtProjectName, False)
            Me.txtProjectName.Size = New System.Drawing.Size(184, 21)
            Me.txtProjectName.TabIndex = 3
            Me.txtProjectName.TabStop = False
            Me.txtProjectName.Text = ""
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
            'ChooseProjectPanel
            '
            Me.Controls.Add(Me.lblProject)
            Me.Controls.Add(Me.txtProjectCode)
            Me.Controls.Add(Me.ibtnShowProjectDialog)
            Me.Controls.Add(Me.txtProjectName)
            Me.Controls.Add(Me.txtMessage)
            Me.Name = "ChooseProjectPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            AddHandler txtProjectCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtProjectCode.TextChanged, AddressOf Me.TextChangeHandler
            Me.NextWizardPanelID = "ChooseBOQPanel"
        End Sub
#End Region

#Region "Methods"
        Private codeTextChanged As Boolean = False
        Private Sub TextChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtprojectcode"
                    codeTextChanged = True
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtprojectcode"
                    If codeTextChanged Then
                        Project.GetProject(txtProjectCode, txtProjectName, CostCenter.Project)
                        codeTextChanged = False
                    End If
            End Select
        End Sub
        Public Sub SetLabelText()
            Me.lblProject.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.ChooseProjectPanel.lblProject}")
            Me.Validator.SetDisplayName(Me.txtProjectCode, Me.lblProject.Text)
            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewCostCenterWizard.ChooseProjectPanel.DescriptionText}").Split(New Char() {ChrW(10)})
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Select Case message
                Case DialogMessage.Activated
                    Me.EnableFinish = False
                Case DialogMessage.Next
                    If Not Validator.ValidationSummary Is Nothing AndAlso Validator.ValidationSummary.Length > 0 Then
                        msgServ.ShowMessage(Validator.ValidationSummary)
                        Return False
                    End If
                    Me.EnableFinish = True
            End Select
            Return True
        End Function
#End Region

#Region "Event handlers"
        Private Sub ibtnShowProjectDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowProjectDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New Project, AddressOf SetProject)
        End Sub
        Private Sub SetProject(ByVal e As ISimpleEntity)
            Me.txtProjectCode.Text = e.Code
            Project.GetProject(txtProjectCode, txtProjectName, CostCenter.Project)
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

