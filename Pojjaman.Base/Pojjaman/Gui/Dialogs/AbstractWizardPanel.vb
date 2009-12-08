Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Gui.XmlForms
Namespace Longkong.Pojjaman.Gui.Dialogs
    Public Class AbstractWizardPanel
        Inherits AbstractOptionPanel
        Implements IWizardPanel

#Region "Members"
        Private m_enableCancel As Boolean
        Private m_enableNext As Boolean
        Private m_enablePrevious As Boolean
        Private m_isLastPanel As Boolean
        Private m_nextWizardPanelID As String
#End Region

#Region "Constructors"
        Public Sub New()
            Me.m_nextWizardPanelID = String.Empty
            Me.m_enablePrevious = True
            Me.m_enableNext = True
            Me.m_isLastPanel = False
            Me.m_enableCancel = True
        End Sub
        Public Sub New(ByVal fileName As String)
            MyBase.New(fileName)
            Me.m_nextWizardPanelID = String.Empty
            Me.m_enablePrevious = True
            Me.m_enableNext = True
            Me.m_isLastPanel = False
            Me.m_enableCancel = True
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
#End Region

    End Class
End Namespace

