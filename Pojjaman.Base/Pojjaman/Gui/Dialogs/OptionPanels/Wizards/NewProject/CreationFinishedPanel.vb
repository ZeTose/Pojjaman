Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewProjectWizard
    Public Class CreationFinishedPanel
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
            'CreationFinishedPanel
            '
            Me.Controls.Add(Me.txtMessage)
            Me.Name = "CreationFinishedPanel"
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
            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewProjectWizard.CreationFinishedPanel.DescriptionText}").Split(New Char() {ChrW(10)})
        End Sub
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim secSvc As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim epsvc As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case message
                Case DialogMessage.Finish
                    If Not Me.Project Is Nothing Then
                        If Not Me.Project.Customer.Originated Then
                            If Me.Project.AutoGen Then
                                Me.Project.Code = ""
                            End If
                            Dim errorMessage As String = Me.Project.Customer.Save(secSvc.CurrentUser.Id).Message
                            If Not IsNumeric(errorMessage) Then 'Todo
                                msgServ.ShowMessage(errorMessage)
                                Return False
                            End If
                        End If
                        Dim saveErrorMessage As String = Me.Project.Save(secSvc.CurrentUser.Id).Message
                        If Not IsNumeric(saveErrorMessage) Then 'Todo
                            msgServ.ShowMessage(saveErrorMessage)
                            Return False
                        End If
                        Dim window As IWorkbenchWindow = epsvc.OpenDetailPanel(Me.Project)
                        If Not window Is Nothing Then
                            window.ViewContent.IsDirty = True
                        End If
                    End If
                Case Else
            End Select
            Return True
        End Function
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

