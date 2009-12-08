Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard
    Public Class StartPanel
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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.SuspendLayout()
            '
            'txtMessage
            '
            Me.txtMessage.Location = New System.Drawing.Point(8, 8)
            Me.txtMessage.Multiline = True
            Me.txtMessage.Name = "txtMessage"
            Me.txtMessage.ReadOnly = True
            Me.txtMessage.Size = New System.Drawing.Size(392, 80)
            Me.txtMessage.TabIndex = 1
            Me.txtMessage.TabStop = False
            Me.txtMessage.Text = ""
            '
            'StartPanel
            '
            Me.Controls.Add(Me.txtMessage)
            Me.Name = "StartPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Me.EnableFinish = False
            SetLabelText()
        End Sub
#End Region

#Region "Methods"
        Public Sub SetLabelText()
            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewProjectWizard.StartPanel.DescriptionText}").Split(New Char() {ChrW(10)})
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Select Case message
                Case DialogMessage.Activated
                    Me.EnableFinish = False
                Case DialogMessage.Next
                    Me.EnableFinish = True
            End Select
            Return True
        End Function
#End Region

    End Class
End Namespace

