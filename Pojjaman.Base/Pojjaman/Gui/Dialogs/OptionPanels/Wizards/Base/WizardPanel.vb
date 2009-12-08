Imports Longkong.Pojjaman.Gui.XmlForms
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports Longkong.Core.AddIns.Codons
Namespace Longkong.Pojjaman.Gui.Dialogs.OptionPanels
    Public Class WizardPanel
        Inherits UserControl
        Implements IWizardPanel, IDialogPanel

#Region "Members"
        Private m_enableCancel As Boolean
        Private m_enableNext As Boolean
        Private m_enablePrevious As Boolean
        Private m_isLastPanel As Boolean
        Private m_nextWizardPanelID As String
        Private m_customizationObject As Object
        Private m_isFinished As Boolean
        Private m_wasActivated As Boolean
        Private m_stringParserService As StringParserService
#End Region

#Region "Events"
        Public Event CustomizationObjectChanged As EventHandler
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_wasActivated = False
            Me.m_isFinished = True
            Me.m_customizationObject = Nothing
            Me.m_nextWizardPanelID = String.Empty
            Me.m_enablePrevious = True
            Me.m_enableNext = True
            Me.m_isLastPanel = False
            Me.m_enableCancel = True
        End Sub
#End Region

#Region "Properties"
        Public ReadOnly Property WasActivated() As Boolean
            Get
                Return Me.m_wasActivated
            End Get
        End Property
        Public ReadOnly Property StringParserService() As StringParserService            Get                If m_stringParserService Is Nothing Then                    m_stringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                End If                Return m_stringParserService            End Get        End Property
#End Region

#Region "Methods"
        Protected Overridable Sub FinishPanel()
            RaiseEvent FinishPanelRequested(Me, EventArgs.Empty)
        End Sub
        Protected Overridable Sub OnEnableCancelChanged(ByVal e As EventArgs)
            RaiseEvent EnableCancelChanged(Me, e)
        End Sub
        Protected Overridable Sub OnEnableNextChanged(ByVal e As EventArgs)
            RaiseEvent EnableNextChanged(Me, e)
        End Sub
        Protected Overridable Sub OnEnablePreviousChanged(ByVal e As EventArgs)
            RaiseEvent EnablePreviousChanged(Me, e)
        End Sub
        Protected Overridable Sub OnIsLastPanelChanged(ByVal e As EventArgs)
            RaiseEvent IsLastPanelChanged(Me, e)
        End Sub
        Protected Overridable Sub OnNextWizardPanelIDChanged(ByVal e As EventArgs)
            RaiseEvent NextWizardPanelIDChanged(Me, e)
        End Sub
        Public Overridable Sub LoadPanelContents()
        End Sub
        Protected Overridable Sub OnCustomizationObjectChanged()
            RaiseEvent CustomizationObjectChanged(Me, Nothing)
        End Sub
        Protected Overridable Sub OnEnableFinishChanged()
            RaiseEvent EnableFinishChanged(Me, Nothing)
        End Sub
        Public Overridable Function StorePanelContents() As Boolean
            Return True
        End Function
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaint(e)
            ControlPaint.DrawBorder3D(e.Graphics, e.ClipRectangle, Border3DStyle.Flat, Border3DSide.Bottom)
        End Sub
#End Region

#Region "IWizardPanel"
        Public Event EnableCancelChanged As EventHandler Implements Core.AddIns.Codons.IWizardPanel.EnableCancelChanged
        Public Event EnableNextChanged As EventHandler Implements Core.AddIns.Codons.IWizardPanel.EnableNextChanged
        Public Event EnablePreviousChanged As EventHandler Implements Core.AddIns.Codons.IWizardPanel.EnablePreviousChanged
        Public Event FinishPanelRequested As EventHandler Implements Core.AddIns.Codons.IWizardPanel.FinishPanelRequested
        Public Event IsLastPanelChanged As EventHandler Implements Core.AddIns.Codons.IWizardPanel.IsLastPanelChanged
        Public Event NextWizardPanelIDChanged As EventHandler Implements Core.AddIns.Codons.IWizardPanel.NextWizardPanelIDChanged

        Public Property EnableCancel() As Boolean Implements Core.AddIns.Codons.IWizardPanel.EnableCancel
            Get
                Return Me.m_enableCancel
            End Get
            Set(ByVal value As Boolean)
                If (Me.m_enableCancel <> value) Then
                    Me.m_enableCancel = value
                    Me.OnEnableCancelChanged(EventArgs.Empty)
                End If
            End Set
        End Property
        Public Property EnableNext() As Boolean Implements Core.AddIns.Codons.IWizardPanel.EnableNext
            Get
                Return Me.m_enableNext
            End Get
            Set(ByVal value As Boolean)
                If (Me.m_enableNext <> value) Then
                    Me.m_enableNext = value
                    Me.OnEnableNextChanged(EventArgs.Empty)
                End If
            End Set
        End Property
        Public Property EnablePrevious() As Boolean Implements Core.AddIns.Codons.IWizardPanel.EnablePrevious
            Get
                Return Me.m_enablePrevious
            End Get
            Set(ByVal value As Boolean)
                If (Me.m_enablePrevious <> value) Then
                    Me.m_enablePrevious = value
                    Me.OnEnablePreviousChanged(EventArgs.Empty)
                End If
            End Set
        End Property
        Public Property IsLastPanel() As Boolean Implements Core.AddIns.Codons.IWizardPanel.IsLastPanel
            Get
                Return Me.m_isLastPanel
            End Get
            Set(ByVal value As Boolean)
                If (Me.m_isLastPanel <> value) Then
                    Me.m_isLastPanel = value
                    Me.OnIsLastPanelChanged(EventArgs.Empty)
                End If
            End Set
        End Property
        Public Property NextWizardPanelID() As String Implements Core.AddIns.Codons.IWizardPanel.NextWizardPanelID
            Get
                Return Me.m_nextWizardPanelID
            End Get
            Set(ByVal value As String)
                If (Not Me.m_nextWizardPanelID Is value) Then
                    Me.m_nextWizardPanelID = value
                    Me.OnNextWizardPanelIDChanged(EventArgs.Empty)
                End If
            End Set
        End Property
#End Region

#Region "IDialogPanel"
        Public Event EnableFinishChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements Core.AddIns.Codons.IDialogPanel.EnableFinishChanged

        Public ReadOnly Property Control() As System.Windows.Forms.Control Implements Core.AddIns.Codons.IDialogPanel.Control
            Get
                Return Me
            End Get
        End Property
        Public Property CustomizationObject() As Object Implements Core.AddIns.Codons.IDialogPanel.CustomizationObject
            Get
                Return Me.m_customizationObject
            End Get
            Set(ByVal value As Object)
                Me.m_customizationObject = value
                Me.OnCustomizationObjectChanged()
            End Set
        End Property

        Public Property EnableFinish() As Boolean Implements Core.AddIns.Codons.IDialogPanel.EnableFinish
            Get
                Return Me.m_isFinished
            End Get
            Set(ByVal value As Boolean)
                If (Me.m_isFinished <> value) Then
                    Me.m_isFinished = value
                    Me.OnEnableFinishChanged()
                End If
            End Set
        End Property
        Public Overridable Function ReceiveDialogMessage(ByVal message As Core.AddIns.Codons.DialogMessage) As Boolean Implements Core.AddIns.Codons.IDialogPanel.ReceiveDialogMessage
            If (message <> DialogMessage.OK) Then
                If ((message = DialogMessage.Activated) AndAlso Not Me.m_wasActivated) Then
                    Me.LoadPanelContents()
                    Me.m_wasActivated = True
                End If
            Else
                If Me.m_wasActivated Then
                    Return Me.StorePanelContents
                End If
            End If
            Return True
        End Function
#End Region

    End Class
End Namespace

