Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.AddIns
Imports Longkong.Core.AddIns.Codons
Imports Longkong.Core.Properties
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Commands
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class WizardDialog
        Inherits Form

#Region "Members"
        Private m_activePanelNumber As Integer
        Private m_backButton As Button
        Private m_cancelButton As Button
        Private m_curPanel As CurrentPanelPanel
        Private m_dialogPanel As Panel
        Private m_finishButton As Button
        Private m_helpButton As Button
        Private m_idStack As Stack
        Private m_nextButton As Button
        Private m_statusPanel As StatusPanel
        Private m_wizardPanels As ArrayList

        Private m_finishPanelHandler As EventHandler
        Private m_enableNextChangedHandler As EventHandler
        Private m_nextWizardPanelIDChangedHandler As EventHandler
        Private m_enableCancelChangedHandler As EventHandler
#End Region

#Region "Constructrs"
        Public Sub New(ByVal title As String, ByVal customizer As Object, ByVal treePath As String)
            Me.KeyPreview = True
            Me.m_statusPanel = Nothing
            Me.m_curPanel = Nothing
            Me.m_dialogPanel = New Panel
            Me.m_idStack = New Stack
            Me.m_wizardPanels = New ArrayList
            Me.m_activePanelNumber = 0
            Me.m_backButton = New Button
            Me.m_nextButton = New Button
            Me.m_finishButton = New Button
            Me.m_cancelButton = New Button
            Me.m_helpButton = New Button
            Dim node As IAddInTreeNode = AddInTreeSingleton.AddInTree.GetTreeNode(treePath)
            Me.Text = title
            If (Not node Is Nothing) Then
                Me.AddNodes(customizer, node.BuildChildItems(Me))
            End If
            Me.InitializeComponents()
            Me.m_enableNextChangedHandler = New EventHandler(AddressOf Me.EnableNextChanged)
            Me.m_nextWizardPanelIDChangedHandler = New EventHandler(AddressOf Me.NextWizardPanelIDChanged)
            Me.m_enableCancelChangedHandler = New EventHandler(AddressOf Me.EnableCancelChanged)
            Me.m_finishPanelHandler = New EventHandler(AddressOf Me.FinishPanelEvent)
            Me.ActivatePanel(0)
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property ActivePanelNumber() As Integer
            Get
                Return Me.m_activePanelNumber
            End Get
        End Property
        Private ReadOnly Property CanFinish() As Boolean
            Get
                Dim successorIndex As Integer = 0
                Do While (successorIndex < Me.m_wizardPanels.Count)
                    Dim descriptor As IDialogPanelDescriptor = CType(Me.m_wizardPanels(successorIndex), IDialogPanelDescriptor)
                    If Not descriptor.DialogPanel.EnableFinish Then
                        Return False
                    End If
                    successorIndex = Me.GetSuccessorNumber(successorIndex)
                Loop
                Return True
            End Get
        End Property
        Public ReadOnly Property CurrentWizardPane() As IWizardPanel
            Get
                Return CType(CType(Me.m_wizardPanels(Me.m_activePanelNumber), IDialogPanelDescriptor).DialogPanel, IWizardPanel)
            End Get
        End Property
        Public ReadOnly Property WizardPanels() As ArrayList
            Get
                Return Me.m_wizardPanels
            End Get
        End Property
#End Region

#Region "Methods"
        Private Sub ActivatePanel(ByVal number As Integer)
            If (Not Me.CurrentWizardPane Is Nothing) Then
                RemoveHandler Me.CurrentWizardPane.EnableNextChanged, Me.m_enableNextChangedHandler
                RemoveHandler Me.CurrentWizardPane.EnableCancelChanged, Me.m_enableCancelChangedHandler
                RemoveHandler Me.CurrentWizardPane.EnablePreviousChanged, Me.m_enableNextChangedHandler
                RemoveHandler Me.CurrentWizardPane.NextWizardPanelIDChanged, Me.m_nextWizardPanelIDChangedHandler
                RemoveHandler Me.CurrentWizardPane.IsLastPanelChanged, Me.m_nextWizardPanelIDChangedHandler
                RemoveHandler Me.CurrentWizardPane.FinishPanelRequested, Me.m_finishPanelHandler
            End If
            Me.m_activePanelNumber = number
            If (Not Me.CurrentWizardPane Is Nothing) Then
                AddHandler Me.CurrentWizardPane.EnableNextChanged, Me.m_enableNextChangedHandler
                AddHandler Me.CurrentWizardPane.EnableCancelChanged, Me.m_enableCancelChangedHandler
                AddHandler Me.CurrentWizardPane.EnablePreviousChanged, Me.m_enableNextChangedHandler
                AddHandler Me.CurrentWizardPane.NextWizardPanelIDChanged, Me.m_nextWizardPanelIDChangedHandler
                AddHandler Me.CurrentWizardPane.IsLastPanelChanged, Me.m_nextWizardPanelIDChangedHandler
                AddHandler Me.CurrentWizardPane.FinishPanelRequested, Me.m_finishPanelHandler
            End If
            Me.EnableNextChanged(Nothing, Nothing)
            Me.NextWizardPanelIDChanged(Nothing, Nothing)
            Me.EnableCancelChanged(Nothing, Nothing)
            Me.m_statusPanel.Refresh()
            Me.m_curPanel.Refresh()
            Me.m_dialogPanel.Controls.Clear()
            Dim myWizardPane As Control = Me.CurrentWizardPane.Control
            myWizardPane.Dock = DockStyle.Fill
            Me.m_dialogPanel.Controls.Add(myWizardPane)
        End Sub
        Private Sub AddNodes(ByVal customizer As Object, ByVal dialogPanelDescriptors As ArrayList)
            For Each descriptor As IDialogPanelDescriptor In dialogPanelDescriptors
                If (Not descriptor.DialogPanel Is Nothing) Then
                    AddHandler descriptor.DialogPanel.EnableFinishChanged, New EventHandler(AddressOf Me.CheckFinishedState)
                    descriptor.DialogPanel.CustomizationObject = customizer
                    Me.m_wizardPanels.Add(descriptor)
                End If
                If (Not descriptor.DialogPanelDescriptors Is Nothing) Then
                    Me.AddNodes(customizer, descriptor.DialogPanelDescriptors)
                End If
            Next
        End Sub
        Private Sub CancelEvent(ByVal sender As Object, ByVal e As EventArgs)
            For Each descriptor As IDialogPanelDescriptor In Me.m_wizardPanels
                If Not descriptor.DialogPanel.ReceiveDialogMessage(DialogMessage.Cancel) Then
                    Return
                End If
            Next
            MyBase.DialogResult = DialogResult.Cancel
        End Sub
        Private Sub CheckFinishedState(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_finishButton.Enabled = Me.CanFinish
        End Sub
        Private Sub EnableCancelChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_cancelButton.Enabled = Me.CurrentWizardPane.EnableCancel
        End Sub
        Private Sub EnableNextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.m_nextButton.Enabled = (Me.CurrentWizardPane.EnableNext AndAlso (Me.GetSuccessorNumber(Me.m_activePanelNumber) < Me.m_wizardPanels.Count))
            Me.m_backButton.Enabled = (Me.CurrentWizardPane.EnablePrevious AndAlso (Me.m_idStack.Count > 0))
        End Sub
        Private Sub FinishEvent(ByVal sender As Object, ByVal e As EventArgs)
            For Each descriptor As IDialogPanelDescriptor In Me.m_wizardPanels
                If Not descriptor.DialogPanel.ReceiveDialogMessage(DialogMessage.Finish) Then
                    Return
                End If
            Next
            MyBase.DialogResult = DialogResult.OK
        End Sub
        Private Sub FinishPanelEvent(ByVal sender As Object, ByVal e As EventArgs)
            Dim panel As AbstractWizardPanel = CType(Me.CurrentWizardPane, AbstractWizardPanel)
            Dim oldStatus As Boolean = panel.IsLastPanel
            panel.IsLastPanel = False
            Me.ShowNextPanelEvent(sender, e)
            panel.IsLastPanel = oldStatus
        End Sub
        Private Function GetPanelNumber(ByVal id As String) As Integer
            For i As Integer = 0 To Me.m_wizardPanels.Count - 1
                Dim descriptor As IDialogPanelDescriptor = CType(Me.m_wizardPanels(i), IDialogPanelDescriptor)
                If (descriptor.ID = id) Then
                    Return i
                End If
            Next
            Return -1
        End Function
        Public Function GetSuccessorNumber(ByVal curNr As Integer) As Integer
            Dim panel As IWizardPanel = CType(CType(Me.m_wizardPanels.Item(curNr), IDialogPanelDescriptor).DialogPanel, IWizardPanel)
            If panel.IsLastPanel Then
                Return (Me.m_wizardPanels.Count + 1)
            End If
            Dim index As Integer = Me.GetPanelNumber(panel.NextWizardPanelID)
            If (index < 0) Then
                Return (curNr + 1)
            End If
            Return index
        End Function
        Private Sub HelpEvent(ByVal sender As Object, ByVal e As EventArgs)
            Me.CurrentWizardPane.ReceiveDialogMessage(DialogMessage.Help)
        End Sub
        Private Sub InitializeComponents()
            Dim myPropertyService As PropertyService = CType(ServiceManager.Services.GetService(GetType(PropertyService)), PropertyService)
            Dim myResourceService As ResourceService = CType(ServiceManager.Services.GetService(GetType(IResourceService)), ResourceService)
            MyBase.SuspendLayout()
            MyBase.ShowInTaskbar = False
            MyBase.StartPosition = FormStartPosition.CenterScreen
            MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.Icon = Nothing
            MyBase.ClientSize = New Size(640, 440)

            Dim buttonWidth As Integer = 92
            Dim buttonY As Integer = 412
            Dim firstButtonX As Integer = ((MyBase.Width - ((buttonWidth + 4) * 4)) - 4)

            Me.m_backButton.Text = myResourceService.GetString("Global.BackButtonText")
            Me.m_backButton.Location = New Point(firstButtonX, buttonY)
            Me.m_backButton.ClientSize = New Size(buttonWidth, 26)
            AddHandler Me.m_backButton.Click, New EventHandler(AddressOf Me.ShowPrevPanelEvent)
            Me.m_backButton.FlatStyle = FlatStyle.System
            Me.m_backButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            MyBase.Controls.Add(Me.m_backButton)

            Me.m_nextButton.Text = myResourceService.GetString("Global.NextButtonText")
            Me.m_nextButton.Location = New Point(((firstButtonX + buttonWidth) + 4), buttonY)
            Me.m_nextButton.ClientSize = New Size(buttonWidth, 26)
            AddHandler Me.m_nextButton.Click, New EventHandler(AddressOf Me.ShowNextPanelEvent)
            Me.m_nextButton.FlatStyle = FlatStyle.System
            Me.m_nextButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            MyBase.Controls.Add(Me.m_nextButton)

            Me.m_finishButton.Text = myResourceService.GetString("Dialog.WizardDialog.FinishButton")
            Me.m_finishButton.Location = New Point((firstButtonX + (2 * (buttonWidth + 4))), buttonY)
            Me.m_finishButton.ClientSize = New Size(buttonWidth, 26)
            AddHandler Me.m_finishButton.Click, New EventHandler(AddressOf Me.FinishEvent)
            Me.m_finishButton.FlatStyle = FlatStyle.System
            Me.m_finishButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            MyBase.Controls.Add(Me.m_finishButton)

            Me.m_cancelButton.Text = myResourceService.GetString("Global.CancelButtonText")
            Me.m_cancelButton.Location = New Point((firstButtonX + (3 * (buttonWidth + 4))), buttonY)
            Me.m_cancelButton.ClientSize = New Size(buttonWidth, 26)
            AddHandler Me.m_cancelButton.Click, New EventHandler(AddressOf Me.CancelEvent)
            Me.m_cancelButton.FlatStyle = FlatStyle.System
            Me.m_cancelButton.Anchor = (AnchorStyles.Right Or AnchorStyles.Bottom)
            MyBase.Controls.Add(Me.m_cancelButton)

            Me.m_statusPanel = New StatusPanel(Me)
            Me.m_statusPanel.Location = New Point(2, 2)
            Me.m_statusPanel.Anchor = (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top))
            MyBase.Controls.Add(Me.m_statusPanel)

            Me.m_curPanel = New CurrentPanelPanel(Me)
            Me.m_curPanel.Location = New Point(200, 2)
            Me.m_curPanel.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or AnchorStyles.Top))
            MyBase.Controls.Add(Me.m_curPanel)

            Me.m_dialogPanel.Location = New Point(200, 27)
            Me.m_dialogPanel.Size = New Size(((MyBase.Width - 8) - Me.m_statusPanel.Bounds.Right), 402 - Me.m_dialogPanel.Location.Y) '(Me.m_label1.Location.Y - Me.m_dialogPanel.Location.Y))
            Me.m_dialogPanel.Anchor = (AnchorStyles.Right Or (AnchorStyles.Left Or (AnchorStyles.Bottom Or AnchorStyles.Top)))
            MyBase.Controls.Add(Me.m_dialogPanel)

            MyBase.ResumeLayout(True)
        End Sub
        Private Sub NextWizardPanelIDChanged(ByVal sender As Object, ByVal e As EventArgs)
            Me.EnableNextChanged(Nothing, Nothing)
            Me.m_finishButton.Enabled = Me.CanFinish
            Me.m_statusPanel.Refresh()
        End Sub
        Private Sub ShowNextPanelEvent(ByVal sender As Object, ByVal e As EventArgs)
            Dim num1 As Integer = Me.GetSuccessorNumber(Me.ActivePanelNumber)
            If Me.CurrentWizardPane.ReceiveDialogMessage(DialogMessage.Next) Then
                Me.m_idStack.Push(Me.m_activePanelNumber)
                Me.ActivatePanel(num1)
                Me.CurrentWizardPane.ReceiveDialogMessage(DialogMessage.Activated)
            End If
        End Sub
        Private Sub ShowPrevPanelEvent(ByVal sender As Object, ByVal e As EventArgs)
            If Me.CurrentWizardPane.ReceiveDialogMessage(DialogMessage.Prev) Then
                Me.ActivatePanel(CType(Me.m_idStack.Pop, Integer))
            End If
        End Sub
#End Region

#Region "KeyDown"
        Private Sub WizardDialog_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
            Select Case e.KeyCode
                Case Keys.Enter
          If StartPojjamanWorkbenchCommand.ALLOWTAB Then
                    SendKeys.Send("{tab}")
          End If
                    e.Handled = True
            End Select
        End Sub
#End Region

    End Class
End Namespace

