Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard
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
        Friend WithEvents rdPMA As System.Windows.Forms.RadioButton
        Friend WithEvents rdCC As System.Windows.Forms.RadioButton
        Friend WithEvents rdNothing As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtMessage = New System.Windows.Forms.TextBox
            Me.rdPMA = New System.Windows.Forms.RadioButton
            Me.rdCC = New System.Windows.Forms.RadioButton
            Me.rdNothing = New System.Windows.Forms.RadioButton
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
            'rdPMA
            '
            Me.rdPMA.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdPMA.Location = New System.Drawing.Point(96, 128)
            Me.rdPMA.Name = "rdPMA"
            Me.rdPMA.Size = New System.Drawing.Size(224, 24)
            Me.rdPMA.TabIndex = 1
            Me.rdPMA.Text = "ต้องการบันทึกงวดงาน"
            '
            'rdCC
            '
            Me.rdCC.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdCC.Location = New System.Drawing.Point(96, 160)
            Me.rdCC.Name = "rdCC"
            Me.rdCC.Size = New System.Drawing.Size(224, 24)
            Me.rdCC.TabIndex = 2
            Me.rdCC.Text = "ต้องการดูรายละเอียด Cost Center"
            '
            'rdNothing
            '
            Me.rdNothing.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdNothing.Location = New System.Drawing.Point(96, 192)
            Me.rdNothing.Name = "rdNothing"
            Me.rdNothing.Size = New System.Drawing.Size(224, 24)
            Me.rdNothing.TabIndex = 3
            Me.rdNothing.Text = "ไม่ต้องการ"
            '
            'CreationFinishedPanel
            '
            Me.Controls.Add(Me.rdNothing)
            Me.Controls.Add(Me.rdPMA)
            Me.Controls.Add(Me.rdCC)
            Me.Controls.Add(Me.txtMessage)
            Me.Name = "CreationFinishedPanel"
            Me.Size = New System.Drawing.Size(408, 368)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            SetLabelText()
            Me.rdNothing.PerformClick()
        End Sub
#End Region

#Region "Methods"
        Public Sub SetLabelText()
            Me.rdCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreationFinishedPanel.rdCC}")
            Me.rdNothing.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreationFinishedPanel.rdNothing}")
            Me.rdPMA.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Dialogs.OptionPanels.NewCostCenterWizard.CreationFinishedPanel.rdPMA}")
            txtMessage.Lines = Me.StringParserService.Parse("${res:Dialog.Wizards.NewCostCenterWizard.CreationFinishedPanel.DescriptionText}").Split(New Char() {ChrW(10)})
        End Sub
        Public Overrides Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean
            Dim secSvc As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim epsvc As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case message
                Case DialogMessage.Finish
                    If Not Me.CostCenter Is Nothing Then
                        If Me.CostCenter.AutoGen Then
                            Me.CostCenter.Code = ""
                        End If
                        Dim saveErrorMessage As String = Me.CostCenter.Save(secSvc.CurrentUser.Id).Message
                        If Not IsNumeric(saveErrorMessage) Then 'Todo
                            msgServ.ShowMessage(saveErrorMessage)
                            Return False
                        End If
                        If Me.rdCC.Checked Then
                            Dim window As IWorkbenchWindow = epsvc.OpenDetailPanel(Me.CostCenter)
                        ElseIf Me.rdPMA.Checked Then
                            Dim pma As New PaymentApplication
                            pma.CostCenter = Me.CostCenter
                            Dim window As IWorkbenchWindow = epsvc.OpenDetailPanel(pma)
                            If Not window Is Nothing Then
                                window.ViewContent.IsDirty = True
                            End If
                        End If
                    End If
                Case Else
            End Select
            Return True
        End Function
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

