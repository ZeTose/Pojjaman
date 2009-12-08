Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard
    Public Class UseExistingCustomerPanel
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
        Friend WithEvents rdExist As System.Windows.Forms.RadioButton
        Friend WithEvents rdNotExist As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.rdExist = New System.Windows.Forms.RadioButton
            Me.rdNotExist = New System.Windows.Forms.RadioButton
            Me.SuspendLayout()
            '
            'txtMessage
            '
            Me.txtMessage.Location = New System.Drawing.Point(8, 8)
            Me.txtMessage.Multiline = True
            Me.txtMessage.Name = "txtMessage"
            Me.txtMessage.ReadOnly = True
            Me.txtMessage.Size = New System.Drawing.Size(392, 80)
            Me.txtMessage.TabIndex = 0
            Me.txtMessage.TabStop = False
            Me.txtMessage.Text = ""
            '
            'rdExist
            '
            Me.rdExist.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdExist.Location = New System.Drawing.Point(96, 128)
            Me.rdExist.Name = "rdExist"
            Me.rdExist.Size = New System.Drawing.Size(224, 24)
            Me.rdExist.TabIndex = 1
            Me.rdExist.Text = "มีในระบบ"
            '
            'rdNotExist
            '
            Me.rdNotExist.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdNotExist.Location = New System.Drawing.Point(96, 160)
            Me.rdNotExist.Name = "rdNotExist"
            Me.rdNotExist.Size = New System.Drawing.Size(224, 24)
            Me.rdNotExist.TabIndex = 2
            Me.rdNotExist.Text = "ไม่มีในระบบ"
            '
            'UseExistingCustomerPanel
            '
            Me.Controls.Add(Me.rdExist)
            Me.Controls.Add(Me.txtMessage)
            Me.Controls.Add(Me.rdNotExist)
            Me.Name = "UseExistingCustomerPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            'Me.EnableFinish = False
            SetLabelText()
            AddHandler rdExist.CheckedChanged, AddressOf Me.RDCheck
            AddHandler rdNotExist.CheckedChanged, AddressOf Me.RDCheck

            rdExist.PerformClick()
        End Sub
#End Region

#Region "Methods"
        Public Sub SetLabelText()
            Me.rdExist.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.UseExistingCustomerPanel.rdExist}")
            Me.rdNotExist.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard.UseExistingCustomerPanel.rdNotExist}")
            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewProjectWizard.UseExistingCustomerPanel.DescriptionText}").Split(New Char() {ChrW(10)})
        End Sub
        Private Sub RDCheck(ByVal sender As Object, ByVal e As EventArgs)
            If Me.rdExist.Checked Then
                Me.NextWizardPanelID = "ChooseCustomerPanel"
            Else
                Me.NextWizardPanelID = "CreateCustomerPanel"
            End If
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

#Region "Overrides"
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Select Case message
                Case DialogMessage.Activated
                    Me.EnableFinish = False
                Case DialogMessage.Next
                    If Not Me.Project Is Nothing Then
                        If Me.rdNotExist.Checked Then
                            Me.Project.Customer = New Customer
                            Me.Project.Customer.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.Customer).Account
                            Me.Project.Customer.BillingAddress = Me.StringParserService.Parse("${res:Global.Temp}")
                        End If
                    End If
                    Me.EnableFinish = True
            End Select
            Return True
        End Function
#End Region

    End Class
End Namespace

