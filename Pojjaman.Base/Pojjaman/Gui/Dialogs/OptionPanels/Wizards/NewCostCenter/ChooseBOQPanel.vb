Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard
    Public Class ChooseBOQPanel
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
        Friend WithEvents lblBOQ As System.Windows.Forms.Label
        Friend WithEvents txtBOQCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowBOQDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChooseBOQPanel))
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.lblBOQ = New System.Windows.Forms.Label
            Me.txtBOQCode = New System.Windows.Forms.TextBox
            Me.ibtnShowBOQDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
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
            'lblBOQ
            '
            Me.lblBOQ.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBOQ.Location = New System.Drawing.Point(16, 136)
            Me.lblBOQ.Name = "lblBOQ"
            Me.lblBOQ.Size = New System.Drawing.Size(64, 20)
            Me.lblBOQ.TabIndex = 2
            Me.lblBOQ.Text = "BOQ:"
            Me.lblBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBOQCode
            '
            Me.txtBOQCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtBOQCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBOQCode, "")
            Me.txtBOQCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBOQCode, System.Drawing.Color.Empty)
            Me.txtBOQCode.Location = New System.Drawing.Point(80, 136)
            Me.txtBOQCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtBOQCode, "")
            Me.Validator.SetMinValue(Me.txtBOQCode, "")
            Me.txtBOQCode.Name = "txtBOQCode"
            Me.Validator.SetRegularExpression(Me.txtBOQCode, "")
            Me.Validator.SetRequired(Me.txtBOQCode, False)
            Me.txtBOQCode.Size = New System.Drawing.Size(272, 21)
            Me.txtBOQCode.TabIndex = 1
            Me.txtBOQCode.Text = ""
            '
            'ibtnShowBOQDialog
            '
            Me.ibtnShowBOQDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowBOQDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowBOQDialog.Image = CType(resources.GetObject("ibtnShowBOQDialog.Image"), System.Drawing.Image)
            Me.ibtnShowBOQDialog.Location = New System.Drawing.Point(352, 136)
            Me.ibtnShowBOQDialog.Name = "ibtnShowBOQDialog"
            Me.ibtnShowBOQDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowBOQDialog.TabIndex = 3
            Me.ibtnShowBOQDialog.TabStop = False
            Me.ibtnShowBOQDialog.ThemedImage = CType(resources.GetObject("ibtnShowBOQDialog.ThemedImage"), System.Drawing.Bitmap)
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
            'ChooseBOQPanel
            '
            Me.Controls.Add(Me.ibtnShowBOQDialog)
            Me.Controls.Add(Me.lblBOQ)
            Me.Controls.Add(Me.txtBOQCode)
            Me.Controls.Add(Me.txtMessage)
            Me.Name = "ChooseBOQPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            AddHandler txtBOQCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtBOQCode.TextChanged, AddressOf Me.TextChangeHandler
        End Sub
#End Region

#Region "Methods"
        Private codeTextChanged As Boolean = False
        Private Sub TextChangeHandler(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtboqcode"
                    codeTextChanged = True
            End Select
        End Sub
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Select Case CType(sender, Control).Name.ToLower
                Case "txtboqcode"
                    If codeTextChanged Then
                        BOQ.GetBOQ(txtBOQCode, CostCenter.Boq)
                        codeTextChanged = False
                    End If
            End Select
        End Sub
        Public Sub SetLabelText()
            Me.lblBOQ.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.ChooseBOQPanel.lblBOQ}")
            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewCostCenterWizard.ChooseBOQPanel.DescriptionText}").Split(New Char() {ChrW(10)})
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
        Private Sub ibtnShowBOQDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowBOQDialog.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New BOQ, AddressOf SetBOQ)
        End Sub
        Private Sub SetBOQ(ByVal e As ISimpleEntity)
            Me.txtBOQCode.Text = e.Code
            BOQ.GetBOQ(txtBOQCode, CostCenter.Boq)
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

